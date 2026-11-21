using System;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Operation;

namespace DotSpatial.Topology;

[Serializable]
public class LineString : Geometry, ICloneable, IComparable, IBasicGeometry, IBasicLineString, IGeometry, IOverlay, IRelate, ILineString
{
	public static readonly ILineString Empty;

	private IList<Coordinate> _points;

	public virtual int Count => _points.Count;

	public virtual Coordinate this[int int_0]
	{
		get
		{
			return _points[int_0];
		}
		set
		{
			_points[int_0] = value;
		}
	}

	public virtual double Angle
	{
		get
		{
			double num = EndPoint.X - StartPoint.X;
			double num2 = EndPoint.Y - StartPoint.Y;
			double num3 = Math.Sqrt(num * num + num2 * num2);
			double num4 = Math.Asin(Math.Abs(EndPoint.Y - StartPoint.Y) / num3) * 180.0 / Math.PI;
			if ((StartPoint.X < EndPoint.X && StartPoint.Y > EndPoint.Y) || (StartPoint.X > EndPoint.X && StartPoint.Y < EndPoint.Y))
			{
				num4 = 360.0 - num4;
			}
			return num4;
		}
	}

	public override IGeometry Boundary
	{
		get
		{
			if (IsEmpty)
			{
				return base.Factory.CreateGeometryCollection(null);
			}
			if (IsClosed)
			{
				return MultiPoint.Empty;
			}
			return base.Factory.CreateMultiPoint(new Coordinate[2] { StartPoint.Coordinate, EndPoint.Coordinate });
		}
	}

	public override DimensionType BoundaryDimension
	{
		get
		{
			if (IsClosed)
			{
				return DimensionType.False;
			}
			return DimensionType.Point;
		}
	}

