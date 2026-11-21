using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Buffer;

public class BufferSubgraph : IComparable
{
	private readonly IList comparatorRule = new ArrayList();

	private readonly RightmostEdgeFinder itemRule;

	private readonly IList _SetterRule = new ArrayList();

	private Coordinate _CreatorRule;

	public virtual IList DirectedEdges => comparatorRule;

	public virtual IList Nodes => _SetterRule;

	public virtual Coordinate RightMostCoordinate => _CreatorRule;

	public BufferSubgraph()
	{
		itemRule = new RightmostEdgeFinder();
	}

	public virtual int CompareTo(object target)
	{
		BufferSubgraph bufferSubgraph = (BufferSubgraph)target;
		if (RightMostCoordinate.X < bufferSubgraph.RightMostCoordinate.X)
		{
			return -1;
		}
		if (RightMostCoordinate.X <= bufferSubgraph.RightMostCoordinate.X)
		{
			return 0;
		}
		return 1;
	}

	public virtual void Create(Node node_0)
	{
		OrderInstance(node_0);
		itemRule.FindEdge(comparatorRule);
		_CreatorRule = itemRule.Coordinate;
	}

	private void OrderInstance(Node node_0)
	{
		Stack stack = new Stack();
		stack.Push(node_0);
		while (stack.Count != 0)
		{
			Node node_ = (Node)stack.Pop();
			Add(node_, stack);
		}
	}

	private void Add(Node node_0, Stack stack_0)
	{
		node_0.IsVisited = true;
		_SetterRule.Add(node_0);
		IEnumerator enumerator = node_0.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			comparatorRule.Add(directedEdge);
			Node node = directedEdge.Sym.Node;
			if (!node.IsVisited)
			{
				stack_0.Push(node);
			}
		}
	}

	private void RegisterInstance()
	{
		IEnumerator enumerator = comparatorRule.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdge)enumerator.Current).IsVisited = false;
		}
	}

	public virtual void ComputeDepth(int int_0)
	{
		RegisterInstance();
		DirectedEdge edge = itemRule.Edge;
		edge.SetEdgeDepths(PositionType.Right, int_0);
		CountObject(edge);
		ManageInstance(edge);
	}

	private static void ManageInstance(object object_0)
	{
		HashSet<Node> hashSet = new HashSet<Node>();
		Queue queue = new Queue();
		Node node = ((EdgeEnd)object_0).Node;
		queue.Enqueue(node);
		hashSet.Add(node);
		((DirectedEdge)object_0).IsVisited = true;
		while (queue.Count != 0)
		{
			Node node2 = (Node)queue.Dequeue();
			hashSet.Add(node2);
			RevertInstance(node2);
			IEnumerator enumerator = node2.Edges.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DirectedEdge sym = ((DirectedEdge)enumerator.Current).Sym;
				if (!sym.IsVisited)
				{
					Node node3 = sym.Node;
					if (!hashSet.Contains(node3))
					{
						queue.Enqueue(node3);
						hashSet.Add(node3);
					}
				}
			}
		}
	}

	private static void RevertInstance(object object_0)
	{
		DirectedEdge directedEdge = null;
		IEnumerator enumerator = ((Node)object_0).Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge2 = (DirectedEdge)enumerator.Current;
			if (directedEdge2.IsVisited || directedEdge2.Sym.IsVisited)
			{
				directedEdge = directedEdge2;
				break;
			}
		}
		Assert.IsTrue(directedEdge != null, "unable to find edge to compute depths at " + (object)((GraphComponent)object_0).Coordinate);
		((DirectedEdgeStar)((Node)object_0).Edges).ComputeDepths(directedEdge);
		IEnumerator enumerator2 = ((Node)object_0).Edges.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			DirectedEdge obj = (DirectedEdge)enumerator2.Current;
			obj.IsVisited = true;
			CountObject(obj);
		}
	}

	private static void CountObject(DirectedEdge directedEdge_0)
	{
		DirectedEdge sym = directedEdge_0.Sym;
		sym.SetDepth(PositionType.Left, directedEdge_0.GetDepth(PositionType.Right));
		sym.SetDepth(PositionType.Right, directedEdge_0.GetDepth(PositionType.Left));
	}

	public virtual void FindResultEdges()
	{
		IEnumerator enumerator = comparatorRule.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.GetDepth(PositionType.Right) >= 1 && directedEdge.GetDepth(PositionType.Left) <= 0 && !directedEdge.IsInteriorAreaEdge)
			{
				directedEdge.IsInResult = true;
			}
		}
	}
}
