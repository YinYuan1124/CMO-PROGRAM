using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Listeners;

internal class FilterObjectListener : ServiceMerchantService
{
	private Connection comparatorListener;

	public FilterObjectListener(Connection connection_0)
	{
		comparatorListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(comparatorListener, "SELECT * FROM " + value, value);
	}
}
