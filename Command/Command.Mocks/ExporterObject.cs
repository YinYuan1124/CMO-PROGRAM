using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Command.Mocks;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[CompilerGenerated]
[DebuggerNonUserCode]
internal class ExporterObject
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
				resourceMan = new QResourceManager("CSMaterial.DarkUI.Icons.ScrollIcons", typeof(ExporterObject).Assembly);
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

	internal static Bitmap scrollbar_arrow => (Bitmap)ResourceManager.GetObject("scrollbar_arrow", resourceCulture);

	internal static Bitmap scrollbar_arrow_clicked => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_clicked", resourceCulture);

	internal static Bitmap scrollbar_arrow_disabled => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_disabled", resourceCulture);

	internal static Bitmap scrollbar_arrow_hot => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_hot", resourceCulture);

	internal static Bitmap scrollbar_arrow_standard => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_standard", resourceCulture);

	internal ExporterObject()
	{
	}
}
