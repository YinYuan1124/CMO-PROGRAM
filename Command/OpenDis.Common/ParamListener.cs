using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Common;

internal class ParamListener : ServiceMerchantService
{
	private Connection m_PageListener;

	public ParamListener(Connection connection_0)
	{
		m_PageListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_PageListener, "SELECT * FROM " + value, value);
	}
}
