using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class TaskPool : Mission
{
	public List<Mission> PackageList;

	public List<string> PackageList_IDs;

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("TaskPool");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Category", ((byte)Category).ToString());
			method_0(ref xmlWriter_0, ref hashSet_0, ref scenario_0);
			xmlWriter_0.WriteStartElement("Packages");
			foreach (Mission package in PackageList)
			{
				if (!Information.IsNothing(package))
				{
					xmlWriter_0.WriteElementString("ID", package.ObjectID);
				}
			}
			xmlWriter_0.WriteEndElement();
			if (_StartTime.HasValue)
			{
				xmlWriter_0.WriteElementString("START", _StartTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				xmlWriter_0.WriteElementString("END", _EndTime.Value.ToBinary().ToString());
			}
			if (_TakeOffTime.HasValue)
			{
				xmlWriter_0.WriteElementString("TakeOffTime", _TakeOffTime.Value.ToBinary().ToString());
			}
			if (_TimeOnTarget.HasValue)
			{
				xmlWriter_0.WriteElementString("TimeOnTarget", _TimeOnTarget.Value.ToBinary().ToString());
			}
			xmlWriter_0.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			xmlWriter_0.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			xmlWriter_0.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200648", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static TaskPool FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, Mission mission_0 = null)
	{
		TaskPool result = null;
		try
		{
			Side side_ = null;
			TaskPool taskPool = new TaskPool(ref side_, ref scenario_0, "", MissionCategory.Mission);
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					Mission.FromXMLCommon(taskPool, xmlNode);
					switch (xmlNode.Name)
					{
					case "Packages":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								taskPool.PackageList_IDs.Add(xmlNode2.InnerText);
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
					case "Name":
						taskPool.Name = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							taskPool.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(taskPool.ObjectID, taskPool);
							break;
						}
						result = (TaskPool)concurrentDictionary_0[xmlNode.InnerText];
						return result;
					case "Category":
						taskPool.Category = (MissionCategory)Conversions.ToInteger(xmlNode.InnerText);
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
			result = taskPool;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200649", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public TaskPool(ref Side side_0, ref Scenario scenario_0, string string_0, MissionCategory missionCategory_0)
		: base(side_0, scenario_0, string_0)
	{
		PackageList = new List<Mission>();
		PackageList_IDs = new List<string>();
		IsMission = true;
		Name = string_0;
		Category = missionCategory_0;
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		return "任务池";
	}

	public override void PostDeserializationHousekeeping(ref Scenario scenario_0, Side side_0, bool bool_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			foreach (string packageList_ID in PackageList_IDs)
			{
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i++)
				{
					foreach (Mission mission in sides_ReadOnly[i].Missions)
					{
						if (Operators.CompareString(mission.ObjectID, packageList_ID, TextCompare: false) == 0)
						{
							PackageList.Add(mission);
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(_SecondaryAirBaseID) && !concurrentDictionary_0.ContainsKey(_SecondaryAirBaseID))
			{
				SecondaryAirBase = (ActiveUnit)concurrentDictionary_0[_SecondaryAirBaseID];
			}
			if (!string.IsNullOrEmpty(_SecondaryNavalBaseID) && !concurrentDictionary_0.ContainsKey(_SecondaryNavalBaseID))
			{
				SecondaryNavalBase = (ActiveUnit)concurrentDictionary_0[_SecondaryNavalBaseID];
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200650", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
