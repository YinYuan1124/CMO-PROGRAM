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

public sealed class Submarine_Weaponry : ActiveUnit_Weaponry
{
	public enum TorpedoWireBreakReason
	{
		None,
		ExcessiveTurnRate,
		ExcessiveSpeed
	}

	private Submarine m_ResolverProxy;

	public override Weapon PrimaryAttackWeapon_Default
	{
		get
		{
			List<WeaponRec> list = AllDistinctWeaponsAboard_Default_WeaponRecs(bool_1: false);
			List<Weapon> list2 = new List<Weapon>();
			foreach (WeaponRec item in list)
			{
				if (item.DefaultLoad == 0)
				{
					continue;
				}
				Weapon referenceWeapon = item.GetReferenceWeapon(myUnit.ParentScen);
				if ((uint)(GetParentPlatform().Type - 2004) <= 3u)
				{
					if (referenceWeapon.IsMissile)
					{
						list2.Add(referenceWeapon);
					}
				}
				else if (referenceWeapon.IsTorpedo)
				{
					list2.Add(referenceWeapon);
				}
			}
			if (list2.Count <= 0)
			{
				return null;
			}
			return list2.OrderByDescending((Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public override Weapon PrimaryAttackWeapon_Actual
	{
		get
		{
			List<Weapon> list = new List<Weapon>();
			foreach (Weapon item in AllDistinctWeaponsAboard_Actual())
			{
				if ((uint)(GetParentPlatform().Type - 2004) <= 3u)
				{
					if (item.IsMissile)
					{
						list.Add(item);
					}
				}
				else if (item.IsTorpedo)
				{
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list.OrderByDescending((Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public override Weapon PrimaryDefenceWeapon_Actual
	{
		get
		{
			List<Weapon> list = (from theW in AllDistinctWeaponsAboard_Actual()
				where theW.IsTorpedo
				select theW).ToList();
			if (list.Count <= 0)
			{
				return null;
			}
			return list.OrderByDescending((Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public override Weapon PrimaryDefenceWeapon_Default
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
					if (referenceWeapon.IsTorpedo)
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

	public bool IsGuidingWireTorpedoes
	{
		get
		{
			if (myUnit != null && myUnit.ParentScen != null && myUnit.ParentScen.GuidedWeaponsInAir != null)
			{
				foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir.ToList())
				{
					if (item.IsTorpedo && item.FiringParent == myUnit && item.DataLinkParent == myUnit)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	[SpecialName]
	private Submarine GetParentPlatform()
	{
		if (Information.IsNothing(m_ResolverProxy))
		{
			m_ResolverProxy = (Submarine)myUnit;
		}
		return m_ResolverProxy;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Submarine_Weaponry");
			if (WeaponAssignments.Count > 0)
			{
				xmlWriter_0.WriteStartElement("WeaponAssignments");
				foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
				{
					weaponAssignment.ToXML(ref xmlWriter_0, ref hashSet_0);
				}
				xmlWriter_0.WriteEndElement();
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
			exception_?.Data.Add("Error at 100840", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Submarine_Weaponry FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Submarine_Weaponry submarine_Weaponry = new Submarine_Weaponry(ref activeUnit_0);
			submarine_Weaponry.myUnit = activeUnit_0;
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
									submarine_Weaponry.WeaponAssignments.Add(weaponAssignment);
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
					case "IDLZ":
						submarine_Weaponry.bool_0 = true;
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
			return submarine_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100841", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Submarine_Weaponry result = new Submarine_Weaponry(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Submarine_Weaponry(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}

	public void BreakTorpedoWires(TorpedoWireBreakReason torpedoWireBreakReason_0)
	{
		foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
		{
			if (item.IsTorpedo && item.FiringParent == myUnit && item.DataLinkParent == myUnit)
			{
				switch (torpedoWireBreakReason_0)
				{
				case TorpedoWireBreakReason.ExcessiveSpeed:
					myUnit.AddMessage(myUnit.Name + "拉断了引导线" + item.Name + "（速度过快）", "鱼雷线缆损坏", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					break;
				case TorpedoWireBreakReason.ExcessiveTurnRate:
					myUnit.AddMessage(myUnit.Name + "拉断了引导线" + item.Name + "（转弯率过高）", "鱼雷线缆损坏", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					break;
				}
				item.StopReponse(bool_0: false, bool_1: true, bool_2: true);
			}
		}
	}
}
