using System;
using System.Collections;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public class StRtree : AbstractStRtree, ISpatialIndex
{
	private class ConfigCollectionTask : AbstractNode
	{
		public ConfigCollectionTask(int int_0)
			: base(int_0)
		{
		}

		protected override object ComputeBounds()
		{
			Envelope envelope = null;
			IEnumerator enumerator = ChildBoundables.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IBoundable boundable = (IBoundable)enumerator.Current;
				if (envelope == null)
				{
					envelope = new Envelope((Envelope)boundable.Bounds);
				}
				else
				{
					envelope.ExpandToInclude((Envelope)boundable.Bounds);
				}
			}
			return envelope;
		}
	}

	private class ImporterListenerMapping : IIntersectsOp
	{
		public bool Intersects(object object_0, object object_1)
		{
			return ((Envelope)object_0).Intersects((Envelope)object_1);
		}
	}

	private class IdentifierMerchantService : IComparer
	{
		private readonly object publisherPrototype;

		public IdentifierMerchantService(StRtree stRtree_0)
		{
			publisherPrototype = stRtree_0;
		}

		public int Compare(object x, object y)
		{
			double xBounds = InitParameter((Envelope)((IBoundable)x).Bounds);
			double yBounds = InitParameter((Envelope)((IBoundable)y).Bounds);
			return ((AbstractStRtree)publisherPrototype).CompareDoubles(xBounds, yBounds);
		}
	}

	private class ServerPrototype : IComparer
	{
		private readonly object _AdapterPrototype;

		public ServerPrototype(StRtree stRtree_0)
		{
			_AdapterPrototype = stRtree_0;
		}

		public int Compare(object x, object y)
		{
			return ((AbstractStRtree)_AdapterPrototype).CompareDoubles(CheckParameter((Envelope)((IBoundable)x).Bounds), CheckParameter((Envelope)((IBoundable)y).Bounds));
		}
	}

	protected override IIntersectsOp IntersectsOp => new ImporterListenerMapping();

	public StRtree()
		: this(10)
	{
	}

	public StRtree(int int_0)
		: base(int_0)
	{
	}

	public virtual void Insert(IEnvelope ienvelope_0, object object_0)
	{
		if (!ienvelope_0.IsNull)
		{
			base.Insert(ienvelope_0, object_0);
		}
	}

	public virtual IList Query(IEnvelope ienvelope_0)
	{
		return base.Query(ienvelope_0);
	}

	public virtual void Query(IEnvelope ienvelope_0, IItemVisitor iitemVisitor_0)
	{
		base.Query(ienvelope_0, iitemVisitor_0);
	}

	public virtual bool Remove(IEnvelope ienvelope_0, object object_0)
	{
		return base.Remove(ienvelope_0, object_0);
	}

	private static double ChangeParameter(double double_0, double double_1)
	{
		return (double_0 + double_1) / 2.0;
	}

	private static double InitParameter(IEnvelope ienvelope_0)
	{
		return ChangeParameter(ienvelope_0.Minimum.X, ienvelope_0.Maximum.X);
	}

	private static double CheckParameter(IEnvelope ienvelope_0)
	{
		return ChangeParameter(ienvelope_0.Minimum.Y, ienvelope_0.Maximum.Y);
	}

	protected override IList CreateParentBoundables(IList ilist_0, int int_0)
	{
		Assert.IsTrue(ilist_0.Count != 0);
		int num = (int)Math.Ceiling((double)ilist_0.Count / (double)NodeCapacity);
		ArrayList arrayList = new ArrayList(ilist_0);
		arrayList.Sort(new IdentifierMerchantService(this));
		IList[] ilist_ = VerticalSlices(arrayList, (int)Math.Ceiling(Math.Sqrt(num)));
		return ConcatParameter(ilist_, int_0);
	}

	private IList ConcatParameter(IList[] ilist_0, int int_0)
	{
		Assert.IsTrue(ilist_0.Length != 0);
		IList list = new ArrayList();
		for (int i = 0; i < ilist_0.Length; i++)
		{
			foreach (object item in CreateParentBoundablesFromVerticalSlice(ilist_0[i], int_0))
			{
				list.Add(item);
			}
		}
		return list;
	}

	protected virtual IList CreateParentBoundablesFromVerticalSlice(IList ilist_0, int int_0)
	{
		return base.CreateParentBoundables(ilist_0, int_0);
	}

	protected virtual IList[] VerticalSlices(IList ilist_0, int int_0)
	{
		int num = (int)Math.Ceiling((double)ilist_0.Count / (double)int_0);
		IList[] array = new IList[int_0];
		IEnumerator enumerator = ilist_0.GetEnumerator();
		for (int i = 0; i < int_0; i++)
		{
			array[i] = new ArrayList();
			for (int j = 0; j < num; j++)
			{
				if (!enumerator.MoveNext())
				{
					break;
				}
				IBoundable value = (IBoundable)enumerator.Current;
				array[i].Add(value);
			}
		}
		return array;
	}

	protected override AbstractNode CreateNode(int int_0)
	{
		return new ConfigCollectionTask(int_0);
	}

	protected override IComparer GetComparer()
	{
		return new ServerPrototype(this);
	}
}
