using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class ScenarioGoal : ScenarioObject
{
	public string TargetSide;

	public GlobalVariables.ActiveUnitType TargetType;

	public int TargetSubType;

	public int SpecificUnitClass;

	public ActiveUnit SpecificUnit;

	public string Description;

	public bool NeedsToBeChecked;

	public bool IsRepeatable;

	public int GoalPoints;

	public ScenarioGoal()
	{
		NeedsToBeChecked = true;
	}

	public virtual void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ScenarioGoal");
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
			if (!string.IsNullOrEmpty(Conversions.ToString(SpecificUnitClass)))
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
			exception_?.Data.Add("Error at 100759", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ScenarioGoal FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			if (Operators.CompareString(xmlNode_0.Name, "DestroyGoal", TextCompare: false) == 0)
			{
				return DestroyGoal.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100760", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		throw new NotImplementedException();
	}

	public bool IsFulfilled()
	{
		throw new NotImplementedException();
	}
}
