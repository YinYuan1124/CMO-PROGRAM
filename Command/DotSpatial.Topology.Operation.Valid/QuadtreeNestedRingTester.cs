using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Index.Quadtree;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class QuadtreeNestedRingTester
{
	private readonly GeometryGraph m_CandidateThread;

	private readonly IList _BaseThread = new ArrayList();

	private readonly Envelope policyThread = new Envelope();

	private Coordinate broadcasterThread;

	private Quadtree identifierThread;

	public virtual Coordinate NestedPoint => broadcasterThread;

	public QuadtreeNestedRingTester(GeometryGraph geometryGraph_0)
	{
		m_CandidateThread = geometryGraph_0;
	}

	public virtual void Add(LinearRing linearRing_0)
	{
		_BaseThread.Add(linearRing_0);
		policyThread.ExpandToInclude(linearRing_0.EnvelopeInternal);
	}

	public virtual bool IsNonNested()
	{
		CompareCollection();
		for (int i = 0; i < _BaseThread.Count; i++)
		{
			LinearRing linearRing = (LinearRing)_BaseThread[i];
			IList<Coordinate> coordinates = linearRing.Coordinates;
			IList list = identifierThread.Query(linearRing.EnvelopeInternal);
			for (int j = 0; j < list.Count; j++)
			{
				LinearRing linearRing2 = (LinearRing)list[j];
				IList<Coordinate> coordinates2 = linearRing2.Coordinates;
				if (linearRing != linearRing2 && linearRing.EnvelopeInternal.Intersects(linearRing2.EnvelopeInternal))
				{
					Coordinate coordinate = IsValidOp.FindPointNotNode(coordinates, linearRing2, m_CandidateThread);
					Assert.IsTrue(coordinate != null, "Unable to find a ring point not a node of the search ring");
					if (CgAlgorithms.IsPointInRing(coordinate, coordinates2))
					{
						broadcasterThread = coordinate;
						return false;
					}
				}
			}
		}
		return true;
	}

	private void CompareCollection()
	{
		identifierThread = new Quadtree();
		for (int i = 0; i < _BaseThread.Count; i++)
		{
			LinearRing linearRing = (LinearRing)_BaseThread[i];
			IEnvelope envelopeInternal = linearRing.EnvelopeInternal;
			identifierThread.Insert(envelopeInternal, linearRing);
		}
	}
}
