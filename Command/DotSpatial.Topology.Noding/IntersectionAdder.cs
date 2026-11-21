using System;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class IntersectionAdder : GInterface5
{
	private readonly LineIntersector m_ProductRule;

	public int NumInteriorIntersections;

	private bool m_AnnotationRule;

	private bool iteratorRule;

	private bool initializerRule;

	private bool m_RoleRule;

	private int m_FactoryRule;

	private int m_AttributeRule;

	private int eventRule;

	public LineIntersector LineIntersector => m_ProductRule;

	public bool HasIntersection => iteratorRule;

	public bool HasProperIntersection => initializerRule;

	public bool HasProperInteriorIntersection => m_RoleRule;

	public bool HasInteriorIntersection => m_AnnotationRule;

	public IntersectionAdder(LineIntersector lineIntersector_0)
	{
		m_ProductRule = lineIntersector_0;
	}

	public void ProcessIntersections(SegmentString segmentString_0, int int_0, SegmentString segmentString_1, int int_1)
	{
		if (segmentString_0 == segmentString_1 && int_0 == int_1)
		{
			return;
		}
		eventRule++;
		Coordinate coordinate_ = segmentString_0.Coordinates[int_0];
		Coordinate coordinate_2 = segmentString_0.Coordinates[int_0 + 1];
		Coordinate coordinate_3 = segmentString_1.Coordinates[int_1];
		Coordinate coordinate_4 = segmentString_1.Coordinates[int_1 + 1];
		m_ProductRule.ComputeIntersection(coordinate_, coordinate_2, coordinate_3, coordinate_4);
		if (!m_ProductRule.HasIntersection)
		{
			return;
		}
		m_FactoryRule++;
		if (m_ProductRule.IsInteriorIntersection())
		{
			NumInteriorIntersections++;
			m_AnnotationRule = true;
		}
		if (!CalculateObject(segmentString_0, int_0, segmentString_1, int_1))
		{
			iteratorRule = true;
			segmentString_0.AddIntersections(m_ProductRule, int_0);
			segmentString_1.AddIntersections(m_ProductRule, int_1);
			if (m_ProductRule.IsProper)
			{
				m_AttributeRule++;
				initializerRule = true;
				m_RoleRule = true;
			}
		}
	}

	private static bool FillObject(int int_0, int int_1)
	{
		return Math.Abs(int_0 - int_1) == 1;
	}

	private bool CalculateObject(SegmentString segmentString_0, int int_0, SegmentString segmentString_1, int int_1)
	{
		if (segmentString_0 == segmentString_1 && m_ProductRule.IntersectionNum == 1)
		{
			if (FillObject(int_0, int_1))
			{
				return true;
			}
			if (segmentString_0.IsClosed)
			{
				int num = segmentString_0.Count - 1;
				if ((int_0 == 0 && int_1 == num) || (int_1 == 0 && int_0 == num))
				{
					return true;
				}
			}
		}
		return false;
	}
}
