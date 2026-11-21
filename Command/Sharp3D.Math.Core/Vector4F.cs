using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector4FConverter))]
public struct Vector4F : ICloneable
{
	private float _x;

	private float _y;

	private float _z;

	private float _w;

	public static readonly Vector4F Zero;

	public static readonly Vector4F XAxis;

	public static readonly Vector4F YAxis;

	public static readonly Vector4F ZAxis;

	public static readonly Vector4F WAxis;

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

	public float W
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

	public Vector4F(float float_0, float float_1, float float_2, float float_3)
	{
		_x = float_0;
		_y = float_1;
		_z = float_2;
		_w = float_3;
	}

	public Vector4F(float[] float_0)
	{
		_x = float_0[0];
		_y = float_0[1];
		_z = float_0[2];
		_w = float_0[3];
	}

	public Vector4F(List<float> list_0)
	{
		_x = list_0[0];
		_y = list_0[1];
		_z = list_0[2];
		_w = list_0[3];
	}

	public Vector4F(Vector4F vector4F_0)
	{
		_x = vector4F_0.X;
		_y = vector4F_0.Y;
		_z = vector4F_0.Z;
		_w = vector4F_0.W;
	}

	object ICloneable.Clone()
	{
		return new Vector4F(this);
	}

	public Vector4F Clone()
	{
		return new Vector4F(this);
	}

	public static Vector4F Parse(string string_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector4F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")), float.Parse(match.Result("${w}")));
	}

