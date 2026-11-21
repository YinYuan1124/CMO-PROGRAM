using System.Collections;

namespace DotSpatial.Topology.Index.Quadtree;

public class Quadtree : ISpatialIndex
{
	protected readonly Root Root;

	private double m_PolicyCollection = 1.0;

	public virtual int Depth
	{
		get
		{
			if (Root == null)
			{
				return 0;
			}
			return Root.Depth;
		}
	}

	public virtual int Count
	{
		get
		{
			if (Root == null)
			{
				return 0;
			}
			return Root.Count;
		}
	}

	public Quadtree()
	{
		Root = new Root();
	}

	public virtual void Insert(IEnvelope ienvelope_0, object object_0)
	{
		FillParameter(ienvelope_0);
		IEnvelope ienvelope_ = EnsureExtent(ienvelope_0, m_PolicyCollection);
		Root.Insert(ienvelope_, object_0);
	}

	public virtual bool Remove(IEnvelope ienvelope_0, object object_0)
	{
		IEnvelope ienvelope_ = EnsureExtent(ienvelope_0, m_PolicyCollection);
		return Root.Remove(ienvelope_, object_0);
	}

	public virtual IList Query(IEnvelope ienvelope_0)
	{
		ArrayListVisitor arrayListVisitor = new ArrayListVisitor();
		Query(ienvelope_0, arrayListVisitor);
		return arrayListVisitor.Items;
	}

	public virtual void Query(IEnvelope ienvelope_0, IItemVisitor iitemVisitor_0)
	{
		Root.Visit(ienvelope_0, iitemVisitor_0);
	}

	public static IEnvelope EnsureExtent(IEnvelope ienvelope_0, double double_0)
	{
		double num = ienvelope_0.Minimum.X;
		double num2 = ienvelope_0.Maximum.X;
		double num3 = ienvelope_0.Minimum.Y;
		double num4 = ienvelope_0.Maximum.Y;
		if (num != num2 && num3 != num4)
		{
			return ienvelope_0;
		}
		if (num == num2)
		{
			num -= double_0 / 2.0;
			num2 = num + double_0 / 2.0;
		}
		if (num3 == num4)
		{
			num3 -= double_0 / 2.0;
			num4 = num3 + double_0 / 2.0;
		}
		return new Envelope(num, num2, num3, num4);
	}

	public virtual IList QueryAll()
	{
		IList ilist_ = new ArrayList();
		Root.AddAllItems(ref ilist_);
		return ilist_;
	}

	private void FillParameter(IRectangle irectangle_0)
	{
		double width = irectangle_0.Width;
		if (width < m_PolicyCollection && width > 0.0)
		{
			m_PolicyCollection = width;
		}
		double width2 = irectangle_0.Width;
		if (width2 < m_PolicyCollection && width2 > 0.0)
		{
			m_PolicyCollection = width2;
		}
	}
}
