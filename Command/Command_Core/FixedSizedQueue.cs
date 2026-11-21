using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FixedSizedQueue<T> : Queue
{
	private object m_FactoryClient;

	internal static object eventClient;

	public int Limit { get; set; }

	public FixedSizedQueue(int int_0)
	{
		m_FactoryClient = RuntimeHelpers.GetObjectValue(new object());
		Limit = int_0;
	}

	public override void Enqueue(object obj)
	{
		base.Enqueue(RuntimeHelpers.GetObjectValue(obj));
		if (Count <= Limit)
		{
			return;
		}
		object factoryClient = m_FactoryClient;
		ObjectFlowControl.CheckForSyncLockOnValueType(factoryClient);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(factoryClient, ref lockTaken);
			while (Count > Limit)
			{
				RuntimeHelpers.GetObjectValue(Dequeue());
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(factoryClient);
			}
		}
	}

	internal static bool CancelBridge()
	{
		return eventClient == null;
	}
}
