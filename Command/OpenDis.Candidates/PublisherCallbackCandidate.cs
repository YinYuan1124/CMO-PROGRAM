using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Candidates;

internal class PublisherCallbackCandidate : ServiceMerchantService
{
	private Connection _WorkerListener;

	public PublisherCallbackCandidate(Connection connection_0)
	{
		_WorkerListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_WorkerListener, "SELECT * FROM " + value, value);
	}
}
