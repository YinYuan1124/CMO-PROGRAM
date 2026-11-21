using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public class DirectedEdgeStar
{
	private IList m_RecordThread = new ArrayList();

	private bool m_ExceptionThread;

	protected IList OutEdges
	{
		get
		{
			return m_RecordThread;
		}
		set
		{
			m_RecordThread = value;
		}
	}

	public virtual int Degree => m_RecordThread.Count;

	public virtual Coordinate Coordinate
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			if (enumerator.MoveNext())
			{
				return ((DirectedEdge)enumerator.Current).Coordinate;
			}
			return null;
		}
	}

	public virtual IList Edges
	{
		get
		{
			CustomizeCollection();
			return m_RecordThread;
		}
	}

	public virtual void Add(DirectedEdge directedEdge_0)
	{
		m_RecordThread.Add(directedEdge_0);
		m_ExceptionThread = false;
	}

	public virtual void Remove(DirectedEdge directedEdge_0)
	{
		m_RecordThread.Remove(directedEdge_0);
	}

	public virtual IEnumerator GetEnumerator()
	{
		CustomizeCollection();
		return m_RecordThread.GetEnumerator();
	}

	private void CustomizeCollection()
	{
		if (!m_ExceptionThread)
		{
			((ArrayList)m_RecordThread).Sort();
			m_ExceptionThread = true;
		}
	}

	public virtual int GetIndex(Edge edge_0)
	{
		CustomizeCollection();
		int num = 0;
		while (true)
		{
			if (num < m_RecordThread.Count)
			{
				if (((DirectedEdge)m_RecordThread[num]).Edge == edge_0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public virtual int GetIndex(DirectedEdge directedEdge_0)
	{
		CustomizeCollection();
		int num = 0;
		while (true)
		{
			if (num < m_RecordThread.Count)
			{
				if ((DirectedEdge)m_RecordThread[num] == directedEdge_0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public virtual int GetIndex(int int_0)
	{
		int num = int_0 % m_RecordThread.Count;
		if (num < 0)
		{
			num += m_RecordThread.Count;
		}
		return num;
	}

	public virtual DirectedEdge GetNextEdge(DirectedEdge directedEdge_0)
	{
		int index = GetIndex(directedEdge_0);
		return (DirectedEdge)m_RecordThread[GetIndex(index + 1)];
	}
}
