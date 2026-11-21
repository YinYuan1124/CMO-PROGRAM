using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SimpleEdgeSetIntersector : EdgeSetIntersector
{
	public override void ComputeIntersections(IList ilist_0, SegmentIntersector segmentIntersector_0, bool bool_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			IEnumerator enumerator2 = ilist_0.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Edge edge2 = (Edge)enumerator2.Current;
				if (bool_0 || edge != edge2)
				{
					FlushParameter(edge, edge2, segmentIntersector_0);
				}
			}
		}
	}

	public override void ComputeIntersections(IList ilist_0, IList ilist_1, SegmentIntersector segmentIntersector_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge_ = (Edge)enumerator.Current;
			IEnumerator enumerator2 = ilist_1.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Edge edge_2 = (Edge)enumerator2.Current;
				FlushParameter(edge_, edge_2, segmentIntersector_0);
			}
		}
	}

	private static void FlushParameter(Edge edge_0, Edge edge_1, SegmentIntersector segmentIntersector_0)
	{
		IList<Coordinate> coordinates = edge_0.Coordinates;
		IList<Coordinate> coordinates2 = edge_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				segmentIntersector_0.AddIntersections(edge_0, i, edge_1, j);
			}
		}
	}
}
