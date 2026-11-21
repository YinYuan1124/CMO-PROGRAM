using System;

namespace DotSpatial.Topology.Index.Sweepline;

public class SweepLineEvent : IComparable
{
	public enum SweepLineEventType
	{
		Insert = 1,
		Delete
	}

	private readonly SweepLineEventType indexerCollection;

	private readonly SweepLineEvent m_ResolverCollection;

	private readonly SweepLineInterval _PublisherCollection;

	private readonly double m_ServerCollection;

	private int adapterCollection;

	public virtual bool IsInsert => m_ResolverCollection == null;

	public virtual bool IsDelete => m_ResolverCollection != null;

	public virtual SweepLineEvent InsertEvent => m_ResolverCollection;

	public virtual int DeleteEventIndex
	{
		get
		{
			return adapterCollection;
		}
		set
		{
			adapterCollection = value;
		}
	}

	public virtual SweepLineInterval Interval => _PublisherCollection;

	public SweepLineEvent(double double_0, SweepLineEvent sweepLineEvent_0, SweepLineInterval sweepLineInterval_0)
	{
		m_ServerCollection = double_0;
		m_ResolverCollection = sweepLineEvent_0;
		indexerCollection = ((sweepLineEvent_0 == null) ? SweepLineEventType.Insert : SweepLineEventType.Delete);
		_PublisherCollection = sweepLineInterval_0;
	}

	public virtual int CompareTo(object target)
	{
		SweepLineEvent sweepLineEvent = (SweepLineEvent)target;
		if (m_ServerCollection < sweepLineEvent.m_ServerCollection)
		{
			return -1;
		}
		if (m_ServerCollection <= sweepLineEvent.m_ServerCollection)
		{
			if (indexerCollection < sweepLineEvent.indexerCollection)
			{
				return -1;
			}
			if (indexerCollection <= sweepLineEvent.indexerCollection)
			{
				return 0;
			}
			return 1;
		}
		return 1;
	}
}
