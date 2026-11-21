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

public class ActiveUnit_CommStuff
{
	public enum ReasonForGoingOffGrid
	{
		None,
		ChangeOfInternalStatus,
		AllCommDevicesDisabled,
		DivingDeep
	}

	protected ActiveUnit myUnit;

	protected CommLink[] _CommLinksEstablished;

	public float CommsCheckCountdown;

	protected bool? _IsConnectedToSideNetwork;

	protected bool _InternalCommsStatus;

	protected bool _HasBeenSummonedToReestablishComms;

	public ReasonForGoingOffGrid ReasonForBeingOffGrid
	{
		get
		{
			if (_InternalCommsStatus)
			{
				if (myUnit.IsSubmarine && myUnit.GetCurrentAltitude() < (float)Submarine.CommsEstablishDepth && CommsDeviceAvailable)
				{
					return ReasonForGoingOffGrid.DivingDeep;
				}
				return ReasonForGoingOffGrid.AllCommDevicesDisabled;
			}
			return ReasonForGoingOffGrid.ChangeOfInternalStatus;
		}
	}

	public virtual bool IsConnectedToSideNetwork
	{
		get
		{
			if (!_IsConnectedToSideNetwork.HasValue)
			{
				_IsConnectedToSideNetwork = true;
			}
			return _IsConnectedToSideNetwork.Value;
		}
	}

	public CommLink[] CommLinksEstablished_ReadOnly => _CommLinksEstablished;

	public bool HasBeenSummonedToReestablishComms
	{
		get
		{
			return _HasBeenSummonedToReestablishComms;
		}
		set
		{
			_HasBeenSummonedToReestablishComms = value;
		}
	}

