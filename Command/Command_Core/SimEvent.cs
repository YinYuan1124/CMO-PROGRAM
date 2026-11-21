using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SimEvent : ScenarioObject
{
	public string Description;

	public bool IsRepeatable;

	public bool IsActive;

	public bool IsShown;

	public short Probability;

	public List<EventTrigger> Triggers;

	public List<EventCondition> Conditions;

	public List<EventAction> Actions;

	public void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SimEvent");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("IsRepeatable", IsRepeatable.ToString());
			xmlWriter_0.WriteElementString("IsActive", IsActive.ToString());
			xmlWriter_0.WriteElementString("IsShown", IsShown.ToString());
			xmlWriter_0.WriteElementString("Probability", Probability.ToString());
			xmlWriter_0.WriteStartElement("Triggers");
			foreach (EventTrigger trigger in Triggers)
			{
				if (!Information.IsNothing(trigger))
				{
					xmlWriter_0.WriteElementString("Trigger", trigger.ObjectID);
				}
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Conditions");
			foreach (EventCondition condition in Conditions)
			{
				if (!Information.IsNothing(condition))
				{
					xmlWriter_0.WriteElementString("Condition", condition.ObjectID);
				}
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Actions");
			foreach (EventAction action in Actions)
			{
				if (!Information.IsNothing(action))
				{
					xmlWriter_0.WriteElementString("Action", action.ObjectID);
				}
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100538", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static SimEvent FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		SimEvent result = null;
		try
		{
			SimEvent simEvent = new SimEvent();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Probability":
						simEvent.Probability = Conversions.ToShort(xmlNode.InnerText);
						break;
					case "IsShown":
						simEvent.IsShown = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ID":
						simEvent.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Conditions":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode4 = (XmlNode)enumerator3.Current;
								EventCondition item3 = scenario_0.EventConditions[xmlNode4.InnerText];
								simEvent.Conditions.Add(item3);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					case "IsRepeatable":
						simEvent.IsRepeatable = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Description":
						simEvent.Description = xmlNode.InnerText;
						break;
					case "Triggers":
						try
						{
							enumerator4 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator4.Current;
								EventTrigger item2 = scenario_0.EventTriggers[xmlNode3.InnerText];
								simEvent.Triggers.Add(item2);
							}
						}
						finally
						{
							if (enumerator4 is IDisposable)
							{
								(enumerator4 as IDisposable).Dispose();
							}
						}
						break;
					case "Actions":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								EventAction item = scenario_0.EventActions[xmlNode2.InnerText];
								simEvent.Actions.Add(item);
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
					case "IsActive":
						simEvent.IsActive = Conversions.ToBoolean(xmlNode.InnerText);
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
			result = simEvent;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100539", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public SimEvent()
	{
		Triggers = new List<EventTrigger>();
		Conditions = new List<EventCondition>();
		Actions = new List<EventAction>();
		IsActive = true;
		IsRepeatable = false;
		IsShown = true;
		Probability = 100;
	}

	[SpecialName]
	public bool GetConditionsAreMet(Scenario scenario_0)
	{
		if (Conditions.Count == 0)
		{
			return true;
		}
		foreach (EventCondition condition in Conditions)
		{
			if (!condition.GetIsTrue(scenario_0, this))
			{
				return false;
			}
		}
		return true;
	}

	public SimEvent Clone()
	{
		SimEvent obj = (SimEvent)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.Triggers = new List<EventTrigger>();
		obj.Triggers.AddRange(Triggers);
		obj.Conditions = new List<EventCondition>();
		obj.Conditions.AddRange(Conditions);
		obj.Actions = new List<EventAction>();
		obj.Actions.AddRange(Actions);
		return obj;
	}
}
