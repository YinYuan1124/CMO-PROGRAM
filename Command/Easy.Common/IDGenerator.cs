using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Easy.Common;

public sealed class IDGenerator
{
	private static readonly char[] interceptorProcess;

	private static long _MessageProcess;

	private static readonly ThreadLocal<char[]> _ProductProcess;

	[CompilerGenerated]
	private static readonly IDGenerator m_AnnotationProcess;

	public static IDGenerator Instance
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationProcess;
		}
	}

	public string Next => DestroyRule(Interlocked.Increment(ref _MessageProcess));

	static IDGenerator()
	{
		interceptorProcess = new char[6];
		_MessageProcess = DateTime.UtcNow.Ticks;
		_ProductProcess = new ThreadLocal<char[]>(() => new char[20]
		{
			interceptorProcess[0],
			interceptorProcess[1],
			interceptorProcess[2],
			interceptorProcess[3],
			interceptorProcess[4],
			interceptorProcess[5],
			'-',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0'
		});
		m_AnnotationProcess = new IDGenerator();
		ComputeRule();
	}

	private IDGenerator()
	{
	}

	private static string DestroyRule(long long_0)
	{
		char[] value = _ProductProcess.Value;
		value[7] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 60) & 0x1F];
		value[8] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 55) & 0x1F];
		value[9] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 50) & 0x1F];
		value[10] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 45) & 0x1F];
		value[11] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 40) & 0x1F];
		value[12] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 35) & 0x1F];
		value[13] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 30) & 0x1F];
		value[14] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 25) & 0x1F];
		value[15] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 20) & 0x1F];
		value[16] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 15) & 0x1F];
		value[17] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 10) & 0x1F];
		value[18] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_0 >> 5) & 0x1F];
		value[19] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)long_0 & 0x1F];
		return new string(value, 0, value.Length);
	}

	private static void ComputeRule()
	{
		string text = Base36.Encode(Math.Abs(Environment.MachineName.GetHashCode()));
		int num = interceptorProcess.Length - 1;
		int num2 = 0;
		while (num >= 0)
		{
			if (num2 < text.Length)
			{
				interceptorProcess[num] = text[num2];
				num2++;
			}
			else
			{
				interceptorProcess[num] = '0';
			}
			num--;
		}
	}
}
