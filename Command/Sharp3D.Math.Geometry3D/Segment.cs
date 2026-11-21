using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry3D;

[Serializable]
[TypeConverter(typeof(SegmentConverter))]
public struct Segment : ICloneable
{
	private Vector3F _p0;

	private Vector3F _p1;

	public Vector3F P0
	{
		get
		{
			return _p0;
		}
		set
		{
			_p0 = value;
		}
	}

	public Vector3F P1
	{
		get
		{
			return _p1;
		}
		set
		{
			_p1 = value;
		}
	}

	public Segment(Vector3F vector3F_0, Vector3F vector3F_1)
	{
		_p0 = vector3F_0;
		_p1 = vector3F_1;
	}

	public Segment(Segment segment_0)
	{
		_p0 = segment_0.P0;
		_p1 = segment_0.P1;
	}

	object ICloneable.Clone()
	{
		return new Segment(this);
	}

	public Segment Clone()
	{
		return new Segment(this);
	}

	public static Segment Parse(string string_0)
	{
		Match match = new Regex("\\((?<p0>\\([^\\)]*\\)), (?<p1>\\([^\\)]*\\))\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Segment(Vector3F.Parse(match.Result("${p0}")), Vector3F.Parse(match.Result("${p1}")));
	}

	public override int GetHashCode()
	{
		return _p0.GetHashCode() ^ _p1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Segment segment)
		{
			if (_p0 == segment.P0)
			{
				return _p1 == segment.P1;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Segment(P0={0}, P1={1})", _p0, _p1);
	}

	public static bool operator ==(Segment segment_0, Segment segment_1)
	{
		return object.Equals(segment_0, segment_1);
	}

	public static bool operator !=(Segment segment_0, Segment segment_1)
	{
		return !object.Equals(segment_0, segment_1);
	}
}
