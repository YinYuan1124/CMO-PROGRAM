using System;
using System.Collections;

namespace DotSpatial.Topology;

[Serializable]
public class MultiPolygon : GeometryCollection, IEnumerable, ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate, GInterface3, IMultiPolygon
{
	public new static readonly IMultiPolygon Empty;

	public override DimensionType Dimension => DimensionType.Surface;

	public override DimensionType BoundaryDimension => DimensionType.Curve;

	public override string GeometryType => "MultiPolygon";

	public override FeatureType FeatureType => FeatureType.Polygon;

	public override bool IsSimple => true;

	public override IGeometry Boundary
	{
		get
		{
			if (IsEmpty)
			{
				return base.Factory.CreateGeometryCollection(null);
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Geometries.Length; i++)
			{
				Geometry geometry = (Geometry)((Polygon)Geometries[i]).Boundary;
				for (int j = 0; j < geometry.NumGeometries; j++)
				{
					arrayList.Add(geometry.GetGeometryN(j));
				}
			}
			IGeometryFactory factory = base.Factory;
			IBasicLineString[] array2 = (LineString[])arrayList.ToArray(typeof(LineString));
			IBasicLineString[] array = array2;
			IBasicLineString[] ibasicLineString_ = array;
			return factory.CreateMultiLineString(ibasicLineString_);
		}
	}

	public MultiPolygon(Polygon[] polygon_0)
		: this(polygon_0, Geometry.DefaultFactory)
	{
	}

	public MultiPolygon(IBasicPolygon[] ibasicPolygon_0)
		: base(ibasicPolygon_0, Geometry.DefaultFactory)
	{
	}

	public MultiPolygon(IBasicGeometry ibasicGeometry_0)
		: base(ibasicGeometry_0, Geometry.DefaultFactory)
	{
	}

	public MultiPolygon(IBasicGeometry ibasicGeometry_0, IGeometryFactory igeometryFactory_0)
		: base(ibasicGeometry_0, igeometryFactory_0)
	{
	}

	public MultiPolygon(IPolygon[] ipolygon_0, IGeometryFactory igeometryFactory_0)
		: base(ipolygon_0, igeometryFactory_0)
	{
	}

	public override bool EqualsExact(IGeometry igeometry_0, double double_0)
	{
		if (IsEquivalentClass(igeometry_0))
		{
			return base.EqualsExact(igeometry_0, double_0);
		}
		return false;
	}

	public new static IMultiPolygon FromBasicGeometry(IBasicGeometry ibasicGeometry_0)
	{
		if (ibasicGeometry_0 is IMultiPolygon result)
		{
			return result;
		}
		IPolygon polygon = (IPolygon)ibasicGeometry_0;
		IBasicPolygon[] array2;
		IBasicPolygon[] ibasicPolygon_2;
		if (polygon == null)
		{
			IBasicPolygon basicPolygon = (IBasicPolygon)ibasicGeometry_0;
			if (basicPolygon == null)
			{
				IPolygon[] array = new IPolygon[ibasicGeometry_0.NumGeometries];
				for (int i = 0; i < ibasicGeometry_0.NumGeometries; i++)
				{
					IBasicPolygon ibasicPolygon_ = (IBasicPolygon)ibasicGeometry_0.GetBasicGeometryN(i);
					array[i] = new Polygon(ibasicPolygon_);
				}
				array2 = array;
				ibasicPolygon_2 = array2;
				return new MultiPolygon(ibasicPolygon_2);
			}
			return new MultiPolygon(new IBasicPolygon[1] { basicPolygon });
		}
		array2 = new IPolygon[1] { polygon };
		ibasicPolygon_2 = array2;
		return new MultiPolygon(ibasicPolygon_2);
	}

	static MultiPolygon()
	{
		Empty = new GeometryFactory().CreateMultiPolygon(null);
	}
}
