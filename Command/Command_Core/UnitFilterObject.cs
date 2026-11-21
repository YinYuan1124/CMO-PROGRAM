using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class UnitFilterObject : ScenarioObject
{
	public string TargetSide;

	public GlobalVariables.ActiveUnitType TargetType;

	public int TargetSubType;

	public int SpecificUnitClass;

	public string SpecificUnitID;

	public bool ShowAllTypes;

	public UnitFilterObject()
	{
		ShowAllTypes = false;
	}

	public void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (!string.IsNullOrEmpty(TargetSide))
			{
				xmlWriter_0.WriteElementString("TargetSide", TargetSide);
			}
			int targetType = (int)TargetType;
			xmlWriter_0.WriteElementString("TargetType", targetType.ToString());
			xmlWriter_0.WriteElementString("TargetSubType", TargetSubType.ToString());
			if (ShowAllTypes)
			{
				xmlWriter_0.WriteElementString("ShowAllTypes", ShowAllTypes.ToString());
			}
			if (SpecificUnitClass != 0)
			{
				xmlWriter_0.WriteElementString("SpecificUnitClass", SpecificUnitClass.ToString());
			}
			if (!string.IsNullOrEmpty(SpecificUnitID))
			{
				xmlWriter_0.WriteElementString("SpecificUnitID", SpecificUnitID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101070", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static UnitFilterObject FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			UnitFilterObject unitFilterObject = new UnitFilterObject();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TargetSubType":
						unitFilterObject.TargetSubType = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ShowAllTypes":
						unitFilterObject.ShowAllTypes = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SpecificUnitClass":
						unitFilterObject.SpecificUnitClass = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ID":
						unitFilterObject.ObjectID_Set(xmlNode.InnerText);
						break;
					case "TargetSide":
						unitFilterObject.TargetSide = xmlNode.InnerText;
						break;
					case "TargetType":
						unitFilterObject.TargetType = (GlobalVariables.ActiveUnitType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "SpecificUnit":
						if (xmlNode.HasChildNodes)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[0];
							ActiveUnit activeUnit = ActiveUnit.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref scenario_0);
							if (activeUnit != null)
							{
								unitFilterObject.SpecificUnitID = activeUnit.ObjectID;
							}
						}
						break;
					case "SpecificUnitID":
						unitFilterObject.SpecificUnitID = xmlNode.InnerText;
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
			return unitFilterObject;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101071", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			UnitFilterObject result = new UnitFilterObject();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public bool MatchesThisUnit(ActiveUnit activeUnit_0)
	{
		if (!string.IsNullOrEmpty(TargetSide))
		{
			if (activeUnit_0.GetUnitSide() == null)
			{
				return false;
			}
			if (string.CompareOrdinal(activeUnit_0.GetUnitSide().ObjectID, TargetSide) != 0)
			{
				return false;
			}
		}
		switch (TargetType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			if (!activeUnit_0.IsAircraft)
			{
				return false;
			}
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			if (!activeUnit_0.IsShip)
			{
				return false;
			}
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			if (!activeUnit_0.IsSubmarine)
			{
				return false;
			}
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			if (!activeUnit_0.IsFacility)
			{
				return false;
			}
			break;
		case GlobalVariables.ActiveUnitType.Aimpoint:
			return false;
		case GlobalVariables.ActiveUnitType.Weapon:
			if (!activeUnit_0.IsWeapon)
			{
				return false;
			}
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			if (!activeUnit_0.IsSatellite)
			{
				return false;
			}
			break;
		}
		if (TargetSubType == 0)
		{
			return true;
		}
		if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).Type != (Aircraft._AircraftType)TargetSubType)
		{
			return false;
		}
		if (activeUnit_0.IsShip && ((Ship)activeUnit_0).Type != (Ship._ShipType)TargetSubType)
		{
			return false;
		}
		if (activeUnit_0.IsSubmarine && ((Submarine)activeUnit_0).Type != (Submarine._SubmarineType)TargetSubType)
		{
			return false;
		}
		if (activeUnit_0.IsFacility && (int)((Facility)activeUnit_0).Category != TargetSubType)
		{
			return false;
		}
		if (activeUnit_0.IsWeapon && (int)((Weapon)activeUnit_0).Type != TargetSubType)
		{
			return false;
		}
		if (activeUnit_0.IsSatellite && ((Satellite)activeUnit_0).Type != (Satellite._SatelliteType)TargetSubType)
		{
			return false;
		}
		if (SpecificUnitClass == 0)
		{
			return true;
		}
		if (SpecificUnitClass == activeUnit_0.DBID)
		{
			if (string.IsNullOrEmpty(SpecificUnitID))
			{
				return true;
			}
			if (Operators.CompareString(SpecificUnitID, activeUnit_0.ObjectID, TextCompare: false) == 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public bool MatchesThisUnit(UnguidedWeapon unguidedWeapon_0)
	{
		if (!string.IsNullOrEmpty(TargetSide))
		{
			if (unguidedWeapon_0.GetUnitSide() == null)
			{
				return false;
			}
			if (string.CompareOrdinal(unguidedWeapon_0.GetUnitSide().ObjectID, TargetSide) != 0)
			{
				return false;
			}
		}
		if (TargetType == GlobalVariables.ActiveUnitType.Weapon)
		{
			if (unguidedWeapon_0.IsMine)
			{
				if (TargetSubType == 0)
				{
					return true;
				}
				if ((int)unguidedWeapon_0.Type == TargetSubType)
				{
					if (SpecificUnitClass == 0)
					{
						return true;
					}
					if (Operators.CompareString("武器_" + Conversions.ToString(SpecificUnitClass), unguidedWeapon_0.AnnexAndDBID, TextCompare: false) == 0)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public UnitFilterObject Clone()
	{
		return (UnitFilterObject)MemberwiseClone();
	}
}
