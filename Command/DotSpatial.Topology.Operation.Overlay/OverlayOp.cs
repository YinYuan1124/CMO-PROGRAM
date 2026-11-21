using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Overlay;

public class OverlayOp : GeometryGraphOperation
{
	private readonly EdgeList stubRule = new EdgeList();

	private readonly IGeometryFactory m_WriterRule;

	private readonly PlanarGraph _SpecificationRule;

	private readonly PointLocator m_WatcherRule = new PointLocator();

	private IGeometry reponseRule;

	private IList descriptorRule = new ArrayList();

	private IList m_PoolRule = new ArrayList();

	private IList m_TaskRule = new ArrayList();

	public virtual PlanarGraph Graph => _SpecificationRule;

	public OverlayOp(IGeometry igeometry_0, IGeometry igeometry_1)
		: base(igeometry_0, igeometry_1)
	{
		_SpecificationRule = new PlanarGraph(new OverlayNodeFactory());
		m_WriterRule = igeometry_0.Factory;
	}

	public static IGeometry Overlay(IGeometry igeometry_0, IGeometry igeometry_1, SpatialFunction spatialFunction_0)
	{
		return new OverlayOp(igeometry_0, igeometry_1).GetResultGeometry(spatialFunction_0);
	}

	public static bool IsResultOfOp(Label label_0, SpatialFunction spatialFunction_0)
	{
		LocationType location = label_0.GetLocation(0);
		LocationType location2 = label_0.GetLocation(1);
		return IsResultOfOp(location, location2, spatialFunction_0);
	}

	public static bool IsResultOfOp(LocationType locationType_0, LocationType locationType_1, SpatialFunction spatialFunction_0)
	{
		if (locationType_0 == LocationType.Boundary)
		{
			locationType_0 = LocationType.Interior;
		}
		if (locationType_1 == LocationType.Boundary)
		{
			locationType_1 = LocationType.Interior;
		}
		switch (spatialFunction_0)
		{
		default:
			return false;
		case SpatialFunction.Intersection:
			if (locationType_0 == LocationType.Interior)
			{
				return locationType_1 == LocationType.Interior;
			}
			return false;
		case SpatialFunction.Union:
			if (locationType_0 == LocationType.Interior)
			{
				return true;
			}
			return locationType_1 == LocationType.Interior;
		case SpatialFunction.Difference:
			if (locationType_0 == LocationType.Interior)
			{
				return locationType_1 != LocationType.Interior;
			}
			return false;
		case SpatialFunction.SymDifference:
			if (locationType_0 == LocationType.Interior && locationType_1 != 0)
			{
				return true;
			}
			if (locationType_0 == LocationType.Interior)
			{
				return false;
			}
			return locationType_1 == LocationType.Interior;
		}
	}

	public IGeometry GetResultGeometry(SpatialFunction spatialFunction_0)
	{
		NewInstance(spatialFunction_0);
		return reponseRule;
	}

	private void NewInstance(SpatialFunction spatialFunction_0)
	{
		ExcludeInstance(0);
		ExcludeInstance(1);
		Arg[0].ComputeSelfNodes(base.LineIntersector, bool_0: false);
		Arg[1].ComputeSelfNodes(base.LineIntersector, bool_0: false);
		Arg[0].ComputeEdgeIntersections(Arg[1], base.LineIntersector, bool_0: true);
		IList list = new ArrayList();
		Arg[0].ComputeSplitEdges(list);
		Arg[1].ComputeSplitEdges(list);
		PushInstance(list);
		InvokeInstance();
		SetupInstance();
		_SpecificationRule.AddEdges(stubRule.Edges);
		IncludeInstance();
		ChangeInstance();
		CheckInstance(spatialFunction_0);
		ConcatInstance();
		PolygonBuilder polygonBuilder = new PolygonBuilder(m_WriterRule);
		polygonBuilder.Add(_SpecificationRule);
		m_TaskRule = polygonBuilder.Polygons;
		LineBuilder lineBuilder = new LineBuilder(this, m_WriterRule, m_WatcherRule);
		descriptorRule = lineBuilder.Build(spatialFunction_0);
		PointBuilder pointBuilder = new PointBuilder(this, m_WriterRule);
		m_PoolRule = pointBuilder.Build(spatialFunction_0);
		reponseRule = RemoveInstance(m_PoolRule, descriptorRule, m_TaskRule);
	}

