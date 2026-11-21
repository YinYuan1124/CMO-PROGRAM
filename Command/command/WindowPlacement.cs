using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
public sealed class WindowPlacement
{
	public static Dictionary<string, Tuple<int, int, int, int>> WindowPlacementSettings;

	static WindowPlacement()
	{
		WindowPlacementSettings = new Dictionary<string, Tuple<int, int, int, int>>();
	}

	public static void UpdateWindowPlacementSetting(string string_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (WindowPlacementSettings.ContainsKey(string_0))
		{
			WindowPlacementSettings[string_0] = new Tuple<int, int, int, int>(int_0, int_1, int_2, int_3);
		}
		else
		{
			WindowPlacementSettings.Add(string_0, new Tuple<int, int, int, int>(int_0, int_1, int_2, int_3));
		}
	}

	public static void GetWindowPlacementSetting(CommandSecondaryFormBase commandSecondaryFormBase_0)
	{
		if (WindowPlacementSettings.ContainsKey(commandSecondaryFormBase_0.Name))
		{
			Tuple<int, int, int, int> tuple = WindowPlacementSettings[commandSecondaryFormBase_0.Name];
			if (commandSecondaryFormBase_0.contextRequest)
			{
				commandSecondaryFormBase_0.Location = new Point(tuple.Item1, tuple.Item2);
			}
			if (commandSecondaryFormBase_0.m_StatusRequest)
			{
				if (commandSecondaryFormBase_0.MinimumSize.Width <= tuple.Item3)
				{
					commandSecondaryFormBase_0.Width = tuple.Item3;
				}
				else
				{
					commandSecondaryFormBase_0.Width = commandSecondaryFormBase_0.MinimumSize.Width;
				}
				if (commandSecondaryFormBase_0.MinimumSize.Height <= tuple.Item4)
				{
					commandSecondaryFormBase_0.Height = tuple.Item4;
				}
				else
				{
					commandSecondaryFormBase_0.Height = commandSecondaryFormBase_0.MinimumSize.Height;
				}
			}
			return;
		}
		try
		{
			commandSecondaryFormBase_0.StartPosition = FormStartPosition.WindowsDefaultLocation;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200488", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetWindowPlacementSetting(DarkSecondaryFormBase darkSecondaryFormBase_0)
	{
		if (WindowPlacementSettings.ContainsKey(darkSecondaryFormBase_0.Name))
		{
			Tuple<int, int, int, int> tuple = WindowPlacementSettings[darkSecondaryFormBase_0.Name];
			if (darkSecondaryFormBase_0.tokenValue)
			{
				darkSecondaryFormBase_0.Location = new Point(tuple.Item1, tuple.Item2);
			}
			if (darkSecondaryFormBase_0._IndexerValue)
			{
				if (darkSecondaryFormBase_0.MinimumSize.Width <= tuple.Item3)
				{
					darkSecondaryFormBase_0.Width = tuple.Item3;
				}
				else
				{
					darkSecondaryFormBase_0.Width = darkSecondaryFormBase_0.MinimumSize.Width;
				}
				if (darkSecondaryFormBase_0.MinimumSize.Height <= tuple.Item4)
				{
					darkSecondaryFormBase_0.Height = tuple.Item4;
				}
				else
				{
					darkSecondaryFormBase_0.Height = darkSecondaryFormBase_0.MinimumSize.Height;
				}
			}
			return;
		}
		try
		{
			Point location = default(Point);
			location.X = (int)Math.Round((double)Screen.AllScreens[0].Bounds.Width / 2.0 - (double)darkSecondaryFormBase_0.Width / 2.0);
			location.Y = (int)Math.Round((double)Screen.AllScreens[0].Bounds.Height / 2.0 - (double)darkSecondaryFormBase_0.Height / 2.0);
			darkSecondaryFormBase_0.Location = location;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200488", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
