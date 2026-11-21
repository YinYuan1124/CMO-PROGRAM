namespace DotSpatial.Topology.Precision;

public class CommonBitsRemover
{
	public class CommonCoordinateFilter : ICoordinateFilter
	{
		private readonly CommonBits _TaskPrototype = new CommonBits();

		private readonly CommonBits _FilterPrototype = new CommonBits();

		public virtual Coordinate CommonCoordinate => new Coordinate(_TaskPrototype.Common, _FilterPrototype.Common);

		public virtual void Filter(Coordinate coordinate_0)
		{
			_TaskPrototype.Add(coordinate_0.X);
			_FilterPrototype.Add(coordinate_0.Y);
		}
	}

	private class TestsPrototype : ICoordinateFilter
	{
		private readonly Coordinate _InterpreterPrototype;

		public TestsPrototype(Coordinate coordinate_0)
		{
			_InterpreterPrototype = coordinate_0;
		}

		public void Filter(Coordinate coordinate_0)
		{
			coordinate_0.X += _InterpreterPrototype.X;
			coordinate_0.Y += _InterpreterPrototype.Y;
		}
	}

	private readonly CommonCoordinateFilter m_StatusThread = new CommonCoordinateFilter();

	private Coordinate m_ProccesorThread;

	public virtual Coordinate CommonCoordinate => m_ProccesorThread;

	public virtual void Add(IGeometry igeometry_0)
	{
		igeometry_0.Apply(m_StatusThread);
		m_ProccesorThread = m_StatusThread.CommonCoordinate;
	}

	public virtual Geometry RemoveCommonBits(Geometry geometry_0)
	{
		if (m_ProccesorThread.X == 0.0 && m_ProccesorThread.Y == 0.0)
		{
			return geometry_0;
		}
		Coordinate coordinate = new Coordinate(m_ProccesorThread);
		coordinate.X = 0.0 - coordinate.X;
		coordinate.Y = 0.0 - coordinate.Y;
		TestsPrototype icoordinateFilter_ = new TestsPrototype(coordinate);
		geometry_0.Apply(icoordinateFilter_);
		geometry_0.GeometryChanged();
		return geometry_0;
	}

	public virtual void AddCommonBits(IGeometry igeometry_0)
	{
		TestsPrototype icoordinateFilter_ = new TestsPrototype(m_ProccesorThread);
		igeometry_0.Apply(icoordinateFilter_);
		igeometry_0.GeometryChanged();
	}
}
