using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Imazen.WebP.Extern;

namespace Imazen.WebP;

public sealed class SimpleEncoder
{
	public static string GetEncoderVersion()
	{
		int num = NativeMethods.WebPGetEncoderVersion();
		uint num2 = (uint)num % 256u;
		uint num3 = (uint)(num >>> 8) % 256u;
		uint num4 = (uint)(num >>> 16) % 256u;
		return num4 + "." + num3 + "." + num2;
	}

	[Obsolete]
	public void Encode(Bitmap bitmap_0, Stream stream_0, float float_0, bool bool_0)
	{
		Encode(bitmap_0, stream_0, float_0);
	}

	public void Encode(Bitmap bitmap_0, Stream stream_0, float float_0)
	{
		Encode(bitmap_0, float_0, out var intptr_, out var long_);
		try
		{
			byte[] array = new byte[4096];
			for (int i = 0; i < long_; i += array.Length)
			{
				int num = (int)Math.Min(array.Length, long_ - i);
				Marshal.Copy((IntPtr)((long)intptr_ + i), array, 0, num);
				stream_0.Write(array, 0, num);
			}
		}
		finally
		{
			NativeMethods.WebPSafeFree(intptr_);
		}
	}

	[Obsolete]
	public void Encode(Bitmap bitmap_0, float float_0, bool bool_0, out IntPtr intptr_0, out long long_0)
	{
		Encode(bitmap_0, float_0, out intptr_0, out long_0);
	}

	public void Encode(Bitmap bitmap_0, float float_0, out IntPtr intptr_0, out long long_0)
	{
		if (float_0 < -1f)
		{
			float_0 = -1f;
		}
		if (float_0 > 100f)
		{
			float_0 = 100f;
		}
		int width = bitmap_0.Width;
		int height = bitmap_0.Height;
		BitmapData bitmapData = bitmap_0.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bitmap_0.PixelFormat);
		try
		{
			intptr_0 = IntPtr.Zero;
			if (bitmap_0.PixelFormat == PixelFormat.Format32bppArgb)
			{
				if (float_0 == -1f)
				{
					long_0 = (long)(ulong)NativeMethods.WebPEncodeLosslessBGRA(bitmapData.Scan0, width, height, bitmapData.Stride, ref intptr_0);
				}
				else
				{
					long_0 = (long)NativeMethods.WebPEncodeBGRA(bitmapData.Scan0, width, height, bitmapData.Stride, float_0, ref intptr_0);
				}
			}
			else if (bitmap_0.PixelFormat == PixelFormat.Format24bppRgb)
			{
				if (float_0 == -1f)
				{
					long_0 = (long)(ulong)NativeMethods.WebPEncodeLosslessBGR(bitmapData.Scan0, width, height, bitmapData.Stride, ref intptr_0);
				}
				else
				{
					long_0 = (long)(ulong)NativeMethods.WebPEncodeBGR(bitmapData.Scan0, width, height, bitmapData.Stride, float_0, ref intptr_0);
				}
			}
			else
			{
				using Bitmap bitmap_ = bitmap_0.Clone(new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), PixelFormat.Format32bppArgb);
				Encode(bitmap_, float_0, out intptr_0, out long_0);
			}
			if (long_0 == 0)
			{
				throw new Exception("WebP encode failed!");
			}
		}
		finally
		{
			bitmap_0.UnlockBits(bitmapData);
		}
	}
}
