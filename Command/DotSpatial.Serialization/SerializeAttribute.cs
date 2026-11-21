using System;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class SerializeAttribute : Attribute
{
	[CompilerGenerated]
	private string m_ConsumerObject;

	[CompilerGenerated]
	private Type proxyObject;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerObject;
		}
		[CompilerGenerated]
		private set
		{
			m_ConsumerObject = value;
		}
	}

	public int ConstructorArgumentIndex { get; set; }

	public Type Formatter
	{
		[CompilerGenerated]
		get
		{
			return proxyObject;
		}
		[CompilerGenerated]
		set
		{
			proxyObject = value;
		}
	}

	public SerializeAttribute(string string_0)
	{
		Name = string_0;
		ConstructorArgumentIndex = -1;
	}
}
