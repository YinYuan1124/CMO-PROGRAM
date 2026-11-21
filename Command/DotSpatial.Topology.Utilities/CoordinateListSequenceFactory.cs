using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

[Serializable]
public sealed class CoordinateListSequenceFactory : ICoordinateSequenceFactory
{
	public static readonly CoordinateListSequenceFactory Instance;

	public GInterface2 Create(IEnumerable<Coordinate> ienumerable_0)
	{
		return new CoordinateListSequence(ienumerable_0);
	}

	public GInterface2 Create()
	{
		return new CoordinateListSequence();
	}

	public GInterface2 Create(Coordinate coordinate_0)
	{
		return new CoordinateListSequence(coordinate_0);
	}

	public GInterface2 Create(GInterface2 ginterface2_0)
	{
		return new CoordinateListSequence(ginterface2_0);
	}

	static CoordinateListSequenceFactory()
	{
		Instance = new CoordinateListSequenceFactory();
	}
}
