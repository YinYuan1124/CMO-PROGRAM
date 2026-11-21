using System;
using Command.Specifications;

namespace Aced.Compression;

public sealed class AcedDeflator
{
	private static AcedDeflator m_ErrorRegistry;

	private int m_CodeRegistry;

	private int m_ConnectionRegistry;

	private int contextRegistry;

	private int _StatusRegistry;

	private int proccesorRegistry;

	private int _StrategyRegistry;

	private int configurationRegistry;

	private int m_TokenRegistry;

	private int m_IndexerRegistry;

	private int resolverRegistry;

	private int m_PublisherRegistry;

	private int m_ServerRegistry;

	private int m_AdapterRegistry;

	private int m_SchemaRegistry;

	private int _UtilsRegistry;

	private int predicateRegistry;

	private int m_SingletonRegistry;

	private int _RecordRegistry;

	private int _ExceptionRegistry;

	private int m_AttrRegistry;

	private int visitorRegistry;

	private unsafe int* m_ExporterRegistry;

	private unsafe int* m_PrototypeRegistry;

	private unsafe int* comparatorRegistry;

	private unsafe int* itemRegistry;

	private unsafe int* setterRegistry;

	private unsafe int* m_CreatorRegistry;

	private unsafe int* templateRegistry;

	private unsafe int* mappingRegistry;

	private int[] mockRegistry;

	private int[] m_TagRegistry;

	private int[] m_FieldRegistry;

	private int[] m_QueueRegistry;

	private int[] m_RegRegistry;

	private int[] paramRegistry;

	private int pageRegistry;

	private int _RulesRegistry;

	private int methodRegistry;

	private uint[] _ServiceRegistry;

	private object[] _SystemRegistry;

	private int _CandidateRegistry;

	private uint _BaseRegistry;

	private unsafe byte* _PolicyRegistry;

	private unsafe byte* broadcasterRegistry;

	private int m_IdentifierRegistry;

	private int m_PrinterRegistry;

	private int m_ParserRegistry;

	private int _AlgoRegistry;

	private unsafe int* m_DatabaseRegistry;

	private unsafe int* interceptorRegistry;

	private unsafe int* messageRegistry;

	private unsafe int* _ProductRegistry;

	private int[] _AnnotationRegistry;

	private int[] _IteratorRegistry;

	private int[] _InitializerRegistry;

	private int[] _RoleRegistry;

	private int factoryRegistry;

	private int _AttributeRegistry;

	private int m_EventRegistry;

	private int _GlobalRegistry;

	private unsafe int* _WorkerRegistry;

	private unsafe int* accountRegistry;

	private unsafe int* stateRegistry;

	private unsafe int* authenticationRegistry;

	private unsafe int* m_ParamsRegistry;

	private unsafe int* m_InfoRegistry;

	private unsafe int* m_HelperRegistry;

	private unsafe int* mapperRegistry;

	private unsafe int* _ManagerRegistry;

	private unsafe int* _GetterRegistry;

	private unsafe int* m_ProducerRegistry;

	private unsafe int* procRegistry;

	private unsafe int* m_StructDefinition;

	private int[] m_MerchantDefinition;

	private int[] _CallbackDefinition;

	private int[] m_DecoratorDefinition;

	private int[] processDefinition;

	private int[] m_ThreadDefinition;

	private int[] ruleDefinition;

	private int[] collectionDefinition;

	private int[] instanceDefinition;

	private int[] _ObjectDefinition;

	private int[] m_ParameterDefinition;

	private int[] _ExpressionDefinition;

	private int[] _DispatcherDefinition;

	private int[] _ListenerDefinition;

	private int[] _ConfigDefinition;

	private unsafe int* _RegistryDefinition;

	private unsafe int* definitionDefinition;

	private unsafe int* valDefinition;

	private unsafe int* _WrapperDefinition;

	private unsafe int* observerDefinition;

	private bool issuerDefinition;

	private bool _ClientDefinition;

	private static byte[] _DicDefinition;

	public static AcedDeflator Instance
	{
		get
		{
			if (m_ErrorRegistry == null)
			{
				m_ErrorRegistry = new AcedDeflator();
				return m_ErrorRegistry;
			}
			return m_ErrorRegistry;
		}
	}

	public AcedDeflator()
	{
		m_FieldRegistry = new int[321];
		m_QueueRegistry = new int[640];
		m_RegRegistry = new int[640];
		paramRegistry = new int[15];
		_AnnotationRegistry = new int[8192];
		_IteratorRegistry = new int[8192];
		_InitializerRegistry = new int[8192];
		_RoleRegistry = new int[8192];
		m_MerchantDefinition = new int[15];
		_CallbackDefinition = new int[640];
		m_DecoratorDefinition = new int[640];
		processDefinition = new int[320];
		m_ThreadDefinition = new int[320];
		ruleDefinition = new int[15];
		collectionDefinition = new int[128];
		instanceDefinition = new int[128];
		_ObjectDefinition = new int[64];
		m_ParameterDefinition = new int[64];
		_ExpressionDefinition = new int[8];
		_DispatcherDefinition = new int[40];
		_ListenerDefinition = new int[40];
		_ConfigDefinition = new int[20];
		mockRegistry = new int[262144];
		m_TagRegistry = new int[262144];
	}

	private void InterruptObserver()
	{
		if (_SystemRegistry == null)
		{
			_SystemRegistry = new object[16];
			_SystemRegistry[0] = _ServiceRegistry;
		}
		else
		{
			int num = (pageRegistry >> 17) - 1;
			int num2 = _SystemRegistry.Length;
			if (num == num2)
			{
				object[] array = new object[num2 * 2];
				Array.Copy(_SystemRegistry, 0, array, 0, num2);
				_SystemRegistry = array;
			}
			_SystemRegistry[num] = _ServiceRegistry;
		}
		_ServiceRegistry = new uint[32768];
		methodRegistry = 0;
	}

	private unsafe bool RemoveObserver(int int_0)
	{
		if (_CandidateRegistry == 0)
		{
			pageRegistry += 4;
			if (pageRegistry <= _RulesRegistry)
			{
				if (issuerDefinition)
				{
					if (methodRegistry == 32768)
					{
						InterruptObserver();
					}
					_ServiceRegistry[methodRegistry] = _BaseRegistry;
					methodRegistry++;
				}
				else if (!_ClientDefinition)
				{
					*(uint*)broadcasterRegistry = _BaseRegistry;
					broadcasterRegistry += 4;
				}
				_BaseRegistry = (uint)int_0;
				_CandidateRegistry = 31;
				return true;
			}
			return false;
		}
		_BaseRegistry |= (uint)(int_0 << 32 - _CandidateRegistry);
		_CandidateRegistry--;
		return true;
	}

