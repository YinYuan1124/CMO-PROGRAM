using System.Collections;
using Nini.Util;

namespace Nini.Ini;

public class IniSection
{
	private OrderedList mapperCallback = new OrderedList();

	private string managerCallback = "";

	private string _GetterCallback;

	private int m_ProducerCallback;

	public string Name => managerCallback;

	public string Comment => _GetterCallback;

	public int ItemCount => mapperCallback.Count;

	public IniSection(string string_0, string string_1)
	{
		managerCallback = string_0;
		_GetterCallback = string_1;
	}

	public IniSection(string string_0)
		: this(string_0, null)
	{
	}

	public string GetValue(string string_0)
	{
		string result = null;
		if (Contains(string_0))
		{
			result = ((IniItem)mapperCallback[string_0]).Value;
		}
		return result;
	}

	public IniItem GetItem(int int_0)
	{
		return (IniItem)mapperCallback[int_0];
	}

	public string[] GetKeys()
	{
		ArrayList arrayList = new ArrayList();
		IniItem iniItem = null;
		for (int i = 0; i < mapperCallback.Count; i++)
		{
			iniItem = (IniItem)mapperCallback[i];
			if (iniItem.Type == IniType.Key)
			{
				arrayList.Add(iniItem.Name);
			}
		}
		string[] array = new string[arrayList.Count];
		arrayList.CopyTo(array, 0);
		return array;
	}

	public bool Contains(string string_0)
	{
		return mapperCallback[string_0] != null;
	}

	public void Set(string string_0, string string_1, string string_2)
	{
		IniItem iniItem = null;
		if (Contains(string_0))
		{
			iniItem = (IniItem)mapperCallback[string_0];
			iniItem.Value = string_1;
			iniItem.Comment = string_2;
		}
		else
		{
			iniItem = new IniItem(string_0, string_1, IniType.Key, string_2);
			mapperCallback.Add(string_0, iniItem);
		}
	}

	public void Set(string string_0, string string_1)
	{
		Set(string_0, string_1, null);
	}

	public void Set(string string_0)
	{
		string text = "#comment" + m_ProducerCallback;
		IniItem value = new IniItem(text, null, IniType.Empty, string_0);
		mapperCallback.Add(text, value);
		m_ProducerCallback++;
	}

	public void Set()
	{
		Set(null);
	}

	public void Remove(string string_0)
	{
		if (Contains(string_0))
		{
			mapperCallback.Remove(string_0);
		}
	}
}
