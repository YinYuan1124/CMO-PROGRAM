using System;
using System.Drawing;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;

namespace Command;

public class CommandSecondaryFormBase : Form
{
	internal bool contextRequest;

	internal bool m_StatusRequest;

	protected bool AutoFocusOnClick;

	public CommandSecondaryFormBase()
	{
		base.Activated += AssetConfiguration;
		base.FormClosing += DefineConfiguration;
		contextRequest = true;
		m_StatusRequest = true;
		AutoFocusOnClick = true;
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
			if (!PrintConfiguration(base.Location, base.Size))
			{
				CenterToScreen();
			}
		}
	}

	private void AssetConfiguration(object sender, EventArgs e)
	{
		if (!Client.infoClass)
		{
			base.Owner = ItemExporter.ConnectInterruptibleTemplate.MainForm;
		}
	}

	private bool PrintConfiguration(Point point_0, Size size_0, double double_0 = 0.1)
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

	public Color GetComponentDamageBackColor(PlatformComponent platformComponent_0)
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
			return Color.Red;
		}
		if ((object)platformComponent_0.GetType() == typeof(AirFacility))
		{
			AirFacility airFacility = (AirFacility)platformComponent_0;
			if ((int)airFacility.MaxAircraftSize > (int)airFacility.EffectiveRunwaySize)
			{
				return Color.Yellow;
			}
		}
		return Color.White;
	}

	private void DefineConfiguration(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	protected override void WndProc(ref Message m)
	{
		if (AutoFocusOnClick && !Focused && m.Msg == 528)
		{
			switch (0xFFFF & (long)m.WParam)
			{
			case 513L:
			case 516L:
			case 519L:
			case 523L:
			case 582L:
				Activate();
				break;
			}
		}
		base.WndProc(ref m);
	}

	private void PublishConfiguration()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(CommandSecondaryFormBase));
		SuspendLayout();
		base.ClientSize = new Size(284, 261);
		base.Icon = componentResourceManager.GetIcon("$this.Icon");
		base.Name = "CommandSecondaryFormBase";
		ResumeLayout(performLayout: false);
	}
}
