using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CargoFilterObject : ScenarioObject
{
	public CargoType cargoType;

	public Cargo.CargoObjectType SpecificObjectType;

	public int SpecificCargoDBID;

	public string SpecificCargoObjID;

	public int ThresholdReceived;

	public int ThresholdSent;

	public int Received;

	public int Sent;

	public CargoFilterObject()
	{
		ThresholdReceived = 0;
		ThresholdSent = 0;
		Received = 0;
		Sent = 0;
		SpecificObjectType = Cargo.CargoObjectType.Mount;
	}

	public void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteElementString("ID", ObjectID);
			int num = (int)cargoType;
			xmlWriter_0.WriteElementString("TargetType", num.ToString());
			if (SpecificCargoDBID != 0)
			{
				num = (int)SpecificObjectType;
				xmlWriter_0.WriteElementString("SpecificObjectType", num.ToString());
				xmlWriter_0.WriteElementString("SpecificUnitClass", SpecificCargoDBID.ToString());
			}
			if (!string.IsNullOrEmpty(SpecificCargoObjID))
			{
				xmlWriter_0.WriteElementString("SpecificUnitID", SpecificCargoObjID);
			}
			xmlWriter_0.WriteElementString("TargetLimitReceived", ThresholdReceived.ToString());
			xmlWriter_0.WriteElementString("TargetLimitSent", ThresholdSent.ToString());
			xmlWriter_0.WriteElementString("TargetReceived", Received.ToString());
			xmlWriter_0.WriteElementString("TargetSent", Sent.ToString());
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

	public static CargoFilterObject FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			CargoFilterObject cargoFilterObject = new CargoFilterObject();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ID":
						cargoFilterObject.ObjectID_Set(xmlNode.InnerText);
						break;
					case "TargetSent":
						cargoFilterObject.Sent = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "SpecificUnitClass":
						cargoFilterObject.SpecificCargoDBID = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "TargetLimitReceived":
						cargoFilterObject.ThresholdReceived = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "TargetType":
						cargoFilterObject.cargoType = (CargoType)Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "TargetReceived":
						cargoFilterObject.Received = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "TargetLimitSent":
						cargoFilterObject.ThresholdSent = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "SpecificUnitID":
						cargoFilterObject.SpecificCargoObjID = xmlNode.InnerText;
						if (xmlNode.HasChildNodes)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[0];
							ActiveUnit activeUnit = ActiveUnit.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref scenario_0);
							if (activeUnit != null)
							{
								cargoFilterObject.SpecificCargoObjID = activeUnit.ObjectID;
							}
						}
						break;
					case "SpecificObjectType":
						cargoFilterObject.SpecificObjectType = (Cargo.CargoObjectType)Conversions.ToInteger(xmlNode.InnerText);
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
			return cargoFilterObject;
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
			CargoFilterObject result = new CargoFilterObject();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public bool MatchesThisCargo(Cargo cargo_0)
	{
		if (cargo_0.CurrentType == SpecificObjectType)
		{
			if (cargo_0.RequiredCargoType == cargoType)
			{
				if (SpecificCargoDBID == 0)
				{
					return true;
				}
				if (cargo_0.CargoObjectDBID == SpecificCargoDBID)
				{
					if (string.IsNullOrEmpty(SpecificCargoObjID))
					{
						return true;
					}
					if (Operators.CompareString(SpecificCargoObjID, cargo_0.CargoObjectID, TextCompare: false) == 0)
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

	public CargoFilterObject Clone()
	{
		return (CargoFilterObject)MemberwiseClone();
	}
}
