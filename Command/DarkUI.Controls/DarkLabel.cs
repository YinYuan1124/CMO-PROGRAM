using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkLabel : Label
{
	private bool m_DispatcherExpression;

	private bool _ListenerExpression;

	[Description("Enables automatic height sizing based on the contents of the label.")]
	[DefaultValue(false)]
	[Category("Layout")]
	public bool AutoUpdateHeight
	{
		get
		{
			return m_DispatcherExpression;
		}
		set
		{
			m_DispatcherExpression = value;
			if (m_DispatcherExpression)
			{
				AutoSize = false;
				InitRegistry();
			}
		}
	}

	public new bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = value;
			if (AutoSize)
			{
				AutoUpdateHeight = false;
			}
		}
	}

	public DarkLabel()
	{
		ForeColor = Colors.LightText;
	}

	private void InitRegistry()
	{
		if (m_DispatcherExpression && !_ListenerExpression)
		{
			try
			{
				_ListenerExpression = true;
				base.Height = TextRenderer.MeasureText(proposedSize: new Size(base.Width, int.MaxValue), text: Text, font: Font, flags: TextFormatFlags.WordBreak).Height + base.Padding.Vertical;
			}
			finally
			{
				_ListenerExpression = false;
			}
		}
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		InitRegistry();
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		InitRegistry();
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		InitRegistry();
	}
}
