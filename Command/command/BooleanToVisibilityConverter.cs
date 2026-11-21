using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class BooleanToVisibilityConverter : IValueConverter
{
	private object MoveContext(object object_0)
	{
		if (object_0 is bool)
		{
			if (Conversions.ToBoolean(object_0))
			{
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}
		return Visibility.Collapsed;
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return MoveContext(RuntimeHelpers.GetObjectValue(value));
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
