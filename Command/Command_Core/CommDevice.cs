using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CommDevice : PlatformComponent
{
	public enum CommLinkType
	{
		NONE = 1001,
		Commercial_SATCOM = 2001,
		USN_FLTSATCOM = 2002,
		MILSTAR_SATCOM = 2003,
		DSCS_SATCOM = 2004,
		Skynet_SATCOM = 2005,
		Big_Ball_SATCOM = 2006,
		SSIXS_SATCOM = 2007,
		Syracuse_SATCOM = 2008,
		Punch_Bowl_SATCOM = 2009,
		SATCOM_Generic = 2010,
		Visual_Comm = 3001,
		Laser_Comm = 3002,
		Land_Line = 3003,
		Link4 = 4001,
		Link10 = 4002,
		Link11 = 4003,
		Link16 = 4004,
		Link14 = 4005,
		LinkW = 4008,
		LinkY = 4009,
		LinkZ = 4010,
		AKT22_Datalink = 5001,
		PEAB_TDMA_Datalink = 5002,
		TERMA_Datalink = 5003,
		LAMPS_Datalink = 5004,
		APD15_Datalink = 5005,
		A346Z_Datalink = 5006,
		ELF_Link = 6001,
		Radio = 7001,
		HaveQuick_Radio = 7002,
		OneWay_WireGuidance = 8001,
		TwoWay_WireGuidance = 8002,
		NATO_SonobuoyLink = 9001,
		RGB_SonobuoyLink = 9002,
		BM_SonobuoyLink = 9003,
		Generic_SonobuoyLink = 9004,
		Type75_SonobuoyLink = 9005,
		AEGIS_WeaponLink = 10001,
		AWG9_WeaponLink = 10002,
		NTU_WeaponLink = 10003,
		NASAMS_WeaponLink = 10004,
		AGM142_WeaponLink = 10005,
		Patriot_WeaponLink = 10006,
		AGM154_WeaponLink = 10007,
		Rapier_WeaponLink = 10008,
		AIM120_WeaponLink = 10009,
		Roland_WeaponLink = 10010,
		AAW9_13_WeaponLink = 10011,
		SA12_WeaponLink = 10012,
		AJ168_WeaponLink = 10013,
		SA5_WeaponLink = 10014,
		AS12_WeaponWire = 10015,
		SA10_WeaponLink = 10016,
		AS15TT_WeaponLink = 10017,
		HUMRAAM_WeaponLink = 10018,
		AS30_WeaponLink = 10019,
		HOT_WeaponLink = 10020,
		APK8_9_WeaponLink = 10021,
		IKARA_WeaponLink = 10022,
		AS7_WeaponLink = 10023,
		MICA_WeaponLink = 10024,
		Aster_WeaponLink = 10025,
		Otomat_WeaponLink = 10026,
		GBU15_WeaponLink = 10027,
		RBS15_WeaponLink = 10028,
		ABM_WeaponLink = 10029,
		ADATS_WeaponLink = 10030,
		Arrow_WeaponLink = 10031,
		AT2_3_6_12_16_WeaponLink = 10032,
		Bamse_WeaponLink = 10033,
		Barak_WeaponLink = 10034,
		Blowpipe_WeaponLink = 10035,
		Bullpup_WeaponLink = 10036,
		C701_WeaponLink = 10037,
		CADSN1_WeaponLink = 10038,
		ASM_SSM_WeaponLink = 10039,
		Crotale_WeaponLink = 10040,
		EFOGM_WeaponLink = 10041,
		Gabriel_WeaponLink = 10042,
		MarteMk2_WeaponLink = 10043,
		Javelin_WeaponLink = 10044,
		SAM1_WeaponLink = 10045,
		SAM4_WeaponLink = 10046,
		SeaCat_WeaponLink = 10047,
		SeaSkua_WeaponLink = 10048,
		SeaWolf_WeaponLink = 10049,
		SkyBow_WeaponLink = 10050,
		Starstreak_WeaponLink = 10051,
		THAAD_WeaponLink = 10052,
		TOW_WeaponLink = 10053,
		AA10_12_WeaponLink = 10054,
		AA9_13_WeaponLink = 10055,
		AA5_WeaponLink = 10056,
		AA7_WeaponLink = 10057,
		AAM4_WeaponLink = 10058,
		SkySwordII_WeaponLink = 10059,
		RBS70_90_WeaponLink = 10060,
		Derby_WeaponLink = 10061,
		Blackwing_UAV_WeaponLink = 10073,
		Swingfire_WeaponLink = 10075,
		HISAR_WeaponLink = 10076,
		SSM2_WeaponLink = 10077,
		Nag_WeaponLink = 10078
	}

	public struct _Flags
	{
		public bool Broadcast;

		public bool Secure;

		public bool Receive_Only;

		public bool Send_Only;

		public bool LOS_Limited;

		public bool ELF_Radio;

		public bool SLF_Radio;

		public bool VLF_Radio;

		public bool ULF_Radio;

		public bool LF_Radio;

		public bool MF_Radio;

		public bool HF_Radio;

		public bool VHF_Radio;

		public bool UHF_Radio;

		public bool SHF_Radio;

		public bool EHF_Radio;

		public bool DaisyChain;

		public bool Low_Probability_Of_Intercept;

		public bool Phased_Array_Antenna;

		public bool Jam_Resistant;

		public bool BLOS_LEO;

		public bool BLOS_MEO;
	}

	public CommLinkType Type;

	public double Range;

	public int MaxChannels;

	public _Flags Flags;

	private int m_PolicyObserver;

	public bool IsOptional;

	public bool ParentSpecific;

	public bool Hypothetical;

	public HashSet<Sensor.FrequencyBand> UsedFrequencies;

	public bool IsJammed;

	public bool IsCommsInMount;

	[ThreadStatic]
	private static StringBuilder _BroadcasterObserver;

	public int OccupiedChannels
	{
		get
		{
			return m_PolicyObserver;
		}
		set
		{
			m_PolicyObserver = value;
		}
	}

	public bool IsSonobuoyLink
	{
		get
		{
			if ((uint)(Type - 9001) <= 4u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsDaisyChainCapable => Flags.DaisyChain;

	internal bool ViewImporter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		if (ParentSpecific && activeUnit_0.IsWeapon && !activeUnit_1.IsWeapon)
		{
			Weapon weapon = (Weapon)activeUnit_0;
			if (weapon.FiringParent != null && weapon.FiringParent != activeUnit_1)
			{
				return false;
			}
		}
		return true;
	}

	public string ToXML(ref HashSet<string> hashSet_0)
	{
		string result = null;
		try
		{
			if (_BroadcasterObserver == null)
			{
				_BroadcasterObserver = new StringBuilder();
			}
			else
			{
				_BroadcasterObserver.Clear();
			}
			_BroadcasterObserver.Append("<CD>");
			_BroadcasterObserver.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					_BroadcasterObserver.Append("</CD>");
					result = _BroadcasterObserver.ToString();
					return result;
				}
				hashSet_0.Add(ObjectID);
			}
			if (DBID == 0 && !string.IsNullOrEmpty(Name))
			{
				string name = Name;
				SQLiteConnection sqliteConnection_ = base.ParentPlatform.ParentScen.DBConnection;
				DBID = DBFunctions.GetCommDeviceID(name, ref sqliteConnection_);
			}
			if (_Status != 0)
			{
				StringBuilder stringBuilder = _BroadcasterObserver.Append("<St>");
				byte status = (byte)_Status;
				stringBuilder.Append(status.ToString()).Append("</St>");
			}
			_BroadcasterObserver.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			_BroadcasterObserver.Append("<OC>").Append(m_PolicyObserver.ToString()).Append("</OC>");
			_BroadcasterObserver.Append("<PS>").Append(ParentSpecific.ToString()).Append("</PS>");
			if (IsJammed)
			{
				_BroadcasterObserver.Append("<IJ>True</IJ>");
			}
			if (base.DamageSeverity != 0)
			{
				_BroadcasterObserver.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			_BroadcasterObserver.Append("</CD>");
			result = _BroadcasterObserver.ToString();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100662", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private CommDevice()
	{
		Flags = default(_Flags);
		ParentSpecific = true;
		UsedFrequencies = new HashSet<Sensor.FrequencyBand>();
		IsCommsInMount = false;
	}

	public static CommDevice FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ActiveUnit activeUnit_0)
	{
		try
		{
			CommDevice commDevice = new CommDevice();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					if (Operators.CompareString(xmlNode.Name, "DBID", TextCompare: false) == 0)
					{
						commDevice.DBID = Conversions.ToInteger(xmlNode.InnerText);
						if (commDevice.DBID > 0)
						{
							commDevice = DBFunctions.GetCommDevice(Conversions.ToInteger(xmlNode.InnerText), ref activeUnit_0);
						}
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
				enumerator2 = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
					if (Operators.CompareString(xmlNode2.Name, "ID", TextCompare: false) == 0)
					{
						commDevice.ObjectID_Set(xmlNode2.InnerText);
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
			if (commDevice.DBID <= 0)
			{
				IEnumerator enumerator3 = null;
				try
				{
					enumerator3 = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator4 = null;
					while (enumerator3.MoveNext())
					{
						XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
						switch (xmlNode3.Name)
						{
						case "Flags":
							try
							{
								enumerator4 = xmlNode3.ChildNodes.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									switch (((XmlNode)enumerator4.Current).Name)
									{
									case "LF_Radio":
										commDevice.Flags.LF_Radio = true;
										break;
									case "Receive_Only":
										commDevice.Flags.Receive_Only = true;
										break;
									case "LOS_Limited":
										commDevice.Flags.LOS_Limited = true;
										break;
									case "Broadcast":
										commDevice.Flags.Broadcast = true;
										break;
									case "UHF_Radio":
										commDevice.Flags.UHF_Radio = true;
										break;
									case "VLF_Radio":
										commDevice.Flags.VLF_Radio = true;
										break;
									case "SHF_Radio":
										commDevice.Flags.SHF_Radio = true;
										break;
									case "HF_Radio":
										commDevice.Flags.HF_Radio = true;
										break;
									case "ELF_Radio":
										commDevice.Flags.ELF_Radio = true;
										break;
									case "Send_Only":
										commDevice.Flags.Send_Only = true;
										break;
									case "Secure":
										commDevice.Flags.Secure = true;
										break;
									case "VHF_Radio":
										commDevice.Flags.VHF_Radio = true;
										break;
									case "MF_Radio":
										commDevice.Flags.MF_Radio = true;
										break;
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
						case "Name":
							commDevice.Name = xmlNode3.InnerText;
							break;
						case "DamageSeverity":
							commDevice.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode3.InnerText);
							break;
						case "ID":
							if (concurrentDictionary_0 == null)
							{
								commDevice.ObjectID_Set(xmlNode3.InnerText);
								break;
							}
							if (!concurrentDictionary_0.ContainsKey(xmlNode3.InnerText))
							{
								commDevice.ObjectID_Set(xmlNode3.InnerText);
								concurrentDictionary_0.TryAdd(commDevice.ObjectID, commDevice);
								break;
							}
							return (CommDevice)concurrentDictionary_0[xmlNode3.InnerText];
						case "Status":
						case "St":
							switch (xmlNode3.InnerText)
							{
							default:
								commDevice._Status = (_ComponentStatus)Conversions.ToByte(xmlNode3.InnerText);
								break;
							case "Operational":
								commDevice._Status = _ComponentStatus.Operational;
								break;
							case "Destroyed":
								commDevice._Status = _ComponentStatus.Destroyed;
								break;
							case "Damaged":
								commDevice._Status = _ComponentStatus.Damaged;
								break;
							}
							break;
						case "IsOptional":
							commDevice.IsOptional = Conversions.ToBoolean(xmlNode3.InnerText);
							break;
						case "IJ":
							commDevice.IsJammed = Conversions.ToBoolean(xmlNode3.InnerText);
							break;
						case "MaxChannels":
							commDevice.MaxChannels = Conversions.ToInteger(xmlNode3.InnerText);
							break;
						case "Range":
							commDevice.Range = XmlConvert.ToDouble(xmlNode3.InnerText);
							break;
						case "Type":
							if (Versioned.IsNumeric(xmlNode3.InnerText))
							{
								commDevice.Type = (CommLinkType)Conversions.ToInteger(xmlNode3.InnerText);
							}
							else
							{
								commDevice.Type = (CommLinkType)Enum.Parse(typeof(CommLinkType), xmlNode3.InnerText, ignoreCase: true);
							}
							break;
						case "OC":
						case "OccupiedChannels":
							commDevice.m_PolicyObserver = Conversions.ToInteger(xmlNode3.InnerText);
							break;
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
			}
			else
			{
				IEnumerator enumerator5 = null;
				try
				{
					enumerator5 = xmlNode_0.ChildNodes.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						XmlNode xmlNode4 = (XmlNode)enumerator5.Current;
						switch (xmlNode4.Name)
						{
						case "PS":
							commDevice.ParentSpecific = Conversions.ToBoolean(xmlNode4.InnerText);
							break;
						case "St":
						case "Status":
							switch (xmlNode4.InnerText)
							{
							default:
								commDevice._Status = (_ComponentStatus)Conversions.ToByte(xmlNode4.InnerText);
								break;
							case "Operational":
								commDevice._Status = _ComponentStatus.Operational;
								break;
							case "Destroyed":
								commDevice._Status = _ComponentStatus.Destroyed;
								break;
							case "Damaged":
								commDevice._Status = _ComponentStatus.Damaged;
								break;
							}
							break;
						case "IJ":
							commDevice.IsJammed = Conversions.ToBoolean(xmlNode4.InnerText);
							break;
						case "DamageSeverity":
							commDevice.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode4.InnerText);
							break;
						case "OccupiedChannels":
						case "OC":
							commDevice.m_PolicyObserver = Conversions.ToInteger(xmlNode4.InnerText);
							break;
						}
					}
				}
				finally
				{
					if (enumerator5 is IDisposable)
					{
						(enumerator5 as IDisposable).Dispose();
					}
				}
			}
			return commDevice;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100663", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public CommDevice(ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		Flags = default(_Flags);
		ParentSpecific = true;
		UsedFrequencies = new HashSet<Sensor.FrequencyBand>();
		IsCommsInMount = false;
	}

	public CommDevice(ActiveUnit activeUnit_0, Scenario scenario_0, int int_0, string string_0, CommLinkType commLinkType_0, double double_0, int int_1, bool bool_0 = false)
		: base(activeUnit_0)
	{
		Flags = default(_Flags);
		ParentSpecific = true;
		UsedFrequencies = new HashSet<Sensor.FrequencyBand>();
		IsCommsInMount = false;
		DBID = int_0;
		Name = string_0;
		Type = commLinkType_0;
		Range = double_0;
		MaxChannels = int_1;
		IsOptional = bool_0;
		CommDevice commDevice_ = this;
		DBFunctions.GetCommDeviceFlags(ref commDevice_, scenario_0.DBConnection);
	}

	internal bool ValidateImporter()
	{
		int type = (int)Type;
		if (type != 16 && type != 4011 && type != 5006 && type != 8002 && type != 9001 && type != 9002)
		{
			if (type <= 10000)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	internal bool LoginImporter()
	{
		if ((uint)(Type - 2001) <= 9u)
		{
			return true;
		}
		return false;
	}

	public override void vmethod_0(float float_0)
	{
		if (Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		float num = ((float_0 < 0.1f) ? 0.05f : ((float_0 < 0.25f) ? 0.15f : ((float_0 < 0.5f) ? 0.3f : ((float_0 < 0.75f) ? 0.5f : 0.75f))));
		if (Status != 0)
		{
			num /= 2f;
		}
		if ((double)num < 0.05)
		{
			num = 0.05f;
		}
		if ((double)num > 0.95)
		{
			num = 0.95f;
		}
		float num2 = num;
		float num3 = (float)((double)num - 0.1);
		float num4 = (float)((double)num - 0.2);
		float num5 = (float)((double)num - 0.3);
		double num6 = GameGeneral.LockRandom_0.NextDouble();
		if (num6 < (double)num5)
		{
			Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer(base.ParentPlatform));
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 一个通信链路中断", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
		}
		else if (num6 < (double)num4)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了严重的毁伤。", base.ParentPlatform.Name + " 一个通信链路受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < (double)num3)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了中度毁伤。", base.ParentPlatform.Name + " 一个通信链路受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < (double)num2)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "受轻伤。", base.ParentPlatform.Name + " 一个通信链路受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}
}
