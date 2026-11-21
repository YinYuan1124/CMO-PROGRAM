using System.Drawing;

namespace CSMaterial;

public struct UnsafeColor
{
	public byte A;

	public byte R;

	public byte G;

	public byte B;

	public UnsafeColor(Color color_0)
	{
		A = color_0.A;
		R = color_0.R;
		G = color_0.G;
		B = color_0.B;
	}

	public UnsafeColor(byte byte_0, byte byte_1, byte byte_2, byte byte_3)
	{
		A = byte_0;
		R = byte_1;
		G = byte_2;
		B = byte_3;
	}

	public UnsafeColor(byte byte_0, byte byte_1, byte byte_2)
	{
		A = byte.MaxValue;
		R = byte_0;
		G = byte_1;
		B = byte_2;
	}
}
