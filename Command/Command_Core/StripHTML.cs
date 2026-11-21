using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class StripHTML
{
	private static Regex watcherProxy;

	static StripHTML()
	{
		watcherProxy = new Regex("<.*?>", RegexOptions.Compiled);
	}

	internal static string InterruptSpecification(string string_0)
	{
		return Regex.Replace(string_0, "<.*?>", string.Empty);
	}

	internal static string RemoveSpecification(string string_0)
	{
		return watcherProxy.Replace(string_0, string.Empty).Replace("&nbsp;", " ").Replace("\ufffd", Conversions.ToString(Strings.Chr(176)));
	}

	internal static string FindSpecification(string string_0)
	{
		char[] array = new char[string_0.Length - 1 + 1];
		int num = 0;
		bool flag = false;
		int num2 = string_0.Length - 1;
		for (int i = 0; i <= num2; i++)
		{
			char c = string_0[i];
			switch (c)
			{
			case '>':
				flag = false;
				continue;
			case '<':
				flag = true;
				continue;
			}
			if (!flag)
			{
				array[num] = c;
				num++;
			}
		}
		return new string(array, 0, num);
	}
}
