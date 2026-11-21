using System;
using System.Drawing;
using System.Windows.Forms;
using Command.Listeners;

namespace DarkUI.Win32;

public sealed class ControlScrollFilter : IMessageFilter
{
	public bool PreFilterMessage(ref Message m)
	{
		int msg = m.Msg;
		if (msg != 522 && msg != 526)
		{
			return false;
		}
		IntPtr intPtr = MethodObject.WindowFromPoint(new Point((int)m.LParam));
		if (intPtr == m.HWnd)
		{
			return false;
		}
		MethodObject.SendMessage(intPtr, (uint)m.Msg, m.WParam, m.LParam);
		return true;
	}
}
