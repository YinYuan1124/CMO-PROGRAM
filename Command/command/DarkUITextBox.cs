using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DefaultEvent("TextChanged")]
public sealed class DarkUITextBox : Control
{
	public delegate void TextChangedEventHandler(object sender);

	public TextBox _T;

	private HorizontalAlignment m_PageValue;

	private int rulesValue;

	private bool m_MethodValue;

	private bool serviceValue;

	private string _SystemValue;

	private Image m_CandidateValue;

	private AutoCompleteSource m_BaseValue;

	private AutoCompleteMode _PolicyValue;

	private AutoCompleteStringCollection _BroadcasterValue;

	private bool m_IdentifierValue;

	private string[] _PrinterValue;

	[CompilerGenerated]
	private TextChangedEventHandler _ParserValue;

	public TextBox T
	{
		get
		{
			return _T;
		}
		set
		{
			if (_T != null)
			{
				_T.TextChanged -= GetServer;
				_T.KeyDown -= WriteServer;
				_T.Click -= NewServer;
			}
			_T = value;
			if (_T != null)
			{
				_T.TextChanged += GetServer;
				_T.KeyDown += WriteServer;
				_T.Click += NewServer;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BorderStyle BorderStyle => BorderStyle.None;

	[Category("Custom")]
	[Description("Gets or sets how text is aligned in TextBox control.")]
	public HorizontalAlignment TextAlign
	{
		get
		{
			return m_PageValue;
		}
		set
		{
			m_PageValue = value;
			if (T != null)
			{
				T.TextAlign = value;
			}
			Invalidate();
		}
	}

	[Description("Gets or sets how text is aligned in TextBox control.")]
	[Category("Custom")]
	public int MaxLength
	{
		get
		{
			return rulesValue;
		}
		set
		{
			rulesValue = value;
			if (T != null)
			{
				T.MaxLength = value;
			}
			Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets a value indicating whether text in the text box is read-only.")]
	public bool ReadOnly
	{
		get
		{
			return m_MethodValue;
		}
		set
		{
			m_MethodValue = value;
			if (T != null)
			{
				T.ReadOnly = value;
			}
		}
	}

	[Description("Gets or sets a value indicating whether the text in  TextBox control should appear as the default password character.")]
	[Category("Custom")]
	public bool UseSystemPasswordChar
	{
		get
		{
			return serviceValue;
		}
		set
		{
			serviceValue = value;
			if (T != null)
			{
				T.UseSystemPasswordChar = value;
			}
		}
	}

	[Category("Custom")]
	[Description("Gets or sets a value indicating whether this is a multiline System.Windows.Forms.TextBox control.")]
	public bool Multiline
	{
		get
		{
			return m_IdentifierValue;
		}
		set
		{
			m_IdentifierValue = value;
			if (T != null)
			{
				T.Multiline = value;
				if (value)
				{
					T.Height = base.Height - 10;
				}
				else
				{
					base.Height = T.Height + 10;
				}
			}
		}
	}

	public int SelectionStart
	{
		get
		{
			return T.SelectionStart;
		}
		set
		{
			T.SelectionStart = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new Image BackgroundImage => null;

	[Category("Custom")]
	[Description("Gets or sets the current text in  TextBox.")]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
			if (T != null)
			{
				T.Text = value;
			}
		}
	}

	[Description("Gets or sets the text in the System.Windows.Forms.TextBox while being empty.")]
	[Category("Custom")]
	public string WatermarkText
	{
		get
		{
			return _SystemValue;
		}
		set
		{
			_SystemValue = value;
			SendMessage(T.Handle, 5377, 0, value);
			Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the image of the control.")]
	public Image Image
	{
		get
		{
			return m_CandidateValue;
		}
		set
		{
			m_CandidateValue = value;
			Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
	public AutoCompleteSource AutoCompleteSource
	{
		get
		{
			return m_BaseValue;
		}
		set
		{
			m_BaseValue = value;
			if (T != null)
			{
				T.AutoCompleteSource = value;
			}
			Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
	public AutoCompleteStringCollection AutoCompleteCustomSource
	{
		get
		{
			return _BroadcasterValue;
		}
		set
		{
			_BroadcasterValue = value;
			if (T != null)
			{
				T.AutoCompleteCustomSource = value;
			}
			Invalidate();
		}
	}

	[Description("Gets or sets an option that controls how automatic completion works for the TextBox.")]
	[Category("Custom")]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			return _PolicyValue;
		}
		set
		{
			_PolicyValue = value;
			if (T != null)
			{
				T.AutoCompleteMode = value;
			}
			Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the font of the text displayed by the control.")]
	public new Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			if (T != null)
			{
				T.Font = value;
				T.Location = new Point(5, 5);
				T.Width = base.Width - 8;
				if (!Multiline)
				{
					base.Height = T.Height + 11;
				}
			}
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the lines of text in the control.")]
	public string[] Lines
	{
		get
		{
			return _PrinterValue;
		}
		set
		{
			_PrinterValue = value;
			if (T != null)
			{
				T.Lines = value;
				Invalidate();
			}
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the ContextMenuStrip associated with this control.")]
	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return base.ContextMenuStrip;
		}
		set
		{
			base.ContextMenuStrip = value;
			if (T != null)
			{
				T.ContextMenuStrip = value;
				Invalidate();
			}
		}
	}

	public override bool Focused => T.Focused;

	public ScrollBars ScrollBars
	{
		get
		{
			return T.ScrollBars;
		}
		set
		{
			T.ScrollBars = value;
		}
	}

	public new event TextChangedEventHandler TextChanged
	{
		[CompilerGenerated]
		add
		{
			TextChangedEventHandler textChangedEventHandler = _ParserValue;
			TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				TextChangedEventHandler value2 = (TextChangedEventHandler)Delegate.Combine(textChangedEventHandler2, value);
				textChangedEventHandler = Interlocked.CompareExchange(ref _ParserValue, value2, textChangedEventHandler2);
			}
			while ((object)textChangedEventHandler != textChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TextChangedEventHandler textChangedEventHandler = _ParserValue;
			TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				TextChangedEventHandler value2 = (TextChangedEventHandler)Delegate.Remove(textChangedEventHandler2, value);
				textChangedEventHandler = Interlocked.CompareExchange(ref _ParserValue, value2, textChangedEventHandler2);
			}
			while ((object)textChangedEventHandler != textChangedEventHandler2);
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int SendMessage(IntPtr intptr_0, int int_0, int int_1, [MarshalAs(UnmanagedType.LPWStr)] string string_0);

	public DarkUITextBox()
	{
		_T = new TextBox();
		m_PageValue = HorizontalAlignment.Left;
		rulesValue = 32767;
		m_MethodValue = false;
		serviceValue = false;
		_SystemValue = string.Empty;
		m_BaseValue = AutoCompleteSource.None;
		_PolicyValue = AutoCompleteMode.None;
		m_IdentifierValue = false;
		_PrinterValue = null;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		UpdateStyles();
		BackColor = Color.Transparent;
		ForeColor = Color.FromArgb(189, 189, 189);
		T.Multiline = false;
		T.Cursor = Cursors.IBeam;
		T.BackColor = Color.FromArgb(31, 31, 31);
		T.ForeColor = ForeColor;
		T.BorderStyle = BorderStyle.None;
		T.Location = new Point(7, 4);
		T.Font = Font;
		T.UseSystemPasswordChar = UseSystemPasswordChar;
		base.Size = new Size(135, 30);
		if (Multiline)
		{
			T.Height = base.Height - 11;
		}
		else
		{
			base.Height = T.Height + 11;
		}
		_T.TextChanged += GetServer;
		_T.KeyDown += WriteServer;
		_T.Click += NewServer;
	}

	public void Clear()
	{
		T.Clear();
		Text = string.Empty;
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		if (!base.Controls.Contains(T))
		{
			base.Controls.Add(T);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		T.Size = new Size(base.Width - 10, base.Height - 10);
	}

	private void GetServer(object sender, EventArgs e)
	{
		Text = T.Text;
		if (_ParserValue != null)
		{
			_ParserValue?.Invoke(this);
		}
		Invalidate();
	}

	private void WriteServer(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			e.SuppressKeyPress = true;
		}
		if (e.Control && e.KeyCode == Keys.C)
		{
			T.Copy();
			e.SuppressKeyPress = true;
		}
		Invalidate();
	}

	private void NewServer(object sender, EventArgs e)
	{
		if (Operators.CompareString(T.Text, "任务: <name>", TextCompare: true) == 0 || Operators.CompareString(T.Text, "未标明", TextCompare: true) == 0)
		{
			T.SelectAll();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		Rectangle rectangle_ = new Rectangle(0, 0, T.Width + 8, T.Height + 8);
		using (SolidBrush brush_ = new SolidBrush(Color.FromArgb(31, 31, 31)))
		{
			HelperMethods.FillRoundedPath(graphics, brush_, rectangle_, 2);
			HelperMethods.DrawRoundedPath(graphics, Color.FromArgb(22, 22, 22), 1f, rectangle_, 2);
		}
		if (Image == null)
		{
			T.Location = new Point(5, 2);
			return;
		}
		T.Location = new Point(31, 2);
		T.Width = base.Width - 60;
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.DrawImage(Image, new Rectangle(8, 6, 16, 16));
	}
}
