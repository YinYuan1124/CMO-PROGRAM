using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Specifications;

internal class InvocationDefinitionSpec : ServiceMerchantService
{
	private Connection annotationListener;

	public InvocationDefinitionSpec(Connection connection_0)
	{
		annotationListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(annotationListener, "SELECT * FROM " + value, value);
	}
}
