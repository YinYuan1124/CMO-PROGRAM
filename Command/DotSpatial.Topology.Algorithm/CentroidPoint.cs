namespace DotSpatial.Topology.Algorithm;

public class CentroidPoint
{
	private readonly Coordinate identifierInstance = new Coordinate();

	private int m_PrinterInstance;

	public virtual Coordinate Centroid => new Coordinate
	{
		X = identifierInstance.X / (double)m_PrinterInstance,
		Y = identifierInstance.Y / (double)m_PrinterInstance
	};

	public virtual void Add(IGeometry igeometry_0)
	{
		if (igeometry_0 is IPoint)
		{
			Add(igeometry_0.Coordinate);
		}
		else if (igeometry_0 is GInterface3)
		{
			IGeometry[] geometries = ((GInterface3)igeometry_0).Geometries;
			IGeometry[] array = geometries;
			foreach (IGeometry igeometry_ in array)
			{
				Add(igeometry_);
			}
		}
	}

	public virtual void Add(Coordinate coordinate_0)
	{
		m_PrinterInstance++;
		identifierInstance.X += coordinate_0.X;
		identifierInstance.Y += coordinate_0.Y;
	}
}
