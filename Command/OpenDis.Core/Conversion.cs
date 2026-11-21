namespace OpenDis.Core;

public static class Conversion
{
	public const int ARTICULATION_PARAMETER_TYPE_METRIC_MASK = 31;

	public const byte ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS = 5;

	public static int GetArticulationTypeClass(int int_0)
	{
		return int_0 >> 5;
	}

	public static int GetArticulationTypeMetric(int int_0)
	{
		return int_0 & 0x1F;
	}

	public static uint MakeArticulationParameterType(uint uint_0, uint uint_1)
	{
		uint_1 &= 0x1Fu;
		return (uint_0 << 5) + uint_1;
	}
}
