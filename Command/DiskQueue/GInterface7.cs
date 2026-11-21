using System;
using System.Collections.Generic;
using System.IO;
using DiskQueue.Implementation;

namespace DiskQueue;

public interface GInterface7 : IDisposable
{
	int CurrentFileNumber { get; }

	bool TrimTransactionLogOnDispose { get; set; }

	bool ParanoidFlushing { get; set; }

	void AcquireWriter(Stream stream_0, Func<Stream, long> func_0, Action<Stream> action_0);

	void CommitTransaction(ICollection<Operation> icollection_0);

	Entry Dequeue();

	void Reinstate(IEnumerable<Operation> ienumerable_0);
}
