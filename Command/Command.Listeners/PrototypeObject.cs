using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Command.Listeners;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class PrototypeObject
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
				resourceMan = new QResourceManager("CSMaterial.DarkUI.Icons.TreeViewIcons", typeof(PrototypeObject).Assembly);
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

	internal static Bitmap node_closed_empty => (Bitmap)ResourceManager.GetObject("node_closed_empty", resourceCulture);

	internal static Bitmap node_closed_full => (Bitmap)ResourceManager.GetObject("node_closed_full", resourceCulture);

	internal static Bitmap node_open => (Bitmap)ResourceManager.GetObject("node_open", resourceCulture);

	internal static Bitmap node_open_empty => (Bitmap)ResourceManager.GetObject("node_open_empty", resourceCulture);

	internal PrototypeObject()
	{
	}
}
