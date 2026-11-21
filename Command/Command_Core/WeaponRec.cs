using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponRec : ScenarioObject
{
	public delegate void CurrentLoadChangedEventHandler(string WeaponRecObjectID);

	public int? WRecDBID;

	public int DefaultLoad;

	private int _DescriptorReader;

	public int MaxLoad;

	private int m_PoolReader;

	public int Multiple;

	private Weapon m_TaskReader;

	public bool OptionalWeapons;

	public bool InternalWeapons;

	public int int_0;

	public float TimeToFire;

	public Mount ParentMount;

	[CompilerGenerated]
	private static CurrentLoadChangedEventHandler _FilterReader;

	private Weapon._WeaponType? m_TestsReader;

	[ThreadStatic]
	private static StringBuilder interpreterReader;

	public int CurrentLoad
	{
		get
		{
			return _DescriptorReader;
		}
		set
		{
			bool num = value != _DescriptorReader;
			_DescriptorReader = value;
			if (!num)
			{
				return;
			}
			try
			{
				_FilterReader?.Invoke(ObjectID);
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

	public float ReloadTime => m_PoolReader;

	public static event CurrentLoadChangedEventHandler CurrentLoadChanged
	{
		[CompilerGenerated]
		add
		{
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler = _FilterReader;
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler2;
			do
			{
				currentLoadChangedEventHandler2 = currentLoadChangedEventHandler;
				CurrentLoadChangedEventHandler value2 = (CurrentLoadChangedEventHandler)Delegate.Combine(currentLoadChangedEventHandler2, value);
				currentLoadChangedEventHandler = Interlocked.CompareExchange(ref _FilterReader, value2, currentLoadChangedEventHandler2);
			}
			while ((object)currentLoadChangedEventHandler != currentLoadChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler = _FilterReader;
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler2;
			do
			{
				currentLoadChangedEventHandler2 = currentLoadChangedEventHandler;
				CurrentLoadChangedEventHandler value2 = (CurrentLoadChangedEventHandler)Delegate.Remove(currentLoadChangedEventHandler2, value);
				currentLoadChangedEventHandler = Interlocked.CompareExchange(ref _FilterReader, value2, currentLoadChangedEventHandler2);
			}
			while ((object)currentLoadChangedEventHandler != currentLoadChangedEventHandler2);
		}
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		if (m_TaskReader != null)
		{
			m_TaskReader.ResetIDs();
		}
	}

	internal Weapon._WeaponType PatchDescriptor(Scenario scenario_0)
	{
		if (m_TestsReader.HasValue)
		{
			return m_TestsReader.Value;
		}
		if (m_TaskReader == null)
		{
			Weapon._WeaponType weaponType = DBFunctions.GetWeaponType(int_0, scenario_0);
			m_TestsReader = weaponType;
			return m_TestsReader.Value;
		}
		m_TestsReader = m_TaskReader.Type;
		return m_TestsReader.Value;
	}

	public string ToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			if (interpreterReader == null)
			{
				interpreterReader = new StringBuilder();
			}
			else
			{
				interpreterReader.Clear();
			}
			interpreterReader.Append("<WRec>");
			interpreterReader.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					interpreterReader.Append("</WRec>");
					return interpreterReader.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			if (DefaultLoad != 0)
			{
				interpreterReader.Append("<DL>").Append(DefaultLoad.ToString()).Append("</DL>");
			}
			if (CurrentLoad != 0)
			{
				interpreterReader.Append("<CL>").Append(CurrentLoad.ToString()).Append("</CL>");
			}
			if (MaxLoad != 0)
			{
				interpreterReader.Append("<ML>").Append(MaxLoad.ToString()).Append("</ML>");
			}
			if (m_PoolReader != 0)
			{
				interpreterReader.Append("<ROF>").Append(m_PoolReader.ToString()).Append("</ROF>");
			}
			if (OptionalWeapons)
			{
				interpreterReader.Append("<OW>").Append("True").Append("</OW>");
			}
			if (InternalWeapons)
			{
				interpreterReader.Append("<IW>").Append("True").Append("</IW>");
			}
			if (Multiple != 1)
			{
				interpreterReader.Append("<Mult>").Append(Multiple.ToString()).Append("</Mult>");
			}
			interpreterReader.Append("<WeapID>").Append(int_0.ToString()).Append("</WeapID>");
			if (TimeToFire != 0f)
			{
				interpreterReader.Append("<TTF>").Append(XmlConvert.ToString(TimeToFire)).Append("</TTF>");
			}
			if (WRecDBID.HasValue)
			{
				interpreterReader.Append("<RecID>").Append(WRecDBID.Value.ToString()).Append("</RecID>");
			}
			Weapon._WeaponType weaponType = PatchDescriptor(scenario_0);
			if (weaponType == Weapon._WeaponType.FerryTank || weaponType == Weapon._WeaponType.DropTank || weaponType == Weapon._WeaponType.SensorPod)
			{
				Weapon referenceWeapon = GetReferenceWeapon(scenario_0);
				if (referenceWeapon.FuelCapacityMax > 0)
				{
					interpreterReader.Append("<FuelTank>").Append(XmlConvert.ToString(referenceWeapon.Fuel_ReadOnly[0].CurrentQuantity)).Append("</FuelTank>");
				}
			}
			interpreterReader.Append("</WRec>");
			return interpreterReader.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1013249583745892137", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static WeaponRec FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			WeaponRec weaponRec = new WeaponRec();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "RecDBID":
						weaponRec.WRecDBID = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "IW":
						weaponRec.InternalWeapons = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ID":
						weaponRec.ObjectID_Set(xmlNode.InnerText);
						break;
					case "ML":
					case "MaxLoad":
						weaponRec.MaxLoad = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ROF":
						weaponRec.m_PoolReader = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "CurrentLoad":
					case "CL":
						weaponRec._DescriptorReader = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "OW":
						weaponRec.OptionalWeapons = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "TTF":
					case "TimeToFire":
						weaponRec.TimeToFire = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "FuelTank":
					{
						Weapon referenceWeapon = weaponRec.GetReferenceWeapon(scenario_0);
						if (referenceWeapon.IsFuelTank || referenceWeapon.IsSensorPodWithFuelTank)
						{
							referenceWeapon.Fuel_ReadOnly[0].CurrentQuantity = XmlConvert.ToSingle(xmlNode.InnerText);
						}
						break;
					}
					case "DL":
					case "DefaultLoad":
						weaponRec.DefaultLoad = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "WeapID":
					case "WeaponDBID":
						weaponRec.int_0 = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Mult":
					case "Multiple":
						weaponRec.Multiple = Conversions.ToInteger(xmlNode.InnerText);
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
			return weaponRec;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101076", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			WeaponRec result = new WeaponRec();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private WeaponRec()
	{
		Multiple = 1;
		OptionalWeapons = false;
		InternalWeapons = false;
	}

	[SpecialName]
	public bool GetHasManualReloadPriority(Mount mount_0)
	{
		return mount_0.ReloadPriority.Contains(int_0);
	}

	[SpecialName]
	public Weapon GetReferenceWeapon(Scenario scenario_0)
	{
		if (m_TaskReader == null)
		{
			if (GetIsUnguidedWeapon(scenario_0))
			{
				m_TaskReader = scenario_0.Cache_GetWeapon(int_0);
			}
			else
			{
				m_TaskReader = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: false);
			}
		}
		return m_TaskReader;
	}

	public void DestroyWeaponRec()
	{
		m_TaskReader = null;
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

	public void ResetTimeToFire()
	{
		if (m_PoolReader < 0)
		{
			TimeToFire = 30 * -m_PoolReader;
		}
		else
		{
			TimeToFire = m_PoolReader;
		}
	}

	public WeaponRec(ref Scenario scenario_0, int int_1, int int_2, int int_3, int int_4, int int_5, bool bool_0, bool bool_1)
	{
		Multiple = 1;
		OptionalWeapons = false;
		InternalWeapons = false;
		DefaultLoad = int_2;
		_DescriptorReader = DefaultLoad;
		MaxLoad = int_3;
		m_PoolReader = int_4;
		Multiple = int_5;
		TimeToFire = 0f;
		int_0 = int_1;
		OptionalWeapons = bool_0;
		InternalWeapons = bool_1;
	}
}
