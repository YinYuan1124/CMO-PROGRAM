using System;

namespace Nini.Config;

public class ConfigEventArgs : EventArgs
{
	private IConfig _FacadeDecorator;

	public IConfig Config => _FacadeDecorator;

	public ConfigEventArgs(IConfig iconfig_0)
	{
		_FacadeDecorator = iconfig_0;
	}
}
