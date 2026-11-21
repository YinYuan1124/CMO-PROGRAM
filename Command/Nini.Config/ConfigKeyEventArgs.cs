using System;

namespace Nini.Config;

public class ConfigKeyEventArgs : EventArgs
{
	private string _ProxyDecorator;

	private string readerDecorator;

	public string KeyName => _ProxyDecorator;

	public string KeyValue => readerDecorator;

	public ConfigKeyEventArgs(string string_0, string string_1)
	{
		_ProxyDecorator = string_0;
		readerDecorator = string_1;
	}
}
