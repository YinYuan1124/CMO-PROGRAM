namespace DotSpatial.Topology.Index.Bintree;

public class Interval
{
	private double _AttributeCollection;

	private double m_EventCollection;

	public virtual double Min
	{
		get
		{
			return m_EventCollection;
		}
		set
		{
			m_EventCollection = value;
		}
	}

	public virtual double Max
	{
		get
		{
			return _AttributeCollection;
		}
		set
		{
			_AttributeCollection = value;
		}
	}

	public virtual double Width => Max - Min;

	public Interval()
	{
		m_EventCollection = 0.0;
		_AttributeCollection = 0.0;
	}

	public Interval(double double_0, double double_1)
	{
		Init(double_0, double_1);
	}

	public Interval(Interval interval_0)
	{
		Init(interval_0.Min, interval_0.Max);
	}

	public void Init(double double_0, double double_1)
	{
		Min = double_0;
		Max = double_1;
		if (double_0 > double_1)
		{
			Min = double_1;
			Max = double_0;
		}
	}

	public virtual void ExpandToInclude(Interval interval_0)
	{
		if (interval_0.Max > Max)
		{
			Max = interval_0.Max;
		}
		if (interval_0.Min < Min)
		{
			Min = interval_0.Min;
		}
	}

	public virtual bool Overlaps(Interval interval_0)
	{
		return Overlaps(interval_0.Min, interval_0.Max);
	}

	public virtual bool Overlaps(double double_0, double double_1)
	{
		if (Min <= double_1)
		{
			return Max >= double_0;
		}
		return false;
	}

	public virtual bool Contains(Interval interval_0)
	{
		return Contains(interval_0.Min, interval_0.Max);
	}

	public virtual bool Contains(double double_0, double double_1)
	{
		if (double_0 < Min)
		{
			return false;
		}
		return double_1 <= Max;
	}

	public virtual bool Contains(double double_0)
	{
		if (double_0 < Min)
		{
			return false;
		}
		return double_0 <= Max;
	}
}
