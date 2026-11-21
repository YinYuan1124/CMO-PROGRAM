using System;

namespace ExWorldWind;

public struct Quaternion4d
{
	public double X;

	public double Y;

	public double Z;

	public double W;

	public Quaternion4d(double double_0, double double_1, double double_2, double double_3)
	{
		X = double_0;
		Y = double_1;
		Z = double_2;
		W = double_3;
	}

	public override int GetHashCode()
	{
		return (int)(X / Y / Z / W);
	}

	public override bool Equals(object obj)
	{
		if (obj is Quaternion4d)
		{
			return (Quaternion4d)obj == this;
		}
		return false;
	}

	public static Quaternion4d EulerToQuaternion(double double_0, double double_1, double double_2)
	{
		double num = Math.Cos(double_0 * 0.5);
		double num2 = Math.Cos(double_1 * 0.5);
		double num3 = Math.Cos(double_2 * 0.5);
		double num4 = Math.Sin(double_0 * 0.5);
		double num5 = Math.Sin(double_1 * 0.5);
		double num6 = Math.Sin(double_2 * 0.5);
		double double_3 = num * num2 * num3 + num4 * num5 * num6;
		double double_4 = num4 * num2 * num3 - num * num5 * num6;
		double double_5 = num * num5 * num3 + num4 * num2 * num6;
		double double_6 = num * num2 * num6 - num4 * num5 * num3;
		return new Quaternion4d(double_4, double_5, double_6, double_3);
	}

	public static Point3d QuaternionToEuler(Quaternion4d quaternion4d_0)
	{
		double w = quaternion4d_0.W;
		double x = quaternion4d_0.X;
		double y = quaternion4d_0.Y;
		double z = quaternion4d_0.Z;
		double double_ = Math.Atan2(2.0 * (y * z + w * x), w * w - x * x - y * y + z * z);
		double double_2 = Math.Asin(-2.0 * (x * z - w * y));
		double double_3 = Math.Atan2(2.0 * (x * y + w * z), w * w + x * x - y * y - z * z);
		return new Point3d(double_, double_2, double_3);
	}

	public static Quaternion4d operator +(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1)
	{
		return new Quaternion4d(quaternion4d_0.X + quaternion4d_1.X, quaternion4d_0.Y + quaternion4d_1.Y, quaternion4d_0.Z + quaternion4d_1.Z, quaternion4d_0.W + quaternion4d_1.W);
	}

	public static Quaternion4d operator -(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1)
	{
		return new Quaternion4d(quaternion4d_0.X - quaternion4d_1.X, quaternion4d_0.Y - quaternion4d_1.Y, quaternion4d_0.Z - quaternion4d_1.Z, quaternion4d_0.W - quaternion4d_1.W);
	}

	public static Quaternion4d operator *(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1)
	{
		return new Quaternion4d(quaternion4d_0.W * quaternion4d_1.X + quaternion4d_0.X * quaternion4d_1.W + quaternion4d_0.Y * quaternion4d_1.Z - quaternion4d_0.Z * quaternion4d_1.Y, quaternion4d_0.W * quaternion4d_1.Y + quaternion4d_0.Y * quaternion4d_1.W + quaternion4d_0.Z * quaternion4d_1.X - quaternion4d_0.X * quaternion4d_1.Z, quaternion4d_0.W * quaternion4d_1.Z + quaternion4d_0.Z * quaternion4d_1.W + quaternion4d_0.X * quaternion4d_1.Y - quaternion4d_0.Y * quaternion4d_1.X, quaternion4d_0.W * quaternion4d_1.W - quaternion4d_0.X * quaternion4d_1.X - quaternion4d_0.Y * quaternion4d_1.Y - quaternion4d_0.Z * quaternion4d_1.Z);
	}

	public static Quaternion4d operator *(double double_0, Quaternion4d quaternion4d_0)
	{
		return new Quaternion4d(double_0 * quaternion4d_0.X, double_0 * quaternion4d_0.Y, double_0 * quaternion4d_0.Z, double_0 * quaternion4d_0.W);
	}

