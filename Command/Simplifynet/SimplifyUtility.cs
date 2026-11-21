using System.Collections.Generic;

namespace Simplifynet;

public sealed class SimplifyUtility : ISimplifyUtility
{
	private double CreateCallback(Point point_0, Point point_1)
	{
		double num = point_0.X - point_1.X;
		double num2 = point_0.Y - point_1.Y;
		return num * num + num2 * num2;
	}

	private double CompareCallback(Point point_0, Point point_1, Point point_2)
	{
		double num = point_1.X;
		double num2 = point_1.Y;
		double num3 = point_2.X - num;
		double num4 = point_2.Y - num2;
		if (!num3.Equals(0.0) || !num4.Equals(0.0))
		{
			double num5 = ((point_0.X - num) * num3 + (point_0.Y - num2) * num4) / (num3 * num3 + num4 * num4);
			if (num5 <= 1.0)
			{
				if (num5 > 0.0)
				{
					num += num3 * num5;
					num2 += num4 * num5;
				}
			}
			else
			{
				num = point_2.X;
				num2 = point_2.Y;
			}
		}
		num3 = point_0.X - num;
		num4 = point_0.Y - num2;
		return num3 * num3 + num4 * num4;
	}

	private List<Point> ReadCallback(Point[] point_0, double double_0)
	{
		Point point = point_0[0];
		List<Point> list = new List<Point> { point };
		Point point2 = null;
		for (int i = 1; i < point_0.Length; i++)
		{
			point2 = point_0[i];
			if (CreateCallback(point2, point) > double_0)
			{
				list.Add(point2);
				point = point2;
			}
		}
		if (point2 != null && !point.Equals(point2))
		{
			list.Add(point2);
		}
		return list;
	}

	private List<Point> DisableCallback(Point[] point_0, double double_0)
	{
		int num = point_0.Length;
		int?[] array = new int?[num];
		int? num2 = 0;
		int? num3 = num - 1;
		int? num4 = 0;
		List<int?> list = new List<int?>();
		List<Point> list2 = new List<Point>();
		array[num2.Value] = (array[num3.Value] = 1);
		while (num3.HasValue)
		{
			double num5 = 0.0;
			for (int? num6 = num2 + 1; num6 < num3; num6++)
			{
				double num7 = CompareCallback(point_0[num6.Value], point_0[num2.Value], point_0[num3.Value]);
				if (num7 > num5)
				{
					num4 = num6;
					num5 = num7;
				}
			}
			if (num5 > double_0)
			{
				array[num4.Value] = 1;
				list.AddRange(new int?[4] { num2, num4, num4, num3 });
			}
			if (list.Count <= 0)
			{
				num3 = null;
			}
			else
			{
				num3 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
			}
			if (list.Count <= 0)
			{
				num2 = null;
				continue;
			}
			num2 = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
		for (int i = 0; i < num; i++)
		{
			if (array[i].HasValue)
			{
				list2.Add(point_0[i]);
			}
		}
		return list2;
	}

	public List<Point> Simplify(Point[] point_0, double double_0 = 0.3, bool bool_0 = false)
	{
		if (point_0 != null && point_0.Length != 0)
		{
			double double_ = double_0 * double_0;
			if (bool_0)
			{
				return DisableCallback(point_0, double_);
			}
			List<Point> list = ReadCallback(point_0, double_);
			return DisableCallback(list.ToArray(), double_);
		}
		return new List<Point>();
	}

	public static List<Point> SimplifyArray(Point[] point_0, double double_0 = 0.3, bool bool_0 = false)
	{
		return new SimplifyUtility().Simplify(point_0, double_0, bool_0);
	}
}
