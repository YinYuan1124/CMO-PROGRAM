using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry3D;

[Serializable]
[TypeConverter(typeof(RayConverter))]
public struct Ray : ICloneable
{
	private Vector3F _origin;

	private Vector3F _direction;

	public Vector3F Origin
	{
		get
		{
			return _origin;
		}
		set
		{
			_origin = value;
		}
	}

	public Vector3F Direction
	{
		get
		{
			return _direction;
		}
		set
		{
			_direction = value;
		}
	}

	public Ray(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		_origin = vector3F_0;
		_direction = vector3F_1;
	}

	public Ray(Ray ray_0)
	{
		_origin = ray_0.Origin;
		_direction = ray_0.Direction;
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
		Match match = new Regex("\\((?<origin>\\([^\\)]*\\)), (?<direction>\\([^\\)]*\\))\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Ray(Vector3F.Parse(match.Result("${origin}")), Vector3F.Parse(match.Result("${direction}")));
	}

	public Vector3F GetPointOnRay(float float_0)
	{
		return Origin + Direction * float_0;
	}

	public override int GetHashCode()
	{
		return _origin.GetHashCode() ^ _direction.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Ray ray)
		{
			if (_origin == ray.Origin)
			{
				return _direction == ray.Direction;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", _origin, _direction);
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
