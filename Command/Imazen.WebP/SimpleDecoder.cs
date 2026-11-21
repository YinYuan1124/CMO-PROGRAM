using System;
using System.Drawing;
using System.Drawing.Imaging;
using Imazen.WebP.Extern;

namespace Imazen.WebP;

public sealed class SimpleDecoder
{
	public static string GetDecoderVersion()
	{
		int num = NativeMethods.WebPGetDecoderVersion();
		uint num2 = (uint)num % 256u;
		uint num3 = (uint)(num >>> 8) % 256u;
		uint num4 = (uint)(num >>> 16) % 256u;
		return num4 + "." + num3 + "." + num2;
	}

	public unsafe Bitmap DecodeFromBytes(byte[] byte_0, long long_0)
	{
		fixed (byte* ptr = byte_0)
		{
			return DecodeFromPointer((IntPtr)ptr, long_0);
		}
	}

	public Bitmap DecodeFromPointer(IntPtr intptr_0, long long_0)
	{
		int int_ = 0;
		int int_2 = 0;
		if (NativeMethods.WebPGetInfo(intptr_0, (UIntPtr)(ulong)long_0, ref int_, ref int_2) == 0)
		{
			throw new Exception("Invalid WebP header detected");
		}
		bool flag = false;
		Bitmap bitmap = null;
		BitmapData bitmapData = null;
		try
		{
			bitmap = new Bitmap(int_, int_2, PixelFormat.Format32bppArgb);
			bitmapData = bitmap.LockBits(new Rectangle(0, 0, int_, int_2), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			IntPtr intPtr = NativeMethods.WebPDecodeBGRAInto(intptr_0, (UIntPtr)(ulong)long_0, bitmapData.Scan0, (UIntPtr)(ulong)(bitmapData.Stride * bitmapData.Height), bitmapData.Stride);
			if (!(bitmapData.Scan0 == intPtr))
			{
				throw new Exception("Failed to decode WebP image with error " + (long)intPtr);
			}
			flag = true;
		}
		finally
		{
			if (bitmapData != null)
			{
				bitmap?.UnlockBits(bitmapData);
			}
			if (!flag)
			{
				bitmap?.Dispose();
			}
		}
		return bitmap;
	}
}
