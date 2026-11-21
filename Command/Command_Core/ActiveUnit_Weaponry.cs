using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Command.Specifications;
using Command_Core.DAL;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Weaponry
{
	public delegate void FiredWeaponEventHandler(Scenario theScen, ActiveUnit theFiringUnit, Weapon theWeapon);

	public sealed class WeaponSalvoWpnQty
	{
		public int? WeaponQty_ToFire;

		public int? WeaponQty_Available;

		public WeaponSalvoWpnQty(int? nullable_0, int? nullable_1)
		{
			WeaponQty_ToFire = nullable_0;
			WeaponQty_Available = nullable_1;
		}
	}

	public enum WeaponPrefireChecklistEvaluation
	{
		OK,
		NeedHighQualityLocalTrackOrCEC,
		OutsideBoresightLimits,
		OtherNegative,
		WithinMinimumRange
	}

	private sealed class PrototypeCallbackCandidate
	{
		public float _BridgeComparator;

		public ActiveUnit invocationComparator;

		public object m_ClassComparator;

		public object _RequestComparator;

		public object _ValueComparator;

		public PrototypeCallbackCandidate(ref float float_0, ActiveUnit activeUnit_0, ref WeaponRec weaponRec_0, ref ActiveUnit activeUnit_1, ref Mount mount_0)
		{
			_BridgeComparator = float_0;
			invocationComparator = activeUnit_0;
			m_ClassComparator = weaponRec_0;
			_RequestComparator = activeUnit_1;
			_ValueComparator = mount_0;
		}
	}

	public enum PointDefenceResult
	{
		Undefined,
		WeaponDefeated,
		WeaponSurvived
	}

	public enum DLZResultEnum
	{
		None,
		Success,
		Fail_OutOfEnergy,
		Fail_OutsideValidAltitudeEnvelope,
		Fail_CannotPlotIntercept,
		Fail_TargetNotDefined,
		Fail_ExhaustedConsumables,
		Fail_CodeError,
		Fail_TargetWillImpactBeforeIntercept,
		Fail_InsideMinimumRange,
		Fail_MAXRangeWRA,
		Fail_ScenarioDuration
	}

	public enum AssumedDLZTargetBehavior
	{
		ContinuesAsCurrent,
		RunStraightAway
	}

	[CompilerGenerated]
	private sealed class RoleCollectionRecord
	{
		public Weapon Local_PalletWeapon;

		public Func<WeaponRec, bool> _003C_003E9__0;

		internal bool CloneInterruptibleTag(WeaponRec thePWR)
		{
			return thePWR.int_0 == Local_PalletWeapon.DBID;
		}
	}

	[CompilerGenerated]
	private sealed class FieldExpressionDic
	{
		public Weapon Local_PalletWeapon;

		public Func<WeaponRec, bool> _003C_003E9__0;

		internal bool ConnectInterruptibleTag(WeaponRec thePWR)
		{
			return thePWR.int_0 == Local_PalletWeapon.DBID;
		}
	}

	[CompilerGenerated]
	private sealed class AdapterRegistryFilter
	{
		public int Local_theWeaponDBID;

		public ActiveUnit_Weaponry Me;

		public Contact Local_theTarget;

		public ActiveUnit_Weaponry _003C_003E4__this;

		public Func<Warhead, bool> _003C_003E9__0;

		public Func<Warhead, bool> _003C_003E9__1;

		public Func<Warhead, bool> _003C_003E9__2;

		public Func<Warhead, bool> _003C_003E9__3;

		public Func<WeaponSalvo.Shooter, bool> _003C_003E9__9;

		public Func<WeaponSalvo.Shooter, bool> _003C_003E9__10;

		public Func<WeaponSalvo, bool> _003C_003E9__11;

		public Func<WeaponSalvo.Shooter, bool> _003C_003E9__12;

		public Func<WeaponSalvo, bool> _003C_003E9__13;

		public Func<WeaponSalvo.Shooter, bool> _003C_003E9__14;

		internal bool MoveInterruptibleTag(Warhead x)
		{
			return x.DP == (float)Local_theWeaponDBID;
		}

		internal bool DeleteInterruptibleTag(Warhead x)
		{
			return x.DP == (float)Local_theWeaponDBID;
		}

		internal bool AddInterruptibleTag(Warhead x)
		{
			return x.DP == (float)Local_theWeaponDBID;
		}

		internal bool DestroyInterruptibleTag(Warhead x)
		{
			return x.DP == (float)Local_theWeaponDBID;
		}

		internal int ComputeInterruptibleTag(WeaponRec theRec)
		{
			Weapon weapon_ = theRec.GetReferenceWeapon(Me.myUnit.ParentScen);
			return Me.WeaponSuitabilityForThisTarget(ref weapon_, ref Local_theTarget, bool_1: false);
		}

		internal float PatchInterruptibleTag(WeaponRec theRec0)
		{
			return theRec0.GetReferenceWeapon(Me.myUnit.ParentScen).GetMaxRangeForThisTarget(Me.myUnit, Local_theTarget, bool_0: true, Me.myUnit.Doctrine, bool_1: false);
		}

		internal bool SelectInterruptibleTag(WeaponSalvo.Shooter theSh)
		{
			return Operators.CompareString(theSh.ShooterObjectID, _003C_003E4__this.myUnit.ObjectID, TextCompare: false) == 0;
		}

		internal bool CallInterruptibleTag(WeaponSalvo.Shooter theSh)
		{
			return Operators.CompareString(theSh.ShooterObjectID, _003C_003E4__this.myUnit.ObjectID, TextCompare: false) == 0;
		}

		internal bool LogoutInterruptibleTag(WeaponSalvo theS)
		{
			return !theS.GetReferenceWeapon(_003C_003E4__this.myUnit.ParentScen).IsPalletWeapon;
		}

		internal bool ViewInterruptibleTag(WeaponSalvo.Shooter theSh)
		{
			return Operators.CompareString(theSh.ShooterObjectID, _003C_003E4__this.myUnit.ObjectID, TextCompare: false) == 0;
		}

		internal bool ValidateInterruptibleTag(WeaponSalvo theS)
		{
			return !theS.GetReferenceWeapon(_003C_003E4__this.myUnit.ParentScen).IsPalletWeapon;
		}

		internal bool LoginInterruptibleTag(WeaponSalvo.Shooter theSh)
		{
			return Operators.CompareString(theSh.ShooterObjectID, _003C_003E4__this.myUnit.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class QueueExpressionDic
	{
		public ActiveUnit_Weaponry _003C_003E4__this;

		public Weapon theWeapon;

		public Contact theTarget;

		internal bool GetInterruptibleTag(KeyValuePair<Tuple<ActiveUnit, int, ScenarioObject>, double> theRes)
		{
			return (Operators.CompareString(theRes.Key.Item1.ObjectID, _003C_003E4__this.myUnit.ObjectID, TextCompare: false) == 0) & (theRes.Key.Item2 == theWeapon.DBID) & (Operators.CompareString(theRes.Key.Item3.ObjectID, theTarget.ObjectID, TextCompare: false) == 0);
		}
	}

	[CompilerGenerated]
	private sealed class TokenizerComparator
	{
		public ActiveUnit_Weaponry _003C_003E4__this;

		public Contact theTarget;

		internal float WriteInterruptibleTag(Weapon theW)
		{
			return theW.GetMaxRangeForThisTarget(_003C_003E4__this.myUnit, theTarget, bool_0: true, _003C_003E4__this.myUnit.Doctrine, bool_1: false);
		}
	}

	[CompilerGenerated]
	private sealed class RegistryCollectionTask
	{
		public ActiveUnit_Weaponry Me;

		public Contact Local_theTarget;

		public bool Local_CheckIfWithinRange;

		internal int NewInterruptibleTag(Weapon theW)
		{
			Weapon weapon_ = theW;
			return Me.WeaponSuitabilityForThisTarget(ref weapon_, ref Local_theTarget, Local_CheckIfWithinRange);
		}
	}

	[CompilerGenerated]
	private sealed class FilterRuleWatcher
	{
		public string Local_TargetObjectID;

		internal bool PushInterruptibleTag(Contact theC)
		{
			return Operators.CompareString(theC.ObjectID, Local_TargetObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class PrototypeThreadBridge
	{
		public ActiveUnit_Weaponry Me;

		public float Local_MaxSlantRange;

		public bool Local_InterceptPossible;

		internal void InvokeInterruptibleTag(TrajectoryPoint thePoint, ParallelLoopState loopstate)
		{
			if (Module_Unit.RangeToPoint_Slant(Me.myUnit, thePoint) < Local_MaxSlantRange)
			{
				Local_InterceptPossible = true;
				loopstate.Stop();
			}
		}
	}

	[CompilerGenerated]
	private sealed class StubComparator
	{
		public Contact contact_0;

		public Weapon weapon_6;

		public bool result;

		internal void SetupInterruptibleTag(ActiveUnit theAU, ParallelLoopState loopstate)
		{
			if (theAU.Sensory.PostDic(contact_0) && weapon_6.CommStuff.CommDeviceToConnectToThisUnit(weapon_6.Comms_ReadOnly, theAU) != null)
			{
				result = true;
				loopstate.Stop();
			}
		}
	}

	[CompilerGenerated]
	private sealed class SchemaRegistryFilter
	{
		public Contact Local_theTarget;

		public Func<Contact, double> _003C_003E9__0;

		internal double ExcludeInterruptibleTag(Contact theC)
		{
			return Geodesic_Haversine.Distance_Horiz_Approx_nm(theC.GetLatitude(), theC.GetLongitude(), Local_theTarget.GetLatitude(), Local_theTarget.GetLongitude());
		}
	}

	[CompilerGenerated]
	private sealed class WriterComparator
	{
		public Sensor Local_theSensor;

		internal float IncludeInterruptibleTag(Module_Unit.Unit theUnit)
		{
			return Module_Unit.RangeToUnit_Horiz(Local_theSensor.ParentPlatform, theUnit);
		}
	}

	[CompilerGenerated]
	private sealed class SpecificationComparator
	{
		public float Local_BearingToNearestTarget;

		internal int SearchInterruptibleTag(int x, int y)
		{
			if (!(Math.Abs((float)x - Local_BearingToNearestTarget) < Math.Abs((float)y - Local_BearingToNearestTarget)))
			{
				return y;
			}
			return x;
		}
	}

	[CompilerGenerated]
	private sealed class SystemConfigObject
	{
		public ActiveUnit Local_FiringUnit;

		internal float EnableInterruptibleTag(ActiveUnit theU)
		{
			return Module_Unit.RangeToUnit_Horiz(Local_FiringUnit, theU);
		}
	}

	private bool m_MappingWrapper;

	private bool m_MockWrapper;

	protected ActiveUnit myUnit;

	[CompilerGenerated]
	[AccessedThroughProperty("WeaponAssignments")]
	private List<WeaponAssignment> m_TagWrapper;

	private ConcurrentDictionary<Tuple<int, string>, Tuple<DLZResultEnum, float>> _FieldWrapper;

	internal HashSet<Tuple<int, string>> queueWrapper;

	private bool regWrapper;

	public bool LayChaffStream;

	public bool bool_0;

	private ConcurrentDictionary<Tuple<ActiveUnit, int, ScenarioObject>, double> m_ParamWrapper;

	protected List<Weapon> _AllDistinctWeaponsAboard_Actual;

	private List<Weapon> _PageWrapper;

	[ThreadStatic]
	private List<WeaponSalvo> m_RulesWrapper;

	[ThreadStatic]
	private Dictionary<int, WeaponSalvoWpnQty> m_MethodWrapper;

	[ThreadStatic]
	private List<WeaponRec> _ServiceWrapper;

	[ThreadStatic]
	private StringBuilder systemWrapper;

	[ThreadStatic]
	private List<WeaponSalvo> candidateWrapper;

	[ThreadStatic]
	private List<WeaponSalvo> _BaseWrapper;

	[ThreadStatic]
	private List<WeaponRec> policyWrapper;

	[ThreadStatic]
	private List<WeaponRec> _BroadcasterWrapper;

	[ThreadStatic]
	private List<WeaponRec> identifierWrapper;

	[ThreadStatic]
	private List<WeaponRec> printerWrapper;

	private Weapon parserWrapper;

	private bool _AlgoWrapper;

	private Weapon _DatabaseWrapper;

	private Weapon interceptorWrapper;

	private bool m_MessageWrapper;

	private bool m_ProductWrapper;

	private Weapon m_AnnotationWrapper;

	private Weapon _IteratorWrapper;

	private bool m_InitializerWrapper;

	private bool roleWrapper;

	private Weapon factoryWrapper;

	private bool attributeWrapper;

	[CompilerGenerated]
	private bool m_EventWrapper;

	public static int DLZ_Nm_tolerance;

	public static List<DLZCAche> DLZCacheList;

	[CompilerGenerated]
	private static FiredWeaponEventHandler globalWrapper;

	protected virtual List<WeaponAssignment> WeaponAssignments
	{
		[CompilerGenerated]
		get
		{
			return m_TagWrapper;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TagWrapper = value;
		}
	}

	public ConcurrentDictionary<Tuple<int, string>, Tuple<DLZResultEnum, float>> DLZ_ResultsCache
	{
		get
		{
			return _FieldWrapper;
		}
		set
		{
			_FieldWrapper = value;
		}
	}

	public ConcurrentDictionary<Tuple<ActiveUnit, int, ScenarioObject>, double> ETA_ResultsCache
	{
		get
		{
			return m_ParamWrapper;
		}
		set
		{
			m_ParamWrapper = value;
		}
	}

	public bool HasChaffBundles
	{
		get
		{
			foreach (Mount mount in myUnit.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					if (mountWeapon.CurrentLoad != 0 && mountWeapon.GetReferenceWeapon(myUnit.ParentScen).IsChaffBundle && mount.Status == PlatformComponent._ComponentStatus.Operational)
					{
						return true;
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec obj in array)
				{
					obj.ParentMount = null;
					if (obj.GetReferenceWeapon(myUnit.ParentScen).IsChaffBundle)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public virtual Weapon PrimaryAttackWeapon_Default
	{
		get
		{
			List<WeaponRec> list = AllDistinctWeaponsAboard_Default_WeaponRecs(bool_1: false);
			List<Weapon> list2 = new List<Weapon>();
			foreach (WeaponRec item in list)
			{
				if (item.DefaultLoad != 0)
				{
					Weapon referenceWeapon = item.GetReferenceWeapon(myUnit.ParentScen);
					if (referenceWeapon.IsASuW_Land || referenceWeapon.IsASuW_Naval)
					{
						list2.Add(referenceWeapon);
					}
				}
			}
			if (list2.Count <= 0)
			{
				return null;
			}
			if (!Information.IsNothing(myUnit.AssignedMissionOrPackage()) && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
			{
				IEnumerable<Weapon> source = list2.Where((Weapon theWeap) => theWeap.IsMine);
				if (source.Count() <= 0)
				{
					return list2.OrderByDescending((Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
				}
				return source.ElementAtOrDefault(0);
			}
			return list2.OrderByDescending((Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public virtual Weapon PrimaryDefenceWeapon_Default
	{
		get
		{
			List<WeaponRec> list = AllDistinctWeaponsAboard_Default_WeaponRecs(bool_1: false);
			List<Weapon> list2 = new List<Weapon>();
			foreach (WeaponRec item in list)
			{
				if (item.DefaultLoad != 0)
				{
					Weapon referenceWeapon = item.GetReferenceWeapon(myUnit.ParentScen);
					if (referenceWeapon.IsAAW || referenceWeapon.IsASW)
					{
						list2.Add(referenceWeapon);
					}
				}
			}
			if (list2.Count <= 0)
			{
				return null;
			}
			return list2.OrderByDescending((Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public virtual Weapon PrimaryAttackWeapon_Actual
	{
		get
		{
			List<Weapon> list = (from theW in AllDistinctWeaponsAboard_Actual()
				where theW.IsASuW_Land || theW.IsASuW_Naval
				select theW).ToList();
			if (list.Count <= 0)
			{
				return null;
			}
			return list.OrderByDescending((Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public virtual Weapon PrimaryDefenceWeapon_Actual
	{
		get
		{
			List<Weapon> list = (from theW in AllDistinctWeaponsAboard_Actual()
				where theW.IsAAW || theW.IsASW
				select theW).ToList();
			if (list.Count <= 0)
			{
				return null;
			}
			return list.OrderByDescending((Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public bool DebugNEZ
	{
		[CompilerGenerated]
		get
		{
			return m_EventWrapper;
		}
		[CompilerGenerated]
		set
		{
			m_EventWrapper = value;
		}
	}

	public static event FiredWeaponEventHandler FiredWeapon
	{
		[CompilerGenerated]
		add
		{
			FiredWeaponEventHandler firedWeaponEventHandler = globalWrapper;
			FiredWeaponEventHandler firedWeaponEventHandler2;
			do
			{
				firedWeaponEventHandler2 = firedWeaponEventHandler;
				FiredWeaponEventHandler value2 = (FiredWeaponEventHandler)Delegate.Combine(firedWeaponEventHandler2, value);
				firedWeaponEventHandler = Interlocked.CompareExchange(ref globalWrapper, value2, firedWeaponEventHandler2);
			}
			while ((object)firedWeaponEventHandler != firedWeaponEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			FiredWeaponEventHandler firedWeaponEventHandler = globalWrapper;
			FiredWeaponEventHandler firedWeaponEventHandler2;
			do
			{
				firedWeaponEventHandler2 = firedWeaponEventHandler;
				FiredWeaponEventHandler value2 = (FiredWeaponEventHandler)Delegate.Remove(firedWeaponEventHandler2, value);
				firedWeaponEventHandler = Interlocked.CompareExchange(ref globalWrapper, value2, firedWeaponEventHandler2);
			}
			while ((object)firedWeaponEventHandler != firedWeaponEventHandler2);
		}
	}

	static ActiveUnit_Weaponry()
	{
		DLZ_Nm_tolerance = 5;
		DLZCacheList = new List<DLZCAche>();
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ActiveUnit_Weaponry");
			if (WeaponAssignments.Count > 0)
			{
				xmlWriter_0.WriteStartElement("WeaponAssignments");
				foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
				{
					weaponAssignment.ToXML(ref xmlWriter_0, ref hashSet_0);
				}
				xmlWriter_0.WriteEndElement();
			}
			if (LayChaffStream)
			{
				xmlWriter_0.WriteElementString("LCS", "True");
			}
			if (bool_0)
			{
				xmlWriter_0.WriteElementString("IDLZ", "True");
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100284", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Weaponry FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_Weaponry activeUnit_Weaponry = new ActiveUnit_Weaponry();
			activeUnit_Weaponry.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "WeaponAssignments":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								WeaponAssignment weaponAssignment = WeaponAssignment.FromXML(ref xmlNode_, concurrentDictionary_0, ref activeUnit_0.ParentScen);
								if (!Information.IsNothing(weaponAssignment.Target))
								{
									activeUnit_Weaponry.WeaponAssignments.Add(weaponAssignment);
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
					case "LCS":
						activeUnit_Weaponry.LayChaffStream = true;
						break;
					case "IDLZ":
						activeUnit_Weaponry.bool_0 = true;
						break;
					case "HF":
						if (!Information.IsNothing(activeUnit_0.Doctrine) && Conversions.ToBoolean(xmlNode.InnerText))
						{
							activeUnit_0.Doctrine.SetWeaponControlStatus_Air(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._WCS.Hold);
						}
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
			return activeUnit_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100285", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_Weaponry result = new ActiveUnit_Weaponry();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private ActiveUnit_Weaponry()
	{
		m_MappingWrapper = false;
		m_MockWrapper = true;
		WeaponAssignments = new List<WeaponAssignment>();
		queueWrapper = new HashSet<Tuple<int, string>>();
		m_ParamWrapper = new ConcurrentDictionary<Tuple<ActiveUnit, int, ScenarioObject>, double>();
		systemWrapper = new StringBuilder();
		DebugNEZ = false;
	}

	public ActiveUnit_Weaponry(ActiveUnit activeUnit_0)
	{
		m_MappingWrapper = false;
		m_MockWrapper = true;
		WeaponAssignments = new List<WeaponAssignment>();
		queueWrapper = new HashSet<Tuple<int, string>>();
		m_ParamWrapper = new ConcurrentDictionary<Tuple<ActiveUnit, int, ScenarioObject>, double>();
		systemWrapper = new StringBuilder();
		DebugNEZ = false;
		myUnit = activeUnit_0;
	}

	public List<WeaponRec> AllDistinctWeaponsAboard_Current_WeaponRecs(bool bool_1)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> result = null;
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec item = mountWeapons[j];
						list.Add(item);
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec item2 = weapons[k];
						list.Add(item2);
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (sharedMagazines != null)
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (bool_1 || !magazine.IsAviationMag)
					{
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec item3 = weapons2[m];
							list.Add(item3);
						}
					}
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec item4 = weapons3[n];
					list.Add(item4);
				}
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 103245230948568", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public List<WeaponRec> AllDistinctWeaponsAboard_Default_WeaponRecs(bool bool_1)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> result = null;
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec item = mountWeapons[j];
						list.Add(item);
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec item2 = weapons[k];
						list.Add(item2);
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (!Information.IsNothing(sharedMagazines))
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (bool_1 || !magazine.IsAviationMag)
					{
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec item3 = weapons2[m];
							list.Add(item3);
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec item4 = weapons3[n];
					list.Add(item4);
				}
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101300", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public List<WeaponRec> AllDistinctWeaponsAboard_Actual_WeaponRecs(bool bool_1)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec item = mountWeapons[j];
						list.Add(item);
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec item2 = weapons[k];
						list.Add(item2);
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (!Information.IsNothing(sharedMagazines))
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (bool_1 || !magazine.IsAviationMag)
					{
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec item3 = weapons2[m];
							list.Add(item3);
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec item4 = weapons3[n];
					list.Add(item4);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10324502345239204859038532985", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	public Dictionary<int, WeaponRec> AllDistinctWeaponsAboard_Potential_WeaponRecs(bool bool_1)
	{
		Dictionary<int, WeaponRec> dictionary = new Dictionary<int, WeaponRec>();
		Dictionary<int, WeaponRec> result = null;
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec weaponRec = mountWeapons[j];
						if (!dictionary.ContainsKey(weaponRec.int_0))
						{
							dictionary.Add(weaponRec.int_0, weaponRec);
						}
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec weaponRec2 = weapons[k];
						if (!dictionary.ContainsKey(weaponRec2.int_0))
						{
							dictionary.Add(weaponRec2.int_0, weaponRec2);
						}
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (!Information.IsNothing(sharedMagazines))
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (!bool_1 && magazine.IsAviationMag)
					{
						continue;
					}
					ObservableList<WeaponRec> weapons2 = magazine.Weapons;
					int num5 = weapons2.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						WeaponRec weaponRec3 = weapons2[m];
						if (!dictionary.ContainsKey(weaponRec3.int_0))
						{
							dictionary.Add(weaponRec3.int_0, weaponRec3);
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec weaponRec4 = weapons3[n];
					if (!dictionary.ContainsKey(weaponRec4.int_0))
					{
						dictionary.Add(weaponRec4.int_0, weaponRec4);
					}
				}
			}
			result = dictionary;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101301", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Dictionary<int, Weapon> AllDistinctWeaponsAboard_Potential(bool bool_1)
	{
		Dictionary<int, Weapon> dictionary = new Dictionary<int, Weapon>();
		Dictionary<int, Weapon> result = null;
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec weaponRec = mountWeapons[j];
						if (!dictionary.ContainsKey(weaponRec.int_0))
						{
							dictionary.Add(weaponRec.int_0, weaponRec.GetReferenceWeapon(myUnit.ParentScen));
						}
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec weaponRec2 = weapons[k];
						if (!dictionary.ContainsKey(weaponRec2.int_0))
						{
							dictionary.Add(weaponRec2.int_0, weaponRec2.GetReferenceWeapon(myUnit.ParentScen));
						}
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (!Information.IsNothing(sharedMagazines))
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (!bool_1 && magazine.IsAviationMag)
					{
						continue;
					}
					ObservableList<WeaponRec> weapons2 = magazine.Weapons;
					int num5 = weapons2.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						WeaponRec weaponRec3 = weapons2[m];
						if (!dictionary.ContainsKey(weaponRec3.int_0))
						{
							dictionary.Add(weaponRec3.int_0, weaponRec3.GetReferenceWeapon(myUnit.ParentScen));
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec weaponRec4 = weapons3[n];
					if (!dictionary.ContainsKey(weaponRec4.int_0))
					{
						dictionary.Add(weaponRec4.int_0, weaponRec4.GetReferenceWeapon(myUnit.ParentScen));
					}
				}
			}
			result = dictionary;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100287", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void Housekeeping_PrePulse()
	{
		if (myUnit.ParentScen.SecondIsChangingOnThisPulse)
		{
			ClearCachedWeapons();
		}
	}

	public virtual void ClearCachedWeapons()
	{
		_AllDistinctWeaponsAboard_Actual = null;
		_PageWrapper = null;
		interceptorWrapper = null;
		_DatabaseWrapper = null;
		m_ProductWrapper = false;
		m_MessageWrapper = false;
		parserWrapper = null;
		_AlgoWrapper = false;
		_IteratorWrapper = null;
		m_AnnotationWrapper = null;
		roleWrapper = false;
		m_InitializerWrapper = false;
		factoryWrapper = null;
		attributeWrapper = false;
	}

	public virtual List<Weapon> AllDistinctWeaponsAboard_Actual()
	{
		if (_AllDistinctWeaponsAboard_Actual == null)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<Weapon> list = new List<Weapon>();
			try
			{
				if (myUnit.IsPalletWeapon)
				{
					if (((Weapon)myUnit).WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in ((Weapon)myUnit).WeaponWeapons)
					{
						list.Add(weaponWeapon.GetReferenceWeapon(myUnit.ParentScen));
					}
				}
				ObservableList<Mount> mounts = myUnit.Mounts;
				if (mounts.Count > 0)
				{
					int num = mounts.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Mount mount = mounts[i];
						ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
						int num2 = mountWeapons.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							WeaponRec weaponRec = mountWeapons[j];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_0))
							{
								dictionary.Add(weaponRec.int_0, 0);
								list.Add(weaponRec.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
						ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
						int num3 = weapons.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							WeaponRec weaponRec2 = weapons[k];
							if (weaponRec2.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec2.int_0))
							{
								dictionary.Add(weaponRec2.int_0, 0);
								list.Add(weaponRec2.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				if (!Information.IsNothing(sharedMagazines))
				{
					int num4 = sharedMagazines.Length - 1;
					for (int l = 0; l <= num4; l++)
					{
						Magazine magazine = sharedMagazines[l];
						if (magazine.IsAviationMag)
						{
							continue;
						}
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec weaponRec3 = weapons2[m];
							if (weaponRec3.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec3.int_0))
							{
								dictionary.Add(weaponRec3.int_0, 0);
								list.Add(weaponRec3.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100288", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			_AllDistinctWeaponsAboard_Actual = list;
		}
		return _AllDistinctWeaponsAboard_Actual;
	}

	public virtual List<Weapon> AllDistinctWeaponsAboard_Actual_InclAviation()
	{
		if (Information.IsNothing(_PageWrapper))
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<Weapon> list = new List<Weapon>();
			try
			{
				ObservableList<Mount> mounts = myUnit.Mounts;
				if (mounts.Count > 0)
				{
					int num = mounts.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Mount mount = mounts[i];
						ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
						int num2 = mountWeapons.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							WeaponRec weaponRec = mountWeapons[j];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_0))
							{
								dictionary.Add(weaponRec.int_0, 0);
								list.Add(weaponRec.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
						ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
						int num3 = weapons.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							WeaponRec weaponRec2 = weapons[k];
							if (weaponRec2.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec2.int_0))
							{
								dictionary.Add(weaponRec2.int_0, 0);
								list.Add(weaponRec2.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				if (!Information.IsNothing(sharedMagazines))
				{
					int num4 = sharedMagazines.Length - 1;
					for (int l = 0; l <= num4; l++)
					{
						ObservableList<WeaponRec> weapons2 = sharedMagazines[l].Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec weaponRec3 = weapons2[m];
							if (weaponRec3.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec3.int_0))
							{
								dictionary.Add(weaponRec3.int_0, 0);
								list.Add(weaponRec3.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 10028123459085", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			_PageWrapper = list;
		}
		return _PageWrapper;
	}

	public bool TargetIsWithinGunRange_Horiz(Contact contact_0)
	{
		bool result = false;
		try
		{
			float num = 0f;
			foreach (Weapon item in AllDistinctWeaponsAboard_Actual())
			{
				if (item.Type == Weapon._WeaponType.Gun)
				{
					float maxRangeForThisTarget = item.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, myUnit.Doctrine, bool_1: false);
					if (maxRangeForThisTarget > num)
					{
						num = maxRangeForThisTarget;
					}
				}
			}
			if (num == 0f)
			{
				result = false;
				return false;
			}
			return result = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0) < num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100289", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public int TotalDefaultCapacityForThisWeapon(int int_0)
	{
		int result = 0;
		try
		{
			int num = 0;
			foreach (Mount mount in myUnit.Mounts)
			{
				if (mount.Status != 0)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_0 == int_0)
					{
						num += mountWeapon.DefaultLoad;
					}
				}
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					if (weapon.int_0 == int_0)
					{
						num += weapon.DefaultLoad;
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			Magazine[] array = sharedMagazines;
			foreach (Magazine magazine in array)
			{
				if (magazine.Status != 0)
				{
					continue;
				}
				foreach (WeaponRec weapon2 in magazine.Weapons)
				{
					if (weapon2.int_0 == int_0)
					{
						num += weapon2.MaxLoad;
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				WeaponRec[] array2 = weapons;
				foreach (WeaponRec weaponRec in array2)
				{
					if (weaponRec.int_0 == int_0)
					{
						num += weaponRec.DefaultLoad;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100290", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public int TotalMaximumCapacityForThisWeapon(int int_0, bool bool_1, Weapon weapon_0 = null)
	{
		int result = 0;
		try
		{
			int num = 0;
			foreach (Mount mount in myUnit.Mounts)
			{
				if (!(mount.Status == PlatformComponent._ComponentStatus.Operational || bool_1))
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_0 == int_0)
					{
						num += mountWeapon.MaxLoad;
					}
				}
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					if (weapon.int_0 == int_0)
					{
						num += weapon.MaxLoad;
					}
				}
			}
			if (myUnit.SharedMagazines != null)
			{
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				Magazine[] array = sharedMagazines;
				foreach (Magazine magazine in array)
				{
					if (!(magazine.Status == PlatformComponent._ComponentStatus.Operational || bool_1))
					{
						continue;
					}
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						if (weapon2.int_0 == int_0)
						{
							num += weapon2.MaxLoad;
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				WeaponRec[] array2 = weapons;
				foreach (WeaponRec weaponRec in array2)
				{
					if (weaponRec.int_0 == int_0)
					{
						num += weaponRec.MaxLoad;
						continue;
					}
					if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
					{
						if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_0 == int_0)
							{
								weapon_0 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
							}
						}
					}
					if (weapon_0 == null || weapon_0.Warheads.Count() <= 0)
					{
						continue;
					}
					int currentLoad = ((Aircraft)myUnit).Loadout.Weapons.Where((WeaponRec thePWR) => thePWR.int_0 == weapon_0.DBID).First().CurrentLoad;
					if (weapon_0.WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon2 in weapon_0.WeaponWeapons)
					{
						if (weaponWeapon2.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0)
						{
							num = weaponWeapon2.MaxLoad * currentLoad;
						}
					}
				}
			}
			if (myUnit.IsPalletWeapon)
			{
				foreach (WeaponRec weaponWeapon3 in ((Weapon)myUnit).WeaponWeapons)
				{
					if (weaponWeapon3.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0)
					{
						num = weaponWeapon3.MaxLoad;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1002901111", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public int TotalAvailableInventoryForThisWeapon(int int_0, bool bool_1, Weapon weapon_0 = null)
	{
		int result = 0;
		try
		{
			int num = 0;
			foreach (Mount mount in myUnit.Mounts)
			{
				if (!(mount.Status == PlatformComponent._ComponentStatus.Operational || bool_1))
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_0 == int_0)
					{
						num += mountWeapon.CurrentLoad;
					}
				}
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					if (weapon.int_0 == int_0)
					{
						num += weapon.CurrentLoad;
					}
				}
			}
			if (myUnit.SharedMagazines != null)
			{
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				Magazine[] array = sharedMagazines;
				foreach (Magazine magazine in array)
				{
					if (!(magazine.Status == PlatformComponent._ComponentStatus.Operational || bool_1))
					{
						continue;
					}
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						if (weapon2.int_0 == int_0)
						{
							num += weapon2.CurrentLoad;
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				WeaponRec[] array2 = weapons;
				foreach (WeaponRec weaponRec in array2)
				{
					if (weaponRec.int_0 == int_0)
					{
						num += weaponRec.CurrentLoad;
						continue;
					}
					if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
					{
						if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_0 == int_0)
							{
								weapon_0 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
							}
						}
					}
					if (weapon_0 == null || weapon_0.Warheads.Count() <= 0)
					{
						continue;
					}
					int currentLoad = ((Aircraft)myUnit).Loadout.Weapons.Where((WeaponRec thePWR) => thePWR.int_0 == weapon_0.DBID).First().CurrentLoad;
					if (weapon_0.WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon2 in weapon_0.WeaponWeapons)
					{
						if (weaponWeapon2.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0)
						{
							num = weaponWeapon2.CurrentLoad * currentLoad;
						}
					}
				}
			}
			if (myUnit.IsPalletWeapon)
			{
				foreach (WeaponRec weaponWeapon3 in ((Weapon)myUnit).WeaponWeapons)
				{
					if (weaponWeapon3.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0)
					{
						num = weaponWeapon3.CurrentLoad;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100292", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal bool PopConsumer(Contact contact_0, bool bool_1, Doctrine doctrine_0, ref string string_0, ref int int_0, List<Weapon> list_0 = null)
	{
		bool result = false;
		try
		{
			List<Weapon> list = ((list_0 == null) ? AllDistinctWeaponsAboard_Actual() : list_0);
			if (list.Count == 0)
			{
				result = false;
				return false;
			}
			bool? nullable_ = contact_0.GetIsDestroyed(myUnit.ParentScen);
			bool? flag = nullable_;
			flag = flag;
			if (flag.GetValueOrDefault())
			{
				result = false;
				return false;
			}
			int num = list.Count - 1;
			int i = 0;
			Doctrine._GunStrafeGroundTargets? gunStrafeGroundTargets = null;
			for (; i <= num; i++)
			{
				Weapon weapon_ = list[i];
				if (myUnit.IsAircraft && contact_0.IsSurfaceContact && weapon_.Type == Weapon._WeaponType.Gun)
				{
					if (!gunStrafeGroundTargets.HasValue)
					{
						gunStrafeGroundTargets = myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
					}
					byte? b = (byte?)gunStrafeGroundTargets;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						if (int_0 < 2)
						{
							string_0 = "可用武器不能目标任何目标者（唯一合适的武器是枪，但是条令禁止枪支射击）。";
							int_0 = 2;
						}
						continue;
					}
				}
				if (!weapon_.QueryReponse(myUnit, ref contact_0, ref nullable_))
				{
					continue;
				}
				if (bool_1 && doctrine_0 != null && doctrine_0.InsertRepository(ref weapon_))
				{
					weapon_.FiringParent = myUnit;
					Weapon weapon_2 = weapon_;
					flag = null;
					Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_2, ref flag);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref contact_0, ref _WRA_WeaponTargetType_, myUnit.GetUnitSide().ObjectID);
					Scenario parentScen = weapon_.ParentScen;
					Weapon weapon_3 = weapon_;
					int? nullable_2 = null;
					int? nullable_3 = null;
					nullable_3 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine_0, parentScen, weapon_3, wRA_WeaponTargetType_, bool_0: false, ref nullable_2, ref nullable_3);
					if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						if (int_0 < 4)
						{
							string_0 = "可用武器（武器释放授权 - 目标类型）不能使用任何目标。";
							int_0 = 4;
						}
						continue;
					}
					Scenario parentScen2 = weapon_.ParentScen;
					int dBID = weapon_.DBID;
					float? nullable_4 = null;
					float? nullable_5 = null;
					float? num2 = doctrine_0.IncludeRepository(doctrine_0, parentScen2, dBID, wRA_WeaponTargetType_, bool_0: false, ref nullable_4, ref nullable_5);
					if (num2.HasValue)
					{
						nullable_5 = num2;
						if ((nullable_5.HasValue ? new bool?(nullable_5.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
						{
							if (int_0 < 5)
							{
								string_0 = "可用武器（武器释放授权 - 射击范围）不能使用任何目标。";
								int_0 = 5;
							}
							continue;
						}
					}
				}
				result = true;
				return true;
			}
			if (int_0 < 3)
			{
				string_0 = "可用武器（不适合）不能使用任何目标。";
				int_0 = 3;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100293", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void AttemptToLayMine(float float_0, long long_0)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<Mount> list2 = new List<Mount>();
		List<Mount> list3 = new List<Mount>();
		List<Mount> list4 = new List<Mount>();
		try
		{
			foreach (Mount mount in myUnit.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					Weapon referenceWeapon = mountWeapon.GetReferenceWeapon(myUnit.ParentScen);
					if (!referenceWeapon.IsMine)
					{
						continue;
					}
					if (mount.ReloadPriority.Count == 0 && !list4.Contains(mount))
					{
						list4.Add(mount);
					}
					if (myUnit.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(myUnit.ParentScen.DBConnection) && referenceWeapon.MaxLaunchAlt_AGL == 0f && referenceWeapon.MinLaunchAlt_AGL == 0f)
					{
						if (referenceWeapon.MaxLaunchAlt_ASL < myUnit.GetCurrentAltitude() || referenceWeapon.MinLaunchAlt_ASL > myUnit.GetCurrentAltitude())
						{
							continue;
						}
					}
					else if (myUnit.IsAircraft)
					{
						if (referenceWeapon.MaxLaunchAlt_AGL < myUnit.GetCurrentAltitude() || referenceWeapon.MinLaunchAlt_AGL > myUnit.GetCurrentAltitude())
						{
							continue;
						}
					}
					else if (referenceWeapon.MaxLaunchAlt_ASL < myUnit.GetCurrentAltitude() || referenceWeapon.MinLaunchAlt_ASL > myUnit.GetCurrentAltitude())
					{
						continue;
					}
					if (mountWeapon.CurrentLoad == 0 || mount.Status != 0)
					{
						continue;
					}
					if (mount.ReloadPriority.Count == 0 && !list3.Contains(mount))
					{
						list3.Add(mount);
					}
					if (mount.TimeToFire != 0f || mountWeapon.TimeToFire != 0f)
					{
						continue;
					}
					if (mount.ReloadPriority.Count == 0 && !list2.Contains(mount))
					{
						list2.Add(mount);
					}
					UnguidedWeapon unguidedWeapon_ = new UnguidedWeapon(referenceWeapon, null, null, 0.0, 0.0, 0L);
					string text = UnguidedWeapon.CanLayMineHere(ref unguidedWeapon_, myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen), myUnit.ParentScen);
					if (string.CompareOrdinal(text, "OK") == 0)
					{
						list.Add(mountWeapon);
						continue;
					}
					string text2 = "";
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
					{
						text2 = " (" + myUnit.UnitClass + ")";
					}
					myUnit.ParentScen.AddMessage(myUnit.Name + text2 + "不能布设水雷类型" + referenceWeapon.Name + ": " + text, myUnit.Name + " 无法布雷", LoggedMessage.MessageType.WeaponEndgame, 0, null, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
			}
			if (myUnit.IsAircraft)
			{
				if (!Information.IsNothing(((Aircraft)myUnit).Loadout))
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						weaponRec.ParentMount = null;
						Weapon referenceWeapon2 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
						if (!referenceWeapon2.IsMine)
						{
							continue;
						}
						if (myUnit.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(myUnit.ParentScen.DBConnection) && referenceWeapon2.MaxLaunchAlt_AGL == 0f)
						{
							if (referenceWeapon2.MaxLaunchAlt_ASL < myUnit.GetCurrentAltitude())
							{
								continue;
							}
						}
						else if (referenceWeapon2.MaxLaunchAlt_AGL < myUnit.GetCurrentAltitude())
						{
							continue;
						}
						if (weaponRec.CurrentLoad != 0 && weaponRec.TimeToFire <= 0f)
						{
							UnguidedWeapon unguidedWeapon_2 = new UnguidedWeapon(referenceWeapon2, null, null, 0.0, 0.0, 0L);
							if (string.CompareOrdinal(UnguidedWeapon.CanLayMineHere(ref unguidedWeapon_2, myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen), myUnit.ParentScen), "OK") == 0)
							{
								list.Add(weaponRec);
							}
						}
					}
				}
				if (list.Count == 0)
				{
					return;
				}
			}
			if (!myUnit.IsAircraft)
			{
				if (list.Count == 0 && list4.Count == 0)
				{
					return;
				}
				if (list.Count == 0 && list3.Count == list2.Count)
				{
					Mount mount_ = list4[GameGeneral.LockRandom_0.Next(0, list4.Count)];
					WeaponRec weaponRec_ = mount_.MountWeapons.FirstOrDefault((WeaponRec s) => s.CurrentLoad > 0);
					WeaponRec weaponRec_2 = mount_.MountWeapons.FirstOrDefault((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMine);
					if (weaponRec_ != null && weaponRec_2 != null)
					{
						RunConsumer(ref mount_, ref weaponRec_);
						StartConsumer(ref mount_, ref weaponRec_2);
					}
					return;
				}
				if (list.Count == 0)
				{
					return;
				}
			}
			WeaponRec weaponRec_3 = ((list.Count == 1) ? list[0] : list[GameGeneral.LockRandom_0.Next(0, list.Count)]);
			int int_ = 0;
			WeaponSalvo weaponSalvo_ = null;
			ResetConsumer(float_0, ref weaponRec_3, null, ref int_, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, long_0, ref weaponSalvo_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100294", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual ActiveUnit._ActiveUnitWeaponState IsWinchesterOrShotgun()
	{
		if (myUnit.Mounts.Count == 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		ActiveUnit._ActiveUnitWeaponState result = ActiveUnit._ActiveUnitWeaponState.None;
		try
		{
			myUnit.Mounts.Where((Mount theM) => theM.IsEmpty).Count();
			if (myUnit.Mounts.Count == 0)
			{
				result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100295", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual void ExecuteWeaponAssignments(float float_0)
	{
		if (WeaponAssignments.Count == 0)
		{
			return;
		}
		List<WeaponAssignment> list = new List<WeaponAssignment>();
		try
		{
			Doctrine._GunStrafeGroundTargets? nullable_ = null;
			foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
			{
				if (myUnit.Weaponry.CreateSalvo(weaponAssignment.Target, weaponAssignment.Weapon.DBID, weaponAssignment.Quantity, weaponAssignment.ManualFire, ref nullable_, weaponAssignment.ScheduledFireTime))
				{
					list.Add(weaponAssignment);
				}
			}
			foreach (WeaponAssignment item in list)
			{
				WeaponAssignments.Remove(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100297", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Doctrine._WCS InstantiateConsumer(Contact_Base.ContactType contactType_0)
	{
		switch (contactType_0)
		{
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
		case Contact_Base.ContactType.Decoy_Air:
			return myUnit.Doctrine.GetWeaponControlStatus_Air(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Torpedo:
		case Contact_Base.ContactType.Decoy_Sub:
			return myUnit.Doctrine.GetWeaponControlStatus_Submarine(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		case Contact_Base.ContactType.Aimpoint:
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
		case Contact_Base.ContactType.Decoy_Land:
		case Contact_Base.ContactType.Installation:
		case Contact_Base.ContactType.AirBase:
		case Contact_Base.ContactType.NavalBase:
		case Contact_Base.ContactType.MobileGroup:
			return myUnit.Doctrine.GetWeaponControlStatus_Land(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.Decoy_Surface:
		case Contact_Base.ContactType.ActivationPoint:
			return myUnit.Doctrine.GetWeaponControlStatus_Surface(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
		}
	}

	public virtual void ExecuteWeaponSalvos(float float_0)
	{
		if (myUnit.GetUnitSide().WeaponSalvos.Length == 0 || (myUnit.IsFacility && (int)Math.Round(myUnit.CurrentSpeed) > 0 && !((Facility)myUnit).CanFireOnTheMove) || (myUnit.IsPalletWeapon & (myUnit.Attitude_Pitch != -85f)))
		{
			return;
		}
		bool flag = false;
		Dictionary<string, WeaponSalvo> dictionary = new Dictionary<string, WeaponSalvo>();
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		try
		{
			regWrapper = false;
			List<WeaponSalvo> list2 = new List<WeaponSalvo>(myUnit.GetUnitSide().WeaponSalvos.Count());
			WeaponSalvo[] weaponSalvos = myUnit.GetUnitSide().WeaponSalvos;
			WeaponSalvo[] array3 = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array3)
			{
				if (DateTime.Compare(weaponSalvo.ScheduledFireTime, myUnit.ParentScen.Time) >= 0)
				{
					continue;
				}
				if (Information.IsNothing(weaponSalvo))
				{
					list.Add(weaponSalvo);
					continue;
				}
				bool flag2 = false;
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				for (int i = 0; i < shootersList.Length; i = checked(i + 1))
				{
					if (Operators.CompareString(shootersList[i].ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					if (weaponSalvo.ShootersList.Length == 0 && weaponSalvo.WpnQuantityAssigned == 0 && weaponSalvo.WpnQuantityFired == 0)
					{
						list.Add(weaponSalvo);
					}
					list2.Add(weaponSalvo);
				}
			}
			if (list.Count > 0)
			{
				foreach (WeaponSalvo item in list)
				{
					ArrayExtensions.Remove(ref myUnit.GetUnitSide().WeaponSalvos, item);
				}
				list.Clear();
			}
			if (m_RulesWrapper == null)
			{
				m_RulesWrapper = new List<WeaponSalvo>();
			}
			else
			{
				m_RulesWrapper.Clear();
			}
			List<WeaponSalvo> list3 = new List<WeaponSalvo>();
			ActiveUnit activeUnit = null;
			foreach (WeaponSalvo item2 in list2)
			{
				WeaponSalvo.Shooter shooter = null;
				WeaponSalvo.Shooter[] array = new WeaponSalvo.Shooter[item2.ShootersList.Length - 1 + 1];
				int num = array.Length - 1;
				for (int j = 0; j <= num; j++)
				{
					array[j] = item2.ShootersList[j];
				}
				WeaponSalvo.Shooter[] array2 = array;
				WeaponSalvo.Shooter[] array4 = array2;
				foreach (WeaponSalvo.Shooter shooter2 in array4)
				{
					if (myUnit.ParentScen.ActiveUnits.TryGetValue(shooter2.ShooterObjectID, ref activeUnit) && myUnit == activeUnit)
					{
						shooter = shooter2;
						break;
					}
				}
				if (shooter != null)
				{
					m_RulesWrapper.Add(item2);
				}
			}
			foreach (WeaponSalvo item3 in list3)
			{
				ArrayExtensions.Remove(ref myUnit.GetUnitSide().WeaponSalvos, item3);
			}
			Doctrine._WCS wCS = Doctrine._WCS.Free;
			short? nullable_ = null;
			foreach (WeaponSalvo item4 in m_RulesWrapper)
			{
				WeaponSalvo weaponSalvo_ = item4;
				WeaponSalvo.Shooter shooter3 = ((weaponSalvo_.ShootersList.Length == 1) ? weaponSalvo_.ShootersList[0] : weaponSalvo_.ShootersList.Where((WeaponSalvo.Shooter shooter_0) => Operators.CompareString(shooter_0.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0).ElementAtOrDefault(0));
				if (shooter3.Timeout >= 40 && !weaponSalvo_.ManualFire)
				{
					if (SimConfiguration.DefaultGamePreferences.SalvoTimeout)
					{
						if (!dictionary.ContainsKey(shooter3.ShooterObjectID))
						{
							dictionary.Add(shooter3.ShooterObjectID, weaponSalvo_);
						}
						continue;
					}
				}
				else if (weaponSalvo_.WeaponList.Count() == 0)
				{
					if (myUnit.IsPalletWeapon)
					{
						shooter3.WeaponIsReadyToFire = true;
					}
					if (shooter3.WeaponIsReadyToFire)
					{
						shooter3.Timeout++;
					}
					else
					{
						shooter3.Timeout = 1;
					}
				}
				else
				{
					shooter3.Timeout = 0;
				}
				if (!weaponSalvo_.ManualFire && wCS == Doctrine._WCS.Hold)
				{
					Side unitSide = myUnit.GetUnitSide();
					ref Scenario parentScen = ref myUnit.ParentScen;
					ref ActiveUnit activeUnit_ = ref myUnit;
					Contact contact_ = null;
					unitSide.StopShootingSalvo(ref parentScen, ref activeUnit_, ref contact_, ref weaponSalvo_);
					continue;
				}
				if (!weaponSalvo_.ManualFire && shooter3.QuantityAssigned == 0 && shooter3.QuantityFired == 0)
				{
					list.Add(weaponSalvo_);
					continue;
				}
				int num2 = shooter3.QuantityAssigned - shooter3.QuantityFired;
				if (num2 <= 0)
				{
					myUnit.GetUnitSide().AttemptToRemoveWeaponSalvo(ref myUnit.ParentScen, weaponSalvo_);
					continue;
				}
				if (weaponSalvo_.Target.IsShipContact)
				{
					byte? b = (byte?)weaponSalvo_.Target.BDA_StructuralIntegrity;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						Side unitSide2 = myUnit.GetUnitSide();
						ref Scenario parentScen2 = ref myUnit.ParentScen;
						ref ActiveUnit activeUnit_2 = ref myUnit;
						Contact contact_2 = null;
						unitSide2.StopShootingSalvo(ref parentScen2, ref activeUnit_2, ref contact_2, ref weaponSalvo_);
						continue;
					}
				}
				if (!weaponSalvo_.FireSimultaneouslyFromMultipleMounts && (weaponSalvo_.Target.IsFacility || weaponSalvo_.Target.IsShip || weaponSalvo_.Target.IsSubmarine))
				{
					regWrapper = true;
				}
				if (shooter3.TimeToNextLaunch > 1)
				{
					shooter3.TimeToNextLaunch--;
					continue;
				}
				if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					for (int k = 0; k < weapons.Length; k = checked(k + 1))
					{
						weapons[k].GetReferenceWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
					}
					foreach (WeaponRec weaponRec in from It in ((Aircraft)myUnit).Loadout.Weapons.OrderByDescending((WeaponRec WeaponRec) => WeaponRec.CurrentLoad).GroupBy((WeaponRec WeaponRec) => WeaponRec.int_0, (int int_0, IEnumerable<WeaponRec> ItAnonymous) => (int_0, ItAnonymous))
						select It.Item2.First())
					{
						WeaponRec weaponRec_ = weaponRec;
						Weapon referenceWeapon = weaponRec_.GetReferenceWeapon(myUnit.ParentScen);
						if ((referenceWeapon.IsGuidedWeapon() && !myUnit.ParentScen.SecondIsChangingOnThisPulse) || weaponSalvo_.int_0 != weaponRec_.int_0)
						{
							continue;
						}
						if (weaponRec_.CurrentLoad == 0)
						{
							if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(referenceWeapon.DBID, bool_1: false) <= 0)
							{
								shooter3.WeaponIsReadyToFire = true;
							}
							else
							{
								shooter3.WeaponIsReadyToFire = false;
							}
						}
						else if (weaponRec_.TimeToFire == 0f)
						{
							shooter3.WeaponIsReadyToFire = true;
							if (shooter3.Timeout > 1 || !weaponSalvo_.ManualFire)
							{
							}
							if (referenceWeapon.IsPalletWeapon)
							{
								bool flag3 = false;
								if (referenceWeapon.Warheads.Count() > 0)
								{
									Warhead[] warheads2 = weaponRec_.GetReferenceWeapon(myUnit.ParentScen).Warheads;
									Warhead[] array5 = warheads2;
									foreach (Warhead warhead in array5)
									{
										if (flag3)
										{
											break;
										}
										if (warhead.GetCarriedWeapon(myUnit.ParentScen) != null)
										{
											Weapon carriedWeapon = warhead.GetCarriedWeapon(myUnit.ParentScen);
											Contact target = weaponSalvo_.Target;
											bool manualFire = weaponSalvo_.ManualFire;
											Sensor sensor_ = null;
											if (CanThisWeaponEngageThisTarget(carriedWeapon, target, ref nullable_, manualFire, bool_2: false, bool_3: false, null, ref sensor_).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
											{
												flag3 = true;
											}
										}
									}
									if (!flag3)
									{
										continue;
									}
								}
							}
							else
							{
								ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
								Weapon referenceWeapon2 = weaponRec_.GetReferenceWeapon(myUnit.ParentScen);
								Contact target2 = weaponSalvo_.Target;
								bool manualFire2 = weaponSalvo_.ManualFire;
								Sensor sensor_2 = null;
								if (weaponry.CanThisWeaponEngageThisTarget(referenceWeapon2, target2, ref nullable_, manualFire2, bool_2: false, bool_3: false, null, ref sensor_2).EvaluationEnum != 0)
								{
									continue;
								}
							}
							ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
							Contact target3 = weaponSalvo_.Target;
							int int_ = weaponSalvo_.WpnQuantityFired;
							weaponry2.ResetConsumer(float_0, ref weaponRec_, target3, ref int_, num2, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_);
							shooter3.QuantityFired = weaponSalvo_.WeaponList.Count();
						}
						else
						{
							shooter3.WeaponIsReadyToFire = false;
						}
					}
				}
				if (myUnit.IsPalletWeapon)
				{
					Warhead[] warheads = ((Weapon)myUnit).Warheads;
					Warhead[] array6 = warheads;
					foreach (Warhead warhead2 in array6)
					{
						if (warhead2.GetCarriedWeapon(myUnit.ParentScen) != null)
						{
							warhead2.GetCarriedWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
						}
					}
					if (((Weapon)myUnit).WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in ((Weapon)myUnit).WeaponWeapons)
					{
						WeaponRec weaponRec_2 = weaponWeapon;
						Weapon referenceWeapon3 = weaponRec_2.GetReferenceWeapon(myUnit.ParentScen);
						if ((referenceWeapon3.IsGuidedWeapon() && !myUnit.ParentScen.SecondIsChangingOnThisPulse) || weaponSalvo_.int_0 != weaponRec_2.int_0)
						{
							continue;
						}
						if (weaponRec_2.CurrentLoad == 0)
						{
							if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(referenceWeapon3.DBID, bool_1: false) <= 0)
							{
								shooter3.WeaponIsReadyToFire = true;
							}
							else
							{
								shooter3.WeaponIsReadyToFire = false;
							}
							continue;
						}
						shooter3.WeaponIsReadyToFire = true;
						if (shooter3.Timeout > 1 || !weaponSalvo_.ManualFire)
						{
						}
						ActiveUnit_Weaponry weaponry3 = myUnit.Weaponry;
						Weapon referenceWeapon4 = weaponRec_2.GetReferenceWeapon(myUnit.ParentScen);
						Contact target4 = weaponSalvo_.Target;
						bool manualFire3 = weaponSalvo_.ManualFire;
						Sensor sensor_3 = null;
						if (weaponry3.CanThisWeaponEngageThisTarget(referenceWeapon4, target4, ref nullable_, manualFire3, bool_2: false, bool_3: false, null, ref sensor_3).EvaluationEnum != 0)
						{
							continue;
						}
						int int_2 = 0;
						foreach (Weapon item5 in myUnit.ParentScen.AllWeaponsAlive)
						{
							if (item5.FiringParent != null && Operators.CompareString(item5.FiringParent.ObjectID, myUnit.ObjectID, TextCompare: false) == 0 && item5.AI.PrimaryTarget != null && Operators.CompareString(item5.AI.PrimaryTarget.ObjectID, weaponSalvo_.Target.ObjectID, TextCompare: false) == 0)
							{
								int_2++;
							}
						}
						myUnit.Weaponry.ResetConsumer(float_0, ref weaponRec_2, weaponSalvo_.Target, ref int_2, num2, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_);
						shooter3.QuantityFired += int_2;
						if (int_2 == 0)
						{
							flag = true;
						}
						if (int_2 <= 0 || weaponSalvo_.FireSimultaneouslyFromMultipleMounts)
						{
							continue;
						}
						return;
					}
				}
				try
				{
					if (!flag)
					{
						foreach (Mount mount in myUnit.Mounts)
						{
							if (Operators.CompareString(shooter3.PreferredMountObjectID, "", TextCompare: false) != 0 && Operators.CompareString(mount.ObjectID, shooter3.PreferredMountObjectID, TextCompare: false) != 0)
							{
								continue;
							}
							int int_3 = shooter3.QuantityFired;
							foreach (WeaponRec mountWeapon in mount.MountWeapons)
							{
								WeaponRec weaponRec_3 = mountWeapon;
								if (weaponSalvo_.int_0 != weaponRec_3.int_0 || weaponRec_3.CurrentLoad == 0)
								{
									continue;
								}
								if (mount.Status != 0)
								{
									break;
								}
								if (mount.TimeToFire == 0f && mount.MountMagazine.TimeToFire == 0f)
								{
									if (weaponRec_3.TimeToFire != 0f || (weaponRec_3.GetReferenceWeapon(myUnit.ParentScen).IsGuidedWeapon() && !myUnit.ParentScen.SecondIsChangingOnThisPulse))
									{
										continue;
									}
									shooter3.WeaponIsReadyToFire = true;
									if (shooter3.Timeout > 1 || !weaponSalvo_.ManualFire)
									{
									}
									ActiveUnit_Weaponry weaponry4 = myUnit.Weaponry;
									Weapon referenceWeapon5 = weaponRec_3.GetReferenceWeapon(myUnit.ParentScen);
									Contact target5 = weaponSalvo_.Target;
									bool manualFire4 = weaponSalvo_.ManualFire;
									Sensor sensor_4 = null;
									(string, WeaponPrefireChecklistEvaluation) tuple = weaponry4.CanThisWeaponEngageThisTarget(referenceWeapon5, target5, ref nullable_, manualFire4, bool_2: false, bool_3: false, mount, ref sensor_4);
									if (tuple.Item2 == WeaponPrefireChecklistEvaluation.OK)
									{
										myUnit.Weaponry.ResetConsumer(float_0, ref weaponRec_3, weaponSalvo_.Target, ref int_3, num2, 0f, ActiveUnit.Throttle.Flank, mount, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_);
										if (!Information.IsNothing(weaponRec_3.ParentMount))
										{
											weaponRec_3.ParentMount.TimeToFire = weaponRec_3.ParentMount.ROF;
										}
										shooter3.QuantityFired = int_3;
										if (int_3 == 0)
										{
											flag = true;
										}
										if (int_3 > 0)
										{
											if (weaponRec_3.CurrentLoad == 0)
											{
												int int_4 = 0;
												int int_5 = 0;
												if (mount.RegisterTokenizer(ref int_4, ref int_5) == 0)
												{
													mount.TimeToReloadAttempt = 0f;
													goto IL_1228;
												}
											}
											if (mount.TimeToReloadAttempt < 300f)
											{
												mount.TimeToReloadAttempt = mount.TimeToFire + 300f;
											}
											goto IL_1228;
										}
										goto IL_1344;
									}
									string text = "The Unit" + myUnit.Name + "cannot fire against" + weaponSalvo_.Target.Name + " with weapon" + weaponSalvo_.GetReferenceWeapon(myUnit.ParentScen).Name + " REASON: " + tuple.Item1;
									if (!myUnit.ParentScen.WeaponFeedBackMessage.Contains(text))
									{
										myUnit.ParentScen.AddMessage(text, myUnit.Name + "cannot fire to " + weaponSalvo_.Target.Name, LoggedMessage.MessageType.WeaponLogic, 1, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
										myUnit.ParentScen.WeaponFeedBackMessage.Add(text);
									}
									if (tuple.Item2 == WeaponPrefireChecklistEvaluation.WithinMinimumRange && !myUnit.IsAircraft)
									{
										list3.Add(weaponSalvo_);
										num2 = 0;
									}
									continue;
								}
								shooter3.WeaponIsReadyToFire = false;
								break;
								IL_1228:
								if (weaponSalvo_.ManualFire || !mount.ReserveTarget || weaponRec_3.CurrentLoad != 0 || !weaponSalvo_.Target.IsAir_Missile_Orbital_Contact)
								{
									num2 = shooter3.QuantityAssigned - int_3;
									if (!weaponSalvo_.FireSimultaneouslyFromMultipleMounts)
									{
										if (num2 <= 0)
										{
											shooter3.PreferredMountObjectID = mount.ObjectID;
											shooter3.TimeToNextLaunch = 0;
										}
										else if (weaponRec_3.CurrentLoad == 0)
										{
											shooter3.PreferredMountObjectID = "";
											shooter3.TimeToNextLaunch = (int)Math.Round(weaponRec_3.TimeToFire);
										}
										else
										{
											shooter3.PreferredMountObjectID = mount.ObjectID;
											shooter3.TimeToNextLaunch = (int)Math.Round(weaponRec_3.TimeToFire);
										}
										return;
									}
									goto IL_1344;
								}
								Side unitSide3 = myUnit.GetUnitSide();
								ref Scenario parentScen3 = ref myUnit.ParentScen;
								ref ActiveUnit activeUnit_3 = ref myUnit;
								Contact contact_3 = null;
								unitSide3.StopShootingSalvo(ref parentScen3, ref activeUnit_3, ref contact_3, ref weaponSalvo_);
								return;
								IL_1344:
								if (num2 > 0)
								{
									continue;
								}
								break;
							}
							if (num2 <= 0)
							{
								break;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101210", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (!weaponSalvo_.ManualFire && flag && shooter3.Timeout == 1 && weaponSalvo_.WeaponList.Count() == 0)
				{
					list.Add(weaponSalvo_);
				}
			}
			foreach (KeyValuePair<string, WeaponSalvo> item6 in dictionary)
			{
				Side unitSide4 = myUnit.GetUnitSide();
				ref Scenario parentScen4 = ref myUnit.ParentScen;
				string key = item6.Key;
				WeaponSalvo weaponSalvo_2 = item6.Value;
				unitSide4.RemoveThisUnitFromThisSalvos(ref parentScen4, key, ref weaponSalvo_2);
			}
			if (list.Count <= 0)
			{
				return;
			}
			foreach (WeaponSalvo item7 in list)
			{
				ArrayExtensions.Remove(ref myUnit.GetUnitSide().WeaponSalvos, item7);
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 200578", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool CreateConsumer(Weapon weapon_0, Contact contact_0, ref string string_0)
	{
		bool flag = false;
		bool result = false;
		try
		{
			float num;
			switch (weapon_0.Type)
			{
			case Weapon._WeaponType.Torpedo:
				num = 90f;
				break;
			case Weapon._WeaponType.DepthCharge:
				num = 20f;
				break;
			case Weapon._WeaponType.Sonobuoy:
				num = 4f;
				break;
			case Weapon._WeaponType.GuidedWeapon:
				num = 40f;
				if (weapon_0.Flags.HOB_AAM)
				{
					num += 20f;
				}
				if (myUnit.IsAircraft && ((Aircraft)myUnit).HasHelmetMountedSight)
				{
					num += 30f;
				}
				if (myUnit.IsAircraft)
				{
					flag = true;
				}
				break;
			case Weapon._WeaponType.Rocket:
				num = 30f;
				break;
			case Weapon._WeaponType.IronBomb:
			case Weapon._WeaponType.BottomMine:
			case Weapon._WeaponType.MooredMine:
			case Weapon._WeaponType.FloatingMine:
			case Weapon._WeaponType.MovingMine:
			case Weapon._WeaponType.RisingMine:
			case Weapon._WeaponType.DriftingMine:
			case Weapon._WeaponType.DummyMine:
				num = 30f;
				break;
			case Weapon._WeaponType.Gun:
				num = 8f;
				if (myUnit.IsAircraft)
				{
					flag = true;
				}
				break;
			default:
				num = 20f;
				break;
			case Weapon._WeaponType.Decoy_Vehicle:
			case Weapon._WeaponType.UAV_Expendable:
				num = 135f;
				break;
			}
			if (myUnit.IsAircraft && contact_0.IsSurfaceContact)
			{
				if (weapon_0.Guidance == Weapon.WeaponGuidanceType.Inertial || weapon_0.Is_LOAL_capable)
				{
					flag = false;
				}
				Weapon.WeaponGuidanceType guidance = weapon_0.Guidance;
				if (guidance == Weapon.WeaponGuidanceType.SemiActive || (int)(guidance - 14) <= 1)
				{
					flag = false;
				}
			}
			if (flag)
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				float value = Module_Unit.DefineTokenizer(contact_0, myUnit, ref double_, ref double_2);
				if (Math.Abs(double_) > (double)num)
				{
					string_0 = "Target is outside horizontal boresight limit";
				}
				if (Math.Abs(double_2) > (double)num)
				{
					if (Operators.CompareString(string_0, "", TextCompare: false) == 0)
					{
						string_0 += "Target is outside vertical boresight limit, check observer altitude and pitch";
					}
					else
					{
						string_0 = "Target is outside horizontal and vertical boresight limits, check observer altitude, orientation and pitch ";
					}
				}
				return result = Math.Abs(value) < num;
			}
			ActiveUnit unit_ = myUnit;
			string string_ = "";
			return result = Math.Abs(Module_Unit.PrintTokenizer(contact_0, unit_, bool_0: true, ref string_)) < num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100298", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public bool CanPhysicallyAttackThisTargetRightNow(Contact contact_0, bool bool_1, bool bool_2)
	{
		short? nullable_ = null;
		if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
		{
			WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
			for (int i = 0; i < weapons.Length; i = checked(i + 1))
			{
				weapons[i].GetReferenceWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
			}
			WeaponRec[] weapons2 = ((Aircraft)myUnit).Loadout.Weapons;
			WeaponRec[] array = weapons2;
			foreach (WeaponRec weaponRec in array)
			{
				if (weaponRec.CurrentLoad != 0 && (bool_2 || weaponRec.TimeToFire <= 0f))
				{
					ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
					Weapon referenceWeapon = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
					Sensor sensor_ = null;
					if (weaponry.CanThisWeaponEngageThisTarget(referenceWeapon, contact_0, ref nullable_, bool_1: false, bool_1, bool_3: false, null, ref sensor_).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
					{
						return true;
					}
				}
			}
		}
		foreach (Mount mount in myUnit.Mounts)
		{
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				if (mountWeapon.CurrentLoad != 0 && (bool_2 || mountWeapon.TimeToFire <= 0f))
				{
					ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
					Weapon referenceWeapon2 = mountWeapon.GetReferenceWeapon(myUnit.ParentScen);
					Sensor sensor_2 = null;
					if (weaponry2.CanThisWeaponEngageThisTarget(referenceWeapon2, contact_0, ref nullable_, bool_1: false, bool_1, bool_3: false, mount, ref sensor_2).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool CreateSalvo(Contact contact_0, int int_0, int int_1, bool bool_1, ref Doctrine._GunStrafeGroundTargets? nullable_0, [Optional][DateTimeConstant(0L)] DateTime theScheduledTime, bool bool_2 = false, bool bool_3 = false, bool bool_4 = true, bool bool_5 = false)
	{
		if (bool_3)
		{
			myUnit.GetUnitSide().RebuildSalvoCache();
		}
		if (bool_1)
		{
			myUnit.AI.ManuallyMarkTargetHostile(ref contact_0, bool_1);
		}
		else if (InstantiateConsumer(contact_0.Type) == Doctrine._WCS.Hold)
		{
			return false;
		}
		bool? nullable_ = null;
		try
		{
			switch (contact_0.Type)
			{
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.Submarine:
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
				if (regWrapper)
				{
					return false;
				}
				goto default;
			case Contact_Base.ContactType.Decoy_Air:
			{
				if (regWrapper)
				{
					return false;
				}
				bool flag = false;
				if (contact_0.DetectedEmissions.Count > 0)
				{
					foreach (KeyValuePair<int, EmissionContainer> detectedEmission in contact_0.DetectedEmissions)
					{
						if (detectedEmission.Value.GetAssociatedSensor(detectedEmission.Key, myUnit.ParentScen).IsOECM)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					return false;
				}
				goto default;
			}
			default:
			{
				if (contact_0.BDA_StructuralIntegrity.HasValue)
				{
					byte? b = (byte?)contact_0.BDA_StructuralIntegrity;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						return false;
					}
				}
				List<WeaponSalvo> list = myUnit.GetUnitSide().WeaponSalvosForThisTarget(contact_0);
				bool flag12 = false;
				bool flag17 = false;
				bool flag18 = true;
				WeaponSalvo weaponSalvo_ = null;
				if (bool_1)
				{
					foreach (WeaponSalvo item9 in list)
					{
						if (item9.Target == contact_0 && int_0 == item9.int_0)
						{
							int num = item9.ShootersList.Length - 1;
							for (int i = 0; i <= num; i++)
							{
								WeaponSalvo.Shooter shooter;
								try
								{
									shooter = item9.ShootersList[i];
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									ProjectData.ClearProjectError();
									continue;
								}
								if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
								{
									weaponSalvo_ = item9;
									break;
								}
							}
						}
						if (weaponSalvo_ != null)
						{
							break;
						}
					}
				}
				else
				{
					if (myUnit.GetUnitSide().callbackProxy != null)
					{
						IEnumerator<KeyValuePair<string, FiringProposal>> enumerator11 = myUnit.GetUnitSide().callbackProxy.GetEnumerator();
						while (enumerator11.MoveNext())
						{
							FiringProposal value = enumerator11.Current.Value;
							if (Operators.CompareString(value.Target.ObjectID, contact_0.ObjectID, TextCompare: false) == 0 && Operators.CompareString(value.FiringUnit.ObjectID, myUnit.ObjectID, TextCompare: false) == 0)
							{
								return true;
							}
						}
					}
					foreach (WeaponSalvo item10 in list)
					{
						if (item10.Target == contact_0)
						{
							int num12 = item10.ShootersList.Length - 1;
							for (int j = 0; j <= num12; j++)
							{
								WeaponSalvo.Shooter shooter2;
								try
								{
									shooter2 = item10.ShootersList[j];
								}
								catch (Exception projectError2)
								{
									ProjectData.SetProjectError(projectError2);
									ProjectData.ClearProjectError();
									continue;
								}
								if (Operators.CompareString(shooter2.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
								{
									if (myUnit.IsAircraft)
									{
										return false;
									}
									flag17 = true;
								}
							}
							if (!item10.FireSimultaneouslyFromMultipleMounts)
							{
								flag12 = true;
							}
						}
						if (flag18 && item10.GetReferenceWeapon(myUnit.ParentScen) != null && !item10.GetReferenceWeapon(myUnit.ParentScen).IsMobileDecoy)
						{
							flag18 = false;
						}
					}
				}
				Weapon weapon = new Weapon(ref myUnit.ParentScen, int_0);
				weapon.FiringParent = myUnit;
				bool? nullable_9 = null;
				Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon, ref nullable_9);
				if (_WRA_WeaponTargetType_ == Doctrine._WRA_WeaponTargetType.Radar_Unspecified)
				{
					List<Weapon> list2 = AllDistinctWeaponsAboard_Actual();
					new List<Weapon>();
					Weapon weapon2 = null;
					foreach (Weapon item11 in list2)
					{
						if (item11.ValidTargets.Radar)
						{
							weapon2 = item11;
							break;
						}
					}
					if (weapon2 == null)
					{
						ref Contact contact_ = ref contact_0;
						nullable_9 = false;
						_WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_, weapon, ref nullable_9);
					}
				}
				if (m_MethodWrapper == null)
				{
					m_MethodWrapper = new Dictionary<int, WeaponSalvoWpnQty>();
				}
				else
				{
					m_MethodWrapper.Clear();
				}
				WeaponRec weaponRec = null;
				short? nullable_10 = null;
				Sensor sensor = null;
				WeaponRec weaponRec2 = null;
				float? num23 = null;
				float? num28 = null;
				float? num29 = null;
				bool result = true;
				bool flag19 = false;
				if (_ServiceWrapper == null)
				{
					_ServiceWrapper = new List<WeaponRec>();
				}
				else
				{
					_ServiceWrapper.Clear();
				}
				try
				{
					int? num30 = null;
					float? num31 = null;
					int? num32 = null;
					WeaponRec weaponRec3 = null;
					Weapon weapon_;
					if (myUnit.IsPalletWeapon)
					{
						foreach (WeaponRec weaponWeapon in ((Weapon)myUnit).WeaponWeapons)
						{
							if (weaponWeapon.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0)
							{
								weaponRec3 = weaponWeapon;
								break;
							}
						}
						weaponRec3.ParentMount = null;
						if (!bool_1)
						{
							if (weaponRec3.CurrentLoad == 0)
							{
								return false;
							}
							if (weaponRec3.TimeToFire <= 0f)
							{
								if (m_MethodWrapper.ContainsKey(weaponRec3.int_0))
								{
									int? weaponQty_Available = m_MethodWrapper[weaponRec3.int_0].WeaponQty_Available;
									if (Information.IsNothing(weaponQty_Available))
									{
										weaponQty_Available = weaponRec3.CurrentLoad;
									}
									else
									{
										weaponQty_Available += weaponRec3.CurrentLoad;
									}
									return false;
								}
								num30 = weaponRec3.CurrentLoad;
								if (m_MethodWrapper.ContainsKey(weaponRec3.int_0))
								{
									int? weaponQty_Available2 = m_MethodWrapper[weaponRec3.int_0].WeaponQty_Available;
									weaponQty_Available2 = ((!weaponQty_Available2.HasValue) ? num30 : (weaponQty_Available2 + num30));
									m_MethodWrapper[weaponRec3.int_0].WeaponQty_Available = weaponQty_Available2;
									return false;
								}
								if (weaponSalvo_ == null)
								{
									weapon_ = weaponRec3.GetReferenceWeapon(myUnit.ParentScen);
									if (weapon_.Type == Weapon._WeaponType.Gun && contact_0.IsSurfaceContact)
									{
										if (!nullable_0.HasValue)
										{
											nullable_0 = myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
										}
										byte? b2 = (byte?)nullable_0;
										if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
										{
											return false;
										}
									}
									if (weapon_.QueryReponse(myUnit, ref contact_0, ref nullable_))
									{
										float num33 = WeaponOuterRangeLimit(ref myUnit, ref weapon_, ref contact_0, bool_1: false);
										if (weapon_.Type == Weapon._WeaponType.Gun && Information.IsNothing(num28))
										{
											num28 = Module_Unit.RangeToUnit_Slant(myUnit, contact_0);
										}
										else if (!num23.HasValue)
										{
											num31 = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
											num23 = num31;
										}
										float? num2;
										if (weapon_.Type == Weapon._WeaponType.Gun)
										{
											num2 = num28;
											if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > num33) : null).GetValueOrDefault())
											{
												return false;
											}
										}
										num2 = num23;
										if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > num33) : null).GetValueOrDefault())
										{
											return false;
										}
										num29 = ((weapon_.Type == Weapon._WeaponType.Gun) ? num28 : num23);
										if (myUnit.Doctrine.InsertRepository(ref weapon_))
										{
											Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref contact_0, ref _WRA_WeaponTargetType_, myUnit.GetUnitSide().ObjectID);
											Doctrine doctrine = myUnit.Doctrine;
											Scenario parentScen = myUnit.ParentScen;
											Weapon weapon_9 = weapon_;
											Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = wRA_WeaponTargetType;
											int? nullable_11 = null;
											int? nullable_12 = null;
											num32 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, weapon_9, wRA_WeaponTargetType_, bool_0: false, ref nullable_11, ref nullable_12);
											nullable_12 = num32;
											if ((nullable_12.HasValue ? new bool?(nullable_12.GetValueOrDefault() == 0) : null).GetValueOrDefault())
											{
												return false;
											}
											nullable_12 = num32;
											if ((nullable_12.HasValue ? new bool?(nullable_12.GetValueOrDefault() == -99) : null).GetValueOrDefault())
											{
												num32 = int.MaxValue;
											}
											if (!num32.HasValue)
											{
												return false;
											}
											Doctrine doctrine9 = myUnit.Doctrine;
											Doctrine doctrine10 = myUnit.Doctrine;
											Scenario parentScen4 = myUnit.ParentScen;
											int dBID = weapon_.DBID;
											Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_3 = wRA_WeaponTargetType;
											num2 = null;
											float? nullable_13 = null;
											float? num3 = doctrine9.IncludeRepository(doctrine10, parentScen4, dBID, wRA_WeaponTargetType_3, bool_0: false, ref num2, ref nullable_13);
											if (Information.IsNothing(num3))
											{
												num3 = -99f;
											}
											nullable_13 = num3;
											if ((nullable_13.HasValue ? new bool?(nullable_13.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
											{
												return false;
											}
											nullable_13 = num3;
											nullable_9 = (nullable_13.HasValue ? new bool?(nullable_13.GetValueOrDefault() == -99f) : null);
											if (((!nullable_9) ?? nullable_9).GetValueOrDefault())
											{
												float maxRangeForThisTarget = weapon_.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, myUnit.Doctrine, bool_1);
												if ((num29.HasValue ? new bool?(maxRangeForThisTarget < num29.GetValueOrDefault()) : null).GetValueOrDefault())
												{
													return false;
												}
											}
											if (list.Count > 0 && !flag18 && !weapon_.IsMobileDecoy)
											{
												if (contact_0.IsAir_Missile_Orbital_Contact)
												{
													bool flag20 = false;
													foreach (WeaponSalvo item12 in list)
													{
														if (item12.int_0 == weapon_.DBID)
														{
															flag20 = true;
															break;
														}
													}
													if (flag20)
													{
														return false;
													}
												}
												Doctrine doctrine11 = myUnit.Doctrine;
												Doctrine doctrine12 = myUnit.Doctrine;
												Scenario parentScen5 = myUnit.ParentScen;
												Weapon weapon_10 = weapon_;
												Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_4 = wRA_WeaponTargetType;
												nullable_13 = null;
												num2 = null;
												float? num4 = doctrine11.SetupRepository(doctrine12, parentScen5, weapon_10, wRA_WeaponTargetType_4, bool_0: false, ref nullable_13, ref num2);
												num2 = num4;
												if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
												{
													num4 = (int)Math.Round(num33);
												}
												num2 = num4;
												if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
												{
													num2 = num4;
													nullable_9 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() > 0f) : null);
													if (!nullable_9.GetValueOrDefault(true) || !((num4.HasValue & num29.HasValue) ? new bool?(num4.GetValueOrDefault() < num29.GetValueOrDefault()) : null).GetValueOrDefault() || !nullable_9.HasValue)
													{
														goto IL_1102;
													}
												}
												bool flag21 = false;
												foreach (WeaponSalvo item13 in list)
												{
													if (item13.int_0 == weapon_.DBID && item13.ShootersList.Length < item13.MaxNumberOfShooters && (item13.MaxNumberOfWeapons == int.MaxValue || item13.MaxNumberOfWeapons > item13.WpnQuantityAssigned))
													{
														flag21 = true;
														break;
													}
												}
												if (!flag21)
												{
													return false;
												}
											}
										}
										goto IL_1102;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						goto IL_107c;
					}
					goto IL_1282;
					IL_1102:
					if (list.Count > 0)
					{
						bool flag22 = false;
						foreach (WeaponSalvo item14 in list)
						{
							if (item14.int_0 != weapon_.DBID)
							{
								continue;
							}
							if (item14.WpnQuantityAssigned >= item14.MaxNumberOfWeapons && item14.MaxNumberOfWeapons != int.MaxValue)
							{
								flag22 = true;
							}
							if (!flag22)
							{
								WeaponSalvo.Shooter[] shootersList2 = item14.ShootersList;
								for (int k = 0; k < shootersList2.Length; k++)
								{
									if (Operators.CompareString(shootersList2[k].ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
									{
										flag22 = true;
										break;
									}
								}
							}
							if (flag22 || item14.ShootersList.Length >= item14.MaxNumberOfShooters)
							{
								continue;
							}
							weaponSalvo_ = item14;
							break;
						}
						if (flag22)
						{
							return false;
						}
					}
					ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
					Weapon weapon_11 = weapon_;
					Contact contact_2 = contact_0;
					sensor = null;
					if (weaponry.CanThisWeaponEngageThisTarget(weapon_11, contact_2, ref nullable_10, bool_1, bool_2: false, bool_3: false, null, ref sensor).EvaluationEnum != 0)
					{
						return false;
					}
					goto IL_107c;
					IL_1282:
					if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
						for (int n = 0; n < weapons.Length; n = checked(n + 1))
						{
							weaponRec3 = weapons[n];
							weaponRec3.GetReferenceWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
						}
						int num5 = 0;
						WeaponRec[] weapons2 = ((Aircraft)myUnit).Loadout.Weapons;
						for (int m2 = 0; m2 < weapons2.Length; m2 = checked(m2 + 1))
						{
							weaponRec3 = weapons2[m2];
							num5 += weaponRec3.CurrentLoad;
						}
						foreach (Mount mount in ((Aircraft)myUnit).Mounts)
						{
							foreach (WeaponRec mountWeapon in mount.MountWeapons)
							{
								num5 += mountWeapon.CurrentLoad;
							}
						}
						if (num5 == 0)
						{
							return false;
						}
						int num6 = 0;
						int num7 = 0;
						WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
						float num8 = 0f;
						bool bool_6 = false;
						for (int n2 = 0; n2 < weapons3.Length; n2 = checked(n2 + 1))
						{
							weaponRec3 = weapons3[n2];
							if (weaponSalvo_ == null)
							{
								bool flag23 = false;
								if (weaponRec3.int_0 == int_0)
								{
									flag23 = true;
								}
								else if (weaponRec3.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon && weaponRec3.GetReferenceWeapon(myUnit.ParentScen).Warheads.Count() > 0)
								{
									flag23 = true;
									num6 = weaponRec3.MaxLoad * weaponRec3.GetReferenceWeapon(myUnit.ParentScen).Warheads.Where((Warhead x) => x.DP == (float)int_0).Count();
									num7 = weaponRec3.CurrentLoad * weaponRec3.GetReferenceWeapon(myUnit.ParentScen).Warheads.Where((Warhead x) => x.DP == (float)int_0).Count();
									if (num7 > 0)
									{
										flag23 = true;
									}
									weaponRec = new WeaponRec(ref myUnit.ParentScen, int_0, num7, num6, 1, 1, bool_0: false, bool_1: false);
								}
								if (!flag23 && int_0 != 0)
								{
									continue;
								}
							}
							else
							{
								bool flag2 = false;
								if (weaponRec3.int_0 == int_0)
								{
									flag2 = true;
								}
								else if (weaponRec3.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon && weaponRec3.GetReferenceWeapon(myUnit.ParentScen).Warheads.Count() > 0)
								{
									flag2 = true;
									num6 = weaponRec3.MaxLoad * weaponRec3.GetReferenceWeapon(myUnit.ParentScen).Warheads.Where((Warhead x) => x.DP == (float)int_0).Count();
									num7 = weaponRec3.CurrentLoad * weaponRec3.GetReferenceWeapon(myUnit.ParentScen).Warheads.Where((Warhead x) => x.DP == (float)int_0).Count();
									if (num7 > 0)
									{
										flag2 = true;
									}
									weaponRec = new WeaponRec(ref myUnit.ParentScen, int_0, num7, num6, 1, 1, bool_0: false, bool_1: false);
								}
								if (!flag2 && int_0 != 0)
								{
									continue;
								}
							}
							weaponRec3.ParentMount = null;
							Weapon weapon_12;
							if (!bool_1)
							{
								if (weaponRec3.CurrentLoad == 0 || !(weaponRec3.TimeToFire <= 0f))
								{
									continue;
								}
								if (m_MethodWrapper.ContainsKey(weaponRec3.int_0))
								{
									int? weaponQty_Available3 = m_MethodWrapper[weaponRec3.int_0].WeaponQty_Available;
									if (Information.IsNothing(weaponQty_Available3))
									{
										weaponQty_Available3 = weaponRec3.CurrentLoad;
									}
									else
									{
										weaponQty_Available3 += weaponRec3.CurrentLoad;
									}
									continue;
								}
								num30 = weaponRec3.CurrentLoad;
								if (m_MethodWrapper.ContainsKey(weaponRec3.int_0))
								{
									int? weaponQty_Available4 = m_MethodWrapper[weaponRec3.int_0].WeaponQty_Available;
									weaponQty_Available4 = ((!weaponQty_Available4.HasValue) ? num30 : (weaponQty_Available4 + num30));
									m_MethodWrapper[weaponRec3.int_0].WeaponQty_Available = weaponQty_Available4;
									continue;
								}
								if (weaponSalvo_ != null)
								{
									continue;
								}
								weapon_12 = ((weaponRec == null) ? weaponRec3.GetReferenceWeapon(myUnit.ParentScen) : weaponRec.GetReferenceWeapon(myUnit.ParentScen));
								if (weapon_12.Type == Weapon._WeaponType.Gun && contact_0.IsSurfaceContact)
								{
									if (!nullable_0.HasValue)
									{
										nullable_0 = myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									}
									byte? b3 = (byte?)nullable_0;
									if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
									{
										continue;
									}
								}
								if (!weapon_12.QueryReponse(myUnit, ref contact_0, ref nullable_))
								{
									continue;
								}
								if (weapon_12.IsPalletWeapon)
								{
									if (weapon_12.WeaponWeapons.Count == 0)
									{
										weapon_12.InitializeWeaponWeaponsPallet();
									}
									foreach (WeaponRec weaponWeapon2 in weapon_12.WeaponWeapons)
									{
										Weapon weapon_13 = weaponWeapon2.GetReferenceWeapon(myUnit.ParentScen);
										float num9 = WeaponOuterRangeLimit(ref myUnit, ref weapon_13, ref contact_0, bool_1: false);
										if (num9 > num8)
										{
											num8 = num9;
										}
									}
								}
								else
								{
									num8 = WeaponOuterRangeLimit(ref myUnit, ref weapon_12, ref contact_0, bool_1: false);
								}
								if (weapon_12.Type == Weapon._WeaponType.Gun && Information.IsNothing(num28))
								{
									num28 = Module_Unit.RangeToUnit_Slant(myUnit, contact_0);
								}
								else if (!num23.HasValue)
								{
									num31 = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
									num23 = num31;
								}
								float? num10;
								if (weapon_12.Type == Weapon._WeaponType.Gun)
								{
									num10 = num28;
									if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() > num8) : null).GetValueOrDefault())
									{
										continue;
									}
								}
								num10 = num23;
								if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() > num8) : null).GetValueOrDefault())
								{
									if (myUnit.IsAircraft && myUnit.AI.PrimaryTarget == null)
									{
										ActiveUnit activeUnit = myUnit;
										Aircraft_AI aI = ((Aircraft)myUnit).AI;
										Aircraft aircraft_ = (Aircraft)myUnit;
										activeUnit.DesiredAltitude = aI.PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: false, ref bool_6);
										if (!myUnit.IsGroupWingman())
										{
											myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_6);
										}
									}
									continue;
								}
								num29 = ((weapon_12.Type == Weapon._WeaponType.Gun) ? num28 : num23);
								if (myUnit.Doctrine.InsertRepository(ref weapon_12))
								{
									Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType2 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_12, ref contact_0, ref _WRA_WeaponTargetType_, myUnit.GetUnitSide().ObjectID);
									int? nullable_15;
									if (weapon_12.IsPalletWeapon)
									{
										num32 = 1;
									}
									else
									{
										Doctrine doctrine13 = myUnit.Doctrine;
										Scenario parentScen6 = myUnit.ParentScen;
										Weapon weapon_14 = weapon_12;
										Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_5 = wRA_WeaponTargetType2;
										int? nullable_14 = null;
										nullable_15 = null;
										num32 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine13, parentScen6, weapon_14, wRA_WeaponTargetType_5, bool_0: false, ref nullable_14, ref nullable_15);
									}
									nullable_15 = num32;
									if ((nullable_15.HasValue ? new bool?(nullable_15.GetValueOrDefault() == 0) : null).GetValueOrDefault())
									{
										continue;
									}
									nullable_15 = num32;
									if ((nullable_15.HasValue ? new bool?(nullable_15.GetValueOrDefault() == -99) : null).GetValueOrDefault())
									{
										num32 = int.MaxValue;
									}
									nullable_15 = num32;
									if ((nullable_15.HasValue ? new bool?(nullable_15.GetValueOrDefault() < 0) : null).GetValueOrDefault())
									{
										num32 = myUnit.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(num32, ref myUnit, ref contact_0, ref weapon_12);
									}
									if (!num32.HasValue)
									{
										continue;
									}
									Doctrine doctrine14 = myUnit.Doctrine;
									Doctrine doctrine15 = myUnit.Doctrine;
									Scenario parentScen7 = myUnit.ParentScen;
									int dBID2 = weapon_12.DBID;
									Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_6 = wRA_WeaponTargetType2;
									num10 = null;
									float? nullable_16 = null;
									float? num11 = doctrine14.IncludeRepository(doctrine15, parentScen7, dBID2, wRA_WeaponTargetType_6, bool_0: false, ref num10, ref nullable_16);
									if (Information.IsNothing(num11))
									{
										num11 = -99f;
									}
									nullable_16 = num11;
									if ((nullable_16.HasValue ? new bool?(nullable_16.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
									{
										continue;
									}
									nullable_16 = num11;
									nullable_9 = (nullable_16.HasValue ? new bool?(nullable_16.GetValueOrDefault() == -99f) : null);
									if (((!nullable_9) ?? nullable_9).GetValueOrDefault())
									{
										float maxRangeForThisTarget2 = weapon_12.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, myUnit.Doctrine, bool_1);
										if ((num29.HasValue ? new bool?(maxRangeForThisTarget2 < num29.GetValueOrDefault()) : null).GetValueOrDefault())
										{
											continue;
										}
									}
									bool flag3 = CompareConsumer(contact_0);
									if (list.Count > 0 && !flag18 && !weapon_12.IsMobileDecoy)
									{
										if (contact_0.IsAir_Missile_Orbital_Contact)
										{
											bool flag4 = false;
											foreach (WeaponSalvo item15 in list)
											{
												if (item15.int_0 == weapon_12.DBID)
												{
													flag4 = true;
													break;
												}
											}
											if (flag4 && !flag3)
											{
												continue;
											}
										}
										Doctrine doctrine16 = myUnit.Doctrine;
										Doctrine doctrine2 = myUnit.Doctrine;
										Scenario parentScen8 = myUnit.ParentScen;
										Weapon weapon_15 = weapon_12;
										Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_7 = wRA_WeaponTargetType2;
										nullable_16 = null;
										num10 = null;
										float? num13 = doctrine16.SetupRepository(doctrine2, parentScen8, weapon_15, wRA_WeaponTargetType_7, bool_0: false, ref nullable_16, ref num10);
										num10 = num13;
										if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
										{
											num13 = (int)Math.Round(num8);
										}
										num10 = num13;
										if (!(num10.HasValue ? new bool?(num10.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
										{
											num10 = num13;
											nullable_9 = (num10.HasValue ? new bool?(num10.GetValueOrDefault() > 0f) : null);
											if (!nullable_9.GetValueOrDefault(true) || !((num13.HasValue & num29.HasValue) ? new bool?(num13.GetValueOrDefault() < num29.GetValueOrDefault()) : null).GetValueOrDefault() || !nullable_9.HasValue)
											{
												goto IL_2360;
											}
										}
										bool flag5 = false;
										foreach (WeaponSalvo item16 in list)
										{
											if (item16.int_0 == weapon_12.DBID && item16.ShootersList.Length < item16.MaxNumberOfShooters && (item16.MaxNumberOfWeapons == int.MaxValue || item16.MaxNumberOfWeapons > item16.WpnQuantityAssigned))
											{
												flag5 = true;
												break;
											}
										}
										if (flag3 && !flag5)
										{
											list = new List<WeaponSalvo>();
										}
										else if (!flag5)
										{
											continue;
										}
									}
								}
								goto IL_2360;
							}
							goto IL_26cf;
							IL_26cf:
							if (weaponRec == null)
							{
								_ServiceWrapper.Add(weaponRec3);
							}
							else
							{
								_ServiceWrapper.Add(weaponRec);
							}
							if (bool_1)
							{
								break;
							}
							WeaponSalvoWpnQty value3 = new WeaponSalvoWpnQty(num32, num30);
							if (weaponRec == null)
							{
								m_MethodWrapper.Add(weaponRec3.int_0, value3);
							}
							else
							{
								m_MethodWrapper.Add(weaponRec.int_0, value3);
							}
							continue;
							IL_2360:
							if (list.Count > 0)
							{
								bool flag6 = false;
								foreach (WeaponSalvo item2 in list)
								{
									if (item2.int_0 != weapon_12.DBID)
									{
										continue;
									}
									if (item2.WpnQuantityAssigned >= item2.MaxNumberOfWeapons && item2.MaxNumberOfWeapons != int.MaxValue)
									{
										flag6 = true;
									}
									if (!flag6)
									{
										WeaponSalvo.Shooter[] shootersList4 = item2.ShootersList;
										for (int m = 0; m < shootersList4.Length; m++)
										{
											if (Operators.CompareString(shootersList4[m].ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
											{
												flag6 = true;
												break;
											}
										}
									}
									if (flag6 || item2.ShootersList.Length >= item2.MaxNumberOfShooters)
									{
										continue;
									}
									weaponSalvo_ = item2;
									break;
								}
								if (flag6)
								{
									continue;
								}
							}
							bool flag7 = false;
							if (weapon_12.IsPalletWeapon)
							{
								if (weapon_12.WeaponWeapons.Count == 0)
								{
									weapon_12.InitializeWeaponWeaponsPallet();
								}
								foreach (WeaponRec weaponWeapon3 in weapon_12.WeaponWeapons)
								{
									Weapon referenceWeapon = weaponWeapon3.GetReferenceWeapon(myUnit.ParentScen);
									ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
									Contact contact_3 = contact_0;
									sensor = null;
									if (weaponry2.CanThisWeaponEngageThisTarget(referenceWeapon, contact_3, ref nullable_10, bool_1, bool_2: false, bool_3: false, null, ref sensor).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
									{
										flag7 = true;
										break;
									}
								}
								if (!flag7)
								{
									continue;
								}
							}
							else
							{
								ActiveUnit_Weaponry weaponry3 = myUnit.Weaponry;
								Weapon weapon_16 = weapon_12;
								Contact contact_4 = contact_0;
								sensor = null;
								if (weaponry3.CanThisWeaponEngageThisTarget(weapon_16, contact_4, ref nullable_10, bool_1, bool_2: false, bool_3: false, null, ref sensor).EvaluationEnum != 0)
								{
									continue;
								}
							}
							goto IL_26cf;
						}
					}
					if (_ServiceWrapper.Count == 0)
					{
						bool flag8 = CompareConsumer(contact_0);
						bool bool_7 = false;
						foreach (Mount mount2 in myUnit.Mounts)
						{
							if (!bool_1 && (mount2.TimeToFire != 0f || mount2.MountMagazine.TimeToFire != 0f))
							{
								continue;
							}
							foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
							{
								if (weaponSalvo_ == null)
								{
									if (bool_1 && mountWeapon2.int_0 != int_0)
									{
										continue;
									}
								}
								else if (mountWeapon2.int_0 != weaponSalvo_.int_0)
								{
									continue;
								}
								mountWeapon2.ParentMount = mount2;
								Weapon weapon_2;
								float? nullable_4;
								if (!bool_1)
								{
									if (mount2.Status != 0 || mountWeapon2.TimeToFire != 0f || mountWeapon2.CurrentLoad == 0)
									{
										continue;
									}
									num30 = mountWeapon2.CurrentLoad;
									if (mount2.MountMagazine.Weapons.Count > 0)
									{
										bool flag9 = false;
										if (mount2.MountMagazine.Weapons.Count > 1)
										{
											foreach (WeaponRec mountWeapon3 in mount2.MountWeapons)
											{
												if (mountWeapon3.GetHasManualReloadPriority(mount2))
												{
													flag9 = true;
													break;
												}
											}
										}
										if (!flag9)
										{
											num30 += HowManyOfThisWeaponOnMountMagazine(mount2, mountWeapon2.int_0);
										}
									}
									int? num14 = num30;
									if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == 0) : null).GetValueOrDefault())
									{
										continue;
									}
									if (m_MethodWrapper.ContainsKey(mountWeapon2.int_0))
									{
										int? weaponQty_Available5 = m_MethodWrapper[mountWeapon2.int_0].WeaponQty_Available;
										weaponQty_Available5 = ((!weaponQty_Available5.HasValue) ? num30 : (weaponQty_Available5 + num30));
										m_MethodWrapper[mountWeapon2.int_0].WeaponQty_Available = weaponQty_Available5;
										continue;
									}
									if (weaponSalvo_ != null)
									{
										continue;
									}
									weapon_2 = mountWeapon2.GetReferenceWeapon(myUnit.ParentScen);
									weapon_2.FiringParent = myUnit;
									if (myUnit.IsAircraft && weapon_2.Type == Weapon._WeaponType.Gun && contact_0.IsSurfaceContact)
									{
										if (!nullable_0.HasValue)
										{
											nullable_0 = myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
										}
										byte? b4 = (byte?)nullable_0;
										if ((b4.HasValue ? new bool?(b4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
										{
											continue;
										}
									}
									if (!weapon_2.QueryReponse(myUnit, ref contact_0, ref nullable_))
									{
										continue;
									}
									float num15 = WeaponOuterRangeLimit(ref myUnit, ref weapon_2, ref contact_0, bool_1: false);
									if (weapon_2.Type == Weapon._WeaponType.Gun && Information.IsNothing(num28))
									{
										num28 = Module_Unit.RangeToUnit_Slant(myUnit, contact_0);
									}
									else if (!num23.HasValue)
									{
										if (!num31.HasValue)
										{
											num31 = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
										}
										num23 = num31;
									}
									float? num16;
									if (weapon_2.Type == Weapon._WeaponType.Gun)
									{
										num16 = num28;
										if ((num16.HasValue ? new bool?(num16.GetValueOrDefault() > num15) : null).GetValueOrDefault())
										{
											continue;
										}
									}
									num16 = num23;
									if ((num16.HasValue ? new bool?(num16.GetValueOrDefault() > num15) : null).GetValueOrDefault())
									{
										continue;
									}
									num29 = ((weapon_2.Type == Weapon._WeaponType.Gun) ? num28 : num23);
									if (myUnit.Doctrine.InsertRepository(ref weapon_2))
									{
										Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType3 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_2, ref contact_0, ref _WRA_WeaponTargetType_, myUnit.GetUnitSide().ObjectID);
										Doctrine doctrine3 = myUnit.Doctrine;
										Scenario parentScen9 = myUnit.ParentScen;
										Weapon weapon_3 = weapon_2;
										Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_8 = wRA_WeaponTargetType3;
										num14 = null;
										int? nullable_2 = null;
										num32 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine3, parentScen9, weapon_3, wRA_WeaponTargetType_8, bool_0: false, ref num14, ref nullable_2);
										nullable_2 = num32;
										if ((nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
										{
											continue;
										}
										nullable_2 = num32;
										if ((nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() == -99) : null).GetValueOrDefault())
										{
											num32 = int.MaxValue;
										}
										if (!num32.HasValue)
										{
											continue;
										}
										Doctrine doctrine4 = myUnit.Doctrine;
										Doctrine doctrine5 = myUnit.Doctrine;
										Scenario parentScen10 = myUnit.ParentScen;
										int dBID3 = weapon_2.DBID;
										Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_9 = wRA_WeaponTargetType3;
										num16 = null;
										float? nullable_3 = null;
										float? num17 = doctrine4.IncludeRepository(doctrine5, parentScen10, dBID3, wRA_WeaponTargetType_9, bool_0: false, ref num16, ref nullable_3);
										if (!num17.HasValue)
										{
											num17 = Doctrine.WRA_FiringRange_GetDefaultFiringRange(myUnit.ParentScen, weapon_2.DBID, wRA_WeaponTargetType3);
										}
										nullable_3 = num17;
										if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
										{
											continue;
										}
										nullable_3 = num17;
										num16 = nullable_3;
										if (!(num16.HasValue ? new bool?(num16.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
										{
											num16 = nullable_3;
											if ((num16.HasValue ? new bool?(num16.GetValueOrDefault() == -97f) : null).GetValueOrDefault())
											{
												num15 *= 0.75f;
											}
											else
											{
												num16 = nullable_3;
												if ((num16.HasValue ? new bool?(num16.GetValueOrDefault() == -96f) : null).GetValueOrDefault())
												{
													num15 *= 0.5f;
												}
												else
												{
													num16 = nullable_3;
													if ((num16.HasValue ? new bool?(num16.GetValueOrDefault() == -95f) : null).GetValueOrDefault())
													{
														num15 *= 0.25f;
													}
													else
													{
														num16 = nullable_3;
														if ((num16.HasValue ? new bool?(num16.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
														{
															bool bool_8 = false;
															if (bool_1)
															{
																bool_8 = true;
															}
															if (GameGeneral.SpeedUp_NEZ_DLZ)
															{
																num15 *= 0.5f;
																if ((num29.HasValue ? new bool?(num15 < num29.GetValueOrDefault()) : null).GetValueOrDefault())
																{
																	return false;
																}
															}
															else
															{
																if (method_0(contact_0, weapon_2, bool_1: false, null, null, bool_8).Item1 != DLZResultEnum.Success)
																{
																	return false;
																}
																num15 = (float)Math.Round(Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), contact_0.GetLatitude(), weapon_2.GetLongitude()), 2);
															}
														}
														else if (num17.HasValue)
														{
															num16 = num17;
															if ((num16.HasValue ? new bool?(num16.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
															{
																num15 = num17.Value;
															}
														}
													}
												}
											}
										}
										num16 = num17;
										bool? flag10 = (num16.HasValue ? new bool?(num16.GetValueOrDefault() == -99f) : null);
										nullable_9 = (!flag10) ?? flag10;
										if (nullable_9.GetValueOrDefault(true) && (num29.HasValue ? new bool?(num15 < num29.GetValueOrDefault()) : null).GetValueOrDefault() && nullable_9.HasValue)
										{
											continue;
										}
										if (list.Count > 0 && !flag18 && !weapon_2.IsMobileDecoy)
										{
											if (contact_0.IsAir_Missile_Orbital_Contact)
											{
												bool flag11 = false;
												foreach (WeaponSalvo item3 in list)
												{
													if ((item3.int_0 == weapon_2.DBID) & (item3.ShootersList.Count() > 0))
													{
														flag11 = true;
														break;
													}
												}
												if (flag11 && !flag8)
												{
													continue;
												}
											}
											Doctrine doctrine6 = myUnit.Doctrine;
											Doctrine doctrine7 = myUnit.Doctrine;
											Scenario parentScen11 = myUnit.ParentScen;
											Weapon weapon_4 = weapon_2;
											Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_10 = wRA_WeaponTargetType3;
											num16 = null;
											nullable_4 = null;
											float? num18 = doctrine6.SetupRepository(doctrine7, parentScen11, weapon_4, wRA_WeaponTargetType_10, bool_0: false, ref num16, ref nullable_4);
											nullable_4 = num18;
											if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
											{
												num18 = (int)Math.Round(num15);
											}
											nullable_4 = num18;
											if (!(nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
											{
												nullable_4 = num18;
												nullable_9 = (nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() > 0f) : null);
												if (!nullable_9.GetValueOrDefault(true) || !((num18.HasValue & num29.HasValue) ? new bool?(num18.GetValueOrDefault() < num29.GetValueOrDefault()) : null).GetValueOrDefault() || !nullable_9.HasValue)
												{
													if (flag17 && (weapon_2.IsGuidedWeapon() || weapon_2.IsTorpedo))
													{
														continue;
													}
													goto IL_3b07;
												}
											}
											if ((flag12 && !flag8) || (!weapon_2.IsGuidedWeapon() && !weapon_2.IsTorpedo))
											{
												bool flag13 = false;
												foreach (WeaponSalvo item4 in list)
												{
													if (item4.int_0 == weapon_2.DBID && item4.ShootersList.Length < item4.MaxNumberOfShooters && (item4.MaxNumberOfWeapons == int.MaxValue || item4.MaxNumberOfWeapons > item4.WpnQuantityAssigned))
													{
														flag13 = true;
														break;
													}
												}
												if (!flag13)
												{
													continue;
												}
											}
										}
									}
									goto IL_3b07;
								}
								goto IL_3aaa;
								IL_3b07:
								if (list.Count > 0)
								{
									bool flag14 = false;
									foreach (WeaponSalvo item5 in list)
									{
										if (item5.int_0 != weapon_2.DBID)
										{
											continue;
										}
										if (item5.WpnQuantityAssigned >= item5.MaxNumberOfWeapons && item5.MaxNumberOfWeapons != int.MaxValue)
										{
											flag14 = true;
										}
										if (!flag14)
										{
											WeaponSalvo.Shooter[] shootersList3 = item5.ShootersList;
											for (int l = 0; l < shootersList3.Length; l++)
											{
												if (Operators.CompareString(shootersList3[l].ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
												{
													flag14 = true;
													break;
												}
											}
										}
										if (flag14 || item5.ShootersList.Length >= item5.MaxNumberOfShooters)
										{
											continue;
										}
										weaponSalvo_ = item5;
										break;
									}
									if (flag14)
									{
										continue;
									}
								}
								ActiveUnit_Weaponry weaponry4 = myUnit.Weaponry;
								Weapon weapon_5 = weapon_2;
								Contact contact_5 = contact_0;
								sensor = null;
								WeaponPrefireChecklistEvaluation item = weaponry4.CanThisWeaponEngageThisTarget(weapon_5, contact_5, ref nullable_10, bool_1, bool_2: false, bool_3: false, mount2, ref sensor).EvaluationEnum;
								if (item != 0)
								{
									switch (item)
									{
									case WeaponPrefireChecklistEvaluation.OutsideBoresightLimits:
										if (myUnit.IsAircraft && myUnit.AI.PrimaryTarget == null)
										{
											ActiveUnit activeUnit2 = myUnit;
											Aircraft_AI aI2 = ((Aircraft)myUnit).AI;
											Aircraft aircraft_2 = (Aircraft)myUnit;
											activeUnit2.DesiredAltitude = aI2.PrintFacade(ref aircraft_2, ActiveUnit.Throttle.Cruise, bool_0: false, ref bool_7);
											if (!myUnit.IsGroupWingman())
											{
												myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_7);
											}
										}
										break;
									case WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC:
										if (myUnit.AI.PrimaryTarget == null)
										{
											myUnit.AI.PrimaryTarget = contact_0;
										}
										break;
									}
									continue;
								}
								if (!flag19 && weapon_2.IsGuidedWeapon() && (weapon_2.Flags.TerminalIllumination || weapon_2.Flags.IlluminateAtLaunch || weapon_2.Comms_ReadOnly.Count() > 0))
								{
									flag19 = true;
									result = true;
								}
								nullable_4 = num29;
								nullable_9 = (nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() < 5f) : null);
								if (nullable_9.GetValueOrDefault(true) && !flag19 && nullable_9.HasValue)
								{
									result = false;
								}
								goto IL_3aaa;
								IL_3aaa:
								_ServiceWrapper.Add(mountWeapon2);
								if (!bool_1)
								{
									WeaponSalvoWpnQty value4 = new WeaponSalvoWpnQty(num32, num30);
									m_MethodWrapper.Add(mountWeapon2.int_0, value4);
									continue;
								}
								break;
							}
							if (bool_1 && _ServiceWrapper.Count > 0)
							{
								break;
							}
						}
					}
					goto end_IL_0691;
					IL_107c:
					if (weaponRec == null)
					{
						_ServiceWrapper.Add(weaponRec3);
					}
					else
					{
						_ServiceWrapper.Add(weaponRec);
					}
					if (!bool_1)
					{
						WeaponSalvoWpnQty value2 = new WeaponSalvoWpnQty(num32, num30);
						if (weaponRec == null)
						{
							m_MethodWrapper.Add(weaponRec3.int_0, value2);
						}
						else
						{
							m_MethodWrapper.Add(weaponRec.int_0, value2);
						}
					}
					goto IL_1282;
					end_IL_0691:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101238", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!bool_1 && myUnit.IsAircraft && nullable_0.HasValue)
					{
						byte? b5 = (byte?)nullable_0;
						if ((b5.HasValue ? new bool?(b5.GetValueOrDefault() == 1) : null).GetValueOrDefault() && _ServiceWrapper.Count > 1 && contact_0.IsSurfaceContact && (from theW in PrepareConsumer(contact_0, ref nullable_0)
							select (theW) into theW
							where theW.Type != Weapon._WeaponType.Gun
							select theW).Count() > 0)
						{
							foreach (WeaponRec item6 in new List<WeaponRec>(_ServiceWrapper))
							{
								if (item6.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
								{
									_ServiceWrapper.Remove(item6);
								}
							}
						}
					}
					Weapon weapon_6 = null;
					int? nullable_5 = null;
					if (_ServiceWrapper.Count > 0)
					{
						if (bool_1)
						{
							weaponRec2 = _ServiceWrapper[0];
							weapon_6 = weaponRec2.GetReferenceWeapon(myUnit.ParentScen);
						}
						else
						{
							weaponRec2 = ((_ServiceWrapper.Count <= 1) ? _ServiceWrapper[0] : _ServiceWrapper.Select((WeaponRec theRec) => theRec).OrderByDescending(delegate(WeaponRec theRec)
							{
								Weapon weapon_17 = theRec.GetReferenceWeapon(myUnit.ParentScen);
								return WeaponSuitabilityForThisTarget(ref weapon_17, ref contact_0, bool_1: false);
							}).ThenBy((WeaponRec theRec0) => theRec0.GetReferenceWeapon(myUnit.ParentScen).GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, myUnit.Doctrine, bool_1: false))
								.ElementAtOrDefault(0));
							weapon_6 = weaponRec2.GetReferenceWeapon(myUnit.ParentScen);
							int? nullable_7;
							if (!nullable_5.HasValue)
							{
								Doctrine._WRA_WeaponTargetType num19 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_6, ref contact_0, ref _WRA_WeaponTargetType_, myUnit.GetUnitSide().ObjectID);
								Doctrine doctrine8 = myUnit.Doctrine;
								Scenario parentScen2 = myUnit.ParentScen;
								Weapon weapon_7 = weapon_6;
								Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_2 = num19;
								int? nullable_6 = null;
								nullable_7 = null;
								nullable_5 = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine8, parentScen2, weapon_7, wRA_WeaponTargetType_2, bool_0: false, ref nullable_6, ref nullable_7);
							}
							nullable_7 = nullable_5;
							if ((nullable_7.HasValue ? new bool?(nullable_7.GetValueOrDefault() == -99) : null).GetValueOrDefault())
							{
								nullable_5 = int.MaxValue;
							}
						}
					}
					if (weaponRec2 != null)
					{
						int? num20;
						int? nullable_8;
						if (bool_1)
						{
							num20 = int_1;
							nullable_8 = int_1;
						}
						else
						{
							num20 = m_MethodWrapper[weaponRec2.int_0].WeaponQty_ToFire;
							nullable_8 = m_MethodWrapper[weaponRec2.int_0].WeaponQty_Available;
							int? num21 = num20;
							nullable_9 = (num21.HasValue ? new bool?(num21.GetValueOrDefault() < 0) : null);
							if (nullable_9.GetValueOrDefault(true))
							{
								num21 = num20;
								bool? flag15 = (num21.HasValue ? new bool?(num21.GetValueOrDefault() == -99) : null);
								if (((!flag15) ?? flag15).GetValueOrDefault() && nullable_9.HasValue)
								{
									num20 = myUnit.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(num20, ref myUnit, ref contact_0, ref weapon_6);
								}
							}
							num21 = num20;
							if ((num21.HasValue ? new bool?(num21.GetValueOrDefault() < 1) : null).GetValueOrDefault())
							{
								num20 = 1;
							}
							nullable_9 = ((nullable_8.HasValue & num20.HasValue) ? new bool?(nullable_8.GetValueOrDefault() > num20.GetValueOrDefault()) : null);
							if (nullable_9.GetValueOrDefault(true))
							{
								num21 = num20;
								bool? flag16 = (num21.HasValue ? new bool?(num21.GetValueOrDefault() == -99) : null);
								if (((!flag16) ?? flag16).GetValueOrDefault() && nullable_9.HasValue)
								{
									nullable_8 = num20;
								}
							}
						}
						if (bool_4 && !weapon_6.IsPalletWeapon && myUnit.IsAircraft)
						{
							WeaponRec[] weapons4 = ((Aircraft)myUnit).Loadout.Weapons;
							WeaponRec[] array = weapons4;
							foreach (WeaponRec weaponRec4 in array)
							{
								if (!weaponRec4.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
								{
									continue;
								}
								if (weaponRec4.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
								{
									weaponRec4.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
								}
								foreach (WeaponSalvo weaponSalvo in myUnit.GetUnitSide().GetWeaponSalvos())
								{
									if (!((weaponSalvo.ShootersList.Where((WeaponSalvo.Shooter theSh) => Operators.CompareString(theSh.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0).Count() > 0) & (weaponSalvo.int_0 == weaponRec2.int_0)))
									{
										continue;
									}
									foreach (WeaponRec weaponWeapon4 in weaponRec4.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
									{
										int? num22 = weaponSalvo.WpnQuantityAssigned + num20;
										int currentLoad = weaponWeapon4.CurrentLoad;
										if (!(num22.HasValue ? new bool?(num22.GetValueOrDefault() > currentLoad) : null).GetValueOrDefault())
										{
											continue;
										}
										foreach (WeaponSalvo weaponSalvo2 in myUnit.GetUnitSide().GetWeaponSalvos())
										{
											if (!((weaponSalvo2.ShootersList.Where((WeaponSalvo.Shooter theSh) => Operators.CompareString(theSh.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0).Count() > 0) & (weaponSalvo2.int_0 == weaponRec4.GetReferenceWeapon(myUnit.ParentScen).DBID)))
											{
												continue;
											}
											WeaponSalvo.Shooter[] shootersList = weaponSalvo2.ShootersList;
											WeaponSalvo.Shooter[] array2 = shootersList;
											foreach (WeaponSalvo.Shooter shooter3 in array2)
											{
												if (Operators.CompareString(shooter3.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
												{
													weaponSalvo_ = null;
													if (weaponRec4.MaxLoad >= shooter3.QuantityAssigned)
													{
														break;
													}
													shooter3.QuantityAssigned++;
												}
											}
										}
									}
								}
							}
						}
						if (GameGeneral.helperClient && !bool_1)
						{
							if (weaponRec2.CurrentLoad == 0)
							{
								return false;
							}
							DateTime dateTime_ = ReadConsumer(contact_0, weapon_6);
							myUnit.GetUnitSide().AddFiringProposal(myUnit, weapon_6, num20.Value, nullable_8.Value, contact_0, dateTime_);
							if (weaponRec2.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
							{
								if (weaponRec2.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
								{
									weaponRec2.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
								}
								using List<WeaponRec>.Enumerator enumerator10 = weaponRec2.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.GetEnumerator();
								if (enumerator10.MoveNext())
								{
									WeaponRec current20 = enumerator10.Current;
									if (bool_2)
									{
										Weapon referenceWeapon2 = current20.GetReferenceWeapon(myUnit.ParentScen);
										myUnit.GetUnitSide().AddFiringProposal(myUnit, referenceWeapon2, num20.Value, current20.MaxLoad, contact_0, DateTime.MaxValue);
										return true;
									}
									myUnit.GetUnitSide().AddFiringProposal(myUnit, weapon_6, num20.Value * current20.CurrentLoad, nullable_8.Value, contact_0, DateTime.MaxValue);
									return true;
								}
							}
							return true;
						}
						if (weaponSalvo_ != null)
						{
							int value5 = num20.Value;
							int wpnQuantityAssigned = weaponSalvo_.WpnQuantityAssigned;
							if ((bool_1 | (num20.HasValue ? new bool?(wpnQuantityAssigned < num20.GetValueOrDefault()) : null)).GetValueOrDefault())
							{
								myUnit.GetUnitSide().AddShooterToExistingSalvo(ref weaponSalvo_, value5, 0, nullable_8, bool_1, ref myUnit.ObjectID);
								if (weaponRec2.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
								{
									if (weaponRec2.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
									{
										weaponRec2.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
									}
									foreach (WeaponRec weaponWeapon5 in weaponRec2.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
									{
										CreateSalvo(contact_0, weaponWeapon5.GetReferenceWeapon(myUnit.ParentScen).DBID, num20.Value * weaponWeapon5.CurrentLoad, bool_1, ref nullable_0, DateTime.MaxValue);
									}
								}
							}
							return result;
						}
						Side unitSide = myUnit.GetUnitSide();
						Scenario parentScen3 = myUnit.ParentScen;
						Weapon weapon_8 = weaponRec2.GetReferenceWeapon(myUnit.ParentScen);
						unitSide.AssignSalvoToTarget(parentScen3, ref weapon_8, ref contact_0, num20, 0, nullable_8, bool_1, ref myUnit.ObjectID, ref nullable_5, theScheduledTime, DateTime.MinValue);
						if (weaponRec2.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
						{
							if (weaponRec2.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
							{
								weaponRec2.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
							}
							WeaponSalvo theAC = null;
							foreach (WeaponRec weaponWeapon6 in weaponRec2.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
							{
								if (bool_2)
								{
									CreateSalvo(contact_0, weaponWeapon6.GetReferenceWeapon(myUnit.ParentScen).DBID, num20.Value, bool_1, ref nullable_0, DateTime.MaxValue);
								}
								else if (!bool_5)
								{
									CreateSalvo(contact_0, weaponWeapon6.GetReferenceWeapon(myUnit.ParentScen).DBID, num20.Value * weaponWeapon6.CurrentLoad, bool_1, ref nullable_0, DateTime.MaxValue, bool_2: false, bool_3: false, bool_4: false);
								}
								int num24 = 0;
								int num25 = 0;
								int num26 = 0;
								int num27 = 0;
								foreach (WeaponSalvo item7 in myUnit.GetUnitSide().WeaponSalvos.OrderBy((WeaponSalvo theS) => !theS.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon))
								{
									if (item7.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
									{
										if (item7.WpnQuantityFired == 0)
										{
											item7.ShootersList.Where((WeaponSalvo.Shooter theSh) => Operators.CompareString(theSh.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0);
											num24 += item7.WpnQuantityAssigned;
											item7.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
											num26 = item7.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons[0].MaxLoad;
											num27 = item7.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons[0].int_0;
										}
									}
									else if (item7.int_0 == num27)
									{
										num25 += item7.WpnQuantityAssigned;
									}
								}
								for (; (num24 > 1) & ((double)num26 / (double)num24 > (double)num25 / (double)num24); num24--)
								{
									foreach (WeaponSalvo item8 in myUnit.GetUnitSide().WeaponSalvos.OrderBy((WeaponSalvo theS) => !theS.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon))
									{
										if (item8.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon && item8.WpnQuantityFired == 0)
										{
											item8.ShootersList.Where((WeaponSalvo.Shooter theSh) => Operators.CompareString(theSh.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0);
											theAC = item8;
											break;
										}
									}
									ArrayExtensions.Remove(ref myUnit.GetUnitSide().WeaponSalvos, theAC);
								}
							}
						}
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 101239", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				return false;
			}
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Decoy_Sub:
				return false;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100299", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool CompareConsumer(Contact contact_0)
	{
		if (m_MappingWrapper)
		{
			return true;
		}
		bool result = false;
		if (m_MockWrapper && contact_0.ActualUnit != null && !contact_0.ActualUnit.IsAircraft && myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
		{
			if (((Strike)myUnit.AssignedMissionOrPackage()).SpecificTargets.Contains(contact_0))
			{
				result = true;
			}
			else if (myUnit.AI.PrimaryTarget != null && Operators.CompareString(myUnit.AI.PrimaryTarget.ObjectID, contact_0.ObjectID, TextCompare: false) == 0)
			{
				result = true;
			}
		}
		return result;
	}

	internal DateTime ReadConsumer(Contact contact_0, Weapon weapon_0)
	{
		DateTime dateTime;
		if (ETA_ResultsCache != null && ETA_ResultsCache.Count > 0 && myUnit != null)
		{
			KeyValuePair<Tuple<ActiveUnit, int, ScenarioObject>, double> keyValuePair = ETA_ResultsCache.Where((KeyValuePair<Tuple<ActiveUnit, int, ScenarioObject>, double> theRes) => (Operators.CompareString(theRes.Key.Item1.ObjectID, myUnit.ObjectID, TextCompare: false) == 0) & (theRes.Key.Item2 == weapon_0.DBID) & (Operators.CompareString(theRes.Key.Item3.ObjectID, contact_0.ObjectID, TextCompare: false) == 0)).FirstOrDefault();
			if (keyValuePair.Value == 0.0)
			{
				dateTime = DisableConsumer(contact_0, weapon_0);
			}
			else
			{
				dateTime = myUnit.ParentScen.Time;
				dateTime.AddSeconds(keyValuePair.Value);
			}
		}
		else
		{
			dateTime = DisableConsumer(contact_0, weapon_0);
		}
		if (DateTime.Compare(dateTime, DateTime.MinValue) == 0 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return dateTime;
	}

	internal DateTime DisableConsumer(Contact contact_0, Weapon weapon_0)
	{
		double num = 0.0;
		double value = 0.0;
		DateTime result = default(DateTime);
		if (weapon_0.SupportsWaypoints & !weapon_0.IsBallisticMissile)
		{
			weapon_0.FiringParent = myUnit;
			weapon_0.SetUnitSide(bool_0: false, myUnit.GetUnitSide());
			weapon_0.AI.PrimaryTarget = contact_0;
			Weapon_Navigator navigator = weapon_0.Navigator;
			Waypoint[] gparam_ = navigator.PlottedCourse;
			ArrayExtensions.Clear(ref gparam_);
			navigator.PlottedCourse = gparam_;
			weapon_0.AI.PrimaryTarget = contact_0;
			value = weapon_0.Navigator.FindDescriptor(myUnit).ETA;
			if (value == 0.0 && Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = myUnit.ParentScen.Time.AddSeconds(value);
			ETA_ResultsCache.TryAdd(new Tuple<ActiveUnit, int, ScenarioObject>(weapon_0.FiringParent, weapon_0.DBID, contact_0), value);
			return result;
		}
		if (weapon_0.IsUnguidedBallisticWeapon)
		{
			num = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, weapon_0.MaxRange_NoTargetType, bool_0: true);
			if (num != 0.0)
			{
				result = myUnit.ParentScen.Time;
				value = (double)Module_Unit.RangeToUnit_Slant(myUnit, contact_0) * 1852.0 / num;
				result = result.AddSeconds(value);
			}
		}
		else if (!weapon_0.IsHGV && !weapon_0.InterruptReponse())
		{
			if (weapon_0.IsBallisticMissile)
			{
				BallisticTrajectory ballisticTrajectory = BallisticTrajectory.Factory(myUnit, contact_0, Math.Max(weapon_0.MaxSurfaceRange, weapon_0.MaxLandRange), bool_0: true, 60.0);
				bool flag = false;
				if (ballisticTrajectory.CurrentRecord.Radius_km <= (double)(contact_0.GetCurrentAltitude() / 1000f) + 6371.0)
				{
					flag = true;
				}
				while (flag | ((ballisticTrajectory.CurrentRecord.Radius_km > (double)(contact_0.GetCurrentAltitude() / 1000f) + 6371.0) & (ballisticTrajectory.CurrentRecord.Phase != 2)))
				{
					ballisticTrajectory.CurrentRecord = ballisticTrajectory.NextRecord;
					ballisticTrajectory.NextRecord = BallisticTrajectory.ComputeNextRecord(ballisticTrajectory, ballisticTrajectory.CurrentRecord, 1.0);
					if (ballisticTrajectory.CurrentRecord.Radius_km > (double)(contact_0.GetCurrentAltitude() / 1000f) + 6371.0)
					{
						flag = false;
					}
				}
				result = myUnit.ParentScen.Time;
				value = ballisticTrajectory.NextRecord.Time_s;
				result = result.AddSeconds(value);
			}
			else if (weapon_0.IsGuidedWeapon())
			{
				result = myUnit.ParentScen.Time;
				float num2 = UpdateConsumer(weapon_0, contact_0, bool_1: false);
				result = result.AddSeconds(num2);
			}
			else if (weapon_0.IsContactExplosive)
			{
				num = myUnit.MaxSpeed;
				if (num == 0.0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					result = myUnit.ParentScen.Time;
					value = (double)Module_Unit.RangeToUnit_Slant(myUnit, contact_0) * 1852.0 / num;
					result = result.AddSeconds(value);
				}
			}
			else if (!weapon_0.IsLaserShot && weapon_0.Type != Weapon._WeaponType.Microwave)
			{
				if (weapon_0.Type == Weapon._WeaponType.Dispenser)
				{
					value = 0.0;
					result = myUnit.ParentScen.Time;
				}
				else
				{
					num = weapon_0.MaxSpeed;
					if (num == 0.0 && weapon_0.IsGuidedProjectile)
					{
						num = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, weapon_0.MaxRange_NoTargetType, bool_0: true);
					}
					if (num == 0.0)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						result = myUnit.ParentScen.Time;
						value = (double)Module_Unit.RangeToUnit_Slant(myUnit, contact_0) * 1852.0 / num;
						result = result.AddSeconds(value);
					}
				}
			}
			else
			{
				result = myUnit.ParentScen.Time.AddSeconds(2.0);
			}
		}
		else
		{
			value = method_0(contact_0, weapon_0, bool_1: false).Item2;
			result = myUnit.ParentScen.Time.AddSeconds(value);
		}
		ETA_ResultsCache.TryAdd(new Tuple<ActiveUnit, int, ScenarioObject>(myUnit, weapon_0.DBID, contact_0), value);
		return result;
	}

	internal float UpdateConsumer(Weapon weapon_0, Contact contact_0, bool bool_1)
	{
		if (bool_1)
		{
			return 0f;
		}
		return method_0(contact_0, weapon_0, bool_1: false).Item2;
	}

	internal int InsertConsumer(ref Contact contact_0)
	{
		if (contact_0.ActualUnit != null)
		{
			if (contact_0.ActualUnit.IsShip)
			{
				return Math.Max((int)((Ship)contact_0.ActualUnit).MissileDefense, 1);
			}
			if (contact_0.ActualUnit.IsFacility)
			{
				return Math.Max(((Facility)contact_0.ActualUnit).MissileDefense, 1);
			}
			if (contact_0.ActualUnit.IsVehicle)
			{
				return Math.Max(((Vehicle)contact_0.ActualUnit).MissileDefense, 1);
			}
		}
		return 0;
	}

	internal List<Weapon> PrepareConsumer(Contact contact_0, ref Doctrine._GunStrafeGroundTargets? nullable_0)
	{
		List<Weapon> result = null;
		try
		{
			List<Weapon> list = AllDistinctWeaponsAboard_Actual();
			List<Weapon> list2 = new List<Weapon>();
			bool? nullable_ = null;
			foreach (Weapon item in list)
			{
				if (!item.QueryReponse(myUnit, ref contact_0, ref nullable_))
				{
					continue;
				}
				if (myUnit.IsAircraft && item.Type == Weapon._WeaponType.Gun && contact_0.IsSurfaceContact)
				{
					if (!nullable_0.HasValue)
					{
						nullable_0 = myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
					}
					byte? b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						list2.Add(item);
					}
				}
				else
				{
					list2.Add(item);
				}
			}
			result = list2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100300", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public int WeaponSuitabilityForThisTarget(ref Weapon weapon_0, ref Contact contact_0, bool bool_1)
	{
		if (weapon_0 == null)
		{
			return 0;
		}
		int result = 0;
		try
		{
			Weapon obj = weapon_0;
			ActiveUnit activeUnit_ = myUnit;
			bool? nullable_ = null;
			if (obj.QueryReponse(activeUnit_, ref contact_0, ref nullable_))
			{
				if (weapon_0.IsNuke.Value)
				{
					byte? b = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
					nullable_ = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
					if (((!nullable_) ?? nullable_).GetValueOrDefault())
					{
						result = 0;
						return 0;
					}
				}
				if (bool_1)
				{
					float float_ = ((weapon_0.Type == Weapon._WeaponType.Gun) ? Module_Unit.RangeToUnit_Slant(myUnit, contact_0) : Module_Unit.RangeToUnit_Horiz(myUnit, contact_0));
					if (!weapon_0.ResetReponse(float_, contact_0))
					{
						result = 0;
						return 0;
					}
					if (weapon_0.MapReponse(float_, contact_0))
					{
						result = 0;
						return 0;
					}
				}
				int num = 1;
				if (myUnit.IsAircraft && weapon_0.Type == Weapon._WeaponType.Gun)
				{
					num -= 2;
				}
				if (weapon_0.Warheads.Length != 0)
				{
					Warhead warhead = weapon_0.Warheads[0];
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
						if (weapon_0.Type == Weapon._WeaponType.Gun && weapon_0.IsAAW && !weapon_0.IsASuW_Land && !weapon_0.IsASuW_Naval)
						{
							num++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.ContinuousRod:
						case Warhead.WarheadType.Nuclear:
							num++;
							break;
						case Warhead.WarheadType.Fragmentation_ABM:
							num += 2;
							break;
						}
						break;
					case Contact_Base.ContactType.Missile:
						if (weapon_0.Type == Weapon._WeaponType.Gun && weapon_0.IsAAW && !weapon_0.IsASuW_Land && !weapon_0.IsASuW_Naval)
						{
							num++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.Fragmentation_ABM:
							num += 2;
							break;
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.ContinuousRod:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Laser_COIL:
						case Warhead.WarheadType.Laser_CarbonDioxide:
						case Warhead.WarheadType.Laser_DeuteriumFluoride:
						case Warhead.WarheadType.Laser_SolidStateFiber:
						case Warhead.WarheadType.Kinetic:
							num++;
							break;
						}
						break;
					case Contact_Base.ContactType.Surface:
						if (weapon_0.IsASuW_Naval && !weapon_0.IsAAW)
						{
							num++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.HEAT:
						case Warhead.WarheadType.SemiAP:
						case Warhead.WarheadType.HESH:
						case Warhead.WarheadType.HardTargetPenetrator:
						case Warhead.WarheadType.Nuclear:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Kinetic:
							num++;
							break;
						}
						break;
					case Contact_Base.ContactType.Submarine:
					{
						Warhead.WarheadType type = warhead.Type;
						if (type == Warhead.WarheadType.HEAT || type == Warhead.WarheadType.HESH || (uint)(type - 3001) <= 1u)
						{
							num++;
						}
						break;
					}
					case Contact_Base.ContactType.Facility_Fixed:
						if (weapon_0.IsASuW_Land && !weapon_0.IsAAW)
						{
							num += 2;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.HEAT:
						case Warhead.WarheadType.Incendiary:
						case Warhead.WarheadType.SemiAP:
						case Warhead.WarheadType.HESH:
						case Warhead.WarheadType.HardTargetPenetrator:
						case Warhead.WarheadType.Nuclear:
						case Warhead.WarheadType.Cluster_Penetrator:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Kinetic:
							num++;
							break;
						}
						if (!Information.IsNothing(contact_0.ActualUnit) && Module_ActiveUnit.CancelTokenizer(contact_0.ActualUnit) && warhead.IsAreaEffect)
						{
							num += 3;
						}
						break;
					case Contact_Base.ContactType.Facility_Mobile:
						if (weapon_0.IsASuW_Land && !weapon_0.IsAAW)
						{
							num++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.HEAT:
						case Warhead.WarheadType.Incendiary:
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.HESH:
						case Warhead.WarheadType.SuperFrag:
						case Warhead.WarheadType.Nuclear:
						case Warhead.WarheadType.Cluster_AP:
						case Warhead.WarheadType.Cluster_AT:
						case Warhead.WarheadType.Cluster_SmartSubs:
						case Warhead.WarheadType.Landmine_AP:
						case Warhead.WarheadType.Landmine_AT:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Kinetic:
							num++;
							break;
						}
						if (!Information.IsNothing(contact_0.ActualUnit) && Module_ActiveUnit.CancelTokenizer(contact_0.ActualUnit) && warhead.IsAreaEffect)
						{
							num += 3;
						}
						break;
					}
					if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
					{
						GlobalVariables.ArmorRating armorRating = (GlobalVariables.ArmorRating)0;
						switch (contact_0.Type)
						{
						case Contact_Base.ContactType.Surface:
						{
							ActiveUnit actualUnit = contact_0.ActualUnit;
							if (actualUnit.IsShip)
							{
								armorRating = ((Ship)actualUnit).Armor_Belt;
							}
							else if (actualUnit.IsSubmarine)
							{
								armorRating = GlobalVariables.ArmorRating.Light;
							}
							else if (actualUnit.IsFacility)
							{
								armorRating = ((Facility)actualUnit).Armor_General;
							}
							break;
						}
						case Contact_Base.ContactType.Submarine:
							armorRating = (((Submarine)contact_0.ActualUnit).Flags.DoubleHull ? GlobalVariables.ArmorRating.Medium : GlobalVariables.ArmorRating.Light);
							break;
						default:
							armorRating = GlobalVariables.ArmorRating.Light;
							break;
						case Contact_Base.ContactType.Facility_Fixed:
							armorRating = ((!Module_ActiveUnit.CancelTokenizer(contact_0.ActualUnit)) ? ((Facility)contact_0.ActualUnit).Armor_General : ((contact_0.ActualUnit.Mounts.Count <= 0) ? ((Facility)contact_0.ActualUnit).Armor_General : contact_0.ActualUnit.Mounts[0].ArmorRating));
							break;
						case Contact_Base.ContactType.Facility_Mobile:
							armorRating = (contact_0.ActualUnit.IsMobileGroundUnit ? ((IMobileGroundUnit)contact_0.ActualUnit).Armor_General : ((!Module_ActiveUnit.CancelTokenizer((Facility)contact_0.ActualUnit)) ? ((Facility)contact_0.ActualUnit).Armor_General : ((contact_0.ActualUnit.Mounts.Count <= 0) ? ((Facility)contact_0.ActualUnit).Armor_General : contact_0.ActualUnit.Mounts[0].ArmorRating)));
							break;
						case Contact_Base.ContactType.Air:
						case Contact_Base.ContactType.Missile:
						case Contact_Base.ContactType.Orbital:
						case Contact_Base.ContactType.Torpedo:
						case Contact_Base.ContactType.Mine:
							armorRating = GlobalVariables.ArmorRating.None;
							break;
						}
						switch (armorRating)
						{
						case GlobalVariables.ArmorRating.Light:
							if (warhead.Type == Warhead.WarheadType.SuperFrag)
							{
								num++;
							}
							break;
						default:
							switch (warhead.Type)
							{
							case Warhead.WarheadType.ArmorPiercing:
							case Warhead.WarheadType.HEAT:
							case Warhead.WarheadType.SemiAP:
							case Warhead.WarheadType.HESH:
							case Warhead.WarheadType.HardTargetPenetrator:
							case Warhead.WarheadType.Cluster_AT:
							case Warhead.WarheadType.Cluster_Penetrator:
							case Warhead.WarheadType.Cluster_SmartSubs:
							case Warhead.WarheadType.Landmine_AT:
							case Warhead.WarheadType.LongRodPenetrator:
							case Warhead.WarheadType.Kinetic:
								num++;
								break;
							}
							if (weapon_0.Type == Weapon._WeaponType.Gun)
							{
								num = ((warhead.Caliber <= Warhead.WarheadCaliber.Gun_61_80mm) ? (num - 1) : (num + 1));
							}
							break;
						case GlobalVariables.ArmorRating.None:
							switch (warhead.Type)
							{
							case Warhead.WarheadType.HE_BlastFrag:
							case Warhead.WarheadType.Incendiary:
							case Warhead.WarheadType.Fragmentation:
							case Warhead.WarheadType.ContinuousRod:
							case Warhead.WarheadType.Fragmentation_ABM:
							case Warhead.WarheadType.DepthCharge:
							case Warhead.WarheadType.Nuclear:
							case Warhead.WarheadType.Cluster_AP:
							case Warhead.WarheadType.Landmine_AP:
								num++;
								break;
							}
							if (weapon_0.Type == Weapon._WeaponType.Gun)
							{
								num = ((warhead.Caliber <= Warhead.WarheadCaliber.Gun_61_80mm) ? (num + 1) : (num - 1));
							}
							break;
						}
					}
				}
				result = num;
				return result;
			}
			result = 0;
			return 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100301", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Weapon LongestRangedSuitableWeaponForThisTarget(Contact contact_0)
	{
		Weapon result = null;
		try
		{
			Contact contact_ = contact_0;
			Doctrine._GunStrafeGroundTargets? nullable_ = null;
			List<Weapon> list = PrepareConsumer(contact_, ref nullable_);
			if (list.Count == 0)
			{
				result = null;
				return result;
			}
			switch (list.Count)
			{
			default:
				result = list.OrderByDescending((Weapon theW) => theW.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, myUnit.Doctrine, bool_1: false)).ElementAtOrDefault(0);
				return result;
			case 1:
				result = list[0];
				return result;
			case 0:
				result = null;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100302", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Weapon MostSuitableWeaponForThisTarget(Contact contact_0, bool bool_1, bool bool_2, bool bool_3, Doctrine doctrine_0, bool bool_4 = false, bool bool_5 = false)
	{
		try
		{
			if (myUnit.IsWeapon)
			{
				return null;
			}
			Doctrine._GunStrafeGroundTargets? nullable_ = doctrine_0.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			List<Weapon> list = PrepareConsumer(contact_0, ref nullable_);
			if (list != null && list.Count != 0)
			{
				float num = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
				List<Weapon> list2 = new List<Weapon>();
				List<Weapon> list3 = new List<Weapon>();
				if (doctrine_0 != null && contact_0.IsSurfaceContact)
				{
					byte? b = (byte?)doctrine_0.GetUseSAMsOnASuW(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						foreach (Weapon item in list)
						{
							if (item.ValidTargets.Aircraft)
							{
								list3.Add(item);
							}
						}
						foreach (Weapon item2 in list3)
						{
							list.Remove(item2);
						}
					}
				}
				if (bool_3 && bool_1)
				{
					if (bool_2 && contact_0.AltitudeIsKnown)
					{
						foreach (Weapon item3 in list)
						{
							if (item3.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, doctrine_0, bool_1: false) >= num && string.CompareOrdinal(ReflectConsumer(item3, contact_0), "OK") == 0)
							{
								short? nullable_2 = null;
								if (string.CompareOrdinal(VisitConsumer(item3, contact_0, ref nullable_2), "OK") == 0)
								{
									list2.Add(item3);
								}
							}
						}
					}
					else
					{
						foreach (Weapon item4 in list)
						{
							if (item4.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, doctrine_0, bool_1: false) >= num)
							{
								list2.Add(item4);
							}
						}
					}
				}
				else if (bool_3 && !bool_1)
				{
					if (bool_2 && contact_0.AltitudeIsKnown)
					{
						foreach (Weapon item5 in list)
						{
							if (item5.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, doctrine_0, bool_1: false) > 0f && string.CompareOrdinal(ReflectConsumer(item5, contact_0), "OK") == 0)
							{
								Contact contact_ = contact_0;
								short? nullable_3 = null;
								if (string.CompareOrdinal(VisitConsumer(item5, contact_, ref nullable_3), "OK") == 0)
								{
									list2.Add(item5);
								}
							}
						}
					}
					else
					{
						foreach (Weapon item6 in list)
						{
							if (item6.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: true, doctrine_0, bool_1: false) > 0f)
							{
								list2.Add(item6);
							}
						}
					}
				}
				else if (!bool_3 && bool_1)
				{
					if (bool_2 && contact_0.AltitudeIsKnown)
					{
						foreach (Weapon item7 in list)
						{
							if (item7.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, doctrine_0, bool_1: false) >= num && string.CompareOrdinal(ReflectConsumer(item7, contact_0), "OK") == 0)
							{
								Contact contact_2 = contact_0;
								short? nullable_4 = null;
								if (string.CompareOrdinal(VisitConsumer(item7, contact_2, ref nullable_4), "OK") == 0)
								{
									list2.Add(item7);
								}
							}
						}
					}
					else
					{
						foreach (Weapon item8 in list)
						{
							if (item8.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, doctrine_0, bool_1: false) >= num)
							{
								list2.Add(item8);
							}
						}
					}
				}
				else
				{
					list2 = list;
				}
				if (bool_4)
				{
					list2.RemoveAll((Weapon toBeRem) => toBeRem?.IsChaff_CM_SG ?? false);
				}
				if (bool_5 && list2.Count > 0)
				{
					for (int i = list2.Count - 1; i >= 0; i += -1)
					{
						if (HowManyOfThisWeapon(list2[i].DBID) == 0)
						{
							list2.RemoveAt(i);
						}
					}
				}
				int count = list2.Count;
				if (1 == 0)
				{
				}
				Weapon result = count switch
				{
					1 => list2[0], 
					0 => null, 
					_ => list2.Where((Weapon theW) => theW != null).OrderByDescending(delegate(Weapon theW)
					{
						Weapon weapon_ = theW;
						return WeaponSuitabilityForThisTarget(ref weapon_, ref contact_0, bool_1);
					}).ThenByDescending((Weapon theW0) => theW0.DP_Total)
						.ElementAtOrDefault(0), 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100303", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public virtual void ReduceTimesToFire(float float_0)
	{
		int count = myUnit.Mounts.Count;
		try
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					Mount mount = myUnit.Mounts[i];
					if (mount.Status != 0)
					{
						continue;
					}
					float num2 = 0f;
					if (mount.TimeToFire > 0f)
					{
						mount.TimeToFire = Math.Max(0f, mount.TimeToFire - float_0);
						num2 = mount.TimeToFire;
					}
					if (mount.MountMagazine.TimeToFire > 0f && mount.MountMagazine.TimeToFire > num2)
					{
						num2 = mount.MountMagazine.TimeToFire;
					}
					int num3 = mount.MountWeapons.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						try
						{
							WeaponRec weaponRec = mount.MountWeapons[j];
							if (weaponRec.TimeToFire > 0f)
							{
								weaponRec.TimeToFire -= float_0;
								if (weaponRec.TimeToFire < 0f)
								{
									weaponRec.TimeToFire = 0f;
								}
								if (weaponRec.TimeToFire > num2)
								{
									num2 = weaponRec.TimeToFire;
								}
							}
							weaponRec = null;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 200437", exception_.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (mount.MountMagazine.TimeToFire > 0f)
					{
						mount.MountMagazine.TimeToFire = Math.Max(0f, mount.MountMagazine.TimeToFire - float_0);
					}
					int num4 = mount.MountMagazine.Weapons.Count - 1;
					for (int k = 0; k <= num4; k++)
					{
						try
						{
							WeaponRec weaponRec2 = mount.MountMagazine.Weapons[k];
							if (weaponRec2.TimeToFire > 0f)
							{
								weaponRec2.TimeToFire -= float_0;
								if (weaponRec2.TimeToFire < 0f)
								{
									weaponRec2.TimeToFire = 0f;
								}
								if (weaponRec2.TimeToFire > num2)
								{
									num2 = weaponRec2.TimeToFire;
								}
							}
							weaponRec2 = null;
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 200438", exception_2.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (num2 <= 0f)
					{
						mount.ReloadStatus = Mount._ReloadStatus.Ready;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 200439", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!myUnit.IsPlatform)
			{
				return;
			}
			Magazine[] magazines = ((Platform)myUnit).Magazines;
			Magazine[] array = magazines;
			foreach (Magazine magazine in array)
			{
				int num5 = magazine.Weapons.Count - 1;
				for (int l = 0; l <= num5; l++)
				{
					try
					{
						WeaponRec weaponRec3 = magazine.Weapons[l];
						if (weaponRec3.TimeToFire > 0f)
						{
							weaponRec3.TimeToFire -= float_0;
							if (weaponRec3.TimeToFire < 0f)
							{
								weaponRec3.TimeToFire = 0f;
							}
						}
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at 200440", exception_4.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at 100304", "");
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HaveSuitableWeaponForAmbigousTarget(Contact contact_0, bool bool_1)
	{
		bool result = false;
		try
		{
			if (contact_0.ActualUnit.IsShip || contact_0.ActualUnit.IsFacility || contact_0.ActualUnit.IsSubmarine)
			{
				List<Weapon> list = AllDistinctWeaponsAboard_Actual();
				if (list.Count > 0)
				{
					bool? nullable_ = null;
					foreach (Weapon item in list)
					{
						if (!item.QueryReponse(myUnit, ref contact_0, ref nullable_) || string.CompareOrdinal(IsWeaponSuitableForTargetAmbiguity(item, contact_0), "OK") != 0)
						{
							continue;
						}
						if (bool_1)
						{
							Contact contact_ = contact_0;
							short? nullable_2 = null;
							Sensor sensor_ = null;
							if (CanThisWeaponEngageThisTarget(item, contact_, ref nullable_2, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_).EvaluationEnum != 0)
							{
								continue;
							}
						}
						result = true;
						return true;
					}
				}
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100305", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public string IsWeaponSuitableForTargetAmbiguity(Weapon weapon_0, Contact contact_0)
	{
		try
		{
			byte? b;
			if (weapon_0.IsNuke.Value)
			{
				b = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() != 1) : null).GetValueOrDefault())
				{
					return "核武器未经授权";
				}
			}
			Doctrine._BehaviorTowardsTargetAmbiguity? behaviorTowardsAmbigousTarget = myUnit.Doctrine.GetBehaviorTowardsAmbigousTarget(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)behaviorTowardsAmbigousTarget;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				return "OK";
			}
			b = (byte?)behaviorTowardsAmbigousTarget;
			int num = 0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				num = 3;
			}
			else
			{
				b = (byte?)behaviorTowardsAmbigousTarget;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					num = 1;
				}
			}
			if (weapon_0.IsMobileDecoy)
			{
				return "OK";
			}
			if (contact_0.IsSubmergedContact)
			{
				if (num == 1)
				{
					if (contact_0.Age > 120f)
					{
						return "目标的最后一个已知位置已过时（" + Misc.UpdateRequest((long)Math.Round(contact_0.Age)) + "秒）。（悲观）";
					}
				}
				else if (contact_0.Age > 600f)
				{
					return "目标的最后一个已知位置已过时（" + Misc.UpdateRequest((long)Math.Round(contact_0.Age)) + "秒）。（乐观）";
				}
			}
			float num2 = Module_Contact.StartTokenizer(contact_0, myUnit);
			float num3 = (float)Math.Round(weapon_0.AcceptableDownRangeAmbiguity, 1);
			string text = ((num <= 1) ? (" " + Conversions.ToString(num) + "x ") : " ");
			if (Math.Round(num2, 1) <= Math.Round(num3 * (float)num, 1))
			{
				float num4 = Module_Contact.RunTokenizer(contact_0, myUnit.GetLatitude(), myUnit.GetLongitude());
				float num5 = (float)Math.Round(weapon_0.AcceptableCrossRangeAmbiguity, 1);
				if (Math.Round(num4, 1) <= Math.Round(num5, 1))
				{
					return "OK";
				}
				return "目标的跨范围不明确（" + $"{num4:0.0}" + "海里）大于" + text + "武器的可接受限度（" + $"{num5:0.0}" + "nm)";
			}
			return "目标的下行不明确（" + $"{num2:0.0}" + "海里）大于" + text + "武器的可接受限度（" + $"{num3:0.0}" + "nm)";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100306", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error";
		}
	}

	public float WeaponOuterRangeLimit(ref ActiveUnit activeUnit_0, ref Weapon weapon_0, ref Contact contact_0, bool bool_1)
	{
		if (weapon_0.IsMissile && CancelConsumer(weapon_0, contact_0) && contact_0.CurrentSpeed != 0f)
		{
			if (!contact_0.IsSurfaceContact && !contact_0.IsLandContact)
			{
				if (!contact_0.IsBallisticTarget() && !contact_0.ActualUnit.IsSatellite && (!contact_0.ActualUnit.IsWeapon || !((Weapon)contact_0.ActualUnit).IsHGV))
				{
					if (contact_0.IsAircraftContact)
					{
						return weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false);
					}
					double num = Physics.CompareStub(contact_0.GetCurrentAltitude(), contact_0.CurrentSpeed);
					return (float)((double)weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) * (1.0 + num));
				}
				return weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) * 100f;
			}
			return weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false);
		}
		if (weapon_0.IsTorpedo)
		{
			byte? b = (byte?)myUnit.Doctrine.GetUseKinematicRangeForTorpedoes(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				goto IL_0429;
			}
			if (bool_1)
			{
				b = (byte?)myUnit.Doctrine.GetUseKinematicRangeForTorpedoes(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					goto IL_0429;
				}
			}
		}
		if (weapon_0.Type == Weapon._WeaponType.Gun && contact_0.IsGuidedWeaponContact && contact_0.ActualUnit != null && contact_0.ActualUnit.AI.PrimaryTarget != null && contact_0.ActualUnit.AI.PrimaryTarget.ActualUnit != null && contact_0.ActualUnit.AI.PrimaryTarget.ActualUnit == activeUnit_0)
		{
			if (contact_0.GetCurrentAltitude() < 650f)
			{
				return (float)Math.Min((double)weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) * 1.5, 1.5);
			}
			float num2 = ((contact_0.CurrentSpeed < 1000f) ? 1.5f : 2f);
			float num3 = (float)((double)Math.Abs(myUnit.GetCurrentAltitude() - contact_0.GetCurrentAltitude()) / 1852.0);
			return (float)Math.Sqrt(num2 * num2 + num3 * num3);
		}
		if (weapon_0.Type == Weapon._WeaponType.Aircraft)
		{
			Aircraft aircraft_ = new Aircraft(ref myUnit.ParentScen);
			DBFunctions.GetAircraft(ref myUnit.ParentScen, ref aircraft_, (int)Math.Round(weapon_0.Warheads[0].DP));
			float maximumAltitude = aircraft_.Kinematics.GetMaximumAltitude();
			float num4 = aircraft_.Kinematics.GetMaximumSpeed(maximumAltitude, ActiveUnit.Throttle.Cruise, bool_0: false, bool_1: false);
			float result = (float)((double)aircraft_.GetFuelEndurance(ActiveUnit.Throttle.Cruise, null, num4, maximumAltitude) / 3600.0 * (double)num4);
			aircraft_ = null;
			return result;
		}
		return weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, myUnit.Doctrine, bool_1);
		IL_0429:
		Torpedo torpedo = (Torpedo)weapon_0;
		return Math.Max(torpedo.MaxKinematicRange_Cruise, torpedo.MaxKinematicRange_Full);
	}

	public void PrecacheDLZchecks()
	{
		if (!myUnit.IsGroup && DLZ_ResultsCache != null && (myUnit.GetUnitSide().callbackProxy == null || myUnit.GetUnitSide().callbackProxy.Count == 0) && DLZ_ResultsCache.Skip(0).Count() != 0)
		{
			DLZ_ResultsCache.Clear();
		}
		if (queueWrapper.Count == 0)
		{
			return;
		}
		Parallel.ForEach(queueWrapper, delegate(Tuple<int, string> tuple_0)
		{
			Weapon weapon = null;
			Contact contact = null;
			try
			{
				int item = tuple_0.Item1;
				string Local_TargetObjectID = tuple_0.Item2;
				try
				{
					List<Contact> list = myUnit.AI.Targets_ReadOnly.Where((Contact theC) => Operators.CompareString(theC.ObjectID, Local_TargetObjectID, TextCompare: false) == 0).ToList();
					if (list.Count > 0)
					{
						contact = list[0];
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200441", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
				if (contact != null)
				{
					Doctrine._GunStrafeGroundTargets? nullable_ = myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
					foreach (Weapon current in PrepareConsumer(contact, ref nullable_))
					{
						if (current.DBID == item)
						{
							weapon = current;
						}
					}
					if (weapon != null)
					{
						Tuple<DLZResultEnum, float> value = method_0(contact, weapon, bool_1: false);
						if (DLZ_ResultsCache == null)
						{
							DLZ_ResultsCache = new ConcurrentDictionary<Tuple<int, string>, Tuple<DLZResultEnum, float>>();
						}
						DLZ_ResultsCache.TryAdd(new Tuple<int, string>(item, Local_TargetObjectID), value);
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
		});
		queueWrapper.Clear();
	}

	private string ReflectConsumer(Weapon weapon_0, Contact contact_0)
	{
		try
		{
			if (!contact_0.IsBallisticTarget() && contact_0.Type != Contact_Base.ContactType.Surface && Module_Unit.RateTokenizer(contact_0, myUnit.ParentScen) == 0f)
			{
				if (weapon_0.MaxTargetAlt_AGL > 0f)
				{
					float num = (myUnit.IsFacility ? (myUnit.GetCurrentAltitude() + weapon_0.MaxTargetAlt_AGL) : weapon_0.MaxTargetAlt_AGL);
					if (contact_0.CurrentAltitude_AGL > num && Module_Unit.ResetTokenizer(contact_0))
					{
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL * 3.28084f)) + "英尺 真高）高于武器的天花板（" + Conversions.ToString((int)Math.Round(num * 3.28084f)) + "英尺 真高）";
						}
						return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL)) + "米 真高）高于武器的天花板（" + Conversions.ToString(num) + "米 真高）";
					}
				}
				if (!(weapon_0.MaxTargetAlt_ASL <= 0f) && contact_0.GetCurrentAltitude() > weapon_0.MaxTargetAlt_ASL)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude() * 3.28084f)) + "英尺 海高）高于武器的天花板（" + Conversions.ToString((int)Math.Round(weapon_0.MaxTargetAlt_ASL * 3.28084f)) + "英尺 海高）";
					}
					return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude())) + "米 海高）高于武器的天花板（" + Conversions.ToString(weapon_0.MaxTargetAlt_ASL) + "米 海高）";
				}
				if (weapon_0.MinTargetAlt_AGL > 0f)
				{
					float minTargetAlt_AGL = weapon_0.MinTargetAlt_AGL;
					if (contact_0.CurrentAltitude_AGL < minTargetAlt_AGL && contact_0.Type != Contact_Base.ContactType.ActivationPoint)
					{
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL * 3.28084f)) + "英尺 真高）低于武器的最低接合高度（" + Conversions.ToString((int)Math.Round(minTargetAlt_AGL * 3.28084f)) + "英尺 真高）";
						}
						return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL)) + "米 真高）低于武器的最低接合高度（" + Conversions.ToString(minTargetAlt_AGL) + "米 真高）";
					}
				}
				if (weapon_0.MinTargetAlt_ASL > 0f && contact_0.GetCurrentAltitude() < weapon_0.MinTargetAlt_ASL)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude() * 3.28084f)) + "英尺 海高）低于武器的最低接合高度（" + Conversions.ToString((int)Math.Round(weapon_0.MinTargetAlt_ASL * 3.28084f)) + "英尺 海高）";
					}
					return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude())) + "米 海高）低于武器的最低接合高度（" + Conversions.ToString(weapon_0.MinTargetAlt_ASL) + "米 海高）";
				}
			}
			return "OK";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error";
		}
	}

	internal string VisitConsumer(Weapon weapon_0, Contact contact_0, ref short? nullable_0)
	{
		try
		{
			if (myUnit.IsAircraft && !contact_0.IsOrbitalContact && (weapon_0.MinLaunchAlt_AGL != 0f || weapon_0.MaxLaunchAlt_AGL != 0f || weapon_0.MinLaunchAlt_ASL != 0f || weapon_0.MaxLaunchAlt_ASL != 0f))
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = (short)Math.Max(0, myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen));
				}
				short value = nullable_0.Value;
				if (!(weapon_0.MaxLaunchAlt_AGL <= 0f) && (double)(myUnit.GetCurrentAltitude() - (float)value) > (double)weapon_0.MaxLaunchAlt_AGL + 0.1)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value <= 0)
						{
							if (weapon_0.MinLaunchAlt_AGL <= 0f)
							{
								if (weapon_0.MinLaunchAlt_ASL <= 0f)
								{
									return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + " 英尺 真高 最大值）";
								}
								return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + "英尺 真高）";
							}
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + "英尺 真高）";
						}
						if (weapon_0.MinLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MinLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + " 英尺 真高 最大，地形高度" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
							}
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + " 英尺 真高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
						}
						return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + " 英尺 真高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
					}
					if (value <= 0)
					{
						if (weapon_0.MinLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MinLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + " 米 真高 最大）";
							}
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + "米 真高）";
						}
						return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + "米 真高）";
					}
					if (weapon_0.MinLaunchAlt_AGL <= 0f)
					{
						if (weapon_0.MinLaunchAlt_ASL <= 0f)
						{
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + " 米 真高 最大，地形高度" + Conversions.ToString((int)value) + " 米)";
						}
						return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + " 米 真高，地形高程" + Conversions.ToString((int)value) + " 米)";
					}
					return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + " 米 真高，地形高程" + Conversions.ToString((int)value) + " 米)";
				}
				if (!(weapon_0.MaxLaunchAlt_ASL <= 0f) && (double)myUnit.GetCurrentAltitude() > (double)weapon_0.MaxLaunchAlt_ASL + 0.1)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value <= 0)
						{
							if (weapon_0.MinLaunchAlt_AGL <= 0f)
							{
								if (weapon_0.MinLaunchAlt_ASL <= 0f)
								{
									return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + " 英尺 海高最大值）";
								}
								return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + "英尺 海高）";
							}
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + "英尺 海高）";
						}
						if (weapon_0.MinLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MinLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + " 英尺 海高最大，地形高度" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
							}
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + " 英尺 海高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
						}
						return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + " 英尺 海高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
					}
					if (value <= 0)
					{
						if (weapon_0.MinLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MinLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + "米 海高 最大）";
							}
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + "米 海高）";
						}
						return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + "米 海高）";
					}
					if (weapon_0.MinLaunchAlt_AGL <= 0f)
					{
						if (weapon_0.MinLaunchAlt_ASL <= 0f)
						{
							return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + "米 海高 最大，地形高程" + Conversions.ToString((int)value) + " 米)";
						}
						return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + " 米 海高，地形高程" + Conversions.ToString((int)value) + " 米)";
					}
					return "飞机高度太高（有效高度：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + " 米 海高，地形高程" + Conversions.ToString((int)value) + " 米)";
				}
				if (weapon_0.MinLaunchAlt_AGL > 0f && (double)myUnit.GetCurrentAltitude() < (double)(weapon_0.MinLaunchAlt_AGL + (float)value) - 0.1)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value <= 0)
						{
							if (weapon_0.MaxLaunchAlt_AGL <= 0f)
							{
								if (weapon_0.MaxLaunchAlt_ASL <= 0f)
								{
									return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + "英尺 真高最小值）";
								}
								return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + "英尺 海高）";
							}
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + "英尺 真高）";
						}
						if (weapon_0.MaxLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MaxLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + "英尺 真高最小，地形高度" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
							}
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + " 英尺 海高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
						}
						return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)) + " 英尺 真高到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + " 英尺 真高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
					}
					if (value <= 0)
					{
						if (weapon_0.MaxLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MaxLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + "米 真高 最小）";
							}
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + "米 海高）";
						}
						return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + "米 真高）";
					}
					if (weapon_0.MaxLaunchAlt_AGL <= 0f)
					{
						if (weapon_0.MaxLaunchAlt_ASL <= 0f)
						{
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + "米 真高 最小，地形高度" + Conversions.ToString((int)value) + " 米)";
						}
						return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL)) + " 米 海高，地形高程" + Conversions.ToString((int)value) + " 米)";
					}
					return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_AGL)) + " 米 真高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL)) + " 米 真高，地形高程" + Conversions.ToString((int)value) + " 米)";
				}
				if (weapon_0.MinLaunchAlt_ASL > 0f && (double)myUnit.GetCurrentAltitude() < (double)weapon_0.MinLaunchAlt_ASL - 0.1)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value <= 0)
						{
							if (weapon_0.MaxLaunchAlt_AGL <= 0f)
							{
								if (weapon_0.MaxLaunchAlt_ASL <= 0f)
								{
									return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + "英尺 海高最小值）";
								}
								return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f)) + "英尺 海高）";
							}
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f)) + "英尺 真高）";
						}
						if (weapon_0.MaxLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MaxLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + "英尺 海高 最小，地形高度" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
							}
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round((weapon_0.MaxLaunchAlt_ASL + (float)value) * 3.28084f)) + " 英尺 海高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
						}
						return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)) + " 英尺 海高 to" + Conversions.ToString((int)Math.Round((weapon_0.MaxLaunchAlt_AGL + (float)value) * 3.28084f)) + " 英尺 真高，地形高程" + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " 英尺）";
					}
					if (value <= 0)
					{
						if (weapon_0.MaxLaunchAlt_AGL <= 0f)
						{
							if (weapon_0.MaxLaunchAlt_ASL <= 0f)
							{
								return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + "米 海高 最小）";
							}
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL + (float)value)) + "米 海高）";
						}
						return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL + (float)value)) + "米 真高）";
					}
					if (weapon_0.MaxLaunchAlt_AGL <= 0f)
					{
						if (weapon_0.MaxLaunchAlt_ASL <= 0f)
						{
							return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + "米 海高 最小，地形高度" + Conversions.ToString((int)value) + " 米)";
						}
						return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_ASL + (float)value)) + " 米 海高，地形高程" + Conversions.ToString((int)value) + " 米)";
					}
					return "飞机高度太低（有效：" + Conversions.ToString((int)Math.Round(weapon_0.MinLaunchAlt_ASL)) + " 米 海高 到" + Conversions.ToString((int)Math.Round(weapon_0.MaxLaunchAlt_AGL + (float)value)) + " 米 真高，地形高程" + Conversions.ToString((int)value) + " 米)";
				}
			}
			return "OK";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error";
		}
	}

	public (string EvaluationString, WeaponPrefireChecklistEvaluation EvaluationEnum) CanThisWeaponEngageThisTarget(Weapon weapon_0, Contact contact_0, ref short? nullable_0, bool bool_1, bool bool_2, bool bool_3, Mount mount_0, ref Sensor sensor_0)
	{
		(string, WeaponPrefireChecklistEvaluation) result = CanThisWeaponEngageThisTarget_Internal(weapon_0, contact_0, ref nullable_0, bool_1, bool_2, bool_3, mount_0, ref sensor_0);
		if (Debugger.IsAttached && result.Item2 != 0 && ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.All) | ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit) & myUnit.GetUnitSide().SelectedUnits.Contains(myUnit))))
		{
			string text = result.Item2.ToString() + " " + result.Item1 + " Target " + contact_0.Name + " Weapon: " + weapon_0.Name;
			if (Operators.CompareString(Misc.LastBarkText, text, TextCompare: false) != 0)
			{
				Notification_Bark.Create(myUnit, text, Color.Red, bool_0: true, bool_1: true, 7f);
				Misc.LastBarkText = text;
			}
		}
		return result;
	}

	public (string EvaluationString, WeaponPrefireChecklistEvaluation EvaluationEnum) CanThisWeaponEngageThisTarget_Internal(Weapon weapon_0, Contact contact_0, ref short? nullable_0, bool bool_1, bool bool_2, bool bool_3, Mount mount_0, ref Sensor sensor_0)
	{
		try
		{
			if (Debugger.IsAttached)
			{
				bool_3 = true;
			}
			if (contact_0 == null)
			{
				if (bool_3)
				{
					return (EvaluationString: "目标为空", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
				}
				return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
			}
			if (weapon_0 == null)
			{
				return (EvaluationString: "武器无效", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
			}
			if (weapon_0.Guidance == Weapon.WeaponGuidanceType.CommandGuided_Datalinked && contact_0.Age > 0f)
			{
				return (EvaluationString: "无法向过期目标发射指令引导武器。", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
			}
			if (weapon_0.Type != Weapon._WeaponType.Decoy_Expendable && weapon_0.Type != Weapon._WeaponType.Decoy_Towed)
			{
				if (weapon_0.IsMine)
				{
					UnguidedWeapon unguidedWeapon_ = new UnguidedWeapon(weapon_0, null, null, 0.0, 0.0, 0L);
					string text = UnguidedWeapon.CanLayMineHere(ref unguidedWeapon_, contact_0.GetLatitude(), contact_0.GetLongitude(), contact_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen), myUnit.ParentScen);
					if (string.CompareOrdinal(text, "OK") == 0)
					{
						return (EvaluationString: "可以在这里布雷。将单元分配给布雷任务。", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					return (EvaluationString: text, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
				}
				Weapon weapon = weapon_0;
				ActiveUnit activeUnit_ = myUnit;
				bool? nullable_ = null;
				if (weapon.QueryReponse(activeUnit_, ref contact_0, ref nullable_))
				{
					if (mount_0 != null)
					{
						if (mount_0.Status != 0)
						{
							return (EvaluationString: "武器挂架不可操作", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
						if (mount_0.ReloadStatus == Mount._ReloadStatus.Reloading)
						{
							return (EvaluationString: "武器正在重新装载", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
						if (mount_0.ReloadStatus == Mount._ReloadStatus.Unloading)
						{
							return (EvaluationString: "武器正在卸载", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
						if (mount_0.OrderTokenizer())
						{
							return (EvaluationString: "The launcher is still linked to a wire-guided weapon", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
						if (myUnit.GetCurrentAltitude() < 0f && weapon_0.IsGuidedOrUnguidedGun())
						{
							return (EvaluationString: "枪不能在水下射击", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
					}
					if (weapon_0.IsNuke.Value && myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value != Doctrine._UseNukesAllowed.Yes && !myUnit.IsBallisticMissile)
					{
						return (EvaluationString: "该单元未被授权使用核武器", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					if (weapon_0.IsUnguidedBallisticWeapon && contact_0.Type == Contact_Base.ContactType.Facility_Mobile && contact_0.CurrentSpeed > 0f && contact_0.Age > 5f)
					{
						return (EvaluationString: "目标时间超过5秒 - 需要当前目标数据才能使用非制导武器", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					float num = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
					float num4 = Module_Unit.RangeToUnit_Slant(myUnit, contact_0, num);
					if (weapon_0.Type == Weapon._WeaponType.Dispenser && num * 1852f > (float)weapon_0.Warheads[0].ClusterBombDispersionAreaLength)
					{
						return (EvaluationString: "目标超出武器范围", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					if (contact_0.IsBallisticTarget() && (!contact_0.HeadingIsKnown || !contact_0.SpeedIsKnown || !contact_0.AltitudeIsKnown))
					{
						return (EvaluationString: "Insufficient tracking data for BMD engagement", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					if (weapon_0.IsTorpedo && myUnit.IsAircraft && contact_0.Type == Contact_Base.ContactType.Submarine && (double)num > 0.4)
					{
						return (EvaluationString: "空投鱼雷必须在距目标点0.4海里内投放。", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					float num5 = WeaponOuterRangeLimit(ref myUnit, ref weapon_0, ref contact_0, bool_1);
					if (weapon_0.IsGuidedOrUnguidedGun())
					{
						if (num5 < num4)
						{
							return (EvaluationString: "Target is out of weapon range (slant)", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
					}
					else if (num5 < num)
					{
						return (EvaluationString: "Target is out of weapon range (horiz)", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					if (num > num5 && Module_Unit.ClosureSpeed(myUnit, contact_0, myUnit.CurrentSpeed, myUnit.CurrentHeading) <= 0f)
					{
						return (EvaluationString: "Impossible to intercept target", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					if (weapon_0.IsGuidedOrUnguidedGun())
					{
						if (weapon_0.MapReponse(num4, contact_0))
						{
							return (EvaluationString: "目标在武器最小范围内", EvaluationEnum: WeaponPrefireChecklistEvaluation.WithinMinimumRange);
						}
					}
					else if (weapon_0.MapReponse(num, contact_0))
					{
						return (EvaluationString: "目标在武器最小范围内", EvaluationEnum: WeaponPrefireChecklistEvaluation.WithinMinimumRange);
					}
					if (myUnit.IsAircraft && !contact_0.IsAir_Missile_Orbital_Contact && !contact_0.IsSubmergedContact && weapon_0.IsUnguidedBallisticWeapon)
					{
						float maxDownRange = weapon_0.GetMaxDownRange(myUnit.GetCurrentAltitude(), myUnit.CurrentAltitude_AGL, contact_0.Type);
						if (maxDownRange >= 0f && num > maxDownRange)
						{
							if (bool_3)
							{
								systemWrapper.Clear();
								systemWrapper.Append("目标水平范围（").Append(Math.Round(num, 1)).Append("海里)大于该高度下武器的下降范围(")
									.Append(Math.Round(maxDownRange))
									.Append("nm)");
								return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
							}
							return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
					}
					if (weapon_0.IsMissile && weapon_0.IsAAW && contact_0.Type == Contact_Base.ContactType.Surface && myUnit.Doctrine.GetUseSAMsOnASuW(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value != Doctrine._UseSAMsAgainstShips.Yes)
					{
						return (EvaluationString: "单元无权对地表目标使用SAM", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					if (!contact_0.IsBallisticTarget())
					{
						(string, WeaponPrefireChecklistEvaluation) result = RestartConsumer(weapon_0, contact_0, 0f, bool_3);
						if (result.Item2 != 0)
						{
							return result;
						}
					}
					if (contact_0.Type == Contact_Base.ContactType.ActivationPoint && !weapon_0.Flags.BearingOnlyLaunch && !weapon_0.PostReponse())
					{
						return (EvaluationString: "武器不具备BOL能力", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					string text2 = ReflectConsumer(weapon_0, contact_0);
					if (string.CompareOrdinal(text2, "OK") == 0)
					{
						if (!contact_0.IsBallisticTarget() && myUnit.ParentScen.FeatureCompatibility.GetWeaponSnapUpDown(myUnit.ParentScen.DBConnection) && weapon_0.SnapUpDown > 0f && contact_0.IsAir_Missile_Orbital_Contact && Module_Unit.RateTokenizer(contact_0, myUnit.ParentScen) == 0f)
						{
							float num6 = Math.Abs(contact_0.GetCurrentAltitude() - myUnit.GetCurrentAltitude());
							if (num6 > weapon_0.SnapUpDown)
							{
								if (bool_3)
								{
									systemWrapper.Clear();
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										systemWrapper.Append("海拔差异（").Append((int)Math.Round(num6 * 3.28084f)).Append(" 英尺)超出武器性能指标(")
											.Append((int)Math.Round(weapon_0.SnapUpDown * 3.28084f))
											.Append(" 英尺）");
										return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									systemWrapper.Append("海拔差异（").Append((int)Math.Round(num6)).Append(" 米)超出武器性能指标(")
										.Append((int)Math.Round(weapon_0.SnapUpDown))
										.Append(" 米)");
									return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
								return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
							}
						}
						if (!weapon_0.IsNuke.Value && contact_0.Type == Contact_Base.ContactType.Submarine && (weapon_0.Type == Weapon._WeaponType.DepthCharge || weapon_0.Type == Weapon._WeaponType.Rocket) && contact_0.UncertaintyArea != null)
						{
							return (EvaluationString: "武器需要精确的目标位置", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
						}
						if (mount_0 != null)
						{
							int num7 = 0;
							foreach (WeaponRec mountWeapon in mount_0.MountWeapons)
							{
								if (mountWeapon.int_0 == weapon_0.DBID)
								{
									num7 += mountWeapon.CurrentLoad;
								}
							}
							if (num7 == 0)
							{
								return (EvaluationString: "未加载武器到挂架", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
							}
						}
						weapon_0.SetLatitude(null, myUnit.GetLatitude());
						weapon_0.SetLongitude(null, myUnit.GetLongitude());
						if (weapon_0.GetCurrentAltitude() != myUnit.GetCurrentAltitude())
						{
							weapon_0.SetCurrentAltitude(bool_0: false, myUnit.GetCurrentAltitude());
						}
						if (myUnit.IsAircraft)
						{
							weapon_0.CurrentHeading = myUnit.CurrentHeading;
						}
						else if (!myUnit.IsFacility && !myUnit.IsShip)
						{
							if (myUnit.IsSubmarine)
							{
								if (weapon_0.IsAAW)
								{
									weapon_0.CurrentHeading = Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude());
								}
								else
								{
									weapon_0.CurrentHeading = myUnit.CurrentHeading;
								}
							}
						}
						else
						{
							weapon_0.CurrentHeading = Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude());
						}
						text2 = VisitConsumer(weapon_0, contact_0, ref nullable_0);
						if (string.CompareOrdinal(text2, "OK") == 0)
						{
							if (myUnit.IsSubmarine)
							{
								if (weapon_0.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(weapon_0.ParentScen.DBConnection))
								{
									if (!((double)myUnit.GetCurrentAltitude() <= (double)weapon_0.MaxLaunchAlt_ASL + 0.1))
									{
										if (bool_3)
										{
											systemWrapper.Clear();
											if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
											{
												systemWrapper.Append("潜艇太浅而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)).Append("至")
													.Append((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f))
													.Append(" 英尺）");
												return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
											}
											systemWrapper.Append("潜艇太浅而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_ASL)).Append("至")
												.Append((int)Math.Round(weapon_0.MaxLaunchAlt_ASL))
												.Append(" 米)");
											return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									if ((double)myUnit.GetCurrentAltitude() < (double)weapon_0.MinLaunchAlt_ASL - 0.1)
									{
										if (bool_3)
										{
											systemWrapper.Clear();
											if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
											{
												systemWrapper.Append("潜艇太深而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_ASL * 3.28084f)).Append("至")
													.Append((int)Math.Round(weapon_0.MaxLaunchAlt_ASL * 3.28084f))
													.Append(" 英尺）");
												return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
											}
											systemWrapper.Append("潜艇太深而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_ASL)).Append("至")
												.Append((int)Math.Round(weapon_0.MaxLaunchAlt_ASL))
												.Append(" 米)");
											return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
								else
								{
									if (!((double)myUnit.GetCurrentAltitude() <= (double)weapon_0.MaxLaunchAlt_AGL + 0.1))
									{
										if (bool_3)
										{
											systemWrapper.Clear();
											if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
											{
												systemWrapper.Append("潜艇太浅而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)).Append("至")
													.Append((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f))
													.Append(" 英尺）");
												return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
											}
											systemWrapper.Append("潜艇太浅而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_AGL)).Append("至")
												.Append((int)Math.Round(weapon_0.MaxLaunchAlt_AGL))
												.Append(" 米)");
											return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									if ((double)myUnit.GetCurrentAltitude() < (double)weapon_0.MinLaunchAlt_AGL - 0.1)
									{
										if (bool_3)
										{
											systemWrapper.Clear();
											if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
											{
												systemWrapper.Append("潜艇太深而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_AGL * 3.28084f)).Append("至")
													.Append((int)Math.Round(weapon_0.MaxLaunchAlt_AGL * 3.28084f))
													.Append(" 英尺）");
												return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
											}
											systemWrapper.Append("潜艇太深而无法发射（有效深度：").Append((int)Math.Round(weapon_0.MinLaunchAlt_AGL)).Append("至")
												.Append((int)Math.Round(weapon_0.MaxLaunchAlt_AGL))
												.Append(" 米)");
											return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
							}
							if (!bool_2 && !weapon_0.PostReponse() && myUnit.IsAircraft && myUnit.CurrentSpeed > 0f)
							{
								if (mount_0 == null)
								{
									string string_ = "";
									if (!CreateConsumer(weapon_0, contact_0, ref string_))
									{
										return (EvaluationString: string_, EvaluationEnum: WeaponPrefireChecklistEvaluation.OutsideBoresightLimits);
									}
								}
								else if (!mount_0.TargetIsWithinCoverageArc(contact_0))
								{
									return (EvaluationString: "目标位于武器装置的攻击范围外（5海里内）", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							if (contact_0.Type == Contact_Base.ContactType.Air)
							{
								if (weapon_0.Flags.SternChase_AAM)
								{
									Weapon unit_ = weapon_0;
									Contact unit_2 = contact_0;
									string string_2 = "";
									float num8 = Module_Unit.PrintTokenizer(unit_, unit_2, bool_0: true, ref string_2);
									if (Math.Abs(num8) < 130f)
									{
										if (bool_3)
										{
											systemWrapper.Clear();
											systemWrapper.Append("目标（").Append(Math.Abs((int)Math.Round(num8))).Append(" 度）在武器范围外");
											return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
								if (weapon_0.Flags.RearAspect_AAM)
								{
									Weapon unit_3 = weapon_0;
									Contact unit_4 = contact_0;
									string string_3 = "";
									float num9 = Module_Unit.PrintTokenizer(unit_3, unit_4, bool_0: true, ref string_3);
									if (Math.Abs(num9) < 100f)
									{
										if (bool_3)
										{
											systemWrapper.Clear();
											systemWrapper.Append("目标（").Append(Math.Abs((int)Math.Round(num9))).Append(" 度）在武器范围外");
											return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
							}
							if (myUnit.IsAircraft)
							{
								float num10 = myUnit.AI.TargetingDelayForThisTarget(contact_0);
								if (num10 > 0f)
								{
									if (bool_3)
									{
										systemWrapper.Clear();
										systemWrapper.Append("武器无法更改目标").Append(Math.Round(num10, 1)).Append("秒（OODA环限制）");
										return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							else if (mount_0 != null && !mount_0.IsAutonomous)
							{
								float num11 = myUnit.AI.TargetingDelayForThisTarget(contact_0);
								if (num11 > 0f)
								{
									if (bool_3)
									{
										systemWrapper.Clear();
										systemWrapper.Append("武器无法更改目标").Append(Math.Round(num11, 1)).Append("秒（OODA环限制）");
										return (EvaluationString: systemWrapper.ToString(), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									return (EvaluationString: null, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							if (mount_0 != null && num <= 5f && !mount_0.TargetIsWithinCoverageArc(contact_0))
							{
								return (EvaluationString: "目标位于武器装置的攻击范围外（5海里内）", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
							}
							if (contact_0.Type == Contact_Base.ContactType.ActivationPoint)
							{
								return (EvaluationString: "OK", EvaluationEnum: WeaponPrefireChecklistEvaluation.OK);
							}
							if (contact_0.ActualUnit == null)
							{
								if (myUnit.IsWeapon)
								{
									return (EvaluationString: "OK", EvaluationEnum: WeaponPrefireChecklistEvaluation.OK);
								}
								return (EvaluationString: "目标消失了", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
							}
							if (contact_0.ActualUnit.IsShip || contact_0.ActualUnit.IsSubmarine || contact_0.ActualUnit.IsFacility)
							{
								string text3 = IsWeaponSuitableForTargetAmbiguity(weapon_0, contact_0);
								if (string.CompareOrdinal(text3, "OK") != 0)
								{
									return (EvaluationString: text3, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							if (SeaIceProvider.PrepareWriter(contact_0.GetLongitude(), contact_0.GetLatitude()))
							{
								if ((myUnit.GetCurrentAltitude() > 0f && contact_0.ActualUnit.GetCurrentAltitude() < 0f) || (myUnit.GetCurrentAltitude() < 0f && contact_0.ActualUnit.GetCurrentAltitude() > 0f))
								{
									return (EvaluationString: "武器不能穿过冰层", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
								if (myUnit.GetCurrentAltitude() < 0f && weapon_0.IsMissile)
								{
									return (EvaluationString: "在冰层下不能发射导弹", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
								if (myUnit.GetCurrentAltitude() > 0f && weapon_0.IsTorpedo)
								{
									return (EvaluationString: "不能在冰层上方使用鱼雷", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
								if (contact_0.IsSubmergedContact && myUnit.IsShip && weapon_0.IsMissile)
								{
									return (EvaluationString: "不能用导弹攻击冰下潜艇", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							if ((weapon_0.Type == Weapon._WeaponType.Laser || weapon_0.Type == Weapon._WeaponType.Microwave || weapon_0.Type == Weapon._WeaponType.LaserDazzler) && contact_0.ActualUnit != null && Module_Unit.Has_Visual_LOS_ToUnit(myUnit, null, contact_0.ActualUnit, ref myUnit.ParentScen, bool_0: true) != Module_Unit.Unit.LOSCheckResult.Success)
							{
								return (EvaluationString: "Weapon has no visual LOS to target", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
							}
							if (weapon_0.Type == Weapon._WeaponType.Microwave && mount_0 != null)
							{
								Mount mount = null;
								foreach (UnguidedWeapon value2 in myUnit.ParentScen.UnguidedWeapons.Values)
								{
									if (value2.Type != Weapon._WeaponType.Microwave || value2.Target.ActualUnit != contact_0.ActualUnit || string.IsNullOrEmpty(value2.FiringWeaponRec_ID))
									{
										continue;
									}
									foreach (Mount mount2 in myUnit.Mounts)
									{
										foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
										{
											if (Operators.CompareString(mountWeapon2.ObjectID, value2.FiringWeaponRec_ID, TextCompare: false) == 0)
											{
												mount = mount2;
												break;
											}
										}
									}
								}
								if (mount == mount_0)
								{
									return (EvaluationString: "Mount already beaming at this target", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
								int num2 = 0;
								foreach (UnguidedWeapon value3 in myUnit.ParentScen.UnguidedWeapons.Values)
								{
									if (value3.Type != Weapon._WeaponType.Microwave || string.IsNullOrEmpty(value3.FiringWeaponRec_ID))
									{
										continue;
									}
									foreach (WeaponRec mountWeapon3 in mount_0.MountWeapons)
									{
										if (Operators.CompareString(mountWeapon3.ObjectID, value3.FiringWeaponRec_ID, TextCompare: false) == 0)
										{
											num2++;
										}
									}
								}
								Sensor sensor = weapon_0.Sensors_Cached[0];
								if (num2 <= sensor.MaxIlluminate)
								{
									if (num2 == sensor.MaxIlluminate)
									{
										return (EvaluationString: "Mount already fully commited", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									if (num2 > 0)
									{
										List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
										foreach (UnguidedWeapon value4 in myUnit.ParentScen.UnguidedWeapons.Values)
										{
											if (value4.FiringParent != myUnit)
											{
												continue;
											}
											foreach (WeaponRec mountWeapon4 in mount_0.MountWeapons)
											{
												if (Operators.CompareString(mountWeapon4.ObjectID, value4.FiringWeaponRec_ID, TextCompare: false) == 0)
												{
													list.Add(value4.Target);
												}
											}
										}
										if (list.Count != 0)
										{
											list.Add(contact_0);
											if (!BearingForSensorBoresightToCoverMultipleTargets(sensor, list).HasValue)
											{
												return (EvaluationString: "Mount cannot engage this target without interrupting existing engagements", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
											}
										}
									}
								}
								else if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
							bool flag = false;
							if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl))
							{
								if (!myUnit.IsAircraft && weapon_0.Type == Weapon._WeaponType.Gun && contact_0.Type != Contact_Base.ContactType.Facility_Fixed && contact_0.Type != Contact_Base.ContactType.Facility_Mobile && mount_0 != null && !mount_0.LocalControl)
								{
									if (StopConsumer(mount_0, contact_0).Count == 0)
									{
										return (EvaluationString: "枪没有本地控制，也没有可用的引导器", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									flag = true;
								}
							}
							else
							{
								flag = true;
							}
							List<ActiveUnit> list2 = null;
							if (!contact_0.IsFirm && !weapon_0.CanBeFiredOnAmbigousTarget(contact_0, flag))
							{
								bool flag2 = false;
								Sensor[] sensors_Cached = myUnit.Sensors_Cached;
								Sensor[] array2 = sensors_Cached;
								foreach (Sensor sensor2 in array2)
								{
									if (!sensor2.CanBeActive || sensor2.IsActive || !sensor2.CanIlluminateForThisWeapon(ref weapon_0) || !sensor2.GetIsPrecise(num4))
									{
										continue;
									}
									if (list2 == null)
									{
										list2 = myUnit.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
									}
									float float_ = (weapon_0.IsGuidedOrUnguidedGun() ? num4 : num);
									ActiveUnit activeUnit_2 = myUnit;
									ActiveUnit actualUnit = contact_0.ActualUnit;
									List<Geopoint_Struct> list_ = null;
									Lazy<Dictionary<int, EmissionContainer>> lazy_ = null;
									List<ActiveUnit> list_2 = list2;
									nullable_ = null;
									bool? nullable_12 = null;
									Module_Unit.Unit.LOSCheckResult? nullable_17 = null;
									bool? nullable_18 = null;
									bool? nullable_19 = null;
									bool? nullable_20 = null;
									if (!sensor2.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, activeUnit_2, actualUnit, ref list_, float_, ref lazy_, list_2, ref nullable_, ref nullable_12, ref nullable_17, ref nullable_18, ref nullable_19, ref nullable_20))
									{
										continue;
									}
									float num3 = (weapon_0.IsGuidedOrUnguidedGun() ? Module_Unit.RangeToUnit_Slant(myUnit, contact_0.ActualUnit) : Module_Unit.RangeToUnit_Horiz(myUnit, contact_0.ActualUnit));
									ActiveUnit activeUnit_3 = myUnit;
									ActiveUnit actualUnit2 = contact_0.ActualUnit;
									list_ = null;
									lazy_ = null;
									List<ActiveUnit> list_3 = list2;
									nullable_20 = null;
									nullable_19 = null;
									nullable_17 = null;
									nullable_18 = null;
									nullable_12 = null;
									nullable_ = null;
									if (sensor2.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, activeUnit_3, actualUnit2, ref list_, num3, ref lazy_, list_3, ref nullable_20, ref nullable_19, ref nullable_17, ref nullable_18, ref nullable_12, ref nullable_))
									{
										if (weapon_0.Type == Weapon._WeaponType.Dispenser && num3 * 1852f > (float)weapon_0.Warheads[0].ClusterBombDispersionAreaLength)
										{
											return (EvaluationString: "武器无法攻击超出武器范围的不精确目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										if (weapon_0.IsTorpedo && myUnit.IsAircraft && contact_0.Type == Contact_Base.ContactType.Submarine && (double)num3 > 0.4)
										{
											return (EvaluationString: "无法向非精确目标发射武器，由于空投鱼雷必须在距目标点0.4海里内投放。", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										if (WeaponOuterRangeLimit(ref myUnit, ref weapon_0, ref contact_0, bool_1) < num3)
										{
											return (EvaluationString: "武器无法攻击超出武器范围的不精确目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										if (weapon_0.MapReponse(num3, contact_0))
										{
											return (EvaluationString: "武器无法攻击武器最小范围内的不精确目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									return (EvaluationString: "武器无法攻击不精确的目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							Lazy<Dictionary<int, EmissionContainer>> lazy_2 = new Lazy<Dictionary<int, EmissionContainer>>();
							if (weapon_0.Guidance == Weapon.WeaponGuidanceType.Passive && (!weapon_0.IsMissile || contact_0.Type != 0 || !myUnit.IsAircraft || !((Aircraft)myUnit).HasHelmetMountedSight))
							{
								Sensor obj = weapon_0.Sensors_ReadOnly()[0];
								Weapon activeUnit_4 = weapon_0;
								ActiveUnit actualUnit3 = contact_0.ActualUnit;
								List<Geopoint_Struct> list_4 = null;
								nullable_ = null;
								bool? nullable_21 = null;
								Module_Unit.Unit.LOSCheckResult? nullable_22 = null;
								bool? nullable_23 = null;
								bool? nullable_2 = null;
								bool? nullable_3 = null;
								if (!obj.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, activeUnit_4, actualUnit3, ref list_4, num, ref lazy_2, null, ref nullable_, ref nullable_21, ref nullable_22, ref nullable_23, ref nullable_2, ref nullable_3))
								{
									return (EvaluationString: "武器必须在射击前检测目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							CommDevice[] comms_ReadOnly = weapon_0.Comms_ReadOnly;
							if (comms_ReadOnly.Length != 0 && !comms_ReadOnly[0].IsOptional && weapon_0.CommStuff.CommDeviceToConnectToThisUnit(comms_ReadOnly, myUnit) == null)
							{
								return (EvaluationString: "无法使用强制数据链接连接到发射装置", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
							}
							if (weapon_0.Flags.IlluminateAtLaunch || weapon_0.Flags.TerminalIllumination)
							{
								bool flag3 = false;
								bool flag4 = false;
								bool flag5 = false;
								List<Sensor> list3 = new List<Sensor>();
								Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
								Sensor[] array3 = sensors_Cached2;
								foreach (Sensor sensor3 in array3)
								{
									if (sensor3.Status == PlatformComponent._ComponentStatus.Operational && sensor3.CanIlluminateForThisWeapon(ref weapon_0))
									{
										list3.Add(sensor3);
									}
								}
								if (list3.Count > 0)
								{
									flag3 = true;
									List<Sensor> list4 = new List<Sensor>();
									foreach (Sensor item in list3)
									{
										if (weapon_0.Guidance == Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive)
										{
											list4.Add(item);
										}
										else if (item.TargetsTrackedForFireControl_Readonly.Count < item.MaxIlluminate || item.IsTrackingThisTargetForFireControl(ref contact_0))
										{
											list4.Add(item);
										}
									}
									if (list4.Count > 0)
									{
										flag4 = true;
										new List<Sensor>();
										Module_Unit.Unit.LOSCheckResult? nullable_4 = null;
										bool? nullable_5 = null;
										bool? nullable_6 = null;
										bool? nullable_7 = null;
										foreach (Sensor item2 in list4)
										{
											if (item2.Type == Sensor.Sensor_Type.Radar && list2 == null)
											{
												list2 = myUnit.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
											}
											if (item2.CanIlluminateTarget(myUnit, ref contact_0, ref myUnit.ParentScen, num4, list2, myUnit.IsShip, bool_1: false, ref nullable_5, ref nullable_6, ref nullable_4, ref nullable_7) == Sensor.SensorDetectionCheckResult.Success)
											{
												sensor_0 = item2;
												flag5 = true;
												break;
											}
										}
									}
								}
								if (!flag3 || !flag4 || !flag5)
								{
									Sensor sensor_ = null;
									if (myUnit.IsMobileGroundUnit && myUnit.IsGroupMember())
									{
										foreach (ActiveUnit item3 in weapon_0.FetchAvailableIlluminators_VehicleGroup(new List<ActiveUnit>(myUnit.GetParentGroup().Units.Values), contact_0))
										{
											if (item3 != null)
											{
												ActiveUnit_Sensory sensory = item3.Sensory;
												Contact contact_ = contact_0;
												Weapon weapon_ = weapon_0;
												bool? nullable_8 = null;
												bool? nullable_9 = null;
												Module_Unit.Unit.LOSCheckResult? nullable_10 = null;
												bool? nullable_11 = null;
												if (sensory.CanIlluminateThisContactForThisWeapon(contact_, weapon_, ref sensor_, ref nullable_8, ref nullable_9, ref nullable_10, ref nullable_11))
												{
													sensor_0 = sensor_;
												}
											}
										}
									}
									else if (weapon_0.Flags.SupportsBuddyIllumination)
									{
										foreach (ActiveUnit item4 in weapon_0.FetchAvailableBuddyIlluminatorUnits(myUnit.GetUnitSide(), contact_0))
										{
											if (item4 != null)
											{
												ActiveUnit_Sensory sensory2 = item4.Sensory;
												Contact contact_2 = contact_0;
												Weapon weapon_2 = weapon_0;
												bool? nullable_13 = null;
												bool? nullable_14 = null;
												Module_Unit.Unit.LOSCheckResult? nullable_15 = null;
												bool? nullable_16 = null;
												if (sensory2.CanIlluminateThisContactForThisWeapon(contact_2, weapon_2, ref sensor_, ref nullable_13, ref nullable_14, ref nullable_15, ref nullable_16))
												{
													sensor_0 = sensor_;
												}
											}
										}
									}
								}
								if (sensor_0 == null)
								{
									if (!flag3)
									{
										return (EvaluationString: "没有武器引导器能够照射目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									if (!flag4)
									{
										return (EvaluationString: "适用于此武器的所有照射通道均在使用中", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									if (!flag5)
									{
										return (EvaluationString: "没有引导器能够照射这个目标（反射不充分，没有LOS视线等）", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
							}
							if (weapon_0.Guidance == Weapon.WeaponGuidanceType.BeamRiding)
							{
								bool flag6 = false;
								bool flag7 = false;
								Sensor[] sensors_Cached3 = myUnit.Sensors_ReadOnly();
								Sensor[] array4 = sensors_Cached3;
								foreach (Sensor sensor4 in array4)
								{
									if (sensor4.Status == PlatformComponent._ComponentStatus.Operational && sensor4.CanIlluminateForThisWeapon(ref weapon_0))
									{
										flag6 = true;
										if (sensor4.TargetsTrackedForFireControl_Readonly.Count < sensor4.MaxIlluminate || sensor4.IsTrackingThisTargetForFireControl(ref contact_0))
										{
											sensor_0 = sensor4;
											flag7 = true;
										}
									}
								}
								if (!flag6)
								{
									return (EvaluationString: "没有武器引导器能够照射目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
								if (!flag7)
								{
									return (EvaluationString: "适用于此武器的所有照射通道均在使用中", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							foreach (NoNavZone noNavZone in myUnit.GetUnitSide().NoNavZones)
							{
								if (noNavZone.Area.Count != 0 && noNavZone.IsActive && noNavZone.GetAffectsThisUnit(contact_0.ActualUnit) && GeoPoint.IsInsideThisArea(contact_0.ActualUnit.GetLatitude(), contact_0.ActualUnit.GetLongitude(), noNavZone.Area) && noNavZone.Type == Zone.ZoneType.NoNavZone && noNavZone.NoFireZone)
								{
									return (EvaluationString: "Target is inside a no-navigation zone marked as no fire zone.", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							Weapon weapon2 = null;
							if (contact_0.ActualUnit.IsWeapon)
							{
								weapon2 = (Weapon)contact_0.ActualUnit;
							}
							if (contact_0.IsBallisticTarget() && (weapon2 == null || !weapon2.IsHGV || weapon2.GetCurrentAltitude() > 200000f))
							{
								if (contact_0.mapperObserver.Length == 0)
								{
									contact_0.mapperObserver = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(contact_0, myUnit.ParentScen);
								}
								TrajectoryPoint[] mapperObserver = contact_0.mapperObserver;
								float maxTargetAlt_ASL = weapon_0.MaxTargetAlt_ASL;
								float minTargetAlt_ASL = weapon_0.MinTargetAlt_ASL;
								float Local_MaxSlantRange = weapon_0.MaxRange_NoTargetType;
								bool Local_InterceptPossible = false;
								if (weapon_0.Type != Weapon._WeaponType.Laser && weapon_0.Type != Weapon._WeaponType.Microwave)
								{
									TrajectoryPoint[] array = mapperObserver;
									for (int i = 0; i < array.Length; i = checked(i + 1))
									{
										TrajectoryPoint trajectoryPoint = array[i];
										if (trajectoryPoint.Altitude < maxTargetAlt_ASL && !(trajectoryPoint.Altitude <= minTargetAlt_ASL))
										{
											Local_InterceptPossible = true;
											break;
										}
									}
								}
								else
								{
									Local_InterceptPossible = true;
								}
								if (!Local_InterceptPossible)
								{
									return (EvaluationString: "The weapon's target-altitude envelope does not match any point in the target's estimated trajectory", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
								Local_InterceptPossible = false;
								Parallel.ForEach(mapperObserver, delegate(TrajectoryPoint thePoint, ParallelLoopState loopstate)
								{
									if (Module_Unit.RangeToPoint_Slant(myUnit, thePoint) < Local_MaxSlantRange)
									{
										Local_InterceptPossible = true;
										loopstate.Stop();
									}
								});
								if (!Local_InterceptPossible)
								{
									return (EvaluationString: "No point in the target's estimated trajectory is within the weapon's engagement range", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
								}
							}
							if (weapon_0.IsGuidedWeapon() && weapon_0.IsAAW_GuidedMissile_ARH && contact_0.IsAir_Missile_Orbital_Contact && !myUnit.Sensory.PostDic(contact_0) && !TestConsumer(weapon_0, contact_0))
							{
								return (EvaluationString: "射击单元必须在射击之前（从其自身或另一个CEC启用的平台）获得目标的高质量轨迹", EvaluationEnum: WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC);
							}
							if (weapon_0.ValidTargets.Radar)
							{
								if (weapon_0.IsDualModeARM)
								{
									if (!contact_0.IsFirm)
									{
										return (EvaluationString: "Target is not radiating, and lacking a firm location solution to launch dual mode ARM in INS/GPS mode.", EvaluationEnum: WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC);
									}
								}
								else
								{
									if (!contact_0.HasDetectedEmissions)
									{
										if ((contact_0.ActualUnit != null) & contact_0.ActualUnit.GetIsAutoDetectable(myUnit.GetUnitSide()))
										{
											return (EvaluationString: "Target is autodetectable but not radiating", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
										}
										return (EvaluationString: "目标不是辐射目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
									Weapon weapon3 = weapon_0;
									ObservableDictionary<int, EmissionContainer> detectedEmissions = contact_0.DetectedEmissions;
									Side unitSide = myUnit.GetUnitSide();
									Contact contact_3 = contact_0;
									LockRandom lockRandom_ = GameGeneral.LockRandom_0;
									if (!weapon3.ARM_DetermineEmissionToTrack(detectedEmissions, unitSide, contact_3, bool_0: false, ref lockRandom_))
									{
										return (EvaluationString: "目前没有威胁发射器正在辐射", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
							}
							if (!bool_0 && CancelConsumer(weapon_0, contact_0))
							{
								Tuple<int, string> tuple = new Tuple<int, string>(weapon_0.DBID, contact_0.ObjectID);
								queueWrapper.Add(tuple);
								if (!bool_3 && DLZ_ResultsCache != null && DLZ_ResultsCache.TryGetValue(tuple, out var value))
								{
									if (value.Item1 != DLZResultEnum.Success && (value.Item1 != DLZResultEnum.Fail_MAXRangeWRA || !bool_1))
									{
										return (EvaluationString: TokenizerDefinitionSpec.ResolveTokenizer(value.Item1), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
								else
								{
									Tuple<DLZResultEnum, float> tuple2 = method_0(contact_0, weapon_0, bool_3, null, null, bool_1);
									if (DLZ_ResultsCache == null)
									{
										DLZ_ResultsCache = new ConcurrentDictionary<Tuple<int, string>, Tuple<DLZResultEnum, float>>();
									}
									DLZ_ResultsCache.TryAdd(tuple, tuple2);
									if (tuple2.Item1 != DLZResultEnum.Success)
									{
										return (EvaluationString: TokenizerDefinitionSpec.ResolveTokenizer(tuple2.Item1), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
									}
								}
							}
							return (EvaluationString: "OK", EvaluationEnum: WeaponPrefireChecklistEvaluation.OK);
						}
						return (EvaluationString: text2, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
					return (EvaluationString: text2, EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
				}
				return (EvaluationString: "武器不适合这个目标", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
			}
			return (EvaluationString: "武器是诱饵，会自动部署", EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101240", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			(string, WeaponPrefireChecklistEvaluation) result2 = ("发生了错误", WeaponPrefireChecklistEvaluation.OtherNegative);
			ProjectData.ClearProjectError();
			return result2;
		}
	}

	private (string, WeaponPrefireChecklistEvaluation) RestartConsumer(Weapon weapon_0, Contact contact_0, float float_0, bool bool_1)
	{
		float num = 0f;
		num = contact_0?.CurrentSpeed ?? float_0;
		if (weapon_0.MaxTargetSpeed > 0)
		{
			if (!(num <= (float)weapon_0.MaxTargetSpeed * 1.2f) && contact_0 != null && contact_0.Type != Contact_Base.ContactType.Orbital)
			{
				if (bool_1)
				{
					systemWrapper.Clear();
					systemWrapper.Append("目标速度(").Append((int)Math.Round(num)).Append("节)远高于武器的最大目标速度（")
						.Append(weapon_0.MaxTargetSpeed)
						.Append(" 节)");
					return (systemWrapper.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
				}
				return ("Other", WeaponPrefireChecklistEvaluation.OtherNegative);
			}
			if (num < (float)weapon_0.MinTargetSpeed * 0.8f && contact_0 != null && contact_0.Type != Contact_Base.ContactType.Orbital)
			{
				if (bool_1)
				{
					systemWrapper.Clear();
					systemWrapper.Append("目标速度(").Append((int)Math.Round(num)).Append(" kts) is much lower than the weapon's minimum target speed (")
						.Append(weapon_0.MinTargetSpeed)
						.Append(" 节)");
					return (systemWrapper.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
				}
				return ("Other", WeaponPrefireChecklistEvaluation.OtherNegative);
			}
		}
		return ("OK", WeaponPrefireChecklistEvaluation.OK);
	}

	private bool TestConsumer(Weapon weapon_0, Contact contact_0)
	{
		try
		{
			if (!weapon_0.Flags.LOAL_CEC && weapon_0.CommStuff.CommDeviceToConnectToThisUnit(weapon_0.Comms_ReadOnly, weapon_0.FiringParent) == null)
			{
				return false;
			}
			if (contact_0.UncertaintyArea == null)
			{
				List<ActiveUnit> source = new List<ActiveUnit>(myUnit.GetUnitSide().Units);
				bool result = false;
				Parallel.ForEach(source, delegate(ActiveUnit theAU, ParallelLoopState loopstate)
				{
					if (theAU.Sensory.PostDic(contact_0) && weapon_0.CommStuff.CommDeviceToConnectToThisUnit(weapon_0.Comms_ReadOnly, theAU) != null)
					{
						result = true;
						loopstate.Stop();
					}
				});
				return result;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1032450239658340", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public Tuple<DLZResultEnum, float> method_0(Contact contact_0, Weapon weapon_0, bool bool_1, Action<string> action_0 = null, Action<DLZResultData> action_1 = null, bool bool_2 = false)
	{
		double num = Math2.PrintClass(contact_0, myUnit);
		float float_ = 0f;
		Tuple<DLZResultEnum, float> result = null;
		try
		{
			if (contact_0 == null)
			{
				result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_TargetNotDefined, float_);
				return result;
			}
			float num2 = (myUnit.IsAircraft ? myUnit.CurrentHeading : 0f);
			GeoPoint geoPoint_ = null;
			weapon_0.FiringParent = myUnit;
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(weapon_0, myUnit.ParentScen, myUnit.IsAircraft || myUnit.IsMissile, action_0);
			Tuple<DLZResultEnum, float> tuple;
			if (contact_0.IsBallisticTarget())
			{
				Scenario parentScen = myUnit.ParentScen;
				int dBID = weapon_0.DBID;
				ActiveUnit activeUnit_ = myUnit;
				double longitude = myUnit.GetLongitude();
				double latitude = myUnit.GetLatitude();
				float float_2 = (int)Math.Round(myUnit.GetCurrentAltitude());
				int int_ = (int)Math.Round(myUnit.CurrentSpeed);
				Contact contact_ = contact_0;
				GeoPoint geoPoint_2 = null;
				string string_ = "";
				tuple = TargetIsWithinDLZ_BallisticTarget(parentScen, dBID, activeUnit_, longitude, latitude, float_2, int_, contact_, num2, ActiveUnit.Throttle.Cruise, ref geoPoint_2, ref string_, null, null, ref float_, action_0, action_1);
			}
			else if (contact_0.IsOrbitalContact)
			{
				tuple = TargetIsWithinDLZ_OrbitalTarget(myUnit.ParentScen, weapon_0.DBID, myUnit, myUnit.GetLongitude(), myUnit.GetLatitude(), (int)Math.Round(myUnit.GetCurrentAltitude()), (int)Math.Round(myUnit.CurrentSpeed), contact_0, 0f, ActiveUnit.Throttle.Cruise, ref float_);
			}
			else
			{
				float num3 = 0.1f;
				int int_2 = ((weapon_0.Propulsion[0].Type == Engine.EngineType.Nuclear) ? int.MaxValue : ((int)Math.Round((float)weapon_0.Fuel_ReadOnly[0].MaxQuantity * (1f - num3))));
				ActiveUnit.Throttle throttle_ = ActiveUnit.Throttle.Full;
				if (weapon_0.IsTorpedo)
				{
					throttle_ = ActiveUnit.Throttle.Cruise;
				}
				bool? nullable_ = null;
				Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_0, ref nullable_);
				float? num4 = myUnit.Doctrine.SearchRepository(myUnit.Doctrine, myUnit.ParentScen, weapon_0.DBID, _WRA_WeaponTargetType_);
				if (!num4.HasValue)
				{
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_);
					num4 = myUnit.Doctrine.SearchRepository(myUnit.Doctrine, myUnit.ParentScen, weapon_0.DBID, wRA_WeaponTargetType_);
					if (!num4.HasValue)
					{
						float? num5 = Doctrine.WRA_FiringRange_GetDefaultFiringRange(myUnit.ParentScen, weapon_0.DBID, _WRA_WeaponTargetType_);
						if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
						{
							num4 = -102f;
						}
					}
				}
				int num6 = (int)Math.Round(contact_0.CurrentSpeed);
				int maximumSpeed = contact_0.ActualUnit.Kinematics.GetMaximumSpeed(contact_0.GetCurrentAltitude());
				AssumedDLZTargetBehavior assumedDLZTargetBehavior = AssumedDLZTargetBehavior.ContinuesAsCurrent;
				if (num4.HasValue)
				{
					if (num4.Value == -102f)
					{
						if (Doctrine.IsNEZValidTarget(weapon_0, contact_0) && !bool_2)
						{
							if (GameGeneral.SpeedUp_NEZ_DLZ)
							{
								KeyValuePair<(float, double, float), (float, double)> keyValuePair = default(KeyValuePair<(float, double, float), (float, double)>);
								foreach (KeyValuePair<(float, double, float), (float, double)> item in Scenario.NEZ_DLZ_Cache)
								{
									if (item.Key.Item1 == (float)maximumSpeed && item.Key.Item2 == (double)myUnit.DBID && item.Key.Item3 == contact_0.ActualUnit.GetCurrentAltitude())
									{
										keyValuePair = item;
										break;
									}
								}
								if (!keyValuePair.Equals(default(KeyValuePair<(float, double, float), (float, double)>)))
								{
									if (keyValuePair.Value.Item1 != 0f && keyValuePair.Value.Item2 >= num)
									{
										result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Success, keyValuePair.Value.Item1);
										return result;
									}
									result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_MAXRangeWRA, 0f);
									return result;
								}
							}
							assumedDLZTargetBehavior = AssumedDLZTargetBehavior.RunStraightAway;
							if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
							{
								num6 = maximumSpeed;
							}
						}
						else
						{
							assumedDLZTargetBehavior = AssumedDLZTargetBehavior.ContinuesAsCurrent;
						}
					}
					else
					{
						assumedDLZTargetBehavior = AssumedDLZTargetBehavior.ContinuesAsCurrent;
					}
				}
				Scenario parentScen2 = myUnit.ParentScen;
				int dBID2 = weapon_0.DBID;
				ActiveUnit activeUnit_2 = myUnit;
				double longitude2 = myUnit.GetLongitude();
				double latitude2 = myUnit.GetLatitude();
				float float_3 = (int)Math.Round(myUnit.GetCurrentAltitude());
				int int_3 = (int)Math.Round(myUnit.CurrentSpeed);
				double longitude3 = contact_0.GetLongitude();
				double latitude3 = contact_0.GetLatitude();
				float currentHeading = contact_0.CurrentHeading;
				bool headingIsKnown = contact_0.HeadingIsKnown;
				int int_4 = num6;
				bool speedIsKnown = contact_0.SpeedIsKnown;
				float currentAltitude = contact_0.GetCurrentAltitude();
				bool altitudeIsKnown = contact_0.AltitudeIsKnown;
				float float_4 = Module_Unit.RateTokenizer(contact_0, myUnit.ParentScen);
				Contact_Base.ContactType type = contact_0.Type;
				string string_2 = null;
				tuple = TargetIsWithinDLZ(parentScen2, dBID2, activeUnit_2, longitude2, latitude2, float_3, int_3, longitude3, latitude3, currentHeading, headingIsKnown, int_4, speedIsKnown, currentAltitude, altitudeIsKnown, float_4, type, ref geoPoint_, ref string_2, bool_1, num2, throttle_, int_2, null, null, ref float_, action_0, action_1, assumedDLZTargetBehavior);
				if (assumedDLZTargetBehavior == AssumedDLZTargetBehavior.RunStraightAway && GameGeneral.SpeedUp_NEZ_DLZ)
				{
					weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false);
					if (Scenario.NEZ_DLZ_Cache == null)
					{
						Scenario.NEZ_DLZ_Cache = new ConcurrentDictionary<(float, double, float), (float, double)>();
					}
					KeyValuePair<(float, double, float), (float, double)> keyValuePair2 = new KeyValuePair<(float, double, float), (float, double)>((maximumSpeed, myUnit.DBID, contact_0.ActualUnit.GetCurrentAltitude()), (tuple.Item2, num));
					if (!Scenario.NEZ_DLZ_Cache.Keys.Contains(keyValuePair2.Key))
					{
						Scenario.NEZ_DLZ_Cache.TryAdd(keyValuePair2.Key, keyValuePair2.Value);
						if (DebugNEZ & Debugger.IsAttached)
						{
							string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NEZ_DEBUG.txt");
							object writing = myUnit.ParentScen.writing;
							ObjectFlowControl.CheckForSyncLockOnValueType(writing);
							bool lockTaken = false;
							try
							{
								Monitor.Enter(writing, ref lockTaken);
								if (!File.Exists(path))
								{
									File.Create(path).Close();
									using StreamWriter streamWriter = new StreamWriter(path, append: true);
									streamWriter.WriteLine("RESULT; WEAPON NAME; TARGET; TARGET ALTITUDE; TARGET SPEED AT THIS ALTITUDE; RANGE; TIME");
								}
								string text = "";
								text = ((tuple.Item2 <= 0f) ? ("FAILURE; " + weapon_0.Name + ";" + contact_0.ActualUnit.Name + "; " + contact_0.ActualUnit.GetCurrentAltitude() + ";" + maximumSpeed + "; " + num + "; " + tuple.Item2) : ("SUCCESS; " + weapon_0.Name + ";" + contact_0.ActualUnit.Name + "; " + contact_0.ActualUnit.GetCurrentAltitude() + ";" + maximumSpeed + "; " + num + "; " + tuple.Item2));
								using StreamWriter streamWriter2 = new StreamWriter(path, append: true);
								streamWriter2.WriteLine(text);
							}
							finally
							{
								if (lockTaken)
								{
									Monitor.Exit(writing);
								}
							}
						}
					}
				}
			}
			result = tuple;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 32452390866543698", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public string CanThisWeaponEngageThisTarget_AttemptRetargeting(Weapon weapon_0, Contact contact_0)
	{
		try
		{
			if (Information.IsNothing(contact_0))
			{
				return "目标为空";
			}
			if (weapon_0.IsMissile && weapon_0.IsAAW)
			{
				Contact_Base.ContactType type = contact_0.Type;
				if ((type == Contact_Base.ContactType.Surface || (int)(type - 7) <= 1) && myUnit.Doctrine.GetUseSAMsOnASuW(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value != Doctrine._UseSAMsAgainstShips.Yes)
				{
					return "单元无权对地表目标使用SAM";
				}
			}
			if (weapon_0.MaxTargetSpeed > 0 && contact_0.CurrentSpeed > (float)weapon_0.MaxTargetSpeed * 1.2f)
			{
				return "目标速度(" + Conversions.ToString((int)Math.Round(contact_0.CurrentSpeed)) + "节)远高于武器的最大目标速度（" + Conversions.ToString(weapon_0.MaxTargetSpeed) + " 节)";
			}
			if (!contact_0.IsBallisticTarget() && contact_0.Type != Contact_Base.ContactType.Surface)
			{
				if (!(weapon_0.MaxTargetAlt_AGL <= 0f) && contact_0.GetCurrentAltitude() > weapon_0.MaxTargetAlt_AGL)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude() * 3.28084f)) + "英尺）高于武器的天花板（" + Conversions.ToString((int)Math.Round(weapon_0.MaxTargetAlt_AGL * 3.28084f)) + " 英尺）";
					}
					return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude())) + "米）高于武器的天花板（" + Conversions.ToString(weapon_0.MaxTargetAlt_AGL) + " 米)";
				}
				if (weapon_0.MinTargetAlt_AGL > 0f && contact_0.GetCurrentAltitude() < weapon_0.MinTargetAlt_AGL)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude() * 3.28084f)) + "英尺）低于武器的最低接合高度（" + Conversions.ToString((int)Math.Round(weapon_0.MinTargetAlt_AGL * 3.28084f)) + " 英尺）";
					}
					return "目标高度（" + Conversions.ToString((int)Math.Round(contact_0.GetCurrentAltitude())) + "米）低于武器的最低接合高度（" + Conversions.ToString(weapon_0.MinTargetAlt_AGL) + " 米)";
				}
			}
			if (contact_0.Type == Contact_Base.ContactType.ActivationPoint && !weapon_0.Flags.BearingOnlyLaunch)
			{
				return "武器不具备BOL能力";
			}
			if (!weapon_0.IsNuke.Value && contact_0.Type == Contact_Base.ContactType.Submarine && (weapon_0.Type == Weapon._WeaponType.DepthCharge || weapon_0.Type == Weapon._WeaponType.Rocket) && contact_0.UncertaintyArea != null)
			{
				return "武器需要精确的目标位置";
			}
			Weapon weapon = weapon_0;
			ActiveUnit activeUnit_ = myUnit;
			bool? nullable_ = null;
			if (weapon.QueryReponse(activeUnit_, ref contact_0, ref nullable_))
			{
				float num = ((weapon_0.Type == Weapon._WeaponType.Gun) ? Module_Unit.RangeToUnit_Slant(myUnit, contact_0) : Module_Unit.RangeToUnit_Horiz(myUnit, contact_0));
				if (weapon_0.Type == Weapon._WeaponType.Dispenser && (double)(num * 1852f) > (double)weapon_0.Warheads[0].ClusterBombDispersionAreaLength / 2.0)
				{
					return "目标超出武器范围";
				}
				if (((!weapon_0.IsMissile || !CancelConsumer(weapon_0, contact_0) || contact_0.CurrentSpeed == 0f) ? weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) : ((contact_0.Type == Contact_Base.ContactType.Surface) ? weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) : ((float)((double)weapon_0.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) * 1.5)))) < num)
				{
					return "目标超出武器范围";
				}
				if (contact_0.Type == Contact_Base.ContactType.ActivationPoint)
				{
					return "OK";
				}
				if (Information.IsNothing(contact_0.ActualUnit))
				{
					return "单元消失了";
				}
				if (contact_0.ActualUnit.IsShip || contact_0.ActualUnit.IsFacility || contact_0.ActualUnit.IsSubmarine)
				{
					string text = IsWeaponSuitableForTargetAmbiguity(weapon_0, contact_0);
					if (string.CompareOrdinal(text, "OK") != 0)
					{
						return text;
					}
				}
				if (!contact_0.IsFirm && !weapon_0.CanBeFiredOnAmbigousTarget(contact_0, bool_0: false))
				{
					return "武器无法攻击不精确的目标";
				}
				Lazy<Dictionary<int, EmissionContainer>> lazy_ = new Lazy<Dictionary<int, EmissionContainer>>();
				if (weapon_0.Guidance == Weapon.WeaponGuidanceType.Passive)
				{
					Sensor obj = weapon_0.Sensors_ReadOnly()[0];
					Weapon activeUnit_2 = weapon_0;
					ActiveUnit actualUnit = contact_0.ActualUnit;
					List<Geopoint_Struct> list_ = null;
					nullable_ = null;
					bool? nullable_7 = null;
					Module_Unit.Unit.LOSCheckResult? nullable_8 = null;
					bool? nullable_9 = null;
					bool? nullable_10 = null;
					bool? nullable_11 = null;
					if (!obj.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, activeUnit_2, actualUnit, ref list_, num, ref lazy_, null, ref nullable_, ref nullable_7, ref nullable_8, ref nullable_9, ref nullable_10, ref nullable_11))
					{
						return "武器必须在射击前检测目标";
					}
				}
				if (weapon_0.Flags.IlluminateAtLaunch || weapon_0.Flags.TerminalIllumination)
				{
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					List<Sensor> list = new List<Sensor>();
					Sensor[] array = myUnit.Sensors_ReadOnly();
					Sensor[] array3 = array;
					foreach (Sensor sensor in array3)
					{
						if (sensor.Status == PlatformComponent._ComponentStatus.Operational && sensor.CanIlluminateForThisWeapon(ref weapon_0))
						{
							list.Add(sensor);
						}
					}
					Sensor expression = null;
					if (list.Count > 0)
					{
						flag = true;
						List<Sensor> list2 = new List<Sensor>();
						foreach (Sensor item in list)
						{
							if (weapon_0.Guidance == Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive)
							{
								list2.Add(item);
							}
							else if (item.TargetsTrackedForFireControl_Readonly.Count < item.MaxIlluminate || item.IsTrackingThisTargetForFireControl(ref contact_0))
							{
								list2.Add(item);
							}
						}
						if (list2.Count > 0)
						{
							flag2 = true;
							new List<Sensor>();
							Module_Unit.Unit.LOSCheckResult? nullable_12 = null;
							bool? nullable_13 = null;
							bool? nullable_14 = null;
							bool? nullable_2 = null;
							float float_ = Module_Unit.RangeToUnit_Slant(myUnit, contact_0);
							List<ActiveUnit> list3 = null;
							foreach (Sensor item2 in list2)
							{
								if (item2.Type == Sensor.Sensor_Type.Radar && Information.IsNothing(list3))
								{
									list3 = myUnit.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
								}
								if (item2.CanIlluminateTarget(myUnit, ref contact_0, ref myUnit.ParentScen, float_, list3, myUnit.IsShip, bool_1: false, ref nullable_13, ref nullable_14, ref nullable_12, ref nullable_2) == Sensor.SensorDetectionCheckResult.Success)
								{
									expression = item2;
									flag3 = true;
									break;
								}
							}
						}
					}
					if ((!flag || !flag2 || !flag3) && weapon_0.Flags.SupportsBuddyIllumination)
					{
						List<ActiveUnit> list4 = weapon_0.FetchAvailableBuddyIlluminatorUnits(myUnit.GetUnitSide(), contact_0);
						Sensor sensor_ = null;
						foreach (ActiveUnit item3 in list4)
						{
							if (!Information.IsNothing(item3))
							{
								ActiveUnit_Sensory sensory = item3.Sensory;
								Contact contact_ = contact_0;
								Weapon weapon_ = weapon_0;
								bool? nullable_3 = null;
								bool? nullable_4 = null;
								Module_Unit.Unit.LOSCheckResult? nullable_5 = null;
								bool? nullable_6 = null;
								if (sensory.CanIlluminateThisContactForThisWeapon(contact_, weapon_, ref sensor_, ref nullable_3, ref nullable_4, ref nullable_5, ref nullable_6))
								{
									expression = sensor_;
								}
							}
						}
					}
					if (Information.IsNothing(expression))
					{
						if (!flag)
						{
							return "没有武器引导器能够照射目标";
						}
						if (!flag2)
						{
							return "适用于此武器的所有照射通道均在使用中";
						}
						if (!flag3)
						{
							return "所有引导器都无法照射这个目标（由于反射不充分，没有视线等原因）";
						}
					}
				}
				if (weapon_0.Guidance == Weapon.WeaponGuidanceType.BeamRiding)
				{
					bool flag4 = false;
					bool flag5 = false;
					Sensor[] array2 = myUnit.Sensors_ReadOnly();
					Sensor[] array4 = array2;
					foreach (Sensor sensor2 in array4)
					{
						if (sensor2.Status == PlatformComponent._ComponentStatus.Operational && sensor2.CanIlluminateForThisWeapon(ref weapon_0))
						{
							flag4 = true;
							if (sensor2.TargetsTrackedForFireControl_Readonly.Count < sensor2.MaxIlluminate || sensor2.IsTrackingThisTargetForFireControl(ref contact_0))
							{
								flag5 = true;
							}
						}
					}
					if (!flag4)
					{
						return "没有武器引导器能够照射目标";
					}
					if (!flag5)
					{
						return "适用于此武器的所有照射通道均在使用中";
					}
				}
				float num2 = (myUnit.IsAircraft ? myUnit.CurrentHeading : 0f);
				GeoPoint geoPoint_ = null;
				if (CancelConsumer(weapon_0, contact_0))
				{
					Tuple<int, string> key = new Tuple<int, string>(weapon_0.DBID, contact_0.ObjectID);
					if (DLZ_ResultsCache != null && DLZ_ResultsCache.ContainsKey(key))
					{
						if (DLZ_ResultsCache[key].Item1 != DLZResultEnum.Success)
						{
							return DLZ_ResultsCache[key].ToString();
						}
					}
					else
					{
						Tuple<DLZResultEnum, float> tuple;
						if (contact_0.IsBallisticTarget())
						{
							Scenario parentScen = myUnit.ParentScen;
							int dBID = weapon_0.DBID;
							ActiveUnit activeUnit_3 = myUnit;
							double longitude = myUnit.GetLongitude();
							double latitude = myUnit.GetLatitude();
							float float_2 = (int)Math.Round(myUnit.GetCurrentAltitude());
							int int_ = (int)Math.Round(myUnit.CurrentSpeed);
							Contact contact_2 = contact_0;
							GeoPoint geoPoint_2 = null;
							string string_ = "";
							float float_3 = 0f;
							tuple = TargetIsWithinDLZ_BallisticTarget(parentScen, dBID, activeUnit_3, longitude, latitude, float_2, int_, contact_2, num2, ActiveUnit.Throttle.Cruise, ref geoPoint_2, ref string_, null, null, ref float_3);
						}
						else if (contact_0.IsOrbitalContact)
						{
							Scenario parentScen2 = myUnit.ParentScen;
							int dBID2 = weapon_0.DBID;
							ActiveUnit activeUnit_4 = myUnit;
							double longitude2 = myUnit.GetLongitude();
							double latitude2 = myUnit.GetLatitude();
							float float_4 = (int)Math.Round(myUnit.GetCurrentAltitude());
							int int_2 = (int)Math.Round(myUnit.CurrentSpeed);
							Contact contact_3 = contact_0;
							float float_5 = 0f;
							tuple = TargetIsWithinDLZ_OrbitalTarget(parentScen2, dBID2, activeUnit_4, longitude2, latitude2, float_4, int_2, contact_3, 0f, ActiveUnit.Throttle.Cruise, ref float_5);
						}
						else
						{
							Scenario parentScen3 = myUnit.ParentScen;
							int dBID3 = weapon_0.DBID;
							ActiveUnit activeUnit_5 = myUnit;
							double longitude3 = myUnit.GetLongitude();
							double latitude3 = myUnit.GetLatitude();
							float float_6 = (int)Math.Round(myUnit.GetCurrentAltitude());
							int int_3 = (int)Math.Round(myUnit.CurrentSpeed);
							double longitude4 = contact_0.GetLongitude();
							double latitude4 = contact_0.GetLatitude();
							float currentHeading = contact_0.CurrentHeading;
							bool headingIsKnown = contact_0.HeadingIsKnown;
							int int_4 = (int)Math.Round(contact_0.CurrentSpeed);
							bool speedIsKnown = contact_0.SpeedIsKnown;
							float currentAltitude = contact_0.GetCurrentAltitude();
							bool altitudeIsKnown = contact_0.AltitudeIsKnown;
							float float_7 = Module_Unit.RateTokenizer(contact_0, myUnit.ParentScen);
							Contact_Base.ContactType type2 = contact_0.Type;
							string string_2 = null;
							int int_5 = (int)Math.Round((double)(float)weapon_0.Fuel_ReadOnly[0].MaxQuantity * 0.8999999985098839);
							float float_8 = 0f;
							tuple = TargetIsWithinDLZ(parentScen3, dBID3, activeUnit_5, longitude3, latitude3, float_6, int_3, longitude4, latitude4, currentHeading, headingIsKnown, int_4, speedIsKnown, currentAltitude, altitudeIsKnown, float_7, type2, ref geoPoint_, ref string_2, bool_4: false, num2, ActiveUnit.Throttle.Cruise, int_5, null, null, ref float_8);
						}
						if (DLZ_ResultsCache == null)
						{
							DLZ_ResultsCache = new ConcurrentDictionary<Tuple<int, string>, Tuple<DLZResultEnum, float>>();
						}
						DLZ_ResultsCache.TryAdd(key, tuple);
						if (tuple.Item1 != DLZResultEnum.Success)
						{
							return TokenizerDefinitionSpec.ResolveTokenizer(tuple.Item1);
						}
					}
				}
				if (weapon_0.ValidTargets.Radar)
				{
					if (weapon_0.IsDualModeARM)
					{
						if (!contact_0.IsPreciselyLocatedOnThisPulse)
						{
							return "Target is not radiating, and lacking a precise location to launch dual mode ARM in INS/GPS mode.";
						}
					}
					else
					{
						if (!contact_0.HasDetectedEmissions)
						{
							return "目标不是辐射目标";
						}
						Weapon weapon2 = weapon_0;
						ObservableDictionary<int, EmissionContainer> detectedEmissions = contact_0.DetectedEmissions;
						Side unitSide = myUnit.GetUnitSide();
						Contact contact_4 = contact_0;
						LockRandom lockRandom_ = GameGeneral.LockRandom_0;
						if (!weapon2.ARM_DetermineEmissionToTrack(detectedEmissions, unitSide, contact_4, bool_0: false, ref lockRandom_))
						{
							return "目前没有威胁发射器正在辐射";
						}
					}
				}
				return "OK";
			}
			return "武器不适合这个目标";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100307", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "发生了错误";
		}
	}

	private List<Sensor> StopConsumer(Mount mount_0, Contact contact_0)
	{
		List<Sensor> list = new List<Sensor>();
		Module_Unit.Unit.LOSCheckResult? nullable_ = null;
		bool? nullable_2 = null;
		bool? nullable_3 = null;
		bool? nullable_4 = null;
		bool? nullable_5 = null;
		bool? nullable_6 = null;
		List<Sensor> result = null;
		try
		{
			List<ActiveUnit> list2 = null;
			Sensor[] array = myUnit.Sensors_ReadOnly();
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				if (sensor.Status == PlatformComponent._ComponentStatus.Operational && mount_0.CompatibleDirectors.Contains(sensor.DBID) && (sensor.HasFireControlChannelAvailable() || sensor.TargetsTrackedForFireControl_Readonly.Contains(contact_0)))
				{
					if (sensor.Type == Sensor.Sensor_Type.Radar && Information.IsNothing(list2))
					{
						list2 = myUnit.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
					}
					ActiveUnit activeUnit_ = myUnit;
					ActiveUnit actualUnit = contact_0.ActualUnit;
					List<Geopoint_Struct> list_ = null;
					float float_ = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
					Lazy<Dictionary<int, EmissionContainer>> lazy_ = null;
					if (sensor.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, activeUnit_, actualUnit, ref list_, float_, ref lazy_, list2, ref nullable_2, ref nullable_3, ref nullable_, ref nullable_4, ref nullable_5, ref nullable_6))
					{
						list.Add(sensor);
					}
				}
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100308", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private bool CancelConsumer(Weapon weapon_0, Contact contact_0)
	{
		bool result = false;
		try
		{
			switch (weapon_0.Type)
			{
			default:
				result = false;
				return false;
			case Weapon._WeaponType.RV:
				result = true;
				return true;
			case Weapon._WeaponType.Torpedo:
				result = true;
				return true;
			case Weapon._WeaponType.GuidedWeapon:
			{
				if (weapon_0.IsBallisticMissile && weapon_0.HasRVs.Value)
				{
					result = false;
					return false;
				}
				if (weapon_0.IsLongFlightCruiseMissile)
				{
					result = false;
					return false;
				}
				Contact_Base.ContactType type = contact_0.Type;
				if ((int)type > 1 && type != Contact_Base.ContactType.Orbital)
				{
					if (weapon_0.Flags.IsBallisticMissile && weapon_0.Warheads.Length != 0 && weapon_0.Warheads[0].Type == Warhead.WarheadType.Weapon)
					{
						result = false;
						return false;
					}
					if (myUnit.IsAircraft)
					{
						result = true;
						return true;
					}
					if (weapon_0.IsAAW)
					{
						Contact_Base.ContactType type2 = contact_0.Type;
						if (type2 == Contact_Base.ContactType.Surface || (int)(type2 - 7) <= 1)
						{
							result = true;
							return true;
						}
					}
					result = false;
					return false;
				}
				result = true;
				return true;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100309", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void ResolvePointDefence(float float_0, ref Weapon weapon_0)
	{
		if (!(weapon_0.AddDescriptor() <= 0f))
		{
			return;
		}
		List<string> list_ = new List<string>();
		PointDefenceResult pointDefenceResult = PointDefenceResult.Undefined;
		int num = 0;
		int num2 = 0;
		bool flag = false;
		try
		{
			Sensor[] array;
			if (weapon_0.Sensors_ReadOnly().Length != 0)
			{
				array = weapon_0.Sensors_ReadOnly();
				Sensor[] array4 = array;
				foreach (Sensor sensor in array4)
				{
					if (sensor.Type == Sensor.Sensor_Type.ESM)
					{
						if (!weapon_0.ValidTargets.Radar)
						{
							continue;
						}
					}
					else if (sensor.Type == Sensor.Sensor_Type.ECM || !sensor.GetIsSuitableForThisTarget(myUnit))
					{
						continue;
					}
					num2++;
				}
			}
			if (weapon_0.Sensors_ReadOnly().Length != 0 || weapon_0.Guidance == Weapon.WeaponGuidanceType.TVM)
			{
				bool hasLaserSpotTracker = weapon_0.HasLaserSpotTracker;
				bool flag2 = false;
				if (hasLaserSpotTracker)
				{
					Sensor[] array2 = weapon_0.AI.PrimaryTarget.ActualUnit.Sensors_ReadOnly();
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						if (array2[i].Role == Sensor.Sensor_Role.ESM_LWR)
						{
							flag2 = true;
						}
					}
				}
				if (weapon_0.AI.PrimaryTarget.ActualUnit.GetUnitSide().AwakeOrder(weapon_0) || (hasLaserSpotTracker && flag2))
				{
					List<PrototypeCallbackCandidate> list = new List<PrototypeCallbackCandidate>();
					foreach (Mount mount in myUnit.Mounts)
					{
						Mount mount_ = mount;
						if (mount_.Status != 0 || !(mount_.TimeToFire <= 1f))
						{
							continue;
						}
						foreach (WeaponRec mountWeapon in mount_.MountWeapons)
						{
							WeaponRec weaponRec_ = mountWeapon;
							if (weaponRec_.CurrentLoad > 0)
							{
								weaponRec_.ParentMount = mount_;
								if (VerifyConsumer(weaponRec_, mount_, weapon_0))
								{
									ActiveUnit activeUnit_ = myUnit;
									ActiveUnit activeUnit_2 = weapon_0;
									PrototypeCallbackCandidate item = new PrototypeCallbackCandidate(ref float_0, activeUnit_, ref weaponRec_, ref activeUnit_2, ref mount_);
									list.Add(item);
								}
							}
						}
					}
					if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
						for (int j = 0; j < weapons.Length; j = checked(j + 1))
						{
							WeaponRec weaponRec_2 = weapons[j];
							if (weaponRec_2.CurrentLoad <= 0)
							{
								continue;
							}
							Weapon referenceWeapon = weaponRec_2.GetReferenceWeapon(myUnit.ParentScen);
							if (referenceWeapon.IsSensorPod)
							{
								foreach (WeaponRec weaponWeapon in referenceWeapon.WeaponWeapons)
								{
									WeaponRec weaponRec_3 = weaponWeapon;
									if (weaponRec_3.CurrentLoad > 0 && ListConsumer(weaponRec_3, weapon_0))
									{
										ActiveUnit activeUnit_3 = myUnit;
										ActiveUnit activeUnit_4 = weapon_0;
										Mount mount_2 = null;
										PrototypeCallbackCandidate item2 = new PrototypeCallbackCandidate(ref float_0, activeUnit_3, ref weaponRec_3, ref activeUnit_4, ref mount_2);
										list.Add(item2);
									}
								}
							}
							else if (ListConsumer(weaponRec_2, weapon_0))
							{
								ActiveUnit activeUnit_5 = myUnit;
								ActiveUnit activeUnit_6 = weapon_0;
								Mount mount_3 = null;
								PrototypeCallbackCandidate item3 = new PrototypeCallbackCandidate(ref float_0, activeUnit_5, ref weaponRec_2, ref activeUnit_6, ref mount_3);
								list.Add(item3);
							}
						}
					}
					if (list.Count > 0)
					{
						flag = true;
						IEnumerable<PrototypeCallbackCandidate> enumerable = from theE in list
							select (theE) into prototypeCallbackCandidate_0
							orderby ((WeaponRec)prototypeCallbackCandidate_0.m_ClassComparator).GetReferenceWeapon(myUnit.ParentScen).OrderReponse() descending
							select prototypeCallbackCandidate_0;
						HashSet<int> hashSet_ = new HashSet<int>();
						Contact contact = null;
						foreach (Contact contacts_ in myUnit.GetUnitSide().Contacts_List)
						{
							if (contacts_.ActualUnit == weapon_0)
							{
								contact = contacts_;
								break;
							}
						}
						foreach (PrototypeCallbackCandidate item4 in enumerable)
						{
							ref object classComparator = ref item4.m_ClassComparator;
							Contact contact_ = contact;
							int int_ = 0;
							MapConsumer(ref Unsafe.As<object, WeaponRec>(ref classComparator), contact_, ref list_, ref int_, hashSet_);
							if (item4._ValueComparator == null)
							{
								continue;
							}
							if (((WeaponRec)item4.m_ClassComparator).CurrentLoad == 0)
							{
								object valueComparator = item4._ValueComparator;
								int_ = 0;
								int int_2 = 0;
								if (((Mount)valueComparator).RegisterTokenizer(ref int_, ref int_2) == 0)
								{
									((Mount)item4._ValueComparator).TimeToReloadAttempt = 0f;
									continue;
								}
							}
							if (((Mount)item4._ValueComparator).TimeToReloadAttempt < 300f)
							{
								((Mount)item4._ValueComparator).TimeToReloadAttempt = ((Mount)item4._ValueComparator).TimeToFire + 300f;
							}
						}
					}
				}
			}
			Sensor sensor_ = null;
			if (weapon_0.Sensors_ReadOnly().Length == 0)
			{
				if (weapon_0.Guidance == Weapon.WeaponGuidanceType.TVM)
				{
					sensor_ = weapon_0.SensorProvidingFireControlForMe;
					if (sensor_ == null)
					{
						string string_ = "没有雷达为武器提供引导：" + weapon_0.Name + " (" + weapon_0.UnitClass + "） - 不能影响";
						myUnit.ParentScen.AddMessage(string_, weapon_0.Name + " 未命中（无导航）", LoggedMessage.MessageType.WeaponEndgame, 1, myUnit.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					else if (sensor_.IsNeutralized.GetValueOrDefault())
					{
						string string_2 = "为TVM/SAGG指导武器提供引导的雷达被干扰 - 无法命中目标";
						myUnit.ParentScen.AddMessage(string_2, weapon_0.Name + " 被干扰", LoggedMessage.MessageType.WeaponEndgame, 1, myUnit.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						if (weapon_0.Flags.ReAttack_Capability)
						{
							list_?.Add("武器将重新攻击目标");
							ExportResolvePointDefence(weapon_0, myUnit, PointDefenceResult.WeaponDefeated, list_);
							weapon_0.PrepareForReattack(myUnit);
							return;
						}
						weapon_0.ParentScen.DestroyThisUnit(weapon_0, "为TVM/SAGG指导武器提供引导的雷达被干扰 - 无法命中目标", "Spoofed");
					}
				}
			}
			else
			{
				array = weapon_0.Sensors_ReadOnly();
				Sensor[] array5 = array;
				foreach (Sensor sensor2 in array5)
				{
					if (sensor2.Type == Sensor.Sensor_Type.ESM)
					{
						if (!weapon_0.ValidTargets.Radar)
						{
							continue;
						}
					}
					else if (sensor2.Type == Sensor.Sensor_Type.ECM || !sensor2.GetIsSuitableForThisTarget(myUnit))
					{
						continue;
					}
					if (sensor2.IsNeutralized.GetValueOrDefault())
					{
						num++;
					}
				}
				if (num >= num2 && num2 > 0)
				{
					string string_3 = "武器的所有传感器都被欺骗 - 武器错过了目标";
					myUnit.ParentScen.AddMessage(string_3, weapon_0.Name + " 被干扰", LoggedMessage.MessageType.WeaponEndgame, 1, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					if (weapon_0.Flags.ReAttack_Capability)
					{
						myUnit.ParentScen.AddMessage("武器：" + weapon_0.Name + " 将重新攻击", "武器将重新攻击目标", LoggedMessage.MessageType.WeaponEndgame, 1, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						list_?.Add("武器：" + weapon_0.Name + " 将重新攻击");
						ExportResolvePointDefence(weapon_0, myUnit, PointDefenceResult.WeaponDefeated, list_);
						weapon_0.PrepareForReattack(myUnit);
						return;
					}
					weapon_0.ParentScen.DestroyThisUnit(weapon_0, "Weapon missed target and does not have ReAttack Capability", "Missed");
				}
			}
			if (myUnit.ParentScen.MorituriUnits.Contains(weapon_0))
			{
				pointDefenceResult = PointDefenceResult.WeaponDefeated;
			}
			if (pointDefenceResult != PointDefenceResult.WeaponDefeated)
			{
				if (weapon_0.Sensors_ReadOnly().Length == 0)
				{
					if (weapon_0.Guidance == Weapon.WeaponGuidanceType.TVM)
					{
						sensor_ = weapon_0.SensorProvidingFireControlForMe;
						if (sensor_ != null)
						{
							bool? isNeutralized = sensor_.IsNeutralized;
							if (((!isNeutralized) ?? isNeutralized).GetValueOrDefault())
							{
								array = myUnit.Sensors_ReadOnly();
								Sensor[] array6 = array;
								foreach (Sensor sensor3 in array6)
								{
									if (sensor3.IsDECM && sensor3.GetCanSpoofThisSensor(sensor_))
									{
										flag = true;
										if (sensor3.PointDefenceJam(ref sensor_, ref myUnit, list_))
										{
											sensor_.IsNeutralized = true;
											string string_4 = "为TVM/SAGG指导武器提供引导的雷达被干扰 - 无法命中目标";
											myUnit.ParentScen.AddMessage(string_4, weapon_0.Name + " 被干扰", LoggedMessage.MessageType.WeaponEndgame, 1, myUnit.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
											list_?.Add("为TVM/SAGG指导武器提供引导的雷达被干扰 - 无法命中目标");
											break;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					Sensor[] array3 = weapon_0.Sensors_ReadOnly();
					for (int k = 0; k < array3.Length; k = checked(k + 1))
					{
						Sensor sensor_2 = array3[k];
						if (sensor_2.IsNeutralized.GetValueOrDefault())
						{
							continue;
						}
						if (sensor_2.Type == Sensor.Sensor_Type.ESM)
						{
							if (!weapon_0.ValidTargets.Radar)
							{
								continue;
							}
						}
						else if (sensor_2.Type == Sensor.Sensor_Type.ECM || !sensor_2.GetIsSuitableForThisTarget(myUnit))
						{
							continue;
						}
						new HashSet<int>();
						array = myUnit.Sensors_ReadOnly();
						Sensor[] array7 = array;
						foreach (Sensor sensor4 in array7)
						{
							if (sensor4.IsDECM && sensor4.GetCanSpoofThisSensor(sensor_2))
							{
								flag = true;
								if (sensor4.PointDefenceJam(ref sensor_2, ref myUnit, list_))
								{
									num++;
									sensor_2.IsNeutralized = true;
								}
							}
						}
					}
				}
				if (weapon_0.Sensors_ReadOnly().Length == 0)
				{
					if (!Information.IsNothing(sensor_) && sensor_.IsNeutralized.GetValueOrDefault())
					{
						ExportResolvePointDefence(weapon_0, myUnit, PointDefenceResult.WeaponDefeated, list_);
					}
					else
					{
						if (flag)
						{
							list_.Add("Point defence systems on " + myUnit.Name + " defeated by weapon " + weapon_0.Name);
						}
						else
						{
							list_.Add("No point defence systems employed by " + myUnit.Name + " against weapon " + weapon_0.Name);
						}
						ExportResolvePointDefence(weapon_0, myUnit, PointDefenceResult.WeaponSurvived, list_);
						Weapon obj = weapon_0;
						ActiveUnit activeUnit_7 = myUnit;
						Scenario parentScen = myUnit.ParentScen;
						List<string> list_2 = null;
						obj.ResolveImpact(activeUnit_7, parentScen, bool_0: false, ref list_2);
					}
				}
				else if (num >= num2 && num2 > 0)
				{
					string string_5 = "武器的所有传感器都被欺骗 - 武器错过了目标";
					myUnit.ParentScen.AddMessage(string_5, weapon_0.Name + " 被干扰", LoggedMessage.MessageType.WeaponEndgame, 1, myUnit.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					list_?.Add("武器的所有传感器都被欺骗 - 武器错过了目标");
					ExportResolvePointDefence(weapon_0, myUnit, PointDefenceResult.WeaponDefeated, list_);
					if (weapon_0.Flags.ReAttack_Capability)
					{
						list_?.Add("武器将重新攻击目标");
						ExportResolvePointDefence(weapon_0, myUnit, PointDefenceResult.WeaponDefeated, list_);
						weapon_0.PrepareForReattack(myUnit);
						return;
					}
					weapon_0.ParentScen.DestroyThisUnit(weapon_0, "武器的所有传感器都被欺骗 - 武器错过了目标", "Spoofed");
				}
				else
				{
					if (num > 0)
					{
						string string_6 = "只有" + Conversions.ToString(num) + "个（共" + Conversions.ToString(num2) + "个）武器传感器被欺骗";
						myUnit.ParentScen.AddMessage(string_6, "尝试干扰" + weapon_0.Name + " 失败", LoggedMessage.MessageType.WeaponEndgame, 1, myUnit.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						list_?.Add("只有" + Conversions.ToString(num) + "个（共" + Conversions.ToString(num2) + "个）武器传感器被欺骗");
					}
					if (flag)
					{
						list_.Add("Point defence systems on " + myUnit.Name + " defeated by weapon " + weapon_0.Name);
					}
					else
					{
						list_.Add("No point defence systems employed by " + myUnit.Name + " against weapon " + weapon_0.Name);
					}
					ExportResolvePointDefence(weapon_0, myUnit, PointDefenceResult.WeaponSurvived, list_);
					Weapon obj2 = weapon_0;
					ActiveUnit activeUnit_8 = myUnit;
					Scenario parentScen2 = myUnit.ParentScen;
					List<string> list_3 = null;
					obj2.ResolveImpact(activeUnit_8, parentScen2, bool_0: false, ref list_3);
				}
			}
			if (weapon_0.Guidance == Weapon.WeaponGuidanceType.TVM)
			{
				if (sensor_ != null && sensor_.IsNeutralized.HasValue)
				{
					sensor_.IsNeutralized = null;
				}
				return;
			}
			array = weapon_0.Sensors_ReadOnly();
			Sensor[] array8 = array;
			foreach (Sensor sensor5 in array8)
			{
				if (sensor5.IsNeutralized.HasValue)
				{
					sensor5.IsNeutralized = null;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100310", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportResolvePointDefence(Weapon weapon_0, Module_Unit.Unit unit_0, PointDefenceResult pointDefenceResult_0, List<string> list_0)
	{
		try
		{
			foreach (IEventExporter applicableEventExporter in weapon_0.ParentScen.ApplicableEventExporters)
			{
				if (!applicableEventExporter.IsOperating || !applicableEventExporter.ExportWeaponEndgame)
				{
					continue;
				}
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (weapon_0.ParentScen.MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(weapon_0.ParentScen.Title, typeof(string), 500));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(weapon_0.ParentScen.MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(weapon_0.ParentScen.TimelineID, typeof(string), 40));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(weapon_0.ParentScen.Time.Subtract(weapon_0.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(weapon_0.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + weapon_0.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(weapon_0.ObjectID, typeof(string), 40));
				dictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(weapon_0.Name, typeof(string), 500));
				dictionary.Add("WeaponSide", new IEventExporter.EventNotificationParameter(weapon_0.GetUnitSide().Name, typeof(string), 500));
				if (Information.IsNothing(weapon_0.FiringParent))
				{
					dictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					dictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				else
				{
					dictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter(weapon_0.FiringParent.ObjectID, typeof(string), 40));
					dictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter(weapon_0.FiringParent.Name, typeof(string), 500));
				}
				if (Information.IsNothing(unit_0))
				{
					dictionary.Add("TargetID", new IEventExporter.EventNotificationParameter("-", typeof(string)));
					dictionary.Add("TargetName", new IEventExporter.EventNotificationParameter("-", typeof(string)));
					dictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter("-", typeof(string)));
					dictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter("-", typeof(double)));
					dictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter("-", typeof(double)));
					dictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter("-", typeof(float)));
					dictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter("-", typeof(float)));
				}
				else
				{
					dictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(unit_0.ObjectID, typeof(string), 40));
					dictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(unit_0.Name, typeof(string), 500));
					if (Information.IsNothing(unit_0.GetUnitSide()))
					{
						dictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
					}
					else
					{
						dictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(unit_0.GetUnitSide().Name, typeof(string), 500));
					}
					dictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(unit_0.GetLongitude(), typeof(double)));
					dictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(unit_0.GetLatitude(), typeof(double)));
					dictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(unit_0.GetCurrentAltitude(), typeof(float)));
					dictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(unit_0.CurrentAltitude_AGL, typeof(float)));
				}
				if (Information.IsNothing(weapon_0.FiringParent))
				{
					dictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
				}
				else
				{
					dictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Horiz(weapon_0, weapon_0.FiringParent), typeof(float)));
				}
				switch (pointDefenceResult_0)
				{
				case PointDefenceResult.Undefined:
					dictionary.Add("Result", new IEventExporter.EventNotificationParameter("UNDEFINED", typeof(string), 20));
					break;
				case PointDefenceResult.WeaponDefeated:
					dictionary.Add("Result", new IEventExporter.EventNotificationParameter("POINTDEF:SUCCESS", typeof(string), 20));
					break;
				case PointDefenceResult.WeaponSurvived:
					dictionary.Add("Result", new IEventExporter.EventNotificationParameter("POINTDEF:FAILURE", typeof(string), 20));
					break;
				}
				if (Information.IsNothing(list_0.Count == 0))
				{
					dictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				}
				else
				{
					dictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(string.Join("|", list_0), typeof(string)));
				}
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponEndgame, dictionary, weapon_0.ParentScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10123453204592340", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool VerifyConsumer(WeaponRec weaponRec_0, Mount mount_0, Weapon weapon_0)
	{
		try
		{
			switch (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type)
			{
			case Weapon._WeaponType.Microwave:
				return false;
			case Weapon._WeaponType.Laser:
				return false;
			case Weapon._WeaponType.GuidedWeapon:
				return false;
			case Weapon._WeaponType.Rocket:
				return false;
			default:
				if (mount_0.Status == PlatformComponent._ComponentStatus.Operational)
				{
					if (weaponRec_0.CurrentLoad == 0)
					{
						return false;
					}
					Weapon referenceWeapon = weaponRec_0.GetReferenceWeapon(myUnit.ParentScen);
					float num = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), weapon_0.GetLatitude(), weapon_0.GetLongitude());
					float num2 = ((weapon_0.Type == Weapon._WeaponType.Torpedo) ? referenceWeapon.MinSubsurfaceRange : referenceWeapon.MinAirRange);
					if (num < num2)
					{
						return false;
					}
					if (!mount_0.IsAutonomous && !mount_0.IsCountermeasuresDispenser)
					{
						return false;
					}
					if (referenceWeapon.Type != Weapon._WeaponType.Decoy_Expendable && referenceWeapon.Type != Weapon._WeaponType.Decoy_Towed)
					{
						if (weaponRec_0.TimeToFire > 0f)
						{
							return false;
						}
					}
					else if (weaponRec_0.TimeToFire > 1f)
					{
						return false;
					}
					if (mount_0.TimeToFire <= 0f)
					{
						if (ResolveConsumer(weaponRec_0, weapon_0))
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			case Weapon._WeaponType.Gun:
				return false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100311", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ListConsumer(WeaponRec weaponRec_0, Weapon weapon_0)
	{
		try
		{
			float num = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), weapon_0.GetLatitude(), weapon_0.GetLongitude());
			if (weaponRec_0.CurrentLoad == 0)
			{
				return false;
			}
			if (num < weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).MinAirRange)
			{
				return false;
			}
			if (ResolveConsumer(weaponRec_0, weapon_0))
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100312", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ResolveConsumer(WeaponRec weaponRec_0, Weapon weapon_0)
	{
		bool flag = false;
		try
		{
			Weapon referenceWeapon = weaponRec_0.GetReferenceWeapon(myUnit.ParentScen);
			if (referenceWeapon.IsDecoy)
			{
				if (referenceWeapon.Type != Weapon._WeaponType.Decoy_Vehicle && referenceWeapon.Type != Weapon._WeaponType.UAV_Expendable)
				{
					bool flag2 = false;
					switch (weapon_0.AI.PrimaryTarget.Type)
					{
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						flag2 = referenceWeapon.ValidTargets.Aircraft;
						break;
					case Contact_Base.ContactType.Surface:
						flag2 = referenceWeapon.ValidTargets.SurfaceVessel;
						break;
					case Contact_Base.ContactType.Submarine:
						flag2 = referenceWeapon.ValidTargets.Submarine;
						break;
					case Contact_Base.ContactType.Facility_Fixed:
						flag2 = referenceWeapon.ValidTargets.LandStructure_Soft || referenceWeapon.ValidTargets.LandStructure_Hard;
						break;
					case Contact_Base.ContactType.Facility_Mobile:
						flag2 = referenceWeapon.ValidTargets.MobileTarget_Soft || referenceWeapon.ValidTargets.MobileTarget_Hard;
						break;
					}
					if (flag2)
					{
						bool flag3 = false;
						if (weapon_0.Guidance == Weapon.WeaponGuidanceType.TVM)
						{
							if (referenceWeapon.IsRadarCountermeasure)
							{
								flag3 = true;
							}
						}
						else if (weapon_0.HasInfraredSensor)
						{
							if (referenceWeapon.Boolean_0)
							{
								flag3 = true;
							}
						}
						else if (weapon_0.HasLaserSpotTracker)
						{
							if (referenceWeapon.IsSmokeGrenade)
							{
								flag3 = true;
							}
						}
						else
						{
							Sensor[] array = weapon_0.Sensors_ReadOnly();
							Sensor[] array2 = array;
							foreach (Sensor sensor in array2)
							{
								if (sensor.IsSonar)
								{
									if (referenceWeapon.IsSonarCountermeasure)
									{
										flag3 = true;
									}
									continue;
								}
								switch (sensor.Type)
								{
								case Sensor.Sensor_Type.Radar:
								case Sensor.Sensor_Type.SemiActive:
									if (referenceWeapon.IsRadarCountermeasure)
									{
										flag3 = true;
									}
									break;
								case Sensor.Sensor_Type.Visual:
									if (referenceWeapon.IsVisualCountermeasure)
									{
										flag3 = true;
									}
									break;
								case Sensor.Sensor_Type.Infrared:
									if (referenceWeapon.Boolean_0)
									{
										flag3 = true;
									}
									break;
								}
							}
						}
						if (flag3)
						{
							flag = true;
							return true;
						}
						flag = false;
						return false;
					}
					flag = false;
					return false;
				}
				flag = false;
				return false;
			}
			Weapon._WeaponType type = weapon_0.Type;
			if (1 == 0)
			{
			}
			bool result = type switch
			{
				Weapon._WeaponType.Torpedo => flag = referenceWeapon.ValidTargets.Torpedo, 
				Weapon._WeaponType.GuidedWeapon => flag = referenceWeapon.ValidTargets.Missile && !weapon_0.ValidTargets.Aircraft && !weapon_0.ValidTargets.Missile, 
				_ => flag, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100313", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return flag;
		}
	}

	public int HowManyOfThisWeapon(int int_0)
	{
		int num = 0;
		foreach (Mount mount in myUnit.Mounts)
		{
			num += myUnit.Weaponry.HowManyOfThisWeaponOnMountTotal(mount, int_0);
			num += myUnit.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount, int_0);
		}
		if (myUnit.IsAircraft)
		{
			num += myUnit.Weaponry.HowManyOfThisWeaponOnLoadout(((Aircraft)myUnit).Loadout, int_0);
		}
		return num + myUnit.Weaponry.HowManyOfThisWeaponOnMagazines(int_0);
	}

	public int HowManyOfThisWeaponOnMountTotal(Mount mount_0, int int_0)
	{
		int num = 0;
		int result = 0;
		try
		{
			foreach (WeaponRec mountWeapon in mount_0.MountWeapons)
			{
				if (mountWeapon.int_0 == int_0)
				{
					num += mountWeapon.CurrentLoad;
				}
			}
			foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
			{
				if (weapon.int_0 == int_0)
				{
					num += weapon.CurrentLoad;
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100314", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public int HowManyOfThisWeaponOnMountMagazine(Mount mount_0, int int_0)
	{
		int num = 0;
		int result = 0;
		try
		{
			foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
			{
				if (weapon.int_0 == int_0)
				{
					num += weapon.CurrentLoad;
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100315", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual int HowManyOfThisWeaponOnMagazines(int int_0)
	{
		int num = 0;
		int result = 0;
		try
		{
			Magazine[] array = ((!myUnit.IsGroupMember() || !myUnit.GetParentGroup().IsLandInstallation) ? myUnit.SharedMagazines : myUnit.GetParentGroup().SharedMagazines);
			if (array != null)
			{
				Magazine[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					foreach (WeaponRec weapon in array2[i].Weapons)
					{
						if (weapon.int_0 == int_0)
						{
							num += weapon.CurrentLoad;
						}
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100316", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual int HowManyOfThisWeaponOnLoadout(Loadout loadout_0, int int_0, int int_1 = 0, Scenario scenario_0 = null)
	{
		int num = 0;
		int result = 0;
		try
		{
			WeaponRec[] weapons;
			if (int_1 == 0)
			{
				weapons = loadout_0.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					if (weaponRec.int_0 == int_0)
					{
						num += weaponRec.CurrentLoad;
					}
				}
				result = num;
				return result;
			}
			if (scenario_0 == null)
			{
				throw new Exception("Scenario is requested when checking the loadout for a Pallet Weapon");
			}
			weapons = loadout_0.Weapons;
			WeaponRec[] array2 = weapons;
			foreach (WeaponRec weaponRec2 in array2)
			{
				if (weaponRec2.int_0 != int_1)
				{
					continue;
				}
				Warhead[] warheads = weaponRec2.GetReferenceWeapon(scenario_0).Warheads;
				for (int i = 0; i < warheads.Length; i = checked(i + 1))
				{
					if (warheads[i].GetCarriedWeapon(scenario_0) != null)
					{
						num += weaponRec2.CurrentLoad;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100317", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void ReloadMounts()
	{
		try
		{
			if (myUnit.IsAircraft || myUnit.IsWeapon || myUnit.Mounts.Count == 0)
			{
				return;
			}
			int count = myUnit.Mounts.Count;
			int num = myUnit.SharedMagazines.Length;
			Dictionary<int, WeaponSalvo.Shooter> dictionary = new Dictionary<int, WeaponSalvo.Shooter>();
			Doctrine._WCS value = myUnit.Doctrine.GetWeaponControlStatus_Air(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
			WeaponSalvo[] weaponSalvos = myUnit.GetUnitSide().WeaponSalvos;
			if (candidateWrapper == null)
			{
				candidateWrapper = new List<WeaponSalvo>();
			}
			else
			{
				candidateWrapper.Clear();
			}
			if (_BaseWrapper == null)
			{
				_BaseWrapper = new List<WeaponSalvo>();
			}
			else
			{
				_BaseWrapper.Clear();
			}
			for (int i = weaponSalvos.Length - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo = weaponSalvos[i];
				if (weaponSalvo == null || (!weaponSalvo.ManualFire && value == Doctrine._WCS.Hold))
				{
					continue;
				}
				for (int j = weaponSalvo.ShootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter = weaponSalvo.ShootersList[j];
					if (Operators.CompareString(myUnit.ObjectID, shooter.ShooterObjectID, TextCompare: false) != 0)
					{
						continue;
					}
					if (shooter.QuantityFired < shooter.QuantityAssigned && !dictionary.ContainsKey(weaponSalvo.int_0))
					{
						dictionary.Add(weaponSalvo.int_0, shooter);
						candidateWrapper.Add(weaponSalvo);
						if (weaponSalvo.ManualFire)
						{
							_BaseWrapper.Add(weaponSalvo);
						}
					}
					break;
				}
			}
			int num8 = count - 1;
			int int_ = 0;
			int int_7 = 0;
			int int_8 = 0;
			int int_9 = 0;
			for (int k = 0; k <= num8; k++)
			{
				Mount mount_ = myUnit.Mounts[k];
				bool flag = false;
				if (myUnit.AI.PrimaryTarget != null && value != Doctrine._WCS.Hold && myUnit.AI.PrimaryTarget != null && mount_.TargetIsWithinCoverageArc(myUnit.AI.PrimaryTarget))
				{
					foreach (WeaponRec mountWeapon in mount_.MountWeapons)
					{
						if (mountWeapon.CurrentLoad > 0)
						{
							Weapon weapon_ = mountWeapon.GetReferenceWeapon(myUnit.ParentScen);
							ActiveUnit_AI aI;
							Contact contact_ = (aI = myUnit.AI).PrimaryTarget;
							int num9 = WeaponSuitabilityForThisTarget(ref weapon_, ref contact_, bool_1: true);
							aI.PrimaryTarget = contact_;
							if (num9 > 0)
							{
								flag = true;
							}
						}
					}
				}
				if (flag)
				{
					continue;
				}
				if (!(mount_.TimeToReloadAttempt <= 0f) && mount_.MountWeapons.Count != mount_.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsLaserShot).Count())
				{
					mount_.TimeToReloadAttempt -= 1f;
				}
				else
				{
					if (!myUnit.IsFacility && num == 0 && mount_.MountMagazine.Weapons.Count == 0)
					{
						continue;
					}
					if (policyWrapper == null)
					{
						policyWrapper = new List<WeaponRec>();
					}
					else
					{
						policyWrapper.Clear();
					}
					if (_BroadcasterWrapper == null)
					{
						_BroadcasterWrapper = new List<WeaponRec>();
					}
					else
					{
						_BroadcasterWrapper.Clear();
					}
					if (identifierWrapper == null)
					{
						identifierWrapper = new List<WeaponRec>();
					}
					else
					{
						identifierWrapper.Clear();
					}
					if (mount_.Status != 0 || !(mount_.MountMagazine.TimeToFire <= 0f))
					{
						continue;
					}
					bool flag2 = false;
					foreach (WeaponRec mountWeapon8 in mount_.MountWeapons)
					{
						if (mountWeapon8.MaxLoad == mount_.MaxCapacity)
						{
							flag2 = true;
							break;
						}
					}
					int int_13;
					if (mount_.MountWeapons.Count > 1 && flag2)
					{
						int num10 = mount_.MountWeapons.Count - 1;
						for (int l = 0; l <= num10; l++)
						{
							WeaponRec weaponRec = mount_.MountWeapons[l];
							if (weaponRec.GetHasManualReloadPriority(mount_))
							{
								if (weaponRec.CurrentLoad < weaponRec.MaxLoad)
								{
									bool flag3 = false;
									foreach (WeaponRec weapon in mount_.MountMagazine.Weapons)
									{
										if (weapon.int_0 == weaponRec.int_0 && weapon.CurrentLoad > 0)
										{
											flag3 = true;
											break;
										}
									}
									if (!flag3)
									{
										Magazine[] magazines = ((Platform)myUnit).Magazines;
										Magazine[] array = magazines;
										foreach (Magazine magazine in array)
										{
											if (magazine.Status == PlatformComponent._ComponentStatus.Destroyed)
											{
												continue;
											}
											foreach (WeaponRec weapon2 in magazine.Weapons)
											{
												if (weapon2.int_0 == weaponRec.int_0 && weapon2.CurrentLoad > 0)
												{
													flag3 = true;
													break;
												}
											}
											if (flag3)
											{
												break;
											}
										}
									}
									if (flag3)
									{
										_BroadcasterWrapper.Add(weaponRec);
									}
								}
								policyWrapper.Add(weaponRec);
							}
							else
							{
								identifierWrapper.Add(weaponRec);
							}
						}
						foreach (WeaponRec item in _BroadcasterWrapper)
						{
							WeaponRec weaponRec_ = item;
							if (weaponRec_.CurrentLoad >= weaponRec_.MaxLoad)
							{
								continue;
							}
							if (identifierWrapper.Count > 0)
							{
								int num11 = identifierWrapper.Count - 1;
								for (int m = 0; m <= num11; m++)
								{
									WeaponRec weaponRec_6 = identifierWrapper[m];
									if (weaponRec_6.CurrentLoad > 0)
									{
										Mount mount = mount_;
										int int_10 = 0;
										int int_11 = 0;
										if (mount.RegisterTokenizer(ref int_10, ref int_11) >= mount_.MaxCapacity && RunConsumer(ref mount_, ref weaponRec_6))
										{
											StartConsumer(ref mount_, ref weaponRec_);
										}
									}
								}
							}
							if (policyWrapper.Count > 1)
							{
								int num12 = policyWrapper.Count - 1;
								for (int num13 = 0; num13 <= num12; num13++)
								{
									WeaponRec weaponRec_7 = policyWrapper[num13];
									if (weaponRec_7 != weaponRec_ && (double)weaponRec_7.CurrentLoad / (double)weaponRec_7.Multiple - 1.0 > (double)weaponRec_.CurrentLoad)
									{
										Mount mount2 = mount_;
										int int_12 = 0;
										int_13 = 0;
										if (mount2.RegisterTokenizer(ref int_12, ref int_13) >= mount_.MaxCapacity && RunConsumer(ref mount_, ref weaponRec_7))
										{
											StartConsumer(ref mount_, ref weaponRec_);
										}
									}
								}
							}
							mount_.RegisterTokenizer(ref int_, ref int_7);
							if (int_7 <= 0 || weaponRec_.Multiple != 1 || int_ + int_7 < mount_.MaxCapacity)
							{
								StartConsumer(ref mount_, ref weaponRec_);
							}
						}
						bool flag4 = false;
						if (dictionary.Count > 0 && policyWrapper.Count == 0)
						{
							if (mount_.MountMagazine.Weapons.Count <= 0)
							{
								if (_BaseWrapper.Count <= 0)
								{
									if (candidateWrapper.Count > 0)
									{
										Mount mount3 = mount_;
										int_13 = 0;
										int int_14 = 0;
										if (mount3.RegisterTokenizer(ref int_13, ref int_14) >= mount_.MaxCapacity)
										{
											foreach (WeaponRec mountWeapon9 in mount_.MountWeapons)
											{
												foreach (WeaponSalvo item2 in candidateWrapper)
												{
													if (mountWeapon9.GetReferenceWeapon(myUnit.ParentScen).DBID == item2.int_0 && mountWeapon9.CurrentLoad > 0)
													{
														flag4 = true;
														break;
													}
												}
												if (flag4)
												{
													break;
												}
											}
										}
										if (flag4)
										{
											continue;
										}
										foreach (WeaponRec mountWeapon10 in mount_.MountWeapons)
										{
											WeaponRec weaponRec_8 = mountWeapon10;
											if (weaponRec_8.GetHasManualReloadPriority(mount_) || weaponRec_8.GetReferenceWeapon(myUnit.ParentScen).IsDecoy || HowManyOfThisWeaponOnMagazines(weaponRec_8.int_0) == 0)
											{
												continue;
											}
											foreach (WeaponSalvo item3 in candidateWrapper)
											{
												if (item3.int_0 != weaponRec_8.int_0 || !dictionary.ContainsKey(weaponRec_8.int_0))
												{
													continue;
												}
												WeaponSalvo.Shooter shooter2 = dictionary[weaponRec_8.int_0];
												if (Operators.CompareString(shooter2.PreferredMountObjectID, "", TextCompare: false) != 0 && Operators.CompareString(shooter2.PreferredMountObjectID, mount_.ObjectID, TextCompare: false) != 0)
												{
													continue;
												}
												Mount mount4 = mount_;
												int_14 = 0;
												int_13 = 0;
												if (mount4.RegisterTokenizer(ref int_14, ref int_13) < mount_.MaxCapacity)
												{
													if (weaponRec_8.CurrentLoad < weaponRec_8.MaxLoad)
													{
														StartConsumer(ref mount_, ref weaponRec_8);
													}
												}
												else
												{
													foreach (WeaponRec mountWeapon11 in mount_.MountWeapons)
													{
														WeaponRec weaponRec_9 = mountWeapon11;
														if (weaponRec_9.CurrentLoad != 0 && weaponRec_9 != weaponRec_8 && RunConsumer(ref mount_, ref weaponRec_9))
														{
															StartConsumer(ref mount_, ref weaponRec_8);
															break;
														}
													}
												}
												flag4 = true;
												break;
											}
											if (!flag4)
											{
												continue;
											}
											break;
										}
									}
								}
								else
								{
									Mount mount5 = mount_;
									int int_2 = 0;
									int_13 = 0;
									if (mount5.RegisterTokenizer(ref int_2, ref int_13) >= mount_.MaxCapacity)
									{
										foreach (WeaponRec mountWeapon12 in mount_.MountWeapons)
										{
											foreach (WeaponSalvo item4 in _BaseWrapper)
											{
												if (mountWeapon12.GetReferenceWeapon(myUnit.ParentScen).DBID == item4.int_0 && mountWeapon12.CurrentLoad > 0)
												{
													flag4 = true;
													break;
												}
											}
											if (flag4)
											{
												break;
											}
										}
									}
									if (flag4)
									{
										continue;
									}
									foreach (WeaponRec mountWeapon13 in mount_.MountWeapons)
									{
										WeaponRec weaponRec_10 = mountWeapon13;
										if (weaponRec_10.GetHasManualReloadPriority(mount_) || weaponRec_10.GetReferenceWeapon(myUnit.ParentScen).IsDecoy || HowManyOfThisWeaponOnMagazines(weaponRec_10.int_0) == 0)
										{
											continue;
										}
										foreach (WeaponSalvo item5 in _BaseWrapper)
										{
											if (item5.int_0 != weaponRec_10.int_0 || !dictionary.ContainsKey(weaponRec_10.int_0))
											{
												continue;
											}
											WeaponSalvo.Shooter shooter3 = dictionary[weaponRec_10.int_0];
											if (Operators.CompareString(shooter3.PreferredMountObjectID, "", TextCompare: false) != 0 && Operators.CompareString(shooter3.PreferredMountObjectID, mount_.ObjectID, TextCompare: false) != 0)
											{
												continue;
											}
											Mount mount6 = mount_;
											int_13 = 0;
											int_2 = 0;
											if (mount6.RegisterTokenizer(ref int_13, ref int_2) < mount_.MaxCapacity)
											{
												if (weaponRec_10.CurrentLoad < weaponRec_10.MaxLoad)
												{
													StartConsumer(ref mount_, ref weaponRec_10);
												}
											}
											else
											{
												int num14 = 0;
												int_2 = count - 1;
												for (int num15 = 0; num15 <= int_2; num15++)
												{
													foreach (WeaponRec mountWeapon14 in myUnit.Mounts[num15].MountWeapons)
													{
														if (mountWeapon14.CurrentLoad != 0 && mountWeapon14.int_0 == item5.int_0)
														{
															num14++;
														}
													}
												}
												if (num14 < shooter3.QuantityAssigned - shooter3.QuantityFired)
												{
													foreach (WeaponRec mountWeapon15 in mount_.MountWeapons)
													{
														WeaponRec weaponRec_11 = mountWeapon15;
														if (weaponRec_11.CurrentLoad != 0 && weaponRec_11 != weaponRec_10 && RunConsumer(ref mount_, ref weaponRec_11))
														{
															StartConsumer(ref mount_, ref weaponRec_10);
															break;
														}
													}
												}
											}
											flag4 = true;
											break;
										}
										if (!flag4)
										{
											continue;
										}
										break;
									}
								}
							}
							else
							{
								foreach (WeaponRec mountWeapon2 in mount_.MountWeapons)
								{
									WeaponRec weaponRec_12 = mountWeapon2;
									if (weaponRec_12.GetHasManualReloadPriority(mount_) || weaponRec_12.GetReferenceWeapon(myUnit.ParentScen).IsDecoy || HowManyOfThisWeaponOnMountMagazine(mount_, weaponRec_12.int_0) == 0 || !dictionary.ContainsKey(weaponRec_12.int_0))
									{
										continue;
									}
									WeaponSalvo.Shooter shooter4 = dictionary[weaponRec_12.int_0];
									if (Operators.CompareString(shooter4.PreferredMountObjectID, "", TextCompare: false) != 0 && Operators.CompareString(shooter4.PreferredMountObjectID, mount_.ObjectID, TextCompare: false) != 0)
									{
										continue;
									}
									Mount mount7 = mount_;
									int_13 = 0;
									int int_3 = 0;
									if (mount7.RegisterTokenizer(ref int_13, ref int_3) < mount_.MaxCapacity)
									{
										StartConsumer(ref mount_, ref weaponRec_12);
									}
									else
									{
										foreach (WeaponRec mountWeapon3 in mount_.MountWeapons)
										{
											WeaponRec weaponRec_13 = mountWeapon3;
											if (weaponRec_13 != weaponRec_12 && RunConsumer(ref mount_, ref weaponRec_13))
											{
												StartConsumer(ref mount_, ref weaponRec_12);
												break;
											}
										}
									}
									dictionary.Remove(weaponRec_12.int_0);
									flag4 = true;
									break;
								}
							}
						}
						if (flag4)
						{
							continue;
						}
						bool flag5 = false;
						if (!flag4 && policyWrapper.Count == 0 && (myUnit.AI.PrimaryTarget != null || myUnit.AI.Targets_ReadOnly.Length != 0))
						{
							if (printerWrapper == null)
							{
								printerWrapper = new List<WeaponRec>();
							}
							else
							{
								printerWrapper.Clear();
							}
							List<WeaponRec> list;
							if (myUnit.AI.PrimaryTarget == null)
							{
								foreach (WeaponRec mountWeapon4 in mount_.MountWeapons)
								{
									Weapon referenceWeapon = mountWeapon4.GetReferenceWeapon(myUnit.ParentScen);
									if (!referenceWeapon.IsDecoy && !referenceWeapon.IsTrainingRound && referenceWeapon.IsAAW)
									{
										printerWrapper.Add(mountWeapon4);
									}
								}
								list = printerWrapper.OrderByDescending((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).MaxAirRange).ToList();
							}
							else
							{
								bool? nullable_ = null;
								foreach (WeaponRec mountWeapon5 in mount_.MountWeapons)
								{
									Weapon referenceWeapon2 = mountWeapon5.GetReferenceWeapon(myUnit.ParentScen);
									if (!referenceWeapon2.IsDecoy && !referenceWeapon2.IsTrainingRound)
									{
										ActiveUnit activeUnit_ = myUnit;
										ActiveUnit_AI aI2;
										Contact contact_2 = (aI2 = myUnit.AI).PrimaryTarget;
										bool num2 = referenceWeapon2.QueryReponse(activeUnit_, ref contact_2, ref nullable_);
										aI2.PrimaryTarget = contact_2;
										if (num2)
										{
											printerWrapper.Add(mountWeapon5);
										}
									}
								}
								list = printerWrapper.OrderByDescending(delegate(WeaponRec weaponRec_0)
								{
									Weapon weapon_3 = weaponRec_0.GetReferenceWeapon(myUnit.ParentScen);
									ActiveUnit_AI aI5;
									Contact contact_4 = (aI5 = myUnit.AI).PrimaryTarget;
									int result = WeaponSuitabilityForThisTarget(ref weapon_3, ref contact_4, bool_1: true);
									aI5.PrimaryTarget = contact_4;
									return result;
								}).ToList();
							}
							if (list.Count > 0)
							{
								foreach (WeaponRec item6 in list)
								{
									WeaponRec weaponRec_2 = item6;
									if (HowManyOfThisWeaponOnMountMagazine(mount_, weaponRec_2.int_0) == 0 && HowManyOfThisWeaponOnMagazines(weaponRec_2.int_0) == 0)
									{
										continue;
									}
									Mount mount8 = mount_;
									int_13 = 0;
									int int_4 = 0;
									if (mount8.RegisterTokenizer(ref int_13, ref int_4) >= mount_.MaxCapacity)
									{
										foreach (WeaponRec mountWeapon6 in mount_.MountWeapons)
										{
											WeaponRec weaponRec_3 = mountWeapon6;
											if (weaponRec_3 != weaponRec_2 && !weaponRec_3.GetHasManualReloadPriority(mount_) && weaponRec_3.CurrentLoad > 0 && !weaponRec_3.GetReferenceWeapon(myUnit.ParentScen).IsDecoy && myUnit.AI.PrimaryTarget != null)
											{
												Weapon weapon_2 = weaponRec_3.GetReferenceWeapon(myUnit.ParentScen);
												ActiveUnit_AI aI3 = myUnit.AI;
												Contact contact_3 = aI3.PrimaryTarget;
												int num3 = WeaponSuitabilityForThisTarget(ref weapon_2, ref contact_3, bool_1: true);
												aI3.PrimaryTarget = contact_3;
												weapon_2 = weaponRec_2.GetReferenceWeapon(myUnit.ParentScen);
												ActiveUnit_AI aI4 = myUnit.AI;
												contact_3 = aI4.PrimaryTarget;
												int num4 = WeaponSuitabilityForThisTarget(ref weapon_2, ref contact_3, bool_1: true);
												aI4.PrimaryTarget = contact_3;
												if (num3 < num4 && RunConsumer(ref mount_, ref weaponRec_3))
												{
													StartConsumer(ref mount_, ref weaponRec_2);
													flag5 = true;
													break;
												}
											}
										}
										continue;
									}
									StartConsumer(ref mount_, ref weaponRec_2);
									flag5 = true;
									break;
								}
							}
						}
						if (!flag5 && !flag4)
						{
							mount_.RegisterTokenizer(ref int_8, ref int_9);
							if (int_8 < mount_.MaxCapacity && _BroadcasterWrapper.Count <= 0)
							{
								int num5 = identifierWrapper.Count - 1;
								for (int num6 = 0; num6 <= num5; num6++)
								{
									WeaponRec weaponRec_4 = identifierWrapper[num6];
									if ((int_9 <= 0 || weaponRec_4.Multiple != 1 || int_8 + int_9 < mount_.MaxCapacity) && !weaponRec_4.GetReferenceWeapon(myUnit.ParentScen).IsTrainingRound && weaponRec_4.CurrentLoad < weaponRec_4.MaxLoad)
									{
										StartConsumer(ref mount_, ref weaponRec_4);
									}
								}
							}
						}
					}
					else
					{
						foreach (WeaponRec mountWeapon7 in mount_.MountWeapons)
						{
							WeaponRec weaponRec_5 = mountWeapon7;
							if (weaponRec_5.CurrentLoad < weaponRec_5.MaxLoad && StartConsumer(ref mount_, ref weaponRec_5))
							{
								break;
							}
						}
					}
					int_13 = mount_.MountMagazine.Weapons.Count - 1;
					for (int num7 = 0; num7 <= int_13; num7++)
					{
						WeaponRec weaponRec2 = mount_.MountMagazine.Weapons[num7];
						if (weaponRec2.GetReferenceWeapon(myUnit.ParentScen).IsTrainingRound || weaponRec2.CurrentLoad >= weaponRec2.MaxLoad)
						{
							continue;
						}
						while (weaponRec2.CurrentLoad < weaponRec2.MaxLoad)
						{
							float float_ = 0f;
							if (string.CompareOrdinal(RemoveWeaponFromMagazines(weaponRec2.int_0, bool_1: false, ref float_), "OK") != 0)
							{
								break;
							}
							weaponRec2.CurrentLoad++;
							mount_.TimeToFire += float_;
							Mount mount9 = mount_;
							int int_5 = 0;
							int int_6 = 0;
							if (mount9.RegisterTokenizer(ref int_5, ref int_6) >= mount_.MaxCapacity)
							{
								break;
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
			exception_?.Data.Add("Error at 100318", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool PostConsumer(Mount mount_0, List<WeaponRec> list_0)
	{
		bool result = false;
		try
		{
			if (list_0.Count == 0)
			{
				result = false;
				return false;
			}
			foreach (WeaponRec item in list_0)
			{
				foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
				{
					if (weapon.int_0 == item.int_0 && weapon.CurrentLoad > 0)
					{
						result = true;
						return true;
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				Magazine[] array = sharedMagazines;
				foreach (Magazine magazine in array)
				{
					if (magazine.Status != 0)
					{
						continue;
					}
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						if (weapon2.int_0 == item.int_0 && weapon2.CurrentLoad > 0)
						{
							result = true;
							return true;
						}
					}
				}
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100319", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private bool RunConsumer(ref Mount mount_0, ref WeaponRec weaponRec_0)
	{
		Mount obj = mount_0;
		int int_ = 0;
		int int_2 = 0;
		if (obj.RegisterTokenizer(ref int_, ref int_2) == 0)
		{
			return false;
		}
		if (weaponRec_0.CurrentLoad == 0)
		{
			return false;
		}
		if (weaponRec_0.TimeToFire <= 0f)
		{
			try
			{
				foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
				{
					WeaponRec weaponRec_ = weapon;
					if (weaponRec_.int_0 == weaponRec_0.int_0 && string.CompareOrdinal(PrintConsumer(ref weaponRec_), "OK") == 0)
					{
						if (weaponRec_0.Multiple <= 1)
						{
							weaponRec_0.CurrentLoad--;
						}
						else
						{
							int_2 = weaponRec_0.Multiple;
							for (int i = 1; i <= int_2; i++)
							{
								weaponRec_0.CurrentLoad--;
								float num = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
								if (num == (float)(int)Math.Round(num))
								{
									break;
								}
							}
						}
						weaponRec_0.ResetTimeToFire();
						mount_0.ReloadStatus = Mount._ReloadStatus.Unloading;
						mount_0.MountMagazine.ResetTimeToFire();
						return true;
					}
				}
				if (string.CompareOrdinal(AddWeaponToMagazines(weaponRec_0.int_0, bool_1: false, bool_2: true, bool_3: true), "OK") == 0)
				{
					if (weaponRec_0.Multiple <= 1)
					{
						weaponRec_0.CurrentLoad--;
					}
					else
					{
						int_ = weaponRec_0.Multiple;
						for (int j = 1; j <= int_; j++)
						{
							weaponRec_0.CurrentLoad--;
							float num2 = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
							if (num2 == (float)(int)Math.Round(num2))
							{
								break;
							}
						}
					}
					mount_0.ReloadStatus = Mount._ReloadStatus.Unloading;
					weaponRec_0.ResetTimeToFire();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100320", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
		return false;
	}

	private bool StartConsumer(ref Mount mount_0, ref WeaponRec weaponRec_0)
	{
		bool result = false;
		if (mount_0.OrderTokenizer())
		{
			result = false;
		}
		else
		{
			Mount obj = mount_0;
			int int_ = 0;
			int int_2 = 0;
			obj.RegisterTokenizer(ref int_2, ref int_);
			if (int_2 < mount_0.MaxCapacity)
			{
				try
				{
					while (true)
					{
						if (weaponRec_0.CurrentLoad >= weaponRec_0.MaxLoad)
						{
							return result;
						}
						if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsLaserShot && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Warheads[0].LaserType == Warhead._LaserType.SolidState && myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse && (myUnit.IsFacility || myUnit.Propulsion.Count > 0 || myUnit.Propulsion.Where((Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() > 0))
						{
							weaponRec_0.CurrentLoad++;
							return true;
						}
						foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
						{
							WeaponRec weaponRec_ = weapon;
							if (weaponRec_.int_0 == weaponRec_0.int_0 && string.CompareOrdinal(AssetConsumer(ref weaponRec_), "OK") == 0)
							{
								if (weaponRec_0.Multiple <= 1)
								{
									weaponRec_0.CurrentLoad++;
								}
								else
								{
									int_ = weaponRec_0.Multiple;
									for (int i = 1; i <= int_; i++)
									{
										weaponRec_0.CurrentLoad++;
										float num = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
										if (num == (float)(int)Math.Round(num))
										{
											break;
										}
									}
								}
								mount_0.TimeToFire += mount_0.MountMagazine.ROF;
								if (mount_0.TimeToFire > (float)(mount_0.MaxCapacity * mount_0.MountMagazine.ROF))
								{
									mount_0.TimeToFire = mount_0.MaxCapacity * mount_0.MountMagazine.ROF;
								}
								mount_0.ReloadStatus = Mount._ReloadStatus.Reloading;
								Mount obj2 = mount_0;
								int int_3 = 0;
								int int_4 = 0;
								if (obj2.RegisterTokenizer(ref int_3, ref int_4) >= mount_0.MaxCapacity)
								{
									result = true;
									return true;
								}
							}
						}
						float float_ = 0f;
						bool flag = false;
						if (weaponRec_0.Multiple <= 1)
						{
							if (string.CompareOrdinal(RemoveWeaponFromMagazines(weaponRec_0.int_0, bool_1: false, ref float_), "OK") == 0)
							{
								flag = true;
								weaponRec_0.CurrentLoad++;
							}
						}
						else
						{
							int multiple = weaponRec_0.Multiple;
							for (int j = 1; j <= multiple; j++)
							{
								if (string.CompareOrdinal(RemoveWeaponFromMagazines(weaponRec_0.int_0, bool_1: false, ref float_), "OK") == 0)
								{
									flag = true;
									weaponRec_0.CurrentLoad++;
									float num2 = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
									if (num2 == (float)(int)Math.Round(num2))
									{
										break;
									}
								}
							}
						}
						if (!flag)
						{
							break;
						}
						mount_0.TimeToFire += float_;
						if (mount_0.TimeToFire > (float)mount_0.MaxCapacity * float_)
						{
							mount_0.TimeToFire = (float)mount_0.MaxCapacity * float_;
						}
						mount_0.ReloadStatus = Mount._ReloadStatus.Reloading;
						Mount obj3 = mount_0;
						int int_5 = 0;
						obj3.RegisterTokenizer(ref int_2, ref int_5);
						if (int_2 == mount_0.MaxCapacity)
						{
							return true;
						}
					}
					return false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 100321", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = false;
					ProjectData.ClearProjectError();
					return false;
				}
			}
		}
		return result;
	}

	public virtual string CanAddWeaponToUnit(int int_0, bool bool_1, bool bool_2)
	{
		string result = null;
		try
		{
			Magazine[] totalMagazines = myUnit.TotalMagazines;
			Magazine[] array = totalMagazines;
			Magazine[] array2 = array;
			foreach (Magazine magazine in array2)
			{
				int int_ = 0;
				int int_2 = 0;
				if (magazine.InitClass(ref int_, ref int_2) >= magazine.Capacity)
				{
					continue;
				}
				foreach (WeaponRec weapon in magazine.Weapons)
				{
					if (weapon.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0 && weapon.CurrentLoad < weapon.MaxLoad)
					{
						result = "OK";
						return result;
					}
				}
			}
			if (bool_2 && ((Platform)myUnit).SharedMagazines.Length != 0)
			{
				totalMagazines = ((Platform)myUnit).SharedMagazines;
				if (bool_1)
				{
					totalMagazines = totalMagazines.OrderByDescending((Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
				}
				Magazine magazine2 = totalMagazines[0];
				int int_4;
				int int_3;
				if (totalMagazines.Count() > 1)
				{
					array = totalMagazines;
					Magazine[] array3 = array;
					foreach (Magazine magazine3 in array3)
					{
						int_3 = 0;
						int_4 = 0;
						if (magazine3.InitClass(ref int_3, ref int_4) < magazine3.Capacity)
						{
							magazine2 = magazine3;
							break;
						}
					}
				}
				Magazine magazine4 = magazine2;
				int_4 = 0;
				int_3 = 0;
				if (magazine4.InitClass(ref int_4, ref int_3) < magazine2.Capacity)
				{
					result = "OK";
					return result;
				}
			}
			foreach (Mount mount in myUnit.Mounts)
			{
				int int_5 = 0;
				int int_6 = 0;
				if (mount.RegisterTokenizer(ref int_5, ref int_6) >= mount.MaxCapacity)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_0 == int_0 && mountWeapon.CurrentLoad < mountWeapon.MaxLoad)
					{
						result = "OK";
						return result;
					}
				}
			}
			result = "Failed";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100322", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual string CanReplenishWeaponToUnit(int int_0, bool bool_1, bool bool_2)
	{
		string result = null;
		try
		{
			Magazine[] totalMagazines = myUnit.TotalMagazines;
			Magazine[] array = totalMagazines;
			Magazine[] array2 = array;
			foreach (Magazine magazine in array2)
			{
				int int_ = 0;
				int int_2 = 0;
				if (magazine.InitClass(ref int_, ref int_2) >= magazine.Capacity)
				{
					continue;
				}
				foreach (WeaponRec weapon in magazine.Weapons)
				{
					if (weapon.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0 && weapon.CurrentLoad < weapon.MaxLoad && (weapon.WRecDBID.HasValue || weapon.MaxLoad < 10000))
					{
						result = "OK";
						return result;
					}
				}
			}
			if (bool_2 && ((Platform)myUnit).SharedMagazines.Length != 0)
			{
				totalMagazines = ((Platform)myUnit).SharedMagazines;
				if (bool_1)
				{
					totalMagazines = totalMagazines.OrderByDescending((Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
				}
				Magazine magazine2 = totalMagazines[0];
				int int_4;
				int int_3;
				if (totalMagazines.Count() > 1)
				{
					array = totalMagazines;
					Magazine[] array3 = array;
					foreach (Magazine magazine3 in array3)
					{
						int_3 = 0;
						int_4 = 0;
						if (magazine3.InitClass(ref int_3, ref int_4) < magazine3.Capacity)
						{
							magazine2 = magazine3;
							break;
						}
					}
				}
				Magazine magazine4 = magazine2;
				int_4 = 0;
				int_3 = 0;
				if (magazine4.InitClass(ref int_4, ref int_3) < magazine2.Capacity)
				{
					result = "OK";
					return result;
				}
			}
			foreach (Mount mount in myUnit.Mounts)
			{
				int int_5 = 0;
				int int_6 = 0;
				if (mount.RegisterTokenizer(ref int_5, ref int_6) >= mount.MaxCapacity)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_0 == int_0 && mountWeapon.CurrentLoad < mountWeapon.MaxLoad)
					{
						result = "OK";
						return result;
					}
				}
			}
			result = "Failed";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100322", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual string AddWeaponToUnit(int int_0, bool bool_1, bool bool_2)
	{
		string result = null;
		try
		{
			if (Operators.CompareString(AddWeaponToMagazines(int_0, bool_1, bool_2), "OK", TextCompare: false) == 0)
			{
				result = "OK";
				return result;
			}
			foreach (Mount mount in myUnit.Mounts)
			{
				int int_ = 0;
				int int_2 = 0;
				if (mount.RegisterTokenizer(ref int_, ref int_2) >= mount.MaxCapacity)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_0 == int_0 && mountWeapon.CurrentLoad < mountWeapon.MaxLoad)
					{
						mountWeapon.CurrentLoad++;
						result = "OK";
						return result;
					}
				}
			}
			result = "Failed";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100322", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual string AddWeaponToMagazines(int int_0, bool bool_1, bool bool_2, bool bool_3 = false)
	{
		string result = null;
		try
		{
			Magazine[] totalMagazines = myUnit.TotalMagazines;
			Magazine[] array = totalMagazines;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (string.CompareOrdinal(array[num].AddWeapon(int_0, bool_3), "OK") == 0)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				if (bool_2 && ((Platform)myUnit).SharedMagazines.Length != 0)
				{
					totalMagazines = ((Platform)myUnit).SharedMagazines;
					if (bool_1)
					{
						totalMagazines = totalMagazines.OrderByDescending((Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
					}
					Magazine magazine = totalMagazines[0];
					if (totalMagazines.Count() > 1)
					{
						Magazine[] array2 = totalMagazines;
						Magazine[] array3 = array2;
						foreach (Magazine magazine2 in array3)
						{
							int int_ = 0;
							int int_2 = 0;
							if (magazine2.InitClass(ref int_, ref int_2) < magazine2.Capacity)
							{
								magazine = magazine2;
								break;
							}
						}
					}
					if (magazine.Capacity != 10000)
					{
						Magazine magazine3 = magazine;
						int int_3 = 0;
						int int_4 = 0;
						if (magazine3.InitClass(ref int_3, ref int_4) >= magazine.Capacity)
						{
							goto IL_01c0;
						}
					}
					WeaponRec item = new WeaponRec(ref myUnit.ParentScen, int_0, 0, 10000, 1, 1, bool_0: false, bool_1: false);
					magazine.Weapons.Add(item);
					if (string.CompareOrdinal(magazine.AddWeapon(int_0), "OK") == 0)
					{
						magazine.RaiseEventStatusChanged();
						result = "OK";
						return result;
					}
				}
				goto IL_01c0;
				IL_01c0:
				result = "Failed";
				return result;
			}
			result = "OK";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100323", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual string RemoveWeaponFromMagazines(int int_0, bool bool_1, ref float float_0)
	{
		string result = null;
		try
		{
			if (bool_1 && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				result = "OK";
				return result;
			}
			Magazine[] magazines = ((Platform)myUnit).Magazines;
			Magazine[] array = magazines;
			foreach (Magazine magazine in array)
			{
				if (magazine.Status != PlatformComponent._ComponentStatus.Destroyed && Operators.CompareString(magazine.RemoveWeapon(int_0, bool_1, ref float_0), "OK", TextCompare: false) == 0)
				{
					float_0 = magazine.ROF;
					result = "OK";
					return result;
				}
			}
			result = "弹药库中没有找到武器";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100324", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private string AssetConsumer(ref WeaponRec weaponRec_0)
	{
		string result = null;
		try
		{
			if (weaponRec_0.TimeToFire <= 0f)
			{
				if (weaponRec_0.CurrentLoad == 0)
				{
					result = "武器记录是空的";
					return result;
				}
				weaponRec_0.CurrentLoad--;
				result = "OK";
				return result;
			}
			result = "目前无法发射该武器（未到下次开火时间）";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100325", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private string PrintConsumer(ref WeaponRec weaponRec_0)
	{
		string result = null;
		try
		{
			if (weaponRec_0.CurrentLoad == weaponRec_0.MaxLoad)
			{
				result = "武器记录已满";
				return result;
			}
			weaponRec_0.CurrentLoad++;
			result = "OK";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100326", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void FireChaffBundle(float float_0)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		try
		{
			foreach (Mount mount in myUnit.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					if (mountWeapon.CurrentLoad != 0 && mountWeapon.GetReferenceWeapon(myUnit.ParentScen).IsChaffBundle && mount.Status == PlatformComponent._ComponentStatus.Operational && mount.TimeToFire == 0f && mountWeapon.TimeToFire == 0f)
					{
						list.Add(mountWeapon);
					}
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					weaponRec.ParentMount = null;
					if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).IsChaffBundle && weaponRec.CurrentLoad != 0 && weaponRec.TimeToFire <= 0f)
					{
						list.Add(weaponRec);
					}
				}
			}
			switch (list.Count)
			{
			case 1:
			{
				WeaponRec weaponRec_2 = list[0];
				int int_2 = 0;
				WeaponSalvo weaponSalvo_2 = null;
				ResetConsumer(float_0, ref weaponRec_2, null, ref int_2, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_2);
				list[0] = weaponRec_2;
				break;
			}
			default:
			{
				WeaponRec weaponRec_ = list[GameGeneral.LockRandom_0.Next(0, list.Count)];
				int int_ = 0;
				WeaponSalvo weaponSalvo_ = null;
				ResetConsumer(float_0, ref weaponRec_, null, ref int_, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_);
				break;
			}
			case 0:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100476", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DefineConsumer(ActiveUnit activeUnit_0, ref UnguidedWeapon unguidedWeapon_0, StringBuilder stringBuilder_0)
	{
		try
		{
			if (activeUnit_0.IsAircraft)
			{
				switch (((Aircraft)activeUnit_0).BombSightTech)
				{
				case Aircraft._BombsightTech.Basic:
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("基础科技轰炸 - 准确性不受影响。");
					}
					break;
				case Aircraft._BombsightTech.Ballistic:
					unguidedWeapon_0.CEP_Land = (float)(0.75 * (double)unguidedWeapon_0.CEP_Land);
					unguidedWeapon_0.CEP_Surface = (float)(0.75 * (double)unguidedWeapon_0.CEP_Surface);
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("弹道技术轰炸 - 准确度提高了25％。");
					}
					break;
				case Aircraft._BombsightTech.Computing:
					unguidedWeapon_0.CEP_Land = (float)(0.5 * (double)unguidedWeapon_0.CEP_Land);
					unguidedWeapon_0.CEP_Surface = (float)(0.5 * (double)unguidedWeapon_0.CEP_Surface);
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("计算技术轰炸 - 精度提高50％。");
					}
					break;
				case Aircraft._BombsightTech.Advanced:
					unguidedWeapon_0.CEP_Land = (float)(0.2 * (double)unguidedWeapon_0.CEP_Land);
					unguidedWeapon_0.CEP_Surface = (float)(0.2 * (double)unguidedWeapon_0.CEP_Surface);
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("先进技术轰炸 - 精度提高80％。");
					}
					break;
				}
				GlobalVariables.ProficiencyLevel? proficiency = activeUnit_0.Proficiency;
				int? num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					unguidedWeapon_0.CEP_Land *= 2f;
					unguidedWeapon_0.CEP_Surface *= 2f;
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("船员是新手 - 准确度降低100％。");
					}
				}
				else
				{
					num = (int?)proficiency;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("船员是学员 - 准确度降低50％。");
						}
					}
					else
					{
						num = (int?)proficiency;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
							unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
							if (!Information.IsNothing(stringBuilder_0))
							{
								stringBuilder_0.Append("船员熟练度一般 -\u200b\u200b 准确度降低20％。");
							}
						}
						else
						{
							num = (int?)proficiency;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								if (!Information.IsNothing(stringBuilder_0))
								{
									stringBuilder_0.Append("船员是熟手 - 准确性不受影响。");
								}
							}
							else
							{
								num = (int?)proficiency;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.5);
									unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.5);
									if (!Information.IsNothing(stringBuilder_0))
									{
										stringBuilder_0.Append("船员是高手 - 准确度提高100％。");
									}
								}
							}
						}
					}
				}
				if (unguidedWeapon_0.Type != Weapon._WeaponType.IronBomb || !(activeUnit_0.CurrentAltitude_AGL > 609.60004f))
				{
					return;
				}
				float num2 = (activeUnit_0.CurrentAltitude_AGL - 609.60004f) / 1500f;
				if (num2 <= 0f)
				{
					return;
				}
				switch (((Aircraft)activeUnit_0).BombSightTech)
				{
				case Aircraft._BombsightTech.Basic:
					unguidedWeapon_0.CEP_Land += num2 * 100f;
					unguidedWeapon_0.CEP_Surface += num2 * 100f;
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("基础技术轰炸瞄准器炸和").Append(activeUnit_0.GetCurrentAltitude()).Append("米高度 - 精度下降")
							.Append((int)Math.Round(num2))
							.Append("%. ");
					}
					break;
				case Aircraft._BombsightTech.Ballistic:
					unguidedWeapon_0.CEP_Land += num2 * 75f;
					unguidedWeapon_0.CEP_Surface += num2 * 75f;
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("弹道技术轰炸瞄准器和").Append(activeUnit_0.GetCurrentAltitude()).Append("米高度 - 精度下降")
							.Append((int)Math.Round(num2))
							.Append("%. ");
					}
					break;
				case Aircraft._BombsightTech.Computing:
					unguidedWeapon_0.CEP_Land += num2 * 50f;
					unguidedWeapon_0.CEP_Surface += num2 * 50f;
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("计算技术轰炸瞄准器和").Append(activeUnit_0.GetCurrentAltitude()).Append("米高度 - 精度下降")
							.Append((int)Math.Round(num2))
							.Append("%. ");
					}
					break;
				case Aircraft._BombsightTech.Advanced:
					unguidedWeapon_0.CEP_Land += num2 * 25f;
					unguidedWeapon_0.CEP_Surface += num2 * 25f;
					if (!Information.IsNothing(stringBuilder_0))
					{
						stringBuilder_0.Append("高科技轰炸瞄准器和").Append(activeUnit_0.GetCurrentAltitude()).Append("米高度 - 精度下降")
							.Append((int)Math.Round(num2))
							.Append("%. ");
					}
					break;
				}
			}
			else
			{
				if (!activeUnit_0.IsShip)
				{
					return;
				}
				int seaState = Weather.GetWeatherAtThisTimeAndPlace(activeUnit_0.ParentScen, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), 0).SeaState;
				switch (((Ship)activeUnit_0).VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况0-2和非常小的船 - 准确度不受影响。");
						}
						break;
					case 3:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况3和非常小的船 - 准确度下降10％。");
						}
						break;
					case 4:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况4和非常小的船 - 准确度下降20％。");
						}
						break;
					case 5:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况5和非常小的船 - 准确度下降20％。");
						}
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况6和非常小的船 - 准确度下降50％。");
						}
						break;
					case 7:
						unguidedWeapon_0.CEP_Land *= 2f;
						unguidedWeapon_0.CEP_Surface *= 2f;
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况7和非常小的船 - 准确度下降100％。");
						}
						break;
					case 8:
						unguidedWeapon_0.CEP_Land *= 3f;
						unguidedWeapon_0.CEP_Surface *= 3f;
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况8和非常小的船 - 准确度下降200％。");
						}
						break;
					case 9:
						unguidedWeapon_0.CEP_Land *= 4f;
						unguidedWeapon_0.CEP_Surface *= 4f;
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况9号和非常小的船舶 - 准确度下降300％。");
						}
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况0-3和小船 - 准确度不受影响。");
						}
						break;
					case 4:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况4和小型船舶 - 准确度下降了10％。");
						}
						break;
					case 5:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况5和小船 - 准确度下降了20％。");
						}
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况6和小型船舶 - 准确度下降了30％。");
						}
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况7和小型船舶 - 准确度下降了50％。");
						}
						break;
					case 8:
						unguidedWeapon_0.CEP_Land *= 2f;
						unguidedWeapon_0.CEP_Surface *= 2f;
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况8和小船 - 准确度下降了100％。");
						}
						break;
					case 9:
						unguidedWeapon_0.CEP_Land *= 3f;
						unguidedWeapon_0.CEP_Surface *= 3f;
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况9号和小型船舶 - 准确度下降了200％。");
						}
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况0-4和中型船 - 准确度不受影响。");
						}
						break;
					case 5:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况5和中型船 - 准确度下降10％。");
						}
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况6和中型船 - 准确度下降20％。");
						}
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况7和中型船 - 准确度下降了30％。");
						}
						break;
					case 8:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况8和中型船 - 准确度下降了50％。");
						}
						break;
					case 9:
						unguidedWeapon_0.CEP_Land *= 2f;
						unguidedWeapon_0.CEP_Surface *= 2f;
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况9号和中型船 - 准确度下降了100％。");
						}
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况0-5和大型船舶 - 准确度不受影响。");
						}
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况6号和大型船舶 - 准确度下降了10％。");
						}
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况7号和大型船舶 - 准确度下降了20％。");
						}
						break;
					case 8:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况8和大型船舶 - 准确度下降了30％。");
						}
						break;
					case 9:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况9号和大型船舶 - 准确度下降了50％。");
						}
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况0-6和非常大的船 - 准确度不受影响。");
						}
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况7号和超大型船舶 - 准确度下降了10％。");
						}
						break;
					case 8:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况8号和超大型船舶 - 准确度下降了20％。");
						}
						break;
					case 9:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("海况9号和超大型船舶 - 准确度下降了30％。");
						}
						break;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100328", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PublishConsumer(WeaponRec weaponRec_0, Weapon weapon_0, WeaponSalvo weaponSalvo_0, Contact contact_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		string name = weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Name;
		Geopoint_Struct geopoint_Struct_ = new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude());
		stringBuilder.Append(myUnit.Name).Append(" attacks with contact bomb: ").Append(name)
			.Append(". ");
		myUnit.ParentScen.AddMessage(stringBuilder.ToString(), name + " 被攻击", LoggedMessage.MessageType.WeaponEndgame, 0, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
		weaponRec_0.CurrentLoad--;
		weaponRec_0.ResetTimeToFire();
		float num = weapon_0.OrderReponse();
		if ((float)GameGeneral.LockRandom_0.Next(1, 101) < num)
		{
			if (weapon_0.Warheads.Count() > 0)
			{
				Weapon.RaiseEvent_WeaponImpact(myUnit.ParentScen, weapon_0, contact_0, bool_0: true);
			}
			float currentAltitude = contact_0.GetCurrentAltitude();
			if (contact_0.ActualUnit != null)
			{
				currentAltitude = contact_0.ActualUnit.GetCurrentAltitude();
			}
			Warhead[] warheads = weapon_0.Warheads;
			Warhead[] array = warheads;
			foreach (Warhead warhead in array)
			{
				new Explosion(ref myUnit.ParentScen, contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.CurrentHeading, currentAltitude, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, contact_0.ActualUnit, null, myUnit, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads, warhead.DP).CurrentHeading = myUnit.CurrentHeading;
			}
			if (weaponSalvo_0 != null)
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvo_0.ShootersList;
				WeaponSalvo.Shooter[] array2 = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array2)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0)
					{
						shooter.QuantityFired++;
					}
				}
				myUnit.GetUnitSide().AttemptToRemoveWeaponSalvo(ref myUnit.ParentScen, weaponSalvo_0);
			}
			string text = "武器：" + name + " has detonated on the target. ";
			if (weapon_0.Type == Weapon._WeaponType.ContactBomb_Suicide)
			{
				myUnit.ParentScen.DestroyThisUnit(myUnit, "Contact bomb detonated", "Self-destruct");
				text = text + myUnit.Name + " was destroyed.";
			}
			myUnit.ParentScen.AddMessage(text, name + " 正引爆", LoggedMessage.MessageType.WeaponEndgame, 0, weapon_0.ObjectID, null, geopoint_Struct_);
		}
		else
		{
			myUnit.ParentScen.AddMessage("武器：" + name + "发生故障。", name + " 故障", LoggedMessage.MessageType.WeaponEndgame, 0, weapon_0.ObjectID, null, geopoint_Struct_);
		}
	}

	private void AwakeConsumer(Weapon weapon_0)
	{
		if (weapon_0.Warheads.Count() > 0)
		{
			switch (weapon_0.Warheads[0].Caliber)
			{
			case Warhead.WarheadCaliber.Rocket_6_15mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 2f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 2f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_16_24mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 4f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 4f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_25_60mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 8f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 8f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_61_80mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 14f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 14f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_81_150mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 25f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 25f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_151_200mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 35f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 35f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_201_350mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 45f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 45f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_351_450mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 55f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 55f, 4);
				break;
			case Warhead.WarheadCaliber.Gun_6_15mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 2f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 2f);
				break;
			case Warhead.WarheadCaliber.Gun_16_24mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 4f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 4f);
				break;
			case Warhead.WarheadCaliber.Gun_25_60mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 8f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 8f);
				break;
			case Warhead.WarheadCaliber.Gun_61_80mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 14f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 14f);
				break;
			case Warhead.WarheadCaliber.Gun_81_150mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 25f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 25f);
				break;
			case Warhead.WarheadCaliber.Gun_151_200mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 35f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 35f);
				break;
			case Warhead.WarheadCaliber.Gun_201_350mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 45f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 45f);
				break;
			case Warhead.WarheadCaliber.Gun_351_450mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 55f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 55f);
				break;
			case Warhead.WarheadCaliber.None:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 20f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 20f);
				break;
			}
		}
	}

	private void QueryConsumer(string string_0, Mount mount_0)
	{
		if (mount_0 != null)
		{
			mount_0.LastFiredWeaponID = string_0;
		}
	}

	internal List<Module_Unit.Unit> ResetConsumer(float float_0, ref WeaponRec weaponRec_0, Contact contact_0, ref int int_0, int int_1, float float_1, ActiveUnit.Throttle throttle_0, Mount mount_0, SonarModel.PositionRelativeToThermocline positionRelativeToThermocline_0, long long_0, ref WeaponSalvo weaponSalvo_0)
	{
		float num = 0f;
		if (contact_0 != null)
		{
			num = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
		}
		Weapon referenceWeapon = weaponRec_0.GetReferenceWeapon(myUnit.ParentScen);
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		try
		{
			AwakeConsumer(referenceWeapon);
			MiningMission miningMission;
			GeoPoint geoPoint;
			float num3;
			ActiveUnit activeUnit;
			bool? nullable_;
			double double_;
			ActiveUnit activeUnit2;
			bool? nullable_2;
			double double_2;
			double double_3;
			double double_4;
			double double_5;
			int? sequence2;
			switch (referenceWeapon.Type)
			{
			case Weapon._WeaponType.Sonobuoy:
			{
				Weapon newWeapon2 = Weapon.GetNewWeapon(ref myUnit.ParentScen, weaponRec_0.int_0, bool_0: false);
				newWeapon2.CEP_Surface = newWeapon2.CEP_Surface_Nominal;
				newWeapon2.CEP_Land = newWeapon2.CEP_Land_Nominal;
				CalcConsumer(float_0, myUnit, newWeapon2, weaponRec_0.int_0, null, mount_0, myUnit.CurrentHeading, ActiveUnit.Throttle.Cruise, positionRelativeToThermocline_0);
				weaponRec_0.CurrentLoad--;
				weaponRec_0.ResetTimeToFire();
				int_0++;
				list.Add(newWeapon2);
				break;
			}
			case Weapon._WeaponType.BottomMine:
			case Weapon._WeaponType.MooredMine:
			case Weapon._WeaponType.FloatingMine:
			case Weapon._WeaponType.MovingMine:
			case Weapon._WeaponType.RisingMine:
			case Weapon._WeaponType.DriftingMine:
			case Weapon._WeaponType.DummyMine:
			{
				UnguidedWeapon unguidedWeapon_ = new UnguidedWeapon(referenceWeapon, null, null, 0.0, 0.0, long_0);
				unguidedWeapon_.SetUnitSide(bool_0: false, myUnit.GetUnitSide());
				if (string.CompareOrdinal(UnguidedWeapon.CanLayMineHere(ref unguidedWeapon_, myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen), myUnit.ParentScen), "OK") != 0)
				{
					break;
				}
				myUnit.ParentScen.UnguidedWeapons.Add(unguidedWeapon_.ObjectID, unguidedWeapon_);
				weaponRec_0.CurrentLoad--;
				weaponRec_0.ResetTimeToFire();
				int_0++;
				list.Add(unguidedWeapon_);
				ActivationPointContact contact_ = new ActivationPointContact(myUnit.GetLatitude(), myUnit.GetLongitude());
				Weapon newWeapon = Weapon.GetNewWeapon(ref myUnit.ParentScen, weaponRec_0.int_0, bool_0: false);
				unguidedWeapon_.FiringParent = myUnit;
				unguidedWeapon_.FiringParent_ID = myUnit.ObjectID;
				ExportWeaponFireEvent(contact_, newWeapon, weaponSalvo_0);
				if (Information.IsNothing(myUnit.AssignedMissionOrPackage()) || myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Mining)
				{
					break;
				}
				miningMission = (MiningMission)myUnit.AssignedMissionOrPackage();
				if (myUnit.AI.MiningInfo == null)
				{
					myUnit.AI.MiningInfo = new MiningMission.MiningInformation(new GeoPoint(myUnit.GetLongitude(), myUnit.GetLatitude()), miningMission.MinesLaidInSets, miningMission.MinesLaidInterval, miningMission.MinesLaidMethod, miningMission.MinesLaidSetInterval);
					if (myUnit.AI.MiningInfo.Sequence.HasValue)
					{
						myUnit.AI.MiningInfo.Sequence--;
					}
					if (myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.ManualPlottedCourseWaypoint)
					{
						myUnit.AI.MiningInfo.LastPlottedWayPoint = myUnit.Navigator.PlottedCourse[0];
					}
				}
				else
				{
					myUnit.AI.MiningInfo.LastMineLocal = new GeoPoint(myUnit.GetLongitude(), myUnit.GetLatitude());
					if (myUnit.AI.MiningInfo.Sequence.HasValue)
					{
						myUnit.AI.MiningInfo.Sequence--;
					}
				}
				if (((MiningMission)myUnit.AssignedMissionOrPackage()).Area.Count <= 2)
				{
					break;
				}
				if (myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.ManualPlottedCourseWaypoint)
				{
					if (myUnit.AI.MiningInfo == null)
					{
						break;
					}
					int? sequence = myUnit.AI.MiningInfo.Sequence;
					if ((sequence.HasValue ? new bool?(sequence.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						if (myUnit.AI.MiningInfo.SpacingSet.HasValue)
						{
							myUnit.AI.MiningInfo.LastMineSet = new GeoPoint(myUnit.GetLongitude(), myUnit.GetLatitude());
							myUnit.AI.MiningInfo.Sequence = miningMission.MinesLaidInSets;
						}
						else
						{
							myUnit.AI.MiningInfo = null;
						}
					}
					break;
				}
				if (myUnit.Navigator.PlottedCourse.Count() == 1)
				{
					_ = myUnit.Navigator.PlottedCourse[0];
				}
				else if (myUnit.Navigator.PlottedCourse.Count() > 1)
				{
					_ = myUnit.Navigator.PlottedCourse[1];
				}
				myUnit.Navigator.ClearPlottedCourse();
				geoPoint = new GeoPoint();
				float desiredHeading = myUnit.DesiredHeading;
				num3 = desiredHeading;
				if (miningMission.MinesLaidMethod.HasValue)
				{
					int? num4 = miningMission.MinesLaidMethod;
					if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						num3 = desiredHeading;
						goto IL_225b;
					}
				}
				num3 = Math2.UpdateClass(desiredHeading + (float)GameGeneral.LockRandom_0.Next(60) - (float)GameGeneral.LockRandom_0.Next(60));
				goto IL_225b;
			}
			case Weapon._WeaponType.Decoy_Expendable:
			{
				Weapon newWeapon4 = Weapon.GetNewWeapon(ref myUnit.ParentScen, weaponRec_0.int_0, bool_0: false);
				if (newWeapon4.IsChaffBundle)
				{
					ChaffCorridorCloud item = new ChaffCorridorCloud(myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.GetCurrentAltitude(), myUnit.CurrentHeading);
					myUnit.ParentScen.ChaffClouds.Add(item);
				}
				weaponRec_0.CurrentLoad--;
				weaponRec_0.ResetTimeToFire();
				int_0++;
				list.Add(newWeapon4);
				break;
			}
			case Weapon._WeaponType.ContactBomb_Suicide:
			case Weapon._WeaponType.ContactBomb_Sabotage:
				PublishConsumer(weaponRec_0, referenceWeapon, weaponSalvo_0, contact_0);
				int_0++;
				break;
			default:
				switch (referenceWeapon.Type)
				{
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				{
					int num7 = 150;
					if (int_1 > 0 && num7 > int_1)
					{
						num7 = int_1;
					}
					if (num7 > weaponRec_0.CurrentLoad)
					{
						num7 = weaponRec_0.CurrentLoad;
					}
					Sensor sensor_2 = null;
					stringBuilder.Append(myUnit.Name).Append("使用非制导武器进行攻击：").Append(num7)
						.Append("x ")
						.Append(weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Name)
						.Append(". ");
					FlushConsumer(ref contact_0, mount_0, ref sensor_2);
					int num8 = num7;
					for (int i = 1; i <= num8; i++)
					{
						if (weaponRec_0.CurrentLoad == 0)
						{
							break;
						}
						UnguidedWeapon unguidedWeapon_3 = new UnguidedWeapon(referenceWeapon, contact_0, myUnit, myUnit.GetLatitude(), myUnit.GetLongitude(), 0L);
						if (i == 1)
						{
							switch (contact_0.Type)
							{
							case Contact_Base.ContactType.Air:
							case Contact_Base.ContactType.Missile:
								stringBuilder.Append("标称命中率PoH：").Append(unguidedWeapon_3.AirPOK).Append("%. ");
								break;
							case Contact_Base.ContactType.Surface:
								stringBuilder.Append("标称CEP：").Append(unguidedWeapon_3.CEP_Surface).Append("米。");
								break;
							case Contact_Base.ContactType.Submarine:
								stringBuilder.Append("标称命中率PoH：").Append(unguidedWeapon_3.SubPOK).Append("%. ");
								break;
							case Contact_Base.ContactType.Facility_Fixed:
							case Contact_Base.ContactType.Facility_Mobile:
								stringBuilder.Append("标称CEP：").Append(unguidedWeapon_3.CEP_Land).Append("米。");
								break;
							}
						}
						if (unguidedWeapon_3.Type != Weapon._WeaponType.IronBomb && !myUnit.IsAircraft)
						{
							double num9 = num / referenceWeapon.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false);
							unguidedWeapon_3.CEP_Surface = (int)Math.Round((double)referenceWeapon.CEP_Surface * num9);
							unguidedWeapon_3.CEP_Land = (int)Math.Round((double)referenceWeapon.CEP_Land * num9);
							if (i == 1)
							{
								stringBuilder.Append("范围是最大值的").Append((int)Math.Round(100.0 * num9)).Append("%，CEP调整为相同。");
								myUnit.AddMessage(stringBuilder.ToString(), "CEP adjusted for range", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							}
						}
						if (i == 1)
						{
							RateConsumer(ref mount_0, unguidedWeapon_3, sensor_2, contact_0, weaponSalvo_0, stringBuilder);
						}
						else
						{
							RateConsumer(ref mount_0, unguidedWeapon_3, sensor_2, contact_0, weaponSalvo_0, null);
						}
						DefineConsumer(myUnit, ref unguidedWeapon_3, stringBuilder);
						float? num10 = (float?)ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.CurrentHeading, contact_0, unguidedWeapon_3.CurrentSpeed);
						if (!num10.HasValue)
						{
							(Geopoint_Struct, TimeSpan) tuple2 = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, Module_Unit.CalcTokenizer(unguidedWeapon_3), contact_0);
							if (!Information.IsNothing(tuple2))
							{
								num10 = Module_Unit.BearingToPoint_True(myUnit, tuple2.Item1.Latitude, tuple2.Item1.Longitude);
							}
						}
						if (num10.HasValue)
						{
							unguidedWeapon_3.CurrentHeading = num10.Value;
						}
						else
						{
							unguidedWeapon_3.CurrentHeading = myUnit.AI.BearingToUnit_True(contact_0);
						}
						unguidedWeapon_3.SetUnitSide(bool_0: false, myUnit.GetUnitSide());
						unguidedWeapon_3.SetCurrentAltitude(bool_0: false, myUnit.GetCurrentAltitude());
						myUnit.ParentScen.UnguidedWeapons.Add(unguidedWeapon_3.ObjectID, unguidedWeapon_3);
						weaponRec_0.CurrentLoad--;
						int_0++;
						list.Add(unguidedWeapon_3);
						unguidedWeapon_3.FiringParent = myUnit;
						unguidedWeapon_3.FiringParent_ID = myUnit.ObjectID;
						if (sensor_2 != null)
						{
							unguidedWeapon_3.serviceProxy = sensor_2.DBID;
						}
						switch (contact_0.Type)
						{
						case Contact_Base.ContactType.Air:
						case Contact_Base.ContactType.Missile:
							stringBuilder.Append("在发射点最终命中概率(PoH)：").Append(unguidedWeapon_3.AirPOK).Append("%. ");
							break;
						case Contact_Base.ContactType.Surface:
							stringBuilder.Append("在发射点最终毁伤半径(CEP)：").Append(unguidedWeapon_3.CEP_Surface).Append("米。");
							break;
						case Contact_Base.ContactType.Submarine:
							stringBuilder.Append("在发射点最终命中概率(PoH)：").Append(unguidedWeapon_3.SubPOK).Append("%. ");
							break;
						case Contact_Base.ContactType.Facility_Fixed:
						case Contact_Base.ContactType.Facility_Mobile:
							stringBuilder.Append("在发射点最终毁伤半径(CEP)：").Append(unguidedWeapon_3.CEP_Land).Append("米。");
							break;
						}
						myUnit.AddMessage(stringBuilder.ToString(), unguidedWeapon_3.Name + " 被攻击", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						ExportWeaponFireEvent(contact_0, unguidedWeapon_3, weaponSalvo_0);
						QueryConsumer(unguidedWeapon_3.ObjectID, mount_0);
						if (!Information.IsNothing(weaponSalvo_0))
						{
							string objectID4 = unguidedWeapon_3.ObjectID;
							ArrayExtensions.Add(ref weaponSalvo_0.WeaponList, objectID4);
						}
					}
					break;
				}
				case Weapon._WeaponType.Microwave:
				{
					UnguidedWeapon unguidedWeapon = new UnguidedWeapon(referenceWeapon, contact_0, myUnit, myUnit.GetLatitude(), myUnit.GetLongitude(), 0L);
					if (referenceWeapon.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) > 0f)
					{
						unguidedWeapon.CEP_Surface = (int)Math.Round((float)referenceWeapon.CEP_Surface_Nominal * num / referenceWeapon.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false));
						unguidedWeapon.CEP_Land = (int)Math.Round((float)referenceWeapon.CEP_Land_Nominal * num / referenceWeapon.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false));
					}
					Sensor sensor_3 = null;
					stringBuilder.Append(myUnit.Name).Append(" attacks with weapon: ").Append(weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Name)
						.Append(". ");
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						stringBuilder.Append("标称命中率PoH：").Append(unguidedWeapon.AirPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Surface:
						stringBuilder.Append("标称CEP：").Append(unguidedWeapon.CEP_Surface).Append("米。");
						break;
					case Contact_Base.ContactType.Submarine:
						stringBuilder.Append("标称命中率PoH：").Append(unguidedWeapon.SubPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						stringBuilder.Append("标称CEP：").Append(unguidedWeapon.CEP_Land).Append("米。");
						break;
					}
					FlushConsumer(ref contact_0, mount_0, ref sensor_3);
					Sensor sensor = unguidedWeapon.ReferenceWeapon.Sensors_Cached[0];
					if (sensor.MaxIlluminate <= 1)
					{
						mount_0.Boresight = Module_Unit.BearingToUnit_True(myUnit, contact_0);
					}
					else
					{
						List<Module_Unit.Unit> list3 = new List<Module_Unit.Unit>();
						foreach (UnguidedWeapon value in myUnit.ParentScen.UnguidedWeapons.Values)
						{
							if (value.FiringParent != myUnit)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon in mount_0.MountWeapons)
							{
								if (Operators.CompareString(mountWeapon.ObjectID, value.FiringWeaponRec_ID, TextCompare: false) == 0)
								{
									list3.Add(value.Target);
								}
							}
						}
						if (list3.Count == 0)
						{
							mount_0.Boresight = Module_Unit.BearingToUnit_True(myUnit, contact_0);
						}
						else
						{
							list3.Add(contact_0);
							int? num2 = BearingForSensorBoresightToCoverMultipleTargets(sensor, list3);
							if (num2.HasValue)
							{
								mount_0.Boresight = num2.Value;
							}
						}
					}
					unguidedWeapon.SetUnitSide(bool_0: false, myUnit.GetUnitSide());
					myUnit.ParentScen.UnguidedWeapons.Add(unguidedWeapon.ObjectID, unguidedWeapon);
					weaponRec_0.CurrentLoad--;
					int_0++;
					list.Add(unguidedWeapon);
					weaponRec_0.ResetTimeToFire();
					unguidedWeapon.LaunchPoint = new GeoPoint(myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude());
					unguidedWeapon.FiringParent = myUnit;
					unguidedWeapon.FiringParent_ID = myUnit.ObjectID;
					unguidedWeapon.FiringWeaponRec_ID = weaponRec_0.ObjectID;
					QueryConsumer(unguidedWeapon.ObjectID, mount_0);
					if (weaponSalvo_0 != null)
					{
						string objectID5 = unguidedWeapon.ObjectID;
						ArrayExtensions.Add(ref weaponSalvo_0.WeaponList, objectID5);
					}
					myUnit.AddMessage(stringBuilder.ToString(), unguidedWeapon.Name + " 被攻击", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					ExportWeaponFireEvent(contact_0, unguidedWeapon, weaponSalvo_0);
					break;
				}
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.Laser:
				case Weapon._WeaponType.LaserDazzler:
				{
					UnguidedWeapon unguidedWeapon_2 = new UnguidedWeapon(referenceWeapon, contact_0, myUnit, myUnit.GetLatitude(), myUnit.GetLongitude(), 0L);
					if (referenceWeapon.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false) > 0f)
					{
						unguidedWeapon_2.CEP_Surface = (int)Math.Round((float)referenceWeapon.CEP_Surface_Nominal * num / referenceWeapon.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false));
						unguidedWeapon_2.CEP_Land = (int)Math.Round((float)referenceWeapon.CEP_Land_Nominal * num / referenceWeapon.GetMaxRangeForThisTarget(myUnit, contact_0, bool_0: false, null, bool_1: false));
					}
					Sensor sensor_ = null;
					stringBuilder.Append(myUnit.Name).Append(" attacks with weapon: ").Append(weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Name)
						.Append(". ");
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						stringBuilder.Append("标称命中率PoH：").Append(unguidedWeapon_2.AirPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Surface:
						stringBuilder.Append("标称CEP：").Append(unguidedWeapon_2.CEP_Surface).Append("米。");
						break;
					case Contact_Base.ContactType.Submarine:
						stringBuilder.Append("标称命中率PoH：").Append(unguidedWeapon_2.SubPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						stringBuilder.Append("标称CEP：").Append(unguidedWeapon_2.CEP_Land).Append("米。");
						break;
					}
					FlushConsumer(ref contact_0, mount_0, ref sensor_);
					RateConsumer(ref mount_0, unguidedWeapon_2, sensor_, contact_0, weaponSalvo_0, stringBuilder);
					DefineConsumer(myUnit, ref unguidedWeapon_2, stringBuilder);
					float? num6 = (float?)ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.CurrentHeading, contact_0, unguidedWeapon_2.CurrentSpeed);
					if (!num6.HasValue)
					{
						(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, unguidedWeapon_2.CurrentSpeed, contact_0);
						if (!tuple.Item1.HasZeroCoords)
						{
							num6 = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
						}
					}
					if (num6.HasValue)
					{
						unguidedWeapon_2.CurrentHeading = num6.Value;
					}
					else
					{
						unguidedWeapon_2.CurrentHeading = myUnit.AI.BearingToUnit_True(contact_0);
					}
					unguidedWeapon_2.SetUnitSide(bool_0: false, myUnit.GetUnitSide());
					myUnit.ParentScen.UnguidedWeapons.Add(unguidedWeapon_2.ObjectID, unguidedWeapon_2);
					weaponRec_0.CurrentLoad--;
					int_0++;
					list.Add(unguidedWeapon_2);
					weaponRec_0.ResetTimeToFire();
					unguidedWeapon_2.LaunchPoint = new GeoPoint(myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude());
					unguidedWeapon_2.FiringParent = myUnit;
					unguidedWeapon_2.FiringParent_ID = myUnit.ObjectID;
					unguidedWeapon_2.FiringWeaponRec_ID = weaponRec_0.ObjectID;
					if (sensor_ != null)
					{
						unguidedWeapon_2.serviceProxy = sensor_.DBID;
					}
					QueryConsumer(unguidedWeapon_2.ObjectID, mount_0);
					if (weaponSalvo_0 != null)
					{
						string objectID3 = unguidedWeapon_2.ObjectID;
						ArrayExtensions.Add(ref weaponSalvo_0.WeaponList, objectID3);
					}
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						stringBuilder.Append("在发射点最终命中概率(PoH)：").Append(unguidedWeapon_2.AirPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Surface:
						stringBuilder.Append("在发射点最终毁伤半径(CEP)：").Append(unguidedWeapon_2.CEP_Surface).Append("米。");
						break;
					case Contact_Base.ContactType.Submarine:
						stringBuilder.Append("在发射点最终命中概率(PoH)：").Append(unguidedWeapon_2.SubPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						stringBuilder.Append("在发射点最终毁伤半径(CEP)：").Append(unguidedWeapon_2.CEP_Land).Append("米。");
						break;
					}
					myUnit.AddMessage(stringBuilder.ToString(), unguidedWeapon_2.Name + " 被攻击", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					ExportWeaponFireEvent(contact_0, unguidedWeapon_2, weaponSalvo_0);
					break;
				}
				case Weapon._WeaponType.Dispenser:
				{
					Weapon newWeapon3 = Weapon.GetNewWeapon(ref myUnit.ParentScen, weaponRec_0.int_0, bool_0: false);
					Warhead[] warheads = newWeapon3.Warheads;
					Warhead[] array = warheads;
					foreach (Warhead warhead in array)
					{
						new Explosion(ref myUnit.ParentScen, contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), contact_0.GetLatitude(), myUnit.CurrentHeading, myUnit.GetCurrentAltitude(), referenceWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, 10f, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads).CurrentHeading = myUnit.CurrentHeading;
					}
					weaponRec_0.CurrentLoad--;
					int_0++;
					list.Add(newWeapon3);
					weaponRec_0.ResetTimeToFire();
					ExportWeaponFireEvent(contact_0, newWeapon3, weaponSalvo_0);
					QueryConsumer(newWeapon3.ObjectID, mount_0);
					if (!Information.IsNothing(weaponSalvo_0))
					{
						string objectID2 = newWeapon3.ObjectID;
						ArrayExtensions.Add(ref weaponSalvo_0.WeaponList, objectID2);
					}
					break;
				}
				}
				break;
			case Weapon._WeaponType.GuidedWeapon:
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.Decoy_Vehicle:
			case Weapon._WeaponType.GuidedProjectile:
			case Weapon._WeaponType.UAV_Expendable:
			case Weapon._WeaponType.Torpedo:
			case Weapon._WeaponType.BallisticMissile:
			case Weapon._WeaponType.RV:
			case Weapon._WeaponType.PalletWeapon:
			case Weapon._WeaponType.HGV:
				try
				{
					int num5 = 0;
					while (num5 <= int_1 && (myUnit.IsPalletWeapon || weaponRec_0.TimeToFire == 0f) && weaponRec_0.CurrentLoad != 0)
					{
						Weapon weapon_ = Weapon.GetNewWeapon(ref myUnit.ParentScen, weaponRec_0.int_0, bool_0: false);
						weapon_.CEP_Surface = weapon_.CEP_Surface_Nominal;
						weapon_.CEP_Land = weapon_.CEP_Land_Nominal;
						try
						{
							if (myUnit.IsAircraft)
							{
								weapon_.FiringParent = (Aircraft)myUnit;
								CalcConsumer(float_0, myUnit, weapon_, weaponRec_0.int_0, contact_0, mount_0, myUnit.CurrentHeading, ActiveUnit.Throttle.Cruise, positionRelativeToThermocline_0, weaponSalvo_0);
							}
							else
							{
								CalcConsumer(float_0, myUnit, weapon_, weaponRec_0.int_0, contact_0, mount_0, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()), ActiveUnit.Throttle.Cruise, positionRelativeToThermocline_0, weaponSalvo_0);
							}
							if (myUnit.IsWeapon)
							{
								weapon_.FiringParent = ((Weapon)myUnit).FiringParent;
							}
							QueryConsumer(weapon_.ObjectID, mount_0);
							if (weaponSalvo_0 == null)
							{
								if (myUnit.IsWeapon)
								{
									if (contact_0.Type == Contact_Base.ContactType.Aimpoint)
									{
										List<Contact> list2 = new List<Contact>();
										if (myUnit.AI.Targets_ReadOnly.Length != 0)
										{
											list2.AddRange(myUnit.AI.Targets_ReadOnly);
										}
										if (myUnit.AI.PrimaryTarget != null && myUnit.AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
										{
											list2.Add(myUnit.AI.PrimaryTarget);
										}
										if (list2.Count != 0)
										{
											list2 = list2.OrderBy((Contact theC) => Geodesic_Haversine.Distance_Horiz_Approx_nm(theC.GetLatitude(), theC.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude())).ToList();
											contact_0 = list2[0];
										}
									}
									weapon_.CreateSalvo_Airborne(ref weapon_, ref contact_0, myUnit.ParentScen);
								}
							}
							else
							{
								string objectID = weapon_.ObjectID;
								ArrayExtensions.Add(ref weaponSalvo_0.WeaponList, objectID);
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 100333", "");
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						weaponRec_0.CurrentLoad--;
						weaponRec_0.ResetTimeToFire();
						if (weapon_.ValidTargets.Radar && !Information.IsNothing(referenceWeapon.ARM_SpecifiedEMission) && referenceWeapon.ARM_SpecifiedEMission.Key != 0)
						{
							weapon_.ARM_SpecifiedEMission = referenceWeapon.ARM_SpecifiedEMission;
							weapon_.ARM_SpecifiedEmissionIsMandatory = true;
						}
						if (weapon_.Type == Weapon._WeaponType.RV || weapon_.Type == Weapon._WeaponType.HGV)
						{
							weapon_.CEP_Surface = ((Weapon)myUnit).CEP_Surface;
							weapon_.CEP_Land = ((Weapon)myUnit).CEP_Land;
						}
						int_0++;
						list.Add(weapon_);
						if (weapon_.Flags.SearchPattern)
						{
							if (myUnit.IsAircraft && weapon_.IsTorpedo)
							{
								weapon_.SearchPatternType = Weapon.WeaponSearchPatternType.Circle;
							}
							else
							{
								weapon_.SearchPatternType = Weapon.WeaponSearchPatternType.Snake;
							}
						}
						num5++;
						if (weapon_.IsPalletWeapon)
						{
							myUnit.GetUnitSide().PublishOrder();
						}
						num5++;
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 100332", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case Weapon._WeaponType.Aircraft:
				{
					Scenario parentScen = myUnit.ParentScen;
					parentScen.UnitsAutoIncrement++;
					Aircraft aircraft = parentScen.AddNewAircraft(myUnit.GetUnitSide(), referenceWeapon.Name + " #" + Conversions.ToString(parentScen.UnitsAutoIncrement), myUnit.GetLongitude(), myUnit.GetLatitude(), (int)Math.Round(referenceWeapon.Warheads[0].DP), 0, Math.Max(myUnit.GetCurrentAltitude(), 1f));
					if (contact_0 != null)
					{
						aircraft.Navigator.AddWaypoint(new Waypoint(contact_0.GetLongitude(), contact_0.GetLatitude(), myUnit.GetCurrentAltitude(), Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
					weaponRec_0.CurrentLoad--;
					weaponRec_0.ResetTimeToFire();
					list.Add(referenceWeapon);
					int_0++;
					break;
				}
				IL_225b:
				activeUnit = myUnit;
				nullable_ = null;
				double_ = activeUnit.GetLongitude(nullable_);
				activeUnit2 = myUnit;
				nullable_2 = null;
				double_2 = activeUnit2.GetLatitude(nullable_2);
				double_3 = geoPoint.Longitude;
				double_4 = geoPoint.Latitude;
				double_5 = 0.3;
				Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_3, ref double_4, ref double_5, ref num3);
				geoPoint.Latitude = double_4;
				geoPoint.Longitude = double_3;
				activeUnit2.SetLatitude(nullable_2, double_2);
				activeUnit.SetLongitude(nullable_, double_);
				if (myUnit.AI.MiningInfo == null)
				{
					myUnit.Navigator.AddWaypoint(geoPoint.Latitude, geoPoint.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint.Latitude, geoPoint.Longitude)));
					break;
				}
				sequence2 = myUnit.AI.MiningInfo.Sequence;
				if ((sequence2.HasValue ? new bool?(sequence2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					myUnit.AI.MiningInfo = null;
					myUnit.Navigator.PreviousWaypointTime = null;
					myUnit.Navigator.PreviousWaypointLatitude = null;
					myUnit.Navigator.PreviousWaypointLongitude = null;
					myUnit.Navigator.PreviousWaypointType = null;
					myUnit.Navigator.PlotCourseToArea(miningMission.Area);
				}
				else
				{
					myUnit.Navigator.AddWaypoint(geoPoint.Latitude, geoPoint.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint.Latitude, geoPoint.Longitude)));
				}
				break;
			}
			if (myUnit.IsAircraft && referenceWeapon.EmptyWeight > 0 && ((Aircraft)myUnit).Loadout.PayloadWeight > 0)
			{
				AdjustLoadoutPayloadWeight();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100331", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
			for (int j = 0; j < sides_ReadOnly.Length; j = checked(j + 1))
			{
				sides_ReadOnly[j].HandleUnitHasFiredWeapon(myUnit, contact_0, weaponRec_0);
			}
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 100330", "");
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (list.Count <= 0)
			{
				return list;
			}
			try
			{
				myUnit.GetUnitSide().AAR.AddToExpenditures(weaponRec_0.int_0, list.Count);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			FiredWeaponEventHandler firedWeaponEventHandler = globalWrapper;
			if (firedWeaponEventHandler == null)
			{
				return list;
			}
			firedWeaponEventHandler(myUnit.ParentScen, myUnit, referenceWeapon);
			return list;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at 100328", "");
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	internal List<Module_Unit.Unit> MapConsumer(ref WeaponRec weaponRec_0, Contact contact_0, ref List<string> list_0, ref int int_0, HashSet<int> hashSet_0)
	{
		if (contact_0 != null)
		{
			Module_Unit.RangeToUnit_Horiz(myUnit, contact_0);
		}
		Weapon referenceWeapon = weaponRec_0.GetReferenceWeapon(myUnit.ParentScen);
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		new StringBuilder();
		try
		{
			bool flag;
			if ((uint)(referenceWeapon.Type - 2005) <= 1u)
			{
				if (hashSet_0.Contains(referenceWeapon.DBID))
				{
					flag = false;
				}
				else
				{
					Weapon weapon_ = (Weapon)contact_0.ActualUnit;
					flag = referenceWeapon.ResolveDecoyAttempt(ref weapon_, ref myUnit, ref list_0);
					hashSet_0.Add(referenceWeapon.DBID);
				}
			}
			else
			{
				new UnguidedWeapon(referenceWeapon, contact_0, myUnit, myUnit.GetLatitude(), myUnit.GetLongitude(), 0L);
				flag = referenceWeapon.ResolveImpact(contact_0.ActualUnit, myUnit.ParentScen, bool_0: true, ref list_0);
			}
			if (referenceWeapon.Type == Weapon._WeaponType.Decoy_Towed)
			{
				if (flag && GameGeneral.LockRandom_0.Next(0, 101) > 50)
				{
					weaponRec_0.CurrentLoad--;
					int_0 = 1;
					list.Add(referenceWeapon);
				}
			}
			else
			{
				weaponRec_0.CurrentLoad--;
				weaponRec_0.ResetTimeToFire();
				int_0 = 1;
				list.Add(referenceWeapon);
			}
			if (myUnit.IsAircraft && referenceWeapon.EmptyWeight > 0 && ((Aircraft)myUnit).Loadout.PayloadWeight > 0)
			{
				AdjustLoadoutPayloadWeight();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1003245023495023495", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				sides_ReadOnly[i].HandleUnitHasFiredWeapon(myUnit, contact_0, weaponRec_0);
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 1023450923845902386524598", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (list.Count <= 0)
			{
				return list;
			}
			try
			{
				myUnit.GetUnitSide().AAR.AddToExpenditures(weaponRec_0.int_0, list.Count);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			FiredWeaponEventHandler firedWeaponEventHandler = globalWrapper;
			if (firedWeaponEventHandler == null)
			{
				return list;
			}
			firedWeaponEventHandler(myUnit.ParentScen, myUnit, referenceWeapon);
			return list;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 10354329054823906834905634", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	public void AdjustLoadoutPayloadWeight()
	{
		try
		{
			if (!Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				Loadout loadout_ = ((Aircraft)myUnit).Loadout;
				DBFunctions.GetLoadoutPayloadTakeOffWeight_Current(ref myUnit.ParentScen, ref loadout_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100334", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SortConsumer(Weapon weapon_0, Contact contact_0)
	{
		try
		{
			if (contact_0 != null)
			{
				if (weapon_0.IsMobileDecoy && weapon_0.Warheads.Count() == 0 && contact_0.Type != Contact_Base.ContactType.ActivationPoint)
				{
					double latitude = contact_0.GetLatitude();
					double longitude = contact_0.GetLongitude();
					if (contact_0.UncertaintyArea != null)
					{
						Geopoint_Struct geopoint_Struct = Misc.Center(contact_0.UncertaintyArea);
						double latitude2 = geopoint_Struct.Latitude;
						double longitude2 = geopoint_Struct.Longitude;
						bool bool_ = true;
						bool bool_2 = false;
						List<ActiveUnit> list_ = null;
						string string_ = "";
						bool bool_3 = false;
						int int_ = 0;
						if (weapon_0.CanMoveToThisLocation(latitude2, longitude2, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_, bool_4: false, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
						{
							latitude = geopoint_Struct.Latitude;
							longitude = geopoint_Struct.Longitude;
						}
						else
						{
							Weapon_Navigator navigator = weapon_0.Navigator;
							double latitude3 = weapon_0.GetLatitude();
							double longitude3 = weapon_0.GetLongitude();
							double latitude4 = geopoint_Struct.Latitude;
							double longitude4 = geopoint_Struct.Longitude;
							list_ = null;
							GeoPoint geoPoint = navigator.LastAccessiblePointOnPath(latitude3, longitude3, latitude4, longitude4, 0f, null, 0f, ref list_);
							if (geoPoint != null)
							{
								latitude = geoPoint.Latitude;
								longitude = geoPoint.Longitude;
							}
						}
					}
					weapon_0.AI.PrimaryTarget = new ActivationPointContact(latitude, longitude);
					weapon_0.AI.PrimaryTarget_Type = Contact_Base.ContactType.ActivationPoint;
				}
				else if (contact_0.Type == Contact_Base.ContactType.ActivationPoint && weapon_0.Flags.LoiterCapability)
				{
					float num = Math.Min(weapon_0.GetCurrentAltitude(), weapon_0.Kinematics.GetMaximumAltitude());
					if (weapon_0.CruiseAltitude_ASL <= num)
					{
						if (weapon_0.CruiseAltitude_AGL > 0f)
						{
							num = Math.Max(num, weapon_0.CruiseAltitude_AGL + (float)Terrain.GetElevation(contact_0.GetLatitude(), contact_0.GetLongitude(), bool_0: false, myUnit.ParentScen));
						}
					}
					else
					{
						num = weapon_0.CruiseAltitude_ASL;
					}
					weapon_0.AI.PrimaryTarget = new ActivationPointContact(contact_0.GetLatitude(), contact_0.GetLongitude());
					weapon_0.AI.PrimaryTarget.SetCurrentAltitude(bool_0: false, num);
				}
			}
			if (weapon_0.isUAV)
			{
				weapon_0.DesiredAltitude = weapon_0.Kinematics.GetMaximumAltitude();
			}
			if (!Information.IsNothing(contact_0) && weapon_0.IsMissile && (contact_0.Type == Contact_Base.ContactType.Submarine || contact_0.Type == Contact_Base.ContactType.Submarine || contact_0.Type == Contact_Base.ContactType.ActivationPoint || weapon_0.AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint) && weapon_0.HasTorpedoPayload)
			{
				if (weapon_0.Sensors_ReadOnly().Length != 0)
				{
					weapon_0.ClearAllSensors();
					weapon_0.DetermineGuidance();
				}
				if (weapon_0.Comms_ReadOnly.Length != 0)
				{
					weapon_0.ClearAllComms();
					weapon_0.DetermineGuidance();
				}
			}
			if (Information.IsNothing(contact_0) || Information.IsNothing(contact_0.ActualUnit) || !weapon_0.IsMissile || contact_0.Type != Contact_Base.ContactType.Facility_Fixed || weapon_0.Sensors_ReadOnly().Length == 0)
			{
				return;
			}
			bool flag = false;
			Sensor[] array = weapon_0.Sensors_ReadOnly();
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				if (array[i].GetIsSuitableForThisTarget(contact_0.ActualUnit))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Sensor[] gparam_ = weapon_0.Sensors_ReadOnly();
				ArrayExtensions.Clear(ref gparam_);
				weapon_0.DetermineGuidance();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100335", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalcConsumer(float float_0, ActiveUnit activeUnit_0, Weapon weapon_0, int int_0, Contact contact_0, Mount mount_0, float float_1 = 0f, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Cruise, SonarModel.PositionRelativeToThermocline positionRelativeToThermocline_0 = SonarModel.PositionRelativeToThermocline.Above, WeaponSalvo weaponSalvo_0 = null)
	{
		try
		{
			weapon_0.FiringParent = activeUnit_0;
			if (!activeUnit_0.Weaponry.bool_0 && CancelConsumer(weapon_0, contact_0))
			{
				Weapon.RecalculateWeaponFlightEnergyIfNecessary(weapon_0, activeUnit_0.ParentScen, myUnit.IsAircraft || myUnit.IsMissile);
			}
			activeUnit_0.ParentScen.UnitsAutoIncrement = activeUnit_0.ParentScen.UnitsAutoIncrement + 1;
			weapon_0.Name = weapon_0.Name + " #" + Conversions.ToString(activeUnit_0.ParentScen.UnitsAutoIncrement);
			weapon_0.SetUnitSide(bool_0: false, activeUnit_0.GetUnitSide());
			weapon_0.AI.PrimaryTarget = contact_0;
			if (contact_0 != null)
			{
				weapon_0.AI.PrimaryTarget_Type = contact_0.Type;
			}
			if (!(activeUnit_0.CurrentSpeed <= 0f) && !weapon_0.IsReEntryVehicle)
			{
				weapon_0.SetLongitude(null, activeUnit_0.GetLongitude_next(float_0));
				weapon_0.SetLatitude(null, activeUnit_0.GetLatitude_next(float_0));
			}
			else
			{
				weapon_0.SetLongitude(null, activeUnit_0.GetLongitude());
				weapon_0.SetLatitude(null, activeUnit_0.GetLatitude());
			}
			if (weapon_0.IsMissile)
			{
				weapon_0.SetCurrentAltitude(bool_0: true, Math.Max(0f, activeUnit_0.GetCurrentAltitude()));
				if (weapon_0.FiringParent.IsFacility || weapon_0.FiringParent.IsVehicle)
				{
					Weapon weapon;
					(weapon = weapon_0).SetCurrentAltitude(bool_0: true, weapon.GetCurrentAltitude(bool_0: true) + 2f);
				}
			}
			else
			{
				weapon_0.SetCurrentAltitude(bool_0: true, activeUnit_0.GetCurrentAltitude());
			}
			if (weapon_0.IsPalletWeapon)
			{
				weapon_0.DesiredPitch = -85f;
				weapon_0.Attitude_Pitch = activeUnit_0.Attitude_Pitch;
				weapon_0.CurrentSpeed = activeUnit_0.CurrentSpeed;
				weapon_0.ThrottleSetting = ActiveUnit.Throttle.Cruise;
				weapon_0.CurrentHeading = activeUnit_0.CurrentHeading;
			}
			if (weapon_0.IsTorpedo && (int)weapon_0.MaxPossibleThrottleSetting >= 3)
			{
				Scenario parentScen = myUnit.ParentScen;
				int dBID = weapon_0.DBID;
				ActiveUnit activeUnit_ = myUnit;
				double longitude = myUnit.GetLongitude();
				double latitude = myUnit.GetLatitude();
				float float_2 = (int)Math.Round(myUnit.GetCurrentAltitude());
				int int_ = (int)Math.Round(myUnit.CurrentSpeed);
				double longitude2 = contact_0.GetLongitude();
				double latitude2 = contact_0.GetLatitude();
				float currentHeading = contact_0.CurrentHeading;
				bool headingIsKnown = contact_0.HeadingIsKnown;
				int int_2 = (int)Math.Round(contact_0.CurrentSpeed);
				bool speedIsKnown = contact_0.SpeedIsKnown;
				float currentAltitude = contact_0.GetCurrentAltitude();
				bool altitudeIsKnown = contact_0.AltitudeIsKnown;
				float float_3 = Module_Unit.RateTokenizer(contact_0, myUnit.ParentScen);
				Contact_Base.ContactType type = contact_0.Type;
				GeoPoint geoPoint_ = null;
				string string_ = null;
				int int_3 = (int)Math.Round((double)(float)weapon_0.Fuel_ReadOnly[0].MaxQuantity * 0.8999999985098839);
				float float_4 = 0f;
				if (TargetIsWithinDLZ(parentScen, dBID, activeUnit_, longitude, latitude, float_2, int_, longitude2, latitude2, currentHeading, headingIsKnown, int_2, speedIsKnown, currentAltitude, altitudeIsKnown, float_3, type, ref geoPoint_, ref string_, bool_4: false, 0f, ActiveUnit.Throttle.Full, int_3, null, null, ref float_4).Item1 == DLZResultEnum.Success)
				{
					throttle_0 = ActiveUnit.Throttle.Full;
				}
			}
			weapon_0.SetThrottle(throttle_0);
			float currentSpeed = weapon_0.Kinematics.GetMaximumSpeed(weapon_0.GetCurrentAltitude(), throttle_0, bool_0: false);
			if (weapon_0.IsTorpedo)
			{
				weapon_0.CurrentSpeed = currentSpeed;
			}
			else if (weapon_0.Type == Weapon._WeaponType.GuidedProjectile)
			{
				weapon_0.CurrentSpeed = currentSpeed;
			}
			else if (weapon_0.IsReEntryVehicle)
			{
				weapon_0.CurrentSpeed = activeUnit_0.CurrentSpeed;
			}
			else
			{
				weapon_0.CurrentSpeed = activeUnit_0.CurrentSpeed + weapon_0.Kinematics.Acceleration_Actual(weapon_0.ThrottleSetting, myUnit.GetCurrentAltitude(), myUnit.CurrentSpeed);
			}
			if (weapon_0.Type == Weapon._WeaponType.Sonobuoy)
			{
				weapon_0.CurrentSpeed = 0f;
			}
			weapon_0.DesiredSpeed = weapon_0.CurrentSpeed;
			SortConsumer(weapon_0, contact_0);
			if (weapon_0.IsHGV && activeUnit_0.IsMissile)
			{
				ActiveUnit_Navigator navigator = activeUnit_0.Navigator;
				if (navigator != null && navigator.HasPlottedCourse())
				{
					weapon_0.Navigator.PlottedCourse = activeUnit_0.Navigator.PlottedCourse;
					Waypoint waypoint = weapon_0.Navigator.PlottedCourse[0];
					float_1 = Module_Unit.BearingToPoint_True(activeUnit_0, waypoint.Latitude, waypoint.Longitude);
				}
			}
			if (float_1 == 0f)
			{
				if (activeUnit_0.IsAircraft)
				{
					weapon_0.CurrentHeading = activeUnit_0.CurrentHeading;
				}
				else if (activeUnit_0.IsSubmarine)
				{
					if (weapon_0.IsAAW)
					{
						weapon_0.CurrentHeading = Math2.PublishClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), weapon_0.AI.PrimaryTarget.GetLatitude(), weapon_0.AI.PrimaryTarget.GetLongitude());
					}
					else
					{
						weapon_0.CurrentHeading = activeUnit_0.CurrentHeading;
					}
				}
				else
				{
					weapon_0.CurrentHeading = Math2.PublishClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), weapon_0.AI.PrimaryTarget.GetLatitude(), weapon_0.AI.PrimaryTarget.GetLongitude());
				}
			}
			else
			{
				weapon_0.CurrentHeading = float_1;
			}
			if (weapon_0.DesiredHeading == 0f)
			{
				weapon_0.SetDesiredHeading(ActiveUnit.TurnRate.Max, weapon_0.CurrentHeading);
			}
			if (weapon_0.IsGuidedProjectile && !activeUnit_0.IsAircraft)
			{
				double? num = ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.CurrentHeading, weapon_0.AI.PrimaryTarget, weapon_0.CurrentSpeed);
				if (!num.HasValue)
				{
					(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, weapon_0.CurrentSpeed, contact_0);
					if (!Information.IsNothing(tuple))
					{
						num = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
					}
				}
				if (num.HasValue)
				{
					weapon_0.CurrentHeading = (float)num.Value;
					weapon_0.SetDesiredHeading(ActiveUnit.TurnRate.Max, (float)num.Value);
				}
			}
			if (weapon_0.AI.PrimaryTarget != null && weapon_0.Comms_ReadOnly.Count() == 0 && weapon_0.AI.PrimaryTarget.IsLandContact && weapon_0.Flags.Navigation_INS_GPS && !weapon_0.ValidTargets.Radar && weapon_0.AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint && weapon_0.ValidTargets.SurfaceVessel)
			{
				Sensor[] array = weapon_0.Sensors_ReadOnly();
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					if (array[i].Type == Sensor.Sensor_Type.Radar)
					{
						weapon_0.GoDumb(bool_0: false);
						break;
					}
				}
			}
			if (contact_0 != null)
			{
				if (weapon_0.SupportsWaypoints && activeUnit_0.IsAircraft && ((activeUnit_0.Navigator.IsOnAutoPlannerPlottedCourse && !Information.IsNothing(activeUnit_0.Navigator.PlottedCourse[0].Time_Zulu)) || (activeUnit_0.IsGroupMember() && !Information.IsNothing(activeUnit_0.GetParentGroup().GroupLead) && activeUnit_0.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse && !Information.IsNothing(activeUnit_0.GetParentGroup().GroupLead.Navigator.PlottedCourse[0].Time_Zulu))))
				{
					if (weapon_0.AI.PrimaryTarget != null)
					{
						weapon_0.Navigator.AddWaypoint(new Waypoint(weapon_0.AI.PrimaryTarget.GetLongitude(), weapon_0.AI.PrimaryTarget.GetLatitude(), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
				}
				else if (weaponSalvo_0 != null && weaponSalvo_0.PlottedCourse != null)
				{
					if (weaponSalvo_0.PlottedCourse.Count() <= 0)
					{
						if (weapon_0.SupportsWaypoints)
						{
							Weapon_Navigator navigator2 = weapon_0.Navigator;
							if (navigator2 != null && !navigator2.HasPlottedCourse())
							{
								weapon_0.Navigator.FindDescriptor(activeUnit_0);
								Waypoint[] plottedCourse2 = weapon_0.Navigator.PlottedCourse;
								Waypoint[] array3 = plottedCourse2;
								foreach (Waypoint waypoint2 in array3)
								{
									ArrayExtensions.Add(ref weaponSalvo_0.PlottedCourse, new Waypoint(waypoint2.Longitude, waypoint2.Latitude, 0f, waypoint2.Type, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse));
								}
							}
						}
					}
					else
					{
						float num2 = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), weaponSalvo_0.PlottedCourse[0].Latitude, weaponSalvo_0.PlottedCourse[0].Longitude);
						int num3 = weaponSalvo_0.PlottedCourse.Count() - 2;
						for (int j = 0; j <= num3; j++)
						{
							num2 += Math2.VerifyClass(weaponSalvo_0.PlottedCourse[j].Latitude, weaponSalvo_0.PlottedCourse[j].Longitude, weaponSalvo_0.PlottedCourse[j + 1].Latitude, weaponSalvo_0.PlottedCourse[j + 1].Longitude);
						}
						num2 += Math2.VerifyClass(weaponSalvo_0.PlottedCourse.Last().Latitude, weaponSalvo_0.PlottedCourse.Last().Longitude, contact_0.GetLatitude(), contact_0.GetLongitude());
						if (weapon_0.GetMaxRangeForThisTarget(activeUnit_0, contact_0, bool_0: false, activeUnit_0.Doctrine, bool_1: false) < num2)
						{
							weapon_0.Navigator.FindDescriptor(activeUnit_0);
						}
						else
						{
							Waypoint[] plottedCourse = weaponSalvo_0.PlottedCourse;
							Waypoint[] array4 = plottedCourse;
							foreach (Waypoint waypoint3 in array4)
							{
								weapon_0.Navigator.AddWaypoint(new Waypoint(waypoint3.Longitude, waypoint3.Latitude, 0f, waypoint3.Type, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse));
							}
						}
					}
				}
			}
			if (contact_0 != null && (weapon_0.Is_LOAL_capable || weapon_0.Guidance == Weapon.WeaponGuidanceType.Inertial || (weapon_0.HasTorpedoPayload && (weapon_0.AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || weapon_0.AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || weapon_0.AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint))))
			{
				float num4 = contact_0.GetCurrentAltitude();
				float minimumAltitude = weapon_0.Kinematics.GetMinimumAltitude();
				float maximumAltitude = weapon_0.Kinematics.GetMaximumAltitude();
				if (num4 > maximumAltitude)
				{
					num4 = maximumAltitude;
				}
				if (num4 < minimumAltitude)
				{
					num4 = minimumAltitude;
				}
				if (weapon_0.IsBallisticMissile)
				{
					ConnectFacade(weapon_0);
				}
				else
				{
					float float_5 = ((weapon_0.CruiseAltitude_AGL != 0f) ? ((float)weapon_0.Kinematics.GetMaximumSpeed(weapon_0.CruiseAltitude_AGL, throttle_0, bool_0: false)) : ((weapon_0.CruiseAltitude_ASL == 0f) ? ((float)weapon_0.Kinematics.GetMaximumSpeed(num4, throttle_0, bool_0: false)) : ((float)weapon_0.Kinematics.GetMaximumSpeed(weapon_0.CruiseAltitude_ASL, throttle_0, bool_0: false))));
					weapon_0.Navigator.CalculateDescriptor(float_5, activeUnit_0.IsAircraft && weapon_0.IsTorpedo);
				}
				if (weaponSalvo_0 != null && weaponSalvo_0.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
				{
					if (weapon_0.CruiseAltitude_AGL <= 0f)
					{
						if (weapon_0.CruiseAltitude_ASL <= 0f)
						{
							weapon_0.Navigator.PlottedCourse[0].Altitude = weapon_0.Kinematics.GetMaximumAltitude();
						}
						else
						{
							weapon_0.Navigator.PlottedCourse[0].Altitude = weapon_0.CruiseAltitude_ASL;
						}
					}
					else
					{
						weapon_0.Navigator.PlottedCourse[0].Altitude = weapon_0.CruiseAltitude_AGL;
					}
				}
				if (weapon_0.IsReEntryVehicle && !weapon_0.HasTerminalGuidance && activeUnit_0.Navigator.HasPlottedCourse() && weapon_0.Navigator.HasPlottedCourse())
				{
					weapon_0.Navigator.PlottedCourse.Last().Altitude = Math.Min(activeUnit_0.Navigator.PlottedCourse.Last().Altitude, activeUnit_0.GetCurrentAltitude());
				}
				if (weapon_0.Navigator.HasNonPathfindPlottedCourse())
				{
					weapon_0.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(weapon_0.GetLatitude(), weapon_0.GetLongitude(), weapon_0.Navigator.PlottedCourse[0].Latitude, weapon_0.Navigator.PlottedCourse[0].Longitude));
				}
			}
			if (weapon_0.Type == Weapon._WeaponType.Sonobuoy)
			{
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(weapon_0.GetLatitude(), weapon_0.GetLongitude(), weapon_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen), weapon_0.ParentScen);
				if (positionRelativeToThermocline_0 == SonarModel.PositionRelativeToThermocline.Above)
				{
					weapon_0.SetCurrentAltitude(bool_0: true, -40f);
					weapon_0.m_ObserverReader = 120f;
				}
				else
				{
					if (thermalLayerAtThisLocation.Strength <= 0f)
					{
						weapon_0.SetCurrentAltitude(bool_0: true, (float)Math.Min(-40.0, Math.Max(-300.0, (double)weapon_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen) / 2.0)));
					}
					else
					{
						weapon_0.SetCurrentAltitude(bool_0: true, thermalLayerAtThisLocation.Floor - 20);
					}
					weapon_0.m_ObserverReader = 240f;
				}
				weapon_0.DesiredAltitude = weapon_0.GetCurrentAltitude();
			}
			if (weapon_0.Guidance == Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active)
			{
				weapon_0.DataLinkParent = activeUnit_0;
			}
			Warhead[] warheads = weapon_0.Warheads;
			Warhead[] array5 = warheads;
			foreach (Warhead warhead in array5)
			{
				if ((warhead.Type == Warhead.WarheadType.Weapon) & !weapon_0.IsPalletWeapon)
				{
					warhead.GetCarriedWeapon(weapon_0.ParentScen).AI.PrimaryTarget = weapon_0.AI.PrimaryTarget;
					warhead.GetCarriedWeapon(weapon_0.ParentScen).AI.PrimaryTarget_Type = weapon_0.AI.PrimaryTarget.Type;
				}
			}
			if (activeUnit_0.IsAircraft && weapon_0.IsTorpedo)
			{
				Sensor[] array2 = weapon_0.Sensors_ReadOnly();
				Sensor[] array6 = array2;
				foreach (Sensor sensor in array6)
				{
					if (sensor.CanBeActive)
					{
						sensor.GoActive();
					}
				}
			}
			if (weapon_0.IsMIRVedMissile.Value)
			{
				weapon_0.Warheads[0].GetCarriedWeapon(activeUnit_0.ParentScen).AI.PrimaryTarget = weapon_0.AI.PrimaryTarget;
				weapon_0.Warheads[0].GetCarriedWeapon(activeUnit_0.ParentScen).AI.PrimaryTarget_Type = weapon_0.AI.PrimaryTarget.Type;
				((BallisticMissile_AI)weapon_0.AI).method_0();
			}
			if ((weapon_0.Warheads.Any() & !weapon_0.IsPalletWeapon) && weapon_0.Warheads[0].Type == Warhead.WarheadType.EMP_Directed)
			{
				Contact[] targets_ReadOnly = activeUnit_0.AI.Targets_ReadOnly;
				Contact[] array7 = targets_ReadOnly;
				foreach (Contact contact in array7)
				{
					if (contact != contact_0 && activeUnit_0.AI.IsClearedToEngageThisTarget(contact_0))
					{
						weapon_0.AI.TargetThisContact(contact, bool_0: false, bool_1: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
			weapon_0.Kinematics.IncludeDescriptor(activeUnit_0, contact_0);
			if (weapon_0.IsBallisticMissile && weapon_0.Warheads.Any() && weapon_0.Warheads[0].Type == Warhead.WarheadType.Weapon)
			{
				Weapon carriedWeapon = weapon_0.Warheads[0].GetCarriedWeapon(myUnit.ParentScen);
				if (weapon_0.CruiseAltitude_ASL > 0f)
				{
					float maximumAltitude2 = carriedWeapon.Kinematics.GetMaximumAltitude();
					if (weapon_0.CruiseAltitude_ASL > maximumAltitude2)
					{
						weapon_0.CruiseAltitude_ASL = maximumAltitude2 - 10f;
					}
				}
			}
			if (weapon_0.SupportsAttitude_Pitch)
			{
				if (myUnit.IsAircraft && !((Aircraft)myUnit).IsHelicopter)
				{
					weapon_0.Attitude_Pitch = myUnit.Attitude_Pitch;
				}
				else if (weapon_0.IsHGV)
				{
					weapon_0.Attitude_Pitch = activeUnit_0.Attitude_Pitch;
				}
				else if (!weapon_0.IsASuW_Land && !weapon_0.IsASuW_Naval)
				{
					if (weapon_0.CalculateReponse() || (mount_0 != null && mount_0.IsVLS) || (weapon_0.IsAAW_GuidedMissile && (myUnit.IsFacility || myUnit.IsMobileGroundUnit)))
					{
						weapon_0.Attitude_Pitch = 90f;
					}
				}
				else if (mount_0 != null)
				{
					if (weapon_0.IsBallisticMissile)
					{
						weapon_0.Attitude_Pitch = 90f;
					}
					else if (mount_0.IsVLS)
					{
						weapon_0.Attitude_Pitch = 90f;
					}
					else if (mount_0.IsRail && contact_0.AltitudeIsKnown)
					{
						float num5 = (float)((double)Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()) * 1852.0);
						weapon_0.Attitude_Pitch = (int)Math.Round(Math2.CompareClass(num5 / contact_0.GetCurrentAltitude()));
						if (weapon_0.Attitude_Pitch < 0f)
						{
							weapon_0.Attitude_Pitch = 0f;
						}
					}
					else
					{
						weapon_0.Attitude_Pitch = 45f;
					}
				}
				if (weapon_0.Type == Weapon._WeaponType.RV)
				{
					weapon_0.Attitude_Pitch = 0f - (float)Geodesic_Vincenty.EnableInvocation(Module_Unit.RangeToUnit_Horiz(myUnit, contact_0), myUnit.GetCurrentAltitude(), contact_0.GetCurrentAltitude());
				}
			}
			ForgotConsumer(ref activeUnit_0, ref weapon_0, ref contact_0);
			CollectConsumer(activeUnit_0, weapon_0, contact_0);
			weapon_0.LaunchPoint = new GeoPoint(weapon_0.GetLongitude(), weapon_0.GetLatitude(), weapon_0.GetCurrentAltitude());
			weapon_0.Altitude_old = myUnit.Altitude_old;
			activeUnit_0.ParentScen.AddThisUnit(weapon_0);
			if (contact_0 != null)
			{
				if (myUnit.GetUnitSide().processProxy.ContainsKey(contact_0.ObjectID))
				{
					myUnit.GetUnitSide().processProxy[contact_0.ObjectID]++;
				}
				else
				{
					myUnit.GetUnitSide().processProxy.TryAdd(contact_0.ObjectID, 1);
				}
			}
			ExportWeaponFireEvent(contact_0, weapon_0, weaponSalvo_0);
			weapon_0.Kinematics.ExportLocationEvent(bool_0: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100336", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ExportWeaponFireEvent(Contact contact_0, Module_Unit.Unit unit_0, WeaponSalvo weaponSalvo_0)
	{
		if (contact_0 == null)
		{
			return;
		}
		foreach (IEventExporter applicableEventExporter in myUnit.ParentScen.ApplicableEventExporters)
		{
			if (!applicableEventExporter.IsOperating || !applicableEventExporter.ExportWeaponFired)
			{
				continue;
			}
			Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
			if (myUnit.ParentScen.MonteCarloIteration > 0)
			{
				dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string), 500));
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
			dictionary.Add("FiringUnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string), 40));
			dictionary.Add("FiringUnitDBID", new IEventExporter.EventNotificationParameter(myUnit.DBID, typeof(string), 10));
			dictionary.Add("FiringUnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string), 500));
			dictionary.Add("FiringUnitType", new IEventExporter.EventNotificationParameter(myUnit.UnitType_String, typeof(string), 20));
			dictionary.Add("FiringUnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string), 500));
			dictionary.Add("FiringUnitSide", new IEventExporter.EventNotificationParameter(myUnit.GetUnitSide().Name, typeof(string), 500));
			dictionary.Add("FiringUnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.GetLongitude(), typeof(double)));
			dictionary.Add("FiringUnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.GetLatitude(), typeof(double)));
			dictionary.Add("FiringUnitCourse", new IEventExporter.EventNotificationParameter(myUnit.CurrentHeading, typeof(double)));
			dictionary.Add("FiringUnitSpeed_kts", new IEventExporter.EventNotificationParameter(myUnit.CurrentSpeed, typeof(float)));
			dictionary.Add("FiringUnitAltitude_m", new IEventExporter.EventNotificationParameter(myUnit.GetCurrentAltitude(), typeof(float)));
			dictionary.Add("FiringUnitAGL_m", new IEventExporter.EventNotificationParameter(myUnit.CurrentAltitude_AGL, typeof(float)));
			dictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(unit_0.ObjectID, typeof(string), 40));
			dictionary.Add("WeaponDBID", new IEventExporter.EventNotificationParameter(unit_0.IsActiveUnit ? ((ActiveUnit)unit_0).DBID : ((UnguidedWeapon)unit_0).ReferenceWeapon.DBID, typeof(string), 10));
			string object_ = (unit_0.IsActiveUnit ? Misc.ForgotRequest(((Weapon)unit_0).Type) : Misc.ForgotRequest(((UnguidedWeapon)unit_0).ReferenceWeapon.Type));
			dictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(unit_0.Name, typeof(string), 500));
			dictionary.Add("WeaponType", new IEventExporter.EventNotificationParameter(object_, typeof(string), 200));
			dictionary.Add("WeaponClass", new IEventExporter.EventNotificationParameter(unit_0.UnitClass, typeof(string), 500));
			dictionary.Add("TargetContactID", new IEventExporter.EventNotificationParameter(contact_0.ObjectID, typeof(string), 40));
			dictionary.Add("TargetContactLongitude", new IEventExporter.EventNotificationParameter(contact_0.GetLongitude(), typeof(double)));
			dictionary.Add("TargetContactLatitude", new IEventExporter.EventNotificationParameter(contact_0.GetLatitude(), typeof(double)));
			dictionary.Add("TargetContactHeading", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(contact_0.HeadingIsKnown, contact_0.CurrentHeading, "")), typeof(float)));
			dictionary.Add("TargetContactSpeed", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(contact_0.SpeedIsKnown, contact_0.CurrentSpeed, "")), typeof(float)));
			dictionary.Add("TargetContactAltitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(contact_0.AltitudeIsKnown, contact_0.GetCurrentAltitude().ToString(), "")), typeof(float)));
			dictionary.Add("TargetContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Horiz(myUnit, contact_0), typeof(float)));
			dictionary.Add("TargetContactRangeSlant_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Slant(myUnit, contact_0), typeof(float)));
			if (contact_0.ActualUnit == null)
			{
				dictionary.Add("TargetContactActualUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
				dictionary.Add("TargetContactActualUnitName", new IEventExporter.EventNotificationParameter(contact_0.Name, typeof(string), 500));
				dictionary.Add("TargetContactActualUnitClass", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				dictionary.Add("TargetContactActualUnitSide", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
			}
			else
			{
				dictionary.Add("TargetContactActualUnitID", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.ObjectID, typeof(string), 40));
				dictionary.Add("TargetContactActualUnitName", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.Name, typeof(string), 500));
				dictionary.Add("TargetContactActualUnitClass", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.UnitClass, typeof(string), 500));
				dictionary.Add("TargetContactActualUnitSide", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.GetUnitSide().Name, typeof(string), 500));
			}
			dictionary.Add("SalvoID", new IEventExporter.EventNotificationParameter((weaponSalvo_0 == null) ? string.Empty : weaponSalvo_0.ObjectID, typeof(string)));
			string object_2 = string.Empty;
			if (contact_0.IsWeaponContact)
			{
				Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
				foreach (WeaponRec item in myUnit.Weaponry.AllDistinctWeaponsAboard_Current_WeaponRecs(bool_1: false))
				{
					if (item.CurrentLoad == 0)
					{
						continue;
					}
					Weapon referenceWeapon = item.GetReferenceWeapon(myUnit.ParentScen);
					ActiveUnit activeUnit_ = myUnit;
					bool? nullable_ = null;
					if (referenceWeapon.QueryReponse(activeUnit_, ref contact_0, ref nullable_))
					{
						if (dictionary2.ContainsKey(item.int_0))
						{
							dictionary2[item.int_0] += item.CurrentLoad;
						}
						else
						{
							dictionary2.Add(item.int_0, item.CurrentLoad);
						}
					}
				}
				List<string> list = new List<string>();
				foreach (KeyValuePair<int, int> item2 in dictionary2)
				{
					list.Add(Conversions.ToString(item2.Value) + "x " + Conversions.ToString(item2.Key));
				}
				object_2 = string.Join("|", list);
			}
			dictionary.Add("CountermeasuresRemaining", new IEventExporter.EventNotificationParameter(object_2, typeof(string)));
			applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponFired, dictionary, myUnit.ParentScen);
		}
		if (unit_0.IsActiveUnit)
		{
			((ActiveUnit)unit_0).Kinematics.ExportLocationEvent(bool_0: true);
		}
		else
		{
			((UnguidedWeapon)unit_0).ExportLocationEvent(myUnit.ParentScen, bool_0: true);
		}
	}

	public static void DropPassiveSonobuoy(Module_Unit.Unit unit_0, bool bool_1, bool bool_2, ref string string_0)
	{
		if (!Information.IsNothing(unit_0) && unit_0.IsAircraft)
		{
			if (bool_1)
			{
				((Aircraft)unit_0).Weaponry.DropSonobuoy(((ActiveUnit)unit_0).ParentScen.GameResolution, bool_2, ref string_0, SonarModel.PositionRelativeToThermocline.Above, false);
			}
			else
			{
				((Aircraft)unit_0).Weaponry.DropSonobuoy(((ActiveUnit)unit_0).ParentScen.GameResolution, bool_2, ref string_0, SonarModel.PositionRelativeToThermocline.Below, false);
			}
		}
	}

	public static void DropActiveSonobuoy(Module_Unit.Unit unit_0, bool bool_1, bool bool_2, ref string string_0)
	{
		if (!Information.IsNothing(unit_0) && unit_0.IsAircraft)
		{
			if (bool_1)
			{
				((Aircraft)unit_0).Weaponry.DropSonobuoy(((ActiveUnit)unit_0).ParentScen.GameResolution, bool_2, ref string_0, SonarModel.PositionRelativeToThermocline.Above, true);
			}
			else
			{
				((Aircraft)unit_0).Weaponry.DropSonobuoy(((ActiveUnit)unit_0).ParentScen.GameResolution, bool_2, ref string_0, SonarModel.PositionRelativeToThermocline.Below, true);
			}
		}
	}

	private void RateConsumer(ref Mount mount_0, UnguidedWeapon unguidedWeapon_0, Sensor sensor_0, Contact contact_0, WeaponSalvo weaponSalvo_0, StringBuilder stringBuilder_0)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl) || myUnit.IsAircraft || mount_0 == null)
			{
				return;
			}
			if (mount_0.LocalControl && mount_0.CompatibleDirectors.Count == 0)
			{
				flag2 = true;
			}
			if (sensor_0 == null)
			{
				stringBuilder_0?.Append("不使用任何辅助引导（手动瞄准）。");
				flag = true;
				if (contact_0.CurrentSpeed > 0f && contact_0.Age == 0f && contact_0.ActualUnit != null && unguidedWeapon_0.Type != Weapon._WeaponType.Laser && (unguidedWeapon_0.Type != Weapon._WeaponType.Microwave || unguidedWeapon_0.Type == Weapon._WeaponType.LaserDazzler))
				{
					double num = contact_0.ActualUnit.Kinematics.GetMaximumSpeed(contact_0.GetCurrentAltitude(), ActiveUnit.Throttle.Flank, bool_0: false);
					if (!(num <= 0.0))
					{
						double num2 = (double)contact_0.CurrentSpeed / num;
						stringBuilder_0?.Append("目标正在以最大速度的").Append((int)Math.Round(100.0 * num2)).Append("%移动;准确度调整到相同。");
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * (1.0 + num2));
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * (1.0 + num2));
					}
				}
			}
			else if (unguidedWeapon_0.Type != Weapon._WeaponType.Laser && unguidedWeapon_0.Type != Weapon._WeaponType.Microwave && unguidedWeapon_0.Type != Weapon._WeaponType.LaserDazzler)
			{
				switch (sensor_0.Type)
				{
				case Sensor.Sensor_Type.LaserDesignator:
					unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
					unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
					unguidedWeapon_0.AirPOK = (float)((double)(long)Math.Round(unguidedWeapon_0.AirPOK) / 1.2);
					stringBuilder_0?.Append("导引器 （").Append(sensor_0.Name).Append("）是激光;准确度下降了20％。");
					break;
				case Sensor.Sensor_Type.Visual:
				case Sensor.Sensor_Type.Infrared:
					unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
					unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
					unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK / 1.5);
					stringBuilder_0?.Append("导引器 （").Append(sensor_0.Name).Append(") 是视线/EO/红外探测；精确度下降50%。");
					break;
				case Sensor.Sensor_Type.Radar:
					stringBuilder_0?.Append("导引器 （").Append(sensor_0.Name).Append("）是雷达;准确性不受影响。");
					break;
				}
			}
			if (!flag && weaponSalvo_0 != null)
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvo_0.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, TextCompare: false) != 0)
					{
						continue;
					}
					int quantityFired = shooter.QuantityFired;
					if (quantityFired < 4)
					{
						continue;
					}
					if (quantityFired < 8)
					{
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.9);
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.9);
						unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK * 1.1);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("少数（少于8发）炮弹已经在齐射中发射;准确度略有提高。");
						}
					}
					else if (quantityFired < 12)
					{
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.8);
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.8);
						unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK * 1.25);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("一些（少于12发）炮弹已经在齐射中发射;准确度提高可观。");
						}
					}
					else if (quantityFired < 15)
					{
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.7);
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.7);
						unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK * 1.5);
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("在齐射中已经发射了不少（不到15发）的炮弹;准确度得到实质提高。");
						}
					}
					else
					{
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.2);
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.2);
						unguidedWeapon_0.AirPOK *= 2f;
						if (!Information.IsNothing(stringBuilder_0))
						{
							stringBuilder_0.Append("在齐射中已经发射很多炮弹;准确度大幅提高。");
						}
					}
				}
			}
			if (flag && !flag2)
			{
				unguidedWeapon_0.CEP_Surface *= 3f;
				unguidedWeapon_0.CEP_Land *= 3f;
				unguidedWeapon_0.AirPOK /= 3f;
				unguidedWeapon_0.SubPOK /= 3f;
				if (!Information.IsNothing(stringBuilder_0))
				{
					stringBuilder_0.Append("手动瞄准通常不用于本地控制的系统;准确度急剧下降。");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100337", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FlushConsumer(ref Contact contact_0, Mount mount_0, ref Sensor sensor_0)
	{
		if (mount_0 == null)
		{
			return;
		}
		try
		{
			List<Sensor> list = StopConsumer(mount_0, contact_0);
			if (list.Count <= 0)
			{
				return;
			}
			IEnumerable<Sensor> source = list.Where((Sensor theS) => theS.Type == Sensor.Sensor_Type.Radar);
			if (source.Count() <= 0)
			{
				IEnumerable<Sensor> source2 = list.Where((Sensor theS) => theS.Type == Sensor.Sensor_Type.LaserDesignator);
				if (source2.Count() <= 0)
				{
					IEnumerable<Sensor> source3 = list.Where((Sensor theS) => theS.Type == Sensor.Sensor_Type.Visual || theS.Type == Sensor.Sensor_Type.Infrared);
					if (source3.Count() > 0)
					{
						sensor_0 = source3.ElementAtOrDefault(0);
						sensor_0.TrackTargetForFireControl(ref contact_0);
					}
				}
				else
				{
					sensor_0 = source2.ElementAtOrDefault(0);
					sensor_0.TrackTargetForFireControl(ref contact_0);
				}
			}
			else
			{
				sensor_0 = source.ElementAtOrDefault(0);
				sensor_0.TrackTargetForFireControl(ref contact_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100338", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public int? BearingForSensorBoresightToCoverMultipleTargets(Sensor sensor_0, List<Module_Unit.Unit> list_0)
	{
		List<int> list = new List<int>();
		int num = 0;
		do
		{
			if (!Sensor.CanTrackAllTargetsAtThisBoresightBearing(sensor_0, num, list_0))
			{
				num++;
				continue;
			}
			list.Add(num);
			break;
		}
		while (num <= 359);
		int count = list.Count;
		int? result;
		if (count == 0)
		{
			result = null;
		}
		else
		{
			int value;
			if (count == 1)
			{
				value = list[0];
			}
			else if (list_0.Count == 1)
			{
				value = (int)Math.Round(Module_Unit.BearingToUnit_True(sensor_0.ParentPlatform, list_0[0]));
			}
			else
			{
				Module_Unit.Unit unit_ = list_0.OrderBy((Module_Unit.Unit theUnit) => Module_Unit.RangeToUnit_Horiz(sensor_0.ParentPlatform, theUnit)).ElementAtOrDefault(0);
				float Local_BearingToNearestTarget = Module_Unit.BearingToUnit_True(sensor_0.ParentPlatform, unit_);
				value = list.Aggregate((int x, int y) => (!(Math.Abs((float)x - Local_BearingToNearestTarget) < Math.Abs((float)y - Local_BearingToNearestTarget))) ? y : x);
			}
			result = value;
		}
		return result;
	}

	private bool ForgotConsumer(ref ActiveUnit activeUnit_0, ref Weapon weapon_0, ref Contact contact_0)
	{
		if (contact_0 == null)
		{
			return false;
		}
		bool result = false;
		try
		{
			if (weapon_0.Flags.IlluminateAtLaunch)
			{
				Module_Unit.Unit.LOSCheckResult? nullable_ = null;
				bool? nullable_2 = null;
				bool? nullable_3 = null;
				bool? nullable_4 = null;
				Sensor[] array = activeUnit_0.Sensors_ReadOnly();
				List<ActiveUnit> list = null;
				Sensor[] array2 = array;
				Sensor[] array3 = array2;
				foreach (Sensor sensor in array3)
				{
					if (sensor.Status != 0 || !sensor.CanIlluminateForThisWeapon(ref weapon_0))
					{
						continue;
					}
					if (sensor.Type == Sensor.Sensor_Type.Radar && list == null)
					{
						list = myUnit.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
					}
					if (sensor.CanIlluminateTarget(activeUnit_0, contact_0.ActualUnit, Module_Unit.RangeToUnit_Slant(activeUnit_0, contact_0), list, myUnit.IsShip, bool_1: false, ref nullable_2, ref nullable_3, ref nullable_, ref nullable_4) != Sensor.SensorDetectionCheckResult.Success)
					{
						continue;
					}
					if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.TargetsTrackedForFireControl_Readonly.Count > 1)
					{
						List<Module_Unit.Unit> list2 = new List<Module_Unit.Unit>(sensor.TargetsTrackedForFireControl_Readonly);
						list2.Add(contact_0);
						int? num = BearingForSensorBoresightToCoverMultipleTargets(sensor, list2);
						if (!num.HasValue)
						{
							continue;
						}
						sensor.Boresight = num.Value;
					}
					else
					{
						sensor.Boresight = Module_Unit.BearingToUnit_True(sensor.ParentPlatform, contact_0);
					}
					if (!sensor.IsTrackingThisTargetForFireControl(ref contact_0))
					{
						if (!sensor.HasFireControlChannelAvailable())
						{
							continue;
						}
						sensor.TrackTargetForFireControl(ref contact_0);
					}
					if (!sensor.SemiActiveWeaponsGuided.Contains(weapon_0))
					{
						sensor.SemiActiveWeaponsGuided.Add(weapon_0);
						weapon_0.SensorProvidingFireControlForMe = sensor;
					}
					if (!sensor.IsActive)
					{
						sensor.GoActive();
					}
					result = true;
					return true;
				}
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100339", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private static bool CollectConsumer(ActiveUnit activeUnit_0, Weapon weapon_0, Contact contact_0)
	{
		if (Information.IsNothing(contact_0))
		{
			return false;
		}
		bool result = false;
		try
		{
			CommDevice[] comms_ReadOnly = weapon_0.Comms_ReadOnly;
			if (comms_ReadOnly.Count() > 0)
			{
				if (weapon_0.Flags.LOAL_CEC && weapon_0.IsAAW)
				{
					if (weapon_0.CommStuff.CommDeviceToConnectToThisUnit(comms_ReadOnly, activeUnit_0) != null && activeUnit_0.Sensory.PostDic(contact_0))
					{
						weapon_0.DataLinkParent = activeUnit_0;
						result = true;
						return true;
					}
					ActiveUnit[] array = activeUnit_0.GetUnitSide().Units.OrderBy((ActiveUnit theU) => Module_Unit.RangeToUnit_Horiz(activeUnit_0, theU)).ToArray();
					ActiveUnit[] array2 = array;
					foreach (ActiveUnit activeUnit in array2)
					{
						if (activeUnit != activeUnit_0)
						{
							CommDevice commDevice = weapon_0.CommStuff.CommDeviceToConnectToThisUnit(comms_ReadOnly, activeUnit);
							if (commDevice != null && activeUnit.Sensory.PostDic(contact_0) && weapon_0.CommStuff.EstablishCommLinkToUnit(commDevice, activeUnit, bool_0: true))
							{
								weapon_0.DataLinkParent = activeUnit;
								result = true;
								return true;
							}
						}
					}
				}
				else if (!Information.IsNothing(weapon_0.CommStuff.CommDeviceToConnectToThisUnit(comms_ReadOnly, activeUnit_0)) && weapon_0.CommStuff.EstablishCommLinkToUnit(null, activeUnit_0, bool_0: false))
				{
					weapon_0.DataLinkParent = activeUnit_0;
					result = true;
					return true;
				}
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100340", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public bool TargetIsWithinNEZ(Contact contact_0, Weapon weapon_0, float float_0 = 0f, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Flank)
	{
		Weapon._WeaponType type = weapon_0.Type;
		if (type != Weapon._WeaponType.GuidedWeapon && type != Weapon._WeaponType.Torpedo)
		{
			return true;
		}
		int num = (int)Math.Round(weapon_0.Fuel_ReadOnly[0].CurrentQuantity);
		float num2 = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0) + contact_0.CurrentSpeed * (float)num / 3600f;
		weapon_0.SetLongitude(null, myUnit.GetLongitude());
		weapon_0.SetLatitude(null, myUnit.GetLatitude());
		weapon_0.SetCurrentAltitude(bool_0: false, myUnit.GetCurrentAltitude());
		weapon_0.SetThrottle(throttle_0);
		weapon_0.CurrentSpeed = myUnit.CurrentSpeed;
		weapon_0.DesiredSpeed = weapon_0.Kinematics.GetMaximumSpeed(weapon_0.GetCurrentAltitude(), throttle_0, bool_0: false);
		weapon_0.DesiredAltitude = contact_0.GetCurrentAltitude();
		weapon_0.AI.PrimaryTarget = contact_0;
		weapon_0.AI.PrimaryTarget_Type = contact_0.Type;
		if (float_0 == 0f)
		{
			if ((object)myUnit.GetType() != typeof(Aircraft) && (object)myUnit.GetType() != typeof(Submarine))
			{
				weapon_0.CurrentHeading = Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), contact_0.GetLatitude(), weapon_0.AI.PrimaryTarget.GetLongitude());
			}
			else
			{
				weapon_0.CurrentHeading = myUnit.CurrentHeading;
			}
		}
		else
		{
			weapon_0.CurrentHeading = float_0;
		}
		int num3 = num;
		for (int i = 1; i <= num3; i++)
		{
			weapon_0.Kinematics.Move(1f, bool_0: false, bool_1: true, myUnit.ParentScen.Time.AddSeconds(i));
		}
		return Math2.VerifyClass(weapon_0.GetLatitude(), weapon_0.GetLongitude(), myUnit.GetLatitude(), myUnit.GetLongitude()) > num2;
	}

	private static DLZResultEnum OrderConsumer(Weapon weapon_0, Module_Unit.Unit unit_0)
	{
		if ((!(weapon_0.MaxTargetAlt_AGL <= 0f) && !(unit_0.CurrentAltitude_AGL <= weapon_0.MaxTargetAlt_AGL)) || (!(weapon_0.MaxTargetAlt_ASL <= 0f) && unit_0.GetCurrentAltitude() > weapon_0.MaxTargetAlt_ASL))
		{
			return DLZResultEnum.Fail_OutsideValidAltitudeEnvelope;
		}
		if ((weapon_0.MinTargetAlt_AGL > 0f && unit_0.CurrentAltitude_AGL < weapon_0.MinTargetAlt_AGL) || (weapon_0.MinTargetAlt_ASL > 0f && unit_0.GetCurrentAltitude() < weapon_0.MinTargetAlt_ASL))
		{
			return DLZResultEnum.Fail_OutsideValidAltitudeEnvelope;
		}
		return DLZResultEnum.Success;
	}

	public static Tuple<DLZResultEnum, float> TargetIsWithinDLZ_BallisticTarget(Scenario scenario_0, int int_0, ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, int int_1, Contact contact_0, float float_1, ActiveUnit.Throttle throttle_0, ref GeoPoint geoPoint_0, ref string string_0, List<float> list_0, List<float> list_1, ref float float_2, Action<string> action_0 = null, Action<DLZResultData> action_1 = null)
	{
		geoPoint_0 = null;
		try
		{
			Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: true);
			newWeapon._FacadeReader = true;
			if (newWeapon.Fuel_ReadOnly.Count == 0)
			{
				newWeapon.AddFuelRec(new FuelRec(0, 0));
			}
			newWeapon.FiringParent = activeUnit_0;
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(newWeapon, scenario_0, activeUnit_0.IsAircraft || activeUnit_0.IsMissile);
			Weapon newWeapon2 = Weapon.GetNewWeapon(ref contact_0.ActualUnit.ParentScen, contact_0.ActualUnit.DBID, bool_0: true);
			newWeapon2._FacadeReader = true;
			newWeapon2.SetLongitude(null, contact_0.GetLongitude());
			newWeapon2.SetLatitude(null, contact_0.GetLatitude());
			newWeapon2.CurrentHeading = contact_0.CurrentHeading;
			newWeapon2.CurrentSpeed = contact_0.CurrentSpeed;
			newWeapon2.SetCurrentAltitude(bool_0: false, contact_0.GetCurrentAltitude());
			newWeapon2.Attitude_Pitch = contact_0.ActualUnit.Attitude_Pitch;
			newWeapon2.LaunchPoint = ((Weapon)contact_0.ActualUnit).LaunchPoint;
			newWeapon2.FiringParent = ((Weapon)contact_0.ActualUnit).FiringParent;
			newWeapon2.ThrottleSetting = ActiveUnit.Throttle.Flank;
			newWeapon2._FacadeReader = true;
			if (contact_0.ActualUnit is BallisticMissile)
			{
				newWeapon2.AI.PrimaryTarget = ((BallisticMissile)contact_0.ActualUnit).SortReader();
			}
			else
			{
				newWeapon2.AI.PrimaryTarget = contact_0.ActualUnit.AI.PrimaryTarget;
			}
			bool flag = false;
			if (contact_0.ActualUnit.IsWeapon & ((Weapon)contact_0.ActualUnit).IsHGV)
			{
				newWeapon2.AI.TerminalDive = ((HGV)contact_0.ActualUnit).AI.TerminalDive;
				flag = true;
			}
			if (contact_0.ActualUnit.IsBallisticMissile && !flag)
			{
				newWeapon2.TimeSinceBurnout = ((BallisticMissile)contact_0.ActualUnit).TimeSinceBurnout;
				newWeapon2.TimeSinceLaunch = ((BallisticMissile)contact_0.ActualUnit).TimeSinceLaunch;
			}
			newWeapon2.Navigator.ClearPlottedCourse();
			Waypoint[] plottedCourse = ((Weapon)contact_0.ActualUnit).Navigator.PlottedCourse;
			Waypoint[] array = plottedCourse;
			foreach (Waypoint waypoint_ in array)
			{
				newWeapon2.Navigator.AddWaypoint(waypoint_);
			}
			newWeapon.SetLongitude(null, double_0);
			newWeapon.SetLatitude(null, double_1);
			newWeapon.SetCurrentAltitude(bool_0: false, float_0);
			newWeapon.CurrentSpeed = int_1;
			if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
			{
				newWeapon.SetThrottle(throttle_0);
			}
			else
			{
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			}
			if (float_1 <= 0f)
			{
				newWeapon.CurrentHeading = Math2.PublishClass(double_1, double_0, newWeapon2.GetLatitude(), newWeapon2.GetLongitude());
			}
			else
			{
				newWeapon.CurrentHeading = float_1;
			}
			newWeapon.LaunchPoint = new GeoPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude());
			if (activeUnit_0.IsFacility || activeUnit_0.IsVehicle || activeUnit_0.IsShip || activeUnit_0.IsSubmarine)
			{
				newWeapon.Attitude_Pitch = 90f;
			}
			Contact contact = new Contact(newWeapon2);
			contact.CurrentSpeed = contact_0.CurrentSpeed;
			contact.SpeedIsKnown = contact_0.SpeedIsKnown;
			contact.CurrentHeading = contact_0.CurrentHeading;
			contact.HeadingIsKnown = contact_0.HeadingIsKnown;
			contact.SetLongitude(null, contact_0.GetLongitude());
			contact.SetLatitude(null, contact_0.GetLatitude());
			contact.SetCurrentAltitude(bool_0: false, contact_0.GetCurrentAltitude());
			contact.AltitudeIsKnown = contact_0.AltitudeIsKnown;
			contact.mapperObserver = contact_0.mapperObserver;
			newWeapon.AI.PrimaryTarget = contact;
			newWeapon.Kinematics.IncludeDescriptor(activeUnit_0, contact);
			if (newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
			{
				float maximumAltitude = newWeapon.Kinematics.GetMaximumAltitude();
				float float_3 = ((contact.GetCurrentAltitude() <= maximumAltitude) ? ((float)newWeapon.Kinematics.GetMaximumSpeed(contact.GetCurrentAltitude(), throttle_0, bool_0: false)) : ((float)newWeapon.Kinematics.GetMaximumSpeed(maximumAltitude)));
				newWeapon.Navigator._ProccesorReader = null;
				if (!newWeapon.Navigator.CalculateDescriptor(float_3, bool_1: false))
				{
					string_0 = "无法计算拦截过程";
					return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_CannotPlotIntercept, float_2);
				}
			}
			float num = newWeapon.FuelConsumption(newWeapon.ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			if (num <= 0f)
			{
				num = 1f;
			}
			float num2 = newWeapon.Fuel_ReadOnly[0].CurrentQuantity / num - 1f;
			bool flag2 = false;
			long num3 = (long)Math.Round(86400.0 + scenario_0.Duration.TotalSeconds);
			long num4 = (newWeapon.UsesBoostCoastModel.Value ? long.MaxValue : ((long)Math.Round(num2 * 2f)));
			bool flag3 = num4 > num3;
			long num5 = num4;
			long num6 = 0L;
			bool flag4 = false;
			for (; num6 <= num5; num6++)
			{
				newWeapon.Navigator._ProccesorReader = null;
				if (!(contact.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation) || contact.CurrentAltitude_AGL >= 10f)
				{
					if (newWeapon.UsesBoostCoastModel.Value)
					{
						if (newWeapon.TimeSinceLaunch > (float)newWeapon.TotalBurnTime && newWeapon.CurrentSpeed < (float)newWeapon.Kinematics.InitDescriptor(newWeapon.GetCurrentAltitude()))
						{
							string_0 = "失败！武器在" + Conversions.ToString(num6) + "秒后未达到目标，覆盖范围" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "海里。与目标的剩余距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
							return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutOfEnergy, float_2);
						}
					}
					else if ((float)num6 > num2)
					{
						if (!newWeapon.SupportsAttitude_Pitch)
						{
							string_0 = "失败！武器在" + Conversions.ToString(num6) + "秒后未达到目标，覆盖范围" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "海里。与目标的剩余距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
							return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutOfEnergy, float_2);
						}
						if (!(newWeapon.Attitude_Pitch < newWeapon.MoveDescriptor()))
						{
							string_0 = "失败！武器在" + Conversions.ToString(num6) + "秒后未达到目标，覆盖范围" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "海里。与目标的剩余距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
							return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutOfEnergy, float_2);
						}
					}
					newWeapon2.AI.DetermineDesiredAttitudeAndThrottle(1f);
					newWeapon2.Kinematics.Move(1f, bool_0: false, bool_1: true, scenario_0.Time.AddSeconds(num6));
					if (newWeapon2.GetCurrentAltitude() != 0f && (!(newWeapon2.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation) || !(newWeapon2.GetCurrentAltitude() <= (float)Terrain.GetElevation(newWeapon2.GetLatitude(), newWeapon2.GetLongitude(), bool_0: false, scenario_0))))
					{
						if (!(newWeapon2.Attitude_Pitch < 0f) || newWeapon2.GetCurrentAltitude() > newWeapon2.ImpactAltitude)
						{
							contact.CurrentSpeed = newWeapon2.CurrentSpeed;
							contact.CurrentHeading = newWeapon2.CurrentHeading;
							contact.SetLongitude(null, newWeapon2.GetLongitude());
							contact.SetLatitude(null, newWeapon2.GetLatitude());
							contact.SetCurrentAltitude(bool_0: false, newWeapon2.GetCurrentAltitude());
							newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
							if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
							{
								newWeapon.SetThrottle(throttle_0);
							}
							else
							{
								newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
							}
							newWeapon.Kinematics.Move(1f, bool_0: false, bool_1: true, scenario_0.Time.AddSeconds(num6));
							list_0?.Add(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()));
							list_1?.Add(newWeapon.GetCurrentAltitude());
							if ((float)num6 != num2 && Module_Unit.RangeToUnit_Horiz(newWeapon, contact) < Math.Max(2f, (newWeapon.CurrentSpeed + contact.CurrentSpeed) / 2400f))
							{
								if (newWeapon.CalcReponse(newWeapon2, 1f, bool_0: true))
								{
									double longitude = contact.GetLongitude();
									double latitude = contact.GetLatitude();
									Contact contact2 = contact;
									bool? nullable_ = null;
									double double_2 = contact2.GetLongitude(nullable_);
									Contact contact3 = contact;
									bool? nullable_2 = null;
									double double_3 = contact3.GetLatitude(nullable_2);
									Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_2, ref double_3, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
									contact3.SetLatitude(nullable_2, double_3);
									contact2.SetLongitude(nullable_, double_2);
									newWeapon.SetLatitude(null, contact.GetLatitude());
									newWeapon.SetLongitude(null, contact.GetLongitude());
									newWeapon.SetCurrentAltitude(bool_0: false, contact.GetCurrentAltitude());
									geoPoint_0 = new GeoPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude());
									flag4 = true;
									float_2 = num6;
									if (contact.GetCurrentAltitude() <= newWeapon.MaxTargetAlt_ASL && contact.GetCurrentAltitude() >= newWeapon.MinTargetAlt_ASL)
									{
										if (!(Module_Unit.RangeToPoint_Slant(contact, newWeapon.LaunchPoint) < newWeapon.MinRange_NoTargetType))
										{
											break;
										}
										string_0 = "FAILURE! Estimated intercept point (" + Conversions.ToString(contact.GetCurrentAltitude()) + "m) is within the weapon's minimum range.";
										return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_InsideMinimumRange, float_2);
									}
									string_0 = "FAILURE! Altitude of estimated intercept point (" + Conversions.ToString(contact.GetCurrentAltitude()) + "m) is outside weapon's min/max target altitude envelope.";
									return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutsideValidAltitudeEnvelope, float_2);
								}
								float num7 = Module_Unit.BearingToUnit_Relative(newWeapon, contact);
								if (num7 >= 90f && num7 <= 270f)
								{
									if (flag2)
									{
										if (contact.GetCurrentAltitude() <= newWeapon.MaxTargetAlt_ASL && contact.GetCurrentAltitude() >= newWeapon.MinTargetAlt_ASL)
										{
											break;
										}
										string_0 = "FAILURE! Altitude of estimated intercept point (" + Conversions.ToString(contact.GetCurrentAltitude()) + "m) is outside weapon's min/max target altitude envelope.";
										return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutsideValidAltitudeEnvelope, float_2);
									}
								}
								else
								{
									flag2 = true;
								}
							}
							if (flag3 && num6 > num3)
							{
								return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_ScenarioDuration, float_2);
							}
							continue;
						}
						return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_TargetWillImpactBeforeIntercept, float_2);
					}
					return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_TargetWillImpactBeforeIntercept, float_2);
				}
				string_0 = "Ballistic Contact impacted ground";
				return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_TargetWillImpactBeforeIntercept, float_2);
			}
			if (!flag4)
			{
				string_0 = "失败！武器在" + Conversions.ToString(num6) + "秒后未达到目标，覆盖范围" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "海里。与目标的剩余距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
			}
			else
			{
				string_0 = "成功！武器将在" + Conversions.ToString(num6) + "秒内到达目标。距离发射点的距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
			}
			contact = null;
			if (flag4)
			{
				return new Tuple<DLZResultEnum, float>(DLZResultEnum.Success, float_2);
			}
			return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutOfEnergy, float_2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100343", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Tuple<DLZResultEnum, float> result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_CodeError, float_2);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Tuple<DLZResultEnum, float> TargetIsWithinDLZ_OrbitalTarget(Scenario scenario_0, int int_0, ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, int int_1, Contact contact_0, float float_1, ActiveUnit.Throttle throttle_0, ref float float_2)
	{
		Tuple<DLZResultEnum, float> result = null;
		try
		{
			Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: true);
			newWeapon.FiringParent = activeUnit_0;
			newWeapon._FacadeReader = true;
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(newWeapon, scenario_0, myUnit.IsAircraft || myUnit.IsMissile);
			Satellite satellite_ = new Satellite(ref scenario_0);
			int int_2 = Conversions.ToInteger(((Satellite)contact_0.ActualUnit).SpacecraftID.Split(Conversions.ToCharArrayRankOne("_"))[1]);
			DBFunctions.GetSatellite(ref scenario_0, ref satellite_, contact_0.ActualUnit.DBID, int_2);
			satellite_.SetCurrentAltitude(bool_0: false, contact_0.ActualUnit.GetCurrentAltitude());
			satellite_.CurrentSpeed = contact_0.ActualUnit.CurrentSpeed;
			satellite_.CurrentHeading = contact_0.ActualUnit.CurrentHeading;
			satellite_.SetLongitude(null, contact_0.GetLongitude());
			satellite_.SetLatitude(null, contact_0.GetLatitude());
			newWeapon.SetLongitude(null, double_0);
			newWeapon.SetLatitude(null, double_1);
			newWeapon.SetCurrentAltitude(bool_0: false, float_0);
			newWeapon.CurrentSpeed = int_1;
			newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			if (float_1 <= 0f)
			{
				newWeapon.CurrentHeading = Math2.PublishClass(double_1, double_0, contact_0.GetLatitude(), contact_0.GetLongitude());
			}
			else
			{
				newWeapon.CurrentHeading = float_1;
			}
			newWeapon.LaunchPoint = new GeoPoint(double_0, double_1, float_0);
			float num = (int)Math.Round(newWeapon.Fuel_ReadOnly[0].CurrentQuantity);
			Contact contact = new Contact(satellite_);
			contact.ActualUnit = null;
			contact.SetCurrentAltitude(bool_0: false, satellite_.GetCurrentAltitude());
			contact.CurrentSpeed = satellite_.CurrentSpeed;
			contact.CurrentHeading = satellite_.CurrentHeading;
			contact.SetLongitude(null, satellite_.GetLongitude());
			contact.SetLatitude(null, satellite_.GetLatitude());
			contact.HeadingIsKnown = contact_0.HeadingIsKnown;
			contact.SpeedIsKnown = contact_0.SpeedIsKnown;
			contact.AltitudeIsKnown = contact_0.AltitudeIsKnown;
			newWeapon.AI.PrimaryTarget = contact;
			if (newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
			{
				newWeapon.Navigator.AddWaypoint(contact.GetLatitude(), contact.GetLongitude(), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
			}
			float num2 = num - 1f;
			bool flag = false;
			for (float num3 = 0f; num3 <= num2; num3 += 1f)
			{
				satellite_.AI.DetermineDesiredAttitudeAndThrottle(1f);
				satellite_.SetThrottle(satellite_.MaxPossibleThrottleSetting);
				satellite_.Kinematics.Move(1f, bool_0: false, bool_1: true, scenario_0.Time.AddSeconds(num3));
				contact.SetCurrentAltitude(bool_0: false, satellite_.GetCurrentAltitude());
				contact.CurrentSpeed = satellite_.CurrentSpeed;
				contact.CurrentHeading = satellite_.CurrentHeading;
				contact.SetLongitude(null, satellite_.GetLongitude());
				contact.SetLatitude(null, satellite_.GetLatitude());
				if (newWeapon.Navigator.HasPlottedCourse())
				{
					newWeapon.Navigator.PlottedCourse[0].Latitude = contact.GetLatitude();
					newWeapon.Navigator.PlottedCourse[0].Longitude = contact.GetLongitude();
				}
				newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
				newWeapon.Kinematics.Move(1f, bool_0: false, bool_1: true, scenario_0.Time.AddSeconds(num3));
				if (num3 != num && newWeapon.AboutToImpact_Contact(1f))
				{
					double longitude = contact.GetLongitude();
					double latitude = contact.GetLatitude();
					bool? nullable_ = null;
					double double_2 = contact.GetLongitude(nullable_);
					bool? nullable_2 = null;
					double double_3 = contact.GetLatitude(nullable_2);
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_2, ref double_3, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
					contact.SetLatitude(nullable_2, double_3);
					contact.SetLongitude(nullable_, double_2);
					newWeapon.SetLatitude(null, contact.GetLatitude());
					newWeapon.SetLongitude(null, contact.GetLongitude());
					newWeapon.SetCurrentAltitude(bool_0: false, contact.GetCurrentAltitude());
					flag = true;
					float_2 = num3;
					break;
				}
			}
			if (flag)
			{
				result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Success, float_2);
				return result;
			}
			result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutOfEnergy, float_2);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100342", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static Tuple<DLZResultEnum, float> TargetIsWithinDLZ_BoostCoast(Scenario scenario_0, int int_0, ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, int int_1, double double_2, double double_3, float float_1, bool bool_1, int int_2, bool bool_2, float float_2, bool bool_3, float float_3, Contact_Base.ContactType contactType_0, ref GeoPoint geoPoint_0, ref string string_0, bool bool_4, bool bool_5, float float_4, ActiveUnit.Throttle throttle_0, int int_3, List<float> list_0, List<float> list_1, ref float float_5, Action<string> action_0 = null, Action<DLZResultData> action_1 = null, AssumedDLZTargetBehavior assumedDLZTargetBehavior_0 = AssumedDLZTargetBehavior.ContinuesAsCurrent, bool bool_6 = false)
	{
		geoPoint_0 = null;
		try
		{
			Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: true);
			newWeapon._FacadeReader = true;
			newWeapon.FiringParent = activeUnit_0;
			if (!bool_4)
			{
				Weapon.RecalculateWeaponFlightEnergyIfNecessary(newWeapon, scenario_0, activeUnit_0.IsAircraft || activeUnit_0.IsMissile, action_0);
			}
			ActiveUnit activeUnit;
			switch (contactType_0)
			{
			case Contact_Base.ContactType.Missile:
				activeUnit = new Weapon(ref scenario_0);
				((Weapon)activeUnit).Type = Weapon._WeaponType.GuidedWeapon;
				break;
			case Contact_Base.ContactType.Orbital:
				activeUnit = new Satellite(ref scenario_0);
				break;
			case Contact_Base.ContactType.Torpedo:
				activeUnit = new Weapon(ref scenario_0);
				((Weapon)activeUnit).Type = Weapon._WeaponType.Torpedo;
				break;
			case Contact_Base.ContactType.Air:
			case Contact_Base.ContactType.Decoy_Air:
				activeUnit = new Aircraft(ref scenario_0);
				break;
			case Contact_Base.ContactType.Submarine:
			case Contact_Base.ContactType.Decoy_Sub:
				activeUnit = new Submarine(ref scenario_0);
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Installation:
			case Contact_Base.ContactType.AirBase:
			case Contact_Base.ContactType.NavalBase:
				activeUnit = new Facility(ref scenario_0);
				break;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				activeUnit = new Facility(ref scenario_0);
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.ActivationPoint:
				activeUnit = new Ship(ref scenario_0);
				break;
			}
			activeUnit.SetLongitude(null, double_2);
			activeUnit.SetLatitude(null, double_3);
			switch (assumedDLZTargetBehavior_0)
			{
			case AssumedDLZTargetBehavior.ContinuesAsCurrent:
				activeUnit.CurrentHeading = float_1;
				break;
			case AssumedDLZTargetBehavior.RunStraightAway:
				if (!bool_6)
				{
					activeUnit.CurrentHeading = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit);
				}
				break;
			}
			activeUnit.CurrentSpeed = int_2;
			activeUnit.SetCurrentAltitude(bool_0: false, float_2);
			newWeapon.SetLongitude(null, double_0);
			newWeapon.SetLatitude(null, double_1);
			newWeapon.SetCurrentAltitude(bool_0: false, float_0);
			newWeapon.CurrentSpeed = int_1;
			if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
			{
				newWeapon.SetThrottle(throttle_0);
			}
			else
			{
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			}
			if (float_4 <= 0f)
			{
				newWeapon.CurrentHeading = Math2.PublishClass(double_1, double_0, double_3, double_2);
			}
			else
			{
				newWeapon.CurrentHeading = float_4;
			}
			if (int_3 > 0)
			{
				newWeapon.TotalBurnTime = int_3;
			}
			newWeapon.LaunchPoint = new GeoPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude());
			Contact contact = new Contact(activeUnit);
			contact.SetCurrentAltitude(bool_0: false, float_2);
			if (newWeapon.IsTorpedo)
			{
				contact.AltitudeIsKnown = true;
			}
			else
			{
				contact.AltitudeIsKnown = bool_3;
			}
			contact.CurrentSpeed = activeUnit.CurrentSpeed;
			contact.SpeedIsKnown = bool_2;
			contact.CurrentHeading = activeUnit.CurrentHeading;
			contact.HeadingIsKnown = bool_1;
			contact.SetLongitude(null, activeUnit.GetLongitude());
			contact.SetLatitude(null, activeUnit.GetLatitude());
			newWeapon.AI.PrimaryTarget = contact;
			newWeapon.Kinematics.IncludeDescriptor(activeUnit_0, contact);
			if ((newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial) && !newWeapon.Navigator.CalculateDescriptor(newWeapon.Kinematics.GetMaximumSpeed(contact.GetCurrentAltitude(), throttle_0, bool_0: false), bool_1: false))
			{
				string_0 = "无法计算拦截过程";
				return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_CannotPlotIntercept, float_5);
			}
			newWeapon.FuelConsumption(newWeapon.ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			long num = (long)Math.Round(86400.0 + scenario_0.Duration.TotalSeconds);
			float num2 = 0f;
			double double_4 = 0.0;
			double double_5 = 0.0;
			bool flag = false;
			while (true)
			{
				if (!bool_4)
				{
					float timeSinceLaunch = newWeapon.TimeSinceLaunch;
					float? num3 = newWeapon.FlightEndurance;
					if ((num3.HasValue ? new bool?(timeSinceLaunch > num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						goto IL_0840;
					}
				}
				if (newWeapon.TimeSinceLaunch <= (float)newWeapon.TotalBurnTime || newWeapon.CurrentSpeed >= (float)newWeapon.Kinematics.InitDescriptor(newWeapon.GetCurrentAltitude()))
				{
					if (contact.CurrentSpeed != 0f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact.GetLongitude(), contact.GetLatitude(), ref double_4, ref double_5, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
						activeUnit.SetLongitude(null, double_4);
						activeUnit.SetLatitude(null, double_5);
						activeUnit.SetCurrentAltitude(bool_0: false, activeUnit.GetCurrentAltitude() + float_3);
						contact.SetLongitude(null, double_4);
						contact.SetLatitude(null, double_5);
						contact.SetCurrentAltitude(bool_0: false, activeUnit.GetCurrentAltitude());
					}
					if ((newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial) && newWeapon.Navigator.HasPlottedCourse())
					{
						newWeapon.Navigator.CalculateDescriptor(newWeapon.Kinematics.GetMaximumSpeed(contact.GetCurrentAltitude(), throttle_0, bool_0: false), bool_1: false);
					}
					newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
					if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
					{
						newWeapon.SetThrottle(throttle_0);
					}
					else
					{
						newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
					}
					newWeapon.Kinematics.Move(1f, bool_0: false, bool_1: true, scenario_0.Time.AddSeconds(num2));
					list_0?.Add(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()));
					list_1?.Add(newWeapon.GetCurrentAltitude());
					if (!newWeapon.AboutToImpact_Contact(1f) || (!newWeapon.CalculateReponse() && Module_Unit.RangeToUnit_Horiz(newWeapon, contact) >= 1f))
					{
						num2 += 1f;
						if (!(num2 <= (float)num))
						{
							break;
						}
						continue;
					}
					double longitude = contact.GetLongitude();
					double latitude = contact.GetLatitude();
					Contact contact2 = contact;
					bool? nullable_ = null;
					double double_6 = contact2.GetLongitude(nullable_);
					Contact contact3 = contact;
					bool? nullable_2 = null;
					double double_7 = contact3.GetLatitude(nullable_2);
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_6, ref double_7, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
					contact3.SetLatitude(nullable_2, double_7);
					contact2.SetLongitude(nullable_, double_6);
					newWeapon.SetLatitude(null, contact.GetLatitude());
					newWeapon.SetLongitude(null, contact.GetLongitude());
					newWeapon.SetCurrentAltitude(bool_0: false, contact.GetCurrentAltitude());
					geoPoint_0 = new GeoPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude());
					flag = true;
					float_5 = num2;
				}
				goto IL_0840;
				IL_0840:
				if (bool_5)
				{
					if (!flag)
					{
						if (assumedDLZTargetBehavior_0 == AssumedDLZTargetBehavior.RunStraightAway && !bool_6)
						{
							string_0 = "FAILURE! Target was outside NEZ " + Conversions.ToString(num2) + "秒后未达到目标，覆盖范围" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "海里。与目标的剩余距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
						}
						else
						{
							string_0 = "失败！武器在" + Conversions.ToString(num2) + "秒后未达到目标，覆盖范围" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "海里。与目标的剩余距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
						}
					}
					else
					{
						string_0 = "成功！武器将在" + Conversions.ToString(num2) + "秒内到达目标。距离发射点的距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
					}
				}
				contact = null;
				if (flag)
				{
					return new Tuple<DLZResultEnum, float>(DLZResultEnum.Success, num2);
				}
				if (assumedDLZTargetBehavior_0 == AssumedDLZTargetBehavior.RunStraightAway)
				{
					return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_MAXRangeWRA, num2);
				}
				return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutOfEnergy, num2);
			}
			return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_ScenarioDuration, float_5);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100343", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Tuple<DLZResultEnum, float> result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_CodeError, 0f);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static Tuple<DLZResultEnum, float> TargetIsWithinDLZ(Scenario scenario_0, int int_0, ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, int int_1, double double_2, double double_3, float float_1, bool bool_1, int int_2, bool bool_2, float float_2, bool bool_3, float float_3, Contact_Base.ContactType contactType_0, ref GeoPoint geoPoint_0, ref string string_0, bool bool_4, float float_4, ActiveUnit.Throttle throttle_0, int int_3, List<float> list_0, List<float> list_1, ref float float_5, Action<string> action_0 = null, Action<DLZResultData> action_1 = null, AssumedDLZTargetBehavior assumedDLZTargetBehavior_0 = AssumedDLZTargetBehavior.ContinuesAsCurrent, bool bool_5 = false)
	{
		Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: true);
		newWeapon.FiringParent = activeUnit_0;
		if (newWeapon.UsesBoostCoastModel.Value)
		{
			Tuple<DLZResultEnum, float> tuple = TargetIsWithinDLZ_BoostCoast(scenario_0, int_0, activeUnit_0, double_0, double_1, float_0, int_1, double_2, double_3, float_1, bool_1, int_2, bool_2, float_2, bool_3, float_3, contactType_0, ref geoPoint_0, ref string_0, bool_4: false, bool_4, float_4, throttle_0, 0, list_0, list_1, ref float_5, action_0, action_1, assumedDLZTargetBehavior_0, bool_5);
			if (tuple.Item1 != DLZResultEnum.Success)
			{
				return new Tuple<DLZResultEnum, float>(tuple.Item1, 0f);
			}
		}
		geoPoint_0 = null;
		try
		{
			newWeapon._FacadeReader = true;
			if (newWeapon.Fuel_ReadOnly.Count == 0)
			{
				newWeapon.AddFuelRec(new FuelRec(0, 0));
			}
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(newWeapon, scenario_0, activeUnit_0.IsAircraft || activeUnit_0.IsMissile);
			if (newWeapon.Flags.SearchPattern)
			{
				newWeapon.Flags.SearchPattern = false;
			}
			ActiveUnit activeUnit;
			switch (contactType_0)
			{
			case Contact_Base.ContactType.Missile:
				activeUnit = new Weapon(ref scenario_0);
				((Weapon)activeUnit).Type = Weapon._WeaponType.GuidedWeapon;
				break;
			case Contact_Base.ContactType.Orbital:
				activeUnit = new Satellite(ref scenario_0);
				break;
			case Contact_Base.ContactType.Torpedo:
				activeUnit = new Weapon(ref scenario_0);
				((Weapon)activeUnit).Type = Weapon._WeaponType.Torpedo;
				break;
			case Contact_Base.ContactType.Air:
			case Contact_Base.ContactType.Decoy_Air:
				activeUnit = new Aircraft(ref scenario_0);
				break;
			case Contact_Base.ContactType.Submarine:
			case Contact_Base.ContactType.Decoy_Sub:
				activeUnit = new Submarine(ref scenario_0);
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Installation:
			case Contact_Base.ContactType.AirBase:
			case Contact_Base.ContactType.NavalBase:
				activeUnit = new Facility(ref scenario_0);
				break;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				activeUnit = new Facility(ref scenario_0);
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.ActivationPoint:
				activeUnit = new Ship(ref scenario_0);
				break;
			}
			activeUnit.SetLongitude(null, double_2);
			activeUnit.SetLatitude(null, double_3);
			if (assumedDLZTargetBehavior_0 == AssumedDLZTargetBehavior.RunStraightAway && !bool_5)
			{
				activeUnit.CurrentHeading = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit);
			}
			else
			{
				activeUnit.CurrentHeading = float_1;
			}
			activeUnit.CurrentSpeed = int_2;
			activeUnit.SetCurrentAltitude(bool_0: false, float_2);
			newWeapon.SetLongitude(null, double_0);
			newWeapon.SetLatitude(null, double_1);
			newWeapon.SetCurrentAltitude(bool_0: false, float_0);
			newWeapon.CurrentSpeed = int_1;
			if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
			{
				newWeapon.SetThrottle(throttle_0);
			}
			else
			{
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			}
			if (float_4 <= 0f)
			{
				newWeapon.CurrentHeading = Math2.PublishClass(double_1, double_0, double_3, double_2);
			}
			else
			{
				newWeapon.CurrentHeading = float_4;
			}
			if (int_3 > 0)
			{
				newWeapon.Fuel_ReadOnly[0].CurrentQuantity = int_3;
			}
			newWeapon.LaunchPoint = new GeoPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude());
			Contact contact = new Contact(activeUnit);
			contact.SetCurrentAltitude(bool_0: false, float_2);
			if (newWeapon.IsTorpedo)
			{
				contact.AltitudeIsKnown = true;
			}
			else
			{
				contact.AltitudeIsKnown = bool_3;
			}
			contact.CurrentSpeed = activeUnit.CurrentSpeed;
			contact.SpeedIsKnown = bool_2;
			contact.CurrentHeading = activeUnit.CurrentHeading;
			contact.HeadingIsKnown = bool_1;
			contact.SetLongitude(null, activeUnit.GetLongitude());
			contact.SetLatitude(null, activeUnit.GetLatitude());
			newWeapon.AI.PrimaryTarget = contact;
			newWeapon.Kinematics.IncludeDescriptor(activeUnit_0, contact);
			if ((newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial) && !newWeapon.Navigator.CalculateDescriptor(newWeapon.Kinematics.GetMaximumSpeed(contact.GetCurrentAltitude(), throttle_0, bool_0: false), bool_1: false))
			{
				string_0 = "无法计算拦截过程";
				return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_CannotPlotIntercept, 0f);
			}
			float num = newWeapon.FuelConsumption(newWeapon.ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			if (num <= 0f)
			{
				num = 1f;
			}
			float num2 = newWeapon.Fuel_ReadOnly[0].CurrentQuantity / num - 1f;
			bool flag = false;
			float num3 = num2 * 2f;
			double double_4 = 0.0;
			double double_5 = 0.0;
			bool flag2 = false;
			float num4;
			for (num4 = 0f; num4 <= num3 && (!(num4 > num2) || (newWeapon.SupportsAttitude_Pitch && !(newWeapon.Attitude_Pitch >= newWeapon.MoveDescriptor()))); num4 += 1f)
			{
				if (contact.CurrentSpeed != 0f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact.GetLongitude(), contact.GetLatitude(), ref double_4, ref double_5, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
					activeUnit.SetLongitude(null, double_4);
					activeUnit.SetLatitude(null, double_5);
					activeUnit.SetCurrentAltitude(bool_0: false, activeUnit.GetCurrentAltitude() + float_3);
					contact.SetLongitude(null, double_4);
					contact.SetLatitude(null, double_5);
					contact.SetCurrentAltitude(bool_0: false, activeUnit.GetCurrentAltitude());
				}
				newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
				if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
				{
					newWeapon.SetThrottle(throttle_0);
				}
				else
				{
					newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
				}
				newWeapon.Kinematics.Move(1f, bool_0: false, bool_1: true, scenario_0.Time.AddSeconds(num4));
				list_0?.Add(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()));
				list_1?.Add(newWeapon.GetCurrentAltitude());
				if (num4 == num2 || !(Module_Unit.RangeToUnit_Horiz(newWeapon, contact) < Math.Max(1f, (newWeapon.CurrentSpeed + contact.CurrentSpeed) / 2400f)))
				{
					continue;
				}
				if (!newWeapon.CalcReponse(contact, 1f, bool_0: true))
				{
					float num5 = Module_Unit.BearingToUnit_Relative(newWeapon, contact);
					if (num5 >= 90f && num5 <= 270f)
					{
						if (flag)
						{
							DLZResultEnum dLZResultEnum = OrderConsumer(newWeapon, contact);
							if (dLZResultEnum == DLZResultEnum.Success)
							{
								break;
							}
							return new Tuple<DLZResultEnum, float>(dLZResultEnum, 0f);
						}
					}
					else
					{
						flag = true;
					}
					continue;
				}
				DLZResultEnum dLZResultEnum2 = OrderConsumer(newWeapon, contact);
				if (dLZResultEnum2 == DLZResultEnum.Success)
				{
					double longitude = contact.GetLongitude();
					double latitude = contact.GetLatitude();
					Contact contact2 = contact;
					bool? nullable_ = null;
					double double_6 = contact2.GetLongitude(nullable_);
					Contact contact3 = contact;
					bool? nullable_2 = null;
					double double_7 = contact3.GetLatitude(nullable_2);
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_6, ref double_7, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
					contact3.SetLatitude(nullable_2, double_7);
					contact2.SetLongitude(nullable_, double_6);
					newWeapon.SetLatitude(null, contact.GetLatitude());
					newWeapon.SetLongitude(null, contact.GetLongitude());
					newWeapon.SetCurrentAltitude(bool_0: false, contact.GetCurrentAltitude());
					geoPoint_0 = new GeoPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude());
					flag2 = true;
					float_5 = num4;
					break;
				}
				return new Tuple<DLZResultEnum, float>(dLZResultEnum2, 0f);
			}
			if (newWeapon.LaunchPoint != null)
			{
				if (!flag2)
				{
					string_0 = "失败！武器在" + Conversions.ToString(num4) + "秒后未达到目标，覆盖范围" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "海里。与目标的剩余距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
				}
				else
				{
					string_0 = "成功！武器将在" + Conversions.ToString(num4) + "秒内到达目标。距离发射点的距离是" + Conversions.ToString(Math.Round(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()), 2)) + "nm.";
				}
			}
			contact = null;
			if (flag2)
			{
				return new Tuple<DLZResultEnum, float>(DLZResultEnum.Success, float_5);
			}
			return new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_OutOfEnergy, 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100343", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Tuple<DLZResultEnum, float> result = new Tuple<DLZResultEnum, float>(DLZResultEnum.Fail_CodeError, float_5);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private int? RegisterConsumer(ref Contact contact_0, ref Weapon weapon_0)
	{
		int? result = null;
		if (contact_0 == null)
		{
			result = -98;
		}
		else if (myUnit.Doctrine.InsertRepository(ref weapon_0))
		{
			weapon_0.FiringParent = myUnit;
			Weapon weapon_ = weapon_0;
			bool? nullable_ = null;
			Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_, ref nullable_);
			Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_2 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_0, ref contact_0, ref _WRA_WeaponTargetType_, myUnit.GetUnitSide().ObjectID);
			Doctrine doctrine = myUnit.Doctrine;
			Scenario parentScen = weapon_0.ParentScen;
			Weapon weapon_2 = weapon_0;
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = _WRA_WeaponTargetType_2;
			int? nullable_2 = null;
			int? nullable_3 = null;
			int? num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, weapon_2, wRA_WeaponTargetType_, bool_0: false, ref nullable_2, ref nullable_3);
			if (!num.HasValue)
			{
				num = Doctrine.WRA_WeaponQty_SystemDefault(weapon_0, _WRA_WeaponTargetType_2);
				if (!num.HasValue)
				{
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_2 = Doctrine.WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_2);
					num = Doctrine.WRA_WeaponQty_SystemDefault(weapon_0, wRA_WeaponTargetType_2);
				}
			}
			nullable_3 = num;
			if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				result = 0;
			}
			else
			{
				Doctrine doctrine2 = myUnit.Doctrine;
				Doctrine doctrine3 = myUnit.Doctrine;
				Scenario parentScen2 = weapon_0.ParentScen;
				int dBID = weapon_0.DBID;
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_3 = _WRA_WeaponTargetType_2;
				float? nullable_4 = null;
				float? nullable_5 = null;
				nullable_5 = doctrine2.IncludeRepository(doctrine3, parentScen2, dBID, wRA_WeaponTargetType_3, bool_0: false, ref nullable_4, ref nullable_5);
				if ((nullable_5.HasValue ? new bool?(nullable_5.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
				{
					result = 0;
				}
			}
		}
		return result;
	}

	internal Weapon ManageConsumer(Contact contact_0, ref List<int> list_0)
	{
		Weapon result = null;
		try
		{
			float num = 0f;
			foreach (Mount mount in myUnit.Mounts)
			{
				if (mount.Status != 0 || !(mount.MountMagazine.TimeToFire <= 0f))
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					WeaponRec current2;
					Weapon weapon_ = (current2 = mountWeapon).GetReferenceWeapon(myUnit.ParentScen);
					if (weapon_.IsSoftKill)
					{
						continue;
					}
					if (weapon_.IsNuke.Value)
					{
						byte? b = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						if (((!flag) ?? flag).GetValueOrDefault())
						{
							continue;
						}
					}
					int? num2 = RegisterConsumer(ref contact_0, ref weapon_);
					if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						if (((weapon_.MaxAirRange > num) & !list_0.Contains(weapon_.DBID)) && current2.CurrentLoad > 0 && (weapon_.ValidTargets.Aircraft || weapon_.ValidTargets.Missile))
						{
							result = weapon_;
							num = weapon_.MaxAirRange;
						}
						current2 = null;
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					WeaponRec weaponRec2 = weaponRec;
					if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
					{
						if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
						{
							Weapon referenceWeapon = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
							if (referenceWeapon.IsSoftKill)
							{
								continue;
							}
							if (referenceWeapon.IsNuke.Value)
							{
								byte? b2 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
								bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
								if (((!flag2) ?? flag2).GetValueOrDefault())
								{
									continue;
								}
							}
							if (((referenceWeapon.MaxAirRange > num) & !list_0.Contains(referenceWeapon.DBID)) && weaponRec2.CurrentLoad > 0 && (referenceWeapon.ValidTargets.Aircraft || referenceWeapon.ValidTargets.Missile || referenceWeapon.ValidTargets.Satellite))
							{
								result = referenceWeapon;
								num = referenceWeapon.MaxAirRange;
							}
						}
					}
					Weapon weapon_2 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
					if (weapon_2.IsSoftKill)
					{
						continue;
					}
					if (weapon_2.IsNuke.Value)
					{
						byte? b3 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						bool? flag3 = (b3.HasValue ? new bool?(b3.GetValueOrDefault() == 1) : null);
						if (((!flag3) ?? flag3).GetValueOrDefault())
						{
							continue;
						}
					}
					int? num3 = RegisterConsumer(ref contact_0, ref weapon_2);
					if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						if (weapon_2.MaxAirRange > num && weaponRec2.CurrentLoad > 0 && (weapon_2.ValidTargets.Aircraft || weapon_2.ValidTargets.Missile || (weapon_2.ValidTargets.Satellite & !list_0.Contains(weapon_2.DBID))))
						{
							result = weapon_2;
							num = weapon_2.MaxAirRange;
						}
						weaponRec2 = null;
					}
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200296", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal Weapon RevertConsumer(Contact contact_0)
	{
		try
		{
			if (Information.IsNothing(parserWrapper) && !_AlgoWrapper)
			{
				List<Mount> list = Misc.EnableRequest(myUnit.Mounts);
				float num = 0f;
				foreach (Mount item in list)
				{
					if (item.Status != 0 || !(item.MountMagazine.TimeToFire <= 0f))
					{
						continue;
					}
					foreach (WeaponRec mountWeapon in item.MountWeapons)
					{
						WeaponRec current2;
						Weapon weapon_ = (current2 = mountWeapon).GetReferenceWeapon(myUnit.ParentScen);
						if (weapon_.IsSoftKill)
						{
							continue;
						}
						if (weapon_.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							if (((!flag) ?? flag).GetValueOrDefault())
							{
								continue;
							}
						}
						int? num2 = RegisterConsumer(ref contact_0, ref weapon_);
						if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							if (weapon_.MaxAirRange > num && current2.CurrentLoad > 0 && (weapon_.ValidTargets.Aircraft || weapon_.ValidTargets.Missile))
							{
								parserWrapper = weapon_;
								num = weapon_.MaxAirRange;
							}
							current2 = null;
						}
					}
				}
				if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						WeaponRec weaponRec2 = weaponRec;
						if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
						{
							if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
							{
								weaponRec.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
							}
							foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
							{
								Weapon referenceWeapon = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
								if (referenceWeapon.IsSoftKill)
								{
									continue;
								}
								if (referenceWeapon.IsNuke.Value)
								{
									byte? b2 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
									if (((!flag2) ?? flag2).GetValueOrDefault())
									{
										continue;
									}
								}
								if (referenceWeapon.MaxAirRange > num && weaponRec2.CurrentLoad > 0 && (referenceWeapon.ValidTargets.Aircraft || referenceWeapon.ValidTargets.Missile || referenceWeapon.ValidTargets.Satellite))
								{
									parserWrapper = referenceWeapon;
									num = referenceWeapon.MaxAirRange;
								}
							}
						}
						Weapon weapon_2 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
						if (weapon_2.IsSoftKill)
						{
							continue;
						}
						if (weapon_2.IsNuke.Value)
						{
							byte? b3 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag3 = (b3.HasValue ? new bool?(b3.GetValueOrDefault() == 1) : null);
							if (((!flag3) ?? flag3).GetValueOrDefault())
							{
								continue;
							}
						}
						int? num3 = RegisterConsumer(ref contact_0, ref weapon_2);
						if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							if (weapon_2.MaxAirRange > num && weaponRec2.CurrentLoad > 0 && (weapon_2.ValidTargets.Aircraft || weapon_2.ValidTargets.Missile || weapon_2.ValidTargets.Satellite))
							{
								parserWrapper = weapon_2;
								num = weapon_2.MaxAirRange;
							}
							weaponRec2 = null;
						}
					}
				}
				_AlgoWrapper = true;
			}
			return parserWrapper;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200296", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal Weapon CountFacade(Contact contact_0, bool bool_1)
	{
		try
		{
			if ((_DatabaseWrapper == null && !bool_1 && !m_MessageWrapper) || (interceptorWrapper == null && bool_1 && !m_ProductWrapper))
			{
				List<Mount> list = new List<Mount>(myUnit.Mounts);
				float num = 0f;
				foreach (Mount item in list)
				{
					if (!(item.MountMagazine.TimeToFire <= 0f) || item.Status != 0)
					{
						continue;
					}
					foreach (WeaponRec mountWeapon in item.MountWeapons)
					{
						Weapon weapon_ = mountWeapon.GetReferenceWeapon(myUnit.ParentScen);
						if (weapon_.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							if (((!flag) ?? flag).GetValueOrDefault())
							{
								continue;
							}
						}
						if ((weapon_.IsSoftKill && !weapon_.IsMobileDecoy) || (bool_1 && weapon_.MaxSurfaceRange > 5400f))
						{
							continue;
						}
						float num2 = ((!myUnit.IsAircraft || !weapon_.IsUnguidedBallisticWeapon) ? weapon_.MaxSurfaceRange : weapon_.GetMaxDownRange(myUnit.GetCurrentAltitude(), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Surface));
						int? num3 = RegisterConsumer(ref contact_0, ref weapon_);
						if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault() && num2 > num && mountWeapon.CurrentLoad > 0 && (weapon_.ValidTargets.SurfaceVessel || weapon_.ValidTargets.Radar))
						{
							if (bool_1)
							{
								interceptorWrapper = weapon_;
							}
							else
							{
								_DatabaseWrapper = weapon_;
							}
							num = num2;
						}
					}
				}
				if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						Weapon weapon_2 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
						float num4;
						int? num5;
						if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
						{
							if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
							{
								weaponRec.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
							}
							foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
							{
								Weapon referenceWeapon = weaponWeapon.GetReferenceWeapon(myUnit.ParentScen);
								if (referenceWeapon.IsNuke.Value)
								{
									byte? b2 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
									if (((!flag2) ?? flag2).GetValueOrDefault())
									{
										continue;
									}
								}
								if ((referenceWeapon.IsSoftKill && !referenceWeapon.IsMobileDecoy) || (bool_1 && referenceWeapon.MaxSurfaceRange > 5400f))
								{
									continue;
								}
								num4 = ((!myUnit.IsAircraft || !referenceWeapon.IsUnguidedBallisticWeapon) ? referenceWeapon.MaxSurfaceRange : referenceWeapon.GetMaxDownRange(myUnit.GetCurrentAltitude(), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Surface));
								num5 = RegisterConsumer(ref contact_0, ref weapon_2);
								if (!(num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault() && num4 > num && weaponRec.CurrentLoad > 0 && (referenceWeapon.ValidTargets.SurfaceVessel || referenceWeapon.ValidTargets.Radar))
								{
									if (bool_1)
									{
										interceptorWrapper = referenceWeapon;
									}
									else
									{
										_DatabaseWrapper = referenceWeapon;
									}
									num = num4;
								}
							}
						}
						if (weapon_2.IsNuke.Value)
						{
							byte? b3 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag3 = (b3.HasValue ? new bool?(b3.GetValueOrDefault() == 1) : null);
							if (((!flag3) ?? flag3).GetValueOrDefault())
							{
								continue;
							}
						}
						if ((weapon_2.IsSoftKill && !weapon_2.IsMobileDecoy) || (bool_1 && weapon_2.MaxSurfaceRange > 5400f))
						{
							continue;
						}
						num4 = ((!myUnit.IsAircraft || !weapon_2.IsUnguidedBallisticWeapon) ? weapon_2.MaxSurfaceRange : weapon_2.GetMaxDownRange(myUnit.GetCurrentAltitude(), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Surface));
						num5 = RegisterConsumer(ref contact_0, ref weapon_2);
						if (!(num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault() && num4 > num && weaponRec.CurrentLoad > 0 && (weapon_2.ValidTargets.SurfaceVessel || weapon_2.ValidTargets.Radar))
						{
							if (bool_1)
							{
								interceptorWrapper = weapon_2;
							}
							else
							{
								_DatabaseWrapper = weapon_2;
							}
							num = num4;
						}
					}
				}
				if (bool_1)
				{
					m_ProductWrapper = true;
				}
				else
				{
					m_MessageWrapper = true;
				}
			}
			if (bool_1)
			{
				return interceptorWrapper;
			}
			return _DatabaseWrapper;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200297", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal Weapon CustomizeFacade(Contact contact_0, bool bool_1)
	{
		try
		{
			if ((Information.IsNothing(m_AnnotationWrapper) && !bool_1 && !m_InitializerWrapper) || (Information.IsNothing(_IteratorWrapper) && bool_1 && !roleWrapper))
			{
				List<Mount> list = Misc.EnableRequest(myUnit.Mounts);
				float num = 0f;
				foreach (Mount item in list)
				{
					if (!(item.MountMagazine.TimeToFire <= 0f) || item.Status != 0)
					{
						continue;
					}
					foreach (WeaponRec mountWeapon in item.MountWeapons)
					{
						Weapon weapon_ = mountWeapon.GetReferenceWeapon(myUnit.ParentScen);
						if (weapon_.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							if (((!flag) ?? flag).GetValueOrDefault())
							{
								continue;
							}
						}
						if ((weapon_.IsSoftKill && !weapon_.IsMobileDecoy) || (bool_1 && weapon_.MaxLandRange > 5400f))
						{
							continue;
						}
						float num2 = ((!myUnit.IsAircraft || !weapon_.IsUnguidedBallisticWeapon) ? weapon_.MaxLandRange : weapon_.GetMaxDownRange(myUnit.GetCurrentAltitude(), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Facility_Fixed));
						int? num3 = RegisterConsumer(ref contact_0, ref weapon_);
						if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault() && num2 > num && mountWeapon.CurrentLoad > 0 && (weapon_.ValidTargets.LandStructure_Hard || weapon_.ValidTargets.MobileTarget_Hard || weapon_.ValidTargets.LandStructure_Soft || weapon_.ValidTargets.Radar || weapon_.ValidTargets.Runway || weapon_.ValidTargets.MobileTarget_Soft))
						{
							if (bool_1)
							{
								_IteratorWrapper = weapon_;
							}
							else
							{
								m_AnnotationWrapper = weapon_;
							}
							num = num2;
						}
					}
				}
				if (myUnit.IsAircraft && !Information.IsNothing(((Aircraft)myUnit).Loadout))
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						Weapon weapon_2 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
						float num4;
						int? num5;
						if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).IsPalletWeapon)
						{
							if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
							{
								weaponRec.GetReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
							}
							foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
							{
								Weapon referenceWeapon = weaponWeapon.GetReferenceWeapon(myUnit.ParentScen);
								if (referenceWeapon.IsNuke.Value)
								{
									byte? b2 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
									if (((!flag2) ?? flag2).GetValueOrDefault())
									{
										continue;
									}
								}
								if ((referenceWeapon.IsSoftKill && !referenceWeapon.IsMobileDecoy) || (bool_1 && referenceWeapon.MaxLandRange > 5400f))
								{
									continue;
								}
								num4 = ((!myUnit.IsAircraft || !referenceWeapon.IsUnguidedBallisticWeapon) ? referenceWeapon.MaxLandRange : referenceWeapon.GetMaxDownRange(myUnit.GetCurrentAltitude(), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Facility_Fixed));
								num5 = RegisterConsumer(ref contact_0, ref weapon_2);
								if (!(num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault() && num4 > num && weaponRec.CurrentLoad > 0 && (referenceWeapon.ValidTargets.LandStructure_Hard || referenceWeapon.ValidTargets.MobileTarget_Hard || referenceWeapon.ValidTargets.LandStructure_Soft || referenceWeapon.ValidTargets.Radar || referenceWeapon.ValidTargets.Runway || referenceWeapon.ValidTargets.MobileTarget_Soft))
								{
									if (bool_1)
									{
										_IteratorWrapper = referenceWeapon;
									}
									else
									{
										m_AnnotationWrapper = referenceWeapon;
									}
									num = num4;
								}
							}
						}
						if (weapon_2.IsNuke.Value)
						{
							byte? b3 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag3 = (b3.HasValue ? new bool?(b3.GetValueOrDefault() == 1) : null);
							if (((!flag3) ?? flag3).GetValueOrDefault())
							{
								continue;
							}
						}
						if ((weapon_2.IsSoftKill && !weapon_2.IsMobileDecoy) || (bool_1 && weapon_2.MaxLandRange > 5400f))
						{
							continue;
						}
						num4 = ((!myUnit.IsAircraft || !weapon_2.IsUnguidedBallisticWeapon) ? weapon_2.MaxLandRange : weapon_2.GetMaxDownRange(myUnit.GetCurrentAltitude(), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Facility_Fixed));
						num5 = RegisterConsumer(ref contact_0, ref weapon_2);
						if (!(num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault() && num4 > num && weaponRec.CurrentLoad > 0 && (weapon_2.ValidTargets.LandStructure_Hard || weapon_2.ValidTargets.MobileTarget_Hard || weapon_2.ValidTargets.LandStructure_Soft || weapon_2.ValidTargets.Radar || weapon_2.ValidTargets.Runway || weapon_2.ValidTargets.MobileTarget_Soft))
						{
							if (bool_1)
							{
								_IteratorWrapper = weapon_2;
							}
							else
							{
								m_AnnotationWrapper = weapon_2;
							}
							num = num4;
						}
					}
				}
				if (bool_1)
				{
					roleWrapper = true;
				}
				else
				{
					m_InitializerWrapper = true;
				}
			}
			if (bool_1)
			{
				return _IteratorWrapper;
			}
			return m_AnnotationWrapper;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200298", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal Weapon CloneFacade(Contact contact_0)
	{
		try
		{
			if (Information.IsNothing(factoryWrapper) && !attributeWrapper)
			{
				List<Mount> list = Misc.EnableRequest(myUnit.Mounts);
				float num = 0f;
				foreach (Mount item in list)
				{
					if (!(item.MountMagazine.TimeToFire <= 0f) || item.Status != 0)
					{
						continue;
					}
					foreach (WeaponRec mountWeapon in item.MountWeapons)
					{
						Weapon weapon_ = mountWeapon.GetReferenceWeapon(myUnit.ParentScen);
						if (weapon_.IsSoftKill && !weapon_.IsMobileDecoy_Sub)
						{
							continue;
						}
						if (weapon_.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							if (((!flag) ?? flag).GetValueOrDefault())
							{
								continue;
							}
						}
						int? num2 = RegisterConsumer(ref contact_0, ref weapon_);
						if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault() && weapon_.MaxSubsurfaceRange > num && mountWeapon.CurrentLoad > 0 && (weapon_.ValidTargets.Mine || weapon_.ValidTargets.Submarine || weapon_.ValidTargets.Torpedo))
						{
							factoryWrapper = weapon_;
							num = weapon_.MaxSubsurfaceRange;
						}
					}
				}
				if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						Weapon weapon_2 = weaponRec.GetReferenceWeapon(myUnit.ParentScen);
						if (weapon_2.IsSoftKill && !weapon_2.IsMobileDecoy_Sub)
						{
							continue;
						}
						if (weapon_2.IsNuke.Value)
						{
							byte? b2 = (byte?)myUnit.Doctrine.GetNukesAllowed(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
							if (((!flag2) ?? flag2).GetValueOrDefault())
							{
								continue;
							}
						}
						int? num3 = RegisterConsumer(ref contact_0, ref weapon_2);
						if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault() && weapon_2.MaxSubsurfaceRange > num && weaponRec.CurrentLoad > 0 && (weapon_2.ValidTargets.Mine || weapon_2.ValidTargets.Submarine || weapon_2.ValidTargets.Torpedo))
						{
							factoryWrapper = weapon_2;
							num = weapon_2.MaxSubsurfaceRange;
						}
					}
				}
				attributeWrapper = true;
			}
			return factoryWrapper;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200299", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public List<Weapon> IsGuidingWeaponsInAir_List()
	{
		List<Weapon> list = new List<Weapon>();
		if (myUnit.ParentScen.GuidedWeaponsInAir.Count == 0)
		{
			return list;
		}
		foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
		{
			if (item.DataLinkParent != null && item.DataLinkParent == myUnit)
			{
				list.Add(item);
				continue;
			}
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			for (int i = 0; i < sensors_Cached.Length; i = checked(i + 1))
			{
				if (sensors_Cached[i].SemiActiveWeaponsGuided.Contains(item))
				{
					list.Add(item);
				}
			}
			if (item.Guidance == Weapon.WeaponGuidanceType.Inertial_Plus_SemiActive && item.FiringParent == myUnit)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public bool IsGuidingWeaponsInAir()
	{
		if (myUnit.ParentScen.GuidedWeaponsInAir.Count == 0)
		{
			return false;
		}
		foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
		{
			if (Information.IsNothing(item.DataLinkParent) || item.DataLinkParent != myUnit)
			{
				Sensor[] sensors_Cached = myUnit.Sensors_Cached;
				for (int i = 0; i < sensors_Cached.Length; i = checked(i + 1))
				{
					if (sensors_Cached[i].SemiActiveWeaponsGuided.Contains(item))
					{
						return true;
					}
				}
				continue;
			}
			return true;
		}
		return false;
	}

	public bool IsGuidingWeaponsOntoThisContact(Contact contact_0)
	{
		try
		{
			if (myUnit.ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return false;
			}
			if (myUnit.Sensory.IsIlluminatingThisContact(contact_0))
			{
				return true;
			}
			if (Information.IsNothing(contact_0.ActualUnit))
			{
				return false;
			}
			foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
			{
				if (!Information.IsNothing(item.AI.PrimaryTarget) && Operators.CompareString(item.AI.PrimaryTarget._ActualUnitID, contact_0._ActualUnitID, TextCompare: false) == 0)
				{
					if (myUnit.Sensory.IsIlluminatingThisContact(contact_0))
					{
						return true;
					}
					if (!Information.IsNothing(item.DataLinkParent) && item.DataLinkParent == myUnit)
					{
						return true;
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100347", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void ConnectFacade(Weapon weapon_0)
	{
		if (!weapon_0.IsBallisticMissile && Debugger.IsAttached)
		{
			Debugger.Break();
			return;
		}
		TrajectoryPoint[] array = new TrajectoryPoint[0];
		array = BallisticMissile_Kinematics.EstimatedFutureBallisticPath(weapon_0, weapon_0.GetLatitude(), weapon_0.GetLongitude(), weapon_0.AI.PrimaryTarget, weapon_0.ParentScen);
		float float_ = ((array.Length == 0) ? ((float)weapon_0.Kinematics.GetMaximumSpeed(weapon_0.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false)) : (Math2.VerifyClass(weapon_0.GetLatitude(), weapon_0.GetLongitude(), array.Last().Latitude, array.Last().Longitude) / ((float)array.Length / 3600f)));
		weapon_0.Navigator.CalculateDescriptor(float_, bool_1: false);
		if (weapon_0.Navigator.PlottedCourse.Count() <= 0 || !weapon_0.HasTerminalGuidance)
		{
			return;
		}
		if (weapon_0.AI.PrimaryTarget != null && weapon_0.AI.PrimaryTarget.CurrentSpeed > 0f)
		{
			float num = Module_Unit.BearingToPoint_True(weapon_0, weapon_0.Navigator.PlottedCourse[0].Latitude, weapon_0.Navigator.PlottedCourse[0].Longitude);
			Geopoint_Struct geopoint_Struct = MathFunctions.Intersection(weapon_0.GetLatitude(), weapon_0.GetLongitude(), num, weapon_0.AI.PrimaryTarget.GetLatitude(), weapon_0.AI.PrimaryTarget.GetLongitude(), weapon_0.AI.PrimaryTarget.CurrentHeading);
			if (!geopoint_Struct.HasZeroCoords)
			{
				Contact contact_ = new AimpointContact(geopoint_Struct.Latitude, geopoint_Struct.Longitude);
				array = BallisticMissile_Kinematics.EstimatedFutureBallisticPath(weapon_0, weapon_0.GetLatitude(), weapon_0.GetLongitude(), contact_, weapon_0.ParentScen);
			}
		}
		if (array.Length == 0)
		{
			return;
		}
		float num2 = Math2.VerifyClass(weapon_0.GetLatitude(), weapon_0.GetLongitude(), weapon_0.Navigator.PlottedCourse[0].Latitude, weapon_0.Navigator.PlottedCourse[0].Longitude);
		int num3 = array.Length - 1;
		while (true)
		{
			if (num3 > 0)
			{
				if (Math2.VerifyClass(weapon_0.GetLatitude(), weapon_0.GetLongitude(), array[num3].Latitude, array[num3].Longitude) <= num2)
				{
					break;
				}
				num3--;
				continue;
			}
			return;
		}
		weapon_0.Navigator.PlottedCourse[0].Altitude = array[num3].Altitude;
	}

	public void Disarm()
	{
		if (myUnit.Mounts != null)
		{
			myUnit.Mounts.Clear();
		}
		if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
		{
			((Aircraft)myUnit).Loadout.ClearAllWeapons();
		}
		if (myUnit.SharedMagazines != null)
		{
			Magazine[] gparam_ = myUnit.SharedMagazines;
			ArrayExtensions.Clear(ref gparam_);
		}
		if (myUnit.TotalMagazines != null)
		{
			Magazine[] gparam_2 = myUnit.TotalMagazines;
			ArrayExtensions.Clear(ref gparam_2);
		}
	}

	internal List<Weapon> MoveFacade()
	{
		List<Weapon> list = new List<Weapon>();
		foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
		{
			if (item.GuidanceHasSemiActivePhase() && item.AI.PrimaryTarget == myUnit.AI.PrimaryTarget && item.FiringParent == myUnit)
			{
				list.Add(item);
			}
		}
		return list;
	}

	internal List<Weapon> DeleteFacade()
	{
		List<Weapon> list = new List<Weapon>();
		foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
		{
			if (item.GuidanceHasDataLink() && item.DataLinkParent == myUnit)
			{
				list.Add(item);
			}
		}
		return list;
	}

	[CompilerGenerated]
	private bool AddFacade(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMine;
	}

	[CompilerGenerated]
	private bool DestroyFacade(WeaponSalvo.Shooter shooter_0)
	{
		return Operators.CompareString(shooter_0.ShooterObjectID, myUnit.ObjectID, TextCompare: false) == 0;
	}

	[CompilerGenerated]
	private void ComputeFacade(Tuple<int, string> tuple_0)
	{
		Weapon weapon = null;
		Contact contact = null;
		try
		{
			int item = tuple_0.Item1;
			string Local_TargetObjectID = tuple_0.Item2;
			try
			{
				List<Contact> list = myUnit.AI.Targets_ReadOnly.Where((Contact theC) => Operators.CompareString(theC.ObjectID, Local_TargetObjectID, TextCompare: false) == 0).ToList();
				if (list.Count > 0)
				{
					contact = list[0];
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200441", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
			if (contact == null)
			{
				return;
			}
			Doctrine._GunStrafeGroundTargets? nullable_ = myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			foreach (Weapon item2 in PrepareConsumer(contact, ref nullable_))
			{
				if (item2.DBID == item)
				{
					weapon = item2;
				}
			}
			if (weapon != null)
			{
				Tuple<DLZResultEnum, float> value = method_0(contact, weapon, bool_1: false);
				if (DLZ_ResultsCache == null)
				{
					DLZ_ResultsCache = new ConcurrentDictionary<Tuple<int, string>, Tuple<DLZResultEnum, float>>();
				}
				DLZ_ResultsCache.TryAdd(new Tuple<int, string>(item, Local_TargetObjectID), value);
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
	private float PatchFacade(PrototypeCallbackCandidate prototypeCallbackCandidate_0)
	{
		return ((WeaponRec)prototypeCallbackCandidate_0.m_ClassComparator).GetReferenceWeapon(myUnit.ParentScen).OrderReponse();
	}

	[CompilerGenerated]
	private bool SelectFacade(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsLaserShot;
	}

	[CompilerGenerated]
	private float CallFacade(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).MaxAirRange;
	}

	[CompilerGenerated]
	private int LogoutFacade(WeaponRec weaponRec_0)
	{
		Weapon weapon_ = weaponRec_0.GetReferenceWeapon(myUnit.ParentScen);
		ActiveUnit_AI aI;
		Contact contact_ = (aI = myUnit.AI).PrimaryTarget;
		int result = WeaponSuitabilityForThisTarget(ref weapon_, ref contact_, bool_1: true);
		aI.PrimaryTarget = contact_;
		return result;
	}
}
