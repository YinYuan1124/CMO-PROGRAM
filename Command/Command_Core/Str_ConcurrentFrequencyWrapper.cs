using System.Collections.Generic;

namespace Command_Core;

public sealed class Str_ConcurrentFrequencyWrapper
{
	public Dictionary<Sensor.FrequencyBand, Sensor.FrequencyBand> NonNatoFrequencies;

	public Str_ConcurrentFrequencyWrapper()
	{
		NonNatoFrequencies = new Dictionary<Sensor.FrequencyBand, Sensor.FrequencyBand>();
	}
}
