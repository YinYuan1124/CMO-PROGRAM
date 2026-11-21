using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology;

[Serializable]
public class GeometryFactory : IGeometryFactory
{
	private class CollectionProcessProducer : GeometryEditor.CoordinateOperation
	{
		public override IList<Coordinate> Edit(IList<Coordinate> ilist_0, IGeometry igeometry_0)
		{
			return ilist_0;
		}
	}

	private static GeometryFactory _default;

	private static GeometryFactory _floating;

	private static GeometryFactory _floatingSingle;

	private static GeometryFactory _fixed;

	private readonly ICoordinateSequenceFactory _coordinateSequenceFactory;

	private readonly PrecisionModel _precisionModel;

	private readonly int _srid;

	public static IGeometryFactory Default
	{
		get
		{
			return _default;
		}
		set
		{
			_default = new GeometryFactory(value);
		}
	}

	public IGeometryFactory Fixed
	{
		get
		{
			return _fixed;
		}
		set
		{
			_fixed = new GeometryFactory(value);
		}
	}

	public IGeometryFactory Floating
	{
		get
		{
			return _floating;
		}
		set
		{
			_floating = new GeometryFactory(value);
		}
	}

	public IGeometryFactory FloatingSingle
	{
		get
		{
			return _floatingSingle;
		}
		set
		{
			_floatingSingle = new GeometryFactory(value);
		}
	}

	public virtual PrecisionModelType PrecisionModel => _precisionModel.GetPrecisionModelType();

	public virtual ICoordinateSequenceFactory CoordinateSequenceFactory => _coordinateSequenceFactory;

	public virtual int Srid => _srid;

	public GeometryFactory(PrecisionModel precisionModel_0, int int_0, ICoordinateSequenceFactory icoordinateSequenceFactory_0)
	{
		_precisionModel = precisionModel_0;
		_coordinateSequenceFactory = icoordinateSequenceFactory_0;
		_srid = int_0;
	}

	public GeometryFactory(IGeometryFactory igeometryFactory_0)
	{
		_precisionModel = new PrecisionModel(igeometryFactory_0.PrecisionModel);
		_coordinateSequenceFactory = CoordinateArraySequenceFactory.Instance;
		_srid = igeometryFactory_0.Srid;
	}

	public GeometryFactory(IGeometryFactory igeometryFactory_0, ICoordinateSequenceFactory icoordinateSequenceFactory_0)
	{
		_precisionModel = new PrecisionModel(igeometryFactory_0.PrecisionModel);
		_coordinateSequenceFactory = icoordinateSequenceFactory_0;
		_srid = igeometryFactory_0.Srid;
	}

	public GeometryFactory(ICoordinateSequenceFactory icoordinateSequenceFactory_0)
		: this(new PrecisionModel(), 0, icoordinateSequenceFactory_0)
	{
	}

	public GeometryFactory(PrecisionModel precisionModel_0)
		: this(precisionModel_0, 0, CoordinateArraySequenceFactory.Instance)
	{
	}

	public GeometryFactory(PrecisionModel precisionModel_0, int int_0)
		: this(precisionModel_0, int_0, CoordinateArraySequenceFactory.Instance)
	{
	}

	public GeometryFactory()
		: this(new PrecisionModel(), 0)
	{
	}

	public virtual IPoint CreatePoint(Coordinate coordinate_0)
	{
		return new Point(coordinate_0, this);
	}

	public virtual IMultiLineString CreateMultiLineString(IBasicLineString[] ibasicLineString_0)
	{
		if (ibasicLineString_0 == null)
		{
			return new MultiLineString();
		}
		int num = ibasicLineString_0.Length;
		LineString[] array = new LineString[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new LineString(ibasicLineString_0[i]);
		}
		IBasicLineString[] array2 = array;
		IBasicLineString[] ibasicLineString_ = array2;
		return new MultiLineString(ibasicLineString_);
	}

	public virtual GInterface3 CreateGeometryCollection(IGeometry[] igeometry_0)
	{
		return new GeometryCollection(igeometry_0, this);
	}

	public virtual IMultiPolygon CreateMultiPolygon(IPolygon[] ipolygon_0)
	{
		return new MultiPolygon(ipolygon_0, this);
	}

	public virtual ILinearRing CreateLinearRing(IList<Coordinate> ilist_0)
	{
		return new LinearRing(ilist_0);
	}

	public virtual IMultiPoint CreateMultiPoint(IEnumerable<Coordinate> ienumerable_0)
	{
		return new MultiPoint(ienumerable_0, this);
	}

	public IMultiPoint CreateMultiPoint(IEnumerable<ICoordinate> ienumerable_0)
	{
		return new MultiPoint(ienumerable_0);
	}

	public virtual IPolygon CreatePolygon(ILinearRing ilinearRing_0, ILinearRing[] ilinearRing_1)
	{
		return new Polygon(ilinearRing_0, ilinearRing_1, this);
	}

