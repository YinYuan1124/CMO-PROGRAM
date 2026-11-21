using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FixedSizedConcurrentQueue<T>
{
	private ConcurrentQueue<T> annotationClient;

	private object m_IteratorClient;

	internal static object _RoleClient;

	public int Limit { get; set; }

	public FixedSizedConcurrentQueue(int int_0)
	{
		annotationClient = new ConcurrentQueue<T>();
		m_IteratorClient = RuntimeHelpers.GetObjectValue(new object());
		Limit = int_0;
	}

	public void Enqueue(T obj)
	{
		annotationClient.Enqueue(obj);
		object iteratorClient = m_IteratorClient;
		ObjectFlowControl.CheckForSyncLockOnValueType(iteratorClient);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(iteratorClient, ref lockTaken);
			T result;
			while (annotationClient.Count > Limit && annotationClient.TryDequeue(out result))
			{
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(iteratorClient);
			}
		}
	}

	internal static bool TestBridge()
	{
		return _RoleClient == null;
	}
}
