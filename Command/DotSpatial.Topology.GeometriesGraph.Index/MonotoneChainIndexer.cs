using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class MonotoneChainIndexer
{
	public static int[] ToIntArray(IList ilist_0)
	{
		int[] array = new int[ilist_0.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToInt32(ilist_0[i]);
		}
		return array;
	}

	public virtual int[] GetChainStartIndices(IList<Coordinate> ilist_0)
	{
		int num = 0;
		IList list = new ArrayList();
		list.Add(0);
		do
		{
			int num2 = MapParameter(ilist_0, num);
			list.Add(num2);
			num = num2;
		}
		while (num < ilist_0.Count - 1);
		return ToIntArray(list);
	}

	private static int MapParameter(IList<Coordinate> ilist_0, int int_0)
	{
		int num = QuadrantOp.Quadrant(ilist_0[int_0], ilist_0[int_0 + 1]);
		int i;
		for (i = int_0 + 1; i < ilist_0.Count && QuadrantOp.Quadrant(ilist_0[i - 1], ilist_0[i]) == num; i++)
		{
		}
		return i - 1;
	}
}
