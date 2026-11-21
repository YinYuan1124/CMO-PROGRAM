using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector2DConverter))]
public struct Vector2D : ICloneable
{
	private double _x;

	private double _y;

	public static readonly Vector2D Zero;

	public static readonly Vector2D XAxis;

	public static readonly Vector2D YAxis;

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

	public double this[int int_0]
	{
		get
		{
			if (1 == 0)
			{
			}
			double result = int_0 switch
			{
				1 => _y, 
				0 => _x, 
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
			case 1:
				_y = value;
				break;
			case 0:
				_x = value;
				break;
			}
		}
	}

	public Vector2D(double double_0, double double_1)
	{
		_x = double_0;
		_y = double_1;
	}

	public Vector2D(double[] double_0)
	{
		_x = double_0[0];
		_y = double_0[1];
	}

	public Vector2D(List<double> list_0)
	{
		_x = list_0[0];
		_y = list_0[1];
	}

	public Vector2D(Vector2D vector2D_0)
	{
		_x = vector2D_0.X;
		_y = vector2D_0.Y;
	}

	object ICloneable.Clone()
	{
		return new Vector2D(this);
	}

	public Vector2D Clone()
	{
		return new Vector2D(this);
	}

	public static Vector2D Parse(string string_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector2D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")));
	}

