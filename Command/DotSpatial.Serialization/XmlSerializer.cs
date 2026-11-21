using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DotSpatial.Serialization;

public class XmlSerializer
{
	private class ListDecoratorEntry
	{
		[CompilerGenerated]
		private sealed class ConsumerMerchantPage
		{
			public object o;

			internal bool SetupInterruptiblePolicy(KeyValuePair<object, XElement> kvp)
			{
				KeyValuePair<object, XElement> keyValuePair = kvp;
				return keyValuePair.Key == o;
			}
		}

		[CompilerGenerated]
		private sealed class ProducerProcessResolver
		{
			public object o;

			internal bool ExcludeInterruptiblePolicy(KeyValuePair<object, XElement> kvp)
			{
				return kvp.Key == o;
			}
		}

		private readonly List<KeyValuePair<object, XElement>> _ExporterPrototype = new List<KeyValuePair<object, XElement>>();

		private int m_PrototypePrototype;

		public int ComputeInterruptibleMock(object object_0)
		{
			int result = -1;
			XElement xElement = _ExporterPrototype.Where(delegate(KeyValuePair<object, XElement> kvp)
			{
				KeyValuePair<object, XElement> keyValuePair2 = kvp;
				return keyValuePair2.Key == object_0;
			}).Select(delegate(KeyValuePair<object, XElement> kvp)
			{
				KeyValuePair<object, XElement> keyValuePair = kvp;
				return keyValuePair.Value;
			}).FirstOrDefault();
			if (xElement != null)
			{
				XAttribute xAttribute = xElement.Attribute("id");
				if (xAttribute == null)
				{
					xElement.Add(new XAttribute("id", m_PrototypePrototype.ToString(CultureInfo.InvariantCulture)));
					result = m_PrototypePrototype;
					m_PrototypePrototype++;
				}
				else
				{
					result = int.Parse(xAttribute.Value, CultureInfo.InvariantCulture);
				}
			}
			return result;
		}

		public void Add(object object_0, XElement xelement_0)
		{
			_ExporterPrototype.Add(new KeyValuePair<object, XElement>(object_0, xelement_0));
		}

		[Conditional("DEBUG")]
		private void PatchInterruptibleMock(object object_0)
		{
			if (_ExporterPrototype.Any((KeyValuePair<object, XElement> kvp) => kvp.Key == object_0))
			{
				throw new InvalidOperationException("Duplicate entry detected");
			}
		}

		public void SelectInterruptibleMock()
		{
			_ExporterPrototype.Clear();
			m_PrototypePrototype = 0;
		}
	}

	private readonly object repositoryObject = new object();

	private int bridgeObject;

	private Dictionary<Type, int> m_InvocationObject;

	private ListDecoratorEntry m_ClassObject;

	public string Serialize(object object_0)
	{
		if (object_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		lock (repositoryObject)
		{
			m_ClassObject = new ListDecoratorEntry();
			m_InvocationObject = new Dictionary<Type, int>();
			XDocument xDocument = new XDocument(CloneDispatcher("root", null, object_0));
			if (xDocument.Root != null)
			{
				xDocument.Root.AddFirst(PatchDispatcher());
			}
			string result = CustomizeDispatcher(xDocument);
			CountDispatcher();
			return result;
		}
	}

	private void CountDispatcher()
	{
		m_ClassObject.SelectInterruptibleMock();
		m_ClassObject = null;
	}

	private string CustomizeDispatcher(XDocument xdocument_0)
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		xdocument_0.Save(stringWriter);
		stringWriter.Flush();
		return stringWriter.ToString();
	}

