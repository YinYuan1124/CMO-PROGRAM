using System;

namespace DotSpatial.Topology.KDTree;

public class HRect : ICloneable
{
	internal HPoint containerCollection;

	internal HPoint m_ComposerCollection;

	public double HyperVolume
	{
		get
		{
			double num = 1.0;
			for (int i = 0; i < m_ComposerCollection.NumOrdinates; i++)
			{
				num *= containerCollection[i] - m_ComposerCollection[i];
			}
			return num;
		}
	}

	public HPoint Minimum
	{
		get
		{
			return m_ComposerCollection;
		}
		set
		{
			m_ComposerCollection = value;
		}
	}

	public HPoint Maximum
	{
		get
		{
			return containerCollection;
		}
		set
		{
			containerCollection = value;
		}
	}

	public int NumOrdinates => m_ComposerCollection.NumOrdinates;

	public HRect(int int_0)
	{
		m_ComposerCollection = new HPoint(int_0);
		containerCollection = new HPoint(int_0);
	}

	public HRect(HPoint hpoint_0, HPoint hpoint_1)
	{
		m_ComposerCollection = hpoint_0.Copy();
		containerCollection = hpoint_1.Copy();
	}

	public object Clone()
	{
		return new HRect(m_ComposerCollection, containerCollection);
	}

	public HRect Copy()
	{
		return new HRect(m_ComposerCollection, containerCollection);
	}

	public HPoint Closest(HPoint hpoint_0)
	{
		int numOrdinates = hpoint_0.NumOrdinates;
		HPoint hPoint = new HPoint(numOrdinates);
		for (int i = 0; i < numOrdinates; i++)
		{
			if (hpoint_0[i] <= m_ComposerCollection[i])
			{
				hPoint[i] = m_ComposerCollection[i];
			}
			else if (hpoint_0[i] < containerCollection[i])
			{
				hPoint[i] = hpoint_0[i];
			}
			else
			{
				hPoint[i] = containerCollection[i];
			}
		}
		return hPoint;
	}

	public HPoint Farthest(HPoint hpoint_0)
	{
		int numOrdinates = hpoint_0.NumOrdinates;
		HPoint hPoint = new HPoint(numOrdinates);
		for (int i = 0; i < numOrdinates; i++)
		{
			if (hpoint_0[i] <= m_ComposerCollection[i])
			{
				hPoint[i] = containerCollection[i];
			}
			else if (hpoint_0[i] < containerCollection[i])
			{
				if (hpoint_0[i] - m_ComposerCollection[i] <= containerCollection[i] - hpoint_0[i])
				{
					hPoint[i] = containerCollection[i];
				}
				else
				{
					hPoint[i] = m_ComposerCollection[i];
				}
			}
			else
			{
				hPoint[i] = m_ComposerCollection[i];
			}
		}
		return hPoint;
	}

	public static HRect InfiniteHRect(int int_0)
	{
		HPoint hPoint = new HPoint(int_0);
		HPoint hPoint2 = new HPoint(int_0);
		for (int i = 0; i < int_0; i++)
		{
			hPoint[i] = double.NegativeInfinity;
			hPoint2[i] = double.PositiveInfinity;
		}
		return new HRect(hPoint, hPoint2);
	}

	public HRect Intersection(HRect hrect_0)
	{
		HPoint hPoint = new HPoint(m_ComposerCollection.NumOrdinates);
		HPoint hPoint2 = new HPoint(m_ComposerCollection.NumOrdinates);
		for (int i = 0; i < m_ComposerCollection.NumOrdinates; i++)
		{
			hPoint[i] = Math.Max(m_ComposerCollection[i], hrect_0.m_ComposerCollection[i]);
			hPoint2[i] = Math.Min(containerCollection[i], hrect_0.containerCollection[i]);
			if (!(hPoint[i] < hPoint2[i]))
			{
				return null;
			}
		}
		return new HRect(hPoint, hPoint2);
	}

	public override string ToString()
	{
		return ((object)m_ComposerCollection)?.ToString() + "\n" + ((object)containerCollection)?.ToString() + "\n";
	}
}
