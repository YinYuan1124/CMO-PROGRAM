using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Candidates;

internal class IteratorListener : ServiceMerchantService
{
	private Connection initializerListener;

	public IteratorListener(Connection connection_0)
	{
		initializerListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(initializerListener, "SELECT * FROM " + value, value);
	}
}
