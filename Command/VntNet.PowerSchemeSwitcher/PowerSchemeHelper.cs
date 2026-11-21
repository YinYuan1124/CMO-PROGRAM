using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace VntNet.PowerSchemeSwitcher;

public sealed class PowerSchemeHelper
{
	private class SchemaCallbackCandidate
	{
		[Flags]
		private enum Enum1
		{

		}

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerEnumerate(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, Enum1 enum1_0, uint uint_0, IntPtr intptr_3, ref uint uint_1);

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerReadFriendlyName(IntPtr intptr_0, ref Guid guid_0, IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3, ref uint uint_0);

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerSetActiveScheme(IntPtr intptr_0, ref Guid guid_0);

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerGetActiveScheme(IntPtr intptr_0, ref IntPtr intptr_1);

		public static Guid InvokeInterruptibleTemplate(uint uint_0)
		{
			uint uint_ = 16u;
			uint num = 0u;
			Guid empty = Guid.Empty;
			IntPtr intPtr = (intPtr = Marshal.AllocHGlobal(16));
			try
			{
				num = PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (Enum1)16, uint_0, intPtr, ref uint_);
				if (num == 234)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal((int)uint_);
					num = PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (Enum1)16, uint_0, intPtr, ref uint_);
				}
				if (1 == 0)
				{
				}
				Guid result = num switch
				{
					259u => empty, 
					0u => (Guid)Marshal.PtrToStructure(intPtr, typeof(Guid)), 
					_ => throw new Win32Exception(Marshal.GetLastWin32Error()), 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}

		public static string SetupInterruptibleTemplate(Guid guid_0)
		{
			uint uint_ = 255u;
			uint num = 0u;
			string text = null;
			IntPtr intPtr = (intPtr = Marshal.AllocHGlobal(255));
			num = PowerReadFriendlyName(IntPtr.Zero, ref guid_0, IntPtr.Zero, IntPtr.Zero, intPtr, ref uint_);
			if (num == 234)
			{
				Marshal.FreeHGlobal(intPtr);
				intPtr = Marshal.AllocHGlobal((int)uint_);
				num = PowerReadFriendlyName(IntPtr.Zero, ref guid_0, IntPtr.Zero, IntPtr.Zero, intPtr, ref uint_);
			}
			if (1 == 0)
			{
			}
			string text2 = num switch
			{
				2u => null, 
				0u => Marshal.PtrToStringUni(intPtr), 
				_ => throw new Win32Exception(Marshal.GetLastWin32Error()), 
			};
			if (1 == 0)
			{
			}
			text = text2;
			Marshal.FreeHGlobal(intPtr);
			return text;
		}

		public static bool ExcludeInterruptibleTemplate(Guid guid_0)
		{
			if (PowerSetActiveScheme(IntPtr.Zero, ref guid_0) == 0)
			{
				return true;
			}
			return false;
		}

		public static Guid IncludeInterruptibleTemplate()
		{
			IntPtr intptr_ = Marshal.AllocHGlobal(16);
			Guid result = Guid.Empty;
			if (PowerGetActiveScheme(IntPtr.Zero, ref intptr_) == 0)
			{
				result = (Guid)Marshal.PtrToStructure(intptr_, typeof(Guid));
			}
			Marshal.FreeHGlobal(intptr_);
			return result;
		}
	}

	public static bool SetPowerScheme(Guid guid_0)
	{
		if (SchemaCallbackCandidate.IncludeInterruptibleTemplate() == guid_0)
		{
			return true;
		}
		SchemaCallbackCandidate.ExcludeInterruptibleTemplate(guid_0);
		return SchemaCallbackCandidate.IncludeInterruptibleTemplate() == guid_0;
	}

	public static Dictionary<Guid, PowerPlanInfo> GetAllPowerSchemas()
	{
		uint num = 0u;
		Dictionary<Guid, PowerPlanInfo> dictionary = new Dictionary<Guid, PowerPlanInfo>(3);
		while (true)
		{
			try
			{
				Guid guid = SchemaCallbackCandidate.InvokeInterruptibleTemplate(num);
				if (guid == Guid.Empty)
				{
					return dictionary;
				}
				string friendlyName = SchemaCallbackCandidate.SetupInterruptibleTemplate(guid);
				dictionary.Add(guid, new PowerPlanInfo
				{
					SchemeGuid = guid,
					FriendlyName = friendlyName
				});
			}
			finally
			{
				num++;
			}
		}
	}

	public static Guid GetPowerActiveScheme()
	{
		return SchemaCallbackCandidate.IncludeInterruptibleTemplate();
	}
}
