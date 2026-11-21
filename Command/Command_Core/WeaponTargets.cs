using System;
using System.Collections;
using System.Data.SQLite;
using System.Diagnostics;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponTargets
{
	public bool SurfaceVessel;

	public bool Submarine;

	public bool Aircraft;

	public bool Missile;

	public bool Satellite;

	public bool Radar;

	public bool Runway;

	public bool LandStructure_Soft;

	public bool LandStructure_Hard;

	public bool MobileTarget_Personnel;

	public bool Torpedo;

	public bool Mine;

	public bool Helicopter;

	public bool MobileTarget_Soft;

	public bool MobileTarget_Hard;

	public bool UnderwaterStructure;

	public bool AerostatMooring;

	public bool AirBaseSingleUnit;

	public bool RAMB;

	public bool MultipleTypes;

	public void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("WeaponTargets");
			if (SurfaceVessel)
			{
				xmlWriter_0.WriteElementString("SurfaceVessel", true.ToString());
			}
			if (Submarine)
			{
				xmlWriter_0.WriteElementString("Submarine", true.ToString());
			}
			if (Aircraft)
			{
				xmlWriter_0.WriteElementString("Aircraft", true.ToString());
			}
			if (Missile)
			{
				xmlWriter_0.WriteElementString("Missile", true.ToString());
			}
			if (Radar)
			{
				xmlWriter_0.WriteElementString("Radar", true.ToString());
			}
			if (Runway)
			{
				xmlWriter_0.WriteElementString("Runway", true.ToString());
			}
			if (LandStructure_Soft)
			{
				xmlWriter_0.WriteElementString("LandStructure_Soft", true.ToString());
			}
			if (LandStructure_Hard)
			{
				xmlWriter_0.WriteElementString("LandStructure_Hard", true.ToString());
			}
			if (Torpedo)
			{
				xmlWriter_0.WriteElementString("Torpedo", true.ToString());
			}
			if (Mine)
			{
				xmlWriter_0.WriteElementString("Mine", true.ToString());
			}
			if (Helicopter)
			{
				xmlWriter_0.WriteElementString("Helicopter", true.ToString());
			}
			if (MobileTarget_Soft)
			{
				xmlWriter_0.WriteElementString("MobileTarget_Soft", true.ToString());
			}
			if (MobileTarget_Hard)
			{
				xmlWriter_0.WriteElementString("MobileTarget_Hard", true.ToString());
			}
			if (MobileTarget_Personnel)
			{
				xmlWriter_0.WriteElementString("MobileTarget_Personnel", true.ToString());
			}
			if (UnderwaterStructure)
			{
				xmlWriter_0.WriteElementString("UnderwaterStructure", true.ToString());
			}
			if (AerostatMooring)
			{
				xmlWriter_0.WriteElementString("AerostatMooring", true.ToString());
			}
			if (AirBaseSingleUnit)
			{
				xmlWriter_0.WriteElementString("AirBaseSingleUnit", true.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101077", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static WeaponTargets FromXML(XmlNode xmlNode_0)
	{
		try
		{
			WeaponTargets weaponTargets = new WeaponTargets();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					switch (((XmlNode)enumerator.Current).Name)
					{
					case "MobileTarget_Personnel":
						weaponTargets.MobileTarget_Personnel = true;
						break;
					case "Missile":
						weaponTargets.Missile = true;
						break;
					case "Submarine":
						weaponTargets.Submarine = true;
						break;
					case "MobileTarget_Soft":
						weaponTargets.MobileTarget_Soft = true;
						break;
					case "AirBaseSingleUnit As":
						weaponTargets.AirBaseSingleUnit = true;
						break;
					case "Radar":
						weaponTargets.Radar = true;
						break;
					case "MobileTarget_Hard":
						weaponTargets.MobileTarget_Hard = true;
						break;
					case "Runway":
						weaponTargets.Runway = true;
						break;
					case "LandStructure_Soft":
						weaponTargets.LandStructure_Soft = true;
						break;
					case "LandStructure_Hard":
						weaponTargets.LandStructure_Hard = true;
						break;
					case "Helicopter":
						weaponTargets.Helicopter = true;
						break;
					case "SurfaceVessel":
						weaponTargets.SurfaceVessel = true;
						break;
					case "Torpedo":
						weaponTargets.Torpedo = true;
						break;
					case "UnderwaterStructure":
						weaponTargets.UnderwaterStructure = true;
						break;
					case "Aircraft":
						weaponTargets.Aircraft = true;
						break;
					case "AerostatMooring As":
						weaponTargets.AerostatMooring = true;
						break;
					case "Mine":
						weaponTargets.Mine = true;
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
			if (xmlNode_0.ChildNodes.Count > 1)
			{
				weaponTargets.MultipleTypes = true;
			}
			return weaponTargets;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101078", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			WeaponTargets result = new WeaponTargets();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private WeaponTargets()
	{
		MultipleTypes = false;
	}

	public WeaponTargets(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		MultipleTypes = false;
		WeaponTargets weaponTargets_ = this;
		DBFunctions.PopulateWeaponTargets(ref weaponTargets_, int_0, ref sqliteConnection_0);
	}
}
