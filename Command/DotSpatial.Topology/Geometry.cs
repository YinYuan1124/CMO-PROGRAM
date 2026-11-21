using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Operation.Buffer;
using DotSpatial.Topology.Operation.Distance;
using DotSpatial.Topology.Operation.Overlay;
using DotSpatial.Topology.Operation.Predicate;
using DotSpatial.Topology.Operation.Relate;
using DotSpatial.Topology.Operation.Valid;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology;

[Serializable]
public abstract class Geometry : ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate
{
	private class SingletonCallbackCandidate : IGeometryComponentFilter
	{
		public void Filter(IGeometry igeometry_0)
		{
			igeometry_0.GeometryChangedAction();
		}
	}

	private readonly IGeometryFactory _factory;

	private IEnvelope _envelope;

	private int _srid;

	private object _userData;

	private static readonly Type[] SortedClasses;

	public static GeometryFactory DefaultFactory;

	private IGeometry _boundary;

	private DimensionType _boundaryDimension;

	private DimensionType _dimension;

	public virtual IGeometry EnvelopeAsGeometry => new GeometryFactory(Factory).ToGeometry(new Envelope(EnvelopeInternal));

	public IGeometryFactory Factory => _factory;

	public virtual object UserData
	{
		get
		{
			return _userData;
		}
		set
		{
			_userData = value;
		}
	}

	[Obsolete("deprecated use {getUserData} instead")]
	public virtual int Srid
	{
		get
		{
			return _srid;
		}
		set
		{
			_srid = value;
		}
	}

	public abstract string GeometryType { get; }

	public virtual PrecisionModelType PrecisionModel => Factory.PrecisionModel;

	public abstract Coordinate Coordinate { get; }

	public abstract IList<Coordinate> Coordinates { get; set; }

	public abstract int NumPoints { get; }

	public virtual int NumGeometries => 1;

	public abstract bool IsSimple { get; }

	public virtual bool IsValid => new IsValidOp(this).IsValid;

	public abstract bool IsEmpty { get; }

	public virtual double Area => 0.0;

	public virtual double Length => 0.0;

	public virtual IGeometry InteriorPoint
	{
		get
		{
			DimensionType dimension = Dimension;
			if (1 == 0)
			{
			}
			Coordinate coordinate_ = dimension switch
			{
				DimensionType.Curve => new InteriorPointLine(this).InteriorPoint, 
				DimensionType.Point => new InteriorPointPoint(this).InteriorPoint, 
				_ => new InteriorPointArea(this).InteriorPoint, 
			};
			if (1 == 0)
			{
			}
			return CreatePointFromInternalCoord(coordinate_, this);
		}
	}

	public virtual DimensionType Dimension
	{
		get
		{
			return _dimension;
		}
		set
		{
			_dimension = value;
		}
	}

	public virtual DimensionType BoundaryDimension
	{
		get
		{
			return _boundaryDimension;
		}
		set
		{
			_boundaryDimension = value;
		}
	}

	public virtual IEnvelope EnvelopeInternal
	{
		get
		{
			if (_envelope == null)
			{
				_envelope = ComputeEnvelopeInternal();
			}
			return _envelope;
		}
	}

	public IEnvelope Envelope
	{
		get
		{
			if (_envelope == null)
			{
				_envelope = ComputeEnvelopeInternal();
				return _envelope;
			}
			return _envelope;
		}
	}

	public virtual bool IsRectangle => false;

	public virtual IGeometry Boundary
	{
		get
		{
			return _boundary;
		}
		set
		{
			_boundary = value;
		}
	}

