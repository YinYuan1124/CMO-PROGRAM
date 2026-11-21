using System.Collections.Generic;
using Command_Core;

namespace Command;

public class LandingPlan_ImportWrapper
{
	public Dictionary<Zone, LandingZoneWrapper> LandingZones;

	public ActiveUnit Mothership;

	public List<ActiveUnit> AllowedTransports;

	public HashSet<string> AllowedTransportClasses;

	public List<Chalk> Serials;

	public Dictionary<Chalk, Zone> SerialToZoneAssociation;

	public Dictionary<Chalk, int> SerialToPriority;

	public Dictionary<string, HashSet<string>> SerialAllowedTransportClasses;

	public Dictionary<ActiveUnit, Zone> Preboated;

	public LandingPlan_ImportWrapper()
	{
		LandingZones = new Dictionary<Zone, LandingZoneWrapper>();
		AllowedTransports = new List<ActiveUnit>();
		AllowedTransportClasses = new HashSet<string>();
		Serials = new List<Chalk>();
		SerialToZoneAssociation = new Dictionary<Chalk, Zone>();
		SerialToPriority = new Dictionary<Chalk, int>();
		SerialAllowedTransportClasses = new Dictionary<string, HashSet<string>>();
		Preboated = new Dictionary<ActiveUnit, Zone>();
	}

	public LandingPlan_ImportWrapper(ActiveUnit activeUnit_0, List<ActiveUnit> list_0, List<Chalk> list_1, Dictionary<Zone, LandingZoneWrapper> dictionary_0, Dictionary<Chalk, Zone> dictionary_1)
	{
		LandingZones = new Dictionary<Zone, LandingZoneWrapper>();
		AllowedTransports = new List<ActiveUnit>();
		AllowedTransportClasses = new HashSet<string>();
		Serials = new List<Chalk>();
		SerialToZoneAssociation = new Dictionary<Chalk, Zone>();
		SerialToPriority = new Dictionary<Chalk, int>();
		SerialAllowedTransportClasses = new Dictionary<string, HashSet<string>>();
		Preboated = new Dictionary<ActiveUnit, Zone>();
		Mothership = activeUnit_0;
		AllowedTransports = list_0;
		Serials = list_1;
		LandingZones = dictionary_0;
		SerialToZoneAssociation = dictionary_1;
	}
}
