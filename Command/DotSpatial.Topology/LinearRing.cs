using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

[Serializable]
public class LinearRing : LineString, ICloneable, IComparable, IBasicGeometry, IBasicLineString, IGeometry, IOverlay, IRelate, ILinearRing, ILineString
{
	public override string GeometryType => "LinearRing";

	public override bool IsClosed
	{
		get
		{
			if (IsEmpty)
			{
				return true;
			}
			return base.IsClosed;
		}
	}

	public override FeatureType FeatureType => FeatureType.Line;

	public LinearRing(IEnumerable<Coordinate> ienumerable_0)
		: base(ienumerable_0)
	{
		ValidateConstruction();
	}

	public LinearRing(IEnumerable<ICoordinate> ienumerable_0)
		: base(ienumerable_0)
	{
		ValidateConstruction();
	}

	public LinearRing(IBasicLineString ibasicLineString_0)
		: base(ibasicLineString_0)
	{
	}

	private void ValidateConstruction()
	{
		if (!IsEmpty && !IsClosed)
		{
			Coordinates.Add(Coordinates[0].Copy());
		}
		if (Coordinates.Count >= 1 && Coordinates.Count < 3)
		{
			throw new ArgumentException("Number of points must be 0 or >= 3");
		}
	}
}
