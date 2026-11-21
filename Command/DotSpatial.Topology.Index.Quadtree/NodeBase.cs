using System.Collections;

namespace DotSpatial.Topology.Index.Quadtree;

public abstract class NodeBase
{
	private IList _CandidateCollection = new ArrayList();

	private Node[] m_BaseCollection = new Node[4];

	public virtual int Count
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (m_BaseCollection[i] != null)
				{
					num += m_BaseCollection[i].Count;
				}
			}
			return num + _CandidateCollection.Count;
		}
	}

	public virtual int Depth
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (m_BaseCollection[i] != null)
				{
					int depth = m_BaseCollection[i].Depth;
					if (depth > num)
					{
						num = depth;
					}
				}
			}
			return num + 1;
		}
	}

	public Node[] Nodes
	{
		get
		{
			return m_BaseCollection;
		}
		set
		{
			m_BaseCollection = value;
		}
	}

	public virtual bool HasChildren
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < 4)
				{
					if (m_BaseCollection[num] != null)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	public virtual bool HasItems
	{
		get
		{
			if (_CandidateCollection.Count == 0)
			{
				return false;
			}
			return true;
		}
	}

	public virtual bool IsPrunable
	{
		get
		{
			if (HasChildren)
			{
				return false;
			}
			return !HasItems;
		}
	}

	public virtual bool IsEmpty
	{
		get
		{
			bool result = true;
			if (_CandidateCollection.Count != 0)
			{
				result = false;
			}
			for (int i = 0; i < 4; i++)
			{
				if (m_BaseCollection[i] != null && !m_BaseCollection[i].IsEmpty)
				{
					result = false;
				}
			}
			return result;
		}
	}

	public virtual IList Items
	{
		get
		{
			return _CandidateCollection;
		}
		set
		{
			_CandidateCollection = value;
		}
	}

	public virtual int NodeCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (m_BaseCollection[i] != null)
				{
					num += m_BaseCollection[i].NodeCount;
				}
			}
			return num + 1;
		}
	}

	public virtual void Add(object object_0)
	{
		_CandidateCollection.Add(object_0);
	}

	public virtual IList AddAllItems(ref IList ilist_0)
	{
		foreach (object item in _CandidateCollection)
		{
			ilist_0.Add(item);
		}
		for (int i = 0; i < 4; i++)
		{
			if (m_BaseCollection[i] != null)
			{
				m_BaseCollection[i].AddAllItems(ref ilist_0);
			}
		}
		return ilist_0;
	}

	public virtual void AddAllItemsFromOverlapping(IEnvelope ienvelope_0, ref IList ilist_0)
	{
		if (!IsSearchMatch(ienvelope_0))
		{
			return;
		}
		foreach (object item in _CandidateCollection)
		{
			ilist_0.Add(item);
		}
		for (int i = 0; i < 4; i++)
		{
			if (m_BaseCollection[i] != null)
			{
				m_BaseCollection[i].AddAllItemsFromOverlapping(ienvelope_0, ref ilist_0);
			}
		}
	}

	public virtual bool Remove(IEnvelope ienvelope_0, object object_0)
	{
		if (IsSearchMatch(ienvelope_0))
		{
			bool flag = false;
			for (int i = 0; i < 4; i++)
			{
				if (m_BaseCollection[i] != null && (flag = m_BaseCollection[i].Remove(ienvelope_0, object_0)))
				{
					if (m_BaseCollection[i].IsPrunable)
					{
						m_BaseCollection[i] = null;
					}
					break;
				}
			}
			if (flag)
			{
				return true;
			}
			if (_CandidateCollection.Contains(object_0))
			{
				_CandidateCollection.Remove(object_0);
				flag = true;
			}
			return flag;
		}
		return false;
	}

	public virtual void Visit(IEnvelope ienvelope_0, IItemVisitor iitemVisitor_0)
	{
		if (!IsSearchMatch(ienvelope_0))
		{
			return;
		}
		SetParameter(iitemVisitor_0);
		for (int i = 0; i < 4; i++)
		{
			if (m_BaseCollection[i] != null)
			{
				m_BaseCollection[i].Visit(ienvelope_0, iitemVisitor_0);
			}
		}
	}

	protected abstract bool IsSearchMatch(IEnvelope ienvelope_0);

	private void SetParameter(IItemVisitor iitemVisitor_0)
	{
		IEnumerator enumerator = _CandidateCollection.GetEnumerator();
		while (enumerator.MoveNext())
		{
			iitemVisitor_0.VisitItem(enumerator.Current);
		}
	}

	public static int GetSubnodeIndex(IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		int result = -1;
		if (ienvelope_0.Minimum.X >= coordinate_0.X)
		{
			if (ienvelope_0.Minimum.Y >= coordinate_0.Y)
			{
				result = 3;
			}
			if (ienvelope_0.Maximum.Y <= coordinate_0.Y)
			{
				result = 1;
			}
		}
		if (ienvelope_0.Maximum.X <= coordinate_0.X)
		{
			if (ienvelope_0.Minimum.Y >= coordinate_0.Y)
			{
				result = 2;
			}
			if (ienvelope_0.Maximum.Y <= coordinate_0.Y)
			{
				result = 0;
			}
		}
		return result;
	}
}
