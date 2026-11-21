using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Pages;

internal class ProducerPage : ServiceMerchantService
{
	private Connection m_ServiceListener;

	public ProducerPage(Connection connection_0)
	{
		m_ServiceListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_ServiceListener, "SELECT * FROM " + value, value);
	}
}
