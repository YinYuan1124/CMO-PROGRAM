using System;

public class ThreadStaticRandom : Random
{
	[ThreadStatic]
	private static Random customer;

	internal ThreadStaticRandom()
	{
	}

	private Random ReadStruct()
	{
		Random random = customer;
		if (random == null)
		{
			random = (customer = DisableStruct());
		}
		return random;
	}

	private Random DisableStruct()
	{
		return RandomUtils.NewRandom();
	}

	public override int Next()
	{
		return ReadStruct().Next();
	}

	public override int Next(int maxValue)
	{
		return ReadStruct().Next(maxValue);
	}

	public override int Next(int minValue, int maxValue)
	{
		return ReadStruct().Next(minValue, maxValue);
	}

	public override void NextBytes(byte[] buffer)
	{
		ReadStruct().NextBytes(buffer);
	}

	public override double NextDouble()
	{
		return ReadStruct().NextDouble();
	}

	protected override double Sample()
	{
		throw new NotImplementedException();
	}
}
