using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class NoNavZone : Zone
{
	public bool IsLocked;

	public bool NoFireZone;

	public override ZoneType Type => ZoneType.NoNavZone;

	public NoNavZone(string string_0, List<ReferencePoint> list_0, Scenario scenario_0, Side side_0, List<GlobalVariables.ActiveUnitType> list_1 = null)
	{
		NoFireZone = true;
		Description = string_0;
		Area = list_0;
		if (Information.IsNothing(list_1))
		{
			AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
			{
				GlobalVariables.ActiveUnitType.Aircraft,
				GlobalVariables.ActiveUnitType.Ship,
				GlobalVariables.ActiveUnitType.Submarine,
				GlobalVariables.ActiveUnitType.Facility
			};
		}
		else
		{
			AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
			foreach (GlobalVariables.ActiveUnitType item in list_1)
			{
				AffectedUnitTypes.Add(item);
			}
		}
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (activeUnits_.GetUnitSide() == side_0)
			{
				activeUnits_.Navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
			}
		}
		string string_ = null;
		if (!ActiveUnit_Navigator.ValidateArea(ref list_0, ref string_, side_0, scenario_0, "封锁区 '" + Description + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
	}

	private NoNavZone()
	{
		NoFireZone = true;
	}

	public new static void TransformTo(Zone zone_0, Side side_0, Scenario scenario_0)
	{
		if (zone_0 != null)
		{
			side_0.NoNavZones.Add(new NoNavZone(zone_0.Description, zone_0.Area, scenario_0, side_0));
			side_0.StandardZones.Remove(zone_0);
		}
	}

	public new static void TransformTo(ExclusionZone exclusionZone_0, Side side_0, Scenario scenario_0)
	{
		if (exclusionZone_0 != null)
		{
			side_0.NoNavZones.Add(new NoNavZone(exclusionZone_0.Description, exclusionZone_0.Area, scenario_0, side_0));
			side_0.ExclusionZones.Remove(exclusionZone_0);
		}
	}

	public new static void TransformTo(CustomEnvironmentZone customEnvironmentZone_0, Side side_0, Scenario scenario_0)
	{
		scenario_0.CreateNatureSideIfNeeded();
		if (customEnvironmentZone_0 != null)
		{
			scenario_0.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(customEnvironmentZone_0.Description, customEnvironmentZone_0.Area, scenario_0, side_0, scenario_0.GlobalWeather));
			side_0.CustomEnvironmentZones.Remove(customEnvironmentZone_0);
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("NoNavZone");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("Area");
			int num = Area.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ReferencePoint referencePoint;
				try
				{
					referencePoint = Area[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				xmlWriter_0.WriteRaw(referencePoint.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("AffectedUnitTypes", string.Join("_", AffectedUnitTypes.Select(delegate(GlobalVariables.ActiveUnitType theType)
			{
				int num2 = (int)theType;
				return num2.ToString();
			})));
			xmlWriter_0.WriteElementString("IsLocked", IsLocked.ToString());
			xmlWriter_0.WriteElementString("IsActive", IsActive.ToString());
			xmlWriter_0.WriteElementString("NoFireZone", NoFireZone.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100993", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static NoNavZone FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			NoNavZone noNavZone = new NoNavZone();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "IsLocked":
						noNavZone.IsLocked = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AffectedUnitTypes":
					{
						noNavZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
						string[] array = xmlNode.InnerText.Split('_');
						string[] array2 = array;
						foreach (string text in array2)
						{
							if (Versioned.IsNumeric(text))
							{
								int num = Conversions.ToInteger(text);
								noNavZone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
							}
						}
						break;
					}
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								noNavZone.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "Description":
						noNavZone.Description = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							noNavZone.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(noNavZone.ObjectID, noNavZone);
							break;
						}
						return (NoNavZone)concurrentDictionary_0[xmlNode.InnerText];
					case "NoFireZone":
						noNavZone.NoFireZone = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "IsActive":
						noNavZone.IsActive = Conversions.ToBoolean(xmlNode.InnerText);
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
			if (Information.IsNothing(noNavZone.AffectedUnitTypes))
			{
				noNavZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			return noNavZone;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100994", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			NoNavZone result = new NoNavZone();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
