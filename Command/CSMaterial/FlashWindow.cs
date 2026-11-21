using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CSMaterial;

public static class FlashWindow
{
	private struct MockPrototype
	{
		public uint tagPrototype;

		public IntPtr _FieldPrototype;

		public uint m_QueuePrototype;

		public uint m_RegPrototype;

		public uint m_ParamPrototype;
	}

	public const uint FLASHW_STOP = 0u;

	public const uint FLASHW_CAPTION = 1u;

	public const uint FLASHW_TRAY = 2u;

	public const uint FLASHW_ALL = 3u;

	public const uint FLASHW_TIMER = 4u;

	public const uint FLASHW_TIMERNOFG = 12u;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool FlashWindowEx(ref MockPrototype mockPrototype_0);

	public static bool Flash(Form form_0)
	{
		if (smethod_0())
		{
			MockPrototype mockPrototype_ = InterruptDefinition(form_0.Handle, 15u, uint.MaxValue, 0u);
			return FlashWindowEx(ref mockPrototype_);
		}
		return false;
	}

	private static MockPrototype InterruptDefinition(IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2)
	{
		MockPrototype mockPrototype = default(MockPrototype);
		mockPrototype.tagPrototype = Convert.ToUInt32(Marshal.SizeOf(mockPrototype));
		mockPrototype._FieldPrototype = intptr_0;
		mockPrototype.m_QueuePrototype = uint_0;
		mockPrototype.m_RegPrototype = uint_1;
		mockPrototype.m_ParamPrototype = uint_2;
		return mockPrototype;
	}

	public static bool Flash(Form form_0, uint uint_0)
	{
		if (smethod_0())
		{
			MockPrototype mockPrototype_ = InterruptDefinition(form_0.Handle, 3u, uint_0, 0u);
			return FlashWindowEx(ref mockPrototype_);
		}
		return false;
	}

	public static bool Start(Form form_0)
	{
		if (smethod_0())
		{
			MockPrototype mockPrototype_ = InterruptDefinition(form_0.Handle, 3u, uint.MaxValue, 0u);
			return FlashWindowEx(ref mockPrototype_);
		}
		return false;
	}

	public static bool Stop(Form form_0)
	{
		if (smethod_0())
		{
			MockPrototype mockPrototype_ = InterruptDefinition(form_0.Handle, 0u, uint.MaxValue, 0u);
			return FlashWindowEx(ref mockPrototype_);
		}
		return false;
	}

	[SpecialName]
	private static bool smethod_0()
	{
		return Environment.OSVersion.Version.Major >= 5;
	}
}
