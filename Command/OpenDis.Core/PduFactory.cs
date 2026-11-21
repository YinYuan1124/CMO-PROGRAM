using System;
using Command.Maps;
using OpenDis.Dis1998;
using OpenDis.Enumerations;

namespace OpenDis.Core;

public static class PduFactory
{
	public static IPdu CreatePdu(byte byte_0, ProtocolVersion protocolVersion_0)
	{
		return CreatePdu((PduType)byte_0, protocolVersion_0);
	}

	public static IPdu CreatePdu(PduType pduType_0, ProtocolVersion protocolVersion_0)
	{
		if (1 == 0)
		{
		}
		IPdu result = protocolVersion_0 switch
		{
			ProtocolVersion.Ieee1278_1A_1998 => OpenDis.Dis1998.PduFactory.CreatePdu(pduType_0), 
			ProtocolVersion.Ieee1278_1_1995 => ComparatorCallback.CallDecorator(pduType_0), 
			_ => throw new ArgumentException("Unsupported protocol version."), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
