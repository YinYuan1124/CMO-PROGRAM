using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy.Common;

public static class Base36
{
	public static string Encode(long long_0)
	{
		if (long_0 < 0)
		{
			throw new Exception("Input cannot be negative.");
		}
		char[] array = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
		Stack<char> stack = new Stack<char>();
		while (long_0 != 0)
		{
			stack.Push(array[long_0 % 36]);
			long_0 /= 36;
		}
		return new string(stack.ToArray());
	}

	public static long Decode(string string_0)
	{
		if (string_0 == null)
		{
			throw new Exception("Input cannot be null.");
		}
		IEnumerable<char> enumerable = string_0.ToLower().Reverse();
		long num = 0L;
		int num2 = 0;
		foreach (char item in enumerable)
		{
			num += "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(item) * (long)Math.Pow(36.0, num2);
			num2++;
		}
		return num;
	}
}
