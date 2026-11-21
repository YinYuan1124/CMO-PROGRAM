using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class MultiKeyModule
{
	public enum FieldType : byte
	{
		None,
		Field,
		Property
	}

	public class MultiKeyedCollection<TValue, TKey1> : IEnumerable<TValue>, IEnumerable, IDisposable where TValue : new()
	{
		public struct ThreadSafeEnumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private MultiKeyedCollection<TValue, TKey1> refMapping;

			private Dictionary<TKey1, TValue>.Enumerator _ErrorMapping;

			private TValue codeMapping;

			private int connectionMapping;

			public TValue Current => codeMapping;

			object IEnumerator.Current => codeMapping;

			internal ThreadSafeEnumerator(MultiKeyedCollection<TValue, TKey1> multiKeyedCollection_0)
			{
				this = default(ThreadSafeEnumerator);
				refMapping = multiKeyedCollection_0;
				_ErrorMapping = multiKeyedCollection_0._Index1.GetEnumerator();
				codeMapping = default(TValue);
			}

			internal bool FindInterruptiblePolicy()
			{
				if (codeMapping == null)
				{
					refMapping._PrimaryMutex.WaitOne();
					if (_ErrorMapping.MoveNext())
					{
						codeMapping = _ErrorMapping.Current.Value;
						return true;
					}
					refMapping._PrimaryMutex.ReleaseMutex();
					return false;
				}
				if (_ErrorMapping.MoveNext())
				{
					codeMapping = _ErrorMapping.Current.Value;
					return true;
				}
				refMapping._PrimaryMutex.ReleaseMutex();
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				return FindInterruptiblePolicy();
			}

			public void Dispose()
			{
			}

			private void SetInterruptiblePolicy()
			{
				_ErrorMapping = refMapping._Index1.GetEnumerator();
				codeMapping = default(TValue);
				refMapping._PrimaryMutex.ReleaseMutex();
			}

			void IEnumerator.Reset()
			{
				SetInterruptiblePolicy();
			}
		}

		protected Mutex _PrimaryMutex;

		protected Dictionary<TKey1, TValue> _Index1;

		protected FieldInfo[] _Fields;

		protected PropertyInfo[] _Properties;

		protected FieldType[] _FieldTypes;

		protected string[] _FieldNames;

		private bool m_StrategyItem;

		private static object configurationItem;

		public int Count
		{
			get
			{
				_PrimaryMutex.WaitOne();
				int count = _Index1.Count;
				_PrimaryMutex.ReleaseMutex();
				return count;
			}
		}

		public TValue this[TKey1 primaryKey]
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (!_Index1.TryGetValue(primaryKey, out var value))
				{
					_PrimaryMutex.ReleaseMutex();
					throw new KeyNotFoundException("Primary key not found!");
				}
				_PrimaryMutex.ReleaseMutex();
				return value;
			}
		}

		public MultiKeyedCollection(string string_0)
		{
			_Index1 = new Dictionary<TKey1, TValue>();
			_Fields = new FieldInfo[1];
			_Properties = new PropertyInfo[1];
			_FieldTypes = new FieldType[1];
			_FieldNames = new string[1];
			m_StrategyItem = false;
			Type typeFromHandle = typeof(TValue);
			_Fields[0] = typeFromHandle.GetField(string_0);
			if ((object)_Fields[0] == null)
			{
				_Properties[0] = typeFromHandle.GetProperty(string_0);
				if ((object)_Properties[0] == null)
				{
					throw new ArgumentException("Field 1 name is not accessible in the value object");
				}
				if (!_Properties[0].CanRead)
				{
					throw new ArgumentException("Field 1 is a non-readable property");
				}
				_FieldTypes[0] = FieldType.Property;
			}
			else
			{
				_FieldTypes[0] = FieldType.Field;
			}
			_FieldNames[0] = string_0;
			_PrimaryMutex = new Mutex(initiallyOwned: true);
			_PrimaryMutex.ReleaseMutex();
		}

		private T PostInterruptibleQueue<T>(int int_0, TValue gparam_0)
		{
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				return (T)_Fields[int_0].GetValue(gparam_0);
			}
			return (T)_Properties[int_0].GetValue(gparam_0, null);
		}

		public void Add(TValue Value)
		{
			if (Value == null)
			{
				throw new ArgumentNullException("Cannot add a null reference!");
			}
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				if (num == 0)
				{
					TKey1 key = PostInterruptibleQueue<TKey1>(0, Value);
					if (_Index1.ContainsKey(key))
					{
						_PrimaryMutex.ReleaseMutex();
						throw new ArgumentException("Object with this primary key already exists!");
					}
					_Index1.Add(key, Value);
				}
				num++;
			}
			while (num <= 0);
			_PrimaryMutex.ReleaseMutex();
		}

		public void Clear()
		{
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				if (num == 0)
				{
					_Index1.Clear();
				}
				num++;
			}
			while (num <= 0);
			_PrimaryMutex.ReleaseMutex();
		}

		internal bool RunInterruptibleQueue(TKey1 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool StartInterruptibleQueue(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				TKey1 key = PostInterruptibleQueue<TKey1>(0, value);
				_PrimaryMutex.WaitOne();
				result = _Index1.ContainsKey(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool Remove(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.Remove(primaryKey);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool Remove(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				_PrimaryMutex.WaitOne();
				TKey1 key = PostInterruptibleQueue<TKey1>(0, value);
				result = _Index1.Remove(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool AssetInterruptibleQueue(TKey1 primaryKey, out TValue gparam_0)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.TryGetValue(primaryKey, out gparam_0);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		[SpecialName]
		public TValue GetItem(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			if (!_Index1.TryGetValue(primaryKey, out var value))
			{
				_PrimaryMutex.ReleaseMutex();
				throw new KeyNotFoundException("Primary key not found!");
			}
			_PrimaryMutex.ReleaseMutex();
			return value;
		}

		internal IEnumerator<TValue> PrintInterruptibleQueue()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return PrintInterruptibleQueue();
		}

		internal IEnumerator DefineInterruptibleQueue()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return DefineInterruptibleQueue();
		}

		protected virtual void Dispose(bool bool_0)
		{
			if (!m_StrategyItem && bool_0)
			{
				_PrimaryMutex.Close();
			}
			m_StrategyItem = true;
		}

		public void Dispose()
		{
			Dispose(bool_0: true);
			GC.SuppressFinalize(this);
		}

		internal static bool PublishInterruptibleQueue()
		{
			return configurationItem == null;
		}
	}

	public class MultiKeyedCollection<TValue, TKey1, TKey2> : IEnumerable<TValue>, IEnumerable, IDisposable where TValue : new()
	{
		public struct ThreadSafeEnumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private MultiKeyedCollection<TValue, TKey1, TKey2> contextMapping;

			private Dictionary<TKey1, TValue>.Enumerator statusMapping;

			private TValue m_ProccesorMapping;

			private int strategyMapping;

			public TValue Current => m_ProccesorMapping;

			object IEnumerator.Current => m_ProccesorMapping;

			internal ThreadSafeEnumerator(MultiKeyedCollection<TValue, TKey1, TKey2> multiKeyedCollection_0)
			{
				this = default(ThreadSafeEnumerator);
				contextMapping = multiKeyedCollection_0;
				statusMapping = multiKeyedCollection_0._Index1.GetEnumerator();
				m_ProccesorMapping = default(TValue);
			}

			internal bool PopInterruptiblePolicy()
			{
				if (m_ProccesorMapping == null)
				{
					contextMapping._PrimaryMutex.WaitOne();
					if (statusMapping.MoveNext())
					{
						m_ProccesorMapping = statusMapping.Current.Value;
						return true;
					}
					contextMapping._PrimaryMutex.ReleaseMutex();
					return false;
				}
				if (statusMapping.MoveNext())
				{
					m_ProccesorMapping = statusMapping.Current.Value;
					return true;
				}
				contextMapping._PrimaryMutex.ReleaseMutex();
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				return PopInterruptiblePolicy();
			}

			public void Dispose()
			{
			}

			private void InstantiateInterruptiblePolicy()
			{
				statusMapping = contextMapping._Index1.GetEnumerator();
				m_ProccesorMapping = default(TValue);
				contextMapping._PrimaryMutex.ReleaseMutex();
			}

			void IEnumerator.Reset()
			{
				InstantiateInterruptiblePolicy();
			}
		}

		protected Type _T;

		protected Mutex _PrimaryMutex;

		protected Dictionary<TKey1, TValue> _Index1;

		protected Dictionary<TKey2, Dictionary<TKey1, TValue>> _NIndex2;

		protected FieldInfo[] _Fields;

		protected PropertyInfo[] _Properties;

		protected FieldType[] _FieldTypes;

		protected bool[] _IsMutable;

		protected string[] _FieldNames;

		private bool m_TokenItem;

		private static object m_IndexerItem;

		public int Count
		{
			get
			{
				_PrimaryMutex.WaitOne();
				int count = _Index1.Count;
				_PrimaryMutex.ReleaseMutex();
				return count;
			}
		}

		public TValue this[TKey1 primaryKey]
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (!_Index1.TryGetValue(primaryKey, out var value))
				{
					_PrimaryMutex.ReleaseMutex();
					throw new KeyNotFoundException("Primary key not found!");
				}
				_PrimaryMutex.ReleaseMutex();
				return value;
			}
		}

		private void QueryInterruptibleQueue(int int_0, string string_0, bool bool_0)
		{
			_Fields[int_0] = _T.GetField(string_0);
			if ((object)_Fields[int_0] == null)
			{
				_Properties[int_0] = _T.GetProperty(string_0);
				if ((object)_Properties[int_0] == null)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " name is not accessible in the value object");
				}
				if (!_Properties[1].CanRead)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a non-readable property");
				}
				_FieldTypes[1] = FieldType.Property;
				if (bool_0 && !_Properties[int_0].CanWrite)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a readonly property and cannot be mutable");
				}
				_IsMutable[int_0] = bool_0;
			}
			else
			{
				_FieldTypes[int_0] = FieldType.Field;
				_IsMutable[int_0] = bool_0;
			}
			_FieldNames[int_0] = string_0;
			_IsMutable[int_0] = bool_0;
		}

		private void ResetInterruptibleQueue(string string_0)
		{
			_Fields[0] = _T.GetField(string_0);
			if ((object)_Fields[0] != null)
			{
				_FieldTypes[0] = FieldType.Field;
			}
			else
			{
				_Properties[0] = _T.GetProperty(string_0);
				if ((object)_Properties[0] == null)
				{
					throw new ArgumentException("Field 1 name is not accessible in the value object");
				}
				if (!_Properties[0].CanRead)
				{
					throw new ArgumentException("Field 1 is a non-readable property");
				}
				_FieldTypes[0] = FieldType.Property;
			}
			_FieldNames[0] = string_0;
		}

		public MultiKeyedCollection(string string_0, string string_1, bool bool_0 = false)
		{
			_T = typeof(TValue);
			_Index1 = new Dictionary<TKey1, TValue>();
			_NIndex2 = new Dictionary<TKey2, Dictionary<TKey1, TValue>>();
			_Fields = new FieldInfo[2];
			_Properties = new PropertyInfo[2];
			_FieldTypes = new FieldType[2];
			_IsMutable = new bool[2];
			_FieldNames = new string[2];
			m_TokenItem = false;
			ResetInterruptibleQueue(string_0);
			QueryInterruptibleQueue(1, string_1, bool_0);
			_PrimaryMutex = new Mutex(initiallyOwned: true);
			_PrimaryMutex.ReleaseMutex();
		}

		private T MapInterruptibleQueue<T>(int int_0, TValue gparam_0)
		{
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				return (T)_Fields[int_0].GetValue(gparam_0);
			}
			return (T)_Properties[int_0].GetValue(gparam_0, null);
		}

		private void SortInterruptibleQueue<T>(int int_0, TValue gparam_0, T gparam_1)
		{
			if (!_IsMutable[int_0])
			{
				if (_FieldTypes[int_0] == FieldType.Field)
				{
					_Fields[int_0].SetValue(gparam_0, gparam_1);
				}
				else
				{
					_Properties[int_0].SetValue(gparam_0, gparam_1, null);
				}
				return;
			}
			throw new ArgumentException("Cannot update an immutable field!");
		}

		public void UpdateKey2(TValue obj, TKey2 newKey2)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("Cannot update a null object!");
			}
			_PrimaryMutex.WaitOne();
			TKey1 key = MapInterruptibleQueue<TKey1>(0, obj);
			if (_Index1.ContainsKey(key))
			{
				TKey2 key2 = MapInterruptibleQueue<TKey2>(1, obj);
				Dictionary<TKey1, TValue> value = _NIndex2[key2];
				value.Remove(key);
				if (value.Count == 0)
				{
					_NIndex2.Remove(key2);
				}
				SortInterruptibleQueue(1, obj, newKey2);
				if (_NIndex2.TryGetValue(newKey2, out value))
				{
					value.Add(key, obj);
				}
				else
				{
					value = new Dictionary<TKey1, TValue>();
					value.Add(key, obj);
					_NIndex2.Add(newKey2, value);
				}
				_PrimaryMutex.ReleaseMutex();
				return;
			}
			_PrimaryMutex.ReleaseMutex();
			throw new ArgumentException("Object is not part of the collection!");
		}

		public void Add(TValue Value)
		{
			if (Value == null)
			{
				throw new ArgumentNullException("Cannot add a null reference!");
			}
			_PrimaryMutex.WaitOne();
			int num = 0;
			TKey1 key = default(TKey1);
			do
			{
				switch (num)
				{
				case 0:
					key = MapInterruptibleQueue<TKey1>(0, Value);
					if (_Index1.ContainsKey(key))
					{
						_Index1.Add(key, Value);
						break;
					}
					_PrimaryMutex.ReleaseMutex();
					throw new ArgumentException("Object with this primary key already exists!");
				case 1:
				{
					TKey2 key2 = MapInterruptibleQueue<TKey2>(1, Value);
					if (_NIndex2.TryGetValue(key2, out var value))
					{
						value.Add(key, Value);
						break;
					}
					value = new Dictionary<TKey1, TValue>();
					value.Add(key, Value);
					_NIndex2.Add(key2, value);
					break;
				}
				}
				num++;
			}
			while (num <= 1);
			_PrimaryMutex.ReleaseMutex();
		}

		public void Clear()
		{
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				switch (num)
				{
				case 0:
					_Index1.Clear();
					break;
				case 1:
					_NIndex2.Clear();
					break;
				}
				num++;
			}
			while (num <= 1);
			_PrimaryMutex.ReleaseMutex();
		}

		internal bool CalcInterruptibleQueue(TKey1 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool RateInterruptibleQueue(TKey2 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _NIndex2.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool FlushInterruptibleQueue(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				TKey1 key = MapInterruptibleQueue<TKey1>(0, value);
				_PrimaryMutex.WaitOne();
				result = _Index1.ContainsKey(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool Remove(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_Index1.TryGetValue(primaryKey, out var value))
			{
				TKey2 key = MapInterruptibleQueue<TKey2>(1, value);
				Dictionary<TKey1, TValue> dictionary = _NIndex2[key];
				dictionary.Remove(primaryKey);
				if (dictionary.Count == 0)
				{
					_NIndex2.Remove(key);
				}
				_Index1.Remove(primaryKey);
				result = true;
			}
			else
			{
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool Remove(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				_PrimaryMutex.WaitOne();
				TKey1 key = MapInterruptibleQueue<TKey1>(0, value);
				if (_Index1.TryGetValue(key, out value))
				{
					TKey2 key2 = MapInterruptibleQueue<TKey2>(1, value);
					Dictionary<TKey1, TValue> dictionary = _NIndex2[key2];
					dictionary.Remove(key);
					if (dictionary.Count == 0)
					{
						_NIndex2.Remove(key2);
					}
					_Index1.Remove(key);
					result = true;
				}
				else
				{
					result = false;
				}
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool ForgotInterruptibleQueue(TKey1 primaryKey, out TValue gparam_0)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.TryGetValue(primaryKey, out gparam_0);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool CollectInterruptibleQueue(TKey2 key2, out TValue[] gparam_0)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_NIndex2.TryGetValue(key2, out var value))
			{
				gparam_0 = new TValue[value.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value)
				{
					gparam_0[num] = item.Value;
					num++;
				}
				result = true;
			}
			else
			{
				gparam_0 = null;
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		[SpecialName]
		public TValue GetItem(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			if (!_Index1.TryGetValue(primaryKey, out var value))
			{
				_PrimaryMutex.ReleaseMutex();
				throw new KeyNotFoundException("Primary key not found!");
			}
			_PrimaryMutex.ReleaseMutex();
			return value;
		}

		[SpecialName]
		public TValue[] GetItemsByKey2(TKey2 key2)
		{
			_PrimaryMutex.WaitOne();
			if (_NIndex2.TryGetValue(key2, out var value))
			{
				TValue[] array = new TValue[value.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value)
				{
					array[num] = item.Value;
					num++;
				}
				_PrimaryMutex.ReleaseMutex();
				return array;
			}
			_PrimaryMutex.ReleaseMutex();
			throw new KeyNotFoundException("Key 2 not found!");
		}

		internal IEnumerator<TValue> OrderInterruptibleQueue()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return OrderInterruptibleQueue();
		}

		internal IEnumerator RegisterInterruptibleQueue()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return RegisterInterruptibleQueue();
		}

		protected virtual void Dispose(bool bool_0)
		{
			if (!m_TokenItem && bool_0)
			{
				_PrimaryMutex.Close();
			}
			m_TokenItem = true;
		}

		public void Dispose()
		{
			Dispose(bool_0: true);
			GC.SuppressFinalize(this);
		}

		internal static bool ManageInterruptibleQueue()
		{
			return m_IndexerItem == null;
		}
	}

	public class MultiKeyedCollection<TValue, TKey1, TKey2, TKey3> : IEnumerable<TValue>, IEnumerable, IDisposable where TValue : new()
	{
		public struct ThreadSafeEnumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private MultiKeyedCollection<TValue, TKey1, TKey2, TKey3> m_ConfigurationMapping;

			private Dictionary<TKey1, TValue>.Enumerator tokenMapping;

			private TValue indexerMapping;

			private int _ResolverMapping;

			public TValue Current => indexerMapping;

			object IEnumerator.Current => indexerMapping;

			internal ThreadSafeEnumerator(MultiKeyedCollection<TValue, TKey1, TKey2, TKey3> multiKeyedCollection_0)
			{
				this = default(ThreadSafeEnumerator);
				m_ConfigurationMapping = multiKeyedCollection_0;
				tokenMapping = multiKeyedCollection_0._Index1.GetEnumerator();
				indexerMapping = default(TValue);
			}

			internal bool ReadInterruptiblePolicy()
			{
				if (indexerMapping == null)
				{
					m_ConfigurationMapping._PrimaryMutex.WaitOne();
					if (tokenMapping.MoveNext())
					{
						indexerMapping = tokenMapping.Current.Value;
						return true;
					}
					m_ConfigurationMapping._PrimaryMutex.ReleaseMutex();
					return false;
				}
				if (tokenMapping.MoveNext())
				{
					indexerMapping = tokenMapping.Current.Value;
					return true;
				}
				m_ConfigurationMapping._PrimaryMutex.ReleaseMutex();
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				return ReadInterruptiblePolicy();
			}

			public void Dispose()
			{
			}

			private void DisableInterruptiblePolicy()
			{
				tokenMapping = m_ConfigurationMapping._Index1.GetEnumerator();
				indexerMapping = default(TValue);
				m_ConfigurationMapping._PrimaryMutex.ReleaseMutex();
			}

			void IEnumerator.Reset()
			{
				DisableInterruptiblePolicy();
			}
		}

		protected Type _T;

		protected Mutex _PrimaryMutex;

		protected Dictionary<TKey1, TValue> _Index1;

		protected Dictionary<TKey2, Dictionary<TKey1, TValue>> _NIndex2;

		protected Dictionary<TKey3, Dictionary<TKey1, TValue>> _NIndex3;

		protected FieldInfo[] _Fields;

		protected PropertyInfo[] _Properties;

		protected FieldType[] _FieldTypes;

		protected bool[] _IsMutable;

		protected string[] _FieldNames;

		private bool resolverItem;

		private static object _PublisherItem;

		public int Count
		{
			get
			{
				_PrimaryMutex.WaitOne();
				int count = _Index1.Count;
				_PrimaryMutex.ReleaseMutex();
				return count;
			}
		}

		public TValue this[TKey1 primaryKey]
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (!_Index1.TryGetValue(primaryKey, out var value))
				{
					_PrimaryMutex.ReleaseMutex();
					throw new KeyNotFoundException("Primary key not found!");
				}
				_PrimaryMutex.ReleaseMutex();
				return value;
			}
		}

		private void CountInterruptibleReg(int int_0, string string_0, bool bool_0)
		{
			_Fields[int_0] = _T.GetField(string_0);
			if ((object)_Fields[int_0] == null)
			{
				_Properties[int_0] = _T.GetProperty(string_0);
				if ((object)_Properties[int_0] == null)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " name is not accessible in the value object");
				}
				if (!_Properties[1].CanRead)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a non-readable property");
				}
				_FieldTypes[1] = FieldType.Property;
				if (bool_0 && !_Properties[int_0].CanWrite)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a readonly property and cannot be mutable");
				}
				_IsMutable[int_0] = bool_0;
			}
			else
			{
				_FieldTypes[int_0] = FieldType.Field;
				_IsMutable[int_0] = bool_0;
			}
			_FieldNames[int_0] = string_0;
			_IsMutable[int_0] = bool_0;
		}

		private void CustomizeInterruptibleReg(string string_0)
		{
			_Fields[0] = _T.GetField(string_0);
			if ((object)_Fields[0] != null)
			{
				_FieldTypes[0] = FieldType.Field;
			}
			else
			{
				_Properties[0] = _T.GetProperty(string_0);
				if ((object)_Properties[0] == null)
				{
					throw new ArgumentException("Field 1 name is not accessible in the value object");
				}
				if (!_Properties[0].CanRead)
				{
					throw new ArgumentException("Field 1 is a non-readable property");
				}
				_FieldTypes[0] = FieldType.Property;
			}
			_FieldNames[0] = string_0;
		}

		public MultiKeyedCollection(string string_0, string string_1, string string_2, bool bool_0 = false, bool bool_1 = false)
		{
			_T = typeof(TValue);
			_Index1 = new Dictionary<TKey1, TValue>();
			_NIndex2 = new Dictionary<TKey2, Dictionary<TKey1, TValue>>();
			_NIndex3 = new Dictionary<TKey3, Dictionary<TKey1, TValue>>();
			_Fields = new FieldInfo[3];
			_Properties = new PropertyInfo[3];
			_FieldTypes = new FieldType[3];
			_IsMutable = new bool[3];
			_FieldNames = new string[3];
			resolverItem = false;
			CustomizeInterruptibleReg(string_0);
			CountInterruptibleReg(1, string_1, bool_0);
			CountInterruptibleReg(2, string_2, bool_1);
			_PrimaryMutex = new Mutex(initiallyOwned: true);
			_PrimaryMutex.ReleaseMutex();
		}

		private T CloneInterruptibleReg<T>(int int_0, TValue gparam_0)
		{
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				return (T)_Fields[int_0].GetValue(gparam_0);
			}
			return (T)_Properties[int_0].GetValue(gparam_0, null);
		}

		private void ConnectInterruptibleReg<T>(int int_0, TValue gparam_0, T gparam_1)
		{
			if (!_IsMutable[int_0])
			{
				if (_FieldTypes[int_0] == FieldType.Field)
				{
					_Fields[int_0].SetValue(gparam_0, gparam_1);
				}
				else
				{
					_Properties[int_0].SetValue(gparam_0, gparam_1, null);
				}
				return;
			}
			throw new ArgumentException("Cannot update an immutable field!");
		}

		public void UpdateKey2(TValue obj, TKey2 newKey2)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("Cannot update a null object!");
			}
			_PrimaryMutex.WaitOne();
			TKey1 key = CloneInterruptibleReg<TKey1>(0, obj);
			if (_Index1.ContainsKey(key))
			{
				TKey2 key2 = CloneInterruptibleReg<TKey2>(1, obj);
				Dictionary<TKey1, TValue> value = _NIndex2[key2];
				value.Remove(key);
				if (value.Count == 0)
				{
					_NIndex2.Remove(key2);
				}
				ConnectInterruptibleReg(1, obj, newKey2);
				if (_NIndex2.TryGetValue(newKey2, out value))
				{
					value.Add(key, obj);
				}
				else
				{
					value = new Dictionary<TKey1, TValue>();
					value.Add(key, obj);
					_NIndex2.Add(newKey2, value);
				}
				_PrimaryMutex.ReleaseMutex();
				return;
			}
			_PrimaryMutex.ReleaseMutex();
			throw new ArgumentException("Object is not part of the collection!");
		}

		public void UpdateKey3(TValue obj, TKey3 newKey3)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("Cannot update a null object!");
			}
			_PrimaryMutex.WaitOne();
			TKey1 key = CloneInterruptibleReg<TKey1>(0, obj);
			if (_Index1.ContainsKey(key))
			{
				TKey3 key2 = CloneInterruptibleReg<TKey3>(2, obj);
				Dictionary<TKey1, TValue> value = _NIndex3[key2];
				value.Remove(key);
				if (value.Count == 0)
				{
					_NIndex3.Remove(key2);
				}
				ConnectInterruptibleReg(2, obj, newKey3);
				if (_NIndex3.TryGetValue(newKey3, out value))
				{
					value.Add(key, obj);
				}
				else
				{
					value = new Dictionary<TKey1, TValue>();
					value.Add(key, obj);
					_NIndex3.Add(newKey3, value);
				}
				_PrimaryMutex.ReleaseMutex();
				return;
			}
			_PrimaryMutex.ReleaseMutex();
			throw new ArgumentException("Object is not part of the collection!");
		}

		public void Add(TValue Value)
		{
			if (Value == null)
			{
				throw new ArgumentNullException("Cannot add a null reference!");
			}
			_PrimaryMutex.WaitOne();
			int num = 0;
			while (true)
			{
				TKey1 key = CloneInterruptibleReg<TKey1>(0, Value);
				if (_Index1.ContainsKey(key))
				{
					break;
				}
				_Index1.Add(key, Value);
				while (true)
				{
					num++;
					if (num <= 2)
					{
						switch (num)
						{
						case 1:
						{
							TKey2 key3 = CloneInterruptibleReg<TKey2>(1, Value);
							if (_NIndex2.TryGetValue(key3, out var value2))
							{
								value2.Add(key, Value);
								continue;
							}
							value2 = new Dictionary<TKey1, TValue>();
							value2.Add(key, Value);
							_NIndex2.Add(key3, value2);
							continue;
						}
						case 2:
						{
							TKey3 key2 = CloneInterruptibleReg<TKey3>(2, Value);
							if (_NIndex3.TryGetValue(key2, out var value))
							{
								value.Add(key, Value);
								continue;
							}
							value = new Dictionary<TKey1, TValue>();
							value.Add(key, Value);
							_NIndex3.Add(key2, value);
							continue;
						}
						default:
							continue;
						case 0:
							break;
						}
						break;
					}
					_PrimaryMutex.ReleaseMutex();
					return;
				}
			}
			_PrimaryMutex.ReleaseMutex();
			throw new ArgumentException("Object with this primary key already exists!");
		}

		public void Clear()
		{
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				switch (num)
				{
				case 0:
					_Index1.Clear();
					break;
				case 1:
					_NIndex2.Clear();
					break;
				}
				num++;
			}
			while (num <= 2);
			_PrimaryMutex.ReleaseMutex();
		}

		internal bool MoveInterruptibleReg(TKey1 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool DeleteInterruptibleReg(TKey2 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _NIndex2.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool AddInterruptibleReg(TKey3 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _NIndex3.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool DestroyInterruptibleReg(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				TKey1 key = CloneInterruptibleReg<TKey1>(0, value);
				_PrimaryMutex.WaitOne();
				result = _Index1.ContainsKey(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool Remove(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_Index1.TryGetValue(primaryKey, out var value))
			{
				TKey2 key = CloneInterruptibleReg<TKey2>(1, value);
				Dictionary<TKey1, TValue> dictionary = _NIndex2[key];
				dictionary.Remove(primaryKey);
				if (dictionary.Count == 0)
				{
					_NIndex2.Remove(key);
				}
				TKey3 key2 = CloneInterruptibleReg<TKey3>(2, value);
				Dictionary<TKey1, TValue> dictionary2 = _NIndex3[key2];
				dictionary2.Remove(primaryKey);
				if (dictionary2.Count == 0)
				{
					_NIndex3.Remove(key2);
				}
				_Index1.Remove(primaryKey);
				result = true;
			}
			else
			{
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool Remove(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				_PrimaryMutex.WaitOne();
				TKey1 key = CloneInterruptibleReg<TKey1>(0, value);
				if (_Index1.TryGetValue(key, out value))
				{
					TKey2 key2 = CloneInterruptibleReg<TKey2>(1, value);
					Dictionary<TKey1, TValue> dictionary = _NIndex2[key2];
					dictionary.Remove(key);
					if (dictionary.Count == 0)
					{
						_NIndex2.Remove(key2);
					}
					TKey3 key3 = CloneInterruptibleReg<TKey3>(2, value);
					Dictionary<TKey1, TValue> dictionary2 = _NIndex3[key3];
					dictionary2.Remove(key);
					if (dictionary2.Count == 0)
					{
						_NIndex3.Remove(key3);
					}
					_Index1.Remove(key);
					result = true;
				}
				else
				{
					result = false;
				}
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool ComputeInterruptibleReg(TKey1 primaryKey, out TValue gparam_0)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.TryGetValue(primaryKey, out gparam_0);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool PatchInterruptibleReg(TKey2 key2, out TValue[] gparam_0)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_NIndex2.TryGetValue(key2, out var value))
			{
				gparam_0 = new TValue[value.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value)
				{
					gparam_0[num] = item.Value;
					num++;
				}
				result = true;
			}
			else
			{
				gparam_0 = null;
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool SelectInterruptibleReg(TKey3 key3, out TValue[] gparam_0)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_NIndex3.TryGetValue(key3, out var value))
			{
				gparam_0 = new TValue[value.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value)
				{
					gparam_0[num] = item.Value;
					num++;
				}
				result = true;
			}
			else
			{
				gparam_0 = null;
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		[SpecialName]
		public TValue GetItem(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			if (!_Index1.TryGetValue(primaryKey, out var value))
			{
				_PrimaryMutex.ReleaseMutex();
				throw new KeyNotFoundException("Primary key not found!");
			}
			_PrimaryMutex.ReleaseMutex();
			return value;
		}

		[SpecialName]
		public TValue[] GetItemsByKey2(TKey2 key2)
		{
			_PrimaryMutex.WaitOne();
			if (_NIndex2.TryGetValue(key2, out var value))
			{
				TValue[] array = new TValue[value.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value)
				{
					array[num] = item.Value;
					num++;
				}
				_PrimaryMutex.ReleaseMutex();
				return array;
			}
			_PrimaryMutex.ReleaseMutex();
			throw new KeyNotFoundException("Key 2 not found!");
		}

		[SpecialName]
		public TValue[] GetItemsByKey3(TKey3 key3)
		{
			_PrimaryMutex.WaitOne();
			if (_NIndex3.TryGetValue(key3, out var value))
			{
				TValue[] array = new TValue[value.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value)
				{
					array[num] = item.Value;
					num++;
				}
				_PrimaryMutex.ReleaseMutex();
				return array;
			}
			_PrimaryMutex.ReleaseMutex();
			throw new KeyNotFoundException("Key 3 not found!");
		}

		internal IEnumerator<TValue> CallInterruptibleReg()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return CallInterruptibleReg();
		}

		internal IEnumerator LogoutInterruptibleReg()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return LogoutInterruptibleReg();
		}

		protected virtual void Dispose(bool bool_0)
		{
			if (!resolverItem && bool_0)
			{
				_PrimaryMutex.Close();
			}
			resolverItem = true;
		}

		public void Dispose()
		{
			Dispose(bool_0: true);
			GC.SuppressFinalize(this);
		}

		internal static bool ViewInterruptibleReg()
		{
			return _PublisherItem == null;
		}
	}
}
