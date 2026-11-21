using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Command;

public sealed class CustomPanelsEventRaiser
{
	public delegate void CustomPanelStatusChangedEventHandler();

	[CompilerGenerated]
	private static CustomPanelStatusChangedEventHandler m_TokenizerValue;

	public static event CustomPanelStatusChangedEventHandler CustomPanelStatusChanged
	{
		[CompilerGenerated]
		add
		{
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler = m_TokenizerValue;
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler2;
			do
			{
				customPanelStatusChangedEventHandler2 = customPanelStatusChangedEventHandler;
				CustomPanelStatusChangedEventHandler value2 = (CustomPanelStatusChangedEventHandler)Delegate.Combine(customPanelStatusChangedEventHandler2, value);
				customPanelStatusChangedEventHandler = Interlocked.CompareExchange(ref m_TokenizerValue, value2, customPanelStatusChangedEventHandler2);
			}
			while ((object)customPanelStatusChangedEventHandler != customPanelStatusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler = m_TokenizerValue;
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler2;
			do
			{
				customPanelStatusChangedEventHandler2 = customPanelStatusChangedEventHandler;
				CustomPanelStatusChangedEventHandler value2 = (CustomPanelStatusChangedEventHandler)Delegate.Remove(customPanelStatusChangedEventHandler2, value);
				customPanelStatusChangedEventHandler = Interlocked.CompareExchange(ref m_TokenizerValue, value2, customPanelStatusChangedEventHandler2);
			}
			while ((object)customPanelStatusChangedEventHandler != customPanelStatusChangedEventHandler2);
		}
	}

	public static void FireChangeEvent()
	{
		m_TokenizerValue?.Invoke();
	}
}
