using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector3DConverter))]
public struct Vector3D : ICloneable
{
	private double _x;

	private double _y;

	private double _z;

	public static readonly Vector3D Zero;

	public static readonly Vector3D XAxis;

	public static readonly Vector3D YAxis;

	public static readonly Vector3D ZAxis;

	public double X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public double Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public double Z
	{
		get
		{
			return _z;
		}
		set
		{
			_z = value;
		}
	}

	public double this[int int_0]
	{
		get
		{
			if (1 == 0)
			{
			}
			double result = int_0 switch
			{
				0 => _x, 
				1 => _y, 
				2 => _z, 
				_ => throw new IndexOutOfRangeException(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		set
		{
			switch (int_0)
			{
			default:
				throw new IndexOutOfRangeException();
			case 0:
				_x = value;
				break;
			case 1:
				_y = value;
				break;
			case 2:
				_z = value;
				break;
			}
		}
	}

	public Vector3D(double double_0, double double_1, double double_2)
	{
		_x = double_0;
		_y = double_1;
		_z = double_2;
	}

	public Vector3D(double[] double_0)
	{
		_x = double_0[0];
		_y = double_0[1];
		_z = double_0[2];
	}

	public Vector3D(List<double> list_0)
	{
		_x = list_0[0];
		_y = list_0[1];
		_z = list_0[2];
	}

	public Vector3D(Vector3D vector3D_0)
	{
		_x = vector3D_0.X;
		_y = vector3D_0.Y;
		_z = vector3D_0.Z;
	}

	object ICloneable.Clone()
	{
		return new Vector3D(this);
	}

	public Vector3D Clone()
	{
		return new Vector3D(this);
	}

	public static Vector3D Parse(string string_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		return new Vector3D(double.Parse(match.Result("${x}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${y}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${z}"), NumberStyles.Number, invariantCulture));
	}

	public static bool TryParse(string string_0, out Vector3D vector3D_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			vector3D_0 = new Vector3D(double.Parse(match.Result("${x}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${y}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${z}"), NumberStyles.Number, invariantCulture));
			return true;
		}
		vector3D_0 = Zero;
		return false;
	}

	public static Vector3D Add(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return new Vector3D(vector3D_0.X + vector3D_1.X, vector3D_0.Y + vector3D_1.Y, vector3D_0.Z + vector3D_1.Z);
	}

	public static Vector3D Add(Vector3D vector3D_0, double double_0)
	{
		return new Vector3D(vector3D_0.X + double_0, vector3D_0.Y + double_0, vector3D_0.Z + double_0);
	}

	public static void Add(Vector3D vector3D_0, Vector3D vector3D_1, ref Vector3D vector3D_2)
	{
		vector3D_2.X = vector3D_0.X + vector3D_1.X;
		vector3D_2.Y = vector3D_0.Y + vector3D_1.Y;
		vector3D_2.Z = vector3D_0.Z + vector3D_1.Z;
	}

	public static void Add(Vector3D vector3D_0, double double_0, ref Vector3D vector3D_1)
	{
		vector3D_1.X = vector3D_0.X + double_0;
		vector3D_1.Y = vector3D_0.Y + double_0;
		vector3D_1.Z = vector3D_0.Z + double_0;
	}

	public static Vector3D Subtract(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return new Vector3D(vector3D_0.X - vector3D_1.X, vector3D_0.Y - vector3D_1.Y, vector3D_0.Z - vector3D_1.Z);
	}

	public static Vector3D Subtract(Vector3D vector3D_0, double double_0)
	{
		return new Vector3D(vector3D_0.X - double_0, vector3D_0.Y - double_0, vector3D_0.Z - double_0);
	}

	public static Vector3D Subtract(double double_0, Vector3D vector3D_0)
	{
		return new Vector3D(double_0 - vector3D_0.X, double_0 - vector3D_0.Y, double_0 - vector3D_0.Z);
	}

	public static void Subtract(Vector3D vector3D_0, Vector3D vector3D_1, ref Vector3D vector3D_2)
	{
		vector3D_2.X = vector3D_0.X - vector3D_1.X;
		vector3D_2.Y = vector3D_0.Y - vector3D_1.Y;
		vector3D_2.Z = vector3D_0.Z - vector3D_1.Z;
	}

	public static void Subtract(Vector3D vector3D_0, double double_0, ref Vector3D vector3D_1)
	{
		vector3D_1.X = vector3D_0.X - double_0;
		vector3D_1.Y = vector3D_0.Y - double_0;
		vector3D_1.Z = vector3D_0.Z - double_0;
	}

	public static void Subtract(double double_0, Vector3D vector3D_0, ref Vector3D vector3D_1)
	{
		vector3D_1.X = double_0 - vector3D_0.X;
		vector3D_1.Y = double_0 - vector3D_0.Y;
		vector3D_1.Z = double_0 - vector3D_0.Z;
	}

	public static Vector3D Divide(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return new Vector3D(vector3D_0.X / vector3D_1.X, vector3D_0.Y / vector3D_1.Y, vector3D_0.Z / vector3D_1.Z);
	}

	public static Vector3D Divide(Vector3D vector3D_0, double double_0)
	{
		return new Vector3D(vector3D_0.X / double_0, vector3D_0.Y / double_0, vector3D_0.Z / double_0);
	}

	public static Vector3D Divide(double double_0, Vector3D vector3D_0)
	{
		return new Vector3D(double_0 / vector3D_0.X, double_0 / vector3D_0.Y, double_0 / vector3D_0.Z);
	}

	public static void Divide(Vector3D vector3D_0, Vector3D vector3D_1, ref Vector3D vector3D_2)
	{
		vector3D_2.X = vector3D_0.X / vector3D_1.X;
		vector3D_2.Y = vector3D_0.Y / vector3D_1.Y;
		vector3D_2.Z = vector3D_0.Z / vector3D_1.Z;
	}

	public static void Divide(Vector3D vector3D_0, double double_0, ref Vector3D vector3D_1)
	{
		vector3D_1.X = vector3D_0.X / double_0;
		vector3D_1.Y = vector3D_0.Y / double_0;
		vector3D_1.Z = vector3D_0.Z / double_0;
	}

	public static void Divide(double double_0, Vector3D vector3D_0, ref Vector3D vector3D_1)
	{
		vector3D_1.X = double_0 / vector3D_0.X;
		vector3D_1.Y = double_0 / vector3D_0.Y;
		vector3D_1.Z = double_0 / vector3D_0.Z;
	}

	public static Vector3D Multiply(Vector3D vector3D_0, double double_0)
	{
		return new Vector3D(vector3D_0.X * double_0, vector3D_0.Y * double_0, vector3D_0.Z * double_0);
	}

	public static void Multiply(Vector3D vector3D_0, double double_0, ref Vector3D vector3D_1)
	{
		vector3D_1.X = vector3D_0.X * double_0;
		vector3D_1.Y = vector3D_0.Y * double_0;
		vector3D_1.Z = vector3D_0.Z * double_0;
	}

	public static double DotProduct(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return vector3D_0.X * vector3D_1.X + vector3D_0.Y * vector3D_1.Y + vector3D_0.Z * vector3D_1.Z;
	}

	public static Vector3D CrossProduct(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return new Vector3D(vector3D_0.Y * vector3D_1.Z - vector3D_0.Z * vector3D_1.Y, vector3D_0.Z * vector3D_1.X - vector3D_0.X * vector3D_1.Z, vector3D_0.X * vector3D_1.Y - vector3D_0.Y * vector3D_1.X);
	}

	public static void CrossProduct(Vector3D vector3D_0, Vector3D vector3D_1, ref Vector3D vector3D_2)
	{
		vector3D_2.X = vector3D_0.Y * vector3D_1.Z - vector3D_0.Z * vector3D_1.Y;
		vector3D_2.Y = vector3D_0.Z * vector3D_1.X - vector3D_0.X * vector3D_1.Z;
		vector3D_2.Z = vector3D_0.X * vector3D_1.Y - vector3D_0.Y * vector3D_1.X;
	}

	public static Vector3D Negate(Vector3D vector3D_0)
	{
		return new Vector3D(0.0 - vector3D_0.X, 0.0 - vector3D_0.Y, 0.0 - vector3D_0.Z);
	}

	public static bool ApproxEqual(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return ApproxEqual(vector3D_0, vector3D_1, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(Vector3D vector3D_0, Vector3D vector3D_1, double double_0)
	{
		if (System.Math.Abs(vector3D_0.X - vector3D_1.X) <= double_0 && System.Math.Abs(vector3D_0.Y - vector3D_1.Y) <= double_0)
		{
			return System.Math.Abs(vector3D_0.Z - vector3D_1.Z) <= double_0;
		}
		return false;
	}

	public void Normalize()
	{
		double length = GetLength();
		if (length == 0.0)
		{
			throw new DivideByZeroException("Trying to normalize a vector with length of zero.");
		}
		_x /= length;
		_y /= length;
		_z /= length;
	}

	public double GetLength()
	{
		return System.Math.Sqrt(_x * _x + _y * _y + _z * _z);
	}

	public double GetLengthSquared()
	{
		return _x * _x + _y * _y + _z * _z;
	}

	public void ClampZero(double double_0)
	{
		_x = MathFunctions.Clamp(_x, 0.0, double_0);
		_y = MathFunctions.Clamp(_y, 0.0, double_0);
		_z = MathFunctions.Clamp(_z, 0.0, double_0);
	}

	public void ClampZero()
	{
		_x = MathFunctions.Clamp(_x, 0.0);
		_y = MathFunctions.Clamp(_y, 0.0);
		_z = MathFunctions.Clamp(_z, 0.0);
	}

	public override int GetHashCode()
	{
		return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector3D vector3D)
		{
			if (_x == vector3D.X && _y == vector3D.Y)
			{
				return _z == vector3D.Z;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", _x, _y, _z);
	}

	public static bool operator ==(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return object.Equals(vector3D_0, vector3D_1);
	}

	public static bool operator !=(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return !object.Equals(vector3D_0, vector3D_1);
	}

	public static bool operator >(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		if (!(vector3D_0._x <= vector3D_1._x) && vector3D_0._y > vector3D_1._y)
		{
			return vector3D_0._z > vector3D_1._z;
		}
		return false;
	}

	public static bool operator <(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		if (vector3D_0._x < vector3D_1._x && vector3D_0._y < vector3D_1._y)
		{
			return vector3D_0._z < vector3D_1._z;
		}
		return false;
	}

	public static bool operator >=(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		if (!(vector3D_0._x < vector3D_1._x) && vector3D_0._y >= vector3D_1._y)
		{
			return vector3D_0._z >= vector3D_1._z;
		}
		return false;
	}

	public static bool operator <=(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		if (vector3D_0._x <= vector3D_1._x && vector3D_0._y <= vector3D_1._y)
		{
			return vector3D_0._z <= vector3D_1._z;
		}
		return false;
	}

	public static Vector3D operator -(Vector3D vector3D_0)
	{
		return Negate(vector3D_0);
	}

	public static Vector3D operator +(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return Add(vector3D_0, vector3D_1);
	}

	public static Vector3D operator +(Vector3D vector3D_0, double double_0)
	{
		return Add(vector3D_0, double_0);
	}

	public static Vector3D operator +(double double_0, Vector3D vector3D_0)
	{
		return Add(vector3D_0, double_0);
	}

	public static Vector3D operator -(Vector3D vector3D_0, Vector3D vector3D_1)
	{
		return Subtract(vector3D_0, vector3D_1);
	}

	public static Vector3D operator -(Vector3D vector3D_0, double double_0)
	{
		return Subtract(vector3D_0, double_0);
	}

	public static Vector3D operator -(double double_0, Vector3D vector3D_0)
	{
		return Subtract(double_0, vector3D_0);
	}

	public static Vector3D operator *(Vector3D vector3D_0, double double_0)
	{
		return Multiply(vector3D_0, double_0);
	}

	public static Vector3D operator *(double double_0, Vector3D vector3D_0)
	{
		return Multiply(vector3D_0, double_0);
	}

	public static Vector3D operator /(Vector3D vector3D_0, double double_0)
	{
		return Divide(vector3D_0, double_0);
	}

	public static Vector3D operator /(double double_0, Vector3D vector3D_0)
	{
		return Divide(double_0, vector3D_0);
	}

	public static explicit operator double[](Vector3D vector3D_0)
	{
		return new double[3] { vector3D_0.X, vector3D_0.Y, vector3D_0.Z };
	}

	public static explicit operator List<double>(Vector3D vector3D_0)
	{
		return new List<double>(3) { vector3D_0.X, vector3D_0.Y, vector3D_0.Z };
	}

	public static explicit operator LinkedList<double>(Vector3D vector3D_0)
	{
		LinkedList<double> linkedList = new LinkedList<double>();
		linkedList.AddLast(vector3D_0.X);
		linkedList.AddLast(vector3D_0.Y);
		linkedList.AddLast(vector3D_0.Z);
		return linkedList;
	}

	static Vector3D()
	{
		Zero = new Vector3D(0.0, 0.0, 0.0);
		XAxis = new Vector3D(1.0, 0.0, 0.0);
		YAxis = new Vector3D(0.0, 1.0, 0.0);
		ZAxis = new Vector3D(0.0, 0.0, 1.0);
	}
}
