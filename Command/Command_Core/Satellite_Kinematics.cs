using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using Zeptomoby.OrbitTools;

namespace Command_Core;

public sealed class Satellite_Kinematics : ActiveUnit_Kinematics
{
	private Zeptomoby.OrbitTools.Satellite definitionFacade;

	private SatelliteModel_Tukey.TSatellite m_ValFacade;

	public long Apogee
	{
		get
		{
			if (m_ValFacade == null)
			{
				return (long)Math.Round(definitionFacade.Orbit.Apogee * 1000.0);
			}
			return (long)Math.Round(m_ValFacade.ApogeeAltitude_km * 1000.0);
		}
	}

	public long Perigee
	{
		get
		{
			if (m_ValFacade == null)
			{
				return (long)Math.Round(definitionFacade.Orbit.Perigee * 1000.0);
			}
			return (long)Math.Round(m_ValFacade.PerigeeAltitude_km * 1000.0);
		}
	}

	public Satellite_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public void SetOrbit_Tukey(string[] string_0)
	{
		definitionFacade = null;
		m_ValFacade = new SatelliteModel_Tukey.TSatellite();
		m_ValFacade.method_0(string_0);
		try
		{
			Move(0f, bool_0: false, bool_1: false, myUnit.ParentScen.Time);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			SetOrbit_Tukey((float)m_ValFacade.Inclination, (long)Math.Round(m_ValFacade.ApogeeAltitude_km * 1000.0), (long)Math.Round(m_ValFacade.PerigeeAltitude_km * 1000.0), m_ValFacade.MeanAnomaly);
			ProjectData.ClearProjectError();
		}
	}

	public void SetOrbit_Tukey(float float_0, long long_0, long long_1)
	{
		SetOrbit_Tukey(float_0, long_0, long_1, 0.0);
	}

