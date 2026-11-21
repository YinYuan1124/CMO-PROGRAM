using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Producers;

internal class ThreadProcessProducer : ServiceMerchantService
{
	private Connection broadcasterListener;

	public ThreadProcessProducer(Connection connection_0)
	{
		broadcasterListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(broadcasterListener, "SELECT * FROM " + value, value);
	}
}
