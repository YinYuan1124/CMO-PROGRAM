using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

public sealed class FastObservableCollection<T> : ObservableCollection<T>
{
	private readonly object m_Observer = new object();

	private bool _Issuer;

	[CompilerGenerated]
	private NotifyCollectionChangedEventHandler m_Client;

	public override event NotifyCollectionChangedEventHandler CollectionChanged
	{
		[CompilerGenerated]
		add
		{
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = m_Client;
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
			do
			{
				notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
				NotifyCollectionChangedEventHandler value2 = (NotifyCollectionChangedEventHandler)Delegate.Combine(notifyCollectionChangedEventHandler2, value);
				notifyCollectionChangedEventHandler = Interlocked.CompareExchange(ref m_Client, value2, notifyCollectionChangedEventHandler2);
			}
			while ((object)notifyCollectionChangedEventHandler != notifyCollectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = m_Client;
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
			do
			{
				notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
				NotifyCollectionChangedEventHandler value2 = (NotifyCollectionChangedEventHandler)Delegate.Remove(notifyCollectionChangedEventHandler2, value);
				notifyCollectionChangedEventHandler = Interlocked.CompareExchange(ref m_Client, value2, notifyCollectionChangedEventHandler2);
			}
			while ((object)notifyCollectionChangedEventHandler != notifyCollectionChangedEventHandler2);
		}
	}

	public FastObservableCollection()
	{
		_Issuer = false;
	}

	public void AddItems(IList<T> ilist_0)
	{
		lock (m_Observer)
		{
			SuspendCollectionChangeNotification();
			foreach (T item in ilist_0)
			{
				InsertItem(base.Count, item);
			}
			NotifyChanges();
		}
	}

	public void NotifyChanges()
	{
		ResumeCollectionChangeNotification();
		NotifyCollectionChangedEventArgs e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
		OnCollectionChanged(e);
	}

	public void RemoveItems(IList<T> ilist_0)
	{
		lock (m_Observer)
		{
			SuspendCollectionChangeNotification();
			foreach (T item in ilist_0)
			{
				Remove(item);
			}
			NotifyChanges();
		}
	}

	public void ResumeCollectionChangeNotification()
	{
		_Issuer = false;
	}

	public void SuspendCollectionChangeNotification()
	{
		_Issuer = true;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		using (BlockReentrancy())
		{
			if (_Issuer)
			{
				return;
			}
			NotifyCollectionChangedEventHandler client = m_Client;
			if (client == null)
			{
				return;
			}
			Delegate[] invocationList = client.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = (NotifyCollectionChangedEventHandler)invocationList[i];
				if (notifyCollectionChangedEventHandler.Target is DispatcherObject dispatcherObject && !dispatcherObject.CheckAccess())
				{
					dispatcherObject.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, notifyCollectionChangedEventHandler, this, e);
				}
				else
				{
					notifyCollectionChangedEventHandler(this, e);
				}
			}
		}
	}
}
