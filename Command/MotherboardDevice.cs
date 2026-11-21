using System.Management;
using SmartAssembly.Attributes;

[DoNotPrune]
[DoNotObfuscateType]
[DoNotPruneType]
internal class MotherboardDevice : BaseWin32Entity
{
	public MotherboardDevice(ManagementBaseObject managementBaseObject_0)
		: base(managementBaseObject_0)
	{
	}

	public override string ToString()
	{
		return CustomizeStruct();
	}
}
