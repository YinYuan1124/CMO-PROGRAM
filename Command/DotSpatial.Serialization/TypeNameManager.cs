using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DotSpatial.Serialization;

public class TypeNameManager
{
	private readonly Dictionary<string, Assembly> m_ReaderObject;

	public TypeNameManager()
	{
		m_ReaderObject = new Dictionary<string, Assembly>();
	}

	public string UpdateTypename(string string_0)
	{
		QualifiedTypeName qualifiedTypeName = new QualifiedTypeName(string_0);
		for (QualifiedTypeName qualifiedTypeName2 = qualifiedTypeName; qualifiedTypeName2 != null; qualifiedTypeName2 = qualifiedTypeName2.EnclosedName)
		{
			DefineExpression(qualifiedTypeName2);
		}
		return qualifiedTypeName.ToString();
	}

	private void DefineExpression(QualifiedTypeName qualifiedTypeName_0)
	{
		if (!m_ReaderObject.Keys.Contains(qualifiedTypeName_0.Assembly))
		{
			PublishExpression(qualifiedTypeName_0.Assembly);
		}
		if (m_ReaderObject.Keys.Contains(qualifiedTypeName_0.Assembly))
		{
			AssemblyName name = m_ReaderObject[qualifiedTypeName_0.Assembly].GetName();
			qualifiedTypeName_0.Version = name.Version;
			string text = BitConverter.ToString(name.GetPublicKeyToken());
			string text4 = (qualifiedTypeName_0.PublicKeyToken = text.Replace("-", string.Empty).ToLower());
			string text2 = text4;
			text = text2;
		}
	}

	private void PublishExpression(string string_0)
	{
		string text = string_0 + ".dll";
		if (!File.Exists(text))
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (directoryName != null)
			{
				string[] files = Directory.GetFiles(directoryName, text, SearchOption.AllDirectories);
				if (files.Length == 0)
				{
					string directoryName2 = Path.GetDirectoryName(directoryName);
					if (directoryName2 != null)
					{
						DirectoryInfo parent = Directory.GetParent(directoryName2);
						while (parent != null)
						{
							string[] files2 = Directory.GetFiles(directoryName, text, SearchOption.TopDirectoryOnly);
							if (files2.Length == 0)
							{
								parent = parent.Parent;
								continue;
							}
							text = files2[0];
							break;
						}
					}
				}
				else
				{
					text = files[0];
				}
			}
		}
		if (File.Exists(text))
		{
			Assembly assembly = Assembly.LoadFrom(text);
			if (assembly != null)
			{
				m_ReaderObject.Add(string_0, assembly);
			}
		}
	}
}
