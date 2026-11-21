using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Mocks;

internal class FactoryParameterMock : ServiceMerchantService
{
	private Connection queueListener;

	public FactoryParameterMock(Connection connection_0)
	{
		queueListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(queueListener, "SELECT * FROM " + value, value);
	}
}
