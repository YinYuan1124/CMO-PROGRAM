using System.Runtime.CompilerServices;

namespace DotSpatial.Topology.Index.Chain;

public class MonotoneChainOverlapAction
{
	private Envelope messageCollection = new Envelope();

	private Envelope productCollection = new Envelope();

	[CompilerGenerated]
	private LineSegment annotationCollection;

	[CompilerGenerated]
	private LineSegment m_IteratorCollection;

	public Envelope TempEnv1
	{
		get
		{
			return messageCollection;
		}
		set
		{
			messageCollection = value;
		}
	}

	public Envelope TempEnv2
	{
		get
		{
			return productCollection;
		}
		set
		{
			productCollection = value;
		}
	}

	protected LineSegment OverlapSeg1
	{
		[CompilerGenerated]
		get
		{
			return annotationCollection;
		}
		[CompilerGenerated]
		set
		{
			annotationCollection = value;
		}
	}

	protected LineSegment OverlapSeg2
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorCollection;
		}
		[CompilerGenerated]
		set
		{
			m_IteratorCollection = value;
		}
	}

	public virtual void Overlap(MonotoneChain monotoneChain_0, int int_0, MonotoneChain monotoneChain_1, int int_1)
	{
		OverlapSeg1 = monotoneChain_0.GetLineSegment(int_0);
		OverlapSeg2 = monotoneChain_1.GetLineSegment(int_1);
		Overlap(OverlapSeg1, OverlapSeg2);
	}

	public virtual void Overlap(LineSegment lineSegment_0, LineSegment lineSegment_1)
	{
	}
}
