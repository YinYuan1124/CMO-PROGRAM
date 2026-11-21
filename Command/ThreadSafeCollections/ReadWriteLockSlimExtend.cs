using System;
using System.Threading;

namespace ThreadSafeCollections;

public static class ReadWriteLockSlimExtend
{
	public static void PerformUsingReadLock(this ReaderWriterLockSlim readerWriterLockSlim_0, Action action_0)
	{
		try
		{
			readerWriterLockSlim_0.EnterReadLock();
			action_0();
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public static T PerformUsingReadLock<T>(this ReaderWriterLockSlim readerWriterLockSlim_0, Func<T> func_0)
	{
		try
		{
			readerWriterLockSlim_0.EnterReadLock();
			return func_0();
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public static void PerformUsingWriteLock(this ReaderWriterLockSlim readerWriterLockSlim_0, Action action_0)
	{
		try
		{
			readerWriterLockSlim_0.EnterWriteLock();
			action_0();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public static T PerformUsingWriteLock<T>(this ReaderWriterLockSlim readerWriterLockSlim_0, Func<T> func_0)
	{
		try
		{
			readerWriterLockSlim_0.EnterWriteLock();
			return func_0();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public static void PerformUsingUpgradeableReadLock(this ReaderWriterLockSlim readerWriterLockSlim_0, Action action_0)
	{
		try
		{
			readerWriterLockSlim_0.EnterUpgradeableReadLock();
			action_0();
		}
		finally
		{
			readerWriterLockSlim_0.ExitUpgradeableReadLock();
		}
	}

	public static T PerformUsingUpgradeableReadLock<T>(this ReaderWriterLockSlim readerWriterLockSlim_0, Func<T> func_0)
	{
		try
		{
			readerWriterLockSlim_0.EnterUpgradeableReadLock();
			return func_0();
		}
		finally
		{
			readerWriterLockSlim_0.ExitUpgradeableReadLock();
		}
	}
}
