using System.Collections.Generic;

namespace DotSpatial.Topology.KDTree;

public class FarthestNeighborList
{
	private readonly SortedList<double, object> m_TestsCollection;

	public double MinimumPriority
	{
		get
		{
			if (m_TestsCollection.Count == 0)
			{
				return 0.0;
			}
			return m_TestsCollection.Keys[0];
		}
	}

	public bool IsCapacityReached => m_TestsCollection.Count == m_TestsCollection.Capacity;

	public object Farthest
	{
		get
		{
			if (m_TestsCollection.Count == 0)
			{
				return null;
			}
			return m_TestsCollection.Values[m_TestsCollection.Count - 1];
		}
	}

	public bool IsEmpty => m_TestsCollection.Count == 0;

	public int Size => m_TestsCollection.Count;

	public FarthestNeighborList(int int_0)
	{
		m_TestsCollection = new SortedList<double, object>(int_0);
	}

	public bool Insert(object object_0, double double_0)
	{
		if (m_TestsCollection.Count < m_TestsCollection.Capacity)
		{
			m_TestsCollection.Add(double_0, object_0);
			return true;
		}
		if (double_0 < m_TestsCollection.Keys[0])
		{
			return false;
		}
		m_TestsCollection.RemoveAt(0);
		m_TestsCollection.Add(double_0, object_0);
		return true;
	}

	public object RemoveFarthest()
	{
		if (m_TestsCollection.Count <= 0)
		{
			return null;
		}
		int index = m_TestsCollection.Count - 1;
		object result = m_TestsCollection.Values[index];
		m_TestsCollection.RemoveAt(index);
		return result;
	}
}
