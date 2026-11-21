using System.Collections;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SimpleMcSweepLineIntersector : EdgeSetIntersector
{
	private readonly ArrayList m_CreatorInstance = new ArrayList();

	private int templateInstance;

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
		CollectParameter(segmentIntersector_0);
	}

	public override void ComputeIntersections(IList ilist_0, IList ilist_1, SegmentIntersector segmentIntersector_0)
	{
		Add(ilist_0, ilist_0);
		Add(ilist_1, ilist_1);
		CollectParameter(segmentIntersector_0);
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
		MonotoneChainEdge monotoneChainEdge = edge_0.MonotoneChainEdge;
		int[] startIndexes = monotoneChainEdge.StartIndexes;
		for (int i = 0; i < startIndexes.Length - 1; i++)
		{
			MonotoneChain object_ = new MonotoneChain(monotoneChainEdge, i);
			SweepLineEvent sweepLineEvent = new SweepLineEvent(object_0, monotoneChainEdge.GetMinX(i), null, object_);
			m_CreatorInstance.Add(sweepLineEvent);
			m_CreatorInstance.Add(new SweepLineEvent(object_0, monotoneChainEdge.GetMaxX(i), sweepLineEvent, object_));
		}
	}

	private void ForgotParameter()
	{
		m_CreatorInstance.Sort();
		for (int i = 0; i < m_CreatorInstance.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)m_CreatorInstance[i];
			if (sweepLineEvent.IsDelete)
			{
				sweepLineEvent.InsertEvent.DeleteEventIndex = i;
			}
		}
	}

	private void CollectParameter(SegmentIntersector segmentIntersector_0)
	{
		templateInstance = 0;
		ForgotParameter();
		for (int i = 0; i < m_CreatorInstance.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)m_CreatorInstance[i];
			if (sweepLineEvent.IsInsert)
			{
				OrderParameter(i, sweepLineEvent.DeleteEventIndex, sweepLineEvent, segmentIntersector_0);
			}
		}
	}

	private void OrderParameter(int int_0, int int_1, SweepLineEvent sweepLineEvent_0, SegmentIntersector segmentIntersector_0)
	{
		MonotoneChain monotoneChain = (MonotoneChain)sweepLineEvent_0.Object;
		for (int i = int_0; i < int_1; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)m_CreatorInstance[i];
			if (sweepLineEvent.IsInsert)
			{
				MonotoneChain monotoneChain_ = (MonotoneChain)sweepLineEvent.Object;
				_ = sweepLineEvent_0.EdgeSet;
				if (sweepLineEvent_0.EdgeSet == null || sweepLineEvent_0.EdgeSet != sweepLineEvent.EdgeSet)
				{
					monotoneChain.ComputeIntersections(monotoneChain_, segmentIntersector_0);
					templateInstance++;
				}
			}
		}
	}
}
