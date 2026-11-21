using System;
using System.Collections.Generic;

public static class ListIteratorExtensions
{
	public static ListIterator<T> Begin<T>(this IList<T> ilist_0)
	{
		ListIterator<T> result = default(ListIterator<T>);
		result.List = ilist_0;
		return result;
	}

	public static ListIterator<T> End<T>(this IList<T> ilist_0)
	{
		ListIterator<T> result = default(ListIterator<T>);
		result.List = ilist_0;
		result.Index = ilist_0.Count;
		return result;
	}

	public static ListIterator<T> IteratorAt<T>(this IList<T> ilist_0, int int_0)
	{
		ListIterator<T> result = default(ListIterator<T>);
		result.List = ilist_0;
		result.Index = int_0;
		return result;
	}

	public static T GetCurrent<T>(this ListIterator<T> listIterator_0)
	{
		return listIterator_0.List[listIterator_0.Index];
	}

	public static void SetCurrent<T>(this ListIterator<T> listIterator_0, T val)
	{
		listIterator_0.List[listIterator_0.Index] = val;
	}

	public static ListIterator<T> GetNext<T>(this ListIterator<T> listIterator_0)
	{
		listIterator_0.Index++;
		return listIterator_0;
	}

	public static ListIterator<T> GetPrev<T>(this ListIterator<T> listIterator_0)
	{
		listIterator_0.Index--;
		return listIterator_0;
	}

