using System;
using System.Globalization;
using System.Linq;

namespace CSMaterial;

public static class FastDoubleParse
{
	private static readonly char _DispatcherDispatcher;

	private static readonly char m_ListenerDispatcher;

	private static readonly char m_ConfigDispatcher;

	private static readonly string m_RegistryDispatcher;

	private static readonly string definitionDispatcher;

	private static readonly string _ValDispatcher;

	private static readonly string m_WrapperDispatcher;

	private static readonly double[] observerDispatcher;

	private static readonly double[] m_IssuerDispatcher;

	public static bool FastTryParseDouble(string string_0, out double double_0)
	{
		int length = string_0.Length;
		if (length <= 0)
		{
			double_0 = double.NaN;
			return false;
		}
		double num = 1.0;
		int num2 = 0;
		char c = string_0[0];
		if (c < '0' || c > '9')
		{
			if (length == 1)
			{
				return CheckForSpecialCaseDoubleStrings(string_0, out double_0);
			}
			if (c == _DispatcherDispatcher)
			{
				num = -1.0;
			}
			else
			{
				if (c == m_ConfigDispatcher)
				{
					double_0 = 0.0;
					goto IL_0162;
				}
				if (c != m_ListenerDispatcher)
				{
					return CheckForSpecialCaseDoubleStrings(string_0, out double_0);
				}
			}
			c = string_0[++num2];
			if (c < '0' || c > '9')
			{
				if (c == m_ConfigDispatcher)
				{
					double_0 = 0.0;
					goto IL_0162;
				}
				return CheckForSpecialCaseDoubleStrings(string_0, out double_0);
			}
		}
		double_0 = c - 48;
		while (++num2 < length)
		{
			c = string_0[num2];
			if (c < '0' || c > '9')
			{
				break;
			}
			double_0 = double_0 * 10.0 + (double)(c - 48);
		}
		goto IL_0162;
		IL_0162:
		if (c == m_ConfigDispatcher)
		{
			int num3 = ++num2;
			do
			{
				c = string_0[num2];
				if (c > '9' || c < '0')
				{
					break;
				}
				double_0 = double_0 * 10.0 + (double)(c - 48);
			}
			while (++num2 < length);
			num3 = num2 - num3;
			double_0 *= ((num3 < 16) ? m_IssuerDispatcher[num3] : ((num3 < 308) ? observerDispatcher[308 + num3] : Math.Pow(10.0, -num3)));
		}
		double_0 *= num;
		if (num2 >= length)
		{
			return true;
		}
		if (c != 'e' && c != 'E')
		{
			return false;
		}
		if (++num2 >= length)
		{
			return false;
		}
		c = string_0[num2];
		bool flag = false;
		if (c < '0' || c > '9')
		{
			if (c == _DispatcherDispatcher)
			{
				flag = true;
			}
			else if (c != m_ListenerDispatcher)
			{
				return false;
			}
			if (++num2 >= length)
			{
				return false;
			}
			c = string_0[num2];
			if (c < '0' || c > '9')
			{
				return false;
			}
		}
		int num4 = c - 48;
		while (++num2 < length)
		{
			c = string_0[num2];
			if (c >= '0' && c <= '9')
			{
				num4 = num4 * 10 + c - 48;
				continue;
			}
			return false;
		}
		if (flag)
		{
			double_0 *= ((num4 < 309) ? observerDispatcher[num4 + 308] : Math.Pow(10.0, -num4));
		}
		else
		{
			if (num4 > 308)
			{
				return false;
			}
			double_0 *= observerDispatcher[num4];
		}
		return !double.IsInfinity(double_0);
	}

	public static bool CheckForSpecialCaseDoubleStrings(string string_0, out double double_0)
	{
		if (string_0 == m_RegistryDispatcher)
		{
			double_0 = double.PositiveInfinity;
		}
		else if (string_0 == definitionDispatcher)
		{
			double_0 = double.NegativeInfinity;
		}
		else if (string_0 == _ValDispatcher)
		{
			double_0 = double.NaN;
		}
		else if (string_0 == m_WrapperDispatcher)
		{
			double_0 = 0.0;
		}
		else
		{
			if (!string_0.Equals("unlimited", StringComparison.OrdinalIgnoreCase))
			{
				double_0 = double.NaN;
				return false;
			}
			double_0 = double.MaxValue;
		}
		return true;
	}

	static FastDoubleParse()
	{
		_DispatcherDispatcher = CultureInfo.InvariantCulture.NumberFormat.NegativeSign[0];
		m_ListenerDispatcher = CultureInfo.InvariantCulture.NumberFormat.PositiveSign[0];
		m_ConfigDispatcher = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator[0];
		m_RegistryDispatcher = CultureInfo.InvariantCulture.NumberFormat.PositiveInfinitySymbol[0].ToString();
		definitionDispatcher = CultureInfo.InvariantCulture.NumberFormat.NegativeInfinitySymbol[0].ToString();
		_ValDispatcher = CultureInfo.InvariantCulture.NumberFormat.NaNSymbol[0].ToString();
		m_WrapperDispatcher = CultureInfo.InvariantCulture.NumberFormat.NegativeSign[0].ToString();
		observerDispatcher = (from i in Enumerable.Range(0, 309)
			select Math.Pow(10.0, i)).Concat(from i in Enumerable.Range(1, 308)
			select Math.Pow(10.0, -i)).ToArray();
		m_IssuerDispatcher = (from i in Enumerable.Range(0, 16)
			select Math.Pow(10.0, -i)).ToArray();
	}
}
