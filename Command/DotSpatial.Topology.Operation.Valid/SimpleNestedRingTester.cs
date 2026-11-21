using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class SimpleNestedRingTester
{
	private readonly GeometryGraph parserThread;

	private readonly IList m_AlgoThread = new ArrayList();

	private Coordinate databaseThread;

	public virtual Coordinate NestedPoint => databaseThread;

	public SimpleNestedRingTester(GeometryGraph geometryGraph_0)
	{
		parserThread = geometryGraph_0;
	}

	public virtual void Add(LinearRing linearRing_0)
	{
		m_AlgoThread.Add(linearRing_0);
	}

	public virtual bool IsNonNested()
	{
		for (int i = 0; i < m_AlgoThread.Count; i++)
		{
			LinearRing linearRing = (LinearRing)m_AlgoThread[i];
			IList<Coordinate> coordinates = linearRing.Coordinates;
			for (int j = 0; j < m_AlgoThread.Count; j++)
			{
				LinearRing linearRing2 = (LinearRing)m_AlgoThread[j];
				IList<Coordinate> coordinates2 = linearRing2.Coordinates;
				if (linearRing != linearRing2 && linearRing.EnvelopeInternal.Intersects(linearRing2.EnvelopeInternal))
				{
					Coordinate coordinate = IsValidOp.FindPointNotNode(coordinates, linearRing2, parserThread);
					Assert.IsTrue(coordinate != null, "Unable to find a ring point not a node of the search ring");
					if (CgAlgorithms.IsPointInRing(coordinate, coordinates2))
					{
						databaseThread = coordinate;
						return false;
					}
				}
			}
		}
		return true;
	}
}