	private XElement CloneDispatcher(string string_0, SerializeAttribute serializeAttribute_0, object object_0, params object[] content)
	{
		if (object_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		Type type = object_0.GetType();
		int num = m_ClassObject.ComputeInterruptibleMock(object_0);
		XElement xElement;
		if (num < 0)
		{
			xElement = ConnectDispatcher(string_0, object_0, serializeAttribute_0, content);
			if (serializeAttribute_0 != null && !(serializeAttribute_0.Formatter == null))
			{
				XElement xElement2 = xElement;
				object[] array2 = DeleteDispatcher(serializeAttribute_0.Formatter, object_0);
				object[] array = array2;
				object[] content2 = array;
				xElement2.Add(content2);
			}
			else if (type.IsPrimitive)
			{
				xElement.Add(new XAttribute("value", Convert.ToString(object_0, CultureInfo.InvariantCulture)));
			}
			else if (type.IsEnum)
			{
				xElement.Add(new XAttribute("value", object_0.ToString()));
			}
			else if (object_0 is string)
			{
				xElement.Add(new XAttribute("value", XmlHelper.EscapeInvalidCharacters((string)object_0)));
			}
			else if (typeof(IDictionary).IsAssignableFrom(type))
			{
				DestroyDispatcher(xElement, (IDictionary)object_0);
			}
			else if (!typeof(IList).IsAssignableFrom(type) && !typeof(ICollection).IsAssignableFrom(type))
			{
				if (type == typeof(DateTime))
				{
					xElement.Add(new XAttribute("value", Convert.ToString(object_0, CultureInfo.InvariantCulture)));
				}
				else if (type == typeof(Color))
				{
					xElement.Add(new XAttribute("value", ColorTranslator.ToHtml((Color)object_0)));
				}
				else if (type == typeof(PointF))
				{
					PointF pointF = (PointF)object_0;
					xElement.Add(new XAttribute("value", XmlHelper.EscapeInvalidCharacters(pointF.X + "|" + pointF.Y)));
				}
				else
				{
					SerializationMap serializationMap = SerializationMap.FromType(object_0.GetType());
					AddDispatcher(xElement, serializationMap.Members, object_0);
				}
			}
			else
			{
				ComputeDispatcher(xElement, (IEnumerable)object_0);
			}
			return xElement;
		}
		xElement = new XElement(string_0, content, new XAttribute("ref", num.ToString(CultureInfo.InvariantCulture)));
		if (serializeAttribute_0 != null && serializeAttribute_0.ConstructorArgumentIndex >= 0)
		{
			xElement.Add(new XAttribute("arg", serializeAttribute_0.ConstructorArgumentIndex));
		}
		return xElement;
	}

	private XElement ConnectDispatcher(string string_0, object object_0, SerializeAttribute serializeAttribute_0, params object[] content)
	{
		Type type = object_0.GetType();
		XElement xElement = new XElement(string_0, content);
		xElement.Add(new XAttribute("type", MoveDispatcher(type).ToString()));
		if (serializeAttribute_0 != null && serializeAttribute_0.ConstructorArgumentIndex >= 0)
		{
			xElement.Add(new XAttribute("arg", serializeAttribute_0.ConstructorArgumentIndex));
		}
		if (!type.IsValueType && !type.Equals(typeof(string)))
		{
			m_ClassObject.Add(object_0, xElement);
		}
		return xElement;
	}

	private int MoveDispatcher(Type type_0)
	{
		if (!m_InvocationObject.TryGetValue(type_0, out var value))
		{
			value = bridgeObject;
			m_InvocationObject[type_0] = value;
			bridgeObject++;
		}
		return value;
	}

	private XAttribute[] DeleteDispatcher(Type type_0, object object_0)
	{
		SerializationFormatter serializationFormatter = (SerializationFormatter)type_0.GetConstructor(Type.EmptyTypes).Invoke(null);
		return new XAttribute[2]
		{
			new XAttribute("value", XmlHelper.EscapeInvalidCharacters(serializationFormatter.ToString(object_0))),
			new XAttribute("formatter", MoveDispatcher(type_0).ToString())
		};
	}

	private void AddDispatcher(XElement xelement_0, IEnumerable<SerializationMapEntry> ienumerable_0, object object_0)
	{
		foreach (SerializationMapEntry item in ienumerable_0)
		{
			object value;
			if (item.Member is PropertyInfo)
			{
				value = ((PropertyInfo)item.Member).GetValue(object_0, null);
			}
			else
			{
				if (!(item.Member is FieldInfo))
				{
					throw new InvalidOperationException("Only fields and properties are supported.");
				}
				value = ((FieldInfo)item.Member).GetValue(object_0);
			}
			if (value != null)
			{
				string value2 = ((item.Attribute == null || string.IsNullOrEmpty(item.Attribute.Name)) ? item.Member.Name : item.Attribute.Name);
				XElement content = CloneDispatcher("member", item.Attribute, value, new XAttribute("name", value2));
				xelement_0.Add(content);
			}
		}
	}

	private void DestroyDispatcher(XElement xelement_0, IDictionary idictionary_0)
	{
		foreach (DictionaryEntry item in idictionary_0)
		{
			XElement content = new XElement("entry", CloneDispatcher("key", null, item.Key), CloneDispatcher("value", null, item.Value));
			xelement_0.Add(content);
		}
	}

	private void ComputeDispatcher(XElement xelement_0, IEnumerable ienumerable_0)
	{
		foreach (object item in ienumerable_0)
		{
			if (item != null)
			{
				xelement_0.Add(CloneDispatcher("item", null, item));
			}
		}
	}

	private XElement PatchDispatcher()
	{
		return new XElement("types", m_InvocationObject.Select((KeyValuePair<Type, int> keyValuePair_0) => new XElement("item", new XAttribute("key", keyValuePair_0.Value), new XAttribute("value", SelectDispatcher(keyValuePair_0.Key)))));
	}

	private string SelectDispatcher(Type type_0)
	{
		return Regex.Replace(type_0.AssemblyQualifiedName, ", Version=\\S+ Culture=\\S+ PublicKeyToken=null", string.Empty);
	}

	[CompilerGenerated]
	private XElement CallDispatcher(KeyValuePair<Type, int> keyValuePair_0)
	{
		return new XElement("item", new XAttribute("key", keyValuePair_0.Value), new XAttribute("value", SelectDispatcher(keyValuePair_0.Key)));
	}
}
