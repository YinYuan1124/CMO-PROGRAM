using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using DiskQueue;
using DiskQueue.Implementation;

namespace OpenDis.Services;

internal class TaskObject : IDisposable, GInterface7
{
	[CompilerGenerated]
	private sealed class ParameterProcessProducer
	{
		public bool bool_0;

		public bool bool_1;

		public TaskObject _003C_003E4__this;

		public Action _003C_003E9__1;

		internal void CallInterruptibleMock(Stream stream)
		{
			using BinaryReader binaryReader = new BinaryReader(stream);
			bool_0 = false;
			try
			{
				int num = 0;
				while (true)
				{
					num++;
					CheckDispatcher(binaryReader, num, Constants.StartTransactionSeparatorGuid, delegate
					{
						bool_0 = true;
					});
					int num2 = binaryReader.ReadInt32();
					List<Operation> list = new List<Operation>(num2);
					for (int i = 0; i < num2; i++)
					{
						ChangeDispatcher(binaryReader);
						Operation operation = new Operation((OperationType)binaryReader.ReadByte(), binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32());
						list.Add(operation);
						if (operation.Type != OperationType.Enqueue)
						{
							bool_1 = true;
						}
					}
					CheckDispatcher(binaryReader, num, Constants.EndTransactionSeparatorGuid, delegate
					{
					});
					bool_0 = false;
					_003C_003E4__this.RemoveDispatcher(list);
				}
			}
			catch (EndOfStreamException)
			{
				if (bool_0)
				{
					bool_1 = true;
				}
			}
		}

		internal void LogoutInterruptibleMock()
		{
			bool_0 = true;
		}
	}

	[CompilerGenerated]
	private sealed class ObserverParameterMessage
	{
		public byte[] byte_0;

		internal void ViewInterruptibleMock(Stream stream)
		{
			stream.SetLength(byte_0.Length);
			stream.Write(byte_0, 0, byte_0.Length);
		}
	}

	private readonly HashSet<Entry> m_FilterObject = new HashSet<Entry>();

	private readonly Dictionary<int, int> testsObject = new Dictionary<int, int>();

	private readonly LinkedList<Entry> _InterpreterObject = new LinkedList<Entry>();

	private readonly string path;

	private readonly object m_ContainerObject = new object();

	private readonly object _ComposerObject = new object();

	private static readonly object _ModelObject;

	private object m_AdvisorObject;

	private FileStream _CustomerObject;

	[CompilerGenerated]
	private bool serializerObject;

	[CompilerGenerated]
	private int refObject;

	[CompilerGenerated]
	private int _ErrorObject;

	[CompilerGenerated]
	private long m_CodeObject;

	[CompilerGenerated]
	private bool connectionObject;

	[CompilerGenerated]
	private int contextObject;

	[CompilerGenerated]
	private long statusObject;

	public bool TrimTransactionLogOnDispose
	{
		[CompilerGenerated]
		get
		{
			return serializerObject;
		}
		[CompilerGenerated]
		set
		{
			serializerObject = value;
		}
	}

	public bool ParanoidFlushing
	{
		[CompilerGenerated]
		get
		{
			return connectionObject;
		}
		[CompilerGenerated]
		set
		{
			connectionObject = value;
		}
	}

	public int CurrentFileNumber { get; private set; }

	private int CurrentCountOfItemsInQueue
	{
		get
		{
			lock (_InterpreterObject)
			{
				return _InterpreterObject.Count + m_FilterObject.Count;
			}
		}
	}

	private string TransactionLog => Path.Combine(path, "transaction.log");

	private string Meta => Path.Combine(path, "meta.state");

	[SpecialName]
	[CompilerGenerated]
	public int CreateDispatcher()
	{
		return refObject;
	}

