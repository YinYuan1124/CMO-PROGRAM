using System.Collections.Generic;

namespace Algorithms;

[Author("Franco, Gustavo")]
public class PriorityQueueB<T> : IPriorityQueue<T>
{
	protected List<T> InnerList = new List<T>();

	protected IComparer<T> mComparer;

	internal static object strategyConfig;

	public int Count => InnerList.Count;

	public T this[int int_0]
	{
		get
		{
			return InnerList[int_0];
		}
		set
		{
			InnerList[int_0] = value;
			Update(int_0);
		}
	}

	public PriorityQueueB()
	{
		mComparer = Comparer<T>.Default;
	}

	public PriorityQueueB(IComparer<T> icomparer_0)
	{
		mComparer = icomparer_0;
	}

	public PriorityQueueB(IComparer<T> icomparer_0, int int_0)
	{
		mComparer = icomparer_0;
		InnerList.Capacity = int_0;
	}

	protected void SwitchElements(int int_0, int int_1)
	{
		T value = InnerList[int_0];
		InnerList[int_0] = InnerList[int_1];
		InnerList[int_1] = value;
	}

	protected virtual int OnCompare(int int_0, int int_1)
	{
		return mComparer.Compare(InnerList[int_0], InnerList[int_1]);
	}

	public int Push(T item)
	{
		int num = InnerList.Count;
		InnerList.Add(item);
		while (num != 0)
		{
			int num2 = (num - 1) / 2;
			if (OnCompare(num, num2) >= 0)
			{
				break;
			}
			SwitchElements(num, num2);
			num = num2;
		}
		return num;
	}

	public T Pop()
	{
		T result = InnerList[0];
		int num = 0;
		InnerList[0] = InnerList[InnerList.Count - 1];
		InnerList.RemoveAt(InnerList.Count - 1);
		while (true)
		{
			int num2 = num;
			int num3 = 2 * num + 1;
			int num4 = 2 * num + 2;
			if (InnerList.Count > num3 && OnCompare(num, num3) > 0)
			{
				num = num3;
			}
			if (InnerList.Count > num4 && OnCompare(num, num4) > 0)
			{
				num = num4;
			}
			if (num == num2)
			{
				break;
			}
			SwitchElements(num, num2);
		}
		return result;
	}

	public void Update(int int_0)
	{
		int num = int_0;
		while (num != 0)
		{
			int num2 = (num - 1) / 2;
			if (OnCompare(num, num2) >= 0)
			{
				break;
			}
			SwitchElements(num, num2);
			num = num2;
		}
		if (num < int_0)
		{
			return;
		}
		while (true)
		{
			int num3 = num;
			int num4 = 2 * num + 1;
			int num5 = 2 * num + 2;
			if (InnerList.Count > num4 && OnCompare(num, num4) > 0)
			{
				num = num4;
			}
			if (InnerList.Count > num5 && OnCompare(num, num5) > 0)
			{
				num = num5;
			}
			if (num != num3)
			{
				SwitchElements(num, num3);
				continue;
			}
			break;
		}
	}

	public T Peek()
	{
		if (InnerList.Count <= 0)
		{
			return default(T);
		}
		return InnerList[0];
	}

	public void Clear()
	{
		InnerList.Clear();
	}

	public void RemoveLocation(T item)
	{
		int num = -1;
		for (int i = 0; i < InnerList.Count; i++)
		{
			if (mComparer.Compare(InnerList[i], item) == 0)
			{
				num = i;
			}
		}
		if (num != -1)
		{
			InnerList.RemoveAt(num);
		}
	}

	internal static bool WriteObserver()
	{
		return strategyConfig == null;
	}
}
