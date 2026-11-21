using System.Collections;
using DotSpatial.Topology.Index;

namespace DotSpatial.Topology.Simplify;

public class LineSegmentVisitor : IItemVisitor
{
	private readonly ArrayList classThread = new ArrayList();

	private readonly LineSegment requestThread;

	public virtual ArrayList Items => classThread;

	public LineSegmentVisitor(LineSegment lineSegment_0)
	{
		requestThread = lineSegment_0;
	}

	public virtual void VisitItem(object object_0)
	{
		LineSegment lineSegment = (LineSegment)object_0;
		if (Envelope.Intersects(lineSegment.P0, lineSegment.P1, requestThread.P0, requestThread.P1))
		{
			classThread.Add(object_0);
		}
	}
}
