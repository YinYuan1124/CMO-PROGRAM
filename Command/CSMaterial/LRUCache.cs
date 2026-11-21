using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Command.Specifications;

namespace CSMaterial;

public class LRUCache<K, V>
{
	private int _ImporterDispatcher;

	private bool _RepositoryDispatcher;

	private Dictionary<K, LinkedListNode<RequestDispatcher<K, V>>> bridgeDispatcher = new Dictionary<K, LinkedListNode<RequestDispatcher<K, V>>>();

	private LinkedList<RequestDispatcher<K, V>> _InvocationDispatcher = new LinkedList<RequestDispatcher<K, V>>();

	internal static object m_ClassDispatcher;

	public LRUCache(int int_0, bool bool_0)
	{
		_ImporterDispatcher = int_0;
		_RepositoryDispatcher = bool_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public V get(K key)
	{
		if (bridgeDispatcher.TryGetValue(key, out var value))
		{
			V tokenizerDispatcher = value.Value._TokenizerDispatcher;
			_InvocationDispatcher.Remove(value);
			_InvocationDispatcher.AddLast(value);
			return tokenizerDispatcher;
		}
		return default(V);
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void add(K key, V val)
	{
		if (bridgeDispatcher.TryGetValue(key, out var value))
		{
			_InvocationDispatcher.Remove(value);
			if (_RepositoryDispatcher && value.Value._TokenizerDispatcher is IDisposable)
			{
				((IDisposable)(object)value.Value._TokenizerDispatcher).Dispose();
			}
		}
		else if (bridgeDispatcher.Count >= _ImporterDispatcher)
		{
			FindDefinition();
		}
		LinkedListNode<RequestDispatcher<K, V>> linkedListNode = new LinkedListNode<RequestDispatcher<K, V>>(new RequestDispatcher<K, V>(key, val));
		_InvocationDispatcher.AddLast(linkedListNode);
		bridgeDispatcher[key] = linkedListNode;
	}

	private void FindDefinition()
	{
		LinkedListNode<RequestDispatcher<K, V>> first = _InvocationDispatcher.First;
		_InvocationDispatcher.RemoveFirst();
		bridgeDispatcher.Remove(first.Value._ValueDispatcher);
		if (_RepositoryDispatcher && first.Value._TokenizerDispatcher is IDisposable)
		{
			((IDisposable)(object)first.Value._TokenizerDispatcher).Dispose();
		}
	}

	internal static bool SetDefinition()
	{
		return m_ClassDispatcher == null;
	}
}
