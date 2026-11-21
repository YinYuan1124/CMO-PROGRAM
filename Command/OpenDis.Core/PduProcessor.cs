using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Dis1998;
using OpenDis.Enumerations;

namespace OpenDis.Core;

public class PduProcessor
{
	public const uint PDU_LENGTH_POSITION = 8u;

	public const uint PDU_TYPE_POSITION = 2u;

	public const uint PDU_VERSION_POSITION = 0u;

	private Endian _RulesCallback;

	private XmlSerializer methodCallback;

	public Endian Endian
	{
		get
		{
			return _RulesCallback;
		}
		set
		{
			_RulesCallback = value;
		}
	}

	public PduProcessor()
	{
		_RulesCallback = (BitConverter.IsLittleEndian ? Endian.Little : Endian.Big);
	}

	public static Pdu ConvertByteArrayToPdu1998(byte byte_0, byte[] byte_1, Endian endian_0)
	{
		return UnmarshalRawPdu(byte_0, byte_1, endian_0);
	}

	public static StringBuilder DecodePdu(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		object_0.GetType().InvokeMember("Reflection", BindingFlags.InvokeMethod, null, object_0, new object[1] { stringBuilder }, CultureInfo.InvariantCulture);
		return stringBuilder;
	}

	public List<object> ProcessPdu(byte[] byte_0, Endian endian_0)
	{
		Endian = endian_0;
		return ProcessPdu(byte_0);
	}

	public object ProcessPdu(Stream stream_0, Endian endian_0)
	{
		Endian = endian_0;
		return ProcessPdu(stream_0);
	}

	public void ProcessPdu(Stream stream_0, Endian endian_0, out byte[] byte_0)
	{
		Endian = endian_0;
		ProcessPdu(stream_0, out byte_0);
	}

	public List<byte[]> ProcessRawPdu(byte[] byte_0, Endian endian_0)
	{
		Endian = endian_0;
		return ProcessRawPdu(byte_0);
	}

	public void ProcessRawPdu(byte[] byte_0, Endian endian_0, ref Queue<byte[]> queue_0)
	{
		Endian = endian_0;
		foreach (byte[] item in ProcessRawPdu(byte_0))
		{
			queue_0.Enqueue(item);
		}
	}

	public static Pdu UnmarshalRawPdu(byte byte_0, DataInputStream dataInputStream_0)
	{
		return UnmarshalRawPdu((PduType)byte_0, dataInputStream_0);
	}

