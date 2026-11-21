using System.Collections;

namespace DotSpatial.Topology.Operation.Distance;

public class ConnectedElementPointFilter : IGeometryFilter
{
	private readonly IList m_ContextRule;

	private ConnectedElementPointFilter(IList ilist_0)
	{
		m_ContextRule = ilist_0;
	}

	public virtual void Filter(IGeometry igeometry_0)
	{
		if (igeometry_0 is Point || igeometry_0 is LineString || igeometry_0 is Polygon)
		{
			m_ContextRule.Add(igeometry_0.Coordinate);
		}
	}

	public static IList GetCoordinates(Geometry geometry_0)
	{
		IList list = new ArrayList();
		geometry_0.Apply(new ConnectedElementPointFilter(list));
		return list;
	}
}
