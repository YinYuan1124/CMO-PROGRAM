using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix2F : ICloneable
{
	private float _m11;

	private float _m12;

	private float _m21;

	private float _m22;

	public static readonly Matrix2F Zero;

	public static readonly Matrix2F Identity;

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

	public float Trace => _m11 + _m22;

	public unsafe float this[int int_0]
	{
		get
		{
			if (int_0 < 0 || int_0 >= 4)
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
			if (int_0 < 0 || int_0 >= 4)
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
			return this[(int_0 - 1) * 2 + (int_1 - 1)];
		}
		set
		{
			this[(int_0 - 1) * 2 + (int_1 - 1)] = value;
		}
	}

	public Matrix2F(float float_0, float float_1, float float_2, float float_3)
	{
		_m11 = float_0;
		_m12 = float_1;
		_m21 = float_2;
		_m22 = float_3;
	}

	public Matrix2F(float[] float_0)
	{
		_m11 = float_0[0];
		_m12 = float_0[1];
		_m21 = float_0[2];
		_m22 = float_0[3];
	}

	public Matrix2F(List<float> list_0)
	{
		_m11 = list_0[0];
		_m12 = list_0[1];
		_m21 = list_0[2];
		_m22 = list_0[3];
	}

	public Matrix2F(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		_m11 = vector2F_0.X;
		_m12 = vector2F_1.X;
		_m21 = vector2F_0.Y;
		_m22 = vector2F_1.Y;
	}

	public Matrix2F(Matrix2F matrix2F_0)
	{
		_m11 = matrix2F_0.M11;
		_m12 = matrix2F_0.M12;
		_m21 = matrix2F_0.M21;
		_m22 = matrix2F_0.M22;
	}

	object ICloneable.Clone()
	{
		return new Matrix2F(this);
	}

	public Matrix2F Clone()
	{
		return new Matrix2F(this);
	}

	public static Matrix2F Parse(string string_0)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix2F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")));
	}

	public static bool TryParse(string string_0, out Matrix2F matrix2F_0)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			matrix2F_0 = new Matrix2F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")));
			return true;
		}
		matrix2F_0 = Zero;
		return false;
	}

	public static Matrix2F Add(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return new Matrix2F(matrix2F_0.M11 + matrix2F_1.M11, matrix2F_0.M12 + matrix2F_1.M12, matrix2F_0.M21 + matrix2F_1.M21, matrix2F_0.M22 + matrix2F_1.M22);
	}

	public static Matrix2F Add(Matrix2F matrix2F_0, float float_0)
	{
		return new Matrix2F(matrix2F_0.M11 + float_0, matrix2F_0.M12 + float_0, matrix2F_0.M21 + float_0, matrix2F_0.M22 + float_0);
	}

	public static void Add(Matrix2F matrix2F_0, Matrix2F matrix2F_1, ref Matrix2F matrix2F_2)
	{
		matrix2F_2.M11 = matrix2F_0.M11 + matrix2F_1.M11;
		matrix2F_2.M12 = matrix2F_0.M12 + matrix2F_1.M12;
		matrix2F_2.M21 = matrix2F_0.M21 + matrix2F_1.M21;
		matrix2F_2.M22 = matrix2F_0.M22 + matrix2F_1.M22;
	}

	public static void Add(Matrix2F matrix2F_0, float float_0, ref Matrix2F matrix2F_1)
	{
		matrix2F_1.M11 = matrix2F_0.M11 + float_0;
		matrix2F_1.M12 = matrix2F_0.M12 + float_0;
		matrix2F_1.M21 = matrix2F_0.M21 + float_0;
		matrix2F_1.M22 = matrix2F_0.M22 + float_0;
	}

	public static Matrix2F Subtract(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return new Matrix2F(matrix2F_0.M11 - matrix2F_1.M11, matrix2F_0.M12 - matrix2F_1.M12, matrix2F_0.M21 - matrix2F_1.M21, matrix2F_0.M22 - matrix2F_1.M22);
	}

	public static Matrix2F Subtract(Matrix2F matrix2F_0, float float_0)
	{
		return new Matrix2F(matrix2F_0.M11 - float_0, matrix2F_0.M12 - float_0, matrix2F_0.M21 - float_0, matrix2F_0.M22 - float_0);
	}

	public static void Subtract(Matrix2F matrix2F_0, Matrix2F matrix2F_1, ref Matrix2F matrix2F_2)
	{
		matrix2F_2.M11 = matrix2F_0.M11 - matrix2F_1.M11;
		matrix2F_2.M12 = matrix2F_0.M12 - matrix2F_1.M12;
		matrix2F_2.M21 = matrix2F_0.M21 - matrix2F_1.M21;
		matrix2F_2.M22 = matrix2F_0.M22 - matrix2F_1.M22;
	}

	public static void Subtract(Matrix2F matrix2F_0, float float_0, ref Matrix2F matrix2F_1)
	{
		matrix2F_1.M11 = matrix2F_0.M11 - float_0;
		matrix2F_1.M12 = matrix2F_0.M12 - float_0;
		matrix2F_1.M21 = matrix2F_0.M21 - float_0;
		matrix2F_1.M22 = matrix2F_0.M22 - float_0;
	}

	public static Matrix2F Multiply(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return new Matrix2F(matrix2F_0.M11 * matrix2F_1.M11 + matrix2F_0.M12 * matrix2F_1.M21, matrix2F_0.M11 * matrix2F_1.M12 + matrix2F_0.M12 * matrix2F_1.M22, matrix2F_0.M21 * matrix2F_1.M11 + matrix2F_0.M22 * matrix2F_1.M21, matrix2F_0.M21 * matrix2F_1.M12 + matrix2F_0.M22 * matrix2F_1.M22);
	}

	public static void Multiply(Matrix2F matrix2F_0, Matrix2F matrix2F_1, ref Matrix2F matrix2F_2)
	{
		matrix2F_2.M11 = matrix2F_0.M11 * matrix2F_1.M11 + matrix2F_0.M12 * matrix2F_1.M21;
		matrix2F_2.M12 = matrix2F_0.M11 * matrix2F_1.M12 + matrix2F_0.M12 * matrix2F_1.M22;
		matrix2F_2.M21 = matrix2F_0.M21 * matrix2F_1.M11 + matrix2F_0.M22 * matrix2F_1.M21;
		matrix2F_2.M22 = matrix2F_0.M21 * matrix2F_1.M12 + matrix2F_0.M22 * matrix2F_1.M22;
	}

	public static Vector2F Transform(Matrix2F matrix2F_0, Vector2F vector2F_0)
	{
		return new Vector2F(matrix2F_0.M11 * vector2F_0.X + matrix2F_0.M12 * vector2F_0.Y, matrix2F_0.M21 * vector2F_0.X + matrix2F_0.M22 * vector2F_0.Y);
	}

	public static void Transform(Matrix2F matrix2F_0, Vector2F vector2F_0, ref Vector2F vector2F_1)
	{
		vector2F_1.X = matrix2F_0.M11 * vector2F_0.X + matrix2F_0.M12 * vector2F_0.Y;
		vector2F_1.Y = matrix2F_0.M21 * vector2F_0.X + matrix2F_0.M22 * vector2F_0.Y;
	}

	public static Matrix2F Transpose(Matrix2F matrix2F_0)
	{
		Matrix2F result = new Matrix2F(matrix2F_0);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return _m11.GetHashCode() ^ _m12.GetHashCode() ^ _m21.GetHashCode() ^ _m22.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix2F matrix2F)
		{
			if (_m11 == matrix2F.M11 && _m12 == matrix2F.M12 && _m21 == matrix2F.M21)
			{
				return _m22 == matrix2F.M22;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "2x2[{0}, {1}, {2}, {3}]", _m11, _m12, _m21, _m22);
	}

	public float GetDeterminant()
	{
		return _m11 * _m22 - _m12 * _m21;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref _m12, ref _m21);
	}

	public static bool operator ==(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return object.Equals(matrix2F_0, matrix2F_1);
	}

	public static bool operator !=(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return !object.Equals(matrix2F_0, matrix2F_1);
	}

	public static Matrix2F operator +(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return Add(matrix2F_0, matrix2F_1);
	}

	public static Matrix2F operator +(Matrix2F matrix2F_0, float float_0)
	{
		return Add(matrix2F_0, float_0);
	}

	public static Matrix2F operator +(float float_0, Matrix2F matrix2F_0)
	{
		return Add(matrix2F_0, float_0);
	}

	public static Matrix2F operator -(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return Subtract(matrix2F_0, matrix2F_1);
	}

	public static Matrix2F operator -(Matrix2F matrix2F_0, float float_0)
	{
		return Subtract(matrix2F_0, float_0);
	}

	public static Matrix2F operator *(Matrix2F matrix2F_0, Matrix2F matrix2F_1)
	{
		return Multiply(matrix2F_0, matrix2F_1);
	}

	public static Vector2F operator *(Matrix2F matrix2F_0, Vector2F vector2F_0)
	{
		return Transform(matrix2F_0, vector2F_0);
	}

	static Matrix2F()
	{
		Zero = new Matrix2F(0f, 0f, 0f, 0f);
		Identity = new Matrix2F(1f, 0f, 0f, 1f);
	}
}
