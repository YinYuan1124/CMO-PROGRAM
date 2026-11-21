using System;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

public sealed class DockContentEventArgs : EventArgs
{
	[CompilerGenerated]
	private DarkDockContent testsParameter;

	public DarkDockContent Content
	{
		[CompilerGenerated]
		get
		{
			return testsParameter;
		}
		[CompilerGenerated]
		private set
		{
			testsParameter = value;
		}
	}

	public DockContentEventArgs(DarkDockContent darkDockContent_0)
	{
		Content = darkDockContent_0;
	}
}
