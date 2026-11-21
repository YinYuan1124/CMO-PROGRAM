using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Filter;

internal class PrototypeInstanceFilter : ServiceMerchantService
{
	private Connection m_ParserListener;

	public PrototypeInstanceFilter(Connection connection_0)
	{
		m_ParserListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_ParserListener, "SELECT * FROM " + value, value);
	}
}