	public bool CommsDeviceAvailable
	{
		get
		{
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			if (comms_ReadOnly.Count() == 0)
			{
				return false;
			}
			if (comms_ReadOnly.Where((CommDevice theCD) => !theCD.ValidateImporter()).Count() == 0)
			{
				return false;
			}
			CommDevice[] array = comms_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					CommDevice commDevice = array[num];
					if (!commDevice.ValidateImporter() && commDevice.Status == PlatformComponent._ComponentStatus.Operational)
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
	}

	public bool CommJamUnitsAreAffectingMe
	{
		get
		{
			try
			{
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100240", "");
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

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			if (_CommLinksEstablished.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("CLE");
				CommLink[] array = _CommLinksEstablished.ToArray();
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].ToXML(ref xmlWriter_0, ref hashSet_0, myUnit.ParentScen);
				}
				xmlWriter_0.WriteEndElement();
			}
			bool? isConnectedToSideNetwork = _IsConnectedToSideNetwork;
			if (((!isConnectedToSideNetwork) ?? isConnectedToSideNetwork).GetValueOrDefault())
			{
				xmlWriter_0.WriteElementString("OOC", "True");
			}
			if (!_InternalCommsStatus)
			{
				xmlWriter_0.WriteElementString("ICS", "False");
			}
			if (_HasBeenSummonedToReestablishComms)
			{
				xmlWriter_0.WriteElementString("HBS", "True");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100100", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_CommStuff FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_CommStuff activeUnit_CommStuff = new ActiveUnit_CommStuff();
			activeUnit_CommStuff.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "OOC":
						activeUnit_CommStuff._IsConnectedToSideNetwork = !Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ICS":
						activeUnit_CommStuff._InternalCommsStatus = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "HBS":
						activeUnit_CommStuff._HasBeenSummonedToReestablishComms = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "CLE":
					case "CommLinksEstablished":
					{
						activeUnit_CommStuff._CommLinksEstablished = new CommLink[xmlNode.ChildNodes.Count - 1 + 1];
						int num = xmlNode.ChildNodes.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[i];
							CommLink commLink = CommLink.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0);
							activeUnit_CommStuff._CommLinksEstablished[i] = commLink;
						}
						break;
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
			return activeUnit_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100101", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_CommStuff result = new ActiveUnit_CommStuff();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private ActiveUnit_CommStuff()
	{
		_CommLinksEstablished = new CommLink[0];
		_InternalCommsStatus = true;
		_HasBeenSummonedToReestablishComms = false;
	}

	public ActiveUnit_CommStuff(ref ActiveUnit activeUnit_0)
	{
		_CommLinksEstablished = new CommLink[0];
		_InternalCommsStatus = true;
		_HasBeenSummonedToReestablishComms = false;
		myUnit = activeUnit_0;
	}

	[SpecialName]
	public void SetIsConnectedToSideNetwork(ReasonForGoingOffGrid reasonForGoingOffGrid_0, bool bool_0)
	{
		bool? isConnectedToSideNetwork = _IsConnectedToSideNetwork;
		bool num = isConnectedToSideNetwork.HasValue && isConnectedToSideNetwork.Value != bool_0;
		_IsConnectedToSideNetwork = bool_0;
		if (!num)
		{
			return;
		}
		if (bool_0)
		{
			_InternalCommsStatus = true;
			myUnit.Sensory.RejoinCommsGrid();
			return;
		}
		if (reasonForGoingOffGrid_0 == ReasonForGoingOffGrid.ChangeOfInternalStatus)
		{
			_InternalCommsStatus = false;
		}
		myUnit.Sensory.StartDic();
		myUnit.Sensory.AssetDic();
		switch (reasonForGoingOffGrid_0)
		{
		case ReasonForGoingOffGrid.ChangeOfInternalStatus:
			myUnit.AddMessage(myUnit.Name + "已经放弃了通讯网络！ （网络攻击或上帝行为）", myUnit.Name + " 已断开通信连接", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			break;
		case ReasonForGoingOffGrid.AllCommDevicesDisabled:
			myUnit.AddMessage(myUnit.Name + "已经放弃了通讯网络！ （所有通讯设备无法使用）", myUnit.Name + " 已断开通信连接", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			break;
		case ReasonForGoingOffGrid.DivingDeep:
			myUnit.AddMessage(myUnit.Name + " 已断开通信网络（深度下沉）", myUnit.Name + " 已断开通信连接", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			break;
		}
	}

	public void DropCommLink(CommLink commLink_0)
	{
		ArrayExtensions.Remove(ref _CommLinksEstablished, commLink_0);
	}

	public void CheckForCommsDisruption()
	{
		if (myUnit.IsSubmarine && myUnit.GetCurrentAltitude() < -40f && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
		{
			return;
		}
		CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
		if (comms_ReadOnly.Count() == 0 || comms_ReadOnly.Where((CommDevice theCD) => !theCD.ValidateImporter()).Count() == 0)
		{
			return;
		}
		bool flag = false;
		CommDevice[] array = comms_ReadOnly;
		CommDevice[] array2 = array;
		foreach (CommDevice commDevice in array2)
		{
			if (!commDevice.ValidateImporter() && commDevice.Status == PlatformComponent._ComponentStatus.Operational)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if (_InternalCommsStatus)
			{
				SetIsConnectedToSideNetwork(ReasonForGoingOffGrid.None, bool_0: true);
			}
		}
		else if (_InternalCommsStatus)
		{
			SetIsConnectedToSideNetwork(ReasonForGoingOffGrid.AllCommDevicesDisabled, bool_0: false);
		}
	}

	public void CheckForCommsJamming()
	{
		CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
		if (comms_ReadOnly.Count() == 0 || comms_ReadOnly.Where((CommDevice theCD) => !theCD.ValidateImporter()).Count() == 0)
		{
			return;
		}
		List<ActiveUnit> unitsBeenJammed = GetUnitsBeenJammed();
		CommDevice[] array;
		if (unitsBeenJammed.Count <= 0)
		{
			array = comms_ReadOnly;
			CommDevice[] array3 = array;
			foreach (CommDevice commDevice in array3)
			{
				if (commDevice.Status == PlatformComponent._ComponentStatus.Operational && commDevice.Type != CommDevice.CommLinkType.Land_Line)
				{
					commDevice.IsJammed = false;
				}
			}
		}
		else
		{
			HashSet<CommDevice> hashSet = new HashSet<CommDevice>();
			foreach (ActiveUnit item in unitsBeenJammed)
			{
				bool? flag = null;
				float? num = null;
				Sensor[] array2 = item.Sensors_ReadOnly();
				Sensor[] array4 = array2;
				foreach (Sensor sensor in array4)
				{
					if (!sensor.IsActive || !sensor.IsCommsJammer)
					{
						continue;
					}
					array = comms_ReadOnly;
					CommDevice[] array5 = array;
					foreach (CommDevice commDevice2 in array5)
					{
						if (commDevice2.Status != 0 || commDevice2.Type == CommDevice.CommLinkType.Land_Line)
						{
							continue;
						}
						if (!num.HasValue)
						{
							num = Module_Unit.RangeToUnit_Slant(myUnit, item);
						}
						if (!RadarModel.VisitStub(commDevice2, sensor, num.Value))
						{
							if (!sensor.IsOTH && !flag.HasValue)
							{
								flag = Module_Unit.Has_Radar_LOS_ToUnit(myUnit, sensor, item, ref myUnit.ParentScen);
							}
							if (sensor.IsOTH || flag.GetValueOrDefault())
							{
								hashSet.Add(commDevice2);
							}
						}
					}
				}
			}
			array = comms_ReadOnly;
			CommDevice[] array6 = array;
			foreach (CommDevice commDevice3 in array6)
			{
				if (commDevice3.Status == PlatformComponent._ComponentStatus.Operational && commDevice3.Type != CommDevice.CommLinkType.Land_Line)
				{
					if (hashSet.Contains(commDevice3))
					{
						commDevice3.IsJammed = true;
					}
					else
					{
						commDevice3.IsJammed = false;
					}
				}
			}
		}
		bool flag2 = false;
		array = comms_ReadOnly;
		CommDevice[] array7 = array;
		foreach (CommDevice commDevice4 in array7)
		{
			if (!commDevice4.ValidateImporter() && commDevice4.Status == PlatformComponent._ComponentStatus.Operational && !commDevice4.IsJammed)
			{
				flag2 = true;
				break;
			}
		}
		if (flag2)
		{
			if (_InternalCommsStatus)
			{
				SetIsConnectedToSideNetwork(ReasonForGoingOffGrid.None, bool_0: true);
			}
		}
		else if (_InternalCommsStatus)
		{
			SetIsConnectedToSideNetwork(ReasonForGoingOffGrid.AllCommDevicesDisabled, bool_0: false);
		}
	}

	[SpecialName]
	private List<ActiveUnit> GetUnitsBeenJammed()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming))
			{
				if (myUnit.IsWeapon && ((Weapon)myUnit).Flags.HomeOnJam)
				{
					return list;
				}
				Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (side == null || myUnit.GetUnitSide() == null || side == myUnit.GetUnitSide() || Module_Side.IsAlliedWithThisSide(myUnit.GetUnitSide(), side))
					{
						continue;
					}
					for (int i = side.GetUnitsEngagedInOECM(bool_0: false).Count - 1; i >= 0; i += -1)
					{
						ActiveUnit activeUnit = side.GetUnitsEngagedInOECM(bool_0: false)[i];
						if (RateClient(activeUnit))
						{
							list.Add(activeUnit);
						}
					}
				}
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100240", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	private bool RateClient(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(activeUnit_0))
		{
			return false;
		}
		try
		{
			bool flag = false;
			Sensor[] sensors_Cached = activeUnit_0.Sensors_Cached;
			bool flag2 = false;
			for (int i = sensors_Cached.Length - 1; i >= 0; i += -1)
			{
				Sensor sensor = sensors_Cached[i];
				if (!sensor.IsCommsJammer)
				{
					continue;
				}
				if (sensor.IsOTH)
				{
					flag2 = true;
				}
				if (!sensor.IsActive || !sensor.TargetIsWithinCoverageArc(myUnit))
				{
					continue;
				}
				for (int j = myUnit.Comms_ReadOnly.Count() - 1; j >= 0; j += -1)
				{
					CommDevice commDevice_ = myUnit.Comms_ReadOnly[j];
					if (sensor.GetCanJamThisCommDevice(commDevice_))
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
				if (!flag2 && !Module_Unit.Has_Radar_LOS_ToUnit(myUnit, null, activeUnit_0, ref myUnit.ParentScen))
				{
					return false;
				}
				return true;
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

	public virtual void ClearAllCommLinks()
	{
		try
		{
			_CommLinksEstablished = new CommLink[0];
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			for (int i = 0; i < comms_ReadOnly.Length; i = checked(i + 1))
			{
				comms_ReadOnly[i].OccupiedChannels = 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100103", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool FlushClient(ActiveUnit activeUnit_0)
	{
		try
		{
			int num = CommLinksEstablished_ReadOnly.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					CommLink commLink = CommLinksEstablished_ReadOnly[num];
					if (!Information.IsNothing(commLink) && commLink.CommPartner == activeUnit_0)
					{
						break;
					}
					num += -1;
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
			exception_?.Data.Add("Error at 100104", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ForgotClient(CommLink commLink_0)
	{
		try
		{
			if ((double)Module_Unit.RangeToUnit_Horiz(myUnit, commLink_0.CommPartner) <= commLink_0.DeviceUsed.Range && myUnit.ParentScen.ActiveUnits.ContainsKey(commLink_0.CommPartner.ObjectID))
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100105", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual bool EstablishCommLinkToUnit(CommDevice commDevice_0, ActiveUnit activeUnit_0, bool bool_0)
	{
		if (Information.IsNothing(commDevice_0))
		{
			commDevice_0 = CommDeviceToConnectToThisUnit(null, activeUnit_0);
		}
		if (Information.IsNothing(commDevice_0))
		{
			return false;
		}
		try
		{
			ArrayExtensions.Add(ref _CommLinksEstablished, new CommLink(ref activeUnit_0, ref commDevice_0));
			ArrayExtensions.Add(ref activeUnit_0.CommStuff._CommLinksEstablished, new CommLink(ref myUnit, ref commDevice_0));
			commDevice_0.OccupiedChannels++;
			CommDevice[] comms_ReadOnly = activeUnit_0.Comms_ReadOnly;
			CommDevice[] array = comms_ReadOnly;
			foreach (CommDevice commDevice in array)
			{
				if ((!bool_0 || !commDevice_0.ParentSpecific || !myUnit.IsWeapon || activeUnit_0 == ((Weapon)myUnit).FiringParent || (commDevice.IsDaisyChainCapable && ((Weapon)myUnit).CommStuff.ExcludeDescriptor(activeUnit_0, bool_0: false))) && commDevice.Type == commDevice_0.Type && (commDevice.MaxChannels == 0 || commDevice.MaxChannels > commDevice.OccupiedChannels))
				{
					commDevice.OccupiedChannels++;
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100106", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public CommDevice CommDeviceToConnectToThisUnit(CommDevice[] commDevice_0, ActiveUnit activeUnit_0, bool bool_0 = false)
	{
		List<CommDevice> list = new List<CommDevice>();
		try
		{
			if (activeUnit_0 != null && activeUnit_0.IsOperating())
			{
				if (!activeUnit_0.IsBeingDestroyed)
				{
					if (commDevice_0 == null)
					{
						commDevice_0 = myUnit.Comms_ReadOnly;
					}
					double num = Module_Unit.RangeToUnit_Horiz_Angular(myUnit, activeUnit_0);
					if (double.IsNaN(num))
					{
						num = 0.0;
					}
					bool flag = myUnit.IsWeapon && activeUnit_0.IsWeapon;
					CommDevice[] array = commDevice_0;
					bool? flag2 = null;
					bool? flag3 = null;
					CommDevice[] array2 = array;
					CommDevice[] array5 = array2;
					foreach (CommDevice commDevice in array5)
					{
						if (commDevice.Status != 0 || (flag && !commDevice.IsDaisyChainCapable) || !commDevice.ViewImporter(myUnit, activeUnit_0) || (!bool_0 && commDevice.MaxChannels > 0 && commDevice.OccupiedChannels == commDevice.MaxChannels) || commDevice.IsJammed || (!activeUnit_0.IsWeapon && !myUnit.IsWeapon && commDevice.ValidateImporter()) || (!activeUnit_0.IsSatellite && !myUnit.IsSatellite && commDevice.LoginImporter()))
						{
							continue;
						}
						CommDevice[] array3 = activeUnit_0.Comms_ReadOnly;
						if (activeUnit_0.GetParentGroup() != null && (activeUnit_0.IsMobileGroundUnit || activeUnit_0.IsFacility) && myUnit.SettledTime > 120f)
						{
							foreach (KeyValuePair<string, ActiveUnit> unit in activeUnit_0.GetParentGroup().Units)
							{
								if (activeUnit_0 != unit.Value && (unit.Value.IsMobileGroundUnit || unit.Value.IsFacility) && Module_Unit.RangeToUnit_Slant(activeUnit_0, unit.Value) < 5f && unit.Value.SettledTime > 120f)
								{
									array3 = array3.Concat(unit.Value.Comms_ReadOnly).ToArray();
								}
							}
						}
						CommDevice[] array4 = array3;
						CommDevice[] array6 = array4;
						foreach (CommDevice commDevice2 in array6)
						{
							if ((flag && !commDevice2.IsDaisyChainCapable) || commDevice2.Type != commDevice.Type || commDevice2.IsJammed || (!(commDevice2.MaxChannels > commDevice2.OccupiedChannels || bool_0) && commDevice2.MaxChannels != 0))
							{
								continue;
							}
							double num2 = Math2.TestClass((float)commDevice.Range);
							if (!(num <= num2))
							{
								continue;
							}
							if (commDevice.Flags.LOS_Limited)
							{
								bool value;
								if (myUnit.IsTorpedo)
								{
									if (!flag2.HasValue)
									{
										ActiveUnit unit_ = myUnit;
										ref Scenario parentScen = ref myUnit.ParentScen;
										bool bool_ = false;
										flag2 = Module_Unit.Has_Sonar_LOS_ToUnit(unit_, activeUnit_0, ref parentScen, ref bool_);
									}
									value = flag2.Value;
								}
								else
								{
									if (!flag3.HasValue)
									{
										flag3 = Module_Unit.Has_Radar_LOS_ToUnit(myUnit, null, activeUnit_0, ref myUnit.ParentScen);
									}
									value = flag3.Value;
								}
								if (!value)
								{
									continue;
								}
							}
							list.Add(commDevice);
						}
					}
					switch (list.Count)
					{
					default:
					{
						double num3 = 20000.0;
						CommDevice result = null;
						foreach (CommDevice item in list)
						{
							if (item.Range < num3)
							{
								num3 = item.Range;
								result = item;
							}
						}
						return result;
					}
					case 1:
						return list[0];
					case 0:
						return null;
					}
				}
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100107", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public CommDevice CommDevicePresentToConnectToThisUnit(CommDevice[] commDevice_0, ActiveUnit activeUnit_0)
	{
		List<CommDevice> list = new List<CommDevice>();
		try
		{
			if (activeUnit_0.IsOperating())
			{
				if (activeUnit_0.IsBeingDestroyed)
				{
					return null;
				}
				if (Information.IsNothing(commDevice_0))
				{
					commDevice_0 = myUnit.Comms_ReadOnly;
				}
				if (myUnit.IsWeapon && activeUnit_0.IsWeapon)
				{
					return null;
				}
				CommDevice[] array = commDevice_0;
				CommDevice[] array2 = array;
				foreach (CommDevice commDevice in array2)
				{
					if (commDevice.Status != 0 || (!activeUnit_0.IsWeapon && !myUnit.IsWeapon && commDevice.ValidateImporter()) || (!activeUnit_0.IsSatellite && !myUnit.IsSatellite && commDevice.LoginImporter()))
					{
						continue;
					}
					CommDevice[] comms_ReadOnly = activeUnit_0.Comms_ReadOnly;
					CommDevice[] array3 = comms_ReadOnly;
					foreach (CommDevice commDevice2 in array3)
					{
						if (commDevice2.Type == commDevice.Type && commDevice2.Status == PlatformComponent._ComponentStatus.Operational)
						{
							list.Add(commDevice);
						}
					}
				}
				switch (list.Count)
				{
				default:
				{
					double num = 20000.0;
					CommDevice result = null;
					foreach (CommDevice item in list)
					{
						if (item.Range < num)
						{
							num = item.Range;
							result = item;
						}
					}
					return result;
				}
				case 1:
					return list[0];
				case 0:
					return null;
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100107", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	protected bool CommChannelsAvailable()
	{
		try
		{
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < comms_ReadOnly.Length)
				{
					CommDevice commDevice = comms_ReadOnly[num];
					if (commDevice.OccupiedChannels < commDevice.MaxChannels)
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
			exception_?.Data.Add("Error at 100108", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	protected void DisconnectCommLinkToUnit(ActiveUnit activeUnit_0, bool bool_0)
	{
		try
		{
			for (int i = CommLinksEstablished_ReadOnly.Length - 1; i >= 0; i += -1)
			{
				CommLink commLink = CommLinksEstablished_ReadOnly[i];
				if (!Information.IsNothing(commLink) && commLink.CommPartner == activeUnit_0)
				{
					if (bool_0)
					{
						commLink.CommPartner.CommStuff.DisconnectCommLinkToUnit(myUnit, bool_0: false);
					}
					if (commLink.DeviceUsed != null && commLink.DeviceUsed.OccupiedChannels > 0)
					{
						commLink.DeviceUsed.OccupiedChannels--;
					}
					DropCommLink(commLink);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100109", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
