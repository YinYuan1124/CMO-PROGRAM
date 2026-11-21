using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic.CompilerServices;

namespace OpenDis.Database;

[StandardModule]
internal sealed class StubDecoratorEntry
{
	public static BitmapImage RemoveInterruptibleMap(Image image_0)
	{
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		image_0.Save(memoryStream, ImageFormat.Png);
		memoryStream.Position = 0L;
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.StreamSource = memoryStream;
		bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
		bitmapImage.EndInit();
		return bitmapImage;
	}

	public static BitmapImage FindInterruptibleMap(string string_0)
	{
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.StreamSource = new MemoryTributary(Convert.FromBase64String(string_0));
		bitmapImage.EndInit();
		return bitmapImage;
	}
}
