using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class LinearComponentExtracter : IGeometryComponentFilter
{
	private readonly IList m_RegistryThread;

	public LinearComponentExtracter(IList ilist_0)
	{
		m_RegistryThread = ilist_0;
	}

	public virtual void Filter(IGeometry igeometry_0)
	{
		if (igeometry_0 is LineString)
		{
			m_RegistryThread.Add(igeometry_0);
		}
	}

	public static IList GetLines(IGeometry igeometry_0)
	{
		IList list = new ArrayList();
		igeometry_0.Apply(new LinearComponentExtracter(list));
		return list;
	}
}
