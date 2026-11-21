using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Resolver;

internal class AlgoProcessResolver : ServiceMerchantService
{
	private Connection itemListener;

	public AlgoProcessResolver(Connection connection_0)
	{
		itemListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(itemListener, "SELECT * FROM " + value, value);
	}
}
