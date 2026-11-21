using System;
using System.Security.Cryptography;

public static class RandomUtils
{
	private static readonly RNGCryptoServiceProvider model;

	public static Random NewRandom()
	{
		byte[] array = new byte[4];
		model.GetBytes(array);
		return new Random(BitConverter.ToInt32(array, 0));
	}

	static RandomUtils()
	{
		model = new RNGCryptoServiceProvider();
	}
}
