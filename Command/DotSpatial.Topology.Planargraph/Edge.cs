namespace DotSpatial.Topology.Planargraph;

public class Edge : GraphComponent
{
	protected DirectedEdge[] DirEdge { get; set; }

	public override bool IsRemoved => DirEdge == null;

	public new bool IsVisited
	{
		get
		{
			return base.IsVisited;
		}
		set
		{
			base.IsVisited = value;
		}
	}

	public Edge()
	{
	}

	public Edge(DirectedEdge directedEdge_0, DirectedEdge directedEdge_1)
	{
		SetDirectedEdges(directedEdge_0, directedEdge_1);
	}

	public void SetDirectedEdges(DirectedEdge directedEdge_0, DirectedEdge directedEdge_1)
	{
		DirEdge = new DirectedEdge[2] { directedEdge_0, directedEdge_1 };
		directedEdge_0.Edge = this;
		directedEdge_1.Edge = this;
		directedEdge_0.Sym = directedEdge_1;
		directedEdge_1.Sym = directedEdge_0;
		directedEdge_0.FromNode.AddOutEdge(directedEdge_0);
		directedEdge_1.FromNode.AddOutEdge(directedEdge_1);
	}

	public virtual DirectedEdge GetDirEdge(int int_0)
	{
		return DirEdge[int_0];
	}

	public virtual DirectedEdge GetDirEdge(Node node_0)
	{
		if (DirEdge[0].FromNode == node_0)
		{
			return DirEdge[0];
		}
		if (DirEdge[1].FromNode == node_0)
		{
			return DirEdge[1];
		}
		return null;
	}

	public virtual Node GetOppositeNode(Node node_0)
	{
		if (DirEdge[0].FromNode == node_0)
		{
			return DirEdge[0].ToNode;
		}
		if (DirEdge[1].FromNode == node_0)
		{
			return DirEdge[1].ToNode;
		}
		return null;
	}

	internal void Remove()
	{
		DirEdge = null;
	}
}
