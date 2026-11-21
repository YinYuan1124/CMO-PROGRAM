using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace OpenDis.Resolver;

internal class IdentifierProcessResolver
{
	internal enum HKeyEnum
	{
		LocalMachine
	}

	private class ProxyListenerMapping
	{
		private IntPtr parserExporter;

		private IntPtr m_AlgoExporter;

		private bool _DatabaseExporter;

		[CompilerGenerated]
		private Action interceptorExporter;

		[DllImport("kernel32.dll")]
		private static extern IntPtr CreateEvent(IntPtr intptr_0, bool bool_0, bool bool_1, string string_0);

		[DllImport("advapi32.dll")]
		private static extern IntPtr RegOpenKey(IntPtr intptr_0, string string_0, out IntPtr intptr_1);

		[DllImport("advapi32.dll")]
		private static extern long RegNotifyChangeKeyValue(IntPtr intptr_0, bool bool_0, int int_0, IntPtr intptr_1, bool bool_1);

		[DllImport("kernel32.dll")]
		private static extern long WaitForSingleObject(IntPtr intptr_0, int int_0);

		[DllImport("kernel32.dll")]
		private static extern IntPtr CloseHandle(IntPtr intptr_0);

		[SpecialName]
		[CompilerGenerated]
		internal void method_0(Action action_0)
		{
			Action action = interceptorExporter;
			Action action2;
			do
			{
				action2 = action;
				Action value = (Action)Delegate.Combine(action2, action_0);
				action = Interlocked.CompareExchange(ref interceptorExporter, value, action2);
			}
			while ((object)action != action2);
		}

		[SpecialName]
		[CompilerGenerated]
		internal void method_1(Action action_0)
		{
			Action action = interceptorExporter;
			Action action2;
			do
			{
				action2 = action;
				Action value = (Action)Delegate.Remove(action2, action_0);
				action = Interlocked.CompareExchange(ref interceptorExporter, value, action2);
			}
			while ((object)action != action2);
		}

		internal unsafe ProxyListenerMapping(long long_0, string string_0, bool bool_0)
		{
			_DatabaseExporter = bool_0;
			m_AlgoExporter = CreateEvent((IntPtr)(void*)null, bool_0: false, bool_1: false, null);
			RegOpenKey(new IntPtr((int)long_0), string_0, out parserExporter);
			CreateInterruptibleTemplate();
		}

		private void CreateInterruptibleTemplate()
		{
			RegNotifyChangeKeyValue(parserExporter, _DatabaseExporter, 5, m_AlgoExporter, bool_1: true);
		}

		internal void CompareInterruptibleTemplate()
		{
			WaitForSingleObject(m_AlgoExporter, -1);
			ReadInterruptibleTemplate();
			CreateInterruptibleTemplate();
		}

		private void ReadInterruptibleTemplate()
		{
			if (interceptorExporter != null)
			{
				interceptorExporter();
			}
		}
	}

	private bool factoryMerchant;

	private ProxyListenerMapping m_AttributeMerchant;

	[CompilerGenerated]
	private Action eventMerchant;

	internal event Action ComputeCallback
	{
		[CompilerGenerated]
		add
		{
			Action action = eventMerchant;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref eventMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = eventMerchant;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref eventMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public IdentifierProcessResolver(HKeyEnum hkeyEnum_0, string string_0, bool bool_0)
	{
		m_AttributeMerchant = new ProxyListenerMapping((hkeyEnum_0 == HKeyEnum.LocalMachine) ? 2147483650u : 0, string_0, bool_0);
		Application.ApplicationExit += CustomizeCallback;
		ThreadPool.QueueUserWorkItem(delegate
		{
			ConnectCallback();
		});
	}

	private void CustomizeCallback(object sender, EventArgs e)
	{
		factoryMerchant = true;
	}

	private void CloneCallback()
	{
		if (eventMerchant != null)
		{
			eventMerchant();
		}
	}

	private void ConnectCallback()
	{
		while (!factoryMerchant)
		{
			try
			{
				m_AttributeMerchant.CompareInterruptibleTemplate();
				CloneCallback();
			}
			catch (Exception)
			{
			}
		}
	}

	[CompilerGenerated]
	private void MoveCallback(object object_0)
	{
		ConnectCallback();
	}
}
