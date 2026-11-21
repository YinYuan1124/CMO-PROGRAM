using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Noding;

public class OrientedCoordinateArray : IComparable
{
	private readonly bool _RuleCollection;

	private readonly IList<Coordinate> _CollectionCollection;

	public OrientedCoordinateArray(IList<Coordinate> ilist_0)
	{
		_CollectionCollection = ilist_0;
		_RuleCollection = Orientation(ilist_0);
	}

	public int CompareTo(object target)
	{
		OrientedCoordinateArray orientedCoordinateArray = (OrientedCoordinateArray)target;
		return PostObject(_CollectionCollection, _RuleCollection, orientedCoordinateArray._CollectionCollection, orientedCoordinateArray._RuleCollection);
	}

	private static bool Orientation(IList<Coordinate> ilist_0)
	{
		return CoordinateArrays.IncreasingDirection(ilist_0) == 1;
	}

	private static int PostObject(IList<Coordinate> ilist_0, bool bool_0, IList<Coordinate> ilist_1, bool bool_1)
	{
		int num = (bool_0 ? 1 : (-1));
		int num2 = (bool_1 ? 1 : (-1));
		int num3 = (bool_0 ? ilist_0.Count : (-1));
		int num4 = (bool_1 ? ilist_1.Count : (-1));
		int num5 = ((!bool_0) ? (ilist_0.Count - 1) : 0);
		int num6 = ((!bool_1) ? (ilist_1.Count - 1) : 0);
		int num7;
		while (true)
		{
			num7 = ilist_0[num5].CompareTo(ilist_1[num6]);
			if (num7 != 0)
			{
				break;
			}
			num5 += num;
			num6 += num2;
			bool flag = num5 == num3;
			bool flag2 = num6 == num4;
			if (!flag || flag2)
			{
				if (!(!flag && flag2))
				{
					if (flag)
					{
						return 0;
					}
					continue;
				}
				return 1;
			}
			return -1;
		}
		return num7;
	}
}
