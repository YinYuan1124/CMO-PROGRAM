using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using Command;

namespace DarkUI;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public sealed class MenuIcons
{
	private static QResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static QResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new QResourceManager("CSMaterial.DarkUI.Icons.MenuIcons", typeof(MenuIcons).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	public static Bitmap grip => (Bitmap)ResourceManager.GetObject("grip", resourceCulture);

	public static Bitmap tick => (Bitmap)ResourceManager.GetObject("tick", resourceCulture);

	internal MenuIcons()
	{
	}
}
