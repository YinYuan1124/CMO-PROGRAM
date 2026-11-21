using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace Command;

public class QResourceHelper
{
	public static ConcurrentDictionary<string, Image> imageDic = new ConcurrentDictionary<string, Image>();

	public static ConcurrentDictionary<string, Icon> iconDic = new ConcurrentDictionary<string, Icon>();

	public static ConcurrentDictionary<string, string> stringDic = new ConcurrentDictionary<string, string>();

	public static Image info => GetImage("info");

	public static Image GetImage(string name)
	{
		if (imageDic.ContainsKey(name))
		{
			return imageDic[name];
		}
		Image image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", name));
		imageDic.TryAdd(name, image);
		return image;
	}

	public static Icon GetIcon(string name)
	{
		if (iconDic.ContainsKey(name))
		{
			return iconDic[name];
		}
		Icon icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", name));
		iconDic.TryAdd(name, icon);
		return icon;
	}

	public static string GetString(string name, CultureInfo info = null)
	{
		if (stringDic.ContainsKey(name))
		{
			return stringDic[name];
		}
		string str = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", name));
		str.Trim();
		stringDic.TryAdd(name, str);
		return str;
	}
}
