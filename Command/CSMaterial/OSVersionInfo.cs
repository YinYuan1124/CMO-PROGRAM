using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CSMaterial;

public static class OSVersionInfo
{
	public enum SoftwareArchitecture
	{
		Unknown,
		Bit32,
		Bit64
	}

	public enum ProcessorArchitecture
	{
		Unknown,
		Bit32,
		Bit64,
		const_3
	}

	private delegate bool AttrCallbackCandidate([In] IntPtr handle, out bool isWow64Process);

	private struct InitializerCollectionRecord
	{
		public int pagePrototype;

		public int m_RulesPrototype;

		public int m_MethodPrototype;

		public int _ServicePrototype;

		public int m_SystemPrototype;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string candidatePrototype;

		public short basePrototype;

		public short policyPrototype;

		public short broadcasterPrototype;

		public byte identifierPrototype;

		public byte printerPrototype;
	}

	public struct SYSTEM_INFO
	{
		internal _PROCESSOR_INFO_UNION parserPrototype;

		public uint dwPageSize;

		public IntPtr lpMinimumApplicationAddress;

		public IntPtr lpMaximumApplicationAddress;

		public IntPtr dwActiveProcessorMask;

		public uint dwNumberOfProcessors;

		public uint dwProcessorType;

		public uint dwAllocationGranularity;

		public ushort dwProcessorLevel;

		public ushort dwProcessorRevision;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct _PROCESSOR_INFO_UNION
	{
		[FieldOffset(0)]
		internal uint algoPrototype;

		[FieldOffset(0)]
		internal ushort databasePrototype;

		[FieldOffset(2)]
		internal ushort _InterceptorPrototype;
	}

	private static string _StubDispatcher;

	private static string _WriterDispatcher;

