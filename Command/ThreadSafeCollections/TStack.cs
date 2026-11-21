using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TStack<T> : IEnumerable<T>, IEnumerable, ICollection
{
	[CompilerGenerated]
	private sealed class ComposerObjectListener
	{
		public Stack<T> LocalStack;

		public TStack<T> _003C_003E4__this;

		internal void PublishInterruptibleTemplate()
		{
			LocalStack = new Stack<T>(_003C_003E4__this.producerMerchant);
		}
	}

	[CompilerGenerated]
	private sealed class RoleExporter
	{
		public Stack<T> LocalStack;

		public TStack<T> _003C_003E4__this;

		internal void AwakeInterruptibleTemplate()
		{
			LocalStack = new Stack<T>(_003C_003E4__this.producerMerchant);
		}
	}

	[CompilerGenerated]
	private sealed class ProducerListenerManager
	{
		public TStack<T> _003C_003E4__this;

		public Array array;

		public int index;

		internal void QueryInterruptibleTemplate()
		{
			_003C_003E4__this.producerMerchant.ToArray().CopyTo(array, index);
		}
	}

	[CompilerGenerated]
	private sealed class PolicyMerchantService
	{
		public TStack<T> _003C_003E4__this;

		public T item;

		internal bool ResetInterruptibleTemplate()
		{
			return _003C_003E4__this.producerMerchant.Contains(item);
		}
	}

	[CompilerGenerated]
	private sealed class OrderDefinitionSpec
	{
		public TStack<T> _003C_003E4__this;

		public T item;

		internal void MapInterruptibleTemplate()
		{
			_003C_003E4__this.producerMerchant.Push(item);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public Stack<T> LocalStack;

		public TStack<T> _003C_003E4__this;

		internal void _003CGetEnumerator_003Eb__0()
		{
			LocalStack = new Stack<T>(_003C_003E4__this.producerMerchant);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public Stack<T> LocalStack;

		public TStack<T> _003C_003E4__this;

		internal void _003CSystem_002ECollections_002EIEnumerable_002EGetEnumerator_003Eb__0()
		{
			LocalStack = new Stack<T>(_003C_003E4__this.producerMerchant);
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__17 : IEnumerator<T>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		public TStack<T> _003C_003E4__this;

		private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

		private Stack<T>.Enumerator _003C_003Es__2;

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
		public _003CGetEnumerator_003Ed__17(int _003C_003E1__state)
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
			_003C_003E8__1 = null;
			_003C_003Es__2 = default(Stack<T>.Enumerator);
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
					_003C_003E8__1 = new _003C_003Ec__DisplayClass17_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.LocalStack = null;
					_003C_003E4__this.procMerchant.PerformUsingReadLock(delegate
					{
						_003C_003E8__1.LocalStack = new Stack<T>(_003C_003E8__1._003C_003E4__this.producerMerchant);
					});
					_003C_003Es__2 = _003C_003E8__1.LocalStack.GetEnumerator();
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
				_003C_003Es__2 = default(Stack<T>.Enumerator);
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
	private sealed class _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__18 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TStack<T> _003C_003E4__this;

		private _003C_003Ec__DisplayClass18_0 _003C_003E8__1;

		private Stack<T>.Enumerator _003C_003Es__2;

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
		public _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__18(int _003C_003E1__state)
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
			_003C_003E8__1 = null;
			_003C_003Es__2 = default(Stack<T>.Enumerator);
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
					_003C_003E8__1 = new _003C_003Ec__DisplayClass18_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.LocalStack = null;
					_003C_003E4__this.procMerchant.PerformUsingReadLock(delegate
					{
						_003C_003E8__1.LocalStack = new Stack<T>(_003C_003E8__1._003C_003E4__this.producerMerchant);
					});
					_003C_003Es__2 = _003C_003E8__1.LocalStack.GetEnumerator();
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
				_003C_003Es__2 = default(Stack<T>.Enumerator);
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

	private readonly Stack<T> producerMerchant;

	private readonly ReaderWriterLockSlim procMerchant = new ReaderWriterLockSlim();

	private readonly object structCallback = new object();

	internal static object m_MerchantCallback;

	public int Count => procMerchant.PerformUsingReadLock(() => producerMerchant.Count);

	public bool IsSynchronized => true;

	public object SyncRoot => structCallback;

	public TStack()
	{
		producerMerchant = new Stack<T>();
	}

	public TStack(IEnumerable<T> ienumerable_0)
	{
		producerMerchant = new Stack<T>(ienumerable_0);
	}

	[IteratorStateMachine(typeof(TStack<>._003CGetEnumerator_003Ed__17))]
	public IEnumerator<T> GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetEnumerator_003Ed__17(0)
		{
			_003C_003E4__this = this
		};
	}

	[IteratorStateMachine(typeof(TStack<>._003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__18))]
	IEnumerator IEnumerable.GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__18(0)
		{
			_003C_003E4__this = this
		};
	}

	public void CopyTo(Array array, int index)
	{
		procMerchant.PerformUsingReadLock(delegate
		{
			producerMerchant.ToArray().CopyTo(array, index);
		});
	}

	public void Clear()
	{
		procMerchant.PerformUsingWriteLock(delegate
		{
			producerMerchant.Clear();
		});
	}

	public bool Contains(T item)
	{
		return procMerchant.PerformUsingReadLock(() => producerMerchant.Contains(item));
	}

	public T Peek()
	{
		return procMerchant.PerformUsingReadLock(() => producerMerchant.Peek());
	}

	public T Pop()
	{
		return procMerchant.PerformUsingWriteLock(() => producerMerchant.Pop());
	}

	public void Push(T item)
	{
		procMerchant.PerformUsingWriteLock(delegate
		{
			producerMerchant.Push(item);
		});
	}

	public T[] ToArray()
	{
		return procMerchant.PerformUsingReadLock(() => producerMerchant.ToArray());
	}

	public void TrimExcess()
	{
		procMerchant.PerformUsingWriteLock(delegate
		{
			producerMerchant.TrimExcess();
		});
	}

	[CompilerGenerated]
	private int SearchCallback()
	{
		return producerMerchant.Count;
	}

	[CompilerGenerated]
	private void EnableCallback()
	{
		producerMerchant.Clear();
	}

	[CompilerGenerated]
	private T ChangeCallback()
	{
		return producerMerchant.Peek();
	}

	[CompilerGenerated]
	private T InitCallback()
	{
		return producerMerchant.Pop();
	}

	[CompilerGenerated]
	private T[] CheckCallback()
	{
		return producerMerchant.ToArray();
	}

	[CompilerGenerated]
	private void ConcatCallback()
	{
		producerMerchant.TrimExcess();
	}

	internal static bool InterruptCallback()
	{
		return m_MerchantCallback == null;
	}

	[CompilerGenerated]
	private int FindCallback()
	{
		return producerMerchant.Count;
	}

	[CompilerGenerated]
	private void SetCallback()
	{
		producerMerchant.Clear();
	}

	[CompilerGenerated]
	private T FillCallback()
	{
		return producerMerchant.Peek();
	}

	[CompilerGenerated]
	private T CalculateCallback()
	{
		return producerMerchant.Pop();
	}

	[CompilerGenerated]
	private T[] PopCallback()
	{
		return producerMerchant.ToArray();
	}

	[CompilerGenerated]
	private void InstantiateCallback()
	{
		producerMerchant.TrimExcess();
	}
}
