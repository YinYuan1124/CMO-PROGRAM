using System;
using System.Runtime.Serialization;

namespace Sharp3D.Math;

[Serializable]
public class MathException : ApplicationException
{
	public MathException()
	{
	}

	public MathException(string string_0)
		: base(string_0)
	{
	}

	public MathException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	protected MathException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}
}
