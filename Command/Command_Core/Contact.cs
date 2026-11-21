using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using CSMaterial.ClipperLib;
using Command_Core.DAL;
using DotSpatial.Topology;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Contact : Contact_Base
{
	public delegate void BDA_ChangedEventHandler(Contact theC);

	public enum BDA_StructuralIntegrityLevel : byte
	{
		Undamaged,
		LightDamage,
		MediumDamage,
		HeavyDamage,
		Destroyed
	}

	public sealed class HostedUnitReconRecord
	{
		public string UnitID;

		public IdentificationStatus IDStatus;

		public float ReconAge;

		public string ToXML()
		{
			string result = null;
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Clear();
				stringBuilder.Append("<HURR>");
				stringBuilder.Append("<UID>").Append(UnitID).Append("</UID>");
				stringBuilder.Append("<IDS>").Append(Conversions.ToString((int)IDStatus)).Append("</IDS>");
				stringBuilder.Append("<RA>").Append(XmlConvert.ToString(ReconAge)).Append("</RA>");
				stringBuilder.Append("</HURR>");
				result = stringBuilder.ToString();
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101312340958903458932993", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public void ToXML(ref XmlWriter xmlWriter_0)
		{
			try
			{
				xmlWriter_0.WriteStartElement("HURR");
				xmlWriter_0.WriteElementString("UID", UnitID);
				xmlWriter_0.WriteElementString("IDS", Conversions.ToString((int)IDStatus));
				xmlWriter_0.WriteElementString("RA", XmlConvert.ToString(ReconAge));
				xmlWriter_0.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101313", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static HostedUnitReconRecord FromXML(XmlNode xmlNode_0)
		{
			try
			{
				HostedUnitReconRecord hostedUnitReconRecord = new HostedUnitReconRecord();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						switch (xmlNode.Name)
						{
						case "UID":
							hostedUnitReconRecord.UnitID = xmlNode.InnerText;
							break;
						case "RA":
							hostedUnitReconRecord.ReconAge = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "IDS":
							hostedUnitReconRecord.IDStatus = (IdentificationStatus)Conversions.ToShort(xmlNode.InnerText);
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
				return hostedUnitReconRecord;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101314", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				HostedUnitReconRecord result = new HostedUnitReconRecord();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	private string _IdentifierObserver;

	public ActiveUnit ActualUnit;

	public string _ActualUnitID;

	private bool m_PrinterObserver;

	private bool parserObserver;

	private Dictionary<Side, Misc.PostureStance> _AlgoObserver;

	private Dictionary<string, Misc.PostureStance> databaseObserver;

	private Misc.PostureStance? m_InterceptorObserver;

	public bool RetreivedPostureOnThisPulse;

	public float TimeSinceDetection;

	public float TimeSinceBDA;

	public float TimeSinceRecon;

	public float TimeSinceESM_Identification;

	public bool IsFilteredOut;

	private Weapon[] messageObserver;

	public BDA_StructuralIntegrityLevel? BDA_StructuralIntegrity;

	public ActiveUnit_Damage.FireIntensityLevel? BDA_FireLevel;

	public ActiveUnit_Damage.FloodingIntensityLevel? BDA_FloodLevel;

	private List<HostedUnitReconRecord> productObserver;

	public bool SpeedIsKnown;

	public bool HeadingIsKnown;

	public bool AltitudeIsKnown;

	private List<Geopoint_Struct> annotationObserver;

	internal float m_IteratorObserver;

	internal float _InitializerObserver;

	public float Age;

	public float HeldFor;

	private bool m_RoleObserver;

	public float RemainingContinousTrackTime;

	public float RemainingContinousTrackTime_Precise;

	public Queue<(string DetectorUnitID, string DetectingSensorID, float RangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode theDetectionMode, DateTime theTime)> LastDetections;

	[AccessedThroughProperty("_DetectedEmissions")]
	[CompilerGenerated]
	private ObservableDictionary<int, EmissionContainer> factoryObserver;

	public ObservableDictionary<int, EmissionContainer> _DetectedEmissionsPrevious;

	public List<int> ListOfESMMatches;

	private object attributeObserver;

	internal float? m_EventObserver;

	internal float? globalObserver;

	internal float? m_WorkerObserver;

	internal float? m_AccountObserver;

	internal float? stateObserver;

	internal float? authenticationObserver;

	internal bool m_ParamsObserver;

	public bool HasBeenCheckedForDestructionThisPulse;

	private bool infoObserver;

	internal bool _HelperObserver;

	internal TrajectoryPoint[] mapperObserver;

	[CompilerGenerated]
	private static BDA_ChangedEventHandler m_ManagerObserver;

	[ThreadStatic]
	private static StringBuilder m_GetterObserver;

	private float? producerObserver;

	private float? _ProcObserver;

	private float? m_StructIssuer;

	private float? merchantIssuer;

	private float? _CallbackIssuer;

	private IdentificationStatus decoratorIssuer;

	private float? processIssuer;

	private IdentificationStatus m_ThreadIssuer;

	private float? _RuleIssuer;

	private IdentificationStatus _CollectionIssuer;

	private bool? m_InstanceIssuer;

	private object _ObjectIssuer;

	private bool? parameterIssuer;

	private object m_ExpressionIssuer;

	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	public bool HasDetectedEmissions
	{
		get
		{
			if (UpdateImporter() == null)
			{
				return false;
			}
			return UpdateImporter().Count > 0;
		}
	}

	public ObservableDictionary<int, EmissionContainer> DetectedEmissions
	{
		get
		{
			if (UpdateImporter() == null)
			{
				InsertImporter(new ObservableDictionary<int, EmissionContainer>());
			}
			return UpdateImporter();
		}
		set
		{
			if (UpdateImporter() != null)
			{
				_DetectedEmissionsPrevious = UpdateImporter();
			}
			InsertImporter(value);
		}
	}

	public List<int> PossibleMatchesBasedOnEmissions
	{
		get
		{
			if (Information.IsNothing(ActualUnit))
			{
				return new List<int>();
			}
			GlobalVariables.ActiveUnitType activeUnitType_;
			switch (Type)
			{
			case ContactType.Air:
				activeUnitType_ = GlobalVariables.ActiveUnitType.Aircraft;
				break;
			case ContactType.Surface:
				activeUnitType_ = GlobalVariables.ActiveUnitType.Ship;
				break;
			case ContactType.Submarine:
				activeUnitType_ = GlobalVariables.ActiveUnitType.Submarine;
				break;
			default:
				return new List<int>();
			case ContactType.Orbital:
				activeUnitType_ = GlobalVariables.ActiveUnitType.Satellite;
				break;
			case ContactType.Facility_Fixed:
			case ContactType.Facility_Mobile:
				activeUnitType_ = GlobalVariables.ActiveUnitType.Facility;
				break;
			case ContactType.Missile:
			case ContactType.Torpedo:
				activeUnitType_ = GlobalVariables.ActiveUnitType.Weapon;
				break;
			}
			List<int> list = new List<int>();
			foreach (int key in DetectedEmissions.Keys)
			{
				if (DetectedEmissions[key].PreciseID)
				{
					list.Add(key);
				}
			}
			return DBFunctions.EW_GetAllUnitsMatchingTheseEmissions(list, activeUnitType_, ActualUnit.ParentScen, ActualUnit.ParentScen.DBConnection);
		}
	}

	public string DescriptionString
	{
		get
		{
			if (ActualUnit == null)
			{
				return "";
			}
			switch (IDStatus)
			{
			default:
				return "";
			case IdentificationStatus.Unknown:
				return "类型：未知";
			case IdentificationStatus.KnownDomain:
				switch (Type)
				{
				case ContactType.Air:
				case ContactType.Missile:
					return "类型：未知的空中目标";
				case ContactType.Surface:
					return "类型：未知的水面目标";
				case ContactType.Facility_Fixed:
					return "类型：未知的固定设施";
				case ContactType.Facility_Mobile:
					return "类型：未知的移动地面单元";
				case ContactType.Submarine:
				case ContactType.Torpedo:
					return "类型：未知的水下目标";
				default:
					return Type.ToString();
				case ContactType.Undetermined:
					return "类型：未确定";
				}
			case IdentificationStatus.KnownType:
				return "类型：" + ActualUnit.SubTypeDescription;
			case IdentificationStatus.KnownClass:
				return "类别：" + ActualUnit.UnitClass;
			case IdentificationStatus.PreciseID:
				return "识别为：" + ActualUnit.Name;
			}
		}
	}

	public bool IsClassifiedFalseTarget
	{
		get
		{
			if (IDStatus < IdentificationStatus.KnownType)
			{
				return false;
			}
			if (Information.IsNothing(ActualUnit))
			{
				return false;
			}
			if (Type == ContactType.Submarine && (uint)(((Submarine)ActualUnit).Type - 9001) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public Weapon[] IncomingGuidedWeapons
	{
		get
		{
			try
			{
				Weapon[] result = new Weapon[0];
				if (ActualUnit == null)
				{
					return result;
				}
				if (messageObserver == null)
				{
					messageObserver = CheckImporter();
				}
				return messageObserver;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				Weapon[] result2 = new Weapon[0];
				ProjectData.ClearProjectError();
				return result2;
			}
		}
	}

	public bool IsAir_Missile_Orbital_Contact
	{
		get
		{
			if (Type != 0 && Type != ContactType.Missile)
			{
				return Type == ContactType.Orbital;
			}
			return true;
		}
	}

	public bool IsAircraftContact => Type == ContactType.Air;

	public bool IsAir_GuidedWeapon_Contact
	{
		get
		{
			if (Type == ContactType.Air)
			{
				return true;
			}
			if (Type == ContactType.Missile && !IsBallisticTarget())
			{
				return true;
			}
			return false;
		}
	}

	public bool IsAir_Missile_Submarine_Contact
	{
		get
		{
			if (Type != 0 && Type != ContactType.Missile)
			{
				return Type == ContactType.Submarine;
			}
			return true;
		}
	}

	public bool IsGroundContact
	{
		get
		{
			if (Type == ContactType.Facility_Fixed)
			{
				return true;
			}
			return Type == ContactType.Facility_Mobile;
		}
	}

	public bool IsShipContact => Type == ContactType.Surface;

	public bool IsOrbitalContact => Type == ContactType.Orbital;

	public bool IsWeaponContact
	{
		get
		{
			ContactType type = Type;
			if (type != ContactType.Missile && (int)(type - 9) > 1)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsGuidedWeaponContact
	{
		get
		{
			if (Type == ContactType.Missile)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsBiological
	{
		get
		{
			if (ActualUnit == null)
			{
				return false;
			}
			if (Type == ContactType.Submarine && ((Submarine)ActualUnit).IsBiological)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsCivilian
	{
		get
		{
			if (ActualUnit == null)
			{
				return false;
			}
			if (ActualUnit.IsCivilian)
			{
				return true;
			}
			return false;
		}
	}

	public List<Geopoint_Struct> UncertaintyArea
	{
		get
		{
			return annotationObserver;
		}
		set
		{
			annotationObserver = value;
		}
	}

	public bool IsPreciselyLocatedOnThisPulse
	{
		get
		{
			return m_PrinterObserver;
		}
		set
		{
			if (value)
			{
				UncertaintyArea = null;
			}
			m_PrinterObserver = value;
		}
	}

	public bool ChangedToFirmOnThisPulse
	{
		get
		{
			return parserObserver;
		}
		set
		{
			parserObserver = value;
		}
	}

	public bool IsSinkingShip
	{
		get
		{
			if (ActualUnit != null && ActualUnit.IsShip)
			{
				return ((Ship)ActualUnit).IsSinking;
			}
			return false;
		}
	}

	public IdentificationStatus IDStatus => _IDStatus;

	public IdentificationStatus IDStatusBypassIdentification
	{
		set
		{
			_IDStatus = value;
			producerObserver = null;
			_ProcObserver = null;
			merchantIssuer = null;
		}
	}

	public bool IsConsideredManouverable
	{
		get
		{
			ContactType type = Type;
			if (type != ContactType.Missile && type != ContactType.Orbital && (int)(type - 9) > 1)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsDueToExpire
	{
		get
		{
			switch (Type)
			{
			case ContactType.Submarine:
				return Age > 21600f;
			case ContactType.Air:
			case ContactType.Missile:
			case ContactType.Orbital:
				return Age > 300f;
			default:
				return false;
			case ContactType.Surface:
			case ContactType.Facility_Mobile:
				return Age > 7200f;
			case ContactType.Torpedo:
				return Age > 600f;
			}
		}
	}

	public bool IsFirm
	{
		get
		{
			if (Information.IsNothing(UncertaintyArea))
			{
				if (Age <= 1f)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsSurfaceContact
	{
		get
		{
			ContactType type = Type;
			if (type != ContactType.Surface && (int)(type - 7) > 1 && type != ContactType.ActivationPoint)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsLandContact
	{
		get
		{
			ContactType type = Type;
			if (type != ContactType.Aimpoint && (int)(type - 7) > 1)
			{
				return false;
			}
			if (ActualUnit != null)
			{
				if (!ActualUnit.IsFacility)
				{
					return true;
				}
				if (((Facility)ActualUnit).Category == Facility._FacilityCategory.Water_Surface)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool IsSubmergedContact
	{
		get
		{
			ContactType type = Type;
			if (type != ContactType.Submarine && (int)(type - 9) > 1)
			{
				return false;
			}
			return true;
		}
	}

	public int AutoIncrement => _AutoIncrement;

	public static event BDA_ChangedEventHandler BDA_Changed
	{
		[CompilerGenerated]
		add
		{
			BDA_ChangedEventHandler bDA_ChangedEventHandler = m_ManagerObserver;
			BDA_ChangedEventHandler bDA_ChangedEventHandler2;
			do
			{
				bDA_ChangedEventHandler2 = bDA_ChangedEventHandler;
				BDA_ChangedEventHandler value2 = (BDA_ChangedEventHandler)Delegate.Combine(bDA_ChangedEventHandler2, value);
				bDA_ChangedEventHandler = Interlocked.CompareExchange(ref m_ManagerObserver, value2, bDA_ChangedEventHandler2);
			}
			while ((object)bDA_ChangedEventHandler != bDA_ChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			BDA_ChangedEventHandler bDA_ChangedEventHandler = m_ManagerObserver;
			BDA_ChangedEventHandler bDA_ChangedEventHandler2;
			do
			{
				bDA_ChangedEventHandler2 = bDA_ChangedEventHandler;
				BDA_ChangedEventHandler value2 = (BDA_ChangedEventHandler)Delegate.Remove(bDA_ChangedEventHandler2, value);
				bDA_ChangedEventHandler = Interlocked.CompareExchange(ref m_ManagerObserver, value2, bDA_ChangedEventHandler2);
			}
			while ((object)bDA_ChangedEventHandler != bDA_ChangedEventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ObservableDictionary<int, EmissionContainer> UpdateImporter()
	{
		return factoryObserver;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void InsertImporter(ObservableDictionary<int, EmissionContainer> observableDictionary_0)
	{
		INotifyDictionaryChanged<int, EmissionContainer>.DictionaryChangedEventHandler val = SetImporter;
		ObservableDictionary<int, EmissionContainer> val2 = factoryObserver;
		if (val2 != null)
		{
			val2.DictionaryChanged -= val;
		}
		factoryObserver = observableDictionary_0;
		val2 = factoryObserver;
		if (val2 != null)
		{
			val2.DictionaryChanged += val;
		}
	}

	internal int InvokeImporter()
	{
		try
		{
			Weapon[] incomingGuidedWeapons = IncomingGuidedWeapons;
			int num = 0;
			for (int i = 0; i < incomingGuidedWeapons.Length; i = checked(i + 1))
			{
				if (incomingGuidedWeapons[i].IsNuke.Value)
				{
					num++;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101097", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public void CombineContactData(Contact contact_0)
	{
		if (!SpeedIsKnown)
		{
			SpeedIsKnown = contact_0.SpeedIsKnown;
		}
		if (!AltitudeIsKnown)
		{
			AltitudeIsKnown = contact_0.AltitudeIsKnown;
		}
		if (!HeadingIsKnown)
		{
			HeadingIsKnown = contact_0.HeadingIsKnown;
		}
		if (!SideIsKnown)
		{
			SideIsKnown = contact_0.SideIsKnown;
		}
	}

	public string ToXML(HashSet<string> hashSet_0, Side side_0)
	{
		try
		{
			if (m_GetterObserver == null)
			{
				m_GetterObserver = new StringBuilder();
			}
			else
			{
				m_GetterObserver.Clear();
			}
			m_GetterObserver.Append("<Contact>");
			m_GetterObserver.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					m_GetterObserver.Append("</Contact>");
					return m_GetterObserver.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			m_GetterObserver.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			if (CurrentHeading != 0f)
			{
				m_GetterObserver.Append("<CH>").Append(XmlConvert.ToString(CurrentHeading)).Append("</CH>");
			}
			if (CurrentSpeed != 0f)
			{
				m_GetterObserver.Append("<CS>").Append(XmlConvert.ToString(CurrentSpeed)).Append("</CS>");
			}
			if (GetCurrentAltitude() != 0f)
			{
				m_GetterObserver.Append("<CA>").Append(XmlConvert.ToString(GetCurrentAltitude())).Append("</CA>");
			}
			m_GetterObserver.Append("<Lon>").Append(XmlConvert.ToString(GetLongitude())).Append("</Lon>");
			m_GetterObserver.Append("<Lat>").Append(XmlConvert.ToString(GetLatitude())).Append("</Lat>");
			if (!string.IsNullOrEmpty(UnitClass))
			{
				m_GetterObserver.Append("<UnitClass>").Append(UnitClass).Append("</UnitClass>");
			}
			if (_UnitSide != null)
			{
				m_GetterObserver.Append("<Side>").Append(SecurityElement.Escape(_UnitSide.Name)).Append("</Side>");
			}
			if (!string.IsNullOrEmpty(Message))
			{
				m_GetterObserver.Append("<Message>").Append(SecurityElement.Escape(Message)).Append("</Message>");
			}
			if (ActualUnit != null)
			{
				m_GetterObserver.Append("<ActualUnitID>").Append(ActualUnit.ObjectID).Append("</ActualUnitID>");
			}
			if (IsPreciselyLocatedOnThisPulse)
			{
				m_GetterObserver.Append("<IPLOTP>").Append("True").Append("</IPLOTP>");
			}
			if (RemainingContinousTrackTime != 0f)
			{
				m_GetterObserver.Append("<RCTT>").Append(XmlConvert.ToString(RemainingContinousTrackTime)).Append("</RCTT>");
			}
			if (RemainingContinousTrackTime_Precise != 0f)
			{
				m_GetterObserver.Append("<RCTTP>").Append(XmlConvert.ToString(RemainingContinousTrackTime_Precise)).Append("</RCTTP>");
			}
			StringBuilder stringBuilder = m_GetterObserver.Append("<IDStatus>");
			int iDStatus = (int)_IDStatus;
			stringBuilder.Append(iDStatus.ToString()).Append("</IDStatus>");
			if (TimeSinceDetection != 0f)
			{
				ActiveUnit actualUnit = ActualUnit;
				if (actualUnit != null && actualUnit.GetIsEligibleForAutodetection(side_0))
				{
					m_GetterObserver.Append("<TSD>").Append(TimeSinceDetection.ToString()).Append("</TSD>");
				}
			}
			if (TimeSinceBDA != 0f)
			{
				m_GetterObserver.Append("<TS_BDA>").Append(((int)Math.Round(TimeSinceBDA)).ToString()).Append("</TS_BDA>");
			}
			if (TimeSinceRecon != 0f)
			{
				m_GetterObserver.Append("<TS_Recon>").Append(((int)Math.Round(TimeSinceRecon)).ToString()).Append("</TS_Recon>");
			}
			if (SideIsKnown)
			{
				m_GetterObserver.Append("<SIK>").Append(SideIsKnown.ToString()).Append("</SIK>");
			}
			if (m_RoleObserver)
			{
				m_GetterObserver.Append("<ISS>").Append("True").Append("</ISS>");
			}
			if (_AlgoObserver.Count > 0)
			{
				m_GetterObserver.Append("<Stance>");
				foreach (KeyValuePair<Side, Misc.PostureStance> item2 in _AlgoObserver)
				{
					m_GetterObserver.Append("<Stance_").Append(item2.Key.ObjectID).Append(">")
						.Append(((int)item2.Value).ToString())
						.Append("</Stance_")
						.Append(item2.Key.ObjectID)
						.Append(">");
				}
				m_GetterObserver.Append("</Stance>");
			}
			if (!Information.IsNothing(Type))
			{
				StringBuilder stringBuilder2 = m_GetterObserver.Append("<Type>");
				iDStatus = (int)Type;
				stringBuilder2.Append(iDStatus.ToString()).Append("</Type>");
			}
			if (IsFilteredOut)
			{
				m_GetterObserver.Append("<IFO>").Append("True").Append("</IFO>");
			}
			if (BDA_StructuralIntegrity.HasValue)
			{
				m_GetterObserver.Append("<BDA_Struct>").Append(((byte)BDA_StructuralIntegrity.Value).ToString()).Append("</BDA_Struct>");
			}
			if (BDA_FireLevel.HasValue)
			{
				m_GetterObserver.Append("<BDA_Fire>").Append(((byte)BDA_FireLevel.Value).ToString()).Append("</BDA_Fire>");
			}
			if (BDA_FloodLevel.HasValue)
			{
				m_GetterObserver.Append("<BDA_Flood>").Append(((byte)BDA_FloodLevel.Value).ToString()).Append("</BDA_Flood>");
			}
			if (HeadingIsKnown)
			{
				m_GetterObserver.Append("<H_Known>").Append("True").Append("</H_Known>");
			}
			if (SpeedIsKnown)
			{
				m_GetterObserver.Append("<S_Known>").Append("True").Append("</S_Known>");
			}
			if (AltitudeIsKnown)
			{
				m_GetterObserver.Append("<A_Known>").Append("True").Append("</A_Known>");
			}
			if (annotationObserver != null)
			{
				m_GetterObserver.Append("<UA>");
				foreach (Geopoint_Struct item3 in annotationObserver)
				{
					m_GetterObserver.Append(item3.ToXML(hashSet_0));
				}
				m_GetterObserver.Append("</UA>");
			}
			if (Age != 0f)
			{
				m_GetterObserver.Append("<Age>").Append(XmlConvert.ToString(Age)).Append("</Age>");
			}
			if (HeldFor != 0f)
			{
				m_GetterObserver.Append("<HeldFor>").Append(XmlConvert.ToString(HeldFor)).Append("</HeldFor>");
			}
			m_GetterObserver.Append("<AInc>").Append(_AutoIncrement.ToString()).Append("</AInc>");
			if (!Information.IsNothing(OriginalDetectorSide))
			{
				m_GetterObserver.Append("<ODS>").Append(SecurityElement.Escape(OriginalDetectorSide.Name)).Append("</ODS>");
			}
			if (!Information.IsNothing(DetectedEmissions) && HasDetectedEmissions)
			{
				m_GetterObserver.Append("<DEm>");
				foreach (KeyValuePair<int, EmissionContainer> detectedEmission in DetectedEmissions)
				{
					if (detectedEmission.Value != null)
					{
						m_GetterObserver.Append("<Emission").Append(Conversions.ToString(detectedEmission.Key)).Append(">")
							.Append(detectedEmission.Value.ToString())
							.Append("</Emission")
							.Append(Conversions.ToString(detectedEmission.Key))
							.Append(">");
					}
				}
				m_GetterObserver.Append("</DEm>");
			}
			if (productObserver.Count > 0)
			{
				m_GetterObserver.Append("<RHU>");
				foreach (HostedUnitReconRecord item4 in productObserver)
				{
					m_GetterObserver.Append(item4.ToXML());
				}
				m_GetterObserver.Append("</RHU>");
			}
			if (m_EventObserver.HasValue)
			{
				m_GetterObserver.Append("<TSD_Radar>").Append(m_EventObserver.ToString()).Append("</TSD_Radar>");
			}
			if (globalObserver.HasValue)
			{
				m_GetterObserver.Append("<TSD_ESM>").Append(globalObserver.ToString()).Append("</TSD_ESM>");
			}
			if (m_WorkerObserver.HasValue)
			{
				m_GetterObserver.Append("<TSD_Visual>").Append(m_WorkerObserver.ToString()).Append("</TSD_Visual>");
			}
			if (m_AccountObserver.HasValue)
			{
				m_GetterObserver.Append("<TSD_Infrared>").Append(m_AccountObserver.ToString()).Append("</TSD_Infrared>");
			}
			if (stateObserver.HasValue)
			{
				m_GetterObserver.Append("<TSD_SonarActive>").Append(stateObserver.ToString()).Append("</TSD_SonarActive>");
			}
			if (authenticationObserver.HasValue)
			{
				m_GetterObserver.Append("<TSD_SonarPassive>").Append(authenticationObserver.ToString()).Append("</TSD_SonarPassive>");
			}
			if (LastDetections.Count > 0)
			{
				m_GetterObserver.Append("<LastDetections>");
				try
				{
					foreach (var lastDetection in LastDetections)
					{
						StringBuilder stringBuilder3 = m_GetterObserver.Append("<DET>").Append(lastDetection.DetectorUnitID).Append("_")
							.Append(lastDetection.DetectingSensorID)
							.Append("_")
							.Append(XmlConvert.ToString(lastDetection.RangeEstimate))
							.Append("_")
							.Append((int)lastDetection.theDetectionMode)
							.Append("_");
						DateTime item = lastDetection.theTime;
						stringBuilder3.Append(item.ToBinary().ToString()).Append("</DET>");
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				finally
				{
					m_GetterObserver.Append("</LastDetections>");
				}
			}
			if (m_ParamsObserver)
			{
				m_GetterObserver.Append("<SZC>True</SZC>");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1002134210938549324589328", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			m_GetterObserver.Append("</Contact>");
		}
		return m_GetterObserver.ToString();
	}

	public static Contact FromXML(string string_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			if (concurrentDictionary_0.ContainsKey(string_0))
			{
				return (Contact)concurrentDictionary_0[string_0];
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100478", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static Contact FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		Contact contact = new Contact();
		try
		{
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(innerText, ' '))
			{
				innerText = innerText.Replace(" ", "-");
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime) item = default((string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime));
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				IEnumerator enumerator6 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Name":
						contact.Name = xmlNode.InnerText;
						break;
					case "BDA_Fire":
						contact.BDA_FireLevel = (ActiveUnit_Damage.FireIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "H_Known":
						contact.HeadingIsKnown = true;
						break;
					case "Stance":
						try
						{
							enumerator5 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator5.Current;
								if (Operators.CompareString(xmlNode3.Name, "#text", TextCompare: false) == 0)
								{
									if (Versioned.IsNumeric(xmlNode.InnerText))
									{
										contact.m_InterceptorObserver = (Misc.PostureStance)Conversions.ToByte(xmlNode.InnerText);
									}
									else
									{
										contact.m_InterceptorObserver = (Misc.PostureStance)Enum.Parse(typeof(Misc.PostureStance), xmlNode.InnerText, ignoreCase: true);
									}
									continue;
								}
								string key = xmlNode3.Name.Split('_')[1];
								Misc.PostureStance value = (Misc.PostureStance)Conversions.ToByte(xmlNode3.InnerText);
								if (Information.IsNothing(contact.databaseObserver))
								{
									contact.databaseObserver = new Dictionary<string, Misc.PostureStance>();
								}
								contact.databaseObserver.Add(key, value);
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
					case "TSD_Visual":
					case "TimeSinceDetection_Visual":
						contact.m_WorkerObserver = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "RCTTP":
						contact.RemainingContinousTrackTime_Precise = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "TimeSinceDetection":
					case "TSD":
						try
						{
							contact.TimeSinceDetection = Conversions.ToSingle(xmlNode.InnerText);
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
						break;
					case "LastDetections":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator3.Current;
								try
								{
									string[] array = xmlNode2.InnerText.Split(Conversions.ToCharArrayRankOne("_"));
									item.Item1 = array[0];
									item.Item2 = array[1];
									item.Item3 = XmlConvert.ToSingle(array[2]);
									item.Item4 = (ActiveUnit_Sensory.SpecialDetectionMode)Conversions.ToInteger(array[3]);
									item.Item5 = DateTime.FromBinary(Conversions.ToLong(array[4]));
									contact.LastDetections.Enqueue(item);
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									ProjectData.ClearProjectError();
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
					case "SZC":
						contact.m_ParamsObserver = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "TS_BDA":
						contact.TimeSinceBDA = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "DEm":
					case "DetectedEmissions":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode4 = (XmlNode)enumerator2.Current;
								int num = Conversions.ToInteger(xmlNode4.Name.Remove(0, 8));
								if (!contact.DetectedEmissions.ContainsKey(num))
								{
									ObservableDictionary<int, EmissionContainer> detectedEmissions = contact.DetectedEmissions;
									string string_ = xmlNode4.InnerText;
									EmissionContainer emissionContainer = EmissionContainer.FromString(ref string_);
									xmlNode4.InnerText = string_;
									detectedEmissions.Add(num, emissionContainer);
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
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							if (xmlNode_0.ChildNodes.Count != 1)
							{
								contact.ObjectID_Set(xmlNode.InnerText);
								concurrentDictionary_0.TryAdd(contact.ObjectID, contact);
								break;
							}
							return null;
						}
						return (Contact)concurrentDictionary_0[xmlNode.InnerText];
					case "ActualUnitID":
						contact._ActualUnitID = xmlNode.InnerText;
						break;
					case "TimeSinceDetection_Radar":
					case "TSD_Radar":
						contact.m_EventObserver = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "UnitClass":
						contact.UnitClass = xmlNode.InnerText;
						break;
					case "IDStatus":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							contact._IDStatus = (IdentificationStatus)Conversions.ToShort(xmlNode.InnerText);
						}
						else
						{
							contact._IDStatus = (IdentificationStatus)Enum.Parse(typeof(IdentificationStatus), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "RHU":
						try
						{
							enumerator4 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								HostedUnitReconRecord item3 = HostedUnitReconRecord.FromXML((XmlNode)enumerator4.Current);
								contact.productObserver.Add(item3);
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
					case "CurrentAltitude":
					case "CA":
						contact.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "UA":
					case "UncertaintyArea":
						if (xmlNode.ChildNodes.Count <= 0)
						{
							break;
						}
						contact.UncertaintyArea = new List<Geopoint_Struct>();
						try
						{
							enumerator6 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator6.MoveNext())
							{
								Geopoint_Struct item2 = Geopoint_Struct.InsertInvocation((XmlNode)enumerator6.Current, concurrentDictionary_0);
								contact.UncertaintyArea.Add(item2);
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
					case "Age":
						contact.Age = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "Longitude":
					case "Lon":
						contact.SetLongitude(null, XmlConvert.ToDouble(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "A_Known":
						contact.AltitudeIsKnown = true;
						break;
					case "BDA_Struct":
						contact.BDA_StructuralIntegrity = (BDA_StructuralIntegrityLevel)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "Side":
						contact._IdentifierObserver = xmlNode.InnerText;
						break;
					case "TimeSinceDetection_SonarPassive":
					case "TSD_SonarPassive":
						contact.authenticationObserver = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "BDA_Flood":
						contact.BDA_FloodLevel = (ActiveUnit_Damage.FloodingIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "SIK":
					case "SideIsKnown":
						contact.SideIsKnown = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RCTT":
						contact.RemainingContinousTrackTime = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "S_Known":
						contact.SpeedIsKnown = true;
						break;
					case "TS_Recon":
						contact.TimeSinceRecon = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "TimeSinceDetection_ESM":
					case "TSD_ESM":
						contact.globalObserver = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Message":
						contact.Message = xmlNode.InnerText;
						break;
					case "TSD_SonarActive":
					case "TimeSinceDetection_SonarActive":
						contact.stateObserver = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Latitude":
					case "Lat":
						contact.SetLatitude(null, XmlConvert.ToDouble(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "CS":
					case "CurrentSpeed":
						contact.CurrentSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "IFO":
						contact.IsFilteredOut = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "InheritsSideStance":
					case "ISS":
						contact.m_RoleObserver = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AutoIncrement":
					case "AInc":
						contact._AutoIncrement = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Type":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							contact.Type = (ContactType)Conversions.ToByte(xmlNode.InnerText);
						}
						else
						{
							contact.Type = (ContactType)Enum.Parse(typeof(ContactType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "IPLOTP":
					case "IsPreciselyLocatedOnThisPulse":
						contact.IsPreciselyLocatedOnThisPulse = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ODS":
					case "OriginalDetectorSide":
						contact._OriginalDetectorSide_Name = xmlNode.InnerText;
						break;
					case "HeldFor":
						contact.HeldFor = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CH":
					case "CurrentHeading":
						contact.CurrentHeading = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "TimeSinceDetection_Infrared":
					case "TSD_Infrared":
						contact.m_AccountObserver = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
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
			return contact;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100479", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Contact result = new Contact();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal bool SetupImporter()
	{
		if ((Latitude_old != GetLatitude()) | (Longitude_old != GetLongitude()) | (base.Altitude_old != GetCurrentAltitude()))
		{
			return true;
		}
		return false;
	}

	public override void PrePulseHousekeeping(float float_0, Scenario scenario_0)
	{
		base.PrePulseHousekeeping(float_0, scenario_0);
		if (IsBallisticTarget() && mapperObserver.Length == 0 && _HelperObserver)
		{
			mapperObserver = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(this, scenario_0);
			_HelperObserver = false;
		}
		if (scenario_0.SecondIsChangingOnThisPulse)
		{
			messageObserver = null;
		}
		if (scenario_0.FifthMinuteIsChangingOnThisPulse)
		{
			RetreivedPostureOnThisPulse = false;
			scenario_0.WeaponFeedBackMessage.Clear();
		}
	}

	public void PostPulseHousekeeping(float float_0, Side side_0, Scenario scenario_0, bool bool_0)
	{
		try
		{
			if (UncertaintyArea != null)
			{
				for (int i = UncertaintyArea.Count - 1; i >= 0; i += -1)
				{
					Geopoint_Struct geopoint_Struct;
					try
					{
						geopoint_Struct = UncertaintyArea[i];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						continue;
					}
					if (double.IsNaN(geopoint_Struct.Latitude) || double.IsNaN(geopoint_Struct.Longitude))
					{
						UncertaintyArea.RemoveAt(i);
					}
				}
			}
			if (ActualUnit != null && ActualUnit.IsFixedFacility && UncertaintyArea == null && IDStatus < IdentificationStatus.PreciseID)
			{
				method_0(scenario_0, side_0, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, IdentificationStatus.PreciseID);
			}
			if (scenario_0.SecondIsChangingOnThisPulse)
			{
				GrowUncertaintyArea(float_0, side_0, scenario_0, bool_0);
			}
			if (RemainingContinousTrackTime > 0f && ActualUnit != null)
			{
				Age = 0f;
				base.Altitude_old = GetCurrentAltitude();
				if (side_0.Units.Count > 0 && !ActualUnit.GetIsAutoDetectable(side_0))
				{
					List<ActiveUnit> units = side_0.Units;
					ActiveUnit activeUnit_ = units[0];
					Contact contact_ = this;
					ActiveUnit_Sensory.UpdateContactData(ref activeUnit_, ref contact_, ActualUnit, bool_0: false);
					units[0] = activeUnit_;
				}
			}
			if (Age == 0f)
			{
				HeldFor += float_0;
			}
			messageObserver = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200641", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void GrowUncertaintyArea(float float_0, Side side_0, Scenario scenario_0, bool bool_0)
	{
		if (ActualUnit == null)
		{
			return;
		}
		if (ActualUnit.GetIsAutoDetectable(side_0) && !bool_0)
		{
			UncertaintyArea = null;
			return;
		}
		if (UncertaintyArea == null)
		{
			if (!IsPreciselyLocatedOnThisPulse & (RemainingContinousTrackTime <= 0f))
			{
				GrowUncertaintyArea_Clipper(1.0, ref scenario_0);
			}
			return;
		}
		_InitializerObserver = Misc.ExcludeRequest(_InitializerObserver, float_0, 1);
		if (_InitializerObserver <= 0f)
		{
			GrowUncertaintyArea_Clipper(m_IteratorObserver, ref scenario_0);
		}
		if (UncertaintyArea.Count == 0)
		{
			UncertaintyArea = null;
		}
	}

	public bool PostDeserializationHousekeeping(ref Scenario scenario_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Side side_0)
	{
		try
		{
			if (!string.IsNullOrEmpty(_ActualUnitID) && concurrentDictionary_0.ContainsKey(_ActualUnitID))
			{
				ActualUnit = (ActiveUnit)concurrentDictionary_0[_ActualUnitID];
				if (ActualUnit.isUAV)
				{
					Type = ContactType.Air;
					Name = Name.Replace("GuidedWeapon", "UAV");
				}
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (Operators.CompareString(side.Name, _IdentifierObserver, TextCompare: false) == 0)
					{
						_UnitSide = side;
					}
					if (Operators.CompareString(side.Name, _OriginalDetectorSide_Name, TextCompare: false) == 0)
					{
						OriginalDetectorSide = side;
					}
				}
				if (Information.IsNothing(m_InterceptorObserver))
				{
					if (!Information.IsNothing(databaseObserver) && databaseObserver.TryGetValue(side_0.ObjectID, out var value))
					{
						Side key = Side.FromXML_ByObjectID(side_0.ObjectID, ref concurrentDictionary_0);
						try
						{
							_AlgoObserver.Add(key, value);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
				}
				else
				{
					_AlgoObserver.Add(side_0, m_InterceptorObserver.Value);
				}
				databaseObserver = null;
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200023", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public Contact()
	{
		_AlgoObserver = new Dictionary<Side, Misc.PostureStance>();
		m_InterceptorObserver = null;
		TimeSinceDetection = 0f;
		TimeSinceBDA = 0f;
		TimeSinceRecon = 0f;
		TimeSinceESM_Identification = 0f;
		productObserver = new List<HostedUnitReconRecord>();
		m_RoleObserver = true;
		LastDetections = new Queue<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime)>();
		attributeObserver = RuntimeHelpers.GetObjectValue(new object());
		_HelperObserver = false;
		mapperObserver = new TrajectoryPoint[0];
		_ObjectIssuer = RuntimeHelpers.GetObjectValue(new object());
		m_ExpressionIssuer = RuntimeHelpers.GetObjectValue(new object());
		if (ActualUnit == null)
		{
			return;
		}
		Side[] sides_ReadOnly = ActualUnit.ParentScen.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (side != null)
			{
				List<Contact> contacts_List = side.Contacts_List;
				if (contacts_List != null && contacts_List.Contains(this))
				{
					_AlgoObserver.Add(side, Misc.PostureStance.Unknown);
				}
			}
		}
	}

	public static void IncreaseAge(Contact contact_0, Side side_0, float float_0, Scenario scenario_0)
	{
		Contact contact = contact_0;
		if (contact.OriginalDetectorSide != null)
		{
			if (Operators.CompareString(contact.OriginalDetectorSide.ObjectID, side_0.ObjectID, TextCompare: false) == 0)
			{
				if (contact.ActualUnit != null)
				{
					if (!contact.ActualUnit.GetIsAutoDetectable(side_0) && contact.RemainingContinousTrackTime <= 0f)
					{
						contact.Age = Misc.SetupRequest(contact.Age, float_0, 1);
					}
					if (contact.ActualUnit.GetIsAutoDetectable(side_0))
					{
						contact.TimeSinceBDA = Misc.SetupRequest(contact.TimeSinceBDA, float_0, 1);
					}
					if (contact.UpdateImporter() != null && contact.DetectedEmissions.Count > 0)
					{
						contact.TimeSinceESM_Identification = Misc.SetupRequest(contact.TimeSinceESM_Identification, float_0, 1);
					}
				}
				contact.RemainingContinousTrackTime = Misc.ExcludeRequest(contact.RemainingContinousTrackTime, float_0, 1);
				contact.RemainingContinousTrackTime_Precise = Misc.ExcludeRequest(contact.RemainingContinousTrackTime_Precise, float_0, 1);
				contact.TimeSinceDetection = Misc.SetupRequest(contact.TimeSinceDetection, float_0, 1);
				contact.TimeSinceRecon = Misc.SetupRequest(contact.TimeSinceRecon, float_0, 1);
				contact.ExcludeImporter(float_0);
				foreach (HostedUnitReconRecord item in contact.IncludeImporter(contact.OriginalDetectorSide))
				{
					item.ReconAge = Misc.SetupRequest(item.ReconAge, float_0, 1);
				}
			}
			else
			{
				contact.TimeSinceRecon = Misc.SetupRequest(contact.TimeSinceRecon, float_0, 1);
				contact.TimeSinceBDA = Misc.SetupRequest(contact.TimeSinceBDA, float_0, 1);
				contact.ExcludeImporter(float_0);
			}
		}
		contact = null;
	}

	private void ExcludeImporter(float float_0)
	{
		if (m_EventObserver.HasValue)
		{
			m_EventObserver = Misc.SetupRequest(m_EventObserver.Value, float_0, 1);
		}
		if (globalObserver.HasValue)
		{
			globalObserver = Misc.SetupRequest(globalObserver.Value, float_0, 1);
		}
		if (m_WorkerObserver.HasValue)
		{
			m_WorkerObserver = Misc.SetupRequest(m_WorkerObserver.Value, float_0, 1);
		}
		if (m_AccountObserver.HasValue)
		{
			m_AccountObserver = Misc.SetupRequest(m_AccountObserver.Value, float_0, 1);
		}
		if (stateObserver.HasValue)
		{
			stateObserver = Misc.SetupRequest(stateObserver.Value, float_0, 1);
		}
		if (authenticationObserver.HasValue)
		{
			authenticationObserver = Misc.SetupRequest(authenticationObserver.Value, float_0, 1);
		}
	}

	public void DetermineNextGrow(ref Scenario scenario_0)
	{
		if (Age < 60f)
		{
			_InitializerObserver = GameGeneral.LockRandom_0.Next(5, 16);
		}
		else if (Age < 300f)
		{
			_InitializerObserver = 60f;
		}
		else if (Age < 7200f)
		{
			_InitializerObserver = 300f;
		}
		else
		{
			_InitializerObserver = 3600f;
		}
		if (scenario_0.TimeCompression_SimSeconds > 0 && _InitializerObserver < (float)scenario_0.TimeCompression_SimSeconds)
		{
			_InitializerObserver = scenario_0.TimeCompression_SimSeconds;
			if (scenario_0.TimeCompression_SimSeconds < 5)
			{
				_InitializerObserver *= GameGeneral.LockRandom_0.Next(2, 6);
			}
		}
		m_IteratorObserver = _InitializerObserver;
	}

	internal List<HostedUnitReconRecord> IncludeImporter(Side side_0)
	{
		if (ActualUnit != null && side_0 != null && ActualUnit.IsGroup)
		{
			List<Contact> contacts_List = side_0.Contacts_List;
			Lazy<List<HostedUnitReconRecord>> lazy = new Lazy<List<HostedUnitReconRecord>>();
			foreach (Contact item in contacts_List)
			{
				if (item != null && item.ActualUnit != null && item.ActualUnit.IsGroupMember() && item.ActualUnit.GetParentGroup() == ActualUnit && item.IncludeImporter(side_0).Count > 0)
				{
					lazy.Value.AddRange(item.IncludeImporter(side_0));
				}
			}
			return lazy.Value;
		}
		return productObserver;
	}

	internal float? SearchImporter(GlobalVariables.ActiveUnitType activeUnitType_0)
	{
		float? result = null;
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Ship:
			result = MaxPotentialWeaponRange_ASuW_Naval().GetValueOrDefault();
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			result = MaxPotentialWeaponRange_ASW().GetValueOrDefault();
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			result = MaxPotentialWeaponRange_ASuW_Land().GetValueOrDefault();
			break;
		case GlobalVariables.ActiveUnitType.Aimpoint:
			result = null;
			break;
		case GlobalVariables.ActiveUnitType.Aircraft:
		case GlobalVariables.ActiveUnitType.Weapon:
			result = MaxPotentialWeaponRange_AAW().GetValueOrDefault();
			break;
		}
		return result;
	}

	internal float? EnableImporter(ContactType contactType_0)
	{
		float? result = null;
		switch (contactType_0)
		{
		case ContactType.Air:
		case ContactType.Missile:
			result = MaxPotentialWeaponRange_AAW().GetValueOrDefault();
			break;
		case ContactType.Surface:
			result = MaxPotentialWeaponRange_ASuW_Naval().GetValueOrDefault();
			break;
		case ContactType.Submarine:
			result = MaxPotentialWeaponRange_ASW().GetValueOrDefault();
			break;
		case ContactType.Aimpoint:
		case ContactType.ActivationPoint:
			result = null;
			break;
		case ContactType.Facility_Fixed:
		case ContactType.Facility_Mobile:
			result = MaxPotentialWeaponRange_ASuW_Land().GetValueOrDefault();
			break;
		}
		return result;
	}

	internal float ChangeImporter()
	{
		if (!IsBallisticTarget() && !IsOrbitalContact)
		{
			if (ActualUnit.IsAerospaceUnit)
			{
				double num = Physics.CompareStub(GetCurrentAltitude(), CurrentSpeed);
				return (float)(1.0 + num);
			}
			return 1.5f;
		}
		return 10f;
	}

	public float? MaxPotentialWeaponRange_AAW()
	{
		float? result = null;
		try
		{
			if (IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
				return result;
			}
			if (Information.IsNothing(ActualUnit))
			{
				result = null;
				return result;
			}
			if (!producerObserver.HasValue)
			{
				List<Weapon> list = new List<Weapon>();
				if (ActualUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
				{
					List<int>.Enumerator enumerator = default(List<int>.Enumerator);
					try
					{
						int dBID = ActualUnit.DBID;
						SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
						enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
						while (enumerator.MoveNext())
						{
							int current = enumerator.Current;
							Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
							if (weapon.IsAAW)
							{
								list.Add(weapon);
							}
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				else
				{
					list = (from theW in ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: false).Values.ToList()
						where theW.IsAAW
						select theW).ToList();
				}
				if (list.Count == 0)
				{
					producerObserver = 0f;
				}
				else
				{
					producerObserver = list.OrderByDescending((Weapon theW) => theW.MaxAirRange).ElementAtOrDefault(0).MaxAirRange;
				}
			}
			result = producerObserver;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100480", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public float? MaxPotentialWeaponRange_ASuW_Naval()
	{
		float? result = null;
		try
		{
			if (IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
				return result;
			}
			if (Information.IsNothing(ActualUnit))
			{
				result = null;
				return result;
			}
			if (!_ProcObserver.HasValue)
			{
				List<Weapon> list = new List<Weapon>();
				if (ActualUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
				{
					List<int>.Enumerator enumerator = default(List<int>.Enumerator);
					try
					{
						int dBID = ActualUnit.DBID;
						SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
						enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
						while (enumerator.MoveNext())
						{
							int current = enumerator.Current;
							Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
							if (weapon.IsASuW_Naval)
							{
								list.Add(weapon);
							}
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				else
				{
					list = (from theW in ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: false).Values.ToList()
						where theW.IsASuW_Naval
						select theW).ToList();
				}
				if (list.Count == 0)
				{
					_ProcObserver = 0f;
				}
				else
				{
					_ProcObserver = list.OrderByDescending((Weapon theW) => theW.MaxSurfaceRange).ElementAtOrDefault(0).MaxSurfaceRange;
				}
			}
			result = _ProcObserver;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100481", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public float? MaxPotentialWeaponRange_ASuW_Land()
	{
		float? result = null;
		try
		{
			if (IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
				return result;
			}
			if (Information.IsNothing(ActualUnit))
			{
				result = null;
				return result;
			}
			if (!m_StructIssuer.HasValue)
			{
				List<Weapon> list = new List<Weapon>();
				if (ActualUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
				{
					List<int>.Enumerator enumerator = default(List<int>.Enumerator);
					try
					{
						int dBID = ActualUnit.DBID;
						SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
						enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
						while (enumerator.MoveNext())
						{
							int current = enumerator.Current;
							Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
							if (weapon.IsASuW_Land)
							{
								list.Add(weapon);
							}
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				else
				{
					list = (from theW in ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: false).Values.ToList()
						where theW.IsASuW_Land
						select theW).ToList();
				}
				if (list.Count == 0)
				{
					m_StructIssuer = 0f;
				}
				else
				{
					m_StructIssuer = list.OrderByDescending((Weapon theW) => theW.MaxLandRange).ElementAtOrDefault(0).MaxLandRange;
				}
			}
			result = m_StructIssuer;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101215", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public float? MaxPotentialWeaponRange_ASW()
	{
		float? result = null;
		try
		{
			if (IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
				return result;
			}
			if (Information.IsNothing(ActualUnit))
			{
				result = null;
				return result;
			}
			if (!merchantIssuer.HasValue)
			{
				List<Weapon> list = new List<Weapon>();
				if (ActualUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
				{
					List<int>.Enumerator enumerator = default(List<int>.Enumerator);
					try
					{
						int dBID = ActualUnit.DBID;
						SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
						enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
						while (enumerator.MoveNext())
						{
							int current = enumerator.Current;
							Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
							if (weapon.IsASW)
							{
								list.Add(weapon);
							}
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				else
				{
					list = (from theW in ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: false).Values.ToList()
						where theW.IsASW
						select theW).ToList();
				}
				if (list.Count == 0)
				{
					merchantIssuer = 0f;
				}
				else
				{
					merchantIssuer = list.OrderByDescending((Weapon theW) => theW.MaxSubsurfaceRange).ElementAtOrDefault(0).MaxSubsurfaceRange;
				}
			}
			result = merchantIssuer;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100482", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public float? MaxPotentialActiveSensorRange_AAW()
	{
		if (ActualUnit == null)
		{
			return null;
		}
		try
		{
			if (!_CallbackIssuer.HasValue || decoratorIssuer != IDStatus)
			{
				decoratorIssuer = IDStatus;
				if (IDStatus < IdentificationStatus.KnownClass)
				{
					if (HasDetectedEmissions)
					{
						IEnumerable<Sensor> source;
						try
						{
							source = from theS in DetectedEmissions.Where(delegate(KeyValuePair<int, EmissionContainer> theKVP)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair4 = theKVP;
									return keyValuePair4.Value.PreciseID;
								}).Select(delegate(KeyValuePair<int, EmissionContainer> keyValuePair_0)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair3 = keyValuePair_0;
									EmissionContainer value2 = keyValuePair3.Value;
									keyValuePair3 = keyValuePair_0;
									return value2.GetAssociatedSensor(keyValuePair3.Key, ActualUnit.ParentScen);
								})
								where theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite)
								orderby theS.maxRange descending
								select theS;
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							source = from theS in DetectedEmissions.Where(delegate(KeyValuePair<int, EmissionContainer> theKVP)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair2 = theKVP;
									return keyValuePair2.Value.PreciseID;
								}).Select(delegate(KeyValuePair<int, EmissionContainer> keyValuePair_0)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
									EmissionContainer value = keyValuePair.Value;
									keyValuePair = keyValuePair_0;
									return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
								})
								where theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite)
								orderby theS.maxRange descending
								select theS;
							ProjectData.ClearProjectError();
						}
						if (source.Count() == 0)
						{
							_CallbackIssuer = 0f;
						}
						else
						{
							_CallbackIssuer = source.ElementAtOrDefault(0).maxRange;
						}
					}
					else
					{
						_CallbackIssuer = 0f;
					}
				}
				else
				{
					ActiveUnit_Sensory sensory = ActualUnit.Sensory;
					Sensor[] sensor_ = null;
					List<Sensor> list = sensory.ViewConsumer(bool_0: true, bool_1: false, bool_2: false, bool_3: false, ref sensor_);
					if (list.Count == 0)
					{
						_CallbackIssuer = 0f;
					}
					else
					{
						_CallbackIssuer = list[0].maxRange;
					}
				}
			}
			return _CallbackIssuer;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200547", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float? result = 0f;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public float? MaxPotentialActiveSensorRange_ASuW()
	{
		if (ActualUnit == null)
		{
			return null;
		}
		try
		{
			if (!processIssuer.HasValue || m_ThreadIssuer != IDStatus)
			{
				m_ThreadIssuer = IDStatus;
				if (IDStatus < IdentificationStatus.KnownClass)
				{
					if (HasDetectedEmissions)
					{
						List<Sensor> list;
						try
						{
							list = (from theS in DetectedEmissions.Where(delegate(KeyValuePair<int, EmissionContainer> theKVP)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair4 = theKVP;
									return keyValuePair4.Value.PreciseID;
								}).Select(delegate(KeyValuePair<int, EmissionContainer> keyValuePair_0)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair3 = keyValuePair_0;
									EmissionContainer value2 = keyValuePair3.Value;
									keyValuePair3 = keyValuePair_0;
									return value2.GetAssociatedSensor(keyValuePair3.Key, ActualUnit.ParentScen);
								})
								where theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility) || theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship)
								orderby theS.maxRange descending
								select theS).ToList();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							list = (from theS in DetectedEmissions.Where(delegate(KeyValuePair<int, EmissionContainer> theKVP)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair2 = theKVP;
									return keyValuePair2.Value.PreciseID;
								}).Select(delegate(KeyValuePair<int, EmissionContainer> keyValuePair_0)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
									EmissionContainer value = keyValuePair.Value;
									keyValuePair = keyValuePair_0;
									return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
								})
								where theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility) || theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship)
								orderby theS.maxRange descending
								select theS).ToList();
							ProjectData.ClearProjectError();
						}
						if (list.Count == 0)
						{
							processIssuer = 0f;
						}
						else
						{
							processIssuer = list[0].maxRange;
						}
					}
					else
					{
						processIssuer = 0f;
					}
				}
				else
				{
					ActiveUnit_Sensory sensory = ActualUnit.Sensory;
					Sensor[] sensor_ = null;
					List<Sensor> list2 = sensory.ValidateConsumer(bool_0: true, bool_1: false, bool_2: false, bool_3: false, ref sensor_);
					if (list2.Count == 0)
					{
						processIssuer = 0f;
					}
					else
					{
						processIssuer = list2[0].maxRange;
					}
				}
			}
			return processIssuer;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200548", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float? result = 0f;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public float? MaxPotentialActiveSensorRange_ASW()
	{
		if (ActualUnit == null)
		{
			return null;
		}
		float? result = null;
		try
		{
			if (!_RuleIssuer.HasValue || _CollectionIssuer != IDStatus)
			{
				_CollectionIssuer = IDStatus;
				if (IDStatus < IdentificationStatus.KnownClass)
				{
					if (HasDetectedEmissions)
					{
						IEnumerable<Sensor> source;
						try
						{
							source = from theS in DetectedEmissions.Where(delegate(KeyValuePair<int, EmissionContainer> theKVP)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair4 = theKVP;
									return keyValuePair4.Value.PreciseID;
								}).Select(delegate(KeyValuePair<int, EmissionContainer> keyValuePair_0)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair3 = keyValuePair_0;
									EmissionContainer value2 = keyValuePair3.Value;
									keyValuePair3 = keyValuePair_0;
									return value2.GetAssociatedSensor(keyValuePair3.Key, ActualUnit.ParentScen);
								})
								where theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine)
								orderby theS.maxRange descending
								select theS;
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							source = from theS in DetectedEmissions.Where(delegate(KeyValuePair<int, EmissionContainer> theKVP)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair2 = theKVP;
									return keyValuePair2.Value.PreciseID;
								}).Select(delegate(KeyValuePair<int, EmissionContainer> keyValuePair_0)
								{
									KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
									EmissionContainer value = keyValuePair.Value;
									keyValuePair = keyValuePair_0;
									return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
								})
								where theS.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine)
								orderby theS.maxRange descending
								select theS;
							ProjectData.ClearProjectError();
						}
						if (source.ToList().Count == 0)
						{
							_RuleIssuer = 0f;
						}
						else
						{
							_RuleIssuer = source.ElementAtOrDefault(0).maxRange;
						}
					}
					else
					{
						_RuleIssuer = 0f;
					}
				}
				else
				{
					ActiveUnit_Sensory sensory = ActualUnit.Sensory;
					Sensor[] sensor_ = null;
					List<Sensor> list = sensory.WriteConsumer(bool_0: true, bool_1: false, bool_2: false, bool_3: false, ref sensor_);
					if (list.Count == 0)
					{
						_RuleIssuer = 0f;
					}
					else
					{
						_RuleIssuer = list[0].maxRange;
					}
				}
			}
			result = _RuleIssuer;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100485", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public string HeadingString()
	{
		if (HeadingIsKnown)
		{
			return Misc.FillRequest(CurrentHeading) + " 度";
		}
		return "XXX";
	}

	public string SpeedString(Game.GamePreferences.SpeedUnitSetting speedUnitSetting_0, string string_0)
	{
		if (SpeedIsKnown)
		{
			if (Type == ContactType.Facility_Mobile)
			{
				return Misc.ValidateValue(CurrentSpeed, 0, speedUnitSetting_0);
			}
			return Misc.ValidateValue(CurrentSpeed, 0, Game.GamePreferences.SpeedUnitSetting.Knots);
		}
		return string_0;
	}

	public string AltitudeString(bool bool_0)
	{
		if (AltitudeIsKnown)
		{
			if (bool_0)
			{
				if (GetCurrentAltitude() <= 45720f)
				{
					if (GetCurrentAltitude() <= 3048f)
					{
						if (IsAir_Missile_Orbital_Contact && Module_Unit.ResetTokenizer(this))
						{
							return Conversions.ToString(Math.Round(GetCurrentAltitude() * 3.28084f, 0)) + " 英尺（" + Conversions.ToString(Math.Round(CurrentAltitude_AGL * 3.28084f, 0)) + "英尺 真高）";
						}
						return Conversions.ToString(Math.Round(GetCurrentAltitude() * 3.28084f, 0)) + " 英尺";
					}
					return Conversions.ToString(Math.Round(GetCurrentAltitude() * 3.28084f, 0)) + " 英尺";
				}
				return Conversions.ToString(Math.Round(GetCurrentAltitude() / 1000f, 1)) + " 千米";
			}
			if (GetCurrentAltitude() <= 45720f)
			{
				if (GetCurrentAltitude() <= 3048f)
				{
					if (IsAir_Missile_Orbital_Contact && Module_Unit.ResetTokenizer(this))
					{
						return Conversions.ToString(Math.Round(GetCurrentAltitude(), 0)) + " 米 (" + Conversions.ToString((int)Math.Round(CurrentAltitude_AGL)) + "米 真高）";
					}
					return Conversions.ToString(Math.Round(GetCurrentAltitude(), 0)) + " 米";
				}
				return Conversions.ToString(Math.Round(GetCurrentAltitude(), 0)) + " 米";
			}
			return Conversions.ToString(Math.Round(GetCurrentAltitude() / 1000f, 1)) + " 千米";
		}
		return "XXX";
	}

	public bool IsHardTarget()
	{
		if (ActualUnit == null)
		{
			return false;
		}
		return ActualUnit.IsHardTarget;
	}

	public bool IsBallisticTarget()
	{
		bool result = false;
		try
		{
			if (m_InstanceIssuer.HasValue)
			{
				return result = m_InstanceIssuer.Value;
			}
			if (ActualUnit == null)
			{
				m_InstanceIssuer = false;
				result = false;
				return false;
			}
			if (ActualUnit.IsWeapon)
			{
				if (((Weapon)ActualUnit).IsHGV)
				{
					m_InstanceIssuer = true;
					result = true;
					return true;
				}
				if (!((Weapon)ActualUnit).Flags.Warhead_MIRV && !((Weapon)ActualUnit).Flags.Warhead_MRV && !((Weapon)ActualUnit).Flags.Warhead_SingleRV && !ActualUnit.IsBallisticMissile && !((Weapon)ActualUnit).IsReEntryVehicle)
				{
					m_InstanceIssuer = false;
					result = false;
					return false;
				}
				m_InstanceIssuer = true;
				result = true;
				return true;
			}
			m_InstanceIssuer = false;
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100486", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public bool GetIsSpecificTargetForThisStrike(Strike strike_0)
	{
		if (Information.IsNothing(ActualUnit))
		{
			return false;
		}
		if (strike_0.TargetCount == 0)
		{
			return false;
		}
		if (strike_0.SpecificTargets.Contains(this))
		{
			return true;
		}
		if (strike_0.SpecificTargets.Contains(ActualUnit))
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public override bool GetIsInsideThisArea(List<GeoPoint> list_0, Scenario scenario_0, bool bool_0)
	{
		bool result = false;
		try
		{
			if (Information.IsNothing(UncertaintyArea))
			{
				return result = base.GetIsInsideThisArea(list_0, scenario_0, bool_0);
			}
			foreach (Geopoint_Struct item in UncertaintyArea)
			{
				if (!GeoPoint.IsInsideThisArea(item.Latitude, item.Longitude, list_0.ToList(), bool_0))
				{
					result = false;
					return false;
				}
			}
			result = true;
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100489", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public bool GetIsOutOfUnguidedWeaponsRange(ActiveUnit activeUnit_0)
	{
		bool result = false;
		try
		{
			float num = Module_Unit.RangeToUnit_Slant(activeUnit_0, this);
			List<Weapon> list = new List<Weapon>();
			foreach (Mount mount in activeUnit_0.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if ((uint)(mountWeapon.GetReferenceWeapon(activeUnit_0.ParentScen).Type - 2002) <= 2u)
					{
						list.Add(mountWeapon.GetReferenceWeapon(activeUnit_0.ParentScen));
					}
				}
			}
			foreach (Weapon item in list)
			{
				if (!(item.GetMaxRangeForThisTarget(activeUnit_0, this, bool_0: true, activeUnit_0.Doctrine, bool_1: false) <= num))
				{
					result = false;
					return false;
				}
			}
			result = true;
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100490", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal Contact InitImporter(Side side_0)
	{
		Contact result = null;
		if (!Information.IsNothing(side_0) && !Information.IsNothing(ActualUnit))
		{
			result = side_0.Contacts_List.Find((Contact contact_0) => !Information.IsNothing(contact_0.ActualUnit) && Operators.CompareString(contact_0.ActualUnit.ObjectID, ActualUnit.ObjectID, TextCompare: false) == 0);
		}
		return result;
	}

	private Weapon[] CheckImporter()
	{
		if (ActualUnit == null)
		{
			return new Weapon[0];
		}
		return GetIncomingGuidedWeapons(this, ActualUnit.ParentScen);
	}

	public static Weapon[] GetIncomingGuidedWeapons(Contact contact_0, Scenario scenario_0)
	{
		Weapon[] gparam_ = new Weapon[0];
		Side originalDetectorSide = contact_0.OriginalDetectorSide;
		if (originalDetectorSide == null)
		{
			return gparam_;
		}
		try
		{
			if (scenario_0.GuidedWeaponsInAir != null)
			{
				List<Weapon> guidedWeaponsInAir = scenario_0.GuidedWeaponsInAir;
				if (guidedWeaponsInAir == null || guidedWeaponsInAir.Count != 0)
				{
					List<Weapon> guidedWeaponsInAir2 = scenario_0.GuidedWeaponsInAir;
					if (guidedWeaponsInAir2 == null)
					{
						return gparam_;
					}
					if (contact_0.ActualUnit == null)
					{
						return gparam_;
					}
					if (guidedWeaponsInAir2.Count > 0)
					{
						string objectID = contact_0.ObjectID;
						Contact contact = null;
						for (int i = guidedWeaponsInAir2.Count - 1; i >= 0; i += -1)
						{
							Weapon weapon = guidedWeaponsInAir2[i];
							if (weapon == null)
							{
								continue;
							}
							Weapon_AI aI = weapon.AI;
							if (originalDetectorSide.GetConsidersThisSideToBe(weapon.GetUnitSide()) != Misc.PostureStance.Friendly)
							{
								continue;
							}
							if (aI != null)
							{
								contact = aI.PrimaryTarget;
								if (contact != null)
								{
									if (contact == contact_0 || string.CompareOrdinal(contact.ObjectID, objectID) == 0)
									{
										if (weapon.FiringParent == null || weapon.FiringParent.CommStuff.IsConnectedToSideNetwork)
										{
											ArrayExtensions.Add(ref gparam_, weapon);
										}
										continue;
									}
									if (contact.ActualUnit != null && contact_0.ActualUnit != null && contact.ActualUnit == contact_0.ActualUnit)
									{
										if (weapon.FiringParent == null || weapon.FiringParent.CommStuff.IsConnectedToSideNetwork)
										{
											ArrayExtensions.Add(ref gparam_, weapon);
										}
										continue;
									}
								}
							}
							if (weapon.IsMIRVedMissile.Value && aI.IsTargetingThisContact(contact_0))
							{
								ArrayExtensions.Add(ref gparam_, weapon);
							}
							else if (weapon.Guidance == Weapon.WeaponGuidanceType.Inertial && contact != null && contact.Type == ContactType.Aimpoint && (double)Module_Unit.RangeToUnit_Horiz(contact, contact_0) * 1852.0 < 20.0)
							{
								ArrayExtensions.Add(ref gparam_, weapon);
							}
						}
					}
					ActiveUnit activeUnit = null;
					for (int j = scenario_0.NewbornUnits.Count - 1; j >= 0; j += -1)
					{
						try
						{
							activeUnit = scenario_0.NewbornUnits[j];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						if (activeUnit == null || !activeUnit.IsWeapon || originalDetectorSide.GetConsidersThisSideToBe(activeUnit.GetUnitSide()) != Misc.PostureStance.Friendly)
						{
							continue;
						}
						Contact primaryTarget = activeUnit.AI.PrimaryTarget;
						if (primaryTarget != null)
						{
							if (primaryTarget == contact_0)
							{
								ArrayExtensions.Add(ref gparam_, (Weapon)activeUnit);
							}
							else if (primaryTarget.ActualUnit != null && contact_0.ActualUnit != null && primaryTarget.ActualUnit == contact_0.ActualUnit)
							{
								ArrayExtensions.Add(ref gparam_, (Weapon)activeUnit);
							}
						}
					}
					return gparam_;
				}
			}
			return gparam_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200024", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Weapon[] result = gparam_;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public override Side GetUnitSide(bool bool_0 = false)
	{
		if (SideIsKnown && ActualUnit != null)
		{
			_UnitSide = ActualUnit.GetUnitSide();
		}
		return _UnitSide;
	}

	[SpecialName]
	public override void SetUnitSide(bool bool_0, Side side_0)
	{
		_UnitSide = side_0;
	}

	[SpecialName]
	public GlobalVariables.TargetVisualSizeClass GetApparentSize(Scenario scenario_0)
	{
		ActiveUnit actualUnit = ActualUnit;
		switch (IDStatus)
		{
		case IdentificationStatus.KnownClass:
		case IdentificationStatus.PreciseID:
			return actualUnit.VisualSizeClass;
		default:
			return GlobalVariables.TargetVisualSizeClass.Stealthy;
		case IdentificationStatus.Unknown:
		case IdentificationStatus.KnownDomain:
		case IdentificationStatus.KnownType:
			return actualUnit.VisualSizeClass;
		}
	}

	[SpecialName]
	public bool GetIsDestroyed(Scenario scenario_0)
	{
		if (HasBeenCheckedForDestructionThisPulse)
		{
			if (!infoObserver && ActualUnit != null && ActualUnit.IsDestroyed)
			{
				infoObserver = true;
				return infoObserver;
			}
			return infoObserver;
		}
		if (Type != ContactType.Aimpoint && Type != ContactType.ActivationPoint)
		{
			if (ActualUnit == null)
			{
				infoObserver = true;
				HasBeenCheckedForDestructionThisPulse = true;
				return infoObserver;
			}
			if (ActualUnit.IsBeingDestroyed)
			{
				infoObserver = true;
				HasBeenCheckedForDestructionThisPulse = true;
				return infoObserver;
			}
			try
			{
				if (!scenario_0.ActiveUnits.ContainsKey(ActualUnit.ObjectID) && !scenario_0.NewbornUnits.Contains(ActualUnit))
				{
					infoObserver = true;
				}
				else
				{
					infoObserver = false;
				}
				HasBeenCheckedForDestructionThisPulse = true;
				return infoObserver;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200025", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return true;
			}
		}
		infoObserver = false;
		HasBeenCheckedForDestructionThisPulse = true;
		return infoObserver;
	}

	private static string ConcatImporter(object object_0)
	{
		string result = null;
		try
		{
			if (((Contact)object_0).ActualUnit == null)
			{
				result = "";
				return result;
			}
			if (!((Contact)object_0).ActualUnit.isUAV)
			{
				if (((Contact)object_0).ActualUnit.isUAV)
				{
					result = "UAV";
					return result;
				}
				switch (((Contact_Base)object_0).Type)
				{
				case ContactType.Air:
					if (((Contact)object_0).ActualUnit.IsAircraft)
					{
						result = ((Aircraft)((Contact)object_0).ActualUnit).Type.ToString();
						return result;
					}
					if (((Contact)object_0).ActualUnit.IsWeapon)
					{
						if (((Weapon)((Contact)object_0).ActualUnit).IsDecoy)
						{
							result = "Decoy";
							return result;
						}
						result = "Unknown";
						return result;
					}
					result = "Unknown";
					return result;
				case ContactType.Surface:
					result = ((Ship)((Contact)object_0).ActualUnit).Type.ToString();
					return result;
				case ContactType.Submarine:
					result = ((Submarine)((Contact)object_0).ActualUnit).Type.ToString();
					return result;
				case ContactType.Facility_Fixed:
					result = ((Facility)((Contact)object_0).ActualUnit).Category.ToString();
					return result;
				case ContactType.Facility_Mobile:
					if (((Contact)object_0).ActualUnit.IsMobileGroundUnit)
					{
						result = Misc.ToEnglishString(((IMobileGroundUnit)((Contact)object_0).ActualUnit).MobileUnitCategory);
						return result;
					}
					result = ((Facility)((Contact)object_0).ActualUnit).ChangeBridge();
					return result;
				case ContactType.Missile:
				case ContactType.Torpedo:
					result = ((Weapon)((Contact)object_0).ActualUnit).Type.ToString();
					return result;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = ((Contact)object_0).ActualUnit.UnitClass;
					return result;
				case ContactType.Decoy_Air:
				case ContactType.Decoy_Surface:
				case ContactType.Decoy_Land:
				case ContactType.Decoy_Sub:
					result = "Decoy";
					return result;
				}
			}
			result = "UAV";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100492", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static string GeneralClassificationString(Contact contact_0)
	{
		switch (contact_0.IDStatus)
		{
		default:
			return null;
		case IdentificationStatus.Unknown:
			return "Unknown";
		case IdentificationStatus.KnownDomain:
			return contact_0.ContactType_String;
		case IdentificationStatus.KnownType:
			return ConcatImporter(contact_0);
		case IdentificationStatus.KnownClass:
		case IdentificationStatus.PreciseID:
			return contact_0.ActualUnit.UnitClass;
		}
	}

	[SpecialName]
	public void method_0(Scenario scenario_0, Side side_0, Sensor sensor_0, float? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, IdentificationStatus identificationStatus_0)
	{
		try
		{
			if (identificationStatus_0 <= _IDStatus)
			{
				return;
			}
			_IDStatus = identificationStatus_0;
			producerObserver = null;
			_ProcObserver = null;
			merchantIssuer = null;
			string text = "";
			if (nullable_0.HasValue)
			{
				text = ((UncertaintyArea == null) ? Math.Round(nullable_0.Value, 1).ToString() : ("估计" + Math.Round(nullable_0.Value, 0)));
			}
			LoggedMessage.MessageType messageType_ = (bool_1 ? LoggedMessage.MessageType.ContactChange : LoggedMessage.MessageType.CommsIsolatedMessage);
			bool flag = false;
			if (sensor_0 != null)
			{
				flag = !sensor_0.ParentPlatform.CommStuff.IsConnectedToSideNetwork;
			}
			if (ActualUnit.GetIsEligibleForAutodetection(side_0) && !flag)
			{
				_IDStatus = IdentificationStatus.PreciseID;
			}
			if (_AutoIncrement == 0 && flag)
			{
				_AutoIncrement = new LockRandom(scenario_0.Time.Millisecond).Next(1, 9999);
			}
			switch (_IDStatus)
			{
			case IdentificationStatus.Unknown:
				if (bool_2)
				{
					InterruptImporter(scenario_0, this, side_0, sensor_0, string.Empty);
				}
				break;
			case IdentificationStatus.KnownDomain:
				switch (Type)
				{
				case ContactType.Sonobuoy:
					Name = "声呐浮标 #" + Conversions.ToString(_AutoIncrement);
					break;
				case ContactType.Air:
					Name = "BOGEY #" + Conversions.ToString(_AutoIncrement);
					break;
				case ContactType.Missile:
					if (ActualUnit == null)
					{
						Name = "导弹 #" + Conversions.ToString(_AutoIncrement);
					}
					else if (!ActualUnit.IsBallisticMissile && (!ActualUnit.IsWeapon || !((Weapon)ActualUnit).IsReEntryVehicle))
					{
						if (ActualUnit.AI.PrimaryTarget == null)
						{
							Name = "导弹 #" + Conversions.ToString(_AutoIncrement);
							break;
						}
						Contact primaryTarget = ActualUnit.AI.PrimaryTarget;
						if (primaryTarget.IsAir_Missile_Orbital_Contact)
						{
							Weapon weapon = (Weapon)ActualUnit;
							if (weapon.FiringParent == null)
							{
								Name = "导弹 #" + Conversions.ToString(_AutoIncrement);
							}
							else if (weapon.FiringParent.IsAircraft)
							{
								Name = "导弹 #" + Conversions.ToString(_AutoIncrement);
							}
							else
							{
								Name = "地空导弹 #" + Conversions.ToString(_AutoIncrement);
							}
						}
						else if ((primaryTarget.IsSurfaceContact || primaryTarget.IsSubmergedContact) && !ActualUnit.IsMobileDecoy_Air && !ActualUnit.isUAV)
						{
							Name = "VAMPIRE #" + Conversions.ToString(_AutoIncrement);
						}
						else
						{
							Name = "导弹 #" + Conversions.ToString(_AutoIncrement);
						}
					}
					else
					{
						Name = "FIREBALL #" + Conversions.ToString(_AutoIncrement);
					}
					break;
				case ContactType.Surface:
					Name = "SKUNK #" + Conversions.ToString(_AutoIncrement);
					break;
				case ContactType.Submarine:
					Name = "GOBLIN #" + Conversions.ToString(_AutoIncrement);
					break;
				default:
					Name = "目标 #" + Conversions.ToString(_AutoIncrement);
					break;
				case ContactType.Facility_Fixed:
					if (ActualUnit.GetIsAutoDetectable(null))
					{
						Name = ActualUnit.Name;
						SideIsKnown = true;
					}
					else
					{
						Name = "固定 #" + Conversions.ToString(_AutoIncrement);
					}
					break;
				case ContactType.Facility_Mobile:
					Name = "移动 #" + Conversions.ToString(_AutoIncrement);
					break;
				case ContactType.Torpedo:
					Name = "TORPEDO #" + Conversions.ToString(_AutoIncrement);
					break;
				case ContactType.Mine:
					Name = "雷 #" + Conversions.ToString(_AutoIncrement);
					break;
				}
				if (flag && !Name.StartsWith("[OOC]"))
				{
					Name = "[OOC] " + Name;
				}
				if (bool_2)
				{
					InterruptImporter(scenario_0, this, side_0, sensor_0, "Designated: " + Name);
				}
				break;
			case IdentificationStatus.KnownType:
			{
				if (sensor_0 != null && (sensor_0.Type == Sensor.Sensor_Type.Visual || sensor_0.Type == Sensor.Sensor_Type.Infrared) && Type == ContactType.Air && ActualUnit != null && ActualUnit.IsMobileDecoy_Air)
				{
					Type = ContactType.Decoy_Air;
					if (!bool_3)
					{
						break;
					}
					string text9 = "目标：" + Name + " 已被分类为诱饵！";
					string text10 = "";
					if (sensor_0 != null)
					{
						if (sensor_0.ParentPlatform == null)
						{
							text10 = " （按传感器分类：" + Misc.ReadRequest(sensor_0.Name);
						}
						else
						{
							ActiveUnit parentPlatform2 = sensor_0.ParentPlatform;
							string text11 = "";
							if (parentPlatform2.IsAircraft && Operators.CompareString(parentPlatform2.Name, parentPlatform2.UnitClass, TextCompare: false) != 0)
							{
								text11 = " (" + parentPlatform2.UnitClass + ")";
							}
							text10 = " （分类依据：" + sensor_0.ParentPlatform.Name + text11 + " [传感器：" + Misc.ReadRequest(sensor_0.Name) + "]";
						}
						text10 += ")";
					}
					text9 += text10;
					if (flag && !Name.StartsWith("[OOC]"))
					{
						Name = "[OOC] " + Name;
					}
					scenario_0.AddMessage(text9, Name + " 是一个诱饵", LoggedMessage.MessageType.ContactChange, 1, null, side_0, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					break;
				}
				string name2 = Name;
				string text12 = "目标：" + Name;
				Name = ConcatImporter(this) + " #" + Conversions.ToString(_AutoIncrement);
				if (bool_3)
				{
					text12 = text12 + " 已被分类为：" + ConcatImporter(this);
					string text13 = "";
					if (sensor_0 != null)
					{
						if (sensor_0.ParentPlatform == null)
						{
							text13 = " （按传感器分类：" + Misc.ReadRequest(sensor_0.Name);
						}
						else
						{
							ActiveUnit parentPlatform3 = sensor_0.ParentPlatform;
							string text2 = "";
							if (parentPlatform3.IsAircraft && Operators.CompareString(parentPlatform3.Name, parentPlatform3.UnitClass, TextCompare: false) == 0)
							{
								text2 = " (" + parentPlatform3.UnitClass + ")";
							}
							text13 = " （分类依据：" + sensor_0.ParentPlatform.Name + text2 + " [传感器：" + Misc.ReadRequest(sensor_0.Name) + "]";
						}
						if (bool_0)
						{
							text13 += " [NCTR模式]";
						}
						text13 = (nullable_0.HasValue ? (text13 + "在" + text + " 海里）") : (text13 + ")"));
					}
					text12 += text13;
					scenario_0.AddMessage(text12, name2 + " 型号识别为：" + ConcatImporter(this), messageType_, 1, null, side_0, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					if (flag && !Name.StartsWith("[OOC]"))
					{
						Name = "[OOC] " + Name;
					}
				}
				if (Type == ContactType.Submarine && (uint)(((Submarine)ActualUnit).Type - 9001) <= 1u)
				{
					SideIsKnown = true;
					if (ActualUnit != null && ActualUnit.GetUnitSide() != null)
					{
						SetStance(side_0, bool_0: false, side_0.GetConsidersThisSideToBe(ActualUnit.GetUnitSide()));
						Contact contact_2 = this;
						RemoveImporter(ref scenario_0, ref side_0, ref contact_2);
						RetreivedPostureOnThisPulse = false;
					}
				}
				break;
			}
			case IdentificationStatus.KnownClass:
			{
				SideIsKnown = true;
				if (!Information.IsNothing(ActualUnit) && !Information.IsNothing(ActualUnit.GetUnitSide()))
				{
					SetStance(side_0, bool_0: false, side_0.GetConsidersThisSideToBe(ActualUnit.GetUnitSide()));
				}
				string name3 = Name;
				string text3 = "目标：" + name3;
				Name = Misc.ReadRequest(ActualUnit.UnitClass) + " #" + Conversions.ToString(_AutoIncrement);
				if (bool_3)
				{
					text3 = text3 + " 被分类为：" + Misc.ReadRequest(ActualUnit.UnitClass);
					text3 = text3 + " - 确定为：" + GetStance(side_0);
					string text4 = "";
					if (!Information.IsNothing(sensor_0))
					{
						if (Information.IsNothing(sensor_0.ParentPlatform))
						{
							text4 = " （按传感器分类：" + Misc.ReadRequest(sensor_0.Name);
						}
						else
						{
							ActiveUnit parentPlatform4 = sensor_0.ParentPlatform;
							string text5 = "";
							if (parentPlatform4.IsAircraft && Operators.CompareString(parentPlatform4.Name, parentPlatform4.UnitClass, TextCompare: false) != 0)
							{
								text5 = " (" + parentPlatform4.UnitClass + ")";
							}
							text4 = " （分类依据：" + sensor_0.ParentPlatform.Name + text5 + " [传感器：" + Misc.ReadRequest(sensor_0.Name) + "]";
						}
						if (bool_0)
						{
							text4 += " [NCTR模式]";
						}
						text4 = (Information.IsNothing(nullable_0) ? (text4 + ")") : (text4 + "在" + text + " 海里）"));
					}
					text3 += text4;
					scenario_0.AddMessage(text3, name3 + " 平台识别为：" + Misc.ReadRequest(ActualUnit.UnitClass), messageType_, 1, null, side_0, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
				if (Information.IsNothing(sensor_0) || sensor_0.Type != Sensor.Sensor_Type.Visual || sensor_0.Type != Sensor.Sensor_Type.Infrared)
				{
					if (!ActualUnit.IsMobileDecoy_Air && !ActualUnit.isUAV)
					{
						if (ActualUnit.IsMobileDecoy_Surface)
						{
							Type = ContactType.Surface;
						}
						else if (ActualUnit.IsMobileDecoy_Sub)
						{
							Type = ContactType.Submarine;
						}
					}
					else
					{
						Type = ContactType.Air;
					}
				}
				Contact contact_3 = this;
				RemoveImporter(ref scenario_0, ref side_0, ref contact_3);
				RetreivedPostureOnThisPulse = false;
				break;
			}
			case IdentificationStatus.PreciseID:
			{
				SideIsKnown = true;
				if (!Information.IsNothing(ActualUnit) && !Information.IsNothing(ActualUnit.GetUnitSide()))
				{
					SetStance(side_0, bool_0: false, side_0.GetConsidersThisSideToBe(ActualUnit.GetUnitSide()));
				}
				if (string.IsNullOrEmpty(Name) || ActualUnit.GetIsEligibleForAutodetection(side_0))
				{
					Name = ActualUnit.Name;
				}
				if (ActualUnit.GetIsEligibleForAutodetection(side_0))
				{
					break;
				}
				string name = Name;
				string text6 = "目标：" + Name;
				Name = ActualUnit.Name;
				if (bool_3)
				{
					text6 = text6 + "已被识别为：" + Misc.ReadRequest(Name);
					text6 = text6 + " - 确定为：" + GetStance(side_0);
					string text7 = "";
					if (!Information.IsNothing(sensor_0))
					{
						if (Information.IsNothing(sensor_0.ParentPlatform))
						{
							text7 = "（传感器ID：" + Misc.ReadRequest(sensor_0.Name);
						}
						else
						{
							ActiveUnit parentPlatform = sensor_0.ParentPlatform;
							string text8 = "";
							if (parentPlatform.IsAircraft && Operators.CompareString(parentPlatform.Name, parentPlatform.UnitClass, TextCompare: false) != 0)
							{
								text8 = " (" + parentPlatform.UnitClass + ")";
							}
							text7 = " (ID by: " + sensor_0.ParentPlatform.Name + text8 + " [传感器：" + Misc.ReadRequest(sensor_0.Name) + "]";
						}
						text7 = (Information.IsNothing(nullable_0) ? (text7 + ")") : (text7 + "在" + text + " 海里）"));
					}
					text6 += text7;
					if (Type != ContactType.Facility_Fixed && Type != ContactType.Installation && Type != ContactType.AirBase && Type != ContactType.NavalBase && Type != ContactType.MobileGroup)
					{
						scenario_0.AddMessage(text6, name + " now positive ID: " + Misc.ReadRequest(Name), messageType_, 1, null, side_0, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
					if (flag && !Name.StartsWith("[OOC]"))
					{
						Name = "[OOC] " + Name;
					}
					if (bool_2)
					{
						InterruptImporter(scenario_0, this, side_0, sensor_0, text6);
					}
				}
				Contact contact_ = this;
				RemoveImporter(ref scenario_0, ref side_0, ref contact_);
				RetreivedPostureOnThisPulse = false;
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100493", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FullyIdentify(Side side_0)
	{
		_IDStatus = IdentificationStatus.PreciseID;
		SideIsKnown = true;
		AltitudeIsKnown = true;
		HeadingIsKnown = true;
		SpeedIsKnown = true;
		IsPreciselyLocatedOnThisPulse = true;
		if (ActualUnit != null)
		{
			if (ActualUnit.GetUnitSide() != null)
			{
				SetStance(side_0, bool_0: false, side_0.GetConsidersThisSideToBe(ActualUnit.GetUnitSide()));
			}
			Name = ActualUnit.Name;
		}
	}

	private static void InterruptImporter(Scenario scenario_0, object object_0, Side side_0, PlatformComponent platformComponent_0, object object_1)
	{
		try
		{
			foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
			{
				if (applicableEventExporter.IsOperating && applicableEventExporter.ExportEngagementCycle)
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
					ActiveUnit activeUnit = null;
					if (platformComponent_0 != null && platformComponent_0.ParentPlatform != null)
					{
						activeUnit = platformComponent_0.ParentPlatform;
					}
					if (activeUnit == null)
					{
						dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 40));
						dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
						dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					else
					{
						dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(activeUnit.ObjectID, typeof(string), 40));
						dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(activeUnit.Name, typeof(string), 500));
						dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(activeUnit.UnitClass, typeof(string), 500));
					}
					if (side_0 == null)
					{
						dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					else
					{
						dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(side_0.Name, typeof(string), 500));
					}
					dictionary.Add("CycleAction", new IEventExporter.EventNotificationParameter("Contact ID status changed: " + ((Contact)object_0).DescriptionString, typeof(string), 200));
					dictionary.Add("ContactID", new IEventExporter.EventNotificationParameter(((ScenarioObject)object_0).ObjectID, typeof(string), 40));
					dictionary.Add("ContactName", new IEventExporter.EventNotificationParameter(((Contact)object_0).Name, typeof(string), 500));
					dictionary.Add("ContactLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)object_0).GetLongitude().ToString(), typeof(double)));
					dictionary.Add("ContactLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)object_0).GetLatitude().ToString(), typeof(double)));
					if (activeUnit == null)
					{
						dictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
						dictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
					}
					else
					{
						dictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Horiz(activeUnit, (Module_Unit.Unit)object_0), typeof(float)));
						dictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Slant(activeUnit, (Module_Unit.Unit)object_0), typeof(float)));
					}
					if (((Contact)object_0).ActualUnit != null)
					{
						dictionary.Add("ContactActualUnitID", new IEventExporter.EventNotificationParameter(((Contact)object_0).ActualUnit.ObjectID, typeof(string), 40));
						dictionary.Add("ContactActualUnitName", new IEventExporter.EventNotificationParameter(((Contact)object_0).ActualUnit.Name, typeof(string), 500));
						dictionary.Add("ContactActualUnitClass", new IEventExporter.EventNotificationParameter(((Contact)object_0).ActualUnit.UnitClass, typeof(string), 500));
						dictionary.Add("ContactActualUnitSide", new IEventExporter.EventNotificationParameter(((Contact)object_0).ActualUnit.GetUnitSide().Name, typeof(string), 500));
					}
					dictionary.Add("SalvoID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					dictionary.Add("MiscInfo", new IEventExporter.EventNotificationParameter(object_1, typeof(string)));
					applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.EngagementCycle, dictionary, scenario_0);
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

	private void RemoveImporter(ref Scenario scenario_0, ref Side side_0, ref Contact contact_0)
	{
		HashSet<string> hashSet = GameGeneral.m_ManagerClient[side_0.ObjectID];
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (side != side_0 && hashSet.Contains(side.ObjectID) && !Information.IsNothing(contact_0.ActualUnit))
			{
				Contact contact_ = null;
				if (side.Contacts.TryGetValue(contact_0.ActualUnit.ObjectID, ref contact_))
				{
					smethod_0(contact_0, contact_);
				}
			}
		}
	}

	public static void smethod_0(Contact contact_0, Contact contact_1)
	{
		if (contact_0._IDStatus > contact_1._IDStatus && !ActiveUnit_Sensory.ContactsAreOfSameActualUnit(contact_1, contact_0))
		{
			contact_1._IDStatus = contact_0._IDStatus;
			contact_1.Name = contact_0.Name;
			contact_1.RetreivedPostureOnThisPulse = false;
		}
	}

	[SpecialName]
	public bool GetIsPrivate(Side side_0)
	{
		if (!parameterIssuer.HasValue)
		{
			parameterIssuer = !side_0.Contacts.ContainsKey(ActualUnit.ObjectID);
		}
		return parameterIssuer.Value;
	}

	[SpecialName]
	public void SetIsPrivate(Side side_0, bool bool_0)
	{
		parameterIssuer = bool_0;
	}

	[SpecialName]
	public Misc.PostureStance GetStance(Side side_0)
	{
		try
		{
			if (Information.IsNothing(ActualUnit))
			{
				return Misc.PostureStance.Unknown;
			}
			if (!GetIsPrivate(side_0) && !RetreivedPostureOnThisPulse)
			{
				object objectIssuer = _ObjectIssuer;
				ObjectFlowControl.CheckForSyncLockOnValueType(objectIssuer);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(objectIssuer, ref lockTaken);
					if (!RetreivedPostureOnThisPulse)
					{
						if (Information.IsNothing(ActualUnit) || ActualUnit.IsDestroyed)
						{
							return Misc.PostureStance.Unknown;
						}
						Information.IsNothing(side_0);
						Information.IsNothing(ActualUnit.GetUnitSide());
						if (Type != ContactType.Missile && Type != ContactType.Torpedo)
						{
							if (SideIsKnown && m_RoleObserver)
							{
								Dictionary<Side, Misc.PostureStance> dictionary = new Dictionary<Side, Misc.PostureStance>(ActualUnit.ParentScen.Sides_ReadOnly.Length);
								Side[] sides_ReadOnly2 = ActualUnit.ParentScen.Sides_ReadOnly;
								Side[] array = sides_ReadOnly2;
								foreach (Side side in array)
								{
									if (Information.IsNothing(side))
									{
										continue;
									}
									if ((int)(Type - 18) <= 3)
									{
										if (!Information.IsNothing(ActualUnit) && (side.BaseContacts.ContainsKey(ActualUnit.ObjectID) || ActualUnit.GetIsEligibleForAutodetection(side)))
										{
											dictionary.Add(side, side.GetConsidersThisSideToBe(ActualUnit.GetUnitSide()));
										}
									}
									else if (!Information.IsNothing(ActualUnit) && (side.Contacts.ContainsKey(ActualUnit.ObjectID) || ActualUnit.GetIsEligibleForAutodetection(side)))
									{
										dictionary.Add(side, side.GetConsidersThisSideToBe(ActualUnit.GetUnitSide()));
									}
								}
								_AlgoObserver = dictionary;
							}
						}
						else
						{
							Dictionary<Side, Misc.PostureStance> dictionary2 = new Dictionary<Side, Misc.PostureStance>(ActualUnit.ParentScen.Sides_ReadOnly.Length);
							Side[] sides_ReadOnly = ActualUnit.ParentScen.Sides_ReadOnly;
							Side[] array2 = sides_ReadOnly;
							foreach (Side side2 in array2)
							{
								if (!Information.IsNothing(side2) && !Information.IsNothing(ActualUnit) && side2.Contacts.ContainsKey(ActualUnit.ObjectID))
								{
									Misc.PostureStance considersThisSideToBe = side2.GetConsidersThisSideToBe(ActualUnit.GetUnitSide());
									if (considersThisSideToBe == Misc.PostureStance.Friendly)
									{
										dictionary2.Add(side2, considersThisSideToBe);
									}
									else
									{
										dictionary2.Add(side2, Misc.PostureStance.Hostile);
									}
								}
							}
							_AlgoObserver = dictionary2;
						}
						RetreivedPostureOnThisPulse = true;
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(objectIssuer);
					}
				}
			}
			if (_AlgoObserver.TryGetValue(side_0, out var value))
			{
				return value;
			}
			return Misc.PostureStance.Unknown;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200572", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return Misc.PostureStance.Unknown;
		}
	}

	[SpecialName]
	public void SetStance(Side side_0, bool bool_0, Misc.PostureStance postureStance_0)
	{
		try
		{
			if (SideIsKnown && Module_Side.IsAlliedWithThisSide(side_0, ActualUnit.GetUnitSide()))
			{
				return;
			}
			if (bool_0)
			{
				m_RoleObserver = false;
			}
			else
			{
				m_RoleObserver = true;
			}
			if (!_AlgoObserver.TryGetValue(side_0, out var value))
			{
				_AlgoObserver.Add(side_0, value);
			}
			bool? flag = value != postureStance_0;
			if (_AlgoObserver.ContainsKey(side_0))
			{
				_AlgoObserver[side_0] = postureStance_0;
			}
			if (!flag.GetValueOrDefault())
			{
				return;
			}
			if (side_0.Cache_ContactStancesOnThisPulse.ContainsKey(ObjectID))
			{
				side_0.Cache_ContactStancesOnThisPulse[ObjectID] = postureStance_0;
			}
			else
			{
				object obj = attributeObserver;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					side_0.Cache_ContactStancesOnThisPulse.Add(ObjectID, postureStance_0);
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			if (SideIsKnown && GetUnitSide().AssignsCollectiveResponsibility && (postureStance_0 == Misc.PostureStance.Unfriendly || postureStance_0 == Misc.PostureStance.Hostile) && !Information.IsNothing(ActualUnit))
			{
				side_0.SetConsidersThisSideToBe(ActualUnit.GetUnitSide(), postureStance_0);
			}
			if (IsFilteredOut && (postureStance_0 == Misc.PostureStance.Unfriendly || postureStance_0 == Misc.PostureStance.Hostile))
			{
				IsFilteredOut = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100494", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateCenter(ActiveUnit activeUnit_0)
	{
		if (UncertaintyArea != null && UncertaintyArea.Count != 0)
		{
			List<Geopoint_Struct> list = null;
			foreach (Geopoint_Struct item in UncertaintyArea)
			{
				if (double.IsNaN(item.Longitude) || double.IsNaN(item.Latitude))
				{
					if (list == null)
					{
						list = new List<Geopoint_Struct>();
					}
					list.Add(item);
				}
			}
			if (list != null)
			{
				foreach (Geopoint_Struct item2 in list)
				{
					UncertaintyArea.Remove(item2);
				}
			}
			Geopoint_Struct geopoint_Struct = Misc.Center(UncertaintyArea);
			SetLongitude(null, geopoint_Struct.Longitude);
			SetLatitude(null, geopoint_Struct.Latitude);
		}
		else
		{
			SetLongitude(null, activeUnit_0.GetLongitude());
			SetLatitude(null, activeUnit_0.GetLatitude());
		}
	}

	public bool CurrentCenterIsWithinThisArea(List<GeoPoint> list_0)
	{
		return GeoPoint.IsInsideThisArea(GetLatitude(), GetLongitude(), list_0);
	}

	public Contact(ActiveUnit activeUnit_0, int int_0 = 0, bool bool_0 = false)
	{
		_AlgoObserver = new Dictionary<Side, Misc.PostureStance>();
		m_InterceptorObserver = null;
		TimeSinceDetection = 0f;
		TimeSinceBDA = 0f;
		TimeSinceRecon = 0f;
		TimeSinceESM_Identification = 0f;
		productObserver = new List<HostedUnitReconRecord>();
		m_RoleObserver = true;
		LastDetections = new Queue<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime)>();
		attributeObserver = RuntimeHelpers.GetObjectValue(new object());
		_HelperObserver = false;
		mapperObserver = new TrajectoryPoint[0];
		_ObjectIssuer = RuntimeHelpers.GetObjectValue(new object());
		m_ExpressionIssuer = RuntimeHelpers.GetObjectValue(new object());
		SideIsKnown = false;
		_AutoIncrement = int_0;
		if (activeUnit_0 == null)
		{
			return;
		}
		try
		{
			ActualUnit = activeUnit_0;
			if (activeUnit_0.IsAircraft)
			{
				Type = ContactType.Air;
			}
			else if (activeUnit_0.IsWeapon)
			{
				if (activeUnit_0.isUAV)
				{
					Type = ContactType.Air;
				}
				else
				{
					switch (((Weapon)activeUnit_0).Type)
					{
					case Weapon._WeaponType.UAV_Expendable:
						Type = ContactType.Air;
						break;
					case Weapon._WeaponType.Decoy_Vehicle:
						if (activeUnit_0.IsMobileDecoy_Air)
						{
							Type = ContactType.Air;
						}
						else if (activeUnit_0.IsMobileDecoy_Surface)
						{
							Type = ContactType.Surface;
						}
						else if (activeUnit_0.IsMobileDecoy_Sub)
						{
							Type = ContactType.Submarine;
						}
						break;
					case Weapon._WeaponType.Sonobuoy:
						Type = ContactType.Sonobuoy;
						break;
					case Weapon._WeaponType.Torpedo:
						Type = ContactType.Torpedo;
						break;
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new NotImplementedException();
					case Weapon._WeaponType.GuidedWeapon:
					case Weapon._WeaponType.Rocket:
					case Weapon._WeaponType.BallisticMissile:
					case Weapon._WeaponType.RV:
					case Weapon._WeaponType.HGV:
						Type = ContactType.Missile;
						break;
					}
				}
			}
			else if (activeUnit_0.IsFacility)
			{
				if (((Platform)activeUnit_0).RepresentsMobileGroundUnit)
				{
					Type = ContactType.Facility_Mobile;
				}
				else
				{
					Type = ContactType.Facility_Fixed;
				}
			}
			else if (activeUnit_0.IsMobileGroundUnit)
			{
				Type = ContactType.Facility_Mobile;
			}
			else if (activeUnit_0.IsShip)
			{
				Type = ContactType.Surface;
			}
			else if (activeUnit_0.IsSubmarine)
			{
				Type = ContactType.Submarine;
			}
			else if (activeUnit_0.IsSatellite)
			{
				Type = ContactType.Orbital;
			}
			else
			{
				if (!activeUnit_0.IsGroup)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				}
				if (((Group)ActualUnit).Type == Group.GroupType.AirBase)
				{
					Type = ContactType.AirBase;
				}
				else if (((Group)ActualUnit).Type == Group.GroupType.MobileGroup)
				{
					Type = ContactType.MobileGroup;
				}
				else if (((Group)ActualUnit).Type == Group.GroupType.NavalBase)
				{
					Type = ContactType.NavalBase;
				}
				else
				{
					Type = ContactType.Installation;
				}
			}
			if (bool_0)
			{
				SetLatitude(null, activeUnit_0.GetLatitude());
				SetLongitude(null, activeUnit_0.GetLongitude());
				SetCurrentAltitude(bool_0: false, activeUnit_0.GetCurrentAltitude());
				TimeSinceDetection = 1.7014117E+38f;
				_IDStatus = IdentificationStatus.KnownType;
			}
			else
			{
				if (ActualUnit == null)
				{
					return;
				}
				Side[] sides_ReadOnly = ActualUnit.ParentScen.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (side != null && side.Contacts.ContainsKey(ActualUnit.ObjectID))
					{
						_AlgoObserver.Add(side, Misc.PostureStance.Unknown);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100495", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal float FindImporter(Module_Unit.Unit unit_0)
	{
		float result = 0f;
		try
		{
			float float_ = CurrentSpeed / 3600f;
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_, ref double_2, float_, CurrentHeading);
			float num = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), GetLatitude(), GetLongitude());
			float num2 = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_2, double_);
			num2 = Math2.UpdateClass(num2 - num);
			num = 0f;
			if (num2 <= 180f)
			{
				result = num2;
				return result;
			}
			result = 360f - num2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100496", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void GrowUncertaintyArea_Clipper(double double_0, ref Scenario scenario_0)
	{
		if (UncertaintyArea == null && Age == 0f)
		{
			return;
		}
		try
		{
			if (UncertaintyArea != null && Misc.QueryRequest(UncertaintyArea))
			{
				return;
			}
			double num = 0.0;
			if (SpeedIsKnown)
			{
				num = CurrentSpeed;
			}
			else
			{
				switch (Type)
				{
				case ContactType.Air:
					num = 660.0;
					break;
				case ContactType.Missile:
					num = 1000.0;
					break;
				case ContactType.Surface:
				case ContactType.Submarine:
					num = 20.0;
					break;
				case ContactType.Orbital:
					num = 6000.0;
					break;
				case ContactType.Facility_Mobile:
					num = 20.0;
					break;
				case ContactType.Torpedo:
					num = 45.0;
					break;
				}
			}
			if (num == 0.0)
			{
				return;
			}
			double num2 = num / 3600.0 * double_0;
			double num3 = num2 * 1852.0;
			if (UncertaintyArea == null)
			{
				Geodesic_Vincenty.Point3D[] point3D_ = new Geodesic_Vincenty.Point3D[46];
				Geodesic_EdWilliams.CircleFromPoint(GetLatitude(), GetLongitude(), num2, 45, ref point3D_);
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(point3D_.Length);
				Geodesic_Vincenty.Point3D[] array = point3D_;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					Geodesic_Vincenty.Point3D point3D = array[i];
					list.Add(new Geopoint_Struct(point3D.X, point3D.Y));
				}
				UncertaintyArea = list;
				return;
			}
			if (num3 > 0.0)
			{
				try
				{
					List<IntPoint> list2 = new List<IntPoint>();
					foreach (Geopoint_Struct item in UncertaintyArea)
					{
						double num4 = item.Latitude;
						double num5 = item.Longitude;
						while (num5 > 180.0 || num5 < -180.0)
						{
							num5 = Math2.VisitClass(num5);
						}
						if (num4 > 90.0)
						{
							num4 = 90.0;
						}
						if (num4 < -90.0)
						{
							num4 = -90.0;
						}
						MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(num5, num4);
						Coordinate coordinate = new Coordinate(mercatorPixel.x, mercatorPixel.y);
						list2.Add(new IntPoint((long)Math.Round(coordinate[0]), (long)Math.Round(coordinate[1])));
					}
					List<List<IntPoint>> list3 = new List<List<IntPoint>>();
					list3.Add(list2);
					ClipperOffset clipperOffset = new ClipperOffset();
					clipperOffset.AddPaths(list3, JoinType.jtSquare, EndType.etClosedPolygon);
					List<List<IntPoint>> list_ = new List<List<IntPoint>>();
					clipperOffset.Execute(ref list_, num3);
					List<List<IntPoint>> list4 = list_;
					List<Geopoint_Struct> list5 = new List<Geopoint_Struct>(list4.Count);
					if (list4.Count == 0)
					{
						return;
					}
					foreach (IntPoint item2 in list4[0])
					{
						try
						{
							MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(item2.X, item2.Y);
							list5.Add(new Geopoint_Struct(tCoord.Lon, tCoord.Lat));
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 200002", "");
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (list5.Count > 100)
					{
						list5 = Math2.SimplifyArea(list5);
					}
					UncertaintyArea = list5;
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 200287", exception_2.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			DetermineNextGrow(ref scenario_0);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100498", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Teleport(ref Scenario scenario_0, double double_0, double double_1)
	{
		base.Teleport(ref scenario_0, double_0, double_1);
		ActualUnit.Teleport(ref scenario_0, double_0, double_1);
	}

	private void SetImporter(object sender, NotifyDictionaryChangedEventArgs<int, EmissionContainer> e)
	{
		ListOfESMMatches = null;
	}

	public Contact Clone()
	{
		Contact contact = (Contact)MemberwiseClone();
		try
		{
			contact.ObjectID_Set(Guid.NewGuid().ToString());
			contact.InsertImporter(new ObservableDictionary<int, EmissionContainer>());
			if (!Information.IsNothing(UpdateImporter()))
			{
				contact.UpdateImporter().AddRange(UpdateImporter());
			}
			contact.messageObserver = null;
			contact.productObserver = new List<HostedUnitReconRecord>();
			if (!Information.IsNothing(productObserver))
			{
				contact.productObserver.AddRange(productObserver);
			}
			contact.annotationObserver = new List<Geopoint_Struct>();
			if (!Information.IsNothing(annotationObserver))
			{
				contact.annotationObserver.AddRange(annotationObserver);
			}
			contact.ListOfESMMatches = new List<int>();
			if (!Information.IsNothing(ListOfESMMatches))
			{
				contact.ListOfESMMatches.AddRange(ListOfESMMatches);
			}
			contact._AlgoObserver = new Dictionary<Side, Misc.PostureStance>(_AlgoObserver.Count);
			if (!Information.IsNothing(_AlgoObserver))
			{
				foreach (KeyValuePair<Side, Misc.PostureStance> item in _AlgoObserver)
				{
					contact._AlgoObserver.Add(item.Key, item.Value);
				}
			}
			return contact;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101418", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public void AddDetectionRecord((string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime) valueTuple_0)
	{
		LastDetections.Enqueue(valueTuple_0);
		while (LastDetections.Count > 50)
		{
			LastDetections.Dequeue();
		}
	}

	internal Doctrine._WRA_WeaponTargetType FillImporter(Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		if (ActualUnit != null && ActualUnit.HasEmittingRadars)
		{
			if (ActualUnit.IsAircraft | ActualUnit.IsSubmarine)
			{
				return _WRA_WeaponTargetType_0;
			}
			return Doctrine._WRA_WeaponTargetType.Radar_Unspecified;
		}
		return _WRA_WeaponTargetType_0;
	}

	[CompilerGenerated]
	private Sensor CalculateImporter(KeyValuePair<int, EmissionContainer> keyValuePair_0)
	{
		KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
		EmissionContainer value = keyValuePair.Value;
		keyValuePair = keyValuePair_0;
		return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
	}

	[CompilerGenerated]
	private Sensor PopImporter(KeyValuePair<int, EmissionContainer> keyValuePair_0)
	{
		KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
		EmissionContainer value = keyValuePair.Value;
		keyValuePair = keyValuePair_0;
		return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
	}

	[CompilerGenerated]
	private Sensor InstantiateImporter(KeyValuePair<int, EmissionContainer> keyValuePair_0)
	{
		KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
		EmissionContainer value = keyValuePair.Value;
		keyValuePair = keyValuePair_0;
		return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
	}

	[CompilerGenerated]
	private Sensor CreateImporter(KeyValuePair<int, EmissionContainer> keyValuePair_0)
	{
		KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
		EmissionContainer value = keyValuePair.Value;
		keyValuePair = keyValuePair_0;
		return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
	}

	[CompilerGenerated]
	private Sensor CompareImporter(KeyValuePair<int, EmissionContainer> keyValuePair_0)
	{
		KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
		EmissionContainer value = keyValuePair.Value;
		keyValuePair = keyValuePair_0;
		return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
	}

	[CompilerGenerated]
	private Sensor ReadImporter(KeyValuePair<int, EmissionContainer> keyValuePair_0)
	{
		KeyValuePair<int, EmissionContainer> keyValuePair = keyValuePair_0;
		EmissionContainer value = keyValuePair.Value;
		keyValuePair = keyValuePair_0;
		return value.GetAssociatedSensor(keyValuePair.Key, ActualUnit.ParentScen);
	}

	[CompilerGenerated]
	private bool DisableImporter(Contact contact_0)
	{
		if (!Information.IsNothing(contact_0.ActualUnit))
		{
			return Operators.CompareString(contact_0.ActualUnit.ObjectID, ActualUnit.ObjectID, TextCompare: false) == 0;
		}
		return false;
	}
}
