using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using baileysoft.Wmi;

namespace OpenDis.Services;

internal class SystemMerchantService : ServiceMerchantService
{
	private Connection m_PredicateListener;

	public SystemMerchantService(Connection connection_0)
	{
		m_PredicateListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_PredicateListener, "SELECT * FROM " + value, value);
	}
}
