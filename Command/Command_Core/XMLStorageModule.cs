using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class XMLStorageModule
{
	public sealed class PersistentPointer
	{
		public string ObjectTypeID;

		public int ID;

		public override int GetHashCode()
		{
			return ObjectTypeID.GetHashCode() ^ ID;
		}
	}

	public sealed class TTailRecursion
	{
		public long Oid;

		public object Obj;

		public TTailRecursion(long long_0, ref object object_0)
		{
			Oid = long_0;
			Obj = RuntimeHelpers.GetObjectValue(object_0);
		}
	}

	[Serializable]
	public abstract class TestClassP
	{
		[NonSerialized]
		public bool IgnoreField;

		public double NonIgnoredField;

		protected TestClassP()
		{
			NonIgnoredField = 15.093;
		}
	}

	[Serializable]
	public sealed class TestClass : TestClassP
	{
		public double NonIgnoredField2;

		public TestClass()
		{
			NonIgnoredField2 = 16.2;
		}
	}

	private static ObjectIDGenerator tokenReader;

	private static Stack<TTailRecursion> m_IndexerReader;

	internal static bool StartDescriptor(string string_0, ref object object_0)
	{
		XmlWriter xmlWriter_ = null;
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		try
		{
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "\t";
			tokenReader = new ObjectIDGenerator();
			xmlWriter_ = XmlWriter.Create(string_0, xmlWriterSettings);
			xmlWriter_.WriteStartDocument();
			xmlWriter_.WriteStartElement("root");
			m_IndexerReader = new Stack<TTailRecursion>();
			xmlWriter_.WriteStartElement("content");
			DefineDescriptor(ref xmlWriter_, (Array)RuntimeHelpers.GetObjectValue(object_0), 0, bool_0: true);
			xmlWriter_.WriteEndElement();
			xmlWriter_.WriteStartElement("objects");
			while (m_IndexerReader.Count > 0)
			{
				TTailRecursion tTailRecursion = m_IndexerReader.Pop();
				PrintDescriptor(ref xmlWriter_, RuntimeHelpers.GetObjectValue(tTailRecursion.Obj), tTailRecursion.Oid, 0, bool_0: false);
			}
			xmlWriter_.WriteEndElement();
			xmlWriter_.Close();
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			exception_?.Data.Add("Error at 200065", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			xmlWriter_.WriteEndElement();
			xmlWriter_.Close();
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static void AssetDescriptor(ref XmlWriter xmlWriter_0, object object_0, int int_0, bool bool_0)
	{
		string ws = Strings.StrDup(int_0, "\t");
		xmlWriter_0.WriteWhitespace("\r\n");
		xmlWriter_0.WriteWhitespace(ws);
		if (object_0 == null)
		{
			xmlWriter_0.WriteElementString("NULL", "");
			return;
		}
		Type type = object_0.GetType();
		xmlWriter_0.WriteStartElement(type.Name);
		if (object.Equals(type, typeof(double)))
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");
			xmlWriter_0.WriteString(Conversions.ToDouble(object_0).ToString(cultureInfo));
		}
		else if (object.Equals(type, typeof(float)))
		{
			CultureInfo cultureInfo2 = new CultureInfo("en-US");
			xmlWriter_0.WriteString(Conversions.ToSingle(object_0).ToString(cultureInfo2));
		}
		else if (object.Equals(type, typeof(int)))
		{
			CultureInfo cultureInfo3 = new CultureInfo("en-US");
			xmlWriter_0.WriteString(Conversions.ToSingle(object_0).ToString(cultureInfo3));
		}
		else if (object.Equals(type, typeof(DateTime)))
		{
			CultureInfo cultureInfo4 = new CultureInfo("en-US");
			_ = cultureInfo4.DateTimeFormat;
			xmlWriter_0.WriteString(Conversions.ToDate(object_0).ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff'Z'", cultureInfo4));
		}
		else
		{
			xmlWriter_0.WriteString(object_0.ToString());
		}
		xmlWriter_0.WriteEndElement();
	}

	private static void PrintDescriptor(ref XmlWriter xmlWriter_0, object object_0, long long_0, int int_0, bool bool_0)
	{
		Type type = object_0.GetType();
		xmlWriter_0.WriteStartElement(type.Name);
		xmlWriter_0.WriteAttributeString("oid", long_0.ToString());
		FieldInfo[] fields = type.GetFields();
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), inherit: true);
			if (customAttributes == null || customAttributes.Length == 0)
			{
				string text = fieldInfo.ToString();
				int num = text.IndexOf(' ');
				text = text.Substring(num + 1, text.Length - num - 1);
				xmlWriter_0.WriteStartElement(text);
				DefineDescriptor(ref xmlWriter_0, (Array)RuntimeHelpers.GetObjectValue(fieldInfo.GetValue(RuntimeHelpers.GetObjectValue(object_0))), int_0 + 3, bool_0: true);
				xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 3, "\t"));
				xmlWriter_0.WriteEndElement();
			}
		}
		PropertyInfo[] properties = type.GetProperties();
		PropertyInfo[] array2 = properties;
		foreach (PropertyInfo propertyInfo in array2)
		{
			object[] customAttributes2 = propertyInfo.GetCustomAttributes(typeof(NonSerializedAttribute), inherit: true);
			if (customAttributes2 != null && customAttributes2.Length != 0)
			{
				continue;
			}
			string text2 = propertyInfo.ToString();
			int num2 = text2.IndexOf(' ');
			if (propertyInfo.GetIndexParameters().Length != 0)
			{
				continue;
			}
			text2 = text2.Substring(num2 + 1, text2.Length - num2 - 1);
			if (propertyInfo.PropertyType.IsArray)
			{
				Array array_ = (Array)propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(object_0), null);
				DefineDescriptor(ref xmlWriter_0, array_, int_0 + 3, bool_0: true);
				xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 3, "\t"));
				continue;
			}
			xmlWriter_0.WriteStartElement(text2);
			DefineDescriptor(ref xmlWriter_0, (Array)RuntimeHelpers.GetObjectValue(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(object_0), null)), int_0 + 3, bool_0: true);
			if (bool_0)
			{
				xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 1, "\t"));
			}
			else
			{
				xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 3, "\t"));
			}
			xmlWriter_0.WriteEndElement();
		}
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.Flush();
	}

	private unsafe static void DefineDescriptor(ref XmlWriter xmlWriter_0, Array array_0, int int_0, bool bool_0)
	{
		string text = Strings.StrDup(int_0, "\t");
		if (!bool_0)
		{
			xmlWriter_0.WriteWhitespace("\r\n" + text);
		}
		if (array_0 == null)
		{
			xmlWriter_0.WriteElementString("NULL", "");
			return;
		}
		Type type = array_0.GetType();
		if (type.IsArray)
		{
			Type elementType = type.GetElementType();
			xmlWriter_0.WriteStartElement("Array");
			xmlWriter_0.WriteAttributeString("type", elementType.Name);
			Array array = array_0;
			xmlWriter_0.WriteAttributeString("size", array.Length.ToString());
			IEnumerator enumerator = null;
			try
			{
				enumerator = array.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object object_ = RuntimeHelpers.GetObjectValue(enumerator.Current);
					if (object_.GetType().IsValueType | ((object)object_.GetType() == typeof(string)))
					{
						AssetDescriptor(ref xmlWriter_0, RuntimeHelpers.GetObjectValue(object_), int_0 + 3, bool_0: true);
						continue;
					}
					bool firstTime;
					long id = tokenReader.GetId(RuntimeHelpers.GetObjectValue(object_), out firstTime);
					xmlWriter_0.WriteStartElement(object_.GetType().Name);
					xmlWriter_0.WriteAttributeString("ref", id.ToString());
					xmlWriter_0.WriteEndElement();
					if (firstTime)
					{
						m_IndexerReader.Push(new TTailRecursion(id, ref object_));
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			xmlWriter_0.WriteWhitespace("\r\n" + text + "\t\t");
			xmlWriter_0.WriteEndElement();
		}
		else if (type.IsValueType | ((object)type == typeof(string)))
		{
			AssetDescriptor(ref xmlWriter_0, RuntimeHelpers.GetObjectValue(array_0), int_0 + 1, bool_0: false);
		}
		else if (type.IsPointer | type.IsByRef | type.IsClass)
		{
			bool firstTime2;
			long id2 = tokenReader.GetId(RuntimeHelpers.GetObjectValue(array_0), out firstTime2);
			xmlWriter_0.WriteStartElement(array_0.GetType().Name);
			xmlWriter_0.WriteAttributeString("ref", id2.ToString());
			xmlWriter_0.WriteEndElement();
			if (firstTime2)
			{
				m_IndexerReader.Push(new TTailRecursion(id2, ref *(object*)(&array_0)));
			}
		}
		xmlWriter_0.Flush();
	}

	public static void LoadObjectFromXML(ref object object_0, string string_0)
	{
		try
		{
			TreeNode treeNode = null;
			TreeNode treeNode2 = null;
			new Dictionary<long, object>();
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
			xmlReaderSettings.ProhibitDtd = true;
			xmlReaderSettings.XmlResolver = null;
			xmlReaderSettings.IgnoreComments = true;
			xmlReaderSettings.IgnoreProcessingInstructions = true;
			TextReader textReader = new StreamReader(string_0);
			XmlReader xmlReader = XmlReader.Create(textReader, xmlReaderSettings);
			xmlReader.MoveToContent();
			while (xmlReader.Read())
			{
				switch (xmlReader.NodeType)
				{
				case XmlNodeType.EndElement:
					treeNode = treeNode.Parent;
					break;
				case XmlNodeType.Text:
					treeNode2.ToolTipText = xmlReader.Value;
					break;
				case XmlNodeType.Element:
					treeNode2 = new TreeNode(xmlReader.Name);
					if (xmlReader.HasAttributes)
					{
						while (xmlReader.MoveToNextAttribute())
						{
						}
						xmlReader.MoveToElement();
					}
					treeNode.Nodes.Add(treeNode2);
					treeNode = (xmlReader.IsEmptyElement ? treeNode : treeNode2);
					break;
				}
			}
			xmlReader.Close();
			textReader.Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal static object PublishDescriptor(ref XmlReader xmlReader_0)
	{
		xmlReader_0.ReadElementContentAsString();
		xmlReader_0.GetAttribute("ref");
		return null;
	}
}
