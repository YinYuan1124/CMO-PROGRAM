using Command.Maps;
using Command.Tasks;
using DotSpatial.Topology.Voronoi;

namespace OpenDis.Database;

internal class ClassDecoratorEntry : ThreadThread
{
	public Vector2 Center;

	public DicListenerMapping _MapperProcess;

	public DicListenerMapping _ManagerProcess;

	public DicListenerMapping _GetterProcess;

	public bool _ProducerProcess = true;

	public override double Y => Center.Y + MathTools.Dist(_ManagerProcess._MerchantThread.X, _ManagerProcess._MerchantThread.Y, Center.X, Center.Y);

	protected override double X => Center.X;
}
