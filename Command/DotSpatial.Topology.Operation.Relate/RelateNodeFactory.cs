using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateNodeFactory : NodeFactory
{
	public override Node CreateNode(Coordinate coordinate_0)
	{
		return new RelateNode(coordinate_0, new EdgeEndBundleStar());
	}
}
