using System.Management;
using System.Runtime.CompilerServices;
using SmartAssembly.Attributes;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
internal class ComputerSystem : BaseWin32Entity
{
	[CompilerGenerated]
	private string expression;

	public string OEMStringArray
	{
		[CompilerGenerated]
		get
		{
			return expression;
		}
		[CompilerGenerated]
		set
		{
			expression = value;
		}
	}

	public ComputerSystem(ManagementBaseObject managementBaseObject_0)
		: base(managementBaseObject_0)
	{
		object obj = managementBaseObject_0["OEMStringArray"];
		if (obj != null)
		{
			OEMStringArray = ConnectStruct(obj).ToLower();
		}
	}

	public override string ToString()
	{
		return CustomizeStruct();
	}
}
