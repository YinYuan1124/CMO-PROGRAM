using System.Collections.Generic;
using System.Windows.Forms;
using Command.My.Resources;

namespace Command;

public sealed class CustomCursor
{
	private static CustomCursor m_RepositoryValue;

	public Dictionary<CursorType, Cursor> Cursors;

	static CustomCursor()
	{
		m_RepositoryValue = null;
	}

	private CustomCursor()
	{
		Cursors = new Dictionary<CursorType, Cursor>();
		Cursors.Add(CursorType.RedCrossHair, new Cursor(Resources.CrossHairRedCursor_32.GetHicon()));
		Cursors.Add(CursorType.Radar, new Cursor(Resources.Radar32.GetHicon()));
		Cursors.Add(CursorType.Refuel, new Cursor(Resources.RefuelCursor32.GetHicon()));
		Cursors.Add(CursorType.Rebase, new Cursor(Resources.Rebase32.GetHicon()));
		Cursors.Add(CursorType.RTB, new Cursor(Resources.RTB32.GetHicon()));
		Cursors.Add(CursorType.Escort, new Cursor(Resources.Escort32.GetHicon()));
	}

	public static CustomCursor GetInstance()
	{
		if (m_RepositoryValue == null)
		{
			m_RepositoryValue = new CustomCursor();
		}
		return m_RepositoryValue;
	}

	public static Cursor GetCursor(CursorType cursorType_0)
	{
		return GetInstance().Cursors[cursorType_0];
	}
}
