using System.Collections;

namespace DotSpatial.Topology.Index.Bintree;

public class Bintree
{
	private readonly Root roleCollection;

	private double _FactoryCollection = 1.0;

	public virtual int Depth
	{
		get
		{
			if (roleCollection == null)
			{
				return 0;
			}
			return roleCollection.Depth;
		}
	}

	public virtual int Count
	{
		get
		{
			if (roleCollection == null)
			{
				return 0;
			}
			return roleCollection.Count;
		}
	}

	public virtual int NodeSize
	{
		get
		{
			if (roleCollection == null)
			{
				return 0;
			}
			return roleCollection.NodeCount;
		}
	}

	public Bintree()
	{
		roleCollection = new Root();
	}

	public static Interval EnsureExtent(Interval interval_0, double double_0)
	{
		double num = interval_0.Min;
		double num2 = interval_0.Max;
		if (num == num2)
		{
			if (num == num2)
			{
				num -= double_0 / 2.0;
				num2 = num + double_0 / 2.0;
			}
			return new Interval(num, num2);
		}
		return interval_0;
	}

	public virtual void Insert(Interval interval_0, object object_0)
	{
		CompareParameter(interval_0);
		Interval interval_ = EnsureExtent(interval_0, _FactoryCollection);
		roleCollection.Insert(interval_, object_0);
	}

	public virtual IEnumerator GetEnumerator()
	{
		IList list = new ArrayList();
		roleCollection.AddAllItems(list);
		return list.GetEnumerator();
	}

	public virtual IList Query(double double_0)
	{
		return Query(new Interval(double_0, double_0));
	}

	public virtual IList Query(Interval interval_0)
	{
		IList list = new ArrayList();
		Query(interval_0, list);
		return list;
	}

	public virtual void Query(Interval interval_0, IList ilist_0)
	{
		roleCollection.AddAllItemsFromOverlapping(interval_0, ilist_0);
	}

	private void CompareParameter(Interval interval_0)
	{
		double width = interval_0.Width;
		if (width < _FactoryCollection && width > 0.0)
		{
			_FactoryCollection = width;
		}
	}
}
