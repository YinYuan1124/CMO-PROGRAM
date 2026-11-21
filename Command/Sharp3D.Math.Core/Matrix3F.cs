using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix3F : ICloneable
{
	private float _m11;

	private float _m12;

	private float _m13;

	private float _m21;

	private float _m22;

	private float _m23;

	private float _m31;

	private float _m32;

	private float _m33;

	public static readonly Matrix3F Zero;

	public static readonly Matrix3F Identity;

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

	public float Trace => _m11 + _m22 + _m33;

	public unsafe float this[int int_0]
	{
		get
		{
			if (int_0 < 0 || int_0 >= 9)
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
			if (int_0 < 0 || int_0 >= 9)
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
			return this[(int_0 - 1) * 3 + (int_1 - 1)];
		}
		set
		{
			this[(int_0 - 1) * 3 + (int_1 - 1)] = value;
		}
	}

	public Matrix3F(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
	{
		_m11 = float_0;
		_m12 = float_1;
		_m13 = float_2;
		_m21 = float_3;
		_m22 = float_4;
		_m23 = float_5;
		_m31 = float_6;
		_m32 = float_7;
		_m33 = float_8;
	}

	public Matrix3F(float[] float_0)
	{
		_m11 = float_0[0];
		_m12 = float_0[1];
		_m13 = float_0[2];
		_m21 = float_0[3];
		_m22 = float_0[4];
		_m23 = float_0[5];
		_m31 = float_0[6];
		_m32 = float_0[7];
		_m33 = float_0[8];
	}

	public Matrix3F(List<float> list_0)
	{
		_m11 = list_0[0];
		_m12 = list_0[1];
		_m13 = list_0[2];
		_m21 = list_0[3];
		_m22 = list_0[4];
		_m23 = list_0[5];
		_m31 = list_0[6];
		_m32 = list_0[7];
		_m33 = list_0[8];
	}

	public Matrix3F(Vector3F vector3F_0, Vector3F vector3F_1, Vector3F vector3F_2)
	{
		_m11 = vector3F_0.X;
		_m12 = vector3F_1.X;
		_m13 = vector3F_2.X;
		_m21 = vector3F_0.Y;
		_m22 = vector3F_1.Y;
		_m23 = vector3F_2.Y;
		_m31 = vector3F_0.Z;
		_m32 = vector3F_1.Z;
		_m33 = vector3F_2.Z;
	}

	public Matrix3F(Matrix3F matrix3F_0)
	{
		_m11 = matrix3F_0.M11;
		_m12 = matrix3F_0.M12;
		_m13 = matrix3F_0.M13;
		_m21 = matrix3F_0.M21;
		_m22 = matrix3F_0.M22;
		_m23 = matrix3F_0.M23;
		_m31 = matrix3F_0.M31;
		_m32 = matrix3F_0.M32;
		_m33 = matrix3F_0.M33;
	}

	object ICloneable.Clone()
	{
		return new Matrix3F(this);
	}

	public Matrix3F Clone()
	{
		return new Matrix3F(this);
	}

	public static Matrix3F Parse(string string_0)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix3F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")));
	}

	public static bool TryParse(string string_0, out Matrix3F matrix3F_0)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			matrix3F_0 = new Matrix3F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")));
			return true;
		}
		matrix3F_0 = Zero;
		return false;
	}

	public static Matrix3F Add(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return new Matrix3F(matrix3F_0.M11 + matrix3F_1.M11, matrix3F_0.M12 + matrix3F_1.M12, matrix3F_0.M13 + matrix3F_1.M13, matrix3F_0.M21 + matrix3F_1.M21, matrix3F_0.M22 + matrix3F_1.M22, matrix3F_0.M23 + matrix3F_1.M23, matrix3F_0.M31 + matrix3F_1.M31, matrix3F_0.M32 + matrix3F_1.M32, matrix3F_0.M33 + matrix3F_1.M33);
	}

	public static Matrix3F Add(Matrix3F matrix3F_0, float float_0)
	{
		return new Matrix3F(matrix3F_0.M11 + float_0, matrix3F_0.M12 + float_0, matrix3F_0.M13 + float_0, matrix3F_0.M21 + float_0, matrix3F_0.M22 + float_0, matrix3F_0.M23 + float_0, matrix3F_0.M31 + float_0, matrix3F_0.M32 + float_0, matrix3F_0.M33 + float_0);
	}

	public static void Add(Matrix3F matrix3F_0, Matrix3F matrix3F_1, ref Matrix3F matrix3F_2)
	{
		matrix3F_2.M11 = matrix3F_0.M11 + matrix3F_1.M11;
		matrix3F_2.M12 = matrix3F_0.M12 + matrix3F_1.M12;
		matrix3F_2.M13 = matrix3F_0.M13 + matrix3F_1.M13;
		matrix3F_2.M21 = matrix3F_0.M21 + matrix3F_1.M21;
		matrix3F_2.M22 = matrix3F_0.M22 + matrix3F_1.M22;
		matrix3F_2.M23 = matrix3F_0.M23 + matrix3F_1.M23;
		matrix3F_2.M31 = matrix3F_0.M31 + matrix3F_1.M31;
		matrix3F_2.M32 = matrix3F_0.M32 + matrix3F_1.M32;
		matrix3F_2.M33 = matrix3F_0.M33 + matrix3F_1.M33;
	}

	public static void Add(Matrix3F matrix3F_0, float float_0, ref Matrix3F matrix3F_1)
	{
		matrix3F_1.M11 = matrix3F_0.M11 + float_0;
		matrix3F_1.M12 = matrix3F_0.M12 + float_0;
		matrix3F_1.M13 = matrix3F_0.M13 + float_0;
		matrix3F_1.M21 = matrix3F_0.M21 + float_0;
		matrix3F_1.M22 = matrix3F_0.M22 + float_0;
		matrix3F_1.M23 = matrix3F_0.M23 + float_0;
		matrix3F_1.M31 = matrix3F_0.M31 + float_0;
		matrix3F_1.M32 = matrix3F_0.M32 + float_0;
		matrix3F_1.M33 = matrix3F_0.M33 + float_0;
	}

	public static Matrix3F Subtract(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return new Matrix3F(matrix3F_0.M11 - matrix3F_1.M11, matrix3F_0.M12 - matrix3F_1.M12, matrix3F_0.M13 - matrix3F_1.M13, matrix3F_0.M21 - matrix3F_1.M21, matrix3F_0.M22 - matrix3F_1.M22, matrix3F_0.M23 - matrix3F_1.M23, matrix3F_0.M31 - matrix3F_1.M31, matrix3F_0.M32 - matrix3F_1.M32, matrix3F_0.M33 - matrix3F_1.M33);
	}

	public static Matrix3F Subtract(Matrix3F matrix3F_0, float float_0)
	{
		return new Matrix3F(matrix3F_0.M11 - float_0, matrix3F_0.M12 - float_0, matrix3F_0.M13 - float_0, matrix3F_0.M21 - float_0, matrix3F_0.M22 - float_0, matrix3F_0.M23 - float_0, matrix3F_0.M31 - float_0, matrix3F_0.M32 - float_0, matrix3F_0.M33 - float_0);
	}

	public static void Subtract(Matrix3F matrix3F_0, Matrix3F matrix3F_1, ref Matrix3F matrix3F_2)
	{
		matrix3F_2.M11 = matrix3F_0.M11 - matrix3F_1.M11;
		matrix3F_2.M12 = matrix3F_0.M12 - matrix3F_1.M12;
		matrix3F_2.M13 = matrix3F_0.M13 - matrix3F_1.M13;
		matrix3F_2.M21 = matrix3F_0.M21 - matrix3F_1.M21;
		matrix3F_2.M22 = matrix3F_0.M22 - matrix3F_1.M22;
		matrix3F_2.M23 = matrix3F_0.M23 - matrix3F_1.M23;
		matrix3F_2.M31 = matrix3F_0.M31 - matrix3F_1.M31;
		matrix3F_2.M32 = matrix3F_0.M32 - matrix3F_1.M32;
		matrix3F_2.M33 = matrix3F_0.M33 - matrix3F_1.M33;
	}

	public static void Subtract(Matrix3F matrix3F_0, float float_0, ref Matrix3F matrix3F_1)
	{
		matrix3F_1.M11 = matrix3F_0.M11 - float_0;
		matrix3F_1.M12 = matrix3F_0.M12 - float_0;
		matrix3F_1.M13 = matrix3F_0.M13 - float_0;
		matrix3F_1.M21 = matrix3F_0.M21 - float_0;
		matrix3F_1.M22 = matrix3F_0.M22 - float_0;
		matrix3F_1.M23 = matrix3F_0.M23 - float_0;
		matrix3F_1.M31 = matrix3F_0.M31 - float_0;
		matrix3F_1.M32 = matrix3F_0.M32 - float_0;
		matrix3F_1.M33 = matrix3F_0.M33 - float_0;
	}

	public static Matrix3F Multiply(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return new Matrix3F(matrix3F_0.M11 * matrix3F_1.M11 + matrix3F_0.M12 * matrix3F_1.M21 + matrix3F_0.M13 * matrix3F_1.M31, matrix3F_0.M11 * matrix3F_1.M12 + matrix3F_0.M12 * matrix3F_1.M22 + matrix3F_0.M13 * matrix3F_1.M32, matrix3F_0.M11 * matrix3F_1.M13 + matrix3F_0.M12 * matrix3F_1.M23 + matrix3F_0.M13 * matrix3F_1.M33, matrix3F_0.M21 * matrix3F_1.M11 + matrix3F_0.M22 * matrix3F_1.M21 + matrix3F_0.M23 * matrix3F_1.M31, matrix3F_0.M21 * matrix3F_1.M12 + matrix3F_0.M22 * matrix3F_1.M22 + matrix3F_0.M23 * matrix3F_1.M32, matrix3F_0.M21 * matrix3F_1.M13 + matrix3F_0.M22 * matrix3F_1.M23 + matrix3F_0.M23 * matrix3F_1.M33, matrix3F_0.M31 * matrix3F_1.M11 + matrix3F_0.M32 * matrix3F_1.M21 + matrix3F_0.M33 * matrix3F_1.M31, matrix3F_0.M31 * matrix3F_1.M12 + matrix3F_0.M32 * matrix3F_1.M22 + matrix3F_0.M33 * matrix3F_1.M32, matrix3F_0.M31 * matrix3F_1.M13 + matrix3F_0.M32 * matrix3F_1.M23 + matrix3F_0.M33 * matrix3F_1.M33);
	}

	public static void Multiply(Matrix3F matrix3F_0, Matrix3F matrix3F_1, ref Matrix3F matrix3F_2)
	{
		matrix3F_2.M11 = matrix3F_0.M11 * matrix3F_1.M11 + matrix3F_0.M12 * matrix3F_1.M21 + matrix3F_0.M13 * matrix3F_1.M31;
		matrix3F_2.M12 = matrix3F_0.M11 * matrix3F_1.M12 + matrix3F_0.M12 * matrix3F_1.M22 + matrix3F_0.M13 * matrix3F_1.M32;
		matrix3F_2.M13 = matrix3F_0.M11 * matrix3F_1.M13 + matrix3F_0.M12 * matrix3F_1.M23 + matrix3F_0.M13 * matrix3F_1.M33;
		matrix3F_2.M21 = matrix3F_0.M21 * matrix3F_1.M11 + matrix3F_0.M22 * matrix3F_1.M21 + matrix3F_0.M23 * matrix3F_1.M31;
		matrix3F_2.M22 = matrix3F_0.M21 * matrix3F_1.M12 + matrix3F_0.M22 * matrix3F_1.M22 + matrix3F_0.M23 * matrix3F_1.M32;
		matrix3F_2.M23 = matrix3F_0.M21 * matrix3F_1.M13 + matrix3F_0.M22 * matrix3F_1.M23 + matrix3F_0.M23 * matrix3F_1.M33;
		matrix3F_2.M31 = matrix3F_0.M31 * matrix3F_1.M11 + matrix3F_0.M32 * matrix3F_1.M21 + matrix3F_0.M33 * matrix3F_1.M31;
		matrix3F_2.M32 = matrix3F_0.M31 * matrix3F_1.M12 + matrix3F_0.M32 * matrix3F_1.M22 + matrix3F_0.M33 * matrix3F_1.M32;
		matrix3F_2.M33 = matrix3F_0.M31 * matrix3F_1.M13 + matrix3F_0.M32 * matrix3F_1.M23 + matrix3F_0.M33 * matrix3F_1.M33;
	}

	public static Vector3F Transform(Matrix3F matrix3F_0, Vector3F vector3F_0)
	{
		return new Vector3F(matrix3F_0.M11 * vector3F_0.X + matrix3F_0.M12 * vector3F_0.Y + matrix3F_0.M13 * vector3F_0.Z, matrix3F_0.M21 * vector3F_0.X + matrix3F_0.M22 * vector3F_0.Y + matrix3F_0.M23 * vector3F_0.Z, matrix3F_0.M31 * vector3F_0.X + matrix3F_0.M32 * vector3F_0.Y + matrix3F_0.M33 * vector3F_0.Z);
	}

	public static void Transform(Matrix3F matrix3F_0, Vector3F vector3F_0, ref Vector3F vector3F_1)
	{
		vector3F_1.X = matrix3F_0.M11 * vector3F_0.X + matrix3F_0.M12 * vector3F_0.Y + matrix3F_0.M13 * vector3F_0.Z;
		vector3F_1.Y = matrix3F_0.M21 * vector3F_0.X + matrix3F_0.M22 * vector3F_0.Y + matrix3F_0.M23 * vector3F_0.Z;
		vector3F_1.Z = matrix3F_0.M31 * vector3F_0.X + matrix3F_0.M32 * vector3F_0.Y + matrix3F_0.M33 * vector3F_0.Z;
	}

	public static Matrix3F Transpose(Matrix3F matrix3F_0)
	{
		Matrix3F result = new Matrix3F(matrix3F_0);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return _m11.GetHashCode() ^ _m12.GetHashCode() ^ _m13.GetHashCode() ^ _m21.GetHashCode() ^ _m22.GetHashCode() ^ _m23.GetHashCode() ^ _m31.GetHashCode() ^ _m32.GetHashCode() ^ _m33.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix3F matrix3F)
		{
			if (_m11 == matrix3F.M11 && _m12 == matrix3F.M12 && _m13 == matrix3F.M13 && _m21 == matrix3F.M21 && _m22 == matrix3F.M22 && _m23 == matrix3F.M23 && _m31 == matrix3F.M31 && _m32 == matrix3F.M32)
			{
				return _m33 == matrix3F.M33;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "3x3[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}]", _m11, _m12, _m13, _m21, _m22, _m23, _m31, _m32, _m33);
	}

	public float GetDeterminant()
	{
		return _m11 * _m22 * _m33 + _m12 * _m23 * _m31 + _m13 * _m21 * _m32 - _m13 * _m22 * _m31 - _m11 * _m23 * _m32 - _m12 * _m21 * _m33;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref _m12, ref _m21);
		MathFunctions.Swap(ref _m13, ref _m31);
		MathFunctions.Swap(ref _m23, ref _m32);
	}

	public static bool operator ==(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return object.Equals(matrix3F_0, matrix3F_1);
	}

	public static bool operator !=(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return !object.Equals(matrix3F_0, matrix3F_1);
	}

	public static Matrix3F operator +(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return Add(matrix3F_0, matrix3F_1);
	}

	public static Matrix3F operator +(Matrix3F matrix3F_0, float float_0)
	{
		return Add(matrix3F_0, float_0);
	}

	public static Matrix3F operator +(float float_0, Matrix3F matrix3F_0)
	{
		return Add(matrix3F_0, float_0);
	}

	public static Matrix3F operator -(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return Subtract(matrix3F_0, matrix3F_1);
	}

	public static Matrix3F operator -(Matrix3F matrix3F_0, float float_0)
	{
		return Subtract(matrix3F_0, float_0);
	}

	public static Matrix3F operator *(Matrix3F matrix3F_0, Matrix3F matrix3F_1)
	{
		return Multiply(matrix3F_0, matrix3F_1);
	}

	public static Vector3F operator *(Matrix3F matrix3F_0, Vector3F vector3F_0)
	{
		return Transform(matrix3F_0, vector3F_0);
	}

	static Matrix3F()
	{
		Zero = new Matrix3F(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
		Identity = new Matrix3F(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);
	}
}