	private unsafe bool FindObserver(int int_0, uint uint_0)
	{
		int candidateRegistry = _CandidateRegistry;
		if (candidateRegistry < int_0)
		{
			if (candidateRegistry != 0)
			{
				_BaseRegistry |= uint_0 << 32 - candidateRegistry;
				uint_0 >>= candidateRegistry;
			}
			pageRegistry += 4;
			if (pageRegistry <= _RulesRegistry)
			{
				if (issuerDefinition)
				{
					if (methodRegistry == 32768)
					{
						InterruptObserver();
					}
					_ServiceRegistry[methodRegistry] = _BaseRegistry;
					methodRegistry++;
				}
				else if (!_ClientDefinition)
				{
					*(uint*)broadcasterRegistry = _BaseRegistry;
					broadcasterRegistry += 4;
				}
				_BaseRegistry = uint_0;
				_CandidateRegistry = 32 + candidateRegistry - int_0;
				return true;
			}
			return false;
		}
		_BaseRegistry |= uint_0 << 32 - candidateRegistry;
		_CandidateRegistry = candidateRegistry - int_0;
		return true;
	}

	private unsafe void SetObserver(int int_0)
	{
		int* ptr = comparatorRegistry + 1;
		int* ptr2 = itemRegistry;
		_UtilsRegistry = 0;
		m_SchemaRegistry = -1;
		int num = 0;
		while (num < int_0)
		{
			if (*ptr2 == 0)
			{
				setterRegistry[num] = 0;
			}
			else
			{
				*ptr = num;
				m_SchemaRegistry = num;
				m_CreatorRegistry[num] = 0;
				_UtilsRegistry++;
				ptr++;
			}
			num++;
			ptr2++;
		}
		if (_UtilsRegistry > 1)
		{
			return;
		}
		if (_UtilsRegistry <= 0)
		{
			m_SchemaRegistry = 1;
			*ptr = 0;
			ptr[1] = 1;
			*itemRegistry = 1;
			itemRegistry[1] = 1;
			*m_CreatorRegistry = 0;
			m_CreatorRegistry[1] = 0;
		}
		else
		{
			if (m_SchemaRegistry == 0)
			{
				num = 1;
				m_SchemaRegistry = 1;
			}
			else
			{
				num = 0;
			}
			*ptr = num;
			itemRegistry[num] = 1;
			m_CreatorRegistry[num] = 0;
		}
		_UtilsRegistry = 2;
	}

	private unsafe void FillObserver(int int_0, int int_1)
	{
		int* ptr = comparatorRegistry;
		int* ptr2 = itemRegistry;
		int num;
		do
		{
			num = int_0;
			int num2 = int_1;
			int num3 = ptr2[ptr[int_0 + int_1 >> 1]];
			while (true)
			{
				if (ptr2[ptr[num]] >= num3)
				{
					while (num3 < ptr2[ptr[num2]])
					{
						num2--;
					}
					if (num <= num2)
					{
						int num4 = ptr[num];
						ptr[num] = ptr[num2];
						ptr[num2] = num4;
						num++;
						num2--;
					}
					if (num > num2)
					{
						break;
					}
				}
				else
				{
					num++;
				}
			}
			if (int_0 < num2)
			{
				FillObserver(int_0, num2);
			}
			int_0 = num;
		}
		while (num < int_1);
	}

	private unsafe void CalculateObserver()
	{
		int* ptr = comparatorRegistry;
		int num = ptr[1];
		int num2 = itemRegistry[num];
		int num3 = 1;
		for (int num4 = 2; num4 <= _UtilsRegistry; num4 <<= 1)
		{
			int num5 = ptr[num4];
			int num6 = itemRegistry[num5];
			if (num4 < _UtilsRegistry)
			{
				int num7 = ptr[num4 + 1];
				int num8 = itemRegistry[num7];
				if (num8 < num6 || (num8 == num6 && m_CreatorRegistry[num7] <= m_CreatorRegistry[num5]))
				{
					num4++;
					num5 = num7;
					num6 = num8;
				}
			}
			if (num2 < num6 || (num2 == num6 && m_CreatorRegistry[num] <= m_CreatorRegistry[num5]))
			{
				break;
			}
			ptr[num3] = ptr[num4];
			num3 = num4;
		}
		ptr[num3] = num;
	}

	private unsafe int PopObserver(int int_0)
	{
		int num = 0;
		int* ptr = comparatorRegistry + 1;
		int* ptr2 = templateRegistry;
		do
		{
			int num2 = *ptr;
			*ptr = comparatorRegistry[_UtilsRegistry];
			_UtilsRegistry--;
			CalculateObserver();
			int num3 = *ptr;
			*ptr2 = num2;
			ptr2[1] = num3;
			num += 2;
			ptr2 += 2;
			setterRegistry[num2] = (setterRegistry[num3] = int_0);
			itemRegistry[int_0] = itemRegistry[num2] + itemRegistry[num3];
			num2 = m_CreatorRegistry[num2];
			num3 = m_CreatorRegistry[num3];
			m_CreatorRegistry[int_0] = ((num2 <= num3) ? num3 : num2) + 1;
			*ptr = int_0;
			int_0++;
			CalculateObserver();
		}
		while (_UtilsRegistry > 1);
		setterRegistry[*ptr] = 0;
		return num;
	}

	private unsafe int InstantiateObserver()
	{
		itemRegistry = accountRegistry;
		setterRegistry = stateRegistry;
		SetObserver(320);
		FillObserver(1, _UtilsRegistry);
		int num = PopObserver(320);
		AcedUtils.Fill(0, _WorkerRegistry, 15);
		int num2 = 0;
		int num3 = 0;
		int* ptr = templateRegistry + num;
		do
		{
			ptr--;
			int num4 = *ptr;
			int num5 = stateRegistry[stateRegistry[num4]] + 1;
			if (num5 > 14)
			{
				num5 = 14;
				num2++;
			}
			stateRegistry[num4] = num5;
			if (num4 < 320)
			{
				num3 += num5 * accountRegistry[num4];
				_WorkerRegistry[num5]++;
			}
			num--;
		}
		while (num > 0);
		if (num2 == 0)
		{
			return num3;
		}
		do
		{
			num = 13;
			while (_WorkerRegistry[num] == 0)
			{
				num--;
			}
			_WorkerRegistry[num]--;
			_WorkerRegistry[num + 1] += 2;
			_WorkerRegistry[14]--;
			num2 -= 2;
		}
		while (num2 > 0);
		num2 = 14;
		do
		{
			int num6 = _WorkerRegistry[num2];
			while (num6 != 0)
			{
				int num7 = *ptr;
				ptr++;
				if (num7 < 320)
				{
					num3 += (num2 - stateRegistry[num7]) * accountRegistry[num7];
					stateRegistry[num7] = num2;
					num6--;
				}
			}
			num2--;
		}
		while (num2 != 0);
		return num3;
	}

