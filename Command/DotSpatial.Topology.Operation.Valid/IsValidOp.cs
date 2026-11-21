using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Valid;

public class IsValidOp
{
	private readonly Geometry m_MethodThread;

	private bool serviceThread;

	private TopologyValidationError m_SystemThread;

	public bool IsSelfTouchingRingFormingHoleValid
	{
		get
		{
			return serviceThread;
		}
		set
		{
			serviceThread = value;
		}
	}

	public virtual bool IsValid
	{
		get
		{
			NewCollection(m_MethodThread);
			return m_SystemThread == null;
		}
	}

	public virtual TopologyValidationError ValidationError
	{
		get
		{
			NewCollection(m_MethodThread);
			return m_SystemThread;
		}
	}

	public IsValidOp(Geometry geometry_0)
	{
		m_MethodThread = geometry_0;
	}

	public static bool IsValidCoordinate(Coordinate coordinate_0)
	{
		if (double.IsNaN(coordinate_0.X))
		{
			return false;
		}
		if (double.IsInfinity(coordinate_0.X))
		{
			return false;
		}
		if (double.IsNaN(coordinate_0.Y))
		{
			return false;
		}
		if (double.IsInfinity(coordinate_0.Y))
		{
			return false;
		}
		return true;
	}

	public static Coordinate FindPointNotNode(IList<Coordinate> ilist_0, ILinearRing ilinearRing_0, GeometryGraph geometryGraph_0)
	{
		EdgeIntersectionList edgeIntersectionList = geometryGraph_0.FindEdge(ilinearRing_0).EdgeIntersectionList;
		foreach (Coordinate item in ilist_0)
		{
			if (!edgeIntersectionList.IsIntersection(item))
			{
				return item;
			}
		}
		return null;
	}

	private void NewCollection(IGeometry igeometry_0)
	{
		m_SystemThread = null;
		if (!igeometry_0.IsEmpty)
		{
			PushCollection(igeometry_0);
			if (igeometry_0 is ILineString)
			{
				InvokeCollection(igeometry_0);
			}
			if (igeometry_0 is ILinearRing ilinearRing_)
			{
				SetupCollection(ilinearRing_);
			}
			if (igeometry_0 is IPolygon ipolygon_)
			{
				ExcludeCollection(ipolygon_);
			}
			if (igeometry_0 is IMultiPolygon imultiPolygon_)
			{
				IncludeCollection(imultiPolygon_);
			}
			else if (igeometry_0 is GInterface3 ginterface3_)
			{
				SearchCollection(ginterface3_);
			}
		}
	}

	private void PushCollection(IBasicGeometry ibasicGeometry_0)
	{
		EnableCollection(ibasicGeometry_0.Coordinates);
	}

	private void InvokeCollection(IGeometry igeometry_0)
	{
		GeometryGraph geometryGraph_ = new GeometryGraph(0, igeometry_0);
		ConcatCollection(geometryGraph_);
	}

	private void SetupCollection(ILinearRing ilinearRing_0)
	{
		CheckCollection(ilinearRing_0);
		if (m_SystemThread == null)
		{
			GeometryGraph geometryGraph = new GeometryGraph(0, ilinearRing_0);
			LineIntersector lineIntersector_ = new RobustLineIntersector();
			geometryGraph.ComputeSelfNodes(lineIntersector_, bool_0: true);
			RemoveCollection(geometryGraph);
		}
	}

	private void ExcludeCollection(IPolygon ipolygon_0)
	{
		InitCollection(ipolygon_0);
		if (m_SystemThread != null)
		{
			return;
		}
		GeometryGraph geometryGraph_ = new GeometryGraph(0, ipolygon_0);
		InterruptCollection(geometryGraph_);
		if (m_SystemThread != null)
		{
			return;
		}
		if (!IsSelfTouchingRingFormingHoleValid)
		{
			RemoveCollection(geometryGraph_);
			if (m_SystemThread != null)
			{
				return;
			}
		}
		SetCollection(ipolygon_0, geometryGraph_);
		if (m_SystemThread == null)
		{
			FillCollection(ipolygon_0, geometryGraph_);
			if (m_SystemThread == null)
			{
				CreateCollection(geometryGraph_);
			}
		}
	}

