using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class OrbitAnchor : Window, IComponentConnector
{
	public Satellite SelectedSatellite;

	private bool _StructSchema;

	internal TextBox TB_Longitude;

	internal TextBox TB_Latitude;

	internal TextBox TB_Altitude;

	internal Button Button_UseCurrent;

	internal Button Button_OK;

	internal CheckBox CB_ApplyAnchor;

	private bool _contentLoaded;

	public OrbitAnchor()
	{
		base.ContentRendered += NewInterruptibleCode;
		InitializeComponent();
	}

	private void GetInterruptibleCode(object sender, RoutedEventArgs e)
	{
		if (CB_ApplyAnchor.IsChecked.GetValueOrDefault())
		{
			if (!Versioned.IsNumeric(TB_Longitude.Text))
			{
				DarkMessageBox.ShowError("经度无效！", "Error");
				return;
			}
			if (!Math2.AwakeClass(Conversions.ToDouble(TB_Longitude.Text)))
			{
				DarkMessageBox.ShowError("经度无效！", "Error");
				return;
			}
			if (!Versioned.IsNumeric(TB_Latitude.Text))
			{
				DarkMessageBox.ShowError("纬度无效！", "Error");
				return;
			}
			if (!Math2.QueryClass(Conversions.ToDouble(TB_Latitude.Text)))
			{
				DarkMessageBox.ShowError("纬度无效！", "Error");
				return;
			}
			if (!Versioned.IsNumeric(TB_Altitude.Text))
			{
				DarkMessageBox.ShowError("海拔高度无效！", "Error");
				return;
			}
			Satellite.SatelliteOrbitAnchor satelliteOrbitAnchor = new Satellite.SatelliteOrbitAnchor();
			satelliteOrbitAnchor.Longitude = Conversions.ToDouble(TB_Longitude.Text);
			satelliteOrbitAnchor.Latitude = Conversions.ToDouble(TB_Latitude.Text);
			satelliteOrbitAnchor.Altitude = Conversions.ToSingle(TB_Altitude.Text) * 1000f;
			SelectedSatellite.OrbitAnchor = satelliteOrbitAnchor;
		}
		else
		{
			SelectedSatellite.OrbitAnchor = null;
		}
		Close();
	}

	private void WriteInterruptibleCode(object sender, RoutedEventArgs e)
	{
		TB_Longitude.Text = Conversions.ToString(SelectedSatellite.GetLongitude());
		TB_Latitude.Text = Conversions.ToString(SelectedSatellite.GetLatitude());
		TB_Altitude.Text = Conversions.ToString(SelectedSatellite.GetCurrentAltitude() / 1000f);
	}

	private void NewInterruptibleCode(object sender, EventArgs e)
	{
		base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
		if (SelectedSatellite.OrbitAnchor == null)
		{
			CB_ApplyAnchor.IsChecked = false;
			TB_Longitude.Text = "";
			TB_Latitude.Text = "";
			TB_Altitude.Text = "";
		}
		else
		{
			CB_ApplyAnchor.IsChecked = true;
			TB_Longitude.Text = Conversions.ToString(SelectedSatellite.OrbitAnchor.Longitude);
			TB_Latitude.Text = Conversions.ToString(SelectedSatellite.OrbitAnchor.Latitude);
			TB_Altitude.Text = Conversions.ToString(SelectedSatellite.OrbitAnchor.Altitude / 1000f);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/orbitanchor.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			TB_Longitude = (TextBox)target;
			break;
		case 2:
			TB_Latitude = (TextBox)target;
			break;
		case 3:
			TB_Altitude = (TextBox)target;
			break;
		case 4:
			Button_UseCurrent = (Button)target;
			Button_UseCurrent.Click += WriteInterruptibleCode;
			break;
		case 5:
			Button_OK = (Button)target;
			Button_OK.Click += GetInterruptibleCode;
			break;
		case 6:
			CB_ApplyAnchor = (CheckBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
