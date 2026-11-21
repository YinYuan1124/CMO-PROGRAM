using System;

namespace DotSpatial.Topology;

public static class Location
{
	public static char ToLocationSymbol(LocationType locationType_0)
	{
		if (1 == 0)
		{
		}
		char result = locationType_0 switch
		{
			LocationType.Null => '-', 
			LocationType.Interior => 'i', 
			LocationType.Boundary => 'b', 
			LocationType.Exterior => 'e', 
			_ => throw new ArgumentException("Unknown location value: " + locationType_0), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
