using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CSMaterial;

namespace AGaugeApp;

[ToolboxBitmap(typeof(AGauge), "AGauge.bmp")]
[DefaultEvent("ValueInRangeChanged")]
[Description("Displays a value on an analog gauge. Raises an event if the value enters one of the definable ranges.")]
public class AGauge : Control
{
	public enum NeedleColorEnum
	{
		Gray,
		Red,
		Green,
		Blue,
		Yellow,
		Violet,
		Magenta
	}

	public sealed class ValueInRangeChangedEventArgs : EventArgs
	{
		public int valueInRange;

		public ValueInRangeChangedEventArgs(int int_0)
		{
			valueInRange = int_0;
		}
	}

	public delegate void ValueInRangeChangedDelegate(object sender, ValueInRangeChangedEventArgs e);

	private float m_ConfigurationConfig;

	private float tokenConfig;

	private Bitmap m_IndexerConfig;

	private bool resolverConfig = true;

	private float _PublisherConfig;

	private bool[] serverConfig = new bool[5];

	private byte m_AdapterConfig = 1;

	private Color[] m_SchemaConfig = new Color[5]
	{
		Color.Black,
		Color.Black,
		Color.Black,
		Color.Black,
		Color.Black
	};

	private string[] _UtilsConfig = new string[5] { "", "", "", "", "" };

	private Point[] predicateConfig = new Point[5]
	{
		new Point(10, 10),
		new Point(10, 10),
		new Point(10, 10),
		new Point(10, 10),
		new Point(10, 10)
	};

	private Point _SingletonConfig = new Point(100, 100);

	private float recordConfig = -100f;

	private float exceptionConfig = 400f;

	private Color _AttrConfig = Color.Gray;

	private int m_VisitorConfig = 80;

	private int m_ExporterConfig = 135;

	private int prototypeConfig = 270;

	private int m_ComparatorConfig = 2;

	private Color _ItemConfig = Color.Black;

	private int m_SetterConfig = 73;

	private int creatorConfig = 80;

	private int m_TemplateConfig = 1;

	private int _MappingConfig = 9;

	private Color mockConfig = Color.Gray;

	private int _TagConfig = 75;

	private int _FieldConfig = 80;

	private int m_QueueConfig = 1;

	private float regConfig = 50f;

	private Color _ParamConfig = Color.Black;

	private int m_PageConfig = 70;

	private int m_RulesConfig = 80;

	private int methodConfig = 2;

	private byte _ServiceConfig;

	private bool[] m_SystemConfig = new bool[5] { true, true, false, false, false };

	private Color[] m_CandidateConfig = new Color[5]
	{
		Color.LightGreen,
		Color.Red,
		Color.FromKnownColor(KnownColor.Control),
		Color.FromKnownColor(KnownColor.Control),
		Color.FromKnownColor(KnownColor.Control)
	};

	private float[] _BaseConfig = new float[5] { -100f, 300f, 0f, 0f, 0f };

	private float[] _PolicyConfig = new float[5] { 300f, 400f, 0f, 0f, 0f };

	private int[] m_BroadcasterConfig = new int[5] { 70, 70, 70, 70, 70 };

	private int[] identifierConfig = new int[5] { 80, 80, 80, 80, 80 };

	private int m_PrinterConfig = 95;

	private Color m_ParserConfig = Color.Black;

	private string algoConfig;

	private int _DatabaseConfig;

	private int m_InterceptorConfig = 1;

	private int messageConfig;

	private int m_ProductConfig;

	private int m_AnnotationConfig = 80;

	private NeedleColorEnum _IteratorConfig;

	private Color _InitializerConfig = Color.DimGray;

	private int m_RoleConfig = 2;

	[CompilerGenerated]
	private ValueInRangeChangedDelegate m_FactoryConfig;

	private IContainer _AttributeConfig;

