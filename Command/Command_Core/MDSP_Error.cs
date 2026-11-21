using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class MDSP_Error
{
	[ThreadStatic]
	private static StringBuilder _MerchantConsumer;

	public string Mission;

	public string Flight;

	public string Message;

	public MDSP_Error()
	{
	}

	public MDSP_Error(string string_0, string string_1, string string_2)
	{
		Mission = string_0;
		Flight = string_1;
		Message = string_2;
	}

	public string ToXML(HashSet<string> hashSet_0)
	{
		try
		{
			if (_MerchantConsumer == null)
			{
				_MerchantConsumer = new StringBuilder();
			}
			else
			{
				_MerchantConsumer.Clear();
			}
			_MerchantConsumer.Append("<MDSP_Error>");
			if (Operators.CompareString(Mission, string.Empty, TextCompare: false) != 0)
			{
				_MerchantConsumer.Append("<Mission>").Append(Mission).Append("</Mission>");
			}
			if (Operators.CompareString(Flight, string.Empty, TextCompare: false) != 0)
			{
				_MerchantConsumer.Append("<Flight>").Append(Flight).Append("</Flight>");
			}
			if (Operators.CompareString(Message, string.Empty, TextCompare: false) != 0)
			{
				_MerchantConsumer.Append("<Message>").Append(Message).Append("</Message>");
			}
			_MerchantConsumer.Append("</MDSP_Error>");
			return _MerchantConsumer.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1345145151451", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static MDSP_Error FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		MDSP_Error mDSP_Error = new MDSP_Error();
		try
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Mission":
						mDSP_Error.Mission = xmlNode.InnerText;
						break;
					case "Message":
						mDSP_Error.Message = xmlNode.InnerText;
						break;
					case "Flight":
						mDSP_Error.Flight = xmlNode.InnerText;
						break;
					default:
						return InvokeRequest(xmlNode.InnerText);
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
			return mDSP_Error;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1312312314515", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static MDSP_Error InvokeRequest(string string_0)
	{
		MDSP_Error mDSP_Error = new MDSP_Error();
		try
		{
			int num = string_0.IndexOf("! Mission") + 9;
			int num2 = string_0.IndexOf(", Flight") + 9;
			int num3 = string_0.IndexOf(":");
			if (num >= 0 && num2 > num)
			{
				mDSP_Error.Mission = string_0.Substring(num, num2 - num);
			}
			if (num2 >= 0 && num3 > num2)
			{
				mDSP_Error.Flight = string_0.Substring(num2, num3 - num2);
			}
			mDSP_Error.Message = string_0;
			return mDSP_Error;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return mDSP_Error;
		}
	}
}
