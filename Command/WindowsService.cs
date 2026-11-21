using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using SmartAssembly.Attributes;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
internal class WindowsService
{
	private static Regex token;

	[CompilerGenerated]
	private string m_Indexer;

	[CompilerGenerated]
	private string m_Resolver;

	[CompilerGenerated]
	private string publisher;

	[CompilerGenerated]
	private FileInfo server;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return m_Resolver;
		}
		[CompilerGenerated]
		private set
		{
			m_Resolver = value;
		}
	}

	public FileVersionInfo Version { get; private set; }

	[SpecialName]
	[CompilerGenerated]
	public string ReflectStruct()
	{
		return m_Indexer;
	}

	[SpecialName]
	[CompilerGenerated]
	private void VisitStruct(string string_0)
	{
		m_Indexer = string_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public string CancelStruct()
	{
		return publisher;
	}

	[SpecialName]
	[CompilerGenerated]
	private void VerifyStruct(string string_0)
	{
		publisher = string_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public FileInfo ResolveStruct()
	{
		return server;
	}

	[SpecialName]
	[CompilerGenerated]
	private void PostStruct(FileInfo fileInfo_0)
	{
		server = fileInfo_0;
	}

	public WindowsService(ServiceController serviceController_0)
	{
		Name = serviceController_0.ServiceName.ToLower();
		VisitStruct(serviceController_0.DisplayName.ToLower());
		try
		{
			string name = "SYSTEM\\CurrentControlSet\\Services\\" + serviceController_0.ServiceName;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name);
			string name2 = registryKey.GetValue("ImagePath").ToString();
			registryKey.Close();
			VerifyStruct(Environment.ExpandEnvironmentVariables(name2).ToLower());
			Match match = token.Match(CancelStruct());
			if (!match.Success)
			{
				return;
			}
			string text = match.Groups["name"].Value;
			if (!FileExistsNative.FileExistsFast(text))
			{
				text += ".exe";
			}
			if (FileExistsNative.FileExistsFast(text))
			{
				PostStruct(new FileInfo(text));
				if (ResolveStruct() != null && ResolveStruct().Exists)
				{
					Version = FileVersionInfo.GetVersionInfo(text);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} ({1})", ReflectStruct(), Name);
		if (ResolveStruct() == null)
		{
			stringBuilder.AppendFormat(" - {0}", CancelStruct());
		}
		else
		{
			if (ResolveStruct() != null)
			{
				stringBuilder.AppendFormat(" - {0}", ResolveStruct().ToString());
			}
			if (Version != null)
			{
				stringBuilder.AppendFormat(" (v{0})", Version.ProductVersion);
			}
		}
		return stringBuilder.ToString();
	}

	static WindowsService()
	{
		token = new Regex("((?<name>[A-Z]:.+?(\\.exe|\\Z))|(?:\"(?<name>.+?)\"))", RegexOptions.IgnoreCase);
	}
}
