using System;
using DotSpatial.Topology.Precision;

namespace DotSpatial.Topology.Operation.Buffer;

public class BufferOp
{
	private readonly IGeometry m_RecordRule;

	private double _ExceptionRule;

	private BufferStyle _AttrRule = BufferStyle.CapRound;

	private int m_VisitorRule = 8;

	private IGeometry m_ExporterRule;

	private TopologyException m_PrototypeRule;

	public virtual BufferStyle EndCapStyle
	{
		get
		{
			return _AttrRule;
		}
		set
		{
			_AttrRule = value;
		}
	}

	public virtual int QuadrantSegments
	{
		get
		{
			return m_VisitorRule;
		}
		set
		{
			m_VisitorRule = value;
		}
	}

	public BufferOp(IGeometry igeometry_0)
	{
		m_RecordRule = igeometry_0;
	}

	private static double RateInstance(IGeometry igeometry_0, double double_0, int int_0)
	{
		IEnvelope envelopeInternal = igeometry_0.EnvelopeInternal;
		double num = Math.Max(envelopeInternal.Height, envelopeInternal.Width);
		double num2 = ((double_0 <= 0.0) ? 0.0 : double_0);
		int num3 = (int)(Math.Log(num + 2.0 * num2) / Math.Log(10.0) + 1.0) - int_0;
		return Math.Pow(10.0, -num3);
	}

	public static IGeometry Buffer(IGeometry igeometry_0, double double_0)
	{
		return new BufferOp(igeometry_0).GetResultGeometry(double_0);
	}

	public static IGeometry Buffer(Geometry geometry_0, double double_0, BufferStyle bufferStyle_0)
	{
		return new BufferOp(geometry_0)
		{
			EndCapStyle = bufferStyle_0
		}.GetResultGeometry(double_0);
	}

	public static IGeometry Buffer(Geometry geometry_0, double double_0, int int_0)
	{
		return new BufferOp(geometry_0)
		{
			QuadrantSegments = int_0
		}.GetResultGeometry(double_0);
	}

	public static IGeometry Buffer(IGeometry igeometry_0, double double_0, int int_0, BufferStyle bufferStyle_0)
	{
		return new BufferOp(igeometry_0)
		{
			EndCapStyle = bufferStyle_0,
			QuadrantSegments = int_0
		}.GetResultGeometry(double_0);
	}

	public virtual IGeometry GetResultGeometry(double double_0)
	{
		_ExceptionRule = double_0;
		FlushInstance();
		return m_ExporterRule;
	}

	public virtual IGeometry GetResultGeometry(double double_0, int int_0)
	{
		_ExceptionRule = double_0;
		QuadrantSegments = int_0;
		FlushInstance();
		return m_ExporterRule;
	}

	private void FlushInstance()
	{
		ForgotInstance();
		if (m_ExporterRule != null)
		{
			return;
		}
		int num = 12;
		while (num >= 0)
		{
			try
			{
				CollectInstance(num);
			}
			catch (TopologyException prototypeRule)
			{
				m_PrototypeRule = prototypeRule;
			}
			if (m_ExporterRule == null)
			{
				num--;
				continue;
			}
			return;
		}
		throw m_PrototypeRule;
	}

	private void ForgotInstance()
	{
		try
		{
			BufferBuilder bufferBuilder = new BufferBuilder();
			bufferBuilder.QuadrantSegments = m_VisitorRule;
			bufferBuilder.EndCapStyle = _AttrRule;
			m_ExporterRule = bufferBuilder.Buffer(m_RecordRule, _ExceptionRule);
		}
		catch (TopologyException prototypeRule)
		{
			m_PrototypeRule = prototypeRule;
		}
	}

	private void CollectInstance(int int_0)
	{
		PrecisionModel precisionModel = new PrecisionModel(RateInstance(m_RecordRule, _ExceptionRule, int_0));
		IGeometry igeometry_ = new SimpleGeometryPrecisionReducer(precisionModel).Reduce(m_RecordRule);
		BufferBuilder bufferBuilder = new BufferBuilder();
		bufferBuilder.WorkingPrecisionModel = precisionModel;
		bufferBuilder.QuadrantSegments = m_VisitorRule;
		m_ExporterRule = bufferBuilder.Buffer(igeometry_, _ExceptionRule);
	}
}