	private void IncludeCollection(IMultiPolygon imultiPolygon_0)
	{
		IGeometry[] geometries = imultiPolygon_0.Geometries;
		for (int num = 0; num < geometries.Length; num++)
		{
			Polygon ipolygon_ = (Polygon)geometries[num];
			ChangeCollection(ipolygon_);
			if (m_SystemThread == null)
			{
				InitCollection(ipolygon_);
				if (m_SystemThread != null)
				{
					return;
				}
				continue;
			}
			return;
		}
		GeometryGraph geometryGraph_ = new GeometryGraph(0, imultiPolygon_0);
		ConcatCollection(geometryGraph_);
		if (m_SystemThread != null)
		{
			return;
		}
		InterruptCollection(geometryGraph_);
		if (m_SystemThread != null)
		{
			return;
		}
		if (!IsSelfTouchingRingFormingHoleValid)
		{
			RemoveCollection(geometryGraph_);
			if (m_SystemThread != null)
			{
				return;
			}
		}
		geometries = imultiPolygon_0.Geometries;
		for (int num = 0; num < geometries.Length; num++)
		{
			Polygon ipolygon_2 = (Polygon)geometries[num];
			SetCollection(ipolygon_2, geometryGraph_);
			if (m_SystemThread != null)
			{
				return;
			}
		}
		geometries = imultiPolygon_0.Geometries;
		for (int num = 0; num < geometries.Length; num++)
		{
			Polygon ipolygon_3 = (Polygon)geometries[num];
			FillCollection(ipolygon_3, geometryGraph_);
			if (m_SystemThread != null)
			{
				return;
			}
		}
		CalculateCollection(imultiPolygon_0, geometryGraph_);
		if (m_SystemThread == null)
		{
			CreateCollection(geometryGraph_);
		}
	}

