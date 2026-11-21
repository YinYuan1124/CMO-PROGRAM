using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class UnguidedWeapon : Module_Unit.Unit
{
	[CompilerGenerated]
	private sealed class DefinitionMerchantPage
	{
		public UnguidedWeapon Me;

		public WeaponSalvo Local_ParentWS;

		internal bool GetInterruptibleParam(UnguidedWeapon theUW)
		{
			if (Operators.CompareString(theUW.FiringParent_ID, Me.FiringParent_ID, TextCompare: false) == 0)
			{
				return Local_ParentWS.WeaponList.Contains(theUW.ObjectID);
			}
			return false;
		}
	}

	private int fieldProxy;

	private Weapon queueProxy;

	private Weapon._WeaponType m_RegProxy;

	public float CEP_Surface;

	public float CEP_Land;

	public float CruiseAltitude_AGL;

	public float CruiseAltitude_ASL;

	public float AirPOK;

	public float SurfPOK;

	public float LandPOK;

	public float SubPOK;

	public float MaxAirRange;

	public float MinAirRange;

	public float MaxSurfaceRange;

	public float MinSurfaceRange;

	public float MaxLandRange;

	public float MinLandRange;

	public float MaxSubsurfaceRange;

	public float MinSubsurfaceRange;

	public float MinLaunchAlt_AGL;

	public float MaxLaunchAlt_AGL;

	public float MinTargetAlt_AGL;

	public float MaxTargetAlt_AGL;

	public float MinLaunchAlt_ASL;

	public float MaxLaunchAlt_ASL;

	public float MinTargetAlt_ASL;

	public float MaxTargetAlt_ASL;

	public Warhead[] Warheads;

	public Weapon.WeaponFlags Flags;

	public Contact Target;

	private float _ParamProxy;

	private GeoPoint _PageProxy;

	private float _RulesProxy;

	private ActiveUnit _MethodProxy;

	public string FiringParent_ID;

	internal int serviceProxy;

	public string FiringWeaponRec_ID;

	private float _SystemProxy;

	internal ActiveUnit _CandidateProxy;

	public string Mine_Targeted_ID;

	[ThreadStatic]
	private static StringBuilder m_BaseProxy;

	private bool? m_PolicyProxy;

	private bool broadcasterProxy;

	public GeoPoint LaunchPoint
	{
		get
		{
			return _PageProxy;
		}
		set
		{
			_PageProxy = value;
		}
	}

	public override string AnnexAndDBID => "武器_" + Conversions.ToString(ReferenceWeapon.DBID);

	public ActiveUnit FiringParent
	{
		get
		{
			if (_MethodProxy == null)
			{
				return null;
			}
			if (_MethodProxy.IsDestroyed)
			{
				return null;
			}
			return _MethodProxy;
		}
		set
		{
			_MethodProxy = value;
		}
	}

	public Weapon ReferenceWeapon => queueProxy;

	public float TimeToDetonate
	{
		get
		{
			return _RulesProxy;
		}
		set
		{
			_RulesProxy = value;
		}
	}

	public Weapon._WeaponType Type
	{
		get
		{
			return m_RegProxy;
		}
		set
		{
			m_RegProxy = value;
		}
	}

	public bool IsUnderwaterWeapon
	{
		get
		{
			if (IsMine)
			{
				return true;
			}
			if (Type == Weapon._WeaponType.DepthCharge)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsMine
	{
		get
		{
			Weapon._WeaponType type = Type;
			if ((uint)(type - 4004) > 5u && type != Weapon._WeaponType.DummyMine)
			{
				return false;
			}
			return true;
		}
	}

	public float OptimumBurstHeight
	{
		get
		{
			if (Warheads.Length == 0)
			{
				return 0f;
			}
			if (Warheads[0].IsCluster)
			{
				return 800f;
			}
			return 0f;
		}
	}

	public new string ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		if (m_BaseProxy == null)
		{
			m_BaseProxy = new StringBuilder();
		}
		else
		{
			m_BaseProxy.Clear();
		}
		try
		{
			m_BaseProxy.Append("<UnguidedWeapon>");
			m_BaseProxy.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0.Contains(ObjectID))
			{
				m_BaseProxy.Append("</UnguidedWeapon>");
				return m_BaseProxy.ToString();
			}
			hashSet_0.Add(ObjectID);
			m_BaseProxy.Append("<DBID>").Append(fieldProxy.ToString()).Append("</DBID>");
			m_BaseProxy.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			if (CurrentHeading != 0f)
			{
				m_BaseProxy.Append("<CurrentHeading>").Append(XmlConvert.ToString(CurrentHeading)).Append("</CurrentHeading>");
			}
			if (CurrentSpeed != 0f)
			{
				m_BaseProxy.Append("<CurrentSpeed>").Append(XmlConvert.ToString(CurrentSpeed)).Append("</CurrentSpeed>");
			}
			if (GetCurrentAltitude() != 0f)
			{
				m_BaseProxy.Append("<CurrentAltitude>").Append(XmlConvert.ToString(GetCurrentAltitude())).Append("</CurrentAltitude>");
			}
			if (ImpactAltitude != 0f)
			{
				m_BaseProxy.Append("<ImpactAltitude>").Append(XmlConvert.ToString(ImpactAltitude)).Append("</ImpactAltitude>");
			}
			m_BaseProxy.Append("<Longitude>").Append(XmlConvert.ToString(GetLongitude())).Append("</Longitude>");
			m_BaseProxy.Append("<Latitude>").Append(XmlConvert.ToString(GetLatitude())).Append("</Latitude>");
			if (GetUnitSide() != null)
			{
				m_BaseProxy.Append("<Side>").Append(SecurityElement.Escape(GetUnitSide().Name)).Append("</Side>");
			}
			if (CEP_Surface != 0f)
			{
				m_BaseProxy.Append("<CEP_Surface>").Append(XmlConvert.ToString(CEP_Surface)).Append("</CEP_Surface>");
			}
			if (CEP_Land != 0f)
			{
				m_BaseProxy.Append("<CEP_Land>").Append(XmlConvert.ToString(CEP_Land)).Append("</CEP_Land>");
			}
			if (Target != null)
			{
				m_BaseProxy.Append("<Target>").Append(Target.ObjectID).Append("</Target>");
			}
			if (_ParamProxy != 0f)
			{
				m_BaseProxy.Append("<TimeToLive>").Append(XmlConvert.ToString(_ParamProxy)).Append("</TimeToLive>");
			}
			if (LaunchPoint != null)
			{
				m_BaseProxy.Append("<LaunchPoint>").Append(LaunchPoint.ToXML(hashSet_0)).Append("</LaunchPoint>");
			}
			if (_RulesProxy != 0f)
			{
				m_BaseProxy.Append("<TimeToDetonate>").Append(XmlConvert.ToString(_RulesProxy)).Append("</TimeToDetonate>");
			}
			if (FiringParent != null)
			{
				m_BaseProxy.Append("<FiringParent>").Append(FiringParent.ObjectID).Append("</FiringParent>");
			}
			if (serviceProxy != 0)
			{
				m_BaseProxy.Append("<DirectorDBID>").Append(serviceProxy).Append("</DirectorDBID>");
			}
			if (!string.IsNullOrEmpty(FiringWeaponRec_ID))
			{
				m_BaseProxy.Append("<FiringWR>").Append(FiringWeaponRec_ID).Append("</FiringWR>");
			}
			if (_CandidateProxy != null)
			{
				m_BaseProxy.Append("<MineTargeted>").Append(_CandidateProxy.ObjectID).Append("</MineTargeted>");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100852", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			m_BaseProxy.Append("</UnguidedWeapon>");
		}
		return m_BaseProxy.ToString();
	}

	public static bool IsBurst(string string_0)
	{
		return string_0.ToLower().Contains("burst");
	}

	public static bool IsSalvo(string string_0)
	{
		return string_0.ToLower().Contains("salvo");
	}

	internal bool PrepareWatcher()
	{
		switch (Type)
		{
		default:
			return false;
		case Weapon._WeaponType.Rocket:
		case Weapon._WeaponType.IronBomb:
		case Weapon._WeaponType.Gun:
		case Weapon._WeaponType.TrainingRound:
		case Weapon._WeaponType.PalletWeapon:
		case Weapon._WeaponType.Laser:
		case Weapon._WeaponType.Microwave:
			return true;
		}
	}

	public void PostDeserializationHousekeeping(ref Scenario scenario_0)
	{
		try
		{
			if (FiringParent_ID != null)
			{
				scenario_0.ActiveUnits.TryGetValue(FiringParent_ID, ref _MethodProxy);
			}
			if (Mine_Targeted_ID != null)
			{
				scenario_0.ActiveUnits.TryGetValue(Mine_Targeted_ID, ref _CandidateProxy);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101295", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static UnguidedWeapon FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			int int_ = ((Misc.StartRequest(xmlNode_0.ChildNodes, "DBID") == null) ? DBFunctions.GetActiveUnitIDByName(Misc.StartRequest(xmlNode_0.ChildNodes, "Name").InnerText, GlobalVariables.ActiveUnitType.Weapon, scenario_0.DBConnection) : Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText));
			UnguidedWeapon unguidedWeapon = new UnguidedWeapon(scenario_0.Cache_GetWeapon(int_), null, null, 0.0, 0.0, 0L);
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "CurrentAltitude":
						unguidedWeapon.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "Name":
						unguidedWeapon.Name = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							unguidedWeapon.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(unguidedWeapon.ObjectID, unguidedWeapon);
							break;
						}
						return (UnguidedWeapon)concurrentDictionary_0[xmlNode.InnerText];
					case "DirectorDBID":
						unguidedWeapon.serviceProxy = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Latitude":
						unguidedWeapon.SetLatitude(null, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "Longitude":
						unguidedWeapon.SetLongitude(null, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "LaunchPoint":
					{
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						unguidedWeapon._PageProxy = GeoPoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
						break;
					}
					case "FiringParent":
						unguidedWeapon.FiringParent_ID = xmlNode.InnerText;
						break;
					case "Target":
						unguidedWeapon.Target = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "TimeToDetonate":
						unguidedWeapon._RulesProxy = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "Side":
						unguidedWeapon.SetUnitSide(bool_0: false, Side.FromXML_ByName(xmlNode.InnerText, ref concurrentDictionary_0, scenario_0));
						break;
					case "MineTargeted":
						unguidedWeapon.Mine_Targeted_ID = xmlNode.InnerText;
						break;
					case "TimeToLive":
						unguidedWeapon._ParamProxy = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CEP_Land":
						unguidedWeapon.CEP_Land = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CurrentSpeed":
						unguidedWeapon.CurrentSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CEP":
					case "CEP_Surface":
						unguidedWeapon.CEP_Surface = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CurrentHeading":
						unguidedWeapon.CurrentHeading = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "FiringWR":
						unguidedWeapon.FiringWeaponRec_ID = xmlNode.InnerText;
						break;
					case "ImpactAltitude":
						unguidedWeapon.ImpactAltitude = XmlConvert.ToSingle(xmlNode.InnerText);
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
			return unguidedWeapon;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100853", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private UnguidedWeapon()
	{
		Warheads = new Warhead[0];
		Flags = default(Weapon.WeaponFlags);
		_CandidateProxy = null;
	}

	[SpecialName]
	public WeaponSalvo GetParentSalvo(Scenario scenario_0)
	{
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			WeaponSalvo[] weaponSalvos = sides_ReadOnly[i].WeaponSalvos;
			WeaponSalvo[] array = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array)
			{
				if (weaponSalvo.WeaponList.Contains(ObjectID))
				{
					return weaponSalvo;
				}
			}
		}
		return null;
	}

	[SpecialName]
	public WeaponSalvo.Shooter GetParentSalvoShooter(Scenario scenario_0)
	{
		if (!Information.IsNothing(_MethodProxy))
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				WeaponSalvo[] weaponSalvos = sides_ReadOnly[i].WeaponSalvos;
				WeaponSalvo[] array = weaponSalvos;
				foreach (WeaponSalvo weaponSalvo in array)
				{
					if (!weaponSalvo.WeaponList.Contains(ObjectID))
					{
						continue;
					}
					WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
					WeaponSalvo.Shooter[] array2 = shootersList;
					foreach (WeaponSalvo.Shooter shooter in array2)
					{
						if (Operators.CompareString(shooter.ShooterObjectID, _MethodProxy.ObjectID, TextCompare: false) == 0)
						{
							return shooter;
						}
					}
				}
			}
		}
		return null;
	}

	public UnguidedWeapon(Weapon weapon_0, Contact contact_0, ActiveUnit activeUnit_0, double double_0, double double_1, long long_0 = 0L)
	{
		Warheads = new Warhead[0];
		Flags = default(Weapon.WeaponFlags);
		_CandidateProxy = null;
		try
		{
			fieldProxy = weapon_0.DBID;
			queueProxy = weapon_0;
			UnitClass = weapon_0.UnitClass;
			Name = weapon_0.Name;
			m_RegProxy = weapon_0.Type;
			CruiseAltitude_AGL = weapon_0.CruiseAltitude_AGL;
			CruiseAltitude_ASL = weapon_0.CruiseAltitude_ASL;
			SurfPOK = weapon_0.SurfPOK;
			LandPOK = weapon_0.LandPOK;
			SubPOK = weapon_0.SubPOK;
			AirPOK = weapon_0.AirPOK;
			MaxAirRange = weapon_0.MaxAirRange;
			MinAirRange = weapon_0.MinAirRange;
			MaxSurfaceRange = weapon_0.MaxSurfaceRange;
			MinSurfaceRange = weapon_0.MinSurfaceRange;
			MaxLandRange = weapon_0.MaxLandRange;
			MinLandRange = weapon_0.MinLandRange;
			MaxSubsurfaceRange = weapon_0.MaxSubsurfaceRange;
			MinSubsurfaceRange = weapon_0.MinSubsurfaceRange;
			MaxLaunchAlt_AGL = weapon_0.MaxLaunchAlt_AGL;
			MinLaunchAlt_AGL = weapon_0.MinLaunchAlt_AGL;
			MaxLaunchAlt_ASL = weapon_0.MaxLaunchAlt_ASL;
			MinLaunchAlt_ASL = weapon_0.MinLaunchAlt_ASL;
			MaxTargetAlt_AGL = weapon_0.MaxTargetAlt_AGL;
			MinTargetAlt_AGL = weapon_0.MinTargetAlt_AGL;
			MaxTargetAlt_ASL = weapon_0.MaxTargetAlt_ASL;
			MinTargetAlt_ASL = weapon_0.MinTargetAlt_ASL;
			CEP_Land = weapon_0.CEP_Land;
			CEP_Surface = weapon_0.CEP_Surface;
			if (long_0 == 0)
			{
				_RulesProxy = weapon_0.m_ObserverReader;
			}
			else
			{
				_RulesProxy = long_0;
			}
			if (activeUnit_0 != null)
			{
				FiringParent_ID = activeUnit_0.ObjectID;
			}
			if (m_RegProxy == Weapon._WeaponType.Laser)
			{
				_RulesProxy = 2f;
			}
			else if (m_RegProxy == Weapon._WeaponType.LaserDazzler)
			{
				_RulesProxy = 3f;
			}
			if (m_RegProxy == Weapon._WeaponType.Microwave)
			{
				_RulesProxy = 5f;
			}
			DBFunctions.PopulateWeaponFlags(ref weapon_0, ref Flags);
			DBFunctions.PopulateWarheads(ref Warheads, ref weapon_0);
			Target = contact_0;
			if (!Information.IsNothing(activeUnit_0) && !Information.IsNothing(contact_0))
			{
				float currentSpeed = activeUnit_0.CurrentSpeed;
				double num = (double)GameGeneral.LockRandom_0.Next(95, 106) / 100.0;
				switch (m_RegProxy)
				{
				case Weapon._WeaponType.DepthCharge:
					if (contact_0.SpeedIsKnown)
					{
						CurrentSpeed = (float)((double)(currentSpeed / 2f + contact_0.CurrentSpeed * 2f) + (double)(MaxSubsurfaceRange * 5f) * num);
					}
					else
					{
						CurrentSpeed = (float)((double)(currentSpeed / 2f) + (double)(MaxSubsurfaceRange * 5f) * num);
					}
					break;
				case Weapon._WeaponType.Rocket:
					switch (contact_0.Type)
					{
					default:
						CurrentSpeed = (float)((double)(currentSpeed + MaxSubsurfaceRange * 100f) * num);
						break;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
					case Contact_Base.ContactType.Orbital:
						CurrentSpeed = (float)((double)(currentSpeed + MaxAirRange * 100f) * num);
						break;
					case Contact_Base.ContactType.Surface:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						CurrentSpeed = (float)((double)(currentSpeed + MaxSurfaceRange * 100f) * num);
						break;
					}
					break;
				case Weapon._WeaponType.IronBomb:
					if (Flags.IsRetardedWeapon)
					{
						CurrentSpeed = (float)((double)currentSpeed * 0.4 * num);
					}
					else
					{
						CurrentSpeed = (float)((double)currentSpeed * 0.9 * num);
					}
					break;
				case Weapon._WeaponType.Gun:
				{
					double num2 = CalculateGunMuzzleVelocity_mpersec(contact_0.Type, ReferenceWeapon.MaxRange_NoTargetType, IsGunOrRocketAttackGround()) * 1.94384;
					CurrentSpeed = (float)((double)currentSpeed + num2 * num);
					Warhead.WarheadType type = Warheads[0].Type;
					if (type == Warhead.WarheadType.ArmorPiercing || type == Warhead.WarheadType.LongRodPenetrator)
					{
						CurrentSpeed = (float)((double)(CurrentSpeed * 2f) * num);
					}
					break;
				}
				}
			}
			if (Information.IsNothing(activeUnit_0))
			{
				_PageProxy = new GeoPoint(double_1, double_0, 0f);
			}
			else
			{
				_PageProxy = new GeoPoint(double_1, double_0, activeUnit_0.GetCurrentAltitude());
			}
			SetLatitude(null, double_0);
			SetLongitude(null, double_1);
			if (Information.IsNothing(contact_0))
			{
				return;
			}
			if (Type == Weapon._WeaponType.IronBomb && !Information.IsNothing(activeUnit_0) && !Information.IsNothing(contact_0))
			{
				float num3 = Math.Abs(activeUnit_0.GetCurrentAltitude() - contact_0.GetCurrentAltitude());
				float num4 = ((num3 <= 5000f) ? ((float)Math.Sqrt((double)num3 / 4.5)) : (33f + (num3 - 5000f) / 300f));
				_RulesProxy = Math.Max(num4, _RulesProxy);
				if (num4 > 0f)
				{
					CurrentSpeed = Math.Min(activeUnit_0.CurrentSpeed - 10f, 3600f * Module_Unit.RangeToUnit_Horiz(activeUnit_0, contact_0) / num4);
				}
				_ParamProxy = _RulesProxy + 1f;
			}
			else
			{
				double val = ((!contact_0.SpeedIsKnown || contact_0.CurrentSpeed <= 0f) ? (3600.0 * ReflectWatcher() / (double)CurrentSpeed) : (3600.0 * ReflectWatcher() * 2.0 / (double)CurrentSpeed));
				_ParamProxy = (float)Math.Max(val, TimeToDetonate + 1f);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100854", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool myTargetHasBeenDestroyed(Scenario scenario_0)
	{
		return Target.GetIsDestroyed(scenario_0);
	}

	private double ReflectWatcher()
	{
		return Math.Max(MaxAirRange, Math.Max(MaxSurfaceRange, Math.Max(MaxLandRange, MaxSubsurfaceRange)));
	}

	public static string CanLayMineHere(ref UnguidedWeapon unguidedWeapon_0, double double_0, double double_1, float float_0, Scenario scenario_0)
	{
		try
		{
			if (float_0 <= 0f)
			{
				switch (unguidedWeapon_0.Type)
				{
				case Weapon._WeaponType.BottomMine:
					if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
					{
						if (float_0 < unguidedWeapon_0.MinTargetAlt_ASL)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_ASL * 3.28084f)) + "英尺，而水深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_ASL)) + "米而水深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
						if (float_0 > -5f)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太浅了。最小布雷深度是" + Conversions.ToString(16) + "英尺而海深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太浅了。最小布雷深度是" + Conversions.ToString(5) + "米而海深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
					}
					else
					{
						if (float_0 < unguidedWeapon_0.MinTargetAlt_AGL)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_AGL * 3.28084f)) + "英尺，而水深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_AGL)) + "米而水深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
						if (float_0 > -5f)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太浅了。最小布雷深度是" + Conversions.ToString(16) + "英尺而海深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太浅了。最小布雷深度是" + Conversions.ToString(5) + "米而海深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
					}
					unguidedWeapon_0.SetCurrentAltitude(bool_0: false, float_0);
					break;
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.DriftingMine:
					unguidedWeapon_0.SetCurrentAltitude(bool_0: false, 0f);
					break;
				case Weapon._WeaponType.MooredMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DummyMine:
					if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
					{
						if (float_0 < unguidedWeapon_0.MinTargetAlt_ASL)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_ASL * 3.28084f)) + "英尺，而水深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_ASL)) + "米而水深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
						if (float_0 > unguidedWeapon_0.MaxTargetAlt_ASL)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太浅了。最小布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MaxTargetAlt_ASL * 3.28084f)) + "英尺而海深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太浅了。最小布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MaxTargetAlt_ASL)) + "米而海深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
					}
					else
					{
						if (float_0 < unguidedWeapon_0.MinTargetAlt_AGL)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_AGL * 3.28084f)) + "英尺，而水深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太深了。最大布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MinTargetAlt_AGL)) + "米而水深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
						if (float_0 > unguidedWeapon_0.MaxTargetAlt_AGL)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "水太浅了。最小布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MaxTargetAlt_AGL * 3.28084f)) + "英尺而海深是" + Conversions.ToString((int)Math.Round(float_0 * 3.28084f)) + "英尺。";
							}
							return "水太浅了。最小布雷深度是" + Conversions.ToString((int)Math.Round(unguidedWeapon_0.MaxTargetAlt_ASL)) + "米而海深是" + Conversions.ToString((int)Math.Round(float_0)) + "米。";
						}
					}
					unguidedWeapon_0.SetCurrentAltitude(bool_0: false, (float)((double)float_0 + GameGeneral.LockRandom_0.NextDouble() * (double)(0f - float_0) - 5.0));
					break;
				}
				unguidedWeapon_0.SetLatitude(null, double_0);
				unguidedWeapon_0.SetLongitude(null, double_1);
				return "OK";
			}
			return "不能在陆地上放置水雷！";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100855", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "不能在这里布雷（错误！）";
		}
	}

	public void Detonate(Scenario scenario_0)
	{
		try
		{
			float float_;
			if (ReferenceWeapon.IsNuke.Value)
			{
				if (Type == Weapon._WeaponType.DepthCharge)
				{
					byte? b = (byte?)ReferenceWeapon?.AI.PrimaryTarget?.Type;
					if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 22) : null).GetValueOrDefault())
					{
						b = (byte?)ReferenceWeapon?.AI.PrimaryTarget?.Type;
						if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
						{
							Contact target = Target;
							if (target == null || target.Type != Contact_Base.ContactType.ActivationPoint)
							{
								Contact target2 = Target;
								if (target2 == null || target2.Type != Contact_Base.ContactType.Aimpoint)
								{
									float_ = GetCurrentAltitude();
									goto IL_020b;
								}
							}
							float_ = Math.Max(GetLandElevation(bool_0: false, bool_1: false, bool_2: false, scenario_0), -300);
							goto IL_020b;
						}
					}
					float_ = Math.Max(GetLandElevation(bool_0: false, bool_1: false, bool_2: false, scenario_0), -300);
				}
				else
				{
					float_ = OptimumBurstHeight + (float)Math.Max(0, GetLandElevation(bool_0: false, bool_1: false, bool_2: false, scenario_0));
				}
			}
			else
			{
				float_ = GetCurrentAltitude();
			}
			goto IL_020b;
			IL_020b:
			if (Warheads.Count() > 0)
			{
				new Explosion(ref scenario_0, GetLongitude(), GetLatitude(), GetLongitude(), GetLatitude(), CurrentHeading, float_, Type, Warheads[0].DP, Warheads[0].DP, Warheads[0].Type, Warheads[0].ExplosivesType, null, null, FiringParent, null, null, 0, 0);
				DestroyMe(ref scenario_0, "Intentional detonation");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100856", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private bool IsGunOrRocketAttackGround()
	{
		if (!m_PolicyProxy.HasValue)
		{
			if (FiringParent == null || Target == null)
			{
				return false;
			}
			m_PolicyProxy = (Type == Weapon._WeaponType.Gun || Type == Weapon._WeaponType.Rocket) && !FiringParent.IsAircraft && !Target.IsAircraftContact && !Target.IsWeaponContact;
		}
		return m_PolicyProxy.Value;
	}

	private void VisitWatcher(Scenario scenario_0, float float_0)
	{
		ResolveWatcher();
		GetLatitude();
		GetLongitude();
		double num = CalculateGunMuzzleVelocity_mpersec(Target.Type, ReferenceWeapon.MaxRange_NoTargetType, IsGunOrRocketAttackGround());
		if (IsGunOrRocketAttackGround())
		{
			_ParamProxy = float.MaxValue;
			double num7 = _PageProxy.RangeToPoint_Horiz(Target.GetLongitude(), Target.GetLatitude());
			double num8 = num7 / (double)ReferenceWeapon.MaxRange_NoTargetType;
			double num9 = 35.0 * num8;
			double num10 = Math.Pow(num, 2.0) * Math.Pow(Math2.SetClass(num9), 2.0) / 19.62;
			double num11 = (double)CurrentSpeed * Math2.CalculateClass(num9);
			bool? nullable_ = null;
			double double_ = GetLongitude(nullable_);
			bool? nullable_2 = null;
			double double_2 = GetLatitude(nullable_2);
			double double_3 = num11 * (double)float_0 / 3600.0;
			float float_ = CurrentHeading;
			double double_4 = 0.0;
			double double_5 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_4, ref double_5, ref double_3, ref float_);
			CurrentHeading = float_;
			SetLatitude(nullable_2, double_2);
			SetLongitude(nullable_, double_);
			SetLongitude(null, double_4);
			SetLatitude(null, double_5);
			double num12 = num7 * 1852.0 / 2.0;
			double num13 = num10 / Math.Pow(num12, 2.0);
			double x = Math.Abs((double)(Module_Unit.RangeToPoint_Horiz(this, _PageProxy) * 1852f) - num12);
			double num14 = 0.0 - num13 * Math.Pow(x, 2.0) + num10;
			SetCurrentAltitude(bool_0: false, (float)(num14 + (double)_PageProxy.Altitude));
		}
		else
		{
			ActualHorizMovement(float_0, bool_0: false);
			float num2 = Math.Abs(_PageProxy.Altitude - Target.GetCurrentAltitude());
			double num3 = _PageProxy.RangeToPoint_Horiz(Target.GetLongitude(), Target.GetLatitude());
			double num4 = (double)Module_Unit.RangeToUnit_Horiz(this, Target) / num3;
			if (Target.GetCurrentAltitude() <= _PageProxy.Altitude)
			{
				SetCurrentAltitude(bool_0: false, (float)((double)Target.GetCurrentAltitude() + (double)num2 * num4));
			}
			else
			{
				SetCurrentAltitude(bool_0: false, (float)((double)Target.GetCurrentAltitude() - (double)num2 * num4));
			}
		}
		if (Type == Weapon._WeaponType.Gun)
		{
			double num5 = Module_Unit.RangeToPoint_Slant(this, _PageProxy) / ReferenceWeapon.MaxRange_NoTargetType;
			double num6 = num * 1.94384;
			CurrentSpeed = (float)(num6 * (0.34 + 0.67 * (1.0 - num5)));
		}
		ExportLocationEvent(scenario_0, bool_0: false);
	}

	public void TypeSpecificActions(ref Scenario scenario_0, float float_0, ref LockRandom lockRandom_0)
	{
		try
		{
			if (IsMine)
			{
				RestartWatcher(scenario_0, float_0, ref lockRandom_0);
				return;
			}
			if (_RulesProxy > 0f)
			{
				_RulesProxy -= float_0;
			}
			if (Target == null)
			{
				if (Type == Weapon._WeaponType.Gun)
				{
					Detonate(scenario_0);
				}
			}
			else
			{
				if ((Type != Weapon._WeaponType.IronBomb && Module_Unit.RangeToPoint_Horiz(this, Target.GetLatitude(), Target.GetLongitude()) * 2f < CurrentSpeed / 3600f) || (Type == Weapon._WeaponType.IronBomb && _RulesProxy <= 0f))
				{
					try
					{
						if (CurrentAltitude_AGL < 0f)
						{
							SetCurrentAltitude(bool_0: false, GetLandElevation(bool_0: false, bool_1: false, bool_2: false, scenario_0));
						}
						if (GetCurrentAltitude() < 0f)
						{
							SetCurrentAltitude(bool_0: false, Target.GetCurrentAltitude());
						}
						string string_ = null;
						StopWatcher(Target.ActualUnit, Target, ref scenario_0, ref lockRandom_0, ref string_);
						DestroyMe(ref scenario_0, string_, "Impact / Detonation");
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200042", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else if (Type != Weapon._WeaponType.Laser && Type != Weapon._WeaponType.Microwave && Type != Weapon._WeaponType.LaserDazzler)
				{
					VisitWatcher(scenario_0, float_0);
				}
				if ((m_RegProxy == Weapon._WeaponType.Laser || m_RegProxy == Weapon._WeaponType.LaserDazzler) && _RulesProxy <= 0f)
				{
					string string_2 = null;
					StopWatcher(Target.ActualUnit, Target, ref scenario_0, ref lockRandom_0, ref string_2);
					DestroyMe(ref scenario_0, string_2, "Impact / Detonation");
				}
				if (m_RegProxy == Weapon._WeaponType.Microwave && _RulesProxy <= 0f)
				{
					string string_3 = null;
					StopWatcher(Target.ActualUnit, Target, ref scenario_0, ref lockRandom_0, ref string_3);
					List<ActiveUnit> list = new List<ActiveUnit>();
					double num = Module_Unit.BearingToUnit_True(FiringParent, Target);
					double num2 = Module_Unit.GrazingAngleToUnit(FiringParent, Target);
					foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
					{
						if (Module_Unit.RangeToUnit_Slant(FiringParent, activeUnits_) < MaxAirRange)
						{
							Sensor sensor = ReferenceWeapon.Sensors_Cached[0];
							double num3 = sensor.m_RadarHorBeamwidth;
							double num4 = sensor.m_RadarVerBeamwidth;
							double num5 = Module_Unit.BearingToUnit_True(FiringParent, activeUnits_);
							double num6 = Module_Unit.GrazingAngleToUnit(FiringParent, activeUnits_);
							if (Math.Abs(MathFunctions.DeleteRequest((float)num, (float)num5)) < (float)(num3 / 2.0) && Math.Abs(num2 - num6) < num4 / 2.0 && Module_Unit.Has_Radar_LOS_ToUnit(FiringParent, sensor, activeUnits_, ref scenario_0))
							{
								list.Add(activeUnits_);
							}
						}
					}
					foreach (ActiveUnit item in list)
					{
						StopWatcher(item, null, ref scenario_0, ref lockRandom_0, ref string_3);
					}
					DestroyMe(ref scenario_0, string_3, "Impact / Detonation");
				}
			}
			if (!Module_Unit.AwakeTokenizer(this))
			{
				_ParamProxy -= float_0;
				if (_ParamProxy <= 0f)
				{
					DestroyMe(ref scenario_0, "Weapon out of energy/fuel/time", "Missed");
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100857", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RestartWatcher(Scenario scenario_0, float float_0, ref LockRandom lockRandom_0)
	{
		try
		{
			if (_RulesProxy > 0f)
			{
				_RulesProxy = Math.Max(0f, _RulesProxy - float_0);
			}
			_SystemProxy -= float_0;
			ActiveUnit activeUnit = null;
			Sensor sensor_ = null;
			if (_SystemProxy <= 0f)
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				if (_CandidateProxy != null && _CandidateProxy.IsWeapon)
				{
					if ((int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, _CandidateProxy) * 1852.0) < 20)
					{
						Weapon weapon = (Weapon)_CandidateProxy;
						weapon.Detonate(weapon.GetLatitude(), weapon.GetLongitude(), weapon.GetCurrentAltitude(), ref lockRandom_0, bool_0: true);
						if (!weapon._InvocationReader)
						{
							return;
						}
						DestroyMe(ref scenario_0, "Mine neutralized");
						if (IsMine)
						{
							GetUnitSide().AAR.AddToLosses(this, bool_0: false);
						}
						List<EventTrigger> list = new List<EventTrigger>();
						foreach (EventTrigger value in scenario_0.EventTriggers.Values)
						{
							if (value.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value).GetIsFulfilled(this, activeUnit))
							{
								list.Add(value);
							}
						}
						if (list.Count > 0)
						{
							scenario_0.FireEvents(list);
						}
						return;
					}
					if ((int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, _CandidateProxy) * 1852.0) < 500)
					{
						_CandidateProxy.DesiredAltitude = GetCurrentAltitude();
					}
				}
				if (scenario_0.CandidatesForDetectionByMines.Count == 0)
				{
					return;
				}
				bool flag5 = true;
				bool flag6 = true;
				if (Warheads.Count() > 0 && Warheads[0].GetCarriedWeapon(scenario_0) != null)
				{
					Weapon carriedWeapon = Warheads[0].GetCarriedWeapon(scenario_0);
					if (!carriedWeapon.IsASuW_Naval)
					{
						flag5 = false;
					}
					if (!carriedWeapon.IsASW)
					{
						flag6 = false;
					}
				}
				List<ActiveUnit> candidatesForDetectionByMines = scenario_0.CandidatesForDetectionByMines;
				int num = 0;
				int num2 = 0;
				foreach (ActiveUnit item in candidatesForDetectionByMines)
				{
					try
					{
						if (item.IsShip && !flag5)
						{
							continue;
						}
						if (!item.IsSubmarine)
						{
							goto IL_0325;
						}
						if (flag6)
						{
							Submarine._SubmarineType type = ((Submarine)item).Type;
							if (type != Submarine._SubmarineType.SDV && (uint)(type - 4001) > 1u && (uint)(type - 9001) > 1u)
							{
								goto IL_0325;
							}
						}
						goto end_IL_02ac;
						IL_0325:
						double num3 = Math2.TestClass((float)((double)item.GetSafeDistanceAgainstKnownMineType_meters(Type, bool_0: false) / 1852.0));
						if (Type == Weapon._WeaponType.RisingMine && !item.IsMCMPlatform)
						{
							Weapon carriedWeapon2 = Warheads[0].GetCarriedWeapon(item.ParentScen);
							if (!Information.IsNothing(carriedWeapon2))
							{
								num3 = Math2.TestClass(carriedWeapon2.MaxRange_NoTargetType);
							}
						}
						int num4 = ((!item.IsMCMPlatform) ? 1 : 5);
						if (!item.IsAircraft && _RulesProxy == 0f)
						{
							double num5 = Module_Unit.RangeToUnit_Horiz_Angular(this, item);
							if (Type != Weapon._WeaponType.DummyMine && num5 <= num3 && (float)num4 < item.CurrentSpeed && (Type == Weapon._WeaponType.RisingMine || Module_Unit.ClosureSpeed(this, item, CurrentSpeed, CurrentHeading) < 0f))
							{
								flag = true;
								flag2 = true;
								activeUnit = item;
								num = (int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, activeUnit) * 1852.0);
								num2 = (int)Math.Round(Math2.PublishClass(activeUnit.GetLatitude(), activeUnit.GetLongitude(), GetLatitude(), GetLongitude()));
								break;
							}
						}
						if (!flag)
						{
							if (Math.Round(item.DesiredHeading, 2) == Math.Round(item.CurrentHeading, 2))
							{
								foreach (Sensor mineCountermeasure in item.MineCountermeasures)
								{
									if (mineCountermeasure.IsActive && (mineCountermeasure.GetCanSweepThisMine(this) || mineCountermeasure.GetCanTriggerThisMine(this)))
									{
										if (_RulesProxy > 0f)
										{
											Sensor.Sensor_Type type2 = mineCountermeasure.Type;
											if (type2 <= Sensor.Sensor_Type.MineNeutralization_MooredMineCableCutter)
											{
												if ((type2 != Sensor.Sensor_Type.MineSweep_MechanicalCableCutter && type2 != Sensor.Sensor_Type.MineNeutralization_MooredMineCableCutter) || (Type != Weapon._WeaponType.MooredMine && Type != Weapon._WeaponType.DummyMine))
												{
													continue;
												}
											}
											else if (type2 != Sensor.Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal && type2 != Sensor.Sensor_Type.MineNeutralization_DiverExplosiveCharge)
											{
												continue;
											}
										}
										if (mineCountermeasure.IsExplosiveMineNeutralizer)
										{
											num = (int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, item) * 1852.0);
											if (num < 100 && item.CurrentSpeed <= 5f && (_CandidateProxy == null || item.ParentScen.MineAllocation.ContainsKey(item.ObjectID)))
											{
												int num6 = GameGeneral.LockRandom_0.Next(1, 50);
												if (mineCountermeasure.Status == PlatformComponent._ComponentStatus.Operational && num6 < 10)
												{
													flag = true;
													flag4 = true;
													activeUnit = item;
													sensor_ = mineCountermeasure;
													num2 = (int)Math.Round(Math2.PublishClass(activeUnit.GetLatitude(), activeUnit.GetLongitude(), GetLatitude(), GetLongitude()));
													break;
												}
											}
										}
										else if ((Type == Weapon._WeaponType.FloatingMine || Type == Weapon._WeaponType.DriftingMine) && item.IsShip && ((Ship)item).Crew > 0)
										{
											num = (int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, item) * 1852.0);
											if (num < 200 && item.CurrentSpeed <= 5f && GameGeneral.LockRandom_0.Next(1, 50) < 30)
											{
												flag = true;
												flag3 = true;
												activeUnit = item;
												sensor_ = null;
												num2 = (int)Math.Round(Math2.PublishClass(activeUnit.GetLatitude(), activeUnit.GetLongitude(), GetLatitude(), GetLongitude()));
												break;
											}
										}
										if (GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), mineCountermeasure.MineSweepCoverageArea, bool_0: false))
										{
											flag = true;
											flag3 = true;
											activeUnit = item;
											sensor_ = mineCountermeasure;
											num = (int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, activeUnit) * 1852.0);
											num2 = (int)Math.Round(Math2.PublishClass(activeUnit.GetLatitude(), activeUnit.GetLongitude(), GetLatitude(), GetLongitude()));
											break;
										}
									}
									else if (mineCountermeasure.IsActive && mineCountermeasure.MineSweepCoverageArea != null && mineCountermeasure.TimeToNextScan < 1 && _CandidateProxy != null)
									{
										Operators.CompareString(item.ObjectID, _CandidateProxy.ObjectID, TextCompare: false);
									}
								}
							}
							else if (item.IsAircraft)
							{
								if ((double)Math.Abs(MathFunctions.DeleteRequest(item.CurrentHeading, item.DesiredHeading)) < 0.2)
								{
									UnguidedWeapon unguidedWeapon = null;
									if (item.ParentScen.MineAllocation.TryGetValue(item.ObjectID, ref unguidedWeapon) && unguidedWeapon != null)
									{
										float num7 = Module_Unit.RangeToUnit_Horiz(item, unguidedWeapon);
										if ((double)num7 > 0.75)
										{
											item.AI.ManouverToSweepMine(unguidedWeapon, num7, bool_0: true);
										}
									}
								}
							}
							else
							{
								float num8 = Math.Abs(MathFunctions.DeleteRequest(item.CurrentHeading, item.DesiredHeading));
								int num9 = 3;
								if (num8 < 60f)
								{
									num9 = 2;
								}
								if (num8 < 30f)
								{
									num9 = 1;
								}
								if (num8 < 10f)
								{
									num9 = 0;
								}
								foreach (Sensor mineCountermeasure2 in item.MineCountermeasures)
								{
									if (mineCountermeasure2.IsActive && mineCountermeasure2.TimeToNextScan < 1 && !mineCountermeasure2.IsExplosiveMineNeutralizer)
									{
										mineCountermeasure2.TimeToNextScan = num9 * 60;
									}
								}
							}
						}
						goto IL_0a8f;
						end_IL_02ac:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200043", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						goto IL_0a8f;
					}
					continue;
					IL_0a8f:
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					if (flag4)
					{
						activeUnit.NeutralizeMine(this, sensor_);
					}
					else if (_RulesProxy <= 0f)
					{
						if (Warheads.Count() > 0 && Warheads[0].GetCarriedWeapon(scenario_0) != null)
						{
							try
							{
								Contact contact_ = new Contact(activeUnit);
								contact_.SetLatitude(null, activeUnit.GetLatitude());
								contact_.SetLongitude(null, activeUnit.GetLongitude());
								contact_.Type = Contact_Base.ContactType.Aimpoint;
								Weapon weapon_ = Weapon.GetNewWeapon(ref activeUnit.ParentScen, Warheads[0].GetCarriedWeapon(activeUnit.ParentScen).DBID, bool_0: false);
								weapon_.SetUnitSide(bool_0: false, GetUnitSide());
								if (weapon_.IsTorpedo)
								{
									TestWatcher(ref weapon_, weapon_.DBID, ref contact_, ActiveUnit.Throttle.Flank);
								}
								if (weapon_.Type == Weapon._WeaponType.Rocket)
								{
									switch (activeUnit.UnitType)
									{
									default:
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										break;
									case GlobalVariables.ActiveUnitType.Ship:
									case GlobalVariables.ActiveUnitType.Submarine:
										if (flag3)
										{
											weapon_.SetCurrentAltitude(bool_0: false, -1f);
											scenario_0.AddMessage("水下爆炸！仰角" + Conversions.ToString(num2) + "- 范围 " + Conversions.ToString(num) + "米到 " + activeUnit.Name, "声呐传输", LoggedMessage.MessageType.WeaponEndgame, 0, activeUnit.ObjectID, activeUnit.GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
											weapon_.Detonate(weapon_.GetLatitude(), weapon_.GetLongitude(), 0f, ref lockRandom_0, bool_0: true);
										}
										else
										{
											weapon_.SetLongitude(null, activeUnit.GetLongitude());
											weapon_.SetLatitude(null, activeUnit.GetLatitude());
											weapon_.SetCurrentAltitude(bool_0: false, activeUnit.GetCurrentAltitude() - 1f);
											scenario_0.AddMessage("水下爆炸！就在下面" + activeUnit.Name, "声呐传输", LoggedMessage.MessageType.WeaponEndgame, 0, activeUnit.ObjectID, activeUnit.GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
											weapon_.Impact(activeUnit, null);
										}
										break;
									case GlobalVariables.ActiveUnitType.Aircraft:
										weapon_.SetCurrentAltitude(bool_0: false, -1f);
										scenario_0.AddMessage("水下爆炸！仰角" + Conversions.ToString(num2) + "- 范围 " + Conversions.ToString(num) + "米到 " + activeUnit.Name, "声呐传输", LoggedMessage.MessageType.WeaponEndgame, 0, activeUnit.ObjectID, activeUnit.GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
										weapon_.Detonate(weapon_.GetLatitude(), weapon_.GetLongitude(), 0f, ref lockRandom_0, bool_0: true);
										break;
									}
								}
								DestroyMe(ref activeUnit.ParentScen, "Mine detonation", "Impact / Detonation");
							}
							catch (Exception ex2)
							{
								ProjectData.SetProjectError(ex2);
								Exception exception_2 = ex2;
								exception_2?.Data.Add("Error at 200044", exception_2.Message);
								GameGeneral.WriteExceptionsToLog(ref exception_2);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						else if (Type != Weapon._WeaponType.DummyMine && _RulesProxy <= 0f)
						{
							if (Type != Weapon._WeaponType.FloatingMine && Type != Weapon._WeaponType.DriftingMine)
							{
								scenario_0.AddMessage("水下爆炸！仰角" + Conversions.ToString(num2) + "- 范围 " + Conversions.ToString(num) + "米到 " + activeUnit.Name, "声呐传输", LoggedMessage.MessageType.WeaponEndgame, 0, activeUnit.ObjectID, activeUnit.GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
								Detonate(scenario_0);
							}
							else
							{
								scenario_0.AddMessage("Surface detonation! Bearing " + Conversions.ToString(num2) + "- 范围 " + Conversions.ToString(num) + "米到 " + activeUnit.Name, "声呐传输", LoggedMessage.MessageType.WeaponEndgame, 0, activeUnit.ObjectID, activeUnit.GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
								Detonate(scenario_0);
							}
						}
						else
						{
							scenario_0.AddMessage("No mine detonation! Bearing " + Conversions.ToString(num2) + "- 范围 " + Conversions.ToString(num) + "米到 " + activeUnit.Name, "声呐传输", LoggedMessage.MessageType.WeaponEndgame, 0, activeUnit.ObjectID, activeUnit.GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
							DestroyMe(ref scenario_0, "Mine detonated");
						}
					}
					else
					{
						scenario_0.AddMessage("No mine detonation! Bearing " + Conversions.ToString(num2) + "- 范围 " + Conversions.ToString(num) + "米到 " + activeUnit.Name, "声呐传输", LoggedMessage.MessageType.WeaponEndgame, 0, activeUnit.ObjectID, activeUnit.GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
						DestroyMe(ref scenario_0, "Mine detonated");
					}
					if (IsMine && (flag4 || flag3))
					{
						GetUnitSide().AAR.AddToLosses(this, bool_0: false);
					}
					if (IsMine && flag2)
					{
						try
						{
							GetUnitSide().AAR.AddToExpenditures(CancelWatcher(), 1);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					if (IsMine && !flag4)
					{
						if (flag3)
						{
							SetCurrentAltitude(bool_0: false, -1f);
						}
						List<EventTrigger> list2 = new List<EventTrigger>();
						foreach (EventTrigger value2 in scenario_0.EventTriggers.Values)
						{
							if (value2.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value2).GetIsFulfilled(this, activeUnit))
							{
								list2.Add(value2);
							}
						}
						if (list2.Count > 0)
						{
							scenario_0.FireEvents(list2);
						}
					}
				}
			}
			_SystemProxy = (float)(lockRandom_0.NextDouble() * 3.0);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100858", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DestroyMe(ref Scenario scenario_0, string string_0, string string_1 = null)
	{
		try
		{
			scenario_0.DestroyThisUnguidedWeapon(this, string_0, string_1);
			if (GetUnitSide() != null)
			{
				GetUnitSide().RemoveWeaponFromSalvos(ref scenario_0, ref ObjectID);
			}
			string object_ = "-";
			if (string_1 != null)
			{
				object_ = string_1;
			}
			foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
			{
				if (applicableEventExporter.IsOperating && applicableEventExporter.ExportUnitDestroyed)
				{
					Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
					if (scenario_0.MonteCarloIteration > 0)
					{
						dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(scenario_0.Title, typeof(string), 500));
						dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(scenario_0.MonteCarloIteration, typeof(int)));
					}
					dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(scenario_0.TimelineID, typeof(string), 40));
					if (applicableEventExporter.UseZeroHour)
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.Subtract(scenario_0.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
					}
					else
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3"), typeof(DateTime)));
					}
					dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(ObjectID, typeof(string), 40));
					dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(Name, typeof(string), 500));
					dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(UnitClass, typeof(string), 500));
					dictionary.Add("MiscInfo", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					dictionary.Add("Reason", new IEventExporter.EventNotificationParameter(string_0, typeof(string)));
					dictionary.Add("Cause", new IEventExporter.EventNotificationParameter(object_, typeof(string)));
					applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.UnitDestroyed, dictionary, scenario_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 104856", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void TestWatcher(ref Weapon weapon_0, int int_0, ref Contact contact_0, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Cruise)
	{
		if (Information.IsNothing(contact_0.ActualUnit))
		{
			return;
		}
		try
		{
			Scenario parentScen = contact_0.ActualUnit.ParentScen;
			parentScen.UnitsAutoIncrement++;
			weapon_0.Name = weapon_0.Name + " #" + Conversions.ToString(parentScen.UnitsAutoIncrement);
			weapon_0.SetUnitSide(bool_0: false, GetUnitSide());
			weapon_0.AI.PrimaryTarget = contact_0;
			weapon_0.AI.PrimaryTarget_Type = contact_0.Type;
			weapon_0.SetLongitude(null, GetLongitude());
			weapon_0.SetLatitude(null, GetLatitude());
			weapon_0.SetCurrentAltitude(bool_0: true, GetCurrentAltitude());
			weapon_0.SetThrottle(throttle_0);
			weapon_0.Kinematics.GetMaximumSpeed(weapon_0.GetCurrentAltitude(), throttle_0, bool_0: false);
			weapon_0.DesiredSpeed = weapon_0.Kinematics.GetMaximumSpeed(weapon_0.GetCurrentAltitude(), throttle_0, bool_0: false);
			weapon_0.CurrentHeading = Math2.PublishClass(GetLatitude(), GetLongitude(), weapon_0.AI.PrimaryTarget.GetLatitude(), weapon_0.AI.PrimaryTarget.GetLongitude());
			weapon_0.SetDesiredHeading(ActiveUnit.TurnRate.Max, weapon_0.CurrentHeading);
			if (weapon_0.IsTorpedo)
			{
				Sensor[] array = weapon_0.Sensors_ReadOnly();
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (sensor.CanBeActive)
					{
						sensor.GoActive();
					}
				}
			}
			weapon_0.LaunchPoint = new GeoPoint(GetLongitude(), GetLatitude(), GetCurrentAltitude());
			parentScen.AddThisUnit(weapon_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100859", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool StopWatcher(ActiveUnit activeUnit_0, Contact contact_0, ref Scenario scenario_0, ref LockRandom lockRandom_0, ref string string_0)
	{
		string_0 = "";
		if (activeUnit_0 == null)
		{
			return false;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		bool flag = false;
		try
		{
			SetCurrentAltitude(bool_0: false, OptimumBurstHeight + (float)Math.Max(GetLandElevation(bool_0: false, bool_1: false, bool_2: false, scenario_0), 0));
			ImpactAltitude = GetCurrentAltitude();
			float num;
			if (!activeUnit_0.IsWeapon && !activeUnit_0.IsAircraft)
			{
				if (!activeUnit_0.IsSubmarine)
				{
					return VerifyWatcher(activeUnit_0, contact_0, ref scenario_0, ref lockRandom_0, string_0);
				}
				if (!IsTorpedo)
				{
					return VerifyWatcher(activeUnit_0, contact_0, ref scenario_0, ref lockRandom_0, string_0);
				}
				num = SubPOK;
				if (num == 0f && activeUnit_0.GetCurrentAltitude() == 0f)
				{
					num = SurfPOK;
				}
			}
			else
			{
				num = AirPOK;
			}
			if (ReferenceWeapon.Type == Weapon._WeaponType.Gun)
			{
				stringBuilder.Append("火炮 (" + UnitClass + "）正在攻击" + activeUnit_0.Name + "基础Ph为" + Conversions.ToString(Math.Round(num, 1)) + "%. ");
			}
			else
			{
				stringBuilder.Append("武器：" + Name + " 正在攻击" + activeUnit_0.Name + "基础Ph为" + Conversions.ToString(Math.Round(num, 1)) + "%. ");
			}
			float num9;
			if (ReferenceWeapon.Type != Weapon._WeaponType.Laser && ReferenceWeapon.Type != Weapon._WeaponType.Microwave && ReferenceWeapon.Type != Weapon._WeaponType.LaserDazzler)
			{
				double num6 = Module_Unit.RangeToPoint_Slant(this, _PageProxy);
				if (num6 > GetMaxRangeForThisTargetType(activeUnit_0) / 2.0)
				{
					double num7 = Math.Min(1.0, num6 / 2.0 / GetMaxRangeForThisTargetType(activeUnit_0));
					num -= (float)((double)(num / 2f) * num7);
				}
				stringBuilder.Append("基础Ph根据距离调整：" + Conversions.ToString(Math.Round(num, 1)) + "%. ");
				if (activeUnit_0.IsAircraft)
				{
					if (activeUnit_0.IsBeingDestroyed || activeUnit_0.IsDestroyed)
					{
						return true;
					}
					if (((Aircraft)activeUnit_0).Crew > 0 && ((Aircraft)activeUnit_0).Agility_Nominal > 0f)
					{
						float actualAgility = ((Aircraft)activeUnit_0).Kinematics.GetActualAgility(stringBuilder);
						string string_ = "";
						float num8 = Module_Unit.PrintTokenizer(this, activeUnit_0, bool_0: false, ref string_);
						if (num8 < 345f && num8 > 15f)
						{
							if ((num8 >= 15f && num8 <= 60f) || (num8 <= 345f && num8 >= 300f))
							{
								actualAgility = (float)((double)actualAgility * 0.7);
								stringBuilder.Append("灵敏度调整为向前倾斜冲击效果：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
							}
							else if ((num8 >= 60f && num8 <= 110f) || (num8 <= 300f && num8 >= 250f))
							{
								actualAgility = actualAgility;
								stringBuilder.Append("高挠度冲击（对敏捷性没有影响）。");
							}
							else if ((num8 >= 110f && num8 <= 165f) || (num8 <= 250f && num8 >= 195f))
							{
								actualAgility = (float)((double)actualAgility * 0.85);
								stringBuilder.Append("灵敏度调整后倾斜冲击效果：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
							}
							else
							{
								actualAgility = (float)((double)actualAgility * 0.5);
								stringBuilder.Append("灵敏度调整为尾部撞击效果：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
							}
						}
						else
						{
							actualAgility = (float)((double)actualAgility * 0.6);
							stringBuilder.Append("针对正面碰撞效果调整敏捷度：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
						}
						actualAgility = (float)Math.Round(actualAgility, 1);
						stringBuilder.Append("最终的敏捷修正： - " + Conversions.ToString((int)Math.Round(actualAgility * 10f)) + "%. ");
						num9 = num - actualAgility * 10f;
					}
					else
					{
						num9 = num;
					}
				}
				else
				{
					num9 = num;
				}
				if (activeUnit_0.IsAerospaceUnit && activeUnit_0.GetCurrentAltitude() > 0f && !Flags.CapableVsSeaskimmer)
				{
					double num10 = Math.Round(ReferenceWeapon.ManageReponse(activeUnit_0.GetCurrentAltitude()), 2);
					if (num10 > 0.0)
					{
						num9 = (float)((double)num9 - num10);
						stringBuilder.Append("撇水器修正： - " + Conversions.ToString(num10) + "%. ");
					}
				}
				if (activeUnit_0.IsMissile)
				{
					num9 = Weapon.ModifierVsTargetSpeed((int)Math.Round(num9), ReferenceWeapon, activeUnit_0, stringBuilder);
				}
				if (activeUnit_0.IsAerospaceUnit)
				{
					Sensor sensor_ = null;
					if (serviceProxy != 0)
					{
						sensor_ = scenario_0.Cache_GetSensor(serviceProxy);
					}
					string string_2 = "";
					float num11 = Module_Unit.PrintTokenizer(this, activeUnit_0, bool_0: false, ref string_2);
					XSection xSection = Sensor.smethod_0(activeUnit_0, XSection._SignatureType.Radar_E_M);
					XSection xSection2 = Sensor.smethod_0(activeUnit_0, XSection._SignatureType.IR_Detect);
					xSection.isDBInvisible(activeUnit_0);
					xSection2.isDBInvisible(activeUnit_0);
					float float_ = 0f;
					float float_2 = 0f;
					if (num11 < 315f && num11 > 45f)
					{
						if ((num11 >= 45f && num11 <= 135f) || (num11 >= 225f && num11 <= 315f))
						{
							float_ = xSection.GetSide(activeUnit_0);
							float_2 = xSection2.GetSide(activeUnit_0);
						}
						else if (num11 >= 135f && num11 <= 225f)
						{
							float_ = xSection.GetRear(activeUnit_0);
							float_2 = xSection2.GetRear(activeUnit_0);
						}
					}
					else
					{
						float_ = xSection.GetFront(activeUnit_0);
						float_2 = xSection2.GetFront(activeUnit_0);
					}
					num9 = Weapon.ModifierVsTargetSignature((int)Math.Round(num9), FiringParent, ReferenceWeapon, activeUnit_0, sensor_, float_, float_2, stringBuilder);
				}
				if (activeUnit_0.IsMissile && Module_Unit.RangeToPoint_Horiz(this, _PageProxy) <= 2f)
				{
					Weapon weapon = (Weapon)activeUnit_0;
					if (weapon.AI.PrimaryTarget != null && Module_Unit.RangeToUnit_Horiz(weapon, weapon.AI.PrimaryTarget) < 2f)
					{
						if (weapon.Flags.TerminalManeuver_PopUp)
						{
							stringBuilder.Append("目标是具有弹出终端操纵杆的导弹 - 命中概率降低25％。");
							num9 = (float)((double)num9 * 0.75);
						}
						else if (weapon.Flags.TerminalManeuver_ZigZag)
						{
							stringBuilder.Append("目标是具有之字形终端的导弹 - 命中率降低了33％。");
							num9 = (float)((double)num9 * 0.66);
						}
						else if (weapon.Flags.TerminalManeuver_Random)
						{
							stringBuilder.Append("目标是具有随机终端管理的导弹 - 命中概率降低50％。");
							num9 = (float)((double)num9 * 0.5);
						}
					}
				}
			}
			else
			{
				num9 = num;
			}
			if (Flags.Fuze_Proximity && activeUnit_0.IsAerospaceUnit)
			{
				Warhead.WarheadCaliber? warheadCaliber = Warheads.FirstOrDefault()?.Caliber;
				short? num12 = (short?)warheadCaliber;
				bool? flag9;
				bool? flag10 = (flag9 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2001) : null));
				bool? flag11;
				bool? flag12;
				if (flag10.HasValue && flag9.GetValueOrDefault())
				{
					flag11 = true;
				}
				else
				{
					num12 = (short?)warheadCaliber;
					flag10 = (flag12 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2002) : null));
					flag11 = ((!flag10.HasValue) ? null : (flag12.GetValueOrDefault() | flag9));
				}
				bool? flag13 = flag11;
				flag12 = flag11;
				bool? flag14;
				bool? flag15;
				if (flag12.HasValue && flag13.GetValueOrDefault())
				{
					flag14 = true;
				}
				else
				{
					num12 = (short?)warheadCaliber;
					flag12 = (flag15 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3001) : null));
					flag14 = ((!flag12.HasValue) ? null : (flag15.GetValueOrDefault() | flag13));
				}
				bool? flag16 = flag14;
				flag15 = flag14;
				bool? flag2;
				bool? flag3;
				if (flag15.HasValue && flag16.GetValueOrDefault())
				{
					flag2 = true;
				}
				else
				{
					num12 = (short?)warheadCaliber;
					flag15 = (flag3 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3002) : null));
					flag2 = ((!flag15.HasValue) ? null : (flag3.GetValueOrDefault() | flag16));
				}
				flag3 = flag2;
				float num13;
				if (flag3.GetValueOrDefault())
				{
					num13 = 1.5f;
				}
				else
				{
					num12 = (short?)warheadCaliber;
					flag15 = (flag3 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2003) : null));
					bool? flag4;
					if (flag15.HasValue && flag3.GetValueOrDefault())
					{
						flag4 = true;
					}
					else
					{
						num12 = (short?)warheadCaliber;
						flag15 = (flag16 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3003) : null));
						flag4 = ((!flag15.HasValue) ? null : (flag16.GetValueOrDefault() | flag3));
					}
					flag16 = flag4;
					if (flag16.GetValueOrDefault())
					{
						num13 = 2f;
					}
					else
					{
						num12 = (short?)warheadCaliber;
						flag15 = (flag16 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2004) : null));
						bool? flag5;
						if (flag15.HasValue && flag16.GetValueOrDefault())
						{
							flag5 = true;
						}
						else
						{
							num12 = (short?)warheadCaliber;
							flag15 = (flag3 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3004) : null));
							flag5 = ((!flag15.HasValue) ? null : (flag3.GetValueOrDefault() | flag16));
						}
						flag3 = flag5;
						if (flag3.GetValueOrDefault())
						{
							num13 = 3.5f;
						}
						else
						{
							num12 = (short?)warheadCaliber;
							flag15 = (flag3 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2005) : null));
							bool? flag6;
							if (flag15.HasValue && flag3.GetValueOrDefault())
							{
								flag6 = true;
							}
							else
							{
								num12 = (short?)warheadCaliber;
								flag15 = (flag16 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3005) : null));
								flag6 = ((!flag15.HasValue) ? null : (flag16.GetValueOrDefault() | flag3));
							}
							flag16 = flag6;
							if (flag16.GetValueOrDefault())
							{
								num13 = 4f;
							}
							else
							{
								num12 = (short?)warheadCaliber;
								flag15 = (flag16 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2006) : null));
								bool? flag7;
								if (flag15.HasValue && flag16.GetValueOrDefault())
								{
									flag7 = true;
								}
								else
								{
									num12 = (short?)warheadCaliber;
									flag15 = (flag3 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3006) : null));
									flag7 = ((!flag15.HasValue) ? null : (flag3.GetValueOrDefault() | flag16));
								}
								flag3 = flag7;
								if (flag3.GetValueOrDefault())
								{
									num13 = 4.5f;
								}
								else
								{
									num12 = (short?)warheadCaliber;
									flag15 = (flag3 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2007) : null));
									bool? flag8;
									if (flag15.HasValue && flag3.GetValueOrDefault())
									{
										flag8 = true;
									}
									else
									{
										num12 = (short?)warheadCaliber;
										flag15 = (flag16 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3007) : null));
										flag8 = ((!flag15.HasValue) ? null : (flag16.GetValueOrDefault() | flag3));
									}
									flag16 = flag8;
									num13 = (flag16.GetValueOrDefault() ? 5f : 6f);
								}
							}
						}
					}
				}
				num9 *= num13;
				string[] array = new string[5] { "Proximity fuze (", null, null, null, null };
				Warhead warhead = Warheads.FirstOrDefault();
				array[1] = ((warhead == null) ? null : Misc.RestartRequest(warhead.Caliber));
				array[2] = ") - Ph increased by ";
				array[3] = Conversions.ToString(num13);
				array[4] = "x. ";
				stringBuilder.Append(string.Concat(array));
				float num2 = Physics.CompareStub(activeUnit_0.GetCurrentAltitude(), activeUnit_0.CurrentSpeed);
				if (num2 < 1f)
				{
					stringBuilder.Append("Target is subsonic - no alteration to effective flak hit probability.");
				}
				else
				{
					num9 /= num2;
					stringBuilder.Append("Target is at Mach " + Conversions.ToString(Math.Round(num2, 2)) + "; effective flak hit probability reduced by same factor. ");
				}
			}
			if (num9 < 0f)
			{
				num9 = 1f;
			}
			if (num9 > 99f)
			{
				num9 = 99f;
			}
			if (!float.IsNaN(num9))
			{
				stringBuilder.Append("最终Ph：" + Conversions.ToString((int)Math.Round(num9)) + "%. ");
			}
			float num3 = 0f;
			float num4 = 0f;
			int num5 = GameGeneral.LockRandom_0.Next(1, 101);
			if ((float)num5 <= num9)
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num5) + " - 命中");
				flag = true;
			}
			else
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num5) + " - 未命中");
				if (Warheads.Length != 0 && activeUnit_0.IsFacility && Warheads[0].IsExplosive)
				{
					num3 = GameGeneral.LockRandom_0.Next(0, 359);
					num4 = GameGeneral.LockRandom_0.Next(1, 50);
					stringBuilder.Append("（接近命中：" + Conversions.ToString(num4) + "m)");
					if (!string.IsNullOrEmpty(FiringParent_ID) && FiringParent == null)
					{
						ObservableDictionary<string, ActiveUnit> activeUnits = ReferenceWeapon.ParentScen.ActiveUnits;
						string firingParent_ID = FiringParent_ID;
						ActiveUnit firingParent = FiringParent;
						activeUnits.TryGetValue(firingParent_ID, ref firingParent);
						FiringParent = firingParent;
					}
					ActiveUnit_Damage damage = activeUnit_0.Damage;
					Weapon referenceWeapon = ReferenceWeapon;
					GeoPoint pageProxy = _PageProxy;
					float float_3 = num4;
					float float_4 = num3;
					ActiveUnit firingParent2 = FiringParent;
					string string_3 = "";
					damage.ResolveDamageFromWeapon(referenceWeapon, pageProxy, float_3, float_4, firingParent2, null, null, null, ref string_3, bool_0: false);
				}
			}
			string empty = string.Empty;
			empty = (flag ? (Name + " 命中" + activeUnit_0.Name) : (Name + "错过" + activeUnit_0.Name));
			activeUnit_0.ParentScen.AddMessage(stringBuilder.ToString(), empty, LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			if (flag)
			{
				ActiveUnit firingParent3;
				if (!string.IsNullOrEmpty(FiringParent_ID) && FiringParent == null)
				{
					ObservableDictionary<string, ActiveUnit> activeUnits2 = ReferenceWeapon.ParentScen.ActiveUnits;
					string firingParent_ID2 = FiringParent_ID;
					firingParent3 = FiringParent;
					activeUnits2.TryGetValue(firingParent_ID2, ref firingParent3);
					FiringParent = firingParent3;
				}
				float float_5 = num4;
				float float_6 = num3;
				firingParent3 = FiringParent;
				string string_4 = "";
				ListWatcher(activeUnit_0, float_5, float_6, ref firingParent3, null, null, null, ref string_4);
				FiringParent = firingParent3;
			}
			PostWatcher(activeUnit_0, flag, activeUnit_0.IsDestroyed, stringBuilder, scenario_0);
			return flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100860", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static double CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType contactType_0, float float_0, bool bool_0)
	{
		double num = Math.Sqrt((double)(float_0 * 1852f) * 9.81 / Math.Sin(1.570796326794897));
		if (!bool_0)
		{
			num *= 3.0;
		}
		if (!Information.IsNothing(contactType_0) && (int)contactType_0 <= 1)
		{
			num = Math.Max(990.0, num);
		}
		return num;
	}

	[SpecialName]
	public double GetMaxRangeForThisTargetType(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.IsAerospaceUnit)
		{
			return MaxAirRange;
		}
		if (!activeUnit_0.IsShip && !activeUnit_0.IsFacility)
		{
			if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsTorpedo)
			{
				throw new NotImplementedException();
			}
			return MaxSubsurfaceRange;
		}
		return MaxSurfaceRange;
	}

	internal int CancelWatcher()
	{
		return fieldProxy;
	}

	internal bool VerifyWatcher(ActiveUnit activeUnit_0, Contact contact_0, ref Scenario scenario_0, ref LockRandom lockRandom_0, string string_0 = "")
	{
		try
		{
			string_0 = "Weapon " + Name + " involved in CEP weapon impact resolution with " + activeUnit_0.Name;
			double num = 0.0;
			if (!activeUnit_0.IsShip && (!activeUnit_0.IsSubmarine || !((Submarine)activeUnit_0).IsSurfaced))
			{
				if (activeUnit_0.IsFacility | activeUnit_0.IsVehicle)
				{
					num = LandPOK;
				}
				else if ((activeUnit_0.IsSubmarine && !((Submarine)activeUnit_0).IsSurfaced) || activeUnit_0.IsTorpedo)
				{
					num = SubPOK;
				}
			}
			else
			{
				num = SurfPOK;
			}
			if (Type == Weapon._WeaponType.DepthCharge || (Warheads[0].Type == Warhead.WarheadType.Weapon && Warheads[0].GetCarriedWeapon(scenario_0).Type == Weapon._WeaponType.DepthCharge))
			{
				if (CEP_Surface == 0f)
				{
					num = 99.0;
					CEP_Surface = 200f;
				}
				if (num < 85.0)
				{
					num = 85.0;
				}
			}
			bool flag = (double)lockRandom_0.Next(1, 101) < num;
			string text = "";
			float num12 = (activeUnit_0.IsFacility ? CEP_Land : CEP_Surface);
			if (activeUnit_0.CurrentSpeed > 0f && contact_0.Age > 0f)
			{
				if (activeUnit_0.IsFacility)
				{
					_ = activeUnit_0.CurrentSpeed;
				}
				else
				{
					_ = activeUnit_0.CurrentSpeed;
				}
			}
			float float_ = lockRandom_0.Next(0, 360);
			double num21 = lockRandom_0.NextDouble();
			float num22 = ((num21 <= 0.5) ? ((float)((double)lockRandom_0.Next(0, 101) / 100.0 * (double)num12)) : ((num21 < 0.937) ? ((float)((double)num12 + (double)num12 * lockRandom_0.NextDouble())) : ((float)((double)(2f * num12) + (double)num12 * lockRandom_0.NextDouble()))));
			Mount mount = null;
			double double_ = 0.0;
			double double_12 = 0.0;
			if (Module_ActiveUnit.CancelTokenizer((Facility)activeUnit_0))
			{
				mount = ((Facility)activeUnit_0).PickRandomAimpoint();
				if (mount == null)
				{
					double_ = contact_0.GetLatitude();
					double_12 = contact_0.GetLongitude();
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_12, ref double_, mount.AimpointOffset_Distance / 1852f, mount.AimpointOffset_Bearing);
				}
			}
			else
			{
				double_ = contact_0.GetLatitude();
				double_12 = contact_0.GetLongitude();
			}
			WeaponSalvo Local_ParentWS = GetParentSalvo(scenario_0);
			WeaponSalvo.Shooter parentSalvoShooter = GetParentSalvoShooter(scenario_0);
			string string_ = ((parentSalvoShooter == null) ? string.Empty : parentSalvoShooter.BombStickAimpointObjectID);
			if (Local_ParentWS != null && parentSalvoShooter != null && (Type == Weapon._WeaponType.IronBomb || Type == Weapon._WeaponType.Rocket))
			{
				if (!parentSalvoShooter.BombStickTotalQty.HasValue)
				{
					parentSalvoShooter.BombStickTotalQty = scenario_0.UnguidedWeapons.Values.Where((UnguidedWeapon theUW) => Operators.CompareString(theUW.FiringParent_ID, FiringParent_ID, TextCompare: false) == 0 && Local_ParentWS.WeaponList.Contains(theUW.ObjectID)).Count();
					if (!parentSalvoShooter.BombStickTotalQty.HasValue)
					{
						parentSalvoShooter.BombStickTotalQty = 1;
					}
				}
				int? bombStickTotalQty = parentSalvoShooter.BombStickTotalQty;
				if ((bombStickTotalQty.HasValue ? new bool?(bombStickTotalQty.GetValueOrDefault() < 2) : null).GetValueOrDefault())
				{
					double double_22 = double_12;
					double double_23 = double_;
					bool? nullable_ = null;
					double double_24 = GetLongitude(nullable_);
					bool? nullable_5 = null;
					double double_25 = GetLatitude(nullable_5);
					Geodesic_EdWilliams.CalcPoint_Williams(double_22, double_23, ref double_24, ref double_25, num22 / 1852f, float_);
					SetLatitude(nullable_5, double_25);
					SetLongitude(nullable_, double_24);
				}
				else
				{
					if (!parentSalvoShooter.BombStickIndexOfCenterShot.HasValue)
					{
						parentSalvoShooter.BombStickIndexOfCenterShot = RadarModel.PrintStub((double)parentSalvoShooter.BombStickTotalQty.Value / 2.0);
					}
					if (!parentSalvoShooter.BombStickDirection.HasValue)
					{
						parentSalvoShooter.BombStickDirection = CurrentHeading;
					}
					if (!parentSalvoShooter.BombStickLength.HasValue)
					{
						Weapon._WeaponType type3 = Type;
						Weapon._WeaponType weaponType = type3;
						if (!string.IsNullOrEmpty(FiringParent_ID) && FiringParent == null)
						{
							ObservableDictionary<string, ActiveUnit> activeUnits = scenario_0.ActiveUnits;
							string firingParent_ID = FiringParent_ID;
							ActiveUnit firingParent = FiringParent;
							activeUnits.TryGetValue(firingParent_ID, ref firingParent);
							FiringParent = firingParent;
						}
						if (FiringParent != null && FiringParent.IsAircraft)
						{
							Aircraft._AircraftType type = ((Aircraft)FiringParent).Type;
							Weapon._WeaponType type2 = Type;
							float num23 = ((type2 != Weapon._WeaponType.IronBomb && type2 != Weapon._WeaponType.DepthCharge) ? 9.144f : ((type == Aircraft._AircraftType.Bomber) ? 22.86f : 15.24f));
							if (Type != Weapon._WeaponType.IronBomb && Type != Weapon._WeaponType.DepthCharge)
							{
								if (parentSalvoShooter.BombStickTotalQty.Value < 40)
								{
									parentSalvoShooter.BombStickLength = 30.48f;
								}
								else if (parentSalvoShooter.BombStickTotalQty.Value < 80)
								{
									parentSalvoShooter.BombStickLength = 60.96f;
								}
								else
								{
									parentSalvoShooter.BombStickLength = 91.44f;
								}
							}
							else if (type == Aircraft._AircraftType.Bomber)
							{
								if (parentSalvoShooter.BombStickTotalQty.Value < 28)
								{
									parentSalvoShooter.BombStickLength = (float)parentSalvoShooter.BombStickTotalQty.Value * num23;
								}
								else
								{
									parentSalvoShooter.BombStickLength = 609.60004f;
								}
							}
							else if (parentSalvoShooter.BombStickTotalQty.Value < 8)
							{
								parentSalvoShooter.BombStickLength = (float)parentSalvoShooter.BombStickTotalQty.Value * num23;
							}
							else if (parentSalvoShooter.BombStickTotalQty.Value < 25)
							{
								parentSalvoShooter.BombStickLength = 91.44f;
							}
							else
							{
								parentSalvoShooter.BombStickLength = 182.88f;
							}
						}
						else
						{
							parentSalvoShooter.BombStickLength = 91.44f;
						}
					}
					if (parentSalvoShooter.BombStickFirstWeaponDPI == null)
					{
						parentSalvoShooter.BombStickFirstWeaponDPI = new GeoPoint();
						parentSalvoShooter.BombStickFirstWeaponDPI.Latitude = double_;
						parentSalvoShooter.BombStickFirstWeaponDPI.Longitude = double_12;
					}
					if (parentSalvoShooter.BombStickFirstWeaponActualPI == null)
					{
						parentSalvoShooter.BombStickFirstWeaponActualPI = new GeoPoint();
						double longitude = parentSalvoShooter.BombStickFirstWeaponDPI.Longitude;
						double latitude = parentSalvoShooter.BombStickFirstWeaponDPI.Latitude;
						GeoPoint bombStickFirstWeaponActualPI = parentSalvoShooter.BombStickFirstWeaponActualPI;
						double double_26 = bombStickFirstWeaponActualPI.Longitude;
						GeoPoint bombStickFirstWeaponActualPI2 = parentSalvoShooter.BombStickFirstWeaponActualPI;
						double double_27 = bombStickFirstWeaponActualPI2.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_26, ref double_27, num22 / 1852f, float_);
						bombStickFirstWeaponActualPI2.Latitude = double_27;
						bombStickFirstWeaponActualPI.Longitude = double_26;
					}
					if (Type != Weapon._WeaponType.IronBomb && Type != Weapon._WeaponType.DepthCharge)
					{
						int num24 = parentSalvoShooter.BombStickTotalQty.Value - parentSalvoShooter.BombStickImpactedQty;
						parentSalvoShooter.BombStickImpactedQty++;
						bombStickTotalQty = parentSalvoShooter.BombStickIndexOfCenterShot;
						if ((bombStickTotalQty.HasValue ? new bool?(bombStickTotalQty.GetValueOrDefault() == num24) : null).GetValueOrDefault())
						{
							double_ = parentSalvoShooter.BombStickFirstWeaponActualPI.Latitude;
							double_12 = parentSalvoShooter.BombStickFirstWeaponActualPI.Longitude;
						}
						else
						{
							int num25 = num24;
							bombStickTotalQty = parentSalvoShooter.BombStickIndexOfCenterShot;
							if ((bombStickTotalQty.HasValue ? new bool?(num25 > bombStickTotalQty.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								int num26 = num24 - parentSalvoShooter.BombStickIndexOfCenterShot.Value;
								float num27 = (parentSalvoShooter.BombStickLength / 2f / (float?)parentSalvoShooter.BombStickIndexOfCenterShot).Value;
								if (float.IsInfinity(num27) || float.IsNaN(num27))
								{
									num27 = 0f;
								}
								float num2 = (float)num26 * num27;
								Geodesic_EdWilliams.CalcPoint_Williams(parentSalvoShooter.BombStickFirstWeaponActualPI.Longitude, parentSalvoShooter.BombStickFirstWeaponActualPI.Latitude, ref double_12, ref double_, num2 / 1852f, Math2.UpdateClass(parentSalvoShooter.BombStickDirection.Value + 180f));
							}
							else
							{
								int num3 = parentSalvoShooter.BombStickTotalQty.Value - (num24 + parentSalvoShooter.BombStickIndexOfCenterShot.Value);
								float num4 = (parentSalvoShooter.BombStickLength / 2f / (float?)(parentSalvoShooter.BombStickTotalQty.Value - 1 - parentSalvoShooter.BombStickIndexOfCenterShot)).Value;
								if (float.IsInfinity(num4) || float.IsNaN(num4))
								{
									num4 = 0f;
								}
								float num5 = (float)num3 * num4;
								Geodesic_EdWilliams.CalcPoint_Williams(parentSalvoShooter.BombStickFirstWeaponActualPI.Longitude, parentSalvoShooter.BombStickFirstWeaponActualPI.Latitude, ref double_12, ref double_, num5 / 1852f, Math2.UpdateClass(parentSalvoShooter.BombStickDirection.Value));
							}
						}
						if (lockRandom_0.Next(1, 4) <= 1)
						{
							float num6 = lockRandom_0.Next(7, 16);
							double double_28 = double_12;
							double double_2 = double_;
							bool? nullable_6 = null;
							double double_3 = GetLongitude(nullable_6);
							bool? nullable_7 = null;
							double double_4 = GetLatitude(nullable_7);
							Geodesic_EdWilliams.CalcPoint_Williams(double_28, double_2, ref double_3, ref double_4, num6 / 1852f, float_);
							SetLatitude(nullable_7, double_4);
							SetLongitude(nullable_6, double_3);
						}
						else
						{
							float num7 = lockRandom_0.Next(0, 8);
							double double_5 = double_12;
							double double_6 = double_;
							bool? nullable_8 = null;
							double double_7 = GetLongitude(nullable_8);
							bool? nullable_9 = null;
							double double_8 = GetLatitude(nullable_9);
							Geodesic_EdWilliams.CalcPoint_Williams(double_5, double_6, ref double_7, ref double_8, num7 / 1852f, float_);
							SetLatitude(nullable_9, double_8);
							SetLongitude(nullable_8, double_7);
						}
						num22 = parentSalvoShooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(GetLongitude(), GetLatitude()) * 1852f;
					}
					else
					{
						int num8 = parentSalvoShooter.BombStickTotalQty.Value - parentSalvoShooter.BombStickImpactedQty;
						parentSalvoShooter.BombStickImpactedQty++;
						bombStickTotalQty = parentSalvoShooter.BombStickIndexOfCenterShot;
						if ((bombStickTotalQty.HasValue ? new bool?(bombStickTotalQty.GetValueOrDefault() == num8) : null).GetValueOrDefault())
						{
							SetLatitude(null, parentSalvoShooter.BombStickFirstWeaponActualPI.Latitude);
							SetLongitude(null, parentSalvoShooter.BombStickFirstWeaponActualPI.Longitude);
							num22 = parentSalvoShooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(GetLongitude(), GetLatitude()) * 1852f;
						}
						else
						{
							int num9 = num8;
							bombStickTotalQty = parentSalvoShooter.BombStickIndexOfCenterShot;
							if ((bombStickTotalQty.HasValue ? new bool?(num9 > bombStickTotalQty.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								int num10 = num8 - parentSalvoShooter.BombStickIndexOfCenterShot.Value;
								float num11 = (parentSalvoShooter.BombStickLength / 2f / (float?)parentSalvoShooter.BombStickIndexOfCenterShot).Value;
								if (float.IsInfinity(num11) || float.IsNaN(num11))
								{
									num11 = 0f;
								}
								float num13 = (float)num10 * num11;
								Geodesic_EdWilliams.CalcPoint_Williams(parentSalvoShooter.BombStickFirstWeaponActualPI.Longitude, parentSalvoShooter.BombStickFirstWeaponActualPI.Latitude, ref double_12, ref double_, num13 / 1852f, Math2.UpdateClass(parentSalvoShooter.BombStickDirection.Value + 180f));
								float num14 = lockRandom_0.Next(0, (int)Math.Round(num11));
								double double_9 = double_12;
								double double_10 = double_;
								bool? nullable_10 = null;
								double double_11 = GetLongitude(nullable_10);
								bool? nullable_11 = null;
								double double_13 = GetLatitude(nullable_11);
								Geodesic_EdWilliams.CalcPoint_Williams(double_9, double_10, ref double_11, ref double_13, num14 / 1852f, float_);
								SetLatitude(nullable_11, double_13);
								SetLongitude(nullable_10, double_11);
								num22 = parentSalvoShooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(GetLongitude(), GetLatitude()) * 1852f;
							}
							else
							{
								int num15 = parentSalvoShooter.BombStickTotalQty.Value - (num8 + parentSalvoShooter.BombStickIndexOfCenterShot.Value);
								float num16 = (parentSalvoShooter.BombStickLength / 2f / (float?)(parentSalvoShooter.BombStickTotalQty.Value - 1 - parentSalvoShooter.BombStickIndexOfCenterShot)).Value;
								if (float.IsInfinity(num16) || float.IsNaN(num16))
								{
									num16 = 0f;
								}
								float num17 = (float)num15 * num16;
								Geodesic_EdWilliams.CalcPoint_Williams(parentSalvoShooter.BombStickFirstWeaponActualPI.Longitude, parentSalvoShooter.BombStickFirstWeaponActualPI.Latitude, ref double_12, ref double_, num17 / 1852f, Math2.UpdateClass(parentSalvoShooter.BombStickDirection.Value));
								float num18 = lockRandom_0.Next(0, (int)Math.Round(num16));
								double double_14 = double_12;
								double double_15 = double_;
								bool? nullable_12 = null;
								double double_16 = GetLongitude(nullable_12);
								bool? nullable_2 = null;
								double double_17 = GetLatitude(nullable_2);
								Geodesic_EdWilliams.CalcPoint_Williams(double_14, double_15, ref double_16, ref double_17, num18 / 1852f, float_);
								SetLatitude(nullable_2, double_17);
								SetLongitude(nullable_12, double_16);
								num22 = parentSalvoShooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(GetLongitude(), GetLatitude()) * 1852f;
							}
						}
					}
				}
			}
			else if (num12 <= 0f)
			{
				SetLatitude(null, double_);
				SetLongitude(null, double_12);
			}
			else
			{
				double double_18 = double_12;
				double double_19 = double_;
				bool? nullable_3 = null;
				double double_20 = GetLongitude(nullable_3);
				bool? nullable_4 = null;
				double double_21 = GetLatitude(nullable_4);
				Geodesic_EdWilliams.CalcPoint_Williams(double_18, double_19, ref double_20, ref double_21, num22 / 1852f, float_);
				SetLatitude(nullable_4, double_21);
				SetLongitude(nullable_3, double_20);
			}
			ClearElevationAndAltitudeAGL();
			if (!IsTorpedo)
			{
				if (Type != Weapon._WeaponType.DepthCharge && (Warheads[0].Type != Warhead.WarheadType.Weapon || Warheads[0].GetCarriedWeapon(scenario_0).Type != Weapon._WeaponType.DepthCharge))
				{
					SetCurrentAltitude(bool_0: false, Math.Max(0, (int)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, scenario_0)));
				}
				else
				{
					SetCurrentAltitude(bool_0: false, (float)Math.Max(-100.0, (double)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, scenario_0) / 2.0));
				}
			}
			ImpactAltitude = GetCurrentAltitude();
			float num19 = (float)((double)Math2.VerifyClass(GetLatitude(), GetLongitude(), activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude()) * 1852.0);
			if (mount != null && mount.AimpointOffset_Distance > 0f)
			{
				num19 = Math.Abs(num19 - mount.AimpointOffset_Distance);
			}
			float float_2 = Module_Unit.BearingToPoint_True(activeUnit_0, GetLatitude(), GetLongitude());
			bool flag2;
			if (flag2 = Weapon.CheckForDirectHit(activeUnit_0, GetLatitude(), GetLongitude(), num19, _PageProxy, ReferenceWeapon.MaxRange_NoTargetType, bool_0: true))
			{
				Weapon.RaiseEvent_WeaponImpact(scenario_0, ReferenceWeapon, contact_0, bool_0: false);
				num19 = 0f;
			}
			if (Warheads.Length != 0 && Warheads[0].IsCluster)
			{
				if (flag)
				{
					Warhead[] warheads = Warheads;
					Warhead[] array = warheads;
					foreach (Warhead warhead in array)
					{
						if (warhead.IsCluster)
						{
							new Explosion(ref scenario_0, GetLongitude(), GetLatitude(), GetLongitude(), GetLatitude(), CurrentHeading, GetCurrentAltitude(), Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads).CurrentHeading = CurrentHeading;
						}
					}
				}
				else
				{
					scenario_0.AddMessage("武器：" + Name + "发生故障。", Name + " 故障", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
				flag2 = true;
			}
			if (!Warheads[0].IsExplosive && (Warheads[0].Type != Warhead.WarheadType.Weapon || !Warheads[0].GetCarriedWeapon(scenario_0).Warheads[0].IsExplosive) && !Warheads[0].IsIncendiary && (Warheads[0].Type != Warhead.WarheadType.Weapon || !Warheads[0].GetCarriedWeapon(scenario_0).Warheads[0].IsIncendiary))
			{
				if (flag2)
				{
					ActiveUnit firingParent2;
					if (!string.IsNullOrEmpty(FiringParent_ID) && Information.IsNothing(FiringParent))
					{
						ObservableDictionary<string, ActiveUnit> activeUnits2 = scenario_0.ActiveUnits;
						string firingParent_ID2 = FiringParent_ID;
						firingParent2 = FiringParent;
						activeUnits2.TryGetValue(firingParent_ID2, ref firingParent2);
						FiringParent = firingParent2;
					}
					float float_3 = num19;
					firingParent2 = FiringParent;
					ListWatcher(activeUnit_0, float_3, float_2, ref firingParent2, null, null, null, ref string_);
					FiringParent = firingParent2;
					if (!Information.IsNothing(parentSalvoShooter) && !Information.IsNothing(parentSalvoShooter.BombStickTotalQty) && !Information.IsNothing(parentSalvoShooter.BombStickImpactedQty) && !string.IsNullOrEmpty(string_) && !Information.IsNothing(parentSalvoShooter))
					{
						parentSalvoShooter.BombStickAimpointObjectID = string_;
					}
				}
				else if (num19 < 926f)
				{
					text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num19 * 3.28084f))) + "ft") : ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num19))) + "m"));
					scenario_0.AddMessage(text, Name + " 未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
				else
				{
					text = "武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Round(num19 / 1852f, 1)) + "nm";
					scenario_0.AddMessage(text, Name + " 未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
			}
			else if (flag)
			{
				Weapon.RaiseEvent_WeaponImpact(scenario_0, ReferenceWeapon, contact_0, bool_0: false);
				if (flag2)
				{
					ActiveUnit firingParent3;
					if (!string.IsNullOrEmpty(FiringParent_ID) && Information.IsNothing(FiringParent))
					{
						ObservableDictionary<string, ActiveUnit> activeUnits3 = scenario_0.ActiveUnits;
						string firingParent_ID3 = FiringParent_ID;
						firingParent3 = FiringParent;
						activeUnits3.TryGetValue(firingParent_ID3, ref firingParent3);
						FiringParent = firingParent3;
					}
					float float_4 = num19;
					firingParent3 = FiringParent;
					ListWatcher(activeUnit_0, float_4, float_2, ref firingParent3, GetLatitude(), GetLongitude(), null, ref string_);
					FiringParent = firingParent3;
				}
				else
				{
					if (!Module_ActiveUnit.CancelTokenizer(activeUnit_0))
					{
						if (Warheads[0].GetIsAirburst(ReferenceWeapon, activeUnit_0))
						{
							double num20 = Math.Sqrt(Math.Pow(Math.Abs(GetCurrentAltitude() - activeUnit_0.GetCurrentAltitude()), 2.0) + Math.Pow(num19, 2.0));
							string text2 = "空中爆炸";
							if (IsUnderwater || IsUnderground || CurrentAltitude_AGL == 0f)
							{
								text2 = "错过";
							}
							text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + text2 + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num20 * 3.2808399200439453))) + "ft") : ("武器：" + Name + text2 + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num20))) + "m"));
							scenario_0.AddMessage(text, Name + " 未命中/空中爆炸", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						}
						else if ((double)num19 < 926.0)
						{
							text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num19 * 3.28084f))) + "ft") : ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num19))) + "m"));
							scenario_0.AddMessage(text, Name + " 未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						}
						else
						{
							text = "武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Round(num19 / 1852f, 1)) + "nm";
							scenario_0.AddMessage(text, Name + " 未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						}
					}
					if ((GetCurrentAltitude() >= 0f && (Module_Unit.ResetTokenizer(this) || Type == Weapon._WeaponType.IronBomb || Type == Weapon._WeaponType.GuidedWeapon || Type == Weapon._WeaponType.Gun || Type == Weapon._WeaponType.Rocket)) || Warheads[0].GetIsNuclear(scenario_0) || IsTorpedo || Type == Weapon._WeaponType.DepthCharge || (Warheads[0].Type == Warhead.WarheadType.Weapon && Warheads[0].GetCarriedWeapon(scenario_0).Type == Weapon._WeaponType.DepthCharge) || (Warheads[0].GetIsAirburst(ReferenceWeapon, activeUnit_0) ? true : false))
					{
						if (!string.IsNullOrEmpty(FiringParent_ID) && Information.IsNothing(FiringParent))
						{
							ObservableDictionary<string, ActiveUnit> activeUnits4 = scenario_0.ActiveUnits;
							string firingParent_ID4 = FiringParent_ID;
							ActiveUnit firingParent4 = FiringParent;
							activeUnits4.TryGetValue(firingParent_ID4, ref firingParent4);
							FiringParent = firingParent4;
						}
						if (Type == Weapon._WeaponType.DepthCharge)
						{
							activeUnit_0.Damage.ResolveDamageFromWeapon(ReferenceWeapon, _PageProxy, num19, float_2, FiringParent, GetLatitude(), GetLongitude(), activeUnit_0.GetCurrentAltitude(), ref string_, flag2);
						}
						else
						{
							activeUnit_0.Damage.ResolveDamageFromWeapon(ReferenceWeapon, _PageProxy, num19, float_2, FiringParent, GetLatitude(), GetLongitude(), GetCurrentAltitude(), ref string_, flag2);
						}
					}
				}
				if (!Information.IsNothing(parentSalvoShooter) && !Information.IsNothing(parentSalvoShooter.BombStickTotalQty) && !Information.IsNothing(parentSalvoShooter.BombStickImpactedQty) && !string.IsNullOrEmpty(string_) && !Information.IsNothing(parentSalvoShooter))
				{
					parentSalvoShooter.BombStickAimpointObjectID = string_;
				}
			}
			else
			{
				scenario_0.AddMessage("武器：" + Name + "发生故障。", Name + " 故障", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			return flag2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100862", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void ListWatcher(ActiveUnit activeUnit_0, float float_0, float float_1, ref ActiveUnit activeUnit_1, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0)
	{
		try
		{
			if (!ReferenceWeapon.IsDecoy)
			{
				Weapon.RaiseEvent_WeaponImpact(ReferenceWeapon.ParentScen, ReferenceWeapon, activeUnit_0, bool_0: true);
				new WeaponImpact(ref activeUnit_0.ParentScen, activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), activeUnit_0.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, fieldProxy);
			}
			if (!activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				if (activeUnit_0.IsFacility)
				{
					if (!((Facility)activeUnit_0).HasAimpoints)
					{
						activeUnit_0.ParentScen.AddMessage("武器：" + UnitClass + "毁伤了" + activeUnit_0.Name, UnitClass + " 命中", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
				}
				else
				{
					activeUnit_0.ParentScen.AddMessage("武器：" + UnitClass + "毁伤了" + activeUnit_0.Name, UnitClass + " 命中", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
			}
			if (!string.IsNullOrEmpty(FiringParent_ID) && activeUnit_1 == null)
			{
				ReferenceWeapon.ParentScen.ActiveUnits.TryGetValue(FiringParent_ID, ref activeUnit_1);
			}
			ReferenceWeapon.FiringParent = FiringParent;
			activeUnit_0.Damage.ResolveDamageFromWeapon(ReferenceWeapon, _PageProxy, float_0, float_1, activeUnit_1, nullable_0, nullable_1, nullable_2, ref string_0, bool_0: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100863", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ResolveWatcher()
	{
		double? num = ActiveUnit_Navigator.CalculateInterceptHeading(GetLatitude(), GetLongitude(), CurrentHeading, Target, CurrentSpeed);
		if (!num.HasValue)
		{
			(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(this, CurrentSpeed, Target);
			if (!Information.IsNothing(tuple))
			{
				num = Module_Unit.BearingToPoint_True(this, tuple.Item1.Latitude, tuple.Item1.Longitude);
			}
		}
		if (num.HasValue)
		{
			CurrentHeading = (float)num.Value;
		}
		else
		{
			CurrentHeading = Math2.PublishClass(GetLatitude(), GetLongitude(), Target.GetLatitude(), Target.GetLongitude());
		}
	}

	private void PostWatcher(ActiveUnit activeUnit_0, bool bool_0, bool bool_1, StringBuilder stringBuilder_0, Scenario scenario_0)
	{
		try
		{
			foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
			{
				if (!applicableEventExporter.IsOperating || !applicableEventExporter.ExportWeaponEndgame)
				{
					continue;
				}
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (scenario_0.MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(scenario_0.Title, typeof(string), 500));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(scenario_0.MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(scenario_0.TimelineID, typeof(string), 40));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.Subtract(scenario_0.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(ObjectID, typeof(string), 40));
				dictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(Name, typeof(string), 500));
				dictionary.Add("WeaponSide", new IEventExporter.EventNotificationParameter(GetUnitSide().Name, typeof(string), 500));
				if (Information.IsNothing(FiringParent))
				{
					dictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					dictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				else
				{
					dictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter(FiringParent.ObjectID, typeof(string), 40));
					dictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter(FiringParent.Name, typeof(string), 500));
				}
				dictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(activeUnit_0.ObjectID, typeof(string), 40));
				dictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(activeUnit_0.Name, typeof(string), 500));
				dictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(activeUnit_0.GetUnitSide().Name, typeof(string), 500));
				dictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(activeUnit_0.GetLongitude(), typeof(double)));
				dictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(activeUnit_0.GetLatitude(), typeof(double)));
				dictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(activeUnit_0.GetCurrentAltitude(), typeof(float)));
				dictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(activeUnit_0.CurrentAltitude_AGL, typeof(float)));
				dictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(!Information.IsNothing(FiringParent), Module_Unit.RangeToUnit_Horiz(this, FiringParent), "")), typeof(float)));
				if (bool_0)
				{
					if (bool_1)
					{
						dictionary.Add("Result", new IEventExporter.EventNotificationParameter("KILL", typeof(string), 10));
					}
					else
					{
						dictionary.Add("Result", new IEventExporter.EventNotificationParameter("HIT", typeof(string), 10));
					}
				}
				else
				{
					dictionary.Add("Result", new IEventExporter.EventNotificationParameter("MISS", typeof(string), 10));
				}
				if (Information.IsNothing(stringBuilder_0))
				{
					dictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter("-", typeof(string)));
				}
				else
				{
					dictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(stringBuilder_0.ToString(), typeof(string)));
				}
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponEndgame, dictionary, activeUnit_0.ParentScen);
			}
			ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
			ISimConnector[] array = activeSimConnectors;
			foreach (ISimConnector simConnector in array)
			{
				if (!simConnector.ExportWeaponImpactOrDetonation)
				{
					continue;
				}
				Dictionary<string, Tuple<Type, string>> dictionary2 = new Dictionary<string, Tuple<Type, string>>();
				dictionary2.Add("TimelineID", new Tuple<Type, string>(typeof(string), scenario_0.TimelineID));
				dictionary2.Add("Time", new Tuple<Type, string>(typeof(DateTime), scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3")));
				dictionary2.Add("Longitude", new Tuple<Type, string>(typeof(double), Conversions.ToString(GetLongitude())));
				dictionary2.Add("Latitude", new Tuple<Type, string>(typeof(double), Conversions.ToString(GetLatitude())));
				dictionary2.Add("Altitude", new Tuple<Type, string>(typeof(float), Conversions.ToString(activeUnit_0.GetCurrentAltitude())));
				dictionary2.Add("WeaponID", new Tuple<Type, string>(typeof(string), ObjectID));
				dictionary2.Add("WeaponDBID", new Tuple<Type, string>(typeof(string), Conversions.ToString(CancelWatcher())));
				dictionary2.Add("WeaponCourse", new Tuple<Type, string>(typeof(string), CurrentHeading.ToString()));
				dictionary2.Add("WeaponSpeed_Horiz", new Tuple<Type, string>(typeof(string), Module_Unit.CalcTokenizer(this).ToString()));
				dictionary2.Add("WeaponSpeed_Vert", new Tuple<Type, string>(typeof(string), Module_Unit.RateTokenizer(this, scenario_0).ToString()));
				if (!Information.IsNothing(FiringParent))
				{
					dictionary2.Add("FiringUnitID", new Tuple<Type, string>(typeof(string), FiringParent.ObjectID));
				}
				if (!Information.IsNothing(activeUnit_0))
				{
					dictionary2.Add("TargetID", new Tuple<Type, string>(typeof(string), activeUnit_0.ObjectID));
				}
				if (bool_0)
				{
					if (bool_1)
					{
						dictionary2.Add("Result", new Tuple<Type, string>(typeof(string), "KILL"));
					}
					else
					{
						dictionary2.Add("Result", new Tuple<Type, string>(typeof(string), "HIT"));
					}
				}
				else
				{
					dictionary2.Add("Result", new Tuple<Type, string>(typeof(string), "MISS"));
				}
				dictionary2.Add("EventType", new Tuple<Type, string>(typeof(string), "WeaponImpact"));
				simConnector.ExportInfo(ISimConnector.ExportedInfoType.WeaponImpactOrDetonation, dictionary2, scenario_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101329", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ExportLocationEvent(Scenario scenario_0, bool bool_0)
	{
		if (broadcasterProxy && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		try
		{
			foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
			{
				if (!applicableEventExporter.IsOperating || !applicableEventExporter.ExportUnitPositions)
				{
					continue;
				}
				broadcasterProxy = true;
				if (GetUnitSide() != null || !applicableEventExporter.Common.AssetRepository(scenario_0, this))
				{
					Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
					if (scenario_0.MonteCarloIteration > 0)
					{
						dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(scenario_0.Title, typeof(string), 500));
						dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(scenario_0.MonteCarloIteration, typeof(int)));
					}
					dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(scenario_0.TimelineID, typeof(string), 40));
					if (applicableEventExporter.UseZeroHour)
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.Subtract(scenario_0.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
					}
					else
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3"), typeof(DateTime)));
					}
					dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(ObjectID, typeof(string), 40));
					dictionary.Add("UnitDBID", new IEventExporter.EventNotificationParameter(fieldProxy, typeof(string), 10));
					dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(Name, typeof(string), 500));
					dictionary.Add("UnitType", new IEventExporter.EventNotificationParameter(ReferenceWeapon.UnitType_String, typeof(string), 20));
					dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(UnitClass, typeof(string), 500));
					dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(GetUnitSide().Name, typeof(string), 500));
					dictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(GetLongitude(), typeof(double)));
					dictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(GetLatitude(), typeof(double)));
					dictionary.Add("UnitCourse", new IEventExporter.EventNotificationParameter(CurrentHeading, typeof(float)));
					dictionary.Add("UnitSpeed_kts", new IEventExporter.EventNotificationParameter(CurrentSpeed, typeof(float)));
					dictionary.Add("UnitAltitude_m", new IEventExporter.EventNotificationParameter(GetCurrentAltitude(), typeof(float)));
					dictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(Attitude_Pitch, typeof(float)));
					dictionary.Add("UnitAttitude_Roll", new IEventExporter.EventNotificationParameter(Attitude_Roll, typeof(float)));
					applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.UnitPositions, dictionary, scenario_0);
					applicableEventExporter.Common.ApplyLastExportLocation(this);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			broadcasterProxy = false;
		}
	}
}
