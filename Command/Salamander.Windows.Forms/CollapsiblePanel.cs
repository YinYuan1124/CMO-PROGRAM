using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command;
using Salamander.Drawing;

namespace Salamander.Windows.Forms;

public class CollapsiblePanel : Panel
{
	private ColorMatrix m_SpecificationCallback;

	private ImageAttributes watcherCallback;

	private PanelState reponseCallback;

	private int m_DescriptorCallback;

	private int _PoolCallback;

	private Color m_TaskCallback = Color.White;

	private Color filterCallback = Color.FromArgb(199, 212, 247);

	private IContainer m_TestsCallback;

	private Label m_InterpreterCallback;

	private Image m_ContainerCallback;

	private ImageList m_ComposerCallback;

	[CompilerGenerated]
	private PanelStateChangedEventHandler modelCallback;

	[Browsable(false)]
	public PanelState PanelState
	{
		get
		{
			return reponseCallback;
		}
		set
		{
			PanelState num = reponseCallback;
			reponseCallback = value;
			if (num != reponseCallback)
			{
				ForgotCallback();
			}
		}
	}

	[Category("Title")]
	[Description("The text contained in the title bar.")]
	public string TitleText
	{
		get
		{
			return m_InterpreterCallback.Text;
		}
		set
		{
			m_InterpreterCallback.Text = value;
		}
	}

	[Description("The foreground colour used to display the title text.")]
	[Category("Title")]
	public Color TitleFontColour
	{
		get
		{
			return m_InterpreterCallback.ForeColor;
		}
		set
		{
			m_InterpreterCallback.ForeColor = value;
		}
	}

	[Category("Title")]
	[Description("The font used to display the title text.")]
	public Font TitleFont
	{
		get
		{
			return m_InterpreterCallback.Font;
		}
		set
		{
			m_InterpreterCallback.Font = value;
		}
	}

	[Description("The image list to get the images displayed for expanding/collapsing the panel.")]
	[Category("Title")]
	public ImageList ImageList
	{
		get
		{
			return m_ComposerCallback;
		}
		set
		{
			m_ComposerCallback = value;
			if (m_ComposerCallback == null)
			{
				_PoolCallback = -1;
			}
			else if (m_ComposerCallback.Images.Count > 0)
			{
				_PoolCallback = 0;
			}
		}
	}

	[Description("The colour used at the start of the colour gradient displayed as the background of the title bar.")]
	[Category("Title")]
	public Color StartColour
	{
		get
		{
			return m_TaskCallback;
		}
		set
		{
			m_TaskCallback = value;
			m_InterpreterCallback.Invalidate();
		}
	}

	[Description("The colour used at the end of the colour gradient displayed as the background of the title bar.")]
	[Category("Title")]
	public Color EndColour
	{
		get
		{
			return filterCallback;
		}
		set
		{
			filterCallback = value;
			m_InterpreterCallback.Invalidate();
		}
	}

	[Description("The image that will be displayed on the left hand side of the title bar.")]
	[Category("Title")]
	public Image Image
	{
		get
		{
			return m_ContainerCallback;
		}
		set
		{
			m_ContainerCallback = value;
			if (value != null)
			{
				m_InterpreterCallback.Height = m_ContainerCallback.Height + 4;
				if (m_InterpreterCallback.Height < 24)
				{
					m_InterpreterCallback.Height = 24;
				}
			}
			m_InterpreterCallback.Invalidate();
		}
	}

