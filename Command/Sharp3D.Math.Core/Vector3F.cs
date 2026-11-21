using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector3FConverter))]
public struct Vector3F : ICloneable
{
	private float _x;

	private float _y;

	private float _z;

	public static readonly Vector3F Zero;

	public static readonly Vector3F XAxis;

	public static readonly Vector3F YAxis;

	public static readonly Vector3F ZAxis;

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

	public float Z
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

	public float this[int int_0]
	{
		get
		{
			if (1 == 0)
			{
			}
			float result = int_0 switch
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

	public Vector3F(float float_0, float float_1, float float_2)
	{
		_x = float_0;
		_y = float_1;
		_z = float_2;
	}

	public Vector3F(float[] float_0)
	{
		_x = float_0[0];
		_y = float_0[1];
		_z = float_0[2];
	}

	public Vector3F(List<float> list_0)
	{
		_x = list_0[0];
		_y = list_0[1];
		_z = list_0[2];
	}

	public Vector3F(Vector3F vector3F_0)
	{
		_x = vector3F_0.X;
		_y = vector3F_0.Y;
		_z = vector3F_0.Z;
	}

	object ICloneable.Clone()
	{
		return new Vector3F(this);
	}

	public Vector3F Clone()
	{
		return new Vector3F(this);
	}

	public static Vector3F Parse(string string_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector3F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")));
	}

	public static bool TryParse(string string_0, out Vector3F vector3F_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			vector3F_0 = new Vector3F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")));
			return true;
		}
		vector3F_0 = Zero;
		return false;
	}

	public static Vector3F Add(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return new Vector3F(vector3F_0.X + vector3F_1.X, vector3F_0.Y + vector3F_1.Y, vector3F_0.Z + vector3F_1.Z);
	}

	public static Vector3F Add(Vector3F vector3F_0, float float_0)
	{
		return new Vector3F(vector3F_0.X + float_0, vector3F_0.Y + float_0, vector3F_0.Z + float_0);
	}

	public static void Add(Vector3F vector3F_0, Vector3F vector3F_1, ref Vector3F vector3F_2)
	{
		vector3F_2.X = vector3F_0.X + vector3F_1.X;
		vector3F_2.Y = vector3F_0.Y + vector3F_1.Y;
		vector3F_2.Z = vector3F_0.Z + vector3F_1.Z;
	}

	public static void Add(Vector3F vector3F_0, float float_0, ref Vector3F vector3F_1)
	{
		vector3F_1.X = vector3F_0.X + float_0;
		vector3F_1.Y = vector3F_0.Y + float_0;
		vector3F_1.Z = vector3F_0.Z + float_0;
	}

	public static Vector3F Subtract(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return new Vector3F(vector3F_0.X - vector3F_1.X, vector3F_0.Y - vector3F_1.Y, vector3F_0.Z - vector3F_1.Z);
	}

	public static Vector3F Subtract(Vector3F vector3F_0, float float_0)
	{
		return new Vector3F(vector3F_0.X - float_0, vector3F_0.Y - float_0, vector3F_0.Z - float_0);
	}

	public static Vector3F Subtract(float float_0, Vector3F vector3F_0)
	{
		return new Vector3F(float_0 - vector3F_0.X, float_0 - vector3F_0.Y, float_0 - vector3F_0.Z);
	}

	public static void Subtract(Vector3F vector3F_0, Vector3F vector3F_1, ref Vector3F vector3F_2)
	{
		vector3F_2.X = vector3F_0.X - vector3F_1.X;
		vector3F_2.Y = vector3F_0.Y - vector3F_1.Y;
		vector3F_2.Z = vector3F_0.Z - vector3F_1.Z;
	}

	public static void Subtract(Vector3F vector3F_0, float float_0, ref Vector3F vector3F_1)
	{
		vector3F_1.X = vector3F_0.X - float_0;
		vector3F_1.Y = vector3F_0.Y - float_0;
		vector3F_1.Z = vector3F_0.Z - float_0;
	}

	public static void Subtract(float float_0, Vector3F vector3F_0, ref Vector3F vector3F_1)
	{
		vector3F_1.X = float_0 - vector3F_0.X;
		vector3F_1.Y = float_0 - vector3F_0.Y;
		vector3F_1.Z = float_0 - vector3F_0.Z;
	}

	public static Vector3F Divide(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return new Vector3F(vector3F_0.X / vector3F_1.X, vector3F_0.Y / vector3F_1.Y, vector3F_0.Z / vector3F_1.Z);
	}

	public static Vector3F Divide(Vector3F vector3F_0, float float_0)
	{
		return new Vector3F(vector3F_0.X / float_0, vector3F_0.Y / float_0, vector3F_0.Z / float_0);
	}

	public static Vector3F Divide(float float_0, Vector3F vector3F_0)
	{
		return new Vector3F(float_0 / vector3F_0.X, float_0 / vector3F_0.Y, float_0 / vector3F_0.Z);
	}

	public static void Divide(Vector3F vector3F_0, Vector3F vector3F_1, ref Vector3F vector3F_2)
	{
		vector3F_2.X = vector3F_0.X / vector3F_1.X;
		vector3F_2.Y = vector3F_0.Y / vector3F_1.Y;
		vector3F_2.Z = vector3F_0.Z / vector3F_1.Z;
	}

	public static void Divide(Vector3F vector3F_0, float float_0, ref Vector3F vector3F_1)
	{
		vector3F_1.X = vector3F_0.X / float_0;
		vector3F_1.Y = vector3F_0.Y / float_0;
		vector3F_1.Z = vector3F_0.Z / float_0;
	}

	public static void Divide(float float_0, Vector3F vector3F_0, ref Vector3F vector3F_1)
	{
		vector3F_1.X = float_0 / vector3F_0.X;
		vector3F_1.Y = float_0 / vector3F_0.Y;
		vector3F_1.Z = float_0 / vector3F_0.Z;
	}

	public static Vector3F Multiply(Vector3F vector3F_0, float float_0)
	{
		return new Vector3F(vector3F_0.X * float_0, vector3F_0.Y * float_0, vector3F_0.Z * float_0);
	}

	public static void Multiply(Vector3F vector3F_0, float float_0, ref Vector3F vector3F_1)
	{
		vector3F_1.X = vector3F_0.X * float_0;
		vector3F_1.Y = vector3F_0.Y * float_0;
		vector3F_1.Z = vector3F_0.Z * float_0;
	}

	public static float DotProduct(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return vector3F_0.X * vector3F_1.X + vector3F_0.Y * vector3F_1.Y + vector3F_0.Z * vector3F_1.Z;
	}

	public static Vector3F CrossProduct(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return new Vector3F(vector3F_0.Y * vector3F_1.Z - vector3F_0.Z * vector3F_1.Y, vector3F_0.Z * vector3F_1.X - vector3F_0.X * vector3F_1.Z, vector3F_0.X * vector3F_1.Y - vector3F_0.Y * vector3F_1.X);
	}

	public static void CrossProduct(Vector3F vector3F_0, Vector3F vector3F_1, ref Vector3F vector3F_2)
	{
		vector3F_2.X = vector3F_0.Y * vector3F_1.Z - vector3F_0.Z * vector3F_1.Y;
		vector3F_2.Y = vector3F_0.Z * vector3F_1.X - vector3F_0.X * vector3F_1.Z;
		vector3F_2.Z = vector3F_0.X * vector3F_1.Y - vector3F_0.Y * vector3F_1.X;
	}

	public static Vector3F Negate(Vector3F vector3F_0)
	{
		return new Vector3F(0f - vector3F_0.X, 0f - vector3F_0.Y, 0f - vector3F_0.Z);
	}

	public static bool ApproxEqual(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return ApproxEqual(vector3F_0, vector3F_1, 4.7683716E-07f);
	}

	public static bool ApproxEqual(Vector3F vector3F_0, Vector3F vector3F_1, float float_0)
	{
		if (System.Math.Abs(vector3F_0.X - vector3F_1.X) <= float_0 && System.Math.Abs(vector3F_0.Y - vector3F_1.Y) <= float_0)
		{
			return System.Math.Abs(vector3F_0.Z - vector3F_1.Z) <= float_0;
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
		_z /= length;
	}

	public float GetLength()
	{
		return (float)System.Math.Sqrt(_x * _x + _y * _y + _z * _z);
	}

	public float GetLengthSquared()
	{
		return _x * _x + _y * _y + _z * _z;
	}

	public void ClampZero(float float_0)
	{
		_x = MathFunctions.Clamp(_x, 0f, float_0);
		_y = MathFunctions.Clamp(_y, 0f, float_0);
		_z = MathFunctions.Clamp(_z, 0f, float_0);
	}

	public void ClampZero()
	{
		_x = MathFunctions.Clamp(_x, 0f);
		_y = MathFunctions.Clamp(_y, 0f);
		_z = MathFunctions.Clamp(_z, 0f);
	}

	public override int GetHashCode()
	{
		return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector3F vector3F)
		{
			if (_x == vector3F.X && _y == vector3F.Y)
			{
				return _z == vector3F.Z;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return $"({_x}, {_y}, {_z})";
	}

	public static bool operator ==(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return object.Equals(vector3F_0, vector3F_1);
	}

	public static bool operator !=(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return !object.Equals(vector3F_0, vector3F_1);
	}

	public static bool operator >(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		if (!(vector3F_0._x <= vector3F_1._x) && vector3F_0._y > vector3F_1._y)
		{
			return vector3F_0._z > vector3F_1._z;
		}
		return false;
	}

	public static bool operator <(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		if (vector3F_0._x < vector3F_1._x && vector3F_0._y < vector3F_1._y)
		{
			return vector3F_0._z < vector3F_1._z;
		}
		return false;
	}

	public static bool operator >=(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		if (!(vector3F_0._x < vector3F_1._x) && vector3F_0._y >= vector3F_1._y)
		{
			return vector3F_0._z >= vector3F_1._z;
		}
		return false;
	}

	public static bool operator <=(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		if (vector3F_0._x <= vector3F_1._x && vector3F_0._y <= vector3F_1._y)
		{
			return vector3F_0._z <= vector3F_1._z;
		}
		return false;
	}

	public static Vector3F operator -(Vector3F vector3F_0)
	{
		return Negate(vector3F_0);
	}

	public static Vector3F operator +(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return Add(vector3F_0, vector3F_1);
	}

	public static Vector3F operator +(Vector3F vector3F_0, float float_0)
	{
		return Add(vector3F_0, float_0);
	}

	public static Vector3F operator +(float float_0, Vector3F vector3F_0)
	{
		return Add(vector3F_0, float_0);
	}

	public static Vector3F operator -(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		return Subtract(vector3F_0, vector3F_1);
	}

	public static Vector3F operator -(Vector3F vector3F_0, float float_0)
	{
		return Subtract(vector3F_0, float_0);
	}

	public static Vector3F operator -(float float_0, Vector3F vector3F_0)
	{
		return Subtract(float_0, vector3F_0);
	}

	public static Vector3F operator *(Vector3F vector3F_0, float float_0)
	{
		return Multiply(vector3F_0, float_0);
	}

	public static Vector3F operator *(float float_0, Vector3F vector3F_0)
	{
		return Multiply(vector3F_0, float_0);
	}

	public static Vector3F operator /(Vector3F vector3F_0, float float_0)
	{
		return Divide(vector3F_0, float_0);
	}

	public static Vector3F operator /(float float_0, Vector3F vector3F_0)
	{
		return Divide(float_0, vector3F_0);
	}

	public static explicit operator float[](Vector3F vector3F_0)
	{
		return new float[3] { vector3F_0.X, vector3F_0.Y, vector3F_0.Z };
	}

	public static explicit operator List<float>(Vector3F vector3F_0)
	{
		return new List<float>(3) { vector3F_0.X, vector3F_0.Y, vector3F_0.Z };
	}

	public static explicit operator LinkedList<float>(Vector3F vector3F_0)
	{
		LinkedList<float> linkedList = new LinkedList<float>();
		linkedList.AddLast(vector3F_0.X);
		linkedList.AddLast(vector3F_0.Y);
		linkedList.AddLast(vector3F_0.Z);
		return linkedList;
	}

	static Vector3F()
	{
		Zero = new Vector3F(0f, 0f, 0f);
		XAxis = new Vector3F(1f, 0f, 0f);
		YAxis = new Vector3F(0f, 1f, 0f);
		ZAxis = new Vector3F(0f, 0f, 1f);
	}
}
