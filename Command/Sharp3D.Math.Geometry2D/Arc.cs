using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using CSMaterial;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(SegmentConverter))]
public struct Arc : ICloneable
{
	private Vector2D vector2D_0;

	private double double_0;

	private double double_1;

	private double double_2;

	public Vector2D Center
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

	public double Radius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Angle0
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double Angle1
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public Vector2D P0 => PointAtAngle(double_1);

	public Vector2D P1 => PointAtAngle(double_2);

	public Arc(Vector2D vector2D_1, float float_0, float float_1, float float_2)
	{
		vector2D_0 = vector2D_1;
		double_0 = float_0;
		double_1 = float_1;
		double_2 = float_2;
	}

	public Arc(Arc arc_0)
	{
		vector2D_0 = arc_0.vector2D_0;
		double_0 = arc_0.double_0;
		double_1 = arc_0.double_1;
		double_2 = arc_0.double_2;
	}

	public void Transform(Transform2D transform2D_0)
	{
		Vector2D vector2D_ = transform2D_0.transform(P0);
		Vector2D vector2D_2 = transform2D_0.transform(P1);
		vector2D_0 = transform2D_0.transform(vector2D_0);
		double_1 = AngleAtPoint(vector2D_);
		double_2 = AngleAtPoint(vector2D_2);
	}

	public Vector2D PointAtAngle(double double_3)
	{
		double num = double_3 * CSMath.PI_dividedBy_180;
		return vector2D_0 + double_0 * new Vector2D(System.Math.Cos(num), System.Math.Sin(num));
	}

	public double AngleAtPoint(Vector2D vector2D_1)
	{
		Vector2D vector2D = vector2D_1 - vector2D_0;
		if (vector2D.X <= 0.0)
		{
			if (vector2D.Y <= 0.0)
			{
				return 180.0 * ((System.Math.PI - System.Math.Acos((0.0 - vector2D.Y) / vector2D.GetLength())) / System.Math.PI);
			}
			return 180.0 * ((System.Math.PI + System.Math.Asin(vector2D.Y / vector2D.GetLength())) / System.Math.PI);
		}
		return -180.0 * (System.Math.Asin(vector2D.Y / vector2D.GetLength()) / System.Math.PI);
	}

	public List<Segment> Explode(int int_0)
	{
		List<Segment> list = new List<Segment>();
		double num = (double_2 - double_1) / (double)int_0;
		for (int i = 0; i < int_0; i++)
		{
			list.Add(new Segment(PointAtAngle(double_1 + (double)i * num), PointAtAngle(double_1 + (double)(i + 1) * num)));
		}
		return list;
	}

	object ICloneable.Clone()
	{
		return new Arc(this);
	}

	public Arc Clone()
	{
		return new Arc(this);
	}

	public static Arc Parse(string string_0)
	{
		Match match = new Regex("\\((?<pC>\\([^\\)]*\\)), (?<r>\\([^\\)]*\\)), (?<a0>\\([^\\)]*\\)), ((?<a1>\\([^\\)]*\\))\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Arc(Vector2D.Parse(match.Result("${pC}")), float.Parse(match.Result("${r}")), float.Parse(match.Result("${a0}")), float.Parse(match.Result("${a1}")));
	}

	public override int GetHashCode()
	{
		return vector2D_0.GetHashCode() ^ double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Arc arc)
		{
			if (vector2D_0 == arc.vector2D_0 && double_0 == arc.double_0 && double_1 == arc.double_1)
			{
				return double_2 == arc.double_2;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Arc(Center={0}, Radius={1}, Angle0={2}, Angle1={3})", vector2D_0, double_1, double_2);
	}

	public static bool operator ==(Arc arc_0, Arc arc_1)
	{
		return object.Equals(arc_0, arc_1);
	}

	public static bool operator !=(Arc arc_0, Arc arc_1)
	{
		return !object.Equals(arc_0, arc_1);
	}
}
