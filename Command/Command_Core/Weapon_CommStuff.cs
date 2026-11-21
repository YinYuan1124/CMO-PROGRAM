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

public sealed class Weapon_CommStuff : ActiveUnit_CommStuff
{
	[CompilerGenerated]
	private sealed class CallbackSetter
	{
		public double Local_MyLat;

		public double Local_myLon;

		internal double InterruptInterruptibleParam(ActiveUnit theUnit)
		{
			return Geodesic_Haversine.Distance_Horiz_Angular_Approx_Rad(Local_MyLat, Local_myLon, theUnit.GetLatitude(), theUnit.GetLongitude());
		}
	}

	private Weapon _SerializerReader;

	public bool CanSendDataToParent
	{
		get
		{
			if (Information.IsNothing(GetParentWeapon().DataLinkParent))
			{
				return false;
			}
			if (Information.IsNothing(CommLinkToParent))
			{
				return false;
			}
			return !CommLinkToParent.DeviceUsed.Flags.Receive_Only;
		}
	}

	public CommLink CommLinkToParent
	{
		get
		{
			CommLink[] commLinksEstablished_ReadOnly = base.CommLinksEstablished_ReadOnly;
			CommLink[] array = commLinksEstablished_ReadOnly;
			foreach (CommLink commLink in array)
			{
				if (commLink.CommPartner == GetParentWeapon().DataLinkParent)
				{
					return commLink;
				}
			}
			return null;
		}
	}

