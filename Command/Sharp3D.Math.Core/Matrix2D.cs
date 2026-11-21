using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix2D : ICloneable
{
	private double _m11;

	private double _m12;

	private double _m21;

	private double _m22;

	public static readonly Matrix2D Zero;

	public static readonly Matrix2D Identity;

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

	public double Trace => _m11 + _m22;

	public unsafe double this[int int_0]
	{
		get
		{
			if (int_0 < 0 || int_0 >= 4)
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
			if (int_0 < 0 || int_0 >= 4)
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
			return this[(int_0 - 1) * 2 + (int_1 - 1)];
		}
		set
		{
			this[(int_0 - 1) * 2 + (int_1 - 1)] = value;
		}
	}

	public Matrix2D(double double_0, double double_1, double double_2, double double_3)
	{
		_m11 = double_0;
		_m12 = double_1;
		_m21 = double_2;
		_m22 = double_3;
	}

	public Matrix2D(double[] double_0)
	{
		_m11 = double_0[0];
		_m12 = double_0[1];
		_m21 = double_0[2];
		_m22 = double_0[3];
	}

	public Matrix2D(List<double> list_0)
	{
		_m11 = list_0[0];
		_m12 = list_0[1];
		_m21 = list_0[2];
		_m22 = list_0[3];
	}

	public Matrix2D(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		_m11 = vector2D_0.X;
		_m12 = vector2D_1.X;
		_m21 = vector2D_0.Y;
		_m22 = vector2D_1.Y;
	}

	public Matrix2D(Matrix2D matrix2D_0)
	{
		_m11 = matrix2D_0.M11;
		_m12 = matrix2D_0.M12;
		_m21 = matrix2D_0.M21;
		_m22 = matrix2D_0.M22;
	}

	object ICloneable.Clone()
	{
		return new Matrix2D(this);
	}

	public Matrix2D Clone()
	{
		return new Matrix2D(this);
	}

	public static Matrix2D Parse(string string_0)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix2D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")));
	}

	public static bool TryParse(string string_0, out Matrix2D matrix2D_0)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			matrix2D_0 = new Matrix2D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")));
			return true;
		}
		matrix2D_0 = Zero;
		return false;
	}

	public static Matrix2D Add(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return new Matrix2D(matrix2D_0.M11 + matrix2D_1.M11, matrix2D_0.M12 + matrix2D_1.M12, matrix2D_0.M21 + matrix2D_1.M21, matrix2D_0.M22 + matrix2D_1.M22);
	}

	public static Matrix2D Add(Matrix2D matrix2D_0, double double_0)
	{
		return new Matrix2D(matrix2D_0.M11 + double_0, matrix2D_0.M12 + double_0, matrix2D_0.M21 + double_0, matrix2D_0.M22 + double_0);
	}

	public static void Add(Matrix2D matrix2D_0, Matrix2D matrix2D_1, ref Matrix2D matrix2D_2)
	{
		matrix2D_2.M11 = matrix2D_0.M11 + matrix2D_1.M11;
		matrix2D_2.M12 = matrix2D_0.M12 + matrix2D_1.M12;
		matrix2D_2.M21 = matrix2D_0.M21 + matrix2D_1.M21;
		matrix2D_2.M22 = matrix2D_0.M22 + matrix2D_1.M22;
	}

	public static void Add(Matrix2D matrix2D_0, double double_0, ref Matrix2D matrix2D_1)
	{
		matrix2D_1.M11 = matrix2D_0.M11 + double_0;
		matrix2D_1.M12 = matrix2D_0.M12 + double_0;
		matrix2D_1.M21 = matrix2D_0.M21 + double_0;
		matrix2D_1.M22 = matrix2D_0.M22 + double_0;
	}

	public static Matrix2D Subtract(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return new Matrix2D(matrix2D_0.M11 - matrix2D_1.M11, matrix2D_0.M12 - matrix2D_1.M12, matrix2D_0.M21 - matrix2D_1.M21, matrix2D_0.M22 - matrix2D_1.M22);
	}

	public static Matrix2D Subtract(Matrix2D matrix2D_0, double double_0)
	{
		return new Matrix2D(matrix2D_0.M11 - double_0, matrix2D_0.M12 - double_0, matrix2D_0.M21 - double_0, matrix2D_0.M22 - double_0);
	}

	public static void Subtract(Matrix2D matrix2D_0, Matrix2D matrix2D_1, ref Matrix2D matrix2D_2)
	{
		matrix2D_2.M11 = matrix2D_0.M11 - matrix2D_1.M11;
		matrix2D_2.M12 = matrix2D_0.M12 - matrix2D_1.M12;
		matrix2D_2.M21 = matrix2D_0.M21 - matrix2D_1.M21;
		matrix2D_2.M22 = matrix2D_0.M22 - matrix2D_1.M22;
	}

	public static void Subtract(Matrix2D matrix2D_0, double double_0, ref Matrix2D matrix2D_1)
	{
		matrix2D_1.M11 = matrix2D_0.M11 - double_0;
		matrix2D_1.M12 = matrix2D_0.M12 - double_0;
		matrix2D_1.M21 = matrix2D_0.M21 - double_0;
		matrix2D_1.M22 = matrix2D_0.M22 - double_0;
	}

	public static Matrix2D Multiply(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return new Matrix2D(matrix2D_0.M11 * matrix2D_1.M11 + matrix2D_0.M12 * matrix2D_1.M21, matrix2D_0.M11 * matrix2D_1.M12 + matrix2D_0.M12 * matrix2D_1.M22, matrix2D_0.M21 * matrix2D_1.M11 + matrix2D_0.M22 * matrix2D_1.M21, matrix2D_0.M21 * matrix2D_1.M12 + matrix2D_0.M22 * matrix2D_1.M22);
	}

	public static void Multiply(Matrix2D matrix2D_0, Matrix2D matrix2D_1, ref Matrix2D matrix2D_2)
	{
		matrix2D_2.M11 = matrix2D_0.M11 * matrix2D_1.M11 + matrix2D_0.M12 * matrix2D_1.M21;
		matrix2D_2.M12 = matrix2D_0.M11 * matrix2D_1.M12 + matrix2D_0.M12 * matrix2D_1.M22;
		matrix2D_2.M21 = matrix2D_0.M21 * matrix2D_1.M11 + matrix2D_0.M22 * matrix2D_1.M21;
		matrix2D_2.M22 = matrix2D_0.M21 * matrix2D_1.M12 + matrix2D_0.M22 * matrix2D_1.M22;
	}

	public static Vector2D Transform(Matrix2D matrix2D_0, Vector2D vector2D_0)
	{
		return new Vector2D(matrix2D_0.M11 * vector2D_0.X + matrix2D_0.M12 * vector2D_0.Y, matrix2D_0.M21 * vector2D_0.X + matrix2D_0.M22 * vector2D_0.Y);
	}

	public static void Transform(Matrix2D matrix2D_0, Vector2D vector2D_0, ref Vector2D vector2D_1)
	{
		vector2D_1.X = matrix2D_0.M11 * vector2D_0.X + matrix2D_0.M12 * vector2D_0.Y;
		vector2D_1.Y = matrix2D_0.M21 * vector2D_0.X + matrix2D_0.M22 * vector2D_0.Y;
	}

	public static Matrix2D Transpose(Matrix2D matrix2D_0)
	{
		Matrix2D result = new Matrix2D(matrix2D_0);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return _m11.GetHashCode() ^ _m12.GetHashCode() ^ _m21.GetHashCode() ^ _m22.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix2D matrix2D)
		{
			if (_m11 == matrix2D.M11 && _m12 == matrix2D.M12 && _m21 == matrix2D.M21)
			{
				return _m22 == matrix2D.M22;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "2x2[{0}, {1}, {2}, {3}]", _m11, _m12, _m21, _m22);
	}

	public double GetDeterminant()
	{
		return _m11 * _m22 - _m12 * _m21;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref _m12, ref _m21);
	}

	public static bool operator ==(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return object.Equals(matrix2D_0, matrix2D_1);
	}

	public static bool operator !=(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return !object.Equals(matrix2D_0, matrix2D_1);
	}

	public static Matrix2D operator +(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return Add(matrix2D_0, matrix2D_1);
	}

	public static Matrix2D operator +(Matrix2D matrix2D_0, double double_0)
	{
		return Add(matrix2D_0, double_0);
	}

	public static Matrix2D operator +(double double_0, Matrix2D matrix2D_0)
	{
		return Add(matrix2D_0, double_0);
	}

	public static Matrix2D operator -(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return Subtract(matrix2D_0, matrix2D_1);
	}

	public static Matrix2D operator -(Matrix2D matrix2D_0, double double_0)
	{
		return Subtract(matrix2D_0, double_0);
	}

	public static Matrix2D operator *(Matrix2D matrix2D_0, Matrix2D matrix2D_1)
	{
		return Multiply(matrix2D_0, matrix2D_1);
	}

	public static Vector2D operator *(Matrix2D matrix2D_0, Vector2D vector2D_0)
	{
		return Transform(matrix2D_0, vector2D_0);
	}

	static Matrix2D()
	{
		Zero = new Matrix2D(0.0, 0.0, 0.0, 0.0);
		Identity = new Matrix2D(1.0, 0.0, 0.0, 1.0);
	}
}
