using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class MessageLogControl : UserControl, INotifyPropertyChanged, IStyleConnector, IComponentConnector
{
	[NonSerialized]
	private PropertyChangedEventHandler m_InterceptorConnection;

	private bool m_MessageConnection;

	internal Button ShowAllButton;

	internal Button ToggleRawModeButton;

	internal ScrollViewer RawLOGsv;

	internal ScrollViewer InteractiveLOGsv;

	private bool _contentLoaded;

	public MessageLogControlViewModel VM => (MessageLogControlViewModel)base.DataContext;

	public string DisplayModeString => VM.DisplayModeString;

	public bool RawModeVisibility
	{
		get
		{
			if (VM.RawMode)
			{
				return false;
			}
			return true;
		}
	}

	public bool InteractiveModeVisibility
	{
		get
		{
			if (VM.RawMode)
			{
				return true;
			}
			return false;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_InterceptorConnection;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_InterceptorConnection, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_InterceptorConnection;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_InterceptorConnection, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public MessageLogControl()
	{
		InitializeComponent();
	}

	private void CollectInterruptibleConfig(object sender, MouseEventArgs e)
	{
		TextBlock textBlock = (TextBlock)sender;
		if (textBlock != null)
		{
			MLDetailViewModel mLDetailViewModel = (MLDetailViewModel)textBlock.Tag;
			if (VM != null && SimConfiguration.DefaultGamePreferences.MessageLogSettings[mLDetailViewModel.LoggedMessage.Type].ShowBaloon)
			{
				VM.GenerateBalloon(mLDetailViewModel);
			}
		}
	}

	private void OrderInterruptibleConfig(object sender, MouseEventArgs e)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(((TextBlock)sender).Tag);
		if (VM == null)
		{
			return;
		}
		GClass6[] array = VM.Balloons.ToArray();
		GClass6[] array2 = array;
		foreach (GClass6 gClass in array2)
		{
			if (gClass.Tag == objectValue)
			{
				gClass.Hover = false;
			}
		}
	}

	private void RegisterInterruptibleConfig(object sender, MouseButtonEventArgs e)
	{
		_ = (MLDetailViewModel)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
	}

	private void ManageInterruptibleConfig(object sender, MouseButtonEventArgs e)
	{
		try
		{
			MLDetailViewModel mLDetailViewModel = (MLDetailViewModel)((Grid)sender).DataContext;
			if (mLDetailViewModel.Lon != 0.0 || mLDetailViewModel.Lat != 0.0)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(mLDetailViewModel.Lon, mLDetailViewModel.Lat));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void RevertInterruptibleConfig(object sender, RoutedEventArgs e)
	{
		VM.RawMode = !VM.RawMode;
		InteractiveLOGsv.Visibility = (Visibility)(-(InteractiveModeVisibility ? 1 : 0));
		RawLOGsv.Visibility = (Visibility)(-(RawModeVisibility ? 1 : 0));
	}

	private void CountInterruptibleRegistry(object sender, RoutedEventArgs e)
	{
		VM.ShowAll = !VM.ShowAll;
		if (VM.ShowAll)
		{
			ShowAllButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 115, 115, 115));
		}
		else
		{
			ShowAllButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 63, 63, 63));
		}
		short num = (short)(VM.HeaderToShow.Count - 1);
		for (short num2 = 0; num2 <= num; num2++)
		{
			VM.HeaderToShow[VM.HeaderToShow.ElementAt(num2).Key] = VM.ShowAll;
		}
		VM.RefreshLoggedMessages();
	}

	private void CustomizeInterruptibleRegistry(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.ToggleMessageLogInSeparateWindow();
	}

	public BitmapImage ConvertBitmap(Bitmap bitmap_0)
	{
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		bitmap_0.Save(memoryStream, ImageFormat.Bmp);
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		bitmapImage.StreamSource = memoryStream;
		bitmapImage.EndInit();
		return bitmapImage;
	}

	public void OnPropertyChanged(string string_0)
	{
		m_InterceptorConnection?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/messagelogcontrol.xaml", UriKind.Relative);
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
			ShowAllButton = (Button)target;
			ShowAllButton.Click += CountInterruptibleRegistry;
			break;
		case 2:
			ToggleRawModeButton = (Button)target;
			ToggleRawModeButton.Click += RevertInterruptibleConfig;
			break;
		case 3:
			((Button)target).Click += CustomizeInterruptibleRegistry;
			break;
		case 4:
			RawLOGsv = (ScrollViewer)target;
			break;
		case 5:
			InteractiveLOGsv = (ScrollViewer)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IStyleConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 6:
			((Grid)target).MouseLeftButtonDown += ManageInterruptibleConfig;
			break;
		case 7:
			((TextBlock)target).MouseEnter += CollectInterruptibleConfig;
			((TextBlock)target).MouseLeave += OrderInterruptibleConfig;
			((TextBlock)target).MouseDown += RegisterInterruptibleConfig;
			break;
		case 8:
			((TextBlock)target).MouseEnter += CollectInterruptibleConfig;
			((TextBlock)target).MouseLeave += OrderInterruptibleConfig;
			((TextBlock)target).MouseDown += RegisterInterruptibleConfig;
			break;
		}
	}
}
