using System.Management;
using SmartAssembly.Attributes;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
internal class DiskDrive : BaseWin32Entity
{
	public DiskDrive(ManagementBaseObject managementBaseObject_0)
		: base(managementBaseObject_0)
	{
	}
}
