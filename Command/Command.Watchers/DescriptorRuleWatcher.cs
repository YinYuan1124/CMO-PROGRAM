using Command.Managers;

namespace Command.Watchers;

internal struct DescriptorRuleWatcher
{
	private long prototypeDispatcher;

	private ulong m_ComparatorDispatcher;

	public DescriptorRuleWatcher(long long_0)
	{
		m_ComparatorDispatcher = (ulong)long_0;
		if (long_0 < 0)
		{
			prototypeDispatcher = -1L;
		}
		else
		{
			prototypeDispatcher = 0L;
		}
	}

	public DescriptorRuleWatcher(long long_0, ulong ulong_0)
	{
		m_ComparatorDispatcher = ulong_0;
		prototypeDispatcher = long_0;
	}

	public DescriptorRuleWatcher(DescriptorRuleWatcher descriptorRuleWatcher_0)
	{
		prototypeDispatcher = descriptorRuleWatcher_0.prototypeDispatcher;
		m_ComparatorDispatcher = descriptorRuleWatcher_0.m_ComparatorDispatcher;
	}

	public bool SelectWrapper()
	{
		return prototypeDispatcher < 0;
	}

	public static bool operator ==(DescriptorRuleWatcher descriptorRuleWatcher_0, DescriptorRuleWatcher descriptorRuleWatcher_1)
	{
		if ((object)descriptorRuleWatcher_0 == (object)descriptorRuleWatcher_1)
		{
			return true;
		}
		if ((object)descriptorRuleWatcher_0 != null && (object)descriptorRuleWatcher_1 != null)
		{
			if (descriptorRuleWatcher_0.prototypeDispatcher == descriptorRuleWatcher_1.prototypeDispatcher)
			{
				return descriptorRuleWatcher_0.m_ComparatorDispatcher == descriptorRuleWatcher_1.m_ComparatorDispatcher;
			}
			return false;
		}
		return false;
	}

	public static bool operator !=(DescriptorRuleWatcher descriptorRuleWatcher_0, DescriptorRuleWatcher descriptorRuleWatcher_1)
	{
		return !(descriptorRuleWatcher_0 == descriptorRuleWatcher_1);
	}

