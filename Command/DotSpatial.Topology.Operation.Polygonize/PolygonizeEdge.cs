using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Polygonize;

public class PolygonizeEdge : Edge
{
	private readonly LineString observerRule;

	public virtual LineString Line => observerRule;

	public PolygonizeEdge(LineString lineString_0)
	{
		observerRule = lineString_0;
	}
}
