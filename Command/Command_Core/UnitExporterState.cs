namespace Command_Core;

public sealed class UnitExporterState
{
	public Geopoint_Struct Location;

	public float Heading;

	public float Pitch;

	public ActiveUnit._ActiveUnitStatus status;

	public Aircraft_AirOps._AirOpsCondition? AirOps;

	public ActiveUnit_DockingOps._DockingOpsCondition? DockOps;

	public Mission AssignedMission;

	public float? DamagePercentage;

	public ActiveUnit_Damage.FireIntensityLevel? Fire;

	public ActiveUnit_Damage.FloodingIntensityLevel? Flood;

	public UnitExporterState(Module_Unit.Unit unit_0)
	{
		Location = new Geopoint_Struct(unit_0.GetLongitude(), unit_0.GetLatitude(), unit_0.GetCurrentAltitude());
		Pitch = unit_0.Attitude_Pitch;
		if (unit_0.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)unit_0;
			status = activeUnit.Status;
			DamagePercentage = activeUnit.Damage.DamagePercent;
			Fire = activeUnit.Damage.FireIntensity;
			Flood = activeUnit.Damage.FloodIntensity;
			DockOps = activeUnit.DockingOps.Condition;
		}
		else
		{
			status = ActiveUnit._ActiveUnitStatus.Unassigned;
			DamagePercentage = null;
			Fire = null;
			Flood = null;
			DockOps = null;
		}
		if (unit_0.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)unit_0;
			AirOps = aircraft.AirOps.Condition;
		}
		else
		{
			AirOps = null;
		}
	}

	internal bool RunWatcher(Module_Unit.Unit unit_0)
	{
		if (unit_0.GetLongitude() == Location.Longitude)
		{
			if (unit_0.GetLatitude() == Location.Latitude)
			{
				if (unit_0.GetCurrentAltitude() == Location.Altitude)
				{
					if (unit_0.CurrentHeading == Heading)
					{
						if (unit_0.Attitude_Pitch == Pitch)
						{
							if (unit_0.IsAircraft)
							{
								byte condition = (byte)((Aircraft)unit_0).AirOps.Condition;
								byte? b = (byte?)AirOps;
								if ((b.HasValue ? new bool?(condition != b.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									return false;
								}
							}
							if (unit_0.IsActiveUnit)
							{
								ActiveUnit activeUnit = (ActiveUnit)unit_0;
								if (activeUnit.Status != status)
								{
									return false;
								}
								byte condition2 = (byte)activeUnit.DockingOps.Condition;
								byte? b2 = (byte?)DockOps;
								if ((b2.HasValue ? new bool?(condition2 != b2.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									return false;
								}
								float damagePercent = activeUnit.Damage.DamagePercent;
								float? damagePercentage = DamagePercentage;
								if ((damagePercentage.HasValue ? new bool?(damagePercent != damagePercentage.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									return false;
								}
								condition2 = (byte)activeUnit.Damage.FireIntensity;
								b2 = (byte?)Fire;
								if ((b2.HasValue ? new bool?(condition2 != b2.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									return false;
								}
								condition2 = (byte)activeUnit.Damage.FloodIntensity;
								b2 = (byte?)Flood;
								if ((b2.HasValue ? new bool?(condition2 != b2.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									return false;
								}
							}
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}
}
