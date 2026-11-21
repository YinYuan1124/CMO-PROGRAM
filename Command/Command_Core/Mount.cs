using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Mount : PlatformComponent, ICargoClient
{
	public delegate void MountWeaponRecordAddedEventHandler(string MountObjectID, string WeaponRecObjectID);

	public delegate void MountWeaponRecordRemovedEventHandler(string MountObjectID, string WeaponRecObjectID);

	public enum _ReloadStatus : byte
	{
		Ready,
		Reloading,
		Unloading
	}

	public GlobalVariables.ArmorRating ArmorRating;

	public int ROF;

	public int MaxCapacity;

	public bool IsAutonomous;

	public bool IsLogistic;

	public bool LocalControl;

	public bool IsTrainable;

	public _ReloadStatus ReloadStatus;

	public bool ReserveTarget;

	[CompilerGenerated]
	[AccessedThroughProperty("MountWeapons")]
	private ObservableList<WeaponRec> m_BridgeConsumer;

	private Magazine m_InvocationConsumer;

	private int classConsumer;

	private int m_RequestConsumer;

	private Sensor[] valueConsumer;

	public CommDevice[] CommDevices;

	private float tokenizerConsumer;

	private float _StubConsumer;

	public float DP;

	public bool CanHotReload;

	public HashSet<int> ReloadPriority;

	private int? writerConsumer;

	private float? specificationConsumer;

	public HashSet<int> CompatibleDirectors;

	public bool Hypothetical;

	public float? Boresight;

	public int Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public bool Cargo_ParadropCapable;

	public IMobileGroundUnit._MobileUnitCategory MobileUnitCategory;

	public string LastFiredWeaponID;

	public static float PersonnelMass;

	public static float PersonnelArea;

	[ThreadStatic]
	private static StringBuilder _WatcherConsumer;

	private bool? reponseConsumer;

	private bool? m_DescriptorConsumer;

	[CompilerGenerated]
	private static MountWeaponRecordAddedEventHandler poolConsumer;

	[CompilerGenerated]
	private static MountWeaponRecordRemovedEventHandler _TaskConsumer;

	public ObservableList<WeaponRec> MountWeapons
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeConsumer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<WeaponRec>> value2 = CloneStub;
			EventHandler<ObservableListModified<WeaponRec>> value3 = ConnectStub;
			ObservableList<WeaponRec> bridgeConsumer = m_BridgeConsumer;
			if (bridgeConsumer != null)
			{
				bridgeConsumer.ItemsAdded -= value2;
				bridgeConsumer.ItemsRemoved -= value3;
			}
			m_BridgeConsumer = value;
			bridgeConsumer = m_BridgeConsumer;
			if (bridgeConsumer != null)
			{
				bridgeConsumer.ItemsAdded += value2;
				bridgeConsumer.ItemsRemoved += value3;
			}
		}
	}

	public bool IsVLS
	{
		get
		{
			if (!reponseConsumer.HasValue)
			{
				reponseConsumer = Name.Contains(" VLS");
			}
			return reponseConsumer.Value;
		}
	}

	public bool IsRail
	{
		get
		{
			if (!m_DescriptorConsumer.HasValue)
			{
				m_DescriptorConsumer = Name.Contains(" Rail");
			}
			return m_DescriptorConsumer.Value;
		}
	}

	public int AimpointOffset_Bearing
	{
		get
		{
			if (base.ParentPlatform == null)
			{
				return 0;
			}
			if (Module_ActiveUnit.CancelTokenizer(base.ParentPlatform))
			{
				if (!writerConsumer.HasValue)
				{
					writerConsumer = GameGeneral.LockRandom_0.Next(0, 360);
				}
				return writerConsumer.Value;
			}
			return 0;
		}
	}

	public float AimpointOffset_Distance
	{
		get
		{
			if (base.ParentPlatform == null)
			{
				return 0f;
			}
			if (Module_ActiveUnit.CancelTokenizer(base.ParentPlatform))
			{
				if (!specificationConsumer.HasValue)
				{
					if (MountWeapons.Count <= 0)
					{
						specificationConsumer = (float)((double)GameGeneral.LockRandom_0.Next(0, 51) / 100.0 * (double)((Facility)base.ParentPlatform).AimpointDispersalRadius);
					}
					else
					{
						specificationConsumer = (float)((double)GameGeneral.LockRandom_0.Next(75, 101) / 100.0 * (double)((Facility)base.ParentPlatform).AimpointDispersalRadius);
					}
				}
				return specificationConsumer.Value;
			}
			return 0f;
		}
	}

	public float TimeToFire
	{
		get
		{
			return tokenizerConsumer;
		}
		set
		{
			tokenizerConsumer = value;
		}
	}

	public float TimeToReloadAttempt
	{
		get
		{
			return _StubConsumer;
		}
		set
		{
			_StubConsumer = value;
		}
	}

	public Magazine MountMagazine
	{
		get
		{
			if (m_InvocationConsumer == null)
			{
				m_InvocationConsumer = new Magazine(base.ParentPlatform, 0, "挂载弹药库：" + Misc.ReadRequest(Name), ArmorRating, classConsumer, m_RequestConsumer, bool_0: false);
			}
			if (m_InvocationConsumer.ParentPlatform == null)
			{
				m_InvocationConsumer.ParentPlatform = base.ParentPlatform;
			}
			return m_InvocationConsumer;
		}
	}

	public bool IsCountermeasuresDispenser
	{
		get
		{
			if ((uint)(MountWeapons[0].GetReferenceWeapon(base.ParentPlatform.ParentScen).Type - 2005) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public bool HasEmittingSensors
	{
		get
		{
			Sensor[] sensors_ReadOnly = Sensors_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < sensors_ReadOnly.Length)
				{
					if (sensors_ReadOnly[num].IsActive)
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
	}

	public Sensor[] Sensors_ReadOnly => valueConsumer;

	public bool IsEmpty => MountWeapons.Where((WeaponRec WR) => WR.CurrentLoad == 0).Count() == MountWeapons.Count;

	public bool HasGuns
	{
		get
		{
			foreach (WeaponRec mountWeapon in MountWeapons)
			{
				if (mountWeapon.GetReferenceWeapon(base.ParentPlatform.ParentScen).Type == Weapon._WeaponType.Gun)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool HasAAW
	{
		get
		{
			foreach (WeaponRec mountWeapon in MountWeapons)
			{
				if (mountWeapon.GetReferenceWeapon(base.ParentPlatform.ParentScen).Type == Weapon._WeaponType.Gun)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsFacilityAimpoint
	{
		get
		{
			if (Module_ActiveUnit.CancelTokenizer(base.ParentPlatform))
			{
				return true;
			}
			return false;
		}
	}

	public static event MountWeaponRecordAddedEventHandler MountWeaponRecordAdded
	{
		[CompilerGenerated]
		add
		{
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler = poolConsumer;
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler2;
			do
			{
				mountWeaponRecordAddedEventHandler2 = mountWeaponRecordAddedEventHandler;
				MountWeaponRecordAddedEventHandler value2 = (MountWeaponRecordAddedEventHandler)Delegate.Combine(mountWeaponRecordAddedEventHandler2, value);
				mountWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref poolConsumer, value2, mountWeaponRecordAddedEventHandler2);
			}
			while ((object)mountWeaponRecordAddedEventHandler != mountWeaponRecordAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler = poolConsumer;
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler2;
			do
			{
				mountWeaponRecordAddedEventHandler2 = mountWeaponRecordAddedEventHandler;
				MountWeaponRecordAddedEventHandler value2 = (MountWeaponRecordAddedEventHandler)Delegate.Remove(mountWeaponRecordAddedEventHandler2, value);
				mountWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref poolConsumer, value2, mountWeaponRecordAddedEventHandler2);
			}
			while ((object)mountWeaponRecordAddedEventHandler != mountWeaponRecordAddedEventHandler2);
		}
	}

	public static event MountWeaponRecordRemovedEventHandler MountWeaponRecordRemoved
	{
		[CompilerGenerated]
		add
		{
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler = _TaskConsumer;
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler2;
			do
			{
				mountWeaponRecordRemovedEventHandler2 = mountWeaponRecordRemovedEventHandler;
				MountWeaponRecordRemovedEventHandler value2 = (MountWeaponRecordRemovedEventHandler)Delegate.Combine(mountWeaponRecordRemovedEventHandler2, value);
				mountWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref _TaskConsumer, value2, mountWeaponRecordRemovedEventHandler2);
			}
			while ((object)mountWeaponRecordRemovedEventHandler != mountWeaponRecordRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler = _TaskConsumer;
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler2;
			do
			{
				mountWeaponRecordRemovedEventHandler2 = mountWeaponRecordRemovedEventHandler;
				MountWeaponRecordRemovedEventHandler value2 = (MountWeaponRecordRemovedEventHandler)Delegate.Remove(mountWeaponRecordRemovedEventHandler2, value);
				mountWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref _TaskConsumer, value2, mountWeaponRecordRemovedEventHandler2);
			}
			while ((object)mountWeaponRecordRemovedEventHandler != mountWeaponRecordRemovedEventHandler2);
		}
	}

	static Mount()
	{
		PersonnelMass = 0.1f;
		PersonnelArea = 0.16f;
	}

	internal bool OrderTokenizer()
	{
		if (string.IsNullOrEmpty(LastFiredWeaponID))
		{
			return false;
		}
		if (_ParentPlatform.ParentScen.ActiveUnits.ContainsKey(LastFiredWeaponID))
		{
			if (_ParentPlatform.ParentScen.ActiveUnits[LastFiredWeaponID].IsWeapon)
			{
				if (((Weapon)_ParentPlatform.ParentScen.ActiveUnits[LastFiredWeaponID]).Flags.LauncherOccupiedDuringGuidance)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public override void ResetIDs()
	{
		checked
		{
			try
			{
				base.ResetIDs();
				foreach (WeaponRec mountWeapon in MountWeapons)
				{
					mountWeapon.ResetIDs();
				}
				if (!Information.IsNothing(m_InvocationConsumer))
				{
					m_InvocationConsumer.ResetIDs();
				}
				Sensor[] array = valueConsumer;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ResetIDs();
				}
				CommDevice[] commDevices = CommDevices;
				for (int j = 0; j < commDevices.Length; j++)
				{
					commDevices[j].ResetIDs();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100675", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public string ToXML(ref HashSet<string> hashSet_0, Scenario scenario_0)
	{
		string result = null;
		try
		{
			if (_WatcherConsumer == null)
			{
				_WatcherConsumer = new StringBuilder();
			}
			else
			{
				_WatcherConsumer.Clear();
			}
			_WatcherConsumer.Append("<Mount>");
			try
			{
				_WatcherConsumer.Append("<ID>").Append(ObjectID).Append("</ID>");
				if (hashSet_0 != null)
				{
					if (hashSet_0.Contains(ObjectID))
					{
						_WatcherConsumer.Append("</Mount>");
						result = _WatcherConsumer.ToString();
						return result;
					}
					hashSet_0.Add(ObjectID);
				}
				if (!string.IsNullOrEmpty(Name))
				{
					_WatcherConsumer.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
				}
				if (_Status != 0)
				{
					StringBuilder stringBuilder = _WatcherConsumer.Append("<Status>");
					byte status = (byte)_Status;
					stringBuilder.Append(status.ToString()).Append("</Status>");
				}
				if (base.DamageSeverity != 0)
				{
					_WatcherConsumer.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
				}
				if (_ParentPlatform != null)
				{
					_WatcherConsumer.Append("<PP>").Append(_ParentPlatform.ObjectID).Append("</PP>");
				}
				if (Boresight.HasValue)
				{
					_WatcherConsumer.Append("<Boresight>").Append(XmlConvert.ToString(Boresight.Value)).Append("</Boresight>");
				}
				_WatcherConsumer.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100676-A", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (MountWeapons.Count > 0)
				{
					_WatcherConsumer.Append("<MW>");
					foreach (WeaponRec mountWeapon in MountWeapons)
					{
						_WatcherConsumer.Append(mountWeapon.ToXML(hashSet_0, scenario_0));
					}
					_WatcherConsumer.Append("</MW>");
				}
				if (MountMagazine.Weapons.Count > 0)
				{
					_WatcherConsumer.Append("<MMW>");
					foreach (WeaponRec weapon in MountMagazine.Weapons)
					{
						_WatcherConsumer.Append(weapon.ToXML(hashSet_0, scenario_0));
					}
					_WatcherConsumer.Append("</MMW>");
				}
				if (valueConsumer.Length != 0)
				{
					_WatcherConsumer.Append("<Sensors>");
					Sensor[] array = valueConsumer;
					Sensor[] array2 = array;
					foreach (Sensor sensor in array2)
					{
						_WatcherConsumer.Append(sensor.ToXML(hashSet_0));
					}
					_WatcherConsumer.Append("</Sensors>");
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100676-B", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (CommDevices.Length != 0)
				{
					_WatcherConsumer.Append("<CommDevices>");
					CommDevice[] commDevices = CommDevices;
					CommDevice[] array3 = commDevices;
					foreach (CommDevice commDevice in array3)
					{
						_WatcherConsumer.Append(commDevice.ToXML(ref hashSet_0));
					}
					_WatcherConsumer.Append("</CommDevices>");
				}
				if (Coverage.HasDefinedArcs)
				{
					_WatcherConsumer.Append(Coverage.ToXML(bool_0: false));
				}
				if (tokenizerConsumer != 0f)
				{
					_WatcherConsumer.Append("<TTF>").Append(XmlConvert.ToString(tokenizerConsumer)).Append("</TTF>");
				}
				if (MountMagazine.TimeToFire != 0f)
				{
					_WatcherConsumer.Append("<TTF_MountMagazine>").Append(XmlConvert.ToString(MountMagazine.TimeToFire)).Append("</TTF_MountMagazine>");
				}
				_WatcherConsumer.Append("<DP>").Append(XmlConvert.ToString(DP)).Append("</DP>");
				if (_StubConsumer != 0f)
				{
					_WatcherConsumer.Append("<TTRA>").Append(XmlConvert.ToString(_StubConsumer)).Append("</TTRA>");
				}
				if (ReserveTarget)
				{
					_WatcherConsumer.Append("<ReserveTarget>True</ReserveTarget>");
				}
				if (ReloadStatus != 0)
				{
					_WatcherConsumer.Append("<ReloadStatus>").Append((byte)ReloadStatus).Append("</ReloadStatus>");
				}
				if (ReloadPriority.Count > 0)
				{
					_WatcherConsumer.Append("<RPriority>").Append(string.Join(",", ReloadPriority)).Append("</RPriority>");
				}
				if (AimpointOffset_Bearing != 0)
				{
					_WatcherConsumer.Append("<AO_B>").Append(XmlConvert.ToString(AimpointOffset_Bearing)).Append("</AO_B>");
				}
				if (AimpointOffset_Distance != 0f)
				{
					_WatcherConsumer.Append("<AO_D>").Append(XmlConvert.ToString(AimpointOffset_Distance)).Append("</AO_D>");
				}
				_WatcherConsumer.Append("</Mount>");
				result = _WatcherConsumer.ToString();
				return result;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at 100676-C", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 100676", "");
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static Mount FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ActiveUnit activeUnit_0)
	{
		try
		{
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			if (num == 0)
			{
				if (Information.IsNothing(Misc.StartRequest(xmlNode_0.ChildNodes, "Name")))
				{
					return null;
				}
				num = DBFunctions.GetMountIDByName(Misc.ReadRequest(Misc.StartRequest(xmlNode_0.ChildNodes, "Name").InnerText), activeUnit_0.ParentScen.DBConnection);
			}
			Mount mount = DBFunctions.GetMount(num, ref activeUnit_0.ParentScen, bool_0: false);
			mount.ParentPlatform = activeUnit_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0 != null)
			{
				if (concurrentDictionary_0.ContainsKey(innerText))
				{
					return (Mount)concurrentDictionary_0[innerText];
				}
				mount.ObjectID_Set(innerText);
				concurrentDictionary_0.TryAdd(mount.ObjectID, mount);
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					try
					{
						switch (xmlNode_.Name)
						{
						case "TTF_MountMagazine":
							mount.MountMagazine.TimeToFire = XmlConvert.ToSingle(xmlNode_.InnerText);
							break;
						case "Status":
							switch (xmlNode_.InnerText)
							{
							default:
								mount._Status = (_ComponentStatus)Conversions.ToByte(xmlNode_.InnerText);
								break;
							case "Operational":
								mount._Status = _ComponentStatus.Operational;
								break;
							case "Destroyed":
								mount._Status = _ComponentStatus.Destroyed;
								break;
							case "Damaged":
								mount._Status = _ComponentStatus.Damaged;
								break;
							}
							break;
						case "DP":
							mount.DP = XmlConvert.ToSingle(xmlNode_.InnerText);
							break;
						case "MountMagazineWeapons":
						case "MMW":
							try
							{
								enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									XmlNode xmlNode_4 = (XmlNode)enumerator3.Current;
									WeaponRec item2 = WeaponRec.FromXML(ref xmlNode_4, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
									mount.MountMagazine.Weapons.Add(item2);
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
						case "TTF":
							mount.tokenizerConsumer = XmlConvert.ToSingle(xmlNode_.InnerText);
							break;
						case "Sensors":
							try
							{
								enumerator5 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator5.MoveNext())
								{
									Sensor sensor = Sensor.FromXML((XmlNode)enumerator5.Current, concurrentDictionary_0, mount.ParentPlatform);
									sensor.ParentPlatform = activeUnit_0;
									ArrayExtensions.Add(ref mount.valueConsumer, sensor);
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
						case "ReloadStatus":
							switch (xmlNode_.InnerText)
							{
							default:
								mount.ReloadStatus = (_ReloadStatus)Conversions.ToByte(xmlNode_.InnerText);
								break;
							case "Unloading":
								mount.ReloadStatus = _ReloadStatus.Unloading;
								break;
							case "Reloading":
								mount.ReloadStatus = _ReloadStatus.Reloading;
								break;
							case "Ready":
								mount.ReloadStatus = _ReloadStatus.Ready;
								break;
							}
							break;
						case "DamageSeverity":
							mount.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode_.InnerText);
							break;
						case "MW":
						case "MountWeapons":
							try
							{
								enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									XmlNode xmlNode_3 = (XmlNode)enumerator4.Current;
									WeaponRec item = WeaponRec.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
									mount.MountWeapons.Add(item);
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
						case "ReserveTarget":
							mount.ReserveTarget = Conversions.ToBoolean(xmlNode_.InnerText);
							break;
						case "Boresight":
							mount.Boresight = Convert.ToSingle(xmlNode_.InnerText, CultureInfo.InvariantCulture);
							break;
						case "CommDevices":
							try
							{
								enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
									CommDevice commDevice = CommDevice.FromXML(ref xmlNode_2, ref concurrentDictionary_0, activeUnit_0);
									commDevice.ParentPlatform = activeUnit_0;
									ArrayExtensions.Add(ref mount.CommDevices, commDevice);
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
						case "RPriority":
						case "ReloadPriority":
						{
							string[] array = xmlNode_.InnerText.Split(',');
							string[] array2 = array;
							foreach (string text in array2)
							{
								if (Operators.CompareString(text, "", TextCompare: false) != 0)
								{
									mount.ReloadPriority.Add(Conversions.ToInteger(text));
								}
							}
							break;
						}
						case "Cov":
						case "Coverage":
							mount.Coverage = _Coverage.FromXML(ref xmlNode_);
							break;
						case "AimpointOffset_Distance":
						case "AO_D":
							mount.specificationConsumer = XmlConvert.ToSingle(xmlNode_.InnerText);
							break;
						case "AimpointOffset_Bearing":
						case "AO_B":
							mount.writerConsumer = XmlConvert.ToInt32(xmlNode_.InnerText);
							break;
						case "TTRA":
							mount._StubConsumer = XmlConvert.ToSingle(xmlNode_.InnerText);
							break;
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
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return mount;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100677", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public Mount()
		: base(null)
	{
		MountWeapons = new ObservableList<WeaponRec>();
		valueConsumer = new Sensor[0];
		CommDevices = new CommDevice[0];
		ReloadPriority = new HashSet<int>();
		CompatibleDirectors = new HashSet<int>();
		LastFiredWeaponID = "";
	}

	internal int RegisterTokenizer(ref int int_0, ref int int_1)
	{
		int_0 = 0;
		int_1 = 0;
		foreach (WeaponRec mountWeapon in MountWeapons)
		{
			if (mountWeapon.CurrentLoad == 0)
			{
				continue;
			}
			if (mountWeapon.Multiple <= 1)
			{
				int_0 += mountWeapon.CurrentLoad;
				continue;
			}
			float num = (float)mountWeapon.CurrentLoad / (float)mountWeapon.Multiple;
			if (num == (float)(int)Math.Round(num))
			{
				int_0 += (int)Math.Round(num);
				continue;
			}
			int_1++;
			int_0 += (int)Math.Floor((double)mountWeapon.CurrentLoad / (double)mountWeapon.Multiple);
		}
		return int_0 + int_1;
	}

	public void AddSensor(Sensor sensor_0)
	{
		ArrayExtensions.Add(ref valueConsumer, sensor_0);
	}

	public void RemoveSensor(Sensor sensor_0)
	{
		ArrayExtensions.Remove(ref valueConsumer, sensor_0);
	}

	internal void ManageTokenizer(Side side_0, bool bool_0, bool bool_1)
	{
		base.Destroy(side_0, bool_0, bool_1);
		Sensor[] array = valueConsumer;
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Destroy(side_0, bool_0, bool_1);
			}
			CommDevice[] commDevices = CommDevices;
			for (int j = 0; j < commDevices.Length; j++)
			{
				commDevices[j].Destroy(side_0, bool_0, bool_1);
			}
		}
	}

	public override void Destroy(Side side_0, bool bool_0, bool bool_1)
	{
		try
		{
			float num = 0f;
			if (base.ParentPlatform != null)
			{
				num = base.ParentPlatform.Damage.DamagePercent;
			}
			base.Destroy(side_0, bool_0, bool_1);
			Sensor[] array = valueConsumer;
			checked
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Destroy(side_0, bool_0, bool_1);
				}
				CommDevice[] commDevices = CommDevices;
				for (int j = 0; j < commDevices.Length; j++)
				{
					commDevices[j].Destroy(side_0, bool_0, bool_1);
				}
			}
			if (!(bool_1 && bool_1) || bool_0)
			{
				return;
			}
			side_0.AAR.AddToLosses(this, bool_1);
			float num2 = 0f;
			if (base.ParentPlatform != null)
			{
				num2 = base.ParentPlatform.Damage.DamagePercent;
			}
			if (num2 == num)
			{
				return;
			}
			List<EventTrigger> list = new List<EventTrigger>();
			foreach (EventTrigger value in base.ParentPlatform.ParentScen.EventTriggers.Values)
			{
				if (value.Type == EventTrigger.EventTriggerType.UnitDamaged && ((EventTrigger_UnitDamaged)value).GetIsFulfilled(base.ParentPlatform, num, num2))
				{
					list.Add(value);
				}
			}
			base.ParentPlatform.ParentScen.FireEvents(list);
			base.ParentPlatform.utilsVal = num2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100678", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RevertTokenizer(Weapon weapon_0, double double_0, double double_1, double double_2)
	{
		if (weapon_0.Warheads.Length != 0 && weapon_0.Warheads[0].GetIsAirburst(weapon_0, base.ParentPlatform))
		{
			string text = "空中爆炸";
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				base.ParentPlatform.ParentScen.AddMessage("武器：" + weapon_0.UnitClass + text + Misc.ReadRequest(Name) + "（单元 " + base.ParentPlatform.Name + "）" + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0 * 3.2808399200439453))) + "ft", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
			}
			else
			{
				base.ParentPlatform.ParentScen.AddMessage("武器：" + weapon_0.UnitClass + text + Misc.ReadRequest(Name) + "（单元 " + base.ParentPlatform.Name + "）" + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0))) + "m", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
			}
		}
		else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			base.ParentPlatform.ParentScen.AddMessage("武器：" + weapon_0.UnitClass + "错过" + Misc.ReadRequest(Name) + "（单元 " + base.ParentPlatform.Name + "）" + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0 * 3.2808399200439453))) + "ft", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
		}
		else
		{
			base.ParentPlatform.ParentScen.AddMessage("武器：" + weapon_0.UnitClass + "错过" + Misc.ReadRequest(Name) + "（单元 " + base.ParentPlatform.Name + "）" + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0))) + "m", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
		}
	}

	public void ResolveDamageFromWeapon(Weapon weapon_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, bool bool_0)
	{
		try
		{
			Warhead warhead = weapon_0.Warheads[0];
			double double_ = 0.0;
			double double_2 = 0.0;
			if (Module_ActiveUnit.CancelTokenizer(base.ParentPlatform))
			{
				double double_3 = 0.0;
				double double_4 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref double_3, ref double_4, AimpointOffset_Distance / 1852f, AimpointOffset_Bearing);
				Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_4, ref double_, ref double_2, float_0 / 1852f, float_1);
			}
			else
			{
				Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref double_, ref double_2, float_0 / 1852f, float_1);
			}
			float num = (((weapon_0.IsReEntryVehicle || weapon_0.IsBallisticMissile) && weapon_0.Navigator.HasPlottedCourse()) ? Math.Max(weapon_0.Navigator.PlottedCourse.First().Altitude, Terrain.GetElevation(weapon_0.Navigator.PlottedCourse.First().Latitude, weapon_0.Navigator.PlottedCourse.First().Longitude, bool_0: false, weapon_0.ParentScen) + weapon_0.GetOptimumBurstHeight_AGL(base.ParentPlatform)) : ((float)(Terrain.GetElevation(double_2, double_, bool_0: false, weapon_0.ParentScen) + weapon_0.GetOptimumBurstHeight_AGL(base.ParentPlatform))));
			if (!nullable_0.HasValue || !nullable_1.HasValue)
			{
				double double_5 = 0.0;
				double double_6 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(double_, double_2, ref double_5, ref double_6, float_0 / 1852f, float_1);
				nullable_0 = double_6;
				nullable_1 = double_5;
				_ = Debugger.IsAttached;
			}
			if (warhead.IsAreaEffect)
			{
				new Explosion(ref base.ParentPlatform.ParentScen, double_, double_2, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, num, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, activeUnit_0, null, null, 0, 0);
				double double_7 = (warhead.IsAreaEffect_Conventional ? ((double)float_0) : Math.Sqrt(Math.Pow(Math.Abs(num - base.ParentPlatform.GetCurrentAltitude()), 2.0) + Math.Pow(float_0, 2.0)));
				RevertTokenizer(weapon_0, double_7, double_, double_2);
				return;
			}
			if (float_0 == 0f)
			{
				CountStub(weapon_0, activeUnit_0, nullable_0, nullable_1, nullable_2);
			}
			else
			{
				double num2 = Math.Sqrt(Math.Pow(Math.Abs(num - base.ParentPlatform.GetCurrentAltitude()), 2.0) + Math.Pow(float_0, 2.0));
				RevertTokenizer(weapon_0, num2, double_, double_2);
				if (warhead.IsExplosive || warhead.IsIncendiary)
				{
					bool bool_ = base.ParentPlatform.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
					Warhead.WarheadType type = warhead.Type;
					if (type != Warhead.WarheadType.Fragmentation && type != Warhead.WarheadType.ContinuousRod && type != Warhead.WarheadType.Fragmentation_ABM)
					{
						double num3 = Warhead.BlastDamageAtThisDistance(base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetLongitude(), num2 / 1852.0, DP, warhead.Type, warhead.DP, Weapon.DetonationMedium.Air, bool_, base.ParentPlatform.ParentScen);
						if (num3 > 0.0)
						{
							ResolveDamageFromBlast(num3, warhead.Type);
						}
					}
					else
					{
						float cutoffRange_Frag_nm = Explosion.GetCutoffRange_Frag_nm(weapon_0.Warheads[0].DP, Weapon.DetonationMedium.Air);
						double double_8 = Warhead.FragDamageAtThisDistance(base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetLongitude(), num2 / 1852.0, warhead.Type, warhead.DP, Weapon.DetonationMedium.Air, bool_, base.ParentPlatform.ParentScen);
						ResolveDamageFromFrag(double_8, cutoffRange_Frag_nm);
					}
					new Explosion(ref base.ParentPlatform.ParentScen, double_, double_2, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, num, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, this, null, 0, 0);
				}
			}
			base.ParentPlatform.Damage.LastWeaponHit = weapon_0;
			if (DP <= 0f)
			{
				DP = 0f;
				if (!base.ParentPlatform.IsWeapon)
				{
					base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 损失了一个挂架/武器", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(double_, double_2));
				}
				Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer(base.ParentPlatform));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100679", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CountStub(Weapon weapon_0, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2)
	{
		try
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			float float_;
			if (Module_ActiveUnit.CancelTokenizer(base.ParentPlatform))
			{
				Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref double_, ref double_2, AimpointOffset_Distance / 1852f, AimpointOffset_Bearing);
				float_ = Terrain.GetElevation(double_2, double_, bool_0: false, weapon_0.ParentScen) + weapon_0.GetOptimumBurstHeight_AGL(base.ParentPlatform);
			}
			else
			{
				double_2 = base.ParentPlatform.GetLatitude();
				double_ = base.ParentPlatform.GetLongitude();
				float_ = base.ParentPlatform.GetCurrentAltitude();
			}
			base.ParentPlatform.ParentScen.AddMessage("武器：" + weapon_0.UnitClass + "毁伤了" + Misc.ReadRequest(Name) + "（单元 " + base.ParentPlatform.Name + ")", weapon_0.UnitClass + " 命中", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_, double_2));
			Warhead warhead = weapon_0.Warheads[0];
			double val = 0.0;
			double num;
			if (!warhead.GetIsNuclear(weapon_0.ParentScen) && !warhead.GetIsAirburst(weapon_0, base.ParentPlatform))
			{
				num = weapon_0.CreateReponse(ArmorRating, base.ParentPlatform.VisualSizeClass) / 100f;
				val = weapon_0.ShockDamage_KE();
			}
			else
			{
				num = 0.0;
			}
			if (Information.IsNothing(nullable_0) || Information.IsNothing(nullable_1))
			{
				nullable_0 = double_2;
				nullable_1 = double_;
			}
			double val2 = 0.0;
			if (num <= 0.0)
			{
				if (warhead.IsExplosive || warhead.IsIncendiary)
				{
					new Explosion(ref base.ParentPlatform.ParentScen, double_, double_2, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, this, null, null, null, 0, 0);
				}
			}
			else
			{
				base.ParentPlatform.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num * 100.0)) + "%渗透百分比", base.ParentPlatform.Name + " - armor penetrated", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(double_, double_2));
				val2 = (warhead.IsExplosive ? Math.Round(num * 2.0 * (double)warhead.DP, 2) : Math.Round(num * (double)warhead.DP, 2));
				if (num < 1.0 && warhead.IsExplosive)
				{
					new Explosion(ref base.ParentPlatform.ParentScen, double_, double_2, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_, weapon_0.Type, (float)((double)warhead.DP * (1.0 - num)), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, this, null, 0, 0);
				}
				else if (((Facility)base.ParentPlatform).Armor_General == GlobalVariables.ArmorRating.None && warhead.IsExplosive)
				{
					new Explosion(ref base.ParentPlatform.ParentScen, double_, double_2, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_, weapon_0.Type, (float)((double)warhead.DP * num * 0.25), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, this, null, 0, 0);
				}
			}
			if (num > 0.0)
			{
				base.ParentPlatform.AddMessage(Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 损失了一个挂架/武器", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(double_, double_2));
				Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer(base.ParentPlatform));
			}
			float num2 = (float)Math.Max(val, val2);
			ResolveDamageForOnboardSensors(num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100680", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageForOnboardSensors(double double_0)
	{
		foreach (Sensor item in Sensors_ReadOnly.Where((Sensor theSen) => !theSen.m_IsMk1Eyeball))
		{
			if (double_0 < 1.0)
			{
				if ((int)item.DamageSeverity < 0)
				{
					if (!base.ParentPlatform.IsWeapon)
					{
						base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(item.Name) + "已经轻微受损。", base.ParentPlatform.Name + " - 对传感器损伤", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
					}
					item.Damage(_DamageSeverityFactor.Light);
				}
			}
			else if (double_0 < 2.0)
			{
				if ((int)item.DamageSeverity < 1)
				{
					if (!base.ParentPlatform.IsWeapon)
					{
						base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(item.Name) + "已经中度受损。", base.ParentPlatform.Name + " - 对传感器损伤", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
					}
					item.Damage(_DamageSeverityFactor.Medium);
				}
			}
			else if (double_0 < 5.0)
			{
				if ((int)item.DamageSeverity < 2)
				{
					if (!base.ParentPlatform.IsWeapon)
					{
						base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(item.Name) + "已经严重受损。", base.ParentPlatform.Name + " - 对传感器损伤", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
					}
					item.Damage(_DamageSeverityFactor.Heavy);
				}
			}
			else
			{
				if (!base.ParentPlatform.IsWeapon)
				{
					base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(item.Name) + "已被摧毁。", base.ParentPlatform.Name + " 损失了一个传感器", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
				}
				item.Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, bool_1: false);
			}
		}
	}

	public void ResolveDamageFromFrag(double double_0, float float_0, int int_0 = 0)
	{
		try
		{
			if (double_0 == 0.0)
			{
				return;
			}
			ResolveDamageForOnboardSensors(double_0);
			if (ArmorRating > GlobalVariables.ArmorRating.RHA_20mm)
			{
				return;
			}
			DP = (float)Math.Round((double)DP - double_0, 1);
			if (Math.Round(double_0, 2) <= 0.0)
			{
				return;
			}
			new WeaponImpact(ref base.ParentPlatform.ParentScen, base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
			if (Status == _ComponentStatus.Operational)
			{
				base.ParentPlatform.AddMessage(Misc.ReadRequest(Name) + "遭受了碎片毁伤：" + Conversions.ToString(Math.Ceiling(double_0)) + " DPs", Misc.ReadRequest(Name) + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			else
			{
				base.ParentPlatform.AddMessage(Misc.ReadRequest(Name) + "遭受了额外的碎片毁伤：" + Conversions.ToString(Math.Ceiling(double_0)) + " DPs", Misc.ReadRequest(Name) + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			if (DP <= 0f)
			{
				DP = 0f;
				if (!base.ParentPlatform.IsWeapon)
				{
					base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 损失了一个挂架/武器", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
				}
				Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer(base.ParentPlatform));
				return;
			}
			switch (GameGeneral.LockRandom_0.Next(0, 3))
			{
			default:
				if ((int)base.DamageSeverity < 2)
				{
					Damage(_DamageSeverityFactor.Heavy);
				}
				break;
			case 1:
				if ((int)base.DamageSeverity < 1)
				{
					Damage(_DamageSeverityFactor.Medium);
				}
				break;
			case 0:
				if ((int)base.DamageSeverity < 0)
				{
					Damage(_DamageSeverityFactor.Light);
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100681", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageFromBomblets(double double_0, Warhead.WarheadType warheadType_0, float float_0)
	{
		try
		{
			if (double_0 == 0.0)
			{
				return;
			}
			CustomizeStub(ref double_0, warheadType_0);
			DP = (float)Math.Round((double)DP - double_0, 1);
			ResolveDamageForOnboardSensors(double_0);
			if (Math.Round(double_0, 2) <= 0.0)
			{
				return;
			}
			new WeaponImpact(ref base.ParentPlatform.ParentScen, base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
			base.ParentPlatform.AddMessage(Misc.ReadRequest(Name) + "遭受了炸弹毁伤：" + Conversions.ToString(Math.Round(double_0, 1)) + " DPs", Misc.ReadRequest(Name) + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			if (!(DP <= 0f) && (!Module_ActiveUnit.CancelTokenizer(base.ParentPlatform) || !((Facility)base.ParentPlatform).RepresentsMobileGroundUnit))
			{
				switch (GameGeneral.LockRandom_0.Next(0, 3))
				{
				default:
					if ((int)base.DamageSeverity < 2)
					{
						Damage(_DamageSeverityFactor.Heavy);
					}
					break;
				case 1:
					if ((int)base.DamageSeverity < 1)
					{
						Damage(_DamageSeverityFactor.Medium);
					}
					break;
				case 0:
					if ((int)base.DamageSeverity < 0)
					{
						Damage(_DamageSeverityFactor.Light);
					}
					break;
				}
			}
			else
			{
				DP = 0f;
				if (!base.ParentPlatform.IsWeapon)
				{
					base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 损失了一个挂架/武器", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
				}
				Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer(base.ParentPlatform));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100682", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CustomizeStub(ref double double_0, Warhead.WarheadType warheadType_0)
	{
		switch (warheadType_0)
		{
		case Warhead.WarheadType.Cluster_AP:
			switch (ArmorRating)
			{
			case GlobalVariables.ArmorRating.Light:
				double_0 = 0.5 * double_0;
				break;
			default:
				double_0 = 0.0;
				break;
			case GlobalVariables.ArmorRating.None:
				break;
			}
			break;
		case Warhead.WarheadType.Cluster_AT:
		case Warhead.WarheadType.Cluster_SmartSubs:
			if (!IsFacilityAimpoint)
			{
				switch (ArmorRating)
				{
				default:
					double_0 = 0.0;
					break;
				case GlobalVariables.ArmorRating.Medium:
					double_0 = 0.5 * double_0;
					break;
				case GlobalVariables.ArmorRating.Light:
					double_0 = 0.7 * double_0;
					break;
				case GlobalVariables.ArmorRating.None:
					break;
				}
			}
			break;
		case Warhead.WarheadType.Cluster_Penetrator:
			if (!IsFacilityAimpoint)
			{
				switch (ArmorRating)
				{
				case GlobalVariables.ArmorRating.Light:
					double_0 = 0.9 * double_0;
					break;
				case GlobalVariables.ArmorRating.Medium:
					double_0 = 0.7 * double_0;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					double_0 = 0.5 * double_0;
					break;
				case GlobalVariables.ArmorRating.Special:
					double_0 = 0.2 * double_0;
					break;
				}
			}
			break;
		case Warhead.WarheadType.SuperFrag:
		{
			GlobalVariables.ArmorRating armorRating = ArmorRating;
			if (armorRating != GlobalVariables.ArmorRating.None && armorRating != GlobalVariables.ArmorRating.Light)
			{
				double_0 = 0.0;
			}
			break;
		}
		}
	}

	public void ResolveDamageFromBlast(double double_0, Warhead.WarheadType warheadType_0)
	{
		try
		{
			int num = 0;
			switch (ArmorRating)
			{
			case GlobalVariables.ArmorRating.Light:
				num = 10;
				break;
			case GlobalVariables.ArmorRating.Medium:
				num = 30;
				break;
			case GlobalVariables.ArmorRating.Heavy:
				num = 75;
				break;
			case GlobalVariables.ArmorRating.Special:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.None:
				num = 1;
				break;
			}
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.AddMessage(Misc.ReadRequest(Name) + "受到爆炸毁伤：" + Conversions.ToString(Math.Round(double_0, 1)) + " DPs", Misc.ReadRequest(Name) + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			ResolveDamageForOnboardSensors(double_0);
			if (double_0 <= (double)num)
			{
				if (double_0 > (double)num / 2.0)
				{
					new WeaponImpact(ref base.ParentPlatform.ParentScen, base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
					if (!base.ParentPlatform.IsWeapon)
					{
						base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已经损坏了。", base.ParentPlatform.Name + " - 对挂架/武器损伤", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
					}
					Damage(_DamageSeverityFactor.Medium);
				}
			}
			else
			{
				new WeaponImpact(ref base.ParentPlatform.ParentScen, base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
				if (!base.ParentPlatform.IsWeapon)
				{
					base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 损失了一个挂架/武器", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
				}
				Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer((Facility)base.ParentPlatform));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100683", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void vmethod_0(float float_0)
	{
		Sensor[] sensors_ReadOnly = Sensors_ReadOnly;
		checked
		{
			for (int i = 0; i < sensors_ReadOnly.Length; i++)
			{
				sensors_ReadOnly[i].vmethod_0(float_0);
			}
			CommDevice[] commDevices = CommDevices;
			for (int j = 0; j < commDevices.Length; j++)
			{
				commDevices[j].vmethod_0(float_0);
			}
		}
	}

	private void CloneStub(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			poolConsumer?.Invoke(ObjectID, item.ObjectID);
		}
	}

	private void ConnectStub(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			_TaskConsumer?.Invoke(ObjectID, item.ObjectID);
		}
	}

	public CargoType GetRequiredCargoType()
	{
		return Cargo_Type;
	}

	public float GetRequiredCrewSpace()
	{
		return Cargo_Crew;
	}

	public float GetRequiredArea()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Area == 0f)
		{
			Cargo_Area = (float)Cargo_Crew * PersonnelArea;
		}
		return Cargo_Area;
	}

	public float GetRequiredAreaStacked(ICargoHost icargoHost_0, int int_0)
	{
		return GetRequiredArea() * (float)int_0;
	}

	public float GetRequiredMass()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Mass == 0f)
		{
			Cargo_Mass = (float)Cargo_Crew * PersonnelMass;
		}
		return Cargo_Mass;
	}

	public bool GetParadropCapable()
	{
		return Cargo_ParadropCapable;
	}

	public string GetCargoName()
	{
		return Name;
	}

	public string GetCargoObjectID()
	{
		return ObjectID;
	}

	public int imethod_0()
	{
		return DBID;
	}

	public _ComponentStatus GetCargoObjectStatus()
	{
		return Status;
	}

	public _DamageSeverityFactor GetCargoObjectDamageSeverity()
	{
		return base.DamageSeverity;
	}

	public string GetCargoObjectReasonForInoperative()
	{
		return ReasonForInoperative;
	}

	public string GetCargoObjectLossString()
	{
		return "FacilityAimpointCargo_" + DBID;
	}

	public string CargoObjectToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		return ToXML(ref hashSet_0, scenario_0);
	}

	public void imethod_1()
	{
		ResetIDs();
	}

	public void DestroyCargoObject(Side side_0, bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		Destroy(side_0, bool_0, bool_1);
	}

	public bool WantsToUnload()
	{
		return false;
	}

	public bool IsTowable()
	{
		return false;
	}

	public bool IsStackable()
	{
		return false;
	}

	public float GetRequiredHeight()
	{
		return 0f;
	}

	public int GetCargoQuantity()
	{
		return 1;
	}

	public bool isMatch(Cargo cargo_0)
	{
		if (cargo_0 != null && cargo_0.CurrentType == Cargo.CargoObjectType.Mount && cargo_0.CargoObjectDBID == DBID)
		{
			return true;
		}
		return false;
	}
}
