using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_Side
{
	[CompilerGenerated]
	private sealed class InitializerMerchantService
	{
		public Contact Local_MasterContact;

		public Contact Local_theOtherContact;

		internal void TestInterruptibleQueue()
		{
			Local_MasterContact.UncertaintyArea = ActiveUnit_Sensory.GetRefinedUncertaintyArea_Clipper(Local_MasterContact.UncertaintyArea, Local_theOtherContact.UncertaintyArea);
		}
	}

	public static bool IsAlliedWithThisSide(Side side_0, Side side_1)
	{
		if (side_0.GetConsidersThisSideToBe(side_1) == Misc.PostureStance.Friendly)
		{
			if (side_1.GetConsidersThisSideToBe(side_0) == Misc.PostureStance.Friendly)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static void UpdateMasterContactDataFromOtherContact(Side side_0, Contact contact_0, Contact contact_1, ActiveUnit activeUnit_0, Scenario scenario_0, bool bool_0)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		if (contact_0.Age > contact_1.Age)
		{
			if (!contact_0.ActualUnit.GetIsAutoDetectable(side_0))
			{
				if (contact_1.SpeedIsKnown && !contact_0.SpeedIsKnown)
				{
					contact_0.SpeedIsKnown = true;
					flag = true;
				}
				if (contact_1.HeadingIsKnown && !contact_0.HeadingIsKnown)
				{
					contact_0.HeadingIsKnown = true;
					flag = true;
				}
				if (contact_1.AltitudeIsKnown && !contact_0.AltitudeIsKnown)
				{
					contact_0.AltitudeIsKnown = true;
					flag = true;
				}
				if (contact_0.GetLongitude() != contact_1.GetLongitude())
				{
					contact_0.SetLongitude(null, contact_1.GetLongitude());
					flag = true;
				}
				if (contact_0.GetLatitude() != contact_1.GetLatitude())
				{
					contact_0.SetLatitude(null, contact_1.GetLatitude());
					flag = true;
				}
				if (contact_0.GetCurrentAltitude() != contact_1.GetCurrentAltitude())
				{
					contact_0.SetCurrentAltitude(bool_0: false, contact_1.GetCurrentAltitude());
					flag = true;
				}
				if (contact_0.CurrentHeading != contact_1.CurrentHeading)
				{
					contact_0.CurrentHeading = contact_1.CurrentHeading;
					flag = true;
				}
				if (bool_0 && (contact_0.UncertaintyArea != null || contact_1.UncertaintyArea != null))
				{
					if (contact_0.UncertaintyArea != null && contact_1.UncertaintyArea != null)
					{
						Task task = new Task(delegate
						{
							contact_0.UncertaintyArea = ActiveUnit_Sensory.GetRefinedUncertaintyArea_Clipper(contact_0.UncertaintyArea, contact_1.UncertaintyArea);
						});
						GameGeneral._DefinitionDic.Add(task);
						task.Start();
						flag = true;
					}
					else if ((contact_0.UncertaintyArea != null || contact_1.UncertaintyArea == null) && contact_0.UncertaintyArea != null && contact_1.UncertaintyArea == null)
					{
						contact_0.UncertaintyArea = null;
						flag = true;
					}
				}
				contact_0.Age = contact_1.Age;
				contact_0.HeldFor = contact_1.HeldFor;
			}
			if ((!contact_0.SideIsKnown || !contact_1.SideIsKnown) && (!contact_0.SideIsKnown || contact_1.SideIsKnown) && !contact_0.SideIsKnown && contact_1.SideIsKnown)
			{
				contact_0.SideIsKnown = true;
				flag2 = true;
			}
			ActiveUnit_Sensory.MergeDetectedEmissions(contact_0, contact_1.DetectedEmissions);
			if (contact_0.ListOfESMMatches != null && contact_1.ListOfESMMatches != null)
			{
				contact_0.ListOfESMMatches = contact_0.ListOfESMMatches.Union(contact_1.ListOfESMMatches).ToList();
				flag3 = true;
			}
			if (!contact_0.ActualUnit.GetIsAutoDetectable(side_0))
			{
				if (contact_0.m_EventObserver.HasValue)
				{
					if (contact_1.m_EventObserver.HasValue)
					{
						contact_0.m_EventObserver = Math.Min(contact_0.m_EventObserver.Value, contact_1.m_EventObserver.Value);
					}
				}
				else if (contact_1.m_EventObserver.HasValue)
				{
					contact_0.m_EventObserver = contact_1.m_EventObserver.Value;
				}
				if (contact_0.globalObserver.HasValue)
				{
					if (contact_1.globalObserver.HasValue)
					{
						contact_0.globalObserver = Math.Min(contact_0.globalObserver.Value, contact_1.globalObserver.Value);
					}
				}
				else if (contact_1.globalObserver.HasValue)
				{
					contact_0.globalObserver = contact_1.globalObserver.Value;
				}
				if (contact_0.m_WorkerObserver.HasValue)
				{
					if (contact_1.m_WorkerObserver.HasValue)
					{
						contact_0.m_WorkerObserver = Math.Min(contact_0.m_WorkerObserver.Value, contact_1.m_WorkerObserver.Value);
					}
				}
				else if (contact_1.m_WorkerObserver.HasValue)
				{
					contact_0.m_WorkerObserver = contact_1.m_WorkerObserver.Value;
				}
				if (contact_0.m_AccountObserver.HasValue)
				{
					if (contact_1.m_AccountObserver.HasValue)
					{
						contact_0.m_AccountObserver = Math.Min(contact_0.m_AccountObserver.Value, contact_1.m_AccountObserver.Value);
					}
				}
				else if (contact_1.m_AccountObserver.HasValue)
				{
					contact_0.m_AccountObserver = contact_1.m_AccountObserver.Value;
				}
				if (contact_0.stateObserver.HasValue)
				{
					if (contact_1.stateObserver.HasValue)
					{
						contact_0.stateObserver = Math.Min(contact_0.stateObserver.Value, contact_1.stateObserver.Value);
					}
				}
				else if (contact_1.stateObserver.HasValue)
				{
					contact_0.stateObserver = contact_1.stateObserver.Value;
				}
				if (contact_0.authenticationObserver.HasValue)
				{
					if (contact_1.authenticationObserver.HasValue)
					{
						contact_0.authenticationObserver = Math.Min(contact_0.authenticationObserver.Value, contact_1.authenticationObserver.Value);
					}
				}
				else if (contact_1.authenticationObserver.HasValue)
				{
					contact_0.authenticationObserver = contact_1.authenticationObserver.Value;
				}
			}
		}
		if (contact_0.TimeSinceBDA > contact_1.TimeSinceBDA)
		{
			if (contact_1.BDA_StructuralIntegrity.HasValue)
			{
				contact_0.BDA_StructuralIntegrity = contact_1.BDA_StructuralIntegrity;
			}
			if (contact_1.BDA_FireLevel.HasValue)
			{
				contact_0.BDA_FireLevel = contact_1.BDA_FireLevel;
			}
			if (contact_1.BDA_FloodLevel.HasValue)
			{
				contact_0.BDA_FloodLevel = contact_1.BDA_FloodLevel;
			}
			flag4 = true;
		}
		if (contact_0.TimeSinceRecon > contact_1.TimeSinceRecon)
		{
			foreach (Contact.HostedUnitReconRecord item in contact_1.IncludeImporter(side_0))
			{
				Contact.HostedUnitReconRecord hostedUnitReconRecord = item;
				bool flag7 = false;
				foreach (Contact.HostedUnitReconRecord item2 in contact_0.IncludeImporter(side_0))
				{
					if (Operators.CompareString(item2.UnitID, hostedUnitReconRecord.UnitID, TextCompare: false) == 0)
					{
						flag7 = true;
						if (item2.IDStatus > hostedUnitReconRecord.IDStatus)
						{
							hostedUnitReconRecord = item2;
						}
					}
				}
				if (!flag7)
				{
					Contact.HostedUnitReconRecord hostedUnitReconRecord2 = new Contact.HostedUnitReconRecord();
					hostedUnitReconRecord2.UnitID = hostedUnitReconRecord.UnitID;
					hostedUnitReconRecord2.IDStatus = hostedUnitReconRecord.IDStatus;
					hostedUnitReconRecord2.ReconAge = hostedUnitReconRecord.ReconAge;
					contact_0.IncludeImporter(side_0).Add(hostedUnitReconRecord2);
				}
			}
			flag5 = true;
		}
		if (contact_1.IDStatus > contact_0.IDStatus)
		{
			contact_0.method_0(scenario_0, side_0, null, null, bool_0: false, bool_1: true, bool_2: false, bool_3: true, contact_1.IDStatus);
			scenario_0.AddMessage("目标：" + contact_0.Name + "现在被认为是：" + contact_1.Name, contact_0.Name + " renamed", LoggedMessage.MessageType.ContactChange, 0, null, side_0, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
			contact_0.Name = contact_1.Name;
			flag6 = true;
		}
		if ((flag || flag2 || flag3 || flag4 || flag5 || flag6) && activeUnit_0 != null)
		{
			string text = "更新目标数据：" + contact_0.Name + "，基于以下新信息：" + activeUnit_0.Name + "。更新信息包括：";
			List<string> list = new List<string>();
			if (flag)
			{
				list.Add("position data");
			}
			if (flag2)
			{
				list.Add("side info");
			}
			if (flag3)
			{
				list.Add("ESM data");
			}
			if (flag4)
			{
				list.Add("BDA data");
			}
			if (flag5)
			{
				list.Add("info on hosted units");
			}
			if (flag6)
			{
				list.Add("ID status");
			}
			text = text + string.Join(", ", list) + ".";
			activeUnit_0.AddMessage(text, "目标已更新", LoggedMessage.MessageType.ContactChange, 0, bool_0: false, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
		}
	}

	public static void ShareContactWithFriends(Side side_0, Scenario scenario_0, Contact contact_0)
	{
		if (side_0.Units.Count <= 0)
		{
			return;
		}
		HashSet<string> hashSet = GameGeneral.m_ManagerClient[side_0.ObjectID];
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (side == side_0 || !hashSet.Contains(side.ObjectID) || Information.IsNothing(contact_0.ActualUnit))
			{
				continue;
			}
			Contact contact = null;
			if (side.Contacts.TryGetValue(contact_0.ActualUnit.ObjectID, ref contact))
			{
				Contact.smethod_0(contact_0, contact);
				bool flag = side.GetConsidersThisSideToBe(side_0) == Misc.PostureStance.Friendly;
				if (contact_0 != contact)
				{
					UpdateMasterContactDataFromOtherContact(side, contact, contact_0, null, scenario_0, bool_0: true);
					if (flag)
					{
						UpdateMasterContactDataFromOtherContact(side_0, contact_0, contact, null, scenario_0, bool_0: true);
					}
					side.ContactsJustSharedWithMe.Add(contact_0.ActualUnit.ObjectID);
				}
			}
			else if (!IsAlliedWithThisSide(contact_0.ActualUnit.GetUnitSide(), side) && contact_0.ActualUnit.GetUnitSide() != side && side.Units.Count > 0)
			{
				side.AddContact(contact_0);
				side.ContactsJustSharedWithMe.Add(contact_0.ActualUnit.ObjectID);
			}
		}
	}
}
