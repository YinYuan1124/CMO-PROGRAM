using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(OrientedBoxConverter))]
public struct OrientedBox : ICloneable
{
	private Vector2F _center;

	private Vector2F _axis1;

	private Vector2F _axis2;

	private float _extent1;

	private float _extent2;

	public Vector2F Center
	{
		get
		{
			return _center;
		}
		set
		{
			_center = value;
		}
	}

	public Vector2F Axis1
	{
		get
		{
			return _axis1;
		}
		set
		{
			_axis1 = value;
		}
	}

	public Vector2F Axis2
	{
		get
		{
			return _axis2;
		}
		set
		{
			_axis2 = value;
		}
	}

	public float Extent1
	{
		get
		{
			return _extent1;
		}
		set
		{
			_extent1 = value;
		}
	}

	public float Extent2
	{
		get
		{
			return _extent2;
		}
		set
		{
			_extent2 = value;
		}
	}

	public OrientedBox(Vector2F vector2F_0, Vector2F vector2F_1, Vector2F vector2F_2, float float_0, float float_1)
	{
		_center = vector2F_0;
		_axis1 = vector2F_1;
		_axis2 = vector2F_2;
		_extent1 = float_0;
		_extent2 = float_1;
	}

	public OrientedBox(Vector2F vector2F_0, Vector2F[] vector2F_1, float[] float_0)
	{
		_center = vector2F_0;
		_axis1 = vector2F_1[0];
		_axis2 = vector2F_1[1];
		_extent1 = float_0[0];
		_extent2 = float_0[1];
	}

	public OrientedBox(OrientedBox orientedBox_0)
	{
		_center = orientedBox_0.Center;
		_axis1 = orientedBox_0.Axis1;
		_axis2 = orientedBox_0.Axis2;
		_extent1 = orientedBox_0.Extent1;
		_extent2 = orientedBox_0.Extent2;
	}

	object ICloneable.Clone()
	{
		return new OrientedBox(this);
	}

	public OrientedBox Clone()
	{
		return new OrientedBox(this);
	}

	public static OrientedBox Parse(string string_0)
	{
		Match match = new Regex("OrientedBox\\(Center=(?<center>\\([^\\)]*\\)), Axis1=(?<axis1>\\([^\\)]*\\)), Axis2=(?<axis2>\\([^\\)]*\\)), Extent1=(?<extent1>.*), Extent2=(?<extent2>.*)\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new OrientedBox(Vector2F.Parse(match.Result("${center}")), Vector2F.Parse(match.Result("${axis1}")), Vector2F.Parse(match.Result("${axis2}")), float.Parse(match.Result("${extent1}")), float.Parse(match.Result("${extent2}")));
	}

	public Vector2F[] ComputeVertices()
	{
		Vector2F[] array = new Vector2F[4];
		Vector2F[] array2 = new Vector2F[2]
		{
			Axis1 * Extent1,
			Axis2 * Extent2
		};
		array[0] = Center - array2[0] - array2[1];
		array[1] = Center + array2[0] - array2[1];
		array[2] = Center + array2[0] + array2[1];
		array[3] = Center - array2[0] + array2[1];
		return array;
	}

	public override int GetHashCode()
	{
		return _center.GetHashCode() ^ _axis1.GetHashCode() ^ _axis2.GetHashCode() ^ _extent1.GetHashCode() ^ _extent2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is OrientedBox orientedBox)
		{
			if (_center == orientedBox.Center && _axis1 == orientedBox.Axis1 && _axis2 == orientedBox.Axis2 && _extent1 == orientedBox.Extent1)
			{
				return _extent2 == orientedBox.Extent2;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "OrientedBox(Center={0}, Axis1={1}, Axis2={2}, Extent1={3}, Extent2={4})", Center, Axis1, Axis2, Extent1, Extent2);
	}

	public static bool operator ==(OrientedBox orientedBox_0, OrientedBox orientedBox_1)
	{
		return object.Equals(orientedBox_0, orientedBox_1);
	}

	public static bool operator !=(OrientedBox orientedBox_0, OrientedBox orientedBox_1)
	{
		return object.Equals(orientedBox_0, orientedBox_1);
	}
}
