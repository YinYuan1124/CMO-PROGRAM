using System.Collections;

namespace DotSpatial.Topology.Operation.Distance;

public class ConnectedElementLocationFilter : IGeometryFilter
{
	private readonly IList m_ConnectionRule;

	private ConnectedElementLocationFilter(IList ilist_0)
	{
		m_ConnectionRule = ilist_0;
	}

	public virtual void Filter(IGeometry igeometry_0)
	{
		if (igeometry_0 is Point || igeometry_0 is LineString || igeometry_0 is Polygon)
		{
			m_ConnectionRule.Add(new GeometryLocation(igeometry_0, 0, igeometry_0.Coordinate));
		}
	}

	public static IList GetLocations(IGeometry igeometry_0)
	{
		IList list = new ArrayList();
		igeometry_0.Apply(new ConnectedElementLocationFilter(list));
		return list;
	}
}
