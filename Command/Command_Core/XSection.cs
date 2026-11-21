using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class XSection
{
	public enum _SignatureType : short
	{
		HullSonar_PassiveOnly_VLF = 1001,
		HullSonar_PassiveOnly_LF = 1002,
		HullSonar_PassiveOnly_MF = 1003,
		HullSonar_PassiveOnly_HF = 1004,
		ActiveSonar = 2001,
		Visual_Detect = 3001,
		Visual_ID = 3002,
		IR_Detect = 4001,
		IR_ID = 4002,
		Radar_A_D = 5001,
		Radar_E_M = 5002
	}

	public enum SignatureAspect : short
	{
		Front,
		Side,
		Rear
	}

	private float m_ResolverReader;

	private float publisherReader;

	private float _ServerReader;

	private float m_AdapterReader;

	public _SignatureType SignatureType;

	private Weapon m_SchemaReader;

	private Weapon _UtilsReader;

	public void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("XSection");
			xmlWriter_0.WriteElementString("Front", XmlConvert.ToString(m_ResolverReader));
			xmlWriter_0.WriteElementString("Side", XmlConvert.ToString(publisherReader));
			xmlWriter_0.WriteElementString("Rear", XmlConvert.ToString(_ServerReader));
			xmlWriter_0.WriteElementString("Top", XmlConvert.ToString(m_AdapterReader));
			XmlWriter obj = xmlWriter_0;
			int signatureType = (int)SignatureType;
			obj.WriteElementString("Type", signatureType.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101079", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static XSection FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			XSection xSection = new XSection();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Top":
						xSection.m_AdapterReader = XmlConvert.ToInt32(xmlNode.InnerText.Replace(",", "."));
						break;
					case "SignatureType":
					case "Type":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							xSection.SignatureType = (_SignatureType)Conversions.ToShort(xmlNode.InnerText);
						}
						else
						{
							xSection.SignatureType = (_SignatureType)Enum.Parse(typeof(_SignatureType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "Side":
						xSection.publisherReader = XmlConvert.ToInt32(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Rear":
						xSection._ServerReader = XmlConvert.ToInt32(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Front":
						xSection.m_ResolverReader = XmlConvert.ToInt32(xmlNode.InnerText.Replace(",", "."));
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
			return xSection;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101080", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			XSection result = new XSection();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public float GetFront(ActiveUnit activeUnit_0)
	{
		try
		{
			if (!activeUnit_0.IsSubmarine)
			{
				if (!activeUnit_0.IsAircraft)
				{
					if (activeUnit_0.IsMissile)
					{
						switch (SignatureType)
						{
						case _SignatureType.Visual_Detect:
						case _SignatureType.IR_Detect:
						{
							float num;
							if (activeUnit_0.Propulsion[0].Type == Engine.EngineType.Rocket_BoostCoast)
							{
								Weapon weapon = (Weapon)activeUnit_0;
								num = ((weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime) ? ((float)((double)_ServerReader * 0.5)) : m_ResolverReader);
							}
							else
							{
								num = m_ResolverReader;
							}
							if (((Weapon)activeUnit_0).IsHGV && num == 0f)
							{
								num = 20f;
							}
							return num;
						}
						default:
							return m_ResolverReader;
						case _SignatureType.Radar_E_M:
							if (((Weapon)activeUnit_0).IsHGV && m_ResolverReader == 0f)
							{
								m_ResolverReader = 5.5f;
							}
							return m_ResolverReader;
						case _SignatureType.Radar_A_D:
							if (((Weapon)activeUnit_0).IsHGV && m_ResolverReader == 0f)
							{
								m_ResolverReader = 6.5f;
							}
							return m_ResolverReader;
						}
					}
					if ((object)activeUnit_0.GetType() == typeof(UnguidedRocket))
					{
						switch (SignatureType)
						{
						case _SignatureType.IR_Detect:
						{
							m_ResolverReader = 0.77f;
							float maxRange_NoTargetType = ((Weapon)activeUnit_0).MaxRange_NoTargetType;
							float num2 = (((double)Module_Unit.RangeToPoint_Horiz(activeUnit_0, ((Weapon)activeUnit_0).LaunchPoint) < (double)maxRange_NoTargetType * 0.3) ? ((float)((double)GetRear(activeUnit_0) * 0.5)) : m_ResolverReader);
							double num3 = Physics.CompareStub(activeUnit_0.GetCurrentAltitude(), activeUnit_0.CurrentSpeed);
							if (num3 > 1.0)
							{
								num2 = (float)((double)num2 * Math.Sqrt(num3));
							}
							return num2;
						}
						case _SignatureType.Visual_ID:
							return 0.38f;
						case _SignatureType.Visual_Detect:
						{
							m_ResolverReader = 2f;
							float maxRange_NoTargetType2 = ((Weapon)activeUnit_0).MaxRange_NoTargetType;
							if ((double)Module_Unit.RangeToPoint_Horiz(activeUnit_0, ((Weapon)activeUnit_0).LaunchPoint) < (double)maxRange_NoTargetType2 * 0.3)
							{
								return (float)((double)GetRear(activeUnit_0) * 0.5);
							}
							return m_ResolverReader;
						}
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return m_ResolverReader;
						case _SignatureType.Radar_E_M:
							return -14.6f;
						case _SignatureType.Radar_A_D:
							return -14.6f;
						case _SignatureType.IR_ID:
							return 0.38f;
						}
					}
					return m_ResolverReader;
				}
				switch (SignatureType)
				{
				default:
					return m_ResolverReader;
				case _SignatureType.Radar_A_D:
				case _SignatureType.Radar_E_M:
					return AwakeDescriptor((Aircraft)activeUnit_0, m_ResolverReader, SignatureType, SignatureAspect.Front);
				case _SignatureType.IR_Detect:
				{
					double num4 = Physics.CompareStub(activeUnit_0.GetCurrentAltitude(), activeUnit_0.CurrentSpeed);
					if (num4 <= 1.0)
					{
						return m_ResolverReader;
					}
					return (float)((double)m_ResolverReader * Math.Sqrt(num4));
				}
				}
			}
			Submarine submarine = (Submarine)activeUnit_0;
			if (submarine.IsSurfaced)
			{
				return m_ResolverReader;
			}
			if (submarine.IsAtPeriscopeDepth)
			{
				if (activeUnit_0.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
				{
					switch (SignatureType)
					{
					default:
						return m_ResolverReader;
					case _SignatureType.Radar_A_D:
					case _SignatureType.Radar_E_M:
						return -20f;
					case _SignatureType.IR_Detect:
					case _SignatureType.IR_ID:
						return 2f;
					case _SignatureType.Visual_Detect:
					case _SignatureType.Visual_ID:
						return 2f;
					}
				}
				switch (SignatureType)
				{
				default:
					return m_ResolverReader;
				case _SignatureType.Radar_A_D:
				case _SignatureType.Radar_E_M:
					return -30f;
				case _SignatureType.IR_Detect:
				case _SignatureType.IR_ID:
					return 2f;
				case _SignatureType.Visual_Detect:
				case _SignatureType.Visual_ID:
					return 2f;
				}
			}
			return m_ResolverReader;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101288", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float resolverReader = m_ResolverReader;
			ProjectData.ClearProjectError();
			return resolverReader;
		}
	}

	[SpecialName]
	public float GetSide(ActiveUnit activeUnit_0)
	{
		try
		{
			if (activeUnit_0.IsSubmarine)
			{
				if (((Submarine)activeUnit_0).IsSurfaced)
				{
					return publisherReader;
				}
				if (((Submarine)activeUnit_0).IsAtPeriscopeDepth)
				{
					switch (SignatureType)
					{
					default:
						return publisherReader;
					case _SignatureType.Radar_A_D:
					case _SignatureType.Radar_E_M:
						return -30f;
					case _SignatureType.IR_Detect:
					case _SignatureType.IR_ID:
						return 2f;
					case _SignatureType.Visual_Detect:
					case _SignatureType.Visual_ID:
						return 2f;
					}
				}
				return publisherReader;
			}
			if (!activeUnit_0.IsAircraft)
			{
				if (activeUnit_0.IsMissile)
				{
					switch (SignatureType)
					{
					case _SignatureType.Visual_ID:
						return 1.01f;
					case _SignatureType.Visual_Detect:
					case _SignatureType.IR_Detect:
					{
						float num;
						if (activeUnit_0.Propulsion[0].Type == Engine.EngineType.Rocket_BoostCoast)
						{
							Weapon weapon = (Weapon)activeUnit_0;
							num = ((weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime) ? ((float)((double)_ServerReader * 0.5)) : publisherReader);
						}
						else
						{
							num = publisherReader;
						}
						if (((Weapon)activeUnit_0).IsHGV && num == 0f)
						{
							num = 20f;
						}
						return num;
					}
					default:
						return publisherReader;
					case _SignatureType.Radar_E_M:
						if (((Weapon)activeUnit_0).IsHGV && publisherReader == 0f)
						{
							publisherReader = 5.5f;
						}
						return publisherReader;
					case _SignatureType.Radar_A_D:
						if (((Weapon)activeUnit_0).IsHGV && publisherReader == 0f)
						{
							publisherReader = 6.5f;
						}
						return publisherReader;
					case _SignatureType.IR_ID:
						return 1.01f;
					}
				}
				if ((object)activeUnit_0.GetType() == typeof(UnguidedRocket))
				{
					switch (SignatureType)
					{
					case _SignatureType.IR_Detect:
					{
						publisherReader = 4.43f;
						float maxRange_NoTargetType = ((Weapon)activeUnit_0).MaxRange_NoTargetType;
						float num2 = (((double)Module_Unit.RangeToPoint_Horiz(activeUnit_0, ((Weapon)activeUnit_0).LaunchPoint) < (double)maxRange_NoTargetType * 0.3) ? ((float)((double)GetRear(activeUnit_0) * 0.75)) : publisherReader);
						double num3 = Physics.CompareStub(activeUnit_0.GetCurrentAltitude(), activeUnit_0.CurrentSpeed);
						if (num3 > 1.0)
						{
							num2 = (float)((double)num2 * Math.Sqrt(num3));
						}
						return num2;
					}
					case _SignatureType.Visual_ID:
						return 1.01f;
					case _SignatureType.Visual_Detect:
					{
						publisherReader = 5.59f;
						float maxRange_NoTargetType2 = ((Weapon)activeUnit_0).MaxRange_NoTargetType;
						if ((double)Module_Unit.RangeToPoint_Horiz(activeUnit_0, ((Weapon)activeUnit_0).LaunchPoint) < (double)maxRange_NoTargetType2 * 0.3)
						{
							return (float)((double)GetRear(activeUnit_0) * 0.75);
						}
						return publisherReader;
					}
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return publisherReader;
					case _SignatureType.Radar_E_M:
						return -11.5f;
					case _SignatureType.Radar_A_D:
						return -11.5f;
					case _SignatureType.IR_ID:
						return 1.01f;
					}
				}
				return publisherReader;
			}
			switch (SignatureType)
			{
			default:
				return publisherReader;
			case _SignatureType.Radar_A_D:
			case _SignatureType.Radar_E_M:
				return AwakeDescriptor((Aircraft)activeUnit_0, publisherReader, SignatureType, SignatureAspect.Side);
			case _SignatureType.IR_Detect:
			{
				float num4 = publisherReader;
				double num5 = Physics.CompareStub(activeUnit_0.GetCurrentAltitude(), activeUnit_0.CurrentSpeed);
				if (num5 < 1.0)
				{
					num5 = 1.0;
				}
				ActiveUnit.Throttle throttleSetting = activeUnit_0.ThrottleSetting;
				if (1 == 0)
				{
				}
				float result2 = throttleSetting switch
				{
					ActiveUnit.Throttle.FullStop => (float)((double)num4 * num5 * 1.5), 
					ActiveUnit.Throttle.Loiter => (float)((double)num4 * num5 * 0.85), 
					ActiveUnit.Throttle.Cruise => (float)((double)num4 * num5), 
					ActiveUnit.Throttle.Full => (float)((double)num4 * num5 * 1.2), 
					ActiveUnit.Throttle.Flank => (float)((double)num4 * num5 * 1.5), 
					_ => publisherReader, 
				};
				if (1 == 0)
				{
				}
				return result2;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101289", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float result = publisherReader;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public float GetRear(ActiveUnit activeUnit_0)
	{
		try
		{
			if (activeUnit_0.IsSubmarine)
			{
				if (((Submarine)activeUnit_0).IsSurfaced)
				{
					return _ServerReader;
				}
				if (((Submarine)activeUnit_0).IsAtPeriscopeDepth)
				{
					switch (SignatureType)
					{
					default:
						return _ServerReader;
					case _SignatureType.Radar_A_D:
					case _SignatureType.Radar_E_M:
						return -30f;
					case _SignatureType.IR_Detect:
					case _SignatureType.IR_ID:
						return 2f;
					case _SignatureType.Visual_Detect:
					case _SignatureType.Visual_ID:
						return 2f;
					}
				}
				return _ServerReader;
			}
			if (activeUnit_0.IsAircraft)
			{
				switch (SignatureType)
				{
				default:
					return _ServerReader;
				case _SignatureType.Radar_A_D:
				case _SignatureType.Radar_E_M:
					return AwakeDescriptor((Aircraft)activeUnit_0, _ServerReader, SignatureType, SignatureAspect.Rear);
				case _SignatureType.IR_Detect:
				{
					float serverReader = _ServerReader;
					ActiveUnit.Throttle throttleSetting = activeUnit_0.ThrottleSetting;
					if (1 == 0)
					{
					}
					float result = throttleSetting switch
					{
						ActiveUnit.Throttle.FullStop => (float)((double)serverReader * 1.5), 
						ActiveUnit.Throttle.Loiter => (float)((double)serverReader * 0.85), 
						ActiveUnit.Throttle.Cruise => serverReader, 
						ActiveUnit.Throttle.Full => (float)((double)serverReader * 1.2), 
						ActiveUnit.Throttle.Flank => (float)((double)serverReader * 1.5), 
						_ => _ServerReader, 
					};
					if (1 == 0)
					{
					}
					return result;
				}
				}
			}
			if (activeUnit_0.IsMissile)
			{
				switch (SignatureType)
				{
				case _SignatureType.Visual_Detect:
				case _SignatureType.IR_Detect:
				{
					float num;
					if (activeUnit_0.Propulsion[0].Type == Engine.EngineType.Rocket_BoostCoast)
					{
						Weapon weapon = (Weapon)activeUnit_0;
						num = ((weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime) ? _ServerReader : m_ResolverReader);
					}
					else
					{
						num = _ServerReader;
					}
					if (((Weapon)activeUnit_0).IsHGV && num == 0f)
					{
						num = 20f;
					}
					return num;
				}
				default:
					return _ServerReader;
				case _SignatureType.Radar_E_M:
					if (((Weapon)activeUnit_0).IsHGV && _ServerReader == 0f)
					{
						_ServerReader = 5.5f;
					}
					return _ServerReader;
				case _SignatureType.Radar_A_D:
					if (((Weapon)activeUnit_0).IsHGV && _ServerReader == 0f)
					{
						_ServerReader = 6.5f;
					}
					return _ServerReader;
				}
			}
			if ((object)activeUnit_0.GetType() == typeof(UnguidedRocket))
			{
				switch (SignatureType)
				{
				case _SignatureType.IR_Detect:
				{
					_ServerReader = 9.9f;
					float maxRange_NoTargetType = ((Weapon)activeUnit_0).MaxRange_NoTargetType;
					float num2 = (((double)Module_Unit.RangeToPoint_Horiz(activeUnit_0, ((Weapon)activeUnit_0).LaunchPoint) < (double)maxRange_NoTargetType * 0.3) ? (_ServerReader * 4f) : _ServerReader);
					double num3 = Physics.CompareStub(activeUnit_0.GetCurrentAltitude(), activeUnit_0.CurrentSpeed);
					if (num3 > 1.0)
					{
						num2 = (float)((double)num2 * Math.Sqrt(num3));
					}
					return num2;
				}
				case _SignatureType.Visual_ID:
					return 0.47f;
				case _SignatureType.Visual_Detect:
				{
					_ServerReader = 2f;
					float maxRange_NoTargetType2 = ((Weapon)activeUnit_0).MaxRange_NoTargetType;
					if ((double)Module_Unit.RangeToPoint_Horiz(activeUnit_0, ((Weapon)activeUnit_0).LaunchPoint) < (double)maxRange_NoTargetType2 * 0.3)
					{
						return _ServerReader * 4f;
					}
					return _ServerReader;
				}
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return _ServerReader;
				case _SignatureType.Radar_E_M:
					return -14.6f;
				case _SignatureType.Radar_A_D:
					return -14.6f;
				case _SignatureType.IR_ID:
					return 0.38f;
				}
			}
			return _ServerReader;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101290", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float serverReader2 = _ServerReader;
			ProjectData.ClearProjectError();
			return serverReader2;
		}
	}

	[SpecialName]
	public float GetTop(ActiveUnit activeUnit_0)
	{
		return m_AdapterReader;
	}

	private XSection()
	{
	}

	public XSection(_SignatureType _SignatureType_0, float float_0, float float_1, float float_2, float float_3)
	{
		SignatureType = _SignatureType_0;
		m_ResolverReader = float_0;
		publisherReader = float_1;
		_ServerReader = float_2;
		m_AdapterReader = float_3;
	}

	public bool isDBInvisible(ActiveUnit activeUnit_0)
	{
		if (GetFront(activeUnit_0) != -10000f && GetSide(activeUnit_0) != -10000f && GetRear(activeUnit_0) != -10000f)
		{
			return GetTop(activeUnit_0) == -10000f;
		}
		return true;
	}

	private float AwakeDescriptor(Aircraft aircraft_0, float float_0, _SignatureType _SignatureType_0, SignatureAspect signatureAspect_0)
	{
		RadarModel.TTarget tTarget = new RadarModel.TTarget();
		try
		{
			if (aircraft_0.Loadout == null)
			{
				return float_0;
			}
			tTarget.RCS = float_0;
			float num = (float)tTarget.RCS_m2;
			WeaponRec[] weapons = aircraft_0.Loadout.Weapons;
			float num2 = 0f;
			float num3 = 0f;
			WeaponRec[] array = weapons;
			WeaponRec[] array2 = array;
			foreach (WeaponRec weaponRec in array2)
			{
				if (weaponRec.InternalWeapons)
				{
					continue;
				}
				Weapon weapon = weaponRec.GetReferenceWeapon(aircraft_0.ParentScen);
				if (weapon.IsFuelTank)
				{
					if (m_SchemaReader == null)
					{
						m_SchemaReader = aircraft_0.ParentScen.Cache_GetWeapon(554);
					}
					weapon = m_SchemaReader;
				}
				else if (weapon.Type == Weapon._WeaponType.SensorPod)
				{
					if (_UtilsReader == null)
					{
						_UtilsReader = aircraft_0.ParentScen.Cache_GetWeapon(641);
					}
					weapon = _UtilsReader;
				}
				XSection xSection = Sensor.smethod_0(weapon, _SignatureType_0);
				if (xSection == null)
				{
					xSection = Sensor.smethod_0(weapon, _SignatureType_0);
				}
				if (xSection == null || xSection.isDBInvisible(weapon))
				{
					continue;
				}
				switch (signatureAspect_0)
				{
				case SignatureAspect.Front:
				{
					num2 = Sensor.smethod_0(weapon, _SignatureType_0).GetFront(weapon);
					num3 = (short)weaponRec.CurrentLoad;
					float num5 = num3;
					if (num5 > 6f)
					{
						num3 = ((num5 <= 12f) ? 6f : ((float)(short)Math.Floor(num3 / 3f)));
					}
					break;
				}
				case SignatureAspect.Side:
					num2 = Sensor.smethod_0(weapon, _SignatureType_0).GetSide(weapon);
					num3 = (short)Math.Round((double)weaponRec.CurrentLoad / 2.0);
					break;
				case SignatureAspect.Rear:
				{
					num2 = Sensor.smethod_0(weapon, _SignatureType_0).GetRear(weapon);
					num3 = (short)weaponRec.CurrentLoad;
					float num4 = num3;
					if (num4 > 6f)
					{
						num3 = ((num4 <= 12f) ? 6f : ((float)(short)Math.Floor(num3 / 6f)));
					}
					break;
				}
				}
				if (!aircraft_0.RCCS_StealthPylons)
				{
					num3 = (float)((double)num3 * 1.2);
				}
				if (num2 != -10000f && num2 != 0f)
				{
					tTarget.RCS = num2;
					float num6 = (float)tTarget.RCS_m2;
					num += num6 * num3;
				}
			}
			tTarget.RCS_m2 = num;
			return (float)tTarget.RCS;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101081", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}
}
