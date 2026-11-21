using System;
using System.Runtime.Serialization;

namespace Sharp3D.Math.Core;

[Serializable]
public sealed class ParseException : ApplicationException
{
	public ParseException()
	{
	}

	public ParseException(string string_0)
		: base(string_0)
	{
	}

	public ParseException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	protected ParseException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}
}
