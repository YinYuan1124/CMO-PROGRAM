using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListWithLock<T> : IEnumerable<T>, IEnumerable
{
	private List<T> _Reader = new List<T>();

	private static object _Property;

	internal static object m_Importer;

	public List<T> Raw
	{
		get
		{
			lock (_Property)
			{
				return _Reader;
			}
		}
	}

	public ListWithLock()
	{
	}

	public ListWithLock(IEnumerable<T> ienumerable_0)
	{
		lock (_Property)
		{
			_Reader = new List<T>(ienumerable_0);
		}
	}

	public void Clear()
	{
		lock (_Property)
		{
			_Reader.Clear();
		}
	}

	public void Add(T value)
	{
		lock (_Property)
		{
			_Reader.Add(value);
		}
	}

	public void Add(List<T> list_0)
	{
		lock (_Property)
		{
			_Reader.AddRange(list_0);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		lock (_Property)
		{
			return Raw.GetEnumerator();
		}
	}

	public bool Remove(T item)
	{
		lock (_Property)
		{
			return _Reader.Remove(item);
		}
	}

	public int Remove(Predicate<T> predicate_0)
	{
		lock (_Property)
		{
			return _Reader.RemoveAll(predicate_0);
		}
	}

	public T Yank(Func<T, bool> func_0)
	{
		lock (_Property)
		{
			T val = _Reader.Where(func_0).First();
			if (val != null)
			{
				_Reader.Remove(val);
			}
			return val;
		}
	}

	public T Yank(Func<T, int, bool> func_0)
	{
		lock (_Property)
		{
			T val = _Reader.Where(func_0).First();
			if (val != null)
			{
				_Reader.Remove(val);
			}
			return val;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		lock (_Property)
		{
			return ((IEnumerable)_Reader).GetEnumerator();
		}
	}

	static ListWithLock()
	{
		_Property = new object();
	}

	internal static bool InterruptStruct()
	{
		return m_Importer == null;
	}
}
