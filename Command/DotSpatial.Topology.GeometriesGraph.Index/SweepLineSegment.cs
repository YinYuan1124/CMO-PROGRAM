using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SweepLineSegment
{
	private readonly Edge m_RulesInstance;

	private readonly int methodInstance;

	private readonly IList<Coordinate> serviceInstance;

	public virtual double MinX
	{
		get
		{
			double x = serviceInstance[methodInstance].X;
			double x2 = serviceInstance[methodInstance + 1].X;
			if (x < x2)
			{
				return x;
			}
			return x2;
		}
	}

	public virtual double MaxX
	{
		get
		{
			double x = serviceInstance[methodInstance].X;
			double x2 = serviceInstance[methodInstance + 1].X;
			if (x <= x2)
			{
				return x2;
			}
			return x;
		}
	}

	public SweepLineSegment(Edge edge_0, int int_0)
	{
		m_RulesInstance = edge_0;
		methodInstance = int_0;
		serviceInstance = edge_0.Coordinates;
	}

	public virtual void ComputeIntersections(SweepLineSegment sweepLineSegment_0, SegmentIntersector segmentIntersector_0)
	{
		segmentIntersector_0.AddIntersections(m_RulesInstance, methodInstance, sweepLineSegment_0.m_RulesInstance, sweepLineSegment_0.methodInstance);
	}
}
