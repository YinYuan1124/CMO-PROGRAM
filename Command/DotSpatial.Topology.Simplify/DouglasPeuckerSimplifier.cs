using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Simplify;

public class DouglasPeuckerSimplifier
{
	private class SpecificationPrototype : GeometryTransformer
	{
		private readonly DouglasPeuckerSimplifier m_WatcherPrototype;

		public SpecificationPrototype(DouglasPeuckerSimplifier douglasPeuckerSimplifier_0)
		{
			m_WatcherPrototype = douglasPeuckerSimplifier_0;
		}

		protected override IList<Coordinate> TransformCoordinates(IList<Coordinate> ilist_0, IGeometry igeometry_0)
		{
			return DouglasPeuckerLineSimplifier.Simplify(ilist_0, m_WatcherPrototype.DistanceTolerance);
		}

		protected override IGeometry TransformPolygon(IPolygon ipolygon_0, IGeometry igeometry_0)
		{
			IGeometry geometry = base.TransformPolygon(ipolygon_0, igeometry_0);
			if (igeometry_0 is MultiPolygon)
			{
				return geometry;
			}
			return CollectInterruptibleMapping(geometry);
		}

		protected override IGeometry TransformMultiPolygon(IMultiPolygon imultiPolygon_0)
		{
			return CollectInterruptibleMapping(base.TransformMultiPolygon(imultiPolygon_0));
		}

		private static IGeometry CollectInterruptibleMapping(IGeometry igeometry_0)
		{
			return igeometry_0.Buffer(0.0);
		}
	}

	private readonly Geometry m_RepositoryThread;

	private double m_BridgeThread;

	public virtual double DistanceTolerance
	{
		get
		{
			return m_BridgeThread;
		}
		set
		{
			m_BridgeThread = value;
		}
	}

	public DouglasPeuckerSimplifier(Geometry geometry_0)
	{
		m_RepositoryThread = geometry_0;
	}

	public static IGeometry Simplify(Geometry geometry_0, double double_0)
	{
		return new DouglasPeuckerSimplifier(geometry_0)
		{
			DistanceTolerance = double_0
		}.GetResultGeometry();
	}

	public virtual IGeometry GetResultGeometry()
	{
		return new SpecificationPrototype(this).Transform(m_RepositoryThread);
	}
}
