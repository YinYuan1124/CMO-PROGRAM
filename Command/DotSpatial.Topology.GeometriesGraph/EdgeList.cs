using System.Collections;
using System.Collections.Generic;
using System.IO;
using DotSpatial.Topology.Index;
using DotSpatial.Topology.Index.Quadtree;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeList
{
	private readonly IList m_InvocationInstance = new ArrayList();

	private readonly ISpatialIndex m_ClassInstance = new Quadtree();

	public virtual IList Edges => m_InvocationInstance;

	public virtual Edge this[int int_0] => Get(int_0);

	public virtual void Remove(Edge edge_0)
	{
		m_InvocationInstance.Remove(edge_0);
	}

	public virtual void Add(Edge edge_0)
	{
		m_InvocationInstance.Add(edge_0);
		m_ClassInstance.Insert(edge_0.Envelope, edge_0);
	}

	public virtual void AddAll(ICollection icollection_0)
	{
		IEnumerator enumerator = icollection_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Add((Edge)enumerator.Current);
		}
	}

	public virtual Edge FindEqualEdge(Edge edge_0)
	{
		IEnumerator enumerator = m_ClassInstance.Query(edge_0.Envelope).GetEnumerator();
		Edge edge;
		do
		{
			if (enumerator.MoveNext())
			{
				edge = (Edge)enumerator.Current;
				continue;
			}
			return null;
		}
		while (!edge.Equals(edge_0));
		return edge;
	}

	public virtual IEnumerator GetEnumerator()
	{
		return m_InvocationInstance.GetEnumerator();
	}

	public virtual Edge Get(int int_0)
	{
		return (Edge)m_InvocationInstance[int_0];
	}

	public virtual int FindEdgeIndex(Edge edge_0)
	{
		for (int i = 0; i < m_InvocationInstance.Count; i++)
		{
			if (m_InvocationInstance[i].Equals(edge_0))
			{
				return i;
			}
		}
		return -1;
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.Write("MULTILINESTRING ( ");
		for (int i = 0; i < m_InvocationInstance.Count; i++)
		{
			Edge obj = (Edge)m_InvocationInstance[i];
			if (i > 0)
			{
				streamWriter_0.Write(",");
			}
			streamWriter_0.Write("(");
			IList<Coordinate> coordinates = obj.Coordinates;
			for (int j = 0; j < coordinates.Count; j++)
			{
				if (j > 0)
				{
					streamWriter_0.Write(",");
				}
				streamWriter_0.Write(coordinates[j].X + " " + coordinates[j].Y);
			}
			streamWriter_0.WriteLine(")");
		}
		streamWriter_0.Write(")  ");
	}
}
