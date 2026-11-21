using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Quadtree;

public class Node : NodeBase
{
	private readonly Coordinate m_MethodCollection;

	private readonly IEnvelope serviceCollection;

	private readonly int systemCollection;

	public virtual IEnvelope Envelope => serviceCollection;

	public Node(IEnvelope ienvelope_0, int int_0)
	{
		serviceCollection = ienvelope_0;
		systemCollection = int_0;
		m_MethodCollection = new Coordinate();
		m_MethodCollection.X = (ienvelope_0.Minimum.X + ienvelope_0.Maximum.X) / 2.0;
		m_MethodCollection.Y = (ienvelope_0.Minimum.Y + ienvelope_0.Maximum.Y) / 2.0;
	}

	public static Node CreateNode(IEnvelope ienvelope_0)
	{
		Key key = new Key(ienvelope_0);
		return new Node(key.Envelope, key.Level);
	}

	public static Node CreateExpanded(Node node_0, IEnvelope ienvelope_0)
	{
		Envelope ienvelope_ = new Envelope(ienvelope_0);
		if (node_0 != null)
		{
			ienvelope_.ExpandToInclude(node_0.serviceCollection);
		}
		Node node = CreateNode(ienvelope_);
		if (node_0 != null)
		{
			node.InsertNode(node_0);
		}
		return node;
	}

	protected override bool IsSearchMatch(IEnvelope ienvelope_0)
	{
		return serviceCollection.Intersects(ienvelope_0);
	}

	public virtual Node GetNode(IEnvelope ienvelope_0)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(ienvelope_0, m_MethodCollection);
		if (subnodeIndex == -1)
		{
			return this;
		}
		return RemoveParameter(subnodeIndex).GetNode(ienvelope_0);
	}

	public virtual NodeBase Find(IEnvelope ienvelope_0)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(ienvelope_0, m_MethodCollection);
		if (subnodeIndex == -1)
		{
			return this;
		}
		if (base.Nodes[subnodeIndex] == null)
		{
			return this;
		}
		return base.Nodes[subnodeIndex].Find(ienvelope_0);
	}

	public virtual void InsertNode(Node node_0)
	{
		Assert.IsTrue(serviceCollection == null || serviceCollection.Contains(node_0.Envelope));
		int subnodeIndex = NodeBase.GetSubnodeIndex(node_0.serviceCollection, m_MethodCollection);
		if (node_0.systemCollection == systemCollection - 1)
		{
			base.Nodes[subnodeIndex] = node_0;
			return;
		}
		Node node = FindParameter(subnodeIndex);
		node.InsertNode(node_0);
		base.Nodes[subnodeIndex] = node;
	}

	private Node RemoveParameter(int int_0)
	{
		if (base.Nodes[int_0] == null)
		{
			base.Nodes[int_0] = FindParameter(int_0);
		}
		return base.Nodes[int_0];
	}

	private Node FindParameter(int int_0)
	{
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		switch (int_0)
		{
		case 0:
			double_ = serviceCollection.Minimum.X;
			double_2 = m_MethodCollection.X;
			double_3 = serviceCollection.Minimum.Y;
			double_4 = m_MethodCollection.Y;
			break;
		case 1:
			double_ = m_MethodCollection.X;
			double_2 = serviceCollection.Maximum.X;
			double_3 = serviceCollection.Minimum.Y;
			double_4 = m_MethodCollection.Y;
			break;
		case 2:
			double_ = serviceCollection.Minimum.X;
			double_2 = m_MethodCollection.X;
			double_3 = m_MethodCollection.Y;
			double_4 = serviceCollection.Maximum.Y;
			break;
		case 3:
			double_ = m_MethodCollection.X;
			double_2 = serviceCollection.Maximum.X;
			double_3 = m_MethodCollection.Y;
			double_4 = serviceCollection.Maximum.Y;
			break;
		}
		return new Node(new Envelope(double_, double_2, double_3, double_4), systemCollection - 1);
	}
}
