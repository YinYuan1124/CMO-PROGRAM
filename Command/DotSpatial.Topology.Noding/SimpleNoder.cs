using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Noding;

public class SimpleNoder : SinglePassNoder
{
	private IList dicCollection;

	public SimpleNoder()
	{
	}

	public SimpleNoder(GInterface5 ginterface5_0)
		: base(ginterface5_0)
	{
	}

	public override IList GetNodedSubstrings()
	{
		return SegmentString.GetNodedSubstrings(dicCollection);
	}

	public override void ComputeNodes(IList ilist_0)
	{
		dicCollection = ilist_0;
		foreach (SegmentString item in ilist_0)
		{
			foreach (SegmentString item2 in ilist_0)
			{
				OrderObject(item, item2);
			}
		}
	}

	private void OrderObject(SegmentString segmentString_0, SegmentString segmentString_1)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		IList<Coordinate> coordinates2 = segmentString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				base.SegmentIntersector.ProcessIntersections(segmentString_0, i, segmentString_1, j);
			}
		}
	}
}
