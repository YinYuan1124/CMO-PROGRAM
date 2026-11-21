using System;
using System.IO;
using System.Threading;

namespace DiskQueue.Implementation;

public static class Atomic
{
	private static readonly object _ValueObject;

	public static void Read(string string_0, Action<Stream> action_0)
	{
		lock (_ValueObject)
		{
			if (FileExistsNative.FileExistsFast(string_0 + ".old_copy") && LoginDispatcher(string_0))
			{
				File.Move(string_0 + ".old_copy", string_0);
			}
			using FileStream obj = new FileStream(string_0, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None, 65536, FileOptions.SequentialScan);
			SetPermissions.TryAllowReadWriteForAll(string_0);
			action_0(obj);
		}
	}

	public static void Write(string string_0, Action<Stream> action_0)
	{
		lock (_ValueObject)
		{
			if (!FileExistsNative.FileExistsFast(string_0 + ".old_copy"))
			{
				File.Move(string_0, string_0 + ".old_copy");
			}
			using (FileStream fileStream = new FileStream(string_0, FileMode.Create, FileAccess.Write, FileShare.None, 65536, FileOptions.WriteThrough | FileOptions.SequentialScan))
			{
				SetPermissions.TryAllowReadWriteForAll(string_0);
				action_0(fileStream);
				fileStream.Flush();
			}
			LoginDispatcher(string_0 + ".old_copy");
		}
	}

	private static bool LoginDispatcher(string string_0)
	{
		for (int i = 0; i < 5; i++)
		{
			try
			{
				File.Delete(string_0);
				return true;
			}
			catch
			{
				Thread.Sleep(100);
			}
		}
		return false;
	}

	static Atomic()
	{
		_ValueObject = new object();
	}
}
