using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Planargraph;

public class Subgraph
{
	protected readonly IList<DirectedEdge> DirEdges = new List<DirectedEdge>();

	protected readonly ISet<Edge> Edges = new HashSet<Edge>();

	protected readonly NodeMap NodeMap = new NodeMap();

	protected readonly PlanarGraph ParentGraph;

	public Subgraph(PlanarGraph planarGraph_0)
	{
		ParentGraph = planarGraph_0;
	}

	public virtual PlanarGraph GetParent()
	{
		return ParentGraph;
	}

	public virtual void Add(Edge edge_0)
	{
		if (!Edges.Contains(edge_0))
		{
			Edges.Add(edge_0);
			DirEdges.Add(edge_0.GetDirEdge(0));
			DirEdges.Add(edge_0.GetDirEdge(1));
			NodeMap.Add(edge_0.GetDirEdge(0).FromNode);
			NodeMap.Add(edge_0.GetDirEdge(1).FromNode);
		}
	}

	public virtual IEnumerator GetDirEdgeEnumerator()
	{
		return DirEdges.GetEnumerator();
	}

	public virtual IEnumerator GetEdgeEnumerator()
	{
		return Edges.GetEnumerator();
	}

	public virtual IEnumerator GetNodeEnumerator()
	{
		return NodeMap.GetEnumerator();
	}

	public virtual bool Contains(Edge edge_0)
	{
		return Edges.Contains(edge_0);
	}
}
