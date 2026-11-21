using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FiringProposal : ScenarioObject
{
	[CompilerGenerated]
	private sealed class UtilsComparator
	{
		public XmlNode Local_theChild;

		internal bool PopInterruptibleField(ActiveUnit theU)
		{
			return Operators.CompareString(theU.ObjectID, Local_theChild.InnerText, TextCompare: false) == 0;
		}
	}

	public int int_0;

	public Contact Target;

	public DateTime ETA;

	public double Distance;

	public bool ManualFire;

	private Weapon interceptorClient;

	public Module_Unit.Unit FiringUnit;

	public int? QuantityToFire;

	public int? QuantityAvailable;

	public int? ShooterQuantity;

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("FiringProposal");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("WeaponDBID", int_0.ToString());
			xmlWriter_0.WriteElementString("QuantityToFire", QuantityToFire.ToString());
			xmlWriter_0.WriteElementString("QuantityAvailable", QuantityAvailable.ToString());
			xmlWriter_0.WriteElementString("Target", Target.ObjectID);
			xmlWriter_0.WriteElementString("ETA", ETA.ToBinary().ToString());
			xmlWriter_0.WriteElementString("Distance", Distance.ToString());
			xmlWriter_0.WriteElementString("ManualFire", ManualFire.ToString());
			xmlWriter_0.WriteElementString("FiringUnit", FiringUnit.ObjectID.ToString());
			xmlWriter_0.WriteElementString("ShooterQuantity", FiringUnit.ObjectID.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 7345554", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static FiringProposal FromXML(ref XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			FiringProposal firingProposal = new FiringProposal();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode Local_theChild = (XmlNode)enumerator.Current;
					switch (Local_theChild.Name)
					{
					case "FiringUnit":
						scenario_0.GetCurrentSide().Units.Where((ActiveUnit theU) => Operators.CompareString(theU.ObjectID, Local_theChild.InnerText, TextCompare: false) == 0).FirstOrDefault();
						break;
					case "ETA":
						firingProposal.ETA = DateTime.FromBinary(Conversions.ToLong(Local_theChild.InnerText));
						break;
					case "ShooterQuantity":
						firingProposal.ShooterQuantity = Conversions.ToInteger(Local_theChild.InnerText);
						break;
					case "ID":
						firingProposal.ObjectID_Set(Local_theChild.InnerText);
						break;
					case "ManualFire":
						firingProposal.ManualFire = Conversions.ToBoolean(Local_theChild.InnerText);
						break;
					case "Target":
						if (Local_theChild.InnerText.StartsWith("Aimpoint_"))
						{
							firingProposal.Target = AimpointContact.FromString(Local_theChild.InnerText);
						}
						else if (Local_theChild.InnerText.StartsWith("ActivationPoint_"))
						{
							firingProposal.Target = ActivationPointContact.FromString(Local_theChild.InnerText);
						}
						else
						{
							firingProposal.Target = Contact.FromXML(Local_theChild.InnerText, ref concurrentDictionary_0);
						}
						break;
					case "QuantityAvailable":
						firingProposal.QuantityAvailable = Conversions.ToInteger(Local_theChild.InnerText);
						break;
					case "WeaponDBID":
						firingProposal.int_0 = Conversions.ToInteger(Local_theChild.InnerText);
						break;
					case "Distance":
						firingProposal.Distance = Conversions.ToInteger(Local_theChild.InnerText);
						break;
					case "QuantityToFire":
						firingProposal.QuantityToFire = Conversions.ToInteger(Local_theChild.InnerText);
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
			return firingProposal;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 7345555", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			FiringProposal result = new FiringProposal();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public Weapon GetReferenceWeapon(Scenario scenario_0)
	{
		if (interceptorClient == null)
		{
			if (GetIsUnguidedWeapon(scenario_0))
			{
				interceptorClient = scenario_0.Cache_GetWeapon(int_0);
			}
			else
			{
				interceptorClient = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: false);
			}
		}
		return interceptorClient;
	}

	[SpecialName]
	public bool GetIsUnguidedWeapon(Scenario scenario_0)
	{
		int num = int_0;
		SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
		switch (DBFunctions.GetWeaponType(num, ref sqliteConnection_))
		{
		default:
			return false;
		case Weapon._WeaponType.Rocket:
		case Weapon._WeaponType.IronBomb:
		case Weapon._WeaponType.Gun:
		case Weapon._WeaponType.DepthCharge:
		case Weapon._WeaponType.Laser:
		case Weapon._WeaponType.Microwave:
		case Weapon._WeaponType.Troops:
		case Weapon._WeaponType.Paratroops:
			return true;
		}
	}

	public FiringProposal()
	{
	}

	public FiringProposal(int int_1, Contact contact_0, DateTime dateTime_0, double double_0, bool bool_0, Weapon weapon_0, Module_Unit.Unit unit_0)
	{
		int_0 = int_1;
		Target = contact_0;
		ETA = dateTime_0;
		Distance = double_0;
		ManualFire = bool_0;
		interceptorClient = weapon_0;
		FiringUnit = unit_0;
	}
}
