using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Pages;

internal class ProcPage : ServiceMerchantService
{
	private Connection _ParamsListener;

	public ProcPage(Connection connection_0)
	{
		_ParamsListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_ParamsListener, "SELECT * FROM " + value, value);
	}
}
