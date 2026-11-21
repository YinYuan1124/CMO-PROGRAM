using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector4DConverter))]
public struct Vector4D : ICloneable
{
	private double _x;

	private double _y;

	private double _z;

	private double _w;

	public static readonly Vector4D Zero;

	public static readonly Vector4D XAxis;

	public static readonly Vector4D YAxis;

	public static readonly Vector4D ZAxis;

	public static readonly Vector4D WAxis;

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

	public double W
	{
		get
		{
			return _w;
		}
		set
		{
			_w = value;
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
				3 => _w, 
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
			case 3:
				_w = value;
				break;
			}
		}
	}

	public Vector4D(double double_0, double double_1, double double_2, double double_3)
	{
		_x = double_0;
		_y = double_1;
		_z = double_2;
		_w = double_3;
	}

	public Vector4D(double[] double_0)
	{
		_x = double_0[0];
		_y = double_0[1];
		_z = double_0[2];
		_w = double_0[3];
	}

	public Vector4D(List<double> list_0)
	{
		_x = list_0[0];
		_y = list_0[1];
		_z = list_0[2];
		_w = list_0[3];
	}

	public Vector4D(Vector4D vector4D_0)
	{
		_x = vector4D_0.X;
		_y = vector4D_0.Y;
		_z = vector4D_0.Z;
		_w = vector4D_0.W;
	}

	object ICloneable.Clone()
	{
		return new Vector4D(this);
	}

	public Vector4D Clone()
	{
		return new Vector4D(this);
	}

	public static Vector4D Parse(string string_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector4D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")), double.Parse(match.Result("${w}")));
	}

	public static bool TryParse(string string_0, out Vector4D vector4D_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			vector4D_0 = new Vector4D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")), double.Parse(match.Result("${w}")));
			return true;
		}
		vector4D_0 = Zero;
		return false;
	}

	public static Vector4D Add(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return new Vector4D(vector4D_0.X + vector4D_1.X, vector4D_0.Y + vector4D_1.Y, vector4D_0.Z + vector4D_1.Z, vector4D_0.W + vector4D_1.W);
	}

	public static Vector4D Add(Vector4D vector4D_0, double double_0)
	{
		return new Vector4D(vector4D_0.X + double_0, vector4D_0.Y + double_0, vector4D_0.Z + double_0, vector4D_0.W + double_0);
	}

	public static void Add(Vector4D vector4D_0, Vector4D vector4D_1, ref Vector4D vector4D_2)
	{
		vector4D_2.X = vector4D_0.X + vector4D_1.X;
		vector4D_2.Y = vector4D_0.Y + vector4D_1.Y;
		vector4D_2.Z = vector4D_0.Z + vector4D_1.Z;
		vector4D_2.W = vector4D_0.W + vector4D_1.W;
	}

	public static void Add(Vector4D vector4D_0, double double_0, ref Vector4D vector4D_1)
	{
		vector4D_1.X = vector4D_0.X + double_0;
		vector4D_1.Y = vector4D_0.Y + double_0;
		vector4D_1.Z = vector4D_0.Z + double_0;
		vector4D_1.W = vector4D_0.W + double_0;
	}

	public static Vector4D Subtract(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return new Vector4D(vector4D_0.X - vector4D_1.X, vector4D_0.Y - vector4D_1.Y, vector4D_0.Z - vector4D_1.Z, vector4D_0.W - vector4D_1.W);
	}

	public static Vector4D Subtract(Vector4D vector4D_0, double double_0)
	{
		return new Vector4D(vector4D_0.X - double_0, vector4D_0.Y - double_0, vector4D_0.Z - double_0, vector4D_0.W - double_0);
	}

	public static Vector4D Subtract(double double_0, Vector4D vector4D_0)
	{
		return new Vector4D(double_0 - vector4D_0.X, double_0 - vector4D_0.Y, double_0 - vector4D_0.Z, double_0 - vector4D_0.W);
	}

	public static void Subtract(Vector4D vector4D_0, Vector4D vector4D_1, ref Vector4D vector4D_2)
	{
		vector4D_2.X = vector4D_0.X - vector4D_1.X;
		vector4D_2.Y = vector4D_0.Y - vector4D_1.Y;
		vector4D_2.Z = vector4D_0.Z - vector4D_1.Z;
		vector4D_2.W = vector4D_0.W - vector4D_1.W;
	}

	public static void Subtract(Vector4D vector4D_0, double double_0, ref Vector4D vector4D_1)
	{
		vector4D_1.X = vector4D_0.X - double_0;
		vector4D_1.Y = vector4D_0.Y - double_0;
		vector4D_1.Z = vector4D_0.Z - double_0;
		vector4D_1.W = vector4D_0.W - double_0;
	}

	public static void Subtract(double double_0, Vector4D vector4D_0, ref Vector4D vector4D_1)
	{
		vector4D_1.X = double_0 - vector4D_0.X;
		vector4D_1.Y = double_0 - vector4D_0.Y;
		vector4D_1.Z = double_0 - vector4D_0.Z;
		vector4D_1.W = double_0 - vector4D_0.W;
	}

	public static Vector4D Divide(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return new Vector4D(vector4D_0.X / vector4D_1.X, vector4D_0.Y / vector4D_1.Y, vector4D_0.Z / vector4D_1.Z, vector4D_0.W / vector4D_1.W);
	}

	public static Vector4D Divide(Vector4D vector4D_0, double double_0)
	{
		return new Vector4D(vector4D_0.X / double_0, vector4D_0.Y / double_0, vector4D_0.Z / double_0, vector4D_0.W / double_0);
	}

	public static Vector4D Divide(double double_0, Vector4D vector4D_0)
	{
		return new Vector4D(double_0 / vector4D_0.X, double_0 / vector4D_0.Y, double_0 / vector4D_0.Z, double_0 / vector4D_0.W);
	}

	public static void Divide(Vector4D vector4D_0, Vector4D vector4D_1, ref Vector4D vector4D_2)
	{
		vector4D_2.X = vector4D_0.X / vector4D_1.X;
		vector4D_2.Y = vector4D_0.Y / vector4D_1.Y;
		vector4D_2.Z = vector4D_0.Z / vector4D_1.Z;
		vector4D_2.W = vector4D_0.W / vector4D_1.W;
	}

	public static void Divide(Vector4D vector4D_0, double double_0, ref Vector4D vector4D_1)
	{
		vector4D_1.X = vector4D_0.X / double_0;
		vector4D_1.Y = vector4D_0.Y / double_0;
		vector4D_1.Z = vector4D_0.Z / double_0;
		vector4D_1.W = vector4D_0.W / double_0;
	}

	public static void Divide(double double_0, Vector4D vector4D_0, ref Vector4D vector4D_1)
	{
		vector4D_1.X = double_0 / vector4D_0.X;
		vector4D_1.Y = double_0 / vector4D_0.Y;
		vector4D_1.Z = double_0 / vector4D_0.Z;
		vector4D_1.W = double_0 / vector4D_0.W;
	}

	public static Vector4D Multiply(Vector4D vector4D_0, double double_0)
	{
		return new Vector4D(vector4D_0.X * double_0, vector4D_0.Y * double_0, vector4D_0.Z * double_0, vector4D_0.W * double_0);
	}

	public static void Multiply(Vector4D vector4D_0, double double_0, ref Vector4D vector4D_1)
	{
		vector4D_1.X = vector4D_0.X * double_0;
		vector4D_1.Y = vector4D_0.Y * double_0;
		vector4D_1.Z = vector4D_0.Z * double_0;
		vector4D_1.W = vector4D_0.W * double_0;
	}

	public static double DotProduct(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return vector4D_0.X * vector4D_1.X + vector4D_0.Y * vector4D_1.Y + vector4D_0.Z * vector4D_1.Z + vector4D_0.W * vector4D_1.W;
	}

	public static Vector4D Negate(Vector4D vector4D_0)
	{
		return new Vector4D(0.0 - vector4D_0.X, 0.0 - vector4D_0.Y, 0.0 - vector4D_0.Z, 0.0 - vector4D_0.W);
	}

	public static bool ApproxEqual(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return ApproxEqual(vector4D_0, vector4D_1, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(Vector4D vector4D_0, Vector4D vector4D_1, double double_0)
	{
		if (System.Math.Abs(vector4D_0.X - vector4D_1.X) <= double_0 && System.Math.Abs(vector4D_0.Y - vector4D_1.Y) <= double_0 && System.Math.Abs(vector4D_0.Z - vector4D_1.Z) <= double_0)
		{
			return System.Math.Abs(vector4D_0.W - vector4D_1.W) <= double_0;
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
		_w /= length;
	}

	public double GetLength()
	{
		return System.Math.Sqrt(_x * _x + _y * _y + _z * _z + _w * _w);
	}

	public double GetLengthSquared()
	{
		return _x * _x + _y * _y + _z * _z + _w * _w;
	}

	public void ClampZero(double double_0)
	{
		_x = MathFunctions.Clamp(_x, 0.0, double_0);
		_y = MathFunctions.Clamp(_y, 0.0, double_0);
		_z = MathFunctions.Clamp(_z, 0.0, double_0);
		_w = MathFunctions.Clamp(_w, 0.0, double_0);
	}

	public void ClampZero()
	{
		_x = MathFunctions.Clamp(_x, 0.0);
		_y = MathFunctions.Clamp(_y, 0.0);
		_z = MathFunctions.Clamp(_z, 0.0);
		_w = MathFunctions.Clamp(_w, 0.0);
	}

	public override int GetHashCode()
	{
		return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode() ^ _w.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector4D vector4D)
		{
			if (_x == vector4D.X && _y == vector4D.Y && _z == vector4D.Z)
			{
				return _w == vector4D.W;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2}, {3})", _x, _y, _z, _w);
	}

	public static bool operator ==(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return object.Equals(vector4D_0, vector4D_1);
	}

	public static bool operator !=(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return !object.Equals(vector4D_0, vector4D_1);
	}

	public static bool operator >(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		if (!(vector4D_0._x <= vector4D_1._x) && !(vector4D_0._y <= vector4D_1._y) && vector4D_0._z > vector4D_1._z)
		{
			return vector4D_0._w > vector4D_1._w;
		}
		return false;
	}

	public static bool operator <(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		if (vector4D_0._x < vector4D_1._x && vector4D_0._y < vector4D_1._y && vector4D_0._z < vector4D_1._z)
		{
			return vector4D_0._w < vector4D_1._w;
		}
		return false;
	}

	public static bool operator >=(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		if (!(vector4D_0._x < vector4D_1._x) && !(vector4D_0._y < vector4D_1._y) && vector4D_0._z >= vector4D_1._z)
		{
			return vector4D_0._w >= vector4D_1._w;
		}
		return false;
	}

	public static bool operator <=(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		if (vector4D_0._x <= vector4D_1._x && vector4D_0._y <= vector4D_1._y && vector4D_0._z <= vector4D_1._z)
		{
			return vector4D_0._w <= vector4D_1._w;
		}
		return false;
	}

	public static Vector4D operator -(Vector4D vector4D_0)
	{
		return Negate(vector4D_0);
	}

	public static Vector4D operator +(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return Add(vector4D_0, vector4D_1);
	}

	public static Vector4D operator +(Vector4D vector4D_0, double double_0)
	{
		return Add(vector4D_0, double_0);
	}

	public static Vector4D operator +(double double_0, Vector4D vector4D_0)
	{
		return Add(vector4D_0, double_0);
	}

	public static Vector4D operator -(Vector4D vector4D_0, Vector4D vector4D_1)
	{
		return Subtract(vector4D_0, vector4D_1);
	}

	public static Vector4D operator -(Vector4D vector4D_0, double double_0)
	{
		return Subtract(vector4D_0, double_0);
	}

	public static Vector4D operator -(double double_0, Vector4D vector4D_0)
	{
		return Subtract(double_0, vector4D_0);
	}

	public static Vector4D operator *(Vector4D vector4D_0, double double_0)
	{
		return Multiply(vector4D_0, double_0);
	}

	public static Vector4D operator *(double double_0, Vector4D vector4D_0)
	{
		return Multiply(vector4D_0, double_0);
	}

	public static Vector4D operator /(Vector4D vector4D_0, double double_0)
	{
		return Divide(vector4D_0, double_0);
	}

	public static Vector4D operator /(double double_0, Vector4D vector4D_0)
	{
		return Divide(double_0, vector4D_0);
	}

	public static explicit operator double[](Vector4D vector4D_0)
	{
		return new double[4] { vector4D_0.X, vector4D_0.Y, vector4D_0.Z, vector4D_0.W };
	}

	public static explicit operator List<double>(Vector4D vector4D_0)
	{
		return new List<double>(4) { vector4D_0.X, vector4D_0.Y, vector4D_0.Z, vector4D_0.W };
	}

	public static explicit operator LinkedList<double>(Vector4D vector4D_0)
	{
		LinkedList<double> linkedList = new LinkedList<double>();
		linkedList.AddLast(vector4D_0.X);
		linkedList.AddLast(vector4D_0.Y);
		linkedList.AddLast(vector4D_0.Z);
		linkedList.AddLast(vector4D_0.W);
		return linkedList;
	}

	static Vector4D()
	{
		Zero = new Vector4D(0.0, 0.0, 0.0, 0.0);
		XAxis = new Vector4D(1.0, 0.0, 0.0, 0.0);
		YAxis = new Vector4D(0.0, 1.0, 0.0, 0.0);
		ZAxis = new Vector4D(0.0, 0.0, 1.0, 0.0);
		WAxis = new Vector4D(0.0, 0.0, 0.0, 1.0);
	}
}
