using System.Collections;

namespace DotSpatial.Topology.Noding;

public abstract class SinglePassNoder : INoder
{
	private GInterface5 m_ConsumerCollection;

	public GInterface5 SegmentIntersector
	{
		get
		{
			return m_ConsumerCollection;
		}
		set
		{
			m_ConsumerCollection = value;
		}
	}

	protected SinglePassNoder()
	{
	}

	protected SinglePassNoder(GInterface5 ginterface5_0)
	{
		m_ConsumerCollection = ginterface5_0;
	}

	public abstract void ComputeNodes(IList ilist_0);

	public abstract IList GetNodedSubstrings();
}