	public void SetOrbit_Tukey(float float_0, long long_0, long long_1, double double_0)
	{
		definitionFacade = null;
		m_ValFacade = new SatelliteModel_Tukey.TSatellite();
		m_ValFacade.ReInit(float_0, (double)long_0 / 1000.0, (double)long_1 / 1000.0);
		m_ValFacade.MeanAnomaly = double_0;
		try
		{
			Move(0f, bool_0: false, bool_1: false, myUnit.ParentScen.Time);
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

	public void SetOrbit_OT(string[] string_0)
	{
		try
		{
			m_ValFacade = null;
			if (string_0.Length == 2)
			{
				List<string> list = string_0.ToList();
				list.Insert(0, "Mysat");
				string_0 = list.ToArray();
			}
			if (Operators.CompareString(string_0[1].Substring(17, 1), " ", TextCompare: false) != 0)
			{
				string[] array = string_0[1].Split(' ');
				string_0[1] = $"{array[0]} {array[1],6} {array[2],-8} {array[3],-14} {array[4],11} {array[5],-8} {array[6],-7} {array[7]} {array[8],5}";
			}
			if (Operators.CompareString(string_0[2].Substring(7, 2), "  ", TextCompare: false) != 0)
			{
				string[] gparam_ = string_0[2].Split(' ');
				if (gparam_.Count() != 9)
				{
					ArrayExtensions.Add(ref gparam_, "0");
				}
				string_0[2] = $"{gparam_[0]} {gparam_[1],5} {gparam_[2],-8} {gparam_[3],8} {gparam_[4],-7} {gparam_[5],-8} {gparam_[6],-8} {gparam_[7],11} {gparam_[8],6}";
			}
			Tle tle_ = new Tle(string_0[0], string_0[1], string_0[2]);
			definitionFacade = new Zeptomoby.OrbitTools.Satellite(tle_);
			Move(0f, bool_0: false, bool_1: false, myUnit.ParentScen.Time);
			if (float.IsNaN(myUnit.CurrentHeading))
			{
				SetOrbit_Tukey(string_0);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			SetOrbit_Tukey(string_0);
			ProjectData.ClearProjectError();
		}
	}

	public void PredictPosition(DateTime dateTime_0, ref double double_0, ref double double_1, ref double double_2, ref double double_3)
	{
		Satellite.SatelliteOrbitAnchor orbitAnchor = ((Satellite)myUnit).OrbitAnchor;
		if (orbitAnchor == null)
		{
			if (definitionFacade == null)
			{
				double double_4 = 0.0;
				m_ValFacade.Predict_Position(dateTime_0, bool_0: true, ref double_0, ref double_1, ref double_2, ref double_4);
				if (double_2 < (double)Perigee / 1000.0)
				{
					double_2 = (double)Perigee / 1000.0;
				}
				if (double_2 > (double)Apogee / 1000.0)
				{
					double_2 = (double)Apogee / 1000.0;
				}
				double_3 = double_4 * 1000.0 * 1.94384;
			}
			else
			{
				EciTime eciTime = definitionFacade.PositionEci(dateTime_0.ToUniversalTime());
				Geo geo = new Geo(eciTime, new Julian(dateTime_0.ToUniversalTime()));
				double_0 = geo.LatitudeDeg;
				double_1 = geo.LongitudeDeg;
				double_2 = geo.Altitude;
				double num = Math.Abs(eciTime.Velocity.X * 1000.0);
				double_3 = num * 1.94384;
			}
		}
		else
		{
			double_1 = orbitAnchor.Longitude;
			double_0 = orbitAnchor.Latitude;
			double_2 = orbitAnchor.Altitude / 1000f;
			double_3 = 0.0;
		}
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		try
		{
			((Satellite)myUnit).InvalidatePositionVector();
			double double_ = 0.0;
			double double_5 = 0.0;
			double double_6 = 0.0;
			double double_7 = 0.0;
			try
			{
				PredictPosition(dateTime_0, ref double_, ref double_5, ref double_6, ref double_7);
			}
			catch (DecayException projectError)
			{
				ProjectData.SetProjectError(projectError);
				myUnit.Destroy(bool_0: false, bool_1: false, bool_2: true, "Orbit decayed");
				ProjectData.ClearProjectError();
			}
			double double_8 = 0.0;
			double double_9 = 0.0;
			double double_10 = 0.0;
			double double_11 = 0.0;
			PredictPosition(dateTime_0.AddSeconds(1.0), ref double_8, ref double_9, ref double_10, ref double_11);
			PredictPosition(dateTime_0, ref double_, ref double_5, ref double_6, ref double_7);
			PredictPosition(dateTime_0.AddSeconds(1.0), ref double_8, ref double_9, ref double_10, ref double_11);
			if (!double.IsNaN(double_) && !double.IsNaN(double_5))
			{
				myUnit.CurrentHeading = Math2.PublishClass(double_, double_5, double_8, double_9);
				if (myUnit.ParentScen.TimeCompression_SimSeconds <= 1)
				{
					float num = (float)((double)dateTime_0.Millisecond / 1000.0);
					float num2 = Math2.VerifyClass(double_, double_5, double_8, double_9);
					float float_ = num * num2;
					double double_12 = double_5;
					double double_2 = double_;
					ActiveUnit activeUnit = myUnit;
					bool? nullable_ = null;
					double double_3 = activeUnit.GetLongitude(nullable_);
					ActiveUnit activeUnit2 = myUnit;
					bool? nullable_2 = null;
					double double_4 = activeUnit2.GetLatitude(nullable_2);
					Geodesic_EdWilliams.CalcPoint_Williams(double_12, double_2, ref double_3, ref double_4, float_, myUnit.CurrentHeading);
					activeUnit2.SetLatitude(nullable_2, double_4);
					activeUnit.SetLongitude(nullable_, double_3);
					myUnit.SetCurrentAltitude(bool_0: false, (float)((double_6 + (double_10 - double_6) * (double)num) * 1000.0));
					myUnit.CurrentSpeed = (float)(double_7 + (double_11 - double_7) * (double)num);
				}
				else
				{
					myUnit.SetLatitude(null, double_);
					myUnit.SetLongitude(null, double_5);
					myUnit.SetCurrentAltitude(bool_0: false, (float)(double_6 * 1000.0));
					myUnit.CurrentSpeed = (float)double_7;
				}
				myUnit.Longitude_LastReported = myUnit.GetLongitude();
				myUnit.Latitude_LastReported = myUnit.GetLatitude();
				if (!bool_1)
				{
					myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
				}
				Module_Unit.FlushTokenizer(myUnit, float_0);
				return;
			}
			throw new Exception("NaN values generated duirng orbital calculation.");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100755", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			throw;
		}
	}
}
