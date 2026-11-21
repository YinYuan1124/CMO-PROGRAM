using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Managers;

internal class BaseListener : ServiceMerchantService
{
	private Connection _PolicyListener;

	public BaseListener(Connection connection_0)
	{
		_PolicyListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_PolicyListener, "SELECT * FROM " + value, value);
	}
}
