using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Command;

public sealed class GClass4 : IValueConverter
{
	private object ChangeConnection(object object_0, Type type_0, object object_1, CultureInfo cultureInfo_0)
	{
		if (object_0 is string s)
		{
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.StreamSource = new MemoryTributary(Convert.FromBase64String(s));
			bitmapImage.EndInit();
			return bitmapImage;
		}
		return null;
	}

	object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return ChangeConnection(value, targetType, parameter, culture);
	}

	private object InitConnection(object object_0, Type type_0, object object_1, CultureInfo cultureInfo_0)
	{
		throw new NotImplementedException();
	}

	object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return InitConnection(value, targetType, parameter, culture);
	}
}