	[Description("Raised when panel state has changed.")]
	[Category("State")]
	public event PanelStateChangedEventHandler PanelStateChanged
	{
		[CompilerGenerated]
		add
		{
			PanelStateChangedEventHandler panelStateChangedEventHandler = modelCallback;
			PanelStateChangedEventHandler panelStateChangedEventHandler2;
			do
			{
				panelStateChangedEventHandler2 = panelStateChangedEventHandler;
				PanelStateChangedEventHandler value2 = (PanelStateChangedEventHandler)Delegate.Combine(panelStateChangedEventHandler2, value);
				panelStateChangedEventHandler = Interlocked.CompareExchange(ref modelCallback, value2, panelStateChangedEventHandler2);
			}
			while ((object)panelStateChangedEventHandler != panelStateChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PanelStateChangedEventHandler panelStateChangedEventHandler = modelCallback;
			PanelStateChangedEventHandler panelStateChangedEventHandler2;
			do
			{
				panelStateChangedEventHandler2 = panelStateChangedEventHandler;
				PanelStateChangedEventHandler value2 = (PanelStateChangedEventHandler)Delegate.Remove(panelStateChangedEventHandler2, value);
				panelStateChangedEventHandler = Interlocked.CompareExchange(ref modelCallback, value2, panelStateChangedEventHandler2);
			}
			while ((object)panelStateChangedEventHandler != panelStateChangedEventHandler2);
		}
	}

	private void RateCallback()
	{
		m_TestsCallback = new Container();
		QResourceManager resourceManager = new QResourceManager(typeof(CollapsiblePanel));
		m_InterpreterCallback = new Label();
		m_ComposerCallback = new ImageList(m_TestsCallback);
		SuspendLayout();
		m_InterpreterCallback.Cursor = Cursors.Default;
		m_InterpreterCallback.Dock = DockStyle.Top;
		m_InterpreterCallback.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		m_InterpreterCallback.ForeColor = Color.Navy;
		m_InterpreterCallback.Location = new Point(114, 17);
		m_InterpreterCallback.Name = "labelTitle";
		m_InterpreterCallback.Size = new Size(200, 24);
		m_InterpreterCallback.TabIndex = 0;
		m_InterpreterCallback.Text = "Title";
		m_InterpreterCallback.TextAlign = ContentAlignment.MiddleLeft;
		m_InterpreterCallback.Paint += CollectCallback;
		m_InterpreterCallback.MouseUp += OrderCallback;
		m_InterpreterCallback.MouseMove += RegisterCallback;
		m_ComposerCallback.ColorDepth = ColorDepth.Depth32Bit;
		m_ComposerCallback.ImageSize = new Size(16, 16);
		m_ComposerCallback.ImageStream = resourceManager.GetImageListStreamer("imageList.ImageStream", CultureInfo.InvariantCulture);
		m_ComposerCallback.TransparentColor = Color.Transparent;
		base.Controls.AddRange(new Control[1] { m_InterpreterCallback });
		ResumeLayout(performLayout: false);
	}

	public CollapsiblePanel()
	{
		m_TestsCallback = new Container();
		RateCallback();
		BackColor = Color.AliceBlue;
		m_DescriptorCallback = base.Height;
		m_SpecificationCallback = new ColorMatrix();
		m_SpecificationCallback.Matrix00 = 1f / 3f;
		m_SpecificationCallback.Matrix01 = 1f / 3f;
		m_SpecificationCallback.Matrix02 = 1f / 3f;
		m_SpecificationCallback.Matrix10 = 1f / 3f;
		m_SpecificationCallback.Matrix11 = 1f / 3f;
		m_SpecificationCallback.Matrix12 = 1f / 3f;
		m_SpecificationCallback.Matrix20 = 1f / 3f;
		m_SpecificationCallback.Matrix21 = 1f / 3f;
		m_SpecificationCallback.Matrix22 = 1f / 3f;
		watcherCallback = new ImageAttributes();
		watcherCallback.SetColorMatrix(m_SpecificationCallback, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
	}

	private bool FlushCallback(int int_0, int int_1)
	{
		if (m_InterpreterCallback.Bounds.Contains(int_0, int_1))
		{
			return true;
		}
		return false;
	}

	private void ForgotCallback()
	{
		switch (reponseCallback)
		{
		case PanelState.Collapsed:
			m_DescriptorCallback = base.Height;
			base.Height = m_InterpreterCallback.Height;
			_PoolCallback = 1;
			break;
		case PanelState.Expanded:
			base.Height = m_DescriptorCallback;
			_PoolCallback = 0;
			break;
		}
		m_InterpreterCallback.Invalidate();
		OnPanelStateChanged(new PanelEventArgs(this));
	}

	protected virtual void OnPanelStateChanged(PanelEventArgs panelEventArgs_0)
	{
		if (modelCallback != null)
		{
			modelCallback(this, panelEventArgs_0);
		}
	}

	private void CollectCallback(object sender, PaintEventArgs e)
	{
		int num = 7;
		Rectangle bounds = m_InterpreterCallback.Bounds;
		int num2 = 0;
		if (m_ContainerCallback != null)
		{
			num2 = m_InterpreterCallback.Height - 24;
			if (num2 < 0)
			{
				num2 = 0;
			}
			bounds.Offset(0, num2);
			bounds.Height -= num2;
		}
		e.Graphics.Clear(base.Parent.BackColor);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(bounds.Left + num, bounds.Top, bounds.Right - 14 - 1, bounds.Top);
		graphicsPath.AddArc(bounds.Right - 14 - 1, bounds.Top, 14, 14, 270f, 90f);
		graphicsPath.AddLine(bounds.Right, bounds.Top + num, bounds.Right, bounds.Bottom);
		graphicsPath.AddLine(bounds.Right, bounds.Bottom, bounds.Left - 1, bounds.Bottom);
		graphicsPath.AddArc(bounds.Left, bounds.Top, 14, 14, 180f, 90f);
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		if (base.Enabled)
		{
			LinearGradientBrush brush = new LinearGradientBrush(bounds, m_TaskCallback, filterCallback, LinearGradientMode.Horizontal);
			e.Graphics.FillPath(brush, graphicsPath);
		}
		else
		{
			Colour colour = new Colour();
			colour.CurrentColour = m_TaskCallback;
			colour.Saturation = 0f;
			Colour colour2 = new Colour();
			colour2.CurrentColour = filterCallback;
			colour2.Saturation = 0f;
			LinearGradientBrush brush2 = new LinearGradientBrush(bounds, colour.CurrentColour, colour2.CurrentColour, LinearGradientMode.Horizontal);
			e.Graphics.FillPath(brush2, graphicsPath);
		}
		GraphicsUnit pageUnit = GraphicsUnit.Display;
		int num3 = 2;
		if (m_ContainerCallback != null)
		{
			num3 += m_ContainerCallback.Width + 2;
			RectangleF bounds2 = m_ContainerCallback.GetBounds(ref pageUnit);
			Rectangle destRect = new Rectangle(2, 2, m_ContainerCallback.Width, m_ContainerCallback.Height);
			if (base.Enabled)
			{
				e.Graphics.DrawImage(m_ContainerCallback, destRect, (int)bounds2.Left, (int)bounds2.Top, (int)bounds2.Width, (int)bounds2.Height, pageUnit);
			}
			else
			{
				e.Graphics.DrawImage(m_ContainerCallback, destRect, (int)bounds2.Left, (int)bounds2.Top, (int)bounds2.Width, (int)bounds2.Height, pageUnit, watcherCallback);
			}
		}
		SolidBrush brush3 = new SolidBrush(TitleFontColour);
		float num4 = num3;
		float num5 = (float)num2 + 4f;
		float num6 = (float)m_InterpreterCallback.Width - num4 - (float)m_ComposerCallback.ImageSize.Width - 4f;
		float num7 = 16f;
		RectangleF layoutRectangle = new RectangleF(num4, num5, num6, num7);
		StringFormat stringFormat = new StringFormat();
		stringFormat.Trimming = StringTrimming.EllipsisWord;
		if (base.Enabled)
		{
			e.Graphics.DrawString(m_InterpreterCallback.Text, m_InterpreterCallback.Font, brush3, layoutRectangle, stringFormat);
		}
		else
		{
			Color grayText = SystemColors.GrayText;
			ControlPaint.DrawStringDisabled(e.Graphics, m_InterpreterCallback.Text, m_InterpreterCallback.Font, grayText, layoutRectangle, stringFormat);
		}
		Pen pen = new Pen(new SolidBrush(Color.White), 1f);
		graphicsPath.Reset();
		graphicsPath.AddLine(bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
		e.Graphics.DrawPath(pen, graphicsPath);
		int num8 = bounds.Right - m_ComposerCallback.ImageSize.Width - 4;
		int num9 = bounds.Top + 4;
		RectangleF bounds3 = ImageList.Images[(int)reponseCallback].GetBounds(ref pageUnit);
		Rectangle destRect2 = new Rectangle(num8, num9, m_ComposerCallback.ImageSize.Width, m_ComposerCallback.ImageSize.Height);
		if (base.Enabled)
		{
			e.Graphics.DrawImage(ImageList.Images[(int)reponseCallback], destRect2, (int)bounds3.Left, (int)bounds3.Top, (int)bounds3.Width, (int)bounds3.Height, pageUnit);
		}
		else
		{
			e.Graphics.DrawImage(ImageList.Images[(int)reponseCallback], destRect2, (int)bounds3.Left, (int)bounds3.Top, (int)bounds3.Width, (int)bounds3.Height, pageUnit, watcherCallback);
		}
	}

	private void OrderCallback(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left && FlushCallback(e.X, e.Y) && m_ComposerCallback != null && m_ComposerCallback.Images.Count >= 2)
		{
			if (_PoolCallback == 0)
			{
				reponseCallback = PanelState.Collapsed;
			}
			else
			{
				reponseCallback = PanelState.Expanded;
			}
			ForgotCallback();
		}
	}

	private void RegisterCallback(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.None && FlushCallback(e.X, e.Y))
		{
			m_InterpreterCallback.Cursor = Cursors.Hand;
		}
		else
		{
			m_InterpreterCallback.Cursor = Cursors.Default;
		}
	}
}
