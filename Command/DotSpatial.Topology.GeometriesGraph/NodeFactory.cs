namespace DotSpatial.Topology.GeometriesGraph;

public class NodeFactory
{
	public virtual Node CreateNode(Coordinate coordinate_0)
	{
		return new Node(coordinate_0, null);
	}
}
