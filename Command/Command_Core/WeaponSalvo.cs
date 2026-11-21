using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponSalvo : ScenarioObject
{
	public sealed class Shooter
	{
		public string ShooterObjectID;

		public string PreferredMountObjectID;

		[CompilerGenerated]
		private int m_MerchantSetter;

		public int QuantityFired;

		public bool WeaponIsReadyToFire;

		public int TimeToNextLaunch;

		public int Timeout;

		public int? BombStickTotalQty;

		public int BombStickImpactedQty;

		public float? BombStickDirection;

		public float? BombStickLength;

		public int? BombStickIndexOfCenterShot;

		public GeoPoint BombStickFirstWeaponDPI;

		public GeoPoint BombStickFirstWeaponActualPI;

		public string BombStickAimpointObjectID;

		public int QuantityAssigned
		{
			get
			{
				return method_0();
			}
			set
			{
				method_1(value);
			}
		}

		[SpecialName]
		[CompilerGenerated]
		private int method_0()
		{
			return m_MerchantSetter;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_1(int int_0)
		{
			m_MerchantSetter = int_0;
		}

		public Shooter(string string_0)
		{
			method_1(0);
			ShooterObjectID = string_0;
		}

		public Shooter(string string_0, int int_0, int int_1)
		{
			method_1(0);
			ShooterObjectID = string_0;
			QuantityAssigned = int_0;
			QuantityFired = int_1;
			WeaponIsReadyToFire = false;
		}

		public Shooter(string string_0, string string_1, int int_0, int int_1, int int_2)
		{
			method_1(0);
			ShooterObjectID = string_0;
			PreferredMountObjectID = string_1;
			QuantityAssigned = int_0;
			QuantityFired = int_1;
			TimeToNextLaunch = int_2;
		}
	}

	public int int_0;

	public Shooter[] ShootersList;

	public string[] WeaponList;

	public int MaxNumberOfShooters;

	public int MaxNumberOfWeapons;

	public bool FireSimultaneouslyFromMultipleMounts;

	public Contact Target;

	public DateTime ScheduledFireTime;

	public Waypoint[] PlottedCourse;

	public bool ManualFire;

	private Weapon m_ContainerReader;

	public Weapon.WeaponSpecialMode ActiveSpecialMode;

	public DateTime ETA;

	public int WpnQuantityAssigned
	{
		get
		{
			Shooter[] shootersList = ShootersList;
			int num = 0;
			Shooter[] array = shootersList;
			int num2 = 0;
			Shooter shooter;
			while (true)
			{
				if (num2 < array.Length)
				{
					shooter = array[num2];
					if (shooter.QuantityAssigned == int.MaxValue)
					{
						break;
					}
					num += shooter.QuantityAssigned;
					num2++;
					continue;
				}
				return num;
			}
			return shooter.QuantityAssigned;
		}
	}

	public int WpnQuantityFired
	{
		get
		{
			Shooter[] shootersList = ShootersList;
			int num = 0;
			Shooter[] array = shootersList;
			Shooter[] array2 = array;
			foreach (Shooter shooter in array2)
			{
				num += shooter.QuantityFired;
			}
			return num;
		}
	}

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("WeaponSalvo");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteStartElement("Weapons");
			string[] weaponList = WeaponList;
			string[] array = weaponList;
			foreach (string value in array)
			{
				xmlWriter_0.WriteElementString("Weapon_ObjectID", value);
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Shooters");
			Shooter[] shootersList = ShootersList;
			Shooter[] array2 = shootersList;
			foreach (Shooter shooter in array2)
			{
				xmlWriter_0.WriteStartElement("Shooter");
				xmlWriter_0.WriteElementString("ShooterObjectID", shooter.ShooterObjectID);
				xmlWriter_0.WriteElementString("PreferredMountObjectID", shooter.PreferredMountObjectID);
				if (shooter.QuantityAssigned > 0)
				{
					xmlWriter_0.WriteElementString("QuantityAssigned", shooter.QuantityAssigned.ToString());
				}
				if (shooter.QuantityFired > 0)
				{
					xmlWriter_0.WriteElementString("QuantityFired", shooter.QuantityFired.ToString());
				}
				xmlWriter_0.WriteElementString("TimeToNextLaunch", shooter.TimeToNextLaunch.ToString());
				xmlWriter_0.WriteElementString("Timeout", shooter.Timeout.ToString());
				if (!Information.IsNothing(shooter.BombStickFirstWeaponDPI))
				{
					xmlWriter_0.WriteStartElement("FirstWeaponDPI");
					xmlWriter_0.WriteRaw(shooter.BombStickFirstWeaponDPI.ToXML(hashSet_0));
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("NumberOfShooters", MaxNumberOfShooters.ToString());
			xmlWriter_0.WriteElementString("WeaponDBID", int_0.ToString());
			xmlWriter_0.WriteElementString("Quantity_Total", MaxNumberOfWeapons.ToString());
			xmlWriter_0.WriteElementString("Target", Target.ObjectID);
			xmlWriter_0.WriteElementString("ScheduledFireTime", ScheduledFireTime.ToBinary().ToString());
			if (ActiveSpecialMode != 0)
			{
				XmlWriter obj = xmlWriter_0;
				int activeSpecialMode = (int)ActiveSpecialMode;
				obj.WriteElementString("ASMode", activeSpecialMode.ToString());
			}
			xmlWriter_0.WriteStartElement("PlottedCourse");
			Waypoint[] plottedCourse = PlottedCourse;
			Waypoint[] array3 = plottedCourse;
			foreach (Waypoint waypoint in array3)
			{
				if (!Information.IsNothing(waypoint))
				{
					waypoint.ToXML(ref xmlWriter_0, ref hashSet_0);
				}
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("ManualFire", ManualFire.ToString());
			xmlWriter_0.WriteElementString("FireSimultaneouslyFromMultipleMounts", FireSimultaneouslyFromMultipleMounts.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101206", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static WeaponSalvo FromXML(ref XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			WeaponSalvo weaponSalvo = new WeaponSalvo();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				GeoPoint bombStickFirstWeaponDPI = null;
				int num = 0;
				int int_ = 0;
				int int_2 = 0;
				IEnumerator enumerator5 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "Weapons":
						try
						{
							enumerator5 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								string innerText = ((XmlNode)enumerator5.Current).InnerText;
								ArrayExtensions.Add(ref weaponSalvo.WeaponList, innerText);
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
					case "ManualFire":
						weaponSalvo.ManualFire = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "NumberOfShooters":
						weaponSalvo.MaxNumberOfShooters = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Target":
						if (xmlNode_.InnerText.StartsWith("Aimpoint_"))
						{
							weaponSalvo.Target = AimpointContact.FromString(xmlNode_.InnerText);
						}
						else if (xmlNode_.InnerText.StartsWith("ActivationPoint_"))
						{
							weaponSalvo.Target = ActivationPointContact.FromString(xmlNode_.InnerText);
						}
						else
						{
							weaponSalvo.Target = Contact.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
						}
						break;
					case "FireSimultaneouslyFromMultipleMounts":
						weaponSalvo.FireSimultaneouslyFromMultipleMounts = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "ID":
						weaponSalvo.ObjectID_Set(xmlNode_.InnerText);
						break;
					case "WeaponDBID":
						weaponSalvo.int_0 = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ASMode":
						weaponSalvo.ActiveSpecialMode = (Weapon.WeaponSpecialMode)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Quantity_Total":
						weaponSalvo.MaxNumberOfWeapons = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ScheduledFireTime":
						weaponSalvo.ScheduledFireTime = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						break;
					case "Shooters":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator3.Current;
								string string_ = "";
								string string_2 = "";
								try
								{
									enumerator4 = xmlNode.ChildNodes.GetEnumerator();
									while (enumerator4.MoveNext())
									{
										XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
										switch (xmlNode2.Name)
										{
										case "PreferredMountObjectID":
											string_2 = xmlNode2.InnerText;
											break;
										case "TimeToNextLaunch":
											int_2 = Conversions.ToInteger(xmlNode2.InnerText);
											break;
										case "FirstWeaponDPI":
											bombStickFirstWeaponDPI = GeoPoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
											break;
										case "QuantityFired":
											int_ = Conversions.ToInteger(xmlNode2.InnerText);
											break;
										case "Timeout":
											Conversions.ToInteger(xmlNode2.InnerText);
											break;
										case "QuantityAssigned":
											num = Conversions.ToInteger(xmlNode2.InnerText);
											break;
										case "ShooterObjectID":
											string_ = xmlNode2.InnerText;
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
								Shooter shooter = new Shooter(string_, string_2, num, int_, int_2);
								shooter.BombStickFirstWeaponDPI = bombStickFirstWeaponDPI;
								ArrayExtensions.Add(ref weaponSalvo.ShootersList, shooter);
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
					case "PlottedCourse":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								Waypoint theAC = Waypoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0, scenario_0);
								ArrayExtensions.Add(ref weaponSalvo.PlottedCourse, theAC);
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
			return weaponSalvo;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101205", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			WeaponSalvo result = new WeaponSalvo();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private WeaponSalvo()
	{
		ShootersList = new Shooter[0];
		WeaponList = new string[0];
		PlottedCourse = new Waypoint[0];
	}

	public WeaponSalvo(ref int int_1, int int_2, int int_3, int int_4, ref Contact contact_0, ref bool bool_0, string string_0, int int_5, bool bool_1, [Optional][DateTimeConstant(0L)] DateTime theScheduledTime, List<Waypoint> list_0 = null)
	{
		ShootersList = new Shooter[0];
		WeaponList = new string[0];
		PlottedCourse = new Waypoint[0];
		try
		{
			int_0 = int_1;
			MaxNumberOfWeapons = int_2;
			MaxNumberOfShooters = int_5;
			Target = contact_0;
			ManualFire = bool_0;
			FireSimultaneouslyFromMultipleMounts = bool_1;
			Shooter theAC = new Shooter(string_0, int_4, int_3);
			ArrayExtensions.Add(ref ShootersList, theAC);
			if (!Information.IsNothing(theScheduledTime))
			{
				ScheduledFireTime = theScheduledTime;
			}
			if (!Information.IsNothing(list_0))
			{
				PlottedCourse = list_0.ToArray();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101207", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public Weapon GetReferenceWeapon(Scenario scenario_0)
	{
		if (m_ContainerReader == null)
		{
			if (GetIsUnguidedWeapon(scenario_0))
			{
				m_ContainerReader = scenario_0.Cache_GetWeapon(int_0);
			}
			else
			{
				m_ContainerReader = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: false);
			}
		}
		return m_ContainerReader;
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
		case Weapon._WeaponType.LaserDazzler:
		case Weapon._WeaponType.Troops:
		case Weapon._WeaponType.Paratroops:
			return true;
		}
	}
}
