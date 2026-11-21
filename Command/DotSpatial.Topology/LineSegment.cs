using System;
using System.Text;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology;

[Serializable]
public class LineSegment : IComparable, ILineSegment, ILineSegmentBase
{
	private Coordinate _p0;

	private Coordinate _p1;

	public virtual Coordinate P1
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

	public virtual Coordinate P0
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

	public virtual double Length => new Coordinate(_p0).Distance(P1);

	public virtual bool IsHorizontal => P0.Y == P1.Y;

	public virtual bool IsVertical => P0.X == P1.X;

	public virtual double Angle => Math.Atan2(P1.Y - P0.Y, P1.X - P0.X);

	public LineSegment(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		_p0 = coordinate_0;
		_p1 = coordinate_1;
	}

	public LineSegment(ILineSegmentBase ilineSegmentBase_0)
		: this(ilineSegmentBase_0.P0, ilineSegmentBase_0.P1)
	{
	}

	public LineSegment()
		: this(new Coordinate(), new Coordinate())
	{
	}

	public virtual Coordinate GetCoordinate(int int_0)
	{
		if (int_0 == 0)
		{
			return new Coordinate(_p0);
		}
		return new Coordinate(_p1);
	}

	public virtual void SetCoordinates(ILineSegmentBase ilineSegmentBase_0)
	{
		SetCoordinates(ilineSegmentBase_0.P0, ilineSegmentBase_0.P1);
	}

	public virtual void SetCoordinates(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		P0.X = coordinate_0.X;
		P0.Y = coordinate_0.Y;
		P1.X = coordinate_1.X;
		P1.Y = coordinate_1.Y;
	}

	public virtual int OrientationIndex(ILineSegmentBase ilineSegmentBase_0)
	{
		int num = CgAlgorithms.OrientationIndex(P0, P1, ilineSegmentBase_0.P0);
		int num2 = CgAlgorithms.OrientationIndex(P0, P1, ilineSegmentBase_0.P1);
		if (num >= 0 && num2 >= 0)
		{
			return Math.Max(num, num2);
		}
		if (num <= 0 && num2 <= 0)
		{
			return Math.Max(num, num2);
		}
		return 0;
	}

	public virtual void Reverse()
	{
		Coordinate p = P0;
		P0 = P1;
		P1 = p;
	}

	public virtual void Normalize()
	{
		if (new Coordinate(P1).CompareTo(P0) < 0)
		{
			Reverse();
		}
	}

	public virtual double Distance(ILineSegmentBase ilineSegmentBase_0)
	{
		return CgAlgorithms.DistanceLineLine(P0, P1, new Coordinate(ilineSegmentBase_0.P0), new Coordinate(ilineSegmentBase_0.P1));
	}

	public virtual double Distance(Coordinate coordinate_0)
	{
		return CgAlgorithms.DistancePointLine(new Coordinate(coordinate_0), P0, P1);
	}

	public virtual double DistancePerpendicular(Coordinate coordinate_0)
	{
		return CgAlgorithms.DistancePointLinePerpendicular(new Coordinate(coordinate_0), P0, P1);
	}

	public virtual double ProjectionFactor(Coordinate coordinate_0)
	{
		if (coordinate_0.Equals(P0))
		{
			return 0.0;
		}
		if (coordinate_0.Equals(P1))
		{
			return 1.0;
		}
		double num = P1.X - P0.X;
		double num2 = P1.Y - P0.Y;
		double num3 = num * num + num2 * num2;
		return ((coordinate_0.X - P0.X) * num + (coordinate_0.Y - P0.Y) * num2) / num3;
	}

	public virtual Coordinate Project(Coordinate coordinate_0)
	{
		if (!coordinate_0.Equals(P0) && !coordinate_0.Equals(P1))
		{
			double num = ProjectionFactor(coordinate_0);
			return new Coordinate
			{
				X = P0.X + num * (P1.X - P0.X),
				Y = P0.Y + num * (P1.Y - P0.Y)
			};
		}
		return new Coordinate(coordinate_0);
	}

	public virtual ILineSegment Project(ILineSegmentBase ilineSegmentBase_0)
	{
		double num = ProjectionFactor(ilineSegmentBase_0.P0);
		double num2 = ProjectionFactor(ilineSegmentBase_0.P1);
		if (!(num < 1.0) && num2 >= 1.0)
		{
			return null;
		}
		if (num <= 0.0 && num2 <= 0.0)
		{
			return null;
		}
		Coordinate coordinate_ = Project(ilineSegmentBase_0.P0);
		if (num < 0.0)
		{
			coordinate_ = P0;
		}
		if (num > 1.0)
		{
			coordinate_ = P1;
		}
		Coordinate coordinate_2 = Project(ilineSegmentBase_0.P1);
		if (num2 < 0.0)
		{
			coordinate_2 = P0;
		}
		if (num2 > 1.0)
		{
			coordinate_2 = P1;
		}
		return new LineSegment(coordinate_, coordinate_2);
	}

