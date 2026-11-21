using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Filters;

internal class ProccesorRegistryFilter : ServiceMerchantService
{
	private Connection m_InterceptorListener;

	public ProccesorRegistryFilter(Connection connection_0)
	{
		m_InterceptorListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_InterceptorListener, "SELECT * FROM " + value, value);
	}
}
