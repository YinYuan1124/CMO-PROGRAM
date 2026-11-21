using System.IO;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Pages;

namespace Command_Core;

public sealed class OnStartForcedLocalChange
{
	private static OnStartForcedLocalChange m_StrategyConsumer;

	private string _ConfigurationConsumer;

	static OnStartForcedLocalChange()
	{
		m_StrategyConsumer = null;
	}

	private void EnableStub(string string_0)
	{
		ref string configurationConsumer = ref _ConfigurationConsumer;
		configurationConsumer = configurationConsumer + string_0 + "\r\n";
	}

	private void ChangeStub()
	{
		StreamWriter streamWriter = MerchantMerchantPage.SelectList.FileSystem.OpenTextFileWriter(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "VersionForcedChanges.txt", append: false);
		streamWriter.WriteLine(_ConfigurationConsumer);
		streamWriter.Close();
	}

	public void Apply()
	{
		if (FileExistsNative.FileExistsFast(GameGeneral.ScenariosRootPath + "\\Standalone Scenarios\\Canarys Cage, 2005.ini"))
		{
			File.Delete(GameGeneral.ScenariosRootPath + "\\Standalone Scenarios\\Canarys Cage, 2005.ini");
		}
		if (FileExistsNative.FileExistsFast(GameGeneral.ScenariosRootPath + "\\Standalone Scenarios\\Canarys Cage, 2005.scen"))
		{
			File.Delete(GameGeneral.ScenariosRootPath + "\\Standalone Scenarios\\Canarys Cage, 2005.scen");
		}
		EnableStub("Deleting Canarys cage scenario (duplicate item)");
		ChangeStub();
	}

	private OnStartForcedLocalChange()
	{
	}

	public static OnStartForcedLocalChange GetInstance()
	{
		if (m_StrategyConsumer == null)
		{
			m_StrategyConsumer = new OnStartForcedLocalChange();
		}
		return m_StrategyConsumer;
	}
}
