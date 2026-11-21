using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Operation;

namespace DotSpatial.Topology;

[Serializable]
public class MultiPoint : GeometryCollection, IEnumerable, ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate, GInterface3, IMultiPoint
{
	public new static readonly IMultiPoint Empty;

	public override DimensionType Dimension => DimensionType.Point;

	public override DimensionType BoundaryDimension => DimensionType.False;

	public override string GeometryType => "MultiPoint";

	public override FeatureType FeatureType => FeatureType.MultiPoint;

	public override IGeometry Boundary => base.Factory.CreateGeometryCollection(null);

	public override bool IsSimple => new IsSimpleOp().IsSimple(this);

	public override bool IsValid => true;

	public new IPoint this[int int_0]
	{
		get
		{
			return base[int_0] as IPoint;
		}
		set
		{
			base[int_0] = value;
		}
	}

	public MultiPoint(IEnumerable<Coordinate> ienumerable_0, IGeometryFactory igeometryFactory_0)
		: base(CastPoints(ienumerable_0), igeometryFactory_0)
	{
	}

	public MultiPoint(IBasicGeometry ibasicGeometry_0)
		: base(ibasicGeometry_0, Geometry.DefaultFactory)
	{
	}

	public MultiPoint(IEnumerable<Coordinate> ienumerable_0)
		: base(CastPoints(ienumerable_0), Geometry.DefaultFactory)
	{
	}

	public MultiPoint(IEnumerable<ICoordinate> ienumerable_0)
		: base(CastPoints(ienumerable_0), Geometry.DefaultFactory)
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

	private static IEnumerable<IBasicGeometry> CastPoints(IEnumerable<Coordinate> ienumerable_0)
	{
		List<IBasicGeometry> list = new List<IBasicGeometry>();
		foreach (Coordinate item in ienumerable_0)
		{
			list.Add(new Point(item));
		}
		return list;
	}

	private static IEnumerable<IBasicGeometry> CastPoints(IEnumerable<ICoordinate> ienumerable_0)
	{
		List<IBasicGeometry> list = new List<IBasicGeometry>();
		foreach (ICoordinate item in ienumerable_0)
		{
			list.Add(new Point(item));
		}
		return list;
	}

	protected virtual Coordinate GetCoordinate(int int_0)
	{
		return ((Point)Geometries[int_0]).Coordinate;
	}

	static MultiPoint()
	{
		Empty = new MultiPoint(new Point[0]);
	}
}
