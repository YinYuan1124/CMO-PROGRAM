using System;
using System.Runtime.CompilerServices;

namespace DarkUI.Controls;

public sealed class ScrollValueEventArgs : EventArgs
{
	[CompilerGenerated]
	private int m_ProducerExpression;

	public int Value
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerExpression;
		}
		[CompilerGenerated]
		private set
		{
			m_ProducerExpression = value;
		}
	}

	public ScrollValueEventArgs(int int_0)
	{
		Value = int_0;
	}
}
