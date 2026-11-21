using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;

namespace baileysoft.Wmi;

public sealed class Win32_Processor : ServiceMerchantService
{
	private Connection m_AlgoListener;

	public Win32_Processor(Connection connection_0)
	{
		m_AlgoListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_AlgoListener, "SELECT * FROM " + value, value);
	}
}
