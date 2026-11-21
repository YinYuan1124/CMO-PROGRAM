using System;

namespace Nini.Config;

public interface IConfigSource
{
	ConfigCollection Configs { get; }

	bool AutoSave { get; set; }

	AliasText Alias { get; }

	event EventHandler Reloaded;

	event EventHandler Saved;

	void Merge(IConfigSource iconfigSource_0);

	void Save();

	void Reload();

	IConfig AddConfig(string string_0);

	string GetExpanded(IConfig iconfig_0, string string_0);

	void ExpandKeyValues();

	void ReplaceKeyValues();
}
