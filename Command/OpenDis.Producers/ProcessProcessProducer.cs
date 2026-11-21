using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Producers;

internal class ProcessProcessProducer : ServiceMerchantService
{
	private Connection m_RegListener;

	public ProcessProcessProducer(Connection connection_0)
	{
		m_RegListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_RegListener, "SELECT * FROM " + value, value);
	}
}
