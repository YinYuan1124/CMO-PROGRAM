using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class EdgeEndBundleStar : EdgeEndStar
{
	public override void Insert(EdgeEnd edgeEnd_0)
	{
		EdgeEndBundle edgeEndBundle = (EdgeEndBundle)base.EdgeMap[edgeEnd_0];
		if (edgeEndBundle == null)
		{
			edgeEndBundle = new EdgeEndBundle(edgeEnd_0);
			InsertEdgeEnd(edgeEnd_0, edgeEndBundle);
		}
		else
		{
			edgeEndBundle.Insert(edgeEnd_0);
		}
	}

	public virtual void UpdateIm(IntersectionMatrix intersectionMatrix_0)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEndBundle)enumerator.Current).UpdateIm(intersectionMatrix_0);
		}
	}
}
