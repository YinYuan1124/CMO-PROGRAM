using System;

namespace DotSpatial.Topology;

public struct FloatVector3
{
	public float X;

	public float Y;

	public float Z;

	public float Length => Convert.ToSingle(Math.Sqrt(X * X + Y * Y + Z * Z));

	public float LengthSq => Convert.ToSingle(X * X + Y * Y + Z * Z);

	public FloatVector3(CoordinateF coordinateF_0)
	{
		X = coordinateF_0.X;
		Y = coordinateF_0.Y;
		Z = coordinateF_0.Z;
	}

	public FloatVector3(float float_0, float float_1, float float_2)
	{
		X = float_0;
		Y = float_1;
		Z = float_2;
	}

	public FloatVector3(Coordinate coordinate_0)
	{
		X = Convert.ToSingle(coordinate_0.X);
		Y = Convert.ToSingle(coordinate_0.Y);
		Z = Convert.ToSingle(coordinate_0.Z);
	}

	public override bool Equals(object obj)
	{
		if (obj is FloatVector3 floatVector && floatVector.X == X && floatVector.Y == Y && floatVector.Z == Z)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static FloatVector3 Add(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		return new FloatVector3(floatVector3_0.X + floatVector3_1.X, floatVector3_0.Y + floatVector3_1.Y, floatVector3_0.Z + floatVector3_1.Z);
	}

	public void Add(FloatVector3 floatVector3_0)
	{
		X += floatVector3_0.X;
		Y += floatVector3_0.Y;
		Z += floatVector3_0.Z;
	}

	public static FloatVector3 Subtract(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		return new FloatVector3(floatVector3_0.X - floatVector3_1.X, floatVector3_0.Y - floatVector3_1.Y, floatVector3_0.Z - floatVector3_1.Z);
	}

	public void Subtract(FloatVector3 floatVector3_0)
	{
		X -= floatVector3_0.X;
		Y -= floatVector3_0.Y;
		Z -= floatVector3_0.Z;
	}

	public static FloatVector3 CrossProduct(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = floatVector3_0.Y * floatVector3_1.Z - floatVector3_0.Z * floatVector3_1.Y;
		result.Y = floatVector3_0.Z * floatVector3_1.X - floatVector3_0.X * floatVector3_1.Z;
		result.Z = floatVector3_0.X * floatVector3_1.Y - floatVector3_0.Y * floatVector3_1.X;
		return result;
	}

	public static float Dot(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		return floatVector3_0.X * floatVector3_1.X + floatVector3_0.Y * floatVector3_1.Y + floatVector3_0.Z * floatVector3_1.Z;
	}

	public static FloatVector3 Multiply(FloatVector3 floatVector3_0, float float_0)
	{
		return new FloatVector3(floatVector3_0.X * float_0, floatVector3_0.Y * float_0, floatVector3_0.Z * float_0);
	}

	public void Multiply(float float_0)
	{
		X *= float_0;
		Y *= float_0;
		Z *= float_0;
	}

	public void Normalize()
	{
		float length = Length;
		X /= length;
		Y /= length;
		Z /= length;
	}

	public static FloatVector3 operator +(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = floatVector3_0.X + floatVector3_1.X;
		result.Y = floatVector3_0.Y + floatVector3_1.Y;
		result.Z = floatVector3_0.Z + floatVector3_1.Z;
		return result;
	}

	public static bool operator ==(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		if (floatVector3_0.X == floatVector3_1.X && floatVector3_0.Y == floatVector3_1.Y && floatVector3_0.Z == floatVector3_1.Z)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		if (floatVector3_0.X == floatVector3_1.X && floatVector3_0.Y == floatVector3_1.Y && floatVector3_0.Z == floatVector3_1.Z)
		{
			return false;
		}
		return true;
	}

	public static FloatVector3 operator ^(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = floatVector3_0.Y * floatVector3_1.Z - floatVector3_0.Z * floatVector3_1.Y;
		result.Y = floatVector3_0.Z * floatVector3_1.X - floatVector3_0.X * floatVector3_1.Z;
		result.Z = floatVector3_0.X * floatVector3_1.Y - floatVector3_0.Y * floatVector3_1.X;
		return result;
	}

	public static FloatVector3 operator /(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		FloatVector3 result = default(FloatVector3);
		if (floatVector3_1.X > 0f)
		{
			result.X = floatVector3_0.X / floatVector3_1.X;
		}
		if (floatVector3_1.Y > 0f)
		{
			result.Y = floatVector3_0.Y / floatVector3_1.Y;
		}
		if (floatVector3_1.Z > 0f)
		{
			result.Z = floatVector3_0.Z / floatVector3_1.Z;
		}
		return result;
	}

	public static FloatVector3 operator /(FloatVector3 floatVector3_0, float float_0)
	{
		if (float_0 == 0f)
		{
			throw new ArgumentException("Divisor cannot be 0.");
		}
		FloatVector3 result = default(FloatVector3);
		result.X = floatVector3_0.X / float_0;
		result.Y = floatVector3_0.Y / float_0;
		result.Z = floatVector3_0.Z / float_0;
		return result;
	}

	public static float operator *(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		return floatVector3_0.X * floatVector3_1.X + floatVector3_0.Y * floatVector3_1.Y + floatVector3_0.Z * floatVector3_1.Z;
	}

	public static FloatVector3 operator *(float float_0, FloatVector3 floatVector3_0)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = float_0 * floatVector3_0.X;
		result.Y = float_0 * floatVector3_0.Y;
		result.Z = float_0 * floatVector3_0.Z;
		return result;
	}

	public static FloatVector3 operator *(FloatVector3 floatVector3_0, float float_0)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = floatVector3_0.X * float_0;
		result.Y = floatVector3_0.Y * float_0;
		result.Z = floatVector3_0.Z * float_0;
		return result;
	}

	public static FloatVector3 operator -(FloatVector3 floatVector3_0, FloatVector3 floatVector3_1)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = floatVector3_0.X - floatVector3_1.X;
		result.Y = floatVector3_0.Y - floatVector3_1.Y;
		result.Z = floatVector3_0.Z - floatVector3_1.Z;
		return result;
	}
}
