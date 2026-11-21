using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Nini.Util;

namespace Nini.Config;

public class ConfigBase : IConfig
{
	private string configDecorator;

	private IConfigSource registryDecorator;

	private AliasText definitionDecorator;

	private IFormatProvider _ValDecorator = NumberFormatInfo.CurrentInfo;

	protected OrderedList keys = new OrderedList();

	[CompilerGenerated]
	private ConfigKeyEventHandler m_WrapperDecorator;

	[CompilerGenerated]
	private ConfigKeyEventHandler m_ObserverDecorator;

	public string Name
	{
		get
		{
			return configDecorator;
		}
		set
		{
			if (configDecorator != value)
			{
				CancelDecorator(value);
			}
		}
	}

	public IConfigSource ConfigSource => registryDecorator;

	public AliasText Alias => definitionDecorator;

	public event ConfigKeyEventHandler KeySet
	{
		[CompilerGenerated]
		add
		{
			ConfigKeyEventHandler configKeyEventHandler = m_WrapperDecorator;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Combine(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref m_WrapperDecorator, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigKeyEventHandler configKeyEventHandler = m_WrapperDecorator;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Remove(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref m_WrapperDecorator, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
	}

	public event ConfigKeyEventHandler KeyRemoved
	{
		[CompilerGenerated]
		add
		{
			ConfigKeyEventHandler configKeyEventHandler = m_ObserverDecorator;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Combine(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref m_ObserverDecorator, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigKeyEventHandler configKeyEventHandler = m_ObserverDecorator;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Remove(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref m_ObserverDecorator, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
	}

	public ConfigBase(string string_0, IConfigSource iconfigSource_0)
	{
		configDecorator = string_0;
		registryDecorator = iconfigSource_0;
		definitionDecorator = new AliasText();
	}

	public bool Contains(string string_0)
	{
		return Get(string_0) != null;
	}

	public virtual string Get(string string_0)
	{
		string result = null;
		if (keys.Contains(string_0))
		{
			result = keys[string_0].ToString();
		}
		return result;
	}

	public string Get(string string_0, string string_1)
	{
		string text = Get(string_0);
		if (text == null)
		{
			return string_1;
		}
		return text;
	}

	public string GetExpanded(string string_0)
	{
		return ConfigSource.GetExpanded(this, string_0);
	}

	public string GetString(string string_0)
	{
		return Get(string_0);
	}

	public string GetString(string string_0, string string_1)
	{
		return Get(string_0, string_1);
	}

	public int GetInt(string string_0)
	{
		return Convert.ToInt32(Get(string_0) ?? throw new ArgumentException("Value not found: " + string_0), _ValDecorator);
	}

	public int GetInt(string string_0, bool bool_0)
	{
		if (bool_0)
		{
			string text = Get(string_0);
			if (text == null)
			{
				throw new ArgumentException("Value not found: " + string_0);
			}
			return VerifyDecorator(string_0, text);
		}
		return GetInt(string_0);
	}

	public int GetInt(string string_0, int int_0)
	{
		string text = Get(string_0);
		if (text == null)
		{
			return int_0;
		}
		return Convert.ToInt32(text, _ValDecorator);
	}

	public int GetInt(string string_0, int int_0, bool bool_0)
	{
		if (bool_0)
		{
			string text = Get(string_0);
			if (text == null)
			{
				return int_0;
			}
			return VerifyDecorator(string_0, text);
		}
		return GetInt(string_0, int_0);
	}

	public long GetLong(string string_0)
	{
		return Convert.ToInt64(Get(string_0) ?? throw new ArgumentException("Value not found: " + string_0), _ValDecorator);
	}

	public long GetLong(string string_0, long long_0)
	{
		string text = Get(string_0);
		if (text == null)
		{
			return long_0;
		}
		return Convert.ToInt64(text, _ValDecorator);
	}

	public bool GetBoolean(string string_0)
	{
		string text = Get(string_0);
		if (text == null)
		{
			throw new ArgumentException("Value not found: " + string_0);
		}
		return ListDecorator(text);
	}

	public bool GetBoolean(string string_0, bool bool_0)
	{
		string text = Get(string_0);
		if (text == null)
		{
			return bool_0;
		}
		return ListDecorator(text);
	}

	public float GetFloat(string string_0)
	{
		return Convert.ToSingle(Get(string_0) ?? throw new ArgumentException("Value not found: " + string_0), _ValDecorator);
	}

	public float GetFloat(string string_0, float float_0)
	{
		string text = Get(string_0);
		if (text == null)
		{
			return float_0;
		}
		return Convert.ToSingle(text, _ValDecorator);
	}

	public double GetDouble(string string_0)
	{
		return Convert.ToDouble(Get(string_0) ?? throw new ArgumentException("Value not found: " + string_0), _ValDecorator);
	}

	public double GetDouble(string string_0, double double_0)
	{
		string text = Get(string_0);
		if (text == null)
		{
			return double_0;
		}
		return Convert.ToDouble(text, _ValDecorator);
	}

	public string[] GetKeys()
	{
		string[] array = new string[keys.Keys.Count];
		keys.Keys.CopyTo(array, 0);
		return array;
	}

	public string[] GetValues()
	{
		string[] array = new string[keys.Values.Count];
		keys.Values.CopyTo(array, 0);
		return array;
	}

	public void Add(string string_0, string string_1)
	{
		keys.Add(string_0, string_1);
	}

	public virtual void Set(string string_0, object object_0)
	{
		if (object_0 == null)
		{
			throw new ArgumentNullException("Value cannot be null");
		}
		if (Get(string_0) == null)
		{
			Add(string_0, object_0.ToString());
		}
		else
		{
			keys[string_0] = object_0.ToString();
		}
		if (ConfigSource.AutoSave)
		{
			ConfigSource.Save();
		}
		OnKeySet(new ConfigKeyEventArgs(string_0, object_0.ToString()));
	}

	public virtual void Remove(string string_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("Key cannot be null");
		}
		if (Get(string_0) != null)
		{
			string string_ = null;
			if (m_WrapperDecorator != null)
			{
				string_ = Get(string_0);
			}
			keys.Remove(string_0);
			OnKeyRemoved(new ConfigKeyEventArgs(string_0, string_));
		}
	}

	protected void OnKeySet(ConfigKeyEventArgs configKeyEventArgs_0)
	{
		if (m_WrapperDecorator != null)
		{
			m_WrapperDecorator(this, configKeyEventArgs_0);
		}
	}

	protected void OnKeyRemoved(ConfigKeyEventArgs configKeyEventArgs_0)
	{
		if (m_ObserverDecorator != null)
		{
			m_ObserverDecorator(this, configKeyEventArgs_0);
		}
	}

	private void CancelDecorator(string string_0)
	{
		ConfigSource.Configs.Remove(this);
		configDecorator = string_0;
		ConfigSource.Configs.Add(this);
	}

	private int VerifyDecorator(string string_0, string string_1)
	{
		if (definitionDecorator.ContainsInt(string_0, string_1))
		{
			return definitionDecorator.GetInt(string_0, string_1);
		}
		return ConfigSource.Alias.GetInt(string_0, string_1);
	}

	private bool ListDecorator(string string_0)
	{
		if (definitionDecorator.ContainsBoolean(string_0))
		{
			return definitionDecorator.GetBoolean(string_0);
		}
		if (!ConfigSource.Alias.ContainsBoolean(string_0))
		{
			throw new ArgumentException("Alias value not found: " + string_0 + ". Add it to the Alias property.");
		}
		return ConfigSource.Alias.GetBoolean(string_0);
	}
}
