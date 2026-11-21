using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TList<T> : IEnumerable<T>, IEnumerable, IList<T>, ICollection<T>
{
	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__20 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TList<T> _003C_003E4__this;

		private List<T> _003Clist_003E5__1;

		private List<T>.Enumerator _003C_003Es__2;

		private T _003Citem_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetEnumerator_003Ed__20(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003Clist_003E5__1 = null;
			_003C_003Es__2 = default(List<T>.Enumerator);
			_003Citem_003E5__3 = default(T);
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this._AuthenticationMerchant.EnterReadLock();
					try
					{
						_003Clist_003E5__1 = new List<T>(_003C_003E4__this.stateMerchant);
					}
					finally
					{
						_003C_003E4__this._AuthenticationMerchant.ExitReadLock();
					}
					_003C_003Es__2 = _003Clist_003E5__1.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					_003Citem_003E5__3 = default(T);
					break;
				}
				if (_003C_003Es__2.MoveNext())
				{
					_003Citem_003E5__3 = _003C_003Es__2.Current;
					_003C_003E2__current = _003Citem_003E5__3;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003Es__2 = default(List<T>.Enumerator);
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003Es__2).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CT_003E_002DGetEnumerator_003Ed__21 : IEnumerator<T>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		public TList<T> _003C_003E4__this;

		private List<T> _003Clist_003E5__1;

		private List<T>.Enumerator _003C_003Es__2;

		private T _003Citem_003E5__3;

		T IEnumerator<T>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CT_003E_002DGetEnumerator_003Ed__21(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003Clist_003E5__1 = null;
			_003C_003Es__2 = default(List<T>.Enumerator);
			_003Citem_003E5__3 = default(T);
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this._AuthenticationMerchant.EnterReadLock();
					try
					{
						_003Clist_003E5__1 = new List<T>(_003C_003E4__this.stateMerchant);
					}
					finally
					{
						_003C_003E4__this._AuthenticationMerchant.ExitReadLock();
					}
					_003C_003Es__2 = _003Clist_003E5__1.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					_003Citem_003E5__3 = default(T);
					break;
				}
				if (_003C_003Es__2.MoveNext())
				{
					_003Citem_003E5__3 = _003C_003Es__2.Current;
					_003C_003E2__current = _003Citem_003E5__3;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003Es__2 = default(List<T>.Enumerator);
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003Es__2).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private readonly List<T> stateMerchant;

	private readonly ReaderWriterLockSlim _AuthenticationMerchant = new ReaderWriterLockSlim();

	private int _ParamsMerchant;

	private static object infoMerchant;

	public int Capacity
	{
		get
		{
			_AuthenticationMerchant.EnterReadLock();
			try
			{
				return stateMerchant.Capacity;
			}
			finally
			{
				_AuthenticationMerchant.ExitReadLock();
			}
		}
		set
		{
			_AuthenticationMerchant.EnterWriteLock();
			try
			{
				stateMerchant.Capacity = value;
			}
			finally
			{
				_AuthenticationMerchant.ExitWriteLock();
			}
		}
	}

	public int Count
	{
		get
		{
			_AuthenticationMerchant.EnterReadLock();
			try
			{
				return stateMerchant.Count;
			}
			finally
			{
				_AuthenticationMerchant.ExitReadLock();
			}
		}
	}

	public bool IsReadOnly => false;

	public T this[int index]
	{
		get
		{
			_AuthenticationMerchant.EnterReadLock();
			try
			{
				return stateMerchant[index];
			}
			finally
			{
				_AuthenticationMerchant.ExitReadLock();
			}
		}
		set
		{
			_AuthenticationMerchant.EnterWriteLock();
			try
			{
				stateMerchant[index] = value;
			}
			finally
			{
				_AuthenticationMerchant.ExitWriteLock();
			}
		}
	}

	[SpecialName]
	private bool method_0()
	{
		return Thread.VolatileRead(ref _ParamsMerchant) == 1;
	}

	[SpecialName]
	private void method_1(bool bool_0)
	{
		Thread.VolatileWrite(ref _ParamsMerchant, bool_0 ? 1 : 0);
	}

	public TList()
	{
		stateMerchant = new List<T>();
	}

	public TList(int int_0)
	{
		stateMerchant = new List<T>(int_0);
	}

	public TList(IEnumerable<T> ienumerable_0)
	{
		stateMerchant = new List<T>(ienumerable_0);
	}

	public static implicit operator TList<T>(List<T> list_0)
	{
		return new TList<T>(list_0);
	}

	[IteratorStateMachine(typeof(TList<>._003CGetEnumerator_003Ed__20))]
	public IEnumerator GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetEnumerator_003Ed__20(0)
		{
			_003C_003E4__this = this
		};
	}

	[IteratorStateMachine(typeof(TList<>._003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CT_003E_002DGetEnumerator_003Ed__21))]
	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CT_003E_002DGetEnumerator_003Ed__21(0)
		{
			_003C_003E4__this = this
		};
	}

	public void Dispose()
	{
		PushCallback(bool_0: true);
		GC.SuppressFinalize(this);
	}

	private void PushCallback(bool bool_0)
	{
		if (!method_0())
		{
			method_1(bool_0: true);
		}
	}

	~TList()
	{
		PushCallback(bool_0: false);
	}

	public void Add(T item)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.Add(item);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void AddRange(IEnumerable<T> ienumerable_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.AddRange(ienumerable_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public bool AddIfNotExist(T item)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			if (stateMerchant.Contains(item))
			{
				return false;
			}
			stateMerchant.Add(item);
			return true;
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public ReadOnlyCollection<T> AsReadOnly()
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.AsReadOnly();
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int BinarySearch(T item)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.BinarySearch(item);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int BinarySearch(T item, IComparer<T> icomparer_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.BinarySearch(item, icomparer_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int BinarySearch(int int_0, int int_1, T item, IComparer<T> icomparer_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.BinarySearch(int_0, int_1, item, icomparer_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public void Clear()
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			stateMerchant.Clear();
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public bool Contains(T item)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.Contains(item);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.ConvertAll(converter_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			stateMerchant.CopyTo(array, arrayIndex);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public bool Exists(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.Exists(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public T Find(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.Find(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public List<T> FindAll(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindAll(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int FindIndex(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindIndex(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int FindIndex(int int_0, Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindIndex(int_0, predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int FindIndex(int int_0, int int_1, Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindIndex(int_0, int_1, predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public T FindLast(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindLast(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int FindLastIndex(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindLastIndex(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int FindLastIndex(int int_0, Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindLastIndex(int_0, predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int FindLastIndex(int int_0, int int_1, Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.FindLastIndex(int_0, int_1, predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public void ForEach(Action<T> action_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.ForEach(action_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public List<T> GetRange(int int_0, int int_1)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.GetRange(int_0, int_1);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int IndexOf(T item)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.IndexOf(item);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int IndexOf(T item, int int_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.IndexOf(item, int_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int IndexOf(T item, int int_0, int int_1)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.IndexOf(item, int_0, int_1);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public void Insert(int index, T item)
	{
		_AuthenticationMerchant.ExitWriteLock();
		try
		{
			stateMerchant.Insert(index, item);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void InsertRange(int int_0, IEnumerable<T> ienumerable_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.InsertRange(int_0, ienumerable_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public int LastIndexOf(T item)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.LastIndexOf(item);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int LastIndexOf(T item, int int_0)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.LastIndexOf(item, int_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public int LastIndexOf(T item, int int_0, int int_1)
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.LastIndexOf(item, int_0, int_1);
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public bool Remove(T item)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			return stateMerchant.Remove(item);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public int RemoveAll(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			return stateMerchant.RemoveAll(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void RemoveAt(int index)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.RemoveAt(index);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void RemoveRange(int int_0, int int_1)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.RemoveRange(int_0, int_1);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void Reverse()
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.Reverse();
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void Reverse(int int_0, int int_1)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.Reverse(int_0, int_1);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void Sort()
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.Sort();
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void Sort(Comparison<T> comparison_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.Sort(comparison_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void Sort(IComparer<T> icomparer_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.Sort(icomparer_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public void Sort(int int_0, int int_1, IComparer<T> icomparer_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.Sort(int_0, int_1, icomparer_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public T[] ToArray()
	{
		_AuthenticationMerchant.EnterReadLock();
		try
		{
			return stateMerchant.ToArray();
		}
		finally
		{
			_AuthenticationMerchant.ExitReadLock();
		}
	}

	public void TrimExcess()
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			stateMerchant.TrimExcess();
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	public bool TrueForAll(Predicate<T> predicate_0)
	{
		_AuthenticationMerchant.EnterWriteLock();
		try
		{
			return stateMerchant.TrueForAll(predicate_0);
		}
		finally
		{
			_AuthenticationMerchant.ExitWriteLock();
		}
	}

	internal static bool InvokeCallback()
	{
		return infoMerchant == null;
	}
}
