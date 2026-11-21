using System;
using System.IO;
using System.Xml;

namespace Nini.Config;

public class XmlConfigSource : ConfigSourceBase
{
	private XmlDocument _DescriptorDecorator;

	private string m_PoolDecorator;

	public string SavePath => m_PoolDecorator;

	public XmlConfigSource()
	{
		_DescriptorDecorator = new XmlDocument();
		_DescriptorDecorator.LoadXml("<Nini/>");
		GetProcess(_DescriptorDecorator);
	}

	public XmlConfigSource(string string_0)
	{
		Load(string_0);
	}

	public XmlConfigSource(XmlReader xmlReader_0)
	{
		Load(xmlReader_0);
	}

	public void Load(string string_0)
	{
		m_PoolDecorator = string_0;
		_DescriptorDecorator = new XmlDocument();
		_DescriptorDecorator.Load(string_0);
		GetProcess(_DescriptorDecorator);
	}

	public void Load(XmlReader xmlReader_0)
	{
		_DescriptorDecorator = new XmlDocument();
		_DescriptorDecorator.Load(xmlReader_0);
		GetProcess(_DescriptorDecorator);
	}

	public override void Save()
	{
		if (!SearchProcess())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		ViewProcess();
		_DescriptorDecorator.Save(m_PoolDecorator);
		base.Save();
	}

	public void Save(string string_0)
	{
		m_PoolDecorator = string_0;
		Save();
	}

	public void Save(TextWriter textWriter_0)
	{
		ViewProcess();
		_DescriptorDecorator.Save(textWriter_0);
		m_PoolDecorator = null;
		OnSaved(new EventArgs());
	}

	public void Save(Stream stream_0)
	{
		ViewProcess();
		_DescriptorDecorator.Save(stream_0);
		m_PoolDecorator = null;
		OnSaved(new EventArgs());
	}

	public override void Reload()
	{
		if (m_PoolDecorator == null)
		{
			throw new ArgumentException("Error reloading: You must have the loaded the source from a file");
		}
		_DescriptorDecorator = new XmlDocument();
		_DescriptorDecorator.Load(m_PoolDecorator);
		EnableProcess();
		base.Reload();
	}

	public override string ToString()
	{
		ViewProcess();
		StringWriter stringWriter = new StringWriter();
		_DescriptorDecorator.Save(stringWriter);
		return stringWriter.ToString();
	}

	private void ViewProcess()
	{
		ValidateProcess();
		foreach (IConfig config in base.Configs)
		{
			string[] keys = config.GetKeys();
			XmlNode xmlNode = ExcludeProcess(config.Name);
			if (xmlNode == null)
			{
				xmlNode = SetupProcess(config.Name);
				_DescriptorDecorator.DocumentElement.AppendChild(xmlNode);
			}
			LoginProcess(config.Name);
			for (int i = 0; i < keys.Length; i++)
			{
				PushProcess(xmlNode, keys[i], config.Get(keys[i]));
			}
		}
	}

	private void ValidateProcess()
	{
		XmlAttribute xmlAttribute = null;
		foreach (XmlNode childNode in _DescriptorDecorator.DocumentElement.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Section")
			{
				xmlAttribute = childNode.Attributes["Name"];
				if (xmlAttribute == null)
				{
					throw new ArgumentException("Section name attribute not found");
				}
				if (base.Configs[xmlAttribute.Value] == null)
				{
					_DescriptorDecorator.DocumentElement.RemoveChild(childNode);
				}
			}
		}
	}

	private void LoginProcess(string string_0)
	{
		XmlNode xmlNode = ExcludeProcess(string_0);
		XmlAttribute xmlAttribute = null;
		if (xmlNode == null)
		{
			return;
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Key")
			{
				xmlAttribute = childNode.Attributes["Name"];
				if (xmlAttribute == null)
				{
					throw new ArgumentException("Name attribute not found in key");
				}
				if (base.Configs[string_0].Get(xmlAttribute.Value) == null)
				{
					xmlNode.RemoveChild(childNode);
				}
			}
		}
	}

