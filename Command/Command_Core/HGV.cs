using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class HGV : Weapon
{
	private HGV_AI _SingletonDic;

	private HGV_Kinematics recordDic;

	public override Weapon_AI AI => _SingletonDic;

	public override Weapon_Kinematics Kinematics => recordDic;

	internal override bool IsHGV => true;

	public override bool SupportsAttitude_Pitch => true;

	public override float Attitude_Pitch
	{
		get
		{
			return _Attitude_Pitch;
		}
		set
		{
			_Attitude_Pitch = value;
		}
	}

	public override float DesiredPitch
	{
		get
		{
			return _DesiredPitch;
		}
		set
		{
			_DesiredPitch = value;
		}
	}

	public HGV()
	{
		_SingletonDic = new HGV_AI(this);
		ActiveUnit activeUnit_ = this;
		recordDic = new HGV_Kinematics(ref activeUnit_);
		IsWeapon = true;
		Type = _WeaponType.HGV;
		CruiseAltitude_ASL = 50000f;
		Attitude_Pitch = 0f;
		Attitude_Roll = 0f;
	}

	public HGV(ref Scenario scenario_0, int int_0, string string_0 = null)
	{
		_SingletonDic = new HGV_AI(this);
		ActiveUnit activeUnit_ = this;
		recordDic = new HGV_Kinematics(ref activeUnit_);
		IsWeapon = true;
		Type = _WeaponType.HGV;
		CruiseAltitude_ASL = 50000f;
		Attitude_Pitch = 0f;
		Attitude_Roll = 0f;
	}

	[SpecialName]
	public override float GetCurrentAltitude(bool bool_0 = false)
	{
		return base.GetCurrentAltitude(bool_0);
	}

	[SpecialName]
	public override void SetCurrentAltitude(bool bool_0, float float_0)
	{
		if (bool_0 && IsGuidedWeapon() && float_0 < 6.0959997f)
		{
			float_0 = 6.0959997f;
		}
		GetCurrentAltitude();
		base.SetCurrentAltitude(bool_0, float_0);
	}

	public new static HGV FromXML_Private(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, bool bool_0)
	{
		try
		{
			HGV hGV = new HGV();
			hGV.ParentScen = scenario_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				return (HGV)concurrentDictionary_0[innerText];
			}
			hGV.ObjectID_Set(innerText);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return hGV;
			}
			concurrentDictionary_0.TryAdd(hGV.ObjectID, hGV);
			int int_ = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			DBFunctions.GetWeapon(scenario_0.DBConnection, hGV, int_, scenario_0, bool_0);
			if (hGV.IsHGV)
			{
				hGV.CruiseAltitude_ASL = 100000f;
			}
			if (bool_0)
			{
				hGV.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_0)
			{
				Weapon.LoadSavedComponents(hGV, scenario_0, xmlNode_0, concurrentDictionary_0);
			}
			Weapon.LoadMutableProperties(hGV, scenario_0, xmlNode_0, concurrentDictionary_0);
			float maximumAltitude = hGV.Kinematics.GetMaximumAltitude();
			float minimumAltitude = hGV.Kinematics.GetMinimumAltitude();
			if (hGV.GetCurrentAltitude() > maximumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
			{
				hGV.SetCurrentAltitude(bool_0: false, maximumAltitude);
			}
			else if (hGV.GetCurrentAltitude() < minimumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
			{
				hGV.SetCurrentAltitude(bool_0: false, minimumAltitude);
			}
			if (hGV.DesiredAltitude > maximumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
			{
				hGV.DesiredAltitude = maximumAltitude;
			}
			else if (hGV.DesiredAltitude < minimumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
			{
				hGV.DesiredAltitude = minimumAltitude;
			}
			return hGV;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100882", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			HGV result = new HGV();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void DoFuelConsumption(float float_0)
	{
	}
}
