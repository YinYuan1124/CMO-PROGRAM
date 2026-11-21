using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Watchers;

internal class ListRuleWatcher : EnumConverter
{
	private Type m_ManagerTests;

	public ListRuleWatcher(Type type_0)
		: base(type_0)
	{
		m_ManagerTests = type_0;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		return destinationType == typeof(string);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(m_ManagerTests.GetField(Enum.GetName(m_ManagerTests, RuntimeHelpers.GetObjectValue(value))), typeof(DescriptionAttribute));
		if (descriptionAttribute == null)
		{
			return value.ToString();
		}
		return Localization.Translate(descriptionAttribute.Description);
	}

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		FieldInfo[] fields = m_ManagerTests.GetFields();
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
				if (descriptionAttribute != null && (Operators.CompareString(Conversions.ToString(value), descriptionAttribute.Description, TextCompare: true) == 0 || Operators.CompareString(Conversions.ToString(value), Localization.Translate(descriptionAttribute.Description), TextCompare: true) == 0))
				{
					break;
				}
				num++;
				continue;
			}
			return Enum.Parse(m_ManagerTests, Conversions.ToString(value));
		}
		return Enum.Parse(m_ManagerTests, fieldInfo.Name);
	}
}
