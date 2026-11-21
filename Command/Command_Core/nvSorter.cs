using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Command_Core;

public sealed class nvSorter : IComparer<string>
{
	[DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
	public static extern int StrCmpLogicalW([MarshalAs(UnmanagedType.VBByRefStr)] ref string string_0, [MarshalAs(UnmanagedType.VBByRefStr)] ref string string_1);

	internal int ExcludeStub(string string_0, string string_1)
	{
		return StrCmpLogicalW(ref string_0, ref string_1);
	}

	int IComparer<string>.Compare(string x, string y)
	{
		return ExcludeStub(x, y);
	}
}
