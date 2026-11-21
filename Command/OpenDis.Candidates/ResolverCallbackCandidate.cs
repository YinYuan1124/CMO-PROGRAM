using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Candidates;

internal class ResolverCallbackCandidate : ServiceMerchantService
{
	private Connection visitorListener;

	public ResolverCallbackCandidate(Connection connection_0)
	{
		visitorListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(visitorListener, "SELECT * FROM " + value, value);
	}
}
