using System.Collections;
using DotSpatial.Topology.Operation.Polygonize;

namespace DotSpatial.Topology.Planargraph.Algorithm;

public class ConnectedSubgraphFinder
{
	private readonly PlanarGraph templateThread;

	public ConnectedSubgraphFinder(PlanarGraph planarGraph_0)
	{
		templateThread = planarGraph_0;
	}

	public virtual IList GetConnectedSubgraphs()
	{
		IList list = new ArrayList();
		GraphComponent.SetVisited(templateThread.GetNodeEnumerator(), bool_0: false);
		IEnumerator edgeEnumerator = templateThread.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Node fromNode = ((edgeEnumerator.Current as Edge) ?? throw new NullEdgeException()).GetDirEdge(0).FromNode;
			if (!fromNode.IsVisited)
			{
				list.Add(CloneCollection(fromNode));
			}
		}
		return list;
	}

	private Subgraph CloneCollection(Node node_0)
	{
		Subgraph subgraph = new Subgraph(templateThread);
		ConnectCollection(node_0, subgraph);
		return subgraph;
	}

	private static void ConnectCollection(object object_0, Subgraph subgraph_0)
	{
		Stack stack = new Stack();
		stack.Push(object_0);
		while (stack.Count != 0)
		{
			MoveCollection((Node)stack.Pop(), stack, subgraph_0);
		}
	}

	private static void MoveCollection(object object_0, Stack stack_0, Subgraph subgraph_0)
	{
		((GraphComponent)object_0).IsVisited = true;
		IEnumerator enumerator = ((Node)object_0).OutEdges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			subgraph_0.Add(directedEdge.Edge);
			Node toNode = directedEdge.ToNode;
			if (!toNode.IsVisited)
			{
				stack_0.Push(toNode);
			}
		}
	}
}
