using System;
using System.Runtime.InteropServices;

namespace Command.Watchers;

internal sealed class SpecificationRuleWatcher
{
	internal struct TagExporter : IDisposable
	{
		public IntPtr _FieldExporter;

		public int _QueueExporter;

		public IntPtr _RegExporter;

		public void Dispose()
		{
			if (_RegExporter != IntPtr.Zero)
			{
				LocalFree(_RegExporter);
				_RegExporter = IntPtr.Zero;
			}
		}
	}

	public const int m_SetterMerchant = 74;

	public const int _CreatorMerchant = 28;

	private SpecificationRuleWatcher()
	{
	}

	[DllImport("user32.dll")]
	internal static extern bool SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, ref TagExporter tagExporter_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr LocalAlloc(int int_0, int int_1);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr LocalFree(IntPtr intptr_0);

	[DllImport("user32.dll")]
	internal static extern IntPtr FindWindow(string string_0, string string_1);

	public static bool AddMerchant(IntPtr intptr_0, string string_0)
	{
		if (intptr_0 == IntPtr.Zero)
		{
			return false;
		}
		TagExporter tagExporter_ = default(TagExporter);
		try
		{
			tagExporter_._QueueExporter = (string_0.Length + 1) * 2;
			tagExporter_._RegExporter = LocalAlloc(64, tagExporter_._QueueExporter);
			Marshal.Copy(string_0.ToCharArray(), 0, tagExporter_._RegExporter, string_0.Length);
			tagExporter_._FieldExporter = (IntPtr)1;
			return SendMessage(intptr_0, 74, IntPtr.Zero, ref tagExporter_);
		}
		finally
		{
			tagExporter_.Dispose();
		}
	}
}
