using System.Collections.Generic;

namespace Command;

public sealed class GlobalSingleton
{
	private static GlobalSingleton m_ServiceTests;

	private List<InternalDBViewer> m_SystemTests;

	public List<Notification> NotificationContainer;

	static GlobalSingleton()
	{
		m_ServiceTests = null;
	}

	private GlobalSingleton()
	{
		m_SystemTests = new List<InternalDBViewer>();
		NotificationContainer = new List<Notification>();
	}

	public void method_0(InternalDBViewer internalDBViewer_0)
	{
		m_SystemTests.Add(internalDBViewer_0);
	}

	public InternalDBViewer GetLastOpenedDBViewer()
	{
		for (int i = m_SystemTests.Count - 1; i >= 0; i += -1)
		{
			if (m_SystemTests[i] == null || m_SystemTests[i]._IsDisposed)
			{
				m_SystemTests.RemoveAt(i);
			}
		}
		if (m_SystemTests.Count == 0)
		{
			return null;
		}
		return m_SystemTests[m_SystemTests.Count - 1];
	}

	public static GlobalSingleton GetInstance()
	{
		if (m_ServiceTests == null)
		{
			m_ServiceTests = new GlobalSingleton();
		}
		return m_ServiceTests;
	}
}