	public override Coordinate Coordinate
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return _points.First();
		}
	}

	public override IList<Coordinate> Coordinates
	{
		get
		{
			return _points;
		}
		set
		{
			if (value.GetType().IsArray)
			{
				_points = value.ToList();
			}
			else
			{
				_points = value;
			}
		}
	}

	public override DimensionType Dimension => DimensionType.Curve;

	public virtual IPoint EndPoint
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return GetPointN(NumPoints - 1);
		}
	}

	public override FeatureType FeatureType => FeatureType.Line;

	public override string GeometryType => "LineString";

	public virtual bool IsClosed
	{
		get
		{
			if (IsEmpty)
			{
				return false;
			}
			return new Coordinate(GetCoordinateN(0)).Equals2D(GetCoordinateN(NumPoints - 1));
		}
	}

	public override bool IsEmpty => _points.Count == 0;

	public virtual bool IsRing
	{
		get
		{
			if (IsClosed)
			{
				return IsSimple;
			}
			return false;
		}
	}

	public override bool IsSimple => new IsSimpleOp().IsSimple(this);

	public override double Length => CgAlgorithms.Length(_points);

	public override int NumPoints => _points.Count;

	public virtual IPoint StartPoint
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return GetPointN(0);
		}
	}

	public LineString(IList<Coordinate> ilist_0, IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		if (ilist_0 == null)
		{
			ilist_0 = new List<Coordinate>();
		}
		if (ilist_0.Count == 1)
		{
			throw new ArgumentException("point array must contain 0 or > 1 elements");
		}
		if (ilist_0.GetType().IsArray)
		{
			_points = ilist_0.ToList();
		}
		else
		{
			_points = ilist_0;
		}
	}

	public LineString(IList<Coordinate> ilist_0)
		: this(ilist_0, Geometry.DefaultFactory)
	{
	}

	public LineString(IBasicLineString ibasicLineString_0)
		: this(ibasicLineString_0.Coordinates, Geometry.DefaultFactory)
	{
	}

	public LineString(IBasicLineString ibasicLineString_0, IGeometryFactory igeometryFactory_0)
		: this(ibasicLineString_0.Coordinates, igeometryFactory_0)
	{
	}

	public LineString(IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		_points = new List<Coordinate>();
	}

	public LineString(IEnumerable<Coordinate> ienumerable_0)
		: base(Geometry.DefaultFactory)
	{
		if (ienumerable_0 == null)
		{
			_points = new List<Coordinate>();
			return;
		}
		if (!ienumerable_0.GetType().IsArray)
		{
			_points = ienumerable_0 as IList<Coordinate>;
			if (_points != null)
			{
				return;
			}
		}
		_points = new List<Coordinate>();
		foreach (Coordinate item in ienumerable_0)
		{
			_points.Add(item);
		}
	}

	public LineString(IEnumerable<ICoordinate> ienumerable_0)
		: base(Geometry.DefaultFactory)
	{
		if (ienumerable_0 == null)
		{
			_points = new List<Coordinate>();
			return;
		}
		if (!ienumerable_0.GetType().IsArray)
		{
			_points = ienumerable_0 as IList<Coordinate>;
			if (_points != null)
			{
				return;
			}
		}
		_points = new List<Coordinate>();
		foreach (ICoordinate item in ienumerable_0)
		{
			_points.Add(new Coordinate(item));
		}
	}

	public override void Apply(ICoordinateFilter icoordinateFilter_0)
	{
		foreach (Coordinate point in _points)
		{
			icoordinateFilter_0.Filter(point);
		}
	}

	public override void Apply(IGeometryFilter igeometryFilter_0)
	{
		igeometryFilter_0.Filter(this);
	}

	public override void Apply(IGeometryComponentFilter igeometryComponentFilter_0)
	{
		igeometryComponentFilter_0.Filter(this);
	}

	public override int CompareToSameClass(object object_0)
	{
		LineString lineString = object_0 as LineString;
		int num = 0;
		int num2 = 0;
		if (lineString != null)
		{
			while (num < _points.Count && num2 < lineString._points.Count)
			{
				int num3 = _points[num].CompareTo(lineString._points[num2]);
				if (num3 == 0)
				{
					num++;
					num2++;
					continue;
				}
				return num3;
			}
		}
		if (num < _points.Count)
		{
			return 1;
		}
		if (lineString != null && num2 < lineString._points.Count)
		{
			return -1;
		}
		return 0;
	}

	public override bool EqualsExact(IGeometry igeometry_0, double double_0)
	{
		if (IsEquivalentClass(igeometry_0))
		{
			LineString lineString = (LineString)igeometry_0;
			if (_points.Count == lineString._points.Count)
			{
				for (int i = 0; i < _points.Count; i++)
				{
					if (!Equal(new Coordinate(_points[i]), lineString._points[i], double_0))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public override Coordinate ClosestPoint(Coordinate coordinate_0)
	{
		Coordinate result = Coordinate;
		double num = double.MaxValue;
		for (int i = 0; i < _points.Count - 1; i++)
		{
			Coordinate coordinate = new LineSegment(_points[i], _points[i + 1]).ClosestPoint(coordinate_0);
			double num2 = coordinate_0.Distance(coordinate);
			if (num2 < num)
			{
				num = num2;
				result = coordinate;
			}
		}
		return result;
	}

	public virtual IPoint GetPointN(int int_0)
	{
		return new Point(_points[int_0]);
	}

	public virtual bool IsCoordinate(Coordinate coordinate_0)
	{
		Coordinate coordinate = new Coordinate(coordinate_0);
		for (int i = 0; i < _points.Count; i++)
		{
			if (coordinate == _points[i])
			{
				return true;
			}
		}
		return false;
	}

	public override void Normalize()
	{
		int num = 0;
		int index;
		while (true)
		{
			if (num < _points.Count / 2)
			{
				index = _points.Count - 1 - num;
				if (!_points[num].Equals(_points[index]))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		if (_points[num].CompareTo(_points[index]) > 0)
		{
			_points = _points.Reverse().ToList();
		}
	}

	public virtual ILineString Reverse()
	{
		List<Coordinate> list = Coordinates.CloneList();
		list.Reverse();
		return new LineString(list);
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		if (IsEmpty)
		{
			return new Envelope();
		}
		double num = _points[0].X;
		double num2 = _points[0].Y;
		double num3 = _points[0].X;
		double num4 = _points[0].Y;
		for (int i = 1; i < _points.Count; i++)
		{
			num = ((num < _points[i].X) ? num : _points[i].X);
			num3 = ((num3 <= _points[i].X) ? _points[i].X : num3);
			num2 = ((num2 < _points[i].Y) ? num2 : _points[i].Y);
			num4 = ((num4 <= _points[i].Y) ? _points[i].Y : num4);
		}
		return new Envelope(num, num3, num2, num4);
	}

	protected override void OnCopy(Geometry geometry_0)
	{
		base.OnCopy(geometry_0);
		if (!(geometry_0 is LineString lineString))
		{
			return;
		}
		lineString.Coordinates = new List<Coordinate>();
		foreach (Coordinate point in _points)
		{
			lineString.Coordinates.Add(point);
		}
	}

	public virtual Coordinate GetCoordinateN(int int_0)
	{
		return _points[int_0];
	}

	protected override bool IsEquivalentClass(IGeometry igeometry_0)
	{
		return igeometry_0 is LineString;
	}

	public ILineString Offset(double double_0)
	{
		if (double_0 != 0.0)
		{
			throw new NotImplementedException("This is not yet implemented");
		}
		return this.Copy();
	}

	public override void Rotate(Coordinate coordinate_0, double double_0)
	{
		for (int i = 0; i < _points.Count; i++)
		{
			RotateCoordinateRad(coordinate_0, ref _points[i].X, ref _points[i].Y, double_0);
		}
	}

	static LineString()
	{
		Empty = new GeometryFactory().CreateLineString(new List<Coordinate>());
	}
}
