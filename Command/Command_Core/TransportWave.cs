using System.Collections.Generic;
using System.Linq;

namespace Command_Core;

public class TransportWave
{
	public Transport AssociatedTransport;

	public Dictionary<ChalkUnit, ChalkUnit> UnitsInWave;

	public int Wave;

	public CargoMission AssociatedMission;

	public bool IsFirstWave;

	public bool Complete;

	public LandingZoneWrapper LandingZone;

	public TransportWave(Transport transport_0, int int_0, LandingZoneWrapper landingZoneWrapper_0)
	{
		UnitsInWave = new Dictionary<ChalkUnit, ChalkUnit>();
		LandingZone = landingZoneWrapper_0;
		AssociatedTransport = transport_0;
		Wave = int_0;
	}

	internal AddCargoReturnValue CreateWatcher(Chalk chalk_0, LandingZoneWrapper landingZoneWrapper_0, Dictionary<Chalk, List<UnitLineWrapper>> dictionary_0)
	{
		if (Complete)
		{
			return AddCargoReturnValue.CurrentlyImpossible;
		}
		float num = AssociatedTransport.AreaCapacity - DisableWatcher();
		float num2 = AssociatedTransport.MassCapacity - UpdateWatcher();
		float num3 = AssociatedTransport.CrewCapacity - InsertWatcher();
		string transportErrorMessage = "";
		AddCargoReturnValue addCargoReturnValue;
		if (chalk_0.DestroyImporter() <= AssociatedTransport.MaxSize)
		{
			if (chalk_0.SelectImporter() <= AssociatedTransport.CrewCapacity)
			{
				if (chalk_0.PatchImporter() <= AssociatedTransport.AreaCapacity)
				{
					if (chalk_0.ComputeImporter() <= AssociatedTransport.MassCapacity)
					{
						addCargoReturnValue = AddCargoReturnValue.Success;
					}
					else
					{
						transportErrorMessage = "Exceeds max mass";
						addCargoReturnValue = AddCargoReturnValue.Impossible;
					}
				}
				else
				{
					transportErrorMessage = "Exceeds max area";
					addCargoReturnValue = AddCargoReturnValue.Impossible;
				}
			}
			else
			{
				transportErrorMessage = "Exceeds max PAX";
				addCargoReturnValue = AddCargoReturnValue.Impossible;
			}
		}
		else
		{
			transportErrorMessage = "Exceeds max cargo size";
			addCargoReturnValue = AddCargoReturnValue.Impossible;
		}
		if (addCargoReturnValue == AddCargoReturnValue.Impossible)
		{
			foreach (UnitLineWrapper item in dictionary_0[chalk_0])
			{
				item.ChalkUnit.TransportErrorMessage = transportErrorMessage;
			}
			return AddCargoReturnValue.Impossible;
		}
		if (landingZoneWrapper_0 == LandingZone && chalk_0.PatchImporter() <= num && chalk_0.SelectImporter() <= num3 && chalk_0.ComputeImporter() <= num2)
		{
			foreach (UnitLineWrapper item2 in dictionary_0[chalk_0])
			{
				if (!UnitsInWave.ContainsKey(item2.ChalkUnit))
				{
					item2.ChalkUnit.TransportErrorMessage = transportErrorMessage;
					UnitsInWave.Add(item2.ChalkUnit, item2.ChalkUnit);
					item2.ChalkUnit.CurrentTransport = AssociatedTransport;
					item2.ChalkUnit.Wave = Wave;
				}
			}
			return AddCargoReturnValue.Success;
		}
		return AddCargoReturnValue.CurrentlyImpossible;
	}

	internal AddCargoReturnValue CompareWatcher(ChalkUnit chalkUnit_0)
	{
		if (Complete)
		{
			return AddCargoReturnValue.CurrentlyImpossible;
		}
		float num = AssociatedTransport.AreaCapacity - DisableWatcher();
		float num2 = AssociatedTransport.MassCapacity - UpdateWatcher();
		float num3 = AssociatedTransport.CrewCapacity - InsertWatcher();
		chalkUnit_0.TransportErrorMessage = "";
		if (chalkUnit_0.Unit.RequiredCargoType <= AssociatedTransport.MaxSize)
		{
			if (chalkUnit_0.Unit.RequiredCrewSpace <= AssociatedTransport.CrewCapacity)
			{
				if (chalkUnit_0.Unit.RequiredArea <= AssociatedTransport.AreaCapacity)
				{
					if (chalkUnit_0.Unit.RequiredMass <= AssociatedTransport.MassCapacity)
					{
						if (chalkUnit_0.LandingZone == LandingZone && chalkUnit_0.Unit.RequiredArea <= num && chalkUnit_0.Unit.RequiredCrewSpace <= num3 && chalkUnit_0.Unit.RequiredMass <= num2)
						{
							if (UnitsInWave.ContainsKey(chalkUnit_0))
							{
								return AddCargoReturnValue.Impossible;
							}
							UnitsInWave.Add(chalkUnit_0, chalkUnit_0);
							chalkUnit_0.CurrentTransport = AssociatedTransport;
							chalkUnit_0.Wave = Wave;
							return AddCargoReturnValue.Success;
						}
						return AddCargoReturnValue.CurrentlyImpossible;
					}
					chalkUnit_0.TransportErrorMessage = "Exceeds max mass";
					return AddCargoReturnValue.Impossible;
				}
				chalkUnit_0.TransportErrorMessage = "Exceeds max area";
				return AddCargoReturnValue.Impossible;
			}
			chalkUnit_0.TransportErrorMessage = "Exceeds max PAX";
			return AddCargoReturnValue.Impossible;
		}
		chalkUnit_0.TransportErrorMessage = "Exceeds max cargo size";
		return AddCargoReturnValue.Impossible;
	}

	internal Zone ReadWatcher()
	{
		if (UnitsInWave.Count == 0)
		{
			return null;
		}
		return UnitsInWave.Keys.ElementAt(0).LandingZone.LandingZone;
	}

	internal float DisableWatcher()
	{
		float num = 0f;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in UnitsInWave)
		{
			num += item.Value.Unit.RequiredArea;
		}
		return num;
	}

	internal float UpdateWatcher()
	{
		float num = 0f;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in UnitsInWave)
		{
			num += item.Value.Unit.RequiredMass;
		}
		return num;
	}

	internal float InsertWatcher()
	{
		float num = 0f;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in UnitsInWave)
		{
			num += item.Value.Unit.RequiredCrewSpace;
		}
		return num;
	}
}
