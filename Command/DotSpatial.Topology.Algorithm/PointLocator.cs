using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Algorithm;

public class PointLocator
{
	private bool processObject;

	private int _ThreadObject;

	public virtual bool Intersects(Coordinate coordinate_0, IGeometry igeometry_0)
	{
		return Locate(coordinate_0, igeometry_0) != LocationType.Exterior;
	}

	public virtual LocationType Locate(Coordinate coordinate_0, IGeometry igeometry_0)
	{
		if (igeometry_0.IsEmpty)
		{
			return LocationType.Exterior;
		}
		if (igeometry_0 is ILineString)
		{
			return CalculateExpression(coordinate_0, (ILineString)igeometry_0);
		}
		if (igeometry_0 is IPolygon)
		{
			return InstantiateExpression(coordinate_0, (IPolygon)igeometry_0);
		}
		processObject = false;
		_ThreadObject = 0;
		SetExpression(coordinate_0, igeometry_0);
		if (GeometryGraph.IsInBoundary(_ThreadObject))
		{
			return LocationType.Boundary;
		}
		if (_ThreadObject <= 0 && !processObject)
		{
			return LocationType.Exterior;
		}
		return LocationType.Interior;
	}

	private void SetExpression(Coordinate coordinate_0, IGeometry igeometry_0)
	{
		if (igeometry_0 is ILineString)
		{
			FillExpression(Locate(coordinate_0, igeometry_0));
		}
		else if (igeometry_0 is IPolygon)
		{
			FillExpression(Locate(coordinate_0, igeometry_0));
		}
		else if (igeometry_0 is IMultiLineString)
		{
			IGeometry[] geometries = ((IMultiLineString)igeometry_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				ILineString igeometry_ = (ILineString)geometries[i];
				FillExpression(Locate(coordinate_0, igeometry_));
			}
		}
		else if (igeometry_0 is IMultiPolygon)
		{
			IGeometry[] geometries2 = ((IMultiPolygon)igeometry_0).Geometries;
			for (int j = 0; j < geometries2.Length; j++)
			{
				IPolygon igeometry_2 = (IPolygon)geometries2[j];
				FillExpression(Locate(coordinate_0, igeometry_2));
			}
		}
		else
		{
			if (!(igeometry_0 is GInterface3))
			{
				return;
			}
			IEnumerator enumerator = new GeometryCollection.Enumerator((GInterface3)igeometry_0);
			while (enumerator.MoveNext())
			{
				IGeometry geometry = (IGeometry)enumerator.Current;
				if (geometry != igeometry_0)
				{
					SetExpression(coordinate_0, geometry);
				}
			}
		}
	}

	private void FillExpression(LocationType locationType_0)
	{
		if (locationType_0 == LocationType.Interior)
		{
			processObject = true;
		}
		if (locationType_0 == LocationType.Boundary)
		{
			_ThreadObject++;
		}
	}

	private static LocationType CalculateExpression(Coordinate coordinate_0, object object_0)
	{
		IList<Coordinate> coordinates = ((IBasicGeometry)object_0).Coordinates;
		if (!((ILineString)object_0).IsClosed && (coordinate_0.Equals(coordinates[0]) || coordinate_0.Equals(coordinates[coordinates.Count - 1])))
		{
			return LocationType.Boundary;
		}
		if (CgAlgorithms.IsOnLine(coordinate_0, coordinates))
		{
			return LocationType.Interior;
		}
		return LocationType.Exterior;
	}

	private static LocationType PopExpression(Coordinate coordinate_0, IBasicGeometry ibasicGeometry_0)
	{
		if (CgAlgorithms.IsOnLine(coordinate_0, ibasicGeometry_0.Coordinates))
		{
			return LocationType.Boundary;
		}
		if (CgAlgorithms.IsPointInRing(coordinate_0, ibasicGeometry_0.Coordinates))
		{
			return LocationType.Interior;
		}
		return LocationType.Exterior;
	}

	private static LocationType InstantiateExpression(Coordinate coordinate_0, object object_0)
	{
		if (((IGeometry)object_0).IsEmpty)
		{
			return LocationType.Exterior;
		}
		LinearRing ibasicGeometry_ = (LinearRing)((IPolygon)object_0).Shell;
		switch (PopExpression(coordinate_0, ibasicGeometry_))
		{
		default:
		{
			ILinearRing[] holes = ((IPolygon)object_0).Holes;
			for (int i = 0; i < holes.Length; i++)
			{
				LinearRing ibasicGeometry_2 = (LinearRing)holes[i];
				switch (PopExpression(coordinate_0, ibasicGeometry_2))
				{
				case LocationType.Boundary:
					return LocationType.Boundary;
				case LocationType.Interior:
					return LocationType.Exterior;
				}
			}
			return LocationType.Interior;
		}
		case LocationType.Exterior:
			return LocationType.Exterior;
		case LocationType.Boundary:
			return LocationType.Boundary;
		}
	}
}
