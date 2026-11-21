using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Command;

public class QResourceManager
{
	public QResourceManager(Type type)
	{
	}

	public QResourceManager(string name, Assembly assembly)
	{
	}

	public string GetString(string name, CultureInfo info = null)
	{
		return QResourceHelper.GetString(name, info);
	}

	public Image GetObject(string name, CultureInfo info)
	{
		return QResourceHelper.GetImage(name);
	}

	public ImageListStreamer GetImageListStreamer(string name, CultureInfo info = null)
	{
		ImageList res = new ImageList();
		return res.ImageStream;
	}
}
