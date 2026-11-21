using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Common;

internal class SingletonListener : ServiceMerchantService
{
	private Connection recordListener;

	public SingletonListener(Connection connection_0)
	{
		recordListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(recordListener, "SELECT * FROM " + value, value);
	}
}
