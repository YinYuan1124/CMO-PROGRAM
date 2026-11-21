using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[Serializable]
public sealed class GroupsCollection : KeyedCollection<string, Group>
{
	public delegate void CollectionChangedEventHandler();

	[CompilerGenerated]
	private sealed class ClientItem
	{
		public string theName;

		internal bool ValidateInterruptibleQueue(Group theG)
		{
			return Operators.CompareString(theG.Name, theName, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class DicItem
	{
		public string theName;

		internal bool LoginInterruptibleQueue(Group theG)
		{
			return Operators.CompareString(theG.Name, theName, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private static CollectionChangedEventHandler _OnItemChanged;

	public static event CollectionChangedEventHandler CollectionChanged
	{
		[CompilerGenerated]
		add
		{
			CollectionChangedEventHandler collectionChangedEventHandler = _OnItemChanged;
			CollectionChangedEventHandler collectionChangedEventHandler2;
			do
			{
				collectionChangedEventHandler2 = collectionChangedEventHandler;
				CollectionChangedEventHandler value2 = (CollectionChangedEventHandler)Delegate.Combine(collectionChangedEventHandler2, value);
				collectionChangedEventHandler = Interlocked.CompareExchange(ref _OnItemChanged, value2, collectionChangedEventHandler2);
			}
			while ((object)collectionChangedEventHandler != collectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CollectionChangedEventHandler collectionChangedEventHandler = _OnItemChanged;
			CollectionChangedEventHandler collectionChangedEventHandler2;
			do
			{
				collectionChangedEventHandler2 = collectionChangedEventHandler;
				CollectionChangedEventHandler value2 = (CollectionChangedEventHandler)Delegate.Remove(collectionChangedEventHandler2, value);
				collectionChangedEventHandler = Interlocked.CompareExchange(ref _OnItemChanged, value2, collectionChangedEventHandler2);
			}
			while ((object)collectionChangedEventHandler != collectionChangedEventHandler2);
		}
	}

	protected override string GetKeyForItem(Group item)
	{
		return item.ObjectID;
	}

	protected override void InsertItem(int index, Group item)
	{
		base.InsertItem(index, item);
		_OnItemChanged?.Invoke();
	}

	protected override void SetItem(int index, Group item)
	{
		base.SetItem(index, item);
		_OnItemChanged?.Invoke();
	}

	protected override void RemoveItem(int index)
	{
		base.RemoveItem(index);
		_OnItemChanged?.Invoke();
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		_OnItemChanged?.Invoke();
	}

	public Group GetByName(string string_0)
	{
		return (from theG in this
			select (theG) into theG
			where Operators.CompareString(theG.Name, string_0, TextCompare: false) == 0
			select theG).ElementAtOrDefault(0);
	}

	public bool ContainsByName(string string_0)
	{
		return (from theG in this
			select (theG) into theG
			where Operators.CompareString(theG.Name, string_0, TextCompare: false) == 0
			select theG).Count() > 0;
	}
}
