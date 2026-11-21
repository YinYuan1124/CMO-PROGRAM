using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;

namespace baileysoft.Wmi;

public sealed class Win32_MemoryDevice : ServiceMerchantService
{
	private Connection _FieldListener;

	public Win32_MemoryDevice(Connection connection_0)
	{
		_FieldListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(_FieldListener, "SELECT * FROM " + value, value);
	}
}
