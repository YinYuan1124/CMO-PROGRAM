using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class PointBuilder
{
	private readonly IGeometryFactory _FilterRule;

	private readonly OverlayOp _TestsRule;

	public PointBuilder(OverlayOp overlayOp_0, IGeometryFactory igeometryFactory_0)
	{
		_TestsRule = overlayOp_0;
		_FilterRule = igeometryFactory_0;
	}

	public virtual IList Build(SpatialFunction spatialFunction_0)
	{
		IList instance = FindInstance(spatialFunction_0);
		return SetInstance(instance);
	}

	private IList FindInstance(SpatialFunction spatialFunction_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = _TestsRule.Graph.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (!node.IsInResult && OverlayOp.IsResultOfOp(node.Label, spatialFunction_0))
			{
				list.Add(node);
			}
		}
		return list;
	}

	private IList SetInstance(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Coordinate coordinate = ((Node)enumerator.Current).Coordinate;
			if (!_TestsRule.IsCoveredByLa(coordinate))
			{
				IPoint value = _FilterRule.CreatePoint(coordinate);
				list.Add(value);
			}
		}
		return list;
	}
}
