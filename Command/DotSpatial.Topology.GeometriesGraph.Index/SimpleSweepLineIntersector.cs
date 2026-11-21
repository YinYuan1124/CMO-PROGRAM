using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SimpleSweepLineIntersector : EdgeSetIntersector
{
	private readonly ArrayList m_MappingInstance = new ArrayList();

	private int mockInstance;

	public override void ComputeIntersections(IList ilist_0, SegmentIntersector segmentIntersector_0, bool bool_0)
	{
		if (bool_0)
		{
			Add(ilist_0, null);
		}
		else
		{
			Add(ilist_0);
		}
		ManageParameter(segmentIntersector_0);
	}

	public override void ComputeIntersections(IList ilist_0, IList ilist_1, SegmentIntersector segmentIntersector_0)
	{
		Add(ilist_0, ilist_0);
		Add(ilist_1, ilist_1);
		ManageParameter(segmentIntersector_0);
	}

	private void Add(IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			Add(edge, edge);
		}
	}

	private void Add(IEnumerable ienumerable_0, object object_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge_ = (Edge)enumerator.Current;
			Add(edge_, object_0);
		}
	}

	private void Add(Edge edge_0, object object_0)
	{
		IList<Coordinate> coordinates = edge_0.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			SweepLineSegment sweepLineSegment = new SweepLineSegment(edge_0, i);
			SweepLineEvent sweepLineEvent = new SweepLineEvent(object_0, sweepLineSegment.MinX, null, sweepLineSegment);
			m_MappingInstance.Add(sweepLineEvent);
			m_MappingInstance.Add(new SweepLineEvent(object_0, sweepLineSegment.MaxX, sweepLineEvent, sweepLineSegment));
		}
	}

	private void RegisterParameter()
	{
		m_MappingInstance.Sort();
		for (int i = 0; i < m_MappingInstance.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)m_MappingInstance[i];
			if (sweepLineEvent.IsDelete)
			{
				sweepLineEvent.InsertEvent.DeleteEventIndex = i;
			}
		}
	}

	private void ManageParameter(SegmentIntersector segmentIntersector_0)
	{
		mockInstance = 0;
		RegisterParameter();
		for (int i = 0; i < m_MappingInstance.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)m_MappingInstance[i];
			if (sweepLineEvent.IsInsert)
			{
				RevertParameter(i, sweepLineEvent.DeleteEventIndex, sweepLineEvent, segmentIntersector_0);
			}
		}
	}

	private void RevertParameter(int int_0, int int_1, SweepLineEvent sweepLineEvent_0, SegmentIntersector segmentIntersector_0)
	{
		SweepLineSegment sweepLineSegment = (SweepLineSegment)sweepLineEvent_0.Object;
		for (int i = int_0; i < int_1; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)m_MappingInstance[i];
			if (sweepLineEvent.IsInsert)
			{
				SweepLineSegment sweepLineSegment_ = (SweepLineSegment)sweepLineEvent.Object;
				if (sweepLineEvent_0.EdgeSet == null || sweepLineEvent_0.EdgeSet != sweepLineEvent.EdgeSet)
				{
					sweepLineSegment.ComputeIntersections(sweepLineSegment_, segmentIntersector_0);
				}
				mockInstance++;
			}
		}
	}
}