	[SpecialName]
	private Weapon GetParentWeapon()
	{
		if (Information.IsNothing(_SerializerReader))
		{
			_SerializerReader = (Weapon)myUnit;
		}
		return _SerializerReader;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		checked
		{
			try
			{
				xmlWriter_0.WriteStartElement("Weapon_CommStuff");
				CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
				for (int i = 0; i < comms_ReadOnly.Length; i++)
				{
					comms_ReadOnly[i].ParentPlatform = myUnit;
				}
				xmlWriter_0.WriteStartElement("CLE");
				CommLink[] commLinksEstablished_ReadOnly = base.CommLinksEstablished_ReadOnly;
				for (int j = 0; j < commLinksEstablished_ReadOnly.Length; j++)
				{
					commLinksEstablished_ReadOnly[j].ToXML(ref xmlWriter_0, ref hashSet_0, myUnit.ParentScen);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100973", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public new static Weapon_CommStuff FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Weapon_CommStuff weapon_CommStuff = new Weapon_CommStuff(ref activeUnit_0);
			weapon_CommStuff.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string name = xmlNode.Name;
					if (Operators.CompareString(name, "CommLinksEstablished", TextCompare: false) == 0 || Operators.CompareString(name, "CLE", TextCompare: false) == 0)
					{
						weapon_CommStuff._CommLinksEstablished = new CommLink[xmlNode.ChildNodes.Count - 1 + 1];
						int num = xmlNode.ChildNodes.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[i];
							CommLink commLink = CommLink.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0);
							weapon_CommStuff._CommLinksEstablished[i] = commLink;
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
			return weapon_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100974", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Weapon_CommStuff result = new Weapon_CommStuff(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Weapon_CommStuff(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void ClearAllCommLinks()
	{
		if (CommsCheckCountdown <= 0f)
		{
			base.ClearAllCommLinks();
		}
	}

	public override bool EstablishCommLinkToUnit(CommDevice commDevice_0, ActiveUnit activeUnit_0, bool bool_0)
	{
		bool num = base.EstablishCommLinkToUnit(commDevice_0, activeUnit_0, bool_0);
		if (num)
		{
			GetParentWeapon().DataLinkParent = activeUnit_0;
		}
		return num;
	}

	internal bool ExcludeDescriptor(ActiveUnit activeUnit_0, bool bool_0)
	{
		if (activeUnit_0.IsWeapon && activeUnit_0.DBID == GetParentWeapon().DBID)
		{
			Weapon weapon = (Weapon)activeUnit_0;
			if (weapon.DataLinkParent != null)
			{
				ActiveUnit dataLinkParent = weapon.DataLinkParent;
				while (dataLinkParent != null && dataLinkParent.IsWeapon)
				{
					dataLinkParent = ((Weapon)dataLinkParent).DataLinkParent;
				}
				if (dataLinkParent != null)
				{
					if (!bool_0)
					{
						return dataLinkParent == GetParentWeapon().FiringParent;
					}
					return true;
				}
			}
		}
		return false;
	}

	public void CheckCommsAndDataLinks(float float_0, List<ActiveUnit> list_0)
	{
		try
		{
			Weapon parentWeapon = GetParentWeapon();
			ActiveUnit activeUnit = parentWeapon.DataLinkParent;
			if (activeUnit == null)
			{
				base.ClearAllCommLinks();
			}
			else
			{
				bool flag = false;
				if (activeUnit.IsDestroyed)
				{
					flag = true;
				}
				else if (activeUnit.IsOperating())
				{
					if (activeUnit.IsWeapon && ((Weapon)activeUnit).DataLinkParent == null)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					DisconnectCommLinkToUnit(activeUnit, bool_0: true);
					parentWeapon.DataLinkParent = null;
					activeUnit = null;
				}
			}
			CommsCheckCountdown -= float_0;
			if (!parentWeapon.IsAAW & (parentWeapon.MaxRange_NoTargetType > 20f))
			{
				if (!(CommsCheckCountdown <= 0f))
				{
					return;
				}
				CommsCheckCountdown = GameGeneral.LockRandom_0.Next(1, 16);
			}
			if (CommsCheckCountdown < 0f)
			{
				CommsCheckCountdown = 0f;
			}
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			if (comms_ReadOnly.Length == 0 || !CommChannelsAvailable())
			{
				return;
			}
			if (activeUnit == null)
			{
				if (parentWeapon.FiringParent != null)
				{
					CommDevice commDevice = CommDeviceToConnectToThisUnit(comms_ReadOnly, parentWeapon.FiringParent);
					if (commDevice != null)
					{
						EstablishCommLinkToUnit(commDevice, parentWeapon.FiringParent, GetParentWeapon().FiringParent != activeUnit);
					}
				}
			}
			else
			{
				bool flag2 = CommLinkToParent != null;
				CommDevice commDevice2 = CommDeviceToConnectToThisUnit(comms_ReadOnly, activeUnit, bool_0: true);
				if (commDevice2 == null)
				{
					DisconnectCommLinkToUnit(activeUnit, bool_0: true);
					parentWeapon.DataLinkParent = null;
					activeUnit = null;
				}
				else if (!flag2)
				{
					EstablishCommLinkToUnit(commDevice2, activeUnit, GetParentWeapon().FiringParent != activeUnit);
				}
			}
			if (activeUnit != null)
			{
				return;
			}
			bool flag3 = comms_ReadOnly.Where((CommDevice theCD) => theCD.IsDaisyChainCapable).Any();
			bool flag4 = comms_ReadOnly.Where((CommDevice theCD) => !theCD.ParentSpecific).Any();
			if (!(flag3 || flag4))
			{
				return;
			}
			double num = comms_ReadOnly.Select((CommDevice theCD) => theCD.Range).Max();
			Math2.TestClass(num);
			double Local_MyLat = parentWeapon.GetLatitude();
			double Local_myLon = parentWeapon.GetLongitude();
			if (list_0 == null)
			{
				list_0 = myUnit.GetUnitSide().GetFriendlyUnits_OperativeOnly(myUnit.ParentScen);
			}
			List<ActiveUnit> list = new List<ActiveUnit>(list_0.Count);
			foreach (ActiveUnit item in list_0)
			{
				if (item != myUnit)
				{
					if (flag3 && ExcludeDescriptor(item, flag4))
					{
						list.Add(item);
					}
					else if (!item.IsWeapon && (flag4 || item == parentWeapon.FiringParent) && (parentWeapon.Type != Weapon._WeaponType.Sonobuoy || !item.IsFacility))
					{
						list.Add(item);
					}
				}
			}
			List<ActiveUnit> list2 = new List<ActiveUnit>(Geodesic_Haversine.UnitsWithinDistanceFromPoint(list, bool_0: true, Local_MyLat, Local_myLon, num));
			if (list2.Count > 1)
			{
				list2 = list2.OrderBy((ActiveUnit theUnit) => Geodesic_Haversine.Distance_Horiz_Angular_Approx_Rad(Local_MyLat, Local_myLon, theUnit.GetLatitude(), theUnit.GetLongitude())).ToList();
			}
			foreach (ActiveUnit item2 in list2)
			{
				CommDevice commDevice3 = CommDeviceToConnectToThisUnit(comms_ReadOnly, item2);
				if (commDevice3 != null)
				{
					base.ClearAllCommLinks();
					if (parentWeapon.Type == Weapon._WeaponType.Sonobuoy)
					{
						EstablishCommLinkToUnit(commDevice3, item2, bool_0: false);
					}
					else
					{
						EstablishCommLinkToUnit(commDevice3, item2, bool_0: true);
					}
					break;
				}
			}
			list2 = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100975", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
