using System.Numerics;

namespace ExWorldWind;

public class CustomVertex
{
	public struct PositionColored
	{
		public float X;

		public float Y;

		public float Z;

		public int Color;

		public PositionColored(float float_0, float float_1, float float_2, int int_0)
		{
			X = float_0;
			Y = float_1;
			Z = float_2;
			Color = int_0;
		}

		public PositionColored(Vector3 vector3_0, int int_0)
		{
			X = vector3_0.X;
			Y = vector3_0.Y;
			Z = vector3_0.Z;
			Color = int_0;
		}
	}

	public struct PositionTextured
	{
		public float X;

		public float Y;

		public float Z;

		public float Tu;

		public float Tv;

		public PositionTextured(Vector3 vector3_0, float float_0, float float_1)
		{
			X = vector3_0.X;
			Y = vector3_0.Y;
			Z = vector3_0.Z;
			Tu = float_0;
			Tv = float_1;
		}
	}
}
