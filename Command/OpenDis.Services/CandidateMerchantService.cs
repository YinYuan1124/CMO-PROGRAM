using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using baileysoft.Wmi;

namespace OpenDis.Services;

internal class CandidateMerchantService : ServiceMerchantService
{
	private Connection databaseListener;

	public CandidateMerchantService(Connection connection_0)
	{
		databaseListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(databaseListener, "SELECT * FROM " + value, value);
	}
}
