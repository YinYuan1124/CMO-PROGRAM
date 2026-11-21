using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class GuidedProjectile : Weapon
{
	private GuidedProjectile_AI proccesorDic;

	private GuidedProjectile_Kinematics _StrategyDic;

	public override Weapon_AI AI => proccesorDic;

	public override Weapon_Kinematics Kinematics => _StrategyDic;

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

	public GuidedProjectile()
	{
		proccesorDic = new GuidedProjectile_AI(this);
		ActiveUnit activeUnit_ = this;
		_StrategyDic = new GuidedProjectile_Kinematics(ref activeUnit_);
		IsWeapon = true;
		Type = _WeaponType.GuidedProjectile;
		IsGuidedProjectile = true;
		EvaluateIfDumb();
	}

	public GuidedProjectile(ref Scenario scenario_0, int int_0, string string_0 = null)
		: base(string_0)
	{
		proccesorDic = new GuidedProjectile_AI(this);
		ActiveUnit activeUnit_ = this;
		_StrategyDic = new GuidedProjectile_Kinematics(ref activeUnit_);
		IsWeapon = true;
		Type = _WeaponType.GuidedProjectile;
		IsGuidedProjectile = true;
		EvaluateIfDumb();
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

	public new static GuidedProjectile FromXML_Private(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, bool bool_0)
	{
		try
		{
			GuidedProjectile guidedProjectile = new GuidedProjectile();
			guidedProjectile.ParentScen = scenario_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				return (GuidedProjectile)concurrentDictionary_0[innerText];
			}
			guidedProjectile.ObjectID_Set(innerText);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return guidedProjectile;
			}
			concurrentDictionary_0.TryAdd(guidedProjectile.ObjectID, guidedProjectile);
			int int_ = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			DBFunctions.GetWeapon(scenario_0.DBConnection, guidedProjectile, int_, scenario_0, bool_0);
			if (bool_0)
			{
				guidedProjectile.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_0)
			{
				Weapon.LoadSavedComponents(guidedProjectile, scenario_0, xmlNode_0, concurrentDictionary_0);
			}
			Weapon.LoadMutableProperties(guidedProjectile, scenario_0, xmlNode_0, concurrentDictionary_0);
			return guidedProjectile;
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
			GuidedProjectile result = new GuidedProjectile();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override bool AboutToImpact_ActualTarget(float float_0)
	{
		bool result;
		if (!(result = base.AboutToImpact_ActualTarget(float_0)))
		{
			if (Information.IsNothing(AI.PrimaryTarget))
			{
				return false;
			}
			float num = Module_Unit.BearingToUnit_Relative(this, AI.PrimaryTarget);
			if (num > 100f && num < 260f)
			{
				return true;
			}
		}
		return result;
	}

	public override void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
		if (!clientReader)
		{
			if (IsUnderwater || IsUnderground)
			{
				if (Warheads.Any() && Warheads[0].IsExplosive)
				{
					double latitude = GetLatitude();
					double longitude = GetLongitude();
					float currentAltitude = GetCurrentAltitude();
					LockRandom lockRandom_ = GameGeneral.LockRandom_0;
					Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: true);
				}
				else
				{
					ParentScen.DestroyThisUnit(this, "Guided projectile impacted ground", "Impact / Detonation");
				}
				return;
			}
			if (AI.PrimaryTarget != null)
			{
				ActiveUnit actualUnit = AI.PrimaryTarget.ActualUnit;
				if (actualUnit != null && actualUnit.IsAerospaceUnit && Module_Unit.BearingToUnit_Relative(this, AI.PrimaryTarget) > 100f && Module_Unit.BearingToUnit_Relative(this, AI.PrimaryTarget) < 260f)
				{
					double latitude2 = GetLatitude();
					double longitude2 = GetLongitude();
					float currentAltitude2 = GetCurrentAltitude();
					LockRandom lockRandom_2 = GameGeneral.LockRandom_0;
					Detonate(latitude2, longitude2, currentAltitude2, ref lockRandom_2, bool_0: true);
					return;
				}
			}
			if ((double)Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) > (double)base.MaxRange_NoTargetType * 1.05)
			{
				ParentScen.DestroyThisUnit(this, "Guided projectile ran out of energy", "燃料已用完");
				return;
			}
		}
		base.DoTypeSpecificActions(float_0, ref lockRandom_0);
	}
}