	public new bool AllowDrop
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public new bool AutoSize
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public new bool ForeColor
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public new bool ImeMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
			resolverConfig = true;
			Refresh();
		}
	}

	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			resolverConfig = true;
			Refresh();
		}
	}

	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
			resolverConfig = true;
			Refresh();
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The value.")]
	public float Value
	{
		get
		{
			return _PublisherConfig;
		}
		set
		{
			if (_PublisherConfig == value)
			{
				return;
			}
			_PublisherConfig = Math.Min(Math.Max(value, recordConfig), exceptionConfig);
			if (base.DesignMode)
			{
				resolverConfig = true;
			}
			for (int i = 0; i < 4; i++)
			{
				if (_BaseConfig[i] <= _PublisherConfig && _PublisherConfig <= _PolicyConfig[i] && m_SystemConfig[i])
				{
					if (!serverConfig[i] && m_FactoryConfig != null)
					{
						m_FactoryConfig(this, new ValueInRangeChangedEventArgs(i));
					}
				}
				else
				{
					serverConfig[i] = false;
				}
			}
			Refresh();
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	[Description("The caption index. set this to a value of 0 up to 4 to change the corresponding caption's properties.")]
	[Browsable(true)]
	[Category("AGauge")]
	public byte Cap_Idx
	{
		get
		{
			return m_AdapterConfig;
		}
		set
		{
			if (m_AdapterConfig != value && 0 <= value && value < 5)
			{
				m_AdapterConfig = value;
			}
		}
	}

	[Category("AGauge")]
	[Description("The color of the caption text.")]
	[Browsable(true)]
	private Color IncludeObserver
	{
		get
		{
			return m_SchemaConfig[m_AdapterConfig];
		}
		set
		{
			if (m_SchemaConfig[m_AdapterConfig] != value)
			{
				m_SchemaConfig[m_AdapterConfig] = value;
				CapColors = m_SchemaConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public Color[] CapColors
	{
		get
		{
			return m_SchemaConfig;
		}
		set
		{
			m_SchemaConfig = value;
		}
	}

	[Description("The text of the caption.")]
	[Category("AGauge")]
	[Browsable(true)]
	public string CapText
	{
		get
		{
			return _UtilsConfig[m_AdapterConfig];
		}
		set
		{
			if (_UtilsConfig[m_AdapterConfig] != value)
			{
				_UtilsConfig[m_AdapterConfig] = value;
				CapsText = _UtilsConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public string[] CapsText
	{
		get
		{
			return _UtilsConfig;
		}
		set
		{
			for (int i = 0; i < 5; i++)
			{
				_UtilsConfig[i] = value[i];
			}
		}
	}

	[Description("The position of the caption.")]
	[Category("AGauge")]
	[Browsable(true)]
	public Point CapPosition
	{
		get
		{
			return predicateConfig[m_AdapterConfig];
		}
		set
		{
			if (predicateConfig[m_AdapterConfig] != value)
			{
				predicateConfig[m_AdapterConfig] = value;
				CapsPosition = predicateConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public Point[] CapsPosition
	{
		get
		{
			return predicateConfig;
		}
		set
		{
			predicateConfig = value;
		}
	}

	[Description("The center of the gauge (in the control's client area).")]
	[Browsable(true)]
	[Category("AGauge")]
	public Point Center
	{
		get
		{
			return _SingletonConfig;
		}
		set
		{
			if (_SingletonConfig != value)
			{
				_SingletonConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The minimum value to show on the scale.")]
	public float MinValue
	{
		get
		{
			return recordConfig;
		}
		set
		{
			if (recordConfig != value && value < exceptionConfig)
			{
				recordConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The maximum value to show on the scale.")]
	[Category("AGauge")]
	[Browsable(true)]
	public float MaxValue
	{
		get
		{
			return exceptionConfig;
		}
		set
		{
			if (exceptionConfig != value && value > recordConfig)
			{
				exceptionConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The color of the base arc.")]
	public Color BaseArcColor
	{
		get
		{
			return _AttrConfig;
		}
		set
		{
			if (_AttrConfig != value)
			{
				_AttrConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The radius of the base arc.")]
	[Category("AGauge")]
	public int BaseArcRadius
	{
		get
		{
			return m_VisitorConfig;
		}
		set
		{
			if (m_VisitorConfig != value)
			{
				m_VisitorConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The start angle of the base arc.")]
	[Category("AGauge")]
	public int BaseArcStart
	{
		get
		{
			return m_ExporterConfig;
		}
		set
		{
			if (m_ExporterConfig != value)
			{
				m_ExporterConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The sweep angle of the base arc.")]
	[Category("AGauge")]
	[Browsable(true)]
	public int BaseArcSweep
	{
		get
		{
			return prototypeConfig;
		}
		set
		{
			if (prototypeConfig != value)
			{
				prototypeConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The width of the base arc.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int BaseArcWidth
	{
		get
		{
			return m_ComparatorConfig;
		}
		set
		{
			if (m_ComparatorConfig != value)
			{
				m_ComparatorConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	[Category("AGauge")]
	[Browsable(true)]
	public Color ScaleLinesInterColor
	{
		get
		{
			return _ItemConfig;
		}
		set
		{
			if (_ItemConfig != value)
			{
				_ItemConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The inner radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int ScaleLinesInterInnerRadius
	{
		get
		{
			return m_SetterConfig;
		}
		set
		{
			if (m_SetterConfig != value)
			{
				m_SetterConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The outer radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	public int ScaleLinesInterOuterRadius
	{
		get
		{
			return creatorConfig;
		}
		set
		{
			if (creatorConfig != value)
			{
				creatorConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The width of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	public int ScaleLinesInterWidth
	{
		get
		{
			return m_TemplateConfig;
		}
		set
		{
			if (m_TemplateConfig != value)
			{
				m_TemplateConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The number of minor scale lines.")]
	public int ScaleLinesMinorNumOf
	{
		get
		{
			return _MappingConfig;
		}
		set
		{
			if (_MappingConfig != value)
			{
				_MappingConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The color of the minor scale lines.")]
	public Color ScaleLinesMinorColor
	{
		get
		{
			return mockConfig;
		}
		set
		{
			if (mockConfig != value)
			{
				mockConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The inner radius of the minor scale lines.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int ScaleLinesMinorInnerRadius
	{
		get
		{
			return _TagConfig;
		}
		set
		{
			if (_TagConfig != value)
			{
				_TagConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The outer radius of the minor scale lines.")]
	[Category("AGauge")]
	public int ScaleLinesMinorOuterRadius
	{
		get
		{
			return _FieldConfig;
		}
		set
		{
			if (_FieldConfig != value)
			{
				_FieldConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The width of the minor scale lines.")]
	[Category("AGauge")]
	[Browsable(true)]
	public int ScaleLinesMinorWidth
	{
		get
		{
			return m_QueueConfig;
		}
		set
		{
			if (m_QueueConfig != value)
			{
				m_QueueConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The step value of the major scale lines.")]
	[Category("AGauge")]
	[Browsable(true)]
	public float ScaleLinesMajorStepValue
	{
		get
		{
			return regConfig;
		}
		set
		{
			if (value > 0f)
			{
				regConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The color of the major scale lines.")]
	public Color ScaleLinesMajorColor
	{
		get
		{
			return _ParamConfig;
		}
		set
		{
			if (_ParamConfig != value)
			{
				_ParamConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The inner radius of the major scale lines.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int ScaleLinesMajorInnerRadius
	{
		get
		{
			return m_PageConfig;
		}
		set
		{
			if (m_PageConfig != value)
			{
				m_PageConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Description("The outer radius of the major scale lines.")]
	[Browsable(true)]
	public int ScaleLinesMajorOuterRadius
	{
		get
		{
			return m_RulesConfig;
		}
		set
		{
			if (m_RulesConfig != value)
			{
				m_RulesConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The width of the major scale lines.")]
	public int ScaleLinesMajorWidth
	{
		get
		{
			return methodConfig;
		}
		set
		{
			if (methodConfig != value)
			{
				methodConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The range index. set this to a value of 0 up to 4 to change the corresponding range's properties.")]
	[Category("AGauge")]
	[Browsable(true)]
	[RefreshProperties(RefreshProperties.All)]
	public byte Range_Idx
	{
		get
		{
			return _ServiceConfig;
		}
		set
		{
			if (_ServiceConfig != value && 0 <= value && value < 5)
			{
				_ServiceConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("Enables or disables the range selected by Range_Idx.")]
	[Browsable(true)]
	[Category("AGauge")]
	public bool RangeEnabled
	{
		get
		{
			return m_SystemConfig[_ServiceConfig];
		}
		set
		{
			if (m_SystemConfig[_ServiceConfig] != value)
			{
				m_SystemConfig[_ServiceConfig] = value;
				RangesEnabled = m_SystemConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public bool[] RangesEnabled
	{
		get
		{
			return m_SystemConfig;
		}
		set
		{
			m_SystemConfig = value;
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The color of the range.")]
	public Color RangeColor
	{
		get
		{
			return m_CandidateConfig[_ServiceConfig];
		}
		set
		{
			if (m_CandidateConfig[_ServiceConfig] != value)
			{
				m_CandidateConfig[_ServiceConfig] = value;
				RangesColor = m_CandidateConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public Color[] RangesColor
	{
		get
		{
			return m_CandidateConfig;
		}
		set
		{
			m_CandidateConfig = value;
		}
	}

	[Description("The start value of the range, must be less than RangeEndValue.")]
	[Browsable(true)]
	[Category("AGauge")]
	public float RangeStartValue
	{
		get
		{
			return _BaseConfig[_ServiceConfig];
		}
		set
		{
			if (_BaseConfig[_ServiceConfig] != value && value < _PolicyConfig[_ServiceConfig])
			{
				_BaseConfig[_ServiceConfig] = value;
				RangesStartValue = _BaseConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public float[] RangesStartValue
	{
		get
		{
			return _BaseConfig;
		}
		set
		{
			_BaseConfig = value;
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The end value of the range. Must be greater than RangeStartValue.")]
	public float RangeEndValue
	{
		get
		{
			return _PolicyConfig[_ServiceConfig];
		}
		set
		{
			if (_PolicyConfig[_ServiceConfig] != value && _BaseConfig[_ServiceConfig] < value)
			{
				_PolicyConfig[_ServiceConfig] = value;
				RangesEndValue = _PolicyConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public float[] RangesEndValue
	{
		get
		{
			return _PolicyConfig;
		}
		set
		{
			_PolicyConfig = value;
		}
	}

	[Description("The inner radius of the range.")]
	[Category("AGauge")]
	[Browsable(true)]
	public int RangeInnerRadius
	{
		get
		{
			return m_BroadcasterConfig[_ServiceConfig];
		}
		set
		{
			if (m_BroadcasterConfig[_ServiceConfig] != value)
			{
				m_BroadcasterConfig[_ServiceConfig] = value;
				RangesInnerRadius = m_BroadcasterConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public int[] RangesInnerRadius
	{
		get
		{
			return m_BroadcasterConfig;
		}
		set
		{
			m_BroadcasterConfig = value;
		}
	}

	[Browsable(true)]
	[Description("The inner radius of the range.")]
	[Category("AGauge")]
	public int RangeOuterRadius
	{
		get
		{
			return identifierConfig[_ServiceConfig];
		}
		set
		{
			if (identifierConfig[_ServiceConfig] != value)
			{
				identifierConfig[_ServiceConfig] = value;
				RangesOuterRadius = identifierConfig;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	public int[] RangesOuterRadius
	{
		get
		{
			return identifierConfig;
		}
		set
		{
			identifierConfig = value;
		}
	}

	[Description("The radius of the scale numbers.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int ScaleNumbersRadius
	{
		get
		{
			return m_PrinterConfig;
		}
		set
		{
			if (m_PrinterConfig != value)
			{
				m_PrinterConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The color of the scale numbers.")]
	[Browsable(true)]
	[Category("AGauge")]
	public Color ScaleNumbersColor
	{
		get
		{
			return m_ParserConfig;
		}
		set
		{
			if (m_ParserConfig != value)
			{
				m_ParserConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The format of the scale numbers.")]
	public string ScaleNumbersFormat
	{
		get
		{
			return algoConfig;
		}
		set
		{
			if (algoConfig != value)
			{
				algoConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The number of the scale line to start writing numbers next to.")]
	[Category("AGauge")]
	public int ScaleNumbersStartScaleLine
	{
		get
		{
			return _DatabaseConfig;
		}
		set
		{
			if (_DatabaseConfig != value)
			{
				_DatabaseConfig = Math.Max(value, 1);
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The number of scale line steps for writing numbers.")]
	[Category("AGauge")]
	public int ScaleNumbersStepScaleLines
	{
		get
		{
			return m_InterceptorConfig;
		}
		set
		{
			if (m_InterceptorConfig != value)
			{
				m_InterceptorConfig = Math.Max(value, 1);
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The angle relative to the tangent of the base arc at a scale line that is used to rotate numbers. set to 0 for no rotation or e.g. set to 90.")]
	[Category("AGauge")]
	public int ScaleNumbersRotation
	{
		get
		{
			return messageConfig;
		}
		set
		{
			if (messageConfig != value)
			{
				messageConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
	public int NeedleType
	{
		get
		{
			return m_ProductConfig;
		}
		set
		{
			if (m_ProductConfig != value)
			{
				m_ProductConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The radius of the needle.")]
	[Category("AGauge")]
	[Browsable(true)]
	public int NeedleRadius
	{
		get
		{
			return m_AnnotationConfig;
		}
		set
		{
			if (m_AnnotationConfig != value)
			{
				m_AnnotationConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The first color of the needle.")]
	[Browsable(true)]
	[Category("AGauge")]
	public NeedleColorEnum NeedleColor1
	{
		get
		{
			return _IteratorConfig;
		}
		set
		{
			if (_IteratorConfig != value)
			{
				_IteratorConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("The second color of the needle.")]
	[Category("AGauge")]
	[Browsable(true)]
	public Color NeedleColor2
	{
		get
		{
			return _InitializerConfig;
		}
		set
		{
			if (_InitializerConfig != value)
			{
				_InitializerConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The width of the needle.")]
	public int NeedleWidth
	{
		get
		{
			return m_RoleConfig;
		}
		set
		{
			if (m_RoleConfig != value)
			{
				m_RoleConfig = value;
				resolverConfig = true;
				Refresh();
			}
		}
	}

	[Description("This event is raised if the value falls into a defined range.")]
	public event ValueInRangeChangedDelegate ValueInRangeChanged
	{
		[CompilerGenerated]
		add
		{
			ValueInRangeChangedDelegate valueInRangeChangedDelegate = m_FactoryConfig;
			ValueInRangeChangedDelegate valueInRangeChangedDelegate2;
			do
			{
				valueInRangeChangedDelegate2 = valueInRangeChangedDelegate;
				ValueInRangeChangedDelegate value2 = (ValueInRangeChangedDelegate)Delegate.Combine(valueInRangeChangedDelegate2, value);
				valueInRangeChangedDelegate = Interlocked.CompareExchange(ref m_FactoryConfig, value2, valueInRangeChangedDelegate2);
			}
			while ((object)valueInRangeChangedDelegate != valueInRangeChangedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ValueInRangeChangedDelegate valueInRangeChangedDelegate = m_FactoryConfig;
			ValueInRangeChangedDelegate valueInRangeChangedDelegate2;
			do
			{
				valueInRangeChangedDelegate2 = valueInRangeChangedDelegate;
				ValueInRangeChangedDelegate value2 = (ValueInRangeChangedDelegate)Delegate.Remove(valueInRangeChangedDelegate2, value);
				valueInRangeChangedDelegate = Interlocked.CompareExchange(ref m_FactoryConfig, value2, valueInRangeChangedDelegate2);
			}
			while ((object)valueInRangeChangedDelegate != valueInRangeChangedDelegate2);
		}
	}

	public AGauge()
	{
		InvokeObserver();
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	private void PushObserver()
	{
		SolidBrush solidBrush = new SolidBrush(Color.White);
		SolidBrush brush = new SolidBrush(Color.Black);
		Bitmap image = new Bitmap(5, 5);
		SizeF sizeF = Graphics.FromImage(image).MeasureString("0123456789", Font, -1, StringFormat.GenericTypographic);
		image = new Bitmap((int)sizeF.Width, (int)sizeF.Height);
		Graphics graphics = Graphics.FromImage(image);
		graphics.FillRectangle(solidBrush, 0f, 0f, sizeF.Width, sizeF.Height);
		graphics.DrawString("0123456789", Font, brush, 0f, 0f, StringFormat.GenericTypographic);
		m_ConfigurationConfig = 0f;
		tokenConfig = 0f;
		int i = 0;
		bool flag = false;
		for (; i < image.Height; i++)
		{
			if (flag)
			{
				break;
			}
			for (int j = 0; j < image.Width; j++)
			{
				if (flag)
				{
					break;
				}
				if (image.GetPixel(j, i) != solidBrush.Color)
				{
					m_ConfigurationConfig = i;
					flag = true;
				}
			}
		}
		i = image.Height - 1;
		flag = false;
		while (0 < i && !flag)
		{
			for (int k = 0; k < image.Width; k++)
			{
				if (flag)
				{
					break;
				}
				if (image.GetPixel(k, i) != solidBrush.Color)
				{
					tokenConfig = i;
					flag = true;
				}
			}
			i--;
		}
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (base.Width >= 10)
		{
			_ = base.Height;
		}
		if (resolverConfig)
		{
			resolverConfig = false;
			PushObserver();
			m_IndexerConfig = new Bitmap(base.Width, base.Height, e.Graphics);
			Graphics graphics = Graphics.FromImage(m_IndexerConfig);
			graphics.FillRectangle(new SolidBrush(BackColor), base.ClientRectangle);
			if (BackgroundImage != null)
			{
				switch (BackgroundImageLayout)
				{
				case ImageLayout.None:
					graphics.DrawImageUnscaled(BackgroundImage, 0, 0);
					break;
				case ImageLayout.Tile:
				{
					int i = 0;
					int num = 0;
					for (; i < base.Width; i += BackgroundImage.Width)
					{
						for (num = 0; num < base.Height; num += BackgroundImage.Height)
						{
							graphics.DrawImageUnscaled(BackgroundImage, i, num);
						}
					}
					break;
				}
				case ImageLayout.Center:
					graphics.DrawImageUnscaled(BackgroundImage, base.Width / 2 - BackgroundImage.Width / 2, base.Height / 2 - BackgroundImage.Height / 2);
					break;
				case ImageLayout.Stretch:
					graphics.DrawImage(BackgroundImage, 0, 0, base.Width, base.Height);
					break;
				case ImageLayout.Zoom:
					if ((float)(BackgroundImage.Width / base.Width) < (float)(BackgroundImage.Height / base.Height))
					{
						graphics.DrawImage(BackgroundImage, 0, 0, base.Height, base.Height);
					}
					else
					{
						graphics.DrawImage(BackgroundImage, 0, 0, base.Width, base.Width);
					}
					break;
				}
			}
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int j = 0; j < 5; j++)
			{
				if (_PolicyConfig[j] > _BaseConfig[j] && m_SystemConfig[j])
				{
					float startAngle = (float)m_ExporterConfig + (_BaseConfig[j] - recordConfig) * (float)prototypeConfig / (exceptionConfig - recordConfig);
					float sweepAngle = (_PolicyConfig[j] - _BaseConfig[j]) * (float)prototypeConfig / (exceptionConfig - recordConfig);
					graphicsPath.Reset();
					graphicsPath.AddPie(new Rectangle(_SingletonConfig.X - identifierConfig[j], _SingletonConfig.Y - identifierConfig[j], 2 * identifierConfig[j], 2 * identifierConfig[j]), startAngle, sweepAngle);
					graphicsPath.Reverse();
					graphicsPath.AddPie(new Rectangle(_SingletonConfig.X - m_BroadcasterConfig[j], _SingletonConfig.Y - m_BroadcasterConfig[j], 2 * m_BroadcasterConfig[j], 2 * m_BroadcasterConfig[j]), startAngle, sweepAngle);
					graphicsPath.Reverse();
					graphics.SetClip(graphicsPath);
					graphics.FillPie(new SolidBrush(m_CandidateConfig[j]), new Rectangle(_SingletonConfig.X - identifierConfig[j], _SingletonConfig.Y - identifierConfig[j], 2 * identifierConfig[j], 2 * identifierConfig[j]), startAngle, sweepAngle);
				}
			}
			graphics.SetClip(base.ClientRectangle);
			if (m_VisitorConfig > 0)
			{
				graphics.DrawArc(new Pen(_AttrConfig, m_ComparatorConfig), new Rectangle(_SingletonConfig.X - m_VisitorConfig, _SingletonConfig.Y - m_VisitorConfig, 2 * m_VisitorConfig, 2 * m_VisitorConfig), m_ExporterConfig, prototypeConfig);
			}
			string text = "";
			float num2 = 0f;
			int num3 = 0;
			while (num2 <= exceptionConfig - recordConfig)
			{
				text = (recordConfig + num2).ToString(algoConfig);
				graphics.ResetTransform();
				SizeF sizeF = graphics.MeasureString(text, Font, -1, StringFormat.GenericTypographic);
				graphicsPath.Reset();
				graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - m_RulesConfig, _SingletonConfig.Y - m_RulesConfig, 2 * m_RulesConfig, 2 * m_RulesConfig));
				graphicsPath.Reverse();
				graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - m_PageConfig, _SingletonConfig.Y - m_PageConfig, 2 * m_PageConfig, 2 * m_PageConfig));
				graphicsPath.Reverse();
				graphics.SetClip(graphicsPath);
				graphics.DrawLine(new Pen(_ParamConfig, methodConfig), Center.X, Center.Y, (float)((double)Center.X + (double)(2 * m_RulesConfig) * Math.Cos((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig)) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)(2 * m_RulesConfig) * Math.Sin((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig)) * CSMath.PI_dividedBy_180)));
				graphicsPath.Reset();
				graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - _FieldConfig, _SingletonConfig.Y - _FieldConfig, 2 * _FieldConfig, 2 * _FieldConfig));
				graphicsPath.Reverse();
				graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - _TagConfig, _SingletonConfig.Y - _TagConfig, 2 * _TagConfig, 2 * _TagConfig));
				graphicsPath.Reverse();
				graphics.SetClip(graphicsPath);
				if (num2 < exceptionConfig - recordConfig)
				{
					for (int k = 1; k <= _MappingConfig; k++)
					{
						if (_MappingConfig % 2 == 1 && _MappingConfig / 2 + 1 == k)
						{
							graphicsPath.Reset();
							graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - creatorConfig, _SingletonConfig.Y - creatorConfig, 2 * creatorConfig, 2 * creatorConfig));
							graphicsPath.Reverse();
							graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - m_SetterConfig, _SingletonConfig.Y - m_SetterConfig, 2 * m_SetterConfig, 2 * m_SetterConfig));
							graphicsPath.Reverse();
							graphics.SetClip(graphicsPath);
							graphics.DrawLine(new Pen(_ItemConfig, m_TemplateConfig), Center.X, Center.Y, (float)((double)Center.X + (double)(2 * creatorConfig) * Math.Cos((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig) + (float)(k * prototypeConfig) / ((exceptionConfig - recordConfig) / regConfig * (float)(_MappingConfig + 1))) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)(2 * creatorConfig) * Math.Sin((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig) + (float)(k * prototypeConfig) / ((exceptionConfig - recordConfig) / regConfig * (float)(_MappingConfig + 1))) * CSMath.PI_dividedBy_180)));
							graphicsPath.Reset();
							graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - _FieldConfig, _SingletonConfig.Y - _FieldConfig, 2 * _FieldConfig, 2 * _FieldConfig));
							graphicsPath.Reverse();
							graphicsPath.AddEllipse(new Rectangle(_SingletonConfig.X - _TagConfig, _SingletonConfig.Y - _TagConfig, 2 * _TagConfig, 2 * _TagConfig));
							graphicsPath.Reverse();
							graphics.SetClip(graphicsPath);
						}
						else
						{
							graphics.DrawLine(new Pen(mockConfig, m_QueueConfig), Center.X, Center.Y, (float)((double)Center.X + (double)(2 * _FieldConfig) * Math.Cos((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig) + (float)(k * prototypeConfig) / ((exceptionConfig - recordConfig) / regConfig * (float)(_MappingConfig + 1))) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)(2 * _FieldConfig) * Math.Sin((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig) + (float)(k * prototypeConfig) / ((exceptionConfig - recordConfig) / regConfig * (float)(_MappingConfig + 1))) * CSMath.PI_dividedBy_180)));
						}
					}
				}
				graphics.SetClip(base.ClientRectangle);
				if (messageConfig != 0)
				{
					graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
					graphics.RotateTransform(90f + (float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig));
				}
				graphics.TranslateTransform((float)((double)Center.X + (double)m_PrinterConfig * Math.Cos((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig)) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)m_PrinterConfig * Math.Sin((double)((float)m_ExporterConfig + num2 * (float)prototypeConfig / (exceptionConfig - recordConfig)) * CSMath.PI_dividedBy_180)), MatrixOrder.Append);
				if (num3 >= ScaleNumbersStartScaleLine - 1)
				{
					graphics.DrawString(text, Font, new SolidBrush(m_ParserConfig), (0f - sizeF.Width) / 2f, 0f - m_ConfigurationConfig - (tokenConfig - m_ConfigurationConfig + 1f) / 2f, StringFormat.GenericTypographic);
				}
				num2 += regConfig;
				num3++;
			}
			graphics.ResetTransform();
			graphics.SetClip(base.ClientRectangle);
			if (messageConfig != 0)
			{
				graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
			}
			for (int l = 0; l < 5; l++)
			{
				if (_UtilsConfig[l] != "")
				{
					graphics.DrawString(_UtilsConfig[l], Font, new SolidBrush(m_SchemaConfig[l]), predicateConfig[l].X, predicateConfig[l].Y, StringFormat.GenericTypographic);
				}
			}
		}
		if (!base.Enabled)
		{
			return;
		}
		e.Graphics.DrawImageUnscaled(m_IndexerConfig, 0, 0);
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
		float num4 = (int)((float)m_ExporterConfig + (_PublisherConfig - recordConfig) * (float)prototypeConfig / (exceptionConfig - recordConfig)) % 360;
		double num5 = (double)num4 * CSMath.PI_dividedBy_180;
		switch (m_ProductConfig)
		{
		case 1:
		{
			Point point = new Point((int)((double)Center.X - (double)(m_AnnotationConfig / 8) * Math.Cos(num5)), (int)((double)Center.Y - (double)(m_AnnotationConfig / 8) * Math.Sin(num5)));
			Point point2 = new Point((int)((double)Center.X + (double)m_AnnotationConfig * Math.Cos(num5)), (int)((double)Center.Y + (double)m_AnnotationConfig * Math.Sin(num5)));
			e.Graphics.FillEllipse(new SolidBrush(_InitializerConfig), Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
			switch (_IteratorConfig)
			{
			case NeedleColorEnum.Gray:
				e.Graphics.DrawLine(new Pen(Color.DarkGray, m_RoleConfig), Center.X, Center.Y, point2.X, point2.Y);
				e.Graphics.DrawLine(new Pen(Color.DarkGray, m_RoleConfig), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Red:
				e.Graphics.DrawLine(new Pen(Color.Red, m_RoleConfig), Center.X, Center.Y, point2.X, point2.Y);
				e.Graphics.DrawLine(new Pen(Color.Red, m_RoleConfig), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Green:
				e.Graphics.DrawLine(new Pen(Color.Green, m_RoleConfig), Center.X, Center.Y, point2.X, point2.Y);
				e.Graphics.DrawLine(new Pen(Color.Green, m_RoleConfig), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Blue:
				e.Graphics.DrawLine(new Pen(Color.Blue, m_RoleConfig), Center.X, Center.Y, point2.X, point2.Y);
				e.Graphics.DrawLine(new Pen(Color.Blue, m_RoleConfig), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Yellow:
				e.Graphics.DrawLine(new Pen(Color.Yellow, m_RoleConfig), Center.X, Center.Y, point2.X, point2.Y);
				e.Graphics.DrawLine(new Pen(Color.Yellow, m_RoleConfig), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Violet:
				e.Graphics.DrawLine(new Pen(Color.Violet, m_RoleConfig), Center.X, Center.Y, point2.X, point2.Y);
				e.Graphics.DrawLine(new Pen(Color.Violet, m_RoleConfig), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Magenta:
				e.Graphics.DrawLine(new Pen(Color.Magenta, m_RoleConfig), Center.X, Center.Y, point2.X, point2.Y);
				e.Graphics.DrawLine(new Pen(Color.Magenta, m_RoleConfig), Center.X, Center.Y, point.X, point.Y);
				break;
			}
			break;
		}
		case 0:
		{
			PointF[] array = new PointF[3];
			Brush brush = Brushes.White;
			Brush brush2 = Brushes.White;
			Brush brush3 = Brushes.White;
			Brush brush4 = Brushes.White;
			_ = Brushes.White;
			int num6 = (int)((num4 + 225f) % 180f * 100f / 180f);
			int num7 = (int)((num4 + 135f) % 180f * 100f / 180f);
			e.Graphics.FillEllipse(new SolidBrush(_InitializerConfig), Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
			switch (_IteratorConfig)
			{
			case NeedleColorEnum.Gray:
				brush = new SolidBrush(Color.FromArgb(80 + num6, 80 + num6, 80 + num6));
				brush2 = new SolidBrush(Color.FromArgb(180 - num6, 180 - num6, 180 - num6));
				brush3 = new SolidBrush(Color.FromArgb(80 + num7, 80 + num7, 80 + num7));
				brush4 = new SolidBrush(Color.FromArgb(180 - num7, 180 - num7, 180 - num7));
				e.Graphics.DrawEllipse(Pens.Gray, Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
				break;
			case NeedleColorEnum.Red:
				brush = new SolidBrush(Color.FromArgb(145 + num6, num6, num6));
				brush2 = new SolidBrush(Color.FromArgb(245 - num6, 100 - num6, 100 - num6));
				brush3 = new SolidBrush(Color.FromArgb(145 + num7, num7, num7));
				brush4 = new SolidBrush(Color.FromArgb(245 - num7, 100 - num7, 100 - num7));
				e.Graphics.DrawEllipse(Pens.Red, Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
				break;
			case NeedleColorEnum.Green:
				brush = new SolidBrush(Color.FromArgb(num6, 145 + num6, num6));
				brush2 = new SolidBrush(Color.FromArgb(100 - num6, 245 - num6, 100 - num6));
				brush3 = new SolidBrush(Color.FromArgb(num7, 145 + num7, num7));
				brush4 = new SolidBrush(Color.FromArgb(100 - num7, 245 - num7, 100 - num7));
				e.Graphics.DrawEllipse(Pens.Green, Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
				break;
			case NeedleColorEnum.Blue:
				brush = new SolidBrush(Color.FromArgb(num6, num6, 145 + num6));
				brush2 = new SolidBrush(Color.FromArgb(100 - num6, 100 - num6, 245 - num6));
				brush3 = new SolidBrush(Color.FromArgb(num7, num7, 145 + num7));
				brush4 = new SolidBrush(Color.FromArgb(100 - num7, 100 - num7, 245 - num7));
				e.Graphics.DrawEllipse(Pens.Blue, Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
				break;
			case NeedleColorEnum.Yellow:
				brush = new SolidBrush(Color.FromArgb(145 + num6, 145 + num6, num6));
				brush2 = new SolidBrush(Color.FromArgb(245 - num6, 245 - num6, 100 - num6));
				brush3 = new SolidBrush(Color.FromArgb(145 + num7, 145 + num7, num7));
				brush4 = new SolidBrush(Color.FromArgb(245 - num7, 245 - num7, 100 - num7));
				e.Graphics.DrawEllipse(Pens.Violet, Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
				break;
			case NeedleColorEnum.Violet:
				brush = new SolidBrush(Color.FromArgb(145 + num6, num6, 145 + num6));
				brush2 = new SolidBrush(Color.FromArgb(245 - num6, 100 - num6, 245 - num6));
				brush3 = new SolidBrush(Color.FromArgb(145 + num7, num7, 145 + num7));
				brush4 = new SolidBrush(Color.FromArgb(245 - num7, 100 - num7, 245 - num7));
				e.Graphics.DrawEllipse(Pens.Violet, Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
				break;
			case NeedleColorEnum.Magenta:
				brush = new SolidBrush(Color.FromArgb(num6, 145 + num6, 145 + num6));
				brush2 = new SolidBrush(Color.FromArgb(100 - num6, 245 - num6, 245 - num6));
				brush3 = new SolidBrush(Color.FromArgb(num7, 145 + num7, 145 + num7));
				brush4 = new SolidBrush(Color.FromArgb(100 - num7, 245 - num7, 245 - num7));
				e.Graphics.DrawEllipse(Pens.Magenta, Center.X - m_RoleConfig * 3, Center.Y - m_RoleConfig * 3, m_RoleConfig * 6, m_RoleConfig * 6);
				break;
			}
			if (Math.Floor((float)((double)((num4 + 225f) % 360f) / 180.0)) == 0.0)
			{
				Brush brush5 = brush;
				brush = brush2;
				brush2 = brush5;
			}
			if (Math.Floor((float)((double)((num4 + 135f) % 360f) / 180.0)) == 0.0)
			{
				brush4 = brush3;
			}
			array[0].X = (float)((double)Center.X + (double)m_AnnotationConfig * Math.Cos(num5));
			array[0].Y = (float)((double)Center.Y + (double)m_AnnotationConfig * Math.Sin(num5));
			array[1].X = (float)((double)Center.X - (double)(m_AnnotationConfig / 20) * Math.Cos(num5));
			array[1].Y = (float)((double)Center.Y - (double)(m_AnnotationConfig / 20) * Math.Sin(num5));
			array[2].X = (float)((double)Center.X - (double)(m_AnnotationConfig / 5) * Math.Cos(num5) + (double)(m_RoleConfig * 2) * Math.Cos(num5 + Math.PI / 2.0));
			array[2].Y = (float)((double)Center.Y - (double)(m_AnnotationConfig / 5) * Math.Sin(num5) + (double)(m_RoleConfig * 2) * Math.Sin(num5 + Math.PI / 2.0));
			e.Graphics.FillPolygon(brush, array);
			array[2].X = (float)((double)Center.X - (double)(m_AnnotationConfig / 5) * Math.Cos(num5) + (double)(m_RoleConfig * 2) * Math.Cos(num5 - Math.PI / 2.0));
			array[2].Y = (float)((double)Center.Y - (double)(m_AnnotationConfig / 5) * Math.Sin(num5) + (double)(m_RoleConfig * 2) * Math.Sin(num5 - Math.PI / 2.0));
			e.Graphics.FillPolygon(brush2, array);
			array[0].X = (float)((double)Center.X - (double)(m_AnnotationConfig / 20 - 1) * Math.Cos(num5));
			array[0].Y = (float)((double)Center.Y - (double)(m_AnnotationConfig / 20 - 1) * Math.Sin(num5));
			array[1].X = (float)((double)Center.X - (double)(m_AnnotationConfig / 5) * Math.Cos(num5) + (double)(m_RoleConfig * 2) * Math.Cos(num5 + Math.PI / 2.0));
			array[1].Y = (float)((double)Center.Y - (double)(m_AnnotationConfig / 5) * Math.Sin(num5) + (double)(m_RoleConfig * 2) * Math.Sin(num5 + Math.PI / 2.0));
			array[2].X = (float)((double)Center.X - (double)(m_AnnotationConfig / 5) * Math.Cos(num5) + (double)(m_RoleConfig * 2) * Math.Cos(num5 - Math.PI / 2.0));
			array[2].Y = (float)((double)Center.Y - (double)(m_AnnotationConfig / 5) * Math.Sin(num5) + (double)(m_RoleConfig * 2) * Math.Sin(num5 - Math.PI / 2.0));
			e.Graphics.FillPolygon(brush4, array);
			array[0].X = (float)((double)Center.X - (double)(m_AnnotationConfig / 20) * Math.Cos(num5));
			array[0].Y = (float)((double)Center.Y - (double)(m_AnnotationConfig / 20) * Math.Sin(num5));
			array[1].X = (float)((double)Center.X + (double)m_AnnotationConfig * Math.Cos(num5));
			array[1].Y = (float)((double)Center.Y + (double)m_AnnotationConfig * Math.Sin(num5));
			e.Graphics.DrawLine(new Pen(_InitializerConfig), Center.X, Center.Y, array[0].X, array[0].Y);
			e.Graphics.DrawLine(new Pen(_InitializerConfig), Center.X, Center.Y, array[1].X, array[1].Y);
			break;
		}
		}
	}

	protected override void OnResize(EventArgs e)
	{
		resolverConfig = true;
		Refresh();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _AttributeConfig != null)
		{
			_AttributeConfig.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InvokeObserver()
	{
		_AttributeConfig = new Container();
	}
}
