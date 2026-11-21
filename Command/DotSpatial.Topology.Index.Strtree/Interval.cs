using System;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public class Interval
{
	private double m_CreatorCollection;

	private double _TemplateCollection;

	public virtual double Centre => (_TemplateCollection + m_CreatorCollection) / 2.0;

	public Interval(Interval interval_0)
		: this(interval_0._TemplateCollection, interval_0.m_CreatorCollection)
	{
	}

	public Interval(double double_0, double double_1)
	{
		Assert.IsTrue(double_0 <= double_1);
		_TemplateCollection = double_0;
		m_CreatorCollection = double_1;
	}

	public virtual Interval ExpandToInclude(Interval interval_0)
	{
		m_CreatorCollection = Math.Max(m_CreatorCollection, interval_0.m_CreatorCollection);
		_TemplateCollection = Math.Min(_TemplateCollection, interval_0._TemplateCollection);
		return this;
	}

	public virtual bool Intersects(Interval interval_0)
	{
		if (interval_0._TemplateCollection <= m_CreatorCollection)
		{
			return !(interval_0.m_CreatorCollection < _TemplateCollection);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is Interval)
		{
			Interval interval = (Interval)obj;
			if (_TemplateCollection == interval._TemplateCollection)
			{
				return m_CreatorCollection == interval.m_CreatorCollection;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
