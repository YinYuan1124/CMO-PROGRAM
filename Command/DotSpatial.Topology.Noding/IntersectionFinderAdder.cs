using System.Collections;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class IntersectionFinderAdder : GInterface5
{
	private readonly IList globalRule;

	private readonly LineIntersector m_WorkerRule;

	public IList InteriorIntersections => globalRule;

	public IntersectionFinderAdder(LineIntersector lineIntersector_0)
	{
		m_WorkerRule = lineIntersector_0;
		globalRule = new ArrayList();
	}

	public void ProcessIntersections(SegmentString segmentString_0, int int_0, SegmentString segmentString_1, int int_1)
	{
		if (segmentString_0 == segmentString_1 && int_0 == int_1)
		{
			return;
		}
		Coordinate coordinate_ = segmentString_0.Coordinates[int_0];
		Coordinate coordinate_2 = segmentString_0.Coordinates[int_0 + 1];
		Coordinate coordinate_3 = segmentString_1.Coordinates[int_1];
		Coordinate coordinate_4 = segmentString_1.Coordinates[int_1 + 1];
		m_WorkerRule.ComputeIntersection(coordinate_, coordinate_2, coordinate_3, coordinate_4);
		if (m_WorkerRule.HasIntersection && m_WorkerRule.IsInteriorIntersection())
		{
			for (int i = 0; i < m_WorkerRule.IntersectionNum; i++)
			{
				globalRule.Add(m_WorkerRule.GetIntersection(i));
			}
			segmentString_0.AddIntersections(m_WorkerRule, int_0);
			segmentString_1.AddIntersections(m_WorkerRule, int_1);
		}
	}
}