	public virtual IGeometry BuildGeometry(IList ilist_0)
	{
		Type type = null;
		bool flag = false;
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Type type2 = ((Geometry)enumerator.Current).GetType();
			if (type == null)
			{
				type = type2;
			}
			if (type2 != type)
			{
				flag = true;
			}
		}
		if (type == null)
		{
			return CreateGeometryCollection(null);
		}
		if (flag)
		{
			return CreateGeometryCollection(ToGeometryArray(ilist_0));
		}
		IEnumerator enumerator2 = ilist_0.GetEnumerator();
		enumerator2.MoveNext();
		Geometry geometry = (Geometry)enumerator2.Current;
		if (ilist_0.Count <= 1)
		{
			return geometry;
		}
		if (geometry is Polygon)
		{
			return CreateMultiPolygon(ToPolygonArray(ilist_0));
		}
		if (geometry is LineString)
		{
			IBasicLineString[] array2 = ToLineStringArray(ilist_0);
			IBasicLineString[] array = array2;
			IBasicLineString[] ibasicLineString_ = array;
			return CreateMultiLineString(ibasicLineString_);
		}
		if (!(geometry is Point))
		{
			throw new ShouldNeverReachHereException();
		}
		return new MultiPoint(ToPointArray(ilist_0));
	}

	public virtual ILineString CreateLineString(IList<Coordinate> ilist_0)
	{
		return new LineString(ilist_0, this);
	}

	public virtual IGeometry CreateGeometry(IGeometry igeometry_0)
	{
		return new GeometryEditor(this).Edit(igeometry_0, new CollectionProcessProducer());
	}

	public static IPoint CreatePointFromInternalCoord(Coordinate coordinate_0, IGeometry igeometry_0)
	{
		new PrecisionModel(igeometry_0.PrecisionModel).MakePrecise(coordinate_0);
		return igeometry_0.Factory.CreatePoint(coordinate_0);
	}

	public static IPoint[] ToPointArray(IList ilist_0)
	{
		return (Point[])new ArrayList(ilist_0).ToArray(typeof(Point));
	}

	public static IGeometry[] ToGeometryArray(IList ilist_0)
	{
		if (ilist_0 == null)
		{
			return null;
		}
		return (Geometry[])new ArrayList(ilist_0).ToArray(typeof(Geometry));
	}

	public static ILinearRing[] ToLinearRingArray(IList ilist_0)
	{
		return (ILinearRing[])new ArrayList(ilist_0).ToArray(typeof(LinearRing));
	}

	public static ILineString[] ToLineStringArray(IList ilist_0)
	{
		return (LineString[])new ArrayList(ilist_0).ToArray(typeof(LineString));
	}

	public static IPolygon[] ToPolygonArray(IList ilist_0)
	{
		return (Polygon[])new ArrayList(ilist_0).ToArray(typeof(Polygon));
	}

	public static IMultiPolygon[] ToMultiPolygonArray(IList ilist_0)
	{
		return (IMultiPolygon[])new ArrayList(ilist_0).ToArray(typeof(MultiPolygon));
	}

	public static IMultiLineString[] ToMultiLineStringArray(IList ilist_0)
	{
		return (IMultiLineString[])new ArrayList(ilist_0).ToArray(typeof(MultiLineString));
	}

	public static IMultiPoint[] ToMultiPointArray(IList ilist_0)
	{
		return (IMultiPoint[])new ArrayList(ilist_0).ToArray(typeof(MultiPoint));
	}

	public virtual IGeometry ToGeometry(IEnvelope ienvelope_0)
	{
		if (ienvelope_0.IsNull)
		{
			return CreatePoint(null);
		}
		if (ienvelope_0.Minimum.X == ienvelope_0.Maximum.X && ienvelope_0.Minimum.Y == ienvelope_0.Maximum.Y)
		{
			return CreatePoint(new Coordinate(ienvelope_0.Minimum.X, ienvelope_0.Minimum.Y));
		}
		return CreatePolygon(CreateLinearRing(new Coordinate[5]
		{
			new Coordinate(ienvelope_0.Minimum.X, ienvelope_0.Minimum.Y),
			new Coordinate(ienvelope_0.Maximum.X, ienvelope_0.Minimum.Y),
			new Coordinate(ienvelope_0.Maximum.X, ienvelope_0.Maximum.Y),
			new Coordinate(ienvelope_0.Minimum.X, ienvelope_0.Maximum.Y),
			new Coordinate(ienvelope_0.Minimum.X, ienvelope_0.Minimum.Y)
		}), null);
	}

	public virtual IMultiPoint CreateMultiPoint(GInterface2 ginterface2_0)
	{
		if (ginterface2_0 == null)
		{
			ginterface2_0 = CoordinateSequenceFactory.Create(new Coordinate[0]);
		}
		List<IPoint> list = new List<IPoint>();
		for (int i = 0; i < ginterface2_0.Count; i++)
		{
			list.Add(CreatePoint(ginterface2_0[i]));
		}
		return new MultiPoint(list.ToArray());
	}

	static GeometryFactory()
	{
		_default = new GeometryFactory();
		_floating = new GeometryFactory();
		_floatingSingle = new GeometryFactory(new PrecisionModel(PrecisionModelType.FloatingSingle));
		_fixed = new GeometryFactory(new PrecisionModel(PrecisionModelType.Fixed));
	}
}