	public static SoftwareArchitecture ProgramBits
	{
		get
		{
			Environment.GetEnvironmentVariables();
			int num = IntPtr.Size * 8;
			if (1 == 0)
			{
			}
			SoftwareArchitecture result = num switch
			{
				64 => SoftwareArchitecture.Bit64, 
				32 => SoftwareArchitecture.Bit32, 
				_ => SoftwareArchitecture.Unknown, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public static SoftwareArchitecture OSBits
	{
		get
		{
			switch (IntPtr.Size * 8)
			{
			default:
				return SoftwareArchitecture.Unknown;
			case 64:
				return SoftwareArchitecture.Bit64;
			case 32:
				if (CreateDefinition())
				{
					return SoftwareArchitecture.Bit64;
				}
				return SoftwareArchitecture.Bit32;
			}
		}
	}

	public static ProcessorArchitecture ProcessorBits
	{
		get
		{
			ProcessorArchitecture result = ProcessorArchitecture.Unknown;
			try
			{
				SYSTEM_INFO system_INFO_ = default(SYSTEM_INFO);
				GetNativeSystemInfo(ref system_INFO_);
				switch (system_INFO_.parserPrototype.databasePrototype)
				{
				default:
					result = ProcessorArchitecture.Unknown;
					return ProcessorArchitecture.Unknown;
				case 9:
					result = ProcessorArchitecture.Bit64;
					return ProcessorArchitecture.Bit64;
				case 6:
					result = ProcessorArchitecture.const_3;
					return ProcessorArchitecture.const_3;
				case 0:
					result = ProcessorArchitecture.Bit32;
					return ProcessorArchitecture.Bit32;
				}
			}
			catch
			{
				return result;
			}
		}
	}

	public static string Edition
	{
		get
		{
			if (_StubDispatcher == null)
			{
				string text = string.Empty;
				OperatingSystem oSVersion = Environment.OSVersion;
				InitializerCollectionRecord initializerCollectionRecord_ = default(InitializerCollectionRecord);
				initializerCollectionRecord_.pagePrototype = Marshal.SizeOf(typeof(InitializerCollectionRecord));
				if (GetVersionEx(ref initializerCollectionRecord_))
				{
					int major = oSVersion.Version.Major;
					int minor = oSVersion.Version.Minor;
					byte identifierPrototype = initializerCollectionRecord_.identifierPrototype;
					short broadcasterPrototype = initializerCollectionRecord_.broadcasterPrototype;
					switch (major)
					{
					case 4:
						switch (identifierPrototype)
						{
						case 3:
							text = (((broadcasterPrototype & 2) == 0) ? "Standard Server" : "Enterprise Server");
							break;
						case 1:
							text = "Workstation";
							break;
						}
						break;
					case 5:
						switch (identifierPrototype)
						{
						case 3:
							text = ((minor == 0) ? ((((uint)broadcasterPrototype & 0x80u) != 0) ? "Datacenter Server" : (((broadcasterPrototype & 2) == 0) ? "Server" : "Advanced Server")) : ((((uint)broadcasterPrototype & 0x80u) != 0) ? "Datacenter" : ((((uint)broadcasterPrototype & 2u) != 0) ? "Enterprise" : (((broadcasterPrototype & 0x400) == 0) ? "Standard" : "Web Edition"))));
							break;
						case 1:
							text = ((((uint)broadcasterPrototype & 0x200u) != 0) ? "Home" : ((GetSystemMetrics(86) == 0) ? "Professional" : "Tablet Edition"));
							break;
						}
						break;
					case 6:
					{
						if (GetProductInfo(major, minor, initializerCollectionRecord_.basePrototype, initializerCollectionRecord_.policyPrototype, out var int_))
						{
							switch (int_)
							{
							case 0:
								text = "Unknown product";
								break;
							case 1:
								text = "Ultimate";
								break;
							case 2:
								text = "Home Basic";
								break;
							case 3:
								text = "Home Premium";
								break;
							case 4:
								text = "Enterprise";
								break;
							case 5:
								text = "Home Basic N";
								break;
							case 6:
								text = "Business";
								break;
							case 7:
								text = "Standard Server";
								break;
							case 8:
								text = "Datacenter Server";
								break;
							case 9:
								text = "Windows Small Business Server";
								break;
							case 10:
								text = "Enterprise Server";
								break;
							case 11:
								text = "Starter";
								break;
							case 12:
								text = "Datacenter Server (core installation)";
								break;
							case 13:
								text = "Standard Server (core installation)";
								break;
							case 14:
								text = "Enterprise Server (core installation)";
								break;
							case 15:
								text = "Enterprise Server for Itanium-based Systems";
								break;
							case 16:
								text = "Business N";
								break;
							case 17:
								text = "Web Server";
								break;
							case 18:
								text = "HPC Edition";
								break;
							case 20:
								text = "Express Storage Server";
								break;
							case 21:
								text = "Standard Storage Server";
								break;
							case 22:
								text = "Workgroup Storage Server";
								break;
							case 23:
								text = "Enterprise Storage Server";
								break;
							case 24:
								text = "Windows Essential Server Solutions";
								break;
							case 25:
								text = "Windows Small Business Server Premium";
								break;
							case 26:
								text = "Home Premium N";
								break;
							case 27:
								text = "Enterprise N";
								break;
							case 28:
								text = "Ultimate N";
								break;
							case 29:
								text = "Web Server (core installation)";
								break;
							case 30:
								text = "Windows Essential Business Management Server";
								break;
							case 31:
								text = "Windows Essential Business Security Server";
								break;
							case 32:
								text = "Windows Essential Business Messaging Server";
								break;
							case 33:
								text = "Server Foundation";
								break;
							case 34:
								text = "Home Premium Server";
								break;
							case 35:
								text = "Windows Essential Server Solutions without Hyper-V";
								break;
							case 36:
								text = "Standard Server without Hyper-V";
								break;
							case 37:
								text = "Datacenter Server without Hyper-V";
								break;
							case 38:
								text = "Enterprise Server without Hyper-V";
								break;
							case 39:
								text = "Datacenter Server without Hyper-V (core installation)";
								break;
							case 40:
								text = "Standard Server without Hyper-V (core installation)";
								break;
							case 41:
								text = "Enterprise Server without Hyper-V (core installation)";
								break;
							case 42:
								text = "Microsoft Hyper-V Server";
								break;
							case 43:
								text = "Express Storage Server (core installation)";
								break;
							case 44:
								text = "Standard Storage Server (core installation)";
								break;
							case 45:
								text = "Workgroup Storage Server (core installation)";
								break;
							case 46:
								text = "Enterprise Storage Server (core installation)";
								break;
							case 47:
								text = "Starter N";
								break;
							case 48:
								text = "Professional";
								break;
							case 49:
								text = "Professional N";
								break;
							case 50:
								text = "SB Solution Server";
								break;
							case 51:
								text = "Server for SB Solutions";
								break;
							case 52:
								text = "Standard Server Solutions";
								break;
							case 53:
								text = "Standard Server Solutions (core installation)";
								break;
							case 54:
								text = "SB Solution Server EM";
								break;
							case 55:
								text = "Server for SB Solutions EM";
								break;
							case 56:
								text = "Solution Embedded Server";
								break;
							case 57:
								text = "Solution Embedded Server (core installation)";
								break;
							case 59:
								text = "Essential Business Server MGMT";
								break;
							case 60:
								text = "Essential Business Server ADDL";
								break;
							case 61:
								text = "Essential Business Server MGMTSVC";
								break;
							case 62:
								text = "Essential Business Server ADDLSVC";
								break;
							case 63:
								text = "Windows Small Business Server Premium (core installation)";
								break;
							case 64:
								text = "HPC Edition without Hyper-V";
								break;
							case 65:
								text = "Embedded";
								break;
							case 66:
								text = "Starter E";
								break;
							case 67:
								text = "Home Basic E";
								break;
							case 68:
								text = "Home Premium E";
								break;
							case 69:
								text = "Professional E";
								break;
							case 70:
								text = "Enterprise E";
								break;
							case 71:
								text = "Ultimate E";
								break;
							}
						}
						break;
					}
					}
				}
				_StubDispatcher = text;
				return text;
			}
			return _StubDispatcher;
		}
	}

	public static string Name
	{
		get
		{
			if (_WriterDispatcher == null)
			{
				string text = "unknown";
				OperatingSystem oSVersion = Environment.OSVersion;
				InitializerCollectionRecord initializerCollectionRecord_ = default(InitializerCollectionRecord);
				initializerCollectionRecord_.pagePrototype = Marshal.SizeOf(typeof(InitializerCollectionRecord));
				if (GetVersionEx(ref initializerCollectionRecord_))
				{
					int num = oSVersion.Version.Major;
					int num2 = oSVersion.Version.Minor;
					if (num == 6 && num2 == 2)
					{
						string text2 = DisableDefinition("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentVersion", "");
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split('.');
							num = Convert.ToInt32(array[0]);
							num2 = Convert.ToInt32(array[1]);
						}
						if (CompareDefinition())
						{
							num = 10;
							num2 = 0;
						}
						if (ReadDefinition())
						{
							num = 11;
							num2 = 0;
						}
					}
					switch (oSVersion.Platform)
					{
					case PlatformID.Win32S:
						text = "Windows 3.1";
						break;
					case PlatformID.Win32Windows:
						if (num == 4)
						{
							string candidatePrototype = initializerCollectionRecord_.candidatePrototype;
							switch (num2)
							{
							case 90:
								text = "Windows Me";
								break;
							case 10:
								text = ((candidatePrototype == "A") ? "Windows 98 Second Edition" : "Windows 98");
								break;
							case 0:
								text = ((candidatePrototype == "B" || candidatePrototype == "C") ? "Windows 95 OSR2" : "Windows 95");
								break;
							}
						}
						break;
					case PlatformID.Win32NT:
					{
						byte identifierPrototype = initializerCollectionRecord_.identifierPrototype;
						switch (num)
						{
						case 3:
							text = "Windows NT 3.51";
							break;
						case 4:
							switch (identifierPrototype)
							{
							case 3:
								text = "Windows NT 4.0 Server";
								break;
							case 1:
								text = "Windows NT 4.0";
								break;
							}
							break;
						case 5:
							switch (num2)
							{
							case 0:
								text = "Windows 2000";
								break;
							case 1:
								text = "Windows XP";
								break;
							case 2:
								text = "Windows Server 2003";
								break;
							}
							break;
						case 6:
							switch (num2)
							{
							case 0:
								switch (identifierPrototype)
								{
								case 3:
									text = "Windows Server 2008";
									break;
								case 1:
									text = "Windows Vista";
									break;
								}
								break;
							case 1:
								switch (identifierPrototype)
								{
								case 3:
									text = "Windows Server 2008 R2";
									break;
								case 1:
									text = "Windows 7";
									break;
								}
								break;
							case 2:
								switch (identifierPrototype)
								{
								case 3:
									text = "Windows Server 2012";
									break;
								case 1:
									text = "Windows 8";
									break;
								}
								break;
							case 3:
								switch (identifierPrototype)
								{
								case 3:
									text = "Windows Server 2012 R2";
									break;
								case 1:
									text = "Windows 8.1";
									break;
								}
								break;
							}
							break;
						case 10:
							if (num2 == 0)
							{
								switch (identifierPrototype)
								{
								case 3:
									text = "Windows Server 2016";
									break;
								case 1:
									text = "Windows 10";
									break;
								}
							}
							break;
						case 11:
							if (num2 == 0)
							{
								switch (identifierPrototype)
								{
								case 3:
									text = "Windows Server 2022+";
									break;
								case 1:
									text = "Windows 11";
									break;
								}
							}
							break;
						}
						break;
					}
					case PlatformID.WinCE:
						text = "Windows CE";
						break;
					}
				}
				_WriterDispatcher = text;
				return text;
			}
			return _WriterDispatcher;
		}
	}

	public static string ServicePack
	{
		get
		{
			string result = string.Empty;
			InitializerCollectionRecord initializerCollectionRecord_ = default(InitializerCollectionRecord);
			initializerCollectionRecord_.pagePrototype = Marshal.SizeOf(typeof(InitializerCollectionRecord));
			if (GetVersionEx(ref initializerCollectionRecord_))
			{
				result = initializerCollectionRecord_.candidatePrototype;
			}
			return result;
		}
	}

	public static int BuildVersion => int.Parse(DisableDefinition("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentBuildNumber", "0"));

	public static string VersionString => Version.ToString();

	public static Version Version => new Version(MajorVersion, MinorVersion, BuildVersion, RevisionVersion);

	public static int MajorVersion
	{
		get
		{
			if (CompareDefinition())
			{
				return 10;
			}
			if (ReadDefinition())
			{
				return 11;
			}
			string text = DisableDefinition("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentVersion", "");
			if (string.IsNullOrEmpty(text))
			{
				return Environment.OSVersion.Version.Major;
			}
			return int.Parse(text.Split('.')[0]);
		}
	}

	public static int MinorVersion
	{
		get
		{
			if (!CompareDefinition() && !ReadDefinition())
			{
				string text = DisableDefinition("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentVersion", "");
				if (string.IsNullOrEmpty(text))
				{
					return Environment.OSVersion.Version.Minor;
				}
				return int.Parse(text.Split('.')[1]);
			}
			return 0;
		}
	}

	public static int RevisionVersion
	{
		get
		{
			if (!CompareDefinition() && !ReadDefinition())
			{
				return Environment.OSVersion.Version.Revision;
			}
			return 0;
		}
	}

	[DllImport("kernel32.dll")]
	internal static extern bool GetProductInfo(int int_0, int int_1, int int_2, int int_3, out int int_4);

	[DllImport("kernel32.dll")]
	private static extern bool GetVersionEx(ref InitializerCollectionRecord initializerCollectionRecord_0);

	[DllImport("user32")]
	public static extern int GetSystemMetrics(int int_0);

	[DllImport("kernel32.dll")]
	public static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO system_INFO_0);

	[DllImport("kernel32.dll")]
	public static extern void GetNativeSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO system_INFO_0);

