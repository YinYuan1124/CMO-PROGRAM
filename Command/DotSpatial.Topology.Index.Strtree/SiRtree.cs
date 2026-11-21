using System;
using System.Collections;

namespace DotSpatial.Topology.Index.Strtree;

public class SiRtree : AbstractStRtree
{
	private class VisitorThreadBridge : IComparer
	{
		public int Compare(object x, object y)
		{
			return new SiRtree().CompareDoubles(((Interval)((IBoundable)x).Bounds).Centre, ((Interval)((IBoundable)y).Bounds).Centre);
		}
	}

	private class ResolverPrototype : AbstractNode
	{
		public ResolverPrototype(int int_0)
			: base(int_0)
		{
		}

		protected override object ComputeBounds()
		{
			Interval interval = null;
			IEnumerator enumerator = ChildBoundables.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IBoundable boundable = (IBoundable)enumerator.Current;
				if (interval == null)
				{
					interval = new Interval((Interval)boundable.Bounds);
				}
				else
				{
					interval.ExpandToInclude((Interval)boundable.Bounds);
				}
			}
			return interval;
		}
	}

	private class SpecificationDefinitionSpec : IIntersectsOp
	{
		public bool Intersects(object object_0, object object_1)
		{
			return ((Interval)object_0).Intersects((Interval)object_1);
		}
	}

	private readonly IComparer tagCollection = new VisitorThreadBridge();

	private readonly IIntersectsOp m_FieldCollection = new SpecificationDefinitionSpec();

	protected override IIntersectsOp IntersectsOp => m_FieldCollection;

	public SiRtree()
		: this(10)
	{
	}

	public SiRtree(int int_0)
		: base(int_0)
	{
	}

	protected override AbstractNode CreateNode(int int_0)
	{
		return new ResolverPrototype(int_0);
	}

	public virtual void Insert(double double_0, double double_1, object object_0)
	{
		base.Insert(new Interval(Math.Min(double_0, double_1), Math.Max(double_0, double_1)), object_0);
	}

	public virtual IList Query(double double_0)
	{
		return Query(double_0, double_0);
	}

	public virtual IList Query(double double_0, double double_1)
	{
		return base.Query(new Interval(Math.Min(double_0, double_1), Math.Max(double_0, double_1)));
	}

	protected override IComparer GetComparer()
	{
		return tagCollection;
	}
}
