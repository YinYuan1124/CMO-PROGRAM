using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class Vector
{
	[CompilerGenerated]
	private double exporterMerchant;

	[CompilerGenerated]
	private double m_PrototypeMerchant;

	[CompilerGenerated]
	private double m_ComparatorMerchant;

	[CompilerGenerated]
	private double m_ItemMerchant;

	public double X
	{
		[CompilerGenerated]
		get
		{
			return exporterMerchant;
		}
		[CompilerGenerated]
		set
		{
			exporterMerchant = value;
		}
	}

	public double Y
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeMerchant;
		}
		[CompilerGenerated]
		set
		{
			m_PrototypeMerchant = value;
		}
	}

	public double Z
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorMerchant;
		}
		[CompilerGenerated]
		set
		{
			m_ComparatorMerchant = value;
		}
	}

	public double W
	{
		[CompilerGenerated]
		get
		{
			return m_ItemMerchant;
		}
		[CompilerGenerated]
		set
		{
			m_ItemMerchant = value;
		}
	}

	public Vector()
	{
	}

	public Vector(Vector vector_0)
		: this(vector_0.X, vector_0.Y, vector_0.Z, vector_0.W)
	{
	}

	public Vector(double double_0, double double_1, double double_2)
	{
		X = double_0;
		Y = double_1;
		Z = double_2;
	}

	public Vector(double double_0, double double_1, double double_2, double double_3)
	{
		X = double_0;
		Y = double_1;
		Z = double_2;
		W = double_3;
	}

	public void Scale(double double_0)
	{
		X *= double_0;
		Y *= double_0;
		Z *= double_0;
		W *= Math.Abs(double_0);
	}

	public void Sub(Vector vector_0)
	{
		X -= vector_0.X;
		Y -= vector_0.Y;
		Z -= vector_0.Z;
		W -= vector_0.W;
	}

	public double Angle(Vector vector_0)
	{
		double num = Dot(vector_0) / (Magnitude() * vector_0.Magnitude());
		if (num > 0.0)
		{
			num = Math.Min(num, 1.0);
		}
		if (num < 0.0)
		{
			num = Math.Max(num, -1.0);
		}
		return Math.Acos(num);
	}

	public double Magnitude()
	{
		return Math.Sqrt(X * X + Y * Y + Z * Z);
	}

	public double Dot(Vector vector_0)
	{
		return X * vector_0.X + Y * vector_0.Y + Z * vector_0.Z;
	}

	public double Distance(Vector vector_0)
	{
		return Math.Sqrt(Math.Pow(X - vector_0.X, 2.0) + Math.Pow(Y - vector_0.Y, 2.0) + Math.Pow(Z - vector_0.Z, 2.0));
	}

	public void RotateX(double double_0)
	{
		double y = Y;
		Y = Math.Cos(double_0) * y - Math.Sin(double_0) * Z;
		Z = Math.Sin(double_0) * y + Math.Cos(double_0) * Z;
	}

	public void RotateY(double double_0)
	{
		double x = X;
		X = Math.Cos(double_0) * x + Math.Sin(double_0) * Z;
		Z = (0.0 - Math.Sin(double_0)) * x + Math.Cos(double_0) * Z;
	}

	public void RotateZ(double double_0)
	{
		double x = X;
		X = Math.Cos(double_0) * x - Math.Sin(double_0) * Y;
		Y = Math.Sin(double_0) * x + Math.Cos(double_0) * Y;
	}

	public void Translate(double double_0, double double_1, double double_2)
	{
		X += double_0;
		Y += double_1;
		Z += double_2;
	}
}
