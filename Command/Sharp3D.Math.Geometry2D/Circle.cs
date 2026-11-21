using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(CircleConverter))]
public struct Circle : ICloneable
{
	private Vector2F center;

	private float radius;

	public static readonly Circle UnitCircle;

	public Vector2F Center
	{
		get
		{
			return center;
		}
		set
		{
			center = value;
		}
	}

	public float Radius
	{
		get
		{
			return radius;
		}
		set
		{
			radius = value;
		}
	}

	public Circle(Vector2F vector2F_0, float float_0)
	{
		center = vector2F_0;
		radius = float_0;
	}

	public Circle(Circle circle_0)
	{
		center = circle_0.center;
		radius = circle_0.radius;
	}

	object ICloneable.Clone()
	{
		return new Circle(this);
	}

	public Circle Clone()
	{
		return new Circle(this);
	}

	public static Circle Parse(string string_0)
	{
		Match match = new Regex("Circle\\(Center=(?<center>\\([^\\)]*\\)), Radius=(?<radius>.*)\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Circle(Vector2F.Parse(match.Result("${center}")), float.Parse(match.Result("${radius}")));
	}

	public override int GetHashCode()
	{
		return center.GetHashCode() ^ radius.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Circle circle)
		{
			if (center == circle.center)
			{
				return radius == circle.radius;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", center, radius);
	}

	public float GetArea()
	{
		return (float)System.Math.PI * radius * radius;
	}

	static Circle()
	{
		UnitCircle = new Circle(new Vector2F(0f, 0f), 1f);
	}
}
