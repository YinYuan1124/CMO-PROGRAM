using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Command_Core.DAL;
using DotSpatial.Topology;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Spatial.Euclidean;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public class ActiveUnit_Sensory
{
	public delegate void NewContactDetectedEventHandler(Side DetectingSide, Contact_Base.ContactType ContactType);

	public enum SensoryType
	{
		None,
		Radar,
		ESM,
		Visual,
		IR,
		Sonar_Active,
		Sonar_Passive,
		Magnetic,
		Laser
	}

	public enum SpecialDetectionMode
	{
		None,
		SubAssumedFromTorpedoDetection,
		SubAssumedFromMissileDetection,
		FlamingDatum,
		AutoDetection,
		MissileAssumedFromSemiActiveIllumination,
		LuaScript,
		CounterBatteryTrack
	}

	public class EligibleContactEntry
	{
		public ActiveUnit ActiveUnit;

		public Sensor[] SensorList;

		public EligibleContactEntry(ref ActiveUnit activeUnit_0, ref Sensor[] sensor_0)
		{
			ActiveUnit = activeUnit_0;
			SensorList = sensor_0;
		}
	}

	public class GClass3
	{
		public UnguidedWeapon NonAU_Weapon;

		public Sensor[] SensorList;

		public GClass3(ref UnguidedWeapon unguidedWeapon_0, ref Sensor[] sensor_0)
		{
			NonAU_Weapon = unguidedWeapon_0;
			SensorList = sensor_0;
		}
	}

	public class ContactEntry_Local : ScenarioObject
	{
		public float TimeSinceDetection;

		public float? TimeSinceDetection_Radar;

		public float? TimeSinceDetection_ESM;

		public float? TimeSinceDetection_Visual;

		public float? TimeSinceDetection_Infrared;

		public float? TimeSinceDetection_SonarActive;

		public float? TimeSinceDetection_SonarPassive;

		public Contact Contact;

		public float NoDetectionCount;

		public void ToXML(ref XmlWriter xmlWriter_0, Side side_0)
		{
			try
			{
				if (!Information.IsNothing(Contact) && side_0.Contacts.ContainsKey(Contact.ActualUnit.ObjectID))
				{
					xmlWriter_0.WriteStartElement("ContactEntry");
					xmlWriter_0.WriteElementString("Contact", Contact.ActualUnit.ObjectID);
					xmlWriter_0.WriteElementString("TSD", TimeSinceDetection.ToString());
					if (!Information.IsNothing(TimeSinceDetection_Radar))
					{
						xmlWriter_0.WriteElementString("TSD_Radar", TimeSinceDetection_Radar.ToString());
					}
					if (!Information.IsNothing(TimeSinceDetection_ESM))
					{
						xmlWriter_0.WriteElementString("TSD_ESM", TimeSinceDetection_ESM.ToString());
					}
					if (!Information.IsNothing(TimeSinceDetection_Visual))
					{
						xmlWriter_0.WriteElementString("TSD_Visual", TimeSinceDetection_Visual.ToString());
					}
					if (!Information.IsNothing(TimeSinceDetection_Infrared))
					{
						xmlWriter_0.WriteElementString("TSD_Infrared", TimeSinceDetection_Infrared.ToString());
					}
					if (!Information.IsNothing(TimeSinceDetection_SonarActive))
					{
						xmlWriter_0.WriteElementString("TSD_SonarActive", TimeSinceDetection_SonarActive.ToString());
					}
					if (!Information.IsNothing(TimeSinceDetection_SonarPassive))
					{
						xmlWriter_0.WriteElementString("TSD_SonarPassive", TimeSinceDetection_SonarPassive.ToString());
					}
					xmlWriter_0.WriteElementString("NDC", NoDetectionCount.ToString());
					xmlWriter_0.WriteEndElement();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101217", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static ContactEntry_Local FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref string string_0)
		{
			try
			{
				ContactEntry_Local contactEntry_Local = new ContactEntry_Local();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						switch (xmlNode.Name)
						{
						case "TSD_Visual":
						case "TimeSinceDetection_Visual":
							contactEntry_Local.TimeSinceDetection_Visual = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "TimeSinceDetection":
						case "TSD":
							contactEntry_Local.TimeSinceDetection = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "NoDetectionCount":
						case "NDC":
							contactEntry_Local.NoDetectionCount = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "Contact":
							contactEntry_Local.Contact = null;
							string_0 = xmlNode.InnerText;
							break;
						case "TimeSinceDetection_Radar":
						case "TSD_Radar":
							contactEntry_Local.TimeSinceDetection_Radar = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "TSD_SonarPassive":
						case "TimeSinceDetection_SonarPassive":
							contactEntry_Local.TimeSinceDetection_SonarPassive = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "TimeSinceDetection_Infrared":
						case "TSD_Infrared":
							contactEntry_Local.TimeSinceDetection_Infrared = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "TSD_SonarActive":
						case "TimeSinceDetection_SonarActive":
							contactEntry_Local.TimeSinceDetection_SonarActive = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "TimeSinceDetection_ESM":
						case "TSD_ESM":
							contactEntry_Local.TimeSinceDetection_ESM = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
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
				return contactEntry_Local;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101218", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ContactEntry_Local result = new ContactEntry_Local();
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public ContactEntry_Local()
		{
			TimeSinceDetection = 0f;
			NoDetectionCount = 0f;
		}
	}

	[CompilerGenerated]
	private sealed class RepositoryComparator
	{
		public float Local_elapsedTime;

		public ActiveUnit_Sensory Me;

		internal void CustomizeInterruptibleTag(Contact theC)
		{
			theC?.PostPulseHousekeeping(Local_elapsedTime, Me.strategyWrapper.GetUnitSide(), Me.strategyWrapper.ParentScen, bool_0: true);
		}
	}

	internal ActiveUnit strategyWrapper;

	protected bool _ObeysEMCON;

	private bool configurationWrapper;

	internal ConcurrentQueue<Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>> _TokenWrapper;

	internal ConcurrentQueue<string> _IndexerWrapper;

	private List<Contact> m_ResolverWrapper;

	internal TDictionary<long, LoggedMessage> m_PublisherWrapper;

	public TDictionary<string, Contact> NewContactsQueue_Local;

	public TDictionary<string, Contact> DroppedContactsQueue_Local;

	public bool HadActiveSensorInLastPulse;

	protected Dictionary<string, Contact> _ContactsList_OffGrid;

	protected List<string> _ContactsList_OffGrid_NonAU;

	private List<ActiveUnit> m_ServerWrapper;

	private List<ActiveUnit> adapterWrapper;

	private Dictionary<bool, List<ActiveUnit>> _SchemaWrapper;

	internal ActiveEmissionInterval m_UtilsWrapper;

	[ThreadStatic]
	private List<Sensor> predicateWrapper;

	[CompilerGenerated]
	[AccessedThroughProperty("__ContactsList_Local")]
	private ObservableDictionary<string, ContactEntry_Local> _SingletonWrapper;

	private List<Contact> recordWrapper;

	private object _ExceptionWrapper;

	private List<EligibleContactEntry> attrWrapper;

	private List<EligibleContactEntry> _VisitorWrapper;

	private List<EligibleContactEntry> _ExporterWrapper;

	private List<EligibleContactEntry> m_PrototypeWrapper;

	private List<ActiveUnit> _ComparatorWrapper;

	private List<ActiveUnit> _ItemWrapper;

	[ThreadStatic]
	private List<EligibleContactEntry> m_SetterWrapper;

	private ObservableDictionary<string, Contact> creatorWrapper;

	[CompilerGenerated]
	private static NewContactDetectedEventHandler templateWrapper;

	protected ObservableDictionary<string, ContactEntry_Local> _ContactsList_Local
	{
		get
		{
			if (SetConsumer() == null)
			{
				FillConsumer(new ObservableDictionary<string, ContactEntry_Local>());
			}
			return SetConsumer();
		}
	}

	public virtual bool Boolean_0
	{
		get
		{
			return _ObeysEMCON;
		}
		set
		{
			_ObeysEMCON = value;
			if (value)
			{
				vmethod_0(strategyWrapper.Sensors_Cached);
			}
		}
	}

	public bool HasOperationalTowedArray
	{
		get
		{
			try
			{
				Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
				int num = 0;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						Sensor sensor = sensors_Cached[num];
						if (sensor.Status == PlatformComponent._ComponentStatus.Operational && sensor.IsTowedArray)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100236", "");
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

	public bool HasEyeballOperating
	{
		get
		{
			try
			{
				Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
				Sensor[] array = sensors_Cached;
				foreach (Sensor sensor in array)
				{
					if (sensor.m_IsMk1Eyeball && sensor.IsOperating)
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
				exception_?.Data.Add("Error at 1002384", "");
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

	public bool JammerUnitsAreAffectingMe
	{
		get
		{
			try
			{
				if (strategyWrapper.IsSatellite)
				{
					return false;
				}
				if (strategyWrapper.IsSubmarine && Math.Round(strategyWrapper.GetCurrentAltitude()) < -20.0)
				{
					return false;
				}
				new HashSet<ActiveUnit>();
				Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
				if (sensors_Cached == null)
				{
					return false;
				}
				bool flag = false;
				Sensor sensor = null;
				int num = sensors_Cached.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					sensor = sensors_Cached[i];
					if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.IsActive)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					Side[] sides_ReadOnly = strategyWrapper.ParentScen.Sides_ReadOnly;
					Side[] array = sides_ReadOnly;
					foreach (Side side in array)
					{
						if (side == strategyWrapper.GetUnitSide() || Module_Side.IsAlliedWithThisSide(strategyWrapper.GetUnitSide(), side) || side.GetUnitsEngagedInOECM(bool_0: false) == null)
						{
							continue;
						}
						for (int j = side.GetUnitsEngagedInOECM(bool_0: false).Count - 1; j >= 0; j += -1)
						{
							ActiveUnit activeUnit_;
							try
							{
								activeUnit_ = side.GetUnitsEngagedInOECM(bool_0: false)[j];
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception exception_ = ex;
								exception_?.Data.Add("Error at 200432", exception_.Message);
								GameGeneral.WriteExceptionsToLog(ref exception_);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								continue;
							}
							if (PublishDic(activeUnit_))
							{
								return true;
							}
						}
					}
					return false;
				}
				return false;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100239", "");
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

	public bool HasAvailableDippingSonar
	{
		get
		{
			try
			{
				Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
				Sensor[] array = sensors_Cached;
				foreach (Sensor sensor in array)
				{
					if (sensor.IsDippingSonar && sensor.Status == PlatformComponent._ComponentStatus.Operational)
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
				exception_?.Data.Add("Error at 100267", "");
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

	public List<Sensor> GetSensors_AirSearch
	{
		get
		{
			try
			{
				Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
				if (sensors_Cached == null)
				{
					return new List<Sensor>();
				}
				int num = sensors_Cached.Length;
				List<Sensor> list = new List<Sensor>();
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Sensor sensor = sensors_Cached[i];
					if ((sensor.CanPerformVolumeSearch || sensor.TargetsTrackedForFireControl_Readonly.Count != 0) && (sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite) || sensor.Capabilities.SpaceSearch_ABM || sensor.Capabilities.C_RAM))
					{
						list.Add(sensor);
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100272", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Sensor> result = new List<Sensor>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public ObservableDictionary<string, Contact> Contacts_Local_ReadOnly
	{
		get
		{
			try
			{
				if (Information.IsNothing(creatorWrapper))
				{
					ObservableDictionary<string, Contact> val = new ObservableDictionary<string, Contact>();
					foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
					{
						if (item.Value.Contact == null)
						{
							DroppedContactsQueue_Local.AddIfNotExistsElseUpdate(item.Key, null);
						}
						else
						{
							val.Add(item.Key, item.Value.Contact);
						}
					}
					creatorWrapper = val;
				}
				return creatorWrapper;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101216", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ObservableDictionary<string, Contact> result = new ObservableDictionary<string, Contact>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public static event NewContactDetectedEventHandler NewContactDetected
	{
		[CompilerGenerated]
		add
		{
			NewContactDetectedEventHandler newContactDetectedEventHandler = templateWrapper;
			NewContactDetectedEventHandler newContactDetectedEventHandler2;
			do
			{
				newContactDetectedEventHandler2 = newContactDetectedEventHandler;
				NewContactDetectedEventHandler value2 = (NewContactDetectedEventHandler)Delegate.Combine(newContactDetectedEventHandler2, value);
				newContactDetectedEventHandler = Interlocked.CompareExchange(ref templateWrapper, value2, newContactDetectedEventHandler2);
			}
			while ((object)newContactDetectedEventHandler != newContactDetectedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NewContactDetectedEventHandler newContactDetectedEventHandler = templateWrapper;
			NewContactDetectedEventHandler newContactDetectedEventHandler2;
			do
			{
				newContactDetectedEventHandler2 = newContactDetectedEventHandler;
				NewContactDetectedEventHandler value2 = (NewContactDetectedEventHandler)Delegate.Remove(newContactDetectedEventHandler2, value);
				newContactDetectedEventHandler = Interlocked.CompareExchange(ref templateWrapper, value2, newContactDetectedEventHandler2);
			}
			while ((object)newContactDetectedEventHandler != newContactDetectedEventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ObservableDictionary<string, ContactEntry_Local> SetConsumer()
	{
		return _SingletonWrapper;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void FillConsumer(ObservableDictionary<string, ContactEntry_Local> observableDictionary_0)
	{
		INotifyDictionaryChanged<string, ContactEntry_Local>.DictionaryChangedEventHandler val = EnableConsumer;
		ObservableDictionary<string, ContactEntry_Local> singletonWrapper = _SingletonWrapper;
		if (singletonWrapper != null)
		{
			singletonWrapper.DictionaryChanged -= val;
		}
		_SingletonWrapper = observableDictionary_0;
		singletonWrapper = _SingletonWrapper;
		if (singletonWrapper != null)
		{
			singletonWrapper.DictionaryChanged += val;
		}
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Sensory");
			xmlWriter_0.WriteElementString("ObE", _ObeysEMCON.ToString());
			if (_ContactsList_Local.Count > 0)
			{
				xmlWriter_0.WriteStartElement("ContactList_Local");
				try
				{
					foreach (ContactEntry_Local item in _ContactsList_Local.Values.ToList())
					{
						if (!Information.IsNothing(item.Contact) && !Information.IsNothing(item.Contact.ActualUnit))
						{
							item.ToXML(ref xmlWriter_0, strategyWrapper.GetUnitSide());
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
				finally
				{
					xmlWriter_0.WriteEndElement();
				}
			}
			if (_ContactsList_OffGrid.Count > 0)
			{
				xmlWriter_0.WriteStartElement("ContactList_OffGrid");
				foreach (Contact item2 in _ContactsList_OffGrid.Values.ToList())
				{
					if (item2.ActualUnit != null)
					{
						xmlWriter_0.WriteRaw(item2.ToXML(null, strategyWrapper.GetUnitSide()));
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(m_UtilsWrapper))
			{
				m_UtilsWrapper.ToXML(ref xmlWriter_0);
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100234", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Sensory FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_Sensory activeUnit_Sensory = new ActiveUnit_Sensory();
			activeUnit_Sensory.strategyWrapper = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				string string_ = null;
				IEnumerator enumerator3 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "ObE":
					case "ObeysEMCON":
						activeUnit_Sensory._ObeysEMCON = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "EmissionInterval":
						activeUnit_Sensory.m_UtilsWrapper = ActiveEmissionInterval.FromXML(ref xmlNode_);
						activeUnit_Sensory.m_UtilsWrapper?.Initialize(activeUnit_Sensory);
						break;
					case "ContactList_OffGrid":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator3.Current;
								Contact contact = Contact.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
								activeUnit_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
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
					case "ContactList":
					case "ContactList_Local":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								ContactEntry_Local contactEntry_Local = ContactEntry_Local.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref string_);
								if (!Information.IsNothing(string_) && !activeUnit_Sensory._ContactsList_Local.ContainsKey(string_))
								{
									activeUnit_Sensory._ContactsList_Local.Add(string_, contactEntry_Local);
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
			return activeUnit_Sensory;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100235", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_Sensory result = new ActiveUnit_Sensory();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal ActiveUnit ResolveDic()
	{
		return strategyWrapper;
	}

	internal bool PostDic(Contact contact_0)
	{
		Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
		for (int i = 0; i < sensors_Cached.Length; i = checked(i + 1))
		{
			if (sensors_Cached[i].GetCanTrackThisContact_AAWFireControlGrade(contact_0))
			{
				return true;
			}
		}
		return false;
	}

	internal bool RunDic(Contact contact_0, float float_0, Sensor.Sensor_Type sensor_Type_0)
	{
		if (contact_0.ActualUnit != null && contact_0.ActualUnit.GetIsAutoDetectable(strategyWrapper.GetUnitSide()))
		{
			return true;
		}
		if (_ContactsList_Local.Count == 0)
		{
			return false;
		}
		foreach (ContactEntry_Local item in new List<ContactEntry_Local>(_ContactsList_Local.Values))
		{
			try
			{
				if (item == null || item.Contact == null || !ContactsAreOfSameActualUnit(item.Contact, contact_0))
				{
					continue;
				}
				switch (sensor_Type_0)
				{
				case Sensor.Sensor_Type.ESM:
					if (item.TimeSinceDetection_ESM.HasValue)
					{
						float? timeSinceDetection_ESM = item.TimeSinceDetection_ESM;
						if ((timeSinceDetection_ESM.HasValue ? new bool?(timeSinceDetection_ESM.GetValueOrDefault() <= float_0) : null).GetValueOrDefault())
						{
							return true;
						}
						return false;
					}
					return false;
				case Sensor.Sensor_Type.Radar:
				case Sensor.Sensor_Type.SemiActive:
					if (item.TimeSinceDetection_Radar.HasValue)
					{
						float? timeSinceDetection_Radar = item.TimeSinceDetection_Radar;
						if ((timeSinceDetection_Radar.HasValue ? new bool?(timeSinceDetection_Radar.GetValueOrDefault() <= float_0) : null).GetValueOrDefault())
						{
							return true;
						}
						return false;
					}
					return false;
				case Sensor.Sensor_Type.Visual:
					if (item.TimeSinceDetection_Visual.HasValue)
					{
						float? timeSinceDetection_Visual = item.TimeSinceDetection_Visual;
						if ((timeSinceDetection_Visual.HasValue ? new bool?(timeSinceDetection_Visual.GetValueOrDefault() <= float_0) : null).GetValueOrDefault())
						{
							return true;
						}
						return false;
					}
					return false;
				case Sensor.Sensor_Type.Infrared:
					if (item.TimeSinceDetection_Infrared.HasValue)
					{
						float? timeSinceDetection_Infrared = item.TimeSinceDetection_Infrared;
						if ((timeSinceDetection_Infrared.HasValue ? new bool?(timeSinceDetection_Infrared.GetValueOrDefault() <= float_0) : null).GetValueOrDefault())
						{
							return true;
						}
						return false;
					}
					return false;
				case Sensor.Sensor_Type.None:
					if (item.TimeSinceDetection <= float_0)
					{
						return true;
					}
					return false;
				case Sensor.Sensor_Type.HullSonar_ActivePassive:
				case Sensor.Sensor_Type.HullSonar_ActiveOnly:
				case Sensor.Sensor_Type.TowedArray_ActivePassive:
				case Sensor.Sensor_Type.TowedArray_ActiveOnly:
				case Sensor.Sensor_Type.VDS_ActivePassive:
				case Sensor.Sensor_Type.VDS_ActiveOnly:
				case Sensor.Sensor_Type.DippingSonar_ActivePassive:
				case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
					if (item.TimeSinceDetection_SonarActive.HasValue)
					{
						float? timeSinceDetection_SonarActive = item.TimeSinceDetection_SonarActive;
						if ((timeSinceDetection_SonarActive.HasValue ? new bool?(timeSinceDetection_SonarActive.GetValueOrDefault() <= float_0) : null).GetValueOrDefault())
						{
							return true;
						}
						return false;
					}
					return false;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						break;
					}
					return false;
				case Sensor.Sensor_Type.LaserDesignator:
				case Sensor.Sensor_Type.LaserSpotTracker:
				case Sensor.Sensor_Type.LaserRangefinder:
				case Sensor.Sensor_Type.PingIntercept:
					return false;
				case Sensor.Sensor_Type.HullSonar_PassiveOnly:
				case Sensor.Sensor_Type.TowedArray_PassiveOnly:
				case Sensor.Sensor_Type.VDS_PassiveOnly:
				case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
				case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
					if (item.TimeSinceDetection_SonarPassive.HasValue)
					{
						float? timeSinceDetection_SonarPassive = item.TimeSinceDetection_SonarPassive;
						if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= float_0) : null).GetValueOrDefault())
						{
							return true;
						}
						return false;
					}
					return false;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		return false;
	}

	private ActiveUnit_Sensory()
	{
		m_ResolverWrapper = new List<Contact>();
		m_PublisherWrapper = new TDictionary<long, LoggedMessage>();
		NewContactsQueue_Local = new TDictionary<string, Contact>();
		DroppedContactsQueue_Local = new TDictionary<string, Contact>();
		HadActiveSensorInLastPulse = false;
		_ContactsList_OffGrid = new Dictionary<string, Contact>();
		_ContactsList_OffGrid_NonAU = new List<string>();
		m_ServerWrapper = new List<ActiveUnit>();
		adapterWrapper = new List<ActiveUnit>();
		_SchemaWrapper = new Dictionary<bool, List<ActiveUnit>>();
		_ExceptionWrapper = RuntimeHelpers.GetObjectValue(new object());
	}

	internal void StartDic()
	{
		_ContactsList_Local.Clear();
	}

	internal void AssetDic()
	{
		foreach (Contact contacts_ in strategyWrapper.GetUnitSide().Contacts_List)
		{
			if (!Information.IsNothing(contacts_.ActualUnit))
			{
				Contact contact = contacts_.Clone();
				contact.RemainingContinousTrackTime = 0f;
				contact.RemainingContinousTrackTime_Precise = 0f;
				_ContactsList_OffGrid.Add(contact.ActualUnit.ObjectID, contact);
			}
		}
	}

	public void RejoinCommsGrid()
	{
		strategyWrapper.AddMessage(strategyWrapper.Name + "重新加入了通信网络。", "通信问题", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(strategyWrapper.GetLongitude(), strategyWrapper.GetLatitude()));
		foreach (KeyValuePair<string, Contact> item in _ContactsList_OffGrid)
		{
			if (item.Value.ActualUnit == null)
			{
				strategyWrapper.AI.DropTarget(item.Value);
				continue;
			}
			if (Information.IsNothing(item.Value.ActualUnit.GetUnitSide()))
			{
				strategyWrapper.AI.DropTarget(item.Value);
				continue;
			}
			Side unitSide = item.Value.ActualUnit.GetUnitSide();
			if (unitSide == strategyWrapper.GetUnitSide())
			{
				strategyWrapper.AI.DropTarget(item.Value);
			}
			else if (unitSide.GetConsidersThisSideToBe(strategyWrapper.GetUnitSide()) == Misc.PostureStance.Friendly)
			{
				strategyWrapper.AI.DropTarget(item.Value);
			}
			else if (strategyWrapper.GetUnitSide().Contacts.ContainsKey(item.Key))
			{
				_ = strategyWrapper.GetUnitSide().Contacts[item.Key];
				Module_Side.UpdateMasterContactDataFromOtherContact(strategyWrapper.GetUnitSide(), strategyWrapper.GetUnitSide().Contacts[item.Key], item.Value, strategyWrapper, strategyWrapper.ParentScen, bool_0: true);
			}
			else
			{
				strategyWrapper.AddMessage("新延误目标：" + item.Value.Name, "目标报告", LoggedMessage.MessageType.ContactChange, 0, bool_0: false, new Geopoint_Struct(item.Value.GetLongitude(), item.Value.GetLatitude()));
				strategyWrapper.GetUnitSide().AddContact(item.Value);
				item.Value.SetIsPrivate(strategyWrapper.GetUnitSide(), bool_0: false);
			}
		}
		_ContactsList_OffGrid.Clear();
		List<Contact> list = new List<Contact>();
		foreach (Contact contacts_ in strategyWrapper.GetUnitSide().Contacts_List)
		{
			if (!Information.IsNothing(contacts_.ActualUnit) && contacts_.ActualUnit == strategyWrapper)
			{
				list.Add(contacts_);
			}
		}
		foreach (Contact item2 in list)
		{
			strategyWrapper.GetUnitSide().DropContact(item2, ref strategyWrapper.ParentScen, bool_0: false);
		}
	}

	public List<Contact> PrivateContactList()
	{
		if (_ContactsList_OffGrid.Count == 0)
		{
			if (recordWrapper == null)
			{
				recordWrapper = new List<Contact>();
			}
			else
			{
				recordWrapper.Clear();
			}
			return recordWrapper;
		}
		recordWrapper = new List<Contact>(_ContactsList_OffGrid.Values);
		return recordWrapper;
	}

	private void PrintDic()
	{
		if (GetJammerUnitsAffectingMe(bool_0: true).Count > 0 != configurationWrapper)
		{
			if (configurationWrapper)
			{
				configurationWrapper = false;
			}
			else
			{
				configurationWrapper = true;
			}
		}
	}

	public void ActivateSensorsToHelpDatalinkedOrSemiActiveGuidedWeapons(Sensor[] sensor_0)
	{
		List<Weapon> list = strategyWrapper.Weaponry.DeleteFacade();
		Sensor[] array;
		if (list.Count > 0)
		{
			array = sensor_0;
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				foreach (Weapon item in list)
				{
					if (sensor.CanBeActive && sensor.GetCanTrackThisContact_AAWFireControlGrade(item.AI.PrimaryTarget))
					{
						sensor.GoActive();
						break;
					}
				}
			}
		}
		List<Weapon> list2 = strategyWrapper.Weaponry.MoveFacade();
		if (list2.Count <= 0)
		{
			return;
		}
		array = sensor_0;
		Sensor[] array3 = array;
		foreach (Sensor sensor2 in array3)
		{
			if (!sensor2.CanBeActive || sensor2.IsActive)
			{
				continue;
			}
			foreach (Weapon item2 in list2)
			{
				Weapon weapon_ = item2;
				if (sensor2.CanIlluminateForThisWeapon(ref weapon_))
				{
					sensor2.GoActive();
					break;
				}
			}
		}
	}

	public virtual void vmethod_0(Sensor[] sensor_0)
	{
		try
		{
			if (strategyWrapper.IsGroup)
			{
				return;
			}
			if (strategyWrapper.IsSatellite)
			{
				foreach (Sensor sensor in sensor_0)
				{
					if (sensor.CanBeActive)
					{
						sensor.GoActive();
					}
				}
				return;
			}
			if (strategyWrapper.IsWeapon && ((Weapon)strategyWrapper).IsDecoy)
			{
				foreach (Sensor sensor2 in sensor_0)
				{
					if (sensor2.IsOECM && !sensor2.IsActive)
					{
						sensor2.GoActive();
					}
				}
			}
			if (!Boolean_0)
			{
				return;
			}
			Doctrine.EMCONSettings eMCONSettings = strategyWrapper.Doctrine.NewRepository(strategyWrapper.ParentScen);
			bool bool_ = false;
			if (eMCONSettings.HasActiveEmissions() && !Information.IsNothing(strategyWrapper.AssignedMissionOrPackage()))
			{
				if (strategyWrapper.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					if (((Patrol)strategyWrapper.AssignedMissionOrPackage()).ActiveEMCONOnlyInPatrolOrProsecutionArea)
					{
						Patrol patrol = (Patrol)strategyWrapper.AssignedMissionOrPackage();
						if (strategyWrapper.IsAircraft)
						{
							if (!strategyWrapper.Navigator.DisableDic(ref patrol.PatrolArea, ref patrol.PatrolArea_5nm_Buffered, ref patrol.PatrolArea_5nm_ChangeCheck, 5, bool_1: true, bool_2: false) && !strategyWrapper.Navigator.DisableDic(ref patrol.ProsecutionArea, ref patrol.ProsecutionArea_5nm_Buffered, ref patrol.ProsecutionArea_5nm_ChangeCheck, 5, bool_1: true, bool_2: true))
							{
								bool_ = true;
							}
						}
						else if (!strategyWrapper.Navigator.DisableDic(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, bool_1: true, bool_2: false) && !strategyWrapper.Navigator.DisableDic(ref patrol.ProsecutionArea, ref patrol.ProsecutionArea_2nm_Buffered, ref patrol.ProsecutionArea_2nm_ChangeCheck, 2, bool_1: true, bool_2: true))
						{
							bool_ = true;
						}
					}
				}
				else if (strategyWrapper.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support && ((SupportMission)strategyWrapper.AssignedMissionOrPackage()).ActiveEMCONOnlyOnStation && strategyWrapper.Navigator.IsInSupportTransit)
				{
					bool_ = true;
				}
			}
			int num = sensor_0.Count() - 1;
			Sensor sensor_ = null;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					sensor_ = sensor_0[i];
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200429", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				DefineDic(sensor_, eMCONSettings, bool_);
			}
			if (!strategyWrapper.IsMCMPlatform)
			{
				return;
			}
			IEnumerable<Sensor> mineCountermeasures = strategyWrapper.MineCountermeasures;
			if (mineCountermeasures.Count() <= 0)
			{
				return;
			}
			int num2 = mineCountermeasures.Count() - 1;
			for (int j = 0; j <= num2; j++)
			{
				try
				{
					sensor_ = mineCountermeasures.ElementAtOrDefault(j);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 200430", exception_2.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				DefineDic(sensor_, eMCONSettings, bool_);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100237", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DefineDic(Sensor sensor_0, Doctrine.EMCONSettings emconsettings_0, bool bool_0)
	{
		if (sensor_0 == null || !sensor_0.CanBeActive)
		{
			return;
		}
		try
		{
			if (sensor_0.IsPureIlluminator)
			{
				if (sensor_0.SemiActiveWeaponsGuided.Count == 0)
				{
					sensor_0.GoPassive();
				}
			}
			else
			{
				if (sensor_0.TargetsTrackedForFireControl_Readonly.Count > 0)
				{
					return;
				}
				bool flag = false;
				if (sensor_0.Type == Sensor.Sensor_Type.Radar)
				{
					if (emconsettings_0.LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active && !bool_0)
					{
						flag = true;
					}
					else if (sensor_0.TargetsTrackedForFireControl_Readonly.Count == 0)
					{
						flag = false;
					}
					if (!flag && ((strategyWrapper.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive) & (strategyWrapper.AI.PrimaryTarget != null)))
					{
						ActiveUnit_Weaponry weaponry = strategyWrapper.Weaponry;
						Contact primaryTarget = strategyWrapper.AI.PrimaryTarget;
						Doctrine._GunStrafeGroundTargets? nullable_ = null;
						foreach (Weapon item in weaponry.PrepareConsumer(primaryTarget, ref nullable_))
						{
							ActiveUnit_Weaponry weaponry2 = strategyWrapper.Weaponry;
							Contact primaryTarget2 = strategyWrapper.AI.PrimaryTarget;
							short? nullable_2 = null;
							Sensor sensor_ = null;
							if (weaponry2.CanThisWeaponEngageThisTarget(item, primaryTarget2, ref nullable_2, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						CommLink[] commLinksEstablished_ReadOnly = strategyWrapper.CommStuff.CommLinksEstablished_ReadOnly;
						CommLink[] array = commLinksEstablished_ReadOnly;
						foreach (CommLink commLink in array)
						{
							if (commLink != null && commLink.CommPartner != null && commLink.CommPartner.IsWeapon)
							{
								Weapon weapon = (Weapon)commLink.CommPartner;
								if (weapon.IsAAW && weapon.IsSemiAutonomous)
								{
									flag = true;
									break;
								}
							}
						}
					}
				}
				if (sensor_0.IsOECM)
				{
					flag = ((emconsettings_0.OECM() == Doctrine.EMCONSettings._EMCONSetting.Active && !bool_0) ? true : false);
				}
				if (sensor_0.IsSonar && sensor_0.CanBeActive)
				{
					flag = (sensor_0.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly && strategyWrapper.IsAircraft && ((Aircraft)strategyWrapper).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar) || ((emconsettings_0.GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active && !bool_0) ? true : false);
				}
				if (strategyWrapper.IsMCMPlatform && strategyWrapper.IsOnActiveMineClearingMission)
				{
					MineClearingMission mineClearingMission = (MineClearingMission)strategyWrapper.AssignedMissionOrPackage();
					if (strategyWrapper.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false))
					{
						if (strategyWrapper.IsAircraft && (strategyWrapper.GetCurrentAltitude() > 76.5048f || strategyWrapper.CurrentSpeed > 30f))
						{
							flag = false;
						}
						else if ((strategyWrapper.IsShip || strategyWrapper.IsSubmarine) && (strategyWrapper.IsRTB || strategyWrapper.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder) && sensor_0.IsMineCountermeasure)
						{
							flag = false;
						}
						else if ((sensor_0.IsMineCountermeasure || sensor_0.IsMineHuntingSensor) && sensor_0.CanBeActive)
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					sensor_0.GoActive();
				}
				else if (sensor_0.IsActive)
				{
					sensor_0.GoPassive();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200431", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public bool GetHasSensorsOperating(Sensor[] sensor_0)
	{
		try
		{
			if (Information.IsNothing(sensor_0))
			{
				sensor_0 = strategyWrapper.Sensors_Cached;
			}
			if (sensor_0.Length == 0)
			{
				return false;
			}
			Sensor[] array = sensor_0;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (array[num].IsOperating)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100238", "");
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
	public List<ActiveUnit> GetJammerUnitsAffectingMe(bool bool_0)
	{
		try
		{
			if (strategyWrapper.IsWeapon && ((Weapon)strategyWrapper).Flags.HomeOnJam)
			{
				return new List<ActiveUnit>();
			}
			if (_SchemaWrapper.ContainsKey(bool_0))
			{
				return _SchemaWrapper[bool_0];
			}
			HashSet<ActiveUnit> hashSet = new HashSet<ActiveUnit>();
			List<ActiveUnit> list = new List<ActiveUnit>();
			if (bool_0)
			{
				Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
				bool flag = false;
				Sensor sensor = null;
				int num = sensors_Cached.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					sensor = sensors_Cached[i];
					if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.IsActive)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list = hashSet.ToList();
					try
					{
						_SchemaWrapper.Add(bool_0, list);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200433", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					return list;
				}
			}
			Side[] sides_ReadOnly = strategyWrapper.ParentScen.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (Information.IsNothing(side) || Information.IsNothing(strategyWrapper.GetUnitSide()) || side == strategyWrapper.GetUnitSide() || Module_Side.IsAlliedWithThisSide(strategyWrapper.GetUnitSide(), side))
				{
					continue;
				}
				for (int j = side.GetUnitsEngagedInOECM(bool_0: false).Count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit = side.GetUnitsEngagedInOECM(bool_0: false)[j];
					if (PublishDic(activeUnit))
					{
						hashSet.Add(activeUnit);
					}
				}
			}
			list = hashSet.ToList();
			try
			{
				object exceptionWrapper = _ExceptionWrapper;
				ObjectFlowControl.CheckForSyncLockOnValueType(exceptionWrapper);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(exceptionWrapper, ref lockTaken);
					if (!_SchemaWrapper.ContainsKey(bool_0))
					{
						_SchemaWrapper.Add(bool_0, list);
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(exceptionWrapper);
					}
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 200434", exception_2.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return list;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100240", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private bool PublishDic(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 == null)
		{
			return false;
		}
		bool flag = false;
		Sensor[] sensors_Cached = activeUnit_0.Sensors_Cached;
		Sensor[] sensors_Cached2 = strategyWrapper.Sensors_Cached;
		try
		{
			if (sensors_Cached != null && sensors_Cached.Length != 0)
			{
				if (sensors_Cached2 != null && sensors_Cached2.Length != 0)
				{
					bool flag2 = false;
					for (int i = sensors_Cached.Count() - 1; i >= 0; i += -1)
					{
						Sensor sensor = sensors_Cached[i];
						if (sensor == null || !sensor.IsOECM)
						{
							continue;
						}
						if (sensor.IsOTH)
						{
							flag2 = true;
						}
						if (!sensor.IsActive || !sensor.TargetIsWithinCoverageArc(strategyWrapper))
						{
							continue;
						}
						for (int j = sensors_Cached2.Length - 1; j >= 0; j += -1)
						{
							Sensor sensor2 = sensors_Cached2[j];
							if (sensor2 != null && sensor2.TargetIsWithinCoverageArc(activeUnit_0) && sensor.GetCanJamThisSensor(sensor2))
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
					if (flag)
					{
						if (!flag2 && !Module_Unit.Has_Radar_LOS_ToUnit(strategyWrapper, null, activeUnit_0, ref strategyWrapper.ParentScen))
						{
							return false;
						}
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
			exception_?.Data.Add("Error at 200352", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public ActiveUnit_Sensory(ref ActiveUnit activeUnit_0)
	{
		m_ResolverWrapper = new List<Contact>();
		m_PublisherWrapper = new TDictionary<long, LoggedMessage>();
		NewContactsQueue_Local = new TDictionary<string, Contact>();
		DroppedContactsQueue_Local = new TDictionary<string, Contact>();
		HadActiveSensorInLastPulse = false;
		_ContactsList_OffGrid = new Dictionary<string, Contact>();
		_ContactsList_OffGrid_NonAU = new List<string>();
		m_ServerWrapper = new List<ActiveUnit>();
		adapterWrapper = new List<ActiveUnit>();
		_SchemaWrapper = new Dictionary<bool, List<ActiveUnit>>();
		_ExceptionWrapper = RuntimeHelpers.GetObjectValue(new object());
		strategyWrapper = activeUnit_0;
		_ObeysEMCON = true;
	}

	public static bool smethod_0(ActiveUnit activeUnit_0)
	{
		try
		{
			Sensor[] sensors_Cached = activeUnit_0.Sensors_Cached;
			if (sensors_Cached != null && sensors_Cached.Length != 0)
			{
				try
				{
					Sensor[] sensors_Cached2 = activeUnit_0.Sensors_Cached;
					if (sensors_Cached2 != null)
					{
						Sensor[] array = sensors_Cached2;
						Sensor[] array2 = array;
						foreach (Sensor sensor in array2)
						{
							if (sensor.IsOECM && sensor.IsActive)
							{
								return true;
							}
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					List<Sensor> list = activeUnit_0.Sensors_Cached?.ToList();
					if (list != null)
					{
						foreach (Sensor item in list)
						{
							if (item.IsOECM && item.IsActive)
							{
								ProjectData.ClearProjectError();
								return true;
							}
						}
					}
					ProjectData.ClearProjectError();
				}
			}
			return false;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private Sensor[] AwakeDic(Sensor[] sensor_0)
	{
		if (sensor_0.Length == 0)
		{
			return new Sensor[0];
		}
		List<Sensor> list = new List<Sensor>(sensor_0.Length);
		foreach (Sensor sensor in sensor_0)
		{
			if (sensor.CanPerformVolumeSearch && ResetDic(sensor) && (!sensor.CanBeActive || InterruptConsumer().AwakeIssuer()))
			{
				list.Add(sensor);
			}
		}
		int count = list.Count;
		if (count == 0)
		{
			return new Sensor[0];
		}
		Sensor[] array = new Sensor[count - 1 + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			array[i] = list[i];
		}
		return array;
	}

	private List<Sensor> QueryDic(Sensor[] sensor_0)
	{
		List<Sensor> list = new List<Sensor>();
		foreach (Sensor sensor in sensor_0)
		{
			if ((!sensor.CanBeActive || InterruptConsumer().AwakeIssuer()) && !sensor.CanPerformVolumeSearch && sensor.TargetsTrackedForFireControl_Readonly.Count > 0)
			{
				list.Add(sensor);
			}
		}
		return list;
	}

	private bool ResetDic(Sensor sensor_0)
	{
		if (sensor_0.IsOperating)
		{
			if (sensor_0.HasActiveModeOnly && !sensor_0.IsActive)
			{
				return false;
			}
			if (sensor_0.IsScanningOnThisPulse)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private bool MapDic(Sensor sensor_0)
	{
		if (sensor_0.IsScanningOnThisPulse_Full)
		{
			return true;
		}
		return false;
	}

	public virtual void PerformBaseDetections(ref ActiveUnit activeUnit_0, ref Side side_0)
	{
		HandleDetectedBaseContact(activeUnit_0, side_0);
	}

	public virtual void PerformDetections(Sensor[] sensor_0, List<ActiveUnit> list_0, float float_0)
	{
		if (strategyWrapper.Decoy)
		{
			return;
		}
		HadActiveSensorInLastPulse = false;
		if (strategyWrapper.IsGroup || strategyWrapper == null)
		{
			return;
		}
		lock (strategyWrapper)
		{
			try
			{
				if (strategyWrapper.GetUnitSide().AwarenessLevel == Side.AwarenessLevel_Enum.Blind)
				{
					return;
				}
				if (strategyWrapper.IsFacility)
				{
					bool flag = strategyWrapper.Sensors_Cached.Length == 0;
					bool flag2 = strategyWrapper.Mounts.Count == 0;
					if (((Facility)strategyWrapper).Crew == 0 && flag2 && flag)
					{
						return;
					}
				}
				if (Module_ActiveUnit.HasIncomingGuidedWeapons(strategyWrapper, strategyWrapper.ParentScen))
				{
					Sensor[] array2 = strategyWrapper.Sensors_ReadOnly();
					Sensor[] array7 = array2;
					foreach (Sensor sensor in array7)
					{
						if (sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.PingIntercept)
						{
							sensor.TimeToNextScan = 0;
							sensor.TimeToNextScan_Full = 0;
						}
						if (sensor.Type == Sensor.Sensor_Type.Radar)
						{
							sensor.TimeToNextScan_Full = 0;
						}
					}
				}
				if (!GetHasSensorsOperating(sensor_0))
				{
					return;
				}
				Sensor[] array3 = AwakeDic(sensor_0);
				List<Sensor> list = QueryDic(sensor_0);
				for (int i = 0; i < sensor_0.Length; i = checked(i + 1))
				{
					if (sensor_0[i].IsActive)
					{
						HadActiveSensorInLastPulse = true;
						break;
					}
				}
				if (array3.Length == 0 && list.Count == 0)
				{
					return;
				}
				Sensor[] array4 = array3.Where((Sensor sensor_0) => MapDic(sensor_0) && !sensor_0.IsHeightFinder).ToArray();
				Sensor[] array5 = array3.Where((Sensor sensor_0) => !MapDic(sensor_0) && !sensor_0.IsHeightFinder).ToArray();
				Sensor[] array6 = array3.Where((Sensor theS) => theS.IsHeightFinder).ToArray();
				if (array4.Count() == 0 && array5.Count() == 0 && array6.Count() == 0)
				{
					return;
				}
				if (_ComparatorWrapper == null)
				{
					_ComparatorWrapper = new List<ActiveUnit>();
				}
				else
				{
					_ComparatorWrapper.Clear();
				}
				if (_ItemWrapper == null)
				{
					_ItemWrapper = new List<ActiveUnit>();
				}
				else
				{
					_ItemWrapper.Clear();
				}
				m_ServerWrapper.Clear();
				if (array4.Length != 0)
				{
					if (strategyWrapper.IsWeapon)
					{
						Weapon weapon = (Weapon)strategyWrapper;
						if (weapon.IsFullyAutonomous && !weapon.IsAAW)
						{
							m_ServerWrapper.AddRange(strategyWrapper.ParentScen.ActiveUnits_List);
						}
						else
						{
							m_ServerWrapper.AddRange(strategyWrapper.GetUnitSide().interceptorFacade);
						}
					}
					else if (strategyWrapper.CommStuff.IsConnectedToSideNetwork)
					{
						m_ServerWrapper.AddRange(strategyWrapper.GetUnitSide().interceptorFacade);
					}
					else
					{
						m_ServerWrapper.AddRange(strategyWrapper.ParentScen.ActiveUnits_List);
					}
				}
				foreach (ActiveUnit item in list_0)
				{
					if (item != null && item != strategyWrapper && (!item.IsWeapon || ((Weapon)item).FiringParent != strategyWrapper) && !m_ServerWrapper.Contains(item))
					{
						m_ServerWrapper.Add(item);
					}
				}
				if (strategyWrapper.IsWeapon)
				{
					ActiveUnit dataLinkParent = ((Weapon)strategyWrapper).DataLinkParent;
					if (dataLinkParent != null)
					{
						m_ServerWrapper.Remove(dataLinkParent);
					}
				}
				if (!strategyWrapper.CommStuff.IsConnectedToSideNetwork)
				{
					foreach (Weapon item2 in strategyWrapper.ParentScen.GuidedWeaponsInAir)
					{
						if (item2.FiringParent == strategyWrapper)
						{
							m_ServerWrapper.Remove(item2);
						}
					}
				}
				if (array5.Length != 0)
				{
					foreach (Contact value in strategyWrapper.Sensory.Contacts_Local_ReadOnly.Values)
					{
						if (value.ActualUnit != null)
						{
							_ComparatorWrapper.Add(value.ActualUnit);
						}
					}
				}
				if (array6.Length != 0)
				{
					foreach (Contact contacts_ in strategyWrapper.GetUnitSide().Contacts_List)
					{
						if (contacts_.ActualUnit != null)
						{
							_ItemWrapper.Add(contacts_.ActualUnit);
						}
					}
				}
				if (attrWrapper == null)
				{
					attrWrapper = new List<EligibleContactEntry>();
				}
				else
				{
					attrWrapper.Clear();
				}
				if (m_PrototypeWrapper == null)
				{
					m_PrototypeWrapper = new List<EligibleContactEntry>();
				}
				else
				{
					m_PrototypeWrapper.Clear();
				}
				if (array4.Length != 0 && m_ServerWrapper != null && m_ServerWrapper.Count > 0)
				{
					attrWrapper = SortDic(array4, m_ServerWrapper);
				}
				if (array5.Count() > 0 && _ComparatorWrapper.Count > 0)
				{
					_VisitorWrapper = SortDic(array5, _ComparatorWrapper);
					if (_VisitorWrapper != null)
					{
						attrWrapper.AddRange(_VisitorWrapper);
					}
				}
				if (array6.Count() > 0 && _ItemWrapper.Count > 0)
				{
					_ExporterWrapper = SortDic(array6, _ItemWrapper);
					if (_ExporterWrapper != null)
					{
						attrWrapper.AddRange(_ExporterWrapper);
					}
				}
				if (list.Count > 0)
				{
					foreach (Sensor item3 in list)
					{
						foreach (Contact item4 in item3.TargetsTrackedForFireControl_Readonly)
						{
							if (item4.ActualUnit != null)
							{
								Sensor[] sensor_ = new Sensor[1] { item3 };
								EligibleContactEntry eligibleContactEntry = new EligibleContactEntry(ref item4.ActualUnit, ref sensor_);
								if (eligibleContactEntry != null)
								{
									attrWrapper.Add(eligibleContactEntry);
								}
							}
						}
					}
				}
				bool flag3 = false;
				if (attrWrapper.Count > 0)
				{
					List<ActiveUnit> list2 = null;
					Sensor[] array = array3;
					Sensor[] array8 = array;
					foreach (Sensor sensor2 in array8)
					{
						if (sensor2.Type == Sensor.Sensor_Type.Radar)
						{
							flag3 |= sensor2.PostWriter();
							if (list2 == null)
							{
								list2 = GetJammerUnitsAffectingMe(bool_0: true);
							}
							break;
						}
					}
					foreach (Sensor item5 in list)
					{
						if (item5.Type == Sensor.Sensor_Type.Radar)
						{
							flag3 |= item5.PostWriter();
							if (list2 == null)
							{
								list2 = GetJammerUnitsAffectingMe(bool_0: true);
							}
							break;
						}
					}
					if (_TokenWrapper == null)
					{
						_TokenWrapper = new ConcurrentQueue<Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>>();
					}
					else
					{
						Misc.Clear(_TokenWrapper);
					}
					foreach (EligibleContactEntry item6 in attrWrapper)
					{
						try
						{
							ForgotDic(item6, list2);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 101168", "");
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				if (array4.Length != 0)
				{
					CalcDic(array4);
				}
				if (flag3)
				{
					ConcatConsumer();
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100242", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private List<EligibleContactEntry> SortDic(Sensor[] sensor_0, List<ActiveUnit> list_0)
	{
		try
		{
			if (m_SetterWrapper == null)
			{
				m_SetterWrapper = new List<EligibleContactEntry>();
			}
			else
			{
				m_SetterWrapper.Clear();
			}
			(float, float, float, float) tuple = LogoutConsumer(bool_0: true);
			float item = tuple.Item1;
			float item2 = tuple.Item2;
			float item3 = tuple.Item4;
			float item4 = tuple.Item3;
			float num = Math.Max(Math.Max(Math.Max(item, item2), item4), item3);
			if (num == 0f)
			{
				return new List<EligibleContactEntry>();
			}
			double latitude = strategyWrapper.GetLatitude();
			double longitude = strategyWrapper.GetLongitude();
			IEnumerable<ActiveUnit> enumerable = Geodesic_Haversine.UnitsWithinDistanceFromPoint(list_0, bool_0: true, latitude, longitude, num);
			float num2 = 0f;
			foreach (ActiveUnit item6 in enumerable)
			{
				ActiveUnit activeUnit_ = item6;
				if (activeUnit_ == null || activeUnit_.IsGroup || !activeUnit_.IsOperating())
				{
					continue;
				}
				if (!activeUnit_.IsFacility && !activeUnit_.IsMobileGroundUnit)
				{
					if (activeUnit_.IsVehicle)
					{
						num2 = item3;
					}
					else if (activeUnit_.IsShip)
					{
						num2 = item2;
					}
					else if (!activeUnit_.IsSubmarine && !activeUnit_.IsTorpedo)
					{
						if (activeUnit_.IsAerospaceUnit)
						{
							num2 = item;
							if (strategyWrapper.IsSubmarine && activeUnit_.IsAircraft && ((Aircraft)activeUnit_).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
							{
								num2 = Math.Max(Math.Max(num2, item2), item4);
							}
						}
					}
					else
					{
						num2 = Math.Max(item4, item2);
					}
				}
				else
				{
					num2 = item3;
				}
				if (num2 != 0f && num2 > Module_Unit.RangeToUnit_Horiz(strategyWrapper, activeUnit_))
				{
					EligibleContactEntry item5 = new EligibleContactEntry(ref activeUnit_, ref sensor_0);
					m_SetterWrapper.Add(item5);
				}
			}
			return Misc.EnableRequest(m_SetterWrapper);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101224", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<EligibleContactEntry> result = new List<EligibleContactEntry>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void CalcDic(Sensor[] sensor_0)
	{
		try
		{
			if (strategyWrapper.ParentScen.Mines == null || strategyWrapper.ParentScen.Mines.Count == 0 || strategyWrapper.IsFacility || strategyWrapper.ParentScen.UnguidedWeapons.Values.Count <= 0)
			{
				return;
			}
			if (strategyWrapper.IsWeapon)
			{
				Weapon weapon = (Weapon)strategyWrapper;
				if (weapon.Type != Weapon._WeaponType.HeliTowedPackage && !weapon.ValidTargets.Mine)
				{
					return;
				}
			}
			Sensor[] gparam_ = new Sensor[0];
			foreach (Sensor sensor in sensor_0)
			{
				if (sensor.IsSonar)
				{
					if (sensor.IsActive && sensor.IsOperating && (sensor.GetSearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar) || sensor.Capabilities.Mine_Obstacle_Search))
					{
						ArrayExtensions.Add(ref gparam_, sensor);
					}
				}
				else if (sensor.Type == Sensor.Sensor_Type.Visual && (strategyWrapper.IsAircraft || strategyWrapper.IsShip) && strategyWrapper.GetCurrentAltitude() < 150f && strategyWrapper.CurrentSpeed < 200f)
				{
					ArrayExtensions.Add(ref gparam_, sensor);
				}
			}
			if (gparam_.Length == 0)
			{
				return;
			}
			List<GClass3> list = new List<GClass3>();
			list = RateDic(ref gparam_, ref strategyWrapper.ParentScen.Mines);
			if (list.Count <= 0)
			{
				return;
			}
			if (_IndexerWrapper == null)
			{
				_IndexerWrapper = new ConcurrentQueue<string>();
			}
			else
			{
				Misc.Clear(_IndexerWrapper);
			}
			foreach (GClass3 item in list)
			{
				FlushDic(item, gparam_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101272", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private List<GClass3> RateDic(ref Sensor[] sensor_0, ref List<UnguidedWeapon> list_0)
	{
		try
		{
			List<GClass3> list = new List<GClass3>();
			List<Sensor> list2 = NewConsumer(ref sensor_0);
			if (sensor_0.Count() <= 0)
			{
				return list;
			}
			double num = list2[0].maxRange;
			if (num > 1.0)
			{
				num = 1.0;
			}
			float num2 = (float)Math2.TestClass(num);
			int num3 = list_0.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (i < list_0.Count)
				{
					UnguidedWeapon unguidedWeapon_ = list_0[i];
					if (Math.Abs(strategyWrapper.GetLatitude() - unguidedWeapon_.GetLatitude()) <= (double)num2 && (double)num2 > Module_Unit.RangeToUnit_Horiz_Angular(strategyWrapper, unguidedWeapon_))
					{
						GClass3 item = new GClass3(ref unguidedWeapon_, ref sensor_0);
						list.Add(item);
					}
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101224", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<GClass3> result = new List<GClass3>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void FlushDic(GClass3 gclass3_0, Sensor[] sensor_0)
	{
		try
		{
			UnguidedWeapon nonAU_Weapon = gclass3_0.NonAU_Weapon;
			float float_ = Module_Unit.RangeToUnit_Slant(strategyWrapper, nonAU_Weapon);
			for (int i = 0; i < sensor_0.Length; i = checked(i + 1))
			{
				if (sensor_0[i].CanDetectTarget_NonAU(strategyWrapper, nonAU_Weapon, float_))
				{
					_IndexerWrapper.Enqueue(nonAU_Weapon.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100244", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ForgotDic(EligibleContactEntry eligibleContactEntry_0, List<ActiveUnit> list_0)
	{
		Side unitSide = strategyWrapper.GetUnitSide();
		List<Geopoint_Struct> list_ = new List<Geopoint_Struct>();
		try
		{
			ActiveUnit activeUnit = eligibleContactEntry_0.ActiveUnit;
			Sensor[] sensorList = eligibleContactEntry_0.SensorList;
			if (activeUnit == null || activeUnit == strategyWrapper || !activeUnit.IsOperating())
			{
				return;
			}
			Side unitSide2 = activeUnit.GetUnitSide();
			if (strategyWrapper.CommStuff.IsConnectedToSideNetwork && activeUnit.CommStuff.IsConnectedToSideNetwork && (unitSide == unitSide2 || unitSide2.GetConsidersThisSideToBe(unitSide) == Misc.PostureStance.Friendly))
			{
				return;
			}
			Contact value = null;
			bool isEligibleForAutodetection;
			if ((isEligibleForAutodetection = activeUnit.GetIsEligibleForAutodetection(unitSide)) && unitSide != unitSide2)
			{
				if (strategyWrapper.CommStuff.IsConnectedToSideNetwork)
				{
					if (!unitSide.Contacts.TryGetValue(activeUnit.ObjectID, ref value))
					{
						return;
					}
				}
				else if (!_ContactsList_OffGrid.TryGetValue(activeUnit.ObjectID, out value))
				{
					return;
				}
				if (value != null && !strategyWrapper.IsWeapon && (!activeUnit.HasEmittingSensors || value.DetectedEmissions.Count != 0))
				{
					if (value.IncludeImporter(unitSide).Count <= 0)
					{
						if (value.TimeSinceBDA < 15f)
						{
							return;
						}
					}
					else if (value.TimeSinceBDA < 10f)
					{
						return;
					}
				}
			}
			List<Sensor> list_2 = new List<Sensor>();
			float? num = null;
			num = ((!strategyWrapper.IsSubmarine || !activeUnit.IsAircraft || ((Aircraft)activeUnit).AirOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar) ? new float?(Module_Unit.RangeToUnit_Slant(strategyWrapper, activeUnit)) : new float?(Module_Unit.RangeToUnit_Horiz(strategyWrapper, activeUnit)));
			bool? nullable_ = null;
			bool? nullable_2 = null;
			Module_Unit.Unit.LOSCheckResult? nullable_3 = null;
			bool? nullable_4 = null;
			bool? nullable_5 = null;
			bool? nullable_6 = null;
			if (isEligibleForAutodetection && unitSide != unitSide2)
			{
				if (activeUnit.HasEmittingSensors)
				{
					Contact contact = ResultOfDetectionAttempt(activeUnit, sensorList, num.Value, ref list_2, list_0, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4, nullable_5, nullable_6, bool_0: true);
					if (contact != null)
					{
						MergeDetectedEmissions(value, contact.DetectedEmissions);
					}
				}
				if (!strategyWrapper.IsWeapon || (!((Weapon)strategyWrapper).HasGoneAutonomous && strategyWrapper.CommStuff.CommLinksEstablished_ReadOnly.Length != 0))
				{
					Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
					Sensor[] array = sensors_Cached;
					foreach (Sensor sensor in array)
					{
						if (sensor.GetCanPerformBDA(bool_0: false, bool_1: false))
						{
							ActiveUnit activeUnit_ = strategyWrapper;
							float value2 = num.Value;
							Lazy<Dictionary<int, EmissionContainer>> lazy_ = new Lazy<Dictionary<int, EmissionContainer>>();
							if (sensor.CanDetectTarget(Sensor.DetectionAttemptType.Recon, activeUnit_, activeUnit, ref list_, value2, ref lazy_, list_0, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4, ref nullable_5, ref nullable_6))
							{
								method_0(value, activeUnit, sensor);
								AttemptReconOfHostedUnits(value, activeUnit, sensor);
							}
						}
					}
				}
				if (!strategyWrapper.IsWeapon)
				{
					return;
				}
			}
			value = ResultOfDetectionAttempt(activeUnit, sensorList, num.Value, ref list_2, list_0, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4, nullable_5, nullable_6, bool_0: false);
			if (value != null)
			{
				_TokenWrapper.Enqueue(new Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>(value, activeUnit, list_2, num.Value, SpecialDetectionMode.None, strategyWrapper.ParentScen.Time, value.UncertaintyArea));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100245", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void HandleDetections_OnGrid()
	{
		try
		{
			while (strategyWrapper.GetUnitSide().definitionProxy.Count > 0)
			{
				Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> tuple_ = strategyWrapper.GetUnitSide().definitionProxy.Dequeue();
				HandleDetectedContact_OnGrid(strategyWrapper, strategyWrapper.GetUnitSide(), tuple_);
			}
			strategyWrapper.Sensory.ProcessContactListChanges_Local();
			if (_TokenWrapper != null)
			{
				while (_TokenWrapper.Count > 0)
				{
					if (_TokenWrapper.TryDequeue(out var result))
					{
						HandleDetectedContact_OnGrid(strategyWrapper, strategyWrapper.GetUnitSide(), result);
					}
				}
			}
			if (_IndexerWrapper != null && _IndexerWrapper.Count > 0)
			{
				List<EventTrigger> list = new List<EventTrigger>();
				foreach (string item in _IndexerWrapper)
				{
					if (string.IsNullOrEmpty(item) || strategyWrapper.GetUnitSide().Contacts_NonAU.Contains(item))
					{
						continue;
					}
					strategyWrapper.GetUnitSide().Contacts_NonAU.Add(item);
					try
					{
						if (strategyWrapper.ParentScen.UnguidedWeapons.Count <= 0)
						{
							continue;
						}
						UnguidedWeapon unguidedWeapon = strategyWrapper.ParentScen.UnguidedWeapons[item];
						if (unguidedWeapon == null || !unguidedWeapon.IsMine)
						{
							continue;
						}
						string text = "";
						if (strategyWrapper.IsAircraft && Operators.CompareString(strategyWrapper.Name, strategyWrapper.UnitClass, TextCompare: false) != 0)
						{
							text = " (" + strategyWrapper.UnitClass + ")";
						}
						strategyWrapper.AddMessage("新的雷区目标！探测单元" + strategyWrapper.Name + text + "在" + Conversions.ToString((int)Math.Round(strategyWrapper.AI.BearingToUnit_True(unguidedWeapon))) + "度 - " + Conversions.ToString(Math.Round(Module_Unit.RangeToUnit_Horiz(strategyWrapper, unguidedWeapon), 1)) + "NM", "布雷扫雷战", LoggedMessage.MessageType.NewMineContact, 1, bool_0: false, new Geopoint_Struct(unguidedWeapon.GetLongitude(), unguidedWeapon.GetLatitude()));
						foreach (ActiveUnit activeUnits_ in strategyWrapper.ParentScen.ActiveUnits_List)
						{
							if (Information.IsNothing(activeUnits_) || (!activeUnits_.IsSubmarine && !activeUnits_.IsShip))
							{
								continue;
							}
							if (!activeUnits_.IsMCMPlatform && activeUnits_.MineCountermeasures.Count <= 0)
							{
								if (Module_Unit.RangeToUnit_Horiz(unguidedWeapon, activeUnits_) < 20f)
								{
									activeUnits_.Navigator.ResetTimeToNextPathfinderCheck();
								}
							}
							else if (Module_Unit.RangeToUnit_Horiz(unguidedWeapon, activeUnits_) < 2f)
							{
								activeUnits_.Navigator.TimeToNextPathfinderCheck = Math.Max(600f, activeUnits_.Navigator.TimeToNextPathfinderCheck);
							}
							else
							{
								activeUnits_.Navigator.TimeToNextPathfinderCheck = Math.Max(300f, activeUnits_.Navigator.TimeToNextPathfinderCheck);
							}
						}
						foreach (EventTrigger value in strategyWrapper.ParentScen.EventTriggers.Values)
						{
							if (value.Type == EventTrigger.EventTriggerType.UnitDetected && ((EventTrigger_UnitDetected)value).GetIsFulfilled(unguidedWeapon, strategyWrapper, bool_0: true, Contact_Base.IdentificationStatus.KnownClass, Contact_Base.IdentificationStatus.Unknown, null))
							{
								list.Add(value);
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
				if (list != null && list.Count > 0)
				{
					strategyWrapper.ParentScen.FireEvents(list);
				}
			}
			if (m_PublisherWrapper == null || m_PublisherWrapper.Count <= 0)
			{
				return;
			}
			foreach (LoggedMessage value2 in m_PublisherWrapper.Values)
			{
				strategyWrapper.ParentScen.AddMessage(value2);
			}
			m_PublisherWrapper.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100246", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HandleDetections_OffGrid()
	{
		try
		{
			strategyWrapper.Sensory.ProcessContactListChanges_Local();
			if (_TokenWrapper != null)
			{
				foreach (Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> item in _TokenWrapper)
				{
					if (!Information.IsNothing(item))
					{
						HandleDetectedContact_OffGrid(item);
					}
				}
			}
			if (_IndexerWrapper != null)
			{
				foreach (string item2 in _IndexerWrapper)
				{
					if (string.IsNullOrEmpty(item2) || _ContactsList_OffGrid_NonAU.Contains(item2))
					{
						continue;
					}
					_ContactsList_OffGrid_NonAU.Add(item2);
					try
					{
						UnguidedWeapon unguidedWeapon = strategyWrapper.ParentScen.UnguidedWeapons[item2];
						if (unguidedWeapon.IsMine)
						{
							strategyWrapper.AddMessage("新的雷区目标！探测单元" + strategyWrapper.Name + "在" + Conversions.ToString((int)Math.Round(strategyWrapper.AI.BearingToUnit_True(unguidedWeapon))) + "度 - " + Conversions.ToString(Math.Round(Module_Unit.RangeToUnit_Horiz(strategyWrapper, unguidedWeapon), 1)) + "NM", "布雷扫雷战", LoggedMessage.MessageType.CommsIsolatedMessage, 1, bool_0: false, new Geopoint_Struct(unguidedWeapon.GetLongitude(), unguidedWeapon.GetLatitude()));
							if (strategyWrapper.IsSubmarine || strategyWrapper.IsShip)
							{
								strategyWrapper.Navigator.ResetTimeToNextPathfinderCheck();
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
			}
			if (m_PublisherWrapper != null)
			{
				foreach (LoggedMessage value in m_PublisherWrapper.Values)
				{
					strategyWrapper.ParentScen.AddMessage(value);
				}
			}
			m_PublisherWrapper.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200653", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void UpdateContactData(ref ActiveUnit activeUnit_0, ref Contact contact_0, ActiveUnit activeUnit_1, bool bool_0, List<Geopoint_Struct> list_0 = null)
	{
		try
		{
			bool flag = false;
			if (bool_0)
			{
				flag = true;
			}
			else
			{
				switch (contact_0.Type)
				{
				case Contact_Base.ContactType.Facility_Fixed:
				{
					bool flag2 = false;
					if (contact_0.ActualUnit != null)
					{
						flag2 = (contact_0.GetLatitude() != contact_0.ActualUnit.GetLatitude()) | (contact_0.GetLongitude() != contact_0.ActualUnit.GetLongitude());
					}
					if (contact_0.UncertaintyArea != null || flag2)
					{
						flag = true;
					}
					break;
				}
				default:
					flag = true;
					break;
				case Contact_Base.ContactType.Aimpoint:
				case Contact_Base.ContactType.Explosion:
				case Contact_Base.ContactType.ActivationPoint:
					break;
				}
			}
			if (flag)
			{
				if (list_0 != null)
				{
					if (contact_0.UncertaintyArea == null)
					{
						if (bool_0)
						{
							contact_0.UncertaintyArea = list_0;
						}
					}
					else if (!contact_0.IsPreciselyLocatedOnThisPulse)
					{
						if (contact_0.ActualUnit == null)
						{
							contact_0.UncertaintyArea = list_0;
						}
						else
						{
							contact_0.UncertaintyArea = GetRefinedUncertaintyArea_Clipper(contact_0.UncertaintyArea, list_0);
						}
					}
				}
				contact_0.CurrentHeading = activeUnit_1.CurrentHeading;
				contact_0.CurrentSpeed = activeUnit_1.CurrentSpeed;
				contact_0.SetCurrentAltitude(bool_0: false, activeUnit_1.GetCurrentAltitude());
				contact_0.ContactMovement();
				contact_0.UpdateCenter(activeUnit_1);
			}
			contact_0.Age = 0f;
			if (contact_0.ActualUnit.isUAV)
			{
				contact_0.Type = Contact_Base.ContactType.Air;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100247", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportContactLocationEvent(Contact contact_0, Side side_0, Scenario scenario_0)
	{
		lock (contact_0)
		{
			try
			{
				foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
				{
					if (applicableEventExporter.IsOperating && applicableEventExporter.Common.AssetRepository(scenario_0, contact_0) && side_0 != null)
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
						dictionary.Add("ContactID", new IEventExporter.EventNotificationParameter(contact_0.ObjectID, typeof(string), 40));
						dictionary.Add("UnitDBID", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.DBID, typeof(string), 10));
						dictionary.Add("ContactName", new IEventExporter.EventNotificationParameter(contact_0.Name, typeof(string), 500));
						dictionary.Add("UnitType", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.UnitType_String, typeof(string), 20));
						dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.UnitClass, typeof(string), 500));
						dictionary.Add("ObserverSide", new IEventExporter.EventNotificationParameter(side_0.Name, typeof(string), 500));
						dictionary.Add("ContactLongitude", new IEventExporter.EventNotificationParameter(contact_0.GetLongitude(), typeof(double)));
						dictionary.Add("ContactLatitude", new IEventExporter.EventNotificationParameter(contact_0.GetLatitude(), typeof(double)));
						dictionary.Add("ContactCourse", new IEventExporter.EventNotificationParameter(contact_0.HeadingIsKnown ? Conversions.ToString(contact_0.CurrentHeading) : string.Empty, typeof(float)));
						dictionary.Add("ContactSpeed_kts", new IEventExporter.EventNotificationParameter(contact_0.SpeedIsKnown ? Conversions.ToString(contact_0.CurrentSpeed) : string.Empty, typeof(float)));
						dictionary.Add("ContactAltitude_m", new IEventExporter.EventNotificationParameter(contact_0.AltitudeIsKnown ? Conversions.ToString(contact_0.GetCurrentAltitude()) : string.Empty, typeof(float)));
						if (!contact_0.ActualUnit.IsAircraft && !contact_0.ActualUnit.IsMissile && !contact_0.ActualUnit.IsTorpedo)
						{
							dictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.Attitude_Pitch, typeof(float)));
						}
						else
						{
							dictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.Attitude_Pitch_Derived(), typeof(float)));
						}
						dictionary.Add("UnitAttitude_Roll", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.Attitude_Roll, typeof(float)));
						applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.ContactPositions, dictionary, scenario_0);
						applicableEventExporter.Common.ApplyLastExportLocation(contact_0);
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
	}

	public void HandleContactLoss(Contact contact_0)
	{
		Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
		try
		{
			int num = sensors_Cached.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				Sensor sensor = sensors_Cached[i];
				List<Contact> targetsTrackedForFireControl_Readonly = sensor.TargetsTrackedForFireControl_Readonly;
				int num2 = targetsTrackedForFireControl_Readonly.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					Contact contact;
					try
					{
						if (targetsTrackedForFireControl_Readonly.Count <= j)
						{
							break;
						}
						contact = targetsTrackedForFireControl_Readonly[j];
						goto IL_0071;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						continue;
					}
					IL_0071:
					if (contact == contact_0)
					{
						sensor.StopTrackingTarget(contact_0);
					}
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void MergeDetectedEmissions(Contact contact_0, ObservableDictionary<int, EmissionContainer> observableDictionary_0)
	{
		if (observableDictionary_0.Count == 0)
		{
			return;
		}
		try
		{
			foreach (int item in observableDictionary_0.Keys.ToList())
			{
				EmissionContainer emissionContainer = observableDictionary_0[item];
				if (contact_0.DetectedEmissions.ContainsKey(item))
				{
					if (contact_0.DetectedEmissions[item].PreciseID)
					{
						emissionContainer.PreciseID = true;
					}
					emissionContainer.Age = Math.Min(emissionContainer.Age, contact_0.DetectedEmissions[item].Age);
					contact_0.DetectedEmissions[item] = emissionContainer;
					continue;
				}
				try
				{
					if (contact_0 == null)
					{
						break;
					}
					if (contact_0.DetectedEmissions == null)
					{
						contact_0.DetectedEmissions = new ObservableDictionary<int, EmissionContainer>();
					}
					lock (contact_0.DetectedEmissions)
					{
						if (contact_0.DetectedEmissions.ContainsKey(item))
						{
							contact_0.DetectedEmissions[item] = emissionContainer;
						}
						else
						{
							contact_0.DetectedEmissions.Add(item, emissionContainer);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200011", ex2.Message);
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
			Exception exception_ = ex3;
			exception_?.Data.Add("Error at 100248", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CollectDic(List<Sensor> list_0, Contact contact_0)
	{
		foreach (Sensor item in list_0)
		{
			bool flag = DetectionIsPrecise(item, Module_Unit.RangeToUnit_Horiz(item.ParentPlatform, contact_0.ActualUnit));
			if (item.m_IsMk1Eyeball)
			{
				contact_0.RemainingContinousTrackTime = 10f;
				contact_0.RemainingContinousTrackTime_Precise = 10f;
				continue;
			}
			if (item.IsContinousTrackingCapable)
			{
				contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, item.ScanInterval);
				if (flag)
				{
					contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
				}
				continue;
			}
			ActiveUnit activeUnit_ = contact_0.ActualUnit;
			if (item.IsTrackingThisUnitForFireControl(ref activeUnit_))
			{
				contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, item.ScanInterval);
				if (flag)
				{
					contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
				}
			}
			else if (item.Type == Sensor.Sensor_Type.Radar)
			{
				contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, 3f);
				if (flag)
				{
					contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
				}
			}
			else if (contact_0.IsLandContact)
			{
				contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, item.ScanInterval * 6);
				if (flag)
				{
					contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
				}
			}
			else
			{
				contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, 1f);
			}
		}
	}

	public virtual void HandleDetectedContact_OnGrid(ActiveUnit activeUnit_0, Side side_0, Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> tuple_0, bool bool_0 = false)
	{
		Contact item = tuple_0.Item1;
		ActiveUnit item2 = tuple_0.Item2;
		List<Sensor> item3 = tuple_0.Item3;
		float item4 = tuple_0.Item4;
		SpecialDetectionMode item5 = tuple_0.Item5;
		List<Geopoint_Struct> list = null;
		_ = item.DetectedEmissions;
		List<Side> list2 = new List<Side>();
		Side[] sides_ReadOnly = activeUnit_0.ParentScen.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (side != side_0 && Module_Side.IsAlliedWithThisSide(side_0, side))
			{
				list2.Add(side);
			}
		}
		try
		{
			InterruptConsumer().AttemptToWake_WithDetection(tuple_0.Item1);
			bool flag = strategyWrapper.GetUnitSide().m_InfoFacade.ContainsKey_NoLock(item2.ObjectID);
			bool flag2 = ManageDic(item2);
			bool flag3 = strategyWrapper.Sensory.Contacts_Local_ReadOnly.ContainsKey(item2.ObjectID);
			Contact contact_;
			if (flag2)
			{
				contact_ = side_0.Contacts[item2.ObjectID];
				if (contact_.HasDetectedEmissions || item.HasDetectedEmissions)
				{
					MergeDetectedEmissions(contact_, item.DetectedEmissions);
				}
			}
			else
			{
				if (flag)
				{
					return;
				}
				contact_ = item;
			}
			if (tuple_0.Item7 != null && tuple_0.Item7.Count > 0)
			{
				list = tuple_0.Item7;
			}
			else if (item.UncertaintyArea != null)
			{
				list = item.UncertaintyArea;
			}
			CollectDic(item3, contact_);
			if (side_0.AwarenessLevel >= Side.AwarenessLevel_Enum.AutoSideID && !contact_.SideIsKnown)
			{
				contact_.SideIsKnown = true;
				contact_.RetreivedPostureOnThisPulse = false;
			}
			string name = contact_.Name;
			Contact_Base.IdentificationStatus? nullable_ = null;
			Contact_Base.IdentificationStatus? nullable_2 = null;
			if (item3.Count != 0)
			{
				_ = contact_.IDStatus;
				Contact_Base.IdentificationStatus? identificationStatus = contact_.IDStatus;
				foreach (Sensor item6 in item3)
				{
					if (flag2)
					{
						OrderDic(item6, contact_, item2, item4, bool_0: true, ref nullable_, ref nullable_2);
					}
					method_0(contact_, item2, item6);
					AttemptReconOfHostedUnits(contact_, item2, item6);
					RegisterDic(item6, contact_);
					if (DetectionIsPrecise(item6, Module_Unit.RangeToUnit_Horiz(item6.ParentPlatform, contact_.ActualUnit)))
					{
						contact_.IsPreciselyLocatedOnThisPulse = true;
						continue;
					}
					if (!contact_.IsPreciselyLocatedOnThisPulse && (!item2.IsFixedFacility || item6.Type == Sensor.Sensor_Type.ESM))
					{
						if (list == null && tuple_0.Item7 != null)
						{
							list = tuple_0.Item7;
						}
						else if (list != null)
						{
							list = GetRefinedUncertaintyArea_Clipper(list, tuple_0.Item7);
						}
					}
					if (item6.Capabilities.AltitudeInfo || strategyWrapper.IsWeapon)
					{
						contact_.AltitudeIsKnown = true;
					}
				}
				nullable_2 = identificationStatus;
			}
			if (!contact_.ActualUnit.CommStuff.IsConnectedToSideNetwork && (contact_.ActualUnit.GetUnitSide() == strategyWrapper.GetUnitSide() || contact_.ActualUnit.GetUnitSide().GetConsidersThisSideToBe(strategyWrapper.GetUnitSide()) == Misc.PostureStance.Friendly))
			{
				_ = contact_.IDStatus;
				Contact_Base.IdentificationStatus? identificationStatus2 = contact_.IDStatus;
				foreach (Sensor item7 in item3)
				{
					OrderDic(item7, contact_, item2, item4, bool_0: false, ref nullable_, ref nullable_2);
				}
				nullable_2 = identificationStatus2;
			}
			if (nullable_.HasValue)
			{
				short? num = (short?)nullable_;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					goto IL_04cf;
				}
				if (contact_.IsAircraftContact)
				{
					num = (short?)nullable_;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
					{
						goto IL_04cf;
					}
				}
			}
			goto IL_0666;
			IL_0666:
			if (flag2)
			{
				if (list == null)
				{
					UpdateContactData(ref strategyWrapper, ref contact_, item2, bool_0: false);
				}
				else
				{
					UpdateContactData(ref strategyWrapper, ref contact_, item2, bool_0: false, list);
				}
			}
			else
			{
				nullable_ = Contact_Base.IdentificationStatus.KnownDomain;
				nullable_2 = Contact_Base.IdentificationStatus.Unknown;
				List<ActiveUnit> list3 = new List<ActiveUnit>();
				sides_ReadOnly = strategyWrapper.ParentScen.Sides_ReadOnly;
				Side[] array2 = sides_ReadOnly;
				foreach (Side side2 in array2)
				{
					if (side2 != strategyWrapper.GetUnitSide() && side2.GetConsidersThisSideToBe(strategyWrapper.GetUnitSide()) != Misc.PostureStance.Friendly)
					{
						continue;
					}
					foreach (ActiveUnit unit in side2.Units)
					{
						if (!unit.CommStuff.IsConnectedToSideNetwork)
						{
							list3.Add(unit);
						}
					}
				}
				if (list3.Count > 0)
				{
					if (Information.IsNothing(list))
					{
						UpdateContactData(ref strategyWrapper, ref contact_, item2, bool_0: true);
					}
					else
					{
						UpdateContactData(ref strategyWrapper, ref contact_, item2, bool_0: true, list);
					}
					foreach (ActiveUnit item8 in list3)
					{
						_ = Debugger.IsAttached;
						if (((item8.IsAircraft && contact_.IsAircraftContact) || (item8.IsShip && contact_.IsShipContact) || (item8.IsSubmarine && contact_.IsSubmergedContact) || (item8.IsFacility && contact_.Type == Contact_Base.ContactType.Facility_Mobile)) && !(Module_Unit.RangeToPoint_Horiz(contact_, item8.Latitude_LastReported.Value, item8.Longitude_LastReported.Value) >= 1f))
						{
							item8.Latitude_LastReported = contact_.GetLatitude();
							item8.Longitude_LastReported = contact_.GetLongitude();
							return;
						}
					}
				}
				contact_.UncertaintyArea = list;
				ProcessNewContact(ref contact_, ref activeUnit_0.ParentScen, side_0, item2, item5, activeUnit_0, Contact_Base.IdentificationStatus.KnownDomain, item3);
			}
			RevertDic(item, item3);
			List<EventTrigger> list4 = new List<EventTrigger>();
			if (nullable_.HasValue && nullable_2.HasValue)
			{
				if (item5 == SpecialDetectionMode.None)
				{
					foreach (EventTrigger value in activeUnit_0.ParentScen.EventTriggers.Values)
					{
						if (value.Type == EventTrigger.EventTriggerType.UnitDetected)
						{
							if (((EventTrigger_UnitDetected)value).GetIsFulfilled(item2, strategyWrapper, flag, nullable_.Value, nullable_2, item3))
							{
								list4.Add(value);
							}
						}
						else if (value.Type == EventTrigger.EventTriggerType.UnitEmissions && ((EventTrigger_UnitEmissions)value).GetIsFulfilled(item2, strategyWrapper, flag, nullable_.Value, nullable_2, item3))
						{
							list4.Add(value);
						}
					}
				}
			}
			else if (contact_ != null)
			{
				foreach (EventTrigger value2 in strategyWrapper.ParentScen.EventTriggers.Values)
				{
					if (value2.Type == EventTrigger.EventTriggerType.UnitDetected)
					{
						if (((EventTrigger_UnitDetected)value2).Area.Count <= 0)
						{
							continue;
						}
						if (contact_.GetIsInsideThisArea(((EventTrigger_UnitDetected)value2).Area, strategyWrapper.ParentScen, bool_0: false))
						{
							if (((EventTrigger_UnitDetected)value2).GetIsFulfilled(item2, activeUnit_0, flag, Contact_Base.IdentificationStatus.Unknown, nullable_2, item3))
							{
								list4.Add(value2);
							}
						}
						else if (contact_.ActiveEnterAreaTriggers.Count > 0)
						{
							item2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitDetected)value2).ObjectID);
						}
					}
					else if (value2.Type == EventTrigger.EventTriggerType.UnitEmissions && ((EventTrigger_UnitEmissions)value2).GetIsFulfilled(item2, strategyWrapper, flag, Contact_Base.IdentificationStatus.Unknown, nullable_2, item3))
					{
						list4.Add(value2);
					}
				}
			}
			if (list4 != null && list4.Count > 0)
			{
				activeUnit_0.ParentScen.FireEvents(list4);
			}
			if (flag3)
			{
				UpdateContactData_Local(ref item2.ObjectID, item3);
			}
			else
			{
				NewContactsQueue_Local.AddIfNotExistsElseUpdate(item2.ObjectID, contact_);
				UpdateContactData_Local(ref item2.ObjectID, item3);
			}
			if (contact_ == null)
			{
				return;
			}
			foreach (Sensor item9 in tuple_0.Item3)
			{
				contact_.AddDetectionRecord((strategyWrapper.ObjectID, item9.ObjectID, tuple_0.Item4, tuple_0.Item5, tuple_0.Item6));
			}
			return;
			IL_04cf:
			if (!contact_.ActualUnit.CommStuff.IsConnectedToSideNetwork && (contact_.ActualUnit.GetUnitSide() == side_0 || contact_.ActualUnit.GetUnitSide().GetConsidersThisSideToBe(side_0) == Misc.PostureStance.Friendly))
			{
				if (flag3)
				{
					strategyWrapper.AddMessage("目标：" + name + "被" + strategyWrapper.Name + "识别为" + item2.Name + "，一个通信中断的单元。放弃目标并更新单元上次报告的位置", "Dropping contact " + name + " (isolated own/friendly unit!)", LoggedMessage.MessageType.ContactChange, 0, bool_0: false, new Geopoint_Struct(contact_.GetLongitude(), contact_.GetLatitude()));
				}
				try
				{
					side_0.DropContact(contact_, ref activeUnit_0.ParentScen, bool_0: false);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (list == null)
				{
					UpdateContactData(ref strategyWrapper, ref contact_, item2, !flag2);
				}
				else
				{
					UpdateContactData(ref strategyWrapper, ref contact_, item2, !flag2, list);
				}
				contact_.ActualUnit.Latitude_LastReported = contact_.GetLatitude();
				contact_.ActualUnit.Longitude_LastReported = contact_.GetLongitude();
				return;
			}
			goto IL_0666;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 100249", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ContactsAreOfSameActualUnit(Contact contact_0, Contact contact_1)
	{
		if (contact_0.Type == contact_1.Type)
		{
			if (contact_0.ActualUnit == contact_1.ActualUnit)
			{
				return true;
			}
			if (string.CompareOrdinal(contact_0.ActualUnit.ObjectID, contact_1.ActualUnit.ObjectID) == 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private void OrderDic(Sensor sensor_0, Contact contact_0, ActiveUnit activeUnit_0, float float_0, bool bool_0, ref Contact_Base.IdentificationStatus? nullable_0, ref Contact_Base.IdentificationStatus? nullable_1)
	{
		if (contact_0.ActualUnit.isUAV)
		{
			contact_0.Type = Contact_Base.ContactType.Air;
		}
		if (sensor_0.Capabilities.HeadingInfo)
		{
			contact_0.HeadingIsKnown = true;
		}
		if (sensor_0.Capabilities.SpeedInfo)
		{
			contact_0.SpeedIsKnown = true;
		}
		if (sensor_0.Capabilities.AltitudeInfo || strategyWrapper.IsWeapon)
		{
			contact_0.AltitudeIsKnown = true;
		}
		nullable_1 = contact_0.IDStatus;
		short? num;
		switch (contact_0.Type)
		{
		default:
			num = (short?)nullable_1;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() >= 4) : null).GetValueOrDefault())
			{
				return;
			}
			break;
		case Contact_Base.ContactType.Missile:
			num = (short?)nullable_1;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() >= 3) : null).GetValueOrDefault())
			{
				return;
			}
			break;
		case Contact_Base.ContactType.Air:
			num = (short?)nullable_1;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() >= 3) : null).GetValueOrDefault())
			{
				return;
			}
			break;
		}
		bool bool_ = false;
		switch (sensor_0.Type)
		{
		case Sensor.Sensor_Type.ESM:
			nullable_0 = Contact_Base.IdentificationStatus.KnownDomain;
			if (sensor_0.Role != Sensor.Sensor_Role.ESM_RWR)
			{
				CustomizeConsumer(contact_0, float_0);
				if (contact_0.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
				{
					nullable_0 = ComputeConsumer(contact_0, activeUnit_0, sensor_0);
				}
			}
			break;
		case Sensor.Sensor_Type.Radar:
			if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
			{
				break;
			}
			if (contact_0.IsAir_Missile_Orbital_Contact)
			{
				nullable_0 = DestroyConsumer(contact_0, activeUnit_0, sensor_0, float_0);
				if (nullable_0.HasValue)
				{
					bool_ = true;
				}
			}
			else
			{
				nullable_0 = AddConsumer(contact_0, activeUnit_0, sensor_0, float_0);
			}
			break;
		case Sensor.Sensor_Type.Visual:
		{
			float num2 = sensor_0.MaxIDRangeOnThisTarget(strategyWrapper, activeUnit_0);
			if (float_0 < num2)
			{
				switch (contact_0.Type)
				{
				case Contact_Base.ContactType.Missile:
					nullable_0 = Contact_Base.IdentificationStatus.KnownType;
					break;
				case Contact_Base.ContactType.Surface:
					nullable_0 = Contact_Base.IdentificationStatus.PreciseID;
					break;
				case Contact_Base.ContactType.Submarine:
					if (((Submarine)contact_0.ActualUnit).IsSurfaced)
					{
						nullable_0 = Contact_Base.IdentificationStatus.KnownClass;
					}
					else
					{
						nullable_0 = Contact_Base.IdentificationStatus.KnownType;
					}
					break;
				case Contact_Base.ContactType.Air:
				case Contact_Base.ContactType.Orbital:
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.Torpedo:
				case Contact_Base.ContactType.Mine:
					nullable_0 = Contact_Base.IdentificationStatus.KnownClass;
					break;
				}
			}
			else if (float_0 < num2 * 3f)
			{
				nullable_0 = Contact_Base.IdentificationStatus.KnownType;
			}
			else
			{
				nullable_0 = Contact_Base.IdentificationStatus.KnownDomain;
			}
			break;
		}
		case Sensor.Sensor_Type.Infrared:
		{
			if (!sensor_0.Codes.Classification)
			{
				break;
			}
			float num3 = sensor_0.MaxIDRangeOnThisTarget(strategyWrapper, activeUnit_0);
			if (float_0 < num3)
			{
				switch (contact_0.Type)
				{
				case Contact_Base.ContactType.Missile:
					nullable_0 = Contact_Base.IdentificationStatus.KnownType;
					break;
				case Contact_Base.ContactType.Air:
				case Contact_Base.ContactType.Surface:
				case Contact_Base.ContactType.Orbital:
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.Torpedo:
				case Contact_Base.ContactType.Mine:
					nullable_0 = Contact_Base.IdentificationStatus.KnownClass;
					break;
				}
			}
			else if (float_0 < num3 * 3f)
			{
				nullable_0 = Contact_Base.IdentificationStatus.KnownType;
			}
			else
			{
				nullable_0 = Contact_Base.IdentificationStatus.KnownDomain;
			}
			break;
		}
		case Sensor.Sensor_Type.HullSonar_PassiveOnly:
		case Sensor.Sensor_Type.HullSonar_ActivePassive:
		case Sensor.Sensor_Type.TowedArray_PassiveOnly:
		case Sensor.Sensor_Type.TowedArray_ActivePassive:
		case Sensor.Sensor_Type.VDS_PassiveOnly:
		case Sensor.Sensor_Type.VDS_ActivePassive:
		case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
		case Sensor.Sensor_Type.DippingSonar_ActivePassive:
		case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
			if (!sensor_0.IsActive)
			{
				CountConsumer(contact_0, float_0);
				nullable_0 = PatchConsumer(contact_0, activeUnit_0, sensor_0);
			}
			break;
		}
		if (strategyWrapper.GetUnitSide().AwarenessLevel >= Side.AwarenessLevel_Enum.AutoSideAndUnitID)
		{
			nullable_0 = Contact_Base.IdentificationStatus.PreciseID;
		}
		short iDStatus;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			iDStatus = (short)contact_0.IDStatus;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() != iDStatus) : null).GetValueOrDefault())
			{
				if (contact_0.UncertaintyArea == null)
				{
					contact_0.method_0(strategyWrapper.ParentScen, strategyWrapper.GetUnitSide(), sensor_0, (float)Math.Round(float_0, 1), bool_, strategyWrapper.CommStuff.IsConnectedToSideNetwork, bool_2: true, bool_0, nullable_0.Value);
				}
				else
				{
					contact_0.method_0(strategyWrapper.ParentScen, strategyWrapper.GetUnitSide(), sensor_0, (float)Math.Round(Module_Unit.RangeToUnit_Slant(strategyWrapper, contact_0), 1), bool_, strategyWrapper.CommStuff.IsConnectedToSideNetwork, bool_2: true, bool_0, nullable_0.Value);
				}
			}
		}
		num = (short?)nullable_0;
		iDStatus = (short)contact_0.IDStatus;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() != iDStatus) : null).GetValueOrDefault())
		{
			nullable_0 = contact_0.IDStatus;
		}
	}

	private void RegisterDic(Sensor sensor_0, Contact contact_0)
	{
		switch (sensor_0.Type)
		{
		case Sensor.Sensor_Type.ESM:
			contact_0.globalObserver = 0f;
			break;
		case Sensor.Sensor_Type.Visual:
			contact_0.m_WorkerObserver = 0f;
			break;
		case Sensor.Sensor_Type.Infrared:
			contact_0.m_AccountObserver = 0f;
			break;
		case Sensor.Sensor_Type.Radar:
		case Sensor.Sensor_Type.PCLS:
			contact_0.m_EventObserver = 0f;
			break;
		case Sensor.Sensor_Type.PingIntercept:
			contact_0.authenticationObserver = 0f;
			break;
		case Sensor.Sensor_Type.HullSonar_PassiveOnly:
		case Sensor.Sensor_Type.HullSonar_ActivePassive:
		case Sensor.Sensor_Type.HullSonar_ActiveOnly:
		case Sensor.Sensor_Type.TowedArray_PassiveOnly:
		case Sensor.Sensor_Type.TowedArray_ActivePassive:
		case Sensor.Sensor_Type.TowedArray_ActiveOnly:
		case Sensor.Sensor_Type.VDS_PassiveOnly:
		case Sensor.Sensor_Type.VDS_ActivePassive:
		case Sensor.Sensor_Type.VDS_ActiveOnly:
		case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
		case Sensor.Sensor_Type.DippingSonar_ActivePassive:
		case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
		case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
			if (sensor_0.HasActiveModeOnly)
			{
				contact_0.stateObserver = 0f;
			}
			else if (sensor_0.IsActive)
			{
				contact_0.stateObserver = 0f;
			}
			else
			{
				contact_0.authenticationObserver = 0f;
			}
			break;
		}
	}

	internal bool ManageDic(ActiveUnit activeUnit_0)
	{
		try
		{
			if (strategyWrapper.GetUnitSide() == null)
			{
				return false;
			}
			if (strategyWrapper.CommStuff.IsConnectedToSideNetwork)
			{
				return strategyWrapper.GetUnitSide().Contacts.ContainsKey(activeUnit_0.ObjectID);
			}
			return _ContactsList_OffGrid.ContainsKey(activeUnit_0.ObjectID);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	protected virtual void HandleDetectedContact_OffGrid(Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> tuple_0)
	{
		Contact item = tuple_0.Item1;
		ActiveUnit item2 = tuple_0.Item2;
		List<Sensor> item3 = tuple_0.Item3;
		float item4 = tuple_0.Item4;
		SpecialDetectionMode item5 = tuple_0.Item5;
		try
		{
			List<Geopoint_Struct> list = null;
			_ = item.DetectedEmissions;
			bool flag = strategyWrapper.GetUnitSide().m_InfoFacade.ContainsKey_NoLock(item2.ObjectID);
			bool flag2 = ManageDic(item2);
			bool flag3 = strategyWrapper.Sensory.Contacts_Local_ReadOnly.ContainsKey(item2.ObjectID);
			Contact contact_;
			if (flag2)
			{
				contact_ = _ContactsList_OffGrid[item2.ObjectID];
				if (contact_.HasDetectedEmissions || item.HasDetectedEmissions)
				{
					MergeDetectedEmissions(contact_, item.DetectedEmissions);
				}
			}
			else
			{
				if (flag)
				{
					return;
				}
				contact_ = item;
			}
			if (item5 != 0)
			{
				if (tuple_0.Item7 != null && tuple_0.Item7.Count > 0)
				{
					list = tuple_0.Item7;
				}
				else if (item.UncertaintyArea != null)
				{
					list = item.UncertaintyArea;
				}
			}
			CollectDic(item3, contact_);
			if (strategyWrapper.GetUnitSide().AwarenessLevel >= Side.AwarenessLevel_Enum.AutoSideID && !contact_.SideIsKnown)
			{
				contact_.SideIsKnown = true;
			}
			if (item3.Count != 0)
			{
				Contact_Base.IdentificationStatus? nullable_ = null;
				Contact_Base.IdentificationStatus? nullable_2 = null;
				foreach (Sensor item6 in item3)
				{
					if (flag2)
					{
						OrderDic(item6, contact_, item2, item4, bool_0: true, ref nullable_, ref nullable_2);
					}
					RegisterDic(item6, contact_);
					method_0(contact_, item2, item6);
					AttemptReconOfHostedUnits(contact_, item2, item6);
					if (DetectionIsPrecise(item6, Module_Unit.RangeToUnit_Horiz(item6.ParentPlatform, contact_.ActualUnit)))
					{
						if (contact_.UncertaintyArea != null)
						{
							contact_.ChangedToFirmOnThisPulse = true;
						}
						contact_.IsPreciselyLocatedOnThisPulse = true;
						contact_.UncertaintyArea = null;
						continue;
					}
					if (!contact_.IsPreciselyLocatedOnThisPulse && (!item2.IsFixedFacility || item6.Type == Sensor.Sensor_Type.ESM))
					{
						list = ((list == null) ? tuple_0.Item7 : GetRefinedUncertaintyArea_Clipper(list, tuple_0.Item7));
					}
					if (item6.Capabilities.AltitudeInfo || strategyWrapper.IsWeapon)
					{
						contact_.AltitudeIsKnown = true;
					}
				}
			}
			if (flag2)
			{
				if (list == null)
				{
					UpdateContactData(ref strategyWrapper, ref contact_, item2, bool_0: false);
				}
				else
				{
					UpdateContactData(ref strategyWrapper, ref contact_, item2, bool_0: false, list);
				}
			}
			else
			{
				contact_.UncertaintyArea = list;
			}
			RevertDic(item, item3);
			if (contact_.IsWeaponContact && strategyWrapper.AI.GetClient(contact_))
			{
				contact_.SetStance(strategyWrapper.GetUnitSide(), bool_0: false, Misc.PostureStance.Hostile);
			}
			if (!flag2 && !_ContactsList_OffGrid.ContainsKey(item2.ObjectID))
			{
				_ContactsList_OffGrid.Add(item2.ObjectID, contact_);
			}
			if (flag3)
			{
				UpdateContactData_Local(ref item2.ObjectID, item3);
			}
			else
			{
				NewContactsQueue_Local.AddIfNotExistsElseUpdate(item2.ObjectID, contact_);
				UpdateContactData_Local(ref item2.ObjectID, item3);
			}
			if (contact_ == null)
			{
				return;
			}
			foreach (Sensor item7 in tuple_0.Item3)
			{
				contact_.AddDetectionRecord((strategyWrapper.ObjectID, item7.ObjectID, tuple_0.Item4, tuple_0.Item5, tuple_0.Item6));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 100249", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public void HandleAssumedWeaponContactFromGuidanceDetection(Contact contact_0, Sensor sensor_0, Sensor sensor_1, float float_0, Dictionary<int, EmissionContainer> dictionary_0)
	{
		Weapon weapon = null;
		bool flag = true;
		Contact contact = null;
		foreach (Weapon item in sensor_1.SemiActiveWeaponsGuided)
		{
			if (item.AI.PrimaryTarget != null && item.AI.PrimaryTarget.ActualUnit == strategyWrapper)
			{
				if (strategyWrapper.GetUnitSide().Contacts.ContainsKey(item.ObjectID))
				{
					flag = false;
					contact = strategyWrapper.GetUnitSide().Contacts[item.ObjectID];
					weapon = item;
					break;
				}
				weapon = item;
			}
		}
		if (weapon != null)
		{
			if (flag)
			{
				contact = new Contact(weapon);
			}
			if (contact != null && (flag || (contact.UncertaintyArea != null && contact.RemainingContinousTrackTime < 1f)))
			{
				contact.SetLatitude(null, contact_0.GetLatitude());
				contact.SetLongitude(null, contact_0.GetLongitude());
				contact.SetCurrentAltitude(bool_0: false, contact_0.GetCurrentAltitude());
				contact.CurrentHeading = contact_0.CurrentHeading;
				float float_ = Module_Unit.RangeToUnit_Horiz(strategyWrapper, contact_0);
				contact.UncertaintyArea = GetUncertaintyArea(sensor_0, contact_0, float_, dictionary_0);
				_TokenWrapper.Enqueue(new Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>(contact, weapon, new List<Sensor>(), 0f, SpecialDetectionMode.MissileAssumedFromSemiActiveIllumination, strategyWrapper.ParentScen.Time, contact.UncertaintyArea));
			}
		}
	}

	private void RevertDic(Contact contact_0, List<Sensor> list_0)
	{
		checked
		{
			switch (contact_0.Type)
			{
			case Contact_Base.ContactType.Torpedo:
			{
				Weapon weapon2 = (Weapon)contact_0.ActualUnit;
				if (weapon2.FiringParent == null || !weapon2.FiringParent.IsSubmarine)
				{
					break;
				}
				bool flag6 = false;
				foreach (Contact contacts_ in strategyWrapper.GetUnitSide().Contacts_List)
				{
					if (contacts_.Type == Contact_Base.ContactType.Submarine && Module_Unit.RangeToUnit_Horiz(strategyWrapper, contacts_) <= 15f && !(Math.Abs(MathFunctions.DeleteRequest(Math2.PublishClass(strategyWrapper.GetLatitude(), strategyWrapper.GetLongitude(), contacts_.GetLatitude(), contacts_.GetLongitude()), Math2.PublishClass(strategyWrapper.GetLatitude(), strategyWrapper.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()))) >= 45f))
					{
						flag6 = true;
						break;
					}
				}
				if (flag6)
				{
					break;
				}
				bool flag7 = false;
				foreach (Contact contacts_2 in strategyWrapper.GetUnitSide().Contacts_List)
				{
					if (contacts_2.Type == Contact_Base.ContactType.Submarine && contacts_2.ActualUnit == ((Weapon)contact_0.ActualUnit).FiringParent)
					{
						flag7 = true;
						break;
					}
				}
				if (!flag7 && weapon2.FiringParent.IsDestroyed)
				{
					flag7 = true;
				}
				if (!flag7)
				{
					Contact contact4 = new Contact(((Weapon)contact_0.ActualUnit).FiringParent);
					contact4.SetLatitude(null, contact_0.ActualUnit.GetLatitude());
					contact4.SetLongitude(null, contact_0.ActualUnit.GetLongitude());
					Geodesic_Vincenty.Point3D[] point3D_3 = new Geodesic_Vincenty.Point3D[46];
					Geodesic_EdWilliams.CircleFromPoint(contact4.GetLatitude(), contact4.GetLongitude(), 10.0, 45, ref point3D_3);
					List<Geopoint_Struct> list3 = new List<Geopoint_Struct>();
					Geodesic_Vincenty.Point3D[] array3 = point3D_3;
					for (int k = 0; k < array3.Length; k++)
					{
						Geodesic_Vincenty.Point3D point3D3 = array3[k];
						list3.Add(new Geopoint_Struct(point3D3.X, point3D3.Y));
					}
					contact4.UncertaintyArea = list3;
					_TokenWrapper.Enqueue(new Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>(contact4, ((Weapon)contact_0.ActualUnit).FiringParent, new List<Sensor>(), 0f, SpecialDetectionMode.SubAssumedFromTorpedoDetection, strategyWrapper.ParentScen.Time, list3));
				}
				break;
			}
			case Contact_Base.ContactType.Missile:
			{
				Weapon weapon = (Weapon)contact_0.ActualUnit;
				if (weapon.IsDecoy || weapon.FiringParent == null)
				{
					break;
				}
				if (weapon.FiringParent.IsSubmarine)
				{
					if (Module_Unit.RangeToUnit_Horiz(weapon, weapon.FiringParent) < 5f)
					{
						bool flag = false;
						foreach (Contact contacts_3 in strategyWrapper.GetUnitSide().Contacts_List)
						{
							if (contacts_3.Type == Contact_Base.ContactType.Submarine && !(Math.Abs(MathFunctions.DeleteRequest(Math2.PublishClass(strategyWrapper.GetLatitude(), strategyWrapper.GetLongitude(), contacts_3.GetLatitude(), contacts_3.GetLongitude()), Math2.PublishClass(strategyWrapper.GetLatitude(), strategyWrapper.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()))) >= 45f))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							bool flag2 = false;
							foreach (Contact contacts_4 in strategyWrapper.GetUnitSide().Contacts_List)
							{
								if (contacts_4.Type == Contact_Base.ContactType.Submarine && contacts_4.ActualUnit == ((Weapon)contact_0.ActualUnit).FiringParent)
								{
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								Contact contact = new Contact(((Weapon)contact_0.ActualUnit).FiringParent);
								contact.SetLatitude(null, contact_0.ActualUnit.GetLatitude());
								contact.SetLongitude(null, contact_0.ActualUnit.GetLongitude());
								Geodesic_Vincenty.Point3D[] point3D_ = new Geodesic_Vincenty.Point3D[46];
								Geodesic_EdWilliams.CircleFromPoint(contact.GetLatitude(), contact.GetLongitude(), 1.0, 45, ref point3D_);
								List<Geopoint_Struct> list = new List<Geopoint_Struct>();
								Geodesic_Vincenty.Point3D[] array = point3D_;
								for (int i = 0; i < array.Length; i++)
								{
									Geodesic_Vincenty.Point3D point3D = array[i];
									list.Add(new Geopoint_Struct(point3D.X, point3D.Y));
								}
								contact.UncertaintyArea = list;
								_TokenWrapper.Enqueue(new Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>(contact, ((Weapon)contact_0.ActualUnit).FiringParent, new List<Sensor>(), 0f, SpecialDetectionMode.SubAssumedFromMissileDetection, strategyWrapper.ParentScen.Time, list));
							}
						}
					}
				}
				else
				{
					Contact contact2 = strategyWrapper.GetUnitSide().Contacts[weapon.FiringParent.ObjectID];
					if (!Information.IsNothing(contact2) && contact2.GetStance(strategyWrapper.GetUnitSide()) != Misc.PostureStance.Hostile && !Information.IsNothing(weapon.AI.PrimaryTarget) && weapon.AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint && weapon.AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
					{
						Contact primaryTarget = weapon.AI.PrimaryTarget;
						if (!Information.IsNothing(primaryTarget.ActualUnit) && (primaryTarget.ActualUnit.GetUnitSide() == strategyWrapper.GetUnitSide() || primaryTarget.ActualUnit.GetUnitSide().GetConsidersThisSideToBe(strategyWrapper.GetUnitSide()) == Misc.PostureStance.Friendly))
						{
							bool flag3 = false;
							string text = "";
							if (contact2.IDStatus > Contact_Base.IdentificationStatus.KnownDomain)
							{
								flag3 = true;
								text = "（原因：目标类型）";
							}
							if (!flag3)
							{
								foreach (int key in contact2.DetectedEmissions.Keys)
								{
									Sensor associatedSensor = contact2.DetectedEmissions[key].GetAssociatedSensor(key, strategyWrapper.ParentScen);
									if (associatedSensor.IsPureIlluminator || associatedSensor.IsFireControlRadar)
									{
										flag3 = true;
										text = "（原因：发射模式）";
										break;
									}
								}
							}
							if (flag3)
							{
								contact2.SetStance(strategyWrapper.GetUnitSide(), bool_0: false, Misc.PostureStance.Hostile);
								strategyWrapper.ParentScen.AddMessage("目标：" + contact2.Name + "是最有可能的射击单元" + contact_0.Name + "现在被认为是敌对的！" + text, contact2.Name + " 现在是敌方！", LoggedMessage.MessageType.ContactChange, 0, null, strategyWrapper.GetUnitSide(), new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
							}
						}
					}
				}
				if ((!weapon.FiringParent.IsMobileGroundUnit && !weapon.FiringParent.IsFacility) || list_0.Where((Sensor theS) => theS.Role == Sensor.Sensor_Role.CounterBattery).Count() <= 0)
				{
					break;
				}
				bool flag4 = false;
				foreach (Contact contacts_5 in strategyWrapper.GetUnitSide().Contacts_List)
				{
					if (contacts_5.IsGroundContact && contacts_5.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
					{
						bool? flag5 = contacts_5.ActualUnit?.IsFacility;
						if (((flag5.GetValueOrDefault(true) && ((Facility)contacts_5.ActualUnit).IsArtillery() && flag5.HasValue) || (contacts_5.ActualUnit.IsMobileGroundUnit && ((IMobileGroundUnit)contacts_5.ActualUnit).IsArtillery())) && !(Module_Unit.RangeToPoint_Horiz(contacts_5, weapon.LaunchPoint) > 1f))
						{
							flag4 = false;
							break;
						}
					}
				}
				if (!flag4)
				{
					Contact contact3 = new Contact(((Weapon)contact_0.ActualUnit).FiringParent);
					float float_ = new LockRandom().Next(0, 360);
					GeoPoint launchPoint = weapon.LaunchPoint;
					double double_ = launchPoint.Longitude;
					GeoPoint launchPoint2 = weapon.LaunchPoint;
					double double_2 = launchPoint2.Latitude;
					bool? nullable_ = null;
					double double_3 = contact3.GetLongitude(nullable_);
					bool? nullable_2 = null;
					double double_4 = contact3.GetLatitude(nullable_2);
					double double_5 = 0.8;
					Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_3, ref double_4, ref double_5, ref float_);
					contact3.SetLatitude(nullable_2, double_4);
					contact3.SetLongitude(nullable_, double_3);
					launchPoint2.Latitude = double_2;
					launchPoint.Longitude = double_;
					Geodesic_Vincenty.Point3D[] point3D_2 = new Geodesic_Vincenty.Point3D[46];
					Geodesic_EdWilliams.CircleFromPoint(contact3.GetLatitude(), contact3.GetLongitude(), 1.0, 45, ref point3D_2);
					List<Geopoint_Struct> list2 = new List<Geopoint_Struct>();
					Geodesic_Vincenty.Point3D[] array2 = point3D_2;
					for (int j = 0; j < array2.Length; j++)
					{
						Geodesic_Vincenty.Point3D point3D2 = array2[j];
						list2.Add(new Geopoint_Struct(point3D2.X, point3D2.Y));
					}
					contact3.UncertaintyArea = list2;
					_TokenWrapper.Enqueue(new Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>(contact3, ((Weapon)contact_0.ActualUnit).FiringParent, new List<Sensor>(), 0f, SpecialDetectionMode.CounterBatteryTrack, strategyWrapper.ParentScen.Time, list2));
				}
				break;
			}
			}
		}
	}

	protected virtual void HandleDetectedBaseContact(Module_Unit.Unit unit_0, Side side_0)
	{
		try
		{
			bool flag = side_0.BaseContacts.ContainsKey(unit_0.ObjectID);
			bool flag2 = side_0.m_HelperFacade.ContainsKey_NoLock(unit_0.ObjectID);
			Contact contact;
			if (flag)
			{
				contact = side_0.BaseContacts[unit_0.ObjectID];
			}
			else
			{
				if (flag2)
				{
					return;
				}
				contact = new Contact((ActiveUnit)unit_0);
			}
			contact.SideIsKnown = true;
			if (flag)
			{
				contact.CurrentHeading = unit_0.CurrentHeading;
				contact.CurrentSpeed = unit_0.CurrentSpeed;
				contact.SetCurrentAltitude(bool_0: false, unit_0.GetCurrentAltitude());
				contact.SetLongitude(null, unit_0.GetLongitude());
				contact.SetLatitude(null, unit_0.GetLatitude());
			}
			else
			{
				ProcessNewBaseContact(contact, ref strategyWrapper.ParentScen, side_0, unit_0, strategyWrapper, Contact_Base.IdentificationStatus.PreciseID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100250", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CountConsumer(Contact contact_0, float float_0)
	{
		if (contact_0.HeadingIsKnown && contact_0.SpeedIsKnown && contact_0.AltitudeIsKnown)
		{
			return;
		}
		float num = TMASolution_Sonar(contact_0, float_0);
		if (num >= 0.5f)
		{
			if (num < 0.65f)
			{
				contact_0.SpeedIsKnown = true;
			}
			else if (num < 0.85f)
			{
				contact_0.SpeedIsKnown = true;
				contact_0.HeadingIsKnown = true;
			}
			else
			{
				contact_0.SpeedIsKnown = true;
				contact_0.HeadingIsKnown = true;
				contact_0.AltitudeIsKnown = true;
			}
		}
	}

	private void CustomizeConsumer(Contact contact_0, float float_0)
	{
		if (contact_0.HeadingIsKnown && contact_0.SpeedIsKnown)
		{
			return;
		}
		if (Information.IsNothing(contact_0.UncertaintyArea))
		{
			contact_0.SpeedIsKnown = true;
			contact_0.HeadingIsKnown = true;
			return;
		}
		float num = TMASolution_ESM(contact_0, float_0);
		if (num >= 0.5f)
		{
			if (num < 0.75f)
			{
				contact_0.HeadingIsKnown = true;
				return;
			}
			contact_0.SpeedIsKnown = true;
			contact_0.HeadingIsKnown = true;
		}
	}

	public void AddNewHostedUnitReconRecord(ActiveUnit activeUnit_0, Contact contact_0, Sensor sensor_0)
	{
		Contact.HostedUnitReconRecord hostedUnitReconRecord = new Contact.HostedUnitReconRecord();
		hostedUnitReconRecord.UnitID = activeUnit_0.ObjectID;
		hostedUnitReconRecord.ReconAge = 0f;
		hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownDomain;
		contact_0.IncludeImporter(strategyWrapper.GetUnitSide()).Add(hostedUnitReconRecord);
		LoggedMessage.MessageType messageType_ = LoggedMessage.MessageType.ContactChange;
		if (!strategyWrapper.CommStuff.IsConnectedToSideNetwork)
		{
			messageType_ = LoggedMessage.MessageType.CommsIsolatedMessage;
		}
		strategyWrapper.AddMessage("新" + activeUnit_0.UnitType_String.ToLower() + "发现了" + contact_0.Name + "通过" + strategyWrapper.Name + "（传感器：" + sensor_0.Name + "). ", "目标报告", messageType_, 0, bool_0: false, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
	}

	private void CloneConsumer(AirFacility airFacility_0, Sensor sensor_0, Contact contact_0, float float_0)
	{
		if (!airFacility_0.IsOpenAirFacility || airFacility_0.HostedAircraft.Count == 0)
		{
			return;
		}
		LoggedMessage.MessageType messageType_ = LoggedMessage.MessageType.ContactChange;
		if (!strategyWrapper.CommStuff.IsConnectedToSideNetwork)
		{
			messageType_ = LoggedMessage.MessageType.CommsIsolatedMessage;
		}
		float num = 0f;
		foreach (Aircraft value in airFacility_0.HostedAircraft.Values)
		{
			num = sensor_0.MaxIDRangeOnThisTarget(strategyWrapper, value);
			if (num * 3f < float_0)
			{
				continue;
			}
			Contact.HostedUnitReconRecord hostedUnitReconRecord = null;
			foreach (Contact.HostedUnitReconRecord item in contact_0.IncludeImporter(strategyWrapper.GetUnitSide()))
			{
				if (Operators.CompareString(item.UnitID, value.ObjectID, TextCompare: false) == 0)
				{
					hostedUnitReconRecord = item;
					hostedUnitReconRecord.ReconAge = 0f;
					break;
				}
			}
			if (Information.IsNothing(hostedUnitReconRecord))
			{
				AddNewHostedUnitReconRecord(value, contact_0, sensor_0);
			}
			else
			{
				if (float_0 < num)
				{
					if (hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
					{
						hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownClass;
						strategyWrapper.AddMessage("飞机以前发现过" + contact_0.Name + "已被确定为：" + value.UnitClass + "（侦察：" + strategyWrapper.Name + " - 传感器：" + sensor_0.Name + "). ", "目标报告", messageType_, 0, bool_0: false, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
					}
				}
				else if (float_0 < num * 2f && hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownType)
				{
					hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownType;
					strategyWrapper.AddMessage("飞机以前发现过" + contact_0.Name + " 已被分类为：" + value.SubTypeDescription + "（侦察：" + strategyWrapper.Name + " - 传感器：" + sensor_0.Name + "). ", "目标报告", messageType_, 0, bool_0: false, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				}
				hostedUnitReconRecord.ReconAge = 0f;
			}
			contact_0.TimeSinceRecon = 0f;
		}
		Lazy<List<Contact.HostedUnitReconRecord>> lazy = new Lazy<List<Contact.HostedUnitReconRecord>>();
		List<Contact.HostedUnitReconRecord> list = contact_0.IncludeImporter(strategyWrapper.GetUnitSide());
		int num2 = list.Count - 1;
		ActiveUnit activeUnit = null;
		for (int i = 0; i <= num2; i++)
		{
			Contact.HostedUnitReconRecord hostedUnitReconRecord2;
			try
			{
				hostedUnitReconRecord2 = list[i];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				continue;
			}
			strategyWrapper.ParentScen.ActiveUnits.TryGetValue(hostedUnitReconRecord2.UnitID, ref activeUnit);
			if (Information.IsNothing(activeUnit))
			{
				if (float_0 < num * 2f)
				{
					lazy.Value.Add(hostedUnitReconRecord2);
				}
			}
			else if (!airFacility_0.ParentPlatform.DockingOps.EmbarkedBoats.Contains(activeUnit) && (!activeUnit.IsAircraft || !airFacility_0.ParentPlatform.AirOps.EmbarkedAircraft_ReadOnly.Contains((Aircraft)activeUnit)) && float_0 < num * 2f)
			{
				lazy.Value.Add(hostedUnitReconRecord2);
			}
		}
		foreach (Contact.HostedUnitReconRecord item2 in lazy.Value)
		{
			CheckConsumer(contact_0, item2);
		}
	}

	public void AttemptReconOfHostedUnits(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0)
	{
		if ((Information.IsNothing(contact_0.ActualUnit) || !contact_0.ActualUnit.IsSubmarine) && !activeUnit_0.IsAircraft && sensor_0.GetCanPerformBDA(bool_0: true, bool_1: false))
		{
			float float_ = Module_Unit.RangeToUnit_Slant(strategyWrapper, activeUnit_0);
			AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
			AirFacility[] array = airFacilities_ReadOnly;
			foreach (AirFacility airFacility_ in array)
			{
				CloneConsumer(airFacility_, sensor_0, contact_0, float_);
			}
			DockFacility[] dockFacilities_ReadOnly = activeUnit_0.DockFacilities_ReadOnly;
			DockFacility[] array2 = dockFacilities_ReadOnly;
			foreach (DockFacility dockFacility_ in array2)
			{
				InitConsumer(dockFacility_, sensor_0, contact_0, float_);
			}
		}
	}

	public void method_0(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0)
	{
		try
		{
			if ((!Information.IsNothing(contact_0.ActualUnit) && contact_0.ActualUnit.IsSubmarine && !((Submarine)contact_0.ActualUnit).IsSurfaced) || activeUnit_0.IsAircraft || !sensor_0.GetCanPerformBDA(bool_0: true, bool_1: true))
			{
				return;
			}
			string text = Misc.FlushRequest(contact_0.BDA_StructuralIntegrity) + Misc.CalcRequest(contact_0.BDA_FireLevel);
			if (strategyWrapper.IsShip || strategyWrapper.IsSubmarine)
			{
				text += Misc.RateRequest(contact_0.BDA_FloodLevel);
			}
			switch (sensor_0.Type)
			{
			case Sensor.Sensor_Type.Visual:
			case Sensor.Sensor_Type.Infrared:
				ConnectConsumer(contact_0, activeUnit_0, sensor_0);
				MoveConsumer(contact_0, activeUnit_0, sensor_0);
				DeleteConsumer(contact_0, activeUnit_0, sensor_0);
				break;
			case Sensor.Sensor_Type.Radar:
				if (sensor_0.Codes.Classification)
				{
					ConnectConsumer(contact_0, activeUnit_0, sensor_0);
				}
				break;
			}
			if (sensor_0.IsSonar && !sensor_0.IsActive)
			{
				DeleteConsumer(contact_0, activeUnit_0, sensor_0);
			}
			string text2 = Misc.FlushRequest(contact_0.BDA_StructuralIntegrity) + Misc.CalcRequest(contact_0.BDA_FireLevel);
			if (strategyWrapper.IsShip || strategyWrapper.IsSubmarine)
			{
				text2 += Misc.RateRequest(contact_0.BDA_FloodLevel);
			}
			if (string.CompareOrdinal(text2, text) != 0 && !string.IsNullOrEmpty(text))
			{
				NotifyBDAChange(contact_0, strategyWrapper.GetUnitSide());
			}
			if (!Information.IsNothing(contact_0))
			{
				contact_0.TimeSinceBDA = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100251", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void NotifyBDAChange(Contact contact_0, Side side_0)
	{
		try
		{
			if (!Information.IsNothing(contact_0.ActualUnit))
			{
				string text = strategyWrapper.Name + "报告目标战斗毁伤评估BDA状态变化：" + contact_0.Name;
				if (contact_0.BDA_StructuralIntegrity.HasValue)
				{
					text = text + " - " + Misc.FlushRequest(contact_0.BDA_StructuralIntegrity);
				}
				if (contact_0.BDA_FireLevel.HasValue)
				{
					text = text + " - " + Misc.CalcRequest(contact_0.BDA_FireLevel);
				}
				if ((contact_0.ActualUnit.IsShip || contact_0.ActualUnit.IsSubmarine) && contact_0.BDA_FloodLevel.HasValue)
				{
					text = text + " - " + Misc.RateRequest(contact_0.BDA_FloodLevel);
				}
				long messageIncrement = strategyWrapper.ParentScen.MessageIncrement;
				strategyWrapper.ParentScen.MessageIncrement_Add1();
				LoggedMessage value = new LoggedMessage(messageIncrement, text, "目标报告", LoggedMessage.MessageType.ContactChange, strategyWrapper.ParentScen.Time, strategyWrapper.ObjectID, 0, side_0, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				m_PublisherWrapper.Add(messageIncrement, value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100252", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ConnectConsumer(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0)
	{
		try
		{
			if (!Information.IsNothing(activeUnit_0) && !activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				float damagePercent = activeUnit_0.Damage.DamagePercent;
				if (damagePercent == 0f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.Undamaged;
				}
				else if (damagePercent < 20f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.LightDamage;
				}
				else if (damagePercent < 50f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.MediumDamage;
				}
				else if (damagePercent < 100f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.HeavyDamage;
				}
				else
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.Destroyed;
				}
			}
			else
			{
				contact_0.BDA_StructuralIntegrity = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100253", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void MoveConsumer(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0)
	{
		try
		{
			if (!Information.IsNothing(activeUnit_0) && !activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				contact_0.BDA_FireLevel = activeUnit_0.Damage.FireIntensity;
			}
			else
			{
				contact_0.BDA_FireLevel = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100254", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DeleteConsumer(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0)
	{
		try
		{
			if (!Information.IsNothing(activeUnit_0) && !activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				contact_0.BDA_FloodLevel = activeUnit_0.Damage.FloodIntensity;
			}
			else
			{
				contact_0.BDA_FloodLevel = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100255", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Contact_Base.IdentificationStatus? AddConsumer(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0, float float_0)
	{
		Contact_Base.IdentificationStatus? result = null;
		try
		{
			if (sensor_0.Codes.SyntheticApertureRadar)
			{
				if (contact_0.Type == Contact_Base.ContactType.Air)
				{
					result = null;
					return result;
				}
				float num = 0.75f;
				float num2 = 0.5f;
				if (sensor_0.IsContinousTrackingCapable)
				{
					num = (float)((double)num * 1.25);
					num2 = (float)((double)num2 * 1.25);
				}
				switch (sensor_0.TechGeneration)
				{
				case GlobalVariables.TechGenerationClass.Early1970s:
				case GlobalVariables.TechGenerationClass.Late1970s:
				case GlobalVariables.TechGenerationClass.Early1980s:
				{
					GlobalVariables.ProficiencyLevel? proficiency2 = strategyWrapper.Proficiency;
					int? num4 = (int?)proficiency2;
					if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						num = (float)((double)num * 0.25);
						num2 = (float)((double)num2 * 0.25);
						break;
					}
					num4 = (int?)proficiency2;
					if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						num = (float)((double)num * 0.5);
						num2 = (float)((double)num2 * 0.5);
						break;
					}
					num4 = (int?)proficiency2;
					bool? flag;
					bool? flag2 = (flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 2) : null));
					bool? flag3;
					bool? flag4;
					if (flag2.HasValue && flag.GetValueOrDefault())
					{
						flag3 = true;
					}
					else
					{
						num4 = (int?)proficiency2;
						flag2 = (flag4 = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 3) : null));
						flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
					}
					bool? flag5 = flag3;
					flag4 = flag3;
					bool? flag6;
					bool? flag7;
					if (flag4.HasValue && flag5.GetValueOrDefault())
					{
						flag6 = true;
					}
					else
					{
						num4 = (int?)proficiency2;
						flag4 = (flag7 = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 4) : null));
						flag6 = ((!flag4.HasValue) ? null : (flag7.GetValueOrDefault() | flag5));
					}
					flag7 = flag6;
					flag7.GetValueOrDefault();
					break;
				}
				case GlobalVariables.TechGenerationClass.Early1950s:
				case GlobalVariables.TechGenerationClass.Late1950s:
				case GlobalVariables.TechGenerationClass.Early1960s:
				case GlobalVariables.TechGenerationClass.Late1960s:
				{
					GlobalVariables.ProficiencyLevel? proficiency = strategyWrapper.Proficiency;
					int? num3 = (int?)proficiency;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						num = (float)((double)num * 0.1);
						num2 = (float)((double)num2 * 0.1);
						break;
					}
					num3 = (int?)proficiency;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						num = (float)((double)num * 0.25);
						num2 = (float)((double)num2 * 0.25);
						break;
					}
					num3 = (int?)proficiency;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						num = (float)((double)num * 0.5);
						num2 = (float)((double)num2 * 0.5);
						break;
					}
					num3 = (int?)proficiency;
					if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 3) : null).GetValueOrDefault())
					{
						num3 = (int?)proficiency;
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 4) : null).GetValueOrDefault())
						{
							num = (float)((double)num * 1.5);
							num2 = (float)((double)num2 * 1.5);
						}
					}
					break;
				}
				}
				if (float_0 / sensor_0.maxRange <= num2)
				{
					result = Contact_Base.IdentificationStatus.KnownClass;
					return result;
				}
				return result;
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100256", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private Contact_Base.IdentificationStatus? DestroyConsumer(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0, float float_0)
	{
		Contact_Base.IdentificationStatus? result = null;
		try
		{
			if (!sensor_0.Codes.NCTR_JEM && !sensor_0.Codes.NCTR_NBILST)
			{
				result = null;
				return result;
			}
			if (contact_0.Type == Contact_Base.ContactType.Air)
			{
				if (contact_0.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
				{
					Contact_Base.IdentificationStatus value = Contact_Base.IdentificationStatus.Unknown;
					if (sensor_0.Codes.NCTR_JEM)
					{
						ActiveUnit unit_ = strategyWrapper;
						string string_ = "";
						if (Math.Abs(Module_Unit.PrintTokenizer(unit_, activeUnit_0, bool_0: true, ref string_)) <= 15f)
						{
							float num = 0.75f;
							float num3 = 0.5f;
							if (sensor_0.IsContinousTrackingCapable)
							{
								num = (float)((double)num * 1.25);
								num3 = (float)((double)num3 * 1.25);
							}
							switch (sensor_0.TechGeneration)
							{
							case GlobalVariables.TechGenerationClass.Early1970s:
							case GlobalVariables.TechGenerationClass.Late1970s:
							case GlobalVariables.TechGenerationClass.Early1980s:
							{
								GlobalVariables.ProficiencyLevel? proficiency2 = strategyWrapper.Proficiency;
								int? num5 = (int?)proficiency2;
								if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									num = (float)((double)num * 0.25);
									num3 = (float)((double)num3 * 0.25);
									break;
								}
								num5 = (int?)proficiency2;
								if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									num = (float)((double)num * 0.5);
									num3 = (float)((double)num3 * 0.5);
									break;
								}
								num5 = (int?)proficiency2;
								bool? flag;
								bool? flag7 = (flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 2) : null));
								bool? flag8;
								bool? flag9;
								if (flag7.HasValue && flag.GetValueOrDefault())
								{
									flag8 = true;
								}
								else
								{
									num5 = (int?)proficiency2;
									flag7 = (flag9 = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 3) : null));
									flag8 = ((!flag7.HasValue) ? null : (flag9.GetValueOrDefault() | flag));
								}
								bool? flag10 = flag8;
								flag9 = flag8;
								bool? flag11;
								bool? flag12;
								if (flag9.HasValue && flag10.GetValueOrDefault())
								{
									flag11 = true;
								}
								else
								{
									num5 = (int?)proficiency2;
									flag9 = (flag12 = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 4) : null));
									flag11 = ((!flag9.HasValue) ? null : (flag12.GetValueOrDefault() | flag10));
								}
								flag12 = flag11;
								flag12.GetValueOrDefault();
								break;
							}
							case GlobalVariables.TechGenerationClass.Early1950s:
							case GlobalVariables.TechGenerationClass.Late1950s:
							case GlobalVariables.TechGenerationClass.Early1960s:
							case GlobalVariables.TechGenerationClass.Late1960s:
							{
								GlobalVariables.ProficiencyLevel? proficiency = strategyWrapper.Proficiency;
								int? num4 = (int?)proficiency;
								if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									num = (float)((double)num * 0.1);
									num3 = (float)((double)num3 * 0.1);
									break;
								}
								num4 = (int?)proficiency;
								if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									num = (float)((double)num * 0.25);
									num3 = (float)((double)num3 * 0.25);
									break;
								}
								num4 = (int?)proficiency;
								if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 2) : null).GetValueOrDefault())
								{
									num = (float)((double)num * 0.5);
									num3 = (float)((double)num3 * 0.5);
									break;
								}
								num4 = (int?)proficiency;
								if (!(num4.HasValue ? new bool?(num4.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									num4 = (int?)proficiency;
									if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 4) : null).GetValueOrDefault())
									{
										num = (float)((double)num * 1.5);
										num3 = (float)((double)num3 * 1.5);
									}
								}
								break;
							}
							}
							float num6 = float_0 / sensor_0.maxRange;
							if (num6 <= num)
							{
								value = Contact_Base.IdentificationStatus.KnownType;
							}
							if (num6 <= num3)
							{
								value = Contact_Base.IdentificationStatus.KnownClass;
								result = Contact_Base.IdentificationStatus.KnownClass;
								return result;
							}
						}
					}
					if (sensor_0.Codes.NCTR_NBILST)
					{
						float num7 = 0.6f;
						float num8 = 0.3f;
						switch (sensor_0.TechGeneration)
						{
						case GlobalVariables.TechGenerationClass.Early1970s:
						case GlobalVariables.TechGenerationClass.Late1970s:
						case GlobalVariables.TechGenerationClass.Early1980s:
						{
							GlobalVariables.ProficiencyLevel? proficiency4 = strategyWrapper.Proficiency;
							int? num10 = (int?)proficiency4;
							if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = (float)((double)num7 * 0.25);
								num8 = (float)((double)num8 * 0.25);
								break;
							}
							num10 = (int?)proficiency4;
							if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = (float)((double)num7 * 0.5);
								num8 = (float)((double)num8 * 0.5);
								break;
							}
							num10 = (int?)proficiency4;
							bool? flag13;
							bool? flag14 = (flag13 = (num10.HasValue ? new bool?(num10.GetValueOrDefault() == 2) : null));
							bool? flag2;
							bool? flag3;
							if (flag14.HasValue && flag13.GetValueOrDefault())
							{
								flag2 = true;
							}
							else
							{
								num10 = (int?)proficiency4;
								flag14 = (flag3 = (num10.HasValue ? new bool?(num10.GetValueOrDefault() == 3) : null));
								flag2 = ((!flag14.HasValue) ? null : (flag3.GetValueOrDefault() | flag13));
							}
							bool? flag4 = flag2;
							flag3 = flag2;
							bool? flag5;
							bool? flag6;
							if (flag3.HasValue && flag4.GetValueOrDefault())
							{
								flag5 = true;
							}
							else
							{
								num10 = (int?)proficiency4;
								flag3 = (flag6 = (num10.HasValue ? new bool?(num10.GetValueOrDefault() == 4) : null));
								flag5 = ((!flag3.HasValue) ? null : (flag6.GetValueOrDefault() | flag4));
							}
							flag6 = flag5;
							flag6.GetValueOrDefault();
							break;
						}
						case GlobalVariables.TechGenerationClass.Early1950s:
						case GlobalVariables.TechGenerationClass.Late1950s:
						case GlobalVariables.TechGenerationClass.Early1960s:
						case GlobalVariables.TechGenerationClass.Late1960s:
						{
							GlobalVariables.ProficiencyLevel? proficiency3 = strategyWrapper.Proficiency;
							int? num9 = (int?)proficiency3;
							if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = (float)((double)num7 * 0.1);
								num8 = (float)((double)num8 * 0.1);
								break;
							}
							num9 = (int?)proficiency3;
							if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = (float)((double)num7 * 0.25);
								num8 = (float)((double)num8 * 0.25);
								break;
							}
							num9 = (int?)proficiency3;
							if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								num7 = (float)((double)num7 * 0.5);
								num8 = (float)((double)num8 * 0.5);
								break;
							}
							num9 = (int?)proficiency3;
							if (!(num9.HasValue ? new bool?(num9.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num9 = (int?)proficiency3;
								if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num7 = (float)((double)num7 * 1.5);
									num8 = (float)((double)num8 * 1.5);
								}
							}
							break;
						}
						}
						float num2 = float_0 / sensor_0.maxRange;
						if (num2 >= num7)
						{
							value = Contact_Base.IdentificationStatus.KnownType;
						}
						if (num2 >= num8)
						{
							value = Contact_Base.IdentificationStatus.KnownClass;
							result = Contact_Base.IdentificationStatus.KnownClass;
							return result;
						}
					}
					result = value;
					return result;
				}
				result = null;
				return result;
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100256", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private Contact_Base.IdentificationStatus ComputeConsumer(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0)
	{
		try
		{
			if (contact_0.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
			{
				if (contact_0.TimeSinceESM_Identification < 15f)
				{
					return Contact_Base.IdentificationStatus.Unknown;
				}
				if (contact_0.HasDetectedEmissions)
				{
					Scenario scenario_ = strategyWrapper.ParentScen;
					GlobalVariables.ActiveUnitType activeUnitType;
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
						activeUnitType = GlobalVariables.ActiveUnitType.Aircraft;
						break;
					case Contact_Base.ContactType.Surface:
						activeUnitType = GlobalVariables.ActiveUnitType.Ship;
						break;
					case Contact_Base.ContactType.Submarine:
						activeUnitType = GlobalVariables.ActiveUnitType.Submarine;
						break;
					default:
						return Contact_Base.IdentificationStatus.Unknown;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						activeUnitType = GlobalVariables.ActiveUnitType.Facility;
						break;
					case Contact_Base.ContactType.Missile:
					case Contact_Base.ContactType.Torpedo:
						activeUnitType = GlobalVariables.ActiveUnitType.Weapon;
						break;
					}
					List<int> list = new List<int>();
					foreach (int key in contact_0.DetectedEmissions.Keys)
					{
						if (contact_0.DetectedEmissions[key].PreciseID)
						{
							list.Add(key);
						}
					}
					if (contact_0.ListOfESMMatches == null)
					{
						contact_0.ListOfESMMatches = DBFunctions.EW_GetAllUnitsMatchingTheseEmissions(list, activeUnitType, scenario_, scenario_.DBConnection);
					}
					list = null;
					if (contact_0.ListOfESMMatches.Count == 0)
					{
						return Contact_Base.IdentificationStatus.Unknown;
					}
					Contact_Base.IdentificationStatus identificationStatus = Contact_Base.IdentificationStatus.Unknown;
					if (contact_0.ListOfESMMatches.Count == 1)
					{
						contact_0.TimeSinceESM_Identification = 0f;
						return Contact_Base.IdentificationStatus.KnownClass;
					}
					HashSet<int> hashSet = new HashSet<int>();
					switch (activeUnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						foreach (int listOfESMMatch in contact_0.ListOfESMMatches)
						{
							hashSet.Add(DBFunctions.GetAircraftType_Int(ref scenario_, listOfESMMatch));
						}
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						foreach (int listOfESMMatch2 in contact_0.ListOfESMMatches)
						{
							hashSet.Add(DBFunctions.GetShipType_Int(ref scenario_, listOfESMMatch2));
						}
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						foreach (int listOfESMMatch3 in contact_0.ListOfESMMatches)
						{
							hashSet.Add(DBFunctions.GetSubmarineType_Int(ref scenario_, listOfESMMatch3));
						}
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						foreach (int listOfESMMatch4 in contact_0.ListOfESMMatches)
						{
							hashSet.Add(DBFunctions.GetFacilityType_Int(ref scenario_, listOfESMMatch4));
						}
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						foreach (int listOfESMMatch5 in contact_0.ListOfESMMatches)
						{
							hashSet.Add(DBFunctions.GetWeaponType_Int(ref scenario_, listOfESMMatch5));
						}
						break;
					}
					if (hashSet.Count == 1)
					{
						contact_0.TimeSinceESM_Identification = 0f;
						identificationStatus = Contact_Base.IdentificationStatus.KnownType;
					}
					if (identificationStatus < Contact_Base.IdentificationStatus.KnownType)
					{
						short num = 30;
						num = (short)(30 + (sensor_0.TechGeneration - 2005));
						float heldFor = contact_0.HeldFor;
						if (heldFor >= 180f)
						{
							num = ((heldFor < 360f) ? ((short)(num + 5)) : ((heldFor < 540f) ? ((short)(num + 10)) : ((heldFor < 720f) ? ((short)(num + 15)) : ((heldFor < 900f) ? ((short)(num + 25)) : ((short)(num + 30))))));
						}
						int count = hashSet.Count;
						num = ((count < 5) ? ((short)Math.Round((double)num / 2.0)) : ((count < 10) ? ((short)Math.Round((double)num / 5.0)) : ((short)Math.Round((double)num / 10.0))));
						if (GameGeneral.LockRandom_0.Next(0, 101) < num)
						{
							contact_0.TimeSinceESM_Identification = 0f;
							identificationStatus = Contact_Base.IdentificationStatus.KnownType;
						}
					}
					if (contact_0.ListOfESMMatches.Count == 1)
					{
						contact_0.TimeSinceESM_Identification = 0f;
						identificationStatus = Contact_Base.IdentificationStatus.KnownClass;
					}
					else
					{
						byte b = 10;
						b = (byte)(10 + (sensor_0.TechGeneration - 2005));
						float heldFor2 = contact_0.HeldFor;
						if (heldFor2 >= 180f)
						{
							b = ((heldFor2 < 360f) ? ((byte)(b + 5)) : ((heldFor2 < 540f) ? ((byte)(b + 10)) : ((heldFor2 < 720f) ? ((byte)(b + 15)) : ((heldFor2 < 900f) ? ((byte)(b + 25)) : ((byte)(b + 30))))));
						}
						int num2 = DBFunctions.EW_GetNumberOfBasicVariants(contact_0.ListOfESMMatches, activeUnitType, strategyWrapper.ParentScen.DBConnection);
						b = ((num2 < 5) ? ((byte)Math.Round((double)(int)b / 2.0)) : ((num2 < 10) ? ((byte)Math.Round((double)(int)b / 5.0)) : ((byte)Math.Round((double)(int)b / 10.0))));
						if (GameGeneral.LockRandom_0.Next(40, 101) < b)
						{
							contact_0.TimeSinceESM_Identification = 0f;
							identificationStatus = Contact_Base.IdentificationStatus.KnownClass;
						}
					}
					hashSet = null;
					return identificationStatus;
				}
				return Contact_Base.IdentificationStatus.Unknown;
			}
			return Contact_Base.IdentificationStatus.Unknown;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100257", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return Contact_Base.IdentificationStatus.Unknown;
		}
	}

	private Contact_Base.IdentificationStatus PatchConsumer(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_0)
	{
		try
		{
			int num = 0;
			switch (activeUnit_0.NoiseLevelClass)
			{
			case GlobalVariables.UnitNoiseLevelClass.Loud:
				if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 25;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					num = 20;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
				{
					num = 15;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
				{
					num = 10;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.Noisy:
				if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 20;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					num = 15;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
				{
					num = 10;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
				{
					num = 5;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.Quiet:
				if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 15;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					num = 10;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
				{
					num = 5;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
				{
					num = -1;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.VQuiet:
				if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 10;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					num = 5;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
				{
					num = -1;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
				{
					num = -1;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.ExQuiet:
				if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 5;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					num = -1;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
				{
					num = -1;
				}
				else if (sensor_0.GetSearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
				{
					num = -1;
				}
				break;
			}
			if (num < 0)
			{
				return Contact_Base.IdentificationStatus.Unknown;
			}
			float desiredSpeed = activeUnit_0.DesiredSpeed;
			if (desiredSpeed >= 6f)
			{
				num = ((desiredSpeed < 12f) ? (num + 5) : ((desiredSpeed < 18f) ? (num + 10) : ((desiredSpeed < 24f) ? (num + 15) : (num + 20))));
			}
			if (activeUnit_0.IsSubmarine && ((Submarine)activeUnit_0).DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
			{
				num += 15;
			}
			float heldFor = contact_0.HeldFor;
			int num2 = ((heldFor < 360f) ? num : ((heldFor < 720f) ? (num + 5) : ((heldFor < 1080f) ? (num + 10) : ((heldFor < 1440f) ? (num + 15) : ((heldFor < 1800f) ? (num + 25) : (num + 30))))));
			int num3 = (int)Math.Round((double)num2 / 2.0);
			int num4 = num2 + 20;
			int num5 = GameGeneral.LockRandom_0.Next(20, 101);
			if (num5 < num3)
			{
				return Contact_Base.IdentificationStatus.PreciseID;
			}
			if (num5 < num2)
			{
				return Contact_Base.IdentificationStatus.KnownClass;
			}
			if (num5 < num4)
			{
				return Contact_Base.IdentificationStatus.KnownType;
			}
			return Contact_Base.IdentificationStatus.KnownDomain;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100258", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return Contact_Base.IdentificationStatus.KnownDomain;
		}
	}

	public static void ProcessNewContact(ref Contact contact_0, ref Scenario scenario_0, Side side_0, ActiveUnit activeUnit_0, SpecialDetectionMode specialDetectionMode_0, ActiveUnit activeUnit_1 = null, Contact_Base.IdentificationStatus identificationStatus_0 = Contact_Base.IdentificationStatus.KnownDomain, List<Sensor> list_0 = null)
	{
		try
		{
			List<Geopoint_Struct> uncertaintyArea = null;
			ObservableDictionary<int, EmissionContainer> detectedEmissions = null;
			float remainingContinousTrackTime = 0f;
			if (contact_0 != null)
			{
				if (contact_0.UncertaintyArea != null)
				{
					uncertaintyArea = contact_0.UncertaintyArea;
				}
				if (contact_0.HasDetectedEmissions)
				{
					detectedEmissions = contact_0.DetectedEmissions;
				}
				remainingContinousTrackTime = contact_0.RemainingContinousTrackTime;
			}
			side_0.m_StateFacade++;
			contact_0 = new Contact(activeUnit_0, side_0.m_StateFacade);
			contact_0.UncertaintyArea = uncertaintyArea;
			contact_0.DetectedEmissions = detectedEmissions;
			contact_0.RemainingContinousTrackTime = remainingContinousTrackTime;
			if (activeUnit_1 == null)
			{
				contact_0.method_0(scenario_0, side_0, null, null, bool_0: false, bool_1: true, bool_2: false, bool_3: true, identificationStatus_0);
			}
			else
			{
				contact_0.method_0(scenario_0, side_0, null, null, bool_0: false, activeUnit_1.CommStuff.IsConnectedToSideNetwork, bool_2: false, bool_3: true, identificationStatus_0);
			}
			contact_0.OriginalDetectorSide = side_0;
			bool bool_ = !side_0.Contacts.ContainsKey(activeUnit_0.ObjectID);
			UpdateContactData(ref activeUnit_1, ref contact_0, activeUnit_0, bool_);
			if (activeUnit_1 == null)
			{
				side_0.AddContact(contact_0);
			}
			else if (activeUnit_1.CommStuff.IsConnectedToSideNetwork)
			{
				side_0.AddContact(contact_0);
			}
			else
			{
				activeUnit_1.Sensory._ContactsList_OffGrid[activeUnit_0.ObjectID] = contact_0;
			}
			if (activeUnit_0.IsActiveUnit && activeUnit_0.GetIsAutoDetectable(side_0))
			{
				contact_0.IsPreciselyLocatedOnThisPulse = true;
				contact_0.HeadingIsKnown = true;
				contact_0.SpeedIsKnown = true;
				contact_0.AltitudeIsKnown = true;
				contact_0.AddDetectionRecord((null, null, 0f, SpecialDetectionMode.AutoDetection, activeUnit_0.ParentScen.Time));
				return;
			}
			if (list_0 != null)
			{
				float float_ = Module_Unit.RangeToUnit_Slant(activeUnit_1, activeUnit_0);
				foreach (Sensor item in list_0)
				{
					if (item.GetIsPrecise(float_))
					{
						contact_0.IsPreciselyLocatedOnThisPulse = true;
						break;
					}
				}
			}
			string text;
			try
			{
				text = ((contact_0.UncertaintyArea == null) ? Math.Round(Module_Unit.RangeToUnit_Horiz(activeUnit_1, contact_0), 1).ToString() : ("估计" + Math.Round(Module_Unit.RangeToUnit_Horiz(activeUnit_1, contact_0), 0)));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200012", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				text = "[unspecified]";
				ProjectData.ClearProjectError();
			}
			string text2;
			try
			{
				text2 = ((int)Math.Round(activeUnit_1.AI.BearingToUnit_True(contact_0))).ToString();
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 200015", exception_2.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				text2 = "[unspecified]";
				ProjectData.ClearProjectError();
			}
			LoggedMessage.MessageType messageType_;
			if (!Information.IsNothing(activeUnit_1) && !activeUnit_1.CommStuff.IsConnectedToSideNetwork)
			{
				messageType_ = LoggedMessage.MessageType.CommsIsolatedMessage;
			}
			else if (contact_0.ActualUnit.IsWeapon & !contact_0.ActualUnit.IsMobileDecoy)
			{
				messageType_ = LoggedMessage.MessageType.NewWeaponContact;
			}
			else
			{
				switch (contact_0.ActualUnit.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					messageType_ = LoggedMessage.MessageType.NewAirContact;
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					messageType_ = LoggedMessage.MessageType.NewSurfaceContact;
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					messageType_ = LoggedMessage.MessageType.NewUnderwaterContact;
					break;
				default:
					messageType_ = LoggedMessage.MessageType.NewContact;
					break;
				case GlobalVariables.ActiveUnitType.Facility:
				case GlobalVariables.ActiveUnitType.Vehicle:
					messageType_ = LoggedMessage.MessageType.NewGroundContact;
					break;
				}
			}
			string text3 = SelectConsumer(list_0, activeUnit_0, activeUnit_1);
			string text4 = "";
			if (activeUnit_1.IsAircraft && Operators.CompareString(activeUnit_1.Name, activeUnit_1.UnitClass, TextCompare: false) != 0)
			{
				text4 = " (" + activeUnit_1.UnitClass + ")";
			}
			switch (specialDetectionMode_0)
			{
			case SpecialDetectionMode.None:
			{
				string string_;
				switch (contact_0.Type)
				{
				case Contact_Base.ContactType.Air:
					string_ = "新空中目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Missile:
					string_ = "新武器目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Surface:
					string_ = "新海面目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Submarine:
					string_ = "新水下目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Orbital:
					string_ = "新空间目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Torpedo:
					string_ = "新鱼雷目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Mine:
					string_ = "新雷区目标（" + contact_0.Name + ")";
					break;
				default:
					string_ = "新目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Sonobuoy:
					string_ = "新声呐目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Installation:
				case Contact_Base.ContactType.AirBase:
				case Contact_Base.ContactType.NavalBase:
					string_ = "新地面固定目标（" + contact_0.Name + ")";
					break;
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.MobileGroup:
					string_ = "新地面移动目标（" + contact_0.Name + ")";
					break;
				}
				if (list_0.Count == 0)
				{
					activeUnit_1.AddMessage("新目标！命名为 " + contact_0.Name + " - 探测单位 " + activeUnit_1.Name + text4 + "在" + Conversions.ToString((int)Math.Round(activeUnit_1.AI.BearingToUnit_True(contact_0))) + "度 - " + Conversions.ToString(Math.Round(Module_Unit.RangeToUnit_Horiz(activeUnit_1, contact_0), 1)) + "nm", string_, messageType_, 1, bool_0: false, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
					break;
				}
				string text5 = "";
				foreach (Sensor item2 in list_0)
				{
					text5 = Misc.ReadRequest(item2.Name) + ", ";
				}
				if (list_0.Count > 0)
				{
					text5 = Strings.Left(text5, Strings.Len(text5) - 2);
				}
				activeUnit_1.AddMessage("新目标！命名为 " + contact_0.Name + " - 探测单位 " + activeUnit_1.Name + text4 + " [传感器：" + text5 + "] 在" + text2 + "度 - " + text + "nm" + text3, string_, messageType_, 1, bool_0: false, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				break;
			}
			case SpecialDetectionMode.SubAssumedFromTorpedoDetection:
				scenario_0.AddMessage("新的可能的子目标！ （探测到鱼雷）。命名为 " + contact_0.Name, "新水下目标（" + contact_0.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, side_0, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				break;
			case SpecialDetectionMode.SubAssumedFromMissileDetection:
				scenario_0.AddMessage("新的可能的子目标！ （发现导弹发射）。命名为 " + contact_0.Name, "新水下目标（" + contact_0.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, side_0, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				break;
			case SpecialDetectionMode.FlamingDatum:
				scenario_0.AddMessage("新的可能的子目标！ （火焰情报）。命名为 " + contact_0.Name, "新水下目标（" + contact_0.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, side_0, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				break;
			case SpecialDetectionMode.MissileAssumedFromSemiActiveIllumination:
				scenario_0.AddMessage("New probable missile contact! (Guidance illumination detected). Designated " + contact_0.Name, "新武器目标（" + contact_0.Name + ")", LoggedMessage.MessageType.NewWeaponContact, 0, null, side_0, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				break;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case SpecialDetectionMode.CounterBatteryTrack:
				contact_0.method_0(scenario_0, side_0, null, null, bool_0: false, activeUnit_1.CommStuff.IsConnectedToSideNetwork, bool_2: false, bool_3: false, Contact_Base.IdentificationStatus.KnownType);
				scenario_0.AddMessage("New probable artillery contact! (Counter-battery detection). Designated " + contact_0.Name, "New artillery contact (" + contact_0.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, side_0, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				break;
			case SpecialDetectionMode.AutoDetection:
				break;
			}
			if (!Information.IsNothing(activeUnit_1) && activeUnit_1.CommStuff.IsConnectedToSideNetwork)
			{
				templateWrapper?.Invoke(side_0, contact_0.Type);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100259", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static string SelectConsumer(List<Sensor> list_0, object object_0, ScenarioObject scenarioObject_0)
	{
		if (list_0 != null)
		{
			Ship.ShipWakeSize shipWakeSize = Ship.ShipWakeSize.NoWake;
			ActiveUnit.AirContrailSize airContrailSize = ActiveUnit.AirContrailSize.NoContrail;
			foreach (Sensor item in list_0)
			{
				if (item.Type != Sensor.Sensor_Type.Visual)
				{
					continue;
				}
				if ((((ScenarioObject)object_0).IsShip || ((ScenarioObject)object_0).IsSubmarine) & (scenarioObject_0.IsAircraft || scenarioObject_0.IsMissile))
				{
					if (((ScenarioObject)object_0).IsShip)
					{
						shipWakeSize = ((Ship)object_0).WakeSize;
					}
					if (((ScenarioObject)object_0).IsSubmarine)
					{
						shipWakeSize = ((Submarine)object_0).WakeSize;
					}
					switch (shipWakeSize)
					{
					case Ship.ShipWakeSize.NoWake:
						return " - 未探测到尾流。";
					case Ship.ShipWakeSize.VSmall:
						return " - 探测到非常小的尾流。";
					case Ship.ShipWakeSize.Small:
						return " - 探测到小的尾流。";
					case Ship.ShipWakeSize.Medium:
						return " - 探测到中等尾流。";
					case Ship.ShipWakeSize.Large:
						return " - 探测到大的尾流。";
					case Ship.ShipWakeSize.VLarge:
						return " - 探测到非常大的尾流。";
					}
				}
				if (((ScenarioObject)object_0).IsAircraft || ((ScenarioObject)object_0).IsMissile)
				{
					if (((ScenarioObject)object_0).IsAircraft)
					{
						airContrailSize = ((ActiveUnit)object_0).FlushIssuer();
					}
					if (((ScenarioObject)object_0).IsMissile)
					{
						airContrailSize = ((ActiveUnit)object_0).FlushIssuer();
					}
					switch (airContrailSize)
					{
					case ActiveUnit.AirContrailSize.NoContrail:
						return " - 未探测到凝结尾流。";
					case ActiveUnit.AirContrailSize.VSmall:
						return " - 探测到非常小的凝结尾流。";
					case ActiveUnit.AirContrailSize.Small:
						return " - 探测到小的凝结尾流。";
					case ActiveUnit.AirContrailSize.Medium:
						return " - 探测到中度凝结尾流。";
					case ActiveUnit.AirContrailSize.Large:
						return " - 探测到大的凝结尾流。";
					case ActiveUnit.AirContrailSize.VLarge:
						return " - 探测到非常大的凝结尾流。";
					}
				}
			}
		}
		return "";
	}

	public static void ProcessNewBaseContact(Contact contact_0, ref Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0, ActiveUnit activeUnit_0 = null, Contact_Base.IdentificationStatus identificationStatus_0 = Contact_Base.IdentificationStatus.KnownDomain)
	{
		try
		{
			side_0.authenticationFacade++;
			contact_0 = new Contact((ActiveUnit)unit_0, side_0.authenticationFacade);
			contact_0.UncertaintyArea = null;
			contact_0.IsPreciselyLocatedOnThisPulse = true;
			contact_0.HeadingIsKnown = true;
			contact_0.SpeedIsKnown = true;
			contact_0.AltitudeIsKnown = true;
			contact_0.method_0(scenario_0, side_0, null, null, bool_0: false, activeUnit_0.CommStuff.IsConnectedToSideNetwork, bool_2: false, bool_3: true, identificationStatus_0);
			contact_0.OriginalDetectorSide = side_0;
			contact_0.Age = 0f;
			contact_0.UpdateCenter((ActiveUnit)unit_0);
			side_0.AddBaseContact(contact_0);
			if (unit_0.IsActiveUnit && ((ActiveUnit)unit_0).GetIsAutoDetectable(side_0) && contact_0.IDStatus == Contact_Base.IdentificationStatus.PreciseID)
			{
				contact_0.AddDetectionRecord((null, null, 0f, SpecialDetectionMode.AutoDetection, ((ActiveUnit)unit_0).ParentScen.Time));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100260", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsIlluminatingThisContact(Contact contact_0)
	{
		try
		{
			Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
			Sensor[] array = sensors_Cached;
			foreach (Sensor sensor in array)
			{
				if (sensor.IsActive && sensor.TargetsTrackedForFireControl_Readonly.Contains(contact_0))
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
			exception_?.Data.Add("Error at 100261", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool CanIlluminateThisContactForThisWeapon(Contact contact_0, Weapon weapon_0, ref Sensor sensor_0, ref bool? nullable_0, ref bool? nullable_1, ref Module_Unit.Unit.LOSCheckResult? nullable_2, ref bool? nullable_3)
	{
		if (weapon_0._FacadeReader)
		{
			return true;
		}
		try
		{
			if (strategyWrapper.IsMissile)
			{
				return false;
			}
			if (strategyWrapper.IsOperating())
			{
				List<ActiveUnit> list = null;
				Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
				Sensor[] array = sensors_Cached;
				foreach (Sensor sensor in array)
				{
					if (!sensor.CanIlluminateForThisWeapon(ref weapon_0))
					{
						continue;
					}
					if (!sensor.IsTrackingThisTargetForFireControl(ref contact_0))
					{
						if (sensor.Status == PlatformComponent._ComponentStatus.Operational)
						{
							if (!sensor.HasFireControlChannelAvailable())
							{
								continue;
							}
							if (contact_0 != null && contact_0.ActualUnit != null)
							{
								ActiveUnit actualUnit = contact_0.ActualUnit;
								if (actualUnit != null)
								{
									if (sensor.Type == Sensor.Sensor_Type.Radar)
									{
										if (list == null)
										{
											list = strategyWrapper.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
										}
										if (sensor.TargetsTrackedForFireControl_Readonly.Count > 0)
										{
											bool flag = false;
											List<Module_Unit.Unit> list2 = new List<Module_Unit.Unit>(sensor.TargetsTrackedForFireControl_Readonly);
											list2.Add(contact_0);
											int num = 0;
											do
											{
												if (!Sensor.CanTrackAllTargetsAtThisBoresightBearing(sensor, num, list2))
												{
													num++;
													continue;
												}
												flag = true;
												break;
											}
											while (num <= 359);
											if (!flag)
											{
												return false;
											}
										}
									}
									if (sensor.CanIlluminateTarget(strategyWrapper, actualUnit, Module_Unit.RangeToUnit_Slant(strategyWrapper, contact_0), list, strategyWrapper.IsShip, bool_1: false, ref nullable_0, ref nullable_1, ref nullable_2, ref nullable_3) == Sensor.SensorDetectionCheckResult.Success)
									{
										sensor_0 = sensor;
										return true;
									}
									continue;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100262", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool IlluminateThisContactForThisWeapon(Contact contact_0, Weapon weapon_0, ref bool? nullable_0, ref bool? nullable_1, ref Module_Unit.Unit.LOSCheckResult? nullable_2, ref bool? nullable_3)
	{
		try
		{
			Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
			int i = 0;
			List<ActiveUnit> list = null;
			for (; i < sensors_Cached.Length; i = checked(i + 1))
			{
				Sensor sensor = sensors_Cached[i];
				if (sensor.Status != 0 || (!sensor.HasFireControlChannelAvailable() && !sensor.IsTrackingThisTargetForFireControl(ref contact_0)) || !sensor.CanIlluminateForThisWeapon(ref weapon_0))
				{
					continue;
				}
				if (sensor.Type == Sensor.Sensor_Type.Radar && Information.IsNothing(list))
				{
					list = strategyWrapper.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
				}
				if (sensor.CanIlluminateTarget(strategyWrapper, contact_0.ActualUnit, Module_Unit.RangeToUnit_Slant(strategyWrapper, contact_0), list, strategyWrapper.IsShip, bool_1: false, ref nullable_0, ref nullable_1, ref nullable_2, ref nullable_3) == Sensor.SensorDetectionCheckResult.Success)
				{
					sensor.TrackTargetForFireControl(ref contact_0);
					if (!sensor.SemiActiveWeaponsGuided.Contains(weapon_0))
					{
						sensor.SemiActiveWeaponsGuided.Add(weapon_0);
						weapon_0.SensorProvidingFireControlForMe = sensor;
					}
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100263", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public Contact ResultOfDetectionAttempt(ActiveUnit activeUnit_0, Sensor[] sensor_0, float float_0, ref List<Sensor> list_0, List<ActiveUnit> list_1, ref bool? nullable_0, ref bool? nullable_1, ref Module_Unit.Unit.LOSCheckResult? nullable_2, ref bool? nullable_3, bool? nullable_4, bool? nullable_5, bool bool_0)
	{
		try
		{
			if (strategyWrapper.IsGuidedWeapon() && activeUnit_0.IsGuidedWeapon() && activeUnit_0.IsActiveUnit)
			{
				Contact_Base.ContactType primaryTarget_Type = activeUnit_0.AI.PrimaryTarget_Type;
				if (primaryTarget_Type == Contact_Base.ContactType.Air || primaryTarget_Type == Contact_Base.ContactType.Missile || primaryTarget_Type == Contact_Base.ContactType.Orbital)
				{
					return null;
				}
			}
			Sensor[] array = (bool_0 ? sensor_0.Where((Sensor theS) => theS.CanDetectEmissions).ToArray() : sensor_0);
			int num = array.Length - 1;
			Contact contact = null;
			for (int i = 0; i <= num; i++)
			{
				Sensor sensor = array[i];
				if (!sensor.IsOperating)
				{
					continue;
				}
				ActiveUnit activeUnit_ = activeUnit_0;
				if (sensor.IsTrackingThisUnitForFireControl(ref activeUnit_) && sensor.IsScanningOnThisPulse && sensor.CanPerformIllumination)
				{
					if (sensor.CanIlluminateTarget(strategyWrapper, activeUnit_0, float_0, list_1, strategyWrapper.IsShip, bool_1: false, ref nullable_0, ref nullable_1, ref nullable_2, ref nullable_3) == Sensor.SensorDetectionCheckResult.Success)
					{
						list_0.Add(sensor);
						if (contact == null)
						{
							contact = new Contact(activeUnit_0);
						}
					}
					else
					{
						Contact contact2 = (strategyWrapper.CommStuff.IsConnectedToSideNetwork ? strategyWrapper.GetUnitSide().Contacts[activeUnit_0.ObjectID] : _ContactsList_OffGrid[activeUnit_0.ObjectID]);
						if (contact2 != null)
						{
							sensor.StopTrackingTarget(contact2);
						}
					}
				}
				if (!sensor.IsScanningOnThisPulse || !sensor.CanPerformVolumeSearch || (sensor.Type == Sensor.Sensor_Type.Radar && !sensor.Codes.PESA && !sensor.Codes.AESA && !sensor.Codes.ICWI && sensor.TargetsTrackedForFireControl_Readonly.Count > 0))
				{
					continue;
				}
				List<Geopoint_Struct> list_2 = null;
				Lazy<Dictionary<int, EmissionContainer>> lazy_ = new Lazy<Dictionary<int, EmissionContainer>>();
				bool flag = false;
				try
				{
					if (activeUnit_0.IsActiveUnit)
					{
						flag = sensor.CanDetectTarget(Sensor.DetectionAttemptType.VolumeSearch, strategyWrapper, activeUnit_0, ref list_2, float_0, ref lazy_, list_1, ref nullable_0, ref nullable_1, ref nullable_2, ref nullable_3, ref nullable_4, ref nullable_5);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 100264", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return null;
				}
				if (!flag)
				{
					continue;
				}
				list_0.Add(sensor);
				if (contact == null)
				{
					contact = new Contact(activeUnit_0);
					if (list_2 != null)
					{
						contact.UncertaintyArea = list_2;
					}
				}
				else if (list_2 != null && contact.UncertaintyArea != null)
				{
					if (Zone.ComputeArea(contact.UncertaintyArea) > Zone.ComputeArea(list_2))
					{
						contact.UncertaintyArea = list_2;
					}
				}
				else if (contact.UncertaintyArea == null)
				{
					contact.UncertaintyArea = list_2;
				}
				if (DetectionIsPrecise(sensor, Module_Unit.RangeToUnit_Horiz(strategyWrapper, activeUnit_0)))
				{
					contact.IsPreciselyLocatedOnThisPulse = true;
					contact.SetLatitude(null, activeUnit_0.GetLatitude());
					contact.SetLongitude(null, activeUnit_0.GetLongitude());
					if (sensor.Capabilities.AltitudeInfo)
					{
						contact.SetCurrentAltitude(bool_0: false, activeUnit_0.GetCurrentAltitude());
						contact.AltitudeIsKnown = true;
					}
				}
				if (!lazy_.IsValueCreated)
				{
					continue;
				}
				try
				{
					foreach (int key in lazy_.Value.Keys)
					{
						if (contact.DetectedEmissions.ContainsKey(key))
						{
							contact.DetectedEmissions[key].Age = 0f;
							if (lazy_.Value[key].IsIllumination)
							{
								contact.DetectedEmissions[key].IsIllumination = true;
							}
							if (lazy_.Value[key].PreciseID)
							{
								contact.DetectedEmissions[key].PreciseID = true;
							}
						}
						else
						{
							contact.DetectedEmissions.Add(key, new EmissionContainer(0.0, lazy_.Value[key].IsIllumination, lazy_.Value[key].PreciseID));
						}
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 101169", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			return contact;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100264", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static bool DetectionIsPrecise(Sensor sensor_0, float float_0)
	{
		if (sensor_0.GetIsPrecise(float_0))
		{
			if (sensor_0.IsSonar && sensor_0.IsActive)
			{
				float num = (float)((double)SonarModel.smethod_0(sensor_0.ParentPlatform.GetLatitude(), sensor_0.ParentPlatform.GetLongitude(), sensor_0.ParentPlatform.GetUnitSide(), sensor_0.ParentPlatform.ParentScen) - 2.5);
				if (sensor_0.Role == Sensor.Sensor_Role.HullSonarPassiveOnlyVerticalRangingArray)
				{
					num = (float)((double)num * 0.8);
				}
				if (float_0 < num)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public void method_1(List<Sensor> list_0)
	{
		if (list_0 == null)
		{
			return;
		}
		try
		{
			foreach (Sensor item in new List<Sensor>(list_0))
			{
				if (item.Status == PlatformComponent._ComponentStatus.Operational)
				{
					if (item.TimeToNextScan != 0)
					{
						item.TimeToNextScan = Math.Max(0, item.TimeToNextScan - 1);
					}
					if (item.TimeToNextScan_Full != 0)
					{
						item.TimeToNextScan_Full = Math.Max(0, item.TimeToNextScan_Full - 1);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100265", "UpdateMCMCountdown");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateSensorsCountdown_PreDetection(Sensor[] sensor_0)
	{
		try
		{
			if (sensor_0 == null)
			{
				return;
			}
			foreach (Sensor item in new List<Sensor>(sensor_0))
			{
				if (item.Status == PlatformComponent._ComponentStatus.Operational)
				{
					item.TimeToNextScan--;
					item.TimeToNextScan_Full--;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100265", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateSensorsCountdown_PostDetection(Sensor[] sensor_0)
	{
		try
		{
			if (sensor_0 == null)
			{
				return;
			}
			if (predicateWrapper == null)
			{
				predicateWrapper = new List<Sensor>();
			}
			else
			{
				predicateWrapper.Clear();
			}
			predicateWrapper.AddRange(sensor_0);
			foreach (Sensor item in predicateWrapper)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Operational && item.IsScanningOnThisPulse)
				{
					if (!item.IsMineCountermeasure)
					{
						item.TimeToNextScan = item.ScanInterval;
					}
					if (item.IsScanningOnThisPulse_Full && item.ParentPlatform != null)
					{
						item.TimeToNextScan_Full = item.ParentPlatform.m_TokenVal;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100266", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public float TMASolution_ESM(Contact contact_0, float float_0)
	{
		try
		{
			int num = (int)Math.Round(contact_0.HeldFor);
			if (num == 0)
			{
				return 0f;
			}
			if (float_0 < 10f)
			{
				return (float)Math.Min((double)num / 600.0, 0.99);
			}
			if (float_0 < 25f)
			{
				return (float)Math.Min((double)num / 900.0, 0.99);
			}
			if (float_0 < 50f)
			{
				return (float)Math.Min((double)num / 1800.0, 0.99);
			}
			return (float)Math.Min((double)num / 3600.0, 0.99);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100268", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.99f;
		}
	}

	public float TMASolution_Sonar(Contact contact_0, float float_0)
	{
		try
		{
			if (Information.IsNothing(contact_0.UncertaintyArea))
			{
				return 1f;
			}
			int num = (int)Math.Round(contact_0.HeldFor);
			if (num == 0)
			{
				return 0f;
			}
			if (float_0 < 2.5f)
			{
				return (float)Math.Min((double)num / 600.0, 0.99);
			}
			if (float_0 < 5f)
			{
				return (float)Math.Min((double)num / 900.0, 0.99);
			}
			if (float_0 < 10f)
			{
				return (float)Math.Min((double)num / 1800.0, 0.99);
			}
			return (float)Math.Min((double)num / 3600.0, 0.99);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100269", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.99f;
		}
	}

	public List<Geopoint_Struct> GetUncertaintyArea(Sensor sensor_0, Module_Unit.Unit unit_0, float float_0, Dictionary<int, EmissionContainer> dictionary_0)
	{
		if (strategyWrapper == null)
		{
			return null;
		}
		if (strategyWrapper.GetUnitSide() == null)
		{
			return null;
		}
		float num = sensor_0.RangeResolution_Nominal;
		float num11 = sensor_0.AngleResolution;
		bool flag = false;
		double longitude = strategyWrapper.GetLongitude();
		double latitude = strategyWrapper.GetLatitude();
		try
		{
			if ((sensor_0.Type == Sensor.Sensor_Type.ESM) | (sensor_0.Type == Sensor.Sensor_Type.PCLS))
			{
				Contact contact = null;
				strategyWrapper.GetUnitSide().Contacts.TryGetValue(unit_0.ObjectID, ref contact);
				if (contact != null && sensor_0.Role != Sensor.Sensor_Role.ESM_RWR && float_0 <= 300f)
				{
					float num12 = TMASolution_ESM(contact, float_0);
					num = float_0 * (1f - num12);
					flag = true;
				}
			}
			else if (sensor_0.Type == Sensor.Sensor_Type.Visual)
			{
				float num13 = Module_Unit.RangeToUnit_Slant(sensor_0.ParentPlatform, unit_0);
				num11 = 0.1f;
				num = (float)((double)num13 * 0.1);
			}
			else if (sensor_0.Type == Sensor.Sensor_Type.Infrared)
			{
				float num14 = Module_Unit.RangeToUnit_Slant(sensor_0.ParentPlatform, unit_0);
				num11 = 0.1f;
				num = (sensor_0.Codes.Classification ? ((float)((double)num14 * 0.2)) : ((float)((double)num14 * 0.5)));
			}
			else if (!sensor_0.IsSonar && sensor_0.Type != Sensor.Sensor_Type.PingIntercept)
			{
				num = ((sensor_0.Type == Sensor.Sensor_Type.Radar) ? (float_0 / 20f) : (num * (float_0 / sensor_0.maxRange)));
			}
			else
			{
				float num15 = SonarModel.smethod_0(latitude, longitude, strategyWrapper.GetUnitSide(), strategyWrapper.ParentScen);
				float num16 = (float)((double)num15 - 2.5);
				if (!(float_0 < num16) && num15 != 0f)
				{
					num = 30f;
					num11 = 4f;
				}
				else
				{
					Contact contact2 = null;
					strategyWrapper.GetUnitSide().Contacts.TryGetValue(unit_0.ObjectID, ref contact2);
					if (contact2 != null && float_0 <= 20f)
					{
						float num17 = TMASolution_Sonar(contact2, float_0);
						num = float_0 * (1f - num17);
						flag = true;
					}
				}
			}
			float num18 = Math2.PublishClass(latitude, longitude, unit_0.GetLatitude(), unit_0.GetLongitude());
			LockRandom lockRandom_ = GameGeneral.LockRandom_0;
			float num2 = (float)Math2.DisableClass((double)num18 + (double)num11 * ((double)lockRandom_.Next(-90, 91) / 100.0));
			float num3 = (float)Math.Max(0.0, (double)float_0 + (double)num * ((double)lockRandom_.Next(-90, 91) / 100.0));
			List<Geopoint_Struct> list = new List<Geopoint_Struct>(6);
			float float_2;
			float float_;
			if (sensor_0.Type == Sensor.Sensor_Type.ESM)
			{
				if (flag)
				{
					float_ = Math.Max(num3 - num, 0f);
					float_2 = num3 + num;
				}
				else
				{
					Horizon.CollectInvocation(strategyWrapper, unit_0, sensor_0);
					if (strategyWrapper.GetCurrentAltitude() <= 100000f)
					{
						float_ = Math.Max(num3 - sensor_0.maxRange / 3f, 0f);
						float_2 = num3 + sensor_0.maxRange / 3f;
					}
					else
					{
						float num4 = Horizon.CustomizeClass(Math.Min(strategyWrapper.GetCurrentAltitude(), 100000f), unit_0.GetCurrentAltitude());
						float num5 = Math.Min(3441.6865f, Horizon.ManageInvocation(strategyWrapper.GetCurrentAltitude(), unit_0.GetCurrentAltitude())) + num4;
						if (!float.IsInfinity(num5) && !float.IsNaN(num5))
						{
							float_2 = Math.Min(num5, num3 + sensor_0.maxRange / 3f);
						}
						else
						{
							float_2 = num3 + sensor_0.maxRange / 3f;
							float_ = Math.Max(num3 - sensor_0.maxRange / 3f, 0f);
						}
						float num6 = Math.Min(sensor_0.maxRange / 3f, num5);
						float_ = Math.Max(num3 - num6, 0f);
					}
				}
			}
			else if (sensor_0.Type == Sensor.Sensor_Type.PCLS)
			{
				if (flag)
				{
					float_ = Math.Max(num3 - num, 0f);
					float_2 = num3 + num;
				}
				else
				{
					float_ = Math.Max(num3 - sensor_0.maxRange / 3f, 0f);
					float num7 = Horizon.CollectInvocation(strategyWrapper, unit_0, sensor_0);
					float_2 = ((float.IsInfinity(num7) || float.IsNaN(num7)) ? (num3 + sensor_0.maxRange / 3f) : Math.Min(num7, num3 + sensor_0.maxRange / 3f));
				}
			}
			else if (sensor_0.IsSonar)
			{
				float num8 = SonarModel.smethod_0(latitude, longitude, strategyWrapper.GetUnitSide(), strategyWrapper.ParentScen);
				float num9 = (float)((double)num8 - 2.5);
				if (!(float_0 < num9) && num8 != 0f)
				{
					float_ = num9;
					float_2 = sensor_0.maxRange;
				}
				else if (flag)
				{
					float_ = Math.Max(num3 - num, 0f);
					float_2 = num3 + num;
				}
				else
				{
					float_ = 1E-05f;
					if (num8 <= 0f)
					{
						float num10 = SonarModel.SonarPropagationModifier(sensor_0.UsesDeepSoundChannel(), strategyWrapper, (ActiveUnit)unit_0);
						float_2 = (float)(9.87473 * (double)num10);
					}
					else
					{
						float_2 = num9;
					}
				}
			}
			else if (sensor_0.Type == Sensor.Sensor_Type.MAD)
			{
				float_ = 0.001f;
				float_2 = sensor_0.maxRange;
			}
			else
			{
				float_ = Math.Max(num3 - num, 0f);
				float_2 = num3 + num;
			}
			float float_3 = Math2.UpdateClass(num2 - num11);
			float float_4 = Math2.UpdateClass(num2 + num11);
			float float_5 = Math2.UpdateClass(num2);
			Geopoint_Struct item = default(Geopoint_Struct);
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref item.Longitude, ref item.Latitude, float_, float_3);
			list.Add(item);
			item = default(Geopoint_Struct);
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref item.Longitude, ref item.Latitude, float_, float_5);
			list.Add(item);
			item = default(Geopoint_Struct);
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref item.Longitude, ref item.Latitude, float_, float_4);
			list.Add(item);
			item = default(Geopoint_Struct);
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref item.Longitude, ref item.Latitude, float_2, float_4);
			list.Add(item);
			item = default(Geopoint_Struct);
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref item.Longitude, ref item.Latitude, float_2, float_5);
			list.Add(item);
			item = default(Geopoint_Struct);
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref item.Longitude, ref item.Latitude, float_2, float_3);
			list.Add(item);
			foreach (Geopoint_Struct item2 in list)
			{
				Geopoint_Struct current = item2;
				if (current.Latitude > 90.0)
				{
					current.Latitude = 90.0;
				}
				if (current.Latitude < -90.0)
				{
					current.Latitude = -90.0;
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200585", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static List<Geopoint_Struct> GetRefinedUncertaintyArea_Clipper(List<Geopoint_Struct> list_0, List<Geopoint_Struct> list_1)
	{
		try
		{
			if (list_0 == null)
			{
				return list_1;
			}
			if (list_0.Count > 100)
			{
				list_0 = Math2.SimplifyArea(list_0);
			}
			if (list_1 == null)
			{
				return list_0;
			}
			if (list_1.Count > 100)
			{
				list_1 = Math2.SimplifyArea(list_1);
			}
			List<Vector3D> list = new List<Vector3D>(list_0.Count);
			List<Vector3D> list2 = new List<Vector3D>(list_1.Count);
			foreach (Geopoint_Struct item10 in list_0)
			{
				Vector3D item = MathFunctions.Geopoint_Struct_To_UnitVector(item10);
				list.Add(item);
			}
			foreach (Geopoint_Struct item11 in list_1)
			{
				Vector3D item6 = MathFunctions.Geopoint_Struct_To_UnitVector(item11);
				list2.Add(item6);
			}
			Vector3D val = default(Vector3D);
			foreach (Vector3D item12 in list2)
			{
				val += item12;
			}
			foreach (Vector3D item13 in list)
			{
				val += item13;
			}
			val /= (double)(list2.Count + list.Count);
			Vector3D vector3D = val;
			Vector3D vector3D2 = val;
			val = vector3D / vector3D2.Length;
			Matrix<double> val2 = Matrix3D.RotationTo(val, new Vector3D(1.0, 0.0, 0.0));
			Matrix<double> val3 = val2.Inverse();
			int num = list2.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int index = i;
				Vector3D val4 = list2[i];
				vector3D2 = val4;
				list2[index] = vector3D2.TransformBy(val2);
			}
			int num2 = list.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				int index2 = j;
				Vector3D val4 = list[j];
				vector3D2 = val4;
				list[index2] = vector3D2.TransformBy(val2);
			}
			List<Geopoint_Struct> list_2 = new List<Geopoint_Struct>(list.Count);
			List<Geopoint_Struct> list_3 = new List<Geopoint_Struct>(list2.Count);
			foreach (Vector3D item2 in list)
			{
				Geopoint_Struct item7 = MathFunctions.Vector_To_Geopoint_Struct(item2);
				list_2.Add(item7);
			}
			foreach (Vector3D item3 in list2)
			{
				Geopoint_Struct item8 = MathFunctions.Vector_To_Geopoint_Struct(item3);
				list_3.Add(item8);
			}
			List<Geopoint_Struct> list3 = Math2.RateClass(ref list_2, ref list_3);
			if (list3.Count == 0)
			{
				return list_1;
			}
			List<Vector3D> list4 = new List<Vector3D>(list3.Count);
			foreach (Geopoint_Struct item4 in list3)
			{
				Vector3D item9 = MathFunctions.Geopoint_Struct_To_UnitVector(item4);
				list4.Add(item9);
			}
			int num3 = list4.Count - 1;
			for (int k = 0; k <= num3; k++)
			{
				int index3 = k;
				Vector3D val4 = list4[k];
				vector3D2 = val4;
				list4[index3] = vector3D2.TransformBy(val3);
			}
			List<Geopoint_Struct> list5 = new List<Geopoint_Struct>(list4.Count);
			foreach (Vector3D item5 in list4)
			{
				list5.Add(MathFunctions.Vector_To_Geopoint_Struct(item5));
			}
			if (list5.Count > 100)
			{
				list5 = Math2.SimplifyArea(list5);
			}
			return list5;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200586", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Geopoint_Struct> result = list_1;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static List<GeoPoint> GetRefinedUncertaintyArea_DotSpatial(List<GeoPoint> list_0, List<GeoPoint> list_1)
	{
		Coordinate[] array = new Coordinate[list_0.Count + 1];
		try
		{
			int num = list_0.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = new Coordinate(list_0[i].Longitude, list_0[i].Latitude, 0.0);
			}
			array[list_0.Count] = array[0];
			Polygon polygon = new Polygon(new LinearRing(array));
			Coordinate[] array2 = new Coordinate[list_1.Count + 1];
			int num2 = list_1.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				array2[j] = new Coordinate(list_1[j].Longitude, list_1[j].Latitude, 0.0);
			}
			array2[list_1.Count] = array2[0];
			Polygon igeometry_ = new Polygon(new LinearRing(array2));
			try
			{
				Geometry geometry = (Geometry)polygon.Intersection(igeometry_);
				if (geometry.Coordinates.Count <= 0)
				{
					return list_1;
				}
				List<GeoPoint> list = new List<GeoPoint>();
				int num3 = geometry.Coordinates.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					Coordinate coordinate = geometry.Coordinates[k];
					list.Add(new GeoPoint(coordinate.X, coordinate.Y));
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200017", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return list_1;
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 200587", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list_1;
		}
	}

	internal List<Sensor> CallConsumer(Contact contact_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0)
	{
		List<Sensor> result = new List<Sensor>();
		if (contact_0 != null)
		{
			switch (contact_0.Type)
			{
			case Contact_Base.ContactType.Mine:
				result = NewConsumer(ref sensor_0);
				break;
			case Contact_Base.ContactType.Air:
			case Contact_Base.ContactType.Missile:
			case Contact_Base.ContactType.Orbital:
			case Contact_Base.ContactType.Decoy_Air:
				result = ViewConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.Decoy_Surface:
				result = LoginConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.Decoy_Land:
				result = GetConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
				break;
			case Contact_Base.ContactType.Submarine:
			case Contact_Base.ContactType.Torpedo:
			case Contact_Base.ContactType.Decoy_Sub:
				result = WriteConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
				break;
			}
		}
		return result;
	}

	internal (float MaxAirSpace, float MaxSurface, float MaxSubsurface, float MaxLand) LogoutConsumer(bool bool_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
		Sensor[] array = sensors_Cached;
		foreach (Sensor sensor in array)
		{
			if (sensor.IsOperating && (!bool_0 || sensor.IsScanningOnThisPulse))
			{
				if (sensor.Capabilities.AirSearch || sensor.Capabilities.SpaceSearch_ABM || sensor.Capabilities.C_RAM)
				{
					num = Math.Max(num, sensor.maxRange);
				}
				if (sensor.Capabilities.SurfaceSearch || sensor.Type == Sensor.Sensor_Type.PingIntercept)
				{
					num2 = Math.Max(num2, sensor.maxRange);
				}
				if (sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Capabilities.SubSearch)
				{
					num3 = Math.Max(num3, sensor.maxRange);
				}
				if (sensor.Type == Sensor.Sensor_Type.ESM || sensor.Capabilities.LandSearch_Fixed || sensor.Capabilities.LandSearch_Mobile)
				{
					num4 = Math.Max(num4, sensor.maxRange);
				}
			}
		}
		return (MaxAirSpace: num, MaxSurface: num2, MaxSubsurface: num3, MaxLand: num4);
	}

	internal List<Sensor> ViewConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0)
	{
		List<Sensor> list = new List<Sensor>();
		List<Sensor> list2 = new List<Sensor>();
		new List<Sensor>();
		try
		{
			List<Sensor> list3 = PushConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
			float num = 0f;
			int num2 = 0;
			foreach (Sensor item in list3)
			{
				if (item.maxRange < num)
				{
					if (item.maxRange == num)
					{
						list2.Add(item);
						num2++;
					}
				}
				else
				{
					list2.Add(item);
					num = item.maxRange;
					num2 = 1;
				}
			}
			if (list2.Count == 0)
			{
				return list;
			}
			foreach (Sensor item2 in list2)
			{
				if (item2.maxRange != num)
				{
					continue;
				}
				if (num2 == 1)
				{
					list.Add(item2);
					continue;
				}
				if (!item2.Coverage.Has360Coverage())
				{
					num2--;
					continue;
				}
				list.Add(item2);
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100273", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> ValidateConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0)
	{
		List<Sensor> list = new List<Sensor>();
		List<Sensor> list2 = new List<Sensor>();
		List<Sensor> list3 = new List<Sensor>();
		List<Sensor> list4 = new List<Sensor>();
		try
		{
			list4 = InvokeConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
			if (Information.IsNothing(list4))
			{
				return new List<Sensor>();
			}
			float num = 0f;
			int num2 = 0;
			float num3 = 0f;
			int num4 = 0;
			foreach (Sensor item in list4)
			{
				if (!(item.maxRange < num) && !item.Capabilities.OTH_SurfaceWave)
				{
					if (item.maxRange < num)
					{
						if (item.maxRange == num)
						{
							list2.Add(item);
							num2++;
						}
					}
					else
					{
						list2.Add(item);
						num = item.maxRange;
						num2 = 1;
					}
				}
				else
				{
					if (!(item.maxRange >= num3) || !item.Capabilities.OTH_SurfaceWave)
					{
						continue;
					}
					if (item.maxRange < num)
					{
						if (item.maxRange == num)
						{
							list3.Add(item);
							num4++;
						}
					}
					else
					{
						list3.Add(item);
						num3 = item.maxRange;
						num4 = 1;
					}
				}
			}
			if (list2.Count == 0 && list3.Count == 0)
			{
				return list;
			}
			if (list3.Count == 0)
			{
				foreach (Sensor item2 in list2)
				{
					if (item2.maxRange != num)
					{
						continue;
					}
					if (num2 == 1)
					{
						list.Add(item2);
						continue;
					}
					if (!item2.Coverage.Has360Coverage())
					{
						num2--;
						continue;
					}
					list.Add(item2);
					return list;
				}
			}
			else
			{
				foreach (Sensor item3 in list3)
				{
					if (item3.maxRange != num3)
					{
						continue;
					}
					if (num4 == 1)
					{
						list.Add(item3);
						continue;
					}
					if (!item3.Coverage.Has360Coverage())
					{
						num4--;
						continue;
					}
					list.Add(item3);
					return list;
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100274", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> LoginConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0)
	{
		List<Sensor> list = new List<Sensor>();
		List<Sensor> list2 = new List<Sensor>();
		try
		{
			List<Sensor> list3 = SetupConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
			float num = 0f;
			int num2 = 0;
			foreach (Sensor item in list3)
			{
				if (item.maxRange < num)
				{
					if (item.maxRange == num)
					{
						list2.Add(item);
						num2++;
					}
				}
				else
				{
					list2.Add(item);
					num = item.maxRange;
					num2 = 1;
				}
			}
			if (list2.Count == 0)
			{
				return list;
			}
			foreach (Sensor item2 in list2)
			{
				if (item2.maxRange != num)
				{
					continue;
				}
				if (num2 == 1)
				{
					list.Add(item2);
					continue;
				}
				if (!item2.Coverage.Has360Coverage())
				{
					num2--;
					continue;
				}
				list.Add(item2);
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100275", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> GetConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0)
	{
		List<Sensor> list = new List<Sensor>();
		List<Sensor> list2 = new List<Sensor>();
		try
		{
			List<Sensor> list3 = ExcludeConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0);
			float num = 0f;
			int num2 = 0;
			foreach (Sensor item in list3)
			{
				if (item.maxRange < num)
				{
					if (item.maxRange == num)
					{
						list2.Add(item);
						num2++;
					}
				}
				else
				{
					list2.Add(item);
					num = item.maxRange;
					num2 = 1;
				}
			}
			if (list2.Count == 0)
			{
				return list;
			}
			foreach (Sensor item2 in list2)
			{
				if (item2.maxRange != num)
				{
					continue;
				}
				if (num2 == 1)
				{
					list.Add(item2);
					continue;
				}
				if (!item2.Coverage.Has360Coverage())
				{
					num2--;
					continue;
				}
				list.Add(item2);
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100276", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> WriteConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0, bool bool_4 = false)
	{
		List<Sensor> list = new List<Sensor>();
		List<Sensor> list2 = new List<Sensor>();
		new List<Sensor>();
		try
		{
			List<Sensor> list3 = IncludeConsumer(bool_0, bool_1, bool_2, bool_3, ref sensor_0, bool_4);
			float num = 0f;
			int num2 = 0;
			foreach (Sensor item in list3)
			{
				if (item.maxRange <= num)
				{
					if (item.maxRange == num)
					{
						list2.Add(item);
						num2++;
					}
				}
				else
				{
					list2.Add(item);
					num = item.maxRange;
					num2 = 1;
				}
			}
			if (list2.Count == 0)
			{
				return list;
			}
			foreach (Sensor item2 in list2)
			{
				if (item2.maxRange != num)
				{
					continue;
				}
				if (num2 == 1)
				{
					list.Add(item2);
					continue;
				}
				if (!item2.Coverage.Has360Coverage())
				{
					num2--;
					continue;
				}
				list.Add(item2);
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100277", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> NewConsumer(ref Sensor[] sensor_0)
	{
		List<Sensor> list = new List<Sensor>();
		List<Sensor> list2 = new List<Sensor>();
		try
		{
			Sensor[] obj = sensor_0;
			float num = 0f;
			int num2 = 0;
			Sensor[] array = obj;
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				if (sensor.maxRange < num)
				{
					if (sensor.maxRange == num)
					{
						list2.Add(sensor);
						num2++;
					}
				}
				else
				{
					list2.Add(sensor);
					num = sensor.maxRange;
					num2 = 1;
				}
			}
			if (list2.Count == 0)
			{
				return list;
			}
			foreach (Sensor item in list2)
			{
				if (item.maxRange != num)
				{
					continue;
				}
				if (num2 == 1)
				{
					list.Add(item);
					continue;
				}
				if (!item.Coverage.Has360Coverage())
				{
					num2--;
					continue;
				}
				list.Add(item);
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101273", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> PushConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0, bool bool_4 = false)
	{
		try
		{
			List<Sensor> list = new List<Sensor>();
			Sensor[] array = ((sensor_0 == null) ? GetSensors_AirSearch.ToArray() : sensor_0);
			if (array == null)
			{
				return list;
			}
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				Sensor sensor = array[i];
				if ((bool_0 && !sensor.CanBeActive) || (bool_1 && !sensor.IsActive) || (bool_3 && !sensor.IsScanningOnThisPulse) || (!sensor.CanPerformVolumeSearch && sensor.TargetsTrackedForFireControl_Readonly.Count == 0) || (bool_2 && !sensor.IsOperating))
				{
					continue;
				}
				if (strategyWrapper.IsWeapon)
				{
					if (!sensor.GetIsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Aircraft, (Weapon)strategyWrapper) && !sensor.GetIsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Weapon, (Weapon)strategyWrapper))
					{
						continue;
					}
				}
				else if (!sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) && !sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Weapon) && !sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite))
				{
					continue;
				}
				list.Add(sensor);
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100278", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> InvokeConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0, bool bool_4 = false)
	{
		Sensor[] array = ((sensor_0 == null) ? strategyWrapper.Sensors_Cached : sensor_0);
		if (array == null)
		{
			return new List<Sensor>();
		}
		List<Sensor> list = new List<Sensor>();
		int num = array.Length;
		try
		{
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				Sensor sensor = array[i];
				if ((!bool_0 || sensor.CanBeActive) && (!bool_1 || sensor.IsActive) && (!bool_3 || sensor.IsScanningOnThisPulse) && sensor.CanPerformVolumeSearch && (!bool_2 || sensor.IsOperating) && (sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship) || sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility)))
				{
					list.Add(sensor);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100279", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> SetupConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0, bool bool_4 = false)
	{
		Sensor[] array = ((sensor_0 == null) ? strategyWrapper.Sensors_Cached : sensor_0);
		List<Sensor> list = new List<Sensor>();
		if (array == null)
		{
			return list;
		}
		int num = array.Length;
		try
		{
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				Sensor sensor = array[i];
				if ((bool_0 && !sensor.CanBeActive) || (bool_1 && !sensor.IsActive) || (bool_3 && !sensor.IsScanningOnThisPulse) || !sensor.CanPerformVolumeSearch || (bool_2 && !sensor.IsOperating))
				{
					continue;
				}
				if (strategyWrapper.IsWeapon)
				{
					if (!sensor.GetIsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Ship, (Weapon)strategyWrapper))
					{
						continue;
					}
				}
				else if (!sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship))
				{
					continue;
				}
				list.Add(sensor);
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100280", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Sensor> result = new List<Sensor>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Sensor> ExcludeConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0, bool bool_4 = false)
	{
		Sensor[] array = ((sensor_0 == null) ? strategyWrapper.Sensors_Cached : sensor_0);
		List<Sensor> list = new List<Sensor>();
		if (array == null)
		{
			return list;
		}
		int num = array.Length;
		try
		{
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				Sensor sensor = array[i];
				if ((bool_0 && !sensor.CanBeActive) || (bool_1 && !sensor.IsActive) || (bool_3 && !sensor.IsScanningOnThisPulse) || !sensor.CanPerformVolumeSearch || (bool_2 && !sensor.IsOperating))
				{
					continue;
				}
				if (strategyWrapper.IsWeapon)
				{
					if (!sensor.GetIsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Facility, (Weapon)strategyWrapper))
					{
						continue;
					}
				}
				else if (!sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility))
				{
					continue;
				}
				list.Add(sensor);
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100281", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	internal List<Sensor> IncludeConsumer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref Sensor[] sensor_0, bool bool_4 = false)
	{
		List<Sensor> list = new List<Sensor>();
		Sensor[] array = ((sensor_0 == null) ? strategyWrapper.Sensors_Cached : sensor_0);
		if (array == null)
		{
			return list;
		}
		int num = array.Length;
		try
		{
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				Sensor sensor = array[i];
				if ((bool_4 && !sensor.IsSonar) || (bool_0 && !sensor.CanBeActive) || (bool_1 && !sensor.IsActive) || (bool_3 && !sensor.IsScanningOnThisPulse) || !sensor.CanPerformVolumeSearch || (bool_2 && !sensor.IsOperating))
				{
					continue;
				}
				if (strategyWrapper.IsWeapon)
				{
					if (((Weapon)strategyWrapper).Type != Weapon._WeaponType.Sonobuoy && !sensor.GetIsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Submarine, (Weapon)strategyWrapper) && (!sensor.GetIsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Ship, (Weapon)strategyWrapper) || !strategyWrapper.IsTorpedo))
					{
						continue;
					}
				}
				else if (!sensor.GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine))
				{
					continue;
				}
				list.Add(sensor);
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100282", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	public void CheckMountDirectors()
	{
		try
		{
			bool flag = false;
			Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
			Sensor[] array = sensors_Cached;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				if (array[i].TargetsTrackedForFireControl_Readonly.Contains(strategyWrapper.AI.PrimaryTarget))
				{
					flag = true;
					break;
				}
			}
			Sensor[] array2 = sensors_Cached;
			Sensor[] array3 = array2;
			foreach (Sensor sensor in array3)
			{
				if (sensor.TargetsTrackedForFireControl_Readonly.Count <= 0)
				{
					continue;
				}
				if (sensor.SemiActiveWeaponsGuided.Count == 0)
				{
					List<Contact> list = new List<Contact>();
					foreach (Contact item in sensor.TargetsTrackedForFireControl_Readonly)
					{
						if (item == null || item.GetIsOutOfUnguidedWeaponsRange(strategyWrapper))
						{
							list.Add(item);
						}
					}
					if (!flag && !sensor.HasFireControlChannelAvailable())
					{
						list.Add(sensor.TargetsTrackedForFireControl_Readonly[0]);
					}
					foreach (Contact item2 in list)
					{
						sensor.StopTrackingTarget(item2);
					}
					continue;
				}
				List<Contact> list2 = new List<Contact>();
				foreach (Contact item3 in sensor.TargetsTrackedForFireControl_Readonly)
				{
					if (Information.IsNothing(item3))
					{
						list2.Add(item3);
					}
					else if (item3.GetIsDestroyed(strategyWrapper.ParentScen))
					{
						list2.Add(item3);
					}
				}
				foreach (Contact item4 in list2)
				{
					sensor.StopTrackingTarget(item4);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100283", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateContactData_Local(ref string string_0, List<Sensor> list_0)
	{
		if (!_ContactsList_Local.ContainsKey(string_0))
		{
			return;
		}
		ContactEntry_Local contactEntry_Local = _ContactsList_Local[string_0];
		contactEntry_Local.NoDetectionCount = 0f;
		foreach (Sensor item in list_0)
		{
			switch (item.Type)
			{
			case Sensor.Sensor_Type.ESM:
				contactEntry_Local.TimeSinceDetection_ESM = 0f;
				break;
			case Sensor.Sensor_Type.Radar:
				contactEntry_Local.TimeSinceDetection_Radar = 0f;
				break;
			case Sensor.Sensor_Type.Visual:
				contactEntry_Local.TimeSinceDetection_Visual = 0f;
				break;
			case Sensor.Sensor_Type.Infrared:
				contactEntry_Local.TimeSinceDetection_Infrared = 0f;
				break;
			case Sensor.Sensor_Type.PingIntercept:
				contactEntry_Local.TimeSinceDetection_SonarPassive = 0f;
				break;
			case Sensor.Sensor_Type.HullSonar_PassiveOnly:
			case Sensor.Sensor_Type.HullSonar_ActivePassive:
			case Sensor.Sensor_Type.HullSonar_ActiveOnly:
			case Sensor.Sensor_Type.TowedArray_PassiveOnly:
			case Sensor.Sensor_Type.TowedArray_ActivePassive:
			case Sensor.Sensor_Type.TowedArray_ActiveOnly:
			case Sensor.Sensor_Type.VDS_PassiveOnly:
			case Sensor.Sensor_Type.VDS_ActivePassive:
			case Sensor.Sensor_Type.VDS_ActiveOnly:
			case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
			case Sensor.Sensor_Type.DippingSonar_ActivePassive:
			case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
			case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
				if (item.HasActiveModeOnly)
				{
					contactEntry_Local.TimeSinceDetection_SonarActive = 0f;
				}
				else if (item.IsActive)
				{
					contactEntry_Local.TimeSinceDetection_SonarActive = 0f;
				}
				else
				{
					contactEntry_Local.TimeSinceDetection_SonarPassive = 0f;
				}
				break;
			}
		}
	}

	internal float? SearchConsumer(ref Contact contact_0)
	{
		float? result = null;
		if (Information.IsNothing(contact_0.ActualUnit))
		{
			result = null;
		}
		else if (_ContactsList_Local.ContainsKey(contact_0.ActualUnit.ObjectID))
		{
			result = _ContactsList_Local[contact_0.ActualUnit.ObjectID].TimeSinceDetection;
		}
		return result;
	}

	private void EnableConsumer(object sender, NotifyDictionaryChangedEventArgs<string, ContactEntry_Local> e)
	{
		creatorWrapper = null;
	}

	public void RemoveContact_Local(ref string string_0)
	{
		if (_ContactsList_Local.ContainsKey(string_0))
		{
			_ContactsList_Local.Remove(string_0);
		}
	}

	public void ProcessContactListChanges_Local()
	{
		try
		{
			if (NewContactsQueue_Local.Count > 0)
			{
				foreach (string key in NewContactsQueue_Local.Keys)
				{
					if (!_ContactsList_Local.ContainsKey(key))
					{
						ContactEntry_Local contactEntry_Local = new ContactEntry_Local();
						contactEntry_Local.Contact = NewContactsQueue_Local[key];
						_ContactsList_Local.Add(key, contactEntry_Local);
					}
				}
				NewContactsQueue_Local.Clear();
			}
			if (DroppedContactsQueue_Local.Count <= 0)
			{
				return;
			}
			foreach (string key2 in DroppedContactsQueue_Local.Keys)
			{
				_ContactsList_Local.Remove(key2);
			}
			DroppedContactsQueue_Local.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101220", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AgeLocalAndPrivateContacts(float float_0)
	{
		try
		{
			if (_ContactsList_Local.Count > 0)
			{
				foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
				{
					ContactEntry_Local value = item.Value;
					value.TimeSinceDetection = item.Value.TimeSinceDetection + float_0;
					if (value.TimeSinceDetection > (float)strategyWrapper._IndexerVal)
					{
						if (strategyWrapper._IndexerVal > 0 && strategyWrapper.GetUnitSide().WeaponSalvosForThisTarget(value.Contact).Count > 0)
						{
							value.NoDetectionCount = 0f;
						}
						else if (value.NoDetectionCount <= 300f)
						{
							float num = 1f;
							if (strategyWrapper.ParentScen.UsesHighFidelity())
							{
								num = 10f;
							}
							value.NoDetectionCount += 1f / num;
						}
						else
						{
							DroppedContactsQueue_Local.AddIfNotExistsElseUpdate(item.Key, value.Contact);
						}
					}
					if (value.TimeSinceDetection_Radar.HasValue)
					{
						value.TimeSinceDetection_Radar = Misc.SetupRequest(value.TimeSinceDetection_Radar.Value, float_0, 1);
					}
					if (value.TimeSinceDetection_ESM.HasValue)
					{
						value.TimeSinceDetection_ESM = Misc.SetupRequest(value.TimeSinceDetection_ESM.Value, float_0, 1);
					}
					if (value.TimeSinceDetection_Visual.HasValue)
					{
						value.TimeSinceDetection_Visual = Misc.SetupRequest(value.TimeSinceDetection_Visual.Value, float_0, 1);
					}
					if (value.TimeSinceDetection_Infrared.HasValue)
					{
						value.TimeSinceDetection_Infrared = Misc.SetupRequest(value.TimeSinceDetection_Infrared.Value, float_0, 1);
					}
					if (value.TimeSinceDetection_SonarActive.HasValue)
					{
						value.TimeSinceDetection_SonarActive = Misc.SetupRequest(value.TimeSinceDetection_SonarActive.Value, float_0, 1);
					}
					if (value.TimeSinceDetection_SonarPassive.HasValue)
					{
						value.TimeSinceDetection_SonarPassive = Misc.SetupRequest(value.TimeSinceDetection_SonarPassive.Value, float_0, 1);
					}
				}
			}
			if (!strategyWrapper.ParentScen.SecondIsChangingOnThisPulse || _ContactsList_OffGrid.Count <= 0)
			{
				return;
			}
			foreach (Contact value2 in _ContactsList_OffGrid.Values)
			{
				Contact.IncreaseAge(value2, strategyWrapper.GetUnitSide(), 1f, strategyWrapper.ParentScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101223", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Housekeeping_PrePulse(float float_0)
	{
		if (_SchemaWrapper.Count > 0)
		{
			_SchemaWrapper.Clear();
		}
		Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
		if (sensors_Cached != null && sensors_Cached.Length != 0)
		{
			try
			{
				if (predicateWrapper == null)
				{
					predicateWrapper = new List<Sensor>();
				}
				else
				{
					predicateWrapper.Clear();
				}
				predicateWrapper.AddRange(strategyWrapper.Sensors_Cached);
				foreach (Sensor item in predicateWrapper)
				{
					if (item.PostWriter())
					{
						item.ReCalculateResolutionCell();
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		if (strategyWrapper.CommStuff.IsConnectedToSideNetwork)
		{
			return;
		}
		List<Contact> list = PrivateContactList();
		for (int i = list.Count - 1; i >= 0; i += -1)
		{
			Contact contact;
			try
			{
				contact = list[i];
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
				continue;
			}
			contact?.PrePulseHousekeeping(float_0, strategyWrapper.ParentScen);
		}
	}

	public void Housekeeping_PostPulse(float float_0)
	{
		if (_SchemaWrapper.Count > 0)
		{
			_SchemaWrapper.Clear();
		}
		if (!strategyWrapper.CommStuff.IsConnectedToSideNetwork)
		{
			List<Contact> list = new List<Contact>(PrivateContactList());
			if (list.Count > 0)
			{
				Parallel.ForEach(list, delegate(Contact theC)
				{
					theC?.PostPulseHousekeeping(float_0, strategyWrapper.GetUnitSide(), strategyWrapper.ParentScen, bool_0: true);
				});
			}
			ChangeConsumer();
		}
		Sensor[] sensors_Cached = strategyWrapper.Sensors_Cached;
		for (int i = 0; i < sensors_Cached.Length; i = checked(i + 1))
		{
			sensors_Cached[i]?.DetectionChecksThisPulse?.Clear();
		}
	}

	private void ChangeConsumer()
	{
		try
		{
			if (_ContactsList_OffGrid.Count <= 0)
			{
				return;
			}
			Contact[] array = _ContactsList_OffGrid.Values.ToArray();
			Contact[] array3 = array;
			foreach (Contact contact in array3)
			{
				if (contact != null && !contact.IsDueToExpire && !contact.GetIsDestroyed(strategyWrapper.ParentScen))
				{
					continue;
				}
				strategyWrapper.ParentScen.AddMessage(strategyWrapper.Name + "：本地目标" + contact.Name + "已经丢失。", contact.Name + " 已消失", LoggedMessage.MessageType.CommsIsolatedMessage, 5, null, strategyWrapper.GetUnitSide(), new Geopoint_Struct(contact.GetLongitude(), contact.GetLatitude()));
				try
				{
					_ContactsList_OffGrid.Remove(contact.ActualUnit.ObjectID);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					KeyValuePair<string, Contact>[] array2 = _ContactsList_OffGrid.ToArray();
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						KeyValuePair<string, Contact> keyValuePair = array2[i];
						if (keyValuePair.Value == contact)
						{
							_ContactsList_OffGrid.Remove(keyValuePair.Key);
							break;
						}
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300011", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PostDeserializationHousekeeping_LocalAndPrivateContacts(ref ActiveUnit activeUnit_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
		{
			if (activeUnit_0.GetUnitSide().Contacts.ContainsKey(item.Key))
			{
				item.Value.Contact = activeUnit_0.GetUnitSide().Contacts[item.Key];
			}
		}
		foreach (Contact value in _ContactsList_OffGrid.Values)
		{
			ref Scenario parentScen = ref strategyWrapper.ParentScen;
			ActiveUnit activeUnit = strategyWrapper;
			Side side_ = activeUnit.GetUnitSide();
			value.PostDeserializationHousekeeping(ref parentScen, ref concurrentDictionary_0, ref side_);
			activeUnit.SetUnitSide(bool_0: false, side_);
		}
	}

	public void DestroyLocalContacts()
	{
		try
		{
			foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
			{
				if (!Information.IsNothing(item.Value.Contact) && !Information.IsNothing(item.Value.Contact.ActualUnit))
				{
					item.Value.Contact.ActualUnit = null;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101225", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InitConsumer(DockFacility dockFacility_0, Sensor sensor_0, Contact contact_0, float float_0)
	{
		if (!dockFacility_0.IsOpenDockFacility || dockFacility_0.HostedBoats.Count == 0)
		{
			return;
		}
		float num = 0f;
		foreach (ActiveUnit value in dockFacility_0.HostedBoats.Values)
		{
			num = sensor_0.MaxIDRangeOnThisTarget(strategyWrapper, value);
			if (num * 3f < float_0)
			{
				continue;
			}
			Contact.HostedUnitReconRecord hostedUnitReconRecord = null;
			foreach (Contact.HostedUnitReconRecord item in contact_0.IncludeImporter(strategyWrapper.GetUnitSide()))
			{
				if (Operators.CompareString(item.UnitID, value.ObjectID, TextCompare: false) == 0)
				{
					hostedUnitReconRecord = item;
					hostedUnitReconRecord.ReconAge = 0f;
					break;
				}
			}
			if (Information.IsNothing(hostedUnitReconRecord))
			{
				AddNewHostedUnitReconRecord(value, contact_0, sensor_0);
				continue;
			}
			if (float_0 < num)
			{
				if (hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
				{
					hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownClass;
					strategyWrapper.AddMessage(value.UnitType_String + "之前发现于" + contact_0.Name + "已被确定为：" + value.UnitClass + "（侦察：" + strategyWrapper.Name + " - 传感器：" + sensor_0.Name + "). ", "目标报告", LoggedMessage.MessageType.ContactChange, 0, bool_0: false, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
				}
			}
			else if (float_0 < num * 2f && hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownType)
			{
				hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownType;
				strategyWrapper.AddMessage(value.UnitType_String + "之前发现于" + contact_0.Name + " 已被分类为：" + value.SubTypeDescription + "（侦察：" + strategyWrapper.Name + " - 传感器：" + sensor_0.Name + "). ", "目标报告", LoggedMessage.MessageType.ContactChange, 0, bool_0: false, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
			}
			hostedUnitReconRecord.ReconAge = 0f;
		}
		Lazy<List<Contact.HostedUnitReconRecord>> lazy = new Lazy<List<Contact.HostedUnitReconRecord>>();
		ActiveUnit activeUnit = null;
		foreach (Contact.HostedUnitReconRecord item2 in contact_0.IncludeImporter(strategyWrapper.GetUnitSide()))
		{
			strategyWrapper.ParentScen.ActiveUnits.TryGetValue(item2.UnitID, ref activeUnit);
			if (activeUnit == null)
			{
				if (float_0 < num * 2f)
				{
					lazy.Value.Add(item2);
				}
			}
			else if (!dockFacility_0.ParentPlatform.DockingOps.EmbarkedBoats.Contains(activeUnit) && (!activeUnit.IsAircraft || !dockFacility_0.ParentPlatform.AirOps.EmbarkedAircraft_ReadOnly.Contains((Aircraft)activeUnit)) && float_0 < num * 2f)
			{
				lazy.Value.Add(item2);
			}
		}
		foreach (Contact.HostedUnitReconRecord item3 in lazy.Value)
		{
			CheckConsumer(contact_0, item3);
		}
	}

	internal void CheckConsumer(Contact contact_0, Contact.HostedUnitReconRecord hostedUnitReconRecord_0)
	{
		contact_0.IncludeImporter(strategyWrapper.GetUnitSide()).Remove(hostedUnitReconRecord_0);
		HashSet<string> hashSet = new HashSet<string>();
		strategyWrapper.GetUnitSide().GetAllFriendlySides(strategyWrapper.ParentScen, hashSet);
		Side[] sides_ReadOnly = strategyWrapper.ParentScen.Sides_ReadOnly;
		Contact contact = null;
		Side[] array = sides_ReadOnly;
		Side[] array2 = array;
		foreach (Side side in array2)
		{
			if (!hashSet.Contains(side.Name) || !side.Contacts.TryGetValue(contact_0.ActualUnit.ObjectID, ref contact))
			{
				continue;
			}
			foreach (Contact.HostedUnitReconRecord item in contact.IncludeImporter(side))
			{
				if (Operators.CompareString(item.UnitID, hostedUnitReconRecord_0.UnitID, TextCompare: false) == 0)
				{
					contact.IncludeImporter(side).Remove(item);
					break;
				}
			}
		}
	}

	private void ConcatConsumer()
	{
		if (_TokenWrapper == null || _TokenWrapper.Count < 2)
		{
			return;
		}
		ConcurrentQueue<Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>> concurrentQueue = null;
		foreach (Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> item in _TokenWrapper)
		{
			foreach (Sensor item2 in new List<Sensor>(item.Item3))
			{
				if (item2.PostWriter() && item2.StartWriter(item.Item2, _TokenWrapper))
				{
					item.Item3.Remove(item2);
				}
			}
			if (item.Item3.Count == 0)
			{
				if (concurrentQueue != null)
				{
					continue;
				}
				concurrentQueue = new ConcurrentQueue<Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>>();
				foreach (Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> item3 in _TokenWrapper)
				{
					if (item3 == item)
					{
						break;
					}
					concurrentQueue.Enqueue(item3);
				}
			}
			else
			{
				concurrentQueue?.Enqueue(item);
			}
		}
		if (concurrentQueue != null)
		{
			_TokenWrapper = concurrentQueue;
		}
	}

	internal ActiveEmissionInterval InterruptConsumer()
	{
		if (m_UtilsWrapper == null)
		{
			m_UtilsWrapper = new ActiveEmissionInterval(this);
		}
		return m_UtilsWrapper;
	}

	[CompilerGenerated]
	private bool RemoveConsumer(Sensor sensor_0)
	{
		if (MapDic(sensor_0))
		{
			return !sensor_0.IsHeightFinder;
		}
		return false;
	}

	[CompilerGenerated]
	private bool FindConsumer(Sensor sensor_0)
	{
		if (!MapDic(sensor_0))
		{
			return !sensor_0.IsHeightFinder;
		}
		return false;
	}
}
