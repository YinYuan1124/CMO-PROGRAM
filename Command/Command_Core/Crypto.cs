using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Crypto
{
	private static byte[] _DispatcherIssuer;

	private static string _ListenerIssuer;

	public static string string_0;

	private static object _ConfigIssuer;

	private MD5 registryIssuer;

	static Crypto()
	{
		_DispatcherIssuer = Encoding.ASCII.GetBytes("o6806642kbM7c5");
		_ListenerIssuer = "6b887c5ac993e7ae98c4c08e19f56429fdeb440755a4701b-7e80-4e57-9b96-3e9bee544da1942448a6-3112-4975-a68c-68782c80c0af";
		string_0 = "EBA66B7C-B09A-4EE0E860AE-410C-410D-8E7E-0AC92423D79F8F-8CD3-4BC7C54842BD8CC4DF32-BAAC-4C5F-8120-FD02B6131532";
		_ConfigIssuer = RuntimeHelpers.GetObjectValue(new object());
	}

	internal static string VerifyImporter(string string_1, string string_2 = "")
	{
		if (string.IsNullOrEmpty(string_1))
		{
			throw new ArgumentNullException("plainText");
		}
		if (string.IsNullOrEmpty(string_2))
		{
			string_2 = _ListenerIssuer;
		}
		RijndaelManaged rijndaelManaged = null;
		try
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(string_2, _DispatcherIssuer);
			rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryTributary memoryTributary = new MemoryTributary();
			memoryTributary.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
			memoryTributary.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
			using (CryptoStream stream = new CryptoStream(memoryTributary, transform, CryptoStreamMode.Write))
			{
				using StreamWriter streamWriter = new StreamWriter(stream);
				streamWriter.Write(string_1);
			}
			return Convert.ToBase64String(memoryTributary.ToArray());
		}
		finally
		{
			rijndaelManaged?.Clear();
		}
	}

	internal static string ListImporter(string string_1, string string_2 = "")
	{
		if (!string.IsNullOrEmpty(string_1))
		{
			if (string.IsNullOrEmpty(string_2) && string.IsNullOrEmpty(string_2))
			{
				string_2 = _ListenerIssuer;
			}
			RijndaelManaged rijndaelManaged = null;
			string result = null;
			try
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(string_2, _DispatcherIssuer);
				using MemoryTributary memoryTributary = new MemoryTributary(Convert.FromBase64String(string_1));
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
				rijndaelManaged.IV = ResolveImporter(memoryTributary);
				ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				using CryptoStream stream = new CryptoStream(memoryTributary, transform, CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(stream);
				result = streamReader.ReadToEnd();
				return result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
				return result;
			}
			finally
			{
				rijndaelManaged?.Clear();
			}
		}
		throw new ArgumentNullException("cipherText");
	}

	private static byte[] ResolveImporter(Stream stream_0)
	{
		byte[] array = new byte[4];
		if (stream_0.Read(array, 0, array.Length) == array.Length)
		{
			byte[] array2 = new byte[BitConverter.ToInt32(array, 0) - 1 + 1];
			if (stream_0.Read(array2, 0, array2.Length) != array2.Length)
			{
				throw new SystemException("没有正确读取字节数组");
			}
			return array2;
		}
		throw new SystemException("Stream没有包含格式正确的字节数组");
	}

	public static string GetFileHashFromFilename(string string_1)
	{
		object configIssuer = _ConfigIssuer;
		ObjectFlowControl.CheckForSyncLockOnValueType(configIssuer);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(configIssuer, ref lockTaken);
			using FileStream inputStream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			using SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			return Misc.InsertRequest(sHA1CryptoServiceProvider.ComputeHash(inputStream));
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(configIssuer);
			}
		}
	}

	internal string PostImporter(string string_1)
	{
		if (Information.IsNothing(registryIssuer))
		{
			registryIssuer = MD5.Create();
		}
		byte[] bytes = Encoding.UTF8.GetBytes(string_1);
		return Convert.ToBase64String(registryIssuer.ComputeHash(bytes));
	}
}
