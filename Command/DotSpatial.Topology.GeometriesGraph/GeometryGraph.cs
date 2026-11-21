using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph.Index;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public class GeometryGraph : PlanarGraph
{
	private readonly int filterInstance;

	private readonly IDictionary testsInstance = new Hashtable();

	private readonly IGeometry _InterpreterInstance;

	private ICollection containerInstance;

	private bool composerInstance;

	private Coordinate modelInstance;

	private bool _AdvisorInstance;

	public virtual bool HasTooFewPoints => composerInstance;

	public virtual Coordinate InvalidPoint => modelInstance;

	public virtual IGeometry Geometry => _InterpreterInstance;

	public virtual ICollection BoundaryNodes
	{
		get
		{
			if (containerInstance == null)
			{
				containerInstance = Nodes.GetBoundaryNodes(filterInstance);
			}
			return containerInstance;
		}
	}

	public GeometryGraph(int int_0, IGeometry igeometry_0)
	{
		filterInstance = int_0;
		_InterpreterInstance = igeometry_0;
		if (igeometry_0 != null)
		{
			Add(igeometry_0);
		}
	}

	public static bool IsInBoundary(int int_0)
	{
		return int_0 % 2 == 1;
	}

	public static LocationType DetermineBoundary(int int_0)
	{
		if (IsInBoundary(int_0))
		{
			return LocationType.Boundary;
		}
		return LocationType.Interior;
	}

	private static EdgeSetIntersector ListParameter()
	{
		return new SimpleMcSweepLineIntersector();
	}

	public virtual Coordinate[] GetBoundaryPoints()
	{
		ICollection boundaryNodes = BoundaryNodes;
		Coordinate[] array = new Coordinate[boundaryNodes.Count];
		int num = 0;
		IEnumerator enumerator = boundaryNodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			array[num++] = (Coordinate)node.Coordinate.Clone();
		}
		return array;
	}

	public virtual Edge FindEdge(ILineString ilineString_0)
	{
		return (Edge)testsInstance[ilineString_0];
	}

	public virtual void ComputeSplitEdges(IList ilist_0)
	{
		IEnumerator enumerator = base.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Edge)enumerator.Current).EdgeIntersectionList.AddSplitEdges(ilist_0);
		}
	}

	private void Add(IGeometry igeometry_0)
	{
		if (!igeometry_0.IsEmpty)
		{
			if (igeometry_0 is GeometryCollection && !(igeometry_0 is MultiPolygon))
			{
				_AdvisorInstance = true;
			}
			if (igeometry_0 is Polygon)
			{
				RunParameter((Polygon)igeometry_0);
			}
			else if (igeometry_0 is LineString)
			{
				StartParameter(igeometry_0);
			}
			else if (igeometry_0 is Point)
			{
				AddPoint(igeometry_0.Coordinate);
			}
			else
			{
				ResolveParameter(igeometry_0);
			}
		}
	}

	private void ResolveParameter(IGeometry igeometry_0)
	{
		for (int i = 0; i < igeometry_0.NumGeometries; i++)
		{
			IGeometry geometryN = igeometry_0.GetGeometryN(i);
			Add(geometryN);
		}
	}

	private void PostParameter(IBasicGeometry ibasicGeometry_0, LocationType locationType_0, LocationType locationType_1)
	{
		IList<Coordinate> list = CoordinateArrays.RemoveRepeatedPoints(ibasicGeometry_0.Coordinates);
		if (list.Count < 4)
		{
			composerInstance = true;
			modelInstance = list[0];
			return;
		}
		LocationType locationType_2 = locationType_0;
		LocationType locationType_3 = locationType_1;
		if (CgAlgorithms.IsCounterClockwise(list))
		{
			locationType_2 = locationType_1;
			locationType_3 = locationType_0;
		}
		Edge edge = new Edge(list, new Label(filterInstance, LocationType.Boundary, locationType_2, locationType_3));
		testsInstance.Add(ibasicGeometry_0, edge);
		InsertEdge(edge);
		AssetParameter(filterInstance, list[0], LocationType.Boundary);
	}

	private void RunParameter(Polygon polygon_0)
	{
		PostParameter(polygon_0.ExteriorRing, LocationType.Exterior, LocationType.Interior);
		for (int i = 0; i < polygon_0.NumHoles; i++)
		{
			PostParameter(polygon_0.GetInteriorRingN(i), LocationType.Interior, LocationType.Exterior);
		}
	}

	private void StartParameter(IBasicGeometry ibasicGeometry_0)
	{
		IList<Coordinate> list = CoordinateArrays.RemoveRepeatedPoints(ibasicGeometry_0.Coordinates);
		if (list.Count < 2)
		{
			composerInstance = true;
			modelInstance = list[0];
			return;
		}
		Edge edge = new Edge(list, new Label(filterInstance, LocationType.Interior));
		testsInstance.Add(ibasicGeometry_0, edge);
		InsertEdge(edge);
		Assert.IsTrue(list.Count >= 2, "found LineString with single point");
		PrintParameter(filterInstance, list[0]);
		PrintParameter(filterInstance, list[list.Count - 1]);
	}

	public virtual void AddEdge(Edge edge_0)
	{
		InsertEdge(edge_0);
		IList<Coordinate> coordinates = edge_0.Coordinates;
		AssetParameter(filterInstance, coordinates[0], LocationType.Boundary);
		AssetParameter(filterInstance, coordinates[coordinates.Count - 1], LocationType.Boundary);
	}

	public virtual void AddPoint(Coordinate coordinate_0)
	{
		AssetParameter(filterInstance, coordinate_0, LocationType.Interior);
	}

	public virtual SegmentIntersector ComputeSelfNodes(LineIntersector lineIntersector_0, bool bool_0)
	{
		SegmentIntersector segmentIntersector = new SegmentIntersector(lineIntersector_0, bool_0: true, bool_1: false);
		EdgeSetIntersector edgeSetIntersector = ListParameter();
		if (!bool_0 && (_InterpreterInstance is ILinearRing || _InterpreterInstance is IPolygon || _InterpreterInstance is IMultiPolygon))
		{
			edgeSetIntersector.ComputeIntersections(base.Edges, segmentIntersector, bool_0: false);
		}
		else
		{
			edgeSetIntersector.ComputeIntersections(base.Edges, segmentIntersector, bool_0: true);
		}
		DefineParameter(filterInstance);
		return segmentIntersector;
	}

	public virtual SegmentIntersector ComputeEdgeIntersections(GeometryGraph geometryGraph_0, LineIntersector lineIntersector_0, bool bool_0)
	{
		SegmentIntersector segmentIntersector = new SegmentIntersector(lineIntersector_0, bool_0, bool_1: true);
		segmentIntersector.SetBoundaryNodes(BoundaryNodes, geometryGraph_0.BoundaryNodes);
		ListParameter().ComputeIntersections(base.Edges, geometryGraph_0.Edges, segmentIntersector);
		return segmentIntersector;
	}

	private void AssetParameter(int int_0, Coordinate coordinate_0, LocationType locationType_0)
	{
		Node node = Nodes.AddNode(coordinate_0);
		Label label = node.Label;
		if (label == null)
		{
			node.Label = new Label(int_0, locationType_0);
		}
		else
		{
			label.SetLocation(int_0, locationType_0);
		}
	}

	private void PrintParameter(int int_0, Coordinate coordinate_0)
	{
		Label label = Nodes.AddNode(coordinate_0).Label;
		int num = 1;
		LocationType locationType = LocationType.Null;
		if (label != null)
		{
			locationType = label.GetLocation(int_0, PositionType.On);
		}
		if (locationType == LocationType.Boundary)
		{
			num++;
		}
		LocationType locationType_ = DetermineBoundary(num);
		label?.SetLocation(int_0, locationType_);
	}

	private void DefineParameter(int int_0)
	{
		IEnumerator enumerator = base.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge obj = (Edge)enumerator.Current;
			LocationType location = obj.Label.GetLocation(int_0);
			IEnumerator enumerator2 = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator2.Current;
				PublishParameter(int_0, edgeIntersection.Coordinate, location);
			}
		}
	}

	private void PublishParameter(int int_0, Coordinate coordinate_0, LocationType locationType_0)
	{
		if (!IsBoundaryNode(int_0, coordinate_0))
		{
			if (locationType_0 == LocationType.Boundary && _AdvisorInstance)
			{
				PrintParameter(int_0, coordinate_0);
			}
			else
			{
				AssetParameter(int_0, coordinate_0, locationType_0);
			}
		}
	}
}
