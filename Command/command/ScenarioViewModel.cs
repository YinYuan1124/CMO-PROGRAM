using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public abstract class ScenarioViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string _DefinitionSingleton;

	[CompilerGenerated]
	private string valSingleton;

	[CompilerGenerated]
	private string m_WrapperSingleton;

	[CompilerGenerated]
	private string observerSingleton;

	[CompilerGenerated]
	private string m_IssuerSingleton;

	public ScenarioSelectControlViewModel ScenarioSelectControlViewModel;

	[CompilerGenerated]
	private RelayCommand m_ClientSingleton;

	[NonSerialized]
	private PropertyChangedEventHandler _DicSingleton;

	public string ScenarioDate
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_DefinitionSingleton, value, StringComparison.Ordinal))
			{
				_DefinitionSingleton = value;
				OnPropertyChanged("ScenarioDate");
			}
		}
	}

	public string ScenarioComplexity
	{
		[CompilerGenerated]
		get
		{
			return valSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(valSingleton, value, StringComparison.Ordinal))
			{
				valSingleton = value;
				OnPropertyChanged("ScenarioComplexity");
			}
		}
	}

	public string ScenarioDifficulty
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_WrapperSingleton, value, StringComparison.Ordinal))
			{
				m_WrapperSingleton = value;
				OnPropertyChanged("ScenarioDifficulty");
			}
		}
	}

	public string ScenarioName
	{
		[CompilerGenerated]
		get
		{
			return observerSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(observerSingleton, value, StringComparison.Ordinal))
			{
				observerSingleton = value;
				OnPropertyChanged("ScenarioName");
			}
		}
	}

	public string ScenarioPath
	{
		[CompilerGenerated]
		get
		{
			return m_IssuerSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_IssuerSingleton, value, StringComparison.Ordinal))
			{
				m_IssuerSingleton = value;
				OnPropertyChanged("ScenarioPath");
			}
		}
	}

	public RelayCommand SelectCommand
	{
		[CompilerGenerated]
		get
		{
			return m_ClientSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (m_ClientSingleton != value)
			{
				m_ClientSingleton = value;
				OnPropertyChanged("SelectCommand");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _DicSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _DicSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _DicSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _DicSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	protected ScenarioViewModel()
	{
		SelectCommand = new RelayCommand(delegate
		{
			SelectSubroutine();
		});
	}

	public void SelectSubroutine()
	{
		ScenarioSelectControlViewModel.LoadScenarioForm.Label_Title.Visible = true;
		ScenarioSelectControlViewModel.LoadScenarioForm.Label1.Visible = true;
		ScenarioSelectControlViewModel.LoadScenarioForm.PB_Difficulty.Visible = true;
		ScenarioSelectControlViewModel.LoadScenarioForm.Label2.Visible = true;
		ScenarioSelectControlViewModel.LoadScenarioForm.PB_Complexity.Visible = true;
		ScenarioSelectControlViewModel.LoadScenarioForm.Label4.Visible = true;
		ScenarioSelectControlViewModel.LoadScenarioForm.LoadFromPath(ScenarioPath, ScenarioPath);
	}

	public virtual void OnPropertyChanged(string string_0)
	{
		_DicSingleton?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void RunInterruptiblePublisher(object object_0)
	{
		SelectSubroutine();
	}
}
