using System.Collections;
using DotSpatial.Topology.Index.Quadtree;

namespace DotSpatial.Topology.Simplify;

public class LineSegmentIndex
{
	private readonly Quadtree m_InvocationThread = new Quadtree();

	public virtual void Add(TaggedLineString taggedLineString_0)
	{
		TaggedLineSegment[] segments = taggedLineString_0.Segments;
		for (int i = 0; i < segments.Length - 1; i++)
		{
			TaggedLineSegment lineSegment_ = segments[i];
			Add(lineSegment_);
		}
	}

	public virtual void Add(LineSegment lineSegment_0)
	{
		m_InvocationThread.Insert(new Envelope(lineSegment_0.P0, lineSegment_0.P1), lineSegment_0);
	}

	public virtual void Remove(LineSegment lineSegment_0)
	{
		m_InvocationThread.Remove(new Envelope(lineSegment_0.P0, lineSegment_0.P1), lineSegment_0);
	}

	public virtual IList Query(LineSegment lineSegment_0)
	{
		Envelope ienvelope_ = new Envelope(lineSegment_0.P0, lineSegment_0.P1);
		LineSegmentVisitor lineSegmentVisitor = new LineSegmentVisitor(lineSegment_0);
		m_InvocationThread.Query(ienvelope_, lineSegmentVisitor);
		return lineSegmentVisitor.Items;
	}
}
