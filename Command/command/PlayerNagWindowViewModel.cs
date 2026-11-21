using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class PlayerNagWindowViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string valueSchema;

	[CompilerGenerated]
	private string m_TokenizerSchema;

	[CompilerGenerated]
	private string m_StubSchema;

	[NonSerialized]
	private PropertyChangedEventHandler _WriterSchema;

	public string INI_String
	{
		[CompilerGenerated]
		get
		{
			return valueSchema;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(valueSchema, value, StringComparison.Ordinal))
			{
				valueSchema = value;
				OnPropertyChanged("NeverShowAgain");
				OnPropertyChanged("INI_String");
			}
		}
	}

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerSchema;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_TokenizerSchema, value, StringComparison.Ordinal))
			{
				m_TokenizerSchema = value;
				OnPropertyChanged("Title");
			}
		}
	}

	public string Message
	{
		[CompilerGenerated]
		get
		{
			return m_StubSchema;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_StubSchema, value, StringComparison.Ordinal))
			{
				m_StubSchema = value;
				OnPropertyChanged("Message");
			}
		}
	}

	public bool NeverShowAgain
	{
		get
		{
			if (!FileExistsNative.FileExistsFast(method_0()))
			{
				new IniConfigSource().Save(method_0());
			}
			string text = new IniConfigSource(method_0()).Configs[INI_String]?.Get("NeverShowAgain");
			if (text == null)
			{
				return false;
			}
			return Conversions.ToBoolean(text);
		}
		set
		{
			if (NeverShowAgain != value)
			{
				IniConfigSource iniConfigSource;
				if (!FileExistsNative.FileExistsFast(method_0()))
				{
					iniConfigSource = new IniConfigSource();
					iniConfigSource.Save(method_0());
				}
				iniConfigSource = new IniConfigSource(method_0());
				if (iniConfigSource.Configs[INI_String] == null)
				{
					iniConfigSource.AddConfig(INI_String);
				}
				iniConfigSource.Configs[INI_String].Set("NeverShowAgain", value);
				iniConfigSource.Save(method_0());
				OnPropertyChanged("NeverShowAgain");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _WriterSchema;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _WriterSchema, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _WriterSchema;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _WriterSchema, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	[SpecialName]
	private string method_0()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "PlayerDialogOptions.ini");
	}

	public void OnPropertyChanged(string string_0)
	{
		_WriterSchema?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
