using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DotSpatial.Topology.Algorithm;

public class CentroidArea
{
	private readonly Coordinate _SystemInstance = new Coordinate(0.0, 0.0, 0.0, 0.0);

	private double candidateInstance;

	private Coordinate m_BaseInstance;

	public virtual Coordinate Centroid => new Coordinate
	{
		X = _SystemInstance.X / 3.0 / candidateInstance,
		Y = _SystemInstance.Y / 3.0 / candidateInstance
	};

	[SpecialName]
	private void DeleteExpression(Coordinate coordinate_0)
	{
		m_BaseInstance = coordinate_0;
	}

	public virtual void Add(IGeometry igeometry_0)
	{
		if (igeometry_0 is Polygon)
		{
			Polygon polygon = igeometry_0 as Polygon;
			DeleteExpression(polygon.Shell.Coordinates[0]);
			Add(polygon);
		}
		else if (igeometry_0 is GeometryCollection)
		{
			IGeometry[] geometries = (igeometry_0 as GeometryCollection).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				Geometry igeometry_ = (Geometry)geometries[i];
				Add(igeometry_);
			}
		}
	}

	public virtual void Add(Coordinate[] coordinate_0)
	{
		DeleteExpression(coordinate_0[0]);
		CountExpression(coordinate_0);
	}

	private void Add(IPolygon ipolygon_0)
	{
		CountExpression(ipolygon_0.Shell.Coordinates);
		ILinearRing[] holes = ipolygon_0.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LineString lineString = (LineString)holes[i];
			CustomizeExpression(lineString.Coordinates);
		}
	}

	private void CountExpression(IList<Coordinate> ilist_0)
	{
		bool bool_ = !CgAlgorithms.IsCounterClockwise(ilist_0);
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			CloneExpression(m_BaseInstance, ilist_0[i], ilist_0[i + 1], bool_);
		}
	}

	private void CustomizeExpression(IList<Coordinate> ilist_0)
	{
		bool bool_ = CgAlgorithms.IsCounterClockwise(ilist_0);
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			CloneExpression(m_BaseInstance, ilist_0[i], ilist_0[i + 1], bool_);
		}
	}

	private void CloneExpression(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, bool bool_0)
	{
		double num = (bool_0 ? 1.0 : (-1.0));
		ConnectExpression(coordinate_0, coordinate_1, coordinate_2, out var coordinate_3);
		double num2 = MoveExpression(coordinate_0, coordinate_1, coordinate_2);
		_SystemInstance.X += num * num2 * coordinate_3.X;
		_SystemInstance.Y += num * num2 * coordinate_3.Y;
		candidateInstance += num * num2;
	}

	private static void ConnectExpression(object object_0, object object_1, object object_2, out Coordinate coordinate_0)
	{
		coordinate_0 = new Coordinate();
		coordinate_0.X = ((Coordinate)object_0).X + ((Coordinate)object_1).X + ((Coordinate)object_2).X;
		coordinate_0.Y = ((Coordinate)object_0).Y + ((Coordinate)object_1).Y + ((Coordinate)object_2).Y;
	}

	private static double MoveExpression(object object_0, object object_1, object object_2)
	{
		return (((Coordinate)object_1).X - ((Coordinate)object_0).X) * (((Coordinate)object_2).Y - ((Coordinate)object_0).Y) - (((Coordinate)object_2).X - ((Coordinate)object_0).X) * (((Coordinate)object_1).Y - ((Coordinate)object_0).Y);
	}
}
