using DotSpatial.Topology.Index;
using DotSpatial.Topology.Index.Chain;
using DotSpatial.Topology.Index.Strtree;

namespace DotSpatial.Topology.Noding.Snapround;

public class McIndexPointSnapper
{
	public class HotPixelSnapAction : MonotoneChainSelectAction
	{
		private readonly HotPixel m_ContextPrototype;

		private readonly SegmentString statusPrototype;

		private readonly int proccesorPrototype;

		private bool m_StrategyPrototype;

		public bool IsNodeAdded => m_StrategyPrototype;

		public HotPixelSnapAction(HotPixel hotPixel_0, SegmentString segmentString_0, int int_0)
		{
			m_ContextPrototype = hotPixel_0;
			statusPrototype = segmentString_0;
			proccesorPrototype = int_0;
		}

		public override void Select(MonotoneChain monotoneChain_0, int int_0)
		{
			SegmentString segmentString = (SegmentString)monotoneChain_0.Context;
			if (statusPrototype == null || segmentString != statusPrototype || int_0 != proccesorPrototype)
			{
				m_StrategyPrototype = SimpleSnapRounder.AddSnappedNode(m_ContextPrototype, segmentString, int_0);
			}
		}
	}

	private class ConfigurationPrototype : IItemVisitor
	{
		private readonly HotPixelSnapAction _TokenPrototype;

		private readonly Envelope _IndexerPrototype;

		public ConfigurationPrototype(Envelope envelope_0, HotPixelSnapAction hotPixelSnapAction_0)
		{
			_IndexerPrototype = envelope_0;
			_TokenPrototype = hotPixelSnapAction_0;
		}

		public void VisitItem(object object_0)
		{
			((MonotoneChain)object_0).Select(_IndexerPrototype, _TokenPrototype);
		}
	}

	private readonly StRtree _StubCollection;

	public McIndexPointSnapper(ISpatialIndex ispatialIndex_0)
	{
		_StubCollection = (StRtree)ispatialIndex_0;
	}

	public bool Snap(HotPixel hotPixel_0, SegmentString segmentString_0, int int_0)
	{
		Envelope safeEnvelope = hotPixel_0.GetSafeEnvelope();
		HotPixelSnapAction hotPixelSnapAction = new HotPixelSnapAction(hotPixel_0, segmentString_0, int_0);
		_StubCollection.Query(safeEnvelope, new ConfigurationPrototype(safeEnvelope, hotPixelSnapAction));
		return hotPixelSnapAction.IsNodeAdded;
	}

	public bool Snap(HotPixel hotPixel_0)
	{
		return Snap(hotPixel_0, null, -1);
	}
}
