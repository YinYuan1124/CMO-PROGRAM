using System;
using System.Runtime.Serialization;

namespace DotSpatial.Serialization;

[Obsolete("Do not use it. This class is not used in DotSpatial anymore.")]
public class AssemblyMissingException : Exception
{
	public AssemblyMissingException(string string_0)
		: base(string_0)
	{
	}

	public AssemblyMissingException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	public AssemblyMissingException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}
}
