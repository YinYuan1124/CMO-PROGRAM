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

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class ScenarioMinimapViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class BroadcasterMap
	{
		public double Local_gw;

		public ScenarioMinimapViewModel Me;

		public double Local_gh;

		public VB_0024AnonymousDelegate_2<object, object> Local_WrapAngle;

		public double Local_clat;

		public double Local_clon;

		internal void ChangeInterruptibleMethod()
		{
			Local_gw = Me.GridControl.ActualWidth;
			Local_gh = Me.GridControl.ActualHeight;
		}

		internal Tuple<double, double> InitInterruptibleMethod(ActiveUnit F)
		{
			return new Tuple<double, double>(Conversions.ToDouble(Local_WrapAngle(F.GetLatitude() * CSMath.PI_dividedBy_180 - Local_clat)), Conversions.ToDouble(Local_WrapAngle(F.GetLongitude() * CSMath.PI_dividedBy_180 - Local_clon)));
		}
	}

	[CompilerGenerated]
	private sealed class IdentifierMap
	{
		public ScenarioMinimapViewModel Me;

		public double Local_GridWidth;

		public double Local_GridHeight;

		public uint[] Local_PIXEL_terrain;

		internal void CheckInterruptibleMethod()
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
	private sealed class ConfigurationObjectListener
	{
		public double Local_GridWidth;

		public ScenarioMinimapViewModel Me;

		public double Local_GridHeight;

		public uint[] Local_PIXEL_units;

		public uint Local_alpha;

		public uint Local_red;

		public uint Local_green;

		public uint Local_blue;

		internal void ConcatInterruptibleMethod(object xbar, object ybar, object PipSize)
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

		internal void InterruptInterruptibleMethod()
		{
			try
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	private WriteableBitmap _ProductPredicate;

	[CompilerGenerated]
	private WriteableBitmap m_AnnotationPredicate;

	public Dispatcher Dispatcher;

	public Grid GridControl;

	private double m_IteratorPredicate;

	private double _InitializerPredicate;

	private double m_RolePredicate;

	private double m_FactoryPredicate;

	private double _AttributePredicate;

	private double m_EventPredicate;

	private double globalPredicate;

	private double _WorkerPredicate;

	private double accountPredicate;

	private double statePredicate;

	private double m_AuthenticationPredicate;

	private double _ParamsPredicate;

	private double infoPredicate;

	private double helperPredicate;

	[NonSerialized]
	private PropertyChangedEventHandler mapperPredicate;

	public WriteableBitmap BITMAP_terrain
	{
		[CompilerGenerated]
		get
		{
			return _ProductPredicate;
		}
		[CompilerGenerated]
		set
		{
			if (_ProductPredicate != value)
			{
				_ProductPredicate = value;
				OnPropertyChanged("BITMAP_terrain");
			}
		}
	}

	public WriteableBitmap BITMAP_units
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationPredicate;
		}
		[CompilerGenerated]
		set
		{
			if (m_AnnotationPredicate != value)
			{
				m_AnnotationPredicate = value;
				OnPropertyChanged("BITMAP_units");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = mapperPredicate;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref mapperPredicate, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = mapperPredicate;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref mapperPredicate, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public ScenarioMinimapViewModel()
	{
		m_IteratorPredicate = 0.0;
		_InitializerPredicate = 0.0;
		m_RolePredicate = 0.0;
		m_FactoryPredicate = 0.0;
		_AttributePredicate = 0.0;
		m_EventPredicate = 0.0;
		globalPredicate = 0.0;
		_WorkerPredicate = 0.0;
		accountPredicate = 0.0;
		statePredicate = 0.0;
		m_AuthenticationPredicate = 0.0;
		_ParamsPredicate = 0.0;
		infoPredicate = 0.0;
		helperPredicate = 0.0;
	}

	private bool PushInterruptiblePublisher(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref double double_5, ref double double_6, ref double double_7, ref double double_8, ref double double_9)
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
		VB_0024AnonymousDelegate_2<object, object> Local_WrapAngle = delegate(object Theta)
		{
			while (Operators.ConditionalCompareObjectGreater(Theta, Math.PI, TextCompare: true))
			{
				Theta = Operators.SubtractObject(Theta, Math.PI * 2.0);
			}
			while (Operators.ConditionalCompareObjectLess(Theta, -Math.PI, TextCompare: true))
			{
				Theta = Operators.AddObject(Theta, Math.PI * 2.0);
			}
			return Theta;
		};
		double_3 = Math.Atan2(num2, num);
		double_2 = Math.PI / 2.0 - Math.Acos(num3);
		double_4 = double.MaxValue;
		double_5 = double.MinValue;
		double_6 = double.MaxValue;
		double_7 = double.MinValue;
		double Local_clat = double_2;
		double Local_clon = double_3;
		foreach (Tuple<double, double> item2 in list.Select((ActiveUnit F) => new Tuple<double, double>(Conversions.ToDouble(Local_WrapAngle(F.GetLatitude() * CSMath.PI_dividedBy_180 - Local_clat)), Conversions.ToDouble(Local_WrapAngle(F.GetLongitude() * CSMath.PI_dividedBy_180 - Local_clon)))).ToList())
		{
			double_4 = Math.Min(double_4, item2.Item1);
			double_5 = Math.Max(double_5, item2.Item1);
			double_6 = Math.Min(double_6, item2.Item2);
			double_7 = Math.Max(double_7, item2.Item2);
		}
		double num8 = double_5 - double_4;
		double num9 = double_7 - double_6;
		double_4 -= num8 * 0.1;
		double_5 += num8 * 0.1;
		double_6 -= num9 * 0.1;
		double_7 += num9 * 0.1;
		double_8 = double_5 - double_4;
		double_9 = double_7 - double_6;
		m_IteratorPredicate = double_4;
		_InitializerPredicate = double_6;
		m_RolePredicate = double_1;
		m_FactoryPredicate = double_0;
		_AttributePredicate = double_8;
		m_EventPredicate = double_9;
		globalPredicate = double_2;
		_WorkerPredicate = double_3;
		return true;
	}

	public void UpdateTerrain()
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
		if (!PushInterruptiblePublisher(ref Local_GridHeight, ref Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2) || (accountPredicate == double_5 && statePredicate == double_7 && m_AuthenticationPredicate == Local_GridWidth && _ParamsPredicate == Local_GridHeight && infoPredicate == double_ && helperPredicate == double_2))
		{
			return;
		}
		accountPredicate = double_5;
		statePredicate = double_7;
		m_AuthenticationPredicate = Local_GridWidth;
		_ParamsPredicate = Local_GridHeight;
		infoPredicate = double_;
		helperPredicate = double_2;
		uint[] Local_PIXEL_terrain = new uint[(int)Math.Round(Local_GridHeight * Local_GridWidth) + 1];
		uint num = 0u;
		uint num4 = 0u;
		uint num5 = 0u;
		int num6 = (int)Math.Round(Local_GridWidth - 1.0);
		string htmlColor = null;
		for (int i = 0; i <= num6; i++)
		{
			Thread.Sleep(1);
			int num7 = (int)Math.Round(Local_GridHeight - 1.0);
			for (int j = 0; j <= num7; j++)
			{
				int num8 = (int)Math.Round(Local_GridWidth * (double)j + (double)i);
				double num9 = double_5 + (Local_GridHeight - (double)j) * (double_ / Local_GridHeight);
				double num10 = double_7 + (double)i * (double_2 / Local_GridWidth);
				double num11 = num9 + double_4;
				double num2 = num10 + double_3;
				double double_9 = num11 * 180.0 / Math.PI;
				double num3 = num2 * 180.0 / Math.PI;
				(bool, short?) tuple = Terrain.ExcludeWatcher(Math2.ReflectClass(double_9), Math2.VisitClass(num3));
				num = 0u;
				num4 = 0u;
				num5 = 0u;
				if (tuple.Item1)
				{
					num4 = 64u;
				}
				else
				{
					num5 = 64u;
				}
				switch (LandCover.DestroyClass(double_9, num3, Client.CurrentScenario))
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
				num4 = color.G;
				num5 = color.B;
				Local_PIXEL_terrain[num8] = (uint)(-1358954496 + (int)(num << 16) + (int)(num4 << 8)) + num5;
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
		if (!PushInterruptiblePublisher(ref Local_GridHeight, ref Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2))
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
			try
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
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		});
	}

	public void PanMapToPixel(int int_0, int int_1)
	{
		double num = m_IteratorPredicate + (m_FactoryPredicate - (double)int_1) * (_AttributePredicate / m_FactoryPredicate);
		double num2 = _InitializerPredicate + (double)int_0 * (m_EventPredicate / m_RolePredicate);
		double num3 = num + globalPredicate;
		double num4 = num2 + _WorkerPredicate;
		double double_ = num3 * 180.0 / Math.PI;
		double double_2 = num4 * 180.0 / Math.PI;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(double_2, double_));
	}

	public void OnPropertyChanged(string string_0)
	{
		mapperPredicate?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
