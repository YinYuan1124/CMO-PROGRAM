using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Command.Bridges;

namespace DotSpatial.Serialization;

public class XmlDeserializer
{
	[CompilerGenerated]
	private sealed class ObjectProcessProducer
	{
		public AssemblyName name;

		internal bool DeleteInterruptibleMock(Assembly z)
		{
			return z.FullName == name.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class VisitorPrototype
	{
		public bool includeConstructorElements;

		public Func<XElement, bool> _003C_003E9__0;

		internal bool AddInterruptibleMock(XElement m)
		{
			return (m.Attribute("arg") == null) | includeConstructorElements;
		}
	}

	[CompilerGenerated]
	private sealed class ItemInstanceFilter
	{
		public string string_0;

		internal bool DestroyInterruptibleMock(SerializationMapEntry m)
		{
			return m.Attribute.Name == string_0;
		}
	}

	private Dictionary<string, object> m_PropertyObject;

	private Dictionary<string, Type> importerObject;

	public T Deserialize<T>(string string_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("xml");
		}
		return AwakeExpression(default(T), string_0, bool_0: false);
	}

	public void Deserialize<T>(T existingObject, string string_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("xml");
		}
		if (!typeof(T).IsValueType && existingObject == null)
		{
			throw new ArgumentNullException("existingObject");
		}
		AwakeExpression(existingObject, string_0, bool_0: true);
	}

	private T AwakeExpression<T>(T gparam_0, string string_0, bool bool_0)
	{
		m_PropertyObject = new Dictionary<string, object>();
		try
		{
			using StringReader textReader = new StringReader(string_0);
			XElement root = XDocument.Load(textReader).Root;
			if (root == null)
			{
				throw new XmlException("Could not find a root XML element.");
			}
			importerObject = QueryExpression(root);
			if (bool_0)
			{
				MapExpression(root, gparam_0, bool_0: true);
				return gparam_0;
			}
			return (T)ResetExpression(root, null);
		}
		finally
		{
			m_PropertyObject.Clear();
			if (importerObject != null)
			{
				importerObject.Clear();
				importerObject = null;
			}
		}
	}

