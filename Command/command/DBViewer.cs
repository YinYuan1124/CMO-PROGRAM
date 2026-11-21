using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class DBViewer
{
	private static object collectionTokenizer;

	static DBViewer()
	{
		collectionTokenizer = RuntimeHelpers.GetObjectValue(new object());
	}

	public static void OpenNewDatabaseWindow()
	{
		OpenNewDatabaseWindow(null, 0);
	}

	public static void OpenNewDatabaseWindow(string string_0, int int_0, string string_1 = null)
	{
		object obj = collectionTokenizer;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			InternalDBViewer internalDBViewer = new InternalDBViewer();
			internalDBViewer.SelectedObjectType = string_0;
			internalDBViewer.selectedSubType = -1;
			internalDBViewer.SelectedObjectID = int_0;
			internalDBViewer.HighlightTarget = string_1;
			internalDBViewer.Show();
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private static void InitServer()
	{
	}
}
