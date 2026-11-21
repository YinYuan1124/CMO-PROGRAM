using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Command.Watchers;
using OpenDis.Pages;
using OpenDis.Resolver;

namespace Gameloop.Vdf.Linq;

public sealed class VObject : VToken, IDictionary<string, VToken>, ICollection<KeyValuePair<string, VToken>>, IEnumerable<KeyValuePair<string, VToken>>, IEnumerable
{
	private class ReaderPrototype : ManagerPage<VObject>
	{
		public override bool TryGetMember(VObject instance, GetMemberBinder getMemberBinder_0, out object object_0)
		{
			object_0 = instance[getMemberBinder_0.Name];
			return true;
		}

		public override bool TrySetMember(VObject instance, SetMemberBinder setMemberBinder_0, object object_0)
		{
			VToken vToken = object_0 as VToken;
			if (vToken == null)
			{
				vToken = new VValue(object_0);
			}
			instance[setMemberBinder_0.Name] = vToken;
			return true;
		}

		public override IEnumerable<string> GetDynamicMemberNames(VObject instance)
		{
			return from p in instance.Children()
				select p.string_0;
		}
	}

	[CompilerGenerated]
	private sealed class CollectionMerchantPage
	{
		public string key;

		internal bool MapInterruptibleMapping(VProperty x)
		{
			return x.string_0 == key;
		}
	}

	[CompilerGenerated]
	private sealed class PropertyPrototype
	{
		public string key;

		internal bool SortInterruptibleMapping(VProperty x)
		{
			return x.string_0 == key;
		}
	}

	[CompilerGenerated]
	private sealed class ImporterPrototype
	{
		public string key;

		internal bool CalcInterruptibleMapping(VProperty x)
		{
			return x.string_0 == key;
		}
	}

	[CompilerGenerated]
	private sealed class RepositoryPrototype
	{
		public string key;

		internal bool RateInterruptibleMapping(VProperty x)
		{
			return x.string_0 == key;
		}
	}

	[CompilerGenerated]
	private sealed class BridgePrototype
	{
		public string key;

		internal bool FlushInterruptibleMapping(VProperty x)
		{
			return x.string_0 == key;
		}
	}

	[CompilerGenerated]
	private sealed class InvocationPrototype
	{
		public KeyValuePair<string, VToken> item;