	private unsafe int CreateObserver()
	{
		itemRegistry = m_HelperRegistry;
		setterRegistry = mapperRegistry;
		SetObserver(64);
		FillObserver(1, _UtilsRegistry);
		int num = PopObserver(64);
		AcedUtils.Fill(0, m_InfoRegistry, 15);
		int num2 = 0;
		int num3 = 0;
		int* ptr = templateRegistry + num;
		do
		{
			ptr--;
			int num4 = *ptr;
			int num5 = mapperRegistry[mapperRegistry[num4]] + 1;
			if (num5 > 14)
			{
				num5 = 14;
				num2++;
			}
			mapperRegistry[num4] = num5;
			if (num4 < 64)
			{
				num3 += num5 * m_HelperRegistry[num4];
				m_InfoRegistry[num5]++;
			}
			num--;
		}
		while (num > 0);
		if (num2 == 0)
		{
			return num3;
		}
		do
		{
			num = 13;
			while (m_InfoRegistry[num] == 0)
			{
				num--;
			}
			m_InfoRegistry[num]--;
			m_InfoRegistry[num + 1] += 2;
			m_InfoRegistry[14]--;
			num2 -= 2;
		}
		while (num2 > 0);
		num2 = 14;
		do
		{
			int num6 = m_InfoRegistry[num2];
			while (num6 != 0)
			{
				int num7 = *ptr;
				ptr++;
				if (num7 < 64)
				{
					num3 += (num2 - mapperRegistry[num7]) * m_HelperRegistry[num7];
					mapperRegistry[num7] = num2;
					num6--;
				}
			}
			num2--;
		}
		while (num2 != 0);
		return num3;
	}

	private unsafe int CompareObserver()
	{
		int* ptr = stateRegistry;
		int* ptr2 = authenticationRegistry;
		factoryRegistry = 0;
		int num = 0;
		int i = 0;
		if (m_SchemaRegistry <= 255)
		{
			m_EventRegistry = 257;
			m_SchemaRegistry = 256;
		}
		else
		{
			m_EventRegistry = m_SchemaRegistry + 1;
		}
		AcedUtils.Fill(0, m_ParamsRegistry, m_EventRegistry);
		int num2 = 0;
		do
		{
			int num3 = *ptr;
			ptr++;
			if (num3 != num || num3 != *ptr)
			{
				num = (*ptr2 = num3);
				i++;
			}
			else
			{
				int num4 = ((i + 144 <= m_SchemaRegistry) ? (i + 144) : m_EventRegistry);
				int num5 = i;
				i += 2;
				ptr++;
				for (; i < num4; i++)
				{
					if (num3 != *ptr)
					{
						break;
					}
					ptr++;
				}
				num5 = i - num5;
				if (num5 == 2)
				{
					*ptr2 = 15;
				}
				else if (num5 < 5)
				{
					*ptr2 = 16;
					m_ParamsRegistry[factoryRegistry] = num5 - 3;
					num2++;
				}
				else if (num5 < 9)
				{
					*ptr2 = 17;
					m_ParamsRegistry[factoryRegistry] = num5 - 5;
					num2 += 2;
				}
				else if (num5 < 17)
				{
					*ptr2 = 18;
					m_ParamsRegistry[factoryRegistry] = num5 - 9;
					num2 += 3;
				}
				else
				{
					*ptr2 = 19;
					m_ParamsRegistry[factoryRegistry] = num5 - 17;
					num2 += 7;
				}
			}
			factoryRegistry++;
			ptr2++;
		}
		while (i < m_SchemaRegistry);
		if (i == m_SchemaRegistry)
		{
			*ptr2 = *ptr;
			factoryRegistry++;
		}
		return num2;
	}

	private unsafe int ReadObserver()
	{
		int* ptr = mapperRegistry;
		int* ptr2 = _ManagerRegistry;
		_AttributeRegistry = 0;
		int num = 0;
		int i = 0;
		_GlobalRegistry = m_SchemaRegistry + 1;
		AcedUtils.Fill(0, _GetterRegistry, _GlobalRegistry);
		int num2 = 0;
		do
		{
			int num3 = *ptr;
			ptr++;
			if (num3 != num || num3 != *ptr)
			{
				num = (*ptr2 = num3);
				i++;
			}
			else
			{
				int num4 = i;
				i += 2;
				ptr++;
				for (; i < _GlobalRegistry; i++)
				{
					if (num3 != *ptr)
					{
						break;
					}
					ptr++;
				}
				num4 = i - num4;
				if (num4 == 2)
				{
					*ptr2 = 15;
				}
				else if (num4 < 5)
				{
					*ptr2 = 16;
					_GetterRegistry[_AttributeRegistry] = num4 - 3;
					num2++;
				}
				else if (num4 < 9)
				{
					*ptr2 = 17;
					_GetterRegistry[_AttributeRegistry] = num4 - 5;
					num2 += 2;
				}
				else if (num4 < 17)
				{
					*ptr2 = 18;
					_GetterRegistry[_AttributeRegistry] = num4 - 9;
					num2 += 3;
				}
				else
				{
					*ptr2 = 19;
					_GetterRegistry[_AttributeRegistry] = num4 - 17;
					num2 += 7;
				}
			}
			_AttributeRegistry++;
			ptr2++;
		}
		while (i < m_SchemaRegistry);
		if (i == m_SchemaRegistry)
		{
			*ptr2 = *ptr;
			_AttributeRegistry++;
		}
		return num2;
	}

	private unsafe void DisableObserver()
	{
		int* ptr = procRegistry;
		AcedUtils.Fill(0, ptr, 20);
		int* ptr2 = authenticationRegistry;
		int i;
		for (i = 7; i < factoryRegistry; i += 8)
		{
			ptr[*ptr2]++;
			ptr[ptr2[1]]++;
			ptr[ptr2[2]]++;
			ptr[ptr2[3]]++;
			ptr[ptr2[4]]++;
			ptr[ptr2[5]]++;
			ptr[ptr2[6]]++;
			ptr[ptr2[7]]++;
			ptr2 += 8;
		}
		for (i -= 7; i < factoryRegistry; i++)
		{
			ptr[*ptr2]++;
			ptr2++;
		}
		ptr2 = _ManagerRegistry;
		for (i = 7; i < _AttributeRegistry; i += 8)
		{
			ptr[*ptr2]++;
			ptr[ptr2[1]]++;
			ptr[ptr2[2]]++;
			ptr[ptr2[3]]++;
			ptr[ptr2[4]]++;
			ptr[ptr2[5]]++;
			ptr[ptr2[6]]++;
			ptr[ptr2[7]]++;
			ptr2 += 8;
		}
		for (i -= 7; i < _AttributeRegistry; i++)
		{
			ptr[*ptr2]++;
			ptr2++;
		}
	}

