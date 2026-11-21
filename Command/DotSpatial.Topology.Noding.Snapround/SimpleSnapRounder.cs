using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding.Snapround;

public class SimpleSnapRounder : INoder
{
	private readonly LineIntersector poolCollection;

	private readonly double taskCollection;

	private IList _FilterCollection;

	public SimpleSnapRounder(PrecisionModel precisionModel_0)
	{
		poolCollection = new RobustLineIntersector();
		poolCollection.PrecisionModel = precisionModel_0;
		taskCollection = precisionModel_0.Scale;
	}

	public IList GetNodedSubstrings()
	{
		return SegmentString.GetNodedSubstrings(_FilterCollection);
	}

	public void ComputeNodes(IList ilist_0)
	{
		_FilterCollection = ilist_0;
		DeleteParameter(ilist_0, poolCollection);
	}

	private void DeleteParameter(IList ilist_0, LineIntersector lineIntersector_0)
	{
		IList ilist_ = AddParameter(ilist_0, lineIntersector_0);
		DestroyParameter(ilist_0, ilist_);
		ComputeVertexSnaps(ilist_0);
	}

	private static IList AddParameter(IList ilist_0, LineIntersector lineIntersector_0)
	{
		IntersectionFinderAdder intersectionFinderAdder = new IntersectionFinderAdder(lineIntersector_0);
		new McIndexNoder(intersectionFinderAdder).ComputeNodes(ilist_0);
		return intersectionFinderAdder.InteriorIntersections;
	}

	private void DestroyParameter(IList ilist_0, IList ilist_1)
	{
		foreach (SegmentString item in ilist_0)
		{
			ComputeParameter(item, ilist_1);
		}
	}

	private void ComputeParameter(SegmentString segmentString_0, IList ilist_0)
	{
		foreach (Coordinate item in ilist_0)
		{
			HotPixel hotPixel_ = new HotPixel(item, taskCollection, poolCollection);
			for (int i = 0; i < segmentString_0.Count - 1; i++)
			{
				AddSnappedNode(hotPixel_, segmentString_0, i);
			}
		}
	}

	public void ComputeVertexSnaps(IList ilist_0)
	{
		foreach (SegmentString item in ilist_0)
		{
			foreach (SegmentString item2 in ilist_0)
			{
				PatchParameter(item, item2);
			}
		}
	}

	private void PatchParameter(SegmentString segmentString_0, SegmentString segmentString_1)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		IList<Coordinate> coordinates2 = segmentString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			HotPixel hotPixel_ = new HotPixel(coordinates[i], taskCollection, poolCollection);
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				if ((segmentString_0 != segmentString_1 || i != j) && AddSnappedNode(hotPixel_, segmentString_1, j))
				{
					segmentString_0.AddIntersection(coordinates[i], i);
				}
			}
		}
	}

	public static bool AddSnappedNode(HotPixel hotPixel_0, SegmentString segmentString_0, int int_0)
	{
		Coordinate coordinate = segmentString_0.GetCoordinate(int_0);
		Coordinate coordinate2 = segmentString_0.GetCoordinate(int_0 + 1);
		if (hotPixel_0.Intersects(coordinate, coordinate2))
		{
			segmentString_0.AddIntersection(hotPixel_0.Coordinate, int_0);
			return true;
		}
		return false;
	}
}
