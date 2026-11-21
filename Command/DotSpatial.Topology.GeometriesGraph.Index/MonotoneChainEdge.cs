using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class MonotoneChainEdge
{
	private readonly Edge m_AdapterInstance;

	private readonly Envelope m_SchemaInstance = new Envelope();

	private readonly Envelope utilsInstance = new Envelope();

	private readonly IList<Coordinate> predicateInstance;

	private readonly int[] singletonInstance;

	public virtual IList<Coordinate> Coordinates => predicateInstance;

	public virtual int[] StartIndexes => singletonInstance;

	public MonotoneChainEdge(Edge edge_0)
	{
		m_AdapterInstance = edge_0;
		predicateInstance = edge_0.Coordinates;
		MonotoneChainIndexer monotoneChainIndexer = new MonotoneChainIndexer();
		singletonInstance = monotoneChainIndexer.GetChainStartIndices(predicateInstance);
	}

	public virtual double GetMinX(int int_0)
	{
		double x = predicateInstance[singletonInstance[int_0]].X;
		double x2 = predicateInstance[singletonInstance[int_0 + 1]].X;
		if (x < x2)
		{
			return x;
		}
		return x2;
	}

	public virtual double GetMaxX(int int_0)
	{
		double x = predicateInstance[singletonInstance[int_0]].X;
		double x2 = predicateInstance[singletonInstance[int_0 + 1]].X;
		if (x <= x2)
		{
			return x2;
		}
		return x;
	}

	public virtual void ComputeIntersects(MonotoneChainEdge monotoneChainEdge_0, SegmentIntersector segmentIntersector_0)
	{
		for (int i = 0; i < singletonInstance.Length - 1; i++)
		{
			for (int j = 0; j < monotoneChainEdge_0.singletonInstance.Length - 1; j++)
			{
				ComputeIntersectsForChain(i, monotoneChainEdge_0, j, segmentIntersector_0);
			}
		}
	}

	public virtual void ComputeIntersectsForChain(int int_0, MonotoneChainEdge monotoneChainEdge_0, int int_1, SegmentIntersector segmentIntersector_0)
	{
		ResetParameter(singletonInstance[int_0], singletonInstance[int_0 + 1], monotoneChainEdge_0, monotoneChainEdge_0.singletonInstance[int_1], monotoneChainEdge_0.singletonInstance[int_1 + 1], segmentIntersector_0);
	}

	private void ResetParameter(int int_0, int int_1, MonotoneChainEdge monotoneChainEdge_0, int int_2, int int_3, SegmentIntersector segmentIntersector_0)
	{
		Coordinate coordinate_ = predicateInstance[int_0];
		Coordinate coordinate_2 = predicateInstance[int_1];
		Coordinate coordinate_3 = monotoneChainEdge_0.predicateInstance[int_2];
		Coordinate coordinate_4 = monotoneChainEdge_0.predicateInstance[int_3];
		if (int_1 - int_0 == 1 && int_3 - int_2 == 1)
		{
			segmentIntersector_0.AddIntersections(m_AdapterInstance, int_0, monotoneChainEdge_0.m_AdapterInstance, int_2);
			return;
		}
		m_SchemaInstance.Init(coordinate_, coordinate_2);
		utilsInstance.Init(coordinate_3, coordinate_4);
		if (!m_SchemaInstance.Intersects(utilsInstance))
		{
			return;
		}
		int num = (int_0 + int_1) / 2;
		int num2 = (int_2 + int_3) / 2;
		if (int_0 < num)
		{
			if (int_2 < num2)
			{
				ResetParameter(int_0, num, monotoneChainEdge_0, int_2, num2, segmentIntersector_0);
			}
			if (num2 < int_3)
			{
				ResetParameter(int_0, num, monotoneChainEdge_0, num2, int_3, segmentIntersector_0);
			}
		}
		if (num < int_1)
		{
			if (int_2 < num2)
			{
				ResetParameter(num, int_1, monotoneChainEdge_0, int_2, num2, segmentIntersector_0);
			}
			if (num2 < int_3)
			{
				ResetParameter(num, int_1, monotoneChainEdge_0, num2, int_3, segmentIntersector_0);
			}
		}
	}
}
