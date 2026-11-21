using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TQueue<T> : IEnumerable, ICollection
{
	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__13 : IEnumerator<T>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		public TQueue<T> _003C_003E4__this;

		private Queue<T> _003Cqueue_003E5__1;

		private Queue<T>.Enumerator _003C_003Es__2;

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
		public _003CGetEnumerator_003Ed__13(int _003C_003E1__state)
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
			_003Cqueue_003E5__1 = null;
			_003C_003Es__2 = default(Queue<T>.Enumerator);
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
					_003C_003E4__this.mapperMerchant.EnterReadLock();
					try
					{
						_003Cqueue_003E5__1 = new Queue<T>(_003C_003E4__this._HelperMerchant);
					}
					finally
					{
						_003C_003E4__this.mapperMerchant.ExitReadLock();
					}
					_003C_003Es__2 = _003Cqueue_003E5__1.GetEnumerator();
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
				_003C_003Es__2 = default(Queue<T>.Enumerator);
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
	private sealed class _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__14 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TQueue<T> _003C_003E4__this;

		private Queue<T> _003Cqueue_003E5__1;

		private Queue<T>.Enumerator _003C_003Es__2;

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
		public _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__14(int _003C_003E1__state)
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
			_003Cqueue_003E5__1 = null;
			_003C_003Es__2 = default(Queue<T>.Enumerator);
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
					_003C_003E4__this.mapperMerchant.EnterReadLock();
					try
					{
						_003Cqueue_003E5__1 = new Queue<T>(_003C_003E4__this._HelperMerchant);
					}
					finally
					{
						_003C_003E4__this.mapperMerchant.ExitReadLock();
					}
					_003C_003Es__2 = _003Cqueue_003E5__1.GetEnumerator();
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
				_003C_003Es__2 = default(Queue<T>.Enumerator);
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

	private readonly Queue<T> _HelperMerchant;

	private readonly ReaderWriterLockSlim mapperMerchant = new ReaderWriterLockSlim();

	private readonly object managerMerchant = new object();

	internal static object m_GetterMerchant;

	public int Count
	{
		get
		{
			mapperMerchant.EnterReadLock();
			try
			{
				return _HelperMerchant.Count;
			}
			finally
			{
				mapperMerchant.ExitReadLock();
			}
		}
	}

	public bool IsSynchronized => true;

	public object SyncRoot => managerMerchant;

	public TQueue()
	{
		_HelperMerchant = new Queue<T>();
	}

	public TQueue(int int_0)
	{
		_HelperMerchant = new Queue<T>(int_0);
	}

	public TQueue(IEnumerable<T> ienumerable_0)
	{
		_HelperMerchant = new Queue<T>(ienumerable_0);
	}

	[IteratorStateMachine(typeof(TQueue<>._003CGetEnumerator_003Ed__13))]
	public IEnumerator<T> GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetEnumerator_003Ed__13(0)
		{
			_003C_003E4__this = this
		};
	}

	[IteratorStateMachine(typeof(TQueue<>._003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__14))]
	IEnumerator IEnumerable.GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__14(0)
		{
			_003C_003E4__this = this
		};
	}

	public void CopyTo(Array array, int index)
	{
		mapperMerchant.EnterReadLock();
		try
		{
			_HelperMerchant.ToArray().CopyTo(array, index);
		}
		finally
		{
			mapperMerchant.ExitReadLock();
		}
	}

	public void CopyTo(T[] gparam_0, int int_0)
	{
		mapperMerchant.EnterReadLock();
		try
		{
			_HelperMerchant.CopyTo(gparam_0, int_0);
		}
		finally
		{
			mapperMerchant.ExitReadLock();
		}
	}

	public void Enqueue(T item)
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			_HelperMerchant.Enqueue(item);
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public int EnqueueAndCount(T item)
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			_HelperMerchant.Enqueue(item);
			return _HelperMerchant.Count;
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public T Dequeue()
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			return _HelperMerchant.Dequeue();
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public void EnqueueAll(IEnumerable<T> ienumerable_0)
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			foreach (T item in ienumerable_0)
			{
				_HelperMerchant.Enqueue(item);
			}
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public void EnqueueAll(TList<T> tlist_0)
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			foreach (T item in tlist_0)
			{
				_HelperMerchant.Enqueue(item);
			}
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public TList<T> DequeueAll()
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			TList<T> tList = new TList<T>();
			while (_HelperMerchant.Count > 0)
			{
				tList.Add(_HelperMerchant.Dequeue());
			}
			return tList;
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public List<T> DequeueAllList()
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			List<T> list = new List<T>();
			while (_HelperMerchant.Count > 0)
			{
				list.Add(_HelperMerchant.Dequeue());
			}
			return list;
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public void Clear()
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			_HelperMerchant.Clear();
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	public bool Contains(T item)
	{
		mapperMerchant.EnterReadLock();
		try
		{
			return _HelperMerchant.Contains(item);
		}
		finally
		{
			mapperMerchant.ExitReadLock();
		}
	}

	public T Peek()
	{
		mapperMerchant.EnterReadLock();
		try
		{
			return _HelperMerchant.Peek();
		}
		finally
		{
			mapperMerchant.ExitReadLock();
		}
	}

	public T[] ToArray()
	{
		mapperMerchant.EnterReadLock();
		try
		{
			return _HelperMerchant.ToArray();
		}
		finally
		{
			mapperMerchant.ExitReadLock();
		}
	}

	public void TrimExcess()
	{
		mapperMerchant.EnterWriteLock();
		try
		{
			_HelperMerchant.TrimExcess();
		}
		finally
		{
			mapperMerchant.ExitWriteLock();
		}
	}

	internal static bool ExcludeCallback()
	{
		return m_GetterMerchant == null;
	}
}
