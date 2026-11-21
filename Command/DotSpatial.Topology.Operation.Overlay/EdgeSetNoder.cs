using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;

namespace DotSpatial.Topology.Operation.Overlay;

public class EdgeSetNoder
{
	private readonly IList m_RepositoryRule = new ArrayList();

	private readonly LineIntersector m_BridgeRule;

	public virtual IList NodedEdges
	{
		get
		{
			new SimpleMcSweepLineIntersector().ComputeIntersections(segmentIntersector_0: new SegmentIntersector(m_BridgeRule, bool_0: true, bool_1: false), ilist_0: m_RepositoryRule, bool_0: true);
			IList list = new ArrayList();
			IEnumerator enumerator = m_RepositoryRule.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((Edge)enumerator.Current).EdgeIntersectionList.AddSplitEdges(list);
			}
			return list;
		}
	}

	public EdgeSetNoder(LineIntersector lineIntersector_0)
	{
		m_BridgeRule = lineIntersector_0;
	}

	public virtual void AddEdges(IList ilist_0)
	{
		foreach (object item in ilist_0)
		{
			m_RepositoryRule.Add(item);
		}
	}
}
