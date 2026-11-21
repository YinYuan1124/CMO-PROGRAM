using System;
using System.Collections.Generic;
using System.Text;
using OpenDis.Dis1998;

namespace OpenDis.Core;

public static class DIS1998ChunkConverter
{
	public static List<EightByteChunk> ArrayToEightByteChunks(Array array_0)
	{
		if (array_0.Length == 0)
		{
			return null;
		}
		EightByteChunk eightByteChunk = new EightByteChunk();
		int num = eightByteChunk.OtherParameters.Length;
		int num2 = Convert.ToInt32(Math.Ceiling((double)array_0.Length / (double)num));
		byte[] array = new byte[num2 * num];
		Buffer.BlockCopy(array_0, 0, array, 0, array_0.Length);
		List<EightByteChunk> list = new List<EightByteChunk>();
		for (int i = 0; i < num2; i++)
		{
			eightByteChunk = new EightByteChunk();
			Buffer.BlockCopy(array, i * num, eightByteChunk.OtherParameters, 0, num);
			list.Add(eightByteChunk);
		}
		return list;
	}

	public static List<FourByteChunk> ArrayToFourByteChunks(Array array_0)
	{
		if (array_0.Length == 0)
		{
			return null;
		}
		FourByteChunk fourByteChunk = new FourByteChunk();
		int num = fourByteChunk.OtherParameters.Length;
		int num2 = Convert.ToInt32(Math.Ceiling((double)array_0.Length / (double)num));
		byte[] array = new byte[num2 * num];
		Buffer.BlockCopy(array_0, 0, array, 0, array_0.Length);
		List<FourByteChunk> list = new List<FourByteChunk>();
		for (int i = 0; i < num2; i++)
		{
			fourByteChunk = new FourByteChunk();
			Buffer.BlockCopy(array, i * num, fourByteChunk.OtherParameters, 0, num);
			list.Add(fourByteChunk);
		}
		return list;
	}

	public static List<TwoByteChunk> ArrayToTwoByteChunks(Array array_0)
	{
		if (array_0.Length == 0)
		{
			return null;
		}
		TwoByteChunk twoByteChunk = new TwoByteChunk();
		int num = twoByteChunk.OtherParameters.Length;
		int num2 = Convert.ToInt32(Math.Ceiling((double)array_0.Length / (double)num));
		byte[] array = new byte[num2 * num];
		Buffer.BlockCopy(array_0, 0, array, 0, array_0.Length);
		List<TwoByteChunk> list = new List<TwoByteChunk>();
		for (int i = 0; i < num2; i++)
		{
			twoByteChunk = new TwoByteChunk();
			Buffer.BlockCopy(array, i * num, twoByteChunk.OtherParameters, 0, num);
			list.Add(twoByteChunk);
		}
		return list;
	}

	public static Array EightByteChunksToArray(List<EightByteChunk> list_0)
	{
		int num = new EightByteChunk().OtherParameters.Length;
		if (list_0.Count == 0)
		{
			return null;
		}
		byte[] array = new byte[list_0.Count * num];
		for (int i = 0; i < list_0.Count; i++)
		{
			Buffer.BlockCopy(list_0[i].OtherParameters, 0, array, i * num, num);
		}
		return array;
	}

	public static Array FourByteChunksToArray(List<FourByteChunk> list_0)
	{
		int num = new FourByteChunk().OtherParameters.Length;
		if (list_0.Count == 0)
		{
			return null;
		}
		byte[] array = new byte[list_0.Count * num];
		for (int i = 0; i < list_0.Count; i++)
		{
			Buffer.BlockCopy(list_0[i].OtherParameters, 0, array, i * num, num);
		}
		return array;
	}

	public static List<EightByteChunk> StringToEightByteChunks(string string_0)
	{
		if (string_0.Length == 0)
		{
			return null;
		}
		return ArrayToEightByteChunks(new ASCIIEncoding().GetBytes(string_0));
	}

	public static List<FourByteChunk> StringToFourByteChunks(string string_0)
	{
		if (string_0.Length == 0)
		{
			return null;
		}
		return ArrayToFourByteChunks(new ASCIIEncoding().GetBytes(string_0));
	}

	public static List<TwoByteChunk> StringToTwoByteChunks(string string_0)
	{
		if (string_0.Length == 0)
		{
			return null;
		}
		return ArrayToTwoByteChunks(new ASCIIEncoding().GetBytes(string_0));
	}

	public static Array TwoByteChunksToArray(List<TwoByteChunk> list_0)
	{
		int num = new TwoByteChunk().OtherParameters.Length;
		if (list_0.Count == 0)
		{
			return null;
		}
		byte[] array = new byte[list_0.Count * num];
		for (int i = 0; i < list_0.Count; i++)
		{
			Buffer.BlockCopy(list_0[i].OtherParameters, 0, array, i * num, num);
		}
		return array;
	}
}