	private void PushInstance(IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge_ = (Edge)enumerator.Current;
			InsertUniqueEdge(edge_);
		}
	}

	protected virtual void InsertUniqueEdge(Edge edge_0)
	{
		int num = stubRule.FindEdgeIndex(edge_0);
		if (num < 0)
		{
			stubRule.Add(edge_0);
			return;
		}
		Edge edge = stubRule[num];
		Label label = edge.Label;
		Label label2 = edge_0.Label;
		if (!edge.IsPointwiseEqual(edge_0))
		{
			label2 = new Label(edge_0.Label);
			label2.Flip();
		}
		Depth depth = edge.Depth;
		if (depth.IsNull())
		{
			depth.Add(label);
		}
		depth.Add(label2);
		label.Merge(label2);
	}

	private void InvokeInstance()
	{
		IEnumerator enumerator = stubRule.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge obj = (Edge)enumerator.Current;
			Label label = obj.Label;
			Depth depth = obj.Depth;
			if (depth.IsNull())
			{
				continue;
			}
			depth.Normalize();
			for (int i = 0; i < 2; i++)
			{
				if (!label.IsNull(i) && label.IsArea() && !depth.IsNull(i))
				{
					if (depth.GetDelta(i) == 0)
					{
						label.ToLine(i);
						continue;
					}
					Assert.IsTrue(!depth.IsNull(i, PositionType.Left), "depth of Left side has not been initialized");
					label.SetLocation(i, PositionType.Left, depth.GetLocation(i, PositionType.Left));
					Assert.IsTrue(!depth.IsNull(i, PositionType.Right), "depth of Right side has not been initialized");
					label.SetLocation(i, PositionType.Right, depth.GetLocation(i, PositionType.Right));
				}
			}
		}
	}

	private void SetupInstance()
	{
		IList list = new ArrayList();
		IList list2 = new ArrayList();
		IEnumerator enumerator = stubRule.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			if (edge.IsCollapsed)
			{
				list2.Add(enumerator.Current);
				list.Add(edge.CollapsedEdge);
			}
		}
		foreach (Edge item in list2)
		{
			stubRule.Remove(item);
		}
		foreach (object item2 in list)
		{
			stubRule.Add((Edge)item2);
		}
	}

	private void ExcludeInstance(int int_0)
	{
		IEnumerator nodeEnumerator = Arg[int_0].GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			_SpecificationRule.AddNode(node.Coordinate).SetLabel(int_0, node.Label.GetLocation(int_0));
		}
	}

	private void IncludeInstance()
	{
		IEnumerator enumerator = _SpecificationRule.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Node)enumerator.Current).Edges.ComputeLabelling(Arg);
		}
		SearchInstance();
		EnableInstance();
	}

	private void SearchInstance()
	{
		IEnumerator enumerator = _SpecificationRule.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).MergeSymLabels();
		}
	}

	private void EnableInstance()
	{
		IEnumerator enumerator = _SpecificationRule.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node obj = (Node)enumerator.Current;
			Label label = ((DirectedEdgeStar)obj.Edges).Label;
			obj.Label.Merge(label);
		}
	}

	private void ChangeInstance()
	{
		IEnumerator enumerator = _SpecificationRule.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			Label label = node.Label;
			if (node.IsIsolated)
			{
				if (label.IsNull(0))
				{
					InitInstance(node, 0);
				}
				else
				{
					InitInstance(node, 1);
				}
			}
			((DirectedEdgeStar)node.Edges).UpdateLabelling(label);
		}
	}

	private void InitInstance(Node node_0, int int_0)
	{
		LocationType locationType_ = m_WatcherRule.Locate(node_0.Coordinate, Arg[int_0].Geometry);
		node_0.Label.SetLocation(int_0, locationType_);
	}

	private void CheckInstance(SpatialFunction spatialFunction_0)
	{
		IEnumerator enumerator = _SpecificationRule.EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			Label label = directedEdge.Label;
			if (label.IsArea() && !directedEdge.IsInteriorAreaEdge && IsResultOfOp(label.GetLocation(0, PositionType.Right), label.GetLocation(1, PositionType.Right), spatialFunction_0))
			{
				directedEdge.IsInResult = true;
			}
		}
	}

	private void ConcatInstance()
	{
		IEnumerator enumerator = _SpecificationRule.EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			DirectedEdge sym = directedEdge.Sym;
			if (directedEdge.IsInResult && sym.IsInResult)
			{
				directedEdge.IsInResult = false;
				sym.IsInResult = false;
			}
		}
	}

	public virtual bool IsCoveredByLa(Coordinate coordinate_0)
	{
		if (InterruptInstance(coordinate_0, descriptorRule))
		{
			return true;
		}
		if (InterruptInstance(coordinate_0, m_TaskRule))
		{
			return true;
		}
		return false;
	}

	public virtual bool IsCoveredByA(Coordinate coordinate_0)
	{
		if (InterruptInstance(coordinate_0, m_TaskRule))
		{
			return true;
		}
		return false;
	}

	private bool InterruptInstance(Coordinate coordinate_0, IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		IGeometry igeometry_;
		do
		{
			if (enumerator.MoveNext())
			{
				igeometry_ = (IGeometry)enumerator.Current;
				continue;
			}
			return false;
		}
		while (m_WatcherRule.Locate(coordinate_0, igeometry_) == LocationType.Exterior);
		return true;
	}

	private IGeometry RemoveInstance(IList ilist_0, IList ilist_1, IList ilist_2)
	{
		ArrayList arrayList = new ArrayList();
		foreach (object item in ilist_0)
		{
			arrayList.Add(item);
		}
		foreach (object item2 in ilist_1)
		{
			arrayList.Add(item2);
		}
		foreach (object item3 in ilist_2)
		{
			arrayList.Add(item3);
		}
		return m_WriterRule.BuildGeometry(arrayList);
	}
}
