using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(RayConverter))]
public struct Ray : ICloneable
{
	private Vector2D vector2D_0;

	private Vector2D vector2D_1;

	public Vector2D Origin
	{
		get
		{
			return vector2D_0;
		}
		set
		{
			vector2D_0 = value;
		}
	}

	public Vector2D Direction
	{
		get
		{
			return vector2D_1;
		}
		set
		{
			vector2D_1 = value;
		}
	}

	public Ray(Vector2D vector2D_2, Vector2D vector2D_3)
	{
		vector2D_0 = vector2D_2;
		vector2D_1 = vector2D_3;
	}

	public Ray(Ray ray_0)
	{
		vector2D_0 = ray_0.Origin;
		vector2D_1 = ray_0.Direction;
	}

	object ICloneable.Clone()
	{
		return new Ray(this);
	}

	public Ray Clone()
	{
		return new Ray(this);
	}

	public static Ray Parse(string string_0)
	{
		Match match = new Regex("Ray\\(Origin=(?<origin>\\([^\\)]*\\)), Direction=(?<direction>\\([^\\)]*\\))\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Ray(Vector2D.Parse(match.Result("${origin}")), Vector2D.Parse(match.Result("${direction}")));
	}

	public Vector2D GetPointOnRay(double double_0)
	{
		return Origin + Direction * double_0;
	}

	public override int GetHashCode()
	{
		return vector2D_0.GetHashCode() ^ vector2D_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Ray ray)
		{
			if (vector2D_0 == ray.Origin)
			{
				return vector2D_1 == ray.Direction;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Ray(Origin={0}, Direction={1})", vector2D_0, vector2D_1);
	}

	public static bool operator ==(Ray ray_0, Ray ray_1)
	{
		return object.Equals(ray_0, ray_1);
	}

	public static bool operator !=(Ray ray_0, Ray ray_1)
	{
		return !object.Equals(ray_0, ray_1);
	}
}
