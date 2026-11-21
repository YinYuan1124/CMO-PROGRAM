using System;
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
using Command.Managers;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class CameraFollowingMinimapViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class RegistryMap
	{
		public double Local_gw;

		public CameraFollowingMinimapViewModel Me;

		public double Local_gh;

		public double Local_MainFormLat;

		public double Local_MainFormLon;

		public double Local_MainFormAlt;

		public Geopoint_Struct Local_UpperLeftCorner;

		internal void VerifyInterruptibleParam()
		{
			Local_gw = Me.GridControl.ActualWidth;
			Local_gh = Me.GridControl.ActualHeight;
			GeoPoint mapCenter = ItemExporter.ConnectInterruptibleTemplate.MainForm.GetMapCenter(bool_0: false);
			Local_MainFormLat = mapCenter.Latitude * CSMath.PI_dividedBy_180;
			Local_MainFormLon = mapCenter.Longitude * CSMath.PI_dividedBy_180;
			Local_MainFormAlt = ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude;
		}

		internal void ListInterruptibleParam()
		{
			Local_UpperLeftCorner = ManagerListenerManager.CalculateInterruptibleMap(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1, 0, 0);
		}
	}

	[CompilerGenerated]
	private sealed class DefinitionMap
	{
		public CameraFollowingMinimapViewModel Me;

		public double Local_GridWidth;

		public double Local_GridHeight;

		public uint[] Local_PIXEL_terrain;

		internal void ResolveInterruptibleParam()
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
	private sealed class SingletonRegistryFilter
	{
		public double Local_GridWidth;

		public CameraFollowingMinimapViewModel Me;

		public double Local_GridHeight;

		public uint[] Local_PIXEL_units;

		public uint Local_alpha;

		public uint Local_red;

		public uint Local_green;

		public uint Local_blue;

		internal void PostInterruptibleParam(object xbar, object ybar, object PipSize)
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

		internal void RunInterruptibleParam()
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
	private WriteableBitmap mapperBridge;

	[CompilerGenerated]
	private WriteableBitmap managerBridge;

	public Dispatcher Dispatcher;

	public Grid GridControl;

	private double getterBridge;

	private double producerBridge;

	private double m_ProcBridge;

	private double m_StructInvocation;

	private double merchantInvocation;

	private double m_CallbackInvocation;

	private double m_DecoratorInvocation;

	private double processInvocation;

	private double m_ThreadInvocation;

	private double ruleInvocation;

	private double collectionInvocation;

	private double _InstanceInvocation;

	private double _ObjectInvocation;

	private double _ParameterInvocation;

	[NonSerialized]
	private PropertyChangedEventHandler m_ExpressionInvocation;

	public WriteableBitmap BITMAP_terrain
	{
		[CompilerGenerated]
		get
		{
			return mapperBridge;
		}
		[CompilerGenerated]
		set
		{
			if (mapperBridge != value)
			{
				mapperBridge = value;
				OnPropertyChanged("BITMAP_terrain");
			}
		}
	}

	public WriteableBitmap BITMAP_units
	{
		[CompilerGenerated]
		get
		{
			return managerBridge;
		}
		[CompilerGenerated]
		set
		{
			if (managerBridge != value)
			{
				managerBridge = value;
				OnPropertyChanged("BITMAP_units");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ExpressionInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ExpressionInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ExpressionInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ExpressionInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public CameraFollowingMinimapViewModel()
	{
		getterBridge = 0.0;
		producerBridge = 0.0;
		m_ProcBridge = 0.0;
		m_StructInvocation = 0.0;
		merchantInvocation = 0.0;
		m_CallbackInvocation = 0.0;
		m_DecoratorInvocation = 0.0;
		processInvocation = 0.0;
		m_ThreadInvocation = 0.0;
		ruleInvocation = 0.0;
		collectionInvocation = 0.0;
		_InstanceInvocation = 0.0;
		_ObjectInvocation = 0.0;
		_ParameterInvocation = 0.0;
	}

	private bool RemoveContext(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref double double_5, ref double double_6, ref double double_7, ref double double_8, ref double double_9)
	{
		Geopoint_Struct Local_UpperLeftCorner = default(Geopoint_Struct);
		double Local_gw = 0.0;
		double Local_gh = 0.0;
		double Local_MainFormLat = 0.0;
		double Local_MainFormLon = 0.0;
		double Local_MainFormAlt = 0.0;
		Dispatcher.Invoke(delegate
		{
			Local_gw = GridControl.ActualWidth;
			Local_gh = GridControl.ActualHeight;
			GeoPoint mapCenter = ItemExporter.ConnectInterruptibleTemplate.MainForm.GetMapCenter(bool_0: false);
			Local_MainFormLat = mapCenter.Latitude * CSMath.PI_dividedBy_180;
			Local_MainFormLon = mapCenter.Longitude * CSMath.PI_dividedBy_180;
			Local_MainFormAlt = ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude;
		});
		double_1 = Local_gw;
		double_0 = Local_gh;
		VB_0024AnonymousDelegate_2<object, object> vB_0024AnonymousDelegate_ = delegate(object Theta)
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
		double_2 = Conversions.ToDouble(vB_0024AnonymousDelegate_(Local_MainFormLat));
		double_3 = Conversions.ToDouble(vB_0024AnonymousDelegate_(Local_MainFormLon));
		Dispatcher.Invoke(delegate
		{
			Local_UpperLeftCorner = ManagerListenerManager.CalculateInterruptibleMap(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1, 0, 0);
		});
		if (Local_UpperLeftCorner.Latitude != 0.0 && !double.IsNaN(Local_UpperLeftCorner.Latitude))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(vB_0024AnonymousDelegate_(Local_UpperLeftCorner.Latitude * CSMath.PI_dividedBy_180 - double_2));
			object objectValue2 = RuntimeHelpers.GetObjectValue(vB_0024AnonymousDelegate_(Local_UpperLeftCorner.Longitude * CSMath.PI_dividedBy_180 - double_3));
			double_4 = Conversions.ToDouble(Operators.NegateObject(objectValue));
			double_6 = Conversions.ToDouble(objectValue2);
			double_5 = Conversions.ToDouble(objectValue);
			double_7 = Conversions.ToDouble(Operators.NegateObject(objectValue2));
			double_8 = double_5 - double_4;
			double_9 = double_7 - double_6;
			getterBridge = double_4;
			producerBridge = double_6;
			m_ProcBridge = double_1;
			m_StructInvocation = double_0;
			merchantInvocation = double_8;
			m_CallbackInvocation = double_9;
			m_DecoratorInvocation = double_2;
			processInvocation = double_3;
			return true;
		}
		return false;
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
		if (!RemoveContext(ref Local_GridHeight, ref Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2) || (m_ThreadInvocation == double_5 && ruleInvocation == double_7 && collectionInvocation == Local_GridWidth && _InstanceInvocation == Local_GridHeight && _ObjectInvocation == double_ && _ParameterInvocation == double_2))
		{
			return;
		}
		m_ThreadInvocation = double_5;
		ruleInvocation = double_7;
		collectionInvocation = Local_GridWidth;
		_InstanceInvocation = Local_GridHeight;
		_ObjectInvocation = double_;
		_ParameterInvocation = double_2;
		uint[] Local_PIXEL_terrain = new uint[(int)Math.Round(Local_GridHeight * Local_GridWidth) + 1];
		uint num = 0u;
		uint num4 = 0u;
		uint num5 = 0u;
		int num6 = (int)Math.Round(Local_GridWidth - 1.0);
		string htmlColor = null;
		for (int i = 0; i <= num6; i++)
		{
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
				short elevation = Terrain.GetElevation(Math2.ReflectClass(double_9), Math2.VisitClass(num3), bool_0: false, Client.CurrentScenario);
				num = 0u;
				num4 = 0u;
				num5 = 0u;
				if (elevation <= 0)
				{
					num5 = 64u;
				}
				else
				{
					num4 = 64u;
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

	private bool FindContext(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7)
	{
		double num = double_0 - double_2;
		double num2 = double_1 - double_3;
		if (num >= double_4 && num <= double_5 && num2 >= double_6 && num2 <= double_7)
		{
			return true;
		}
		return false;
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
		if (!RemoveContext(ref Local_GridHeight, ref Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2) || Client.CurrentSide == null)
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
		double num = getterBridge + (m_StructInvocation - (double)int_1) * (merchantInvocation / m_StructInvocation);
		double num2 = producerBridge + (double)int_0 * (m_CallbackInvocation / m_ProcBridge);
		double num3 = num + m_DecoratorInvocation;
		double num4 = num2 + processInvocation;
		double double_ = num3 * 180.0 / Math.PI;
		double double_2 = num4 * 180.0 / Math.PI;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(double_2, double_));
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ExpressionInvocation?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
