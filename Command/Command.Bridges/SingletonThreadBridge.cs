using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Bridges;

internal class SingletonThreadBridge : ServiceMerchantService
{
	private Connection m_MockListener;

	public SingletonThreadBridge(Connection connection_0)
	{
		m_MockListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_MockListener, "SELECT * FROM " + value, value);
	}
}
