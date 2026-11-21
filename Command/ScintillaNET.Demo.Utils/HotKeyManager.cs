using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ScintillaNET.Demo.Utils;

public sealed class HotKeyManager
{
	[CompilerGenerated]
	private sealed class ReponseDecoratorEntry
	{
		public Keys key;

		public bool ctrl;

		public bool shift;

		public bool alt;

		public Action function;

		internal void ComputeInterruptibleMapping(object sender, KeyEventArgs e)
		{
			if (IsHotkey(e, key, ctrl, shift, alt))
			{
				function();
			}
		}
	}

	public static bool Enable;

	public static void AddHotKey(Form form_0, Action action_0, Keys keys_0, bool bool_0 = false, bool bool_1 = false, bool bool_2 = false)
	{
		form_0.KeyPreview = true;
		form_0.KeyDown += delegate(object sender, KeyEventArgs e)
		{
			if (IsHotkey(e, keys_0, bool_0, bool_1, bool_2))
			{
				action_0();
			}
		};
	}

	public static bool IsHotkey(KeyEventArgs keyEventArgs_0, Keys keys_0, bool bool_0 = false, bool bool_1 = false, bool bool_2 = false)
	{
		if (keyEventArgs_0.KeyCode == keys_0 && keyEventArgs_0.Control == bool_0 && keyEventArgs_0.Shift == bool_1)
		{
			return keyEventArgs_0.Alt == bool_2;
		}
		return false;
	}

	static HotKeyManager()
	{
		Enable = true;
	}
}
