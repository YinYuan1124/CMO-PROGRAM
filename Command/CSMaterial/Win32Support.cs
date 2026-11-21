using System;
using System.Runtime.InteropServices;

namespace CSMaterial;

public sealed class Win32Support
{
	public enum Bool
	{
		False,
		True
	}

	public enum TernaryRasterOperations
	{
		SRCCOPY = 13369376,
		SRCPAINT = 15597702,
		SRCAND = 8913094,
		SRCINVERT = 6684742,
		SRCERASE = 4457256,
		NOTSRCCOPY = 3342344,
		NOTSRCERASE = 1114278,
		MERGECOPY = 12583114,
		MERGEPAINT = 12255782,
		PATCOPY = 15728673,
		PATPAINT = 16452105,
		PATINVERT = 5898313,
		DSTINVERT = 5570569,
		BLACKNESS = 66,
		WHITENESS = 16711778
	}

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern Bool DeleteDC(IntPtr intptr_0);

	[DllImport("GDI32.DLL", ExactSpelling = true)]
	public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern Bool DeleteObject(IntPtr intptr_0);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_0, int int_0, int int_1);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern Bool BitBlt(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, TernaryRasterOperations ternaryRasterOperations_0);

	[DllImport("GDI32.DLL")]
	public static extern Bool GdiAlphaBlend(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, int int_6, int int_7, BLENDFUNCTION blendfunction_0);
}