	public static bool TryParse(string string_0, out Vector4F vector4F_0)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(string_0);
		if (match.Success)
		{
			vector4F_0 = new Vector4F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")), float.Parse(match.Result("${w}")));
			return true;
		}
		vector4F_0 = Zero;
		return false;
	}

	public static Vector4F Add(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return new Vector4F(vector4F_0.X + vector4F_1.X, vector4F_0.Y + vector4F_1.Y, vector4F_0.Z + vector4F_1.Z, vector4F_0.W + vector4F_1.W);
	}

	public static Vector4F Add(Vector4F vector4F_0, float float_0)
	{
		return new Vector4F(vector4F_0.X + float_0, vector4F_0.Y + float_0, vector4F_0.Z + float_0, vector4F_0.W + float_0);
	}

	public static void Add(Vector4F vector4F_0, Vector4F vector4F_1, ref Vector4F vector4F_2)
	{
		vector4F_2.X = vector4F_0.X + vector4F_1.X;
		vector4F_2.Y = vector4F_0.Y + vector4F_1.Y;
		vector4F_2.Z = vector4F_0.Z + vector4F_1.Z;
		vector4F_2.W = vector4F_0.W + vector4F_1.W;
	}

	public static void Add(Vector4F vector4F_0, float float_0, ref Vector4F vector4F_1)
	{
		vector4F_1.X = vector4F_0.X + float_0;
		vector4F_1.Y = vector4F_0.Y + float_0;
		vector4F_1.Z = vector4F_0.Z + float_0;
		vector4F_1.W = vector4F_0.W + float_0;
	}

	public static Vector4F Subtract(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return new Vector4F(vector4F_0.X - vector4F_1.X, vector4F_0.Y - vector4F_1.Y, vector4F_0.Z - vector4F_1.Z, vector4F_0.W - vector4F_1.W);
	}

	public static Vector4F Subtract(Vector4F vector4F_0, float float_0)
	{
		return new Vector4F(vector4F_0.X - float_0, vector4F_0.Y - float_0, vector4F_0.Z - float_0, vector4F_0.W - float_0);
	}

	public static Vector4F Subtract(float float_0, Vector4F vector4F_0)
	{
		return new Vector4F(float_0 - vector4F_0.X, float_0 - vector4F_0.Y, float_0 - vector4F_0.Z, float_0 - vector4F_0.W);
	}

	public static void Subtract(Vector4F vector4F_0, Vector4F vector4F_1, ref Vector4F vector4F_2)
	{
		vector4F_2.X = vector4F_0.X - vector4F_1.X;
		vector4F_2.Y = vector4F_0.Y - vector4F_1.Y;
		vector4F_2.Z = vector4F_0.Z - vector4F_1.Z;
		vector4F_2.W = vector4F_0.W - vector4F_1.W;
	}

	public static void Subtract(Vector4F vector4F_0, float float_0, ref Vector4F vector4F_1)
	{
		vector4F_1.X = vector4F_0.X - float_0;
		vector4F_1.Y = vector4F_0.Y - float_0;
		vector4F_1.Z = vector4F_0.Z - float_0;
		vector4F_1.W = vector4F_0.W - float_0;
	}

	public static void Subtract(float float_0, Vector4F vector4F_0, ref Vector4F vector4F_1)
	{
		vector4F_1.X = float_0 - vector4F_0.X;
		vector4F_1.Y = float_0 - vector4F_0.Y;
		vector4F_1.Z = float_0 - vector4F_0.Z;
		vector4F_1.W = float_0 - vector4F_0.W;
	}

	public static Vector4F Divide(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return new Vector4F(vector4F_0.X / vector4F_1.X, vector4F_0.Y / vector4F_1.Y, vector4F_0.Z / vector4F_1.Z, vector4F_0.W / vector4F_1.W);
	}

	public static Vector4F Divide(Vector4F vector4F_0, float float_0)
	{
		return new Vector4F(vector4F_0.X / float_0, vector4F_0.Y / float_0, vector4F_0.Z / float_0, vector4F_0.W / float_0);
	}

	public static Vector4F Divide(float float_0, Vector4F vector4F_0)
	{
		return new Vector4F(float_0 / vector4F_0.X, float_0 / vector4F_0.Y, float_0 / vector4F_0.Z, float_0 / vector4F_0.W);
	}

	public static void Divide(Vector4F vector4F_0, Vector4F vector4F_1, ref Vector4F vector4F_2)
	{
		vector4F_2.X = vector4F_0.X / vector4F_1.X;
		vector4F_2.Y = vector4F_0.Y / vector4F_1.Y;
		vector4F_2.Z = vector4F_0.Z / vector4F_1.Z;
		vector4F_2.W = vector4F_0.W / vector4F_1.W;
	}

	public static void Divide(Vector4F vector4F_0, float float_0, ref Vector4F vector4F_1)
	{
		vector4F_1.X = vector4F_0.X / float_0;
		vector4F_1.Y = vector4F_0.Y / float_0;
		vector4F_1.Z = vector4F_0.Z / float_0;
		vector4F_1.W = vector4F_0.W / float_0;
	}

	public static void Divide(float float_0, Vector4F vector4F_0, ref Vector4F vector4F_1)
	{
		vector4F_1.X = float_0 / vector4F_0.X;
		vector4F_1.Y = float_0 / vector4F_0.Y;
		vector4F_1.Z = float_0 / vector4F_0.Z;
		vector4F_1.W = float_0 / vector4F_0.W;
	}

	public static Vector4F Multiply(Vector4F vector4F_0, float float_0)
	{
		return new Vector4F(vector4F_0.X * float_0, vector4F_0.Y * float_0, vector4F_0.Z * float_0, vector4F_0.W * float_0);
	}

	public static void Multiply(Vector4F vector4F_0, float float_0, ref Vector4F vector4F_1)
	{
		vector4F_1.X = vector4F_0.X * float_0;
		vector4F_1.Y = vector4F_0.Y * float_0;
		vector4F_1.Z = vector4F_0.Z * float_0;
		vector4F_1.W = vector4F_0.W * float_0;
	}

	public static float DotProduct(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return vector4F_0.X * vector4F_1.X + vector4F_0.Y * vector4F_1.Y + vector4F_0.Z * vector4F_1.Z + vector4F_0.W * vector4F_1.W;
	}

	public static Vector4F Negate(Vector4F vector4F_0)
	{
		return new Vector4F(0f - vector4F_0.X, 0f - vector4F_0.Y, 0f - vector4F_0.Z, 0f - vector4F_0.W);
	}

	public static bool ApproxEqual(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return ApproxEqual(vector4F_0, vector4F_1, 4.7683716E-07f);
	}

	public static bool ApproxEqual(Vector4F vector4F_0, Vector4F vector4F_1, float float_0)
	{
		if (System.Math.Abs(vector4F_0.X - vector4F_1.X) <= float_0 && System.Math.Abs(vector4F_0.Y - vector4F_1.Y) <= float_0 && System.Math.Abs(vector4F_0.Z - vector4F_1.Z) <= float_0)
		{
			return System.Math.Abs(vector4F_0.W - vector4F_1.W) <= float_0;
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
		_w /= length;
	}

	public float GetLength()
	{
		return (float)System.Math.Sqrt(_x * _x + _y * _y + _z * _z + _w * _w);
	}

	public float GetLengthSquared()
	{
		return _x * _x + _y * _y + _z * _z + _w * _w;
	}

	public void ClampZero(float float_0)
	{
		_x = MathFunctions.Clamp(_x, 0f, float_0);
		_y = MathFunctions.Clamp(_y, 0f, float_0);
		_z = MathFunctions.Clamp(_z, 0f, float_0);
		_w = MathFunctions.Clamp(_w, 0f, float_0);
	}

	public void ClampZero()
	{
		_x = MathFunctions.Clamp(_x, 0f);
		_y = MathFunctions.Clamp(_y, 0f);
		_z = MathFunctions.Clamp(_z, 0f);
		_w = MathFunctions.Clamp(_w, 0f);
	}

	public override int GetHashCode()
	{
		return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode() ^ _w.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector4F vector4F)
		{
			if (_x == vector4F.X && _y == vector4F.Y && _z == vector4F.Z)
			{
				return _w == vector4F.W;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2}, {3})", _x, _y, _z, _w);
	}

	public static bool operator ==(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return object.Equals(vector4F_0, vector4F_1);
	}

	public static bool operator !=(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return !object.Equals(vector4F_0, vector4F_1);
	}

	public static bool operator >(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		if (!(vector4F_0._x <= vector4F_1._x) && !(vector4F_0._y <= vector4F_1._y) && vector4F_0._z > vector4F_1._z)
		{
			return vector4F_0._w > vector4F_1._w;
		}
		return false;
	}

	public static bool operator <(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		if (vector4F_0._x < vector4F_1._x && vector4F_0._y < vector4F_1._y && vector4F_0._z < vector4F_1._z)
		{
			return vector4F_0._w < vector4F_1._w;
		}
		return false;
	}

	public static bool operator >=(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		if (!(vector4F_0._x < vector4F_1._x) && !(vector4F_0._y < vector4F_1._y) && vector4F_0._z >= vector4F_1._z)
		{
			return vector4F_0._w >= vector4F_1._w;
		}
		return false;
	}

	public static bool operator <=(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		if (vector4F_0._x <= vector4F_1._x && vector4F_0._y <= vector4F_1._y && vector4F_0._z <= vector4F_1._z)
		{
			return vector4F_0._w <= vector4F_1._w;
		}
		return false;
	}

	public static Vector4F operator -(Vector4F vector4F_0)
	{
		return Negate(vector4F_0);
	}

	public static Vector4F operator +(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return Add(vector4F_0, vector4F_1);
	}

	public static Vector4F operator +(Vector4F vector4F_0, float float_0)
	{
		return Add(vector4F_0, float_0);
	}

	public static Vector4F operator +(float float_0, Vector4F vector4F_0)
	{
		return Add(vector4F_0, float_0);
	}

	public static Vector4F operator -(Vector4F vector4F_0, Vector4F vector4F_1)
	{
		return Subtract(vector4F_0, vector4F_1);
	}

	public static Vector4F operator -(Vector4F vector4F_0, float float_0)
	{
		return Subtract(vector4F_0, float_0);
	}

	public static Vector4F operator -(float float_0, Vector4F vector4F_0)
	{
		return Subtract(float_0, vector4F_0);
	}

	public static Vector4F operator *(Vector4F vector4F_0, float float_0)
	{
		return Multiply(vector4F_0, float_0);
	}

	public static Vector4F operator *(float float_0, Vector4F vector4F_0)
	{
		return Multiply(vector4F_0, float_0);
	}

	public static Vector4F operator /(Vector4F vector4F_0, float float_0)
	{
		return Divide(vector4F_0, float_0);
	}

	public static Vector4F operator /(float float_0, Vector4F vector4F_0)
	{
		return Divide(float_0, vector4F_0);
	}

	public static explicit operator float[](Vector4F vector4F_0)
	{
		return new float[4] { vector4F_0.X, vector4F_0.Y, vector4F_0.Z, vector4F_0.W };
	}

	public static explicit operator List<float>(Vector4F vector4F_0)
	{
		return new List<float>(4) { vector4F_0.X, vector4F_0.Y, vector4F_0.Z, vector4F_0.W };
	}

	public static explicit operator LinkedList<float>(Vector4F vector4F_0)
	{
		LinkedList<float> linkedList = new LinkedList<float>();
		linkedList.AddLast(vector4F_0.X);
		linkedList.AddLast(vector4F_0.Y);
		linkedList.AddLast(vector4F_0.Z);
		linkedList.AddLast(vector4F_0.W);
		return linkedList;
	}

	static Vector4F()
	{
		Zero = new Vector4F(0f, 0f, 0f, 0f);
		XAxis = new Vector4F(1f, 0f, 0f, 0f);
		YAxis = new Vector4F(0f, 1f, 0f, 0f);
		ZAxis = new Vector4F(0f, 0f, 1f, 0f);
		WAxis = new Vector4F(0f, 0f, 0f, 1f);
	}
}
