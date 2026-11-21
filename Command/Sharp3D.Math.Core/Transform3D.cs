using System;
using CSMaterial;

namespace Sharp3D.Math.Core;

[Serializable]
public sealed class Transform3D : ICloneable
{
	public enum Axis
	{
		X,
		Y,
		Z
	}

	private Matrix4D matrix4D_0 = Matrix4D.Identity;

	public static readonly Transform3D Identity;

	public Matrix4D Matrix
	{
		get
		{
			return matrix4D_0;
		}
		set
		{
			matrix4D_0 = value;
		}
	}

	public Matrix4D MatrixRot => new Matrix4D(matrix4D_0.M11, matrix4D_0.M12, matrix4D_0.M13, 0.0, matrix4D_0.M21, matrix4D_0.M22, matrix4D_0.M23, 0.0, matrix4D_0.M31, matrix4D_0.M32, matrix4D_0.M33, 0.0, matrix4D_0.M41, matrix4D_0.M42, matrix4D_0.M43, 1.0);

	public Vector3D Rotations => new Vector3D(System.Math.Atan2(matrix4D_0.M32, matrix4D_0.M33) * 180.0 / System.Math.PI, System.Math.Asin(0.0 - matrix4D_0.M31) * 180.0 / System.Math.PI, System.Math.Atan2(matrix4D_0.M21, matrix4D_0.M11) * 180.0 / System.Math.PI);

	public Transform3D()
	{
	}

	public Transform3D(Matrix4D matrix4D_1)
	{
		matrix4D_0 = matrix4D_1.Clone();
	}

	public Transform3D(Transform3D transform3D_0)
	{
		matrix4D_0 = transform3D_0.matrix4D_0.Clone();
	}

	public Vector3D transform(Vector3D vector3D_0)
	{
		Vector4D vector4D = matrix4D_0 * new Vector4D(vector3D_0.X, vector3D_0.Y, vector3D_0.Z, 1.0);
		return new Vector3D(vector4D.X, vector4D.Y, vector4D.Z);
	}

	public Vector3D transformRot(Vector3D vector3D_0)
	{
		Vector4D vector4D = MatrixRot * new Vector4D(vector3D_0.X, vector3D_0.Y, vector3D_0.Z, 1.0);
		return new Vector3D(vector4D.X, vector4D.Y, vector4D.Z);
	}

	public Transform3D Inverse()
	{
		double i = matrix4D_0.M11;
		double m13 = matrix4D_0.M12;
		double m14 = matrix4D_0.M13;
		double m15 = matrix4D_0.M14;
		double m16 = matrix4D_0.M21;
		double m17 = matrix4D_0.M22;
		double m18 = matrix4D_0.M23;
		double m19 = matrix4D_0.M24;
		double m20 = matrix4D_0.M31;
		double m10 = matrix4D_0.M32;
		double m11 = matrix4D_0.M33;
		double m12 = matrix4D_0.M34;
		double num = i * m17;
		double num10 = i * m10;
		double num11 = m16 * m13;
		double num12 = m16 * m10;
		double num13 = m20 * m13;
		double num14 = m20 * m17;
		double num15 = num * m11 - num10 * m18 - num11 * m11 + num12 * m14 + num13 * m18 - num14 * m14;
		if (num15 == 0.0)
		{
			throw new Exception("Matrix determinant is 0.0");
		}
		double num16 = 1.0 / num15;
		double num17 = m10 * m14;
		double num2 = m13 * m18;
		double num3 = m17 * m14;
		double num4 = m20 * m14;
		double num5 = i * m18;
		double num6 = m16 * m14;
		double num7 = i * m19;
		double num8 = m16 * m15;
		double num9 = m20 * m15;
		double double_ = (m17 * m11 - m10 * m18) * num16;
		double double_5 = (0.0 - (m13 * m11 - num17)) * num16;
		double double_6 = (num2 - num3) * num16;
		double double_7 = (0.0 - (num2 * m12 - m13 * m19 * m11 - num3 * m12 + m17 * m15 * m11 + num17 * m19 - m10 * m15 * m18)) * num16;
		double double_8 = (0.0 - (m16 * m11 - m20 * m18)) * num16;
		double double_9 = (i * m11 - num4) * num16;
		double double_10 = (0.0 - (num5 - num6)) * num16;
		double double_11 = (num5 * m12 - num7 * m11 - num6 * m12 + num8 * m11 + num4 * m19 - num9 * m18) * num16;
		double double_12 = (num12 - num14) * num16;
		double double_2 = (0.0 - (num10 - num13)) * num16;
		double double_3 = (num - num11) * num16;
		double double_4 = (0.0 - (num * m12 - num7 * m10 - num11 * m12 + num8 * m10 + num13 * m19 - num9 * m17)) * num16;
		return new Transform3D(new Matrix4D(double_, double_5, double_6, double_7, double_8, double_9, double_10, double_11, double_12, double_2, double_3, double_4, 0.0, 0.0, 0.0, 1.0));
	}

	object ICloneable.Clone()
	{
		return new Transform3D(this);
	}

	public Transform3D Clone()
	{
		return new Transform3D(this);
	}

	public static Transform3D Translation(Vector3D vector3D_0)
	{
		Matrix4D identity = Matrix4D.Identity;
		identity.M14 = vector3D_0.X;
		identity.M24 = vector3D_0.Y;
		identity.M34 = vector3D_0.Z;
		return new Transform3D(identity);
	}

