using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class GameControlBar : UserControl, IComponentConnector
{
	internal ComboBoxItem comboBoxItem_0;

	internal Image image_0;

	internal ComboBoxItem comboBoxItem_1;

	internal Image image_1;

	internal ComboBoxItem comboBoxItem_2;

	internal Image image_2;

	internal ComboBoxItem comboBoxItem_3;

	internal Image image_3;

	private bool m_SchemaTests;

	internal ComboBox TimeComboBox;

	internal ComboBoxItem TimeItem1x;

	internal Image Time1Image;

	internal ComboBoxItem TimeItem2x;

	internal Image Time2Image;

	internal ComboBoxItem TimeItem5x;

	internal Image Time5Image;

	internal ComboBoxItem TimeItem15x;

	internal Image Time15Image;

	internal ComboBoxItem TimeItemTurbo;

	internal Image TimeTurboImage;

	internal ComboBoxItem TimeItemDoubleFlame;

	internal Image TimeDoubleFlameImage;

	internal Button ToggleFidelityMode;

	internal Image ToggleFidelityModeImage;

	internal TextBlock ToggleFidelityModeLabel;

	internal Button PlayButton;

	internal Image PlayButtonImage;

	internal Button PauseButton;

	internal Image PauseButtonImage;

	internal Button PlayButtonAt1Time;

	internal Image PlayAtTime1ButtonImage;

	internal Button RecordButton;

	internal Image RecordButtonImage;

	internal Button LayersButton;

	internal Image LayersButtonImage;

	internal Image ArrowButtonImage;

	internal Button SpecialActionsButton;

	internal Image SpecialButtonImage;

	internal TextBlock SpecialActionLabel;

	internal Button GameOptionsButton;

	internal Image GameOptionsImage;

	internal Button GCB_MP_CommitTurnButton;

	internal Label GCB_ToolStripStatusLabel1;

	internal Label GCB_MP_ReplayToolStripStatusLabel;

	internal Label GCB_MP_StatusLabel;

	internal Label GCB_MP_SpecialNoticeLabel;

	internal Label GCB_ToolStripLabel1;

	internal Label GCB_ToolStripLabel2;

	internal Label GCB_MP_SpeedChess_CommitCountdownLabel;

	internal Label GCB_MP_SpeedChess_EventLabel;

	private bool _contentLoaded;

	public GameControlBar()
	{
		InitializeComponent();
		if (!Assembly.GetExecutingAssembly().Location.Contains("VisualStudio"))
		{
			Time1Image.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Time_1x.png"));
			Time2Image.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Time_2x.png"));
			Time5Image.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Time_5x.png"));
			Time15Image.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Time_15x.png"));
			TimeTurboImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Time_Turbo.png"));
			TimeDoubleFlameImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Time_DoubleFlame.png"));
			ArrowButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Arrow.png"));
			LayersButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Layers.png"));
			PlayButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Play.png"));
			PlayAtTime1ButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Play_1x.png"));
			PauseButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Pause.png"));
			RecordButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Record.png"));
			SpecialButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Special.png"));
			GameOptionsImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/OptionsIcon.png"));
		}
	}

	private void CallAnnotation(object sender, SelectionChangedEventArgs e)
	{
		if (Client._CandidateClass)
		{
			ComboBoxItem comboBoxItem = (ComboBoxItem)TimeComboBox.SelectedItem;
			if (comboBoxItem == TimeItem1x)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSMI_TimeAccel1x_Click(null, null);
			}
			else if (comboBoxItem == TimeItem2x)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSMI_TimeAccel2x_Click(null, null);
			}
			else if (comboBoxItem == TimeItem5x)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSMI_TimeAccel5x_Click(null, null);
			}
			else if (comboBoxItem == TimeItem15x)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSMI_TimeAccel15x_Click(null, null);
			}
			else if (comboBoxItem == TimeItemTurbo)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSMI_TimeAccelTurbo_Click(null, null);
			}
			else if (comboBoxItem == TimeItemDoubleFlame)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSMI_TimeAccelDoubleFlame_Click(null, null);
			}
		}
	}

	private void LogoutAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_StartGame_Click(null, null);
	}

	private void ViewAnnotation(object sender, RoutedEventArgs e)
	{
		if (Client.CurrentScenario.GameResolution == 0.1f)
		{
			Client.CurrentScenario.SetSimulationFidelity(1f, bool_0: true);
		}
		else if (Client.CurrentScenario.GameResolution == 1f)
		{
			Client.CurrentScenario.SetSimulationFidelity(5f, bool_0: true);
		}
		else
		{
			Client.CurrentScenario.SetSimulationFidelity(0.1f, bool_0: true);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshControlBarCompressionElements();
	}

	private void ValidateAnnotation(object sender, RoutedEventArgs e)
	{
		if (Client.PopConfiguration())
		{
			Client.InstantiateConfiguration(bool_0: false);
			RecordButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/Record.png"));
			RecordButton.ToolTip = "Record the current game";
		}
		else
		{
			Client._DatabaseClass = Recorder.CreateNewTape(null, null);
			Client.InstantiateConfiguration(bool_0: true);
			RecordButtonImage.Source = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Bar/RecordStop.png"));
			RecordButton.ToolTip = "停止录制";
		}
	}

	private void LoginAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.CustomLayersForm.Show();
	}

	private void GetAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_ToggleCommandShortcuts_Click(null, null);
	}

	private void WriteAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_StartGame_Click(null, null);
	}

	private void NewAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.SpecialActionsForm.Show();
	}

	private void PushAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.TSMI_TimeAccel1x_Click(null, null);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.SetPlayButton(bool_0: true);
	}

	private void InvokeAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.Options.Show();
	}

	private void SetupAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MP_CommitTurnButton.PerformClick();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/gamecontrolbar.xaml", UriKind.Relative);
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
			TimeComboBox = (ComboBox)target;
			TimeComboBox.SelectionChanged += CallAnnotation;
			break;
		case 2:
			TimeItem1x = (ComboBoxItem)target;
			break;
		case 3:
			Time1Image = (Image)target;
			break;
		case 4:
			TimeItem2x = (ComboBoxItem)target;
			break;
		case 5:
			Time2Image = (Image)target;
			break;
		case 6:
			TimeItem5x = (ComboBoxItem)target;
			break;
		case 7:
			Time5Image = (Image)target;
			break;
		case 8:
			TimeItem15x = (ComboBoxItem)target;
			break;
		case 9:
			Time15Image = (Image)target;
			break;
		case 10:
			TimeItemTurbo = (ComboBoxItem)target;
			break;
		case 11:
			TimeTurboImage = (Image)target;
			break;
		case 12:
			TimeItemDoubleFlame = (ComboBoxItem)target;
			break;
		case 13:
			TimeDoubleFlameImage = (Image)target;
			break;
		case 14:
			ToggleFidelityMode = (Button)target;
			ToggleFidelityMode.Click += ViewAnnotation;
			break;
		case 15:
			ToggleFidelityModeImage = (Image)target;
			break;
		case 16:
			ToggleFidelityModeLabel = (TextBlock)target;
			break;
		case 17:
			PlayButton = (Button)target;
			PlayButton.Click += LogoutAnnotation;
			break;
		case 18:
			PlayButtonImage = (Image)target;
			break;
		case 19:
			PauseButton = (Button)target;
			PauseButton.Click += WriteAnnotation;
			break;
		case 20:
			PauseButtonImage = (Image)target;
			break;
		case 21:
			PlayButtonAt1Time = (Button)target;
			PlayButtonAt1Time.Click += PushAnnotation;
			break;
		case 22:
			PlayAtTime1ButtonImage = (Image)target;
			break;
		case 23:
			RecordButton = (Button)target;
			RecordButton.Click += ValidateAnnotation;
			break;
		case 24:
			RecordButtonImage = (Image)target;
			break;
		case 25:
			LayersButton = (Button)target;
			LayersButton.Click += LoginAnnotation;
			break;
		case 26:
			LayersButtonImage = (Image)target;
			break;
		case 27:
			((Button)target).Click += GetAnnotation;
			break;
		case 28:
			ArrowButtonImage = (Image)target;
			break;
		case 29:
			SpecialActionsButton = (Button)target;
			SpecialActionsButton.Click += NewAnnotation;
			break;
		case 30:
			SpecialButtonImage = (Image)target;
			break;
		case 31:
			SpecialActionLabel = (TextBlock)target;
			break;
		case 32:
			GameOptionsButton = (Button)target;
			GameOptionsButton.Click += InvokeAnnotation;
			break;
		case 33:
			GameOptionsImage = (Image)target;
			break;
		case 34:
			GCB_MP_CommitTurnButton = (Button)target;
			GCB_MP_CommitTurnButton.Click += SetupAnnotation;
			break;
		case 35:
			GCB_ToolStripStatusLabel1 = (Label)target;
			break;
		case 36:
			GCB_MP_ReplayToolStripStatusLabel = (Label)target;
			break;
		case 37:
			GCB_MP_StatusLabel = (Label)target;
			break;
		case 38:
			GCB_MP_SpecialNoticeLabel = (Label)target;
			break;
		case 39:
			GCB_ToolStripLabel1 = (Label)target;
			break;
		case 40:
			GCB_ToolStripLabel2 = (Label)target;
			break;
		case 41:
			GCB_MP_SpeedChess_CommitCountdownLabel = (Label)target;
			break;
		case 42:
			GCB_MP_SpeedChess_EventLabel = (Label)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
