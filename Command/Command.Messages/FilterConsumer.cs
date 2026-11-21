using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Command.Messages;

internal class FilterConsumer
{
	internal const int testsConsumer = 997;

	internal const int _InterpreterConsumer = 535;

	internal const int _ContainerConsumer = 1073741824;

	internal const int m_ComposerConsumer = 65535;

	internal const int m_ModelConsumer = 0;

	internal const int advisorConsumer = 255;

	internal const int customerConsumer = 0;

	[DllImport("kernel32.dll")]
	public static extern bool GetOverlappedResult(IntPtr intptr_0, [In] ref NativeOverlapped nativeOverlapped_0, out uint uint_0, bool bool_0);

	[DllImport("kernel32.dll")]
	internal static extern uint WaitForMultipleObjects(uint uint_0, IntPtr[] intptr_0, bool bool_0, uint uint_1);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern int ConnectNamedPipe(IntPtr intptr_0, [In] ref NativeOverlapped nativeOverlapped_0);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern IntPtr CreateFile(string string_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern IntPtr CreateNamedPipe(string string_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, IntPtr intptr_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool DisconnectNamedPipe(IntPtr intptr_0);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern int WaitNamedPipe(string string_0, ushort ushort_0);
}
