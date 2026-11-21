using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Command_Core.SQLTableGenerator;

public sealed class TableClass
{
	private List<KeyValuePair<string, Type>> setterReader;

	private string creatorReader;

	private static Dictionary<Type, string> templateReader;

	public List<KeyValuePair<string, Type>> Fields
	{
		get
		{
			return setterReader;
		}
		set
		{
			setterReader = value;
		}
	}

	public string ClassName
	{
		get
		{
			return creatorReader;
		}
		set
		{
			creatorReader = value;
		}
	}

	[SpecialName]
	private static Dictionary<Type, string> smethod_0()
	{
		if (templateReader == null)
		{
			templateReader = new Dictionary<Type, string>();
			templateReader.Add(typeof(int), "BIGINT");
			templateReader.Add(typeof(string), "NVARCHAR");
			templateReader.Add(typeof(bool), "BIT");
			templateReader.Add(typeof(DateTime), "DATETIME");
			templateReader.Add(typeof(float), "FLOAT");
			templateReader.Add(typeof(double), "FLOAT");
			templateReader.Add(typeof(decimal), "DECIMAL(18,0)");
			templateReader.Add(typeof(Guid), "UNIQUEIDENTIFIER");
			templateReader.Add(typeof(TimeSpan), "NVARCHAR");
		}
		return templateReader;
	}

	public TableClass(Type type_0)
	{
		setterReader = new List<KeyValuePair<string, Type>>();
		creatorReader = string.Empty;
		creatorReader = type_0.Name;
		PropertyInfo[] properties = type_0.GetProperties();
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			KeyValuePair<string, Type> item = new KeyValuePair<string, Type>(propertyInfo.Name, propertyInfo.PropertyType);
			Fields.Add(item);
		}
	}

	internal string OrderDescriptor()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("CREATE TABLE " + ClassName);
		stringBuilder.AppendLine("(");
		stringBuilder.AppendLine("\t ID BIGINT IDENTITY(1,1) NOT NULL,");
		int num = Fields.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			KeyValuePair<string, Type> keyValuePair = Fields[i];
			if (smethod_0().ContainsKey(keyValuePair.Value))
			{
				stringBuilder.Append("\t " + keyValuePair.Key + " " + smethod_0()[keyValuePair.Value]);
			}
			else
			{
				stringBuilder.Append("\t " + keyValuePair.Key + " BIGINT");
			}
			if (i != Fields.Count - 1)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append(Environment.NewLine);
		}
		stringBuilder.AppendLine(")");
		return stringBuilder.ToString();
	}
}
