using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotSpatial.Topology;

[Serializable]
public class GeometryCollection : Geometry, IEnumerable, ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate, GInterface3
{
	public class Enumerator : IEnumerator
	{
		private readonly int requestPrototype;

		private readonly GInterface3 valuePrototype;

		private bool _TokenizerPrototype;

		private int stubPrototype;

		private Enumerator _WriterPrototype;

		public virtual object Current
		{
			get
			{
				if (_TokenizerPrototype)
				{
					_TokenizerPrototype = false;
					return valuePrototype;
				}
				if (_WriterPrototype != null)
				{
					if (_WriterPrototype.MoveNext())
					{
						return _WriterPrototype.Current;
					}
					_WriterPrototype = null;
				}
				if (stubPrototype < requestPrototype)
				{
					IGeometry geometryN = valuePrototype.GetGeometryN(stubPrototype++);
					if (geometryN is GeometryCollection)
					{
						_WriterPrototype = new Enumerator((GeometryCollection)geometryN);
						return _WriterPrototype.Current;
					}
					return geometryN;
				}
				throw new ArgumentOutOfRangeException();
			}
		}

		internal Enumerator(GInterface3 ginterface3_0)
		{
			valuePrototype = ginterface3_0;
			_TokenizerPrototype = true;
			stubPrototype = 0;
			requestPrototype = ginterface3_0.NumGeometries;
		}

		public virtual bool MoveNext()
		{
			if (_TokenizerPrototype)
			{
				return true;
			}
			if (_WriterPrototype != null)
			{
				if (_WriterPrototype.MoveNext())
				{
					return true;
				}
				_WriterPrototype = null;
			}
			if (stubPrototype < requestPrototype)
			{
				return true;
			}
			return false;
		}

		public virtual void Reset()
		{
			_TokenizerPrototype = true;
			stubPrototype = 0;
		}
	}

	public static readonly GInterface3 Empty;

	private IGeometry[] _geometries;

