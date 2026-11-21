using System;
using DotSpatial.Topology.Index.Quadtree;

namespace DotSpatial.Topology.Index.Bintree;

public class Key
{
	private Interval globalCollection;

	private int m_WorkerCollection;

	private double _AccountCollection;

	public virtual double Point => _AccountCollection;

	public virtual int Level => m_WorkerCollection;

	public virtual Interval Interval => globalCollection;

	public Key(Interval interval_0)
	{
		ComputeKey(interval_0);
	}

	public static int ComputeLevel(Interval interval_0)
	{
		return DoubleBits.GetExponent(interval_0.Width) + 1;
	}

	public void ComputeKey(Interval interval_0)
	{
		m_WorkerCollection = ComputeLevel(interval_0);
		globalCollection = new Interval();
		ReadParameter(m_WorkerCollection, interval_0);
		while (!globalCollection.Contains(interval_0))
		{
			m_WorkerCollection++;
			ReadParameter(m_WorkerCollection, interval_0);
		}
	}

	private void ReadParameter(int int_0, Interval interval_0)
	{
		double num = DoubleBits.PowerOf2(int_0);
		_AccountCollection = Math.Floor(interval_0.Min / num) * num;
		globalCollection.Init(_AccountCollection, _AccountCollection + num);
	}
}
