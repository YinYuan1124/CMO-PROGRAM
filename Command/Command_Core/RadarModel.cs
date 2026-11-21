using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class RadarModel
{
	public enum TSurfaceType
	{
		st_Urban,
		st_Mountains,
		st_Cropland,
		st_Shrubland,
		st_Forest,
		st_Desert,
		st_Tundra,
		st_Grassland,
		st_Wetland
	}

	public enum TAntennaType
	{
		at_ITU_R_M1652,
		at_ITU_R_F1245,
		at_Sin_x_x,
		at_Coseq_Sq,
		at_Gaussian,
		at_Height_Finder_Generic,
		at_Height_Finder_Specific,
		at_Dipole,
		at_Phased_Array
	}

	public enum TPolarizationType
	{
		pt_Horizontal,
		pt_Vertical,
		pt_Circular
	}

	public enum TRadarCalcsType
	{
		rct_Simple_Pulsed,
		rct_Integrated_Incoherent,
		rct_Integrated_Coherent,
		rct_CW_Coherent,
		rct_Synthetic_Aperture
	}

	public enum TMultistaticRadarType
	{
		mrt_Incoherent,
		mrt_Coherent,
		mrt_Short_Term_Coherent
	}

	public enum TJammingType
	{
		None = 0,
		jt_Rebroadcast_Pulses_Azimouth_Shift = 1,
		jt_Rebroadcast_Pulses_Elevation_Shift = 2,
		jt_Rebroadcast_Pulses_Decrease = 4,
		jt_Inverse_Jamming = 8,
		jt_Double_Frequency = 0x10,
		jt_Cross_Polarization = 0x20,
		jt_Mirror_Channel = 0x40,
		jt_Multistatic_Coherent = 0x80,
		jt_Multistatic_Incoherent = 0x100,
		jt_Twinkling = 0x200,
		jt_Chaff_Illumination_Broadcast_Delay = 0x400,
		jt_Chaff_Illumination_Broadcast_Delay_Frequency_Shift = 0x800,
		jt_Reflection_Spot = 0x1000,
		jt_Multiple_Synchronous_Pulse = 0x2000,
		jt_Chaotic_Pulse = 0x4000,
		jt_Continuous = 0x8000,
		jt_VGPO = 0x10000,
		jt_RGPO = 0x20000
	}

	[Flags]
	public enum TECCMType
	{
		None = 0,
		et_Double_Pulse = 1,
		et_Rebroadcast_Delay_Detection = 2,
		et_Two_Narrow_Guard_Strobes = 4,
		et_Single_Guard_Strobe = 8,
		et_Pulse_Front_End_Tracking = 0x10,
		et_Pulse_Front_End_Extension = 0x20,
		et_Asymmetric_Strobe_Front_End_Tracking = 0x40,
		et_Pulse_Shortening = 0x80,
		et_Channel_Blanking = 0x100,
		et_Velocity_Guard_Strobes = 0x200,
		et_Velocity_Maintenance_Logic = 0x400,
		et_FFT_Spectrum_Analysis = 0x800,
		et_Double_Frequency_Concurrent = 0x1000,
		et_Double_Frequency_Consecutive = 0x2000,
		et_Triple_Channel_Frequency_Discriminator = 0x4000,
		et_Correlated_Velocity_Range_Processing = 0x8000,
		et_Steerable_Nulls = 0x10000
	}

	public struct TNATORadarBand
	{
		public double LoFreq;

		public double HiFreq;

		public double DefaultFreq;
	}

	public struct TMetricParams
	{
		public double h1;

		public double h2;

		public double range;

		public double Frequency;
	}

	public struct TOpticalParams
	{
		public double opmaxd;

		public double opmaxl;

		public double exloss;

		public double r1min;
	}

	public struct TAntennaParams
	{
		public TAntennaType AntennaType;

		public double antbwr;

		public double antelr;

		public double antfac;

		public double elmaxr;

		public double patrfac;
	}

	public struct TEvapDuctParams
	{
		public double C1;

		public double C2;

		public double C3;

		public double C4;

		public double C5;

		public double C6;

		public double C7;

		public double rfac;

		public double zmax;

		public double zfac;

		public double hmin;

		public double xterm;

		public double zterm;

		public double del;

		public double capk;

		public double difac;

		public double atten;
	}

	public struct TReflection
	{
		public double ReflectionCoeff;

		public double PhaseLag;
	}

	public interface IDoubleMatrix
	{
		double this[int int_0, int int_1] { get; set; }
	}

	public sealed class TSteerableNullSet
	{
		protected double[] m_Angles;

		protected double m_Width;

		protected double m_Level;

		public double[] Angles
		{
			get
			{
				return m_Angles;
			}
			set
			{
				m_Angles = value;
			}
		}

		public double Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				m_Width = value;
			}
		}

		public double Level
		{
			get
			{
				return m_Level;
			}
			set
			{
				m_Level = value;
			}
		}

		public TSteerableNullSet()
		{
			m_Angles = new double[0];
			m_Width = 1.0;
			m_Level = -50.0;
		}

		public TSteerableNullSet(int int_0)
		{
			m_Angles = new double[0];
			m_Angles = new double[int_0 - 1 + 1];
			m_Width = 1.0;
			m_Level = -50.0;
		}

		public TSteerableNullSet(int int_0, double double_0)
		{
			m_Angles = new double[0];
			m_Angles = new double[int_0 - 1 + 1];
			m_Width = double_0;
			m_Level = -50.0;
		}

		public TSteerableNullSet(int int_0, double double_0, double double_1)
		{
			m_Angles = new double[0];
			m_Angles = new double[int_0 - 1 + 1];
			m_Width = double_0;
			m_Level = double_1;
		}
	}

	public interface IEmitter
	{
		double Frequency { get; set; }

		double PowerOutputW { get; set; }

		double Altitude { get; set; }

		double VertBeamWidth { get; set; }

		double HorzBeamWidth { get; set; }

		double AntennaGain { get; set; }

		TSteerableNullSet SteerableNulls { get; set; }

		double ElevationAngle { get; set; }
	}

	public sealed class TRadar : IEmitter
	{
		private double _RadarVerBeamwidth;

		private double _RadarHorBeamwidth;

		private double Gain;

		private double m_HitsPerScan;

		protected double m_RangeResolution;

		protected double m_PRF;

		protected double m_PulseWidth;

		protected double m_MaximumUnambiguousRangeNM;

		protected double m_MinimumRangeNM;

		public float Altitude;

		private TSurfaceAndPeriscopeSearchCapability m_SingletonItem;

		public double Frequency;

		public double PowerOutputW;

		public double Velocity;

		protected double m_RecoveryTime;

		public double AntennaTemp;

		public double ReceiverTemp;

		protected double m_ProcessingGain;

		public double AntennaEfficiency;

		public double AzimuthLength;

		public double ElevationLength;

		public int RelativeSidelobeLevel;

		public int BacklobeLevel;

		public BitArray bitArray_0;

		public TAntennaType AntennaType;

		private double m_ScanRate;

		public double ElevationAngle;

		public TRadarCalcsType RadarCalculations;

		public TPolarizationType Polarization;

		public double FalseAlarmRate;

		protected TSteerableNullSet m_SteerableNulls;

		protected double _DetectionSNR_dB;

		protected double _TrackLossSNR_dB;

		public double RangeResolution => m_RangeResolution;

		public double PRF
		{
			get
			{
				return m_PRF;
			}
			set
			{
				m_PRF = value;
				if (value <= 0.0)
				{
					m_MaximumUnambiguousRangeNM = Math.Sqrt(-1.0);
					return;
				}
				m_MaximumUnambiguousRangeNM = 299792458.0 / (2.0 * value) / 1852.0;
				if (ScanRate <= 0.0)
				{
					m_HitsPerScan = Math.Sqrt(-1.0);
				}
				else
				{
					m_HitsPerScan = HorzBeamWidth * value / (6.0 * ScanRate);
				}
			}
		}

		public double PulseWidth
		{
			get
			{
				return m_PulseWidth;
			}
			set
			{
				m_PulseWidth = value;
				m_RangeResolution = 299792458.0 * value * 1E-06 / 2.0;
				if (m_PulseWidth == 1000.0)
				{
					m_MinimumRangeNM = 0.0;
				}
				else
				{
					m_MinimumRangeNM = WriteInterruptibleReg();
				}
			}
		}

		public double MaximumUnambiguousRangeNM => m_MaximumUnambiguousRangeNM;

		public double MinimumRangeNM => m_MinimumRangeNM;

		double IEmitter.Altitude
		{
			get
			{
				return Altitude;
			}
			set
			{
				Altitude = (int)Math.Round(value);
			}
		}

		public TSurfaceAndPeriscopeSearchCapability SurfaceAndPeriscopeSearchCapability
		{
			get
			{
				return m_SingletonItem;
			}
			set
			{
				m_SingletonItem = value;
			}
		}

		double IEmitter.Frequency
		{
			get
			{
				return Frequency;
			}
			set
			{
				Frequency = value;
			}
		}

		double IEmitter.PowerOutputW
		{
			get
			{
				return PowerOutputW;
			}
			set
			{
				PowerOutputW = value;
			}
		}

		public double RecoveryTime
		{
			get
			{
				return m_RecoveryTime;
			}
			set
			{
				m_RecoveryTime = value;
				m_MinimumRangeNM = WriteInterruptibleReg();
			}
		}

		public double ProcessingGain
		{
			get
			{
				return m_ProcessingGain;
			}
			set
			{
				m_ProcessingGain = value;
			}
		}

		public double AntennaGain
		{
			get
			{
				if (double.IsNaN(Gain))
				{
					if (!double.IsNaN(_RadarVerBeamwidth) && !double.IsNaN(_RadarHorBeamwidth))
					{
						Gain = 10.0 * Math.Log10(12.56637061435916 / (2.0 * Math.Sin(HorzBeamWidth * 0.0174532925199433 / 2.0) * VertBeamWidth * 0.0174532925199433));
						return Gain;
					}
					return Gain;
				}
				return Gain;
			}
			set
			{
				Gain = value;
				if (double.IsNaN(_RadarVerBeamwidth) && !double.IsNaN(_RadarHorBeamwidth))
				{
					_RadarVerBeamwidth = 12.56637061435916 / (Math.Pow(10.0, value / 10.0) * 2.0 * Math.Sin(_RadarHorBeamwidth * 0.0174532925199433 / 2.0) * 0.0174532925199433);
				}
				if (double.IsNaN(_RadarHorBeamwidth) && !double.IsNaN(_RadarVerBeamwidth))
				{
					_RadarHorBeamwidth = 2.0 * Math.Asin(12.56637061435916 / (Math.Pow(10.0, value / 10.0) * 2.0 * _RadarVerBeamwidth * 0.0174532925199433)) / 0.0174532925199433;
				}
			}
		}

		public double ScanRate
		{
			get
			{
				return m_ScanRate;
			}
			set
			{
				m_ScanRate = value;
				if (!(value <= 0.0) && !(PRF <= 0.0) && ScanRate > 0.0)
				{
					m_HitsPerScan = HorzBeamWidth * PRF / (6.0 * value);
				}
				else
				{
					m_HitsPerScan = Math.Sqrt(-1.0);
				}
			}
		}

		public double HorzBeamWidth
		{
			get
			{
				return _RadarHorBeamwidth;
			}
			set
			{
				_RadarHorBeamwidth = value;
				if (!(ScanRate <= 0.0) && PRF > 0.0)
				{
					m_HitsPerScan = value * PRF / (6.0 * ScanRate);
				}
				else
				{
					m_HitsPerScan = Math.Sqrt(-1.0);
				}
			}
		}

		public double VertBeamWidth
		{
			get
			{
				return _RadarVerBeamwidth;
			}
			set
			{
				_RadarVerBeamwidth = value;
			}
		}

		double IEmitter.ElevationAngle
		{
			get
			{
				return ElevationAngle;
			}
			set
			{
				ElevationAngle = value;
			}
		}

		public TSteerableNullSet SteerableNulls
		{
			get
			{
				return m_SteerableNulls;
			}
			set
			{
				m_SteerableNulls = value;
			}
		}

		public double HitsPerScan
		{
			get
			{
				if (ScanRate == 0.0)
				{
					throw new Exception("Zero scan rate! Can't measure hits per scan");
				}
				return m_HitsPerScan;
			}
		}

		public double SystemLoss
		{
			get
			{
				return 0.0 - ProcessingGain;
			}
			set
			{
				ProcessingGain = 0.0 - value;
			}
		}

		public double SystemNoiseLevel
		{
			get
			{
				return Math.Log10((AntennaTemp + ReceiverTemp) / 290.0) * 10.0;
			}
			set
			{
				AntennaTemp = 40.0;
				ReceiverTemp = Math.Pow(10.0, value / 10.0) * 290.0 - AntennaTemp;
			}
		}

		public TRadar()
		{
			m_MinimumRangeNM = 0.0;
			_DetectionSNR_dB = 0.0;
			_TrackLossSNR_dB = 0.0;
			ReceiverTemp = 275.0;
			AntennaTemp = 15.0;
			RecoveryTime = 0.0;
			Altitude = 10f;
			PRF = 100.0;
			ScanRate = 6.0;
			AntennaType = TAntennaType.at_Sin_x_x;
			Polarization = TPolarizationType.pt_Horizontal;
			RadarCalculations = TRadarCalcsType.rct_Simple_Pulsed;
			ElevationAngle = 0.0;
			FalseAlarmRate = 1E-06;
			Gain = Math.Sqrt(-1.0);
			_RadarVerBeamwidth = 0.0;
			_RadarHorBeamwidth = Math.Sqrt(-1.0);
			SteerableNulls = new TSteerableNullSet();
			SurfaceAndPeriscopeSearchCapability = TSurfaceAndPeriscopeSearchCapability.None;
		}

		internal double WriteInterruptibleReg()
		{
			if (m_PulseWidth == 0.0)
			{
				return 0.0;
			}
			return 299792458.0 * (m_PulseWidth + m_RecoveryTime) * 1E-06 * 0.5 / 1852.0;
		}

		internal double NewInterruptibleReg()
		{
			if (PRF == 0.0)
			{
				throw new Exception("Zero PRF! Can't measure duty cycle");
			}
			return PulseWidth * 1E-06 * PRF;
		}

		public void AdjustAntennaGain(float float_0)
		{
			if (!double.IsNaN(Gain))
			{
				Gain *= float_0;
			}
		}

		internal double PushInterruptibleReg(double double_0, bool bool_0 = true)
		{
			try
			{
				double falseAlarmRate = FalseAlarmRate;
				double num = 2.36 * Math.Sqrt(0.0 - Math.Log10(falseAlarmRate)) - 1.02;
				double num2 = 0.9 * (2.0 * double_0 - 1.0);
				double num3 = 1.23 * num2 / Math.Sqrt(1.0 - num2 * num2);
				double num4 = (num + num3) * (num + num3);
				double num5 = (bool_0 ? (1.0 / ((0.0 - Math.Log(double_0)) * (1.0 + num3 / num))) : 1.0);
				if (RadarCalculations == TRadarCalcsType.rct_Integrated_Coherent)
				{
					return num5 * num4 * (1.0 + Math.Sqrt(1.0 + 16.0 / num4)) / (4.0 * HitsPerScan);
				}
				return num5 * num4 * (1.0 + Math.Sqrt(1.0 + 16.0 * HitsPerScan / num4)) / (4.0 * HitsPerScan);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200099", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0.0;
			}
		}

		internal double InvokeInterruptibleReg()
		{
			switch (RadarCalculations)
			{
			default:
				return 0.0;
			case TRadarCalcsType.rct_Simple_Pulsed:
				return PulseWidth * 1E-06;
			case TRadarCalcsType.rct_Integrated_Incoherent:
			case TRadarCalcsType.rct_Integrated_Coherent:
				return HitsPerScan * PulseWidth * 1E-06;
			case TRadarCalcsType.rct_CW_Coherent:
				return HorzBeamWidth / (ScanRate / 6.0);
			case TRadarCalcsType.rct_Synthetic_Aperture:
				return Math.Sqrt(-1.0);
			}
		}

		public void SetGainFromBeamwidth(double RadarHorBeamwidth, double RadarVerBeamwidth)
		{
			_RadarHorBeamwidth = RadarHorBeamwidth;
			_RadarVerBeamwidth = RadarVerBeamwidth;
			double d = 12.56637061435916 / (2.0 * Math.Sin(RadarHorBeamwidth * 0.0174532925199433 / 2.0) * RadarVerBeamwidth * 0.0174532925199433);
			Gain = 10.0 * Math.Log10(d);
		}

		public void SetHorzBeamwidth(double double_0, double double_1)
		{
			Gain = double_1;
			_RadarVerBeamwidth = double_0;
			_RadarHorBeamwidth = 2.0 * Math.Asin(12.56637061435916 / (Math.Pow(10.0, Gain / 10.0) * 2.0 * _RadarVerBeamwidth * 0.0174532925199433)) / 0.0174532925199433;
		}

		public void SetVertBeamwidth(double double_0, double double_1)
		{
			Gain = double_1;
			_RadarHorBeamwidth = double_0;
			_RadarVerBeamwidth = 12.56637061435916 / (Math.Pow(10.0, Gain / 10.0) * 2.0 * Math.Sin(_RadarHorBeamwidth * 0.0174532925199433 / 2.0) * 0.0174532925199433);
		}
	}

	public sealed class TJammer : IEmitter
	{
		private float m_Altitude;

		private double m_AntennaGain;

		protected double m_HorzBeamWidth;

		private double m_PowerOutputW;

		private double m_Bandwidth;

		protected double _FrequencyHz;

		public double Altitude
		{
			get
			{
				return m_Altitude;
			}
			set
			{
				m_Altitude = (int)Math.Round(value);
			}
		}

		public double AntennaGain
		{
			get
			{
				return m_AntennaGain;
			}
			set
			{
				m_AntennaGain = value;
				m_HorzBeamWidth = 9.869604401089338 / Math.Pow(10.0, ((IEmitter)this).AntennaGain / 10.0) * 57.2957795130823;
			}
		}

		public double PowerOutputW
		{
			get
			{
				return m_PowerOutputW;
			}
			set
			{
				m_PowerOutputW = value;
			}
		}

		public double Bandwidth
		{
			get
			{
				return m_Bandwidth;
			}
			set
			{
				m_Bandwidth = value;
			}
		}

		public double ElevationAngle
		{
			get
			{
				return 0.0;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to set elevation angle!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200222", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}

		public double Frequency
		{
			get
			{
				return _FrequencyHz;
			}
			set
			{
				_FrequencyHz = value;
			}
		}

		public double HorzBeamWidth
		{
			get
			{
				return m_HorzBeamWidth;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to enter beamwidth for jammers directly!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200223", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}

		public TSteerableNullSet SteerableNulls
		{
			get
			{
				return null;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to add steerable null support to jammers!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200224", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}

		public double VertBeamWidth
		{
			get
			{
				return m_HorzBeamWidth;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to enter beamwidth for jammers directly!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200225", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}
	}

	public struct TReceiver
	{
		public float Altitude;

		public double Sensitivity;

		public double SystemLoss;

		public BitArray bitArray_0;

		public double SearchSpeed;

		public double ChannelBandwidth;

		public int NumChannels;
	}

	public sealed class TTarget
	{
		public float Altitude;

		public double RCS;

		public double RadialVelocity;

		public TTargetType ObjectType;

		public double Height;

		public double DeckHeight;

		public double RCS_m2
		{
			get
			{
				return Math.Pow(10.0, RCS / 10.0);
			}
			set
			{
				RCS = 10.0 * Math.Log10(value);
			}
		}

		public TTarget()
		{
			ObjectType = TTargetType.tgt_Unknown;
			Height = 0.0;
			DeckHeight = 0.0;
		}
	}

	public enum TTargetType
	{
		tgt_Unknown,
		tgt_FixedWingAircraft,
		tgt_RotaryWingAircraft,
		tgt_SurfaceShip,
		tgt_Satellite,
		tgt_ReentryVehicle,
		tgt_GroundVehicle,
		tgt_GroundFacility
	}

	public enum TSurfaceAndPeriscopeSearchCapability
	{
		None,
		Basic,
		FineRangeResolution,
		AdvancedProcessing
	}

	public enum TPhaseShifterType
	{
		pst_TrueTimeDelay,
		pst_ConstPhase,
		pst_ConstLength
	}

	public sealed class TPhasedArray
	{
		public TPhaseShifterType PhaseShifter;

		public int NumBits;

		public int LSB;

		public double CenterFrequency;

		public double OperatingFrequency;

		public double ElementSpacing;

		private int prototypeItem;

		public int NumElements
		{
			get
			{
				return prototypeItem;
			}
			set
			{
				if ((double)value / 2.0 == Conversion.Fix((double)value / 2.0))
				{
					throw new Exception("Number of phased array elements shall be odd");
				}
				prototypeItem = value;
			}
		}

		public TPhasedArray()
		{
			PhaseShifter = TPhaseShifterType.pst_TrueTimeDelay;
			NumElements = 11;
		}

		private double SetupInterruptibleReg(double double_0, double double_1)
		{
			double num = 299792458.0 / CenterFrequency * 100.0;
			double num2 = 299792458.0 / OperatingFrequency * 100.0;
			double a = double_0 * 0.0174532925199433;
			double num3 = 0.0;
			int num4 = -(int)Math.Round((double)(NumElements - 1) / 2.0);
			int num5 = (int)Math.Round((double)(NumElements - 1) / 2.0);
			double num6 = 0.0;
			for (int i = num4; i <= num5; i++)
			{
				double num7 = (double)i * 2.0 * 3.14159265358979 * ElementSpacing / num * Math.Sin(a) * 57.2957795130823;
				double double_2 = Math.Abs(num7 - 360.0 * Conversion.Fix(num7 / 360.0));
				switch (PhaseShifter)
				{
				case TPhaseShifterType.pst_TrueTimeDelay:
					num6 = num7 * OperatingFrequency / CenterFrequency;
					break;
				case TPhaseShifterType.pst_ConstPhase:
				{
					double num8 = PatchWriter(double_2, LSB);
					if (num8 >= 359.9)
					{
						num8 = 0.0;
					}
					num6 = num8 * OperatingFrequency / CenterFrequency;
					break;
				}
				case TPhaseShifterType.pst_ConstLength:
					num6 = PatchWriter(double_2, LSB);
					if (num6 >= 359.9)
					{
						num6 = 0.0;
					}
					break;
				}
				double num9 = num6 * 0.0174532925199433;
				num3 += Math.Cos(num9 - (double)i * 2.0 * 3.14159265358979 * ElementSpacing / num2 * Math.Sin(double_1 * 0.0174532925199433));
			}
			return num3 / (double)NumElements;
		}

		internal double ExcludeInterruptibleReg(double double_0, double double_1)
		{
			double num = SetupInterruptibleReg(double_0, double_1);
			double num2 = SetupInterruptibleReg(double_0, double_0);
			return 20.0 * Math.Log10(num / num2);
		}
	}

	public sealed class TChaffCloud
	{
		public double BundlesPerMinute;

		public double DipolesPerBundle;

		public int AircraftSpeed;

		public float ReleaseAltitude;

		public TChaffCloud(int int_0, float float_0, double double_0, double double_1)
		{
			BundlesPerMinute = double_0;
			ReleaseAltitude = float_0;
			AircraftSpeed = int_0;
			DipolesPerBundle = double_1;
		}

		internal double IncludeInterruptibleReg(int int_0)
		{
			double num = int_0;
			double num2 = 60.0;
			double num3 = num + num2;
			double num4;
			if (num3 * 1.3 <= (double)ReleaseAltitude)
			{
				num4 = num3 * 0.9;
			}
			else
			{
				if (!(num3 * 0.4 <= (double)ReleaseAltitude))
				{
					return 0.0;
				}
				num4 = (double)ReleaseAltitude - num3 * 0.4;
			}
			double num5 = num2 * (double)AircraftSpeed * 1852.0 / 3600.0;
			double num6 = num5 + num3 * 0.05;
			double num7 = num5 + num3 * 0.2;
			double num8 = num3 * 0.05;
			double num9 = num3 * 0.2;
			return num4 * (num6 * num8 + (num6 + num7) * (num8 + num9) + num7 * num9) / 6.0;
		}

		internal double SearchInterruptibleReg(int int_0)
		{
			double num = IncludeInterruptibleReg(int_0);
			double num2;
			if (num < 1E-12)
			{
				num2 = 0.0;
			}
			else
			{
				double num3 = 1.0;
				if ((double)(int_0 + 60) * 1.3 > (double)ReleaseAltitude)
				{
					double num4 = IncludeInterruptibleReg((int)Math.Round((double)ReleaseAltitude / 1.3));
					num3 = num / num4;
				}
				num2 = BundlesPerMinute * DipolesPerBundle * num3 * 60.0 / 60.0 / num;
				if (num2 < 0.1)
				{
					num2 = 0.0;
				}
			}
			return num2;
		}

		internal bool EnableInterruptibleReg(int int_0)
		{
			if (SearchInterruptibleReg(int_0) < 1E-12)
			{
				return true;
			}
			return false;
		}

		internal int ChangeInterruptibleReg(int int_0)
		{
			return (int)Math.Round(0.4 * (double)(int_0 + 60));
		}

		internal int InitInterruptibleReg(int int_0)
		{
			return Math.Min((int)Math.Round(1.3 * (double)(int_0 + 60)), 0);
		}

		internal double CheckInterruptibleReg(int int_0)
		{
			return (60.0 * (double)AircraftSpeed * 1852.0 / 3600.0 + (double)(int_0 + 60) * 0.25 / 2.0) / 1852.0;
		}
	}

	public enum RadarClutterType
	{
		None,
		Ground,
		Sea
	}

	public const string ModuleCredits = "Rodney Spence and Glenn Feldhake of NASA (propagation code)\r\nProf. David C. Jenn of NPS (radjam code)\r\nMicrowaves101 - phased array plot\r\nRaafat Nasser (U.S. Dept of Commerce) - RCG-44\r\nW.L.Patterson, C.P.Hattan, G.E.Lindem, Richard A.Paulus,  H.V.Hitney, K.D.Anderson, Amalia E.Barrios  - EREPS V.3.0 user manual. Tech.Doc.2648. San Diego, May 1994.\r\nAmalia E. Barrios, W. L. Patterson. - Advanced Propagation Model  Ver.1.3.1 CSCI Documents Tech.Doc.3145. San Diego, August 2002.\r\nAREPS User Manual V.3.6. San Diego, December 2006.\r\nHerr Alfred Ochs (Peter-Behrens-Str. 14, D-6100 Darmstadt) - the neat rain attenuation model from  the COST 210 Hydrometeor Scatter Prediction Procedure\r\nSources: ITU-R F.1245-1; ITU-R M.1652, miscellaneous files from ITU-R\r\nH.T.Dougherty, E.J.Dutton, 1981 NTIA Report 81-69\r\nRadar Technology Encyclopedia, 1998. David K. Barton, Sergey A. Leonov (eds.) \r\nKuzmin, 1974\r\nF.B.Chernyi. Rasprostranenie radiovoln. 2nd ed. M., 1972\r\nA.I.Kupriyanov, A.V.Sakharov. Teoreticheskiye osnovy radioelektronnoy borby. M., 2007\r\nYu.P.Melnikov. Vozdushnaya radiotekhnicheskaya razvedka. M., 2005\r\nV.G.Radzievsky (ed.) Sovremennaya radioelectronnaya borba. M., 2006\r\nA.I.Kanaschenkov, V.I.Merkulov (eds.) Zaschita radiolokatsionnykh sistem ot pomekh. M., 2003\r\nMichale O. Kolawole (2002) Radar Systems, Peak Detection and Tracking. Oxford, UK. 388 p.\r\nRadar Handbook (2nd and 3rd eds.) Edited by Merrill I. Skolnik.\r\nElectronic Warfare and Radar Systems Engineering Handbook\r\nV.I.Borisov, V.M.Zinchuk, A.E.Limarev. Pomekhozaschischennost' sistem radiosvyazi s rasshireniyem spektra signalov metodom PPRCh. M., 2008.";

	public const string ModuleVersion = "Version 2.03";

	public const double KW = 1000.0;

	public const double MHz = 1000000.0;

	public const double GHz = 1000000000.0;

	public static int NumberOfJammingTypes;

	public const double ThresholdSNR = 0.0;

	public const double ConstFalseAlarmRate = 1E-06;

	public const double ManualFalseAlarmRate = 0.001;

	public const double VoiceDetectabilityThresholdSNR = -15.8503;

	public const double ReflectionCoeff_Magnitude = 1.0;

	public const double ReflectionCoeff_PhaseLag = 3.14159265358979;

	static RadarModel()
	{
		NumberOfJammingTypes = Enum.GetValues(typeof(TJammingType)).Length - 1;
	}

	internal static bool UpdateStub(TJammingType tjammingType_0, TECCMType teccmtype_0)
	{
		switch (tjammingType_0)
		{
		default:
			return false;
		case TJammingType.jt_Rebroadcast_Pulses_Azimouth_Shift:
		case TJammingType.jt_Rebroadcast_Pulses_Elevation_Shift:
		case TJammingType.jt_Rebroadcast_Pulses_Decrease:
		case TJammingType.jt_Inverse_Jamming:
		case TJammingType.jt_Double_Frequency:
		case TJammingType.jt_Cross_Polarization:
		case TJammingType.jt_Mirror_Channel:
		case TJammingType.jt_Multistatic_Coherent:
		case TJammingType.jt_Multistatic_Incoherent:
		case TJammingType.jt_Twinkling:
		case TJammingType.jt_Chaff_Illumination_Broadcast_Delay:
		case TJammingType.jt_Chaff_Illumination_Broadcast_Delay_Frequency_Shift:
		case TJammingType.jt_Reflection_Spot:
		case TJammingType.jt_Multiple_Synchronous_Pulse:
		case TJammingType.jt_Chaotic_Pulse:
		case TJammingType.jt_Continuous:
		case TJammingType.jt_VGPO:
			return false;
		}
	}

	internal static bool InsertStub(TRadar Radar, TTarget Target, int NumJammers, TJammer[] Jammers, double DistanceToTarget, double[] DistancesToJammers, double[] AzimouthsToJammers, Weather.WeatherProfile Env, RadarClutterType radarClutterType_0, GlobalVariables.TechGenerationClass techGenerationClass_0, double ChaffDensity, double ChaffCloudThickness, ref TRadar RadarRecciver, double RecciverDistanceToDistance = 0.0, TSurfaceType tsurfaceType_0 = TSurfaceType.st_Cropland, double MaxTerrainSlope = 0.0)
	{
		try
		{
			bool flag = false;
			if (RadarRecciver != null)
			{
				flag = true;
			}
			double[] array = new double[NumJammers - 1 + 1];
			if (DistanceToTarget <= 0.0)
			{
				return false;
			}
			if (!flag && DistanceToTarget <= Radar.MinimumRangeNM)
			{
				return false;
			}
			if (Radar.PulseWidth == 0.0 && Radar.ScanRate == 0.0)
			{
				throw new Exception("零脉冲宽度和零扫描，无法计算探测 - 未实现的照射器");
			}
			if (Radar.AntennaGain == 0.0)
			{
				throw new Exception("零天线增益，无法计算探测");
			}
			if (Radar.HorzBeamWidth != 0.0 && Radar.VertBeamWidth != 0.0)
			{
				if (Radar.Frequency == 0.0)
				{
					throw new Exception("零频率，无法计算探测");
				}
				if (Radar.PulseWidth == 0.0)
				{
					throw new Exception("零脉宽, 无法计算探测");
				}
				if (Radar.PowerOutputW == 0.0)
				{
					throw new Exception("零输出功率, 无法计算探测");
				}
				if (flag)
				{
					if (RecciverDistanceToDistance <= 0.0)
					{
						throw new Exception("接收器在目标之上。为什么要使用雷达 - 只需要一个好的引信！");
					}
					if (RadarRecciver.AntennaGain == 0.0)
					{
						throw new Exception("零接收天线增益，无法计算探测");
					}
					if (RadarRecciver.HorzBeamWidth == 0.0 || RadarRecciver.VertBeamWidth == 0.0)
					{
						throw new Exception("零接收波束宽度，无法计算探测");
					}
				}
				double radarAntennaGain = Math.Pow(10.0, Radar.AntennaGain / 10.0);
				double waveLength = 299792458.0 / Radar.Frequency;
				double PulseWidth = Radar.InvokeInterruptibleReg();
				double BandWidth = 1.0 / PulseWidth;
				double m_Radar_Receive_BandWidth = 0.0;
				double DistanceToTarget_KM;
				for (int i = 0; i < NumJammers; i++)
				{
					double JammerAntennaGain = Math.Pow(10.0, Jammers[i].AntennaGain / 10.0);
					double m_Jam_RadarAntennaGain;
					if (flag)
					{
						double Azimouth2 = AzimouthsToJammers[i];
						double antennaGain = RadarRecciver.AntennaGain;
						double horzBeamWidth = RadarRecciver.HorzBeamWidth;
						TRadar tRadar;
						TSteerableNullSet tsteerableNullSet_ = (tRadar = RadarRecciver).SteerableNulls;
						double Jam_RadarAntennaGain2 = ListStub(Azimouth2, antennaGain, horzBeamWidth, ref tsteerableNullSet_);
						tRadar.SteerableNulls = tsteerableNullSet_;
						m_Jam_RadarAntennaGain = Jam_RadarAntennaGain2;
					}
					else
					{
						double Azimouth = AzimouthsToJammers[i];
						double antennaGain2 = Radar.AntennaGain;
						double horzBeamWidth2 = Radar.HorzBeamWidth;
						TRadar tRadar2;
						TSteerableNullSet tsteerableNullSet_2 = (tRadar2 = Radar).SteerableNulls;
						double Jam_RadarAntennaGain = ListStub(Azimouth, antennaGain2, horzBeamWidth2, ref tsteerableNullSet_2);
						tRadar2.SteerableNulls = tsteerableNullSet_2;
						m_Jam_RadarAntennaGain = Jam_RadarAntennaGain;
					}
					double m_Jam_RadarAntennaGainConst = Math.Pow(10.0, m_Jam_RadarAntennaGain / 10.0);
					double m_PropagationLossConst;
					if (flag)
					{
						DistanceToTarget_KM = DistancesToJammers[i] * 1852.0 / 1000.0;
						m_PropagationLossConst = Math.Pow(10.0, CloneWriter(RadarRecciver.Altitude, Jammers[i].Altitude, Radar.Frequency, RadarRecciver.VertBeamWidth, RadarRecciver.ElevationAngle, DistanceToTarget_KM, ref Env) / 10.0);
					}
					else
					{
						DistanceToTarget_KM = DistancesToJammers[i] * 1852.0 / 1000.0;
						m_PropagationLossConst = Math.Pow(10.0, CloneWriter(Radar.Altitude, Jammers[i].Altitude, Radar.Frequency, Radar.VertBeamWidth, Radar.ElevationAngle, DistanceToTarget_KM, ref Env) / 10.0);
					}
					switch (Radar.RadarCalculations)
					{
					case TRadarCalcsType.rct_Simple_Pulsed:
						m_Radar_Receive_BandWidth = Jammers[i].Bandwidth / 1E-06;
						break;
					case TRadarCalcsType.rct_Integrated_Incoherent:
					case TRadarCalcsType.rct_Integrated_Coherent:
						m_Radar_Receive_BandWidth = Radar.HitsPerScan * Jammers[i].Bandwidth / 1E-06;
						break;
					case TRadarCalcsType.rct_CW_Coherent:
						m_Radar_Receive_BandWidth = Jammers[i].Bandwidth / (Radar.ScanRate / 6.0);
						break;
					case TRadarCalcsType.rct_Synthetic_Aperture:
						m_Radar_Receive_BandWidth = Math.Sqrt(-1.0);
						break;
					}
					double num13 = Jammers[i].PowerOutputW * JammerAntennaGain * m_Jam_RadarAntennaGainConst * (BandWidth / m_Radar_Receive_BandWidth) / m_PropagationLossConst;
					array[i] = num13 / (1.380650424E-23 * BandWidth);
				}
				double num14 = 0.0;
				for (int j = 0; j < NumJammers; j++)
				{
					if (array[j] > num14)
					{
						num14 = array[j];
					}
				}
				double num15 = (flag ? (RadarRecciver.AntennaTemp + RadarRecciver.ReceiverTemp + num14) : (Radar.AntennaTemp + Radar.ReceiverTemp + num14));
				double num16 = 1.380650424E-23 * num15 * BandWidth;
				double minCanDetectPower = 1.0 * num16;
				double ProcessingGainConst = (flag ? Math.Pow(10.0, RadarRecciver.ProcessingGain / 10.0) : Math.Pow(10.0, Radar.ProcessingGain / 10.0));
				double targetHeight = Math.Max(Target.Altitude, Target.Height);
				DistanceToTarget_KM = DistanceToTarget * 1852.0 / 1000.0;
				double num20;
				if (flag)
				{
					double double_8 = Math.Max(RecciverDistanceToDistance, Geodesic_Vincenty.ConcatInvocation(RecciverDistanceToDistance, RadarRecciver.Altitude, targetHeight)) * 1852.0 / 1000.0;
					double num17 = CloneWriter(Radar.Altitude, targetHeight, Radar.Frequency, Radar.VertBeamWidth, Radar.ElevationAngle, DistanceToTarget_KM, ref Env);
					double num18 = CloneWriter(RadarRecciver.Altitude, targetHeight, Radar.Frequency, RadarRecciver.VertBeamWidth, RadarRecciver.ElevationAngle, double_8, ref Env);
					double num19 = Math.Pow(10.0, (num17 + num18) / 10.0);
					num20 = Radar.PowerOutputW * (radarAntennaGain * radarAntennaGain) * ProcessingGainConst * 4.0 * 3.14159265358979 / (num19 * (waveLength * waveLength));
				}
				else
				{
					CloneWriter(Radar.Altitude, targetHeight, Radar.Frequency, Radar.VertBeamWidth, Radar.ElevationAngle, DistanceToTarget_KM, ref Env);
					double num21 = Math.Pow(10.0, FlushStub(DistanceToTarget * 1852.0 / 1000.0, Radar.Frequency) / 10.0);
					num20 = Radar.PowerOutputW * (radarAntennaGain * radarAntennaGain) * ProcessingGainConst * 4.0 * 3.14159265358979 / (num21 * num21 * (waveLength * waveLength));
				}
				double receivePower = num20 * Target.RCS_m2;
				if (minCanDetectPower <= receivePower)
				{
					if (radarClutterType_0 != 0)
					{
						double num22 = 0.0 - Radar.ElevationAngle;
						if (num22 <= 0.0)
						{
							num22 = Math.Abs(num22);
						}
						double num23 = 0.0;
						switch (radarClutterType_0)
						{
						case RadarClutterType.Sea:
							num23 = PrepareStub(DistanceToTarget, ref Radar, targetHeight, Weather.RunDescriptor(Env.SeaState), 45.0, ref Env, num22);
							break;
						case RadarClutterType.Ground:
						{
							double double_9 = num22;
							if (MaxTerrainSlope != 0.0)
							{
								double val = Math2.SortClass(MaxTerrainSlope);
								double_9 = Math.Max(num22, val);
							}
							num23 = ReflectStub(DistanceToTarget, ref Radar, targetHeight, tsurfaceType_0, ref Env, double_9);
							break;
						}
						}
						double num24 = num20 * num23;
						if (techGenerationClass_0 >= GlobalVariables.TechGenerationClass.Early1980s)
						{
							switch (techGenerationClass_0)
							{
							default:
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								break;
							case GlobalVariables.TechGenerationClass.Late1970s:
								num24 *= 0.9025;
								break;
							case GlobalVariables.TechGenerationClass.Early1980s:
								num24 *= 0.81;
								break;
							case GlobalVariables.TechGenerationClass.Late1980s:
								num24 *= 0.6400000000000001;
								break;
							case GlobalVariables.TechGenerationClass.Early1990s:
								num24 *= 0.48999999999999994;
								break;
							case GlobalVariables.TechGenerationClass.Late1990s:
								num24 *= 0.36;
								break;
							case GlobalVariables.TechGenerationClass.Early2000s:
								num24 *= 0.25;
								break;
							case GlobalVariables.TechGenerationClass.Late2000s:
								num24 *= 0.16000000000000003;
								break;
							case GlobalVariables.TechGenerationClass.Early2010s:
								num24 *= 0.09;
								break;
							case GlobalVariables.TechGenerationClass.Late2010s:
								num24 *= 0.04000000000000001;
								break;
							case GlobalVariables.TechGenerationClass.Early2020s:
								num24 *= 0.010000000000000002;
								break;
							case GlobalVariables.TechGenerationClass.Late2020s:
								num24 *= 0.0025000000000000005;
								break;
							}
						}
						if (Radar.SurfaceAndPeriscopeSearchCapability == TSurfaceAndPeriscopeSearchCapability.FineRangeResolution)
						{
							num24 /= 2.0;
						}
						else if (Radar.SurfaceAndPeriscopeSearchCapability == TSurfaceAndPeriscopeSearchCapability.AdvancedProcessing)
						{
							num24 /= 4.0;
						}
						if (num24 > receivePower)
						{
							return false;
						}
					}
					if (ChaffDensity > 0.0 && ChaffCloudThickness > 0.0)
					{
						double num25 = 0.73 * (waveLength * waveLength) * ChaffDensity;
						receivePower *= Math.Pow(10.0, -2.0 * num25 * ChaffCloudThickness * 1852.0 / 10.0);
					}
					if (minCanDetectPower <= receivePower)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101124", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static double PrepareStub(double DistanceToTarget, ref TRadar tradar_0, double targetHeight, double double_2, double double_3, ref Weather.WeatherProfile weatherProfile_0, double ElevationAngle)
	{
		double num = CallWriter(DistanceToTarget, tradar_0.VertBeamWidth, tradar_0.HorzBeamWidth, tradar_0.PulseWidth, ElevationAngle);
		double num2 = SortStub(ref tradar_0, DistanceToTarget * 1852.0 / 1000.0, ElevationAngle, double_2, double_3);
		return Math.Pow(10.0, (num2 + num) / 10.0);
	}

	internal static double ReflectStub(double double_0, ref TRadar tradar_0, double double_1, TSurfaceType tsurfaceType_0, ref Weather.WeatherProfile weatherProfile_0, double double_2)
	{
		double num = double_0 * 1852.0 * tradar_0.InvokeInterruptibleReg() * 299792458.0 * 0.5 * Math.Tan(double_2 * 0.0174532925199433);
		return CalcStub(ref tradar_0, tsurfaceType_0, double_2) * num;
	}

	internal static bool VisitStub(object object_0, object object_1, float float_0)
	{
		return false;
	}

	internal unsafe static bool RestartStub(IEmitter iemitter_0, TReceiver treceiver_0, double double_0, double double_1, object object_0, ref IDoubleMatrix idoubleMatrix_0)
	{
		double antennaGain = iemitter_0.AntennaGain;
		double horzBeamWidth = iemitter_0.HorzBeamWidth;
		IEmitter emitter;
		TSteerableNullSet tsteerableNullSet_ = (emitter = iemitter_0).SteerableNulls;
		double num = ListStub(double_1, antennaGain, horzBeamWidth, ref tsteerableNullSet_);
		emitter.SteerableNulls = tsteerableNullSet_;
		double num2 = num;
		double num3 = 10.0 * Math.Log10(iemitter_0.PowerOutputW) + 30.0 + num2 - treceiver_0.Sensitivity - treceiver_0.SystemLoss;
		double double_2 = Math.Max(double_0, Geodesic_Vincenty.ConcatInvocation(double_0, iemitter_0.Altitude, treceiver_0.Altitude)) * 1852.0 / 1000.0;
		if (CloneWriter(iemitter_0.Altitude, treceiver_0.Altitude, iemitter_0.Frequency, iemitter_0.VertBeamWidth, iemitter_0.ElevationAngle, double_2, ref *(Weather.WeatherProfile*)(&object_0)) <= num3)
		{
			return true;
		}
		return false;
	}

	internal static int TestStub(double double_0, double double_1)
	{
		return PrintStub(double_0 * Math.Log(1.0 + Math.Pow(10.0, double_1 / 10.0)) / Math.Log(2.0));
	}

	internal static double StopStub(double double_0, double double_1, double double_2, double double_3)
	{
		return -2.0 * double_0 - 10.0 * Math.Log10(double_1) + 10.0 * Math.Log10(1984.4017075391823) + 40.0 * Math.Log10(double_2 * 1000.0) + 20.0 * Math.Log10(double_3) - 20.0 * Math.Log10(299792458.0);
	}

	internal static double CancelStub(double double_0, double double_1, ref Weather.WeatherProfile weatherProfile_0)
	{
		return LogoutWriter(double_0, weatherProfile_0.RainfallRate, double_1, 0.0);
	}

	internal static double VerifyStub(double double_0, double double_1, double double_2, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = double_2 * 1852.0;
		double num2 = RunStub(double_0, 0.0, weatherProfile_0.DELTA_N) * 1000.0;
		double num3 = num2 / 6371000.0;
		_ = RunStub(double_1, 0.0, weatherProfile_0.DELTA_N) * 1000.0 / 6371000.0;
		if (num <= num2)
		{
			return double_1;
		}
		double num4 = Math.Tan(num / 6371000.0 - num3) * 6371000.0;
		double val = double_1 - (Math.Sqrt(num4 * num4 + 40589641000000.0) - 6371000.0);
		return Math.Min(double_1, Math.Max(val, 0.0));
	}

	public static void ShipRCS(double double_0, double double_1, double double_2, double double_3, double double_4, ref Weather.WeatherProfile weatherProfile_0, ref double double_5, ref double double_6)
	{
		if (double_1 != 0.0 && double_2 != 0.0)
		{
			double num = double_1 - double_2;
			double_5 = double_3;
			double_6 = num * 1.0 / 3.0 + double_2;
		}
		else
		{
			double_5 = double_3;
			double_6 = 0.0;
		}
	}

	internal static double ListStub(double Azimouth, double antennaGain2, double horzBeamWidth2, ref TSteerableNullSet tsteerableNullSet_0)
	{
		double m_Azimouth = Math.Abs(Azimouth);
		if (m_Azimouth <= 180.0)
		{
			double result = ((m_Azimouth < 0.001) ? antennaGain2 : Math.Min(antennaGain2, antennaGain2 + 20.0 * Math.Log10(Math.Abs(Math.Sin(2.7831 * m_Azimouth / horzBeamWidth2) / (2.7831 * m_Azimouth / horzBeamWidth2)))));
			if (tsteerableNullSet_0 != null)
			{
				int num2 = tsteerableNullSet_0.Angles.Length - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (!(Math.Abs(Azimouth - tsteerableNullSet_0.Angles[i]) > tsteerableNullSet_0.Width / 2.0))
					{
						result = tsteerableNullSet_0.Level;
						break;
					}
				}
			}
			return result;
		}
		throw new Exception("角度超出限制");
	}

	internal static double ResolveStub(double double_0, double double_1, double double_2, double double_3)
	{
		double num = 299792458.0 / double_1;
		double num2 = Math.Abs(double_3);
		if (num2 < 1E-12)
		{
			num2 = 1E-05;
		}
		double num3 = 3.14159265358979 * double_0 / num;
		double num4 = 10.0 * Math.Log10(double_2 * num3 * num3);
		double num5 = double_0 / num;
		double num6 = num5 * num2;
		double val = num4 - 0.0025 * num6 * num6;
		double num7 = 2.0 + 15.0 * Math.Log(num5);
		double num8;
		double num9;
		double val2;
		if (num5 <= 100.0)
		{
			num8 = 39.8 * Math.Pow(num5, -0.8);
			num9 = 10.0 * Math.Log(0.9 * Math.Pow(Math.Sin(4.7123889803847 * num2 / num8), 2.0) + 0.1);
			val2 = num7 + num9;
			if (num2 < num8)
			{
				return Math.Max(val, val2);
			}
			if (num2 < 48.0)
			{
				return 42.0 - 5.0 * Math.Log(num5) - 25.0 * Math.Log(num2) + num9;
			}
			return -5.0 * Math.Log(num5) + num9;
		}
		num8 = 15.85 * Math.Pow(num5, -0.6);
		num9 = 10.0 * Math.Log(0.9 * Math.Pow(Math.Sin(4.7123889803847 * num2 / num8), 2.0) + 0.1);
		val2 = num7 + num9;
		if (num2 < num8)
		{
			return Math.Max(val, val2);
		}
		if (num2 < 48.0)
		{
			return 32.0 - 25.0 * Math.Log(num2) + num9;
		}
		return -10.0 + num9;
	}

	internal static double PostStub(double double_0, double double_1)
	{
		double num = Math.Abs(double_1);
		if (num <= 180.0)
		{
			double num2 = 50.0 * Math.Sqrt(0.25 * double_0 + 7.0) / Math.Pow(10.0, double_0 / 20.0);
			double num3;
			double num4;
			if (double_0 <= 48.0)
			{
				num3 = 250.0 / Math.Pow(10.0, double_0 / 20.0);
				if (double_0 <= 22.0)
				{
					num4 = 131.8257 * Math.Pow(10.0, (0.0 - double_0) / 50.0);
					if (num < num4)
					{
						if (num < num3)
						{
							if (num < num2)
							{
								return double_0 - 0.0004 * Math.Pow(10.0, double_0 / 10.0) * Math.Pow(num, 2.0);
							}
							return 0.75 * double_0 - 7.0;
						}
						return 53.0 - double_0 / 2.0 - 25.0 * Math.Log(num);
					}
					return 0.0;
				}
				num4 = 48.0;
				if (num < num4)
				{
					if (num < num3)
					{
						if (num < num2)
						{
							return double_0 - 0.0004 * Math.Pow(10.0, double_0 / 10.0) * Math.Pow(num, 2.0);
						}
						return 0.75 * double_0 - 7.0;
					}
					return 53.0 - double_0 / 2.0 - 25.0 * Math.Log(num);
				}
				return 11.0 - double_0 / 2.0;
			}
			num3 = 27.466 * Math.Pow(10.0, -0.3 * double_0 / 10.0);
			num4 = 48.0;
			if (num < num4)
			{
				if (num < num3)
				{
					if (num < num2)
					{
						return double_0 - 0.0004 * Math.Pow(10.0, double_0 / 10.0) * (num * num);
					}
					return 0.75 * double_0 - 7.0;
				}
				return 29.0 - 25.0 * Math.Log(num);
			}
			return -13.0;
		}
		throw new Exception("角度超出限制");
	}

	private static double RunStub(double double_0, double double_1, double double_2 = 39.0)
	{
		double num = Weather.ReflectDescriptor(double_2) * 1000.0;
		double num2 = Math.Sqrt(2.0 * num * double_1 + double_1 * double_1);
		double num3 = Math.Sqrt(2.0 * num * double_0 + double_0 * double_0);
		return (Math.Atan(num2 / 6371000.0) + Math.Atan(num3 / 6371000.0)) * 6371.0;
	}

	internal static double StartStub(double double_0, double double_1, double double_2, ref Weather.WeatherProfile weatherProfile_0)
	{
		if (double_1 == 0.0 && double_2 == 0.0)
		{
			return 0.0;
		}
		double num = RunStub(double_2, double_1, weatherProfile_0.DELTA_N) * 1000.0 / 1852.0;
		double num2 = 6371000.0 + double_1;
		double num3 = num2 * num2;
		double d;
		double num4;
		if (double_0 < num)
		{
			d = double_0 * 1852.0 / 6371000.0;
			num4 = 6371000.0 + double_2;
		}
		else
		{
			d = num * 1852.0 / 6371000.0;
			num4 = 6371000.0;
		}
		double num5 = num4 * num4;
		double num6 = Math.Sqrt(num5 + num3 - 2.0 * num4 * num2 * Math.Cos(d));
		return Math.Acos((num6 * num6 + num5 - num3) / (2.0 * num6 * num4)) * 57.2957795130823 - 90.0;
	}

	internal static double AssetStub(double double_0, double double_1, double double_2, double double_3)
	{
		double double_4 = Weather.RestartDescriptor(double_3, double_2);
		double num = QueryStub(double_0 / 1000000000.0, double_1, double_2);
		double num2 = PublishStub(double_0 / 1000000000.0, double_1, double_2, double_4);
		return num + num2;
	}

	internal static int PrintStub(double double_0)
	{
		try
		{
			int num = (int)Math.Round(double_0);
			if (double_0 - (double)num < 0.0)
			{
				return num - 1;
			}
			return num;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal static double DefineStub(double double_0, double double_1)
	{
		double num = (double_0 - double_1) / (double_0 + double_1);
		return 1.0 + num * num;
	}

	internal static double PublishStub(double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_1 / 1013.0;
		double num8 = 288.0 / (273.0 + double_2);
		double num13;
		double num14;
		double num15;
		if (double_0 <= 54.0)
		{
			double num9 = 0.955 * num * Math.Pow(num8, 0.68) + 0.006 * double_3;
			double num10 = num8 * num8;
			double num11 = 0.735 * num * Math.Sqrt(num8) + 0.0353 * (num10 * num10) * double_3;
			double num12 = num9 * num9;
			num13 = 3.98 * num9 * Math.Exp(2.23 * (1.0 - num8)) / ((double_0 - 22.235) * (double_0 - 22.235) + 9.42 * num12) * DefineStub(double_0, 22.0);
			num14 = 11.96 * num9 * Math.Exp(0.7 * (1.0 - num8)) / ((double_0 - 183.31) * (double_0 - 183.31) + 11.14 * num12);
			num15 = 0.081 * num9 * Math.Exp(6.44 * (1.0 - num8)) / ((double_0 - 321.226) * (double_0 - 321.226) + 6.29 * num12);
			double num2 = 3.66 * num9 * Math.Exp(1.6 * (1.0 - num8)) / ((double_0 - 325.153) * (double_0 - 325.153) + 9.22 * num12);
			double num3 = 25.37 * num9 * Math.Exp(1.09 * (1.0 - num8)) / ((double_0 - 380.0) * (double_0 - 380.0));
			double num4 = 17.4 * num9 * Math.Exp(1.46 * (1.0 - num8)) / ((double_0 - 448.0) * (double_0 - 448.0));
			double num5 = 844.6 * num9 * Math.Exp(0.17 * (1.0 - num8)) / ((double_0 - 557.0) * (double_0 - 557.0)) * DefineStub(double_0, 557.0);
			double num6 = 290.0 * num9 * Math.Exp(0.41 * (1.0 - num8)) / ((double_0 - 752.0) * (double_0 - 752.0)) * DefineStub(double_0, 752.0);
			double num7 = 83328.0 * num11 * Math.Exp(0.99 * (1.0 - num8)) / ((double_0 - 1780.0) * (double_0 - 1780.0)) * DefineStub(double_0, 1780.0);
			return (num13 + num14 + num15 + num2 + num3 + num4 + num5 + num6 + num7) * (double_0 * double_0) * Math.Pow(num8, 2.5) * double_3 * 0.0001;
		}
		num13 = 3.6 / ((double_0 - 22.2) * (double_0 - 22.2) + 8.5);
		num14 = 10.6 / ((double_0 - 183.3) * (double_0 - 183.3) + 9.0);
		num15 = 8.9 / ((double_0 - 325.4) * (double_0 - 325.4) + 26.3);
		return (0.05 + 0.021 * double_3 + num13 + num14 + num15) * (double_0 * double_0) * double_3 * 0.0001;
	}

	internal static double AwakeStub(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		return Math.Pow(double_0, double_2) * Math.Pow(double_1, double_3) * Math.Exp(double_4 * (1.0 - double_0) + double_5 * (1.0 - double_1));
	}

	internal static double QueryStub(double double_0, double double_1, double double_2)
	{
		double num = double_1 / 1013.0;
		double num2 = 288.0 / (273.0 + double_2);
		double num3 = double_0 * double_0;
		double num4;
		double num5;
		if (double_0 <= 54.0)
		{
			num4 = AwakeStub(num, num2, 0.0717, -1.8132, 0.0156, -1.6515);
			num5 = AwakeStub(num, num2, 0.5146, -4.6368, -0.1921, -5.7416);
			double num6 = AwakeStub(num, num2, 0.3414, -6.5851, 0.213, -8.5854);
			double num7 = num * num;
			return (7.2 * Math.Pow(num2, 2.8) / (num3 + 0.34 * num7 * Math.Pow(num2, 1.6)) + 0.62 * num6 / (Math.Pow(54.0 - double_0, 1.16 * num4) + 0.83 * num5)) * num3 * num7 * 0.001;
		}
		num4 = 6.09 / (num3 + 0.227);
		num5 = 4.81 / ((double_0 - 57.0) * (double_0 - 57.0) + 1.5);
		return (1.0 + 0.01 * (double_2 - 15.0)) * 0.001 * (num4 + num5 + 0.00719) * num3;
	}

	public static void NATOBand_Freqs(string string_0, ref TNATORadarBand tnatoradarBand_0)
	{
		switch (string_0)
		{
		case "L Band":
			tnatoradarBand_0.LoFreq = 40000000000.0;
			tnatoradarBand_0.HiFreq = 60000000000.0;
			break;
		case "J Band":
			tnatoradarBand_0.LoFreq = 10000000000.0;
			tnatoradarBand_0.HiFreq = 20000000000.0;
			break;
		case "D Band":
			tnatoradarBand_0.LoFreq = 1000000000.0;
			tnatoradarBand_0.HiFreq = 2000000000.0;
			break;
		case "A Band":
			tnatoradarBand_0.LoFreq = 0.0;
			tnatoradarBand_0.HiFreq = 250000000.0;
			break;
		case "C Band":
			tnatoradarBand_0.LoFreq = 500000000.0;
			tnatoradarBand_0.HiFreq = 1000000000.0;
			break;
		case "M Band":
			tnatoradarBand_0.LoFreq = 60000000000.0;
			tnatoradarBand_0.HiFreq = 100000000000.0;
			break;
		case "I Band":
			tnatoradarBand_0.LoFreq = 8000000000.0;
			tnatoradarBand_0.HiFreq = 10000000000.0;
			break;
		case "F Band":
			tnatoradarBand_0.LoFreq = 3000000000.0;
			tnatoradarBand_0.HiFreq = 4000000000.0;
			break;
		case "G Band":
			tnatoradarBand_0.LoFreq = 4000000000.0;
			tnatoradarBand_0.HiFreq = 6000000000.0;
			break;
		case "H Band":
			tnatoradarBand_0.LoFreq = 6000000000.0;
			tnatoradarBand_0.HiFreq = 8000000000.0;
			break;
		case "E Band":
			tnatoradarBand_0.LoFreq = 2000000000.0;
			tnatoradarBand_0.HiFreq = 3000000000.0;
			break;
		case "K Band":
			tnatoradarBand_0.LoFreq = 20000000000.0;
			tnatoradarBand_0.HiFreq = 40000000000.0;
			break;
		default:
			throw new Exception("Unsupported band name");
		case "B Band":
			tnatoradarBand_0.LoFreq = 250000000.0;
			tnatoradarBand_0.HiFreq = 500000000.0;
			break;
		}
		tnatoradarBand_0.DefaultFreq = (tnatoradarBand_0.LoFreq + tnatoradarBand_0.HiFreq) / 2.0;
	}

	internal static double ResetStub(ref TRadar tradar_0, double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = 299792458.0 / tradar_0.Frequency;
		double num2 = Math.Pow(1.9425 * double_3 / (1.0 + double_3 / 15.0), 1.1 * Math.Pow(num + 0.02, -0.4));
		double num3 = Math.Pow(double_3 / 8.67, 2.5);
		double x = (14.4 * num + 5.5) * double_2 * num3 / (num + 0.02);
		double num4 = Math.Pow(x, 4.0) / (1.0 + Math.Pow(x, 4.0));
		double num5 = Math.Exp(0.2 * Math.Cos(double_4) * (1.0 - 2.8 * double_2) * Math.Pow(num + 0.02, -0.4));
		double num6 = 10.0 * Math.Log10(1000.0 * double_0 * 0.0174532925199433 * tradar_0.HorzBeamWidth * tradar_0.InvokeInterruptibleReg() / (4.0 * Math.Log(2.0)));
		double num7 = 10.0 * Math.Log10(3.9E-06 * num * Math.Pow(double_2, 0.4) * num4 * num5 * num2) + num6;
		return -123.0 + 10.0 * Math.Log10(tradar_0.PowerOutputW / 1000.0 * (num * num) * Math.Pow(double_1, 4.0) / Math.Pow(double_0, -4.0)) + 2.0 * tradar_0.AntennaGain + num7 + tradar_0.ProcessingGain;
	}

	internal static double MapStub(ref TRadar tradar_0, double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_1 * 100.0 * 0.0174532925199433;
		double num2 = 299792458.0 / tradar_0.Frequency;
		double num3 = Math.Pow(1.9425 * double_2 / (1.0 + double_2 / 15.0), 1.1 * Math.Pow(num2 + 0.02, -0.4));
		Math.Pow(double_2 / 8.67, 2.5);
		double num4 = DeleteWriter(double_2, tradar_0.Frequency, double_1);
		double num5 = Math.Exp(0.2 * Math.Cos(double_3) * (1.0 - 2.8 * num) * Math.Pow(num2 + 0.02, -0.4));
		double num6 = 10.0 * Math.Log10(1000.0 * double_0 * 0.0174532925199433 * tradar_0.HorzBeamWidth * tradar_0.InvokeInterruptibleReg() / (4.0 * Math.Log(2.0)));
		return ((num4 == 0.0) ? 0.0 : (10.0 * Math.Log10(3.9E-06 * num2 * Math.Pow(num, 0.4) * num4 * num5 * num3))) + num6;
	}

	internal static double SortStub(ref TRadar tradar_0, double DistanceToTarget, double ElevationAngle, double double_2, double double_3)
	{
		double num;
		if (ElevationAngle == 0.0)
		{
			num = 0.0;
		}
		else
		{
			double num3 = ElevationAngle * 0.0174532925199433;
			double waveLength = 299792458.0 / tradar_0.Frequency;
			double num4 = Math.Pow(double_2, 2.0 / 3.0) / 0.836;
			double num5 = num4 * num4 * num4 / 300.0;
			double num6 = ((num5 == 0.0) ? 1.5707963267949 : Math.Min(1.5707963267949, Math.Asin(waveLength / (12.56637061435916 * num5))));
			double num7 = 6.0 * num4 + 10.0 * Math.Log10(waveLength) - 64.0;
			double num8 = Math.Pow(10.0, num7 / 10.0);
			double num2;
			if (num3 <= num6)
			{
				double num9 = num3 / num6;
				num9 *= num9;
				num9 *= num9;
				num2 = Math.Log10(num8 * num3 * num9) * 10.0;
			}
			else
			{
				num2 = Math.Log10(num8 * Math.Sin(num3)) * 10.0;
			}
			num = num2;
			if (double.IsNaN(num))
			{
				num = 0.0;
			}
		}
		return num;
	}

	internal static double CalcStub(ref TRadar tradar_0, TSurfaceType tsurfaceType_0, double double_0)
	{
		double num = double_0 * 0.0174532925199433;
		double waveLength = 299792458.0 / tradar_0.Frequency;
		double num2;
		double num3;
		switch (tsurfaceType_0)
		{
		default:
			throw new Exception("不支持的水面类型");
		case TSurfaceType.st_Urban:
			num2 = -5.0;
			num3 = 10.0;
			break;
		case TSurfaceType.st_Mountains:
			num2 = -5.0;
			num3 = 100.0;
			break;
		case TSurfaceType.st_Cropland:
			num2 = -10.0;
			num3 = 3.0;
			break;
		case TSurfaceType.st_Shrubland:
			num2 = -12.0;
			num3 = 5.0;
			break;
		case TSurfaceType.st_Forest:
			num2 = -15.0;
			num3 = 10.0;
			break;
		case TSurfaceType.st_Desert:
			num2 = -20.0;
			num3 = 3.0;
			break;
		case TSurfaceType.st_Tundra:
		case TSurfaceType.st_Grassland:
		case TSurfaceType.st_Wetland:
			num2 = -20.0;
			num3 = 1.0;
			break;
		}
		double num4 = Math.Pow(10.0, num2 / 10.0);
		double num5 = ((num3 == 0.0) ? 1.5707963267949 : Math.Min(1.5707963267949, Math.Asin(waveLength / (12.56637061435916 * num3))));
		double num7;
		if (num <= num5)
		{
			double num6 = num / num5;
			num6 *= num6;
			num6 *= num6;
			num7 = Math.Log10(num4 * num * num6) * 10.0;
		}
		else
		{
			num7 = Math.Log10(num4 * Math.Sin(num)) * 10.0;
		}
		return Math.Pow(10.0, num7 / 10.0);
	}

	internal static double RateStub(ref TMetricParams tmetricParams_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = Math.Max(1.3333333333333333, weatherProfile_0.k50);
		return 3.572 * (Math.Sqrt(num * tmetricParams_0.h1) + Math.Sqrt(num * tmetricParams_0.h2)) + 230.2 * Math.Pow(num * num / tmetricParams_0.Frequency, 1.0 / 3.0);
	}

	internal static double FlushStub(double DistanceToTarget_KM, double Frequency)
	{
		return 10.0 * Math.Log10(1.7570265424158548E-09) + 20.0 * Math.Log10(DistanceToTarget_KM) + 20.0 * Math.Log10(Frequency);
	}

	public static void dconst(double double_0, ref TEvapDuctParams tevapDuctParams_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = double_0 / 1000000.0;
		double num8 = num * num;
		double num9 = num * num8;
		double num10 = num8 * num8;
		double num11 = Math.Pow(num, 1.0 / 3.0);
		double num12 = 70.0;
		if (num > 2253.5895)
		{
			num12 = 1.0 / (0.014114535 + -5.2122497E-08 * num + 5.8547829E-11 * num8 + -7.6717423E-16 * num9 + 2.9856318E-21 * num10);
		}
		double num13 = 5.0;
		if (num > 1106.207)
		{
			num13 = 3.8586749 + 0.00091253873 * num + 1.5309921E-08 * num8;
			num13 /= 1.0 + -2.1179295E-05 * num + 6.5727504E-10 * num8 + -1.9647664E-15 * num9;
		}
		double num14 = num12;
		double num15 = -18000.0 * num13 / num;
		double num2 = Math.Pow(weatherProfile_0.RadiusEffective, 1.0 / 3.0);
		double num3 = num15 * num15;
		double num4 = Math.Pow(20.943951023931934, -1.0 / 3.0) / (num2 * num11);
		double x = (num14 - 1.0) * (num14 - 1.0) + num3;
		tevapDuctParams_0.capk = num4 / Math.Pow(x, 0.25);
		tevapDuctParams_0.xterm = 2.2 * num11 / (num2 * num2);
		tevapDuctParams_0.zterm = 0.0096 * (num11 * num11) / num2;
		if (weatherProfile_0.EvaporationDuctHeight == 0.0)
		{
			tevapDuctParams_0.del = 0.0;
			return;
		}
		tevapDuctParams_0.rfac = Math.Pow(num / 9600.0, 1.0 / 3.0);
		tevapDuctParams_0.zfac = Math.Pow(num / 9600.0, 2.0 / 3.0);
		tevapDuctParams_0.hmin = 1.0;
		tevapDuctParams_0.del = weatherProfile_0.EvaporationDuctHeight * tevapDuctParams_0.zfac;
		if (tevapDuctParams_0.del > 23.3)
		{
			tevapDuctParams_0.del = 23.3;
		}
		if (tevapDuctParams_0.del < 10.25)
		{
			tevapDuctParams_0.C2 = Math.Sqrt(40623.61 - (tevapDuctParams_0.del + 4.4961) * (tevapDuctParams_0.del + 4.4961)) - 201.0128;
			tevapDuctParams_0.C1 = (-2.2 * Math.Exp(-0.244 * tevapDuctParams_0.del) + 17.0) * Math.Pow(4.72, 0.0 - tevapDuctParams_0.C2);
			tevapDuctParams_0.C4 = Math.Sqrt(14301.2 - (tevapDuctParams_0.del + 5.32545) * (tevapDuctParams_0.del + 5.32545)) - 119.569;
			tevapDuctParams_0.C3 = (-33.9 * Math.Exp(-0.5170001 * tevapDuctParams_0.del) - 3.0) * Math.Pow(4.72, 0.0 - tevapDuctParams_0.C4);
			tevapDuctParams_0.C5 = 41.0 * Math.Exp(-0.41 * tevapDuctParams_0.del) + 61.0;
		}
		else
		{
			tevapDuctParams_0.C1 = -0.1189 * tevapDuctParams_0.del + 5.5495;
			tevapDuctParams_0.C3 = 1.5;
			tevapDuctParams_0.C2 = 1.3291 * Math.Sin(0.218 * Math.Pow(tevapDuctParams_0.del - 10.0, 0.77)) + 0.2171 * Math.Log(tevapDuctParams_0.del);
			tevapDuctParams_0.C2 *= Math.Pow(4.72, 0.0 - tevapDuctParams_0.C3);
			tevapDuctParams_0.C4 = 87.0 - Math.Sqrt(313.29 - (tevapDuctParams_0.del - 25.3) * (tevapDuctParams_0.del - 25.3));
			tevapDuctParams_0.zmax = 4.0 * Math.Exp(-0.31 * (tevapDuctParams_0.del - 10.0)) + 6.0;
			double a = tevapDuctParams_0.C2 * Math.Pow(tevapDuctParams_0.zmax, tevapDuctParams_0.C3);
			double num5 = 4.72 * tevapDuctParams_0.C1 * tevapDuctParams_0.C2 * tevapDuctParams_0.C3 * Math.Sqrt(tevapDuctParams_0.zmax) / Math.Tan(a);
			tevapDuctParams_0.C7 = 49.4 * Math.Exp(-0.1699 * (tevapDuctParams_0.del - 10.0)) + 30.0;
			double num6 = tevapDuctParams_0.C1 * Math.Log(Math.Sin(a)) + tevapDuctParams_0.C4 - tevapDuctParams_0.C7;
			tevapDuctParams_0.C6 = tevapDuctParams_0.zmax / 4.72 * num5 / num6;
			tevapDuctParams_0.C5 = num6 / Math.Pow(tevapDuctParams_0.zmax, tevapDuctParams_0.C6);
		}
		tevapDuctParams_0.atten = 92.516 - Math.Sqrt(8608.7593 - (tevapDuctParams_0.del - 20.2663) * (tevapDuctParams_0.del - 20.2663));
		if (tevapDuctParams_0.atten < 0.0009)
		{
			tevapDuctParams_0.atten = 0.0009;
		}
		tevapDuctParams_0.atten *= tevapDuctParams_0.rfac;
		double num7 = 0.0;
		if (tevapDuctParams_0.del <= 3.8)
		{
			num7 = 216.7 + tevapDuctParams_0.del * 1.5526;
		}
		if (tevapDuctParams_0.del > 3.8)
		{
			num7 = 222.6 - (tevapDuctParams_0.del - 3.8) * 1.1771;
		}
		tevapDuctParams_0.difac = 51.1 + num7 + 10.0 * Math.Log10(tevapDuctParams_0.rfac);
	}

	public static void hgain(double double_0, ref double double_1, ref double double_2, double double_3, TEvapDuctParams tevapDuctParams_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = double_3 / 1000000.0;
		double_1 = 0.0;
		double_2 = 0.0;
		if (weatherProfile_0.SurfaceDuctHeight > 0.0)
		{
			double num2 = double_0 / weatherProfile_0.SurfaceDuctHeight;
			if (num <= 150.0 && num2 < 0.8)
			{
				double_1 = -60.0 * Math.Pow(num2 - 0.5, 2.0);
			}
			if (num <= 150.0 && num2 >= 0.8)
			{
				double_1 = 1.14 * Math.Pow(num2, -6.26) - 10.0;
			}
			if (num > 150.0 && num2 < 1.0)
			{
				double_1 = 10.0 - 200.0 * Math.Pow(num2 - 0.5, 4.0);
			}
			if (num > 150.0 && num <= 350.0 && num2 >= 1.0)
			{
				double_1 = 7.5 * Math.Pow(num2, -13.3) - 10.0;
			}
			if (num > 350.0 && num2 >= 1.0)
			{
				double_1 = 12.5 * Math.Pow(num2, -8.0) - 15.0;
			}
		}
		if (!(tevapDuctParams_0.del <= 0.0))
		{
			double num3 = double_0 * tevapDuctParams_0.zfac;
			if (num3 < tevapDuctParams_0.hmin)
			{
				num3 = tevapDuctParams_0.hmin;
			}
			if (tevapDuctParams_0.del < 10.25)
			{
				double_2 = tevapDuctParams_0.C1 * Math.Pow(num3, tevapDuctParams_0.C2) + tevapDuctParams_0.C3 * Math.Pow(num3, tevapDuctParams_0.C4) + tevapDuctParams_0.C5;
			}
			else if (num3 <= tevapDuctParams_0.zmax)
			{
				double_2 = tevapDuctParams_0.C1 * Math.Log(Math.Sin(tevapDuctParams_0.C2 * Math.Pow(num3, tevapDuctParams_0.C3))) + tevapDuctParams_0.C4;
			}
			else
			{
				double_2 = tevapDuctParams_0.C5 * Math.Pow(num3, tevapDuctParams_0.C6) + tevapDuctParams_0.C7;
			}
		}
	}

	internal static double ForgotStub(double double_0, ref TEvapDuctParams tevapDuctParams_0)
	{
		double num;
		if (double_0 <= 2.0)
		{
			if (double_0 <= 10.0 * tevapDuctParams_0.capk)
			{
				num = 2.0 + 20.0 * Math.Log10(tevapDuctParams_0.capk);
				if (double_0 > tevapDuctParams_0.capk / 10.0)
				{
					double num2 = 0.1 * Math.Log10(double_0 / tevapDuctParams_0.capk);
					num += 9.0 * num2 * (num2 + 1.0);
				}
			}
			else
			{
				num = 20.0 * Math.Log10(double_0 + 0.1 * double_0 * double_0 * double_0);
			}
		}
		else
		{
			num = 17.6 * Math.Sqrt(double_0 - 1.1) - 2.1715 * Math.Log(double_0 - 1.1) - 8.0;
		}
		return num;
	}

	internal static double CollectStub(ref TMetricParams tmetricParams_0, double double_0, ref TEvapDuctParams tevapDuctParams_0, ref TOpticalParams topticalParams_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = 32.45 + 20.0 * Math.Log10(tmetricParams_0.Frequency / 1000000.0);
		double num2 = num + 20.0 * Math.Log10(tmetricParams_0.range);
		double num3 = OrderStub(ref tmetricParams_0, ref tevapDuctParams_0, ref weatherProfile_0, topticalParams_0.exloss);
		num3 = num3 - num - 20.0 * Math.Log10(double_0);
		double num4 = (tmetricParams_0.range - topticalParams_0.opmaxd) * (topticalParams_0.opmaxl - num3) / (topticalParams_0.opmaxd - double_0);
		double num5 = topticalParams_0.opmaxl + num4;
		if (weatherProfile_0.SurfaceDuctHeight > 0.0 && weatherProfile_0.SurfaceDuctHeight >= tmetricParams_0.h1)
		{
			double num6 = num5 + num2;
			double num7 = ManageStub(ref tmetricParams_0, ref topticalParams_0, ref tevapDuctParams_0, ref weatherProfile_0, topticalParams_0.exloss);
			if (num7 < num6)
			{
				num6 = num7;
			}
			num5 = num6 - num2;
		}
		return num5;
	}

	internal static double OrderStub(ref TMetricParams tmetricParams_0, ref TEvapDuctParams tevapDuctParams_0, ref Weather.WeatherProfile weatherProfile_0, double double_0)
	{
		double num = 32.45 + 20.0 * Math.Log10(tmetricParams_0.Frequency / 1000000.0);
		double num4 = ForgotStub(tevapDuctParams_0.zterm * tmetricParams_0.h1, ref tevapDuctParams_0);
		double num5 = ForgotStub(tevapDuctParams_0.zterm * tmetricParams_0.h2, ref tevapDuctParams_0);
		double num6 = num - num4 - num5;
		double num7 = 10.0 * Math.Log10(tmetricParams_0.range);
		double num8 = tevapDuctParams_0.xterm * tmetricParams_0.range;
		double num9 = 11.0 + 10.0 * Math.Log10(num8) - 17.6 * num8;
		double num10 = num6 + 2.0 * num7 - num9;
		if (weatherProfile_0.EvaporationDuctHeight != 0.0)
		{
			double num11 = tevapDuctParams_0.difac + num7 + tevapDuctParams_0.atten * tmetricParams_0.range;
			if (num11 < num10)
			{
				num10 = num11;
			}
		}
		num10 += double_0;
		double num2 = RegisterStub(ref tmetricParams_0, double_0, ref weatherProfile_0);
		double num3 = num10 - num2;
		if (num3 < 18.0)
		{
			if (num3 >= -18.0)
			{
				num10 -= 10.0 * Math.Log10(1.0 + Math.Exp(Math.Log(10.0) * num3 / 10.0));
			}
		}
		else
		{
			num10 = num2;
		}
		return num10;
	}

	internal static double RegisterStub(ref TMetricParams tmetricParams_0, double double_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = tmetricParams_0.Frequency / 1000000.0 * (tmetricParams_0.Frequency / 1000000.0) * (tmetricParams_0.Frequency / 1000000.0);
		double num12 = 0.031 - 0.00232 * weatherProfile_0.SurfaceRefractivity + 5.67E-06 * weatherProfile_0.SurfaceRefractivity * weatherProfile_0.SurfaceRefractivity;
		double num20 = tmetricParams_0.h1 * 0.0419 * tmetricParams_0.Frequency / 1000000.0;
		double num21 = tmetricParams_0.h2 * 0.0419 * tmetricParams_0.Frequency / 1000000.0;
		double num22 = 0.08984 / weatherProfile_0.k50;
		double num23 = 0.2 * weatherProfile_0.SurfaceRefractivity;
		double num24 = RunStub(tmetricParams_0.h1, tmetricParams_0.h2, weatherProfile_0.DELTA_N);
		double num25 = Math.Sqrt(tmetricParams_0.h1 * weatherProfile_0.RadiusEffective / 500.0) / weatherProfile_0.RadiusEffective;
		double num26 = Math.Sqrt(tmetricParams_0.h2 * weatherProfile_0.RadiusEffective / 500.0) / weatherProfile_0.RadiusEffective;
		double num2 = tmetricParams_0.range / weatherProfile_0.RadiusEffective;
		double num3 = num2 - num25 - num26;
		double num4 = num2 / 2.0 - num25 + (tmetricParams_0.h1 - tmetricParams_0.h2) / (1000.0 * tmetricParams_0.range);
		double num5 = num2 / 2.0 - num26 + (tmetricParams_0.h2 - tmetricParams_0.h1) / (1000.0 * tmetricParams_0.range);
		double num6 = num20 * num3;
		double num7 = num21 * num3;
		if (num6 < 0.1)
		{
			num6 = 0.1;
		}
		if (num7 < 0.1)
		{
			num7 = 0.1;
		}
		double num8 = num4 / num5;
		if (num8 > 10.0)
		{
			num8 = 10.0;
		}
		if (num8 < 0.1)
		{
			num8 = 0.1;
		}
		double num9 = num7 / (num8 * num6);
		if (num9 > 10.0)
		{
			num9 = 10.0;
		}
		if (num9 < 0.1)
		{
			num9 = 0.1;
		}
		double num10 = num8 * tmetricParams_0.range * num3 / ((1.0 + num8) * (1.0 + num8));
		double num11 = num10 * num10 * num10;
		double num13 = 0.5696 * num10 * (1.0 + num12 * Math.Exp(-3.8E-06 * (num11 * num11)));
		if (num13 > 5.0)
		{
			num13 = 5.0;
		}
		if (num13 < 0.01)
		{
			num13 = 0.01;
		}
		double num14 = 16.3 + 13.3 * num13;
		double num15 = 0.4 + 0.16 * num13;
		double num16 = num14 * Math.Pow(num6 + num15, -1.333);
		double num17 = num14 * Math.Pow(num7 + num15, -1.333);
		double num18 = (num16 + num17) / 2.0;
		double num19 = 1.13 * (0.6 - 0.1 * Math.Log10(num13)) * Math.Log(num8) * Math.Log(num9);
		num18 = ((num19 <= num18) ? (num18 + num19) : (2.0 * num18));
		if (num18 < 0.0)
		{
			num18 = 0.0;
		}
		return 114.9 + num22 * (tmetricParams_0.range - num24) + 10.0 * Math.Log10(tmetricParams_0.range * tmetricParams_0.range * num) - num23 + num18 + double_0;
	}

	internal static double ManageStub(ref TMetricParams tmetricParams_0, ref TOpticalParams topticalParams_0, ref TEvapDuctParams tevapDuctParams_0, ref Weather.WeatherProfile weatherProfile_0, double double_0)
	{
		if (weatherProfile_0.SurfaceDuctHeight != 0.0 && tmetricParams_0.h2 <= weatherProfile_0.SurfaceDuctHeight)
		{
			double num = 32.45 + 20.0 * Math.Log10(tmetricParams_0.Frequency / 1000000.0);
			double double_ = 0.0;
			double double_2 = 0.0;
			double double_3 = 0.0;
			skipzone(ref tmetricParams_0, ref topticalParams_0, ref double_, ref double_2, ref double_3, num, tevapDuctParams_0, weatherProfile_0);
			if (tmetricParams_0.range < double_)
			{
				return double_2 + (double_ - tmetricParams_0.range) + double_0;
			}
			return num + 20.0 * Math.Log10(tmetricParams_0.range) - double_3 + double_0;
		}
		return 1000.0;
	}

	internal static double RevertStub(double double_0, double double_1, double double_2, double double_3, ref Weather.WeatherProfile weatherProfile_0)
	{
		double x = 0.0;
		double num = double_2 - 1000.0 * Math.Pow(x, 2.0) / (2.0 * weatherProfile_0.RadiusEffective);
		double x2 = 0.0;
		double num2 = double_3 - 1000.0 * Math.Pow(x2, 2.0) / (2.0 * weatherProfile_0.RadiusEffective);
		double num3 = Math.Sqrt(1.3333333333333333 * (0.001 * weatherProfile_0.RadiusEffective * (double_2 + double_3) + Math.Pow(double_1, 2.0) / 4.0));
		double num4 = Math.Acos(0.002 * weatherProfile_0.RadiusEffective * Math.Abs(double_2 - double_3) * double_1 / num3);
		x = double_1 / 2.0 - num3 * Math.Cos((num4 + 3.14159265358979) / 3.0);
		x2 = double_1 - x;
		double result = 6.28318530717958 * (2.0 * num * num2 / (1000.0 * double_1 * 299792458.0 / double_0));
		_ = 0.001 * Math.Abs(double_2 - double_3) / double_1;
		_ = 0.001 * Math.Min(num, num2) / Math.Min(x, x2);
		return result;
	}

	internal static double CountWriter(double double_0, double double_1, double double_2, double double_3, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = double_1 - double_0 * double_0 * 1000.0 / (2.0 * weatherProfile_0.RadiusEffective);
		double num2 = 12.56637061435916 * double_3 * 1000.0 / 299792458.0;
		double num3 = num / double_0;
		if (0.001 * num3 > 0.05236)
		{
			Math.Atan(0.001 * num / double_0);
		}
		double num4 = double_2 * 4.0 * 1000.0 / (2.0 * weatherProfile_0.RadiusEffective);
		double num5 = (Math.Sqrt(num3 * num3 + num4) - num3) * (weatherProfile_0.RadiusEffective / 1000.0);
		double num6 = double_0 + num5;
		double num7 = double_2 - num5 * num5 / (2.0 * weatherProfile_0.RadiusEffective / 1000.0);
		return 3.14159265358979 + num2 * num * num7 / num6;
	}

	internal static double CustomizeWriter(double double_0, double double_1, double double_2, double double_3, double double_4, ref Weather.WeatherProfile weatherProfile_0)
	{
		int num = 0;
		double num2 = double_1;
		double num3 = double_1;
		double num4 = RunStub(double_2, 0.0, weatherProfile_0.DELTA_N);
		while (Math.Abs(num2) > 0.001 && num < 5)
		{
			double num5 = CountWriter(num3, double_2, double_3, double_4, ref weatherProfile_0);
			double num6 = (CountWriter(num3 + 0.001, double_2, double_3, double_4, ref weatherProfile_0) - num5) / 0.001;
			if (num6 == 0.0)
			{
				num6 = 1E-08;
			}
			num2 = (double_0 - num5) / num6;
			num++;
			num3 = ((num2 <= 0.0 - num3) ? (num3 / 2.0) : ((num2 + num3 <= num4) ? (num3 + num2) : ((num3 + num4) / 2.0)));
		}
		return num3;
	}

	internal static double CloneWriter(double Altitude, double Altitude2, double Frequency, double VertBeamWidth, double ElevationAngle, double DistanceToTarget_KM, ref Weather.WeatherProfile weatherProfile_0)
	{
		return FlushStub(DistanceToTarget_KM, Frequency);
	}

	public static void oplimit(ref TOpticalParams topticalParams_0, ref TMetricParams tmetricParams_0, ref TEvapDuctParams tevapDuctParams_0, ref Weather.WeatherProfile weatherProfile_0, ref TAntennaParams tantennaParams_0)
	{
		double num = 0.01957 / Math.Pow(weatherProfile_0.k50 * tmetricParams_0.Frequency / 1000000.0, 1.0 / 3.0);
		double num2 = 1000.0 * num;
		double num3 = (Math.Sqrt(num2 * num2 + tmetricParams_0.h1 * 4.0 / (weatherProfile_0.RadiusEffective / 1000.0 * (weatherProfile_0.RadiusEffective / 1000.0))) - num2) * (weatherProfile_0.RadiusEffective / 1000.0);
		topticalParams_0.r1min = 0.01 * tmetricParams_0.range * tmetricParams_0.h1 / (tmetricParams_0.h1 + tmetricParams_0.h2);
		double double_ = num3;
		double_ = CustomizeWriter(4.712388980384685, double_, tmetricParams_0.h1, tmetricParams_0.h2, tmetricParams_0.Frequency, ref weatherProfile_0);
		if (num3 > double_)
		{
			double_ = num3;
		}
		num3 = double_;
		if (num3 < topticalParams_0.r1min)
		{
			topticalParams_0.r1min = num3 / 2.0;
		}
		double val;
		if (tevapDuctParams_0.del > 0.0)
		{
			double num4 = CountWriter(num3, tmetricParams_0.h1, tmetricParams_0.h2, tmetricParams_0.Frequency, ref weatherProfile_0);
			val = CountWriter(topticalParams_0.r1min, tmetricParams_0.h1, tmetricParams_0.h2, tmetricParams_0.Frequency, ref weatherProfile_0);
			double num5 = Math.Min(val, 6.28318530717958);
			num4 = ((tevapDuctParams_0.del < 10.25) ? (num4 + tevapDuctParams_0.del / 10.25 * (num5 - num4)) : num5);
			num3 = CustomizeWriter(num4, num3, tmetricParams_0.h1, tmetricParams_0.h2, tmetricParams_0.Frequency, ref weatherProfile_0);
		}
		double_ = num3;
		val = CountWriter(double_, tmetricParams_0.h1, tmetricParams_0.h2, tmetricParams_0.Frequency, ref weatherProfile_0);
		double num6 = tmetricParams_0.h1 - double_ * double_ * 1000.0 / (2.0 * weatherProfile_0.RadiusEffective);
		num2 = num6 / double_;
		if (0.001 * num2 > 0.05236)
		{
			Math.Atan(0.001 * num6 / double_);
		}
		double num7 = tmetricParams_0.h2 * 4.0 * 1000.0 / (2.0 * weatherProfile_0.RadiusEffective);
		double num8 = (Math.Sqrt(num2 * num2 + num7) - num2) * (weatherProfile_0.RadiusEffective / 1000.0);
		topticalParams_0.opmaxd = double_ + num8;
		double double_2 = ((tmetricParams_0.h2 < tmetricParams_0.h1) ? (double_ / weatherProfile_0.RadiusEffective) : (num8 / weatherProfile_0.RadiusEffective));
		double double_3 = 0.0;
		double double_4 = 0.0;
		opffac(double_2, tmetricParams_0.Frequency, topticalParams_0.opmaxd, tmetricParams_0.h1, tmetricParams_0.h2, double_, num8, ref double_3, ref double_4, ref weatherProfile_0, ref tantennaParams_0);
		double num9 = double_3 * double_3 + double_4 * double_4 + 2.0 * double_4 * double_3 * Math.Cos(val);
		if (num9 < 1E-07)
		{
			num9 = 1E-07;
		}
		topticalParams_0.opmaxl = -10.0 * Math.Log10(num9);
		topticalParams_0.exloss = -20.0 * Math.Log10(double_3);
	}

	internal static double ConnectWriter(ref TMetricParams tmetricParams_0, ref TOpticalParams topticalParams_0, ref TAntennaParams tantennaParams_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = 12.56637061435916 * tmetricParams_0.Frequency * 1000.0 / 299792458.0;
		double num7 = tmetricParams_0.h1 / (tmetricParams_0.h1 + tmetricParams_0.h2) * tmetricParams_0.range;
		double num8 = -1.5 * tmetricParams_0.range;
		double num9 = 0.5 * Math.Pow(tmetricParams_0.range, 2.0) - weatherProfile_0.RadiusEffective / 1000.0 * (tmetricParams_0.h1 + tmetricParams_0.h2);
		double num10 = weatherProfile_0.RadiusEffective / 1000.0 * tmetricParams_0.range * tmetricParams_0.h1;
		double num11 = 0.05;
		double num12 = 0.1;
		int num13 = 1;
		while ((num13 < 10) & (Math.Abs(num12) > num11))
		{
			num13++;
			double num14 = Math.Pow(num7, 3.0) + num8 * Math.Pow(num7, 2.0) + num9 * num7 + num10;
			double num2 = 3.0 * Math.Pow(num7, 2.0) + 2.0 * num8 * num7 + num9;
			num12 = num14 / num2;
			num7 -= num12;
			if (num7 < 0.0 || num7 > tmetricParams_0.range)
			{
				num7 = tmetricParams_0.range / 2.0;
			}
		}
		double num3 = tmetricParams_0.range - num7;
		double num4 = tmetricParams_0.h1 - num7 * num7 / (2.0 * weatherProfile_0.RadiusEffective / 1000.0);
		double num5 = tmetricParams_0.h2 - num3 * num3 / (2.0 * weatherProfile_0.RadiusEffective / 1000.0);
		double d = num * num4 * num5 / tmetricParams_0.range + 3.14159265358979;
		double double_ = ((tmetricParams_0.h2 < tmetricParams_0.h1) ? (num7 / weatherProfile_0.RadiusEffective) : (num3 / weatherProfile_0.RadiusEffective));
		double double_2 = 0.0;
		double double_3 = 0.0;
		opffac(double_, tmetricParams_0.Frequency, topticalParams_0.opmaxd, tmetricParams_0.h1, tmetricParams_0.h2, num7, num3, ref double_2, ref double_3, ref weatherProfile_0, ref tantennaParams_0);
		double num6 = double_2 * double_2 + double_3 * double_3 + 2.0 * double_3 * double_2 * Math.Cos(d);
		if (num6 < 1E-07)
		{
			num6 = 1E-07;
		}
		return -10.0 * Math.Log10(num6);
	}

	public static void opffac(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, ref double double_7, ref double double_8, ref Weather.WeatherProfile weatherProfile_0, ref TAntennaParams tantennaParams_0)
	{
		double num = 1.0;
		double num2 = (double_4 - double_3) * 0.001;
		double num3 = double_3 - double_5 * double_5 * 1000.0 / (2.0 * weatherProfile_0.RadiusEffective);
		double num4 = num3 / double_5;
		double num5 = 0.001 * num4;
		if (num5 > 0.05236)
		{
			num5 = Math.Atan(0.001 * num3 / double_5);
		}
		double num6 = num2 / double_2 - double_2 / (2.0 * weatherProfile_0.RadiusEffective);
		num = (double_7 = MoveWriter(num6, num6, ref tantennaParams_0));
		num = MoveWriter(0.0 - (double_0 + num5), num6, ref tantennaParams_0);
		double num7 = AddWriter(weatherProfile_0.SeaState, double_1, num5);
		double num8 = 1.0 / Math.Sqrt(1.0 + 2.0 * double_5 * double_6 / weatherProfile_0.RadiusEffective / (double_2 * Math.Sin(num5)));
		double_8 = num * num7 * num8 * 1.0;
	}

	public static void InitAntennaParams(TAntennaType tantennaType_0, double double_0, double double_1, ref TAntennaParams tantennaParams_0)
	{
		tantennaParams_0.AntennaType = tantennaType_0;
		tantennaParams_0.antbwr = 0.0174532925199433 * double_0;
		tantennaParams_0.antelr = 0.0174532925199433 * double_1;
		tantennaParams_0.elmaxr = 1.047;
		switch (tantennaType_0)
		{
		case TAntennaType.at_Coseq_Sq:
			tantennaParams_0.elmaxr = tantennaParams_0.antelr + 0.78525;
			tantennaParams_0.antfac = Math.Sin(tantennaParams_0.antbwr);
			break;
		case TAntennaType.at_Gaussian:
		{
			double num2 = Math.Sin(tantennaParams_0.antbwr / 2.0);
			double num3 = num2 * num2;
			tantennaParams_0.antfac = (0.0 - Math.Log(2.0)) / (2.0 * num3);
			tantennaParams_0.patrfac = Math.Sin(tantennaParams_0.antelr);
			double num4 = Math.Sqrt(10.11779 * num3);
			tantennaParams_0.elmaxr = tantennaParams_0.antelr + Math.Atan(num4 / Math.Sqrt(1.0 - num4 * num4));
			break;
		}
		case TAntennaType.at_Sin_x_x:
		case TAntennaType.at_Height_Finder_Generic:
		{
			tantennaParams_0.antfac = 1.39157 / Math.Sin(tantennaParams_0.antbwr / 2.0);
			double num = 3.14159265358979 / tantennaParams_0.antfac;
			tantennaParams_0.patrfac = 0.0 - Math.Atan(num / Math.Sqrt(1.0 - num * num));
			if (tantennaType_0 == TAntennaType.at_Sin_x_x)
			{
				tantennaParams_0.elmaxr = tantennaParams_0.antelr - tantennaParams_0.patrfac;
			}
			break;
		}
		}
	}

	internal static double MoveWriter(double double_0, double double_1, ref TAntennaParams tantennaParams_0)
	{
		double num = 1.0;
		double num2 = ((tantennaParams_0.AntennaType != TAntennaType.at_Height_Finder_Generic || double_1 <= tantennaParams_0.antelr) ? tantennaParams_0.antelr : double_1);
		double num3 = double_0 - num2;
		if (tantennaParams_0.AntennaType == TAntennaType.at_Coseq_Sq)
		{
			if (num3 <= tantennaParams_0.antbwr)
			{
				if (num3 < 0.0)
				{
					num = 1.0 + num3 / tantennaParams_0.antbwr;
					if (num < 0.03)
					{
						num = 0.03;
					}
				}
			}
			else
			{
				num = Math.Sin(tantennaParams_0.antbwr) / Math.Sin(Math.Abs(num3));
			}
		}
		else if (tantennaParams_0.AntennaType == TAntennaType.at_Gaussian)
		{
			double num4 = Math.Sin(double_0) - tantennaParams_0.patrfac;
			num = Math.Exp(tantennaParams_0.antfac * num4 * num4);
			if (num < 0.03)
			{
				num = 0.03;
			}
		}
		else if (num3 != 0.0)
		{
			if (!(num3 <= tantennaParams_0.patrfac) && 0.0 - num3 > tantennaParams_0.patrfac)
			{
				double num5 = tantennaParams_0.antfac * Math.Sin(num3);
				num = Math.Sin(num5) / num5;
				if (num > 1.0)
				{
					num = 1.0;
				}
				if (num < 0.03)
				{
					num = 0.03;
				}
			}
			else
			{
				num = 0.03;
			}
		}
		return num;
	}

	public static void skipzone(ref TMetricParams tmetricParams_0, ref TOpticalParams topticalParams_0, ref double double_0, ref double double_1, ref double double_2, double double_3, TEvapDuctParams tevapDuctParams_0, Weather.WeatherProfile weatherProfile_0)
	{
		double radiusEffective = weatherProfile_0.RadiusEffective;
		double double_4 = 0.0;
		hgain(tmetricParams_0.h2, ref double_2, ref double_4, tmetricParams_0.Frequency, tevapDuctParams_0, ref weatherProfile_0);
		double_0 = 0.0;
		if (tmetricParams_0.h2 <= weatherProfile_0.SurfaceDuctHeight)
		{
			double num = 0.9 * weatherProfile_0.SurfaceDuctHeight;
			double num3 = 0.001 / radiusEffective;
			double num4 = num * num3 * 2.0;
			double num5 = num * num3 / (0.1 * weatherProfile_0.SurfaceDuctHeight);
			double num6 = Math.Sqrt(num4);
			double num7 = num6 / num5;
			double num9;
			if (tmetricParams_0.h1 <= num)
			{
				double num8 = Math.Sqrt(num4 - (num - tmetricParams_0.h1) * 2.0 * num3);
				num9 = num7 + (num6 - num8) / num3;
			}
			else
			{
				num9 = Math.Sqrt(num5 * 2.0 * (weatherProfile_0.SurfaceDuctHeight - tmetricParams_0.h1)) / num5;
			}
			double num2;
			if (tmetricParams_0.h2 <= num)
			{
				double num10 = Math.Sqrt(num4 - (num - tmetricParams_0.h2) * 2.0 * num3);
				num2 = num7 + (num6 - num10) / num3;
			}
			else
			{
				num2 = Math.Sqrt(num5 * 2.0 * (weatherProfile_0.SurfaceDuctHeight - tmetricParams_0.h2)) / num5;
			}
			double_0 = (num9 + num2) / 1000.0;
			if (double_0 < topticalParams_0.r1min)
			{
				double_0 = topticalParams_0.r1min;
			}
			double_1 = double_3 + 20.0 * Math.Log10(double_0) - double_2;
		}
	}

	internal static double DeleteWriter(double double_0, double double_1, double double_2)
	{
		double num = 0.0051 * double_0 * double_0;
		double num2 = double_1 / 1000000.0 / 299792458.0 * num * 2.0 * 3.14159265358979;
		double result = 1.0;
		if (num != 0.0)
		{
			double num3 = num2 * 2.0 * Math.Sin(double_2 * 0.0174532925199433);
			double num4 = 0.5 * num3 * num3;
			double num5 = 3.2 * num4;
			double num6 = num5 - 2.0 + Math.Sqrt(num5 * num5 - 7.0 * num4 + 9.0);
			if (num6 > 0.0)
			{
				result = 1.0 / Math.Sqrt(num6);
			}
		}
		return result;
	}

	internal static double AddWriter(int int_0, double double_0, double double_1)
	{
		double num = 0.0;
		switch (int_0)
		{
		case 0:
			num = 0.0;
			break;
		case 1:
			num = 0.05;
			break;
		case 2:
			num = 0.3;
			break;
		case 3:
			num = 0.875;
			break;
		case 4:
			num = 1.875;
			break;
		case 5:
			num = 3.25;
			break;
		case 6:
			num = 5.0;
			break;
		case 7:
			num = 7.5;
			break;
		case 8:
			num = 11.5;
			break;
		case 9:
			num = 15.0;
			break;
		}
		double num2 = double_0 / 1000000.0 / 299792458.0 * num * 2.0 * 3.14159265358979;
		double result = 1.0;
		if (num != 0.0)
		{
			double x = num2 * 2.0 * Math.Sin(double_1 * 0.0174532925199433);
			double num3 = 0.5 * Math.Pow(x, 2.0);
			double num4 = 3.2 * num3 - 2.0 + Math.Sqrt(Math.Pow(3.2 * num3, 2.0) - 7.0 * num3 + 9.0);
			if (num4 > 0.0)
			{
				result = 1.0 / Math.Sqrt(num4);
			}
		}
		return result;
	}

	internal static double DestroyWriter(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = 0.03;
		double num2 = double_1 * 0.0174532925199433 / 1000.0;
		double d = double_0 / 1000000000.0;
		double value = double_3 * double_4 / 1000.0;
		double value2 = Math.Sqrt(2.0 * Math.Abs(value));
		double num3 = ((2.0 * Math.Abs(value2) <= num2) ? (-10.0 * Math.Log10(2.0 * Math.Abs(value2) / double_1)) : 0.0);
		return 92.45 + 20.0 * Math.Log10(d) + 10.0 * Math.Log10(double_2) + num * double_2 + num3;
	}

	internal static double ComputeWriter(double double_0)
	{
		return 299792458.0 / (2.0 * double_0 * 1852.0);
	}

	internal static double PatchWriter(double double_0, double double_1)
	{
		if (Math.Abs(MathFunctions.Sign(double_1) - MathFunctions.Sign(double_0)) == 2)
		{
			throw new Exception("MRound cannot accept arguments of different signs");
		}
		double num = Math.Abs(double_1);
		double num2 = Math.Abs(double_0);
		if (num2 - num * Conversion.Fix(num2 / num) < num / 2.0)
		{
			return (double)MathFunctions.Sign(double_0) * num * Conversion.Fix(num2 / num);
		}
		return (double)MathFunctions.Sign(double_0) * num * (Conversion.Fix(num2 / num) + 1.0);
	}

	internal static double SelectWriter(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = double_0 * 1852.0;
		double val = 3.14159265358979 * num * num * Math.Tan(double_2 * 0.0174532925199433 / 2.0) * Math.Tan(double_1 * 0.0174532925199433 / 2.0) / Math.Sin(double_4 * 0.0174532925199433);
		double val2 = num * double_2 * 0.0174532925199433 * 299792458.0 * double_3 * 1E-06 / (2.0 * Math.Cos(double_4 * 0.0174532925199433));
		return Math.Min(val, val2);
	}

	internal static double CallWriter(double DistanceToTarget, double VertBeamWidth, double HorzBeamWidth, double PulseWidth, double ElevationAngle)
	{
		double num = DistanceToTarget * 1852.0;
		double val = 3.14159265358979 * num * num * Math.Tan(HorzBeamWidth * 0.0174532925199433 / 2.0) * Math.Tan(VertBeamWidth * 0.0174532925199433 / 2.0) / Math.Sin(ElevationAngle * 0.0174532925199433);
		double val2 = num * HorzBeamWidth * 0.0174532925199433 * 299792458.0 * PulseWidth * 1E-06 / (2.0 * Math.Cos(ElevationAngle * 0.0174532925199433));
		return Math.Log10(Math.Min(val, val2)) * 10.0;
	}

	internal static double LogoutWriter(double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_0 / 1000000000.0;
		double[] array = new double[26]
		{
			1.0, 2.0, 4.0, 6.0, 7.0, 8.0, 10.0, 12.0, 15.0, 20.0,
			25.0, 30.0, 35.0, 40.0, 45.0, 50.0, 60.0, 70.0, 80.0, 90.0,
			100.0, 120.0, 150.0, 200.0, 300.0, 400.0
		};
		double[] array2 = new double[26]
		{
			3.87E-05, 0.000154, 0.00065, 0.00175, 0.00301, 0.00454, 0.0101, 0.0188, 0.0367, 0.0751,
			0.124, 0.187, 0.263, 0.35, 0.442, 0.536, 0.707, 0.851, 0.975, 1.06,
			1.12, 1.18, 1.31, 1.45, 1.36, 1.32
		};
		double[] array3 = new double[26]
		{
			3.52E-05, 0.000138, 0.000591, 0.00155, 0.00265, 0.00395, 0.00887, 0.0168, 0.0335, 0.0691,
			0.113, 0.167, 0.233, 0.31, 0.393, 0.479, 0.642, 0.784, 0.906, 0.999,
			1.06, 1.13, 1.27, 1.42, 1.35, 1.31
		};
		double[] array4 = new double[26]
		{
			0.912, 0.963, 1.121, 1.308, 1.332, 1.327, 1.276, 1.217, 1.154, 1.099,
			1.061, 1.021, 0.979, 0.939, 0.903, 0.873, 0.826, 0.793, 0.769, 0.753,
			0.743, 0.731, 0.71, 0.689, 0.688, 0.683
		};
		double[] array5 = new double[26]
		{
			0.88, 0.923, 1.075, 1.265, 1.312, 1.31, 1.264, 1.2, 1.128, 1.065,
			1.03, 1.0, 0.963, 0.929, 0.897, 0.868, 0.824, 0.793, 0.769, 0.754,
			0.744, 0.732, 0.711, 0.69, 0.689, 0.684
		};
		int num3 = 0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		do
		{
			if (!(num < array[num3 + 1]))
			{
				num3++;
				continue;
			}
			double num8 = Math.Log10(num / array[num3]) / Math.Log10(array[num3 + 1] / array[num3]);
			num4 = array2[num3] * Math.Pow(array2[num3 + 1] / array2[num3], num8);
			num5 = array3[num3] * Math.Pow(array3[num3 + 1] / array3[num3], num8);
			num6 = array4[num3] + (array4[num3 + 1] - array4[num3]) * num8;
			num7 = array5[num3] + (array5[num3 + 1] - array5[num3]) * num8;
			break;
		}
		while (num3 <= 23);
		double num9 = Math.Cos(0.0174532925199433 * double_2);
		double num10 = num9 * num9 * Math.Cos(0.0349065850398866 * double_3);
		double num2 = (num4 + num5 + (num4 - num5) * num10) / 2.0;
		double y = (num4 * num6 + num5 * num7 + (num4 * num6 - num5 * num7) * num10) / (2.0 * num2);
		return num2 * Math.Pow(double_1, y);
	}

	internal static bool ViewWriter(ref TRadar tradar_0, double double_0, double double_1)
	{
		if (double_1 <= 0.0)
		{
			return false;
		}
		if (tradar_0.PulseWidth == 0.0)
		{
			return false;
		}
		if (tradar_0.HorzBeamWidth != 0.0 && tradar_0.VertBeamWidth != 0.0)
		{
			if (tradar_0.Frequency == 0.0)
			{
				return false;
			}
			double num = 10.0 * Math.Log10(12.56637061435916 / (2.0 * Math.Sin(tradar_0.HorzBeamWidth * 0.0174532925199433 / 2.0) * tradar_0.VertBeamWidth * 0.0174532925199433));
			double num3 = 1.0 / (tradar_0.PulseWidth * 1E-06);
			double num4 = Math.Pow(10.0, num / 10.0);
			double num5 = 299792458.0 / tradar_0.Frequency;
			double num6 = tradar_0.AntennaTemp + tradar_0.ReceiverTemp;
			double num7 = 1.380650424E-23 * num6 * num3;
			double num8 = 1.0 * num7;
			double num9 = Math.Pow(10.0, tradar_0.ProcessingGain / 10.0);
			double num10 = Math.Pow(10.0, FlushStub(double_1 * 1852.0 / 1000.0, tradar_0.Frequency) / 10.0);
			double num2 = tradar_0.PowerOutputW * (num4 * num4) * double_0 * num9 * 4.0 * 3.14159265358979 / (num10 * num10 * num5 * num5);
			if (num8 <= num2)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal static double ValidateWriter(ref TRadar tradar_0, double double_0)
	{
		double num = 0.01;
		double num2 = 1000.0;
		if (ViewWriter(ref tradar_0, double_0, num))
		{
			while (ViewWriter(ref tradar_0, double_0, num2))
			{
				num = num2;
				num2 = num * 2.0;
			}
			double num3;
			while (true)
			{
				num3 = (num2 - num) / 2.0 + num;
				if (!(num2 - num >= 0.01))
				{
					break;
				}
				if (ViewWriter(ref tradar_0, double_0, num3))
				{
					num = num3;
				}
				else
				{
					num2 = num3;
				}
			}
			return num3;
		}
		return 0.0;
	}

	internal static float LoginWriter(XSection xsection_0, ActiveUnit activeUnit_0, float float_0)
	{
		if (float_0 < 315f && float_0 > 45f)
		{
			if ((float_0 >= 45f && float_0 <= 135f) || (float_0 >= 225f && float_0 <= 315f))
			{
				return xsection_0.GetSide(activeUnit_0);
			}
			if (float_0 >= 135f && float_0 <= 225f)
			{
				return xsection_0.GetRear(activeUnit_0);
			}
			return 0f;
		}
		return xsection_0.GetFront(activeUnit_0);
	}

	internal static float GetWriter(object object_0, XSection._SignatureType _SignatureType_0, Module_Unit.Unit unit_0, Module_Unit.Unit unit_1)
	{
		XSection xSection = Sensor.smethod_0((ActiveUnit)object_0, _SignatureType_0);
		if (xSection == null)
		{
			xSection = Sensor.smethod_0((ActiveUnit)object_0, _SignatureType_0);
		}
		if (xSection == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		}
		if (xSection.isDBInvisible((ActiveUnit)object_0))
		{
			return 0f;
		}
		float float_ = Module_Unit.BearingToUnit_Relative((Module_Unit.Unit)object_0, unit_0);
		float num = Module_Unit.BearingToUnit_Relative((Module_Unit.Unit)object_0, unit_1);
		float result = LoginWriter(xSection, (ActiveUnit)object_0, float_);
		float num2 = LoginWriter(xSection, (ActiveUnit)object_0, num);
		if (MathFunctions.DeleteRequest(float_, num) <= 10f)
		{
			return result;
		}
		float float_2 = Module_Unit.BearingToUnit_True((Module_Unit.Unit)object_0, unit_0);
		float float_3 = Module_Unit.BearingToUnit_True((Module_Unit.Unit)object_0, unit_1);
		float num3 = Math.Abs(MathFunctions.DeleteRequest(Math2.SpecularReflectionAzimuth(((Module_Unit.Unit)object_0).CurrentHeading, float_2), float_3));
		float num4 = ((num3 < 5f) ? (num2 + 20f) : ((num3 < 10f) ? (num2 + 10f) : num2));
		float num5 = Math.Abs(MathFunctions.DeleteRequest(Math2.SpecularReflectionAzimuth(Math2.UpdateClass(((Module_Unit.Unit)object_0).CurrentHeading - 120f), float_2), float_3));
		num4 = ((num5 < 5f) ? Math.Max(num4, num2 + 10f) : ((num5 < 10f) ? Math.Max(num4, num2 + 5f) : Math.Max(num2, num4)));
		float num6 = Math.Abs(MathFunctions.DeleteRequest(Math2.SpecularReflectionAzimuth(Math2.UpdateClass(((Module_Unit.Unit)object_0).CurrentHeading + 120f), float_2), float_3));
		if (!(num6 < 5f))
		{
			if (!(num6 < 10f))
			{
				return Math.Max(num2, num4);
			}
			return Math.Max(num4, num2 + 5f);
		}
		return Math.Max(num4, num2 + 10f);
	}

	public static float ModifiedSignature_MobileUnits_db(Sensor sensor_0, float float_0, ActiveUnit activeUnit_0)
	{
		TTarget tTarget = new TTarget();
		tTarget.RCS = float_0;
		double num = tTarget.RCS_m2;
		if (Module_ActiveUnit.CancelTokenizer(activeUnit_0))
		{
			int num2 = 0;
			foreach (Mount mount in activeUnit_0.Mounts)
			{
				if (mount.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					num2++;
				}
			}
			if (num2 == 0)
			{
				return 0f;
			}
			num *= Math.Sqrt(num2);
		}
		float num3 = activeUnit_0.CurrentSpeed / (float)activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.GetCurrentAltitude(), ActiveUnit.Throttle.Flank, bool_0: false);
		float num4 = ((num3 == 0f) ? 1f : ((num3 < 0.2f) ? 30f : ((num3 < 0.4f) ? 60f : ((num3 < 0.6f) ? 120f : ((num3 < 0.8f) ? 250f : 500f)))));
		Sensor.RadioElectronicFrequency[] searchFreqs = sensor_0.SearchFreqs;
		float num5 = 0f;
		Sensor.RadioElectronicFrequency[] array = searchFreqs;
		Sensor.RadioElectronicFrequency[] array2 = array;
		foreach (Sensor.RadioElectronicFrequency obj in array2)
		{
			if (obj.Band == Sensor.FrequencyBand.J_Band)
			{
				num5 = 0.1f;
			}
			if (obj.Band == Sensor.FrequencyBand.K_Band)
			{
				num5 = 0.2f;
			}
			if (obj.Band == Sensor.FrequencyBand.L_Band)
			{
				num5 = 0.3f;
			}
			if (obj.Band == Sensor.FrequencyBand.M_Band)
			{
				num5 = 0.4f;
			}
		}
		num4 = Math.Max(1f, num4 * (1f + num5));
		if (sensor_0.Codes.SyntheticApertureRadar && activeUnit_0.CurrentSpeed == 0f)
		{
			num4 = Math.Max(num4, 500f);
		}
		double num8 = (tTarget.RCS_m2 = num * (double)num4);
		double num6 = num8;
		num = num6;
		return (float)tTarget.RCS;
	}

	internal static Geodesic_Vincenty.TCoord WriteWriter(int int_0, ref Geodesic_Vincenty.TCoord[] tcoord_0, ref double[] double_0)
	{
		return default(Geodesic_Vincenty.TCoord);
	}

	public static void Main__()
	{
		TRadar tRadar = new TRadar();
		TJammer[] obj = new TJammer[2]
		{
			new TJammer(),
			null
		};
		TTarget tTarget = new TTarget();
		Weather.WeatherProfile weatherProfile = new Weather.WeatherProfile();
		tRadar.Altitude = 10f;
		tRadar.VertBeamWidth = 16.0;
		tRadar.AntennaGain = 28.5;
		tRadar.PowerOutputW = 280000.0;
		tRadar.ProcessingGain = 0.0;
		tRadar.SystemNoiseLevel = 5.5;
		tRadar.PulseWidth = 125.0;
		tRadar.Frequency = 5600000000.0;
		tRadar.PRF = 800.0;
		tRadar.ElevationAngle = 0.0;
		obj[0].Altitude = 500.0;
		obj[0].AntennaGain = 3.0;
		obj[0].Bandwidth = 2000000.0;
		obj[0].PowerOutputW = 100.0;
		tTarget.Altitude = 10f;
		tTarget.RCS = 20.1;
		weatherProfile.FractionUnderRain = 0.5f;
		weatherProfile.GroundReflectionCoeff = 1.0;
		weatherProfile.SurfaceDuctHeight = 0.0;
		weatherProfile.EvaporationDuctHeight = 0.0;
		new StreamWriter("TESTFILE");
	}
}
