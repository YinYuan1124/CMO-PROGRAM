using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

[Serializable]
public sealed class CoordinateArraySequenceFactory : ICoordinateSequenceFactory
{
	public static readonly CoordinateArraySequenceFactory Instance;

	private CoordinateArraySequenceFactory()
	{
	}

	public GInterface2 Create(IEnumerable<Coordinate> ienumerable_0)
	{
		return new CoordinateArraySequence(ienumerable_0);
	}

	public GInterface2 Create(Coordinate coordinate_0)
	{
		return new CoordinateArraySequence(coordinate_0);
	}

	public GInterface2 Create()
	{
		return new CoordinateArraySequence();
	}

	public GInterface2 Create(GInterface2 ginterface2_0)
	{
		return new CoordinateArraySequence(ginterface2_0);
	}

	static CoordinateArraySequenceFactory()
	{
		Instance = new CoordinateArraySequenceFactory();
	}
}
