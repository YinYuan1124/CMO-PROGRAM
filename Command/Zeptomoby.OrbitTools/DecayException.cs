using System;
using System.Runtime.Serialization;

namespace Zeptomoby.OrbitTools;

[Serializable]
public sealed class DecayException : PropagationException
{
	public DateTime DecayTime { get; private set; }

	public string SatelliteName { get; private set; }

	public DecayException()
	{
	}

	public DecayException(string string_0)
		: base(string_0)
	{
	}

	public DecayException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	public DecayException(Julian julian_0, string string_0)
		: this(julian_0.ToTime(), string_0)
	{
	}

	public DecayException(DateTime dateTime_0, string string_0)
	{
		DecayTime = dateTime_0;
		SatelliteName = string_0;
	}

	private DecayException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}
}
