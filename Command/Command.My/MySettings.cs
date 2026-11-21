using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Command.Messages;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.My;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
[CompilerGenerated]
internal sealed class MySettings : ApplicationSettingsBase
{
	private static MySettings mySettings_0;

	private static bool bool_0;

	private static object object_0;

	public static MySettings Default
	{
		get
		{
			if (!bool_0)
			{
				object obj = object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (!bool_0)
					{
						ItemExporter.RevertInterruptibleMap.Shutdown += delegate
						{
							if (ItemExporter.RevertInterruptibleMap.SaveMySettingsOnExit)
							{
								MySettingsProperty.Settings.Save();
							}
						};
						bool_0 = true;
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			return mySettings_0;
		}
	}

	static MySettings()
	{
		mySettings_0 = (MySettings)SettingsBase.Synchronized(new MySettings());
		object_0 = RuntimeHelpers.GetObjectValue(new object());
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	private static void SaveSettings(object sender, EventArgs e)
	{
		if (ItemExporter.RevertInterruptibleMap.SaveMySettingsOnExit)
		{
			MySettingsProperty.Settings.Save();
		}
	}
}
