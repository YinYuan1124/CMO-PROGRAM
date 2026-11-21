using System;
using System.Collections.Generic;
using System.Management;
using Command.Managers;
using baileysoft.Wmi;

namespace Command.Dictionaries;

internal class MappingExpressionDic
{
	public static IList<string> ViewObserver(Connection connection_0, string string_0, string string_1)
	{
		ManagementScope getConnectionScope = connection_0.GetConnectionScope;
		List<string> list = new List<string>();
		SelectQuery query = new SelectQuery(string_0);
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(getConnectionScope, query);
		try
		{
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				foreach (string item2 in HelperListenerManager.ValidateObserver(string_1))
				{
					try
					{
						list.Add(item2 + ": " + item[item2]);
					}
					catch (SystemException)
					{
					}
				}
			}
			return list;
		}
		catch (ManagementException)
		{
			return list;
		}
	}
}
