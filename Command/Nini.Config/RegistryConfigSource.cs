using System;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

namespace Nini.Config;

public class RegistryConfigSource : ConfigSourceBase
{
	private class AnnotationCollectionRecord : ConfigBase
	{
		private RegistryKey _ProcExporter;

		private bool _StructPrototype;

		public RegistryKey Key
		{
			get
			{
				return _ProcExporter;
			}
			set
			{
				_ProcExporter = value;
			}
		}

		[SpecialName]
		public bool CallInterruptibleMapping()
		{
			return _StructPrototype;
		}

		[SpecialName]
		public void LogoutInterruptibleMapping(bool bool_0)
		{
			_StructPrototype = bool_0;
		}

		public AnnotationCollectionRecord(string string_0, IConfigSource iconfigSource_0)
			: base(string_0, iconfigSource_0)
		{
		}
	}

	private RegistryKey _ReponseDecorator;

	public RegistryKey DefaultKey
	{
		get
		{
			return _ReponseDecorator;
		}
		set
		{
			_ReponseDecorator = value;
		}
	}

	public override IConfig AddConfig(string string_0)
	{
		if (DefaultKey == null)
		{
			throw new ApplicationException("You must set DefaultKey");
		}
		return AddConfig(string_0, DefaultKey);
	}

	public IConfig AddConfig(string string_0, RegistryKey registryKey_0)
	{
		AnnotationCollectionRecord annotationCollectionRecord = new AnnotationCollectionRecord(string_0, this);
		annotationCollectionRecord.Key = registryKey_0;
		annotationCollectionRecord.LogoutInterruptibleMapping(bool_0: true);
		base.Configs.Add(annotationCollectionRecord);
		return annotationCollectionRecord;
	}

	public void AddMapping(RegistryKey registryKey_0, string string_0)
	{
		RegistryKey registryKey = registryKey_0.OpenSubKey(string_0, writable: true);
		if (registryKey == null)
		{
			throw new ArgumentException("The specified key does not exist");
		}
		ComputeProcess(registryKey, LogoutProcess(registryKey));
	}

	public void AddMapping(RegistryKey registryKey_0, string string_0, RegistryRecurse registryRecurse_0)
	{
		RegistryKey registryKey = registryKey_0.OpenSubKey(string_0, writable: true);
		if (registryKey == null)
		{
			throw new ArgumentException("The specified key does not exist");
		}
		if (registryRecurse_0 == RegistryRecurse.Namespacing)
		{
			ComputeProcess(registryKey, string_0);
		}
		else
		{
			ComputeProcess(registryKey, LogoutProcess(registryKey));
		}
		string[] subKeyNames = registryKey.GetSubKeyNames();
		for (int i = 0; i < subKeyNames.Length; i++)
		{
			switch (registryRecurse_0)
			{
			case RegistryRecurse.Namespacing:
				AddMapping(registryKey_0, string_0 + "\\" + subKeyNames[i], registryRecurse_0);
				break;
			case RegistryRecurse.Flattened:
				AddMapping(registryKey, subKeyNames[i], registryRecurse_0);
				break;
			}
		}
	}

	public override void Save()
	{
		PatchProcess();
		for (int i = 0; i < base.Configs.Count; i++)
		{
			if (base.Configs[i] is AnnotationCollectionRecord)
			{
				AnnotationCollectionRecord annotationCollectionRecord = (AnnotationCollectionRecord)base.Configs[i];
				string[] keys = annotationCollectionRecord.GetKeys();
				for (int j = 0; j < keys.Length; j++)
				{
					annotationCollectionRecord.Key.SetValue(keys[j], annotationCollectionRecord.Get(keys[j]));
				}
			}
		}
	}

	public override void Reload()
	{
		SelectProcess();
	}

	private void ComputeProcess(RegistryKey registryKey_0, string string_0)
	{
		AnnotationCollectionRecord annotationCollectionRecord = new AnnotationCollectionRecord(string_0, this);
		annotationCollectionRecord.Key = registryKey_0;
		string[] valueNames = registryKey_0.GetValueNames();
		string[] array = valueNames;
		foreach (string text in array)
		{
			annotationCollectionRecord.Add(text, registryKey_0.GetValue(text).ToString());
		}
		base.Configs.Add(annotationCollectionRecord);
	}

	private void PatchProcess()
	{
		foreach (IConfig config in base.Configs)
		{
			if (config is AnnotationCollectionRecord)
			{
				AnnotationCollectionRecord annotationCollectionRecord = (AnnotationCollectionRecord)config;
				if (annotationCollectionRecord.CallInterruptibleMapping())
				{
					annotationCollectionRecord.Key = annotationCollectionRecord.Key.CreateSubKey(annotationCollectionRecord.Name);
				}
				CallProcess(annotationCollectionRecord);
				string[] keys = config.GetKeys();
				for (int i = 0; i < keys.Length; i++)
				{
					annotationCollectionRecord.Key.SetValue(keys[i], config.Get(keys[i]));
				}
				annotationCollectionRecord.Key.Flush();
			}
		}
	}

	private void SelectProcess()
	{
		RegistryKey[] array = new RegistryKey[base.Configs.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ((AnnotationCollectionRecord)base.Configs[i]).Key;
		}
		base.Configs.Clear();
		for (int j = 0; j < array.Length; j++)
		{
			ComputeProcess(array[j], LogoutProcess(array[j]));
		}
	}

	private void CallProcess(AnnotationCollectionRecord annotationCollectionRecord_0)
	{
		string[] valueNames = annotationCollectionRecord_0.Key.GetValueNames();
		string[] array = valueNames;
		foreach (string text in array)
		{
			if (!annotationCollectionRecord_0.Contains(text))
			{
				annotationCollectionRecord_0.Key.DeleteValue(text);
			}
		}
	}

	private string LogoutProcess(RegistryKey registryKey_0)
	{
		int num = registryKey_0.Name.LastIndexOf("\\");
		if (num == -1)
		{
			return registryKey_0.Name;
		}
		return registryKey_0.Name.Substring(num + 1);
	}
}
