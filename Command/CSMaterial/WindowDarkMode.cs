using System;
using System.Runtime.InteropServices;

namespace CSMaterial;

public class WindowDarkMode
{
	[DllImport("dwmapi.dll")]
	private static extern int DwmSetWindowAttribute(IntPtr intptr_0, int int_0, ref int int_1, int int_2);

	public static bool UseImmersiveDarkMode(IntPtr intptr_0, bool bool_0)
	{
		if (OSVersionInfo.BuildVersion <= 17763)
		{
			return false;
		}
		int int_ = 19;
		if (OSVersionInfo.BuildVersion > 18985)
		{
			int_ = 20;
		}
		int int_2 = (bool_0 ? 1 : 0);
		return DwmSetWindowAttribute(intptr_0, int_, ref int_2, 4) == 0;
	}
}
