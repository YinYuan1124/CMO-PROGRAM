using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface ICoordinateSequenceFactory
{
	GInterface2 Create(IEnumerable<Coordinate> ienumerable_0);

	GInterface2 Create(Coordinate coordinate_0);

	GInterface2 Create();
}
