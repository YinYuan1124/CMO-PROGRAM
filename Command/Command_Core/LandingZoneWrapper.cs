using Command_Core.SmartAssembly.Attributes;

namespace Command_Core;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
public class LandingZoneWrapper
{
	public Zone LandingZone;

	public LandingType LandingZoneType;

	public LandingZoneWrapper(Zone zone_0, LandingType landingType_0)
	{
		LandingZone = zone_0;
		LandingZoneType = landingType_0;
	}
}
