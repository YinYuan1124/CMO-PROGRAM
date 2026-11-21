using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using Command.Records;
using SmartAssembly.Attributes;

[DoNotPrune]
[DoNotObfuscateType]
[DoNotPruneType]
public sealed class VirtualMachineDetector
{
	[CompilerGenerated]
	private sealed class MessageProcessResolver
	{
		public string[] string_0;

		internal bool AddInterruptibleTemplate(Facade c)
		{
			return c.ChangeInterruptibleBroadcaster(m_Connection, m_Context, _Proccesor, _Strategy, string_0, configuration);
		}
	}

	private static Facade[] code;

	private static ComputerSystem m_Connection;

	private static BIOS m_Context;

	private static MotherboardDevice m_Status;

	private static IEnumerable<DiskDrive> _Proccesor;

	private static IEnumerable<PnPEntity> _Strategy;

	private static IEnumerable<WindowsService> configuration;

	[DoNotPrune]
	static VirtualMachineDetector()
	{
		code = new Facade[4]
		{
			new VmWarePlayer(),
			new HyperVMachine(),
			new QEmuMachine(),
			new VirtualBoxMachine()
		};
		m_Connection = InsertStruct<ComputerSystem>("Win32_ComputerSystem");
		m_Context = InsertStruct<BIOS>("Win32_BIOS");
		m_Status = InsertStruct<MotherboardDevice>("Win32_MotherboardDevice");
		_Strategy = PrepareStruct<PnPEntity>("Win32_PnPEntity");
		_Proccesor = PrepareStruct<DiskDrive>("Win32_DiskDrive");
		configuration = UpdateStruct();
	}

	public static bool Assert(out string string_0)
	{
		string[] string_ = (from p in Process.GetProcesses()
			select p.ProcessName.ToLower() into p
			orderby p
			select p).ToArray();
		Facade facade = code.FirstOrDefault((Facade c) => c.ChangeInterruptibleBroadcaster(m_Connection, m_Context, _Proccesor, _Strategy, string_, configuration));
		bool flag = facade != null;
		string_0 = (flag ? facade.Name : null);
		return flag;
	}

	public static bool Assert()
	{
		string string_;
		return Assert(out string_);
	}

	private static IEnumerable<WindowsService> UpdateStruct()
	{
		return (from s in ServiceController.GetServices()
			select new WindowsService(s) into s
			orderby s.Name
			select s).ToArray();
	}

	private static T InsertStruct<T>(string string_0)
	{
		using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = new ManagementClass(string_0).GetInstances().GetEnumerator())
		{
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementBaseObject current = managementObjectEnumerator.Current;
				return (T)Activator.CreateInstance(typeof(T), current);
			}
		}
		return default(T);
	}

	private static List<T> PrepareStruct<T>(string string_0)
	{
		ManagementClass managementClass = new ManagementClass(string_0);
		List<T> list = new List<T>();
		foreach (ManagementBaseObject instance in managementClass.GetInstances())
		{
			list.Add((T)Activator.CreateInstance(typeof(T), instance));
		}
		return list;
	}
}
