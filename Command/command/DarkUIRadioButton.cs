using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Command;

[DefaultProperty("Checked")]
[DefaultEvent("CheckedChanged")]
public sealed class DarkUIRadioButton : Control
{
	public delegate void CheckedChangedEventHandler(object sender);

	private bool m_RegValue;

	protected int _Group;

	[CompilerGenerated]
	private CheckedChangedEventHandler m_ParamValue;

	[Category("Custom")]
	[Description("Gets or sets a value indicating whether the control is checked.")]
	public bool Checked
	{
		get
		{
			return m_RegValue;
		}
		set
		{
			m_RegValue = value;
			if (m_ParamValue != null)
			{
				m_ParamValue?.Invoke(this);
			}
			Invalidate();
		}
	}

	[Category("Custom")]
	public int Group
	{
		get
		{
			return _Group;
		}
		set
		{
			_Group = value;
			Invalidate();
		}
	}

	public event CheckedChangedEventHandler CheckedChanged
	{
		[CompilerGenerated]
		add
		{
			CheckedChangedEventHandler checkedChangedEventHandler = m_ParamValue;
			CheckedChangedEventHandler checkedChangedEventHandler2;
			do
			{
				checkedChangedEventHandler2 = checkedChangedEventHandler;
				CheckedChangedEventHandler value2 = (CheckedChangedEventHandler)Delegate.Combine(checkedChangedEventHandler2, value);
				checkedChangedEventHandler = Interlocked.CompareExchange(ref m_ParamValue, value2, checkedChangedEventHandler2);
			}
			while ((object)checkedChangedEventHandler != checkedChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CheckedChangedEventHandler checkedChangedEventHandler = m_ParamValue;
			CheckedChangedEventHandler checkedChangedEventHandler2;
			do
			{
				checkedChangedEventHandler2 = checkedChangedEventHandler;
				CheckedChangedEventHandler value2 = (CheckedChangedEventHandler)Delegate.Remove(checkedChangedEventHandler2, value);
				checkedChangedEventHandler = Interlocked.CompareExchange(ref m_ParamValue, value2, checkedChangedEventHandler2);
			}
			while ((object)checkedChangedEventHandler != checkedChangedEventHandler2);
		}
	}

	public DarkUIRadioButton()
	{
		_Group = 1;
		SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		UpdateStyles();
		Cursor = Cursors.Hand;
		BackColor = Color.Transparent;
		ForeColor = Color.FromArgb(209, 209, 209);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(0, 0, 18, 18);
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		using LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
		using SolidBrush brush3 = new SolidBrush(Color.FromArgb(189, 189, 189));
		using Pen pen2 = new Pen(Color.FromArgb(22, 22, 22));
		using SolidBrush brush2 = new SolidBrush(ForeColor);
		using Pen pen = new Pen(Color.FromArgb(20, Color.White));
		graphics.FillEllipse(brush, rect);
		graphics.DrawEllipse(pen, new Rectangle(1, 1, 16, 16));
		graphics.DrawEllipse(pen2, rect);
		graphics.DrawString(Text, Font, brush2, new Rectangle(21, 1, base.Width, base.Height - 2), HelperMethods.SetPosition(StringAlignment.Near));
		if (Checked)
		{
			graphics.FillEllipse(brush3, new Rectangle(5, 5, 8, 8));
		}
	}

	private void ViewServer()
	{
		if (!base.IsHandleCreated || !Checked)
		{
			return;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = base.Parent.Controls.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Control control = (Control)enumerator.Current;
				if (control != this && control is DarkUIRadioButton && ((DarkUIRadioButton)control).Group == _Group)
				{
					((DarkUIRadioButton)control).Checked = false;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	protected override void OnClick(EventArgs e)
	{
		m_RegValue = !Checked;
		ViewServer();
		base.OnClick(e);
		Invalidate();
	}

	protected override void OnCreateControl()
	{
		ViewServer();
		base.OnCreateControl();
	}

	protected override void OnTextChanged(EventArgs e)
	{
		Invalidate();
		base.OnTextChanged(e);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		base.Height = 21;
		Invalidate();
	}
}
