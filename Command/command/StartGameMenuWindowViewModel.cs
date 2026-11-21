using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Imaging;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class StartGameMenuWindowViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private BitmapSource proxyException;

	[CompilerGenerated]
	private RelayCommand _ReaderException;

	[CompilerGenerated]
	private RelayCommand _PropertyException;

	[CompilerGenerated]
	private RelayCommand importerException;

	[CompilerGenerated]
	private RelayCommand repositoryException;

	[CompilerGenerated]
	private RelayCommand m_BridgeException;

	[CompilerGenerated]
	private RelayCommand invocationException;

	[CompilerGenerated]
	private RelayCommand classException;

	[CompilerGenerated]
	private RelayCommand _RequestException;

	[CompilerGenerated]
	private RelayCommand valueException;

	private StartGameMenuWindow m_TokenizerException;

	[NonSerialized]
	private PropertyChangedEventHandler _StubException;

	public BitmapSource BackgroundImage
	{
		[CompilerGenerated]
		get
		{
			return proxyException;
		}
		[CompilerGenerated]
		set
		{
			if (proxyException != value)
			{
				proxyException = value;
				OnPropertyChanged("BackgroundImage");
			}
		}
	}

	public RelayCommand StartNewCampaignCommand
	{
		[CompilerGenerated]
		get
		{
			return _ReaderException;
		}
		[CompilerGenerated]
		set
		{
			if (_ReaderException != value)
			{
				_ReaderException = value;
				OnPropertyChanged("StartNewCampaignCommand");
			}
		}
	}

	public RelayCommand QuickBattleCommand
	{
		[CompilerGenerated]
		get
		{
			return _PropertyException;
		}
		[CompilerGenerated]
		set
		{
			if (_PropertyException != value)
			{
				_PropertyException = value;
				OnPropertyChanged("QuickBattleCommand");
			}
		}
	}

	public RelayCommand NewGameCommand
	{
		[CompilerGenerated]
		get
		{
			return importerException;
		}
		[CompilerGenerated]
		set
		{
			if (importerException != value)
			{
				importerException = value;
				OnPropertyChanged("NewGameCommand");
			}
		}
	}

	public RelayCommand LoadGameCommand
	{
		[CompilerGenerated]
		get
		{
			return repositoryException;
		}
		[CompilerGenerated]
		set
		{
			if (repositoryException != value)
			{
				repositoryException = value;
				OnPropertyChanged("LoadGameCommand");
			}
		}
	}

	public RelayCommand ResumeGameCommand
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeException;
		}
		[CompilerGenerated]
		set
		{
			if (m_BridgeException != value)
			{
				m_BridgeException = value;
				OnPropertyChanged("ResumeGameCommand");
			}
		}
	}

	public RelayCommand CreateScenCommand
	{
		[CompilerGenerated]
		get
		{
			return invocationException;
		}
		[CompilerGenerated]
		set
		{
			if (invocationException != value)
			{
				invocationException = value;
				OnPropertyChanged("CreateScenCommand");
			}
		}
	}

	public RelayCommand MultiplayerCommand
	{
		[CompilerGenerated]
		get
		{
			return classException;
		}
		[CompilerGenerated]
		set
		{
			if (classException != value)
			{
				classException = value;
				OnPropertyChanged("MultiplayerCommand");
			}
		}
	}

	public RelayCommand LoadScenCommand
	{
		[CompilerGenerated]
		get
		{
			return _RequestException;
		}
		[CompilerGenerated]
		set
		{
			if (_RequestException != value)
			{
				_RequestException = value;
				OnPropertyChanged("LoadScenCommand");
			}
		}
	}

	public RelayCommand ExitCommand
	{
		[CompilerGenerated]
		get
		{
			return valueException;
		}
		[CompilerGenerated]
		set
		{
			if (valueException != value)
			{
				valueException = value;
				OnPropertyChanged("ExitCommand");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _StubException;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _StubException, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _StubException;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _StubException, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	private void SetInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			ItemExporter.ConnectInterruptibleTemplate.MultiplayerForm.Show();
		});
		m_TokenizerException.Close();
	}

	private void FillInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			ItemExporter.ConnectInterruptibleTemplate.QuickBattle.Show();
		});
		m_TokenizerException.Close();
	}

	private void CalculateInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Close();
		});
	}

	private void PopInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			if (Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
			{
				Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
				ItemExporter.ConnectInterruptibleTemplate.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
				ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleLicense.CommandFullVersion };
				ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
			}
		});
	}

	private void InstantiateInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			if (Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
			{
				Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
				Client.CreateNewScenario();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleLicense.CommandFullVersion };
				ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
			}
		});
		m_TokenizerException.Close();
	}

	private void CreateInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			string text = "";
			if (Directory.Exists(GameGeneral.ScenariosRootPath + "\\Autosaves"))
			{
				DirectoryInfo directoryInfo = (from p in new DirectoryInfo(GameGeneral.ScenariosRootPath + "\\Autosaves").GetDirectories()
					orderby p.LastWriteTime descending
					select p).First();
				text = GameGeneral.ScenariosRootPath + "\\Autosaves\\" + directoryInfo.Name + " \\Autosave.scen";
			}
			if (Operators.CompareString(text, "", TextCompare: true) != 0 && FileExistsNative.FileExistsFast(text))
			{
				Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = text;
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
			}
			else if (File.Exists(GameGeneral.ScenariosRootPath + "\\Autosave.scen"))
			{
				Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = GameGeneral.ScenariosRootPath + "\\Autosave.scen";
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
			}
			else
			{
				DarkMessageBox.ShowError("No autosave file was found at the path " + text, "没有找到自动保存存档");
			}
		});
	}

	private void CompareInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadSavedGame;
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
		});
	}

	private void ReadInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
		});
	}

	private void DisableInterruptibleRecord(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			ItemExporter.ConnectInterruptibleTemplate.CampaignPlayWindow.Show();
		});
	}

	[Obsolete]
	public StartGameMenuWindowViewModel()
	{
		StartNewCampaignCommand = new RelayCommand(DisableInterruptibleRecord);
		QuickBattleCommand = new RelayCommand(FillInterruptibleRecord);
		NewGameCommand = new RelayCommand(ReadInterruptibleRecord);
		LoadGameCommand = new RelayCommand(CompareInterruptibleRecord);
		ResumeGameCommand = new RelayCommand(CreateInterruptibleRecord);
		CreateScenCommand = new RelayCommand(InstantiateInterruptibleRecord);
		MultiplayerCommand = new RelayCommand(SetInterruptibleRecord);
		LoadScenCommand = new RelayCommand(PopInterruptibleRecord);
		ExitCommand = new RelayCommand(CalculateInterruptibleRecord);
	}

	public StartGameMenuWindowViewModel(StartGameMenuWindow startGameMenuWindow_0)
	{
		StartNewCampaignCommand = new RelayCommand(DisableInterruptibleRecord);
		QuickBattleCommand = new RelayCommand(FillInterruptibleRecord);
		NewGameCommand = new RelayCommand(ReadInterruptibleRecord);
		LoadGameCommand = new RelayCommand(CompareInterruptibleRecord);
		ResumeGameCommand = new RelayCommand(CreateInterruptibleRecord);
		CreateScenCommand = new RelayCommand(InstantiateInterruptibleRecord);
		MultiplayerCommand = new RelayCommand(SetInterruptibleRecord);
		LoadScenCommand = new RelayCommand(PopInterruptibleRecord);
		ExitCommand = new RelayCommand(CalculateInterruptibleRecord);
		m_TokenizerException = startGameMenuWindow_0;
	}

	public void OnPropertyChanged(string string_0)
	{
		_StubException?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
