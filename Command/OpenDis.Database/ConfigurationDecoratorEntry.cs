using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenDis.Database;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
[ComVisible(true)]
internal sealed class ConfigurationDecoratorEntry : Attribute
{
	private bool m_FieldMapping = true;

	private bool _QueueMapping = true;

	private bool m_RegMapping = true;

	private string paramMapping = "";

	[SpecialName]
	public bool ComputeInterruptibleBroadcaster()
	{
		return m_FieldMapping;
	}

	[SpecialName]
	public void PatchInterruptibleBroadcaster(bool bool_0)
	{
		m_FieldMapping = bool_0;
	}

	[SpecialName]
	public bool CallInterruptibleBroadcaster()
	{
		return _QueueMapping;
	}

	[SpecialName]
	public void LogoutInterruptibleBroadcaster(bool bool_0)
	{
		_QueueMapping = bool_0;
	}

	[SpecialName]
	public string ValidateInterruptibleBroadcaster()
	{
		return paramMapping;
	}

	[SpecialName]
	public void LoginInterruptibleBroadcaster(string string_0)
	{
		paramMapping = string_0;
	}

	[SpecialName]
	public bool WriteInterruptibleBroadcaster()
	{
		return m_RegMapping;
	}

	[SpecialName]
	public void NewInterruptibleBroadcaster(bool bool_0)
	{
		m_RegMapping = bool_0;
	}
}
