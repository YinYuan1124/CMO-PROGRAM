using System.Collections;
using DotSpatial.Topology.Index.Bintree;
using DotSpatial.Topology.Index.Chain;

namespace DotSpatial.Topology.Algorithm;

public sealed class McPointInRing : IPointInRing
{
	private class PredicatePrototype : MonotoneChainSelectAction
	{
		private readonly McPointInRing singletonPrototype;

		private readonly Coordinate _RecordPrototype = Coordinate.Empty;

		public PredicatePrototype(McPointInRing mcPointInRing_0, Coordinate coordinate_0)
		{
			singletonPrototype = mcPointInRing_0;
			_RecordPrototype = coordinate_0;
		}

		public override void Select(LineSegment lineSegment_0)
		{
			singletonPrototype.EnableExpression(_RecordPrototype, lineSegment_0);
		}
	}

	private readonly Interval helperInstance = new Interval();

	private readonly ILinearRing mapperInstance;

	private int _ManagerInstance;

	private Bintree m_GetterInstance;

	public McPointInRing(ILinearRing ilinearRing_0)
	{
		mapperInstance = ilinearRing_0;
		IncludeExpression();
	}

	public bool IsInside(Coordinate coordinate_0)
	{
		_ManagerInstance = 0;
		Envelope ienvelope_ = new Envelope(double.NegativeInfinity, double.PositiveInfinity, coordinate_0.Y, coordinate_0.Y);
		helperInstance.Min = coordinate_0.Y;
		helperInstance.Max = coordinate_0.Y;
		IList list = m_GetterInstance.Query(helperInstance);
		PredicatePrototype monotoneChainSelectAction_ = new PredicatePrototype(this, coordinate_0);
		IEnumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MonotoneChain monotoneChain_ = (MonotoneChain)enumerator.Current;
			SearchExpression(ienvelope_, monotoneChainSelectAction_, monotoneChain_);
		}
		if (_ManagerInstance % 2 == 1)
		{
			return true;
		}
		return false;
	}

	private void IncludeExpression()
	{
		m_GetterInstance = new Bintree();
		IList chains = MonotoneChainBuilder.GetChains(CoordinateArrays.RemoveRepeatedPoints(mapperInstance.Coordinates));
		for (int i = 0; i < chains.Count; i++)
		{
			MonotoneChain monotoneChain = (MonotoneChain)chains[i];
			Envelope envelope = monotoneChain.Envelope;
			helperInstance.Min = envelope.Minimum.Y;
			helperInstance.Max = envelope.Maximum.Y;
			m_GetterInstance.Insert(helperInstance, monotoneChain);
		}
	}

	private static void SearchExpression(IEnvelope ienvelope_0, MonotoneChainSelectAction monotoneChainSelectAction_0, MonotoneChain monotoneChain_0)
	{
		monotoneChain_0.Select(ienvelope_0, monotoneChainSelectAction_0);
	}

	private void EnableExpression(Coordinate coordinate_0, ILineSegmentBase ilineSegmentBase_0)
	{
		Coordinate p = ilineSegmentBase_0.P0;
		Coordinate p2 = ilineSegmentBase_0.P1;
		double double_ = p.X - coordinate_0.X;
		double num = p.Y - coordinate_0.Y;
		double double_2 = p2.X - coordinate_0.X;
		double num2 = p2.Y - coordinate_0.Y;
		if ((num > 0.0 && num2 <= 0.0) || (num2 > 0.0 && num <= 0.0))
		{
			double num3 = (double)RobustDeterminant.SignOfDet2X2(double_, num, double_2, num2) / (num2 - num);
			if (0.0 < num3)
			{
				_ManagerInstance++;
			}
		}
	}
}
