namespace DotSpatial.Topology.Index.Chain;

public class MonotoneChainSelectAction
{
	public Envelope TempEnv1 = new Envelope();

	private LineSegment initializerCollection;

	public virtual void Select(MonotoneChain monotoneChain_0, int int_0)
	{
		initializerCollection = monotoneChain_0.GetLineSegment(int_0);
		Select(initializerCollection);
	}

	public virtual void Select(LineSegment lineSegment_0)
	{
	}
}
