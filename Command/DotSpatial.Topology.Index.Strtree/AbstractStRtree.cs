using System.Collections;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public abstract class AbstractStRtree
{
	protected interface IIntersectsOp
	{
		bool Intersects(object object_0, object object_1);
	}

	private readonly ArrayList prototypeCollection = new ArrayList();

	private readonly int m_ComparatorCollection;

	private bool itemCollection;

	private AbstractNode _SetterCollection;

	public virtual AbstractNode Root
	{
		get
		{
			return _SetterCollection;
		}
		protected set
		{
			_SetterCollection = value;
		}
	}

	public virtual int NodeCapacity => m_ComparatorCollection;

	public virtual int Count
	{
		get
		{
			if (!itemCollection)
			{
				Build();
			}
			if (prototypeCollection.Count == 0)
			{
				return 0;
			}
			return GetSize(_SetterCollection);
		}
	}

	public virtual int Depth
	{
		get
		{
			if (!itemCollection)
			{
				Build();
			}
			if (prototypeCollection.Count == 0)
			{
				return 0;
			}
			return GetDepth(_SetterCollection);
		}
	}

	protected abstract IIntersectsOp IntersectsOp { get; }

	protected AbstractStRtree(int int_0)
	{
		Assert.IsTrue(int_0 > 1, "Node capacity must be greater than 1");
		m_ComparatorCollection = int_0;
	}

	public virtual void Build()
	{
		Assert.IsTrue(!itemCollection);
		_SetterCollection = ((prototypeCollection.Count == 0) ? CreateNode(0) : SetupParameter(prototypeCollection, -1));
		itemCollection = true;
	}

	protected abstract AbstractNode CreateNode(int int_0);

	protected virtual IList CreateParentBoundables(IList ilist_0, int int_0)
	{
		Assert.IsTrue(ilist_0.Count != 0);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(CreateNode(int_0));
		ArrayList arrayList2 = new ArrayList(ilist_0);
		arrayList2.Sort(GetComparer());
		IEnumerator enumerator = arrayList2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable iboundable_ = (IBoundable)enumerator.Current;
			if (LastNode(arrayList).ChildBoundables.Count == NodeCapacity)
			{
				arrayList.Add(CreateNode(int_0));
			}
			LastNode(arrayList).AddChildBoundable(iboundable_);
		}
		return arrayList;
	}

	protected virtual AbstractNode LastNode(IList ilist_0)
	{
		return (AbstractNode)ilist_0[ilist_0.Count - 1];
	}

	public virtual int CompareDoubles(double double_0, double double_1)
	{
		if (double_0 <= double_1)
		{
			if (double_0 < double_1)
			{
				return -1;
			}
			return 0;
		}
		return 1;
	}

	private AbstractNode SetupParameter(IList ilist_0, int int_0)
	{
		Assert.IsTrue(ilist_0.Count != 0);
		IList list = CreateParentBoundables(ilist_0, int_0 + 1);
		if (list.Count == 1)
		{
			return (AbstractNode)list[0];
		}
		return SetupParameter(list, int_0 + 1);
	}

	protected virtual int GetSize(AbstractNode abstractNode_0)
	{
		int num = 0;
		IEnumerator enumerator = abstractNode_0.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable = (IBoundable)enumerator.Current;
			if (boundable is AbstractNode)
			{
				num += GetSize((AbstractNode)boundable);
			}
			else if (boundable is ItemBoundable)
			{
				num++;
			}
		}
		return num;
	}

	protected virtual int GetDepth(AbstractNode abstractNode_0)
	{
		int num = 0;
		IEnumerator enumerator = abstractNode_0.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable = (IBoundable)enumerator.Current;
			if (boundable is AbstractNode)
			{
				int depth = GetDepth((AbstractNode)boundable);
				if (depth > num)
				{
					num = depth;
				}
			}
		}
		return num + 1;
	}

	protected virtual void Insert(object object_0, object object_1)
	{
		Assert.IsTrue(!itemCollection, "Cannot insert items into an STR packed R-tree after it has been built.");
		prototypeCollection.Add(new ItemBoundable(object_0, object_1));
	}

	protected virtual IList Query(object object_0)
	{
		if (!itemCollection)
		{
			Build();
		}
		ArrayList arrayList = new ArrayList();
		if (prototypeCollection.Count == 0)
		{
			Assert.IsTrue(_SetterCollection.Bounds == null);
			return arrayList;
		}
		if (IntersectsOp.Intersects(_SetterCollection.Bounds, object_0))
		{
			ExcludeParameter(object_0, _SetterCollection, arrayList);
		}
		return arrayList;
	}

	protected virtual void Query(object object_0, IItemVisitor iitemVisitor_0)
	{
		if (!itemCollection)
		{
			Build();
		}
		if (prototypeCollection.Count == 0)
		{
			Assert.IsTrue(_SetterCollection.Bounds == null);
		}
		if (IntersectsOp.Intersects(_SetterCollection.Bounds, object_0))
		{
			IncludeParameter(object_0, _SetterCollection, iitemVisitor_0);
		}
	}

	private void ExcludeParameter(object object_0, AbstractNode abstractNode_0, IList ilist_0)
	{
		foreach (IBoundable childBoundable in abstractNode_0.ChildBoundables)
		{
			if (!IntersectsOp.Intersects(childBoundable.Bounds, object_0))
			{
				continue;
			}
			if (childBoundable is AbstractNode)
			{
				ExcludeParameter(object_0, (AbstractNode)childBoundable, ilist_0);
				continue;
			}
			if (childBoundable is ItemBoundable)
			{
				ilist_0.Add(((ItemBoundable)childBoundable).Item);
				continue;
			}
			throw new ShouldNeverReachHereException();
		}
	}

	private void IncludeParameter(object object_0, AbstractNode abstractNode_0, IItemVisitor iitemVisitor_0)
	{
		foreach (IBoundable childBoundable in abstractNode_0.ChildBoundables)
		{
			if (!IntersectsOp.Intersects(childBoundable.Bounds, object_0))
			{
				continue;
			}
			if (childBoundable is AbstractNode)
			{
				IncludeParameter(object_0, (AbstractNode)childBoundable, iitemVisitor_0);
				continue;
			}
			if (childBoundable is ItemBoundable)
			{
				iitemVisitor_0.VisitItem(((ItemBoundable)childBoundable).Item);
				continue;
			}
			throw new ShouldNeverReachHereException();
		}
	}

	protected virtual bool Remove(object object_0, object object_1)
	{
		if (!itemCollection)
		{
			Build();
		}
		if (prototypeCollection.Count == 0)
		{
			Assert.IsTrue(_SetterCollection.Bounds == null);
		}
		if (IntersectsOp.Intersects(_SetterCollection.Bounds, object_0))
		{
			return Remove(object_0, _SetterCollection, object_1);
		}
		return false;
	}

	private static bool SearchParameter(AbstractNode abstractNode_0, object object_0)
	{
		IBoundable boundable = null;
		IEnumerator enumerator = abstractNode_0.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable2 = (IBoundable)enumerator.Current;
			if (boundable2 is ItemBoundable && ((ItemBoundable)boundable2).Item == object_0)
			{
				boundable = boundable2;
			}
		}
		if (boundable == null)
		{
			return false;
		}
		abstractNode_0.ChildBoundables.Remove(boundable);
		return true;
	}

	private bool Remove(object object_0, AbstractNode abstractNode_0, object object_1)
	{
		bool result;
		if (result = SearchParameter(abstractNode_0, object_1))
		{
			return true;
		}
		AbstractNode abstractNode = null;
		IEnumerator enumerator = abstractNode_0.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable = (IBoundable)enumerator.Current;
			if (IntersectsOp.Intersects(boundable.Bounds, object_0) && boundable is AbstractNode && (result = Remove(object_0, (AbstractNode)boundable, object_1)))
			{
				abstractNode = (AbstractNode)boundable;
				break;
			}
		}
		if (abstractNode != null && abstractNode.ChildBoundables.Count == 0)
		{
			abstractNode_0.ChildBoundables.Remove(abstractNode);
		}
		return result;
	}

	protected virtual IList BoundablesAtLevel(int int_0)
	{
		IList ilist_ = new ArrayList();
		EnableParameter(int_0, _SetterCollection, ref ilist_);
		return ilist_;
	}

	private static void EnableParameter(int int_0, AbstractNode abstractNode_0, ref IList ilist_0)
	{
		Assert.IsTrue(int_0 > -2);
		if (abstractNode_0.Level == int_0)
		{
			ilist_0.Add(abstractNode_0);
			return;
		}
		IEnumerator enumerator = abstractNode_0.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable = (IBoundable)enumerator.Current;
			if (boundable is AbstractNode)
			{
				EnableParameter(int_0, (AbstractNode)boundable, ref ilist_0);
				continue;
			}
			Assert.IsTrue(boundable is ItemBoundable);
			if (int_0 == -1)
			{
				ilist_0.Add(boundable);
			}
		}
	}

	protected abstract IComparer GetComparer();
}
