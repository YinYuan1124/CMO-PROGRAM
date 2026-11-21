using System;
using System.Collections;

namespace Nini.Util;

public class OrderedList : IEnumerable, ICollection, IDictionary
{
	private Hashtable m_SystemCallback = new Hashtable();

	private ArrayList m_CandidateCallback = new ArrayList();

	public int Count => m_CandidateCallback.Count;

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	public object this[int int_0]
	{
		get
		{
			return ((DictionaryEntry)m_CandidateCallback[int_0]).Value;
		}
		set
		{
			if (int_0 < 0 || int_0 >= Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			object key = ((DictionaryEntry)m_CandidateCallback[int_0]).Key;
			m_CandidateCallback[int_0] = new DictionaryEntry(key, value);
			m_SystemCallback[key] = value;
		}
	}

	public object this[object key]
	{
		get
		{
			return m_SystemCallback[key];
		}
		set
		{
			if (m_SystemCallback.Contains(key))
			{
				m_SystemCallback[key] = value;
				m_SystemCallback[NewDecorator(key)] = new DictionaryEntry(key, value);
			}
			else
			{
				Add(key, value);
			}
		}
	}

	public ICollection Keys
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < m_CandidateCallback.Count; i++)
			{
				arrayList.Add(((DictionaryEntry)m_CandidateCallback[i]).Key);
			}
			return arrayList;
		}
	}

	public ICollection Values
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < m_CandidateCallback.Count; i++)
			{
				arrayList.Add(((DictionaryEntry)m_CandidateCallback[i]).Value);
			}
			return arrayList;
		}
	}

	public object SyncRoot => this;

	public void Add(object key, object value)
	{
		m_SystemCallback.Add(key, value);
		m_CandidateCallback.Add(new DictionaryEntry(key, value));
	}

	public void Clear()
	{
		m_SystemCallback.Clear();
		m_CandidateCallback.Clear();
	}

	public bool Contains(object key)
	{
		return m_SystemCallback.Contains(key);
	}

	public void CopyTo(Array array, int index)
	{
		m_SystemCallback.CopyTo(array, index);
	}

	public void CopyTo(DictionaryEntry[] dictionaryEntry_0, int int_0)
	{
		m_SystemCallback.CopyTo(dictionaryEntry_0, int_0);
	}

	public void Insert(int int_0, object object_0, object object_1)
	{
		if (int_0 > Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		m_SystemCallback.Add(object_0, object_1);
		m_CandidateCallback.Insert(int_0, new DictionaryEntry(object_0, object_1));
	}

	public void Remove(object key)
	{
		m_SystemCallback.Remove(key);
		m_CandidateCallback.RemoveAt(NewDecorator(key));
	}

	public void RemoveAt(int int_0)
	{
		if (int_0 >= Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		m_SystemCallback.Remove(((DictionaryEntry)m_CandidateCallback[int_0]).Key);
		m_CandidateCallback.RemoveAt(int_0);
	}

	public IEnumerator GetEnumerator()
	{
		return new OrderedListEnumerator(m_CandidateCallback);
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new OrderedListEnumerator(m_CandidateCallback);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OrderedListEnumerator(m_CandidateCallback);
	}

	private int NewDecorator(object object_0)
	{
		for (int i = 0; i < m_CandidateCallback.Count; i++)
		{
			if (((DictionaryEntry)m_CandidateCallback[i]).Key.Equals(object_0))
			{
				return i;
			}
		}
		return -1;
	}
}
