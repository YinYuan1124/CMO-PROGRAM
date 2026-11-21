using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace OpenDis.Core;

public static class EnumHelper
{
	public static bool EnumerationForValueExists<T>(int int_0)
	{
		return Enum.IsDefined(typeof(T), int_0);
	}

	public static string GetDescription<T>(T value)
	{
		string result = string.Empty;
		DescriptionAttribute enumValueAttribute = GetEnumValueAttribute<DescriptionAttribute, T>(value);
		if (enumValueAttribute != null)
		{
			result = enumValueAttribute.Description;
		}
		return result;
	}

	public static T GetEnumerationForValue<T>(int int_0)
	{
		if (!Enum.IsDefined(typeof(T), int_0))
		{
			throw new EnumNotFoundException($"No enumeration found for value {int_0} of enumeration {typeof(T).Name}", typeof(T));
		}
		return (T)Enum.ToObject(typeof(T), int_0);
	}

	public static T GetEnumValueAttribute<T, U>(U value)
	{
		if (typeof(U).IsEnum)
		{
			if (value != null)
			{
				FieldInfo field = typeof(U).GetField(Enum.GetName(typeof(U), value));
				if (field != null)
				{
					object[] customAttributes = field.GetCustomAttributes(typeof(T), inherit: false);
					if (customAttributes != null && customAttributes.Length != 0)
					{
						return (T)customAttributes[0];
					}
				}
			}
			return default(T);
		}
		throw new ArgumentException("Type must be an enum.");
	}

	public static IEnumerable<T> GetEnumValueAttributes<T, U>(U value)
	{
		if (typeof(U).IsEnum)
		{
			if (value != null)
			{
				FieldInfo field = typeof(U).GetField(Enum.GetName(typeof(U), value));
				if (field != null)
				{
					object[] customAttributes = field.GetCustomAttributes(typeof(T), inherit: false);
					if (customAttributes != null && customAttributes.Length != 0)
					{
						return customAttributes.Cast<T>();
					}
				}
			}
			return new T[0];
		}
		throw new ArgumentException("Type must be an enum.");
	}

	public static string GetInternetDomainCode<T>(T value)
	{
		string result = string.Empty;
		InternetDomainCodeAttribute enumValueAttribute = GetEnumValueAttribute<InternetDomainCodeAttribute, T>(value);
		if (enumValueAttribute != null)
		{
			result = enumValueAttribute.InternetDomainCode;
		}
		return result;
	}

	public static T Parse<T>(string string_0)
	{
		return (T)Enum.Parse(typeof(T), string_0);
	}

	public static T Parse<T>(string string_0, bool bool_0)
	{
		return (T)Enum.Parse(typeof(T), string_0, bool_0);
	}
}
