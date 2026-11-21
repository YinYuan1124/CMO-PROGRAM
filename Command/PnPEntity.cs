using System.Management;
using SmartAssembly.Attributes;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
internal class PnPEntity : BaseWin32Entity
{
	public PnPEntity(ManagementBaseObject managementBaseObject_0)
		: base(managementBaseObject_0)
	{
	}
}