	private void GetProcess(XmlDocument xmlDocument_0)
	{
		base.Configs.Clear();
		Merge(this);
		if (!(xmlDocument_0.DocumentElement.Name == "Nini"))
		{
			throw new ArgumentException("Did not find Nini XML root node");
		}
		WriteProcess(xmlDocument_0.DocumentElement);
	}

	private void WriteProcess(XmlNode xmlNode_0)
	{
		ConfigBase configBase = null;
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Section")
			{
				configBase = new ConfigBase(childNode.Attributes["Name"].Value, this);
				base.Configs.Add(configBase);
				NewProcess(childNode, configBase);
			}
		}
	}

	private void NewProcess(XmlNode xmlNode_0, ConfigBase configBase_0)
	{
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Key")
			{
				configBase_0.Add(childNode.Attributes["Name"].Value, childNode.Attributes["Value"].Value);
			}
		}
	}

	private void PushProcess(XmlNode xmlNode_0, string string_0, string string_1)
	{
		XmlNode xmlNode = IncludeProcess(xmlNode_0, string_0);
		if (xmlNode == null)
		{
			InvokeProcess(xmlNode_0, string_0, string_1);
		}
		else
		{
			xmlNode.Attributes["Value"].Value = string_1;
		}
	}

	private void InvokeProcess(XmlNode xmlNode_0, string string_0, string string_1)
	{
		XmlNode xmlNode = _DescriptorDecorator.CreateElement("Key");
		XmlAttribute xmlAttribute = _DescriptorDecorator.CreateAttribute("Name");
		XmlAttribute xmlAttribute2 = _DescriptorDecorator.CreateAttribute("Value");
		xmlAttribute.Value = string_0;
		xmlAttribute2.Value = string_1;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlNode.Attributes.Append(xmlAttribute2);
		xmlNode_0.AppendChild(xmlNode);
	}

	private XmlNode SetupProcess(string string_0)
	{
		XmlElement xmlElement = _DescriptorDecorator.CreateElement("Section");
		XmlAttribute xmlAttribute = _DescriptorDecorator.CreateAttribute("Name");
		xmlAttribute.Value = string_0;
		xmlElement.Attributes.Append(xmlAttribute);
		return xmlElement;
	}

	private XmlNode ExcludeProcess(string string_0)
	{
		XmlNode result = null;
		foreach (XmlNode childNode in _DescriptorDecorator.DocumentElement.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Section" && childNode.Attributes["Name"].Value == string_0)
			{
				return childNode;
			}
		}
		return result;
	}

	private XmlNode IncludeProcess(XmlNode xmlNode_0, string string_0)
	{
		XmlNode result = null;
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Key" && childNode.Attributes["Name"].Value == string_0)
			{
				return childNode;
			}
		}
		return result;
	}

	private bool SearchProcess()
	{
		if (m_PoolDecorator == null)
		{
			return false;
		}
		return _DescriptorDecorator != null;
	}

	private void EnableProcess()
	{
		ChangeProcess();
		foreach (XmlNode childNode in _DescriptorDecorator.DocumentElement.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Section")
			{
				string value = childNode.Attributes["Name"].Value;
				IConfig config = base.Configs[value];
				if (config == null)
				{
					config = new ConfigBase(value, this);
					base.Configs.Add(config);
				}
				InitProcess(config);
			}
		}
	}

	private void ChangeProcess()
	{
		IConfig config = null;
		for (int num = base.Configs.Count - 1; num > -1; num--)
		{
			config = base.Configs[num];
			if (ExcludeProcess(config.Name) == null)
			{
				base.Configs.Remove(config);
			}
		}
	}

	private void InitProcess(IConfig iconfig_0)
	{
		XmlNode xmlNode = ExcludeProcess(iconfig_0.Name);
		string[] keys = iconfig_0.GetKeys();
		string[] array = keys;
		foreach (string string_ in array)
		{
			if (IncludeProcess(xmlNode, string_) == null)
			{
				iconfig_0.Remove(string_);
			}
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Key")
			{
				iconfig_0.Set(childNode.Attributes["Name"].Value, childNode.Attributes["Value"].Value);
			}
		}
	}
}
