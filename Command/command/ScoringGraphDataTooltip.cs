using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
[DesignerGenerated]
public class ScoringGraphDataTooltip : UserControl, IChartTooltip, INotifyPropertyChanged, IComponentConnector
{
	private TooltipData descriptorSingleton;

	[CompilerGenerated]
	private PropertyChangedEventHandler _PoolSingleton;

	private TooltipSelectionMode? _TaskSingleton;

	private bool _FilterSingleton;

	internal TextBlock TB_1;

	internal TextBlock TB_2;

	internal TextBlock TB_3;

	private bool _contentLoaded;

	TooltipData IChartTooltip.Data
	{
		get
		{
			return descriptorSingleton;
		}
		set
		{
			if (descriptorSingleton != value)
			{
				descriptorSingleton = value;
				DeleteInterruptibleServer("Data");
				ScoringDatapointViewModel scoringDatapointViewModel = (ScoringDatapointViewModel)descriptorSingleton.Points.First().ChartPoint.Instance;
				TB_2.Text = scoringDatapointViewModel.Reason;
				TB_1.Text = "分数：" + scoringDatapointViewModel.ScoreValue;
				TB_3.Text = scoringDatapointViewModel.DateTime.ToString();
			}
		}
	}

	public TooltipSelectionMode? SelectionMode
	{
		[CompilerGenerated]
		get
		{
			return _TaskSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!Nullable.Equals(_TaskSingleton, value))
			{
				_TaskSingleton = value;
				DeleteInterruptibleServer("SelectionMode");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _PoolSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _PoolSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _PoolSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _PoolSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public ScoringGraphDataTooltip()
	{
		InitializeComponent();
	}

	private void DeleteInterruptibleServer(string string_0)
	{
		_PoolSingleton?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/scoringgraphdatatooltip.xaml", UriKind.Relative);
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
			TB_1 = (TextBlock)target;
			break;
		case 2:
			TB_2 = (TextBlock)target;
			break;
		case 3:
			TB_3 = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
