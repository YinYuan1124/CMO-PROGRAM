using System;
using Command.Specifications;

namespace Aced.Compression;

public sealed class AcedInflator
{
	private static AcedInflator m_ConsumerDefinition;

	private int _FacadeDefinition;

	private int m_ProxyDefinition;

	private int _ReaderDefinition;

	private int _PropertyDefinition;

	private int m_ImporterDefinition;

	private int repositoryDefinition;

	private int _BridgeDefinition;

	private int _InvocationDefinition;

	private int m_ClassDefinition;

	private int _RequestDefinition;

	private unsafe byte* valueDefinition;

	private unsafe byte* m_TokenizerDefinition;

	private unsafe int* m_StubDefinition;

	private unsafe int* writerDefinition;

	private unsafe int* specificationDefinition;

	private unsafe int* _WatcherDefinition;

	private unsafe int* m_ReponseDefinition;

	private unsafe int* _DescriptorDefinition;

	private int[] poolDefinition;

	private int[] _TaskDefinition;

	private int[] _FilterDefinition;

	private int[] _TestsDefinition;

	private int[] interpreterDefinition;

	private int[] m_ContainerDefinition;

	private unsafe int* _ComposerDefinition;

	private unsafe int* modelDefinition;

	private unsafe int* advisorDefinition;

	private unsafe int* _CustomerDefinition;

	public static AcedInflator Instance
	{
		get
		{
			if (m_ConsumerDefinition == null)
			{
				m_ConsumerDefinition = new AcedInflator();
				return m_ConsumerDefinition;
			}
			return m_ConsumerDefinition;
		}
	}

	public AcedInflator()
	{
		poolDefinition = new int[640];
		_TaskDefinition = new int[128];
		_FilterDefinition = new int[40];
		_TestsDefinition = new int[320];
		interpreterDefinition = new int[15];
		m_ContainerDefinition = new int[15];
	}

	private unsafe int DefineObserver(int int_0)
	{
		int num = _PropertyDefinition;
		int num2 = m_ImporterDefinition;
		while (num2 < int_0)
		{
			if (num2 < 8 && _FacadeDefinition < m_ProxyDefinition)
			{
				_FacadeDefinition += 3;
				num |= (*valueDefinition | (valueDefinition[1] << 8) | (valueDefinition[2] << 16)) << num2;
				valueDefinition += 3;
				num2 += 24;
			}
			else if (_FacadeDefinition < _ReaderDefinition)
			{
				_FacadeDefinition++;
				num |= *valueDefinition << num2;
				valueDefinition++;
				num2 += 8;
			}
			else
			{
				AcedMCException.OrderObserver();
			}
		}
		_PropertyDefinition = num >> int_0;
		m_ImporterDefinition = num2 - int_0;
		return num & ((1 << int_0) - 1);
	}

	private unsafe int PublishObserver()
	{
		uint propertyDefinition = (uint)_PropertyDefinition;
		int num = m_ImporterDefinition;
		if (num == 0)
		{
			if (_FacadeDefinition < m_ProxyDefinition)
			{
				_FacadeDefinition += 4;
				propertyDefinition = *(uint*)valueDefinition;
				valueDefinition += 4;
				num = 31;
			}
			else if (_FacadeDefinition < _ReaderDefinition)
			{
				_FacadeDefinition++;
				propertyDefinition = *valueDefinition;
				valueDefinition++;
				num = 7;
			}
			else
			{
				AcedMCException.OrderObserver();
			}
		}
		else
		{
			num--;
		}
		_PropertyDefinition = (int)(propertyDefinition >> 1);
		m_ImporterDefinition = num;
		return (int)(propertyDefinition & 1);
	}

	private unsafe int AwakeObserver(int* pInt_0)
	{
		int num = 1;
		int num2 = _PropertyDefinition;
		while (true)
		{
			if (m_ImporterDefinition != 0)
			{
				num = pInt_0[num + (num2 & 1)];
				num2 >>= 1;
				m_ImporterDefinition--;
				if (num <= 0)
				{
					break;
				}
				continue;
			}
			if (_FacadeDefinition < m_ProxyDefinition)
			{
				_FacadeDefinition += 4;
				num2 = *(int*)valueDefinition;
				valueDefinition += 4;
				num = pInt_0[num + (num2 & 1)];
				num2 = (int)((uint)num2 >> 1);
				m_ImporterDefinition = 31;
			}
			else if (_FacadeDefinition < _ReaderDefinition)
			{
				_FacadeDefinition++;
				num2 = *valueDefinition;
				valueDefinition++;
				num = pInt_0[num + (num2 & 1)];
				num2 >>= 1;
				m_ImporterDefinition = 7;
			}
			else
			{
				AcedMCException.OrderObserver();
			}
			if (num <= 0)
			{
				break;
			}
		}
		_PropertyDefinition = num2;
		return -num;
	}

