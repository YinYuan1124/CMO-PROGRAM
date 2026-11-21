using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public static class FileExistsNative
{
	[ThreadStatic]
	private static StringBuilder m_Dic;

	private static Dictionary<string, bool> m_Consumer;

	[DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool PathFileExists(StringBuilder stringBuilder_0);

	public static bool FileExistsFast(string string_0)
	{
		if (m_Dic == null)
		{
			m_Dic = new StringBuilder();
		}
		else
		{
			m_Dic.Clear();
		}
		m_Dic.Append(string_0);
		return PathFileExists(m_Dic);
	}

	public static bool FileExistsFast_CheckOnlyOnce(string string_0)
	{
		if (m_Consumer.TryGetValue(string_0, out var value))
		{
			return value;
		}
		if (m_Dic == null)
		{
			m_Dic = new StringBuilder();
		}
		else
		{
			m_Dic.Clear();
		}
		m_Dic.Append(string_0);
		bool flag = PathFileExists(m_Dic);
		m_Consumer.Add(string_0, flag);
		return flag;
	}

	static FileExistsNative()
	{
		m_Consumer = new Dictionary<string, bool>();
	}
}
