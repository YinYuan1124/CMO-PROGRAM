using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Kinematics
{
	public enum UnitThrottlePreset : byte
	{
		FullStop,
		Loiter,
		Cruise,
		Full,
		Flank,
		None
	}

	protected class AltBandComparer_SortyByMaxAltAscending : IComparer<AltBand>
	{
		internal int RevertInterruptibleMock(AltBand altBand_0, AltBand altBand_1)
		{
			if (altBand_0 == null || altBand_1 == null)
			{
				_ = Debugger.IsAttached;
				if (altBand_0 == null && altBand_1 == null)
				{
					return 0;
				}
				if (altBand_0 == null)
				{
					return -1;
				}
				if (altBand_1 == null)
				{
					return 1;
				}
			}
			return altBand_0.MaxAlt.CompareTo(altBand_1.MaxAlt);
		}

		int IComparer<AltBand>.Compare(AltBand x, AltBand y)
		{
			return RevertInterruptibleMock(x, y);
		}
	}

	public enum _SprintAndDriftCadence : short
	{
		Sprint,
		Drift
	}

	protected ActiveUnit myUnit;

	protected float _ClimbRate;

	internal const float invocationWrapper = 16.256f;

	protected float ActualMovementVector;

	protected float? _DesiredSpeedOverride;

	private bool classWrapper;

	protected float _TacticalRadius;

	private AltBand m_RequestWrapper;

	protected int? _MaxSpeedTotal;

	private AltBand _ValueWrapper;

	private string tokenizerWrapper;

	protected float _ReserveFuel;

	protected float _JokerFuel;

	public _SprintAndDriftCadence SprintAndDriftCadence;

	public bool HasAdjustedSpeedForCavitation;

	internal const int m_StubWrapper = 89;

	internal const int writerWrapper = -89;

	internal const int m_SpecificationWrapper = 89;

	public const int DefaultSpeedLoiter = 3;

	public const int DefaultSpeedCruise = 10;

	public const int DefaultSpeedFull = 20;

	public const int DefaultSpeedFlank = 30;

	protected UnitThrottlePreset _ThrottlePreset;

	public BallisticTrajectory BallisticTrajectory;

	private float? m_WatcherWrapper;

	private float? _ReponseWrapper;

	private ThreadLocal<List<AltBand>> m_DescriptorWrapper;

	protected ObservableList<Engine> _MyPropulsion;

	private bool m_PoolWrapper;

	private bool taskWrapper;

	private bool m_FilterWrapper;

	public bool PerformOutOfSequenceExportLocation;

	private List<AltBand> _TestsWrapper;

	public virtual UnitThrottlePreset ThrottlePreset
	{
		get
		{
			return _ThrottlePreset;
		}
		set
		{
			_ThrottlePreset = value;
			if (value != 0 && value != UnitThrottlePreset.None)
			{
				myUnit.AI.HoldPosition = false;
			}
			try
			{
				if (myUnit.IsAircraft && myUnit.Kinematics.ThrottlePreset == UnitThrottlePreset.FullStop && !((Aircraft)myUnit).GetCanHover(bool_1: false))
				{
					myUnit.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
				}
				if (value != UnitThrottlePreset.None)
				{
					myUnit.Kinematics.DesiredSpeedOverride = myUnit.DesiredSpeed;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100169", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual float ReserveFuel
	{
		get
		{
			return _ReserveFuel;
		}
		set
		{
			_ReserveFuel = value;
		}
	}

	public virtual float JokerFuel
	{
		get
		{
			return _JokerFuel;
		}
		set
		{
			_JokerFuel = value;
		}
	}

	public virtual float? DesiredSpeedOverride
	{
		get
		{
			if (myUnit.IsGroupLead() && myUnit.GetParentGroup().Kinematics.LeadAllowedToSlowDown)
			{
				return null;
			}
			return _DesiredSpeedOverride;
		}
		set
		{
			try
			{
				_DesiredSpeedOverride = value;
				if (value.HasValue)
				{
					if (myUnit.IsGroupLead())
					{
						myUnit.GetParentGroup().Kinematics.LeadAllowedToSlowDown = false;
					}
				}
				else
				{
					myUnit.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100170", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual bool DesiredAltitudeOverride
	{
		get
		{
			return classWrapper;
		}
		set
		{
			try
			{
				classWrapper = value;
				if (!value)
				{
					if (myUnit.IsSubmarine)
					{
						((Submarine)myUnit).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					}
					if (myUnit.IsAircraft)
					{
						((Aircraft)myUnit).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100171", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			if (ActualMovementVector != 0f)
			{
				xmlWriter_0.WriteElementString("AMV", XmlConvert.ToString(ActualMovementVector));
			}
			if (_DesiredSpeedOverride.HasValue)
			{
				xmlWriter_0.WriteElementString("DSO", _DesiredSpeedOverride.ToString());
			}
			if (classWrapper)
			{
				xmlWriter_0.WriteElementString("DAO", classWrapper.ToString());
			}
			if (_ReserveFuel != 0f)
			{
				xmlWriter_0.WriteElementString("ReserveFuel", _ReserveFuel.ToString());
			}
			if (ThrottlePreset != 0)
			{
				xmlWriter_0.WriteElementString("SP", ((byte)ThrottlePreset).ToString());
			}
			if (SprintAndDriftCadence != 0)
			{
				XmlWriter obj = xmlWriter_0;
				short sprintAndDriftCadence = (short)SprintAndDriftCadence;
				obj.WriteElementString("SADC", sprintAndDriftCadence.ToString());
			}
			if (BallisticTrajectory != null)
			{
				xmlWriter_0.WriteStartElement("BallisticTrajectory");
				BallisticTrajectory.ToXML(ref xmlWriter_0);
				xmlWriter_0.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100166", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ActiveUnit activeUnit_0)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlNode_0.ChildNodes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				try
				{
					switch (xmlNode.Name)
					{
					case "DSO":
					case "DesiredSpeedOverride":
						if (Operators.CompareString(xmlNode.InnerText, true.ToString(), TextCompare: false) == 0)
						{
							activeUnit_0.Kinematics._DesiredSpeedOverride = activeUnit_0.DesiredSpeed;
						}
						else if (Operators.CompareString(xmlNode.InnerText, false.ToString(), TextCompare: false) == 0)
						{
							activeUnit_0.Kinematics._DesiredSpeedOverride = null;
						}
						else
						{
							activeUnit_0.Kinematics._DesiredSpeedOverride = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						}
						break;
					case "SP":
						activeUnit_0.Kinematics.ThrottlePreset = (UnitThrottlePreset)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "ReserveFuel":
						activeUnit_0.Kinematics._ReserveFuel = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "BallisticTrajectory":
					{
						ActiveUnit_Kinematics kinematics = activeUnit_0.Kinematics;
						XmlNode xmlNode_ = xmlNode.FirstChild;
						kinematics.BallisticTrajectory = BallisticTrajectory.FromXML(ref xmlNode_);
						break;
					}
					case "SADC":
						activeUnit_0.Kinematics.SprintAndDriftCadence = (_SprintAndDriftCadence)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "DAO":
					case "DesiredAltitudeOverride":
						activeUnit_0.Kinematics.classWrapper = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AMV":
					case "ActualMovementVector":
						activeUnit_0.Kinematics.ActualMovementVector = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 100167", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		try
		{
			if (activeUnit_0.Kinematics.ReserveFuel == 0f && activeUnit_0.IsAircraft)
			{
				activeUnit_0.Kinematics.DetermineReserveFuelQty();
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100168", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SimpleBallisticFlight_Vaccum(float float_0, float float_1, bool bool_0)
	{
		double num = (double)myUnit.CurrentSpeed * 0.514444;
		double num2 = num * Math2.FillClass(float_1) - (double)float_0 * PhysicalConstants.InstantiateStub((int)Math.Round(myUnit.GetCurrentAltitude()));
		double x = num * Math2.PopClass(float_1);
		double num3 = (double)myUnit.GetCurrentAltitude() + (double)float_0 * num2;
		myUnit.DesiredAltitude = (float)num3;
		ChangeAltitude(float_0, myUnit.DesiredAltitude, null, bool_0: false);
		if (myUnit.CurrentHeading != myUnit.DesiredHeading)
		{
			TurnToDesiredHeading(float_0);
		}
		myUnit.ActualHorizMovement(float_0, bool_0);
		double num4 = Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num2, 2.0)) * 1.94384;
		myUnit.CurrentSpeed = (float)num4;
		myUnit.Attitude_Pitch = (float)(Math.Atan2(num2, x) * 57.2957795130823);
	}

	public void FollowSpeedPreset()
	{
		if (myUnit != null && myUnit.Kinematics.DesiredSpeedOverride.HasValue)
		{
			switch (ThrottlePreset)
			{
			case UnitThrottlePreset.FullStop:
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				break;
			case UnitThrottlePreset.Loiter:
				myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				break;
			case UnitThrottlePreset.Cruise:
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				break;
			case UnitThrottlePreset.Full:
				myUnit.SetThrottle(ActiveUnit.Throttle.Full);
				break;
			case UnitThrottlePreset.Flank:
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				break;
			}
			myUnit.Kinematics.DesiredSpeedOverride = myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), (ActiveUnit.Throttle)ThrottlePreset, bool_0: false);
		}
	}

	public virtual void DetermineReserveFuelQty(bool bool_0 = false)
	{
		ReserveFuel = 0f;
	}

	public virtual float Acceleration_Actual(ActiveUnit.Throttle throttle_0, float float_0, float float_1)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		GlobalVariables.ActiveUnitType unitType = myUnit.UnitType;
		if (1 == 0)
		{
		}
		float result = unitType switch
		{
			GlobalVariables.ActiveUnitType.Aircraft => ((Aircraft)myUnit).Kinematics.Acceleration_Actual(throttle_0, float_0, float_1), 
			GlobalVariables.ActiveUnitType.Ship => ((Ship)myUnit).Kinematics.Acceleration_Actual(throttle_0, float_0, float_1), 
			GlobalVariables.ActiveUnitType.Submarine => ((Submarine)myUnit).Kinematics.Acceleration_Actual(throttle_0, float_0, float_1), 
			GlobalVariables.ActiveUnitType.Facility => ((Facility)myUnit).Kinematics.Acceleration_Actual(throttle_0, float_0, float_1), 
			GlobalVariables.ActiveUnitType.Weapon => ((Weapon)myUnit).Kinematics.Acceleration_Actual(throttle_0, float_0, float_1), 
			GlobalVariables.ActiveUnitType.Satellite => ((Satellite)myUnit).Kinematics.Acceleration_Actual(throttle_0, float_0, float_1), 
			GlobalVariables.ActiveUnitType.Vehicle => ((Vehicle)myUnit).Kinematics.Acceleration_Actual(throttle_0, float_0, float_1), 
			_ => throw new NotImplementedException(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public virtual float Acceleration_Nominal(ActiveUnit.Throttle throttle_0, float float_0)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		GlobalVariables.ActiveUnitType unitType = myUnit.UnitType;
		if (1 == 0)
		{
		}
		float result = unitType switch
		{
			GlobalVariables.ActiveUnitType.Aircraft => ((Aircraft)myUnit).Kinematics.Acceleration_Nominal(throttle_0, float_0), 
			GlobalVariables.ActiveUnitType.Ship => ((Ship)myUnit).Kinematics.Acceleration_Nominal(throttle_0, float_0), 
			GlobalVariables.ActiveUnitType.Submarine => ((Submarine)myUnit).Kinematics.Acceleration_Nominal(throttle_0, float_0), 
			GlobalVariables.ActiveUnitType.Facility => ((Facility)myUnit).Kinematics.Acceleration_Nominal(throttle_0, float_0), 
			GlobalVariables.ActiveUnitType.Weapon => ((Weapon)myUnit).Kinematics.Acceleration_Nominal(throttle_0, float_0), 
			GlobalVariables.ActiveUnitType.Satellite => ((Satellite)myUnit).Kinematics.Acceleration_Nominal(throttle_0, float_0), 
			GlobalVariables.ActiveUnitType.Vehicle => ((Vehicle)myUnit).Kinematics.Acceleration_Nominal(throttle_0, float_0), 
			_ => throw new NotImplementedException(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public virtual float GetClimbRate_Nominal(bool bool_0 = true)
	{
		return _ClimbRate;
	}

	[SpecialName]
	public virtual void SetClimbRate_Nominal(bool bool_0, float float_0)
	{
		_ClimbRate = float_0;
	}

	public virtual float ClimbRate_Actual(float float_0)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (float_0 <= 0f)
			{
				return 0f;
			}
			return (float)Math.Min(GetClimbRate_Nominal(), (double)myUnit.CurrentSpeed * 0.514444 * Math2.FillClass(float_0));
		}
		return GetClimbRate_Nominal();
	}

	public virtual float ClimbRate_Max()
	{
		return _ClimbRate;
	}

	public virtual float RollRate()
	{
		return 0f;
	}

	public virtual float PitchRate_Positive()
	{
		return 0f;
	}

	public virtual float PitchRate_Negative()
	{
		return 0f;
	}

	public virtual float DiveRate_Nominal()
	{
		if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
		{
			if (_ClimbRate * 5f < 16.256f)
			{
				return _ClimbRate * 5f;
			}
			if (((Aircraft)myUnit).IsTiltrotor)
			{
				return _ClimbRate * 3f;
			}
			return 16.256f;
		}
		return _ClimbRate * 3f;
	}

	public virtual float DiveRate_Max()
	{
		if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
		{
			return _ClimbRate * 5f;
		}
		return _ClimbRate * 3f;
	}

	public virtual float DiveRate_Actual(float float_0)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (float_0 < 0f)
			{
				return (float)Math.Min(DiveRate_Nominal(), (double)myUnit.CurrentSpeed * 0.514444 * Math2.FillClass(Math.Abs(float_0)));
			}
			return 0f;
		}
		return DiveRate_Nominal();
	}

	public virtual float MaxRange(bool bool_0, float? nullable_0, float? nullable_1)
	{
		return float.MaxValue;
	}

	public virtual float MaxRadius()
	{
		return float.MaxValue;
	}

	public virtual float TacticalRadius()
	{
		return float.MaxValue;
	}

	public virtual double MaxEndurance(ActiveUnit.Throttle throttle_0, float? nullable_0, float? nullable_1, bool bool_0, float float_0)
	{
		return double.MaxValue;
	}

	internal bool InitDic()
	{
		return myUnit.Propulsion.Count > 0;
	}

	public ActiveUnit_Kinematics(ref ActiveUnit activeUnit_0)
	{
		_ReserveFuel = 0f;
		_JokerFuel = 0f;
		_ThrottlePreset = UnitThrottlePreset.None;
		BallisticTrajectory = null;
		m_DescriptorWrapper = new ThreadLocal<List<AltBand>>();
		_TestsWrapper = new List<AltBand>();
		myUnit = activeUnit_0;
	}

	public void ResetMaxSpeed()
	{
		_MaxSpeedTotal = null;
	}

	internal bool CheckDic()
	{
		return GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false) == 0;
	}

	public virtual void Loiter(float float_0, bool bool_0 = false, bool bool_1 = false)
	{
		myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(myUnit.CurrentHeading + 3f * float_0));
		myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
	}

	public virtual void TurnToDesiredHeading(float float_0)
	{
		if (myUnit.IsPalletWeapon)
		{
			return;
		}
		float currentHeading = myUnit.CurrentHeading;
		float desiredHeading = myUnit.DesiredHeading;
		try
		{
			float num = myUnit.Kinematics.TurnRate() * float_0;
			if (num > 179f)
			{
				num = 179f;
			}
			float num2 = 0f;
			switch (Misc.CountValue(currentHeading, desiredHeading))
			{
			case Misc.TurnDirection.TurnRight:
				num2 = Math2.UpdateClass(currentHeading + num);
				if (IsRightOfDesired(num2, desiredHeading))
				{
					num2 = desiredHeading;
				}
				break;
			case Misc.TurnDirection.TurnLeft:
				num2 = Math2.UpdateClass(currentHeading - num);
				if (IsLeftOfDesired(num2, desiredHeading))
				{
					num2 = desiredHeading;
				}
				break;
			}
			if (myUnit.IsBoat)
			{
				float num3 = adjustBoatHeadingChangeBasedOnRudderCurrentDeflection(num2, currentHeading, float_0, desiredHeading);
				num2 = Math2.UpdateClass(currentHeading + num3);
			}
			myUnit.CurrentHeading = num2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100172", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected float adjustBoatHeadingChangeBasedOnRudderCurrentDeflection(float float_0, float float_1, float float_2, float float_3)
	{
		float num = Math2.UpdateClass(float_0 - float_1);
		if (num > 180f)
		{
			num -= 360f;
		}
		float num2 = Math2.UpdateClass(float_3 - float_1);
		if (num2 > 180f)
		{
			num2 -= 360f;
		}
		Rudder rudder;
		float num3;
		if (myUnit.IsShip)
		{
			rudder = ((Ship)myUnit).Rudder;
			num3 = ((Ship)myUnit).Kinematics.StartOrder();
		}
		else
		{
			rudder = ((Submarine)myUnit).Rudder;
			num3 = ((Submarine)myUnit).Kinematics.MapSpecification();
		}
		float num4 = Math.Abs(rudder.lastHeadingChangePerSecond) / num3;
		float num5 = num3 * (num4 * (num4 + 1f)) / 2f;
		if (Math.Abs(num2) - num5 < 0f - num3)
		{
			return rudder.IncludeWriter(num3, 0f, float_2);
		}
		return rudder.IncludeWriter(num3, num, float_2);
	}

	protected bool IsLeftOfDesired(float float_0, float float_1)
	{
		float num = float_1;
		float num2 = Math2.UpdateClass(float_0 - num);
		num = 0f;
		if (num2 <= 180f)
		{
			return false;
		}
		return true;
	}

	protected bool IsRightOfDesired(float float_0, float float_1)
	{
		float num = float_1;
		float num2 = Math2.UpdateClass(float_0 - num);
		num = 0f;
		if (num2 <= 180f)
		{
			return true;
		}
		return false;
	}

	private void ConcatDic()
	{
	}

	public virtual float CurrentRangeAtBingoThrottleAltitudeDepth(Doctrine._FuelState? nullable_0)
	{
		float result = 0f;
		try
		{
			float num = 0f;
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			AltBand optimumAltBandForThisThrottle = myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(ActiveUnit.Throttle.Cruise);
			result = (float)((double)(num / myUnit.FuelConsumption(ActiveUnit.Throttle.Cruise, optimumAltBandForThisThrottle, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false)) * ((double)GetMaximumSpeed(optimumAltBandForThisThrottle.MaxAlt, ActiveUnit.Throttle.Cruise, bool_0: false) / 3600.0));
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100175", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal float InterruptDic(float float_0, ActiveUnit.Throttle throttle_0, float float_1, float? nullable_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (float_0 == 0f)
			{
				return 0f;
			}
			float? num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
			{
				return 0f;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				return 0f;
			}
			float num2 = myUnit.FuelConsumption(throttle_0, null, nullable_0, float_1, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
			return (float)(long)Math.Round((float_0 / nullable_0 * 3600f).Value) * num2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100176", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	internal float RemoveDic(float float_0, float float_1, float float_2, float float_3, UnitThrottlePreset unitThrottlePreset_0, float? nullable_0, bool bool_0, bool bool_1, bool bool_2, ref float float_4, ref float float_5)
	{
		try
		{
			if (myUnit.Propulsion.Count == 0)
			{
				return 0f;
			}
			AltBand altBand = null;
			AltBand altBand2 = null;
			float num;
			float num12;
			float num23;
			if (float_1 <= float_0)
			{
				altBand = GetCurrentAltBand_CurrentAltitude(float_1, null, bool_0: false);
				altBand2 = GetCurrentAltBand_CurrentAltitude(float_0, null, bool_0: false);
				num = float_3;
				num12 = float_1;
				num23 = float_0;
			}
			else
			{
				altBand = GetCurrentAltBand_CurrentAltitude(float_0, null, bool_0: false);
				altBand2 = GetCurrentAltBand_CurrentAltitude(float_1, null, bool_0: false);
				num = float_2;
				num12 = float_0;
				num23 = float_1;
			}
			float num27 = 0f;
			if (altBand == altBand2)
			{
				float num28 = num23 - num12;
				ActiveUnit.Throttle throttle;
				ActiveUnit.Throttle throttle_;
				if (unitThrottlePreset_0 == UnitThrottlePreset.None && !Information.IsNothing(nullable_0))
				{
					throttle = GetThrottleSuitableForThisSpeed(num12, nullable_0.Value);
					throttle_ = GetThrottleSuitableForThisSpeed(num23, nullable_0.Value);
				}
				else
				{
					throttle = (ActiveUnit.Throttle)unitThrottlePreset_0;
					throttle_ = throttle;
				}
				if (altBand == myUnit.Kinematics.HighestAltBand(myUnit.Propulsion[0]))
				{
					float num29 = myUnit.FuelConsumption(throttle, null, nullable_0, num12, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
					float_5 = num28 / num;
					num27 = float_5 * num29;
					float num30 = (Information.IsNothing(throttle) ? nullable_0.Value : ((float)myUnit.Kinematics.GetMaximumSpeed(num12, throttle, bool_0: false)));
					float_4 = float_5 * num30 * 3600f;
				}
				else
				{
					float num31 = myUnit.FuelConsumption(throttle, null, nullable_0, num12, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
					float num32 = myUnit.FuelConsumption(throttle_, null, nullable_0, num23, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
					float num2 = (num31 + num32) / 2f;
					float_5 = num28 / num;
					num27 = float_5 * num2;
					float num3 = myUnit.Kinematics.GetMaximumSpeed(num12, throttle, bool_0: false);
					float num4 = myUnit.Kinematics.GetMaximumSpeed(num23, throttle_, bool_0: false);
					float num5 = (num3 + num4) / 2f;
					float_4 = float_5 * num5 / 3600f;
				}
			}
			else
			{
				bool flag = false;
				ActiveUnit.Throttle throttle2 = ActiveUnit.Throttle.FullStop;
				ActiveUnit.Throttle throttle3 = ActiveUnit.Throttle.FullStop;
				if (unitThrottlePreset_0 != UnitThrottlePreset.None || Information.IsNothing(nullable_0))
				{
					throttle2 = (ActiveUnit.Throttle)unitThrottlePreset_0;
					throttle3 = throttle2;
				}
				AltBand[] altBands = myUnit.Propulsion[0].AltBands;
				float num6 = 0f;
				float num7 = 0f;
				AltBand[] array = altBands;
				AltBand[] array2 = array;
				foreach (AltBand altBand3 in array2)
				{
					if (altBand3 == altBand)
					{
						flag = true;
						float num8 = altBand3.MaxAlt - num12;
						if (num8 != 0f)
						{
							if (unitThrottlePreset_0 == UnitThrottlePreset.None && !Information.IsNothing(nullable_0))
							{
								throttle2 = GetThrottleSuitableForThisSpeed(num12, nullable_0.Value);
								throttle3 = GetThrottleSuitableForThisSpeed(altBand3.MaxAlt, nullable_0.Value);
							}
							float num9 = myUnit.FuelConsumption(throttle2, null, nullable_0, num12, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
							num6 = myUnit.FuelConsumption(throttle3, null, nullable_0, altBand3.MaxAlt, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
							float num10 = (num9 + num6) / 2f;
							float_5 = num8 / num;
							num27 = float_5 * num10;
							float num11 = myUnit.Kinematics.GetMaximumSpeed(num12, throttle2, bool_0: false);
							num7 = myUnit.Kinematics.GetMaximumSpeed(altBand3.MaxAlt, throttle3, bool_0: false);
							float num13 = (num11 + num7) / 2f;
							float_4 = float_5 * num13 / 3600f;
						}
					}
					else if (altBand3 == altBand2)
					{
						float num14 = num23 - altBand3.MinAlt;
						if (num14 != 0f)
						{
							if (unitThrottlePreset_0 == UnitThrottlePreset.None && !Information.IsNothing(nullable_0))
							{
								throttle2 = throttle3;
								throttle3 = GetThrottleSuitableForThisSpeed(num23, nullable_0.Value);
							}
							float num15 = num6;
							num6 = myUnit.FuelConsumption(throttle2, null, nullable_0, num23, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
							float num16 = (num15 + num6) / 2f;
							float num17 = num14 / num;
							float_5 += num17;
							num27 += num17 * num16;
							float num18 = num7;
							num7 = myUnit.Kinematics.GetMaximumSpeed(num23, throttle2, bool_0: false);
							float num19 = (num18 + num7) / 2f;
							float_4 += num17 * num19 / 3600f;
							break;
						}
					}
					else
					{
						if (!flag)
						{
							continue;
						}
						float num20 = altBand3.MaxAlt - altBand3.MinAlt;
						if (num20 != 0f)
						{
							if (unitThrottlePreset_0 == UnitThrottlePreset.None && !Information.IsNothing(nullable_0))
							{
								throttle2 = throttle3;
								throttle3 = GetThrottleSuitableForThisSpeed(altBand3.MaxAlt, nullable_0.Value);
							}
							float num21 = num6;
							num6 = myUnit.FuelConsumption(throttle2, null, nullable_0, altBand3.MaxAlt, bool_0: false, bool_1: false, bool_0, bool_1, bool_2);
							float num22 = (num21 + num6) / 2f;
							float num24 = num20 / num;
							float_5 += num24;
							num27 += num24 * num22;
							float num25 = num7;
							num7 = myUnit.Kinematics.GetMaximumSpeed(altBand3.MaxAlt, throttle2, bool_0: false);
							float num26 = (num25 + num7) / 2f;
							float_4 += num24 * num26 / 3600f;
						}
					}
				}
			}
			return num27;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100176", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float_4 = 0f;
			float_5 = 0f;
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	internal float FindDic(int int_0, ActiveUnit.Throttle throttle_0, float float_0, float? nullable_0, bool bool_0)
	{
		try
		{
			if (int_0 == 0)
			{
				return 0f;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				return 0f;
			}
			float num = myUnit.FuelConsumption(throttle_0, null, nullable_0, float_0, bool_0: false, bool_1: false, bool_0, bool_3: false, bool_4: false);
			return (float)int_0 * num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101248", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public int CavitationSpeed(float float_0)
	{
		if (float_0 < -500f)
		{
			return int.MaxValue;
		}
		float num = 0f;
		switch (myUnit.NoiseLevelClass)
		{
		case GlobalVariables.UnitNoiseLevelClass.Loud:
			if (float_0 <= -200f)
			{
				if (float_0 <= -300f)
				{
					if (float_0 <= -400f)
					{
						return int.MaxValue;
					}
					num = 25f;
				}
				else
				{
					num = 13f;
				}
			}
			else
			{
				num = 8f;
			}
			break;
		case GlobalVariables.UnitNoiseLevelClass.Noisy:
			if (float_0 <= -100f)
			{
				if (float_0 <= -200f)
				{
					if (float_0 <= -300f)
					{
						return int.MaxValue;
					}
					num = 25f;
				}
				else
				{
					num = 13f;
				}
			}
			else
			{
				num = 8f;
			}
			break;
		case GlobalVariables.UnitNoiseLevelClass.Quiet:
			if (float_0 <= -50f)
			{
				if (float_0 <= -100f)
				{
					if (float_0 <= -200f)
					{
						return int.MaxValue;
					}
					num = 25f;
				}
				else
				{
					num = 13f;
				}
			}
			else
			{
				num = 8f;
			}
			break;
		case GlobalVariables.UnitNoiseLevelClass.VQuiet:
			if (float_0 <= -50f)
			{
				if (float_0 <= -100f)
				{
					return int.MaxValue;
				}
				num = 25f;
			}
			else
			{
				num = 13f;
			}
			break;
		case GlobalVariables.UnitNoiseLevelClass.ExQuiet:
			if (float_0 > -50f)
			{
				num = 25f;
				break;
			}
			return int.MaxValue;
		}
		if (myUnit.IsSubmarine && ((Submarine)myUnit).Flags.ShroudedPropulsor)
		{
			num = (float)((double)num * 1.1);
		}
		return (int)Math.Round(num);
	}

	public void ResetCachedMaxMinAlt()
	{
		m_WatcherWrapper = null;
	}

	public virtual float GetMaximumAltitude()
	{
		try
		{
			if (m_WatcherWrapper.HasValue)
			{
				return m_WatcherWrapper.Value;
			}
			float num = 0f;
			foreach (Engine item in myUnit.Propulsion)
			{
				AltBand[] altBands = item.AltBands;
				int num2 = altBands.Length - 1;
				for (int i = 0; i <= num2; i++)
				{
					AltBand altBand = altBands[i];
					if (altBand.MaxAlt > num)
					{
						num = altBand.MaxAlt;
					}
				}
			}
			m_WatcherWrapper = num;
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100177", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public virtual float GetMinimumAltitude()
	{
		try
		{
			if (_ReponseWrapper.HasValue)
			{
				return _ReponseWrapper.Value;
			}
			float num = 9999999f;
			foreach (Engine item in myUnit.Propulsion)
			{
				if (item.AltBands.Length != 0)
				{
					AltBand[] altBands = item.AltBands;
					int num2 = altBands.Length - 1;
					for (int i = 0; i <= num2; i++)
					{
						AltBand altBand = altBands[i];
						if (altBand.MinAlt <= num)
						{
							num = altBand.MinAlt;
						}
					}
					continue;
				}
				return 0f;
			}
			_ReponseWrapper = num;
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100178", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public virtual float GetMinimumSpeed_Total(float float_0, bool bool_0)
	{
		float result = 0f;
		try
		{
			if (!myUnit.IsFacility && !myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsMobileGroundUnit)
			{
				if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
				{
					result = 0f;
					return result;
				}
				if (myUnit.Propulsion.Count == 0)
				{
					result = 0f;
					return result;
				}
				if (myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					result = 0f;
					return result;
				}
				if (myUnit.Propulsion[0].AltBands.Length == 0)
				{
					result = 0f;
					return result;
				}
				AltBand altBand = GetCurrentAltBand(float_0, bool_0);
				if (Information.IsNothing(altBand))
				{
					if (myUnit.IsAircraft)
					{
						altBand = myUnit.Propulsion[0].AltBands.OrderByDescending((AltBand theb) => theb.MaxAlt).ElementAtOrDefault(0);
						if (bool_0)
						{
							myUnit.SetCurrentAltitude(bool_0: false, altBand.MaxAlt);
						}
					}
					else
					{
						altBand = myUnit.Propulsion[0].AltBands.OrderBy((AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
						if (bool_0)
						{
							myUnit.SetCurrentAltitude(bool_0: true, altBand.MinAlt);
						}
					}
				}
				result = altBand.Speed_Loiter;
				return result;
			}
			result = 0f;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100179", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual int GetMinimumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0)
	{
		try
		{
			AltBand altBand = null;
			AltBand altBand2 = null;
			if (!myUnit.IsFacility && !myUnit.IsShip && !myUnit.IsSubmarine)
			{
				if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
				{
					return 0;
				}
				if (throttle_0 == ActiveUnit.Throttle.FullStop)
				{
					return 0;
				}
				ActiveUnit.Throttle throttle = throttle_0 - 1;
				if (myUnit.IsAircraft && throttle == ActiveUnit.Throttle.FullStop)
				{
					throttle = ActiveUnit.Throttle.Loiter;
				}
				if (myUnit.Propulsion.Count == 0)
				{
					return 0;
				}
				if (myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					return 0;
				}
				if (myUnit.Propulsion[0].AltBands.Length == 0)
				{
					return 0;
				}
				AltBand[] altBands = myUnit.Propulsion[0].AltBands;
				if (altBands.Length == 0)
				{
					return 0;
				}
				altBand = GetCurrentAltBand(float_0, bool_0);
				if (Information.IsNothing(altBand))
				{
					return 0;
				}
				float num = 0f;
				switch (throttle)
				{
				case ActiveUnit.Throttle.FullStop:
					num = 0f;
					break;
				case ActiveUnit.Throttle.Loiter:
					num = altBand.Speed_Loiter;
					break;
				case ActiveUnit.Throttle.Cruise:
					num = ((altBand.Speed_Cruise <= 0) ? ((float)altBand.Speed_Loiter) : ((float)altBand.Speed_Cruise));
					break;
				case ActiveUnit.Throttle.Full:
					num = (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise));
					break;
				case ActiveUnit.Throttle.Flank:
					num = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise)));
					break;
				}
				int num2 = (int)Math.Round(num);
				if (!myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsFacility && altBand != HighestAltBand(myUnit.Propulsion[0]))
				{
					List<AltBand> list = new List<AltBand>();
					AltBand[] array = altBands;
					AltBand[] array2 = array;
					foreach (AltBand altBand3 in array2)
					{
						if (altBand3.MinAlt >= altBand.MaxAlt)
						{
							list.Add(altBand3);
						}
					}
					if (list.Count > 1)
					{
						list.Sort(new AltBandComparer_SortyByMaxAltAscending());
					}
					if (list.Count > 0)
					{
						altBand2 = list[0];
					}
					float num3 = 0f;
					switch (throttle)
					{
					case ActiveUnit.Throttle.FullStop:
						num3 = 0f;
						break;
					case ActiveUnit.Throttle.Loiter:
						num3 = altBand2.Speed_Loiter;
						break;
					case ActiveUnit.Throttle.Cruise:
						num3 = altBand2.Speed_Cruise;
						break;
					case ActiveUnit.Throttle.Full:
						num3 = (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise));
						break;
					case ActiveUnit.Throttle.Flank:
						num3 = (altBand2.Speed_Flank.HasValue ? ((float)altBand2.Speed_Flank.Value) : (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise)));
						break;
					}
					num2 = (int)Math.Round(num3 + (float_0 - altBand2.MinAlt) * (num - num3) / (altBand.MinAlt - altBand2.MinAlt));
				}
				if (myUnit.IsAircraft)
				{
					return (int)Math.Round(RoundAircraftSpeed(num2));
				}
				return num2 + 1;
			}
			return 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100180", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public bool CanApplyLoiterThrottle()
	{
		AltBand currentAltBand = GetCurrentAltBand(myUnit.GetCurrentAltitude(), bool_0: true);
		if (Information.IsNothing(currentAltBand))
		{
			return false;
		}
		if (currentAltBand.Consumption_Loiter < 0f && currentAltBand.Speed_Loiter < 0)
		{
			return true;
		}
		return false;
	}

	public bool CanApplyFullThrottle()
	{
		bool result = false;
		try
		{
			AltBand currentAltBand = GetCurrentAltBand(myUnit.GetCurrentAltitude(), bool_0: false);
			if (Information.IsNothing(currentAltBand))
			{
				result = false;
				return false;
			}
			if (currentAltBand.Consumption_Full.HasValue && currentAltBand.Speed_Full.HasValue)
			{
				result = true;
				return true;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100181", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual bool CanApplyFlankThrottle()
	{
		bool result = false;
		try
		{
			AltBand currentAltBand = GetCurrentAltBand(myUnit.GetCurrentAltitude(), bool_0: false);
			if (Information.IsNothing(currentAltBand))
			{
				result = false;
				return false;
			}
			if (currentAltBand.Consumption_Flank.HasValue && currentAltBand.Speed_Flank.HasValue)
			{
				result = true;
				return true;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100182", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public AltBand LowestAltBand()
	{
		AltBand result = null;
		try
		{
			if (myUnit.Propulsion.Count == 0)
			{
				result = null;
				return result;
			}
			if (myUnit.Propulsion[0].AltBands.Length == 0)
			{
				result = null;
				return result;
			}
			if (Information.IsNothing(m_RequestWrapper))
			{
				m_RequestWrapper = myUnit.Propulsion[0].AltBands.OrderBy((AltBand theBand) => theBand.MinAlt).ElementAtOrDefault(0);
			}
			result = m_RequestWrapper;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100183", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual long RemainingEndurance(bool bool_0 = false)
	{
		long result = 0L;
		try
		{
			float num = 0f;
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			if (!bool_0)
			{
				num -= myUnit.Kinematics.ReserveFuel;
			}
			float num2 = myUnit.FuelConsumption(myUnit.ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			if (num2 == 0f)
			{
				result = long.MaxValue;
				return long.MaxValue;
			}
			result = (long)Math.Round(num / num2);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100184", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual long RemainingEndurance(float float_0, float float_1, bool bool_0, bool bool_1)
	{
		try
		{
			if (float_0 == 0f)
			{
				return long.MaxValue;
			}
			float num = 0f;
			if (bool_1 && myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).AirOps.GetAssignedHostUnit()))
			{
				num = ((Aircraft)myUnit).FuelState_RemainingFuelToBingo;
			}
			else
			{
				foreach (FuelRec item in myUnit.Fuel_ReadOnly.ToList())
				{
					num += item.CurrentQuantity;
				}
				if (!bool_0)
				{
					num -= myUnit.Kinematics.ReserveFuel;
				}
			}
			if (float.IsNaN(num))
			{
				return 0L;
			}
			float num2 = myUnit.FuelConsumption(GetThrottleSuitableForThisSpeed(float_1, (int)Math.Round(float_0)), null, (int)Math.Round(float_0), float_1, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			if (num2 == 0f)
			{
				return long.MaxValue;
			}
			return (long)Math.Round(num / num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100185", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0L;
		}
	}

	public virtual long RemainingEndurance(ActiveUnit.Throttle throttle_0, float float_0, bool bool_0)
	{
		long result = 0L;
		try
		{
			float num = 0f;
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			if (!bool_0)
			{
				num -= myUnit.Kinematics.ReserveFuel;
			}
			result = (long)Math.Round(num / myUnit.FuelConsumption(throttle_0, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100833", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual int GetMaximumSpeed()
	{
		try
		{
			if (!_MaxSpeedTotal.HasValue)
			{
				if (myUnit.Propulsion.Count == 0)
				{
					return 0;
				}
				HashSet<int> hashSet = new HashSet<int>();
				foreach (Engine item in myUnit.Propulsion)
				{
					AltBand[] altBands = item.AltBands;
					AltBand[] array = altBands;
					foreach (AltBand altBand in array)
					{
						hashSet.Add(altBand.MaxSpeed.Value);
					}
				}
				if (hashSet.Count == 0)
				{
					_MaxSpeedTotal = 0;
				}
				else
				{
					_MaxSpeedTotal = hashSet.Max();
				}
			}
			return _MaxSpeedTotal.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100186", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public virtual int GetMaximumSpeed_Total()
	{
		try
		{
			if (!_MaxSpeedTotal.HasValue)
			{
				if (myUnit.Propulsion.Count == 0)
				{
					return 0;
				}
				HashSet<int> hashSet = new HashSet<int>();
				foreach (Engine item in myUnit.Propulsion)
				{
					AltBand[] altBands = item.AltBands;
					AltBand[] array = altBands;
					foreach (AltBand altBand in array)
					{
						hashSet.Add(altBand.MaxSpeed.Value);
					}
				}
				if (hashSet.Count == 0)
				{
					_MaxSpeedTotal = 0;
				}
				else
				{
					_MaxSpeedTotal = hashSet.Max();
				}
			}
			return _MaxSpeedTotal.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100186", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public int GetMaximumSpeed(float float_0)
	{
		if (myUnit.IsGroup)
		{
			if (((Group)myUnit).GroupLead == null)
			{
				return 0;
			}
			return ((Group)myUnit).GroupLead.Kinematics.GetMaximumSpeed(float_0);
		}
		if (myUnit.IsFacility)
		{
			return ((Facility)myUnit).Kinematics.GetMaximumSpeedAtThisLocation(myUnit.GetLatitude(), myUnit.GetLongitude());
		}
		if (myUnit.IsVehicle)
		{
			return GetMaximumSpeed_Total();
		}
		AltBand altBand = null;
		ObservableList<Engine> propulsion = myUnit.Propulsion;
		try
		{
			if (propulsion.Count == 0)
			{
				return 0;
			}
			AltBand[] altBands = propulsion[0].AltBands;
			if (propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				return 0;
			}
			if (altBands.Length == 0)
			{
				return 0;
			}
			AltBand altBand2 = (myUnit.IsWeapon ? GetCurrentAltBand_CurrentAltitude(float_0, propulsion[0], bool_0: false) : GetCurrentAltBand_CurrentAltitude(float_0, null, bool_0: false));
			if (altBand2 == null)
			{
				return 0;
			}
			int value = altBand2.MaxSpeed.Value;
			int num = value;
			if (!myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsFacility && altBand2 != HighestAltBand(propulsion[0]))
			{
				if (m_DescriptorWrapper.IsValueCreated)
				{
					m_DescriptorWrapper.Value.Clear();
				}
				else
				{
					m_DescriptorWrapper.Value = new List<AltBand>();
				}
				AltBand[] array = altBands;
				AltBand[] array2 = array;
				foreach (AltBand altBand3 in array2)
				{
					if (altBand3.MinAlt >= altBand2.MaxAlt && altBand3 != null)
					{
						m_DescriptorWrapper.Value.Add(altBand3);
					}
				}
				int count = m_DescriptorWrapper.Value.Count;
				if (count <= 1)
				{
					if (count <= 0)
					{
						_ = Debugger.IsAttached;
						altBand = HighestAltBand(propulsion[0]);
					}
					else
					{
						altBand = m_DescriptorWrapper.Value[0];
					}
				}
				else
				{
					try
					{
						m_DescriptorWrapper.Value.Sort(new AltBandComparer_SortyByMaxAltAscending());
						altBand = m_DescriptorWrapper.Value[0];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						altBand = m_DescriptorWrapper.Value.OrderBy((AltBand theAB) => theAB.MaxAlt).ElementAtOrDefault(0);
						ProjectData.ClearProjectError();
					}
				}
				float num2 = 0f;
				if (altBand == null)
				{
					if (m_DescriptorWrapper.Value.Count > 0)
					{
						altBand = m_DescriptorWrapper.Value[0];
						num2 = altBand.MaxSpeed.Value;
					}
				}
				else
				{
					num2 = altBand.MaxSpeed.Value;
				}
				num = (int)Math.Round(num2 + (float_0 - altBand.MinAlt) * ((float)value - num2) / (altBand2.MinAlt - altBand.MinAlt));
			}
			if (myUnit.IsAircraft)
			{
				num = (int)Math.Round(RoundAircraftSpeed(num));
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100187", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public AltBand GetCurrentAltBand_CurrentAltitude(float float_0, Engine engine_0, bool bool_0)
	{
		if (myUnit.IsVehicle)
		{
			return ((Vehicle)myUnit).Kinematics.GetCurrentAltBand_CurrentAltitude_Vehicle(engine_0);
		}
		AltBand altBand = null;
		if (_MyPropulsion == null)
		{
			_MyPropulsion = myUnit.Propulsion;
		}
		try
		{
			if (myUnit.IsTorpedo)
			{
				return _MyPropulsion[0].AltBands[0];
			}
			if (myUnit.IsShip)
			{
				if (_MyPropulsion[0].AltBands.Length == 0)
				{
					return null;
				}
				return _MyPropulsion[0].AltBands[0];
			}
			if (myUnit.IsSubmarine && engine_0 == null && _MyPropulsion.Count > 1 && float_0 == myUnit.GetCurrentAltitude())
			{
				Submarine submarine = (Submarine)myUnit;
				if (submarine.PrimaryEngine == null)
				{
					submarine.AI.SelectEngines();
				}
				if (submarine.PrimaryEngine != null)
				{
					engine_0 = submarine.PrimaryEngine;
				}
			}
			AltBand[] array = null;
			if (engine_0 == null)
			{
				foreach (Engine item in _MyPropulsion)
				{
					array = item.AltBands;
					int num = array.Length;
					for (int i = num - 1; i >= 0; i += -1)
					{
						AltBand altBand2 = array[i];
						if (num >= 2 && ((i >= 1 && array[i].MinAlt - array[i - 1].MaxAlt != 0f) || (i == 0 && array[i].MaxAlt - array[i + 1].MinAlt != 0f)))
						{
							if (altBand2.MaxAlt >= float_0 && float_0 + 1f >= altBand2.MinAlt)
							{
								altBand = altBand2;
								break;
							}
						}
						else if (altBand2.MaxAlt >= float_0 && !(float_0 < altBand2.MinAlt))
						{
							altBand = altBand2;
							break;
						}
					}
					if (altBand != null)
					{
						break;
					}
				}
			}
			else
			{
				array = engine_0.AltBands;
				int num2 = array.Length;
				for (int j = num2 - 1; j >= 0; j += -1)
				{
					AltBand altBand3 = array[j];
					if (num2 >= 2 && ((j >= 1 && array[j].MinAlt - array[j - 1].MaxAlt != 0f) || (j == 0 && array[j].MaxAlt - array[j + 1].MinAlt != 0f)))
					{
						if (altBand3.MaxAlt >= float_0 && float_0 + 1f >= altBand3.MinAlt)
						{
							altBand = altBand3;
							break;
						}
					}
					else if (altBand3.MaxAlt >= float_0 && !(float_0 < altBand3.MinAlt))
					{
						altBand = altBand3;
						break;
					}
				}
			}
			if (altBand == null)
			{
				if (!taskWrapper)
				{
					m_PoolWrapper = myUnit.IsGuidedWeapon();
					taskWrapper = true;
				}
				if (!myUnit.IsAircraft && !m_PoolWrapper)
				{
					if (array == null || array.Length == 0)
					{
						return null;
					}
					altBand = array.OrderBy((AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
					if (bool_0)
					{
						myUnit.SetCurrentAltitude(bool_0: true, altBand.MinAlt);
					}
				}
				else
				{
					float num3 = float.MaxValue;
					AltBand[] array2 = array;
					AltBand[] array3 = array2;
					foreach (AltBand altBand4 in array3)
					{
						if (float_0 - altBand4.MaxAlt < num3)
						{
							altBand = altBand4;
							num3 = float_0 - altBand4.MaxAlt;
						}
					}
					if (bool_0)
					{
						myUnit.SetCurrentAltitude(bool_0: false, altBand.MaxAlt);
					}
				}
			}
			return altBand;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100188", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public virtual int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0, bool bool_1 = true)
	{
		if (float.IsNaN(float_0))
		{
			return 0;
		}
		AltBand altBand = null;
		Engine engine = null;
		int result = 0;
		try
		{
			if (throttle_0 == ActiveUnit.Throttle.FullStop)
			{
				result = 0;
				return 0;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				if (myUnit.IsFixedFacility)
				{
					result = 0;
					return 0;
				}
				switch (throttle_0)
				{
				case ActiveUnit.Throttle.Loiter:
					result = 3;
					return 3;
				case ActiveUnit.Throttle.Cruise:
					result = 10;
					return 10;
				case ActiveUnit.Throttle.Full:
					result = 20;
					return 20;
				case ActiveUnit.Throttle.Flank:
					result = 30;
					return 30;
				case ActiveUnit.Throttle.External:
					result = (DesiredSpeedOverride.HasValue ? ((int)Math.Round(DesiredSpeedOverride.Value)) : 0);
					return result;
				}
			}
			altBand = GetCurrentAltBand_CurrentAltitude(float_0, null, bool_0);
			if (altBand == null)
			{
				result = 0;
				return 0;
			}
			engine = (myUnit.IsSubmarine ? FillDic(altBand) : myUnit.Propulsion[0]);
			AltBand[] altBands = engine.AltBands;
			if (bool_1 && engine.Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				result = 0;
				return 0;
			}
			if (altBands.Length == 0)
			{
				result = 0;
				return 0;
			}
			float num = 0f;
			switch (throttle_0)
			{
			case ActiveUnit.Throttle.FullStop:
				num = 0f;
				break;
			case ActiveUnit.Throttle.Loiter:
				num = altBand.Speed_Loiter;
				break;
			case ActiveUnit.Throttle.Cruise:
				num = ((altBand.Speed_Cruise <= 0) ? ((float)altBand.Speed_Loiter) : ((float)altBand.Speed_Cruise));
				break;
			case ActiveUnit.Throttle.Full:
				num = (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise));
				break;
			case ActiveUnit.Throttle.Flank:
				num = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise)));
				break;
			}
			int num2 = (int)Math.Round(num);
			if (bool_1)
			{
				float val = Math.Max((float)num2 * (100f - myUnit.Damage.DamagePercent) / 100f, 0f);
				float val2 = 0f;
				switch (engine.Status)
				{
				case PlatformComponent._ComponentStatus.Operational:
					val2 = num2;
					break;
				case PlatformComponent._ComponentStatus.Damaged:
					val2 = (float)((double)num2 / 2.0);
					break;
				case PlatformComponent._ComponentStatus.Destroyed:
					val2 = 0f;
					break;
				}
				num2 = (int)Math.Round(Math.Min(val, val2));
				if (SetDic() && Module_Unit.ResetTokenizer(myUnit))
				{
					float num3 = Terrain.InvokeWatcher(myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: false, myUnit.ParentScen);
					num2 = (((double)num3 <= 0.5) ? ((int)Math.Round(Math.Max((double)num2 / 10.0, (float)num2 * (1f - num3)))) : ((int)Math.Round(Math.Max(1.0, (double)num2 / 10.0))));
					if ((int)(LandCover.DestroyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.ParentScen) - 1) <= 4)
					{
						num2 = (int)Math.Round((float)num2 * 0.01f);
						num2 = Math.Max(num2, 1);
					}
				}
			}
			result = num2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100189", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal bool SetDic()
	{
		if (myUnit.IsShip)
		{
			return ((Ship)myUnit).Type == Ship._ShipType.LCAC;
		}
		return false;
	}

	public static float RoundAircraftSpeed(float float_0)
	{
		if (float_0 <= 415f)
		{
			return (float)(Math.Round(float_0 / 5f) * 5.0);
		}
		return (float)(Math.Round(float_0 / 10f) * 10.0);
	}

	public AltBand HighestAltBand(Engine engine_0)
	{
		try
		{
			if (engine_0 == null)
			{
				return null;
			}
			if (engine_0.m_ConfigClient == null)
			{
				if (engine_0.AltBands.Length == 0)
				{
					return null;
				}
				if (myUnit.IsWeapon && engine_0 != myUnit.Propulsion[0])
				{
					AltBand altBand = null;
					float num = float.MinValue;
					AltBand[] altBands2 = engine_0.AltBands;
					AltBand[] array = altBands2;
					foreach (AltBand altBand2 in array)
					{
						if (altBand2.MinAlt > num)
						{
							altBand = altBand2;
							num = altBand2.MinAlt;
						}
					}
					engine_0.m_ConfigClient = altBand;
					return altBand;
				}
				if (_ValueWrapper == null || string.CompareOrdinal(tokenizerWrapper, engine_0.ObjectID) != 0)
				{
					AltBand valueWrapper = null;
					float num2 = float.MinValue;
					AltBand[] altBands = engine_0.AltBands;
					AltBand[] array2 = altBands;
					foreach (AltBand altBand3 in array2)
					{
						if (altBand3.MinAlt > num2)
						{
							valueWrapper = altBand3;
							num2 = altBand3.MinAlt;
						}
					}
					_ValueWrapper = valueWrapper;
					tokenizerWrapper = engine_0.ObjectID;
				}
				engine_0.m_ConfigClient = _ValueWrapper;
				return _ValueWrapper;
			}
			return engine_0.m_ConfigClient;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100190", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private Engine FillDic(AltBand altBand_0)
	{
		try
		{
			foreach (Engine item in myUnit.Propulsion)
			{
				if (item.AltBands.Contains(altBand_0))
				{
					return item;
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100191", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public void AdjustSpeedForCavitation()
	{
		try
		{
			int num = myUnit.Kinematics.CavitationSpeed(myUnit.GetCurrentAltitude());
			if (myUnit.DesiredSpeed >= (float)num)
			{
				if (num == 1)
				{
					myUnit.DesiredSpeed = 1f;
				}
				else
				{
					myUnit.DesiredSpeed = num - 1;
				}
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				myUnit.Kinematics.HasAdjustedSpeedForCavitation = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100192", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual ActiveUnit.Throttle GetThrottleSuitableForThisSpeed(float float_0, float float_1)
	{
		try
		{
			if (myUnit.Propulsion.Count == 0)
			{
				return ActiveUnit.Throttle.FullStop;
			}
			AltBand currentAltBand = GetCurrentAltBand(float_0, bool_0: false);
			if (currentAltBand == null)
			{
				return ActiveUnit.Throttle.FullStop;
			}
			AltBand[] altBands = myUnit.Propulsion[0].AltBands;
			AltBand altBand = null;
			int num = currentAltBand.Speed_Loiter;
			int num2 = currentAltBand.Speed_Cruise;
			int num3 = 0;
			if (currentAltBand.Consumption_Full.HasValue)
			{
				num3 = (int)currentAltBand.Speed_Full.Value;
			}
			if (currentAltBand.Consumption_Flank.HasValue)
			{
				_ = currentAltBand.Speed_Flank.Value;
			}
			if (!myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsFacility && currentAltBand != HighestAltBand(myUnit.Propulsion[0]))
			{
				List<AltBand> list = new List<AltBand>();
				AltBand[] array = altBands;
				AltBand[] array2 = array;
				foreach (AltBand altBand2 in array2)
				{
					if (altBand2.MinAlt >= currentAltBand.MaxAlt)
					{
						list.Add(altBand2);
					}
				}
				if (list.Count > 1)
				{
					list.Sort(new AltBandComparer_SortyByMaxAltAscending());
				}
				if (list.Count > 0)
				{
					altBand = list[0];
				}
				if (currentAltBand.Speed_Loiter != altBand.Speed_Loiter)
				{
					num = (int)Math.Round((float)altBand.Speed_Loiter + (float_0 - altBand.MinAlt) * (float)(currentAltBand.Speed_Loiter - altBand.Speed_Loiter) / (currentAltBand.MinAlt - altBand.MinAlt));
					if (myUnit.IsAircraft)
					{
						num = (int)Math.Round(RoundAircraftSpeed(num));
					}
				}
				if (currentAltBand.Speed_Cruise != altBand.Speed_Cruise)
				{
					num2 = (int)Math.Round((float)altBand.Speed_Cruise + (float_0 - altBand.MinAlt) * (float)(currentAltBand.Speed_Cruise - altBand.Speed_Cruise) / (currentAltBand.MinAlt - altBand.MinAlt));
					if (myUnit.IsAircraft)
					{
						num2 = (int)Math.Round(RoundAircraftSpeed(num2));
					}
				}
				if (currentAltBand.Consumption_Full.HasValue)
				{
					long? speed_Full = currentAltBand.Speed_Full;
					long? speed_Full2 = altBand.Speed_Full;
					if (((speed_Full.HasValue & speed_Full2.HasValue) ? new bool?(speed_Full.GetValueOrDefault() != speed_Full2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						num3 = (int)Math.Round(((float?)altBand.Speed_Full + (float_0 - altBand.MinAlt) * (float?)(currentAltBand.Speed_Full - altBand.Speed_Full) / (currentAltBand.MinAlt - altBand.MinAlt)).Value);
						if (myUnit.IsAircraft)
						{
							num3 = (int)Math.Round(RoundAircraftSpeed(num3));
						}
					}
				}
				if (currentAltBand.Consumption_Full.HasValue)
				{
					long? speed_Flank = currentAltBand.Speed_Flank;
					long? speed_Flank2 = altBand.Speed_Flank;
					if (((speed_Flank.HasValue & speed_Flank2.HasValue) ? new bool?(speed_Flank.GetValueOrDefault() != speed_Flank2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						int num4 = (int)Math.Round(((float?)altBand.Speed_Flank + (float_0 - altBand.MinAlt) * (float?)(currentAltBand.Speed_Flank - altBand.Speed_Flank) / (currentAltBand.MinAlt - altBand.MinAlt)).Value);
						if (myUnit.IsAircraft)
						{
							num4 = (int)Math.Round(RoundAircraftSpeed(num4));
						}
					}
				}
			}
			if (float_1 == 0f)
			{
				return ActiveUnit.Throttle.FullStop;
			}
			if (float_1 <= (float)num)
			{
				return ActiveUnit.Throttle.Loiter;
			}
			if (float_1 <= (float)num2)
			{
				return ActiveUnit.Throttle.Cruise;
			}
			if (float_1 <= (float)num3)
			{
				if (currentAltBand.Consumption_Full.HasValue)
				{
					return ActiveUnit.Throttle.Full;
				}
				return ActiveUnit.Throttle.Cruise;
			}
			if (currentAltBand.Consumption_Flank.HasValue)
			{
				return ActiveUnit.Throttle.Flank;
			}
			return ActiveUnit.Throttle.Full;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100193", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return ActiveUnit.Throttle.Cruise;
		}
	}

	public virtual AltBand GetCurrentAltBand(float float_0, bool bool_0)
	{
		try
		{
			AltBand altBand = null;
			if (myUnit.IsTorpedo)
			{
				return myUnit.Propulsion[0].AltBands[0];
			}
			if (myUnit.IsShip)
			{
				if (myUnit.Propulsion[0].AltBands.Length == 0)
				{
					return null;
				}
				return myUnit.Propulsion[0].AltBands[0];
			}
			AltBand[] altBands = myUnit.Propulsion[0].AltBands;
			int num = altBands.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				AltBand altBand2 = altBands[i];
				if (altBand2.MaxAlt >= float_0 && (float_0 + 1f > altBand2.MinAlt || float_0 + 1f == altBand2.MinAlt))
				{
					altBand = altBand2;
				}
			}
			if (Information.IsNothing(altBand))
			{
				if (myUnit.IsAircraft)
				{
					altBand = altBands.OrderByDescending((AltBand theb) => theb.MaxAlt).ElementAtOrDefault(0);
					if (bool_0)
					{
						myUnit.SetCurrentAltitude(bool_0: false, altBand.MaxAlt);
					}
				}
				else
				{
					altBand = altBands.OrderBy((AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
					if (bool_0)
					{
						myUnit.SetCurrentAltitude(bool_0: true, altBand.MinAlt);
					}
				}
			}
			return altBand;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100194", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public void AdjustAttitude_Pitch(float float_0)
	{
		float attitude_Pitch = myUnit.Attitude_Pitch;
		float desiredPitch = myUnit.DesiredPitch;
		float num = ((desiredPitch == attitude_Pitch) ? attitude_Pitch : ((desiredPitch <= attitude_Pitch) ? ((Math.Abs(attitude_Pitch - desiredPitch) <= PitchRate_Negative() * float_0) ? desiredPitch : (attitude_Pitch - PitchRate_Negative() * float_0)) : ((Math.Abs(desiredPitch - attitude_Pitch) <= PitchRate_Positive() * float_0) ? desiredPitch : (attitude_Pitch + PitchRate_Positive() * float_0))));
		if (num > 90f)
		{
			_ = Debugger.IsAttached;
			num %= 90f;
			myUnit.CurrentHeading = Math2.UpdateClass(myUnit.CurrentHeading + 180f);
			myUnit.Attitude_Roll = Math2.PrepareClass(myUnit.Attitude_Roll + 180f);
		}
		if (num < -90f)
		{
			_ = Debugger.IsAttached;
			num %= 90f;
			myUnit.CurrentHeading = Math2.UpdateClass(myUnit.CurrentHeading + 180f);
			myUnit.Attitude_Roll = Math2.PrepareClass(myUnit.Attitude_Roll + 180f);
		}
		myUnit.Attitude_Pitch = num;
	}

	public void AdjustAttitude_Roll(float float_0)
	{
		if (myUnit.DesiredRoll == myUnit.Attitude_Roll)
		{
			return;
		}
		if (myUnit.DesiredRoll <= myUnit.Attitude_Roll)
		{
			if (myUnit.Attitude_Roll - myUnit.DesiredRoll <= RollRate() * float_0)
			{
				myUnit.Attitude_Roll = myUnit.DesiredRoll;
			}
			else
			{
				myUnit.Attitude_Roll -= RollRate() * float_0;
			}
		}
		else if (myUnit.DesiredRoll - myUnit.Attitude_Roll <= RollRate() * float_0)
		{
			myUnit.Attitude_Roll = myUnit.DesiredRoll;
		}
		else
		{
			myUnit.Attitude_Roll += RollRate() * float_0;
		}
	}

	public virtual double GetDecelerationCapacity(float float_0, float float_1, float float_2)
	{
		double num = 1.5 * (double)Acceleration_Nominal(ActiveUnit.Throttle.Full, float_0) * (double)(float_1 / (float)myUnit.Kinematics.GetMaximumSpeed()) * (double)float_2;
		if (myUnit.IsAircraft && ((Aircraft)myUnit).GetCanHover(bool_1: true))
		{
			num = Math.Max(num, 10f * float_2);
		}
		else if (myUnit.IsMobileGroundUnit)
		{
			num *= 5.0;
		}
		return num;
	}

	public virtual void GoToDesiredSpeed(float float_0, float float_1)
	{
		try
		{
			if (myUnit.CurrentSpeed < 1f && myUnit.DesiredSpeed == 0f)
			{
				myUnit.CurrentSpeed = 0f;
			}
			if ((double)Math.Abs(myUnit.DesiredSpeed - myUnit.CurrentSpeed) < 0.5)
			{
				myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				return;
			}
			if (myUnit.DesiredSpeed == 0f && myUnit.CurrentSpeed > 0f && myUnit.IsGroupWingman() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead) && myUnit.GetParentGroup().GroupLead.CurrentSpeed == 0f && myUnit.GetParentGroup().GroupLead.DesiredSpeed == 0f)
			{
				myUnit.CurrentSpeed = 0f;
				return;
			}
			float num = (float)((double)(Acceleration_Actual(myUnit.ThrottleSetting, myUnit.GetCurrentAltitude(), myUnit.CurrentSpeed) * float_0) * (1.0 - 0.8 * (double)(float_1 / TurnRate())));
			if (num > 0f && myUnit.CurrentSpeed < myUnit.DesiredSpeed)
			{
				myUnit.CurrentSpeed += num;
				if ((int)Math.Round(myUnit.CurrentSpeed) > (int)Math.Round(myUnit.DesiredSpeed))
				{
					myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				}
			}
			if (myUnit.CurrentSpeed > myUnit.DesiredSpeed)
			{
				myUnit.CurrentSpeed = (float)((double)myUnit.CurrentSpeed - GetDecelerationCapacity(myUnit.GetCurrentAltitude(), myUnit.CurrentSpeed, float_0));
				if ((int)Math.Round(myUnit.CurrentSpeed) < (int)Math.Round(myUnit.DesiredSpeed))
				{
					myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				}
			}
			if (myUnit.CurrentSpeed < 0f)
			{
				myUnit.CurrentSpeed = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100195", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void CalcTurnDeceleration(double double_0, float float_0)
	{
	}

	public virtual void ChangeAltitude(float float_0, float float_1, float? nullable_0, bool bool_0)
	{
		try
		{
			if (Module_Unit.AwakeTokenizer(myUnit))
			{
				myUnit.SetCurrentAltitude(bool_0: false, myUnit.GetCurrentAltitude() + myUnit._ErrorItem * float_0);
				return;
			}
			double num = (myUnit.GetCurrentAltitude() - myUnit.Altitude_old) / float_0;
			myUnit.Altitude_old = myUnit.GetCurrentAltitude();
			float currentAltitude = myUnit.GetCurrentAltitude();
			if (myUnit.IsWeapon && ((Weapon)myUnit).IsReEntryVehicle && myUnit.DesiredAltitude > myUnit.GetCurrentAltitude())
			{
				myUnit.DesiredAltitude = Math.Min(myUnit.GetCurrentAltitude() - 1f, myUnit.DesiredAltitude);
			}
			float attitude_Pitch = myUnit.Attitude_Pitch;
			float num2 = ClimbRate_Actual(attitude_Pitch) * float_0;
			float num3 = DiveRate_Actual(attitude_Pitch) * float_0;
			if (num < 0.0)
			{
				num2 = (float)((double)num2 - num);
			}
			if (num > 0.0)
			{
				num3 = (float)((double)num3 - Math.Abs(num));
			}
			if (nullable_0.HasValue && (nullable_0.HasValue ? new bool?(float_1 < nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				float_1 = nullable_0.Value;
			}
			if (myUnit.GetCurrentAltitude() < float_1)
			{
				currentAltitude = (myUnit.SupportsAttitude_Pitch ? (myUnit.GetCurrentAltitude() + num2) : ((float_1 - myUnit.GetCurrentAltitude() <= num2) ? float_1 : (myUnit.GetCurrentAltitude() + num2)));
				myUnit.SetCurrentAltitude(bool_0, currentAltitude);
			}
			else if (myUnit.GetCurrentAltitude() <= float_1)
			{
				if (myUnit.GetCurrentAltitude() - float_1 == 0f)
				{
					myUnit.DesiredPitch = 0f;
				}
				if (myUnit.Attitude_Pitch < 0f && nullable_0.HasValue)
				{
					float currentAltitude2 = myUnit.GetCurrentAltitude();
					if ((nullable_0.HasValue ? new bool?(currentAltitude2 <= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
			}
			else
			{
				currentAltitude = (myUnit.SupportsAttitude_Pitch ? (myUnit.GetCurrentAltitude() - num3) : ((myUnit.GetCurrentAltitude() - float_1 <= num3) ? float_1 : (myUnit.GetCurrentAltitude() - num3)));
				if (nullable_0.HasValue && (nullable_0.HasValue ? new bool?(currentAltitude <= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					myUnit.Attitude_Pitch = 0f;
				}
				myUnit.SetCurrentAltitude(bool_0, currentAltitude);
			}
			float maximumAltitude = GetMaximumAltitude();
			float minimumAltitude = GetMinimumAltitude();
			if (myUnit.GetCurrentAltitude() <= maximumAltitude)
			{
				if (myUnit.GetCurrentAltitude() < minimumAltitude)
				{
					myUnit.SetCurrentAltitude(bool_0, minimumAltitude);
					if (myUnit.Attitude_Pitch < 0f)
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
			}
			else
			{
				myUnit.SetCurrentAltitude(bool_0, maximumAltitude);
				if (myUnit.Attitude_Pitch > 0f)
				{
					myUnit.Attitude_Pitch = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100196", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ExportLocationEvent(bool bool_0, IEventExporter.ExportedEventType exportedEventType_0 = IEventExporter.ExportedEventType.UnitPositions)
	{
		if (m_FilterWrapper && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		try
		{
			int num = 0;
			foreach (IEventExporter applicableEventExporter in myUnit.ParentScen.ApplicableEventExporters)
			{
				if (!applicableEventExporter.IsOperating || !applicableEventExporter.ExportUnitPositions || (!bool_0 && !applicableEventExporter.Common.AssetRepository(myUnit.ParentScen, myUnit)))
				{
					continue;
				}
				PerformOutOfSequenceExportLocation = false;
				m_FilterWrapper = true;
				if (myUnit.GetUnitSide() == null)
				{
					continue;
				}
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (myUnit.ParentScen.MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string), 500));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.TimelineID, typeof(string), 40));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.Subtract(myUnit.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + myUnit.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string), 40));
				dictionary.Add("UnitDBID", new IEventExporter.EventNotificationParameter(myUnit.DBID, typeof(string), 10));
				dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string), 500));
				dictionary.Add("UnitType", new IEventExporter.EventNotificationParameter(myUnit.UnitType_String, typeof(string), 20));
				dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string), 500));
				dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(myUnit.GetUnitSide().Name, typeof(string), 500));
				dictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.GetLongitude(), typeof(double)));
				dictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.GetLatitude(), typeof(double)));
				dictionary.Add("UnitCourse", new IEventExporter.EventNotificationParameter(myUnit.CurrentHeading, typeof(float)));
				dictionary.Add("UnitSpeed_kts", new IEventExporter.EventNotificationParameter(myUnit.CurrentSpeed, typeof(float)));
				dictionary.Add("UnitAltitude_m", new IEventExporter.EventNotificationParameter(myUnit.GetCurrentAltitude(), typeof(float)));
				if (!myUnit.IsAircraft && !myUnit.IsMissile && !myUnit.IsTorpedo)
				{
					dictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(myUnit.Attitude_Pitch, typeof(float)));
				}
				else
				{
					dictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(myUnit.Attitude_Pitch_Derived(), typeof(float)));
				}
				dictionary.Add("UnitAttitude_Roll", new IEventExporter.EventNotificationParameter(myUnit.Attitude_Roll, typeof(float)));
				if (applicableEventExporter.UsesUnitMissionAndStatus)
				{
					dictionary.Add("Status", new IEventExporter.EventNotificationParameter(Misc.ToEnglishString(myUnit.Status, myUnit), typeof(string), 100));
					dictionary.Add("Condition_AirOps", new IEventExporter.EventNotificationParameter(myUnit.IsAircraft ? ((Aircraft)myUnit).AirOps.ConditionString : string.Empty, typeof(string), 100));
					dictionary.Add("Condition_DockingOps", new IEventExporter.EventNotificationParameter(myUnit.DockingOps.ConditionString, typeof(string), 100));
					string object_ = string.Empty;
					if (myUnit.AssignedMissionOrPackage() != null)
					{
						object_ = myUnit.AssignedMissionOrPackage().Name;
					}
					dictionary.Add("AssignedMission", new IEventExporter.EventNotificationParameter(object_, typeof(string), 100));
				}
				if (applicableEventExporter.UsesUnitDamage)
				{
					dictionary.Add("DamagePercent", new IEventExporter.EventNotificationParameter(myUnit.Damage.DamagePercent, typeof(float)));
					dictionary.Add("Fire", new IEventExporter.EventNotificationParameter((myUnit.Damage.FireIntensity == ActiveUnit_Damage.FireIntensityLevel.NoFire) ? "None" : myUnit.Damage.FireIntensity.ToString(), typeof(string)));
					dictionary.Add("Flood", new IEventExporter.EventNotificationParameter((myUnit.Damage.FloodIntensity == ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding) ? "None" : myUnit.Damage.FloodIntensity.ToString(), typeof(string)));
					string text = string.Empty;
					foreach (PlatformComponent item in myUnit.OrderIssuer())
					{
						if (item.Status != 0)
						{
							text = text + item.ObjectID + "_" + item.DBID + "_" + item.DamageSeverity.ToString() + "|";
							num++;
						}
					}
					if (num > 1)
					{
						text = text.Substring(0, text.Length - 1);
					}
					dictionary.Add("ComponentStatus", new IEventExporter.EventNotificationParameter(text, typeof(string), 4000));
				}
				applicableEventExporter.ExportEvent(exportedEventType_0, dictionary, myUnit.ParentScen);
				applicableEventExporter.Common.ApplyLastExportLocation(myUnit);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			m_FilterWrapper = false;
		}
	}

	public virtual void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		try
		{
			if (myUnit.AI.HoldPosition)
			{
				if (myUnit.IsAircraft)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				}
			}
			else if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.ThrottlePreset != UnitThrottlePreset.None && !myUnit.Navigator.m_ErrorWrapper)
				{
					if (myUnit.Status != 0 && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						if (myUnit.IsAircraft)
						{
							Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)myUnit.AirOps;
							if (aircraft_AirOps.RefuellingQueue.Count + aircraft_AirOps.A2AR_Connections.Count == 0)
							{
								myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							}
						}
						else if (myUnit.IsShip)
						{
							ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
							if (dockingOps.UNREP_Queue.Count == 0 && string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
							{
								myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							}
						}
						else if (myUnit.IsSubmarine)
						{
							ActiveUnit_DockingOps dockingOps2 = myUnit.DockingOps;
							if (dockingOps2.UNREP_Queue.Count == 0 && string.IsNullOrEmpty(dockingOps2.UNREP_Starboard_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps2.UNREP_Port_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps2.UNREP_Astern_ReceiverUnitID))
							{
								myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							}
						}
						else
						{
							myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
						}
					}
				}
				else
				{
					myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
				}
			}
			float num = GetMaximumSpeed(myUnit.GetCurrentAltitude(), myUnit.ThrottleSetting, bool_0: true);
			if (myUnit.IsShip && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed))
			{
				int maximumSpeedForThisSeaState = Ship_Kinematics.GetMaximumSpeedForThisSeaState((Ship)myUnit, Weather.GetWeatherAtThisTimeAndPlace(myUnit.ParentScen, myUnit.GetLatitude(), myUnit.GetLongitude(), 0).SeaState);
				if (num > (float)maximumSpeedForThisSeaState)
				{
					num = maximumSpeedForThisSeaState;
				}
			}
			if ((myUnit.IsShip || myUnit.IsSubmarine) && GeoPoint.GetIsInCanal(myUnit.GetLatitude(), myUnit.GetLongitude()))
			{
				num = 8f;
			}
			if (myUnit.IsOutOfFuel)
			{
				if (myUnit.IsWeapon && myUnit.SupportsAttitude_Pitch)
				{
					if (myUnit.Attitude_Pitch > ((Weapon)myUnit).MoveDescriptor())
					{
						num = 0f;
					}
				}
				else
				{
					num = 0f;
				}
			}
			if (myUnit.DesiredSpeed > num)
			{
				myUnit.DesiredSpeed = num;
			}
			double num2 = myUnit.CurrentHeading;
			if (myUnit.CurrentHeading == myUnit.DesiredHeading)
			{
				ActualMovementVector = myUnit.CurrentHeading;
			}
			else
			{
				TurnToDesiredHeading(float_0);
			}
			if (myUnit.CurrentSpeed != 0f)
			{
				myUnit.ActualHorizMovement(float_0, bool_1);
			}
			double num3 = (double)Math.Abs(MathFunctions.DeleteRequest((float)num2, myUnit.CurrentHeading)) * (double)(1f / float_0);
			CalcTurnDeceleration(num3, float_0);
			bool flag = false;
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & !Information.IsNothing(myUnit.GetParentGroup())) || Information.IsNothing(myUnit.GetParentGroup().GroupLead) || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.GetParentGroup().GroupLead.CurrentSpeed)) && (int)Math.Round(num2) != (int)Math.Round(myUnit.CurrentHeading))
			{
				if (myUnit.Navigator.PreviousWaypointType.HasValue)
				{
					int? num4 = (int?)myUnit.Navigator.PreviousWaypointType;
					bool? flag2 = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 15) : null);
					if (!((!flag2) ?? flag2).GetValueOrDefault())
					{
						goto IL_0734;
					}
				}
				flag = true;
			}
			goto IL_0734;
			IL_0734:
			if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(float_0, (float)num3);
			}
			if (myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				myUnit.Longitude_LastReported = myUnit.GetLongitude();
				myUnit.Latitude_LastReported = myUnit.GetLatitude();
			}
			else
			{
				if (!myUnit.Longitude_LastReported.HasValue)
				{
					myUnit.Longitude_LastReported = myUnit.GetLongitude();
				}
				if (!myUnit.Latitude_LastReported.HasValue)
				{
					myUnit.Latitude_LastReported = myUnit.GetLatitude();
				}
			}
			if (!bool_1)
			{
				myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100197", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual float HorizMovementDistanceOnThisTime(float float_0)
	{
		return Module_Unit.CalcTokenizer(myUnit) / 3600f * float_0;
	}

	public virtual float HorizDistranceRequiredToReachDesiredAltitude(ActiveUnit activeUnit_0, float float_0, float float_1 = 0f)
	{
		lock (activeUnit_0)
		{
			float result = 0f;
			try
			{
				if (!activeUnit_0.IsAircraft && !activeUnit_0.IsSatellite && !activeUnit_0.IsWeapon)
				{
					result = 0f;
					return result;
				}
				if (activeUnit_0.Propulsion.Count == 0)
				{
					result = 0f;
					return result;
				}
				if (activeUnit_0.ThrottleSetting == ActiveUnit.Throttle.FullStop)
				{
					result = 0f;
					return result;
				}
				if (activeUnit_0.GetCurrentAltitude() == float_0)
				{
					result = 0f;
					return result;
				}
				AltBand altBand = null;
				Engine engine = activeUnit_0.Propulsion[0];
				float currentAltitude = activeUnit_0.GetCurrentAltitude();
				_TestsWrapper.Clear();
				AltBand[] altBands = engine.AltBands;
				if (altBands.Length == 0)
				{
					result = 0f;
					return result;
				}
				if (engine.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					result = 0f;
					return result;
				}
				float num;
				float num5;
				float num6;
				if (activeUnit_0.GetCurrentAltitude() <= float_0)
				{
					if (!(activeUnit_0.GetCurrentAltitude() < float_0))
					{
						result = 0f;
						return result;
					}
					AltBand[] array2 = altBands;
					AltBand[] array3 = array2;
					foreach (AltBand altBand2 in array3)
					{
						if (altBand2.MaxAlt >= currentAltitude && altBand2.MinAlt <= float_0)
						{
							_TestsWrapper.Add(altBand2);
						}
					}
					if (_TestsWrapper.Count > 1)
					{
						_TestsWrapper.Sort(new AltBandComparer_SortyByMaxAltAscending());
					}
					num = float_0;
					num5 = activeUnit_0.GetCurrentAltitude();
					num6 = activeUnit_0.Kinematics.GetClimbRate_Nominal();
				}
				else
				{
					AltBand[] array = altBands;
					AltBand[] array4 = array;
					foreach (AltBand altBand3 in array4)
					{
						if (altBand3.MinAlt <= currentAltitude && altBand3.MaxAlt >= float_0)
						{
							_TestsWrapper.Add(altBand3);
						}
					}
					if (_TestsWrapper.Count > 1)
					{
						_TestsWrapper.Sort(new AltBandComparer_SortyByMaxAltAscending());
					}
					num = activeUnit_0.GetCurrentAltitude();
					num5 = float_0;
					num6 = activeUnit_0.Kinematics.DiveRate_Nominal();
				}
				if (_TestsWrapper.Count == 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = 0f;
					return result;
				}
				float num7 = 0f;
				float num8 = 0f;
				float num9 = 0f;
				foreach (AltBand item in _TestsWrapper)
				{
					try
					{
						switch (activeUnit_0.ThrottleSetting)
						{
						case ActiveUnit.Throttle.FullStop:
							result = 0f;
							return result;
						case ActiveUnit.Throttle.Loiter:
							num7 = item.Speed_Loiter;
							break;
						case ActiveUnit.Throttle.Cruise:
							num7 = ((item.Speed_Cruise <= 0) ? ((float)item.Speed_Loiter) : ((float)item.Speed_Cruise));
							break;
						case ActiveUnit.Throttle.Full:
							num7 = (item.Speed_Full.HasValue ? ((float)item.Speed_Full.Value) : ((float)item.Speed_Cruise));
							break;
						case ActiveUnit.Throttle.Flank:
							num7 = (item.Speed_Flank.HasValue ? ((float)item.Speed_Flank.Value) : (item.Speed_Full.HasValue ? ((float)item.Speed_Full.Value) : ((float)item.Speed_Cruise)));
							break;
						}
						float num10;
						float num11;
						int num12;
						if (item == HighestAltBand(engine))
						{
							num10 = item.MinAlt;
							num11 = activeUnit_0.GetCurrentAltitude();
							num12 = (int)Math.Round(num7);
						}
						else
						{
							altBand = altBands[Array.IndexOf(altBands, item) + 1];
							switch (activeUnit_0.ThrottleSetting)
							{
							case ActiveUnit.Throttle.FullStop:
								num8 = 0f;
								break;
							case ActiveUnit.Throttle.Loiter:
								num8 = altBand.Speed_Loiter;
								break;
							case ActiveUnit.Throttle.Cruise:
								num8 = altBand.Speed_Cruise;
								break;
							case ActiveUnit.Throttle.Full:
								num8 = (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise));
								break;
							case ActiveUnit.Throttle.Flank:
								num8 = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise)));
								break;
							}
							int num2;
							if (num5 <= item.MinAlt)
							{
								num10 = item.MinAlt;
								num2 = (int)Math.Round(num7);
							}
							else
							{
								num10 = num5;
								num2 = GetMaximumSpeed(num5, activeUnit_0.ThrottleSetting, bool_0: false);
							}
							int num3;
							if (num < item.MaxAlt)
							{
								num11 = num;
								num3 = GetMaximumSpeed(num, activeUnit_0.ThrottleSetting, bool_0: false);
							}
							else
							{
								num11 = altBand.MinAlt;
								num3 = (int)Math.Round(num8);
							}
							num12 = (int)Math.Round((double)(num3 + num2) / 2.0 + (double)float_1);
						}
						float num4 = (num11 - num10) / num6;
						num9 += num4 / 3600f * (float)num12;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 101165", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				result = num9;
				return result;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100198", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public virtual float TurnRate()
	{
		if (myUnit.IsSatellite)
		{
			return 0f;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return 0f;
	}

	public static float TurnRateCategoryToActualTurnRate(Waypoint.TurnRateCategory turnRateCategory_0, float float_0)
	{
		if (1 == 0)
		{
		}
		float result = turnRateCategory_0 switch
		{
			Waypoint.TurnRateCategory.StandardRateTurn => 3f, 
			Waypoint.TurnRateCategory.HalfStandardRateTurn => 1.5f, 
			Waypoint.TurnRateCategory.DoubleStandardRateTurn => 6f, 
			Waypoint.TurnRateCategory.FlatTurn => 0.6f, 
			Waypoint.TurnRateCategory.TwoGTurn => G_To_DegreesPerSecond(float_0, 60f), 
			Waypoint.TurnRateCategory.const_5 => G_To_DegreesPerSecond(float_0, 70f), 
			Waypoint.TurnRateCategory.const_6 => G_To_DegreesPerSecond(float_0, 75f), 
			_ => 3f, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static float G_To_DegreesPerSecond(float float_0, float float_1)
	{
		return (float)(1091.0 * Math.Tan((double)float_1 * 0.0174532925199433) / (double)float_0);
	}
}
