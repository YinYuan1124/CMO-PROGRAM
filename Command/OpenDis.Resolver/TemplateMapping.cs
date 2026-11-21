using System.Web;
using System.Windows.Forms;

namespace OpenDis.Resolver;

internal class TemplateMapping
{
	private static bool _MappingMapping;

	internal static void smethod_0()
	{
		if (!_MappingMapping)
		{
			_MappingMapping = true;
			try
			{
				MessageBox.Show("This assembly is protected by an unregistered version of \"IntelliLock\"!", "www.eziriz.com");
			}
			catch
			{
				smethod_1("<script language='javascript'>alert( \"This assembly is protected by an unregistered version of IntelliLock!\" );</script>");
			}
		}
	}

	internal static void smethod_1(string txt)
	{
		try
		{
			if (HttpContext.Current != null && HttpContext.Current.Response != null)
			{
				HttpContext.Current.Response.Write(txt);
			}
		}
		catch
		{
		}
	}
}
