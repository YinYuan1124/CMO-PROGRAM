using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding.Snapround;

public class McIndexSnapRounder : INoder
{
	private readonly LineIntersector writerCollection;

	private readonly double specificationCollection;

	private IList m_WatcherCollection;

	private McIndexNoder reponseCollection;

	private McIndexPointSnapper descriptorCollection;

	public McIndexSnapRounder(PrecisionModel precisionModel_0)
	{
		writerCollection = new RobustLineIntersector();
		writerCollection.PrecisionModel = precisionModel_0;
		specificationCollection = precisionModel_0.Scale;
	}

	public IList GetNodedSubstrings()
	{
		return SegmentString.GetNodedSubstrings(m_WatcherCollection);
	}

	public void ComputeNodes(IList ilist_0)
	{
		m_WatcherCollection = ilist_0;
		reponseCollection = new McIndexNoder();
		descriptorCollection = new McIndexPointSnapper(reponseCollection.Index);
		CustomizeParameter(ilist_0, writerCollection);
	}

	private void CustomizeParameter(IList ilist_0, LineIntersector lineIntersector_0)
	{
		IList ilist_ = CloneParameter(ilist_0, lineIntersector_0);
		ConnectParameter(ilist_);
		ComputeVertexSnaps(ilist_0);
	}

	private IList CloneParameter(IList ilist_0, LineIntersector lineIntersector_0)
	{
		IntersectionFinderAdder intersectionFinderAdder = new IntersectionFinderAdder(lineIntersector_0);
		reponseCollection.SegmentIntersector = intersectionFinderAdder;
		reponseCollection.ComputeNodes(ilist_0);
		return intersectionFinderAdder.InteriorIntersections;
	}

	private void ConnectParameter(IList ilist_0)
	{
		foreach (Coordinate item in ilist_0)
		{
			HotPixel hotPixel_ = new HotPixel(item, specificationCollection, writerCollection);
			descriptorCollection.Snap(hotPixel_);
		}
	}

	public void ComputeVertexSnaps(IList ilist_0)
	{
		foreach (SegmentString item in ilist_0)
		{
			MoveParameter(item);
		}
	}

	private void MoveParameter(SegmentString segmentString_0)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			HotPixel hotPixel_ = new HotPixel(coordinates[i], specificationCollection, writerCollection);
			if (descriptorCollection.Snap(hotPixel_, segmentString_0, i))
			{
				segmentString_0.AddIntersection(coordinates[i], i);
			}
		}
	}
}
