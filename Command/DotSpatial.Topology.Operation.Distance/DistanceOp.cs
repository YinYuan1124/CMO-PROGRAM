using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Distance;

public class DistanceOp
{
	private readonly IGeometry[] _StatusRule;

	private readonly PointLocator _ProccesorRule = new PointLocator();

	private readonly double strategyRule;

	private double m_ConfigurationRule = double.MaxValue;

	private GeometryLocation[] tokenRule;

	private DistanceOp(IGeometry igeometry_0, IGeometry igeometry_1)
		: this(igeometry_0, igeometry_1, 0.0)
	{
	}

	public DistanceOp(IGeometry igeometry_0, IGeometry igeometry_1, double double_0)
	{
		IGeometry[] array = new Geometry[2];
		IGeometry[] statusRule = array;
		_StatusRule = statusRule;
		_StatusRule[0] = igeometry_0;
		_StatusRule[1] = igeometry_1;
		strategyRule = double_0;
	}

	public static double Distance(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		return new DistanceOp(igeometry_0, igeometry_1).Distance();
	}

	public static bool IsWithinDistance(IGeometry igeometry_0, IGeometry igeometry_1, double double_0)
	{
		return new DistanceOp(igeometry_0, igeometry_1, double_0).Distance() <= double_0;
	}

	public static Coordinate[] ClosestPoints(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		return new DistanceOp(igeometry_0, igeometry_1).ClosestPoints();
	}

	public virtual double Distance()
	{
		ListInstance();
		return m_ConfigurationRule;
	}

	public virtual Coordinate[] ClosestPoints()
	{
		ListInstance();
		return new Coordinate[2]
		{
			tokenRule[0].Coordinate,
			tokenRule[1].Coordinate
		};
	}

	public virtual GeometryLocation[] ClosestLocations()
	{
		ListInstance();
		return tokenRule;
	}

	private void VerifyInstance(GeometryLocation[] geometryLocation_0, bool bool_0)
	{
		if (geometryLocation_0[0] != null)
		{
			if (bool_0)
			{
				tokenRule[0] = geometryLocation_0[1];
				tokenRule[1] = geometryLocation_0[0];
			}
			else
			{
				tokenRule[0] = geometryLocation_0[0];
				tokenRule[1] = geometryLocation_0[1];
			}
		}
	}

	private void ListInstance()
	{
		if (tokenRule == null)
		{
			tokenRule = new GeometryLocation[2];
			ResolveInstance();
			if (m_ConfigurationRule > strategyRule)
			{
				StartInstance();
			}
		}
	}

	private void ResolveInstance()
	{
		IList polygons = PolygonExtracter.GetPolygons(_StatusRule[0]);
		IList polygons2 = PolygonExtracter.GetPolygons(_StatusRule[1]);
		GeometryLocation[] array = new GeometryLocation[2];
		if (polygons2.Count > 0)
		{
			IList locations = ConnectedElementLocationFilter.GetLocations(_StatusRule[0]);
			PostInstance(locations, polygons2, array);
			if (m_ConfigurationRule <= strategyRule)
			{
				tokenRule[0] = array[0];
				tokenRule[1] = array[1];
				return;
			}
		}
		if (polygons.Count > 0)
		{
			IList locations2 = ConnectedElementLocationFilter.GetLocations(_StatusRule[1]);
			PostInstance(locations2, polygons, array);
			if (m_ConfigurationRule <= strategyRule)
			{
				tokenRule[0] = array[1];
				tokenRule[1] = array[0];
			}
		}
	}

