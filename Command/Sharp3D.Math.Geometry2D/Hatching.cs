using System;
using System.Collections.Generic;
using CSMaterial;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class Hatching
{
	public sealed class PointComparer : IComparer<Vector2D>
	{
		private Vector2D _FactoryExporter;

		private Vector2D attributeExporter;

		public PointComparer(Vector2D vector2D_0, Vector2D vector2D_1)
		{
			_FactoryExporter = vector2D_0;
			attributeExporter = vector2D_1;
		}

		public int Compare(Vector2D x, Vector2D y)
		{
			if (Vector2D.DotProduct(x - _FactoryExporter, attributeExporter) < Vector2D.DotProduct(y - _FactoryExporter, attributeExporter))
			{
				return -1;
			}
			return 1;
		}
	}

	private Rectangle m_DecoratorCallback;

	private Rectangle processCallback;

	private bool threadCallback;

	public Hatching(Rectangle rectangle_0)
	{
		m_DecoratorCallback = rectangle_0;
	}

	public Hatching(Rectangle rectangle_0, Rectangle rectangle_1)
	{
		m_DecoratorCallback = rectangle_0;
		processCallback = rectangle_1;
		threadCallback = true;
	}

	public Segment[] GetHatchingSegments(double double_0, double double_1)
	{
		double num = double_0 * CSMath.PI_dividedBy_180;
		Vector2D vector2D = new Vector2D(System.Math.Cos(num), System.Math.Sin(num));
		Vector2D vector2D2 = new Vector2D(0.0 - vector2D.Y, vector2D.X);
		int num2 = Convert.ToInt32(Vector2D.DotProduct(m_DecoratorCallback.Dimensions, vector2D) / double_1);
		Segment[] segments = m_DecoratorCallback.Segments;
		Segment[] segments2 = processCallback.Segments;
		List<Segment> list = new List<Segment>();
		Segment[] array = segments;
		Segment[] array2 = array;
		Segment[] array3 = array2;
		foreach (Segment item in array3)
		{
			list.Add(item);
		}
		array = segments2;
		array2 = array;
		Segment[] array4 = array2;
		foreach (Segment item2 in array4)
		{
			list.Add(item2);
		}
		for (int i = 0; i < num2; i++)
		{
			Vector2D vector2D3 = m_DecoratorCallback.Origin + (double)i * double_1 * vector2D;
			Ray ray_ = new Ray(vector2D3, vector2D2);
			List<Vector2D> list2 = new List<Vector2D>();
			array = segments;
			for (int j = 0; j < array.Length; j++)
			{
				if (IntersectMethods.Intersect(array[j], ray_, out var intersection2D_))
				{
					list2.Add((Vector2D)intersection2D_.Result);
				}
			}
			if (threadCallback && list2.Count >= 2)
			{
				array = segments2;
				for (int k = 0; k < array.Length; k++)
				{
					if (IntersectMethods.Intersect(array[k], ray_, out var intersection2D_2))
					{
						list2.Add((Vector2D)intersection2D_2.Result);
					}
				}
			}
			list2.Sort(new PointComparer(vector2D3, vector2D2));
			if (list2.Count >= 2)
			{
				list.Add(new Segment(list2[0], list2[1]));
			}
			if (list2.Count >= 4)
			{
				list.Add(new Segment(list2[2], list2[3]));
			}
		}
		return list.ToArray();
	}
}
