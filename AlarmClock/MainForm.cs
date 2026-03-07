using System.ComponentModel;
using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace AlarmClock;

public partial class MainForm : Form
{
	const string BTN_ENABLE_TEXT = "Завести";
	const string BTN_DISABLE_TEXT = "Остановить";

	bool _enabled = false;

	CancellationTokenSource? _updateLoopCts;
	CancellationTokenSource? _alarmSoundCts;

	public MainForm()
	{
		InitializeComponent();
	}
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		_updateLoopCts = new();
		_ = UpdateLoop(_updateLoopCts.Token);
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		_updateLoopCts?.Cancel();
		_alarmSoundCts?.Cancel();
		base.OnFormClosing(e);
	}

	// Можно создать Func<CancellationTokenSource> и кешировать выбранную лямбду
	CancellationTokenSource PlayAlarmSound()
	{
		var cts = new CancellationTokenSource();
		var resources = new ComponentResourceManager(typeof(MainForm));
		var token = cts.Token;

		var soundRaw = resources.GetObject("alarm-sound");

		Func<Task> playSoundAsync;
		if (soundRaw is not Stream soundStream) playSoundAsync = async () =>
		{
			while (!token.IsCancellationRequested)
			{
				SystemSounds.Beep.Play();
				try { await Task.Delay(1200, token).ConfigureAwait(false); }
				catch (OperationCanceledException) { break; }
			}
		};
		else playSoundAsync = async () =>
		{
			var sp = new SoundPlayer(soundStream);
			try
			{
				while (!token.IsCancellationRequested)
				{
					soundStream.Position = 0;
					sp.PlaySync();
					await Task.Delay(600, token).ConfigureAwait(false);
				}
			}
			catch (OperationCanceledException) { }
			finally { sp.Dispose(); }
		};

		Task.Run(playSoundAsync, token);
		return cts;
	}

	// Обычный Timer был бы идиоматичней
	async Task UpdateLoop(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			Invoke(() => {
				machineTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");

				if (!_enabled || _alarmSoundCts != null)
					return;
				if (!TryParseTime(targetTimeInput.Text, out int hour, out int minute))
					return;

				var now = DateTime.Now;
				if (now.Hour == hour && now.Minute == minute)
					_alarmSoundCts = PlayAlarmSound();
			});

			try { await Task.Delay(300, token).ConfigureAwait(false); }
			catch (OperationCanceledException) { break; }
		}
	}

	private bool TryParseTime(string text, out int hour, out int minute)
	{
		hour = 0; minute = 0;
		var parts = text.Split(':');

		if (parts.Length != 2)
			return false;

		if (!int.TryParse(parts[0].Trim(), out hour) ||
			!int.TryParse(parts[1].Trim(), out minute))
			return false;

		if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
			return false;

		return true;
	}

	private void btnToggle_Click(object sender, EventArgs e)
	{
		targetTimeInput.Enabled = !_enabled;
		btnToggleAlarm.Text = _enabled ? BTN_DISABLE_TEXT : BTN_ENABLE_TEXT;

		if (_enabled)
		{
			_enabled = false;
			if (_alarmSoundCts != null)
			{
				_alarmSoundCts.Cancel();
				_alarmSoundCts.Dispose();
				_alarmSoundCts = null;
			}
			return;
		}

		if (!TryParseTime(targetTimeInput.Text, out _, out _))
		{
			MessageBox.Show(
				"Введите корректное время в формате ЧЧ:ММ.", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Warning
			);
			return;
		}

		_enabled = true;
	}
}