	public static Pdu UnmarshalRawPdu(PduType pduType_0, DataInputStream dataInputStream_0)
	{
		Pdu result = new Pdu();
		switch (pduType_0)
		{
		case PduType.EntityState:
		{
			EntityStatePdu entityStatePdu = new EntityStatePdu();
			entityStatePdu.Unmarshal(dataInputStream_0);
			result = entityStatePdu;
			break;
		}
		case PduType.Fire:
		{
			FirePdu firePdu = new FirePdu();
			firePdu.Unmarshal(dataInputStream_0);
			result = firePdu;
			break;
		}
		case PduType.Detonation:
		{
			DetonationPdu detonationPdu = new DetonationPdu();
			detonationPdu.Unmarshal(dataInputStream_0);
			result = detonationPdu;
			break;
		}
		case PduType.Collision:
		{
			CollisionPdu collisionPdu = new CollisionPdu();
			collisionPdu.Unmarshal(dataInputStream_0);
			result = collisionPdu;
			break;
		}
		case PduType.ServiceRequest:
		{
			ServiceRequestPdu serviceRequestPdu = new ServiceRequestPdu();
			serviceRequestPdu.Unmarshal(dataInputStream_0);
			result = serviceRequestPdu;
			break;
		}
		case PduType.ResupplyOffer:
		{
			ResupplyOfferPdu resupplyOfferPdu = new ResupplyOfferPdu();
			resupplyOfferPdu.Unmarshal(dataInputStream_0);
			result = resupplyOfferPdu;
			break;
		}
		case PduType.ResupplyReceived:
		{
			ResupplyReceivedPdu resupplyReceivedPdu = new ResupplyReceivedPdu();
			resupplyReceivedPdu.Unmarshal(dataInputStream_0);
			result = resupplyReceivedPdu;
			break;
		}
		case PduType.ResupplyCancel:
		{
			ResupplyCancelPdu resupplyCancelPdu = new ResupplyCancelPdu();
			resupplyCancelPdu.Unmarshal(dataInputStream_0);
			result = resupplyCancelPdu;
			break;
		}
		case PduType.RepairComplete:
		{
			RepairCompletePdu repairCompletePdu = new RepairCompletePdu();
			repairCompletePdu.Unmarshal(dataInputStream_0);
			result = repairCompletePdu;
			break;
		}
		case PduType.RepairResponse:
		{
			RepairResponsePdu repairResponsePdu = new RepairResponsePdu();
			repairResponsePdu.Unmarshal(dataInputStream_0);
			result = repairResponsePdu;
			break;
		}
		case PduType.CreateEntity:
		{
			CreateEntityPdu createEntityPdu = new CreateEntityPdu();
			createEntityPdu.Unmarshal(dataInputStream_0);
			result = createEntityPdu;
			break;
		}
		case PduType.RemoveEntity:
		{
			RemoveEntityPdu removeEntityPdu = new RemoveEntityPdu();
			removeEntityPdu.Unmarshal(dataInputStream_0);
			result = removeEntityPdu;
			break;
		}
		case PduType.StartResume:
		{
			StartResumePdu startResumePdu = new StartResumePdu();
			startResumePdu.Unmarshal(dataInputStream_0);
			result = startResumePdu;
			break;
		}
		case PduType.StopFreeze:
		{
			StopFreezePdu stopFreezePdu = new StopFreezePdu();
			stopFreezePdu.Unmarshal(dataInputStream_0);
			result = stopFreezePdu;
			break;
		}
		case PduType.Acknowledge:
		{
			AcknowledgePdu acknowledgePdu = new AcknowledgePdu();
			acknowledgePdu.Unmarshal(dataInputStream_0);
			result = acknowledgePdu;
			break;
		}
		case PduType.ActionRequest:
		{
			ActionRequestPdu actionRequestPdu = new ActionRequestPdu();
			actionRequestPdu.Unmarshal(dataInputStream_0);
			result = actionRequestPdu;
			break;
		}
		case PduType.ActionResponse:
		{
			ActionResponsePdu actionResponsePdu = new ActionResponsePdu();
			actionResponsePdu.Unmarshal(dataInputStream_0);
			result = actionResponsePdu;
			break;
		}
		case PduType.DataQuery:
		{
			DataQueryPdu dataQueryPdu = new DataQueryPdu();
			dataQueryPdu.Unmarshal(dataInputStream_0);
			result = dataQueryPdu;
			break;
		}
		case PduType.SetData:
		{
			SetDataPdu setDataPdu = new SetDataPdu();
			setDataPdu.Unmarshal(dataInputStream_0);
			result = setDataPdu;
			break;
		}
		case PduType.EventReport:
		{
			EventReportPdu eventReportPdu = new EventReportPdu();
			eventReportPdu.Unmarshal(dataInputStream_0);
			result = eventReportPdu;
			break;
		}
		case PduType.Comment:
		{
			CommentPdu commentPdu = new CommentPdu();
			commentPdu.Unmarshal(dataInputStream_0);
			result = commentPdu;
			break;
		}
		case PduType.Transmitter:
		{
			TransmitterPdu transmitterPdu = new TransmitterPdu();
			transmitterPdu.Unmarshal(dataInputStream_0);
			result = transmitterPdu;
			break;
		}
		case PduType.Signal:
		{
			SignalPdu signalPdu = new SignalPdu();
			signalPdu.Unmarshal(dataInputStream_0);
			result = signalPdu;
			break;
		}
		case PduType.UnderwaterAcoustic:
		{
			UaPdu uaPdu = new UaPdu();
			uaPdu.Unmarshal(dataInputStream_0);
			result = uaPdu;
			break;
		}
		}
		return result;
	}

	public static Pdu UnmarshalRawPdu(byte byte_0, byte[] byte_1, Endian endian_0)
	{
		DataInputStream dataInputStream_ = new DataInputStream(byte_1, endian_0);
		return UnmarshalRawPdu((PduType)byte_0, dataInputStream_);
	}

	public static Pdu UnmarshalRawPdu(PduType pduType_0, byte[] byte_0, Endian endian_0)
	{
		DataInputStream dataInputStream_ = new DataInputStream(byte_0, endian_0);
		return UnmarshalRawPdu(pduType_0, dataInputStream_);
	}

