using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace OpenDis.Core;

public class EnumNotFoundException : Exception
{
	[CompilerGenerated]
	private Type m_TagCallback;

	public Type EnumType
	{
		[CompilerGenerated]
		get
		{
			return m_TagCallback;
		}
		[CompilerGenerated]
		private set
		{
			m_TagCallback = value;
		}
	}

	public EnumNotFoundException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	private EnumNotFoundException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}

	public EnumNotFoundException(string string_0, Type type_0)
		: base(string_0)
	{
		EnumType = type_0;
	}

	public EnumNotFoundException(string string_0)
		: base(string_0)
	{
	}

	public EnumNotFoundException()
	{
	}
}
