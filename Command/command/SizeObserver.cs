using System;
using System.Windows;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
[StandardModule]
internal sealed class SizeObserver
{
	[DoNotPrune]
	public static readonly DependencyProperty _WorkerSingleton;

	[DoNotPrune]
	public static readonly DependencyProperty _AccountSingleton;

	[DoNotPrune]
	public static readonly DependencyProperty m_StateSingleton;

	static SizeObserver()
	{
		_WorkerSingleton = DependencyProperty.RegisterAttached("Observe", typeof(bool), typeof(SizeObserver), new FrameworkPropertyMetadata(new Action<FrameworkElement, DependencyPropertyChangedEventArgs>(LoginInterruptibleSchema)));
		_AccountSingleton = DependencyProperty.RegisterAttached("ObservedWidth", typeof(double), typeof(SizeObserver));
		m_StateSingleton = DependencyProperty.RegisterAttached("ObservedHeight", typeof(double), typeof(SizeObserver));
	}

	[DoNotPrune]
	public static bool PatchInterruptibleSchema(DependencyObject dependencyObject_0)
	{
		return Conversions.ToBoolean(dependencyObject_0.GetValue(_WorkerSingleton));
	}

	[DoNotPrune]
	public static void SelectInterruptibleSchema(DependencyObject dependencyObject_0, bool bool_0)
	{
		dependencyObject_0.SetValue(_WorkerSingleton, bool_0);
	}

	[DoNotPrune]
	public static double CallInterruptibleSchema(DependencyObject dependencyObject_0)
	{
		return Conversions.ToDouble(dependencyObject_0.GetValue(_AccountSingleton));
	}

	[DoNotPrune]
	public static void LogoutInterruptibleSchema(DependencyObject dependencyObject_0, double double_0)
	{
		dependencyObject_0.SetValue(_AccountSingleton, double_0);
	}

	[DoNotPrune]
	public static double ViewInterruptibleSchema(DependencyObject dependencyObject_0)
	{
		return Conversions.ToDouble(dependencyObject_0.GetValue(m_StateSingleton));
	}

	[DoNotPrune]
	public static void ValidateInterruptibleSchema(DependencyObject dependencyObject_0, double double_0)
	{
		dependencyObject_0.SetValue(m_StateSingleton, double_0);
	}

	[DoNotPrune]
	private static void LoginInterruptibleSchema(FrameworkElement frameworkElement_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (Conversions.ToBoolean(dependencyPropertyChangedEventArgs_0.NewValue))
		{
			frameworkElement_0.SizeChanged += GetInterruptibleSchema;
			WriteInterruptibleSchema(frameworkElement_0);
		}
		else
		{
			frameworkElement_0.SizeChanged += GetInterruptibleSchema;
		}
	}

	[DoNotPrune]
	private static void GetInterruptibleSchema(FrameworkElement frameworkElement_0, object object_0)
	{
		WriteInterruptibleSchema(frameworkElement_0);
	}

	[DoNotPrune]
	private static void GetInterruptibleSchema(object sender, SizeChangedEventArgs e)
	{
		WriteInterruptibleSchema((FrameworkElement)sender);
	}

	[DoNotPrune]
	private static void WriteInterruptibleSchema(object object_0)
	{
		((DependencyObject)object_0).SetCurrentValue(_AccountSingleton, ((FrameworkElement)object_0).ActualWidth);
		((DependencyObject)object_0).SetCurrentValue(m_StateSingleton, ((FrameworkElement)object_0).ActualHeight);
	}
}
