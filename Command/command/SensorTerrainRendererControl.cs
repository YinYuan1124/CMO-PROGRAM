using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CSMaterial;
using CSMaterial.Sonar;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Worldwind.Component;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
[DesignerGenerated]
public class SensorTerrainRendererControl : System.Windows.Controls.UserControl, INotifyPropertyChanged, IComponentConnector
{
	public sealed class Subject
	{
		public Module_Unit.Unit Unit;

		public ReferencePoint RP;

		public GeoPoint Geopoint;

		public Subject(Module_Unit.Unit unit_0)
		{
			Unit = unit_0;
		}

		public Subject(ReferencePoint referencePoint_0)
		{
			RP = referencePoint_0;
		}

		public Subject(GeoPoint geoPoint_0)
		{
			Geopoint = geoPoint_0;
		}

		public string GetDisplayName()
		{
			if (Information.IsNothing(Unit))
			{
				if (Information.IsNothing(RP))
				{
					if (Information.IsNothing(Geopoint))
					{
						return "Error";
					}
					return "Lat : " + Geopoint.Latitude + " / Long :" + Geopoint.Longitude;
				}
				return RP.Name;
			}
			return Unit.Name;
		}

		public GeoPoint GetGeopoint()
		{
			if (Information.IsNothing(Unit))
			{
				if (Information.IsNothing(RP))
				{
					if (Information.IsNothing(Geopoint))
					{
						return new GeoPoint(0.0, 0.0);
					}
					return Geopoint;
				}
				return new GeoPoint(RP.Longitude, RP.Latitude, 0f);
			}
			return new GeoPoint(Unit.GetLongitude(), Unit.GetLatitude(), Unit.GetCurrentAltitude());
		}

		public bool IsValid()
		{
			if (Information.IsNothing(Unit))
			{
				return false;
			}
			return true;
		}
	}

	public Subject SubjectA;

	public Subject SubjectB;

	[NonSerialized]
	private PropertyChangedEventHandler tagSingleton;

	[CompilerGenerated]
	private WriteableBitmap _FieldSingleton;

	private bool _QueueSingleton;

	internal StackPanel DisplayStack;

	private bool _contentLoaded;

