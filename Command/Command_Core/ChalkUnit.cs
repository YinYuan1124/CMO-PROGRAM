using System.Collections.Generic;

namespace Command_Core;

public class ChalkUnit
{
	public Cargo Unit;

	public Chalk AssociatedChalk;

	public int Priority;

	public LandingZoneWrapper LandingZone;

	public int Wave;

	public Transport CurrentTransport;

	public Dictionary<string, TransportAvailability> TransportAvailable;

	public string TransportErrorMessage;

	public string TransportErrorMessagTooltip;

	public bool IsAmphibious
	{
		get
		{
			if (Unit.CurrentType == Cargo.CargoObjectType.Vehicle && ((Vehicle)Unit.CargoObjectActiveUnit).IsOutOfFuel)
			{
				return true;
			}
			return false;
		}
	}

	internal bool CallImporter(Transport transport_0)
	{
		if (LandingZone == null)
		{
			return false;
		}
		if (LandingZone.LandingZoneType == LandingType.Unassigned)
		{
			return false;
		}
		return transport_0.LandingType == LandingZone.LandingZoneType;
	}

	internal bool LogoutImporter(ActiveUnit activeUnit_0)
	{
		if (LandingZone == null)
		{
			return false;
		}
		LandingType landingType = ((activeUnit_0.IsBoat || activeUnit_0.IsShip) ? LandingType.Amphibious : (activeUnit_0.IsAircraft ? LandingType.Airborne : LandingType.Unassigned));
		if (LandingZone.LandingZoneType == LandingType.Unassigned)
		{
			return false;
		}
		return landingType == LandingZone.LandingZoneType;
	}

	public ChalkUnit(Chalk chalk_0, Cargo cargo_0, int int_0, int int_1, ActiveUnit activeUnit_0, bool bool_0, LandingZoneWrapper landingZoneWrapper_0)
	{
		TransportAvailable = new Dictionary<string, TransportAvailability>();
		TransportErrorMessage = "";
		TransportErrorMessagTooltip = "";
		Unit = cargo_0;
		AssociatedChalk = chalk_0;
		Wave = int_1;
		LandingZone = landingZoneWrapper_0;
	}

	public ChalkUnit(Cargo cargo_0)
	{
		TransportAvailable = new Dictionary<string, TransportAvailability>();
		TransportErrorMessage = "";
		TransportErrorMessagTooltip = "";
		Unit = cargo_0;
	}
}
