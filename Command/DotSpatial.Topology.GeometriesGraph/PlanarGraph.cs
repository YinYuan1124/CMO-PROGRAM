using System.Collections;
using System.Collections.Generic;
using System.IO;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.GeometriesGraph;

public class PlanarGraph
{
	private readonly IList m_ConfigurationInstance = new ArrayList();

	private IList tokenInstance = new ArrayList();

	private NodeMap m_IndexerInstance;

	public virtual IList EdgeEnds => m_ConfigurationInstance;

	public IList Edges
	{
		get
		{
			return tokenInstance;
		}
		set
		{
			tokenInstance = value;
		}
	}

	public virtual NodeMap Nodes
	{
		get
		{
			return m_IndexerInstance;
		}
		set
		{
			m_IndexerInstance = value;
		}
	}

	public virtual IList NodeValues => new ArrayList(m_IndexerInstance.Values);

	public PlanarGraph(NodeFactory nodeFactory_0)
	{
		m_IndexerInstance = new NodeMap(nodeFactory_0);
	}

	public PlanarGraph()
	{
		m_IndexerInstance = new NodeMap(new NodeFactory());
	}

	public virtual void Add(EdgeEnd edgeEnd_0)
	{
		m_IndexerInstance.Add(edgeEnd_0);
		m_ConfigurationInstance.Add(edgeEnd_0);
	}

	public virtual void AddEdges(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			tokenInstance.Add(edge);
			DirectedEdge directedEdge = new DirectedEdge(edge, bool_0: true);
			DirectedEdge directedEdge5 = (directedEdge.Sym = new DirectedEdge(edge, bool_0: false));
			DirectedEdge directedEdge2 = directedEdge5;
			DirectedEdge directedEdge3 = directedEdge2;
			directedEdge3.Sym = directedEdge;
			Add(directedEdge);
			Add(directedEdge3);
		}
	}

	public virtual Node AddNode(Node node_0)
	{
		return m_IndexerInstance.AddNode(node_0);
	}

	public virtual Node AddNode(Coordinate coordinate_0)
	{
		return m_IndexerInstance.AddNode(coordinate_0);
	}

	public virtual Node Find(Coordinate coordinate_0)
	{
		return m_IndexerInstance.Find(coordinate_0);
	}

	public virtual EdgeEnd FindEdgeEnd(Edge edge_0)
	{
		IEnumerator enumerator = EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd edgeEnd = (EdgeEnd)enumerator.Current;
			if (edgeEnd.Edge == edge_0)
			{
				return edgeEnd;
			}
		}
		return null;
	}

	public virtual Edge FindEdge(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		for (int i = 0; i < tokenInstance.Count; i++)
		{
			Edge edge = (Edge)tokenInstance[i];
			IList<Coordinate> coordinates = edge.Coordinates;
			if (coordinate_0.Equals(coordinates[0]) && coordinate_1.Equals(coordinates[1]))
			{
				return edge;
			}
		}
		return null;
	}

	public virtual Edge FindEdgeInSameDirection(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		int num = 0;
		Edge edge;
		while (true)
		{
			if (num < tokenInstance.Count)
			{
				edge = (Edge)tokenInstance[num];
				IList<Coordinate> coordinates = edge.Coordinates;
				if (AwakeParameter(coordinate_0, coordinate_1, coordinates[0], coordinates[1]))
				{
					break;
				}
				if (!AwakeParameter(coordinate_0, coordinate_1, coordinates[coordinates.Count - 1], coordinates[coordinates.Count - 2]))
				{
					num++;
					continue;
				}
				return edge;
			}
			return null;
		}
		return edge;
	}

	public virtual IEnumerator GetNodeEnumerator()
	{
		return m_IndexerInstance.GetEnumerator();
	}

	public virtual IEnumerator GetEdgeEnumerator()
	{
		return tokenInstance.GetEnumerator();
	}

	protected virtual void InsertEdge(Edge edge_0)
	{
		tokenInstance.Add(edge_0);
	}

	public virtual void LinkResultDirectedEdges()
	{
		IEnumerator enumerator = m_IndexerInstance.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).LinkResultDirectedEdges();
		}
	}

	public virtual void LinkAllDirectedEdges()
	{
		IEnumerator enumerator = m_IndexerInstance.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).LinkAllDirectedEdges();
		}
	}

	private static bool AwakeParameter(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		if (coordinate_0.Equals(coordinate_2))
		{
			if (CgAlgorithms.ComputeOrientation(coordinate_0, coordinate_1, coordinate_3) == 0)
			{
				return QuadrantOp.Quadrant(coordinate_0, coordinate_1) == QuadrantOp.Quadrant(coordinate_2, coordinate_3);
			}
			return false;
		}
		return false;
	}

	public virtual void WriteEdges(StreamWriter streamWriter_0)
	{
		streamWriter_0.WriteLine("Edges:");
		for (int i = 0; i < tokenInstance.Count; i++)
		{
			streamWriter_0.WriteLine("edge " + i + ":");
			Edge obj = (Edge)tokenInstance[i];
			obj.Write(streamWriter_0);
			obj.EdgeIntersectionList.Write(streamWriter_0);
		}
	}

	public virtual bool IsBoundaryNode(int int_0, Coordinate coordinate_0)
	{
		Node node = m_IndexerInstance.Find(coordinate_0);
		if (node == null)
		{
			return false;
		}
		Label label = node.Label;
		if (label != null && label.GetLocation(int_0) == LocationType.Boundary)
		{
			return true;
		}
		return false;
	}

	public static void LinkResultDirectedEdges(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).LinkResultDirectedEdges();
		}
	}
}
