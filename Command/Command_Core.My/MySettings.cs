using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Command_Core.My;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
[CompilerGenerated]
internal sealed class MySettings : ApplicationSettingsBase
{
	private static MySettings mySettings_0;

	public static MySettings Default => mySettings_0;

	static MySettings()
	{
		mySettings_0 = (MySettings)SettingsBase.Synchronized(new MySettings());
	}
}
