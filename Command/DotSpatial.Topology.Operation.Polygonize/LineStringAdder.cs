namespace DotSpatial.Topology.Operation.Polygonize;

public class LineStringAdder : IGeometryComponentFilter
{
	private readonly Polygonizer registryRule;

	public LineStringAdder(Polygonizer polygonizer_0)
	{
		registryRule = polygonizer_0;
	}

	public virtual void Filter(IGeometry igeometry_0)
	{
		if (igeometry_0 is ILineString igeometry_)
		{
			registryRule.Add(igeometry_);
		}
	}
}