	private static Dictionary<string, Type> QueryExpression(XContainer xcontainer_0)
	{
		Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
		TypeNameManager typeNameManager = new TypeNameManager();
		foreach (XElement item in xcontainer_0.Elements("types").Elements("item"))
		{
			XAttribute xAttribute = item.Attribute("key");
			XAttribute xAttribute2 = item.Attribute("value");
			if (xAttribute == null || xAttribute2 == null)
			{
				continue;
			}
			Type type;
			try
			{
				type = Type.GetType(xAttribute2.Value);
				if (type == null)
				{
					type = Type.GetType(xAttribute2.Value, (AssemblyName name) => AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly z) => z.FullName == name.FullName), null);
				}
			}
			catch (FileLoadException)
			{
				type = Type.GetType(typeNameManager.UpdateTypename(xAttribute2.Value));
			}
			dictionary.Add(xAttribute.Value, type);
		}
		return dictionary;
	}

	private object ResetExpression(XElement xelement_0, object object_0)
	{
		XAttribute xAttribute = xelement_0.Attribute("ref");
		if (xAttribute == null)
		{
			object obj = FlushExpression(xelement_0);
			if (obj == null)
			{
				Type type = ForgotExpression(xelement_0);
				string text = CollectExpression(xelement_0);
				if (type == null)
				{
					throw new ArgumentNullException("Couldn't find the assembly that contains the type that was serialized into that element");
				}
				if (type.IsPrimitive)
				{
					obj = ((text == "NaN") ? Convert.ChangeType(double.NaN, type) : Convert.ChangeType(text, type, CultureInfo.InvariantCulture));
				}
				else if (type.IsEnum)
				{
					obj = Enum.Parse(type, text);
				}
				else if (type == typeof(string))
				{
					obj = XmlHelper.UnEscapeInvalidCharacters(text);
				}
				else if (type == typeof(DateTime))
				{
					obj = Convert.ToDateTime(text, CultureInfo.InvariantCulture);
				}
				else if (type == typeof(Color))
				{
					obj = ColorTranslator.FromHtml(text);
				}
				else if (type == typeof(PointF))
				{
					string[] array = XmlHelper.UnEscapeInvalidCharacters(text).Split('|');
					obj = new PointF(float.Parse(array[0]), float.Parse(array[1]));
				}
				else
				{
					if (object_0 == null)
					{
						try
						{
							obj = OrderExpression(type, xelement_0);
						}
						catch
						{
							obj = null;
						}
					}
					else
					{
						obj = object_0;
					}
					if (obj != null)
					{
						MapExpression(xelement_0, obj, bool_0: false);
					}
				}
				return obj;
			}
			return obj;
		}
		return m_PropertyObject[xAttribute.Value];
	}

	private void MapExpression(XElement xelement_0, object object_0, bool bool_0)
	{
		Type type = object_0.GetType();
		SerializationMap serializationMap = SerializationMap.FromType(type);
		XAttribute xAttribute = xelement_0.Attribute("id");
		if (xAttribute != null)
		{
			m_PropertyObject[xAttribute.Value] = object_0;
		}
		foreach (XElement item in from m in xelement_0.Elements("member")
			where m.Attribute("arg") == null || bool_0
			select m)
		{
			string string_0 = GetName(item);
			SerializationMapEntry serializationMapEntry = serializationMap.Members.FirstOrDefault((SerializationMapEntry m) => m.Attribute.Name == string_0);
			if (serializationMapEntry == null)
			{
				continue;
			}
			if (serializationMapEntry.Member is PropertyInfo)
			{
				PropertyInfo propertyInfo = (PropertyInfo)serializationMapEntry.Member;
				if (propertyInfo.CanWrite)
				{
					propertyInfo.SetValue(object_0, ResetExpression(item, null), null);
				}
				else
				{
					MapExpression(item, propertyInfo.GetValue(object_0, null), bool_0: false);
				}
			}
			else
			{
				((FieldInfo)serializationMapEntry.Member).SetValue(object_0, ResetExpression(item, null));
			}
		}
		if (type.IsArray)
		{
			SortExpression(xelement_0, (Array)object_0);
		}
		else if (typeof(IDictionary).IsAssignableFrom(type))
		{
			CalcExpression(xelement_0, (IDictionary)object_0);
		}
		else if (typeof(IList).IsAssignableFrom(type))
		{
			RateExpression(xelement_0, (IList)object_0);
		}
	}

	private void SortExpression(XElement xelement_0, Array array_0)
	{
		int index = 0;
		foreach (XElement item in xelement_0.Elements("item"))
		{
			object value = ResetExpression(item, array_0.GetValue(index));
			array_0.SetValue(value, index++);
		}
	}

	private void CalcExpression(XElement xelement_0, IDictionary idictionary_0)
	{
		if (idictionary_0.Count > 0)
		{
			idictionary_0.Clear();
		}
		foreach (XElement item in xelement_0.Elements("entry"))
		{
			XElement xElement = item.Element("key");
			XElement xElement2 = item.Element("value");
			if (xElement != null && xElement2 != null)
			{
				object obj = ResetExpression(xElement, null);
				object obj2 = ResetExpression(xElement2, null);
				if (obj != null && obj2 != null)
				{
					idictionary_0.Add(obj, obj2);
				}
			}
		}
	}

	private void RateExpression(XElement xelement_0, IList ilist_0)
	{
		if (ilist_0.Count > 0)
		{
			ilist_0.Clear();
		}
		foreach (XElement item in xelement_0.Elements("item"))
		{
			object obj = ResetExpression(item, null);
			if (obj != null)
			{
				ilist_0.Add(obj);
			}
		}
	}

	private object FlushExpression(XElement xelement_0)
	{
		XAttribute xAttribute = xelement_0.Attribute("formatter");
		if (xAttribute == null)
		{
			return null;
		}
		XAttribute xAttribute2 = xelement_0.Attribute("value");
		if (xAttribute2 == null)
		{
			throw new XmlException("Missing value attribute for formattable element " + ManageExpression(xelement_0));
		}
		ConstructorInfo constructor = importerObject[xAttribute.Value].GetConstructor(Type.EmptyTypes);
		object[] emptyTypes2 = Type.EmptyTypes;
		object[] emptyTypes = emptyTypes2;
		object[] parameters = emptyTypes;
		return ((SerializationFormatter)constructor.Invoke(parameters)).FromString(XmlHelper.UnEscapeInvalidCharacters(xAttribute2.Value));
	}

	private Type ForgotExpression(XElement xelement_0)
	{
		XAttribute xAttribute = xelement_0.Attribute("type");
		if (xAttribute == null)
		{
			throw new XmlException("Missing type attribute for node " + ManageExpression(xelement_0));
		}
		return importerObject[xAttribute.Value];
	}

	private static string CollectExpression(XElement xelement_0)
	{
		return xelement_0.Attribute("value")?.Value;
	}

	private static string GetName(XElement xelement_0)
	{
		return (xelement_0.Attribute("name") ?? throw new XmlException("Missing name attribute for node " + ManageExpression(xelement_0))).Value;
	}

	private object OrderExpression(Type type_0, XElement xelement_0)
	{
		List<object> list;
		if (type_0.IsArray)
		{
			int num = xelement_0.Elements("item").Count();
			list = new List<object> { num };
		}
		else
		{
			list = RegisterExpression(xelement_0);
		}
		Type[] types = list.Select((object arg) => arg.GetType()).ToArray();
		return type_0.GetConstructor(types).Invoke(list.ToArray());
	}

	private List<object> RegisterExpression(XElement xelement_0)
	{
		List<object> list = new List<object>();
		int num = 0;
		foreach (XElement item in from m in xelement_0.Elements("member")
			select new SchemaThreadBridge<XElement, XAttribute>(m, m.Attribute("arg")) into _003C_003Eh__TransparentIdentifier0
			where _003C_003Eh__TransparentIdentifier0.arg != null
			orderby _003C_003Eh__TransparentIdentifier0.arg.Value
			select _003C_003Eh__TransparentIdentifier0.m)
		{
			XAttribute xAttribute = item.Attribute("arg");
			if (xAttribute != null)
			{
				if (int.Parse(xAttribute.Value, CultureInfo.InvariantCulture) != num)
				{
					throw new XmlException("Missing constructor argument " + num);
				}
				num++;
				list.Add(ResetExpression(item, null));
			}
		}
		return list;
	}

	private static string ManageExpression(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Stack<string> stack = new Stack<string>();
		do
		{
			stack.Push(((XElement)object_0).Name.LocalName);
			object_0 = ((XObject)object_0).Parent;
		}
		while (object_0 != null);
		stringBuilder.Append("/");
		do
		{
			stringBuilder.Append(stack.Pop());
			if (stack.Count > 0)
			{
				stringBuilder.Append("/");
			}
		}
		while (stack.Count > 0);
		return stringBuilder.ToString();
	}
}
