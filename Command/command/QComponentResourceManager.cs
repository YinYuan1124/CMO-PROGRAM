using System;
using System.Drawing;
using System.Globalization;

namespace Command;

public class QComponentResourceManager
{
	public QComponentResourceManager(Type type)
	{
	}

	public Image GetObject(string name)
	{
		return QResourceHelper.GetImage(name);
	}

	public Icon GetIcon(string name)
	{
		return QResourceHelper.GetIcon(name);
	}

	public string GetString(string name, CultureInfo info = null)
	{
		return QResourceHelper.GetString(name);
	}
}