	private unsafe int UpdateObserver()
	{
		itemRegistry = procRegistry;
		setterRegistry = m_StructDefinition;
		SetObserver(20);
		FillObserver(1, _UtilsRegistry);
		int num = PopObserver(20);
		AcedUtils.Fill(0, m_ProducerRegistry, 8);
		int num2 = 0;
		int num3 = 0;
		int* ptr = templateRegistry + num;
		do
		{
			ptr--;
			int num4 = *ptr;
			int num5 = m_StructDefinition[m_StructDefinition[num4]] + 1;
			if (num5 > 7)
			{
				num5 = 7;
				num2++;
			}
			m_StructDefinition[num4] = num5;
			if (num4 < 20)
			{
				num3 += num5 * procRegistry[num4];
				m_ProducerRegistry[num5]++;
			}
			num--;
		}
		while (num > 0);
		if (num2 == 0)
		{
			return num3;
		}
		do
		{
			num = 6;
			while (m_ProducerRegistry[num] == 0)
			{
				num--;
			}
			m_ProducerRegistry[num]--;
			m_ProducerRegistry[num + 1] += 2;
			m_ProducerRegistry[7]--;
			num2 -= 2;
		}
		while (num2 > 0);
		num2 = 7;
		do
		{
			int num6 = m_ProducerRegistry[num2];
			while (num6 != 0)
			{
				int num7 = *ptr;
				ptr++;
				if (num7 < 20)
				{
					num3 += (num2 - m_StructDefinition[num7]) * procRegistry[num7];
					m_StructDefinition[num7] = num2;
					num6--;
				}
			}
			num2--;
		}
		while (num2 != 0);
		return num3;
	}

	private unsafe bool InsertObserver(uint uint_0, int int_0, int int_1)
	{
		if (RemoveObserver(0))
		{
			int num = _CandidateRegistry;
			while (true)
			{
				if (num >= 8)
				{
					_BaseRegistry |= uint_0 << 32 - num;
					num -= 8;
				}
				else
				{
					if (num != 0)
					{
						_BaseRegistry |= uint_0 << 32 - num;
						uint_0 >>= num;
					}
					pageRegistry += 4;
					if (pageRegistry > _RulesRegistry)
					{
						return false;
					}
					if (issuerDefinition)
					{
						if (methodRegistry == 32768)
						{
							InterruptObserver();
						}
						_ServiceRegistry[methodRegistry] = _BaseRegistry;
						methodRegistry++;
					}
					else if (!_ClientDefinition)
					{
						*(uint*)broadcasterRegistry = _BaseRegistry;
						broadcasterRegistry += 4;
					}
					_BaseRegistry = uint_0;
					num += 24;
				}
				if (int_0 >= int_1)
				{
					break;
				}
				uint_0 = _PolicyRegistry[int_0];
				int_0++;
			}
			_CandidateRegistry = num;
			return true;
		}
		return false;
	}

	private unsafe bool PrepareObserver()
	{
		for (int i = 0; i < _AlgoRegistry; i++)
		{
			int num = m_DatabaseRegistry[i];
			if (FindObserver(stateRegistry[num], (uint)accountRegistry[num]))
			{
				if (num < 256)
				{
					continue;
				}
				num -= 272;
				if (num < 0 || FindObserver(_RegistryDefinition[num], (uint)(interceptorRegistry[i] - definitionDefinition[num])))
				{
					num = messageRegistry[i];
					int num2 = mapperRegistry[num];
					if (num < 5)
					{
						if (!FindObserver(num2, (uint)m_HelperRegistry[num]))
						{
							return false;
						}
					}
					else if (!FindObserver(num2 + valDefinition[num], (uint)(m_HelperRegistry[num] | (_ProductRegistry[i] << num2))))
					{
						return false;
					}
					continue;
				}
				return false;
			}
			return false;
		}
		return true;
	}

	private unsafe void ReflectObserver()
	{
		int* ptr = mappingRegistry;
		ptr[1] = 0;
		int num = (ptr[2] = m_ProducerRegistry[1] << 1);
		ptr += 3;
		int* ptr2 = m_ProducerRegistry + 2;
		for (int num2 = 5; num2 > 0; num2--)
		{
			num = (*ptr = num + *ptr2 << 1);
			ptr2++;
			ptr++;
		}
		ptr = mappingRegistry;
		int* ptr3 = procRegistry;
		ptr2 = m_StructDefinition;
		for (int num3 = 20; num3 > 0; num3--)
		{
			num = *ptr2;
			if (num != 0)
			{
				int num4 = ptr[num];
				*ptr3 = (int)AcedUtils.RegisterObserver((uint)num4, num);
				ptr[num] = num4 + 1;
			}
			ptr2++;
			ptr3++;
		}
		ptr = mappingRegistry;
		ptr[1] = 0;
		num = (ptr[2] = _WorkerRegistry[1] << 1);
		ptr += 3;
		ptr2 = _WorkerRegistry + 2;
		for (int num5 = 12; num5 > 0; num5--)
		{
			num = (*ptr = num + *ptr2 << 1);
			ptr2++;
			ptr++;
		}
		ptr = mappingRegistry;
		ptr3 = accountRegistry;
		ptr2 = stateRegistry;
		for (int num6 = 320; num6 > 0; num6--)
		{
			num = *ptr2;
			if (num != 0)
			{
				int num7 = ptr[num];
				*ptr3 = (int)AcedUtils.RegisterObserver((uint)num7, num);
				ptr[num] = num7 + 1;
			}
			ptr2++;
			ptr3++;
		}
		ptr = mappingRegistry;
		ptr[1] = 0;
		num = (ptr[2] = m_InfoRegistry[1] << 1);
		ptr += 3;
		ptr2 = m_InfoRegistry + 2;
		for (int num8 = 12; num8 > 0; num8--)
		{
			num = (*ptr = num + *ptr2 << 1);
			ptr2++;
			ptr++;
		}
		ptr = mappingRegistry;
		ptr3 = m_HelperRegistry;
		ptr2 = mapperRegistry;
		for (int num9 = 64; num9 > 0; num9--)
		{
			num = *ptr2;
			if (num != 0)
			{
				int num10 = ptr[num];
				*ptr3 = (int)AcedUtils.RegisterObserver((uint)num10, num);
				ptr[num] = num10 + 1;
			}
			ptr2++;
			ptr3++;
		}
	}

