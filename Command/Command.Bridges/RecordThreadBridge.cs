using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VntNet.PowerSchemeSwitcher;

namespace Command.Bridges;

[StandardModule]
internal sealed class RecordThreadBridge
{
	private static Guid taskSchema;

	public static void NewInterruptibleConnection()
	{
		try
		{
			taskSchema = PowerSchemeHelper.GetPowerActiveScheme();
			Dictionary<Guid, PowerPlanInfo> allPowerSchemas = PowerSchemeHelper.GetAllPowerSchemas();
			foreach (KeyValuePair<Guid, PowerPlanInfo> item in allPowerSchemas)
			{
				if (Operators.CompareString(item.Value.FriendlyName.ToUpper(), "高性能", TextCompare: true) == 0 && item.Key != taskSchema)
				{
					PowerSchemeHelper.SetPowerScheme(item.Key);
				}
			}
			foreach (KeyValuePair<Guid, PowerPlanInfo> item2 in allPowerSchemas)
			{
				if (Operators.CompareString(item2.Value.FriendlyName.ToUpper(), "ULTIMATE PERFORMANCE", TextCompare: true) == 0 && item2.Key != taskSchema)
				{
					PowerSchemeHelper.SetPowerScheme(item2.Key);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void PushInterruptibleConnection()
	{
		try
		{
			if (!Information.IsNothing(taskSchema) && PowerSchemeHelper.GetPowerActiveScheme() != taskSchema)
			{
				PowerSchemeHelper.SetPowerScheme(taskSchema);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static bool InvokeInterruptibleConnection()
	{
		if (Environment.OSVersion.Platform == PlatformID.Win32NT)
		{
			if (Environment.OSVersion.Version.Major < 6)
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
