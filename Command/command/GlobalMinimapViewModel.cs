using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using CSMaterial;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class GlobalMinimapViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class ModelRuleWatcher
	{
		public double Local_gw;

		public GlobalMinimapViewModel Me;

		public double Local_gh;

		internal void ResolveInterruptiblePage()
		{
			Local_gw = Me.GridControl.ActualWidth;
			Local_gh = Me.GridControl.ActualHeight;
		}
	}

	[CompilerGenerated]
	private sealed class WatcherMap
	{
		public GlobalMinimapViewModel Me;

		public double Local_GridWidth;

		public double Local_GridHeight;

		public uint[] Local_PIXEL_terrain;

		internal void PostInterruptiblePage()
		{
			bool flag = false;
			if (Me.BITMAP_terrain == null)
			{
				flag = true;
			}
			else if ((Me.BITMAP_terrain.Width != Local_GridWidth) | (Me.BITMAP_terrain.Height != Local_GridHeight))
			{
				flag = true;
			}
			if (flag)
			{
				Me.BITMAP_terrain = new WriteableBitmap((int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, null);
			}
			Me.BITMAP_terrain.WritePixels(new Int32Rect(0, 0, (int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight)), Local_PIXEL_terrain, (int)Math.Round(Local_GridWidth * 4.0), 0);
		}
	}

	[CompilerGenerated]
	private sealed class ReponseMap
	{
		public double Local_GridWidth;

		public GlobalMinimapViewModel Me;

		public double Local_GridHeight;

		public uint[] Local_PIXEL_units;

		public uint Local_alpha;

		public uint Local_red;

		public uint Local_green;

		public uint Local_blue;

		internal void RunInterruptiblePage(object xbar, object ybar, object PipSize)
		{
			object CounterResult = null;
			object LoopForResult = null;
			if (!ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult, Operators.NegateObject(PipSize), PipSize, 1, ref LoopForResult, ref CounterResult))
			{
				return;
			}
			object CounterResult2 = null;
			object LoopForResult2 = null;
			do
			{
				if (!ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult2, Operators.NegateObject(PipSize), PipSize, 1, ref LoopForResult2, ref CounterResult2))
				{
					continue;
				}
				do
				{
					int num = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(Local_GridWidth, Operators.AddObject(ybar, CounterResult2)), Operators.AddObject(xbar, CounterResult)));
					if (num >= 0 && num < Local_PIXEL_units.Count())
					{
						if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(CounterResult2, Operators.NegateObject(PipSize), TextCompare: true), Operators.CompareObjectEqual(CounterResult2, PipSize, TextCompare: true)), Operators.CompareObjectEqual(CounterResult, Operators.NegateObject(PipSize), TextCompare: true)), Operators.CompareObjectEqual(CounterResult, PipSize, TextCompare: true))))
						{
							Local_PIXEL_units[num] = (uint)((long)(Local_alpha << 24) + 16711680L + 65280 + 255);
						}
						else
						{
							Local_PIXEL_units[num] = (Local_alpha << 24) + (Local_red << 16) + (Local_green << 8) + Local_blue;
						}
					}
				}
				while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult2, LoopForResult2, ref CounterResult2));
			}
			while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
		}

		internal void StartInterruptiblePage()
		{
			bool flag = false;
			if (Me.BITMAP_units == null)
			{
				flag = true;
			}
			else if ((Me.BITMAP_units.Width != Local_GridWidth) | (Me.BITMAP_units.Height != Local_GridHeight))
			{
				flag = true;
			}
			if (flag)
			{
				Me.BITMAP_units = new WriteableBitmap((int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, null);
			}
			Me.BITMAP_units.WritePixels(new Int32Rect(0, 0, (int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight)), Local_PIXEL_units, (int)Math.Round(Local_GridWidth * 4.0), 0);
		}
	}

	[CompilerGenerated]
	private WriteableBitmap utilsTests;

	[CompilerGenerated]
	private WriteableBitmap _PredicateTests;

	public Dispatcher Dispatcher;

	public Grid GridControl;

	private double singletonTests;

	private double m_RecordTests;

	private double _ExceptionTests;

	private double m_AttrTests;

	private double visitorTests;

	private double m_ExporterTests;

	private double m_PrototypeTests;

	private double comparatorTests;

	private double m_ItemTests;

	private double m_SetterTests;

	private double m_CreatorTests;

	private double templateTests;

	private double mappingTests;

	private double m_MockTests;

	[NonSerialized]
	private PropertyChangedEventHandler m_TagTests;

	public WriteableBitmap BITMAP_terrain
	{
		[CompilerGenerated]
		get
		{
			return utilsTests;
		}
		[CompilerGenerated]
		set
		{
			if (utilsTests != value)
			{
				utilsTests = value;
				OnPropertyChanged("BITMAP_terrain");
			}
		}
	}

	public WriteableBitmap BITMAP_units
	{
		[CompilerGenerated]
		get
		{
			return _PredicateTests;
		}
		[CompilerGenerated]
		set
		{
			if (_PredicateTests != value)
			{
				_PredicateTests = value;
				OnPropertyChanged("BITMAP_units");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_TagTests;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_TagTests, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_TagTests;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_TagTests, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public GlobalMinimapViewModel()
	{
		singletonTests = 0.0;
		m_RecordTests = 0.0;
		_ExceptionTests = 0.0;
		m_AttrTests = 0.0;
		visitorTests = 0.0;
		m_ExporterTests = 0.0;
		m_PrototypeTests = 0.0;
		comparatorTests = 0.0;
		m_ItemTests = 0.0;
		m_SetterTests = 0.0;
		m_CreatorTests = 0.0;
		templateTests = 0.0;
		mappingTests = 0.0;
		m_MockTests = 0.0;
	}

	private bool ExcludeAnnotation(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref double double_5, ref double double_6, ref double double_7, ref double double_8, ref double double_9)
	{
		double_4 = double.MaxValue;
		double_5 = double.MinValue;
		double_6 = double.MaxValue;
		double_7 = double.MinValue;
		double Local_gw = 0.0;
		double Local_gh = 0.0;
		Dispatcher.Invoke(delegate
		{
			Local_gw = GridControl.ActualWidth;
			Local_gh = GridControl.ActualHeight;
		});
		double_1 = Local_gw;
		double_0 = Local_gh;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		List<ActiveUnit> list = Client.CurrentScenario.ActiveUnits_List.Where((ActiveUnit F) => !F.IsSatellite).ToList();
		if (list.Count < 2)
		{
			return false;
		}
		double num4 = 1.0 / (double)list.Count;
		foreach (ActiveUnit item in list)
		{
			double num5 = 1.0 * Math.Cos(item.GetLongitude() * CSMath.PI_dividedBy_180) * Math.Cos(item.GetLatitude() * CSMath.PI_dividedBy_180);
			double num6 = 1.0 * Math.Sin(item.GetLongitude() * CSMath.PI_dividedBy_180) * Math.Cos(item.GetLatitude() * CSMath.PI_dividedBy_180);
			double num7 = 1.0 * Math.Sin(item.GetLatitude() * CSMath.PI_dividedBy_180);
			num += num5 * num4;
			num2 += num6 * num4;
			num3 += num7 * num4;
		}
		double_3 = 0.0;
		double_2 = 0.0;
		double_4 = -Math.PI / 2.0;
		double_5 = Math.PI / 2.0;
		double_6 = -Math.PI;
		double_7 = Math.PI;
		double_8 = double_5 - double_4;
		double_9 = double_7 - double_6;
		singletonTests = double_4;
		m_RecordTests = double_6;
		_ExceptionTests = double_1;
		m_AttrTests = double_0;
		visitorTests = double_8;
		m_ExporterTests = double_9;
		m_PrototypeTests = double_2;
		comparatorTests = double_3;
		return true;
	}

	public void UpdateTerrain(Scenario scenario_0)
	{
		double Local_GridWidth = 0.0;
		double Local_GridHeight = 0.0;
		double double_ = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		double double_5 = 0.0;
		double double_6 = 0.0;
		double double_7 = 0.0;
		double double_8 = 0.0;
		double double_9 = 0.0;
		if (!ExcludeAnnotation(ref Local_GridHeight, ref Local_GridWidth, ref double_5, ref double_4, ref double_6, ref double_7, ref double_8, ref double_9, ref double_, ref double_3) || (m_ItemTests == double_6 && m_SetterTests == double_8 && m_CreatorTests == Local_GridWidth && templateTests == Local_GridHeight && mappingTests == double_ && m_MockTests == double_3) || double.IsNaN(double_6) || double.IsNaN(double_8))
		{
			return;
		}
		m_ItemTests = double_6;
		m_SetterTests = double_8;
		m_CreatorTests = Local_GridWidth;
		templateTests = Local_GridHeight;
		mappingTests = double_;
		m_MockTests = double_3;
		uint[] Local_PIXEL_terrain = new uint[(int)Math.Round(Local_GridHeight * Local_GridWidth) + 1];
		uint num = 0u;
		uint num3 = 0u;
		uint num4 = 0u;
		int num5 = (int)Math.Round(Local_GridWidth - 1.0);
		string htmlColor = null;
		for (int i = 0; i <= num5; i++)
		{
			Thread.Sleep(1);
			int num6 = (int)Math.Round(Local_GridHeight - 1.0);
			for (int j = 0; j <= num6; j++)
			{
				int num7 = (int)Math.Round(Local_GridWidth * (double)j + (double)i);
				double num8 = double_6 + (Local_GridHeight - (double)j) * (double_ / Local_GridHeight);
				double num9 = double_8 + (double)i * (double_3 / Local_GridWidth);
				double num10 = num8 + double_5;
				double num2 = num9 + double_4;
				double double_10 = num10 * 180.0 / Math.PI;
				double double_2 = num2 * 180.0 / Math.PI;
				short elevation = Terrain.GetElevation(double_10, double_2, bool_0: false, scenario_0);
				num = 0u;
				num3 = 0u;
				num4 = 0u;
				if (elevation <= 0)
				{
					num4 = 64u;
				}
				else
				{
					num3 = 64u;
				}
				switch (LandCover.DestroyClass(double_10, double_2, Client.CurrentScenario))
				{
				case LandCover.LandCoverType.Urban_CloseInnerCity:
				case LandCover.LandCoverType.Urban_SpacedHighRise:
				case LandCover.LandCoverType.Urban_AttachedHouses:
				case LandCover.LandCoverType.Urban_CloseIndustrial:
				case LandCover.LandCoverType.Urban_SpacedApartments:
				case LandCover.LandCoverType.Urban_DetachedHouses:
				case LandCover.LandCoverType.Urban_SpacedIndustrial:
				case LandCover.LandCoverType.Urban_ShantyTown:
					htmlColor = "#f00000";
					break;
				case LandCover.LandCoverType.Water:
					htmlColor = "#10203b";
					break;
				case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					htmlColor = "#0a6305";
					break;
				case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					htmlColor = "#027702";
					break;
				case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					htmlColor = "#38c414";
					break;
				case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					htmlColor = "#008805";
					break;
				case LandCover.LandCoverType.Mixed_forest:
					htmlColor = "#00ea00";
					break;
				case LandCover.LandCoverType.Closed_shrublands:
					htmlColor = "#4c4610";
					break;
				case LandCover.LandCoverType.Open_shrublands:
					htmlColor = "#ccbd2e";
					break;
				case LandCover.LandCoverType.Woody_savannas:
					htmlColor = "#deb416";
					break;
				case LandCover.LandCoverType.Savannas:
					htmlColor = "#ecba47";
					break;
				case LandCover.LandCoverType.Grasslands:
					htmlColor = "#82420b";
					break;
				case LandCover.LandCoverType.Permanent_wetlands:
					htmlColor = "#445e5f";
					break;
				case LandCover.LandCoverType.Croplands:
					htmlColor = "#cfb324";
					break;
				case LandCover.LandCoverType.UrbanAndBuiltUp:
					htmlColor = "#f00000";
					break;
				case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
					htmlColor = "#f0bba6";
					break;
				case LandCover.LandCoverType.SnowAndIce:
					htmlColor = "#efeef1";
					break;
				case LandCover.LandCoverType.BarrenOrSparselyVegetated:
					htmlColor = "#efcaa4";
					break;
				}
				System.Drawing.Color color = ColorTranslator.FromHtml(htmlColor);
				num = color.R;
				num3 = color.G;
				num4 = color.B;
				Local_PIXEL_terrain[num7] = (uint)(-1358954496 + (int)(num << 16) + (int)(num3 << 8)) + num4;
			}
		}
		Dispatcher.Invoke(delegate
		{
			bool flag = false;
			if (BITMAP_terrain == null)
			{
				flag = true;
			}
			else if ((BITMAP_terrain.Width != Local_GridWidth) | (BITMAP_terrain.Height != Local_GridHeight))
			{
				flag = true;
			}
			if (flag)
			{
				BITMAP_terrain = new WriteableBitmap((int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, null);
			}
			BITMAP_terrain.WritePixels(new Int32Rect(0, 0, (int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight)), Local_PIXEL_terrain, (int)Math.Round(Local_GridWidth * 4.0), 0);
		});
	}

	public void UpdateUnits()
	{
		double Local_GridWidth = 0.0;
		double Local_GridHeight = 0.0;
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		double double_5 = 0.0;
		double double_6 = 0.0;
		double double_7 = 0.0;
		double double_8 = 0.0;
		if (!ExcludeAnnotation(ref Local_GridHeight, ref Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2))
		{
			return;
		}
		uint[] Local_PIXEL_units = new uint[(int)Math.Round(Local_GridHeight * Local_GridWidth) + 1];
		uint Local_alpha = 0u;
		uint Local_red = 0u;
		uint Local_green = 0u;
		uint Local_blue = 0u;
		VB_0024AnonymousDelegate_3<object, object, object> vB_0024AnonymousDelegate_ = delegate(object xbar, object ybar, object PipSize)
		{
			object CounterResult = null;
			object LoopForResult = null;
			if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult, Operators.NegateObject(PipSize), PipSize, 1, ref LoopForResult, ref CounterResult))
			{
				object CounterResult2 = null;
				object LoopForResult2 = null;
				do
				{
					if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult2, Operators.NegateObject(PipSize), PipSize, 1, ref LoopForResult2, ref CounterResult2))
					{
						do
						{
							int num13 = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(Local_GridWidth, Operators.AddObject(ybar, CounterResult2)), Operators.AddObject(xbar, CounterResult)));
							if (num13 >= 0 && num13 < Local_PIXEL_units.Count())
							{
								if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(CounterResult2, Operators.NegateObject(PipSize), TextCompare: true), Operators.CompareObjectEqual(CounterResult2, PipSize, TextCompare: true)), Operators.CompareObjectEqual(CounterResult, Operators.NegateObject(PipSize), TextCompare: true)), Operators.CompareObjectEqual(CounterResult, PipSize, TextCompare: true))))
								{
									Local_PIXEL_units[num13] = (uint)((long)(Local_alpha << 24) + 16711680L + 65280 + 255);
								}
								else
								{
									Local_PIXEL_units[num13] = (Local_alpha << 24) + (Local_red << 16) + (Local_green << 8) + Local_blue;
								}
							}
						}
						while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult2, LoopForResult2, ref CounterResult2));
					}
				}
				while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
			}
		};
		foreach (ActiveUnit item in Client.CurrentSide.Units.ToList())
		{
			Thread.Sleep(1);
			if (item != null)
			{
				double num = item.GetLatitude() * CSMath.PI_dividedBy_180;
				double num5 = item.GetLongitude() * CSMath.PI_dividedBy_180;
				double a = (0.0 - (num - double_4 - double_5) * Local_GridHeight) / double_ + Local_GridHeight;
				double a2 = (num5 - double_3 - double_7) * (Local_GridWidth / double_2);
				int num6 = (int)Math.Round(a);
				int num7 = (int)Math.Round(a2);
				Local_red = 0u;
				Local_green = 0u;
				Local_blue = 255u;
				Local_alpha = 255u;
				vB_0024AnonymousDelegate_(num7, num6, 4);
			}
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (side == Client.CurrentSide || !Module_Side.IsAlliedWithThisSide(side, Client.CurrentSide) || !Module_Side.IsAlliedWithThisSide(Client.CurrentSide, side))
			{
				continue;
			}
			Thread.Sleep(1);
			foreach (ActiveUnit unit in side.Units)
			{
				Thread.Sleep(1);
				double num8 = unit.GetLatitude() * CSMath.PI_dividedBy_180;
				double num9 = unit.GetLongitude() * CSMath.PI_dividedBy_180;
				double a3 = (0.0 - (num8 - double_4 - double_5) * Local_GridHeight) / double_ + Local_GridHeight;
				double a4 = (num9 - double_3 - double_7) * (Local_GridWidth / double_2);
				int num10 = (int)Math.Round(a3);
				int num11 = (int)Math.Round(a4);
				Local_red = 0u;
				Local_green = 0u;
				Local_blue = 255u;
				Local_alpha = 255u;
				vB_0024AnonymousDelegate_(num11, num10, 4);
			}
		}
		foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
		{
			Thread.Sleep(1);
			System.Drawing.Color colorFromStance = Client.GetColorFromStance(contacts_.GetStance(Client.CurrentSide));
			double num12 = contacts_.GetLatitude() * CSMath.PI_dividedBy_180;
			double num2 = contacts_.GetLongitude() * CSMath.PI_dividedBy_180;
			double a5 = (0.0 - (num12 - double_4 - double_5) * Local_GridHeight) / double_ + Local_GridHeight;
			double a6 = (num2 - double_3 - double_7) * (Local_GridWidth / double_2);
			int num3 = (int)Math.Round(a5);
			int num4 = (int)Math.Round(a6);
			if (colorFromStance == Client.registryRequest)
			{
				Local_red = 255u;
				Local_green = 0u;
				Local_blue = 0u;
			}
			else if (colorFromStance == Client._ExpressionRequest)
			{
				Local_red = 0u;
				Local_green = 0u;
				Local_blue = 255u;
			}
			else
			{
				Local_red = colorFromStance.R;
				Local_green = colorFromStance.G;
				Local_blue = colorFromStance.B;
			}
			Local_alpha = 255u;
			vB_0024AnonymousDelegate_(num4, num3, 4);
		}
		Dispatcher.Invoke(delegate
		{
			bool flag = false;
			if (BITMAP_units == null)
			{
				flag = true;
			}
			else if ((BITMAP_units.Width != Local_GridWidth) | (BITMAP_units.Height != Local_GridHeight))
			{
				flag = true;
			}
			if (flag)
			{
				BITMAP_units = new WriteableBitmap((int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, null);
			}
			BITMAP_units.WritePixels(new Int32Rect(0, 0, (int)Math.Round(Local_GridWidth), (int)Math.Round(Local_GridHeight)), Local_PIXEL_units, (int)Math.Round(Local_GridWidth * 4.0), 0);
		});
	}

	public void PanMapToPixel(int int_0, int int_1)
	{
		double num = singletonTests + (m_AttrTests - (double)int_1) * (visitorTests / m_AttrTests);
		double num2 = m_RecordTests + (double)int_0 * (m_ExporterTests / _ExceptionTests);
		double num3 = num + m_PrototypeTests;
		double num4 = num2 + comparatorTests;
		double double_ = num3 * 180.0 / Math.PI;
		double double_2 = num4 * 180.0 / Math.PI;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(double_2, double_));
	}

	public void OnPropertyChanged(string string_0)
	{
		m_TagTests?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