	private void SearchCollection(GInterface3 ginterface3_0)
	{
		IGeometry[] geometries = ginterface3_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Geometry igeometry_ = (Geometry)geometries[i];
			NewCollection(igeometry_);
			if (m_SystemThread != null)
			{
				break;
			}
		}
	}

	private void EnableCollection(IEnumerable<Coordinate> ienumerable_0)
	{
		foreach (Coordinate item in ienumerable_0)
		{
			if (!IsValidCoordinate(item))
			{
				m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.InvalidCoordinate, item);
				break;
			}
		}
	}

	private void ChangeCollection(IPolygon ipolygon_0)
	{
		EnableCollection(ipolygon_0.Shell.Coordinates);
		if (m_SystemThread != null)
		{
			return;
		}
		ILinearRing[] holes = ipolygon_0.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LineString lineString = (LineString)holes[i];
			EnableCollection(lineString.Coordinates);
			if (m_SystemThread != null)
			{
				break;
			}
		}
	}

	private void InitCollection(IPolygon ipolygon_0)
	{
		CheckCollection(ipolygon_0.Shell);
		if (m_SystemThread != null)
		{
			return;
		}
		ILinearRing[] holes = ipolygon_0.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LineString lineString = (LineString)holes[i];
			CheckCollection((LinearRing)lineString);
			if (m_SystemThread != null)
			{
				break;
			}
		}
	}

	private void CheckCollection(ILinearRing ilinearRing_0)
	{
		if (!ilinearRing_0.IsClosed)
		{
			m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.RingNotClosed, ilinearRing_0.Coordinates[0]);
		}
	}

	private void ConcatCollection(GeometryGraph geometryGraph_0)
	{
		if (geometryGraph_0.HasTooFewPoints)
		{
			m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.TooFewPoints, geometryGraph_0.InvalidPoint);
		}
	}

	private void InterruptCollection(GeometryGraph geometryGraph_0)
	{
		ConsistentAreaTester consistentAreaTester = new ConsistentAreaTester(geometryGraph_0);
		if (consistentAreaTester.IsNodeConsistentArea)
		{
			if (consistentAreaTester.HasDuplicateRings)
			{
				m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.DuplicateRings, consistentAreaTester.InvalidPoint);
			}
		}
		else
		{
			m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.SelfIntersection, consistentAreaTester.InvalidPoint);
		}
	}

	private void RemoveCollection(GeometryGraph geometryGraph_0)
	{
		IEnumerator edgeEnumerator = geometryGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge edge = (Edge)edgeEnumerator.Current;
			FindCollection(edge.EdgeIntersectionList);
			if (m_SystemThread != null)
			{
				break;
			}
		}
	}

	private void FindCollection(EdgeIntersectionList edgeIntersectionList_0)
	{
		HashSet<Coordinate> hashSet = new HashSet<Coordinate>();
		bool flag = true;
		foreach (EdgeIntersection item in edgeIntersectionList_0)
		{
			if (flag)
			{
				flag = false;
				continue;
			}
			if (!hashSet.Contains(item.Coordinate))
			{
				hashSet.Add(item.Coordinate);
				continue;
			}
			m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.RingSelfIntersection, item.Coordinate);
			break;
		}
	}

	private void SetCollection(IPolygon ipolygon_0, GeometryGraph geometryGraph_0)
	{
		ILinearRing shell = ipolygon_0.Shell;
		IPointInRing pointInRing = new McPointInRing(shell);
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			Coordinate coordinate = FindPointNotNode(((LinearRing)ipolygon_0.GetInteriorRingN(i)).Coordinates, shell, geometryGraph_0);
			if (!(coordinate == null))
			{
				if (!pointInRing.IsInside(coordinate))
				{
					m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.HoleOutsideShell, coordinate);
					break;
				}
				continue;
			}
			break;
		}
	}

	private void FillCollection(IPolygon ipolygon_0, GeometryGraph geometryGraph_0)
	{
		QuadtreeNestedRingTester quadtreeNestedRingTester = new QuadtreeNestedRingTester(geometryGraph_0);
		ILinearRing[] holes = ipolygon_0.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LinearRing linearRing_ = (LinearRing)holes[i];
			quadtreeNestedRingTester.Add(linearRing_);
		}
		if (!quadtreeNestedRingTester.IsNonNested())
		{
			m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.NestedHoles, quadtreeNestedRingTester.NestedPoint);
		}
	}

	private void CalculateCollection(IGeometry igeometry_0, GeometryGraph geometryGraph_0)
	{
		for (int i = 0; i < igeometry_0.NumGeometries; i++)
		{
			LinearRing linearRing_ = (LinearRing)((Polygon)igeometry_0.GetGeometryN(i)).ExteriorRing;
			for (int j = 0; j < igeometry_0.NumGeometries; j++)
			{
				if (i != j)
				{
					Polygon polygon_ = (Polygon)igeometry_0.GetGeometryN(j);
					PopCollection(linearRing_, polygon_, geometryGraph_0);
					if (m_SystemThread != null)
					{
						return;
					}
				}
			}
		}
	}

	private void PopCollection(LinearRing linearRing_0, Polygon polygon_0, GeometryGraph geometryGraph_0)
	{
		IList<Coordinate> coordinates = linearRing_0.Coordinates;
		LinearRing linearRing = (LinearRing)polygon_0.ExteriorRing;
		IList<Coordinate> coordinates2 = linearRing.Coordinates;
		Coordinate coordinate = FindPointNotNode(coordinates, linearRing, geometryGraph_0);
		if (!(coordinate != null) || !CgAlgorithms.IsPointInRing(coordinate, coordinates2))
		{
			return;
		}
		if (polygon_0.NumHoles <= 0)
		{
			m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.NestedShells, coordinate);
			return;
		}
		Coordinate coordinate2 = null;
		for (int num = 0; num < polygon_0.NumHoles; num++)
		{
			LinearRing object_ = (LinearRing)polygon_0.GetInteriorRingN(num);
			coordinate2 = InstantiateCollection(linearRing_0, object_, geometryGraph_0);
			if (coordinate2 == null)
			{
				return;
			}
		}
		m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.NestedShells, coordinate2);
	}

	private static Coordinate InstantiateCollection(object object_0, object object_1, GeometryGraph geometryGraph_0)
	{
		IList<Coordinate> coordinates = ((Geometry)object_0).Coordinates;
		IList<Coordinate> coordinates2 = ((Geometry)object_1).Coordinates;
		Coordinate coordinate = FindPointNotNode(coordinates, (ILinearRing)object_1, geometryGraph_0);
		if (!(coordinate == null) && !CgAlgorithms.IsPointInRing(coordinate, coordinates2))
		{
			return coordinate;
		}
		Coordinate coordinate2 = FindPointNotNode(coordinates2, (ILinearRing)object_0, geometryGraph_0);
		if (coordinate2 == null)
		{
			throw new ShellHoleIdentityException();
		}
		if (CgAlgorithms.IsPointInRing(coordinate2, coordinates))
		{
			return coordinate2;
		}
		return null;
	}

	private void CreateCollection(GeometryGraph geometryGraph_0)
	{
		ConnectedInteriorTester connectedInteriorTester = new ConnectedInteriorTester(geometryGraph_0);
		if (!connectedInteriorTester.IsInteriorsConnected())
		{
			m_SystemThread = new TopologyValidationError(TopologyValidationErrorType.DisconnectedInteriors, connectedInteriorTester.Coordinate);
		}
	}
}
