using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group : ActiveUnit
{
	public delegate void UnitAddedEventHandler(Group theGroup, ActiveUnit theUnit);

	public delegate void UnitRemovedEventHandler(Group theGroup, ActiveUnit theUnit);

	public enum GroupType : byte
	{
		AirGroup,
		SurfaceGroup,
		SubGroup,
		Installation,
		MobileGroup,
		AirBase,
		NavalBase
	}

	private GroupType? taskDic;

	public GeoPoint Center;

	private ActiveUnit m_FilterDic;

	[CompilerGenerated]
	[AccessedThroughProperty("Patrols")]
	private ObservableList<Patrol> m_TestsDic;

	private Group_Navigator m_InterpreterDic;

	private Group_AI containerDic;

	private Group_Kinematics _ComposerDic;

	private Group_Sensory m_ModelDic;

	private Group_Weaponry m_AdvisorDic;

	private Group_CommStuff m_CustomerDic;

	private Group_AirOps serializerDic;

	[CompilerGenerated]
	[AccessedThroughProperty("Units")]
	private ObservableDictionary<string, ActiveUnit> _RefDic;

	internal bool m_ErrorDic;

	public string LastFormationSet;

	public float LastFormationSpacing;

	public byte LastFormationSpacingUnits;

	public bool ReservedSupply;

	public bool MembersInheritIcon;

	[CompilerGenerated]
	private static UnitAddedEventHandler m_CodeDic;

	[CompilerGenerated]
	private static UnitRemovedEventHandler m_ConnectionDic;

	public ObservableList<Patrol> Patrols
	{
		[CompilerGenerated]
		get
		{
			return m_TestsDic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Patrol>> value2 = MapInvocation;
			EventHandler<ObservableListModified<Patrol>> value3 = SortInvocation;
			ObservableList<Patrol> testsDic = m_TestsDic;
			if (testsDic != null)
			{
				testsDic.ItemsAdded -= value2;
				testsDic.ItemsRemoved -= value3;
			}
			m_TestsDic = value;
			testsDic = m_TestsDic;
			if (testsDic != null)
			{
				testsDic.ItemsAdded += value2;
				testsDic.ItemsRemoved += value3;
			}
		}
	}

	public ObservableDictionary<string, ActiveUnit> Units
	{
		[CompilerGenerated]
		get
		{
			return _RefDic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, ActiveUnit>.DictionaryChangedEventHandler val = ResetInvocation;
			ObservableDictionary<string, ActiveUnit> refDic = _RefDic;
			if (refDic != null)
			{
				refDic.DictionaryChanged -= val;
			}
			_RefDic = value;
			refDic = _RefDic;
			if (refDic != null)
			{
				refDic.DictionaryChanged += val;
			}
		}
	}

	public override GlobalVariables.ProficiencyLevel? Proficiency
	{
		get
		{
			return base.Proficiency;
		}
		set
		{
			foreach (ActiveUnit value2 in Units.Values)
			{
				value2.Proficiency = value;
			}
		}
	}

	public override _ActiveUnitStatus Status
	{
		get
		{
			if (GroupLead == null)
			{
				return _ActiveUnitStatus.Unassigned;
			}
			return GroupLead.Status;
		}
		set
		{
			if (GroupLead != null)
			{
				GroupLead.Status = value;
			}
		}
	}

	public override string SubTypeDescription => TypeDescription;

	public override float CurrentAltitude_AGL
	{
		get
		{
			if (GroupLead == null)
			{
				return base.CurrentAltitude_AGL;
			}
			return GroupLead.CurrentAltitude_AGL;
		}
	}

	public override float CurrentHeading
	{
		get
		{
			if (GroupLead == null)
			{
				return base.CurrentHeading;
			}
			return GroupLead.CurrentHeading;
		}
		set
		{
			if (GroupLead == null)
			{
				base.CurrentHeading = value;
			}
			else
			{
				GroupLead.CurrentHeading = value;
			}
		}
	}

	public override float CurrentSpeed
	{
		get
		{
			if (GroupLead == null)
			{
				return base.CurrentSpeed;
			}
			return GroupLead.CurrentSpeed;
		}
		set
		{
			if (GroupLead == null)
			{
				base.CurrentSpeed = value;
			}
			else
			{
				GroupLead.CurrentSpeed = value;
			}
		}
	}

	public override Throttle MaxPossibleThrottleSetting => GroupLead.MaxPossibleThrottleSetting;

	public bool IsLandInstallation
	{
		get
		{
			foreach (ActiveUnit item in new List<ActiveUnit>(Units.Values))
			{
				if (item != null && item.IsFixedFacility)
				{
					return true;
				}
			}
			return false;
		}
	}

	public GroupType Type
	{
		get
		{
			if (taskDic.HasValue)
			{
				return taskDic.Value;
			}
			taskDic = AssetInvocation();
			return taskDic.Value;
		}
	}

	public string TypeDescription
	{
		get
		{
			switch (Type)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return Type.ToString();
			case GroupType.AirGroup:
				return "空中编队";
			case GroupType.SurfaceGroup:
				return "水面编队";
			case GroupType.SubGroup:
				return "水下编队";
			case GroupType.Installation:
				return "地面装置";
			case GroupType.MobileGroup:
				return "移动编队";
			case GroupType.AirBase:
				return "Airfield";
			case GroupType.NavalBase:
				return "海军基地";
			}
		}
	}

	public override Mission AssignedTaskPool
	{
		get
		{
			if (GroupLead == null)
			{
				return null;
			}
			return GroupLead.AssignedTaskPool;
		}
		set
		{
			foreach (ActiveUnit value2 in Units.Values)
			{
				value2.AssignedTaskPool = value;
			}
		}
	}

	public override ActiveUnit_Navigator Navigator => m_InterpreterDic;

	public override ActiveUnit_AI AI => containerDic;

	public new Group_Kinematics Kinematics => _ComposerDic;

	public override ActiveUnit_Sensory Sensory => m_ModelDic;

	public override ActiveUnit_Weaponry Weaponry => m_AdvisorDic;

	public override ActiveUnit_CommStuff CommStuff => m_CustomerDic;

	public override ActiveUnit_AirOps AirOps => serializerDic;

	public new ActiveUnit_Damage Damage
	{
		get
		{
			if (_Damage == null)
			{
				ActiveUnit activeUnit_ = this;
				_Damage = new ActiveUnit_Damage(ref activeUnit_);
			}
			return _Damage;
		}
	}

	public ActiveUnit GroupLead
	{
		get
		{
			if (m_FilterDic == null)
			{
				PrintInvocation();
			}
			return m_FilterDic;
		}
	}

	public override float DesiredHeading
	{
		get
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead == null)
			{
				return 0f;
			}
			return GroupLead.DesiredHeading;
		}
	}

	public override float DesiredAltitude
	{
		get
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead == null)
			{
				return 0f;
			}
			return GroupLead.DesiredAltitude;
		}
		set
		{
			try
			{
				if (GroupLead == null)
				{
					PrintInvocation();
				}
				if (GroupLead != null)
				{
					GroupLead.DesiredAltitude = value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100591", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override float DesiredAltitude_AGL
	{
		get
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead == null)
			{
				return 0f;
			}
			return GroupLead.DesiredAltitude_AGL;
		}
		set
		{
			try
			{
				if (GroupLead == null)
				{
					PrintInvocation();
				}
				if (GroupLead != null)
				{
					GroupLead.DesiredAltitude_AGL = value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101257", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override float DesiredSpeed
	{
		get
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead == null)
			{
				return 0f;
			}
			return GroupLead.DesiredSpeed;
		}
		set
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead != null)
			{
				GroupLead.DesiredSpeed = value;
			}
		}
	}

	public override TurnRate DesiredTurnRate
	{
		get
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead == null)
			{
				return TurnRate.Max;
			}
			return GroupLead.DesiredTurnRate;
		}
		set
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead != null)
			{
				GroupLead.DesiredTurnRate = value;
			}
		}
	}

	public override Waypoint.TurnRateCategory DesiredTurnRate_Navigation
	{
		get
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead == null)
			{
				return Waypoint.TurnRateCategory.StandardRateTurn;
			}
			return GroupLead.DesiredTurnRate_Navigation;
		}
		set
		{
			if (GroupLead == null)
			{
				PrintInvocation();
			}
			if (GroupLead != null)
			{
				GroupLead.DesiredTurnRate_Navigation = value;
			}
		}
	}

	public override AirFacility[] AirFacilities_ReadOnly
	{
		get
		{
			try
			{
				int num = 0;
				foreach (ActiveUnit value in Units.Values)
				{
					num += value.AirFacilities_ReadOnly.Length;
				}
				AirFacility[] array = new AirFacility[num - 1 + 1];
				num = 0;
				foreach (ActiveUnit value2 in Units.Values)
				{
					AirFacility[] airFacilities_ReadOnly = value2.AirFacilities_ReadOnly;
					for (int i = 0; i < airFacilities_ReadOnly.Length; i = checked(i + 1))
					{
						array[num] = airFacilities_ReadOnly[i];
						num++;
					}
				}
				return array;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100592", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				AirFacility[] result = new AirFacility[0];
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public override DockFacility[] DockFacilities_ReadOnly
	{
		get
		{
			try
			{
				LinkedList<DockFacility> linkedList = new LinkedList<DockFacility>();
				foreach (ActiveUnit value2 in Units.Values)
				{
					DockFacility[] dockFacilities_ReadOnly = value2.DockFacilities_ReadOnly;
					DockFacility[] array = dockFacilities_ReadOnly;
					foreach (DockFacility value in array)
					{
						linkedList.AddLast(value);
					}
				}
				return linkedList.ToArray();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100593", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DockFacility[] result = new DockFacility[0];
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public override Magazine[] SharedMagazines
	{
		get
		{
			try
			{
				GroupType type = Type;
				if (type != GroupType.Installation && (int)(type - 5) > 1)
				{
					return null;
				}
				List<Magazine> list = new List<Magazine>();
				foreach (Platform value in Units.Values)
				{
					Magazine[] magazines = value.Magazines;
					Magazine[] array = magazines;
					foreach (Magazine item in array)
					{
						list.Add(item);
					}
				}
				return list.ToArray();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100594", "");
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

	public override Throttle ThrottleSetting
	{
		get
		{
			if (Type == GroupType.AirGroup)
			{
				if (base.ThrottleSetting == Throttle.FullStop)
				{
					SetThrottle(Throttle.Cruise);
				}
				return base.ThrottleSetting;
			}
			return base.ThrottleSetting;
		}
		set
		{
			base.ThrottleSetting = value;
		}
	}

	public bool IsFormingUp
	{
		get
		{
			try
			{
				bool result = false;
				if (Type != GroupType.AirBase || Type == GroupType.Installation)
				{
					if (Type == GroupType.SurfaceGroup || Type == GroupType.MobileGroup)
					{
						foreach (ActiveUnit value in Units.Values)
						{
							if (!value.IsAircraft && !value.IsOperating())
							{
								result = true;
								break;
							}
						}
					}
					if (Type == GroupType.AirGroup)
					{
						foreach (ActiveUnit value2 in Units.Values)
						{
							if (!value2.IsOperating())
							{
								result = true;
								break;
							}
						}
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100599", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	public override bool UseAerialUnitUI
	{
		get
		{
			if (taskDic.HasValue && taskDic.Value == GroupType.AirGroup)
			{
				return true;
			}
			return false;
		}
	}

	public override bool UseSubmerisbleUnitUI
	{
		get
		{
			if (taskDic.HasValue && taskDic.Value == GroupType.SubGroup)
			{
				return true;
			}
			return false;
		}
	}

	public override bool SupportsAltitude_Control
	{
		get
		{
			if (taskDic.HasValue)
			{
				if (taskDic.Value != 0)
				{
					return taskDic.Value == GroupType.SubGroup;
				}
				return true;
			}
			return false;
		}
	}

	public static event UnitAddedEventHandler UnitAdded
	{
		[CompilerGenerated]
		add
		{
			UnitAddedEventHandler unitAddedEventHandler = m_CodeDic;
			UnitAddedEventHandler unitAddedEventHandler2;
			do
			{
				unitAddedEventHandler2 = unitAddedEventHandler;
				UnitAddedEventHandler value2 = (UnitAddedEventHandler)Delegate.Combine(unitAddedEventHandler2, value);
				unitAddedEventHandler = Interlocked.CompareExchange(ref m_CodeDic, value2, unitAddedEventHandler2);
			}
			while ((object)unitAddedEventHandler != unitAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitAddedEventHandler unitAddedEventHandler = m_CodeDic;
			UnitAddedEventHandler unitAddedEventHandler2;
			do
			{
				unitAddedEventHandler2 = unitAddedEventHandler;
				UnitAddedEventHandler value2 = (UnitAddedEventHandler)Delegate.Remove(unitAddedEventHandler2, value);
				unitAddedEventHandler = Interlocked.CompareExchange(ref m_CodeDic, value2, unitAddedEventHandler2);
			}
			while ((object)unitAddedEventHandler != unitAddedEventHandler2);
		}
	}

	public static event UnitRemovedEventHandler UnitRemoved
	{
		[CompilerGenerated]
		add
		{
			UnitRemovedEventHandler unitRemovedEventHandler = m_ConnectionDic;
			UnitRemovedEventHandler unitRemovedEventHandler2;
			do
			{
				unitRemovedEventHandler2 = unitRemovedEventHandler;
				UnitRemovedEventHandler value2 = (UnitRemovedEventHandler)Delegate.Combine(unitRemovedEventHandler2, value);
				unitRemovedEventHandler = Interlocked.CompareExchange(ref m_ConnectionDic, value2, unitRemovedEventHandler2);
			}
			while ((object)unitRemovedEventHandler != unitRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitRemovedEventHandler unitRemovedEventHandler = m_ConnectionDic;
			UnitRemovedEventHandler unitRemovedEventHandler2;
			do
			{
				unitRemovedEventHandler2 = unitRemovedEventHandler;
				UnitRemovedEventHandler value2 = (UnitRemovedEventHandler)Delegate.Remove(unitRemovedEventHandler2, value);
				unitRemovedEventHandler = Interlocked.CompareExchange(ref m_ConnectionDic, value2, unitRemovedEventHandler2);
			}
			while ((object)unitRemovedEventHandler != unitRemovedEventHandler2);
		}
	}

	internal bool StartInvocation()
	{
		foreach (ActiveUnit value in Units.Values)
		{
			if (value is ICargoHost)
			{
				return true;
			}
		}
		return false;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Group");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			method_0(ref xmlWriter_0);
			xmlWriter_0.WriteElementString("Name", Name);
			if (!Information.IsNothing(taskDic))
			{
				xmlWriter_0.WriteElementString("Type", ((int)taskDic.Value).ToString());
			}
			xmlWriter_0.WriteElementString("CurrentHeading", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("CurrentSpeed", XmlConvert.ToString(CurrentSpeed));
			xmlWriter_0.WriteElementString("CurrentAltitude", XmlConvert.ToString(GetCurrentAltitude()));
			xmlWriter_0.WriteElementString("Longitude", XmlConvert.ToString(GetLongitude()));
			xmlWriter_0.WriteElementString("Latitude", XmlConvert.ToString(GetLatitude()));
			xmlWriter_0.WriteElementString("UnitClass", UnitClass);
			xmlWriter_0.WriteElementString("Side", GetUnitSide().Name);
			xmlWriter_0.WriteElementString("Message", Message);
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
			xmlWriter_0.WriteElementString("DBID", DBID.ToString());
			xmlWriter_0.WriteElementString("DesiredHeading", XmlConvert.ToString(DesiredHeading));
			xmlWriter_0.WriteElementString("DesiredSpeed", XmlConvert.ToString(DesiredSpeed));
			xmlWriter_0.WriteElementString("DesiredAltitude", XmlConvert.ToString(DesiredAltitude));
			xmlWriter_0.WriteElementString("DesiredTurnRate", ((byte)DesiredTurnRate).ToString());
			xmlWriter_0.WriteElementString("DesiredTurnRate_Navigation", ((byte)DesiredTurnRate_Navigation).ToString());
			xmlWriter_0.WriteElementString("Weight", XmlConvert.ToString(EmptyWeight));
			xmlWriter_0.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
			xmlWriter_0.WriteStartElement("Sensors");
			Sensor[] sensors = _Sensors;
			Sensor[] array = sensors;
			foreach (Sensor sensor in array)
			{
				xmlWriter_0.WriteRaw(sensor.ToXML(hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Comms");
			CommDevice[] comms = _Comms;
			CommDevice[] array2 = comms;
			foreach (CommDevice commDevice in array2)
			{
				xmlWriter_0.WriteRaw(commDevice.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Propulsion");
			foreach (Engine item in Propulsion)
			{
				xmlWriter_0.WriteRaw(item.ToXML(hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Mounts");
			foreach (Mount mount in Mounts)
			{
				if (Information.IsNothing(mount.ParentPlatform))
				{
					mount.ParentPlatform = this;
				}
				xmlWriter_0.WriteRaw(mount.ToXML(ref hashSet_0, ParentScen));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("OnboardCargo");
			Cargo[] onboardCargo = OnboardCargo;
			Cargo[] array3 = onboardCargo;
			foreach (Cargo cargo in array3)
			{
				xmlWriter_0.WriteRaw(cargo.ToXML(hashSet_0, ParentScen));
			}
			xmlWriter_0.WriteEndElement();
			XmlWriter obj = xmlWriter_0;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			XmlWriter obj4 = xmlWriter_0;
			status = (byte)_FuelState;
			obj4.WriteElementString("FuelState", status.ToString());
			XmlWriter obj5 = xmlWriter_0;
			status = (byte)_WeaponState;
			obj5.WriteElementString("WeaponState", status.ToString());
			if (predicateVal != 0)
			{
				XmlWriter obj6 = xmlWriter_0;
				status = (byte)predicateVal;
				obj6.WriteElementString("SBR", status.ToString());
			}
			if (_SingletonVal != 0)
			{
				XmlWriter obj7 = xmlWriter_0;
				status = (byte)_SingletonVal;
				obj7.WriteElementString("SBED", status.ToString());
			}
			if (_RecordVal != 0)
			{
				XmlWriter obj8 = xmlWriter_0;
				status = (byte)_RecordVal;
				obj8.WriteElementString("SBEO", status.ToString());
			}
			if (comparatorVal != 0)
			{
				XmlWriter obj9 = xmlWriter_0;
				status = (byte)comparatorVal;
				obj9.WriteElementString("FSBR", status.ToString());
			}
			if (_ItemVal != 0f)
			{
				xmlWriter_0.WriteElementString("SBR_Altitude", XmlConvert.ToString(_ItemVal));
			}
			if (setterVal != 0f)
			{
				xmlWriter_0.WriteElementString("SBR_Altitude_TF", XmlConvert.ToString(setterVal));
			}
			xmlWriter_0.WriteElementString("SBR_TF", XmlConvert.ToString(_CreatorVal));
			XmlWriter obj10 = xmlWriter_0;
			status = (byte)_TemplateVal;
			obj10.WriteElementString("SBR_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("SBED_Altitude", XmlConvert.ToString(m_MappingVal));
			if (m_MockVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_Altitude_TF", XmlConvert.ToString(m_MockVal.Value));
			}
			xmlWriter_0.WriteElementString("SBED_TF", XmlConvert.ToString(tagVal));
			XmlWriter obj11 = xmlWriter_0;
			status = (byte)fieldVal;
			obj11.WriteElementString("SBED_ThrottleSetting", status.ToString());
			if (queueVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(queueVal.Value));
			}
			xmlWriter_0.WriteElementString("SBEO_Altitude", XmlConvert.ToString(regVal));
			xmlWriter_0.WriteElementString("SBEO_Altitude_TF", XmlConvert.ToString(paramVal));
			xmlWriter_0.WriteElementString("SBEO_TF", XmlConvert.ToString(m_PageVal));
			if (m_RulesVal != 0)
			{
				XmlWriter obj2 = xmlWriter_0;
				status = (byte)m_RulesVal;
				obj2.WriteElementString("SBEO_ThrottleSetting", status.ToString());
			}
			xmlWriter_0.WriteElementString("SBPF_Altitude", XmlConvert.ToString(_MethodVal));
			xmlWriter_0.WriteElementString("SBPF_Altitude_TF", XmlConvert.ToString(serviceVal));
			xmlWriter_0.WriteElementString("SBPF_TF", XmlConvert.ToString(m_SystemVal));
			XmlWriter obj3 = xmlWriter_0;
			status = (byte)candidateVal;
			obj3.WriteElementString("SBPF_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("AMP_OC", m_AttrVal.ToString());
			if (!Information.IsNothing(_VisitorVal))
			{
				xmlWriter_0.WriteElementString("AMP_OC_DSO", _VisitorVal.ToString());
			}
			xmlWriter_0.WriteElementString("AMP_OC_DAO", _ExporterVal.ToString());
			xmlWriter_0.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(m_PrototypeVal));
			xmlWriter_0.WriteElementString("DamagePts", XmlConvert.ToString(GetDamagePts()));
			xmlWriter_0.WriteElementString("ReservedSupply", XmlConvert.ToString(ReservedSupply));
			xmlWriter_0.WriteElementString("MembersInheritIcon", XmlConvert.ToString(MembersInheritIcon));
			xmlWriter_0.WriteStartElement("AirFacilities");
			AirFacility[] airFacilities = _AirFacilities;
			AirFacility[] array4 = airFacilities;
			foreach (AirFacility airFacility in array4)
			{
				xmlWriter_0.WriteRaw(airFacility.ToXML(hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			Navigator.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("Group_AI");
			AI.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Group_Kinematics");
			Kinematics.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteEndElement();
			Sensory.ToXML(ref xmlWriter_0);
			Weaponry.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("Group_CommStuff");
			CommStuff.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			AirOps.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteElementString("Type", ((int)Type).ToString());
			xmlWriter_0.WriteStartElement("Center");
			xmlWriter_0.WriteRaw(Center.ToXML(hashSet_0));
			xmlWriter_0.WriteEndElement();
			if (GroupLead != null)
			{
				xmlWriter_0.WriteStartElement("GroupLead");
				GroupLead.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteStartElement("Patrols");
			foreach (Patrol patrol in Patrols)
			{
				patrol.ToXML(ref xmlWriter_0, ref hashSet_0, ref ParentScen);
			}
			xmlWriter_0.WriteEndElement();
			if (!string.IsNullOrEmpty(LastFormationSet))
			{
				xmlWriter_0.WriteElementString("LastFormationSet", LastFormationSet);
				xmlWriter_0.WriteElementString("LastFormationSpacing", XmlConvert.ToString(LastFormationSpacing));
				xmlWriter_0.WriteElementString("LastFormationSpacingUnits", XmlConvert.ToString(LastFormationSpacingUnits));
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100589", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Group()
	{
		Center = new GeoPoint();
		Patrols = new ObservableList<Patrol>();
		ActiveUnit activeUnit_ = this;
		m_InterpreterDic = new Group_Navigator(ref activeUnit_);
		activeUnit_ = this;
		containerDic = new Group_AI(ref activeUnit_);
		activeUnit_ = this;
		_ComposerDic = new Group_Kinematics(ref activeUnit_);
		activeUnit_ = this;
		m_ModelDic = new Group_Sensory(ref activeUnit_);
		activeUnit_ = this;
		m_AdvisorDic = new Group_Weaponry(ref activeUnit_);
		activeUnit_ = this;
		m_CustomerDic = new Group_CommStuff(ref activeUnit_);
		activeUnit_ = this;
		serializerDic = new Group_AirOps(ref activeUnit_);
		Units = new ObservableDictionary<string, ActiveUnit>();
		ReservedSupply = false;
		MembersInheritIcon = false;
		IsGroup = true;
	}

	public new static Group FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			Group group = new Group();
			group.ParentScen = scenario_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(innerText, ' '))
			{
				innerText = innerText.Replace(" ", "-");
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				IEnumerator enumerator6 = null;
				IEnumerator enumerator7 = null;
				IEnumerator enumerator8 = null;
				IEnumerator enumerator9 = null;
				IEnumerator enumerator10 = null;
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					group.CommonFromXML(xmlNode_);
					switch (xmlNode_.Name)
					{
					case "LastFormationSet":
						group.LastFormationSet = xmlNode_.InnerText;
						break;
					case "Group_Kinematics":
					{
						ActiveUnit activeUnit_8 = group;
						group._ComposerDic = Group_Kinematics.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_8);
						break;
					}
					case "Status":
						if (Versioned.IsNumeric(xmlNode_.InnerText))
						{
							group.Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_.InnerText);
						}
						else
						{
							group.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_.InnerText, ignoreCase: true);
						}
						break;
					case "CurrentAltitude":
						group.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", ".")));
						break;
					case "DesiredTurnRate_Navigation":
						group.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Name":
						group.Name = xmlNode_.InnerText;
						break;
					case "DesiredHeading":
						group._DesiredHeading = XmlConvert.ToSingle(xmlNode_.InnerText);
						break;
					case "DamagePts":
						group.SetDamagePts(bool_0: false, null, XmlConvert.ToSingle(xmlNode_.InnerText));
						break;
					case "FuelState":
						group._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Center":
					{
						XmlNode xmlNode_9 = xmlNode_.ChildNodes[0];
						group.Center = GeoPoint.FromXML(ref xmlNode_9, ref concurrentDictionary_0);
						break;
					}
					case "ThrottleSetting":
						switch (xmlNode_.InnerText)
						{
						default:
							group.ThrottleSetting = (Throttle)Conversions.ToByte(xmlNode_.InnerText);
							break;
						case "Loiter":
							group.ThrottleSetting = Throttle.Loiter;
							break;
						case "FullStop":
							group.ThrottleSetting = Throttle.FullStop;
							break;
						case "Full":
							group.ThrottleSetting = Throttle.Full;
							break;
						case "Flank":
							group.ThrottleSetting = Throttle.Flank;
							break;
						case "Cruise":
							group.ThrottleSetting = Throttle.Cruise;
							break;
						}
						break;
					case "LastFormationSpacing":
						group.LastFormationSpacing = XmlConvert.ToSingle(xmlNode_.InnerText);
						break;
					case "Doctrine":
						group.Doctrine = Doctrine.FromXML(ref xmlNode_, group);
						break;
					case "ActiveEnterAreaTriggers":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								string innerText3 = ((XmlNode)enumerator3.Current).InnerText;
								group.ActiveEnterAreaTriggers.Add(innerText3);
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
					case "OnboardCargo":
						try
						{
							enumerator8 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator8.MoveNext())
							{
								XmlNode xmlNode_8 = (XmlNode)enumerator8.Current;
								Cargo cargo = Cargo.FromXML(ref xmlNode_8, ref concurrentDictionary_0, scenario_0, group);
								ArrayExtensions.Add(ref group.OnboardCargo, cargo);
								cargo.ParentPlatform = group;
							}
						}
						finally
						{
							if (enumerator8 is IDisposable)
							{
								(enumerator8 as IDisposable).Dispose();
							}
						}
						break;
					case "Longitude":
						group.SetLongitude(null, XmlConvert.ToDouble(xmlNode_.InnerText.Replace(",", ".")));
						break;
					case "WeaponState":
						group._WeaponState = (_ActiveUnitWeaponState)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							group.ObjectID_Set(xmlNode_.InnerText);
							if (xmlNode_0.ChildNodes.Count != 1)
							{
								concurrentDictionary_0.TryAdd(group.ObjectID, group);
								break;
							}
							scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
							return group;
						}
						return (Group)concurrentDictionary_0[xmlNode_.InnerText];
					case "Group_AirOps":
					{
						ActiveUnit activeUnit_7 = group;
						group.serializerDic = Group_AirOps.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_7);
						break;
					}
					case "UnitClass":
						group.UnitClass = xmlNode_.InnerText;
						break;
					case "Latitude":
						group.SetLatitude(null, XmlConvert.ToDouble(xmlNode_.InnerText.Replace(",", ".")));
						break;
					case "DesiredAltitude":
						group._DesiredAltitude = XmlConvert.ToSingle(xmlNode_.InnerText);
						break;
					case "Comms":
						try
						{
							enumerator6 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator6.MoveNext())
							{
								XmlNode xmlNode_7 = (XmlNode)enumerator6.Current;
								CommDevice commDevice = CommDevice.FromXML(ref xmlNode_7, ref concurrentDictionary_0, group);
								group.AddCommDevice(commDevice);
								commDevice.ParentPlatform = group;
							}
						}
						finally
						{
							if (enumerator6 is IDisposable)
							{
								(enumerator6 as IDisposable).Dispose();
							}
						}
						break;
					case "Latitude_UnitEntersAreaCheck":
						group.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_.InnerText);
						break;
					case "Propulsion":
						try
						{
							enumerator10 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator10.MoveNext())
							{
								XmlNode xmlNode_6 = (XmlNode)enumerator10.Current;
								ActiveUnit activeUnit_6 = group;
								Engine engine = Engine.FromXML(ref xmlNode_6, ref concurrentDictionary_0, ref activeUnit_6);
								group.Propulsion.Add(engine);
								engine.ParentPlatform = group;
							}
						}
						finally
						{
							if (enumerator10 is IDisposable)
							{
								(enumerator10 as IDisposable).Dispose();
							}
						}
						break;
					case "DBID":
						group.DBID = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "LastFormationSpacingUnits":
						group.LastFormationSpacingUnits = XmlConvert.ToByte(xmlNode_.InnerText);
						break;
					case "ActiveRemainAreaTriggers":
					{
						string key = null;
						DateTime result = DateTime.MinValue;
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator4.Current;
								if (Operators.CompareString(xmlNode.Name, "RemainAreaTrigger", TextCompare: false) == 0)
								{
									key = xmlNode.InnerText;
									result = DateTime.MinValue;
									continue;
								}
								if (DateTime.TryParse(xmlNode.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
								{
									group.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText2 = xmlNode.InnerText;
								long result2 = 0L;
								if (long.TryParse(innerText2, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
									group.ActiveRemainAreaTriggers.Add(key, result);
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
						break;
					}
					case "Sensors":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								Sensor sensor = Sensor.FromXML((XmlNode)enumerator2.Current, concurrentDictionary_0, group);
								ArrayExtensions.Add(ref group._Sensors, sensor);
								sensor.ParentPlatform = group;
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
					case "Sensory":
					{
						ActiveUnit activeUnit_5 = group;
						group.m_ModelDic = Group_Sensory.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_5);
						break;
					}
					case "Group_CommStuff":
					{
						ActiveUnit activeUnit_4 = group;
						group.m_CustomerDic = Group_CommStuff.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_4);
						break;
					}
					case "Side":
					{
						group._SideName = xmlNode_.InnerText;
						Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
						Side[] array = sides_ReadOnly;
						foreach (Side side in array)
						{
							if (Operators.CompareString(side.Name, group._SideName, TextCompare: false) == 0)
							{
								group.SetUnitSide(bool_0: false, side);
							}
						}
						break;
					}
					case "Weight":
						group.EmptyWeight = XmlConvert.ToInt32(xmlNode_.InnerText);
						break;
					case "ReservedSupply":
						group.ReservedSupply = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Message":
						group.Message = xmlNode_.InnerText;
						break;
					case "DesiredSpeed":
						group._DesiredSpeed = XmlConvert.ToSingle(xmlNode_.InnerText);
						break;
					case "DesiredTurnRate":
						group.DesiredTurnRate = (TurnRate)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Group_Navigator":
					{
						ActiveUnit activeUnit_3 = group;
						group.m_InterpreterDic = Group_Navigator.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_3);
						break;
					}
					case "CurrentSpeed":
						group.CurrentSpeed = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Group_Weaponry":
					{
						ActiveUnit activeUnit_2 = group;
						group.m_AdvisorDic = Group_Weaponry.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_2);
						break;
					}
					case "Type":
						group.taskDic = (GroupType)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Group_AI":
					{
						ActiveUnit activeUnit_ = group;
						group.containerDic = Group_AI.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_);
						break;
					}
					case "Longitude_UnitEntersAreaCheck":
						group.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_.InnerText);
						break;
					case "Mounts":
						try
						{
							enumerator7 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								XmlNode xmlNode_5 = (XmlNode)enumerator7.Current;
								Mount mount = Mount.FromXML(ref xmlNode_5, ref concurrentDictionary_0, group);
								group.Mounts.Add(mount);
								mount.ParentPlatform = group;
							}
						}
						finally
						{
							if (enumerator7 is IDisposable)
							{
								(enumerator7 as IDisposable).Dispose();
							}
						}
						break;
					case "MembersInheritIcon":
						group.MembersInheritIcon = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "GroupLead":
					{
						if (!xmlNode_.HasChildNodes)
						{
							break;
						}
						XmlNode xmlNode_4 = xmlNode_.ChildNodes[0];
						group.m_FilterDic = ActiveUnit.FromXML(ref xmlNode_4, ref concurrentDictionary_0, ref scenario_0);
						if (group.m_FilterDic == null)
						{
							break;
						}
						object activeUnitsSyncLock = scenario_0.ActiveUnitsSyncLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(activeUnitsSyncLock);
						bool lockTaken = false;
						try
						{
							Monitor.Enter(activeUnitsSyncLock, ref lockTaken);
							if (!scenario_0.ActiveUnits.ContainsKey(group.m_FilterDic.ObjectID))
							{
								scenario_0.ActiveUnits.Add(group.m_FilterDic.ObjectID, group.m_FilterDic);
							}
						}
						finally
						{
							if (lockTaken)
							{
								Monitor.Exit(activeUnitsSyncLock);
							}
						}
						break;
					}
					case "AirFacilities":
						try
						{
							enumerator5 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator5.Current;
								AirFacility airFacility = AirFacility.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref scenario_0);
								group.AddAirFacility(airFacility);
								airFacility.ParentPlatform = group;
							}
						}
						finally
						{
							if (enumerator5 is IDisposable)
							{
								(enumerator5 as IDisposable).Dispose();
							}
						}
						break;
					case "Patrols":
						try
						{
							enumerator9 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator9.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator9.Current;
								Patrol item = Patrol.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref scenario_0);
								group.Patrols.Add(item);
							}
						}
						finally
						{
							if (enumerator9 is IDisposable)
							{
								(enumerator9 as IDisposable).Dispose();
							}
						}
						break;
					case "CurrentHeading":
						group.CurrentHeading = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
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
			if (group.Type == GroupType.AirGroup && group.ThrottleSetting == Throttle.FullStop)
			{
				group.ThrottleSetting = Throttle.Cruise;
			}
			return group;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100590", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Group result3 = new Group();
			ProjectData.ClearProjectError();
			return result3;
		}
	}

	[SpecialName]
	public override double GetLongitude(bool? nullable_0 = null)
	{
		if (GroupLead == null)
		{
			return base.GetLongitude((bool?)null);
		}
		return GroupLead.GetLongitude();
	}

	[SpecialName]
	public override void SetLongitude(bool? nullable_0, double double_0)
	{
		if (GroupLead == null)
		{
			base.SetLongitude((bool?)null, double_0);
		}
		else
		{
			GroupLead.SetLongitude(null, double_0);
		}
	}

	[SpecialName]
	public override double GetLatitude(bool? nullable_0 = null)
	{
		if (GroupLead == null)
		{
			return base.GetLatitude((bool?)null);
		}
		return GroupLead.GetLatitude();
	}

	[SpecialName]
	public override void SetLatitude(bool? nullable_0, double double_0)
	{
		if (GroupLead == null)
		{
			base.SetLatitude((bool?)null, double_0);
		}
		else
		{
			GroupLead.SetLatitude(null, double_0);
		}
	}

	[SpecialName]
	public override float GetCurrentAltitude(bool bool_0 = false)
	{
		if (GroupLead == null)
		{
			return base.GetCurrentAltitude(bool_0: false);
		}
		return GroupLead.GetCurrentAltitude();
	}

	[SpecialName]
	public override void SetCurrentAltitude(bool bool_0, float float_0)
	{
		if (GroupLead == null)
		{
			base.SetCurrentAltitude(bool_0: false, float_0);
		}
		else
		{
			GroupLead.SetCurrentAltitude(bool_0: false, float_0);
		}
	}

	[SpecialName]
	public override Side GetUnitSide(bool bool_0 = false)
	{
		if (_UnitSide == null && Units.Count > 0)
		{
			_UnitSide = Units.Values.ElementAtOrDefault(0).GetUnitSide();
		}
		return _UnitSide;
	}

	[SpecialName]
	public override void SetUnitSide(bool bool_0, Side side_0)
	{
		bool num = side_0 != _UnitSide;
		base.SetUnitSide(bool_0, side_0);
		if (!num || side_0 == null)
		{
			return;
		}
		foreach (ActiveUnit item in Units.Values.ToList())
		{
			item.SetUnitSide(bool_0, side_0);
		}
	}

	[SpecialName]
	private bool HasAirBase()
	{
		foreach (ActiveUnit item in new List<ActiveUnit>(Units.Values))
		{
			if (item.AirFacilities_ReadOnly == null)
			{
				continue;
			}
			AirFacility[] airFacilities_ReadOnly = item.AirFacilities_ReadOnly;
			for (int i = 0; i < airFacilities_ReadOnly.Length; i = checked(i + 1))
			{
				if (airFacilities_ReadOnly[i].AirFacType == AirFacility._AirFacType.Runway && item.IsFixedFacility)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	private bool HasFixedDockFacilities()
	{
		foreach (ActiveUnit value in Units.Values)
		{
			if (!Information.IsNothing(value.DockFacilities_ReadOnly) && value.IsFixedFacility && value.DockFacilities_ReadOnly.Length != 0)
			{
				return true;
			}
		}
		return false;
	}

	public override Mission AssignedMissionOrPackage()
	{
		if (GroupLead == null)
		{
			return null;
		}
		return GroupLead.AssignedMissionOrPackage();
	}

	public override void Set_AssignedMissionOrPackage(Mission mission_0, bool bool_0, bool bool_1, ref Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_0)
	{
		foreach (ActiveUnit value in Units.Values)
		{
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
			value.Set_AssignedMissionOrPackage(mission_0, bool_0, bool_1, ref missionAssignmentAttemptResult_);
		}
		if (GroupLead != null && GroupLead.AssignedMissionOrPackage() == mission_0)
		{
			missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Success;
		}
		else
		{
			missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Fail_Other;
		}
	}

	[SpecialName]
	public override void SetDesiredHeading(TurnRate turnRate_0, float float_0)
	{
		if (GroupLead == null)
		{
			PrintInvocation();
		}
		if (GroupLead != null)
		{
			GroupLead.SetDesiredHeading(turnRate_0, float_0);
		}
	}

	[SpecialName]
	public override bool GetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0)
	{
		if (Type == GroupType.AirGroup && GroupLead != null)
		{
			return GroupLead.GetDesiredAltitude_UseTerrainFollowing(GroupLead);
		}
		return false;
	}

	[SpecialName]
	public override void SetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0, bool bool_0)
	{
		if (Type == GroupType.AirGroup && GroupLead != null)
		{
			GroupLead.SetDesiredAltitude_UseTerrainFollowing(GroupLead, bool_0);
		}
	}

	public override Sensor[] Sensors_ReadOnly()
	{
		Sensor[] gparam_ = new Sensor[0];
		try
		{
			foreach (ActiveUnit value in Units.Values)
			{
				if (value != null)
				{
					Sensor[] gparam_2 = value.Sensors_Cached;
					if (gparam_2 != null)
					{
						gparam_ = ArrayExtensions.Join(ref gparam_, ref gparam_2);
					}
				}
			}
			return gparam_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100595", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Sensor[] result = gparam_;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private GroupType AssetInvocation()
	{
		try
		{
			if (Units.Count == 0)
			{
				return GroupType.AirGroup;
			}
			List<ActiveUnit> list = new List<ActiveUnit>(Units.Values);
			if (IsLandInstallation && HasFixedDockFacilities())
			{
				return GroupType.NavalBase;
			}
			if (HasAirBase())
			{
				return GroupType.AirBase;
			}
			if (IsLandInstallation)
			{
				return GroupType.Installation;
			}
			int num = list.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					ActiveUnit activeUnit3 = list[num];
					if (activeUnit3 != null && activeUnit3.IsShip)
					{
						break;
					}
					num += -1;
					continue;
				}
				int num2 = list.Count - 1;
				while (true)
				{
					if (num2 >= 0)
					{
						ActiveUnit activeUnit2 = list[num2];
						if (activeUnit2 != null && activeUnit2.IsSubmarine)
						{
							break;
						}
						num2 += -1;
						continue;
					}
					int num3 = list.Count - 1;
					while (true)
					{
						if (num3 >= 0)
						{
							ActiveUnit activeUnit = list[num3];
							if (activeUnit != null && activeUnit.IsAircraft)
							{
								break;
							}
							num3 += -1;
							continue;
						}
						return GroupType.MobileGroup;
					}
					return GroupType.AirGroup;
				}
				return GroupType.SubGroup;
			}
			return GroupType.SurfaceGroup;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100596", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return GroupType.SurfaceGroup;
		}
	}

	public Group(ref Scenario scenario_0, ref Side side_0, List<ActiveUnit> list_0, bool bool_0 = false, string string_0 = null, Mission mission_0 = null)
		: base(ref scenario_0, string_0)
	{
		Center = new GeoPoint();
		Patrols = new ObservableList<Patrol>();
		ActiveUnit activeUnit_ = this;
		m_InterpreterDic = new Group_Navigator(ref activeUnit_);
		activeUnit_ = this;
		containerDic = new Group_AI(ref activeUnit_);
		activeUnit_ = this;
		_ComposerDic = new Group_Kinematics(ref activeUnit_);
		activeUnit_ = this;
		m_ModelDic = new Group_Sensory(ref activeUnit_);
		activeUnit_ = this;
		m_AdvisorDic = new Group_Weaponry(ref activeUnit_);
		activeUnit_ = this;
		m_CustomerDic = new Group_CommStuff(ref activeUnit_);
		activeUnit_ = this;
		serializerDic = new Group_AirOps(ref activeUnit_);
		Units = new ObservableDictionary<string, ActiveUnit>();
		ReservedSupply = false;
		MembersInheritIcon = false;
		IsGroup = true;
		try
		{
			ParentScen = scenario_0;
			scenario_0.UnitsAutoIncrement++;
			SetUnitSide(bool_0: false, side_0);
			Name = "TemporaryGroupName" + Guid.NewGuid().ToString();
			if (!Information.IsNothing(list_0))
			{
				foreach (ActiveUnit item in list_0)
				{
					if (!item.IsShip || !((Ship)item).IsSinking)
					{
						item.SetParentGroup(bool_0, this);
					}
				}
			}
			PrintInvocation();
			Kinematics.UpdateGroupCenter();
			if (GroupLead != null)
			{
				DesiredSpeed = GroupLead.DesiredSpeed;
				SetDesiredHeading(GroupLead.DesiredTurnRate, GroupLead.DesiredHeading);
				DesiredAltitude = GroupLead.DesiredAltitude;
				SetThrottle(GroupLead.ThrottleSetting);
				Kinematics.DesiredSpeedOverride = null;
			}
			HashSet<Mission> hashSet = new HashSet<Mission>();
			HashSet<Mission.Flight> hashSet2 = new HashSet<Mission.Flight>();
			foreach (ActiveUnit value in Units.Values)
			{
				if (!Information.IsNothing(value.AssignedMissionOrPackage()))
				{
					hashSet.Add(value.AssignedMissionOrPackage());
					if (!Information.IsNothing(value.Navigator.GetFlight()))
					{
						hashSet2.Add(value.Navigator.GetFlight());
					}
				}
			}
			bool flag = false;
			if (hashSet.Count == 1)
			{
				Mission mission_ = hashSet.ElementAtOrDefault(0);
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				Set_AssignedMissionOrPackage(mission_, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
				if (hashSet2.Count > 0 && hashSet.ElementAtOrDefault(0).RestartValue())
				{
					foreach (Mission.Flight flight in hashSet.ElementAtOrDefault(0).FlightList)
					{
						foreach (Mission.Flight item2 in hashSet2)
						{
							if (flight == item2)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
			}
			if (!flag)
			{
				foreach (ActiveUnit value2 in Units.Values)
				{
					value2.Navigator.ClearFlight();
				}
			}
			foreach (ActiveUnit value3 in Units.Values)
			{
				if (!Information.IsNothing(value3.AssignedMissionOrPackage()))
				{
					hashSet.Add(value3.AssignedMissionOrPackage());
				}
			}
			bool flag2 = false;
			string text = null;
			if (!Information.IsNothing(list_0))
			{
				foreach (ActiveUnit item3 in list_0)
				{
					if (item3.IsAircraft && string.IsNullOrEmpty(text))
					{
						flag2 = true;
						if (item3.Navigator.HasFlight)
						{
							text = item3.Navigator.GetFlight().Callsign;
						}
					}
				}
			}
			if (flag2)
			{
				if (string.IsNullOrEmpty(text))
				{
					Name = "飞行编队" + Conversions.ToString(scenario_0.UnitsAutoIncrement);
				}
				else
				{
					Name = "飞行编队" + text;
				}
			}
			else
			{
				Name = "编队" + Conversions.ToString(scenario_0.UnitsAutoIncrement);
			}
			activeUnit_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_0);
			scenario_0.Groups.Add(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100597", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void PrintInvocation()
	{
		try
		{
			taskDic = AssetInvocation();
			if (Units.Count == 1)
			{
				SetGroupLead(Units.Values.FirstOrDefault());
			}
			else if (Type != GroupType.AirBase && Type != GroupType.Installation && Type != GroupType.MobileGroup && Type != GroupType.NavalBase)
			{
				ActiveUnit activeUnit = DefineInvocation(bool_0: true);
				if (activeUnit == null)
				{
					activeUnit = DefineInvocation(bool_0: false);
				}
				SetGroupLead(activeUnit);
			}
			else
			{
				SetGroupLead(Units.Values.FirstOrDefault());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100598", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private ActiveUnit DefineInvocation(bool bool_0)
	{
		double num = 0.0;
		List<ActiveUnit> list = new List<ActiveUnit>(Units.Values);
		ActiveUnit activeUnit = null;
		foreach (ActiveUnit item in list)
		{
			bool flag = true;
			if (bool_0)
			{
				flag = (item.IsAircraft & (item.Navigator.GetFlight(bool_1: false) != null)) && item.Navigator.GetFlight(bool_1: false).FlightPlan != null && item.Navigator.GetFlight(bool_1: false).FlightPlan.Count() > 0;
			}
			if (!(((activeUnit == null) | ((double)item.EmptyWeight > num)) && flag))
			{
				continue;
			}
			activeUnit = item;
			num = item.EmptyWeight;
			try
			{
				if (bool_0)
				{
					activeUnit.SetDesiredHeading(activeUnit.DesiredTurnRate, Module_Unit.BearingToPoint_True(this, activeUnit.Navigator.GetFlight(bool_1: false).FlightPlan[0].Latitude, activeUnit.Navigator.GetFlight(bool_1: false).FlightPlan[0].Longitude));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100599", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		return activeUnit;
	}

	internal void PublishInvocation(ActiveUnit activeUnit_0)
	{
		SetGroupLead(activeUnit_0);
	}

	public bool IsSurfaceGroup()
	{
		return Type == GroupType.SurfaceGroup;
	}

	public override void AttemptToSetNewAssignedHost(ActiveUnit activeUnit_0, bool bool_0 = false, bool bool_1 = false)
	{
		bool num = !activeUnit_0.IsGroup;
		bool flag = false;
		bool flag2 = false;
		if (activeUnit_0.IsGroup)
		{
			if (((Group)activeUnit_0).Type == GroupType.AirBase)
			{
				flag2 = true;
			}
			else
			{
				flag = true;
			}
		}
		if (num || flag2)
		{
			short num2 = (short)Units.Count;
			short num3 = 0;
			foreach (ActiveUnit value in Units.Values)
			{
				bool flag3;
				if (value.IsAircraft)
				{
					if (flag3 = Operators.CompareString(((Aircraft)value).AirOps.ThisUnitCanHostMe(activeUnit_0), "OK", TextCompare: false) == 0)
					{
						((Aircraft)value).AirOps.SetAssignedHostUnit(bool_0: false, activeUnit_0);
					}
				}
				else if (flag3 = Operators.CompareString(value.DockingOps.ThisUnitCanHostMe(activeUnit_0), "OK", TextCompare: false) == 0)
				{
					value.DockingOps.SetAssignedHostUnit(bool_0: false, activeUnit_0);
				}
				if (flag3)
				{
					num3++;
				}
			}
			if (Type == GroupType.AirGroup)
			{
				if (num3 == num2)
				{
					ParentScen.AddMessage("现在所有组中的单元都将" + activeUnit_0.Name + "作为他们的基地。", Name + " 现在全部重新指定基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
				else if (num3 == 0)
				{
					ParentScen.AddMessage("组中没有单元切换到" + activeUnit_0.Name + "作为他们的基地。", "这些单元" + Name + " 都未改变基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
				else
				{
					ParentScen.AddMessage("部分成功：仅限" + Conversions.ToString((int)num3) + "个（共" + Conversions.ToString((int)num2) + "这个组中的单元已切换到" + activeUnit_0.Name + "作为他们的基地。", Name + " 部分重新设定基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
			}
			else if (num3 == num2)
			{
				ParentScen.AddMessage("现在所有组中的单元都将" + activeUnit_0.Name + "作为他们的基地。", Name + " 现在全部重新指定基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			else if (num3 == 0)
			{
				ParentScen.AddMessage("组中没有单元切换到" + activeUnit_0.Name + "作为他们的基地。", "这些单元" + Name + " 都未改变基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			else
			{
				ParentScen.AddMessage("部分成功：仅限" + Conversions.ToString((int)num3) + "个（共" + Conversions.ToString((int)num2) + "这个组中的单元已切换到" + activeUnit_0.Name + "作为他们的基地。", Name + " 部分重新设定基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
		}
		if (!flag)
		{
			return;
		}
		short num4 = (short)Units.Count;
		short num5 = 0;
		foreach (ActiveUnit value2 in Units.Values)
		{
			foreach (ActiveUnit value3 in ((Group)activeUnit_0).Units.Values)
			{
				bool flag4;
				if (value2.IsAircraft)
				{
					if (flag4 = Operators.CompareString(((Aircraft)value2).AirOps.ThisUnitCanHostMe(value3), "OK", TextCompare: false) == 0)
					{
						((Aircraft)value2).AirOps.SetAssignedHostUnit(bool_0: false, value3);
					}
				}
				else if (flag4 = Operators.CompareString(value2.DockingOps.ThisUnitCanHostMe(value3), "OK", TextCompare: false) == 0)
				{
					value2.DockingOps.SetAssignedHostUnit(bool_0: false, value3);
				}
				if (flag4)
				{
					num5++;
				}
			}
		}
		if (Type == GroupType.AirGroup)
		{
			if (num5 == num4)
			{
				ParentScen.AddMessage("现在所有组中的单元都将" + activeUnit_0.Name + "作为他们的基地。", Name + " 现在全部重新指定基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide());
				return;
			}
			if (num5 == 0)
			{
				ParentScen.AddMessage("组中没有单元切换到" + activeUnit_0.Name + "作为他们的基地。", "这些单元" + Name + " 都未改变基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide());
				return;
			}
			ParentScen.AddMessage("部分成功：仅限" + Conversions.ToString((int)num5) + "个（共" + Conversions.ToString((int)num4) + "该组中的单元已切换为组中的单元：" + activeUnit_0.Name + "作为他们的基地。", Name + " 部分重新设定基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide());
		}
		else if (num5 == num4)
		{
			ParentScen.AddMessage("编队中的所有单元现在都有不同的单元" + activeUnit_0.Name + "作为他们的基地。", Name + " 现在全部重新指定基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide());
		}
		else if (num5 == 0)
		{
			ParentScen.AddMessage("组中没有单元切换到" + activeUnit_0.Name + "作为他们的基地。", "这些单元" + Name + " 都未改变基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide());
		}
		else
		{
			ParentScen.AddMessage("部分成功：仅限" + Conversions.ToString((int)num5) + "个（共" + Conversions.ToString((int)num4) + "该组中的单元已切换为组中的单元：" + activeUnit_0.Name + "作为他们的基地。", Name + " 部分重新设定基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide());
		}
	}

	public override bool IsOperating()
	{
		GroupType type = Type;
		if ((int)type > 2 && type != GroupType.MobileGroup)
		{
			return true;
		}
		if (GroupLead == null)
		{
			return false;
		}
		return GroupLead.IsOperating();
	}

	public override void SetThrottle(Throttle throttle_0, float? nullable_0 = null)
	{
		if (GroupLead != null)
		{
			if (nullable_0.HasValue)
			{
				GroupLead.DesiredSpeed = nullable_0.Value;
			}
			else
			{
				GroupLead.DesiredSpeed = Kinematics.GroupMaxSpeedForThisThrottleSetting(throttle_0);
			}
			ThrottleSetting = throttle_0;
			GroupLead.SetThrottle(throttle_0, nullable_0);
			GroupLead.Kinematics.DesiredSpeedOverride = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), (Throttle)Kinematics.ThrottlePreset, bool_0: false);
		}
	}

	public List<Module_Unit.Unit> ToList()
	{
		return ((IEnumerable<ActiveUnit>)Units.Values).Select((Func<ActiveUnit, Module_Unit.Unit>)((ActiveUnit theAU) => theAU)).ToList();
	}

	public override void Teleport(ref Scenario scenario_0, double double_0, double double_1)
	{
		try
		{
			GroupLead.Teleport(ref scenario_0, double_0, double_1);
			if (Navigator.HasPlottedCourse())
			{
				CurrentHeading = Module_Unit.BearingToPoint_True(this, Navigator.PlottedCourse[0].Latitude, Navigator.PlottedCourse[0].Longitude);
			}
			foreach (ActiveUnit value in Units.Values)
			{
				if (!value.IsGroupLead())
				{
					Tuple<double, double> latitudeAndLongitude = value.Navigator.UnitFormationStation.GetLatitudeAndLongitude(value, GroupLead);
					value.SetLatitude(null, latitudeAndLongitude.Item1);
					value.SetLongitude(null, latitudeAndLongitude.Item2);
					value.CurrentHeading = CurrentHeading;
				}
			}
			SetLatitude(null, double_1);
			SetLongitude(null, double_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100600", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetGroupLead(ActiveUnit activeUnit_0)
	{
		m_FilterDic = activeUnit_0;
		if (m_FilterDic != null)
		{
			SetLatitude(null, m_FilterDic.GetLatitude());
			SetLongitude(null, m_FilterDic.GetLongitude());
		}
	}

	public override void Destroy(bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		try
		{
			try
			{
				ParentScen.Groups.Remove(this);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ParentScen.Groups.Remove(this);
				ProjectData.ClearProjectError();
			}
			List<ActiveUnit> list = new List<ActiveUnit>();
			list.AddRange(Units.Values);
			foreach (ActiveUnit item in list)
			{
				if (item != null)
				{
					item.SetParentGroup(bool_0: false, null);
					item.Navigator.ClearPlottedCourse();
					Waypoint[] plottedCourse = Navigator.PlottedCourse;
					Waypoint[] array = plottedCourse;
					foreach (Waypoint waypoint_ in array)
					{
						item.Navigator.AddWaypoint(waypoint_);
					}
				}
			}
			base.Destroy(bool_0, bool_1, bool_2, string_0, string_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100601", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AwakeInvocation(ActiveUnit activeUnit_0)
	{
		taskDic = null;
		if (!m_ErrorDic)
		{
			PrintInvocation();
		}
		m_CodeDic?.Invoke(this, activeUnit_0);
	}

	private void QueryInvocation(ActiveUnit activeUnit_0)
	{
		taskDic = null;
		try
		{
			if (!m_ErrorDic && GroupLead == activeUnit_0)
			{
				PrintInvocation();
			}
			if (Units.Count < 1)
			{
				ParentScen.DestroyThisUnit(this, "Group dissolving");
				if (!string.IsNullOrEmpty(Name))
				{
					AddMessage(Name + "没有单元;解散...", "Grouping", LoggedMessage.MessageType.UI, 5, bool_0: true, new Geopoint_Struct(0.0, 0.0));
				}
				ParentScen.DeleteUnitImmediately(ObjectID, bool_0: true, "Group dissolving");
			}
			else if (Type == GroupType.AirGroup && activeUnit_0.FlightRole == Mission.Flight.FlightElement.LeadElement && ((Aircraft)activeUnit_0).Navigator.HasFlightPlan)
			{
				if (GroupLead.Navigator.GetFlight() != null)
				{
					GroupLead.Navigator.GetFlight().FlightPlan = ((Aircraft)activeUnit_0).Navigator.GetFlight().FlightPlan;
				}
				ActiveUnit groupLead = GroupLead;
				if (groupLead != null)
				{
					groupLead.FlightRole = Mission.Flight.FlightElement.LeadElement;
				}
			}
			m_ConnectionDic?.Invoke(this, activeUnit_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100602", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ResetInvocation(object sender, NotifyDictionaryChangedEventArgs<string, ActiveUnit> e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Remove:
			QueryInvocation(e.OldItem.Value);
			break;
		case NotifyCollectionChangedAction.Add:
			AwakeInvocation(e.NewItem.Value);
			break;
		}
	}

	public override bool CanMoveToThisLocation(double double_0, double double_1, ref int int_0, bool bool_0, bool bool_1, bool bool_2, ref bool bool_3, bool bool_4, ref bool bool_5, float? nullable_0, short? nullable_1, ref List<ActiveUnit> list_0, float float_0, bool bool_6, bool bool_7, ref string string_0, ref bool bool_8)
	{
		if (GroupLead != null && GroupLead.IsActiveUnit)
		{
			return GroupLead.CanMoveToThisLocation(double_0, double_1, ref int_0, bool_0, bool_1, bool_2, ref bool_3, bool_4, ref bool_5, nullable_0, nullable_1, ref list_0, float_0, bool_6, bool_7, ref string_0, ref bool_8);
		}
		return false;
	}

	private void MapInvocation(object object_0, ObservableListModified<Patrol> observableListModified_0)
	{
		GetUnitSide().MissionsTotal_Reset();
	}

	private void SortInvocation(object object_0, ObservableListModified<Patrol> observableListModified_0)
	{
		GetUnitSide().MissionsTotal_Reset();
	}
}