	public static Quaternion4d operator *(Quaternion4d quaternion4d_0, double double_0)
	{
		return new Quaternion4d(double_0 * quaternion4d_0.X, double_0 * quaternion4d_0.Y, double_0 * quaternion4d_0.Z, double_0 * quaternion4d_0.W);
	}

	public static Quaternion4d operator *(Point3d point3d_0, Quaternion4d quaternion4d_0)
	{
		return new Quaternion4d(point3d_0.X * quaternion4d_0.W + point3d_0.Y * quaternion4d_0.Z - point3d_0.Z * quaternion4d_0.Y, point3d_0.Y * quaternion4d_0.W + point3d_0.Z * quaternion4d_0.X - point3d_0.X * quaternion4d_0.Z, point3d_0.Z * quaternion4d_0.W + point3d_0.X * quaternion4d_0.Y - point3d_0.Y * quaternion4d_0.X, (0.0 - point3d_0.X) * quaternion4d_0.X - point3d_0.Y * quaternion4d_0.Y - point3d_0.Z * quaternion4d_0.Z);
	}

	public static Quaternion4d operator /(Quaternion4d quaternion4d_0, double double_0)
	{
		return quaternion4d_0 * (1.0 / double_0);
	}

	public Quaternion4d Conjugate()
	{
		return new Quaternion4d(0.0 - X, 0.0 - Y, 0.0 - Z, W);
	}

	public static double Norm2(Quaternion4d quaternion4d_0)
	{
		return quaternion4d_0.X * quaternion4d_0.X + quaternion4d_0.Y * quaternion4d_0.Y + quaternion4d_0.Z * quaternion4d_0.Z + quaternion4d_0.W * quaternion4d_0.W;
	}

	public static double Abs(Quaternion4d quaternion4d_0)
	{
		return Math.Sqrt(Norm2(quaternion4d_0));
	}

	public static Quaternion4d operator /(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1)
	{
		return quaternion4d_0 * (quaternion4d_1.Conjugate() / Abs(quaternion4d_1));
	}

	public static bool operator ==(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1)
	{
		if (quaternion4d_0.X == quaternion4d_1.X && quaternion4d_0.Y == quaternion4d_1.Y && quaternion4d_0.Z == quaternion4d_1.Z)
		{
			return quaternion4d_0.W == quaternion4d_1.W;
		}
		return false;
	}

	public static bool operator !=(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1)
	{
		if (quaternion4d_0.X == quaternion4d_1.X && quaternion4d_0.Y == quaternion4d_1.Y && quaternion4d_0.Z == quaternion4d_1.Z)
		{
			return quaternion4d_0.W != quaternion4d_1.W;
		}
		return true;
	}

	public static double Dot(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1)
	{
		return quaternion4d_0.X * quaternion4d_1.X + quaternion4d_0.Y * quaternion4d_1.Y + quaternion4d_0.Z * quaternion4d_1.Z + quaternion4d_0.W * quaternion4d_1.W;
	}

	public void Normalize()
	{
		double num = Length();
		X /= num;
		Y /= num;
		Z /= num;
		W /= num;
	}

	public double Length()
	{
		return Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
	}

