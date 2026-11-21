using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Noding;
using DotSpatial.Topology.Operation.Overlay;

namespace DotSpatial.Topology.Operation.Buffer;

public class BufferBuilder
{
	private readonly EdgeList serverRule = new EdgeList();

	private BufferStyle _AdapterRule = BufferStyle.CapRound;

	private IGeometryFactory schemaRule;

	private PlanarGraph _UtilsRule;

	private int _PredicateRule = 8;

	private PrecisionModel _SingletonRule;

	public virtual int QuadrantSegments
	{
		get
		{
			return _PredicateRule;
		}
		set
		{
			_PredicateRule = value;
		}
	}

	public virtual PrecisionModel WorkingPrecisionModel
	{
		get
		{
			return _SingletonRule;
		}
		set
		{
			_SingletonRule = value;
		}
	}

	public virtual BufferStyle EndCapStyle
	{
		get
		{
			return _AdapterRule;
		}
		set
		{
			_AdapterRule = value;
		}
	}

	private static int QueryInstance(Label label_0)
	{
		LocationType location = label_0.GetLocation(0, PositionType.Left);
		LocationType location2 = label_0.GetLocation(0, PositionType.Right);
		if (location == LocationType.Interior && location2 == LocationType.Exterior)
		{
			return 1;
		}
		if (location == LocationType.Exterior && location2 == LocationType.Interior)
		{
			return -1;
		}
		return 0;
	}

	public IGeometry Buffer(IGeometry igeometry_0, double double_0)
	{
		PrecisionModel precisionModel_ = _SingletonRule ?? new PrecisionModel(igeometry_0.PrecisionModel);
		schemaRule = igeometry_0.Factory;
		OffsetCurveBuilder offsetCurveBuilder = new OffsetCurveBuilder(precisionModel_, _PredicateRule);
		offsetCurveBuilder.EndCapStyle = _AdapterRule;
		IList curves = new OffsetCurveSetBuilder(igeometry_0, double_0, offsetCurveBuilder).GetCurves();
		if (curves.Count <= 0)
		{
			IGeometryFactory geometryFactory = schemaRule;
			IGeometry[] array2 = new Geometry[0];
			IGeometry[] array = array2;
			IGeometry[] igeometry_ = array;
			return geometryFactory.CreateGeometryCollection(igeometry_);
		}
		MapInstance(curves, precisionModel_);
		_UtilsRule = new PlanarGraph(new OverlayNodeFactory());
		_UtilsRule.AddEdges(serverRule.Edges);
		IList ienumerable_ = SortInstance(_UtilsRule);
		PolygonBuilder polygonBuilder = new PolygonBuilder(schemaRule);
		CalcInstance(ienumerable_, polygonBuilder);
		IList polygons = polygonBuilder.Polygons;
		return schemaRule.BuildGeometry(polygons);
	}

	private static INoder ResetInstance(PrecisionModel precisionModel_0)
	{
		return new McIndexNoder(new IntersectionAdder(new RobustLineIntersector
		{
			PrecisionModel = precisionModel_0
		}));
	}

	private void MapInstance(IList ilist_0, PrecisionModel precisionModel_0)
	{
		INoder noder = ResetInstance(precisionModel_0);
		noder.ComputeNodes(ilist_0);
		foreach (SegmentString nodedSubstring in noder.GetNodedSubstrings())
		{
			Label label_ = new Label((Label)nodedSubstring.Data);
			Edge edge_ = new Edge(nodedSubstring.Coordinates, label_);
			InsertEdge(edge_);
		}
	}

	protected void InsertEdge(Edge edge_0)
	{
		Edge edge = serverRule.FindEqualEdge(edge_0);
		if (edge == null)
		{
			serverRule.Add(edge_0);
			edge_0.DepthDelta = QueryInstance(edge_0.Label);
			return;
		}
		Label label = edge.Label;
		Label label2 = edge_0.Label;
		if (!edge.IsPointwiseEqual(edge_0))
		{
			label2 = new Label(edge_0.Label);
			label2.Flip();
		}
		label.Merge(label2);
		int num = QueryInstance(label2);
		edge.DepthDelta += num;
	}

	private static IList SortInstance(PlanarGraph planarGraph_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (Node node in planarGraph_0.Nodes)
		{
			if (!node.IsVisited)
			{
				BufferSubgraph bufferSubgraph = new BufferSubgraph();
				bufferSubgraph.Create(node);
				arrayList.Add(bufferSubgraph);
			}
		}
		arrayList.Sort();
		arrayList.Reverse();
		return arrayList;
	}

	private static void CalcInstance(IEnumerable ienumerable_0, PolygonBuilder polygonBuilder_0)
	{
		IList list = new ArrayList();
		foreach (BufferSubgraph item in ienumerable_0)
		{
			Coordinate rightMostCoordinate = item.RightMostCoordinate;
			int depth = new SubgraphDepthLocater(list).GetDepth(rightMostCoordinate);
			item.ComputeDepth(depth);
			item.FindResultEdges();
			list.Add(item);
			polygonBuilder_0.Add(item.DirectedEdges, item.Nodes);
		}
	}
}
