using System.Collections;

namespace DotSpatial.Topology.Index.Bintree;

public abstract class NodeBase
{
	private readonly IList _InfoCollection = new ArrayList();

	private Node[] m_HelperCollection = new Node[2];

	public virtual int Count
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (m_HelperCollection[i] != null)
				{
					num += m_HelperCollection[i].Count;
				}
			}
			return num + _InfoCollection.Count;
		}
	}

	public virtual int Depth
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (m_HelperCollection[i] != null)
				{
					int depth = m_HelperCollection[i].Depth;
					if (depth > num)
					{
						num = depth;
					}
				}
			}
			return num + 1;
		}
	}

	public virtual IList Items => _InfoCollection;

	public virtual int NodeCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (m_HelperCollection[i] != null)
				{
					num += m_HelperCollection[i].NodeCount;
				}
			}
			return num + 1;
		}
	}

	public virtual Node[] Nodes
	{
		get
		{
			return m_HelperCollection;
		}
		protected set
		{
			m_HelperCollection = value;
		}
	}

	public virtual void Add(object object_0)
	{
		_InfoCollection.Add(object_0);
	}

	public virtual IList AddAllItems(IList ilist_0)
	{
		foreach (object item in _InfoCollection)
		{
			ilist_0.Add(item);
		}
		for (int i = 0; i < 2; i++)
		{
			if (m_HelperCollection[i] != null)
			{
				m_HelperCollection[i].AddAllItems(ilist_0);
			}
		}
		return ilist_0;
	}

	public virtual IList AddAllItemsFromOverlapping(Interval interval_0, IList ilist_0)
	{
		if (IsSearchMatch(interval_0))
		{
			foreach (object item in _InfoCollection)
			{
				ilist_0.Add(item);
			}
			for (int i = 0; i < 2; i++)
			{
				if (m_HelperCollection[i] != null)
				{
					m_HelperCollection[i].AddAllItemsFromOverlapping(interval_0, ilist_0);
				}
			}
			return _InfoCollection;
		}
		return _InfoCollection;
	}

	protected abstract bool IsSearchMatch(Interval interval_0);

	public static int GetSubnodeIndex(Interval interval_0, double double_0)
	{
		int result = -1;
		if (interval_0.Min >= double_0)
		{
			result = 1;
		}
		if (interval_0.Max <= double_0)
		{
			result = 0;
		}
		return result;
	}
}