	public WriteableBitmap SonarBitmap
	{
		[CompilerGenerated]
		get
		{
			return _FieldSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (_FieldSingleton != value)
			{
				_FieldSingleton = value;
				OnPropertyChanged("SonarBitmap");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = tagSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref tagSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = tagSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref tagSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public SensorTerrainRendererControl()
	{
		InitializeComponent();
		base.DataContext = this;
	}

	public void Refresh(Subject subject_0, Subject subject_1, VerticalProfilerRenderer verticalProfilerRenderer_0)
	{
		SubjectA = subject_0;
		SubjectB = subject_1;
		PushInterruptibleAdapter(verticalProfilerRenderer_0);
	}

	public bool IsReadyToRender()
	{
		if ((SubjectA == null) | (SubjectB == null))
		{
			return false;
		}
		if (SubjectA.IsValid())
		{
			return SubjectB.IsValid();
		}
		return false;
	}

	private void PushInterruptibleAdapter(VerticalProfilerRenderer verticalProfilerRenderer_0)
	{
		if (!IsReadyToRender())
		{
			return;
		}
		SonarRender sonarRender = new SonarRender();
		sonarRender.SideGutter_px = 0;
		sonarRender.TopGutter_px = 0;
		sonarRender.Width_px = 1400;
		sonarRender.Height_px = 800;
		int num = sonarRender.Width_px - sonarRender.SideGutter_px * 2;
		GeoPoint geopoint = SubjectA.GetGeopoint();
		GeoPoint geopoint2 = SubjectB.GetGeopoint();
		MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
		MainForm mainForm2 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
		Module_Unit.Unit unit = SubjectA.Unit;
		bool bool_ = false;
		bool bool_2 = false;
		int int_ = -1;
		bool bool_3 = false;
		mainForm.GetIconPath(mainForm2.CL_GetUnitIcon(unit, ref bool_, ref bool_2, ref int_, ref bool_3));
		try
		{
			PictureBox pictureSubjectA = verticalProfilerRenderer_0.PictureSubjectA;
			MainForm mainForm3 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			MainForm mainForm4 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			Module_Unit.Unit unit2 = SubjectA.Unit;
			bool_3 = false;
			bool_2 = false;
			int_ = -1;
			bool_ = false;
			pictureSubjectA.Image = System.Drawing.Image.FromFile(mainForm3.GetIconPath(mainForm4.CL_GetUnitIcon(unit2, ref bool_3, ref bool_2, ref int_, ref bool_)));
			PictureBox pictureBox = verticalProfilerRenderer_0.PictureBox1;
			MainForm mainForm5 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			MainForm mainForm6 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			Module_Unit.Unit unit3 = SubjectB.Unit;
			bool_ = false;
			bool_2 = false;
			int_ = -1;
			bool_3 = false;
			pictureBox.Image = System.Drawing.Image.FromFile(mainForm5.GetIconPath(mainForm6.CL_GetUnitIcon(unit3, ref bool_, ref bool_2, ref int_, ref bool_3)));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				ProjectData.ClearProjectError();
				return;
			}
			ProjectData.ClearProjectError();
		}
		sonarRender.LeftDepth_m = geopoint.Altitude;
		sonarRender.RightDepth_m = geopoint2.Altitude;
		sonarRender.Dist_m = (double)Math2.RunClass(geopoint, geopoint2) * 1852.0;
		double double_ = geopoint.Latitude * CSMath.PI_dividedBy_180;
		double double_2 = geopoint.Longitude * CSMath.PI_dividedBy_180;
		int_ = num;
		for (int i = 0; i <= int_; i++)
		{
			Tuple<double, double> tuple = CommandLayer.UTIL_OrthodromicInterpolation(double_, double_2, geopoint2.Latitude * CSMath.PI_dividedBy_180, geopoint2.Longitude * CSMath.PI_dividedBy_180, (double)i / (double)num);
			TerrainProfiler_Step terrainProfiler_Step = new TerrainProfiler_Step(Terrain.GetElevation(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, bool_0: true, Client.CurrentScenario));
			sonarRender.TerrainData.Add(terrainProfiler_Step);
			if (terrainProfiler_Step.Height <= 0.0)
			{
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, 0, Client.CurrentScenario);
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(thermalLayerAtThisLocation.Ceiling, -thermalLayerAtThisLocation.Floor + thermalLayerAtThisLocation.Ceiling, System.Windows.Media.Color.FromArgb(byte.MaxValue, (byte)(55 + (byte)Math.Round(thermalLayerAtThisLocation.Strength * 200f)), 0, 125)));
			}
			else
			{
				System.Drawing.Color color = LandCover.PatchClass(LandCover.DestroyClass(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, Client.CurrentScenario));
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(terrainProfiler_Step.Height, 400.0, System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B)));
			}
			Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(Client.CurrentScenario, tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, 0);
			double num2 = terrainProfiler_Step.Height;
			double num3 = terrainProfiler_Step.Height;
			if ((double)weatherAtThisTimeAndPlace.CloudInfo.HighCloudTop_m > terrainProfiler_Step.Height)
			{
				num2 = weatherAtThisTimeAndPlace.CloudInfo.HighCloudTop_m;
			}
			if ((double)weatherAtThisTimeAndPlace.CloudInfo.HighCloudBase_m > terrainProfiler_Step.Height)
			{
				num3 = weatherAtThisTimeAndPlace.CloudInfo.HighCloudBase_m;
			}
			if (num2 != terrainProfiler_Step.Height)
			{
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(num2, 0.0 - num3 + num2, System.Windows.Media.Color.FromArgb(185, 245, 245, 245)));
			}
			num2 = terrainProfiler_Step.Height;
			num3 = terrainProfiler_Step.Height;
			if ((double)weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudTop_m > terrainProfiler_Step.Height)
			{
				num2 = weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudTop_m;
			}
			if ((double)weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudBase_m > terrainProfiler_Step.Height)
			{
				num3 = weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudBase_m;
			}
			if (num2 != terrainProfiler_Step.Height)
			{
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(num2, 0.0 - num3 + num2, System.Windows.Media.Color.FromArgb(185, 245, 245, 245)));
			}
			num2 = terrainProfiler_Step.Height;
			num3 = terrainProfiler_Step.Height;
			if ((double)weatherAtThisTimeAndPlace.CloudInfo.LowCloudTop_m > terrainProfiler_Step.Height)
			{
				num2 = weatherAtThisTimeAndPlace.CloudInfo.LowCloudTop_m;
			}
			if ((double)weatherAtThisTimeAndPlace.CloudInfo.LowCloudBase_m > terrainProfiler_Step.Height)
			{
				num3 = weatherAtThisTimeAndPlace.CloudInfo.LowCloudBase_m;
			}
			if (num2 != terrainProfiler_Step.Height)
			{
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(num2, 0.0 - num3 + num2, System.Windows.Media.Color.FromArgb(185, 245, 245, 245)));
			}
			if (sonarRender.MaxHeight_m < terrainProfiler_Step.Height)
			{
				sonarRender.MaxHeight_m = terrainProfiler_Step.Height;
			}
			if (sonarRender.MinHeight_m > terrainProfiler_Step.Height)
			{
				sonarRender.MinHeight_m = terrainProfiler_Step.Height;
			}
		}
		sonarRender.MaxHeight_m = Math.Max(sonarRender.MaxHeight_m, geopoint.Altitude);
		sonarRender.MaxHeight_m = Math.Max(sonarRender.MaxHeight_m, geopoint2.Altitude);
		sonarRender.MinHeight_m = Math.Min(sonarRender.MinHeight_m, geopoint.Altitude);
		sonarRender.MinHeight_m = Math.Min(sonarRender.MinHeight_m, geopoint2.Altitude);
		verticalProfilerRenderer_0.Label_BottomAltitude.Text = (int)Math.Round(sonarRender.MinHeight_m) + "m";
		verticalProfilerRenderer_0.Label_TopAltitude.Text = (int)Math.Round(sonarRender.MaxHeight_m) + "m";
		sonarRender.Bitmap = new WriteableBitmap(sonarRender.Width_px, sonarRender.Height_px, 96.0, 96.0, PixelFormats.Bgra32, null);
		SonarBitmap = sonarRender.Bitmap;
		sonarRender.Render();
	}

	public void OnPropertyChanged(string string_0)
	{
		tagSingleton?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/sensorterrainrenderercontrol.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		if (connectionId == 1)
		{
			DisplayStack = (StackPanel)target;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
