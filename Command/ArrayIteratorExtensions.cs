using System;

public static class ArrayIteratorExtensions
{
	public static ArrayIterator<T> Begin<T>(this T[] gparam_0)
	{
		ArrayIterator<T> result = default(ArrayIterator<T>);
		result.Array = gparam_0;
		return result;
	}

	public static ArrayIterator<T> End<T>(this T[] gparam_0)
	{
		ArrayIterator<T> result = default(ArrayIterator<T>);
		result.Array = gparam_0;
		result.Index = gparam_0.Length;
		return result;
	}

	public static ArrayIterator<T> IteratorAt<T>(this T[] gparam_0, int int_0)
	{
		ArrayIterator<T> result = default(ArrayIterator<T>);
		result.Array = gparam_0;
		result.Index = int_0;
		return result;
	}

	public static T GetCurrent<T>(this ArrayIterator<T> arrayIterator_0)
	{
		return arrayIterator_0.Array[arrayIterator_0.Index];
	}

	public static void SetCurrent<T>(this ArrayIterator<T> arrayIterator_0, T val)
	{
		arrayIterator_0.Array[arrayIterator_0.Index] = val;
	}

	public static ArrayIterator<T> GetNext<T>(this ArrayIterator<T> arrayIterator_0)
	{
		arrayIterator_0.Index++;
		return arrayIterator_0;
	}

	public static ArrayIterator<T> GetPrev<T>(this ArrayIterator<T> arrayIterator_0)
	{
		arrayIterator_0.Index--;
		return arrayIterator_0;
	}

