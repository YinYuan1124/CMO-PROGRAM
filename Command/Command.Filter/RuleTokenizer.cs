using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Filter;

[StandardModule]
internal sealed class RuleTokenizer
{
	public enum ParseDateTimeResult
	{
		Ok,
		BadDate,
		BadTime
	}

	public static int SearchServer(string string_0, ref DateTime dateTime_0)
	{
		if (DateTime.TryParse(string_0, out dateTime_0))
		{
			return 0;
		}
		return 1;
	}

	public static int EnableServer(string string_0, ref DateTime dateTime_0)
	{
		if (DateTime.TryParse(string_0, out dateTime_0))
		{
			return 0;
		}
		return 2;
	}

	public static int ChangeServer(string string_0, string string_1, ref DateTime dateTime_0)
	{
		int num = 0;
		DateTime dateTime_ = default(DateTime);
		num = SearchServer(string_0, ref dateTime_);
		if (num == 0)
		{
			num = EnableServer(string_1, ref dateTime_);
			if (num == 0 && !DateTime.TryParse(string_0 + " " + string_1, out dateTime_0))
			{
				num = 2;
			}
		}
		return num;
	}
}
