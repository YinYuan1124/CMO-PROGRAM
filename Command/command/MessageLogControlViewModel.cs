using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Command.Managers;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class MessageLogControlViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class ConsumerCollectionTask
	{
		public LoggedMessage theM;

		internal bool FindInterruptibleRules(GClass7 MLSVM)
		{
			return Operators.CompareString(MLSVM.Summary, MessageTypeToBalloonText(theM.Type), TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class WriterListenerMapping
	{
		public MLDetailViewModel theDetails;

		public GClass6 gclass6_0;

		internal bool SetInterruptibleRules(GClass6 F)
		{
			return ((MLDetailViewModel)F.Tag).LoggedMessage == theDetails.LoggedMessage;
		}

		internal void FillInterruptibleRules()
		{
			Balloon item = new Balloon
			{
				CanvasLeft = (int)Math.Round(gclass6_0.CanvasLeft),
				CanvasTop = (int)Math.Round(gclass6_0.CanvasTop),
				StemCanvasLeft = (int)Math.Round(gclass6_0.StemCanvasLeft),
				StemCanvasTop = (int)Math.Round(gclass6_0.StemCanvasTop),
				ObservedHeight = (int)Math.Round(gclass6_0.ObservedHeight),
				ObservedWidth = (int)Math.Round(gclass6_0.ObservedWidth),
				Text = gclass6_0.Text,
				Summary = gclass6_0.Summary,
				Tag = RuntimeHelpers.GetObjectValue(gclass6_0.Tag),
				Lat = gclass6_0.Lat,
				Lon = gclass6_0.Lon,
				Opacity = gclass6_0.Opacity,
				Hover = gclass6_0.Hover,
				Color = gclass6_0.Color,
				X1 = gclass6_0.X1,
				X2 = gclass6_0.X2,
				Y1 = gclass6_0.Y1,
				Y2 = gclass6_0.Y2,
				Radius = gclass6_0.Radius,
				Theta = gclass6_0.Theta
			};
			ItemExporter.ConnectInterruptibleTemplate.MainForm.BalloonsRenderingList.Add(item);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetRenderCountdown(5.0);
		}
	}

	[CompilerGenerated]
	private int m_InitializerConnection;

	public long HighestIncrement;

	private DispatcherTimer _RoleConnection;

	[CompilerGenerated]
	private bool _FactoryConnection;

	[CompilerGenerated]
	private double m_AttributeConnection;

	private int eventConnection;

	public Dictionary<string, bool> HeaderToShow;

	public bool ShowAll;

	private bool _GlobalConnection;

	private string m_WorkerConnection;

	public bool InteractiveMode;

	public bool MustRefresh;

	private DateTime m_AccountConnection;

	[CompilerGenerated]
	private List<GClass7> _StateConnection;

	[CompilerGenerated]
	private ObservableCollection<GClass7> authenticationConnection;

	[CompilerGenerated]
	private ObservableCollection<MLDetailViewModel> _ParamsConnection;

	[CompilerGenerated]
	private ObservableCollection<GClass7> _InfoConnection;

	[CompilerGenerated]
	private ObservableCollection<GClass6> _HelperConnection;

	private readonly LockRandom m_MapperConnection;

	[NonSerialized]
	private PropertyChangedEventHandler m_ManagerConnection;

	public int MainFormLogWidth
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerConnection;
		}
		[CompilerGenerated]
		set
		{
			if (m_InitializerConnection != value)
			{
				m_InitializerConnection = value;
				OnPropertyChanged("MainFormLogWidth");
			}
		}
	}

	public bool LogCollapsed
	{
		[CompilerGenerated]
		get
		{
			return _FactoryConnection;
		}
		[CompilerGenerated]
		set
		{
			if (_FactoryConnection != value)
			{
				_FactoryConnection = value;
				OnPropertyChanged("LogCollapsed");
			}
		}
	}

	public double LogCollapseButtonRotation
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeConnection;
		}
		[CompilerGenerated]
		set
		{
			if (m_AttributeConnection != value)
			{
				m_AttributeConnection = value;
				OnPropertyChanged("LogCollapseButtonRotation");
			}
		}
	}

	public string DisplayModeString
	{
		get
		{
			if (Operators.CompareString(m_WorkerConnection, "", TextCompare: true) == 0)
			{
				RawMode = false;
				return ">Raw";
			}
			return m_WorkerConnection;
		}
		set
		{
			if (!string.Equals(m_WorkerConnection, value, StringComparison.Ordinal))
			{
				m_WorkerConnection = value;
				OnPropertyChanged("DisplayModeString");
			}
		}
	}

	public bool RawMode
	{
		get
		{
			return _GlobalConnection;
		}
		set
		{
			if (_GlobalConnection != value)
			{
				_GlobalConnection = value;
				OnPropertyChanged("RawMode");
				if (_GlobalConnection)
				{
					DisplayModeString = ">Inter.";
				}
				else
				{
					DisplayModeString = ">Raw";
				}
				RefreshLoggedMessages();
			}
		}
	}

	public List<GClass7> SummaryItemsOriginal
	{
		[CompilerGenerated]
		get
		{
			return _StateConnection;
		}
		[CompilerGenerated]
		set
		{
			if (_StateConnection != value)
			{
				_StateConnection = value;
				OnPropertyChanged("SummaryItemsOriginal");
			}
		}
	}

	public ObservableCollection<GClass7> SummaryItems
	{
		[CompilerGenerated]
		get
		{
			return authenticationConnection;
		}
		[CompilerGenerated]
		set
		{
			if (authenticationConnection != value)
			{
				authenticationConnection = value;
				OnPropertyChanged("SummaryItems");
			}
		}
	}

	public ObservableCollection<MLDetailViewModel> FilteredSummaryDetailItems
	{
		[CompilerGenerated]
		get
		{
			return _ParamsConnection;
		}
		[CompilerGenerated]
		set
		{
			if (_ParamsConnection != value)
			{
				_ParamsConnection = value;
				OnPropertyChanged("FilteredSummaryDetailItems");
			}
		}
	}

	public ObservableCollection<GClass7> UniqueHeader
	{
		[CompilerGenerated]
		get
		{
			return _InfoConnection;
		}
		[CompilerGenerated]
		set
		{
			if (_InfoConnection != value)
			{
				_InfoConnection = value;
				OnPropertyChanged("UniqueHeader");
			}
		}
	}

	public ObservableCollection<GClass6> Balloons
	{
		[CompilerGenerated]
		get
		{
			return _HelperConnection;
		}
		[CompilerGenerated]
		set
		{
			if (_HelperConnection != value)
			{
				_HelperConnection = value;
				OnPropertyChanged("Balloons");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ManagerConnection;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ManagerConnection, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ManagerConnection;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ManagerConnection, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void Update()
	{
		if (ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Width != eventConnection)
		{
			eventConnection = ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Width;
			MainFormLogWidth = (int)Math.Round((double)ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Width / 3.0);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MainFormLogWidth = (int)Math.Round((double)ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Width / 3.0);
			int mainFormLogWidth = MainFormLogWidth;
			int height = ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Height;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.MaximumSize = new System.Drawing.Size(mainFormLogWidth, height);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.MinimumSize = new System.Drawing.Size(mainFormLogWidth, height);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Size = new System.Drawing.Size(mainFormLogWidth, height);
		}
		RefreshLog();
	}

	public void ClearLog()
	{
		MustRefresh = true;
		SummaryItemsOriginal.Clear();
		UniqueHeader.Clear();
		Balloons.Clear();
	}

	public void ResetLog()
	{
		MustRefresh = true;
		HighestIncrement = 0L;
		SummaryItemsOriginal.Clear();
		Balloons.Clear();
	}

	public void RefreshLog()
	{
		if (_RoleConnection == null)
		{
			_RoleConnection = new DispatcherTimer();
			_RoleConnection.Tick += CloneInterruptibleRegistry;
			_RoleConnection.Interval = new TimeSpan(0, 0, 0, 0, 100);
			_RoleConnection.Start();
		}
		if (Client.CurrentSide == null)
		{
			return;
		}
		LoggedMessage[] array = ((Client.CurrentMapProfile.String_0 == null) ? (from loggedMessage_0 in Client.CurrentSide.GetMessageLog_Hybrid(Client.CurrentScenario)
			where loggedMessage_0.Increment > HighestIncrement
			select loggedMessage_0).ToArray() : (from loggedMessage_0 in Client.CurrentSide.GetMessageLog_Hybrid(Client.CurrentScenario)
			where (loggedMessage_0.Increment > HighestIncrement) & (Operators.CompareString(loggedMessage_0.ReporterID, Client.CurrentMapProfile.String_0, TextCompare: true) == 0)
			select loggedMessage_0).ToArray());
		if (array.Count() > 0)
		{
			MustRefresh = true;
			HighestIncrement = array.Max((LoggedMessage theM) => theM.Increment);
			LoggedMessage[] array2 = array;
			LoggedMessage[] array3 = array2;
			foreach (LoggedMessage loggedMessage_ in array3)
			{
				ConnectInterruptibleRegistry(loggedMessage_);
			}
		}
		if (MustRefresh)
		{
			RefreshLoggedMessages();
		}
	}

	public void RefreshLoggedMessages()
	{
		MustRefresh = false;
		SummaryItems = new ObservableCollection<GClass7>(SummaryItemsOriginal);
		List<MLDetailViewModel> list = new List<MLDetailViewModel>();
		foreach (GClass7 summaryItem in SummaryItems)
		{
			if (!HeaderToShow.ContainsKey(summaryItem.Summary) || !HeaderToShow[summaryItem.Summary])
			{
				continue;
			}
			foreach (MLDetailViewModel detail in summaryItem.Details)
			{
				list.Add(detail);
			}
		}
		HashSet<long> hashSet = new HashSet<long>();
		foreach (MLDetailViewModel filteredSummaryDetailItem in FilteredSummaryDetailItems)
		{
			hashSet.Add(filteredSummaryDetailItem.LoggedMessage.Increment);
		}
		HashSet<long> hashSet2 = new HashSet<long>();
		foreach (MLDetailViewModel item in list)
		{
			hashSet2.Add(item.LoggedMessage.Increment);
		}
		foreach (MLDetailViewModel item2 in new List<MLDetailViewModel>(FilteredSummaryDetailItems))
		{
			if (!hashSet2.Contains(item2.LoggedMessage.Increment))
			{
				FilteredSummaryDetailItems.Remove(item2);
			}
		}
		foreach (MLDetailViewModel item3 in list)
		{
			if (!hashSet.Contains(item3.LoggedMessage.Increment))
			{
				FilteredSummaryDetailItems.Add(item3);
			}
		}
		Misc.Sort(FilteredSummaryDetailItems, (MLDetailViewModel theVM) => theVM.LoggedMessage.Increment, bool_0: true);
	}

	public static void ComputeBalloon(GClass6 gclass6_0)
	{
		try
		{
			DenseVector val = new DenseVector(2);
			System.Drawing.Point point = ManagerListenerManager.SetInterruptibleMap(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1, gclass6_0.Lat, gclass6_0.Lon);
			val[0] = point.X;
			val[1] = point.Y;
			DenseVector val2 = new DenseVector(2);
			val2[0] = gclass6_0.Radius * Math.Cos(gclass6_0.Theta);
			val2[1] = gclass6_0.Radius * Math.Sin(gclass6_0.Theta);
			DenseVector val3 = val2;
			DenseVector val4 = new DenseVector(2);
			val4[0] = gclass6_0.ObservedWidth / 2.0;
			val4[1] = gclass6_0.ObservedHeight / 2.0;
			DenseVector val5 = val4;
			DenseVector val6 = val - val5 - val3;
			gclass6_0.CanvasLeft = ((Vector<double>)val6)[0];
			gclass6_0.CanvasTop = ((Vector<double>)val6)[1];
			DenseVector val7 = new DenseVector(2);
			DenseVector val8 = val6 + val5;
			((Vector<double>)val7)[0] = Math.Min(((Vector<double>)val8)[0], ((Vector<double>)(val8 + val3))[0]);
			((Vector<double>)val7)[1] = Math.Min(((Vector<double>)val8)[1], ((Vector<double>)(val8 + val3))[1]);
			if (((Vector<double>)val3)[0] < 0.0)
			{
				if (((Vector<double>)val3)[1] < 0.0)
				{
					gclass6_0.X1 = 0.0;
					gclass6_0.Y1 = 0.0;
					gclass6_0.X2 = ((Vector<double>)val3)[0];
					gclass6_0.Y2 = ((Vector<double>)val3)[1];
					gclass6_0.StemCanvasLeft = ((Vector<double>)val7)[0] - ((Vector<double>)val3)[0];
					gclass6_0.StemCanvasTop = ((Vector<double>)val7)[1] - ((Vector<double>)val3)[1];
				}
				else
				{
					gclass6_0.X1 = ((Vector<double>)val3)[0];
					gclass6_0.Y1 = ((Vector<double>)val3)[1];
					gclass6_0.X2 = 0.0;
					gclass6_0.Y2 = 0.0;
					gclass6_0.StemCanvasLeft = ((Vector<double>)val7)[0] - ((Vector<double>)val3)[0];
					gclass6_0.StemCanvasTop = ((Vector<double>)val7)[1];
				}
			}
			else if (((Vector<double>)val3)[1] < 0.0)
			{
				gclass6_0.X1 = 0.0;
				gclass6_0.Y1 = 0.0;
				gclass6_0.X2 = ((Vector<double>)val3)[0];
				gclass6_0.Y2 = ((Vector<double>)val3)[1];
				gclass6_0.StemCanvasLeft = ((Vector<double>)val7)[0];
				gclass6_0.StemCanvasTop = ((Vector<double>)val7)[1] - ((Vector<double>)val3)[1];
			}
			else
			{
				gclass6_0.X1 = 0.0;
				gclass6_0.Y1 = 0.0;
				gclass6_0.X2 = ((Vector<double>)val3)[0];
				gclass6_0.Y2 = ((Vector<double>)val3)[1];
				gclass6_0.StemCanvasLeft = ((Vector<double>)val7)[0];
				gclass6_0.StemCanvasTop = ((Vector<double>)val7)[1];
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void CloneInterruptibleRegistry(object sender, EventArgs e)
	{
		GClass6[] array = Balloons.ToArray();
		GClass6[] array2 = array;
		foreach (GClass6 gClass in array2)
		{
			if (!gClass.Hover)
			{
				gClass.Opacity -= (DateTime.Now - m_AccountConnection).TotalSeconds;
			}
			if (gClass.Opacity < 0.0)
			{
				Balloons.Remove(gClass);
			}
		}
		foreach (GClass7 summaryItem in SummaryItems)
		{
			if (!summaryItem.Expanded && !HeaderToShow[summaryItem.Summary])
			{
				int num = 0;
				foreach (MLDetailViewModel detail in summaryItem.Details)
				{
					if (!detail.Read && !HeaderToShow[summaryItem.Summary])
					{
						num++;
					}
				}
				summaryItem.Header = summaryItem.Summary;
				summaryItem.Header = summaryItem.Summary + $" ({num})";
				continue;
			}
			foreach (MLDetailViewModel detail2 in summaryItem.Details)
			{
				detail2.Read = true;
			}
			summaryItem.Header = summaryItem.Summary;
		}
		m_AccountConnection = DateTime.Now;
	}

	public MessageLogControlViewModel()
	{
		MainFormLogWidth = 400;
		HighestIncrement = 0L;
		_RoleConnection = null;
		LogCollapsed = false;
		LogCollapseButtonRotation = 0.0;
		eventConnection = -1;
		HeaderToShow = new Dictionary<string, bool>();
		ShowAll = true;
		InteractiveMode = true;
		MustRefresh = false;
		m_AccountConnection = DateTime.Now;
		SummaryItemsOriginal = new List<GClass7>();
		SummaryItems = new ObservableCollection<GClass7>();
		FilteredSummaryDetailItems = new ObservableCollection<MLDetailViewModel>();
		UniqueHeader = new ObservableCollection<GClass7>();
		Balloons = new ObservableCollection<GClass6>();
		m_MapperConnection = new LockRandom();
	}

	public static string MessageTypeToBalloonText(LoggedMessage.MessageType messageType_0)
	{
		if (1 == 0)
		{
		}
		string result = messageType_0 switch
		{
			LoggedMessage.MessageType.NewContact => "新目标", 
			LoggedMessage.MessageType.ContactChange => "目标变更", 
			LoggedMessage.MessageType.WeaponEndgame => "武器毁伤", 
			LoggedMessage.MessageType.WeaponDamage => "武器毁伤", 
			LoggedMessage.MessageType.AirOps => "空中作战", 
			LoggedMessage.MessageType.UnitLost => "单元损失", 
			LoggedMessage.MessageType.UnitDamage => "Damage", 
			LoggedMessage.MessageType.PointDefence => "点防御", 
			LoggedMessage.MessageType.WeaponLogic => "武器逻辑", 
			LoggedMessage.MessageType.UnitAI => "成员AI", 
			LoggedMessage.MessageType.EventEngine => "Event", 
			LoggedMessage.MessageType.NewWeaponContact => "新的武器目标", 
			LoggedMessage.MessageType.DockingOps => "停靠操作", 
			LoggedMessage.MessageType.NewMineContact => "新雷场目标", 
			LoggedMessage.MessageType.CommsIsolatedMessage => "通信中断", 
			LoggedMessage.MessageType.NewAirContact => "新的空中目标", 
			LoggedMessage.MessageType.NewSurfaceContact => "新的水面目标", 
			LoggedMessage.MessageType.NewUnderwaterContact => "新的水下目标", 
			LoggedMessage.MessageType.NewGroundContact => "新的地面目标", 
			LoggedMessage.MessageType.UnguidedWeaponModifiers => "非制导武器", 
			LoggedMessage.MessageType.const_23 => "条令/交战规则变更", 
			LoggedMessage.MessageType.Debug => "Debug", 
			LoggedMessage.MessageType.UnitAIEmergency => "Crew AI Emergency", 
			_ => "Event", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private void ConnectInterruptibleRegistry(LoggedMessage loggedMessage_0)
	{
		try
		{
			if (string.IsNullOrEmpty(loggedMessage_0.Summary))
			{
				loggedMessage_0.Summary = "无详细信息";
			}
			GClass7 gClass = SummaryItemsOriginal.FirstOrDefault((GClass7 MLSVM) => Operators.CompareString(MLSVM.Summary, MessageTypeToBalloonText(loggedMessage_0.Type), TextCompare: true) == 0);
			System.Drawing.Color messageColor = loggedMessage_0.MessageColor;
			MLDetailViewModel mLDetailViewModel = new MLDetailViewModel();
			MLDetailViewModel mLDetailViewModel2 = mLDetailViewModel;
			mLDetailViewModel2.LongText = StripHTML.RemoveSpecification(loggedMessage_0.Text);
			mLDetailViewModel2.Summary = StripHTML.RemoveSpecification(loggedMessage_0.Summary);
			mLDetailViewModel2.Text = StripHTML.RemoveSpecification(loggedMessage_0.Summary);
			mLDetailViewModel2.PlusVisibility = Visibility.Visible;
			mLDetailViewModel2.Expanded = false;
			mLDetailViewModel2.Timestamp = loggedMessage_0.Timestamp;
			if (loggedMessage_0.Location.HasValue)
			{
				mLDetailViewModel2.Lat = loggedMessage_0.Location.Value.Latitude;
				mLDetailViewModel2.Lon = loggedMessage_0.Location.Value.Longitude;
			}
			mLDetailViewModel2.LoggedMessage = loggedMessage_0;
			mLDetailViewModel2.Brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(messageColor.A, messageColor.R, messageColor.G, messageColor.B));
			mLDetailViewModel2.Read = false;
			mLDetailViewModel2 = null;
			if (gClass == null)
			{
				gClass = new GClass7
				{
					Header = MessageTypeToBalloonText(loggedMessage_0.Type),
					Summary = MessageTypeToBalloonText(loggedMessage_0.Type)
				};
				SummaryItemsOriginal.Add(gClass);
			}
			SummaryItemsOriginal = new List<GClass7>(SummaryItemsOriginal.OrderByDescending((GClass7 F) => F.Timestamp));
			gClass.Details.Add(mLDetailViewModel);
			List<MLDetailViewModel> ilist_ = new List<MLDetailViewModel>(gClass.Details.OrderByDescending((MLDetailViewModel F) => F.Timestamp));
			gClass.Details = new FastObservableCollection<MLDetailViewModel>();
			gClass.Details.AddItems(ilist_);
			gClass.Timestamp = mLDetailViewModel.Timestamp;
			gClass.MessageLogVM = this;
			if (!string.IsNullOrEmpty(loggedMessage_0.Summary) && SimConfiguration.DefaultGamePreferences.MessageLogSettings[loggedMessage_0.Type].ShowBaloon)
			{
				GenerateBalloon(mLDetailViewModel);
			}
			if (!HeaderToShow.ContainsKey(gClass.Summary))
			{
				HeaderToShow.Add(gClass.Summary, value: true);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public GClass6 GenerateBalloon(MLDetailViewModel mldetailViewModel_0)
	{
		if (Balloons.Any((GClass6 F) => ((MLDetailViewModel)F.Tag).LoggedMessage == mldetailViewModel_0.LoggedMessage))
		{
			return null;
		}
		System.Drawing.Color messageColor = mldetailViewModel_0.LoggedMessage.MessageColor;
		GClass6 gclass6_0 = new GClass6();
		gclass6_0.Text = MessageTypeToBalloonText(mldetailViewModel_0.LoggedMessage.Type);
		gclass6_0.Lon = mldetailViewModel_0.Lon;
		ManagerListenerManager.SetInterruptibleMap(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1, mldetailViewModel_0.Lat, mldetailViewModel_0.Lon);
		gclass6_0.Lat = mldetailViewModel_0.Lat;
		gclass6_0.Tag = mldetailViewModel_0;
		gclass6_0.Opacity = 5.0;
		gclass6_0.Summary = StripHTML.RemoveSpecification(mldetailViewModel_0.Summary);
		gclass6_0.Color = messageColor;
		gclass6_0.Radius = 100.0 + m_MapperConnection.NextDouble() * 50.0;
		gclass6_0.Theta = m_MapperConnection.NextDouble() * Math.PI * 2.0;
		Balloons.Add(gclass6_0);
		Dispatcher.CurrentDispatcher.Invoke(delegate
		{
			Balloon item = new Balloon
			{
				CanvasLeft = (int)Math.Round(gclass6_0.CanvasLeft),
				CanvasTop = (int)Math.Round(gclass6_0.CanvasTop),
				StemCanvasLeft = (int)Math.Round(gclass6_0.StemCanvasLeft),
				StemCanvasTop = (int)Math.Round(gclass6_0.StemCanvasTop),
				ObservedHeight = (int)Math.Round(gclass6_0.ObservedHeight),
				ObservedWidth = (int)Math.Round(gclass6_0.ObservedWidth),
				Text = gclass6_0.Text,
				Summary = gclass6_0.Summary,
				Tag = RuntimeHelpers.GetObjectValue(gclass6_0.Tag),
				Lat = gclass6_0.Lat,
				Lon = gclass6_0.Lon,
				Opacity = gclass6_0.Opacity,
				Hover = gclass6_0.Hover,
				Color = gclass6_0.Color,
				X1 = gclass6_0.X1,
				X2 = gclass6_0.X2,
				Y1 = gclass6_0.Y1,
				Y2 = gclass6_0.Y2,
				Radius = gclass6_0.Radius,
				Theta = gclass6_0.Theta
			};
			ItemExporter.ConnectInterruptibleTemplate.MainForm.BalloonsRenderingList.Add(item);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetRenderCountdown(5.0);
		});
		return gclass6_0;
	}

	internal void MoveInterruptibleRegistry()
	{
		ClearLog();
		HighestIncrement = 0L;
		RefreshLog();
	}

	internal void DeleteInterruptibleRegistry()
	{
		ResetLog();
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ManagerConnection?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private bool AddInterruptibleRegistry(LoggedMessage loggedMessage_0)
	{
		return loggedMessage_0.Increment > HighestIncrement;
	}

	[CompilerGenerated]
	private bool DestroyInterruptibleRegistry(LoggedMessage loggedMessage_0)
	{
		return (loggedMessage_0.Increment > HighestIncrement) & (Operators.CompareString(loggedMessage_0.ReporterID, Client.CurrentMapProfile.String_0, TextCompare: true) == 0);
	}
}
