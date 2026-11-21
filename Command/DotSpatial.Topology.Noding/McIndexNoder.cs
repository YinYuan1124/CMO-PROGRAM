using System.Collections;
using DotSpatial.Topology.Index;
using DotSpatial.Topology.Index.Chain;
using DotSpatial.Topology.Index.Strtree;

namespace DotSpatial.Topology.Noding;

public class McIndexNoder : SinglePassNoder
{
	public class SegmentOverlapAction : MonotoneChainOverlapAction
	{
		private readonly GInterface5 m_ConnectionPrototype;

		public SegmentOverlapAction(GInterface5 ginterface5_0)
		{
			m_ConnectionPrototype = ginterface5_0;
		}

		public override void Overlap(MonotoneChain monotoneChain_0, int int_0, MonotoneChain monotoneChain_1, int int_1)
		{
			SegmentString segmentString_ = (SegmentString)monotoneChain_0.Context;
			SegmentString segmentString_2 = (SegmentString)monotoneChain_1.Context;
			m_ConnectionPrototype.ProcessIntersections(segmentString_, int_0, segmentString_2, int_1);
		}
	}

	private readonly ISpatialIndex m_ParamsRule = new StRtree();

	private readonly IList infoRule = new ArrayList();

	private int helperRule;

	private int mapperRule;

	private IList m_ManagerRule;

	public IList MonotoneChains => infoRule;

	public ISpatialIndex Index => m_ParamsRule;

	public McIndexNoder()
	{
	}

	public McIndexNoder(GInterface5 ginterface5_0)
		: base(ginterface5_0)
	{
	}

	public override IList GetNodedSubstrings()
	{
		return SegmentString.GetNodedSubstrings(m_ManagerRule);
	}

	public override void ComputeNodes(IList ilist_0)
	{
		m_ManagerRule = ilist_0;
		foreach (object item in ilist_0)
		{
			Add((SegmentString)item);
		}
		InstantiateObject();
	}

	private void InstantiateObject()
	{
		MonotoneChainOverlapAction monotoneChainOverlapAction_ = new SegmentOverlapAction(base.SegmentIntersector);
		foreach (MonotoneChain item in infoRule)
		{
			foreach (MonotoneChain item2 in m_ParamsRule.Query(item.Envelope))
			{
				if (item2.Id > item.Id)
				{
					item.ComputeOverlaps(item2, monotoneChainOverlapAction_);
					mapperRule++;
				}
			}
		}
	}

	private void Add(SegmentString segmentString_0)
	{
		foreach (MonotoneChain chain in MonotoneChainBuilder.GetChains(segmentString_0.Coordinates, segmentString_0))
		{
			chain.Id = helperRule++;
			m_ParamsRule.Insert(chain.Envelope, chain);
			infoRule.Add(chain);
		}
	}
}
