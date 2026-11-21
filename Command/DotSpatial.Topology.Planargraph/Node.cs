using System.Collections;
using System.Linq;

namespace DotSpatial.Topology.Planargraph;

public class Node : GraphComponent
{
	protected readonly DirectedEdgeStar DeStar;

	private Coordinate prototypeThread;

	public virtual Coordinate Coordinate => prototypeThread;

	public virtual DirectedEdgeStar OutEdges => DeStar;

	public virtual int Degree => DeStar.Degree;

	public override bool IsRemoved => prototypeThread == null;

	public Node(Coordinate coordinate_0)
		: this(coordinate_0, new DirectedEdgeStar())
	{
	}

	public Node(Coordinate coordinate_0, DirectedEdgeStar directedEdgeStar_0)
	{
		prototypeThread = coordinate_0;
		DeStar = directedEdgeStar_0;
	}

	public static IList GetEdgesBetween(Node node_0, Node node_1)
	{
		IList list = DirectedEdge.ToEdges(node_0.OutEdges.Edges);
		foreach (Edge item in DirectedEdge.ToEdges(node_1.OutEdges.Edges).Cast<Edge>().Where(list.Contains)
			.ToList())
		{
			list.Remove(item);
		}
		return list;
	}

	public virtual void AddOutEdge(DirectedEdge directedEdge_0)
	{
		DeStar.Add(directedEdge_0);
	}

	public virtual int GetIndex(Edge edge_0)
	{
		return DeStar.GetIndex(edge_0);
	}

	internal void Remove()
	{
		prototypeThread = null;
	}

	public override string ToString()
	{
		return "NODE: " + prototypeThread.ToString() + ": " + Degree;
	}
}
