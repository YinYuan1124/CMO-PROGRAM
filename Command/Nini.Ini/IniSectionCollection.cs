using System;
using System.Collections;
using Nini.Util;

namespace Nini.Ini;

public class IniSectionCollection : IEnumerable, ICollection
{
	private OrderedList _ProcCallback = new OrderedList();

	public IniSection this[int int_0] => (IniSection)_ProcCallback[int_0];

	public IniSection this[string string_0] => (IniSection)_ProcCallback[string_0];

	public int Count => _ProcCallback.Count;

	public object SyncRoot => _ProcCallback.SyncRoot;

	public bool IsSynchronized => _ProcCallback.IsSynchronized;

	public void Add(IniSection iniSection_0)
	{
		if (_ProcCallback.Contains(iniSection_0))
		{
			throw new ArgumentException("IniSection already exists");
		}
		_ProcCallback.Add(iniSection_0.Name, iniSection_0);
	}

	public void Remove(string string_0)
	{
		_ProcCallback.Remove(string_0);
	}

	public void CopyTo(Array array, int index)
	{
		_ProcCallback.CopyTo(array, index);
	}

	public void CopyTo(IniSection[] iniSection_0, int int_0)
	{
		((ICollection)_ProcCallback).CopyTo((Array)iniSection_0, int_0);
	}

	public IEnumerator GetEnumerator()
	{
		return _ProcCallback.GetEnumerator();
	}
}
