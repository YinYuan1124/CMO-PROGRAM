using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Steamworks;

namespace Command;

[StandardModule]
public sealed class Licensing
{
	internal struct InfoProcessResolver
	{
		public string m_ContainerMap;

		public AppId_t _ComposerMap;

		public AppId_t _ModelMap;

		public string advisorMap;

		public string m_CustomerMap;

		public string _SerializerMap;

		public string _RefMap;

		public Color _ErrorMap;
	}

	public enum ModuleLicense
	{
		CommandFullVersion,
		NorthernInferno,
		LIVE_OldGrudges,
		LIVE_Brexit,
		LIVE_Spratly,
		LIVE_Don,
		LIVE_Korea,
		ChainsOfWar,
		CommandPE,
		LIVE_Pole,
		ShiftingSands,
		LIVE_BlackGold,
		TheSilentService,
		LIVE_Commonwealth,
		LIVE_Kuril,
		LIVE_KingOfTheBorder,
		DesertStorm,
		LIVE_BrokenShield300,
		LIVE_AegeanInFlames,
		LIVE_SahelSlugfest,
		KashmirFire,
		RedTide,
		Showcase_QueenElizabeth,
		const_23,
		Showcase_FordClass,
		Showcase_DesertFalcon,
		Showcase_Icebreakers
	}

	public static AppId_t appID_FullBaseVersion;

	private static Dictionary<ModuleLicense, InfoProcessResolver> m_ProccesorComposer;

	private static HashSet<ModuleLicense> _StrategyComposer;

	static Licensing()
	{
		appID_FullBaseVersion = new AppId_t(1076160u);
		m_ProccesorComposer = new Dictionary<ModuleLicense, InfoProcessResolver>();
		_StrategyComposer = new HashSet<ModuleLicense>();
	}

