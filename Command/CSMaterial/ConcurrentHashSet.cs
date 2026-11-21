using System;
using System.Collections.Generic;
using System.Threading;

namespace CSMaterial;

public sealed class ConcurrentHashSet<T> : IDisposable
{
	private readonly ReaderWriterLockSlim objectDispatcher = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

	private readonly HashSet<T> parameterDispatcher = new HashSet<T>();

	private static object m_ExpressionDispatcher;

	public int Count
	{
		get
		{
			try
			{
				objectDispatcher.EnterReadLock();
				return parameterDispatcher.Count;
			}
			finally
			{
				if (objectDispatcher.IsReadLockHeld)
				{
					objectDispatcher.ExitReadLock();
				}
			}
		}
	}

	public bool Add(T item)
	{
		try
		{
			objectDispatcher.EnterWriteLock();
			return parameterDispatcher.Add(item);
		}
		finally
		{
			if (objectDispatcher.IsWriteLockHeld)
			{
				objectDispatcher.ExitWriteLock();
			}
		}
	}

	public void Clear()
	{
		try
		{
			objectDispatcher.EnterWriteLock();
			parameterDispatcher.Clear();
		}
		finally
		{
			if (objectDispatcher.IsWriteLockHeld)
			{
				objectDispatcher.ExitWriteLock();
			}
		}
	}

	public bool Contains(T item)
	{
		try
		{
			objectDispatcher.EnterReadLock();
			return parameterDispatcher.Contains(item);
		}
		finally
		{
			if (objectDispatcher.IsReadLockHeld)
			{
				objectDispatcher.ExitReadLock();
			}
		}
	}

	public bool Remove(T item)
	{
		try
		{
			objectDispatcher.EnterWriteLock();
			return parameterDispatcher.Remove(item);
		}
		finally
		{
			if (objectDispatcher.IsWriteLockHeld)
			{
				objectDispatcher.ExitWriteLock();
			}
		}
	}

	public void Dispose()
	{
		if (objectDispatcher != null)
		{
			objectDispatcher.Dispose();
		}
	}

	internal static bool IncludeDefinition()
	{
		return m_ExpressionDispatcher == null;
	}
}
