using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSMaterial;
using Command.Listeners;
using Command.Records;
using Command.Specifications;
using DirectN;
using Efundies;
using ExWorldWind;
using Imazen.WebP;
using OpenDis.Common;
using OpenDis.Pages;

namespace DXRenderer;

public class Main
{
	private struct PoolRuleWatcher
	{
		internal Matrix4x4 _EventPrototype;

		internal float m_GlobalPrototype;

		internal float _WorkerPrototype;

		internal float accountPrototype;

		internal float _StatePrototype;

		internal uint m_AuthenticationPrototype;

		internal uint Row;

		internal int _ParamsPrototype;

		internal float m_InfoPrototype;
	}

	private struct InstanceMerchantPage
	{
		internal uint _HelperPrototype;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] Padding;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] m_MapperPrototype;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] m_ManagerPrototype;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] getterPrototype;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] m_ProducerPrototype;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal uint[] procPrototype;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal uint[] Row;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal int[] _StructComparator;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] merchantComparator;
	}

	[CompilerGenerated]
	private sealed class ParserMerchantService
	{
		public Layer mapOverlayType;

		public Main _003C_003E4__this;

		public OSM_MBTiles_Layer tileMapRenderType;

		public int zoom;

		public int row;

		public FileSystemLayer mapFileSystemRenderType;
	}

	[CompilerGenerated]
	private sealed class CallbackConfigManager
	{
		public int int_0;

		public string string_0;

		public ParserMerchantService CS_0024_003C_003E8__locals1;

		internal void PushInterruptibleMock()
		{
			switch (CS_0024_003C_003E8__locals1.mapOverlayType)
			{
			case Layer.FileSystem:
				switch (CS_0024_003C_003E8__locals1.mapFileSystemRenderType)
				{
				case FileSystemLayer.BMNG:
					CS_0024_003C_003E8__locals1._003C_003E4__this.LogoutIssuer(string_0, bool_0: false);
					break;
				case FileSystemLayer.Stamen:
					switch (CS_0024_003C_003E8__locals1._003C_003E4__this._WrapperVal)
					{
					case StamenLayer.Terrain:
					{
						string string_3 = string_0.Substring(15);
						CS_0024_003C_003E8__locals1._003C_003E4__this.TestIssuer(string_0, string_3, "Stamen Terrain", "/WW/Cache/Stamen Terrain/", "http://tile.stamen.com/terrain/", ImageFormat.png);
						break;
					}
					case StamenLayer.Labels:
					{
						string string_2 = string_0.Substring(24);
						CS_0024_003C_003E8__locals1._003C_003E4__this.TestIssuer(string_0, string_2, "Stamen Labels", "/WW/Cache/Stamen Terrain - Labels/", "http://warfaresims.slitherine.com/MapTiles/Labels/", ImageFormat.png);
						break;
					}
					case StamenLayer.Lines:
					{
						string string_ = string_0.Substring(23);
						CS_0024_003C_003E8__locals1._003C_003E4__this.TestIssuer(string_0, string_, "Stamen Lines", "/WW/Cache/Stamen Terrain - Lines/", "http://tile.stamen.com/terrain-lines/", ImageFormat.png);
						break;
					}
					}
					break;
				case FileSystemLayer.Sentinel:
				{
					if (CS_0024_003C_003E8__locals1._003C_003E4__this.m_RegistryVal == null)
					{
						CS_0024_003C_003E8__locals1._003C_003E4__this.TestIssuer(string_0, string_0, "Sentinel", "\\WW\\Cache\\S2Cloudless_webp\\", "http://warfaresims.slitherine.com/MapTiles/S2Cloudless_webp/", ImageFormat.webp);
						break;
					}
					byte[] array4 = CS_0024_003C_003E8__locals1._003C_003E4__this.RestartIssuer(CS_0024_003C_003E8__locals1.tileMapRenderType, CS_0024_003C_003E8__locals1.zoom, CS_0024_003C_003E8__locals1.row, int_0);
					if (array4 != null)
					{
						CS_0024_003C_003E8__locals1._003C_003E4__this.CallIssuer(string_0, array4, ImageFormat.webp);
					}
					break;
				}
				case FileSystemLayer.OpenTopo:
					CS_0024_003C_003E8__locals1._003C_003E4__this.TestIssuer(string_0, string_0, "OpenTopo", "/WW/Cache/OpenTopoMap/", "https://tile.opentopomap.org/", ImageFormat.png);
					break;
				}
				break;
			case Layer.OSM:
			{
				byte[] array2 = CS_0024_003C_003E8__locals1._003C_003E4__this.RestartIssuer(CS_0024_003C_003E8__locals1.tileMapRenderType, CS_0024_003C_003E8__locals1.zoom, CS_0024_003C_003E8__locals1.row, int_0);
				if (array2 != null)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.CallIssuer(string_0, array2, ImageFormat.webp);
				}
				break;
			}
			case Layer.BMNGOSM:
			{
				byte[] array3 = CS_0024_003C_003E8__locals1._003C_003E4__this.RestartIssuer(CS_0024_003C_003E8__locals1.tileMapRenderType, CS_0024_003C_003E8__locals1.zoom, CS_0024_003C_003E8__locals1.row, int_0);
				if (array3 != null)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.CallIssuer(string_0, array3, ImageFormat.webp);
				}
				break;
			}
			case Layer.Bing:
			{
				byte[] array = CS_0024_003C_003E8__locals1._003C_003E4__this.CancelIssuer(string_0);
				if (array != null)
				{
					Bitmap bitmap_ = new Bitmap(new MemoryStream(array));
					CS_0024_003C_003E8__locals1._003C_003E4__this.ValidateIssuer(string_0, bitmap_, bool_0: false);
				}
				break;
			}
			case Layer.OSMOSM:
			case Layer.const_4:
			case Layer.Line:
				break;
			}
		}
	}

	[CompilerGenerated]
	private sealed class AlgoMerchantService
	{
		public Main _003C_003E4__this;

		public int number;

		public int from;

		public List<DrawParameters> parameters_array;

		public int int_0;

		internal void InvokeInterruptibleMock(ref D3D11_MAPPED_SUBRESOURCE mapped, ref PoolRuleWatcher buffer)
		{
			buffer._EventPrototype = _003C_003E4__this.procDefinition;
		}

		internal void SetupInterruptibleMock(ref D3D11_MAPPED_SUBRESOURCE mapped, ref InstanceMerchantPage buffer)
		{
			buffer._HelperPrototype = (uint)number;
			int num = 0;
			for (int i = from; i < int_0; i++)
			{
				DrawParameters drawParameters = parameters_array[i];
				buffer.m_MapperPrototype[num] = drawParameters._StrategyDefinition;
				buffer.m_ManagerPrototype[num] = drawParameters._ConfigurationDefinition;
				buffer.getterPrototype[num] = drawParameters._TokenDefinition;
				buffer.m_ProducerPrototype[num] = drawParameters.indexerDefinition;
				buffer.Row[num] = drawParameters.Row;
				buffer.procPrototype[num] = drawParameters._PublisherDefinition;
				buffer._StructComparator[num] = (int)drawParameters.resolverDefinition;
				buffer.merchantComparator[num] = drawParameters.m_SingletonDefinition;
				num++;
			}
		}
	}

	[CompilerGenerated]
	private sealed class CallbackComparator
	{
		public DrawParameters drawItem;

		public Main _003C_003E4__this;

		internal void ExcludeInterruptibleMock(ref D3D11_MAPPED_SUBRESOURCE mapped, ref PoolRuleWatcher buffer)
		{
			switch (drawItem.codeDefinition)
			{
			case Projection.Icon:
				buffer._EventPrototype = _003C_003E4__this.m_StructVal;
				break;
			case Projection.Globe:
				buffer._EventPrototype = _003C_003E4__this.procDefinition;
				break;
			}
			buffer.m_GlobalPrototype = drawItem._StrategyDefinition;
			buffer._WorkerPrototype = drawItem._ConfigurationDefinition;
			buffer.accountPrototype = drawItem._TokenDefinition;
			buffer._StatePrototype = drawItem.indexerDefinition;
			buffer.Row = drawItem.Row;
			buffer.m_AuthenticationPrototype = drawItem._PublisherDefinition;
			buffer._ParamsPrototype = (int)drawItem.resolverDefinition;
			buffer.m_InfoPrototype = drawItem.m_SingletonDefinition;
		}
	}

	public static Main Instance;

	internal ValueDefinitionSpec _ExceptionDefinition;

	internal const float m_AttrDefinition = (float)Math.PI;

	private Vector4 _VisitorDefinition = new Vector4(0f, 0f, 0f, 1f);

	private Vector4 _ExporterDefinition = new Vector4(1f, 0f, 0f, 1f);

	private Vector4 prototypeDefinition = new Vector4(0f, 0f, 1f, 1f);

	private readonly Color _ComparatorDefinition = Color.FromArgb(0, 255, 255, 255);

	private readonly UnsafeColor itemDefinition = new UnsafeColor(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private readonly Color _SetterDefinition = Color.FromArgb(127, 0, 0, 0);

	public const float EARTH_MEAN_RADIUS = 6378137f;

	private readonly string _CreatorDefinition;

	private readonly int[] _TemplateDefinition = new int[5] { 8, 16, 32, 64, 128 };

	private readonly int[] m_MappingDefinition = new int[18]
	{
		1, 2, 4, 8, 16, 32, 64, 128, 256, 512,
		1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072
	};

	private readonly int _MockDefinition;

	private readonly int tagDefinition;

	private readonly int m_FieldDefinition;

	private readonly int _QueueDefinition;

	internal int _RegDefinition;

	public int ScreenHeight;

	public bool Ready;

	public bool Drawing;

	private readonly IComObject<IWICImagingFactory> _ParamDefinition;

	private readonly Dictionary<string, ID2D1Bitmap> pageDefinition;

	public string AdapterDescription;

	private IComObject<ID3D11Device> m_RulesDefinition;

	private IComObject<ID3D11DeviceContext> methodDefinition;

	private ID3DUserDefinedAnnotation serviceDefinition;

	private IComObject<ID3D11RenderTargetView> systemDefinition;

	private IComObject<ID3D11DepthStencilView> m_CandidateDefinition;

	private IComObject<IDXGISwapChain1> _BaseDefinition;

	private IComObject<ID2D1Factory1> policyDefinition;

	private IComObject<ID3D11InputLayout> _BroadcasterDefinition;

	public IComObject<ID3D11Buffer> ConstantBuffer;

	public IComObject<ID3D11Buffer> ConstantBufferArray;

	private IComObject<ID3D11VertexShader> m_IdentifierDefinition;

	private IComObject<ID3D11PixelShader> m_PrinterDefinition;

	private IComObject<ID3D11PixelShader> m_ParserDefinition;

	private IComObject<ID3D11PixelShader> algoDefinition;

	private IComObject<ID3D11PixelShader> m_DatabaseDefinition;

	private IComObject<ID3D11PixelShader> m_InterceptorDefinition;

	private IComObject<ID3D11PixelShader> m_MessageDefinition;

	private IComObject<ID3D11RasterizerState> productDefinition;

	private IComObject<ID2D1RenderTarget> annotationDefinition;

	private IComObject<IDWriteFactory> m_IteratorDefinition;

	private DrawParameters initializerDefinition;

	private DrawParameters _RoleDefinition;

	private DrawParameters _FactoryDefinition;

	private readonly OrderedDictionary m_AttributeDefinition;

	private readonly Dictionary<string, DrawParameters> m_EventDefinition;

	private readonly float[] m_GlobalDefinition = new float[4];

	private readonly IComObject<ID3D11BlendState> workerDefinition;

	private readonly IComObject<ID3D11BlendState> accountDefinition;

	private readonly PolygonLayer _StateDefinition;

	private readonly PolygonLayer authenticationDefinition;

	private readonly PolygonLayer m_ParamsDefinition;

	public Borders Borders = Borders.Newer;

	private float _InfoDefinition;

	private readonly IComObject<ID3D11DepthStencilState> _HelperDefinition;

	private readonly IComObject<ID3D11BlendState> m_MapperDefinition;

	private readonly bool _ManagerDefinition;

	internal uint _GetterDefinition = 10u;

	private readonly float producerDefinition = (float)Math.PI / 4f;

	private Matrix4x4 procDefinition;

	private Matrix4x4 m_StructVal;

	private readonly Dictionary<Color, IComObject<ID2D1SolidColorBrush>> _MerchantVal;

	private readonly Dictionary<string, IComObject<ID3D11ShaderResourceView>> _CallbackVal;

	private readonly ConcurrentQueue<SpecificationVal> decoratorVal;

	private readonly ConcurrentDictionary<string, DrawParameters> _ProcessVal;

	internal readonly List<SerializerDefinition> threadVal;

	private readonly Queue<string> _RuleVal;

	private readonly int m_CollectionVal;

	private int m_InstanceVal;

	private int _ObjectVal;

	internal readonly SQLiteConnection _ParameterVal;

	internal readonly SQLiteConnection _ExpressionVal;

	internal readonly SQLiteConnection _DispatcherVal;

	internal readonly SQLiteConnection m_ListenerVal;

	internal readonly SQLiteConnection _ConfigVal;

	internal readonly SQLiteConnection m_RegistryVal;

	private readonly SQLiteConnection _DefinitionVal;

	private readonly SimpleDecoder valVal;

	public RenderState RenderState = new RenderState
	{
		BingMap = false,
		SentinelMap = false,
		ReliefBathymetryMap = false,
		BMNGMap = false,
		bool_0 = false,
		LandCoverOverlay = false,
		StamenTerrainOverlay = false,
		StamenLinesOverlay = false,
		PlacenamesOverlay = false,
		BaseEarth = false
	};

	internal StamenLayer _WrapperVal = StamenLayer.None;

	private float observerVal;

	private float issuerVal;

	private float _ClientVal;

	internal bool m_DicVal;

	internal uint _ConsumerVal;

	public bool Initialized;

	public bool Resizing;

	public readonly DrawArgs DrawArgs = DrawArgs.Instance;

	private readonly LatLongGrid m_FacadeVal;

	private readonly Scale m_ProxyVal;

	private readonly ID2D1StrokeStyle m_ReaderVal;

	private readonly ID2D1StrokeStyle propertyVal;

	private readonly Dictionary<Color, ID2D1LinearGradientBrush> m_ImporterVal = new Dictionary<Color, ID2D1LinearGradientBrush>();

	private LRUCache<(string, float), IComObject<IDWriteTextFormat>> _RepositoryVal = new LRUCache<(string, float), IComObject<IDWriteTextFormat>>(1000, bool_0: true);

	private LRUCache<(IComObject<IDWriteTextFormat>, string), IComObject<IDWriteTextLayout>> bridgeVal = new LRUCache<(IComObject<IDWriteTextFormat>, string), IComObject<IDWriteTextLayout>>(1000, bool_0: true);

	private LRUCache<(string, float), Rectangle> invocationVal = new LRUCache<(string, float), Rectangle>(3, bool_0: true);

	private IComObject<ID3D11Texture2D> classVal;

	private IComObject<ID3D11ShaderResourceView> _RequestVal;

	private List<ID2D1Geometry> valueVal = new List<ID2D1Geometry>();

	public Main(string string_0, Control control_0, int int_0, int int_1)
	{
		Instance = this;
		_CreatorDefinition = string_0;
		_MockDefinition = int_0;
		tagDefinition = int_1;
		_QueueDefinition = _MockDefinition;
		_RegDefinition = control_0.ClientRectangle.Width;
		ScreenHeight = control_0.ClientRectangle.Height - _MockDefinition - tagDefinition;
		valVal = new SimpleDecoder();
		m_AttributeDefinition = new OrderedDictionary();
		_MerchantVal = new Dictionary<Color, IComObject<ID2D1SolidColorBrush>>();
		_CallbackVal = new Dictionary<string, IComObject<ID3D11ShaderResourceView>>();
		m_EventDefinition = new Dictionary<string, DrawParameters>();
		decoratorVal = new ConcurrentQueue<SpecificationVal>();
		_ProcessVal = new ConcurrentDictionary<string, DrawParameters>();
		m_CollectionVal = 300;
		_RuleVal = new Queue<string>();
		threadVal = new List<SerializerDefinition>();
		Ready = CountIssuer(control_0);
		_ParamDefinition = new ComObject<IWICImagingFactory>((IWICImagingFactory)new WicImagingFactory());
		pageDefinition = new Dictionary<string, ID2D1Bitmap>();
		m_StructVal = RemoveIssuer();
		initializerDefinition.codeDefinition = Projection.Globe;
		initializerDefinition._UtilsDefinition = D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
		initializerDefinition.m_ServerDefinition = false;
		_RoleDefinition = initializerDefinition;
		_RoleDefinition.proccesorDefinition = LogoutIssuer(_CreatorDefinition + "/WW/Data/Earth/BmngBathy/world.topo.bathy.200407.jpg", bool_0: true);
		_RoleDefinition.resolverDefinition = Layer.BaseEarth;
		_FactoryDefinition.codeDefinition = Projection.Globe;
		_FactoryDefinition._UtilsDefinition = D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
		_FactoryDefinition.m_ServerDefinition = false;
		_FactoryDefinition.resolverDefinition = Layer.DayNight;
		D3D11_BLEND_DESC val = new D3D11_BLEND_DESC
		{
			AlphaToCoverageEnable = false,
			IndependentBlendEnable = false
		};
		val.RenderTarget = new D3D11_RENDER_TARGET_BLEND_DESC[8];
		val.RenderTarget[0] = new D3D11_RENDER_TARGET_BLEND_DESC
		{
			BlendEnable = true,
			SrcBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
			DestBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
			BlendOp = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
			SrcBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
			DestBlendAlpha = D3D11_BLEND.D3D11_BLEND_ZERO,
			BlendOpAlpha = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
			RenderTargetWriteMask = 15
		};
		workerDefinition = m_RulesDefinition.CreateBlendState(val);
		val.RenderTarget[0] = new D3D11_RENDER_TARGET_BLEND_DESC
		{
			BlendEnable = true,
			SrcBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
			DestBlend = D3D11_BLEND.D3D11_BLEND_DEST_ALPHA,
			BlendOp = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
			SrcBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
			DestBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
			BlendOpAlpha = D3D11_BLEND_OP.D3D11_BLEND_OP_MAX,
			RenderTargetWriteMask = 15
		};
		accountDefinition = m_RulesDefinition.CreateBlendState(val);
		D3D11_DEPTH_STENCIL_DESC val2 = new D3D11_DEPTH_STENCIL_DESC
		{
			DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_ALWAYS
		};
		_HelperDefinition = m_RulesDefinition.CreateDepthStencilState(val2);
		val.RenderTarget[0] = new D3D11_RENDER_TARGET_BLEND_DESC
		{
			BlendEnable = true,
			SrcBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
			DestBlend = D3D11_BLEND.D3D11_BLEND_INV_SRC_ALPHA,
			BlendOp = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
			SrcBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
			DestBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
			BlendOpAlpha = D3D11_BLEND_OP.D3D11_BLEND_OP_MAX,
			RenderTargetWriteMask = 15
		};
		m_MapperDefinition = m_RulesDefinition.CreateBlendState(val);
		_ParameterVal = RevertObserver(_CreatorDefinition + "\\WW\\Cache\\BMNGv2_webp.mbtiles");
		_ExpressionVal = RevertObserver(_CreatorDefinition + "\\WW\\Cache\\Relief_90_webp.mbtiles");
		_DispatcherVal = RevertObserver(_CreatorDefinition + "\\WW\\Cache\\Bathymetry.mbtiles");
		m_ListenerVal = RevertObserver(_CreatorDefinition + "\\WW\\Cache\\Relief_SRTM3_webp.mbtiles");
		_ConfigVal = RevertObserver(_CreatorDefinition + "\\WW\\Cache\\LandCover_300_webp.mbtiles");
		string text = _CreatorDefinition + "\\WW\\Cache\\S2Cloudless_webp.mbtiles";
		string text2 = _CreatorDefinition + "\\WW\\Cache\\S2_Cloudless_webp\\TileManifest.db3";
		if (File.Exists(text))
		{
			m_RegistryVal = RevertObserver(text);
		}
		else if (File.Exists(text2))
		{
			_DefinitionVal = RevertObserver(text2);
		}
		_StateDefinition = new PolygonLayer(_CreatorDefinition + "\\GIS\\MappingHacks\\world_borders_1976-1989.shp");
		authenticationDefinition = new PolygonLayer(_CreatorDefinition + "\\GIS\\MappingHacks\\world_borders.shp");
		m_ParamsDefinition = new PolygonLayer(_CreatorDefinition + "\\GIS\\SeaIce\\Arctic\\nic_autoc2012270n_pl_a.shp");
		D2D1_STROKE_STYLE_PROPERTIES val3 = new D2D1_STROKE_STYLE_PROPERTIES
		{
			startCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
			endCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
			dashCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
			lineJoin = D2D1_LINE_JOIN.D2D1_LINE_JOIN_MITER,
			miterLimit = 0f,
			dashStyle = D2D1_DASH_STYLE.D2D1_DASH_STYLE_SOLID,
			dashOffset = 0f
		};
		HRESULT val4 = policyDefinition.Object.CreateStrokeStyle(ref val3, null, 0, out m_ReaderVal);
		HRESULT hRESULT = val4;
		_ = hRESULT.IsOk;
		val3.dashStyle = D2D1_DASH_STYLE.D2D1_DASH_STYLE_DASH;
		val4 = policyDefinition.Object.CreateStrokeStyle(ref val3, null, 0, out propertyVal);
		hRESULT = val4;
		_ = hRESULT.IsOk;
		m_FacadeVal = new LatLongGrid();
		m_ProxyVal = new Scale();
		Initialized = true;
	}

	private SQLiteConnection RevertObserver(string string_0)
	{
		try
		{
			SQLiteConnection val = new SQLiteConnection("Data Source=" + string_0 + ";Version=3;Read Only=True;");
			val.Open();
			return val;
		}
		catch (Exception innerException)
		{
			throw new Exception("Exception while opening SQLiteConnection for " + string_0, innerException);
		}
	}

	private bool CountIssuer(Control control_0)
	{
		IComObject<IDXGIFactory2> val = DXGIFunctions.CreateDXGIFactory2();
		IComObject<IDXGIAdapter> val3 = null;
		IEnumerator<IComObject<IDXGIAdapter>> enumerator = val.EnumAdapters().GetEnumerator();
		while (enumerator.MoveNext())
		{
			IComObject<IDXGIAdapter> current = enumerator.Current;
			IEnumerator<IComObject<IDXGIOutput1>> enumerator2 = current.EnumOutputs().GetEnumerator();
			bool flag = false;
			while (enumerator2.MoveNext())
			{
				flag = enumerator2.Current.GetDesc().AttachedToDesktop;
			}
			uint vendorId = current.GetDesc().VendorId;
			bool flag2 = 4098 == vendorId || 4318 == vendorId;
			if (val3 == null && flag && flag2)
			{
				val3 = current;
			}
		}
		if (val3 == null)
		{
			val3 = val.GetAdapter1(0);
		}
		try
		{
			m_RulesDefinition = D3D11Functions.D3D11CreateDevice(val3.Object, D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_UNKNOWN, D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT, out methodDefinition, new D3D_FEATURE_LEVEL[1] { D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0 });
			AdapterDescription = val3.GetDesc().Description;
		}
		catch
		{
			m_RulesDefinition = D3D11Functions.D3D11CreateDevice(null, D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_WARP, D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT, out methodDefinition, new D3D_FEATURE_LEVEL[1] { D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0 });
			AdapterDescription = "SOFTWARE RENDERER";
		}
		if (m_RulesDefinition == null)
		{
			return false;
		}
		serviceDefinition = (ID3DUserDefinedAnnotation)methodDefinition.Object;
		DXGI_SWAP_CHAIN_DESC1 val4 = default(DXGI_SWAP_CHAIN_DESC1);
		val4.Format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM;
		val4.BufferUsage = 32u;
		val4.BufferCount = 2u;
		val4.SwapEffect = DXGI_SWAP_EFFECT.DXGI_SWAP_EFFECT_FLIP_DISCARD;
		DXGI_SWAP_CHAIN_DESC1 val5 = val4;
		val5.SampleDesc.Count = 1u;
		val5.SampleDesc.Quality = 0u;
		_BaseDefinition = val.CreateSwapChainForHwnd<IDXGISwapChain1>(m_RulesDefinition, control_0.Handle, val5);
		if (_BaseDefinition == null)
		{
			return false;
		}
		IComObject<ID3D11Texture2D> buffer = _BaseDefinition.GetBuffer<ID3D11Texture2D>(0u);
		D3D11_TEXTURE2D_DESC val6 = default(D3D11_TEXTURE2D_DESC);
		buffer.Object.GetDesc(out val6);
		if (val6.Width == control_0.ClientRectangle.Width && val6.Height == control_0.ClientRectangle.Height)
		{
			systemDefinition = m_RulesDefinition.CreateRenderTargetView(buffer);
			buffer.Dispose();
			if (systemDefinition == null)
			{
				return false;
			}
			val6.Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT;
			val6.BindFlags = 64u;
			IComObject<ID3D11Texture2D> val7 = m_RulesDefinition.CreateTexture2D<ID3D11Texture2D>(val6);
			if (val7 == null)
			{
				return false;
			}
			m_CandidateDefinition = m_RulesDefinition.CreateDepthStencilView(val7);
			val7.Dispose();
			if (m_CandidateDefinition == null)
			{
				return false;
			}
			methodDefinition.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { systemDefinition.Object }, m_CandidateDefinition.Object);
			D3D11_VIEWPORT val8 = default(D3D11_VIEWPORT);
			val8.Width = _RegDefinition;
			val8.Height = ScreenHeight;
			val8.MinDepth = 0f;
			val8.MaxDepth = 1f;
			val8.TopLeftX = m_FieldDefinition;
			val8.TopLeftY = _QueueDefinition;
			D3D11_VIEWPORT val9 = val8;
			methodDefinition.Object.RSSetViewports(1, new D3D11_VIEWPORT[1] { val9 });
			if (CustomizeIssuer())
			{
				if (DestroyIssuer())
				{
					if (ComputeIssuer())
					{
						if (ConnectIssuer())
						{
							if (PatchIssuer())
							{
								m_IteratorDefinition = DWriteFunctions.DWriteCreateFactory();
								if (m_IteratorDefinition == null)
								{
									return false;
								}
								policyDefinition = D2D1Functions.D2D1CreateFactory1(D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_MULTI_THREADED, default(D2D1_FACTORY_OPTIONS));
								if (policyDefinition == null)
								{
									return false;
								}
								D2D1_RENDER_TARGET_PROPERTIES val10 = default(D2D1_RENDER_TARGET_PROPERTIES);
								val10.pixelFormat = new D2D1_PIXEL_FORMAT
								{
									alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
								};
								D2D1_RENDER_TARGET_PROPERTIES val2 = val10;
								IComObject<IDXGISurface> buffer2 = _BaseDefinition.GetBuffer<IDXGISurface>(0u);
								if (buffer2 == null)
								{
									return false;
								}
								annotationDefinition = policyDefinition.CreateDxgiSurfaceRenderTarget(buffer2, val2);
								buffer2.Dispose();
								if (annotationDefinition == null)
								{
									return false;
								}
								return true;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public void OnResize(Control control_0)
	{
		Resizing = true;
		_RegDefinition = control_0.ClientRectangle.Width;
		ScreenHeight = control_0.ClientRectangle.Height - _MockDefinition - tagDefinition;
		systemDefinition.Dispose();
		m_CandidateDefinition.Dispose();
		annotationDefinition.Dispose();
		HRESULT val = _BaseDefinition.Object.ResizeBuffers(2u, (uint)control_0.ClientRectangle.Width, (uint)control_0.ClientRectangle.Height, DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, 0u);
		HRESULT hRESULT = val;
		if (!hRESULT.IsOk)
		{
			return;
		}
		IComObject<ID3D11Texture2D> buffer = _BaseDefinition.GetBuffer<ID3D11Texture2D>(0u);
		D3D11_TEXTURE2D_DESC val2 = default(D3D11_TEXTURE2D_DESC);
		buffer.Object.GetDesc(out val2);
		if (val2.Width != control_0.ClientRectangle.Width || val2.Height != control_0.ClientRectangle.Height)
		{
			return;
		}
		systemDefinition = m_RulesDefinition.CreateRenderTargetView(buffer);
		buffer.Dispose();
		if (systemDefinition == null)
		{
			return;
		}
		val2.Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT;
		val2.BindFlags = 64u;
		IComObject<ID3D11Texture2D> val3 = m_RulesDefinition.CreateTexture2D<ID3D11Texture2D>(val2);
		if (val3 == null)
		{
			return;
		}
		m_CandidateDefinition = m_RulesDefinition.CreateDepthStencilView(val3);
		val3.Dispose();
		if (m_CandidateDefinition == null)
		{
			return;
		}
		methodDefinition.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { systemDefinition.Object }, m_CandidateDefinition.Object);
		D3D11_VIEWPORT val4 = default(D3D11_VIEWPORT);
		val4.Width = _RegDefinition;
		val4.Height = ScreenHeight;
		val4.MinDepth = 0f;
		val4.MaxDepth = 1f;
		val4.TopLeftX = m_FieldDefinition;
		val4.TopLeftY = _QueueDefinition;
		D3D11_VIEWPORT val5 = val4;
		methodDefinition.Object.RSSetViewports(1, new D3D11_VIEWPORT[1] { val5 });
		D2D1_RENDER_TARGET_PROPERTIES val6 = default(D2D1_RENDER_TARGET_PROPERTIES);
		val6.pixelFormat = new D2D1_PIXEL_FORMAT
		{
			alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
		};
		D2D1_RENDER_TARGET_PROPERTIES val7 = val6;
		IComObject<IDXGISurface> buffer2 = _BaseDefinition.GetBuffer<IDXGISurface>(0u);
		if (buffer2 != null)
		{
			annotationDefinition = policyDefinition.CreateDxgiSurfaceRenderTarget(buffer2, val7);
			buffer2.Dispose();
			if (annotationDefinition != null)
			{
				m_StructVal = RemoveIssuer();
				Resizing = false;
			}
		}
	}

	private bool CustomizeIssuer()
	{
		D3D11_RASTERIZER_DESC val = default(D3D11_RASTERIZER_DESC);
		val.FillMode = D3D11_FILL_MODE.D3D11_FILL_SOLID;
		val.CullMode = D3D11_CULL_MODE.D3D11_CULL_BACK;
		D3D11_RASTERIZER_DESC val2 = val;
		IComObject<ID3D11RasterizerState> val3 = m_RulesDefinition.CreateRasterizerState(val2);
		if (val3 == null)
		{
			return false;
		}
		val2.FillMode = D3D11_FILL_MODE.D3D11_FILL_WIREFRAME;
		if (m_RulesDefinition.CreateRasterizerState(val2) == null)
		{
			return false;
		}
		productDefinition = val3;
		return true;
	}

	private bool CloneIssuer()
	{
		_GetterDefinition++;
		return ConnectIssuer();
	}

	private bool ConnectIssuer()
	{
		if (AddIssuer(MoveIssuer(), ref initializerDefinition))
		{
			return AddIssuer(DeleteIssuer(100f), ref _FactoryDefinition);
		}
		return false;
	}

	private TestsObjectListener MoveIssuer()
	{
		return DeleteIssuer(0f);
	}

	private TestsObjectListener DeleteIssuer(float float_0)
	{
		uint num = (uint)Math.Pow(2.0, _GetterDefinition);
		if (num < 2)
		{
			return default(TestsObjectListener);
		}
		uint num12 = num * 2;
		uint num13 = 2 + (num - 1) * (num12 + 1);
		float num14 = 6378137f + float_0;
		float num15 = (float)Math.PI / (float)num;
		float num16 = (float)Math.PI * 2f / (float)num12;
		Vertex vertex = new Vertex(new Vector3(0f, num14, 0f), prototypeDefinition, new Vector2(0.5f, 0f));
		Vertex vertex2 = new Vertex(new Vector3(0f, 0f - num14, 0f), _ExporterDefinition, new Vector2(0.5f, 1f));
		Vertex[] array = new Vertex[num13];
		uint num17 = 0u;
		num17 = 1u;
		array[0] = vertex;
		for (uint num18 = 1u; num18 < num; num18++)
		{
			float num19 = (float)num18 * num15;
			for (uint num2 = 0u; num2 <= num12; num2++)
			{
				float num3 = (float)num2 * num16;
				Vector3 vector3_ = new Vector3(num14 * (float)(Math.Sin(num19) * Math.Cos(num3 + (float)Math.PI / 2f)), num14 * (float)Math.Cos(num19), num14 * (float)(Math.Sin(num19) * Math.Sin(num3 + (float)Math.PI / 2f)));
				Vertex vertex3 = new Vertex(vector3_, _VisitorDefinition, new Vector2(num3 / ((float)Math.PI * 2f), num19 / (float)Math.PI));
				array[num17++] = vertex3;
			}
		}
		array[num17++] = vertex2;
		uint[] array2 = new uint[((num - 2) * num12 * 2 + num12 * 2) * 3];
		uint num4 = 0u;
		for (uint num5 = 1u; num5 <= num12; num5++)
		{
			array2[num4++] = 0u;
			array2[num4++] = num5 + 1;
			array2[num4++] = num5;
		}
		uint num6 = 1u;
		uint num7 = num12 + 1;
		for (uint num8 = 0u; num8 < num - 2; num8++)
		{
			for (uint num9 = 0u; num9 < num12; num9++)
			{
				array2[num4++] = num6 + num8 * num7 + num9;
				array2[num4++] = num6 + num8 * num7 + num9 + 1;
				array2[num4++] = num6 + (num8 + 1) * num7 + num9;
				array2[num4++] = num6 + (num8 + 1) * num7 + num9;
				array2[num4++] = num6 + num8 * num7 + num9 + 1;
				array2[num4++] = num6 + (num8 + 1) * num7 + num9 + 1;
			}
		}
		uint num10 = num17 - 1;
		num6 = num10 - num7;
		for (uint num11 = 0u; num11 < num12; num11++)
		{
			array2[num4++] = num10;
			array2[num4++] = num6 + num11;
			array2[num4++] = num6 + num11 + 1;
		}
		TestsObjectListener result = default(TestsObjectListener);
		result.m_TokenizerVal = array;
		result._StubVal = array2;
		return result;
	}

	private bool AddIssuer(TestsObjectListener testsObjectListener_0, ref DrawParameters drawParameters_0)
	{
		int num = 2;
		if (drawParameters_0._UtilsDefinition == D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST)
		{
			num = 3;
		}
		if (testsObjectListener_0.m_TokenizerVal != null && testsObjectListener_0.m_TokenizerVal.Length >= num && testsObjectListener_0._StubVal != null && testsObjectListener_0._StubVal.Length >= num)
		{
			D3D11_BUFFER_DESC val = default(D3D11_BUFFER_DESC);
			val.ByteWidth = (uint)testsObjectListener_0.m_TokenizerVal.SizeOf();
			val.Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE;
			val.BindFlags = 1u;
			val.CPUAccessFlags = 0u;
			val.MiscFlags = 0u;
			val.StructureByteStride = 0u;
			D3D11_BUFFER_DESC val2 = val;
			GCHandle gCHandle = GCHandle.Alloc(testsObjectListener_0.m_TokenizerVal, GCHandleType.Pinned);
			D3D11_SUBRESOURCE_DATA val3 = default(D3D11_SUBRESOURCE_DATA);
			val3.pSysMem = gCHandle.AddrOfPinnedObject();
			val3.SysMemPitch = 0u;
			val3.SysMemSlicePitch = 0u;
			D3D11_SUBRESOURCE_DATA value = val3;
			drawParameters_0._ConnectionDefinition = m_RulesDefinition.CreateBuffer(val2, value);
			gCHandle.Free();
			if (drawParameters_0._ConnectionDefinition == null)
			{
				return false;
			}
			val = default(D3D11_BUFFER_DESC);
			val.ByteWidth = (uint)testsObjectListener_0._StubVal.SizeOf();
			val.Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE;
			val.BindFlags = 2u;
			val.CPUAccessFlags = 0u;
			val.MiscFlags = 0u;
			val.StructureByteStride = 0u;
			D3D11_BUFFER_DESC val4 = val;
			gCHandle = GCHandle.Alloc(testsObjectListener_0._StubVal, GCHandleType.Pinned);
			val3 = default(D3D11_SUBRESOURCE_DATA);
			val3.pSysMem = gCHandle.AddrOfPinnedObject();
			val3.SysMemPitch = 0u;
			val3.SysMemSlicePitch = 0u;
			D3D11_SUBRESOURCE_DATA value2 = val3;
			drawParameters_0._ContextDefinition = m_RulesDefinition.CreateBuffer(val4, value2);
			gCHandle.Free();
			drawParameters_0._StatusDefinition = (uint)testsObjectListener_0._StubVal.Length;
			if (drawParameters_0._ContextDefinition == null)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private bool DestroyIssuer()
	{
		D3D11_BUFFER_DESC val = default(D3D11_BUFFER_DESC);
		val.ByteWidth = (uint)Marshal.SizeOf<PoolRuleWatcher>();
		val.Usage = D3D11_USAGE.D3D11_USAGE_DYNAMIC;
		val.BindFlags = 4u;
		val.CPUAccessFlags = 65536u;
		val.MiscFlags = 0u;
		val.StructureByteStride = 0u;
		D3D11_BUFFER_DESC val2 = val;
		if (val2.ByteWidth % 16 == 0)
		{
			ConstantBuffer = m_RulesDefinition.CreateBuffer(val2);
			if (ConstantBuffer == null)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private bool ComputeIssuer()
	{
		D3D11_BUFFER_DESC val = default(D3D11_BUFFER_DESC);
		val.ByteWidth = (uint)Marshal.SizeOf<InstanceMerchantPage>();
		val.Usage = D3D11_USAGE.D3D11_USAGE_DYNAMIC;
		val.BindFlags = 4u;
		val.CPUAccessFlags = 65536u;
		val.MiscFlags = 0u;
		val.StructureByteStride = 0u;
		D3D11_BUFFER_DESC val2 = val;
		if (val2.ByteWidth % 16 == 0)
		{
			ConstantBufferArray = m_RulesDefinition.CreateBuffer(val2);
			if (ConstantBufferArray == null)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private bool PatchIssuer()
	{
		IComObject<ID3D10Blob> val = D3D11Functions.D3DCompileFromFile("shaders.hlsl", "vs_main", "vs_5_0");
		m_IdentifierDefinition = m_RulesDefinition.CreateVertexShader(val);
		if (m_IdentifierDefinition == null)
		{
			return false;
		}
		m_PrinterDefinition = SelectIssuer("ps_main");
		m_ParserDefinition = SelectIssuer("ps_tile");
		algoDefinition = SelectIssuer("ps_array");
		m_DatabaseDefinition = SelectIssuer("ps_line");
		m_InterceptorDefinition = SelectIssuer("ps_blendable_line");
		m_MessageDefinition = SelectIssuer("ps_daynight");
		D3D11_SAMPLER_DESC val2 = default(D3D11_SAMPLER_DESC);
		val2.Filter = D3D11_FILTER.D3D11_FILTER_ANISOTROPIC;
		val2.MaxAnisotropy = 4u;
		val2.AddressU = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP;
		val2.AddressV = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP;
		val2.AddressW = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP;
		D3D11_SAMPLER_DESC val3 = val2;
		IComObject<ID3D11SamplerState> val4 = m_RulesDefinition.CreateSamplerState(val3);
		methodDefinition.Object.PSSetSamplers(0u, 1, new ID3D11SamplerState[1] { val4.Object });
		D3D11_INPUT_ELEMENT_DESC[] array = new D3D11_INPUT_ELEMENT_DESC[3]
		{
			new D3D11_INPUT_ELEMENT_DESC
			{
				SemanticName = "POSITION",
				Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT
			},
			new D3D11_INPUT_ELEMENT_DESC
			{
				SemanticName = "COLOR",
				Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT,
				AlignedByteOffset = uint.MaxValue
			},
			new D3D11_INPUT_ELEMENT_DESC
			{
				SemanticName = "TEXCOORD",
				Format = DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT,
				AlignedByteOffset = uint.MaxValue
			}
		};
		_BroadcasterDefinition = m_RulesDefinition.CreateInputLayout(array, val);
		if (_BroadcasterDefinition == null)
		{
			return false;
		}
		return true;
	}

	private IComObject<ID3D11PixelShader> SelectIssuer(string string_0)
	{
		IComObject<ID3D10Blob> val = D3D11Functions.D3DCompileFromFile("shaders.hlsl", string_0, "ps_5_0");
		return m_RulesDefinition.CreatePixelShader(val) ?? throw new ShaderCreationException();
	}

	internal IComObject<ID3D11ShaderResourceView> CallIssuer(string string_0, byte[] byte_0, ImageFormat imageFormat_0)
	{
		Bitmap bitmap_;
		switch (imageFormat_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception();
		case ImageFormat.webp:
			bitmap_ = VerifyIssuer(byte_0);
			break;
		case ImageFormat.png:
		{
			using (MemoryStream stream = new MemoryStream(byte_0))
			{
				bitmap_ = new Bitmap(Image.FromStream(stream));
			}
			break;
		}
		}
		return ValidateIssuer(string_0, bitmap_, bool_0: false);
	}

	private IComObject<ID3D11ShaderResourceView> LogoutIssuer(string string_0, bool bool_0)
	{
		return ViewIssuer(string_0, bool_0, bool_1: false);
	}

	private IComObject<ID3D11ShaderResourceView> ViewIssuer(string string_0, bool bool_0, bool bool_1)
	{
		if (_CallbackVal.ContainsKey(string_0))
		{
			return _CallbackVal[string_0];
		}
		if (File.Exists(string_0))
		{
			try
			{
				Bitmap bitmap_ = new Bitmap(string_0);
				return LoginIssuer(string_0, bitmap_, bool_0, bool_1);
			}
			catch
			{
				if (_ProcessVal.TryGetValue(string_0, out var value))
				{
					value._RecordDefinition = true;
					_ProcessVal[string_0] = value;
				}
				return null;
			}
		}
		return null;
	}

	private IComObject<ID3D11ShaderResourceView> ValidateIssuer(string string_0, Bitmap bitmap_0, bool bool_0)
	{
		return LoginIssuer(string_0, bitmap_0, bool_0, bool_1: false);
	}

	private IComObject<ID3D11ShaderResourceView> LoginIssuer(string string_0, Bitmap bitmap_0, bool bool_0, bool bool_1)
	{
		if (_CallbackVal.ContainsKey(string_0))
		{
			return _CallbackVal[string_0];
		}
		int height = bitmap_0.Height;
		int width = bitmap_0.Width;
		float[] array = new float[height * width * 4];
		LockBitmap lockBitmap = new LockBitmap(bitmap_0);
		lockBitmap.LockBits();
		int num = 0;
		int depth = lockBitmap.Depth;
		int width2 = lockBitmap.Width;
		byte[] pixels = lockBitmap.Pixels;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				UnsafeColor unsafeColor = lockBitmap.GetPixel_UnsafeColor(j, i, depth, width2, pixels);
				if (bool_1 && unsafeColor.Equals(itemDefinition))
				{
					unsafeColor = new UnsafeColor(_SetterDefinition);
				}
				array[num++] = (float)(int)unsafeColor.R / 255f;
				array[num++] = (float)(int)unsafeColor.G / 255f;
				array[num++] = (float)(int)unsafeColor.B / 255f;
				array[num++] = (float)(int)unsafeColor.A / 255f;
			}
		}
		lockBitmap.UnlockBits();
		D3D11_TEXTURE2D_DESC val = default(D3D11_TEXTURE2D_DESC);
		val.Width = (uint)width;
		val.Height = (uint)height;
		val.MipLevels = 1u;
		val.ArraySize = 1u;
		val.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT;
		val.Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE;
		val.BindFlags = 8u;
		D3D11_TEXTURE2D_DESC val2 = val;
		val2.SampleDesc.Count = 1u;
		GCHandle reponseVal = GCHandle.Alloc(array, GCHandleType.Pinned);
		D3D11_SUBRESOURCE_DATA val3 = default(D3D11_SUBRESOURCE_DATA);
		val3.pSysMem = reponseVal.AddrOfPinnedObject();
		val3.SysMemPitch = (uint)(width * 4 * 4);
		D3D11_SUBRESOURCE_DATA val4 = val3;
		if (bool_0)
		{
			IComObject<ID3D11Texture2D> val5 = m_RulesDefinition.CreateTexture2D<ID3D11Texture2D>(val2, val4);
			reponseVal.Free();
			_CallbackVal.Add(string_0, m_RulesDefinition.CreateShaderResourceView(val5));
			return _CallbackVal[string_0];
		}
		SpecificationVal specificationVal = default(SpecificationVal);
		specificationVal.Path = string_0;
		specificationVal.Description = val2;
		specificationVal.watcherVal = val4;
		specificationVal._ReponseVal = reponseVal;
		SpecificationVal item = specificationVal;
		decoratorVal.Enqueue(item);
		return null;
	}

	private unsafe ID2D1Bitmap GetIssuer(string string_0, int int_0, int int_1, bool bool_0 = false)
	{
		string text = string_0;
		string_0 = string_0 + "." + int_0;
		string_0 = string_0 + "." + int_1;
		string_0 = (bool_0 ? (string_0 + ".shadow") : string_0);
		if (pageDefinition.TryGetValue(string_0, out var value))
		{
			return value;
		}
		IWICBitmapDecoder val = null;
		HRESULT val2 = _ParamDefinition.Object.CreateDecoderFromFilename(text, (IntPtr)(void*)null, 2147483648u, WICDecodeOptions.WICDecodeMetadataCacheOnDemand, out val);
		HRESULT hRESULT = val2;
		if (hRESULT.IsOk)
		{
			IWICBitmapFrameDecode val3 = null;
			val2 = val.GetFrame(0u, out val3);
			hRESULT = val2;
			_ = hRESULT.IsOk;
			IWICFormatConverter val4 = null;
			_ParamDefinition.Object.CreateFormatConverter(out val4);
			Guid gUID_WICPixelFormat32bppPBGRA = WICConstants.GUID_WICPixelFormat32bppPBGRA;
			val4.Initialize(val3, ref gUID_WICPixelFormat32bppPBGRA, WICBitmapDitherType.WICBitmapDitherTypeNone, null, 0.0, WICBitmapPaletteType.WICBitmapPaletteTypeCustom);
			IWICBitmap val5 = null;
			_ParamDefinition.Object.CreateBitmapFromSource(val4, WICBitmapCreateCacheOption.WICBitmapNoCache, out val5);
			WICRect val6 = default(WICRect);
			val6.X = 0;
			val6.Y = 0;
			val6.Width = (int)val5.GetSize().width;
			val6.Height = (int)val5.GetSize().height;
			WICRect val7 = val6;
			IWICBitmapLock val8 = null;
			val5.Lock(val7.StructureToPtr(), 1u, out val8);
			uint num = 0u;
			IntPtr source = default(IntPtr);
			val8.GetDataPointer(out num, out source);
			byte[] array = new byte[num];
			Marshal.Copy(source, array, 0, (int)num);
			uint num2 = 0u;
			val8.GetStride(out num2);
			ComObject.Release(val8);
			if (int_1 != -1)
			{
				int num3 = (int_0 << 24) | (int_1 & 0xFFFFFF);
				byte b = (byte)((num3 & 0xFF000000u) >> 24);
				byte b2 = (byte)((num3 & 0xFF0000) >> 16);
				byte b3 = (byte)((num3 & 0xFF00) >> 8);
				byte b4 = (byte)((uint)num3 & 0xFFu);
				b2 = (byte)(b2 * b / 255);
				b3 = (byte)(b3 * b / 255);
				b4 = (byte)(b4 * b / 255);
				for (int i = 0; i < num; i += 4)
				{
					if (array[i] == byte.MaxValue && array[i + 1] == byte.MaxValue && array[i + 2] == byte.MaxValue)
					{
						array[i] = b4;
						array[i + 1] = b3;
						array[i + 2] = b2;
						array[i + 3] = b;
					}
				}
			}
			if (bool_0)
			{
				for (int j = 0; j < num; j += 4)
				{
					if (array[j] != 0 || array[j + 1] != 0 || array[j + 2] != 0)
					{
						array[j] = 0;
						array[j + 1] = 0;
						array[j + 2] = 0;
						array[j + 3] = 127;
					}
				}
			}
			IWICBitmap val9 = null;
			_ParamDefinition.Object.CreateBitmapFromMemory((uint)val7.Width, (uint)val7.Height, ref gUID_WICPixelFormat32bppPBGRA, num2, (int)num, array, out val9);
			ID2D1Bitmap value2 = null;
			annotationDefinition.Object.CreateBitmapFromWicBitmap(val9, (IntPtr)(void*)null, out value2);
			pageDefinition[string_0] = value2;
			return pageDefinition[string_0];
		}
		return null;
	}

	private int WriteIssuer(float float_0)
	{
		if (float_0 <= 2000000f)
		{
			if (float_0 <= 1200000f)
			{
				if (float_0 <= 900000f)
				{
					if (float_0 <= 600000f)
					{
						return 4;
					}
					return 3;
				}
				return 2;
			}
			return 1;
		}
		return 0;
	}

	private int NewIssuer(float float_0)
	{
		return PushIssuer(float_0, 1f);
	}

	private int PushIssuer(float float_0, float float_1)
	{
		if (float_0 <= 6100000f * float_1)
		{
			if (float_0 <= 4400000f * float_1)
			{
				if (float_0 <= 2300000f * float_1)
				{
					if (float_0 <= 1120000f * float_1)
					{
						if (float_0 <= 580000f * float_1)
						{
							if (float_0 <= 280000f * float_1)
							{
								if (float_0 <= 137000f * float_1)
								{
									if (float_0 <= 71000f * float_1)
									{
										if (float_0 <= 37000f * float_1)
										{
											if (float_0 <= 18000f * float_1)
											{
												if ((double)float_0 <= 10200.0 * (double)float_1)
												{
													if ((double)float_0 <= 5000.0 * (double)float_1)
													{
														if ((double)float_0 <= 2600.0 * (double)float_1)
														{
															if ((double)float_0 <= 1200.0 * (double)float_1)
															{
																return 17;
															}
															return 16;
														}
														return 15;
													}
													return 14;
												}
												return 13;
											}
											return 12;
										}
										return 11;
									}
									return 10;
								}
								return 9;
							}
							return 8;
						}
						return 7;
					}
					return 6;
				}
				return 5;
			}
			return 4;
		}
		return 3;
	}

	internal int InvokeIssuer(Layer layer_0, FileSystemLayer fileSystemLayer_0, float float_0)
	{
		switch (layer_0)
		{
		case Layer.FileSystem:
			switch (fileSystemLayer_0)
			{
			default:
				return 0;
			case FileSystemLayer.BMNG:
				return WriteIssuer(float_0);
			case FileSystemLayer.Stamen:
				if (_WrapperVal == StamenLayer.Labels)
				{
					return PushIssuer(float_0, 1.1f);
				}
				return NewIssuer(float_0);
			case FileSystemLayer.Sentinel:
				return NewIssuer(float_0);
			case FileSystemLayer.OpenTopo:
				return NewIssuer(float_0);
			}
		case Layer.OSM:
			return NewIssuer(float_0);
		case Layer.BMNGOSM:
			return NewIssuer(float_0);
		default:
			return 0;
		case Layer.Bing:
			return NewIssuer(float_0);
		}
	}

	private float SetupIssuer(int int_0)
	{
		if (1 == 0)
		{
		}
		float result = int_0 switch
		{
			0 => 2000000f, 
			1 => 1200000f, 
			2 => 900000f, 
			3 => 600000f, 
			_ => 0f, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private float ExcludeIssuer(int int_0)
	{
		if (1 == 0)
		{
		}
		float result = int_0 switch
		{
			3 => 6000000f, 
			4 => 4000000f, 
			5 => 2500000f, 
			6 => 1250000f, 
			7 => 650000f, 
			8 => 350000f, 
			9 => 200000f, 
			10 => 80000f, 
			11 => 40000f, 
			12 => 20000f, 
			_ => 0f, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal float IncludeIssuer(Layer layer_0, FileSystemLayer fileSystemLayer_0, int int_0)
	{
		if (1 == 0)
		{
		}
		float result;
		switch (layer_0)
		{
		case Layer.FileSystem:
		{
			if (1 == 0)
			{
			}
			float num = fileSystemLayer_0 switch
			{
				FileSystemLayer.BMNG => SetupIssuer(int_0), 
				FileSystemLayer.Stamen => ExcludeIssuer(int_0), 
				FileSystemLayer.Sentinel => ExcludeIssuer(int_0), 
				FileSystemLayer.OpenTopo => ExcludeIssuer(int_0), 
				_ => 0f, 
			};
			if (1 == 0)
			{
			}
			result = num;
			break;
		}
		case Layer.OSM:
			result = ExcludeIssuer(int_0);
			break;
		case Layer.BMNGOSM:
			result = ExcludeIssuer(int_0);
			break;
		case Layer.Bing:
			result = ExcludeIssuer(int_0);
			break;
		default:
			result = 0f;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	private void SearchIssuer(Layer layer_0, FileSystemLayer fileSystemLayer_0, OSM_MBTiles_Layer osm_MBTiles_Layer_0, float float_0, float float_1, float float_2, int int_0, bool bool_0)
	{
		int num = InvokeIssuer(layer_0, fileSystemLayer_0, float_2);
		switch (layer_0)
		{
		case Layer.FileSystem:
			observerVal = num;
			break;
		case Layer.OSM:
			_ClientVal = num;
			break;
		case Layer.BMNGOSM:
			issuerVal = num;
			break;
		case Layer.Bing:
			_ClientVal = num;
			break;
		}
		int val = 0;
		int val2 = 0;
		switch (layer_0)
		{
		case Layer.FileSystem:
			switch (fileSystemLayer_0)
			{
			case FileSystemLayer.BMNG:
				val = 0;
				val2 = 4;
				break;
			case FileSystemLayer.Stamen:
				val = 3;
				switch (_WrapperVal)
				{
				case StamenLayer.Terrain:
					val2 = 17;
					break;
				case StamenLayer.Labels:
					val2 = 10;
					if (float_2 < 100000f)
					{
						return;
					}
					break;
				case StamenLayer.Lines:
					val2 = 12;
					break;
				}
				break;
			case FileSystemLayer.Sentinel:
				val = 4;
				val2 = 13;
				break;
			case FileSystemLayer.OpenTopo:
				val = 3;
				val2 = 16;
				break;
			}
			break;
		case Layer.OSM:
			val = 4;
			switch (osm_MBTiles_Layer_0)
			{
			case OSM_MBTiles_Layer.Relief90:
				val2 = 11;
				break;
			case OSM_MBTiles_Layer.Bathymetry:
				val2 = 9;
				break;
			case OSM_MBTiles_Layer.const_4:
				val2 = 11;
				break;
			case OSM_MBTiles_Layer.LandCover300:
				val2 = 9;
				break;
			}
			break;
		case Layer.BMNGOSM:
			val = 4;
			val2 = 8;
			break;
		case Layer.Bing:
			val = 4;
			val2 = 17;
			break;
		}
		int num2 = Convert.ToInt32(3.0 * Math.Pow(Math.Abs(float_1) / 90f, 2.1));
		num -= num2;
		num = Math.Min(num, val2);
		num = Math.Max(val, num);
		EnableIssuer(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, num, float_0, float_1, float_2, int_0, bool_0: false);
	}

	private void EnableIssuer(Layer layer_0, FileSystemLayer fileSystemLayer_0, OSM_MBTiles_Layer osm_MBTiles_Layer_0, int int_0, float float_0, float float_1, float float_2, int int_1, bool bool_0)
	{
		if (float_2 == 0f)
		{
			float_2 = IncludeIssuer(layer_0, fileSystemLayer_0, int_0);
		}
		float num = 90f + float_1;
		float float_3 = 180f + float_0;
		int num2 = 0;
		int num3 = 0;
		int int_2 = 0;
		float num4 = 0f;
		switch (layer_0)
		{
		case Layer.FileSystem:
			switch (fileSystemLayer_0)
			{
			case FileSystemLayer.BMNG:
				num2 = _TemplateDefinition[int_0];
				num3 = num2 * 2;
				num4 = 180f / (float)num2;
				int_2 = (int)(num / num4);
				break;
			case FileSystemLayer.Stamen:
				num2 = m_MappingDefinition[int_0];
				int_2 = num2 - (int)((1.0 - Math.Log(Math.Tan((double)float_1 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_1 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
				int_2 = Math.Min(num2, int_2);
				num3 = num2;
				num4 = 180f / (float)num3;
				break;
			case FileSystemLayer.Sentinel:
				num2 = m_MappingDefinition[int_0];
				int_2 = (int)((1.0 - Math.Log(Math.Tan((double)float_1 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_1 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
				if (m_RegistryVal == null)
				{
					int_2 = num2 - int_2;
					int_2 = Math.Min(num2, int_2);
				}
				else
				{
					int_2 = Math.Max(0, int_2);
				}
				num3 = num2;
				num4 = 180f / (float)num3;
				break;
			case FileSystemLayer.OpenTopo:
				num2 = m_MappingDefinition[int_0];
				int_2 = num2 - (int)((1.0 - Math.Log(Math.Tan((double)float_1 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_1 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
				int_2 = Math.Min(num2, int_2);
				num3 = num2;
				num4 = 180f / (float)num3;
				break;
			}
			break;
		case Layer.OSM:
			int_2 = (int)((1.0 - Math.Log(Math.Tan((double)float_1 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_1 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
			num2 = m_MappingDefinition[int_0];
			int_2 = Math.Min(num2, int_2);
			num4 = 180f / (float)num2;
			num3 = num2;
			break;
		case Layer.BMNGOSM:
			int_2 = (int)((1.0 - Math.Log(Math.Tan((double)float_1 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_1 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
			num2 = m_MappingDefinition[int_0];
			int_2 = Math.Max(0, int_2);
			num4 = 180f / (float)num2;
			num3 = num2;
			break;
		case Layer.Bing:
			int_2 = (int)((1.0 - Math.Log(Math.Tan((double)float_1 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_1 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
			num2 = m_MappingDefinition[int_0];
			int_2 = Math.Min(num2, int_2);
			num4 = 180f / (float)num2;
			num3 = num2;
			break;
		}
		float float_4 = 360f / (float)num3;
		int num5 = 0;
		float num6 = float_1;
		float num7;
		do
		{
			num7 = ConcatIssuer(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_1, float_2, int_0, num2, num3, float_3, num4, float_4, int_2, num5, num6, int_1, bool_0);
			num6 += num4;
			num5++;
		}
		while (num6 < 90f && num7 > 0f);
		if (20f < float_1 && float_1 < 83f)
		{
			ConcatIssuer(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_1, float_2, int_0, num2, num3, float_3, num4, float_4, int_2, num5, num6, int_1, bool_0);
		}
		num5 = -1;
		num6 = float_1 - num4;
		if (num6 > -90f)
		{
			do
			{
				num7 = ConcatIssuer(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_1, float_2, int_0, num2, num3, float_3, num4, float_4, int_2, num5, num6, int_1, bool_0);
				num6 -= num4;
				num5--;
			}
			while (num6 > -90f && num7 > 0f);
			if (-83f < float_1 && float_1 < -20f)
			{
				ConcatIssuer(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_1, float_2, int_0, num2, num3, float_3, num4, float_4, int_2, num5, num6, int_1, bool_0);
			}
		}
	}

	public void SetDateTime(DateTime dateTime_0)
	{
		double num = dateTime_0.ToOADate() + 2415018.5;
		_FactoryDefinition.m_SingletonDefinition = (float)num;
	}

	public void SetProjection(float float_0, float float_1, float float_2)
	{
		float_1 = Math.Min(89.9f, float_1);
		float_1 = Math.Max(-89.9f, float_1);
		procDefinition = InterruptIssuer(float_0, float_1, float_2);
		DrawArgs.AwakeThread(float_1, float_0, float_2, _RegDefinition, ScreenHeight, producerDefinition);
		if (RenderState.BordersCoasts)
		{
			if (!RenderState.BingMap && !RenderState.SentinelMap && !RenderState.ReliefBathymetryMap && !RenderState.BMNGMap && !RenderState.bool_0 && !RenderState.LandCoverOverlay && !RenderState.PlacenamesOverlay && !RenderState.OpenTopoOverlay && !RenderState.BaseEarth)
			{
				_InfoDefinition = 1f;
			}
			else if (float_2 < 500000f)
			{
				_InfoDefinition = 0f;
			}
			else if (float_2 <= 3500000f)
			{
				_InfoDefinition = (float_2 - 500000f) / 3000000f;
			}
			else
			{
				_InfoDefinition = 1f;
			}
		}
	}

	public void ManageTiles(float float_0, float float_1, float float_2)
	{
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		if (RenderState.SentinelMap)
		{
			flag2 = false;
			flag3 = false;
			SearchIssuer(Layer.FileSystem, FileSystemLayer.Sentinel, OSM_MBTiles_Layer.Sentinel, float_0, float_1, float_2, 1, bool_0: true);
		}
		else if (RenderState.OpenTopoOverlay)
		{
			flag2 = false;
			flag3 = false;
			flag = false;
			SearchIssuer(Layer.FileSystem, FileSystemLayer.OpenTopo, OSM_MBTiles_Layer.None, float_0, float_1, float_2, 1, bool_0: false);
		}
		else if (RenderState.LandCoverOverlay)
		{
			flag2 = false;
			SearchIssuer(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.LandCover300, float_0, float_1, float_2, 1, bool_0: false);
		}
		if (flag && RenderState.PlacenamesOverlay)
		{
			_WrapperVal = StamenLayer.Labels;
			SearchIssuer(Layer.FileSystem, FileSystemLayer.Stamen, OSM_MBTiles_Layer.None, float_0, float_1, float_2, 0, bool_0: false);
		}
		if (RenderState.BingMap)
		{
			if (flag2 || flag3)
			{
				SearchIssuer(Layer.Bing, FileSystemLayer.None, OSM_MBTiles_Layer.None, float_0, float_1, float_2, 2, bool_0: false);
			}
		}
		else if (RenderState.ReliefBathymetryMap)
		{
			if (flag2)
			{
				SearchIssuer(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.const_4, float_0, float_1, float_2, 2, bool_0: true);
			}
			if (flag3)
			{
				SearchIssuer(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.Bathymetry, float_0, float_1, float_2, 3, bool_0: true);
			}
		}
		else if (RenderState.BMNGMap)
		{
			if (flag2)
			{
				SearchIssuer(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.Relief90, float_0, float_1, float_2, 2, bool_0: false);
			}
			if (flag3)
			{
				SearchIssuer(Layer.FileSystem, FileSystemLayer.BMNG, OSM_MBTiles_Layer.None, float_0, float_1, float_2, 3, bool_0: true);
			}
		}
		else if (RenderState.bool_0)
		{
			if (flag2)
			{
				SearchIssuer(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.Relief90, float_0, float_1, float_2, 2, bool_0: false);
			}
			if (flag3)
			{
				SearchIssuer(Layer.BMNGOSM, FileSystemLayer.None, OSM_MBTiles_Layer.BMNG, float_0, float_1, float_2, 3, bool_0: true);
			}
		}
		for (int i = 0; i < threadVal.Count; i++)
		{
			SerializerDefinition serializerDefinition = threadVal[i];
			switch (serializerDefinition._RefDefinition.Status)
			{
			case TaskStatus.RanToCompletion:
				threadVal.RemoveAt(i);
				continue;
			case TaskStatus.Canceled:
				threadVal.RemoveAt(i);
				ChangeIssuer(serializerDefinition.ID);
				continue;
			case TaskStatus.Faulted:
				threadVal.RemoveAt(i);
				continue;
			}
			if (_ProcessVal.TryGetValue(serializerDefinition.ID, out var value) && !value.adapterDefinition)
			{
				serializerDefinition.m_ErrorDefinition.Cancel();
			}
			i++;
		}
		SpecificationVal result;
		while (decoratorVal.TryDequeue(out result))
		{
			string path = result.Path;
			if (_ProcessVal.TryGetValue(path, out var value2))
			{
				if (!_CallbackVal.TryGetValue(path, out var value3))
				{
					IComObject<ID3D11Texture2D> val = m_RulesDefinition.CreateTexture2D<ID3D11Texture2D>(result.Description, result.watcherVal);
					result._ReponseVal.Free();
					value3 = m_RulesDefinition.CreateShaderResourceView(val);
					_CallbackVal.Add(path, value3);
				}
				value2.proccesorDefinition = value3;
				_ProcessVal[path] = value2;
			}
		}
		for (int num = _RuleVal.Count - m_CollectionVal; num > 0; num--)
		{
			string text = _RuleVal.Dequeue();
			if (_ProcessVal.TryGetValue(text, out var value4))
			{
				if (!value4.adapterDefinition && !value4.m_SchemaDefinition)
				{
					ChangeIssuer(text);
				}
				else
				{
					_RuleVal.Enqueue(text);
				}
			}
		}
	}

	internal void ChangeIssuer(string string_0)
	{
		_ProcessVal.TryRemove(string_0, out var value);
		_CallbackVal.Remove(string_0);
		if (value.proccesorDefinition != null)
		{
			ID3D11Resource val = null;
			value.proccesorDefinition.Object.GetResource(out val);
			((IDisposable)new ComObject<ID3D11Resource>(val)).Dispose();
			value.proccesorDefinition.Dispose();
		}
	}

	private double InitIssuer(int int_0, int int_1)
	{
		double d = Math.Sinh(Math.PI - Math.PI * 2.0 * (double)int_1 / (double)(1 << int_0));
		return 180.0 / Math.PI * Math.Atan(d);
	}

	private string CheckIssuer(string string_0, int int_0, int int_1, int int_2)
	{
		return _CreatorDefinition + $"/WW/Cache/{string_0}/{int_0}/{int_1}/{int_2}.png";
	}

	private float ConcatIssuer(Layer layer_0, FileSystemLayer fileSystemLayer_0, OSM_MBTiles_Layer osm_MBTiles_Layer_0, float float_0, float float_1, int int_0, int int_1, int int_2, float float_2, float float_3, float float_4, int int_3, int int_4, float float_5, int int_5, bool bool_0)
	{
		switch (layer_0)
		{
		case Layer.FileSystem:
			switch (fileSystemLayer_0)
			{
			case FileSystemLayer.BMNG:
				int_3 += int_4;
				break;
			case FileSystemLayer.Stamen:
				int_3 += int_4;
				break;
			case FileSystemLayer.Sentinel:
				if (m_RegistryVal == null)
				{
					int_3 += int_4;
				}
				else
				{
					int_3 -= int_4;
				}
				break;
			case FileSystemLayer.OpenTopo:
				int_3 += int_4;
				break;
			}
			break;
		case Layer.OSM:
			int_3 -= int_4;
			break;
		case Layer.BMNGOSM:
			int_3 -= int_4;
			break;
		default:
			throw new ArgumentException("Unsupported layer for tile loading: " + layer_0);
		case Layer.Bing:
			int_3 -= int_4;
			break;
		}
		if (int_1 - int_3 < 0)
		{
			return 0f;
		}
		float num = Math.Abs(float_5 - float_0);
		float num9 = producerDefinition / 2f;
		double num10 = 1.0 - Math.Pow(num, 2.0) / Math.Pow(90.0, 2.0);
		double num11 = Math.Tan(num9 * (float)num10) * (double)float_1 * 2.0;
		float num12 = (float_1 + 12756274f) / 12756274f;
		double num13 = num11 * (double)num12;
		if ((double)(((Math.Abs(float_0) < 60f) ? ((float)(1.0 + 27.0 / (double)Math.Max(Math.Abs(float_0), 10f))) : ((float)Math.Max(0.5, 1f - (90f - Math.Abs(float_0) / 30f)))) * (num - float_3)) <= num13 / 111319.4921875)
		{
			double num14 = Math.Cos((double)Math.Abs(float_5) * CSMath.PI_dividedBy_180) * 40075016.0;
			num13 = Math.Min(num14, num13);
			double num15 = num13 / num14;
			if (num15 == 0.0)
			{
				return (float)num15;
			}
			double num16 = num15 * 360.0 / 2.0;
			int num2 = _RegDefinition / ScreenHeight;
			num16 *= (double)num2 * 1.5;
			if (Math.Abs(float_0) > 80f)
			{
				num16 *= 2.0;
			}
			double num3 = (double)float_2 - num16 - (double)(float_4 * 3f);
			double num4 = (double)float_2 + num16 + (double)(float_4 * 2f);
			for (int i = 0; i < int_2; i++)
			{
				int int_6 = i;
				float num5 = (float)int_6 * float_4;
				if ((!(num3 < (double)num5) || !((double)num5 < num4)) && (!(0f <= num5) || !((double)num5 < num4 - 360.0)) && (!(num3 < 0.0) || !(360.0 + num3 < (double)num5) || !(num5 < 360f)))
				{
					continue;
				}
				string string_0 = "";
				switch (layer_0)
				{
				case Layer.FileSystem:
					switch (fileSystemLayer_0)
					{
					case FileSystemLayer.BMNG:
						string_0 = _CreatorDefinition + string.Format("/WW/Cache/BMNGv2/{0}/{1,0:0000}/{1,0:0000}_{2,0:0000}.png", int_0, int_3, int_6);
						break;
					case FileSystemLayer.Stamen:
						switch (_WrapperVal)
						{
						case StamenLayer.Terrain:
							string_0 = $"Stamen Terrain {int_0}/{int_6}/{int_1 - int_3}.png";
							break;
						case StamenLayer.Labels:
							string_0 = $"Stamen Terrain - Labels {int_0}/{int_6}/{int_1 - int_3}.png";
							break;
						case StamenLayer.Lines:
							string_0 = $"Stamen Terrain - Lines {int_0}/{int_6}/{int_1 - int_3}.png";
							break;
						}
						break;
					case FileSystemLayer.Sentinel:
						string_0 = $"{int_0}/{int_6}/{int_1 - int_3}.webp";
						break;
					case FileSystemLayer.OpenTopo:
						string_0 = $"{int_0}/{int_6}/{int_1 - int_3}.png";
						break;
					}
					break;
				case Layer.OSM:
					string_0 = osm_MBTiles_Layer_0.ToString() + "#" + int_0 + ":" + int_3 + "-" + int_6;
					break;
				case Layer.BMNGOSM:
					string_0 = layer_0.ToString() + "#" + int_0 + ":" + int_3 + "-" + int_6;
					break;
				case Layer.Bing:
					string_0 = MapperPage.PopProcess(int_6, int_3, int_0);
					break;
				}
				if (!_ProcessVal.TryGetValue(string_0, out var value))
				{
					value = initializerDefinition;
					value._StrategyDefinition = 1f / (float)int_2 * (float)int_6;
					value.m_SingletonDefinition = 0.9f;
					double num6 = 0.0;
					double num7 = 0.0;
					switch (layer_0)
					{
					case Layer.FileSystem:
						switch (fileSystemLayer_0)
						{
						case FileSystemLayer.BMNG:
							value._ConfigurationDefinition = 1f / (float)int_1 * (float)(int_1 - 1 - int_3);
							value.indexerDefinition = 1f / (float)int_1;
							break;
						case FileSystemLayer.Stamen:
							num6 = InitIssuer(int_0, int_1 - int_3);
							num7 = InitIssuer(int_0, int_1 - int_3 + 1);
							value._ConfigurationDefinition = (float)(90.0 - num6) / 180f;
							value.indexerDefinition = (float)((90.0 - num7) / 180.0 - (double)value._ConfigurationDefinition);
							if (StamenLayer.Labels == _WrapperVal)
							{
								value.resolverDefinition = Layer.StamenLabels;
							}
							else
							{
								value.resolverDefinition = Layer.OSM;
							}
							value.Row = (uint)(int_1 - int_3);
							value._PublisherDefinition = (uint)int_0;
							value.m_SingletonDefinition = 0.35f;
							break;
						case FileSystemLayer.Sentinel:
						{
							int num8 = int_3;
							if (m_RegistryVal == null)
							{
								num8 = int_1 - int_3;
							}
							num6 = InitIssuer(int_0, num8);
							num7 = InitIssuer(int_0, num8 + 1);
							value._ConfigurationDefinition = (float)(90.0 - num6) / 180f;
							value.indexerDefinition = (float)((90.0 - num7) / 180.0 - (double)value._ConfigurationDefinition);
							value.resolverDefinition = Layer.OSM;
							value.Row = (uint)num8;
							value._PublisherDefinition = (uint)int_0;
							break;
						}
						case FileSystemLayer.OpenTopo:
							num6 = InitIssuer(int_0, int_1 - int_3);
							num7 = InitIssuer(int_0, int_1 - int_3 + 1);
							value._ConfigurationDefinition = (float)(90.0 - num6) / 180f;
							value.indexerDefinition = (float)((90.0 - num7) / 180.0 - (double)value._ConfigurationDefinition);
							value.resolverDefinition = Layer.OSM;
							value.Row = (uint)(int_1 - int_3);
							value._PublisherDefinition = (uint)int_0;
							break;
						}
						break;
					case Layer.OSM:
						num6 = InitIssuer(int_0, int_3);
						num7 = InitIssuer(int_0, int_3 + 1);
						value._ConfigurationDefinition = (float)(90.0 - num6) / 180f;
						value.indexerDefinition = (float)((90.0 - num7) / 180.0 - (double)value._ConfigurationDefinition);
						value.resolverDefinition = layer_0;
						value.Row = (uint)int_3;
						value._PublisherDefinition = (uint)int_0;
						break;
					case Layer.BMNGOSM:
						num6 = InitIssuer(int_0, int_3);
						num7 = InitIssuer(int_0, int_3 + 1);
						value._ConfigurationDefinition = (float)(90.0 - num6) / 180f;
						value.indexerDefinition = (float)((90.0 - num7) / 180.0 - (double)value._ConfigurationDefinition);
						value.resolverDefinition = layer_0;
						value.Row = (uint)int_3;
						value._PublisherDefinition = (uint)int_0;
						break;
					case Layer.Bing:
						num6 = InitIssuer(int_0, int_3);
						num7 = InitIssuer(int_0, int_3 + 1);
						value._ConfigurationDefinition = (float)(90.0 - num6) / 180f;
						value.indexerDefinition = (float)((90.0 - num7) / 180.0 - (double)value._ConfigurationDefinition);
						value.resolverDefinition = Layer.Bing;
						value.Row = (uint)int_3;
						value._PublisherDefinition = (uint)int_0;
						break;
					}
					value._TokenDefinition = 1f / (float)int_2;
					value._PublisherDefinition = (uint)int_0;
					value.predicateDefinition = int_5;
					CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
					CancellationToken token = cancellationTokenSource.Token;
					Task task = new Task(delegate
					{
						switch (layer_0)
						{
						case Layer.FileSystem:
							switch (fileSystemLayer_0)
							{
							case FileSystemLayer.BMNG:
								LogoutIssuer(string_0, bool_0: false);
								break;
							case FileSystemLayer.Stamen:
								switch (_WrapperVal)
								{
								case StamenLayer.Terrain:
								{
									string string_3 = string_0.Substring(15);
									TestIssuer(string_0, string_3, "Stamen Terrain", "/WW/Cache/Stamen Terrain/", "http://tile.stamen.com/terrain/", ImageFormat.png);
									break;
								}
								case StamenLayer.Labels:
								{
									string string_2 = string_0.Substring(24);
									TestIssuer(string_0, string_2, "Stamen Labels", "/WW/Cache/Stamen Terrain - Labels/", "http://warfaresims.slitherine.com/MapTiles/Labels/", ImageFormat.png);
									break;
								}
								case StamenLayer.Lines:
								{
									string string_ = string_0.Substring(23);
									TestIssuer(string_0, string_, "Stamen Lines", "/WW/Cache/Stamen Terrain - Lines/", "http://tile.stamen.com/terrain-lines/", ImageFormat.png);
									break;
								}
								}
								break;
							case FileSystemLayer.Sentinel:
								if (m_RegistryVal == null)
								{
									TestIssuer(string_0, string_0, "Sentinel", "\\WW\\Cache\\S2Cloudless_webp\\", "http://warfaresims.slitherine.com/MapTiles/S2Cloudless_webp/", ImageFormat.webp);
								}
								else
								{
									byte[] array4 = RestartIssuer(osm_MBTiles_Layer_0, int_0, int_3, int_6);
									if (array4 != null)
									{
										CallIssuer(string_0, array4, ImageFormat.webp);
									}
								}
								break;
							case FileSystemLayer.OpenTopo:
								TestIssuer(string_0, string_0, "OpenTopo", "/WW/Cache/OpenTopoMap/", "https://tile.opentopomap.org/", ImageFormat.png);
								break;
							}
							break;
						case Layer.OSM:
						{
							byte[] array2 = RestartIssuer(osm_MBTiles_Layer_0, int_0, int_3, int_6);
							if (array2 != null)
							{
								CallIssuer(string_0, array2, ImageFormat.webp);
							}
							break;
						}
						case Layer.BMNGOSM:
						{
							byte[] array3 = RestartIssuer(osm_MBTiles_Layer_0, int_0, int_3, int_6);
							if (array3 != null)
							{
								CallIssuer(string_0, array3, ImageFormat.webp);
							}
							break;
						}
						case Layer.Bing:
						{
							byte[] array = CancelIssuer(string_0);
							if (array != null)
							{
								Bitmap bitmap_ = new Bitmap(new MemoryStream(array));
								ValidateIssuer(string_0, bitmap_, bool_0: false);
							}
							break;
						}
						case Layer.OSMOSM:
						case Layer.const_4:
						case Layer.Line:
							break;
						}
					}, token);
					threadVal.Add(new SerializerDefinition
					{
						ID = string_0,
						_RefDefinition = task,
						m_ErrorDefinition = cancellationTokenSource
					});
					task.Start();
					_RuleVal.Enqueue(string_0);
				}
				m_InstanceVal++;
				if (bool_0)
				{
					value.m_SchemaDefinition = true;
				}
				else
				{
					value.adapterDefinition = true;
				}
				_ProcessVal[string_0] = value;
			}
			return (float)num15;
		}
		return 0f;
	}

	private Matrix4x4 InterruptIssuer(float float_0, float float_1, float float_2)
	{
		float num = 6378137f + float_2;
		float farPlaneDistance = (float)Math.Sqrt((double)(num * num) - 40680631590769.0);
		Matrix4x4 identity = Matrix4x4.Identity;
		float num2 = SetIssuer(float_0);
		float num3 = FindIssuer(float_1);
		float aspectRatio = (float)_RegDefinition / (float)ScreenHeight;
		float nearPlaneDistance = float_2 * 0.1f;
		Matrix4x4 matrix4x = Matrix4x4.CreatePerspectiveFieldOfView(producerDefinition, aspectRatio, nearPlaneDistance, farPlaneDistance);
		matrix4x.M33 *= -1f;
		matrix4x.M34 *= -1f;
		float x = (float)((double)num * Math.Sin(num3) * Math.Cos(num2));
		float z = (float)((double)num * Math.Sin(num3) * Math.Sin(num2));
		float y = (float)((double)num * Math.Cos(num3));
		Vector3 cameraPosition = new Vector3(x, y, z);
		Vector3 zero = Vector3.Zero;
		Vector3 cameraUpVector = new Vector3(0f, 1f, 0f);
		Matrix4x4 matrix4x2 = Matrix4x4.CreateLookAt(cameraPosition, zero, cameraUpVector);
		matrix4x2.M11 *= -1f;
		matrix4x2.M13 *= -1f;
		matrix4x2.M21 *= -1f;
		matrix4x2.M23 *= -1f;
		matrix4x2.M31 *= -1f;
		matrix4x2.M33 *= -1f;
		matrix4x2.M41 *= -1f;
		matrix4x2.M43 *= -1f;
		return identity * matrix4x2 * matrix4x;
	}

	private Matrix4x4 RemoveIssuer()
	{
		Matrix4x4 matrix4x = Matrix4x4.CreateOrthographic(_RegDefinition, ScreenHeight, -1f, 1f);
		matrix4x.M33 *= -1f;
		Matrix4x4 matrix4x2 = Matrix4x4.CreateTranslation(new Vector3((float)(-_RegDefinition) / 2f, (float)(-ScreenHeight) / 2f, 0f));
		return Matrix4x4.Identity * matrix4x2 * matrix4x;
	}

	private float FindIssuer(float float_0)
	{
		float_0 += 90f;
		float_0.Clamp(2.938736E-39f, 180f);
		return (1f - float_0 / 180f) * (float)Math.PI;
	}

	private float SetIssuer(float float_0)
	{
		float_0 += 180f;
		float_0.Clamp(2.938736E-39f, 180f);
		return (0.5f + float_0 / 360f * 2f) * (float)Math.PI;
	}

	public void BeginDrawing()
	{
		serviceDefinition.BeginEvent("BeginDrawing");
		_ExceptionDefinition?.Handle(RenderEvent.BeginDrawing);
		float[] array = new float[4];
		_VisitorDefinition.CopyTo(array);
		ID3D11RenderTargetView @object = systemDefinition.Object;
		methodDefinition.Object.ClearRenderTargetView(@object, array);
		methodDefinition.Object.ClearDepthStencilView(m_CandidateDefinition.Object, 3u, 1f, 0);
		if (_ManagerDefinition && _ConsumerVal != 0)
		{
			CloneIssuer();
		}
		methodDefinition.Object.VSSetShader(m_IdentifierDefinition.Object, null, 0);
		methodDefinition.Object.RSSetState(productDefinition.Object);
		methodDefinition.Object.IASetInputLayout(_BroadcasterDefinition.Object);
		methodDefinition.Object.IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		annotationDefinition.BeginDraw();
		for (int num = m_AttributeDefinition.Count - 1; num >= 0; num--)
		{
			DrawParameters drawParameters_ = (DrawParameters)m_AttributeDefinition[num];
			if (drawParameters_.adapterDefinition)
			{
				ReadIssuer(drawParameters_);
			}
		}
		serviceDefinition.BeginEvent("DrawTiles");
		_ObjectVal = 0;
		int num2 = Math.Max(_TemplateDefinition.Length, m_MappingDefinition.Length);
		for (int i = 0; i < 4; i++)
		{
			serviceDefinition.BeginEvent("DrawTilesPriority" + i);
			List<DrawParameters> list = new List<DrawParameters>();
			KeyValuePair<string, DrawParameters>[] array2 = FillIssuer(_ProcessVal);
			int num3 = array2.Length;
			for (int num4 = num2 - 1; num4 >= 0; num4--)
			{
				for (int j = 0; j < num3; j++)
				{
					KeyValuePair<string, DrawParameters> keyValuePair = array2[j];
					DrawParameters value = keyValuePair.Value;
					if (value.predicateDefinition == i && value._PublisherDefinition == num4)
					{
						if (value.adapterDefinition && value.proccesorDefinition != null)
						{
							list.Add(value);
							_ObjectVal++;
						}
						value.adapterDefinition = false;
						_ProcessVal[keyValuePair.Key] = value;
					}
				}
			}
			if (list.Count > 0)
			{
				CreateIssuer(list);
				list.Clear();
			}
			serviceDefinition.EndEvent();
		}
		serviceDefinition.EndEvent();
		methodDefinition.Object.PSSetShader(m_PrinterDefinition.Object, null, 0);
		if (RenderState.BaseEarth)
		{
			serviceDefinition.BeginEvent("DrawBackground");
			ReadIssuer(_RoleDefinition);
			serviceDefinition.EndEvent();
		}
		if (RenderState.DayNight)
		{
			serviceDefinition.BeginEvent("DrawForeground");
			ReadIssuer(_FactoryDefinition);
			serviceDefinition.EndEvent();
		}
		if (RenderState.BordersCoasts)
		{
			serviceDefinition.BeginEvent("DrawBordersCoasts");
			if (Borders == Borders.Older)
			{
				_StateDefinition.Render(_InfoDefinition);
			}
			else
			{
				authenticationDefinition.Render(_InfoDefinition);
			}
			m_ParamsDefinition.Render(_InfoDefinition);
			serviceDefinition.EndEvent();
		}
		Drawing = true;
		_ExceptionDefinition?.Handle(RenderEvent.DrawingEnabled, _ProcessVal);
		if (RenderState.LatitudeLongitudeGrid)
		{
			serviceDefinition.BeginEvent("DrawLatitudeLongitude");
			m_FacadeVal.MapThread(DrawArgs);
			serviceDefinition.EndEvent();
		}
		if (RenderState.Scale)
		{
			serviceDefinition.BeginEvent("DrawScale");
			m_ProxyVal.CollectThread(DrawArgs);
			serviceDefinition.EndEvent();
		}
	}

	private KeyValuePair<string, DrawParameters>[] FillIssuer(ConcurrentDictionary<string, DrawParameters> concurrentDictionary_0)
	{
		KeyValuePair<string, DrawParameters>[] array = new KeyValuePair<string, DrawParameters>[concurrentDictionary_0.Count];
		IEnumerator<KeyValuePair<string, DrawParameters>> enumerator = concurrentDictionary_0.GetEnumerator();
		int num = 0;
		while (enumerator.MoveNext())
		{
			array[num] = enumerator.Current;
			num++;
		}
		return array;
	}

	public void DrawText(string string_0, int int_0, int int_1, bool bool_0)
	{
		DrawText(string_0, 12f, Color.White, int_0, int_1, bool_0);
	}

	public void DrawText(string string_0, float float_0, Color color_0, int int_0, int int_1, bool bool_0 = false, bool bool_1 = false)
	{
		if (Drawing)
		{
			Point point_ = new Point(int_0, int_1);
			CalculateIssuer(string_0, float_0, color_0, point_, bool_0, bool_1);
		}
	}

	internal void CalculateIssuer(string string_0, float float_0, Color color_0, Point point_0, bool bool_0 = false, bool bool_1 = false)
	{
		if (bool_0)
		{
			point_0.X -= MeasureText(string_0, float_0, point_0.X, point_0.Y).Width;
		}
		D2D1_BRUSH_PROPERTIES val = default(D2D1_BRUSH_PROPERTIES);
		val.opacity = 1f;
		D2D1_BRUSH_PROPERTIES value = val;
		if (!_MerchantVal.TryGetValue(color_0, out var value2))
		{
			_D3DCOLORVALUE val2 = _D3DCOLORVALUE.FromArgb(color_0.A, color_0.R, color_0.G, color_0.B);
			value2 = annotationDefinition.CreateSolidColorBrush(val2, value);
			_MerchantVal.Add(color_0, value2);
		}
		color_0 = Color.FromArgb(color_0.A, Color.Black.R, Color.Black.G, Color.Black.B);
		IComObject<ID2D1SolidColorBrush> value3 = null;
		if (bool_1 && !_MerchantVal.TryGetValue(color_0, out value3))
		{
			_D3DCOLORVALUE val3 = _D3DCOLORVALUE.FromArgb(color_0.A, color_0.R, color_0.G, color_0.B);
			value3 = annotationDefinition.CreateSolidColorBrush(val3, value);
			_MerchantVal.Add(color_0, value3);
		}
		(string, float) key = ("Segoe UI", float_0);
		IComObject<IDWriteTextFormat> val4 = _RepositoryVal.get(key);
		if (val4 == null)
		{
			val4 = m_IteratorDefinition.CreateTextFormat("Segoe UI", float_0);
			_RepositoryVal.add(key, val4);
		}
		(IComObject<IDWriteTextFormat>, string) key2 = (val4, string_0);
		IComObject<IDWriteTextLayout> val5 = bridgeVal.get(key2);
		if (val5 == null)
		{
			val5 = m_IteratorDefinition.CreateTextLayout(val4, string_0);
			bridgeVal.add(key2, val5);
		}
		D2D_POINT_2F val6 = default(D2D_POINT_2F);
		val6 = new D2D_POINT_2F(m_FieldDefinition + point_0.X, _QueueDefinition + point_0.Y);
		ID2D1RenderTarget @object = annotationDefinition.Object;
		IDWriteTextLayout object2 = val5.Object;
		ID2D1SolidColorBrush val7 = value3?.Object;
		annotationDefinition.Object.SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE.D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE);
		val6.y += 1f;
		if (bool_1)
		{
			@object.DrawTextLayout(val6, object2, val7, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		val6.x += 1f;
		if (bool_1)
		{
			@object.DrawTextLayout(val6, object2, val7, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		val6.x -= 2f;
		if (bool_1)
		{
			@object.DrawTextLayout(val6, object2, val7, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		val6.y -= 2f;
		if (bool_1)
		{
			@object.DrawTextLayout(val6, object2, val7, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		val6.x += 1f;
		val6.y += 1f;
		@object.DrawTextLayout(val6, object2, value2.Object, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
	}

	internal float PopIssuer(string string_0)
	{
		int num = 12;
		D2D_RECT_F val = default(D2D_RECT_F);
		val.left = m_FieldDefinition;
		val.right = float.MaxValue;
		val.top = _QueueDefinition;
		val.bottom = float.MaxValue;
		D2D_RECT_F val2 = val;
		(string, float) key = ("Segoe UI", 12f);
		IComObject<IDWriteTextFormat> val3 = _RepositoryVal.get(key);
		if (val3 == null)
		{
			val3 = m_IteratorDefinition.CreateTextFormat("Segoe UI", num);
			_RepositoryVal.add(key, val3);
		}
		IComObject<IDWriteTextLayout> obj = m_IteratorDefinition.CreateTextLayout(val3, string_0, string_0.Length, val2.right, val2.bottom);
		DWRITE_TEXT_METRICS val4 = default(DWRITE_TEXT_METRICS);
		obj.Object.GetMetrics(out val4);
		obj.Dispose();
		return val4.height;
	}

	internal float InstantiateIssuer(string string_0)
	{
		int num = 12;
		D2D_RECT_F val = default(D2D_RECT_F);
		val.left = m_FieldDefinition;
		val.right = float.MaxValue;
		val.top = _QueueDefinition;
		val.bottom = float.MaxValue;
		D2D_RECT_F val2 = val;
		(string, float) key = ("Segoe UI", 12f);
		IComObject<IDWriteTextFormat> val3 = _RepositoryVal.get(key);
		if (val3 == null)
		{
			val3 = m_IteratorDefinition.CreateTextFormat("Segoe UI", num);
			_RepositoryVal.add(key, val3);
		}
		IComObject<IDWriteTextLayout> obj = m_IteratorDefinition.CreateTextLayout(val3, string_0, string_0.Length, val2.right, val2.bottom);
		DWRITE_TEXT_METRICS val4 = default(DWRITE_TEXT_METRICS);
		obj.Object.GetMetrics(out val4);
		obj.Dispose();
		return val4.width;
	}

	public Rectangle MeasureText(string string_0, float float_0, int int_0, int int_1)
	{
		(string, float) key = (string_0, float_0);
		Rectangle rectangle = default(Rectangle);
		rectangle = invocationVal.get(key);
		if (rectangle.Width <= 0)
		{
			D2D_RECT_F val = default(D2D_RECT_F);
			val.left = m_FieldDefinition + int_0;
			val.right = float.MaxValue;
			val.top = _QueueDefinition + int_1;
			val.bottom = float.MaxValue;
			D2D_RECT_F val2 = val;
			(string, float) key2 = ("Segoe UI", float_0);
			IComObject<IDWriteTextFormat> val3 = _RepositoryVal.get(key2);
			if (val3 == null)
			{
				val3 = m_IteratorDefinition.CreateTextFormat("Segoe UI", float_0);
				_RepositoryVal.add(key2, val3);
			}
			IComObject<IDWriteTextLayout> obj = m_IteratorDefinition.CreateTextLayout(val3, string_0, string_0.Length, val2.right, val2.bottom);
			DWRITE_TEXT_METRICS val4 = default(DWRITE_TEXT_METRICS);
			obj.Object.GetMetrics(out val4);
			obj.Dispose();
			rectangle = new Rectangle((int)val4.left, (int)val4.top, (int)val4.width, (int)val4.height);
			invocationVal.add(key, rectangle);
			return rectangle;
		}
		return rectangle;
	}

	public void FinishDrawing()
	{
		if (m_DicVal)
		{
			ListIssuer();
		}
		_ExceptionDefinition?.Handle(RenderEvent.Present);
		Drawing = false;
		serviceDefinition.BeginEvent("Draw2DEnd");
		annotationDefinition.EndDraw();
		serviceDefinition.EndEvent();
		HRESULT val = _BaseDefinition.Object.Present(0u, 0u);
		HRESULT hRESULT = val;
		_ = hRESULT.IsOk;
		methodDefinition.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { systemDefinition.Object }, m_CandidateDefinition.Object);
		_ConsumerVal++;
		m_InstanceVal = 0;
		_ExceptionDefinition?.Handle(RenderEvent.FinishedDrawing);
		serviceDefinition.EndEvent();
	}

	private void CreateIssuer(List<DrawParameters> list_0)
	{
		if (list_0.Count != 0)
		{
			int num = 0;
			int num2 = list_0.Count / 256;
			int num3 = list_0.Count % 256;
			while (num < num2)
			{
				CompareIssuer(list_0, 256, num++ * 256);
			}
			if (num3 > 0)
			{
				CompareIssuer(list_0, num3, num * 256);
			}
		}
	}

	private unsafe void CompareIssuer(List<DrawParameters> list_0, int int_0, int int_1)
	{
		ID3D11DeviceContext @object = methodDefinition.Object;
		int int_2 = int_0 + int_1;
		if (classVal == null)
		{
			D3D11_TEXTURE2D_DESC val = default(D3D11_TEXTURE2D_DESC);
			val.Width = 256u;
			val.Height = 256u;
			val.MipLevels = 1u;
			val.ArraySize = 256u;
			val.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT;
			val.Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT;
			val.BindFlags = 8u;
			D3D11_TEXTURE2D_DESC val2 = val;
			val2.SampleDesc.Count = 1u;
			classVal = m_RulesDefinition.CreateTexture2D<ID3D11Texture2D>(val2);
		}
		uint num = 0u;
		ID3D11Resource val3 = null;
		for (int i = int_1; i < int_2; i++)
		{
			DrawParameters drawParameters = list_0[i];
			if (drawParameters.proccesorDefinition != null)
			{
				drawParameters.proccesorDefinition.Object.GetResource(out val3);
				@object.CopySubresourceRegion(classVal.Object, num++, 0u, 0u, 0u, val3, 0u, (IntPtr)(void*)null);
			}
		}
		methodDefinition.WithMap(ConstantBuffer, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, delegate(ref D3D11_MAPPED_SUBRESOURCE mapped, ref PoolRuleWatcher buffer)
		{
			buffer._EventPrototype = procDefinition;
		});
		methodDefinition.WithMap(ConstantBufferArray, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, delegate(ref D3D11_MAPPED_SUBRESOURCE mapped, ref InstanceMerchantPage buffer)
		{
			buffer._HelperPrototype = (uint)int_0;
			int num2 = 0;
			for (int j = int_1; j < int_2; j++)
			{
				DrawParameters drawParameters2 = list_0[j];
				buffer.m_MapperPrototype[num2] = drawParameters2._StrategyDefinition;
				buffer.m_ManagerPrototype[num2] = drawParameters2._ConfigurationDefinition;
				buffer.getterPrototype[num2] = drawParameters2._TokenDefinition;
				buffer.m_ProducerPrototype[num2] = drawParameters2.indexerDefinition;
				buffer.Row[num2] = drawParameters2.Row;
				buffer.procPrototype[num2] = drawParameters2._PublisherDefinition;
				buffer._StructComparator[num2] = (int)drawParameters2.resolverDefinition;
				buffer.merchantComparator[num2] = drawParameters2.m_SingletonDefinition;
				num2++;
			}
		});
		@object.IASetVertexBuffers(0u, 1, new ID3D11Buffer[1] { initializerDefinition._ConnectionDefinition.Object }, new uint[1] { 36u }, new uint[1]);
		@object.IASetIndexBuffer(initializerDefinition._ContextDefinition.Object, DXGI_FORMAT.DXGI_FORMAT_R32_UINT, 0u);
		@object.IASetPrimitiveTopology(initializerDefinition._UtilsDefinition);
		@object.VSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { ConstantBuffer.Object });
		@object.PSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { ConstantBuffer.Object });
		@object.VSSetConstantBuffers(1u, 1, new ID3D11Buffer[1] { ConstantBufferArray.Object });
		@object.PSSetConstantBuffers(1u, 1, new ID3D11Buffer[1] { ConstantBufferArray.Object });
		if (_RequestVal == null)
		{
			_RequestVal = m_RulesDefinition.CreateShaderResourceView(classVal);
		}
		@object.PSSetShaderResources(1u, 1, new ID3D11ShaderResourceView[1] { _RequestVal.Object });
		@object.PSSetShader(algoDefinition.Object, null, 0);
		@object.DrawIndexed(initializerDefinition._StatusDefinition, 0u, 0);
	}

	private void ReadIssuer(DrawParameters drawParameters_0)
	{
		methodDefinition.Object.IASetVertexBuffers(0u, 1, new ID3D11Buffer[1] { drawParameters_0._ConnectionDefinition.Object }, new uint[1] { 36u }, new uint[1]);
		if (drawParameters_0.m_ServerDefinition)
		{
			drawParameters_0._ConnectionDefinition.Dispose();
		}
		methodDefinition.Object.IASetIndexBuffer(drawParameters_0._ContextDefinition.Object, DXGI_FORMAT.DXGI_FORMAT_R32_UINT, 0u);
		if (drawParameters_0.m_ServerDefinition)
		{
			drawParameters_0._ContextDefinition.Dispose();
		}
		methodDefinition.WithMap(ConstantBuffer, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, delegate(ref D3D11_MAPPED_SUBRESOURCE mapped, ref PoolRuleWatcher buffer)
		{
			switch (drawParameters_0.codeDefinition)
			{
			case Projection.Icon:
				buffer._EventPrototype = m_StructVal;
				break;
			case Projection.Globe:
				buffer._EventPrototype = procDefinition;
				break;
			}
			buffer.m_GlobalPrototype = drawParameters_0._StrategyDefinition;
			buffer._WorkerPrototype = drawParameters_0._ConfigurationDefinition;
			buffer.accountPrototype = drawParameters_0._TokenDefinition;
			buffer._StatePrototype = drawParameters_0.indexerDefinition;
			buffer.Row = drawParameters_0.Row;
			buffer.m_AuthenticationPrototype = drawParameters_0._PublisherDefinition;
			buffer._ParamsPrototype = (int)drawParameters_0.resolverDefinition;
			buffer.m_InfoPrototype = drawParameters_0.m_SingletonDefinition;
		});
		methodDefinition.Object.IASetPrimitiveTopology(drawParameters_0._UtilsDefinition);
		methodDefinition.Object.VSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { ConstantBuffer.Object });
		methodDefinition.Object.PSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { ConstantBuffer.Object });
		if (drawParameters_0.proccesorDefinition != null)
		{
			methodDefinition.Object.PSSetShaderResources(0u, 1, new ID3D11ShaderResourceView[1] { drawParameters_0.proccesorDefinition.Object });
		}
		if (drawParameters_0.resolverDefinition == Layer.DayNight)
		{
			methodDefinition.Object.OMSetBlendState(workerDefinition.Object, m_GlobalDefinition, uint.MaxValue);
		}
		if (drawParameters_0.resolverDefinition == Layer.BlendableLine)
		{
			methodDefinition.Object.OMSetBlendState(accountDefinition.Object, m_GlobalDefinition, uint.MaxValue);
		}
		if (drawParameters_0.codeDefinition == Projection.Icon)
		{
			methodDefinition.Object.OMSetDepthStencilState(_HelperDefinition.Object, 0u);
			methodDefinition.Object.OMSetBlendState(m_MapperDefinition.Object, m_GlobalDefinition, uint.MaxValue);
		}
		if (drawParameters_0.codeDefinition == Projection.Icon)
		{
			methodDefinition.Object.PSSetShader(m_PrinterDefinition.Object, null, 0);
		}
		else
		{
			switch (drawParameters_0.resolverDefinition)
			{
			case Layer.Line:
				methodDefinition.Object.PSSetShader(m_DatabaseDefinition.Object, null, 0);
				break;
			case Layer.DayNight:
				methodDefinition.Object.PSSetShader(m_MessageDefinition.Object, null, 0);
				break;
			default:
				methodDefinition.Object.PSSetShader(m_ParserDefinition.Object, null, 0);
				break;
			case Layer.BlendableLine:
				methodDefinition.Object.PSSetShader(m_InterceptorDefinition.Object, null, 0);
				break;
			case Layer.BaseEarth:
				methodDefinition.Object.PSSetShader(m_PrinterDefinition.Object, null, 0);
				break;
			}
		}
		methodDefinition.Object.DrawIndexed(drawParameters_0._StatusDefinition, 0u, 0);
		methodDefinition.Object.OMSetDepthStencilState(null, 0u);
		methodDefinition.Object.OMSetBlendState(null, null, uint.MaxValue);
	}

	public void DrawIcon(string string_0, int int_0, int int_1, int int_2, int int_3, int int_4, bool bool_0, int int_5 = -1, float float_0 = 0f)
	{
		ID2D1Bitmap issuer = GetIssuer(string_0, int_0, int_5);
		if (issuer != null)
		{
			if (bool_0)
			{
				ID2D1Bitmap issuer2 = GetIssuer(string_0, int_0, int_5, bool_0: true);
				DrawD2DBitmap(issuer2, int_0, int_1 + 1, int_2, int_3, int_4, float_0);
				DrawD2DBitmap(issuer2, int_0, int_1 - 1, int_2, int_3, int_4, float_0);
				DrawD2DBitmap(issuer2, int_0, int_1, int_2 + 1, int_3, int_4, float_0);
				DrawD2DBitmap(issuer2, int_0, int_1, int_2 - 1, int_3, int_4, float_0);
			}
			DrawD2DBitmap(issuer, int_0, int_1, int_2, int_3, int_4, float_0);
		}
	}

	public unsafe void DrawD2DBitmap(ID2D1Bitmap id2D1Bitmap_0, int int_0, int int_1, int int_2, int int_3, int int_4, float float_0)
	{
		int_2 = ScreenHeight - int_2 + _QueueDefinition;
		D2D_RECT_F val = default(D2D_RECT_F);
		val.left = (float)int_1 - (float)int_3 / 2f;
		val.right = (float)int_1 + (float)int_3 / 2f;
		val.top = (float)int_2 + (float)int_4 / 2f;
		val.bottom = (float)int_2 - (float)int_4 / 2f;
		IntPtr pointer = val.StructureToMemory().Pointer;
		float num = (float)int_0 / 255f;
		if (float_0 == 0f)
		{
			annotationDefinition.Object.DrawBitmap(id2D1Bitmap_0, pointer, num, D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, (IntPtr)(void*)null);
			return;
		}
		D2D_MATRIX_3X2_F val2 = default(D2D_MATRIX_3X2_F);
		annotationDefinition.Object.GetTransform(out val2);
		D2D_MATRIX_3X2_F val3 = D2D_MATRIX_3X2_F.Rotation(float_0, int_1, int_2);
		annotationDefinition.Object.SetTransform(ref val3);
		annotationDefinition.Object.DrawBitmap(id2D1Bitmap_0, pointer, num, D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, (IntPtr)(void*)null);
		annotationDefinition.Object.SetTransform(ref val2);
	}

	public unsafe void DrawBitmap(Bitmap bitmap_0)
	{
		D2D_RECT_F val = default(D2D_RECT_F);
		val.left = 0f;
		val.right = bitmap_0.Width;
		val.top = bitmap_0.Height;
		val.bottom = 0f;
		IntPtr pointer = val.StructureToMemory().Pointer;
		ID2D1Bitmap val2 = DisableIssuer(bitmap_0);
		annotationDefinition.Object.DrawBitmap(val2, pointer, 1f, D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, (IntPtr)(void*)null);
	}

	private ID2D1Bitmap DisableIssuer(Bitmap bitmap_0)
	{
		int num = bitmap_0.Width * 4;
		byte[] array = new byte[num * bitmap_0.Height];
		for (int i = 0; i < bitmap_0.Height; i++)
		{
			for (int j = 0; j < bitmap_0.Width; j++)
			{
				Color pixel = bitmap_0.GetPixel(j, i);
				int num2 = i * num + j * 4;
				array[num2] = (byte)(pixel.B * pixel.A / 255);
				array[num2 + 1] = (byte)(pixel.G * pixel.A / 255);
				array[num2 + 2] = (byte)(pixel.R * pixel.A / 255);
				array[num2 + 3] = pixel.A;
			}
		}
		D2D_SIZE_U val = default(D2D_SIZE_U);
		val = new D2D_SIZE_U((uint)bitmap_0.Width, (uint)bitmap_0.Height);
		D2D1_BITMAP_PROPERTIES val2 = default(D2D1_BITMAP_PROPERTIES);
		val2.pixelFormat = new D2D1_PIXEL_FORMAT
		{
			format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
			alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
		};
		D2D1_BITMAP_PROPERTIES val3 = val2;
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		ID2D1Bitmap result = null;
		annotationDefinition.Object.CreateBitmap(val, gCHandle.AddrOfPinnedObject(), (uint)(bitmap_0.Width * 4), ref val3, out result);
		gCHandle.Free();
		return result;
	}

	public void DrawLine(Color color_0, float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		if (Drawing)
		{
			float_2 += (float)_QueueDefinition;
			float_4 += (float)_QueueDefinition;
			D2D_POINT_2F val = default(D2D_POINT_2F);
			val = new D2D_POINT_2F(float_1, float_2);
			D2D_POINT_2F val2 = default(D2D_POINT_2F);
			val2 = new D2D_POINT_2F(float_3, float_4);
			if (!_MerchantVal.TryGetValue(color_0, out var value))
			{
				_D3DCOLORVALUE val3 = _D3DCOLORVALUE.FromArgb(color_0.A, color_0.R, color_0.G, color_0.B);
				D2D1_BRUSH_PROPERTIES val4 = default(D2D1_BRUSH_PROPERTIES);
				val4.opacity = 1f;
				D2D1_BRUSH_PROPERTIES value2 = val4;
				value = annotationDefinition.CreateSolidColorBrush(val3, value2);
				_MerchantVal.Add(color_0, value);
			}
			annotationDefinition.Object.DrawLine(val, val2, value.Object, float_0, null);
		}
	}

	public void DrawDashedLine(Color color_0, Point[] point_0)
	{
		if (!Drawing)
		{
			return;
		}
		bool flag = true;
		for (uint num = 0u; num < point_0.Length; num++)
		{
			if (flag)
			{
				Point point = point_0[num];
				uint num2 = ((num < point_0.Length - 1) ? (num + 1) : 0u);
				Point point2 = point_0[num2];
				DrawLine(color_0, 1.5f, point.X, point.Y, point2.X, point2.Y);
			}
			flag = !flag;
		}
	}

	public unsafe void DrawGradientLine(Color color_0, float float_0, bool bool_0, float float_1, float float_2, float float_3, float float_4)
	{
		if (Drawing)
		{
			float_2 += (float)_QueueDefinition;
			float_4 += (float)_QueueDefinition;
			D2D_POINT_2F val = default(D2D_POINT_2F);
			val = new D2D_POINT_2F(float_1, float_2);
			D2D_POINT_2F val2 = default(D2D_POINT_2F);
			val2 = new D2D_POINT_2F(float_3, float_4);
			if (!m_ImporterVal.TryGetValue(color_0, out var value))
			{
				D2D1_GRADIENT_STOP[] array = new D2D1_GRADIENT_STOP[2];
				array[0].position = 0f;
				array[0].color = _D3DCOLORVALUE.FromArgb(0, color_0.R, color_0.G, color_0.B);
				array[1].position = 1f;
				array[1].color = _D3DCOLORVALUE.FromArgb(byte.MaxValue, color_0.R, color_0.G, color_0.B);
				ID2D1GradientStopCollection val3 = null;
				annotationDefinition.Object.CreateGradientStopCollection(array, 2, D2D1_GAMMA.D2D1_GAMMA_2_2, D2D1_EXTEND_MODE.D2D1_EXTEND_MODE_CLAMP, out val3);
				D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES val4 = default(D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES);
				val4.startPoint = val;
				val4.endPoint = val2;
				D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES val5 = val4;
				annotationDefinition.Object.CreateLinearGradientBrush(ref val5, (IntPtr)(void*)null, val3, out value);
				new ComObject<ID2D1GradientStopCollection>(val3).Dispose();
				m_ImporterVal.Add(color_0, value);
			}
			value.SetStartPoint(val);
			value.SetEndPoint(val2);
			annotationDefinition.Object.DrawLine(val, val2, value, float_0, bool_0 ? propertyVal : m_ReaderVal);
		}
	}

	public void FillGeometry(PointF[] pointF_0, Color color_0)
	{
		if (Drawing)
		{
			IComObject<ID2D1PathGeometry1> val = policyDefinition.CreatePathGeometry();
			IComObject<ID2D1SimplifiedGeometrySink> val2 = val.Open();
			D2D_POINT_2F val3 = default(D2D_POINT_2F);
			val3 = new D2D_POINT_2F(pointF_0[0].X + (float)m_FieldDefinition, pointF_0[0].Y + (float)_QueueDefinition);
			val2.Object.BeginFigure(val3, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
			for (uint num = 1u; num < pointF_0.Length; num++)
			{
				val3 = new D2D_POINT_2F(pointF_0[num].X + (float)m_FieldDefinition, pointF_0[num].Y + (float)_QueueDefinition);
				val2.AddLine(val3);
			}
			val2.Object.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
			val2.Object.Close();
			val2.Dispose();
			D2D1_BRUSH_PROPERTIES val4 = default(D2D1_BRUSH_PROPERTIES);
			val4.opacity = 1f;
			D2D1_BRUSH_PROPERTIES value = val4;
			_D3DCOLORVALUE val5 = _D3DCOLORVALUE.FromArgb(color_0.A, color_0.R, color_0.G, color_0.B);
			IComObject<ID2D1SolidColorBrush> val6 = annotationDefinition.CreateSolidColorBrush(val5, value);
			annotationDefinition.Object.FillGeometry(val.Object, val6.Object, null);
			val.Dispose();
			val6.Dispose();
		}
	}

	public void FillRing(Point[] point_0, Point[] point_1, Color color_0)
	{
		if (Drawing)
		{
			IComObject<ID2D1PathGeometry1> val = policyDefinition.CreatePathGeometry();
			IComObject<ID2D1SimplifiedGeometrySink> val2 = val.Open();
			D2D_POINT_2F val3 = default(D2D_POINT_2F);
			val3 = new D2D_POINT_2F(point_0[0].X + m_FieldDefinition, point_0[0].Y + _QueueDefinition);
			val2.Object.BeginFigure(val3, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
			for (uint num = 1u; num < point_0.Length; num++)
			{
				val3 = new D2D_POINT_2F(point_0[num].X + m_FieldDefinition, point_0[num].Y + _QueueDefinition);
				val2.AddLine(val3);
			}
			val2.Object.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
			val2.Object.Close();
			IComObject<ID2D1PathGeometry1> val4 = policyDefinition.CreatePathGeometry();
			IComObject<ID2D1SimplifiedGeometrySink> val5 = val4.Open();
			val3 = new D2D_POINT_2F(point_1[0].X + m_FieldDefinition, point_1[0].Y + _QueueDefinition);
			val5.Object.BeginFigure(val3, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
			for (uint num2 = 1u; num2 < point_1.Length; num2++)
			{
				val3 = new D2D_POINT_2F(point_1[num2].X + m_FieldDefinition, point_1[num2].Y + _QueueDefinition);
				val5.AddLine(val3);
			}
			val5.Object.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
			val5.Object.Close();
			IComObject<ID2D1PathGeometry1> val6 = policyDefinition.CreatePathGeometry();
			IComObject<ID2D1SimplifiedGeometrySink> val7 = val6.Open();
			val.Object.CombineWithGeometry(val4.Object, D2D1_COMBINE_MODE.D2D1_COMBINE_MODE_XOR, IntPtr.Zero, 1f, val7.Object);
			val7.Object.Close();
			D2D1_BRUSH_PROPERTIES val8 = default(D2D1_BRUSH_PROPERTIES);
			val8.opacity = 1f;
			D2D1_BRUSH_PROPERTIES value = val8;
			_D3DCOLORVALUE val9 = _D3DCOLORVALUE.FromArgb(color_0.A, color_0.R, color_0.G, color_0.B);
			if (!_MerchantVal.TryGetValue(color_0, out var value2))
			{
				value2 = annotationDefinition.CreateSolidColorBrush(val9, value);
			}
			annotationDefinition.Object.FillGeometry(val6.Object, value2.Object, null);
			val2.Dispose();
			val.Dispose();
			val4.Dispose();
			val5.Dispose();
			val6.Dispose();
			val7.Dispose();
		}
	}

	private IComObject<ID2D1PathGeometry> UpdateIssuer(Point[] point_0)
	{
		IComObject<ID2D1PathGeometry1> val = policyDefinition.CreatePathGeometry();
		IComObject<ID2D1SimplifiedGeometrySink> val2 = val.Open();
		ID2D1SimplifiedGeometrySink @object = val2.Object;
		D2D_POINT_2F val3 = default(D2D_POINT_2F);
		val3 = new D2D_POINT_2F(point_0[0].X + m_FieldDefinition, point_0[0].Y + _QueueDefinition);
		@object.BeginFigure(val3, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
		for (uint num = 1u; num < point_0.Length; num++)
		{
			val3 = new D2D_POINT_2F(point_0[num].X + m_FieldDefinition, point_0[num].Y + _QueueDefinition);
			@object.AddLine(val3);
		}
		@object.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
		@object.Close();
		val2.Dispose();
		return val;
	}

	public void DrawCombinedPolygon(List<Point[]> list_0, Color color_0, float float_0, bool bool_0)
	{
		_ExceptionDefinition?.Handle(RenderEvent.CombinePolygons, list_0);
		if (Drawing && list_0.Count != 0)
		{
			float_0 *= 1.5f;
			D2D1_BRUSH_PROPERTIES val = default(D2D1_BRUSH_PROPERTIES);
			val.opacity = 1f;
			D2D1_BRUSH_PROPERTIES value = val;
			_D3DCOLORVALUE val2 = _D3DCOLORVALUE.FromArgb(color_0.A, color_0.R, color_0.G, color_0.B);
			IComObject<ID2D1SolidColorBrush> val3 = annotationDefinition.CreateSolidColorBrush(val2, value);
			IComObject<ID2D1PathGeometry1> val4 = InsertIssuer(list_0);
			ID2D1StrokeStyle val5 = (bool_0 ? propertyVal : m_ReaderVal);
			annotationDefinition.Object.DrawGeometry(val4.Object, val3.Object, float_0, val5);
			val4.Dispose();
			val3.Dispose();
		}
	}

	private IComObject<ID2D1PathGeometry1> InsertIssuer(List<Point[]> list_0)
	{
		List<IComObject<ID2D1Geometry>> list = new List<IComObject<ID2D1Geometry>>();
		int num = 8;
		int num2 = 0;
		while (list_0.Count > num2 * num)
		{
			int num3 = num2++ * num;
			List<Point[]> range = list_0.GetRange(num3, Math.Min(num, list_0.Count - num3));
			list.Add(PrepareIssuer(range));
		}
		return ReflectIssuer(list);
	}

	private IComObject<ID2D1PathGeometry1> PrepareIssuer(List<Point[]> list_0)
	{
		List<IComObject<ID2D1Geometry>> list = new List<IComObject<ID2D1Geometry>>(list_0.Count);
		for (int i = 0; i < list_0.Count; i++)
		{
			IComObject<ID2D1PathGeometry> item = UpdateIssuer(list_0[i]);
			list.Add(item);
		}
		return ReflectIssuer(list);
	}

	private unsafe IComObject<ID2D1PathGeometry1> ReflectIssuer(List<IComObject<ID2D1Geometry>> list_0)
	{
		int count = list_0.Count;
		valueVal.Clear();
		for (int i = 0; i < count; i++)
		{
			valueVal.Add(list_0[i].Object);
		}
		IComObject<ID2D1GeometryGroup> val = policyDefinition.CreateGeometryGroup(D2D1_FILL_MODE.D2D1_FILL_MODE_WINDING, valueVal);
		for (int j = 0; j < count; j++)
		{
			list_0[j].Dispose();
		}
		IComObject<ID2D1PathGeometry1> obj = policyDefinition.CreatePathGeometry();
		IComObject<ID2D1SimplifiedGeometrySink> val2 = obj.Open();
		val.Object.Outline((IntPtr)(void*)null, 0f, val2.Object);
		val2.Object.Close();
		val2.Dispose();
		val.Dispose();
		return obj;
	}

	internal SQLiteConnection VisitIssuer(OSM_MBTiles_Layer osm_MBTiles_Layer_0)
	{
		if (1 == 0)
		{
		}
		SQLiteConnection result = osm_MBTiles_Layer_0 switch
		{
			OSM_MBTiles_Layer.BMNG => _ParameterVal, 
			OSM_MBTiles_Layer.Relief90 => _ExpressionVal, 
			OSM_MBTiles_Layer.Bathymetry => _DispatcherVal, 
			OSM_MBTiles_Layer.const_4 => m_ListenerVal, 
			OSM_MBTiles_Layer.LandCover300 => _ConfigVal, 
			OSM_MBTiles_Layer.Sentinel => m_RegistryVal, 
			_ => throw new ArgumentException("No SQLLite connection for: " + osm_MBTiles_Layer_0), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal byte[] RestartIssuer(OSM_MBTiles_Layer osm_MBTiles_Layer_0, int int_0, int int_1, int int_2)
	{
		using DbCommand dbCommand = VisitIssuer(osm_MBTiles_Layer_0).CreateCommand();
		dbCommand.CommandText = $"SELECT tile_data FROM tiles WHERE tile_column = {int_2} and tile_row = {int_1} and zoom_level = {int_0};";
		return dbCommand.ExecuteScalar() as byte[];
	}

	internal void TestIssuer(string string_0, string string_1, string string_2, string string_3, string string_4, ImageFormat imageFormat_0)
	{
		string text = _CreatorDefinition + string_3;
		byte[] array = null;
		if (string_2 == "Sentinel")
		{
			if (_DefinitionVal != null && ((DbConnection)_DefinitionVal).State == ConnectionState.Open)
			{
				string[] array2 = string_0.Split('/');
				string text2 = array2[0];
				string text3 = array2[1];
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(string_0);
				if (new SQLiteHelper(_DefinitionVal).ExecuteScalar("Select Count(*) from Tiles where zoom=" + text2 + " and column=" + text3 + " and row=" + fileNameWithoutExtension, bool_0: false) == "1")
				{
					array = StopIssuer(string_1, text, string_4);
				}
			}
			else
			{
				array = StopIssuer(string_1, text, string_4);
			}
		}
		else
		{
			array = StopIssuer(string_1, text, string_4);
		}
		if (array != null)
		{
			string path = Path.Combine(text, string_1);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (!File.Exists(path))
			{
				File.WriteAllBytes(path, array);
			}
			CallIssuer(string_0, array, imageFormat_0);
		}
	}

	internal byte[] StopIssuer(string string_0, string string_1, string string_2)
	{
		string text = Path.Combine(string_1, string_0);
		if (FileExistsNative.FileExistsFast(text))
		{
			try
			{
				return File.ReadAllBytes(text);
			}
			catch
			{
			}
		}
		return HTTPHelper.DownloadTile(string_2 + string_0);
	}

	internal byte[] CancelIssuer(string string_0)
	{
		return HTTPHelper.DownloadTile("http://a" + string_0[string_0.Length - 1] + ".ortho.tiles.virtualearth.net/tiles/a" + string_0 + ".jpeg?g=15");
	}

	internal Bitmap VerifyIssuer(byte[] byte_0)
	{
		return valVal.DecodeFromBytes(byte_0, byte_0.Length);
	}

	private void ListIssuer()
	{
		PointF[] pointF_ = new PointF[4]
		{
			new PointF
			{
				X = _RegDefinition - 20,
				Y = 10f
			},
			new PointF
			{
				X = _RegDefinition - 10,
				Y = 10f
			},
			new PointF
			{
				X = _RegDefinition - 10,
				Y = 20f
			},
			new PointF
			{
				X = _RegDefinition - 20,
				Y = 20f
			}
		};
		Color color_ = Color.FromArgb(128, 0, 255, 0);
		if (threadVal.Count != 0)
		{
			color_ = Color.FromArgb(128, 255, 0, 0);
			DrawText(threadVal.Count.ToString(), _RegDefinition - 22, 22, bool_0: false);
		}
		FillGeometry(pointF_, color_);
		DrawText($"F{observerVal,2} / B{issuerVal,2} / O{_ClientVal,2}", _RegDefinition - 93, 34, bool_0: false);
	}

	private void ResolveIssuer(Vertex[] vertex_0, uint[] uint_0, D3D_PRIMITIVE_TOPOLOGY d3D_PRIMITIVE_TOPOLOGY_0)
	{
		PostIssuer(null, vertex_0, uint_0, d3D_PRIMITIVE_TOPOLOGY_0, bool_0: false, 1f);
	}

	private void PostIssuer(string string_0, Vertex[] vertex_0, uint[] uint_0, D3D_PRIMITIVE_TOPOLOGY d3D_PRIMITIVE_TOPOLOGY_0, bool bool_0, float float_0)
	{
		serviceDefinition.BeginEvent("DrawLine");
		DrawParameters drawParameters_ = ((string_0 == null || !m_EventDefinition.ContainsKey(string_0)) ? RunIssuer(string_0, vertex_0, uint_0, d3D_PRIMITIVE_TOPOLOGY_0, bool_0) : m_EventDefinition[string_0]);
		drawParameters_.m_SingletonDefinition = float_0;
		ReadIssuer(drawParameters_);
		serviceDefinition.EndEvent();
	}

	internal DrawParameters RunIssuer(string string_0, Vertex[] vertex_0, uint[] uint_0, D3D_PRIMITIVE_TOPOLOGY d3D_PRIMITIVE_TOPOLOGY_0, bool bool_0)
	{
		TestsObjectListener testsObjectListener = default(TestsObjectListener);
		testsObjectListener.m_TokenizerVal = vertex_0;
		testsObjectListener._StubVal = uint_0;
		TestsObjectListener testsObjectListener_ = testsObjectListener;
		DrawParameters drawParameters_ = initializerDefinition;
		AddIssuer(testsObjectListener_, ref drawParameters_);
		drawParameters_.resolverDefinition = (bool_0 ? Layer.BlendableLine : Layer.Line);
		drawParameters_._UtilsDefinition = d3D_PRIMITIVE_TOPOLOGY_0;
		if (string_0 == null)
		{
			drawParameters_.m_ServerDefinition = true;
		}
		else
		{
			drawParameters_.m_ServerDefinition = false;
			m_EventDefinition[string_0] = drawParameters_;
		}
		return drawParameters_;
	}

	public void DrawLineStrip(Vertex[] vertex_0, uint[] uint_0)
	{
		ResolveIssuer(vertex_0, uint_0, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINESTRIP);
	}

	public void DrawLineStrip(string string_0, Vertex[] vertex_0, uint[] uint_0)
	{
		PostIssuer(string_0, vertex_0, uint_0, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINESTRIP, bool_0: false, 1f);
	}

	public void DrawLineList(Vertex[] vertex_0, uint[] uint_0)
	{
		ResolveIssuer(vertex_0, uint_0, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINELIST);
	}

	public void DrawLineList(string string_0, Vertex[] vertex_0, uint[] uint_0, float float_0)
	{
		PostIssuer(string_0, vertex_0, uint_0, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINELIST, bool_0: true, float_0);
	}

	public static Vector4 IntToVector4(int int_0)
	{
		Color color = Color.FromArgb(int_0);
		return new Vector4((float)(int)color.R / 256f, (float)(int)color.G / 256f, (float)(int)color.B / 256f, (float)(int)color.A / 256f);
	}

	public void LoadCustomOverlay(string string_0, string string_1, int int_0, int int_1)
	{
		IComObject<ID3D11ShaderResourceView> proccesorDefinition = LogoutIssuer(string_1, bool_0: true);
		StreamReader textReader_ = File.OpenText(string_0);
		float num = StartIssuer(textReader_);
		StartIssuer(textReader_);
		StartIssuer(textReader_);
		float num2 = StartIssuer(textReader_);
		float num3 = StartIssuer(textReader_);
		float num4 = StartIssuer(textReader_);
		DrawParameters drawParameters = initializerDefinition;
		drawParameters.proccesorDefinition = proccesorDefinition;
		drawParameters._TokenDefinition = num * (float)int_0 / 360f;
		drawParameters._StrategyDefinition = (num3 + 180f) / 360f;
		drawParameters.indexerDefinition = (0f - num2) * (float)int_1 / 180f;
		drawParameters._ConfigurationDefinition = 1f - (num4 + 90f) / 180f;
		drawParameters.m_ServerDefinition = false;
		drawParameters.adapterDefinition = true;
		drawParameters._PublisherDefinition = 1u;
		m_AttributeDefinition[string_1] = drawParameters;
	}

	public void ToggleCustomOverlay(string string_0)
	{
		if (!m_AttributeDefinition.Contains(string_0))
		{
			throw new Exception("Unrecognized custom overlay: " + string_0);
		}
		DrawParameters drawParameters = (DrawParameters)m_AttributeDefinition[string_0];
		drawParameters.adapterDefinition = !drawParameters.adapterDefinition;
		m_AttributeDefinition[string_0] = drawParameters;
	}

	public void RemoveCustomOverlay(string string_0)
	{
		if (!m_AttributeDefinition.Contains(string_0))
		{
			throw new Exception("Unrecognized custom overlay: " + string_0);
		}
		_CallbackVal.Remove(string_0);
		DrawParameters drawParameters = (DrawParameters)m_AttributeDefinition[string_0];
		m_AttributeDefinition.Remove(string_0);
		ID3D11Resource val = null;
		drawParameters.proccesorDefinition.Object.GetResource(out val);
		((IDisposable)new ComObject<ID3D11Resource>(val)).Dispose();
		drawParameters.proccesorDefinition.Dispose();
		drawParameters.proccesorDefinition = null;
	}

	public string[] CustomOverlayNames()
	{
		ICollection keys = m_AttributeDefinition.Keys;
		string[] array = new string[m_AttributeDefinition.Count];
		keys.CopyTo(array, 0);
		return array;
	}

	public bool IsVisibleCustomOverlay(string string_0)
	{
		if (!m_AttributeDefinition.Contains(string_0))
		{
			throw new Exception("Unrecognized custom overlay: " + string_0);
		}
		return ((DrawParameters)m_AttributeDefinition[string_0]).adapterDefinition;
	}

	public void MoveUpCustomOverlay(string string_0)
	{
		if (m_AttributeDefinition.Contains(string_0))
		{
			ICollection keys = m_AttributeDefinition.Keys;
			int num = 0;
			foreach (string item in keys)
			{
				if (!(string_0 == item))
				{
					num++;
					continue;
				}
				break;
			}
			object value = m_AttributeDefinition[num];
			m_AttributeDefinition.RemoveAt(num);
			num = Math.Max(0, num - 1);
			m_AttributeDefinition.Insert(num, string_0, value);
			return;
		}
		throw new Exception("Unrecognized custom overlay: " + string_0);
	}

	public void MoveDownCustomOverlay(string string_0)
	{
		if (m_AttributeDefinition.Contains(string_0))
		{
			ICollection keys = m_AttributeDefinition.Keys;
			int num = 0;
			foreach (string item in keys)
			{
				if (!(string_0 == item))
				{
					num++;
					continue;
				}
				break;
			}
			object value = m_AttributeDefinition[num];
			m_AttributeDefinition.RemoveAt(num);
			num = Math.Min(m_AttributeDefinition.Count, ++num);
			m_AttributeDefinition.Insert(num, string_0, value);
			return;
		}
		throw new Exception("Unrecognized custom overlay: " + string_0);
	}

	internal static float StartIssuer(TextReader textReader_0)
	{
		return float.Parse(textReader_0.ReadLine(), CultureInfo.InvariantCulture);
	}

	internal int AssetIssuer()
	{
		return _ProcessVal.Count;
	}

	internal int PrintIssuer()
	{
		return m_InstanceVal;
	}

	internal int DefineIssuer()
	{
		return _ObjectVal;
	}

	public void ClearTiles()
	{
		for (int i = 0; i < threadVal.Count; i++)
		{
			threadVal[i].m_ErrorDefinition.Cancel();
		}
		while (threadVal.Count > 0)
		{
			for (int j = 0; j < threadVal.Count; j++)
			{
				if (threadVal[j]._RefDefinition.Status >= TaskStatus.RanToCompletion)
				{
					threadVal.RemoveAt(j);
				}
			}
		}
		SpecificationVal result;
		while (decoratorVal.TryDequeue(out result))
		{
			result._ReponseVal.Free();
		}
		foreach (KeyValuePair<string, DrawParameters> item in _ProcessVal)
		{
			ChangeIssuer(item.Key);
		}
		_RuleVal.Clear();
	}

	public void HandleKeypress(char char_0)
	{
		_ExceptionDefinition?.Handle(RenderEvent.Keypress, char_0);
	}

	public int GetAssignedLevel(float float_0)
	{
		return InvokeIssuer(Layer.FileSystem, FileSystemLayer.OpenTopo, float_0);
	}

	public float GetAssignedAltitude(int int_0)
	{
		return IncludeIssuer(Layer.FileSystem, FileSystemLayer.OpenTopo, int_0);
	}

	public int CountDrawnTiles()
	{
		return DefineIssuer();
	}

	public int CountLoadTiles()
	{
		return PrintIssuer();
	}

	public int CountAllTiles()
	{
		return AssetIssuer();
	}
}