	public static void Initialize(bool bool_0)
	{
		try
		{
			StartRole();
			foreach (KeyValuePair<ModuleLicense, InfoProcessResolver> item in m_ProccesorComposer)
			{
				AssetRole(item.Key);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200416", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal static Dictionary<ModuleLicense, InfoProcessResolver> PostRole()
	{
		return m_ProccesorComposer;
	}

	internal static List<InfoProcessResolver> RunRole(List<ModuleLicense> list_0)
	{
		List<InfoProcessResolver> list = new List<InfoProcessResolver>();
		foreach (ModuleLicense item in list_0)
		{
			list.Add(m_ProccesorComposer[item]);
		}
		return list;
	}

	private static void StartRole()
	{
		InfoProcessResolver value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Modern Operations";
		value._ComposerMap = appID_FullBaseVersion;
		value.advisorMap = "Command Modern Operations";
		value.m_CustomerMap = "Command Modern Operations";
		value._SerializerMap = "https://www.matrixgames.com/game/command-modern-operations";
		value._RefMap = "NoLicense_CMO.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.CommandFullVersion, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Professional Edition";
		value._ComposerMap = new AppId_t(0u);
		value.advisorMap = "Command Professional Edition";
		value._SerializerMap = "http://www.warfaresims.com/?page_id=3822";
		value._RefMap = "NoLicense_CPE.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.CommandPE, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Northern Inferno";
		value._ComposerMap = new AppId_t(397180u);
		value._ModelMap = new AppId_t(1182291u);
		value.advisorMap = "Command Northern Inferno";
		value.m_CustomerMap = "CMO Northern Inferno";
		value._SerializerMap = "http://www.matrixgames.com/products/589/details/Command:.Northern.Inferno.";
		value._RefMap = "NoLicense_NI.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.NorthernInferno, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Chains Of War";
		value._ComposerMap = new AppId_t(614130u);
		value._ModelMap = new AppId_t(1182292u);
		value.advisorMap = "Command Chains Of War";
		value.m_CustomerMap = "CMO Chains Of War";
		value._SerializerMap = "http://www.matrixgames.com/products/693/details/Command.Chains.of.War";
		value._RefMap = "NoLicense_COW.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.ChainsOfWar, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Shifting Sands";
		value._ComposerMap = new AppId_t(718710u);
		value._ModelMap = new AppId_t(1182290u);
		value.advisorMap = "Command Shifting Sands";
		value.m_CustomerMap = "CMO Shifting Sands";
		value._SerializerMap = "http://www.matrixgames.com/products/707/details/Command.Shifting.Sands";
		value._RefMap = "NoLicense_SS.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.ShiftingSands, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - The Silent Service";
		value._ComposerMap = new AppId_t(785930u);
		value._ModelMap = new AppId_t(1182293u);
		value.advisorMap = "Command The Silent Service";
		value.m_CustomerMap = "CMO The Silent Service";
		value._SerializerMap = "http://www.matrixgames.com/products/product.asp?gid=725";
		value._RefMap = "NoLicense_TSS.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.TheSilentService, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Desert Storm";
		value._ComposerMap = new AppId_t(1036420u);
		value._ModelMap = new AppId_t(1182294u);
		value.advisorMap = "Command Desert Storm";
		value.m_CustomerMap = "CMO Desert Storm";
		value._SerializerMap = "http://www.matrixgames.com/products/product.asp?gid=797";
		value._RefMap = "NoLicense_DS.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.DesertStorm, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Kashmir Fire";
		value._ComposerMap = new AppId_t(1594140u);
		value._ModelMap = new AppId_t(1594140u);
		value.advisorMap = "Command Kashmir Fire";
		value.m_CustomerMap = "CMO Kashmir Fire";
		value._SerializerMap = "https://www.matrixgames.com/game/command-kashmir-fire";
		value._RefMap = "NoLicense_KF.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.KashmirFire, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Red Tide";
		value._ComposerMap = new AppId_t(1712070u);
		value._ModelMap = new AppId_t(1712070u);
		value.advisorMap = "Command Red Tide";
		value.m_CustomerMap = "CMO Red Tide";
		value._SerializerMap = "https://www.matrixgames.com/game/command-red-tide";
		value._RefMap = "NoLicense_RT.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.RedTide, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command - Falklands";
		value._ComposerMap = new AppId_t(2141010u);
		value._ModelMap = new AppId_t(2141010u);
		value.advisorMap = "Command Falklands";
		value.m_CustomerMap = "CMO Falklands";
		value._SerializerMap = "https://www.matrixgames.com/game/command-modern-operations-falklands";
		value._RefMap = "NoLicense_FLK.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.const_23, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #1 - Old Grudges Never Die";
		value._ComposerMap = new AppId_t(388020u);
		value._ModelMap = new AppId_t(1182305u);
		value.advisorMap = "Command LIVE\\Old Grudges";
		value.m_CustomerMap = "CMO LIVE\\Old Grudges";
		value._SerializerMap = "http://www.matrixgames.com/products/636/details/Command.Live:.Old.Grudges.Never.Die";
		value._RefMap = "NoLicense_LIVE1.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_OldGrudges, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #2 - You Brexit, You Fix It!";
		value._ComposerMap = new AppId_t(497611u);
		value._ModelMap = new AppId_t(1182309u);
		value.advisorMap = "Command LIVE\\Brexit";
		value.m_CustomerMap = "CMO LIVE\\Brexit";
		value._SerializerMap = "http://www.matrixgames.com/products/640/details/CommandLive:YouBrexit,YouFixit!";
		value._RefMap = "NoLicense_LIVE2.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_Brexit, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #3 - Spratly Spat";
		value._ComposerMap = new AppId_t(527370u);
		value._ModelMap = new AppId_t(1182307u);
		value.advisorMap = "Command LIVE\\Spratly";
		value.m_CustomerMap = "CMO LIVE\\Spratly";
		value._SerializerMap = "http://www.matrixgames.com/products/643/details/Command.LIVE:.Spratly.Spat";
		value._RefMap = "NoLicense_LIVE3.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_Spratly, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #4 - Don of a New Era";
		value._ComposerMap = new AppId_t(497610u);
		value._ModelMap = new AppId_t(1182302u);
		value.advisorMap = "Command LIVE\\Don Era";
		value.m_CustomerMap = "CMO LIVE\\Don Era";
		value._SerializerMap = "http://www.matrixgames.com/products/648/details/CommandLive:DonofanewEra";
		value._RefMap = "NoLicense_LIVE4.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_Don, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #5 - Korean Missile Crisis";
		value._ComposerMap = new AppId_t(584260u);
		value._ModelMap = new AppId_t(1182303u);
		value.advisorMap = "Command LIVE\\Korea";
		value.m_CustomerMap = "CMO LIVE\\Korea";
		value._SerializerMap = "http://www.matrixgames.com/products/681/details/Command.Live:.Korean.Missile.Crisis";
		value._RefMap = "NoLicense_LIVE5.jpg";
		value._ErrorMap = Color.DarkRed;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_Korea, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #6 - Pole Positions";
		value._ComposerMap = new AppId_t(670700u);
		value._ModelMap = new AppId_t(1182306u);
		value.advisorMap = "Command LIVE\\Pole Positions";
		value.m_CustomerMap = "CMO LIVE\\Pole Positions";
		value._SerializerMap = "http://www.matrixgames.com/products/702/details/Command.Live.Pole.Positions";
		value._RefMap = "NoLicense_LIVE6.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_Pole, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #7 - Black Gold Blitz";
		value._ComposerMap = new AppId_t(729630u);
		value._ModelMap = new AppId_t(1182300u);
		value.advisorMap = "Command LIVE\\Black Gold Blitz";
		value.m_CustomerMap = "CMO LIVE\\Black Gold Blitz";
		value._SerializerMap = "http://www.matrixgames.com/products/product.asp?gid=713";
		value._RefMap = "NoLicense_LIVE7.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_BlackGold, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #8 - Commonwealth Collision";
		value._ComposerMap = new AppId_t(842960u);
		value._ModelMap = new AppId_t(1182301u);
		value.advisorMap = "Command LIVE\\Commonwealth Collision";
		value.m_CustomerMap = "CMO LIVE\\Commonwealth Collision";
		value._SerializerMap = "http://www.matrixgames.com/products/product.asp?gid=731";
		value._RefMap = "NoLicense_LIVE8.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_Commonwealth, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #9 - Kuril Sunrise";
		value._ComposerMap = new AppId_t(899280u);
		value._ModelMap = new AppId_t(1182304u);
		value.advisorMap = "Command LIVE\\Kuril Sunrise";
		value.m_CustomerMap = "CMO LIVE\\Kuril Sunrise";
		value._SerializerMap = "http://www.matrixgames.com/products/739/details/Command.Live.Kuril.Sunrise";
		value._RefMap = "NoLicense_LIVE9.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_Kuril, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #10 - The King Of The Border";
		value._ComposerMap = new AppId_t(1011400u);
		value._ModelMap = new AppId_t(1182308u);
		value.advisorMap = "Command LIVE\\King Border";
		value.m_CustomerMap = "CMO LIVE\\King Border";
		value._SerializerMap = "http://www.matrixgames.com/products/product.asp?gid=794";
		value._RefMap = "NoLicense_LIVE10.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_KingOfTheBorder, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #11 - Broken Shield 300";
		value._ComposerMap = new AppId_t(1228660u);
		value._ModelMap = new AppId_t(1228660u);
		value.advisorMap = "Command LIVE\\Broken Shield";
		value.m_CustomerMap = "CMO LIVE\\Broken Shield";
		value._SerializerMap = "http://www.matrixgames.com/game/command-live-broken-shield-300";
		value._RefMap = "NoLicense_LIVE11.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_BrokenShield300, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #12 - Aegean In Flames";
		value._ComposerMap = new AppId_t(1309690u);
		value._ModelMap = new AppId_t(1309690u);
		value.advisorMap = "Command LIVE\\Aegean In Flames";
		value.m_CustomerMap = "CMO LIVE\\Aegean In Flames";
		value._SerializerMap = "http://www.matrixgames.com/game/command-live-aegean-in-flames";
		value._RefMap = "NoLicense_LIVE12.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_AegeanInFlames, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command LIVE #13 - Sahel Slugfest";
		value._ComposerMap = new AppId_t(1438050u);
		value._ModelMap = new AppId_t(1438050u);
		value.advisorMap = "Command LIVE\\Sahel Slugfest";
		value.m_CustomerMap = "CMO LIVE\\Sahel Slugfest";
		value._SerializerMap = "http://www.matrixgames.com/game/command-live-sahel-slugfest";
		value._RefMap = "NoLicense_LIVE13.jpg";
		value._ErrorMap = Color.LightSkyBlue;
		m_ProccesorComposer.Add(ModuleLicense.LIVE_SahelSlugfest, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command Showcase #1 - Queen Elizabeth";
		value._ComposerMap = new AppId_t(1178900u);
		value._ModelMap = new AppId_t(1178900u);
		value.advisorMap = "Command Showcase\\Queen Elizabeth";
		value.m_CustomerMap = "CMO Showcase\\Queen Elizabeth";
		value._SerializerMap = "https://www.matrixgames.com/game/command-showcase-queen-elizabeth";
		value._RefMap = "NoLicense_Showcase1.jpg";
		value._ErrorMap = Color.Aquamarine;
		m_ProccesorComposer.Add(ModuleLicense.Showcase_QueenElizabeth, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command Showcase #2 - Ford Class";
		value._ComposerMap = new AppId_t(2306370u);
		value._ModelMap = new AppId_t(2306370u);
		value.advisorMap = "Command Showcase\\Ford Class";
		value.m_CustomerMap = "CMO Showcase\\Ford Class";
		value._SerializerMap = "https://www.matrixgames.com/game/command-showcase-ford-class";
		value._RefMap = "NoLicense_Showcase2.jpg";
		value._ErrorMap = Color.Aquamarine;
		m_ProccesorComposer.Add(ModuleLicense.Showcase_FordClass, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command Showcase #3 - Operation Desert Falcon";
		value._ComposerMap = new AppId_t(2516840u);
		value._ModelMap = new AppId_t(2516840u);
		value.advisorMap = "Command Showcase\\Operation Desert Falcon";
		value.m_CustomerMap = "CMO Showcase\\Operation Desert Falcon";
		value._SerializerMap = "https://www.matrixgames.com/game/command-showcase-operation-desert-falcon";
		value._RefMap = "NoLicense_Showcase3.jpg";
		value._ErrorMap = Color.Aquamarine;
		m_ProccesorComposer.Add(ModuleLicense.Showcase_DesertFalcon, value);
		value = default(InfoProcessResolver);
		value.m_ContainerMap = "Command Showcase #4 - Icebreakers";
		value._ComposerMap = new AppId_t(2676020u);
		value._ModelMap = new AppId_t(2676020u);
		value.advisorMap = "Command Showcase\\Icebreakers";
		value.m_CustomerMap = "CMO Showcase\\Icebreakers";
		value._SerializerMap = "https://www.matrixgames.com/game/command-showcase-icebreakers";
		value._RefMap = "NoLicense_Showcase4.jpg";
		value._ErrorMap = Color.Aquamarine;
		m_ProccesorComposer.Add(ModuleLicense.Showcase_Icebreakers, value);
	}

	public static void ActivateLicense(ModuleLicense moduleLicense_0)
	{
		_StrategyComposer.Add(moduleLicense_0);
	}

	public static void DeactivateLicense(ModuleLicense moduleLicense_0)
	{
		_StrategyComposer.Remove(moduleLicense_0);
	}

	[SpecialName]
	public static bool GetModuleIsLicensed(ModuleLicense moduleLicense_0)
	{
		return true;
	}

	public static string GetContentTagFromCampaignID(string string_0)
	{
		if (Operators.CompareString(string_0, "6686549e-66a7-45dc-8f7a-1b0099cdae0a", TextCompare: true) == 0)
		{
			return "NINFERNO";
		}
		if (Operators.CompareString(string_0, "f8691e80-1caf-4a49-a1b7-9305255a9200", TextCompare: true) == 0)
		{
			return "CHAINSOFWAR";
		}
		if (Operators.CompareString(string_0, "f703124e-f438-42ab-a738-4dcbe7d90c86", TextCompare: true) == 0)
		{
			return "SSANDS";
		}
		if (Operators.CompareString(string_0, "1fd76cc8-ab96-4a23-afc1-5beb48200026", TextCompare: true) == 0)
		{
			return "SILENTSERVICE";
		}
		if (Operators.CompareString(string_0, "437950b8-3f16-4932-b8e6-a2c397e1f758", TextCompare: true) == 0)
		{
			return "DESERTSTORM";
		}
		if (Operators.CompareString(string_0, "182d560e-c5d0-4f80-9c39-3350a0670194", TextCompare: true) == 0)
		{
			return "KASHMIRFIRE";
		}
		if (Operators.CompareString(string_0, "ca630266-f861-4c2f-9031-e527cf2d6e41", TextCompare: true) == 0)
		{
			return "REDTIDE";
		}
		if (Operators.CompareString(string_0, "15a5de63-a739-4c36-b86b-bc9fc15bc092", TextCompare: true) == 0)
		{
			return "FALKLANDS82";
		}
		_ = Debugger.IsAttached;
		return null;
	}

	private static void AssetRole(ModuleLicense moduleLicense_0)
	{
		if (!Client.RunningInSteamMode || moduleLicense_0 == ModuleLicense.CommandPE)
		{
			return;
		}
		CommandSteam.OpenSteamConnection();
		if (CommandSteam.steamOnline)
		{
			if (CommandSteam.CheckModuleLicence(m_ProccesorComposer[moduleLicense_0]._ComposerMap))
			{
				ActivateLicense(moduleLicense_0);
			}
			else if (CommandSteam.CheckModuleLicence(m_ProccesorComposer[moduleLicense_0]._ModelMap))
			{
				ActivateLicense(moduleLicense_0);
			}
		}
	}

	private static bool PrintRole(string string_0)
	{
		RegistryKey registryKey = (Environment.Is64BitOperatingSystem ? ItemExporter.RegisterInterruptibleMap.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Matrix Games\\" + string_0) : ItemExporter.RegisterInterruptibleMap.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Matrix Games\\" + string_0));
		object obj = null;
		if (registryKey != null)
		{
			obj = RuntimeHelpers.GetObjectValue(registryKey.GetValue("authorized"));
		}
		if (obj == null)
		{
			return false;
		}
		return true;
	}

	public static bool IsUserLicensedForThisContent(string string_0)
	{
		return true;
	}

	public static bool UserHasLicenseForThisFeature(Scenario.ScenarioFeatureOption scenarioFeatureOption_0)
	{
		return true;
	}

	public static ModuleLicense ModuleEnablingThisContent(string string_0)
	{
		if (Operators.CompareString(string_0, "TUTORIAL", TextCompare: true) == 0)
		{
			return ModuleLicense.CommandFullVersion;
		}
		if (Operators.CompareString(string_0, "NINFERNO", TextCompare: true) == 0)
		{
			return ModuleLicense.NorthernInferno;
		}
		if (Operators.CompareString(string_0, "CHAINSOFWAR", TextCompare: true) != 0)
		{
			return ModuleLicense.ChainsOfWar;
		}
		if (Operators.CompareString(string_0, "SSANDS", TextCompare: true) == 0)
		{
			return ModuleLicense.ShiftingSands;
		}
		if (Operators.CompareString(string_0, "SILENTSERVICE", TextCompare: true) == 0)
		{
			return ModuleLicense.TheSilentService;
		}
		if (Operators.CompareString(string_0, "DESERTSTORM", TextCompare: true) == 0)
		{
			return ModuleLicense.DesertStorm;
		}
		if (Operators.CompareString(string_0, "KASHMIRFIRE", TextCompare: true) == 0)
		{
			return ModuleLicense.KashmirFire;
		}
		if (Operators.CompareString(string_0, "REDTIDE", TextCompare: true) == 0)
		{
			return ModuleLicense.RedTide;
		}
		if (Operators.CompareString(string_0, "FALKLANDS82", TextCompare: true) == 0)
		{
			return ModuleLicense.const_23;
		}
		if (Operators.CompareString(string_0, "OLDGRUDGES", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_OldGrudges;
		}
		if (Operators.CompareString(string_0, "BREXIT", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_Brexit;
		}
		if (Operators.CompareString(string_0, "CLIVE3", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_Spratly;
		}
		if (Operators.CompareString(string_0, "DON", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_Don;
		}
		if (Operators.CompareString(string_0, "CLIVE5", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_Korea;
		}
		if (Operators.CompareString(string_0, "CLIVE6", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_Pole;
		}
		if (Operators.CompareString(string_0, "BLACKGOLD", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_BlackGold;
		}
		if (Operators.CompareString(string_0, "CLIVE8", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_Commonwealth;
		}
		if (Operators.CompareString(string_0, "CLIVE9", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_Kuril;
		}
		if (Operators.CompareString(string_0, "CLIVE10", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_KingOfTheBorder;
		}
		if (Operators.CompareString(string_0, "CLIVE11", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_BrokenShield300;
		}
		if (Operators.CompareString(string_0, "CLIVE12", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_AegeanInFlames;
		}
		if (Operators.CompareString(string_0, "CLIVE13", TextCompare: true) == 0)
		{
			return ModuleLicense.LIVE_SahelSlugfest;
		}
		if (Operators.CompareString(string_0, "CSHOW1", TextCompare: true) == 0)
		{
			return ModuleLicense.Showcase_QueenElizabeth;
		}
		if (Operators.CompareString(string_0, "CSHOW2", TextCompare: true) == 0)
		{
			return ModuleLicense.Showcase_FordClass;
		}
		if (Operators.CompareString(string_0, "CSHOW3", TextCompare: true) == 0)
		{
			return ModuleLicense.Showcase_DesertFalcon;
		}
		if (Operators.CompareString(string_0, "CSHOW4", TextCompare: true) == 0)
		{
			return ModuleLicense.Showcase_Icebreakers;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return ModuleLicense.CommandFullVersion;
	}

	public static List<ModuleLicense> ModulesEnablingThisFeature(Scenario.ScenarioFeatureOption scenarioFeatureOption_0)
	{
		List<ModuleLicense> list = new List<ModuleLicense>();
		if (scenarioFeatureOption_0 == Scenario.ScenarioFeatureOption.CommsJamming)
		{
			list.Add(ModuleLicense.CommandPE);
			return list;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return null;
	}
}
