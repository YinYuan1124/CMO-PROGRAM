using Command.Tasks;
using DotSpatial.Topology.Voronoi;

namespace OpenDis.Database;

internal class ProcProcess : ThreadThread
{
	public readonly Vector2 m_StructThread;

	public override double Y => m_StructThread.Y;

	protected override double X => m_StructThread.X;

	public ProcProcess(Vector2 vector2_0)
	{
		m_StructThread = vector2_0;
	}
}
