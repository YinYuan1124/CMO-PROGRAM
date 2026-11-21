using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Messages;

internal class EventListener : ServiceMerchantService
{
	private Connection m_GlobalListener;

	public EventListener(Connection connection_0)
	{
		m_GlobalListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_GlobalListener, "SELECT * FROM " + value, value);
	}
}
