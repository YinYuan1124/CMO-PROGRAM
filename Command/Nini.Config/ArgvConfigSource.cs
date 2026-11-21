using System;
using Nini.Util;

namespace Nini.Config;

public class ArgvConfigSource : ConfigSourceBase
{
	private ArgvParser _DispatcherDecorator;

	private string[] m_ListenerDecorator;

	public ArgvConfigSource(string[] string_0)
	{
		_DispatcherDecorator = new ArgvParser(string_0);
		m_ListenerDecorator = string_0;
	}

	public override void Save()
	{
		throw new ArgumentException("Source is read only");
	}

	public override void Reload()
	{
		throw new ArgumentException("Source cannot be reloaded");
	}

	public void AddSwitch(string string_0, string string_1)
	{
		AddSwitch(string_0, string_1, null);
	}

	public void AddSwitch(string string_0, string string_1, string string_2)
	{
		IConfig config = StopDecorator(string_0);
		if (string_2 != null && (string_2.Length < 1 || string_2.Length > 2))
		{
			throw new ArgumentException("Short name may only be 1 or 2 characters");
		}
		if (_DispatcherDecorator[string_1] == null)
		{
			if (string_2 != null && _DispatcherDecorator[string_2] != null)
			{
				config.Set(string_1, _DispatcherDecorator[string_2]);
			}
		}
		else
		{
			config.Set(string_1, _DispatcherDecorator[string_1]);
		}
	}

	public string[] GetArguments()
	{
		string[] array = new string[m_ListenerDecorator.Length];
		Array.Copy(m_ListenerDecorator, 0, array, 0, m_ListenerDecorator.Length);
		return array;
	}

	private IConfig StopDecorator(string string_0)
	{
		IConfig config = null;
		if (base.Configs[string_0] == null)
		{
			config = new ConfigBase(string_0, this);
			base.Configs.Add(config);
		}
		else
		{
			config = base.Configs[string_0];
		}
		return config;
	}
}
