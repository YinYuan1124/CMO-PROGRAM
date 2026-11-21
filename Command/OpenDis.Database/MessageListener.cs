using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Database;

internal class MessageListener : ServiceMerchantService
{
	private Connection productListener;

	public MessageListener(Connection connection_0)
	{
		productListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(productListener, "SELECT * FROM " + value, value);
	}
}