	public static bool TryParse(string string_0, out Vector2D vector2D_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			vector2D_0 = new Vector2D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")));
			return true;
		}
		vector2D_0 = Zero;
		return false;
	}

	public static Vector2D Add(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return new Vector2D(vector2D_0.X + vector2D_1.X, vector2D_0.Y + vector2D_1.Y);
	}

	public static Vector2D Add(Vector2D vector2D_0, double double_0)
	{
		return new Vector2D(vector2D_0.X + double_0, vector2D_0.Y + double_0);
	}

	public static void Add(Vector2D vector2D_0, Vector2D vector2D_1, ref Vector2D vector2D_2)
	{
		vector2D_2.X = vector2D_0.X + vector2D_1.X;
		vector2D_2.Y = vector2D_0.Y + vector2D_1.Y;
	}

	public static void Add(Vector2D vector2D_0, double double_0, ref Vector2D vector2D_1)
	{
		vector2D_1.X = vector2D_0.X + double_0;
		vector2D_1.Y = vector2D_0.Y + double_0;
	}

	public static Vector2D Subtract(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return new Vector2D(vector2D_0.X - vector2D_1.X, vector2D_0.Y - vector2D_1.Y);
	}

	public static Vector2D Subtract(Vector2D vector2D_0, double double_0)
	{
		return new Vector2D(vector2D_0.X - double_0, vector2D_0.Y - double_0);
	}

	public static Vector2D Subtract(double double_0, Vector2D vector2D_0)
	{
		return new Vector2D(double_0 - vector2D_0.X, double_0 - vector2D_0.Y);
	}

	public static void Subtract(Vector2D vector2D_0, Vector2D vector2D_1, ref Vector2D vector2D_2)
	{
		vector2D_2.X = vector2D_0.X - vector2D_1.X;
		vector2D_2.Y = vector2D_0.Y - vector2D_1.Y;
	}

	public static void Subtract(Vector2D vector2D_0, double double_0, ref Vector2D vector2D_1)
	{
		vector2D_1.X = vector2D_0.X - double_0;
		vector2D_1.Y = vector2D_0.Y - double_0;
	}

	public static void Subtract(double double_0, Vector2D vector2D_0, ref Vector2D vector2D_1)
	{
		vector2D_1.X = double_0 - vector2D_0.X;
		vector2D_1.Y = double_0 - vector2D_0.Y;
	}

	public static Vector2D Divide(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return new Vector2D(vector2D_0.X / vector2D_1.X, vector2D_0.Y / vector2D_1.Y);
	}

	public static Vector2D Divide(Vector2D vector2D_0, double double_0)
	{
		return new Vector2D(vector2D_0.X / double_0, vector2D_0.Y / double_0);
	}

	public static Vector2D Divide(double double_0, Vector2D vector2D_0)
	{
		return new Vector2D(double_0 / vector2D_0.X, double_0 / vector2D_0.Y);
	}

	public static void Divide(Vector2D vector2D_0, Vector2D vector2D_1, ref Vector2D vector2D_2)
	{
		vector2D_2.X = vector2D_0.X / vector2D_1.X;
		vector2D_2.Y = vector2D_0.Y / vector2D_1.Y;
	}

	public static void Divide(Vector2D vector2D_0, double double_0, ref Vector2D vector2D_1)
	{
		vector2D_1.X = vector2D_0.X / double_0;
		vector2D_1.Y = vector2D_0.Y / double_0;
	}

	public static void Divide(double double_0, Vector2D vector2D_0, ref Vector2D vector2D_1)
	{
		vector2D_1.X = double_0 / vector2D_0.X;
		vector2D_1.Y = double_0 / vector2D_0.Y;
	}

	public static Vector2D Multiply(Vector2D vector2D_0, double double_0)
	{
		return new Vector2D(vector2D_0.X * double_0, vector2D_0.Y * double_0);
	}

	public static void Multiply(Vector2D vector2D_0, double double_0, ref Vector2D vector2D_1)
	{
		vector2D_1.X = vector2D_0.X * double_0;
		vector2D_1.Y = vector2D_0.Y * double_0;
	}

	public static double DotProduct(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return vector2D_0.X * vector2D_1.X + vector2D_0.Y * vector2D_1.Y;
	}

	public static double KrossProduct(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return vector2D_0.X * vector2D_1.Y - vector2D_0.Y * vector2D_1.X;
	}

	public static Vector2D Negate(Vector2D vector2D_0)
	{
		return new Vector2D(0.0 - vector2D_0.X, 0.0 - vector2D_0.Y);
	}

	public static bool ApproxEqual(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return ApproxEqual(vector2D_0, vector2D_1, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(Vector2D vector2D_0, Vector2D vector2D_1, double double_0)
	{
		if (System.Math.Abs(vector2D_0.X - vector2D_1.X) <= double_0)
		{
			return System.Math.Abs(vector2D_0.Y - vector2D_1.Y) <= double_0;
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
	}

	public double GetLength()
	{
		return System.Math.Sqrt(_x * _x + _y * _y);
	}

	public double GetLengthSquared()
	{
		return _x * _x + _y * _y;
	}

	public void ClampZero(double double_0)
	{
		_x = MathFunctions.Clamp(_x, 0.0, double_0);
		_y = MathFunctions.Clamp(_y, 0.0, double_0);
	}

	public void ClampZero()
	{
		_x = MathFunctions.Clamp(_x, 0.0);
		_y = MathFunctions.Clamp(_y, 0.0);
	}

	public override int GetHashCode()
	{
		return _x.GetHashCode() ^ _y.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector2D vector2D)
		{
			if (_x == vector2D.X)
			{
				return _y == vector2D.Y;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", _x, _y);
	}

	public static bool operator ==(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return object.Equals(vector2D_0, vector2D_1);
	}

	public static bool operator !=(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return !object.Equals(vector2D_0, vector2D_1);
	}

	public static bool operator >(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		if (vector2D_0._x <= vector2D_1._x)
		{
			return false;
		}
		return vector2D_0._y > vector2D_1._y;
	}

	public static bool operator <(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		if (vector2D_0._x < vector2D_1._x)
		{
			return vector2D_0._y < vector2D_1._y;
		}
		return false;
	}

	public static bool operator >=(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		if (vector2D_0._x < vector2D_1._x)
		{
			return false;
		}
		return vector2D_0._y >= vector2D_1._y;
	}

	public static bool operator <=(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		if (vector2D_0._x <= vector2D_1._x)
		{
			return vector2D_0._y <= vector2D_1._y;
		}
		return false;
	}

	public static Vector2D operator -(Vector2D vector2D_0)
	{
		return Negate(vector2D_0);
	}

	public static Vector2D operator +(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return Add(vector2D_0, vector2D_1);
	}

	public static Vector2D operator +(Vector2D vector2D_0, double double_0)
	{
		return Add(vector2D_0, double_0);
	}

	public static Vector2D operator +(double double_0, Vector2D vector2D_0)
	{
		return Add(vector2D_0, double_0);
	}

	public static Vector2D operator -(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return Subtract(vector2D_0, vector2D_1);
	}

	public static Vector2D operator -(Vector2D vector2D_0, double double_0)
	{
		return Subtract(vector2D_0, double_0);
	}

	public static Vector2D operator -(double double_0, Vector2D vector2D_0)
	{
		return Subtract(double_0, vector2D_0);
	}

	public static Vector2D operator *(Vector2D vector2D_0, double double_0)
	{
		return Multiply(vector2D_0, double_0);
	}

	public static Vector2D operator *(double double_0, Vector2D vector2D_0)
	{
		return Multiply(vector2D_0, double_0);
	}

	public static Vector2D operator /(Vector2D vector2D_0, double double_0)
	{
		return Divide(vector2D_0, double_0);
	}

	public static Vector2D operator /(double double_0, Vector2D vector2D_0)
	{
		return Divide(double_0, vector2D_0);
	}

	public static explicit operator double[](Vector2D vector2D_0)
	{
		return new double[2] { vector2D_0.X, vector2D_0.Y };
	}

	public static explicit operator List<double>(Vector2D vector2D_0)
	{
		return new List<double>(2) { vector2D_0.X, vector2D_0.Y };
	}

	public static explicit operator LinkedList<double>(Vector2D vector2D_0)
	{
		LinkedList<double> linkedList = new LinkedList<double>();
		linkedList.AddLast(vector2D_0.X);
		linkedList.AddLast(vector2D_0.Y);
		return linkedList;
	}

	static Vector2D()
	{
		Zero = new Vector2D(0.0, 0.0);
		XAxis = new Vector2D(1.0, 0.0);
		YAxis = new Vector2D(0.0, 1.0);
	}
}
