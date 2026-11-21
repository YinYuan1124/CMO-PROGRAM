using System;

namespace DotSpatial.Topology;

public interface ILineString : ICloneable, IComparable, IBasicGeometry, IBasicLineString, IGeometry, IOverlay, IRelate
{
	IPoint StartPoint { get; }

	IPoint EndPoint { get; }

	bool IsClosed { get; }

	bool IsRing { get; }

	double Angle { get; }

	IPoint GetPointN(int int_0);

	ILineString Reverse();

	bool IsCoordinate(Coordinate coordinate_0);
}
