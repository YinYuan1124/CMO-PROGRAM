using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Mocks;

internal class IdentifierListener : ServiceMerchantService
{
	private Connection printerListener;

	public IdentifierListener(Connection connection_0)
	{
		printerListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(printerListener, "SELECT * FROM " + value, value);
	}
}
