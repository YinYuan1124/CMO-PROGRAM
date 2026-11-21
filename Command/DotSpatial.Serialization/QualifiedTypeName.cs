using System;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

public class QualifiedTypeName
{
	[CompilerGenerated]
	private QualifiedTypeName m_DispatcherObject;

	[CompilerGenerated]
	private string m_ListenerObject;

	[CompilerGenerated]
	private string m_ConfigObject;

	[CompilerGenerated]
	private Version registryObject;

	[CompilerGenerated]
	private string definitionObject;

	[CompilerGenerated]
	private string m_ValObject;

	public QualifiedTypeName EnclosedName
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherObject;
		}
		[CompilerGenerated]
		set
		{
			m_DispatcherObject = value;
		}
	}

	public string TypeName
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerObject;
		}
		[CompilerGenerated]
		set
		{
			m_ListenerObject = value;
		}
	}

	public string Assembly
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigObject;
		}
		[CompilerGenerated]
		set
		{
			m_ConfigObject = value;
		}
	}

	public Version Version
	{
		[CompilerGenerated]
		get
		{
			return registryObject;
		}
		[CompilerGenerated]
		set
		{
			registryObject = value;
		}
	}

	public string Culture
	{
		[CompilerGenerated]
		get
		{
			return definitionObject;
		}
		[CompilerGenerated]
		set
		{
			definitionObject = value;
		}
	}

	public string PublicKeyToken
	{
		[CompilerGenerated]
		get
		{
			return m_ValObject;
		}
		[CompilerGenerated]
		set
		{
			m_ValObject = value;
		}
	}

	public QualifiedTypeName(string string_0)
	{
		if (string_0.Contains("[["))
		{
			int num = string_0.IndexOf("[[");
			int num2 = string_0.IndexOf("]]");
			string string_ = string_0.Substring(num + 2, num2 - (num + 2));
			EnclosedName = new QualifiedTypeName(string_);
			string_0 = string_0.Substring(0, num + 2) + string_0.Substring(num2, string_0.Length - num2);
		}
		string[] array = string_0.Split(',');
		TypeName = array[0];
		Assembly = array[1].Trim();
		for (int i = 2; i < array.Length; i++)
		{
			string text = array[i].Trim();
			if (text.Substring(0, 8) == "Version=")
			{
				string version = text.Substring(8, text.Length - 8);
				Version = new Version(version);
			}
			if (text.Substring(0, 8) == "Culture=")
			{
				Culture = text.Substring(8, text.Length - 8);
			}
			if (text.Substring(0, 15) == "PublicKeyToken=")
			{
				PublicKeyToken = text.Substring(15, text.Length - 15);
			}
		}
	}

	public new string ToString()
	{
		string text = TypeName;
		if (text.Contains("[["))
		{
			int startIndex = TypeName.IndexOf("]]");
			text = TypeName.Insert(startIndex, EnclosedName.ToString());
		}
		string text2 = PublicKeyToken;
		if (string.IsNullOrEmpty(text2))
		{
			text2 = "null";
		}
		return $"{text}, {Assembly}, Version={Version}, Culture={Culture}, PublicKeyToken={text2}";
	}
}
