using System.Collections.Generic;
using System.Linq;

namespace Command_Core;

public class Transport
{
	public ActiveUnit ActualTransport;

	public float AreaCapacity;

	public float MassCapacity;

	public float CrewCapacity;

	public CargoType MaxSize;

	public float CurrentArea;

	public float CurretMass;

	public float currentCrew;

	public LandingType LandingType;

	public Dictionary<ChalkUnit, ChalkUnit> CurrentCargo;

	public List<TransportWave> Waves;

	internal (float AreaTaken, float MassTaken, float CrewTaken) CalculateWatcher(ChalkUnit chalkUnit_0)
	{
		float item = 0f;
		if (chalkUnit_0.Unit.RequiredArea != 0f && AreaCapacity != 0f)
		{
			item = chalkUnit_0.Unit.RequiredArea / AreaCapacity;
		}
		float item2 = 0f;
		if (chalkUnit_0.Unit.RequiredMass != 0f && MassCapacity != 0f)
		{
			item2 = chalkUnit_0.Unit.RequiredMass / MassCapacity;
		}
		float item3 = 0f;
		if (chalkUnit_0.Unit.RequiredCrewSpace != 0f && CrewCapacity != 0f)
		{
			item3 = chalkUnit_0.Unit.RequiredCrewSpace / CrewCapacity;
		}
		return (AreaTaken: item, MassTaken: item2, CrewTaken: item3);
	}

	public Transport(ActiveUnit activeUnit_0)
	{
		CurrentCargo = new Dictionary<ChalkUnit, ChalkUnit>();
		Waves = new List<TransportWave>();
		ICargoHost cargoHost = (ICargoHost)activeUnit_0;
		ActualTransport = activeUnit_0;
		AreaCapacity = cargoHost.GetCargo_Area();
		MassCapacity = cargoHost.GetCargo_Mass();
		CrewCapacity = cargoHost.GetCargo_Crew();
		MaxSize = cargoHost.GetCargo_Type();
		if (!activeUnit_0.IsBoat && !activeUnit_0.IsShip)
		{
			if (activeUnit_0.IsAircraft)
			{
				LandingType = LandingType.Airborne;
			}
			else
			{
				LandingType = LandingType.Unassigned;
			}
		}
		else
		{
			LandingType = LandingType.Amphibious;
		}
	}

	internal AddCargoReturnValue PopWatcher(Chalk chalk_0, LandingZoneWrapper landingZoneWrapper_0, Dictionary<Chalk, List<UnitLineWrapper>> dictionary_0, bool bool_0 = true, int int_0 = -1)
	{
		if (Waves.Count == 0)
		{
			Waves.Add(new TransportWave(this, Waves.Count + 1, landingZoneWrapper_0));
		}
		AddCargoReturnValue addCargoReturnValue = AddCargoReturnValue.Impossible;
		foreach (TransportWave item in Waves.ToList())
		{
			AddCargoReturnValue addCargoReturnValue2 = item.CreateWatcher(chalk_0, landingZoneWrapper_0, dictionary_0);
			if (addCargoReturnValue2 == AddCargoReturnValue.CurrentlyImpossible && addCargoReturnValue == AddCargoReturnValue.Impossible)
			{
				addCargoReturnValue = AddCargoReturnValue.CurrentlyImpossible;
			}
			else if (addCargoReturnValue2 == AddCargoReturnValue.Success && addCargoReturnValue != 0)
			{
				addCargoReturnValue = AddCargoReturnValue.Success;
				break;
			}
		}
		switch (addCargoReturnValue)
		{
		default:
			return AddCargoReturnValue.Impossible;
		case AddCargoReturnValue.Success:
			return addCargoReturnValue;
		case AddCargoReturnValue.CurrentlyImpossible:
			if (bool_0 && Waves.Count < int_0)
			{
				Waves.Add(new TransportWave(this, Waves.Count + 1, landingZoneWrapper_0));
				return Waves.ElementAt(Waves.Count - 1).CreateWatcher(chalk_0, landingZoneWrapper_0, dictionary_0);
			}
			return AddCargoReturnValue.CurrentlyImpossible;
		case AddCargoReturnValue.Impossible:
			return addCargoReturnValue;
		}
	}

	internal AddCargoReturnValue InstantiateWatcher(ChalkUnit chalkUnit_0, bool bool_0 = true, int int_0 = -1)
	{
		if (Waves.Count == 0)
		{
			Waves.Add(new TransportWave(this, Waves.Count + 1, chalkUnit_0.LandingZone));
		}
		AddCargoReturnValue addCargoReturnValue = AddCargoReturnValue.Impossible;
		foreach (TransportWave item in Waves.ToList())
		{
			AddCargoReturnValue addCargoReturnValue2 = item.CompareWatcher(chalkUnit_0);
			if (addCargoReturnValue2 == AddCargoReturnValue.CurrentlyImpossible && addCargoReturnValue == AddCargoReturnValue.Impossible)
			{
				addCargoReturnValue = AddCargoReturnValue.CurrentlyImpossible;
			}
			else if (addCargoReturnValue2 == AddCargoReturnValue.Success && addCargoReturnValue != 0)
			{
				addCargoReturnValue = AddCargoReturnValue.Success;
				break;
			}
		}
		switch (addCargoReturnValue)
		{
		default:
			return AddCargoReturnValue.Impossible;
		case AddCargoReturnValue.Success:
			return addCargoReturnValue;
		case AddCargoReturnValue.CurrentlyImpossible:
			if (bool_0 && Waves.Count < int_0)
			{
				Waves.Add(new TransportWave(this, Waves.Count + 1, chalkUnit_0.LandingZone));
				return Waves.ElementAt(Waves.Count - 1).CompareWatcher(chalkUnit_0);
			}
			return AddCargoReturnValue.CurrentlyImpossible;
		case AddCargoReturnValue.Impossible:
			return addCargoReturnValue;
		}
	}

	public void RemoveCargo(ChalkUnit chalkUnit_0)
	{
		if (CurrentCargo.ContainsKey(chalkUnit_0))
		{
			CurrentCargo.Remove(chalkUnit_0);
		}
	}
}
