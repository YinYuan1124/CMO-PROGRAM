using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Nini.Config;

public abstract class ConfigSourceBase : IConfigSource
{
	private ArrayList propertyDecorator = new ArrayList();

	private ConfigCollection _ImporterDecorator;

	private bool repositoryDecorator;

	private AliasText _BridgeDecorator = new AliasText();

	[CompilerGenerated]
	private EventHandler m_InvocationDecorator;

	[CompilerGenerated]
	private EventHandler _ClassDecorator;

	public ConfigCollection Configs => _ImporterDecorator;

	public bool AutoSave
	{
		get
		{
			return repositoryDecorator;
		}
		set
		{
			repositoryDecorator = value;
		}
	}

	public AliasText Alias => _BridgeDecorator;

	public event EventHandler Reloaded
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_InvocationDecorator;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_InvocationDecorator, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_InvocationDecorator;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_InvocationDecorator, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler Saved
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _ClassDecorator;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _ClassDecorator, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _ClassDecorator;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _ClassDecorator, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ConfigSourceBase()
	{
		_ImporterDecorator = new ConfigCollection(this);
	}

	public void Merge(IConfigSource iconfigSource_0)
	{
		if (!propertyDecorator.Contains(iconfigSource_0))
		{
			propertyDecorator.Add(iconfigSource_0);
		}
		foreach (IConfig config in iconfigSource_0.Configs)
		{
			Configs.Add(config);
		}
	}

	public virtual IConfig AddConfig(string string_0)
	{
		return _ImporterDecorator.Add(string_0);
	}

	public string GetExpanded(IConfig iconfig_0, string string_0)
	{
		return ResolveDecorator(iconfig_0, string_0, bool_0: false);
	}

	public virtual void Save()
	{
		OnSaved(new EventArgs());
	}

	public virtual void Reload()
	{
		OnReloaded(new EventArgs());
	}

	public void ExpandKeyValues()
	{
		string[] array = null;
		foreach (IConfig item in _ImporterDecorator)
		{
			array = item.GetKeys();
			for (int i = 0; i < array.Length; i++)
			{
				ResolveDecorator(item, array[i], bool_0: true);
			}
		}
	}

	public void ReplaceKeyValues()
	{
		ExpandKeyValues();
	}

	protected void OnReloaded(EventArgs eventArgs_0)
	{
		if (m_InvocationDecorator != null)
		{
			m_InvocationDecorator(this, eventArgs_0);
		}
	}

	protected void OnSaved(EventArgs eventArgs_0)
	{
		if (_ClassDecorator != null)
		{
			_ClassDecorator(this, eventArgs_0);
		}
	}

	private string ResolveDecorator(IConfig iconfig_0, string string_0, bool bool_0)
	{
		string text = iconfig_0.Get(string_0);
		if (text == null)
		{
			throw new ArgumentException("[" + string_0 + "] not found in [" + iconfig_0.Name + "]");
		}
		while (true)
		{
			int num = text.IndexOf("${", 0);
			if (num == -1)
			{
				break;
			}
			int num2 = text.IndexOf("}", num + 2);
			if (num2 == -1)
			{
				break;
			}
			string text2 = text.Substring(num + 2, num2 - (num + 2));
			if (!(text2 == string_0))
			{
				string newValue = PostDecorator(iconfig_0, text2);
				text = text.Replace("${" + text2 + "}", newValue);
				continue;
			}
			throw new ArgumentException("Key cannot have a expand value of itself: " + string_0);
		}
		if (bool_0)
		{
			iconfig_0.Set(string_0, text);
		}
		return text;
	}

	private string PostDecorator(IConfig iconfig_0, string string_0)
	{
		string text = null;
		string[] array = string_0.Split('|');
		if (array.Length <= 1)
		{
			text = iconfig_0.Get(string_0);
			if (text == null)
			{
				throw new ArgumentException("Key not found: " + string_0);
			}
		}
		else
		{
			text = (Configs[array[0]] ?? throw new ArgumentException("Expand config not found: " + array[0])).Get(array[1]);
			if (text == null)
			{
				throw new ArgumentException("Expand key not found: " + array[1]);
			}
		}
		return text;
	}
}
