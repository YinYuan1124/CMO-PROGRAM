using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using Command;

namespace OpenDis.Database;

[CompilerGenerated]
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
internal class RequestDecoratorEntry
{
	private static QResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static QResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new QResourceManager("CSMaterial.DarkUI.Icons.DockIcons", typeof(RequestDecoratorEntry).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap active_inactive_close => (Bitmap)ResourceManager.GetObject("active_inactive_close", resourceCulture);

	internal static Bitmap arrow => (Bitmap)ResourceManager.GetObject("arrow", resourceCulture);

	internal static Bitmap close => (Bitmap)ResourceManager.GetObject("close", resourceCulture);

	internal static Bitmap close_selected => (Bitmap)ResourceManager.GetObject("close_selected", resourceCulture);

	internal static Bitmap inactive_close => (Bitmap)ResourceManager.GetObject("inactive_close", resourceCulture);

	internal static Bitmap inactive_close_selected => (Bitmap)ResourceManager.GetObject("inactive_close_selected", resourceCulture);

	internal static Bitmap tw_active_close => (Bitmap)ResourceManager.GetObject("tw_active_close", resourceCulture);

	internal static Bitmap tw_active_close_selected => (Bitmap)ResourceManager.GetObject("tw_active_close_selected", resourceCulture);

	internal static Bitmap tw_close => (Bitmap)ResourceManager.GetObject("tw_close", resourceCulture);

	internal static Bitmap tw_close_selected => (Bitmap)ResourceManager.GetObject("tw_close_selected", resourceCulture);

	internal RequestDecoratorEntry()
	{
	}
}
