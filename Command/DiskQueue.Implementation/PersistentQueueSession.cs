using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DiskQueue.Implementation;

public sealed class PersistentQueueSession : IDisposable, IPersistentQueueSession
{
	[CompilerGenerated]
	private sealed class PrinterMerchantService
	{
		public Stream stream;

		public PersistentQueueSession _003C_003E4__this;

		public ManualResetEvent manualResetEvent_0;

		internal void ValidateInterruptibleMock(IAsyncResult ar)
		{
			try
			{
				stream.EndWrite(ar);
			}
			catch (Exception item)
			{
				lock (_003C_003E4__this._ConfigurationObject)
				{
					_003C_003E4__this._ConfigurationObject.Add(item);
				}
			}
			finally
			{
				manualResetEvent_0.Set();
			}
		}
	}

	private readonly List<Operation> strategyObject = new List<Operation>();

	private readonly IList<Exception> _ConfigurationObject = new List<Exception>();

	private readonly IList<WaitHandle> tokenObject = new List<WaitHandle>();

	private Stream _IndexerObject;

	private readonly int m_ResolverObject;

	private readonly GInterface7 _PublisherObject;

	private readonly List<Stream> serverObject = new List<Stream>();

	private static readonly object _AdapterObject;

	private volatile bool _SchemaObject;

	private readonly List<byte[]> m_UtilsObject = new List<byte[]>();

	private int m_PredicateObject;

	public PersistentQueueSession(GInterface7 ginterface7_0, Stream stream_0, int int_0)
	{
		lock (_AdapterObject)
		{
			_PublisherObject = ginterface7_0;
			_IndexerObject = stream_0;
			if (int_0 < 65536)
			{
				int_0 = 65536;
			}
			m_ResolverObject = int_0;
			_SchemaObject = false;
		}
	}

	public void Enqueue(byte[] byte_0)
	{
		m_UtilsObject.Add(byte_0);
		m_PredicateObject += byte_0.Length;
		if (m_PredicateObject > m_ResolverObject)
		{
			StartDispatcher();
		}
	}

	private void StartDispatcher()
	{
		_PublisherObject.AcquireWriter(_IndexerObject, PrintDispatcher, PublishDispatcher);
	}

	private void AssetDispatcher()
	{
		_PublisherObject.AcquireWriter(_IndexerObject, delegate(Stream stream_0)
		{
			byte[] array = DefineDispatcher(stream_0);
			stream_0.Write(array, 0, array.Length);
			return stream_0.Position;
		}, PublishDispatcher);
	}

	private long PrintDispatcher(Stream stream_0)
	{
		byte[] array = DefineDispatcher(stream_0);
		ManualResetEvent manualResetEvent_0 = new ManualResetEvent(initialState: false);
		tokenObject.Add(manualResetEvent_0);
		long result = stream_0.Position + array.Length;
		stream_0.BeginWrite(array, 0, array.Length, delegate(IAsyncResult ar)
		{
			try
			{
				stream_0.EndWrite(ar);
			}
			catch (Exception item)
			{
				lock (_ConfigurationObject)
				{
					_ConfigurationObject.Add(item);
				}
			}
			finally
			{
				manualResetEvent_0.Set();
			}
		}, null);
		return result;
	}

	private byte[] DefineDispatcher(Stream stream_0)
	{
		byte[] array = new byte[m_PredicateObject];
		int num = (int)stream_0.Position;
		int num2 = 0;
		foreach (byte[] item in m_UtilsObject)
		{
			strategyObject.Add(new Operation(OperationType.Enqueue, _PublisherObject.CurrentFileNumber, num, item.Length));
			Buffer.BlockCopy(item, 0, array, num2, item.Length);
			num += item.Length;
			num2 += item.Length;
		}
		m_PredicateObject = 0;
		m_UtilsObject.Clear();
		return array;
	}

	private void PublishDispatcher(Stream stream_0)
	{
		serverObject.Add(_IndexerObject);
		_IndexerObject = stream_0;
	}

	public byte[] Dequeue()
	{
		Entry entry = _PublisherObject.Dequeue();
		if (entry == null)
		{
			return null;
		}
		strategyObject.Add(new Operation(OperationType.Dequeue, entry.FileNumber, entry.Start, entry.Length));
		return entry.Data;
	}

	public void Flush()
	{
		try
		{
			AwakeDispatcher();
			AssetDispatcher();
		}
		finally
		{
			foreach (Stream item in serverObject)
			{
				item.Flush();
				item.Dispose();
			}
			serverObject.Clear();
		}
		_IndexerObject.Flush();
		_PublisherObject.CommitTransaction(strategyObject);
		strategyObject.Clear();
	}

	private void AwakeDispatcher()
	{
		while (tokenObject.Count != 0)
		{
			WaitHandle[] array = tokenObject.Take(64).ToArray();
			WaitHandle[] array2 = array;
			WaitHandle[] array3 = array2;
			WaitHandle[] array4 = array3;
			foreach (WaitHandle item in array4)
			{
				tokenObject.Remove(item);
			}
			WaitHandle.WaitAll(array);
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Close();
			}
			QueryDispatcher();
		}
	}

	private void QueryDispatcher()
	{
		lock (_ConfigurationObject)
		{
			if (_ConfigurationObject.Count != 0)
			{
				Exception[] exception_ = _ConfigurationObject.ToArray();
				_ConfigurationObject.Clear();
				throw new PendingWriteException(exception_);
			}
		}
	}

	public void Dispose()
	{
		lock (_AdapterObject)
		{
			if (_SchemaObject)
			{
				return;
			}
			_SchemaObject = true;
			_PublisherObject.Reinstate(strategyObject);
			strategyObject.Clear();
			foreach (Stream item in serverObject)
			{
				item.Dispose();
			}
			_IndexerObject.Dispose();
			GC.SuppressFinalize(this);
		}
		Thread.Sleep(0);
	}

	~PersistentQueueSession()
	{
		if (!_SchemaObject)
		{
			Dispose();
		}
	}

	static PersistentQueueSession()
	{
		_AdapterObject = new object();
	}

	[CompilerGenerated]
	private long ResetDispatcher(Stream stream_0)
	{
		byte[] array = DefineDispatcher(stream_0);
		stream_0.Write(array, 0, array.Length);
		return stream_0.Position;
	}
}
