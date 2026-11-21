using System;
using System.Text;

namespace OpenDis.Common;

internal class ConnectionCallback
{
	private static readonly char[] m_ContextCallback;

	public static long CustomizeDecorator(string string_0)
	{
		long num = 0L;
		double num2 = 0.0;
		int num3 = string_0.Length - 1;
		while (true)
		{
			if (num3 >= 0)
			{
				char value = string_0[num3];
				int num4 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(value);
				if (num4 <= -1)
				{
					break;
				}
				num += num4 * (long)Math.Pow("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length, num2);
				num2 += 1.0;
				num3--;
				continue;
			}
			return num;
		}
		return -1L;
	}

	public static string CloneDecorator(ulong ulong_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		do
		{
			stringBuilder.Append(m_ContextCallback[ulong_0 % (ulong)"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length]);
			ulong_0 /= (ulong)"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length;
		}
		while (ulong_0 != 0);
		return ConnectDecorator(stringBuilder.ToString());
	}

	private static string ConnectDecorator(string string_0)
	{
		char[] array = string_0.ToCharArray();
		Array.Reverse(array);
		return new string(array);
	}

	static ConnectionCallback()
	{
		m_ContextCallback = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
	}
}