	[SpecialName]
	[CompilerGenerated]
	public void CompareDispatcher(int int_0)
	{
		refObject = int_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public int DisableDispatcher()
	{
		return _ErrorObject;
	}

	[SpecialName]
	[CompilerGenerated]
	public void UpdateDispatcher(int int_0)
	{
		_ErrorObject = int_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public long PrepareDispatcher()
	{
		return m_CodeObject;
	}

	[SpecialName]
	[CompilerGenerated]
	public void ReflectDispatcher(long long_0)
	{
		m_CodeObject = long_0;
	}

	[SpecialName]
	public int RestartDispatcher()
	{
		return _InterpreterObject.Count + m_FilterObject.Count;
	}

	[SpecialName]
	[CompilerGenerated]
	public int StopDispatcher()
	{
		return contextObject;
	}

	[SpecialName]
	[CompilerGenerated]
	private void CancelDispatcher(int int_0)
	{
		contextObject = int_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public long ListDispatcher()
	{
		return statusObject;
	}

	[SpecialName]
	[CompilerGenerated]
	private void ResolveDispatcher(long long_0)
	{
		statusObject = long_0;
	}

	public TaskObject(string string_0, int int_0)
	{
		lock (_ModelObject)
		{
			m_AdvisorObject = 1;
			TrimTransactionLogOnDispose = true;
			ParanoidFlushing = true;
			ReflectDispatcher(67108864L);
			CompareDispatcher(1048576);
			UpdateDispatcher(1048576);
			CancelDispatcher(int_0);
			try
			{
				path = Path.GetFullPath(string_0);
				if (!Directory.Exists(path))
				{
					NewDispatcher(path);
				}
				WriteDispatcher();
			}
			catch (UnauthorizedAccessException)
			{
				throw new UnauthorizedAccessException("Directory \"" + string_0 + "\" does not exist or is missing write permissions");
			}
			catch (IOException innerException)
			{
				GC.SuppressFinalize(this);
				throw new InvalidOperationException("Another instance of the queue is already in action, or directory does not exists", innerException);
			}
			try
			{
				ConcatDispatcher();
				IncludeDispatcher();
			}
			catch (Exception)
			{
				GC.SuppressFinalize(this);
				GetDispatcher();
				throw;
			}
			m_AdvisorObject = 0;
		}
	}

	private void GetDispatcher()
	{
		if (path != null)
		{
			string text = Path.Combine(path, "lock");
			if (_CustomerObject != null)
			{
				_CustomerObject.Dispose();
				File.Delete(text);
			}
			_CustomerObject = null;
		}
	}

	private void WriteDispatcher()
	{
		string text = Path.Combine(path, "lock");
		_CustomerObject = new FileStream(text, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
	}

	private void NewDispatcher(string string_0)
	{
		Directory.CreateDirectory(string_0);
		SetPermissions.TryAllowReadWriteForAll(string_0);
	}

	public TaskObject(string string_0)
		: this(string_0, 67108864)
	{
	}

	~TaskObject()
	{
		if (m_AdvisorObject == null)
		{
			Dispose();
		}
	}

	public void Dispose()
	{
		lock (_ModelObject)
		{
			if (m_AdvisorObject != null)
			{
				return;
			}
			try
			{
				m_AdvisorObject = 1;
				lock (m_ContainerObject)
				{
					if (TrimTransactionLogOnDispose)
					{
						SearchDispatcher();
					}
				}
				GC.SuppressFinalize(this);
			}
			finally
			{
				GetDispatcher();
			}
		}
	}

	public void AcquireWriter(Stream stream_0, Func<Stream, long> func_0, Action<Stream> action_0)
	{
		lock (_ComposerObject)
		{
			if (stream_0.Position != ListDispatcher())
			{
				stream_0.Position = ListDispatcher();
			}
			ResolveDispatcher(func_0(stream_0));
			if (ListDispatcher() >= StopDispatcher())
			{
				CurrentFileNumber++;
				FileStream fileStream = SetDispatcher();
				fileStream.SetLength(ListDispatcher());
				ResolveDispatcher(0L);
				action_0(fileStream);
			}
		}
	}

	public void CommitTransaction(ICollection<Operation> icollection_0)
	{
		if (icollection_0.Count == 0)
		{
			return;
		}
		byte[] array = FindDispatcher(icollection_0);
		lock (m_ContainerObject)
		{
			long position;
			using (FileStream fileStream = PushDispatcher(array))
			{
				fileStream.Write(array, 0, array.Length);
				position = fileStream.Position;
				fileStream.Flush();
			}
			RemoveDispatcher(icollection_0);
			InterruptDispatcher(position);
			Atomic.Write(Meta, delegate(Stream stream_0)
			{
				byte[] bytes = BitConverter.GetBytes(CurrentFileNumber);
				stream_0.Write(bytes, 0, bytes.Length);
				bytes = BitConverter.GetBytes(ListDispatcher());
				stream_0.Write(bytes, 0, bytes.Length);
			});
			if (ParanoidFlushing)
			{
				SearchDispatcher();
			}
		}
	}

	private FileStream PushDispatcher(byte[] byte_0)
	{
		for (int i = 0; i < 10; i++)
		{
			try
			{
				return new FileStream(TransactionLog, FileMode.Append, FileAccess.Write, FileShare.None, byte_0.Length, FileOptions.WriteThrough | FileOptions.SequentialScan);
			}
			catch (Exception)
			{
				Thread.Sleep(250);
			}
		}
		throw new TimeoutException("Could not aquire transaction log lock");
	}

	public Entry Dequeue()
	{
		lock (_InterpreterObject)
		{
			LinkedListNode<Entry> first = _InterpreterObject.First;
			if (first == null)
			{
				return null;
			}
			Entry value = first.Value;
			if (value.Data == null)
			{
				InvokeDispatcher();
			}
			_InterpreterObject.RemoveFirst();
			m_FilterObject.Add(new Entry(value.FileNumber, value.Start, value.Length));
			return value;
		}
	}

	private void InvokeDispatcher()
	{
		long num = 0L;
		Entry value = _InterpreterObject.First.Value;
		Entry entry = value;
		foreach (Entry item in _InterpreterObject)
		{
			if ((item == entry || (item.FileNumber == entry.FileNumber && item.Start == entry.Start + entry.Length)) && num + item.Length <= CreateDispatcher())
			{
				entry = item;
				num += item.Length;
				continue;
			}
			break;
		}
		if (entry == value)
		{
			num = entry.Length;
		}
		byte[] src = SetupDispatcher(value, num);
		int num2 = 0;
		foreach (Entry item2 in _InterpreterObject)
		{
			item2.Data = new byte[item2.Length];
			Buffer.BlockCopy(src, num2, item2.Data, 0, item2.Length);
			num2 += item2.Length;
			if (item2 == entry)
			{
				break;
			}
		}
	}

	private byte[] SetupDispatcher(Entry entry_0, long long_0)
	{
		byte[] array = new byte[long_0];
		using FileStream fileStream = new FileStream(FillDispatcher(entry_0.FileNumber), FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
		fileStream.Position = entry_0.Start;
		int num = 0;
		do
		{
			int num2 = fileStream.Read(array, num, array.Length - num);
			if (num2 != 0)
			{
				num += num2;
				continue;
			}
			throw new InvalidOperationException("End of file reached while trying to read queue item");
		}
		while (num < array.Length);
		return array;
	}

	public IPersistentQueueSession ExcludeDispatcher()
	{
		return new PersistentQueueSession(this, SetDispatcher(), DisableDispatcher());
	}

	public void Reinstate(IEnumerable<Operation> ienumerable_0)
	{
		lock (_InterpreterObject)
		{
			RemoveDispatcher(from entry in ienumerable_0
				where entry.Type == OperationType.Dequeue
				select new Operation(OperationType.Reinstate, entry.FileNumber, entry.Start, entry.Length));
		}
	}

	private void IncludeDispatcher()
	{
		bool bool_1 = false;
		bool bool_0;
		Atomic.Read(TransactionLog, delegate(Stream stream)
		{
			using BinaryReader binaryReader = new BinaryReader(stream);
			bool_0 = false;
			try
			{
				int num = 0;
				while (true)
				{
					num++;
					CheckDispatcher(binaryReader, num, Constants.StartTransactionSeparatorGuid, delegate
					{
						bool_0 = true;
					});
					int num2 = binaryReader.ReadInt32();
					List<Operation> list = new List<Operation>(num2);
					for (int i = 0; i < num2; i++)
					{
						ChangeDispatcher(binaryReader);
						Operation operation = new Operation((OperationType)binaryReader.ReadByte(), binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32());
						list.Add(operation);
						if (operation.Type != OperationType.Enqueue)
						{
							bool_1 = true;
						}
					}
					CheckDispatcher(binaryReader, num, Constants.EndTransactionSeparatorGuid, delegate
					{
					});
					bool_0 = false;
					RemoveDispatcher(list);
				}
			}
			catch (EndOfStreamException)
			{
				if (bool_0)
				{
					bool_1 = true;
				}
			}
		});
		if (bool_1)
		{
			SearchDispatcher();
		}
	}

	private void SearchDispatcher()
	{
		byte[] byte_0;
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			memoryStream.Write(Constants.StartTransactionSeparator, 0, Constants.StartTransactionSeparator.Length);
			byte[] bytes = BitConverter.GetBytes(RestartDispatcher());
			memoryStream.Write(bytes, 0, bytes.Length);
			Entry[] array = m_FilterObject.ToArray();
			Entry[] array2 = array;
			foreach (Entry entry_ in array2)
			{
				EnableDispatcher(memoryStream, entry_, OperationType.Enqueue);
			}
			array = _InterpreterObject.ToArray();
			Entry[] array3 = array;
			foreach (Entry entry_2 in array3)
			{
				EnableDispatcher(memoryStream, entry_2, OperationType.Enqueue);
			}
			memoryStream.Write(Constants.EndTransactionSeparator, 0, Constants.EndTransactionSeparator.Length);
			memoryStream.Flush();
			byte_0 = memoryStream.ToArray();
		}
		Atomic.Write(TransactionLog, delegate(Stream stream)
		{
			stream.SetLength(byte_0.Length);
			stream.Write(byte_0, 0, byte_0.Length);
		});
	}

	private static void EnableDispatcher(Stream stream_0, Entry entry_0, OperationType operationType_0)
	{
		stream_0.Write(Constants.OperationSeparatorBytes, 0, Constants.OperationSeparatorBytes.Length);
		stream_0.WriteByte((byte)operationType_0);
		byte[] bytes = BitConverter.GetBytes(entry_0.FileNumber);
		stream_0.Write(bytes, 0, bytes.Length);
		byte[] bytes2 = BitConverter.GetBytes(entry_0.Start);
		stream_0.Write(bytes2, 0, bytes2.Length);
		byte[] bytes3 = BitConverter.GetBytes(entry_0.Length);
		stream_0.Write(bytes3, 0, bytes3.Length);
	}

	private static void ChangeDispatcher(BinaryReader binaryReader_0)
	{
		if (binaryReader_0.ReadInt32() != Constants.OperationSeparator)
		{
			throw new InvalidOperationException("Unexpected data in transaction log. Expected to get transaction separator but got unknonwn data");
		}
	}

	public int[] InitDispatcher(IEnumerable<Operation> ienumerable_0)
	{
		foreach (Operation item in ienumerable_0)
		{
			switch (item.Type)
			{
			case OperationType.Enqueue:
			{
				Entry entry3 = new Entry(item);
				_InterpreterObject.AddLast(entry3);
				int valueOrDefault2 = testsObject.GetValueOrDefault(entry3.FileNumber);
				testsObject[entry3.FileNumber] = valueOrDefault2 + 1;
				break;
			}
			case OperationType.Dequeue:
			{
				Entry entry2 = new Entry(item);
				m_FilterObject.Remove(entry2);
				int valueOrDefault = testsObject.GetValueOrDefault(entry2.FileNumber);
				testsObject[entry2.FileNumber] = valueOrDefault - 1;
				break;
			}
			case OperationType.Reinstate:
			{
				Entry entry = new Entry(item);
				_InterpreterObject.AddFirst(entry);
				m_FilterObject.Remove(entry);
				break;
			}
			}
		}
		HashSet<int> hashSet = new HashSet<int>(testsObject.Where(delegate(KeyValuePair<int, int> pair)
		{
			KeyValuePair<int, int> keyValuePair2 = pair;
			return keyValuePair2.Value < 1;
		}).Select(delegate(KeyValuePair<int, int> pair)
		{
			KeyValuePair<int, int> keyValuePair = pair;
			return keyValuePair.Key;
		}));
		foreach (int item2 in hashSet)
		{
			testsObject.Remove(item2);
		}
		return hashSet.ToArray();
	}

	private static void CheckDispatcher(BinaryReader binaryReader_0, int int_0, Guid guid_0, Action action_0)
	{
		byte[] array = binaryReader_0.ReadBytes(16);
		if (array.Length == 0)
		{
			throw new EndOfStreamException();
		}
		action_0();
		if (array.Length == 16)
		{
			if (new Guid(array) != guid_0)
			{
				throw new InvalidOperationException("Unexpected data in transaction log. Expected to get transaction separator but got unknown data. Tx #" + int_0);
			}
			return;
		}
		if (binaryReader_0.BaseStream.Length == binaryReader_0.BaseStream.Position)
		{
			throw new EndOfStreamException();
		}
		throw new InvalidOperationException("Unexpected data in transaction log. Expected to get transaction separator but got truncated data. Tx #" + int_0);
	}

	private void ConcatDispatcher()
	{
		Atomic.Read(Meta, delegate(Stream stream_0)
		{
			using BinaryReader binaryReader = new BinaryReader(stream_0);
			try
			{
				CurrentFileNumber = binaryReader.ReadInt32();
				ResolveDispatcher(binaryReader.ReadInt64());
			}
			catch (EndOfStreamException)
			{
			}
		});
	}

	private void InterruptDispatcher(long long_0)
	{
		if (long_0 >= PrepareDispatcher())
		{
			long num = CalculateDispatcher();
			if (long_0 >= num * 2)
			{
				SearchDispatcher();
			}
		}
	}

	private void RemoveDispatcher(IEnumerable<Operation> ienumerable_0)
	{
		int[] array;
		lock (_InterpreterObject)
		{
			array = InitDispatcher(ienumerable_0);
		}
		int[] array2 = array;
		int[] array3 = array2;
		foreach (int num in array3)
		{
			if (CurrentFileNumber != num)
			{
				File.Delete(FillDispatcher(num));
			}
		}
	}

	private static byte[] FindDispatcher(ICollection<Operation> icollection_0)
	{
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		memoryStream.Write(Constants.StartTransactionSeparator, 0, Constants.StartTransactionSeparator.Length);
		byte[] bytes = BitConverter.GetBytes(icollection_0.Count);
		memoryStream.Write(bytes, 0, bytes.Length);
		foreach (Operation item in icollection_0)
		{
			EnableDispatcher(memoryStream, new Entry(item), item.Type);
		}
		memoryStream.Write(Constants.EndTransactionSeparator, 0, Constants.EndTransactionSeparator.Length);
		memoryStream.Flush();
		return memoryStream.ToArray();
	}

	private FileStream SetDispatcher()
	{
		string string_ = FillDispatcher(CurrentFileNumber);
		FileStream result = new FileStream(string_, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 65536, FileOptions.WriteThrough | FileOptions.Asynchronous | FileOptions.SequentialScan);
		SetPermissions.TryAllowReadWriteForAll(string_);
		return result;
	}

	public string FillDispatcher(int int_0)
	{
		return Path.Combine(path, "data." + int_0);
	}

	private long CalculateDispatcher()
	{
		return 20L + (long)(16 * CurrentCountOfItemsInQueue);
	}

	static TaskObject()
	{
		_ModelObject = new object();
	}

	[CompilerGenerated]
	private void PopDispatcher(Stream stream_0)
	{
		byte[] bytes = BitConverter.GetBytes(CurrentFileNumber);
		stream_0.Write(bytes, 0, bytes.Length);
		bytes = BitConverter.GetBytes(ListDispatcher());
		stream_0.Write(bytes, 0, bytes.Length);
	}

	[CompilerGenerated]
	private void InstantiateDispatcher(Stream stream_0)
	{
		using BinaryReader binaryReader = new BinaryReader(stream_0);
		try
		{
			CurrentFileNumber = binaryReader.ReadInt32();
			ResolveDispatcher(binaryReader.ReadInt64());
		}
		catch (EndOfStreamException)
		{
		}
	}
}
