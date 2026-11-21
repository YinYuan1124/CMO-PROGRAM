using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Database;

internal class RulesListener : ServiceMerchantService
{
	private Connection methodListener;

	public RulesListener(Connection connection_0)
	{
		methodListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(methodListener, "SELECT * FROM " + value, value);
	}
}
