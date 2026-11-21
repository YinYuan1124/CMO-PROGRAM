using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Nini.Config;

public class DotNetConfigSource : ConfigSourceBase
{
	private string[] m_RequestDecorator;

	private XmlDocument _ValueDecorator;

	private string tokenizerDecorator;

	public string SavePath => tokenizerDecorator;

	public DotNetConfigSource(string[] string_0)
	{
		m_RequestDecorator = string_0;
		StartDecorator();
	}

	public DotNetConfigSource()
	{
		_ValueDecorator = new XmlDocument();
		_ValueDecorator.LoadXml("<configuration><configSections/></configuration>");
		AssetDecorator(_ValueDecorator);
	}

	public DotNetConfigSource(string string_0)
	{
		Load(string_0);
	}

	public DotNetConfigSource(XmlReader xmlReader_0)
	{
		Load(xmlReader_0);
	}

	public void Load(string string_0)
	{
		tokenizerDecorator = string_0;
		_ValueDecorator = new XmlDocument();
		_ValueDecorator.Load(tokenizerDecorator);
		AssetDecorator(_ValueDecorator);
	}

	public void Load(XmlReader xmlReader_0)
	{
		_ValueDecorator = new XmlDocument();
		_ValueDecorator.Load(xmlReader_0);
		AssetDecorator(_ValueDecorator);
	}

	public override void Save()
	{
		if (!FlushDecorator())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		RunDecorator();
		_ValueDecorator.Save(tokenizerDecorator);
		base.Save();
	}

	public void Save(string string_0)
	{
		if (!FlushDecorator())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		tokenizerDecorator = string_0;
		Save();
	}

	public void Save(TextWriter textWriter_0)
	{
		if (!FlushDecorator())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		RunDecorator();
		_ValueDecorator.Save(textWriter_0);
		tokenizerDecorator = null;
		OnSaved(new EventArgs());
	}

	public void Save(Stream stream_0)
	{
		if (!FlushDecorator())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		RunDecorator();
		_ValueDecorator.Save(stream_0);
		tokenizerDecorator = null;
		OnSaved(new EventArgs());
	}

	public override void Reload()
	{
		if (tokenizerDecorator == null)
		{
			throw new ArgumentException("Error reloading: You must have the loaded the source from a file");
		}
		_ValueDecorator = new XmlDocument();
		_ValueDecorator.Load(tokenizerDecorator);
		OrderDecorator();
		base.Reload();
	}

	public override string ToString()
	{
		RunDecorator();
		StringWriter stringWriter = new StringWriter();
		_ValueDecorator.Save(stringWriter);
		return stringWriter.ToString();
	}

	public static string GetFullConfigPath()
	{
		return Assembly.GetCallingAssembly().Location + ".config";
	}

	private void RunDecorator()
	{
		AwakeDecorator();
		foreach (IConfig config in base.Configs)
		{
			string[] keys = config.GetKeys();
			QueryDecorator(config.Name);
			XmlNode xmlNode = CollectDecorator(config.Name);
			if (xmlNode == null)
			{
				xmlNode = RateDecorator(config.Name);
			}
			for (int i = 0; i < keys.Length; i++)
			{
				ResetDecorator(xmlNode, keys[i], config.Get(keys[i]));
			}
		}
	}

	private void StartDecorator()
	{
		Merge(this);
		for (int i = 0; i < m_RequestDecorator.Length; i++)
		{
			CalcDecorator(m_RequestDecorator[i], (NameValueCollection)ConfigurationSettings.GetConfig(m_RequestDecorator[i]));
		}
	}

	private void AssetDecorator(XmlDocument xmlDocument_0)
	{
		base.Configs.Clear();
		Merge(this);
		if (!(xmlDocument_0.DocumentElement.Name == "configuration"))
		{
			throw new ArgumentException("Did not find configuration node");
		}
		PrintDecorator(xmlDocument_0.DocumentElement);
	}

