using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Specifications;

internal class TemplateListener : ServiceMerchantService
{
	private Connection m_MappingListener;

	public TemplateListener(Connection connection_0)
	{
		m_MappingListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_MappingListener, "SELECT * FROM " + value, value);
	}
}