	private unsafe void QueryObserver()
	{
		AcedUtils.Fill(0, m_ReponseDefinition, 8);
		int num;
		for (int i = 0; i < 20; i++)
		{
			num = DefineObserver(3);
			_WatcherDefinition[i] = num;
			m_ReponseDefinition[num]++;
		}
		AcedUtils.Fill(0, specificationDefinition, 40);
		_DescriptorDefinition[1] = 0;
		num = (_DescriptorDefinition[2] = m_ReponseDefinition[1] << 1);
		num = (_DescriptorDefinition[3] = num + m_ReponseDefinition[2] << 1);
		num = (_DescriptorDefinition[4] = num + m_ReponseDefinition[3] << 1);
		num = (_DescriptorDefinition[5] = num + m_ReponseDefinition[4] << 1);
		num = (_DescriptorDefinition[6] = num + m_ReponseDefinition[5] << 1);
		num = (_DescriptorDefinition[7] = num + m_ReponseDefinition[6] << 1);
		int num2 = 2;
		for (int j = 0; j < 20; j++)
		{
			num = _WatcherDefinition[j];
			if (num == 0)
			{
				continue;
			}
			int num3 = _DescriptorDefinition[num];
			int num4 = (int)AcedUtils.RegisterObserver((uint)num3, num);
			_DescriptorDefinition[num] = num3 + 1;
			int num5 = 1;
			while (true)
			{
				num5 += num4 & 1;
				num4 >>= 1;
				num--;
				if (num == 0)
				{
					break;
				}
				num3 = num5;
				num5 = specificationDefinition[num5];
				if (num5 == 0)
				{
					num5 = num2 + 1;
					num2 = num5 + 1;
					specificationDefinition[num3] = num5;
				}
			}
			specificationDefinition[num5] = -j;
		}
	}

	private unsafe void ResetObserver(int int_0)
	{
		int num = 0;
		int* ptr = _WatcherDefinition;
		AcedUtils.Fill(0, m_ReponseDefinition, 15);
		while (int_0 > 0)
		{
			int num2 = AwakeObserver(specificationDefinition);
			if (num2 < 15)
			{
				*ptr = num2;
				m_ReponseDefinition[num2]++;
				ptr++;
				num = num2;
				int_0--;
				continue;
			}
			num2 = ((num2 < 17) ? ((num2 == 15) ? 2 : (PublishObserver() + 3)) : (num2 switch
			{
				18 => DefineObserver(3) + 9, 
				17 => DefineObserver(2) + 5, 
				_ => DefineObserver(7) + 17, 
			}));
			int_0 -= num2;
			m_ReponseDefinition[num] += num2;
			do
			{
				num2--;
				*ptr = num;
				ptr++;
			}
			while (num2 != 0);
		}
	}

	private unsafe void MapObserver()
	{
		AcedUtils.Fill(0, _WatcherDefinition, 320);
		ResetObserver(DefineObserver(6) + 257);
		AcedUtils.Fill(0, m_StubDefinition, 640);
		_DescriptorDefinition[1] = 0;
		int num = (_DescriptorDefinition[2] = m_ReponseDefinition[1] << 1);
		num = (_DescriptorDefinition[3] = num + m_ReponseDefinition[2] << 1);
		num = (_DescriptorDefinition[4] = num + m_ReponseDefinition[3] << 1);
		num = (_DescriptorDefinition[5] = num + m_ReponseDefinition[4] << 1);
		num = (_DescriptorDefinition[6] = num + m_ReponseDefinition[5] << 1);
		num = (_DescriptorDefinition[7] = num + m_ReponseDefinition[6] << 1);
		num = (_DescriptorDefinition[8] = num + m_ReponseDefinition[7] << 1);
		num = (_DescriptorDefinition[9] = num + m_ReponseDefinition[8] << 1);
		num = (_DescriptorDefinition[10] = num + m_ReponseDefinition[9] << 1);
		num = (_DescriptorDefinition[11] = num + m_ReponseDefinition[10] << 1);
		num = (_DescriptorDefinition[12] = num + m_ReponseDefinition[11] << 1);
		num = (_DescriptorDefinition[13] = num + m_ReponseDefinition[12] << 1);
		num = (_DescriptorDefinition[14] = num + m_ReponseDefinition[13] << 1);
		int num2 = 2;
		for (int i = 0; i < 320; i++)
		{
			num = _WatcherDefinition[i];
			if (num == 0)
			{
				continue;
			}
			int num3 = _DescriptorDefinition[num];
			int num4 = (int)AcedUtils.RegisterObserver((uint)num3, num);
			_DescriptorDefinition[num] = num3 + 1;
			int num5 = 1;
			while (true)
			{
				num5 += num4 & 1;
				num4 >>= 1;
				num--;
				if (num == 0)
				{
					break;
				}
				num3 = num5;
				num5 = m_StubDefinition[num5];
				if (num5 == 0)
				{
					num5 = num2 + 1;
					num2 = num5 + 1;
					m_StubDefinition[num3] = num5;
				}
			}
			m_StubDefinition[num5] = -i;
		}
	}

