using Easy.Common;

namespace Command_Core;

public class ScenarioObject
{
	public string ObjectID;

	private string wrapperFacade;

	public bool IsActiveUnit;

	public bool IsGroup;

	public bool IsWeapon;

	public bool IsAircraft;

	public bool IsBoat;

	public bool IsSubmarine;

	public bool IsShip;

	public bool IsTorpedo;

	public bool IsFacility;

	public bool IsVehicle;

	public bool IsSatellite;

	public bool IsMobileGroundUnit;

	public bool IsMission;

	public bool IsWaypoint;

	public bool IsGuidedProjectile;

	public virtual string Name
	{
		get
		{
			return wrapperFacade;
		}
		set
		{
			wrapperFacade = value;
		}
	}

	public bool IsMissile
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type != Weapon._WeaponType.GuidedWeapon && !weapon.IsBallisticMissile && !weapon.IsReEntryVehicle && !weapon.IsHGV)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsVehicleDecoy
	{
		get
		{
			if (IsWeapon)
			{
				if (((Weapon)this).Type == Weapon._WeaponType.Decoy_Vehicle)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsFixedFacility
	{
		get
		{
			if (IsFacility)
			{
				if (((Facility)this).RepresentsMobileGroundUnit)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public ScenarioObject()
	{
		IsActiveUnit = false;
		IsGroup = false;
		IsWeapon = false;
		IsAircraft = false;
		IsBoat = false;
		IsSubmarine = false;
		IsShip = false;
		IsTorpedo = false;
		IsFacility = false;
		IsVehicle = false;
		IsSatellite = false;
		IsMobileGroundUnit = false;
		IsMission = false;
		IsWaypoint = false;
		IsGuidedProjectile = false;
		ObjectID = IDGenerator.Instance.Next;
	}

	public ScenarioObject(bool bool_0 = true)
	{
		IsActiveUnit = false;
		IsGroup = false;
		IsWeapon = false;
		IsAircraft = false;
		IsBoat = false;
		IsSubmarine = false;
		IsShip = false;
		IsTorpedo = false;
		IsFacility = false;
		IsVehicle = false;
		IsSatellite = false;
		IsMobileGroundUnit = false;
		IsMission = false;
		IsWaypoint = false;
		IsGuidedProjectile = false;
		if (bool_0)
		{
			ObjectID = IDGenerator.Instance.Next;
		}
	}

	public virtual void ObjectID_Set(string string_0)
	{
		if (Misc.CreateRequest(string_0, ' '))
		{
			ObjectID = string_0.Replace(" ", "-");
		}
		else
		{
			ObjectID = string_0;
		}
	}

	public virtual void ResetIDs()
	{
		ObjectID = IDGenerator.Instance.Next;
	}

	public void AddMessage(Scenario scenario_0, string string_0, string string_1, LoggedMessage.MessageType messageType_0, byte byte_0)
	{
		if ((object)GetType() == typeof(Side))
		{
			scenario_0.AddMessage(string_0, string_1, messageType_0, byte_0, null, (Side)this);
			return;
		}
		if (IsMission)
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				foreach (Mission mission in side.Missions)
				{
					if (mission == this)
					{
						scenario_0.AddMessage(string_0, string_1, messageType_0, byte_0, null, side);
						return;
					}
				}
			}
			return;
		}
		if (IsActiveUnit)
		{
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (activeUnits_ == this)
				{
					activeUnits_.AddMessage(string_0, string_1, messageType_0, byte_0, bool_0: false, new Geopoint_Struct(activeUnits_.GetLongitude(), activeUnits_.GetLatitude()));
					break;
				}
			}
			return;
		}
		if (!IsWaypoint)
		{
			return;
		}
		foreach (ActiveUnit activeUnits_2 in scenario_0.ActiveUnits_List)
		{
			Waypoint[] plottedCourse = activeUnits_2.Navigator.PlottedCourse;
			for (int i = 0; i < plottedCourse.Length; i = checked(i + 1))
			{
				if (plottedCourse[i] == this)
				{
					activeUnits_2.AddMessage(string_0, string_1, messageType_0, byte_0, bool_0: false, new Geopoint_Struct(activeUnits_2.GetLongitude(), activeUnits_2.GetLatitude()));
					return;
				}
			}
		}
	}

	public bool IsGuidedWeapon()
	{
		if (IsWeapon)
		{
			if (((Weapon)this).Type == Weapon._WeaponType.GuidedWeapon)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal bool CompareWriter()
	{
		return (object)GetType() == typeof(Module_Unit.Unit);
	}

	internal bool ReadWriter()
	{
		return (object)GetType() == typeof(ReferencePoint);
	}

	internal bool DisableWriter()
	{
		return (object)GetType() == typeof(Contact);
	}

	internal bool UpdateWriter()
	{
		if (DisableWriter())
		{
			return ((Contact)this).SetupImporter();
		}
		if (IsActiveUnit)
		{
			return ((ActiveUnit)this).PatchClient();
		}
		return false;
	}
}