	public static bool IsEqual<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1)
	{
		if (arrayIterator_0.Array == arrayIterator_1.Array)
		{
			return arrayIterator_0.Index == arrayIterator_1.Index;
		}
		return false;
	}

	public static bool NotEqual<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1)
	{
		if (arrayIterator_0.Array == arrayIterator_1.Array)
		{
			return arrayIterator_0.Index != arrayIterator_1.Index;
		}
		return true;
	}

	public static ArrayIterator<T> GetAdvanced<T>(this ArrayIterator<T> arrayIterator_0, int int_0)
	{
		ArrayIterator<T> result = default(ArrayIterator<T>);
		result.Array = arrayIterator_0.Array;
		result.Index = arrayIterator_0.Index + int_0;
		return result;
	}

	public static int Distance<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1)
	{
		return arrayIterator_1.Index - arrayIterator_0.Index;
	}

	public static bool AllOf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool AnyOf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool NoneOf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static void ForEach<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Action<T> action_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			action_0(arrayIterator_0.GetCurrent());
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
	}

	public static ArrayIterator<T> Find<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, T val, Func<T, T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator_0.GetCurrent(), val))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return arrayIterator_0;
		}
		return arrayIterator_1;
	}

	public static ArrayIterator<T> FindIf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return arrayIterator_0;
		}
		return arrayIterator_1;
	}

	public static ArrayIterator<T> FindIfNot<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return arrayIterator_0;
		}
		return arrayIterator_1;
	}

	public static ArrayIterator<T> FindEnd<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, Func<T, T, bool> func_0)
	{
		if (arrayIterator_2.IsEqual(arrayIterator_3))
		{
			return arrayIterator_1;
		}
		ArrayIterator<T> result = arrayIterator_1;
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			ArrayIterator<T> arrayIterator_4 = arrayIterator_0;
			ArrayIterator<T> arrayIterator_5 = arrayIterator_2;
			while (func_0(arrayIterator_4.GetCurrent(), arrayIterator_5.GetCurrent()))
			{
				arrayIterator_4 = arrayIterator_4.GetNext();
				arrayIterator_5 = arrayIterator_5.GetNext();
				if (!arrayIterator_5.IsEqual(arrayIterator_3))
				{
					if (arrayIterator_4.IsEqual(arrayIterator_1))
					{
						return result;
					}
					continue;
				}
				result = arrayIterator_0;
				break;
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return result;
	}

	public static ArrayIterator<T> FindFirstOf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, Func<T, T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			ArrayIterator<T> arrayIterator_4 = arrayIterator_2;
			while (arrayIterator_4.NotEqual(arrayIterator_3))
			{
				if (!func_0(arrayIterator_4.GetCurrent(), arrayIterator_0.GetCurrent()))
				{
					arrayIterator_4 = arrayIterator_4.GetNext();
					continue;
				}
				return arrayIterator_0;
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_1;
	}

	public static ArrayIterator<T> AdjacentFind<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
			arrayIterator_2 = arrayIterator_2.GetNext();
			while (arrayIterator_2.NotEqual(arrayIterator_1))
			{
				if (!func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
				{
					arrayIterator_0 = arrayIterator_0.GetNext();
					arrayIterator_2 = arrayIterator_2.GetNext();
					continue;
				}
				return arrayIterator_0;
			}
		}
		return arrayIterator_1;
	}

	public static int Count<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, T val, Func<T, T, bool> func_0)
	{
		int num = 0;
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent(), val))
			{
				num++;
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return num;
	}

	public static int CountIf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		int num = 0;
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent()))
			{
				num++;
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return num;
	}

	public static void Mismatch<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T, bool> func_0, out ArrayIterator<T> arrayIterator_3, out ArrayIterator<T> arrayIterator_4)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1) && func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
		{
			arrayIterator_0 = arrayIterator_0.GetNext();
			arrayIterator_2 = arrayIterator_2.GetNext();
		}
		arrayIterator_3 = arrayIterator_0;
		arrayIterator_4 = arrayIterator_2;
	}

	public static bool Equal<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				arrayIterator_2 = arrayIterator_2.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool IsPermutation<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T, bool> func_0)
	{
		arrayIterator_0.Mismatch(arrayIterator_1, arrayIterator_2, func_0, out arrayIterator_0, out arrayIterator_2);
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return true;
		}
		ArrayIterator<T> arrayIterator_3 = arrayIterator_2;
		arrayIterator_3 = arrayIterator_3.GetAdvanced(arrayIterator_0.Distance(arrayIterator_1));
		ArrayIterator<T> arrayIterator = arrayIterator_0;
		while (arrayIterator.NotEqual(arrayIterator_1))
		{
			if (arrayIterator_0.Find(arrayIterator, arrayIterator.GetCurrent(), func_0).IsEqual(arrayIterator))
			{
				int num = arrayIterator_2.Count(arrayIterator_3, arrayIterator.GetCurrent(), func_0);
				if (num == 0 || arrayIterator.Count(arrayIterator_1, arrayIterator.GetCurrent(), func_0) != num)
				{
					return false;
				}
			}
			arrayIterator = arrayIterator.GetNext();
		}
		return true;
	}

	public static ArrayIterator<T> Search<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, Func<T, T, bool> func_0)
	{
		if (arrayIterator_2.IsEqual(arrayIterator_3))
		{
			return arrayIterator_0;
		}
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			ArrayIterator<T> arrayIterator_4 = arrayIterator_0;
			ArrayIterator<T> arrayIterator_5 = arrayIterator_2;
			while (func_0(arrayIterator_4.GetCurrent(), arrayIterator_5.GetCurrent()))
			{
				arrayIterator_4 = arrayIterator_4.GetNext();
				arrayIterator_5 = arrayIterator_5.GetNext();
				if (!arrayIterator_5.IsEqual(arrayIterator_3))
				{
					if (arrayIterator_4.IsEqual(arrayIterator_1))
					{
						return arrayIterator_1;
					}
					continue;
				}
				return arrayIterator_0;
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_1;
	}

	public static ArrayIterator<T> SearchN<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, int int_0, T val, Func<T, T, bool> func_0)
	{
		ArrayIterator<T> advanced = arrayIterator_0.GetAdvanced(arrayIterator_0.Distance(arrayIterator_1) - int_0);
		while (arrayIterator_0.NotEqual(advanced))
		{
			ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
			int num = 0;
			while (func_0(val, arrayIterator_2.GetCurrent()))
			{
				arrayIterator_2 = arrayIterator_2.GetNext();
				if (++num == int_0)
				{
					return arrayIterator_0;
				}
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_1;
	}

	public static ArrayIterator<T> Copy<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			arrayIterator_2.SetCurrent(arrayIterator_0.GetCurrent());
			arrayIterator_2 = arrayIterator_2.GetNext();
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_2;
	}

	public static ArrayIterator<T> CopyN<T>(this ArrayIterator<T> arrayIterator_0, int int_0, ArrayIterator<T> arrayIterator_1)
	{
		while (int_0 > 0)
		{
			arrayIterator_1.SetCurrent(arrayIterator_0.GetCurrent());
			arrayIterator_1 = arrayIterator_1.GetNext();
			arrayIterator_0 = arrayIterator_0.GetNext();
			int_0--;
		}
		return arrayIterator_1;
	}

	public static ArrayIterator<T> CopyIf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_2.SetCurrent(arrayIterator_0.GetCurrent());
				arrayIterator_2 = arrayIterator_2.GetNext();
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_2;
	}

	public static ArrayIterator<T> CopyBackward<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2)
	{
		while (arrayIterator_1.NotEqual(arrayIterator_0))
		{
			arrayIterator_2 = arrayIterator_2.GetPrev();
			arrayIterator_1 = arrayIterator_1.GetPrev();
			arrayIterator_2.SetCurrent(arrayIterator_1.GetCurrent());
		}
		return arrayIterator_2;
	}

	public static ArrayIterator<T> SwapRanges<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			arrayIterator_0.Swap(arrayIterator_2);
			arrayIterator_0 = arrayIterator_0.GetNext();
			arrayIterator_2 = arrayIterator_2.GetNext();
		}
		return arrayIterator_2;
	}

	public static void Swap<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1)
	{
		T current = arrayIterator_0.GetCurrent();
		arrayIterator_0.SetCurrent(arrayIterator_1.GetCurrent());
		arrayIterator_1.SetCurrent(current);
	}

	public static ArrayIterator<T> Transform<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			arrayIterator_2.SetCurrent(func_0(arrayIterator_0.GetCurrent()));
			arrayIterator_2 = arrayIterator_2.GetNext();
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_2;
	}

	public static ArrayIterator<T> Transform<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, Func<T, T, T> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			arrayIterator_3.SetCurrent(func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()));
			arrayIterator_2 = arrayIterator_2.GetNext();
			arrayIterator_3 = arrayIterator_3.GetNext();
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_3;
	}

	public static void ReplaceIf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0, T newValue)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0.SetCurrent(newValue);
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
	}

	public static ArrayIterator<T> ReplaceCopyIf<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, bool> func_0, T newValue)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			arrayIterator_2.SetCurrent(func_0(arrayIterator_0.GetCurrent()) ? newValue : arrayIterator_0.GetCurrent());
			arrayIterator_0 = arrayIterator_0.GetNext();
			arrayIterator_2 = arrayIterator_2.GetNext();
		}
		return arrayIterator_2;
	}

	public static ArrayIterator<T> Unique<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return arrayIterator_1;
		}
		ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
		while ((arrayIterator_0 = arrayIterator_0.GetNext()).NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator_2 = arrayIterator_2.GetNext();
				arrayIterator_2.SetCurrent(arrayIterator_0.GetCurrent());
			}
		}
		return arrayIterator_2.GetNext();
	}

	public static ArrayIterator<T> UniqueCopy<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return arrayIterator_1;
		}
		arrayIterator_2.SetCurrent(arrayIterator_0.GetCurrent());
		while ((arrayIterator_0 = arrayIterator_0.GetNext()).NotEqual(arrayIterator_1))
		{
			T current = arrayIterator_0.GetCurrent();
			if (!func_0(arrayIterator_2.GetCurrent(), current))
			{
				arrayIterator_2 = arrayIterator_2.GetNext();
				arrayIterator_2.SetCurrent(current);
			}
		}
		arrayIterator_2 = arrayIterator_2.GetNext();
		return arrayIterator_2;
	}

	public static void Reverse<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1) && arrayIterator_0.NotEqual(arrayIterator_1 = arrayIterator_1.GetPrev()))
		{
			arrayIterator_0.Swap(arrayIterator_1);
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
	}

	public static ArrayIterator<T> ReverseCopy<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			arrayIterator_1 = arrayIterator_1.GetPrev();
			arrayIterator_2.SetCurrent(arrayIterator_1.GetCurrent());
			arrayIterator_2 = arrayIterator_2.GetNext();
		}
		return arrayIterator_2;
	}

	public static void Rotate<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2)
	{
		ArrayIterator<T> arrayIterator = arrayIterator_1;
		while (arrayIterator_0.NotEqual(arrayIterator_2))
		{
			arrayIterator_0.Swap(arrayIterator);
			arrayIterator_0 = arrayIterator_0.GetNext();
			arrayIterator = arrayIterator.GetNext();
			if (arrayIterator.IsEqual(arrayIterator_2))
			{
				arrayIterator = arrayIterator_1;
			}
			else if (arrayIterator_0.IsEqual(arrayIterator_1))
			{
				arrayIterator_1 = arrayIterator;
			}
		}
	}

	public static ArrayIterator<T> RotateCopy<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3)
	{
		arrayIterator_3 = arrayIterator_1.Copy(arrayIterator_2, arrayIterator_3);
		return arrayIterator_0.Copy(arrayIterator_1, arrayIterator_3);
	}

	public static void RandomShuffle<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<int, int> func_0)
	{
		for (int num = arrayIterator_0.Distance(arrayIterator_1) - 1; num > 0; num--)
		{
			arrayIterator_0.GetAdvanced(num).Swap(arrayIterator_0.GetAdvanced(func_0(num + 1)));
		}
	}

	public static bool IsPartitioned<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1) && func_0(arrayIterator_0.GetCurrent()))
		{
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static ArrayIterator<T> Partition<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			while (func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				if (arrayIterator_0.IsEqual(arrayIterator_1))
				{
					return arrayIterator_0;
				}
			}
			do
			{
				arrayIterator_1 = arrayIterator_1.GetPrev();
				if (arrayIterator_0.IsEqual(arrayIterator_1))
				{
					return arrayIterator_0;
				}
			}
			while (!func_0(arrayIterator_1.GetCurrent()));
			arrayIterator_0.Swap(arrayIterator_1);
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		return arrayIterator_0;
	}

	public static void PartitionCopy<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, Func<T, bool> func_0, out ArrayIterator<T> arrayIterator_4, out ArrayIterator<T> arrayIterator_5)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent()))
			{
				arrayIterator_2.SetCurrent(arrayIterator_0.GetCurrent());
				arrayIterator_2 = arrayIterator_2.GetNext();
			}
			else
			{
				arrayIterator_3.SetCurrent(arrayIterator_0.GetCurrent());
				arrayIterator_3 = arrayIterator_3.GetNext();
			}
			arrayIterator_0 = arrayIterator_0.GetNext();
		}
		arrayIterator_4 = arrayIterator_2;
		arrayIterator_5 = arrayIterator_3;
	}

	public static ArrayIterator<T> PartitionPoint<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, bool> func_0)
	{
		int num = arrayIterator_0.Distance(arrayIterator_1);
		while (num > 0)
		{
			ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
			int num2 = num / 2;
			arrayIterator_2.GetAdvanced(num2);
			if (func_0(arrayIterator_2.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_2.GetNext();
				num -= num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return arrayIterator_0;
	}

	public static void Sort<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return;
		}
		ArrayIterator<T> arrayIterator = arrayIterator_0;
		ArrayIterator<T> next = arrayIterator_0.GetNext();
		while (next.NotEqual(arrayIterator_1))
		{
			if (func_0(next.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator = arrayIterator.GetNext();
				arrayIterator.Swap(next);
			}
			next = next.GetNext();
		}
		arrayIterator_0.Swap(arrayIterator);
		arrayIterator_0.Sort(arrayIterator, func_0);
		arrayIterator.GetNext().Sort(arrayIterator_1, func_0);
	}

	public static void StableSort<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		T[] array = arrayIterator_0.Array;
		for (int i = arrayIterator_0.Index + 1; i < arrayIterator_1.Index; i++)
		{
			T val = array[i];
			int num = arrayIterator_0.Index;
			int num2 = i - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				if (func_0(val, array[num3]))
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
				array[num4 + 1] = array[num4];
			}
			array[num] = val;
		}
	}

	public static void PartialSort<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T, bool> func_0)
	{
		arrayIterator_0.Sort(arrayIterator_2, func_0);
	}

	public static bool IsSorted<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return true;
		}
		ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
		while ((arrayIterator_2 = arrayIterator_2.GetNext()).NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static ArrayIterator<T> IsSortedUntil<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return arrayIterator_0;
		}
		ArrayIterator<T> arrayIterator = arrayIterator_0;
		while ((arrayIterator = arrayIterator.GetNext()).NotEqual(arrayIterator_1))
		{
			if (!func_0(arrayIterator.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return arrayIterator;
		}
		return arrayIterator_1;
	}

	public static void NthElement<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T, bool> func_0)
	{
		arrayIterator_0.Sort(arrayIterator_2, func_0);
	}

	public static ArrayIterator<T> LowerBound<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, T val, Func<T, T, bool> func_0)
	{
		int num = arrayIterator_0.Distance(arrayIterator_1);
		while (num > 0)
		{
			ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
			int num2 = num / 2;
			arrayIterator_2 = arrayIterator_2.GetAdvanced(num2);
			if (func_0(arrayIterator_2.GetCurrent(), val))
			{
				arrayIterator_2 = arrayIterator_2.GetNext();
				arrayIterator_0 = arrayIterator_2;
				num -= num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return arrayIterator_0;
	}

	public static ArrayIterator<T> UpperBound<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, T val, Func<T, T, bool> func_0)
	{
		int num = arrayIterator_0.Distance(arrayIterator_1);
		while (num > 0)
		{
			ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
			int num2 = num / 2;
			arrayIterator_2 = arrayIterator_2.GetAdvanced(num2);
			if (func_0(val, arrayIterator_2.GetCurrent()))
			{
				num = num2;
				continue;
			}
			arrayIterator_2 = arrayIterator_2.GetNext();
			arrayIterator_0 = arrayIterator_2;
			num -= num2 + 1;
		}
		return arrayIterator_0;
	}

	public static void EqualRange<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, T val, Func<T, T, bool> func_0, out ArrayIterator<T> arrayIterator_2, out ArrayIterator<T> arrayIterator_3)
	{
		arrayIterator_2 = arrayIterator_0.LowerBound(arrayIterator_1, val, func_0);
		arrayIterator_3 = arrayIterator_2.UpperBound(arrayIterator_1, val, func_0);
	}

	public static bool BinarySearch<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, T val, Func<T, T, bool> func_0)
	{
		arrayIterator_0 = arrayIterator_0.LowerBound(arrayIterator_1, val, func_0);
		if (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			return !func_0(val, arrayIterator_0.GetCurrent());
		}
		return false;
	}

	public static ArrayIterator<T> Merge<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, ArrayIterator<T> arrayIterator_4, Func<T, T, bool> func_0)
	{
		while (true)
		{
			if (!arrayIterator_0.IsEqual(arrayIterator_1))
			{
				if (arrayIterator_2.IsEqual(arrayIterator_3))
				{
					break;
				}
				if (func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
				{
					arrayIterator_4.SetCurrent(arrayIterator_2.GetCurrent());
					arrayIterator_2 = arrayIterator_2.GetNext();
				}
				else
				{
					arrayIterator_4.SetCurrent(arrayIterator_0.GetCurrent());
					arrayIterator_0 = arrayIterator_0.GetNext();
				}
				arrayIterator_4 = arrayIterator_4.GetNext();
				continue;
			}
			return arrayIterator_2.Copy(arrayIterator_3, arrayIterator_4);
		}
		return arrayIterator_0.Copy(arrayIterator_1, arrayIterator_4);
	}

	public static void InplaceMerge<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.Index >= arrayIterator_1.Index || arrayIterator_1.Index >= arrayIterator_2.Index)
		{
			return;
		}
		if (arrayIterator_2.Index - arrayIterator_0.Index == 2)
		{
			if (func_0(arrayIterator_1.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator_0.Swap(arrayIterator_1);
			}
			return;
		}
		ArrayIterator<T> arrayIterator;
		ArrayIterator<T> arrayIterator2;
		if (arrayIterator_1.Index - arrayIterator_0.Index <= arrayIterator_2.Index - arrayIterator_1.Index)
		{
			arrayIterator = arrayIterator_1.GetAdvanced(arrayIterator_1.Distance(arrayIterator_2) / 2);
			arrayIterator2 = arrayIterator_0.UpperBound(arrayIterator_1, arrayIterator.GetCurrent(), func_0);
		}
		else
		{
			arrayIterator2 = arrayIterator_0.GetAdvanced(arrayIterator_0.Distance(arrayIterator_1) / 2);
			arrayIterator = arrayIterator_1.LowerBound(arrayIterator_2, arrayIterator2.GetCurrent(), func_0);
		}
		arrayIterator2.Rotate(arrayIterator_1, arrayIterator);
		arrayIterator_1 = arrayIterator2.GetAdvanced(arrayIterator_1.Distance(arrayIterator));
		arrayIterator_0.InplaceMerge(arrayIterator2, arrayIterator_1, func_0);
		arrayIterator_1.InplaceMerge(arrayIterator, arrayIterator_2, func_0);
	}

	public static bool Includes<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, Func<T, T, bool> func_0)
	{
		while (arrayIterator_2.NotEqual(arrayIterator_3))
		{
			if (!arrayIterator_0.IsEqual(arrayIterator_1) && !func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				if (!func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
				{
					arrayIterator_2 = arrayIterator_2.GetNext();
				}
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static ArrayIterator<T> SetUnion<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, ArrayIterator<T> arrayIterator_4, Func<T, T, bool> func_0)
	{
		while (true)
		{
			if (!arrayIterator_0.IsEqual(arrayIterator_1))
			{
				if (arrayIterator_2.IsEqual(arrayIterator_3))
				{
					break;
				}
				if (func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
				{
					arrayIterator_4.SetCurrent(arrayIterator_0.GetCurrent());
					arrayIterator_0 = arrayIterator_0.GetNext();
				}
				else if (func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
				{
					arrayIterator_4.SetCurrent(arrayIterator_2.GetCurrent());
					arrayIterator_2 = arrayIterator_2.GetNext();
				}
				else
				{
					arrayIterator_4.SetCurrent(arrayIterator_0.GetCurrent());
					arrayIterator_0 = arrayIterator_0.GetNext();
					arrayIterator_2 = arrayIterator_2.GetNext();
				}
				arrayIterator_4 = arrayIterator_4.GetNext();
				continue;
			}
			return arrayIterator_2.Copy(arrayIterator_3, arrayIterator_4);
		}
		return arrayIterator_0.Copy(arrayIterator_1, arrayIterator_4);
	}

	public static ArrayIterator<T> SetIntersection<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, ArrayIterator<T> arrayIterator_4, Func<T, T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1) && arrayIterator_2.NotEqual(arrayIterator_3))
		{
			if (func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				continue;
			}
			if (func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator_2 = arrayIterator_2.GetNext();
				continue;
			}
			arrayIterator_4.SetCurrent(arrayIterator_0.GetCurrent());
			arrayIterator_4 = arrayIterator_4.GetNext();
			arrayIterator_0 = arrayIterator_0.GetNext();
			arrayIterator_2 = arrayIterator_2.GetNext();
		}
		return arrayIterator_4;
	}

	public static ArrayIterator<T> SetDifference<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, ArrayIterator<T> arrayIterator_4, Func<T, T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1) && arrayIterator_2.NotEqual(arrayIterator_3))
		{
			if (func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
			{
				arrayIterator_4.SetCurrent(arrayIterator_0.GetCurrent());
				arrayIterator_4 = arrayIterator_4.GetNext();
				arrayIterator_0 = arrayIterator_0.GetNext();
			}
			else if (func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator_2 = arrayIterator_2.GetNext();
			}
			else
			{
				arrayIterator_0 = arrayIterator_0.GetNext();
				arrayIterator_2 = arrayIterator_2.GetNext();
			}
		}
		return arrayIterator_0.Copy(arrayIterator_1, arrayIterator_4);
	}

	public static ArrayIterator<T> SetSymmetricDifference<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, ArrayIterator<T> arrayIterator_4, Func<T, T, bool> func_0)
	{
		while (true)
		{
			if (!arrayIterator_0.IsEqual(arrayIterator_1))
			{
				if (arrayIterator_2.IsEqual(arrayIterator_3))
				{
					break;
				}
				if (func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
				{
					arrayIterator_4.SetCurrent(arrayIterator_0.GetCurrent());
					arrayIterator_4 = arrayIterator_4.GetNext();
					arrayIterator_0 = arrayIterator_0.GetNext();
				}
				else if (func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
				{
					arrayIterator_4.SetCurrent(arrayIterator_2.GetCurrent());
					arrayIterator_4 = arrayIterator_4.GetNext();
					arrayIterator_2 = arrayIterator_2.GetNext();
				}
				else
				{
					arrayIterator_0 = arrayIterator_0.GetNext();
					arrayIterator_2 = arrayIterator_2.GetNext();
				}
				continue;
			}
			return arrayIterator_2.Copy(arrayIterator_3, arrayIterator_4);
		}
		return arrayIterator_0.Copy(arrayIterator_1, arrayIterator_4);
	}

	public static void PushHeap<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.Distance(arrayIterator_1) >= 2)
		{
			arrayIterator_1 = arrayIterator_1.GetPrev();
			T current = arrayIterator_1.GetCurrent();
			ArrayIterator<T> advanced = arrayIterator_0.GetAdvanced((arrayIterator_0.Distance(arrayIterator_1) - 1) / 2);
			while (arrayIterator_0.Distance(arrayIterator_1) > 0 && func_0(advanced.GetCurrent(), current))
			{
				arrayIterator_1.SetCurrent(advanced.GetCurrent());
				arrayIterator_1 = advanced;
				advanced = arrayIterator_0.GetAdvanced((arrayIterator_0.Distance(arrayIterator_1) - 1) / 2);
			}
			arrayIterator_1.SetCurrent(current);
		}
	}

	public static void PopHeap<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.Distance(arrayIterator_1) >= 2)
		{
			arrayIterator_1 = arrayIterator_1.GetPrev();
			arrayIterator_0.Swap(arrayIterator_1);
			arrayIterator_0.Array.CountStruct(arrayIterator_0.Index, arrayIterator_0.Index, arrayIterator_1.Index, func_0);
		}
	}

	public static void MakeHeap<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		int num = arrayIterator_0.Distance(arrayIterator_1);
		if (num >= 2)
		{
			int num2 = (num - 2) / 2;
			do
			{
				arrayIterator_0.Array.CountStruct(arrayIterator_0.Index, arrayIterator_0.Index + num2, arrayIterator_1.Index, func_0);
			}
			while (num2-- != 0);
		}
	}

	public static void SortHeap<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		while (arrayIterator_0.Distance(arrayIterator_1) > 1)
		{
			arrayIterator_1 = arrayIterator_1.GetPrev();
			arrayIterator_0.Swap(arrayIterator_1);
			arrayIterator_0.Array.CountStruct(arrayIterator_0.Index, arrayIterator_0.Index, arrayIterator_1.Index, func_0);
		}
	}

	public static ArrayIterator<T> MinElement<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return arrayIterator_1;
		}
		ArrayIterator<T> arrayIterator = arrayIterator_0;
		while ((arrayIterator_0 = arrayIterator_0.GetNext()).NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent(), arrayIterator.GetCurrent()))
			{
				arrayIterator = arrayIterator_0;
			}
		}
		return arrayIterator;
	}

	public static ArrayIterator<T> MaxElement<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			return arrayIterator_1;
		}
		ArrayIterator<T> arrayIterator = arrayIterator_0;
		while ((arrayIterator_0 = arrayIterator_0.GetNext()).NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator = arrayIterator_0;
			}
		}
		return arrayIterator;
	}

	public static void MinMaxElement<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0, out ArrayIterator<T> arrayIterator_2, out ArrayIterator<T> arrayIterator_3)
	{
		if (arrayIterator_0.IsEqual(arrayIterator_1))
		{
			arrayIterator_2 = arrayIterator_1;
			arrayIterator_3 = arrayIterator_1;
		}
		arrayIterator_2 = arrayIterator_0;
		arrayIterator_3 = arrayIterator_0;
		while ((arrayIterator_0 = arrayIterator_0.GetNext()).NotEqual(arrayIterator_1))
		{
			if (func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
			{
				arrayIterator_2 = arrayIterator_0;
			}
			if (func_0(arrayIterator_3.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				arrayIterator_3 = arrayIterator_0;
			}
		}
	}

	public static bool LexicographicalCompare<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, ArrayIterator<T> arrayIterator_2, ArrayIterator<T> arrayIterator_3, Func<T, T, bool> func_0)
	{
		while (arrayIterator_0.NotEqual(arrayIterator_1))
		{
			if (!arrayIterator_2.IsEqual(arrayIterator_3) && !func_0(arrayIterator_2.GetCurrent(), arrayIterator_0.GetCurrent()))
			{
				if (!func_0(arrayIterator_0.GetCurrent(), arrayIterator_2.GetCurrent()))
				{
					arrayIterator_0 = arrayIterator_0.GetNext();
					arrayIterator_2 = arrayIterator_2.GetNext();
					continue;
				}
				return true;
			}
			return false;
		}
		return arrayIterator_2.NotEqual(arrayIterator_3);
	}

	public static bool NextPermutation<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		ArrayIterator<T> arrayIterator_2 = arrayIterator_1;
		if (!arrayIterator_0.IsEqual(arrayIterator_1) && !arrayIterator_0.IsEqual(arrayIterator_2 = arrayIterator_2.GetPrev()))
		{
			do
			{
				ArrayIterator<T> arrayIterator_3 = arrayIterator_2;
				if (func_0((arrayIterator_2 = arrayIterator_2.GetPrev()).GetCurrent(), arrayIterator_3.GetCurrent()))
				{
					ArrayIterator<T> arrayIterator = arrayIterator_1;
					while (!func_0(arrayIterator_2.GetCurrent(), (arrayIterator = arrayIterator.GetPrev()).GetCurrent()))
					{
					}
					arrayIterator_2.Swap(arrayIterator);
					arrayIterator_3.Reverse(arrayIterator_1);
					return true;
				}
			}
			while (!arrayIterator_2.IsEqual(arrayIterator_0));
			arrayIterator_0.Reverse(arrayIterator_1);
			return false;
		}
		return false;
	}

	public static bool PrevPermutation<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		ArrayIterator<T> arrayIterator_2 = arrayIterator_1;
		if (!arrayIterator_0.IsEqual(arrayIterator_1) && !arrayIterator_0.IsEqual(arrayIterator_2 = arrayIterator_2.GetPrev()))
		{
			do
			{
				ArrayIterator<T> arrayIterator_3 = arrayIterator_2;
				if (func_0(arrayIterator_3.GetCurrent(), (arrayIterator_2 = arrayIterator_2.GetPrev()).GetCurrent()))
				{
					ArrayIterator<T> arrayIterator = arrayIterator_1;
					while (!func_0((arrayIterator = arrayIterator.GetPrev()).GetCurrent(), arrayIterator_2.GetCurrent()))
					{
					}
					arrayIterator_2.Swap(arrayIterator);
					arrayIterator_3.Reverse(arrayIterator_1);
					return true;
				}
			}
			while (!arrayIterator_2.IsEqual(arrayIterator_0));
			arrayIterator_0.Reverse(arrayIterator_1);
			return false;
		}
		return false;
	}

	private static void CountStruct<T>(this object object_0, int int_0, int int_1, int int_2, Func<T, T, bool> func_0)
	{
		T val = ((T[])object_0)[int_1];
		int num = int_2 - int_0;
		int num2 = int_1 - int_0;
		int num3;
		for (num3 = 2 * num2 + 2; num3 < num; num3 *= 2)
		{
			if (func_0(((T[])object_0)[int_0 + num3], ((T[])object_0)[int_0 + (num3 - 1)]))
			{
				num3--;
			}
			((T[])object_0)[int_0 + num2] = ((T[])object_0)[int_0 + num3];
			num2 = num3++;
		}
		if (num3-- == num)
		{
			((T[])object_0)[int_0 + num2] = ((T[])object_0)[int_0 + num3];
			num2 = num3;
		}
		int num4 = (num2 - 1) / 2;
		int num5 = int_1 - int_0;
		while (num2 != num5 && func_0(((T[])object_0)[int_0 + num4], val))
		{
			((T[])object_0)[int_0 + num2] = ((T[])object_0)[int_0 + num4];
			num2 = num4;
			num4 = (num2 - 1) / 2;
		}
		((T[])object_0)[int_0 + num2] = val;
	}

	public static bool IsHeap<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		return arrayIterator_0.IsHeapUntil(arrayIterator_1, func_0).IsEqual(arrayIterator_1);
	}

	public static ArrayIterator<T> IsHeapUntil<T>(this ArrayIterator<T> arrayIterator_0, ArrayIterator<T> arrayIterator_1, Func<T, T, bool> func_0)
	{
		int num = arrayIterator_0.Distance(arrayIterator_1);
		int num2 = 0;
		int num3 = 1;
		ArrayIterator<T> arrayIterator_2 = arrayIterator_0;
		while (num3 < num)
		{
			ArrayIterator<T> advanced = arrayIterator_0.GetAdvanced(num3);
			if (!func_0(arrayIterator_2.GetCurrent(), advanced.GetCurrent()))
			{
				num3++;
				advanced = advanced.GetNext();
				if (num3 != num)
				{
					if (!func_0(arrayIterator_2.GetCurrent(), advanced.GetCurrent()))
					{
						num2++;
						arrayIterator_2 = arrayIterator_2.GetNext();
						num3 = 2 * num2 + 1;
						continue;
					}
					return advanced;
				}
				return arrayIterator_1;
			}
			return advanced;
		}
		return arrayIterator_1;
	}
}
