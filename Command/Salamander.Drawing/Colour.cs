using System;
using System.Drawing;

namespace Salamander.Drawing;

public sealed class Colour
{
	public const int HUEMAX = 360;

	public const float SATMAX = 1f;

	public const float BRIGHTMAX = 1f;

	public const int RGBMAX = 255;

	private Color codeCallback = Color.Red;

	public Color CurrentColour
	{
		get
		{
			return codeCallback;
		}
		set
		{
			codeCallback = value;
		}
	}

	public byte Red
	{
		get
		{
			return codeCallback.R;
		}
		set
		{
			codeCallback = Color.FromArgb(value, Green, Blue);
		}
	}

	public byte Green
	{
		get
		{
			return codeCallback.G;
		}
		set
		{
			codeCallback = Color.FromArgb(Red, value, Blue);
		}
	}

	public byte Blue
	{
		get
		{
			return codeCallback.B;
		}
		set
		{
			codeCallback = Color.FromArgb(Red, Green, value);
		}
	}

	public int Hue
	{
		get
		{
			return (int)codeCallback.GetHue();
		}
		set
		{
			codeCallback = HSBToRGB(value, codeCallback.GetSaturation(), codeCallback.GetBrightness());
		}
	}

	public float Saturation
	{
		get
		{
			if (0f == Brightness)
			{
				return 0f;
			}
			float num = (int)Math.Max(Red, Math.Max(Green, Blue));
			float num2 = (int)Math.Min(Red, Math.Min(Green, Blue));
			return (num - num2) / num;
		}
		set
		{
			codeCallback = HSBToRGB((int)codeCallback.GetHue(), value, codeCallback.GetBrightness());
		}
	}

	public float Brightness
	{
		get
		{
			return (float)(int)Math.Max(Red, Math.Max(Green, Blue)) / 255f;
		}
		set
		{
			codeCallback = HSBToRGB((int)codeCallback.GetHue(), codeCallback.GetSaturation(), value);
		}
	}

	public float GetHue()
	{
		float num = (float)(2 * Red - Green - Blue) / 510f;
		float num2 = (float)Math.Sqrt(((Red - Green) * (Red - Green) + (Red - Blue) * (Green - Blue)) / 255);
		return (float)Math.Acos(num / num2);
	}

	public float GetSaturation()
	{
		return (255f - (float)(Red + Green + Blue) / 3f * (float)(int)Math.Min(Red, Math.Min(Green, Blue))) / 255f;
	}

	public float GetBrightness()
	{
		return (float)(Red + Green + Blue) / 765f;
	}

	public static Color HSBToRGB(int int_0, float float_0, float float_1)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (float_0 == 0f)
		{
			num = (num2 = (num3 = (int)(float_1 * 255f)));
		}
		else
		{
			float num4 = 1f / 60f * (float)int_0;
			float num5 = (float)Math.Floor(num4);
			float num6 = num4 - num5;
			float num7 = float_1 * 255f;
			byte b = (byte)(0.5f + num7 * (1f - float_0));
			byte b2 = (byte)(0.5f + num7 * (1f - float_0 * num6));
			byte b3 = (byte)(0.5f + num7 * (1f - float_0 * (1f - num6)));
			switch ((int)num5)
			{
			default:
				num = 0;
				num2 = 0;
				num3 = 0;
				break;
			case 0:
				num = (int)(float_1 * 255f);
				num2 = b3;
				num3 = b;
				break;
			case 1:
				num = b2;
				num2 = (int)(float_1 * 255f);
				num3 = b;
				break;
			case 2:
				num = b;
				num2 = (int)(float_1 * 255f);
				num3 = b3;
				break;
			case 3:
				num = b;
				num2 = b2;
				num3 = (int)(float_1 * 255f);
				break;
			case 4:
				num = b3;
				num2 = b;
				num3 = (int)(float_1 * 255f);
				break;
			case 5:
				num = (int)(float_1 * 255f);
				num2 = b;
				num3 = b2;
				break;
			}
		}
		return Color.FromArgb(num, num2, num3);
	}
}
