using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateComputer
{
	private readonly GeometryGraph[] m_AttributeThread;

	private readonly ArrayList m_EventThread = new ArrayList();

	private readonly LineIntersector globalThread = new RobustLineIntersector();

	private readonly NodeMap workerThread = new NodeMap(new RelateNodeFactory());

	private readonly PointLocator accountThread = new PointLocator();

	public RelateComputer(GeometryGraph[] geometryGraph_0)
	{
		m_AttributeThread = geometryGraph_0;
	}

	public virtual IntersectionMatrix ComputeIm()
	{
		IntersectionMatrix intersectionMatrix = new IntersectionMatrix();
		intersectionMatrix.Set(LocationType.Exterior, LocationType.Exterior, DimensionType.Surface);
		if (m_AttributeThread[0].Geometry.EnvelopeInternal.Intersects(m_AttributeThread[1].Geometry.EnvelopeInternal))
		{
			m_AttributeThread[0].ComputeSelfNodes(globalThread, bool_0: false);
			m_AttributeThread[1].ComputeSelfNodes(globalThread, bool_0: false);
			SegmentIntersector segmentIntersector_ = m_AttributeThread[0].ComputeEdgeIntersections(m_AttributeThread[1], globalThread, bool_0: false);
			CancelCollection(0);
			CancelCollection(1);
			StopCollection(0);
			StopCollection(1);
			StartCollection();
			TestCollection(segmentIntersector_, intersectionMatrix);
			EdgeEndBuilder edgeEndBuilder = new EdgeEndBuilder();
			IList ienumerable_ = edgeEndBuilder.ComputeEdgeEnds(m_AttributeThread[0].GetEdgeEnumerator());
			RestartCollection(ienumerable_);
			IList ienumerable_2 = edgeEndBuilder.ComputeEdgeEnds(m_AttributeThread[1].GetEdgeEnumerator());
			RestartCollection(ienumerable_2);
			ListCollection();
			PostCollection(0, 1);
			PostCollection(1, 0);
			ResolveCollection(intersectionMatrix);
			return intersectionMatrix;
		}
		VerifyCollection(intersectionMatrix);
		return intersectionMatrix;
	}

	private void RestartCollection(IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd edgeEnd_ = (EdgeEnd)enumerator.Current;
			workerThread.Add(edgeEnd_);
		}
	}

	private void TestCollection(SegmentIntersector segmentIntersector_0, GInterface4 ginterface4_0)
	{
		DimensionType dimension = m_AttributeThread[0].Geometry.Dimension;
		DimensionType dimension2 = m_AttributeThread[1].Geometry.Dimension;
		bool hasProperIntersection = segmentIntersector_0.HasProperIntersection;
		bool hasProperInteriorIntersection = segmentIntersector_0.HasProperInteriorIntersection;
		if (dimension == DimensionType.Surface && dimension2 == DimensionType.Surface)
		{
			if (hasProperIntersection)
			{
				ginterface4_0.SetAtLeast("212101212");
			}
		}
		else if (dimension == DimensionType.Surface && dimension2 == DimensionType.Curve)
		{
			if (hasProperIntersection)
			{
				ginterface4_0.SetAtLeast("FFF0FFFF2");
			}
			if (hasProperInteriorIntersection)
			{
				ginterface4_0.SetAtLeast("1FFFFF1FF");
			}
		}
		else if (dimension == DimensionType.Curve && dimension2 == DimensionType.Surface)
		{
			if (hasProperIntersection)
			{
				ginterface4_0.SetAtLeast("F0FFFFFF2");
			}
			if (hasProperInteriorIntersection)
			{
				ginterface4_0.SetAtLeast("1F1FFFFFF");
			}
		}
		else if (dimension == DimensionType.Curve && dimension2 == DimensionType.Curve && hasProperInteriorIntersection)
		{
			ginterface4_0.SetAtLeast("0FFFFFFFF");
		}
	}

	private void StopCollection(int int_0)
	{
		IEnumerator nodeEnumerator = m_AttributeThread[int_0].GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			workerThread.AddNode(node.Coordinate).SetLabel(int_0, node.Label.GetLocation(int_0));
		}
	}

	private void CancelCollection(int int_0)
	{
		IEnumerator edgeEnumerator = m_AttributeThread[int_0].GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			LocationType location = obj.Label.GetLocation(int_0);
			IEnumerator enumerator = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator.Current;
				RelateNode relateNode = (RelateNode)workerThread.AddNode(edgeIntersection.Coordinate);
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

	private void VerifyCollection(GInterface4 ginterface4_0)
	{
		IGeometry geometry = m_AttributeThread[0].Geometry;
		if (!geometry.IsEmpty)
		{
			ginterface4_0.Set(LocationType.Interior, LocationType.Exterior, geometry.Dimension);
			ginterface4_0.Set(LocationType.Boundary, LocationType.Exterior, geometry.BoundaryDimension);
		}
		IGeometry geometry2 = m_AttributeThread[1].Geometry;
		if (!geometry2.IsEmpty)
		{
			ginterface4_0.Set(LocationType.Exterior, LocationType.Interior, geometry2.Dimension);
			ginterface4_0.Set(LocationType.Exterior, LocationType.Boundary, geometry2.BoundaryDimension);
		}
	}

	private void ListCollection()
	{
		IEnumerator enumerator = workerThread.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((RelateNode)enumerator.Current).Edges.ComputeLabelling(m_AttributeThread);
		}
	}

	private void ResolveCollection(IntersectionMatrix intersectionMatrix_0)
	{
		IEnumerator enumerator = m_EventThread.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Edge)enumerator.Current).UpdateIm(intersectionMatrix_0);
		}
		IEnumerator enumerator2 = workerThread.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			RelateNode obj = (RelateNode)enumerator2.Current;
			obj.UpdateIm(intersectionMatrix_0);
			obj.UpdateImFromEdges(intersectionMatrix_0);
		}
	}

	private void PostCollection(int int_0, int int_1)
	{
		IEnumerator edgeEnumerator = m_AttributeThread[int_0].GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge edge = (Edge)edgeEnumerator.Current;
			if (edge.IsIsolated)
			{
				RunCollection(edge, int_1, m_AttributeThread[int_1].Geometry);
				m_EventThread.Add(edge);
			}
		}
	}

	private void RunCollection(GraphComponent graphComponent_0, int int_0, IGeometry igeometry_0)
	{
		if (igeometry_0.Dimension <= DimensionType.Point)
		{
			graphComponent_0.Label.SetAllLocations(int_0, LocationType.Exterior);
			return;
		}
		LocationType locationType_ = accountThread.Locate(graphComponent_0.Coordinate, igeometry_0);
		graphComponent_0.Label.SetAllLocations(int_0, locationType_);
	}

	private void StartCollection()
	{
		foreach (Node item in workerThread)
		{
			Label label = item.Label;
			Assert.IsTrue(label.GeometryCount > 0, "node with empty label found");
			if (item.IsIsolated)
			{
				AssetCollection(item, (!label.IsNull(0)) ? 1 : 0);
			}
		}
	}

	private void AssetCollection(GraphComponent graphComponent_0, int int_0)
	{
		LocationType locationType_ = accountThread.Locate(graphComponent_0.Coordinate, m_AttributeThread[int_0].Geometry);
		graphComponent_0.Label.SetAllLocations(int_0, locationType_);
	}
}
