using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using Command;

namespace OpenDis.Resolver;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
internal class ParserProcessResolver
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
				resourceMan = new QResourceManager("CSMaterial.DarkUI.Icons.MessageBoxIcons", typeof(ParserProcessResolver).Assembly);
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

	internal static Bitmap error => (Bitmap)ResourceManager.GetObject("error", resourceCulture);

	internal static Bitmap info => (Bitmap)ResourceManager.GetObject("info", resourceCulture);

	internal static Bitmap warning => (Bitmap)ResourceManager.GetObject("warning", resourceCulture);

	internal ParserProcessResolver()
	{
	}
}
