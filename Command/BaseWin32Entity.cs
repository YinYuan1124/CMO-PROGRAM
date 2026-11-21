using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using SmartAssembly.Attributes;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
internal abstract class BaseWin32Entity
{
	[CompilerGenerated]
	private Dictionary<string, object> decorator;

	[CompilerGenerated]
	private string process;

	[CompilerGenerated]
	private string thread;

	[CompilerGenerated]
	private string rule;

	[CompilerGenerated]
	private string m_Collection;

	[CompilerGenerated]
	private string instance;

	public string Caption
	{
		[CompilerGenerated]
		get
		{
			return process;
		}
		[CompilerGenerated]
		protected set
		{
			process = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return thread;
		}
		[CompilerGenerated]
		protected set
		{
			thread = value;
		}
	}

	public string Manufacturer
	{
		[CompilerGenerated]
		get
		{
			return rule;
		}
		[CompilerGenerated]
		protected set
		{
			rule = value;
		}
	}

	public string Model
	{
		[CompilerGenerated]
		get
		{
			return m_Collection;
		}
		[CompilerGenerated]
		protected set
		{
			m_Collection = value;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return instance;
		}
		[CompilerGenerated]
		protected set
		{
			instance = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public Dictionary<string, object> DeleteStruct()
	{
		return decorator;
	}

	[SpecialName]
	[CompilerGenerated]
	public void AddStruct(Dictionary<string, object> dictionary_0)
	{
		decorator = dictionary_0;
	}

	public BaseWin32Entity(ManagementBaseObject managementBaseObject_0)
	{
		AddStruct(new Dictionary<string, object>());
		foreach (PropertyData property in managementBaseObject_0.Properties)
		{
			DeleteStruct().Add(property.Name, property.Value);
		}
		Caption = MoveStruct<string>(managementBaseObject_0, "Caption");
		Name = MoveStruct<string>(managementBaseObject_0, "Name");
		Manufacturer = MoveStruct<string>(managementBaseObject_0, "Manufacturer");
		Model = MoveStruct<string>(managementBaseObject_0, "Model");
		Description = MoveStruct<string>(managementBaseObject_0, "Description");
		if (!string.IsNullOrEmpty(Caption))
		{
			Caption = Caption.ToLower();
		}
		if (!string.IsNullOrEmpty(Name))
		{
			Name = Name.ToLower();
		}
		if (!string.IsNullOrEmpty(Manufacturer))
		{
			Manufacturer = Manufacturer.ToLower();
		}
		if (!string.IsNullOrEmpty(Model))
		{
			Model = Model.ToLower();
		}
		if (!string.IsNullOrEmpty(Description))
		{
			Description = Description.ToLower();
		}
	}

	public override string ToString()
	{
		return "manufacturer=" + Manufacturer + ", name=" + Name + ", model=" + Model + ", caption=" + Caption + ", description=" + Description;
	}

	protected string CustomizeStruct()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string key in DeleteStruct().Keys)
		{
			stringBuilder.AppendLine($"{key} = {CloneStruct(DeleteStruct()[key])}");
		}
		return stringBuilder.ToString();
	}

	private object CloneStruct(object object_0)
	{
		if (object_0 == null)
		{
			return string.Empty;
		}
		if (object_0.GetType().IsArray)
		{
			return ConnectStruct(object_0);
		}
		return object_0;
	}

	protected string ConnectStruct(object object_0)
	{
		return "";
	}

	protected T MoveStruct<T>(ManagementBaseObject managementBaseObject_0, string string_0)
	{
		object obj = null;
		try
		{
			obj = managementBaseObject_0[string_0];
		}
		catch
		{
		}
		if (obj == null)
		{
			if (typeof(T) == typeof(string))
			{
				return (T)Convert.ChangeType(string.Empty, typeof(T));
			}
			return default(T);
		}
		return (T)Convert.ChangeType(obj, typeof(T));
	}
}
