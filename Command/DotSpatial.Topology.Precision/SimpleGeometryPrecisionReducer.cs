using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Precision;

public class SimpleGeometryPrecisionReducer
{
	private class ResolverRegistryFilter : GeometryEditor.CoordinateOperation
	{
		private readonly SimpleGeometryPrecisionReducer _ContainerPrototype;

		public ResolverRegistryFilter(SimpleGeometryPrecisionReducer simpleGeometryPrecisionReducer_0)
		{
			_ContainerPrototype = simpleGeometryPrecisionReducer_0;
		}

		public override IList<Coordinate> Edit(IList<Coordinate> ilist_0, IGeometry igeometry_0)
		{
			if (ilist_0.Count == 0)
			{
				return null;
			}
			Coordinate[] array = new Coordinate[ilist_0.Count];
			for (int i = 0; i < ilist_0.Count; i++)
			{
				Coordinate coordinate = new Coordinate(ilist_0[i]);
				new PrecisionModel(_ContainerPrototype.m_StrategyThread).MakePrecise(coordinate);
				array[i] = coordinate;
			}
			Coordinate[] array2 = new CoordinateList(array, bool_0: false).ToCoordinateArray();
			int num = 0;
			if (igeometry_0 is LineString)
			{
				num = 2;
			}
			if (igeometry_0 is LinearRing)
			{
				num = 4;
			}
			Coordinate[] array3 = array;
			if (_ContainerPrototype.m_TokenThread)
			{
				array3 = null;
			}
			if (array2.Length < num)
			{
				return array3?.ToList();
			}
			return array2.ToList();
		}
	}

	private readonly PrecisionModel m_StrategyThread;

	private bool configurationThread;

	private bool m_TokenThread = true;

	public virtual bool RemoveCollapsedComponents
	{
		get
		{
			return m_TokenThread;
		}
		set
		{
			m_TokenThread = value;
		}
	}

	public virtual bool ChangePrecisionModel
	{
		get
		{
			return configurationThread;
		}
		set
		{
			configurationThread = value;
		}
	}

	public SimpleGeometryPrecisionReducer(PrecisionModel precisionModel_0)
	{
		m_StrategyThread = precisionModel_0;
	}

	public virtual IGeometry Reduce(IGeometry igeometry_0)
	{
		return (configurationThread ? new GeometryEditor(new GeometryFactory(m_StrategyThread)) : new GeometryEditor()).Edit(igeometry_0, new ResolverRegistryFilter(this));
	}
}