	public override Coordinate Coordinate
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return _geometries[0].Coordinate;
		}
	}

	public override IList<Coordinate> Coordinates
	{
		get
		{
			IList<Coordinate> list = new Coordinate[NumPoints];
			int num = -1;
			for (int i = 0; i < _geometries.Length; i++)
			{
				IList<Coordinate> coordinates = _geometries[i].Coordinates;
				for (int j = 0; j < coordinates.Count; j++)
				{
					num++;
					list[num] = coordinates[j];
				}
			}
			return list;
		}
		set
		{
			if (_geometries.Length >= 1)
			{
				_geometries[0].Coordinates = value;
			}
		}
	}

	public override bool IsEmpty
	{
		get
		{
			for (int i = 0; i < _geometries.Length; i++)
			{
				if (!_geometries[i].IsEmpty)
				{
					return false;
				}
			}
			return true;
		}
	}

	public override DimensionType Dimension
	{
		get
		{
			DimensionType dimensionType = DimensionType.False;
			for (int i = 0; i < _geometries.Length; i++)
			{
				dimensionType = (DimensionType)Math.Max((int)dimensionType, (int)_geometries[i].Dimension);
			}
			return dimensionType;
		}
	}

	public override DimensionType BoundaryDimension
	{
		get
		{
			DimensionType dimensionType = DimensionType.False;
			for (int i = 0; i < _geometries.Length; i++)
			{
				dimensionType = (DimensionType)Math.Max((int)dimensionType, (int)((Geometry)_geometries[i]).BoundaryDimension);
			}
			return dimensionType;
		}
	}

	public override int NumGeometries => _geometries.Length;

	public virtual IGeometry[] Geometries
	{
		get
		{
			return _geometries;
		}
		set
		{
			_geometries = value;
		}
	}

	public override int NumPoints
	{
		get
		{
			int num = 0;
			for (int i = 0; i < _geometries.Length; i++)
			{
				num += ((Geometry)_geometries[i]).NumPoints;
			}
			return num;
		}
	}

	public override string GeometryType => "GeometryCollection";

	public override bool IsSimple
	{
		get
		{
			CheckNotGeometryCollection(this);
			throw new ShouldNeverReachHereException();
		}
	}

	public override IGeometry Boundary
	{
		get
		{
			CheckNotGeometryCollection(this);
			throw new ShouldNeverReachHereException();
		}
	}

	public override double Area
	{
		get
		{
			double num = 0.0;
			for (int i = 0; i < _geometries.Length; i++)
			{
				num += _geometries[i].Area;
			}
			return num;
		}
	}

	public override double Length
	{
		get
		{
			double num = 0.0;
			for (int i = 0; i < _geometries.Length; i++)
			{
				num += _geometries[i].Length;
			}
			return num;
		}
	}

	public bool IsHomogeneous
	{
		get
		{
			IGeometry geometry = _geometries[0];
			int num = 1;
			while (true)
			{
				if (num < _geometries.Length)
				{
					if (geometry.GetType() != _geometries[num].GetType())
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	public virtual IGeometry this[int int_0]
	{
		get
		{
			return _geometries[int_0];
		}
		set
		{
			_geometries[int_0] = value;
		}
	}

	public virtual int Count => _geometries.Length;

	public new IEnvelope Envelope
	{
		get
		{
			IEnvelope envelope = new Envelope();
			for (int i = 0; i < NumGeometries; i++)
			{
				envelope.ExpandToInclude(Geometries[i].Envelope);
			}
			return envelope;
		}
	}

	public GeometryCollection(IGeometry[] igeometry_0)
		: this(igeometry_0, Geometry.DefaultFactory)
	{
	}

	protected GeometryCollection()
		: base(Geometry.DefaultFactory)
	{
	}

	protected GeometryCollection(IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
	}

	public GeometryCollection(IGeometry[] igeometry_0, IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		if (igeometry_0 == null)
		{
			igeometry_0 = new IGeometry[0];
		}
		if (Geometry.HasNullElements(igeometry_0))
		{
			throw new ArgumentException("geometries must not contain null elements");
		}
		_geometries = igeometry_0;
	}

	public GeometryCollection(IBasicGeometry ibasicGeometry_0, IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		if (ibasicGeometry_0 == null)
		{
			_geometries = new IGeometry[0];
		}
		else if (ibasicGeometry_0.GetBasicGeometryN(0) is IBasicPolygon)
		{
			_geometries = new IGeometry[ibasicGeometry_0.NumGeometries];
			for (int i = 0; i < ibasicGeometry_0.NumGeometries; i++)
			{
				IBasicPolygon ibasicPolygon_ = ibasicGeometry_0.GetBasicGeometryN(i) as IBasicPolygon;
				_geometries[i] = new Polygon(ibasicPolygon_);
			}
		}
		else if (ibasicGeometry_0.GetBasicGeometryN(0) is IBasicPoint)
		{
			_geometries = new IGeometry[ibasicGeometry_0.NumGeometries];
			for (int j = 0; j < ibasicGeometry_0.NumGeometries; j++)
			{
				IBasicPoint icoordinate_ = ibasicGeometry_0.GetBasicGeometryN(j) as IBasicPoint;
				_geometries[j] = new Point(icoordinate_);
			}
		}
		else if (ibasicGeometry_0.GetBasicGeometryN(0) is IBasicLineString)
		{
			_geometries = new IGeometry[ibasicGeometry_0.NumGeometries];
			for (int k = 0; k < ibasicGeometry_0.NumGeometries; k++)
			{
				IBasicLineString ibasicLineString_ = ibasicGeometry_0.GetBasicGeometryN(k) as IBasicLineString;
				_geometries[k] = new LineString(ibasicLineString_);
			}
		}
	}

	public GeometryCollection(IEnumerable<IBasicGeometry> ienumerable_0, IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		if (ienumerable_0 == null)
		{
			return;
		}
		int num = ienumerable_0.Count();
		if (_geometries == null)
		{
			_geometries = new IGeometry[num];
		}
		if (Geometry.HasNullElements(ienumerable_0))
		{
			throw new ArgumentException("geometries must not contain null elements");
		}
		int num2 = 0;
		foreach (IBasicGeometry item in ienumerable_0)
		{
			_geometries[num2] = Geometry.FromBasicGeometry(item);
			num2++;
		}
	}

	public override Coordinate ClosestPoint(Coordinate coordinate_0)
	{
		Coordinate result = null;
		double num = double.MaxValue;
		IGeometry[] geometries = Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Coordinate coordinate = geometries[i].ClosestPoint(coordinate_0);
			double num2 = coordinate_0.Distance(coordinate);
			if (num2 < num)
			{
				num = num2;
				result = coordinate;
			}
		}
		return result;
	}

	public override IGeometry GetGeometryN(int int_0)
	{
		return _geometries[int_0];
	}

	public override IBasicGeometry GetBasicGeometryN(int int_0)
	{
		return _geometries[int_0];
	}

	public override bool EqualsExact(IGeometry igeometry_0, double double_0)
	{
		if (IsEquivalentClass(igeometry_0))
		{
			GeometryCollection geometryCollection = (GeometryCollection)igeometry_0;
			if (_geometries.Length == geometryCollection.Geometries.Length)
			{
				for (int i = 0; i < _geometries.Length; i++)
				{
					if (!((Geometry)_geometries[i]).EqualsExact(geometryCollection.Geometries[i], double_0))
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

	public override void Apply(ICoordinateFilter icoordinateFilter_0)
	{
		for (int i = 0; i < _geometries.Length; i++)
		{
			_geometries[i].Apply(icoordinateFilter_0);
		}
	}

	public override void Apply(IGeometryFilter igeometryFilter_0)
	{
		igeometryFilter_0.Filter(this);
		for (int i = 0; i < _geometries.Length; i++)
		{
			_geometries[i].Apply(igeometryFilter_0);
		}
	}

	public override void Apply(IGeometryComponentFilter igeometryComponentFilter_0)
	{
		igeometryComponentFilter_0.Filter(this);
		for (int i = 0; i < _geometries.Length; i++)
		{
			_geometries[i].Apply(igeometryComponentFilter_0);
		}
	}

	public override void Normalize()
	{
		for (int i = 0; i < _geometries.Length; i++)
		{
			_geometries[i].Normalize();
		}
		Array.Sort(_geometries);
	}

	public override int CompareToSameClass(object object_0)
	{
		ArrayList arrayList_ = new ArrayList(_geometries);
		ArrayList arrayList_2 = new ArrayList(((GeometryCollection)object_0)._geometries);
		return Compare(arrayList_, arrayList_2);
	}

	public IEnumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	protected override void OnCopy(Geometry geometry_0)
	{
		if (geometry_0 is GeometryCollection geometryCollection)
		{
			IGeometry[] array = new Geometry[_geometries.Length];
			IGeometry[] geometries = array;
			geometryCollection._geometries = geometries;
			for (int i = 0; i < _geometries.Length; i++)
			{
				geometryCollection._geometries[i] = (Geometry)_geometries[i].Clone();
			}
		}
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		Envelope envelope = new Envelope();
		for (int i = 0; i < _geometries.Length; i++)
		{
			envelope.ExpandToInclude(_geometries[i].EnvelopeInternal);
		}
		return envelope;
	}

	public override void Rotate(Coordinate coordinate_0, double double_0)
	{
		IGeometry[] geometries = Geometries;
		IGeometry[] array = geometries;
		foreach (IGeometry geometry in array)
		{
			if (geometry is IPolygon polygon)
			{
				polygon.Rotate(coordinate_0, double_0);
			}
			else if (geometry is ILineString lineString)
			{
				lineString.Rotate(coordinate_0, double_0);
			}
			else if (geometry is IPoint point)
			{
				point.Rotate(coordinate_0, double_0);
			}
		}
	}

	static GeometryCollection()
	{
		Empty = new GeometryFactory().CreateGeometryCollection(null);
	}
}
