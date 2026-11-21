using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_ActiveUnit_Sensory
{
	internal static List<Contact> ListTokenizer(object object_0)
	{
		if (((ActiveUnit_Sensory)object_0).strategyWrapper.CommStuff.IsConnectedToSideNetwork)
		{
			return ((ActiveUnit_Sensory)object_0).strategyWrapper.GetUnitSide().Contacts_List;
		}
		return ((ActiveUnit_Sensory)object_0).PrivateContactList();
	}
}
