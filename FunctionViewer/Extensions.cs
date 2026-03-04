using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FunctionViewer;

internal static class Extensions
{
	public static bool TryParseToDouble(this string str, out double value)
		=> double.TryParse(str.Replace('.', ','), out value);

	public static bool All(this IEnumerable<bool> enumerable)
		=> enumerable.All(x => x);
}
