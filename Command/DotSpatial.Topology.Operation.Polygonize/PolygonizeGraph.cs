using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Planargraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Polygonize;

public class PolygonizeGraph : PlanarGraph
{
	private readonly IGeometryFactory m_IssuerRule;

	public PolygonizeGraph(IGeometryFactory igeometryFactory_0)
	{
		m_IssuerRule = igeometryFactory_0;
	}

	private static int OrderCollection(Node node_0)
	{
		IList edges = node_0.OutEdges.Edges;
		int num = 0;
		IEnumerator enumerator = edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!((PolygonizeDirectedEdge)enumerator.Current).IsMarked)
			{
				num++;
			}
		}
		return num;
	}

	private static int RegisterCollection(Node node_0, long long_0)
	{
		IList edges = node_0.OutEdges.Edges;
		int num = 0;
		IEnumerator enumerator = edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (((PolygonizeDirectedEdge)enumerator.Current).Label == long_0)
			{
				num++;
			}
		}
		return num;
	}

	public static void DeleteAllEdges(Node node_0)
	{
		IEnumerator enumerator = node_0.OutEdges.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PolygonizeDirectedEdge obj = (PolygonizeDirectedEdge)enumerator.Current;
			obj.IsMarked = true;
			PolygonizeDirectedEdge polygonizeDirectedEdge = (PolygonizeDirectedEdge)obj.Sym;
			if (polygonizeDirectedEdge != null)
			{
				polygonizeDirectedEdge.IsMarked = true;
			}
		}
	}

	public virtual void AddEdge(LineString lineString_0)
	{
		if (!lineString_0.IsEmpty)
		{
			IList<Coordinate> list = CoordinateArrays.RemoveRepeatedPoints(lineString_0.Coordinates);
			Coordinate coordinate_ = list[0];
			Coordinate coordinate_2 = list[list.Count - 1];
			Node node = ManageCollection(coordinate_);
			Node node2 = ManageCollection(coordinate_2);
			DirectedEdge directedEdge_ = new PolygonizeDirectedEdge(node, node2, list[1], bool_0: true);
			DirectedEdge directedEdge_2 = new PolygonizeDirectedEdge(node2, node, list[list.Count - 2], bool_0: false);
			Edge edge = new PolygonizeEdge(lineString_0);
			edge.SetDirectedEdges(directedEdge_, directedEdge_2);
			Add(edge);
		}
	}

	private Node ManageCollection(Coordinate coordinate_0)
	{
		Node node = FindNode(coordinate_0);
		if (node == null)
		{
			node = new Node(coordinate_0);
			Add(node);
		}
		return node;
	}

	private void RevertCollection()
	{
		IEnumerator nodeEnumerator = GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			MoveInstance((Node)nodeEnumerator.Current);
		}
	}

	private static void CountInstance(IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PolygonizeDirectedEdge obj = (PolygonizeDirectedEdge)enumerator.Current;
			long label = obj.Label;
			IList list = CustomizeInstance(obj, label);
			if (list != null)
			{
				IEnumerator enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DeleteInstance((Node)enumerator2.Current, label);
				}
			}
		}
	}

	private static IList CustomizeInstance(PolygonizeDirectedEdge polygonizeDirectedEdge_0, long long_0)
	{
		PolygonizeDirectedEdge polygonizeDirectedEdge = polygonizeDirectedEdge_0;
		IList list = null;
		do
		{
			if (polygonizeDirectedEdge == null)
			{
				continue;
			}
			Node fromNode = polygonizeDirectedEdge.FromNode;
			if (RegisterCollection(fromNode, long_0) > 1)
			{
				if (list == null)
				{
					list = new ArrayList();
				}
				list.Add(fromNode);
			}
			polygonizeDirectedEdge = polygonizeDirectedEdge.Next;
			if (polygonizeDirectedEdge != null)
			{
				if (polygonizeDirectedEdge != polygonizeDirectedEdge_0 && polygonizeDirectedEdge.IsInRing)
				{
					throw new DuplicateEdgeException();
				}
				continue;
			}
			throw new NullEdgeException();
		}
		while (polygonizeDirectedEdge != polygonizeDirectedEdge_0);
		return list;
	}

	public virtual IList GetEdgeRings()
	{
		RevertCollection();
		ConnectInstance(DirectedEdges, -1L);
		CountInstance(CloneInstance(DirectedEdges));
		IList list = new ArrayList();
		IEnumerator enumerator = DirectedEdges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PolygonizeDirectedEdge polygonizeDirectedEdge = (PolygonizeDirectedEdge)enumerator.Current;
			if (!polygonizeDirectedEdge.IsMarked && !polygonizeDirectedEdge.IsInRing)
			{
				EdgeRing value = DestroyInstance(polygonizeDirectedEdge);
				list.Add(value);
			}
		}
		return list;
	}

	private static IList CloneInstance(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		long num = 1L;
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PolygonizeDirectedEdge polygonizeDirectedEdge = (PolygonizeDirectedEdge)enumerator.Current;
			if (!polygonizeDirectedEdge.IsMarked && polygonizeDirectedEdge.Label < 0)
			{
				list.Add(polygonizeDirectedEdge);
				ConnectInstance(AddInstance(polygonizeDirectedEdge), num);
				num++;
			}
		}
		return list;
	}

	public virtual IList DeleteCutEdges()
	{
		RevertCollection();
		CloneInstance(DirectedEdges);
		IList list = new ArrayList();
		IEnumerator enumerator = DirectedEdges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PolygonizeDirectedEdge polygonizeDirectedEdge = (PolygonizeDirectedEdge)enumerator.Current;
			if (!polygonizeDirectedEdge.IsMarked)
			{
				PolygonizeDirectedEdge polygonizeDirectedEdge2 = (PolygonizeDirectedEdge)polygonizeDirectedEdge.Sym;
				if (polygonizeDirectedEdge.Label == polygonizeDirectedEdge2.Label)
				{
					polygonizeDirectedEdge.IsMarked = true;
					polygonizeDirectedEdge2.IsMarked = true;
					PolygonizeEdge polygonizeEdge = (PolygonizeEdge)polygonizeDirectedEdge.Edge;
					list.Add(polygonizeEdge.Line);
				}
			}
		}
		return list;
	}

	private static void ConnectInstance(IEnumerable ienumerable_0, long long_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((PolygonizeDirectedEdge)enumerator.Current).Label = long_0;
		}
	}

	private static void MoveInstance(Node node_0)
	{
		DirectedEdgeStar outEdges = node_0.OutEdges;
		PolygonizeDirectedEdge polygonizeDirectedEdge = null;
		PolygonizeDirectedEdge polygonizeDirectedEdge2 = null;
		IEnumerator enumerator = outEdges.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PolygonizeDirectedEdge polygonizeDirectedEdge3 = (PolygonizeDirectedEdge)enumerator.Current;
			if (!polygonizeDirectedEdge3.IsMarked)
			{
				if (polygonizeDirectedEdge == null)
				{
					polygonizeDirectedEdge = polygonizeDirectedEdge3;
				}
				if (polygonizeDirectedEdge2 != null)
				{
					((PolygonizeDirectedEdge)polygonizeDirectedEdge2.Sym).Next = polygonizeDirectedEdge3;
				}
				polygonizeDirectedEdge2 = polygonizeDirectedEdge3;
			}
		}
		if (polygonizeDirectedEdge2 != null)
		{
			((PolygonizeDirectedEdge)polygonizeDirectedEdge2.Sym).Next = polygonizeDirectedEdge;
		}
	}

	private static void DeleteInstance(Node node_0, long long_0)
	{
		DirectedEdgeStar outEdges = node_0.OutEdges;
		PolygonizeDirectedEdge polygonizeDirectedEdge = null;
		PolygonizeDirectedEdge polygonizeDirectedEdge2 = null;
		IList edges = outEdges.Edges;
		for (int num = edges.Count - 1; num >= 0; num--)
		{
			PolygonizeDirectedEdge polygonizeDirectedEdge3 = (PolygonizeDirectedEdge)edges[num];
			PolygonizeDirectedEdge polygonizeDirectedEdge4 = (PolygonizeDirectedEdge)polygonizeDirectedEdge3.Sym;
			PolygonizeDirectedEdge polygonizeDirectedEdge5 = null;
			if (polygonizeDirectedEdge3.Label == long_0)
			{
				polygonizeDirectedEdge5 = polygonizeDirectedEdge3;
			}
			PolygonizeDirectedEdge polygonizeDirectedEdge6 = null;
			if (polygonizeDirectedEdge4.Label == long_0)
			{
				polygonizeDirectedEdge6 = polygonizeDirectedEdge4;
			}
			if (polygonizeDirectedEdge5 != null || polygonizeDirectedEdge6 != null)
			{
				if (polygonizeDirectedEdge6 != null)
				{
					polygonizeDirectedEdge2 = polygonizeDirectedEdge6;
				}
				if (polygonizeDirectedEdge5 != null)
				{
					if (polygonizeDirectedEdge2 != null)
					{
						polygonizeDirectedEdge2.Next = polygonizeDirectedEdge5;
						polygonizeDirectedEdge2 = null;
					}
					if (polygonizeDirectedEdge == null)
					{
						polygonizeDirectedEdge = polygonizeDirectedEdge5;
					}
				}
			}
		}
		if (polygonizeDirectedEdge2 != null)
		{
			Assert.IsTrue(polygonizeDirectedEdge != null);
			polygonizeDirectedEdge2.Next = polygonizeDirectedEdge;
		}
	}

	private static IList AddInstance(PolygonizeDirectedEdge polygonizeDirectedEdge_0)
	{
		PolygonizeDirectedEdge polygonizeDirectedEdge = polygonizeDirectedEdge_0;
		IList list = new ArrayList();
		do
		{
			list.Add(polygonizeDirectedEdge);
			polygonizeDirectedEdge = polygonizeDirectedEdge.Next;
			if (polygonizeDirectedEdge != null)
			{
				if (polygonizeDirectedEdge != polygonizeDirectedEdge_0 && polygonizeDirectedEdge.IsInRing)
				{
					throw new DuplicateEdgeException();
				}
				continue;
			}
			throw new NullEdgeException();
		}
		while (polygonizeDirectedEdge != polygonizeDirectedEdge_0);
		return list;
	}

	private EdgeRing DestroyInstance(PolygonizeDirectedEdge polygonizeDirectedEdge_0)
	{
		PolygonizeDirectedEdge polygonizeDirectedEdge = polygonizeDirectedEdge_0;
		EdgeRing edgeRing = new EdgeRing(m_IssuerRule);
		do
		{
			edgeRing.Add(polygonizeDirectedEdge);
			polygonizeDirectedEdge.Ring = edgeRing;
			polygonizeDirectedEdge = polygonizeDirectedEdge.Next;
			if (polygonizeDirectedEdge != null)
			{
				if (polygonizeDirectedEdge != polygonizeDirectedEdge_0 && polygonizeDirectedEdge.IsInRing)
				{
					throw new DuplicateEdgeException();
				}
				continue;
			}
			throw new NullEdgeException();
		}
		while (polygonizeDirectedEdge != polygonizeDirectedEdge_0);
		return edgeRing;
	}

	public virtual IList DeleteDangles()
	{
		IList list = FindNodesOfDegree(1);
		HashSet<LineString> hashSet = new HashSet<LineString>();
		Stack stack = new Stack();
		IEnumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			stack.Push(enumerator.Current);
		}
		while (stack.Count != 0)
		{
			Node obj = (Node)stack.Pop();
			DeleteAllEdges(obj);
			IEnumerator enumerator2 = obj.OutEdges.Edges.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				PolygonizeDirectedEdge obj2 = (PolygonizeDirectedEdge)enumerator2.Current;
				obj2.IsMarked = true;
				PolygonizeDirectedEdge polygonizeDirectedEdge = (PolygonizeDirectedEdge)obj2.Sym;
				if (polygonizeDirectedEdge != null)
				{
					polygonizeDirectedEdge.IsMarked = true;
				}
				PolygonizeEdge polygonizeEdge = (PolygonizeEdge)obj2.Edge;
				hashSet.Add(polygonizeEdge.Line);
				Node toNode = obj2.ToNode;
				if (OrderCollection(toNode) == 1)
				{
					stack.Push(toNode);
				}
			}
		}
		return new ArrayList(hashSet.ToList());
	}
}
