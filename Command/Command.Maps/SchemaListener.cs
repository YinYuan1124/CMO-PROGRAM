using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Maps;

internal class SchemaListener : ServiceMerchantService
{
	private Connection utilsListener;

	public SchemaListener(Connection connection_0)
	{
		utilsListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(utilsListener, "SELECT * FROM " + value, value);
	}
}
