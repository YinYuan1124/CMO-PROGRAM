using System.Collections.Generic;
using System.Linq;

namespace DotSpatial.Topology.Algorithm;

public class InteriorPointLine
{
	private readonly Coordinate m_InitializerInstance;

	private Coordinate m_RoleInstance;

	private double m_FactoryInstance = double.MaxValue;

	public virtual Coordinate InteriorPoint => m_RoleInstance;

	public InteriorPointLine(IGeometry igeometry_0)
	{
		m_InitializerInstance = new Coordinate(igeometry_0.Centroid);
		PushExpression(igeometry_0);
		if (m_RoleInstance == null)
		{
			SetupExpression(igeometry_0);
		}
	}

	private void PushExpression(IGeometry igeometry_0)
	{
		if (igeometry_0 is ILineString)
		{
			InvokeExpression(igeometry_0.Coordinates);
		}
		else if (igeometry_0 is GeometryCollection)
		{
			IGeometry[] geometries = ((GeometryCollection)igeometry_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				Geometry igeometry_ = (Geometry)geometries[i];
				PushExpression(igeometry_);
			}
		}
	}

	private void InvokeExpression(IEnumerable<Coordinate> ienumerable_0)
	{
		foreach (Coordinate item in ienumerable_0)
		{
			Add(item);
		}
	}

	private void SetupExpression(IGeometry igeometry_0)
	{
		if (igeometry_0 is LineString)
		{
			ExcludeExpression(igeometry_0.Coordinates);
		}
		else if (igeometry_0 is GeometryCollection)
		{
			IGeometry[] geometries = ((GeometryCollection)igeometry_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				Geometry igeometry_ = (Geometry)geometries[i];
				SetupExpression(igeometry_);
			}
		}
	}

	private void ExcludeExpression(IEnumerable<Coordinate> ienumerable_0)
	{
		Add(ienumerable_0.First());
		Add(ienumerable_0.Last());
	}

	private void Add(Coordinate coordinate_0)
	{
		double num = coordinate_0.Distance(m_InitializerInstance);
		if (num < m_FactoryInstance)
		{
			m_RoleInstance = new Coordinate(coordinate_0);
			m_FactoryInstance = num;
		}
	}
}
