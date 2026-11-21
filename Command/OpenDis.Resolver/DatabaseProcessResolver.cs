using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Resolver;

internal class DatabaseProcessResolver : ServiceMerchantService
{
	private Connection _AccountListener;

	public DatabaseProcessResolver(Connection connection_0)
	{
		_AccountListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_AccountListener, "SELECT * FROM " + value, value);
	}
}
