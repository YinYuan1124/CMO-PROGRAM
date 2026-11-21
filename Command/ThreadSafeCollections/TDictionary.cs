using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	[CompilerGenerated]
	private sealed class TokenRegistryFilter
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		internal TValue DisableInterruptibleTemplate()
		{
			return _003C_003E4__this.workerMerchant[key];
		}
	}

	[CompilerGenerated]
	private sealed class BaseMerchantService
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		public TValue value;

		internal TValue UpdateInterruptibleTemplate()
		{
			return _003C_003E4__this.workerMerchant[key] = value;
		}
	}

	[CompilerGenerated]
	private sealed class GetterListenerManager
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		public Func<TValue> func;

		internal TValue InsertInterruptibleTemplate()
		{
			MessageExporter CS_0024_003C_003E8__locals0 = new MessageExporter
			{
				CS_0024_003C_003E8__locals1 = this
			};
			if (_003C_003E4__this.workerMerchant.TryGetValue(key, out CS_0024_003C_003E8__locals0.rVal))
			{
				return CS_0024_003C_003E8__locals0.rVal;
			}
			_003C_003E4__this._GlobalMerchant.PerformUsingWriteLock(delegate
			{
				CS_0024_003C_003E8__locals0.rVal = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.func();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.workerMerchant.Add(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.key, CS_0024_003C_003E8__locals0.rVal);
				return CS_0024_003C_003E8__locals0.rVal;
			});
			return CS_0024_003C_003E8__locals0.rVal;
		}
	}

	[CompilerGenerated]
	private sealed class MessageExporter
	{
		public TValue rVal;

		public GetterListenerManager CS_0024_003C_003E8__locals1;

		internal TValue PrepareInterruptibleTemplate()
		{
			rVal = CS_0024_003C_003E8__locals1.func();
			CS_0024_003C_003E8__locals1._003C_003E4__this.workerMerchant.Add(CS_0024_003C_003E8__locals1.key, rVal);
			return rVal;
		}
	}

	[CompilerGenerated]
	private sealed class SpecificationDecoratorEntry
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		public TValue value;

		internal void ReflectInterruptibleTemplate()
		{
			_003C_003E4__this.workerMerchant.Add(key, value);
		}
	}

	[CompilerGenerated]
	private sealed class ProcessMerchantPage
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		public TValue value;

		internal void VisitInterruptibleTemplate()
		{
			_003C_003E4__this.workerMerchant.Add(key, value);
		}
	}

	[CompilerGenerated]
	private sealed class WriterDefinitionSpec
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		public TValue value;

		public bool rVal;

		internal void RestartInterruptibleTemplate()
		{
			if (!_003C_003E4__this.workerMerchant.ContainsKey(key))
			{
				_003C_003E4__this.workerMerchant.Add(key, value);
				rVal = true;
			}
		}
	}

	[CompilerGenerated]
	private sealed class ThreadMerchantPage
	{
		public IEnumerable<TKey> keys;

		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TValue defaultValue;

		internal void TestInterruptibleTemplate()
		{
			foreach (TKey key in keys)
			{
				if (!_003C_003E4__this.workerMerchant.ContainsKey(key))
				{
					_003C_003E4__this.workerMerchant.Add(key, defaultValue);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class ValParameterMessage
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		public TValue value;

		public bool rVal;

		internal void StopInterruptibleTemplate()
		{
			if (_003C_003E4__this.workerMerchant.ContainsKey(key))
			{
				_003C_003E4__this.workerMerchant[key] = value;
				return;
			}
			_003C_003E4__this.workerMerchant.Add(key, value);
			rVal = true;
		}
	}

	[CompilerGenerated]
	private sealed class WrapperParameterMessage
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		public TValue NewValue;

		public bool rVal;

		internal void CancelInterruptibleTemplate()
		{
			if (_003C_003E4__this.workerMerchant.ContainsKey(key))
			{
				_003C_003E4__this.workerMerchant[key] = NewValue;
				rVal = true;
			}
		}
	}

	[CompilerGenerated]
	private sealed class EventParameterMock
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public KeyValuePair<TKey, TValue> item;

		internal bool VerifyInterruptibleTemplate()
		{
			if (_003C_003E4__this.workerMerchant.ContainsKey(item.Key))
			{
				return _003C_003E4__this.workerMerchant.ContainsValue(item.Value);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ProductCollectionRecord
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		internal bool ListInterruptibleTemplate()
		{
			return _003C_003E4__this.workerMerchant.ContainsKey(key);
		}
	}

	[CompilerGenerated]
	private sealed class WatcherDecoratorEntry
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TValue value;

		internal bool ResolveInterruptibleTemplate()
		{
			return _003C_003E4__this.workerMerchant.ContainsValue(value);
		}
	}

	[CompilerGenerated]
	private sealed class ContainerObjectListener
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public TKey key;

		internal bool PostInterruptibleTemplate()
		{
			if (_003C_003E4__this.workerMerchant.ContainsKey(key))
			{
				return _003C_003E4__this.workerMerchant.Remove(key);
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class TagExpressionDic
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public KeyValuePair<TKey, TValue> item;

		internal bool RunInterruptibleTemplate()
		{
			if (_003C_003E4__this.workerMerchant.TryGetValue(item.Key, out var value))
			{
				if (EqualityComparer<TValue>.Default.Equals(value, item.Value))
				{
					return _003C_003E4__this.workerMerchant.Remove(item.Key);
				}
				return false;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ProductExporter
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public Predicate<TKey> predKey;

		public Predicate<TValue> predValue;

		internal bool StartInterruptibleTemplate()
		{
			if (_003C_003E4__this.workerMerchant.Keys.Count == 0)
			{
				return true;
			}
			List<TKey> list = new List<TKey>();
			foreach (TKey key in _003C_003E4__this.workerMerchant.Keys)
			{
				bool flag = false;
				if (predKey != null)
				{
					flag = predKey(key);
				}
				if (!flag && predValue != null && predValue(_003C_003E4__this.workerMerchant[key]))
				{
					flag = true;
				}
				if (flag)
				{
					list.Add(key);
				}
			}
			foreach (TKey item in list)
			{
				_003C_003E4__this.workerMerchant.Remove(item);
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class AnnotationExporter
	{
		public TDictionary<TKey, TValue> _003C_003E4__this;

		public KeyValuePair<TKey, TValue>[] array;

		public int arrayIndex;

		internal void AssetInterruptibleTemplate()
		{
			_003C_003E4__this.workerMerchant.ToArray().CopyTo(array, arrayIndex);
		}
	}

	[CompilerGenerated]
	private sealed class IteratorExporter
	{
		public Dictionary<TKey, TValue> localDict;

		public TDictionary<TKey, TValue> _003C_003E4__this;

		internal Dictionary<TKey, TValue> PrintInterruptibleTemplate()
		{
			return localDict = new Dictionary<TKey, TValue>(_003C_003E4__this.workerMerchant);
		}
	}

	[CompilerGenerated]
	private sealed class InitializerExporter
	{
		public Dictionary<TKey, TValue> localDict;

		public TDictionary<TKey, TValue> _003C_003E4__this;

		internal Dictionary<TKey, TValue> DefineInterruptibleTemplate()
		{
			return localDict = new Dictionary<TKey, TValue>(_003C_003E4__this.workerMerchant);
		}
	}

	private readonly ReaderWriterLockSlim _GlobalMerchant = new ReaderWriterLockSlim();

	private readonly Dictionary<TKey, TValue> workerMerchant;

	internal static object _AccountMerchant;

	public ICollection<TKey> Keys => _GlobalMerchant.PerformUsingReadLock(() => workerMerchant.Keys);

	public ICollection<TValue> Values => _GlobalMerchant.PerformUsingReadLock(() => workerMerchant.Values);

	public TValue this[TKey key]
	{
		get
		{
			return _GlobalMerchant.PerformUsingReadLock(() => workerMerchant[key]);
		}
		set
		{
			_GlobalMerchant.PerformUsingWriteLock(() => workerMerchant[key] = value);
		}
	}

	public int Count => _GlobalMerchant.PerformUsingReadLock(() => workerMerchant.Count);

	public bool IsReadOnly => false;

	public TDictionary()
	{
		workerMerchant = new Dictionary<TKey, TValue>();
	}

	public TDictionary(int int_0)
	{
		workerMerchant = new Dictionary<TKey, TValue>(int_0);
	}

	public TDictionary(IEqualityComparer<TKey> iequalityComparer_0)
	{
		workerMerchant = new Dictionary<TKey, TValue>(iequalityComparer_0);
	}

	public TDictionary(IDictionary<TKey, TValue> idictionary_0)
	{
		workerMerchant = new Dictionary<TKey, TValue>(idictionary_0);
	}

	public TDictionary(int int_0, IEqualityComparer<TKey> iequalityComparer_0)
	{
		workerMerchant = new Dictionary<TKey, TValue>(int_0, iequalityComparer_0);
	}

	public TDictionary(IDictionary<TKey, TValue> idictionary_0, IEqualityComparer<TKey> iequalityComparer_0)
	{
		workerMerchant = new Dictionary<TKey, TValue>(idictionary_0, iequalityComparer_0);
	}

	public TValue GetValueAddIfNotExist(TKey key, Func<TValue> func_0)
	{
		return _GlobalMerchant.PerformUsingUpgradeableReadLock(delegate
		{
			if (workerMerchant.TryGetValue(key, out var rVal))
			{
				return rVal;
			}
			_GlobalMerchant.PerformUsingWriteLock(delegate
			{
				rVal = func_0();
				workerMerchant.Add(key, rVal);
				return rVal;
			});
			return rVal;
		});
	}

	public void Add(TKey key, TValue value)
	{
		_GlobalMerchant.PerformUsingWriteLock(delegate
		{
			workerMerchant.Add(key, value);
		});
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		TKey key = item.Key;
		TValue value = item.Value;
		_GlobalMerchant.PerformUsingWriteLock(delegate
		{
			workerMerchant.Add(key, value);
		});
	}

	public bool AddIfNotExists(TKey key, TValue value)
	{
		bool rVal = false;
		_GlobalMerchant.PerformUsingWriteLock(delegate
		{
			if (!workerMerchant.ContainsKey(key))
			{
				workerMerchant.Add(key, value);
				rVal = true;
			}
		});
		return rVal;
	}

	public void AddIfNotExists(IEnumerable<TKey> ienumerable_0, TValue defaultValue)
	{
		_GlobalMerchant.PerformUsingWriteLock(delegate
		{
			foreach (TKey current in ienumerable_0)
			{
				if (!workerMerchant.ContainsKey(current))
				{
					workerMerchant.Add(current, defaultValue);
				}
			}
		});
	}

	public bool AddIfNotExistsElseUpdate(TKey key, TValue value)
	{
		bool rVal = false;
		_GlobalMerchant.PerformUsingWriteLock(delegate
		{
			if (workerMerchant.ContainsKey(key))
			{
				workerMerchant[key] = value;
			}
			else
			{
				workerMerchant.Add(key, value);
				rVal = true;
			}
		});
		return rVal;
	}

	public bool UpdateValueIfKeyExists(TKey key, TValue NewValue)
	{
		bool rVal = false;
		_GlobalMerchant.PerformUsingWriteLock(delegate
		{
			if (workerMerchant.ContainsKey(key))
			{
				workerMerchant[key] = NewValue;
				rVal = true;
			}
		});
		return rVal;
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return _GlobalMerchant.PerformUsingReadLock(() => workerMerchant.ContainsKey(item.Key) && workerMerchant.ContainsValue(item.Value));
	}

	public bool ContainsKey(TKey key)
	{
		return _GlobalMerchant.PerformUsingReadLock(() => workerMerchant.ContainsKey(key));
	}

	public bool ContainsKey_NoLock(TKey key)
	{
		return workerMerchant.ContainsKey(key);
	}

	public bool ContainsValue(TValue value)
	{
		return _GlobalMerchant.PerformUsingReadLock(() => workerMerchant.ContainsValue(value));
	}

	public bool Remove(TKey key)
	{
		return _GlobalMerchant.PerformUsingWriteLock(() => !workerMerchant.ContainsKey(key) || workerMerchant.Remove(key));
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		return _GlobalMerchant.PerformUsingWriteLock(delegate
		{
			if (workerMerchant.TryGetValue(item.Key, out var value))
			{
				if (EqualityComparer<TValue>.Default.Equals(value, item.Value))
				{
					return workerMerchant.Remove(item.Key);
				}
				return false;
			}
			return false;
		});
	}

	public bool Remove(Predicate<TKey> predicate_0, Predicate<TValue> predicate_1)
	{
		return _GlobalMerchant.PerformUsingWriteLock(delegate
		{
			if (workerMerchant.Keys.Count == 0)
			{
				return true;
			}
			List<TKey> list = new List<TKey>();
			foreach (TKey current in workerMerchant.Keys)
			{
				bool flag = false;
				if (predicate_0 != null)
				{
					flag = predicate_0(current);
				}
				if (!flag && predicate_1 != null && predicate_1(workerMerchant[current]))
				{
					flag = true;
				}
				if (flag)
				{
					list.Add(current);
				}
			}
			foreach (TKey current2 in list)
			{
				workerMerchant.Remove(current2);
			}
			return true;
		});
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		_GlobalMerchant.EnterReadLock();
		try
		{
			return workerMerchant.TryGetValue(key, out value);
		}
		finally
		{
			_GlobalMerchant.ExitReadLock();
		}
	}

	public bool TryGetValue_NoLock(TKey key, out TValue gparam_0)
	{
		return workerMerchant.TryGetValue(key, out gparam_0);
	}

	public void Clear()
	{
		_GlobalMerchant.PerformUsingWriteLock(delegate
		{
			workerMerchant.Clear();
		});
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		_GlobalMerchant.PerformUsingReadLock(delegate
		{
			workerMerchant.ToArray().CopyTo(array, arrayIndex);
		});
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		Dictionary<TKey, TValue> localDict = null;
		_GlobalMerchant.PerformUsingReadLock(() => localDict = new Dictionary<TKey, TValue>(workerMerchant));
		return ((IEnumerable<KeyValuePair<TKey, TValue>>)localDict).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		Dictionary<TKey, TValue> localDict = null;
		_GlobalMerchant.PerformUsingReadLock(() => localDict = new Dictionary<TKey, TValue>(workerMerchant));
		return localDict.GetEnumerator();
	}

	[CompilerGenerated]
	private Dictionary<TKey, TValue>.KeyCollection PatchCallback()
	{
		return workerMerchant.Keys;
	}

	[CompilerGenerated]
	private Dictionary<TKey, TValue>.ValueCollection SelectCallback()
	{
		return workerMerchant.Values;
	}

	[CompilerGenerated]
	private void CallCallback()
	{
		workerMerchant.Clear();
	}

	[CompilerGenerated]
	private int LogoutCallback()
	{
		return workerMerchant.Count;
	}

	internal static bool ViewCallback()
	{
		return _AccountMerchant == null;
	}

	[CompilerGenerated]
	private Dictionary<TKey, TValue>.KeyCollection LoginCallback()
	{
		return workerMerchant.Keys;
	}

	[CompilerGenerated]
	private Dictionary<TKey, TValue>.ValueCollection GetCallback()
	{
		return workerMerchant.Values;
	}

	[CompilerGenerated]
	private int WriteCallback()
	{
		return workerMerchant.Count;
	}

	[CompilerGenerated]
	private void NewCallback()
	{
		workerMerchant.Clear();
	}
}
