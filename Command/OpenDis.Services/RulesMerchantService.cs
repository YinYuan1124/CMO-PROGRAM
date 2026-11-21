using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace OpenDis.Services;

internal class RulesMerchantService : IDisposable
{
	public enum PowerSavingLevelEnum
	{
		Max,
		Min,
		Typical,
		Unkown
	}

	private class PageExporter
	{
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		internal struct FilterMapping
		{
			public Guid testsMapping;

			public int _InterpreterMapping;
		}

		[Flags]
		public enum EXECUTION_STATE : uint
		{
			ES_SYSTEM_REQUIRED = 1u,
			ES_DISPLAY_REQUIRED = 2u,
			ES_CONTINUOUS = 0x80000000u
		}

		internal static Guid _RulesExporter;

		internal static Guid _MethodExporter;

		internal static Guid m_ServiceExporter;

		private IntPtr m_SystemExporter;

		[CompilerGenerated]
		private Action<Guid> candidateExporter;

		private IntPtr baseExporter;

		private Guid _PolicyExporter = new Guid("A7AD8041-B45A-4CAE-87A3-EECBB468A9E1");

		private Guid broadcasterExporter = new Guid(41095189, 17680, 17702, 153, 230, 229, 161, 126, 189, 26, 234);

		private Guid m_IdentifierExporter = new Guid(1564383833u, 59861, 19200, 166, 189, byte.MaxValue, 52, byte.MaxValue, 81, 101, 72);

		private Guid _PrinterExporter = new Guid(610108737, 14659, 17442, 176, 37, 19, 167, 132, 246, 121, 183);

		[SpecialName]
		[CompilerGenerated]
		public void method_0(Action<Guid> action_0)
		{
			Action<Guid> action = candidateExporter;
			Action<Guid> action2;
			do
			{
				action2 = action;
				Action<Guid> value = (Action<Guid>)Delegate.Combine(action2, action_0);
				action = Interlocked.CompareExchange(ref candidateExporter, value, action2);
			}
			while ((object)action != action2);
		}

		[SpecialName]
		[CompilerGenerated]
		public void method_1(Action<Guid> action_0)
		{
			Action<Guid> action = candidateExporter;
			Action<Guid> action2;
			do
			{
				action2 = action;
				Action<Guid> value = (Action<Guid>)Delegate.Remove(action2, action_0);
				action = Interlocked.CompareExchange(ref candidateExporter, value, action2);
			}
			while ((object)action != action2);
		}

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr RegisterPowerSettingNotification(IntPtr intptr_0, ref Guid guid_0, int int_0);

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern bool UnregisterPowerSettingNotification(IntPtr intptr_0);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE execution_STATE_0);

		public PageExporter(IntPtr intptr_0)
		{
			baseExporter = intptr_0;
		}

		public void InitInterruptibleTemplate()
		{
			m_SystemExporter = RegisterPowerSettingNotification(baseExporter, ref _PrinterExporter, 0);
		}

		public void CheckInterruptibleTemplate()
		{
			UnregisterPowerSettingNotification(m_SystemExporter);
		}

		public bool ConcatInterruptibleTemplate(ref Message message_0)
		{
			if (message_0.Msg == 536)
			{
				InterruptInterruptibleTemplate(ref message_0);
				return true;
			}
			return false;
		}

		private void InterruptInterruptibleTemplate(ref Message message_0)
		{
			if ((int)message_0.WParam == 32787)
			{
				RemoveInterruptibleTemplate(ref message_0);
			}
		}

		private void RemoveInterruptibleTemplate(ref Message message_0)
		{
			FilterMapping filterMapping = (FilterMapping)Marshal.PtrToStructure(message_0.LParam, typeof(FilterMapping));
			IntPtr intptr_ = (IntPtr)((int)message_0.LParam + Marshal.SizeOf(filterMapping));
			if (filterMapping.testsMapping == _PrinterExporter)
			{
				FindInterruptibleTemplate(filterMapping, intptr_);
			}
		}

		private void FindInterruptibleTemplate(FilterMapping filterMapping_0, IntPtr intptr_0)
		{
			if (filterMapping_0._InterpreterMapping == Marshal.SizeOf(typeof(Guid)))
			{
				Guid obj = (Guid)Marshal.PtrToStructure(intptr_0, typeof(Guid));
				if (candidateExporter != null)
				{
					candidateExporter(obj);
				}
			}
		}

		static PageExporter()
		{
			_RulesExporter = new Guid(2709787400u, 13633, 20395, 188, 129, 247, 21, 86, 242, 11, 74);
			_MethodExporter = new Guid(2355003354u, 59583, 19094, 154, 133, 166, 226, 58, 140, 99, 92);
			m_ServiceExporter = new Guid(941310498u, 63124, 16880, 150, 133, byte.MaxValue, 91, 178, 96, 223, 46);
		}
	}

	[CompilerGenerated]
	private Action<PowerSavingLevelEnum> m_IteratorMerchant;

	private PageExporter _InitializerMerchant;

	private bool m_RoleMerchant;

	internal event Action<PowerSavingLevelEnum> CountCallback
	{
		[CompilerGenerated]
		add
		{
			Action<PowerSavingLevelEnum> action = m_IteratorMerchant;
			Action<PowerSavingLevelEnum> action2;
			do
			{
				action2 = action;
				Action<PowerSavingLevelEnum> value2 = (Action<PowerSavingLevelEnum>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref m_IteratorMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<PowerSavingLevelEnum> action = m_IteratorMerchant;
			Action<PowerSavingLevelEnum> action2;
			do
			{
				action2 = action;
				Action<PowerSavingLevelEnum> value2 = (Action<PowerSavingLevelEnum>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref m_IteratorMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public RulesMerchantService(Form form_0)
	{
		_InitializerMerchant = new PageExporter(form_0.Handle);
		_InitializerMerchant.method_0(CalcMerchant);
		m_RoleMerchant = false;
		ForgotMerchant();
	}

	private void CalcMerchant(Guid guid_0)
	{
		PowerSavingLevelEnum powerSavingLevelEnum_ = PowerSavingLevelEnum.Unkown;
		if (m_IteratorMerchant != null)
		{
			if (guid_0 == PageExporter._RulesExporter)
			{
				powerSavingLevelEnum_ = PowerSavingLevelEnum.Max;
			}
			else if (guid_0 == PageExporter._MethodExporter)
			{
				powerSavingLevelEnum_ = PowerSavingLevelEnum.Min;
			}
			else if (guid_0 == PageExporter.m_ServiceExporter)
			{
				powerSavingLevelEnum_ = PowerSavingLevelEnum.Typical;
			}
			RateMerchant(powerSavingLevelEnum_);
		}
	}

	private void RateMerchant(PowerSavingLevelEnum powerSavingLevelEnum_0)
	{
		if (m_IteratorMerchant != null)
		{
			m_IteratorMerchant(powerSavingLevelEnum_0);
		}
	}

	public bool FlushMerchant(ref Message message_0)
	{
		if (m_RoleMerchant)
		{
			return _InitializerMerchant.ConcatInterruptibleTemplate(ref message_0);
		}
		return false;
	}

	private void ForgotMerchant()
	{
		if (!m_RoleMerchant)
		{
			_InitializerMerchant.InitInterruptibleTemplate();
			m_RoleMerchant = true;
		}
	}

	public void CollectMerchant()
	{
		if (m_RoleMerchant)
		{
			_InitializerMerchant.CheckInterruptibleTemplate();
			m_RoleMerchant = false;
		}
	}

	void IDisposable.Dispose()
	{
		CollectMerchant();
	}
}
