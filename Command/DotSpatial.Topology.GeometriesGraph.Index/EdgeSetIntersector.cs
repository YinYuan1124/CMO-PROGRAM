using System.Collections;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public abstract class EdgeSetIntersector
{
	public abstract void ComputeIntersections(IList ilist_0, SegmentIntersector segmentIntersector_0, bool bool_0);

	public abstract void ComputeIntersections(IList ilist_0, IList ilist_1, SegmentIntersector segmentIntersector_0);
}
