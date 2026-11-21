using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Operation;

namespace DotSpatial.Topology;

public class MultiLineString : GeometryCollection, IEnumerable, ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate, GInterface3, IMultiLineString
{
	public new static readonly IMultiLineString Empty;

	public virtual bool IsClosed
	{
		get
		{
			if (IsEmpty)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < Geometries.Length)
				{
					if (!((LineString)Geometries[num]).IsClosed)
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

	public override DimensionType Dimension => DimensionType.Curve;

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

	public override string GeometryType => "MultiLineString";

	public override bool IsSimple => new IsSimpleOp().IsSimple(this);

	public override IGeometry Boundary
	{
		get
		{
			if (IsEmpty)
			{
				return base.Factory.CreateGeometryCollection(null);
			}
			Coordinate[] boundaryPoints = new GeometryGraph(0, this).GetBoundaryPoints();
			return base.Factory.CreateMultiPoint(boundaryPoints);
		}
	}

	public override FeatureType FeatureType => FeatureType.Line;

	public new ILineString this[int int_0]
	{
		get
		{
			return base[int_0] as ILineString;
		}
		set
		{
			base[int_0] = value;
		}
	}

	public MultiLineString(IEnumerable<IBasicLineString> ienumerable_0)
	{
		IGeometry[] array = new IGeometry[ienumerable_0.Count()];
		int num = 0;
		foreach (IBasicLineString item in ienumerable_0)
		{
			array[num] = Geometry.FromBasicGeometry(item);
			num++;
		}
		base.Geometries = array;
	}

	public MultiLineString(IBasicLineString[] ibasicLineString_0, IGeometryFactory igeometryFactory_0)
		: base(ibasicLineString_0, igeometryFactory_0)
	{
	}

	public MultiLineString(IBasicGeometry ibasicGeometry_0)
		: base(ibasicGeometry_0, Geometry.DefaultFactory)
	{
	}

	public MultiLineString(IBasicGeometry ibasicGeometry_0, IGeometryFactory igeometryFactory_0)
		: base(ibasicGeometry_0, igeometryFactory_0)
	{
	}

	public MultiLineString(IBasicLineString[] ibasicLineString_0)
		: this(ibasicLineString_0, Geometry.DefaultFactory)
	{
	}

	public MultiLineString()
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

	public virtual IMultiLineString Reverse()
	{
		int num = Geometries.Length;
		ILineString[] array4 = new LineString[num];
		ILineString[] array = array4;
		ILineString[] array2 = array;
		for (int i = 0; i < Geometries.Length; i++)
		{
			array2[num - 1 - i] = new LineString(((ILineString)Geometries[i]).Reverse());
		}
		IGeometryFactory factory = base.Factory;
		IBasicLineString[] array5 = array2;
		IBasicLineString[] array3 = array5;
		IBasicLineString[] ibasicLineString_ = array3;
		return factory.CreateMultiLineString(ibasicLineString_);
	}

	static MultiLineString()
	{
		Empty = new MultiLineString();
	}
}
