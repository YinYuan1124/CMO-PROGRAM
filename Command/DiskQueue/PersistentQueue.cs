using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using OpenDis.Services;

namespace DiskQueue;

public sealed class PersistentQueue : IDisposable, IPersistentQueue
{
	private TaskObject _RequestObject;

	public int EstimatedCountOfItemsInQueue => _RequestObject.RestartDispatcher();

	public GInterface7 Internals => _RequestObject;

	public int MaxFileSize => _RequestObject.StopDispatcher();

	public long SuggestedMaxTransactionLogSize
	{
		get
		{
			return _RequestObject.PrepareDispatcher();
		}
		set
		{
			_RequestObject.ReflectDispatcher(value);
		}
	}

	public bool TrimTransactionLogOnDispose
	{
		get
		{
			return _RequestObject.TrimTransactionLogOnDispose;
		}
		set
		{
			_RequestObject.TrimTransactionLogOnDispose = value;
		}
	}

	public static IPersistentQueue WaitFor(string string_0, TimeSpan timeSpan_0)
	{
		Stopwatch stopwatch = new Stopwatch();
		try
		{
			stopwatch.Start();
			do
			{
				try
				{
					return new PersistentQueue(string_0);
				}
				catch (DirectoryNotFoundException)
				{
					throw new Exception("Target storagePath does not exist or is not accessible");
				}
				catch (PlatformNotSupportedException ex2)
				{
					Console.WriteLine("Blocked by " + ex2.GetType().Name + "; " + ex2.Message + "\r\n\r\n" + ex2.StackTrace);
					throw;
				}
				catch
				{
					Thread.Sleep(50);
				}
			}
			while (stopwatch.Elapsed < timeSpan_0);
		}
		finally
		{
			stopwatch.Stop();
		}
		throw new TimeoutException("Could not aquire a lock in the time specified");
	}

	public PersistentQueue(string string_0)
	{
		_RequestObject = new TaskObject(string_0);
	}

	public PersistentQueue(string string_0, int int_0)
	{
		_RequestObject = new TaskObject(string_0, int_0);
	}

	public void Dispose()
	{
		TaskObject taskObject = Interlocked.Exchange(ref _RequestObject, null);
		if (taskObject != null)
		{
			taskObject.Dispose();
			GC.SuppressFinalize(this);
		}
	}

	~PersistentQueue()
	{
		if (_RequestObject != null)
		{
			Dispose();
		}
	}

	public IPersistentQueueSession OpenSession()
	{
		if (_RequestObject == null)
		{
			throw new Exception("This queue has been disposed");
		}
		return _RequestObject.ExcludeDispatcher();
	}
}
