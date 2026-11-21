namespace DotSpatial.Topology;

public interface IRelate
{
	bool Contains(IGeometry igeometry_0);

	bool CoveredBy(IGeometry igeometry_0);

	bool Covers(IGeometry igeometry_0);

	bool Crosses(IGeometry igeometry_0);

	bool Disjoint(IGeometry igeometry_0);

	bool Intersects(IGeometry igeometry_0);

	bool Overlaps(IGeometry igeometry_0);

	bool Relate(IGeometry igeometry_0, string string_0);

	GInterface4 Relate(IGeometry igeometry_0);

	bool Touches(IGeometry igeometry_0);

	bool Within(IGeometry igeometry_0);
}
