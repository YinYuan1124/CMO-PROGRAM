using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Command_Core;
using DXRenderer;
using ExWorldWind.Interop;
using Worldwind.Component;

namespace ExWorldWind;

public class WorldWindow : Control
{
	public delegate void DebugFormWriteDelegate(string str);

	public delegate void DebugFormWriteExceptionDelegate(string str, Exception e);

	public delegate void GraphicsCrashDelegate(string str);

	private bool predicateProcess;

	private DrawArgs _SingletonProcess;

	private bool recordProcess;

	private string exceptionProcess = "";

	private long m_AttrProcess;

	private int visitorProcess;

	private string prototypeProcess;

	private bool comparatorProcess;

	private bool itemProcess;

	private bool setterProcess;

	private Point _CreatorProcess = Point.Empty;

	private bool m_TemplateProcess;

	private System.Timers.Timer m_MappingProcess = new System.Timers.Timer(250.0);

	private System.Timers.Timer mockProcess;

	private bool tagProcess;

	public bool bool_0;

	public CommandLayer CommandLayer;

	[CompilerGenerated]
	private static DebugFormWriteExceptionDelegate _FieldProcess;

	[CompilerGenerated]
	private static DebugFormWriteDelegate m_QueueProcess;

	[CompilerGenerated]
	private static GraphicsCrashDelegate _RegProcess;

	private static bool paramProcess;

	private ArrayList m_PageProcess = new ArrayList();

	private int _RulesProcess = 255;

	private int _MethodProcess = 40;

	private int m_ServiceProcess = 205;

	public DateTime LastMouseWheelEvent = DateTime.UtcNow;

	private bool _SystemProcess;

	private Angle candidateProcess;

	private Angle _BaseProcess;

	public float fps { get; private set; }

	public bool ControlHeld
	{
		get
		{
			return tagProcess;
		}
		set
		{
			tagProcess = value;
		}
	}

	public System.Timers.Timer MouseHoverTimer => mockProcess;

	public string Caption
	{
		get
		{
			return exceptionProcess;
		}
		set
		{
			exceptionProcess = value;
		}
	}

	public DrawArgs DrawArgs => _SingletonProcess;

	public bool IsRenderDisabled
	{
		get
		{
			return itemProcess;
		}
		set
		{
			itemProcess = value;
		}
	}

