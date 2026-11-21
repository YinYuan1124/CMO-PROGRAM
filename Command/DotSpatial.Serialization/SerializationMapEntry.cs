using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

public class SerializationMapEntry
{
	[CompilerGenerated]
	private MemberInfo m_ClientObject;

	[CompilerGenerated]
	private SerializeAttribute m_DicObject;

	public MemberInfo Member
	{
		[CompilerGenerated]
		get
		{
			return m_ClientObject;
		}
		[CompilerGenerated]
		private set
		{
			m_ClientObject = value;
		}
	}

	public SerializeAttribute Attribute
	{
		[CompilerGenerated]
		get
		{
			return m_DicObject;
		}
		[CompilerGenerated]
		private set
		{
			m_DicObject = value;
		}
	}

	public SerializationMapEntry(MemberInfo memberInfo_0, SerializeAttribute serializeAttribute_0)
	{
		Member = memberInfo_0;
		Attribute = serializeAttribute_0;
	}

	public SerializationMapEntry AsConstructorArgument(int int_0)
	{
		Attribute.ConstructorArgumentIndex = int_0;
		return this;
	}

	public SerializationMapEntry WithFormatterType(Type type_0)
	{
		Attribute.Formatter = type_0;
		return this;
	}

	public override bool Equals(object obj)
	{
		if (obj is SerializationMapEntry serializationMapEntry)
		{
			if (serializationMapEntry.Member == Member)
			{
				return serializationMapEntry.Attribute == Attribute;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Member.GetHashCode() ^ Attribute.GetHashCode();
	}
}
