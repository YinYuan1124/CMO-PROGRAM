using System.Management;

namespace CSMaterial;

public static class VMDetector2
{
	public static bool RunningInVm()
	{
		return new ManagementObjectSearcher("SELECT * FROM Win32_PortConnector").Get().Count == 0;
	}
}
