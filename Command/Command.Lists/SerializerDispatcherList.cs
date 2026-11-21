using System.Collections.Generic;
using DotSpatial.Topology;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace Command.Lists;

internal class SerializerDispatcherList : ShortCircuitedGeometryVisitor
{
	private readonly IEnvelope m_ParamsThread;

	private readonly IList<Coordinate> m_InfoThread;

	private bool _HelperThread;

	public SerializerDispatcherList(IPolygon ipolygon_0)
	{
		m_InfoThread = ipolygon_0.Shell.Coordinates;
		m_ParamsThread = ipolygon_0.EnvelopeInternal;
	}

	public bool PrintCollection()
	{
		return _HelperThread;
	}

	protected override void Visit(IGeometry igeometry_0)
	{
		if (!(igeometry_0 is Polygon))
		{
			return;
		}
		IEnvelope envelopeInternal = igeometry_0.EnvelopeInternal;
		if (!m_ParamsThread.Intersects(envelopeInternal))
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < 4)
			{
				Coordinate coordinate_ = m_InfoThread[num];
				if (envelopeInternal.Contains(coordinate_) && SimplePointInAreaLocator.ContainsPointInPolygon(coordinate_, (Polygon)igeometry_0))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		_HelperThread = true;
	}

	protected override bool IsDone()
	{
		return _HelperThread;
	}
}
