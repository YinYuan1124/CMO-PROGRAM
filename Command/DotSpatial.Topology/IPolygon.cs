using System;

namespace DotSpatial.Topology;

public interface IPolygon : ICloneable, IComparable, IBasicGeometry, IBasicPolygon, IGeometry, IOverlay, IRelate
{
	new ILinearRing Shell { get; }

	new ILinearRing[] Holes { get; }

	ILineString GetInteriorRingN(int int_0);
}