	public static Transform3D Rotation(Axis axis_0, double double_0)
	{
		double num = double_0 * CSMath.PI_dividedBy_180;
		double num2 = System.Math.Cos(num);
		double num3 = System.Math.Sin(num);
		Matrix4D identity = Matrix4D.Identity;
		switch (axis_0)
		{
		case Axis.X:
		{
			double num5 = (identity.M33 = num2);
			double k = num5;
			identity.M22 = k;
			identity.M32 = num3;
			identity.M23 = 0.0 - num3;
			break;
		}
		case Axis.Y:
		{
			double num5 = (identity.M33 = num2);
			double j = num5;
			identity.M11 = j;
			identity.M31 = num3;
			identity.M13 = 0.0 - num3;
			break;
		}
		case Axis.Z:
		{
			double num5 = (identity.M22 = num2);
			double i = num5;
			identity.M11 = i;
			identity.M21 = num3;
			identity.M12 = 0.0 - num3;
			break;
		}
		}
		return new Transform3D(identity);
	}

	public static Transform3D RotationX(double double_0)
	{
		double num = double_0 * CSMath.PI_dividedBy_180;
		return new Transform3D(new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, System.Math.Cos(num), 0.0 - System.Math.Sin(num), 0.0, 0.0, System.Math.Sin(num), System.Math.Cos(num), 0.0, 0.0, 0.0, 0.0, 1.0));
	}

	public static Transform3D RotationY(double double_0)
	{
		double num = double_0 * CSMath.PI_dividedBy_180;
		return new Transform3D(new Matrix4D(System.Math.Cos(num), 0.0, System.Math.Sin(num), 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - System.Math.Sin(num), 0.0, System.Math.Cos(num), 0.0, 0.0, 0.0, 0.0, 1.0));
	}

	public static Transform3D RotationZ(double double_0)
	{
		double num = double_0 * CSMath.PI_dividedBy_180;
		return new Transform3D(new Matrix4D(System.Math.Cos(num), 0.0 - System.Math.Sin(num), 0.0, 0.0, System.Math.Sin(num), System.Math.Cos(num), 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0));
	}

	public static Transform3D Rotation(Vector3D vector3D_0, double double_0)
	{
		vector3D_0.Normalize();
		double num = double_0 * System.Math.PI;
		double num2 = System.Math.Cos(num);
		double num3 = System.Math.Sin(num);
		Matrix4D identity = Matrix4D.Identity;
		identity.M11 = vector3D_0.X * vector3D_0.X + (1.0 - vector3D_0.X * vector3D_0.X) * num2;
		identity.M12 = vector3D_0.X * vector3D_0.Y * (1.0 - num2) - vector3D_0.Z * num3;
		identity.M13 = vector3D_0.X * vector3D_0.Z * (1.0 - num2) + vector3D_0.Y * num3;
		identity.M21 = vector3D_0.Y * vector3D_0.X * (1.0 - num2) + vector3D_0.Z * num3;
		identity.M22 = vector3D_0.Y * vector3D_0.Y * (1.0 - vector3D_0.Y * vector3D_0.Y) * num2;
		identity.M21 = vector3D_0.Y * vector3D_0.Z * (1.0 - num2) - vector3D_0.X * num3;
		identity.M31 = vector3D_0.Z * vector3D_0.X * (1.0 - num2) + vector3D_0.Y * num3;
		identity.M32 = vector3D_0.Z * vector3D_0.Y * (1.0 - num2) + vector3D_0.X * num3;
		identity.M33 = vector3D_0.Z * vector3D_0.Z * (1.0 - vector3D_0.Z * vector3D_0.Z) * num2;
		return new Transform3D(identity);
	}

	public static Transform3D Perspective(double double_0)
	{
		Matrix4D identity = Matrix4D.Identity;
		identity.M43 = 1.0 / double_0;
		return new Transform3D(identity);
	}

	public static Transform3D OrthographicProjection(Vector3D vector3D_0, Vector3D vector3D_1, double[] double_0, double[] double_1)
	{
		Matrix4D identity = Matrix4D.Identity;
		identity.M11 = (double_1[0] - double_0[0]) / (vector3D_1.X - vector3D_0.X);
		identity.M22 = (double_1[1] - double_0[1]) / (vector3D_1.Y - vector3D_0.Y);
		identity.M33 = (double_1[2] - double_0[2]) / (vector3D_1.Z - vector3D_0.Z);
		identity.M14 = (double_0[0] * vector3D_1.X - double_1[0] * vector3D_0.X) / (vector3D_1.X - vector3D_0.X);
		identity.M24 = (double_0[1] * vector3D_1.Y - double_1[1] * vector3D_0.Y) / (vector3D_1.Y - vector3D_0.Y);
		identity.M34 = (double_0[2] * vector3D_1.Z - double_1[2] * vector3D_0.Z) / (vector3D_1.Z - vector3D_0.Z);
		return new Transform3D(identity);
	}

	public static Transform3D operator *(Transform3D transform3D_0, Transform3D transform3D_1)
	{
		return new Transform3D(transform3D_0.matrix4D_0 * transform3D_1.matrix4D_0);
	}

	static Transform3D()
	{
		Identity = new Transform3D(Matrix4D.Identity);
	}
}
