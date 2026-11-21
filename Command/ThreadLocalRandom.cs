using System;
using System.Runtime.CompilerServices;
using System.Threading;

public class ThreadLocalRandom : Random
{
	private static readonly ThreadLocal<Random> _Advisor;

	private static Random CompareStruct()
	{
		return RandomUtils.NewRandom();
	}

	[SpecialName]
	private static Random smethod_0()
	{
		return _Advisor.Value;
	}

	internal ThreadLocalRandom()
	{
	}

	public override int Next()
	{
		return smethod_0().Next();
	}

	public override int Next(int maxValue)
	{
		return smethod_0().Next(maxValue);
	}

	public override int Next(int minValue, int maxValue)
	{
		return smethod_0().Next(minValue, maxValue);
	}

	public override void NextBytes(byte[] buffer)
	{
		smethod_0().NextBytes(buffer);
	}

	public override double NextDouble()
	{
		return smethod_0().NextDouble();
	}

	protected override double Sample()
	{
		throw new NotImplementedException();
	}

	static ThreadLocalRandom()
	{
		_Advisor = new ThreadLocal<Random>(CompareStruct);
	}
}