	public static Quaternion4d Slerp(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1, double double_0)
	{
		double num = quaternion4d_0.X * quaternion4d_1.X + quaternion4d_0.Y * quaternion4d_1.Y + quaternion4d_0.Z * quaternion4d_1.Z + quaternion4d_0.W * quaternion4d_1.W;
		double num2;
		double num3;
		double num4;
		double num5;
		if (num < 0.0)
		{
			num = 0.0 - num;
			num2 = 0.0 - quaternion4d_1.X;
			num3 = 0.0 - quaternion4d_1.Y;
			num4 = 0.0 - quaternion4d_1.Z;
			num5 = 0.0 - quaternion4d_1.W;
		}
		else
		{
			num2 = quaternion4d_1.X;
			num3 = quaternion4d_1.Y;
			num4 = quaternion4d_1.Z;
			num5 = quaternion4d_1.W;
		}
		double num6;
		double num7;
		if (1.0 - num <= double.Epsilon)
		{
			num6 = 1.0 - double_0;
			num7 = double_0;
		}
		else
		{
			double num8 = Math.Acos(num);
			double num9 = Math.Sin(num8);
			num6 = Math.Sin((1.0 - double_0) * num8) / num9;
			num7 = Math.Sin(double_0 * num8) / num9;
		}
		Quaternion4d result = default(Quaternion4d);
		result.X = num6 * quaternion4d_0.X + num7 * num2;
		result.Y = num6 * quaternion4d_0.Y + num7 * num3;
		result.Z = num6 * quaternion4d_0.Z + num7 * num4;
		result.W = num6 * quaternion4d_0.W + num7 * num5;
		return result;
	}

	public Quaternion4d Ln()
	{
		return Ln(this);
	}

	public static Quaternion4d Ln(Quaternion4d quaternion4d_0)
	{
		double num = 0.0;
		double num2 = Math.Sqrt(quaternion4d_0.X * quaternion4d_0.X + quaternion4d_0.Y * quaternion4d_0.Y + quaternion4d_0.Z * quaternion4d_0.Z);
		double num3 = Math.Atan2(num2, quaternion4d_0.W);
		num = ((Math.Abs(num2) < double.Epsilon) ? 0.0 : (num3 / num2));
		quaternion4d_0.X *= num;
		quaternion4d_0.Y *= num;
		quaternion4d_0.Z *= num;
		quaternion4d_0.W = 0.0;
		return quaternion4d_0;
	}

	public static Quaternion4d Exp(Quaternion4d quaternion4d_0)
	{
		double num = Math.Sqrt(quaternion4d_0.X * quaternion4d_0.X + quaternion4d_0.Y * quaternion4d_0.Y + quaternion4d_0.Z * quaternion4d_0.Z);
		double num2 = ((Math.Abs(num) < double.Epsilon) ? 1.0 : (Math.Sin(num) / num));
		quaternion4d_0.X *= num2;
		quaternion4d_0.Y *= num2;
		quaternion4d_0.Z *= num2;
		quaternion4d_0.W = Math.Cos(num);
		return quaternion4d_0;
	}

	public Quaternion4d Exp()
	{
		return Ln(this);
	}

	public static Quaternion4d Squad(Quaternion4d quaternion4d_0, Quaternion4d quaternion4d_1, Quaternion4d quaternion4d_2, Quaternion4d quaternion4d_3, double double_0)
	{
		return Slerp(Slerp(quaternion4d_0, quaternion4d_3, double_0), Slerp(quaternion4d_1, quaternion4d_2, double_0), 2.0 * double_0 * (1.0 - double_0));
	}

	public static void SquadSetup(ref Quaternion4d quaternion4d_0, ref Quaternion4d quaternion4d_1, ref Quaternion4d quaternion4d_2, Quaternion4d quaternion4d_3, Quaternion4d quaternion4d_4, Quaternion4d quaternion4d_5, Quaternion4d quaternion4d_6)
	{
		quaternion4d_3 += quaternion4d_4;
		quaternion4d_3.Normalize();
		quaternion4d_5 += quaternion4d_4;
		quaternion4d_5.Normalize();
		quaternion4d_6 += quaternion4d_4;
		quaternion4d_6.Normalize();
		quaternion4d_4.Normalize();
		quaternion4d_0 = quaternion4d_4 * Exp(-0.25 * (Ln(Exp(quaternion4d_4) * quaternion4d_5) + Ln(Exp(quaternion4d_4) * quaternion4d_3)));
		quaternion4d_1 = quaternion4d_5 * Exp(-0.25 * (Ln(Exp(quaternion4d_5) * quaternion4d_6) + Ln(Exp(quaternion4d_5) * quaternion4d_4)));
		quaternion4d_2 = quaternion4d_5;
	}
}
