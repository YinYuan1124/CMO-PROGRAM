using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Polygonize;

public class PolygonizeDirectedEdge : DirectedEdge
{
	private EdgeRing _DefinitionRule;

	private long valRule = -1L;

	private PolygonizeDirectedEdge m_WrapperRule;

	public virtual long Label
	{
		get
		{
			return valRule;
		}
		set
		{
			valRule = value;
		}
	}

	public virtual PolygonizeDirectedEdge Next
	{
		get
		{
			return m_WrapperRule;
		}
		set
		{
			m_WrapperRule = value;
		}
	}

	public virtual bool IsInRing => Ring != null;

	public virtual EdgeRing Ring
	{
		get
		{
			return _DefinitionRule;
		}
		set
		{
			_DefinitionRule = value;
		}
	}

	public PolygonizeDirectedEdge(Node node_0, Node node_1, Coordinate coordinate_0, bool bool_0)
		: base(node_0, node_1, coordinate_0, bool_0)
	{
	}
}
