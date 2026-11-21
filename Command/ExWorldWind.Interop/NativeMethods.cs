using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace ExWorldWind.Interop;

public sealed class NativeMethods
{
	public struct Message
	{
		public IntPtr hWnd;

		public uint msg;

		public IntPtr wParam;

		public IntPtr lParam;

		public uint time;

		public Point p;
	}

	private NativeMethods()
	{
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool PeekMessage(out Message message_0, IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2);
}
