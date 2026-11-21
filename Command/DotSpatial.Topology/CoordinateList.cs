using System;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Serialization;

namespace DotSpatial.Topology;

public class CoordinateList : BaseList<Coordinate>, ICloneable
{
	public CoordinateList()
	{
		base.InnerList = new List<Coordinate>();
	}

	public CoordinateList(IEnumerable<Coordinate> ienumerable_0)
	{
		base.InnerList = ienumerable_0.ToList();
	}

	public CoordinateList(IEnumerable<Coordinate> ienumerable_0, bool bool_0)
	{
		if (bool_0)
		{
			base.InnerList = ienumerable_0.ToList();
			return;
		}
		List<Coordinate> list = new List<Coordinate>();
		Coordinate coordinate = null;
		foreach (Coordinate item in ienumerable_0)
		{
			if (null == coordinate || !coordinate.Equals2D(item))
			{
				list.Add(item);
				coordinate = item;
			}
		}
		base.InnerList = list;
	}

	public object Clone()
	{
		CoordinateList coordinateList = new CoordinateList();
		using IEnumerator<Coordinate> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Coordinate current = enumerator.Current;
			coordinateList.Add(current.Copy());
		}
		return coordinateList;
	}

	public virtual void Add(IEnumerable<Coordinate> ienumerable_0, bool bool_0, bool bool_1)
	{
		if (!bool_1)
		{
			ienumerable_0 = ienumerable_0.Reverse();
		}
		DoAddRange(ienumerable_0, bool_0);
	}

	public virtual void Add(IEnumerable<Coordinate> ienumerable_0, bool bool_0)
	{
		Add(ienumerable_0, bool_0, bool_1: true);
	}

	public virtual void Add(Coordinate coordinate_0, bool bool_0)
	{
		DoAdd(coordinate_0, bool_0);
	}

	protected void DoAdd(Coordinate coordinate_0, bool bool_0)
	{
		if (bool_0 || base.Count < 1 || !base[base.Count - 1].Equals2D(coordinate_0))
		{
			Add(coordinate_0);
		}
	}

	protected void DoAddRange(IEnumerable<Coordinate> ienumerable_0, bool bool_0)
	{
		foreach (Coordinate item in ienumerable_0)
		{
			DoAdd(item, bool_0);
		}
	}

	public virtual void CloseRing()
	{
		if (base.Count > 0)
		{
			Add(base[0], bool_0: false);
		}
	}

	public virtual Coordinate[] ToCoordinateArray()
	{
		return base.InnerList.ToArray();
	}
}