	private unsafe void SortObserver()
	{
		AcedUtils.Fill(0, _WatcherDefinition, 64);
		ResetObserver(DefineObserver(6) + 1);
		AcedUtils.Fill(0, writerDefinition, 128);
		_DescriptorDefinition[1] = 0;
		int num = (_DescriptorDefinition[2] = m_ReponseDefinition[1] << 1);
		num = (_DescriptorDefinition[3] = num + m_ReponseDefinition[2] << 1);
		num = (_DescriptorDefinition[4] = num + m_ReponseDefinition[3] << 1);
		num = (_DescriptorDefinition[5] = num + m_ReponseDefinition[4] << 1);
		num = (_DescriptorDefinition[6] = num + m_ReponseDefinition[5] << 1);
		num = (_DescriptorDefinition[7] = num + m_ReponseDefinition[6] << 1);
		num = (_DescriptorDefinition[8] = num + m_ReponseDefinition[7] << 1);
		num = (_DescriptorDefinition[9] = num + m_ReponseDefinition[8] << 1);
		num = (_DescriptorDefinition[10] = num + m_ReponseDefinition[9] << 1);
		num = (_DescriptorDefinition[11] = num + m_ReponseDefinition[10] << 1);
		num = (_DescriptorDefinition[12] = num + m_ReponseDefinition[11] << 1);
		num = (_DescriptorDefinition[13] = num + m_ReponseDefinition[12] << 1);
		num = (_DescriptorDefinition[14] = num + m_ReponseDefinition[13] << 1);
		int num2 = 2;
		for (int i = 0; i < 64; i++)
		{
			num = _WatcherDefinition[i];
			if (num == 0)
			{
				continue;
			}
			int num3 = _DescriptorDefinition[num];
			int num4 = (int)AcedUtils.RegisterObserver((uint)num3, num);
			_DescriptorDefinition[num] = num3 + 1;
			int num5 = 1;
			while (true)
			{
				num5 += num4 & 1;
				num4 >>= 1;
				num--;
				if (num == 0)
				{
					break;
				}
				num3 = num5;
				num5 = writerDefinition[num5];
				if (num5 == 0)
				{
					num5 = num2 + 1;
					num2 = num5 + 1;
					writerDefinition[num3] = num5;
				}
			}
			writerDefinition[num5] = -i;
		}
	}

	private void CalcObserver()
	{
		_BridgeDefinition = 8192;
		if (PublishObserver() == 0)
		{
			RateObserver();
			return;
		}
		QueryObserver();
		MapObserver();
		SortObserver();
	}

	private unsafe void RateObserver()
	{
		_BridgeDefinition += DefineObserver(8);
		int num = m_ImporterDefinition;
		while (_BridgeDefinition > 0 && repositoryDefinition > 0)
		{
			int num2 = _PropertyDefinition;
			if (num < 8)
			{
				if (_FacadeDefinition < m_ProxyDefinition)
				{
					_FacadeDefinition += 3;
					num2 |= (*valueDefinition | (valueDefinition[1] << 8) | (valueDefinition[2] << 16)) << num;
					valueDefinition += 3;
					num += 24;
				}
				else if (_FacadeDefinition < _ReaderDefinition)
				{
					_FacadeDefinition++;
					num2 |= *valueDefinition << num;
					valueDefinition++;
					num += 8;
				}
				else
				{
					AcedMCException.OrderObserver();
				}
			}
			_PropertyDefinition = num2 >> 8;
			num -= 8;
			*m_TokenizerDefinition = (byte)num2;
			_BridgeDefinition--;
			repositoryDefinition--;
			m_TokenizerDefinition++;
		}
		m_ImporterDefinition = num;
	}

