using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DarkUI.Collections;

public class ObservableList<T> : List<T>, IDisposable
{
	private bool _ProcExpression;

	[CompilerGenerated]
	private EventHandler<ObservableListModified<T>> structDispatcher;

	[CompilerGenerated]
	private EventHandler<object> callbackDispatcher;

	internal static object _DecoratorDispatcher;

	private EventHandler<ObservableListModified<T>> _MerchantDispatcher;

	public event EventHandler<ObservableListModified<T>> ItemsAdded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<T>> eventHandler = structDispatcher;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref structDispatcher, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<T>> eventHandler = structDispatcher;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref structDispatcher, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ObservableListModified<T>> ItemsRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<T>> eventHandler = _MerchantDispatcher;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _MerchantDispatcher, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<T>> eventHandler = _MerchantDispatcher;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _MerchantDispatcher, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public event EventHandler<object> ItemsCleared
	{
		[CompilerGenerated]
		add
		{
			EventHandler<object> eventHandler = callbackDispatcher;
			EventHandler<object> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<object> value2 = (EventHandler<object>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref callbackDispatcher, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<object> eventHandler = callbackDispatcher;
			EventHandler<object> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<object> value2 = (EventHandler<object>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref callbackDispatcher, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	~ObservableList()
	{
		Dispose(bool_0: false);
	}

	public void Dispose()
	{
		Dispose(bool_0: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_0)
	{
		if (!_ProcExpression)
		{
			if (structDispatcher != null)
			{
				structDispatcher = null;
			}
			if (_MerchantDispatcher != null)
			{
				_MerchantDispatcher = null;
			}
			_ProcExpression = true;
		}
	}

	public new void Add(T item)
	{
		base.Add(item);
		if (structDispatcher != null)
		{
			structDispatcher(this, new ObservableListModified<T>(new List<T> { item }));
		}
	}

	public new void AddRange(IEnumerable<T> ienumerable_0)
	{
		List<T> list = ienumerable_0.ToList();
		base.AddRange((IEnumerable<T>)list);
		if (structDispatcher != null)
		{
			structDispatcher(this, new ObservableListModified<T>(list));
		}
	}

	public new void Remove(T item)
	{
		base.Remove(item);
		if (_MerchantDispatcher != null)
		{
			_MerchantDispatcher(this, new ObservableListModified<T>(new List<T> { item }));
		}
	}

	public new void Clear()
	{
		base.Clear();
		if (callbackDispatcher != null)
		{
			callbackDispatcher(this, null);
		}
	}

	internal static bool InvokeDefinition()
	{
		return _DecoratorDispatcher == null;
	}
}
