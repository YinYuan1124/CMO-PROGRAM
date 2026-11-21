using DotSpatial.Topology.Voronoi;
using OpenDis.Services;

namespace Command.Maps;

internal class DicListenerMapping : MethodMerchantService
{
	public readonly Vector2 _MerchantThread;

	public DicListenerMapping(Vector2 vector2_0)
	{
		_MerchantThread = vector2_0;
	}
}
