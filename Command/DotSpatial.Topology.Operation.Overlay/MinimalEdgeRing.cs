using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class MinimalEdgeRing : EdgeRing
{
	public MinimalEdgeRing(DirectedEdge directedEdge_0, IGeometryFactory igeometryFactory_0)
		: base(directedEdge_0, igeometryFactory_0)
	{
	}

	public override DirectedEdge GetNext(DirectedEdge directedEdge_0)
	{
		return directedEdge_0.NextMin;
	}

	public override void SetEdgeRing(DirectedEdge directedEdge_0, EdgeRing edgeRing_0)
	{
		directedEdge_0.MinEdgeRing = edgeRing_0;
	}
}
