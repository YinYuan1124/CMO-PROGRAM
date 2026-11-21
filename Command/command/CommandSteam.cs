using Microsoft.VisualBasic.CompilerServices;
using Steamworks;

namespace Command;

[StandardModule]
public sealed class CommandSteam
{
	public static bool steamOnline;

	private static bool proccesorRequest;

	static CommandSteam()
	{
		proccesorRequest = false;
	}

	public static void CloseSteamConnection()
	{
		if (steamOnline)
		{
			SteamAPI.Shutdown();
		}
	}

	public static void RunCallbacks()
	{
		if (steamOnline)
		{
			SteamAPI.RunCallbacks();
		}
	}

	public static void OpenSteamConnection()
	{
		if (!proccesorRequest)
		{
			steamOnline = SteamAPI.Init();
			proccesorRequest = true;
		}
	}

	public static bool CheckModuleLicence(AppId_t appId_t_0)
	{
		if (!steamOnline && !proccesorRequest)
		{
			OpenSteamConnection();
		}
		if (steamOnline)
		{
			if (SteamApps.BIsSubscribedApp(appId_t_0))
			{
				return true;
			}
		}
		else
		{
			byte[] array = new byte[1025];
			uint num = 0u;
			if (SteamUser.GetAuthSessionTicket(array, 1024, out num) != HAuthTicket.Invalid && (ulong)num != 0)
			{
				SteamUser.BeginAuthSession(array, (int)num, SteamUser.GetSteamID());
				if (SteamUser.UserHasLicenseForApp(SteamUser.GetSteamID(), appId_t_0) == EUserHasLicenseForAppResult.k_EUserHasLicenseResultHasLicense)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool CheckDLCLicence(AppId_t appId_t_0)
	{
		if (!steamOnline && !proccesorRequest)
		{
			OpenSteamConnection();
		}
		if (steamOnline)
		{
			if (SteamApps.BIsDlcInstalled(appId_t_0))
			{
				return true;
			}
		}
		else
		{
			byte[] array = new byte[1025];
			uint num = 0u;
			if (SteamUser.GetAuthSessionTicket(array, 1024, out num) != HAuthTicket.Invalid && (ulong)num != 0)
			{
				SteamUser.BeginAuthSession(array, (int)num, SteamUser.GetSteamID());
				if (SteamUser.UserHasLicenseForApp(SteamUser.GetSteamID(), appId_t_0) == EUserHasLicenseForAppResult.k_EUserHasLicenseResultHasLicense)
				{
					return true;
				}
			}
		}
		return false;
	}
}
