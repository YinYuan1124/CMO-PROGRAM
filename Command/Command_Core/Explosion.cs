using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Explosion : Module_Unit.Unit
{
	[CompilerGenerated]
	private sealed class DispatcherMerchantPage
	{
		public Explosion Me;

		public Scenario Local_theScen;

		public string Local_ExcludedUnit_ObjectID;

		public Explosion _003C_003E4__this;

		public Func<Mount, bool> _003C_003E9__1;

		internal bool ExcludeInterruptibleField(Mount theM)
		{
			if (theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _003C_003E4__this._RecordClient)
			{
				return theM != _003C_003E4__this.attrClient;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ProductMerchantService
	{
		public TList<ActiveUnit> Local_AffectedUnits;

		public float Local_theCutOffRange_Frag;

		public DispatcherMerchantPage CS_0024_003C_003E8__locals1;

		internal void IncludeInterruptibleField(ActiveUnit theAU)
		{
			if (theAU == null || !theAU.IsOperating())
			{
				return;
			}
			if (Module_ActiveUnit.CancelTokenizer(theAU))
			{
				if (Module_Unit.Has_Visual_LOS_ToUnit(CS_0024_003C_003E8__locals1.Me, null, theAU, ref CS_0024_003C_003E8__locals1.Local_theScen, bool_0: false) == LOSCheckResult.Success)
				{
					Local_AffectedUnits.Add(theAU);
				}
			}
			else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != CS_0024_003C_003E8__locals1.Me.m_SingletonClient && theAU != CS_0024_003C_003E8__locals1.Me._ExceptionClient && Module_Unit.RangeToUnit_Slant(CS_0024_003C_003E8__locals1.Me, theAU) <= Local_theCutOffRange_Frag && Operators.CompareString(CS_0024_003C_003E8__locals1.Local_ExcludedUnit_ObjectID, theAU.ObjectID, TextCompare: false) != 0 && (!Module_Unit.ResetTokenizer(CS_0024_003C_003E8__locals1.Me) || Module_Unit.Has_Visual_LOS_ToUnit(CS_0024_003C_003E8__locals1.Me, null, theAU, ref CS_0024_003C_003E8__locals1.Local_theScen, bool_0: false) == LOSCheckResult.Success))
			{
				Local_AffectedUnits.Add(theAU);
			}
		}
	}

	[CompilerGenerated]
	private sealed class ContainerDecoratorEntry
	{
		public Explosion Me;

		public double Local_CloudRadius_meters;

		public TList<ActiveUnit> Local_AffectedUnits;

		public Explosion _003C_003E4__this;

		public Func<Mount, bool> _003C_003E9__1;

		internal void SearchInterruptibleField(ActiveUnit theAU)
		{
			if (theAU.IsOperating() && !theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != Me._ExceptionClient && (double)(Module_Unit.RangeToUnit_Slant(Me, theAU) * 1852f) <= Local_CloudRadius_meters)
			{
				Local_AffectedUnits.Add(theAU);
			}
		}

		internal bool EnableInterruptibleField(Mount theM)
		{
			if (theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _003C_003E4__this._RecordClient)
			{
				return theM != _003C_003E4__this.attrClient;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class SetterThreadBridge
	{
		public Explosion Me;

		public string Local_ExcludedUnit_ObjectID;

		public float Local_CutOffRange_InCloud_meters;

		public TList<ActiveUnit> Local_AffectedUnits_InCloud;

		public float Local_CutOffRange_OutOfCloud_meters;

		public TList<ActiveUnit> Local_AffectedUnits_OutOfCloud;

		public Explosion _003C_003E4__this;

		public Func<Mount, bool> _003C_003E9__1;

		public Func<Mount, bool> _003C_003E9__2;

		internal void ChangeInterruptibleField(ActiveUnit theAU)
		{
			if (theAU.IsOperating() && !theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != Me._ExceptionClient && Operators.CompareString(Local_ExcludedUnit_ObjectID, theAU.ObjectID, TextCompare: false) != 0)
			{
				float num = Module_Unit.RangeToUnit_Slant(Me, theAU);
				if (num * 1852f <= Local_CutOffRange_InCloud_meters)
				{
					Local_AffectedUnits_InCloud.Add(theAU);
				}
				else if (num * 1852f <= Local_CutOffRange_OutOfCloud_meters)
				{
					Local_AffectedUnits_OutOfCloud.Add(theAU);
				}
			}
		}

		internal bool InitInterruptibleField(Mount theM)
		{
			if (theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _003C_003E4__this._RecordClient)
			{
				return theM != _003C_003E4__this.attrClient;
			}
			return false;
		}

		internal bool CheckInterruptibleField(Mount theM)
		{
			if (theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _003C_003E4__this._RecordClient)
			{
				return theM != _003C_003E4__this.attrClient;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class AdapterComparator
	{
		public string Local_ExcludedUnit_ObjectID;

		public Explosion Me;

		public Scenario Local_theScen;

		public Warhead.WarheadType Local_theWarheadType;

		public Weapon.DetonationMedium Local_BlastMedium;

		public Explosion _003C_003E4__this;

		public Func<Mount, bool> _003C_003E9__1;

		internal bool ConcatInterruptibleField(Mount theM)
		{
			if (theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _003C_003E4__this._RecordClient)
			{
				return theM != _003C_003E4__this.attrClient;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RegExpressionDic
	{
		public double Local_BlastRing_OuterRim;

		public double Local_BlastRing_InnerRim;

		public TList<ActiveUnit> Local_AffectedUnits;

		public AdapterComparator CS_0024_003C_003E8__locals1;

		internal void InterruptInterruptibleField(ActiveUnit theAU)
		{
			if (theAU == null || Operators.CompareString(CS_0024_003C_003E8__locals1.Local_ExcludedUnit_ObjectID, theAU.ObjectID, TextCompare: false) == 0)
			{
				return;
			}
			if (Module_ActiveUnit.CancelTokenizer(theAU))
			{
				float num = Module_Unit.RangeToUnit_Slant(CS_0024_003C_003E8__locals1.Me, theAU);
				double num2 = (double)num + (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957;
				if ((double)num + (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= Local_BlastRing_OuterRim && num2 >= Local_BlastRing_InnerRim && Module_Unit.Has_Visual_LOS_ToUnit(CS_0024_003C_003E8__locals1.Me, null, theAU, ref CS_0024_003C_003E8__locals1.Local_theScen, bool_0: false) == LOSCheckResult.Success)
				{
					Local_AffectedUnits.Add(theAU);
				}
			}
			else if (theAU.IsOperating() && !theAU.IsGroup && (!theAU.IsWeapon || ((CS_0024_003C_003E8__locals1.Local_theWarheadType == Warhead.WarheadType.Nuclear || (CS_0024_003C_003E8__locals1.Local_BlastMedium == Weapon.DetonationMedium.Underwater && CS_0024_003C_003E8__locals1.Me.ExplosiveType == Warhead.WarheadExplosivesType.Nuclear)) && ((Weapon)theAU).CanBeDestroyedByNuke)) && (!theAU.IsAircraft || CS_0024_003C_003E8__locals1.Me.WarheadType != Warhead.WarheadType.HE_BlastFrag) && (!theAU.IsFacility || (((Facility)theAU).Category != Facility._FacilityCategory.Building_Underground && ((Facility)theAU).Category != Facility._FacilityCategory.SurfaceAndUnderground)) && theAU != CS_0024_003C_003E8__locals1.Me._ExceptionClient && CS_0024_003C_003E8__locals1.Me.RevertRepository(theAU, CS_0024_003C_003E8__locals1.Local_BlastMedium))
			{
				double num3 = Module_Unit.RangeToUnit_Slant(CS_0024_003C_003E8__locals1.Me, theAU);
				if (Local_BlastRing_InnerRim <= num3 && num3 <= Local_BlastRing_OuterRim && (!Module_Unit.ResetTokenizer(CS_0024_003C_003E8__locals1.Me) || Module_Unit.Has_Visual_LOS_ToUnit(CS_0024_003C_003E8__locals1.Me, null, theAU, ref CS_0024_003C_003E8__locals1.Local_theScen, bool_0: false) == LOSCheckResult.Success))
				{
					Local_AffectedUnits.Add(theAU);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class DispatcherProcessProducer
	{
		public Explosion Me;

		public double Local_CraterRadius;

		public string Local_ExcludedUnit_ObjectID;

		public TList<ActiveUnit> Local_InstaKillUnits;

		internal void RemoveInterruptibleField(ActiveUnit theAU)
		{
			if (!theAU.IsOperating() || theAU.IsGroup)
			{
				return;
			}
			if ((double)Module_Unit.RangeToPoint_Slant(Me, new GeoPoint(theAU.GetLongitude(), theAU.GetLatitude(), theAU.GetCurrentAltitude())) <= Local_CraterRadius)
			{
				if (Operators.CompareString(Local_ExcludedUnit_ObjectID, theAU.ObjectID, TextCompare: false) != 0)
				{
					Local_InstaKillUnits.Add(theAU);
				}
			}
			else if (Me.GetCurrentAltitude() < 0f && theAU.GetCurrentAltitude() > Me.GetCurrentAltitude() && theAU.GetCurrentAltitude() < 2000f && (double)Module_Unit.RangeToPoint_Horiz(Me, theAU.GetLatitude(), theAU.GetLongitude()) <= Local_CraterRadius * 2.0 && Operators.CompareString(Local_ExcludedUnit_ObjectID, theAU.ObjectID, TextCompare: false) != 0)
			{
				Local_InstaKillUnits.Add(theAU);
			}
		}
	}

	[CompilerGenerated]
	private sealed class ListenerMerchantPage
	{
		public Explosion Me;

		public string Local_ExcludedUnit_ObjectID;

		public double Local_EffectRadius;

		public TList<ActiveUnit> Local_InstaKillUnits;

		internal void FindInterruptibleField(ActiveUnit theAU)
		{
			if (theAU != null && theAU.IsOperating() && !theAU.IsGroup && theAU.GetCurrentAltitude() >= 0f && theAU.CurrentAltitude_AGL >= 0f && (double)Module_Unit.RangeToPoint_Slant(Me, new GeoPoint(theAU.GetLongitude(), theAU.GetLatitude(), theAU.GetCurrentAltitude())) <= Local_EffectRadius && Operators.CompareString(Local_ExcludedUnit_ObjectID, theAU.ObjectID, TextCompare: false) != 0)
			{
				Local_InstaKillUnits.Add(theAU);
			}
		}
	}

	[CompilerGenerated]
	private sealed class SchemaComparator
	{
		public Scenario Local_thescen;

		public string Local_ExcludedUnit_ObjectID;

		public TList<ActiveUnit> Local_AffectedUnits;

		public Geopoint_Struct[] Local_theArea;

		internal void SetInterruptibleField(ActiveUnit theAU)
		{
			if (Module_ActiveUnit.CancelTokenizer(theAU))
			{
				Local_AffectedUnits.Add(theAU);
			}
			else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU.IsOperating() && theAU.GetIsInsideThisArea(Local_theArea, Local_thescen, bool_0: false) && Operators.CompareString(Local_ExcludedUnit_ObjectID, theAU.ObjectID, TextCompare: false) != 0)
			{
				Local_AffectedUnits.Add(theAU);
			}
		}
	}

	public double ExpYield;

	public double ExpYield_Graphics;

	private double m_PredicateClient;

	public Warhead.WarheadType WarheadType;

	public Weapon._WeaponType WeaponType;

	public Warhead.WarheadExplosivesType ExplosiveType;

	public int ClusterCoverageLength;

	public int ClusterCoverageWidth;

	public int ClusterSubmunitionQty;

	public float ClusterSubmunitionYield;

	private ActiveUnit m_SingletonClient;

	private Mount _RecordClient;

	private ActiveUnit _ExceptionClient;

	private Mount attrClient;

	private string _VisitorClient;

	private string exporterClient;

	private string m_PrototypeClient;

	private string comparatorClient;

	private float? m_ItemClient;

	private bool? _SetterClient;

	private bool? _CreatorClient;

	private double templateClient;

	private double mappingClient;

	public double Longitude_Graphics
	{
		get
		{
			return mappingClient;
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
				mappingClient = value;
			}
		}
	}

	public double Latitude_Graphics
	{
		get
		{
			return templateClient;
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
				templateClient = value;
			}
		}
	}

	public float MaxDuration
	{
		get
		{
			if (!m_ItemClient.HasValue)
			{
				double num = CurrentAltitude_AGL;
				switch (WarheadType)
				{
				case Warhead.WarheadType.Torpedo:
				case Warhead.WarheadType.DepthCharge:
				case Warhead.WarheadType.Torpedo_ASWOptimized:
				{
					double num6 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Underwater);
					return (float)Math.Max(2.0, num6 / 2916.0 * 3600.0);
				}
				default:
					return 0f;
				case Warhead.WarheadType.SuperFrag:
				case Warhead.WarheadType.Cluster_AP:
				case Warhead.WarheadType.Cluster_AT:
				case Warhead.WarheadType.Cluster_Penetrator:
				case Warhead.WarheadType.Cluster_SmartSubs:
					return Math.Max(2f, GetCurrentAltitude() / 300f);
				case Warhead.WarheadType.HE_BlastFrag:
				case Warhead.WarheadType.SemiAP:
				case Warhead.WarheadType.HESH:
				case Warhead.WarheadType.HardTargetPenetrator:
				case Warhead.WarheadType.Nuclear:
				{
					double num2 = num;
					double num3 = 0.0;
					if (num2 < 0.0)
					{
						if (num2 < 0.0)
						{
							if (Module_Unit.ResetTokenizer(this))
							{
								double num4 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Underground);
								return (float)Math.Max(2.0, num4 / 5832.0 * 3600.0);
							}
							double num5 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Underwater);
							return (float)Math.Max(2.0, num5 / 2916.0 * 3600.0);
						}
					}
					else
					{
						num3 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Air);
					}
					return (float)Math.Max(2.0, num3 / 661.0 * 3600.0);
				}
				}
			}
			return m_ItemClient.Value;
		}
	}

	public override bool IsUnderground
	{
		get
		{
			if (!_SetterClient.HasValue)
			{
				_SetterClient = base.IsUnderground;
			}
			return _SetterClient.Value;
		}
	}

	public override bool IsUnderwater
	{
		get
		{
			if (!_CreatorClient.HasValue)
			{
				_CreatorClient = base.IsUnderwater;
			}
			return _CreatorClient.Value;
		}
	}

	public double Age => m_PredicateClient;

	public bool HasExpired => m_PredicateClient == (double)MaxDuration;

	public bool IsCluster
	{
		get
		{
			Warhead.WarheadType warheadType = WarheadType;
			if (warheadType != Warhead.WarheadType.SuperFrag && (uint)(warheadType - 6001) > 2u && warheadType != Warhead.WarheadType.Cluster_SmartSubs)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsAirburst
	{
		get
		{
			if (CurrentAltitude_AGL <= 0f)
			{
				return false;
			}
			return GetCurrentAltitude() > 0f;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Explosion");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("CA", XmlConvert.ToString(GetCurrentAltitude()));
			xmlWriter_0.WriteElementString("Lon", XmlConvert.ToString(GetLongitude()));
			xmlWriter_0.WriteElementString("Lat", XmlConvert.ToString(GetLatitude()));
			xmlWriter_0.WriteElementString("Lon_Graphics", XmlConvert.ToString(Longitude_Graphics));
			xmlWriter_0.WriteElementString("Lat_Graphics", XmlConvert.ToString(Latitude_Graphics));
			if (!string.IsNullOrEmpty(Message))
			{
				xmlWriter_0.WriteElementString("Message", Message);
			}
			xmlWriter_0.WriteElementString("Yield", XmlConvert.ToString(ExpYield));
			xmlWriter_0.WriteElementString("Yield_Graphics", XmlConvert.ToString(ExpYield_Graphics));
			xmlWriter_0.WriteElementString("TTL", XmlConvert.ToString(m_PredicateClient));
			if (!Information.IsNothing(m_ItemClient))
			{
				xmlWriter_0.WriteElementString("MaxD", XmlConvert.ToString(m_ItemClient.Value));
			}
			XmlWriter obj = xmlWriter_0;
			int warheadType = (int)WarheadType;
			obj.WriteElementString("WarheadType", warheadType.ToString());
			XmlWriter obj2 = xmlWriter_0;
			warheadType = (int)WeaponType;
			obj2.WriteElementString("WeaponType", warheadType.ToString());
			XmlWriter obj3 = xmlWriter_0;
			short explosiveType = (short)ExplosiveType;
			obj3.WriteElementString("ExpType", explosiveType.ToString());
			if (!Information.IsNothing(m_SingletonClient))
			{
				xmlWriter_0.WriteElementString("_DirectImpactUnit", m_SingletonClient.ObjectID);
			}
			if (!Information.IsNothing(_RecordClient))
			{
				xmlWriter_0.WriteElementString("_DirectImpactAimpoint", _RecordClient.ObjectID);
			}
			if (!Information.IsNothing(_ExceptionClient))
			{
				xmlWriter_0.WriteElementString("_ExcludedUnit", _ExceptionClient.ObjectID);
			}
			xmlWriter_0.WriteElementString("_ExcludedAimPointID", comparatorClient);
			if (!Information.IsNothing(attrClient))
			{
				xmlWriter_0.WriteElementString("_ExcludedAimpoint", attrClient.ObjectID);
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100842", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Explosion FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		Explosion result = null;
		try
		{
			Explosion explosion = new Explosion();
			explosion.WarheadType = Warhead.WarheadType.HE_BlastFrag;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Name":
						explosion.Name = xmlNode.InnerText;
						break;
					case "_ExcludedAimPoint":
						explosion.comparatorClient = xmlNode.InnerText;
						break;
					case "Yield":
						explosion.ExpYield = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "TTL":
						explosion.m_PredicateClient = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "Latitude_Graphics":
						explosion.Latitude_Graphics = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							explosion.ObjectID_Set(xmlNode.InnerText);
							break;
						}
						result = (Explosion)concurrentDictionary_0[xmlNode.InnerText];
						return result;
					case "ExpType":
						explosion.ExplosiveType = (Warhead.WarheadExplosivesType)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "WeaponType":
						explosion.WeaponType = (Weapon._WeaponType)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "CurrentAltitude":
					case "CH":
						explosion.CurrentHeading = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "MaxD":
						explosion.m_ItemClient = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CA":
						explosion.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "Latitude":
					case "Lat":
						explosion.SetLatitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "Message":
						explosion.Message = xmlNode.InnerText;
						break;
					case "Longitude":
					case "Lon":
						explosion.SetLongitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "Yield_Graphics":
						explosion.ExpYield_Graphics = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "Longitude_Graphics":
						explosion.Longitude_Graphics = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "_DirectImpactUnit":
						explosion._VisitorClient = xmlNode.InnerText;
						break;
					case "Duration":
						explosion.m_PredicateClient = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "WarheadType":
					case "Type":
						explosion.WarheadType = (Warhead.WarheadType)Conversions.ToInteger(xmlNode.InnerText);
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							explosion.WarheadType = (Warhead.WarheadType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							explosion.WarheadType = (Warhead.WarheadType)Enum.Parse(typeof(Warhead.WarheadType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "_ExcludedUnit":
						explosion.m_PrototypeClient = xmlNode.InnerText;
						break;
					case "_DirectImpactAimpoint":
						explosion.exporterClient = xmlNode.InnerText;
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
			concurrentDictionary_0.TryAdd(explosion.ObjectID, explosion);
			result = explosion;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100843", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void PostDeserializationHousekeeping(ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			if (!Information.IsNothing(_VisitorClient))
			{
				m_SingletonClient = (ActiveUnit)concurrentDictionary_0[_VisitorClient];
				_RecordClient = (Mount)concurrentDictionary_0[exporterClient];
				_ExceptionClient = (ActiveUnit)concurrentDictionary_0[m_PrototypeClient];
				attrClient = (Mount)concurrentDictionary_0[comparatorClient];
			}
			if (!string.IsNullOrEmpty(m_PrototypeClient) && concurrentDictionary_0.ContainsKey(m_PrototypeClient))
			{
				_ExceptionClient = (ActiveUnit)concurrentDictionary_0[m_PrototypeClient];
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200040", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Explosion()
	{
		ExplosiveType = Warhead.WarheadExplosivesType.None;
	}

	public void Progress(ref Scenario scenario_0, float float_0)
	{
		m_PredicateClient += float_0;
		double num = MaxDuration;
		if (m_PredicateClient > num)
		{
			m_PredicateClient = num;
		}
		string string_ = ((_ExceptionClient == null) ? m_PrototypeClient : _ExceptionClient.ObjectID);
		if (m_PredicateClient == num && IsCluster)
		{
			DestroyBridge(scenario_0, string_);
		}
		if (!(m_PredicateClient < num))
		{
			return;
		}
		switch (WarheadType)
		{
		case Warhead.WarheadType.HE_BlastFrag:
		case Warhead.WarheadType.SemiAP:
		case Warhead.WarheadType.HESH:
		case Warhead.WarheadType.HardTargetPenetrator:
		case Warhead.WarheadType.Torpedo:
		case Warhead.WarheadType.DepthCharge:
		case Warhead.WarheadType.Torpedo_ASWOptimized:
		case Warhead.WarheadType.Nuclear:
		{
			bool bool_ = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
			if (IsUnderwater)
			{
				CloneBridge(scenario_0, string_, Weapon.DetonationMedium.Underwater, WarheadType, float_0, bool_);
			}
			else if (IsUnderground)
			{
				CloneBridge(scenario_0, string_, Weapon.DetonationMedium.Underground, WarheadType, float_0, bool_);
			}
			else
			{
				CloneBridge(scenario_0, string_, Weapon.DetonationMedium.Air, WarheadType, float_0, bool_);
			}
			break;
		}
		}
	}

	public Explosion(ref Scenario scenario_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, Weapon._WeaponType _WeaponType_0, float float_2, float float_3, Warhead.WarheadType warheadType_0, Warhead.WarheadExplosivesType warheadExplosivesType_0, ActiveUnit activeUnit_0 = null, Mount mount_0 = null, ActiveUnit activeUnit_1 = null, Mount mount_1 = null, float? nullable_0 = null, short short_0 = 0, short short_1 = 0, int int_0 = 0, float float_4 = 0f, int int_1 = 0)
	{
		ExplosiveType = Warhead.WarheadExplosivesType.None;
		try
		{
			SetLongitude(null, double_0);
			SetLatitude(null, double_1);
			Longitude_Graphics = double_2;
			Latitude_Graphics = double_3;
			SetCurrentAltitude(bool_0: false, float_1);
			ExpYield = float_2;
			ExpYield_Graphics = float_3;
			WarheadType = warheadType_0;
			WeaponType = _WeaponType_0;
			ExplosiveType = warheadExplosivesType_0;
			m_SingletonClient = activeUnit_0;
			_RecordClient = mount_0;
			_ExceptionClient = activeUnit_1;
			attrClient = mount_1;
			m_PredicateClient = 0.0;
			ClearElevationAndAltitudeAGL();
			ClusterCoverageLength = short_0;
			ClusterCoverageWidth = short_1;
			ClusterSubmunitionQty = int_0;
			ClusterSubmunitionYield = (float)(ExpYield / (double)int_0);
			if (_ExceptionClient == null)
			{
				m_PrototypeClient = "";
			}
			else
			{
				m_PrototypeClient = _ExceptionClient.ObjectID;
			}
			if (WarheadType == Warhead.WarheadType.HardTargetPenetrator && IsOnLand())
			{
				SetCurrentAltitude(bool_0: false, (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, scenario_0) - 10f);
			}
			if (warheadType_0 == Warhead.WarheadType.Nuclear)
			{
				DeleteBridge(ref scenario_0, m_PrototypeClient);
				AddBridge(ref scenario_0, m_PrototypeClient);
			}
			if (IsAirburst)
			{
				if (ExpYield > 0.0)
				{
					Explosion explosion = new Explosion(ref scenario_0, double_0, double_1, Longitude_Graphics, Latitude_Graphics, float_0, float_1, _WeaponType_0, float_2, float_3, warheadType_0, warheadExplosivesType_0, Weapon.DetonationMedium.Air, activeUnit_0, mount_0, activeUnit_1, mount_1, nullable_0, int_1)
					{
						ClusterCoverageLength = ClusterCoverageLength,
						ClusterCoverageWidth = ClusterCoverageWidth,
						ClusterSubmunitionQty = ClusterSubmunitionQty,
						ClusterSubmunitionYield = ClusterSubmunitionYield
					};
					if (!Information.IsNothing(nullable_0))
					{
						explosion.m_ItemClient = nullable_0;
					}
					if (PatchBridge(float_2 / 1000000f, CurrentAltitude_AGL))
					{
						MoveBridge(ref scenario_0, m_PrototypeClient, Weapon.DetonationMedium.Air);
					}
				}
				if (WarheadType == Warhead.WarheadType.Nuclear)
				{
					if (ExpYield > 0.0)
					{
						LogoutBridge(scenario_0);
					}
				}
				else if (WarheadType == Warhead.WarheadType.Fragmentation || WarheadType == Warhead.WarheadType.HardTargetPenetrator || WarheadType == Warhead.WarheadType.HE_BlastFrag || WarheadType == Warhead.WarheadType.HEAT || WarheadType == Warhead.WarheadType.HESH || WarheadType == Warhead.WarheadType.Landmine_AP || WarheadType == Warhead.WarheadType.Landmine_AT || WarheadType == Warhead.WarheadType.SemiAP || WarheadType == Warhead.WarheadType.FAE || WarheadType == Warhead.WarheadType.SuperFrag)
				{
					if (!Module_Unit.ResetTokenizer(this) && WarheadType != Warhead.WarheadType.Incendiary)
					{
						if (Information.IsNothing(activeUnit_1))
						{
							new WaterSplash(ref scenario_0, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Surface));
						}
					}
					else
					{
						new GroundImpact(ref scenario_0, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Air), WarheadType == Warhead.WarheadType.Incendiary);
					}
				}
				if (WarheadType == Warhead.WarheadType.EMP_Omni)
				{
					ExpYield = 42999999.0;
					LogoutBridge(scenario_0);
				}
			}
			else if (IsOnLand())
			{
				if (ExpYield > 0.0)
				{
					Explosion explosion2 = new Explosion(ref scenario_0, double_0, double_1, Longitude_Graphics, Latitude_Graphics, float_0, Terrain.GetElevation(double_1, double_0, bool_0: false, scenario_0) + 1, _WeaponType_0, (float)((double)float_2 * 0.95), float_3, warheadType_0, warheadExplosivesType_0, Weapon.DetonationMedium.Air, activeUnit_0, mount_0, activeUnit_1, mount_1, nullable_0)
					{
						ClusterCoverageLength = ClusterCoverageLength,
						ClusterCoverageWidth = ClusterCoverageWidth,
						ClusterSubmunitionQty = ClusterSubmunitionQty,
						ClusterSubmunitionYield = ClusterSubmunitionYield
					};
					if (!Information.IsNothing(nullable_0))
					{
						explosion2.m_ItemClient = nullable_0;
					}
					MoveBridge(ref scenario_0, m_PrototypeClient, Weapon.DetonationMedium.Surface);
				}
				if (WarheadType == Warhead.WarheadType.Nuclear)
				{
					if (ExpYield > 0.0)
					{
						LogoutBridge(scenario_0);
					}
				}
				else if (WarheadType == Warhead.WarheadType.Incendiary || WarheadType == Warhead.WarheadType.Fragmentation || WarheadType == Warhead.WarheadType.HardTargetPenetrator || WarheadType == Warhead.WarheadType.HE_BlastFrag || WarheadType == Warhead.WarheadType.HEAT || WarheadType == Warhead.WarheadType.HESH || WarheadType == Warhead.WarheadType.Landmine_AP || WarheadType == Warhead.WarheadType.Landmine_AT || WarheadType == Warhead.WarheadType.SemiAP || WarheadType == Warhead.WarheadType.FAE)
				{
					new GroundImpact(ref scenario_0, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Air), WarheadType == Warhead.WarheadType.Incendiary);
				}
			}
			else if (IsOnSurface())
			{
				if (ExpYield > 0.0)
				{
					Explosion explosion3 = new Explosion(ref scenario_0, double_0, double_1, Longitude_Graphics, Latitude_Graphics, float_0, 1f, _WeaponType_0, (float)((double)float_2 * 0.9), float_3, warheadType_0, warheadExplosivesType_0, Weapon.DetonationMedium.Air, activeUnit_0, mount_0, activeUnit_1, mount_1, nullable_0)
					{
						ClusterCoverageLength = ClusterCoverageLength,
						ClusterCoverageWidth = ClusterCoverageWidth,
						ClusterSubmunitionQty = ClusterSubmunitionQty,
						ClusterSubmunitionYield = ClusterSubmunitionYield
					};
					if (!Information.IsNothing(nullable_0))
					{
						explosion3.m_ItemClient = nullable_0;
					}
					if (WarheadType == Warhead.WarheadType.Nuclear)
					{
						Explosion explosion4 = new Explosion(ref scenario_0, double_0, double_1, Longitude_Graphics, Latitude_Graphics, float_0, -1f, _WeaponType_0, (float)((double)float_2 * 0.1), float_3, Warhead.WarheadType.HE_BlastFrag, warheadExplosivesType_0, Weapon.DetonationMedium.Underwater, activeUnit_0, mount_0, activeUnit_1, mount_1, nullable_0)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth
						};
						if (!Information.IsNothing(nullable_0))
						{
							explosion4.m_ItemClient = nullable_0;
						}
					}
				}
				if (WarheadType == Warhead.WarheadType.Nuclear)
				{
					if (ExpYield > 0.0)
					{
						LogoutBridge(scenario_0);
					}
				}
				else if (WarheadType == Warhead.WarheadType.Incendiary)
				{
					new GroundImpact(ref scenario_0, Longitude_Graphics, Latitude_Graphics, 0.01349892f, WarheadType == Warhead.WarheadType.Incendiary);
				}
				else if (!IsCluster)
				{
					new WaterSplash(ref scenario_0, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Air));
				}
			}
			else if (IsUnderwater)
			{
				if (ExpYield > 0.0)
				{
					int num = 1;
					if (WarheadType == Warhead.WarheadType.Nuclear)
					{
						num = 600;
					}
					if (GetCurrentAltitude() < (float)(-num))
					{
						Explosion explosion5 = new Explosion(ref scenario_0, double_0, double_1, Longitude_Graphics, Latitude_Graphics, float_0, float_1, _WeaponType_0, float_2, float_3, warheadType_0, warheadExplosivesType_0, Weapon.DetonationMedium.Underwater, activeUnit_0, mount_0, activeUnit_1, mount_1, nullable_0)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth,
							ClusterSubmunitionQty = ClusterSubmunitionQty,
							ClusterSubmunitionYield = ClusterSubmunitionYield
						};
						if (nullable_0.HasValue)
						{
							explosion5.m_ItemClient = nullable_0;
						}
					}
					else
					{
						double x = Math.Sqrt(Math.Pow(num, 2.0) - Math.Pow(GetCurrentAltitude(), 2.0));
						double num2 = Math.PI / 6.0 * (double)Math.Abs(GetCurrentAltitude()) * (3.0 * Math.Pow(num, 2.0) + 3.0 * Math.Pow(x, 2.0) + Math.Pow(GetCurrentAltitude(), 2.0));
						double num3 = 4.1887902047863905 * Math.Pow(num, 3.0);
						double num4 = num3 / 2.0 + num2;
						double num5 = (double)float_2 * (num4 / num3);
						double num6 = (double)float_2 - num5;
						Explosion explosion6 = new Explosion(ref scenario_0, double_0, double_1, Longitude_Graphics, Latitude_Graphics, float_0, float_1, _WeaponType_0, (float)num5, float_3, warheadType_0, warheadExplosivesType_0, Weapon.DetonationMedium.Underwater, activeUnit_0, mount_0, activeUnit_1, mount_1, nullable_0)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth,
							ClusterSubmunitionQty = ClusterSubmunitionQty,
							ClusterSubmunitionYield = ClusterSubmunitionYield
						};
						if (nullable_0.HasValue)
						{
							explosion6.m_ItemClient = nullable_0;
						}
						Explosion explosion7 = new Explosion(ref scenario_0, double_0, double_1, Longitude_Graphics, Latitude_Graphics, float_0, 0f, _WeaponType_0, (float)num6, float_3, warheadType_0, warheadExplosivesType_0, Weapon.DetonationMedium.Underwater, activeUnit_0, mount_0, activeUnit_1, mount_1, nullable_0)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth,
							ClusterSubmunitionQty = ClusterSubmunitionQty,
							ClusterSubmunitionYield = ClusterSubmunitionYield
						};
						if (nullable_0.HasValue)
						{
							explosion7.m_ItemClient = nullable_0;
						}
					}
				}
				if (!IsCluster)
				{
					new WaterSplash(ref scenario_0, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Underwater));
				}
			}
			else
			{
				if (!IsUnderground)
				{
					throw new NotImplementedException("Unforeseen set of circumstances for Explosion. Explosion altitude: " + Conversions.ToString(CurrentHeading) + ". Local terrain elevation: " + Conversions.ToString((int)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, GetUnitSide().ParentScen)));
				}
				if (ExpYield > 0.0)
				{
					MoveBridge(ref scenario_0, m_PrototypeClient, Weapon.DetonationMedium.Underground);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100844", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Explosion(ref Scenario scenario_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, Weapon._WeaponType _WeaponType_0, float float_2, float float_3, Warhead.WarheadType warheadType_0, Warhead.WarheadExplosivesType warheadExplosivesType_0, Weapon.DetonationMedium detonationMedium_0, ActiveUnit activeUnit_0 = null, Mount mount_0 = null, ActiveUnit activeUnit_1 = null, Mount mount_1 = null, float? nullable_0 = null, int int_0 = 0)
	{
		ExplosiveType = Warhead.WarheadExplosivesType.None;
		try
		{
			SetLongitude(null, double_0);
			SetLatitude(null, double_1);
			Longitude_Graphics = double_2;
			Latitude_Graphics = double_3;
			SetCurrentAltitude(bool_0: false, float_1);
			CurrentHeading = float_0;
			ExpYield = float_2;
			ExpYield_Graphics = float_3;
			WarheadType = warheadType_0;
			WeaponType = _WeaponType_0;
			ExplosiveType = warheadExplosivesType_0;
			m_SingletonClient = activeUnit_0;
			_RecordClient = mount_0;
			_ExceptionClient = activeUnit_1;
			attrClient = mount_1;
			m_PredicateClient = 0.0;
			if (!Information.IsNothing(nullable_0))
			{
				m_ItemClient = nullable_0;
			}
			if (Information.IsNothing(_ExceptionClient))
			{
				m_PrototypeClient = "";
			}
			else
			{
				m_PrototypeClient = _ExceptionClient.ObjectID;
			}
			scenario_0.UnitsAutoIncrement++;
			scenario_0.Explosions.Add(this);
			bool bool_ = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
			switch (WarheadType)
			{
			case Warhead.WarheadType.Incendiary:
				CountBridge(scenario_0, null, WarheadType, scenario_0.GameResolution);
				break;
			case Warhead.WarheadType.HE_BlastFrag:
			case Warhead.WarheadType.SemiAP:
			case Warhead.WarheadType.HardTargetPenetrator:
			case Warhead.WarheadType.Torpedo:
			case Warhead.WarheadType.DepthCharge:
				if (CurrentAltitude_AGL >= 0f && Module_Unit.ResetTokenizer(this))
				{
					ManageRepository(scenario_0, m_PrototypeClient, bool_, int_0);
				}
				if (MaxDuration <= scenario_0.GameResolution)
				{
					m_PredicateClient = scenario_0.GameResolution;
					if (IsUnderwater)
					{
						CloneBridge(scenario_0, m_PrototypeClient, Weapon.DetonationMedium.Underwater, warheadType_0, scenario_0.GameResolution, bool_);
					}
					else if (IsUnderground)
					{
						CloneBridge(scenario_0, m_PrototypeClient, Weapon.DetonationMedium.Underground, warheadType_0, scenario_0.GameResolution, bool_);
					}
					else
					{
						CloneBridge(scenario_0, m_PrototypeClient, Weapon.DetonationMedium.Air, warheadType_0, scenario_0.GameResolution, bool_);
					}
				}
				break;
			case Warhead.WarheadType.FAE:
				CustomizeBridge(scenario_0, m_PrototypeClient, Warhead.WarheadType.FAE, scenario_0.GameResolution, scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects));
				break;
			case Warhead.WarheadType.Fragmentation:
			case Warhead.WarheadType.SuperFrag:
				if (GetCurrentAltitude() >= 0f)
				{
					ManageRepository(scenario_0, m_PrototypeClient, bool_, int_0);
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100845", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private bool IsOnLand()
	{
		if (CurrentAltitude_AGL == 0f)
		{
			return Module_Unit.ResetTokenizer(this);
		}
		return false;
	}

	[SpecialName]
	private bool IsOnSurface()
	{
		if (GetCurrentAltitude() == 0f)
		{
			return !Module_Unit.ResetTokenizer(this);
		}
		return false;
	}

	private void ManageRepository(Scenario scenario_0, string string_0, bool bool_0, int int_0 = 0)
	{
		try
		{
			float Local_theCutOffRange_Frag = GetCutoffRange_Frag_nm(ExpYield, Weapon.DetonationMedium.Air);
			if (!Information.IsNothing(_RecordClient))
			{
				_RecordClient.ResolveDamageFromFrag(ExpYield, Local_theCutOffRange_Frag, int_0);
			}
			TList<ActiveUnit> Local_AffectedUnits = new TList<ActiveUnit>();
			Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), delegate(ActiveUnit theAU)
			{
				if (theAU != null && theAU.IsOperating())
				{
					if (Module_ActiveUnit.CancelTokenizer(theAU))
					{
						if (Module_Unit.Has_Visual_LOS_ToUnit(this, null, theAU, ref scenario_0, bool_0: false) == LOSCheckResult.Success)
						{
							Local_AffectedUnits.Add(theAU);
						}
					}
					else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != m_SingletonClient && theAU != _ExceptionClient && Module_Unit.RangeToUnit_Slant(this, theAU) <= Local_theCutOffRange_Frag && Operators.CompareString(string_0, theAU.ObjectID, TextCompare: false) != 0 && (!Module_Unit.ResetTokenizer(this) || Module_Unit.Has_Visual_LOS_ToUnit(this, null, theAU, ref scenario_0, bool_0: false) == LOSCheckResult.Success))
					{
						Local_AffectedUnits.Add(theAU);
					}
				}
			});
			IEnumerator enumerator = null;
			try
			{
				enumerator = Local_AffectedUnits.GetEnumerator();
				double double_ = 0.0;
				double double_2 = 0.0;
				while (enumerator.MoveNext())
				{
					ActiveUnit activeUnit = (ActiveUnit)enumerator.Current;
					float num = MathFunctions.SlantRange_NM_SR(Math2.VerifyClass(GetLatitude(), GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetLongitude()), Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude()));
					if (activeUnit.IsFacility && ((Facility)activeUnit).HasAimpoints)
					{
						if (!Information.IsNothing(_RecordClient))
						{
							_RecordClient.ResolveDamageFromBlast(ExpYield, WarheadType);
						}
						foreach (Mount item in activeUnit.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _RecordClient && theM != attrClient))
						{
							Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_, ref double_2, item.AimpointOffset_Distance / 1852f, item.AimpointOffset_Bearing);
							float num2 = Math2.VerifyClass(GetLatitude(), GetLongitude(), double_2, double_);
							if (num2 < 0f)
							{
								num2 = 0f - num2;
							}
							double double_3 = MathFunctions.SlantRange_NM_SR(num2, Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude()));
							double num3 = Warhead.FragDamageAtThisDistance(double_2, double_, double_3, WarheadType, ExpYield, Weapon.DetonationMedium.Air, bool_0, activeUnit.ParentScen);
							if (num3 > 0.0)
							{
								item.ResolveDamageFromFrag(num3, Local_theCutOffRange_Frag, int_0);
							}
						}
					}
					else
					{
						float float_ = Warhead.FragDamageAtThisDistance(activeUnit.GetLatitude(), activeUnit.GetLongitude(), num, WarheadType, ExpYield, Weapon.DetonationMedium.Air, bool_0, scenario_0);
						activeUnit.Damage.ResolveDamageFromFrag(float_, Local_theCutOffRange_Frag, int_0);
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100846", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool RevertRepository(ActiveUnit activeUnit_0, Weapon.DetonationMedium detonationMedium_0)
	{
		switch (detonationMedium_0)
		{
		case Weapon.DetonationMedium.Air:
			if (!activeUnit_0.IsUnderground)
			{
				return !activeUnit_0.IsUnderwater;
			}
			return false;
		default:
			throw new NotImplementedException();
		case Weapon.DetonationMedium.Underwater:
			if (activeUnit_0.IsShip && WeaponType == Weapon._WeaponType.DepthCharge)
			{
				return false;
			}
			if (activeUnit_0.GetCurrentAltitude() <= 0f)
			{
				return !Module_Unit.ResetTokenizer(activeUnit_0);
			}
			return false;
		case Weapon.DetonationMedium.Underground:
			if (!activeUnit_0.IsFixedFacility)
			{
				return activeUnit_0.IsUnderground;
			}
			return true;
		}
	}

	private void CountBridge(Scenario scenario_0, string string_0, Warhead.WarheadType warheadType_0, float float_0)
	{
		double Local_CloudRadius_meters = Math.Sqrt(2100.0 / Math.PI);
		TList<ActiveUnit> Local_AffectedUnits = new TList<ActiveUnit>();
		Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), delegate(ActiveUnit theAU)
		{
			if (theAU.IsOperating() && !theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != _ExceptionClient && (double)(Module_Unit.RangeToUnit_Slant(this, theAU) * 1852f) <= Local_CloudRadius_meters)
			{
				Local_AffectedUnits.Add(theAU);
			}
		});
		IEnumerator enumerator = null;
		try
		{
			enumerator = Local_AffectedUnits.GetEnumerator();
			GlobalVariables.ArmorRating armorRating = (GlobalVariables.ArmorRating)0;
			int num = 0;
			while (enumerator.MoveNext())
			{
				ActiveUnit activeUnit = (ActiveUnit)enumerator.Current;
				if (activeUnit.IsFacility && ((Facility)activeUnit).HasAimpoints)
				{
					foreach (Mount item in activeUnit.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _RecordClient && theM != attrClient))
					{
						int num2;
						switch (item.ArmorRating)
						{
						default:
							num2 = 8;
							break;
						case GlobalVariables.ArmorRating.Light:
							num2 = 6;
							break;
						case GlobalVariables.ArmorRating.Medium:
							num2 = 4;
							break;
						case GlobalVariables.ArmorRating.Heavy:
						case GlobalVariables.ArmorRating.Special:
							num2 = 2;
							break;
						}
						if (GameGeneral.LockRandom_0.Next(1, 11) < num2)
						{
							activeUnit.AddMessage(Misc.ReadRequest(activeUnit.Name) + "损坏报告：" + Misc.ReadRequest(item.Name) + "已被摧毁！", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
							item.Destroy(activeUnit.GetUnitSide(), bool_0: false, bool_1: true);
						}
					}
					continue;
				}
				switch (activeUnit.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Ship:
					armorRating = ((Ship)activeUnit).Armor_Deck;
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					armorRating = ((Facility)activeUnit).Armor_General;
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					continue;
				}
				switch (activeUnit.VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					num += 4;
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					num += 3;
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					num += 2;
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					num++;
					break;
				}
				switch (armorRating)
				{
				default:
					num += 4;
					break;
				case GlobalVariables.ArmorRating.Light:
					num += 3;
					break;
				case GlobalVariables.ArmorRating.Medium:
					num += 2;
					break;
				case GlobalVariables.ArmorRating.Heavy:
				case GlobalVariables.ArmorRating.Special:
					num++;
					break;
				}
				num = Math.Min(4, (int)Math.Round((double)num / 2.0));
				activeUnit.Damage.CauseFire((ActiveUnit_Damage.FireIntensityLevel)Math.Max((int)activeUnit.Damage.FireIntensity, num));
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

	private void CustomizeBridge(Scenario scenario_0, string string_0, Warhead.WarheadType warheadType_0, float float_0, bool bool_0)
	{
		double num = ExpYield;
		float rainfallRate = Weather.GetWeatherAtThisTimeAndPlace(scenario_0, GetLatitude(), GetLongitude(), (int)Math.Round(GetCurrentAltitude())).RainfallRate;
		if (rainfallRate >= 5f)
		{
			num = ((rainfallRate < 10f) ? (num * 0.9) : ((rainfallRate < 20f) ? (num * 0.7) : ((rainfallRate < 30f) ? (num * 0.5) : ((rainfallRate < 40f) ? (num * 0.35) : (num * 0.2)))));
		}
		float currentAltitude = GetCurrentAltitude();
		if (currentAltitude >= 1000f)
		{
			num = ((currentAltitude < 2000f) ? (num * 0.9) : ((currentAltitude < 3000f) ? (num * 0.75) : ((currentAltitude < 4000f) ? (num * 0.6) : ((currentAltitude < 5000f) ? (num * 0.45) : ((currentAltitude < 6000f) ? (num * 0.3) : (num * 0.2))))));
		}
		float Local_CutOffRange_InCloud_meters = (float)(ExpYield / 5.0);
		float Local_CutOffRange_OutOfCloud_meters = Local_CutOffRange_InCloud_meters + GetCutoffRange_Blast_nm(num, Weapon.DetonationMedium.Air) * 1852f;
		TList<ActiveUnit> Local_AffectedUnits_InCloud = new TList<ActiveUnit>();
		TList<ActiveUnit> Local_AffectedUnits_OutOfCloud = new TList<ActiveUnit>();
		Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), delegate(ActiveUnit theAU)
		{
			if (theAU.IsOperating() && !theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != _ExceptionClient && Operators.CompareString(string_0, theAU.ObjectID, TextCompare: false) != 0)
			{
				float num4 = Module_Unit.RangeToUnit_Slant(this, theAU);
				if (num4 * 1852f <= Local_CutOffRange_InCloud_meters)
				{
					Local_AffectedUnits_InCloud.Add(theAU);
				}
				else if (num4 * 1852f <= Local_CutOffRange_OutOfCloud_meters)
				{
					Local_AffectedUnits_OutOfCloud.Add(theAU);
				}
			}
		});
		IEnumerator enumerator = null;
		try
		{
			enumerator = Local_AffectedUnits_InCloud.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ActiveUnit activeUnit = (ActiveUnit)enumerator.Current;
				if (activeUnit.IsFacility && ((Facility)activeUnit).HasAimpoints)
				{
					foreach (Mount item in activeUnit.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _RecordClient && theM != attrClient))
					{
						item.ResolveDamageFromBlast(num, warheadType_0);
					}
				}
				else
				{
					activeUnit.Damage.CauseFire(ActiveUnit_Damage.FireIntensityLevel.Major);
					activeUnit.Damage.ResolveDamageFromBlast((float)num, warheadType_0, ExplosiveType, Weapon.DetonationMedium.Air);
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
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = Local_AffectedUnits_OutOfCloud.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				ActiveUnit activeUnit2 = (ActiveUnit)enumerator2.Current;
				float num2 = Module_Unit.RangeToPoint_Horiz(activeUnit2, GetLatitude(), GetLongitude()) - Local_CutOffRange_InCloud_meters / 1852f;
				float num3 = Warhead.BlastDamageAtThisDistance(activeUnit2.GetLatitude(), activeUnit2.GetLongitude(), num2, activeUnit2.InitialDP, WarheadType, num, Weapon.DetonationMedium.Air, bool_0, scenario_0);
				if (activeUnit2.IsFacility && ((Facility)activeUnit2).HasAimpoints)
				{
					foreach (Mount item2 in activeUnit2.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _RecordClient && theM != attrClient))
					{
						item2.ResolveDamageFromBlast(num3, warheadType_0);
					}
				}
				else
				{
					activeUnit2.Damage.CauseFire(ActiveUnit_Damage.FireIntensityLevel.Major);
					activeUnit2.Damage.ResolveDamageFromBlast(num3, warheadType_0, ExplosiveType, Weapon.DetonationMedium.Air);
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
	}

	private void CloneBridge(Scenario scenario_0, string string_0, Weapon.DetonationMedium detonationMedium_0, Warhead.WarheadType warheadType_0, float float_0, bool bool_0)
	{
		try
		{
			if (_RecordClient != null)
			{
				_RecordClient.ResolveDamageFromBlast(ExpYield, WarheadType);
			}
			int num = 0;
			switch (detonationMedium_0)
			{
			case Weapon.DetonationMedium.Air:
				num = 661;
				break;
			case Weapon.DetonationMedium.Underwater:
				num = 2916;
				break;
			case Weapon.DetonationMedium.Underground:
				num = 5832;
				break;
			}
			double Local_BlastRing_OuterRim = m_PredicateClient / 3600.0 * (double)num;
			double Local_BlastRing_InnerRim = (m_PredicateClient - (double)float_0) / 3600.0 * (double)num;
			float cutoffRange_Blast_nm = GetCutoffRange_Blast_nm(ExpYield, detonationMedium_0);
			if (Local_BlastRing_OuterRim > (double)cutoffRange_Blast_nm)
			{
				Local_BlastRing_OuterRim = cutoffRange_Blast_nm;
			}
			TList<ActiveUnit> Local_AffectedUnits = new TList<ActiveUnit>();
			Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), delegate(ActiveUnit theAU)
			{
				if (theAU != null && Operators.CompareString(string_0, theAU.ObjectID, TextCompare: false) != 0)
				{
					if (Module_ActiveUnit.CancelTokenizer(theAU))
					{
						float num12 = Module_Unit.RangeToUnit_Slant(this, theAU);
						double num13 = (double)num12 + (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957;
						if ((double)num12 + (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= Local_BlastRing_OuterRim && num13 >= Local_BlastRing_InnerRim && Module_Unit.Has_Visual_LOS_ToUnit(this, null, theAU, ref scenario_0, bool_0: false) == LOSCheckResult.Success)
						{
							Local_AffectedUnits.Add(theAU);
						}
					}
					else if (theAU.IsOperating() && !theAU.IsGroup && (!theAU.IsWeapon || ((warheadType_0 == Warhead.WarheadType.Nuclear || (detonationMedium_0 == Weapon.DetonationMedium.Underwater && ExplosiveType == Warhead.WarheadExplosivesType.Nuclear)) && ((Weapon)theAU).CanBeDestroyedByNuke)) && (!theAU.IsAircraft || WarheadType != Warhead.WarheadType.HE_BlastFrag) && (!theAU.IsFacility || (((Facility)theAU).Category != Facility._FacilityCategory.Building_Underground && ((Facility)theAU).Category != Facility._FacilityCategory.SurfaceAndUnderground)) && theAU != _ExceptionClient && RevertRepository(theAU, detonationMedium_0))
					{
						double num14 = Module_Unit.RangeToUnit_Slant(this, theAU);
						if (Local_BlastRing_InnerRim <= num14 && num14 <= Local_BlastRing_OuterRim && (!Module_Unit.ResetTokenizer(this) || Module_Unit.Has_Visual_LOS_ToUnit(this, null, theAU, ref scenario_0, bool_0: false) == LOSCheckResult.Success))
						{
							Local_AffectedUnits.Add(theAU);
						}
					}
				}
			});
			IEnumerator enumerator = null;
			try
			{
				enumerator = Local_AffectedUnits.GetEnumerator();
				double double_ = 0.0;
				double double_2 = 0.0;
				while (enumerator.MoveNext())
				{
					ActiveUnit activeUnit = (ActiveUnit)enumerator.Current;
					float num4 = Math2.VerifyClass(GetLatitude(), GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetLongitude());
					float num5 = ((Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude()) == 0f) ? num4 : MathFunctions.SlantRange_NM_SR(num4, Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude())));
					if (activeUnit.IsFacility)
					{
						if (((Facility)activeUnit).HasAimpoints)
						{
							if (!Information.IsNothing(_RecordClient))
							{
								_RecordClient.ResolveDamageFromBlast(ExpYield, WarheadType);
							}
							foreach (Mount item in activeUnit.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != _RecordClient && theM != attrClient))
							{
								Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_, ref double_2, item.AimpointOffset_Distance / 1852f, item.AimpointOffset_Bearing);
								double num6 = Math2.VerifyClass(GetLatitude(), GetLongitude(), double_2, double_);
								double num7 = ((Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude()) == 0f) ? num6 : ((double)MathFunctions.SlantRange_NM_SR((float)num6, Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude()))));
								if (num7 <= (double)cutoffRange_Blast_nm)
								{
									double num8 = Warhead.BlastDamageAtThisDistance(double_2, double_, num7, item.DP, WarheadType, ExpYield, detonationMedium_0, bool_0, scenario_0);
									if (num8 > 0.0)
									{
										item.ResolveDamageFromBlast(num8, WarheadType);
									}
								}
							}
						}
						else
						{
							float float_ = Warhead.BlastDamageAtThisDistance(activeUnit.GetLatitude(), activeUnit.GetLongitude(), num5, activeUnit.InitialDP, WarheadType, ExpYield, detonationMedium_0, bool_0, scenario_0);
							activeUnit.Damage.ResolveDamageFromBlast(float_, WarheadType, ExplosiveType, detonationMedium_0);
						}
						continue;
					}
					if (activeUnit.IsWeapon)
					{
						activeUnit.AddMessage(activeUnit.Name + "被爆炸摧毁了！", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
						activeUnit.ParentScen.DestroyThisUnit(activeUnit, "destroyed by blast!", "Weapon Interaction");
						continue;
					}
					if (detonationMedium_0 == Weapon.DetonationMedium.Underwater)
					{
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							activeUnit.AddMessage(activeUnit.Name + "被水下爆炸击中了，深度" + Conversions.ToString((int)Math.Round((double)num5 * 1852.0 * 3.2808399200439453)) + " 英尺！", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
						}
						else
						{
							activeUnit.AddMessage(activeUnit.Name + "被水下爆炸击中了，深度" + Conversions.ToString((int)Math.Round((double)num5 * 1852.0)) + " 米！", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
						}
					}
					float num2;
					if (detonationMedium_0 == Weapon.DetonationMedium.Underwater)
					{
						double val = Math2.FillClass(Module_Unit.BearingToPoint_Relative(activeUnit, GetLatitude(), GetLongitude()));
						double val2 = Math2.SetClass(Module_Unit.GrazingAngleToPoint(activeUnit, GetLatitude(), GetLongitude(), GetCurrentAltitude()));
						double num9 = Math.Max(val, val2);
						double d = ExpYield * 2.20462;
						double num10 = (double)num5 * 1852.0 * 3.2808399200439453;
						double num11 = Math.Sqrt(d) * (1.0 + num9) / (num10 * 2.0);
						num2 = ((num11 < 0.1) ? ((float)((double)activeUnit.InitialDP * ((double)GameGeneral.LockRandom_0.Next(5, 16) / 100.0))) : ((num11 < 0.15) ? ((float)((double)activeUnit.InitialDP * ((double)GameGeneral.LockRandom_0.Next(15, 36) / 100.0))) : ((num11 < 0.2) ? ((float)((double)activeUnit.InitialDP * ((double)GameGeneral.LockRandom_0.Next(35, 56) / 100.0))) : ((num11 < 0.5) ? ((float)((double)activeUnit.InitialDP * ((double)GameGeneral.LockRandom_0.Next(55, 76) / 100.0))) : ((num11 < 0.6) ? ((float)((double)activeUnit.InitialDP * ((double)GameGeneral.LockRandom_0.Next(75, 96) / 100.0))) : ((num11 < 0.7) ? ((float)((double)activeUnit.InitialDP * ((double)GameGeneral.LockRandom_0.Next(95, 116) / 100.0))) : ((float)((double)activeUnit.InitialDP * ((double)GameGeneral.LockRandom_0.Next(115, 136) / 100.0)))))))));
					}
					else
					{
						num2 = Warhead.BlastDamageAtThisDistance(activeUnit.GetLatitude(), activeUnit.GetLongitude(), num5, activeUnit.InitialDP, WarheadType, ExpYield, detonationMedium_0, bool_0, scenario_0);
					}
					if (detonationMedium_0 == Weapon.DetonationMedium.Underground)
					{
						float num3 = Math.Abs((float)Math2.FillClass(Module_Unit.BearingToPoint_Relative(activeUnit, GetLatitude(), GetLongitude())));
						num2 = (float)((double)num2 * (0.2 + 0.8 * (double)num3));
					}
					activeUnit.Damage.ResolveDamageFromBlast(num2, WarheadType, ExplosiveType, detonationMedium_0);
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100847", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal float ConnectBridge(GlobalVariables.ArmorRating armorRating_0, float float_0)
	{
		if (armorRating_0 == GlobalVariables.ArmorRating.None)
		{
			return 100f;
		}
		short num = 0;
		switch (armorRating_0)
		{
		case GlobalVariables.ArmorRating.Light:
			return 90f;
		case GlobalVariables.ArmorRating.Medium:
			return 80f;
		case GlobalVariables.ArmorRating.Heavy:
			num = 60;
			break;
		case GlobalVariables.ArmorRating.Special:
			num = 30;
			break;
		}
		int num2 = GameGeneral.LockRandom_0.Next(num - 15, num + 16);
		if (num2 <= 100)
		{
			if (num2 < 0)
			{
				return 0f;
			}
			return num2;
		}
		return 100f;
	}

	private void MoveBridge(ref Scenario scenario_0, string string_0, Weapon.DetonationMedium detonationMedium_0)
	{
		try
		{
			float num = ((WarheadType == Warhead.WarheadType.Nuclear) ? ((float)(1.0 * ExpYield) / 1000f) : ((float)(1.0 * ExpYield) / 1000f));
			switch (detonationMedium_0)
			{
			case Weapon.DetonationMedium.Surface:
				num = (float)((double)num * 0.05);
				break;
			case Weapon.DetonationMedium.Air:
				num = (float)((double)num * 0.01);
				break;
			}
			double double_ = 0.0;
			double double_2 = 0.0;
			double double_3 = 0.0;
			SelectBridge(num, ref double_2, ref double_3, ref double_, CurrentAltitude_AGL * 0.5f);
			double_2 /= 1852.0;
			double_3 /= 1852.0;
			if (CurrentAltitude_AGL > 0f)
			{
				double_3 *= 0.5;
			}
			float num4 = (float)(3.0 * double_3);
			float num5 = (float)(2.0 * double_3);
			float num6 = (float)(1.5 * double_3);
			float num7 = (float)(2.5 * double_3);
			float num8 = (float)(2.0 * double_3);
			float num9 = (float)(1.25 * double_3);
			foreach (ActiveUnit item in new List<ActiveUnit>(scenario_0.ActiveUnits_List))
			{
				if (item == null || !item.IsOperating() || item.IsGroup || !item.IsFacility || Operators.CompareString(string_0, item.ObjectID, TextCompare: false) == 0)
				{
					continue;
				}
				float num10 = Module_Unit.RangeToUnit_Slant(this, item);
				Facility._FacilityCategory category = ((Facility)item).Category;
				if (category != Facility._FacilityCategory.Building_Underground && category != Facility._FacilityCategory.SurfaceAndUnderground)
				{
					float num11 = 0.5f;
					num10 /= num11;
					float num2;
					if (((Facility)item).Armor_General <= GlobalVariables.ArmorRating.Medium)
					{
						if (!(num10 <= num7))
						{
							continue;
						}
						num2 = ((!(num7 <= num10) && !(num10 <= num8)) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.3)) : ((num8 <= num10 || num10 <= num9) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.8)) : ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.5))));
					}
					else
					{
						if (!(num10 <= num4))
						{
							continue;
						}
						num2 = ((!(num4 <= num10) && !(num10 <= num5)) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.3)) : ((num5 <= num10 || num10 <= num6) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.8)) : ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.5))));
					}
					item.Damage.ResolveDamageFromBlast((float)item.InitialDP * num2, WarheadType, ExplosiveType, Weapon.DetonationMedium.Underground);
					continue;
				}
				float num3;
				if (((Facility)item).Armor_General <= GlobalVariables.ArmorRating.Medium)
				{
					if (!(num10 <= num7))
					{
						continue;
					}
					num3 = ((!(num7 <= num10) && !(num10 <= num8)) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.3)) : ((num8 <= num10 || num10 <= num9) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.8)) : ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.5))));
				}
				else
				{
					if (!(num10 <= num4))
					{
						continue;
					}
					num3 = ((!(num4 <= num10) && !(num10 <= num5)) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.3)) : ((num5 <= num10 || num10 <= num6) ? ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.8)) : ((float)(GameGeneral.LockRandom_0.NextDouble() * 0.5))));
				}
				item.Damage.ResolveDamageFromBlast((float)item.InitialDP * num3, WarheadType, ExplosiveType, Weapon.DetonationMedium.Underground);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100848", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DeleteBridge(ref Scenario scenario_0, string string_0)
	{
		double Local_CraterRadius = 0.0;
		try
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			if (Module_Unit.ResetTokenizer(this))
			{
				SelectBridge(1.0 * ExpYield / 1000000.0, ref Local_CraterRadius, ref double_, ref double_2, CurrentAltitude_AGL);
			}
			else
			{
				SelectBridge(1.0 * ExpYield / 1000000.0, ref Local_CraterRadius, ref double_, ref double_2, GetCurrentAltitude());
			}
			if (Local_CraterRadius == 0.0)
			{
				return;
			}
			Local_CraterRadius /= 1852.0;
			TList<ActiveUnit> Local_InstaKillUnits = new TList<ActiveUnit>();
			Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), delegate(ActiveUnit theAU)
			{
				if (theAU.IsOperating() && !theAU.IsGroup)
				{
					if ((double)Module_Unit.RangeToPoint_Slant(this, new GeoPoint(theAU.GetLongitude(), theAU.GetLatitude(), theAU.GetCurrentAltitude())) <= Local_CraterRadius)
					{
						if (Operators.CompareString(string_0, theAU.ObjectID, TextCompare: false) != 0)
						{
							Local_InstaKillUnits.Add(theAU);
						}
					}
					else if (GetCurrentAltitude() < 0f && theAU.GetCurrentAltitude() > GetCurrentAltitude() && theAU.GetCurrentAltitude() < 2000f && (double)Module_Unit.RangeToPoint_Horiz(this, theAU.GetLatitude(), theAU.GetLongitude()) <= Local_CraterRadius * 2.0 && Operators.CompareString(string_0, theAU.ObjectID, TextCompare: false) != 0)
					{
						Local_InstaKillUnits.Add(theAU);
					}
				}
			});
			IEnumerator enumerator = null;
			try
			{
				enumerator = Local_InstaKillUnits.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ActiveUnit activeUnit_ = (ActiveUnit)enumerator.Current;
					scenario_0.DestroyThisUnit(activeUnit_, "Engulfed in nuclear fireball.", "Weapon Interaction");
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100849", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AddBridge(ref Scenario scenario_0, string string_0)
	{
		try
		{
			if (GetCurrentAltitude() < 0f || !(CurrentAltitude_AGL >= 0f))
			{
				return;
			}
			double Local_EffectRadius = 1.0;
			TList<ActiveUnit> Local_InstaKillUnits = new TList<ActiveUnit>();
			Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), delegate(ActiveUnit theAU)
			{
				if (theAU != null && theAU.IsOperating() && !theAU.IsGroup && theAU.GetCurrentAltitude() >= 0f && theAU.CurrentAltitude_AGL >= 0f && (double)Module_Unit.RangeToPoint_Slant(this, new GeoPoint(theAU.GetLongitude(), theAU.GetLatitude(), theAU.GetCurrentAltitude())) <= Local_EffectRadius && Operators.CompareString(string_0, theAU.ObjectID, TextCompare: false) != 0)
				{
					Local_InstaKillUnits.Add(theAU);
				}
			});
			IEnumerator enumerator = null;
			try
			{
				enumerator = Local_InstaKillUnits.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ActiveUnit activeUnit_ = (ActiveUnit)enumerator.Current;
					scenario_0.DestroyThisUnit(activeUnit_, "Utterly disabled by short-range neutron wave.", "Weapon Interaction");
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100849", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public Geopoint_Struct[] GetClusterFallBox(float float_0)
	{
		try
		{
			float float_ = (float)ClusterCoverageLength * float_0;
			float float_2 = (float)ClusterCoverageWidth * float_0;
			return Math2.GetRectangularArea(GetLatitude(), GetLongitude(), float_, float_2, CurrentHeading);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100850", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private void DestroyBridge(Scenario scenario_0, string string_0)
	{
		try
		{
			Geopoint_Struct[] Local_theArea = GetClusterFallBox(1f);
			int num = ClusterCoverageLength * ClusterCoverageWidth;
			TList<ActiveUnit> Local_AffectedUnits = new TList<ActiveUnit>();
			Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), delegate(ActiveUnit theAU)
			{
				if (Module_ActiveUnit.CancelTokenizer(theAU))
				{
					Local_AffectedUnits.Add(theAU);
				}
				else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU.IsOperating() && theAU.GetIsInsideThisArea(Local_theArea, scenario_0, bool_0: false) && Operators.CompareString(string_0, theAU.ObjectID, TextCompare: false) != 0)
				{
					Local_AffectedUnits.Add(theAU);
				}
			});
			IEnumerator enumerator = null;
			try
			{
				enumerator = Local_AffectedUnits.GetEnumerator();
				double double_ = 0.0;
				double double_2 = 0.0;
				while (enumerator.MoveNext())
				{
					ActiveUnit activeUnit = (ActiveUnit)enumerator.Current;
					if (activeUnit.IsFacility && ((Facility)activeUnit).HasAimpoints)
					{
						List<Mount> list = new List<Mount>();
						foreach (Mount item in activeUnit.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed))
						{
							Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_, ref double_2, item.AimpointOffset_Distance / 1852f, item.AimpointOffset_Bearing);
							if (GeoPoint.IsInsideThisArea(double_2, double_, Local_theArea))
							{
								list.Add(item);
							}
						}
						foreach (Mount item2 in list)
						{
							double double_3 = Warhead.BombletDamageAtThisAimpoint(item2, ExpYield, ClusterSubmunitionQty, ClusterSubmunitionYield, num, WarheadType, ExplosiveType);
							item2.ResolveDamageFromBomblets(double_3, WarheadType, ClusterCoverageLength);
						}
					}
					else
					{
						double num2 = Warhead.BombletDamageAtThisTarget((Platform)activeUnit, ExpYield, num, CurrentHeading);
						activeUnit.Damage.ResolveDamageFromBomblets((float)num2, WarheadType, ExplosiveType, ClusterCoverageLength);
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100851", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static float GetCutoffRange_Blast_nm(double double_0, Weapon.DetonationMedium detonationMedium_0)
	{
		double d = double_0 * 1.0;
		double num = Math.Exp(0.3315 * Math.Log(d) + 2.9034);
		switch (detonationMedium_0)
		{
		default:
			throw new NotImplementedException();
		case Weapon.DetonationMedium.Air:
		case Weapon.DetonationMedium.Surface:
			return (float)(num / 1852.0);
		case Weapon.DetonationMedium.Underwater:
			return (float)(num * 4.4114977307110435 / 1852.0);
		case Weapon.DetonationMedium.Underground:
			return (float)(num * 8.822995461422087 / 1852.0);
		case Weapon.DetonationMedium.Space:
			return 0f;
		}
	}

	public static float GetCutoffRange_Frag_nm(double double_0, Weapon.DetonationMedium detonationMedium_0)
	{
		if (1 == 0)
		{
		}
		double num = detonationMedium_0 switch
		{
			Weapon.DetonationMedium.Space => 10.0 * double_0, 
			Weapon.DetonationMedium.Air => 10.0 * Math.Pow(double_0, 1.0 / 3.0), 
			_ => 0.0, 
		};
		if (1 == 0)
		{
		}
		return (float)(num / 1852.0);
	}

	private double ComputeBridge(double double_0, double double_1)
	{
		if (double_1 < 5.0 && double_1 > -3.0)
		{
			double num;
			double num2;
			double num3;
			double num4;
			double num5;
			double num6;
			if (double_1 < 0.0)
			{
				if (double_0 <= 1.0)
				{
					num = 0.258;
					num2 = 0.01;
					num3 = 0.1;
					num4 = 1.9;
					num5 = 16989.0;
					num6 = 5.0;
				}
				else
				{
					if (double_0 < 20.0)
					{
						goto IL_0242;
					}
					num = 0.53;
					num2 = 0.028;
					num3 = -1.0 / 46.0;
					num4 = 1.74;
					num5 = 5663.0;
					num6 = 5.0;
				}
			}
			else if (double_0 <= 1.0)
			{
				num = -1.05;
				num2 = -0.105;
				num3 = 0.0573;
				num4 = -0.5;
				num5 = 16989.0;
				num6 = 5.0;
			}
			else
			{
				if (double_0 < 20.0)
				{
					goto IL_0242;
				}
				num = -2.0;
				num2 = -0.3044;
				num3 = 0.0707;
				num4 = -0.9059;
				num5 = 5663.0;
				num6 = 5.0;
			}
			return num5 / num6 * Math.Pow(10.0, num4 * (Math.Exp(num * double_1 + num2 * double_1 * double_1) - 1.0) + num3 * double_1);
		}
		if (double_1 >= 5.0 && double_1 <= 40.0)
		{
			double num7 = 0.131;
			double num8 = -0.00231;
			double num9 = 0.0;
			return Math.Exp(9.34 + num7 * double_1 + num8 * double_1 * double_1) - num9;
		}
		goto IL_0242;
		IL_0242:
		return 0.0;
	}

	private bool PatchBridge(double double_0, double double_1)
	{
		double num = Math.Pow(double_0, 1.0 / 3.0);
		return double_1 < 3.0 * num;
	}

	private void SelectBridge(double double_0, ref double double_1, ref double double_2, ref double double_3, double double_4 = 0.0)
	{
		try
		{
			double num = 1.0 / 3.0;
			double num2 = 0.29411764705882354;
			if (!(double_0 >= 0.1) || !(double_0 <= 30000.0))
			{
				return;
			}
			double num3 = Math.Pow(double_0, 1.0 / 3.0);
			if (double_4 >= -40.0 * num3 && double_4 <= 3.0 * num3)
			{
				double num4 = (0.0 - double_4) / num3;
				num = ((num4 < 0.15) ? (1.0 / 3.0) : ((num4 < 5.0) ? (0.2946 * Math.Exp((0.0 - num4) * Math.Log10(583.0)) / Math.Sqrt(305.0)) : 0.29411764705882354));
				double x;
				if (double_0 < 1.0)
				{
					double num5 = num;
					double double_5 = (0.0 - double_4) / Math.Pow(double_0, num5);
					x = ComputeBridge(double_0, double_5) * Math.Pow(double_0, 3.0 * num5);
				}
				else if (double_0 <= 20.0)
				{
					double num6 = 1.0 - Math.Min(1.0, Math.Max(0.0, Math.Log(double_0) / Math.Log(20.0)));
					double y = 3.0 * (num2 + num6 * (num - num2));
					double num7 = ComputeBridge(1.0, 0.0 - double_4);
					double num8 = ComputeBridge(20.0, (0.0 - double_4) / Math.Pow(20.0, y));
					x = ((num8 == 0.0) ? 0.0 : (num8 * Math.Pow(num7 / num8, num6) * Math.Pow(double_0, y)));
				}
				else
				{
					double num9 = num2;
					double double_6 = (0.0 - double_4) / Math.Pow(double_0, num9);
					x = ComputeBridge(double_0, double_6) * Math.Pow(double_0, 3.0 * num9);
				}
				double_2 = 1.2 * Math.Pow(x, 1.0 / 3.0);
				double_1 = 1.8 * double_2;
				double_3 = 0.5 * Math.Pow(x, 1.0 / 3.0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			double_1 = 0.0;
			double_3 = 0.0;
			exception_?.Data.Add("Error at 200041", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal float CallBridge(double double_0)
	{
		if (GetCurrentAltitude() <= 12000f)
		{
			return GetCutoffRange_Blast_nm(double_0, Weapon.DetonationMedium.Air);
		}
		return GetCutoffRange_Blast_nm(double_0, Weapon.DetonationMedium.Air) * GetCurrentAltitude() / 12000f;
	}

	private void LogoutBridge(Scenario scenario_0)
	{
		try
		{
			float num = CallBridge(ExpYield);
			TList<ActiveUnit> tList = new TList<ActiveUnit>();
			foreach (ActiveUnit item in new List<ActiveUnit>(scenario_0.ActiveUnits_List))
			{
				if (item != null && (item.IsOperating() || (item.HasSystemsRunning && item.IsHostedInExposedSpace())) && !item.IsGroup && !item.IsWeapon && (!item.IsFacility || (((Facility)item).Category != Facility._FacilityCategory.Building_Underground && ((Facility)item).Category != Facility._FacilityCategory.SurfaceAndUnderground)) && item.GetCurrentAltitude() >= 0f && (double)Module_Unit.RangeToUnit_Slant(this, item) < (double)num)
				{
					tList.Add(item);
				}
			}
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = tList.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ActiveUnit activeUnit = (ActiveUnit)enumerator2.Current;
					float float_ = Math2.VerifyClass(GetLatitude(), GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetLongitude());
					if (Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude()) != 0f)
					{
						MathFunctions.SlantRange_NM_SR(float_, Math.Abs(GetCurrentAltitude() - activeUnit.GetCurrentAltitude()));
					}
					if (Module_Unit.Has_Radar_LOS_ToUnit(this, null, activeUnit, ref scenario_0))
					{
						float float_2 = (float)Math.Pow(1f - Module_Unit.RangeToUnit_Slant(this, activeUnit) / num, 2.0);
						activeUnit.Damage.method_0(float_2);
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 192758436", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportExplosionEvent(Explosion explosion_0, Scenario scenario_0)
	{
		foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
		{
			if (applicableEventExporter.IsOperating && applicableEventExporter.ExportExplosions)
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
				dictionary.Add("ExplosionID", new IEventExporter.EventNotificationParameter(explosion_0.ObjectID, typeof(string), 40));
				dictionary.Add("ExplosionType", new IEventExporter.EventNotificationParameter((int)explosion_0.WarheadType, typeof(int)));
				dictionary.Add("Longitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(explosion_0.GetLongitude()), typeof(double)));
				dictionary.Add("Latitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(explosion_0.GetLatitude()), typeof(double)));
				dictionary.Add("Altitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(explosion_0.GetCurrentAltitude()), typeof(float)));
				dictionary.Add("EventType", new IEventExporter.EventNotificationParameter("Explosion", typeof(string), 40));
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.Explosion, dictionary, scenario_0);
			}
		}
		ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
		for (int i = 0; i < activeSimConnectors.Length; i = checked(i + 1))
		{
			if (activeSimConnectors[i].ExportWeaponImpactOrDetonation)
			{
				Dictionary<string, Tuple<Type, string>> dictionary2 = new Dictionary<string, Tuple<Type, string>>();
				dictionary2.Add("TimelineID", new Tuple<Type, string>(typeof(string), scenario_0.TimelineID));
				dictionary2.Add("Time", new Tuple<Type, string>(typeof(DateTime), scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3")));
				dictionary2.Add("Longitude", new Tuple<Type, string>(typeof(double), Conversions.ToString(explosion_0.GetLongitude())));
				dictionary2.Add("Latitude", new Tuple<Type, string>(typeof(double), Conversions.ToString(explosion_0.GetLatitude())));
				dictionary2.Add("Altitude", new Tuple<Type, string>(typeof(float), Conversions.ToString(explosion_0.GetCurrentAltitude())));
				dictionary2.Add("ExplosionID", new Tuple<Type, string>(typeof(string), explosion_0.ObjectID));
				dictionary2.Add("ExplosionType", new Tuple<Type, string>(typeof(int), Conversions.ToString((int)explosion_0.WarheadType)));
				dictionary2.Add("EventType", new Tuple<Type, string>(typeof(string), "Explosion"));
			}
		}
	}
}
