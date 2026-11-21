using System;

namespace DotSpatial.Topology;

public class Dimension
{
	private Dimension()
	{
	}

	public static char ToDimensionSymbol(DimensionType dimensionType_0)
	{
		if (1 == 0)
		{
		}
		char result = dimensionType_0 switch
		{
			DimensionType.Dontcare => '*', 
			DimensionType.True => 'T', 
			DimensionType.False => 'F', 
			DimensionType.Point => '0', 
			DimensionType.Curve => '1', 
			DimensionType.Surface => '2', 
			_ => throw new ArgumentOutOfRangeException("Unknown dimension value: " + dimensionType_0), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static DimensionType ToDimensionValue(char char_0)
	{
		char c = char.ToUpper(char_0);
		if (1 == 0)
		{
		}
		DimensionType result = c switch
		{
			'0' => DimensionType.Point, 
			'1' => DimensionType.Curve, 
			'2' => DimensionType.Surface, 
			'*' => DimensionType.Dontcare, 
			'T' => DimensionType.True, 
			'F' => DimensionType.False, 
			_ => throw new ArgumentOutOfRangeException("Unknown dimension symbol: " + char_0), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
