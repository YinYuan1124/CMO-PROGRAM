using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SettlersEngine;

namespace OpenDis.Common;

internal class ObserverCallback<T> where T : IIndexedObject
{
	protected List<T> m_IssuerCallback = new List<T>();

	protected IComparer<T> clientCallback;

	private static object _DicCallback;

	[SpecialName]
	public int StartCallback()
	{
		return m_IssuerCallback.Count;
	}

	public ObserverCallback()
	{
		clientCallback = Comparer<T>.Default;
	}

	public ObserverCallback(IComparer<T> icomparer_0)
	{
		clientCallback = icomparer_0;
	}

	public ObserverCallback(IComparer<T> icomparer_0, int int_0)
	{
		clientCallback = icomparer_0;
		m_IssuerCallback.Capacity = int_0;
	}

	protected void TestCallback(int int_0, int int_1)
	{
		T value = m_IssuerCallback[int_0];
		m_IssuerCallback[int_0] = m_IssuerCallback[int_1];
		m_IssuerCallback[int_1] = value;
		T val = m_IssuerCallback[int_0];
		val.Index = int_0;
		val = m_IssuerCallback[int_1];
		val.Index = int_1;
	}

	protected virtual int OnCompare(int int_0, int int_1)
	{
		return clientCallback.Compare(m_IssuerCallback[int_0], m_IssuerCallback[int_1]);
	}

	public int StopCallback(T item)
	{
		int num = m_IssuerCallback.Count;
		ref T reference = ref item;
		T val = default(T);
		if (val == null)
		{
			val = reference;
			reference = ref val;
		}
		ref T reference2 = ref reference;
		T val2 = default(T);
		if (val2 == null)
		{
			val2 = reference2;
			reference2 = ref val2;
		}
		reference2.Index = m_IssuerCallback.Count;
		m_IssuerCallback.Add(item);
		while (num != 0)
		{
			int num2 = (num - 1) / 2;
			if (OnCompare(num, num2) >= 0)
			{
				break;
			}
			TestCallback(num, num2);
			num = num2;
		}
		return num;
	}

	public T CancelCallback()
	{
		T result = m_IssuerCallback[0];
		int num = 0;
		m_IssuerCallback[0] = m_IssuerCallback[m_IssuerCallback.Count - 1];
		T val = m_IssuerCallback[0];
		val.Index = 0;
		m_IssuerCallback.RemoveAt(m_IssuerCallback.Count - 1);
		result.Index = -1;
		while (true)
		{
			int num2 = num;
			int num3 = 2 * num + 1;
			int num4 = 2 * num + 2;
			if (m_IssuerCallback.Count > num3 && OnCompare(num, num3) > 0)
			{
				num = num3;
			}
			if (m_IssuerCallback.Count > num4 && OnCompare(num, num4) > 0)
			{
				num = num4;
			}
			if (num == num2)
			{
				break;
			}
			TestCallback(num, num2);
		}
		return result;
	}

	public void VerifyCallback(T item)
	{
		int count = m_IssuerCallback.Count;
		while (item.Index - 1 >= 0 && OnCompare(item.Index - 1, item.Index) > 0)
		{
			TestCallback(item.Index - 1, item.Index);
		}
		while (item.Index + 1 < count && OnCompare(item.Index + 1, item.Index) < 0)
		{
			TestCallback(item.Index + 1, item.Index);
		}
	}

	public T ListCallback()
	{
		if (m_IssuerCallback.Count <= 0)
		{
			return default(T);
		}
		return m_IssuerCallback[0];
	}

	public void ResolveCallback()
	{
		m_IssuerCallback.Clear();
	}

	internal static bool PostCallback()
	{
		return _DicCallback == null;
	}
}
