using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_Kinematics : ActiveUnit_Kinematics
{
	private bool _StatusDic;

	public bool LeadAllowedToSlowDown
	{
		get
		{
			return _StatusDic;
		}
		set
		{
			_StatusDic = value;
		}
	}

	public override float? DesiredSpeedOverride
	{
		get
		{
			if (Information.IsNothing(((Group)myUnit).GroupLead))
			{
				return null;
			}
			return ((Group)myUnit).GroupLead.Kinematics.DesiredSpeedOverride;
		}
		set
		{
			try
			{
				if (!Information.IsNothing(((Group)myUnit).GroupLead))
				{
					((Group)myUnit).GroupLead.Kinematics.DesiredSpeedOverride = value;
				}
				foreach (ActiveUnit value2 in ((Group)myUnit).Units.Values)
				{
					if (!value2.IsGroupLead())
					{
						value2.Kinematics.DesiredSpeedOverride = null;
					}
				}
				if (!value.HasValue)
				{
					myUnit.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100614", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override UnitThrottlePreset ThrottlePreset
	{
		get
		{
			if (Information.IsNothing(((Group)myUnit).GroupLead))
			{
				return UnitThrottlePreset.FullStop;
			}
			return ((Group)myUnit).GroupLead.Kinematics.ThrottlePreset;
		}
		set
		{
			try
			{
				if (!Information.IsNothing(((Group)myUnit).GroupLead))
				{
					((Group)myUnit).GroupLead.Kinematics.ThrottlePreset = value;
				}
				foreach (ActiveUnit value2 in ((Group)myUnit).Units.Values)
				{
					if (!value2.IsGroupLead())
					{
						value2.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100615", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override bool DesiredAltitudeOverride
	{
		get
		{
			if (Information.IsNothing(((Group)myUnit).GroupLead))
			{
				return false;
			}
			return ((Group)myUnit).GroupLead.Kinematics.DesiredAltitudeOverride;
		}
		set
		{
			try
			{
				if (!Information.IsNothing(((Group)myUnit).GroupLead))
				{
					((Group)myUnit).GroupLead.Kinematics.DesiredAltitudeOverride = value;
				}
				foreach (ActiveUnit value2 in ((Group)myUnit).Units.Values)
				{
					if (!value2.IsGroupLead())
					{
						value2.Kinematics.DesiredAltitudeOverride = false;
					}
				}
				if (!value)
				{
					if (myUnit.IsGroup && ((Group)myUnit).Type == Group.GroupType.SubGroup)
					{
						((Group_AI)myUnit.AI).DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					}
					if (myUnit.IsGroup && ((Group)myUnit).Type == Group.GroupType.AirGroup)
					{
						((Group_AI)myUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100616", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteElementString("AMV", XmlConvert.ToString(ActualMovementVector));
			if (DesiredSpeedOverride.HasValue)
			{
				xmlWriter_0.WriteElementString("DSO", XmlConvert.ToString(DesiredSpeedOverride.Value));
			}
			if (DesiredAltitudeOverride)
			{
				xmlWriter_0.WriteElementString("DAO", DesiredAltitudeOverride.ToString());
			}
			xmlWriter_0.WriteElementString("LATSD", _StatusDic.ToString());
			xmlWriter_0.WriteElementString("SP", ((byte)ThrottlePreset).ToString());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100612", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Group_Kinematics FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Group_Kinematics group_Kinematics = new Group_Kinematics(ref activeUnit_0);
			group_Kinematics.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "DSO":
					case "DesiredSpeedOverride":
						if (Operators.CompareString(xmlNode.InnerText, true.ToString(), TextCompare: false) != 0 && Operators.CompareString(xmlNode.InnerText, false.ToString(), TextCompare: false) != 0)
						{
							group_Kinematics.DesiredSpeedOverride = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						}
						else if (Operators.CompareString(xmlNode.InnerText, true.ToString(), TextCompare: false) == 0)
						{
							group_Kinematics.DesiredSpeedOverride = activeUnit_0.DesiredSpeed;
						}
						break;
					case "AMV":
					case "ActualMovementVector":
						group_Kinematics.ActualMovementVector = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SP":
						group_Kinematics.ThrottlePreset = (UnitThrottlePreset)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "ClimbRate":
						group_Kinematics.SetClimbRate_Nominal(bool_0: true, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "LATSD":
						group_Kinematics._StatusDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
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
			return group_Kinematics;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100613", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Group_Kinematics result = new Group_Kinematics(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Group_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		_StatusDic = true;
	}

	public override float TurnRate()
	{
		return ((Group)myUnit).GroupLead.Kinematics.TurnRate();
	}

	public void UpdateGroupCenter()
	{
		if (!Information.IsNothing(((Group)myUnit).GroupLead))
		{
			myUnit.SetLongitude(null, ((Group)myUnit).GroupLead.GetLongitude());
			myUnit.SetLatitude(null, ((Group)myUnit).GroupLead.GetLatitude());
			myUnit.SetCurrentAltitude(bool_0: false, ((Group)myUnit).GroupLead.GetCurrentAltitude());
			myUnit.CurrentHeading = ((Group)myUnit).GroupLead.CurrentHeading;
			myUnit.CurrentSpeed = ((Group)myUnit).GroupLead.CurrentSpeed;
		}
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
	}

	public override float GetMaximumAltitude()
	{
		Group.GroupType type = ((Group)myUnit).Type;
		if (type != Group.GroupType.SurfaceGroup && (int)(type - 3) > 2)
		{
			IEnumerable<ActiveUnit> source = ((Group)myUnit).Units.Values.OrderByDescending((ActiveUnit AU) => AU.Kinematics.GetMaximumAltitude());
			if (source.Count() == 0)
			{
				return 0f;
			}
			return source.ElementAtOrDefault(0).Kinematics.GetMaximumAltitude();
		}
		return 0f;
	}

	public override float GetMinimumAltitude()
	{
		Group.GroupType type = ((Group)myUnit).Type;
		if (type != Group.GroupType.SurfaceGroup && (int)(type - 3) > 2)
		{
			IEnumerable<ActiveUnit> source = ((Group)myUnit).Units.Values.OrderBy((ActiveUnit AU) => AU.Kinematics.GetMinimumAltitude());
			if (source.Count() == 0)
			{
				return 0f;
			}
			return source.ElementAtOrDefault(0).Kinematics.GetMinimumAltitude();
		}
		return 0f;
	}

	public override float GetMinimumSpeed_Total(float float_0, bool bool_0)
	{
		return ((Group)myUnit).GroupLead.Kinematics.GetMinimumSpeed_Total(float_0, bool_0);
	}

	public override int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0, bool bool_1 = true)
	{
		if (((Group)myUnit).GroupLead == null)
		{
			return 0;
		}
		return ((Group)myUnit).GroupLead.Kinematics.GetMaximumSpeed(float_0, throttle_0, bool_0);
	}

	public int GroupMaxSpeedForThisThrottleSetting(ActiveUnit.Throttle throttle_0)
	{
		int num = 200000000;
		try
		{
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				int maximumSpeed = value.Kinematics.GetMaximumSpeed(value.GetCurrentAltitude(), throttle_0, bool_0: false);
				if (maximumSpeed < num)
				{
					num = maximumSpeed;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100617", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public int GroupMaxSpeedForThisSpeedSetting(int int_0)
	{
		int num = 200000000;
		try
		{
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				int maximumSpeed = value.Kinematics.GetMaximumSpeed();
				if (maximumSpeed < num)
				{
					num = maximumSpeed;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100618", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public float GroupMaxAltitude()
	{
		float num = 0f;
		try
		{
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				float maximumAltitude = value.Kinematics.GetMaximumAltitude();
				if (maximumAltitude > num)
				{
					num = maximumAltitude;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100619", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public void SetDesiredAltitude(float float_0)
	{
		myUnit.DesiredAltitude = float_0;
		foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
		{
			value.DesiredAltitude = float_0;
		}
	}
}
