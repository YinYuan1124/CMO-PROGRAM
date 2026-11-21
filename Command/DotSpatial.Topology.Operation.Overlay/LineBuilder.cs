using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Overlay;

public class LineBuilder
{
	private readonly IGeometryFactory _InvocationRule;

	private readonly IList m_ClassRule = new ArrayList();

	private readonly OverlayOp requestRule;

	private readonly PointLocator valueRule;

	private readonly IList tokenizerRule = new ArrayList();

	public LineBuilder(OverlayOp overlayOp_0, IGeometryFactory igeometryFactory_0, PointLocator pointLocator_0)
	{
		requestRule = overlayOp_0;
		_InvocationRule = igeometryFactory_0;
		valueRule = pointLocator_0;
	}

	public virtual IList Build(SpatialFunction spatialFunction_0)
	{
		ViewInstance();
		ValidateInstance(spatialFunction_0);
		LoginInstance(spatialFunction_0);
		return tokenizerRule;
	}

	private void ViewInstance()
	{
		IEnumerator enumerator = requestRule.Graph.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).FindCoveredLineEdges();
		}
		IEnumerator enumerator2 = requestRule.Graph.EdgeEnds.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator2.Current;
			Edge edge = directedEdge.Edge;
			if (directedEdge.IsLineEdge && !edge.IsCoveredSet)
			{
				edge.IsCovered = requestRule.IsCoveredByA(directedEdge.Coordinate);
			}
		}
	}

	private void ValidateInstance(SpatialFunction spatialFunction_0)
	{
		IEnumerator enumerator = requestRule.Graph.EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge_ = (DirectedEdge)enumerator.Current;
			CollectLineEdge(directedEdge_, spatialFunction_0, m_ClassRule);
			CollectBoundaryTouchEdge(directedEdge_, spatialFunction_0, m_ClassRule);
		}
	}

	public void CollectLineEdge(DirectedEdge directedEdge_0, SpatialFunction spatialFunction_0, IList ilist_0)
	{
		Label label = directedEdge_0.Label;
		Edge edge = directedEdge_0.Edge;
		if (directedEdge_0.IsLineEdge && !directedEdge_0.IsVisited && OverlayOp.IsResultOfOp(label, spatialFunction_0) && !edge.IsCovered)
		{
			ilist_0.Add(edge);
			directedEdge_0.VisitedEdge = true;
		}
	}

	public virtual void CollectBoundaryTouchEdge(DirectedEdge directedEdge_0, SpatialFunction spatialFunction_0, IList ilist_0)
	{
		Label label = directedEdge_0.Label;
		if (!directedEdge_0.IsLineEdge && !directedEdge_0.IsVisited && !directedEdge_0.IsInteriorAreaEdge && !directedEdge_0.Edge.IsInResult)
		{
			Assert.IsTrue((!directedEdge_0.IsInResult && !directedEdge_0.Sym.IsInResult) || !directedEdge_0.Edge.IsInResult);
			if (OverlayOp.IsResultOfOp(label, spatialFunction_0) && spatialFunction_0 == SpatialFunction.Intersection)
			{
				ilist_0.Add(directedEdge_0.Edge);
				directedEdge_0.VisitedEdge = true;
			}
		}
	}

	private void LoginInstance(SpatialFunction spatialFunction_0)
	{
		IEnumerator enumerator = m_ClassRule.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			ILineString value = _InvocationRule.CreateLineString(edge.Coordinates);
			tokenizerRule.Add(value);
			edge.IsInResult = true;
		}
	}

	private void GetInstance(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			Label label = edge.Label;
			if (edge.IsIsolated)
			{
				if (label.IsNull(0))
				{
					WriteInstance(edge, 0);
				}
				else
				{
					WriteInstance(edge, 1);
				}
			}
		}
	}

	private void WriteInstance(Edge edge_0, int int_0)
	{
		LocationType locationType_ = valueRule.Locate(edge_0.Coordinate, requestRule.GetArgGeometry(int_0));
		edge_0.Label.SetLocation(int_0, locationType_);
	}
}
