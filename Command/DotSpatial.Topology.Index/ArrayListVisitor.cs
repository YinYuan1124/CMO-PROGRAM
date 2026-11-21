using System.Collections;

namespace DotSpatial.Topology.Index;

public class ArrayListVisitor : IItemVisitor
{
	private readonly ArrayList _TokenCollection = new ArrayList();

	public virtual ArrayList Items => _TokenCollection;

	public virtual void VisitItem(object object_0)
	{
		_TokenCollection.Add(object_0);
	}
}
