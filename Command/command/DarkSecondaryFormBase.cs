using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CSMaterial;
using Command.Messages;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DarkSecondaryFormBase : DarkForm
{
	public bool _IsDisposed;

	private IContainer configurationValue;

	internal bool tokenValue;

	internal bool _IndexerValue;

	public DarkSecondaryFormBase()
	{
		base.Activated += LogoutServer;
		tokenValue = true;
		_IndexerValue = true;
		SelectServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && configurationValue != null)
			{
				configurationValue.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
			_IsDisposed = true;
		}
	}

	[DebuggerStepThrough]
	private void SelectServer()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(DarkSecondaryFormBase));
		SuspendLayout();
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(284, 261);
		DoubleBuffered = true;
		Font = new Font("Segoe UI", 9f);
		base.Icon = componentResourceManager.GetIcon("$this.Icon");
		base.Name = "DarkSecondaryFormBase";
		Text = "DarkSecondaryFormBase";
		ResumeLayout(performLayout: false);
		WindowDarkMode.UseImmersiveDarkMode(base.Handle, bool_0: true);
	}

	protected override void OnMove(EventArgs e)
	{
		base.OnMove(e);
		if (base.Visible)
		{
			WindowPlacement.UpdateWindowPlacementSetting(base.Name, base.Location.X, base.Location.Y, base.Width, base.Height);
		}
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		if (base.Visible)
		{
			WindowPlacement.UpdateWindowPlacementSetting(base.Name, base.Location.X, base.Location.Y, base.Width, base.Height);
		}
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		base.OnVisibleChanged(e);
		if (base.Visible)
		{
			WindowPlacement.GetWindowPlacementSetting(this);
			if (!CallServer(base.Location, base.Size))
			{
				CenterToScreen();
			}
		}
	}

	private bool CallServer(Point point_0, Size size_0, double double_0 = 0.1)
	{
		double num = 0.0;
		Rectangle a = new Rectangle(point_0, size_0);
		Screen[] allScreens = Screen.AllScreens;
		Screen[] array = allScreens;
		foreach (Screen screen in array)
		{
			Rectangle rectangle = Rectangle.Intersect(a, screen.WorkingArea);
			if ((rectangle.Width != 0) & (rectangle.Height != 0))
			{
				num += (double)(rectangle.Width * rectangle.Height);
			}
		}
		return num >= (double)(a.Width * a.Height) * double_0;
	}

	private void LogoutServer(object sender, EventArgs e)
	{
		if (!Client.infoClass)
		{
			base.Owner = ItemExporter.ConnectInterruptibleTemplate.MainForm;
		}
	}

	public Color GetComponentDamageColor(PlatformComponent platformComponent_0)
	{
		if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Damaged)
		{
			switch (platformComponent_0.DamageSeverity)
			{
			case PlatformComponent._DamageSeverityFactor.Light:
				return Color.Yellow;
			case PlatformComponent._DamageSeverityFactor.Medium:
				return Color.Orange;
			case PlatformComponent._DamageSeverityFactor.Heavy:
				return Color.OrangeRed;
			}
		}
		if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Destroyed)
		{
			return Color.IndianRed;
		}
		if ((object)platformComponent_0.GetType() == typeof(AirFacility))
		{
			AirFacility airFacility = (AirFacility)platformComponent_0;
			if ((int)airFacility.MaxAircraftSize > (int)airFacility.EffectiveRunwaySize)
			{
				return Color.Yellow;
			}
		}
		return Color.LightGray;
	}
}
