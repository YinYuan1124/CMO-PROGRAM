using System;
using System.IO;
using System.Runtime.CompilerServices;
using Command.Messages;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Steamworks;

namespace Command;

public sealed class SteamNag
{
	public static void PerformNagChecks()
	{
	}

	private static string UpdateInterruptibleRecord()
	{
		string path = (Environment.Is64BitOperatingSystem ? Conversions.ToString(ItemExporter.RegisterInterruptibleMap.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", null)) : Conversions.ToString(ItemExporter.RegisterInterruptibleMap.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Valve\\Steam", "InstallPath", null)));
		CSteamID steamID = SteamUser.GetSteamID();
		CSteamID cSteamID = steamID;
		AccountID_t accountID = cSteamID.GetAccountID();
		return Path.Combine(path, "userdata\\" + ((object)accountID).ToString() + "\\config\\localconfig.vdf");
	}

	public static bool IsDirectWriteDisabled()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
		if (registryKey != null)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(registryKey.GetValue("DWriteEnable"));
			if (objectValue != null && Operators.ConditionalCompareObjectEqual(objectValue, 1, TextCompare: true))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsSteamOverlayDisabled()
	{
		return false;
	}
}
