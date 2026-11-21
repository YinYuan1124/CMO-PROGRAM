using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class DestroyGoal : ScenarioGoal
{
	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("DestroyGoal");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("NeedsToBeChecked", NeedsToBeChecked.ToString());
			xmlWriter_0.WriteElementString("IsRepeatable", IsRepeatable.ToString());
			xmlWriter_0.WriteElementString("GoalPoints", GoalPoints.ToString());
			if (!string.IsNullOrEmpty(TargetSide))
			{
				xmlWriter_0.WriteElementString("TargetSide", TargetSide);
			}
			XmlWriter xmlWriter = xmlWriter_0;
			int targetType = (int)TargetType;
			xmlWriter.WriteElementString("TargetType", targetType.ToString());
			xmlWriter_0.WriteElementString("TargetSubType", TargetSubType.ToString());
			if (SpecificUnitClass != 0)
			{
				xmlWriter_0.WriteElementString("SpecificUnitClass", SpecificUnitClass.ToString());
			}
			if (!Information.IsNothing(SpecificUnit))
			{
				xmlWriter_0.WriteStartElement("SpecificUnit");
				SpecificUnit.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100756", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static DestroyGoal FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			DestroyGoal destroyGoal = new DestroyGoal();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "GoalPoints":
						destroyGoal.GoalPoints = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "TargetSubType":
						destroyGoal.TargetSubType = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "SpecificUnitClass":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							destroyGoal.SpecificUnitClass = Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							destroyGoal.SpecificUnitClass = DBFunctions.GetActiveUnitIDByName(xmlNode.InnerText, destroyGoal.TargetType, scenario_0.DBConnection);
						}
						break;
					case "Description":
						destroyGoal.Description = xmlNode.InnerText;
						break;
					case "ID":
						destroyGoal.ObjectID_Set(xmlNode.InnerText);
						break;
					case "IsRepeatable":
						destroyGoal.IsRepeatable = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "TargetType":
						destroyGoal.TargetType = (GlobalVariables.ActiveUnitType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "SpecificUnit":
						if (xmlNode.HasChildNodes)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[0];
							destroyGoal.SpecificUnit = ActiveUnit.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref scenario_0);
						}
						break;
					case "TargetSide":
						destroyGoal.TargetSide = xmlNode.InnerText;
						break;
					case "NeedsToBeChecked":
						destroyGoal.NeedsToBeChecked = Conversions.ToBoolean(xmlNode.InnerText);
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
			return destroyGoal;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100757", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DestroyGoal result = new DestroyGoal();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public bool IsFulfilled(ActiveUnit activeUnit_0)
	{
		try
		{
			if (!string.IsNullOrEmpty(TargetSide))
			{
				if (Information.IsNothing(activeUnit_0.GetUnitSide()))
				{
					return false;
				}
				if (Operators.CompareString(activeUnit_0.GetUnitSide().ObjectID, TargetSide, TextCompare: false) != 0)
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
			if (SpecificUnitClass == 0)
			{
				return true;
			}
			if (SpecificUnitClass == activeUnit_0.DBID)
			{
				if (Information.IsNothing(SpecificUnit))
				{
					return true;
				}
				if (SpecificUnit == activeUnit_0)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100758", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}
}
