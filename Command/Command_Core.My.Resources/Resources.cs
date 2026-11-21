using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Command;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core.My.Resources;

[HideModuleName]
[StandardModule]
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[CompilerGenerated]
internal sealed class Resources
{
	private static QResourceManager resourceManager_0;

	private static object object_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static QResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new QResourceManager("Command_Core.Resources", typeof(Resources).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		set
		{
			object_0 = value;
		}
	}
}
