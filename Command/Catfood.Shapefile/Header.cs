using System;
using System.Runtime.CompilerServices;

namespace Catfood.Shapefile;

internal class Header
{
	public const int _ClientListener = 100;

	private int m_DicListener;

	private int consumerListener;

	private int _FacadeListener;

	private ShapeType _ProxyListener;

	private double readerListener;

	private double propertyListener;

	private double m_ImporterListener;

	private double m_RepositoryListener;

	private double _BridgeListener;

	private double invocationListener;

	private double classListener;

	private double _RequestListener;

	public int Version => _FacadeListener;

	[SpecialName]
	public int DefineWrapper()
	{
		return m_DicListener;
	}

	[SpecialName]
	public int AwakeWrapper()
	{
		return consumerListener;
	}

	[SpecialName]
	public ShapeType MapWrapper()
	{
		return _ProxyListener;
	}

	[SpecialName]
	public double CalcWrapper()
	{
		return readerListener;
	}

	[SpecialName]
	public double FlushWrapper()
	{
		return propertyListener;
	}

	[SpecialName]
	public double CollectWrapper()
	{
		return m_ImporterListener;
	}

	[SpecialName]
	public double RegisterWrapper()
	{
		return m_RepositoryListener;
	}

	[SpecialName]
	public double RevertWrapper()
	{
		return _BridgeListener;
	}

	[SpecialName]
	public double CustomizeObserver()
	{
		return invocationListener;
	}

	[SpecialName]
	public double ConnectObserver()
	{
		return classListener;
	}

	[SpecialName]
	public double DeleteObserver()
	{
		return _RequestListener;
	}

	public Header(byte[] byte_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("headerBytes");
		}
		if (byte_0.Length == 100)
		{
			m_DicListener = EndianBitConverter.ToInt32(byte_0, 0, ProvidedOrder.Big);
			if (m_DicListener == 9994)
			{
				_FacadeListener = EndianBitConverter.ToInt32(byte_0, 28, ProvidedOrder.Little);
				if (_FacadeListener != 1000)
				{
					throw new InvalidOperationException($"Header version is {_FacadeListener}, expected {1000}");
				}
				consumerListener = EndianBitConverter.ToInt32(byte_0, 24, ProvidedOrder.Big);
				_ProxyListener = (ShapeType)EndianBitConverter.ToInt32(byte_0, 32, ProvidedOrder.Little);
				readerListener = EndianBitConverter.ToDouble(byte_0, 36, ProvidedOrder.Little);
				propertyListener = EndianBitConverter.ToDouble(byte_0, 44, ProvidedOrder.Little);
				m_ImporterListener = EndianBitConverter.ToDouble(byte_0, 52, ProvidedOrder.Little);
				m_RepositoryListener = EndianBitConverter.ToDouble(byte_0, 60, ProvidedOrder.Little);
				_BridgeListener = EndianBitConverter.ToDouble(byte_0, 68, ProvidedOrder.Little);
				invocationListener = EndianBitConverter.ToDouble(byte_0, 76, ProvidedOrder.Little);
				classListener = EndianBitConverter.ToDouble(byte_0, 84, ProvidedOrder.Little);
				_RequestListener = EndianBitConverter.ToDouble(byte_0, 92, ProvidedOrder.Little);
				return;
			}
			throw new InvalidOperationException($"Header File code is {m_DicListener}, expected {9994}");
		}
		throw new InvalidOperationException($"headerBytes must be {100} bytes long");
	}
}
