using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSMaterial;

namespace Efundies;

public sealed class LockBitmap
{
	private readonly Bitmap policyProcess;

	private IntPtr _BroadcasterProcess = IntPtr.Zero;

	private BitmapData m_IdentifierProcess;

	[CompilerGenerated]
	private int algoProcess;

	public byte[] Pixels { get; set; }

	public int Depth { get; private set; }

	public int Width
	{
		[CompilerGenerated]
		get
		{
			return algoProcess;
		}
		[CompilerGenerated]
		private set
		{
			algoProcess = value;
		}
	}

	public int Height { get; private set; }

	public LockBitmap(Bitmap bitmap_0)
	{
		policyProcess = bitmap_0;
	}

	public void LockBits()
	{
		try
		{
			Width = policyProcess.Width;
			Height = policyProcess.Height;
			int num = Width * Height;
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			Depth = Image.GetPixelFormatSize(policyProcess.PixelFormat);
			if (Depth != 8 && Depth != 24 && Depth != 32)
			{
				throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
			}
			m_IdentifierProcess = policyProcess.LockBits(rect, ImageLockMode.ReadWrite, policyProcess.PixelFormat);
			int num2 = Depth / 8;
			Pixels = new byte[num * num2];
			_BroadcasterProcess = m_IdentifierProcess.Scan0;
			Marshal.Copy(_BroadcasterProcess, Pixels, 0, Pixels.Length);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void UnlockBits()
	{
		try
		{
			Marshal.Copy(Pixels, 0, _BroadcasterProcess, Pixels.Length);
			policyProcess.UnlockBits(m_IdentifierProcess);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public Color GetPixel(int int_0, int int_1, int int_2, byte[] byte_0)
	{
		Color result = Color.Empty;
		int num = int_2 / 8;
		int num2 = (int_1 * Width + int_0) * num;
		if (num2 <= byte_0.Length - num)
		{
			if (int_2 == 32)
			{
				byte blue = byte_0[num2];
				byte green = byte_0[num2 + 1];
				byte red = byte_0[num2 + 2];
				result = Color.FromArgb(byte_0[num2 + 3], red, green, blue);
			}
			if (int_2 == 24)
			{
				byte blue2 = byte_0[num2];
				byte green2 = byte_0[num2 + 1];
				result = Color.FromArgb(byte_0[num2 + 2], green2, blue2);
			}
			if (int_2 == 8)
			{
				byte b = byte_0[num2];
				result = Color.FromArgb(b, b, b);
			}
			return result;
		}
		throw new IndexOutOfRangeException();
	}

	public UnsafeColor GetPixel_UnsafeColor(int int_0, int int_1, int int_2, int int_3, byte[] byte_0)
	{
		int num = int_2 / 8;
		int num2 = (int_1 * int_3 + int_0) * num;
		if (num2 <= byte_0.Length - num)
		{
			switch (int_2)
			{
			default:
				return default(UnsafeColor);
			case 32:
			{
				byte byte_3 = byte_0[num2];
				byte byte_4 = byte_0[num2 + 1];
				byte byte_5 = byte_0[num2 + 2];
				return new UnsafeColor(byte_0[num2 + 3], byte_5, byte_4, byte_3);
			}
			case 24:
			{
				byte byte_ = byte_0[num2];
				byte byte_2 = byte_0[num2 + 1];
				return new UnsafeColor(byte_0[num2 + 2], byte_2, byte_);
			}
			case 8:
			{
				byte num3 = byte_0[num2];
				return new UnsafeColor(num3, num3, num3);
			}
			}
		}
		throw new IndexOutOfRangeException();
	}

	public void SetPixel(int int_0, int int_1, Color color_0)
	{
		int num = Depth / 8;
		int num2 = (int_1 * Width + int_0) * num;
		if (Depth == 32)
		{
			Pixels[num2] = color_0.B;
			Pixels[num2 + 1] = color_0.G;
			Pixels[num2 + 2] = color_0.R;
			Pixels[num2 + 3] = color_0.A;
		}
		if (Depth == 24)
		{
			Pixels[num2] = color_0.B;
			Pixels[num2 + 1] = color_0.G;
			Pixels[num2 + 2] = color_0.R;
		}
		if (Depth == 8)
		{
			Pixels[num2] = color_0.B;
		}
	}
}
