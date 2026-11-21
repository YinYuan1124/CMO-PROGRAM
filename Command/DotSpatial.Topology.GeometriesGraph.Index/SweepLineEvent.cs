using System;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SweepLineEvent : IComparable
{
	public const int INSERT = 1;

	public const int DELETE = 2;

	private readonly int _TagInstance;

	private readonly SweepLineEvent m_FieldInstance;

	private readonly object _QueueInstance;

	private readonly double _RegInstance;

	private int m_ParamInstance;

	private object m_PageInstance;

	public virtual object EdgeSet
	{
		get
		{
			return m_PageInstance;
		}
		set
		{
			m_PageInstance = value;
		}
	}

	public virtual bool IsInsert => m_FieldInstance == null;

	public virtual bool IsDelete => m_FieldInstance != null;

	public SweepLineEvent InsertEvent => m_FieldInstance;

	public virtual int DeleteEventIndex
	{
		get
		{
			return m_ParamInstance;
		}
		set
		{
			m_ParamInstance = value;
		}
	}

	public virtual object Object => _QueueInstance;

	public SweepLineEvent(object object_0, double double_0, SweepLineEvent sweepLineEvent_0, object object_1)
	{
		m_PageInstance = object_0;
		_RegInstance = double_0;
		m_FieldInstance = sweepLineEvent_0;
		_TagInstance = 1;
		if (sweepLineEvent_0 != null)
		{
			_TagInstance = 2;
		}
		_QueueInstance = object_1;
	}

	public virtual int CompareTo(object target)
	{
		SweepLineEvent sweepLineEvent = (SweepLineEvent)target;
		if (_RegInstance < sweepLineEvent._RegInstance)
		{
			return -1;
		}
		if (_RegInstance <= sweepLineEvent._RegInstance)
		{
			if (_TagInstance < sweepLineEvent._TagInstance)
			{
				return -1;
			}
			if (_TagInstance <= sweepLineEvent._TagInstance)
			{
				return 0;
			}
			return 1;
		}
		return 1;
	}
}
