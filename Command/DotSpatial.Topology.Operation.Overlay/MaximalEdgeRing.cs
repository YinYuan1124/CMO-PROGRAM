using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class MaximalEdgeRing : EdgeRing
{
	public MaximalEdgeRing(DirectedEdge directedEdge_0, IGeometryFactory igeometryFactory_0)
		: base(directedEdge_0, igeometryFactory_0)
	{
	}

	public override DirectedEdge GetNext(DirectedEdge directedEdge_0)
	{
		return directedEdge_0.Next;
	}

	public override void SetEdgeRing(DirectedEdge directedEdge_0, EdgeRing edgeRing_0)
	{
		directedEdge_0.EdgeRing = edgeRing_0;
	}

	public virtual void LinkDirectedEdgesForMinimalEdgeRings()
	{
		DirectedEdge directedEdge = base.StartDe;
		do
		{
			((DirectedEdgeStar)directedEdge.Node.Edges).LinkMinimalDirectedEdges(this);
			directedEdge = directedEdge.Next;
		}
		while (directedEdge != base.StartDe);
	}

	public virtual IList BuildMinimalRings()
	{
		IList list = new ArrayList();
		DirectedEdge directedEdge = base.StartDe;
		do
		{
			if (directedEdge.MinEdgeRing == null)
			{
				EdgeRing value = new MinimalEdgeRing(directedEdge, base.InnerGeometryFactory);
				list.Add(value);
			}
			directedEdge = directedEdge.Next;
		}
		while (directedEdge != base.StartDe);
		return list;
	}
}
