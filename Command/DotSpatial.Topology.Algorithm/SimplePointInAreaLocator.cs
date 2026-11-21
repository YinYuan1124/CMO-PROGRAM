using System.Collections;

namespace DotSpatial.Topology.Algorithm;

public class SimplePointInAreaLocator
{
	private SimplePointInAreaLocator()
	{
	}

	public static LocationType Locate(Coordinate coordinate_0, IGeometry igeometry_0)
	{
		if (igeometry_0.IsEmpty)
		{
			return LocationType.Exterior;
		}
		if (UpdateExpression(coordinate_0, igeometry_0))
		{
			return LocationType.Interior;
		}
		return LocationType.Exterior;
	}

	private static bool UpdateExpression(Coordinate coordinate_0, object object_0)
	{
		if (object_0 is Polygon)
		{
			return ContainsPointInPolygon(coordinate_0, (Polygon)object_0);
		}
		if (object_0 is GeometryCollection)
		{
			IEnumerator enumerator = new GeometryCollection.Enumerator((GeometryCollection)object_0);
			while (enumerator.MoveNext())
			{
				Geometry geometry = (Geometry)enumerator.Current;
				if (geometry != object_0 && UpdateExpression(coordinate_0, geometry))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool ContainsPointInPolygon(Coordinate coordinate_0, IPolygon ipolygon_0)
	{
		if (ipolygon_0.IsEmpty)
		{
			return false;
		}
		LinearRing linearRing = (LinearRing)ipolygon_0.Shell;
		if (CgAlgorithms.IsPointInRing(coordinate_0, linearRing.Coordinates))
		{
			for (int i = 0; i < ipolygon_0.NumHoles; i++)
			{
				LinearRing linearRing2 = (LinearRing)ipolygon_0.GetInteriorRingN(i);
				if (CgAlgorithms.IsPointInRing(coordinate_0, linearRing2.Coordinates))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
