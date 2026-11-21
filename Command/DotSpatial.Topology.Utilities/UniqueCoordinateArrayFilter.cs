using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

public class UniqueCoordinateArrayFilter : ICoordinateFilter
{
	private readonly ArrayList _ObserverThread = new ArrayList();

	private readonly ISet<Coordinate> issuerThread = new SortedSet<Coordinate>();

	public virtual Coordinate[] Coordinates => (Coordinate[])_ObserverThread.ToArray(typeof(Coordinate));

	public virtual void Filter(Coordinate coordinate_0)
	{
		if (!issuerThread.Contains(coordinate_0))
		{
			_ObserverThread.Add(coordinate_0);
			issuerThread.Add(coordinate_0);
		}
	}
}
