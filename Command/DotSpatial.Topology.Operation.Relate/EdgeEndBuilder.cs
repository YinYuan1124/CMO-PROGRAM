using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class EdgeEndBuilder
{
	public virtual IList ComputeEdgeEnds(IEnumerator ienumerator_0)
	{
		IList list = new ArrayList();
		while (ienumerator_0.MoveNext())
		{
			Edge edge_ = (Edge)ienumerator_0.Current;
			ComputeEdgeEnds(edge_, list);
		}
		return list;
	}

	public virtual void ComputeEdgeEnds(Edge edge_0, IList ilist_0)
	{
		EdgeIntersectionList edgeIntersectionList = edge_0.EdgeIntersectionList;
		edgeIntersectionList.AddEndpoints();
		IEnumerator enumerator = edgeIntersectionList.GetEnumerator();
		EdgeIntersection edgeIntersection = null;
		if (!enumerator.MoveNext())
		{
			return;
		}
		EdgeIntersection edgeIntersection2 = (EdgeIntersection)enumerator.Current;
		do
		{
			EdgeIntersection edgeIntersection_ = edgeIntersection;
			edgeIntersection = edgeIntersection2;
			edgeIntersection2 = null;
			if (enumerator.MoveNext())
			{
				edgeIntersection2 = (EdgeIntersection)enumerator.Current;
			}
			if (edgeIntersection != null)
			{
				CreateEdgeEndForPrev(edge_0, ilist_0, edgeIntersection, edgeIntersection_);
				CreateEdgeEndForNext(edge_0, ilist_0, edgeIntersection, edgeIntersection2);
			}
		}
		while (edgeIntersection != null);
	}

	public virtual void CreateEdgeEndForPrev(Edge edge_0, IList ilist_0, EdgeIntersection edgeIntersection_0, EdgeIntersection edgeIntersection_1)
	{
		int num = edgeIntersection_0.SegmentIndex;
		if (edgeIntersection_0.Distance == 0.0)
		{
			if (num == 0)
			{
				return;
			}
			num--;
		}
		Coordinate coordinate = edge_0.GetCoordinate(num);
		if (edgeIntersection_1 != null && edgeIntersection_1.SegmentIndex >= num)
		{
			coordinate = edgeIntersection_1.Coordinate;
		}
		Label label = new Label(edge_0.Label);
		label.Flip();
		EdgeEnd value = new EdgeEnd(edge_0, edgeIntersection_0.Coordinate, coordinate, label);
		ilist_0.Add(value);
	}

	public virtual void CreateEdgeEndForNext(Edge edge_0, IList ilist_0, EdgeIntersection edgeIntersection_0, EdgeIntersection edgeIntersection_1)
	{
		int num = edgeIntersection_0.SegmentIndex + 1;
		if (num < edge_0.NumPoints || edgeIntersection_1 != null)
		{
			Coordinate coordinate = edge_0.GetCoordinate(num);
			if (edgeIntersection_1 != null && edgeIntersection_1.SegmentIndex == edgeIntersection_0.SegmentIndex)
			{
				coordinate = edgeIntersection_1.Coordinate;
			}
			EdgeEnd value = new EdgeEnd(edge_0, edgeIntersection_0.Coordinate, coordinate, new Label(edge_0.Label));
			ilist_0.Add(value);
		}
	}
}
