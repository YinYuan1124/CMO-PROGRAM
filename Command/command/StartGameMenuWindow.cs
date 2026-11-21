using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Command.Records;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class StartGameMenuWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class ProxyCollectionTask
	{
		public IntPtr MainFormHandle;

		internal void InstantiateInterruptibleMethod()
		{
			new WindowInteropHelper(Client.startGameMenuWindow_0).Owner = MainFormHandle;
		}
	}

	public static Thread StartGameWindowThread;

	public static Dispatcher StartGameWindowThreadDispatcher;

	private bool facadeException;

	internal Label Label_ProgramTitle;

	internal Button Button_NewGame;

	internal Button Button_QuickBattle;

	internal Button Button_Campaign;

	internal Rectangle Divider1;

	internal Button Button_LoadGame;

	internal Button Button_ResumeGame;

	internal Rectangle Divider2;

	internal Button Button_CreateScenario;

	internal Button Button_LoadScenario;

	internal Rectangle Divider3;

	internal Button Button_Multiplayer;

	internal Rectangle Divider4;

	internal Button Button_Exit;

	internal StackPanel LeftPanel;

	internal Image GraphicImage;

	internal Label Label_Loading;

	internal StackPanel ClientInfoPanel;

	internal TextBlock ClientInfoTextBlock;

	internal TextBlock TechSupportTextBlock;

	private bool _contentLoaded;

	public StartGameMenuWindow()
	{
		base.Closing += InitInterruptibleRecord;
		InitializeComponent();
		base.Loaded += delegate
		{
			try
			{
				Localization.ApplyToWpfElement(this);
			}
			catch
			{
			}
		};
		Localization.LanguageChanged += delegate
		{
			try
			{
				base.Dispatcher.InvokeAsync(delegate
				{
					try
					{
						Localization.ApplyToWpfElement(this);
					}
					catch
					{
					}
				});
			}
			catch
			{
			}
		};
	}

	private static void EnableInterruptibleRecord()
	{
		Client.startGameMenuWindow_0 = new StartGameMenuWindow();
		StartGameWindowThreadDispatcher = Dispatcher.CurrentDispatcher;
		Dispatcher.Run();
	}

	public static void UpdateStartWindow()
	{
		StartGameWindowThreadDispatcher.InvokeAsync(delegate
		{
		});
	}

	public static void ShowStartWindow()
	{
		if (StartGameWindowThread == null)
		{
			StartGameWindowThread = new Thread(EnableInterruptibleRecord);
			StartGameWindowThread.Name = "StartGameWindowThread";
			StartGameWindowThread.SetApartmentState(ApartmentState.STA);
			StartGameWindowThread.IsBackground = true;
			StartGameWindowThread.Start();
			while (StartGameWindowThreadDispatcher == null)
			{
				Thread.Sleep(1);
			}
		}
		if (Client.startGameMenuWindow_0 == null && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		StartGameWindowThreadDispatcher.InvokeAsync(delegate
		{
			if (!Client.startGameMenuWindow_0.IsVisible)
			{
				Client.startGameMenuWindow_0.WindowState = WindowState.Normal;
				Client.startGameMenuWindow_0.WindowStyle = WindowStyle.None;
				Client.startGameMenuWindow_0.Show();
			}
			Client.startGameMenuWindow_0.Focus();
		});
	}

	public static void HideStartWindow()
	{
		StartGameWindowThreadDispatcher.InvokeAsync(delegate
		{
			if (Client.startGameMenuWindow_0.IsVisible)
			{
				Client.startGameMenuWindow_0.Hide();
			}
		});
	}

	private void ChangeInterruptibleRecord(object sender, RoutedEventArgs e)
	{
		Client.startGameMenuWindow_0.Focus();
		Label_Loading.Content = "加载中，请稍候...";
		Button_Campaign.Visibility = Visibility.Hidden;
		Button_QuickBattle.Visibility = Visibility.Hidden;
		Button_NewGame.Visibility = Visibility.Hidden;
		Button_LoadGame.Visibility = Visibility.Hidden;
		Button_ResumeGame.Visibility = Visibility.Hidden;
		Button_CreateScenario.Visibility = Visibility.Hidden;
		Button_LoadScenario.Visibility = Visibility.Hidden;
		Button_Exit.Visibility = Visibility.Hidden;
		Divider1.Visibility = Visibility.Hidden;
		Divider2.Visibility = Visibility.Hidden;
		Divider3.Visibility = Visibility.Hidden;
		Divider4.Visibility = Visibility.Hidden;
		Button_Multiplayer.Visibility = Visibility.Collapsed;
		Divider3.Visibility = Visibility.Collapsed;
		Label_ProgramTitle.Content = GameGeneral.ProgramTitle;
		GraphicImage.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("Symbols\\StartMenu\\CMO_logo.jpg")));
		base.DataContext = new StartGameMenuWindowViewModel(this);
		base.ShowInTaskbar = true;
	}

	public void ShowButtons()
	{
		StartGameWindowThreadDispatcher.InvokeAsync(delegate
		{
			Label_Loading.Visibility = Visibility.Hidden;
			Button_Campaign.Visibility = Visibility.Visible;
			Button_Campaign.IsEnabled = !GameGeneral.PE_MPOnly;
			Button_QuickBattle.Visibility = Visibility.Visible;
			Button_QuickBattle.IsEnabled = !GameGeneral.PE_MPOnly;
			Button_NewGame.Visibility = Visibility.Visible;
			Button_NewGame.IsEnabled = !GameGeneral.PE_MPOnly;
			Button_LoadGame.Visibility = Visibility.Visible;
			Button_LoadGame.IsEnabled = !GameGeneral.PE_MPOnly;
			Button_ResumeGame.Visibility = Visibility.Visible;
			Button_ResumeGame.IsEnabled = !GameGeneral.PE_MPOnly;
			Button_CreateScenario.Visibility = Visibility.Visible;
			Button_CreateScenario.IsEnabled = !GameGeneral.PE_MPOnly;
			Button_LoadScenario.Visibility = Visibility.Visible;
			Button_LoadScenario.IsEnabled = !GameGeneral.PE_MPOnly;
			Button_Exit.Visibility = Visibility.Visible;
			Divider1.Visibility = Visibility.Visible;
			Divider2.Visibility = Visibility.Visible;
			Divider4.Visibility = Visibility.Visible;
			Button_Multiplayer.Visibility = Visibility.Collapsed;
			Divider3.Visibility = Visibility.Collapsed;
			Label_ProgramTitle.Content = GameGeneral.ProgramTitle;
			base.WindowState = WindowState.Normal;
			if (SimConfiguration.DefaultGamePreferences.GameMusic)
			{
				AuthenticationSingleton.PushInterruptibleSchema();
			}
		});
	}

	private void InitInterruptibleRecord(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
		Hide();
	}

	private void CheckInterruptibleRecord(object sender, DependencyPropertyChangedEventArgs e)
	{
	}

	public static void MainFormShown(IntPtr intptr_0)
	{
		StartGameWindowThreadDispatcher.InvokeAsync(delegate
		{
			new WindowInteropHelper(Client.startGameMenuWindow_0).Owner = intptr_0;
		});
	}

	private void ConcatInterruptibleRecord(object sender, MouseButtonEventArgs e)
	{
		if ((e.ChangedButton == MouseButton.Left) & (e.ButtonState == MouseButtonState.Pressed))
		{
			DragMove();
		}
	}

	private void InterruptInterruptibleRecord(object sender, MouseButtonEventArgs e)
	{
		Close();
	}

	private void RemoveInterruptibleRecord(object sender, RoutedEventArgs e)
	{
		try
		{
			Process.Start("https://pro.matrixgames.com/member/helpdesk");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[CompilerGenerated]
	private void FindInterruptibleRecord()
	{
		Label_Loading.Visibility = Visibility.Hidden;
		Button_Campaign.Visibility = Visibility.Visible;
		Button_Campaign.IsEnabled = !GameGeneral.PE_MPOnly;
		Button_QuickBattle.Visibility = Visibility.Visible;
		Button_QuickBattle.IsEnabled = !GameGeneral.PE_MPOnly;
		Button_NewGame.Visibility = Visibility.Visible;
		Button_NewGame.IsEnabled = !GameGeneral.PE_MPOnly;
		Button_LoadGame.Visibility = Visibility.Visible;
		Button_LoadGame.IsEnabled = !GameGeneral.PE_MPOnly;
		Button_ResumeGame.Visibility = Visibility.Visible;
		Button_ResumeGame.IsEnabled = !GameGeneral.PE_MPOnly;
		Button_CreateScenario.Visibility = Visibility.Visible;
		Button_CreateScenario.IsEnabled = !GameGeneral.PE_MPOnly;
		Button_LoadScenario.Visibility = Visibility.Visible;
		Button_LoadScenario.IsEnabled = !GameGeneral.PE_MPOnly;
		Button_Exit.Visibility = Visibility.Visible;
		Divider1.Visibility = Visibility.Visible;
		Divider2.Visibility = Visibility.Visible;
		Divider4.Visibility = Visibility.Visible;
		Button_Multiplayer.Visibility = Visibility.Collapsed;
		Divider3.Visibility = Visibility.Collapsed;
		Label_ProgramTitle.Content = GameGeneral.ProgramTitle;
		base.WindowState = WindowState.Normal;
		if (SimConfiguration.DefaultGamePreferences.GameMusic)
		{
			AuthenticationSingleton.PushInterruptibleSchema();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/startgamemenuwindow.xaml", UriKind.Relative);
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
			((StartGameMenuWindow)target).Loaded += ChangeInterruptibleRecord;
			break;
		case 2:
			((Grid)target).MouseDown += ConcatInterruptibleRecord;
			break;
		case 3:
			Label_ProgramTitle = (Label)target;
			break;
		case 4:
			((System.Windows.Shapes.Path)target).MouseDown += InterruptInterruptibleRecord;
			break;
		case 5:
			Button_NewGame = (Button)target;
			break;
		case 6:
			Button_QuickBattle = (Button)target;
			break;
		case 7:
			Button_Campaign = (Button)target;
			break;
		case 8:
			Divider1 = (Rectangle)target;
			break;
		case 9:
			Button_LoadGame = (Button)target;
			break;
		case 10:
			Button_ResumeGame = (Button)target;
			break;
		case 11:
			Divider2 = (Rectangle)target;
			break;
		case 12:
			Button_CreateScenario = (Button)target;
			break;
		case 13:
			Button_LoadScenario = (Button)target;
			break;
		case 14:
			Divider3 = (Rectangle)target;
			break;
		case 15:
			Button_Multiplayer = (Button)target;
			break;
		case 16:
			Divider4 = (Rectangle)target;
			break;
		case 17:
			Button_Exit = (Button)target;
			break;
		case 18:
			LeftPanel = (StackPanel)target;
			break;
		case 19:
			GraphicImage = (Image)target;
			break;
		case 20:
			Label_Loading = (Label)target;
			break;
		case 21:
			ClientInfoPanel = (StackPanel)target;
			break;
		case 22:
			ClientInfoTextBlock = (TextBlock)target;
			break;
		case 23:
			TechSupportTextBlock = (TextBlock)target;
			break;
		case 24:
			((Hyperlink)target).Click += RemoveInterruptibleRecord;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
