using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public class SimplePointInRing : IPointInRing
{
	private readonly IList<Coordinate> m_RuleObject;

	public SimplePointInRing(IBasicGeometry ibasicGeometry_0)
	{
		m_RuleObject = ibasicGeometry_0.Coordinates;
	}

	public virtual bool IsInside(Coordinate coordinate_0)
	{
		return CgAlgorithms.IsPointInRing(coordinate_0, m_RuleObject);
	}
}