	public virtual Coordinate ClosestPoint(Coordinate coordinate_0)
	{
		double num = ProjectionFactor(coordinate_0);
		if (num > 0.0 && num < 1.0)
		{
			return Project(coordinate_0);
		}
		double num2 = new Coordinate(_p0).Distance(coordinate_0);
		double num3 = new Coordinate(P1).Distance(coordinate_0);
		if (num2 < num3)
		{
			return new Coordinate(_p0);
		}
		return new Coordinate(_p1);
	}

	public virtual Coordinate[] ClosestPoints(ILineSegmentBase ilineSegmentBase_0)
	{
		LineSegment lineSegment = new LineSegment(ilineSegmentBase_0);
		Coordinate coordinate = Intersection(ilineSegmentBase_0);
		if (coordinate == null)
		{
			Coordinate[] array = new Coordinate[2];
			Coordinate coordinate2 = new Coordinate(ClosestPoint(ilineSegmentBase_0.P0));
			double num = coordinate2.Distance(ilineSegmentBase_0.P0);
			array[0] = coordinate2;
			array[1] = new Coordinate(ilineSegmentBase_0.P0);
			Coordinate coordinate3 = new Coordinate(ClosestPoint(ilineSegmentBase_0.P1));
			double num2 = coordinate3.Distance(ilineSegmentBase_0.P1);
			if (num2 < num)
			{
				num = num2;
				array[0] = coordinate3;
				array[1] = new Coordinate(ilineSegmentBase_0.P1);
			}
			Coordinate coordinate4 = new Coordinate(lineSegment.ClosestPoint(P0));
			num2 = coordinate4.Distance(P0);
			if (num2 < num)
			{
				num = num2;
				array[0] = new Coordinate(P0);
				array[1] = coordinate4;
			}
			Coordinate coordinate5 = new Coordinate(lineSegment.ClosestPoint(P1));
			num2 = coordinate5.Distance(P1);
			if (num2 < num)
			{
				array[0] = new Coordinate(P1);
				array[1] = coordinate5;
			}
			return array;
		}
		return new Coordinate[2] { coordinate, coordinate };
	}

	public virtual Coordinate Intersection(ILineSegmentBase ilineSegmentBase_0)
	{
		LineIntersector lineIntersector = new RobustLineIntersector();
		lineIntersector.ComputeIntersection(P0, P1, new Coordinate(ilineSegmentBase_0.P0), new Coordinate(ilineSegmentBase_0.P1));
		if (lineIntersector.HasIntersection)
		{
			return lineIntersector.GetIntersection(0);
		}
		return null;
	}

	public ILineSegment Intersection(Envelope envelope_0)
	{
		return envelope_0.Intersection(this);
	}

	public bool Intersects(Envelope envelope_0)
	{
		return envelope_0.Intersects(this);
	}

	public virtual int CompareTo(object target)
	{
		ILineSegmentBase lineSegmentBase = (ILineSegmentBase)target;
		int num = new Coordinate(_p0).CompareTo(lineSegmentBase.P0);
		if (num == 0)
		{
			return new Coordinate(_p1).CompareTo(lineSegmentBase.P1);
		}
		return num;
	}

	public virtual bool EqualsTopologically(ILineSegmentBase ilineSegmentBase_0)
	{
		if (new Coordinate(_p0).Equals(ilineSegmentBase_0.P0) && new Coordinate(_p1).Equals(ilineSegmentBase_0.P1))
		{
			return true;
		}
		if (new Coordinate(_p0).Equals(ilineSegmentBase_0.P1))
		{
			return new Coordinate(_p1).Equals(ilineSegmentBase_0.P0);
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("LINESTRING( ");
		stringBuilder.Append(P0.X).Append(" ");
		stringBuilder.Append(P0.Y).Append(", ");
		stringBuilder.Append(P1.X).Append(" ");
		stringBuilder.Append(P1.Y).Append(")");
		return stringBuilder.ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is ILineSegmentBase)
		{
			ILineSegmentBase lineSegmentBase = (ILineSegmentBase)obj;
			if (_p0.X == lineSegmentBase.P0.X && _p0.Y == lineSegmentBase.P0.Y && _p1.X == lineSegmentBase.P1.X)
			{
				return _p1.Y == lineSegmentBase.P1.Y;
			}
			return false;
		}
		return false;
	}

	public static bool operator ==(LineSegment lineSegment_0, ILineSegmentBase ilineSegmentBase_0)
	{
		return object.Equals(lineSegment_0, ilineSegmentBase_0);
	}

	public static bool operator !=(LineSegment lineSegment_0, ILineSegmentBase ilineSegmentBase_0)
	{
		return !(lineSegment_0 == ilineSegmentBase_0);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
