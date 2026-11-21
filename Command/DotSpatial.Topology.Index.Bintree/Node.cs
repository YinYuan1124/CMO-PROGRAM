using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Bintree;

public class Node : NodeBase
{
	private readonly double m_StateCollection;

	private readonly Interval authenticationCollection;

	private readonly int _ParamsCollection;

	public virtual Interval Interval => authenticationCollection;

	public Node(Interval interval_0, int int_0)
	{
		authenticationCollection = interval_0;
		_ParamsCollection = int_0;
		m_StateCollection = (interval_0.Min + interval_0.Max) / 2.0;
	}

	public static Node CreateNode(Interval interval_0)
	{
		Key key = new Key(interval_0);
		return new Node(key.Interval, key.Level);
	}

	public static Node CreateExpanded(Node node_0, Interval interval_0)
	{
		Interval interval = new Interval(interval_0);
		if (node_0 != null)
		{
			interval.ExpandToInclude(node_0.authenticationCollection);
		}
		Node node = CreateNode(interval);
		if (node_0 != null)
		{
			node.Insert(node_0);
		}
		return node;
	}

	protected override bool IsSearchMatch(Interval interval_0)
	{
		return interval_0.Overlaps(authenticationCollection);
	}

	public virtual Node GetNode(Interval interval_0)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(interval_0, m_StateCollection);
		if (subnodeIndex == -1)
		{
			return this;
		}
		return DisableParameter(subnodeIndex).GetNode(interval_0);
	}

	public virtual NodeBase Find(Interval interval_0)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(interval_0, m_StateCollection);
		if (subnodeIndex == -1)
		{
			return this;
		}
		if (Nodes[subnodeIndex] == null)
		{
			return this;
		}
		return Nodes[subnodeIndex].Find(interval_0);
	}

	public virtual void Insert(Node node_0)
	{
		Assert.IsTrue(authenticationCollection == null || authenticationCollection.Contains(node_0.Interval));
		int subnodeIndex = NodeBase.GetSubnodeIndex(node_0.authenticationCollection, m_StateCollection);
		if (node_0._ParamsCollection == _ParamsCollection - 1)
		{
			Nodes[subnodeIndex] = node_0;
			return;
		}
		Node node = UpdateParameter(subnodeIndex);
		node.Insert(node_0);
		Nodes[subnodeIndex] = node;
	}

	private Node DisableParameter(int int_0)
	{
		if (Nodes[int_0] == null)
		{
			Nodes[int_0] = UpdateParameter(int_0);
		}
		return Nodes[int_0];
	}

	private Node UpdateParameter(int int_0)
	{
		double double_ = 0.0;
		double double_2 = 0.0;
		switch (int_0)
		{
		case 1:
			double_ = m_StateCollection;
			double_2 = authenticationCollection.Max;
			break;
		case 0:
			double_ = authenticationCollection.Min;
			double_2 = m_StateCollection;
			break;
		}
		return new Node(new Interval(double_, double_2), _ParamsCollection - 1);
	}
}
