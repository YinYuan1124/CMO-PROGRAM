using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMergeEdge : Edge
{
	private readonly LineString m_CustomerRule;

	public virtual LineString Line => m_CustomerRule;

	public LineMergeEdge(LineString lineString_0)
	{
		m_CustomerRule = lineString_0;
	}
}
