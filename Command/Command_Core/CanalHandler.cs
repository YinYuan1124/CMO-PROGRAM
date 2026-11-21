using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class CanalHandler
{
	private static Canal_Panama _ServerObserver;

	private static Canal_Suez m_AdapterObserver;

	private static Canal_Dardanelles schemaObserver;

	private static Canal_Bosphorus m_UtilsObserver;

	internal static Canal_Panama InsertProperty()
	{
		if (Information.IsNothing(_ServerObserver))
		{
			_ServerObserver = new Canal_Panama();
		}
		return _ServerObserver;
	}

	internal static Canal_Suez PrepareProperty()
	{
		if (Information.IsNothing(m_AdapterObserver))
		{
			m_AdapterObserver = new Canal_Suez();
		}
		return m_AdapterObserver;
	}

	internal static Canal_Dardanelles ReflectProperty()
	{
		if (Information.IsNothing(schemaObserver))
		{
			schemaObserver = new Canal_Dardanelles();
		}
		return schemaObserver;
	}

	internal static Canal_Bosphorus VisitProperty()
	{
		if (Information.IsNothing(m_UtilsObserver))
		{
			m_UtilsObserver = new Canal_Bosphorus();
		}
		return m_UtilsObserver;
	}
}
