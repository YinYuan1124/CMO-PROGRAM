using System;
using System.Runtime.CompilerServices;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class RightColumnPhony
{
	public DoctrineControlPhony DoctrineControl1;

	public EmconControlPhony EmconControl1;

	[CompilerGenerated]
	private bool m_ValuePredicate;

	public bool UpdateData
	{
		[CompilerGenerated]
		get
		{
			return m_ValuePredicate;
		}
		[CompilerGenerated]
		set
		{
			m_ValuePredicate = value;
		}
	}

	public RightColumnPhony()
	{
		UpdateData = true;
		DoctrineControl1 = new DoctrineControlPhony();
		EmconControl1 = new EmconControlPhony();
	}

	public void RefreshPanels(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0, bool bool_0)
	{
		if (unit_0 != null)
		{
			Refresh();
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			ReleaseReferencesInternal();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal void AddInterruptibleIndexer(Module_Unit.Unit unit_0, Module_Unit.Unit unit_1)
	{
		if (unit_0 != null)
		{
			Refresh();
		}
	}

	public static void Refresh()
	{
		if (Client.CurrentSide != null && Client.SelectedUnit != null)
		{
			((RightColumnWPF)Client.theElementHostRightColumn.Child).RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	public static void ReleaseReferencesInternal()
	{
		((RightColumnWPF)Client.theElementHostRightColumn.Child).ReleaseReferences();
	}
}
