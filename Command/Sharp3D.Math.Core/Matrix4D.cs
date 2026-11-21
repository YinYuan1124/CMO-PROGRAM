using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix4D : ICloneable
{
	private double _m11;

	private double _m12;

	private double _m13;

	private double _m14;

	private double _m21;

	private double _m22;

	private double _m23;

	private double _m24;

	private double _m31;

	private double _m32;

	private double _m33;

	private double _m34;

	private double _m41;

	private double _m42;

	private double _m43;

	private double _m44;

	public static readonly Matrix4D Zero;

	public static readonly Matrix4D Identity;

	public double M11
	{
		get
		{
			return _m11;
		}
		set
		{
			_m11 = value;
		}
	}

	public double M12
	{
		get
		{
			return _m12;
		}
		set
		{
			_m12 = value;
		}
	}

	public double M13
	{
		get
		{
			return _m13;
		}
		set
		{
			_m13 = value;
		}
	}

	public double M14
	{
		get
		{
			return _m14;
		}
		set
		{
			_m14 = value;
		}
	}

	public double M21
	{
		get
		{
			return _m21;
		}
		set
		{
			_m21 = value;
		}
	}

	public double M22
	{
		get
		{
			return _m22;
		}
		set
		{
			_m22 = value;
		}
	}

	public double M23
	{
		get
		{
			return _m23;
		}
		set
		{
			_m23 = value;
		}
	}

	public double M24
	{
		get
		{
			return _m24;
		}
		set
		{
			_m24 = value;
		}
	}

	public double M31
	{
		get
		{
			return _m31;
		}
		set
		{
			_m31 = value;
		}
	}

	public double M32
	{
		get
		{
			return _m32;
		}
		set
		{
			_m32 = value;
		}
	}

	public double M33
	{
		get
		{
			return _m33;
		}
		set
		{
			_m33 = value;
		}
	}

	public double M34
	{
		get
		{
			return _m34;
		}
		set
		{
			_m34 = value;
		}
	}

	public double M41
	{
		get
		{
			return _m41;
		}
		set
		{
			_m41 = value;
		}
	}

	public double M42
	{
		get
		{
			return _m42;
		}
		set
		{
			_m42 = value;
		}
	}

	public double M43
	{
		get
		{
			return _m43;
		}
		set
		{
			_m43 = value;
		}
	}

	public double M44
	{
		get
		{
			return _m44;
		}
		set
		{
			_m44 = value;
		}
	}

	public double Trace => _m11 + _m22 + _m33 + _m44;

	public unsafe double this[int int_0]
	{
		get
		{
			if (int_0 < 0 || int_0 >= 16)
			{
				throw new IndexOutOfRangeException("Invalid matrix index!");
			}
			fixed (double* ptr = &_m11)
			{
				return ptr[int_0];
			}
		}
		set
		{
			if (int_0 < 0 || int_0 >= 16)
			{
				throw new IndexOutOfRangeException("Invalid matrix index!");
			}
			fixed (double* ptr = &_m11)
			{
				ptr[int_0] = value;
			}
		}
	}

	public double this[int int_0, int int_1]
	{
		get
		{
			return this[(int_0 - 1) * 4 + (int_1 - 1)];
		}
		set
		{
			this[(int_0 - 1) * 4 + (int_1 - 1)] = value;
		}
	}

	public Matrix4D(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, double double_9, double double_10, double double_11, double double_12, double double_13, double double_14, double double_15)
	{
		_m11 = double_0;
		_m12 = double_1;
		_m13 = double_2;
		_m14 = double_3;
		_m21 = double_4;
		_m22 = double_5;
		_m23 = double_6;
		_m24 = double_7;
		_m31 = double_8;
		_m32 = double_9;
		_m33 = double_10;
		_m34 = double_11;
		_m41 = double_12;
		_m42 = double_13;
		_m43 = double_14;
		_m44 = double_15;
	}

	public Matrix4D(double[] double_0)
	{
		_m11 = double_0[0];
		_m12 = double_0[1];
		_m13 = double_0[2];
		_m14 = double_0[3];
		_m21 = double_0[4];
		_m22 = double_0[5];
		_m23 = double_0[6];
		_m24 = double_0[7];
		_m31 = double_0[8];
		_m32 = double_0[9];
		_m33 = double_0[10];
		_m34 = double_0[11];
		_m41 = double_0[12];
		_m42 = double_0[13];
		_m43 = double_0[14];
		_m44 = double_0[15];
	}

	public Matrix4D(List<double> list_0)
	{
		_m11 = list_0[0];
		_m12 = list_0[1];
		_m13 = list_0[2];
		_m14 = list_0[3];
		_m21 = list_0[4];
		_m22 = list_0[5];
		_m23 = list_0[6];
		_m24 = list_0[7];
		_m31 = list_0[8];
		_m32 = list_0[9];
		_m33 = list_0[10];
		_m34 = list_0[11];
		_m41 = list_0[12];
		_m42 = list_0[13];
		_m43 = list_0[14];
		_m44 = list_0[15];
	}

	public Matrix4D(Vector4D vector4D_0, Vector4D vector4D_1, Vector4D vector4D_2, Vector4D vector4D_3)
	{
		_m11 = vector4D_0.X;
		_m12 = vector4D_1.X;
		_m13 = vector4D_2.X;
		_m14 = vector4D_3.X;
		_m21 = vector4D_0.Y;
		_m22 = vector4D_1.Y;
		_m23 = vector4D_2.Y;
		_m24 = vector4D_3.Y;
		_m31 = vector4D_0.Z;
		_m32 = vector4D_1.Z;
		_m33 = vector4D_2.Z;
		_m34 = vector4D_3.Z;
		_m41 = vector4D_0.W;
		_m42 = vector4D_1.W;
		_m43 = vector4D_2.W;
		_m44 = vector4D_3.W;
	}

	public Matrix4D(Vector3D vector3D_0, Vector3D vector3D_1, Vector3D vector3D_2, Vector3D vector3D_3)
	{
		_m11 = vector3D_0.X;
		_m12 = vector3D_1.X;
		_m13 = vector3D_2.X;
		_m14 = vector3D_3.X;
		_m21 = vector3D_0.Y;
		_m22 = vector3D_1.Y;
		_m23 = vector3D_2.Y;
		_m24 = vector3D_3.Y;
		_m31 = vector3D_0.Z;
		_m32 = vector3D_1.Z;
		_m33 = vector3D_2.Z;
		_m34 = vector3D_3.Z;
		_m41 = 0.0;
		_m42 = 0.0;
		_m43 = 0.0;
		_m44 = 1.0;
	}

	public Matrix4D(Matrix4D matrix4D_0)
	{
		_m11 = matrix4D_0.M11;
		_m12 = matrix4D_0.M12;
		_m13 = matrix4D_0.M13;
		_m14 = matrix4D_0.M14;
		_m21 = matrix4D_0.M21;
		_m22 = matrix4D_0.M22;
		_m23 = matrix4D_0.M23;
		_m24 = matrix4D_0.M24;
		_m31 = matrix4D_0.M31;
		_m32 = matrix4D_0.M32;
		_m33 = matrix4D_0.M33;
		_m34 = matrix4D_0.M34;
		_m41 = matrix4D_0.M41;
		_m42 = matrix4D_0.M42;
		_m43 = matrix4D_0.M43;
		_m44 = matrix4D_0.M44;
	}

	object ICloneable.Clone()
	{
		return new Matrix4D(this);
	}

	public Matrix4D Clone()
	{
		return new Matrix4D(this);
	}

	public static Matrix4D Parse(string string_0)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix4D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m14}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m24}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")), double.Parse(match.Result("${m34}")), double.Parse(match.Result("${m41}")), double.Parse(match.Result("${m42}")), double.Parse(match.Result("${m43}")), double.Parse(match.Result("${m44}")));
	}

	public static bool TryParse(string string_0, out Matrix4D matrix4D_0)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			matrix4D_0 = new Matrix4D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m14}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m24}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")), double.Parse(match.Result("${m34}")), double.Parse(match.Result("${m41}")), double.Parse(match.Result("${m42}")), double.Parse(match.Result("${m43}")), double.Parse(match.Result("${m44}")));
			return true;
		}
		matrix4D_0 = Zero;
		return false;
	}

	public static Matrix4D Add(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return new Matrix4D(matrix4D_0.M11 + matrix4D_1.M11, matrix4D_0.M12 + matrix4D_1.M12, matrix4D_0.M13 + matrix4D_1.M13, matrix4D_0.M14 + matrix4D_1.M14, matrix4D_0.M21 + matrix4D_1.M21, matrix4D_0.M22 + matrix4D_1.M22, matrix4D_0.M23 + matrix4D_1.M23, matrix4D_0.M24 + matrix4D_1.M24, matrix4D_0.M31 + matrix4D_1.M31, matrix4D_0.M32 + matrix4D_1.M32, matrix4D_0.M33 + matrix4D_1.M33, matrix4D_0.M34 + matrix4D_1.M34, matrix4D_0.M41 + matrix4D_1.M41, matrix4D_0.M42 + matrix4D_1.M42, matrix4D_0.M43 + matrix4D_1.M43, matrix4D_0.M44 + matrix4D_1.M44);
	}

	public static Matrix4D Add(Matrix4D matrix4D_0, double double_0)
	{
		return new Matrix4D(matrix4D_0.M11 + double_0, matrix4D_0.M12 + double_0, matrix4D_0.M13 + double_0, matrix4D_0.M14 + double_0, matrix4D_0.M21 + double_0, matrix4D_0.M22 + double_0, matrix4D_0.M23 + double_0, matrix4D_0.M24 + double_0, matrix4D_0.M31 + double_0, matrix4D_0.M32 + double_0, matrix4D_0.M33 + double_0, matrix4D_0.M34 + double_0, matrix4D_0.M41 + double_0, matrix4D_0.M42 + double_0, matrix4D_0.M43 + double_0, matrix4D_0.M44 + double_0);
	}

	public static void Add(Matrix4D matrix4D_0, Matrix4D matrix4D_1, ref Matrix4D matrix4D_2)
	{
		matrix4D_2.M11 = matrix4D_0.M11 + matrix4D_1.M11;
		matrix4D_2.M12 = matrix4D_0.M12 + matrix4D_1.M12;
		matrix4D_2.M13 = matrix4D_0.M13 + matrix4D_1.M13;
		matrix4D_2.M14 = matrix4D_0.M14 + matrix4D_1.M14;
		matrix4D_2.M21 = matrix4D_0.M21 + matrix4D_1.M21;
		matrix4D_2.M22 = matrix4D_0.M22 + matrix4D_1.M22;
		matrix4D_2.M23 = matrix4D_0.M23 + matrix4D_1.M23;
		matrix4D_2.M24 = matrix4D_0.M24 + matrix4D_1.M24;
		matrix4D_2.M31 = matrix4D_0.M31 + matrix4D_1.M31;
		matrix4D_2.M32 = matrix4D_0.M32 + matrix4D_1.M32;
		matrix4D_2.M33 = matrix4D_0.M33 + matrix4D_1.M33;
		matrix4D_2.M34 = matrix4D_0.M34 + matrix4D_1.M34;
		matrix4D_2.M41 = matrix4D_0.M41 + matrix4D_1.M41;
		matrix4D_2.M42 = matrix4D_0.M42 + matrix4D_1.M42;
		matrix4D_2.M43 = matrix4D_0.M43 + matrix4D_1.M43;
		matrix4D_2.M44 = matrix4D_0.M44 + matrix4D_1.M44;
	}

	public static void Add(Matrix4D matrix4D_0, double double_0, ref Matrix4D matrix4D_1)
	{
		matrix4D_1.M11 = matrix4D_0.M11 + double_0;
		matrix4D_1.M12 = matrix4D_0.M12 + double_0;
		matrix4D_1.M13 = matrix4D_0.M13 + double_0;
		matrix4D_1.M14 = matrix4D_0.M14 + double_0;
		matrix4D_1.M21 = matrix4D_0.M21 + double_0;
		matrix4D_1.M22 = matrix4D_0.M22 + double_0;
		matrix4D_1.M23 = matrix4D_0.M23 + double_0;
		matrix4D_1.M24 = matrix4D_0.M24 + double_0;
		matrix4D_1.M31 = matrix4D_0.M31 + double_0;
		matrix4D_1.M32 = matrix4D_0.M32 + double_0;
		matrix4D_1.M33 = matrix4D_0.M33 + double_0;
		matrix4D_1.M34 = matrix4D_0.M34 + double_0;
		matrix4D_1.M41 = matrix4D_0.M41 + double_0;
		matrix4D_1.M42 = matrix4D_0.M42 + double_0;
		matrix4D_1.M43 = matrix4D_0.M43 + double_0;
		matrix4D_1.M44 = matrix4D_0.M44 + double_0;
	}

	public static Matrix4D Subtract(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return new Matrix4D(matrix4D_0.M11 - matrix4D_1.M11, matrix4D_0.M12 - matrix4D_1.M12, matrix4D_0.M13 - matrix4D_1.M13, matrix4D_0.M14 - matrix4D_1.M14, matrix4D_0.M21 - matrix4D_1.M21, matrix4D_0.M22 - matrix4D_1.M22, matrix4D_0.M23 - matrix4D_1.M23, matrix4D_0.M24 - matrix4D_1.M24, matrix4D_0.M31 - matrix4D_1.M31, matrix4D_0.M32 - matrix4D_1.M32, matrix4D_0.M33 - matrix4D_1.M33, matrix4D_0.M34 - matrix4D_1.M34, matrix4D_0.M41 - matrix4D_1.M41, matrix4D_0.M42 - matrix4D_1.M42, matrix4D_0.M43 - matrix4D_1.M43, matrix4D_0.M44 - matrix4D_1.M44);
	}

	public static Matrix4D Subtract(Matrix4D matrix4D_0, double double_0)
	{
		return new Matrix4D(matrix4D_0.M11 - double_0, matrix4D_0.M12 - double_0, matrix4D_0.M13 - double_0, matrix4D_0.M14 - double_0, matrix4D_0.M21 - double_0, matrix4D_0.M22 - double_0, matrix4D_0.M23 - double_0, matrix4D_0.M24 - double_0, matrix4D_0.M31 - double_0, matrix4D_0.M32 - double_0, matrix4D_0.M33 - double_0, matrix4D_0.M34 - double_0, matrix4D_0.M41 - double_0, matrix4D_0.M42 - double_0, matrix4D_0.M43 - double_0, matrix4D_0.M44 - double_0);
	}

	public static void Subtract(Matrix4D matrix4D_0, Matrix4D matrix4D_1, ref Matrix4D matrix4D_2)
	{
		matrix4D_2.M11 = matrix4D_0.M11 - matrix4D_1.M11;
		matrix4D_2.M12 = matrix4D_0.M12 - matrix4D_1.M12;
		matrix4D_2.M13 = matrix4D_0.M13 - matrix4D_1.M13;
		matrix4D_2.M14 = matrix4D_0.M14 - matrix4D_1.M14;
		matrix4D_2.M21 = matrix4D_0.M21 - matrix4D_1.M21;
		matrix4D_2.M22 = matrix4D_0.M22 - matrix4D_1.M22;
		matrix4D_2.M23 = matrix4D_0.M23 - matrix4D_1.M23;
		matrix4D_2.M24 = matrix4D_0.M24 - matrix4D_1.M24;
		matrix4D_2.M31 = matrix4D_0.M31 - matrix4D_1.M31;
		matrix4D_2.M32 = matrix4D_0.M32 - matrix4D_1.M32;
		matrix4D_2.M33 = matrix4D_0.M33 - matrix4D_1.M33;
		matrix4D_2.M34 = matrix4D_0.M34 - matrix4D_1.M34;
		matrix4D_2.M41 = matrix4D_0.M41 - matrix4D_1.M41;
		matrix4D_2.M42 = matrix4D_0.M42 - matrix4D_1.M42;
		matrix4D_2.M43 = matrix4D_0.M43 - matrix4D_1.M43;
		matrix4D_2.M44 = matrix4D_0.M44 - matrix4D_1.M44;
	}

	public static void Subtract(Matrix4D matrix4D_0, double double_0, ref Matrix4D matrix4D_1)
	{
		matrix4D_1.M11 = matrix4D_0.M11 - double_0;
		matrix4D_1.M12 = matrix4D_0.M12 - double_0;
		matrix4D_1.M13 = matrix4D_0.M13 - double_0;
		matrix4D_1.M14 = matrix4D_0.M14 - double_0;
		matrix4D_1.M21 = matrix4D_0.M21 - double_0;
		matrix4D_1.M22 = matrix4D_0.M22 - double_0;
		matrix4D_1.M23 = matrix4D_0.M23 - double_0;
		matrix4D_1.M24 = matrix4D_0.M24 - double_0;
		matrix4D_1.M31 = matrix4D_0.M31 - double_0;
		matrix4D_1.M32 = matrix4D_0.M32 - double_0;
		matrix4D_1.M33 = matrix4D_0.M33 - double_0;
		matrix4D_1.M34 = matrix4D_0.M34 - double_0;
		matrix4D_1.M41 = matrix4D_0.M41 - double_0;
		matrix4D_1.M42 = matrix4D_0.M42 - double_0;
		matrix4D_1.M43 = matrix4D_0.M43 - double_0;
		matrix4D_1.M44 = matrix4D_0.M44 - double_0;
	}

	public static Matrix4D Multiply(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return new Matrix4D(matrix4D_0.M11 * matrix4D_1.M11 + matrix4D_0.M12 * matrix4D_1.M21 + matrix4D_0.M13 * matrix4D_1.M31 + matrix4D_0.M14 * matrix4D_1.M41, matrix4D_0.M11 * matrix4D_1.M12 + matrix4D_0.M12 * matrix4D_1.M22 + matrix4D_0.M13 * matrix4D_1.M32 + matrix4D_0.M14 * matrix4D_1.M42, matrix4D_0.M11 * matrix4D_1.M13 + matrix4D_0.M12 * matrix4D_1.M23 + matrix4D_0.M13 * matrix4D_1.M33 + matrix4D_0.M14 * matrix4D_1.M43, matrix4D_0.M11 * matrix4D_1.M14 + matrix4D_0.M12 * matrix4D_1.M24 + matrix4D_0.M13 * matrix4D_1.M34 + matrix4D_0.M14 * matrix4D_1.M44, matrix4D_0.M21 * matrix4D_1.M11 + matrix4D_0.M22 * matrix4D_1.M21 + matrix4D_0.M23 * matrix4D_1.M31 + matrix4D_0.M24 * matrix4D_1.M41, matrix4D_0.M21 * matrix4D_1.M12 + matrix4D_0.M22 * matrix4D_1.M22 + matrix4D_0.M23 * matrix4D_1.M32 + matrix4D_0.M24 * matrix4D_1.M42, matrix4D_0.M21 * matrix4D_1.M13 + matrix4D_0.M22 * matrix4D_1.M23 + matrix4D_0.M23 * matrix4D_1.M33 + matrix4D_0.M24 * matrix4D_1.M43, matrix4D_0.M21 * matrix4D_1.M14 + matrix4D_0.M22 * matrix4D_1.M24 + matrix4D_0.M23 * matrix4D_1.M34 + matrix4D_0.M24 * matrix4D_1.M44, matrix4D_0.M31 * matrix4D_1.M11 + matrix4D_0.M32 * matrix4D_1.M21 + matrix4D_0.M33 * matrix4D_1.M31 + matrix4D_0.M34 * matrix4D_1.M41, matrix4D_0.M31 * matrix4D_1.M12 + matrix4D_0.M32 * matrix4D_1.M22 + matrix4D_0.M33 * matrix4D_1.M32 + matrix4D_0.M34 * matrix4D_1.M42, matrix4D_0.M31 * matrix4D_1.M13 + matrix4D_0.M32 * matrix4D_1.M23 + matrix4D_0.M33 * matrix4D_1.M33 + matrix4D_0.M34 * matrix4D_1.M43, matrix4D_0.M31 * matrix4D_1.M14 + matrix4D_0.M32 * matrix4D_1.M24 + matrix4D_0.M33 * matrix4D_1.M34 + matrix4D_0.M34 * matrix4D_1.M44, matrix4D_0.M41 * matrix4D_1.M11 + matrix4D_0.M42 * matrix4D_1.M21 + matrix4D_0.M43 * matrix4D_1.M31 + matrix4D_0.M44 * matrix4D_1.M41, matrix4D_0.M41 * matrix4D_1.M12 + matrix4D_0.M42 * matrix4D_1.M22 + matrix4D_0.M43 * matrix4D_1.M32 + matrix4D_0.M44 * matrix4D_1.M42, matrix4D_0.M41 * matrix4D_1.M13 + matrix4D_0.M42 * matrix4D_1.M23 + matrix4D_0.M43 * matrix4D_1.M33 + matrix4D_0.M44 * matrix4D_1.M43, matrix4D_0.M41 * matrix4D_1.M14 + matrix4D_0.M42 * matrix4D_1.M24 + matrix4D_0.M43 * matrix4D_1.M34 + matrix4D_0.M44 * matrix4D_1.M44);
	}

	public static void Multiply(Matrix4D matrix4D_0, Matrix4D matrix4D_1, ref Matrix4D matrix4D_2)
	{
		matrix4D_2.M11 = matrix4D_0.M11 * matrix4D_1.M11 + matrix4D_0.M12 * matrix4D_1.M21 + matrix4D_0.M13 * matrix4D_1.M31 + matrix4D_0.M14 * matrix4D_1.M41;
		matrix4D_2.M12 = matrix4D_0.M11 * matrix4D_1.M12 + matrix4D_0.M12 * matrix4D_1.M22 + matrix4D_0.M13 * matrix4D_1.M32 + matrix4D_0.M14 * matrix4D_1.M42;
		matrix4D_2.M13 = matrix4D_0.M11 * matrix4D_1.M13 + matrix4D_0.M12 * matrix4D_1.M23 + matrix4D_0.M13 * matrix4D_1.M33 + matrix4D_0.M14 * matrix4D_1.M43;
		matrix4D_2.M14 = matrix4D_0.M11 * matrix4D_1.M14 + matrix4D_0.M12 * matrix4D_1.M24 + matrix4D_0.M13 * matrix4D_1.M34 + matrix4D_0.M14 * matrix4D_1.M44;
		matrix4D_2.M21 = matrix4D_0.M21 * matrix4D_1.M11 + matrix4D_0.M22 * matrix4D_1.M21 + matrix4D_0.M23 * matrix4D_1.M31 + matrix4D_0.M24 * matrix4D_1.M41;
		matrix4D_2.M22 = matrix4D_0.M21 * matrix4D_1.M12 + matrix4D_0.M22 * matrix4D_1.M22 + matrix4D_0.M23 * matrix4D_1.M32 + matrix4D_0.M24 * matrix4D_1.M42;
		matrix4D_2.M23 = matrix4D_0.M21 * matrix4D_1.M13 + matrix4D_0.M22 * matrix4D_1.M23 + matrix4D_0.M23 * matrix4D_1.M33 + matrix4D_0.M24 * matrix4D_1.M43;
		matrix4D_2.M24 = matrix4D_0.M21 * matrix4D_1.M14 + matrix4D_0.M22 * matrix4D_1.M24 + matrix4D_0.M23 * matrix4D_1.M34 + matrix4D_0.M24 * matrix4D_1.M44;
		matrix4D_2.M31 = matrix4D_0.M31 * matrix4D_1.M11 + matrix4D_0.M32 * matrix4D_1.M21 + matrix4D_0.M33 * matrix4D_1.M31 + matrix4D_0.M34 * matrix4D_1.M41;
		matrix4D_2.M32 = matrix4D_0.M31 * matrix4D_1.M12 + matrix4D_0.M32 * matrix4D_1.M22 + matrix4D_0.M33 * matrix4D_1.M32 + matrix4D_0.M34 * matrix4D_1.M42;
		matrix4D_2.M33 = matrix4D_0.M31 * matrix4D_1.M13 + matrix4D_0.M32 * matrix4D_1.M23 + matrix4D_0.M33 * matrix4D_1.M33 + matrix4D_0.M34 * matrix4D_1.M43;
		matrix4D_2.M34 = matrix4D_0.M31 * matrix4D_1.M14 + matrix4D_0.M32 * matrix4D_1.M24 + matrix4D_0.M33 * matrix4D_1.M34 + matrix4D_0.M34 * matrix4D_1.M44;
		matrix4D_2.M41 = matrix4D_0.M41 * matrix4D_1.M11 + matrix4D_0.M42 * matrix4D_1.M21 + matrix4D_0.M43 * matrix4D_1.M31 + matrix4D_0.M44 * matrix4D_1.M41;
		matrix4D_2.M42 = matrix4D_0.M41 * matrix4D_1.M12 + matrix4D_0.M42 * matrix4D_1.M22 + matrix4D_0.M43 * matrix4D_1.M32 + matrix4D_0.M44 * matrix4D_1.M42;
		matrix4D_2.M43 = matrix4D_0.M41 * matrix4D_1.M13 + matrix4D_0.M42 * matrix4D_1.M23 + matrix4D_0.M43 * matrix4D_1.M33 + matrix4D_0.M44 * matrix4D_1.M43;
		matrix4D_2.M44 = matrix4D_0.M41 * matrix4D_1.M14 + matrix4D_0.M42 * matrix4D_1.M24 + matrix4D_0.M43 * matrix4D_1.M34 + matrix4D_0.M44 * matrix4D_1.M44;
	}

	public static Vector4D Transform(Matrix4D matrix4D_0, Vector4D vector4D_0)
	{
		return new Vector4D(matrix4D_0.M11 * vector4D_0.X + matrix4D_0.M12 * vector4D_0.Y + matrix4D_0.M13 * vector4D_0.Z + matrix4D_0.M14 * vector4D_0.W, matrix4D_0.M21 * vector4D_0.X + matrix4D_0.M22 * vector4D_0.Y + matrix4D_0.M23 * vector4D_0.Z + matrix4D_0.M24 * vector4D_0.W, matrix4D_0.M31 * vector4D_0.X + matrix4D_0.M32 * vector4D_0.Y + matrix4D_0.M33 * vector4D_0.Z + matrix4D_0.M34 * vector4D_0.W, matrix4D_0.M41 * vector4D_0.X + matrix4D_0.M42 * vector4D_0.Y + matrix4D_0.M43 * vector4D_0.Z + matrix4D_0.M44 * vector4D_0.W);
	}

	public static void Transform(Matrix4D matrix4D_0, Vector4D vector4D_0, ref Vector4D vector4D_1)
	{
		vector4D_1.X = matrix4D_0.M11 * vector4D_0.X + matrix4D_0.M12 * vector4D_0.Y + matrix4D_0.M13 * vector4D_0.Z + matrix4D_0.M14 * vector4D_0.W;
		vector4D_1.Y = matrix4D_0.M21 * vector4D_0.X + matrix4D_0.M22 * vector4D_0.Y + matrix4D_0.M23 * vector4D_0.Z + matrix4D_0.M24 * vector4D_0.W;
		vector4D_1.Z = matrix4D_0.M31 * vector4D_0.X + matrix4D_0.M32 * vector4D_0.Y + matrix4D_0.M33 * vector4D_0.Z + matrix4D_0.M34 * vector4D_0.W;
		vector4D_1.W = matrix4D_0.M41 * vector4D_0.X + matrix4D_0.M42 * vector4D_0.Y + matrix4D_0.M43 * vector4D_0.Z + matrix4D_0.M44 * vector4D_0.W;
	}

	public static Matrix4D Transpose(Matrix4D matrix4D_0)
	{
		Matrix4D result = new Matrix4D(matrix4D_0);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return _m11.GetHashCode() ^ _m12.GetHashCode() ^ _m13.GetHashCode() ^ _m14.GetHashCode() ^ _m21.GetHashCode() ^ _m22.GetHashCode() ^ _m23.GetHashCode() ^ _m24.GetHashCode() ^ _m31.GetHashCode() ^ _m32.GetHashCode() ^ _m33.GetHashCode() ^ _m34.GetHashCode() ^ _m41.GetHashCode() ^ _m42.GetHashCode() ^ _m43.GetHashCode() ^ _m44.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix4D matrix4D)
		{
			if (_m11 == matrix4D.M11 && _m12 == matrix4D.M12 && _m13 == matrix4D.M13 && _m14 == matrix4D.M14 && _m21 == matrix4D.M21 && _m22 == matrix4D.M22 && _m23 == matrix4D.M23 && _m24 == matrix4D.M24 && _m31 == matrix4D.M31 && _m32 == matrix4D.M32 && _m33 == matrix4D.M33 && _m34 == matrix4D.M34 && _m41 == matrix4D.M41 && _m42 == matrix4D.M42 && _m43 == matrix4D.M43)
			{
				return _m44 == matrix4D.M44;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "4x4[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}]", _m11, _m12, _m13, _m14, _m21, _m22, _m23, _m24, _m31, _m32, _m33, _m34, _m41, _m42, _m43, _m44);
	}

	public double GetDeterminant()
	{
		return _m14 * _m23 * _m32 * _m41 - _m13 * _m24 * _m32 * _m41 - _m14 * _m22 * _m33 * _m41 + _m12 * _m24 * _m33 * _m41 + _m13 * _m22 * _m34 * _m41 - _m12 * _m23 * _m34 * _m41 - _m14 * _m23 * _m31 * _m42 + _m13 * _m24 * _m31 * _m42 + _m14 * _m21 * _m33 * _m42 - _m11 * _m24 * _m33 * _m42 - _m13 * _m21 * _m34 * _m42 + _m11 * _m23 * _m34 * _m42 + _m14 * _m22 * _m31 * _m43 - _m12 * _m24 * _m31 * _m43 - _m14 * _m21 * _m32 * _m43 + _m11 * _m24 * _m32 * _m43 + _m12 * _m21 * _m34 * _m43 - _m11 * _m22 * _m34 * _m43 - _m13 * _m22 * _m31 * _m44 + _m12 * _m23 * _m31 * _m44 + _m13 * _m21 * _m32 * _m44 - _m11 * _m23 * _m32 * _m44 - _m12 * _m21 * _m33 * _m44 + _m11 * _m22 * _m33 * _m44;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref _m12, ref _m21);
		MathFunctions.Swap(ref _m13, ref _m31);
		MathFunctions.Swap(ref _m14, ref _m41);
		MathFunctions.Swap(ref _m23, ref _m32);
		MathFunctions.Swap(ref _m24, ref _m42);
		MathFunctions.Swap(ref _m34, ref _m43);
	}

	public static bool operator ==(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return object.Equals(matrix4D_0, matrix4D_1);
	}

	public static bool operator !=(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return !object.Equals(matrix4D_0, matrix4D_1);
	}

	public static Matrix4D operator +(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return Add(matrix4D_0, matrix4D_1);
	}

	public static Matrix4D operator +(Matrix4D matrix4D_0, double double_0)
	{
		return Add(matrix4D_0, double_0);
	}

	public static Matrix4D operator +(double double_0, Matrix4D matrix4D_0)
	{
		return Add(matrix4D_0, double_0);
	}

	public static Matrix4D operator -(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return Subtract(matrix4D_0, matrix4D_1);
	}

	public static Matrix4D operator -(Matrix4D matrix4D_0, double double_0)
	{
		return Subtract(matrix4D_0, double_0);
	}

	public static Matrix4D operator *(Matrix4D matrix4D_0, Matrix4D matrix4D_1)
	{
		return Multiply(matrix4D_0, matrix4D_1);
	}

	public static Vector4D operator *(Matrix4D matrix4D_0, Vector4D vector4D_0)
	{
		return Transform(matrix4D_0, vector4D_0);
	}

	static Matrix4D()
	{
		Zero = new Matrix4D(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Identity = new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
	}
}
