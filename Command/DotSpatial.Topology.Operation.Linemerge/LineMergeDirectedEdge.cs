using DotSpatial.Topology.Planargraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMergeDirectedEdge : DirectedEdge
{
	public virtual LineMergeDirectedEdge Next
	{
		get
		{
			if (ToNode.Degree == 2)
			{
				if (ToNode.OutEdges.Edges[0] == Sym)
				{
					return (LineMergeDirectedEdge)ToNode.OutEdges.Edges[1];
				}
				Assert.IsTrue(ToNode.OutEdges.Edges[1] == Sym);
				return (LineMergeDirectedEdge)ToNode.OutEdges.Edges[0];
			}
			return null;
		}
	}

	public LineMergeDirectedEdge(Node node_0, Node node_1, Coordinate coordinate_0, bool bool_0)
		: base(node_0, node_1, coordinate_0, bool_0)
	{
	}
}
