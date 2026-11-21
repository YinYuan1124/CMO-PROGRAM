using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core.DAL;
using Command_Core.Lua;
using Microsoft.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Common;
using OpenDis.Pages;
using SevenZip;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class GameGeneral
{
	public delegate void CoreToUIMessageEventHandler(string theMessage, string theHeader, Side theSide, MessageBoxMessageType theType);

	public enum MessageBoxMessageType
	{
		Information,
		Warning,
		ErrorMessage
	}

	public class CustomIconWrapper
	{
		public string Filename;

		public int IconSize;

		public bool Rotatable;

		public CustomIconWrapper(string string_0)
		{
			IconSize = -1;
			Filename = string_0;
		}

		public CustomIconWrapper(string string_0, int int_0, bool bool_0)
		{
			if (int_0 == -1)
			{
				IconSize = -1;
			}
			else
			{
				IconSize = Math.Max(Math.Min(int_0, 128), 8);
			}
			Rotatable = bool_0;
			Filename = string_0;
		}
	}

	public enum _ProLicenseTier
	{
		None
	}

	[CompilerGenerated]
	private sealed class SetterCallbackCandidate
	{
		public ActiveUnit Local_theUnit;

		internal void InstantiateInterruptibleField(Weapon theSon, ParallelLoopState loopstate)
		{
			if (theSon.Type == Weapon._WeaponType.Sonobuoy && theSon.Sensors_ReadOnly().Length != 0 && (Local_theUnit.GetUnitSide() == theSon.GetUnitSide() || Module_Side.IsAlliedWithThisSide(Local_theUnit.GetUnitSide(), theSon.GetUnitSide())) && (double)Module_Unit.RangeToUnit_Horiz(Local_theUnit, theSon) < Math.Min(9.5, (double)theSon.Sensors_ReadOnly()[0].maxRange * 1.5))
			{
				((Aircraft)Local_theUnit).ShouldDropSonobuoysOnThisPulse = false;
				loopstate.Stop();
			}
		}
	}

	[CompilerGenerated]
	private sealed class CreatorThreadBridge
	{
		public float Local_elapsedTime;

		public List<ActiveUnit> Local_OffGridUnits;

		internal void CreateInterruptibleField(ActiveUnit theAUnit)
		{
			if (theAUnit != null)
			{
				RunBridge(theAUnit, Local_OffGridUnits, Local_elapsedTime);
			}
		}
	}

	[CompilerGenerated]
	private sealed class ListenerProcessProducer
	{
		public Scenario Local_theScen;

		public float Local_elapsedTime;

		internal void CompareInterruptibleField(Side theSide)
		{
			theSide.PrePulseHousekeeping(Local_theScen);
		}

		internal void ReadInterruptibleField(Side theSide)
		{
			ProcComparator CS_0024_003C_003E8__locals0 = new ProcComparator
			{
				CS_0024_003C_003E8__locals2 = this,
				Local_theSide = theSide
			};
			try
			{
				CS_0024_003C_003E8__locals0.Local_theSide.DiscardExpiredContacts(Local_theScen);
				for (int i = CS_0024_003C_003E8__locals0.Local_theSide.Units.Count - 1; i >= 0; i += -1)
				{
					ActiveUnit activeUnit;
					try
					{
						if (i < CS_0024_003C_003E8__locals0.Local_theSide.Units.Count)
						{
							activeUnit = CS_0024_003C_003E8__locals0.Local_theSide.Units[i];
							if (activeUnit != null)
							{
								goto IL_00c9;
							}
							CS_0024_003C_003E8__locals0.Local_theSide.Units.Remove(activeUnit);
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					continue;
					IL_00c9:
					if (activeUnit.IsDestroyed)
					{
						CS_0024_003C_003E8__locals0.Local_theSide.Units.Remove(activeUnit);
					}
				}
				Parallel.ForEach(new List<Contact>(CS_0024_003C_003E8__locals0.Local_theSide.Contacts.Values), delegate(Contact theC)
				{
					if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.Local_theScen.SecondIsChangingOnThisPulse)
					{
						Contact.IncreaseAge(theC, CS_0024_003C_003E8__locals0.Local_theSide, 1f, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.Local_theScen);
					}
					theC.PrePulseHousekeeping(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.Local_elapsedTime, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.Local_theScen);
					theC.IsPreciselyLocatedOnThisPulse = false;
					theC.ChangedToFirmOnThisPulse = false;
					if (theC.DetectedEmissions == null)
					{
						theC.DetectedEmissions = new ObservableDictionary<int, EmissionContainer>();
					}
					else if (theC.DetectedEmissions.Count > 0)
					{
						IEnumerator<KeyValuePair<int, EmissionContainer>> enumerator2 = theC.DetectedEmissions.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							if (!Information.IsNothing(enumerator2.Current))
							{
								enumerator2.Current.Value.Age += CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.Local_elapsedTime;
							}
						}
					}
				});
				CS_0024_003C_003E8__locals0.Local_theSide.ProcessBaseContacts(ref Local_theScen);
				CS_0024_003C_003E8__locals0.Local_theSide.ProcessAutoDetectableUnits(Local_theScen, Local_elapsedTime);
				CS_0024_003C_003E8__locals0.Local_theSide.GetUnitsEngagedInOECM(bool_0: true);
				if (Local_theScen.SecondIsChangingOnThisPulse)
				{
					List<Weapon> list = Local_theScen.AllWeaponsAlive.Where((Weapon theW) => theW.GetUnitSide() == CS_0024_003C_003E8__locals0.Local_theSide).ToList();
					if (list.Count > 0)
					{
						List<ActiveUnit> friendlyUnits_OperativeOnly = CS_0024_003C_003E8__locals0.Local_theSide.GetFriendlyUnits_OperativeOnly(Local_theScen);
						foreach (Weapon item in list)
						{
							item.CommStuff.CheckCommsAndDataLinks(Local_elapsedTime, friendlyUnits_OperativeOnly);
						}
					}
				}
				CS_0024_003C_003E8__locals0.Local_theSide.Operation.Tick(Local_theScen, Local_elapsedTime);
				if (Local_theScen.MinuteIsChangingOnThisPulse)
				{
					Mission mission_ = null;
					CheckForMissionWakeup(ref Local_theScen, ref CS_0024_003C_003E8__locals0.Local_theSide, ref mission_, bool_1: false, bool_2: true, bool_3: true, 0);
				}
				if (Local_theScen.MinuteIsChangingOnThisPulse)
				{
					ref Scenario local_theScen = ref Local_theScen;
					ref Side local_theSide = ref CS_0024_003C_003E8__locals0.Local_theSide;
					ActiveUnit activeUnit_ = null;
					MissionPlanner.UpdateStrikeMissionWaypoints_AirborneAircraft(Local_elapsedTime, ref local_theScen, ref local_theSide, ref activeUnit_);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101293", "");
				WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	private sealed class CreatorCallbackCandidate
	{
		public TList<ActiveUnit> Local_theBag;

		public ListenerProcessProducer CS_0024_003C_003E8__locals1;

		internal void DisableInterruptibleField(ActiveUnit theAU)
		{
			try
			{
				if (theAU != null)
				{
					if (theAU.IsOperating())
					{
						m_RegistryDic[theAU] = true;
					}
					theAU._CustomerVal = theAU.GetLongitude();
					theAU.m_SerializerVal = theAU.GetLatitude();
					theAU.AI.CalculatedDesiredPitchThisPulse = false;
					ActiveUnit_Sensory sensory = theAU.Sensory;
					ActiveUnit_Weaponry weaponry = theAU.Weaponry;
					theAU.PrePulseHousekeeping(CS_0024_003C_003E8__locals1.Local_elapsedTime, CS_0024_003C_003E8__locals1.Local_theScen);
					sensory.AgeLocalAndPrivateContacts(CS_0024_003C_003E8__locals1.Local_elapsedTime);
					if (CS_0024_003C_003E8__locals1.Local_theScen.SecondIsChangingOnThisPulse && !theAU.IsGroup && m_RegistryDic[theAU])
					{
						Sensor[] sensors_Cached = theAU.Sensors_Cached;
						sensory.UpdateSensorsCountdown_PreDetection(sensors_Cached);
						sensory.method_1(theAU.MineCountermeasures);
						theAU.CommStuff.ClearAllCommLinks();
					}
					if (!theAU.IsWeapon)
					{
						theAU.Doctrine.ClearCachedParentDoctrine();
						Doctrine doctrine = theAU.Doctrine;
						Scenario local_theScen = CS_0024_003C_003E8__locals1.Local_theScen;
						bool bool_ = true;
						doctrine.GetParentDoctrine(local_theScen, ref bool_);
					}
					sensory.Housekeeping_PrePulse(CS_0024_003C_003E8__locals1.Local_elapsedTime);
					weaponry.Housekeeping_PrePulse();
					if (theAU.IsWeapon)
					{
						Weapon obj = (Weapon)theAU;
						obj.clientReader = obj.AboutToImpact_ActualTarget(CS_0024_003C_003E8__locals1.Local_elapsedTime);
						obj.dicReader = obj.AboutToImpact_Contact(CS_0024_003C_003E8__locals1.Local_elapsedTime);
					}
					if (theAU.IsFacility && ActiveUnit_DockingOps.HasPiers(theAU))
					{
						Local_theBag.Add(theAU);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101293A", "");
				WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	private sealed class ProcComparator
	{
		public Side Local_theSide;

		public ListenerProcessProducer CS_0024_003C_003E8__locals2;

		internal void UpdateInterruptibleField(Contact theC)
		{
			if (CS_0024_003C_003E8__locals2.Local_theScen.SecondIsChangingOnThisPulse)
			{
				Contact.IncreaseAge(theC, Local_theSide, 1f, CS_0024_003C_003E8__locals2.Local_theScen);
			}
			theC.PrePulseHousekeeping(CS_0024_003C_003E8__locals2.Local_elapsedTime, CS_0024_003C_003E8__locals2.Local_theScen);
			theC.IsPreciselyLocatedOnThisPulse = false;
			theC.ChangedToFirmOnThisPulse = false;
			if (theC.DetectedEmissions == null)
			{
				theC.DetectedEmissions = new ObservableDictionary<int, EmissionContainer>();
			}
			else
			{
				if (theC.DetectedEmissions.Count <= 0)
				{
					return;
				}
				IEnumerator<KeyValuePair<int, EmissionContainer>> enumerator = theC.DetectedEmissions.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (!Information.IsNothing(enumerator.Current))
					{
						enumerator.Current.Value.Age += CS_0024_003C_003E8__locals2.Local_elapsedTime;
					}
				}
			}
		}

		internal bool InsertInterruptibleField(Weapon theW)
		{
			return theW.GetUnitSide() == Local_theSide;
		}
	}

	[CompilerGenerated]
	private sealed class StructItem
	{
		public Scenario Local_theScen;

		public float Local_elapsedTime;

		internal void PrepareInterruptibleField(ActiveUnit theAU)
		{
			if (theAU == null)
			{
				return;
			}
			ActiveUnit_Sensory sensory = theAU.Sensory;
			theAU.Housekeeping_PostPulse();
			sensory.Housekeeping_PostPulse(Local_elapsedTime);
			if (theAU.IsGroup)
			{
				return;
			}
			if (Local_theScen.SecondIsChangingOnThisPulse)
			{
				sensory.UpdateSensorsCountdown_PostDetection(theAU.Sensors_Cached);
				if (theAU.IsSubmarine)
				{
					theAU.TimeSinceLastThreatDetection_ESM += 1f;
				}
			}
			theAU.Sensors_Cached = null;
			theAU.MineCountermeasures = null;
		}
	}

	[CompilerGenerated]
	private sealed class FactoryCollectionRecord
	{
		public List<ActiveUnit>[] Local_WorkerThreadUnitLists;

		public StructItem CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class ClientParameterMessage
	{
		public Side Local_theSide;

		public TList<Contact> Local_KillBag;

		public FactoryCollectionRecord CS_0024_003C_003E8__locals2;

		internal void ReflectInterruptibleField(Contact theC)
		{
			if (theC.ActualUnit == null)
			{
				Local_KillBag.Add(theC);
			}
			else if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_theScen.ActiveUnits.ContainsKey(theC.ActualUnit.ObjectID))
			{
				if (theC.ActualUnit.IsOperating())
				{
					if (Local_theSide.Units.Count > 0 && theC.ActualUnit.GetIsAutoDetectable(Local_theSide))
					{
						List<ActiveUnit> units = Local_theSide.Units;
						ActiveUnit activeUnit_ = units[0];
						ActiveUnit_Sensory.UpdateContactData(ref activeUnit_, ref theC, theC.ActualUnit, bool_0: false);
						units[0] = activeUnit_;
					}
					if (theC.Age == 0f)
					{
						theC.HeldFor += CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_elapsedTime;
					}
				}
				else
				{
					Local_KillBag.Add(theC);
				}
			}
			else
			{
				Local_KillBag.Add(theC);
			}
		}
	}

	[CompilerGenerated]
	private sealed class DicParameterMessage
	{
		public int Local_theIndex;

		public FactoryCollectionRecord CS_0024_003C_003E8__locals3;

		internal void VisitInterruptibleField()
		{
			foreach (ActiveUnit item in CS_0024_003C_003E8__locals3.Local_WorkerThreadUnitLists[Local_theIndex])
			{
				ActiveUnit activeUnit_ = item;
				if (activeUnit_ == null)
				{
					break;
				}
				ActiveUnit_Sensory sensory = activeUnit_.Sensory;
				_ = activeUnit_.Weaponry;
				activeUnit_.Housekeeping_PostPulse();
				sensory.Housekeeping_PostPulse(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.Local_elapsedTime);
				if (!activeUnit_.IsGroup)
				{
					if (CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.Local_theScen.SecondIsChangingOnThisPulse)
					{
						sensory.UpdateSensorsCountdown_PostDetection(activeUnit_.Sensors_Cached);
						if (activeUnit_.IsSubmarine)
						{
							activeUnit_.TimeSinceLastThreatDetection_ESM += 1f;
						}
					}
					activeUnit_.Sensors_Cached = null;
					activeUnit_.MineCountermeasures = null;
				}
				if (activeUnit_.IsWeapon)
				{
					Contact contact_ = activeUnit_.AI.PrimaryTarget;
					if (contact_ != null && contact_.ActualUnit != null && contact_.RemainingContinousTrackTime > 0f)
					{
						contact_.Age = 0f;
						ActiveUnit_Sensory.UpdateContactData(ref activeUnit_, ref contact_, contact_.ActualUnit, bool_0: false);
					}
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class ConfigProcessProducer
	{
		public TList<Contact> Local_RemList;

		public Dictionary<string, HashSet<string>> Local_FriendlySidesPerSide;

		public Scenario Local_theScen;

		internal void RestartInterruptibleField(Side theSide)
		{
			UtilsRegistryFilter CS_0024_003C_003E8__locals0 = new UtilsRegistryFilter
			{
				CS_0024_003C_003E8__locals1 = this,
				Local_theSide = theSide
			};
			Parallel.ForEach(new List<Contact>(CS_0024_003C_003E8__locals0.Local_theSide.Contacts_List), delegate(Contact theC)
			{
				if (theC.ActualUnit != null && theC.ActualUnit.ParentScen.Sides_ReadOnly.Contains(theC.ActualUnit.GetUnitSide()))
				{
					if (theC.SideIsKnown)
					{
						if (Module_Side.IsAlliedWithThisSide(CS_0024_003C_003E8__locals0.Local_theSide, theC.ActualUnit.GetUnitSide()))
						{
							if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList == null)
							{
								CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList = new TList<Contact>();
							}
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList.Add(theC);
						}
						else if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_FriendlySidesPerSide[theC.ActualUnit.GetUnitSide().ObjectID].Contains(CS_0024_003C_003E8__locals0.Local_theSide.ObjectID))
						{
							if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList == null)
							{
								CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList = new TList<Contact>();
							}
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList.Add(theC);
						}
					}
					else if (Module_Side.IsAlliedWithThisSide(CS_0024_003C_003E8__locals0.Local_theSide, theC.ActualUnit.GetUnitSide()) && !theC.ActualUnit.IsSubmarine)
					{
						if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList == null)
						{
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList = new TList<Contact>();
						}
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_RemList.Add(theC);
					}
				}
			});
			IEnumerator enumerator = null;
			if (Local_RemList == null)
			{
				return;
			}
			try
			{
				enumerator = Local_RemList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Contact contact_ = (Contact)enumerator.Current;
					CS_0024_003C_003E8__locals0.Local_theSide.DropContact(contact_, ref Local_theScen, bool_0: false);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class UtilsRegistryFilter
	{
		public Side Local_theSide;

		public ConfigProcessProducer CS_0024_003C_003E8__locals1;

		internal void TestInterruptibleField(Contact theC)
		{
			if (theC.ActualUnit == null || !theC.ActualUnit.ParentScen.Sides_ReadOnly.Contains(theC.ActualUnit.GetUnitSide()))
			{
				return;
			}
			if (theC.SideIsKnown)
			{
				if (Module_Side.IsAlliedWithThisSide(Local_theSide, theC.ActualUnit.GetUnitSide()))
				{
					if (CS_0024_003C_003E8__locals1.Local_RemList == null)
					{
						CS_0024_003C_003E8__locals1.Local_RemList = new TList<Contact>();
					}
					CS_0024_003C_003E8__locals1.Local_RemList.Add(theC);
				}
				else if (CS_0024_003C_003E8__locals1.Local_FriendlySidesPerSide[theC.ActualUnit.GetUnitSide().ObjectID].Contains(Local_theSide.ObjectID))
				{
					if (CS_0024_003C_003E8__locals1.Local_RemList == null)
					{
						CS_0024_003C_003E8__locals1.Local_RemList = new TList<Contact>();
					}
					CS_0024_003C_003E8__locals1.Local_RemList.Add(theC);
				}
			}
			else if (Module_Side.IsAlliedWithThisSide(Local_theSide, theC.ActualUnit.GetUnitSide()) && !theC.ActualUnit.IsSubmarine)
			{
				if (CS_0024_003C_003E8__locals1.Local_RemList == null)
				{
					CS_0024_003C_003E8__locals1.Local_RemList = new TList<Contact>();
				}
				CS_0024_003C_003E8__locals1.Local_RemList.Add(theC);
			}
		}
	}

	[CompilerGenerated]
	private sealed class MapCallbackCandidate
	{
		public int Local_theDBID;

		internal bool StopInterruptibleField(Aircraft theAC)
		{
			return theAC.DBID == Local_theDBID;
		}
	}

	[CompilerGenerated]
	private sealed class MerchantItem
	{
		public int Local_theLoadoutDBID;

		public MapCallbackCandidate CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class RepositoryListenerMapping
	{
		public ActiveUnit Local_theHost;

		public MerchantItem CS_0024_003C_003E8__locals2;

		internal bool CancelInterruptibleField(Aircraft theAC)
		{
			if (theAC.DBID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_theDBID && !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == CS_0024_003C_003E8__locals2.Local_theLoadoutDBID && !Information.IsNothing(theAC.AirOps.CurrentHostUnit))
			{
				return theAC.AirOps.CurrentHostUnit == Local_theHost;
			}
			return false;
		}

		internal bool VerifyInterruptibleField(Aircraft theAC)
		{
			if (theAC.DBID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_theDBID && !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == CS_0024_003C_003E8__locals2.Local_theLoadoutDBID && !Information.IsNothing(theAC.AirOps.CurrentHostUnit))
			{
				return theAC.AirOps.CurrentHostUnit == Local_theHost;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RegistryProcessProducer
	{
		public ActiveUnit Local_theAircraftHost;
	}

	[CompilerGenerated]
	private sealed class TemplateCallbackCandidate
	{
		public int Local_theLoadoutDBID;

		public RegistryProcessProducer CS_0024_003C_003E8__locals1;

		internal bool ListInterruptibleField(Aircraft theAC)
		{
			if (!Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID && !Information.IsNothing(theAC.AirOps.CurrentHostUnit))
			{
				return theAC.AirOps.CurrentHostUnit == CS_0024_003C_003E8__locals1.Local_theAircraftHost;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class DefinitionProcessProducer
	{
		public ActiveUnit Local_theAircraftHost0;
	}

	[CompilerGenerated]
	private sealed class CallbackItem
	{
		public int Local_theLoadoutDBID0;

		public DefinitionProcessProducer CS_0024_003C_003E8__locals2;

		internal bool ResolveInterruptibleField(Aircraft theAC)
		{
			if (!Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID0 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit))
			{
				return theAC.AirOps.CurrentHostUnit == CS_0024_003C_003E8__locals2.Local_theAircraftHost0;
			}
			return false;
		}

		internal bool PostInterruptibleField(Aircraft theAC)
		{
			if (!Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID0 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == CS_0024_003C_003E8__locals2.Local_theAircraftHost0)
			{
				return !theAC.Loadout.IsSupportOrPatrol;
			}
			return false;
		}

		internal bool RunInterruptibleField(Aircraft theAC)
		{
			if (!Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID0 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == CS_0024_003C_003E8__locals2.Local_theAircraftHost0)
			{
				return theAC.Loadout.IsSupportOrPatrol;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ConfigMerchantPage
	{
		public ActiveUnit Local_theAircraftHost00;
	}

	[CompilerGenerated]
	private sealed class WorkerProcessResolver
	{
		public int Local_theLoadoutDBID00;

		public ConfigMerchantPage CS_0024_003C_003E8__locals3;

		internal bool StartInterruptibleField(Aircraft theAC)
		{
			if (!Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID00 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit))
			{
				return theAC.AirOps.CurrentHostUnit == CS_0024_003C_003E8__locals3.Local_theAircraftHost00;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class CustomerObjectListener
	{
		public Mission Local_theMission;

		public ActiveUnit Local_theMissionUnit;
	}

	[CompilerGenerated]
	private sealed class DecoratorItem
	{
		public int Local_theDBID;

		internal bool AssetInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID;
		}

		internal bool PrintInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID;
		}
	}

	[CompilerGenerated]
	private sealed class ValProcessProducer
	{
		public int Local_theDBID0;

		internal bool DefineInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID0;
		}
	}

	[CompilerGenerated]
	private sealed class ProcessItem
	{
		public int Local_theDBID00;

		internal bool PublishInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID00;
		}

		internal bool AwakeInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID00;
		}
	}

	[CompilerGenerated]
	private sealed class AnnotationMerchantService
	{
		public int Local_theDBID000;

		internal bool QueryInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID000;
		}

		internal bool ResetInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID000;
		}
	}

	[CompilerGenerated]
	private sealed class IteratorMerchantService
	{
		public Doctrine._UseShootTourists? Local_Doctrine_ShootTourists;

		public CustomerObjectListener CS_0024_003C_003E8__locals1;

		internal bool MapInterruptibleField(Contact theC)
		{
			ActiveUnit_AI aI = CS_0024_003C_003E8__locals1.Local_theMissionUnit.AI;
			Mission local_theMission = CS_0024_003C_003E8__locals1.Local_theMission;
			string string_ = "";
			int int_ = 0;
			return aI.ContactIsRelevantToMission(theC, local_theMission, Local_Doctrine_ShootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_);
		}
	}

	[CompilerGenerated]
	private sealed class MapThreadBridge
	{
		public Doctrine._UseShootTourists? Local_Doctrine_ShootTourists0;

		public CustomerObjectListener CS_0024_003C_003E8__locals2;

		internal bool SortInterruptibleField(Contact theC)
		{
			ActiveUnit_AI aI = CS_0024_003C_003E8__locals2.Local_theMissionUnit.AI;
			Mission local_theMission = CS_0024_003C_003E8__locals2.Local_theMission;
			Doctrine._UseShootTourists? local_Doctrine_ShootTourists = Local_Doctrine_ShootTourists0;
			string string_ = "";
			int int_ = 0;
			return aI.ContactIsRelevantToMission(theC, local_theMission, local_Doctrine_ShootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_);
		}
	}

	[CompilerGenerated]
	private sealed class AttributeCollectionRecord
	{
		public Doctrine._UseShootTourists? Local_Doctrine_ShootTourists00;

		public CustomerObjectListener CS_0024_003C_003E8__locals3;

		internal bool CalcInterruptibleField(Contact theC)
		{
			ActiveUnit_AI aI = CS_0024_003C_003E8__locals3.Local_theMissionUnit.AI;
			Mission local_theMission = CS_0024_003C_003E8__locals3.Local_theMission;
			Doctrine._UseShootTourists? local_Doctrine_ShootTourists = Local_Doctrine_ShootTourists00;
			string string_ = "";
			int int_ = 0;
			return aI.ContactIsRelevantToMission(theC, local_theMission, local_Doctrine_ShootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_);
		}
	}

	[CompilerGenerated]
	private sealed class WatcherDefinitionSpec
	{
		public int Local_theDBID0000;

		internal bool RateInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID0000;
		}

		internal bool FlushInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DBID == Local_theDBID0000;
		}
	}

	[CompilerGenerated]
	private sealed class AccountProcessResolver
	{
		public ActiveUnit Local_theShipSubtHost;

		internal bool ForgotInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DockingOps.CurrentHostUnit == Local_theShipSubtHost;
		}

		internal bool CollectInterruptibleField(ActiveUnit theUnit)
		{
			return theUnit.DockingOps.CurrentHostUnit == Local_theShipSubtHost;
		}
	}

	[CompilerGenerated]
	private sealed class ThreadItem
	{
		public Scenario Local_theScen;

		internal string OrderInterruptibleField(KeyValuePair<string, HashSet<string>> theKVP)
		{
			return CallInvocation(Local_theScen, theKVP);
		}

		internal string RegisterInterruptibleField(KeyValuePair<string, HashSet<string>> theKVP)
		{
			return CallInvocation(Local_theScen, theKVP);
		}

		internal string ManageInterruptibleField(KeyValuePair<int, int> theKVP)
		{
			return LogoutInvocation(Local_theScen, theKVP);
		}

		internal string RevertInterruptibleField(KeyValuePair<int, int> theKVP)
		{
			return LogoutInvocation(Local_theScen, theKVP);
		}
	}

	public const string BuildNumber = "1328.18";

	public static DateTime ReleaseDate;

	public static int BetaSlack_Days;

	public const bool IsBeta = false;

	public const bool AdvancedMissionPlannerEnabled = true;

	public const bool EnableBoostCoastModel = true;

	public static bool TacviewPipeEnabled;

	public static bool bool_0;

	internal static bool infoClient;

	internal static bool helperClient;

	public static bool DedupAlliedMessages;

	public static bool SpeedUp_NEZ_DLZ;

	private static _ProLicenseTier _MapperClient;

	public static bool PE_Lua_EnableSocket;

	public static int PE_Lua_EncodingMode;

	public static int PE_Lua_SocketPort;

	public static bool PE_Lua_AllowIO;

	public static bool PE_Lua_AllowCLRPackage;

	public static bool PE_CompleteSensorFailureReport;

	public static bool PE_SaveAsXML;

	public static bool PE_MPOnly;

	public static bool ReportCompleteSensorDetectionAttempt;

	public static bool Beta_UIGridLines;

	public static bool Beta_ShowAIOODA;

	public static float Global_PulseResolution;

	public static bool UseDynamicResolution;

	public static string TopLevelWritablePath;

	public static Exception CatastrophicCoreException;

	internal static Dictionary<string, HashSet<string>> m_ManagerClient;

	private static string getterClient;

	private static string producerClient;

	private static string _ProcClient;

	internal static string m_StructDic;

	public static Bitmap bitmap_0;

	private static float _MerchantDic;

	internal static int _CallbackDic;

	public static DateTime ScenarioLastGoodClone_DateTime;

	private static MemoryTributary m_DecoratorDic;

	public const int MessageLogSizePerSide = 500;

	public static string InstanceName;

	private static ConcurrentDictionary<int, LockRandom> m_ProcessDic;

	private static RNGCryptoServiceProvider m_ThreadDic;

	private static object m_RuleDic;

	public static object _TakeBackMySalvo_LockObj;

	[ThreadStatic]
	private static StringBuilder _CollectionDic;

	public static int NumberOfInstancesRunning;

	public static Stopwatch Timer_1minute;

	public static Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, Dictionary<int, CustomIconWrapper>>> CustomIconCollection;

	public static Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, CustomIconWrapper>> CustomIconCollection_Parent;

	public static string Debug_LastLoadedScenario;

	public static string Debug_LastLoadedDB;

	private static float _InstanceDic;

	private static float _ObjectDic;

	private static string _ParameterDic;

	private static string m_ExpressionDic;

	private static string _DispatcherDic;

	public static bool EnalbeLoadoutFilter;

	public static bool UseLoadoutFilter;

	private static object m_ListenerDic;

	public static object MainGameLoopLockObj;

	public static int DumbAUsThisPulse;

	public static int SmartAUsThisPulse;

	private static List<ActiveUnit> m_ConfigDic;

	private static Dictionary<ActiveUnit, bool> m_RegistryDic;

	internal static List<Task> _DefinitionDic;

	private static object valDic;

	private static StreamWriter _WrapperDic;

	[ThreadStatic]
	private static StringBuilder _ObserverDic;

	[ThreadStatic]
	private static StringBuilder m_IssuerDic;

	public const int FuseThreshold = 20;

	public const bool FuseUIfeedback = true;

	public static bool UseExceptionFuse;

	public static Dictionary<string, ExceptionEntry> RegisteredExceptions;

	private static object clientDic;

	private static List<LoggedMessage> m_DicDic;

	[CompilerGenerated]
	private static CoreToUIMessageEventHandler _ConsumerDic;

	public static StringBuilder ThreadStaticSB
	{
		get
		{
			if (_CollectionDic == null)
			{
				_CollectionDic = new StringBuilder();
			}
			return _CollectionDic;
		}
	}

	public static float VeryHighIntensityResolution
	{
		get
		{
			return _InstanceDic;
		}
		set
		{
			_InstanceDic = Math.Max(Math.Min(value, 60f), 0f);
		}
	}

	public static float HighIntensityResolution
	{
		get
		{
			return _ObjectDic;
		}
		set
		{
			_ObjectDic = Math.Max(Math.Min(value, 60f), 0f);
		}
	}

	public static string ScenariosRootPath => Path.Combine(TopLevelWritablePath, "Scenarios");

	public static string TempPath => Path.Combine(TopLevelWritablePath, "Temp" + Conversions.ToString(Path.DirectorySeparatorChar) + "Process_" + Conversions.ToString(Process.GetCurrentProcess().Id));

	public static string AttachmentRepoPath => Path.Combine(TopLevelWritablePath, "AttachmentRepo");

	public static string DBFolderPath
	{
		get
		{
			if (string.IsNullOrEmpty(_ParameterDic))
			{
				_ParameterDic = Path.Combine(TopLevelWritablePath, "DB");
			}
			return _ParameterDic;
		}
		set
		{
			_ParameterDic = value;
		}
	}

	public static string NTDSPath => Application.StartupPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Symbols" + Conversions.ToString(Path.DirectorySeparatorChar) + "NTDS" + Conversions.ToString(Path.DirectorySeparatorChar);

	public static string CustomIconPath => Application.StartupPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Symbols" + Conversions.ToString(Path.DirectorySeparatorChar) + "Custom" + Conversions.ToString(Path.DirectorySeparatorChar);

	public static string GISFolderPath
	{
		get
		{
			if (string.IsNullOrEmpty(m_ExpressionDic))
			{
				m_ExpressionDic = Path.Combine(TopLevelWritablePath, "GIS");
			}
			return m_ExpressionDic;
		}
		set
		{
			m_ExpressionDic = value;
		}
	}

	public static string WWFolderPath
	{
		get
		{
			if (string.IsNullOrEmpty(_DispatcherDic))
			{
				_DispatcherDic = Path.Combine(TopLevelWritablePath, "WW");
			}
			return _DispatcherDic;
		}
		set
		{
			_DispatcherDic = value;
		}
	}

	public static string SBRLogFilePath => Path.Combine(LogsPath, "SBR log file.txt");

	public static string LogsPath => Path.Combine(TopLevelWritablePath, "Logs");

	public static string ConfigFolderPath => Path.Combine(TopLevelWritablePath, "Config");

	public static string ResourcesFolderPath => Path.Combine(TopLevelWritablePath, "Resources");

	public static string ProgramTitle => "Command v1.06 - Build 1328.18";

	public static _ProLicenseTier LicenseTierContext
	{
		get
		{
			return _MapperClient;
		}
		set
		{
			_MapperClient = value;
		}
	}

	public static LockRandom LockRandom_0
	{
		get
		{
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			if (!m_ProcessDic.ContainsKey(managedThreadId))
			{
				object ruleDic = m_RuleDic;
				ObjectFlowControl.CheckForSyncLockOnValueType(ruleDic);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(ruleDic, ref lockTaken);
					if (!m_ProcessDic.ContainsKey(managedThreadId))
					{
						byte[] array = new byte[5];
						m_ThreadDic.GetBytes(array);
						LockRandom value = new LockRandom(BitConverter.ToInt32(array, 0));
						m_ProcessDic[managedThreadId] = value;
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(ruleDic);
					}
				}
			}
			return m_ProcessDic[managedThreadId];
		}
	}

	public static MemoryTributary ScenarioLastGoodClone
	{
		get
		{
			return m_DecoratorDic;
		}
		set
		{
			if (m_DecoratorDic != null)
			{
				try
				{
					m_DecoratorDic.Close();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				try
				{
					m_DecoratorDic.Dispose();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				m_DecoratorDic = null;
			}
			m_DecoratorDic = value;
		}
	}

	public static event CoreToUIMessageEventHandler CoreToUIMessage
	{
		[CompilerGenerated]
		add
		{
			CoreToUIMessageEventHandler coreToUIMessageEventHandler = _ConsumerDic;
			CoreToUIMessageEventHandler coreToUIMessageEventHandler2;
			do
			{
				coreToUIMessageEventHandler2 = coreToUIMessageEventHandler;
				CoreToUIMessageEventHandler value2 = (CoreToUIMessageEventHandler)Delegate.Combine(coreToUIMessageEventHandler2, value);
				coreToUIMessageEventHandler = Interlocked.CompareExchange(ref _ConsumerDic, value2, coreToUIMessageEventHandler2);
			}
			while ((object)coreToUIMessageEventHandler != coreToUIMessageEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CoreToUIMessageEventHandler coreToUIMessageEventHandler = _ConsumerDic;
			CoreToUIMessageEventHandler coreToUIMessageEventHandler2;
			do
			{
				coreToUIMessageEventHandler2 = coreToUIMessageEventHandler;
				CoreToUIMessageEventHandler value2 = (CoreToUIMessageEventHandler)Delegate.Remove(coreToUIMessageEventHandler2, value);
				coreToUIMessageEventHandler = Interlocked.CompareExchange(ref _ConsumerDic, value2, coreToUIMessageEventHandler2);
			}
			while ((object)coreToUIMessageEventHandler != coreToUIMessageEventHandler2);
		}
	}

	static GameGeneral()
	{
		ReleaseDate = new DateTime(2024, 3, 28);
		BetaSlack_Days = 30;
		TacviewPipeEnabled = true;
		bool_0 = false;
		infoClient = true;
		helperClient = true;
		DedupAlliedMessages = true;
		SpeedUp_NEZ_DLZ = false;
		_MapperClient = _ProLicenseTier.None;
		PE_Lua_EnableSocket = false;
		PE_Lua_EncodingMode = 0;
		PE_Lua_SocketPort = 7777;
		PE_Lua_AllowIO = false;
		PE_Lua_AllowCLRPackage = false;
		PE_CompleteSensorFailureReport = false;
		PE_SaveAsXML = false;
		PE_MPOnly = false;
		ReportCompleteSensorDetectionAttempt = false;
		Beta_UIGridLines = false;
		Beta_ShowAIOODA = false;
		UseDynamicResolution = true;
		TopLevelWritablePath = MerchantMerchantPage.LogoutList.Info.DirectoryPath;
		getterClient = "sellAr";
		producerClient = "ebUnag";
		_ProcClient = "oolaB";
		m_StructDic = getterClient + producerClient + _ProcClient;
		_MerchantDic = 0f;
		_CallbackDic = Environment.ProcessorCount;
		InstanceName = string.Empty;
		m_ProcessDic = new ConcurrentDictionary<int, LockRandom>();
		m_ThreadDic = new RNGCryptoServiceProvider();
		m_RuleDic = RuntimeHelpers.GetObjectValue(new object());
		_TakeBackMySalvo_LockObj = RuntimeHelpers.GetObjectValue(new object());
		NumberOfInstancesRunning = 0;
		CustomIconCollection = new Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, Dictionary<int, CustomIconWrapper>>>();
		CustomIconCollection_Parent = new Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, CustomIconWrapper>>();
		Debug_LastLoadedScenario = "N/A";
		Debug_LastLoadedDB = "N/A";
		_InstanceDic = 0f;
		_ObjectDic = 0f;
		EnalbeLoadoutFilter = false;
		UseLoadoutFilter = false;
		m_ListenerDic = RuntimeHelpers.GetObjectValue(new object());
		MainGameLoopLockObj = RuntimeHelpers.GetObjectValue(new object());
		m_ConfigDic = new List<ActiveUnit>();
		m_RegistryDic = new Dictionary<ActiveUnit, bool>();
		_DefinitionDic = new List<Task>();
		valDic = RuntimeHelpers.GetObjectValue(new object());
		UseExceptionFuse = true;
		RegisteredExceptions = new Dictionary<string, ExceptionEntry>();
		clientDic = RuntimeHelpers.GetObjectValue(new object());
		m_DicDic = new List<LoggedMessage>();
	}

	internal static void ResolveBridge(string string_0, Side side_0, string string_1 = "", MessageBoxMessageType messageBoxMessageType_0 = MessageBoxMessageType.Information)
	{
		_ConsumerDic?.Invoke(string_0, string_1, side_0, messageBoxMessageType_0);
	}

	internal static MemoryTributary PostBridge(Scenario scenario_0)
	{
		MemoryTributary memoryTributary = new MemoryTributary();
		if (scenario_0 == null)
		{
			return memoryTributary;
		}
		object mainGameLoopLockObj = MainGameLoopLockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(mainGameLoopLockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(mainGameLoopLockObj, ref lockTaken);
			scenario_0.SerializationInProgress = true;
			scenario_0.ToXML(memoryTributary, bool_0: true);
			scenario_0.SerializationInProgress = false;
			return memoryTributary;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(mainGameLoopLockObj);
			}
		}
	}

	public static void ClearScenarioClone()
	{
		ScenarioLastGoodClone = null;
		ScenarioLastGoodClone_DateTime = DateTime.MinValue;
	}

	public static void DestroyPreviousScenario(ref Scenario scenario_0, bool bool_1)
	{
		try
		{
			foreach (ActiveUnit item in scenario_0.ActiveUnits_List.ToList())
			{
				ActiveUnit activeUnit_ = item;
				if (activeUnit_ != null)
				{
					DestroyUnit_PrepareForGC(ref activeUnit_);
				}
			}
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				foreach (Contact contacts_ in sides_ReadOnly[i].Contacts_List)
				{
					Contact contact_ = contacts_;
					DestroyContact_PrepareForGC(ref contact_);
				}
			}
			if (bool_1)
			{
				scenario_0.Scenario_LuaSandbox.ClearStats();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DestroyUnit_PrepareForGC(ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (activeUnit_0 == null)
			{
				return;
			}
			if (activeUnit_0.Mounts != null)
			{
				foreach (Mount mount in activeUnit_0.Mounts)
				{
					foreach (WeaponRec mountWeapon in mount.MountWeapons)
					{
						mountWeapon.DestroyWeaponRec();
					}
					foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
					{
						weapon.DestroyWeaponRec();
					}
				}
			}
			if (activeUnit_0.SharedMagazines != null)
			{
				Magazine[] sharedMagazines = activeUnit_0.SharedMagazines;
				for (int i = 0; i < sharedMagazines.Length; i++)
				{
					foreach (WeaponRec weapon2 in sharedMagazines[i].Weapons)
					{
						weapon2.DestroyWeaponRec();
					}
				}
			}
			if (activeUnit_0.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit_0;
				if (aircraft.Loadout != null)
				{
					WeaponRec[] weapons = aircraft.Loadout.Weapons;
					for (int j = 0; j < weapons.Length; j = checked(j + 1))
					{
						weapons[j].DestroyWeaponRec();
					}
				}
				aircraft.Loadout = null;
			}
			if (activeUnit_0.AirFacilities_ReadOnly != null && activeUnit_0.AirFacilities_ReadOnly.Length != 0)
			{
				AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
				AirFacility[] array = airFacilities_ReadOnly;
				foreach (AirFacility airFacility in array)
				{
					if (airFacility.AssetReader())
					{
						airFacility.HostedAircraft.Clear();
					}
				}
			}
			if (activeUnit_0.DockFacilities_ReadOnly != null && activeUnit_0.DockFacilities_ReadOnly.Length != 0)
			{
				DockFacility[] dockFacilities_ReadOnly = activeUnit_0.DockFacilities_ReadOnly;
				DockFacility[] array2 = dockFacilities_ReadOnly;
				foreach (DockFacility dockFacility in array2)
				{
					if (dockFacility.AddRepository())
					{
						dockFacility.HostedBoats.Clear();
					}
				}
			}
			foreach (PlatformComponent item in activeUnit_0.OrderIssuer())
			{
				if (item.ParentPlatform != null)
				{
					item.ParentPlatform = null;
				}
			}
			activeUnit_0.Sensory.DestroyLocalContacts();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101226", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DestroyContact_PrepareForGC(ref Contact contact_0)
	{
		if (contact_0.ActualUnit != null)
		{
			contact_0.ActualUnit = null;
		}
	}

	public static void CoreInitialize(bool bool_1)
	{
		Timer_1minute = new Stopwatch();
		Timer_1minute.Start();
		try
		{
			LicenseTierContext = _ProLicenseTier.None;
			if (!Directory.Exists(TopLevelWritablePath))
			{
				Directory.CreateDirectory(TopLevelWritablePath);
			}
			if (!Directory.Exists(TempPath))
			{
				Directory.CreateDirectory(TempPath);
			}
			if (!Directory.Exists(DBFolderPath))
			{
				Directory.CreateDirectory(DBFolderPath);
			}
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("开始初始化Sim Core。");
			}
			if (Directory.Exists(TempPath))
			{
				Misc.DeleteEverythingInDirectory(TempPath);
			}
			else
			{
				Directory.CreateDirectory(TempPath);
			}
			RCMS.recyclableMemoryStreamManager_0 = new RecyclableMemoryStreamManager();
			Pathfinding.Initialize();
			Task.Factory.StartNew(DBOps.ScanDatabases);
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("成功启动数据库扫描。");
			}
			Terrain.InitializeTerrain();
			LandCover.LoadGrids();
			Task.Factory.StartNew(TerrainMisc.InitializeMaxMinStore);
			SeaIceProvider.Initialize();
			if (!Directory.Exists(AttachmentRepoPath))
			{
				Directory.CreateDirectory(AttachmentRepoPath);
			}
			SevenZipBase.SetLibraryPath(MerchantMerchantPage.LogoutList.Info.DirectoryPath + "\\7z.dll");
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("成功创建了Sim World。");
			}
			Misc.AngularDistance_5nm = Math2.TestClass(5.0);
			TemplateDic.IncludeClass();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("完成初始化Sim Core。");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200577", exception_.Message);
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void MainGameLoop(ref Scenario scenario_0)
	{
		object mainGameLoopLockObj = MainGameLoopLockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(mainGameLoopLockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(mainGameLoopLockObj, ref lockTaken);
			try
			{
				scenario_0.AdjustGameResolution();
				VeryHighIntensityResolution = _InstanceDic - scenario_0.GameResolution;
				HighIntensityResolution = _ObjectDic - scenario_0.GameResolution;
				if (DateTime.Compare(scenario_0.Time, scenario_0.StartTime.Add(scenario_0.Duration)) > 0 && !scenario_0.HasEnded)
				{
					scenario_0.EndScenario();
				}
				scenario_0.ExecutionInProgress = true;
				CatastrophicCoreException = null;
				scenario_0.SetTime(bool_0: false, scenario_0.Time.AddSeconds(scenario_0.GameResolution));
				if (!scenario_0.HasBeenReleased)
				{
					GameEvents(ref scenario_0, scenario_0.GameResolution);
					scenario_0.ExecutionInProgress = false;
					if (Timer_1minute.ElapsedMilliseconds > 30000)
					{
						GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
						Timer_1minute.Restart();
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				scenario_0.ExecutionInProgress = false;
				CatastrophicCoreException = exception_;
				exception_?.Data.Add("Error at 300000", "");
				WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(mainGameLoopLockObj);
			}
		}
	}

	private static void RunBridge(ActiveUnit activeUnit_0, List<ActiveUnit> list_0, float float_0)
	{
		if (activeUnit_0 == null)
		{
			return;
		}
		try
		{
			bool flag = activeUnit_0.IsOperating();
			ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
			if (flag)
			{
				ActiveUnit_Navigator navigator = activeUnit_0.Navigator;
				ActiveUnit_AI aI = activeUnit_0.AI;
				ActiveUnit_Sensory sensory = activeUnit_0.Sensory;
				try
				{
					if (!Module_Unit.AwakeTokenizer(activeUnit_0))
					{
						navigator?.Housekeeping(float_0);
						Sensor[] sensors_Cached = activeUnit_0.Sensors_Cached;
						if (sensory != null && activeUnit_0.ParentScen != null && activeUnit_0.ParentScen.SecondIsChangingOnThisPulse && sensors_Cached != null && sensors_Cached.Length != 0)
						{
							sensory.vmethod_0(sensors_Cached);
							sensory.PerformDetections(sensors_Cached, list_0, float_0);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101263", "");
					WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if ((activeUnit_0.IsExhausted() & ((activeUnit_0.Status != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion) & (activeUnit_0.Status != ActiveUnit._ActiveUnitStatus.RTB_Manual))) && activeUnit_0.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)activeUnit_0;
					activeUnit_0.FuelState = aircraft.GetIsBingoOrJoker(null, aircraft.Doctrine.GetBingoJoker(aircraft.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
					activeUnit_0.WeaponState = aircraft.Weaponry.IsWinchesterOrShotgun();
					activeUnit_0.AirOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Exhaustion, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
					if (Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
					{
						_ = " (" + activeUnit_0.UnitClass + ")";
					}
					ActiveUnit actualDestinationHost = ((Aircraft_AirOps)activeUnit_0.AirOps).ActualDestinationHost;
					if (actualDestinationHost != null)
					{
						_ = " (" + actualDestinationHost.Name + ")";
					}
					activeUnit_0.Navigator.ResetTimeToNextPathfinderCheck();
				}
				try
				{
					activeUnit_0.Kinematics.Move(float_0, bool_0: true, bool_1: false, activeUnit_0.ParentScen.Time);
					if (!Module_Unit.AwakeTokenizer(activeUnit_0) && !activeUnit_0.IsGroup)
					{
						activeUnit_0.DoFuelConsumption(float_0);
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 1320945888121", "");
					WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					activeUnit_0.EvaluateIfDumb();
					if (!Module_Unit.AwakeTokenizer(activeUnit_0) && !activeUnit_0.IsDumbAU)
					{
						aI.TimeToNextTargetsEvaluation -= float_0;
						if (aI.TimeToNextTargetsEvaluation <= 0f)
						{
							activeUnit_0._PublisherVal = true;
							if (activeUnit_0._IndexerVal == 0)
							{
								aI.TimeToNextTargetsEvaluation = LockRandom_0.Next(10, 21);
							}
							else
							{
								aI.TimeToNextTargetsEvaluation = activeUnit_0.OODA_Targeting_Actual() + LockRandom_0.Next(-1, 2);
							}
						}
						else
						{
							activeUnit_0._PublisherVal = false;
						}
						aI.TimeToNextThreatEvaluation -= float_0;
						if (aI.TimeToNextThreatEvaluation <= 0f)
						{
							activeUnit_0._ServerVal = true;
							if (activeUnit_0._ResolverVal == 0)
							{
								aI.TimeToNextThreatEvaluation = LockRandom_0.Next(10, 21);
							}
							else
							{
								aI.TimeToNextThreatEvaluation = activeUnit_0._ResolverVal + LockRandom_0.Next(-1, 2);
							}
						}
						else
						{
							activeUnit_0._ServerVal = false;
						}
						if (!activeUnit_0.IsDumbAU || !activeUnit_0.IsFixedFacility)
						{
							if (activeUnit_0._ServerVal || (aI.EvaluateTargets_Enabled && activeUnit_0._PublisherVal))
							{
								aI.DefineClient(Module_ActiveUnit_Sensory.ListTokenizer(activeUnit_0.Sensory));
								if (aI.PrintClient() != null && aI.PrintClient().Count > 0)
								{
									int count = aI.PrintClient().Count;
									aI.m_AccountVal = new Tuple<Contact, Misc.PostureStance>[count - 1 + 1];
								}
								else
								{
									aI.DefineClient(new List<Contact>());
								}
							}
							if (activeUnit_0._ServerVal)
							{
								aI.EvaluateThreats();
							}
							if (aI.EvaluateTargets_Enabled && activeUnit_0._PublisherVal)
							{
								aI.EvaluateTargets(float_0, bool_0: false, bool_1: true);
								aI.TargetsSortedByRange = aI.SortTargetsByRange_ReadOnly;
								List<ActiveUnit_AI.TargetingEntry> list = new List<ActiveUnit_AI.TargetingEntry>();
								if ((activeUnit_0.GetUnitSide().callbackProxy != null) & (aI.TargetsSortedByRange != null))
								{
									foreach (KeyValuePair<string, FiringProposal> item in activeUnit_0.GetUnitSide().callbackProxy)
									{
										ActiveUnit_AI.TargetingEntry[] targetsSortedByRange = aI.TargetsSortedByRange;
										ActiveUnit_AI.TargetingEntry[] array = targetsSortedByRange;
										foreach (ActiveUnit_AI.TargetingEntry targetingEntry in array)
										{
											if ((Operators.CompareString(item.Value.Target.ObjectID, targetingEntry.Target.ObjectID, TextCompare: false) == 0 && Operators.CompareString(item.Value.FiringUnit.ObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0) & (DateTime.Compare(item.Value.ETA, DateTime.MinValue) != 0))
											{
												list.Add(targetingEntry);
											}
										}
									}
									foreach (ActiveUnit_AI.TargetingEntry item2 in list)
									{
										ArrayExtensions.Remove(ref aI.TargetsSortedByRange, item2);
									}
								}
							}
						}
						if (infoClient && flag)
						{
							if (activeUnit_0.ParentScen.SecondIsChangingOnThisPulse)
							{
								aI.DeterminePrimaryThreat();
							}
							if (aI.DeterminePrimaryTarget_Enabled && activeUnit_0._PublisherVal)
							{
								aI.DeterminePrimaryTarget(1f, bool_0: false, bool_1: true);
							}
							if (activeUnit_0.ParentScen.FifthSecondIsChangingOnThisPulse)
							{
								aI.ViewClient();
							}
							if (activeUnit_0.ParentScen.SecondIsChangingOnThisPulse)
							{
								aI.EvaluateUnitStatus(float_0, bool_0: false, bool_1: false);
							}
						}
						if (helperClient)
						{
							activeUnit_0.EvaluateIfDumb();
							if ((!Module_Unit.AwakeTokenizer(activeUnit_0) & activeUnit_0.IsPalletWeapon & activeUnit_0.IsOperating()) && activeUnit_0.ParentScen.SecondIsChangingOnThisPulse)
							{
								activeUnit_0.Weaponry.ExecuteWeaponSalvos(float_0);
								if (aI.m_EventVal == null)
								{
									aI.m_EventVal = activeUnit_0;
								}
								aI.EngageTargets(float_0);
							}
							if (!Module_Unit.AwakeTokenizer(activeUnit_0) && !activeUnit_0.IsDumbAU && !activeUnit_0.IsWeapon && !activeUnit_0.IsGroup && activeUnit_0.IsOperating() && activeUnit_0.ParentScen.SecondIsChangingOnThisPulse)
							{
								activeUnit_0.Weaponry.ExecuteWeaponSalvos(float_0);
								if (aI.m_EventVal == null)
								{
									aI.m_EventVal = activeUnit_0;
								}
								aI.EngageTargets(float_0);
							}
						}
					}
					else if (infoClient && activeUnit_0.IsDumbAU)
					{
						if (activeUnit_0.HasCargo)
						{
							activeUnit_0.AI.EvaluateUnitCargoStatus(float_0);
						}
						if (activeUnit_0.ParentScen.FifthSecondIsChangingOnThisPulse && activeUnit_0.AI.ValidateClient())
						{
							aI.ViewClient();
							if (aI.PrimaryPickupTarget != null)
							{
								activeUnit_0.DockingOps.SettleForCargoTransfer();
							}
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 101264", "");
					WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!Module_Unit.AwakeTokenizer(activeUnit_0) && !activeUnit_0.IsDumbAU && aI != null)
					{
						if (!activeUnit_0.IsFacility && !activeUnit_0.IsShip && !activeUnit_0.IsSubmarine)
						{
							aI.DetermineDesiredAttitudeAndThrottle(float_0);
							if (activeUnit_0.IsAircraft)
							{
								Aircraft aircraft2 = (Aircraft)activeUnit_0;
								if (activeUnit_0.SupportsAttitude_Pitch && !aI.CalculatedDesiredPitchThisPulse)
								{
									aircraft2.AI.VisitFacade(null, float_0, aircraft2.DesiredAltitude);
								}
								if (aircraft2.Doctrine.NewRepository(aircraft2.ParentScen).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active && Module_Unit.RangeToUnit_Horiz(aircraft2, aircraft2.AirOps.A2AR_Destination) < 5f)
								{
									aircraft2.AirOps.ActiveRadarDoctrineBeforeRefueling = aircraft2.Doctrine.NewRepository(aircraft2.ParentScen).LoginInterruptibleField();
									aircraft2.AirOps.EMCONInheritFromParentBeforeRefueling = aircraft2.Doctrine.EMCON_Inherits;
									aircraft2.Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, activeUnit_0.ParentScen);
								}
							}
						}
						else if (activeUnit_0.ParentScen != null && activeUnit_0.ParentScen.SecondIsChangingOnThisPulse)
						{
							aI.DetermineDesiredAttitudeAndThrottle(float_0);
							if (activeUnit_0.IsSubmarine && activeUnit_0.CurrentSpeed != 0f)
							{
								((Submarine)activeUnit_0).AI.StopSpecification();
							}
						}
						aI.CalculateDesiredRoll();
					}
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at 101265", "");
					WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!Module_Unit.AwakeTokenizer(activeUnit_0))
					{
						if (weaponry != null && !activeUnit_0.IsGroup && activeUnit_0.ParentScen.SecondIsChangingOnThisPulse)
						{
							weaponry.PrecacheDLZchecks();
							weaponry.ReduceTimesToFire(1f);
							weaponry.ReloadMounts();
							if (!Misc.IsEmpty_LockFreeCheck(weaponry.ETA_ResultsCache))
							{
								foreach (KeyValuePair<Tuple<ActiveUnit, int, ScenarioObject>, double> item3 in weaponry.ETA_ResultsCache)
								{
									if (Side.Needs_To_Recalculate_Weapon_ETA(item3.Key.Item1, item3.Key.Item3))
									{
										weaponry.ETA_ResultsCache.Clear();
									}
								}
							}
						}
						ActiveUnit_Damage damage = activeUnit_0.Damage;
						if (damage != null && flag)
						{
							damage.UnderwayRepairs(float_0);
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_NoBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_NoBuffer -= float_0;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer -= float_0;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer -= float_0;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer -= float_0;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer -= float_0;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer -= float_0;
						}
						if (navigator.TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer -= float_0;
						}
						if (navigator.TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer -= float_0;
						}
						if (navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation > 0.0)
						{
							navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation -= float_0;
						}
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at 101266", "");
					WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (!activeUnit_0.IsAircraft)
				{
					return;
				}
				((Aircraft)activeUnit_0).ShouldDropSonobuoysOnThisPulse = true;
				if (((Aircraft)activeUnit_0).AI.DefineFacade())
				{
					Parallel.ForEach(new List<Weapon>(activeUnit_0.ParentScen.SonobuoysInWater), delegate(Weapon theSon, ParallelLoopState loopstate)
					{
						if (theSon.Type == Weapon._WeaponType.Sonobuoy && theSon.Sensors_ReadOnly().Length != 0 && (activeUnit_0.GetUnitSide() == theSon.GetUnitSide() || Module_Side.IsAlliedWithThisSide(activeUnit_0.GetUnitSide(), theSon.GetUnitSide())) && (double)Module_Unit.RangeToUnit_Horiz(activeUnit_0, theSon) < Math.Min(9.5, (double)theSon.Sensors_ReadOnly()[0].maxRange * 1.5))
						{
							((Aircraft)activeUnit_0).ShouldDropSonobuoysOnThisPulse = false;
							loopstate.Stop();
						}
					});
				}
				else
				{
					((Aircraft)activeUnit_0).ShouldDropSonobuoysOnThisPulse = false;
				}
			}
			else if (!activeUnit_0.IsGroup && !activeUnit_0.IsOperating())
			{
				activeUnit_0.DoWithdrawalCleanUp();
				weaponry.ReduceTimesToFire(float_0);
			}
		}
		catch (Exception ex6)
		{
			ProjectData.SetProjectError(ex6);
			Exception exception_6 = ex6;
			exception_6?.Data.Add("Error at 300001", "");
			WriteExceptionsToLog(ref exception_6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void smethod_0(Bitmap bitmap_1)
	{
		bitmap_0 = bitmap_1;
		bitmap_0.Save(TempPath + "\\map.png");
	}

	public static void ReleaseReferences()
	{
		try
		{
			m_ConfigDic.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void GameEvents(ref Scenario scenario_0, float float_0)
	{
		PrintBridge(scenario_0, float_0);
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			sides_ReadOnly[i].AssetOrder();
		}
		m_ConfigDic.Clear();
		foreach (KeyValuePair<string, ActiveUnit> activeUnit in scenario_0.ActiveUnits)
		{
			m_ConfigDic.Add(activeUnit.Value);
		}
		LockRandom lockRandom_ = LockRandom_0;
		DumbAUsThisPulse = 0;
		SmartAUsThisPulse = 0;
		try
		{
			if (m_ConfigDic.Count > 0)
			{
				try
				{
					List<ActiveUnit> Local_OffGridUnits = new List<ActiveUnit>();
					foreach (ActiveUnit item in m_ConfigDic)
					{
						if (item != null && !item.CommStuff.IsConnectedToSideNetwork && item.IsOperating())
						{
							Local_OffGridUnits.Add(item);
						}
					}
					Parallel.ForEach(m_ConfigDic, delegate(ActiveUnit theAUnit)
					{
						if (theAUnit != null)
						{
							RunBridge(theAUnit, Local_OffGridUnits, float_0);
						}
					});
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200492", exception_.Message);
					WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if ((object)typeof(Exception) == typeof(AggregateException))
					{
						exception_?.Data.Add("Error at 300020 ", ((AggregateException)exception_).InnerExceptions[0].Message);
						WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						exception_?.Data.Add("Error at 300002", "");
						WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					Scenario.CargoMovement.Clear();
					if (helperClient)
					{
						Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
						Side[] array = sides_ReadOnly2;
						foreach (Side side in array)
						{
							if (side.callbackProxy != null && side.callbackProxy.Count > 0)
							{
								side.PrintOrder(scenario_0, float_0);
							}
						}
					}
					foreach (ActiveUnit item2 in m_ConfigDic)
					{
						try
						{
							if (item2 == null || item2.GetUnitSide() == null || scenario_0.MorituriUnits.Contains(item2))
							{
								continue;
							}
							if (item2.IsShip && ((Ship)item2).IsSinking)
							{
								if (!Module_Unit.AwakeTokenizer(item2))
								{
									item2.SetDamagePts(bool_0: false, null, (float)((double)item2.GetDamagePts() - (double)item2.InitialDP / (double)(300 * LockRandom_0.Next(1, 7)) * (double)float_0));
									if (item2.GetDamagePts() <= (float)(-item2.InitialDP))
									{
										scenario_0.DestroyThisUnit(item2, "Ship has sunk");
									}
								}
								continue;
							}
							if (scenario_0.SecondIsChangingOnThisPulse)
							{
								item2.AddNewJourneyWaypoint();
							}
							if (!Module_Unit.AwakeTokenizer(item2))
							{
								item2.DoTypeSpecificActions(float_0, ref lockRandom_);
							}
							if (!Module_Unit.AwakeTokenizer(item2) && scenario_0.FifteenthSecondIsChangingOnThisPulse && item2.IsOperating())
							{
								if (scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming))
								{
									item2.CommStuff.CheckForCommsJamming();
								}
								else if (scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption))
								{
									item2.CommStuff.CheckForCommsDisruption();
								}
							}
							if (!Module_Unit.AwakeTokenizer(item2) && scenario_0.SecondIsChangingOnThisPulse && !item2.IsGroup && item2.IsOperating())
							{
								if (item2.Sensors_Cached.Length == 0)
								{
									item2.Sensory.ProcessContactListChanges_Local();
								}
								else
								{
									ActiveUnit_Sensory sensory = item2.Sensory;
									if (item2.CommStuff.IsConnectedToSideNetwork)
									{
										sensory.HandleDetections_OnGrid();
									}
									else
									{
										sensory.HandleDetections_OffGrid();
									}
									sensory.CheckMountDirectors();
									sensory = null;
								}
							}
							ActiveUnit_AI aI = item2.AI;
							if (!infoClient)
							{
								if (!item2.IsDumbAU && item2.IsOperating() && !Module_Unit.AwakeTokenizer(item2))
								{
									if (scenario_0.SecondIsChangingOnThisPulse)
									{
										aI.DeterminePrimaryThreat();
										if (aI.DeterminePrimaryTarget_Enabled)
										{
											aI.DeterminePrimaryTarget(1f, bool_0: false, bool_1: true);
										}
										if (scenario_0.FifthSecondIsChangingOnThisPulse)
										{
											aI.ViewClient();
										}
										item2.AI.EvaluateUnitStatus(float_0, bool_0: false, bool_1: false);
									}
									item2.AI.EvaluateUnitStatus(float_0, bool_0: false, bool_1: false);
								}
								else if (item2.IsDumbAU)
								{
									if (item2.HasCargo)
									{
										item2.AI.EvaluateUnitCargoStatus(float_0);
									}
									if (item2.ParentScen.FifthSecondIsChangingOnThisPulse && item2.AI.ValidateClient())
									{
										aI.ViewClient();
										if (aI.PrimaryPickupTarget != null)
										{
											item2.DockingOps.SettleForCargoTransfer();
										}
									}
								}
							}
							if (scenario_0.FifthSecondIsChangingOnThisPulse)
							{
								aI.EvaluateMissionStatus(scenario_0);
							}
							if (!Module_Unit.AwakeTokenizer(item2) && scenario_0.FifthSecondIsChangingOnThisPulse && item2.IsOperating())
							{
								item2.AirOps.LandingQueue_CleanUp();
								item2.AirOps.ReSortLandingQueue();
							}
							if (!Module_Unit.AwakeTokenizer(item2) && !item2.IsGroup && item2.IsOperating() && scenario_0.SecondIsChangingOnThisPulse)
							{
								item2.Damage.DoSecondaryDamage(float_0);
							}
							if (helperClient)
							{
								continue;
							}
							item2.EvaluateIfDumb();
							if ((!Module_Unit.AwakeTokenizer(item2) & item2.IsPalletWeapon & item2.IsOperating()) && scenario_0.SecondIsChangingOnThisPulse)
							{
								item2.Weaponry.ExecuteWeaponSalvos(float_0);
								if (aI.m_EventVal == null)
								{
									aI.m_EventVal = item2;
								}
								aI.EngageTargets(float_0);
							}
							if (!Module_Unit.AwakeTokenizer(item2) && !item2.IsDumbAU && !item2.IsWeapon && !item2.IsGroup && item2.IsOperating() && scenario_0.SecondIsChangingOnThisPulse)
							{
								item2.Weaponry.ExecuteWeaponSalvos(float_0);
								if (aI.m_EventVal == null)
								{
									aI.m_EventVal = item2;
								}
								aI.EngageTargets(float_0);
							}
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 300003", "");
							WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 300004", "");
					WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				QueryBridge(ref scenario_0, float_0, ref lockRandom_);
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_4 = ex4;
				exception_4?.Data.Add("Error at 300005", "");
				WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				DefineBridge(scenario_0, float_0);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception exception_5 = ex5;
				exception_5?.Data.Add("Error at 300006", "");
				WriteExceptionsToLog(ref exception_5);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (scenario_0.SecondIsChangingOnThisPulse)
				{
					if (_MerchantDic <= float.MaxValue)
					{
						_MerchantDic += 1f;
					}
					if (scenario_0.TimeCompression_SimSeconds == 1)
					{
						if (_MerchantDic < 1f)
						{
						}
					}
					else if (scenario_0.TimeCompression_SimSeconds == 2)
					{
						if (_MerchantDic < 2f)
						{
						}
					}
					else if (scenario_0.TimeCompression_SimSeconds == 5)
					{
						if (_MerchantDic < 5f)
						{
						}
					}
					else if (scenario_0.TimeCompression_SimSeconds == 15)
					{
						if (_MerchantDic < 15f)
						{
						}
					}
					else if (scenario_0.TimeCompression_SimSeconds == 30)
					{
					}
					if (Scenario.CargoMovement.Count > 0)
					{
						foreach (EventTrigger value in scenario_0.EventTriggers.Values)
						{
							if (value.Type == EventTrigger.EventTriggerType.UnitCargoMoved)
							{
								((EventTrigger_UnitCargoMoved)value).updateTrigger();
							}
						}
					}
					List<EventTrigger> list = new List<EventTrigger>();
					foreach (EventTrigger value2 in scenario_0.EventTriggers.Values)
					{
						if (value2.Type == EventTrigger.EventTriggerType.UnitCargoMoved && ((EventTrigger_UnitCargoMoved)value2).IsFulfilled)
						{
							list.Add(value2);
						}
					}
				}
			}
			catch (Exception ex6)
			{
				ProjectData.SetProjectError(ex6);
				Exception exception_6 = ex6;
				exception_6?.Data.Add("Error at 300007", "");
				WriteExceptionsToLog(ref exception_6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				foreach (CMANO.LuaFunctionArg luaFunction in CMANO.LuaFunctionList)
				{
					CMANO.CallFunctionSynchronously(luaFunction.func, luaFunction.args.ToArray());
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception exception_7 = ex7;
			exception_7?.Data.Add("Error at 300009", "");
			WriteExceptionsToLog(ref exception_7);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void StartBridge(ref List<ActiveUnit> list_0)
	{
		int count = list_0.Count;
		LockRandom lockRandom = new LockRandom();
		int num = count;
		do
		{
			double num2 = lockRandom.NextDouble();
			int num3 = (int)Math.Round(Math.Floor((double)num * num2) + 1.0);
			ActiveUnit value = list_0[num3 - 1];
			list_0[num3 - 1] = list_0[num - 1];
			list_0[num - 1] = value;
			num--;
		}
		while (num > 1);
	}

	private static void AssetBridge(Scenario scenario_0)
	{
		try
		{
			if (!scenario_0.AnyActiveWeaponEffectThreats && scenario_0.UnguidedWeapons.Count > 0)
			{
				List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.ToList();
				int num = scenario_0.UnguidedWeapons.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list != null && list[i] != null && list[i].ReferenceWeapon != null && list[i].ReferenceWeapon.IsNuke.Value && !list[i].IsMine)
					{
						scenario_0.AnyActiveWeaponEffectThreats = true;
						break;
					}
				}
			}
			if (scenario_0.AnyActiveWeaponEffectThreats || scenario_0.Explosions.Count <= 0)
			{
				return;
			}
			foreach (Explosion item in scenario_0.Explosions.ToList())
			{
				if (item.WarheadType == Warhead.WarheadType.Nuclear)
				{
					scenario_0.AnyActiveWeaponEffectThreats = true;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 0374656", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void PrintBridge(Scenario scenario_0, float float_0)
	{
		try
		{
			scenario_0.AnyActiveWeaponEffectThreats = false;
			scenario_0.GuidedWeaponsInAir = null;
			scenario_0.SonobuoysInWater = null;
			scenario_0.AllWeaponsAlive = null;
			scenario_0.Cache_PrimaryTargetForWhichPlatforms.Clear();
			_ = scenario_0.GuidedWeaponsInAir;
			AssetBridge(scenario_0);
			m_ManagerClient = new Dictionary<string, HashSet<string>>();
			Parallel.ForEach(scenario_0.Sides_ReadOnly, delegate(Side theSide)
			{
				theSide.PrePulseHousekeeping(scenario_0);
			});
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				side.ContactsJustSharedWithMe.Clear();
				HashSet<string> hashSet = new HashSet<string>();
				side.GetAllFriendlySides(scenario_0, hashSet);
				hashSet.Remove(side.ObjectID);
				m_ManagerClient.Add(side.ObjectID, hashSet);
			}
			if (scenario_0.Mines == null)
			{
				scenario_0.Mines = new List<UnguidedWeapon>();
			}
			scenario_0.Mines.Clear();
			if (scenario_0.UnguidedWeapons.Count > 0)
			{
				int count = scenario_0.UnguidedWeapons.Count;
				List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.ToList();
				for (int i = count - 1; i >= 0; i += -1)
				{
					if (list[i] != null)
					{
						UnguidedWeapon unguidedWeapon = list[i];
						if (unguidedWeapon.IsMine)
						{
							scenario_0.Mines.Add(unguidedWeapon);
						}
					}
				}
			}
			scenario_0.MineAllocation = new ObservableDictionary<string, UnguidedWeapon>();
			foreach (UnguidedWeapon value in scenario_0.UnguidedWeapons.Values)
			{
				bool? flag = value?.IsMine;
				if (!flag.GetValueOrDefault(true) || value._CandidateProxy == null || !flag.HasValue)
				{
					continue;
				}
				if (scenario_0.ActiveUnits.ContainsKey(value._CandidateProxy.ObjectID))
				{
					if (value._CandidateProxy.IsRTB_Or_CalledOff)
					{
						value._CandidateProxy = null;
					}
					else if (scenario_0.MineAllocation.ContainsKey(value._CandidateProxy.ObjectID))
					{
						value._CandidateProxy = null;
					}
					else
					{
						scenario_0.MineAllocation.Add(value._CandidateProxy.ObjectID, value);
					}
				}
				else
				{
					value._CandidateProxy = null;
				}
			}
			scenario_0.Cache_TimeOfDay = new Weather.TTimeOfDayType?[360][];
			scenario_0.ActiveUnits_List = null;
			List<ActiveUnit> list2 = new List<ActiveUnit>(scenario_0.ActiveUnits_List);
			m_RegistryDic.Clear();
			foreach (ActiveUnit item in list2)
			{
				if (item == null)
				{
					continue;
				}
				try
				{
					m_RegistryDic.Add(item, value: false);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_.Data.Add("Error at 987654687654354", "");
					WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			TList<ActiveUnit> Local_theBag = new TList<ActiveUnit>();
			Parallel.ForEach(list2, delegate(ActiveUnit theAU)
			{
				try
				{
					if (theAU != null)
					{
						if (theAU.IsOperating())
						{
							m_RegistryDic[theAU] = true;
						}
						theAU._CustomerVal = theAU.GetLongitude();
						theAU.m_SerializerVal = theAU.GetLatitude();
						theAU.AI.CalculatedDesiredPitchThisPulse = false;
						ActiveUnit_Sensory sensory = theAU.Sensory;
						ActiveUnit_Weaponry weaponry = theAU.Weaponry;
						theAU.PrePulseHousekeeping(float_0, scenario_0);
						sensory.AgeLocalAndPrivateContacts(float_0);
						if (scenario_0.SecondIsChangingOnThisPulse && !theAU.IsGroup && m_RegistryDic[theAU])
						{
							Sensor[] sensors_Cached = theAU.Sensors_Cached;
							sensory.UpdateSensorsCountdown_PreDetection(sensors_Cached);
							sensory.method_1(theAU.MineCountermeasures);
							theAU.CommStuff.ClearAllCommLinks();
						}
						if (!theAU.IsWeapon)
						{
							theAU.Doctrine.ClearCachedParentDoctrine();
							Doctrine doctrine = theAU.Doctrine;
							Scenario scenario_2 = scenario_0;
							bool flag3 = true;
							doctrine.GetParentDoctrine(scenario_2, ref flag3);
						}
						sensory.Housekeeping_PrePulse(float_0);
						weaponry.Housekeeping_PrePulse();
						if (theAU.IsWeapon)
						{
							Weapon weapon = (Weapon)theAU;
							weapon.clientReader = weapon.AboutToImpact_ActualTarget(float_0);
							weapon.dicReader = weapon.AboutToImpact_Contact(float_0);
						}
						if (theAU.IsFacility && ActiveUnit_DockingOps.HasPiers(theAU))
						{
							Local_theBag.Add(theAU);
						}
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at 101293A", "");
					WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			});
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = Local_theBag.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					_ = (ActiveUnit)enumerator3.Current;
					scenario_0.Cache_FacilitiesWithPiers = Local_theBag.ToList();
				}
			}
			finally
			{
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
			PublishBridge(ref scenario_0);
			sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array2 = sides_ReadOnly;
			foreach (Side side2 in array2)
			{
				if (side2.interceptorFacade == null)
				{
					side2.interceptorFacade = new List<ActiveUnit>(scenario_0.ActiveUnits.Count);
				}
				if (side2.m_MessageFacade == null)
				{
					side2.m_MessageFacade = new List<ActiveUnit>(scenario_0.ActiveUnits.Count);
				}
				side2.interceptorFacade.Clear();
				side2.m_MessageFacade.Clear();
				if (Operators.CompareString(scenario_0.GetCurrentSide().ObjectID, side2.ObjectID, TextCompare: false) == 0)
				{
					try
					{
						if (scenario_0.SecondIsChangingOnThisPulse)
						{
							foreach (ReferencePoint item2 in side2.RefPoints.ToList())
							{
								item2.Cycle_1sec(side2, scenario_0);
							}
							foreach (ReferencePoint item3 in side2.RefPoints_Slugtrail.ToList())
							{
								item3.Cycle_1sec(side2, scenario_0);
							}
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2.Data.Add("Error at 93758569436", "");
						WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (SimConfiguration.DefaultGamePreferences.SlugTrail_Use && ((SimConfiguration.DefaultGamePreferences.SlugTrailTimeFrequency == SlugTrailTimeFrequency.FithSecond && scenario_0.FifthSecondIsChangingOnThisPulse) || (SimConfiguration.DefaultGamePreferences.SlugTrailTimeFrequency == SlugTrailTimeFrequency.FithteenthSecond && scenario_0.FifteenthSecondIsChangingOnThisPulse) || (SimConfiguration.DefaultGamePreferences.SlugTrailTimeFrequency == SlugTrailTimeFrequency.OneMinute && scenario_0.MinuteIsChangingOnThisPulse)))
					{
						if (SimConfiguration.DefaultGamePreferences.SlugTrail_OwnAndAllied)
						{
							foreach (ActiveUnit item4 in side2.Units.ToList())
							{
								if (item4.CurrentSpeed != 0f)
								{
									ReferencePoint.CreateNewSlugTrailPoint(scenario_0, "", item4.GetLongitude(), item4.GetLatitude(), side2, scenario_0.Time.AddSeconds(SimConfiguration.DefaultGamePreferences.SlugTrail_LifeTime), Color.White, bool_0: true, bool_1: true);
								}
							}
						}
						Dictionary<Misc.PostureStance, bool> dictionary = new Dictionary<Misc.PostureStance, bool>();
						dictionary.Add(Misc.PostureStance.Friendly, SimConfiguration.DefaultGamePreferences.SlugTrail_Friendly);
						dictionary.Add(Misc.PostureStance.Hostile, SimConfiguration.DefaultGamePreferences.SlugTrail_Hostile);
						dictionary.Add(Misc.PostureStance.Neutral, SimConfiguration.DefaultGamePreferences.SlugTrail_Neutral);
						dictionary.Add(Misc.PostureStance.Unfriendly, SimConfiguration.DefaultGamePreferences.SlugTrail_Unfriendly);
						dictionary.Add(Misc.PostureStance.Unknown, SimConfiguration.DefaultGamePreferences.SlugTrail_UnKnown);
						foreach (Contact contacts_ in side2.Contacts_List)
						{
							Misc.PostureStance stance = contacts_.GetStance(side2);
							if (contacts_.CurrentSpeed != 0f && dictionary[stance])
							{
								Color colorFromStance = Helper.GetColorFromStance(contacts_.GetStance(side2));
								ReferencePoint.CreateNewSlugTrailPoint(scenario_0, "", contacts_.GetLongitude(), contacts_.GetLatitude(), side2, scenario_0.Time.AddSeconds(SimConfiguration.DefaultGamePreferences.SlugTrail_LifeTime), colorFromStance, bool_0: true, bool_1: true);
							}
						}
					}
				}
				Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
				Side[] array3 = sides_ReadOnly2;
				foreach (Side side3 in array3)
				{
					if (side3 == side2 || m_ManagerClient[side3.ObjectID].Contains(side2.ObjectID))
					{
						continue;
					}
					foreach (ActiveUnit unit in side3.Units)
					{
						if (unit == null)
						{
							continue;
						}
						if (unit.IsGroup)
						{
							Group group = (Group)unit;
							if (group.Type != Group.GroupType.AirBase && group.Type != Group.GroupType.Installation && group.Type != Group.GroupType.NavalBase && group.Type != Group.GroupType.MobileGroup)
							{
								continue;
							}
							bool flag2 = false;
							foreach (ActiveUnit value2 in group.Units.Values)
							{
								if (side2.Contacts.ContainsKey(value2.ObjectID))
								{
									flag2 = true;
									break;
								}
							}
							if (flag2)
							{
								side2.m_MessageFacade.Add(unit);
							}
						}
						else if (m_RegistryDic.ContainsKey(unit) && m_RegistryDic[unit])
						{
							side2.interceptorFacade.Add(unit);
						}
					}
				}
			}
			Parallel.ForEach(scenario_0.Sides_ReadOnly, delegate(Side theSide)
			{
				try
				{
					theSide.DiscardExpiredContacts(scenario_0);
					for (int m = theSide.Units.Count - 1; m >= 0; m += -1)
					{
						ActiveUnit activeUnit;
						try
						{
							if (m < theSide.Units.Count)
							{
								activeUnit = theSide.Units[m];
								if (activeUnit != null)
								{
									goto IL_00a5;
								}
								theSide.Units.Remove(activeUnit);
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						continue;
						IL_00a5:
						if (activeUnit.IsDestroyed)
						{
							theSide.Units.Remove(activeUnit);
						}
					}
					Parallel.ForEach(new List<Contact>(theSide.Contacts.Values), delegate(Contact theC)
					{
						if (scenario_0.SecondIsChangingOnThisPulse)
						{
							Contact.IncreaseAge(theC, theSide, 1f, scenario_0);
						}
						theC.PrePulseHousekeeping(float_0, scenario_0);
						theC.IsPreciselyLocatedOnThisPulse = false;
						theC.ChangedToFirmOnThisPulse = false;
						if (theC.DetectedEmissions == null)
						{
							theC.DetectedEmissions = new ObservableDictionary<int, EmissionContainer>();
						}
						else if (theC.DetectedEmissions.Count > 0)
						{
							IEnumerator<KeyValuePair<int, EmissionContainer>> enumerator13 = theC.DetectedEmissions.GetEnumerator();
							while (enumerator13.MoveNext())
							{
								if (!Information.IsNothing(enumerator13.Current))
								{
									enumerator13.Current.Value.Age += float_0;
								}
							}
						}
					});
					theSide.ProcessBaseContacts(ref scenario_0);
					theSide.ProcessAutoDetectableUnits(scenario_0, float_0);
					theSide.GetUnitsEngagedInOECM(bool_0: true);
					if (scenario_0.SecondIsChangingOnThisPulse)
					{
						List<Weapon> list3 = scenario_0.AllWeaponsAlive.Where((Weapon theW) => theW.GetUnitSide() == theSide).ToList();
						if (list3.Count > 0)
						{
							List<ActiveUnit> friendlyUnits_OperativeOnly = theSide.GetFriendlyUnits_OperativeOnly(scenario_0);
							foreach (Weapon current in list3)
							{
								current.CommStuff.CheckCommsAndDataLinks(float_0, friendlyUnits_OperativeOnly);
							}
						}
					}
					theSide.Operation.Tick(scenario_0, float_0);
					if (scenario_0.MinuteIsChangingOnThisPulse)
					{
						Mission mission_ = null;
						CheckForMissionWakeup(ref scenario_0, ref theSide, ref mission_, bool_1: false, bool_2: true, bool_3: true, 0);
					}
					if (scenario_0.MinuteIsChangingOnThisPulse)
					{
						ref Scenario scenario_ = ref scenario_0;
						ref Side side_ = ref theSide;
						ActiveUnit activeUnit_ = null;
						MissionPlanner.UpdateStrikeMissionWaypoints_AirborneAircraft(float_0, ref scenario_, ref side_, ref activeUnit_);
					}
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at 101293", "");
					WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			});
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 300010", "");
			WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void DefineBridge(Scenario scenario_0, float float_0)
	{
		try
		{
			_DefinitionDic.Clear();
			scenario_0.AddRemoveUnits();
			try
			{
				foreach (ActiveUnit item in scenario_0.MorituriUnits.ToList())
				{
					Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
					for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
					{
						sides_ReadOnly[i].Units.Remove(item);
					}
				}
				Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
				Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
				Side[] array4 = sides_ReadOnly2;
				foreach (Side side in array4)
				{
					HashSet<string> hashSet = new HashSet<string>();
					side.GetAllFriendlySides(scenario_0, hashSet);
					hashSet.Remove(side.ObjectID);
					dictionary.Add(side.ObjectID, hashSet);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101255", "");
				WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			DeconflictContactsBetweenAllies(scenario_0, m_ManagerClient);
			try
			{
				Side[] sides_ReadOnly6 = scenario_0.Sides_ReadOnly;
				IEnumerator enumerator2 = null;
				float float_ = 0f;
				Side[] array5 = sides_ReadOnly6;
				foreach (Side Local_theSide in array5)
				{
					Local_theSide.SetFriendlyUnits(scenario_0, null);
					Local_theSide.ProcessContactListChanges(scenario_0);
					Local_theSide.ProcessBaseContactListChanges(scenario_0);
					bool flag = Local_theSide.ExclusionZones.Count > 0;
					List<Contact> list = new List<Contact>();
					try
					{
						TList<Contact> Local_KillBag = new TList<Contact>();
						Parallel.ForEach(Local_theSide.Contacts_List, delegate(Contact theC)
						{
							if (theC.ActualUnit == null)
							{
								Local_KillBag.Add(theC);
							}
							else if (scenario_0.ActiveUnits.ContainsKey(theC.ActualUnit.ObjectID))
							{
								if (theC.ActualUnit.IsOperating())
								{
									if (Local_theSide.Units.Count > 0 && theC.ActualUnit.GetIsAutoDetectable(Local_theSide))
									{
										List<ActiveUnit> units = Local_theSide.Units;
										ActiveUnit activeUnit_2 = units[0];
										ActiveUnit_Sensory.UpdateContactData(ref activeUnit_2, ref theC, theC.ActualUnit, bool_0: false);
										units[0] = activeUnit_2;
									}
									if (theC.Age == 0f)
									{
										theC.HeldFor += float_0;
									}
								}
								else
								{
									Local_KillBag.Add(theC);
								}
							}
							else
							{
								Local_KillBag.Add(theC);
							}
						});
						try
						{
							enumerator2 = Local_KillBag.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								Contact contact = (Contact)enumerator2.Current;
								Local_theSide.DropContact(contact, ref scenario_0, bool_0: true);
								list.Add(contact);
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						foreach (Contact contacts_ in Local_theSide.Contacts_List)
						{
							contacts_.PostPulseHousekeeping(float_0, Local_theSide, scenario_0, bool_0: false);
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200291", "");
						WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					List<Contact> list2 = new List<Contact>(Local_theSide.Contacts_List);
					ActiveUnit[] array = null;
					bool flag2 = true;
					foreach (Contact item4 in list2)
					{
						if (item4.ActualUnit == null)
						{
							continue;
						}
						if (item4.ActualUnit.IsFixedFacility && item4.UncertaintyArea == null && item4.IDStatus < Contact_Base.IdentificationStatus.PreciseID && item4.ActualUnit.GetIsAutoDetectable(Local_theSide))
						{
							item4.method_0(scenario_0, Local_theSide, null, null, bool_0: false, bool_1: true, bool_2: false, bool_3: true, Contact_Base.IdentificationStatus.PreciseID);
						}
						if (item4 == null || item4.ActualUnit.GetIsAutoDetectable(Local_theSide))
						{
							continue;
						}
						if (item4.OriginalDetectorSide == null)
						{
							if (item4.ActualUnit.GetUnitSide() == Local_theSide)
							{
								list.Add(item4);
								scenario_0.AddMessage("目标" + item4.Name + " 被探测" + item4.OriginalDetectorSide.Name + " 丢弃 - " + (m_ManagerClient[item4.ActualUnit.GetUnitSide().ObjectID].Contains(Local_theSide.ObjectID) ? "对于未知友方单元" : "") + ((item4.ActualUnit.GetUnitSide() == Local_theSide) ? "对于我方单元" : ""), "目标故意被丢弃", LoggedMessage.MessageType.ContactChange, 0, null, Local_theSide, new Geopoint_Struct(item4.GetLongitude(), item4.GetLatitude()));
							}
							else if (m_ManagerClient[item4.ActualUnit.GetUnitSide().ObjectID].Contains(Local_theSide.ObjectID))
							{
								list.Add(item4);
								scenario_0.AddMessage("目标" + item4.Name + " 被探测" + item4.OriginalDetectorSide.Name + " 丢弃 - " + (m_ManagerClient[item4.ActualUnit.GetUnitSide().ObjectID].Contains(Local_theSide.ObjectID) ? "对于未知友方单元" : "") + ((item4.ActualUnit.GetUnitSide() == Local_theSide) ? "对于我方单元" : ""), "目标故意被丢弃", LoggedMessage.MessageType.ContactChange, 0, null, Local_theSide, new Geopoint_Struct(item4.GetLongitude(), item4.GetLatitude()));
							}
						}
						else if (item4.OriginalDetectorSide == Local_theSide)
						{
							if (item4.ActualUnit.GetUnitSide() == Local_theSide)
							{
								if (array == null)
								{
									array = new ActiveUnit[0];
									Side[] sides_ReadOnly4 = scenario_0.Sides_ReadOnly;
									Side[] array6 = sides_ReadOnly4;
									foreach (Side side2 in array6)
									{
										if (side2 != Local_theSide && side2.GetConsidersThisSideToBe(Local_theSide) != Misc.PostureStance.Friendly)
										{
											continue;
										}
										foreach (ActiveUnit unit2 in side2.Units)
										{
											if (!unit2.CommStuff.IsConnectedToSideNetwork)
											{
												array = (ActiveUnit[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray(array, new ActiveUnit[array.Length + 1]);
												array[array.Length - 1] = unit2;
											}
										}
									}
								}
								if (!array.Contains(item4.ActualUnit))
								{
									list.Add(item4);
									scenario_0.AddMessage("目标" + item4.Name + " 被探测" + item4.OriginalDetectorSide.Name + " 丢弃 - " + (m_ManagerClient[item4.ActualUnit.GetUnitSide().ObjectID].Contains(Local_theSide.ObjectID) ? "对于未知友方单元" : "") + ((item4.ActualUnit.GetUnitSide() == Local_theSide) ? "对于我方单元" : ""), "目标故意被丢弃", LoggedMessage.MessageType.ContactChange, 0, null, Local_theSide, new Geopoint_Struct(item4.GetLongitude(), item4.GetLatitude()));
								}
							}
							else
							{
								if (!m_ManagerClient[item4.ActualUnit.GetUnitSide().ObjectID].Contains(Local_theSide.ObjectID))
								{
									continue;
								}
								if (array == null)
								{
									array = new ActiveUnit[0];
									Side[] sides_ReadOnly3 = scenario_0.Sides_ReadOnly;
									Side[] array7 = sides_ReadOnly3;
									foreach (Side side3 in array7)
									{
										if (side3 != Local_theSide && side3.GetConsidersThisSideToBe(Local_theSide) != Misc.PostureStance.Friendly)
										{
											continue;
										}
										foreach (ActiveUnit unit3 in side3.Units)
										{
											if (!unit3.CommStuff.IsConnectedToSideNetwork)
											{
												array = (ActiveUnit[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray(array, new ActiveUnit[array.Length + 1]);
												array[array.Length - 1] = unit3;
											}
										}
									}
								}
								if (!array.Contains(item4.ActualUnit))
								{
									list.Add(item4);
									scenario_0.AddMessage("目标" + item4.Name + " 被探测" + item4.OriginalDetectorSide.Name + " 丢弃 - " + (m_ManagerClient[item4.ActualUnit.GetUnitSide().ObjectID].Contains(Local_theSide.ObjectID) ? "对于未知友方单元" : "") + ((item4.ActualUnit.GetUnitSide() == Local_theSide) ? "对于我方单元" : ""), "目标故意被丢弃", LoggedMessage.MessageType.ContactChange, 0, null, Local_theSide, new Geopoint_Struct(item4.GetLongitude(), item4.GetLatitude()));
								}
							}
						}
						else
						{
							if (item4.OriginalDetectorSide.Units.Count != 0 && m_ManagerClient[item4.OriginalDetectorSide.ObjectID].Contains(Local_theSide.ObjectID))
							{
								continue;
							}
							if (item4.OriginalDetectorSide.Units.Count <= 0)
							{
								Contact contact2 = item4.Clone();
								contact2.OriginalDetectorSide = Local_theSide;
								Local_theSide.AddContact(contact2, bool_0: true);
								list.Add(item4);
								continue;
							}
							HashSet<string> hashSet2 = new HashSet<string>();
							Local_theSide.GetAllFriendlySides(scenario_0, hashSet2);
							bool flag3 = false;
							foreach (string item5 in hashSet2)
							{
								if (m_ManagerClient[item5].Contains(item4.OriginalDetectorSide.ObjectID))
								{
									flag3 = true;
									break;
								}
							}
							if (!flag3)
							{
								hashSet2.Clear();
								item4.OriginalDetectorSide.GetAllFriendlySides(scenario_0, hashSet2);
								foreach (string item6 in hashSet2)
								{
									if (m_ManagerClient[item6].Contains(item4.OriginalDetectorSide.ObjectID))
									{
										flag3 = true;
										break;
									}
								}
							}
							if (!flag3 && item4.OriginalDetectorSide.Contacts.ContainsKey(item4.ActualUnit.ObjectID))
							{
								Contact contact3 = item4.Clone();
								contact3.OriginalDetectorSide = Local_theSide;
								Local_theSide.AddContact(contact3, bool_0: true);
								list.Add(item4);
							}
						}
					}
					if (scenario_0.SecondIsChangingOnThisPulse)
					{
						foreach (Contact item7 in list2)
						{
							if (!list.Contains(item7) && flag2)
							{
								Module_Side.ShareContactWithFriends(Local_theSide, scenario_0, item7);
							}
						}
					}
					Task.WaitAll(_DefinitionDic.ToArray());
					_DefinitionDic.Clear();
					if (scenario_0.FifthSecondIsChangingOnThisPulse)
					{
						foreach (Contact item8 in list2)
						{
							if (!flag || item8.m_ParamsObserver || (item8.ActualUnit != null && item8.ActualUnit.IsShip && ((Ship)item8.ActualUnit).IsSinking))
							{
								continue;
							}
							if (!Local_theSide.Cache_ContactStancesOnThisPulse.TryGetValue(item8.ObjectID, out var value))
							{
								value = item8.GetStance(Local_theSide);
							}
							if (value == Misc.PostureStance.Hostile || value == Misc.PostureStance.Friendly)
							{
								continue;
							}
							foreach (ExclusionZone exclusionZone in Local_theSide.ExclusionZones)
							{
								if (value == Misc.PostureStance.Hostile || exclusionZone.Area.Count == 0 || item8.ActualUnit == null || !exclusionZone.GetAffectsThisUnit(item8.ActualUnit) || !item8.ActualUnit.GetIsInsideThisArea(exclusionZone.Area, scenario_0, bool_0: true) || !item8.GetIsInsideThisArea(exclusionZone.Area, scenario_0, bool_0: true))
								{
									continue;
								}
								Misc.PostureStance postureStance;
								if (item8.SideIsKnown)
								{
									if (!exclusionZone.ViolatorsStance.ContainsKey(item8.GetUnitSide().ObjectID))
									{
										exclusionZone.ViolatorsStance.Add(item8.GetUnitSide().ObjectID, exclusionZone.MarkViolatorAs);
									}
									postureStance = exclusionZone.ViolatorsStance[item8.GetUnitSide().ObjectID];
								}
								else
								{
									if (!exclusionZone.ViolatorsStance.ContainsKey("UnknownContactSide"))
									{
										exclusionZone.ViolatorsStance.Add("UnknownContactSide", exclusionZone.MarkViolatorAs);
									}
									postureStance = exclusionZone.ViolatorsStance["UnknownContactSide"];
								}
								if (value == postureStance)
								{
									continue;
								}
								switch (postureStance)
								{
								case Misc.PostureStance.Hostile:
									if (array == null)
									{
										array = new ActiveUnit[0];
										Side[] sides_ReadOnly5 = scenario_0.Sides_ReadOnly;
										Side[] array8 = sides_ReadOnly5;
										foreach (Side side4 in array8)
										{
											if (side4 != Local_theSide && side4.GetConsidersThisSideToBe(Local_theSide) != Misc.PostureStance.Friendly)
											{
												continue;
											}
											foreach (ActiveUnit unit4 in side4.Units)
											{
												if (!unit4.CommStuff.IsConnectedToSideNetwork)
												{
													array = (ActiveUnit[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray(array, new ActiveUnit[array.Length + 1]);
													array[array.Length - 1] = unit4;
												}
											}
										}
									}
									if (array.Length != 0)
									{
										bool flag4 = false;
										ActiveUnit[] array2 = array;
										ActiveUnit[] array9 = array2;
										foreach (ActiveUnit activeUnit in array9)
										{
											_ = Debugger.IsAttached;
											if (((activeUnit.IsAircraft && item8.IsAircraftContact) || (activeUnit.IsShip && item8.IsShipContact) || (activeUnit.IsSubmarine && item8.IsSubmergedContact) || (activeUnit.IsFacility && item8.Type == Contact_Base.ContactType.Facility_Mobile)) && Module_Unit.RangeToPoint_Horiz(item8, activeUnit.Latitude_LastReported.Value, activeUnit.Longitude_LastReported.Value) < 10f && value != Misc.PostureStance.Unfriendly)
											{
												scenario_0.AddMessage("目标：" + item8.Name + "违反了封锁区：" + exclusionZone.Description + "但是在最近报告的位置附近" + activeUnit.Name + "，因此标记为UNFRIENDLY进行进一步调查", item8.Name + " 是非友方", LoggedMessage.MessageType.ContactChange, 0, null, Local_theSide, new Geopoint_Struct(item8.GetLongitude(), item8.GetLatitude()));
												flag4 = true;
												break;
											}
										}
										if (flag4)
										{
											item8.SetStance(Local_theSide, bool_0: false, Misc.PostureStance.Unfriendly);
											item8.m_ParamsObserver = true;
											break;
										}
									}
									scenario_0.AddMessage("目标：" + item8.Name + "违反了封锁区：" + exclusionZone.Description + "现在被认为是HOSTILE", item8.Name + "是敌方！", LoggedMessage.MessageType.ContactChange, 0, null, Local_theSide, new Geopoint_Struct(item8.GetLongitude(), item8.GetLatitude()));
									item8.SetStance(Local_theSide, bool_0: false, postureStance);
									break;
								case Misc.PostureStance.Unfriendly:
									scenario_0.AddMessage("目标：" + item8.Name + "违反了封锁区：" + exclusionZone.Description + "现在被认为是UNIFRIENDLY", item8.Name + " 是非友方", LoggedMessage.MessageType.ContactChange, 0, null, Local_theSide, new Geopoint_Struct(item8.GetLongitude(), item8.GetLatitude()));
									item8.SetStance(Local_theSide, bool_0: false, postureStance);
									break;
								}
							}
						}
					}
					if (scenario_0.SecondIsChangingOnThisPulse)
					{
						foreach (Contact item9 in list2)
						{
							if (!list.Contains(item9) && flag2)
							{
								Module_Side.ShareContactWithFriends(Local_theSide, scenario_0, item9);
							}
						}
					}
					foreach (Contact baseContacts_ in Local_theSide.BaseContacts_List)
					{
						if (baseContacts_.ActualUnit == null)
						{
							continue;
						}
						if (baseContacts_.ActualUnit != null && !scenario_0.ActiveUnits.ContainsKey(baseContacts_.ActualUnit.ObjectID))
						{
							Local_theSide.DropBaseContact(baseContacts_, ref scenario_0);
						}
						if (baseContacts_.ActualUnit == null)
						{
							Local_theSide.DropBaseContact(baseContacts_, ref scenario_0);
						}
						else
						{
							if (baseContacts_.Type != Contact_Base.ContactType.MobileGroup)
							{
								continue;
							}
							bool flag5 = false;
							foreach (ActiveUnit value2 in ((Group)baseContacts_.ActualUnit).Units.Values)
							{
								if (Local_theSide.Contacts.ContainsKey(value2.ObjectID))
								{
									flag5 = true;
									break;
								}
							}
							if (!flag5)
							{
								Local_theSide.DropBaseContact(baseContacts_, ref scenario_0);
							}
						}
					}
					int count = Local_theSide.RefPoints.Count;
					List<ReferencePoint> list3 = new List<ReferencePoint>(count);
					int num = count - 1;
					for (int j = 0; j <= num; j++)
					{
						list3.Add(Local_theSide.RefPoints[j]);
					}
					foreach (ExclusionZone exclusionZone2 in Local_theSide.ExclusionZones)
					{
						foreach (ReferencePoint item10 in exclusionZone2.Area)
						{
							if (item10.IsRelativeTo != null && !Local_theSide.RefPoints.Contains(item10))
							{
								list3.Add(item10);
							}
						}
					}
					foreach (NoNavZone noNavZone in Local_theSide.NoNavZones)
					{
						foreach (ReferencePoint item11 in noNavZone.Area)
						{
							if (item11.IsRelativeTo != null && !Local_theSide.RefPoints.Contains(item11))
							{
								list3.Add(item11);
							}
						}
					}
					foreach (ReferencePoint item2 in list3)
					{
						if (item2 == null || item2.IsRelativeTo == null)
						{
							continue;
						}
						if (item2.IsRelativeTo.IsActiveUnit && !scenario_0.ActiveUnits.ContainsKey(item2.IsRelativeTo.ObjectID))
						{
							item2.IsRelativeTo = null;
							continue;
						}
						if (item2.IsRelativeTo.DisableWriter())
						{
							bool flag6 = true;
							foreach (KeyValuePair<string, Contact> contact4 in Local_theSide.Contacts)
							{
								if ((Operators.CompareString(contact4.Value.ObjectID, item2.IsRelativeTo.ObjectID, TextCompare: false) == 0) | (Operators.CompareString(contact4.Value.ActualUnit.ObjectID, item2.IsRelativeTo.ObjectID, TextCompare: false) == 0))
								{
									flag6 = false;
								}
							}
							if (flag6)
							{
								item2.IsRelativeTo = null;
								continue;
							}
						}
						if (item2.IsRelativeTo.CompareWriter() | item2.IsRelativeTo.DisableWriter() | item2.IsRelativeTo.IsActiveUnit)
						{
							Module_Unit.Unit unit = (Module_Unit.Unit)item2.IsRelativeTo;
							switch (item2.BearingType)
							{
							case ReferencePoint.OrientationType.Rotating:
								float_ = Math2.UpdateClass(unit.CurrentHeading + item2.RelativeBearing);
								break;
							case ReferencePoint.OrientationType.Fixed:
								float_ = item2.RelativeBearing;
								break;
							}
							double longitude = unit.GetLongitude();
							double latitude = unit.GetLatitude();
							double double_ = item2.Longitude;
							double double_2 = item2.Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, item2.RelativeDistance, float_);
							item2.Latitude = double_2;
							item2.Longitude = double_;
						}
						else if (item2.IsRelativeTo.ReadWriter())
						{
							GeoPoint geoPoint = (GeoPoint)item2.IsRelativeTo;
							switch (item2.BearingType)
							{
							case ReferencePoint.OrientationType.Rotating:
								item2.BearingType = ReferencePoint.OrientationType.Fixed;
								float_ = item2.RelativeBearing;
								break;
							case ReferencePoint.OrientationType.Fixed:
								float_ = item2.RelativeBearing;
								break;
							}
							double longitude2 = geoPoint.Longitude;
							double latitude2 = geoPoint.Latitude;
							double double_3 = item2.Longitude;
							double double_4 = item2.Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_3, ref double_4, item2.RelativeDistance, float_);
							item2.Latitude = double_4;
							item2.Longitude = double_3;
						}
					}
					foreach (Contact item3 in list)
					{
						if (!Local_theSide.ContactsJustSharedWithMe.Contains(item3.ActualUnit.ObjectID))
						{
							Local_theSide.DropContact(item3, ref scenario_0, bool_0: true);
						}
					}
					Local_theSide.ProcessContactListChanges(scenario_0);
					Local_theSide.ProcessBaseContactListChanges(scenario_0);
				}
				Parallel.ForEach(scenario_0.ActiveUnits_List, delegate(ActiveUnit theAU)
				{
					if (theAU != null)
					{
						ActiveUnit_Sensory sensory2 = theAU.Sensory;
						theAU.Housekeeping_PostPulse();
						sensory2.Housekeeping_PostPulse(float_0);
						if (!theAU.IsGroup)
						{
							if (scenario_0.SecondIsChangingOnThisPulse)
							{
								sensory2.UpdateSensorsCountdown_PostDetection(theAU.Sensors_Cached);
								if (theAU.IsSubmarine)
								{
									theAU.TimeSinceLastThreatDetection_ESM += 1f;
								}
							}
							theAU.Sensors_Cached = null;
							theAU.MineCountermeasures = null;
						}
					}
				});
				Task[] array3 = new Task[_CallbackDic - 1 + 1];
				List<ActiveUnit>[] Local_WorkerThreadUnitLists = Misc.AddValue(scenario_0.ActiveUnits_List, _CallbackDic);
				int num2 = _CallbackDic - 1;
				for (int k = 0; k <= num2; k++)
				{
					int Local_theIndex = k;
					array3[k] = Task.Factory.StartNew(delegate
					{
						foreach (ActiveUnit current in Local_WorkerThreadUnitLists[Local_theIndex])
						{
							ActiveUnit activeUnit_ = current;
							if (activeUnit_ == null)
							{
								break;
							}
							ActiveUnit_Sensory sensory = activeUnit_.Sensory;
							_ = activeUnit_.Weaponry;
							activeUnit_.Housekeeping_PostPulse();
							sensory.Housekeeping_PostPulse(float_0);
							if (!activeUnit_.IsGroup)
							{
								if (scenario_0.SecondIsChangingOnThisPulse)
								{
									sensory.UpdateSensorsCountdown_PostDetection(activeUnit_.Sensors_Cached);
									if (activeUnit_.IsSubmarine)
									{
										activeUnit_.TimeSinceLastThreatDetection_ESM += 1f;
									}
								}
								activeUnit_.Sensors_Cached = null;
								activeUnit_.MineCountermeasures = null;
							}
							if (activeUnit_.IsWeapon)
							{
								Contact contact_ = activeUnit_.AI.PrimaryTarget;
								if (contact_ != null && contact_.ActualUnit != null && contact_.RemainingContinousTrackTime > 0f)
								{
									contact_.Age = 0f;
									ActiveUnit_Sensory.UpdateContactData(ref activeUnit_, ref contact_, contact_.ActualUnit, bool_0: false);
								}
							}
						}
					});
				}
				int num3 = _CallbackDic - 1;
				for (int l = 0; l <= num3; l++)
				{
					if (array3[l] != null)
					{
						array3[l].Wait();
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at 101254", "");
				WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			scenario_0.ActiveUnits_List = null;
			scenario_0.GuidedWeaponsInAir = null;
			scenario_0.SonobuoysInWater = null;
			scenario_0.AllWeaponsAlive = null;
			scenario_0.CleanUpExplosions();
			scenario_0.CleanUpWeaponImpacts();
			if (scenario_0.CurrentlyInsertingMessages)
			{
				scenario_0.EventWaitHandle_FinishPulse.WaitOne();
			}
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 300012", "");
			WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void PublishBridge(ref Scenario scenario_0)
	{
		try
		{
			scenario_0.Groups.Clear();
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (activeUnits_ != null && activeUnits_.IsGroup)
				{
					scenario_0.Groups.Add((Group)activeUnits_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300013", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void AddUnitToCollections(ref ActiveUnit activeUnit_0, ref Scenario scenario_0)
	{
		object listenerDic = m_ListenerDic;
		ObjectFlowControl.CheckForSyncLockOnValueType(listenerDic);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(listenerDic, ref lockTaken);
			scenario_0.ActiveUnits.Add(activeUnit_0.ObjectID, activeUnit_0);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(listenerDic);
			}
		}
	}

	internal static T AwakeBridge<T>(T item)
	{
		T result = default(T);
		try
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			T val;
			using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
			{
				binaryFormatter.Serialize(memoryStream, item);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				val = (T)binaryFormatter.Deserialize(memoryStream);
			}
			result = val;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300015", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static MemoryTributary ObjectToMemStream<T>(T obj)
	{
		MemoryTributary memoryTributary = new MemoryTributary();
		new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone)).Serialize(memoryTributary, obj);
		return memoryTributary;
	}

	public static T MemStreamToObject<T>(MemoryTributary memoryTributary_0)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		memoryTributary_0.Seek(0L, SeekOrigin.Begin);
		return (T)binaryFormatter.Deserialize(memoryTributary_0);
	}

	private static void QueryBridge(ref Scenario scenario_0, float float_0, ref LockRandom lockRandom_0)
	{
		try
		{
			if (scenario_0.Explosions.Count > 0)
			{
				for (int i = scenario_0.Explosions.Count - 1; i >= 0; i += -1)
				{
					scenario_0.Explosions[i].Progress(ref scenario_0, float_0);
				}
			}
			if (scenario_0.WeaponImpacts.Count > 0)
			{
				for (int j = scenario_0.WeaponImpacts.Count - 1; j >= 0; j += -1)
				{
					scenario_0.WeaponImpacts[j].Progress(ref scenario_0, float_0);
				}
			}
			if (scenario_0.ChaffClouds.Count > 0)
			{
				for (int k = scenario_0.ChaffClouds.Count - 1; k >= 0; k += -1)
				{
					ChaffCorridorCloud chaffCorridorCloud = scenario_0.ChaffClouds[k];
					chaffCorridorCloud.Progress(float_0);
					if (chaffCorridorCloud.GetCurrentAltitude() < 0f || Terrain.GetElevation(chaffCorridorCloud.GetLatitude(), chaffCorridorCloud.GetLongitude(), bool_0: false, scenario_0) > chaffCorridorCloud.CurtainCeiling)
					{
						scenario_0.ChaffClouds.Remove(chaffCorridorCloud);
					}
				}
			}
			if (scenario_0.WaterSplashes.Count > 0)
			{
				for (int l = scenario_0.WaterSplashes.Count - 1; l >= 0; l += -1)
				{
					scenario_0.WaterSplashes[l].Spread(scenario_0, float_0);
				}
			}
			if (scenario_0.GroundImpacts.Count > 0)
			{
				for (int m = scenario_0.GroundImpacts.Count - 1; m >= 0; m += -1)
				{
					scenario_0.GroundImpacts[m].Spread(scenario_0, float_0);
				}
			}
			scenario_0.CandidatesForDetectionByMines.Clear();
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (activeUnits_ != null && (activeUnits_.IsShip || activeUnits_.IsSubmarine || activeUnits_.IsMCMPlatform) && activeUnits_.IsOperating())
				{
					scenario_0.CandidatesForDetectionByMines.Add(activeUnits_);
				}
			}
			if (scenario_0.UnguidedWeapons.Count > 0)
			{
				int count = scenario_0.UnguidedWeapons.Count;
				List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.ToList();
				for (int n = count - 1; n >= 0; n += -1)
				{
					list[n]?.TypeSpecificActions(ref scenario_0, float_0, ref lockRandom_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300016", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static bool ResetBridge(ref Scenario scenario_0, string string_0)
	{
		if (string_0 == null)
		{
			return true;
		}
		try
		{
			if (((ScenarioObject)(object)string_0).IsActiveUnit)
			{
				return !scenario_0.ActiveUnits.ContainsKey(((ScenarioObject)(object)string_0).ObjectID);
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300017", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return true;
		}
	}

	public static void CloneScenario(Scenario scenario_0)
	{
		try
		{
			while (scenario_0.ExecutionInProgress)
			{
				Thread.Sleep(10);
			}
			scenario_0.SerializationInProgress = true;
			MemoryTributary memoryTributary = new MemoryTributary();
			scenario_0.ToXML(memoryTributary, bool_0: true);
			ScenarioLastGoodClone = memoryTributary;
			ScenarioLastGoodClone_DateTime = scenario_0.Time;
			scenario_0.SerializationInProgress = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200581", exception_.Message);
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DeconflictContactsBetweenAllies(Scenario scenario_0, Dictionary<string, HashSet<string>> dictionary_0)
	{
		TList<Contact> Local_RemList = null;
		try
		{
			Parallel.ForEach(scenario_0.Sides_ReadOnly, delegate(Side theSide)
			{
				Parallel.ForEach(new List<Contact>(theSide.Contacts_List), delegate(Contact theC)
				{
					if (theC.ActualUnit != null && theC.ActualUnit.ParentScen.Sides_ReadOnly.Contains(theC.ActualUnit.GetUnitSide()))
					{
						if (theC.SideIsKnown)
						{
							if (Module_Side.IsAlliedWithThisSide(theSide, theC.ActualUnit.GetUnitSide()))
							{
								if (Local_RemList == null)
								{
									Local_RemList = new TList<Contact>();
								}
								Local_RemList.Add(theC);
							}
							else if (dictionary_0[theC.ActualUnit.GetUnitSide().ObjectID].Contains(theSide.ObjectID))
							{
								if (Local_RemList == null)
								{
									Local_RemList = new TList<Contact>();
								}
								Local_RemList.Add(theC);
							}
						}
						else if (Module_Side.IsAlliedWithThisSide(theSide, theC.ActualUnit.GetUnitSide()) && !theC.ActualUnit.IsSubmarine)
						{
							if (Local_RemList == null)
							{
								Local_RemList = new TList<Contact>();
							}
							Local_RemList.Add(theC);
						}
					}
				});
				IEnumerator enumerator = null;
				if (Local_RemList != null)
				{
					try
					{
						enumerator = Local_RemList.GetEnumerator();
						while (enumerator.MoveNext())
						{
							Contact contact_ = (Contact)enumerator.Current;
							theSide.DropContact(contact_, ref scenario_0, bool_0: false);
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300019", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static ExceptionEntry MapBridge(DateTime dateTime_0, string string_0)
	{
		ExceptionEntry result = null;
		try
		{
			object obj = clientDic;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				ExceptionEntry exceptionEntry;
				if (RegisteredExceptions.ContainsKey(string_0))
				{
					exceptionEntry = RegisteredExceptions[string_0];
					exceptionEntry.AddOccurrences(dateTime_0);
				}
				else
				{
					exceptionEntry = new ExceptionEntry(string_0, dateTime_0);
					RegisteredExceptions.Add(string_0, exceptionEntry);
				}
				result = exceptionEntry;
				return result;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			UseExceptionFuse = false;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static void WriteExceptionsToLog(ref Exception exception_0, bool bool_1 = true, bool bool_2 = false, bool bool_3 = false)
	{
		if (exception_0 == null)
		{
			return;
		}
		try
		{
			if (exception_0 is AggregateException)
			{
				foreach (Exception innerException in ((AggregateException)exception_0).InnerExceptions)
				{
					SortBridge(innerException, bool_1, bool_2, bool_3);
				}
				return;
			}
			SortBridge(exception_0, bool_1, bool_2, bool_3);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			SortBridge(exception_0, bool_1, bool_2, bool_3);
			ProjectData.ClearProjectError();
		}
	}

	private static void SortBridge(Exception exception_0, bool bool_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (SimConfiguration.DefaultGamePreferences != null && !SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				return;
			}
			if (_ObserverDic == null)
			{
				_ObserverDic = new StringBuilder();
			}
			else
			{
				_ObserverDic.Clear();
			}
			DateTime now = DateTime.Now;
			if (bool_3)
			{
				_ObserverDic.Append(exception_0.Message);
			}
			else
			{
				_ObserverDic.Append(" -- B").Append("1328.18").Append(" -- ")
					.Append(exception_0.Message)
					.Append(" -- Scen : " + Debug_LastLoadedScenario + " -- ")
					.Append("DB : " + Debug_LastLoadedDB + " -- ");
				_ObserverDic.Append("异常：").Append(exception_0.Message).Append("\r\n")
					.Append("堆栈跟踪：")
					.Append(exception_0.StackTrace)
					.Append("\r\n");
				if (exception_0.InnerException != null)
				{
					_ObserverDic.Append("内部异常：").Append(exception_0.InnerException.Message).Append("\r\n")
						.Append("内部堆栈跟踪：")
						.Append(exception_0.InnerException.StackTrace)
						.Append("\r\n");
				}
				if (exception_0.Data.Count > 0)
				{
					_ObserverDic.Append("调用堆栈和错误详细信息：");
					IDictionaryEnumerator enumerator = exception_0.Data.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						DictionaryEntry dictionaryEntry = ((current == null) ? default(DictionaryEntry) : ((DictionaryEntry)current));
						_ObserverDic.Append("\r\n").Append(Conversions.ToString(dictionaryEntry.Key)).Append(": ")
							.Append(RuntimeHelpers.GetObjectValue(dictionaryEntry.Value));
					}
				}
			}
			if (bool_1 && UseExceptionFuse)
			{
				ExceptionEntry exceptionEntry = MapBridge(now, _ObserverDic.ToString());
				if (exceptionEntry != null && exceptionEntry.Fused)
				{
					return;
				}
				if (bool_2 && !exceptionEntry.UI_Ignored)
				{
					ErrorForm.Open(exceptionEntry);
				}
			}
			string text = _ObserverDic.Insert(0, now.ToString("dd/MM/yyyy HH:mm:ss")).ToString();
			if (m_IssuerDic == null)
			{
				m_IssuerDic = new StringBuilder();
			}
			else
			{
				m_IssuerDic.Clear();
			}
			m_IssuerDic.Append(LogsPath).Append(Path.DirectorySeparatorChar).Append("ExceptionLog_")
				.Append(DateTime.Now.Year)
				.Append("_")
				.Append(DateTime.Now.Month.ToString("D2"))
				.Append("_")
				.Append(DateTime.Now.Day.ToString("D2"))
				.Append(".txt");
			string path = m_IssuerDic.ToString();
			object obj = valDic;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				File.AppendAllText(path, "\r\n\r\n" + text);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
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

	public static void WriteLogDebugInfoToFile(string string_0)
	{
		try
		{
			bool? flag = SimConfiguration.DefaultGamePreferences?.LogDebugInfoToFile;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				return;
			}
			if (m_IssuerDic == null)
			{
				m_IssuerDic = new StringBuilder();
			}
			else
			{
				m_IssuerDic.Clear();
			}
			m_IssuerDic.Append(LogsPath).Append(Path.DirectorySeparatorChar).Append("ExceptionLog_")
				.Append(DateTime.Now.Year)
				.Append("_")
				.Append(DateTime.Now.Month.ToString("D2"))
				.Append("_")
				.Append(DateTime.Now.Day.ToString("D2"))
				.Append(".txt");
			string path = m_IssuerDic.ToString();
			object obj = valDic;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				File.AppendAllText(path, string_0 + "\r\n");
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
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

	public static void CheckForMissionWakeup(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, bool bool_2, bool bool_3, int int_0)
	{
		try
		{
			if (side_0.Missions == null)
			{
				return;
			}
			Mission._ContinousCoverageDuration continousCoverageDuration = Mission._ContinousCoverageDuration.hr_2;
			DateTime? nullable_ = null;
			DateTime? nullable_2 = null;
			Mission._FlightSize _FlightSize_ = default(Mission._FlightSize);
			Mission._FlightSize _FlightSize_2 = default(Mission._FlightSize);
			Mission._FlightSize _FlightSize_3 = default(Mission._FlightSize);
			bool bool_8 = false;
			bool bool_9 = false;
			Mission._GroupSize _GroupSize_ = default(Mission._GroupSize);
			Mission._GroupSize _GroupSize_2 = default(Mission._GroupSize);
			bool bool_10 = false;
			bool bool_11 = false;
			foreach (Mission item in side_0.GetMissionsTotal(scenario_0))
			{
				Mission mission_ = item;
				if (mission_ == null)
				{
					continue;
				}
				bool flag = false;
				if (mission_0 != null && mission_ != mission_0)
				{
					continue;
				}
				if (mission_.GetStatus(scenario_0) == Mission.MissionStatus.Inactive)
				{
					if (mission_.StartTime.HasValue)
					{
						DateTime? startTime = mission_.StartTime;
						DateTime time = scenario_0.Time;
						if ((startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) <= 0) : null).GetValueOrDefault() && (!mission_.EndTime.HasValue || (mission_.EndTime.HasValue && DateTime.Compare(mission_.EndTime.Value, scenario_0.Time) > 0)))
						{
							mission_.SetStatus(scenario_0, Mission.MissionStatus.Active);
							scenario_0.AddMessage("任务" + mission_.Name + "已被激活。", mission_.Name + "被启用", LoggedMessage.MessageType.UnitAI, 0, null, side_0);
						}
					}
				}
				else
				{
					if (mission_.StartTime.HasValue)
					{
						DateTime? startTime2 = mission_.StartTime;
						DateTime time2 = scenario_0.Time;
						if ((startTime2.HasValue ? new bool?(DateTime.Compare(startTime2.GetValueOrDefault(), time2) > 0) : null).GetValueOrDefault())
						{
							mission_.SetStatus(scenario_0, Mission.MissionStatus.Inactive);
							continue;
						}
					}
					if (mission_.EndTime.HasValue)
					{
						DateTime? endTime = mission_.EndTime;
						DateTime time3 = scenario_0.Time;
						if ((endTime.HasValue ? new bool?(DateTime.Compare(endTime.GetValueOrDefault(), time3) <= 0) : null).GetValueOrDefault())
						{
							mission_.SetStatus(scenario_0, Mission.MissionStatus.Inactive);
							flag = true;
							scenario_0.AddMessage("任务" + mission_.Name + "已停用。", mission_.Name + "被关闭", LoggedMessage.MessageType.UnitAI, 0, null, side_0);
						}
					}
				}
				if (flag)
				{
					foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
					{
						if (activeUnits_ == null || activeUnits_.IsGroup || !activeUnits_.IsOperating() || activeUnits_.AssignedMissionOrPackage() != mission_)
						{
							continue;
						}
						if (activeUnits_.IsAircraft)
						{
							if (activeUnits_.AirOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: false, bool_3: true))
							{
								string text = "";
								if (Operators.CompareString(activeUnits_.Name, activeUnits_.UnitClass, TextCompare: false) != 0)
								{
									text = " (" + activeUnits_.UnitClass + ")";
								}
								string text2 = "";
								ActiveUnit actualDestinationHost = ((Aircraft)activeUnits_).AirOps.ActualDestinationHost;
								if (!Information.IsNothing(actualDestinationHost))
								{
									text2 = " (" + actualDestinationHost.Name + ")";
								}
								activeUnits_.ParentScen.AddMessage(activeUnits_.Name + text + "正在返回基地" + text2, activeUnits_.Name + "在返回基地", LoggedMessage.MessageType.AirOps, 5, activeUnits_.ObjectID, activeUnits_.GetUnitSide(), new Geopoint_Struct(activeUnits_.GetLongitude(), activeUnits_.GetLatitude()));
							}
						}
						else if ((activeUnits_.IsShip || activeUnits_.IsSubmarine) && activeUnits_.DockingOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: false, bool_3: true))
						{
							string text3 = "";
							ActiveUnit actualDestinationHost2 = activeUnits_.DockingOps.ActualDestinationHost;
							if (!Information.IsNothing(actualDestinationHost2))
							{
								text3 = " (" + actualDestinationHost2.Name + ")";
							}
							activeUnits_.ParentScen.AddMessage(activeUnits_.Name + "正在返回停靠单元" + text3, activeUnits_.Name + "在返回基地", LoggedMessage.MessageType.DockingOps, 5, activeUnits_.ObjectID, activeUnits_.GetUnitSide());
						}
					}
				}
				else
				{
					if (mission_.GetStatus(scenario_0) != Mission.MissionStatus.Active && bool_2)
					{
						continue;
					}
					List<Group> list_ = new List<Group>();
					List<Aircraft> list_12 = new List<Aircraft>();
					List<Aircraft> list_22 = new List<Aircraft>();
					List<Aircraft> list_23 = new List<Aircraft>();
					double double_ = 120.0;
					bool bool_12 = false;
					if (mission_.TimeSincePlayerNotification < 30)
					{
						mission_.TimeSincePlayerNotification++;
					}
					else
					{
						mission_.TimeSincePlayerNotification = 1;
					}
					List<Aircraft> list_24 = new List<Aircraft>();
					List<Aircraft> list_25 = new List<Aircraft>();
					List<Aircraft> list_26 = new List<Aircraft>();
					List<Aircraft> list_27 = new List<Aircraft>();
					List<ActiveUnit> list_28 = new List<ActiveUnit>();
					List<int> list_2 = new List<int>();
					List<int> list_3 = new List<int>();
					List<ActiveUnit> list_4 = new List<ActiveUnit>();
					List<ActiveUnit> list_5 = new List<ActiveUnit>();
					List<int> list_6 = new List<int>();
					List<ActiveUnit> list_7 = new List<ActiveUnit>();
					int int_ = 0;
					int int_11 = 0;
					int int_12 = 0;
					int int_13 = 0;
					int int_14 = 0;
					int int_15 = 0;
					List<Mission.Flight> list_8 = new List<Mission.Flight>();
					List<Mission.Flight> list_9 = new List<Mission.Flight>();
					List<Mission.Flight> list_10 = new List<Mission.Flight>();
					bool bool_13 = false;
					float float_ = 0f;
					float float_2 = 0f;
					List<Aircraft> list_11 = new List<Aircraft>();
					List<Aircraft> list_13 = new List<Aircraft>();
					List<Aircraft> list_14 = new List<Aircraft>();
					int int_16 = 0;
					int int_17 = 0;
					int int_18 = 0;
					if (bool_1 && !Information.IsNothing(mission_.EmptySlotsList) && mission_.EmptySlotsList.Count > 0)
					{
						int num = 1;
						foreach (Mission.EmptyAircraftSlot emptySlots in mission_.EmptySlotsList)
						{
							if (emptySlots.ReferenceUnit_DBID != 0)
							{
								Mission mission = mission_;
								int referenceUnit_DBID = emptySlots.ReferenceUnit_DBID;
								int int_2 = emptySlots.int_0;
								Mission.EmptyAircraftSlot emptyAircraftSlot;
								Scenario scenario_;
								ActiveUnit activeUnit_ = (emptyAircraftSlot = emptySlots).GetCurrentHostUnit(scenario_ = scenario_0);
								Mission.EmptyAircraftSlot emptyAircraftSlot2;
								Scenario scenario_2;
								Mission.Flight flight_ = (emptyAircraftSlot2 = emptySlots).GetMissionFlight(scenario_2 = scenario_0);
								Aircraft aircraft = mission.CancelValue(ref scenario_0, ref side_0, referenceUnit_DBID, int_2, ref activeUnit_, ref flight_, emptySlots.IsEscort, num);
								emptyAircraftSlot2.SetMissionFlight(scenario_2, flight_);
								emptyAircraftSlot.SetCurrentHostUnit(scenario_, activeUnit_);
								Aircraft aircraft2 = aircraft;
								emptySlots.SetReferenceUnit(scenario_0, null, aircraft2);
								list_11.Add(aircraft2);
								num++;
							}
						}
					}
					if (mission_0 == null && scenario_0.FifthMinuteIsChangingOnThisPulse)
					{
						MissionPlanner.UpdateMissionWaypoints_BeforeTakeOff(ref scenario_0, ref mission_);
					}
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					if (mission_.MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol obj = (Patrol)mission_;
						flag2 = obj.ContinousCoverage_Enable;
						flag3 = obj.ContinousCoverage_QRAEnable;
						continousCoverageDuration = obj.ContinousCoverage_Duration;
					}
					if (mission_.MissionClass == Mission._MissionClass.Support)
					{
						SupportMission obj2 = (SupportMission)mission_;
						flag2 = obj2.ContinousCoverage_Enable;
						flag3 = obj2.ContinousCoverage_QRAEnable;
						continousCoverageDuration = obj2.ContinousCoverage_Duration;
					}
					if (flag2)
					{
						switch (continousCoverageDuration)
						{
						default:
							if (scenario_0.HourIsChangingOnThisPulse)
							{
								flag4 = true;
							}
							break;
						case Mission._ContinousCoverageDuration.hr_2:
							if (scenario_0.FifthMinuteIsChangingOnThisPulse)
							{
								flag4 = true;
							}
							break;
						case Mission._ContinousCoverageDuration.hr_4:
							if (scenario_0.FifteenthMinuteIsChangingOnThisPulse)
							{
								flag4 = true;
							}
							break;
						case Mission._ContinousCoverageDuration.hr_6:
							if (scenario_0.ThirtiethMinuteIsChangingOnThisPulse)
							{
								flag4 = true;
							}
							break;
						}
						if (flag4 || !Information.IsNothing(mission_0) || mission_.FlightList.Count == 0)
						{
							RateBridge(ref scenario_0, ref side_0, ref mission_, !Information.IsNothing(mission_0), double_, !Information.IsNothing(mission_0), !Information.IsNothing(mission_0));
							if (flag3)
							{
								FlushBridge(ref scenario_0, ref side_0, ref mission_, !Information.IsNothing(mission_0), double_, !Information.IsNothing(mission_0), !Information.IsNothing(mission_0));
							}
						}
					}
					if (bool_3)
					{
						CalcBridge(ref scenario_0, ref side_0, ref mission_, ref list_, ref list_12, ref list_22, ref list_23, double_, ref bool_12, bool_2: true, bool_3: false);
					}
					mission_.ReconfigureMissionForPrePlannedFlights(ref scenario_0, ref side_0, null);
					if (!mission_.UsePreGeneratedFlightplansOnly || (!Information.IsNothing(mission_0) && !flag2))
					{
						mission_.UnitsAssignedToMission_SeparatedByType(scenario_0, ref list_2, ref list_3, ref list_24, ref list_25, ref list_26, ref list_27, ref list_28, ref int_, ref int_11, ref int_12, ref int_13, ref int_14, ref int_15, ref list_6, ref list_4, ref list_5, list_7, ref list_11, ref list_13, ref list_14, ref int_16, ref int_17, ref int_18, ref list_8, ref list_9, ref list_10, bool_2, bool_1, bool_2: false);
						if (int_13 > 0 || (bool_1 && int_16 > 0) || ((bool_1 || bool_12) && (int_14 > 0 || int_15 > 0 || int_17 > 0 || int_18 > 0)))
						{
							List<Aircraft> list_15 = new List<Aircraft>();
							List<Aircraft> list_16 = new List<Aircraft>();
							List<Aircraft> list_17 = new List<Aircraft>();
							int int_3 = 0;
							int int_4 = 0;
							int int_5 = 0;
							int int_6 = 0;
							int int_7 = 0;
							int int_8 = 0;
							Doctrine._UseUnderwayRefuelAndReplenishment? nullable_3 = mission_.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
							string string_ = "";
							int int_9 = 0;
							int int_10 = 0;
							if (Information.IsNothing(mission_0) && !Information.IsNothing(nullable_3))
							{
								byte? b = (byte?)nullable_3;
								bool? flag5 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
								if (((!flag5) ?? flag5).GetValueOrDefault() && mission_.TankerUsage == Mission.TankerMethod.Mission)
								{
									if (Information.IsNothing(mission_.TankerMissions) || mission_.TankerMissions.Count == 0)
									{
										scenario_0.AddMessage("任务" + mission_.Name + "需要来自指定任务的加油机，但是没有选择加油机任务！攻击任务不会启动！", mission_.Name + " 未开始（无加油机！）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
										continue;
									}
									if (mission_.TankerMinNumber_Total > 0 || mission_.TankerMinNumber_Airborne > 0 || mission_.TankerMinNumber_Station > 0)
									{
										int num2 = 0;
										int num3 = 0;
										int num4 = 0;
										foreach (Mission tankerMission in mission_.TankerMissions)
										{
											foreach (ActiveUnit item2 in Module_Mission.AssetTokenizer(tankerMission, scenario_0))
											{
												if (!item2.IsAircraft)
												{
													continue;
												}
												Aircraft aircraft3 = (Aircraft)item2;
												if (!aircraft3.IsTanker || (aircraft3.GetUnitSide() != side_0 && !Module_Side.IsAlliedWithThisSide(aircraft3.GetUnitSide(), side_0)))
												{
													continue;
												}
												if (aircraft3.GetUnitSide() != side_0)
												{
													Doctrine._RefuelAlliedUnits? refuelAllies = aircraft3.Doctrine.GetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false);
													b = (byte?)refuelAllies;
													if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
													{
														continue;
													}
													b = (byte?)refuelAllies;
													if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
													{
														continue;
													}
												}
												num2++;
												if (aircraft3.IsOperating())
												{
													num3++;
													if (tankerMission.MissionClass == Mission._MissionClass.Support && !aircraft3.Navigator.IsInSupportTransit)
													{
														num4++;
													}
												}
											}
										}
										if (mission_.TankerMinNumber_Total > 0)
										{
											if (num2 == 0)
											{
												if (mission_.TimeSincePlayerNotification == 1)
												{
													scenario_0.AddMessage("任务" + mission_.Name + "要求" + Conversions.ToString(mission_.TankerMinNumber_Total) + "加油机总共，但没有一个可用！任务不会启动！", mission_.Name + " 未开始（无加油机！）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
												}
												continue;
											}
											if (num2 < mission_.TankerMinNumber_Total)
											{
												if (mission_.TimeSincePlayerNotification == 1)
												{
													scenario_0.AddMessage("任务" + mission_.Name + "要求" + Conversions.ToString(mission_.TankerMinNumber_Total) + "但总共只有加油机" + Conversions.ToString(num2) + "加油机可用！任务不会启动！", mission_.Name + " 未开始（无足够加油机！）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
												}
												continue;
											}
										}
										if (mission_.TankerMinNumber_Airborne > 0)
										{
											if (num3 == 0)
											{
												if (mission_.TimeSincePlayerNotification == 1)
												{
													scenario_0.AddMessage("任务" + mission_.Name + "要求" + Conversions.ToString(mission_.TankerMinNumber_Airborne) + "空中加油机，但目前没有空中飞行！任务不会启动！", mission_.Name + " 未开始（无加油机起飞！）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
												}
												continue;
											}
											if (num3 < mission_.TankerMinNumber_Airborne)
											{
												if (mission_.TimeSincePlayerNotification == 1)
												{
													scenario_0.AddMessage("任务" + mission_.Name + "要求" + Conversions.ToString(mission_.TankerMinNumber_Airborne) + "然而，空中加油机只是" + Conversions.ToString(num3) + "加油机目前在空中飞行！任务不会启动！", mission_.Name + " 未开始（无足够加油机起飞！）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
												}
												continue;
											}
										}
										if (mission_.TankerMinNumber_Station > 0)
										{
											if (num4 == 0)
											{
												if (mission_.TimeSincePlayerNotification == 1)
												{
													scenario_0.AddMessage("任务" + mission_.Name + "要求" + Conversions.ToString(mission_.TankerMinNumber_Station) + "加油机在巡逻，但目前都不在巡逻！任务不会启动！", mission_.Name + " 未开始（无警戒加油机！）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
												}
												continue;
											}
											if (num4 < mission_.TankerMinNumber_Station)
											{
												if (mission_.TimeSincePlayerNotification == 1)
												{
													scenario_0.AddMessage("任务" + mission_.Name + "要求" + Conversions.ToString(mission_.TankerMinNumber_Station) + "加油机在巡逻，然而只有" + Conversions.ToString(num4) + "加油机目前正在巡逻！任务不会启动！", mission_.Name + " 未开始（无足够警戒加油机！）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
												}
												continue;
											}
										}
									}
								}
							}
							foreach (Aircraft item3 in list_25)
							{
								item3.Kinematics.DetermineReserveFuelQty();
							}
							Mission.Flight.DetermineInitialFlightPlanTimes(ref scenario_0, ref mission_, ref nullable_, ref nullable_2);
							if (!CollectBridge(ref scenario_0, ref side_0, ref mission_, !Information.IsNothing(mission_0), ref list_24, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_8, ref bool_9, ref int_3, ref int_4, ref int_5, ref int_6, ref int_7, ref int_8, ref int_, ref int_11, ref int_12, ref int_13, ref int_14, ref int_15, ref list_25, ref list_15, ref list_16, ref list_17, ref nullable_3, ref bool_13, ref list_2, ref list_3, ref float_, ref float_2, ref string_, ref int_9, ref int_10, !Information.IsNothing(mission_0), nullable_, nullable_2, bool_6: false, ref list_28, !Information.IsNothing(mission_0), int_0))
							{
								continue;
							}
							if (list_15.Count > 0 || ((bool_1 || bool_12) && (list_16.Count > 0 || list_17.Count > 0)))
							{
								if (mission_.MissionClass == Mission._MissionClass.Strike)
								{
									List<Mission.Flight> list = new List<Mission.Flight>();
									foreach (Aircraft item4 in list_24)
									{
										if (item4.Navigator.GetFlight() != null && !list.Contains(item4.Navigator.GetFlight()))
										{
											list.Add(item4.Navigator.GetFlight());
										}
									}
									mission_.FlightList = list;
									Strike strike = (Strike)mission_;
									if ((strike.MaxFlightNumber_Strike == Mission._FlightQty.NoPreferences) | (mission_.FlightList.Count < Mission.FlightQty_To_ActualFlightQty(ref strike.MaxFlightNumber_Strike)))
									{
										bool bool_4 = !Information.IsNothing(mission_0);
										bool bool_5 = !Information.IsNothing(mission_0);
										Mission.Flight flight_2 = null;
										if (!CloneInvocation(ref scenario_0, ref side_0, ref mission_, bool_4, ref list_24, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_8, ref bool_9, ref int_3, ref int_4, ref int_5, ref int_6, ref int_7, ref int_8, ref list_15, ref list_16, ref list_17, ref nullable_3, ref bool_13, ref list_2, ref float_, ref float_2, bool_2, ref list_, ref list_12, ref list_22, ref list_23, ref list_28, ref list_11, ref string_, double_, ref bool_12, bool_1, bool_5, bool_9: false, ref flight_2, !Information.IsNothing(mission_0)))
										{
											continue;
										}
									}
								}
								else
								{
									bool bool_6 = !Information.IsNothing(mission_0);
									bool bool_7 = !Information.IsNothing(mission_0);
									Mission.Flight flight_3 = null;
									if (!CloneInvocation(ref scenario_0, ref side_0, ref mission_, bool_6, ref list_24, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_8, ref bool_9, ref int_3, ref int_4, ref int_5, ref int_6, ref int_7, ref int_8, ref list_15, ref list_16, ref list_17, ref nullable_3, ref bool_13, ref list_2, ref float_, ref float_2, bool_2, ref list_, ref list_12, ref list_22, ref list_23, ref list_28, ref list_11, ref string_, double_, ref bool_12, bool_1, bool_7, bool_9: false, ref flight_3, !Information.IsNothing(mission_0)))
									{
										continue;
									}
								}
							}
						}
					}
					if (bool_3 && mission_.MissionClass == Mission._MissionClass.Strike)
					{
						CalcBridge(ref scenario_0, ref side_0, ref mission_, ref list_, ref list_12, ref list_22, ref list_23, double_, ref bool_12, bool_2: false, bool_3: true);
					}
					if (bool_3 && (mission_.MissionClass == Mission._MissionClass.Patrol || mission_.MissionClass == Mission._MissionClass.Support))
					{
						ForgotBridge(ref scenario_0, ref side_0, ref mission_, double_);
					}
					if (list_5.Count > 0)
					{
						List<ActiveUnit> list_18 = new List<ActiveUnit>();
						List<ActiveUnit> list_19 = new List<ActiveUnit>();
						List<ActiveUnit> list_20 = new List<ActiveUnit>();
						List<ActiveUnit> list_21 = new List<ActiveUnit>();
						if (DestroyInvocation(ref scenario_0, ref side_0, mission_, !Information.IsNothing(mission_0), ref list_18, ref list_19, ref list_20, ref list_21, ref _GroupSize_, ref _GroupSize_2, ref bool_10, ref bool_11, ref list_4, ref list_5, ref list_6) && list_18.Count > 0)
						{
							ComputeInvocation(ref scenario_0, ref side_0, mission_, !Information.IsNothing(mission_0), ref list_18, ref list_19, ref list_20, ref list_21, ref _GroupSize_, ref _GroupSize_2, ref bool_10, ref bool_11, ref list_7);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101246", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void CalcBridge(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref List<Group> list_0, ref List<Aircraft> list_1, ref List<Aircraft> list_2, ref List<Aircraft> list_3, double double_0, ref bool bool_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (!mission_0.RestartValue())
			{
				return;
			}
			Mission obj = mission_0;
			Scenario scenario_ = scenario_0;
			bool flag = false;
			obj.FillEmptySlots(scenario_, ref side_0, ref flag, null, bool_1: true);
			int count = mission_0.FlightList.Count;
			List<Mission.Flight> list = new List<Mission.Flight>();
			list_0.Clear();
			list_1.Clear();
			list_2.Clear();
			list_3.Clear();
			if (bool_2)
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				for (int i = count - 1; i >= 0; i += -1)
				{
					Mission.Flight flight_ = mission_0.FlightList[i];
					ActiveUnit activeUnit = scenario_0.ActiveUnits[flight_.TakeOffLocation_HostUnitObjectID];
					if (flight_.HasCriticalError)
					{
						Geopoint_Struct geopoint_Struct_ = default(Geopoint_Struct);
						if (activeUnit != null)
						{
							geopoint_Struct_ = new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude());
						}
						scenario_0.AddMessage("飞行编队" + flight_.Callsign + "在任务上" + mission_0.Name + "来自" + flight_.TakeOffLocation_HostUnitObjectName + "，飞机类型" + flight_.ReferenceUnit_Name + "和挂载类型" + flight_.GetLoadoutName(scenario_0) + "有一个或多个飞行计划错误，不能起飞！", flight_.Callsign + " 无法起飞（飞行计划错误）", LoggedMessage.MessageType.AirOps, 0, null, side_0, geopoint_Struct_);
					}
					else
					{
						if (flight_.Task == Mission._FlightTask.QRA || flight_.IsEscort || flight_.GetIsActive(flight_.GetAUCurrentlyAssigned(mission_0, scenario_0)))
						{
							continue;
						}
						double num;
						if (!Information.IsNothing(flight_.FlightPlan) && flight_.FlightPlan.Count() > 0)
						{
							Waypoint waypoint = flight_.FlightPlan[0];
							if ((Information.IsNothing(waypoint.Time_Zulu) & mission_0.TimeOnTarget.HasValue) | mission_0.TakeOffTime.HasValue)
							{
								Mission.Flight flight = flight_;
								Waypoint[] waypoint_ = flight.FlightPlan;
								Mission.Flight flight2 = flight_;
								Scenario scenario_2;
								ActiveUnit activeUnit_ = flight2.GetReferenceUnit(scenario_2 = scenario_0);
								MissionPlanner.DetermineWaypointZuluTimes(ref scenario_0, ref mission_0, ref flight_, ref waypoint_, ref activeUnit_, bool_0: false, bool_1: true, bool_2: false, mission_0.TakeOffTime, mission_0.TimeOnTarget, Mission.Flight.FlightElement.LeadElement);
								flight2.SetReferenceUnit(scenario_2, activeUnit_);
								flight.FlightPlan = waypoint_;
								waypoint = flight_.FlightPlan[0];
							}
							if (Information.IsNothing(waypoint.Time_Zulu))
							{
								num = -1.0;
							}
							else
							{
								double totalSeconds = (waypoint.Time_Zulu.Value - scenario_0.Time).TotalSeconds;
								if (activeUnit != null)
								{
									double_ = activeUnit.GetLatitude();
									double_2 = activeUnit.GetLongitude();
								}
								if (totalSeconds < -300.0)
								{
									list.Add(flight_);
									scenario_0.AddMessage("飞行编队" + flight_.Callsign + "在任务上" + mission_0.Name + "来自" + flight_.TakeOffLocation_HostUnitObjectName + "，飞机类型" + flight_.ReferenceUnit_Name + "和挂载类型" + flight_.GetLoadoutName(scenario_0) + "超过预定的起飞时间5分钟。该编队已被取消。", flight_.Callsign + " 已取消", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(double_2, double_));
									continue;
								}
								if (totalSeconds < 0.0 - double_0 - 60.0)
								{
									scenario_0.AddMessage("飞行编队" + flight_.Callsign + "在任务上" + mission_0.Name + "来自" + flight_.TakeOffLocation_HostUnitObjectName + "，飞机类型" + flight_.ReferenceUnit_Name + "和挂载类型" + flight_.GetLoadoutName(scenario_0) + "计划起飞，但有些事情已经发生了变化。编队将在预定的起飞时间后5分钟取消。", flight_.Callsign + " 已延迟，可能取消", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(double_2, double_));
								}
								num = totalSeconds - double_0 - 60.0;
							}
						}
						else
						{
							num = ((mission_0 == null || !mission_0.TakeOffTime.HasValue) ? (-1.0) : ((mission_0.TakeOffTime.Value - scenario_0.Time).TotalSeconds - double_0));
						}
						if (mission_0.UseFlightSizeHardLimit)
						{
							mission_0.ResetFlightReadyAicraftCount(scenario_0, flight_);
							if (flight_.ReadyAircraftQty < flight_.MinimumAircraftQty)
							{
								continue;
							}
						}
						if (!(num < 0.0))
						{
							continue;
						}
						List<ActiveUnit> list2 = new List<ActiveUnit>();
						foreach (ActiveUnit unit in side_0.Units)
						{
							if (!Information.IsNothing(unit.AssignedMissionOrPackage()) && !Information.IsNothing(unit.Navigator.GetFlight()) && flight_ == unit.Navigator.GetFlight() && unit.IsAircraft && !unit.IsOperating())
							{
								Aircraft aircraft = (Aircraft)unit;
								string string_ = null;
								if (aircraft.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable && aircraft.IsParkedAndReady())
								{
									list2.Add(unit);
									list_1.Add((Aircraft)unit);
								}
							}
						}
						if (list2.Count == 0)
						{
							continue;
						}
						if (list2.Count > 0)
						{
							if (list2.Count < flight_.MinimumAircraftQty)
							{
								foreach (ActiveUnit item in list2)
								{
									list_1.Remove((Aircraft)item);
								}
								if (mission_0.TimeSincePlayerNotification == 1)
								{
									scenario_0.AddMessage("飞行编队" + flight_.Callsign + "要求最低" + flight_.MinimumAircraftQty.value + "飞机，然而只有" + Conversions.ToString(list2.Count) + "准备好起飞！编队不会起飞！", flight_.Callsign + " 未开始（无足够飞机就绪！）", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
								}
								continue;
							}
							if (list2.Count <= 1)
							{
								Mission.Flight flight3 = list2[0].Navigator.GetFlight();
								list2[0].SetFlight(flight3, 1);
							}
							else
							{
								list2 = list2.OrderBy((ActiveUnit theAc) => !theAc.Navigator.HasFlight).ToList();
								Mission.Flight flight4 = list2[0].Navigator.GetFlight();
								Group group = new Group(ref scenario_0, ref side_0, list2, bool_0: true, null, mission_0);
								list_0.Add(group);
								int num2 = 2;
								foreach (ActiveUnit value in group.Units.Values)
								{
									if (value.IsGroupLead())
									{
										value.SetFlight(flight4, 1);
										group.Name = "飞行编队" + flight4.Callsign;
									}
									else
									{
										value.SetFlight(flight4, num2);
										num2++;
									}
								}
							}
						}
						bool_1 = true;
					}
				}
			}
			if (bool_3)
			{
				for (int j = count - 1; j >= 0; j += -1)
				{
					Mission.Flight flight5 = mission_0.FlightList[j];
					ActiveUnit activeUnit2 = scenario_0.ActiveUnits[flight5.TakeOffLocation_HostUnitObjectID];
					if (flight5.HasCriticalError)
					{
						scenario_0.AddMessage("飞行编队" + flight5.Callsign + "在任务上" + mission_0.Name + "来自" + flight5.TakeOffLocation_HostUnitObjectName + "，飞机类型" + flight5.ReferenceUnit_Name + "和挂载类型" + flight5.GetLoadoutName(scenario_0) + "有一个或多个飞行计划错误，不能起飞！", flight5.Callsign + " 未开始（飞行计划错误！）", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
					}
					else
					{
						if (flight5.Task == Mission._FlightTask.QRA || !flight5.IsEscort || flight5.GetIsActive(flight5.GetAUCurrentlyAssigned(mission_0, scenario_0)))
						{
							continue;
						}
						double num3;
						if (!Information.IsNothing(flight5.FlightPlan) && flight5.FlightPlan.Count() > 0)
						{
							Waypoint waypoint2 = flight5.FlightPlan[0];
							if (Information.IsNothing(waypoint2.Time_Zulu))
							{
								num3 = (bool_1 ? (-1.0) : double.MaxValue);
							}
							else
							{
								double totalSeconds2 = (waypoint2.Time_Zulu.Value - scenario_0.Time).TotalSeconds;
								if (totalSeconds2 < -300.0)
								{
									list.Add(flight5);
									scenario_0.AddMessage("飞行编队" + flight5.Callsign + "在任务上" + mission_0.Name + "来自" + flight5.TakeOffLocation_HostUnitObjectName + "，飞机类型" + flight5.ReferenceUnit_Name + "和挂载类型" + flight5.GetLoadoutName(scenario_0) + "超过预定的起飞时间5分钟。该编队已被取消。", flight5.Callsign + " 已取消（迟到五分钟）", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
									continue;
								}
								if (totalSeconds2 < 0.0 - double_0 - 60.0)
								{
									scenario_0.AddMessage("飞行编队" + flight5.Callsign + "在任务上" + mission_0.Name + "来自" + flight5.TakeOffLocation_HostUnitObjectName + "，飞机类型" + flight5.ReferenceUnit_Name + "和挂载类型" + flight5.GetLoadoutName(scenario_0) + "计划起飞，但有些事情已经发生了变化。编队将在预定的起飞时间后5分钟取消。", flight5.Callsign + " 已延迟（五分钟警告）", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
								}
								num3 = totalSeconds2 - double_0 - 60.0;
							}
						}
						else
						{
							num3 = (bool_1 ? (-1.0) : double.MaxValue);
						}
						if (!(flight5.ReadyAircraftQty >= flight5.MinimumAircraftQty) || !(num3 < 0.0))
						{
							continue;
						}
						List<ActiveUnit> list3 = new List<ActiveUnit>();
						foreach (ActiveUnit unit2 in side_0.Units)
						{
							if (Information.IsNothing(unit2.AssignedMissionOrPackage()) || Information.IsNothing(unit2.Navigator.GetFlight()) || flight5 != unit2.Navigator.GetFlight() || !unit2.IsAircraft || unit2.IsOperating())
							{
								continue;
							}
							Aircraft aircraft2 = (Aircraft)unit2;
							string string_2 = null;
							if (aircraft2.IsAvailableForOps(ref string_2) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable && aircraft2.IsParkedAndReady())
							{
								list3.Add(unit2);
								if (aircraft2.Loadout.IsSupportOrPatrol)
								{
									list_3.Add(aircraft2);
								}
								else
								{
									list_2.Add(aircraft2);
								}
							}
						}
						if (list3.Count == 0 || list3.Count <= 0)
						{
							continue;
						}
						if (list3.Count < flight5.MinimumAircraftQty)
						{
							foreach (ActiveUnit item2 in list3)
							{
								if (((Aircraft)item2).Loadout.IsSupportOrPatrol)
								{
									list_3.Remove((Aircraft)item2);
								}
								else
								{
									list_2.Remove((Aircraft)item2);
								}
							}
							if (mission_0.TimeSincePlayerNotification == 1)
							{
								scenario_0.AddMessage("飞行编队" + flight5.Callsign + "要求最低" + flight5.MinimumAircraftQty.value + "飞机，然而只有" + Conversions.ToString(list3.Count) + "准备好起飞！该编队不会起飞！", flight5.Callsign + " 未开始（无足够飞机就绪！）", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
							}
							continue;
						}
						Mission.Flight flight6 = list3[0].Navigator.GetFlight();
						if (list3.Count <= 1)
						{
							list3[0].SetFlight(flight6, 1);
							continue;
						}
						Group group2 = new Group(ref scenario_0, ref side_0, list3, bool_0: true, null, mission_0);
						list_0.Add(group2);
						int num4 = 2;
						foreach (ActiveUnit value2 in group2.Units.Values)
						{
							if (value2.IsGroupLead())
							{
								value2.SetFlight(flight6, 1);
								group2.Name = "飞行编队" + flight6.Callsign;
							}
							else
							{
								value2.SetFlight(flight6, num4);
								num4++;
							}
						}
					}
				}
			}
			foreach (Mission.Flight item3 in list)
			{
				Mission.Flight flight_2 = item3;
				mission_0.DeleteFlight(ref scenario_0, ref side_0, ref flight_2, flight_2.ObjectID);
			}
			mission_0.OrderAircraftToTakeOff(ref scenario_0, list_0, list_1, list_2, list_3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void RateBridge(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, double double_0, bool bool_2, bool bool_3)
	{
		try
		{
			List<Aircraft> list_ = new List<Aircraft>();
			List<Aircraft> list_12 = new List<Aircraft>();
			List<ActiveUnit> list_23 = new List<ActiveUnit>();
			List<int> list_24 = new List<int>();
			List<int> list_25 = new List<int>();
			List<Mission.ContinousCoverageStation> list = null;
			Mission._ContinousCoverageMethod continousCoverageMethod = Mission._ContinousCoverageMethod.Dynamic;
			Mission._ContinousCoverageStationTime continousCoverageStationTime_ = Mission._ContinousCoverageStationTime.min_15;
			Mission._ContinousCoverageOverlap continousCoverageOverlap_ = Mission._ContinousCoverageOverlap.None;
			Mission._ContinousCoverageDuration continousCoverageDuration_ = Mission._ContinousCoverageDuration.hr_2;
			int int_ = 0;
			bool bool_8 = false;
			if (mission_0.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol obj = (Patrol)mission_0;
				list = obj.ContinousCoverage_Stations;
				continousCoverageMethod = obj.ContinousCoverage_FlightGenerationMethod;
				continousCoverageStationTime_ = obj.ContinousCoverage_StationTime;
				continousCoverageOverlap_ = obj.ContinousCoverage_Overlap;
				continousCoverageDuration_ = obj.ContinousCoverage_Duration;
				int_ = obj.MinimumNumberOnStation;
				bool_8 = obj.OneThirdRule;
			}
			if (mission_0.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission obj2 = (SupportMission)mission_0;
				list = obj2.ContinousCoverage_Stations;
				continousCoverageMethod = obj2.ContinousCoverage_FlightGenerationMethod;
				continousCoverageStationTime_ = obj2.ContinousCoverage_StationTime;
				continousCoverageOverlap_ = obj2.ContinousCoverage_Overlap;
				continousCoverageDuration_ = obj2.ContinousCoverage_Duration;
				int_ = obj2.MinimumNumberOnStation;
				bool_8 = obj2.OneThirdRule;
			}
			switch (continousCoverageMethod)
			{
			case Mission._ContinousCoverageMethod.FlightplanTemplates:
			{
				Mission._FlightSize _FlightSize_4 = mission_0.FlightSize;
				bool bool_13 = mission_0.UseFlightSizeHardLimit;
				int int_10 = 0;
				List<Mission.Flight> list5 = new List<Mission.Flight>();
				List<Mission.Flight> list6 = new List<Mission.Flight>();
				foreach (Mission.Flight flight7 in mission_0.FlightList)
				{
					if (flight7.Task == Mission._FlightTask.QRA)
					{
						continue;
					}
					if (flight7.Type == Mission._FlightType.FlightplanTemplate)
					{
						if (!Information.IsNothing(flight7.FlightPlan) && flight7.FlightPlan.Count() != 0)
						{
							bool flag3 = false;
							bool flag4 = true;
							Waypoint[] flightPlan2 = flight7.FlightPlan;
							Waypoint[] array3 = flightPlan2;
							foreach (Waypoint waypoint6 in array3)
							{
								if (waypoint6.IncludeReponse())
								{
									flag3 = true;
								}
								if (waypoint6.EnableReponse() && waypoint6.Station_Time <= 0f)
								{
									ResolveBridge("飞行计划" + flight7.Callsign + "没有设定巡逻时间！", side_0);
									flag4 = false;
								}
							}
							if (flag4)
							{
								if (flag3)
								{
									list5.Add(flight7);
								}
								else
								{
									ResolveBridge("飞行计划" + flight7.Callsign + " 无警戒开始/结束路径点！对于持续覆盖模板飞行计划必须有警戒路径点。", side_0);
								}
							}
						}
						else
						{
							ResolveBridge("飞行计划" + flight7.Callsign + "没有航点！添加航点并再试一次。", side_0);
						}
					}
					else
					{
						list6.Add(flight7);
					}
				}
				if (list5.Count <= 0)
				{
					ResolveBridge("没有有效的飞行计划模板用于此任务。创建一个或多个飞行计划模板并重试。", side_0);
					break;
				}
				List<Mission.ContinousCoverageStation> list7 = null;
				if (list6.Count == 0 && !Information.IsNothing(list))
				{
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						((Patrol)mission_0).ContinousCoverage_Stations.Clear();
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						((SupportMission)mission_0).ContinousCoverage_Stations.Clear();
					}
				}
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					list7 = list.ToList();
				}
				int count5;
				if (!Information.IsNothing(list7))
				{
					int count4 = list7.Count;
					count5 = list6.Count;
					for (int num2 = count4 - 1; num2 >= 0; num2 += -1)
					{
						Mission.ContinousCoverageStation continousCoverageStation5 = list7[num2];
						bool flag5 = false;
						for (int num3 = count5 - 1; num3 >= 0; num3 += -1)
						{
							if (Operators.CompareString(list6[num3].ObjectID, continousCoverageStation5.FlightObjectID, TextCompare: false) == 0)
							{
								flag5 = true;
								break;
							}
						}
						if (!flag5)
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
							}
						}
					}
				}
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					list7 = list.ToList();
				}
				int count6 = list5.Count;
				count5 = ((!Information.IsNothing(list7)) ? list7.Count : 0);
				string string_2 = null;
				for (int num4 = count6 - 1; num4 >= 0; num4 += -1)
				{
					Mission.Flight flight3 = list5[num4];
					bool flag6 = false;
					if (!Information.IsNothing(list7))
					{
						for (int num5 = count5 - 1; num5 >= 0; num5 += -1)
						{
							Mission.ContinousCoverageStation continousCoverageStation6 = list7[num5];
							if (Operators.CompareString(flight3.ObjectID, continousCoverageStation6.FlightplanTemplateObjectID, TextCompare: false) == 0)
							{
								flag6 = true;
								break;
							}
						}
					}
					if (flag6)
					{
						continue;
					}
					int int_11;
					int int_13;
					if (Information.IsNothing(flight3.GetReferenceUnit(scenario_0)))
					{
						int_11 = flight3.ReferenceUnit_DBID;
						int_13 = flight3.int_0;
						string_2 = flight3.TakeOffLocation_HostUnitObjectID;
					}
					else
					{
						Aircraft aircraft6 = (Aircraft)flight3.GetReferenceUnit(scenario_0);
						int_11 = aircraft6.DBID;
						int_13 = aircraft6.Int32_0;
						if (Information.IsNothing(aircraft6.AirOps.CurrentHostUnit))
						{
							if (!Information.IsNothing(aircraft6.AirOps.GetAssignedHostUnit()))
							{
								string_2 = aircraft6.AirOps.GetAssignedHostUnit().ObjectID;
							}
						}
						else
						{
							string_2 = aircraft6.AirOps.CurrentHostUnit.ObjectID;
						}
					}
					Mission.ContinousCoverageStation item4 = new Mission.ContinousCoverageStation("", int_11, int_13, string_2, scenario_0.Time, scenario_0.Time, flight3.ObjectID);
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol patrol2 = (Patrol)mission_0;
						if (Information.IsNothing(patrol2.ContinousCoverage_Stations))
						{
							patrol2.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
						}
						patrol2.ContinousCoverage_Stations.Add(item4);
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						SupportMission supportMission2 = (SupportMission)mission_0;
						if (Information.IsNothing(supportMission2.ContinousCoverage_Stations))
						{
							supportMission2.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
						}
						supportMission2.ContinousCoverage_Stations.Add(item4);
					}
				}
				if (mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					list = ((Patrol)mission_0).ContinousCoverage_Stations;
				}
				if (mission_0.MissionClass == Mission._MissionClass.Support)
				{
					list = ((SupportMission)mission_0).ContinousCoverage_Stations;
				}
				DateTime t2 = scenario_0.Time.AddHours(mission_0.InsertValue(continousCoverageDuration_));
				double value4 = 0.0;
				Waypoint waypoint7 = null;
				Waypoint waypoint8 = null;
				for (int num6 = list.Count - 1; num6 >= 0; num6 += -1)
				{
					Mission.ContinousCoverageStation continousCoverageStation7 = list[num6];
					DateTime? stationStartTime2 = continousCoverageStation7.StationStartTime;
					if (!(stationStartTime2.HasValue ? new bool?(DateTime.Compare(stationStartTime2.GetValueOrDefault(), t2) < 0) : null).GetValueOrDefault())
					{
						continue;
					}
					if (Information.IsNothing(continousCoverageStation7.HostUnitObjectID))
					{
						list.Remove(continousCoverageStation7);
						continue;
					}
					int int_14 = 0;
					Doctrine._UseUnderwayRefuelAndReplenishment? nullable_2 = mission_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					string string_3 = "";
					if (scenario_0.ActiveUnits.ContainsKey(continousCoverageStation7.HostUnitObjectID))
					{
						ActiveUnit activeUnit_2 = scenario_0.ActiveUnits[continousCoverageStation7.HostUnitObjectID];
						if (Information.IsNothing(activeUnit_2))
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							continue;
						}
						Mission.Flight flight_4 = null;
						foreach (Mission.Flight flight8 in mission_0.FlightList)
						{
							if (Operators.CompareString(flight8.ObjectID, continousCoverageStation7.FlightplanTemplateObjectID, TextCompare: false) == 0)
							{
								flight_4 = flight8;
							}
						}
						if (Information.IsNothing(flight_4))
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							continue;
						}
						if (Information.IsNothing(list_23))
						{
							list_23 = new List<ActiveUnit>();
						}
						list_23.Clear();
						list_23.Add(activeUnit_2);
						int int_15 = continousCoverageStation7.int_0;
						if (Information.IsNothing(list_24))
						{
							list_24 = new List<int>();
						}
						list_24.Clear();
						list_24.Add(int_15);
						DateTime dateTime4 = continousCoverageStation7.StationEndTime.Value;
						bool bool_4 = true;
						Mission.Flight flight4 = null;
						while (true)
						{
							List<Aircraft> list8 = new List<Aircraft>();
							List<Mission.EmptyAircraftSlot> list9 = new List<Mission.EmptyAircraftSlot>();
							int num7 = 1;
							int value5 = _FlightSize_4.value;
							for (int num8 = 1; num8 <= value5; num8++)
							{
								Mission obj7 = mission_0;
								int aircraftDBID2 = continousCoverageStation7.AircraftDBID;
								int int_16 = continousCoverageStation7.int_0;
								Mission.Flight flight_5 = null;
								Aircraft aircraft7 = obj7.CancelValue(ref scenario_0, ref side_0, aircraftDBID2, int_16, ref activeUnit_2, ref flight_5, bool_0: false, num7);
								Mission.EmptyAircraftSlot item5 = new Mission.EmptyAircraftSlot(aircraft7, aircraft7.DBID, aircraft7.UnitClass, aircraft7.Int32_0, aircraft7.LoadoutName, ref activeUnit_2, activeUnit_2.ObjectID, activeUnit_2.Name, bool_0: false);
								list8.Add(aircraft7);
								list9.Add(item5);
								num7++;
							}
							List<Aircraft> list_15 = list8.ToList();
							flight4 = null;
							Mission.Flight flight_6 = new Mission.Flight();
							Mission.Flight flight5 = flight_4;
							Mission mission_ = null;
							int int_17 = 0;
							int int_18 = 0;
							flight5.Copy(ref scenario_0, ref flight_4, ref flight_6, bool_0: false, ref mission_, ref int_17, ref int_18, bool_1: false, bool_2: false);
							flight_6.Type = Mission._FlightType.Flightplan;
							mission_0.MasterFlightList.Clear();
							mission_0.MasterFlightList.Add(flight_6);
							flight_4.UsedByFlight = false;
							if (list_15.Count > 0)
							{
								Mission._FlightSize _FlightSize_5 = 0;
								Mission._FlightSize _FlightSize_6 = 0;
								bool bool_5 = false;
								int_18 = 0;
								int_17 = 0;
								int int_19 = 0;
								int int_20 = 0;
								List<Aircraft> list_16 = new List<Aircraft>();
								List<Aircraft> list_17 = new List<Aircraft>();
								bool bool_6 = false;
								float float_3 = 0f;
								float float_4 = 0f;
								List<Group> list_18 = null;
								List<Aircraft> list_19 = null;
								List<Aircraft> list_20 = null;
								List<Aircraft> list_21 = null;
								List<Aircraft> list_22 = new List<Aircraft>();
								bool bool_7 = false;
								if (CloneInvocation(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_, ref _FlightSize_4, ref _FlightSize_5, ref _FlightSize_6, ref bool_13, ref bool_5, ref int_14, ref int_10, ref int_18, ref int_17, ref int_19, ref int_20, ref list_15, ref list_16, ref list_17, ref nullable_2, ref bool_6, ref list_24, ref float_3, ref float_4, bool_5: false, ref list_18, ref list_19, ref list_20, ref list_21, ref list_23, ref list_22, ref string_3, double_0, ref bool_7, bool_7: false, bool_2, bool_4, ref flight4, bool_3))
								{
									if (!Information.IsNothing(flight4))
									{
										if (!Information.IsNothing(flight4.FlightPlan) && flight4.FlightPlan.Count() != 0)
										{
											int num9 = mission_0.ReadValue(continousCoverageOverlap_);
											Waypoint[] flightPlan = flight4.FlightPlan;
											Waypoint[] array4 = flightPlan;
											foreach (Waypoint waypoint9 in array4)
											{
												if (waypoint9.EnableReponse())
												{
													value4 = waypoint9.Station_Time;
													break;
												}
											}
											DateTime dateTime5 = dateTime4;
											DateTime date2 = dateTime5.Date;
											TimeSpan value6 = TimeSpan.FromMinutes(Math.Floor((dateTime5.TimeOfDay.TotalMinutes + 2.5) / 5.0) * 5.0);
											dateTime4 = date2.Add(value6);
											DateTime dateTime6 = dateTime4.AddSeconds(value4);
											dateTime4 = dateTime4.AddMinutes(-num9);
											if (Information.IsNothing(mission_0.EmptySlotsList))
											{
												mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
											}
											foreach (Mission.EmptyAircraftSlot item6 in list9)
											{
												item6.SetMissionFlight(scenario_0, flight4);
												item6.MissionFlight_ObjectID = flight4.ObjectID;
												item6.SetCurrentHostUnit(scenario_0, activeUnit_2);
												item6.CurrentHostUnit_ObjectID = activeUnit_2.ObjectID;
												item6.CurrentHostUnit_Name = activeUnit_2.Name;
												item6.MissionFlight_ObjectID = flight4.ObjectID;
												mission_0.EmptySlotsList.Add(item6);
											}
											flightPlan = flight4.FlightPlan;
											Waypoint[] array5 = flightPlan;
											foreach (Waypoint waypoint10 in array5)
											{
												if (waypoint10.SearchReponse())
												{
													waypoint7 = waypoint10;
												}
												else if (waypoint10.EnableReponse())
												{
													waypoint8 = waypoint10;
													break;
												}
											}
											if (!Information.IsNothing(waypoint7))
											{
												if (!Information.IsNothing(waypoint8))
												{
													waypoint7.Time_Zulu = dateTime4;
													waypoint7.TimeFixed = Waypoint.FixedFree.Fixed;
													waypoint8.Time_Zulu = dateTime6;
													waypoint8.TimeFixed = Waypoint.FixedFree.Fixed;
													Scenario scenario_4 = scenario_0;
													Mission strike_3 = mission_0;
													ActiveUnit referenceUnit3 = flight4.GetReferenceUnit(scenario_0);
													Mission.Flight flight_7 = flight4;
													Mission.Flight flight6;
													Waypoint[] waypoint_3 = (flight6 = flight4).FlightPlan;
													float_4 = 0f;
													float_3 = 0f;
													MissionPlanner.ConnectTokenizer(scenario_4, strike_3, referenceUnit3, flight_7, ref waypoint_3, ref float_4, ref float_3, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: true);
													flight6.FlightPlan = waypoint_3;
													while (true)
													{
														stationStartTime2 = flight4.FlightPlan[0].Time_Zulu;
														DateTime time2 = scenario_0.Time;
														if (!((!stationStartTime2.HasValue) ? null : new bool?(DateTime.Compare(stationStartTime2.GetValueOrDefault(), time2) < 0)).GetValueOrDefault())
														{
															break;
														}
														TimeSpan value7 = TimeSpan.FromMinutes(Math.Floor(((scenario_0.Time - flight4.FlightPlan[0].Time_Zulu.Value).TotalMinutes + 2.5) / 5.0) * 5.0 + 5.0);
														dateTime4 = dateTime4.Add(value7);
														dateTime6 = dateTime6.Add(value7);
														waypoint_3 = flight4.FlightPlan;
														flightPlan = waypoint_3;
														Waypoint[] array6 = flightPlan;
														foreach (Waypoint waypoint2 in array6)
														{
															if (waypoint2.SearchReponse())
															{
																waypoint2.Time_Zulu = dateTime4;
															}
															else if (waypoint2.EnableReponse())
															{
																waypoint2.Time_Zulu = dateTime6;
																break;
															}
														}
														Scenario scenario_5 = scenario_0;
														Mission strike_4 = mission_0;
														ActiveUnit referenceUnit4 = flight4.GetReferenceUnit(scenario_0);
														Mission.Flight flight_8 = flight4;
														Waypoint[] waypoint_4 = (flight6 = flight4).FlightPlan;
														float_3 = 0f;
														float_4 = 0f;
														MissionPlanner.ConnectTokenizer(scenario_5, strike_4, referenceUnit4, flight_8, ref waypoint_4, ref float_3, ref float_4, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: true);
														flight6.FlightPlan = waypoint_4;
													}
													if (DateTime.Compare(dateTime4, t2) <= 0)
													{
														dateTime4 = dateTime6;
														continue;
													}
													Mission.ContinousCoverageStation continousCoverageStation8 = new Mission.ContinousCoverageStation(flight4.ObjectID, flight4.ReferenceUnit_DBID, flight4.int_0, activeUnit_2.ObjectID, dateTime4, dateTime6, continousCoverageStation7.FlightplanTemplateObjectID);
													if (!Information.IsNothing(continousCoverageStation8))
													{
														if (mission_0.MissionClass == Mission._MissionClass.Patrol)
														{
															Patrol obj8 = (Patrol)mission_0;
															obj8.ContinousCoverage_Stations.Remove(continousCoverageStation7);
															obj8.ContinousCoverage_Stations.Add(continousCoverageStation8);
														}
														if (mission_0.MissionClass == Mission._MissionClass.Support)
														{
															SupportMission obj9 = (SupportMission)mission_0;
															obj9.ContinousCoverage_Stations.Remove(continousCoverageStation7);
															obj9.ContinousCoverage_Stations.Add(continousCoverageStation8);
														}
													}
													break;
												}
												if (mission_0.MissionClass == Mission._MissionClass.Patrol)
												{
													((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
												}
												if (mission_0.MissionClass == Mission._MissionClass.Support)
												{
													((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
												}
												break;
											}
											if (mission_0.MissionClass == Mission._MissionClass.Patrol)
											{
												((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
											}
											if (mission_0.MissionClass == Mission._MissionClass.Support)
											{
												((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
											}
											break;
										}
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										if (mission_0.MissionClass == Mission._MissionClass.Patrol)
										{
											((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
										}
										if (mission_0.MissionClass == Mission._MissionClass.Support)
										{
											((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
										}
										break;
									}
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									if (mission_0.MissionClass == Mission._MissionClass.Patrol)
									{
										((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
									}
									if (mission_0.MissionClass == Mission._MissionClass.Support)
									{
										((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
									}
									break;
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
								}
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
							}
							break;
						}
					}
					else
					{
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation7);
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				break;
			}
			case Mission._ContinousCoverageMethod.Dynamic:
			{
				Mission obj3 = mission_0;
				Scenario scenario_ = scenario_0;
				List<Aircraft> list_26 = null;
				List<Aircraft> list_27 = null;
				int int_12 = 0;
				int int_21 = 0;
				int int_22 = 0;
				int int_23 = 0;
				int int_24 = 0;
				int int_25 = 0;
				List<int> list_28 = null;
				List<ActiveUnit> list_29 = null;
				List<ActiveUnit> list_2 = null;
				List<Aircraft> list_3 = new List<Aircraft>();
				List<Aircraft> list_4 = new List<Aircraft>();
				List<Aircraft> list_5 = new List<Aircraft>();
				int int_26 = 0;
				int int_27 = 0;
				int int_2 = 0;
				List<Mission.Flight> list_6 = null;
				List<Mission.Flight> list_7 = null;
				List<Mission.Flight> list_8 = null;
				obj3.UnitsAssignedToMission_SeparatedByType(scenario_, ref list_24, ref list_25, ref list_, ref list_12, ref list_26, ref list_27, ref list_23, ref int_12, ref int_21, ref int_22, ref int_23, ref int_24, ref int_25, ref list_28, ref list_29, ref list_2, null, ref list_3, ref list_4, ref list_5, ref int_26, ref int_27, ref int_2, ref list_6, ref list_7, ref list_8, bool_0: false, bool_1: false, bool_2: true);
				List<Aircraft> list_9 = new List<Aircraft>();
				Mission._FlightSize _FlightSize_ = mission_0.FlightSize;
				bool bool_9 = mission_0.UseFlightSizeHardLimit;
				int int_3 = 0;
				OrderBridge(bool_1: true, ref list_9, bool_8, int_, ref list_23, ref list_25, ref list_, ref list_24, ref list_12, ref _FlightSize_, ref bool_9);
				if (list_9.Count <= 0)
				{
					break;
				}
				List<Mission.Flight> list2 = new List<Mission.Flight>();
				foreach (Mission.Flight flight9 in mission_0.FlightList)
				{
					if (flight9.Task != Mission._FlightTask.QRA && flight9.Type != Mission._FlightType.FlightplanTemplate)
					{
						list2.Add(flight9);
					}
				}
				List<Mission.ContinousCoverageStation> list3 = null;
				if (list2.Count == 0 && !Information.IsNothing(list))
				{
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						((Patrol)mission_0).ContinousCoverage_Stations.Clear();
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						((SupportMission)mission_0).ContinousCoverage_Stations.Clear();
					}
				}
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					list3 = list.ToList();
				}
				if (!Information.IsNothing(list3))
				{
					int count = list3.Count;
					int count2 = list2.Count;
					for (int i = count - 1; i >= 0; i += -1)
					{
						Mission.ContinousCoverageStation continousCoverageStation = list3[i];
						bool flag = false;
						for (int j = count2 - 1; j >= 0; j += -1)
						{
							if (Operators.CompareString(list2[j].ObjectID, continousCoverageStation.FlightObjectID, TextCompare: false) == 0)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation);
							}
						}
					}
				}
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					list3 = list.ToList();
				}
				if (!Information.IsNothing(list3))
				{
					for (int k = list3.Count - 1; k >= 0; k += -1)
					{
						Mission.ContinousCoverageStation continousCoverageStation2 = list3[k];
						if (Information.IsNothing(continousCoverageStation2.HostUnitObjectID))
						{
							list.Remove(continousCoverageStation2);
							continue;
						}
						if (list_9.Count == 0)
						{
							break;
						}
						int count3 = list_9.Count;
						for (int l = count3 - 1; l >= 0; l += -1)
						{
							Aircraft aircraft = list_9[l];
							int num = mission_0.FlightSize;
							if (continousCoverageStation2.AircraftDBID == aircraft.DBID)
							{
								if (continousCoverageStation2.int_0 == aircraft.Int32_0)
								{
									string text = null;
									if (Information.IsNothing(aircraft.AirOps.CurrentHostUnit))
									{
										if (!Information.IsNothing(aircraft.AirOps.GetAssignedHostUnit()))
										{
											text = aircraft.AirOps.GetAssignedHostUnit().ObjectID;
										}
									}
									else
									{
										text = aircraft.AirOps.CurrentHostUnit.ObjectID;
									}
									if (!Information.IsNothing(text) && Operators.CompareString(continousCoverageStation2.HostUnitObjectID, text, TextCompare: false) == 0)
									{
										list_9.Remove(aircraft);
										count3 = list_9.Count;
										num--;
										if (num > 0)
										{
											_ = list_9.Count;
											for (int m = count3 - 1; m >= 0; m += -1)
											{
												Aircraft aircraft2 = list_9[m];
												if (continousCoverageStation2.AircraftDBID != aircraft2.DBID || continousCoverageStation2.int_0 != aircraft2.Int32_0)
												{
													continue;
												}
												string text2 = null;
												if (Information.IsNothing(aircraft2.AirOps.CurrentHostUnit))
												{
													if (!Information.IsNothing(aircraft2.AirOps.GetAssignedHostUnit()))
													{
														text2 = aircraft2.AirOps.GetAssignedHostUnit().ObjectID;
													}
												}
												else
												{
													text2 = aircraft2.AirOps.CurrentHostUnit.ObjectID;
												}
												if (!Information.IsNothing(text2))
												{
													if (Operators.CompareString(continousCoverageStation2.HostUnitObjectID, text2, TextCompare: false) == 0)
													{
														list_9.Remove(aircraft2);
														l--;
														num--;
														if (num == 0)
														{
															break;
														}
													}
													continue;
												}
												list_9.Remove(aircraft);
												break;
											}
										}
										if (num == 0)
										{
											break;
										}
									}
								}
								else
								{
									list_9.Remove(aircraft);
								}
							}
							if (list_9.Count == 0)
							{
								break;
							}
						}
						list3.Remove(continousCoverageStation2);
					}
				}
				if (!Information.IsNothing(list3) && list3.Count > 0 && !Information.IsNothing(list3))
				{
					for (int n = list3.Count - 1; n >= 0; n += -1)
					{
						Mission.ContinousCoverageStation item = list3[n];
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							((Patrol)mission_0).ContinousCoverage_Stations.Remove(item);
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							((SupportMission)mission_0).ContinousCoverage_Stations.Remove(item);
						}
					}
				}
				string text3 = null;
				for (int num10 = list_9.Count - 1; num10 >= 0; num10 += -1)
				{
					Aircraft aircraft3 = list_9[num10];
					int num11 = mission_0.FlightSize;
					int dBID = aircraft3.DBID;
					int int32_ = aircraft3.Int32_0;
					if (Information.IsNothing(aircraft3.AirOps.CurrentHostUnit))
					{
						if (!Information.IsNothing(aircraft3.AirOps.GetAssignedHostUnit()))
						{
							text3 = aircraft3.AirOps.GetAssignedHostUnit().ObjectID;
						}
					}
					else
					{
						text3 = aircraft3.AirOps.CurrentHostUnit.ObjectID;
					}
					Mission.ContinousCoverageStation item2 = new Mission.ContinousCoverageStation("", dBID, int32_, text3, scenario_0.Time, scenario_0.Time, "");
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol patrol = (Patrol)mission_0;
						if (Information.IsNothing(patrol.ContinousCoverage_Stations))
						{
							patrol.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
						}
						patrol.ContinousCoverage_Stations.Add(item2);
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						SupportMission supportMission = (SupportMission)mission_0;
						if (Information.IsNothing(supportMission.ContinousCoverage_Stations))
						{
							supportMission.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
						}
						supportMission.ContinousCoverage_Stations.Add(item2);
					}
					num11--;
					if (num11 <= 0)
					{
						continue;
					}
					for (int num12 = list_9.Count - 1; num12 >= 0; num12 += -1)
					{
						Aircraft aircraft4 = list_9[num12];
						if (dBID != aircraft4.DBID || int32_ != aircraft4.Int32_0)
						{
							continue;
						}
						string text4 = null;
						if (Information.IsNothing(aircraft4.AirOps.CurrentHostUnit))
						{
							if (!Information.IsNothing(aircraft4.AirOps.GetAssignedHostUnit()))
							{
								text4 = aircraft4.AirOps.GetAssignedHostUnit().ObjectID;
							}
						}
						else
						{
							text4 = aircraft4.AirOps.CurrentHostUnit.ObjectID;
						}
						if (!Information.IsNothing(text4) && Operators.CompareString(text3, text4, TextCompare: false) == 0)
						{
							num11--;
							num10--;
							if (num11 == 0)
							{
								break;
							}
						}
					}
				}
				if (mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					list = ((Patrol)mission_0).ContinousCoverage_Stations;
				}
				if (mission_0.MissionClass == Mission._MissionClass.Support)
				{
					list = ((SupportMission)mission_0).ContinousCoverage_Stations;
				}
				DateTime t = scenario_0.Time.AddHours(mission_0.InsertValue(continousCoverageDuration_));
				Waypoint waypoint = null;
				Waypoint waypoint3 = null;
				for (int num13 = list.Count - 1; num13 >= 0; num13 += -1)
				{
					Mission.ContinousCoverageStation continousCoverageStation3 = list[num13];
					if (Information.IsNothing(continousCoverageStation3.HostUnitObjectID))
					{
						list.Remove(continousCoverageStation3);
						continue;
					}
					DateTime? stationStartTime = continousCoverageStation3.StationStartTime;
					if (!(stationStartTime.HasValue ? new bool?(DateTime.Compare(stationStartTime.GetValueOrDefault(), t) < 0) : null).GetValueOrDefault())
					{
						continue;
					}
					int int_4 = 0;
					Doctrine._UseUnderwayRefuelAndReplenishment? nullable_ = mission_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					string string_ = "";
					int int_5 = 0;
					int int_6 = 0;
					if (scenario_0.ActiveUnits.ContainsKey(continousCoverageStation3.HostUnitObjectID))
					{
						ActiveUnit activeUnit_ = scenario_0.ActiveUnits[continousCoverageStation3.HostUnitObjectID];
						if (Information.IsNothing(activeUnit_))
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							continue;
						}
						DateTime value = continousCoverageStation3.StationEndTime.Value;
						int num14 = mission_0.InstantiateValue(continousCoverageStationTime_);
						int num15 = mission_0.ReadValue(continousCoverageOverlap_);
						DateTime dateTime = value;
						bool flag2 = true;
						Mission.Flight flight = null;
						while (true)
						{
							List<Aircraft> list_10 = new List<Aircraft>();
							List<Mission.EmptyAircraftSlot> list4 = new List<Mission.EmptyAircraftSlot>();
							int num16 = 1;
							int_2 = _FlightSize_.value;
							for (int num17 = 1; num17 <= int_2; num17++)
							{
								Mission obj4 = mission_0;
								int aircraftDBID = continousCoverageStation3.AircraftDBID;
								int int_7 = continousCoverageStation3.int_0;
								Mission.Flight flight_ = null;
								Aircraft aircraft5 = obj4.CancelValue(ref scenario_0, ref side_0, aircraftDBID, int_7, ref activeUnit_, ref flight_, bool_0: false, num16);
								Mission.EmptyAircraftSlot item3 = new Mission.EmptyAircraftSlot(aircraft5, aircraft5.DBID, aircraft5.UnitClass, aircraft5.Int32_0, aircraft5.LoadoutName, ref activeUnit_, activeUnit_.ObjectID, activeUnit_.Name, bool_0: false);
								list_10.Add(aircraft5);
								list4.Add(item3);
								num16++;
							}
							List<Aircraft> list_11 = list_10.ToList();
							DateTime dateTime2 = dateTime;
							DateTime date = dateTime2.Date;
							TimeSpan value2 = TimeSpan.FromMinutes(Math.Floor((dateTime2.TimeOfDay.TotalMinutes + 2.5) / 5.0) * 5.0);
							dateTime = date.Add(value2);
							DateTime dateTime3 = dateTime.AddMinutes(num14);
							dateTime = dateTime.AddMinutes(-num15);
							flight = null;
							Mission._FlightSize _FlightSize_2 = 0;
							Mission._FlightSize _FlightSize_3 = 0;
							bool bool_10 = false;
							int_27 = 0;
							int_26 = 0;
							int_25 = 0;
							int_24 = 0;
							int_23 = 0;
							int_22 = 0;
							int_21 = 0;
							int_12 = 0;
							int int_8 = 0;
							int int_9 = 0;
							list_5 = list_10.ToList();
							list_4 = new List<Aircraft>();
							list_3 = new List<Aircraft>();
							bool bool_11 = false;
							float float_ = 0f;
							float float_2 = 0f;
							if (CollectBridge(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_10, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_9, ref bool_10, ref int_4, ref int_3, ref int_27, ref int_26, ref int_25, ref int_24, ref int_23, ref int_22, ref int_21, ref int_12, ref int_8, ref int_9, ref list_5, ref list_11, ref list_4, ref list_3, ref nullable_, ref bool_11, ref list_24, ref list_25, ref float_, ref float_2, ref string_, ref int_5, ref int_6, bool_2, null, null, flag2, ref list_23, bool_3, 0))
							{
								if (list_11.Count <= 0)
								{
									break;
								}
								_FlightSize_3 = 0;
								_FlightSize_2 = 0;
								bool_11 = false;
								int_9 = 0;
								int_8 = 0;
								int_12 = 0;
								int_21 = 0;
								list_3 = new List<Aircraft>();
								list_4 = new List<Aircraft>();
								bool_10 = false;
								float_2 = 0f;
								float_ = 0f;
								List<Group> list_13 = null;
								list_5 = null;
								list_27 = null;
								list_26 = null;
								List<Aircraft> list_14 = new List<Aircraft>();
								bool bool_12 = false;
								if (CloneInvocation(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_, ref _FlightSize_, ref _FlightSize_3, ref _FlightSize_2, ref bool_9, ref bool_11, ref int_4, ref int_3, ref int_9, ref int_8, ref int_12, ref int_21, ref list_11, ref list_3, ref list_4, ref nullable_, ref bool_10, ref list_24, ref float_2, ref float_, bool_5: false, ref list_13, ref list_5, ref list_27, ref list_26, ref list_23, ref list_14, ref string_, double_0, ref bool_12, bool_7: false, bool_2, flag2, ref flight, bool_3))
								{
									if (!Information.IsNothing(flight))
									{
										if (!Information.IsNothing(flight.FlightPlan) && flight.FlightPlan.Count() != 0)
										{
											if (Information.IsNothing(mission_0.EmptySlotsList))
											{
												mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
											}
											foreach (Mission.EmptyAircraftSlot item7 in list4)
											{
												item7.SetMissionFlight(scenario_0, flight);
												item7.MissionFlight_ObjectID = flight.ObjectID;
												item7.SetCurrentHostUnit(scenario_0, activeUnit_);
												item7.CurrentHostUnit_ObjectID = activeUnit_.ObjectID;
												item7.CurrentHostUnit_Name = activeUnit_.Name;
												item7.MissionFlight_ObjectID = flight.ObjectID;
												mission_0.EmptySlotsList.Add(item7);
											}
											Waypoint[] flightPlan3 = flight.FlightPlan;
											Waypoint[] array = flightPlan3;
											foreach (Waypoint waypoint4 in array)
											{
												if (waypoint4.SearchReponse())
												{
													waypoint = waypoint4;
												}
												else if (waypoint4.EnableReponse())
												{
													waypoint3 = waypoint4;
													break;
												}
											}
											if (!Information.IsNothing(waypoint))
											{
												if (!Information.IsNothing(waypoint3))
												{
													waypoint.Time_Zulu = dateTime;
													waypoint.TimeFixed = Waypoint.FixedFree.Fixed;
													waypoint3.Time_Zulu = dateTime3;
													waypoint3.TimeFixed = Waypoint.FixedFree.Fixed;
													waypoint3.Station_Time = (long)Math.Round(Math.Max((waypoint3.Time_Zulu.Value - waypoint.Time_Zulu.Value).TotalSeconds, 0.0));
													Scenario scenario_2 = scenario_0;
													Mission strike_ = mission_0;
													ActiveUnit referenceUnit = flight.GetReferenceUnit(scenario_0);
													Mission.Flight flight_2 = flight;
													Mission.Flight flight2;
													Waypoint[] waypoint_ = (flight2 = flight).FlightPlan;
													float_ = 0f;
													float_2 = 0f;
													MissionPlanner.ConnectTokenizer(scenario_2, strike_, referenceUnit, flight_2, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: true);
													flight2.FlightPlan = waypoint_;
													while (true)
													{
														stationStartTime = flight.FlightPlan[0].Time_Zulu;
														DateTime time = scenario_0.Time;
														if (!((!stationStartTime.HasValue) ? null : new bool?(DateTime.Compare(stationStartTime.GetValueOrDefault(), time) < 0)).GetValueOrDefault())
														{
															break;
														}
														TimeSpan value3 = TimeSpan.FromMinutes(Math.Floor(((scenario_0.Time - flight.FlightPlan[0].Time_Zulu.Value).TotalMinutes + 2.5) / 5.0) * 5.0 + 5.0);
														dateTime = dateTime.Add(value3);
														dateTime3 = dateTime3.Add(value3);
														waypoint_ = flight.FlightPlan;
														flightPlan3 = waypoint_;
														Waypoint[] array2 = flightPlan3;
														foreach (Waypoint waypoint5 in array2)
														{
															if (waypoint5.SearchReponse())
															{
																waypoint5.Time_Zulu = dateTime;
															}
															else if (waypoint5.EnableReponse())
															{
																waypoint5.Time_Zulu = dateTime3;
																break;
															}
														}
														Scenario scenario_3 = scenario_0;
														Mission strike_2 = mission_0;
														ActiveUnit referenceUnit2 = flight.GetReferenceUnit(scenario_0);
														Mission.Flight flight_3 = flight;
														Waypoint[] waypoint_2 = (flight2 = flight).FlightPlan;
														float_2 = 0f;
														float_ = 0f;
														MissionPlanner.ConnectTokenizer(scenario_3, strike_2, referenceUnit2, flight_3, ref waypoint_2, ref float_2, ref float_, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: true);
														flight2.FlightPlan = waypoint_2;
													}
													if (DateTime.Compare(dateTime, t) <= 0)
													{
														dateTime = dateTime3;
														continue;
													}
													Mission.ContinousCoverageStation continousCoverageStation4 = new Mission.ContinousCoverageStation(flight.ObjectID, flight.ReferenceUnit_DBID, flight.int_0, activeUnit_.ObjectID, dateTime, dateTime3, continousCoverageStation3.FlightplanTemplateObjectID);
													if (!Information.IsNothing(continousCoverageStation4))
													{
														if (mission_0.MissionClass == Mission._MissionClass.Patrol)
														{
															Patrol obj5 = (Patrol)mission_0;
															obj5.ContinousCoverage_Stations.Remove(continousCoverageStation3);
															obj5.ContinousCoverage_Stations.Add(continousCoverageStation4);
														}
														if (mission_0.MissionClass == Mission._MissionClass.Support)
														{
															SupportMission obj6 = (SupportMission)mission_0;
															obj6.ContinousCoverage_Stations.Remove(continousCoverageStation3);
															obj6.ContinousCoverage_Stations.Add(continousCoverageStation4);
														}
													}
													break;
												}
												if (mission_0.MissionClass == Mission._MissionClass.Patrol)
												{
													((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
												}
												if (mission_0.MissionClass == Mission._MissionClass.Support)
												{
													((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
												}
												break;
											}
											if (mission_0.MissionClass == Mission._MissionClass.Patrol)
											{
												((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
											}
											if (mission_0.MissionClass == Mission._MissionClass.Support)
											{
												((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
											}
											break;
										}
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										if (mission_0.MissionClass == Mission._MissionClass.Patrol)
										{
											((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
										}
										if (mission_0.MissionClass == Mission._MissionClass.Support)
										{
											((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
										}
										break;
									}
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									if (mission_0.MissionClass == Mission._MissionClass.Patrol)
									{
										((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
									}
									if (mission_0.MissionClass == Mission._MissionClass.Support)
									{
										((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
									}
									break;
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
								}
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
							}
							break;
						}
					}
					else
					{
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation3);
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void FlushBridge(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, double double_0, bool bool_2, bool bool_3)
	{
		try
		{
			List<Aircraft> list_ = new List<Aircraft>();
			List<Aircraft> list_12 = new List<Aircraft>();
			List<ActiveUnit> list_23 = new List<ActiveUnit>();
			List<int> list_25 = new List<int>();
			List<int> list_26 = new List<int>();
			List<Mission.ContinousCoverageStation> list = null;
			Mission._ContinousCoverageMethod continousCoverageMethod = Mission._ContinousCoverageMethod.Dynamic;
			if (mission_0.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol obj = (Patrol)mission_0;
				list = obj.ContinousCoverage_QRAs;
				continousCoverageMethod = obj.ContinousCoverage_QRAFlightGenerationMethod;
			}
			if (mission_0.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission obj2 = (SupportMission)mission_0;
				list = obj2.ContinousCoverage_QRAs;
				continousCoverageMethod = obj2.ContinousCoverage_QRAFlightGenerationMethod;
			}
			switch (continousCoverageMethod)
			{
			case Mission._ContinousCoverageMethod.FlightplanTemplates:
			{
				Mission._FlightSize _FlightSize_4 = mission_0.FlightSize;
				bool bool_10 = mission_0.UseFlightSizeHardLimit;
				int int_8 = 0;
				List<Mission.Flight> list5 = new List<Mission.Flight>();
				List<Mission.Flight> list6 = new List<Mission.Flight>();
				foreach (Mission.Flight flight4 in mission_0.FlightList)
				{
					if (flight4.Task == Mission._FlightTask.QRA)
					{
						if (flight4.Type == Mission._FlightType.FlightplanTemplate)
						{
							list5.Add(flight4);
						}
						else
						{
							list6.Add(flight4);
						}
					}
				}
				if (list5.Count <= 0)
				{
					if (bool_3)
					{
						ResolveBridge("对于任务没有QRA（快速反应警报）飞行计划模板存在。创建一个或多个QRA飞行计划模板并重试。", side_0);
					}
					scenario_0.AddMessage("对于任务没有QRA（快速反应警报）飞行计划模板存在" + mission_0.Name + "。创建一个或多个QRA飞行计划模板并重试。", "无QRA模板" + mission_0.Name, LoggedMessage.MessageType.AirOps, 0, null, side_0);
					break;
				}
				List<Mission.ContinousCoverageStation> list7 = null;
				if (list6.Count == 0 && !Information.IsNothing(list))
				{
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						((Patrol)mission_0).ContinousCoverage_QRAs.Clear();
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						((SupportMission)mission_0).ContinousCoverage_QRAs.Clear();
					}
				}
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					list7 = list.ToList();
				}
				Mission.ContinousCoverageStation continousCoverageStation = null;
				int count5;
				if (!Information.IsNothing(list7))
				{
					int count4 = list7.Count;
					count5 = list6.Count;
					for (int m = count4 - 1; m >= 0; m += -1)
					{
						continousCoverageStation = list7[m];
						bool flag = false;
						for (int n = count5 - 1; n >= 0; n += -1)
						{
							if (Operators.CompareString(list6[n].ObjectID, continousCoverageStation.FlightObjectID, TextCompare: false) == 0)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
						}
					}
				}
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					list7 = list.ToList();
				}
				count5 = ((!Information.IsNothing(list)) ? list.Count : 0);
				for (int num6 = list5.Count - 1; num6 >= 0; num6 += -1)
				{
					Mission.Flight flight_2 = list5[num6];
					bool flag2 = false;
					if (!Information.IsNothing(list7))
					{
						for (int num7 = count5 - 1; num7 >= 0; num7 += -1)
						{
							continousCoverageStation = list7[num7];
							if (Operators.CompareString(flight_2.ObjectID, continousCoverageStation.FlightplanTemplateObjectID, TextCompare: false) == 0)
							{
								flag2 = true;
								break;
							}
						}
					}
					if (flag2)
					{
						continue;
					}
					if (Information.IsNothing(flight_2))
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						continue;
					}
					int int_9 = 0;
					Doctrine._UseUnderwayRefuelAndReplenishment? nullable_2 = mission_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					string string_2 = "";
					if (scenario_0.ActiveUnits.ContainsKey(flight_2.TakeOffLocation_HostUnitObjectID))
					{
						ActiveUnit activeUnit_2 = scenario_0.ActiveUnits[flight_2.TakeOffLocation_HostUnitObjectID];
						if (Information.IsNothing(activeUnit_2))
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							continue;
						}
						if (Information.IsNothing(list_23))
						{
							list_23 = new List<ActiveUnit>();
						}
						list_23.Clear();
						list_23.Add(activeUnit_2);
						int int_10 = flight_2.int_0;
						if (Information.IsNothing(list_25))
						{
							list_25 = new List<int>();
						}
						list_25.Clear();
						list_25.Add(int_10);
						Mission.Flight flight2 = null;
						List<Aircraft> list8 = new List<Aircraft>();
						List<Mission.EmptyAircraftSlot> list9 = new List<Mission.EmptyAircraftSlot>();
						int num8 = 1;
						int value = _FlightSize_4.value;
						for (int num9 = 1; num9 <= value; num9++)
						{
							Mission obj5 = mission_0;
							int referenceUnit_DBID = flight_2.ReferenceUnit_DBID;
							int int_11 = flight_2.int_0;
							Mission.Flight flight_3 = null;
							Aircraft aircraft2 = obj5.CancelValue(ref scenario_0, ref side_0, referenceUnit_DBID, int_11, ref activeUnit_2, ref flight_3, bool_0: false, num8);
							Mission.EmptyAircraftSlot item2 = new Mission.EmptyAircraftSlot(aircraft2, aircraft2.DBID, aircraft2.UnitClass, aircraft2.Int32_0, aircraft2.LoadoutName, ref activeUnit_2, activeUnit_2.ObjectID, activeUnit_2.Name, bool_0: false);
							list8.Add(aircraft2);
							list9.Add(item2);
							num8++;
						}
						List<Aircraft> list_16 = list8.ToList();
						flight2 = null;
						Mission.Flight flight_4 = new Mission.Flight();
						Mission.Flight flight3 = flight_2;
						Mission mission_ = null;
						int int_13 = 0;
						int int_14 = 0;
						flight3.Copy(ref scenario_0, ref flight_2, ref flight_4, bool_0: false, ref mission_, ref int_13, ref int_14, bool_1: false, bool_2: false);
						flight_4.Type = Mission._FlightType.Flightplan;
						mission_0.MasterFlightList.Clear();
						mission_0.MasterFlightList.Add(flight_4);
						flight_2.UsedByFlight = false;
						if (list_16.Count <= 0)
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
							continue;
						}
						Mission._FlightSize _FlightSize_5 = 0;
						Mission._FlightSize _FlightSize_6 = 0;
						bool bool_11 = false;
						int_14 = 0;
						int_13 = 0;
						int int_15 = 0;
						int int_16 = 0;
						List<Aircraft> list_17 = new List<Aircraft>();
						List<Aircraft> list_18 = new List<Aircraft>();
						bool bool_4 = false;
						float float_3 = 0f;
						float float_4 = 0f;
						List<Group> list_19 = null;
						List<Aircraft> list_20 = null;
						List<Aircraft> list_21 = null;
						List<Aircraft> list_22 = null;
						List<Aircraft> list_24 = new List<Aircraft>();
						bool bool_5 = false;
						if (CloneInvocation(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_, ref _FlightSize_4, ref _FlightSize_5, ref _FlightSize_6, ref bool_10, ref bool_11, ref int_9, ref int_8, ref int_14, ref int_13, ref int_15, ref int_16, ref list_16, ref list_17, ref list_18, ref nullable_2, ref bool_4, ref list_25, ref float_3, ref float_4, bool_5: false, ref list_19, ref list_20, ref list_21, ref list_22, ref list_23, ref list_24, ref string_2, double_0, ref bool_5, bool_7: false, bool_2, bool_9: true, ref flight2, bool_3))
						{
							if (Information.IsNothing(flight2))
							{
								continue;
							}
							flight2.Task = Mission._FlightTask.QRA;
							if (Information.IsNothing(mission_0.EmptySlotsList))
							{
								mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
							}
							foreach (Mission.EmptyAircraftSlot item4 in list9)
							{
								item4.SetMissionFlight(scenario_0, flight2);
								item4.MissionFlight_ObjectID = flight2.ObjectID;
								item4.SetCurrentHostUnit(scenario_0, activeUnit_2);
								item4.CurrentHostUnit_ObjectID = activeUnit_2.ObjectID;
								item4.CurrentHostUnit_Name = activeUnit_2.Name;
								item4.MissionFlight_ObjectID = flight2.ObjectID;
								mission_0.EmptySlotsList.Add(item4);
							}
							Mission.ContinousCoverageStation item3 = new Mission.ContinousCoverageStation(flight2.ObjectID, flight_2.ReferenceUnit_DBID, int_10, activeUnit_2.ObjectID, scenario_0.Time, scenario_0.Time, flight_2.ObjectID);
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								Patrol patrol = (Patrol)mission_0;
								if (Information.IsNothing(patrol.ContinousCoverage_QRAs))
								{
									patrol.ContinousCoverage_QRAs = new List<Mission.ContinousCoverageStation>();
								}
								patrol.ContinousCoverage_QRAs.Add(item3);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								SupportMission supportMission = (SupportMission)mission_0;
								if (Information.IsNothing(supportMission.ContinousCoverage_QRAs))
								{
									supportMission.ContinousCoverage_QRAs = new List<Mission.ContinousCoverageStation>();
								}
								supportMission.ContinousCoverage_QRAs.Add(item3);
							}
						}
						else
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
							}
						}
					}
					else
					{
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				break;
			}
			case Mission._ContinousCoverageMethod.Dynamic:
			{
				Mission._FlightSize _FlightSize_ = mission_0.FlightSize;
				bool bool_6 = mission_0.UseFlightSizeHardLimit;
				int int_ = 0;
				int num = 0;
				if (mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					num = Mission.FlightQty_To_ActualFlightQty(ref ((Patrol)mission_0).ContinousCoverage_QRANumberOfFlights);
				}
				if (mission_0.MissionClass == Mission._MissionClass.Support)
				{
					num = Mission.FlightQty_To_ActualFlightQty(ref ((SupportMission)mission_0).ContinousCoverage_QRANumberOfFlights);
				}
				List<Mission.Flight> list2 = new List<Mission.Flight>();
				foreach (Mission.Flight flight5 in mission_0.FlightList)
				{
					if (flight5.Task == Mission._FlightTask.QRA && flight5.Type != Mission._FlightType.FlightplanTemplate)
					{
						list2.Add(flight5);
					}
				}
				if (list2.Count == 0 && !Information.IsNothing(list))
				{
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						((Patrol)mission_0).ContinousCoverage_QRAs.Clear();
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						((SupportMission)mission_0).ContinousCoverage_QRAs.Clear();
					}
				}
				Mission obj3 = mission_0;
				Scenario scenario_ = scenario_0;
				List<Aircraft> list_27 = null;
				List<Aircraft> list_28 = null;
				int int_12 = 0;
				int int_17 = 0;
				int int_18 = 0;
				int int_19 = 0;
				int int_20 = 0;
				int int_21 = 0;
				List<int> list_29 = null;
				List<ActiveUnit> list_30 = null;
				List<ActiveUnit> list_2 = null;
				List<Aircraft> list_3 = new List<Aircraft>();
				List<Aircraft> list_4 = new List<Aircraft>();
				List<Aircraft> list_5 = new List<Aircraft>();
				int int_22 = 0;
				int int_23 = 0;
				int int_2 = 0;
				List<Mission.Flight> list_6 = null;
				List<Mission.Flight> list_7 = null;
				List<Mission.Flight> list_8 = null;
				obj3.UnitsAssignedToMission_SeparatedByType(scenario_, ref list_25, ref list_26, ref list_, ref list_12, ref list_27, ref list_28, ref list_23, ref int_12, ref int_17, ref int_18, ref int_19, ref int_20, ref int_21, ref list_29, ref list_30, ref list_2, null, ref list_3, ref list_4, ref list_5, ref int_22, ref int_23, ref int_2, ref list_6, ref list_7, ref list_8, bool_0: false, bool_1: false, bool_2: true);
				int count = list_23.Count;
				int count2 = list_26.Count;
				int count3 = list_25.Count;
				for (int i = count - 1; i >= 0; i += -1)
				{
					ActiveUnit activeUnit_ = list_23[i];
					for (int j = count2 - 1; j >= 0; j += -1)
					{
						int num2 = list_26[j];
						for (int k = count3 - 1; k >= 0; k += -1)
						{
							int num3 = list_25[k];
							List<Mission.Flight> list3 = new List<Mission.Flight>();
							foreach (Mission.Flight flight6 in mission_0.FlightList)
							{
								if (flight6.Type != Mission._FlightType.FlightplanTemplate && flight6.Task == Mission._FlightTask.QRA && Operators.CompareString(flight6.TakeOffLocation_HostUnitObjectID, activeUnit_.ObjectID, TextCompare: false) == 0 && flight6.ReferenceUnit_DBID == num2 && flight6.int_0 == num3)
								{
									list3.Add(flight6);
								}
							}
							int num4 = list3.Count;
							if (num4 >= num)
							{
								continue;
							}
							do
							{
								int int_3 = 0;
								Doctrine._UseUnderwayRefuelAndReplenishment? nullable_ = mission_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
								string string_ = "";
								int int_4 = 0;
								int int_5 = 0;
								List<ActiveUnit> list_9 = new List<ActiveUnit>();
								list_9.Add(activeUnit_);
								List<int> list_10 = new List<int>();
								list_10.Add(num3);
								Mission.Flight flight = null;
								List<Aircraft> list_11 = new List<Aircraft>();
								List<Mission.EmptyAircraftSlot> list4 = new List<Mission.EmptyAircraftSlot>();
								int num5 = 1;
								int_2 = _FlightSize_.value;
								for (int l = 1; l <= int_2; l++)
								{
									Mission obj4 = mission_0;
									Mission.Flight flight_ = null;
									Aircraft aircraft = obj4.CancelValue(ref scenario_0, ref side_0, num2, num3, ref activeUnit_, ref flight_, bool_0: false, num5);
									Mission.EmptyAircraftSlot item = new Mission.EmptyAircraftSlot(aircraft, aircraft.DBID, aircraft.UnitClass, aircraft.Int32_0, aircraft.LoadoutName, ref activeUnit_, activeUnit_.ObjectID, activeUnit_.Name, bool_0: false);
									list_11.Add(aircraft);
									list4.Add(item);
									num5++;
								}
								List<Aircraft> list_13 = list_11.ToList();
								flight = null;
								Mission._FlightSize _FlightSize_2 = 0;
								Mission._FlightSize _FlightSize_3 = 0;
								bool bool_7 = false;
								int_23 = 0;
								int_22 = 0;
								int_21 = 0;
								int_20 = 0;
								int_19 = 0;
								int_18 = 0;
								int_17 = 0;
								int_12 = 0;
								int int_6 = 0;
								int int_7 = 0;
								list_5 = list_11.ToList();
								list_4 = new List<Aircraft>();
								list_3 = new List<Aircraft>();
								bool bool_8 = false;
								float float_ = 0f;
								float float_2 = 0f;
								if (CollectBridge(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_11, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_6, ref bool_7, ref int_3, ref int_, ref int_23, ref int_22, ref int_21, ref int_20, ref int_19, ref int_18, ref int_17, ref int_12, ref int_6, ref int_7, ref list_5, ref list_13, ref list_4, ref list_3, ref nullable_, ref bool_8, ref list_25, ref list_26, ref float_, ref float_2, ref string_, ref int_4, ref int_5, bool_2, null, null, bool_6: true, ref list_23, bool_3, 0))
								{
									if (list_13.Count > 0)
									{
										_FlightSize_3 = 0;
										_FlightSize_2 = 0;
										bool_8 = false;
										int_7 = 0;
										int_6 = 0;
										int_12 = 0;
										int_17 = 0;
										list_3 = new List<Aircraft>();
										list_4 = new List<Aircraft>();
										bool_7 = false;
										float_2 = 0f;
										float_ = 0f;
										List<Group> list_14 = null;
										list_5 = null;
										list_28 = null;
										list_27 = null;
										List<Aircraft> list_15 = new List<Aircraft>();
										bool bool_9 = false;
										if (CloneInvocation(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_, ref _FlightSize_, ref _FlightSize_3, ref _FlightSize_2, ref bool_6, ref bool_8, ref int_3, ref int_, ref int_7, ref int_6, ref int_12, ref int_17, ref list_13, ref list_3, ref list_4, ref nullable_, ref bool_7, ref list_10, ref float_2, ref float_, bool_5: false, ref list_14, ref list_5, ref list_28, ref list_27, ref list_9, ref list_15, ref string_, double_0, ref bool_9, bool_7: false, bool_2, bool_9: true, ref flight, bool_3))
										{
											if (Information.IsNothing(flight))
											{
												break;
											}
											flight.Task = Mission._FlightTask.QRA;
											if (Information.IsNothing(mission_0.EmptySlotsList))
											{
												mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
											}
											foreach (Mission.EmptyAircraftSlot item5 in list4)
											{
												item5.SetMissionFlight(scenario_0, flight);
												item5.MissionFlight_ObjectID = flight.ObjectID;
												item5.SetCurrentHostUnit(scenario_0, activeUnit_);
												item5.CurrentHostUnit_ObjectID = activeUnit_.ObjectID;
												item5.CurrentHostUnit_Name = activeUnit_.Name;
												item5.MissionFlight_ObjectID = flight.ObjectID;
												mission_0.EmptySlotsList.Add(item5);
											}
											num4++;
											continue;
										}
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										break;
									}
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									break;
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								break;
							}
							while (num4 < num);
						}
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ForgotBridge(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, double double_0)
	{
		try
		{
			if (!mission_0.RestartValue())
			{
				return;
			}
			bool flag = false;
			if (mission_0.MissionClass == Mission._MissionClass.Patrol)
			{
				flag = ((Patrol)mission_0).ContinousCoverage_QRAEnable;
			}
			if (mission_0.MissionClass == Mission._MissionClass.Support)
			{
				flag = ((SupportMission)mission_0).ContinousCoverage_QRAEnable;
			}
			if (!flag)
			{
				return;
			}
			List<Mission.Flight> list = new List<Mission.Flight>();
			List<Mission.Flight> list2 = new List<Mission.Flight>();
			foreach (Mission.Flight flight3 in mission_0.FlightList)
			{
				if (flight3.Type == Mission._FlightType.FlightplanTemplate)
				{
					continue;
				}
				if (flight3.Task == Mission._FlightTask.QRA)
				{
					if (flight3.GetStatus(scenario_0) == Mission._FlightStatus.None && flight3.ReadyAircraftQty >= flight3.MinimumAircraftQty && flight3.ReadyAircraftQty >= flight3.GetAUCurrentlyAssigned(mission_0, scenario_0).Count)
					{
						list.Add(flight3);
					}
				}
				else if (flight3.GetAUCurrentlyAssigned(mission_0, scenario_0).Count >= flight3.DesiredAircraftQty)
				{
					list2.Add(flight3);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			if (list2.Count == 0)
			{
				foreach (Mission.Flight item in list)
				{
					Mission.Flight flight_ = item;
					mission_0.ClearAllAircraft_ReplaceWithEmptySlots(ref scenario_0, ref side_0, ref flight_);
				}
				return;
			}
			List<Group> list3 = new List<Group>();
			List<Aircraft> list4 = new List<Aircraft>();
			bool flag2 = false;
			List<ActiveUnit> list5 = Module_Mission.AssetTokenizer(mission_0, scenario_0);
			int count = list5.Count;
			if (mission_0.MissionClass == Mission._MissionClass.Patrol && !flag2)
			{
				for (int i = count - 1; i >= 0; i += -1)
				{
					ActiveUnit activeUnit = list5[i];
					if (activeUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && activeUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive)
					{
						if (activeUnit.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || activeUnit.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO || activeUnit.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun || activeUnit.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO)
						{
							flag2 = true;
							break;
						}
						continue;
					}
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				for (int j = count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit2 = list5[j];
					if ((activeUnit2.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || activeUnit2.FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker) && activeUnit2.IsRTB_Or_CalledOff)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (flag2)
			{
				for (int k = list.Count - 1; k >= 0; k += -1)
				{
					Mission.Flight flight = list[k];
					ActiveUnit activeUnit3 = scenario_0.ActiveUnits[flight.TakeOffLocation_HostUnitObjectID];
					if (flight.GetIsActive(flight.GetAUCurrentlyAssigned(mission_0, scenario_0)))
					{
						continue;
					}
					List<ActiveUnit> list6 = new List<ActiveUnit>();
					foreach (ActiveUnit unit in side_0.Units)
					{
						if (!Information.IsNothing(unit.AssignedMissionOrPackage()) && !Information.IsNothing(unit.Navigator.GetFlight()) && flight == unit.Navigator.GetFlight() && unit.IsAircraft && !unit.IsOperating())
						{
							Aircraft aircraft = (Aircraft)unit;
							string string_ = null;
							if (aircraft.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable && aircraft.IsParkedAndReady())
							{
								list6.Add(unit);
								list4.Add((Aircraft)unit);
							}
						}
					}
					if (list6.Count == 0 || list6.Count <= 1)
					{
						continue;
					}
					if (list6.Count < flight.MinimumAircraftQty)
					{
						foreach (ActiveUnit item2 in list6)
						{
							list4.Remove((Aircraft)item2);
						}
						if (mission_0.TimeSincePlayerNotification == 1)
						{
							scenario_0.AddMessage("飞行编队" + flight.Callsign + "要求最低" + flight.MinimumAircraftQty.value + "飞机，然而只有" + Conversions.ToString(list6.Count) + "准备好起飞！该编队不会起飞！", flight.Callsign + " 未开始（无足够飞机就绪！）", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit3.GetLongitude(), activeUnit3.GetLatitude()));
						}
						continue;
					}
					Mission.Flight flight2 = list6[0].Navigator.GetFlight();
					Group group = new Group(ref scenario_0, ref side_0, list6, bool_0: true, null, mission_0);
					list3.Add(group);
					int num = 2;
					foreach (ActiveUnit value in group.Units.Values)
					{
						if (value.IsGroupLead())
						{
							value.SetFlight(flight2, 1);
							group.Name = "飞行编队" + flight2.Callsign;
						}
						else
						{
							value.SetFlight(flight2, num);
							num++;
						}
					}
				}
			}
			mission_0.OrderAircraftToTakeOff(ref scenario_0, list3, list4, null, null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool CollectBridge(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, ref List<Aircraft> list_0, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref bool bool_2, ref bool bool_3, ref int int_0, ref int int_1, ref int int_2, ref int int_3, ref int int_4, ref int int_5, ref int int_6, ref int int_7, ref int int_8, ref int int_9, ref int int_10, ref int int_11, ref List<Aircraft> list_1, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref List<Aircraft> list_4, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref bool bool_4, ref List<int> list_5, ref List<int> list_6, ref float float_0, ref float float_1, ref string string_0, ref int int_12, ref int int_13, bool bool_5, DateTime? nullable_1, DateTime? nullable_2, bool bool_6, ref List<ActiveUnit> list_7, bool bool_7, int int_14)
	{
		try
		{
			List<Mission.Flight> list = new List<Mission.Flight>();
			foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
			{
				if (Information.IsNothing(masterFlight))
				{
					list.Add(masterFlight);
					continue;
				}
				masterFlight.ClearFlightPlan();
				masterFlight.UsedByFlight = false;
				if (mission_0.MissionClass == Mission._MissionClass.Strike && Information.IsNothing(masterFlight.PrimaryTarget))
				{
					Waypoint[] gparam_ = masterFlight.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_);
					masterFlight.FlightPlan_Pathfinder_Ingress_1 = gparam_;
				}
				if (masterFlight.Age <= 120)
				{
					if (masterFlight.Age > 10 && !masterFlight.Pathfinder_Ingress_RequestBeingProcessed)
					{
						masterFlight.Age = 0;
						Waypoint[] gparam_2 = masterFlight.FlightPlan_Pathfinder_Ingress_1;
						ArrayExtensions.Clear(ref gparam_2);
						masterFlight.FlightPlan_Pathfinder_Ingress_1 = gparam_2;
					}
					else if (!bool_6)
					{
						masterFlight.Age++;
					}
				}
				else
				{
					masterFlight.Age = 0;
					Waypoint[] gparam_3 = masterFlight.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_3);
					masterFlight.FlightPlan_Pathfinder_Ingress_1 = gparam_3;
					masterFlight.Pathfinder_Ingress_RequestBeingProcessed = false;
				}
				if (masterFlight.FlightPlan.Count() == 0 && masterFlight.FlightPlan_Pathfinder_Ingress_1.Count() == 0 && !masterFlight.Pathfinder_Ingress_RequestBeingProcessed && !masterFlight.PathfinderRequestBeingProcessed_OnThisPulse)
				{
					list.Add(masterFlight);
				}
				masterFlight.PathfinderRequestBeingProcessed_OnThisPulse = false;
			}
			foreach (Mission.Flight item in list)
			{
				mission_0.MasterFlightList.Remove(item);
			}
			switch (mission_0.MissionClass)
			{
			case Mission._MissionClass.Strike:
			{
				Strike strike_ = (Strike)mission_0;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				bool_3 = strike_.UseFlightSizeHardLimit_Escort;
				if (strike_.OneTimeOnly && strike_.OneTimeOnlyFlown)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("***警告***任务" + mission_0.Name + "只允许执行一次。这项任务已经飞行，不会再次起飞。从任务中删除飞机。", mission_0.Name + " 是一次性的，目前", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
					}
					if (bool_7)
					{
						ResolveBridge("***警告***任务" + mission_0.Name + "只允许执行一次。这项任务已经飞行，不会再次起飞。从任务中删除飞机。", side_0);
					}
					foreach (Aircraft item2 in list_0)
					{
						if (!item2.IsOperating() && !item2.AirOps.IsTakingOff)
						{
							Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
							item2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
						}
					}
					return false;
				}
				if (strike_.RTB_When_Target_Destroyed && strike_.TargetCount == 0)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("任务" + mission_0.Name + "只允许攻击目标列表中的目标，列表为空。因此，任务不会启动。添加目标或取消选中仅预先计划的目标", mission_0.Name + " 未开始（未指定目标）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					if (bool_7)
					{
						ResolveBridge("任务" + mission_0.Name + "只允许攻击目标列表中的目标，列表为空。因此，任务不会启动。添加目标或取消选中仅预先计划的目标", side_0);
					}
					return false;
				}
				_FlightSize_0 = mission_0.FlightSize;
				_FlightSize_1 = strike_.Escort_FlightSize_Shooter;
				_FlightSize_2 = strike_.Escort_FlightSize_NonShooter;
				int_3 = mission_0.ExcludeValue(ref _FlightSize_1, ref strike_.MaximumNumberOfAircraft_Escorts_Shooter);
				int_5 = mission_0.ExcludeValue(ref _FlightSize_2, ref strike_.MaximumNumberOfAircraft_Escorts_NonShooter);
				if (int_14 <= 0)
				{
					int_0 = mission_0.ExcludeValue(ref _FlightSize_0, ref strike_.MinimumNumberOfAircraft);
				}
				else
				{
					Mission mission = mission_0;
					Mission._FlightSize _FlightSize_3 = new Mission._FlightSize(int_14);
					int_0 = mission.ExcludeValue(ref _FlightSize_3, ref strike_.MinimumNumberOfAircraft);
				}
				int_2 = mission_0.ExcludeValue(ref _FlightSize_1, ref strike_.MinimumNumberOfAircraft_Escorts_Shooter);
				int_4 = mission_0.ExcludeValue(ref _FlightSize_2, ref strike_.MinimumNumberOfAircraft_Escorts_NonShooter);
				if (list_0.Count == list_1.Count)
				{
					if (int_0 == int.MaxValue)
					{
						int_0 = int_9;
					}
					if (int_2 == int.MaxValue)
					{
						int_2 = int_10;
					}
					if (int_4 == int.MaxValue)
					{
						int_4 = int_11;
					}
				}
				if (PatchInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_0, ref list_1, int_0, _FlightSize_0))
				{
					if (!Information.IsNothing(int_0) && list_1.Count < int_0)
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + ((strike_.MinimumNumberOfAircraft == Mission._FlightQty.All) ? "All" : int_0.ToString()) + "飞机，然而只有" + Conversions.ToString(list_1.Count) + " 可用", "无足够飞机可用", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + ((strike_.MinimumNumberOfAircraft == Mission._FlightQty.All) ? "All" : int_0.ToString()) + "飞机，然而只有" + Conversions.ToString(list_1.Count) + " 可用", side_0);
						}
						return false;
					}
					List<Aircraft> list2 = list_0.Where((Aircraft theAC) => theAC.IsOperating() && theAC.IsRTB).ToList();
					_ = list2.Count;
					int num = 0;
					int num2 = 0;
					foreach (Aircraft item3 in list2)
					{
						if (item3.AI.IsEscort)
						{
							if (item3.Loadout.IsSupportOrPatrol)
							{
								num2++;
							}
							else
							{
								num++;
							}
						}
					}
					if (list_0.Count - int_6 - list2.Count < int_0)
					{
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + int_0 + "飞机，然而只有" + (int_6 - list2.Count) + " 可用", side_0);
						}
						return false;
					}
					if (int_10 - num < int_2)
					{
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + int_2 + " escorting aircraft, however only " + (int_7 - num) + " 可用", side_0);
						}
						return false;
					}
					if (_FlightSize_2 != 0 && int_11 - num2 < int_5)
					{
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + int_5 + " non shooter escorting aircraft, however only " + (int_8 - num2) + " 可用", side_0);
						}
						return false;
					}
					switch (strike_.Type)
					{
					case Strike.StrikeType.Land_Strike:
					case Strike.StrikeType.Maritime_Strike:
					case Strike.StrikeType.Sub_Strike:
					{
						Contact contact_ = null;
						ManageBridge(ref scenario_0, ref side_0, ref mission_0, ref strike_, bool_1, ref _FlightSize_0, ref _FlightSize_1, ref _FlightSize_2, ref list_2, ref list_3, ref list_4, ref list_1, contact_, ref string_0, ref int_12, ref float_0, ref float_1, ref int_13, ref nullable_0, ref bool_4, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					}
					case Strike.StrikeType.Air_Intercept:
						RegisterBridge(ref scenario_0, ref side_0, ref mission_0, ref strike_, bool_1, ref _FlightSize_0, ref _FlightSize_1, ref _FlightSize_2, ref list_2, ref list_3, ref list_4, ref list_1, ref string_0, ref int_12, ref int_13, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					}
					if (mission_0.MasterFlightList.Count <= 0)
					{
						break;
					}
					foreach (Mission.Flight masterFlight2 in mission_0.MasterFlightList)
					{
						ActiveUnit activeUnit2 = scenario_0.ActiveUnits[masterFlight2.TakeOffLocation_HostUnitObjectID];
						if (masterFlight2.FlightCannotLaunch && !Information.IsNothing(masterFlight2.GetReferenceUnit(scenario_0)) && !string.IsNullOrEmpty(masterFlight2.FlightCannotLaunch_Feedback))
						{
							if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
							{
								scenario_0.AddMessage("任务" + strike_.Name + "，飞机类型" + masterFlight2.GetReferenceUnit(scenario_0).UnitClass + "随着挂载" + ((Aircraft)masterFlight2.GetReferenceUnit(scenario_0)).LoadoutName + "基于" + masterFlight2.TakeOffLocation_HostUnitObjectName + "无法发射！原因：" + masterFlight2.FlightCannotLaunch_Feedback, strike_.Name + " 无法开始", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
							}
							if (bool_7)
							{
								ResolveBridge("任务" + strike_.Name + "，飞机类型" + masterFlight2.GetReferenceUnit(scenario_0).UnitClass + "与挂载" + ((Aircraft)masterFlight2.GetReferenceUnit(scenario_0)).LoadoutName + "基于" + masterFlight2.TakeOffLocation_HostUnitObjectName + "无法发射！原因：" + masterFlight2.FlightCannotLaunch_Feedback, side_0);
							}
						}
					}
					break;
				}
				return false;
			}
			case Mission._MissionClass.Patrol:
			{
				Patrol patrol_ = (Patrol)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				if (!bool_6)
				{
					int_0 = patrol_.ExcludeValue(ref _FlightSize_0, ref patrol_.MinimumNumberOfAircraft);
					if (list_0.Count == list_1.Count && int_0 == int.MaxValue)
					{
						int_0 = int_9;
					}
					if (!PatchInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_0, ref list_1, int_0, _FlightSize_0))
					{
						return false;
					}
					if (!Information.IsNothing(int_0) && list_0.Count < int_0)
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", mission_0.Name + " 无足够飞机", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", side_0);
						}
						return false;
					}
					int minimumNumberOnStation = ((Patrol)mission_0).MinimumNumberOnStation;
					bool oneThirdRule2 = ((Patrol)mission_0).OneThirdRule;
					OrderBridge(bool_1: false, ref list_2, oneThirdRule2, minimumNumberOnStation, ref list_7, ref list_6, ref list_0, ref list_5, ref list_1, ref _FlightSize_0, ref bool_2);
				}
				if (patrol_.UseFlightplans)
				{
					switch (patrol_.Type)
					{
					case GlobalVariables.PatrolType.AAW:
						list_1.Clear();
						list_1 = list_2.ToList();
						list_2.Clear();
						CountInvocation(ref scenario_0, ref side_0, ref mission_0, ref patrol_, bool_1, ref _FlightSize_0, ref list_2, ref list_1, ref string_0, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					case GlobalVariables.PatrolType.SEAD:
						list_1.Clear();
						list_1 = list_2.ToList();
						list_2.Clear();
						CountInvocation(ref scenario_0, ref side_0, ref mission_0, ref patrol_, bool_1, ref _FlightSize_0, ref list_2, ref list_1, ref string_0, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					case GlobalVariables.PatrolType.ASW:
					case GlobalVariables.PatrolType.ASuW_Naval:
					case GlobalVariables.PatrolType.ASuW_Land:
					case GlobalVariables.PatrolType.ASuW_Mixed:
					case GlobalVariables.PatrolType.SeaControl:
						list_1.Clear();
						list_1 = list_2.ToList();
						list_2.Clear();
						CountInvocation(ref scenario_0, ref side_0, ref mission_0, ref patrol_, bool_1, ref _FlightSize_0, ref list_2, ref list_1, ref string_0, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					}
				}
				if (mission_0.MasterFlightList.Count <= 0)
				{
					break;
				}
				foreach (Mission.Flight masterFlight3 in mission_0.MasterFlightList)
				{
					ActiveUnit activeUnit = scenario_0.ActiveUnits[masterFlight3.TakeOffLocation_HostUnitObjectID];
					if (masterFlight3.FlightCannotLaunch && !Information.IsNothing(masterFlight3.GetReferenceUnit(scenario_0)) && !string.IsNullOrEmpty(masterFlight3.FlightCannotLaunch_Feedback))
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("任务" + patrol_.Name + "，飞机类型" + masterFlight3.GetReferenceUnit(scenario_0).UnitClass + "与挂载" + ((Aircraft)masterFlight3.GetReferenceUnit(scenario_0)).LoadoutName + "基于" + masterFlight3.TakeOffLocation_HostUnitObjectName + "无法发射！原因：" + masterFlight3.FlightCannotLaunch_Feedback, patrol_.Name + " 无法开始", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
						}
						if (bool_7)
						{
							ResolveBridge("任务" + patrol_.Name + "，飞机类型" + masterFlight3.GetReferenceUnit(scenario_0).UnitClass + "与挂载" + ((Aircraft)masterFlight3.GetReferenceUnit(scenario_0)).LoadoutName + "基于" + masterFlight3.TakeOffLocation_HostUnitObjectName + "无法发射！原因：" + masterFlight3.FlightCannotLaunch_Feedback, side_0);
						}
					}
				}
				break;
			}
			case Mission._MissionClass.Support:
			{
				SupportMission supportMission_ = (SupportMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				if (!bool_6)
				{
					int_0 = supportMission_.ExcludeValue(ref _FlightSize_0, ref supportMission_.MinimumNumberOfAircraft);
					if (list_0.Count == list_1.Count && int_0 == int.MaxValue)
					{
						int_0 = int_9;
					}
					if (!PatchInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_0, ref list_1, int_0, _FlightSize_0))
					{
						return false;
					}
					if (!Information.IsNothing(int_0) && list_0.Count < int_0)
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", mission_0.Name + " 无足够飞机", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", side_0);
						}
						return false;
					}
					int minimumNumberOnStation2 = ((SupportMission)mission_0).MinimumNumberOnStation;
					bool oneThirdRule4 = ((SupportMission)mission_0).OneThirdRule;
					OrderBridge(bool_1: false, ref list_2, oneThirdRule4, minimumNumberOnStation2, ref list_7, ref list_6, ref list_0, ref list_5, ref list_1, ref _FlightSize_0, ref bool_2);
				}
				if (supportMission_.UseFlightplans)
				{
					list_1.Clear();
					list_1 = list_2.ToList();
					list_2.Clear();
					CustomizeInvocation(ref scenario_0, ref side_0, ref mission_0, ref supportMission_, bool_1, ref _FlightSize_0, ref list_2, ref list_1, ref string_0, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
				}
				if (mission_0.MasterFlightList.Count <= 0)
				{
					break;
				}
				foreach (Mission.Flight masterFlight4 in mission_0.MasterFlightList)
				{
					ActiveUnit activeUnit3 = scenario_0.ActiveUnits[masterFlight4.TakeOffLocation_HostUnitObjectID];
					if (masterFlight4.FlightCannotLaunch && !Information.IsNothing(masterFlight4.GetReferenceUnit(scenario_0)) && !string.IsNullOrEmpty(masterFlight4.FlightCannotLaunch_Feedback))
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("任务" + supportMission_.Name + "，飞机类型" + masterFlight4.GetReferenceUnit(scenario_0).UnitClass + "与挂载" + ((Aircraft)masterFlight4.GetReferenceUnit(scenario_0)).LoadoutName + "基于" + masterFlight4.TakeOffLocation_HostUnitObjectName + "无法发射！原因：" + masterFlight4.FlightCannotLaunch_Feedback, supportMission_.Name + " 无法开始", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit3.GetLongitude(), activeUnit3.GetLatitude()));
						}
						if (bool_7)
						{
							ResolveBridge("任务" + supportMission_.Name + "，飞机类型" + masterFlight4.GetReferenceUnit(scenario_0).UnitClass + "与挂载" + ((Aircraft)masterFlight4.GetReferenceUnit(scenario_0)).LoadoutName + "基于" + masterFlight4.TakeOffLocation_HostUnitObjectName + "无法发射！原因：" + masterFlight4.FlightCannotLaunch_Feedback, side_0);
						}
					}
				}
				break;
			}
			case Mission._MissionClass.Ferry:
			{
				FerryMission ferryMission = (FerryMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				int_0 = ferryMission.ExcludeValue(ref _FlightSize_0, ref ferryMission.MinimumNumberOfAircraft);
				if (list_0.Count == list_1.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (PatchInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_0, ref list_1, int_0, _FlightSize_0))
				{
					foreach (Aircraft item4 in list_1)
					{
						list_2.Add(item4);
					}
					break;
				}
				if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
				{
					scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", mission_0.Name + " 无足够飞机", LoggedMessage.MessageType.AirOps, 0, null, side_0);
				}
				if (bool_7)
				{
					ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", side_0);
				}
				return false;
			}
			case Mission._MissionClass.Mining:
			{
				MiningMission miningMission = (MiningMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				int_0 = mission_0.ExcludeValue(ref _FlightSize_0, ref miningMission.MinimumNumberOfAircraft);
				if (list_0.Count == list_1.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (PatchInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_0, ref list_1, int_0, _FlightSize_0))
				{
					if (!Information.IsNothing(int_0) && list_0.Count < int_0)
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", mission_0.Name + " 无足够飞机", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", side_0);
						}
						return false;
					}
					bool oneThirdRule3 = ((MiningMission)mission_0).OneThirdRule;
					OrderBridge(bool_1: false, ref list_2, oneThirdRule3, 0, ref list_7, ref list_6, ref list_0, ref list_5, ref list_1, ref _FlightSize_0, ref bool_2);
					break;
				}
				return false;
			}
			case Mission._MissionClass.MineClearing:
			{
				MineClearingMission mineClearingMission = (MineClearingMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				int_0 = mineClearingMission.ExcludeValue(ref _FlightSize_0, ref mineClearingMission.MinimumNumberOfAircraft);
				if (list_0.Count == list_1.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (PatchInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_0, ref list_1, int_0, _FlightSize_0))
				{
					if (!Information.IsNothing(int_0) && list_0.Count < int_0)
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", mission_0.Name + " 无足够飞机", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
						if (bool_7)
						{
							ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用", side_0);
						}
						return false;
					}
					bool oneThirdRule = ((MineClearingMission)mission_0).OneThirdRule;
					OrderBridge(bool_1: false, ref list_2, oneThirdRule, 0, ref list_7, ref list_6, ref list_0, ref list_5, ref list_1, ref _FlightSize_0, ref bool_2);
					break;
				}
				return false;
			}
			case Mission._MissionClass.Escort:
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				break;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static void OrderBridge(bool bool_1, ref List<Aircraft> list_0, bool bool_2, int int_0, ref List<ActiveUnit> list_1, ref List<int> list_2, ref List<Aircraft> list_3, ref List<int> list_4, ref List<Aircraft> list_5, ref Mission._FlightSize _FlightSize_0, ref bool bool_3)
	{
		try
		{
			int num = int_0;
			if (!bool_2 && num <= 0)
			{
				foreach (Aircraft item in list_5)
				{
					list_0.Add(item);
				}
				return;
			}
			foreach (int Local_theDBID in list_2)
			{
				if (bool_2)
				{
					num = int_0;
				}
				List<Aircraft> list = list_3.Where((Aircraft theAC) => theAC.DBID == Local_theDBID).ToList();
				List<Aircraft> list2 = new List<Aircraft>();
				if (list.Count <= 0)
				{
					continue;
				}
				foreach (int Local_theLoadoutDBID in list_4)
				{
					foreach (ActiveUnit Local_theHost in list_1)
					{
						int num2 = 0;
						List<Aircraft> list3 = (bool_1 ? list.Where((Aircraft theAC) => theAC.DBID == Local_theDBID && !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == Local_theHost).ToList() : list_5.Where((Aircraft theAC) => theAC.DBID == Local_theDBID && !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == Local_theHost).ToList());
						if (list3.Count <= 0 || (bool_3 & (list3.Count < (int)_FlightSize_0)))
						{
							continue;
						}
						if (bool_2 && num > 0)
						{
							num = (int)Math.Round(Math.Ceiling(Math.Max((double)list.Count / (double)(int)_FlightSize_0 / 3.0, (double)num / (double)(int)_FlightSize_0)) * (double)(int)_FlightSize_0);
						}
						else if (bool_2 && num == 0)
						{
							num = (int)Math.Round(Math.Ceiling((double)list.Count / (double)(int)_FlightSize_0 / 3.0) * (double)(int)_FlightSize_0);
						}
						else if (!bool_2 && num > 0)
						{
							num = (int)Math.Round(Math.Ceiling((double)num / (double)(int)_FlightSize_0) * (double)(int)_FlightSize_0);
						}
						if (bool_1)
						{
							num2 = (int)Math.Round(Math.Ceiling((double)(num - list2.Count) / (double)(int)_FlightSize_0) * (double)(int)_FlightSize_0);
						}
						else
						{
							List<Aircraft> list4 = list.Where((Aircraft theAC) => theAC.AirOps.IsTakingOff || (theAC.IsOperating() && !theAC.IsRTB && !theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun && (!theAC.IsGroupWingman() || Information.IsNothing(theAC.GetParentGroup().GroupLead) || !theAC.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)) || (theAC.Navigator.HasFlightPlan && Information.IsNothing(theAC.Navigator.GetFlight().FlightPlan[0].Time_Zulu) && theAC.PushFacade())).ToList();
							list4.AddRange(list2);
							num2 = (int)Math.Round(Math.Ceiling((double)(num - list4.Count) / (double)(int)_FlightSize_0) * (double)(int)_FlightSize_0);
						}
						if (Information.IsNothing(num2) || num2 <= 0)
						{
							continue;
						}
						for (int i = num2 - 1; i >= 0; i += -1)
						{
							if (bool_3 && list3.Count < (int)_FlightSize_0)
							{
								break;
							}
							int num3 = _FlightSize_0;
							for (int j = 1; j <= num3; j++)
							{
								if (list3.Count > 0)
								{
									list_0.Add(list3[0]);
									list2.Add(list3[0]);
									list3.Remove(list3[0]);
									if (j > 1)
									{
										i--;
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void RegisterBridge(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Strike strike_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref List<Aircraft> list_0, ref List<Aircraft> list_1, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref string string_0, ref int int_0, ref int int_1, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_2, DateTime? nullable_1, DateTime? nullable_2, bool bool_3, bool bool_4)
	{
		try
		{
			List<Mission.MissionAircraftEntry> list = new List<Mission.MissionAircraftEntry>();
			foreach (Aircraft item2 in list_3)
			{
				if (list.Count > 0)
				{
					bool flag = false;
					foreach (Mission.MissionAircraftEntry item3 in list)
					{
						if (Operators.CompareString(item3.HostUnitObjectID, item2.AirOps.CurrentHostUnit.ObjectID, TextCompare: false) == 0 && item3.AircraftDBID == item2.DBID && item3.int_0 == item2.Loadout.DBID)
						{
							flag = true;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				bool flag2 = true;
				if (item2.AI.IsEscort)
				{
					if (item2.Loadout.IsSupportOrPatrol && _FlightSize_2 != 0)
					{
						list_2.Add(item2);
					}
					else
					{
						list_1.Add(item2);
					}
					continue;
				}
				Doctrine._UseShootTourists? shootTourists = item2.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
				foreach (Contact contacts_ in side_0.Contacts_List)
				{
					if (item2.AI.ContactIsRelevantToMission(contacts_, mission_0, shootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_0, ref int_0) && item2.AI.IncludeClient(ref strike_0, contacts_.GetStance(item2.GetUnitSide())) && item2.AI.NewClient(contacts_, strike_0.MinResponseRadius_Aircraft, strike_0.MaxResponseRadius_Aircraft, nullable_0, mission_0.LaunchMissionWithoutTankersInPlace, ref string_0) && Module_Contact.PostTokenizer(contacts_, side_0, bool_0: false).Count < _FlightSize_0)
					{
						item2.AI.PrimaryTarget = contacts_;
						((Strike)mission_0).SpecificTargets.Add(contacts_);
						list_0.Add(item2);
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					Aircraft_AirOps airOps = item2.AirOps;
					Mission.MissionAircraftEntry item = new Mission.MissionAircraftEntry(airOps.CurrentHostUnit.ObjectID, airOps.CurrentHostUnit.Name, item2.DBID, item2.UnitClass, item2.Loadout.DBID, item2.Loadout.Name);
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			foreach (Mission.MissionAircraftEntry item4 in list)
			{
				if (!string.IsNullOrEmpty(string_0))
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_4)
					{
						ActiveUnit activeUnit = scenario_0.ActiveUnits[item4.HostUnitObjectID];
						scenario_0.AddMessage("任务" + strike_0.Name + "，飞机类型" + item4.AircraftName + "与挂载" + item4.LoadoutName + "基于" + item4.HostUnitObjectName + "无法发射！原因：" + string_0, strike_0.Name + " 无法开始", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
					}
					if (bool_4)
					{
						ResolveBridge("任务" + strike_0.Name + "，飞机类型" + item4.AircraftName + "与挂载" + item4.LoadoutName + "基于" + item4.HostUnitObjectName + "无法发射！原因：" + string_0, side_0);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ManageBridge(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Strike strike_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref List<Aircraft> list_0, ref List<Aircraft> list_1, ref List<Aircraft> list_2, ref List<Aircraft> list_3, Contact contact_0, ref string string_0, ref int int_0, ref float float_0, ref float float_1, ref int int_1, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref bool bool_2, bool bool_3, DateTime? nullable_1, DateTime? nullable_2, bool bool_4, bool bool_5)
	{
		try
		{
			foreach (Aircraft item in list_3)
			{
				Aircraft aircraft_ = item;
				if (aircraft_.AI.IsEscort)
				{
					if (aircraft_.Loadout.IsSupportOrPatrol && _FlightSize_2 != 0)
					{
						list_2.Add(aircraft_);
					}
					else
					{
						list_1.Add(aircraft_);
					}
					continue;
				}
				Mission.Flight flight_ = null;
				if (RevertBridge(ref mission_0, ref aircraft_, ref list_0, ref contact_0, ref flight_, bool_3))
				{
					continue;
				}
				bool flag = true;
				Doctrine._UseShootTourists? shootTourists = aircraft_.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
				if (strike_0.TargetCount <= 0)
				{
					List<Contact> list = new List<Contact>();
					for (int i = side_0.Contacts_List.Count - 1; i >= 0; i += -1)
					{
						Contact contact = side_0.Contacts_List[i];
						if (aircraft_.AI.ContactIsRelevantToMission(contact, mission_0, shootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_0, ref int_0) && aircraft_.Weaponry.PopConsumer(contact, bool_1: true, aircraft_.Doctrine, ref string_0, ref int_1))
						{
							list.Add(contact);
							((Strike)mission_0).SpecificTargets.Add(contact);
						}
					}
					foreach (Contact item2 in list)
					{
						Contact contact_ = item2;
						if (!aircraft_.AI.IncludeClient(ref strike_0, contact_.GetStance(side_0)))
						{
							continue;
						}
						if (Information.IsNothing(flight_))
						{
							_ = aircraft_.AirOps;
							string string_ = ((strike_0.Type == Strike.StrikeType.Sub_Strike) ? "主飞行计划" : ("主飞行计划飞机DBID：" + Conversions.ToString(aircraft_.DBID) + "挂载DBID：" + Conversions.ToString(aircraft_.Int32_0)));
							Mission.Flight flight_2 = null;
							flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_2, string_, contact_, aircraft_, _FlightSize_0, bool_0: false);
						}
						Aircraft_AI aI = aircraft_.AI;
						int minResponseRadius_Aircraft = strike_0.MinResponseRadius_Aircraft;
						int maxResponseRadius_Aircraft = strike_0.MaxResponseRadius_Aircraft;
						Doctrine._UseUnderwayRefuelAndReplenishment? nullable_3 = nullable_0;
						bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
						Mission._RadarBehaviour radarBehaviour = strike_0.RadarBehaviour;
						bool usePlanner = strike_0.UsePlanner;
						float float_2 = 0f;
						if (aI.SetupClient(ref scenario_0, ref side_0, ref mission_0, ref flight_, ref contact_, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, nullable_3, launchMissionWithoutTankersInPlace, radarBehaviour, bool_1: true, bool_2: false, bool_3: false, usePlanner, ref float_2, ref string_0, bool_1, ref bool_2, bool_2, ref float_0, ref float_1, bool_8: true, null, bool_3, nullable_1, nullable_2, bool_4, bool_11: true))
						{
							flag = false;
							flight_.FlightCannotLaunch = false;
							flight_.FlightCannotLaunch_Feedback = "";
							mission_0.AddMasterFlight(ref flight_);
						}
						bool flag2 = false;
						if (strike_0.Type == Strike.StrikeType.Sub_Strike)
						{
							if (!flag)
							{
								flag2 = true;
							}
						}
						else if (flight_.FlightPlan.Count() > 0 || flight_.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
						{
							flag2 = true;
						}
						if (!flag2)
						{
							if (flag)
							{
								continue;
							}
							break;
						}
						list_0.Add(aircraft_);
						contact_0 = contact_;
						aircraft_.AI.PrimaryTarget = contact_0;
						break;
					}
				}
				else
				{
					foreach (Contact contacts_ in side_0.Contacts_List)
					{
						Contact contact_2 = contacts_;
						if (contact_2.GetIsSpecificTargetForThisStrike(strike_0) && aircraft_.AI.IncludeClient(ref strike_0, contact_2.GetStance(side_0)) && aircraft_.Weaponry.PopConsumer(contact_2, bool_1: true, aircraft_.Doctrine, ref string_0, ref int_1))
						{
							if (Information.IsNothing(flight_))
							{
								_ = aircraft_.AirOps;
								string string_2 = ((strike_0.Type == Strike.StrikeType.Sub_Strike) ? "主飞行计划" : ("主飞行计划飞机DBID：" + Conversions.ToString(aircraft_.DBID) + "挂载DBID：" + Conversions.ToString(aircraft_.Int32_0)));
								Mission.Flight flight_3 = null;
								flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_3, string_2, contact_2, aircraft_, _FlightSize_0, bool_0: false);
							}
							Aircraft_AI aI2 = aircraft_.AI;
							int minResponseRadius_Aircraft2 = strike_0.MinResponseRadius_Aircraft;
							int maxResponseRadius_Aircraft2 = strike_0.MaxResponseRadius_Aircraft;
							Doctrine._UseUnderwayRefuelAndReplenishment? nullable_4 = nullable_0;
							bool launchMissionWithoutTankersInPlace2 = mission_0.LaunchMissionWithoutTankersInPlace;
							Mission._RadarBehaviour radarBehaviour2 = strike_0.RadarBehaviour;
							bool usePlanner2 = strike_0.UsePlanner;
							float float_3 = 0f;
							if (aI2.SetupClient(ref scenario_0, ref side_0, ref mission_0, ref flight_, ref contact_2, minResponseRadius_Aircraft2, maxResponseRadius_Aircraft2, nullable_4, launchMissionWithoutTankersInPlace2, radarBehaviour2, bool_1: true, bool_2: false, bool_3: false, usePlanner2, ref float_3, ref string_0, bool_1, ref bool_2, bool_2, ref float_0, ref float_1, bool_8: true, null, bool_3, nullable_1, nullable_2, bool_4, bool_11: true))
							{
								flag = false;
								flight_.FlightCannotLaunch = false;
								flight_.FlightCannotLaunch_Feedback = "";
								mission_0.AddMasterFlight(ref flight_);
							}
							bool flag3 = false;
							if (strike_0.Type == Strike.StrikeType.Sub_Strike)
							{
								flag3 = true;
							}
							else if (flight_.FlightPlan.Count() > 0 || flight_.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
							{
								flag3 = true;
							}
							if (flag3)
							{
								list_0.Add(aircraft_);
								contact_0 = contact_2;
								aircraft_.AI.PrimaryTarget = contact_0;
								break;
							}
							if (!flag)
							{
								break;
							}
						}
					}
				}
				if (!flag)
				{
					continue;
				}
				if (Information.IsNothing(flight_))
				{
					_ = aircraft_.AirOps;
					string string_3 = ((strike_0.Type == Strike.StrikeType.Sub_Strike) ? "主飞行计划" : ("主飞行计划飞机DBID：" + Conversions.ToString(aircraft_.DBID) + "挂载DBID：" + Conversions.ToString(aircraft_.Int32_0)));
					Mission.Flight flight_4 = null;
					flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_4, string_3, null, aircraft_, _FlightSize_0, bool_0: false);
					if (bool_5)
					{
						flight_.FlightCannotLaunch_Feedback = "没有可用的目标。";
					}
				}
				if (!mission_0.MasterFlightList.Contains(flight_))
				{
					mission_0.AddMasterFlight(ref flight_);
					flight_.FlightCannotLaunch = true;
					if (!string.IsNullOrEmpty(string_0))
					{
						flight_.FlightCannotLaunch_Feedback = string_0;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool RevertBridge(ref Mission mission_0, ref Aircraft aircraft_0, ref List<Aircraft> list_0, ref Contact contact_0, ref Mission.Flight flight_0, bool bool_1)
	{
		try
		{
			if (mission_0.MasterFlightList.Count != 0)
			{
				foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
				{
					if (aircraft_0.Int32_0 != masterFlight.int_0 || Operators.CompareString(aircraft_0.AirOps.CurrentHostUnit.ObjectID, masterFlight.TakeOffLocation_HostUnitObjectID, TextCompare: false) != 0)
					{
						continue;
					}
					if (masterFlight.PathfinderRequestBeingProcessed_OnThisPulse)
					{
						return true;
					}
					if (masterFlight.FlightCannotLaunch)
					{
						return true;
					}
					if (masterFlight.FlightPlan.Count() <= 0)
					{
						if (masterFlight.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
						{
							if (masterFlight.Pathfinder_Ingress_RequestBeingProcessed)
							{
								return true;
							}
							break;
						}
						if (masterFlight.FlightPlan_Pathfinder_Ingress_1[0].Type == Waypoint.WaypointType.PathfindingPoint)
						{
							flight_0 = masterFlight;
							break;
						}
						ref Scenario parentScen = ref aircraft_0.ParentScen;
						Mission.Flight flight;
						Waypoint[] waypoint_ = (flight = masterFlight).FlightPlan_Pathfinder_Ingress_1;
						bool num = MissionPlanner.ResolveValue(ref parentScen, ref waypoint_, bool_1);
						flight.FlightPlan_Pathfinder_Ingress_1 = waypoint_;
						if (num)
						{
							list_0.Add(aircraft_0);
							aircraft_0.AI.PrimaryTarget = contact_0;
							return true;
						}
						waypoint_ = masterFlight.FlightPlan_Pathfinder_Ingress_1;
						ArrayExtensions.Clear(ref waypoint_);
						masterFlight.FlightPlan_Pathfinder_Ingress_1 = waypoint_;
						masterFlight.FlightCannotLaunch = true;
						break;
					}
					list_0.Add(aircraft_0);
					aircraft_0.AI.PrimaryTarget = contact_0;
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static void CountInvocation(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Patrol patrol_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref List<Aircraft> list_0, ref List<Aircraft> list_1, ref string string_0, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_2, DateTime? nullable_1, DateTime? nullable_2, bool bool_3, bool bool_4)
	{
		try
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			double double_3 = 0.0;
			double double_4 = 0.0;
			foreach (Aircraft item in list_1)
			{
				Aircraft aircraft_ = item;
				Mission.Flight flight_ = null;
				Contact contact_ = null;
				if (RevertBridge(ref mission_0, ref aircraft_, ref list_0, ref contact_, ref flight_, bool_2))
				{
					continue;
				}
				bool flag = true;
				aircraft_.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
				if (Information.IsNothing(flight_))
				{
					_ = aircraft_.AirOps;
					string string_ = "主飞行计划飞机DBID：" + Conversions.ToString(aircraft_.DBID) + "挂载DBID：" + Conversions.ToString(aircraft_.Int32_0);
					Mission.Flight flight_2 = null;
					flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_2, string_, null, aircraft_, _FlightSize_0, bool_0: false);
				}
				float float_ = 50f;
				if (aircraft_.Navigator.UpdateDic(ref double_, ref double_2, ref double_3, ref double_4, ref float_))
				{
					Aircraft_AI aI = aircraft_.AI;
					Doctrine._UseUnderwayRefuelAndReplenishment? nullable_3 = nullable_0;
					bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
					float float_2 = 0f;
					if (aI.ExcludeClient(ref flight_, nullable_3, launchMissionWithoutTankersInPlace, bool_1: true, bool_2: false, bool_3: false, ref float_2, ref string_0, bool_1, bool_5: true, double_, double_2, double_3, double_4, Waypoint.WaypointType.StationStart_Racetrack, Waypoint.TurnRateCategory.HalfStandardRateTurn, bool_2, nullable_1, nullable_2, bool_3, bool_8: true))
					{
						flag = false;
						flight_.FlightCannotLaunch = false;
						flight_.FlightCannotLaunch_Feedback = "";
						mission_0.AddMasterFlight(ref flight_);
					}
					bool flag2 = false;
					if (flight_.FlightPlan.Count() > 0 || flight_.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
					{
						flag2 = true;
					}
					if (flag2)
					{
						list_0.Add(aircraft_);
					}
					if (!flag)
					{
						continue;
					}
					if (Information.IsNothing(flight_))
					{
						string string_2 = "主飞行计划飞机DBID：" + Conversions.ToString(aircraft_.DBID) + "挂载DBID：" + Conversions.ToString(aircraft_.Int32_0);
						Mission.Flight flight_3 = null;
						flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_3, string_2, null, aircraft_, _FlightSize_0, bool_0: false);
						if (bool_4)
						{
							flight_.FlightCannotLaunch_Feedback = "没有可用的目标。";
						}
					}
					if (!mission_0.MasterFlightList.Contains(flight_))
					{
						mission_0.AddMasterFlight(ref flight_);
						flight_.FlightCannotLaunch = true;
						if (!string.IsNullOrEmpty(string_0))
						{
							flight_.FlightCannotLaunch_Feedback = string_0;
						}
					}
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void CustomizeInvocation(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref SupportMission supportMission_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref List<Aircraft> list_0, ref List<Aircraft> list_1, ref string string_0, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_2, DateTime? nullable_1, DateTime? nullable_2, bool bool_3, bool bool_4)
	{
		try
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			double double_3 = 0.0;
			double double_4 = 0.0;
			foreach (Aircraft item in list_1)
			{
				Aircraft aircraft_ = item;
				Mission.Flight flight_ = null;
				Contact contact_ = null;
				if (RevertBridge(ref mission_0, ref aircraft_, ref list_0, ref contact_, ref flight_, bool_2))
				{
					continue;
				}
				bool flag = true;
				aircraft_.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
				if (Information.IsNothing(flight_))
				{
					string string_ = "主飞行计划飞机DBID：" + Conversions.ToString(aircraft_.DBID) + "挂载DBID：" + Conversions.ToString(aircraft_.Int32_0);
					Mission.Flight flight_2 = null;
					flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_2, string_, null, aircraft_, _FlightSize_0, bool_0: false);
				}
				float float_ = 50f;
				if (aircraft_.Navigator.UpdateDic(ref double_, ref double_2, ref double_3, ref double_4, ref float_))
				{
					Waypoint.WaypointType waypointType_ = (aircraft_.IsTanker ? Waypoint.WaypointType.StationStart_Area : Waypoint.WaypointType.StationStart_FigureEight);
					Aircraft_AI aI = aircraft_.AI;
					Doctrine._UseUnderwayRefuelAndReplenishment? nullable_3 = nullable_0;
					bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
					float float_2 = 0f;
					if (aI.ExcludeClient(ref flight_, nullable_3, launchMissionWithoutTankersInPlace, bool_1: true, bool_2: false, bool_3: false, ref float_2, ref string_0, bool_1, bool_5: true, double_, double_2, double_3, double_4, waypointType_, Waypoint.TurnRateCategory.FlatTurn, bool_2, nullable_1, nullable_2, bool_3, bool_8: true))
					{
						flag = false;
						flight_.FlightCannotLaunch = false;
						flight_.FlightCannotLaunch_Feedback = "";
						mission_0.AddMasterFlight(ref flight_);
					}
					bool flag2 = false;
					if (flight_.FlightPlan.Count() > 0 || flight_.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
					{
						flag2 = true;
					}
					if (flag2)
					{
						list_0.Add(aircraft_);
					}
					if (!flag)
					{
						continue;
					}
					if (Information.IsNothing(flight_))
					{
						_ = aircraft_.AirOps;
						string string_2 = "主飞行计划飞机DBID：" + Conversions.ToString(aircraft_.DBID) + "挂载DBID：" + Conversions.ToString(aircraft_.Int32_0);
						Mission.Flight flight_3 = null;
						flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_3, string_2, null, aircraft_, _FlightSize_0, bool_0: false);
						if (bool_4)
						{
							flight_.FlightCannotLaunch_Feedback = "没有可用的目标。";
						}
					}
					if (!mission_0.MasterFlightList.Contains(flight_))
					{
						mission_0.AddMasterFlight(ref flight_);
						flight_.FlightCannotLaunch = true;
						if (!string.IsNullOrEmpty(string_0))
						{
							flight_.FlightCannotLaunch_Feedback = string_0;
						}
					}
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool CloneInvocation(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, ref List<Aircraft> list_0, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref bool bool_2, ref bool bool_3, ref int int_0, ref int int_1, ref int int_2, ref int int_3, ref int int_4, ref int int_5, ref List<Aircraft> list_1, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref bool bool_4, ref List<int> list_4, ref float float_0, ref float float_1, bool bool_5, ref List<Group> list_5, ref List<Aircraft> list_6, ref List<Aircraft> list_7, ref List<Aircraft> list_8, ref List<ActiveUnit> list_9, ref List<Aircraft> list_10, ref string string_0, double double_0, ref bool bool_6, bool bool_7, bool bool_8, bool bool_9, ref Mission.Flight flight_0, bool bool_10)
	{
		try
		{
			if (mission_0.MissionClass == Mission._MissionClass.Strike)
			{
				if (!Information.IsNothing(int_0) && list_1.Count < int_0)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
					{
						scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_1.Count) + "可用。任务不会启动。", mission_0.Name + " 无法开始（无足够飞机）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					if (bool_10)
					{
						ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_1.Count) + "可用。任务不会启动。", side_0);
					}
					return false;
				}
				if (!Information.IsNothing(int_2) && list_2.Count < int_2)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
					{
						scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_2) + "射击（武装）护航，但是只有" + Conversions.ToString(list_2.Count) + "可用。任务不会启动。", mission_0.Name + " 无法开始（无足够护航飞机）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					if (bool_10)
					{
						ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_2) + "射击（武装）护航，但是只有" + Conversions.ToString(list_2.Count) + "可用。任务不会启动。", side_0);
					}
					return false;
				}
				if (!Information.IsNothing(int_4) && list_3.Count < int_4 && _FlightSize_2 != 0)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
					{
						scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_4) + "非射击护航（非武装），但是只有" + Conversions.ToString(list_3.Count) + "可用。任务不会启动。", mission_0.Name + " 无法开始（无足够非武装护航飞机）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					if (bool_10)
					{
						ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_4) + "非射击护航（非武装），但是只有" + Conversions.ToString(list_3.Count) + "可用。任务不会启动。", side_0);
					}
					return false;
				}
			}
			else if (!Information.IsNothing(int_0) && list_0.Count < int_0)
			{
				if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
				{
					scenario_0.AddMessage("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用。任务不会启动。", mission_0.Name + " 无法开始（无足够飞机）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
				}
				if (bool_10)
				{
					ResolveBridge("任务" + mission_0.Name + "要求至少" + Conversions.ToString(int_0) + "飞机，然而只有" + Conversions.ToString(list_0.Count) + "可用。任务不会启动。", side_0);
				}
				return false;
			}
			int num = 0;
			bool flag = false;
			foreach (ActiveUnit Local_theAircraftHost in list_9)
			{
				if (flag)
				{
					break;
				}
				foreach (int Local_theLoadoutDBID in list_4)
				{
					if (flag)
					{
						break;
					}
					int num5 = 0;
					IEnumerable<Aircraft> enumerable = list_1.Where((Aircraft theAC) => !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == Local_theAircraftHost);
					if (enumerable.Count() <= 0)
					{
						continue;
					}
					if (((enumerable.Count() < _FlightSize_0) & bool_2) || flag)
					{
						if (!(enumerable.Count() < _FlightSize_0) || flag)
						{
							continue;
						}
						if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
						{
							if (mission_0.Category == Mission.MissionCategory.Mission)
							{
								scenario_0.AddMessage("任务" + mission_0.Name + "，飞机类型" + enumerable.ElementAtOrDefault(0).UnitClass + "与挂载" + enumerable.ElementAtOrDefault(0).LoadoutName + "在主机" + Local_theAircraftHost.Name + " 无法开始。飞机数量不满足编队最小飞机数量。请重新设置。", mission_0.Name + " 无法开始", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(Local_theAircraftHost.GetLongitude(), Local_theAircraftHost.GetLatitude()));
							}
							else
							{
								scenario_0.AddMessage(mission_0.Name + "，飞机类型" + enumerable.ElementAtOrDefault(0).UnitClass + "与挂载" + enumerable.ElementAtOrDefault(0).LoadoutName + "在主机" + Local_theAircraftHost.Name + "有问题。一架或多架飞机尚未分配到一架飞机，飞机将无法启动。可能的解决方法是从任务包中取出飞机，改变飞行编队大小或手动创建飞行编队。", mission_0.Name + " 无法开始", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(Local_theAircraftHost.GetLongitude(), Local_theAircraftHost.GetLatitude()));
							}
						}
						if (bool_10)
						{
							if (mission_0.Category == Mission.MissionCategory.Mission)
							{
								ResolveBridge("任务" + mission_0.Name + "，飞机类型" + enumerable.ElementAtOrDefault(0).UnitClass + "与挂载" + enumerable.ElementAtOrDefault(0).LoadoutName + "在主机" + Local_theAircraftHost.Name + " 无法开始。飞机数量不满足编队最小飞机数量。请重新设置。", side_0);
							}
							else
							{
								ResolveBridge(mission_0.Name + "，飞机类型" + enumerable.ElementAtOrDefault(0).UnitClass + "与挂载" + enumerable.ElementAtOrDefault(0).LoadoutName + "在主机" + Local_theAircraftHost.Name + "有问题。一架或多架飞机尚未分配到一架飞机，飞机将无法启动。可能的解决方法是从任务包中取出飞机，改变飞行编队大小或手动创建飞行编队。", side_0);
							}
						}
						continue;
					}
					if (_FlightSize_0 <= 1)
					{
						int num6 = 0;
						foreach (Aircraft item3 in enumerable)
						{
							Aircraft aircraft_ = item3;
							if (bool_5)
							{
								list_6.Add(aircraft_);
							}
							if (bool_5)
							{
								if (mission_0.MasterFlightList.Count <= 0)
								{
									AddInvocation(ref scenario_0, ref mission_0, ref aircraft_, ref list_10, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
									num6++;
								}
								else
								{
									DeleteInvocation(ref scenario_0, ref side_0, ref mission_0, ref aircraft_, ref list_10, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_0, ref float_0, ref float_1, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
									num6++;
								}
							}
							else if (mission_0.MasterFlightList.Count <= 0)
							{
								AddInvocation(ref scenario_0, ref mission_0, ref aircraft_, ref list_10, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
								num6++;
							}
							else
							{
								DeleteInvocation(ref scenario_0, ref side_0, ref mission_0, ref aircraft_, ref list_10, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_0, ref float_0, ref float_1, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
								num6++;
							}
							if (mission_0.MissionClass != Mission._MissionClass.Strike || num6 < Mission.FlightQty_To_ActualFlightQty(ref ((Strike)mission_0).MaxFlightNumber_Strike))
							{
								num++;
								if (mission_0.MissionClass == Mission._MissionClass.Strike && int_1 > 0 && num >= int_1)
								{
									flag = true;
									break;
								}
								continue;
							}
							break;
						}
						continue;
					}
					int num7 = enumerable.Count();
					while (true)
					{
						if (!bool_2)
						{
							if (num7 == 0)
							{
								break;
							}
						}
						else
						{
							if (mission_0.MissionClass == Mission._MissionClass.Strike && mission_0.CheckValue((int)((Strike)mission_0).MaxFlightNumber_Strike, bool_0: false) != 0)
							{
								int num8 = mission_0.FlightList.Where((Mission.Flight theF) => theF.IsEscort).Count();
								int num9 = 0;
								foreach (Mission.Flight flight in mission_0.FlightList)
								{
									if (!flight.Departed)
									{
										foreach (ActiveUnit unit in side_0.Units)
										{
											if (unit.IsAircraft && unit.AssignedMissionOrPackage() != null && Operators.CompareString(unit.AssignedMissionOrPackage().ObjectID, mission_0.ObjectID, TextCompare: false) == 0 && unit.Navigator.GetFlight() != null && Operators.CompareString(unit.Navigator.GetFlight().ObjectID, flight.ObjectID, TextCompare: false) == 0 && !(((Aircraft)unit).AirborneTime <= 0f))
											{
												flight.Departed = true;
												break;
											}
										}
									}
									if (flight.Departed)
									{
										foreach (ActiveUnit unit2 in side_0.Units)
										{
											flight.Landed = true;
											if (unit2.IsAircraft && unit2.AssignedMissionOrPackage() != null && Operators.CompareString(unit2.AssignedMissionOrPackage().ObjectID, mission_0.ObjectID, TextCompare: false) == 0 && unit2.Navigator.GetFlight() != null && Operators.CompareString(unit2.Navigator.GetFlight().ObjectID, flight.ObjectID, TextCompare: false) == 0)
											{
												flight.Landed = false;
												break;
											}
										}
									}
									if (!flight.Landed)
									{
										num9++;
									}
								}
								num9 -= num8;
								if (num9 >= mission_0.CheckValue((int)((Strike)mission_0).MaxFlightNumber_Strike, bool_0: false))
								{
									break;
								}
							}
							if (num7 < _FlightSize_0)
							{
								break;
							}
						}
						List<ActiveUnit> list_11 = new List<ActiveUnit>();
						int num10 = _FlightSize_0;
						for (int i = 1; i <= num10; i++)
						{
							if (num5 >= enumerable.Count())
							{
								break;
							}
							if (!Information.IsNothing(enumerable.ElementAtOrDefault(num5)))
							{
								list_11.Add(enumerable.ElementAtOrDefault(num5));
								if (bool_5)
								{
									list_6.Add(enumerable.ElementAtOrDefault(num5));
								}
								num++;
								num7--;
								num5++;
							}
						}
						if (bool_5)
						{
							Group group_ = new Group(ref scenario_0, ref side_0, list_11, bool_0: false, null, mission_0);
							list_5.Add(group_);
							if (mission_0.MasterFlightList.Count <= 0)
							{
								ConnectInvocation(ref scenario_0, ref mission_0, ref list_11, ref group_, ref list_10, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
							}
							else
							{
								MoveInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_11, ref group_, ref list_10, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_0, ref float_0, ref float_1, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
							}
						}
						else if (mission_0.MasterFlightList.Count > 0 && list_11.Count > 0)
						{
							Group group_2 = null;
							MoveInvocation(ref scenario_0, ref side_0, ref mission_0, ref list_11, ref group_2, ref list_10, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_0, ref float_0, ref float_1, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
						}
						else
						{
							Group group_3 = null;
							ConnectInvocation(ref scenario_0, ref mission_0, ref list_11, ref group_3, ref list_10, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
						}
					}
				}
			}
			bool flag2 = true;
			if (bool_3 && ((int_3 == 0) & (int_5 == 0)))
			{
				flag2 = false;
			}
			if ((flag2 & !Information.IsNothing(list_6)) && (((list_6.Count > 0) | bool_6) || bool_7))
			{
				int num11 = 0;
				int num12 = 0;
				bool flag3 = false;
				bool flag4 = false;
				foreach (ActiveUnit Local_theAircraftHost2 in list_9)
				{
					if (flag3 && flag4)
					{
						break;
					}
					foreach (int Local_theLoadoutDBID2 in list_4)
					{
						if (flag3 && flag4)
						{
							break;
						}
						int num2 = 0;
						List<Aircraft> list;
						List<Aircraft> list2;
						if (_FlightSize_2 == 0)
						{
							list = list_2.Where((Aircraft theAC) => !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID2 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == Local_theAircraftHost2).ToList();
							list2 = null;
						}
						else
						{
							list = list_2.Where((Aircraft theAC) => !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID2 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == Local_theAircraftHost2 && !theAC.Loadout.IsSupportOrPatrol).ToList();
							list2 = list_3.Where((Aircraft theAC) => !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID2 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == Local_theAircraftHost2 && theAC.Loadout.IsSupportOrPatrol).ToList();
						}
						bool flag5 = false;
						if ((Information.IsNothing(list) || list.Count <= 0) | bool_3)
						{
							if (list.Count >= _FlightSize_1 && !flag3)
							{
								flag5 = true;
							}
						}
						else
						{
							flag5 = true;
						}
						if (flag5)
						{
							if (_FlightSize_1 <= 1)
							{
								foreach (Aircraft item4 in list)
								{
									Aircraft aircraft_2 = item4;
									if (bool_5)
									{
										list_7.Add(aircraft_2);
									}
									num11++;
									num++;
									if (bool_5)
									{
										Mission.Flight flight_ = null;
										AddInvocation(ref scenario_0, ref mission_0, ref aircraft_2, ref list_10, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_);
									}
									else
									{
										Mission.Flight flight_2 = null;
										AddInvocation(ref scenario_0, ref mission_0, ref aircraft_2, ref list_10, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_2);
									}
									if (int_3 > 0 && num11 >= int_3)
									{
										break;
									}
								}
							}
							else
							{
								int num3 = list.Count;
								while (true)
								{
									if (!bool_3)
									{
										if (num3 == 0)
										{
											break;
										}
									}
									else if (num3 < _FlightSize_1)
									{
										break;
									}
									List<ActiveUnit> list_12 = new List<ActiveUnit>();
									int num4 = _FlightSize_1;
									for (int j = 1; j <= num4; j++)
									{
										if (num2 >= list.Count)
										{
											break;
										}
										if (!Information.IsNothing(list[num2]))
										{
											list_12.Add(list[num2]);
											if (bool_5)
											{
												list_7.Add(list[num2]);
											}
											num11++;
											num3--;
											num2++;
										}
									}
									if (bool_5)
									{
										Group group_4 = new Group(ref scenario_0, ref side_0, list_12, bool_0: false, null, mission_0);
										list_5.Add(group_4);
										Mission.Flight flight_3 = null;
										ConnectInvocation(ref scenario_0, ref mission_0, ref list_12, ref group_4, ref list_10, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_3);
									}
									else
									{
										Group group_5 = null;
										Mission.Flight flight_4 = null;
										ConnectInvocation(ref scenario_0, ref mission_0, ref list_12, ref group_5, ref list_10, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_4);
									}
									if (mission_0.MissionClass == Mission._MissionClass.Strike && int_3 > 0 && num11 >= int_3)
									{
										flag3 = true;
										break;
									}
								}
							}
						}
						if (Information.IsNothing(list2) || list2.Count <= 0 || (bool_3 && !(list2.Count >= _FlightSize_2)) || flag4 || !(_FlightSize_2 <= 1))
						{
							continue;
						}
						foreach (Aircraft item5 in list2)
						{
							Aircraft aircraft_3 = item5;
							if (bool_5)
							{
								list_8.Add(aircraft_3);
							}
							num12++;
							num++;
							if (bool_5)
							{
								Mission.Flight flight_5 = null;
								AddInvocation(ref scenario_0, ref mission_0, ref aircraft_3, ref list_10, ref _FlightSize_2, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_5);
							}
							else
							{
								Mission.Flight flight_6 = null;
								AddInvocation(ref scenario_0, ref mission_0, ref aircraft_3, ref list_10, ref _FlightSize_2, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_6);
							}
							if (int_5 > 0 && num12 >= int_5)
							{
								break;
							}
						}
					}
				}
			}
			if (bool_5 && mission_0.MissionClass == Mission._MissionClass.Strike && ((!Information.IsNothing(int_0) && list_6.Count < int_0) || (!Information.IsNothing(int_2) && list_7.Count < int_2) || (_FlightSize_2 != 0 && !Information.IsNothing(int_4) && list_8.Count < int_4)))
			{
				foreach (Group item6 in list_5)
				{
					item6.Destroy(bool_0: false, bool_1: false, bool_2: false, "Group destroyed by mission logic");
				}
				if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
				{
					if (mission_0.Category == Mission.MissionCategory.Mission)
					{
						scenario_0.AddMessage("任务" + mission_0.Name + " 无法满足最小飞机数量。任务无法开始。请重新设置。", mission_0.Name + " 无法开始（无足够飞机）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					else
					{
						scenario_0.AddMessage(mission_0.Name + "不符合最低飞机要求。可能的解决想定是从任务包中取出飞机，改变飞行大小或手动创建飞行。", mission_0.Name + " 无法开始（无足够飞机）", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
				}
				if (bool_10)
				{
					if (mission_0.Category == Mission.MissionCategory.Mission)
					{
						ResolveBridge("任务" + mission_0.Name + " 无法满足最小飞机数量。任务无法开始。请重新设置。", side_0);
					}
					else
					{
						ResolveBridge(mission_0.Name + "不符合最低飞机要求。可能的解决想定是从任务包中取出飞机，改变飞行大小或手动创建飞行。", side_0);
					}
				}
			}
			else if (bool_5)
			{
				for (int k = list_5.Count - 1; k >= 0; k += -1)
				{
					Group group = list_5[k];
					if (Information.IsNothing(group.Units.Values) || group.Units.Values.Count <= 0)
					{
						continue;
					}
					ActiveUnit activeUnit = group.Units.Values.ElementAtOrDefault(0);
					if (!activeUnit.Navigator.HasFlightPlan)
					{
						continue;
					}
					Waypoint waypoint = activeUnit.Navigator.GetFlight().FlightPlan[0];
					if (Information.IsNothing(waypoint.Time_Zulu) || (waypoint.Time_Zulu.Value - scenario_0.Time).TotalSeconds - double_0 - 60.0 < 0.0)
					{
						continue;
					}
					foreach (Aircraft value2 in group.Units.Values)
					{
						if (list_6.Contains(value2))
						{
							list_6.Remove(value2);
						}
						else if (list_7.Contains(value2))
						{
							list_7.Remove(value2);
						}
						else if (list_8.Contains(value2))
						{
							list_8.Remove(value2);
						}
					}
					list_5.Remove(group);
					group.Destroy(bool_0: false, bool_1: false, bool_2: false, "Group destroyed by mission logic");
				}
				List<Aircraft> list3 = new List<Aircraft>();
				list3.AddRange(list_6);
				list3.AddRange(list_7);
				list3.AddRange(list_8);
				foreach (Aircraft item7 in list3)
				{
					if (!item7.Navigator.HasFlightPlan)
					{
						continue;
					}
					Waypoint waypoint2 = item7.Navigator.GetFlight().FlightPlan[0];
					if (!Information.IsNothing(waypoint2.Time_Zulu) && !((waypoint2.Time_Zulu.Value - scenario_0.Time).TotalSeconds - double_0 - 60.0 < 0.0))
					{
						if (list_6.Contains(item7))
						{
							list_6.Remove(item7);
						}
						else if (list_7.Contains(item7))
						{
							list_7.Remove(item7);
						}
						else if (list_8.Contains(item7))
						{
							list_8.Remove(item7);
						}
					}
				}
				if (list_6.Count == 0 && (list_7.Count > 0 || list_8.Count > 0))
				{
					for (int l = list_5.Count - 1; l >= 0; l += -1)
					{
						Group group2 = list_5[l];
						if (Information.IsNothing(group2.Units.Values) || group2.Units.Values.Count <= 0)
						{
							continue;
						}
						foreach (Aircraft value3 in group2.Units.Values)
						{
							if (list_7.Contains(value3))
							{
								list_7.Remove(value3);
							}
							else if (list_8.Contains(value3))
							{
								list_8.Remove(value3);
							}
						}
						list_5.Remove(group2);
						group2.Destroy(bool_0: false, bool_1: false, bool_2: false, "Group destroyed by mission logic");
					}
					list3.AddRange(list_7);
					list3.AddRange(list_8);
					foreach (Aircraft item8 in list3)
					{
						if (list_7.Contains(item8))
						{
							list_7.Remove(item8);
						}
						else if (list_8.Contains(item8))
						{
							list_8.Remove(item8);
						}
					}
				}
				if (!bool_6 && list_6.Count > 0)
				{
					bool_6 = true;
				}
				mission_0.OrderAircraftToTakeOff(ref scenario_0, list_5, list_6, list_7, list_8);
			}
			if (mission_0.MissionClass == Mission._MissionClass.Ferry)
			{
				foreach (Mission.Flight flight2 in mission_0.FlightList)
				{
					Mission.Flight flight_7 = flight2;
					if (Information.IsNothing(flight_7) || flight_7.GetStatus(scenario_0) != 0)
					{
						continue;
					}
					flight_7.DesiredAircraftQty = mission_0.FlightSize;
					if (mission_0.UseFlightSizeHardLimit)
					{
						flight_7.MinimumAircraftQty = mission_0.FlightSize;
					}
					else
					{
						flight_7.MinimumAircraftQty = 1;
					}
					foreach (ActiveUnit Local_theAircraftHost3 in list_9)
					{
						if (flag)
						{
							break;
						}
						foreach (int Local_theLoadoutDBID3 in list_4)
						{
							if (flag)
							{
								break;
							}
							foreach (Aircraft item9 in list_1.Where((Aircraft theAC) => !Information.IsNothing(theAC.Loadout) && theAC.Loadout.DBID == Local_theLoadoutDBID3 && !Information.IsNothing(theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == Local_theAircraftHost3))
							{
								Aircraft aircraft_4 = item9;
								bool value = false;
								bool flag6 = false;
								bool bool_11 = false;
								bool bool_12 = false;
								float float_2 = 0f;
								bool bool_13 = false;
								float float_3 = 0f;
								Waypoint.TurnRateCategory turnRateCategory_ = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
								if (flight_7.DesiredAircraftQty > 6)
								{
									_ = (int)flight_7.DesiredAircraftQty;
									_ = (int)flight_7.MinimumAircraftQty;
									flight_7.DesiredAircraftQty = 6;
									flight_7.MinimumAircraftQty = 6;
								}
								bool? nullable_ = value;
								string string_ = "";
								MissionPlanner.GenerateFlightPlan_Skeleton(ref scenario_0, ref side_0, ref mission_0, ref flight_7, ref aircraft_4, nullable_, ref flag6, bool_11, bool_12, ref float_2, ref string_, bool_13, float_3, turnRateCategory_, bool_4: true, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_5: false);
							}
						}
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static void ConnectInvocation(ref Scenario scenario_0, ref Mission mission_0, ref List<ActiveUnit> list_0, ref Group group_0, ref List<Aircraft> list_1, ref Mission._FlightSize _FlightSize_0, ref bool bool_1, bool bool_2, bool bool_3, bool bool_4, ref Mission.Flight flight_0)
	{
		try
		{
			Aircraft aircraft_ = (Aircraft)list_0[0];
			Mission.Flight flight_ = null;
			Mission.Flight flight_2 = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_, Callsigns.ReadProperty(ref mission_0), null, aircraft_, _FlightSize_0, bool_2);
			if (mission_0.MissionClass == Mission._MissionClass.Strike)
			{
				int num = mission_0.FlightList.Where((Mission.Flight theF) => theF.IsEscort).Count();
				if (mission_0.CheckValue((int)((Strike)mission_0).MaxFlightNumber_Strike, bool_0: false) != 0)
				{
					int num2 = mission_0.FlightList.Count - num;
					if (!bool_2 & (num2 >= mission_0.CheckValue((int)((Strike)mission_0).MaxFlightNumber_Strike, bool_0: false)))
					{
						return;
					}
				}
			}
			mission_0.AddFlight(ref flight_2);
			int num3 = 2;
			if (bool_1)
			{
				foreach (ActiveUnit value in group_0.Units.Values)
				{
					if (value.IsGroupLead())
					{
						value.SetFlight(flight_2, 1);
						group_0.Name = "飞行编队" + flight_2.Callsign;
					}
					else
					{
						value.SetFlight(flight_2, num3);
						num3++;
					}
				}
			}
			else
			{
				foreach (ActiveUnit item in list_0)
				{
					if (list_1.Contains((Aircraft)item))
					{
						if (Information.IsNothing(mission_0.EmptySlotsList))
						{
							continue;
						}
						foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
						{
							if (!Information.IsNothing(emptySlots.GetReferenceUnit(scenario_0, null)) && emptySlots.GetReferenceUnit(scenario_0, null) == item)
							{
								emptySlots.SetFlight(scenario_0, flight_2, num3);
								num3++;
								break;
							}
						}
					}
					else
					{
						item.SetFlight(flight_2, num3);
						num3++;
					}
				}
			}
			if (bool_4)
			{
				flight_0 = flight_2;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void MoveInvocation(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref List<ActiveUnit> list_0, ref Group group_0, ref List<Aircraft> list_1, ref bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref string string_0, ref float float_0, ref float float_1, ref bool bool_2, bool bool_3, bool bool_4, bool bool_5, ref Mission.Flight flight_0)
	{
		try
		{
			Mission.Flight flight_ = new Mission.Flight();
			Aircraft aircraft = (Aircraft)list_0[0];
			double double_ = 0.0;
			double double_2 = 0.0;
			double double_3 = 0.0;
			double double_4 = 0.0;
			double double_5 = 0.0;
			double double_6 = 0.0;
			double double_7 = 0.0;
			double double_8 = 0.0;
			Strike strike = null;
			foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
			{
				Mission.Flight flight_2 = masterFlight;
				if (aircraft.Int32_0 != flight_2.int_0 || Operators.CompareString(aircraft.AirOps.CurrentHostUnit.ObjectID, flight_2.TakeOffLocation_HostUnitObjectID, TextCompare: false) != 0)
				{
					continue;
				}
				if (flight_2.FlightPlan_Pathfinder_Ingress_1.Count() != 0 || flight_2.UsedByFlight)
				{
					if (flight_2.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
					{
						Mission.Flight flight_3 = null;
						flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_3, Callsigns.ReadProperty(ref mission_0), flight_2.PrimaryTarget, aircraft, _FlightSize_0, bool_3);
						if (mission_0.MissionClass != Mission._MissionClass.Strike)
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								float float_2 = 50f;
								if (!aircraft.Navigator.UpdateDic(ref double_, ref double_2, ref double_3, ref double_4, ref float_2))
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									continue;
								}
								Aircraft_AI aI = aircraft.AI;
								Doctrine._UseUnderwayRefuelAndReplenishment? nullable_ = nullable_0;
								bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
								float float_3 = 0f;
								aI.ExcludeClient(ref flight_, nullable_, launchMissionWithoutTankersInPlace, bool_1: false, bool_2: false, bool_3: false, ref float_3, ref string_0, bool_4: false, bool_5: true, double_, double_2, double_3, double_4, Waypoint.WaypointType.StationStart_Racetrack, Waypoint.TurnRateCategory.HalfStandardRateTurn, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_7: false, bool_8: false);
							}
							else if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								float float_4 = 50f;
								if (!aircraft.Navigator.UpdateDic(ref double_5, ref double_6, ref double_7, ref double_8, ref float_4))
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									continue;
								}
								Aircraft_AI aI2 = aircraft.AI;
								Doctrine._UseUnderwayRefuelAndReplenishment? nullable_2 = nullable_0;
								bool launchMissionWithoutTankersInPlace2 = mission_0.LaunchMissionWithoutTankersInPlace;
								float float_5 = 0f;
								aI2.ExcludeClient(ref flight_, nullable_2, launchMissionWithoutTankersInPlace2, bool_1: false, bool_2: false, bool_3: false, ref float_5, ref string_0, bool_4: false, bool_5: true, double_5, double_6, double_7, double_8, Waypoint.WaypointType.StationStart_FigureEight, Waypoint.TurnRateCategory.FlatTurn, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_7: false, bool_8: false);
							}
							else
							{
								Mission.Flight flight = flight_;
								int int_ = 0;
								int int_2 = 0;
								flight.Copy(ref scenario_0, ref flight_2, ref flight_, bool_0: false, ref mission_0, ref int_, ref int_2, bool_1: false, bool_2: false);
								flight_2.UsedByFlight = true;
								flight_.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref flight_2);
								if (!Information.IsNothing(flight_2.NotificationList) && flight_2.NotificationList.Count > 0)
								{
									ActiveUnit activeUnit = scenario_0.ActiveUnits[flight_.TakeOffLocation_HostUnitObjectID];
									foreach (string notification in flight_2.NotificationList)
									{
										scenario_0.AddMessage(notification, flight_2.Name + " 注意", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
									}
								}
								int num = 1;
								foreach (ActiveUnit item in list_0)
								{
									if (bool_2)
									{
										if (Information.IsNothing(group_0))
										{
											continue;
										}
										foreach (ActiveUnit value in group_0.Units.Values)
										{
											if (value.IsGroupLead())
											{
												value.SetFlight(flight_, 1);
												group_0.Name = "飞行编队" + flight_.Callsign;
											}
											else
											{
												value.SetFlight(flight_, num);
												num++;
											}
										}
									}
									else if (list_1.Contains((Aircraft)item))
									{
										if (Information.IsNothing(mission_0.EmptySlotsList))
										{
											continue;
										}
										foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
										{
											if (!Information.IsNothing(emptySlots.GetReferenceUnit(scenario_0, null)) && emptySlots.GetReferenceUnit(scenario_0, null) == item)
											{
												emptySlots.SetFlight(scenario_0, flight_, num);
												num++;
												break;
											}
										}
									}
									else
									{
										item.SetFlight(flight_, num);
										num++;
									}
								}
							}
						}
						else
						{
							Strike obj = (Strike)mission_0;
							Aircraft_AI aI3 = aircraft.AI;
							ref Contact primaryTarget = ref flight_2.PrimaryTarget;
							int minResponseRadius_Aircraft = obj.MinResponseRadius_Aircraft;
							int maxResponseRadius_Aircraft = obj.MaxResponseRadius_Aircraft;
							Doctrine._UseUnderwayRefuelAndReplenishment? nullable_3 = nullable_0;
							bool launchMissionWithoutTankersInPlace3 = mission_0.LaunchMissionWithoutTankersInPlace;
							Mission._RadarBehaviour radarBehaviour = obj.RadarBehaviour;
							bool usePlanner = obj.UsePlanner;
							float float_6 = 0f;
							aI3.SetupClient(ref scenario_0, ref side_0, ref mission_0, ref flight_, ref primaryTarget, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, nullable_3, launchMissionWithoutTankersInPlace3, radarBehaviour, bool_1: false, bool_2: false, bool_3: false, usePlanner, ref float_6, ref string_0, bool_5: false, ref bool_1, bool_1, ref float_0, ref float_1, bool_8: true, null, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_10: false, bool_11: false);
						}
						if (flight_.FlightPlan.Count() == 0)
						{
							Waypoint[] flightPlan = flight_2.FlightPlan;
							for (int i = 0; i < flightPlan.Length; i = checked(i + 1))
							{
								Waypoint waypoint_ = flightPlan[i];
								Mission.Flight flight7 = flight_;
								Waypoint[] gparam_ = flight7.FlightPlan;
								Doctrine doctrine_ = null;
								ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_, bool_0: true, bool_1: true, ref doctrine_));
								flight7.FlightPlan = gparam_;
							}
						}
						mission_0.AddFlight(ref flight_);
						int num2 = 2;
						if (bool_2)
						{
							foreach (ActiveUnit value2 in group_0.Units.Values)
							{
								if (value2.IsGroupLead())
								{
									value2.SetFlight(flight_, 1);
									group_0.Name = "飞行编队" + flight_.Callsign;
								}
								else
								{
									value2.SetFlight(flight_, num2);
									num2++;
								}
							}
						}
						else
						{
							foreach (ActiveUnit item2 in list_0)
							{
								if (list_1.Contains((Aircraft)item2))
								{
									if (Information.IsNothing(mission_0.EmptySlotsList))
									{
										continue;
									}
									foreach (Mission.EmptyAircraftSlot emptySlots2 in mission_0.EmptySlotsList)
									{
										if (!Information.IsNothing(emptySlots2.GetReferenceUnit(scenario_0, null)) && emptySlots2.GetReferenceUnit(scenario_0, null) == item2)
										{
											emptySlots2.SetFlight(scenario_0, flight_, num2);
											num2++;
											break;
										}
									}
								}
								else
								{
									item2.SetFlight(flight_, num2);
									num2++;
								}
							}
						}
						if (bool_5)
						{
							flight_0 = flight_;
						}
						break;
					}
					flight_ = new Mission.Flight();
					Mission.Flight flight8 = flight_;
					int int_3 = 0;
					int int_4 = 0;
					flight8.Copy(ref scenario_0, ref flight_2, ref flight_, bool_0: false, ref mission_0, ref int_3, ref int_4, bool_1: false, bool_2: false);
					flight_.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref flight_2);
					if (!Information.IsNothing(flight_2.NotificationList) && flight_2.NotificationList.Count > 0)
					{
						ActiveUnit activeUnit2 = scenario_0.ActiveUnits[flight_.TakeOffLocation_HostUnitObjectID];
						foreach (string notification2 in flight_2.NotificationList)
						{
							scenario_0.AddMessage(notification2, flight_2.Name + " 注意", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
						}
					}
					if (mission_0.MissionClass == Mission._MissionClass.Strike)
					{
						strike = (Strike)mission_0;
						if (strike.AttackMethod == Mission._AttackMethod.BananaSplit)
						{
							bool_1 = !bool_1;
						}
					}
					int num3;
					checked
					{
						if (mission_0.MissionClass == Mission._MissionClass.Strike && (Information.IsNothing(strike) || (strike.AttackMethod == Mission._AttackMethod.BananaSplit && !bool_1 && !Information.IsNothing(flight_.FlightPlan_Pathfinder_Ingress_2) && flight_.FlightPlan_Pathfinder_Ingress_2.Count() != 0)))
						{
							if (flight_.FlightPlan_Pathfinder_Ingress_2.Count() > 0 && flight_.FlightPlan.Count() == 0)
							{
								Waypoint[] flightPlan_Pathfinder_Ingress_ = flight_.FlightPlan_Pathfinder_Ingress_2;
								Waypoint[] gparam_2;
								for (int_3 = 0; int_3 < flightPlan_Pathfinder_Ingress_.Length; int_3++)
								{
									Waypoint waypoint_2 = flightPlan_Pathfinder_Ingress_[int_3];
									Mission.Flight flight9 = flight_;
									gparam_2 = flight9.FlightPlan;
									Doctrine doctrine_2 = null;
									ArrayExtensions.Add(ref gparam_2, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: true, bool_1: true, ref doctrine_2));
									flight9.FlightPlan = gparam_2;
								}
								Mission.Flight flight10 = flight_;
								gparam_2 = flight10.FlightPlan_Pathfinder_Ingress_2;
								ArrayExtensions.Clear(ref gparam_2);
								flight10.FlightPlan_Pathfinder_Ingress_2 = gparam_2;
								Mission.Flight flight11 = flight_;
								gparam_2 = flight11.FlightPlan_Pathfinder_Egress_2;
								ArrayExtensions.Clear(ref gparam_2);
								flight11.FlightPlan_Pathfinder_Egress_2 = gparam_2;
								if (!Information.IsNothing(flight_.FlightPlan_Pathfinder_Ingress_1) || flight_.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
								{
									Mission.Flight flight12 = flight_;
									gparam_2 = flight12.FlightPlan_Pathfinder_Ingress_1;
									ArrayExtensions.Clear(ref gparam_2);
									flight12.FlightPlan_Pathfinder_Ingress_1 = gparam_2;
									Mission.Flight flight13 = flight_;
									gparam_2 = flight13.FlightPlan_Pathfinder_Egress_1;
									ArrayExtensions.Clear(ref gparam_2);
									flight13.FlightPlan_Pathfinder_Egress_1 = gparam_2;
								}
							}
						}
						else if (flight_.FlightPlan_Pathfinder_Ingress_1.Count() > 0 && flight_.FlightPlan.Count() == 0)
						{
							Waypoint[] flightPlan_Pathfinder_Ingress_2 = flight_.FlightPlan_Pathfinder_Ingress_1;
							Waypoint[] gparam_3;
							for (int_4 = 0; int_4 < flightPlan_Pathfinder_Ingress_2.Length; int_4++)
							{
								Waypoint waypoint_3 = flightPlan_Pathfinder_Ingress_2[int_4];
								Mission.Flight flight14 = flight_;
								gparam_3 = flight14.FlightPlan;
								Doctrine doctrine_3 = null;
								ArrayExtensions.Add(ref gparam_3, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_3, bool_0: true, bool_1: true, ref doctrine_3));
								flight14.FlightPlan = gparam_3;
							}
							Mission.Flight flight2 = flight_;
							gparam_3 = flight2.FlightPlan_Pathfinder_Ingress_1;
							ArrayExtensions.Clear(ref gparam_3);
							flight2.FlightPlan_Pathfinder_Ingress_1 = gparam_3;
							Mission.Flight flight3 = flight_;
							gparam_3 = flight3.FlightPlan_Pathfinder_Egress_1;
							ArrayExtensions.Clear(ref gparam_3);
							flight3.FlightPlan_Pathfinder_Egress_1 = gparam_3;
							if (!Information.IsNothing(flight_.FlightPlan_Pathfinder_Ingress_2) || flight_.FlightPlan_Pathfinder_Ingress_2.Count() > 0)
							{
								Mission.Flight flight4 = flight_;
								gparam_3 = flight4.FlightPlan_Pathfinder_Ingress_2;
								ArrayExtensions.Clear(ref gparam_3);
								flight4.FlightPlan_Pathfinder_Ingress_2 = gparam_3;
								Mission.Flight flight5 = flight_;
								gparam_3 = flight5.FlightPlan_Pathfinder_Egress_2;
								ArrayExtensions.Clear(ref gparam_3);
								flight5.FlightPlan_Pathfinder_Egress_2 = gparam_3;
							}
						}
						num3 = 2;
					}
					if (bool_2)
					{
						foreach (ActiveUnit value3 in group_0.Units.Values)
						{
							if (value3.IsGroupLead())
							{
								value3.SetFlight(flight_, 1);
								group_0.Name = "飞行编队" + flight_.Callsign;
							}
							else
							{
								value3.SetFlight(flight_, num3);
								num3++;
							}
						}
					}
					else
					{
						foreach (ActiveUnit item3 in list_0)
						{
							if (list_1.Contains((Aircraft)item3))
							{
								if (Information.IsNothing(mission_0.EmptySlotsList))
								{
									continue;
								}
								foreach (Mission.EmptyAircraftSlot emptySlots3 in mission_0.EmptySlotsList)
								{
									if (!Information.IsNothing(emptySlots3.GetReferenceUnit(scenario_0, null)) && emptySlots3.GetReferenceUnit(scenario_0, null) == item3)
									{
										emptySlots3.SetFlight(scenario_0, flight_, num3);
										num3++;
										break;
									}
								}
							}
							else
							{
								item3.SetFlight(flight_, num3);
								num3++;
							}
						}
					}
					if (bool_5)
					{
						flight_0 = flight_;
					}
					break;
				}
				Mission.Flight flight6 = flight_;
				int int_5 = 0;
				int int_6 = 0;
				flight6.Copy(ref scenario_0, ref flight_2, ref flight_, bool_0: false, ref mission_0, ref int_5, ref int_6, bool_1: false, bool_2: false);
				flight_2.UsedByFlight = true;
				flight_.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref flight_2);
				if (!Information.IsNothing(flight_2.NotificationList) && flight_2.NotificationList.Count > 0)
				{
					ActiveUnit activeUnit3 = scenario_0.ActiveUnits[flight_.TakeOffLocation_HostUnitObjectID];
					foreach (string notification3 in flight_2.NotificationList)
					{
						scenario_0.AddMessage(notification3, flight_2.Name + " 注意", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit3.GetLongitude(), activeUnit3.GetLatitude()));
					}
				}
				int num4 = 2;
				foreach (ActiveUnit item4 in list_0)
				{
					if (bool_2)
					{
						if (Information.IsNothing(group_0))
						{
							continue;
						}
						foreach (ActiveUnit value4 in group_0.Units.Values)
						{
							if (value4.IsGroupLead())
							{
								value4.SetFlight(flight_, 1);
								group_0.Name = "飞行编队" + flight_.Callsign;
							}
							else
							{
								value4.SetFlight(flight_, num4);
								num4++;
							}
						}
					}
					else if (list_1.Contains((Aircraft)item4))
					{
						if (Information.IsNothing(mission_0.EmptySlotsList))
						{
							continue;
						}
						foreach (Mission.EmptyAircraftSlot emptySlots4 in mission_0.EmptySlotsList)
						{
							if (!Information.IsNothing(emptySlots4.GetReferenceUnit(scenario_0, null)) && emptySlots4.GetReferenceUnit(scenario_0, null) == item4)
							{
								emptySlots4.SetFlight(scenario_0, flight_, num4);
								num4++;
								break;
							}
						}
					}
					else
					{
						item4.SetFlight(flight_, num4);
						num4++;
					}
				}
				if (bool_5)
				{
					flight_0 = flight_;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void DeleteInvocation(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Aircraft aircraft_0, ref List<Aircraft> list_0, ref bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref string string_0, ref float float_0, ref float float_1, ref bool bool_2, bool bool_3, bool bool_4, bool bool_5, ref Mission.Flight flight_0)
	{
		checked
		{
			try
			{
				Mission.Flight flight_ = new Mission.Flight();
				double double_ = 0.0;
				double double_2 = 0.0;
				double double_3 = 0.0;
				double double_4 = 0.0;
				double double_5 = 0.0;
				double double_6 = 0.0;
				double double_7 = 0.0;
				double double_8 = 0.0;
				foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
				{
					Mission.Flight flight_2 = masterFlight;
					if (aircraft_0.Int32_0 != flight_2.int_0 || Operators.CompareString(aircraft_0.AirOps.CurrentHostUnit.ObjectID, flight_2.TakeOffLocation_HostUnitObjectID, TextCompare: false) != 0)
					{
						continue;
					}
					if (flight_2.FlightPlan_Pathfinder_Ingress_1.Count() != 0 || flight_2.UsedByFlight)
					{
						int int_;
						if (flight_2.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
						{
							Mission.Flight flight_3 = null;
							flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_3, Callsigns.ReadProperty(ref mission_0), flight_2.PrimaryTarget, aircraft_0, _FlightSize_0, bool_3);
							if (mission_0.MissionClass != Mission._MissionClass.Strike)
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									float float_2 = 50f;
									if (!aircraft_0.Navigator.UpdateDic(ref double_, ref double_2, ref double_3, ref double_4, ref float_2))
									{
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										continue;
									}
									Aircraft_AI aI = aircraft_0.AI;
									Doctrine._UseUnderwayRefuelAndReplenishment? nullable_ = nullable_0;
									bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
									float float_3 = 0f;
									aI.ExcludeClient(ref flight_, nullable_, launchMissionWithoutTankersInPlace, bool_1: false, bool_2: false, bool_3: false, ref float_3, ref string_0, bool_4: false, bool_5: true, double_, double_2, double_3, double_4, Waypoint.WaypointType.StationStart_Racetrack, Waypoint.TurnRateCategory.HalfStandardRateTurn, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_7: false, bool_8: false);
								}
								else if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									float float_4 = 50f;
									if (!aircraft_0.Navigator.UpdateDic(ref double_5, ref double_6, ref double_7, ref double_8, ref float_4))
									{
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										continue;
									}
									Aircraft_AI aI2 = aircraft_0.AI;
									Doctrine._UseUnderwayRefuelAndReplenishment? nullable_2 = nullable_0;
									bool launchMissionWithoutTankersInPlace2 = mission_0.LaunchMissionWithoutTankersInPlace;
									float float_5 = 0f;
									aI2.ExcludeClient(ref flight_, nullable_2, launchMissionWithoutTankersInPlace2, bool_1: false, bool_2: false, bool_3: false, ref float_5, ref string_0, bool_4: false, bool_5: true, double_5, double_6, double_7, double_8, Waypoint.WaypointType.StationStart_FigureEight, Waypoint.TurnRateCategory.FlatTurn, bool_4, null, null, bool_7: false, bool_8: true);
								}
								else
								{
									Mission.Flight flight = flight_;
									int_ = 0;
									int int_2 = 0;
									flight.Copy(ref scenario_0, ref flight_2, ref flight_, bool_0: false, ref mission_0, ref int_, ref int_2, bool_1: false, bool_2: false);
									flight_.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref flight_2);
									if (!Information.IsNothing(flight_2.NotificationList) && flight_2.NotificationList.Count > 0)
									{
										ActiveUnit activeUnit = scenario_0.ActiveUnits[flight_.TakeOffLocation_HostUnitObjectID];
										foreach (string notification in flight_2.NotificationList)
										{
											scenario_0.AddMessage(notification, flight_2.Name + " 注意", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
										}
									}
								}
							}
							else
							{
								Strike obj = (Strike)mission_0;
								Aircraft_AI aI3 = aircraft_0.AI;
								ref Contact primaryTarget = ref flight_2.PrimaryTarget;
								int minResponseRadius_Aircraft = obj.MinResponseRadius_Aircraft;
								int maxResponseRadius_Aircraft = obj.MaxResponseRadius_Aircraft;
								Doctrine._UseUnderwayRefuelAndReplenishment? nullable_3 = nullable_0;
								bool launchMissionWithoutTankersInPlace3 = mission_0.LaunchMissionWithoutTankersInPlace;
								Mission._RadarBehaviour radarBehaviour = obj.RadarBehaviour;
								bool usePlanner = obj.UsePlanner;
								float float_6 = 0f;
								aI3.SetupClient(ref scenario_0, ref side_0, ref mission_0, ref flight_, ref primaryTarget, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, nullable_3, launchMissionWithoutTankersInPlace3, radarBehaviour, bool_1: false, bool_2: false, bool_3: false, usePlanner, ref float_6, ref string_0, bool_5: false, ref bool_1, bool_1, ref float_0, ref float_1, bool_8: true, null, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_10: false, bool_11: false);
							}
							if (flight_.FlightPlan.Count() == 0)
							{
								Waypoint[] flightPlan = flight_2.FlightPlan;
								for (int i = 0; i < flightPlan.Length; i++)
								{
									Waypoint waypoint_ = flightPlan[i];
									Mission.Flight flight2 = flight_;
									Waypoint[] gparam_ = flight2.FlightPlan;
									Doctrine doctrine_ = null;
									ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_, bool_0: true, bool_1: true, ref doctrine_));
									flight2.FlightPlan = gparam_;
								}
							}
							mission_0.AddFlight(ref flight_);
							if (bool_2)
							{
								aircraft_0.SetFlight(flight_, 0);
							}
							else if (list_0.Contains(aircraft_0))
							{
								if (!Information.IsNothing(mission_0.EmptySlotsList))
								{
									foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
									{
										if (!Information.IsNothing(emptySlots.GetReferenceUnit(scenario_0, null)) && emptySlots.GetReferenceUnit(scenario_0, null) == aircraft_0)
										{
											emptySlots.SetFlight(scenario_0, flight_, 0);
											break;
										}
									}
								}
							}
							else
							{
								aircraft_0.SetFlight(flight_, 0);
							}
							if (bool_5)
							{
								flight_0 = flight_;
							}
							break;
						}
						flight_ = new Mission.Flight();
						Mission.Flight flight3 = flight_;
						int_ = 0;
						int int_3 = 0;
						flight3.Copy(ref scenario_0, ref flight_2, ref flight_, bool_0: false, ref mission_0, ref int_, ref int_3, bool_1: false, bool_2: false);
						flight_.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref flight_2);
						if (!Information.IsNothing(flight_2.NotificationList) && flight_2.NotificationList.Count > 0)
						{
							ActiveUnit activeUnit2 = scenario_0.ActiveUnits[flight_.TakeOffLocation_HostUnitObjectID];
							foreach (string notification2 in flight_2.NotificationList)
							{
								scenario_0.AddMessage(notification2, flight_2.Name + " 注意", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
							}
						}
						if (flight_.FlightPlan_Pathfinder_Ingress_1.Count() > 0 && flight_.FlightPlan.Count() == 0)
						{
							Waypoint[] flightPlan_Pathfinder_Ingress_ = flight_.FlightPlan_Pathfinder_Ingress_1;
							Waypoint[] gparam_2;
							for (int_3 = 0; int_3 < flightPlan_Pathfinder_Ingress_.Length; int_3++)
							{
								Waypoint waypoint_2 = flightPlan_Pathfinder_Ingress_[int_3];
								Mission.Flight flight4 = flight_;
								gparam_2 = flight4.FlightPlan;
								Doctrine doctrine_2 = null;
								ArrayExtensions.Add(ref gparam_2, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: true, bool_1: true, ref doctrine_2));
								flight4.FlightPlan = gparam_2;
							}
							Mission.Flight flight5 = flight_;
							gparam_2 = flight5.FlightPlan_Pathfinder_Ingress_1;
							ArrayExtensions.Clear(ref gparam_2);
							flight5.FlightPlan_Pathfinder_Ingress_1 = gparam_2;
							Mission.Flight flight6 = flight_;
							gparam_2 = flight6.FlightPlan_Pathfinder_Egress_1;
							ArrayExtensions.Clear(ref gparam_2);
							flight6.FlightPlan_Pathfinder_Egress_1 = gparam_2;
							if (!Information.IsNothing(flight_.FlightPlan_Pathfinder_Ingress_2) || flight_.FlightPlan_Pathfinder_Ingress_2.Count() > 0)
							{
								Mission.Flight flight7 = flight_;
								gparam_2 = flight7.FlightPlan_Pathfinder_Ingress_2;
								ArrayExtensions.Clear(ref gparam_2);
								flight7.FlightPlan_Pathfinder_Ingress_2 = gparam_2;
								Mission.Flight flight8 = flight_;
								gparam_2 = flight8.FlightPlan_Pathfinder_Egress_2;
								ArrayExtensions.Clear(ref gparam_2);
								flight8.FlightPlan_Pathfinder_Egress_2 = gparam_2;
							}
						}
						if (bool_2)
						{
							aircraft_0.SetFlight(flight_, 0);
						}
						else if (list_0.Contains(aircraft_0))
						{
							if (!Information.IsNothing(mission_0.EmptySlotsList))
							{
								foreach (Mission.EmptyAircraftSlot emptySlots2 in mission_0.EmptySlotsList)
								{
									if (!Information.IsNothing(emptySlots2.GetReferenceUnit(scenario_0, null)) && emptySlots2.GetReferenceUnit(scenario_0, null) == aircraft_0)
									{
										emptySlots2.SetFlight(scenario_0, flight_, 0);
										break;
									}
								}
							}
						}
						else
						{
							aircraft_0.SetFlight(flight_, 0);
						}
						if (bool_5)
						{
							flight_0 = flight_;
						}
						break;
					}
					Mission.Flight flight9 = flight_;
					int int_4 = 0;
					int int_5 = 0;
					flight9.Copy(ref scenario_0, ref flight_2, ref flight_, bool_0: false, ref mission_0, ref int_4, ref int_5, bool_1: false, bool_2: false);
					flight_.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref flight_2);
					if (!Information.IsNothing(flight_2.NotificationList) && flight_2.NotificationList.Count > 0)
					{
						ActiveUnit activeUnit3 = scenario_0.ActiveUnits[flight_.TakeOffLocation_HostUnitObjectID];
						foreach (string notification3 in flight_2.NotificationList)
						{
							scenario_0.AddMessage(notification3, flight_.Name + " 注意", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit3.GetLongitude(), activeUnit3.GetLatitude()));
						}
					}
					if (bool_2)
					{
						aircraft_0.SetFlight(flight_, 0);
					}
					else if (list_0.Contains(aircraft_0))
					{
						if (!Information.IsNothing(mission_0.EmptySlotsList))
						{
							foreach (Mission.EmptyAircraftSlot emptySlots3 in mission_0.EmptySlotsList)
							{
								if (!Information.IsNothing(emptySlots3.GetReferenceUnit(scenario_0, null)) && emptySlots3.GetReferenceUnit(scenario_0, null) == aircraft_0)
								{
									emptySlots3.SetFlight(scenario_0, flight_, 0);
									break;
								}
							}
						}
					}
					else
					{
						aircraft_0.SetFlight(flight_, 0);
					}
					flight_2.UsedByFlight = true;
					if (bool_5)
					{
						flight_0 = flight_;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 999999", "");
				WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void AddInvocation(ref Scenario scenario_0, ref Mission mission_0, ref Aircraft aircraft_0, ref List<Aircraft> list_0, ref Mission._FlightSize _FlightSize_0, ref bool bool_1, bool bool_2, bool bool_3, bool bool_4, ref Mission.Flight flight_0)
	{
		try
		{
			Mission.Flight flight_ = null;
			Mission.Flight flight_2 = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_, Callsigns.ReadProperty(ref mission_0), null, aircraft_0, _FlightSize_0, bool_2);
			mission_0.AddFlight(ref flight_2);
			if (bool_1)
			{
				aircraft_0.SetFlight(flight_2, 0);
			}
			else if (list_0.Contains(aircraft_0))
			{
				if (!Information.IsNothing(mission_0.EmptySlotsList))
				{
					foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
					{
						if (!Information.IsNothing(emptySlots.GetReferenceUnit(scenario_0, null)) && emptySlots.GetReferenceUnit(scenario_0, null) == aircraft_0)
						{
							emptySlots.SetFlight(scenario_0, flight_2, 0);
							break;
						}
					}
				}
			}
			else
			{
				aircraft_0.SetFlight(flight_2, 0);
			}
			if (bool_4)
			{
				flight_0 = flight_2;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool DestroyInvocation(ref Scenario scenario_0, ref Side side_0, Mission mission_0, bool bool_1, ref List<ActiveUnit> list_0, ref List<ActiveUnit> list_1, ref List<ActiveUnit> list_2, ref List<ActiveUnit> list_3, ref Mission._GroupSize _GroupSize_0, ref Mission._GroupSize _GroupSize_1, ref bool bool_2, ref bool bool_3, ref List<ActiveUnit> list_4, ref List<ActiveUnit> list_5, ref List<int> list_6)
	{
		try
		{
			ActiveUnit Local_theMissionUnit = null;
			switch (mission_0.MissionClass)
			{
			case Mission._MissionClass.Strike:
			{
				Strike strike = (Strike)mission_0;
				strike = (Strike)mission_0;
				bool flag = strike.TargetCount > 0;
				_GroupSize_0 = strike.GroupSize;
				_GroupSize_1 = strike.Escort_GroupSize;
				bool_2 = strike.UseGroupSizeHardLimit;
				bool_3 = strike.UseGroupSizeHardLimit_Escort;
				switch (strike.Type)
				{
				case Strike.StrikeType.Air_Intercept:
					foreach (ActiveUnit item in list_5)
					{
						Local_theMissionUnit = item;
						if (!Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (Local_theMissionUnit.AI.IsEscort)
						{
							list_1.Add(Local_theMissionUnit);
							continue;
						}
						double num4 = Local_theMissionUnit.Kinematics.TacticalRadius();
						Doctrine._UseShootTourists? shootTourists = Local_theMissionUnit.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
						foreach (Contact contacts_ in side_0.Contacts_List)
						{
							ActiveUnit_AI aI = Local_theMissionUnit.AI;
							string string_ = "";
							int int_ = 0;
							if (aI.ContactIsRelevantToMission(contacts_, mission_0, shootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_) && Local_theMissionUnit.AI.IncludeClient(ref strike, contacts_.GetStance(Local_theMissionUnit.GetUnitSide())))
							{
								Weapon weapon4 = Local_theMissionUnit.Weaponry.RevertConsumer(contacts_);
								if (!Information.IsNothing(weapon4))
								{
									num4 += (double)weapon4.MaxAirRange;
								}
								if ((double)Module_Unit.RangeToUnit_Horiz(Local_theMissionUnit, contacts_) <= num4 && Module_Contact.PostTokenizer(contacts_, side_0, bool_0: false).Count < 2)
								{
									Local_theMissionUnit.AI.PrimaryTarget = contacts_;
									list_0.Add(Local_theMissionUnit);
									break;
								}
							}
						}
					}
					break;
				case Strike.StrikeType.Land_Strike:
					foreach (ActiveUnit item5 in list_5)
					{
						Local_theMissionUnit = item5;
						if (!Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (Local_theMissionUnit.AI.IsEscort)
						{
							list_1.Add(Local_theMissionUnit);
							continue;
						}
						double num3 = Local_theMissionUnit.Kinematics.TacticalRadius();
						Doctrine._UseShootTourists? Local_Doctrine_ShootTourists = Local_theMissionUnit.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
						if (flag)
						{
							foreach (Contact contacts_2 in side_0.Contacts_List)
							{
								if (contacts_2.GetIsSpecificTargetForThisStrike(strike) && Local_theMissionUnit.AI.IncludeClient(ref strike, contacts_2.GetStance(side_0)))
								{
									Weapon weapon3 = Local_theMissionUnit.Weaponry.CustomizeFacade(contacts_2, bool_1: false);
									if (!Information.IsNothing(weapon3))
									{
										num3 += (double)weapon3.MaxLandRange;
									}
									if (!((double)Module_Unit.RangeToUnit_Horiz(Local_theMissionUnit, contacts_2) > num3))
									{
										list_0.Add(Local_theMissionUnit);
										break;
									}
								}
							}
							continue;
						}
						foreach (Contact item6 in side_0.Contacts_List.Where(delegate(Contact theC)
						{
							ActiveUnit_AI aI2 = Local_theMissionUnit.AI;
							Mission mission_ = mission_0;
							string string_2 = "";
							int int_2 = 0;
							return aI2.ContactIsRelevantToMission(theC, mission_, Local_Doctrine_ShootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_2, ref int_2);
						}).ToList())
						{
							if (Local_theMissionUnit.AI.IncludeClient(ref strike, item6.GetStance(side_0)) && !((double)Module_Unit.RangeToUnit_Horiz(Local_theMissionUnit, item6) > num3))
							{
								list_0.Add(Local_theMissionUnit);
								break;
							}
						}
					}
					break;
				case Strike.StrikeType.Maritime_Strike:
					foreach (ActiveUnit item7 in list_5)
					{
						Local_theMissionUnit = item7;
						if (!Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (Local_theMissionUnit.AI.IsEscort)
						{
							list_1.Add(Local_theMissionUnit);
							continue;
						}
						double num2 = Local_theMissionUnit.Kinematics.TacticalRadius();
						Doctrine._UseShootTourists? Local_Doctrine_ShootTourists2 = Local_theMissionUnit.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
						if (flag)
						{
							foreach (Contact contacts_3 in side_0.Contacts_List)
							{
								if (contacts_3.GetIsSpecificTargetForThisStrike(strike) && Local_theMissionUnit.AI.IncludeClient(ref strike, contacts_3.GetStance(side_0)))
								{
									Weapon weapon2 = Local_theMissionUnit.Weaponry.CountFacade(contacts_3, bool_1: false);
									if (!Information.IsNothing(weapon2))
									{
										num2 += (double)weapon2.MaxSurfaceRange;
									}
									if (!((double)Module_Unit.RangeToUnit_Horiz(Local_theMissionUnit, contacts_3) > num2))
									{
										list_0.Add(Local_theMissionUnit);
										break;
									}
								}
							}
							continue;
						}
						foreach (Contact item8 in side_0.Contacts_List.Where(delegate(Contact theC)
						{
							ActiveUnit_AI aI3 = Local_theMissionUnit.AI;
							Mission mission_2 = mission_0;
							Doctrine._UseShootTourists? nullable_ = Local_Doctrine_ShootTourists2;
							string string_3 = "";
							int int_3 = 0;
							return aI3.ContactIsRelevantToMission(theC, mission_2, nullable_, bool_0: false, bool_1: false, bool_2: true, null, ref string_3, ref int_3);
						}).ToList())
						{
							if (Local_theMissionUnit.AI.IncludeClient(ref strike, item8.GetStance(side_0)) && !((double)Module_Unit.RangeToUnit_Horiz(Local_theMissionUnit, item8) > num2))
							{
								list_0.Add(Local_theMissionUnit);
								break;
							}
						}
					}
					break;
				case Strike.StrikeType.Sub_Strike:
					foreach (ActiveUnit item9 in list_5)
					{
						Local_theMissionUnit = item9;
						if (!Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (Local_theMissionUnit.AI.IsEscort)
						{
							list_1.Add(Local_theMissionUnit);
							continue;
						}
						double num18 = Local_theMissionUnit.Kinematics.TacticalRadius();
						Doctrine._UseShootTourists? Local_Doctrine_ShootTourists3 = Local_theMissionUnit.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
						if (flag)
						{
							foreach (Contact contacts_4 in side_0.Contacts_List)
							{
								if (!contacts_4.IsClassifiedFalseTarget && (!Local_theMissionUnit.IsShip || !SeaIceProvider.PrepareWriter(contacts_4.GetLongitude(), contacts_4.GetLatitude())) && contacts_4.GetIsSpecificTargetForThisStrike(strike) && Local_theMissionUnit.AI.IncludeClient(ref strike, contacts_4.GetStance(side_0)))
								{
									Weapon weapon = Local_theMissionUnit.Weaponry.CloneFacade(contacts_4);
									if (!Information.IsNothing(weapon))
									{
										num18 += (double)weapon.MaxSubsurfaceRange;
									}
									if (!((double)Module_Unit.RangeToUnit_Horiz(Local_theMissionUnit, contacts_4) > num18))
									{
										list_0.Add(Local_theMissionUnit);
										break;
									}
								}
							}
							continue;
						}
						foreach (Contact item10 in side_0.Contacts_List.Where(delegate(Contact theC)
						{
							ActiveUnit_AI aI4 = Local_theMissionUnit.AI;
							Mission mission_3 = mission_0;
							Doctrine._UseShootTourists? nullable_2 = Local_Doctrine_ShootTourists3;
							string string_4 = "";
							int int_4 = 0;
							return aI4.ContactIsRelevantToMission(theC, mission_3, nullable_2, bool_0: false, bool_1: false, bool_2: true, null, ref string_4, ref int_4);
						}).ToList())
						{
							if (!item10.IsClassifiedFalseTarget && (!Local_theMissionUnit.IsShip || !SeaIceProvider.PrepareWriter(item10.GetLongitude(), item10.GetLatitude())) && Local_theMissionUnit.AI.IncludeClient(ref strike, item10.GetStance(side_0)) && !((double)Module_Unit.RangeToUnit_Horiz(Local_theMissionUnit, item10) > num18))
							{
								list_0.Add(Local_theMissionUnit);
								break;
							}
						}
					}
					break;
				}
				break;
			}
			case Mission._MissionClass.Patrol:
			{
				Patrol patrol = (Patrol)mission_0;
				int num15 = ((Patrol)mission_0).MinimumNumberOnStation;
				bool oneThirdRule2 = ((Patrol)mission_0).OneThirdRule;
				_GroupSize_0 = patrol.GroupSize;
				bool_2 = patrol.UseGroupSizeHardLimit;
				if (!oneThirdRule2 && num15 <= 0)
				{
					foreach (ActiveUnit item11 in list_5)
					{
						Local_theMissionUnit = item11;
						if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_0.Add(Local_theMissionUnit);
						}
					}
					break;
				}
				foreach (int Local_theDBID4 in list_6)
				{
					List<ActiveUnit> list11 = list_4.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID4).ToList();
					if (oneThirdRule2 && num15 > 0)
					{
						num15 = (int)Math.Round(Math.Max(Math.Ceiling((double)list11.Count / 3.0), num15));
					}
					else if (oneThirdRule2 && num15 == 0)
					{
						num15 = (int)Math.Ceiling((double)list11.Count / 3.0);
					}
					else if (!oneThirdRule2 && num15 > 0)
					{
						num15 = num15;
					}
					List<ActiveUnit> list12 = list11.Where((ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
					List<ActiveUnit> list13 = list_5.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID4).ToList();
					if ((bool_2 && list13.Count < (int)_GroupSize_0) || list13.Count <= 0)
					{
						continue;
					}
					int num16 = num15 - list12.Count;
					if (num16 <= 0)
					{
						continue;
					}
					int num17 = 0;
					while (num16 > 0 && num17 < list13.Count)
					{
						Local_theMissionUnit = list13[num17];
						if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_0.Add(Local_theMissionUnit);
							num16--;
						}
						num17++;
					}
				}
				break;
			}
			case Mission._MissionClass.Support:
			{
				SupportMission supportMission = (SupportMission)mission_0;
				bool oneThirdRule3 = ((SupportMission)mission_0).OneThirdRule;
				_GroupSize_0 = supportMission.GroupSize;
				bool_2 = supportMission.UseGroupSizeHardLimit;
				int num5 = 0;
				if (!oneThirdRule3 && num5 <= 0)
				{
					foreach (ActiveUnit item12 in list_5)
					{
						Local_theMissionUnit = item12;
						if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_0.Add(Local_theMissionUnit);
						}
					}
					break;
				}
				foreach (int Local_theDBID5 in list_6)
				{
					num5 = ((SupportMission)mission_0).MinimumNumberOnStation;
					List<ActiveUnit> list14 = list_4.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID5).ToList();
					if (oneThirdRule3 && num5 > 0)
					{
						num5 = (int)Math.Round(Math.Max(Math.Ceiling((double)list14.Count / 3.0), num5));
					}
					else if (oneThirdRule3 && num5 == 0)
					{
						num5 = (int)Math.Ceiling((double)list14.Count / 3.0);
					}
					else if (!oneThirdRule3 && num5 > 0)
					{
						num5 = num5;
					}
					List<ActiveUnit> list2 = list14.Where((ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
					List<ActiveUnit> list3 = list_5.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID5).ToList();
					if ((bool_2 && list3.Count < (int)_GroupSize_0) || list3.Count <= 0)
					{
						continue;
					}
					int num6 = num5 - list2.Count;
					if (num6 <= 0)
					{
						continue;
					}
					int num7 = 0;
					while (num6 > 0 && num7 < list3.Count)
					{
						Local_theMissionUnit = list3[num7];
						if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_0.Add(Local_theMissionUnit);
							num6--;
						}
						num7++;
					}
				}
				break;
			}
			case Mission._MissionClass.Ferry:
				foreach (ActiveUnit item2 in list_5)
				{
					Local_theMissionUnit = item2;
					if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
					{
						list_0.Add(Local_theMissionUnit);
					}
				}
				break;
			case Mission._MissionClass.Mining:
			{
				MiningMission miningMission = (MiningMission)mission_0;
				bool oneThirdRule4 = ((MiningMission)mission_0).OneThirdRule;
				_GroupSize_0 = miningMission.GroupSize;
				bool_2 = miningMission.UseGroupSizeHardLimit;
				if (oneThirdRule4)
				{
					foreach (int Local_theDBID3 in list_6)
					{
						List<ActiveUnit> list4 = list_4.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID3).ToList();
						List<ActiveUnit> list5 = list_5.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID3).ToList();
						if ((bool_2 && list5.Count < (int)_GroupSize_0) || list5.Count <= 0)
						{
							continue;
						}
						int num8 = (int)Math.Ceiling((double)list4.Count / 3.0);
						List<ActiveUnit> list6 = list4.Where((ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						int num9 = num8 - list6.Count;
						if (num9 <= 0)
						{
							continue;
						}
						int num10 = 0;
						while (num9 > 0 && num10 < list5.Count)
						{
							Local_theMissionUnit = list5[num10];
							if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
							{
								list_0.Add(Local_theMissionUnit);
								num9--;
							}
							num10++;
						}
					}
					break;
				}
				foreach (ActiveUnit item3 in list_5)
				{
					if (item3.AI.IsAllowedToRedeploy_AllChecks)
					{
						list_0.Add(item3);
					}
				}
				break;
			}
			case Mission._MissionClass.MineClearing:
			{
				MineClearingMission mineClearingMission = (MineClearingMission)mission_0;
				bool oneThirdRule = ((MineClearingMission)mission_0).OneThirdRule;
				_GroupSize_0 = mineClearingMission.GroupSize;
				bool_2 = mineClearingMission.UseGroupSizeHardLimit;
				if (oneThirdRule)
				{
					foreach (int Local_theDBID in list_6)
					{
						List<ActiveUnit> list = list_4.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID).ToList();
						List<ActiveUnit> list7 = list_5.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID).ToList();
						if ((bool_2 && list7.Count < (int)_GroupSize_0) || list7.Count <= 0)
						{
							continue;
						}
						int num = (int)Math.Ceiling((double)list.Count / 3.0);
						List<ActiveUnit> list8 = list.Where((ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						int num11 = num - list8.Count;
						if (num11 <= 0)
						{
							continue;
						}
						int num12 = 0;
						while (num11 > 0 && num12 < list7.Count)
						{
							Local_theMissionUnit = list7[num12];
							if (!Information.IsNothing(Local_theMissionUnit))
							{
								if (Local_theMissionUnit.IsSubmarine && (((Submarine)Local_theMissionUnit).Type == Submarine._SubmarineType.ROV || ((Submarine)Local_theMissionUnit).Type == Submarine._SubmarineType.UUV))
								{
									try
									{
										if (Local_theMissionUnit.DockingOps.CurrentHostUnit.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_1nm_Buffered, ref mineClearingMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
										{
											list_0.Add(Local_theMissionUnit);
											num11--;
										}
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception exception_ = ex;
										exception_?.Data.Add("Error at 200493", exception_.Message);
										WriteExceptionsToLog(ref exception_);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
								else if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
								{
									list_0.Add(Local_theMissionUnit);
									num11--;
								}
							}
							num12++;
						}
					}
					break;
				}
				List<ActiveUnit> list9 = new List<ActiveUnit>();
				List<int> list10 = new List<int>();
				foreach (ActiveUnit item4 in list_5)
				{
					if (item4.IsSubmarine && (((Submarine)item4).Type == Submarine._SubmarineType.ROV || ((Submarine)item4).Type == Submarine._SubmarineType.UUV))
					{
						list9.Add(item4);
						if (!list10.Contains(item4.DBID))
						{
							list10.Add(item4.DBID);
						}
					}
					else if (!Information.IsNothing(Local_theMissionUnit) && Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
					{
						list_0.Add(Local_theMissionUnit);
					}
				}
				if (list9.Count <= 0)
				{
					break;
				}
				foreach (int Local_theDBID2 in list10)
				{
					List<ActiveUnit> source = list_4.Where((ActiveUnit theUnit) => theUnit.DBID == Local_theDBID2).ToList();
					IEnumerable<ActiveUnit> source2 = source.Where((ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
					int num13 = (int)Math.Ceiling((double)source.Count() / 3.0) - source2.Count();
					if (num13 <= 0)
					{
						continue;
					}
					int num14 = 0;
					while (num13 > 0 && num14 < list9.Count)
					{
						if (list9[num14].DockingOps.CurrentHostUnit.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_1nm_Buffered, ref mineClearingMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
						{
							if (!Information.IsNothing(list9[num14]))
							{
								list_0.Add(list9[num14]);
							}
							num13--;
						}
						num14++;
					}
				}
				break;
			}
			}
			return true;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool ComputeInvocation(ref Scenario scenario_0, ref Side side_0, object object_0, bool bool_1, ref List<ActiveUnit> list_0, ref List<ActiveUnit> list_1, ref List<ActiveUnit> list_2, ref List<ActiveUnit> list_3, ref Mission._GroupSize _GroupSize_0, ref Mission._GroupSize _GroupSize_1, ref bool bool_2, ref bool bool_3, ref List<ActiveUnit> list_4)
	{
		try
		{
			int num = 0;
			List<Group> list = new List<Group>();
			foreach (ActiveUnit Local_theShipSubtHost in list_4)
			{
				int num2 = 0;
				int num3 = 0;
				IEnumerable<ActiveUnit> enumerable = list_0.Where((ActiveUnit theUnit) => theUnit.DockingOps.CurrentHostUnit == Local_theShipSubtHost);
				IEnumerable<ActiveUnit> enumerable2 = list_1.Where((ActiveUnit theUnit) => theUnit.DockingOps.CurrentHostUnit == Local_theShipSubtHost);
				if (enumerable.Count() > 0)
				{
					if ((enumerable.Count() < _GroupSize_0) & bool_2)
					{
						if (enumerable.Count() < _GroupSize_0 && ((Mission)object_0).TimeSincePlayerNotification == 1)
						{
							scenario_0.AddMessage("任务" + ((ScenarioObject)object_0).Name + " 舰船/潜艇在" + Local_theShipSubtHost.Name + " 无法部署。舰船数量不满足编队最小舰船数量。请重新设置。", ((ScenarioObject)object_0).Name + " 无法部署。", LoggedMessage.MessageType.DockingOps, 0, null, side_0);
						}
					}
					else if (_GroupSize_0 <= 1)
					{
						foreach (ActiveUnit item3 in enumerable)
						{
							list_2.Add(item3);
						}
					}
					else
					{
						int num4 = enumerable.Count();
						while (true)
						{
							if (!bool_2)
							{
								if (num4 == 0)
								{
									break;
								}
							}
							else if (num4 < _GroupSize_0)
							{
								break;
							}
							List<ActiveUnit> list2 = new List<ActiveUnit>();
							int num5 = _GroupSize_0;
							for (int i = 1; i <= num5; i++)
							{
								if (num2 >= enumerable.Count())
								{
									break;
								}
								if (!Information.IsNothing(enumerable.ElementAtOrDefault(num2)))
								{
									list2.Add(enumerable.ElementAtOrDefault(num2));
									list_2.Add(enumerable.ElementAtOrDefault(num2));
									num++;
									num4--;
									num2++;
								}
							}
							Group item = new Group(ref scenario_0, ref side_0, list2, bool_0: false, null, (Mission)object_0);
							list.Add(item);
						}
					}
				}
				if (Information.IsNothing(enumerable2) || enumerable2.Count() <= 0)
				{
					continue;
				}
				if ((enumerable2.Count() < _GroupSize_1) & bool_3)
				{
					if (enumerable2.Count() < _GroupSize_1 && ((Mission)object_0).TimeSincePlayerNotification == 1)
					{
						scenario_0.AddMessage("任务" + ((ScenarioObject)object_0).Name + " 舰船/潜艇在" + Local_theShipSubtHost.Name + " 无法部署。舰船数量不满足编队最小舰船数量。请重新设置。", ((ScenarioObject)object_0).Name + " 无法部署。", LoggedMessage.MessageType.DockingOps, 0, null, side_0);
					}
					continue;
				}
				if (_GroupSize_1 <= 1)
				{
					foreach (ActiveUnit item4 in enumerable2)
					{
						list_3.Add(item4);
					}
					continue;
				}
				int num6 = enumerable2.Count();
				while (true)
				{
					if (!bool_3)
					{
						if (num6 == 0)
						{
							break;
						}
					}
					else if (num6 < _GroupSize_1)
					{
						break;
					}
					List<ActiveUnit> list3 = new List<ActiveUnit>();
					int num7 = _GroupSize_1;
					for (int j = 1; j <= num7; j++)
					{
						if (num3 >= enumerable2.Count())
						{
							break;
						}
						if (!Information.IsNothing(enumerable2.ElementAtOrDefault(num3)))
						{
							list3.Add(enumerable2.ElementAtOrDefault(num3));
							list_3.Add(enumerable2.ElementAtOrDefault(num3));
							num++;
							num6--;
							num3++;
						}
					}
					Group item2 = new Group(ref scenario_0, ref side_0, list3, bool_0: false, null, (Mission)object_0);
					list.Add(item2);
				}
			}
			foreach (Group item5 in list)
			{
				if (item5.Units.Values.Count == 1)
				{
					item5.Units.Values.ElementAtOrDefault(0).SetParentGroup(bool_0: true, null);
					item5.Destroy(bool_0: false, bool_1: false, bool_2: false, "Group destroyed by mission logic");
				}
			}
			foreach (ActiveUnit item6 in list_3)
			{
				if (item6.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
				{
					item6.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
				}
			}
			foreach (ActiveUnit item7 in list_2)
			{
				if (item7.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
				{
					item7.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool PatchInvocation(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref List<Aircraft> list_0, ref List<Aircraft> list_1, int? nullable_0, Mission._FlightSize _FlightSize_0)
	{
		if (list_0.Count == list_1.Count)
		{
			if (nullable_0.HasValue)
			{
				int count = list_0.Count;
				if ((nullable_0.HasValue ? new bool?(count < nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					Scenario scenario = scenario_0;
					string[] array = new string[7]
					{
						"***警告***可用于任务的飞机总数：",
						mission_0.Name,
						" (",
						Conversions.ToString(list_0.Count),
						"）小于触发任务所需的最小飞机数量（",
						null,
						null
					};
					int? num = nullable_0;
					array[5] = ((num.HasValue ? new bool?(num.GetValueOrDefault() == int.MaxValue) : null).GetValueOrDefault() ? "All" : nullable_0.ToString());
					array[6] = "）。这个任务永远不会起飞。从任务中删除飞机。";
					scenario.AddMessage(string.Concat(array), mission_0.Name + " 无法开始；移除其飞机", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
					foreach (Aircraft item in list_0)
					{
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
						item.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
					}
					return false;
				}
			}
			if (!nullable_0.HasValue && list_0.Count < _FlightSize_0 && mission_0.UseFlightSizeHardLimit)
			{
				scenario_0.AddMessage("***警告***可用于任务的飞机总数：" + mission_0.Name + " (" + Conversions.ToString(list_0.Count) + "）小于指定的飞行编队尺寸（" + _FlightSize_0.value + "）或触发任务所需的最小飞机数量。这个任务永远不会起飞。从任务中删除飞机。", mission_0.Name + " 无法开始；移除其飞机", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
				foreach (Aircraft item2 in list_0)
				{
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
					item2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
				}
				return false;
			}
		}
		return true;
	}

	public static bool CanIssueOrdersToThisUnit(Side side_0, Module_Unit.Unit unit_0, bool bool_1, ref string string_0, string string_1)
	{
		try
		{
			if (unit_0.IsActiveUnit)
			{
				if (Module_Unit.AwakeTokenizer(unit_0))
				{
					return false;
				}
				if (unit_0.GetUnitSide() == side_0)
				{
					if (!string.IsNullOrEmpty(string_1) && Operators.CompareString(unit_0.ObjectID, string_1, TextCompare: false) == 0)
					{
						return true;
					}
					if (((ActiveUnit)unit_0).CommStuff.IsConnectedToSideNetwork)
					{
						if (unit_0.IsGroup)
						{
							foreach (ActiveUnit value in ((Group)unit_0).Units.Values)
							{
								string string_2 = null;
								if (CanIssueOrdersToThisUnit(side_0, value, bool_1, ref string_2, string_1))
								{
									return true;
								}
							}
							string_0 = "无法向此组的任何成员发出命令";
							return false;
						}
						if (unit_0.IsWeapon)
						{
							Weapon weapon = (Weapon)unit_0;
							if (weapon.IsPalletWeapon)
							{
								return true;
							}
							if (weapon.DataLinkParent == null)
							{
								string_0 = "Weapon does not have an active datalink";
								return false;
							}
							if (!bool_1 && weapon.Type == Weapon._WeaponType.Sonobuoy)
							{
								return false;
							}
							if (weapon.isLoiterCapable)
							{
								return true;
							}
							if (weapon.IsAAW)
							{
								return false;
							}
						}
						if (((ActiveUnit)unit_0).IsExhausted())
						{
							string_0 = "Unit is Returning To Base due to exhaustion";
							return false;
						}
						return true;
					}
					string_0 = "单元失去通讯连接";
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
			exception_?.Data.Add("Error at 200361", exception_.Message);
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static void PaddedTimeAndDateString(ref DateTime dateTime_0, ref string string_0)
	{
		PaddedDateString(ref dateTime_0, ref string_0, bool_1: true);
		PaddedTimeString(ref dateTime_0, ref string_0);
	}

	public static void PaddedTimeString(ref DateTime dateTime_0, ref string string_0)
	{
		if (dateTime_0.Hour < 10)
		{
			string_0 = string_0 + "0" + dateTime_0.Hour + ":";
		}
		else
		{
			string_0 = string_0 + dateTime_0.Hour + ":";
		}
		if (dateTime_0.Minute < 10)
		{
			string_0 = string_0 + "0" + dateTime_0.Minute + ":";
		}
		else
		{
			string_0 = string_0 + dateTime_0.Minute + ":";
		}
		if (dateTime_0.Second < 10)
		{
			string_0 = string_0 + "0" + dateTime_0.Second;
		}
		else
		{
			string_0 += dateTime_0.Second;
		}
	}

	public static void PaddedDateString(ref DateTime dateTime_0, ref string string_0, bool bool_1)
	{
		string_0 = dateTime_0.Year + "-";
		if (dateTime_0.Month < 10)
		{
			string_0 = string_0 + "0" + dateTime_0.Month + "-";
		}
		else
		{
			string_0 = string_0 + dateTime_0.Month + "-";
		}
		if (dateTime_0.Day < 10)
		{
			string_0 = string_0 + "0" + dateTime_0.Day;
		}
		else
		{
			string_0 += dateTime_0.Day;
		}
		if (bool_1)
		{
			string_0 += ", ";
		}
	}

	internal static string SelectInvocation(object object_0, Scenario scenario_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("分方：" + ((Side)object_0).Name + "\r\n===========================================================\r\n\r\n");
		stringBuilder.Append("战损:\r\n-------------------------------\r\n");
		List<KeyValuePair<string, HashSet<string>>> list;
		try
		{
			list = ((Side)object_0).AAR.Losses.OrderBy((KeyValuePair<string, HashSet<string>> theKVP) => CallInvocation(scenario_0, theKVP)).ToList();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			list = ((Side)object_0).AAR.Losses.OrderBy((KeyValuePair<string, HashSet<string>> theKVP) => CallInvocation(scenario_0, theKVP)).ToList();
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (KeyValuePair<string, HashSet<string>> item in list)
			{
				stringBuilder.Append(Conversions.ToString(item.Value.Count) + "x " + CallInvocation(scenario_0, item) + "\r\n");
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		stringBuilder.Append("\r\n\r\n消耗:\r\n------------------\r\n");
		List<KeyValuePair<int, int>> list2;
		try
		{
			list2 = ((Side)object_0).AAR.Expenditures.OrderBy((KeyValuePair<int, int> theKVP) => LogoutInvocation(scenario_0, theKVP)).ToList();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			list2 = ((Side)object_0).AAR.Expenditures.OrderBy((KeyValuePair<int, int> theKVP) => LogoutInvocation(scenario_0, theKVP)).ToList();
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (KeyValuePair<int, int> item2 in list2)
			{
				stringBuilder.Append(item2.Value + "x " + LogoutInvocation(scenario_0, item2) + "\r\n");
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			ProjectData.ClearProjectError();
		}
		stringBuilder.Append("\r\n\r\n\r\n");
		return stringBuilder.ToString();
	}

	private static string CallInvocation(Scenario scenario_0, KeyValuePair<string, HashSet<string>> keyValuePair_0)
	{
		string[] array = keyValuePair_0.Key.ToString().Split('_');
		string result = "";
		try
		{
			switch (array[0].ToString())
			{
			case "Submarine":
			{
				DataRow[] array4 = scenario_0.Cache_Subs_DT.Select("ID=" + array[1]);
				if (array4 != null && array4.Count() > 0)
				{
					result = Misc.ReadRequest(array4[0]["Name"].ToString());
				}
				break;
			}
			case "Ship":
			{
				DataRow[] array7 = scenario_0.Cache_Ships_DT.Select("ID=" + array[1]);
				if (array7 != null && array7.Count() > 0)
				{
					result = Misc.ReadRequest(array7[0]["Name"].ToString());
				}
				break;
			}
			case "GroundUnit":
			{
				DataRow[] array6 = scenario_0.Cache_GroundUnits_DT.Select("ID=" + array[1]);
				if (array6 != null && array6.Count() > 0)
				{
					result = Misc.ReadRequest(array6[0]["Name"].ToString());
				}
				break;
			}
			case "FacilityAimpoint":
			{
				DataRow[] array3 = null;
				if (Operators.CompareString(array[1], "0", TextCompare: false) == 0)
				{
					result = "不可识别的陆地目标点  - 对不起！";
				}
				else if (array3 != null && array3.Count() > 0)
				{
					result = Misc.ReadRequest(DBFunctions.GetMountName(Conversions.ToInteger(array[1]), ref scenario_0));
				}
				break;
			}
			case "Facility":
			{
				DataRow[] array5 = scenario_0.Cache_Facilities_DT.Select("ID=" + array[1]);
				if (array5 != null && array5.Count() > 0)
				{
					result = Misc.ReadRequest(array5[0]["Name"].ToString());
				}
				break;
			}
			case "Aircraft":
			{
				DataRow[] array2 = scenario_0.Cache_Aircraft_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.ReadRequest(array2[0]["Name"].ToString());
				}
				break;
			}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 20036345354", exception_.Message);
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	private static string LogoutInvocation(Scenario scenario_0, KeyValuePair<int, int> keyValuePair_0)
	{
		return Misc.ReadRequest(scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(keyValuePair_0.Key))[0]["Name"].ToString());
	}

	public static void ProcessAndTruncateMessageLog(Scenario scenario_0, bool bool_1 = false, string string_0 = "")
	{
		try
		{
			if (bool_1 && scenario_0.SecondIsChangingOnThisPulse)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (LoggedMessage item in ViewInvocation(scenario_0))
				{
					string text = ((item.Side == null) ? "" : ("[" + item.Side.Name + "] "));
					stringBuilder.Append(item.Timestamp.ToString() + " - " + text + item.Text + "\r\n\r\n");
					item.ProcessedByClient = true;
				}
				StreamWriter obj = (string.IsNullOrEmpty(string_0) ? File.AppendText(Path.Combine(LogsPath, scenario_0.GameContext.AALog_Name + ".txt")) : File.AppendText(string_0));
				obj.Write(stringBuilder.ToString());
				obj.Close();
			}
			List<LoggedMessage> list = (from theM in scenario_0.MessageLog
				orderby theM.Timestamp descending, theM.Increment descending
				select theM).ToList();
			List<LoggedMessage> list2 = new List<LoggedMessage>();
			int count = list.Count;
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			int num;
			foreach (Side side in array)
			{
				num = 0;
				int num2 = count - 1;
				for (int i = 0; i <= num2; i++)
				{
					LoggedMessage loggedMessage = list[i];
					if (loggedMessage.Side != null && loggedMessage.Side == side)
					{
						num++;
						if (num > 500)
						{
							list2.Add(loggedMessage);
						}
					}
				}
			}
			num = 0;
			int num3 = count - 1;
			for (int j = 0; j <= num3; j++)
			{
				LoggedMessage loggedMessage2 = list[j];
				if (loggedMessage2.Side == null && num > 500)
				{
					list2.Add(loggedMessage2);
				}
			}
			if (list2.Count <= 0)
			{
				return;
			}
			foreach (LoggedMessage item2 in list2.ToList())
			{
				scenario_0.MessageLog.Remove(item2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200367", exception_.Message);
			WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static List<LoggedMessage> ViewInvocation(Scenario scenario)
	{
		int count = scenario.MessageLog.Count;
		m_DicDic.Clear();
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				LoggedMessage loggedMessage = scenario.MessageLog[i];
				if (loggedMessage != null && !loggedMessage.ProcessedByClient)
				{
					m_DicDic.Add(loggedMessage);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		return m_DicDic;
	}
}