	public static event DebugFormWriteExceptionDelegate DebugFormWriteException
	{
		[CompilerGenerated]
		add
		{
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate = _FieldProcess;
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate2;
			do
			{
				debugFormWriteExceptionDelegate2 = debugFormWriteExceptionDelegate;
				DebugFormWriteExceptionDelegate value2 = (DebugFormWriteExceptionDelegate)Delegate.Combine(debugFormWriteExceptionDelegate2, value);
				debugFormWriteExceptionDelegate = Interlocked.CompareExchange(ref _FieldProcess, value2, debugFormWriteExceptionDelegate2);
			}
			while ((object)debugFormWriteExceptionDelegate != debugFormWriteExceptionDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate = _FieldProcess;
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate2;
			do
			{
				debugFormWriteExceptionDelegate2 = debugFormWriteExceptionDelegate;
				DebugFormWriteExceptionDelegate value2 = (DebugFormWriteExceptionDelegate)Delegate.Remove(debugFormWriteExceptionDelegate2, value);
				debugFormWriteExceptionDelegate = Interlocked.CompareExchange(ref _FieldProcess, value2, debugFormWriteExceptionDelegate2);
			}
			while ((object)debugFormWriteExceptionDelegate != debugFormWriteExceptionDelegate2);
		}
	}

	public static event DebugFormWriteDelegate DebugFormWrite
	{
		[CompilerGenerated]
		add
		{
			DebugFormWriteDelegate debugFormWriteDelegate = m_QueueProcess;
			DebugFormWriteDelegate debugFormWriteDelegate2;
			do
			{
				debugFormWriteDelegate2 = debugFormWriteDelegate;
				DebugFormWriteDelegate value2 = (DebugFormWriteDelegate)Delegate.Combine(debugFormWriteDelegate2, value);
				debugFormWriteDelegate = Interlocked.CompareExchange(ref m_QueueProcess, value2, debugFormWriteDelegate2);
			}
			while ((object)debugFormWriteDelegate != debugFormWriteDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			DebugFormWriteDelegate debugFormWriteDelegate = m_QueueProcess;
			DebugFormWriteDelegate debugFormWriteDelegate2;
			do
			{
				debugFormWriteDelegate2 = debugFormWriteDelegate;
				DebugFormWriteDelegate value2 = (DebugFormWriteDelegate)Delegate.Remove(debugFormWriteDelegate2, value);
				debugFormWriteDelegate = Interlocked.CompareExchange(ref m_QueueProcess, value2, debugFormWriteDelegate2);
			}
			while ((object)debugFormWriteDelegate != debugFormWriteDelegate2);
		}
	}

	public static event GraphicsCrashDelegate GraphicsCrash
	{
		[CompilerGenerated]
		add
		{
			GraphicsCrashDelegate graphicsCrashDelegate = _RegProcess;
			GraphicsCrashDelegate graphicsCrashDelegate2;
			do
			{
				graphicsCrashDelegate2 = graphicsCrashDelegate;
				GraphicsCrashDelegate value2 = (GraphicsCrashDelegate)Delegate.Combine(graphicsCrashDelegate2, value);
				graphicsCrashDelegate = Interlocked.CompareExchange(ref _RegProcess, value2, graphicsCrashDelegate2);
			}
			while ((object)graphicsCrashDelegate != graphicsCrashDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GraphicsCrashDelegate graphicsCrashDelegate = _RegProcess;
			GraphicsCrashDelegate graphicsCrashDelegate2;
			do
			{
				graphicsCrashDelegate2 = graphicsCrashDelegate;
				GraphicsCrashDelegate value2 = (GraphicsCrashDelegate)Delegate.Remove(graphicsCrashDelegate2, value);
				graphicsCrashDelegate = Interlocked.CompareExchange(ref _RegProcess, value2, graphicsCrashDelegate2);
			}
			while ((object)graphicsCrashDelegate != graphicsCrashDelegate2);
		}
	}

	public WorldWindow()
	{
		if (CloneRule())
		{
			return;
		}
		SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, value: true);
		base.Size = new Size(1, 1);
		try
		{
			_SingletonProcess = DrawArgs.Instance;
			base.MouseEnter += CustomizeRule;
			base.MouseLeave += CountRule;
			base.MouseMove += RevertThread;
			mockProcess = new System.Timers.Timer();
			mockProcess.Interval = 2500.0;
		}
		catch (Exception innerException)
		{
			throw new Exception("Unable to initialize WorldWindow.", innerException);
		}
	}

	private void RevertThread(object sender, MouseEventArgs e)
	{
		mockProcess.Start();
	}

	private void CountRule(object sender, EventArgs e)
	{
		mockProcess.Stop();
	}

	private void CustomizeRule(object sender, EventArgs e)
	{
		mockProcess.Start();
	}

	public void GotoLatLon(double double_0, double double_1)
	{
		Main.Instance?.SetProjection((float)double_1, (float)double_0, _SingletonProcess.WorldCamera.Altitude);
		DrawArgs.Instance.WorldCamera.SetPosition(double_0, double_1);
	}

	[SpecialName]
	private static bool smethod_0()
	{
		NativeMethods.Message message_;
		return !NativeMethods.PeekMessage(out message_, IntPtr.Zero, 0u, 0u, 0u);
	}

	public static void DebugWrite(string string_0)
	{
		m_QueueProcess(string_0);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (paramProcess)
		{
			GameGeneral.WriteLogDebugInfoToFile("Map received message to paint while painting.");
			return;
		}
		Main instance = Main.Instance;
		if (instance == null || !instance.Initialized || instance.Resizing)
		{
			return;
		}
		paramProcess = true;
		try
		{
			if (!predicateProcess)
			{
				if (Main.Instance != null && !bool_0)
				{
					Main.Instance.ManageTiles(Convert.ToSingle(DrawArgs.Instance.WorldCamera.Longitude.Degrees), Convert.ToSingle(DrawArgs.Instance.WorldCamera.Latitude.Degrees), Convert.ToSingle(DrawArgs.Instance.WorldCamera.Altitude));
					Main.Instance.BeginDrawing();
				}
				Render();
				if (Main.Instance != null && !bool_0)
				{
					Main.Instance.FinishDrawing();
				}
			}
		}
		catch (Exception ex)
		{
			GameGeneral.WriteLogDebugInfoToFile("Map exception while painting: " + ex);
			_FieldProcess("WW.WW.OnPaint Exception", ex);
			throw new Exception("WorldWindow OnPaint exception", ex);
		}
		finally
		{
			paramProcess = false;
		}
	}

	public void Render()
	{
		if (!IsRenderDisabled && Main.Instance == null)
		{
			Thread.Sleep(25);
		}
		else
		{
			CommandLayer.Render(_SingletonProcess);
		}
	}

	public void ResetToolbar()
	{
	}

	public void HandleMouseWheel(MouseEventArgs mouseEventArgs_0)
	{
		OnMouseWheel(mouseEventArgs_0);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		try
		{
			LastMouseWheelEvent = DateTime.UtcNow;
			_SingletonProcess.WorldCamera.ZoomStepped((float)e.Delta / 120f);
		}
		finally
		{
			base.OnMouseWheel(e);
		}
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		try
		{
			ke.Handled = true;
			base.OnKeyDown(ke);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		try
		{
			base.OnKeyUp(e);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		base.OnKeyPress(e);
	}

	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
	public override bool PreProcessMessage(ref Message msg)
	{
		if (msg.Msg == 256)
		{
			Keys keys = (Keys)msg.WParam.ToInt32();
			if ((uint)(keys - 37) <= 3u)
			{
				OnKeyDown(new KeyEventArgs(keys));
				msg.Result = (IntPtr)1;
				return true;
			}
		}
		return base.PreProcessMessage(ref msg);
	}

	public bool HandleKeyUp(KeyEventArgs keyEventArgs_0)
	{
		if (tagProcess && !keyEventArgs_0.Control)
		{
			tagProcess = false;
		}
		if (!keyEventArgs_0.Alt)
		{
			if (keyEventArgs_0.Control)
			{
				switch (keyEventArgs_0.KeyCode)
				{
				case Keys.W:
					m_TemplateProcess = !m_TemplateProcess;
					return true;
				case Keys.D:
					recordProcess = !recordProcess;
					return true;
				}
				tagProcess = false;
			}
			else
			{
				Keys keyCode = keyEventArgs_0.KeyCode;
				if (keyCode == Keys.Clear || keyCode == Keys.Space)
				{
					return true;
				}
			}
		}
		return false;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		Focus();
		DrawArgs.LastMousePosition.X = e.X;
		DrawArgs.LastMousePosition.Y = e.Y;
		_CreatorProcess.X = e.X;
		_CreatorProcess.Y = e.Y;
		try
		{
		}
		finally
		{
			if (e.Button == MouseButtons.Left)
			{
				DrawArgs.IsLeftMouseButtonDown = true;
			}
			if (e.Button == MouseButtons.Right)
			{
				DrawArgs.IsRightMouseButtonDown = true;
			}
			base.OnMouseDown(e);
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		_SystemProcess = true;
		base.OnMouseDoubleClick(e);
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		DrawArgs.LastMousePosition.X = mevent.X;
		DrawArgs.LastMousePosition.Y = mevent.Y;
		try
		{
			if (_CreatorProcess == Point.Empty)
			{
				return;
			}
			_CreatorProcess = Point.Empty;
			if (Main.Instance == null || _SystemProcess)
			{
				return;
			}
			if (mevent.Button == MouseButtons.Left)
			{
				if (setterProcess)
				{
					setterProcess = false;
				}
			}
			else if (mevent.Button == MouseButtons.Right && setterProcess)
			{
				setterProcess = false;
			}
		}
		finally
		{
			if (mevent.Button == MouseButtons.Left)
			{
				DrawArgs.IsLeftMouseButtonDown = false;
			}
			if (mevent.Button == MouseButtons.Right)
			{
				DrawArgs.IsRightMouseButtonDown = false;
			}
			base.OnMouseUp(mevent);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		try
		{
			int num = e.X - DrawArgs.LastMousePosition.X;
			int num2 = e.Y - DrawArgs.LastMousePosition.Y;
			float num3 = (float)num2 / _SingletonProcess.WorldCamera.ViewportHeight;
			if (_CreatorProcess == Point.Empty)
			{
				return;
			}
			bool flag = (e.Button & MouseButtons.Left) != 0;
			bool flag2 = (e.Button & MouseButtons.Right) != 0;
			if (flag || flag2)
			{
				int num4 = _CreatorProcess.X - e.X;
				int num5 = _CreatorProcess.Y - e.Y;
				if (num4 * num4 + num5 * num5 > 9)
				{
					setterProcess = true;
				}
			}
			if (!flag && flag2)
			{
				_SingletonProcess.WorldCamera.PickingRayIntersection(DrawArgs.LastMousePosition.X, DrawArgs.LastMousePosition.Y, out var angle_, out var angle_2);
				_SingletonProcess.WorldCamera.PickingRayIntersection(e.X, e.Y, out var angle_3, out var angle_4);
				if (!Angle.IsNaN(angle_3) && !Angle.IsNaN(angle_))
				{
					Angle angle_5 = angle_ - angle_3;
					Angle angle_6 = angle_2 - angle_4;
					_SingletonProcess.WorldCamera.Pan(angle_5, angle_6);
				}
				else
				{
					Angle angle_7 = Angle.FromRadians((double)num2 * (double)_SingletonProcess.WorldCamera.Altitude / 5102509568.0);
					Angle angle_8 = Angle.FromRadians((double)(-num) * (double)_SingletonProcess.WorldCamera.Altitude / 5102509568.0);
					_SingletonProcess.WorldCamera.Pan(angle_7, angle_8);
				}
			}
			else if ((flag || !flag2 || tagProcess) && flag && flag2 && Math.Abs(num3) > float.Epsilon)
			{
				_SingletonProcess.WorldCamera.Zoom((0f - num3) * 1f);
			}
		}
		catch
		{
		}
		finally
		{
			_SingletonProcess.WorldCamera.PickingRayIntersection(e.X, e.Y, out candidateProcess, out _BaseProcess);
			DrawArgs.LastMousePosition.X = e.X;
			DrawArgs.LastMousePosition.Y = e.Y;
			base.OnMouseMove(e);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
	}

	private static bool CloneRule()
	{
		return Application.ExecutablePath.ToUpper(CultureInfo.InvariantCulture).EndsWith("DEVENV.EXE");
	}

	static WorldWindow()
	{
		_FieldProcess = delegate
		{
		};
		m_QueueProcess = delegate
		{
		};
		_RegProcess = delegate
		{
		};
	}
}
