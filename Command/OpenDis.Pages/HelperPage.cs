using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace OpenDis.Pages;

internal class HelperPage
{
	internal enum PowerLineStatus : byte
	{
		Battery = 0,
		AC = 1,
		Unknown = byte.MaxValue
	}

	private class OrderDecoratorEntry
	{
		[Flags]
		private enum Enum0 : byte
		{

		}

		private struct WriterMapping
		{
			internal PowerLineStatus specificationMapping;

			internal Enum0 m_WatcherMapping;

			internal byte _ReponseMapping;

			internal byte descriptorMapping;

			internal uint poolMapping;

			internal uint taskMapping;
		}

		[DllImport("kernel32")]
		private static extern bool GetSystemPowerStatus(out WriterMapping writerMapping_0);

		public static PowerLineStatus ValidateInterruptibleTemplate()
		{
			if (GetSystemPowerStatus(out var writerMapping_))
			{
				return writerMapping_.specificationMapping;
			}
			return PowerLineStatus.Unknown;
		}

		public static int LoginInterruptibleTemplate()
		{
			if (GetSystemPowerStatus(out var writerMapping_))
			{
				return writerMapping_._ReponseMapping;
			}
			return -1;
		}
	}

	private int m_CandidateMerchant;

	private bool m_BaseMerchant;

	private ManualResetEvent m_PolicyMerchant;

	[CompilerGenerated]
	private Action<PowerLineStatus> m_BroadcasterMerchant;

	[CompilerGenerated]
	private Action<int> m_IdentifierMerchant;

	public event Action<PowerLineStatus> CompareMerchant
	{
		[CompilerGenerated]
		add
		{
			Action<PowerLineStatus> action = m_BroadcasterMerchant;
			Action<PowerLineStatus> action2;
			do
			{
				action2 = action;
				Action<PowerLineStatus> value2 = (Action<PowerLineStatus>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref m_BroadcasterMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<PowerLineStatus> action = m_BroadcasterMerchant;
			Action<PowerLineStatus> action2;
			do
			{
				action2 = action;
				Action<PowerLineStatus> value2 = (Action<PowerLineStatus>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref m_BroadcasterMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public event Action<int> InsertMerchant
	{
		[CompilerGenerated]
		add
		{
			Action<int> action = m_IdentifierMerchant;
			Action<int> action2;
			do
			{
				action2 = action;
				Action<int> value2 = (Action<int>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref m_IdentifierMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<int> action = m_IdentifierMerchant;
			Action<int> action2;
			do
			{
				action2 = action;
				Action<int> value2 = (Action<int>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref m_IdentifierMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public HelperPage()
	{
		m_PolicyMerchant = new ManualResetEvent(initialState: true);
		m_BaseMerchant = false;
		m_CandidateMerchant = 0;
		SystemEvents.PowerModeChanged += FindMerchant;
		Application.ApplicationExit += InitMerchant;
		ThreadPool.QueueUserWorkItem(delegate
		{
			CheckMerchant();
		});
	}

	private void InitMerchant(object sender, EventArgs e)
	{
		m_BaseMerchant = true;
	}

	private void CheckMerchant()
	{
		while (!m_BaseMerchant)
		{
			m_PolicyMerchant.WaitOne(30000);
			m_PolicyMerchant.Reset();
			try
			{
				InterruptMerchant();
			}
			catch (Exception)
			{
			}
		}
	}

	internal void ConcatMerchant()
	{
		m_PolicyMerchant.Set();
	}

	private void InterruptMerchant()
	{
		int num = 0;
		if (OrderDecoratorEntry.ValidateInterruptibleTemplate() == PowerLineStatus.Battery)
		{
			num = OrderDecoratorEntry.LoginInterruptibleTemplate();
			if (num != -1 && num != m_CandidateMerchant)
			{
				RemoveMerchant(num);
				m_CandidateMerchant = num;
			}
		}
	}

	private void RemoveMerchant(int int_0)
	{
		if (m_IdentifierMerchant != null)
		{
			m_IdentifierMerchant(int_0);
		}
	}

	private void FindMerchant(object sender, PowerModeChangedEventArgs e)
	{
		if (m_BroadcasterMerchant != null)
		{
			m_BroadcasterMerchant((PowerLineStatus)e.Mode);
		}
		if (OrderDecoratorEntry.ValidateInterruptibleTemplate() == PowerLineStatus.Battery)
		{
			ConcatMerchant();
		}
	}

	internal static PowerLineStatus SetMerchant()
	{
		return OrderDecoratorEntry.ValidateInterruptibleTemplate();
	}

	[CompilerGenerated]
	private void CalculateMerchant(object object_0)
	{
		CheckMerchant();
	}
}
