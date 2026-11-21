using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;

namespace Command;

public sealed class RelayCommand : ICommand
{
	private readonly Action<object> expressionPredicate;

	private readonly Predicate<object> dispatcherPredicate;

	[CompilerGenerated]
	private EventHandler m_ListenerPredicate;

	event EventHandler ICommand.CanExecuteChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_ListenerPredicate;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_ListenerPredicate, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_ListenerPredicate;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_ListenerPredicate, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler CanExecuteChanged
	{
		add
		{
			CommandManager.RequerySuggested += value;
		}
		remove
		{
			CommandManager.RequerySuggested -= value;
		}
	}

	public RelayCommand(Action<object> action_0)
		: this(action_0, null)
	{
	}

	public RelayCommand(Action<object> action_0, Predicate<object> predicate_0)
	{
		if (action_0 == null)
		{
			throw new ArgumentNullException("execute");
		}
		expressionPredicate = action_0;
		dispatcherPredicate = predicate_0;
	}

	[DebuggerStepThrough]
	public bool CanExecute(object parameter)
	{
		if (dispatcherPredicate == null)
		{
			return true;
		}
		return dispatcherPredicate(RuntimeHelpers.GetObjectValue(parameter));
	}

	[SpecialName]
	private void raise_CanExecuteChanged(object sender, EventArgs e)
	{
		if (dispatcherPredicate != null)
		{
			dispatcherPredicate(RuntimeHelpers.GetObjectValue(sender));
		}
	}

	public void Execute(object parameter)
	{
		expressionPredicate(RuntimeHelpers.GetObjectValue(parameter));
	}
}
