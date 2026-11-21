namespace DotSpatial.Topology.Operation.Distance;

public class GeometryLocation
{
	public const int INSIDE_AREA = -1;

	private readonly IGeometry _IndexerRule;

	private readonly Coordinate m_ResolverRule;

	private readonly int m_PublisherRule;

	public virtual IGeometry GeometryComponent => _IndexerRule;

	public virtual int SegmentIndex => m_PublisherRule;

	public virtual Coordinate Coordinate => m_ResolverRule;

	public virtual bool IsInsideArea => m_PublisherRule == -1;

	public GeometryLocation(IGeometry igeometry_0, int int_0, Coordinate coordinate_0)
	{
		_IndexerRule = igeometry_0;
		m_PublisherRule = int_0;
		m_ResolverRule = new Coordinate(coordinate_0);
	}

	public GeometryLocation(IGeometry igeometry_0, Coordinate coordinate_0)
		: this(igeometry_0, -1, coordinate_0)
	{
	}
}
