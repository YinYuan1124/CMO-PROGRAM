using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class PolygonExtracter : IGeometryFilter
{
	private readonly IList _ValThread;

	public PolygonExtracter(IList ilist_0)
	{
		_ValThread = ilist_0;
	}

	public virtual void Filter(IGeometry igeometry_0)
	{
		if (igeometry_0 is Polygon)
		{
			_ValThread.Add(igeometry_0);
		}
	}

	public static IList GetPolygons(IGeometry igeometry_0)
	{
		IList list = new ArrayList();
		igeometry_0.Apply(new PolygonExtracter(list));
		return list;
	}
}
