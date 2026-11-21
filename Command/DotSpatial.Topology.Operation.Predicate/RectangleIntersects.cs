using Command.Lists;
using Command.Objects;
using OpenDis.Pages;

namespace DotSpatial.Topology.Operation.Predicate;

public class RectangleIntersects
{
	public const int MAXIMUM_SCAN_SEGMENT_COUNT = 200;

	private readonly IEnvelope callbackRule;

	private readonly IPolygon decoratorRule;

	public RectangleIntersects(IPolygon ipolygon_0)
	{
		decoratorRule = ipolygon_0;
		callbackRule = ipolygon_0.EnvelopeInternal;
	}

	public static bool Intersects(Polygon polygon_0, IGeometry igeometry_0)
	{
		return new RectangleIntersects(polygon_0).Intersects(igeometry_0);
	}

	public bool Intersects(IGeometry igeometry_0)
	{
		if (callbackRule.Intersects(igeometry_0.EnvelopeInternal))
		{
			ParamConfigObject paramConfigObject = new ParamConfigObject(callbackRule);
			paramConfigObject.ApplyTo(igeometry_0);
			if (paramConfigObject.DefineCollection())
			{
				return true;
			}
			SerializerDispatcherList serializerDispatcherList = new SerializerDispatcherList(decoratorRule);
			serializerDispatcherList.ApplyTo(igeometry_0);
			if (serializerDispatcherList.PrintCollection())
			{
				return true;
			}
			GetterPage getterPage = new GetterPage(decoratorRule);
			getterPage.ApplyTo(igeometry_0);
			if (getterPage.PublishCollection())
			{
				return true;
			}
			return false;
		}
		return false;
	}
}
