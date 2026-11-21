using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using CSMaterial;

namespace Sharp3D.Math.Core;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class Transform2D : ICloneable
{
	private Matrix3D matrix3D_0 = Matrix3D.Identity;

	public static readonly Transform2D Identity;

	public static readonly Transform2D ReflectionX;

	public static readonly Transform2D ReflectionY;

	private static readonly double double_0;

	public Matrix3D Matrix
	{
		get
		{
			return matrix3D_0;
		}
		set
		{
			matrix3D_0 = value;
		}
	}

	public bool HasReflection => matrix3D_0.M11 * matrix3D_0.M22 * matrix3D_0.M33 < 0.0;

	public Vector2D TranslationVector => new Vector2D(matrix3D_0.M13, matrix3D_0.M23);

	public double RotationAngle
	{
		get
		{
			double num = System.Math.Acos(matrix3D_0.M11) * 180.0 / double_0;
			if (System.Math.Sin(num) * matrix3D_0.M21 < 0.0)
			{
				num = 360.0 - num;
			}
			return num;
		}
	}

	public Transform2D()
	{
	}

	public Transform2D(Matrix3D matrix3D_1)
	{
		matrix3D_0 = matrix3D_1.Clone();
	}

	public Transform2D(Transform2D transform2D_0)
	{
		matrix3D_0 = transform2D_0.matrix3D_0.Clone();
	}

	public Vector2D transform(Vector2D vector2D_0)
	{
		Vector3D vector3D = matrix3D_0 * new Vector3D(vector2D_0.X, vector2D_0.Y, 1.0);
		return new Vector2D(vector3D.X, vector3D.Y);
	}

	public double transform(double double_1)
	{
		if (matrix3D_0.M21 <= 0.0)
		{
			if (matrix3D_0.M11 <= 0.0)
			{
				return double_1 + 180.0 - System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
			}
			return double_1 + System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
		}
		if (matrix3D_0.M11 <= 0.0)
		{
			return double_1 + 180.0 - System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
		}
		return double_1 + System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
	}

	public Transform2D Inverse()
	{
		return new Transform2D(Matrix3D.Inverse(matrix3D_0));
	}

	object ICloneable.Clone()
	{
		return new Transform2D(this);
	}

	public Transform2D Clone()
	{
		return new Transform2D(this);
	}

	public static Transform2D Translation(Vector2D vector2D_0)
	{
		Matrix3D identity = Matrix3D.Identity;
		identity.M13 = vector2D_0.X;
		identity.M23 = vector2D_0.Y;
		return new Transform2D(identity);
	}

	public static Transform2D Rotation(double double_1)
	{
		double num = double_1 * CSMath.PI_dividedBy_180;
		double double_2 = System.Math.Cos(num);
		double num2 = System.Math.Sin(num);
		return new Transform2D(new Matrix3D(new Vector3D(double_2, num2, 0.0), new Vector3D(0.0 - num2, double_2, 0.0), Vector3D.ZAxis));
	}

	public static Transform2D Rotation(Vector2D vector2D_0, double double_1)
	{
		double num = double_1 * CSMath.PI_dividedBy_180;
		double double_2 = System.Math.Cos(num);
		double num2 = System.Math.Sin(num);
		return new Transform2D(new Matrix3D(Vector3D.Zero, Vector3D.Zero, new Vector3D(vector2D_0.X, vector2D_0.Y, 0.0)) * new Matrix3D(new Vector3D(double_2, num2, 0.0), new Vector3D(0.0 - num2, double_2, 0.0), Vector3D.Zero) * new Matrix3D(Vector3D.Zero, Vector3D.Zero, new Vector3D(0.0 - vector2D_0.X, 0.0 - vector2D_0.Y, 0.0)));
	}

	public static Transform2D operator *(Transform2D transform2D_0, Transform2D transform2D_1)
	{
		return new Transform2D(transform2D_0.matrix3D_0 * transform2D_1.matrix3D_0);
	}

	static Transform2D()
	{
		Identity = new Transform2D(Matrix3D.Identity);
		ReflectionX = new Transform2D(new Matrix3D(new double[9] { 1.0, 0.0, 0.0, 0.0, -1.0, 0.0, 0.0, 0.0, 1.0 }));
		ReflectionY = new Transform2D(new Matrix3D(new double[9] { -1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0 }));
		double_0 = System.Math.PI;
	}
}
