using System;
using System.Collections;

namespace Nini.Util;

public class OrderedListEnumerator : IEnumerator, IDictionaryEnumerator
{
	private int _BaseCallback = -1;

	private ArrayList m_PolicyCallback;

	object IEnumerator.Current
	{
		get
		{
			if (_BaseCallback < 0 || _BaseCallback >= m_PolicyCallback.Count)
			{
				throw new InvalidOperationException();
			}
			return m_PolicyCallback[_BaseCallback];
		}
	}

	public DictionaryEntry Current
	{
		get
		{
			if (_BaseCallback < 0 || _BaseCallback >= m_PolicyCallback.Count)
			{
				throw new InvalidOperationException();
			}
			return (DictionaryEntry)m_PolicyCallback[_BaseCallback];
		}
	}

	public DictionaryEntry Entry => Current;

	public object Key => Entry.Key;

	public object Value => Entry.Value;

	internal OrderedListEnumerator(ArrayList arrayList_0)
	{
		m_PolicyCallback = arrayList_0;
	}

	public bool MoveNext()
	{
		_BaseCallback++;
		if (_BaseCallback < m_PolicyCallback.Count)
		{
			return true;
		}
		return false;
	}

	public void Reset()
	{
		_BaseCallback = -1;
	}
}
