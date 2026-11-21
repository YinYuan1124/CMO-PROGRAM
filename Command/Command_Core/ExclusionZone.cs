using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ExclusionZone : Zone
{
	public Dictionary<string, Misc.PostureStance> ViolatorsStance;

	public Misc.PostureStance MarkViolatorAs;

	[ThreadStatic]
	private static StringBuilder m_UtilsClient;

	public override ZoneType Type => ZoneType.ExclusionZone;

	public ExclusionZone(string string_0, Side side_0, List<ReferencePoint> list_0, Misc.PostureStance postureStance_0, List<GlobalVariables.ActiveUnitType> list_1 = null)
	{
		ViolatorsStance = new Dictionary<string, Misc.PostureStance>();
		Description = string_0;
		Area = list_0;
		MarkViolatorAs = postureStance_0;
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
		string string_ = null;
		if (!ActiveUnit_Navigator.ValidateArea(ref list_0, ref string_, side_0, null, "封锁区 '" + Description + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
	}

	public new static void TransformTo(Zone zone_0, Side side_0, Scenario scenario_0)
	{
		if (zone_0 != null)
		{
			side_0.ExclusionZones.Add(new ExclusionZone(zone_0.Description, side_0, zone_0.Area, Misc.PostureStance.Hostile));
			side_0.StandardZones.Remove(zone_0);
		}
	}

	public new static void TransformTo(NoNavZone noNavZone_0, Side side_0, Scenario scenario_0)
	{
		if (noNavZone_0 != null)
		{
			side_0.ExclusionZones.Add(new ExclusionZone(noNavZone_0.Description, side_0, noNavZone_0.Area, Misc.PostureStance.Hostile));
			side_0.NoNavZones.Remove(noNavZone_0);
		}
	}

	public new static void TransformTo(CustomEnvironmentZone customEnvironmentZone_0, Side side_0, Scenario scenario_0)
	{
		if (customEnvironmentZone_0 != null)
		{
			side_0.ExclusionZones.Add(new ExclusionZone(customEnvironmentZone_0.Description, side_0, customEnvironmentZone_0.Area, Misc.PostureStance.Hostile));
			scenario_0.GetNatureSide().CustomEnvironmentZones.Remove(customEnvironmentZone_0);
		}
	}

	private ExclusionZone()
	{
		ViolatorsStance = new Dictionary<string, Misc.PostureStance>();
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			if (m_UtilsClient == null)
			{
				m_UtilsClient = new StringBuilder();
			}
			else
			{
				m_UtilsClient.Clear();
			}
			xmlWriter_0.WriteStartElement("ExclusionZone");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("ViolatorsStance");
			foreach (KeyValuePair<string, Misc.PostureStance> item2 in ViolatorsStance)
			{
				m_UtilsClient.Append("<VStance>");
				m_UtilsClient.Append("<ID>").Append(item2.Key).Append("</ID>");
				m_UtilsClient.Append("<Stance>").Append(((int)item2.Value).ToString()).Append("</Stance>");
				m_UtilsClient.Append("</VStance>");
			}
			xmlWriter_0.WriteRaw(m_UtilsClient.ToString());
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("AffectedUnitTypes", string.Join("_", AffectedUnitTypes.Select(delegate(GlobalVariables.ActiveUnitType theType)
			{
				int num = (int)theType;
				return num.ToString();
			})));
			XmlWriter obj = xmlWriter_0;
			byte markViolatorAs = (byte)MarkViolatorAs;
			obj.WriteElementString("MarkViolatorAs", markViolatorAs.ToString());
			xmlWriter_0.WriteElementString("IsActive", IsActive.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100991", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static ExclusionZone FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			ExclusionZone exclusionZone = new ExclusionZone();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				string key = null;
				Misc.PostureStance value = Misc.PostureStance.Neutral;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "AffectedUnitTypes":
					{
						exclusionZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
						string[] array = xmlNode.InnerText.Split('_');
						string[] array2 = array;
						foreach (string text in array2)
						{
							if (Versioned.IsNumeric(text))
							{
								int num = Conversions.ToInteger(text);
								exclusionZone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
							}
						}
						break;
					}
					case "MarkViolatorAs":
						exclusionZone.MarkViolatorAs = (Misc.PostureStance)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								exclusionZone.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
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
						exclusionZone.Description = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							exclusionZone.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(exclusionZone.ObjectID, exclusionZone);
							break;
						}
						return (ExclusionZone)concurrentDictionary_0[xmlNode.InnerText];
					case "ViolatorsStance":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator3.Current;
								if (Operators.CompareString(xmlNode2.Name, "VStance", TextCompare: false) == 0)
								{
									try
									{
										enumerator4 = xmlNode2.ChildNodes.GetEnumerator();
										while (enumerator4.MoveNext())
										{
											XmlNode xmlNode3 = (XmlNode)enumerator4.Current;
											string name = xmlNode3.Name;
											if (Operators.CompareString(name, "ID", TextCompare: false) == 0)
											{
												key = xmlNode3.InnerText;
											}
											else if (Operators.CompareString(name, "Stance", TextCompare: false) == 0)
											{
												value = (Misc.PostureStance)Conversions.ToByte(xmlNode3.InnerText);
											}
										}
									}
									finally
									{
										if (enumerator4 is IDisposable)
										{
											(enumerator4 as IDisposable).Dispose();
										}
									}
								}
								try
								{
									exclusionZone.ViolatorsStance.Add(key, value);
								}
								catch (Exception ex)
								{
									ProjectData.SetProjectError(ex);
									Exception exception_ = ex;
									exception_?.Data.Add("Error at 10200992", "");
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
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					case "IsActive":
						exclusionZone.IsActive = Conversions.ToBoolean(xmlNode.InnerText);
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
			if (Information.IsNothing(exclusionZone.AffectedUnitTypes))
			{
				exclusionZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			return exclusionZone;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100992", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ExclusionZone result = new ExclusionZone();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
