using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Specifications;

internal class ClassDefinitionSpec : ServiceMerchantService
{
	private Connection m_RoleListener;

	public ClassDefinitionSpec(Connection connection_0)
	{
		m_RoleListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_RoleListener, "SELECT * FROM " + value, value);
	}
}