	[DllImport("kernel32", SetLastError = true)]
	public static extern IntPtr LoadLibrary(string string_0);

	[DllImport("kernel32", SetLastError = true)]
	public static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);

	private static AttrCallbackCandidate InstantiateDefinition()
	{
		IntPtr intPtr = LoadLibrary("kernel32");
		if (intPtr != IntPtr.Zero)
		{
			IntPtr procAddress = GetProcAddress(intPtr, "IsWow64Process");
			if (procAddress != IntPtr.Zero)
			{
				return (AttrCallbackCandidate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(AttrCallbackCandidate));
			}
		}
		return null;
	}

	private static bool CreateDefinition()
	{
		AttrCallbackCandidate attrCallbackCandidate = InstantiateDefinition();
		if (attrCallbackCandidate == null)
		{
			return false;
		}
		if (attrCallbackCandidate(Process.GetCurrentProcess().Handle, out var isWow64Process))
		{
			return isWow64Process;
		}
		return false;
	}

	private static bool CompareDefinition()
	{
		int num = int.Parse((string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion").GetValue("CurrentBuild"));
		if (DisableDefinition("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", "").StartsWith("Windows 10", StringComparison.OrdinalIgnoreCase) && num < 22000)
		{
			return true;
		}
		return false;
	}

	private static bool ReadDefinition()
	{
		return int.Parse((string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion").GetValue("CurrentBuild")) >= 22000;
	}

	private static string DisableDefinition(string string_0, string string_1, object object_0)
	{
		string result = "";
		string text = "";
		string text2 = "";
		try
		{
			RegistryKey registryKey = null;
			string[] array = string_0.Split('\\');
			if (array.Length == 0)
			{
				return result;
			}
			array[0] = array[0].ToUpper();
			if (array[0] == "HKEY_CLASSES_ROOT")
			{
				registryKey = Registry.ClassesRoot;
			}
			else if (array[0] == "HKEY_CURRENT_USER")
			{
				registryKey = Registry.CurrentUser;
			}
			else if (array[0] == "HKEY_LOCAL_MACHINE")
			{
				registryKey = Registry.LocalMachine;
			}
			else if (array[0] == "HKEY_USERS")
			{
				registryKey = Registry.Users;
			}
			else if (array[0] == "HKEY_CURRENT_CONFIG")
			{
				registryKey = Registry.CurrentConfig;
			}
			if (registryKey == null)
			{
				return result;
			}
			for (int i = 1; i < array.Length; i++)
			{
				text2 = text2 + text + array[i];
				text = "\\";
			}
			if (text2 == "")
			{
				return result;
			}
			registryKey = registryKey.OpenSubKey(text2);
			result = (string)registryKey.GetValue(string_1, object_0);
			registryKey.Close();
			return result;
		}
		catch
		{
			return result;
		}
	}
}
