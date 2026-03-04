using System.Data;

namespace FunctionViewer;

public partial class MainFormVer2 : Form
{
	readonly Color defaultInputBgColor;
	readonly Color invalidDataInputBgColor = Color.FromArgb(240, 219, 220);
	private CancellationTokenSource? _cts;

	public MainFormVer2()
	{
		InitializeComponent();
		Text = Program.GetName(version: 2);

		defaultInputBgColor = inputFrom.BackColor;
		btnRecalculate.Click += btnRecalculate_Click;
		dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
	}


	bool TryParseValueFrom(TextBox input, out double value)
	{
		bool isValid = input.Text.TryParseToDouble(out value);
		DisplayValid(input, isValid);
		return isValid;
	}
	void DisplayValid(TextBox input, bool isValid)
	{
		input.BackColor = isValid ? defaultInputBgColor : invalidDataInputBgColor;
	}

	// На память
	[Obsolete]
	void UpdateCalculationsSync()
	{
		minFuncValueTextBox.Text = "";
		maxFuncValueTextBox.Text = "";
		dataGridView1.Rows.Clear();

		bool isAllValid = new bool[] {
			TryParseValueFrom(inputFrom, out var from),
			TryParseValueFrom(inputTo, out var to),
			TryParseValueFrom(inputStep, out var step)
		}.All();

		if (step <= 0)
		{
			DisplayValid(inputStep, false);
			isAllValid = false;
		}

		if (!isAllValid) return;

		double x = from;
		while (x <= to)
		{
			double y = Program.Function(x);

			dataGridView1.Rows.Add();
			var i = dataGridView1.Rows.Count - 1;
			dataGridView1.Rows[i].Cells[0].Value = x;
			dataGridView1.Rows[i].Cells[1].Value = y;

			x += step;
		}
		
		// Тупо конечно, сначала наполнил датафрейм
		// Потом прошёлся по нему XD
		// А надо было сразу min & max считать
		// Устал чёт

		double min = Enumerable
			.Range(0, dataGridView1.Rows.Count)
			.Select(x => dataGridView1.Rows[x].Cells[1].Value)
			//.Where(x => x != null && x is double)
			//.Select(x => (double)x)
			.OfType<double>()
			.Where(x => !double.IsNaN(x))
			.Min();

		double max = double.MinValue;
		for (int i = 0; i < dataGridView1.Rows.Count; i++)
		{
			object? value = dataGridView1.Rows[i].Cells[1].Value;
			if (value == null) continue;
			if (value is not double unpackedValue)
				continue;

			if (double.IsNaN(unpackedValue)) continue;
			if (unpackedValue > max)
				max = unpackedValue;
		}

		maxFuncValueTextBox.Text = max.ToString();
		minFuncValueTextBox.Text = min.ToString();
	}

	async Task UpdateCalculationsAsync(CancellationToken token)
	{
		minFuncValueTextBox.Text = "";
		maxFuncValueTextBox.Text = "";
		dataGridView1.Rows.Clear();

		// Корректный доступ к UI элементам
		// возможен только из UI потока
		if (
			!TryParseValueFrom(inputFrom, out var from) ||
			!TryParseValueFrom(inputTo, out var to) ||
			!TryParseValueFrom(inputStep, out var step)
		) return;

		bool someInvalid = false;
		if (to < from)
		{
			DisplayValid(inputTo, false);
			someInvalid = true;
		}

		if (step <= 0)
		{
			DisplayValid(inputStep, false);
			someInvalid = true;
		}

		if (someInvalid)
			return;

		var progress = new Progress<((double x, double y)[] pack, ushort size)>(pointsPackBlock =>
		{
			var (pack, size) = pointsPackBlock;
			for (byte i = 0; i < size; i++)
				dataGridView1.Rows.Add(pack[i].x, pack[i].y);
		});

		var (min, max) = await Task.Run(() => ComputePoints(from, to, step, progress, token));

		maxFuncValueTextBox.Text = max.ToString();
		minFuncValueTextBox.Text = min.ToString();
	}

	(double min, double max) ComputePoints(
		double from, double to, double step,
		IProgress<((double x, double y)[] pack, ushort size)> progress,
		CancellationToken token
	)
	{
		// Всё равно виснет как собака -_-
		const ushort REPORT_BUFFER_SIZE = 100;
		var reportBuffer = new (double x, double y)[REPORT_BUFFER_SIZE];
		ushort reportBufferCounter = 0;

		double min = double.MaxValue;
		double max = double.MinValue;

		double x = from;
		while (x <= to)
		{
			token.ThrowIfCancellationRequested();

			double y = Program.Function(x);
			if (!double.IsNaN(y))
			{
				if (max < y) max = y;
				if (min > y) min = y;
			}

			reportBuffer[reportBufferCounter] = (x, y);
			reportBufferCounter++;

			if (reportBufferCounter == REPORT_BUFFER_SIZE)
			{
				progress.Report((reportBuffer, REPORT_BUFFER_SIZE));
				reportBufferCounter = 0;
			}

			x += step;
		}

		if (reportBufferCounter > 0)
			progress.Report((reportBuffer, reportBufferCounter));

		if (min == double.MaxValue) min = double.NaN;
		if (max == double.MinValue) max = double.NaN;

		return (min, max);
	}

	async void btnRecalculate_Click(object? sender, EventArgs e)
	{
		_cts?.Cancel();
		using var cts = new CancellationTokenSource();
		_cts = cts;

		try { await UpdateCalculationsAsync(cts.Token); }
		catch (OperationCanceledException) { }
		finally { if (_cts == cts) _cts = null; }
	}
}
