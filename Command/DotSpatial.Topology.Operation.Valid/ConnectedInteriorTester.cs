using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Operation.Overlay;
using DotSpatial.Topology.Operation.Polygonize;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class ConnectedInteriorTester
{
	private readonly GeometryGraph m_TagThread;

	private readonly GeometryFactory _FieldThread = new GeometryFactory();

	private Coordinate queueThread;

	public Coordinate Coordinate => queueThread;

	public ConnectedInteriorTester(GeometryGraph geometryGraph_0)
	{
		m_TagThread = geometryGraph_0;
	}

	private static Coordinate PatchCollection(IEnumerable<Coordinate> ienumerable_0, object object_0)
	{
		foreach (Coordinate item in ienumerable_0)
		{
			if (!item.Equals(object_0))
			{
				return item;
			}
		}
		return null;
	}

	public bool IsInteriorsConnected()
	{
		IList ilist_ = new ArrayList();
		m_TagThread.ComputeSplitEdges(ilist_);
		PlanarGraph planarGraph = new PlanarGraph(new OverlayNodeFactory());
		planarGraph.AddEdges(ilist_);
		SelectCollection(planarGraph);
		planarGraph.LinkResultDirectedEdges();
		IList ilist_2 = CallCollection(planarGraph.EdgeEnds);
		LogoutCollection(m_TagThread.Geometry, planarGraph);
		return !LoginCollection(ilist_2);
	}

	private static void SelectCollection(PlanarGraph planarGraph_0)
	{
		foreach (DirectedEdge edgeEnd in planarGraph_0.EdgeEnds)
		{
			if (edgeEnd.Label.GetLocation(0, PositionType.Right) == LocationType.Interior)
			{
				edgeEnd.IsInResult = true;
			}
		}
	}

	private IList CallCollection(IList ilist_0)
	{
		IList list = new ArrayList();
		foreach (DirectedEdge item in ilist_0)
		{
			if (!item.IsInResult || item.EdgeRing != null)
			{
				continue;
			}
			MaximalEdgeRing maximalEdgeRing = new MaximalEdgeRing(item, _FieldThread);
			maximalEdgeRing.LinkDirectedEdgesForMinimalEdgeRings();
			foreach (object item2 in maximalEdgeRing.BuildMinimalRings())
			{
				list.Add(item2);
			}
		}
		return list;
	}

	private static void LogoutCollection(object object_0, PlanarGraph planarGraph_0)
	{
		if (object_0 is Polygon)
		{
			ViewCollection(((Polygon)object_0).Shell, planarGraph_0);
		}
		if (object_0 is MultiPolygon)
		{
			IGeometry[] geometries = ((MultiPolygon)object_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				ViewCollection(((Polygon)geometries[i]).Shell, planarGraph_0);
			}
		}
	}

	private static void ViewCollection(IBasicGeometry ibasicGeometry_0, PlanarGraph planarGraph_0)
	{
		IList<Coordinate> coordinates = ibasicGeometry_0.Coordinates;
		Coordinate coordinate = coordinates[0];
		Coordinate coordinate_ = PatchCollection(coordinates, coordinate);
		Edge edge_ = planarGraph_0.FindEdgeInSameDirection(coordinate, coordinate_);
		DirectedEdge directedEdge = (DirectedEdge)planarGraph_0.FindEdgeEnd(edge_);
		DirectedEdge directedEdge2 = null;
		if (directedEdge.Label.GetLocation(0, PositionType.Right) == LocationType.Interior)
		{
			directedEdge2 = directedEdge;
		}
		else if (directedEdge.Sym.Label.GetLocation(0, PositionType.Right) == LocationType.Interior)
		{
			directedEdge2 = directedEdge.Sym;
		}
		Assert.IsTrue(directedEdge2 != null, "unable to find dirEdge with Interior on RHS");
		ValidateCollection(directedEdge2);
	}

	private static void ValidateCollection(DirectedEdge directedEdge_0)
	{
		DirectedEdge directedEdge = directedEdge_0;
		while (directedEdge != null)
		{
			directedEdge.IsVisited = true;
			directedEdge = directedEdge.Next;
			if (directedEdge == directedEdge_0)
			{
				return;
			}
		}
		throw new NullEdgeException();
	}

	private bool LoginCollection(IList ilist_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			DotSpatial.Topology.GeometriesGraph.EdgeRing edgeRing = (DotSpatial.Topology.GeometriesGraph.EdgeRing)ilist_0[i];
			if (edgeRing.IsHole)
			{
				continue;
			}
			IList edges = edgeRing.Edges;
			DirectedEdge directedEdge = (DirectedEdge)edges[0];
			if (directedEdge.Label.GetLocation(0, PositionType.Right) != 0)
			{
				continue;
			}
			for (int j = 0; j < edges.Count; j++)
			{
				directedEdge = (DirectedEdge)edges[j];
				if (!directedEdge.IsVisited)
				{
					queueThread = directedEdge.Coordinate;
					return true;
				}
			}
		}
		return false;
	}
}
