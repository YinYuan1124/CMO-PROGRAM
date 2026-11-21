using System;
using System.Runtime.Serialization;

namespace Sharp3D.Math;

[Serializable]
public sealed class QuaternionNotInvertibleException : MathException
{
	public QuaternionNotInvertibleException()
	{
	}

	public QuaternionNotInvertibleException(string string_0)
		: base(string_0)
	{
	}

	public QuaternionNotInvertibleException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	protected QuaternionNotInvertibleException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}
}
