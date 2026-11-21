using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_AI : ActiveUnit_AI
{
	private Vehicle mapperProxy;

	[SpecialName]
	private Vehicle GetVehicle()
	{
		if (mapperProxy == null)
		{
			mapperProxy = (Vehicle)m_EventVal;
		}
		return mapperProxy;
	}

	public static Vehicle_AI FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Vehicle_AI vehicle_AI = new Vehicle_AI(ref activeUnit_0);
			vehicle_AI.m_EventVal = activeUnit_0;
			if (Operators.CompareString(xmlNode_0.ChildNodes[0].Name, "ActiveUnit_AI", TextCompare: false) == 0)
			{
				xmlNode_0 = xmlNode_0.ChildNodes[0];
			}
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
					case "PrimaryTarget":
					case "PTarget":
						vehicle_AI._PrimaryTarget = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "PrimaryThreat":
					case "PThreat":
						vehicle_AI._PrimaryThreat = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "Threats":
						if (vehicle_AI._Threats == null)
						{
							vehicle_AI._Threats = new List<Contact>();
						}
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
								Contact item = Contact.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
								vehicle_AI._Threats.Add(item);
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
					case "TTNPTE":
						vehicle_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "IE":
						vehicle_AI.IsEscort = true;
						break;
					case "PrimaryTarget_LastKnown_Lon":
						vehicle_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "TargetList":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_, ref concurrentDictionary_0);
								if (targetingEntry.Target != null && !vehicle_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
								{
									vehicle_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
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
						break;
					case "PrimaryTarget_LastKnown_Lat":
						vehicle_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "HP":
					case "HPos":
						vehicle_AI.HoldPosition = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Alt":
						vehicle_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "IgnorePlottedCourse":
					case "IPC":
					{
						bool num = Conversions.ToBoolean(xmlNode.InnerText);
						if (!Information.IsNothing(activeUnit_0.Doctrine))
						{
							activeUnit_0.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, (Doctrine._UseIgnorePlottedCourse)(-(Conversions.ToBoolean(xmlNode.InnerText) ? 1 : 0)));
						}
						if (num && !Information.IsNothing(activeUnit_0.AssignedMissionOrPackage()))
						{
							Mission mission = activeUnit_0.AssignedMissionOrPackage();
							if (mission.MissionClass == Mission._MissionClass.Patrol)
							{
								mission.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
							}
						}
						break;
					}
					case "PTOE":
					case "PrimaryTargetOverrideExists":
						vehicle_AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode.InnerText);
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
			return vehicle_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100545", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Vehicle_AI result = new Vehicle_AI(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Vehicle_AI(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}

	public FuelRec._FuelType SelectFuelTypeToConsume(Engine engine_0)
	{
		switch (engine_0.Type)
		{
		case Engine.EngineType.AIP:
			if (m_EventVal.Propulsion.Where((Engine theE) => theE.Type == Engine.EngineType.Electric).Count() == 0)
			{
				return FuelRec._FuelType.Battery;
			}
			return FuelRec._FuelType.AirIndepedent;
		default:
			return FuelRec._FuelType.NoFuel;
		case Engine.EngineType.Electric:
			return FuelRec._FuelType.Battery;
		case Engine.EngineType.Diesel:
			return FuelRec._FuelType.DieselFuel;
		}
	}

	internal void ForgotWatcher()
	{
		if (m_EventVal == null || m_EventVal.Propulsion.Count == 0)
		{
			return;
		}
		new Dictionary<int, Engine>();
		if (m_EventVal.Propulsion.Count == 1)
		{
			GetVehicle().PrimaryEngine = m_EventVal.Propulsion[0];
		}
		try
		{
			if (Module_Unit.ResetTokenizer(GetVehicle()))
			{
				Engine engine = m_EventVal.Propulsion.Where((Engine theE) => theE.CanBeUsedOverland()).FirstOrDefault();
				if (engine != null)
				{
					GetVehicle().PrimaryEngine = engine;
				}
			}
			else
			{
				Engine engine2 = m_EventVal.Propulsion.Where((Engine theE) => theE.CanBeUsedOnWater()).FirstOrDefault();
				if (engine2 != null)
				{
					GetVehicle().PrimaryEngine = engine2;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100812", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool CollectWatcher()
	{
		if (m_EventVal.IsGroupMember())
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			foreach (ActiveUnit value in m_EventVal.GetParentGroup().Units.Values)
			{
				if (value != null && value != m_EventVal)
				{
					switch (value.DesignatedSupplier)
					{
					case ActiveUnit_DockingOps.ResupplyCapacity.Fuel:
						list.Add(value);
						break;
					case ActiveUnit_DockingOps.ResupplyCapacity.Material:
						list2.Add(value);
						break;
					case ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial:
						list.Add(value);
						list2.Add(value);
						break;
					}
				}
			}
			double double_ = 0.0;
			double double_2 = 0.0;
			if (list.Count > 0 && (int)Math.Round(m_EventVal.FuelPercent(ref double_, ref double_2, bool_0: false) * 100.0) < 5)
			{
				foreach (ActiveUnit item in list)
				{
					if (m_EventVal.DockingOps.IncludeDic(m_EventVal.AI.LoginClient(), item, null, bool_0: false, null, ActiveUnit_DockingOps.ResupplyRequest.Fuel).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
						m_EventVal.AddMessage(m_EventVal.Name + " is automatically refueling from group member " + item.Name + " (Reason: Fuel exhausted). ", "Unit refueling", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
						return true;
					}
				}
			}
			if (list2.Count > 0)
			{
				Weapon weapon = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
				if (weapon == null || m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, bool_1: false) > 0)
				{
					weapon = m_EventVal.Weaponry.PrimaryDefenceWeapon_Default;
				}
				if (weapon != null && m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, bool_1: false) == 0)
				{
					foreach (ActiveUnit item2 in list2)
					{
						if (item2.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, bool_1: false) > 0 && m_EventVal.DockingOps.IncludeDic(m_EventVal.AI.LoginClient(), item2, null, bool_0: false, null, ActiveUnit_DockingOps.ResupplyRequest.Material).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
							m_EventVal.AddMessage(m_EventVal.Name + " is automatically re-arming from group member " + item2.Name + " (Reason: " + weapon.Name + " ammunition exhausted). ", "Unit re-arming", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	public override void EvaluateUnitStatus(float float_0, bool bool_0, bool bool_1)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			EvaluateUnitCargoStatus(float_0);
			byte? b = (byte?)m_EventVal.Doctrine.GetAutoEvade(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (_PrimaryThreat != null)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					m_EventVal.Status = m_EventVal._SingletonVal;
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Refuelling || m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo || m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo || m_EventVal.IsRTB || (GetVehicle().IsMobileGroundUnit && m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse && !m_EventVal.IsRTB && (InsertClient() || CollectWatcher())))
			{
				return;
			}
			if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				bool? flag;
				if (Information.IsNothing(PrimaryTarget))
				{
					flag = false;
				}
				else
				{
					b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
					flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
				}
				bool? flag2 = flag;
				if (((!flag2) ?? flag2).GetValueOrDefault())
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					return;
				}
			}
			if (PrimaryTarget != null && (int)PrimaryTarget.Type > 1)
			{
				bool flag3 = true;
				if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
					if (strike.MaxResponseRadius_Ship > 0 || strike.MinResponseRadius_Ship > 0)
					{
						float num = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
						if (num > (float)strike.MaxResponseRadius_Ship || num < (float)strike.MinResponseRadius_Ship)
						{
							flag3 = false;
						}
					}
				}
				if (flag3)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					return;
				}
			}
			if (m_EventVal.IsGroupMember())
			{
				if (m_EventVal.GetParentGroup().Type == Group.GroupType.AirGroup && m_EventVal.GetParentGroup().Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
					return;
				}
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					EvaluateTargets(float_0, bool_0: false, bool_1: true);
				}
			}
			if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().IsActive && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
			{
				switch (m_EventVal.AssignedMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Cargo:
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.Strike:
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.Patrol:
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
					return;
				case Mission._MissionClass.Support:
					if (Information.IsNothing(PrimaryTarget))
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
					}
					else
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					}
					return;
				}
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver || m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker || m_EventVal.WeaponState == ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
			{
				return;
			}
			if (base.PrimaryPickupTarget != null)
			{
				if (m_EventVal.Navigator.HasPlottedCourse())
				{
					ActiveUnit_Navigator navigator = m_EventVal.Navigator;
					double latitude = m_EventVal.GetLatitude();
					double longitude = m_EventVal.GetLongitude();
					double latitude2 = m_EventVal.Navigator.PlottedCourse[0].Latitude;
					double longitude2 = m_EventVal.Navigator.PlottedCourse[0].Longitude;
					int int_ = 0;
					GeoPoint geoPoint_ = null;
					if (navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: true, null, ref int_, ref geoPoint_))
					{
						m_EventVal.Navigator.PlotCourseToPickupPoint();
						if (!m_EventVal.Navigator.HasPlottedCourse())
						{
							m_EventVal.AddMessage(m_EventVal.Name + " is unable to reach cargo pick up target " + base.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							m_EventVal.AI.RemovePickupTarget(base.PrimaryPickupTarget.ObjectID);
						}
					}
				}
				else if (Module_Unit.RangeToUnit_Horiz(m_EventVal, base.PrimaryPickupTarget) < 2f)
				{
					m_EventVal.DockingOps.SettleForCargoTransfer();
				}
				else
				{
					m_EventVal.Navigator.PlotCourseToPickupPoint();
					if (m_EventVal.Navigator.HasPlottedCourse())
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						return;
					}
					m_EventVal.AddMessage(m_EventVal.Name + " is unable to reach cargo pick up target " + base.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
					m_EventVal.AI.RemovePickupTarget(base.PrimaryPickupTarget.ObjectID);
				}
			}
			if (m_EventVal.Status != 0)
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200346", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon[] OrderWatcher()
	{
		return m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			if (m_EventVal.Mounts.Count == 0 && m_EventVal.Sensors_Cached.Length == 0)
			{
				if (!Information.IsNothing(PrimaryTarget))
				{
					DropTarget(PrimaryTarget);
				}
				if (base.Targets_ReadOnly.Length == 0)
				{
					return;
				}
				List<Contact> list = new List<Contact>();
				Contact[] targets_ReadOnly = base.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact item in array)
				{
					list.Add(item);
				}
				{
					foreach (Contact item2 in list)
					{
						DropTarget(item2);
					}
					return;
				}
			}
			base.EvaluateTargets(float_0, bool_0, bool_1: false);
			if (m_EventVal == null || (m_EventVal.IsFixedFacility && m_EventVal.Mounts.Count == 0))
			{
				return;
			}
			Mission mission = m_EventVal.AssignedMissionOrPackage();
			List<Weapon> list2 = m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual();
			Weapon weapon = null;
			Weapon weapon2 = null;
			Weapon weapon3 = null;
			Weapon weapon4 = null;
			foreach (Weapon item3 in list2)
			{
				if (Information.IsNothing(weapon))
				{
					if (item3.MaxAirRange > 0f)
					{
						weapon = item3;
					}
				}
				else if (item3.MaxAirRange > weapon.MaxAirRange)
				{
					weapon = item3;
				}
				if (Information.IsNothing(weapon2))
				{
					if (item3.MaxSurfaceRange > 0f)
					{
						weapon2 = item3;
					}
				}
				else if (item3.MaxSurfaceRange > weapon2.MaxSurfaceRange)
				{
					weapon2 = item3;
				}
				if (Information.IsNothing(weapon3))
				{
					if (item3.MaxLandRange > 0f)
					{
						weapon3 = item3;
					}
				}
				else if (item3.MaxLandRange > weapon3.MaxLandRange)
				{
					weapon3 = item3;
				}
				if (Information.IsNothing(weapon4))
				{
					if (item3.MaxSubsurfaceRange > 0f)
					{
						weapon4 = item3;
					}
				}
				else if (item3.MaxSubsurfaceRange > weapon4.MaxSubsurfaceRange)
				{
					weapon4 = item3;
				}
			}
			if (Information.IsNothing(weapon) && Information.IsNothing(weapon2) && Information.IsNothing(weapon4) && Information.IsNothing(weapon3) && (m_EventVal.IsFixedFacility || HoldPosition))
			{
				return;
			}
			Contact[] targets_ReadOnly2 = base.Targets_ReadOnly;
			bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
			List<Contact> list3 = ChangeClient(targets_ReadOnly2);
			List<Weapon> list4 = new List<Weapon>();
			list4.AddRange(OrderWatcher());
			Doctrine._UseShootTourists? shootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if (PrintClient() == null)
			{
				DefineClient(Module_ActiveUnit_Sensory.ListTokenizer(m_EventVal.Sensory));
			}
			int count = PrintClient().Count;
			if (m_AccountVal == null)
			{
				m_AccountVal = new Tuple<Contact, Misc.PostureStance>[count - 1 + 1];
			}
			int int_;
			if (mission != null && mission.IsActive)
			{
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					Contact contact = PrintClient()[i];
					if ((!bool_1 && contact.Type != Contact_Base.ContactType.Missile && (contact.Type != 0 || !m_EventVal.ParentScen.FifthSecondIsChangingOnThisPulse) && !m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse) || (_TargetList != null && _TargetList.ContainsKey(contact.ObjectID)) || new bool?(contact.GetIsDestroyed(m_EventVal.ParentScen)).GetValueOrDefault() || list3.Contains(contact))
					{
						continue;
					}
					byte? b = (byte?)contact.BDA_StructuralIntegrity;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						continue;
					}
					Misc.PostureStance value;
					if (m_AccountVal[i] == null)
					{
						if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out value))
						{
							value = contact.GetStance(m_EventVal.GetUnitSide());
						}
						m_AccountVal[i] = new Tuple<Contact, Misc.PostureStance>(contact, value);
					}
					else
					{
						value = m_AccountVal[i].Item2;
					}
					Contact contact_ = contact;
					Doctrine._UseShootTourists? nullable_ = shootTourists;
					Misc.PostureStance? nullable_2 = value;
					string string_ = "";
					int_ = 0;
					if (!ContactIsRelevantToMission(contact_, mission, nullable_, bool_0, isInsidePatrolArea_10nmBuffer, bool_2: true, nullable_2, ref string_, ref int_))
					{
						continue;
					}
					switch (value)
					{
					case Misc.PostureStance.Unknown:
						TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						break;
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Hostile:
						if (!PopClient(contact) && (contact.Type != Contact_Base.ContactType.Submarine || (!contact.IsClassifiedFalseTarget && !SeaIceProvider.PrepareWriter(contact.GetLongitude(), contact.GetLatitude()))))
						{
							ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
							Contact contact_2 = contact;
							Doctrine doctrine = m_EventVal.Doctrine;
							string_ = "";
							int_ = 0;
							if (weaponry.PopConsumer(contact_2, bool_1: true, doctrine, ref string_, ref int_, list4))
							{
								TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							}
						}
						break;
					}
				}
			}
			if (m_EventVal.IsOnActivePatrol)
			{
				Patrol patrol = (Patrol)mission;
				GlobalVariables.PatrolType type = patrol.Type;
				if ((int)type <= 1 || (int)(type - 3) <= 3)
				{
					if (patrol.GetInvestigateWithinWeaponRange(m_EventVal.ParentScen))
					{
						weapon2 = m_EventVal.Weaponry.CountFacade(null, bool_1: false);
						weapon3 = m_EventVal.Weaponry.CustomizeFacade(null, bool_1: false);
					}
					else
					{
						weapon2 = null;
						weapon3 = null;
					}
				}
			}
			bool flag = m_EventVal.IsOnActivePatrol && ((Patrol)mission).HasProsecutionArea;
			int_ = count - 1;
			for (int j = 0; j <= int_; j++)
			{
				Contact contact2 = PrintClient()[j];
				if (m_EventVal == null || contact2 == null || (_TargetList != null && _TargetList.ContainsKey(contact2.ObjectID)) || list3.Contains(contact2))
				{
					continue;
				}
				Misc.PostureStance value2;
				if (m_AccountVal[j] == null)
				{
					if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact2.ObjectID, out value2))
					{
						value2 = contact2.GetStance(m_EventVal.GetUnitSide());
					}
				}
				else
				{
					value2 = m_AccountVal[j].Item2;
				}
				if (value2 == Misc.PostureStance.Neutral || value2 == Misc.PostureStance.Friendly)
				{
					continue;
				}
				byte? b2 = (byte?)contact2.BDA_StructuralIntegrity;
				if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					continue;
				}
				if (!flag && mission != null && mission.MissionClass == Mission._MissionClass.Patrol && !contact2.IsAir_Missile_Submarine_Contact && !((Patrol)mission).GetInvestigateOutsidePatrolArea(m_EventVal.ParentScen))
				{
					Patrol patrol2 = (Patrol)mission;
					if (!contact2.GetIsInsideThisArea(patrol2.PatrolArea, m_EventVal.ParentScen, bool_0: true) && TargetingBehaviorForThisTarget(contact2) != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !m_EventVal.Sensory.IsIlluminatingThisContact(contact2))
					{
						continue;
					}
				}
				contact2.GetIsDestroyed(m_EventVal.ParentScen);
				ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
				Contact contact_3 = contact2;
				Doctrine doctrine2 = m_EventVal.Doctrine;
				string string_2 = "";
				int int_2 = 0;
				if (weaponry2.PopConsumer(contact_3, bool_1: true, doctrine2, ref string_2, ref int_2, list4) && TargetIsEligibleBasedOnWeaponRange(contact2, value2, shootTourists.HasValue, shootTourists.Value, weapon, weapon2, weapon3, weapon4))
				{
					TargetThisContact(contact2, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100547", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool RegisterWatcher(Weapon weapon_0)
	{
		if (weapon_0 == null)
		{
			return false;
		}
		IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = GetVehicle().MobileUnitCategory;
		if ((mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM) || (!weapon_0.ValidTargets.MobileTarget_Hard && !weapon_0.ValidTargets.MobileTarget_Soft && !weapon_0.ValidTargets.MobileTarget_Personnel && !weapon_0.ValidTargets.LandStructure_Hard && !weapon_0.ValidTargets.LandStructure_Soft))
		{
			if (GetVehicle().IsHardTarget)
			{
				if (weapon_0.ValidTargets.MobileTarget_Hard)
				{
					return true;
				}
			}
			else if (weapon_0.ValidTargets.MobileTarget_Hard || weapon_0.ValidTargets.MobileTarget_Soft || weapon_0.ValidTargets.MobileTarget_Personnel)
			{
				return true;
			}
			if (weapon_0.ValidTargets.Radar && m_EventVal.HasRadarSensor)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public override void EvaluateThreats()
	{
		if (m_EventVal == null || m_EventVal.IsFixedFacility || HoldPosition)
		{
			return;
		}
		try
		{
			ClearAllThreats();
			bool flag = false;
			if (PrintClient() == null)
			{
				DefineClient(Module_ActiveUnit_Sensory.ListTokenizer(m_EventVal.Sensory));
			}
			int count = PrintClient().Count;
			m_AccountVal = new Tuple<Contact, Misc.PostureStance>[count - 1 + 1];
			int num = count - 1;
			List<Weapon> list_ = null;
			Contact contact;
			ActiveUnit actualUnit;
			Misc.PostureStance value;
			Weapon weapon;
			for (int i = 0; i <= num; i++)
			{
				contact = PrintClient()[i];
				if (contact == null)
				{
					continue;
				}
				actualUnit = contact.ActualUnit;
				if (actualUnit == null || !actualUnit.IsWeapon)
				{
					continue;
				}
				if (m_AccountVal[i] == null)
				{
					if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out value))
					{
						value = contact.GetStance(m_EventVal.GetUnitSide());
					}
				}
				else
				{
					value = m_AccountVal[i].Item2;
				}
				if (value == Misc.PostureStance.Friendly || !RegisterWatcher((Weapon)actualUnit))
				{
					continue;
				}
				AddContactToThreatList(contact);
				if ((_TargetList != null && _TargetList.ContainsKey(contact.ObjectID)) || ((Weapon)actualUnit).Type != Weapon._WeaponType.GuidedWeapon)
				{
					continue;
				}
				weapon = m_EventVal.Weaponry.RevertConsumer(contact);
				if (!Information.IsNothing(weapon))
				{
					if (!flag)
					{
						list_ = m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual();
						flag = true;
					}
					ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
					Contact contact_ = contact;
					Doctrine doctrine = m_EventVal.Doctrine;
					string string_ = null;
					int int_ = 0;
					if (weaponry.PopConsumer(contact_, bool_1: true, doctrine, ref string_, ref int_, list_) && (double)Module_Unit.RangeToUnit_Slant(m_EventVal, contact) < 1.5 * (double)weapon.MaxAirRange)
					{
						TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
			list_ = null;
			contact = null;
			actualUnit = null;
			value = Misc.PostureStance.Neutral;
			weapon = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100548", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EngageTargets(float float_0)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			if (GetVehicle().CanFireOnTheMove || (int)Math.Round(GetVehicle().CurrentSpeed) <= 0)
			{
				base.EngageTargets(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100549", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void MaintainStandoff(float float_0)
	{
		try
		{
			Doctrine doctrine = m_EventVal.Doctrine;
			Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, doctrine);
			if (Information.IsNothing(weapon))
			{
				return;
			}
			float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, doctrine, bool_1: false);
			float num2 = num / maxRangeForThisTarget;
			float num3 = 0.8f;
			switch (GetVehicle().MobileUnitCategory)
			{
			case IMobileGroundUnit._MobileUnitCategory.Infantry:
			case IMobileGroundUnit._MobileUnitCategory.Armor:
			case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
				num3 = 0.5f;
				break;
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
				num3 = 0.95f;
				break;
			}
			if (num2 <= num3)
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
				return;
			}
			m_EventVal.Kinematics.DesiredSpeedOverride = null;
			if ((int)m_EventVal.ThrottleSetting < 3)
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
			}
			ManouverTowardsTarget(float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100550", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool ManageWatcher()
	{
		if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && !GetVehicle().CanFireOnTheMove && _TargetList != null)
		{
			Doctrine._UseShootTourists? shootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if (shootTourists.HasValue)
			{
				byte? b = (byte?)shootTourists;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					foreach (KeyValuePair<string, TargetingEntry> target in _TargetList)
					{
						if (m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(target.Value.Target, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine) != null)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		return false;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			m_EventVal.Navigator.m_ErrorWrapper = false;
			if (m_EventVal.IsFixedFacility || HoldPosition)
			{
				return;
			}
			if (m_EventVal.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo && m_EventVal.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo)
			{
				ActiveUnit._ActiveUnitStatus status = m_EventVal.Status;
				if (status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					if (status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						if (m_EventVal.DockingOps.UNREP_Destination != null)
						{
							m_EventVal.DesiredSpeed = 0f;
							return;
						}
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					}
					switch (m_EventVal.Status)
					{
					case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
						if (ManageWatcher())
						{
							m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
							break;
						}
						if (m_EventVal.IsOnActivePatrol && !m_EventVal.Navigator.NextWaypointIsManual)
						{
							if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && m_EventVal.Navigator.PlottedCourse.Length == 1 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
							{
								m_EventVal.Navigator.ClearPlottedCourse();
								break;
							}
							Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
							if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea, ref patrol.PatrolArea_ChangeCheck, 0f, bool_1: false))
							{
								m_EventVal.Navigator.ClearPlottedCourse();
								m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
							}
						}
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
						if (!m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Kinematics.ThrottlePreset != 0 && m_EventVal.DesiredSpeed != 0f)
						{
							m_EventVal.Kinematics.DesiredSpeedOverride = null;
							m_EventVal.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
							m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
							break;
						}
						if (m_EventVal.Navigator.HasPlottedCourse())
						{
							if (m_EventVal.DesiredSpeed == 0f)
							{
								if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
								{
									m_EventVal.DesiredSpeed = m_EventVal.Kinematics.DesiredSpeedOverride.Value;
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise, (int)Math.Round(m_EventVal.DesiredSpeed));
								}
								else
								{
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
									m_EventVal.DesiredSpeed = m_EventVal.Kinematics.GetMaximumSpeed(0f, m_EventVal.ThrottleSetting, bool_0: false);
								}
							}
							else
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise, (int)Math.Round(m_EventVal.DesiredSpeed));
							}
						}
						if (m_EventVal.AI.MustSlowDownToAllowGroupFormUp())
						{
							float num = float.MaxValue;
							foreach (ActiveUnit value in m_EventVal.GetParentGroup().Units.Values)
							{
								if (!value.IsGroupLead() && !value.Navigator.HaveReachedFormationStation() && value.DesiredSpeed > 0f && value.DesiredSpeed / 2f < num)
								{
									num = value.DesiredSpeed / 2f;
								}
							}
							m_EventVal.DesiredSpeed = Math.Min(m_EventVal.DesiredSpeed, num);
						}
						else if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
						{
							m_EventVal.DesiredSpeed = m_EventVal.Kinematics.DesiredSpeedOverride.Value;
						}
						else if (m_EventVal.IsGroupMember() && m_EventVal.IsGroupLead())
						{
							float num2 = m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), m_EventVal.ThrottleSetting, bool_0: false);
							foreach (ActiveUnit value2 in m_EventVal.GetParentGroup().Units.Values)
							{
								if (value2 != m_EventVal && !value2.IsFixedFacility)
								{
									float num3 = value2.Kinematics.GetMaximumSpeed(value2.GetCurrentAltitude(), m_EventVal.ThrottleSetting, bool_0: false);
									if (num3 < num2)
									{
										num2 = num3;
									}
								}
							}
							m_EventVal.DesiredSpeed = num2;
						}
						m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(m_EventVal.GetCurrentAltitude(), (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
						break;
					case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
						if (Information.IsNothing(PrimaryTarget))
						{
							break;
						}
						if ((int)PrimaryTarget.Type <= 1)
						{
							m_EventVal.DesiredSpeed = 0f;
						}
						else if (m_EventVal.IsGroupMember())
						{
							if (m_EventVal.IsGroupLead())
							{
								ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
								Contact primaryTarget = PrimaryTarget;
								Doctrine doctrine = m_EventVal.Doctrine;
								string string_ = "";
								int int_ = 0;
								if (weaponry.PopConsumer(primaryTarget, bool_1: true, doctrine, ref string_, ref int_))
								{
									MaintainStandoff(float_0);
								}
								else if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= 0.05)
								{
									m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
								}
								else
								{
									ManouverTowardsTarget(float_0);
								}
							}
							else if (m_EventVal.AssignedMissionOrPackage() == m_EventVal.GetParentGroup().AssignedMissionOrPackage() && m_EventVal.CommStuff.IsConnectedToSideNetwork)
							{
								bool flag = false;
								ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
								Contact primaryTarget2 = PrimaryTarget;
								Doctrine doctrine2 = m_EventVal.Doctrine;
								string string_2 = "";
								int int_2 = 0;
								if (weaponry2.PopConsumer(primaryTarget2, bool_1: true, doctrine2, ref string_2, ref int_2))
								{
									Weapon weapon = m_EventVal.Weaponry.LongestRangedSuitableWeaponForThisTarget(PrimaryTarget);
									if (weapon != null)
									{
										float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, m_EventVal.Doctrine, bool_1: false);
										if (PrimaryTarget == m_EventVal.GetParentGroup().AI.PrimaryTarget)
										{
											foreach (ActiveUnit value3 in m_EventVal.GetParentGroup().Units.Values)
											{
												if (!(maxRangeForThisTarget <= Module_Unit.RangeToUnit_Horiz(value3, PrimaryTarget)))
												{
													flag = true;
													break;
												}
											}
										}
										else
										{
											flag = maxRangeForThisTarget > Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
										}
									}
								}
								if (flag)
								{
									MaintainStandoff(float_0);
								}
								else
								{
									m_EventVal.Navigator.HeadToFormationStation(float_0);
								}
							}
							else
							{
								MaintainStandoff(float_0);
							}
						}
						else
						{
							MaintainStandoff(float_0);
						}
						break;
					case ActiveUnit._ActiveUnitStatus.OnPatrol:
						if (!ManageWatcher())
						{
							Patrol patrol2 = (Patrol)m_EventVal.AssignedMissionOrPackage();
							if (Information.IsNothing(patrol2))
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							else
							{
								if (!m_EventVal.IsGroupMember())
								{
									if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
									{
										ActiveUnit_Navigator navigator = m_EventVal.Navigator;
										ref List<ReferencePoint> patrolArea = ref patrol2.PatrolArea;
										List<ReferencePoint> list_ = null;
										List<ReferencePoint> list_2 = null;
										if (!navigator.PlottedCourseLeadsToMissionArea(ref patrolArea, ref list_, ref list_2, 30f, bool_1: false))
										{
											m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
										}
										m_EventVal.Navigator.FollowPlottedCourse(float_0);
									}
									else
									{
										m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
									}
									break;
								}
								if (m_EventVal.IsGroupLead())
								{
									if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
									{
										ActiveUnit_Navigator navigator2 = m_EventVal.GetParentGroup().Navigator;
										ref List<ReferencePoint> patrolArea2 = ref patrol2.PatrolArea;
										List<ReferencePoint> list_3 = null;
										List<ReferencePoint> list_4 = null;
										if (!navigator2.PlottedCourseLeadsToMissionArea(ref patrolArea2, ref list_3, ref list_4, 0f, bool_1: false))
										{
											m_EventVal.GetParentGroup().Navigator.PlotCourseToStationArea(float_0, bool_1: false);
										}
										m_EventVal.Navigator.FollowPlottedCourse(float_0);
									}
									else
									{
										m_EventVal.GetParentGroup().Navigator.PlotCourseToStationArea(float_0, bool_1: false);
									}
									break;
								}
								if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
								{
									m_EventVal.Navigator.HeadToFormationStation(float_0);
									break;
								}
							}
							goto default;
						}
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
						break;
					case ActiveUnit._ActiveUnitStatus.Tasked:
						if (IsEscort)
						{
							HeadToNearestEscortSubject();
						}
						if (m_EventVal.IsOnActiveCargoMission)
						{
							ConnectReponse(float_0);
							break;
						}
						goto default;
					case ActiveUnit._ActiveUnitStatus.RTB:
					case ActiveUnit._ActiveUnitStatus.RTB_Manual:
					case ActiveUnit._ActiveUnitStatus.RTB_Group:
					case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
					case ActiveUnit._ActiveUnitStatus.RTB_Exhaustion:
						if (m_EventVal.IsVehicle && ((Vehicle)m_EventVal).IsOutOfFuel)
						{
							ReturnToBase(float_0);
						}
						goto default;
					case ActiveUnit._ActiveUnitStatus.OnSupportMission:
						if (!ManageWatcher())
						{
							if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
							{
								if (!m_EventVal.IsGroupMember())
								{
									m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
									break;
								}
								if (m_EventVal.IsGroupLead())
								{
									m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
									break;
								}
								if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
								{
									m_EventVal.Navigator.HeadToFormationStation(float_0);
									break;
								}
							}
							goto default;
						}
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
						break;
					default:
						if (m_EventVal.IsGroupWingman())
						{
							if (!m_EventVal.IsGroupLead() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && m_EventVal.GetParentGroup().GroupLead.DockingOps.UNREP_Destination == m_EventVal)
							{
								switch (m_EventVal.GetParentGroup().GroupLead.Status)
								{
								default:
									if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
									{
										m_EventVal.Navigator.HeadToFormationStation(float_0);
									}
									break;
								case ActiveUnit._ActiveUnitStatus.Refuelling:
									m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
									break;
								case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
									m_EventVal.SetDesiredHeading(m_EventVal.GetParentGroup().GroupLead.DesiredTurnRate, Module_Unit.BearingToUnit_True(m_EventVal, m_EventVal.GetParentGroup().GroupLead));
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
									break;
								}
								break;
							}
							if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
							{
								if (ManageWatcher())
								{
									m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
									break;
								}
								m_EventVal.Navigator.HeadToFormationStation(float_0);
								if (!m_EventVal.Navigator.m_ErrorWrapper)
								{
									m_EventVal.DesiredSpeed = m_EventVal.GetParentGroup().DesiredSpeed;
								}
								break;
							}
						}
						if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
						{
							m_EventVal.DesiredSpeed = 0f;
						}
						break;
					case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
						if (m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Underway)
						{
							m_EventVal.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
						}
						ReturnToBase(float_0);
						break;
					}
					return;
				}
				bool flag2 = true;
				GeoPoint geoPoint_ = LoginClient();
				ActiveUnit_DockingOps dockingOps = m_EventVal.DockingOps;
				string string_3 = "";
				List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(bool_0: true, null, ref string_3, ActiveUnit_DockingOps.ResupplyRequest.FuelOrMaterial);
				if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse || m_EventVal.DockingOps.UNREP_Destination == null)
				{
					if (m_EventVal.DockingOps.UNREP_Destination != null && potentialUNREPunits.Contains(m_EventVal.DockingOps.UNREP_Destination))
					{
						flag2 = m_EventVal.DockingOps.SearchDic(m_EventVal.DockingOps.UNREP_Destination) == ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success || m_EventVal.DockingOps.IncludeDic(geoPoint_, null, null, bool_0: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
					}
					else if (potentialUNREPunits.Count <= 0)
					{
						if (m_EventVal.DockingOps.UNREP_Destination != null)
						{
							m_EventVal.DockingOps.DisconnectFromSupplier();
						}
						flag2 = false;
					}
					else
					{
						flag2 = m_EventVal.DockingOps.IncludeDic(geoPoint_, null, null, bool_0: false, 100).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
					}
				}
				if (m_EventVal.DockingOps.UNREP_Destination != null && flag2)
				{
					ActiveUnit uNREP_Destination = m_EventVal.DockingOps.UNREP_Destination;
					if (m_EventVal.IsGroupLead() && uNREP_Destination.IsGroupMember() && m_EventVal.GetParentGroup() == uNREP_Destination.GetParentGroup() && !uNREP_Destination.IsFixedFacility)
					{
						uNREP_Destination.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(uNREP_Destination, m_EventVal));
						uNREP_Destination.SetThrottle(ActiveUnit.Throttle.Full);
						if (m_EventVal.DesiredSpeed > 0f)
						{
							m_EventVal.DesiredSpeed = Math.Max(5f, uNREP_Destination.CurrentSpeed - 10f);
							m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
						}
						return;
					}
					if (uNREP_Destination.CommStuff.IsConnectedToSideNetwork)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(m_EventVal, uNREP_Destination));
					}
					else
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToPoint_True(m_EventVal, uNREP_Destination.Latitude_LastReported.Value, uNREP_Destination.Longitude_LastReported.Value));
					}
					if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, uNREP_Destination) < 0.1)
					{
						return;
					}
					if ((float)(m_EventVal.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.Cruise, bool_0: false) - 5) < uNREP_Destination.DesiredSpeed)
					{
						int maximumSpeed = m_EventVal.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.Full, bool_0: false);
						ActiveUnit.Throttle throttle_ = ActiveUnit.Throttle.Full;
						if ((float)(maximumSpeed - 5) < uNREP_Destination.DesiredSpeed)
						{
							throttle_ = ActiveUnit.Throttle.Flank;
						}
						m_EventVal.SetThrottle(throttle_);
					}
					else
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				else
				{
					if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						m_EventVal.Status = m_EventVal.predicateVal;
					}
					if (m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.ManoeuveringToRefuel || m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Replenishing)
					{
						m_EventVal.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
					}
				}
			}
			else
			{
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100551", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool RevertWatcher(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		return CountReponse(geopoint_Struct_0, cargoMission_0)?.Any() ?? false;
	}

	private List<Geopoint_Struct> CountReponse(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		List<Geopoint_Struct> list = new List<Geopoint_Struct>();
		if (cargoMission_0.DestinationUnit == null)
		{
			if ((cargoMission_0.Area_1nm_Buffered == null) ? GeoPoint.IsInsideThisArea(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, cargoMission_0.Area) : GeoPoint.IsInsideThisArea(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, cargoMission_0.Area_1nm_Buffered))
			{
				short num = short.MaxValue;
				short num2 = 1;
				short elevation = Terrain.GetElevation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, bool_0: false, m_EventVal.ParentScen);
				if (elevation < short.MaxValue && elevation > num2)
				{
					int num3 = 1;
					do
					{
						float num4 = 0f;
						do
						{
							Geopoint_Struct item = default(Geopoint_Struct);
							Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct_0.Longitude, geopoint_Struct_0.Latitude, ref item.Longitude, ref item.Latitude, num4, num3);
							if (GeoPoint.IsInsideThisArea(item.Latitude, item.Longitude, cargoMission_0.Area))
							{
								short elevation2 = Terrain.GetElevation(item.Latitude, item.Longitude, bool_0: false, m_EventVal.ParentScen);
								if (elevation2 > num2 && elevation2 < num)
								{
									list.Add(item);
								}
							}
							num4 += 0.1f;
						}
						while (num4 <= 2f);
						num3++;
					}
					while (num3 <= 360);
					return list;
				}
				return null;
			}
			return null;
		}
		Geopoint_Struct item2 = new Geopoint_Struct(cargoMission_0.DestinationUnit.GetLongitude(), cargoMission_0.DestinationUnit.GetLatitude());
		list.Add(item2);
		return list;
	}

	private void CustomizeReponse(float float_0)
	{
		if (m_EventVal.Navigator.HasPlottedCourse())
		{
			m_EventVal.Navigator.FollowPlottedCourse(float_0);
		}
		else if (CloneReponse())
		{
			m_EventVal.Navigator.PlotCourseToCargoDestination(((CargoMission)m_EventVal.AssignedMissionOrPackage()).DestinationUnit);
		}
		else if (m_EventVal.DockingOps.ActualDestinationHost != null)
		{
			m_EventVal.Navigator.PlotCourseToCargoDestination(m_EventVal.DockingOps.ActualDestinationHost);
		}
	}

	internal bool CloneReponse()
	{
		if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
		{
			CargoMission cargoMission = (CargoMission)m_EventVal.AssignedMissionOrPackage();
			if (cargoMission.AllowAllSelfDelivery)
			{
				return true;
			}
			if (cargoMission.AllowSelfDeliveryFromCargo)
			{
				if (m_EventVal.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && m_EventVal.DockingOps.OriginalCargoHostUnit == null)
				{
					return false;
				}
				if (cargoMission.MoveAllCargo)
				{
					return true;
				}
				foreach (CargoManifestItem item in cargoMission.CargoToUnload)
				{
					if (Operators.CompareString(m_EventVal.ObjectID, item.ObjectID, TextCompare: false) == 0)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void ConnectReponse(float float_0)
	{
		CargoMission cargoMission = (CargoMission)m_EventVal.AssignedMissionOrPackage();
		bool flag = true;
		bool flag2 = CloneReponse();
		if (m_EventVal.OnboardCargo.Count() == 0 && !flag2)
		{
			if (m_EventVal.DockingOps.ActualDestinationHost == null)
			{
				if (cargoMission.RTBUponCompletion)
				{
					if (!m_EventVal.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: true, bool_3: true))
					{
						if (m_EventVal.Navigator.HasPlottedCourse())
						{
							m_EventVal.Navigator.FollowPlottedCourse(float_0);
							return;
						}
						m_EventVal.Kinematics.DesiredSpeedOverride = null;
						m_EventVal.DesiredSpeed = 0f;
						m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") is unable to return to base during cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.DockingOps, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
					}
				}
				else
				{
					ActiveUnit eventVal = m_EventVal;
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
					eventVal.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_);
					m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") has completed cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " has completed its cargo mission", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
				return;
			}
			if (Module_Unit.RangeToUnit_Horiz(m_EventVal, m_EventVal.DockingOps.ActualDestinationHost) < 2f)
			{
				if (GetVehicle().IsOutOfFuel)
				{
					ActiveUnit_DockingOps dockingOps = m_EventVal.DockingOps.ActualDestinationHost.DockingOps;
					ActiveUnit eventVal2 = m_EventVal;
					DockFacility dockFacility_ = null;
					if (dockingOps.CanHostThisBoat(eventVal2, ref dockFacility_))
					{
						ReturnToBase(float_0);
						return;
					}
				}
				if (m_EventVal.DockingOps.ActualDestinationHost.IsGroup)
				{
					m_EventVal.DockingOps.SettleForCargoMissionTransfer(m_EventVal.DockingOps.OriginalCargoHostUnit);
				}
				else
				{
					m_EventVal.DockingOps.SettleForCargoMissionTransfer(m_EventVal.DockingOps.ActualDestinationHost);
				}
				return;
			}
			if (m_EventVal.IsGroupMember())
			{
				if (m_EventVal.IsGroupLead())
				{
					CustomizeReponse(float_0);
				}
				else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
				{
					m_EventVal.Navigator.HeadToFormationStation(float_0);
					flag = false;
				}
			}
			else
			{
				CustomizeReponse(float_0);
			}
			if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && flag)
			{
				m_EventVal.SetThrottle(cargoMission.TransitThrottle_Ship);
			}
			return;
		}
		if (cargoMission.Type == CargoMission.CargoMissionType.Transfer)
		{
			if (cargoMission.DestinationUnit != null && Module_Unit.RangeToUnit_Horiz(m_EventVal, cargoMission.DestinationUnit) < 2f)
			{
				ActiveUnit_DockingOps dockingOps2 = cargoMission.DestinationUnit.DockingOps;
				ActiveUnit eventVal3 = m_EventVal;
				DockFacility dockFacility_2 = null;
				if (!dockingOps2.CanHostThisBoat(eventVal3, ref dockFacility_2))
				{
					if (flag2)
					{
						Cargo item = new Cargo(cargoMission.DestinationUnit, m_EventVal);
						List<Cargo> list = new List<Cargo>();
						list.Add(item);
						ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(m_EventVal, cargoMission.DestinationUnit, list);
						foreach (CargoManifestItem item2 in cargoMission.CargoToUnload)
						{
							if (Operators.CompareString(item2.ObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
							{
								cargoMission.CargoToUnload.Remove(item2);
								break;
							}
						}
						ActiveUnit eventVal4 = m_EventVal;
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
						eventVal4.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_2);
						m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") has completed self-transport for cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " has completed cargo mission self-transport", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
					}
					else
					{
						m_EventVal.DockingOps.SettleForCargoMissionTransfer(cargoMission.DestinationUnit);
					}
					return;
				}
			}
			if (m_EventVal.IsGroupMember())
			{
				if (m_EventVal.IsGroupLead())
				{
					CustomizeReponse(float_0);
				}
				else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
				{
					m_EventVal.Navigator.HeadToFormationStation(float_0);
					flag = false;
				}
			}
			else
			{
				CustomizeReponse(float_0);
			}
			if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && flag)
			{
				m_EventVal.SetThrottle(cargoMission.TransitThrottle_Ship);
			}
			return;
		}
		if (m_EventVal.Navigator.DisableDic(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
		{
			if (!flag2 && RevertWatcher(new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()), cargoMission))
			{
				m_EventVal.DockingOps.SettleForCargoTransfer();
				return;
			}
			if (flag2 && Module_Unit.ResetTokenizer(m_EventVal))
			{
				ActiveUnit eventVal5 = m_EventVal;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_3 = Mission.MissionAssignmentAttemptResult.None;
				eventVal5.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_3);
				m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") has completed self-transport for cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " has completed cargo mission self-transport", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				return;
			}
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			int num = 0;
			Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
			List<Geopoint_Struct> list2 = null;
			while (true)
			{
				num++;
				geopoint_Struct = Math2.RandomPointWithinThisArea(cargoMission.Area);
				if (num > 1000)
				{
					break;
				}
				list2 = CountReponse(geopoint_Struct, cargoMission);
				if (list2 != null && list2.Any())
				{
					geopoint_Struct2 = (from geopoint_Struct_0 in list2
						orderby Math2.CancelClass(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude()), Terrain.GetElevation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, bool_0: false, m_EventVal.ParentScen)
						select geopoint_Struct_0).First();
					m_EventVal.Navigator.ClearPlottedCourse();
					m_EventVal.Navigator.AddWaypoint(geopoint_Struct2.Latitude, geopoint_Struct2.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), geopoint_Struct2.Latitude, geopoint_Struct2.Longitude));
					return;
				}
			}
			m_EventVal.AddMessage(m_EventVal.Name + "无法在参考点定义的货物着陆区域内选择合适的点", m_EventVal.Name + " 无法拾取点", LoggedMessage.MessageType.DockingOps, 1, bool_0: true, geopoint_Struct);
			return;
		}
		if (m_EventVal.IsGroupMember())
		{
			if (m_EventVal.IsGroupLead())
			{
				if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
				{
					if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
					{
						m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(cargoMission.Area);
					}
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(cargoMission.Area);
				}
			}
			else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
			{
				m_EventVal.Navigator.HeadToFormationStation(float_0);
				flag = false;
			}
		}
		else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
		{
			if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
			{
				m_EventVal.Navigator.PlotCourseToArea(cargoMission.Area);
			}
			m_EventVal.Navigator.FollowPlottedCourse(float_0);
		}
		else if (m_EventVal.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo)
		{
			m_EventVal.Navigator.PlotCourseToArea(cargoMission.Area, bool_1: false, Waypoint.WaypointType.DropOffPoint);
		}
		if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && flag)
		{
			if (m_EventVal.Navigator.DisableDic(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
			{
				m_EventVal.SetThrottle(cargoMission.StationThrottle_Ship);
			}
			else
			{
				m_EventVal.SetThrottle(cargoMission.TransitThrottle_Ship);
			}
		}
	}

	[CompilerGenerated]
	private double MoveReponse(Geopoint_Struct geopoint_Struct_0)
	{
		return Math2.CancelClass(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude());
	}

	[CompilerGenerated]
	private short DeleteReponse(Geopoint_Struct geopoint_Struct_0)
	{
		return Terrain.GetElevation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, bool_0: false, m_EventVal.ParentScen);
	}
}