		internal bool ForgotInterruptibleMapping(VProperty x)
		{
			return x.string_0 == item.Key;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__33 : IEnumerator<KeyValuePair<string, VToken>>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private KeyValuePair<string, VToken> _003C_003E2__current;

		public VObject _003C_003E4__this;

		private List<VProperty>.Enumerator _003C_003Es__1;

		private VProperty _003Citem_003E5__2;

		KeyValuePair<string, VToken> IEnumerator<KeyValuePair<string, VToken>>.Current
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
		public _003CGetEnumerator_003Ed__33(int _003C_003E1__state)
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
			_003C_003Es__1 = default(List<VProperty>.Enumerator);
			_003Citem_003E5__2 = null;
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
					_003C_003Es__1 = _003C_003E4__this._CodeProcess.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					_003Citem_003E5__2 = null;
					break;
				}
				if (_003C_003Es__1.MoveNext())
				{
					_003Citem_003E5__2 = _003C_003Es__1.Current;
					_003C_003E2__current = new KeyValuePair<string, VToken>(_003Citem_003E5__2.string_0, _003Citem_003E5__2.Value);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003Es__1 = default(List<VProperty>.Enumerator);
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
			((IDisposable)_003C_003Es__1).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private readonly List<VProperty> _CodeProcess;

	public int Count => _CodeProcess.Count;

	public override VToken this[object object_0]
	{
		get
		{
			PrinterProcessResolver.RunThread(object_0, "key");
			if (!(object_0 is string key))
			{
				throw new ArgumentException("Accessed JObject values with invalid key value: " + RefProcess.RestartThread(object_0) + ". Object property name expected.");
			}
			return this[key];
		}
		set
		{
			PrinterProcessResolver.RunThread(object_0, "key");
			if (!(object_0 is string key))
			{
				throw new ArgumentException("Set JObject values with invalid key value: " + RefProcess.RestartThread(object_0) + ". Object property name expected.");
			}
			this[key] = value;
		}
	}

	public VToken this[string key]
	{
		get
		{
			if (TryGetValue(key, out var value))
			{
				return value;
			}
			return null;
		}
		set
		{
			VProperty vProperty = _CodeProcess.FirstOrDefault((VProperty x) => x.string_0 == key);
			if (vProperty == null)
			{
				Add(key, value);
			}
			else
			{
				vProperty.Value = value;
			}
		}
	}

	ICollection<string> IDictionary<string, VToken>.Keys => _CodeProcess.Select((VProperty x) => x.string_0).ToList();

	ICollection<VToken> IDictionary<string, VToken>.Values
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	bool ICollection<KeyValuePair<string, VToken>>.IsReadOnly => false;

	public VObject()
	{
		_CodeProcess = new List<VProperty>();
	}

	public override IEnumerable<VProperty> Children()
	{
		return _CodeProcess;
	}

	public void Add(string key, VToken value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		_CodeProcess.Add(new VProperty(key, value));
	}

	public void Add(VProperty vproperty_0)
	{
		if (vproperty_0 == null)
		{
			throw new ArgumentNullException("property");
		}
		if (vproperty_0.Value == null)
		{
			throw new ArgumentNullException("Value");
		}
		_CodeProcess.Add(vproperty_0);
	}

	public void Clear()
	{
		_CodeProcess.Clear();
	}

	public bool ContainsKey(string key)
	{
		return _CodeProcess.Exists((VProperty x) => x.string_0 == key);
	}

	public void CopyTo(VProperty[] vproperty_0, int int_0)
	{
		_CodeProcess.CopyTo(vproperty_0, int_0);
	}

	public bool Remove(string key)
	{
		return _CodeProcess.RemoveAll((VProperty x) => x.string_0 == key) != 0;
	}

	public bool TryGetValue(string key, out VToken value)
	{
		value = _CodeProcess.FirstOrDefault((VProperty x) => x.string_0 == key)?.Value;
		return value != null;
	}

	public void RemoveAt(string string_0)
	{
		_CodeProcess.RemoveAll((VProperty x) => x.string_0 == string_0);
	}

	public override void WriteTo(VdfWriter vdfWriter_0)
	{
		vdfWriter_0.WriteObjectStart();
		foreach (VProperty item in _CodeProcess)
		{
			item.WriteTo(vdfWriter_0);
		}
		vdfWriter_0.WriteObjectEnd();
	}

	[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__33))]
	public IEnumerator<KeyValuePair<string, VToken>> GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetEnumerator_003Ed__33(0)
		{
			_003C_003E4__this = this
		};
	}

	void ICollection<KeyValuePair<string, VToken>>.Add(KeyValuePair<string, VToken> item)
	{
		Add(new VProperty(item.Key, item.Value));
	}

	void ICollection<KeyValuePair<string, VToken>>.Clear()
	{
		_CodeProcess.Clear();
	}

	bool ICollection<KeyValuePair<string, VToken>>.Contains(KeyValuePair<string, VToken> item)
	{
		VProperty vProperty = _CodeProcess.FirstOrDefault((VProperty x) => x.string_0 == item.Key);
		if (vProperty == null)
		{
			return false;
		}
		return vProperty.Value == item.Value;
	}

	void ICollection<KeyValuePair<string, VToken>>.CopyTo(KeyValuePair<string, VToken>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex is less than 0.");
		}
		if (arrayIndex >= array.Length && arrayIndex != 0)
		{
			throw new ArgumentException("arrayIndex is equal to or greater than the length of array.");
		}
		if (Count <= array.Length - arrayIndex)
		{
			for (int i = 0; i < _CodeProcess.Count; i++)
			{
				array[arrayIndex + i] = new KeyValuePair<string, VToken>(_CodeProcess[i].string_0, _CodeProcess[i].Value);
			}
			return;
		}
		throw new ArgumentException("The number of elements in the source JObject is greater than the available space from arrayIndex to the end of the destination array.");
	}

	bool ICollection<KeyValuePair<string, VToken>>.Remove(KeyValuePair<string, VToken> item)
	{
		if (((ICollection<KeyValuePair<string, VToken>>)this).Contains(item))
		{
			((IDictionary<string, VToken>)this).Remove(item.Key);
			return true;
		}
		return false;
	}

	protected override DynamicMetaObject GetMetaObject(Expression expression_0)
	{
		return new WatcherRuleWatcher<VObject>(expression_0, this, new ReaderPrototype());
	}
}