	public override bool Equals(object obj)
	{
		if (obj != null && obj is DescriptorRuleWatcher descriptorRuleWatcher)
		{
			if (descriptorRuleWatcher.prototypeDispatcher == prototypeDispatcher)
			{
				return descriptorRuleWatcher.m_ComparatorDispatcher == m_ComparatorDispatcher;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return prototypeDispatcher.GetHashCode() ^ m_ComparatorDispatcher.GetHashCode();
	}

	public static bool operator >(DescriptorRuleWatcher descriptorRuleWatcher_0, DescriptorRuleWatcher descriptorRuleWatcher_1)
	{
		if (descriptorRuleWatcher_0.prototypeDispatcher == descriptorRuleWatcher_1.prototypeDispatcher)
		{
			return descriptorRuleWatcher_0.m_ComparatorDispatcher > descriptorRuleWatcher_1.m_ComparatorDispatcher;
		}
		return descriptorRuleWatcher_0.prototypeDispatcher > descriptorRuleWatcher_1.prototypeDispatcher;
	}

	public static bool operator <(DescriptorRuleWatcher descriptorRuleWatcher_0, DescriptorRuleWatcher descriptorRuleWatcher_1)
	{
		if (descriptorRuleWatcher_0.prototypeDispatcher == descriptorRuleWatcher_1.prototypeDispatcher)
		{
			return descriptorRuleWatcher_0.m_ComparatorDispatcher < descriptorRuleWatcher_1.m_ComparatorDispatcher;
		}
		return descriptorRuleWatcher_0.prototypeDispatcher < descriptorRuleWatcher_1.prototypeDispatcher;
	}

	public static DescriptorRuleWatcher operator +(DescriptorRuleWatcher descriptorRuleWatcher_0, DescriptorRuleWatcher descriptorRuleWatcher_1)
	{
		descriptorRuleWatcher_0.prototypeDispatcher += descriptorRuleWatcher_1.prototypeDispatcher;
		descriptorRuleWatcher_0.m_ComparatorDispatcher += descriptorRuleWatcher_1.m_ComparatorDispatcher;
		if (descriptorRuleWatcher_0.m_ComparatorDispatcher < descriptorRuleWatcher_1.m_ComparatorDispatcher)
		{
			descriptorRuleWatcher_0.prototypeDispatcher++;
		}
		return descriptorRuleWatcher_0;
	}

	public static DescriptorRuleWatcher operator -(DescriptorRuleWatcher descriptorRuleWatcher_0, DescriptorRuleWatcher descriptorRuleWatcher_1)
	{
		return descriptorRuleWatcher_0 + -descriptorRuleWatcher_1;
	}

	public static DescriptorRuleWatcher operator -(DescriptorRuleWatcher descriptorRuleWatcher_0)
	{
		if (descriptorRuleWatcher_0.m_ComparatorDispatcher == 0)
		{
			return new DescriptorRuleWatcher(-descriptorRuleWatcher_0.prototypeDispatcher, 0uL);
		}
		return new DescriptorRuleWatcher(~descriptorRuleWatcher_0.prototypeDispatcher, ~descriptorRuleWatcher_0.m_ComparatorDispatcher + 1);
	}

	public static DescriptorRuleWatcher CallWrapper(long long_0, long long_1)
	{
		bool num = long_0 < 0 != long_1 < 0;
		if (long_0 < 0)
		{
			long_0 = -long_0;
		}
		if (long_1 < 0)
		{
			long_1 = -long_1;
		}
		ulong num3 = (ulong)long_0 >> 32;
		ulong num4 = (ulong)(long_0 & 0xFFFFFFFFu);
		ulong num5 = (ulong)long_1 >> 32;
		ulong num6 = (ulong)(long_1 & 0xFFFFFFFFu);
		ulong num7 = num3 * num5;
		ulong num8 = num4 * num6;
		ulong num9 = num3 * num6 + num4 * num5;
		long num10 = (long)(num7 + (num9 >> 32));
		ulong num2 = (num9 << 32) + num8;
		if (num2 < num8)
		{
			num10++;
		}
		DescriptorRuleWatcher descriptorRuleWatcher = new DescriptorRuleWatcher(num10, num2);
		if (num)
		{
			return -descriptorRuleWatcher;
		}
		return descriptorRuleWatcher;
	}

	public static DescriptorRuleWatcher operator /(DescriptorRuleWatcher descriptorRuleWatcher_0, DescriptorRuleWatcher descriptorRuleWatcher_1)
	{
		if (descriptorRuleWatcher_1.m_ComparatorDispatcher == 0L && descriptorRuleWatcher_1.prototypeDispatcher == 0)
		{
			throw new InfoListenerManager("Int128: divide by zero");
		}
		bool flag = descriptorRuleWatcher_1.prototypeDispatcher < 0 != descriptorRuleWatcher_0.prototypeDispatcher < 0;
		if (descriptorRuleWatcher_0.prototypeDispatcher < 0)
		{
			descriptorRuleWatcher_0 = -descriptorRuleWatcher_0;
		}
		if (descriptorRuleWatcher_1.prototypeDispatcher < 0)
		{
			descriptorRuleWatcher_1 = -descriptorRuleWatcher_1;
		}
		if (descriptorRuleWatcher_1 < descriptorRuleWatcher_0)
		{
			DescriptorRuleWatcher descriptorRuleWatcher = new DescriptorRuleWatcher(0L);
			DescriptorRuleWatcher descriptorRuleWatcher2 = new DescriptorRuleWatcher(1L);
			while (descriptorRuleWatcher_1.prototypeDispatcher >= 0 && !(descriptorRuleWatcher_1 > descriptorRuleWatcher_0))
			{
				descriptorRuleWatcher_1.prototypeDispatcher <<= 1;
				if ((long)descriptorRuleWatcher_1.m_ComparatorDispatcher < 0L)
				{
					descriptorRuleWatcher_1.prototypeDispatcher++;
				}
				descriptorRuleWatcher_1.m_ComparatorDispatcher <<= 1;
				descriptorRuleWatcher2.prototypeDispatcher <<= 1;
				if ((long)descriptorRuleWatcher2.m_ComparatorDispatcher < 0L)
				{
					descriptorRuleWatcher2.prototypeDispatcher++;
				}
				descriptorRuleWatcher2.m_ComparatorDispatcher <<= 1;
			}
			descriptorRuleWatcher_1.m_ComparatorDispatcher >>= 1;
			if ((descriptorRuleWatcher_1.prototypeDispatcher & 1) == 1)
			{
				descriptorRuleWatcher_1.m_ComparatorDispatcher |= 9223372036854775808uL;
			}
			descriptorRuleWatcher_1.prototypeDispatcher >>>= 1;
			descriptorRuleWatcher2.m_ComparatorDispatcher >>= 1;
			if ((descriptorRuleWatcher2.prototypeDispatcher & 1) == 1)
			{
				descriptorRuleWatcher2.m_ComparatorDispatcher |= 9223372036854775808uL;
			}
			descriptorRuleWatcher2.prototypeDispatcher >>= 1;
			while (descriptorRuleWatcher2.prototypeDispatcher != 0L || descriptorRuleWatcher2.m_ComparatorDispatcher != 0)
			{
				if (!(descriptorRuleWatcher_0 < descriptorRuleWatcher_1))
				{
					descriptorRuleWatcher_0 -= descriptorRuleWatcher_1;
					descriptorRuleWatcher.prototypeDispatcher |= descriptorRuleWatcher2.prototypeDispatcher;
					descriptorRuleWatcher.m_ComparatorDispatcher |= descriptorRuleWatcher2.m_ComparatorDispatcher;
				}
				descriptorRuleWatcher_1.m_ComparatorDispatcher >>= 1;
				if ((descriptorRuleWatcher_1.prototypeDispatcher & 1) == 1)
				{
					descriptorRuleWatcher_1.m_ComparatorDispatcher |= 9223372036854775808uL;
				}
				descriptorRuleWatcher_1.prototypeDispatcher >>= 1;
				descriptorRuleWatcher2.m_ComparatorDispatcher >>= 1;
				if ((descriptorRuleWatcher2.prototypeDispatcher & 1) == 1)
				{
					descriptorRuleWatcher2.m_ComparatorDispatcher |= 9223372036854775808uL;
				}
				descriptorRuleWatcher2.prototypeDispatcher >>= 1;
			}
			if (flag)
			{
				return -descriptorRuleWatcher;
			}
			return descriptorRuleWatcher;
		}
		if (descriptorRuleWatcher_1 == descriptorRuleWatcher_0)
		{
			return new DescriptorRuleWatcher((!flag) ? 1 : (-1));
		}
		return new DescriptorRuleWatcher(0L);
	}

	public double LogoutWrapper()
	{
		if (prototypeDispatcher < 0)
		{
			ulong num = ~m_ComparatorDispatcher + 1;
			if (num == 0)
			{
				return (double)prototypeDispatcher * 1.8446744073709552E+19;
			}
			return 0.0 - ((double)num + (double)(~prototypeDispatcher) * 1.8446744073709552E+19);
		}
		return (double)m_ComparatorDispatcher + (double)prototypeDispatcher * 1.8446744073709552E+19;
	}
}
