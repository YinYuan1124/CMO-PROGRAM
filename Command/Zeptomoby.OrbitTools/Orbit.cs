using System;
using System.Runtime.CompilerServices;
using Command.Lists;
using Command.Tasks;
using OpenDis.Producers;

namespace Zeptomoby.OrbitTools;

public sealed class Orbit
{
	private TimeSpan m_ListMerchant = new TimeSpan(0, 0, 0, -1);

	private double poolMerchant;

	private double taskMerchant;

	private double m_FilterMerchant;

	private double m_TestsMerchant;

	private double _InterpreterMerchant;

	private double _ContainerMerchant;

	private double _ComposerMerchant;

	private double m_ModelMerchant;

	private int _AdvisorMerchant;

	private int m_CustomerMerchant;

	private double serializerMerchant;

	private double refMerchant;

	private double errorMerchant;

	private double m_CodeMerchant;

	private double m_ConnectionMerchant;

	[CompilerGenerated]
	private Tle m_ContextMerchant;

	[CompilerGenerated]
	private MerchantProcessProducer statusMerchant;

	[CompilerGenerated]
	private Julian m_ProccesorMerchant;

	public string TleLine1 => Tle.Line1;

	public string TleLine2 => Tle.Line2;

	public Julian Epoch
	{
		[CompilerGenerated]
		get
		{
			return m_ProccesorMerchant;
		}
		[CompilerGenerated]
		private set
		{
			m_ProccesorMerchant = value;
		}
	}

	public DateTime EpochTime => Epoch.ToTime();

	public double SemiMajor => serializerMerchant;

	public double SemiMinor => refMerchant;

	public double MeanMotion => errorMerchant;

	public double Major => 2.0 * SemiMajor;

	public double Minor => 2.0 * SemiMinor;

	public double Perigee => m_CodeMerchant;

	public double Apogee => m_ConnectionMerchant;

	public double Inclination => poolMerchant;

	public double Eccentricity => taskMerchant;

	public double RAAN => m_FilterMerchant;

	public double ArgPerigee => m_TestsMerchant;

	public double BStar => _InterpreterMerchant;

	public double Drag => _ContainerMerchant;

	public double MeanAnomaly => _ComposerMerchant;

	public int RevAtEpoch => _AdvisorMerchant;

	public int TleSetNumber => m_CustomerMerchant;

	public string SatName => Tle.Name;

	public string SatNameLong => SatName + " #" + SatNoradId;

	public string SatNoradId => Tle.NoradNumber;

	public string IntlDesignator => Tle.IntlDesignator;

	public TimeSpan Period
	{
		get
		{
			if (m_ListMerchant.TotalSeconds < 0.0)
			{
				if (MeanMotion == 0.0)
				{
					m_ListMerchant = new TimeSpan(0, 0, 0);
				}
				else
				{
					double num = Math.PI * 2.0 / MeanMotion * 60.0;
					int milliseconds = (int)((num - (double)(int)num) * 1000.0);
					m_ListMerchant = new TimeSpan(0, 0, 0, (int)num, milliseconds);
				}
			}
			return m_ListMerchant;
		}
	}

	private Tle Tle
	{
		[CompilerGenerated]
		get
		{
			return m_ContextMerchant;
		}
		[CompilerGenerated]
		set
		{
			m_ContextMerchant = value;
		}
	}

	private MerchantProcessProducer NoradModel
	{
		[CompilerGenerated]
		get
		{
			return statusMerchant;
		}
		[CompilerGenerated]
		set
		{
			statusMerchant = value;
		}
	}

	private double TleMeanMotion => m_ModelMerchant;

	public Orbit(Tle tle_0)
	{
		Tle = tle_0;
		Epoch = Tle.EpochJulian;
		poolMerchant = GetRad(Tle.Field.Inclination);
		taskMerchant = Tle.GetField(Tle.Field.Eccentricity);
		m_FilterMerchant = GetRad(Tle.Field.Raan);
		m_TestsMerchant = GetRad(Tle.Field.ArgPerigee);
		_InterpreterMerchant = Tle.GetField(Tle.Field.const_14);
		_ContainerMerchant = Tle.GetField(Tle.Field.MeanMotionDt);
		_ComposerMerchant = GetRad(Tle.Field.MeanAnomaly);
		m_ModelMerchant = Tle.GetField(Tle.Field.MeanMotion);
		_AdvisorMerchant = (int)Tle.GetField(Tle.Field.RevAtEpoch);
		m_CustomerMerchant = (int)Tle.GetField(Tle.Field.SetNumber);
		double num = TleMeanMotion * (Math.PI * 2.0) / 1440.0;
		double num2 = Math.Pow(Globals.Xke / num, 2.0 / 3.0);
		double eccentricity = Eccentricity;
		double inclination = Inclination;
		double num3 = 0.00081196185 * (3.0 * Globals.Sqr(Math.Cos(inclination)) - 1.0) / Math.Pow(1.0 - eccentricity * eccentricity, 1.5);
		double num4 = num3 / (num2 * num2);
		double num5 = num2 * (1.0 - num4 * (1.0 / 3.0 + num4 * (1.0 + 1.654320987654321 * num4)));
		double num6 = num3 / (num5 * num5);
		errorMerchant = num / (1.0 + num6);
		serializerMerchant = num5 / (1.0 - num6);
		refMerchant = serializerMerchant * Math.Sqrt(1.0 - eccentricity * eccentricity);
		m_CodeMerchant = 6378.135 * (serializerMerchant * (1.0 - eccentricity) - 1.0);
		m_ConnectionMerchant = 6378.135 * (serializerMerchant * (1.0 + eccentricity) - 1.0);
		if (Period.TotalMinutes < 225.0)
		{
			NoradModel = new WriterMerchant(this);
		}
		else
		{
			NoradModel = new CustomerDispatcherList(this);
		}
	}

	public EciTime PositionEci(double double_0)
	{
		EciTime eciTime = NoradModel.ConcatInterruptibleBroadcaster(double_0);
		double double_ = 6378.135;
		eciTime.ScalePosVector(double_);
		eciTime.ScaleVelVector(106.30225);
		return eciTime;
	}

	public EciTime PositionEci(DateTime dateTime_0)
	{
		return PositionEci(method_0(dateTime_0).TotalMinutes);
	}

	public TimeSpan method_0(DateTime dateTime_0)
	{
		return dateTime_0 - EpochTime;
	}

	public TimeSpan method_1()
	{
		return method_0(DateTime.UtcNow);
	}

	protected double GetRad(Tle.Field field_0)
	{
		return Tle.GetField(field_0, Tle.Unit.Radians);
	}

	protected double GetDeg(Tle.Field field_0)
	{
		return Tle.GetField(field_0, Tle.Unit.Degrees);
	}
}
