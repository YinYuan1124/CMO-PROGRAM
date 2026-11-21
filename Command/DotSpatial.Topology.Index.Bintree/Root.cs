using DotSpatial.Topology.Index.Quadtree;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Bintree;

public class Root : NodeBase
{
	public virtual void Insert(Interval interval_0, object object_0)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(interval_0, 0.0);
		if (subnodeIndex == -1)
		{
			Add(object_0);
			return;
		}
		Node node = Nodes[subnodeIndex];
		if (node == null || !node.Interval.Contains(interval_0))
		{
			Node node2 = Node.CreateExpanded(node, interval_0);
			Nodes[subnodeIndex] = node2;
		}
		InsertParameter(Nodes[subnodeIndex], interval_0, object_0);
	}

	private static void InsertParameter(Node node_0, Interval interval_0, object object_0)
	{
		Assert.IsTrue(node_0.Interval.Contains(interval_0));
		(IntervalSize.IsZeroWidth(interval_0.Min, interval_0.Max) ? node_0.Find(interval_0) : node_0.GetNode(interval_0)).Add(object_0);
	}

	protected override bool IsSearchMatch(Interval interval_0)
	{
		return true;
	}
}
