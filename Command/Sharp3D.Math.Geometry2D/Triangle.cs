using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(TriangleConverter))]
public struct Triangle : ICloneable
{
	private Vector2F vector2F_0;

	private Vector2F vector2F_1;

	private Vector2F vector2F_2;

	public Vector2F Point0
	{
		get
		{
			return vector2F_0;
		}
		set
		{
			vector2F_0 = value;
		}
	}

	public Vector2F Point1
	{
		get
		{
			return vector2F_1;
		}
		set
		{
			vector2F_1 = value;
		}
	}

	public Vector2F Point2
	{
		get
		{
			return vector2F_2;
		}
		set
		{
			vector2F_2 = value;
		}
	}

	public Ordering Ordering
	{
		get
		{
			float determinant = new Matrix3F(1f, 1f, 1f, vector2F_0.X, vector2F_1.X, vector2F_2.X, vector2F_0.Y, vector2F_1.Y, vector2F_2.Y).GetDeterminant();
			if (determinant <= 0f)
			{
				if (determinant < 0f)
				{
					return Ordering.Clockwise;
				}
				return Ordering.None;
			}
			return Ordering.Counterclockwise;
		}
	}

	public Vector2F this[int int_0]
	{
		get
		{
			if (1 == 0)
			{
			}
			Vector2F result = int_0 switch
			{
				0 => vector2F_0, 
				1 => vector2F_1, 
				2 => vector2F_2, 
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
				vector2F_0 = value;
				break;
			case 1:
				vector2F_1 = value;
				break;
			case 2:
				vector2F_2 = value;
				break;
			}
		}
	}

	public Triangle(Vector2F vector2F_3, Vector2F vector2F_4, Vector2F vector2F_5)
	{
		vector2F_0 = vector2F_3;
		vector2F_1 = vector2F_4;
		vector2F_2 = vector2F_5;
	}

	public Triangle(Triangle triangle_0)
	{
		vector2F_0 = triangle_0.vector2F_0;
		vector2F_1 = triangle_0.vector2F_1;
		vector2F_2 = triangle_0.vector2F_2;
	}

	object ICloneable.Clone()
	{
		return new Triangle(this);
	}

	public Triangle Clone()
	{
		return new Triangle(this);
	}

	public static Triangle Parse(string string_0)
	{
		Match match = new Regex("\\((?<p1>\\([^\\)]*\\)), (?<p2>\\([^\\)]*\\)), (?<p3>\\([^\\)]*\\))\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Triangle(Vector2F.Parse(match.Result("${p1}")), Vector2F.Parse(match.Result("${p2}")), Vector2F.Parse(match.Result("${p3}")));
	}

	public override int GetHashCode()
	{
		return vector2F_0.GetHashCode() ^ vector2F_1.GetHashCode() ^ vector2F_2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Triangle triangle)
		{
			if (vector2F_0 == triangle.vector2F_0 && vector2F_1 == triangle.vector2F_1)
			{
				return vector2F_2 == triangle.vector2F_2;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", vector2F_0, vector2F_1, vector2F_2);
	}

	public Vector2F FromBarycentric(float float_0, float float_1)
	{
		return (1f - float_0 - float_1) * vector2F_0 + float_0 * vector2F_1 + float_1 * vector2F_2;
	}

	public float GetArea()
	{
		return 0.5f * ((vector2F_1.X - vector2F_0.X) * (vector2F_2.Y - vector2F_0.Y)) - (vector2F_2.X - vector2F_0.X) * (vector2F_1.Y - vector2F_0.Y);
	}

	public static bool operator ==(Triangle triangle_0, Triangle triangle_1)
	{
		return object.Equals(triangle_0, triangle_1);
	}

	public static bool operator !=(Triangle triangle_0, Triangle triangle_1)
	{
		return !object.Equals(triangle_0, triangle_1);
	}
}
