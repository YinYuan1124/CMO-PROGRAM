using System.Collections.Generic;
using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMergeGraph : PlanarGraph
{
	public virtual void AddEdge(LineString lineString_0)
	{
		if (!lineString_0.IsEmpty)
		{
			IList<Coordinate> list = CoordinateArrays.RemoveRepeatedPoints(lineString_0.Coordinates);
			Coordinate coordinate_ = list[0];
			Coordinate coordinate_2 = list[list.Count - 1];
			Node node = InsertInstance(coordinate_);
			Node node2 = InsertInstance(coordinate_2);
			DirectedEdge directedEdge_ = new LineMergeDirectedEdge(node, node2, list[1], bool_0: true);
			DirectedEdge directedEdge_2 = new LineMergeDirectedEdge(node2, node, list[list.Count - 2], bool_0: false);
			Edge edge = new LineMergeEdge(lineString_0);
			edge.SetDirectedEdges(directedEdge_, directedEdge_2);
			Add(edge);
		}
	}

	private Node InsertInstance(Coordinate coordinate_0)
	{
		Node node = FindNode(coordinate_0);
		if (node == null)
		{
			node = new Node(coordinate_0);
			Add(node);
		}
		return node;
	}
}
