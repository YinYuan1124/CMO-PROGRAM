using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Common;

internal class FactoryListener : ServiceMerchantService
{
	private Connection m_AttributeListener;

	public FactoryListener(Connection connection_0)
	{
		m_AttributeListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_AttributeListener, "SELECT * FROM " + value, value);
	}
}