	public StringBuilder XmlDecodePdu(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
		{
			try
			{
				methodCallback = new XmlSerializer(object_0.GetType());
				methodCallback.Serialize(stringWriter, object_0);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				stringBuilder.Append(stringWriter.ToString());
				stringWriter.Close();
			}
		}
		return stringBuilder;
	}

	protected virtual object ProcessPdu(Stream stream_0)
	{
		int num = 0;
		long position = stream_0.Position;
		byte[] array = new byte[10];
		stream_0.Read(array, 0, 10);
		try
		{
			num = LoginDecorator(array, _RulesCallback);
			byte[] array2 = new byte[num];
			stream_0.Position = position;
			stream_0.Read(array2, 0, num);
			byte uint_ = array2[2];
			byte byte_ = array2[0];
			return SwitchOnType(byte_, uint_, array2);
		}
		catch
		{
			return null;
		}
	}

	protected virtual List<object> ProcessPdu(byte[] byte_0)
	{
		List<object> list = new List<object>();
		if (byte_0.Length < 1)
		{
			return list;
		}
		int num = byte_0.Length;
		int num2 = 0;
		uint num3 = 0u;
		while (num2 < num)
		{
			try
			{
				num3 = LoginDecorator(byte_0, _RulesCallback, (uint)(8uL + (ulong)num2));
				if (num3 == 0)
				{
					return list;
				}
				byte uint_ = byte_0[2L + (long)num2];
				byte byte_ = byte_0[num2];
				byte[] array = new byte[num3];
				Array.Copy(byte_0, num2, array, 0, (int)num3);
				list.Add(SwitchOnType(byte_, uint_, array));
				num2 += (int)num3;
			}
			catch
			{
				return list;
			}
		}
		return list;
	}

	protected virtual void ProcessPdu(Stream stream_0, out byte[] byte_0)
	{
		int num = 0;
		long position = stream_0.Position;
		byte[] array = new byte[10];
		stream_0.Read(array, 0, 10);
		try
		{
			num = LoginDecorator(array, _RulesCallback);
			byte_0 = new byte[num];
			stream_0.Position = position;
			stream_0.Read(byte_0, 0, num);
		}
		catch
		{
			byte_0 = null;
		}
	}

	protected virtual List<byte[]> ProcessRawPdu(byte[] byte_0)
	{
		List<byte[]> list = new List<byte[]>();
		if (byte_0.Length < 1)
		{
			return list;
		}
		int num = byte_0.Length;
		int num2 = 0;
		uint num3 = 0u;
		while (num2 < num)
		{
			try
			{
				num3 = LoginDecorator(byte_0, _RulesCallback);
				if (num3 == 0)
				{
					return list;
				}
				byte[] array = new byte[num3];
				Array.Copy(byte_0, num2, array, 0, (int)num3);
				list.Add(array);
				num2 += (int)num3;
			}
			catch
			{
				return list;
			}
		}
		return list;
	}

	protected virtual object SwitchOnType(byte byte_0, uint uint_0, byte[] byte_1)
	{
		object result = null;
		DataInputStream dataInputStream_ = new DataInputStream(byte_1, Endian);
		if (byte_0 != 5 && byte_0 == 6)
		{
			result = UnmarshalRawPdu((PduType)uint_0, dataInputStream_);
		}
		return result;
	}

	private static ushort LoginDecorator(byte[] byte_0, Endian endian_0, uint uint_0 = 8u)
	{
		byte[] array = new byte[2];
		if (endian_0 == Endian.Big)
		{
			array[0] = byte_0[uint_0 + 1];
			array[1] = byte_0[uint_0];
		}
		else
		{
			array[0] = byte_0[uint_0];
			array[1] = byte_0[uint_0 + 1];
		}
		return BitConverter.ToUInt16(array, 0);
	}

	[Obsolete("This method used Reflection which is slow, new method 'UnmarshallRawPdu' should be used instead.")]
	private static void GetDecorator(object object_0, object object_1)
	{
		object_0.GetType().InvokeMember("Unmarshal", BindingFlags.InvokeMethod, null, object_0, new object[1] { object_1 }, CultureInfo.InvariantCulture);
	}
}
