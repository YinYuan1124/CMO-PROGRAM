using System.Collections.Generic;

namespace DotSpatial.Topology.Simplify;

public class DouglasPeuckerLineSimplifier
{
	private readonly IList<Coordinate> m_ProxyThread;

	private readonly LineSegment readerThread = new LineSegment();

	private double m_PropertyThread;

	private bool[] importerThread;

	private DouglasPeuckerLineSimplifier(IList<Coordinate> ilist_0)
	{
		m_ProxyThread = ilist_0;
	}

	public static IList<Coordinate> Simplify(IList<Coordinate> ilist_0, double double_0)
	{
		return new DouglasPeuckerLineSimplifier(ilist_0)
		{
			m_PropertyThread = double_0
		}.AwakeRule();
	}

	private Coordinate[] AwakeRule()
	{
		importerThread = new bool[m_ProxyThread.Count];
		for (int i = 0; i < m_ProxyThread.Count; i++)
		{
			importerThread[i] = true;
		}
		QueryRule(0, m_ProxyThread.Count - 1);
		CoordinateList coordinateList = new CoordinateList();
		for (int j = 0; j < m_ProxyThread.Count; j++)
		{
			if (importerThread[j])
			{
				coordinateList.Add(new Coordinate(m_ProxyThread[j]));
			}
		}
		return coordinateList.ToCoordinateArray();
	}

	private void QueryRule(int int_0, int int_1)
	{
		if (int_0 + 1 == int_1)
		{
			return;
		}
		readerThread.P0 = m_ProxyThread[int_0];
		readerThread.P1 = m_ProxyThread[int_1];
		double num = -1.0;
		int num2 = int_0;
		for (int i = int_0 + 1; i < int_1; i++)
		{
			double num3 = readerThread.Distance(m_ProxyThread[i]);
			if (num3 > num)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num <= m_PropertyThread)
		{
			for (int j = int_0 + 1; j < int_1; j++)
			{
				importerThread[j] = false;
			}
		}
		else
		{
			QueryRule(int_0, num2);
			QueryRule(num2, int_1);
		}
	}
}