	public unsafe static int GetDecompressedLength(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			AcedMCException.FlushObserver("sourceBytes");
		}
		fixed (byte* ptr = &byte_0[int_0])
		{
			int num = *(int*)ptr;
			if (num < 0)
			{
				return -num;
			}
			return num;
		}
	}

	public unsafe byte[] Decompress(byte[] byte_0, int int_0, int int_1, int int_2)
	{
		if (byte_0 == null)
		{
			AcedMCException.FlushObserver("sourceBytes");
		}
		int num;
		fixed (byte* ptr = &byte_0[int_0])
		{
			num = *(int*)ptr;
		}
		if (num < 0)
		{
			num = -num;
		}
		byte[] array = new byte[num + int_1 + int_2];
		if (num != 0)
		{
			Decompress(byte_0, int_0, array, int_1);
		}
		return array;
	}

	public unsafe int Decompress(byte[] byte_0, int int_0, byte[] byte_1, int int_1)
	{
		if (byte_0 == null)
		{
			AcedMCException.FlushObserver("sourceBytes");
		}
		if (byte_1 != null)
		{
			fixed (byte* ptr = &byte_0[int_0])
			{
				fixed (byte* tokenizerDefinition = &byte_1[int_1])
				{
					valueDefinition = ptr;
					m_TokenizerDefinition = tokenizerDefinition;
					int num = *(int*)valueDefinition;
					if (num <= 0)
					{
						num = -num;
						if (byte_1.Length - int_1 < num)
						{
							AcedMCException.CollectObserver();
						}
						if (num > 0)
						{
							Buffer.BlockCopy(byte_0, int_0 + 4, byte_1, int_1, num);
						}
						return num;
					}
					if (byte_1.Length - int_1 < num)
					{
						AcedMCException.CollectObserver();
					}
					fixed (int* stubDefinition = &poolDefinition[0])
					{
						fixed (int* ptr2 = &_TaskDefinition[0])
						{
							fixed (int* ptr3 = &_FilterDefinition[0])
							{
								fixed (int* watcherDefinition = &_TestsDefinition[0])
								{
									fixed (int* reponseDefinition = &interpreterDefinition[0])
									{
										fixed (int* descriptorDefinition = &m_ContainerDefinition[0])
										{
											fixed (int* composerDefinition = &RequestDefinitionSpec.m_ModelRegistry[0])
											{
												fixed (int* ptr4 = &RequestDefinitionSpec.advisorRegistry[0])
												{
													fixed (int* ptr5 = &RequestDefinitionSpec.m_CustomerRegistry[0])
													{
														fixed (int* customerDefinition = &RequestDefinitionSpec.serializerRegistry[0])
														{
															m_StubDefinition = stubDefinition;
															writerDefinition = ptr2;
															specificationDefinition = ptr3;
															_WatcherDefinition = watcherDefinition;
															m_ReponseDefinition = reponseDefinition;
															_DescriptorDefinition = descriptorDefinition;
															_ComposerDefinition = composerDefinition;
															modelDefinition = ptr4;
															advisorDefinition = ptr5;
															_CustomerDefinition = customerDefinition;
															m_ImporterDefinition = 0;
															_PropertyDefinition = 0;
															_FacadeDefinition = int_0 + 4;
															valueDefinition += 4;
															_ReaderDefinition = byte_0.Length;
															m_ProxyDefinition = _ReaderDefinition - 3;
															repositoryDefinition = num;
															while (repositoryDefinition > 0)
															{
																CalcObserver();
																while (_BridgeDefinition > 0 && repositoryDefinition > 0)
																{
																	int num2 = AwakeObserver(m_StubDefinition);
																	_BridgeDefinition--;
																	if (num2 < 256)
																	{
																		*m_TokenizerDefinition = (byte)num2;
																		repositoryDefinition--;
																		m_TokenizerDefinition++;
																	}
																	else
																	{
																		num2 -= 272;
																		int num3 = ((num2 < 0) ? (num2 + 19) : (DefineObserver(_ComposerDefinition[num2]) + modelDefinition[num2]));
																		num2 = AwakeObserver(writerDefinition);
																		int num4;
																		if (num2 < 3)
																		{
																			switch (num2)
																			{
																			default:
																				num4 = _RequestDefinition;
																				_RequestDefinition = _InvocationDefinition;
																				_InvocationDefinition = num4;
																				break;
																			case 1:
																				num4 = m_ClassDefinition;
																				m_ClassDefinition = _InvocationDefinition;
																				_InvocationDefinition = num4;
																				break;
																			case 0:
																				num4 = _InvocationDefinition;
																				break;
																			}
																		}
																		else
																		{
																			num4 = _CustomerDefinition[num2];
																			if (num2 >= 5)
																			{
																				num4 += DefineObserver(advisorDefinition[num2]);
																				_RequestDefinition = m_ClassDefinition;
																				m_ClassDefinition = _InvocationDefinition;
																				_InvocationDefinition = num4;
																			}
																		}
																		AcedUtils.ManageObserver(m_TokenizerDefinition - num4, m_TokenizerDefinition, num3);
																		repositoryDefinition -= num3;
																		m_TokenizerDefinition += num3;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					return num;
				}
			}
		}
		return GetDecompressedLength(byte_0, int_0);
	}

	public static void Release()
	{
		m_ConsumerDefinition = null;
	}
}
