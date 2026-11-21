using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Candidates;

internal class SystemListener : ServiceMerchantService
{
	private Connection candidateListener;

	public SystemListener(Connection connection_0)
	{
		candidateListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(candidateListener, "SELECT * FROM " + value, value);
	}
}
