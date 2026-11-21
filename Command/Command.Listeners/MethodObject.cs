using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Command.Listeners;

internal sealed class MethodObject
{
	[DllImport("user32.dll")]
	internal static extern IntPtr WindowFromPoint(Point point_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr SendMessage(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, IntPtr intptr_2);
}
