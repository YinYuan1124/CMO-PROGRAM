using System.Collections.Generic;

namespace DotSpatial.Topology.Operation.Predicate;

public class RectangleContains
{
	private readonly IEnvelope merchantRule;

	public RectangleContains(Polygon polygon_0)
	{
		merchantRule = polygon_0.EnvelopeInternal;
	}

	public static bool Contains(Polygon polygon_0, IGeometry igeometry_0)
	{
		return new RectangleContains(polygon_0).Contains(igeometry_0);
	}

	public bool Contains(IGeometry igeometry_0)
	{
		if (merchantRule.Contains(igeometry_0.EnvelopeInternal))
		{
			if (QueryCollection(igeometry_0))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private bool QueryCollection(IGeometry igeometry_0)
	{
		if (!(igeometry_0 is IPolygon) && !(igeometry_0 is IMultiPolygon))
		{
			if (igeometry_0 is IPoint)
			{
				return ResetCollection(igeometry_0.Coordinate);
			}
			if (igeometry_0 is ILineString)
			{
				return MapCollection(igeometry_0);
			}
			int num = 0;
			while (true)
			{
				if (num < igeometry_0.NumGeometries)
				{
					IGeometry geometryN = ((Geometry)igeometry_0).GetGeometryN(num);
					if (!QueryCollection(geometryN))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private bool ResetCollection(Coordinate coordinate_0)
	{
		if (coordinate_0.X != merchantRule.Minimum.X && coordinate_0.X != merchantRule.Maximum.X)
		{
			return false;
		}
		if (coordinate_0.Y != merchantRule.Minimum.Y && coordinate_0.Y != merchantRule.Maximum.Y)
		{
			return false;
		}
		return true;
	}

	private bool MapCollection(IBasicGeometry ibasicGeometry_0)
	{
		IList<Coordinate> coordinates = ibasicGeometry_0.Coordinates;
		int num = 0;
		while (true)
		{
			if (num < coordinates.Count - 1)
			{
				if (!SortCollection(coordinates[num], coordinates[num + 1]))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private bool SortCollection(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		if (coordinate_0.Equals(coordinate_1))
		{
			return ResetCollection(coordinate_0);
		}
		if (coordinate_0.X == coordinate_1.X)
		{
			if (coordinate_0.X == merchantRule.Minimum.X || coordinate_0.X == merchantRule.Maximum.X)
			{
				return true;
			}
		}
		else if (coordinate_0.Y == coordinate_1.Y && (coordinate_0.Y == merchantRule.Minimum.Y || coordinate_0.Y == merchantRule.Maximum.Y))
		{
			return true;
		}
		return false;
	}
}
