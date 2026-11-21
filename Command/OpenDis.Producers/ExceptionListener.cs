using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Producers;

internal class ExceptionListener : ServiceMerchantService
{
	private Connection _AttrListener;

	public ExceptionListener(Connection connection_0)
	{
		_AttrListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_AttrListener, "SELECT * FROM " + value, value);
	}
}
