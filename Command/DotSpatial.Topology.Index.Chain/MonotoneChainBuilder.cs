using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Index.Chain;

public class MonotoneChainBuilder
{
	private MonotoneChainBuilder()
	{
	}

	public static int[] ToIntArray(IList ilist_0)
	{
		int[] array = new int[ilist_0.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (int)ilist_0[i];
		}
		return array;
	}

	public static IList GetChains(IList<Coordinate> ilist_0)
	{
		return GetChains(ilist_0, null);
	}

	public static IList GetChains(IList<Coordinate> ilist_0, object object_0)
	{
		IList list = new ArrayList();
		int[] chainStartIndices = GetChainStartIndices(ilist_0);
		for (int i = 0; i < chainStartIndices.Length - 1; i++)
		{
			MonotoneChain value = new MonotoneChain(ilist_0, chainStartIndices[i], chainStartIndices[i + 1], object_0);
			list.Add(value);
		}
		return list;
	}

	public static int[] GetChainStartIndices(IList<Coordinate> ilist_0)
	{
		int num = 0;
		IList list = new ArrayList();
		list.Add(0);
		do
		{
			int num2 = CreateParameter(ilist_0, num);
			list.Add(num2);
			num = num2;
		}
		while (num < ilist_0.Count - 1);
		return ToIntArray(list);
	}

	private static int CreateParameter(IList<Coordinate> ilist_0, int int_0)
	{
		int num = QuadrantOp.Quadrant(ilist_0[int_0], ilist_0[int_0 + 1]);
		int i;
		for (i = int_0 + 1; i < ilist_0.Count && QuadrantOp.Quadrant(ilist_0[i - 1], ilist_0[i]) == num; i++)
		{
		}
		return i - 1;
	}
}
