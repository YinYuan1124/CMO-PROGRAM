using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Tasks;

internal class ParameterCollectionTask : ServiceMerchantService
{
	private Connection _InfoListener;

	public ParameterCollectionTask(Connection connection_0)
	{
		_InfoListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_InfoListener, "SELECT * FROM " + value, value);
	}
}
