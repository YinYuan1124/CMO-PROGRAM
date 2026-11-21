using System;
using System.Reflection;

namespace DotSpatial.Serialization;

public static class XmlConstants
{
	public const string DICTIONARY = "dictionary";

	public const string DICTIONARY_ENTRY = "entry";

	public const string DICTIONARY_KEY = "key";

	public const string DICTIONARY_VALUE = "value";

	public const string ENUM = "enum";

	public const string LIST = "list";

	public const string OBJECT = "object";

	public const string PRIMITIVE = "primitive";

	public const string STRING = "string";

	public const string ROOT = "root";

	public const string MEMBER = "member";

	public const string ITEM = "item";

	public const string TYPE_CACHE = "types";

	public const string TYPE_ID = "type";

	public const string VALUE = "value";

	public const string ARG = "arg";

	public const string FORMATTER = "formatter";

	public const string NAME = "name";

	public const string KEY = "key";

	public const string ID = "id";

	public const string REF = "ref";

	public static Type GetMemberType(MemberInfo memberInfo_0)
	{
		if (memberInfo_0 is PropertyInfo)
		{
			return ((PropertyInfo)memberInfo_0).PropertyType;
		}
		return ((FieldInfo)memberInfo_0).FieldType;
	}
}
