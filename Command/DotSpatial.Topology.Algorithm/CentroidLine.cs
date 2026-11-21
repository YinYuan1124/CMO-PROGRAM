using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public class CentroidLine
{
	private readonly Coordinate policyInstance = new Coordinate(0.0, 0.0, 0.0, 0.0);

	private double broadcasterInstance;

	public virtual Coordinate Centroid => new Coordinate
	{
		X = policyInstance.X / broadcasterInstance,
		Y = policyInstance.Y / broadcasterInstance
	};

	public virtual void Add(IGeometry igeometry_0)
	{
		if (igeometry_0 is LineString)
		{
			Add(igeometry_0.Coordinates);
		}
		else if (igeometry_0 is GeometryCollection)
		{
			IGeometry[] geometries = ((GeometryCollection)igeometry_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				Geometry igeometry_ = (Geometry)geometries[i];
				Add(igeometry_);
			}
		}
	}

	public virtual void Add(IList<Coordinate> ilist_0)
	{
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			double num = ilist_0[i].Distance(ilist_0[i + 1]);
			broadcasterInstance += num;
			double num2 = (ilist_0[i].X + ilist_0[i + 1].X) / 2.0;
			policyInstance.X += num * num2;
			double num3 = (ilist_0[i].Y + ilist_0[i + 1].Y) / 2.0;
			policyInstance.Y += num * num3;
		}
	}
}
