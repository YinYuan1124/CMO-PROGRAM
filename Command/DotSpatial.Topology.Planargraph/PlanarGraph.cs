using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public abstract class PlanarGraph
{
	private readonly IList itemThread = new ArrayList();

	private readonly NodeMap setterThread = new NodeMap();

	private IList _CreatorThread = new ArrayList();

	public virtual IList DirectedEdges
	{
		get
		{
			return _CreatorThread;
		}
		protected set
		{
			_CreatorThread = value;
		}
	}

	public virtual ICollection Nodes => setterThread.Values;

	public virtual IList Edges => itemThread;

	public virtual Node FindNode(Coordinate coordinate_0)
	{
		return setterThread.Find(coordinate_0);
	}

	protected virtual void Add(Node node_0)
	{
		setterThread.Add(node_0);
	}

	protected virtual void Add(Edge edge_0)
	{
		itemThread.Add(edge_0);
		Add(edge_0.GetDirEdge(0));
		Add(edge_0.GetDirEdge(1));
	}

	protected virtual void Add(DirectedEdge directedEdge_0)
	{
		_CreatorThread.Add(directedEdge_0);
	}

	public virtual IEnumerator GetNodeEnumerator()
	{
		return setterThread.GetEnumerator();
	}

	public virtual IEnumerator GetDirEdgeEnumerator()
	{
		return _CreatorThread.GetEnumerator();
	}

	public virtual IEnumerator GetEdgeEnumerator()
	{
		return itemThread.GetEnumerator();
	}

	public virtual void Remove(Edge edge_0)
	{
		Remove(edge_0.GetDirEdge(0));
		Remove(edge_0.GetDirEdge(1));
		itemThread.Remove(edge_0);
		edge_0.Remove();
	}

	public virtual void Remove(DirectedEdge directedEdge_0)
	{
		DirectedEdge sym = directedEdge_0.Sym;
		if (sym != null)
		{
			sym.Sym = null;
		}
		directedEdge_0.FromNode.OutEdges.Remove(directedEdge_0);
		directedEdge_0.Remove();
		_CreatorThread.Remove(directedEdge_0);
	}

	public virtual void Remove(Node node_0)
	{
		IEnumerator enumerator = node_0.OutEdges.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			DirectedEdge sym = directedEdge.Sym;
			if (sym != null)
			{
				Remove(sym);
			}
			_CreatorThread.Remove(directedEdge);
			Edge edge = directedEdge.Edge;
			if (edge != null)
			{
				itemThread.Remove(edge);
			}
		}
		setterThread.Remove(node_0.Coordinate);
		node_0.Remove();
	}

	public virtual IList FindNodesOfDegree(int int_0)
	{
		IList list = new ArrayList();
		IEnumerator nodeEnumerator = GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			if (node.Degree == int_0)
			{
				list.Add(node);
			}
		}
		return list;
	}
}
