using System;
using System.IO;
using Nini.Ini;

namespace Nini.Config;

public class IniConfigSource : ConfigSourceBase
{
	private IniDocument m_WriterDecorator;

	private string _SpecificationDecorator;

	private bool watcherDecorator = true;

	public bool CaseSensitive
	{
		get
		{
			return watcherDecorator;
		}
		set
		{
			watcherDecorator = value;
		}
	}

	public string SavePath => _SpecificationDecorator;

	public IniConfigSource()
	{
		m_WriterDecorator = new IniDocument();
	}

	public IniConfigSource(string string_0)
	{
		Load(string_0);
	}

	public IniConfigSource(TextReader textReader_0)
	{
		Load(textReader_0);
	}

	public IniConfigSource(IniDocument iniDocument_0)
	{
		Load(iniDocument_0);
	}

	public IniConfigSource(Stream stream_0)
	{
		Load(stream_0);
	}

	public void Load(string string_0)
	{
		Load(new StreamReader(string_0));
		_SpecificationDecorator = string_0;
	}

	public void Load(TextReader textReader_0)
	{
		Load(new IniDocument(textReader_0));
	}

	public void Load(IniDocument iniDocument_0)
	{
		base.Configs.Clear();
		Merge(this);
		m_WriterDecorator = iniDocument_0;
		ConnectProcess();
	}

	public void Load(Stream stream_0)
	{
		Load(new StreamReader(stream_0));
	}

	public override void Save()
	{
		if (!DestroyProcess())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		CountProcess();
		m_WriterDecorator.Save(_SpecificationDecorator);
		base.Save();
	}

	public void Save(string string_0)
	{
		_SpecificationDecorator = string_0;
		Save();
	}

	public void Save(TextWriter textWriter_0)
	{
		CountProcess();
		m_WriterDecorator.Save(textWriter_0);
		_SpecificationDecorator = null;
		OnSaved(new EventArgs());
	}

	public void Save(Stream stream_0)
	{
		CountProcess();
		m_WriterDecorator.Save(stream_0);
		_SpecificationDecorator = null;
		OnSaved(new EventArgs());
	}

	public override void Reload()
	{
		if (_SpecificationDecorator == null)
		{
			throw new ArgumentException("Error reloading: You must have the loaded the source from a file");
		}
		m_WriterDecorator = new IniDocument(_SpecificationDecorator);
		MoveProcess();
		base.Reload();
	}

	public override string ToString()
	{
		CountProcess();
		StringWriter stringWriter = new StringWriter();
		m_WriterDecorator.Save(stringWriter);
		return stringWriter.ToString();
	}

	private void CountProcess()
	{
		CustomizeProcess();
		foreach (IConfig config in base.Configs)
		{
			string[] keys = config.GetKeys();
			if (m_WriterDecorator.Sections[config.Name] == null)
			{
				IniSection iniSection_ = new IniSection(config.Name);
				m_WriterDecorator.Sections.Add(iniSection_);
			}
			CloneProcess(config.Name);
			for (int i = 0; i < keys.Length; i++)
			{
				m_WriterDecorator.Sections[config.Name].Set(keys[i], config.Get(keys[i]));
			}
		}
	}

	private void CustomizeProcess()
	{
		IniSection iniSection = null;
		for (int i = 0; i < m_WriterDecorator.Sections.Count; i++)
		{
			iniSection = m_WriterDecorator.Sections[i];
			if (base.Configs[iniSection.Name] == null)
			{
				m_WriterDecorator.Sections.Remove(iniSection.Name);
			}
		}
	}

	private void CloneProcess(string string_0)
	{
		IniSection iniSection = m_WriterDecorator.Sections[string_0];
		if (iniSection == null)
		{
			return;
		}
		string[] keys = iniSection.GetKeys();
		string[] array = keys;
		foreach (string string_ in array)
		{
			if (base.Configs[string_0].Get(string_) == null)
			{
				iniSection.Remove(string_);
			}
		}
	}

	private void ConnectProcess()
	{
		IniConfig iniConfig = null;
		IniSection iniSection = null;
		IniItem iniItem = null;
		for (int i = 0; i < m_WriterDecorator.Sections.Count; i++)
		{
			iniSection = m_WriterDecorator.Sections[i];
			iniConfig = new IniConfig(iniSection.Name, this);
			for (int j = 0; j < iniSection.ItemCount; j++)
			{
				iniItem = iniSection.GetItem(j);
				if (iniItem.Type == IniType.Key)
				{
					iniConfig.Add(iniItem.Name, iniItem.Value);
				}
			}
			base.Configs.Add(iniConfig);
		}
	}

	private void MoveProcess()
	{
		DeleteProcess();
		IniSection iniSection = null;
		for (int i = 0; i < m_WriterDecorator.Sections.Count; i++)
		{
			iniSection = m_WriterDecorator.Sections[i];
			IConfig config = base.Configs[iniSection.Name];
			if (config == null)
			{
				config = new ConfigBase(iniSection.Name, this);
				base.Configs.Add(config);
			}
			AddProcess(config);
		}
	}

	private void DeleteProcess()
	{
		IConfig config = null;
		for (int num = base.Configs.Count - 1; num > -1; num--)
		{
			config = base.Configs[num];
			if (m_WriterDecorator.Sections[config.Name] == null)
			{
				base.Configs.Remove(config);
			}
		}
	}

	private void AddProcess(IConfig iconfig_0)
	{
		IniSection iniSection = m_WriterDecorator.Sections[iconfig_0.Name];
		string[] keys = iconfig_0.GetKeys();
		string[] array = keys;
		foreach (string string_ in array)
		{
			if (!iniSection.Contains(string_))
			{
				iconfig_0.Remove(string_);
			}
		}
		string[] keys2 = iniSection.GetKeys();
		for (int i = 0; i < keys2.Length; i++)
		{
			string string_2 = keys2[i];
			iconfig_0.Set(string_2, iniSection.GetItem(i).Value);
		}
	}

	private bool DestroyProcess()
	{
		return _SpecificationDecorator != null;
	}
}
