using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Maps;

internal class SetterListener : ServiceMerchantService
{
	private Connection _CreatorListener;

	public SetterListener(Connection connection_0)
	{
		_CreatorListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_CreatorListener, "SELECT * FROM " + value, value);
	}
}
