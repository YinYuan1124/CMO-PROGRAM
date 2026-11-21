using System;
using System.Runtime.Serialization;

namespace Zeptomoby.OrbitTools;

[Serializable]
public class PropagationException : Exception
{
	public PropagationException()
	{
	}

	public PropagationException(string string_0)
		: base(string_0)
	{
	}

	public PropagationException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	protected PropagationException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}
}
