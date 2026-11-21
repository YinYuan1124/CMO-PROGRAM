using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class OverlayNodeFactory : NodeFactory
{
	public override Node CreateNode(Coordinate coordinate_0)
	{
		return new Node(coordinate_0, new DirectedEdgeStar());
	}
}
