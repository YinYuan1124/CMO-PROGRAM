using System.Collections;
using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class NodeMap
{
	private readonly NodeFactory m_ProccesorInstance;

	private readonly IDictionary _StrategyInstance = new SortedList();

	public virtual IList Values => new ArrayList(_StrategyInstance.Values);

	public NodeMap(NodeFactory nodeFactory_0)
	{
		m_ProccesorInstance = nodeFactory_0;
	}

	public virtual Node AddNode(Coordinate coordinate_0)
	{
		Node node = (Node)_StrategyInstance[coordinate_0];
		if (node == null)
		{
			node = m_ProccesorInstance.CreateNode(coordinate_0);
			_StrategyInstance.Add(coordinate_0, node);
		}
		return node;
	}

	public virtual Node AddNode(Node node_0)
	{
		Node node = (Node)_StrategyInstance[node_0.Coordinate];
		if (node == null)
		{
			_StrategyInstance.Add(node_0.Coordinate, node_0);
			return node_0;
		}
		node.MergeLabel(node_0);
		return node;
	}

	public virtual void Add(EdgeEnd edgeEnd_0)
	{
		Coordinate coordinate = edgeEnd_0.Coordinate;
		AddNode(coordinate).Add(edgeEnd_0);
	}

	public virtual Node Find(Coordinate coordinate_0)
	{
		return (Node)_StrategyInstance[coordinate_0];
	}

	public virtual IEnumerator GetEnumerator()
	{
		return _StrategyInstance.Values.GetEnumerator();
	}

	public virtual IList GetBoundaryNodes(int int_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (node.Label.GetLocation(int_0) == LocationType.Boundary)
			{
				list.Add(node);
			}
		}
		return list;
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Node)enumerator.Current).Write(streamWriter_0);
		}
	}
}
