using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CSMaterial;

public sealed class FastList<T> : IEnumerable<T>, IEnumerable
{
	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__14 : IEnumerator<T>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		public FastList<T> _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CGetEnumerator_003Ed__14(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < _003C_003E4__this._DicDispatcher)
			{
				_003C_003E2__current = _003C_003E4__this._ClientDispatcher[_003Ci_003E5__1];
				_003C_003E1__state = 1;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static readonly FastList<T> Empty;

	private T[] _ClientDispatcher;

	private int _DicDispatcher;

	private int m_ConsumerDispatcher;

	internal static object facadeDispatcher;

	public int Count => _DicDispatcher;

	public T this[int int_0]
	{
		get
		{
			return _ClientDispatcher[int_0];
		}
		internal set
		{
			_ClientDispatcher[int_0] = value;
		}
	}

	public FastList()
		: this(4)
	{
	}

	public FastList(int int_0)
	{
		m_ConsumerDispatcher = int_0;
		_ClientDispatcher = new T[int_0];
	}

	public FastList(FastList<T> fastList_0)
	{
		m_ConsumerDispatcher = fastList_0.m_ConsumerDispatcher;
		_ClientDispatcher = (T[])fastList_0._ClientDispatcher.Clone();
		_DicDispatcher = fastList_0._DicDispatcher;
	}

	public void Normalize()
	{
		_DicDispatcher = _ClientDispatcher.Length;
	}

	[IteratorStateMachine(typeof(FastList<>._003CGetEnumerator_003Ed__14))]
	public IEnumerator<T> GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetEnumerator_003Ed__14(0)
		{
			_003C_003E4__this = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public FastList<T> Clone()
	{
		return new FastList<T>
		{
			_ClientDispatcher = (T[])_ClientDispatcher.Clone(),
			_DicDispatcher = _DicDispatcher,
			m_ConsumerDispatcher = m_ConsumerDispatcher
		};
	}

	public bool Contains(T val)
	{
		for (int i = 0; i < _DicDispatcher; i++)
		{
			if (_ClientDispatcher[i].Equals(val))
			{
				return true;
			}
		}
		return false;
	}

	public T[] ToArray()
	{
		T[] array = new T[_DicDispatcher];
		Array.Copy(_ClientDispatcher, array, _DicDispatcher);
		return array;
	}

	private T[] EnableDefinition()
	{
		return _ClientDispatcher;
	}

	public void Clear()
	{
		_DicDispatcher = 0;
		_ClientDispatcher = new T[m_ConsumerDispatcher];
	}

	public void AddRange(IEnumerable<T> ienumerable_0)
	{
		foreach (T item in ienumerable_0)
		{
			Add(item);
		}
	}

	public void AddRange(FastList<T> fastList_0, int int_0, int int_1)
	{
		for (int i = int_0; i < int_1; i++)
		{
			Add(fastList_0[i]);
		}
	}

	public void AddRange(T[] gparam_0, int int_0, int int_1)
	{
		for (int i = int_0; i < int_1; i++)
		{
			Add(gparam_0[i]);
		}
	}

	public void Add(T val)
	{
		if (_DicDispatcher == _ClientDispatcher.Length)
		{
			T[] array = new T[(_ClientDispatcher.Length == 0) ? 4 : (_ClientDispatcher.Length * 2)];
			Array.Copy(_ClientDispatcher, 0, array, 0, _DicDispatcher);
			_ClientDispatcher = array;
		}
		_ClientDispatcher[_DicDispatcher++] = val;
	}

	public bool Remove(T val)
	{
		int num = Array.IndexOf(_ClientDispatcher, val);
		if (num < 0)
		{
			return false;
		}
		_DicDispatcher--;
		if (num < _DicDispatcher)
		{
			Array.Copy(_ClientDispatcher, num + 1, _ClientDispatcher, num, _DicDispatcher - num);
		}
		_ClientDispatcher[_DicDispatcher] = default(T);
		return true;
	}

	public void Trim()
	{
		if (_ClientDispatcher.Length > _DicDispatcher)
		{
			T[] array = new T[_DicDispatcher];
			Array.Copy(_ClientDispatcher, array, _DicDispatcher);
			_ClientDispatcher = array;
		}
	}

	static FastList()
	{
		Empty = new FastList<T>();
	}

	internal static bool ChangeDefinition()
	{
		return facadeDispatcher == null;
	}
}
