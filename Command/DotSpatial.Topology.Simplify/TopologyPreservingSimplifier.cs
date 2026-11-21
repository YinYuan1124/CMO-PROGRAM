using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Simplify;

public class TopologyPreservingSimplifier
{
	private class ReponsePrototype : IGeometryComponentFilter
	{
		private readonly TopologyPreservingSimplifier m_DescriptorPrototype;

		public ReponsePrototype(TopologyPreservingSimplifier topologyPreservingSimplifier_0)
		{
			m_DescriptorPrototype = topologyPreservingSimplifier_0;
		}

		public void Filter(IGeometry igeometry_0)
		{
			if (igeometry_0 is LinearRing)
			{
				TaggedLineString value = new TaggedLineString((LineString)igeometry_0, 4);
				m_DescriptorPrototype._CustomerThread.Add(igeometry_0, value);
			}
			else if (igeometry_0 is LineString)
			{
				TaggedLineString value2 = new TaggedLineString((LineString)igeometry_0, 2);
				m_DescriptorPrototype._CustomerThread.Add(igeometry_0, value2);
			}
		}
	}

	private class ComparatorInstanceFilter : GeometryTransformer
	{
		private readonly TopologyPreservingSimplifier _PoolPrototype;

		public ComparatorInstanceFilter(TopologyPreservingSimplifier topologyPreservingSimplifier_0)
		{
			_PoolPrototype = topologyPreservingSimplifier_0;
		}

		protected override IList<Coordinate> TransformCoordinates(IList<Coordinate> ilist_0, IGeometry igeometry_0)
		{
			if (igeometry_0 is LineString)
			{
				return ((TaggedLineString)_PoolPrototype._CustomerThread[igeometry_0]).ResultCoordinates;
			}
			return base.TransformCoordinates(ilist_0, igeometry_0);
		}
	}

	private readonly IGeometry modelThread;

	private readonly TaggedLinesSimplifier advisorThread = new TaggedLinesSimplifier();

	private IDictionary _CustomerThread;

	public virtual double DistanceTolerance
	{
		get
		{
			return advisorThread.DistanceTolerance;
		}
		set
		{
			advisorThread.DistanceTolerance = value;
		}
	}

	public TopologyPreservingSimplifier(IGeometry igeometry_0)
	{
		modelThread = igeometry_0;
	}

	public static IGeometry Simplify(IGeometry igeometry_0, double double_0)
	{
		return new TopologyPreservingSimplifier(igeometry_0)
		{
			DistanceTolerance = double_0
		}.GetResultGeometry();
	}

	public virtual IGeometry GetResultGeometry()
	{
		_CustomerThread = new Hashtable();
		modelThread.Apply(new ReponsePrototype(this));
		advisorThread.Simplify(new ArrayList(_CustomerThread.Values));
		return new ComparatorInstanceFilter(this).Transform(modelThread);
	}
}
