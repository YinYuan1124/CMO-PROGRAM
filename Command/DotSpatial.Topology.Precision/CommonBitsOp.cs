namespace DotSpatial.Topology.Precision;

public class CommonBitsOp
{
	private readonly bool m_ConnectionThread = true;

	private CommonBitsRemover m_ContextThread;

	public CommonBitsOp()
		: this(bool_0: true)
	{
	}

	public CommonBitsOp(bool bool_0)
	{
		m_ConnectionThread = bool_0;
	}

	public virtual IGeometry Intersection(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		IGeometry[] array = CountCollection(igeometry_0, igeometry_1);
		return ManageRule(array[0].Intersection(array[1]));
	}

	public virtual IGeometry Union(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		IGeometry[] array = CountCollection(igeometry_0, igeometry_1);
		return ManageRule(array[0].Union(array[1]));
	}

	public virtual IGeometry Difference(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		IGeometry[] array = CountCollection(igeometry_0, igeometry_1);
		return ManageRule(array[0].Difference(array[1]));
	}

	public virtual IGeometry SymDifference(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		IGeometry[] array = CountCollection(igeometry_0, igeometry_1);
		return ManageRule(array[0].SymmetricDifference(array[1]));
	}

	public virtual IGeometry Buffer(IGeometry igeometry_0, double double_0)
	{
		IGeometry geometry = RevertRule(igeometry_0);
		return ManageRule(geometry.Buffer(double_0));
	}

	private IGeometry ManageRule(IGeometry igeometry_0)
	{
		if (m_ConnectionThread)
		{
			m_ContextThread.AddCommonBits(igeometry_0);
		}
		return igeometry_0;
	}

	private IGeometry RevertRule(IGeometry igeometry_0)
	{
		m_ContextThread = new CommonBitsRemover();
		m_ContextThread.Add(igeometry_0);
		return m_ContextThread.RemoveCommonBits((Geometry)igeometry_0.Clone());
	}

	private IGeometry[] CountCollection(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		m_ContextThread = new CommonBitsRemover();
		m_ContextThread.Add(igeometry_0);
		m_ContextThread.Add(igeometry_1);
		IGeometry[] array2 = new Geometry[2];
		IGeometry[] array = array2;
		array[0] = m_ContextThread.RemoveCommonBits((Geometry)igeometry_0.Clone());
		array[1] = m_ContextThread.RemoveCommonBits((Geometry)igeometry_1.Clone());
		return array;
	}
}
