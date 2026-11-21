using DotSpatial.Topology;
using DotSpatial.Topology.Utilities;

namespace Command.Objects;

internal class ParamConfigObject : ShortCircuitedGeometryVisitor
{
	private readonly IEnvelope mapperThread;

	private bool m_ManagerThread;

	public ParamConfigObject(IEnvelope ienvelope_0)
	{
		mapperThread = ienvelope_0;
	}

	public bool DefineCollection()
	{
		return m_ManagerThread;
	}

	protected override void Visit(IGeometry igeometry_0)
	{
		IEnvelope envelopeInternal = igeometry_0.EnvelopeInternal;
		if (mapperThread.Intersects(envelopeInternal))
		{
			if (mapperThread.Contains(envelopeInternal))
			{
				m_ManagerThread = true;
			}
			else if (envelopeInternal.Minimum.X >= mapperThread.Minimum.X && envelopeInternal.Maximum.X <= mapperThread.Maximum.X)
			{
				m_ManagerThread = true;
			}
			else if (envelopeInternal.Minimum.Y >= mapperThread.Minimum.Y && envelopeInternal.Maximum.Y <= mapperThread.Maximum.Y)
			{
				m_ManagerThread = true;
			}
		}
	}

	protected override bool IsDone()
	{
		return m_ManagerThread;
	}
}
