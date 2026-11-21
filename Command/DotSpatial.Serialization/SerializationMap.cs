using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

public class SerializationMap
{
	[CompilerGenerated]
	private sealed class MerchantConfigManager
	{
		public MemberInfo memberInfo_0;

		internal bool MoveInterruptibleMock(SerializationMapEntry mi)
		{
			if (mi.Member.Name == memberInfo_0.Name && mi.Member.DeclaringType == memberInfo_0.DeclaringType)
			{
				return mi.Member.MemberType == memberInfo_0.MemberType;
			}
			return false;
		}
	}

	private static readonly Dictionary<Type, SerializationMap> m_WrapperObject;

	private readonly List<SerializationMapEntry> _ObserverObject = new List<SerializationMapEntry>();

	public Type ForType { get; private set; }

	public List<SerializationMapEntry> Members => _ObserverObject;

	static SerializationMap()
	{
		m_WrapperObject = new Dictionary<Type, SerializationMap>();
		foreach (Type item in ReflectionHelper.FindDerivedClasses(typeof(SerializationMap)))
		{
			SerializationMap serializationMap;
			try
			{
				serializationMap = (SerializationMap)item.Assembly.CreateInstance(item.FullName);
			}
			catch
			{
				continue;
			}
			if (serializationMap != null)
			{
				m_WrapperObject[serializationMap.ForType] = serializationMap;
			}
		}
	}

	protected SerializationMap(Type type_0)
	{
		ForType = type_0;
		TestExpression(type_0);
		m_WrapperObject[type_0] = this;
	}

	public static SerializationMap FromType(Type type_0)
	{
		SerializationMap serializationMap = RestartExpression(type_0);
		if (serializationMap == null)
		{
			return new SerializationMap(type_0);
		}
		return serializationMap;
	}

	private static SerializationMap RestartExpression(Type type_0)
	{
		if (m_WrapperObject.ContainsKey(type_0))
		{
			return m_WrapperObject[type_0];
		}
		return null;
	}

	protected SerializationMapEntry Serialize(MemberInfo memberInfo_0, string string_0)
	{
		SerializationMapEntry serializationMapEntry = new SerializationMapEntry(memberInfo_0, new SerializeAttribute(string_0));
		_ObserverObject.Add(serializationMapEntry);
		return serializationMapEntry;
	}

	private void TestExpression(Type type_0)
	{
		ResolveExpression(type_0);
		PostExpression(type_0);
	}

	private void StopExpression(Type type_0, BindingFlags bindingFlags_0)
	{
		ListExpression(type_0.GetProperties(bindingFlags_0));
	}

	private void CancelExpression(Type type_0, BindingFlags bindingFlags_0)
	{
		ListExpression((from fi in type_0.GetFields(bindingFlags_0)
			where !fi.IsInitOnly || VerifyExpression(fi)
			select fi).Cast<MemberInfo>());
	}

	private static bool VerifyExpression(MemberInfo memberInfo_0)
	{
		object[] customAttributes = memberInfo_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true);
		int num = 0;
		if (customAttributes.Length != 0)
		{
			return ((SerializeAttribute)customAttributes[num]).ConstructorArgumentIndex >= 0;
		}
		return false;
	}

	private void ListExpression(IEnumerable<MemberInfo> ienumerable_0)
	{
		foreach (MemberInfo item in ienumerable_0)
		{
			SerializeAttribute serializeAttribute = item.GetCustomAttributes(typeof(SerializeAttribute), inherit: true).Cast<SerializeAttribute>().FirstOrDefault();
			MemberInfo memberInfo_0 = item;
			if (serializeAttribute != null && !_ObserverObject.Any((SerializationMapEntry mi) => mi.Member.Name == memberInfo_0.Name && mi.Member.DeclaringType == memberInfo_0.DeclaringType && mi.Member.MemberType == memberInfo_0.MemberType))
			{
				_ObserverObject.Add(new SerializationMapEntry(item, serializeAttribute));
			}
		}
	}

	private void ResolveExpression(Type type_0)
	{
		Type baseType = type_0.BaseType;
		Stack<Type> stack = new Stack<Type>();
		stack.Push(type_0);
		while (baseType != null && !baseType.Equals(typeof(object)))
		{
			stack.Push(baseType);
			baseType = baseType.BaseType;
		}
		while (stack.Count > 0)
		{
			type_0 = stack.Pop();
			CancelExpression(type_0, BindingFlags.Instance | BindingFlags.NonPublic);
			StopExpression(type_0, BindingFlags.Instance | BindingFlags.NonPublic);
		}
	}

	private void PostExpression(Type type_0)
	{
		CancelExpression(type_0, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		StopExpression(type_0, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
	}
}