	private unsafe bool VisitObserver()
	{
		ReflectObserver();
		if (RemoveObserver(1))
		{
			for (int i = 0; i < 20; i++)
			{
				if (!FindObserver(3, (uint)m_StructDefinition[i]))
				{
					return false;
				}
			}
			if (FindObserver(6, (uint)(m_EventRegistry - 257)))
			{
				for (int i = 0; i < factoryRegistry; i++)
				{
					int num = authenticationRegistry[i];
					int num2 = m_StructDefinition[num];
					if (!FindObserver(num2 + observerDefinition[num], (uint)(procRegistry[num] | (m_ParamsRegistry[i] << num2))))
					{
						return false;
					}
				}
				if (FindObserver(6, (uint)(_GlobalRegistry - 1)))
				{
					int i = 0;
					while (true)
					{
						if (i < _AttributeRegistry)
						{
							int num3 = _ManagerRegistry[i];
							int num4 = m_StructDefinition[num3];
							if (!FindObserver(num4 + observerDefinition[num3], (uint)(procRegistry[num3] | (_GetterRegistry[i] << num4))))
							{
								break;
							}
							i++;
							continue;
						}
						return PrepareObserver();
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private unsafe bool RestartObserver()
	{
		int num = 16;
		num = 16 + InstantiateObserver();
		num += CompareObserver();
		num += CreateObserver();
		num += ReadObserver();
		DisableObserver();
		num += UpdateObserver() + 60;
		num += m_IdentifierRegistry;
		int num2 = m_ParserRegistry - m_PrinterRegistry;
		if (num2 <= 8447 && (num2 << 3) + 10 <= num)
		{
			if (!InsertObserver((num2 >= 8192) ? ((uint)(num2 - 8192)) : 0u, m_PrinterRegistry, m_ParserRegistry))
			{
				return false;
			}
			predicateRegistry = _ExceptionRegistry;
			m_SingletonRegistry = m_AttrRegistry;
			_RecordRegistry = visitorRegistry;
		}
		else
		{
			if (!VisitObserver())
			{
				return false;
			}
			_ExceptionRegistry = predicateRegistry;
			m_AttrRegistry = m_SingletonRegistry;
			visitorRegistry = _RecordRegistry;
		}
		AcedUtils.Fill(0, accountRegistry, 320);
		AcedUtils.Fill(0, m_HelperRegistry, 64);
		m_IdentifierRegistry = 0;
		m_PrinterRegistry = m_ParserRegistry;
		_AlgoRegistry = 0;
		return true;
	}

	private int TestObserver(int int_0)
	{
		if (int_0 < 19)
		{
			return int_0 + 253;
		}
		if (int_0 < 115)
		{
			if (int_0 < 51)
			{
				m_IdentifierRegistry++;
				return (int_0 - 19 >> 1) + 272;
			}
			m_IdentifierRegistry += 2;
			return (int_0 - 51 >> 2) + 288;
		}
		if (int_0 < 243)
		{
			if (int_0 < 179)
			{
				m_IdentifierRegistry += 3;
				return (int_0 - 115 >> 3) + 304;
			}
			m_IdentifierRegistry += 4;
			return (int_0 - 179 >> 4) + 312;
		}
		if (int_0 < 371)
		{
			m_IdentifierRegistry += 6;
			return (int_0 - 243 >> 6) + 316;
		}
		if (int_0 < 627)
		{
			m_IdentifierRegistry += 8;
			return 318;
		}
		m_IdentifierRegistry += 14;
		return 319;
	}

	private int StopObserver(int int_0)
	{
		if (int_0 < 3)
		{
			return int_0 + 2;
		}
		if (int_0 == predicateRegistry)
		{
			return 0;
		}
		if (int_0 == m_SingletonRegistry)
		{
			m_SingletonRegistry = predicateRegistry;
			predicateRegistry = int_0;
			return 1;
		}
		if (int_0 == _RecordRegistry)
		{
			_RecordRegistry = predicateRegistry;
			predicateRegistry = int_0;
			return 2;
		}
		_RecordRegistry = m_SingletonRegistry;
		m_SingletonRegistry = predicateRegistry;
		predicateRegistry = int_0;
		if (int_0 < 1025)
		{
			if (int_0 < 65)
			{
				if (int_0 < 17)
				{
					return (int_0 - 3 >> 1) + 5;
				}
				if (int_0 < 33)
				{
					return (int_0 - 17 >> 2) + 12;
				}
				return (int_0 - 33 >> 3) + 16;
			}
			if (int_0 < 257)
			{
				if (int_0 < 129)
				{
					return (int_0 - 65 >> 4) + 20;
				}
				return (int_0 - 129 >> 5) + 24;
			}
			if (int_0 < 513)
			{
				return (int_0 - 257 >> 6) + 28;
			}
			return (int_0 - 513 >> 7) + 32;
		}
		if (int_0 < 16385)
		{
			if (int_0 < 4097)
			{
				if (int_0 < 2049)
				{
					return (int_0 - 1025 >> 8) + 36;
				}
				return (int_0 - 2049 >> 9) + 40;
			}
			if (int_0 < 8193)
			{
				return (int_0 - 4097 >> 10) + 44;
			}
			return (int_0 - 8193 >> 11) + 48;
		}
		if (int_0 < 65537)
		{
			if (int_0 < 32769)
			{
				return (int_0 - 16385 >> 12) + 52;
			}
			return (int_0 - 32769 >> 14) + 56;
		}
		if (int_0 < 131073)
		{
			return (int_0 - 65537 >> 15) + 58;
		}
		if (int_0 < 262145)
		{
			return (int_0 - 131073 >> 16) + 60;
		}
		return (int_0 - 262145 >> 17) + 62;
	}

	private unsafe bool CancelObserver(int int_0)
	{
		if (_AlgoRegistry == 8192 && !RestartObserver())
		{
			return false;
		}
		accountRegistry[int_0]++;
		m_DatabaseRegistry[_AlgoRegistry] = int_0;
		_AlgoRegistry++;
		return true;
	}

	private unsafe bool VerifyObserver()
	{
		if (_AlgoRegistry == 8192 && !RestartObserver())
		{
			return false;
		}
		int algoRegistry = _AlgoRegistry;
		int num = TestObserver(m_ConnectionRegistry);
		accountRegistry[num]++;
		m_DatabaseRegistry[algoRegistry] = num;
		interceptorRegistry[algoRegistry] = m_ConnectionRegistry;
		num = StopObserver(contextRegistry);
		if (num >= 5)
		{
			_ProductRegistry[algoRegistry] = contextRegistry - _WrapperDefinition[num];
			m_IdentifierRegistry += valDefinition[num];
		}
		m_HelperRegistry[num]++;
		messageRegistry[algoRegistry] = num;
		_AlgoRegistry = algoRegistry + 1;
		return true;
	}

	private unsafe int ListObserver()
	{
		fixed (int* prototypeRegistry = &m_TagRegistry[0])
		{
			fixed (int* exporterRegistry = &mockRegistry[0])
			{
				fixed (int* ptr = &paramRegistry[0])
				{
					fixed (int* ptr2 = &m_FieldRegistry[0])
					{
						fixed (int* creatorRegistry = &m_QueueRegistry[0])
						{
							fixed (int* ptr3 = &m_RegRegistry[0])
							{
								fixed (int* databaseRegistry = &_AnnotationRegistry[0])
								{
									fixed (int* ptr4 = &_IteratorRegistry[0])
									{
										fixed (int* ptr5 = &_InitializerRegistry[0])
										{
											fixed (int* productRegistry = &_RoleRegistry[0])
											{
												fixed (int* workerRegistry = &m_MerchantDefinition[0])
												{
													fixed (int* ptr6 = &_CallbackDefinition[0])
													{
														fixed (int* ptr7 = &m_DecoratorDefinition[0])
														{
															fixed (int* ptr8 = &processDefinition[0])
															{
																fixed (int* paramsRegistry = &m_ThreadDefinition[0])
																{
																	fixed (int* infoRegistry = &ruleDefinition[0])
																	{
																		fixed (int* helperRegistry = &collectionDefinition[0])
																		{
																			fixed (int* ptr9 = &instanceDefinition[0])
																			{
																				fixed (int* managerRegistry = &_ObjectDefinition[0])
																				{
																					fixed (int* getterRegistry = &m_ParameterDefinition[0])
																					{
																						fixed (int* producerRegistry = &_ExpressionDefinition[0])
																						{
																							fixed (int* ptr10 = &_DispatcherDefinition[0])
																							{
																								fixed (int* structDefinition = &_ListenerDefinition[0])
																								{
																									fixed (int* registryDefinition = &RequestDefinitionSpec.m_ModelRegistry[0])
																									{
																										fixed (int* ptr11 = &RequestDefinitionSpec.advisorRegistry[0])
																										{
																											fixed (int* ptr12 = &RequestDefinitionSpec.m_CustomerRegistry[0])
																											{
																												fixed (int* wrapperDefinition = &RequestDefinitionSpec.serializerRegistry[0])
																												{
																													fixed (int* ptr13 = &RequestDefinitionSpec.refRegistry[0])
																													{
																														m_PrototypeRegistry = prototypeRegistry;
																														m_ExporterRegistry = exporterRegistry;
																														mappingRegistry = ptr;
																														comparatorRegistry = ptr2;
																														m_CreatorRegistry = creatorRegistry;
																														templateRegistry = ptr3;
																														m_DatabaseRegistry = databaseRegistry;
																														interceptorRegistry = ptr4;
																														messageRegistry = ptr5;
																														_ProductRegistry = productRegistry;
																														_WorkerRegistry = workerRegistry;
																														accountRegistry = ptr6;
																														stateRegistry = ptr7;
																														authenticationRegistry = ptr8;
																														m_ParamsRegistry = paramsRegistry;
																														m_InfoRegistry = infoRegistry;
																														m_HelperRegistry = helperRegistry;
																														mapperRegistry = ptr9;
																														_ManagerRegistry = managerRegistry;
																														_GetterRegistry = getterRegistry;
																														m_ProducerRegistry = producerRegistry;
																														procRegistry = ptr10;
																														m_StructDefinition = structDefinition;
																														_RegistryDefinition = registryDefinition;
																														definitionDefinition = ptr11;
																														valDefinition = ptr12;
																														_WrapperDefinition = wrapperDefinition;
																														observerDefinition = ptr13;
																														AcedUtils.Fill(-524289, m_ExporterRegistry, configurationRegistry);
																														AcedUtils.Fill(0, accountRegistry, 320);
																														AcedUtils.Fill(0, m_HelperRegistry, 64);
																														m_PrinterRegistry = 0;
																														_AlgoRegistry = 0;
																														m_IdentifierRegistry = 0;
																														predicateRegistry = 0;
																														m_SingletonRegistry = 0;
																														_RecordRegistry = 0;
																														_ExceptionRegistry = 0;
																														m_AttrRegistry = 0;
																														visitorRegistry = 0;
																														*m_PrototypeRegistry = -524289;
																														int num = ((*_PolicyRegistry << _StrategyRegistry + _StrategyRegistry) ^ (_PolicyRegistry[1] << _StrategyRegistry) ^ _PolicyRegistry[2]) & m_TokenRegistry;
																														m_ExporterRegistry[num] = 0;
																														pageRegistry = 0;
																														CancelObserver(*_PolicyRegistry);
																														_CandidateRegistry = 32;
																														_BaseRegistry = 0u;
																														int i = 1;
																														while (i < m_ServerRegistry - 2)
																														{
																															num = ((num << _StrategyRegistry) ^ _PolicyRegistry[i + 2]) & m_TokenRegistry;
																															m_PrototypeRegistry[i & proccesorRegistry] = (m_CodeRegistry = m_ExporterRegistry[num]);
																															m_ExporterRegistry[num] = i;
																															m_ParserRegistry = i;
																															m_AdapterRegistry = m_IndexerRegistry;
																															resolverRegistry = i - _StatusRegistry;
																															if (m_CodeRegistry >= (m_PublisherRegistry = i - 524288) && ResolveObserver(i))
																															{
																																int num2 = i + m_ConnectionRegistry;
																																if (m_CodeRegistry > resolverRegistry && (m_CodeRegistry = m_PrototypeRegistry[m_CodeRegistry & proccesorRegistry]) >= m_PublisherRegistry && num2 < m_ServerRegistry && m_ConnectionRegistry < 17010)
																																{
																																	PostObserver(i);
																																	num2 = i + m_ConnectionRegistry;
																																}
																																while (m_ConnectionRegistry < 32 && num2 < m_ServerRegistry)
																																{
																																	i++;
																																	num = ((num << _StrategyRegistry) ^ _PolicyRegistry[i + 2]) & m_TokenRegistry;
																																	m_PrototypeRegistry[i & proccesorRegistry] = (m_CodeRegistry = m_ExporterRegistry[num]);
																																	m_ExporterRegistry[num] = i;
																																	m_AdapterRegistry = m_IndexerRegistry;
																																	resolverRegistry = i - _StatusRegistry;
																																	if (m_CodeRegistry < (m_PublisherRegistry = i - 524288) || !PostObserver(i))
																																	{
																																		break;
																																	}
																																	if (CancelObserver(_PolicyRegistry[i - 1]))
																																	{
																																		num2 = i + m_ConnectionRegistry;
																																		m_ParserRegistry = i;
																																		continue;
																																	}
																																	return -1;
																																}
																																if (!VerifyObserver())
																																{
																																	return -1;
																																}
																																if (num2 < m_ServerRegistry - 2)
																																{
																																	i++;
																																	do
																																	{
																																		num = ((num << _StrategyRegistry) ^ _PolicyRegistry[i + 2]) & m_TokenRegistry;
																																		m_PrototypeRegistry[i & proccesorRegistry] = (m_CodeRegistry = m_ExporterRegistry[num]);
																																		m_ExporterRegistry[num] = i;
																																		i++;
																																	}
																																	while (i < num2);
																																}
																																else
																																{
																																	i = num2;
																																}
																															}
																															else
																															{
																																if (!CancelObserver(_PolicyRegistry[i]))
																																{
																																	return -1;
																																}
																																i++;
																															}
																														}
																														for (; i < m_ServerRegistry; i++)
																														{
																															m_ParserRegistry = i;
																															if (!CancelObserver(_PolicyRegistry[i]))
																															{
																																return -1;
																															}
																														}
																														m_ParserRegistry = i;
																														if (!AssetObserver())
																														{
																															return -1;
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
				}
			}
		}
		return pageRegistry;
	}

	private unsafe bool ResolveObserver(int int_0)
	{
		byte* policyRegistry = _PolicyRegistry;
		uint num = (uint)(policyRegistry[int_0] | (policyRegistry[int_0 + 1] << 8) | (policyRegistry[int_0 + 2] << 16));
		int num2 = m_CodeRegistry;
		int serverRegistry = m_ServerRegistry;
		int num3 = serverRegistry - 8;
		int num4 = m_AdapterRegistry;
		while (true)
		{
			if ((*(uint*)(policyRegistry + num2) & 0xFFFFFF) == num)
			{
				int num5 = num2 + 3;
				int num6 = int_0 + 3;
				if (num6 < serverRegistry && policyRegistry[num5] == policyRegistry[num6])
				{
					num5++;
					num6++;
					if (num6 < serverRegistry && policyRegistry[num5] == policyRegistry[num6])
					{
						while (num6 < num3 && policyRegistry[++num5] == policyRegistry[++num6] && policyRegistry[++num5] == policyRegistry[++num6] && policyRegistry[++num5] == policyRegistry[++num6] && policyRegistry[++num5] == policyRegistry[++num6] && policyRegistry[++num5] == policyRegistry[++num6] && policyRegistry[++num5] == policyRegistry[++num6] && policyRegistry[++num5] == policyRegistry[++num6] && policyRegistry[++num5] == policyRegistry[++num6])
						{
						}
						if (policyRegistry[num5] == policyRegistry[num6])
						{
							num5++;
							for (num6++; num6 < serverRegistry && policyRegistry[num5] == policyRegistry[num6]; num6++)
							{
								num5++;
							}
						}
						num6 -= int_0;
						if (num6 < 17010)
						{
							m_ConnectionRegistry = num6;
						}
						else
						{
							m_ConnectionRegistry = 17010;
						}
						contextRegistry = int_0 - num2;
						return true;
					}
					if (int_0 - num2 <= 32768)
					{
						m_ConnectionRegistry = 4;
						contextRegistry = int_0 - num2;
						return true;
					}
				}
				else if (int_0 - num2 <= 4096)
				{
					m_ConnectionRegistry = 3;
					contextRegistry = int_0 - num2;
					return true;
				}
			}
			if (num2 <= resolverRegistry)
			{
				break;
			}
			num2 = (m_CodeRegistry = m_PrototypeRegistry[num2 & proccesorRegistry]);
			if (num2 >= m_PublisherRegistry)
			{
				num4 = (m_AdapterRegistry = num4 - 1);
				if (num4 == 0)
				{
					return false;
				}
				continue;
			}
			return false;
		}
		return false;
	}

	private unsafe bool PostObserver(int int_0)
	{
		byte* policyRegistry = _PolicyRegistry;
		int num = m_CodeRegistry;
		int num2 = m_ConnectionRegistry;
		int serverRegistry = m_ServerRegistry;
		int num3 = serverRegistry - 8;
		int num4 = m_AdapterRegistry;
		uint num5 = *(uint*)(policyRegistry + int_0 + num2 - 3);
		bool result = false;
		do
		{
			int i;
			int num6;
			if (*(uint*)(policyRegistry + num + num2 - 3) == num5 && policyRegistry[int_0] == policyRegistry[num] && policyRegistry[int_0 + 1] == policyRegistry[num + 1])
			{
				num6 = num + 1;
				i = int_0 + 1;
				if (num2 <= 4)
				{
					goto IL_0191;
				}
				int num7 = num2 - 1 >> 2;
				while (*(uint*)(policyRegistry + num6 + 1) == *(uint*)(policyRegistry + i + 1))
				{
					num6 += 4;
					i += 4;
					num7--;
					if (num7 > 0)
					{
						continue;
					}
					goto IL_0191;
				}
			}
			goto IL_003b;
			IL_003b:
			if (num <= resolverRegistry)
			{
				break;
			}
			num = m_PrototypeRegistry[num & proccesorRegistry];
			continue;
			IL_0191:
			while (i < num3 && policyRegistry[++num6] == policyRegistry[++i] && policyRegistry[++num6] == policyRegistry[++i] && policyRegistry[++num6] == policyRegistry[++i] && policyRegistry[++num6] == policyRegistry[++i] && policyRegistry[++num6] == policyRegistry[++i] && policyRegistry[++num6] == policyRegistry[++i] && policyRegistry[++num6] == policyRegistry[++i] && policyRegistry[++num6] == policyRegistry[++i])
			{
			}
			if (policyRegistry[num6] == policyRegistry[i])
			{
				num6++;
				for (i++; i < serverRegistry && policyRegistry[num6] == policyRegistry[i]; i++)
				{
					num6++;
				}
			}
			num6 = i - int_0;
			int_0 -= num;
			if (num6 - num2 > 2 || (num6 - num2 == 1 && (int_0 < 1025 || RunObserver(int_0, contextRegistry))) || (num6 - num2 == 2 && (int_0 < 32769 || StartObserver(int_0, contextRegistry))))
			{
				num2 = (m_ConnectionRegistry = num6);
				contextRegistry = int_0;
				result = true;
				if (num2 >= 17010)
				{
					m_ConnectionRegistry = 17010;
					break;
				}
				if (i == serverRegistry)
				{
					break;
				}
				num5 = *(uint*)(policyRegistry + i - 3);
			}
			int_0 += num;
			goto IL_003b;
		}
		while (num >= m_PublisherRegistry && --num4 != 0);
		return result;
	}

	private static bool RunObserver(int int_0, int int_1)
	{
		if (int_0 < 16385)
		{
			if (int_0 < 4097)
			{
				if (int_0 < 2049)
				{
					if (int_1 < 3)
					{
						return false;
					}
				}
				else if (int_1 < 17)
				{
					return false;
				}
			}
			else if (int_0 < 8193)
			{
				if (int_1 < 33)
				{
					return false;
				}
			}
			else if (int_1 < 65)
			{
				return false;
			}
		}
		else if (int_0 < 65537)
		{
			if (int_0 < 32769)
			{
				if (int_1 < 129)
				{
					return false;
				}
			}
			else if (int_1 < 513)
			{
				return false;
			}
		}
		else if (int_0 < 131073)
		{
			if (int_1 < 2049)
			{
				return false;
			}
		}
		else if (int_0 < 262145)
		{
			if (int_1 < 4097)
			{
				return false;
			}
		}
		else if (int_1 < 8193)
		{
			return false;
		}
		return true;
	}

	private static bool StartObserver(int int_0, int int_1)
	{
		if (int_0 < 131073)
		{
			if (int_0 < 65537 && int_1 < 3)
			{
				return false;
			}
			if (int_1 < 17)
			{
				return false;
			}
		}
		if (int_0 < 262145)
		{
			if (int_1 < 33)
			{
				return false;
			}
		}
		else if (int_1 < 65)
		{
			return false;
		}
		return true;
	}

	private unsafe bool AssetObserver()
	{
		if (RestartObserver())
		{
			pageRegistry += 4 - (_CandidateRegistry >> 3);
			if (pageRegistry <= _RulesRegistry)
			{
				if (issuerDefinition)
				{
					if (methodRegistry == 32768)
					{
						InterruptObserver();
					}
					_ServiceRegistry[methodRegistry] = _BaseRegistry;
					methodRegistry++;
				}
				else if (!_ClientDefinition)
				{
					switch (_CandidateRegistry >> 3)
					{
					case 0:
						*(uint*)broadcasterRegistry = _BaseRegistry;
						break;
					case 1:
						*broadcasterRegistry = (byte)_BaseRegistry;
						broadcasterRegistry[1] = (byte)(_BaseRegistry >> 8);
						broadcasterRegistry[2] = (byte)(_BaseRegistry >> 16);
						break;
					case 2:
						*broadcasterRegistry = (byte)_BaseRegistry;
						broadcasterRegistry[1] = (byte)(_BaseRegistry >> 8);
						break;
					case 3:
						*broadcasterRegistry = (byte)_BaseRegistry;
						break;
					}
				}
				return true;
			}
		}
		return false;
	}

	public unsafe byte[] Compress(byte[] byte_0, int int_0, int int_1, AcedCompressionLevel acedCompressionLevel_0, int int_2, int int_3)
	{
		if (int_1 == 0)
		{
			return new byte[int_2 + int_3 + 4];
		}
		if (byte_0 == null)
		{
			AcedMCException.FlushObserver("sourceBytes");
		}
		issuerDefinition = true;
		_ClientDefinition = false;
		_SystemRegistry = null;
		_ServiceRegistry = new uint[32768];
		methodRegistry = 0;
		_RulesRegistry = int_1;
		m_ServerRegistry = int_1;
		broadcasterRegistry = null;
		byte[] array;
		fixed (byte* policyRegistry = &byte_0[int_0])
		{
			_PolicyRegistry = policyRegistry;
			int num = -1;
			if (int_1 > 3 && acedCompressionLevel_0 != 0)
			{
				PrintObserver(acedCompressionLevel_0);
				num = ListObserver();
			}
			if (num <= 0)
			{
				_SystemRegistry = null;
				_ServiceRegistry = null;
				array = new byte[int_2 + 4 + int_1 + int_3];
				fixed (byte* ptr = &array[int_2])
				{
					*(int*)ptr = -int_1;
				}
				Buffer.BlockCopy(byte_0, int_0, array, int_2 + 4, int_1);
			}
			else
			{
				array = new byte[int_2 + 4 + num + int_3];
				fixed (byte* ptr = &array[int_2])
				{
					*(int*)ptr = int_1;
				}
				int_2 += 4;
				num--;
				int num2 = num >> 17;
				for (int i = 0; i < num2; i++)
				{
					Buffer.BlockCopy((uint[])_SystemRegistry[i], 0, array, int_2, 131072);
					int_2 += 131072;
				}
				Buffer.BlockCopy(_ServiceRegistry, 0, array, int_2, (num & 0x1FFFF) + 1);
				_SystemRegistry = null;
				_ServiceRegistry = null;
			}
		}
		return array;
	}

	public unsafe int Compress(byte[] byte_0, int int_0, int int_1, AcedCompressionLevel acedCompressionLevel_0, byte[] byte_1, int int_2)
	{
		_ClientDefinition = false;
		if (byte_1 == null)
		{
			_ClientDefinition = true;
			byte_1 = _DicDefinition;
			int_2 = 0;
			_RulesRegistry = int_1;
		}
		else
		{
			_RulesRegistry = byte_1.Length - int_2 - 4;
		}
		if (int_1 != 0)
		{
			if (byte_0 == null)
			{
				AcedMCException.FlushObserver("sourceBytes");
			}
			issuerDefinition = false;
			if (int_1 < _RulesRegistry)
			{
				_RulesRegistry = int_1;
			}
			m_ServerRegistry = int_1;
			fixed (byte* policyRegistry = &byte_0[int_0])
			{
				fixed (byte* ptr = &byte_1[int_2])
				{
					_PolicyRegistry = policyRegistry;
					broadcasterRegistry = ptr;
					int num = -1;
					if (int_1 > 3 && acedCompressionLevel_0 != 0)
					{
						PrintObserver(acedCompressionLevel_0);
						if (!_ClientDefinition)
						{
							if (_RulesRegistry < 0)
							{
								AcedMCException.ForgotObserver();
							}
							*(int*)broadcasterRegistry = int_1;
							broadcasterRegistry += 4;
						}
						num = ListObserver();
					}
					if (num < 0)
					{
						if (!_ClientDefinition)
						{
							if (_RulesRegistry < int_1)
							{
								AcedMCException.ForgotObserver();
							}
							*(int*)ptr = -int_1;
							Buffer.BlockCopy(byte_0, int_0, byte_1, int_2 + 4, int_1);
						}
						num = int_1;
					}
					return num + 4;
				}
			}
		}
		if (!_ClientDefinition)
		{
			if (_RulesRegistry < 0)
			{
				AcedMCException.ForgotObserver();
			}
			fixed (byte* ptr2 = &byte_1[int_2])
			{
				*(int*)ptr2 = 0;
			}
		}
		return 4;
	}

	private void PrintObserver(AcedCompressionLevel acedCompressionLevel_0)
	{
		switch (acedCompressionLevel_0)
		{
		case AcedCompressionLevel.Fastest:
			configurationRegistry = 4096;
			m_TokenRegistry = 4095;
			_StatusRegistry = 8192;
			proccesorRegistry = 8191;
			m_IndexerRegistry = 2;
			_StrategyRegistry = 4;
			break;
		case AcedCompressionLevel.Fast:
			configurationRegistry = 32768;
			m_TokenRegistry = 32767;
			_StatusRegistry = 65536;
			proccesorRegistry = 65535;
			m_IndexerRegistry = 8;
			_StrategyRegistry = 5;
			break;
		case AcedCompressionLevel.Normal:
			configurationRegistry = 262144;
			m_TokenRegistry = 262143;
			_StatusRegistry = 262144;
			proccesorRegistry = 262143;
			m_IndexerRegistry = 32;
			_StrategyRegistry = 6;
			break;
		case AcedCompressionLevel.Maximum:
			configurationRegistry = 262144;
			m_TokenRegistry = 262143;
			_StatusRegistry = 262144;
			proccesorRegistry = 262143;
			m_IndexerRegistry = 96;
			_StrategyRegistry = 6;
			break;
		}
	}

	public static void Release()
	{
		m_ErrorRegistry = null;
	}

	static AcedDeflator()
	{
		_DicDefinition = new byte[1];
	}
}
