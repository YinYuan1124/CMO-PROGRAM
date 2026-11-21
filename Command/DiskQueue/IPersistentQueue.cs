using System;

namespace DiskQueue;

public interface IPersistentQueue : IDisposable
{
	int EstimatedCountOfItemsInQueue { get; }

	GInterface7 Internals { get; }

	int MaxFileSize { get; }

	IPersistentQueueSession OpenSession();
}
