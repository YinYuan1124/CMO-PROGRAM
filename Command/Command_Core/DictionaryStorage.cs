using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DictionaryStorage
{
	public static void smethod_0<TKey, TValue>(XmlWriter xmlWriter_0, Dictionary<TKey, TValue> dictionary_0)
	{
		try
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");
			xmlWriter_0.WriteStartElement("Dictionary");
			xmlWriter_0.WriteAttributeString("keyType", typeof(TKey).Name);
			xmlWriter_0.WriteAttributeString("valueType", typeof(TValue).Name);
			string name = typeof(TValue).Name;
			foreach (KeyValuePair<TKey, TValue> item in dictionary_0)
			{
				xmlWriter_0.WriteStartElement(name);
				if ((object)typeof(TKey) == typeof(double))
				{
					xmlWriter_0.WriteAttributeString("Key", Conversions.ToDouble(item.Key).ToString(cultureInfo));
				}
				else
				{
					xmlWriter_0.WriteAttributeString("Key", item.Key.ToString());
				}
				if ((object)typeof(TValue) == typeof(double))
				{
					xmlWriter_0.WriteString(Conversions.ToDouble(item.Value).ToString(cultureInfo));
				}
				else
				{
					xmlWriter_0.WriteString(item.Value.ToString());
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200084", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà ñîõðàíåíèÿ àññîöèàòèâíîãî ìàññèâà â ôàéë");
		}
	}

	public static void SaveDictionaryToXML_2<TKey, TValue>(XmlWriter xmlWriter_0, Dictionary<TKey, TValue> dictionary_0) where TValue : IXmlSerializable
	{
		try
		{
			xmlWriter_0.WriteStartElement("Dictionary");
			xmlWriter_0.WriteAttributeString("keyType", typeof(TKey).Name);
			xmlWriter_0.WriteAttributeString("valueType", typeof(TValue).Name);
			string name = typeof(TValue).Name;
			foreach (KeyValuePair<TKey, TValue> item in dictionary_0)
			{
				xmlWriter_0.WriteStartElement(name);
				xmlWriter_0.WriteAttributeString("Key", item.Key.ToString());
				item.Value.WriteXml(xmlWriter_0);
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200085", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà ñîõðàíåíèÿ àññîöèàòèâíîãî ìàññèâà â ôàéë");
		}
	}

	public static void LoadDictionaryFromXML<TKey, TValue>(XmlReader xmlReader_0, ref Dictionary<TKey, TValue> dictionary_0)
	{
		try
		{
			if (xmlReader_0.ReadToFollowing("Dictionary"))
			{
				if (Operators.CompareString(xmlReader_0.GetAttribute("keyType"), typeof(TKey).Name, TextCompare: false) == 0)
				{
					string name = typeof(TValue).Name;
					if (Operators.CompareString(xmlReader_0.GetAttribute("valueType"), typeof(TValue).Name, TextCompare: false) == 0)
					{
						Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
						if (xmlReader_0.IsEmptyElement)
						{
							if (dictionary_0 == null)
							{
								dictionary_0 = new Dictionary<TKey, TValue>();
							}
							dictionary_0.Clear();
							return;
						}
						TKey gparam_ = default(TKey);
						TValue gparam_2 = default(TValue);
						while (xmlReader_0.ReadToFollowing(name))
						{
							smethod_1(xmlReader_0, ref gparam_, ref gparam_2);
							dictionary.Add((TKey)(object)gparam_, gparam_2);
						}
						if (dictionary_0 == null)
						{
							dictionary_0 = new Dictionary<TKey, TValue>();
						}
						dictionary_0.Clear();
						{
							foreach (KeyValuePair<TKey, TValue> item in dictionary)
							{
								dictionary_0.Add(item.Key, item.Value);
							}
							return;
						}
					}
					throw new Exception("value types don't match");
				}
				throw new Exception("key types don't match");
			}
			throw new Exception("dictionary node not found");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200086", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà çàãðóçêè àññîöèàòèâíîãî ìàññèâà èç ôàéëà");
		}
	}

	public static void smethod_1<TKey, TValue>(XmlReader xmlReader_0, ref TKey gparam_0, ref TValue gparam_1)
	{
		CultureInfo provider = new CultureInfo("en-US");
		string attribute = xmlReader_0.GetAttribute("Key");
		if ((object)typeof(TKey) == typeof(double))
		{
			gparam_0 = (TKey)(object)double.Parse(attribute, provider);
		}
		else
		{
			gparam_0 = (TKey)(object)attribute;
		}
		xmlReader_0.MoveToContent();
		if ((object)typeof(TValue) == typeof(double))
		{
			gparam_1 = (TValue)(object)double.Parse(xmlReader_0.ReadString(), provider);
		}
		else
		{
			gparam_1 = (TValue)(object)xmlReader_0.ReadString();
		}
	}

	public static void KeyValuePairReadXML_2<TKey, TValue>(XmlReader xmlReader_0, ref TKey gparam_0, ref TValue gparam_1) where TValue : IXmlSerializable, new()
	{
		string attribute = xmlReader_0.GetAttribute("Key");
		gparam_0 = (TKey)(object)attribute;
		TValue val = new TValue();
		xmlReader_0.MoveToContent();
		val.ReadXml(xmlReader_0);
		gparam_1 = val;
	}

	public static void LoadDictionaryFromXML_2<TKey, TValue>(XmlReader xmlReader_0, ref Dictionary<TKey, TValue> dictionary_0) where TValue : IXmlSerializable, new()
	{
		try
		{
			if (xmlReader_0.ReadToFollowing("Dictionary"))
			{
				if (Operators.CompareString(xmlReader_0.GetAttribute("keyType"), typeof(TKey).Name, TextCompare: false) == 0)
				{
					string name = typeof(TValue).Name;
					if (Operators.CompareString(xmlReader_0.GetAttribute("valueType"), typeof(TValue).Name, TextCompare: false) == 0)
					{
						Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
						if (xmlReader_0.IsEmptyElement)
						{
							if (dictionary_0 == null)
							{
								dictionary_0 = new Dictionary<TKey, TValue>();
							}
							dictionary_0.Clear();
							return;
						}
						TKey gparam_ = default(TKey);
						TValue gparam_2 = default(TValue);
						while (xmlReader_0.ReadToFollowing(name))
						{
							KeyValuePairReadXML_2(xmlReader_0, ref gparam_, ref gparam_2);
							dictionary.Add((TKey)(object)gparam_, gparam_2);
						}
						if (dictionary_0 == null)
						{
							dictionary_0 = new Dictionary<TKey, TValue>();
						}
						dictionary_0.Clear();
						{
							foreach (KeyValuePair<TKey, TValue> item in dictionary)
							{
								dictionary_0.Add(item.Key, item.Value);
							}
							return;
						}
					}
					throw new Exception("value types don't match");
				}
				throw new Exception("key types don't match");
			}
			throw new Exception("dictionary node not found");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200087", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà çàãðóçêè àññîöèàòèâíîãî ìàññèâà èç ôàéëà");
		}
	}
}
