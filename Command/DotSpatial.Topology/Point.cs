using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

[Serializable]
public class Point : Geometry, ICloneable, IComparable, IBasicGeometry, IBasicPoint, ICoordinate, IGeometry, IOverlay, IRelate, IPoint
{
	private IList<Coordinate> _coordinates = new List<Coordinate>();

	private int _recordNumber;

	public static readonly IPoint Empty;

	public double this[int int_0]
	{
		get
		{
			return Coordinate[int_0];
		}
		set
		{
			Coordinate[int_0] = value;
		}
	}

	public int RecordNumber
	{
		get
		{
			return _recordNumber;
		}
		set
		{
			_recordNumber = value;
		}
	}

	public override IGeometry Boundary => base.Factory.CreateGeometryCollection(null);

	public override DimensionType BoundaryDimension => DimensionType.False;

	public override Coordinate Coordinate
	{
		get
		{
			if (_coordinates == null)
			{
				_coordinates = new List<Coordinate>();
			}
			if (_coordinates.Count == 0)
			{
				_coordinates.Add(new Coordinate());
			}
			return _coordinates[0];
		}
	}

	public override IList<Coordinate> Coordinates
	{
		get
		{
			return _coordinates;
		}
		set
		{
			_coordinates = value;
		}
	}

	public override DimensionType Dimension => DimensionType.Point;

	public int NumOrdinates => Coordinate.NumOrdinates;

	public new IEnvelope Envelope => new Envelope(X, X, Y, Y);

	public override FeatureType FeatureType => FeatureType.Point;

	public override string GeometryType => "Point";

	public override bool IsEmpty => Coordinate == null;

	public override bool IsSimple => true;

	public override bool IsValid => true;

	public virtual double M
	{
		get
		{
			if (Coordinate == null)
			{
				throw new ArgumentOutOfRangeException();
			}
			return Coordinate.M;
		}
		set
		{
			Coordinate.M = value;
		}
	}

	public override int NumPoints
	{
		get
		{
			if (!IsEmpty)
			{
				return 1;
			}
			return 0;
		}
	}

	public double[] Values
	{
		get
		{
			return Coordinate.ToArray();
		}
		set
		{
			SetCoordinate(new Coordinate(value));
		}
	}

	public virtual double X
	{
		get
		{
			return Coordinate.X;
		}
		set
		{
			Coordinate.X = value;
		}
	}

	public virtual double Y
	{
		get
		{
			return Coordinate.Y;
		}
		set
		{
			Coordinate.Y = value;
		}
	}

	public virtual double Z
	{
		get
		{
			return Coordinate.Z;
		}
		set
		{
			Coordinate.Z = value;
		}
	}

	public Point()
	{
		_coordinates.Add(new Coordinate());
	}

	public Point(IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		_coordinates.Add(new Coordinate());
	}

	public Point(Coordinate coordinate_0)
		: this(coordinate_0, new GeometryFactory())
	{
	}

	public Point(ICoordinate icoordinate_0)
		: this(new Coordinate(icoordinate_0), new GeometryFactory())
	{
	}

	public Point(Coordinate coordinate_0, IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		_coordinates.Add(coordinate_0);
	}

	public Point(double double_0, double double_1, double double_2)
		: this(new Coordinate(double_0, double_1, double_2), Geometry.DefaultFactory)
	{
	}

	public Point(double double_0, double double_1)
		: this(new Coordinate(double_0, double_1), Geometry.DefaultFactory)
	{
	}

	public override void Apply(ICoordinateFilter icoordinateFilter_0)
	{
		if (!IsEmpty)
		{
			icoordinateFilter_0.Filter(Coordinate);
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
		Point point = (Point)object_0;
		return Coordinate.CompareTo(point.Coordinate);
	}

	public override Coordinate ClosestPoint(Coordinate coordinate_0)
	{
		return Coordinate;
	}

	public override bool EqualsExact(IGeometry igeometry_0, double double_0)
	{
		if (IsEquivalentClass(igeometry_0))
		{
			if (IsEmpty && igeometry_0.IsEmpty)
			{
				return true;
			}
			return Equal(new Coordinate(igeometry_0.Coordinate), Coordinate, double_0);
		}
		return false;
	}

	public override void Normalize()
	{
	}

	protected override void OnCopy(Geometry geometry_0)
	{
		base.OnCopy(geometry_0);
		if (geometry_0 is Point point)
		{
			point.SetCoordinate(Coordinate.Copy());
		}
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		if (IsEmpty)
		{
			return new Envelope();
		}
		return new Envelope(Coordinate.X, Coordinate.X, Coordinate.Y, Coordinate.Y);
	}

	public double Distance(Coordinate coordinate_0)
	{
		double num = X - coordinate_0.X;
		double num2 = Y - coordinate_0.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public double HyperDistance(Coordinate coordinate_0)
	{
		if (coordinate_0.NumOrdinates == NumOrdinates)
		{
			double num = 0.0;
			double[] array = coordinate_0.ToArray();
			for (int i = 0; i < NumOrdinates; i++)
			{
				double num2 = array[i] - Coordinate[i];
				num += num2 * num2;
			}
			return Math.Sqrt(num);
		}
		throw new CoordinateMismatchException();
	}

	public bool Equals2D(Coordinate coordinate_0)
	{
		if (X == coordinate_0.X && Y == coordinate_0.Y)
		{
			return true;
		}
		return false;
	}

	public bool Equals3D(Coordinate coordinate_0)
	{
		if (X == coordinate_0.X && Y == coordinate_0.Y && Z == coordinate_0.Z)
		{
			return true;
		}
		return false;
	}

	public override void Rotate(Coordinate coordinate_0, double double_0)
	{
		RotateCoordinateRad(coordinate_0, ref Coordinate.X, ref Coordinate.Y, double_0);
	}

	public void SetCoordinate(Coordinate coordinate_0)
	{
		if (_coordinates == null)
		{
			_coordinates = new List<Coordinate>();
		}
		if (_coordinates.Count == 0)
		{
			_coordinates.Add(coordinate_0);
		}
		else
		{
			_coordinates[0] = coordinate_0;
		}
	}

	public double[] ToArray()
	{
		return Coordinate.ToArray();
	}

	static Point()
	{
		Empty = new GeometryFactory().CreatePoint(null);
	}
}
