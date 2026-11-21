using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using BitMiracle.LibTiff.Classic;
using CSMaterial;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class GeoTIFF_Tile
{
	public string FileName;

	private Tiff m_RepositoryDic;

	internal int _BridgeDic;

	internal int m_InvocationDic;

	internal double classDic;

	internal double _RequestDic;

	internal double _ValueDic;

	internal double tokenizerDic;

	private double stubDic;

	private double _WriterDic;

	private object specificationDic;

	private MemoryCache watcherDic;

	private MemoryCache reponseDic;

	private readonly MemoryCacheEntryOptions m_DescriptorDic;

	public double BottomEdgeLatitude => tokenizerDic + (double)_BridgeDic * _RequestDic;

	public double RightEdgeLongitude => _ValueDic + (double)m_InvocationDic * classDic;

	private byte[] VisitInvocation(int int_0)
	{
		byte[] result = null;
		watcherDic.TryGetValue<byte[]>(int_0, out result);
		return result;
	}

	private void RestartInvocation(int int_0, byte[] byte_0)
	{
		watcherDic.Set(int_0, byte_0, m_DescriptorDic.SetSize(1L));
	}

	public GeoTIFF_Tile(string string_0)
	{
		specificationDic = RuntimeHelpers.GetObjectValue(new object());
		m_DescriptorDic = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60.0));
		FileName = string_0;
		MemoryCacheOptions val = new MemoryCacheOptions
		{
			ExpirationScanFrequency = TimeSpan.FromSeconds(30.0)
		};
		reponseDic = new MemoryCache(val);
		watcherDic = new MemoryCache(val);
	}

	public void Initialize()
	{
		if (string.IsNullOrEmpty(FileName))
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception();
		}
		m_RepositoryDic = Tiff.Open(FileName, "r");
		FieldValue fieldValue = m_RepositoryDic.GetField(TiffTag.IMAGELENGTH)[0];
		_BridgeDic = fieldValue.ToInt();
		m_InvocationDic = m_RepositoryDic.ScanlineSize();
		FieldValue[] field = m_RepositoryDic.GetField(TiffTag.GEOTIFF_MODELPIXELSCALETAG);
		FieldValue[] field2 = m_RepositoryDic.GetField(TiffTag.GEOTIFF_MODELTIEPOINTTAG);
		fieldValue = field[1];
		byte[] bytes = fieldValue.GetBytes();
		classDic = BitConverter.ToDouble(bytes, 0);
		_RequestDic = BitConverter.ToDouble(bytes, 8) * -1.0;
		fieldValue = field2[1];
		byte[] bytes2 = fieldValue.GetBytes();
		_ValueDic = BitConverter.ToDouble(bytes2, 24);
		tokenizerDic = BitConverter.ToDouble(bytes2, 32);
		stubDic = tokenizerDic + _RequestDic / 2.0;
		_WriterDic = _ValueDic + classDic / 2.0;
	}

	public int ReadValue(double double_0, double double_1)
	{
		byte[] array = new byte[m_InvocationDic - 1 + 1];
		try
		{
			(int, int) tuple = TestInvocation(double_0, double_1);
			int hashCode = new Pos(tuple.Item1, tuple.Item2).GetHashCode();
			int result = 0;
			if (reponseDic.TryGetValue<int>(hashCode, out result))
			{
				return result;
			}
			byte[] array2 = VisitInvocation(tuple.Item2);
			if (array2 == null)
			{
				object obj = specificationDic;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					m_RepositoryDic.ReadScanline(array, tuple.Item2);
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
				RestartInvocation(tuple.Item2, array);
			}
			else
			{
				array = array2;
			}
			result = array[tuple.Item1];
			reponseDic.Set(hashCode, result, m_DescriptorDic.SetSize(1L));
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal (int column, int row) TestInvocation(double double_0, double double_1)
	{
		(int, int) result = default((int, int));
		try
		{
			int num = (int)Math.Round((double_0 - _WriterDic) / classDic);
			int num2 = (int)Math.Round((double_1 - stubDic) / _RequestDic);
			if (num2 == -1)
			{
				num2 = 0;
			}
			if (num == m_InvocationDic)
			{
				num = m_InvocationDic - 1;
			}
			if (num2 == _BridgeDic)
			{
				num2 = _BridgeDic - 1;
			}
			if ((num < 0 || num2 < 0) && Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (num, num2);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 2034503295049630", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
