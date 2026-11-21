using System.Collections;

namespace DotSpatial.Topology.Index.Sweepline;

public class SweepLineIndex
{
	private readonly ArrayList schemaCollection = new ArrayList();

	private bool m_UtilsCollection;

	private int predicateCollection;

	public virtual void Add(SweepLineInterval sweepLineInterval_0)
	{
		SweepLineEvent sweepLineEvent = new SweepLineEvent(sweepLineInterval_0.Min, null, sweepLineInterval_0);
		schemaCollection.Add(sweepLineEvent);
		schemaCollection.Add(new SweepLineEvent(sweepLineInterval_0.Max, sweepLineEvent, sweepLineInterval_0));
	}

	private void PushParameter()
	{
		if (m_UtilsCollection)
		{
			return;
		}
		schemaCollection.Sort();
		for (int i = 0; i < schemaCollection.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)schemaCollection[i];
			if (sweepLineEvent.IsDelete)
			{
				sweepLineEvent.InsertEvent.DeleteEventIndex = i;
			}
		}
		m_UtilsCollection = true;
	}

	public virtual void ComputeOverlaps(ISweepLineOverlapAction isweepLineOverlapAction_0)
	{
		predicateCollection = 0;
		PushParameter();
		for (int i = 0; i < schemaCollection.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)schemaCollection[i];
			if (sweepLineEvent.IsInsert)
			{
				InvokeParameter(i, sweepLineEvent.DeleteEventIndex, sweepLineEvent.Interval, isweepLineOverlapAction_0);
			}
		}
	}

	private void InvokeParameter(int int_0, int int_1, SweepLineInterval sweepLineInterval_0, ISweepLineOverlapAction isweepLineOverlapAction_0)
	{
		for (int i = int_0; i < int_1; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)schemaCollection[i];
			if (sweepLineEvent.IsInsert)
			{
				SweepLineInterval interval = sweepLineEvent.Interval;
				isweepLineOverlapAction_0.Overlap(sweepLineInterval_0, interval);
				predicateCollection++;
			}
		}
	}
}
