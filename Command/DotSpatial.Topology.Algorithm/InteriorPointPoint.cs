namespace DotSpatial.Topology.Algorithm;

public class InteriorPointPoint
{
	private readonly Coordinate m_AttributeInstance;

	private Coordinate eventInstance = Coordinate.Empty;

	private double globalInstance = double.MaxValue;

	public virtual Coordinate InteriorPoint => eventInstance;

	public InteriorPointPoint(IGeometry igeometry_0)
	{
		m_AttributeInstance = new Coordinate(igeometry_0.Centroid);
		Add(igeometry_0);
	}

	private void Add(IGeometry igeometry_0)
	{
		if (igeometry_0 is Point)
		{
			Add(igeometry_0.Coordinate);
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

	private void Add(Coordinate coordinate_0)
	{
		double num = coordinate_0.Distance(m_AttributeInstance);
		if (num < globalInstance)
		{
			eventInstance = new Coordinate(coordinate_0);
			globalInstance = num;
		}
	}
}
