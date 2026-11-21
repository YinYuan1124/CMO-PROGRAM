using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command
{
	public class QResourceHelper
	{
		public static ConcurrentDictionary<string,Image> imageDic=new ConcurrentDictionary<string, Image>();
		public static ConcurrentDictionary<string, Icon> iconDic = new ConcurrentDictionary<string, Icon>();
		public static ConcurrentDictionary<string,string> stringDic=new ConcurrentDictionary<string, string>();
		public static Image GetImage(string name)
		{
			
			if(imageDic.ContainsKey(name)) return  imageDic[name];
			
			var image= Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", name));
			imageDic.TryAdd(name, image);
			return image;
		}
		public static Icon GetIcon(string name)
		{
			if (iconDic.ContainsKey(name)) return iconDic[name];
			Icon icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", name));
			iconDic.TryAdd(name, icon);
			return icon;
		}
		public static string GetString(string name,CultureInfo info=null)
		{
			if(stringDic.ContainsKey(name)) return stringDic[name];
			var str = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", name));
			str.Trim();
			stringDic.TryAdd(name, str);
			return str;
		}
		public static Image info => GetImage("info");
	}
	public class QComponentResourceManager
	{
		public QComponentResourceManager(Type type) { }

		public Image GetObject(string name)
		{
			return QResourceHelper.GetImage(name);
		}

		public Icon GetIcon(string name)
		{
			return QResourceHelper.GetIcon(name);
		}
		public string GetString(string name,CultureInfo info=null)
		{
			return QResourceHelper.GetString(name);
		}

		
	}

	public class QResourceManager
	{

		public QResourceManager(Type type) { }
		public QResourceManager(string name ,Assembly assembly) { }

		public string GetString(string name,CultureInfo info = null)
		{

			return QResourceHelper.GetString(name,info);

		}
		public Image GetObject(string name,CultureInfo info)
		{
			return QResourceHelper.GetImage(name);
		}
		public ImageListStreamer GetImageListStreamer(string name, CultureInfo info = null)
		{
			var res = new ImageList();

			

			return res.ImageStream;

			
		}

	}


}
