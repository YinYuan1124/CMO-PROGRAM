using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace OpenDis.Producers;

internal class ExporterListener : ServiceMerchantService
{
	private Connection _PrototypeListener;

	public ExporterListener(Connection connection_0)
	{
		_PrototypeListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_PrototypeListener, "SELECT * FROM " + value, value);
	}
}
