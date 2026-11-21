using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class InverseBooleanToVisibilityConverter : IValueConverter
{
	private object StartInitializer(object object_0)
	{
		if (object_0 is bool)
		{
			if (Conversions.ToBoolean(object_0))
			{
				return Visibility.Collapsed;
			}
			return Visibility.Visible;
		}
		return Visibility.Visible;
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return StartInitializer(RuntimeHelpers.GetObjectValue(value));
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
