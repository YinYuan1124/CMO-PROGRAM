using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Command.Lists;

[CompilerGenerated]
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
internal class VisitorObject
{
	private static QResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static QResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new QResourceManager("CSMaterial.DarkUI.Icons.DropdownIcons", typeof(VisitorObject).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal static Bitmap small_arrow => (Bitmap)ResourceManager.GetObject("small_arrow", cultureInfo_0);

	internal VisitorObject()
	{
	}
}
