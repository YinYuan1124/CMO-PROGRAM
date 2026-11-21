using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Command;

namespace DotSpatial.Serialization.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
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
				resourceMan = new QResourceManager("DotSpatial.Serialization.Properties.Resources", typeof(Resources).Assembly);
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

	internal static string ReadOnly => ResourceManager.GetString("ReadOnly", resourceCulture);

	internal Resources()
	{
	}
}