	public static bool IsEqual<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1)
	{
		if (listIterator_0.List == listIterator_1.List)
		{
			return listIterator_0.Index == listIterator_1.Index;
		}
		return false;
	}

	public static bool NotEqual<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1)
	{
		if (listIterator_0.List == listIterator_1.List)
		{
			return listIterator_0.Index != listIterator_1.Index;
		}
		return true;
	}

	public static ListIterator<T> GetAdvanced<T>(this ListIterator<T> listIterator_0, int int_0)
	{
		ListIterator<T> result = default(ListIterator<T>);
		result.List = listIterator_0.List;
		result.Index = listIterator_0.Index + int_0;
		return result;
	}

	public static int Distance<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1)
	{
		return listIterator_1.Index - listIterator_0.Index;
	}

	public static bool AllOf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool AnyOf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (!func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool NoneOf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (!func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static void ForEach<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Action<T> action_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			action_0(listIterator_0.GetCurrent());
			listIterator_0 = listIterator_0.GetNext();
		}
	}

	public static ListIterator<T> Find<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, T val, Func<T, T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (!func_0(listIterator_0.GetCurrent(), val))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return listIterator_0;
		}
		return listIterator_1;
	}

	public static ListIterator<T> FindIf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (!func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return listIterator_0;
		}
		return listIterator_1;
	}

	public static ListIterator<T> FindIfNot<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return listIterator_0;
		}
		return listIterator_1;
	}

	public static ListIterator<T> FindEnd<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, Func<T, T, bool> func_0)
	{
		if (listIterator_2.IsEqual(listIterator_3))
		{
			return listIterator_1;
		}
		ListIterator<T> result = listIterator_1;
		while (listIterator_0.NotEqual(listIterator_1))
		{
			ListIterator<T> listIterator_4 = listIterator_0;
			ListIterator<T> listIterator_5 = listIterator_2;
			while (func_0(listIterator_4.GetCurrent(), listIterator_5.GetCurrent()))
			{
				listIterator_4 = listIterator_4.GetNext();
				listIterator_5 = listIterator_5.GetNext();
				if (!listIterator_5.IsEqual(listIterator_3))
				{
					if (listIterator_4.IsEqual(listIterator_1))
					{
						return result;
					}
					continue;
				}
				result = listIterator_0;
				break;
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		return result;
	}

	public static ListIterator<T> FindFirstOf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, Func<T, T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			ListIterator<T> listIterator_4 = listIterator_2;
			while (listIterator_4.NotEqual(listIterator_3))
			{
				if (!func_0(listIterator_4.GetCurrent(), listIterator_0.GetCurrent()))
				{
					listIterator_4 = listIterator_4.GetNext();
					continue;
				}
				return listIterator_0;
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_1;
	}

	public static ListIterator<T> AdjacentFind<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.NotEqual(listIterator_1))
		{
			ListIterator<T> listIterator_2 = listIterator_0;
			listIterator_2 = listIterator_2.GetNext();
			while (listIterator_2.NotEqual(listIterator_1))
			{
				if (!func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
				{
					listIterator_0 = listIterator_0.GetNext();
					listIterator_2 = listIterator_2.GetNext();
					continue;
				}
				return listIterator_0;
			}
		}
		return listIterator_1;
	}

	public static int Count<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, T val, Func<T, T, bool> func_0)
	{
		int num = 0;
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent(), val))
			{
				num++;
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		return num;
	}

	public static int CountIf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		int num = 0;
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent()))
			{
				num++;
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		return num;
	}

	public static void Mismatch<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T, bool> func_0, out ListIterator<T> listIterator_3, out ListIterator<T> listIterator_4)
	{
		while (listIterator_0.NotEqual(listIterator_1) && func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
		{
			listIterator_0 = listIterator_0.GetNext();
			listIterator_2 = listIterator_2.GetNext();
		}
		listIterator_3 = listIterator_0;
		listIterator_4 = listIterator_2;
	}

	public static bool Equal<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				listIterator_2 = listIterator_2.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool IsPermutation<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T, bool> func_0)
	{
		listIterator_0.Mismatch(listIterator_1, listIterator_2, func_0, out listIterator_0, out listIterator_2);
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return true;
		}
		ListIterator<T> listIterator_3 = listIterator_2;
		listIterator_3 = listIterator_3.GetAdvanced(listIterator_0.Distance(listIterator_1));
		ListIterator<T> listIterator = listIterator_0;
		while (listIterator.NotEqual(listIterator_1))
		{
			if (listIterator_0.Find(listIterator, listIterator.GetCurrent(), func_0).IsEqual(listIterator))
			{
				int num = listIterator_2.Count(listIterator_3, listIterator.GetCurrent(), func_0);
				if (num == 0 || listIterator.Count(listIterator_1, listIterator.GetCurrent(), func_0) != num)
				{
					return false;
				}
			}
			listIterator = listIterator.GetNext();
		}
		return true;
	}

	public static ListIterator<T> Search<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, Func<T, T, bool> func_0)
	{
		if (listIterator_2.IsEqual(listIterator_3))
		{
			return listIterator_0;
		}
		while (listIterator_0.NotEqual(listIterator_1))
		{
			ListIterator<T> listIterator_4 = listIterator_0;
			ListIterator<T> listIterator_5 = listIterator_2;
			while (func_0(listIterator_4.GetCurrent(), listIterator_5.GetCurrent()))
			{
				listIterator_4 = listIterator_4.GetNext();
				listIterator_5 = listIterator_5.GetNext();
				if (!listIterator_5.IsEqual(listIterator_3))
				{
					if (listIterator_4.IsEqual(listIterator_1))
					{
						return listIterator_1;
					}
					continue;
				}
				return listIterator_0;
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_1;
	}

	public static ListIterator<T> SearchN<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, int int_0, T val, Func<T, T, bool> func_0)
	{
		ListIterator<T> advanced = listIterator_0.GetAdvanced(listIterator_0.Distance(listIterator_1) - int_0);
		while (listIterator_0.NotEqual(advanced))
		{
			ListIterator<T> listIterator_2 = listIterator_0;
			int num = 0;
			while (func_0(val, listIterator_2.GetCurrent()))
			{
				listIterator_2 = listIterator_2.GetNext();
				if (++num == int_0)
				{
					return listIterator_0;
				}
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_1;
	}

	public static ListIterator<T> Copy<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			listIterator_2.SetCurrent(listIterator_0.GetCurrent());
			listIterator_2 = listIterator_2.GetNext();
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_2;
	}

	public static ListIterator<T> CopyN<T>(this ListIterator<T> listIterator_0, int int_0, ListIterator<T> listIterator_1)
	{
		while (int_0 > 0)
		{
			listIterator_1.SetCurrent(listIterator_0.GetCurrent());
			listIterator_1 = listIterator_1.GetNext();
			listIterator_0 = listIterator_0.GetNext();
			int_0--;
		}
		return listIterator_1;
	}

	public static ListIterator<T> CopyIf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent()))
			{
				listIterator_2.SetCurrent(listIterator_0.GetCurrent());
				listIterator_2 = listIterator_2.GetNext();
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_2;
	}

	public static ListIterator<T> CopyBackward<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2)
	{
		while (listIterator_1.NotEqual(listIterator_0))
		{
			listIterator_2 = listIterator_2.GetPrev();
			listIterator_1 = listIterator_1.GetPrev();
			listIterator_2.SetCurrent(listIterator_1.GetCurrent());
		}
		return listIterator_2;
	}

	public static ListIterator<T> SwapRanges<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			listIterator_0.Swap(listIterator_2);
			listIterator_0 = listIterator_0.GetNext();
			listIterator_2 = listIterator_2.GetNext();
		}
		return listIterator_2;
	}

	public static void Swap<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1)
	{
		T current = listIterator_0.GetCurrent();
		listIterator_0.SetCurrent(listIterator_1.GetCurrent());
		listIterator_1.SetCurrent(current);
	}

	public static ListIterator<T> Transform<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			listIterator_2.SetCurrent(func_0(listIterator_0.GetCurrent()));
			listIterator_2 = listIterator_2.GetNext();
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_2;
	}

	public static ListIterator<T> Transform<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, Func<T, T, T> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			listIterator_3.SetCurrent(func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()));
			listIterator_2 = listIterator_2.GetNext();
			listIterator_3 = listIterator_3.GetNext();
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_3;
	}

	public static void ReplaceIf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0, T newValue)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0.SetCurrent(newValue);
			}
			listIterator_0 = listIterator_0.GetNext();
		}
	}

	public static ListIterator<T> ReplaceCopyIf<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, bool> func_0, T newValue)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			listIterator_2.SetCurrent(func_0(listIterator_0.GetCurrent()) ? newValue : listIterator_0.GetCurrent());
			listIterator_0 = listIterator_0.GetNext();
			listIterator_2 = listIterator_2.GetNext();
		}
		return listIterator_2;
	}

	public static ListIterator<T> Unique<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return listIterator_1;
		}
		ListIterator<T> listIterator_2 = listIterator_0;
		while ((listIterator_0 = listIterator_0.GetNext()).NotEqual(listIterator_1))
		{
			if (!func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator_2 = listIterator_2.GetNext();
				listIterator_2.SetCurrent(listIterator_0.GetCurrent());
			}
		}
		return listIterator_2.GetNext();
	}

	public static ListIterator<T> UniqueCopy<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T, bool> func_0)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return listIterator_1;
		}
		listIterator_2.SetCurrent(listIterator_0.GetCurrent());
		while ((listIterator_0 = listIterator_0.GetNext()).NotEqual(listIterator_1))
		{
			T current = listIterator_0.GetCurrent();
			if (!func_0(listIterator_2.GetCurrent(), current))
			{
				listIterator_2 = listIterator_2.GetNext();
				listIterator_2.SetCurrent(current);
			}
		}
		listIterator_2 = listIterator_2.GetNext();
		return listIterator_2;
	}

	public static void Reverse<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1)
	{
		while (listIterator_0.NotEqual(listIterator_1) && listIterator_0.NotEqual(listIterator_1 = listIterator_1.GetPrev()))
		{
			listIterator_0.Swap(listIterator_1);
			listIterator_0 = listIterator_0.GetNext();
		}
	}

	public static ListIterator<T> ReverseCopy<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			listIterator_1 = listIterator_1.GetPrev();
			listIterator_2.SetCurrent(listIterator_1.GetCurrent());
			listIterator_2 = listIterator_2.GetNext();
		}
		return listIterator_2;
	}

	public static void Rotate<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2)
	{
		ListIterator<T> listIterator = listIterator_1;
		while (listIterator_0.NotEqual(listIterator_2))
		{
			listIterator_0.Swap(listIterator);
			listIterator_0 = listIterator_0.GetNext();
			listIterator = listIterator.GetNext();
			if (listIterator.IsEqual(listIterator_2))
			{
				listIterator = listIterator_1;
			}
			else if (listIterator_0.IsEqual(listIterator_1))
			{
				listIterator_1 = listIterator;
			}
		}
	}

	public static ListIterator<T> RotateCopy<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3)
	{
		listIterator_3 = listIterator_1.Copy(listIterator_2, listIterator_3);
		return listIterator_0.Copy(listIterator_1, listIterator_3);
	}

	public static void RandomShuffle<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<int, int> func_0)
	{
		for (int num = listIterator_0.Distance(listIterator_1) - 1; num > 0; num--)
		{
			listIterator_0.GetAdvanced(num).Swap(listIterator_0.GetAdvanced(func_0(num + 1)));
		}
	}

	public static bool IsPartitioned<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1) && func_0(listIterator_0.GetCurrent()))
		{
			listIterator_0 = listIterator_0.GetNext();
		}
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (!func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static ListIterator<T> Partition<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			while (func_0(listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				if (listIterator_0.IsEqual(listIterator_1))
				{
					return listIterator_0;
				}
			}
			do
			{
				listIterator_1 = listIterator_1.GetPrev();
				if (listIterator_0.IsEqual(listIterator_1))
				{
					return listIterator_0;
				}
			}
			while (!func_0(listIterator_1.GetCurrent()));
			listIterator_0.Swap(listIterator_1);
			listIterator_0 = listIterator_0.GetNext();
		}
		return listIterator_0;
	}

	public static void PartitionCopy<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, Func<T, bool> func_0, out ListIterator<T> listIterator_4, out ListIterator<T> listIterator_5)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent()))
			{
				listIterator_2.SetCurrent(listIterator_0.GetCurrent());
				listIterator_2 = listIterator_2.GetNext();
			}
			else
			{
				listIterator_3.SetCurrent(listIterator_0.GetCurrent());
				listIterator_3 = listIterator_3.GetNext();
			}
			listIterator_0 = listIterator_0.GetNext();
		}
		listIterator_4 = listIterator_2;
		listIterator_5 = listIterator_3;
	}

	public static ListIterator<T> PartitionPoint<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, bool> func_0)
	{
		int num = listIterator_0.Distance(listIterator_1);
		while (num > 0)
		{
			ListIterator<T> listIterator_2 = listIterator_0;
			int num2 = num / 2;
			listIterator_2.GetAdvanced(num2);
			if (func_0(listIterator_2.GetCurrent()))
			{
				listIterator_0 = listIterator_2.GetNext();
				num -= num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return listIterator_0;
	}

	public static void Sort<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return;
		}
		ListIterator<T> listIterator = listIterator_0;
		ListIterator<T> next = listIterator_0.GetNext();
		while (next.NotEqual(listIterator_1))
		{
			if (func_0(next.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator = listIterator.GetNext();
				listIterator.Swap(next);
			}
			next = next.GetNext();
		}
		listIterator_0.Swap(listIterator);
		listIterator_0.Sort(listIterator, func_0);
		listIterator.GetNext().Sort(listIterator_1, func_0);
	}

	public static void StableSort<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		IList<T> list = listIterator_0.List;
		for (int i = listIterator_0.Index + 1; i < listIterator_1.Index; i++)
		{
			T val = list[i];
			int num = listIterator_0.Index;
			int num2 = i - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				if (func_0(val, list[num3]))
				{
					num2 = num3 - 1;
				}
				else
				{
					num = num3 + 1;
				}
			}
			for (int num4 = i - 1; num4 >= num; num4--)
			{
				list[num4 + 1] = list[num4];
			}
			list[num] = val;
		}
	}

	public static void PartialSort<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T, bool> func_0)
	{
		listIterator_0.Sort(listIterator_2, func_0);
	}

	public static bool IsSorted<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return true;
		}
		ListIterator<T> listIterator_2 = listIterator_0;
		while ((listIterator_2 = listIterator_2.GetNext()).NotEqual(listIterator_1))
		{
			if (!func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static ListIterator<T> IsSortedUntil<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return listIterator_0;
		}
		ListIterator<T> listIterator = listIterator_0;
		while ((listIterator = listIterator.GetNext()).NotEqual(listIterator_1))
		{
			if (!func_0(listIterator.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return listIterator;
		}
		return listIterator_1;
	}

	public static void NthElement<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T, bool> func_0)
	{
		listIterator_0.Sort(listIterator_2, func_0);
	}

	public static ListIterator<T> LowerBound<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, T val, Func<T, T, bool> func_0)
	{
		int num = listIterator_0.Distance(listIterator_1);
		while (num > 0)
		{
			ListIterator<T> listIterator_2 = listIterator_0;
			int num2 = num / 2;
			listIterator_2 = listIterator_2.GetAdvanced(num2);
			if (func_0(listIterator_2.GetCurrent(), val))
			{
				listIterator_2 = listIterator_2.GetNext();
				listIterator_0 = listIterator_2;
				num -= num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return listIterator_0;
	}

	public static ListIterator<T> UpperBound<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, T val, Func<T, T, bool> func_0)
	{
		int num = listIterator_0.Distance(listIterator_1);
		while (num > 0)
		{
			ListIterator<T> listIterator_2 = listIterator_0;
			int num2 = num / 2;
			listIterator_2 = listIterator_2.GetAdvanced(num2);
			if (func_0(val, listIterator_2.GetCurrent()))
			{
				num = num2;
				continue;
			}
			listIterator_2 = listIterator_2.GetNext();
			listIterator_0 = listIterator_2;
			num -= num2 + 1;
		}
		return listIterator_0;
	}

	public static void EqualRange<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, T val, Func<T, T, bool> func_0, out ListIterator<T> listIterator_2, out ListIterator<T> listIterator_3)
	{
		listIterator_2 = listIterator_0.LowerBound(listIterator_1, val, func_0);
		listIterator_3 = listIterator_2.UpperBound(listIterator_1, val, func_0);
	}

	public static bool BinarySearch<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, T val, Func<T, T, bool> func_0)
	{
		listIterator_0 = listIterator_0.LowerBound(listIterator_1, val, func_0);
		if (listIterator_0.NotEqual(listIterator_1))
		{
			return !func_0(val, listIterator_0.GetCurrent());
		}
		return false;
	}

	public static ListIterator<T> Merge<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, ListIterator<T> listIterator_4, Func<T, T, bool> func_0)
	{
		while (true)
		{
			if (!listIterator_0.IsEqual(listIterator_1))
			{
				if (listIterator_2.IsEqual(listIterator_3))
				{
					break;
				}
				if (func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
				{
					listIterator_4.SetCurrent(listIterator_2.GetCurrent());
					listIterator_2 = listIterator_2.GetNext();
				}
				else
				{
					listIterator_4.SetCurrent(listIterator_0.GetCurrent());
					listIterator_0 = listIterator_0.GetNext();
				}
				listIterator_4 = listIterator_4.GetNext();
				continue;
			}
			return listIterator_2.Copy(listIterator_3, listIterator_4);
		}
		return listIterator_0.Copy(listIterator_1, listIterator_4);
	}

	public static void InplaceMerge<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, Func<T, T, bool> func_0)
	{
		if (listIterator_0.Index >= listIterator_1.Index || listIterator_1.Index >= listIterator_2.Index)
		{
			return;
		}
		if (listIterator_2.Index - listIterator_0.Index == 2)
		{
			if (func_0(listIterator_1.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator_0.Swap(listIterator_1);
			}
			return;
		}
		ListIterator<T> listIterator;
		ListIterator<T> listIterator2;
		if (listIterator_1.Index - listIterator_0.Index <= listIterator_2.Index - listIterator_1.Index)
		{
			listIterator = listIterator_1.GetAdvanced(listIterator_1.Distance(listIterator_2) / 2);
			listIterator2 = listIterator_0.UpperBound(listIterator_1, listIterator.GetCurrent(), func_0);
		}
		else
		{
			listIterator2 = listIterator_0.GetAdvanced(listIterator_0.Distance(listIterator_1) / 2);
			listIterator = listIterator_1.LowerBound(listIterator_2, listIterator2.GetCurrent(), func_0);
		}
		listIterator2.Rotate(listIterator_1, listIterator);
		listIterator_1 = listIterator2.GetAdvanced(listIterator_1.Distance(listIterator));
		listIterator_0.InplaceMerge(listIterator2, listIterator_1, func_0);
		listIterator_1.InplaceMerge(listIterator, listIterator_2, func_0);
	}

	public static bool Includes<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, Func<T, T, bool> func_0)
	{
		while (listIterator_2.NotEqual(listIterator_3))
		{
			if (!listIterator_0.IsEqual(listIterator_1) && !func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
			{
				if (!func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
				{
					listIterator_2 = listIterator_2.GetNext();
				}
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static ListIterator<T> SetUnion<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, ListIterator<T> listIterator_4, Func<T, T, bool> func_0)
	{
		while (true)
		{
			if (!listIterator_0.IsEqual(listIterator_1))
			{
				if (listIterator_2.IsEqual(listIterator_3))
				{
					break;
				}
				if (func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
				{
					listIterator_4.SetCurrent(listIterator_0.GetCurrent());
					listIterator_0 = listIterator_0.GetNext();
				}
				else if (func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
				{
					listIterator_4.SetCurrent(listIterator_2.GetCurrent());
					listIterator_2 = listIterator_2.GetNext();
				}
				else
				{
					listIterator_4.SetCurrent(listIterator_0.GetCurrent());
					listIterator_0 = listIterator_0.GetNext();
					listIterator_2 = listIterator_2.GetNext();
				}
				listIterator_4 = listIterator_4.GetNext();
				continue;
			}
			return listIterator_2.Copy(listIterator_3, listIterator_4);
		}
		return listIterator_0.Copy(listIterator_1, listIterator_4);
	}

	public static ListIterator<T> SetIntersection<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, ListIterator<T> listIterator_4, Func<T, T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1) && listIterator_2.NotEqual(listIterator_3))
		{
			if (func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
			{
				listIterator_0 = listIterator_0.GetNext();
				continue;
			}
			if (func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator_2 = listIterator_2.GetNext();
				continue;
			}
			listIterator_4.SetCurrent(listIterator_0.GetCurrent());
			listIterator_4 = listIterator_4.GetNext();
			listIterator_0 = listIterator_0.GetNext();
			listIterator_2 = listIterator_2.GetNext();
		}
		return listIterator_4;
	}

	public static ListIterator<T> SetDifference<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, ListIterator<T> listIterator_4, Func<T, T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1) && listIterator_2.NotEqual(listIterator_3))
		{
			if (func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
			{
				listIterator_4.SetCurrent(listIterator_0.GetCurrent());
				listIterator_4 = listIterator_4.GetNext();
				listIterator_0 = listIterator_0.GetNext();
			}
			else if (func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator_2 = listIterator_2.GetNext();
			}
			else
			{
				listIterator_0 = listIterator_0.GetNext();
				listIterator_2 = listIterator_2.GetNext();
			}
		}
		return listIterator_0.Copy(listIterator_1, listIterator_4);
	}

	public static ListIterator<T> SetSymmetricDifference<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, ListIterator<T> listIterator_4, Func<T, T, bool> func_0)
	{
		while (true)
		{
			if (!listIterator_0.IsEqual(listIterator_1))
			{
				if (listIterator_2.IsEqual(listIterator_3))
				{
					break;
				}
				if (func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
				{
					listIterator_4.SetCurrent(listIterator_0.GetCurrent());
					listIterator_4 = listIterator_4.GetNext();
					listIterator_0 = listIterator_0.GetNext();
				}
				else if (func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
				{
					listIterator_4.SetCurrent(listIterator_2.GetCurrent());
					listIterator_4 = listIterator_4.GetNext();
					listIterator_2 = listIterator_2.GetNext();
				}
				else
				{
					listIterator_0 = listIterator_0.GetNext();
					listIterator_2 = listIterator_2.GetNext();
				}
				continue;
			}
			return listIterator_2.Copy(listIterator_3, listIterator_4);
		}
		return listIterator_0.Copy(listIterator_1, listIterator_4);
	}

	public static void PushHeap<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.Distance(listIterator_1) >= 2)
		{
			listIterator_1 = listIterator_1.GetPrev();
			T current = listIterator_1.GetCurrent();
			ListIterator<T> advanced = listIterator_0.GetAdvanced((listIterator_0.Distance(listIterator_1) - 1) / 2);
			while (listIterator_0.Distance(listIterator_1) > 0 && func_0(advanced.GetCurrent(), current))
			{
				listIterator_1.SetCurrent(advanced.GetCurrent());
				listIterator_1 = advanced;
				advanced = listIterator_0.GetAdvanced((listIterator_0.Distance(listIterator_1) - 1) / 2);
			}
			listIterator_1.SetCurrent(current);
		}
	}

	public static void PopHeap<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.Distance(listIterator_1) >= 2)
		{
			listIterator_1 = listIterator_1.GetPrev();
			listIterator_0.Swap(listIterator_1);
			listIterator_0.List.ConcatStruct(listIterator_0.Index, listIterator_0.Index, listIterator_1.Index, func_0);
		}
	}

	public static void MakeHeap<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		int num = listIterator_0.Distance(listIterator_1);
		if (num >= 2)
		{
			int num2 = (num - 2) / 2;
			do
			{
				listIterator_0.List.ConcatStruct(listIterator_0.Index, listIterator_0.Index + num2, listIterator_1.Index, func_0);
			}
			while (num2-- != 0);
		}
	}

	public static void SortHeap<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		while (listIterator_0.Distance(listIterator_1) > 1)
		{
			listIterator_1 = listIterator_1.GetPrev();
			listIterator_0.Swap(listIterator_1);
			listIterator_0.List.ConcatStruct(listIterator_0.Index, listIterator_0.Index, listIterator_1.Index, func_0);
		}
	}

	private static void ConcatStruct<T>(this IList<T> ilist_0, int int_0, int int_1, int int_2, Func<T, T, bool> func_0)
	{
		T val = ilist_0[int_1];
		int num = int_2 - int_0;
		int num2 = int_1 - int_0;
		int num3;
		for (num3 = 2 * num2 + 2; num3 < num; num3 *= 2)
		{
			if (func_0(ilist_0[int_0 + num3], ilist_0[int_0 + (num3 - 1)]))
			{
				num3--;
			}
			ilist_0[int_0 + num2] = ilist_0[int_0 + num3];
			num2 = num3++;
		}
		if (num3-- == num)
		{
			ilist_0[int_0 + num2] = ilist_0[int_0 + num3];
			num2 = num3;
		}
		int num4 = (num2 - 1) / 2;
		int num5 = int_1 - int_0;
		while (num2 != num5 && func_0(ilist_0[int_0 + num4], val))
		{
			ilist_0[int_0 + num2] = ilist_0[int_0 + num4];
			num2 = num4;
			num4 = (num2 - 1) / 2;
		}
		ilist_0[int_0 + num2] = val;
	}

	public static bool IsHeap<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		return listIterator_0.IsHeapUntil(listIterator_1, func_0).IsEqual(listIterator_1);
	}

	public static ListIterator<T> IsHeapUntil<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		int num = listIterator_0.Distance(listIterator_1);
		int num2 = 0;
		int num3 = 1;
		ListIterator<T> listIterator_2 = listIterator_0;
		while (num3 < num)
		{
			ListIterator<T> advanced = listIterator_0.GetAdvanced(num3);
			if (!func_0(listIterator_2.GetCurrent(), advanced.GetCurrent()))
			{
				num3++;
				advanced = advanced.GetNext();
				if (num3 != num)
				{
					if (!func_0(listIterator_2.GetCurrent(), advanced.GetCurrent()))
					{
						num2++;
						listIterator_2 = listIterator_2.GetNext();
						num3 = 2 * num2 + 1;
						continue;
					}
					return advanced;
				}
				return listIterator_1;
			}
			return advanced;
		}
		return listIterator_1;
	}

	public static ListIterator<T> MinElement<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return listIterator_1;
		}
		ListIterator<T> listIterator = listIterator_0;
		while ((listIterator_0 = listIterator_0.GetNext()).NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent(), listIterator.GetCurrent()))
			{
				listIterator = listIterator_0;
			}
		}
		return listIterator;
	}

	public static ListIterator<T> MaxElement<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			return listIterator_1;
		}
		ListIterator<T> listIterator = listIterator_0;
		while ((listIterator_0 = listIterator_0.GetNext()).NotEqual(listIterator_1))
		{
			if (func_0(listIterator.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator = listIterator_0;
			}
		}
		return listIterator;
	}

	public static void MinMaxElement<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0, out ListIterator<T> listIterator_2, out ListIterator<T> listIterator_3)
	{
		if (listIterator_0.IsEqual(listIterator_1))
		{
			listIterator_2 = listIterator_1;
			listIterator_3 = listIterator_1;
		}
		listIterator_2 = listIterator_0;
		listIterator_3 = listIterator_0;
		while ((listIterator_0 = listIterator_0.GetNext()).NotEqual(listIterator_1))
		{
			if (func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
			{
				listIterator_2 = listIterator_0;
			}
			if (func_0(listIterator_3.GetCurrent(), listIterator_0.GetCurrent()))
			{
				listIterator_3 = listIterator_0;
			}
		}
	}

	public static bool LexicographicalCompare<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, ListIterator<T> listIterator_2, ListIterator<T> listIterator_3, Func<T, T, bool> func_0)
	{
		while (listIterator_0.NotEqual(listIterator_1))
		{
			if (!listIterator_2.IsEqual(listIterator_3) && !func_0(listIterator_2.GetCurrent(), listIterator_0.GetCurrent()))
			{
				if (!func_0(listIterator_0.GetCurrent(), listIterator_2.GetCurrent()))
				{
					listIterator_0 = listIterator_0.GetNext();
					listIterator_2 = listIterator_2.GetNext();
					continue;
				}
				return true;
			}
			return false;
		}
		return listIterator_2.NotEqual(listIterator_3);
	}

	public static bool NextPermutation<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		ListIterator<T> listIterator_2 = listIterator_1;
		if (!listIterator_0.IsEqual(listIterator_1) && !listIterator_0.IsEqual(listIterator_2 = listIterator_2.GetPrev()))
		{
			do
			{
				ListIterator<T> listIterator_3 = listIterator_2;
				if (func_0((listIterator_2 = listIterator_2.GetPrev()).GetCurrent(), listIterator_3.GetCurrent()))
				{
					ListIterator<T> listIterator = listIterator_1;
					while (!func_0(listIterator_2.GetCurrent(), (listIterator = listIterator.GetPrev()).GetCurrent()))
					{
					}
					listIterator_2.Swap(listIterator);
					listIterator_3.Reverse(listIterator_1);
					return true;
				}
			}
			while (!listIterator_2.IsEqual(listIterator_0));
			listIterator_0.Reverse(listIterator_1);
			return false;
		}
		return false;
	}

	public static bool PrevPermutation<T>(this ListIterator<T> listIterator_0, ListIterator<T> listIterator_1, Func<T, T, bool> func_0)
	{
		ListIterator<T> listIterator_2 = listIterator_1;
		if (!listIterator_0.IsEqual(listIterator_1) && !listIterator_0.IsEqual(listIterator_2 = listIterator_2.GetPrev()))
		{
			do
			{
				ListIterator<T> listIterator_3 = listIterator_2;
				if (func_0(listIterator_3.GetCurrent(), (listIterator_2 = listIterator_2.GetPrev()).GetCurrent()))
				{
					ListIterator<T> listIterator = listIterator_1;
					while (!func_0((listIterator = listIterator.GetPrev()).GetCurrent(), listIterator_2.GetCurrent()))
					{
					}
					listIterator_2.Swap(listIterator);
					listIterator_3.Reverse(listIterator_1);
					return true;
				}
			}
			while (!listIterator_2.IsEqual(listIterator_0));
			listIterator_0.Reverse(listIterator_1);
			return false;
		}
		return false;
	}
}