	public virtual IPoint Centroid
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			Coordinate centroid;
			switch (Dimension)
			{
			case DimensionType.Curve:
			{
				CentroidLine centroidLine = new CentroidLine();
				centroidLine.Add(this);
				centroid = centroidLine.Centroid;
				break;
			}
			default:
			{
				CentroidArea centroidArea = new CentroidArea();
				centroidArea.Add(this);
				centroid = centroidArea.Centroid;
				break;
			}
			case DimensionType.Point:
			{
				CentroidPoint centroidPoint = new CentroidPoint();
				centroidPoint.Add(this);
				centroid = centroidPoint.Centroid;
				break;
			}
			}
			return new Point(centroid);
		}
	}

	public virtual FeatureType FeatureType => FeatureType.Unspecified;

	private int ClassSortIndex
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < SortedClasses.Length)
				{
					if (GetType().Equals(SortedClasses[num]))
					{
						break;
					}
					num++;
					continue;
				}
				throw new ClassNotSupportedException(GetType().FullName);
			}
			return num;
		}
	}

	protected Geometry()
	{
		if (DefaultFactory == null)
		{
			DefaultFactory = new GeometryFactory(new PrecisionModel(PrecisionModelType.Floating));
		}
		_factory = DefaultFactory;
		_srid = _factory.Srid;
	}

	protected Geometry(IGeometryFactory igeometryFactory_0)
	{
		_factory = igeometryFactory_0;
		_srid = igeometryFactory_0.Srid;
	}

	public virtual IGeometry GetGeometryN(int int_0)
	{
		return this;
	}

	public virtual IBasicGeometry GetBasicGeometryN(int int_0)
	{
		return this;
	}

	public virtual double Distance(IGeometry igeometry_0)
	{
		return DistanceOp.Distance(this, igeometry_0);
	}

	public virtual bool IsWithinDistance(IGeometry igeometry_0, double double_0)
	{
		if (EnvelopeInternal.Distance(igeometry_0.EnvelopeInternal) <= double_0)
		{
			return DistanceOp.IsWithinDistance(this, igeometry_0, double_0);
		}
		return false;
	}

	public virtual Coordinate ClosestPoint(Coordinate coordinate_0)
	{
		return Coordinate;
	}

	public virtual void GeometryChanged()
	{
		Apply(new SingletonCallbackCandidate());
	}

	public virtual void GeometryChangedAction()
	{
		_envelope = null;
	}

	public virtual bool Disjoint(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Intersects(igeometry_0.EnvelopeInternal))
		{
			return Relate(igeometry_0).IsDisjoint();
		}
		return true;
	}

	public virtual bool Touches(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Intersects(igeometry_0.EnvelopeInternal))
		{
			return Relate(igeometry_0).IsTouches(Dimension, igeometry_0.Dimension);
		}
		return false;
	}

	public virtual bool Intersects(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Intersects(igeometry_0.EnvelopeInternal))
		{
			if (IsRectangle)
			{
				return RectangleIntersects.Intersects((Polygon)this, igeometry_0);
			}
			if (igeometry_0.IsRectangle)
			{
				return RectangleIntersects.Intersects((Polygon)igeometry_0, this);
			}
			return Relate(igeometry_0).IsIntersects();
		}
		return false;
	}

	public virtual bool Crosses(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Intersects(igeometry_0.EnvelopeInternal))
		{
			return Relate(igeometry_0).IsCrosses(Dimension, igeometry_0.Dimension);
		}
		return false;
	}

	public virtual bool Within(IGeometry igeometry_0)
	{
		return igeometry_0.Contains(this);
	}

	public virtual bool Overlaps(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Intersects(igeometry_0.EnvelopeInternal))
		{
			return Relate(igeometry_0).IsOverlaps(Dimension, igeometry_0.Dimension);
		}
		return false;
	}

	public virtual bool Covers(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Contains(igeometry_0.EnvelopeInternal))
		{
			if (IsRectangle)
			{
				return EnvelopeInternal.Contains(igeometry_0.EnvelopeInternal);
			}
			return Relate(igeometry_0).IsCovers();
		}
		return false;
	}

	public virtual bool CoveredBy(IGeometry igeometry_0)
	{
		return igeometry_0.Covers(this);
	}

	public virtual bool Relate(IGeometry igeometry_0, string string_0)
	{
		return Relate(igeometry_0).Matches(string_0);
	}

	public virtual GInterface4 Relate(IGeometry igeometry_0)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(igeometry_0);
		return RelateOp.Relate(this, igeometry_0);
	}

	public virtual bool Equals(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Intersects(igeometry_0.EnvelopeInternal))
		{
			return Relate(igeometry_0).IsEquals(Dimension, igeometry_0.Dimension);
		}
		return false;
	}

	public override string ToString()
	{
		return ToText();
	}

	public virtual byte[] ToBinary()
	{
		return new WkbWriter().Write(this);
	}

	public virtual XmlReader ToGmlFeature()
	{
		return new GmlWriter().Write(this);
	}

	public string ExportToGml()
	{
		return ToGmlFeature().ToString();
	}

	public virtual IGeometry ConvexHull()
	{
		return new ConvexHull(this).GetConvexHull();
	}

	public virtual IGeometry Intersection(IGeometry igeometry_0)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(igeometry_0);
		return OverlayOp.Overlay(this, igeometry_0, SpatialFunction.Intersection);
	}

	public virtual void UpdateEnvelope()
	{
		if (NumGeometries <= 1)
		{
			ClearEnvelope();
			_envelope = ComputeEnvelopeInternal();
			return;
		}
		for (int i = 0; i < NumGeometries; i++)
		{
			GetGeometryN(i).UpdateEnvelope();
		}
	}

	public virtual void ClearEnvelope()
	{
		_envelope = null;
	}

	public virtual IGeometry Union(IGeometry igeometry_0)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(igeometry_0);
		return OverlayOp.Overlay(this, igeometry_0, SpatialFunction.Union);
	}

	public virtual IGeometry Difference(IGeometry igeometry_0)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(igeometry_0);
		return OverlayOp.Overlay(this, igeometry_0, SpatialFunction.Difference);
	}

	public virtual IGeometry SymmetricDifference(IGeometry igeometry_0)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(igeometry_0);
		return OverlayOp.Overlay(this, igeometry_0, SpatialFunction.SymDifference);
	}

	public abstract bool EqualsExact(IGeometry igeometry_0, double double_0);

	public virtual bool EqualsExact(IGeometry igeometry_0)
	{
		return EqualsExact(igeometry_0, 0.0);
	}

	public abstract void Apply(ICoordinateFilter icoordinateFilter_0);

	public abstract void Apply(IGeometryFilter igeometryFilter_0);

	public abstract void Apply(IGeometryComponentFilter igeometryComponentFilter_0);

	object ICloneable.Clone()
	{
		Geometry geometry = (Geometry)MemberwiseClone();
		OnCopy(geometry);
		return geometry;
	}

	public abstract void Normalize();

	public virtual int CompareTo(object target)
	{
		Geometry geometry = target as Geometry;
		if (geometry == null)
		{
			Coordinate coordinate = target as Coordinate;
			geometry = ((coordinate == null) ? (((target as IEnvelope) ?? throw new ApplicationException("the specified object could not be treated like a geometry.")).ToLinearRing() as Geometry) : new Point(coordinate));
		}
		if (geometry != null)
		{
			if (ClassSortIndex != geometry.ClassSortIndex)
			{
				return ClassSortIndex - geometry.ClassSortIndex;
			}
			if (IsEmpty && geometry.IsEmpty)
			{
				return 0;
			}
		}
		if (IsEmpty)
		{
			return -1;
		}
		if (geometry == null)
		{
			return 1;
		}
		if (geometry.IsEmpty)
		{
			return 1;
		}
		return CompareToSameClass(geometry);
	}

	public abstract int CompareToSameClass(object object_0);

	public virtual IGeometry Buffer(double double_0, int int_0, BufferStyle bufferStyle_0)
	{
		return BufferOp.Buffer(this, double_0, int_0, bufferStyle_0);
	}

	public virtual IGeometry Buffer(double double_0, int int_0)
	{
		return BufferOp.Buffer(this, double_0, int_0);
	}

	public virtual IGeometry Buffer(double double_0, BufferStyle bufferStyle_0)
	{
		return BufferOp.Buffer(this, double_0, bufferStyle_0);
	}

	public virtual IGeometry Buffer(double double_0)
	{
		return BufferOp.Buffer(this, double_0);
	}

	public virtual bool Contains(IGeometry igeometry_0)
	{
		if (EnvelopeInternal.Contains(new Envelope(igeometry_0.EnvelopeInternal)))
		{
			if (IsRectangle)
			{
				return RectangleContains.Contains((Polygon)this, igeometry_0);
			}
			return Relate(igeometry_0).IsContains();
		}
		return false;
	}

	public abstract void Rotate(Coordinate coordinate_0, double double_0);

	public static IGeometry FromBasicGeometry(IBasicGeometry ibasicGeometry_0)
	{
		if (ibasicGeometry_0 is IBasicPolygon ibasicPolygon_)
		{
			return new Polygon(ibasicPolygon_);
		}
		if (ibasicGeometry_0 is IBasicLineString ibasicLineString_)
		{
			return new LineString(ibasicLineString_);
		}
		if (ibasicGeometry_0 is IBasicPoint icoordinate_)
		{
			return new Point(icoordinate_);
		}
		if (ibasicGeometry_0.NumGeometries <= 0)
		{
			if (ibasicGeometry_0 is IGeometry { IsEmpty: not false } geometry)
			{
				return geometry;
			}
		}
		else
		{
			IBasicGeometry basicGeometryN = ibasicGeometry_0.GetBasicGeometryN(0);
			if (basicGeometryN is IBasicPolygon)
			{
				return new MultiPolygon(ibasicGeometry_0);
			}
			if (basicGeometryN is IBasicLineString)
			{
				return new MultiLineString(ibasicGeometry_0);
			}
			if (basicGeometryN is IBasicPoint)
			{
				return new MultiPoint(ibasicGeometry_0);
			}
		}
		return null;
	}

	protected static bool HasNonEmptyElements(IGeometry[] igeometry_0)
	{
		int num = 0;
		while (true)
		{
			if (num < igeometry_0.Length)
			{
				if (!igeometry_0[num].IsEmpty)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	protected static bool HasNullElements(IEnumerable<IBasicGeometry> ienumerable_0)
	{
		foreach (IBasicGeometry item in ienumerable_0)
		{
			if (item == null)
			{
				return true;
			}
		}
		return false;
	}

	public virtual string ToText()
	{
		return new WktWriter().Write(this);
	}

	protected virtual void OnCopy(Geometry geometry_0)
	{
	}

	protected virtual bool IsEquivalentClass(IGeometry igeometry_0)
	{
		return GetType().FullName == igeometry_0.GetType().FullName;
	}

	protected virtual void CheckNotGeometryCollection(IGeometry igeometry_0)
	{
		if (igeometry_0.GetType().Name == "GeometryCollection" && igeometry_0.GetType().Namespace == GetType().Namespace)
		{
			throw new GeometryCollectionNotSupportedException();
		}
	}

	protected abstract IEnvelope ComputeEnvelopeInternal();

	protected virtual int Compare(ArrayList arrayList_0, ArrayList arrayList_1)
	{
		IEnumerator enumerator = arrayList_0.GetEnumerator();
		IEnumerator enumerator2 = arrayList_1.GetEnumerator();
		while (enumerator.MoveNext() && enumerator2.MoveNext())
		{
			IComparable obj = (IComparable)enumerator.Current;
			IComparable obj2 = (IComparable)enumerator2.Current;
			int num = obj.CompareTo(obj2);
			if (num != 0)
			{
				return num;
			}
		}
		if (enumerator.MoveNext())
		{
			return 1;
		}
		if (enumerator2.MoveNext())
		{
			return -1;
		}
		return 0;
	}

	protected virtual bool Equal(Coordinate coordinate_0, Coordinate coordinate_1, double double_0)
	{
		if (double_0 == 0.0)
		{
			return coordinate_0.Equals(coordinate_1);
		}
		return coordinate_0.Distance(coordinate_1) <= double_0;
	}

	protected void RotateCoordinateRad(Coordinate coordinate_0, ref double double_0, ref double double_1, double double_2)
	{
		double num = coordinate_0.X + (Math.Cos(double_2) * (double_0 - coordinate_0.X) - Math.Sin(double_2) * (double_1 - coordinate_0.Y));
		double num2 = coordinate_0.Y + (Math.Sin(double_2) * (double_0 - coordinate_0.X) + Math.Cos(double_2) * (double_1 - coordinate_0.Y));
		double_0 = num;
		double_1 = num2;
	}

	private static IPoint CreatePointFromInternalCoord(Coordinate coordinate_0, IGeometry igeometry_0)
	{
		Coordinate coordinate_ = new Coordinate(coordinate_0);
		new PrecisionModel(igeometry_0.PrecisionModel).MakePrecise(coordinate_);
		return igeometry_0.Factory.CreatePoint(coordinate_);
	}

	public bool Intersects(IEnvelope ienvelope_0)
	{
		return Intersects(new Envelope(ienvelope_0).ToPolygon());
	}

	public bool Intersects(double double_0, double double_1)
	{
		return Intersects(new Point(double_0, double_1));
	}

	static Geometry()
	{
		SortedClasses = new Type[8]
		{
			typeof(Point),
			typeof(MultiPoint),
			typeof(LineString),
			typeof(LinearRing),
			typeof(MultiLineString),
			typeof(Polygon),
			typeof(MultiPolygon),
			typeof(GeometryCollection)
		};
		DefaultFactory = new GeometryFactory();
	}
}
