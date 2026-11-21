using DotSpatial.Topology.Voronoi;
using OpenDis.Services;

namespace Command.Filter;

internal class CallbackThread : MethodMerchantService
{
	public readonly VoronoiEdge m_DecoratorThread;

	public readonly bool m_ProcessThread;

	public CallbackThread(VoronoiEdge voronoiEdge_0, bool bool_0)
	{
		m_DecoratorThread = voronoiEdge_0;
		m_ProcessThread = bool_0;
	}

	public double SetupRule(double double_0, double double_1)
	{
		if (m_ProcessThread)
		{
			return double_1 - Fortune.GetRule(m_DecoratorThread.RightData.X, m_DecoratorThread.RightData.Y, m_DecoratorThread.LeftData.X, m_DecoratorThread.LeftData.Y, double_0);
		}
		return double_1 - Fortune.GetRule(m_DecoratorThread.LeftData.X, m_DecoratorThread.LeftData.Y, m_DecoratorThread.RightData.X, m_DecoratorThread.RightData.Y, double_0);
	}
}
