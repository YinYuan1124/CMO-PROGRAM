using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MJW.Guardian.RuntimeComponents;

[ToolboxItem(true)]
public sealed class ShadowLabel : Label
{
	private bool taskDecorator = true;

	private Color m_FilterDecorator = Color.White;

	private Color _TestsDecorator = Color.LightSkyBlue;

	private float interpreterDecorator;

	private bool m_ContainerDecorator = true;

	private float composerDecorator = 1f;

	private float modelDecorator = 1f;

	private Color advisorDecorator = Color.Black;

	private Container customerDecorator;

	[DefaultValue(true)]
	[Category("Gradient")]
	[Description("Set to true to draw the gradient background")]
	public bool DrawGradient
	{
		get
		{
			return taskDecorator;
		}
		set
		{
			taskDecorator = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Color.White")]
	[Category("Gradient")]
	[Description("The start color of the gradient")]
	public Color StartColor
	{
		get
		{
			return m_FilterDecorator;
		}
		set
		{
			m_FilterDecorator = value;
			Invalidate();
		}
	}

	[Description("The end color of the gradient")]
	[Category("Gradient")]
	[DefaultValue(typeof(Color), "Color.LightSkyBlue")]
	public Color EndColor
	{
		get
		{
			return _TestsDecorator;
		}
		set
		{
			_TestsDecorator = value;
			Invalidate();
		}
	}

	[DefaultValue(0)]
	[Description("The angle of the gradient")]
	[Category("Gradient")]
	public float Angle
	{
		get
		{
			return interpreterDecorator;
		}
		set
		{
			interpreterDecorator = value;
			Invalidate();
		}
	}

	[Category("Drop Shadow")]
	[Description("Set to true to draw the Drop Shadow")]
	[DefaultValue(true)]
	public bool DrawShadow
	{
		get
		{
			return m_ContainerDecorator;
		}
		set
		{
			m_ContainerDecorator = value;
			Invalidate();
		}
	}

	[Category("Drop Shadow")]
	[Description("The X Offset used to draw the shadow")]
	[DefaultValue(1)]
	public float XOffset
	{
		get
		{
			return modelDecorator;
		}
		set
		{
			modelDecorator = value;
			Invalidate();
		}
	}

	[Description("The Y Offset used to draw the shadow")]
	[Category("Drop Shadow")]
	[DefaultValue(1)]
	public float YOffset
	{
		get
		{
			return composerDecorator;
		}
		set
		{
			composerDecorator = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Color.Black")]
	[Description("The color used to draw the shadow")]
	[Category("Drop Shadow")]
	public Color ShadowColor
	{
		get
		{
			return advisorDecorator;
		}
		set
		{
			advisorDecorator = value;
			Invalidate();
		}
	}

	public ShadowLabel(IContainer icontainer_0)
	{
		icontainer_0.Add(this);
		CheckProcess();
	}

	public ShadowLabel()
	{
		CheckProcess();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && customerDecorator != null)
		{
			customerDecorator.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		if (taskDecorator)
		{
			LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), m_FilterDecorator, _TestsDecorator, interpreterDecorator, isAngleScaleable: true);
			e.Graphics.FillRectangle(brush, 0, 0, base.Width, base.Height);
		}
		if (m_ContainerDecorator)
		{
			e.Graphics.DrawString(Text, Font, new SolidBrush(advisorDecorator), modelDecorator, composerDecorator, StringFormat.GenericDefault);
		}
		e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 0f, 0f, StringFormat.GenericDefault);
	}

	private void CheckProcess()
	{
		customerDecorator = new Container();
		ForeColor = Color.LightSkyBlue;
	}
}
