using System.Runtime.InteropServices;

namespace DiskQueue.Implementation.CrossPlatform.Unix;

public sealed class UnsafeNativeMethods
{
	[DllImport("libc", BestFitMapping = false, CharSet = CharSet.Ansi, EntryPoint = "chmod", SetLastError = true, ThrowOnUnmappableChar = true)]
	private static extern int chmod_1(string string_0, uint uint_0);

	public static int chmod(string string_0, UnixFilePermissions unixFilePermissions_0)
	{
		return chmod_1(string_0, (uint)unixFilePermissions_0);
	}
}
