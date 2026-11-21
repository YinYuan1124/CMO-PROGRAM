using System.Collections;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public abstract class AbstractNode : IBoundable
{
	private readonly ArrayList attrCollection = new ArrayList();

	private readonly int m_VisitorCollection;

	private object exporterCollection;

	public virtual IList ChildBoundables => attrCollection;

	public virtual int Level => m_VisitorCollection;

	public virtual object Bounds
	{
		get
		{
			if (exporterCollection == null)
			{
				exporterCollection = ComputeBounds();
			}
			return exporterCollection;
		}
	}

	protected AbstractNode(int int_0)
	{
		m_VisitorCollection = int_0;
	}

	protected abstract object ComputeBounds();

	public virtual void AddChildBoundable(IBoundable iboundable_0)
	{
		Assert.IsTrue(exporterCollection == null);
		attrCollection.Add(iboundable_0);
	}
}
