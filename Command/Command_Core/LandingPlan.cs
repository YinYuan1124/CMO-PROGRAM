using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class LandingPlan
{
	public int ID;

	public Side Side;

	public string Name;

	public Dictionary<Mission, Mission> Missions;

	public List<string> _SerializedMissionsGUIDS;

	public List<UnitLineWrapper> UnitLineWrappers;

	public List<LandingZoneWrapper> LandingZoneWrappers;

	public Dictionary<ActiveUnit, Transport> AllowedTransport;

	public bool Rebuilt;

	public LandingPlan(Side side_0, List<Mission> list_0, string string_0)
	{
		Missions = new Dictionary<Mission, Mission>();
		_SerializedMissionsGUIDS = new List<string>();
		UnitLineWrappers = new List<UnitLineWrapper>();
		LandingZoneWrappers = new List<LandingZoneWrapper>();
		AllowedTransport = new Dictionary<ActiveUnit, Transport>();
		Side = side_0;
		ID = GetClass() + 1;
		Name = string_0;
		AddMissions(list_0);
		LoginClass();
	}

	public LandingPlan(Side side_0)
	{
		Missions = new Dictionary<Mission, Mission>();
		_SerializedMissionsGUIDS = new List<string>();
		UnitLineWrappers = new List<UnitLineWrapper>();
		LandingZoneWrappers = new List<LandingZoneWrapper>();
		AllowedTransport = new Dictionary<ActiveUnit, Transport>();
		Side = side_0;
	}

	internal bool ValidateClass()
	{
		return Missions.Count > 0;
	}

	public void AddMission(Mission mission_0)
	{
		if (Missions.ContainsKey(mission_0))
		{
			mission_0.LandingPlan = this;
		}
		else
		{
			Missions.Add(mission_0, mission_0);
		}
	}

	public void AddMissions(List<Mission> list_0)
	{
		foreach (Mission item in list_0)
		{
			AddMission(item);
		}
	}

	private void LoginClass()
	{
		foreach (KeyValuePair<Mission, Mission> item in Missions.ToList())
		{
			item.Key.LandingPlan = this;
		}
	}

	private int GetClass()
	{
		int num = 0;
		foreach (LandingPlan landingPlan in Side.LandingPlans)
		{
			if (landingPlan.ID > num)
			{
				num = landingPlan.ID;
			}
		}
		return num;
	}

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("LandingPlans");
			xmlWriter_0.WriteElementString("LocalID", ID.ToString());
			xmlWriter_0.WriteElementString("Name", Name.ToString());
			xmlWriter_0.WriteStartElement("Missions");
			foreach (Mission value in Missions.Values)
			{
				xmlWriter_0.WriteElementString("Mission_ObjectID", value.ObjectID);
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at LandingPlanner_000", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static LandingPlan FromXML(ref XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Side side_0, ref Scenario scenario_0)
	{
		try
		{
			LandingPlan landingPlan = new LandingPlan(side_0);
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
					case "Name":
						landingPlan.Name = xmlNode.InnerText;
						break;
					case "Missions":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								landingPlan._SerializedMissionsGUIDS.Add(xmlNode2.InnerText);
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
					case "LocalID":
						landingPlan.ID = Conversions.ToInteger(xmlNode.InnerText);
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
			return landingPlan;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at LandingPlanner_001", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}
}
