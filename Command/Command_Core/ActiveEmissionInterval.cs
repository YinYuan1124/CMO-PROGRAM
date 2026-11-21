using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ActiveEmissionInterval
{
	public Dictionary<Alertlevels, ActiveEmissionInterval_Config> Configs;

	private ActiveUnit_Sensory m_FilterVal;

	private ActiveUnit m_TestsVal;

	public float TargetInterval;

	public DateTime LastIntervalTimeStamp;

	public DateTime SleepModeTimeStamp;

	public bool IsInEmissionPhase;

	private bool _InterpreterVal;

	private bool _ContainerVal;

	public bool InheritParentGroupConfig
	{
		get
		{
			return _ContainerVal;
		}
		set
		{
			_ContainerVal = value;
		}
	}

	public bool UseCustomPresetOnly
	{
		get
		{
			if (InheritParentGroupConfig)
			{
				return false;
			}
			return _InterpreterVal;
		}
		set
		{
			_InterpreterVal = value;
		}
	}

	public ActiveEmissionInterval()
	{
		Configs = new Dictionary<Alertlevels, ActiveEmissionInterval_Config>();
	}

	public ActiveEmissionInterval(ActiveUnit_Sensory activeUnit_Sensory_0)
	{
		Configs = new Dictionary<Alertlevels, ActiveEmissionInterval_Config>();
		Initialize(activeUnit_Sensory_0);
	}

	public void Initialize(ActiveUnit_Sensory activeUnit_Sensory_0, bool bool_0 = false)
	{
		if (activeUnit_Sensory_0 != null)
		{
			m_FilterVal = activeUnit_Sensory_0;
			m_TestsVal = m_FilterVal.ResolveDic();
		}
		if (bool_0)
		{
			Configs.Clear();
		}
		if (!Configs.ContainsKey(Alertlevels.Green))
		{
			Configs.Add(Alertlevels.Green, new ActiveEmissionInterval_Config(Alertlevels.Green));
		}
		if (!Configs.ContainsKey(Alertlevels.Blue))
		{
			Configs.Add(Alertlevels.Blue, new ActiveEmissionInterval_Config(Alertlevels.Blue));
		}
		if (!Configs.ContainsKey(Alertlevels.Yellow))
		{
			Configs.Add(Alertlevels.Yellow, new ActiveEmissionInterval_Config(Alertlevels.Yellow));
		}
		if (!Configs.ContainsKey(Alertlevels.Orange))
		{
			Configs.Add(Alertlevels.Orange, new ActiveEmissionInterval_Config(Alertlevels.Orange));
		}
		if (!Configs.ContainsKey(Alertlevels.Red))
		{
			Configs.Add(Alertlevels.Red, new ActiveEmissionInterval_Config(Alertlevels.Red));
		}
		if (!Configs.ContainsKey(Alertlevels.Custom))
		{
			Configs.Add(Alertlevels.Custom, new ActiveEmissionInterval_Config(Alertlevels.Custom));
		}
	}

	public void PasteConfig(Alertlevels alertlevels_0, ActiveEmissionInterval activeEmissionInterval_0)
	{
		Configs[alertlevels_0].EmissionDuration = activeEmissionInterval_0.Configs[alertlevels_0].EmissionDuration;
		Configs[alertlevels_0].EmissionInterval = activeEmissionInterval_0.Configs[alertlevels_0].EmissionInterval;
		Configs[alertlevels_0].EmissionIntervalVariation = activeEmissionInterval_0.Configs[alertlevels_0].EmissionIntervalVariation;
		Configs[alertlevels_0].FollowWRAforWakeBehavior = activeEmissionInterval_0.Configs[alertlevels_0].FollowWRAforWakeBehavior;
		Configs[alertlevels_0].SleepModeDelay = activeEmissionInterval_0.Configs[alertlevels_0].SleepModeDelay;
		Configs[alertlevels_0].WakeWhenDetectingThreat = activeEmissionInterval_0.Configs[alertlevels_0].WakeWhenDetectingThreat;
		Configs[alertlevels_0].UseEmissionInterval = activeEmissionInterval_0.Configs[alertlevels_0].UseEmissionInterval;
		Array values = Enum.GetValues(typeof(Misc.PostureStance));
		Array values2 = Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
		IEnumerator enumerator = null;
		try
		{
			enumerator = values2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
				Configs[alertlevels_0].Wake_IncludesContactID[(Contact_Base.IdentificationStatus)Conversions.ToShort(objectValue)] = activeEmissionInterval_0.Configs[alertlevels_0].Wake_IncludesContactID[(Contact_Base.IdentificationStatus)Conversions.ToShort(objectValue)];
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = values.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(enumerator2.Current);
				Configs[alertlevels_0].Wake_IncludesContactStance[(Misc.PostureStance)Conversions.ToByte(objectValue2)] = activeEmissionInterval_0.Configs[alertlevels_0].Wake_IncludesContactStance[(Misc.PostureStance)Conversions.ToByte(objectValue2)];
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
	}

	public void Tick()
	{
		if (InheritParentGroupConfig && m_TestsVal.GetParentGroup() != null)
		{
			m_TestsVal.GetParentGroup().Sensory.InterruptConsumer().Tick();
			return;
		}
		ActiveEmissionInterval_Config activeEmissionInterval_Config = ResetIssuer();
		if (MapIssuer())
		{
			if (activeEmissionInterval_Config.EmissionDuration == 0f)
			{
				IsInEmissionPhase = false;
			}
			else if (activeEmissionInterval_Config.EmissionInterval + activeEmissionInterval_Config.EmissionIntervalVariation == 0f)
			{
				IsInEmissionPhase = true;
			}
			else
			{
				CreateNewInterval(!IsInEmissionPhase);
			}
		}
	}

	internal bool AwakeIssuer()
	{
		if (ResetIssuer().UseEmissionInterval)
		{
			Tick();
			if (InheritParentGroupConfig && m_TestsVal.GetParentGroup() != null)
			{
				return m_TestsVal.GetParentGroup().Sensory.InterruptConsumer().IsInEmissionPhase;
			}
			if (IsInEmissionPhase)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public void CreateNewInterval(bool bool_0)
	{
		LastIntervalTimeStamp = m_TestsVal.ParentScen.Time;
		IsInEmissionPhase = bool_0;
		TargetInterval = QueryIssuer();
	}

	internal float QueryIssuer()
	{
		if (IsInEmissionPhase)
		{
			return ResetIssuer().EmissionDuration;
		}
		return ResetIssuer().EmissionInterval + Conversion.Int((ResetIssuer().EmissionIntervalVariation - 0f + 1f) * VBMath.Rnd() + 0f);
	}

	internal ActiveEmissionInterval_Config ResetIssuer()
	{
		if (InheritParentGroupConfig && m_TestsVal.GetParentGroup() != null)
		{
			Alertlevels key = (UseCustomPresetOnly ? Alertlevels.Custom : CalcIssuer());
			return m_TestsVal.GetParentGroup().Sensory.InterruptConsumer().Configs[key];
		}
		if (UseCustomPresetOnly)
		{
			return Configs[Alertlevels.Custom];
		}
		return Configs[CalcIssuer()];
	}

	private bool MapIssuer()
	{
		DateTime t = LastIntervalTimeStamp.AddSeconds(TargetInterval);
		if (DateTime.Compare(m_TestsVal.ParentScen.Time, t) <= 0)
		{
			return false;
		}
		return true;
	}

	internal double SortIssuer(bool bool_0 = false)
	{
		if (InheritParentGroupConfig && !bool_0 && m_TestsVal.GetParentGroup() != null)
		{
			return m_TestsVal.GetParentGroup().Sensory.InterruptConsumer().SortIssuer(bool_0: true);
		}
		return Math.Min((m_TestsVal.ParentScen.Time - LastIntervalTimeStamp.AddSeconds(TargetInterval)).TotalSeconds, 0.0);
	}

	private Alertlevels CalcIssuer()
	{
		return m_TestsVal.GetUnitSide().EmconAlertness.Level;
	}

	public void ToggleEmissionMode(ActiveEmissionInterval_Config activeEmissionInterval_Config_0 = null)
	{
		if (activeEmissionInterval_Config_0 == null)
		{
			activeEmissionInterval_Config_0 = ResetIssuer();
		}
		if (activeEmissionInterval_Config_0.UseEmissionInterval)
		{
			SwitchToContinuous(activeEmissionInterval_Config_0);
		}
		else
		{
			SwitchToIntermittent(activeEmissionInterval_Config_0);
		}
	}

	public void SwitchToContinuous(ActiveEmissionInterval_Config activeEmissionInterval_Config_0 = null)
	{
		if (activeEmissionInterval_Config_0 == null)
		{
			activeEmissionInterval_Config_0 = ResetIssuer();
		}
		activeEmissionInterval_Config_0.UseEmissionInterval = false;
	}

	public void SwitchToIntermittent(ActiveEmissionInterval_Config activeEmissionInterval_Config_0 = null)
	{
		if (activeEmissionInterval_Config_0 == null)
		{
			activeEmissionInterval_Config_0 = ResetIssuer();
		}
		activeEmissionInterval_Config_0.UseEmissionInterval = true;
		Wake();
	}

	public void ToggleSleep_Wake()
	{
		if (IsInEmissionPhase)
		{
			CreateNewInterval(bool_0: false);
		}
		else
		{
			CreateNewInterval(bool_0: true);
		}
	}

	public void Wake(float float_0 = 0f)
	{
		CreateNewInterval(bool_0: true);
		if (float_0 != 0f)
		{
			TargetInterval = float_0;
		}
	}

	public void Sleep()
	{
		CreateNewInterval(bool_0: false);
	}

	internal bool RateIssuer(Contact contact_0)
	{
		if (ResetIssuer().Wake_IncludesContactID[contact_0.IDStatus] && ResetIssuer().Wake_IncludesContactStance[contact_0.GetStance(m_TestsVal.GetUnitSide())])
		{
			return true;
		}
		return false;
	}

	public void AttemptToWake_WithDetection(Contact contact_0)
	{
		ActiveEmissionInterval_Config activeEmissionInterval_Config = ResetIssuer();
		if (!activeEmissionInterval_Config.WakeWhenDetectingThreat)
		{
			return;
		}
		if (IsInEmissionPhase)
		{
			if (RateIssuer(contact_0))
			{
				LastIntervalTimeStamp = m_TestsVal.ParentScen.Time;
			}
		}
		else
		{
			Wake(activeEmissionInterval_Config.SleepModeDelay);
		}
	}

	public void AttemptToWake_WithDetection(List<Contact> list_0)
	{
		if (!ResetIssuer().WakeWhenDetectingThreat || !IsInEmissionPhase)
		{
			return;
		}
		foreach (Contact item in list_0)
		{
			if (item.GetStance(m_TestsVal.GetUnitSide()) != Misc.PostureStance.Friendly && IsInEmissionPhase)
			{
				LastIntervalTimeStamp = m_TestsVal.ParentScen.Time;
			}
		}
	}

	public void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EmissionInterval");
			if (TargetInterval != 0f)
			{
				xmlWriter_0.WriteElementString("TargetInterval", TargetInterval.ToString());
			}
			if (LastIntervalTimeStamp.Ticks != 0)
			{
				xmlWriter_0.WriteElementString("LastIntervalTimeStamp", Conversions.ToString(LastIntervalTimeStamp.ToBinary()));
			}
			if (SleepModeTimeStamp.Ticks != 0)
			{
				xmlWriter_0.WriteElementString("SleepModeTimeStamp", Conversions.ToString(SleepModeTimeStamp.ToBinary()));
			}
			if (IsInEmissionPhase)
			{
				xmlWriter_0.WriteElementString("IsInEmissionPhase", IsInEmissionPhase.ToString());
			}
			if (UseCustomPresetOnly)
			{
				xmlWriter_0.WriteElementString("UseCustomPresetOnly", UseCustomPresetOnly.ToString());
			}
			if (InheritParentGroupConfig)
			{
				xmlWriter_0.WriteElementString("InheritParentGroupConfig", InheritParentGroupConfig.ToString());
			}
			xmlWriter_0.WriteStartElement("DECON");
			foreach (ActiveEmissionInterval_Config value in Configs.Values)
			{
				xmlWriter_0.WriteStartElement("Defcon_" + value.Defcon);
				xmlWriter_0.WriteElementString("UseEmissionInterval", value.UseEmissionInterval.ToString());
				xmlWriter_0.WriteElementString("WakeWhenDetectingThreat", value.WakeWhenDetectingThreat.ToString());
				if (value.SleepModeDelay != 0f)
				{
					xmlWriter_0.WriteElementString("SleepModeDelay", XmlConvert.ToString(value.SleepModeDelay));
				}
				if (value.EmissionInterval != 0f)
				{
					xmlWriter_0.WriteElementString("EmissionInterval", XmlConvert.ToString(value.EmissionInterval));
				}
				if (value.UseEmissionInterval)
				{
					xmlWriter_0.WriteElementString("UseEmissionInterval", value.UseEmissionInterval.ToString());
				}
				if (value.EmissionDuration != 0f)
				{
					xmlWriter_0.WriteElementString("EmissionDuration", XmlConvert.ToString(value.EmissionDuration));
				}
				if (value.EmissionIntervalVariation != 0f)
				{
					xmlWriter_0.WriteElementString("EmissionIntervalVariation", XmlConvert.ToString(value.EmissionIntervalVariation));
				}
				string text = "";
				foreach (KeyValuePair<Misc.PostureStance, bool> item in value.Wake_IncludesContactStance)
				{
					if (item.Value)
					{
						text = text + item.Key.ToString() + ",";
					}
				}
				xmlWriter_0.WriteElementString("Wake_IncludesContactStance", text);
				text = "";
				foreach (KeyValuePair<Contact_Base.IdentificationStatus, bool> item2 in value.Wake_IncludesContactID)
				{
					if (item2.Value)
					{
						text = text + item2.Key.ToString() + ",";
					}
				}
				xmlWriter_0.WriteElementString("Wake_IncludesContactID", text);
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101003b", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveEmissionInterval FromXML(ref XmlNode xmlNode_0)
	{
		checked
		{
			try
			{
				ActiveEmissionInterval activeEmissionInterval = new ActiveEmissionInterval();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					IEnumerator enumerator3 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						switch (xmlNode.Name)
						{
						case "UseCustomPresetOnly":
							activeEmissionInterval.UseCustomPresetOnly = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "SleepModeTimeStamp":
							try
							{
								activeEmissionInterval.SleepModeTimeStamp = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								activeEmissionInterval.SleepModeTimeStamp = DateTime.Parse(xmlNode.InnerText);
								ProjectData.ClearProjectError();
							}
							break;
						case "LastIntervalTimeStamp":
							try
							{
								activeEmissionInterval.LastIntervalTimeStamp = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								activeEmissionInterval.LastIntervalTimeStamp = DateTime.Parse(xmlNode.InnerText);
								ProjectData.ClearProjectError();
							}
							break;
						case "TargetInterval":
							activeEmissionInterval.TargetInterval = Conversions.ToSingle(xmlNode.InnerText);
							break;
						case "InheritParentGroupConfig":
							activeEmissionInterval.InheritParentGroupConfig = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "IsInEmissionPhase":
							activeEmissionInterval.IsInEmissionPhase = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "DECON":
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
									Alertlevels alertEnumWithString = EmconLevel.GetAlertEnumWithString(xmlNode2.Name.Split('_')[1]);
									ActiveEmissionInterval_Config activeEmissionInterval_Config = new ActiveEmissionInterval_Config(alertEnumWithString, bool_0: false);
									try
									{
										enumerator3 = xmlNode2.ChildNodes.GetEnumerator();
										while (enumerator3.MoveNext())
										{
											XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
											switch (xmlNode3.Name)
											{
											case "SleepModeDelay":
												activeEmissionInterval_Config.SleepModeDelay = Conversions.ToSingle(xmlNode3.InnerText);
												break;
											case "WakeWhenDetectingThreat":
												activeEmissionInterval_Config.WakeWhenDetectingThreat = Conversions.ToBoolean(xmlNode3.InnerText);
												break;
											case "FollowWRAforWakeBehavior":
												activeEmissionInterval_Config.FollowWRAforWakeBehavior = Conversions.ToBoolean(xmlNode3.InnerText);
												break;
											case "Wake_IncludesContactID":
											{
												string[] array2 = xmlNode3.InnerText.Split(',');
												for (int j = 0; j < array2.Length; j++)
												{
													switch (array2[j])
													{
													case "Unknown":
														activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = true;
														break;
													case "PreciseID":
														activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = true;
														break;
													case "KnownType":
														activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = true;
														break;
													case "KnownDomain":
														activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = true;
														break;
													case "KnownClass":
														activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = true;
														break;
													}
												}
												break;
											}
											case "UseEmissionInterval":
												activeEmissionInterval_Config.UseEmissionInterval = Conversions.ToBoolean(xmlNode3.InnerText);
												break;
											case "EmissionInterval":
												activeEmissionInterval_Config.EmissionInterval = Conversions.ToSingle(xmlNode3.InnerText);
												break;
											case "EmissionIntervalVariation":
												activeEmissionInterval_Config.EmissionIntervalVariation = Conversions.ToSingle(xmlNode3.InnerText);
												break;
											case "Wake_IncludesContactStance":
											{
												string[] array = xmlNode3.InnerText.Split(',');
												for (int i = 0; i < array.Length; i++)
												{
													switch (array[i])
													{
													case "Unknown":
														activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Unknown] = true;
														break;
													case "Unfriendly":
														activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = true;
														break;
													case "Neutral":
														activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Neutral] = true;
														break;
													case "Hostile":
														activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Hostile] = true;
														break;
													case "Friendly":
														activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Friendly] = true;
														break;
													}
												}
												break;
											}
											case "EmissionDuration":
												activeEmissionInterval_Config.EmissionDuration = Conversions.ToSingle(xmlNode3.InnerText);
												break;
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
									if (!activeEmissionInterval.Configs.ContainsKey(alertEnumWithString))
									{
										activeEmissionInterval.Configs.Add(alertEnumWithString, activeEmissionInterval_Config);
									}
								}
							}
							finally
							{
								if (enumerator2 is IDisposable)
								{
									(enumerator2 as IDisposable).Dispose();
								}
							}
							activeEmissionInterval.Initialize(null);
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
				return activeEmissionInterval;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101004b", "");
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
}
