namespace DotSpatial.Topology.GeometriesGraph.Index;

public class MonotoneChain
{
	private readonly int m_PublisherInstance;

	private readonly MonotoneChainEdge serverInstance;

	public MonotoneChain(MonotoneChainEdge monotoneChainEdge_0, int int_0)
	{
		serverInstance = monotoneChainEdge_0;
		m_PublisherInstance = int_0;
	}

	public virtual void ComputeIntersections(MonotoneChain monotoneChain_0, SegmentIntersector segmentIntersector_0)
	{
		serverInstance.ComputeIntersectsForChain(m_PublisherInstance, monotoneChain_0.serverInstance, monotoneChain_0.m_PublisherInstance, segmentIntersector_0);
	}
}
