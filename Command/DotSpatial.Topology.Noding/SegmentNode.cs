using System;
using System.IO;

namespace DotSpatial.Topology.Noding;

public class SegmentNode : IComparable
{
	public readonly Coordinate Coordinate;

	public readonly int SegmentIndex;

	private readonly bool _ListenerCollection;

	private readonly OctantDirection configCollection = OctantDirection.Null;

	public bool IsInterior => _ListenerCollection;

	public SegmentNode(SegmentString segmentString_0, Coordinate coordinate_0, int int_0, OctantDirection octantDirection_0)
	{
		Coordinate = new Coordinate(coordinate_0);
		SegmentIndex = int_0;
		configCollection = octantDirection_0;
		_ListenerCollection = !coordinate_0.Equals2D(segmentString_0.GetCoordinate(int_0));
	}

	public int CompareTo(object target)
	{
		SegmentNode segmentNode = (SegmentNode)target;
		if (SegmentIndex < segmentNode.SegmentIndex)
		{
			return -1;
		}
		if (SegmentIndex <= segmentNode.SegmentIndex)
		{
			if (Coordinate.Equals2D(segmentNode.Coordinate))
			{
				return 0;
			}
			return SegmentPointComparator.Compare(configCollection, Coordinate, segmentNode.Coordinate);
		}
		return 1;
	}

	public bool IsEndPoint(int int_0)
	{
		if (SegmentIndex == 0 && !_ListenerCollection)
		{
			return true;
		}
		if (SegmentIndex == int_0)
		{
			return true;
		}
		return false;
	}

	public void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.Write(Coordinate);
		streamWriter_0.Write(" seg # = " + SegmentIndex);
	}
}
