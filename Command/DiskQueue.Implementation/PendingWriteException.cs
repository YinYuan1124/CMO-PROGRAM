using System;
using System.Runtime.Serialization;
using System.Text;

namespace DiskQueue.Implementation;

[Serializable]
public sealed class PendingWriteException : Exception
{
	private readonly Exception[] pendingWritesExceptions;

	public Exception[] PendingWritesExceptions => pendingWritesExceptions;

	public override string Message
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder(base.Message).Append(":");
			Exception[] array = pendingWritesExceptions;
			Exception[] array2 = array;
			foreach (Exception ex in array2)
			{
				stringBuilder.AppendLine().Append(" - ").Append(ex.Message);
			}
			return stringBuilder.ToString();
		}
	}

	public PendingWriteException(Exception[] exception_0)
		: base("Error during pending writes")
	{
		pendingWritesExceptions = exception_0;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.Message).Append(":");
		Exception[] array = pendingWritesExceptions;
		Exception[] array2 = array;
		foreach (Exception value in array2)
		{
			stringBuilder.AppendLine().Append(" - ").Append(value);
		}
		return stringBuilder.ToString();
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("PendingWritesExceptions", PendingWritesExceptions);
	}
}
