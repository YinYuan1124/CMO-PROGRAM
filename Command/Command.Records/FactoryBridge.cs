using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using CSMaterial;
using Command.Listeners;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Records;

[StandardModule]
internal sealed class FactoryBridge
{
	private struct EventMerchantService
	{
		private byte _ExpressionMap;

		private byte _DispatcherMap;

		private byte listenerMap;

		private byte configMap;

		public EventMerchantService(byte byte_0, byte byte_1, byte byte_2, byte byte_3)
		{
			this = default(EventMerchantService);
			_ExpressionMap = byte_0;
			_DispatcherMap = byte_1;
			listenerMap = byte_2;
			configMap = byte_3;
		}
	}

	[DllImport("GDI32.DLL", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern bool GdiAlphaBlend(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, int int_6, int int_7, EventMerchantService eventMerchantService_0);

	public static bool ConnectContext(IntPtr intptr_0, object object_0, int int_0, int int_1, int int_2, int int_3)
	{
		bool result = false;
		try
		{
			if (((Image)object_0).Width != int_2 || ((Image)object_0).Height != int_3)
			{
				object_0 = InterpreterObjectListener.ListInterruptibleTask((Image)object_0, new Size(int_2, int_3), bool_0: false);
			}
			IntPtr intPtr = Win32Support.CreateCompatibleDC(intptr_0);
			if (!Client.Cache_GDIBitmapHandles.TryGetValue((Image)object_0, out var value))
			{
				value = ((Bitmap)object_0).GetHbitmap(Color.Black);
				Client.Cache_GDIBitmapHandles.Add((Image)object_0, value);
			}
			IntPtr intptr_ = Win32Support.SelectObject(intPtr, value);
			result = GdiAlphaBlend(intptr_0, int_0, int_1, ((Image)object_0).Width, ((Image)object_0).Height, intPtr, 0, 0, ((Image)object_0).Width, ((Image)object_0).Height, new EventMerchantService(0, 0, byte.MaxValue, 1));
			Win32Support.SelectObject(intPtr, intptr_);
			Win32Support.DeleteDC(intPtr);
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
