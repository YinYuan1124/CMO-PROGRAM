using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Common;

internal class StateListener : ServiceMerchantService
{
	private Connection authenticationListener;

	public StateListener(Connection connection_0)
	{
		authenticationListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(authenticationListener, "SELECT * FROM " + value, value);
	}
}
