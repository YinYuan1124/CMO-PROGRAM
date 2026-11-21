using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector2FConverter))]
public struct Vector2F : ICloneable
{
	private float _x;

	private float _y;

	public static readonly Vector2F Zero;

	public static readonly Vector2F XAxis;

	public static readonly Vector2F YAxis;

	public float X
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

	public float Y
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

	public float this[int int_0]
	{
		get
		{
			if (1 == 0)
			{
			}
			float result = int_0 switch
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

	public Vector2F(float float_0, float float_1)
	{
		_x = float_0;
		_y = float_1;
	}

	public Vector2F(float[] float_0)
	{
		_x = float_0[0];
		_y = float_0[1];
	}

	public Vector2F(List<float> list_0)
	{
		_x = list_0[0];
		_y = list_0[1];
	}

	public Vector2F(Vector2F vector2F_0)
	{
		_x = vector2F_0.X;
		_y = vector2F_0.Y;
	}

	object ICloneable.Clone()
	{
		return new Vector2F(this);
	}

	public Vector2F Clone()
	{
		return new Vector2F(this);
	}

	public static Vector2F Parse(string string_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector2F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")));
	}

	public static bool TryParse(string string_0, out Vector2F vector2F_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			vector2F_0 = new Vector2F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")));
			return true;
		}
		vector2F_0 = Zero;
		return false;
	}

	public static Vector2F Add(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return new Vector2F(vector2F_0.X + vector2F_1.X, vector2F_0.Y + vector2F_1.Y);
	}

	public static Vector2F Add(Vector2F vector2F_0, float float_0)
	{
		return new Vector2F(vector2F_0.X + float_0, vector2F_0.Y + float_0);
	}

	public static void Add(Vector2F vector2F_0, Vector2F vector2F_1, ref Vector2F vector2F_2)
	{
		vector2F_2.X = vector2F_0.X + vector2F_1.X;
		vector2F_2.Y = vector2F_0.Y + vector2F_1.Y;
	}

	public static void Add(Vector2F vector2F_0, float float_0, ref Vector2F vector2F_1)
	{
		vector2F_1.X = vector2F_0.X + float_0;
		vector2F_1.Y = vector2F_0.Y + float_0;
	}

	public static Vector2F Subtract(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return new Vector2F(vector2F_0.X - vector2F_1.X, vector2F_0.Y - vector2F_1.Y);
	}

	public static Vector2F Subtract(Vector2F vector2F_0, float float_0)
	{
		return new Vector2F(vector2F_0.X - float_0, vector2F_0.Y - float_0);
	}

	public static Vector2F Subtract(float float_0, Vector2F vector2F_0)
	{
		return new Vector2F(float_0 - vector2F_0.X, float_0 - vector2F_0.Y);
	}

	public static void Subtract(Vector2F vector2F_0, Vector2F vector2F_1, ref Vector2F vector2F_2)
	{
		vector2F_2.X = vector2F_0.X - vector2F_1.X;
		vector2F_2.Y = vector2F_0.Y - vector2F_1.Y;
	}

	public static void Subtract(Vector2F vector2F_0, float float_0, ref Vector2F vector2F_1)
	{
		vector2F_1.X = vector2F_0.X - float_0;
		vector2F_1.Y = vector2F_0.Y - float_0;
	}

	public static void Subtract(float float_0, Vector2F vector2F_0, ref Vector2F vector2F_1)
	{
		vector2F_1.X = float_0 - vector2F_0.X;
		vector2F_1.Y = float_0 - vector2F_0.Y;
	}

	public static Vector2F Divide(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return new Vector2F(vector2F_0.X / vector2F_1.X, vector2F_0.Y / vector2F_1.Y);
	}

	public static Vector2F Divide(Vector2F vector2F_0, float float_0)
	{
		return new Vector2F(vector2F_0.X / float_0, vector2F_0.Y / float_0);
	}

	public static Vector2F Divide(float float_0, Vector2F vector2F_0)
	{
		return new Vector2F(float_0 / vector2F_0.X, float_0 / vector2F_0.Y);
	}

	public static void Divide(Vector2F vector2F_0, Vector2F vector2F_1, ref Vector2F vector2F_2)
	{
		vector2F_2.X = vector2F_0.X / vector2F_1.X;
		vector2F_2.Y = vector2F_0.Y / vector2F_1.Y;
	}

	public static void Divide(Vector2F vector2F_0, float float_0, ref Vector2F vector2F_1)
	{
		vector2F_1.X = vector2F_0.X / float_0;
		vector2F_1.Y = vector2F_0.Y / float_0;
	}

	public static void Divide(float float_0, Vector2F vector2F_0, ref Vector2F vector2F_1)
	{
		vector2F_1.X = float_0 / vector2F_0.X;
		vector2F_1.Y = float_0 / vector2F_0.Y;
	}

	public static Vector2F Multiply(Vector2F vector2F_0, float float_0)
	{
		return new Vector2F(vector2F_0.X * float_0, vector2F_0.Y * float_0);
	}

	public static void Multiply(Vector2F vector2F_0, float float_0, ref Vector2F vector2F_1)
	{
		vector2F_1.X = vector2F_0.X * float_0;
		vector2F_1.Y = vector2F_0.Y * float_0;
	}

	public static float DotProduct(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return vector2F_0.X * vector2F_1.X + vector2F_0.Y * vector2F_1.Y;
	}

	public static float KrossProduct(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return vector2F_0.X * vector2F_1.Y - vector2F_0.Y * vector2F_1.X;
	}

	public static Vector2F Negate(Vector2F vector2F_0)
	{
		return new Vector2F(0f - vector2F_0.X, 0f - vector2F_0.Y);
	}

	public static bool ApproxEqual(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return ApproxEqual(vector2F_0, vector2F_1, 4.7683716E-07f);
	}

	public static bool ApproxEqual(Vector2F vector2F_0, Vector2F vector2F_1, float float_0)
	{
		if (System.Math.Abs(vector2F_0.X - vector2F_1.X) <= float_0)
		{
			return System.Math.Abs(vector2F_0.Y - vector2F_1.Y) <= float_0;
		}
		return false;
	}

	public void Normalize()
	{
		float length = GetLength();
		if (length == 0f)
		{
			throw new DivideByZeroException("Trying to normalize a vector with length of zero.");
		}
		_x /= length;
		_y /= length;
	}

	public float GetLength()
	{
		return (float)System.Math.Sqrt(_x * _x + _y * _y);
	}

	public float GetLengthSquared()
	{
		return _x * _x + _y * _y;
	}

	public void ClampZero(float float_0)
	{
		_x = MathFunctions.Clamp(_x, 0f, float_0);
		_y = MathFunctions.Clamp(_y, 0f, float_0);
	}

	public void ClampZero()
	{
		_x = MathFunctions.Clamp(_x, 0f);
		_y = MathFunctions.Clamp(_y, 0f);
	}

	public override int GetHashCode()
	{
		return _x.GetHashCode() ^ _y.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector2F vector2F)
		{
			if (_x == vector2F.X)
			{
				return _y == vector2F.Y;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return $"({_x}, {_y})";
	}

	public static bool operator ==(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return object.Equals(vector2F_0, vector2F_1);
	}

	public static bool operator !=(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return !object.Equals(vector2F_0, vector2F_1);
	}

	public static bool operator >(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		if (vector2F_0._x <= vector2F_1._x)
		{
			return false;
		}
		return vector2F_0._y > vector2F_1._y;
	}

	public static bool operator <(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		if (vector2F_0._x < vector2F_1._x)
		{
			return vector2F_0._y < vector2F_1._y;
		}
		return false;
	}

	public static bool operator >=(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		if (vector2F_0._x < vector2F_1._x)
		{
			return false;
		}
		return vector2F_0._y >= vector2F_1._y;
	}

	public static bool operator <=(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		if (vector2F_0._x <= vector2F_1._x)
		{
			return vector2F_0._y <= vector2F_1._y;
		}
		return false;
	}

	public static Vector2F operator -(Vector2F vector2F_0)
	{
		return Negate(vector2F_0);
	}

	public static Vector2F operator +(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return Add(vector2F_0, vector2F_1);
	}

	public static Vector2F operator +(Vector2F vector2F_0, float float_0)
	{
		return Add(vector2F_0, float_0);
	}

	public static Vector2F operator +(float float_0, Vector2F vector2F_0)
	{
		return Add(vector2F_0, float_0);
	}

	public static Vector2F operator -(Vector2F vector2F_0, Vector2F vector2F_1)
	{
		return Subtract(vector2F_0, vector2F_1);
	}

	public static Vector2F operator -(Vector2F vector2F_0, float float_0)
	{
		return Subtract(vector2F_0, float_0);
	}

	public static Vector2F operator -(float float_0, Vector2F vector2F_0)
	{
		return Subtract(float_0, vector2F_0);
	}

	public static Vector2F operator *(Vector2F vector2F_0, float float_0)
	{
		return Multiply(vector2F_0, float_0);
	}

	public static Vector2F operator *(float float_0, Vector2F vector2F_0)
	{
		return Multiply(vector2F_0, float_0);
	}

	public static Vector2F operator /(Vector2F vector2F_0, float float_0)
	{
		return Divide(vector2F_0, float_0);
	}

	public static Vector2F operator /(float float_0, Vector2F vector2F_0)
	{
		return Divide(float_0, vector2F_0);
	}

	public static explicit operator float[](Vector2F vector2F_0)
	{
		return new float[2] { vector2F_0.X, vector2F_0.Y };
	}

	public static explicit operator List<float>(Vector2F vector2F_0)
	{
		return new List<float>(2) { vector2F_0.X, vector2F_0.Y };
	}

	public static explicit operator LinkedList<float>(Vector2F vector2F_0)
	{
		LinkedList<float> linkedList = new LinkedList<float>();
		linkedList.AddLast(vector2F_0.X);
		linkedList.AddLast(vector2F_0.Y);
		return linkedList;
	}

	static Vector2F()
	{
		Zero = new Vector2F(0f, 0f);
		XAxis = new Vector2F(1f, 0f);
		YAxis = new Vector2F(0f, 1f);
	}
}
