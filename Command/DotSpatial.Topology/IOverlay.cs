namespace DotSpatial.Topology;

public interface IOverlay
{
	IGeometry Difference(IGeometry igeometry_0);

	IGeometry Intersection(IGeometry igeometry_0);

	IGeometry SymmetricDifference(IGeometry igeometry_0);

	IGeometry Union(IGeometry igeometry_0);
}
