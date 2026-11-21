using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;

namespace baileysoft.Wmi;

public sealed class Win32_BaseBoard : ServiceMerchantService
{
	private Connection adapterListener;

	public Win32_BaseBoard(Connection connection_0)
	{
		adapterListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(adapterListener, "SELECT * FROM " + value, value);
	}
}
