using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public static class LoadLibrary
{
	private static object _StatusDecorator;

	private static Dictionary<string, IntPtr> _ProccesorDecorator;

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	private static extern IntPtr LoadLibraryEx(string string_0, IntPtr intptr_0, uint uint_0);

	public static bool EnsureLoadedByPath(string string_0, bool bool_0)
	{
		string_0 = Path.GetFullPath(string_0);
		lock (_StatusDecorator)
		{
			if (_ProccesorDecorator.TryGetValue(string_0, out var value))
			{
				return true;
			}
			value = LoadByPath(string_0, bool_0);
			if (value != IntPtr.Zero)
			{
				_ProccesorDecorator.Add(string_0, value);
				return true;
			}
		}
		return false;
	}

	public static IntPtr LoadByPath(string string_0, bool bool_0)
	{
		IntPtr intPtr = LoadLibraryEx(string_0, IntPtr.Zero, 2304u);
		if (intPtr == IntPtr.Zero && bool_0)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error());
		}
		return intPtr;
	}

	public static void LoadWebPOrFail()
	{
		if (!AutoLoadNearby("libwebp.dll", bool_0: true))
		{
			throw new FileNotFoundException("Failed to locate libwebp.dll");
		}
	}

	public static bool AutoLoadNearby(string string_0, bool bool_0)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		return AutoLoad(string_0, new string[2]
		{
			Path.GetDirectoryName(executingAssembly.Location),
			Path.GetDirectoryName(new Uri(executingAssembly.CodeBase).LocalPath)
		}, bool_0, bool_0);
	}

	public static bool AutoLoad(string string_0, string[] string_1, bool bool_0, bool bool_1)
	{
		string text = "";
		int num = 0;
		while (true)
		{
			if (num < string_1.Length)
			{
				string text2 = Path.Combine(Path.Combine(string_1[num], (IntPtr.Size == 8) ? "x64" : "x86"), string_0);
				if (string.IsNullOrEmpty(Path.GetExtension(text2)))
				{
					text2 += ".dll";
				}
				text = text + "\"" + text2 + "\", ";
				if (FileExistsNative.FileExistsFast(text2) && EnsureLoadedByPath(text2, bool_1))
				{
					break;
				}
				num++;
				continue;
			}
			if (bool_0)
			{
				throw new FileNotFoundException("Failed to locate '" + string_0 + "' as " + text.TrimEnd(' ', ','));
			}
			return false;
		}
		return true;
	}

	static LoadLibrary()
	{
		_StatusDecorator = new object();
		_ProccesorDecorator = new Dictionary<string, IntPtr>(StringComparer.OrdinalIgnoreCase);
	}
}
