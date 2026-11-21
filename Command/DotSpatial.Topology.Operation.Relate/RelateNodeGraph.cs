using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateNodeGraph
{
	private readonly NodeMap m_StateThread = new NodeMap(new RelateNodeFactory());

	public virtual IEnumerator GetNodeEnumerator()
	{
		return m_StateThread.GetEnumerator();
	}

	public virtual void Build(GeometryGraph geometryGraph_0)
	{
		ComputeIntersectionNodes(geometryGraph_0, 0);
		CopyNodesAndLabels(geometryGraph_0, 0);
		IList ilist_ = new EdgeEndBuilder().ComputeEdgeEnds(geometryGraph_0.GetEdgeEnumerator());
		InsertEdgeEnds(ilist_);
	}

	public virtual void ComputeIntersectionNodes(GeometryGraph geometryGraph_0, int int_0)
	{
		IEnumerator edgeEnumerator = geometryGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			LocationType location = obj.Label.GetLocation(int_0);
			IEnumerator enumerator = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator.Current;
				RelateNode relateNode = (RelateNode)m_StateThread.AddNode(edgeIntersection.Coordinate);
				if (location == LocationType.Boundary)
				{
					relateNode.SetLabelBoundary(int_0);
				}
				else if (relateNode.Label.IsNull(int_0))
				{
					relateNode.SetLabel(int_0, LocationType.Interior);
				}
			}
		}
	}

	public virtual void CopyNodesAndLabels(GeometryGraph geometryGraph_0, int int_0)
	{
		IEnumerator nodeEnumerator = geometryGraph_0.GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			m_StateThread.AddNode(node.Coordinate).SetLabel(int_0, node.Label.GetLocation(int_0));
		}
	}

	public virtual void InsertEdgeEnds(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd edgeEnd_ = (EdgeEnd)enumerator.Current;
			m_StateThread.Add(edgeEnd_);
		}
	}
}
