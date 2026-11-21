using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Module_Unit
{
	public class Unit : ScenarioObject
	{
		public enum RemoteSimEntityTypeEnum : short
		{
			Local,
			DIS,
			AIS
		}

		public enum LOSCheckResult
		{
			Undefined = 0,
			Success = 1,
			Fail_OutOfHorizon = 2,
			Fail_BlockedByTerrain = 3,
			Fail_BlockedByCloud = 4,
			Fail_Other = 9999
		}

		private float m_DescriptorItem;

		private float m_PoolItem;

		private float m_TaskItem;

		protected float _Attitude_Pitch;

		private float _FilterItem;

		protected float _DesiredPitch;

		private float m_TestsItem;

		protected float _ImpactAltitude;

		public float _LastTick_DeltaTime;

		public float _LastTick_CurrentSpeed;

		public float _LastTick_CurrentHeading;

		public float _LastTick_CurrentAltitude;

		public float _LastTick_VerticalSpeed;

		public float _LastTick_Attitude_Pitch;

		public float _LastTick_Attitude_Roll;

		public double _LastTick_Latitude;

		public double _LastTick_Longitude;

		protected double _Latitude;

		protected double _Longitude;

		private double? _InterpreterItem;

		private double? m_ContainerItem;

		private float? _ComposerItem;

		private double? m_ModelItem;

		private double? advisorItem;

		private double? customerItem;

		private double? _SerializerItem;

		public List<string> ActiveEnterAreaTriggers;

		public TDictionary<string, DateTime> ActiveRemainAreaTriggers;

		public string UnitClass;

		private List<RangeSymbol> _RefItem;

		protected Side _UnitSide;

		public string Message;

		public Lazy<TDictionary<int, bool>> Cache_IsInsideArea;

		public RemoteSimEntityTypeEnum RemoteSimEntityType;

		internal float _ErrorItem;

		public string CustomIcon;

		public Notification_Bark AttachedBark;

		internal float? codeItem;

		public bool PlayerIsPlottingCourse;

		private int? m_ConnectionItem;

		private int? _ContextItem;

		private float? _StatusItem;

		private bool proccesorItem;

		public Geopoint_Struct Location => new Geopoint_Struct(GetLongitude(), GetLatitude(), GetCurrentAltitude());

		public virtual string AnnexAndDBID => "N/A";

		public virtual bool UseAerialUnitUI => false;

		public virtual bool UseSubmerisbleUnitUI => false;

		public virtual bool SupportsAltitude_Control => false;

		public virtual bool SupportsAttitude_Pitch => false;

		public virtual bool SupportsAttitude_Roll => false;

		public virtual float CurrentHeading
		{
			get
			{
				return m_DescriptorItem;
			}
			set
			{
				if (float.IsNaN(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					m_DescriptorItem = value;
				}
			}
		}

		public virtual float CurrentAltitude_AGL
		{
			get
			{
				try
				{
					float? statusItem = _StatusItem;
					if (statusItem.HasValue)
					{
						return statusItem.Value;
					}
					if (IsGroup)
					{
						Group group = (Group)this;
						if (group.Type == Group.GroupType.AirGroup)
						{
							if (Information.IsNothing(group.GroupLead))
							{
								return 0f;
							}
							Aircraft aircraft = (Aircraft)group.GroupLead;
							statusItem = aircraft.CurrentAltitude_AGL;
						}
						else if (group.Type == Group.GroupType.SubGroup)
						{
							if (Information.IsNothing(group.GroupLead))
							{
								return 0f;
							}
							Submarine submarine = (Submarine)group.GroupLead;
							statusItem = submarine.CurrentAltitude_AGL;
						}
						else
						{
							statusItem = 0f;
						}
					}
					else if (DisableWriter())
					{
						Contact contact = (Contact)this;
						if (contact.ActualUnit == null)
						{
							return 0f;
						}
						if (contact.ActualUnit.IsAircraft)
						{
							statusItem = (ResetTokenizer(this) ? new float?(GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ((Aircraft)contact.ActualUnit).ParentScen)) : new float?(GetCurrentAltitude()));
						}
						else if (contact.ActualUnit.IsWeapon)
						{
							statusItem = (ResetTokenizer(this) ? new float?(GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ((Weapon)contact.ActualUnit).ParentScen)) : (IsTorpedo ? new float?(GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ((Torpedo)contact.ActualUnit).ParentScen)) : new float?(GetCurrentAltitude())));
						}
						else
						{
							if (GetCurrentAltitude() < -11000f)
							{
								SetCurrentAltitude(bool_0: false, 0f);
							}
							statusItem = GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, GetUnitSide()?.ParentScen);
						}
					}
					else if (IsAircraft)
					{
						statusItem = (ResetTokenizer(this) ? new float?(GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ((Aircraft)this).ParentScen)) : new float?(GetCurrentAltitude()));
					}
					else
					{
						if (GetCurrentAltitude() < -11000f)
						{
							SetCurrentAltitude(bool_0: false, 0f);
						}
						statusItem = GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, GetUnitSide()?.ParentScen);
					}
					if (!statusItem.HasValue)
					{
						statusItem = GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, GetUnitSide().ParentScen);
					}
					_StatusItem = statusItem;
					return statusItem.Value;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200320", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					_ = Debugger.IsAttached;
					float num = GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, GetUnitSide()?.ParentScen);
					_StatusItem = num;
					ProjectData.ClearProjectError();
					return num;
				}
			}
		}

		public virtual float ImpactAltitude
		{
			get
			{
				return _ImpactAltitude;
			}
			set
			{
				value = (float)Math.Round(value, 2);
				_ImpactAltitude = value;
			}
		}

		public virtual float Attitude_Pitch
		{
			get
			{
				return _Attitude_Pitch;
			}
			set
			{
				_Attitude_Pitch = value;
			}
		}

		public virtual float Attitude_Roll
		{
			get
			{
				return _FilterItem;
			}
			set
			{
				_FilterItem = value;
			}
		}

		public virtual float DesiredPitch
		{
			get
			{
				return _DesiredPitch;
			}
			set
			{
				if (float.IsInfinity(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if (float.IsPositiveInfinity(value))
					{
						value = 89.9f;
					}
					if (float.IsNegativeInfinity(value))
					{
						value = -89.9f;
					}
				}
				_DesiredPitch = value;
			}
		}

		public virtual float DesiredRoll
		{
			get
			{
				return m_TestsItem;
			}
			set
			{
				m_TestsItem = value;
			}
		}

		public virtual bool IsUnderground => CurrentAltitude_AGL < 0f;

		public virtual bool IsUnderwater
		{
			get
			{
				if (GetCurrentAltitude() < 0f)
				{
					return GetCurrentAltitude() >= (float)GetLandElevation(bool_0: false, bool_1: false, bool_2: false, GetUnitSide()?.ParentScen);
				}
				return false;
			}
		}

		public List<RangeSymbol> RangeSymbols
		{
			get
			{
				if (_RefItem == null)
				{
					_RefItem = new List<RangeSymbol>();
				}
				return _RefItem;
			}
		}

		public virtual double Longitude_old
		{
			get
			{
				if (!_InterpreterItem.HasValue)
				{
					_InterpreterItem = _Longitude;
				}
				return _InterpreterItem.Value;
			}
			set
			{
				if (value > 180.0 || value < -180.0)
				{
					value = Math2.VisitClass(value);
				}
				if (double.IsNaN(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					_InterpreterItem = value;
				}
			}
		}

		public virtual double Latitude_old
		{
			get
			{
				if (!m_ContainerItem.HasValue)
				{
					m_ContainerItem = _Latitude;
				}
				return m_ContainerItem.Value;
			}
			set
			{
				if (value > 90.0 || value < -90.0)
				{
					value = Math2.ReflectClass(value);
				}
				if (double.IsNaN(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					m_ContainerItem = value;
				}
			}
		}

		public virtual double? Longitude__UnitEntersAreaCheck
		{
			get
			{
				if (Information.IsNothing(customerItem))
				{
					return customerItem;
				}
				return customerItem.Value;
			}
			set
			{
				if (!value.HasValue)
				{
					customerItem = null;
					return;
				}
				double? num = value;
				if (!(num.HasValue ? new bool?(num.GetValueOrDefault() > 180.0) : null).GetValueOrDefault())
				{
					num = value;
					if (!(num.HasValue ? new bool?(num.GetValueOrDefault() < -180.0) : null).GetValueOrDefault())
					{
						goto IL_00b5;
					}
				}
				value = Math2.VisitClass(value.Value);
				goto IL_00b5;
				IL_00b5:
				if (double.IsNaN(value.Value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					customerItem = value;
				}
			}
		}

		public virtual double? Latitude__UnitEntersAreaCheck
		{
			get
			{
				if (!Information.IsNothing(_SerializerItem))
				{
					return _SerializerItem.Value;
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					_SerializerItem = null;
					return;
				}
				double? num = value;
				if (!(num.HasValue ? new bool?(num.GetValueOrDefault() > 90.0) : null).GetValueOrDefault())
				{
					num = value;
					if (!(num.HasValue ? new bool?(num.GetValueOrDefault() < -90.0) : null).GetValueOrDefault())
					{
						goto IL_00b5;
					}
				}
				value = Math2.ReflectClass(value.Value);
				goto IL_00b5;
				IL_00b5:
				if (double.IsNaN(value.Value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					_SerializerItem = value;
				}
			}
		}

		public float Altitude_old
		{
			get
			{
				if (!_ComposerItem.HasValue)
				{
					_ComposerItem = GetCurrentAltitude();
				}
				return _ComposerItem.Value;
			}
			set
			{
				_ComposerItem = value;
			}
		}

		public virtual float CurrentSpeed
		{
			get
			{
				return m_PoolItem;
			}
			set
			{
				if (float.IsNaN(value) || float.IsInfinity(value))
				{
					value = 0f;
				}
				m_PoolItem = value;
			}
		}

		public bool IsSingleUnitAirbase
		{
			get
			{
				if (IsGroup)
				{
					return false;
				}
				if (IsFacility)
				{
					return ((Facility)this).Category == Facility._FacilityCategory.AirBase;
				}
				return false;
			}
		}

		public virtual bool IsPlatform
		{
			get
			{
				if ((object)GetType().BaseType == typeof(Platform))
				{
					return true;
				}
				return (object)GetType() == typeof(Platform);
			}
		}

		public bool CanBePlacedOnIce
		{
			get
			{
				if (IsSubmarine && ((Submarine)this).IsNuke)
				{
					return true;
				}
				if (IsShip)
				{
					_ = ((Ship)this).IsIcebreaker;
				}
				return false;
			}
		}

		private static TDictionary<int, bool> StopInterruptibleQueue()
		{
			return new TDictionary<int, bool>();
		}

		public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
		{
			try
			{
				xmlWriter_0.WriteStartElement("Unit");
				xmlWriter_0.WriteElementString("ID", ObjectID);
				if (hashSet_0.Contains(ObjectID))
				{
					xmlWriter_0.WriteEndElement();
					return;
				}
				hashSet_0.Add(ObjectID);
				xmlWriter_0.WriteElementString("Name", Name);
				xmlWriter_0.WriteElementString("CurrentHeading", XmlConvert.ToString(CurrentHeading));
				xmlWriter_0.WriteElementString("CurrentSpeed", XmlConvert.ToString(CurrentSpeed));
				xmlWriter_0.WriteElementString("CurrentAltitude", XmlConvert.ToString(GetCurrentAltitude()));
				xmlWriter_0.WriteElementString("Longitude", XmlConvert.ToString(_Longitude));
				xmlWriter_0.WriteElementString("Latitude", XmlConvert.ToString(_Latitude));
				xmlWriter_0.WriteElementString("UnitClass", UnitClass);
				xmlWriter_0.WriteElementString("Side", _UnitSide.Name);
				if (!string.IsNullOrEmpty(Message))
				{
					xmlWriter_0.WriteElementString("Message", Message);
				}
				if (Longitude__UnitEntersAreaCheck.HasValue)
				{
					xmlWriter_0.WriteElementString("Longitude_UnitEntersAreaCheck", XmlConvert.ToString(Longitude__UnitEntersAreaCheck.Value));
				}
				if (Latitude__UnitEntersAreaCheck.HasValue)
				{
					xmlWriter_0.WriteElementString("Latitude_UnitEntersAreaCheck", XmlConvert.ToString(Latitude__UnitEntersAreaCheck.Value));
				}
				if (ActiveEnterAreaTriggers.Count > 0)
				{
					xmlWriter_0.WriteStartElement("ActiveEnterAreaTriggers");
					foreach (string activeEnterAreaTrigger in ActiveEnterAreaTriggers)
					{
						xmlWriter_0.WriteElementString("ActiveEnterAreaTrigger", activeEnterAreaTrigger);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (ActiveRemainAreaTriggers.Count > 0)
				{
					xmlWriter_0.WriteStartElement("ActiveRemainAreaTriggers");
					foreach (KeyValuePair<string, DateTime> activeRemainAreaTrigger in ActiveRemainAreaTriggers)
					{
						xmlWriter_0.WriteElementString("RemainAreaTrigger", activeRemainAreaTrigger.Key.ToString());
						xmlWriter_0.WriteElementString("RemainAreaStartTime", activeRemainAreaTrigger.Value.ToBinary().ToString());
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100864", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static Unit FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
		{
			try
			{
				Unit unit = new Unit();
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
						case "ActiveEnterAreaTriggers":
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									string innerText2 = ((XmlNode)enumerator2.Current).InnerText;
									unit.ActiveEnterAreaTriggers.Add(innerText2);
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
						case "CurrentAltitude":
							unit.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode.InnerText));
							break;
						case "Name":
							unit.Name = xmlNode.InnerText;
							break;
						case "Longitude":
							unit._Longitude = XmlConvert.ToDouble(xmlNode.InnerText);
							break;
						case "ID":
							if (concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
							{
								unit = (Unit)concurrentDictionary_0[xmlNode.InnerText];
								break;
							}
							unit.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(unit.ObjectID, unit);
							break;
						case "UnitClass":
							unit.UnitClass = xmlNode.InnerText;
							break;
						case "Latitude":
							unit._Latitude = XmlConvert.ToDouble(xmlNode.InnerText);
							break;
						case "Side":
							unit.SetUnitSide(bool_0: false, Side.FromXML_ByName(xmlNode.InnerText, ref concurrentDictionary_0, scenario_0));
							break;
						case "ActiveRemainAreaTriggers":
						{
							string key = null;
							DateTime result = DateTime.MinValue;
							try
							{
								enumerator3 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									XmlNode xmlNode2 = (XmlNode)enumerator3.Current;
									if (Operators.CompareString(xmlNode2.Name, "RemainAreaTrigger", TextCompare: false) == 0)
									{
										key = xmlNode2.InnerText;
										result = DateTime.MinValue;
										continue;
									}
									if (DateTime.TryParse(xmlNode2.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
									{
										unit.ActiveRemainAreaTriggers.Add(key, result);
										continue;
									}
									string innerText = xmlNode2.InnerText;
									long result2 = 0L;
									if (long.TryParse(innerText, out result2))
									{
										result = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
										unit.ActiveRemainAreaTriggers.Add(key, result);
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
						}
						case "Latitude_UnitEntersAreaCheck":
							unit.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode.InnerText);
							break;
						case "CurrentSpeed":
							unit.CurrentSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "Message":
							unit.Message = xmlNode.InnerText;
							break;
						case "CurrentHeading":
							unit.m_DescriptorItem = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "Longitude_UnitEntersAreaCheck":
							unit.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode.InnerText);
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
				return unit;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100865", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Unit result3 = new Unit();
				ProjectData.ClearProjectError();
				return result3;
			}
		}

		public virtual void Housekeeping_PostPulse()
		{
		}

		[SpecialName]
		public virtual Side GetUnitSide(bool bool_0 = false)
		{
			return _UnitSide;
		}

		[SpecialName]
		public virtual void SetUnitSide(bool bool_0, Side side_0)
		{
			_UnitSide = side_0;
		}

		internal bool CancelInterruptibleQueue(Side side_0, Scenario scenario_0)
		{
			if (Information.IsNothing(side_0))
			{
				return false;
			}
			if (Operators.CompareString(GetUnitSide().ObjectID, side_0.ObjectID, TextCompare: false) == 0)
			{
				return false;
			}
			string objectID = ObjectID;
			if (IsGroup)
			{
				Group obj = (Group)this;
				new List<Unit>();
				foreach (Unit item in obj.ToList())
				{
					foreach (Contact contacts_ in side_0.Contacts_List)
					{
						if (!Information.IsNothing(contacts_.ActualUnit) && Operators.CompareString(contacts_.ActualUnit.ObjectID, item.ObjectID, TextCompare: false) == 0)
						{
							side_0.DropContact(contacts_, ref scenario_0, bool_0: false);
							break;
						}
					}
					foreach (Contact baseContacts_ in side_0.BaseContacts_List)
					{
						if (!Information.IsNothing(baseContacts_.ActualUnit) && Operators.CompareString(baseContacts_.ActualUnit.ObjectID, item.ObjectID, TextCompare: false) == 0)
						{
							side_0.DropBaseContact(baseContacts_, ref scenario_0, bool_0: false);
							break;
						}
					}
					ActiveUnit obj2 = (ActiveUnit)item;
					ActiveUnit activeUnit_ = (ActiveUnit)item;
					obj2.ComputeClient(ref activeUnit_);
					item.SetUnitSide(bool_0: false, side_0);
					((ActiveUnit)item).SetParentGroup(bool_0: false, (Group)this);
					scenario_0.OnUnitSideChanged(item.ObjectID, objectID);
				}
				SetUnitSide(bool_0: false, side_0);
				foreach (Contact contacts_2 in side_0.Contacts_List)
				{
					if (!Information.IsNothing(contacts_2.ActualUnit) && Operators.CompareString(contacts_2.ActualUnit.ObjectID, ObjectID, TextCompare: false) == 0)
					{
						side_0.DropContact(contacts_2, ref scenario_0, bool_0: false);
						break;
					}
				}
				foreach (Contact baseContacts_2 in side_0.BaseContacts_List)
				{
					if (!Information.IsNothing(baseContacts_2.ActualUnit) && Operators.CompareString(baseContacts_2.ActualUnit.ObjectID, ObjectID, TextCompare: false) == 0)
					{
						side_0.DropBaseContact(baseContacts_2, ref scenario_0, bool_0: false);
						break;
					}
				}
			}
			else
			{
				foreach (Contact contacts_3 in side_0.Contacts_List)
				{
					if (!Information.IsNothing(contacts_3.ActualUnit) && Operators.CompareString(contacts_3.ActualUnit.ObjectID, ObjectID, TextCompare: false) == 0)
					{
						side_0.DropContact(contacts_3, ref scenario_0, bool_0: false);
						break;
					}
				}
				foreach (Contact baseContacts_3 in side_0.BaseContacts_List)
				{
					if (!Information.IsNothing(baseContacts_3.ActualUnit) && Operators.CompareString(baseContacts_3.ActualUnit.ObjectID, ObjectID, TextCompare: false) == 0)
					{
						side_0.DropBaseContact(baseContacts_3, ref scenario_0, bool_0: false);
						break;
					}
				}
				if (((ActiveUnit)this).GetParentGroup() != null)
				{
					((ActiveUnit)this).SetParentGroup(bool_0: false, null);
				}
				ActiveUnit obj3 = (ActiveUnit)this;
				ActiveUnit activeUnit_2 = (ActiveUnit)this;
				obj3.ComputeClient(ref activeUnit_2);
				SetUnitSide(bool_0: false, side_0);
				scenario_0.OnUnitSideChanged(ObjectID, objectID);
			}
			return true;
		}

		[SpecialName]
		public virtual int GetMastHeight_Radar(Sensor sensor_0 = null)
		{
			return 0;
		}

		[SpecialName]
		public virtual int GetMastHeight_Visual(Sensor sensor_0 = null)
		{
			return 0;
		}

		[SpecialName]
		public int GetLandElevation(bool bool_0, bool bool_1, bool bool_2, Scenario scenario_0)
		{
			try
			{
				int? num = m_ConnectionItem;
				if (IsGroup)
				{
					Group group = (Group)this;
					if (group.Type == Group.GroupType.AirGroup)
					{
						if (Information.IsNothing(group.GroupLead))
						{
							return 0;
						}
						Aircraft aircraft = (Aircraft)group.GroupLead;
						num = aircraft.GetLandElevation(bool_0: false, bool_1, bool_2, scenario_0);
					}
					else if (group.Type == Group.GroupType.SubGroup)
					{
						if (Information.IsNothing(group.GroupLead))
						{
							return 0;
						}
						Submarine submarine = (Submarine)group.GroupLead;
						num = submarine.GetLandElevation(bool_0: false, bool_1, bool_2, scenario_0);
					}
					else
					{
						num = Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_1, scenario_0);
					}
				}
				else if (bool_2 || !num.HasValue)
				{
					num = Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_1, scenario_0);
				}
				if (!num.HasValue)
				{
					num = Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_1, scenario_0);
				}
				m_ConnectionItem = num;
				if (bool_0)
				{
					int? num2 = num;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() < 0) : null).GetValueOrDefault())
					{
						return 0;
					}
				}
				return num.Value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200295", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				int elevation = Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_1, scenario_0);
				m_ConnectionItem = elevation;
				ProjectData.ClearProjectError();
				return elevation;
			}
		}

		[SpecialName]
		public int GetLandElevation_next(bool bool_0, float float_0)
		{
			int? num = _ContextItem;
			if (!num.HasValue)
			{
				Scenario scenario_ = null;
				if (IsWeapon)
				{
					scenario_ = ((Weapon)this).ParentScen;
				}
				else if (GetUnitSide() != null)
				{
					scenario_ = GetUnitSide().ParentScen;
				}
				num = Terrain.GetElevation(GetLatitude_next(float_0), GetLongitude_next(float_0), bool_0: false, scenario_);
			}
			_ContextItem = num;
			if (bool_0)
			{
				int? num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() < 0) : null).GetValueOrDefault())
				{
					return 0;
				}
			}
			return num.Value;
		}

		[SpecialName]
		public double GetLongitude_next(float float_0)
		{
			if (!m_ModelItem.HasValue)
			{
				VerifyInterruptibleQueue(float_0);
			}
			return m_ModelItem.Value;
		}

		[SpecialName]
		public double GetLatitude_next(float float_0)
		{
			if (!advisorItem.HasValue)
			{
				VerifyInterruptibleQueue(float_0);
			}
			return advisorItem.Value;
		}

		private void VerifyInterruptibleQueue(float float_0)
		{
			if (CurrentSpeed <= 0f)
			{
				m_ModelItem = _Longitude;
				advisorItem = _Latitude;
				return;
			}
			float horizMovementDistanceOnThisTime = GetHorizMovementDistanceOnThisTime(float_0);
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_, ref double_2, horizMovementDistanceOnThisTime, CurrentHeading);
			m_ModelItem = double_;
			advisorItem = double_2;
		}

		[SpecialName]
		public virtual float GetCurrentAltitude(bool bool_0 = false)
		{
			return m_TaskItem;
		}

		[SpecialName]
		public virtual void SetCurrentAltitude(bool bool_0, float float_0)
		{
			if (m_TaskItem != float_0)
			{
				_StatusItem = null;
			}
			m_TaskItem = float_0;
		}

		[SpecialName]
		public virtual double GetLongitude(bool? nullable_0 = null)
		{
			return _Longitude;
		}

		[SpecialName]
		public virtual void SetLongitude(bool? nullable_0, double double_0)
		{
			if (double_0 > 180.0 || double_0 < -180.0)
			{
				double_0 = Math2.VisitClass(double_0);
			}
			if (double.IsNaN(double_0))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			if (_Longitude != double_0)
			{
				_StatusItem = null;
			}
			_Longitude = double_0;
		}

		[SpecialName]
		public virtual double GetLatitude(bool? nullable_0 = null)
		{
			return _Latitude;
		}

		[SpecialName]
		public virtual void SetLatitude(bool? nullable_0, double double_0)
		{
			if (double_0 > 90.0 || double_0 < -90.0)
			{
				double_0 = Math2.ReflectClass(double_0);
			}
			if (double.IsNaN(double_0))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			if (_Latitude != double_0)
			{
				_StatusItem = null;
			}
			_Latitude = double_0;
		}

		public virtual void Teleport(ref Scenario scenario_0, double double_0, double double_1)
		{
			SetLongitude(null, double_0);
			SetLatitude(null, double_1);
			if (IsActiveUnit)
			{
				ActiveUnit obj = (ActiveUnit)this;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_NoBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer = 0.0;
				obj.Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 0.0;
				obj.Navigator.ResetTimeToNextPathfinderCheck();
			}
			if (!IsActiveUnit || !IsAircraft)
			{
				return;
			}
			Aircraft aircraft = (Aircraft)this;
			if (!Information.IsNothing(aircraft.Loadout))
			{
				WeaponRec[] weapons = aircraft.Loadout.Weapons;
				for (int i = 0; i < weapons.Length; i = checked(i + 1))
				{
					Weapon referenceWeapon = weapons[i].GetReferenceWeapon(aircraft.ParentScen);
					referenceWeapon.SetLongitude(null, aircraft.GetLongitude());
					referenceWeapon.SetLatitude(null, aircraft.GetLatitude());
					referenceWeapon.SetCurrentAltitude(bool_0: false, aircraft.GetCurrentAltitude());
					referenceWeapon.CurrentHeading = aircraft.CurrentHeading;
					referenceWeapon.CurrentSpeed = aircraft.CurrentSpeed;
				}
			}
		}

		public virtual void PrePulseHousekeeping(float float_0, Scenario scenario_0)
		{
			if (string.IsNullOrEmpty(ObjectID))
			{
				ResetIDs();
			}
			if (scenario_0.SecondIsChangingOnThisPulse && proccesorItem)
			{
				if (Cache_IsInsideArea.Value.Count > 0)
				{
					Cache_IsInsideArea.Value.Clear();
				}
				proccesorItem = false;
			}
		}

		public Unit()
		{
			_LastTick_DeltaTime = float.NaN;
			_LastTick_CurrentSpeed = float.NaN;
			_LastTick_CurrentHeading = float.NaN;
			_LastTick_CurrentAltitude = float.NaN;
			_LastTick_VerticalSpeed = float.NaN;
			_LastTick_Attitude_Pitch = float.NaN;
			_LastTick_Attitude_Roll = float.NaN;
			_LastTick_Latitude = double.NaN;
			_LastTick_Longitude = double.NaN;
			ActiveEnterAreaTriggers = new List<string>();
			ActiveRemainAreaTriggers = new TDictionary<string, DateTime>();
			Cache_IsInsideArea = new Lazy<TDictionary<int, bool>>(StopInterruptibleQueue);
			RemoteSimEntityType = RemoteSimEntityTypeEnum.Local;
			CustomIcon = "";
			PlayerIsPlottingCourse = false;
			proccesorItem = false;
		}

		[SpecialName]
		public bool GetIsInsideThisArea(GeoPoint[] geoPoint_0, Scenario scenario_0, bool bool_0)
		{
			try
			{
				if (geoPoint_0 == null)
				{
					return false;
				}
				if (geoPoint_0.Length < 3)
				{
					return false;
				}
				bool flag;
				if (bool_0 && (IsActiveUnit || DisableWriter()))
				{
					int hashCode = geoPoint_0.GetHashCode();
					if (Cache_IsInsideArea.Value.ContainsKey_NoLock(hashCode))
					{
						flag = Cache_IsInsideArea.Value[hashCode];
					}
					else
					{
						flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), geoPoint_0);
						Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, flag);
						proccesorItem = true;
					}
				}
				else
				{
					flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), geoPoint_0);
				}
				return flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 10043563407600", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}

		[SpecialName]
		public bool GetIsInsideThisArea(Geopoint_Struct[] geopoint_Struct_0, Scenario scenario_0, bool bool_0)
		{
			try
			{
				if (geopoint_Struct_0 == null)
				{
					return false;
				}
				if (geopoint_Struct_0.Length < 3)
				{
					return false;
				}
				bool flag;
				if (bool_0 && (IsActiveUnit || DisableWriter()))
				{
					int hashCode = geopoint_Struct_0.GetHashCode();
					if (Cache_IsInsideArea.Value.ContainsKey_NoLock(hashCode))
					{
						flag = Cache_IsInsideArea.Value[hashCode];
					}
					else
					{
						flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), geopoint_Struct_0);
						Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, flag);
						proccesorItem = true;
					}
				}
				else
				{
					flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), geopoint_Struct_0);
				}
				return flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 10043563407600", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}

		[SpecialName]
		public bool GetIsInsideThisArea(List<Geopoint_Struct> list_0, Scenario scenario_0, bool bool_0)
		{
			try
			{
				if (list_0 == null)
				{
					return false;
				}
				if (list_0.Count < 3)
				{
					return false;
				}
				bool flag;
				if (bool_0 && (IsActiveUnit || DisableWriter()))
				{
					int hashCode = list_0.GetHashCode();
					if (Cache_IsInsideArea.Value.ContainsKey_NoLock(hashCode))
					{
						flag = Cache_IsInsideArea.Value[hashCode];
					}
					else
					{
						flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
						Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, flag);
						proccesorItem = true;
					}
				}
				else
				{
					flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
				}
				return flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 32490874598647213094873249587", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}

		[SpecialName]
		public virtual bool GetIsInsideThisArea(List<GeoPoint> list_0, Scenario scenario_0, bool bool_0)
		{
			try
			{
				if (Information.IsNothing(list_0))
				{
					return false;
				}
				if (list_0.Count < 3)
				{
					return false;
				}
				bool flag;
				if (bool_0 && (IsActiveUnit || DisableWriter()))
				{
					int hashCode = list_0.GetHashCode();
					if (Cache_IsInsideArea.Value.ContainsKey_NoLock(hashCode))
					{
						flag = Cache_IsInsideArea.Value[hashCode];
					}
					else
					{
						flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
						if (!Cache_IsInsideArea.Value.ContainsKey_NoLock(hashCode))
						{
							Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, flag);
							proccesorItem = true;
						}
					}
				}
				else
				{
					flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
				}
				return flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100873", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}

		[SpecialName]
		public virtual bool GetIsInsideThisArea(List<ReferencePoint> list_0, Scenario scenario_0, bool bool_0)
		{
			try
			{
				if (list_0 == null)
				{
					return false;
				}
				if (list_0.Count < 3)
				{
					return false;
				}
				bool flag;
				if (bool_0 && (IsActiveUnit || DisableWriter()))
				{
					int hashCode = list_0.GetHashCode();
					if (Cache_IsInsideArea.Value.ContainsKey_NoLock(hashCode))
					{
						try
						{
							flag = Cache_IsInsideArea.Value[hashCode];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
							Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, flag);
							proccesorItem = true;
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
						Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, flag);
						proccesorItem = true;
					}
				}
				else
				{
					flag = GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
				}
				return flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100873", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Geopoint_Struct geopoint_Struct = new Geopoint_Struct(GetLongitude(), GetLatitude());
				bool result = GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, list_0);
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public virtual bool CanPlotCourseToThisLocation(double double_0, double double_1)
		{
			return true;
		}

		public virtual bool CanMoveToThisLocation(double double_0, double double_1, ref int int_0, bool bool_0, bool bool_1, bool bool_2, ref bool bool_3, bool bool_4, ref bool bool_5, float? nullable_0, short? nullable_1, ref List<ActiveUnit> list_0, float float_0, bool bool_6, bool bool_7, ref string string_0, ref bool bool_8)
		{
			return true;
		}

		public static float DetermineAltitude_SensorTarget_Radar(Unit unit_0)
		{
			try
			{
				if (unit_0.IsSubmarine)
				{
					if (((Submarine)unit_0).IsAtPeriscopeDepth)
					{
						return 2f;
					}
					if (((Submarine)unit_0).IsSurfaced)
					{
						return 8f;
					}
					return 0f;
				}
				if (!unit_0.IsShip && !unit_0.IsFacility && !unit_0.IsVehicle)
				{
					return unit_0.GetCurrentAltitude();
				}
				if (unit_0.GetCurrentAltitude() < 0f)
				{
					return 0f;
				}
				return unit_0.GetCurrentAltitude() + (float)unit_0.GetMastHeight_Radar();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100868", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0f;
			}
		}

		public static float DetermineAltitude_SensorObserver_Radar(Unit unit_0, Sensor sensor_0)
		{
			if (sensor_0 != null && sensor_0.MastHeight != 0)
			{
				return unit_0.GetCurrentAltitude() + (float)sensor_0.MastHeight;
			}
			if (unit_0.IsSubmarine)
			{
				if (Math.Round(unit_0.GetCurrentAltitude()) < -20.0)
				{
					return 0f;
				}
				if (Math.Round(unit_0.GetCurrentAltitude()) == -20.0)
				{
					return 2f;
				}
				return 2f + ((float)Math.Abs(-20) - Math.Abs(unit_0.GetCurrentAltitude()));
			}
			if (!unit_0.IsShip && !unit_0.IsFacility && !unit_0.IsVehicle && !unit_0.IsAircraft)
			{
				return unit_0.GetCurrentAltitude();
			}
			if (unit_0.GetCurrentAltitude() < 0f)
			{
				return 0f;
			}
			return unit_0.GetCurrentAltitude() + (float)unit_0.GetMastHeight_Radar();
		}

		[SpecialName]
		public float GetHorizMovementDistanceOnThisTime(float float_0)
		{
			if (SupportsAttitude_Pitch)
			{
				return (float)(Math2.PopClass(Attitude_Pitch) * (double)(CurrentSpeed / 3600f)) * float_0;
			}
			return CurrentSpeed / 3600f * float_0;
		}

		public void BallisticMovement(BallisticTrajectory.BallisticResult ballisticResult_0, float float_0, bool bool_0)
		{
			_InterpreterItem = GetLongitude();
			m_ContainerItem = GetLatitude();
			double lon_deg = ballisticResult_0.Lon_deg;
			double lat_deg = ballisticResult_0.Lat_deg;
			double altASL_m = ballisticResult_0.AltASL_m;
			Altitude_old = GetCurrentAltitude();
			SetCurrentAltitude(bool_0: false, (float)altASL_m);
			CurrentSpeed = (float)ballisticResult_0.Speed_kts;
			SetLatitude(null, lat_deg);
			SetLongitude(null, lon_deg);
			DesiredPitch = (float)ballisticResult_0.Pitch_deg;
			_Attitude_Pitch = (float)ballisticResult_0.Pitch_deg;
			if (IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)this;
				if (activeUnit != null)
				{
					ActiveUnit_Navigator navigator = activeUnit.Navigator;
					if (navigator != null && navigator.HasPlottedCourse())
					{
						ActiveUnit activeUnit2 = (ActiveUnit)this;
						object obj;
						if (activeUnit2 == null)
						{
							obj = null;
						}
						else
						{
							ActiveUnit_Navigator navigator2 = activeUnit2.Navigator;
							obj = ((navigator2 == null) ? null : navigator2.PlottedCourse[0]);
						}
						Waypoint waypoint = (Waypoint)obj;
						CurrentHeading = BearingToPoint_True(this, waypoint.Latitude, waypoint.Longitude);
						goto IL_015e;
					}
				}
			}
			CurrentHeading = (float)ballisticResult_0.Heading_deg;
			goto IL_015e;
			IL_015e:
			if (double.IsNaN(GetLatitude()))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				SetLatitude(null, m_ContainerItem.Value);
			}
			if (double.IsNaN(GetLongitude()))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				SetLongitude(null, _InterpreterItem.Value);
			}
			if (double.IsNaN(GetCurrentAltitude()))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				SetCurrentAltitude(bool_0: false, Altitude_old);
			}
			if (!bool_0)
			{
				CacheOldPosAndNextPos(float_0);
			}
		}

		public virtual void ActualHorizMovement(float float_0, bool bool_0)
		{
			if (CurrentSpeed == 0f)
			{
				return;
			}
			_InterpreterItem = GetLongitude();
			m_ContainerItem = GetLatitude();
			try
			{
				float num = (IsActiveUnit ? ((ActiveUnit)this).Kinematics.HorizMovementDistanceOnThisTime(float_0) : GetHorizMovementDistanceOnThisTime(float_0));
				double double_ = 0.0;
				double double_3 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(_InterpreterItem.Value, m_ContainerItem.Value, ref double_, ref double_3, num, CurrentHeading);
				if (double.IsNaN(double_3))
				{
					double_3 = m_ContainerItem.Value;
				}
				if (double.IsNaN(double_))
				{
					double_ = _InterpreterItem.Value;
				}
				if (IsPlatform)
				{
					bool bool_ = false;
					bool bool_2 = true;
					bool bool_3 = true;
					ActiveUnit activeUnit = null;
					List<ActiveUnit> list_ = null;
					if (IsActiveUnit)
					{
						activeUnit = (ActiveUnit)this;
						list_ = activeUnit.DockingOps.OrderClient();
					}
					double double_4 = double_3;
					double double_5 = double_;
					int int_ = 0;
					string string_ = "";
					if (CanMoveToThisLocation(double_4, double_5, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_2, bool_4: true, ref bool_, null, null, ref list_, 0f, bool_6: false, bool_7: true, ref string_, ref bool_3))
					{
						SetLatitude(null, double_3);
						SetLongitude(null, double_);
						if (((ActiveUnit)this).ParentScen.MinuteIsChangingOnThisPulse)
						{
							((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
						}
					}
					else if (bool_ || bool_2)
					{
						if (activeUnit != null)
						{
							if (!activeUnit.ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing(activeUnit.Navigator.GetNearestAccessibleSpotHeading))
							{
								activeUnit.CurrentHeading = activeUnit.Navigator.GetNearestAccessibleSpotHeading.Value;
							}
							else
							{
								if (bool_ && activeUnit.Navigator.HasPathfindingPlottedCourse)
								{
									activeUnit.Navigator.ClearPathfindingWaypoints();
								}
								double double_6 = 0.0;
								double double_7 = 0.0;
								if (activeUnit.Navigator.GetNearestAccessibleSpot(double_3, double_, ref double_6, ref double_7, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: false))
								{
									activeUnit.Navigator.GetNearestAccessibleSpotHeading = Math2.PublishClass(GetLatitude(), GetLongitude(), double_6, double_7);
									activeUnit.CurrentHeading = activeUnit.Navigator.GetNearestAccessibleSpotHeading.Value;
									activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
								}
							}
						}
						SetLatitude(null, double_3);
						SetLongitude(null, double_);
					}
					else
					{
						double value = m_ContainerItem.Value;
						double value2 = _InterpreterItem.Value;
						int_ = 0;
						string_ = "";
						if (CanMoveToThisLocation(value, value2, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_2, bool_4: true, ref bool_, null, null, ref list_, 0f, bool_6: false, bool_7: true, ref string_, ref bool_3))
						{
							bool_3 = true;
						}
						if (bool_3)
						{
							CurrentHeading = Bounce(m_DescriptorItem, num, bool_0: false);
							Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_, ref double_3, num, CurrentHeading);
							if (activeUnit != null && activeUnit.ParentScen.MinuteIsChangingOnThisPulse)
							{
								double double_8 = double_3;
								double double_9 = double_;
								int_ = 0;
								bool bool_4 = false;
								string_ = "";
								bool bool_5 = false;
								double double_10 = 0.0;
								double double_2 = 0.0;
								if (!CanMoveToThisLocation(double_8, double_9, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_4, bool_4: true, ref bool_, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_5) && activeUnit.Navigator.GetNearestAccessibleSpot(double_3, double_, ref double_10, ref double_2, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: false))
								{
									double_3 = double_10;
									double_ = double_2;
									activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
								}
								activeUnit.Navigator.GetNearestAccessibleSpotHeading = null;
							}
						}
					}
				}
				SetLatitude(null, double_3);
				SetLongitude(null, double_);
				if (double.IsNaN(GetLatitude()))
				{
					SetLatitude(null, m_ContainerItem.Value);
				}
				if (double.IsNaN(GetLongitude()))
				{
					SetLongitude(null, _InterpreterItem.Value);
				}
				if (!bool_0)
				{
					CacheOldPosAndNextPos(float_0);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100875", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		protected void CacheOldPosAndNextPos(float float_0)
		{
			if (Longitude_old != GetLongitude() || Latitude_old != GetLatitude())
			{
				_StatusItem = null;
				m_ConnectionItem = null;
			}
			if (CalcTokenizer(this) != 0f)
			{
				_ContextItem = null;
				m_ModelItem = null;
				advisorItem = null;
			}
		}

		public void ContactMovement()
		{
			if (Longitude_old != GetLongitude() || Latitude_old != GetLatitude())
			{
				ClearElevationAndAltitudeAGL();
			}
			Longitude_old = GetLongitude();
			Latitude_old = GetLatitude();
		}

		public void ClearElevationAndAltitudeAGL()
		{
			_StatusItem = null;
			m_ConnectionItem = null;
		}

		public float Bounce(float float_0, float float_1, bool bool_0)
		{
			try
			{
				int num = 3;
				double double_ = 0.0;
				double double_2 = 0.0;
				List<ActiveUnit> list_ = null;
				float num2;
				while (true)
				{
					num2 = Math2.UpdateClass(float_0 + (float)num);
					Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_, ref double_2, float_1, num2);
					double double_3 = double_2;
					double double_4 = double_;
					int int_ = 0;
					bool bool_ = false;
					bool bool_2 = true;
					string string_ = "";
					bool bool_3 = false;
					if (!CanMoveToThisLocation(double_3, double_4, ref int_, bool_0, bool_1: false, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
					{
						num2 = Math2.UpdateClass(float_0 - (float)num);
						Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_, ref double_2, float_1, num2);
						double double_5 = double_2;
						double double_6 = double_;
						int_ = 0;
						bool_3 = true;
						bool_2 = true;
						string_ = "";
						bool_ = false;
						if (CanMoveToThisLocation(double_5, double_6, ref int_, bool_0, bool_1: false, bool_2: false, ref bool_3, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_))
						{
							break;
						}
						num += 3;
						if (num > 177)
						{
							return float_0;
						}
						continue;
					}
					return num2;
				}
				return num2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100876", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return float_0;
			}
		}

		public float ETA_To_Location(float float_0, float float_1)
		{
			if (float_0 <= 0f)
			{
				return float.MaxValue;
			}
			return (float)Math.Round(float_1 / (float_0 / 3600f), 2);
		}

		public float ETA_To_Unit(Unit unit_0)
		{
			float num = RangeToUnit_Horiz(this, unit_0);
			float num2 = ClosureSpeed(this, unit_0, CurrentSpeed, CurrentHeading);
			return num / num2 * 3600f;
		}

		internal string ListInterruptibleQueue(Unit unit_0)
		{
			string string_ = "";
			if (PrintTokenizer(this, unit_0, bool_0: true, ref string_) < 0f)
			{
				return "Port";
			}
			return "Starboard";
		}

		internal Misc.TurnDirection ResolveInterruptibleQueue(Unit unit_0)
		{
			float num = Math2.PublishClass(GetLatitude(), GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
			float num2 = Math2.UpdateClass(CurrentHeading - num);
			num = 0f;
			if (num2 <= 180f)
			{
				return Misc.TurnDirection.TurnLeft;
			}
			return Misc.TurnDirection.TurnRight;
		}

		public string SpeedString(Game.GamePreferences.SpeedUnitSetting speedUnitSetting_0)
		{
			if (!IsMobileGroundUnit && !IsFacility)
			{
				return Misc.ValidateValue(CurrentSpeed, 0, Game.GamePreferences.SpeedUnitSetting.Knots);
			}
			return Misc.ValidateValue(CurrentSpeed, 0, speedUnitSetting_0);
		}
	}

	public static float RangeToUnit_Slant(Unit unit_0, Unit unit_1, float float_0 = 0f)
	{
		if (unit_1 == null)
		{
			return float.MaxValue;
		}
		float num = ((float_0 == 0f) ? RangeToUnit_Horiz(unit_0, unit_1) : float_0);
		float num2 = (float)((double)Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) * 0.000539957);
		if (num2 == 0f)
		{
			return num;
		}
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float RangeToPoint_Horiz(Unit unit_0, GeoPoint geoPoint_0)
	{
		return Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geoPoint_0.Latitude, geoPoint_0.Longitude);
	}

	public static float RangeToPoint_Horiz(Unit unit_0, Geopoint_Struct geopoint_Struct_0)
	{
		return Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude);
	}

	public static float RangeToPoint_Horiz(Unit unit_0, double double_0, double double_1)
	{
		return Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_0, double_1);
	}

	public static float RangeToPoint_Slant(Unit unit_0, Geopoint_Struct geopoint_Struct_0)
	{
		float num = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude);
		float num2 = (float)((double)Math.Abs(unit_0.GetCurrentAltitude() - geopoint_Struct_0.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float RangeToPoint_Slant(Unit unit_0, TrajectoryPoint trajectoryPoint_0)
	{
		float num = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), trajectoryPoint_0.Latitude, trajectoryPoint_0.Longitude);
		float num2 = (float)((double)Math.Abs(unit_0.GetCurrentAltitude() - trajectoryPoint_0.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float RangeToPoint_Slant(Unit unit_0, GeoPoint geoPoint_0)
	{
		float num = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geoPoint_0.Latitude, geoPoint_0.Longitude);
		float num2 = (float)((double)Math.Abs(unit_0.GetCurrentAltitude() - geoPoint_0.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float RangeToPoint_Slant(Unit unit_0, double double_0, double double_1, float float_0)
	{
		float num = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_0, double_1);
		float num2 = (float)((double)Math.Abs(unit_0.GetCurrentAltitude() - float_0) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static double RangeToPoint_Horiz_Angular(Unit unit_0, GeoPoint geoPoint_0)
	{
		Angle angle_ = default(Angle);
		Angle angle_2 = default(Angle);
		Angle angle_3 = default(Angle);
		Angle angle_4 = default(Angle);
		if (unit_0.IsActiveUnit)
		{
			bool value = ((ActiveUnit)unit_0).IsOperating();
			angle_.Degrees = unit_0.GetLatitude(value);
			angle_2.Degrees = unit_0.GetLongitude(value);
		}
		else
		{
			angle_.Degrees = unit_0.GetLatitude();
			angle_2.Degrees = unit_0.GetLongitude();
		}
		angle_3.Degrees = geoPoint_0.Latitude;
		angle_4.Degrees = geoPoint_0.Longitude;
		return World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Degrees;
	}

	public static double RangeToPoint_Horiz_Angular(Unit unit_0, Geopoint_Struct geopoint_Struct_0)
	{
		Angle angle_ = default(Angle);
		Angle angle_2 = default(Angle);
		Angle angle_3 = default(Angle);
		Angle angle_4 = default(Angle);
		if (unit_0.IsActiveUnit)
		{
			bool value = ((ActiveUnit)unit_0).IsOperating();
			angle_.Degrees = unit_0.GetLatitude(value);
			angle_2.Degrees = unit_0.GetLongitude(value);
		}
		else
		{
			angle_.Degrees = unit_0.GetLatitude();
			angle_2.Degrees = unit_0.GetLongitude();
		}
		angle_3.Degrees = geopoint_Struct_0.Latitude;
		angle_4.Degrees = geopoint_Struct_0.Longitude;
		return World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Degrees;
	}

	public static double RangeToPoint_Horiz_Angular(Unit unit_0, ref double double_0, ref double double_1)
	{
		Angle angle_ = default(Angle);
		Angle angle_2 = default(Angle);
		Angle angle_3 = default(Angle);
		Angle angle_4 = default(Angle);
		if (unit_0.IsActiveUnit)
		{
			bool value = ((ActiveUnit)unit_0).IsOperating();
			angle_.Degrees = unit_0.GetLatitude(value);
			angle_2.Degrees = unit_0.GetLongitude(value);
		}
		else
		{
			angle_.Degrees = unit_0.GetLatitude();
			angle_2.Degrees = unit_0.GetLongitude();
		}
		angle_3.Degrees = double_0;
		angle_4.Degrees = double_1;
		return World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Degrees;
	}

	public static double RangeToUnit_Horiz_Angular(Unit unit_0, Unit unit_1)
	{
		Angle angle_ = default(Angle);
		Angle angle_2 = default(Angle);
		Angle angle_3 = default(Angle);
		Angle angle_4 = default(Angle);
		if (unit_0.IsActiveUnit)
		{
			bool value = ((ActiveUnit)unit_0).IsOperating();
			angle_.Degrees = unit_0.GetLatitude(value);
			angle_2.Degrees = unit_0.GetLongitude(value);
		}
		else
		{
			angle_.Degrees = unit_0.GetLatitude();
			angle_2.Degrees = unit_0.GetLongitude();
		}
		angle_3.Degrees = unit_1.GetLatitude();
		angle_4.Degrees = unit_1.GetLongitude();
		return World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Degrees;
	}

	public static float BearingToUnit_True(Unit unit_0, Unit unit_1)
	{
		return Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), unit_1.GetLatitude(), unit_1.GetLongitude());
	}

	public static float BearingToUnit_Relative(Unit unit_0, Unit unit_1)
	{
		float float_ = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), unit_1.GetLatitude(), unit_1.GetLongitude());
		return Math2.UpdateClass(MathFunctions.DeleteRequest(unit_0.CurrentHeading, float_));
	}

	public static float BearingToPoint_True(Unit unit_0, double double_0, double double_1)
	{
		return Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_0, double_1);
	}

	public static float BearingToPoint_Relative(Unit unit_0, double double_0, double double_1)
	{
		float float_ = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_0, double_1);
		return Math2.UpdateClass(MathFunctions.DeleteRequest(unit_0.CurrentHeading, float_));
	}

	public static float RangeToUnit_Horiz(Unit unit_0, Unit unit_1)
	{
		if (unit_1 == null)
		{
			return float.MaxValue;
		}
		return Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), unit_1.GetLatitude(), unit_1.GetLongitude());
	}

	public static double GrazingAngleToUnit(Unit unit_0, Unit unit_1)
	{
		return Geodesic_Vincenty.EnableInvocation(RangeToUnit_Horiz(unit_0, unit_1), unit_0.GetCurrentAltitude(), unit_1.GetCurrentAltitude());
	}

	public static double GrazingAngleToPoint(Unit unit_0, double double_0, double double_1, float float_0)
	{
		return Geodesic_Vincenty.EnableInvocation(RangeToPoint_Horiz(unit_0, double_0, double_1), unit_0.GetCurrentAltitude(), float_0);
	}

	internal static float PrintTokenizer(Unit unit_0, Unit unit_1, bool bool_0, ref string string_0)
	{
		float currentHeading = unit_1.CurrentHeading;
		float num = Math2.PublishClass(unit_1.GetLatitude(), unit_1.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
		num = Math2.UpdateClass(num - currentHeading);
		currentHeading = 0f;
		string_0 = "horizontal bearing exeed boresight limit";
		if (bool_0 && num > 180f)
		{
			return 0f - (360f - num);
		}
		return num;
	}

	internal static float DefineTokenizer(Unit unit_0, Unit unit_1, ref double double_0, ref double double_1)
	{
		float currentHeading = unit_1.CurrentHeading;
		float num = Math2.PublishClass(unit_1.GetLatitude(), unit_1.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
		num = Math2.UpdateClass(num - currentHeading);
		currentHeading = 0f;
		double num2 = unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude();
		double num3 = (double)Math2.VerifyClass(unit_1.GetLatitude(), unit_1.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude()) * 1852.0;
		double num4 = 90.0;
		if (num3 != 0.0)
		{
			num4 = Math.Atan(num2 / num3) * 57.2957795130823;
		}
		if (unit_1.GetCurrentAltitude() > unit_0.GetCurrentAltitude())
		{
			num4 = 0.0 - Math.Abs(num4);
		}
		num4 -= (double)unit_1.Attitude_Pitch;
		if (num > 180f)
		{
			num = 360f - num;
		}
		double_0 = num;
		double_1 = num4;
		return (float)((double)Math.Abs(num) + Math.Abs(num4));
	}

	internal static bool PublishTokenizer(Weapon weapon_0)
	{
		if (weapon_0.IsWeapon)
		{
			if (weapon_0.Type != Weapon._WeaponType.GuidedWeapon && !weapon_0.IsBallisticMissile && !weapon_0.IsReEntryVehicle && !weapon_0.IsHGV)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	internal static bool AwakeTokenizer(object object_0)
	{
		return ((Unit)object_0).RemoteSimEntityType != Unit.RemoteSimEntityTypeEnum.Local;
	}

	internal static bool QueryTokenizer(object object_0)
	{
		return (object)object_0.GetType() == typeof(Contact);
	}

	internal static bool ResetTokenizer(object object_0)
	{
		if (((ScenarioObject)object_0).IsActiveUnit && ((ActiveUnit)object_0).ParentScen.NatureSideExists())
		{
			foreach (CustomEnvironmentZone customEnvironmentZone in ((ActiveUnit)object_0).ParentScen.GetNatureSide().CustomEnvironmentZones)
			{
				if (customEnvironmentZone.HasCustomTerrain && GeoPoint.IsInsideThisArea(((Unit)object_0).GetLatitude(), ((Unit)object_0).GetLongitude(), customEnvironmentZone.Area) && customEnvironmentZone.TerrainType != 0)
				{
					return true;
				}
			}
		}
		int num = -70;
		if (((ScenarioObject)object_0).IsVehicle || ((ScenarioObject)object_0).IsFacility)
		{
			bool flag = false;
			foreach (Engine item in ((ActiveUnit)object_0).Propulsion)
			{
				if (item.CanBeUsedOnWater())
				{
					flag = true;
					break;
				}
			}
			Scenario scenario_ = (((ScenarioObject)object_0).IsVehicle ? ((Vehicle)object_0).ParentScen : ((Facility)object_0).ParentScen);
			if (!flag && Terrain.GetElevation(((Unit)object_0).GetLatitude(), ((Unit)object_0).GetLongitude(), bool_0: false, scenario_) > num)
			{
				return true;
			}
		}
		return Terrain.ExcludeWatcher(((Unit)object_0).GetLatitude(), ((Unit)object_0).GetLongitude()).IsOverland;
	}

	internal static bool MapTokenizer(Unit unit_0)
	{
		return unit_0.GetCurrentAltitude() < 100000f;
	}

	internal static bool SortTokenizer(object object_0, float float_0)
	{
		int landElevation_next = ((Unit)object_0).GetLandElevation_next(bool_0: false, float_0);
		int num = -70;
		if (((ScenarioObject)object_0).IsVehicle)
		{
			if ((landElevation_next > num) & Information.IsNothing(((Vehicle)object_0).Propulsion.Where((Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0)))
			{
				return true;
			}
		}
		else if (((ScenarioObject)object_0).IsFacility && ((landElevation_next > num) & Information.IsNothing(((Facility)object_0).Propulsion.Where((Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0))))
		{
			return true;
		}
		return false;
	}

	internal static float CalcTokenizer(Unit unit_0)
	{
		if (unit_0.SupportsAttitude_Pitch)
		{
			return (float)(Math2.PopClass(unit_0.Attitude_Pitch) * (double)unit_0.CurrentSpeed);
		}
		return unit_0.CurrentSpeed;
	}

	internal static float RateTokenizer(Unit unit_0, Scenario scenario_0, bool bool_0 = false)
	{
		if (bool_0 || !unit_0.codeItem.HasValue)
		{
			FlushTokenizer(unit_0, scenario_0.GameResolution);
		}
		return unit_0.codeItem.Value;
	}

	internal static void FlushTokenizer(Unit unit_0, float float_0)
	{
		unit_0.codeItem = (unit_0.GetCurrentAltitude() - unit_0.Altitude_old) / float_0;
	}

	public static float ClosureSpeed(Unit unit_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3)
	{
		try
		{
			if (float_1 == 0f && Math.Abs(Math.Round(MathFunctions.DeleteRequest(BearingToPoint_True(unit_0, double_0, double_1), float_3), 1)) <= 0.1)
			{
				return float_2;
			}
			if (Geodesic_Haversine.Distance_Horiz_Approx_nm(unit_0.GetLatitude(), unit_0.GetLongitude(), double_0, double_1) < 50.0)
			{
				return (float)MercatorProjection.ClosureRate_Geocentric(unit_0.GetLatitude(), unit_0.GetLongitude(), float_2, float_3, double_0, double_1, float_1, float_0);
			}
			return ForgotTokenizer(unit_0, double_0, double_1, float_0, float_1, float_2, float_3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200045", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	private static float ForgotTokenizer(Unit unit_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3)
	{
		float float_4 = float_2 / 3600f;
		double double_2 = 0.0;
		double double_3 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_2, ref double_3, float_4, float_3);
		float_4 = float_1 / 3600f;
		double double_4 = 0.0;
		double double_5 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_5, ref double_4, float_4, float_0);
		float num = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_0, double_1);
		float num2 = Math2.VerifyClass(double_3, double_2, double_4, double_5);
		return (num - num2) * 3600f;
	}

	public static float ClosureSpeed(Unit unit_0, Unit unit_1, float float_0, float float_1)
	{
		return ClosureSpeed(unit_0, unit_1.GetLatitude(), unit_1.GetLongitude(), unit_1.CurrentHeading, unit_1.CurrentSpeed, float_0, float_1);
	}

	public static Unit.LOSCheckResult Has_LOS_ToUnit_Orbital(Unit unit_0, Unit unit_1, ref Scenario scenario_0)
	{
		if (unit_0.IsSatellite && unit_1.IsSatellite)
		{
			MathFunctions.Vector positionVector = ((Satellite)unit_0).PositionVector;
			MathFunctions.Vector positionVector2 = ((Satellite)unit_1).PositionVector;
			if (MathFunctions.Arccos(6371.0 / positionVector.Mag) + MathFunctions.Arccos(6371.0 / positionVector2.Mag) - MathFunctions.Arccos(positionVector.ExcludeInterruptibleQueue(positionVector2) / (positionVector.Mag * positionVector2.Mag)) <= 0.0)
			{
				return Unit.LOSCheckResult.Fail_OutOfHorizon;
			}
			return Unit.LOSCheckResult.Success;
		}
		return Unit.LOSCheckResult.Fail_Other;
	}

	public static bool Has_Radar_LOS_ToPoint(Unit unit_0, Sensor sensor_0, double double_0, double double_1, float float_0, ref Scenario scenario_0, bool bool_0 = false)
	{
		try
		{
			float float_ = ((sensor_0 != null && sensor_0.MastHeight != 0) ? (unit_0.GetCurrentAltitude() + (float)sensor_0.MastHeight) : ((unit_0.IsShip || unit_0.IsFacility) ? (unit_0.GetCurrentAltitude() + (float)unit_0.GetMastHeight_Radar()) : unit_0.GetCurrentAltitude()));
			if (!bool_0 && Horizon.CountClass(float_, float_0) < Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_0, double_1))
			{
				return false;
			}
			bool result = false;
			try
			{
				result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), float_, double_0, double_1, float_0, bool_0: false, scenario_0, 0, bool_0);
			}
			catch (OutOfMemoryException projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), float_, double_0, double_1, float_0, bool_0: false, scenario_0, 0, bool_0);
				ProjectData.ClearProjectError();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101174", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100867", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool Has_Radar_LOS_ToUnit(Unit unit_0, Sensor sensor_0, Unit unit_1, ref Scenario scenario_0, bool bool_0 = false, float? nullable_0 = null, float? nullable_1 = null)
	{
		try
		{
			if (unit_0.IsSatellite && unit_1.IsSatellite)
			{
				return Has_LOS_ToUnit_Orbital(unit_0, unit_1, ref scenario_0) == Unit.LOSCheckResult.Success;
			}
			float num = (nullable_1.HasValue ? nullable_1.Value : Unit.DetermineAltitude_SensorTarget_Radar(unit_1));
			float num2 = (nullable_0.HasValue ? nullable_0.Value : Unit.DetermineAltitude_SensorObserver_Radar(unit_0, sensor_0));
			if ((unit_1.IsShip || unit_1.IsFacility || unit_1.IsMobileGroundUnit || unit_1.IsSubmarine) && unit_0.GetCurrentAltitude() > 0f && unit_0.CurrentAltitude_AGL > 0f)
			{
				return Has_Radar_LOS_ToUnit(unit_1, null, unit_0, ref scenario_0, bool_0, num, num2);
			}
			if (!bool_0 && Horizon.CountClass(num2, num) < RangeToUnit_Horiz(unit_0, unit_1))
			{
				return false;
			}
			if (unit_0.IsSubmarine && Math.Round(unit_0.GetCurrentAltitude()) < -20.0 && unit_1.GetCurrentAltitude() > 0f)
			{
				return false;
			}
			bool result = false;
			try
			{
				result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num2, unit_1.GetLatitude(), unit_1.GetLongitude(), num, bool_0: false, scenario_0, 0, bool_0);
			}
			catch (OutOfMemoryException projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num2, unit_1.GetLatitude(), unit_1.GetLongitude(), num, bool_0: false, scenario_0, 0, bool_0);
				ProjectData.ClearProjectError();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101175", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100869", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool Has_ESM_LOS_ToUnit(Unit unit_0, Sensor sensor_0, Unit unit_1, ref Scenario scenario_0, bool bool_0 = false, float? nullable_0 = null, float? nullable_1 = null)
	{
		try
		{
			if (unit_0.IsSatellite && unit_1.IsSatellite)
			{
				return Has_LOS_ToUnit_Orbital(unit_0, unit_1, ref scenario_0) == Unit.LOSCheckResult.Success;
			}
			float num = (nullable_1.HasValue ? nullable_1.Value : Unit.DetermineAltitude_SensorTarget_Radar(unit_1));
			float num2 = (nullable_0.HasValue ? nullable_0.Value : Unit.DetermineAltitude_SensorObserver_Radar(unit_0, sensor_0));
			if (unit_0.GetCurrentAltitude() > 0f && unit_0.CurrentAltitude_AGL > 0f && (unit_1.IsShip || unit_1.IsFacility || unit_1.IsSubmarine))
			{
				return Has_ESM_LOS_ToUnit(unit_1, null, unit_0, ref scenario_0, bool_0, num, num2);
			}
			if (!bool_0 && Horizon.CustomizeClass(num2, num) < RangeToUnit_Horiz(unit_0, unit_1))
			{
				return false;
			}
			if (unit_0.IsSubmarine && Math.Round(unit_0.GetCurrentAltitude()) < -20.0 && unit_1.GetCurrentAltitude() > 0f)
			{
				return false;
			}
			bool result = false;
			try
			{
				result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num2, unit_1.GetLatitude(), unit_1.GetLongitude(), num, bool_0: false, scenario_0, 0, bool_0);
			}
			catch (OutOfMemoryException projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num2, unit_1.GetLatitude(), unit_1.GetLongitude(), num, bool_0: false, scenario_0, 0, bool_0);
				ProjectData.ClearProjectError();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 3495067356897345", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 4321857569873459867", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static Unit.LOSCheckResult Has_Visual_LOS_ToUnit(Unit unit_0, Sensor sensor_0, Unit unit_1, ref Scenario scenario_0, bool bool_0)
	{
		try
		{
			if (unit_0.IsSatellite && unit_1.IsSatellite)
			{
				return Has_LOS_ToUnit_Orbital(unit_0, unit_1, ref scenario_0);
			}
			if (unit_0.IsSubmarine && Math.Round(unit_0.GetCurrentAltitude()) < -20.0 && unit_1.GetCurrentAltitude() > 0f)
			{
				return Unit.LOSCheckResult.Fail_Other;
			}
			float num = 0f;
			if (unit_1.IsSubmarine)
			{
				if (((Submarine)unit_1).IsAtPeriscopeDepth)
				{
					num = 2f;
				}
				else if (((Submarine)unit_1).IsSurfaced)
				{
					num = 8f;
				}
			}
			else
			{
				bool flag = unit_1.IsMobileGroundUnit && ResetTokenizer(unit_1);
				bool flag2 = unit_1.IsMobileGroundUnit && !ResetTokenizer(unit_1);
				num = ((unit_1.IsShip || unit_1.IsFacility || flag) ? (unit_1.GetCurrentAltitude() + (float)unit_1.GetMastHeight_Visual()) : (flag2 ? ((float)unit_1.GetMastHeight_Visual()) : unit_1.GetCurrentAltitude()));
			}
			float num2 = ((unit_0.IsShip || unit_0.IsFacility || unit_0.IsAircraft) ? (unit_0.GetCurrentAltitude() + (float)unit_0.GetMastHeight_Visual(sensor_0)) : ((unit_0.IsWeapon && ((Weapon)unit_0).Type == Weapon._WeaponType.Sonobuoy && !unit_1.IsSubmarine) ? 1f : ((!unit_0.IsSubmarine || Math.Round(unit_0.GetCurrentAltitude()) > -20.0) ? unit_0.GetCurrentAltitude() : ((float)(Math.Abs(-20) + 2) + unit_0.GetCurrentAltitude()))));
			bool flag3 = true;
			bool flag4 = num2 < 0f;
			bool flag5 = num < 0f;
			if (flag4 && num > 0f)
			{
				return Unit.LOSCheckResult.Fail_Other;
			}
			if (unit_0.GetCurrentAltitude() > 0f && flag5)
			{
				return Unit.LOSCheckResult.Fail_Other;
			}
			if (flag4 && num == 0f)
			{
				flag3 = false;
			}
			if (unit_0.GetCurrentAltitude() == 0f && flag5)
			{
				flag3 = false;
			}
			if (flag4 && flag5)
			{
				flag3 = false;
			}
			if (flag3 && Horizon.RevertInvocation(num2, num) < Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), unit_1.GetLatitude(), unit_1.GetLongitude()))
			{
				return Unit.LOSCheckResult.Fail_OutOfHorizon;
			}
			if (bool_0 && !Weather.Visibility(unit_0, unit_1, ref scenario_0))
			{
				return Unit.LOSCheckResult.Fail_BlockedByCloud;
			}
			if (unit_0.IsSatellite)
			{
				return Unit.LOSCheckResult.Success;
			}
			if (unit_1.IsSatellite)
			{
				return Has_Visual_LOS_ToUnit(unit_1, null, unit_0, ref scenario_0, bool_0);
			}
			bool flag6 = false;
			try
			{
				flag6 = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num2, unit_1.GetLatitude(), unit_1.GetLongitude(), num, bool_0: false, scenario_0);
			}
			catch (OutOfMemoryException projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				flag6 = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num2, unit_1.GetLatitude(), unit_1.GetLongitude(), num, bool_0: false, scenario_0);
				ProjectData.ClearProjectError();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101176", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (flag6)
			{
				return Unit.LOSCheckResult.Success;
			}
			return Unit.LOSCheckResult.Fail_BlockedByTerrain;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100870", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return Unit.LOSCheckResult.Fail_Other;
		}
	}

	public static bool Has_Sonar_LOS_ToUnit(Unit unit_0, Unit unit_1, ref Scenario scenario_0, ref bool bool_0, float? nullable_0 = null)
	{
		try
		{
			float num = (nullable_0.HasValue ? nullable_0.Value : unit_0.GetCurrentAltitude());
			if (num <= 0f && unit_1.GetCurrentAltitude() <= 0f)
			{
				float currentAltitude = unit_1.GetCurrentAltitude();
				bool result = false;
				try
				{
					result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num, unit_1.GetLatitude(), unit_1.GetLongitude(), currentAltitude, bool_0, scenario_0);
				}
				catch (OutOfMemoryException projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = Scenario.DetermineLOS(unit_0.GetLatitude(), unit_0.GetLongitude(), num, unit_1.GetLatitude(), unit_1.GetLongitude(), currentAltitude, bool_0, scenario_0);
					ProjectData.ClearProjectError();
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101178", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				return result;
			}
			return false;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100871", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}
}
