using System.Collections.Generic;
using System.Text.RegularExpressions;
using Command.Dictionaries;
using OpenDis.Services;
using baileysoft.Wmi;

namespace Command.Tasks;

internal class ObjectCollectionTask : ServiceMerchantService
{
	private Connection m_TagListener;

	public ObjectCollectionTask(Connection connection_0)
	{
		m_TagListener = connection_0;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return MappingExpressionDic.ViewObserver(m_TagListener, "SELECT * FROM " + value, value);
	}
}
