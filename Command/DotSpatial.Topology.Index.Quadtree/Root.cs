using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Quadtree;

public class Root : NodeBase
{
	private static readonly Coordinate _BroadcasterCollection;

	public virtual void Insert(IEnvelope ienvelope_0, object object_0)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(ienvelope_0, _BroadcasterCollection);
		if (subnodeIndex == -1)
		{
			Add(object_0);
			return;
		}
		Node node = base.Nodes[subnodeIndex];
		if (node == null || !node.Envelope.Contains(ienvelope_0))
		{
			Node node2 = Node.CreateExpanded(node, ienvelope_0);
			base.Nodes[subnodeIndex] = node2;
		}
		CalculateParameter(base.Nodes[subnodeIndex], ienvelope_0, object_0);
	}

	private static void CalculateParameter(Node node_0, IEnvelope ienvelope_0, object object_0)
	{
		Assert.IsTrue(node_0.Envelope.Contains(ienvelope_0));
		((IntervalSize.IsZeroWidth(ienvelope_0.Minimum.X, ienvelope_0.Maximum.X) | IntervalSize.IsZeroWidth(ienvelope_0.Minimum.X, ienvelope_0.Maximum.X)) ? node_0.Find(ienvelope_0) : node_0.GetNode(ienvelope_0)).Add(object_0);
	}

	protected override bool IsSearchMatch(IEnvelope ienvelope_0)
	{
		return true;
	}

	static Root()
	{
		_BroadcasterCollection = new Coordinate(0.0, 0.0);
	}
}
