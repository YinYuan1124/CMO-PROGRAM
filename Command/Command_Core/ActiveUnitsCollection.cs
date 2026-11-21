using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ActiveUnitsCollection : KeyedCollection<string, ActiveUnit>
{
	public delegate void CollectionChangedEventHandler();

	[CompilerGenerated]
	private static CollectionChangedEventHandler attributeVal;

	public static event CollectionChangedEventHandler CollectionChanged
	{
		[CompilerGenerated]
		add
		{
			CollectionChangedEventHandler collectionChangedEventHandler = attributeVal;
			CollectionChangedEventHandler collectionChangedEventHandler2;
			do
			{
				collectionChangedEventHandler2 = collectionChangedEventHandler;
				CollectionChangedEventHandler value2 = (CollectionChangedEventHandler)Delegate.Combine(collectionChangedEventHandler2, value);
				collectionChangedEventHandler = Interlocked.CompareExchange(ref attributeVal, value2, collectionChangedEventHandler2);
			}
			while ((object)collectionChangedEventHandler != collectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CollectionChangedEventHandler collectionChangedEventHandler = attributeVal;
			CollectionChangedEventHandler collectionChangedEventHandler2;
			do
			{
				collectionChangedEventHandler2 = collectionChangedEventHandler;
				CollectionChangedEventHandler value2 = (CollectionChangedEventHandler)Delegate.Remove(collectionChangedEventHandler2, value);
				collectionChangedEventHandler = Interlocked.CompareExchange(ref attributeVal, value2, collectionChangedEventHandler2);
			}
			while ((object)collectionChangedEventHandler != collectionChangedEventHandler2);
		}
	}

	protected override string GetKeyForItem(ActiveUnit item)
	{
		return item.ObjectID;
	}

	protected override void InsertItem(int index, ActiveUnit item)
	{
		base.InsertItem(index, item);
		attributeVal?.Invoke();
	}

	protected override void SetItem(int index, ActiveUnit item)
	{
		base.SetItem(index, item);
		attributeVal?.Invoke();
	}

	protected override void RemoveItem(int index)
	{
		base.RemoveItem(index);
		attributeVal?.Invoke();
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		attributeVal?.Invoke();
	}

	public ActiveUnit GetByName(string string_0)
	{
		try
		{
			using (IEnumerator<ActiveUnit> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ActiveUnit current = enumerator.Current;
					if (string.CompareOrdinal(current.Name, string_0) == 0)
					{
						return current;
					}
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100996", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}
}
