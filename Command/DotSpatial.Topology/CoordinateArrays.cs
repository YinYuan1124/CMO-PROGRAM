using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public static class CoordinateArrays
{
	public class BidirectionalComparator : IComparer<Coordinate[]>
	{
		public virtual int Compare(Coordinate[] x, Coordinate[] y)
		{
			if (x.Length < y.Length)
			{
				return -1;
			}
			if (x.Length <= y.Length)
			{
				if (x.Length == 0)
				{
					return 0;
				}
				int result = CoordinateArrays.Compare(x, y);
				if (PatchRule(x, y))
				{
					return 0;
				}
				return result;
			}
			return 1;
		}
	}

	public class ForwardComparator : IComparer<Coordinate[]>
	{
		public virtual int Compare(Coordinate[] x, Coordinate[] y)
		{
			return CoordinateArrays.Compare(x, y);
		}
	}

	public static Coordinate PointNotInList(Coordinate[] coordinate_0, Coordinate[] coordinate_1)
	{
		foreach (Coordinate coordinate in coordinate_0)
		{
			if (IndexOf(coordinate, coordinate_1) < 0)
			{
				return coordinate;
			}
		}
		return null;
	}

	public static int Compare(Coordinate[] coordinate_0, Coordinate[] coordinate_1)
	{
		int i;
		for (i = 0; i < coordinate_0.Length && i < coordinate_1.Length; i++)
		{
			int num = coordinate_0[i].CompareTo(coordinate_1[i]);
			if (num != 0)
			{
				return num;
			}
		}
		if (i < coordinate_1.Length)
		{
			return -1;
		}
		if (i < coordinate_0.Length)
		{
			return 1;
		}
		return 0;
	}

	public static int IncreasingDirection(IList<Coordinate> ilist_0)
	{
		for (int i = 0; i < ilist_0.Count / 2; i++)
		{
			int index = ilist_0.Count - 1 - i;
			int num = ilist_0[i].CompareTo(ilist_0[index]);
			if (num != 0)
			{
				return num;
			}
		}
		return 1;
	}

	private static bool PatchRule(object object_0, object[] object_1)
	{
		for (int i = 0; i < ((Array)object_0).Length; i++)
		{
			object obj = ((object[])object_0)[i];
			Coordinate other = (Coordinate)object_1[((Array)object_0).Length - i - 1];
			if (((Coordinate)obj).CompareTo(other) != 0)
			{
				return false;
			}
		}
		return true;
	}

	public static Coordinate[] CopyDeep(Coordinate[] coordinate_0)
	{
		Coordinate[] array = new Coordinate[coordinate_0.Length];
		for (int i = 0; i < coordinate_0.Length; i++)
		{
			array[i] = new Coordinate(coordinate_0[i]);
		}
		return array;
	}

	[Obsolete("Use generic method instead")]
	public static Coordinate[] ToCoordinateArray(IList ilist_0)
	{
		List<Coordinate> list = new List<Coordinate>(ilist_0.Count);
		foreach (Coordinate item in ilist_0)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	public static Coordinate[] ToCoordinateArray(IList<Coordinate> ilist_0)
	{
		List<Coordinate> list = new List<Coordinate>(ilist_0.Count);
		foreach (Coordinate item in ilist_0)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	public static bool HasRepeatedPoints(IEnumerable<Coordinate> ienumerable_0)
	{
		Coordinate obj = null;
		foreach (Coordinate item in ienumerable_0)
		{
			if (!item.Equals(obj))
			{
				obj = item;
				continue;
			}
			return true;
		}
		return false;
	}

	public static Coordinate[] AtLeastNCoordinatesOrNothing(int int_0, Coordinate[] coordinate_0)
	{
		if (coordinate_0.Length < int_0)
		{
			return new Coordinate[0];
		}
		return coordinate_0;
	}

	public static IList<Coordinate> RemoveRepeatedPoints(IList<Coordinate> ilist_0)
	{
		if (HasRepeatedPoints(ilist_0))
		{
			return new CoordinateList(ilist_0, bool_0: false);
		}
		return ilist_0;
	}

	public static void Reverse(Coordinate[] coordinate_0)
	{
		Array.Reverse(coordinate_0);
	}

	public static bool Equals(Coordinate[] coordinate_0, Coordinate[] coordinate_1)
	{
		if (coordinate_0 == coordinate_1)
		{
			return true;
		}
		if (coordinate_0 != null && coordinate_1 != null)
		{
			if (coordinate_0.Length == coordinate_1.Length)
			{
				int num = 0;
				while (true)
				{
					if (num < coordinate_0.Length)
					{
						if (!coordinate_0[num].Equals(coordinate_1[num]))
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool Equals(Coordinate[] coordinate_0, Coordinate[] coordinate_1, IComparer<Coordinate[]> icomparer_0)
	{
		if (coordinate_0 == coordinate_1)
		{
			return true;
		}
		if (coordinate_0 != null && coordinate_1 != null)
		{
			if (coordinate_0.Length == coordinate_1.Length)
			{
				if (icomparer_0.Compare(coordinate_0, coordinate_1) == 0)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static Coordinate MinCoordinate(Coordinate[] coordinate_0)
	{
		Coordinate coordinate = null;
		for (int i = 0; i < coordinate_0.Length; i++)
		{
			if (coordinate == null || coordinate.CompareTo(coordinate_0[i]) > 0)
			{
				coordinate = coordinate_0[i];
			}
		}
		return coordinate;
	}

	public static void Scroll(Coordinate[] coordinate_0, Coordinate coordinate_1)
	{
		int num = IndexOf(coordinate_1, coordinate_0);
		if (num >= 0)
		{
			Coordinate[] array = new Coordinate[coordinate_0.Length];
			Array.Copy(coordinate_0, num, array, 0, coordinate_0.Length - num);
			Array.Copy(coordinate_0, 0, array, coordinate_0.Length - num, num);
			Array.Copy(array, 0, coordinate_0, 0, coordinate_0.Length);
		}
	}

	public static int IndexOf(Coordinate coordinate_0, Coordinate[] coordinate_1)
	{
		for (int i = 0; i < coordinate_1.Length; i++)
		{
			if (coordinate_0.Equals(coordinate_1[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public static Coordinate[] Extract(Coordinate[] coordinate_0, int int_0, int int_1)
	{
		int num = int_1 - int_0 + 1;
		Coordinate[] array = new Coordinate[num];
		Array.Copy(coordinate_0, int_0, array, 0, num);
		return array;
	}
}
