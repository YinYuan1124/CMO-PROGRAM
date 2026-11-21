using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Serialization;

public class BaseCollection<T> : IEnumerable<T>, IEnumerable, ICollection<T> where T : class
{
	public class BaseCollectionEnumerator<TE> : IEnumerator<TE>, IDisposable, IEnumerator where TE : class
	{
		private readonly IEnumerator exceptionPrototype;

		private static object m_AttrPrototype;

		public TE Current => exceptionPrototype.Current as TE;

		object IEnumerator.Current => exceptionPrototype.Current as TE;

		public BaseCollectionEnumerator(IEnumerator ienumerator_0)
		{
			exceptionPrototype = ienumerator_0;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return exceptionPrototype.MoveNext();
		}

		public void Reset()
		{
			exceptionPrototype.Reset();
		}

		internal static bool CountInterruptibleMock()
		{
			return m_AttrPrototype == null;
		}
	}

	private List<T> _ParameterObject;

	internal static object expressionObject;

	[Serialize("InnerList")]
	protected List<T> InnerList
	{
		get
		{
			return _ParameterObject;
		}
		set
		{
			if (_ParameterObject != null && _ParameterObject.Count > 0)
			{
				foreach (T item in _ParameterObject)
				{
					OnExclude(item);
				}
			}
			_ParameterObject = value;
			foreach (T item2 in _ParameterObject)
			{
				OnInclude(item2);
			}
			OnInnerListSet();
		}
	}

	public bool IsReadOnly => false;

	public int Count => InnerList.Count;

	public void Add(T item)
	{
		Include(item);
		InnerList.Add(item);
		OnIncludeComplete(item);
		OnInsert(InnerList.IndexOf(item), item);
	}

	public bool Contains(T item)
	{
		return InnerList.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		InnerList.CopyTo(array, arrayIndex);
	}

	public void Move(T item, int int_0)
	{
		if (!InnerList.Contains(item))
		{
			return;
		}
		int num = InnerList.IndexOf(item);
		if (num != int_0)
		{
			InnerList.RemoveAt(num);
			if (InnerList.Count <= int_0)
			{
				InnerList.Add(item);
			}
			else if (int_0 < 0)
			{
				InnerList.Insert(0, item);
			}
			else
			{
				InnerList.Insert(int_0, item);
			}
			OnMoved(item, InnerList.IndexOf(item));
		}
	}

	public bool Remove(T item)
	{
		if (InnerList.Contains(item))
		{
			int int_ = InnerList.IndexOf(item);
			InnerList.Remove(item);
			OnRemoveComplete(int_, item);
			return true;
		}
		return false;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return InnerList.GetEnumerator();
	}

	public void Clear()
	{
		OnClear();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return InnerList.GetEnumerator();
	}

	protected virtual void OnInnerListSet()
	{
	}

	protected virtual void OnClear()
	{
		List<T> list = new List<T>();
		foreach (T inner in InnerList)
		{
			list.Add(inner);
		}
		foreach (T item in list)
		{
			Remove(item);
		}
	}

	protected virtual void OnInsert(int int_0, object object_0)
	{
		T item = object_0 as T;
		Include(item);
	}

	protected virtual void OnInsertComplete(int int_0, object object_0)
	{
		T item = object_0 as T;
		OnIncludeComplete(item);
	}

	protected virtual void OnRemoveComplete(int int_0, object object_0)
	{
		T item = object_0 as T;
		Exclude(item);
	}

	protected virtual void OnSet(int int_0, object object_0, object object_1)
	{
		T item = object_1 as T;
		Include(item);
	}

	protected virtual void OnSetComplete(int int_0, object object_0, object object_1)
	{
		T item = object_0 as T;
		Exclude(item);
		item = object_1 as T;
		OnIncludeComplete(item);
	}

	protected virtual void OnInclude(T item)
	{
	}

	protected virtual void OnMoved(T item, int int_0)
	{
	}

	protected virtual void OnIncludeComplete(T item)
	{
	}

	protected virtual void OnExclude(T item)
	{
	}

	protected void Include(T item)
	{
		if (!InnerList.Contains(item))
		{
			OnInclude(item);
		}
	}

	protected void Exclude(T item)
	{
		if (!InnerList.Contains(item))
		{
			OnExclude(item);
		}
	}

	public BaseCollection()
	{
		_ParameterObject = new List<T>();
	}

	internal static bool ReflectExpression()
	{
		return expressionObject == null;
	}
}
