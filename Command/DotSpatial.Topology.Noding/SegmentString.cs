using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class SegmentString
{
	private readonly SegmentNodeList _ValCollection;

	private readonly IList<Coordinate> m_WrapperCollection;

	private object observerCollection;

	public object Data
	{
		get
		{
			return observerCollection;
		}
		set
		{
			observerCollection = value;
		}
	}

	public SegmentNodeList NodeList => _ValCollection;

	public int Count => m_WrapperCollection.Count;

	public IList<Coordinate> Coordinates => m_WrapperCollection;

	public bool IsClosed => m_WrapperCollection[0].Equals(m_WrapperCollection[m_WrapperCollection.Count - 1]);

	public static IList GetNodedSubstrings(IList ilist_0)
	{
		IList list = new ArrayList();
		GetNodedSubstrings(ilist_0, list);
		return list;
	}

	public static void GetNodedSubstrings(IList ilist_0, IList ilist_1)
	{
		foreach (SegmentString item in ilist_0)
		{
			item.NodeList.AddSplitEdges(ilist_1);
		}
	}

	public SegmentString(IList<Coordinate> ilist_0, object object_0)
	{
		_ValCollection = new SegmentNodeList(this);
		m_WrapperCollection = ilist_0;
		observerCollection = object_0;
	}

	public Coordinate GetCoordinate(int int_0)
	{
		return m_WrapperCollection[int_0];
	}

	public OctantDirection GetSegmentOctant(int int_0)
	{
		if (int_0 == m_WrapperCollection.Count - 1)
		{
			return OctantDirection.Null;
		}
		return Octant.GetOctant(GetCoordinate(int_0), GetCoordinate(int_0 + 1));
	}

	public void AddIntersections(LineIntersector lineIntersector_0, int int_0)
	{
		for (int i = 0; i < lineIntersector_0.IntersectionNum; i++)
		{
			AddIntersection(lineIntersector_0, int_0, i);
		}
	}

	public void AddIntersection(LineIntersector lineIntersector_0, int int_0, int int_1)
	{
		Coordinate coordinate_ = new Coordinate(lineIntersector_0.GetIntersection(int_1));
		AddIntersection(coordinate_, int_0);
	}

	public void AddIntersection(Coordinate coordinate_0, int int_0)
	{
		int num = int_0;
		int num2 = num + 1;
		if (num2 < m_WrapperCollection.Count)
		{
			Coordinate coordinate_ = m_WrapperCollection[num2];
			if (coordinate_0.Equals2D(coordinate_))
			{
				num = num2;
			}
		}
		_ValCollection.Add(coordinate_0, num);
	}
}
