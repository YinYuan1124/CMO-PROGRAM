namespace DotSpatial.Topology.Utilities;

public abstract class ShortCircuitedGeometryVisitor
{
	private bool wrapperThread;

	public void ApplyTo(IGeometry igeometry_0)
	{
		for (int i = 0; i < igeometry_0.NumGeometries; i++)
		{
			if (wrapperThread)
			{
				break;
			}
			IGeometry geometryN = igeometry_0.GetGeometryN(i);
			if (geometryN is GeometryCollection)
			{
				ApplyTo(geometryN);
				continue;
			}
			Visit(geometryN);
			if (IsDone())
			{
				wrapperThread = true;
				break;
			}
		}
	}

	protected abstract void Visit(IGeometry igeometry_0);

	protected abstract bool IsDone();
}
