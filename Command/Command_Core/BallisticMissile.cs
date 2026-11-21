using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticMissile : Weapon
{
	private BallisticMissile_AI errorObserver;

	private BallisticMissile_Kinematics _CodeObserver;

	public bool IsPerformingTerminalManeuvers;

	private float? _ConnectionObserver;

	public override bool SupportsAttitude_Pitch => true;

	public override Weapon_AI AI => errorObserver;

	public override Weapon_Kinematics Kinematics => _CodeObserver;

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

	public override float CurrentSpeed
	{
		get
		{
			return base.CurrentSpeed;
		}
		set
		{
			base.CurrentSpeed = value;
		}
	}

	public override bool IsBallisticMissile => true;

	public BallisticMissile()
	{
		errorObserver = new BallisticMissile_AI(this);
		ActiveUnit activeUnit_ = this;
		_CodeObserver = new BallisticMissile_Kinematics(ref activeUnit_);
		IsPerformingTerminalManeuvers = false;
		IsWeapon = true;
		Type = _WeaponType.BallisticMissile;
	}

	public BallisticMissile(ref Scenario scenario_0, int int_0, string string_0 = null)
	{
		errorObserver = new BallisticMissile_AI(this);
		ActiveUnit activeUnit_ = this;
		_CodeObserver = new BallisticMissile_Kinematics(ref activeUnit_);
		IsPerformingTerminalManeuvers = false;
		IsWeapon = true;
		Type = _WeaponType.BallisticMissile;
		ParentScen = scenario_0;
	}

	public float TotalFlyoutHorizontalRange()
	{
		if (!_ConnectionObserver.HasValue)
		{
			if (AI.PrimaryTarget == null)
			{
				if (base.Navigator.HasPlottedCourse())
				{
					_ConnectionObserver = LaunchPoint.RangeToPoint_Horiz(base.Navigator.PlottedCourse[0].Longitude, base.Navigator.PlottedCourse[1].Longitude);
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				_ConnectionObserver = LaunchPoint.RangeToUnit_Horiz(AI.PrimaryTarget);
			}
		}
		return _ConnectionObserver.Value;
	}

	[SpecialName]
	public override float GetCurrentAltitude(bool bool_0 = false)
	{
		return base.GetCurrentAltitude(bool_0);
	}

	[SpecialName]
	public override void SetCurrentAltitude(bool bool_0, float float_0)
	{
		GetCurrentAltitude();
		base.SetCurrentAltitude(bool_0, float_0);
	}

	public new static BallisticMissile FromXML_Private(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, bool bool_0)
	{
		try
		{
			BallisticMissile ballisticMissile = new BallisticMissile();
			ballisticMissile.ParentScen = scenario_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				return (BallisticMissile)concurrentDictionary_0[innerText];
			}
			ballisticMissile.ObjectID_Set(innerText);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return ballisticMissile;
			}
			concurrentDictionary_0.TryAdd(ballisticMissile.ObjectID, ballisticMissile);
			int int_ = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			DBFunctions.GetWeapon(scenario_0.DBConnection, ballisticMissile, int_, scenario_0, bool_0);
			if (bool_0)
			{
				ballisticMissile.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_0)
			{
				Weapon.LoadSavedComponents(ballisticMissile, scenario_0, xmlNode_0, concurrentDictionary_0);
			}
			Weapon.LoadMutableProperties(ballisticMissile, scenario_0, xmlNode_0, concurrentDictionary_0);
			return ballisticMissile;
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
			BallisticMissile result = new BallisticMissile();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void DoFuelConsumption(float float_0)
	{
	}

	internal Contact SortReader()
	{
		Contact contact = null;
		if (Kinematics.BallisticTrajectory == null)
		{
			if (AI.PrimaryTarget == null)
			{
				if (AI.LastKnownTargetLocation != null)
				{
					contact = new AimpointContact(AI.LastKnownTargetLocation.Latitude, AI.LastKnownTargetLocation.Longitude);
					contact.SetCurrentAltitude(bool_0: false, AI.LastKnownTargetLocation.Altitude);
				}
			}
			else
			{
				contact = AI.PrimaryTarget;
			}
		}
		else
		{
			contact = new AimpointContact(Kinematics.BallisticTrajectory.Target.lat * 180.0 / 3.14159265358979, Kinematics.BallisticTrajectory.Target.lon * 180.0 / 3.14159265358979);
			contact.SetCurrentAltitude(bool_0: false, (float)((Kinematics.BallisticTrajectory.Target.radius_km - 6371.0) * 1000.0));
		}
		if (contact == null && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return contact;
	}
}
