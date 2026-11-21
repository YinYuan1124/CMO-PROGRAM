using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class PointExtracter : IGeometryFilter
{
	private readonly IList _DefinitionThread;

	public PointExtracter(IList ilist_0)
	{
		_DefinitionThread = ilist_0;
	}

	public virtual void Filter(IGeometry igeometry_0)
	{
		if (igeometry_0 is Point)
		{
			_DefinitionThread.Add(igeometry_0);
		}
	}

	public static IList GetPoints(IGeometry igeometry_0)
	{
		IList list = new ArrayList();
		igeometry_0.Apply(new PointExtracter(list));
		return list;
	}
}
