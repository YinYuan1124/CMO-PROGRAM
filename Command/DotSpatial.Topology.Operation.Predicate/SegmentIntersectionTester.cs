using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Operation.Predicate;

public class SegmentIntersectionTester
{
	private readonly LineIntersector m_ProcessRule = new RobustLineIntersector();

	private bool threadRule;

	private Coordinate ruleRule;

	private Coordinate _CollectionRule;

	private Coordinate instanceRule;

	private Coordinate m_ObjectRule;

	public bool HasIntersectionWithLineStrings(IList<Coordinate> ilist_0, IList ilist_1)
	{
		IEnumerator enumerator = ilist_1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			LineString lineString = (LineString)enumerator.Current;
			CalcCollection(ilist_0, lineString.Coordinates);
			if (threadRule)
			{
				break;
			}
		}
		return threadRule;
	}

	private void CalcCollection(IList<Coordinate> ilist_0, IList<Coordinate> ilist_1)
	{
		for (int i = 1; i < ilist_0.Count; i++)
		{
			if (threadRule)
			{
				break;
			}
			ruleRule = ilist_0[i - 1];
			_CollectionRule = ilist_0[i];
			for (int j = 1; j < ilist_1.Count; j++)
			{
				if (threadRule)
				{
					break;
				}
				instanceRule = ilist_1[j - 1];
				m_ObjectRule = ilist_1[j];
				m_ProcessRule.ComputeIntersection(ruleRule, _CollectionRule, instanceRule, m_ObjectRule);
				if (m_ProcessRule.HasIntersection)
				{
					threadRule = true;
				}
			}
		}
	}
}
