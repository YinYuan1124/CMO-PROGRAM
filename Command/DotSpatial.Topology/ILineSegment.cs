using System;

namespace DotSpatial.Topology;

public interface ILineSegment : IComparable, ILineSegmentBase
{
	double Length { get; }

	bool IsHorizontal { get; }

	bool IsVertical { get; }

	double Angle { get; }

	Coordinate GetCoordinate(int int_0);

	void SetCoordinates(ILineSegmentBase ilineSegmentBase_0);

	void SetCoordinates(Coordinate coordinate_0, Coordinate coordinate_1);

	int OrientationIndex(ILineSegmentBase ilineSegmentBase_0);

	void Reverse();

	void Normalize();

	double Distance(ILineSegmentBase ilineSegmentBase_0);

	double Distance(Coordinate coordinate_0);

	double DistancePerpendicular(Coordinate coordinate_0);

	double ProjectionFactor(Coordinate coordinate_0);

	Coordinate Project(Coordinate coordinate_0);

	ILineSegment Project(ILineSegmentBase ilineSegmentBase_0);

	Coordinate ClosestPoint(Coordinate coordinate_0);

	Coordinate[] ClosestPoints(ILineSegmentBase ilineSegmentBase_0);

	Coordinate Intersection(ILineSegmentBase ilineSegmentBase_0);

	ILineSegment Intersection(Envelope envelope_0);

	bool Intersects(Envelope envelope_0);

	bool EqualsTopologically(ILineSegmentBase ilineSegmentBase_0);

	new string ToString();
}