	private void PrintDecorator(XmlNode xmlNode_0)
	{
		DefineDecorator(xmlNode_0, "appSettings");
		XmlNode xmlNode = ForgotDecorator(xmlNode_0, "configSections");
		if (xmlNode == null)
		{
			return;
		}
		ConfigBase configBase = null;
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "section")
			{
				configBase = new ConfigBase(childNode.Attributes["name"].Value, this);
				base.Configs.Add(configBase);
				PublishDecorator(xmlNode_0, configBase);
			}
		}
	}

	private void DefineDecorator(XmlNode xmlNode_0, string string_0)
	{
		XmlNode xmlNode = ForgotDecorator(xmlNode_0, string_0);
		ConfigBase configBase = null;
		if (xmlNode != null)
		{
			configBase = new ConfigBase(xmlNode.Name, this);
			base.Configs.Add(configBase);
			PublishDecorator(xmlNode_0, configBase);
		}
	}

	private void PublishDecorator(XmlNode xmlNode_0, ConfigBase configBase_0)
	{
		foreach (XmlNode childNode in ForgotDecorator(xmlNode_0, configBase_0.Name).ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "add")
			{
				configBase_0.Add(childNode.Attributes["key"].Value, childNode.Attributes["value"].Value);
			}
		}
	}

	private void AwakeDecorator()
	{
		XmlAttribute xmlAttribute = null;
		XmlNode xmlNode = CollectDecorator("configSections");
		if (xmlNode == null)
		{
			return;
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType != XmlNodeType.Element || !(childNode.Name == "section"))
			{
				continue;
			}
			xmlAttribute = childNode.Attributes["name"];
			if (xmlAttribute != null)
			{
				if (base.Configs[xmlAttribute.Value] == null)
				{
					childNode.ParentNode.RemoveChild(childNode);
					XmlNode xmlNode2 = CollectDecorator(xmlAttribute.Value);
					if (xmlNode2 != null)
					{
						_ValueDecorator.DocumentElement.RemoveChild(xmlNode2);
					}
				}
				continue;
			}
			throw new ArgumentException("Section name attribute not found");
		}
	}

	private void QueryDecorator(string string_0)
	{
		XmlNode xmlNode = CollectDecorator(string_0);
		XmlAttribute xmlAttribute = null;
		if (xmlNode == null)
		{
			return;
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "add")
			{
				xmlAttribute = childNode.Attributes["key"];
				if (xmlAttribute == null)
				{
					throw new ArgumentException("Key attribute not found in node");
				}
				if (base.Configs[string_0].Get(xmlAttribute.Value) == null)
				{
					xmlNode.RemoveChild(childNode);
				}
			}
		}
	}

	private void ResetDecorator(XmlNode xmlNode_0, string string_0, string string_1)
	{
		XmlNode xmlNode = MapDecorator(xmlNode_0, string_0);
		if (xmlNode == null)
		{
			SortDecorator(xmlNode_0, string_0, string_1);
		}
		else
		{
			xmlNode.Attributes["value"].Value = string_1;
		}
	}

	private XmlNode MapDecorator(XmlNode xmlNode_0, string string_0)
	{
		XmlNode result = null;
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "add" && childNode.Attributes["key"].Value == string_0)
			{
				return childNode;
			}
		}
		return result;
	}

	private void SortDecorator(XmlNode xmlNode_0, string string_0, string string_1)
	{
		XmlNode xmlNode = _ValueDecorator.CreateElement("add");
		XmlAttribute xmlAttribute = _ValueDecorator.CreateAttribute("key");
		XmlAttribute xmlAttribute2 = _ValueDecorator.CreateAttribute("value");
		xmlAttribute.Value = string_0;
		xmlAttribute2.Value = string_1;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlNode.Attributes.Append(xmlAttribute2);
		xmlNode_0.AppendChild(xmlNode);
	}

	private void CalcDecorator(string string_0, NameValueCollection nameValueCollection_0)
	{
		ConfigBase configBase = new ConfigBase(string_0, this);
		if (nameValueCollection_0 == null)
		{
			throw new ArgumentException("Section was not found");
		}
		if (nameValueCollection_0 != null)
		{
			for (int i = 0; i < nameValueCollection_0.Count; i++)
			{
				configBase.Add(nameValueCollection_0.Keys[i], nameValueCollection_0[i]);
			}
			base.Configs.Add(configBase);
		}
	}

	private XmlNode RateDecorator(string string_0)
	{
		XmlNode xmlNode = _ValueDecorator.CreateElement("section");
		XmlAttribute xmlAttribute = _ValueDecorator.CreateAttribute("name");
		xmlAttribute.Value = string_0;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _ValueDecorator.CreateAttribute("type");
		xmlAttribute.Value = "System.Configuration.NameValueSectionHandler";
		xmlNode.Attributes.Append(xmlAttribute);
		CollectDecorator("configSections").AppendChild(xmlNode);
		XmlNode xmlNode2 = _ValueDecorator.CreateElement(string_0);
		_ValueDecorator.DocumentElement.AppendChild(xmlNode2);
		return xmlNode2;
	}

	private bool FlushDecorator()
	{
		if (tokenizerDecorator == null)
		{
			return _ValueDecorator != null;
		}
		return true;
	}

	private XmlNode ForgotDecorator(XmlNode xmlNode_0, string string_0)
	{
		XmlNode result = null;
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == string_0)
			{
				return childNode;
			}
		}
		return result;
	}

	private XmlNode CollectDecorator(string string_0)
	{
		return ForgotDecorator(_ValueDecorator.DocumentElement, string_0);
	}

	private void OrderDecorator()
	{
		RegisterDecorator();
		XmlNode xmlNode = CollectDecorator("configSections");
		if (xmlNode == null)
		{
			return;
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "section")
			{
				string value = childNode.Attributes["name"].Value;
				IConfig config = base.Configs[value];
				if (config == null)
				{
					config = new ConfigBase(value, this);
					base.Configs.Add(config);
				}
				ManageDecorator(config);
			}
		}
	}

	private void RegisterDecorator()
	{
		IConfig config = null;
		for (int num = base.Configs.Count - 1; num > -1; num--)
		{
			config = base.Configs[num];
			if (CollectDecorator(config.Name) == null)
			{
				base.Configs.Remove(config);
			}
		}
	}

	private void ManageDecorator(IConfig iconfig_0)
	{
		XmlNode xmlNode = CollectDecorator(iconfig_0.Name);
		string[] keys = iconfig_0.GetKeys();
		string[] array = keys;
		foreach (string string_ in array)
		{
			if (MapDecorator(xmlNode, string_) == null)
			{
				iconfig_0.Remove(string_);
			}
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "add")
			{
				iconfig_0.Set(childNode.Attributes["key"].Value, childNode.Attributes["value"].Value);
			}
		}
	}
}
