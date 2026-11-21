using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Nini.Config;

public class ConfigCollection : IEnumerable, IList, ICollection
{
	private ArrayList _IssuerDecorator = new ArrayList();

	private ConfigSourceBase m_ClientDecorator;

	[CompilerGenerated]
	private ConfigEventHandler dicDecorator;

	[CompilerGenerated]
	private ConfigEventHandler _ConsumerDecorator;

	public int Count => _IssuerDecorator.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public IConfig this[int int_0] => (IConfig)_IssuerDecorator[int_0];

	object IList.this[int index]
	{
		get
		{
			return _IssuerDecorator[index];
		}
		set
		{
		}
	}

	public IConfig this[string string_0]
	{
		get
		{
			IConfig result = null;
			foreach (IConfig item in _IssuerDecorator)
			{
				if (item.Name == string_0)
				{
					return item;
				}
			}
			return result;
		}
	}

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public event ConfigEventHandler ConfigAdded
	{
		[CompilerGenerated]
		add
		{
			ConfigEventHandler configEventHandler = dicDecorator;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Combine(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref dicDecorator, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigEventHandler configEventHandler = dicDecorator;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Remove(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref dicDecorator, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
	}

	public event ConfigEventHandler ConfigRemoved
	{
		[CompilerGenerated]
		add
		{
			ConfigEventHandler configEventHandler = _ConsumerDecorator;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Combine(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref _ConsumerDecorator, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigEventHandler configEventHandler = _ConsumerDecorator;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Remove(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref _ConsumerDecorator, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
	}

	public ConfigCollection(ConfigSourceBase configSourceBase_0)
	{
		m_ClientDecorator = configSourceBase_0;
	}

	public void Add(IConfig iconfig_0)
	{
		if (_IssuerDecorator.Contains(iconfig_0))
		{
			throw new ArgumentException("IConfig already exists");
		}
		IConfig config = this[iconfig_0.Name];
		if (config == null)
		{
			_IssuerDecorator.Add(iconfig_0);
			OnConfigAdded(new ConfigEventArgs(iconfig_0));
			return;
		}
		string[] keys = iconfig_0.GetKeys();
		for (int i = 0; i < keys.Length; i++)
		{
			config.Set(keys[i], iconfig_0.Get(keys[i]));
		}
	}

	int IList.Add(object value)
	{
		if (!(value is IConfig config))
		{
			throw new Exception("Must be an IConfig");
		}
		Add(config);
		return IndexOf(config);
	}

	public IConfig Add(string string_0)
	{
		ConfigBase configBase = null;
		if (this[string_0] != null)
		{
			throw new ArgumentException("An IConfig of that name already exists");
		}
		configBase = new ConfigBase(string_0, m_ClientDecorator);
		_IssuerDecorator.Add(configBase);
		OnConfigAdded(new ConfigEventArgs(configBase));
		return configBase;
	}

	public void Remove(IConfig iconfig_0)
	{
		_IssuerDecorator.Remove(iconfig_0);
		OnConfigRemoved(new ConfigEventArgs(iconfig_0));
	}

	public void Remove(object value)
	{
		_IssuerDecorator.Remove(value);
		OnConfigRemoved(new ConfigEventArgs((IConfig)value));
	}

	public void RemoveAt(int index)
	{
		IConfig iconfig_ = (IConfig)_IssuerDecorator[index];
		_IssuerDecorator.RemoveAt(index);
		OnConfigRemoved(new ConfigEventArgs(iconfig_));
	}

	public void Clear()
	{
		_IssuerDecorator.Clear();
	}

	public IEnumerator GetEnumerator()
	{
		return _IssuerDecorator.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		_IssuerDecorator.CopyTo(array, index);
	}

	public void CopyTo(IConfig[] iconfig_0, int int_0)
	{
		((ICollection)_IssuerDecorator).CopyTo((Array)iconfig_0, int_0);
	}

	public bool Contains(object value)
	{
		return _IssuerDecorator.Contains(value);
	}

	public int IndexOf(object value)
	{
		return _IssuerDecorator.IndexOf(value);
	}

	public void Insert(int index, object value)
	{
		_IssuerDecorator.Insert(index, value);
	}

	protected void OnConfigAdded(ConfigEventArgs configEventArgs_0)
	{
		if (dicDecorator != null)
		{
			dicDecorator(this, configEventArgs_0);
		}
	}

	protected void OnConfigRemoved(ConfigEventArgs configEventArgs_0)
	{
		if (_ConsumerDecorator != null)
		{
			_ConsumerDecorator(this, configEventArgs_0);
		}
	}
}
