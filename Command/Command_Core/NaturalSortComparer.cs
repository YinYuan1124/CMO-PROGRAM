using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class NaturalSortComparer<T> : IComparer<string>
{
	private bool serializerConsumer;

	private Dictionary<string, string[]> m_RefConsumer;

	internal static object errorConsumer;

	public NaturalSortComparer(bool bool_0 = true)
	{
		m_RefConsumer = new Dictionary<string, string[]>();
		serializerConsumer = bool_0;
	}

	internal int CallStub(string string_0, string string_1)
	{
		throw new NotImplementedException();
	}

	private int LogoutStub(string string_0, string string_1)
	{
		if (Operators.CompareString(string_0, string_1, TextCompare: false) == 0)
		{
			return 0;
		}
		if (string.IsNullOrEmpty(string_0))
		{
			return 1;
		}
		if (string.IsNullOrEmpty(string_1))
		{
			return -1;
		}
		if (!m_RefConsumer.TryGetValue(string_0, out var value))
		{
			value = Regex.Split(string_0.Replace(" ", ""), "([0-9]+)");
			m_RefConsumer.Add(string_0, value);
		}
		if (!m_RefConsumer.TryGetValue(string_1, out var value2))
		{
			value2 = Regex.Split(string_1.Replace(" ", ""), "([0-9]+)");
			m_RefConsumer.Add(string_1, value2);
		}
		int num;
		for (int i = 0; i < value.Length && i < value2.Length; i++)
		{
			if (Operators.CompareString(value[i], value2[i], TextCompare: false) != 0)
			{
				num = ViewStub(value[i], value2[i]);
				if (!serializerConsumer)
				{
					return -num;
				}
				return num;
			}
		}
		num = ((value2.Length > value.Length) ? 1 : ((value.Length > value2.Length) ? (-1) : 0));
		if (!serializerConsumer)
		{
			return -num;
		}
		return num;
	}

	int IComparer<string>.Compare(string x, string y)
	{
		return LogoutStub(x, y);
	}

	private static int ViewStub(string string_0, string string_1)
	{
		if (int.TryParse(string_0, out var result))
		{
			if (int.TryParse(string_1, out var result2))
			{
				return result.CompareTo(result2);
			}
			return string_0.CompareTo(string_1);
		}
		return string_0.CompareTo(string_1);
	}

	public void Dispose()
	{
		m_RefConsumer.Clear();
		m_RefConsumer = null;
	}

	internal static bool ValidateStub()
	{
		return errorConsumer == null;
	}
}