	private void PostInstance(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			GeometryLocation geometryLocation_ = (GeometryLocation)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				Polygon igeometry_ = (Polygon)ilist_1[j];
				RunInstance(geometryLocation_, igeometry_, geometryLocation_0);
				if (!(m_ConfigurationRule > strategyRule))
				{
					return;
				}
			}
		}
	}

	private void RunInstance(GeometryLocation geometryLocation_0, IGeometry igeometry_0, GeometryLocation[] geometryLocation_1)
	{
		Coordinate coordinate = geometryLocation_0.Coordinate;
		if (LocationType.Exterior != _ProccesorRule.Locate(coordinate, igeometry_0))
		{
			m_ConfigurationRule = 0.0;
			geometryLocation_1[0] = geometryLocation_0;
			geometryLocation_1[1] = new GeometryLocation(igeometry_0, coordinate);
		}
	}

	private void StartInstance()
	{
		GeometryLocation[] array = new GeometryLocation[2];
		IList lines = LinearComponentExtracter.GetLines(_StatusRule[0]);
		IList lines2 = LinearComponentExtracter.GetLines(_StatusRule[1]);
		IList points = PointExtracter.GetPoints(_StatusRule[0]);
		IList points2 = PointExtracter.GetPoints(_StatusRule[1]);
		AssetInstance(lines, lines2, array);
		VerifyInstance(array, bool_0: false);
		if (m_ConfigurationRule <= strategyRule)
		{
			return;
		}
		array[0] = null;
		array[1] = null;
		DefineInstance(lines, points2, array);
		VerifyInstance(array, bool_0: false);
		if (m_ConfigurationRule > strategyRule)
		{
			array[0] = null;
			array[1] = null;
			DefineInstance(lines2, points, array);
			VerifyInstance(array, bool_0: true);
			if (m_ConfigurationRule > strategyRule)
			{
				array[0] = null;
				array[1] = null;
				PrintInstance(points, points2, array);
				VerifyInstance(array, bool_0: false);
			}
		}
	}

	private void AssetInstance(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LineString ilineString_ = (LineString)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				LineString ilineString_2 = (LineString)ilist_1[j];
				PublishInstance(ilineString_, ilineString_2, geometryLocation_0);
				if (!(m_ConfigurationRule > strategyRule))
				{
					return;
				}
			}
		}
	}

	private void PrintInstance(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Point point = (Point)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				Point point2 = (Point)ilist_1[j];
				double num = point.Coordinate.Distance(point2.Coordinate);
				if (num < m_ConfigurationRule)
				{
					m_ConfigurationRule = num;
					geometryLocation_0[0] = new GeometryLocation(point, 0, point.Coordinate);
					geometryLocation_0[1] = new GeometryLocation(point2, 0, point2.Coordinate);
				}
				if (!(m_ConfigurationRule > strategyRule))
				{
					return;
				}
			}
		}
	}

	private void DefineInstance(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LineString ilineString_ = (LineString)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				Point point_ = (Point)ilist_1[j];
				AwakeInstance(ilineString_, point_, geometryLocation_0);
				if (!(m_ConfigurationRule > strategyRule))
				{
					return;
				}
			}
		}
	}

	private void PublishInstance(ILineString ilineString_0, ILineString ilineString_1, GeometryLocation[] geometryLocation_0)
	{
		if (!(ilineString_0.EnvelopeInternal.Distance(ilineString_1.EnvelopeInternal) <= m_ConfigurationRule))
		{
			return;
		}
		IList<Coordinate> coordinates = ilineString_0.Coordinates;
		IList<Coordinate> coordinates2 = ilineString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				double num = CgAlgorithms.DistanceLineLine(coordinates[i], coordinates[i + 1], coordinates2[j], coordinates2[j + 1]);
				if (num < m_ConfigurationRule)
				{
					m_ConfigurationRule = num;
					LineSegment lineSegment = new LineSegment(coordinates[i], coordinates[i + 1]);
					LineSegment ilineSegmentBase_ = new LineSegment(coordinates2[j], coordinates2[j + 1]);
					Coordinate[] array = lineSegment.ClosestPoints(ilineSegmentBase_);
					geometryLocation_0[0] = new GeometryLocation(ilineString_0, i, new Coordinate(array[0]));
					geometryLocation_0[1] = new GeometryLocation(ilineString_1, j, new Coordinate(array[1]));
				}
				if (!(m_ConfigurationRule > strategyRule))
				{
					return;
				}
			}
		}
	}

	private void AwakeInstance(ILineString ilineString_0, Point point_0, GeometryLocation[] geometryLocation_0)
	{
		if (!(ilineString_0.EnvelopeInternal.Distance(point_0.EnvelopeInternal) <= m_ConfigurationRule))
		{
			return;
		}
		IList<Coordinate> coordinates = ilineString_0.Coordinates;
		Coordinate coordinate = point_0.Coordinate;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			double num = CgAlgorithms.DistancePointLine(coordinate, coordinates[i], coordinates[i + 1]);
			if (num < m_ConfigurationRule)
			{
				m_ConfigurationRule = num;
				Coordinate coordinate_ = new Coordinate(new LineSegment(coordinates[i], coordinates[i + 1]).ClosestPoint(coordinate));
				geometryLocation_0[0] = new GeometryLocation(ilineString_0, i, coordinate_);
				geometryLocation_0[1] = new GeometryLocation(point_0, 0, coordinate);
			}
			if (m_ConfigurationRule <= strategyRule)
			{
				break;
			}
		}
	}
}
