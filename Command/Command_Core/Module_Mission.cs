using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Module_Mission
{
	[CompilerGenerated]
	private sealed class PolicyConfigObject
	{
		public Mission theMission;

		public TList<ActiveUnit> tList;

		internal void RestartInterruptibleQueue(ActiveUnit theAU)
		{
			if (theAU != null)
			{
				if (theAU.AssignedMissionOrPackage() == theMission)
				{
					tList.Add(theAU);
				}
				else if (theAU.AllowMultiMission && theAU.AssignedMissionsQueue.Keys.Contains(theMission))
				{
					tList.Add(theAU);
				}
			}
		}
	}

	internal static List<ActiveUnit> AssetTokenizer(Mission mission_0, Scenario scenario_0)
	{
		if (mission_0 == null)
		{
			return new List<ActiveUnit>();
		}
		if (scenario_0 == null)
		{
			return new List<ActiveUnit>();
		}
		try
		{
			if (scenario_0.ActiveUnits_List == null)
			{
				return new List<ActiveUnit>();
			}
			List<ActiveUnit> source = scenario_0.ActiveUnits_List.ToList();
			TList<ActiveUnit> tList = new TList<ActiveUnit>();
			Parallel.ForEach(source, delegate(ActiveUnit theAU)
			{
				if (theAU != null)
				{
					if (theAU.AssignedMissionOrPackage() == mission_0)
					{
						tList.Add(theAU);
					}
					else if (theAU.AllowMultiMission && theAU.AssignedMissionsQueue.Keys.Contains(mission_0))
					{
						tList.Add(theAU);
					}
				}
			});
			return tList.ToList();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 100642", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
