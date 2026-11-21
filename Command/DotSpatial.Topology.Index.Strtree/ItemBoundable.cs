namespace DotSpatial.Topology.Index.Strtree;

public class ItemBoundable : IBoundable
{
	private readonly object mappingCollection;

	private readonly object m_MockCollection;

	public virtual object Item => m_MockCollection;

	public virtual object Bounds => mappingCollection;

	public ItemBoundable(object object_0, object object_1)
	{
		mappingCollection = object_0;
		m_MockCollection = object_1;
	}
}
