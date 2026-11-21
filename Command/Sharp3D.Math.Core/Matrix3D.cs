using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix3D : ICloneable
{
	private double _m11;

	private double _m12;

	private double _m13;

	private double _m21;

	private double _m22;

	private double _m23;

	private double _m31;

	private double _m32;

	private double _m33;

	public static readonly Matrix3D Zero;

	public static readonly Matrix3D Identity;

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

	public double Trace => _m11 + _m22 + _m33;

	public unsafe double this[int int_0]
	{
		get
		{
			if (int_0 < 0 || int_0 >= 9)
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
			if (int_0 < 0 || int_0 >= 9)
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
			return this[(int_0 - 1) * 3 + (int_1 - 1)];
		}
		set
		{
			this[(int_0 - 1) * 3 + (int_1 - 1)] = value;
		}
	}

	public Matrix3D(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8)
	{
		_m11 = double_0;
		_m12 = double_1;
		_m13 = double_2;
		_m21 = double_3;
		_m22 = double_4;
		_m23 = double_5;
		_m31 = double_6;
		_m32 = double_7;
		_m33 = double_8;
	}

	public Matrix3D(double[] double_0)
	{
		_m11 = double_0[0];
		_m12 = double_0[1];
		_m13 = double_0[2];
		_m21 = double_0[3];
		_m22 = double_0[4];
		_m23 = double_0[5];
		_m31 = double_0[6];
		_m32 = double_0[7];
		_m33 = double_0[8];
	}

	public Matrix3D(List<double> list_0)
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

	public Matrix3D(Vector3D vector3D_0, Vector3D vector3D_1, Vector3D vector3D_2)
	{
		_m11 = vector3D_0.X;
		_m12 = vector3D_1.X;
		_m13 = vector3D_2.X;
		_m21 = vector3D_0.Y;
		_m22 = vector3D_1.Y;
		_m23 = vector3D_2.Y;
		_m31 = vector3D_0.Z;
		_m32 = vector3D_1.Z;
		_m33 = vector3D_2.Z;
	}

	public Matrix3D(Matrix3D matrix3D_0)
	{
		_m11 = matrix3D_0.M11;
		_m12 = matrix3D_0.M12;
		_m13 = matrix3D_0.M13;
		_m21 = matrix3D_0.M21;
		_m22 = matrix3D_0.M22;
		_m23 = matrix3D_0.M23;
		_m31 = matrix3D_0.M31;
		_m32 = matrix3D_0.M32;
		_m33 = matrix3D_0.M33;
	}

	object ICloneable.Clone()
	{
		return new Matrix3D(this);
	}

	public Matrix3D Clone()
	{
		return new Matrix3D(this);
	}

	public static Matrix3D Parse(string string_0)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix3D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")));
	}

	public static bool TryParse(string string_0, out Matrix3D matrix3D_0)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			matrix3D_0 = new Matrix3D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")));
			return true;
		}
		matrix3D_0 = Zero;
		return false;
	}

	public static Matrix3D Add(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return new Matrix3D(matrix3D_0.M11 + matrix3D_1.M11, matrix3D_0.M12 + matrix3D_1.M12, matrix3D_0.M13 + matrix3D_1.M13, matrix3D_0.M21 + matrix3D_1.M21, matrix3D_0.M22 + matrix3D_1.M22, matrix3D_0.M23 + matrix3D_1.M23, matrix3D_0.M31 + matrix3D_1.M31, matrix3D_0.M32 + matrix3D_1.M32, matrix3D_0.M33 + matrix3D_1.M33);
	}

	public static Matrix3D Add(Matrix3D matrix3D_0, double double_0)
	{
		return new Matrix3D(matrix3D_0.M11 + double_0, matrix3D_0.M12 + double_0, matrix3D_0.M13 + double_0, matrix3D_0.M21 + double_0, matrix3D_0.M22 + double_0, matrix3D_0.M23 + double_0, matrix3D_0.M31 + double_0, matrix3D_0.M32 + double_0, matrix3D_0.M33 + double_0);
	}

	public static void Add(Matrix3D matrix3D_0, Matrix3D matrix3D_1, ref Matrix3D matrix3D_2)
	{
		matrix3D_2.M11 = matrix3D_0.M11 + matrix3D_1.M11;
		matrix3D_2.M12 = matrix3D_0.M12 + matrix3D_1.M12;
		matrix3D_2.M13 = matrix3D_0.M13 + matrix3D_1.M13;
		matrix3D_2.M21 = matrix3D_0.M21 + matrix3D_1.M21;
		matrix3D_2.M22 = matrix3D_0.M22 + matrix3D_1.M22;
		matrix3D_2.M23 = matrix3D_0.M23 + matrix3D_1.M23;
		matrix3D_2.M31 = matrix3D_0.M31 + matrix3D_1.M31;
		matrix3D_2.M32 = matrix3D_0.M32 + matrix3D_1.M32;
		matrix3D_2.M33 = matrix3D_0.M33 + matrix3D_1.M33;
	}

	public static void Add(Matrix3D matrix3D_0, double double_0, ref Matrix3D matrix3D_1)
	{
		matrix3D_1.M11 = matrix3D_0.M11 + double_0;
		matrix3D_1.M12 = matrix3D_0.M12 + double_0;
		matrix3D_1.M13 = matrix3D_0.M13 + double_0;
		matrix3D_1.M21 = matrix3D_0.M21 + double_0;
		matrix3D_1.M22 = matrix3D_0.M22 + double_0;
		matrix3D_1.M23 = matrix3D_0.M23 + double_0;
		matrix3D_1.M31 = matrix3D_0.M31 + double_0;
		matrix3D_1.M32 = matrix3D_0.M32 + double_0;
		matrix3D_1.M33 = matrix3D_0.M33 + double_0;
	}

	public static Matrix3D Subtract(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return new Matrix3D(matrix3D_0.M11 - matrix3D_1.M11, matrix3D_0.M12 - matrix3D_1.M12, matrix3D_0.M13 - matrix3D_1.M13, matrix3D_0.M21 - matrix3D_1.M21, matrix3D_0.M22 - matrix3D_1.M22, matrix3D_0.M23 - matrix3D_1.M23, matrix3D_0.M31 - matrix3D_1.M31, matrix3D_0.M32 - matrix3D_1.M32, matrix3D_0.M33 - matrix3D_1.M33);
	}

	public static Matrix3D Subtract(Matrix3D matrix3D_0, double double_0)
	{
		return new Matrix3D(matrix3D_0.M11 - double_0, matrix3D_0.M12 - double_0, matrix3D_0.M13 - double_0, matrix3D_0.M21 - double_0, matrix3D_0.M22 - double_0, matrix3D_0.M23 - double_0, matrix3D_0.M31 - double_0, matrix3D_0.M32 - double_0, matrix3D_0.M33 - double_0);
	}

	public static void Subtract(Matrix3D matrix3D_0, Matrix3D matrix3D_1, ref Matrix3D matrix3D_2)
	{
		matrix3D_2.M11 = matrix3D_0.M11 - matrix3D_1.M11;
		matrix3D_2.M12 = matrix3D_0.M12 - matrix3D_1.M12;
		matrix3D_2.M13 = matrix3D_0.M13 - matrix3D_1.M13;
		matrix3D_2.M21 = matrix3D_0.M21 - matrix3D_1.M21;
		matrix3D_2.M22 = matrix3D_0.M22 - matrix3D_1.M22;
		matrix3D_2.M23 = matrix3D_0.M23 - matrix3D_1.M23;
		matrix3D_2.M31 = matrix3D_0.M31 - matrix3D_1.M31;
		matrix3D_2.M32 = matrix3D_0.M32 - matrix3D_1.M32;
		matrix3D_2.M33 = matrix3D_0.M33 - matrix3D_1.M33;
	}

	public static void Subtract(Matrix3D matrix3D_0, double double_0, ref Matrix3D matrix3D_1)
	{
		matrix3D_1.M11 = matrix3D_0.M11 - double_0;
		matrix3D_1.M12 = matrix3D_0.M12 - double_0;
		matrix3D_1.M13 = matrix3D_0.M13 - double_0;
		matrix3D_1.M21 = matrix3D_0.M21 - double_0;
		matrix3D_1.M22 = matrix3D_0.M22 - double_0;
		matrix3D_1.M23 = matrix3D_0.M23 - double_0;
		matrix3D_1.M31 = matrix3D_0.M31 - double_0;
		matrix3D_1.M32 = matrix3D_0.M32 - double_0;
		matrix3D_1.M33 = matrix3D_0.M33 - double_0;
	}

	public static Matrix3D Multiply(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return new Matrix3D(matrix3D_0.M11 * matrix3D_1.M11 + matrix3D_0.M12 * matrix3D_1.M21 + matrix3D_0.M13 * matrix3D_1.M31, matrix3D_0.M11 * matrix3D_1.M12 + matrix3D_0.M12 * matrix3D_1.M22 + matrix3D_0.M13 * matrix3D_1.M32, matrix3D_0.M11 * matrix3D_1.M13 + matrix3D_0.M12 * matrix3D_1.M23 + matrix3D_0.M13 * matrix3D_1.M33, matrix3D_0.M21 * matrix3D_1.M11 + matrix3D_0.M22 * matrix3D_1.M21 + matrix3D_0.M23 * matrix3D_1.M31, matrix3D_0.M21 * matrix3D_1.M12 + matrix3D_0.M22 * matrix3D_1.M22 + matrix3D_0.M23 * matrix3D_1.M32, matrix3D_0.M21 * matrix3D_1.M13 + matrix3D_0.M22 * matrix3D_1.M23 + matrix3D_0.M23 * matrix3D_1.M33, matrix3D_0.M31 * matrix3D_1.M11 + matrix3D_0.M32 * matrix3D_1.M21 + matrix3D_0.M33 * matrix3D_1.M31, matrix3D_0.M31 * matrix3D_1.M12 + matrix3D_0.M32 * matrix3D_1.M22 + matrix3D_0.M33 * matrix3D_1.M32, matrix3D_0.M31 * matrix3D_1.M13 + matrix3D_0.M32 * matrix3D_1.M23 + matrix3D_0.M33 * matrix3D_1.M33);
	}

	public static void Multiply(Matrix3D matrix3D_0, Matrix3D matrix3D_1, ref Matrix3D matrix3D_2)
	{
		matrix3D_2.M11 = matrix3D_0.M11 * matrix3D_1.M11 + matrix3D_0.M12 * matrix3D_1.M21 + matrix3D_0.M13 * matrix3D_1.M31;
		matrix3D_2.M12 = matrix3D_0.M11 * matrix3D_1.M12 + matrix3D_0.M12 * matrix3D_1.M22 + matrix3D_0.M13 * matrix3D_1.M32;
		matrix3D_2.M13 = matrix3D_0.M11 * matrix3D_1.M13 + matrix3D_0.M12 * matrix3D_1.M23 + matrix3D_0.M13 * matrix3D_1.M33;
		matrix3D_2.M21 = matrix3D_0.M21 * matrix3D_1.M11 + matrix3D_0.M22 * matrix3D_1.M21 + matrix3D_0.M23 * matrix3D_1.M31;
		matrix3D_2.M22 = matrix3D_0.M21 * matrix3D_1.M12 + matrix3D_0.M22 * matrix3D_1.M22 + matrix3D_0.M23 * matrix3D_1.M32;
		matrix3D_2.M23 = matrix3D_0.M21 * matrix3D_1.M13 + matrix3D_0.M22 * matrix3D_1.M23 + matrix3D_0.M23 * matrix3D_1.M33;
		matrix3D_2.M31 = matrix3D_0.M31 * matrix3D_1.M11 + matrix3D_0.M32 * matrix3D_1.M21 + matrix3D_0.M33 * matrix3D_1.M31;
		matrix3D_2.M32 = matrix3D_0.M31 * matrix3D_1.M12 + matrix3D_0.M32 * matrix3D_1.M22 + matrix3D_0.M33 * matrix3D_1.M32;
		matrix3D_2.M33 = matrix3D_0.M31 * matrix3D_1.M13 + matrix3D_0.M32 * matrix3D_1.M23 + matrix3D_0.M33 * matrix3D_1.M33;
	}

	public static Vector3D Transform(Matrix3D matrix3D_0, Vector3D vector3D_0)
	{
		return new Vector3D(matrix3D_0.M11 * vector3D_0.X + matrix3D_0.M12 * vector3D_0.Y + matrix3D_0.M13 * vector3D_0.Z, matrix3D_0.M21 * vector3D_0.X + matrix3D_0.M22 * vector3D_0.Y + matrix3D_0.M23 * vector3D_0.Z, matrix3D_0.M31 * vector3D_0.X + matrix3D_0.M32 * vector3D_0.Y + matrix3D_0.M33 * vector3D_0.Z);
	}

	public static void Transform(Matrix3D matrix3D_0, Vector3D vector3D_0, ref Vector3D vector3D_1)
	{
		vector3D_1.X = matrix3D_0.M11 * vector3D_0.X + matrix3D_0.M12 * vector3D_0.Y + matrix3D_0.M13 * vector3D_0.Z;
		vector3D_1.Y = matrix3D_0.M21 * vector3D_0.X + matrix3D_0.M22 * vector3D_0.Y + matrix3D_0.M23 * vector3D_0.Z;
		vector3D_1.Z = matrix3D_0.M31 * vector3D_0.X + matrix3D_0.M32 * vector3D_0.Y + matrix3D_0.M33 * vector3D_0.Z;
	}

	public static Matrix3D Transpose(Matrix3D matrix3D_0)
	{
		Matrix3D result = new Matrix3D(matrix3D_0);
		result.Transpose();
		return result;
	}

	public static Matrix3D Inverse(Matrix3D matrix3D_0)
	{
		double num = 1.0 / matrix3D_0.GetDeterminant();
		return new Matrix3D(num * (matrix3D_0._m33 * matrix3D_0._m22 - matrix3D_0._m32 * matrix3D_0._m23), (0.0 - num) * (matrix3D_0._m33 * matrix3D_0._m12 - matrix3D_0._m32 * matrix3D_0._m13), num * (matrix3D_0._m23 * matrix3D_0._m12 - matrix3D_0._m22 * matrix3D_0._m13), (0.0 - num) * (matrix3D_0._m33 * matrix3D_0._m21 - matrix3D_0._m31 * matrix3D_0._m23), num * (matrix3D_0._m33 * matrix3D_0._m11 - matrix3D_0._m31 * matrix3D_0._m13), (0.0 - num) * (matrix3D_0._m23 * matrix3D_0._m11 - matrix3D_0._m21 * matrix3D_0._m13), num * (matrix3D_0._m32 * matrix3D_0._m21 - matrix3D_0._m31 * matrix3D_0._m22), (0.0 - num) * (matrix3D_0._m32 * matrix3D_0._m11 - matrix3D_0._m31 * matrix3D_0._m12), num * (matrix3D_0._m22 * matrix3D_0._m11 - matrix3D_0._m21 * matrix3D_0._m12));
	}

	public override int GetHashCode()
	{
		return _m11.GetHashCode() ^ _m12.GetHashCode() ^ _m13.GetHashCode() ^ _m21.GetHashCode() ^ _m22.GetHashCode() ^ _m23.GetHashCode() ^ _m31.GetHashCode() ^ _m32.GetHashCode() ^ _m33.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix3D matrix3D)
		{
			if (_m11 == matrix3D.M11 && _m12 == matrix3D.M12 && _m13 == matrix3D.M13 && _m21 == matrix3D.M21 && _m22 == matrix3D.M22 && _m23 == matrix3D.M23 && _m31 == matrix3D.M31 && _m32 == matrix3D.M32)
			{
				return _m33 == matrix3D.M33;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "3x3[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}]", _m11, _m12, _m13, _m21, _m22, _m23, _m31, _m32, _m33);
	}

	public double GetDeterminant()
	{
		return _m11 * _m22 * _m33 + _m12 * _m23 * _m31 + _m13 * _m21 * _m32 - _m13 * _m22 * _m31 - _m11 * _m23 * _m32 - _m12 * _m21 * _m33;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref _m12, ref _m21);
		MathFunctions.Swap(ref _m13, ref _m31);
		MathFunctions.Swap(ref _m23, ref _m32);
	}

	public static bool operator ==(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return object.Equals(matrix3D_0, matrix3D_1);
	}

	public static bool operator !=(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return !object.Equals(matrix3D_0, matrix3D_1);
	}

	public static Matrix3D operator +(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return Add(matrix3D_0, matrix3D_1);
	}

	public static Matrix3D operator +(Matrix3D matrix3D_0, double double_0)
	{
		return Add(matrix3D_0, double_0);
	}

	public static Matrix3D operator +(double double_0, Matrix3D matrix3D_0)
	{
		return Add(matrix3D_0, double_0);
	}

	public static Matrix3D operator -(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return Subtract(matrix3D_0, matrix3D_1);
	}

	public static Matrix3D operator -(Matrix3D matrix3D_0, double double_0)
	{
		return Subtract(matrix3D_0, double_0);
	}

	public static Matrix3D operator *(Matrix3D matrix3D_0, Matrix3D matrix3D_1)
	{
		return Multiply(matrix3D_0, matrix3D_1);
	}

	public static Vector3D operator *(Matrix3D matrix3D_0, Vector3D vector3D_0)
	{
		return Transform(matrix3D_0, vector3D_0);
	}

	static Matrix3D()
	{
		Zero = new Matrix3D(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Identity = new Matrix3D(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);
	}
}
