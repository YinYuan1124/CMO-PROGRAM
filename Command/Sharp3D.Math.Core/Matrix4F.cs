using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix4F : ICloneable
{
	private float _m11;

	private float _m12;

	private float _m13;

	private float _m14;

	private float _m21;

	private float _m22;

	private float _m23;

	private float _m24;

	private float _m31;

	private float _m32;

	private float _m33;

	private float _m34;

	private float _m41;

	private float _m42;

	private float _m43;

	private float _m44;

	public static readonly Matrix4F Zero;

	public static readonly Matrix4F Identity;

	public float M11
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

	public float M12
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

	public float M13
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

	public float M14
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

	public float M21
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

	public float M22
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

	public float M23
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

	public float M24
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

	public float M31
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

	public float M32
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

	public float M33
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

	public float M34
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

	public float M41
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

	public float M42
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

	public float M43
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

	public float M44
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

	public float Trace => _m11 + _m22 + _m33 + _m44;

	public unsafe float this[int int_0]
	{
		get
		{
			if (int_0 < 0 || int_0 >= 16)
			{
				throw new IndexOutOfRangeException("Invalid matrix index!");
			}
			fixed (float* ptr = &_m11)
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
			fixed (float* ptr = &_m11)
			{
				ptr[int_0] = value;
			}
		}
	}

	public float this[int int_0, int int_1]
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

	public Matrix4F(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15)
	{
		_m11 = float_0;
		_m12 = float_1;
		_m13 = float_2;
		_m14 = float_3;
		_m21 = float_4;
		_m22 = float_5;
		_m23 = float_6;
		_m24 = float_7;
		_m31 = float_8;
		_m32 = float_9;
		_m33 = float_10;
		_m34 = float_11;
		_m41 = float_12;
		_m42 = float_13;
		_m43 = float_14;
		_m44 = float_15;
	}

	public Matrix4F(float[] float_0)
	{
		_m11 = float_0[0];
		_m12 = float_0[1];
		_m13 = float_0[2];
		_m14 = float_0[3];
		_m21 = float_0[4];
		_m22 = float_0[5];
		_m23 = float_0[6];
		_m24 = float_0[7];
		_m31 = float_0[8];
		_m32 = float_0[9];
		_m33 = float_0[10];
		_m34 = float_0[11];
		_m41 = float_0[12];
		_m42 = float_0[13];
		_m43 = float_0[14];
		_m44 = float_0[15];
	}

	public Matrix4F(List<float> list_0)
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

	public Matrix4F(Vector4F vector4F_0, Vector4F vector4F_1, Vector4F vector4F_2, Vector4F vector4F_3)
	{
		_m11 = vector4F_0.X;
		_m12 = vector4F_1.X;
		_m13 = vector4F_2.X;
		_m14 = vector4F_3.X;
		_m21 = vector4F_0.Y;
		_m22 = vector4F_1.Y;
		_m23 = vector4F_2.Y;
		_m24 = vector4F_3.Y;
		_m31 = vector4F_0.Z;
		_m32 = vector4F_1.Z;
		_m33 = vector4F_2.Z;
		_m34 = vector4F_3.Z;
		_m41 = vector4F_0.W;
		_m42 = vector4F_1.W;
		_m43 = vector4F_2.W;
		_m44 = vector4F_3.W;
	}

	public Matrix4F(Matrix4F matrix4F_0)
	{
		_m11 = matrix4F_0.M11;
		_m12 = matrix4F_0.M12;
		_m13 = matrix4F_0.M13;
		_m14 = matrix4F_0.M14;
		_m21 = matrix4F_0.M21;
		_m22 = matrix4F_0.M22;
		_m23 = matrix4F_0.M23;
		_m24 = matrix4F_0.M24;
		_m31 = matrix4F_0.M31;
		_m32 = matrix4F_0.M32;
		_m33 = matrix4F_0.M33;
		_m34 = matrix4F_0.M34;
		_m41 = matrix4F_0.M41;
		_m42 = matrix4F_0.M42;
		_m43 = matrix4F_0.M43;
		_m44 = matrix4F_0.M44;
	}

	object ICloneable.Clone()
	{
		return new Matrix4F(this);
	}

	public Matrix4F Clone()
	{
		return new Matrix4F(this);
	}

	public static Matrix4F Parse(string string_0)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix4F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m14}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m24}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")), float.Parse(match.Result("${m34}")), float.Parse(match.Result("${m41}")), float.Parse(match.Result("${m42}")), float.Parse(match.Result("${m43}")), float.Parse(match.Result("${m44}")));
	}

	public static bool TryParse(string string_0, out Matrix4F matrix4F_0)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			matrix4F_0 = new Matrix4F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m14}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m24}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")), float.Parse(match.Result("${m34}")), float.Parse(match.Result("${m41}")), float.Parse(match.Result("${m42}")), float.Parse(match.Result("${m43}")), float.Parse(match.Result("${m44}")));
			return true;
		}
		matrix4F_0 = Zero;
		return false;
	}

	public static Matrix4F Add(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return new Matrix4F(matrix4F_0.M11 + matrix4F_1.M11, matrix4F_0.M12 + matrix4F_1.M12, matrix4F_0.M13 + matrix4F_1.M13, matrix4F_0.M14 + matrix4F_1.M14, matrix4F_0.M21 + matrix4F_1.M21, matrix4F_0.M22 + matrix4F_1.M22, matrix4F_0.M23 + matrix4F_1.M23, matrix4F_0.M24 + matrix4F_1.M24, matrix4F_0.M31 + matrix4F_1.M31, matrix4F_0.M32 + matrix4F_1.M32, matrix4F_0.M33 + matrix4F_1.M33, matrix4F_0.M34 + matrix4F_1.M34, matrix4F_0.M41 + matrix4F_1.M41, matrix4F_0.M42 + matrix4F_1.M42, matrix4F_0.M43 + matrix4F_1.M43, matrix4F_0.M44 + matrix4F_1.M44);
	}

	public static Matrix4F Add(Matrix4F matrix4F_0, float float_0)
	{
		return new Matrix4F(matrix4F_0.M11 + float_0, matrix4F_0.M12 + float_0, matrix4F_0.M13 + float_0, matrix4F_0.M14 + float_0, matrix4F_0.M21 + float_0, matrix4F_0.M22 + float_0, matrix4F_0.M23 + float_0, matrix4F_0.M24 + float_0, matrix4F_0.M31 + float_0, matrix4F_0.M32 + float_0, matrix4F_0.M33 + float_0, matrix4F_0.M34 + float_0, matrix4F_0.M41 + float_0, matrix4F_0.M42 + float_0, matrix4F_0.M43 + float_0, matrix4F_0.M44 + float_0);
	}

	public static void Add(Matrix4F matrix4F_0, Matrix4F matrix4F_1, ref Matrix4F matrix4F_2)
	{
		matrix4F_2.M11 = matrix4F_0.M11 + matrix4F_1.M11;
		matrix4F_2.M12 = matrix4F_0.M12 + matrix4F_1.M12;
		matrix4F_2.M13 = matrix4F_0.M13 + matrix4F_1.M13;
		matrix4F_2.M14 = matrix4F_0.M14 + matrix4F_1.M14;
		matrix4F_2.M21 = matrix4F_0.M21 + matrix4F_1.M21;
		matrix4F_2.M22 = matrix4F_0.M22 + matrix4F_1.M22;
		matrix4F_2.M23 = matrix4F_0.M23 + matrix4F_1.M23;
		matrix4F_2.M24 = matrix4F_0.M24 + matrix4F_1.M24;
		matrix4F_2.M31 = matrix4F_0.M31 + matrix4F_1.M31;
		matrix4F_2.M32 = matrix4F_0.M32 + matrix4F_1.M32;
		matrix4F_2.M33 = matrix4F_0.M33 + matrix4F_1.M33;
		matrix4F_2.M34 = matrix4F_0.M34 + matrix4F_1.M34;
		matrix4F_2.M41 = matrix4F_0.M41 + matrix4F_1.M41;
		matrix4F_2.M42 = matrix4F_0.M42 + matrix4F_1.M42;
		matrix4F_2.M43 = matrix4F_0.M43 + matrix4F_1.M43;
		matrix4F_2.M44 = matrix4F_0.M44 + matrix4F_1.M44;
	}

	public static void Add(Matrix4F matrix4F_0, float float_0, ref Matrix4F matrix4F_1)
	{
		matrix4F_1.M11 = matrix4F_0.M11 + float_0;
		matrix4F_1.M12 = matrix4F_0.M12 + float_0;
		matrix4F_1.M13 = matrix4F_0.M13 + float_0;
		matrix4F_1.M14 = matrix4F_0.M14 + float_0;
		matrix4F_1.M21 = matrix4F_0.M21 + float_0;
		matrix4F_1.M22 = matrix4F_0.M22 + float_0;
		matrix4F_1.M23 = matrix4F_0.M23 + float_0;
		matrix4F_1.M24 = matrix4F_0.M24 + float_0;
		matrix4F_1.M31 = matrix4F_0.M31 + float_0;
		matrix4F_1.M32 = matrix4F_0.M32 + float_0;
		matrix4F_1.M33 = matrix4F_0.M33 + float_0;
		matrix4F_1.M34 = matrix4F_0.M34 + float_0;
		matrix4F_1.M41 = matrix4F_0.M41 + float_0;
		matrix4F_1.M42 = matrix4F_0.M42 + float_0;
		matrix4F_1.M43 = matrix4F_0.M43 + float_0;
		matrix4F_1.M44 = matrix4F_0.M44 + float_0;
	}

	public static Matrix4F Subtract(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return new Matrix4F(matrix4F_0.M11 - matrix4F_1.M11, matrix4F_0.M12 - matrix4F_1.M12, matrix4F_0.M13 - matrix4F_1.M13, matrix4F_0.M14 - matrix4F_1.M14, matrix4F_0.M21 - matrix4F_1.M21, matrix4F_0.M22 - matrix4F_1.M22, matrix4F_0.M23 - matrix4F_1.M23, matrix4F_0.M24 - matrix4F_1.M24, matrix4F_0.M31 - matrix4F_1.M31, matrix4F_0.M32 - matrix4F_1.M32, matrix4F_0.M33 - matrix4F_1.M33, matrix4F_0.M34 - matrix4F_1.M34, matrix4F_0.M41 - matrix4F_1.M41, matrix4F_0.M42 - matrix4F_1.M42, matrix4F_0.M43 - matrix4F_1.M43, matrix4F_0.M44 - matrix4F_1.M44);
	}

	public static Matrix4F Subtract(Matrix4F matrix4F_0, float float_0)
	{
		return new Matrix4F(matrix4F_0.M11 - float_0, matrix4F_0.M12 - float_0, matrix4F_0.M13 - float_0, matrix4F_0.M14 - float_0, matrix4F_0.M21 - float_0, matrix4F_0.M22 - float_0, matrix4F_0.M23 - float_0, matrix4F_0.M24 - float_0, matrix4F_0.M31 - float_0, matrix4F_0.M32 - float_0, matrix4F_0.M33 - float_0, matrix4F_0.M34 - float_0, matrix4F_0.M41 - float_0, matrix4F_0.M42 - float_0, matrix4F_0.M43 - float_0, matrix4F_0.M44 - float_0);
	}

	public static void Subtract(Matrix4F matrix4F_0, Matrix4F matrix4F_1, ref Matrix4F matrix4F_2)
	{
		matrix4F_2.M11 = matrix4F_0.M11 - matrix4F_1.M11;
		matrix4F_2.M12 = matrix4F_0.M12 - matrix4F_1.M12;
		matrix4F_2.M13 = matrix4F_0.M13 - matrix4F_1.M13;
		matrix4F_2.M14 = matrix4F_0.M14 - matrix4F_1.M14;
		matrix4F_2.M21 = matrix4F_0.M21 - matrix4F_1.M21;
		matrix4F_2.M22 = matrix4F_0.M22 - matrix4F_1.M22;
		matrix4F_2.M23 = matrix4F_0.M23 - matrix4F_1.M23;
		matrix4F_2.M24 = matrix4F_0.M24 - matrix4F_1.M24;
		matrix4F_2.M31 = matrix4F_0.M31 - matrix4F_1.M31;
		matrix4F_2.M32 = matrix4F_0.M32 - matrix4F_1.M32;
		matrix4F_2.M33 = matrix4F_0.M33 - matrix4F_1.M33;
		matrix4F_2.M34 = matrix4F_0.M34 - matrix4F_1.M34;
		matrix4F_2.M41 = matrix4F_0.M41 - matrix4F_1.M41;
		matrix4F_2.M42 = matrix4F_0.M42 - matrix4F_1.M42;
		matrix4F_2.M43 = matrix4F_0.M43 - matrix4F_1.M43;
		matrix4F_2.M44 = matrix4F_0.M44 - matrix4F_1.M44;
	}

	public static void Subtract(Matrix4F matrix4F_0, float float_0, ref Matrix4F matrix4F_1)
	{
		matrix4F_1.M11 = matrix4F_0.M11 - float_0;
		matrix4F_1.M12 = matrix4F_0.M12 - float_0;
		matrix4F_1.M13 = matrix4F_0.M13 - float_0;
		matrix4F_1.M14 = matrix4F_0.M14 - float_0;
		matrix4F_1.M21 = matrix4F_0.M21 - float_0;
		matrix4F_1.M22 = matrix4F_0.M22 - float_0;
		matrix4F_1.M23 = matrix4F_0.M23 - float_0;
		matrix4F_1.M24 = matrix4F_0.M24 - float_0;
		matrix4F_1.M31 = matrix4F_0.M31 - float_0;
		matrix4F_1.M32 = matrix4F_0.M32 - float_0;
		matrix4F_1.M33 = matrix4F_0.M33 - float_0;
		matrix4F_1.M34 = matrix4F_0.M34 - float_0;
		matrix4F_1.M41 = matrix4F_0.M41 - float_0;
		matrix4F_1.M42 = matrix4F_0.M42 - float_0;
		matrix4F_1.M43 = matrix4F_0.M43 - float_0;
		matrix4F_1.M44 = matrix4F_0.M44 - float_0;
	}

	public static Matrix4F Multiply(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return new Matrix4F(matrix4F_0.M11 * matrix4F_1.M11 + matrix4F_0.M12 * matrix4F_1.M21 + matrix4F_0.M13 * matrix4F_1.M31 + matrix4F_0.M14 * matrix4F_1.M41, matrix4F_0.M11 * matrix4F_1.M12 + matrix4F_0.M12 * matrix4F_1.M22 + matrix4F_0.M13 * matrix4F_1.M32 + matrix4F_0.M14 * matrix4F_1.M42, matrix4F_0.M11 * matrix4F_1.M13 + matrix4F_0.M12 * matrix4F_1.M23 + matrix4F_0.M13 * matrix4F_1.M33 + matrix4F_0.M14 * matrix4F_1.M43, matrix4F_0.M11 * matrix4F_1.M14 + matrix4F_0.M12 * matrix4F_1.M24 + matrix4F_0.M13 * matrix4F_1.M34 + matrix4F_0.M14 * matrix4F_1.M44, matrix4F_0.M21 * matrix4F_1.M11 + matrix4F_0.M22 * matrix4F_1.M21 + matrix4F_0.M23 * matrix4F_1.M31 + matrix4F_0.M24 * matrix4F_1.M41, matrix4F_0.M21 * matrix4F_1.M12 + matrix4F_0.M22 * matrix4F_1.M22 + matrix4F_0.M23 * matrix4F_1.M32 + matrix4F_0.M24 * matrix4F_1.M42, matrix4F_0.M21 * matrix4F_1.M13 + matrix4F_0.M22 * matrix4F_1.M23 + matrix4F_0.M23 * matrix4F_1.M33 + matrix4F_0.M24 * matrix4F_1.M43, matrix4F_0.M21 * matrix4F_1.M14 + matrix4F_0.M22 * matrix4F_1.M24 + matrix4F_0.M23 * matrix4F_1.M34 + matrix4F_0.M24 * matrix4F_1.M44, matrix4F_0.M31 * matrix4F_1.M11 + matrix4F_0.M32 * matrix4F_1.M21 + matrix4F_0.M33 * matrix4F_1.M31 + matrix4F_0.M34 * matrix4F_1.M41, matrix4F_0.M31 * matrix4F_1.M12 + matrix4F_0.M32 * matrix4F_1.M22 + matrix4F_0.M33 * matrix4F_1.M32 + matrix4F_0.M34 * matrix4F_1.M42, matrix4F_0.M31 * matrix4F_1.M13 + matrix4F_0.M32 * matrix4F_1.M23 + matrix4F_0.M33 * matrix4F_1.M33 + matrix4F_0.M34 * matrix4F_1.M43, matrix4F_0.M31 * matrix4F_1.M14 + matrix4F_0.M32 * matrix4F_1.M24 + matrix4F_0.M33 * matrix4F_1.M34 + matrix4F_0.M34 * matrix4F_1.M44, matrix4F_0.M41 * matrix4F_1.M11 + matrix4F_0.M42 * matrix4F_1.M21 + matrix4F_0.M43 * matrix4F_1.M31 + matrix4F_0.M44 * matrix4F_1.M41, matrix4F_0.M41 * matrix4F_1.M12 + matrix4F_0.M42 * matrix4F_1.M22 + matrix4F_0.M43 * matrix4F_1.M32 + matrix4F_0.M44 * matrix4F_1.M42, matrix4F_0.M41 * matrix4F_1.M13 + matrix4F_0.M42 * matrix4F_1.M23 + matrix4F_0.M43 * matrix4F_1.M33 + matrix4F_0.M44 * matrix4F_1.M43, matrix4F_0.M41 * matrix4F_1.M14 + matrix4F_0.M42 * matrix4F_1.M24 + matrix4F_0.M43 * matrix4F_1.M34 + matrix4F_0.M44 * matrix4F_1.M44);
	}

	public static void Multiply(Matrix4F matrix4F_0, Matrix4F matrix4F_1, ref Matrix4F matrix4F_2)
	{
		matrix4F_2.M11 = matrix4F_0.M11 * matrix4F_1.M11 + matrix4F_0.M12 * matrix4F_1.M21 + matrix4F_0.M13 * matrix4F_1.M31 + matrix4F_0.M14 * matrix4F_1.M41;
		matrix4F_2.M12 = matrix4F_0.M11 * matrix4F_1.M12 + matrix4F_0.M12 * matrix4F_1.M22 + matrix4F_0.M13 * matrix4F_1.M32 + matrix4F_0.M14 * matrix4F_1.M42;
		matrix4F_2.M13 = matrix4F_0.M11 * matrix4F_1.M13 + matrix4F_0.M12 * matrix4F_1.M23 + matrix4F_0.M13 * matrix4F_1.M33 + matrix4F_0.M14 * matrix4F_1.M43;
		matrix4F_2.M14 = matrix4F_0.M11 * matrix4F_1.M14 + matrix4F_0.M12 * matrix4F_1.M24 + matrix4F_0.M13 * matrix4F_1.M34 + matrix4F_0.M14 * matrix4F_1.M44;
		matrix4F_2.M21 = matrix4F_0.M21 * matrix4F_1.M11 + matrix4F_0.M22 * matrix4F_1.M21 + matrix4F_0.M23 * matrix4F_1.M31 + matrix4F_0.M24 * matrix4F_1.M41;
		matrix4F_2.M22 = matrix4F_0.M21 * matrix4F_1.M12 + matrix4F_0.M22 * matrix4F_1.M22 + matrix4F_0.M23 * matrix4F_1.M32 + matrix4F_0.M24 * matrix4F_1.M42;
		matrix4F_2.M23 = matrix4F_0.M21 * matrix4F_1.M13 + matrix4F_0.M22 * matrix4F_1.M23 + matrix4F_0.M23 * matrix4F_1.M33 + matrix4F_0.M24 * matrix4F_1.M43;
		matrix4F_2.M24 = matrix4F_0.M21 * matrix4F_1.M14 + matrix4F_0.M22 * matrix4F_1.M24 + matrix4F_0.M23 * matrix4F_1.M34 + matrix4F_0.M24 * matrix4F_1.M44;
		matrix4F_2.M31 = matrix4F_0.M31 * matrix4F_1.M11 + matrix4F_0.M32 * matrix4F_1.M21 + matrix4F_0.M33 * matrix4F_1.M31 + matrix4F_0.M34 * matrix4F_1.M41;
		matrix4F_2.M32 = matrix4F_0.M31 * matrix4F_1.M12 + matrix4F_0.M32 * matrix4F_1.M22 + matrix4F_0.M33 * matrix4F_1.M32 + matrix4F_0.M34 * matrix4F_1.M42;
		matrix4F_2.M33 = matrix4F_0.M31 * matrix4F_1.M13 + matrix4F_0.M32 * matrix4F_1.M23 + matrix4F_0.M33 * matrix4F_1.M33 + matrix4F_0.M34 * matrix4F_1.M43;
		matrix4F_2.M34 = matrix4F_0.M31 * matrix4F_1.M14 + matrix4F_0.M32 * matrix4F_1.M24 + matrix4F_0.M33 * matrix4F_1.M34 + matrix4F_0.M34 * matrix4F_1.M44;
		matrix4F_2.M41 = matrix4F_0.M41 * matrix4F_1.M11 + matrix4F_0.M42 * matrix4F_1.M21 + matrix4F_0.M43 * matrix4F_1.M31 + matrix4F_0.M44 * matrix4F_1.M41;
		matrix4F_2.M42 = matrix4F_0.M41 * matrix4F_1.M12 + matrix4F_0.M42 * matrix4F_1.M22 + matrix4F_0.M43 * matrix4F_1.M32 + matrix4F_0.M44 * matrix4F_1.M42;
		matrix4F_2.M43 = matrix4F_0.M41 * matrix4F_1.M13 + matrix4F_0.M42 * matrix4F_1.M23 + matrix4F_0.M43 * matrix4F_1.M33 + matrix4F_0.M44 * matrix4F_1.M43;
		matrix4F_2.M44 = matrix4F_0.M41 * matrix4F_1.M14 + matrix4F_0.M42 * matrix4F_1.M24 + matrix4F_0.M43 * matrix4F_1.M34 + matrix4F_0.M44 * matrix4F_1.M44;
	}

	public static Vector4F Transform(Matrix4F matrix4F_0, Vector4F vector4F_0)
	{
		return new Vector4F(matrix4F_0.M11 * vector4F_0.X + matrix4F_0.M12 * vector4F_0.Y + matrix4F_0.M13 * vector4F_0.Z + matrix4F_0.M14 * vector4F_0.W, matrix4F_0.M21 * vector4F_0.X + matrix4F_0.M22 * vector4F_0.Y + matrix4F_0.M23 * vector4F_0.Z + matrix4F_0.M24 * vector4F_0.W, matrix4F_0.M31 * vector4F_0.X + matrix4F_0.M32 * vector4F_0.Y + matrix4F_0.M33 * vector4F_0.Z + matrix4F_0.M34 * vector4F_0.W, matrix4F_0.M41 * vector4F_0.X + matrix4F_0.M42 * vector4F_0.Y + matrix4F_0.M43 * vector4F_0.Z + matrix4F_0.M44 * vector4F_0.W);
	}

	public static void Transform(Matrix4F matrix4F_0, Vector4F vector4F_0, ref Vector4F vector4F_1)
	{
		vector4F_1.X = matrix4F_0.M11 * vector4F_0.X + matrix4F_0.M12 * vector4F_0.Y + matrix4F_0.M13 * vector4F_0.Z + matrix4F_0.M14 * vector4F_0.W;
		vector4F_1.Y = matrix4F_0.M21 * vector4F_0.X + matrix4F_0.M22 * vector4F_0.Y + matrix4F_0.M23 * vector4F_0.Z + matrix4F_0.M24 * vector4F_0.W;
		vector4F_1.Z = matrix4F_0.M31 * vector4F_0.X + matrix4F_0.M32 * vector4F_0.Y + matrix4F_0.M33 * vector4F_0.Z + matrix4F_0.M34 * vector4F_0.W;
		vector4F_1.W = matrix4F_0.M41 * vector4F_0.X + matrix4F_0.M42 * vector4F_0.Y + matrix4F_0.M43 * vector4F_0.Z + matrix4F_0.M44 * vector4F_0.W;
	}

	public static Matrix4F Transpose(Matrix4F matrix4F_0)
	{
		Matrix4F result = new Matrix4F(matrix4F_0);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return _m11.GetHashCode() ^ _m12.GetHashCode() ^ _m13.GetHashCode() ^ _m14.GetHashCode() ^ _m21.GetHashCode() ^ _m22.GetHashCode() ^ _m23.GetHashCode() ^ _m24.GetHashCode() ^ _m31.GetHashCode() ^ _m32.GetHashCode() ^ _m33.GetHashCode() ^ _m34.GetHashCode() ^ _m41.GetHashCode() ^ _m42.GetHashCode() ^ _m43.GetHashCode() ^ _m44.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix4F matrix4F)
		{
			if (_m11 == matrix4F.M11 && _m12 == matrix4F.M12 && _m13 == matrix4F.M13 && _m14 == matrix4F.M14 && _m21 == matrix4F.M21 && _m22 == matrix4F.M22 && _m23 == matrix4F.M23 && _m24 == matrix4F.M24 && _m31 == matrix4F.M31 && _m32 == matrix4F.M32 && _m33 == matrix4F.M33 && _m34 == matrix4F.M34 && _m41 == matrix4F.M41 && _m42 == matrix4F.M42 && _m43 == matrix4F.M43)
			{
				return _m44 == matrix4F.M44;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "4x4[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}]", _m11, _m12, _m13, _m14, _m21, _m22, _m23, _m24, _m31, _m32, _m33, _m34, _m41, _m42, _m43, _m44);
	}

	public float GetDeterminant()
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

	public static bool operator ==(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return object.Equals(matrix4F_0, matrix4F_1);
	}

	public static bool operator !=(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return !object.Equals(matrix4F_0, matrix4F_1);
	}

	public static Matrix4F operator +(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return Add(matrix4F_0, matrix4F_1);
	}

	public static Matrix4F operator +(Matrix4F matrix4F_0, float float_0)
	{
		return Add(matrix4F_0, float_0);
	}

	public static Matrix4F operator +(float float_0, Matrix4F matrix4F_0)
	{
		return Add(matrix4F_0, float_0);
	}

	public static Matrix4F operator -(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return Subtract(matrix4F_0, matrix4F_1);
	}

	public static Matrix4F operator -(Matrix4F matrix4F_0, float float_0)
	{
		return Subtract(matrix4F_0, float_0);
	}

	public static Matrix4F operator *(Matrix4F matrix4F_0, Matrix4F matrix4F_1)
	{
		return Multiply(matrix4F_0, matrix4F_1);
	}

	public static Vector4F operator *(Matrix4F matrix4F_0, Vector4F vector4F_0)
	{
		return Transform(matrix4F_0, vector4F_0);
	}

	static Matrix4F()
	{
		Zero = new Matrix4F(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
		Identity = new Matrix4F(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
	}
}
