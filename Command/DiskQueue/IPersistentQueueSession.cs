using System;

namespace DiskQueue;

public interface IPersistentQueueSession : IDisposable
{
	void Enqueue(byte[] byte_0);

	byte[] Dequeue();

	void Flush();
}
