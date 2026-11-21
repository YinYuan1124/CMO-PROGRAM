using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.SendFileTo;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class CustomExceptionHandler
{
	public void OnThreadException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
	{
		if (ItemExporter.ConnectInterruptibleTemplate.DebugForm.isInitialised())
		{
			try
			{
				e.ExitApplication = false;
				ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write("OnThreadException");
				Exception exception = e.Exception;
				if (exception == null)
				{
					ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write("theEx == null");
				}
				else
				{
					ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write("theEx != null");
				}
				ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write("e.Exception.GetType().Name: " + e.Exception.GetType().Name);
				ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write("theEx.Message: " + exception.Message);
				ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write("theEx.StackTrace: " + exception.StackTrace);
				if (!Information.IsNothing(exception.InnerException))
				{
					ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write("theEx.InnerException.GetType().Name: " + exception.InnerException.GetType().Name);
				}
				if (Information.IsNothing(GameGeneral.CatastrophicCoreException))
				{
					e.ExitApplication = false;
				}
				else
				{
					string text = "This is probably a bug. Please save a screenshot of this and submit it, along with the autosave files, for investigation.\r\n\r\nException: " + exception.Message + "\r\n\r\nStack Trace: " + exception.StackTrace + "\r\n\r\n";
					if (!Information.IsNothing(exception.InnerException))
					{
						text = text + "内部异常：" + exception.InnerException.Message + "\r\n\r\nInner StackTrace: " + exception.InnerException.StackTrace + "\r\n\r\n";
					}
					if (exception.Data.Count > 0)
					{
						text += "调用堆栈和错误详细信息：";
						IDictionaryEnumerator enumerator = exception.Data.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object current = enumerator.Current;
							DictionaryEntry dictionaryEntry = ((current == null) ? default(DictionaryEntry) : ((DictionaryEntry)current));
							text = text + "\r\n" + Conversions.ToString(dictionaryEntry.Key) + ", " + Conversions.ToString(dictionaryEntry.Value);
						}
					}
					ItemExporter.ConnectInterruptibleTemplate.DebugForm.Write(text);
					e.ExitApplication = false;
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				DestroyPublisher(exception_);
				ProjectData.ClearProjectError();
				return;
			}
		}
		Exception exception2 = e.Exception;
		DestroyPublisher(exception2);
	}

	private void DestroyPublisher(Exception exception_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Error in Exception Handler! OnThreadException\r\n");
		if (exception_0 == null)
		{
			stringBuilder.Append("Error in Exception Handler! theEx == null\r\n");
		}
		else
		{
			stringBuilder.Append("Error in Exception Handler! theEx != null\r\n");
		}
		stringBuilder.Append("Error in Exception Handler! e.Exception.GetType().Name: " + exception_0.GetType().Name + "\r\n");
		stringBuilder.Append("Error in Exception Handler! theEx.Message: " + exception_0.Message + "\r\n");
		stringBuilder.Append("Error in Exception Handler! theEx.StackTrace: " + exception_0.StackTrace + "\r\n");
		if (!Information.IsNothing(exception_0.InnerException))
		{
			stringBuilder.Append("Error in Exception Handler! theEx.InnerException.GetType().Name: " + exception_0.InnerException.GetType().Name + "\r\n");
		}
		string text = "Error in Exception Handler! This is probably a Error in Exception Handler!. Please save a screenshot of this and submit it, along with the autosave files, for investigation.\r\n\r\nException: " + exception_0.Message + "\r\n\r\nStack Trace: " + exception_0.StackTrace + "\r\n\r\n";
		if (!Information.IsNothing(exception_0.InnerException))
		{
			text = text + "内部异常：" + exception_0.InnerException.Message + "\r\n\r\nInner StackTrace: " + exception_0.InnerException.StackTrace + "\r\n\r\n";
		}
		if (exception_0.Data.Count > 0)
		{
			text += "调用堆栈和错误详细信息：";
			IDictionaryEnumerator enumerator = exception_0.Data.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				DictionaryEntry dictionaryEntry = ((current == null) ? default(DictionaryEntry) : ((DictionaryEntry)current));
				text = text + "\r\n" + Conversions.ToString(dictionaryEntry.Key) + ", " + Conversions.ToString(dictionaryEntry.Value);
			}
		}
		stringBuilder.Append(text);
		MessageBox.Show(stringBuilder.ToString());
		GameGeneral.WriteLogDebugInfoToFile(stringBuilder.ToString());
	}

	private void ComputePublisher(Exception exception_0)
	{
		new StringBuilder();
		MAPI mAPI = new MAPI();
		mAPI.AddAttachment("c:\\\\temp\\\\file1.txt");
		mAPI.AddAttachment("c:\\\\temp\\\\file2.txt");
		mAPI.RegisterDescriptor("person1@somewhere.com");
		mAPI.RegisterDescriptor("person2@somewhere.com");
		mAPI.CountList("testing", "body text");
	}
}
