using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Index.Sweepline;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class SweeplineNestedRingTester
{
	public class OverlapAction : ISweepLineOverlapAction
	{
		private readonly SweeplineNestedRingTester m_CustomerPrototype;

		private bool _SerializerPrototype = true;

		public virtual bool IsNonNested => _SerializerPrototype;

		public OverlapAction(SweeplineNestedRingTester sweeplineNestedRingTester_0)
		{
			m_CustomerPrototype = sweeplineNestedRingTester_0;
		}

		public virtual void Overlap(SweepLineInterval sweepLineInterval_0, SweepLineInterval sweepLineInterval_1)
		{
			LinearRing linearRing = (LinearRing)sweepLineInterval_0.Item;
			LinearRing linearRing2 = (LinearRing)sweepLineInterval_1.Item;
			if (linearRing != linearRing2 && m_CustomerPrototype.InsertCollection(linearRing, linearRing2))
			{
				_SerializerPrototype = false;
			}
		}
	}

	private readonly GeometryGraph m_InterceptorThread;

	private readonly IList messageThread = new ArrayList();

	private Coordinate productThread;

	private SweepLineIndex _AnnotationThread;

	public virtual Coordinate NestedPoint => productThread;

	public SweeplineNestedRingTester(GeometryGraph geometryGraph_0)
	{
		m_InterceptorThread = geometryGraph_0;
	}

	public virtual void Add(LinearRing linearRing_0)
	{
		messageThread.Add(linearRing_0);
	}

	public virtual bool IsNonNested()
	{
		UpdateCollection();
		OverlapAction overlapAction = new OverlapAction(this);
		_AnnotationThread.ComputeOverlaps(overlapAction);
		return overlapAction.IsNonNested;
	}

	private void UpdateCollection()
	{
		_AnnotationThread = new SweepLineIndex();
		for (int i = 0; i < messageThread.Count; i++)
		{
			LinearRing linearRing = (LinearRing)messageThread[i];
			IEnvelope envelopeInternal = linearRing.EnvelopeInternal;
			SweepLineInterval sweepLineInterval_ = new SweepLineInterval(envelopeInternal.Minimum.X, envelopeInternal.Maximum.X, linearRing);
			_AnnotationThread.Add(sweepLineInterval_);
		}
	}

	private bool InsertCollection(ILinearRing ilinearRing_0, ILinearRing ilinearRing_1)
	{
		IList<Coordinate> coordinates = ilinearRing_0.Coordinates;
		IList<Coordinate> coordinates2 = ilinearRing_1.Coordinates;
		if (ilinearRing_0.EnvelopeInternal.Intersects(ilinearRing_1.EnvelopeInternal))
		{
			Coordinate coordinate = IsValidOp.FindPointNotNode(coordinates, ilinearRing_1, m_InterceptorThread);
			Assert.IsTrue(coordinate != null, "Unable to find a ring point not a node of the search ring");
			if (CgAlgorithms.IsPointInRing(coordinate, coordinates2))
			{
				productThread = new Coordinate(coordinate);
				return true;
			}
			return false;
		}
		return false;
	}
}
