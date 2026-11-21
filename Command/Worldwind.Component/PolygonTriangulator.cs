using System.Collections.Generic;
using System.Drawing;

namespace Worldwind.Component;

public class PolygonTriangulator
{
	public static List<List<PointF>> Triangulate(List<PointF> list_0, bool bool_0 = true)
	{
		List<List<PointF>> list = new List<List<PointF>>();
		List<PointF> list2 = new List<PointF>(list_0);
		List<PointF> list3 = new List<PointF>();
		int num = 0;
		int count = list_0.Count;
		if (Square(list2) < 0f)
		{
			list2.Reverse();
		}
		int num2 = 10000;
		while (count >= 3)
		{
			list3 = new List<PointF>();
			while (IncludeMerchant(list2[num], list2[(num + 1) % count], list2[(num + 2) % count]) < 0f || SetupMerchant(list2, num, (num + 1) % count, (num + 2) % count))
			{
				num++;
				num %= count;
				num2--;
				if (num2 <= 0)
				{
					return new List<List<PointF>>();
				}
			}
			int num3 = (num + 1) % count;
			list3.Add(list2[num]);
			list3.Add(list2[num3]);
			list3.Add(list2[(num + 2) % count]);
			if (!bool_0)
			{
				while (IncludeMerchant(list2[num3], list2[(num3 + 1) % count], list2[(num3 + 2) % count]) > 0f && (num3 + 2) % count != num && !SetupMerchant(list2, num, (num3 + 1) % count, (num3 + 2) % count) && IncludeMerchant(list2[num], list2[(num + 1) % count], list2[(num3 + 2) % count]) >= 0f)
				{
					list3.Add(list2[(num3 + 2) % count]);
					num3++;
					num3 %= count;
				}
			}
			int num4 = num3 - num;
			if (num4 <= 0)
			{
				list2.RemoveRange(num + 1, count - num - 1);
				list2.RemoveRange(0, num3 + 1);
			}
			else
			{
				list2.RemoveRange(num + 1, num4);
			}
			count = list2.Count;
			num++;
			num %= count;
			list.Add(list3);
		}
		return list;
	}

	public static int SelfIntersection(List<PointF> list_0)
	{
		if (list_0.Count < 3)
		{
			return 0;
		}
		int num = list_0.Count - 1;
		PointF pointF_ = default(PointF);
		for (int i = 0; i < num; i++)
		{
			for (int k = i + 2; k < num; k++)
			{
				if (SearchMerchant(list_0[i], list_0[i + 1], list_0[k], list_0[k + 1], ref pointF_) == 1)
				{
					return 1;
				}
			}
		}
		for (int j = 1; j < num - 1; j++)
		{
			if (SearchMerchant(list_0[j], list_0[j + 1], list_0[num], list_0[0], ref pointF_) == 1)
			{
				return 1;
			}
		}
		return -1;
	}

	public static float Square(List<PointF> list_0)
	{
		float num = 0f;
		if (list_0.Count >= 3)
		{
			for (int i = 0; i < list_0.Count - 1; i++)
			{
				num += ExcludeMerchant(list_0[i], list_0[i + 1]);
			}
			num += ExcludeMerchant(list_0[list_0.Count - 1], list_0[0]);
		}
		return num;
	}

	public int IsConvex(List<PointF> list_0)
	{
		if (list_0.Count < 3)
		{
			return 0;
		}
		if (Square(list_0) <= 0f)
		{
			for (int i = 0; i < list_0.Count - 2; i++)
			{
				if (!(IncludeMerchant(list_0[i], list_0[i + 1], list_0[i + 2]) <= 0f))
				{
					return -1;
				}
			}
			if (!(IncludeMerchant(list_0[list_0.Count - 2], list_0[list_0.Count - 1], list_0[0]) <= 0f))
			{
				return -1;
			}
			if (IncludeMerchant(list_0[list_0.Count - 1], list_0[0], list_0[1]) > 0f)
			{
				return -1;
			}
		}
		else
		{
			for (int j = 0; j < list_0.Count - 2; j++)
			{
				if (!(IncludeMerchant(list_0[j], list_0[j + 1], list_0[j + 2]) >= 0f))
				{
					return -1;
				}
			}
			if (IncludeMerchant(list_0[list_0.Count - 2], list_0[list_0.Count - 1], list_0[0]) < 0f)
			{
				return -1;
			}
			if (IncludeMerchant(list_0[list_0.Count - 1], list_0[0], list_0[1]) < 0f)
			{
				return -1;
			}
		}
		return 1;
	}

