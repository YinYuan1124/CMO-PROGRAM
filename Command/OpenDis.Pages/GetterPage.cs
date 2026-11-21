using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology;
using DotSpatial.Topology.Operation.Predicate;
using DotSpatial.Topology.Utilities;

namespace OpenDis.Pages;

internal class GetterPage : ShortCircuitedGeometryVisitor
{
	private readonly IEnvelope _GetterThread;

	private readonly IList<Coordinate> m_ProducerThread;

	private readonly object procThread;

	private bool structRule;

	public GetterPage(IPolygon ipolygon_0)
	{
		procThread = ipolygon_0;
		m_ProducerThread = ipolygon_0.Shell.Coordinates;
		_GetterThread = ipolygon_0.EnvelopeInternal;
	}

	public bool PublishCollection()
	{
		return structRule;
	}

	protected override void Visit(IGeometry igeometry_0)
	{
		IEnvelope envelopeInternal = igeometry_0.EnvelopeInternal;
		if (_GetterThread.Intersects(envelopeInternal))
		{
			if (igeometry_0.NumPoints <= 200)
			{
				AwakeCollection(igeometry_0);
			}
			else
			{
				structRule = ((IRelate)procThread).Relate(igeometry_0).IsIntersects();
			}
		}
	}

	private void AwakeCollection(IGeometry igeometry_0)
	{
		IList lines = LinearComponentExtracter.GetLines(igeometry_0);
		if (new SegmentIntersectionTester().HasIntersectionWithLineStrings(m_ProducerThread, lines))
		{
			structRule = true;
		}
	}

	protected override bool IsDone()
	{
		return structRule;
	}
}
