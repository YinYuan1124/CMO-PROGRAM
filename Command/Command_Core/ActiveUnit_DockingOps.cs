using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class ActiveUnit_DockingOps
{
	public delegate void DeployedToSeaEventHandler(ActiveUnit theBoat);

	public delegate void DockingEventHandler(ActiveUnit theBoat);

	public delegate void HostDockFacilityChangedEventHandler(string UnitObjectID);

	public delegate void DockingOpsStatusChangeEventHandler(ActiveUnit theUnit, object oldStatus);

	public enum _DockingOpsCondition : byte
	{
		Underway,
		Docked,
		DeployingUnderway,
		Docking,
		RTB,
		Readying,
		ManoeuveringToRefuel,
		Replenishing,
		ProvidingUNREP,
		RechargingBatteries,
		SettlingForCargoTransfer,
		LoadedAsCargo,
		TransferringCargo,
		TransferringMissionCargo
	}

	public enum ResultOfAttemptToScheduleUNREP
	{
		None,
		Success,
		Fail_Other,
		Fail_NoCandidatesWithinSpecifiedDistance
	}

	public enum ResultOfAttemptToRendezvousWithTanker
	{
		None,
		Success,
		Fail_Unknown,
		Fail_NoSuitableFuelOrStoresToTransfer,
		Fail_CannotIntercept,
		Fail_ProviderSmallerThanReceiver
	}

	public enum ResupplyRequest
	{
		Fuel,
		Material,
		FuelAndMaterial,
		FuelOrMaterial
	}

	public enum ResupplyCapacity
	{
		None,
		Fuel,
		Material,
		FuelAndMaterial
	}

	[CompilerGenerated]
	private sealed class SetterInstanceFilter
	{
		public Module_Unit.Unit Local_PickupUnit;

		internal float PrintInterruptibleMock(GeoPoint thepoint)
		{
			return Math2.VerifyClass(thepoint.Latitude, thepoint.Longitude, Local_PickupUnit.GetLatitude(), Local_PickupUnit.GetLongitude());
		}
	}

	[CompilerGenerated]
	private sealed class ProxyComparator
	{
		public Dictionary<string, int> Local_GroupDictionary;

		public Func<Cargo, int> _003C_003E9__0;

		internal int DefineInterruptibleMock(Cargo s)
		{
			ActiveUnit cargoObjectActiveUnit = s.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit != null && cargoObjectActiveUnit.GetParentGroup() != null && Local_GroupDictionary.TryGetValue(cargoObjectActiveUnit.GetParentGroup().ObjectID, out var value))
			{
				if (!cargoObjectActiveUnit.IsGroupLead())
				{
					return value + 1;
				}
				return value;
			}
			return int.MaxValue;
		}
	}

	[CompilerGenerated]
	private sealed class ReaderComparator
	{
		public FuelRec Local_theFR;

		internal bool PublishInterruptibleMock(FuelRec theF)
		{
			return (theF.FuelType == Local_theFR.FuelType) & (theF.CurrentQuantity > 0f);
		}
	}

	[CompilerGenerated]
	private sealed class FactoryProcessResolver
	{
		public FuelRec Local_theFR;

		internal bool AwakeInterruptibleMock(FuelRec theF)
		{
			if (theF.FuelType == Local_theFR.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ParameterMerchantPage
	{
		public FuelRec Local_theFR;

		internal bool QueryInterruptibleMock(FuelRec theF)
		{
			if (theF.FuelType == Local_theFR.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ExpressionMerchantPage
	{
		public FuelRec Local_theFR0;

		internal bool ResetInterruptibleMock(FuelRec theF)
		{
			if (theF.FuelType == Local_theFR0.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class VisitorCallbackCandidate
	{
		public FuelRec Local_theFR00;

		internal bool MapInterruptibleMock(FuelRec theF)
		{
			if (theF.FuelType == Local_theFR00.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class PropertyComparator
	{
		public ActiveUnit_DockingOps _003C_003E4__this;

		public float num;

		public TList<ActiveUnit> tList;

		internal void SortInterruptibleMock(ActiveUnit theUnit)
		{
			if (theUnit != _003C_003E4__this.myUnit && Module_Unit.RangeToUnit_Horiz(_003C_003E4__this.myUnit, theUnit) <= num && Operators.CompareString(_003C_003E4__this.ThisUnitCanHostMe(theUnit), "OK", TextCompare: false) == 0)
			{
				tList.Add(theUnit);
			}
		}
	}

	[CompilerGenerated]
	private sealed class AccountParameterMock
	{
		public ActiveUnit_DockingOps Me;

		public int? Local_DistanceLimit;

		public ActiveUnit_DockingOps _003C_003E4__this;

		public GeoPoint Local_IntermediateTargetPoint;

		internal bool CalcInterruptibleMock(ActiveUnit theT)
		{
			return Module_Unit.RangeToUnit_Horiz(Me.myUnit, theT) <= (float)Local_DistanceLimit.Value;
		}

		internal double RateInterruptibleMock(ActiveUnit theT)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, _003C_003E4__this.myUnit);
		}

		internal double FlushInterruptibleMock(ActiveUnit theT)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, _003C_003E4__this.myUnit);
		}

		internal double ForgotInterruptibleMock(ActiveUnit theT)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, _003C_003E4__this.myUnit);
		}

		internal double CollectInterruptibleMock(ActiveUnit theT)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, _003C_003E4__this.myUnit);
		}

		internal double OrderInterruptibleMock(ActiveUnit theT)
		{
			return Module_Unit.RangeToPoint_Horiz_Angular(theT, Local_IntermediateTargetPoint);
		}
	}

	[CompilerGenerated]
	private sealed class ImporterComparator
	{
		public ActiveUnit Local_myHost;

		public double Local_RangeToBase_Angular;

		public AccountParameterMock CS_0024_003C_003E8__locals1;

		internal bool RegisterInterruptibleMock(ActiveUnit theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular(CS_0024_003C_003E8__locals1.Me.myUnit, theT) < Local_RangeToBase_Angular)
			{
				return Module_Unit.RangeToUnit_Horiz_Angular(theT, Local_myHost) < Local_RangeToBase_Angular;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class CreatorInstanceFilter
	{
		public double Local_RangeToTarget_Angular;

		public AccountParameterMock CS_0024_003C_003E8__locals2;

		internal bool ManageInterruptibleMock(ActiveUnit theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular(CS_0024_003C_003E8__locals2.Me.myUnit, theT) < Local_RangeToTarget_Angular)
			{
				return Module_Unit.RangeToPoint_Horiz_Angular(theT, CS_0024_003C_003E8__locals2.Local_IntermediateTargetPoint) < Local_RangeToTarget_Angular;
			}
			return false;
		}
	}

	protected ActiveUnit myUnit;

	public float PierLaneLength;

	private DockFacility _ParameterWrapper;

	private string expressionWrapper;

	private ActiveUnit m_DispatcherWrapper;

	private ActiveUnit m_ListenerWrapper;

	private string configWrapper;

	private string registryWrapper;

	private string definitionWrapper;

	private ActiveUnit _ValWrapper;

	private string m_WrapperWrapper;

	public string UNREP_Port_ReceiverUnitID;

	public float UNREP_Port_TimeToNextTransfer;

	public string UNREP_Starboard_ReceiverUnitID;

	public float UNREP_Starboard_TimeToNextTransfer;

	public string UNREP_Astern_ReceiverUnitID;

	public float UNREP_Astern_TimeToNextTransfer;

	[AccessedThroughProperty("UNREP_Queue")]
	[CompilerGenerated]
	private List<string> m_ObserverWrapper;

	private _DockingOpsCondition issuerWrapper;

	private float m_ClientWrapper;

	private _DockingOpsCondition m_DicWrapper;

	internal _DockingOpsCondition consumerWrapper;

	internal float _FacadeWrapper;

	internal ActiveUnit.Throttle proxyWrapper;

	public float UNREP_Connect_ThresholdRange;

	public static int DEFAULT_CARGO_LOAD_TIME;

	public static int DEFAULT_CARGO_UNLOAD_TIME;

	private Geopoint_Struct[] readerWrapper;

	public static object CargoOpsLockObj;

	public static Lazy<LockRandom> CargoOpsRandom;

	[CompilerGenerated]
	private static DeployedToSeaEventHandler _PropertyWrapper;

	[CompilerGenerated]
	private static DockingEventHandler importerWrapper;

	[CompilerGenerated]
	private static HostDockFacilityChangedEventHandler _RepositoryWrapper;

	[CompilerGenerated]
	private static DockingOpsStatusChangeEventHandler m_BridgeWrapper;

	public List<string> UNREP_Queue
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverWrapper;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObserverWrapper = value;
		}
	}

	public float ConditionTimer
	{
		get
		{
			return m_ClientWrapper;
		}
		set
		{
			m_ClientWrapper = value;
		}
	}

	public ActiveUnit ActualDestinationHost
	{
		get
		{
			try
			{
				ActiveUnit activeUnit = null;
				Mission mission = myUnit.AssignedMissionOrPackage();
				if (mission == null)
				{
					activeUnit = GetAssignedHostUnit();
				}
				else if (mission.MissionClass == Mission._MissionClass.Ferry)
				{
					if (((FerryMission)mission).GetNominalDestinationHost(myUnit.ParentScen) == null)
					{
						myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + "）不再能够执行转场任务：" + mission.Name + "（转场目的地似乎不见了）。该单元将从任务中删除。", myUnit.Name + " 无法转场；从任务中移除", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						ActiveUnit activeUnit2 = myUnit;
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
						activeUnit2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
						activeUnit = GetAssignedHostUnit();
					}
					FerryMission.FerryMissionBehavior behavior = ((FerryMission)mission).Behavior;
					if (1 == 0)
					{
					}
					ActiveUnit activeUnit4 = behavior switch
					{
						FerryMission.FerryMissionBehavior.OneWay => ((FerryMission)mission).GetNominalDestinationHost(myUnit.ParentScen), 
						FerryMission.FerryMissionBehavior.Cycle => myUnit.AI.FerryCycleLegIsOutbound ? ((FerryMission)mission).GetNominalDestinationHost(myUnit.ParentScen) : GetAssignedHostUnit(), 
						FerryMission.FerryMissionBehavior.Random => GetAssignedHostUnit(), 
						_ => GetAssignedHostUnit(), 
					};
					if (1 == 0)
					{
					}
					activeUnit = activeUnit4;
				}
				else if (mission.MissionClass == Mission._MissionClass.Cargo && ((CargoMission)mission).Type == CargoMission.CargoMissionType.Transfer)
				{
					CargoMission cargoMission = (CargoMission)mission;
					if (cargoMission.DestinationUnit == null || !myUnit.ParentScen.ActiveUnits.Keys.Contains(cargoMission.DestinationUnit.ObjectID))
					{
						myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") is no longer able to execute cargo mission: " + mission.Name + " (the destination appears to be missing). The unit will be removed from the mission.", myUnit.Name + " unable to execute cargo mission; removed from mission", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						ActiveUnit activeUnit3 = myUnit;
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
						activeUnit3.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
						activeUnit = GetAssignedHostUnit();
					}
					if (myUnit.OnboardCargo.Count() <= 0)
					{
						if (GetAssignedHostUnit() == null)
						{
							if (OriginalCargoHostUnit != null)
							{
								return OriginalCargoHostUnit;
							}
						}
						else
						{
							activeUnit = GetAssignedHostUnit();
						}
					}
					else
					{
						activeUnit = cargoMission.DestinationUnit;
					}
				}
				else
				{
					activeUnit = GetAssignedHostUnit();
					if (GetAssignedHostUnit() == null && OriginalCargoHostUnit != null && myUnit.OnboardCargo.Count() == 0)
					{
						activeUnit = OriginalCargoHostUnit;
					}
				}
				if (!Information.IsNothing(activeUnit) && activeUnit.IsGroupMember() && activeUnit.GetParentGroup().IsLandInstallation)
				{
					activeUnit = activeUnit.GetParentGroup();
				}
				return activeUnit;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100133", "");
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

	public Geopoint_Struct[] PierEntranceLane
	{
		get
		{
			try
			{
				if (HasPiers(myUnit))
				{
					if (Information.IsNothing(readerWrapper))
					{
						Geopoint_Struct[] array = new Geopoint_Struct[10];
						float num = Math2.UpdateClass(myUnit.CurrentHeading - 60f);
						float float_ = Math2.UpdateClass(myUnit.CurrentHeading + 60f);
						float currentHeading = myUnit.CurrentHeading;
						Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength / 3f, Math2.UpdateClass(currentHeading + 180f));
						array[0] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, num);
						array[1] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.UpdateClass(num + 15f));
						array[2] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.UpdateClass(num + 30f));
						array[3] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.UpdateClass(num + 45f));
						array[4] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, currentHeading);
						array[5] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.UpdateClass(currentHeading + 15f));
						array[6] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.UpdateClass(currentHeading + 30f));
						array[7] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.UpdateClass(currentHeading + 45f));
						array[8] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, float_);
						array[9] = geopoint_Struct;
						readerWrapper = array;
					}
					return readerWrapper;
				}
				return null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101363", "");
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

	public ActiveUnit UNREP_Destination
	{
		get
		{
			return _ValWrapper;
		}
		set
		{
			try
			{
				if (value != _ValWrapper && !Information.IsNothing(_ValWrapper) && !Information.IsNothing(_ValWrapper.DockingOps))
				{
					_ValWrapper.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
				}
				_ValWrapper = value;
				if (value != null)
				{
					List<string> uNREP_Queue = _ValWrapper.DockingOps.UNREP_Queue;
					if (!uNREP_Queue.Contains(myUnit.ObjectID))
					{
						uNREP_Queue.Add(myUnit.ObjectID);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100135", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public _DockingOpsCondition OldCondition => m_DicWrapper;

	public _DockingOpsCondition Condition
	{
		get
		{
			return issuerWrapper;
		}
		set
		{
			try
			{
				bool num = issuerWrapper != value;
				m_DicWrapper = issuerWrapper;
				issuerWrapper = value;
				if (!num)
				{
					return;
				}
				switch (value)
				{
				default:
					if (m_DicWrapper == _DockingOpsCondition.RechargingBatteries)
					{
						if (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
						{
							myUnit.DesiredAltitude = _FacadeWrapper;
							myUnit.SetThrottle(proxyWrapper);
							if (myUnit.Navigator.SprintDrift)
							{
								myUnit.Navigator.SetSprintDriftMarker(bool_1: false);
							}
						}
					}
					else if (value == _DockingOpsCondition.Underway)
					{
						_PropertyWrapper?.Invoke(myUnit);
					}
					break;
				case _DockingOpsCondition.RechargingBatteries:
					_FacadeWrapper = myUnit.DesiredAltitude;
					proxyWrapper = myUnit.ThrottleSetting;
					break;
				case _DockingOpsCondition.Docking:
					ConditionTimer = TimeNeededToDock;
					importerWrapper?.Invoke(myUnit);
					break;
				case _DockingOpsCondition.DeployingUnderway:
					ConditionTimer += (float)((double)TimeNeededToDock * (2.0 / 3.0));
					break;
				}
				m_BridgeWrapper?.Invoke(myUnit, m_DicWrapper);
				myUnit.Kinematics.PerformOutOfSequenceExportLocation = true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100136", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public string ConditionString
	{
		get
		{
			switch (Condition)
			{
			default:
				return Condition.ToString();
			case _DockingOpsCondition.Underway:
				return "Underway";
			case _DockingOpsCondition.Docked:
				return "Docked";
			case _DockingOpsCondition.DeployingUnderway:
				return "准备出动";
			case _DockingOpsCondition.Docking:
				return "Docking";
			case _DockingOpsCondition.RTB:
				return "返回基地";
			case _DockingOpsCondition.Readying:
				return "Readying";
			case _DockingOpsCondition.ManoeuveringToRefuel:
				return "向补给点机动";
			case _DockingOpsCondition.Replenishing:
				return "Replenishing";
			case _DockingOpsCondition.ProvidingUNREP:
				return "正提供补给";
			case _DockingOpsCondition.RechargingBatteries:
				return "给电池充电";
			case _DockingOpsCondition.LoadedAsCargo:
				return "Loaded as Cargo";
			case _DockingOpsCondition.SettlingForCargoTransfer:
			case _DockingOpsCondition.TransferringCargo:
			case _DockingOpsCondition.TransferringMissionCargo:
				return "转移货物";
			}
		}
	}

	public ActiveUnit OriginalCargoHostUnit => m_ListenerWrapper;

	public ReadOnlyCollection<ActiveUnit> AssignedBoats
	{
		get
		{
			try
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
				{
					if (Information.IsNothing(activeUnits_))
					{
						continue;
					}
					if (activeUnits_.IsShip)
					{
						if (((Ship)activeUnits_).DockingOps.GetAssignedHostUnit() == myUnit)
						{
							list.Add(activeUnits_);
						}
					}
					else if (activeUnits_.IsSubmarine && ((Submarine)activeUnits_).DockingOps.GetAssignedHostUnit() == myUnit)
					{
						list.Add(activeUnits_);
					}
				}
				return list.AsReadOnly();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100139b", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ReadOnlyCollection<ActiveUnit> result = new List<ActiveUnit>().AsReadOnly();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public ReadOnlyCollection<ActiveUnit> EmbarkedBoats
	{
		get
		{
			try
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
				for (int i = 0; i < dockFacilities_ReadOnly.Length; i++)
				{
					foreach (ActiveUnit value in dockFacilities_ReadOnly[i].HostedBoats.Values)
					{
						list.Add(value);
					}
				}
				return list.AsReadOnly();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100139", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ReadOnlyCollection<ActiveUnit> result = new List<ActiveUnit>().AsReadOnly();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public DockFacility HostDockFacility
	{
		get
		{
			return _ParameterWrapper;
		}
		set
		{
			try
			{
				bool num = value != _ParameterWrapper;
				if (_ParameterWrapper != null)
				{
					_ParameterWrapper.HostedBoats.Remove(myUnit.ObjectID);
				}
				if (value != null && !value.HostedBoats.ContainsKey(myUnit.ObjectID))
				{
					value.HostedBoats.AddIfNotExistsElseUpdate(myUnit.ObjectID, myUnit);
				}
				_ParameterWrapper = value;
				if (num)
				{
					_RepositoryWrapper?.Invoke(myUnit.ObjectID);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100140", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public ActiveUnit CurrentHostUnit
	{
		get
		{
			try
			{
				if (issuerWrapper == _DockingOpsCondition.LoadedAsCargo)
				{
					return m_DispatcherWrapper;
				}
				DockFacility hostDockFacility = HostDockFacility;
				if (hostDockFacility == null)
				{
					return null;
				}
				if (hostDockFacility.ParentPlatform == null)
				{
					return null;
				}
				ActiveUnit parentPlatform = hostDockFacility.ParentPlatform;
				if (parentPlatform.IsGroupMember() && parentPlatform.GetParentGroup().Type == Group.GroupType.Installation)
				{
					return parentPlatform.GetParentGroup();
				}
				return parentPlatform;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100141", "");
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

	public bool IsCurrentlyProvidingUNREP
	{
		get
		{
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					return true;
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					return true;
				}
				if (!string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					return true;
				}
			}
			else
			{
				List<ActiveUnit> activeUnits_List = myUnit.ParentScen.ActiveUnits_List;
				int count = activeUnits_List.Count;
				if (Information.IsNothing(activeUnits_List))
				{
					return false;
				}
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					try
					{
						ActiveUnit activeUnit = activeUnits_List[i];
						if (!Information.IsNothing(activeUnit) && activeUnit.DockingOps.UNREP_Destination == myUnit && activeUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
						{
							return true;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			return false;
		}
	}

	public short TimeNeededToDock
	{
		get
		{
			try
			{
				DockFacility.DockingPhysicalSize dockingPhysicalSize = (DockFacility.DockingPhysicalSize)0;
				if (myUnit.IsShip)
				{
					dockingPhysicalSize = ((Ship)myUnit).DockingPhysicalSize;
				}
				if (myUnit.IsSubmarine)
				{
					dockingPhysicalSize = ((Submarine)myUnit).DockingPhysicalSize;
				}
				if (myUnit.IsVehicle)
				{
					dockingPhysicalSize = ((Vehicle)myUnit).DockingPhysicalSize;
				}
				switch (dockingPhysicalSize)
				{
				case DockFacility.DockingPhysicalSize.const_5:
					return 900;
				case DockFacility.DockingPhysicalSize.const_6:
					return 1200;
				case DockFacility.DockingPhysicalSize.None:
					return 360;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case DockFacility.DockingPhysicalSize.const_1:
				case DockFacility.DockingPhysicalSize.VSmallDockDavit:
				case DockFacility.DockingPhysicalSize.ROV_UUV:
					return 60;
				case DockFacility.DockingPhysicalSize.SmallPier:
				case DockFacility.DockingPhysicalSize.SmallDockDavit:
				case DockFacility.DockingPhysicalSize.DryDockShelter:
					return 180;
				case DockFacility.DockingPhysicalSize.MediumPier:
				case DockFacility.DockingPhysicalSize.MediumDock:
					return 360;
				case DockFacility.DockingPhysicalSize.LargePier:
				case DockFacility.DockingPhysicalSize.LargeDock:
					return 600;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100142", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 360;
			}
		}
	}

	public bool IsDeploying
	{
		get
		{
			if (Condition == _DockingOpsCondition.DeployingUnderway)
			{
				return true;
			}
			return false;
		}
	}

	public static event DeployedToSeaEventHandler DeployedToSea
	{
		[CompilerGenerated]
		add
		{
			DeployedToSeaEventHandler deployedToSeaEventHandler = _PropertyWrapper;
			DeployedToSeaEventHandler deployedToSeaEventHandler2;
			do
			{
				deployedToSeaEventHandler2 = deployedToSeaEventHandler;
				DeployedToSeaEventHandler value2 = (DeployedToSeaEventHandler)Delegate.Combine(deployedToSeaEventHandler2, value);
				deployedToSeaEventHandler = Interlocked.CompareExchange(ref _PropertyWrapper, value2, deployedToSeaEventHandler2);
			}
			while ((object)deployedToSeaEventHandler != deployedToSeaEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DeployedToSeaEventHandler deployedToSeaEventHandler = _PropertyWrapper;
			DeployedToSeaEventHandler deployedToSeaEventHandler2;
			do
			{
				deployedToSeaEventHandler2 = deployedToSeaEventHandler;
				DeployedToSeaEventHandler value2 = (DeployedToSeaEventHandler)Delegate.Remove(deployedToSeaEventHandler2, value);
				deployedToSeaEventHandler = Interlocked.CompareExchange(ref _PropertyWrapper, value2, deployedToSeaEventHandler2);
			}
			while ((object)deployedToSeaEventHandler != deployedToSeaEventHandler2);
		}
	}

	public static event DockingEventHandler Docking
	{
		[CompilerGenerated]
		add
		{
			DockingEventHandler dockingEventHandler = importerWrapper;
			DockingEventHandler dockingEventHandler2;
			do
			{
				dockingEventHandler2 = dockingEventHandler;
				DockingEventHandler value2 = (DockingEventHandler)Delegate.Combine(dockingEventHandler2, value);
				dockingEventHandler = Interlocked.CompareExchange(ref importerWrapper, value2, dockingEventHandler2);
			}
			while ((object)dockingEventHandler != dockingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DockingEventHandler dockingEventHandler = importerWrapper;
			DockingEventHandler dockingEventHandler2;
			do
			{
				dockingEventHandler2 = dockingEventHandler;
				DockingEventHandler value2 = (DockingEventHandler)Delegate.Remove(dockingEventHandler2, value);
				dockingEventHandler = Interlocked.CompareExchange(ref importerWrapper, value2, dockingEventHandler2);
			}
			while ((object)dockingEventHandler != dockingEventHandler2);
		}
	}

	public static event HostDockFacilityChangedEventHandler HostDockFacilityChanged
	{
		[CompilerGenerated]
		add
		{
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler = _RepositoryWrapper;
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler2;
			do
			{
				hostDockFacilityChangedEventHandler2 = hostDockFacilityChangedEventHandler;
				HostDockFacilityChangedEventHandler value2 = (HostDockFacilityChangedEventHandler)Delegate.Combine(hostDockFacilityChangedEventHandler2, value);
				hostDockFacilityChangedEventHandler = Interlocked.CompareExchange(ref _RepositoryWrapper, value2, hostDockFacilityChangedEventHandler2);
			}
			while ((object)hostDockFacilityChangedEventHandler != hostDockFacilityChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler = _RepositoryWrapper;
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler2;
			do
			{
				hostDockFacilityChangedEventHandler2 = hostDockFacilityChangedEventHandler;
				HostDockFacilityChangedEventHandler value2 = (HostDockFacilityChangedEventHandler)Delegate.Remove(hostDockFacilityChangedEventHandler2, value);
				hostDockFacilityChangedEventHandler = Interlocked.CompareExchange(ref _RepositoryWrapper, value2, hostDockFacilityChangedEventHandler2);
			}
			while ((object)hostDockFacilityChangedEventHandler != hostDockFacilityChangedEventHandler2);
		}
	}

	public static event DockingOpsStatusChangeEventHandler DockingOpsStatusChange
	{
		[CompilerGenerated]
		add
		{
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler = m_BridgeWrapper;
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler2;
			do
			{
				dockingOpsStatusChangeEventHandler2 = dockingOpsStatusChangeEventHandler;
				DockingOpsStatusChangeEventHandler value2 = (DockingOpsStatusChangeEventHandler)Delegate.Combine(dockingOpsStatusChangeEventHandler2, value);
				dockingOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref m_BridgeWrapper, value2, dockingOpsStatusChangeEventHandler2);
			}
			while ((object)dockingOpsStatusChangeEventHandler != dockingOpsStatusChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler = m_BridgeWrapper;
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler2;
			do
			{
				dockingOpsStatusChangeEventHandler2 = dockingOpsStatusChangeEventHandler;
				DockingOpsStatusChangeEventHandler value2 = (DockingOpsStatusChangeEventHandler)Delegate.Remove(dockingOpsStatusChangeEventHandler2, value);
				dockingOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref m_BridgeWrapper, value2, dockingOpsStatusChangeEventHandler2);
			}
			while ((object)dockingOpsStatusChangeEventHandler != dockingOpsStatusChangeEventHandler2);
		}
	}

	static ActiveUnit_DockingOps()
	{
		DEFAULT_CARGO_LOAD_TIME = 1800;
		DEFAULT_CARGO_UNLOAD_TIME = 240;
		CargoOpsLockObj = RuntimeHelpers.GetObjectValue(new object());
		CargoOpsRandom = new Lazy<LockRandom>();
	}

	public static void ToXML(ActiveUnit_DockingOps activeUnit_DockingOps_0, ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ActiveUnit_DockingOps");
			XmlWriter obj = xmlWriter_0;
			int num = (int)activeUnit_DockingOps_0.issuerWrapper;
			obj.WriteElementString("Con", num.ToString());
			if (activeUnit_DockingOps_0.ConditionTimer != 0f)
			{
				xmlWriter_0.WriteElementString("CT", XmlConvert.ToString(activeUnit_DockingOps_0.ConditionTimer));
			}
			if (activeUnit_DockingOps_0.myUnit.IsSubmarine && !((Submarine)activeUnit_DockingOps_0.myUnit).IsNuke)
			{
				XmlWriter obj2 = xmlWriter_0;
				num = (int)activeUnit_DockingOps_0.consumerWrapper;
				obj2.WriteElementString("CBRB", num.ToString());
			}
			if (activeUnit_DockingOps_0.myUnit.IsSubmarine && !((Submarine)activeUnit_DockingOps_0.myUnit).IsNuke)
			{
				xmlWriter_0.WriteElementString("CBRB_Depth", XmlConvert.ToString(activeUnit_DockingOps_0._FacadeWrapper));
			}
			if (activeUnit_DockingOps_0.myUnit.IsSubmarine && !((Submarine)activeUnit_DockingOps_0.myUnit).IsNuke)
			{
				XmlWriter obj3 = xmlWriter_0;
				byte b = (byte)activeUnit_DockingOps_0.proxyWrapper;
				obj3.WriteElementString("CBRB_ThrottleSetting", b.ToString());
			}
			if (activeUnit_DockingOps_0._ParameterWrapper != null)
			{
				xmlWriter_0.WriteElementString("HDF", activeUnit_DockingOps_0.HostDockFacility.ObjectID);
			}
			if (activeUnit_DockingOps_0.CurrentHostUnit != null)
			{
				xmlWriter_0.WriteElementString("CHU", activeUnit_DockingOps_0.CurrentHostUnit.ObjectID);
			}
			if (activeUnit_DockingOps_0.m_DispatcherWrapper != null)
			{
				xmlWriter_0.WriteElementString("AHU", activeUnit_DockingOps_0.m_DispatcherWrapper.ObjectID);
			}
			if (activeUnit_DockingOps_0.m_ListenerWrapper != null)
			{
				xmlWriter_0.WriteElementString("OHU", activeUnit_DockingOps_0.m_ListenerWrapper.ObjectID);
			}
			if (activeUnit_DockingOps_0.UNREP_Destination != null)
			{
				xmlWriter_0.WriteElementString("UNREP_D", activeUnit_DockingOps_0.UNREP_Destination.ObjectID);
			}
			if (!string.IsNullOrEmpty(activeUnit_DockingOps_0.UNREP_Port_ReceiverUnitID))
			{
				xmlWriter_0.WriteElementString("UNREP_P", activeUnit_DockingOps_0.UNREP_Port_ReceiverUnitID);
			}
			if (!string.IsNullOrEmpty(activeUnit_DockingOps_0.UNREP_Starboard_ReceiverUnitID))
			{
				xmlWriter_0.WriteElementString("UNREP_S", activeUnit_DockingOps_0.UNREP_Starboard_ReceiverUnitID);
			}
			if (!string.IsNullOrEmpty(activeUnit_DockingOps_0.UNREP_Astern_ReceiverUnitID))
			{
				xmlWriter_0.WriteElementString("UNREP_A", activeUnit_DockingOps_0.UNREP_Astern_ReceiverUnitID);
			}
			xmlWriter_0.WriteElementString("PierLL", ((int)Math.Round(activeUnit_DockingOps_0.PierLaneLength)).ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100129", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_DockingOps FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_DockingOps activeUnit_DockingOps = new ActiveUnit_DockingOps(ref activeUnit_0);
			activeUnit_DockingOps.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "UNREP_D":
						activeUnit_DockingOps.m_WrapperWrapper = xmlNode.InnerText;
						break;
					case "UNREP_P":
						if (!string.IsNullOrEmpty(xmlNode.InnerText) && Operators.CompareString(activeUnit_DockingOps.UNREP_Starboard_ReceiverUnitID, xmlNode.InnerText, TextCompare: false) != 0 && Operators.CompareString(activeUnit_DockingOps.UNREP_Astern_ReceiverUnitID, xmlNode.InnerText, TextCompare: false) != 0)
						{
							activeUnit_DockingOps.UNREP_Port_ReceiverUnitID = xmlNode.InnerText;
						}
						break;
					case "UNREP_S":
						if (!string.IsNullOrEmpty(xmlNode.InnerText) && Operators.CompareString(activeUnit_DockingOps.UNREP_Port_ReceiverUnitID, xmlNode.InnerText, TextCompare: false) != 0 && Operators.CompareString(activeUnit_DockingOps.UNREP_Astern_ReceiverUnitID, xmlNode.InnerText, TextCompare: false) != 0)
						{
							activeUnit_DockingOps.UNREP_Starboard_ReceiverUnitID = xmlNode.InnerText;
						}
						break;
					case "HDF":
						activeUnit_DockingOps.expressionWrapper = xmlNode.InnerText;
						break;
					case "UNREP_A":
						if (!string.IsNullOrEmpty(xmlNode.InnerText) && Operators.CompareString(activeUnit_DockingOps.UNREP_Port_ReceiverUnitID, xmlNode.InnerText, TextCompare: false) != 0 && Operators.CompareString(activeUnit_DockingOps.UNREP_Starboard_ReceiverUnitID, xmlNode.InnerText, TextCompare: false) != 0)
						{
							activeUnit_DockingOps.UNREP_Astern_ReceiverUnitID = xmlNode.InnerText;
						}
						break;
					case "CHU":
						activeUnit_DockingOps.registryWrapper = xmlNode.InnerText;
						break;
					case "CT":
						activeUnit_DockingOps.ConditionTimer = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CBRB_Depth":
						activeUnit_DockingOps._FacadeWrapper = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CBRB_ThrottleSetting":
						switch (xmlNode.InnerText)
						{
						default:
							activeUnit_DockingOps.proxyWrapper = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode.InnerText);
							break;
						case "Loiter":
							activeUnit_DockingOps.proxyWrapper = ActiveUnit.Throttle.Loiter;
							break;
						case "FullStop":
							activeUnit_DockingOps.proxyWrapper = ActiveUnit.Throttle.FullStop;
							break;
						case "Full":
							activeUnit_DockingOps.proxyWrapper = ActiveUnit.Throttle.Full;
							break;
						case "Flank":
							activeUnit_DockingOps.proxyWrapper = ActiveUnit.Throttle.Flank;
							break;
						case "Cruise":
							activeUnit_DockingOps.proxyWrapper = ActiveUnit.Throttle.Cruise;
							break;
						}
						break;
					case "AHU":
						activeUnit_DockingOps.configWrapper = xmlNode.InnerText;
						break;
					case "Con":
					case "Condition":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							activeUnit_DockingOps.Condition = (_DockingOpsCondition)Conversions.ToByte(xmlNode.InnerText);
						}
						else
						{
							activeUnit_DockingOps.Condition = (_DockingOpsCondition)Enum.Parse(typeof(_DockingOpsCondition), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "CBRB":
						activeUnit_DockingOps.consumerWrapper = (_DockingOpsCondition)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "OHU":
						activeUnit_DockingOps.definitionWrapper = xmlNode.InnerText;
						break;
					case "PierLL":
						activeUnit_DockingOps.PierLaneLength = XmlConvert.ToSingle(xmlNode.InnerText);
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
			return activeUnit_DockingOps;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100130", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_DockingOps result = new ActiveUnit_DockingOps(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static void PostDeserializationHousekeeping(ActiveUnit_DockingOps activeUnit_DockingOps_0, ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, bool bool_0)
	{
		try
		{
			if (!string.IsNullOrEmpty(activeUnit_DockingOps_0.definitionWrapper))
			{
				activeUnit_DockingOps_0.m_ListenerWrapper = scenario_0.ActiveUnits[activeUnit_DockingOps_0.definitionWrapper];
			}
			if (activeUnit_DockingOps_0.Condition == _DockingOpsCondition.LoadedAsCargo)
			{
				if (activeUnit_DockingOps_0.m_DispatcherWrapper == null && activeUnit_DockingOps_0.configWrapper != null)
				{
					ActiveUnit activeUnit = scenario_0.ActiveUnits[activeUnit_DockingOps_0.configWrapper];
					if (activeUnit == null)
					{
						activeUnit_DockingOps_0.myUnit.DockingOps.Condition = _DockingOpsCondition.Underway;
					}
					else
					{
						activeUnit_DockingOps_0.myUnit.DockingOps.SetAssignedHostUnit(bool_0: false, activeUnit);
					}
				}
				return;
			}
			if (activeUnit_DockingOps_0.HostDockFacility == null && !string.IsNullOrEmpty(activeUnit_DockingOps_0.expressionWrapper))
			{
				if (concurrentDictionary_0.ContainsKey(activeUnit_DockingOps_0.expressionWrapper))
				{
					activeUnit_DockingOps_0.HostDockFacility = (DockFacility)concurrentDictionary_0[activeUnit_DockingOps_0.expressionWrapper];
					if (activeUnit_DockingOps_0.m_DispatcherWrapper != null && Operators.CompareString(activeUnit_DockingOps_0.m_DispatcherWrapper.ObjectID, activeUnit_DockingOps_0.HostDockFacility.ParentPlatform.ObjectID, TextCompare: false) != 0)
					{
						activeUnit_DockingOps_0.m_DispatcherWrapper = activeUnit_DockingOps_0.HostDockFacility.ParentPlatform;
						switch (activeUnit_DockingOps_0.Condition)
						{
						case _DockingOpsCondition.Docked:
							if (activeUnit_DockingOps_0.ConditionTimer > 0f)
							{
								activeUnit_DockingOps_0.Condition = _DockingOpsCondition.Readying;
							}
							break;
						case _DockingOpsCondition.Underway:
						case _DockingOpsCondition.RTB:
						case _DockingOpsCondition.ManoeuveringToRefuel:
						case _DockingOpsCondition.Replenishing:
						case _DockingOpsCondition.ProvidingUNREP:
						case _DockingOpsCondition.RechargingBatteries:
						case _DockingOpsCondition.SettlingForCargoTransfer:
						case _DockingOpsCondition.TransferringCargo:
						case _DockingOpsCondition.TransferringMissionCargo:
							if (activeUnit_DockingOps_0.ConditionTimer == 0f)
							{
								activeUnit_DockingOps_0.Condition = _DockingOpsCondition.Docked;
							}
							else
							{
								activeUnit_DockingOps_0.Condition = _DockingOpsCondition.Docking;
							}
							break;
						}
					}
				}
				else
				{
					bool flag = false;
					foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
					{
						if (activeUnits_ == null)
						{
							continue;
						}
						DockFacility[] dockFacilities_ReadOnly = activeUnits_.DockFacilities_ReadOnly;
						DockFacility[] array = dockFacilities_ReadOnly;
						foreach (DockFacility dockFacility in array)
						{
							if (string.CompareOrdinal(dockFacility.ObjectID, activeUnit_DockingOps_0.expressionWrapper) == 0)
							{
								activeUnit_DockingOps_0.HostDockFacility = dockFacility;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
						break;
					}
				}
			}
			if (activeUnit_DockingOps_0.CurrentHostUnit != null && activeUnit_DockingOps_0.HostDockFacility != null && !activeUnit_DockingOps_0.CurrentHostUnit.DockFacilities_ReadOnly.Contains(activeUnit_DockingOps_0.HostDockFacility))
			{
				activeUnit_DockingOps_0.CurrentHostUnit.DockingOps.AddThisBoat(activeUnit_DockingOps_0.myUnit);
			}
			if (activeUnit_DockingOps_0.m_DispatcherWrapper == null && activeUnit_DockingOps_0.configWrapper != null)
			{
				try
				{
					ActiveUnit activeUnit2 = scenario_0.ActiveUnits[activeUnit_DockingOps_0.configWrapper];
					if (activeUnit2 == null)
					{
						if (!activeUnit_DockingOps_0.myUnit.IsOperating())
						{
							activeUnit_DockingOps_0.myUnit.DockingOps.Condition = _DockingOpsCondition.Underway;
						}
					}
					else if (activeUnit_DockingOps_0.myUnit.IsOperating())
					{
						activeUnit_DockingOps_0.myUnit.DockingOps.SetAssignedHostUnit(bool_0: false, activeUnit2);
					}
					else if (activeUnit_DockingOps_0.CurrentHostUnit != null && Operators.CompareString(activeUnit_DockingOps_0.CurrentHostUnit.ObjectID, activeUnit2.ObjectID, TextCompare: false) != 0)
					{
						if (activeUnit_DockingOps_0.myUnit.IsSubmarine && ((Submarine)activeUnit_DockingOps_0.myUnit).IsTetheredROV)
						{
							activeUnit_DockingOps_0.CurrentHostUnit.DockingOps.AddThisBoat(activeUnit_DockingOps_0.myUnit);
						}
						else
						{
							activeUnit_DockingOps_0.myUnit.DockingOps.SetAssignedHostUnit(bool_0: false, activeUnit2);
						}
					}
					else
					{
						activeUnit2.DockingOps.AddThisBoat(activeUnit_DockingOps_0.myUnit);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200007", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit_DockingOps_0.CurrentHostUnit == null && !activeUnit_DockingOps_0.myUnit.IsOperating() && activeUnit_DockingOps_0.GetAssignedHostUnit() != null)
			{
				activeUnit_DockingOps_0.GetAssignedHostUnit().DockingOps.AddThisBoat(activeUnit_DockingOps_0.myUnit);
			}
			if (!string.IsNullOrEmpty(activeUnit_DockingOps_0.m_WrapperWrapper))
			{
				activeUnit_DockingOps_0._ValWrapper = scenario_0.ActiveUnits[activeUnit_DockingOps_0.m_WrapperWrapper];
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100131", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal List<ActiveUnit> OrderClient()
	{
		List<ActiveUnit> list = null;
		if (myUnit.IsShip || myUnit.IsSubmarine)
		{
			ActiveUnit actualDestinationHost = ActualDestinationHost;
			if (actualDestinationHost != null && HasPiers(actualDestinationHost))
			{
				list = new List<ActiveUnit>();
				list.Add(actualDestinationHost);
			}
		}
		return list;
	}

	public static IEnumerable<ActiveUnit> ReadyBoats(ActiveUnit_DockingOps activeUnit_DockingOps_0)
	{
		try
		{
			return activeUnit_DockingOps_0.EmbarkedBoats.Where((ActiveUnit AC) => AC.DockingOps.Condition == _DockingOpsCondition.Docked && AC.DockingOps.ConditionTimer == 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100132", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void ResetPierEntranceLaneCache()
	{
		readerWrapper = null;
	}

	public static bool HasPiers(ActiveUnit activeUnit_0)
	{
		DockFacility[] dockFacilities_ReadOnly = activeUnit_0.DockFacilities_ReadOnly;
		for (int i = 0; i < dockFacilities_ReadOnly.Length; i = checked(i + 1))
		{
			if (dockFacilities_ReadOnly[i].Type == DockFacility.DockFacilityType.Pier)
			{
				return true;
			}
		}
		return false;
	}

	public bool AttemptToRTB(bool bool_0, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool bool_1, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (Information.IsNothing(ActualDestinationHost))
			{
				PickNewAssignedHost_Nearest();
				if (Information.IsNothing(GetAssignedHostUnit()))
				{
					if (bool_0)
					{
						myUnit.ParentScen.AddMessage(myUnit.Name + "没有合适的地方停靠！", myUnit.Name + " 无法停靠", LoggedMessage.MessageType.DockingOps, 15, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					return false;
				}
				if (!Information.IsNothing(_ActiveUnitStatus_0))
				{
					myUnit.Status = _ActiveUnitStatus_0;
				}
				Condition = _DockingOpsCondition.RTB;
				myUnit.Navigator.ClearPlottedCourse();
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.Kinematics.DesiredAltitudeOverride = false;
				if (bool_1 && myUnit.GetParentGroup() != null)
				{
					foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
					{
						if (value != myUnit)
						{
							value.Status = _ActiveUnitStatus_1;
							value.DockingOps.Condition = _DockingOpsCondition.RTB;
							value.Navigator.ClearPlottedCourse();
							value.Kinematics.DesiredSpeedOverride = null;
							value.Kinematics.DesiredAltitudeOverride = false;
						}
					}
				}
				return true;
			}
			if (!Information.IsNothing(_ActiveUnitStatus_0))
			{
				myUnit.Status = _ActiveUnitStatus_0;
			}
			Condition = _DockingOpsCondition.RTB;
			myUnit.Navigator.ClearPlottedCourse();
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.Kinematics.DesiredAltitudeOverride = false;
			if (bool_1 && myUnit.GetParentGroup() != null)
			{
				foreach (ActiveUnit value2 in myUnit.GetParentGroup().Units.Values)
				{
					if (value2 != myUnit)
					{
						value2.Status = _ActiveUnitStatus_1;
						value2.DockingOps.Condition = _DockingOpsCondition.RTB;
						value2.Navigator.ClearPlottedCourse();
						value2.Kinematics.DesiredSpeedOverride = null;
						value2.Kinematics.DesiredAltitudeOverride = false;
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100134", "");
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
	public ActiveUnit GetAssignedHostUnit(bool bool_0 = false)
	{
		try
		{
			if (bool_0 && (Information.IsNothing(m_DispatcherWrapper) || m_DispatcherWrapper.IsDestroyed))
			{
				PickNewAssignedHost_Nearest();
			}
			return m_DispatcherWrapper;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100137", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[SpecialName]
	public void SetAssignedHostUnit(bool bool_0, ActiveUnit activeUnit_0)
	{
		try
		{
			bool num = activeUnit_0 != m_DispatcherWrapper;
			m_DispatcherWrapper = activeUnit_0;
			if (num && myUnit.IsSubmarine && ((Submarine)myUnit).IsTetheredROV && activeUnit_0 != null)
			{
				ActiveUnit activeUnit = myUnit;
				Mission mission_ = activeUnit_0.AssignedMissionOrPackage();
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				activeUnit.Set_AssignedMissionOrPackage(mission_, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100138", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public ActiveUnit_DockingOps(ref ActiveUnit activeUnit_0)
	{
		PierLaneLength = 7f;
		UNREP_Queue = new List<string>();
		UNREP_Connect_ThresholdRange = 0.3f;
		myUnit = activeUnit_0;
	}

	public void LoadIntoCargo(ActiveUnit activeUnit_0)
	{
		myUnit.Latitude_old = myUnit.GetLatitude();
		myUnit.Longitude_old = myUnit.GetLongitude();
		issuerWrapper = _DockingOpsCondition.LoadedAsCargo;
		SetAssignedHostUnit(bool_0: false, activeUnit_0);
	}

	public void UnloadFromCargo()
	{
		if (!myUnit.IsAircraft && m_DispatcherWrapper != null)
		{
			if (m_DispatcherWrapper.IsFixedFacility)
			{
				m_ListenerWrapper = m_DispatcherWrapper;
			}
			else if (myUnit.IsBoat || myUnit.IsVehicle)
			{
				ActiveUnit_DockingOps dockingOps = m_DispatcherWrapper.DockingOps;
				ActiveUnit activeUnit_ = myUnit;
				DockFacility dockFacility_ = null;
				if (dockingOps.CanHostThisBoat(activeUnit_, ref dockFacility_))
				{
					m_ListenerWrapper = m_DispatcherWrapper;
				}
			}
		}
		m_DispatcherWrapper = null;
		issuerWrapper = _DockingOpsCondition.Underway;
		myUnit.ClearElevationAndAltitudeAGL();
	}

	public void PickupCargoFromSource(ActiveUnit activeUnit_0)
	{
		List<CargoManifestItem> list = Cargo.GenerateCargoManifest(activeUnit_0);
		if (list.Count > 0)
		{
			List<Cargo> list2 = DetermineFeasibleCargoTransferManifest((ICargoHost)activeUnit_0, (ICargoHost)myUnit, list);
			if (list2.Count > 0)
			{
				PerformCargoTransferBetweenHostAndTarget(activeUnit_0, myUnit, list2);
			}
		}
		myUnit.AI.RemovePickupTarget(activeUnit_0.ObjectID);
	}

	internal bool RegisterClient()
	{
		if (myUnit.IsSubmarine)
		{
			return false;
		}
		if (myUnit.IsShip)
		{
			switch (myUnit.SubType)
			{
			default:
				return ((Ship)myUnit).CreateOrder();
			case 4002:
			case 4004:
			case 4005:
			case 4006:
			case 4007:
			case 4008:
			case 4018:
			case 4020:
			case 4021:
			case 4022:
				return true;
			}
		}
		return true;
	}

	internal List<GeoPoint> ManageClient(ActiveUnit activeUnit_0, Module_Unit.Unit unit_0)
	{
		List<GeoPoint> list = new List<GeoPoint>();
		short num = 0;
		short num2 = short.MaxValue;
		if (activeUnit_0 != null && unit_0 != null)
		{
			if (activeUnit_0.IsShip)
			{
				num = short.MinValue;
				num2 = -3;
				if (activeUnit_0.SubType == 4002)
				{
					num2 = 50;
				}
			}
			int num3 = 0;
			double double_ = 0.0;
			double double_2 = 0.0;
			do
			{
				float num4 = 2f;
				do
				{
					Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_, ref double_2, num4, num3);
					short elevation = Terrain.GetElevation(double_2, double_, bool_0: false, myUnit.ParentScen);
					if (elevation < num || elevation > num2)
					{
						break;
					}
					GeoPoint item = new GeoPoint(double_, double_2, elevation);
					list.Add(item);
					num4 += -0.1f;
				}
				while (num4 >= 0f);
				num3++;
			}
			while (num3 <= 359);
			if (list.Any())
			{
				list = list.OrderBy((GeoPoint thepoint) => Math2.VerifyClass(thepoint.Latitude, thepoint.Longitude, unit_0.GetLatitude(), unit_0.GetLongitude())).ToList();
			}
		}
		return list;
	}

	internal List<GeoPoint> RevertClient()
	{
		List<GeoPoint> list = new List<GeoPoint>();
		short num = 1;
		short num2 = short.MaxValue;
		if (myUnit.IsShip)
		{
			num = 0;
			num2 = 50;
		}
		int num3 = 1;
		double double_ = 0.0;
		double double_2 = 0.0;
		do
		{
			float num4 = 0f;
			do
			{
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_, ref double_2, num4, num3);
				short elevation = Terrain.GetElevation(double_2, double_, bool_0: false, myUnit.ParentScen);
				if (elevation > num && elevation < num2)
				{
					GeoPoint item = new GeoPoint(double_, double_2, elevation);
					list.Add(item);
				}
				num4 += 0.1f;
			}
			while (num4 <= 2f);
			num3++;
		}
		while (num3 <= 360);
		return list;
	}

	public void UnloadCargoOverBeach()
	{
		try
		{
			if (myUnit.OnboardCargo.Count() == 0 || myUnit is Group)
			{
				return;
			}
			List<GeoPoint> source = RevertClient();
			if (source.Any())
			{
				GeoPoint geoPoint = source.OrderBy((GeoPoint geoPoint_0) => Math2.VerifyClass(geoPoint_0.Latitude, geoPoint_0.Longitude, myUnit.GetLatitude(), myUnit.GetLongitude())).ElementAtOrDefault(0);
				Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, geoPoint.Latitude, geoPoint.Longitude, myUnit.ParentScen, myUnit.GetUnitSide(), bool_0: false);
				myUnit.CargoTransferList = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101364", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal float CountDic()
	{
		return myUnit.Kinematics.TacticalRadius() / 2f * 0.75f;
	}

	internal bool CustomizeDic()
	{
		bool result = false;
		if (myUnit.AssignedMissionOrPackage() != null)
		{
			float num = CountDic();
			ActiveUnit assignedHostUnit = GetAssignedHostUnit();
			if (myUnit.IsAircraft)
			{
				assignedHostUnit = ((Aircraft)myUnit).AirOps.GetAssignedHostUnit();
			}
			if (assignedHostUnit == null)
			{
				assignedHostUnit = myUnit;
			}
			if (myUnit.AssignedMissionOrPackage().GetAverageDistanceToMissionArea(myUnit, assignedHostUnit) < num)
			{
				result = true;
			}
		}
		return result;
	}

	internal bool CloneDic()
	{
		if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
		{
			bool flag = false;
			List<ActiveUnit> list = new List<ActiveUnit>();
			ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
			if (currentHostUnitCargoSource != null)
			{
				if (currentHostUnitCargoSource.IsGroup)
				{
					foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)currentHostUnitCargoSource).Units)
					{
						list.Add(unit.Value);
					}
				}
				else
				{
					list.Add(currentHostUnitCargoSource);
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			CargoMission cargoMission = (CargoMission)myUnit.AssignedMissionOrPackage();
			foreach (ActiveUnit item in list)
			{
				List<CargoManifestItem> list_ = null;
				if (!cargoMission.MoveAllCargo)
				{
					list_ = cargoMission.CargoToUnload;
				}
				ICargoHost cargoHost = (ICargoHost)item;
				ICargoHost cargoHost2 = (ICargoHost)myUnit;
				if (cargoHost != null && cargoHost2 != null && DetermineFeasibleCargoTransferManifest(cargoHost, cargoHost2, list_).Count > 0)
				{
					return true;
				}
			}
			foreach (Mission mission in myUnit.GetUnitSide().Missions)
			{
				if (mission == myUnit.AssignedMissionOrPackage())
				{
					continue;
				}
				if (mission.MissionClass == Mission._MissionClass.Cargo)
				{
					CargoMission cargoMission2 = (CargoMission)mission;
					if (cargoMission2.Type == CargoMission.CargoMissionType.Transfer && (cargoMission2.MoveAllCargo || cargoMission2.CargoToUnload.Count > 0))
					{
						bool flag2 = false;
						if (cargoMission2.DestinationUnit == currentHostUnitCargoSource)
						{
							flag2 = true;
						}
						else if (currentHostUnitCargoSource.IsGroup)
						{
							foreach (ActiveUnit item2 in list)
							{
								if (cargoMission2.DestinationUnit == item2)
								{
									flag2 = true;
									break;
								}
							}
						}
						if (flag2)
						{
							list.Clear();
							foreach (ActiveUnit item3 in Module_Mission.AssetTokenizer(cargoMission2, myUnit.ParentScen))
							{
								if (item3.HasCargo)
								{
									list.Add(item3);
								}
								ActiveUnit assignedHostUnitCargoSource = item3.AssignedHostUnitCargoSource;
								if (assignedHostUnitCargoSource == null)
								{
									continue;
								}
								if (assignedHostUnitCargoSource.IsGroup)
								{
									foreach (ActiveUnit value in ((Group)assignedHostUnitCargoSource).Units.Values)
									{
										if (!list.Contains(value))
										{
											list.Add(value);
										}
									}
								}
								else if (!list.Contains(assignedHostUnitCargoSource))
								{
									list.Add(assignedHostUnitCargoSource);
								}
							}
							foreach (ActiveUnit item4 in list)
							{
								if (item4.HasCargo)
								{
									List<CargoManifestItem> list_2 = null;
									if (!cargoMission2.MoveAllCargo)
									{
										list_2 = cargoMission2.CargoToUnload;
									}
									ICargoHost cargoHost3 = (ICargoHost)item4;
									ICargoHost cargoHost4 = (ICargoHost)myUnit;
									if (cargoHost3 != null && cargoHost4 != null && DetermineFeasibleCargoTransferManifest(cargoHost3, cargoHost4, list_2).Count > 0)
									{
										flag = true;
										break;
									}
								}
							}
						}
					}
				}
				if (!flag)
				{
					continue;
				}
				break;
			}
			return flag;
		}
		return false;
	}

	internal bool ConnectDic()
	{
		if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
		{
			CargoMission cargoMission = (CargoMission)myUnit.AssignedMissionOrPackage();
			if (cargoMission.DestinationUnit != null)
			{
				ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
				if (currentHostUnitCargoSource == null)
				{
					return false;
				}
				if (cargoMission.DestinationUnit == currentHostUnitCargoSource)
				{
					return true;
				}
				if (!cargoMission.DestinationUnit.IsGroup && !currentHostUnitCargoSource.IsGroup)
				{
					if (cargoMission.DestinationUnit.IsGroupMember() && currentHostUnitCargoSource.IsGroupMember() && cargoMission.DestinationUnit.GetParentGroup() == currentHostUnitCargoSource.GetParentGroup())
					{
						return true;
					}
				}
				else
				{
					if (cargoMission.DestinationUnit.IsGroup && currentHostUnitCargoSource.GetParentGroup() == cargoMission.DestinationUnit)
					{
						return true;
					}
					if (currentHostUnitCargoSource.IsGroup && cargoMission.DestinationUnit.GetParentGroup() == currentHostUnitCargoSource)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	internal bool MoveDic()
	{
		if (myUnit.IsVehicle && ((Vehicle)myUnit).AI.CloneReponse())
		{
			return true;
		}
		if (myUnit.OnboardCargo.Count() > 0)
		{
			if (CargoHostHelper.GetPercentFull((ICargoHost)myUnit) >= 80)
			{
				return true;
			}
			if (!CloneDic())
			{
				return true;
			}
		}
		return false;
	}

	private void DeleteDic()
	{
		try
		{
			if (myUnit.AssignedMissionOrPackage() == null || !myUnit.AssignedMissionOrPackage().IsActive)
			{
				return;
			}
			bool flag = true;
			if (myUnit.AssignedMissionOrPackage() is CargoMission)
			{
				if (((ICargoHost)myUnit).GetCargo_Type() == CargoType.NoCargo)
				{
					return;
				}
				flag = false;
				if (MoveDic())
				{
					flag = true;
				}
				else if (ConnectDic())
				{
					flag = true;
				}
			}
			else if (!myUnit.IsVehicle)
			{
				return;
			}
			if (flag)
			{
				if (CustomizeDic())
				{
					myUnit.DockingOps.Condition = _DockingOpsCondition.DeployingUnderway;
				}
			}
			else
			{
				if (myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Cargo)
				{
					return;
				}
				List<ActiveUnit> list = new List<ActiveUnit>();
				ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
				if (currentHostUnitCargoSource.IsGroup)
				{
					foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)currentHostUnitCargoSource).Units)
					{
						list.Add(unit.Value);
					}
				}
				else
				{
					list.Add(currentHostUnitCargoSource);
				}
				object cargoOpsLockObj = CargoOpsLockObj;
				ObjectFlowControl.CheckForSyncLockOnValueType(cargoOpsLockObj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(cargoOpsLockObj, ref lockTaken);
					CargoMission cargoMission = (CargoMission)myUnit.AssignedMissionOrPackage();
					foreach (ActiveUnit item in list)
					{
						List<CargoManifestItem> list_ = (cargoMission.MoveAllCargo ? null : cargoMission.CargoToUnload);
						List<Cargo> list2 = DetermineFeasibleCargoTransferManifest((ICargoHost)item, (ICargoHost)myUnit, list_, item);
						if (list2.Count <= 0)
						{
							continue;
						}
						PerformCargoTransferBetweenHostAndTarget(item, myUnit, list2);
						Condition = _DockingOpsCondition.Readying;
						if (cargoMission.InstantLoadingForNextManifest)
						{
							cargoMission.InstantLoadingForNextManifest = false;
							ConditionTimer = Math.Max(ConditionTimer, 0f);
						}
						else
						{
							ConditionTimer = Math.Max(ConditionTimer, TimeToLoadCargo(myUnit, list2));
						}
						foreach (Cargo item2 in list2)
						{
							CargoManifestItem.Remove(item2, cargoMission.CargoToUnload);
						}
					}
					return;
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(cargoOpsLockObj);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101365", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static List<Cargo> DetermineFeasibleCargoTransferManifest(ICargoHost icargoHost_0, ICargoHost icargoHost_1, List<CargoManifestItem> list_0, ActiveUnit activeUnit_0 = null)
	{
		List<Cargo> list = new List<Cargo>();
		List<CargoManifestItem> list2 = null;
		if (list_0 != null)
		{
			list2 = new List<CargoManifestItem>();
			foreach (CargoManifestItem item3 in list_0)
			{
				CargoManifestItem item = new CargoManifestItem(item3);
				list2.Add(item);
			}
		}
		double num = icargoHost_1.GetCargo_Mass();
		double num2 = icargoHost_1.GetCargo_Area();
		double num3 = icargoHost_1.GetCargo_Crew();
		Cargo[] onboardCargo = ((ActiveUnit)icargoHost_1).OnboardCargo;
		Cargo[] array = onboardCargo;
		foreach (Cargo cargo in array)
		{
			num -= (double)cargo.RequiredMass;
			num2 -= (double)cargo.RequiredArea;
			num3 -= (double)cargo.RequiredCrewSpace;
		}
		if (icargoHost_0 != activeUnit_0 && icargoHost_0 is ICargoClient)
		{
			ICargoClient cargoClient = (ICargoClient)icargoHost_0;
			if (cargoClient != null && cargoClient.GetRequiredCargoType() != 0)
			{
				if (icargoHost_0 is Vehicle)
				{
					Cargo cargo2 = null;
					if (icargoHost_1.CanLoad(cargoClient))
					{
						cargo2 = new Cargo(null, (Vehicle)icargoHost_0);
					}
					else if (icargoHost_1.CanTow(cargoClient))
					{
						cargo2 = new Cargo(null, (Vehicle)icargoHost_0);
						cargo2.StorageType = Cargo.CargoStorageType.TowedExternal;
					}
					if (cargo2 != null)
					{
						list.Add(cargo2);
						return list;
					}
				}
				else if (icargoHost_0 is Facility && icargoHost_1.CanLoad(cargoClient))
				{
					Cargo item2 = new Cargo(null, (Facility)icargoHost_0);
					list.Add(item2);
					return list;
				}
			}
		}
		Dictionary<string, int> Local_GroupDictionary = new Dictionary<string, int>();
		int num4 = 0;
		Cargo[] onboardCargo2 = ((ActiveUnit)icargoHost_0).OnboardCargo;
		for (int i = 0; i < onboardCargo2.Length; i = checked(i + 1))
		{
			ActiveUnit cargoObjectActiveUnit = onboardCargo2[i].CargoObjectActiveUnit;
			if (cargoObjectActiveUnit != null && cargoObjectActiveUnit.GetParentGroup() != null && !Local_GroupDictionary.Keys.Contains(cargoObjectActiveUnit.GetParentGroup().ObjectID))
			{
				Local_GroupDictionary.Add(cargoObjectActiveUnit.GetParentGroup().ObjectID, 2 * num4);
				num4++;
			}
		}
		foreach (Cargo item4 in ((ActiveUnit)icargoHost_0).OnboardCargo.OrderBy(delegate(Cargo s)
		{
			ActiveUnit cargoObjectActiveUnit2 = s.CargoObjectActiveUnit;
			int value;
			return (cargoObjectActiveUnit2 == null || cargoObjectActiveUnit2.GetParentGroup() == null || !Local_GroupDictionary.TryGetValue(cargoObjectActiveUnit2.GetParentGroup().ObjectID, out value)) ? int.MaxValue : ((!cargoObjectActiveUnit2.IsGroupLead()) ? (value + 1) : value);
		}))
		{
			if (item4.RequiredCargoType > icargoHost_1.GetCargo_Type() || (item4.CargoObjectActiveUnit != null && item4.CargoObjectActiveUnit.IsVehicle && ((Vehicle)item4.CargoObjectActiveUnit).AI.CloneReponse()))
			{
				continue;
			}
			bool flag = false;
			int num5 = 0;
			if (list2 == null)
			{
				flag = true;
				num5 = 1;
			}
			else
			{
				CargoManifestItem cargoManifestItem = CargoManifestItem.FindMatch(item4, list2);
				if (cargoManifestItem != null)
				{
					flag = true;
					num5 = cargoManifestItem.quantity;
				}
			}
			if (flag && num5 >= 1 && num >= (double)item4.RequiredMass && num2 >= (double)item4.RequiredArea && num3 >= (double)item4.RequiredCrewSpace)
			{
				list.Add(item4);
				CargoManifestItem.Remove(item4, list2);
				num -= (double)item4.RequiredMass;
				num2 -= (double)item4.RequiredArea;
				num3 -= (double)item4.RequiredCrewSpace;
			}
		}
		ActiveUnit activeUnit = (ActiveUnit)icargoHost_0;
		if (activeUnit.IsMobileGroundUnit && Module_ActiveUnit.CancelTokenizer(activeUnit))
		{
			foreach (Mount mount in activeUnit.Mounts)
			{
				if (mount.Cargo_Type != 0 && mount.Cargo_Type <= icargoHost_1.GetCargo_Type())
				{
					Cargo cargo3 = new Cargo(activeUnit, mount);
					CargoManifestItem cargoManifestItem2 = CargoManifestItem.FindMatch(cargo3, list2);
					if (cargoManifestItem2 != null && cargoManifestItem2.quantity >= 1 && num >= (double)cargo3.RequiredMass && num2 >= (double)cargo3.RequiredArea && num3 >= (double)cargo3.RequiredCrewSpace)
					{
						list.Add(cargo3);
						CargoManifestItem.Remove(cargo3, list2);
						num -= (double)cargo3.RequiredMass;
						num2 -= (double)cargo3.RequiredArea;
						num3 -= (double)cargo3.RequiredCrewSpace;
					}
				}
			}
		}
		return list;
	}

	public bool SettleForCargoMissionTransfer(ActiveUnit activeUnit_0)
	{
		try
		{
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.DesiredSpeed = 0f;
			Condition = _DockingOpsCondition.TransferringMissionCargo;
			ConditionTimer = 0f;
			if (myUnit.IsVehicle)
			{
				if (myUnit.OnboardCargo.Count() == 0)
				{
					if (myUnit.AssignedMissionOrPackage() != null)
					{
						CargoMission cargoMission = (CargoMission)myUnit.AssignedMissionOrPackage();
						List<CargoManifestItem> list_ = null;
						if (!cargoMission.MoveAllCargo)
						{
							list_ = cargoMission.CargoToUnload;
						}
						List<Cargo> list = DetermineFeasibleCargoTransferManifest((ICargoHost)activeUnit_0, (ICargoHost)myUnit, list_, activeUnit_0);
						if (list.Count <= 0)
						{
							Condition = _DockingOpsCondition.Underway;
							ConditionTimer = 300f;
						}
						else
						{
							ConditionTimer = Math.Max(240, TimeToLoadCargo(myUnit, list));
							PerformCargoTransferBetweenHostAndTarget(activeUnit_0, myUnit, list);
						}
					}
				}
				else if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
				{
					CargoMission cargoMission2 = (CargoMission)myUnit.AssignedMissionOrPackage();
					ConditionTimer = Math.Max(240, TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
					PerformCargoTransferBetweenHostAndTarget(myUnit, activeUnit_0, myUnit.OnboardCargo.ToList(), cargoMission2.UnpackAllContainers);
				}
				else
				{
					ConditionTimer = Math.Max(240, TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
					PerformCargoTransferBetweenHostAndTarget(myUnit, activeUnit_0, myUnit.OnboardCargo.ToList());
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1034205823409586290485912038412A", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool SettleForCargoTransfer()
	{
		try
		{
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.DesiredSpeed = 0f;
			Condition = _DockingOpsCondition.TransferringCargo;
			if (!myUnit.IsShip && !myUnit.IsVehicle)
			{
				ConditionTimer = 0f;
			}
			else
			{
				ConditionTimer = Math.Max(240, TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1034205823409586290485912038412", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void DoDockingOps(float float_0)
	{
		try
		{
			ComputeDic(float_0);
			GetDic(float_0);
			CallDic();
			ConditionTimer -= float_0;
			if (ConditionTimer < 0f)
			{
				ConditionTimer = 0f;
			}
			if (ConditionTimer != 0f)
			{
				return;
			}
			switch (Condition)
			{
			case _DockingOpsCondition.Docked:
				DeleteDic();
				break;
			case _DockingOpsCondition.DeployingUnderway:
				SetupDic(float_0);
				break;
			case _DockingOpsCondition.Docking:
				ExcludeDic();
				break;
			case _DockingOpsCondition.Readying:
				Condition = _DockingOpsCondition.Docked;
				break;
			case _DockingOpsCondition.ManoeuveringToRefuel:
				AttemptToConnectToTanker();
				break;
			case _DockingOpsCondition.ProvidingUNREP:
				SelectDic(float_0);
				NewDic(float_0);
				DestroyDic();
				if (!IsCurrentlyProvidingUNREP)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					Condition = _DockingOpsCondition.Underway;
					if (myUnit.IsMobileGroundUnit)
					{
						myUnit.Kinematics.DesiredSpeedOverride = null;
						myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
					}
				}
				break;
			case _DockingOpsCondition.TransferringCargo:
				if (myUnit.IsShip)
				{
					if (myUnit.AI.PrimaryPickupTarget == null)
					{
						if (RegisterClient())
						{
							UnloadCargoOverBeach();
						}
					}
					else if (myUnit.AI.PrimaryPickupTarget.IsActiveUnit)
					{
						PickupCargoFromSource(myUnit.AI.PrimaryPickupTarget);
					}
				}
				else if (myUnit.IsVehicle)
				{
					if (myUnit.AI.PrimaryPickupTarget == null)
					{
						UnloadCargoOverBeach();
					}
					else if (myUnit.AI.PrimaryPickupTarget.IsActiveUnit)
					{
						PickupCargoFromSource(myUnit.AI.PrimaryPickupTarget);
					}
				}
				else if (myUnit.IsFixedFacility)
				{
					if (myUnit.AI.PrimaryPickupTarget == null)
					{
						Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.ParentScen, myUnit.GetUnitSide(), bool_0: false);
					}
					else if (myUnit.AI.PrimaryPickupTarget.IsActiveUnit)
					{
						if (Module_Unit.RangeToUnit_Horiz(myUnit, myUnit.AI.PrimaryPickupTarget) < 2f)
						{
							PickupCargoFromSource(myUnit.AI.PrimaryPickupTarget);
						}
						else
						{
							myUnit.AddMessage(myUnit.Name + " is too far (> 2nm) from cargo pick up target " + myUnit.AI.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							myUnit.AI.RemovePickupTarget(myUnit.AI.PrimaryPickupTarget.ObjectID);
						}
					}
				}
				myUnit.CargoTransferList = null;
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				Condition = _DockingOpsCondition.Underway;
				ConditionTimer = 0f;
				break;
			case _DockingOpsCondition.TransferringMissionCargo:
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				Condition = _DockingOpsCondition.Underway;
				ConditionTimer = 0f;
				break;
			case _DockingOpsCondition.RTB:
			case _DockingOpsCondition.Replenishing:
			case _DockingOpsCondition.RechargingBatteries:
			case _DockingOpsCondition.SettlingForCargoTransfer:
			case _DockingOpsCondition.LoadedAsCargo:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100143", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AddDic()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_.DockingOps.UNREP_Destination == myUnit && activeUnits_.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				list.Add(activeUnits_);
			}
		}
		foreach (ActiveUnit item in list)
		{
			if (Module_Unit.RangeToUnit_Horiz(myUnit, item) <= UNREP_Connect_ThresholdRange * 2f)
			{
				if (GetFuelWeCanSupplyToThisUnit(item) <= 0 && GetMaterialWeCanSupplyToThisUnit(item) <= 0)
				{
					item.DockingOps.DisconnectFromSupplier();
				}
			}
			else
			{
				item.DockingOps.DisconnectFromSupplier();
			}
		}
	}

	private void DestroyDic()
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			try
			{
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					ActiveUnit activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Port_ReceiverUnitID];
					if (Module_Unit.RangeToUnit_Horiz(myUnit, activeUnit) <= UNREP_Connect_ThresholdRange * 2f)
					{
						if (GetFuelWeCanSupplyToThisUnit(activeUnit) <= 0 && GetMaterialWeCanSupplyToThisUnit(activeUnit) <= 0)
						{
							activeUnit.DockingOps.DisconnectFromSupplier();
						}
					}
					else
					{
						activeUnit.DockingOps.DisconnectFromSupplier();
					}
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					ActiveUnit activeUnit2 = myUnit.ParentScen.ActiveUnits[UNREP_Starboard_ReceiverUnitID];
					if (Module_Unit.RangeToUnit_Horiz(myUnit, activeUnit2) <= UNREP_Connect_ThresholdRange * 2f)
					{
						if (GetFuelWeCanSupplyToThisUnit(activeUnit2) <= 0 && GetMaterialWeCanSupplyToThisUnit(activeUnit2) <= 0)
						{
							activeUnit2.DockingOps.DisconnectFromSupplier();
						}
					}
					else
					{
						activeUnit2.DockingOps.DisconnectFromSupplier();
					}
				}
				if (!string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					ActiveUnit activeUnit3 = myUnit.ParentScen.ActiveUnits[UNREP_Astern_ReceiverUnitID];
					if (Module_Unit.RangeToUnit_Horiz(myUnit, activeUnit3) <= UNREP_Connect_ThresholdRange * 2f)
					{
						if (GetFuelWeCanSupplyToThisUnit(activeUnit3) <= 0 && GetMaterialWeCanSupplyToThisUnit(activeUnit3) <= 0)
						{
							activeUnit3.DockingOps.DisconnectFromSupplier();
						}
					}
					else
					{
						activeUnit3.DockingOps.DisconnectFromSupplier();
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100144", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		AddDic();
	}

	public void DisconnectFromSupplier_Facility()
	{
		if (UNREP_Destination != null && UNREP_Destination.DockingOps.UNREP_Queue.Contains(myUnit.ObjectID))
		{
			UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
		}
		UNREP_Destination = null;
		myUnit.Kinematics.DesiredSpeedOverride = null;
		myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
		Condition = _DockingOpsCondition.Underway;
	}

	public void DisconnectFromSupplier()
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			try
			{
				if (UNREP_Destination != null)
				{
					ActiveUnit uNREP_Destination = UNREP_Destination;
					if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID, myUnit.ObjectID, TextCompare: false) == 0)
					{
						UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID = null;
						UNREP_Destination = null;
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						Condition = _DockingOpsCondition.Underway;
					}
					else if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID, myUnit.ObjectID, TextCompare: false) == 0)
					{
						UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID = null;
						UNREP_Destination = null;
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						Condition = _DockingOpsCondition.Underway;
					}
					else if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID, myUnit.ObjectID, TextCompare: false) == 0)
					{
						UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID = null;
						UNREP_Destination = null;
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						Condition = _DockingOpsCondition.Underway;
					}
					else if (uNREP_Destination != null && uNREP_Destination.DockingOps.UNREP_Queue.Contains(myUnit.ObjectID))
					{
						uNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100145", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		DisconnectFromSupplier_Facility();
	}

	private void ComputeDic(float float_0)
	{
		try
		{
			float num = 63.33f;
			int num2 = 0;
			foreach (ActiveUnit embarkedBoat in EmbarkedBoats)
			{
				_DockingOpsCondition condition = embarkedBoat.DockingOps.Condition;
				if (condition != _DockingOpsCondition.Docked && condition != _DockingOpsCondition.Readying)
				{
					continue;
				}
				switch (embarkedBoat.VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					num2 = 1;
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					num2 = 2;
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					num2 = 3;
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					num2 = 4;
					break;
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					num2 = 5;
					break;
				}
				float val = num * (float)num2 * float_0;
				foreach (FuelRec Local_theFR in embarkedBoat.Fuel_ReadOnly.Where((FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity))
				{
					if (Local_theFR.FuelType == FuelRec._FuelType.Battery)
					{
						Local_theFR.CurrentQuantity = Local_theFR.MaxQuantity;
						continue;
					}
					FuelRec fuelRec = (myUnit.IsFixedFacility ? new FuelRec(int.MaxValue, (short)Local_theFR.FuelType) : myUnit.Fuel_ReadOnly.Where((FuelRec theF) => (theF.FuelType == Local_theFR.FuelType) & (theF.CurrentQuantity > 0f)).DefaultIfEmpty(null).FirstOrDefault());
					if (!Information.IsNothing(fuelRec))
					{
						float num3 = (float)Local_theFR.MaxQuantity - Local_theFR.CurrentQuantity;
						float num4 = Math.Min(val, fuelRec.CurrentQuantity);
						if (num3 < num4)
						{
							embarkedBoat.Fuel_Add(num3, fuelRec.FuelType);
							fuelRec.CurrentQuantity -= num3;
						}
						else
						{
							embarkedBoat.Fuel_Add(num4, fuelRec.FuelType);
							fuelRec.CurrentQuantity -= num4;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101366", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PatchDic(float float_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_.DockingOps.UNREP_Destination == myUnit && activeUnits_.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				list.Add(activeUnits_);
			}
		}
		float num = 0.5f / (float)list.Count;
		foreach (ActiveUnit item in list)
		{
			float val = num * float_0;
			foreach (FuelRec Local_theFR in item.Fuel_ReadOnly.Where((FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity))
			{
				FuelRec fuelRec = myUnit.Fuel_ReadOnly.Where((FuelRec theF) => theF.FuelType == Local_theFR.FuelType && theF.CurrentQuantity > 0f).DefaultIfEmpty(null).FirstOrDefault();
				if (!Information.IsNothing(fuelRec))
				{
					float num2 = (float)Local_theFR.MaxQuantity - Local_theFR.CurrentQuantity;
					float num3 = Math.Min(val, fuelRec.CurrentQuantity);
					if (num2 < num3)
					{
						item.Fuel_Add(num2, fuelRec.FuelType);
						fuelRec.CurrentQuantity -= num2;
					}
					else
					{
						item.Fuel_Add(num3, fuelRec.FuelType);
						fuelRec.CurrentQuantity -= num3;
					}
				}
			}
		}
	}

	private void SelectDic(float float_0)
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			float num = 63.33f;
			try
			{
				ActiveUnit activeUnit;
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Port_ReceiverUnitID];
					byte instanceComparator = myUnit.UNREP_Capabilities.instanceComparator;
					float val = num * (float)(int)instanceComparator * float_0;
					foreach (FuelRec Local_theFR in activeUnit.Fuel_ReadOnly.Where((FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity))
					{
						FuelRec fuelRec = myUnit.Fuel_ReadOnly.Where((FuelRec theF) => theF.FuelType == Local_theFR.FuelType && theF.CurrentQuantity > 0f).DefaultIfEmpty(null).FirstOrDefault();
						if (!Information.IsNothing(fuelRec))
						{
							float num2 = (float)Local_theFR.MaxQuantity - Local_theFR.CurrentQuantity;
							float num3 = Math.Min(val, fuelRec.CurrentQuantity);
							if (num2 < num3)
							{
								activeUnit.Fuel_Add(num2, fuelRec.FuelType);
								fuelRec.CurrentQuantity -= num2;
							}
							else
							{
								activeUnit.Fuel_Add(num3, fuelRec.FuelType);
								fuelRec.CurrentQuantity -= num3;
							}
						}
					}
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Starboard_ReceiverUnitID];
					byte parameterComparator = myUnit.UNREP_Capabilities.m_ParameterComparator;
					float val2 = num * (float)(int)parameterComparator * float_0;
					foreach (FuelRec Local_theFR2 in activeUnit.Fuel_ReadOnly.Where((FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity))
					{
						FuelRec fuelRec2 = myUnit.Fuel_ReadOnly.Where((FuelRec theF) => theF.FuelType == Local_theFR2.FuelType && theF.CurrentQuantity > 0f).DefaultIfEmpty(null).FirstOrDefault();
						if (!Information.IsNothing(fuelRec2))
						{
							float num4 = (float)Local_theFR2.MaxQuantity - Local_theFR2.CurrentQuantity;
							float num5 = Math.Min(val2, fuelRec2.CurrentQuantity);
							if (num4 < num5)
							{
								activeUnit.Fuel_Add(num4, fuelRec2.FuelType);
								fuelRec2.CurrentQuantity -= num4;
							}
							else
							{
								activeUnit.Fuel_Add(num5, fuelRec2.FuelType);
								fuelRec2.CurrentQuantity -= num5;
							}
						}
					}
				}
				if (string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					return;
				}
				activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Astern_ReceiverUnitID];
				byte ruleComparator = myUnit.UNREP_Capabilities.m_RuleComparator;
				float val3 = num * (float)(int)ruleComparator * float_0;
				foreach (FuelRec Local_theFR3 in activeUnit.Fuel_ReadOnly.Where((FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity))
				{
					FuelRec fuelRec3 = myUnit.Fuel_ReadOnly.Where((FuelRec theF) => theF.FuelType == Local_theFR3.FuelType && theF.CurrentQuantity > 0f).DefaultIfEmpty(null).FirstOrDefault();
					if (!Information.IsNothing(fuelRec3))
					{
						float num6 = (float)Local_theFR3.MaxQuantity - Local_theFR3.CurrentQuantity;
						float num7 = Math.Min(val3, fuelRec3.CurrentQuantity);
						if (num6 < num7)
						{
							activeUnit.Fuel_Add(num6, fuelRec3.FuelType);
							fuelRec3.CurrentQuantity -= num6;
						}
						else
						{
							activeUnit.Fuel_Add(num7, fuelRec3.FuelType);
							fuelRec3.CurrentQuantity -= num7;
						}
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100146", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		PatchDic(float_0);
	}

	private void CallDic()
	{
		if (!myUnit.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
		{
			return;
		}
		foreach (ActiveUnit embarkedBoat in EmbarkedBoats)
		{
			embarkedBoat.Damage.PerformComponentRepairs(myUnit.Proficiency.Value);
			embarkedBoat.Damage.PerformStructuralRepairs(myUnit.Proficiency.Value);
		}
	}

	private bool LogoutDic(float float_0)
	{
		if (float_0 <= 10f)
		{
			if (myUnit.ParentScen.SecondIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (float_0 <= 50f)
		{
			if (myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (float_0 <= 100f)
		{
			if (myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (float_0 <= 150f)
		{
			if (myUnit.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (float_0 <= 250f)
		{
			if (myUnit.ParentScen.MinuteIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (float_0 <= 500f)
		{
			if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (float_0 <= 1000f)
		{
			if (myUnit.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (float_0 <= 2500f)
		{
			if (myUnit.ParentScen.ThirtiethMinuteIsChangingOnThisPulse)
			{
				return true;
			}
		}
		else if (myUnit.ParentScen.HourIsChangingOnThisPulse)
		{
			return true;
		}
		return false;
	}

	private bool ViewDic(Weapon weapon_0)
	{
		try
		{
			if (weapon_0.MaxWeight <= 0)
			{
				switch (weapon_0.Type)
				{
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.Gun:
					switch (weapon_0.Warheads[0].Caliber)
					{
					default:
						if (LogoutDic(weapon_0.MaxWeight))
						{
							return true;
						}
						if (myUnit.ParentScen.HourIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_6_15mm:
					case Warhead.WarheadCaliber.Rocket_6_15mm:
						if (myUnit.ParentScen.SecondIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_16_24mm:
					case Warhead.WarheadCaliber.Rocket_16_24mm:
						if (myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_25_60mm:
					case Warhead.WarheadCaliber.Rocket_25_60mm:
						if (myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_61_80mm:
					case Warhead.WarheadCaliber.Rocket_61_80mm:
						if (myUnit.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_81_150mm:
					case Warhead.WarheadCaliber.Rocket_81_150mm:
						if (myUnit.ParentScen.MinuteIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_151_200mm:
					case Warhead.WarheadCaliber.Rocket_151_200mm:
						if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_201_350mm:
					case Warhead.WarheadCaliber.Rocket_201_350mm:
						if (myUnit.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					case Warhead.WarheadCaliber.Gun_351_450mm:
					case Warhead.WarheadCaliber.Rocket_351_450mm:
						if (myUnit.ParentScen.ThirtiethMinuteIsChangingOnThisPulse)
						{
							return true;
						}
						break;
					}
					break;
				case Weapon._WeaponType.Decoy_Expendable:
				case Weapon._WeaponType.Decoy_Vehicle:
				case Weapon._WeaponType.UAV_Expendable:
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						return true;
					}
					break;
				case Weapon._WeaponType.Dispenser:
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						return true;
					}
					break;
				case Weapon._WeaponType.Laser:
				case Weapon._WeaponType.Microwave:
				case Weapon._WeaponType.LaserDazzler:
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						return true;
					}
					break;
				case Weapon._WeaponType.DepthCharge:
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						return true;
					}
					break;
				default:
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						return true;
					}
					break;
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.MooredMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						return true;
					}
					break;
				case Weapon._WeaponType.DropTank:
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						return true;
					}
					break;
				}
			}
			else if (LogoutDic(weapon_0.MaxWeight))
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101367", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void ValidateDic(ActiveUnit activeUnit_0)
	{
		if (GetMaterialWeCanSupplyToThisUnit(activeUnit_0) <= 0)
		{
			return;
		}
		Dictionary<int, Weapon> dictionary = activeUnit_0.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: true);
		int num = 1;
		foreach (int key in dictionary.Keys)
		{
			if (num == 0)
			{
				break;
			}
			Weapon weapon_ = myUnit.ParentScen.Cache_GetWeapon(key);
			if (activeUnit_0.Weaponry.TotalDefaultCapacityForThisWeapon(key) - activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(key, bool_1: false) == 0 || !ViewDic(weapon_) || Operators.CompareString(activeUnit_0.Weaponry.CanAddWeaponToUnit(key, bool_1: false, bool_2: false), "OK", TextCompare: false) != 0)
			{
				continue;
			}
			if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				if (Operators.CompareString(activeUnit_0.Weaponry.AddWeaponToUnit(key, bool_1: false, bool_2: false), "OK", TextCompare: false) == 0)
				{
					num--;
				}
				continue;
			}
			Magazine[] array = ((!myUnit.IsGroupMember() || !myUnit.GetParentGroup().IsLandInstallation) ? myUnit.SharedMagazines : myUnit.GetParentGroup().SharedMagazines);
			for (int i = 0; i < array.Length; i++)
			{
				foreach (WeaponRec weapon in array[i].Weapons)
				{
					if (weapon.CurrentLoad > 0 && weapon.int_0 == key && Operators.CompareString(activeUnit_0.Weaponry.AddWeaponToUnit(key, bool_1: false, bool_2: false), "OK", TextCompare: false) == 0)
					{
						weapon.CurrentLoad--;
						weapon.ResetTimeToFire();
						num--;
						if (num == 0)
						{
							break;
						}
					}
				}
			}
		}
	}

	private void LoginDic(ActiveUnit activeUnit_0)
	{
		try
		{
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (GetMaterialWeCanSupplyToThisUnit(activeUnit_0) <= 0)
				{
					return;
				}
				Dictionary<int, Weapon> dictionary = activeUnit_0.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: true);
				int num = 1;
				if ((myUnit.UNREP_Capabilities.m_CollectionComparator == 4) | (myUnit.UNREP_Capabilities.m_ObjectComparator == 4))
				{
					num *= 4;
				}
				else if ((myUnit.UNREP_Capabilities.m_CollectionComparator == 3) | (myUnit.UNREP_Capabilities.m_ObjectComparator == 3))
				{
					num *= 3;
				}
				else if ((myUnit.UNREP_Capabilities.m_CollectionComparator == 2) | (myUnit.UNREP_Capabilities.m_ObjectComparator == 2))
				{
					num *= 2;
				}
				if (myUnit.IsFacility)
				{
					num *= 2;
				}
				if (activeUnit_0.IsSubmarine)
				{
					num = Math.Max(1, (int)Math.Round((double)num / 2.0));
				}
				{
					foreach (int key in dictionary.Keys)
					{
						if (num == 0)
						{
							break;
						}
						Weapon weapon_ = myUnit.ParentScen.Cache_GetWeapon(key);
						if (activeUnit_0.Weaponry.TotalDefaultCapacityForThisWeapon(key) - activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(key, bool_1: false) == 0 || !ViewDic(weapon_) || Operators.CompareString(activeUnit_0.Weaponry.CanReplenishWeaponToUnit(key, bool_1: false, bool_2: false), "OK", TextCompare: false) != 0)
						{
							continue;
						}
						if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
						{
							if (Operators.CompareString(activeUnit_0.Weaponry.AddWeaponToUnit(key, bool_1: false, bool_2: false), "OK", TextCompare: false) == 0)
							{
								num--;
							}
							continue;
						}
						Magazine[] array = ((!myUnit.IsGroupMember() || !myUnit.GetParentGroup().IsLandInstallation) ? myUnit.SharedMagazines : myUnit.GetParentGroup().SharedMagazines);
						for (int i = 0; i < array.Length; i++)
						{
							foreach (WeaponRec weapon in array[i].Weapons)
							{
								if (weapon.CurrentLoad > 0 && weapon.int_0 == key && Operators.CompareString(activeUnit_0.Weaponry.AddWeaponToUnit(key, bool_1: false, bool_2: false), "OK", TextCompare: false) == 0)
								{
									weapon.CurrentLoad--;
									weapon.ResetTimeToFire();
									num--;
								}
							}
						}
					}
					return;
				}
			}
			ValidateDic(activeUnit_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101368", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void GetDic(float float_0)
	{
		try
		{
			foreach (ActiveUnit embarkedBoat in EmbarkedBoats)
			{
				_DockingOpsCondition condition = embarkedBoat.DockingOps.Condition;
				if (condition == _DockingOpsCondition.Docked || condition == _DockingOpsCondition.Readying)
				{
					LoginDic(embarkedBoat);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101369", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void WriteDic(float float_0)
	{
		foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_.DockingOps.UNREP_Destination == myUnit && activeUnits_.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				LoginDic(activeUnits_);
			}
		}
	}

	private void NewDic(float float_0)
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			try
			{
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					list.Add(myUnit.ParentScen.ActiveUnits[UNREP_Port_ReceiverUnitID]);
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					list.Add(myUnit.ParentScen.ActiveUnits[UNREP_Starboard_ReceiverUnitID]);
				}
				if (!string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					list.Add(myUnit.ParentScen.ActiveUnits[UNREP_Astern_ReceiverUnitID]);
				}
				foreach (ActiveUnit item in list)
				{
					string objectID = item.ObjectID;
					if (Operators.CompareString(objectID, UNREP_Port_ReceiverUnitID, TextCompare: false) == 0)
					{
						LoginDic(item);
					}
					else if (Operators.CompareString(objectID, UNREP_Starboard_ReceiverUnitID, TextCompare: false) == 0)
					{
						LoginDic(item);
					}
					else if (Operators.CompareString(objectID, UNREP_Astern_ReceiverUnitID, TextCompare: false) == 0)
					{
						LoginDic(item);
					}
					else if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100147", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		WriteDic(float_0);
	}

	[SpecialName]
	public int GetFuelWeCanSupplyToThisUnit(ActiveUnit activeUnit_0, float float_0 = 0f)
	{
		try
		{
			int num = 0;
			foreach (FuelRec item in activeUnit_0.Fuel_ReadOnly)
			{
				if (!(item.CurrentQuantity < (float)item.MaxQuantity))
				{
					continue;
				}
				int num2 = (int)Math.Round((float)item.MaxQuantity - item.CurrentQuantity);
				int num3 = 0;
				int num4 = 0;
				foreach (FuelRec item2 in myUnit.Fuel_ReadOnly)
				{
					if (item2.FuelType == item.FuelType)
					{
						num3 = (int)Math.Round((float)num3 + item2.CurrentQuantity);
						num4 += item2.MaxQuantity;
					}
				}
				if (float_0 <= 0f || (float)num4 >= float_0)
				{
					num = ((num2 < num3) ? (num + num2) : (num + num3));
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100148", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[SpecialName]
	public int GetMaterialWeCanSupplyToThisUnit(ActiveUnit activeUnit_0, Dictionary<int, Weapon> dictionary_0 = null)
	{
		try
		{
			Dictionary<int, Weapon> dictionary = activeUnit_0.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: true);
			int num = 0;
			foreach (int key in dictionary.Keys)
			{
				if (dictionary_0 != null && !dictionary_0.ContainsKey(key))
				{
					continue;
				}
				int num2 = activeUnit_0.Weaponry.TotalDefaultCapacityForThisWeapon(key);
				int num3 = activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(key, bool_1: false);
				int num4 = num2 - num3;
				if (num4 > 0)
				{
					int num5 = (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines) ? int.MaxValue : myUnit.Weaponry.HowManyOfThisWeaponOnMagazines(key));
					if (num5 != 0 && Operators.CompareString(activeUnit_0.Weaponry.CanReplenishWeaponToUnit(key, bool_1: false, bool_2: false), "OK", TextCompare: false) == 0)
					{
						num = ((num4 < num5) ? (num + num4) : (num + num5));
					}
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100149", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public bool AttemptToConnectToTanker()
	{
		try
		{
			if (UNREP_Destination.DockingOps.Condition != _DockingOpsCondition.ManoeuveringToRefuel && UNREP_Destination.DockingOps.Condition != _DockingOpsCondition.Replenishing)
			{
				if (myUnit.IsOutOfFuel && (myUnit.IsFacility || myUnit.IsMobileGroundUnit) && UNREP_Destination.Navigator.PlottedCourse.Length == 0)
				{
					ActiveUnit uNREP_Destination = UNREP_Destination;
					double latitude = myUnit.GetLatitude();
					double longitude = myUnit.GetLongitude();
					int int_ = 0;
					bool bool_ = true;
					bool bool_2 = true;
					List<ActiveUnit> list_ = null;
					string string_ = null;
					bool bool_3 = false;
					if (uNREP_Destination.CanMoveToThisLocation(latitude, longitude, ref int_, bool_0: true, bool_1: false, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3) && UNREP_Destination.CanPlotCourseToThisLocation(myUnit.GetLatitude(), myUnit.GetLongitude()))
					{
						UNREP_Destination.Navigator.AddWaypoint(myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.GetCurrentAltitude(), Waypoint.WaypointType.Refuel, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					}
				}
				if (Module_Unit.RangeToUnit_Horiz(myUnit, UNREP_Destination) <= UNREP_Connect_ThresholdRange)
				{
					if (!(UNREP_Destination.CurrentSpeed <= 0f) && !(myUnit.CurrentSpeed <= 0f) && Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, UNREP_Destination.CurrentHeading)) > 20f)
					{
						return false;
					}
					if (UNREP_Destination.GetCanPhysicallyReplenishThisUnit(myUnit) && (string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID) || string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID) || string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID)))
					{
						PushDic();
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100150", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void PushDic()
	{
		try
		{
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID, myUnit.ObjectID, TextCompare: false) != 0 && Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID, myUnit.ObjectID, TextCompare: false) != 0 && Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID, myUnit.ObjectID, TextCompare: false) != 0)
				{
					if (string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID) && UNREP_Destination.UNREP_Capabilities.instanceComparator > 0)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
						Condition = _DockingOpsCondition.Replenishing;
						UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
						UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
						UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID = myUnit.ObjectID;
					}
					else if (string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID) && UNREP_Destination.UNREP_Capabilities.m_ParameterComparator > 0)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
						Condition = _DockingOpsCondition.Replenishing;
						UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
						UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
						UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID = myUnit.ObjectID;
					}
					else if (string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID) && UNREP_Destination.UNREP_Capabilities.m_RuleComparator > 0)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
						Condition = _DockingOpsCondition.Replenishing;
						UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
						UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
						UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID = myUnit.ObjectID;
					}
				}
			}
			else
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
				Condition = _DockingOpsCondition.Replenishing;
				UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
				UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
				UNREP_Destination.Navigator.ClearPlottedCourse();
				UNREP_Destination.Kinematics.DesiredSpeedOverride = 0f;
				UNREP_Destination.DesiredSpeed = 0f;
				UNREP_Destination.SetThrottle(ActiveUnit.Throttle.FullStop);
				UNREP_Destination.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
				myUnit.Navigator.ClearPlottedCourse();
				myUnit.Kinematics.DesiredSpeedOverride = 0f;
				myUnit.DesiredSpeed = 0f;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100151", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool CanParkOnDock(DockFacility.DockingPhysicalSize dockingPhysicalSize_0)
	{
		DockFacility.DockingPhysicalSize dockingPhysicalSize = dockingPhysicalSize_0;
		if ((uint)(dockingPhysicalSize - 3001) > 3u && dockingPhysicalSize != DockFacility.DockingPhysicalSize.DryDockShelter && dockingPhysicalSize != DockFacility.DockingPhysicalSize.ROV_UUV)
		{
			return false;
		}
		return true;
	}

	public bool CanHostThisBoat(ActiveUnit activeUnit_0, ref DockFacility dockFacility_0)
	{
		List<DockFacility> list = new List<DockFacility>();
		try
		{
			bool flag = true;
			int num;
			DockFacility.DockingPhysicalSize dockingPhysicalSize;
			if (activeUnit_0.IsShip)
			{
				num = (int)Math.Round(((Ship)activeUnit_0).Length);
				dockingPhysicalSize = ((Ship)activeUnit_0).DockingPhysicalSize;
			}
			else if (activeUnit_0.IsSubmarine)
			{
				num = (int)Math.Round(((Submarine)activeUnit_0).Length);
				dockingPhysicalSize = ((Submarine)activeUnit_0).DockingPhysicalSize;
			}
			else
			{
				if (!activeUnit_0.IsVehicle)
				{
					throw new NotImplementedException();
				}
				if (!((Vehicle)activeUnit_0).IsOutOfFuel)
				{
					return false;
				}
				num = (int)Math.Round(((Vehicle)activeUnit_0).Length);
				dockingPhysicalSize = ((Vehicle)activeUnit_0).DockingPhysicalSize;
				flag = false;
			}
			DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
			DockFacility[] array = dockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in array)
			{
				if ((flag || dockFacility.Type != DockFacility.DockFacilityType.Davit) && dockFacility.CanHostThisBoat((short)num, dockingPhysicalSize) == DockingOpsAttemptResult.Success && dockFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					if (myUnit.DockFacilities_ReadOnly.Count() == 1)
					{
						dockFacility_0 = dockFacility;
						return true;
					}
					list.Add(dockFacility);
				}
			}
			DockFacility dockFacility2 = null;
			if (list.Count <= 0)
			{
				return false;
			}
			foreach (DockFacility item in list)
			{
				if (item.Size == dockingPhysicalSize && (Information.IsNothing(dockFacility2) || item.TotalCapacity_Free < dockFacility2.TotalCapacity_Free))
				{
					dockFacility2 = item;
				}
			}
			if (Information.IsNothing(dockFacility2))
			{
				IEnumerable<DockFacility> source = list.OrderBy((DockFacility theAF) => theAF.TotalCapacity_Free);
				dockFacility_0 = source.ElementAtOrDefault(0);
				return true;
			}
			dockFacility_0 = dockFacility2;
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100152", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public DockingOpsAttemptResult CanHostThisBoat(short short_0, DockFacility.DockingPhysicalSize dockingPhysicalSize_0)
	{
		try
		{
			DockingOpsAttemptResult result = DockingOpsAttemptResult.Failure_other;
			DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
			DockFacility[] array = dockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in array)
			{
				DockingOpsAttemptResult dockingOpsAttemptResult = dockFacility.CanHostThisBoat(short_0, dockingPhysicalSize_0);
				if (dockingOpsAttemptResult == DockingOpsAttemptResult.Success)
				{
					if (dockFacility.Status == PlatformComponent._ComponentStatus.Operational)
					{
						return DockingOpsAttemptResult.Success;
					}
					result = DockingOpsAttemptResult.Damaged_facility;
				}
				else
				{
					result = dockingOpsAttemptResult;
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100153", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return DockingOpsAttemptResult.Failure_Program;
		}
	}

	public void AddThisBoat(ActiveUnit activeUnit_0)
	{
		try
		{
			if (!Information.IsNothing(activeUnit_0.DockingOps.HostDockFacility))
			{
				activeUnit_0.DockingOps.HostDockFacility = null;
			}
			DockFacility hostDockFacility = InvokeDic(activeUnit_0);
			activeUnit_0.DockingOps.HostDockFacility = hostDockFacility;
			switch (activeUnit_0.DockingOps.Condition)
			{
			case _DockingOpsCondition.Docked:
				if (activeUnit_0.DockingOps.ConditionTimer > 0f)
				{
					activeUnit_0.DockingOps.Condition = _DockingOpsCondition.Readying;
				}
				break;
			case _DockingOpsCondition.Underway:
			case _DockingOpsCondition.RTB:
			case _DockingOpsCondition.ManoeuveringToRefuel:
			case _DockingOpsCondition.Replenishing:
			case _DockingOpsCondition.ProvidingUNREP:
			case _DockingOpsCondition.RechargingBatteries:
			case _DockingOpsCondition.SettlingForCargoTransfer:
			case _DockingOpsCondition.TransferringCargo:
			case _DockingOpsCondition.TransferringMissionCargo:
				if (activeUnit_0.DockingOps.ConditionTimer == 0f)
				{
					activeUnit_0.DockingOps.Condition = _DockingOpsCondition.Docked;
				}
				else
				{
					activeUnit_0.DockingOps.Condition = _DockingOpsCondition.Docking;
				}
				break;
			}
			activeUnit_0.DockingOps.SetAssignedHostUnit(bool_0: false, myUnit);
			activeUnit_0.SetCurrentAltitude(bool_0: false, 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100154", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PickNewAssignedHost_RandomWithinRange(ActiveUnit activeUnit_0 = null)
	{
		try
		{
			if (!myUnit.IsShip && !myUnit.IsSubmarine)
			{
				return;
			}
			TList<ActiveUnit> tList = new TList<ActiveUnit>();
			float num = myUnit.Kinematics.MaxRange(bool_0: true, null, null);
			Parallel.ForEach(myUnit.GetUnitSide().Units.ToList(), delegate(ActiveUnit theUnit)
			{
				if (theUnit != myUnit && Module_Unit.RangeToUnit_Horiz(myUnit, theUnit) <= num && Operators.CompareString(ThisUnitCanHostMe(theUnit), "OK", TextCompare: false) == 0)
				{
					tList.Add(theUnit);
				}
			});
			List<ActiveUnit> list = tList.ToList();
			if (!Information.IsNothing(activeUnit_0) && list.Contains(activeUnit_0))
			{
				list.Remove(activeUnit_0);
			}
			if (list.Count > 0)
			{
				int index = GameGeneral.LockRandom_0.Next(0, list.Count);
				SetAssignedHostUnit(bool_0: false, list[index]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100155", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PickNewAssignedHost_Nearest()
	{
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			ActiveUnit activeUnit_ = null;
			if (CurrentHostUnit != null)
			{
				if (!CurrentHostUnit.IsDestroyed)
				{
					SetAssignedHostUnit(bool_0: false, CurrentHostUnit);
					return;
				}
				SetAssignedHostUnit(bool_0: false, null);
			}
			foreach (ActiveUnit item in myUnit.GetUnitSide().Units.ToList())
			{
				if (Operators.CompareString(ThisUnitCanHostMe(item), "OK", TextCompare: false) == 0)
				{
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			double num = 99999999999.0;
			foreach (ActiveUnit item2 in list)
			{
				double num2 = Math2.VerifyClass(item2.GetLatitude(), item2.GetLongitude(), myUnit.GetLatitude(), myUnit.GetLongitude());
				if (num2 < num)
				{
					num = num2;
					activeUnit_ = item2;
				}
			}
			SetAssignedHostUnit(bool_0: false, activeUnit_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100156", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public string ThisUnitCanHostMe(ActiveUnit activeUnit_0)
	{
		try
		{
			if (activeUnit_0 == null)
			{
				return "不可能（错误！）";
			}
			int num;
			DockFacility.DockingPhysicalSize dockingPhysicalSize;
			if (myUnit.IsShip)
			{
				num = (int)Math.Round(((Ship)myUnit).Length);
				dockingPhysicalSize = ((Ship)myUnit).DockingPhysicalSize;
			}
			else if (myUnit.IsSubmarine)
			{
				num = (int)Math.Round(((Submarine)myUnit).Length);
				dockingPhysicalSize = ((Submarine)myUnit).DockingPhysicalSize;
			}
			else
			{
				if (!myUnit.IsVehicle || !((Vehicle)myUnit).IsOutOfFuel)
				{
					return "Not possible (wrong type of unit)";
				}
				num = (int)Math.Round(((Vehicle)myUnit).Length);
				dockingPhysicalSize = ((Vehicle)myUnit).DockingPhysicalSize;
			}
			DockingOpsAttemptResult dockingOpsAttemptResult = activeUnit_0.DockingOps.CanHostThisBoat((short)num, dockingPhysicalSize);
			if (dockingOpsAttemptResult == DockingOpsAttemptResult.Success)
			{
				return "OK";
			}
			return "The boat cannot be hosted on any docking facility here (" + dockingOpsAttemptResult.ToString().Replace("_", " ") + ")";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100157", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "不可能（错误！）";
		}
	}

	private DockFacility InvokeDic(ActiveUnit activeUnit_0)
	{
		List<DockFacility> list = new List<DockFacility>();
		try
		{
			DockFacility dockFacility_ = null;
			bool flag = true;
			int num;
			DockFacility.DockingPhysicalSize dockingPhysicalSize;
			if (activeUnit_0.IsShip)
			{
				num = (int)Math.Round(((Ship)activeUnit_0).Length);
				dockingPhysicalSize = ((Ship)activeUnit_0).DockingPhysicalSize;
			}
			else if (activeUnit_0.IsSubmarine)
			{
				num = (int)Math.Round(((Submarine)activeUnit_0).Length);
				dockingPhysicalSize = ((Submarine)activeUnit_0).DockingPhysicalSize;
			}
			else
			{
				if (!activeUnit_0.IsVehicle)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				}
				flag = false;
				Vehicle vehicle = (Vehicle)activeUnit_0;
				if (!vehicle.IsOutOfFuel)
				{
					return null;
				}
				num = (int)Math.Round(vehicle.Length);
				dockingPhysicalSize = vehicle.DockingPhysicalSize;
			}
			DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
			DockFacility[] array = dockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in array)
			{
				if ((flag || dockFacility.Type != DockFacility.DockFacilityType.Davit) && dockFacility.CanHostThisBoat((short)num, dockingPhysicalSize) == DockingOpsAttemptResult.Success && dockFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					list.Add(dockFacility);
				}
			}
			if (list.Count == 0 && CanHostThisBoat(activeUnit_0, ref dockFacility_) && dockFacility_ != null)
			{
				return dockFacility_;
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list.OrderBy((DockFacility theAF) => theAF.TotalCapacity_Free).ElementAtOrDefault(0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100158", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private void SetupDic(float float_0)
	{
		try
		{
			if (!Information.IsNothing(CurrentHostUnit))
			{
				string name = CurrentHostUnit.Name;
				ActiveUnit currentHostUnit = CurrentHostUnit;
				_ = CurrentHostUnit;
				myUnit.SetLongitude(null, CurrentHostUnit.GetLongitude());
				myUnit.SetLatitude(null, CurrentHostUnit.GetLatitude());
				myUnit.SetCurrentAltitude(bool_0: false, 0f);
				myUnit.CurrentSpeed = (float)(2.0 / 3.0 * (double)myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false));
				myUnit.DesiredSpeed = myUnit.CurrentSpeed;
				myUnit.CurrentHeading = CurrentHostUnit.CurrentHeading;
				HostDockFacility = null;
				Condition = _DockingOpsCondition.Underway;
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				myUnit.AI.EvaluateTargets(float_0, bool_0: true, bool_1: true);
				myUnit.AI.EvaluateThreats();
				myUnit.AI.EvaluateUnitStatus(float_0, bool_0: false, bool_1: false);
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
				{
					myUnit.AddMessage(myUnit.Name + "离开" + name + "正在等待命令。", "停靠操作", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else if (myUnit.IsGroupLead() && Information.IsNothing(myUnit.AssignedMissionOrPackage()))
				{
					myUnit.AddMessage(myUnit.Name + "离开" + name + "正在等待命令。", "停靠操作", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + "离开" + name + ".", "停靠操作", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				if (!Information.IsNothing(currentHostUnit) && HasPiers(currentHostUnit))
				{
					bool? nullable_ = null;
					double double_ = currentHostUnit.GetLongitude(nullable_);
					bool? nullable_2 = null;
					double double_2 = currentHostUnit.GetLatitude(nullable_2);
					double double_3 = (double)PierLaneLength * 0.95;
					float float_ = currentHostUnit.CurrentHeading;
					double double_4 = 0.0;
					double double_5 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_4, ref double_5, ref double_3, ref float_);
					currentHostUnit.CurrentHeading = float_;
					currentHostUnit.SetLatitude(nullable_2, double_2);
					currentHostUnit.SetLongitude(nullable_, double_);
					myUnit.Navigator.AddWaypoint(0, new Waypoint(double_4, double_5, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
				myUnit.Sensory.Boolean_0 = true;
				myUnit.Sensory.vmethod_0(myUnit.Sensors_Cached);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100159", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AttemptToStartDocking(ActiveUnit activeUnit_0, bool bool_0 = false)
	{
		DockFacility dockFacility;
		if (bool_0 && !Information.IsNothing(CurrentHostUnit))
		{
			dockFacility = HostDockFacility;
		}
		else
		{
			dockFacility = activeUnit_0.DockingOps.InvokeDic(myUnit);
			if (Information.IsNothing(dockFacility))
			{
				return;
			}
		}
		try
		{
			HostDockFacility = dockFacility;
			if (bool_0)
			{
				Condition = _DockingOpsCondition.Docked;
				ConditionTimer = 0f;
			}
			else
			{
				Condition = _DockingOpsCondition.Docking;
			}
			Mission mission = myUnit.AssignedMissionOrPackage();
			if (!Information.IsNothing(mission))
			{
				if (mission.MissionClass == Mission._MissionClass.Ferry)
				{
					switch (((FerryMission)mission).Behavior)
					{
					case FerryMission.FerryMissionBehavior.OneWay:
					{
						ActiveUnit activeUnit = myUnit;
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
						activeUnit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
						SetAssignedHostUnit(bool_0: false, CurrentHostUnit);
						break;
					}
					case FerryMission.FerryMissionBehavior.Cycle:
						myUnit.AI.ChangeCycleLeg();
						break;
					case FerryMission.FerryMissionBehavior.Random:
						PickNewAssignedHost_RandomWithinRange(GetAssignedHostUnit());
						break;
					}
				}
				if (mission.MissionClass == Mission._MissionClass.Support && ((SupportMission)mission).OneTimeOnly)
				{
					ActiveUnit activeUnit2 = myUnit;
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
					activeUnit2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
				}
			}
			if (myUnit.IsGroupMember() && myUnit.GetParentGroup() != CurrentHostUnit.GetParentGroup())
			{
				myUnit.DetachUnit(bool_0: false, bool_1: true, bool_2: false);
			}
			myUnit.GoInoperative();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100160", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ExcludeDic()
	{
		Condition = _DockingOpsCondition.Docked;
		EnableDic(myUnit.AssignedMissionOrPackage());
		List<Cargo> list = myUnit.OnboardCargo.ToList();
		int val = 0;
		ActiveUnit activeUnit_ = CurrentHostUnit;
		ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
		if (list.Count > 0)
		{
			bool bool_ = false;
			val = TimeToUnloadCargo(myUnit, list);
			if (currentHostUnitCargoSource.IsGroup)
			{
				ActiveUnit activeUnit = null;
				bool flag = false;
				if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
				{
					CargoMission obj = (CargoMission)myUnit.AssignedMissionOrPackage();
					activeUnit = obj.DestinationUnit;
					bool_ = obj.UnpackAllContainers;
				}
				foreach (ActiveUnit value in ((Group)currentHostUnitCargoSource).Units.Values)
				{
					if (value != activeUnit)
					{
						if (value.OnboardCargo.Count() > 0 && !flag)
						{
							activeUnit_ = value;
							flag = true;
						}
						continue;
					}
					activeUnit_ = value;
					break;
				}
			}
			PerformCargoTransferBetweenHostAndTarget(myUnit, activeUnit_, myUnit.OnboardCargo.ToList(), bool_);
		}
		Condition = _DockingOpsCondition.Readying;
		ConditionTimer = Math.Max(1800, val);
		CommenceRepairs();
	}

	public void BeginReadying()
	{
		Condition = _DockingOpsCondition.Readying;
		ConditionTimer = 1800f;
		CommenceRepairs();
	}

	public void CommenceRepairs()
	{
		try
		{
			foreach (Sensor mineCountermeasure in myUnit.MineCountermeasures)
			{
				if (mineCountermeasure.IsExplosiveMineNeutralizer)
				{
					mineCountermeasure.MakeOperational(bool_0: true);
					myUnit.WeaponState = ActiveUnit._ActiveUnitWeaponState.None;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100161", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public List<ActiveUnit> GetPotentialUNREPunits(bool bool_0, List<Mission> list_0, ref string string_0, ResupplyRequest resupplyRequest_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			byte? b = (byte?)myUnit.Doctrine.GetUseReplenishment(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				string_0 = "单元" + myUnit.Name + "有一个不允许补给的条令设置。因此，该单元将不会加油。更改条令设置，然后重试。";
				return list;
			}
			int num = 0;
			string_0 = "没有补给单元。";
			foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
			{
				if (activeUnits_ == null || activeUnits_ == myUnit || (activeUnits_.GetUnitSide() != myUnit.GetUnitSide() && !Module_Side.IsAlliedWithThisSide(activeUnits_.GetUnitSide(), myUnit.GetUnitSide())) || !activeUnits_.IsOperating() || (activeUnits_.GetParentGroup() != null && activeUnits_.GetParentGroup().ReservedSupply && (myUnit.GetParentGroup() == null || Operators.CompareString(myUnit.GetParentGroup().ObjectID, activeUnits_.GetParentGroup().ObjectID, TextCompare: false) != 0)))
				{
					continue;
				}
				ResupplyCapacity designatedSupplier = activeUnits_.DesignatedSupplier;
				if (designatedSupplier == ResupplyCapacity.None)
				{
					continue;
				}
				switch (resupplyRequest_0)
				{
				case ResupplyRequest.Fuel:
					if (designatedSupplier != ResupplyCapacity.Fuel && designatedSupplier != ResupplyCapacity.FuelAndMaterial)
					{
						continue;
					}
					break;
				case ResupplyRequest.Material:
					if (designatedSupplier != ResupplyCapacity.Material && designatedSupplier != ResupplyCapacity.FuelAndMaterial)
					{
						continue;
					}
					break;
				case ResupplyRequest.FuelAndMaterial:
					if (designatedSupplier != ResupplyCapacity.FuelAndMaterial && (designatedSupplier != ResupplyCapacity.Fuel || designatedSupplier != ResupplyCapacity.Material))
					{
						continue;
					}
					break;
				case ResupplyRequest.FuelOrMaterial:
					if (designatedSupplier != ResupplyCapacity.FuelAndMaterial && designatedSupplier != ResupplyCapacity.Fuel && designatedSupplier != ResupplyCapacity.Material)
					{
						continue;
					}
					break;
				}
				if (activeUnits_.IsRTB)
				{
					if (num < 1)
					{
						num = 1;
						string_0 = "加油机在返回基地。";
					}
				}
				else if (activeUnits_.GetCanPhysicallyReplenishThisUnit(myUnit))
				{
					if (list_0 != null)
					{
						if (activeUnits_.AssignedMissionOrPackage() == null)
						{
							if (num < 3)
							{
								num = 3;
								string_0 = "任务" + list_0[0].Name + "没有可用的加油机。";
							}
							continue;
						}
						bool flag = true;
						foreach (Mission item in list_0)
						{
							if (activeUnits_.AssignedMissionOrPackage() == item)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							if (num < 4)
							{
								num = 4;
								string_0 = "任务" + activeUnits_.AssignedMissionOrPackage().Name + "没有可用的加油机。";
							}
							continue;
						}
					}
					if (myUnit.IsBoat)
					{
						if (Module_Unit.RangeToUnit_Horiz(myUnit, activeUnits_) < 10f)
						{
							bool_0 = false;
						}
						if (bool_0)
						{
							ActiveUnit_AI aI = myUnit.AI;
							float currentHeading = myUnit.CurrentHeading;
							float? nullable_ = 0.15f;
							bool bool_ = false;
							if (!aI.CanInterceptTarget(activeUnits_, null, 0f, null, currentHeading, ActiveUnit.Throttle.Full, nullable_, bool_0: true, bool_1: false, ref bool_))
							{
								if (num < 5)
								{
									num = 5;
									string_0 = "Unit" + myUnit.Name + " 无法到达补给提供者。可能原因是补给队列已满。";
								}
								continue;
							}
						}
					}
					list.Add(activeUnits_);
				}
				else if (num < 2)
				{
					num = 2;
					string_0 = "单元" + activeUnits_.Name + "是一个补给单元，但不能补给" + myUnit.Name + ".";
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100163", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal (ResultOfAttemptToScheduleUNREP Result, string DetailedFeedback) IncludeDic(GeoPoint geoPoint_0, ActiveUnit activeUnit_0, List<Mission> list_0, bool bool_0, int? nullable_0 = null, ResupplyRequest resupplyRequest_0 = ResupplyRequest.FuelOrMaterial, Dictionary<int, Weapon> dictionary_0 = null)
	{
		try
		{
			string string_ = "";
			if (activeUnit_0 == null)
			{
				List<ActiveUnit> list = GetPotentialUNREPunits(bool_0: true, list_0, ref string_, resupplyRequest_0);
				if (list.Count == 0)
				{
					if (Operators.CompareString(string_, string.Empty, TextCompare: false) == 0)
					{
						string text = myUnit.Name + " 没有合适的补给单元。";
						if (bool_0)
						{
							myUnit.AddMessage(text, "未找到合适的补给提供者", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
						string_ = text;
					}
					return (Result: ResultOfAttemptToScheduleUNREP.Fail_Other, DetailedFeedback: string_);
				}
				if (nullable_0.HasValue)
				{
					list = list.Where((ActiveUnit theT) => Module_Unit.RangeToUnit_Horiz(myUnit, theT) <= (float)nullable_0.Value).ToList();
					if (list.Count == 0)
					{
						string text2 = myUnit.Name + "没有合适的补给目的地距离在" + (nullable_0.HasValue ? Conversions.ToString(nullable_0.GetValueOrDefault()) : null) + "海里 - 中止补给尝试。";
						if (bool_0)
						{
							myUnit.AddMessage(text2, "未找到合适的补给提供者", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
						return (Result: ResultOfAttemptToScheduleUNREP.Fail_NoCandidatesWithinSpecifiedDistance, DetailedFeedback: text2);
					}
				}
				if (list.Contains(myUnit.DockingOps.GetAssignedHostUnit()) && SearchDic(myUnit.DockingOps.GetAssignedHostUnit(), resupplyRequest_0) == ResultOfAttemptToRendezvousWithTanker.Success)
				{
					return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
				}
				if (geoPoint_0 == null)
				{
					ActiveUnit Local_myHost = ActualDestinationHost;
					if (Local_myHost == null)
					{
						foreach (ActiveUnit item in list.OrderBy((ActiveUnit theT) => Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit)))
						{
							if (SearchDic(item, resupplyRequest_0, dictionary_0) == ResultOfAttemptToRendezvousWithTanker.Success)
							{
								return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
							}
						}
					}
					else
					{
						double Local_RangeToBase_Angular = Module_Unit.RangeToUnit_Horiz_Angular(myUnit, Local_myHost);
						IEnumerable<ActiveUnit> enumerable = from theT in list
							where Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theT) < Local_RangeToBase_Angular && Module_Unit.RangeToUnit_Horiz_Angular(theT, Local_myHost) < Local_RangeToBase_Angular
							orderby Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit)
							select theT;
						if (enumerable.Count() <= 0)
						{
							ActiveUnit._ActiveUnitFuelState isBingoTowardsThisDestination = myUnit.GetIsBingoTowardsThisDestination(Local_myHost, null, null);
							if (isBingoTowardsThisDestination == ActiveUnit._ActiveUnitFuelState.IsBingo || isBingoTowardsThisDestination == ActiveUnit._ActiveUnitFuelState.IsJoker)
							{
								foreach (ActiveUnit item2 in list.OrderBy((ActiveUnit theT) => Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit)))
								{
									if (SearchDic(item2, resupplyRequest_0, dictionary_0) == ResultOfAttemptToRendezvousWithTanker.Success)
									{
										return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
									}
								}
							}
						}
						else
						{
							foreach (ActiveUnit item3 in enumerable)
							{
								if (SearchDic(item3, resupplyRequest_0, dictionary_0) == ResultOfAttemptToRendezvousWithTanker.Success)
								{
									return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
								}
							}
						}
					}
				}
				else
				{
					double Local_RangeToTarget_Angular = Module_Unit.RangeToPoint_Horiz_Angular(myUnit, geoPoint_0);
					IEnumerable<ActiveUnit> enumerable2 = from theT in list
						where Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theT) < Local_RangeToTarget_Angular && Module_Unit.RangeToPoint_Horiz_Angular(theT, geoPoint_0) < Local_RangeToTarget_Angular
						orderby Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit)
						select theT;
					if (enumerable2.Count() <= 0)
					{
						foreach (ActiveUnit item4 in list.OrderBy((ActiveUnit theT) => Module_Unit.RangeToPoint_Horiz_Angular(theT, geoPoint_0)))
						{
							if (SearchDic(item4, resupplyRequest_0, dictionary_0) == ResultOfAttemptToRendezvousWithTanker.Success)
							{
								return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
							}
						}
					}
					else
					{
						foreach (ActiveUnit item5 in enumerable2)
						{
							if (SearchDic(item5, resupplyRequest_0, dictionary_0) == ResultOfAttemptToRendezvousWithTanker.Success)
							{
								return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
							}
						}
					}
				}
				return (Result: ResultOfAttemptToScheduleUNREP.Fail_Other, DetailedFeedback: "无法调度补给点");
			}
			if (activeUnit_0.IsGroup)
			{
				if (((Group)activeUnit_0).GroupLead == null)
				{
					return (Result: ResultOfAttemptToScheduleUNREP.Fail_Other, DetailedFeedback: "所选编队没有领队");
				}
				activeUnit_0 = ((Group)activeUnit_0).GroupLead;
			}
			ResultOfAttemptToRendezvousWithTanker resultOfAttemptToRendezvousWithTanker = SearchDic(activeUnit_0, resupplyRequest_0, dictionary_0);
			if (resultOfAttemptToRendezvousWithTanker == ResultOfAttemptToRendezvousWithTanker.Success)
			{
				return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
			}
			return (Result: ResultOfAttemptToScheduleUNREP.Fail_Other, DetailedFeedback: Misc.DestroyValue(resultOfAttemptToRendezvousWithTanker));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100164", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			(ResultOfAttemptToScheduleUNREP, string) result = (ResultOfAttemptToScheduleUNREP.Fail_Other, "失败 - 未知错误");
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal ResultOfAttemptToRendezvousWithTanker SearchDic(ActiveUnit activeUnit_0, ResupplyRequest resupplyRequest_0 = ResupplyRequest.FuelOrMaterial, Dictionary<int, Weapon> dictionary_0 = null)
	{
		try
		{
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				return ResultOfAttemptToRendezvousWithTanker.Success;
			}
			if (activeUnit_0.IsBoat && myUnit.IsBoat && !((IBoat)activeUnit_0).IsDedicatedTankerOrUNREP && ((IBoat)activeUnit_0).Displacement_Standard < ((IBoat)myUnit).Displacement_Standard)
			{
				return ResultOfAttemptToRendezvousWithTanker.Fail_ProviderSmallerThanReceiver;
			}
			int num = 0;
			if (activeUnit_0.IsMobileGroundUnit || (activeUnit_0.IsFacility && !activeUnit_0.IsFixedFacility))
			{
				num = 5000;
			}
			bool flag = activeUnit_0.DockingOps.GetFuelWeCanSupplyToThisUnit(myUnit, num) > 0;
			bool flag2 = activeUnit_0.DockingOps.GetMaterialWeCanSupplyToThisUnit(myUnit, dictionary_0) > 0;
			switch (resupplyRequest_0)
			{
			case ResupplyRequest.Fuel:
				if (!flag)
				{
					return ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer;
				}
				break;
			case ResupplyRequest.Material:
				if (!flag2)
				{
					return ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer;
				}
				break;
			case ResupplyRequest.FuelAndMaterial:
				if (!(flag && flag2))
				{
					return ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer;
				}
				break;
			case ResupplyRequest.FuelOrMaterial:
				if (!(flag || flag2))
				{
					return ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer;
				}
				break;
			}
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (myUnit.IsBoat & myUnit.IsOutOfFuel)
				{
					if (Module_Unit.RangeToUnit_Horiz(myUnit, activeUnit_0) <= 10f)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
						Condition = _DockingOpsCondition.ManoeuveringToRefuel;
						UNREP_Destination = activeUnit_0;
						return ResultOfAttemptToRendezvousWithTanker.Success;
					}
					return ResultOfAttemptToRendezvousWithTanker.None;
				}
				ActiveUnit_AI aI = myUnit.AI;
				float currentHeading = myUnit.CurrentHeading;
				float? nullable_ = 0.25f;
				bool bool_ = false;
				if (aI.CanInterceptTarget(activeUnit_0, null, 0f, null, currentHeading, ActiveUnit.Throttle.Cruise, nullable_, bool_0: true, bool_1: false, ref bool_))
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					Condition = _DockingOpsCondition.ManoeuveringToRefuel;
					UNREP_Destination = activeUnit_0;
					return ResultOfAttemptToRendezvousWithTanker.Success;
				}
				return ResultOfAttemptToRendezvousWithTanker.Fail_CannotIntercept;
			}
			myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
			Condition = _DockingOpsCondition.ManoeuveringToRefuel;
			UNREP_Destination = activeUnit_0;
			return ResultOfAttemptToRendezvousWithTanker.Success;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100165", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return ResultOfAttemptToRendezvousWithTanker.Fail_Unknown;
		}
	}

	public static double GetCargoMoveTime(double double_0, double double_1, double double_2, double double_3)
	{
		double num = Math.Log(double_1 / double_0) / double_3;
		return double_0 * Math.Exp(num * double_2);
	}

	public static int TimeToLoadCargo(ActiveUnit activeUnit_0, List<Cargo> list_0)
	{
		return ((ICargoHost)activeUnit_0)?.GetLoadTime(list_0) ?? DEFAULT_CARGO_LOAD_TIME;
	}

	public static int TimeToUnloadCargo(ActiveUnit activeUnit_0, List<Cargo> list_0)
	{
		return ((ICargoHost)activeUnit_0)?.GetUnloadTime(list_0) ?? DEFAULT_CARGO_UNLOAD_TIME;
	}

	public static void PerformCargoTransferBetweenHostAndTarget(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, List<Cargo> list_0, bool bool_0 = false)
	{
		try
		{
			if (list_0.Count == 0)
			{
				return;
			}
			List<CargoContainer> list = new List<CargoContainer>();
			foreach (Cargo item in list_0)
			{
				ActiveUnit activeUnit = (activeUnit_1.IsGroup ? Cargo.GetGroupCargoDestinationUnit((Group)activeUnit_1, activeUnit_0, item) : activeUnit_1);
				if (bool_0 && item.CargoObjectContainer != null && (activeUnit.IsFixedFacility || activeUnit.IsShip))
				{
					ArrayExtensions.Remove(ref activeUnit_0.OnboardCargo, item);
					list.Add(item.CargoObjectContainer);
					Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit_0.ObjectID, new CargoTracker(item, 0, 1)));
					Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
					continue;
				}
				if (Operators.CompareString(item.CargoObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0)
				{
					activeUnit_0.DockingOps.LoadIntoCargo(activeUnit);
					ArrayExtensions.Add(ref activeUnit.OnboardCargo, item);
					Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit_0.ObjectID, new CargoTracker(item, 0, 1)));
					Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
					continue;
				}
				if (activeUnit_0.OnboardCargo.Contains(item))
				{
					ArrayExtensions.Remove(ref activeUnit_0.OnboardCargo, item);
					ArrayExtensions.Add(ref activeUnit.OnboardCargo, item);
					if (item.CargoObjectActiveUnit != null)
					{
						item.CargoObjectActiveUnit.DockingOps.LoadIntoCargo(activeUnit);
					}
					Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit_0.ObjectID, new CargoTracker(item, 0, 1)));
					Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
					continue;
				}
				foreach (Mount mount in activeUnit_0.Mounts)
				{
					if (item.InternalObjectType == Cargo.CargoObjectType.Mount && item.CargoObjectDBID == mount.DBID)
					{
						activeUnit_0.Mounts.Remove(mount);
						ArrayExtensions.Add(ref activeUnit.OnboardCargo, item);
						Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit_0.ObjectID, new CargoTracker(item, 0, 1)));
						Scenario.CargoMovement.Add(new Tuple<string, CargoTracker>(activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
						break;
					}
				}
			}
			if (list.Count > 0)
			{
				Cargo.UnloadCargoContainersToSupplyDump(activeUnit_0, list, activeUnit_1);
			}
			if (Module_ActiveUnit.CancelTokenizer(activeUnit_0) && activeUnit_0.Mounts.Count == 0)
			{
				activeUnit_0.ParentScen.DeleteUnitImmediately(activeUnit_0.ObjectID, bool_0: true, "Picked up as cargo");
				foreach (ActiveUnit activeUnits_ in activeUnit_1.ParentScen.ActiveUnits_List)
				{
					if (activeUnits_ != null && activeUnits_.AI.PrimaryPickupTarget == activeUnit_0)
					{
						activeUnits_.AI.PrimaryPickupTarget = null;
					}
				}
			}
			if (activeUnit_1.IsOperating() && activeUnit_1.IsAircraft && activeUnit_1.ThrottleSetting == ActiveUnit.Throttle.FullStop)
			{
				activeUnit_1.SetThrottle(ActiveUnit.Throttle.Loiter);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101370", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void EnableDic(Mission mission_0)
	{
		try
		{
			foreach (IEventExporter applicableEventExporter in myUnit.ParentScen.ApplicableEventExporters)
			{
				if (applicableEventExporter.IsOperating && applicableEventExporter.ExportDockingOps && !Information.IsNothing(myUnit.GetUnitSide()))
				{
					Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
					if (myUnit.ParentScen.MonteCarloIteration > 0)
					{
						dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string)));
						dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.MonteCarloIteration, typeof(int)));
					}
					dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.TimelineID, typeof(string)));
					if (applicableEventExporter.UseZeroHour)
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.Subtract(myUnit.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
					}
					else
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + myUnit.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
					}
					dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string)));
					dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string)));
					dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string)));
					dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(myUnit.GetUnitSide().Name, typeof(string)));
					dictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.GetLongitude(), typeof(double)));
					dictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.GetLatitude(), typeof(double)));
					dictionary.Add("Action", new IEventExporter.EventNotificationParameter("Docking", typeof(string)));
					dictionary.Add("DepartureHostID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					dictionary.Add("DepartureHostName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					if (!Information.IsNothing(CurrentHostUnit))
					{
						dictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(CurrentHostUnit.ObjectID, typeof(string)));
						dictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(CurrentHostUnit.Name, typeof(string)));
					}
					dictionary.Add("MissionID", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.ObjectID, typeof(string)));
					dictionary.Add("MissionName", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.Name, typeof(string)));
					dictionary.Add("TotalFuel", new IEventExporter.EventNotificationParameter(Conversions.ToString(myUnit.FuelCapacityCurrent), typeof(int)));
					applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.DockingOps, dictionary, myUnit.ParentScen);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[CompilerGenerated]
	private float ChangeDic(GeoPoint geoPoint_0)
	{
		return Math2.VerifyClass(geoPoint_0.Latitude, geoPoint_0.Longitude, myUnit.GetLatitude(), myUnit.GetLongitude());
	}
}