	private static bool SetupMerchant(List<PointF> list_0, int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			if (i == int_0 || i == int_1 || i == int_2)
			{
				continue;
			}
			float num = IncludeMerchant(list_0[int_0], list_0[int_1], list_0[i]);
			float num2 = IncludeMerchant(list_0[int_1], list_0[int_2], list_0[i]);
			if ((num >= 0f || num2 <= 0f) && (num <= 0f || num2 >= 0f))
			{
				float num3 = IncludeMerchant(list_0[int_2], list_0[int_0], list_0[i]);
				if ((num3 >= 0f && num2 >= 0f) || (num3 <= 0f && num2 <= 0f))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static float ExcludeMerchant(PointF pointF_0, PointF pointF_1)
	{
		return pointF_1.X * pointF_0.Y - pointF_0.X * pointF_1.Y;
	}

	private static float IncludeMerchant(PointF pointF_0, PointF pointF_1, PointF pointF_2)
	{
		return (pointF_2.X - pointF_0.X) * (pointF_1.Y - pointF_0.Y) - (pointF_1.X - pointF_0.X) * (pointF_2.Y - pointF_0.Y);
	}

	private static int SearchMerchant(PointF pointF_0, PointF pointF_1, PointF pointF_2, PointF pointF_3, ref PointF pointF_4)
	{
		float num = pointF_1.Y - pointF_0.Y;
		float num2 = pointF_0.X - pointF_1.X;
		float num3 = (0f - num) * pointF_0.X - num2 * pointF_0.Y;
		float num4 = pointF_3.Y - pointF_2.Y;
		float num5 = pointF_2.X - pointF_3.X;
		float num6 = (0f - num4) * pointF_2.X - num5 * pointF_2.Y;
		float num7 = num4 * num2 - num * num5;
		if (num7 == 0f)
		{
			return -1;
		}
		pointF_4.Y = (num * num6 - num4 * num3) / num7;
		pointF_4.X = (num5 * num3 - num2 * num6) / num7;
		if (pointF_0.X <= pointF_1.X)
		{
			if (pointF_4.X < pointF_0.X || pointF_4.X > pointF_1.X)
			{
				return 0;
			}
		}
		else if (pointF_4.X < pointF_1.X || !(pointF_4.X <= pointF_0.X))
		{
			return 0;
		}
		if (pointF_0.Y <= pointF_1.Y)
		{
			if (pointF_4.Y < pointF_0.Y || pointF_4.Y > pointF_1.Y)
			{
				return 0;
			}
		}
		else if (pointF_4.Y < pointF_1.Y || !(pointF_4.Y <= pointF_0.Y))
		{
			return 0;
		}
		if (pointF_2.X <= pointF_3.X)
		{
			if (pointF_4.X < pointF_2.X || pointF_4.X > pointF_3.X)
			{
				return 0;
			}
		}
		else if (pointF_4.X < pointF_3.X || !(pointF_4.X <= pointF_2.X))
		{
			return 0;
		}
		if (pointF_2.Y <= pointF_3.Y)
		{
			if (pointF_4.Y < pointF_2.Y || pointF_4.Y > pointF_3.Y)
			{
				return 0;
			}
		}
		else if (pointF_4.Y < pointF_3.Y || !(pointF_4.Y <= pointF_2.Y))
		{
			return 0;
		}
		return 1;
	}
}
