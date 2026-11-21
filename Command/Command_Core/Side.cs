using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Side : ScenarioObject
{
	public delegate void SelectedUnitsChangedEventHandler();

	public delegate void ScoreChangedEventHandler(Side theSide);

	public delegate void MissionsChangedEventHandler(Side theSide);

	public delegate void ContactAddedEventHandler(string theSideID, string ContactActualUnitID);

	public delegate void ContactRemovedEventHandler(string theSideID, string ContactActualUnitID);

	public delegate void BaseContactAddedEventHandler(string theSideID, string ContactActualUnitID);

	public delegate void BaseContactRemovedEventHandler(string theSideID, string ContactActualUnitID);

	public class _AAR
	{
		public Dictionary<int, int> Expenditures;

		public Dictionary<int, int> WeaponsLost;

		public Dictionary<string, HashSet<string>> Losses;

		public _AAR()
		{
			Losses = new Dictionary<string, HashSet<string>>();
			Expenditures = new Dictionary<int, int>();
			WeaponsLost = new Dictionary<int, int>();
		}

		public void AddToExpenditures(int int_0, int int_1)
		{
			if (Expenditures == null)
			{
				Expenditures = new Dictionary<int, int>();
			}
			if (Expenditures.ContainsKey(int_0))
			{
				Expenditures[int_0] += int_1;
				return;
			}
			try
			{
				Expenditures.Add(int_0, int_1);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				Expenditures.Add(int_0, int_1);
				ProjectData.ClearProjectError();
			}
		}

		public void AddToWeaponsLost(int int_0, int int_1)
		{
			if (WeaponsLost == null)
			{
				WeaponsLost = new Dictionary<int, int>();
			}
			if (WeaponsLost.ContainsKey(int_0))
			{
				WeaponsLost[int_0] += int_1;
			}
			else
			{
				WeaponsLost.Add(int_0, int_1);
			}
		}

		public void AddToLosses(ScenarioObject scenarioObject_0, bool bool_0)
		{
			if (Information.IsNothing(Losses))
			{
				Losses = new Dictionary<string, HashSet<string>>();
			}
			int num = 1;
			string text = null;
			if (scenarioObject_0.IsActiveUnit && ((ActiveUnit)scenarioObject_0).IsDecoy)
			{
				text += "_[DECOY]";
				num = -1;
			}
			if (scenarioObject_0.IsAircraft)
			{
				text = "Aircraft_" + Conversions.ToString(num * ((Aircraft)scenarioObject_0).DBID);
			}
			else if (scenarioObject_0.IsShip)
			{
				text = "Ship_" + Conversions.ToString(num * ((Ship)scenarioObject_0).DBID);
			}
			else if (scenarioObject_0.IsSubmarine)
			{
				text = "Submarine_" + Conversions.ToString(num * ((Submarine)scenarioObject_0).DBID);
			}
			else if (scenarioObject_0.IsFacility)
			{
				text = "Facility_" + Conversions.ToString(num * ((Facility)scenarioObject_0).DBID);
			}
			else if (scenarioObject_0.IsMobileGroundUnit)
			{
				text = "GroundUnit_" + Conversions.ToString(num * ((Vehicle)scenarioObject_0).DBID);
			}
			else if (bool_0)
			{
				text = "FacilityAimpoint_" + Conversions.ToString(((Mount)scenarioObject_0).DBID);
			}
			else if (scenarioObject_0.IsSatellite)
			{
				text = "Satellite_" + Conversions.ToString(((Satellite)scenarioObject_0).DBID);
			}
			else if (scenarioObject_0 is UnguidedWeapon && ((UnguidedWeapon)scenarioObject_0).IsMine)
			{
				text = "Weapon_" + Conversions.ToString(((UnguidedWeapon)scenarioObject_0).CancelWatcher());
			}
			else if (scenarioObject_0 is Cargo)
			{
				text = ((Cargo)scenarioObject_0).CargoObjectLossString;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (Losses.ContainsKey(text))
			{
				Losses[text].Add(scenarioObject_0.ObjectID);
				return;
			}
			HashSet<string> hashSet = new HashSet<string>();
			hashSet.Add(scenarioObject_0.ObjectID);
			Losses.Add(text, hashSet);
		}

		public string ToCSV(Scenario scenario_0, string string_0)
		{
			string result = null;
			try
			{
				string text = "";
				string text2 = "";
				if (Information.IsNothing(Losses))
				{
					Losses = new Dictionary<string, HashSet<string>>();
				}
				foreach (KeyValuePair<string, HashSet<string>> loss in Losses)
				{
					text2 = "Loss".Replace(string_0, "") + string_0;
					text2 = text2 + loss.Key.ToString().Replace(string_0, "") + string_0;
					text2 = text2 + loss.Value.ToString().Replace(string_0, "") + string_0;
					text2 = text2 + AwakeInterruptibleReg(scenario_0, loss).Replace(string_0, "") + string_0;
					text = ((Operators.CompareString(text, "", TextCompare: false) == 0) ? text2 : (text + Environment.NewLine + text2));
				}
				if (Information.IsNothing(Expenditures))
				{
					Expenditures = new Dictionary<int, int>();
				}
				foreach (KeyValuePair<int, int> expenditure in Expenditures)
				{
					text2 = "Expenditure".Replace(string_0, "") + string_0;
					text2 = text2 + expenditure.Key.ToString().Replace(string_0, "") + string_0;
					text2 = text2 + expenditure.Value.ToString().Replace(string_0, "") + string_0;
					text2 = text2 + PublishInterruptibleReg(scenario_0, expenditure).Replace(string_0, "") + string_0;
					text = ((Operators.CompareString(text, "", TextCompare: false) == 0) ? text2 : (text + Environment.NewLine + text2));
				}
				if (WeaponsLost == null)
				{
					WeaponsLost = new Dictionary<int, int>();
				}
				foreach (KeyValuePair<int, int> item in WeaponsLost)
				{
					text2 = "Weapon Loss".Replace(string_0, "") + string_0;
					text2 = text2 + item.Key.ToString().Replace(string_0, "") + string_0;
					text2 = text2 + item.Value.ToString().Replace(string_0, "") + string_0;
					text2 = text2 + PublishInterruptibleReg(scenario_0, item).Replace(string_0, "") + string_0;
					text = ((Operators.CompareString(text, "", TextCompare: false) == 0) ? text2 : (text + Environment.NewLine + text2));
				}
				result = text;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 987651321563", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public void ToXML(ref XmlWriter xmlWriter_0, Scenario scenario_0 = null)
		{
			if (scenario_0 == null)
			{
				try
				{
					xmlWriter_0.WriteStartElement("AAR");
					if (Losses == null)
					{
						Losses = new Dictionary<string, HashSet<string>>();
					}
					if (Losses.Count > 0)
					{
						xmlWriter_0.WriteStartElement("Losses");
						Dictionary<string, HashSet<string>>.Enumerator enumerator = Losses.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								KeyValuePair<string, HashSet<string>> current = enumerator.Current;
								if (current.Value.Count > 0)
								{
									xmlWriter_0.WriteElementString(current.Key.ToString(), string.Join("_", current.Value));
								}
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						xmlWriter_0.WriteEndElement();
					}
					if (Expenditures == null)
					{
						Expenditures = new Dictionary<int, int>();
					}
					if (Expenditures.Count > 0)
					{
						xmlWriter_0.WriteStartElement("Expenditures");
						Dictionary<int, int>.Enumerator enumerator2 = Expenditures.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								KeyValuePair<int, int> current2 = enumerator2.Current;
								xmlWriter_0.WriteElementString("Weapon_" + current2.Key, current2.Value.ToString());
							}
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
						xmlWriter_0.WriteEndElement();
					}
					if (WeaponsLost == null)
					{
						WeaponsLost = new Dictionary<int, int>();
					}
					if (WeaponsLost.Count > 0)
					{
						xmlWriter_0.WriteStartElement("WeaponsLost");
						Dictionary<int, int>.Enumerator enumerator3 = WeaponsLost.GetEnumerator();
						try
						{
							while (enumerator3.MoveNext())
							{
								KeyValuePair<int, int> current3 = enumerator3.Current;
								xmlWriter_0.WriteElementString("Weapon_" + current3.Key, current3.Value.ToString());
							}
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							ProjectData.ClearProjectError();
						}
						xmlWriter_0.WriteEndElement();
					}
					xmlWriter_0.WriteEndElement();
					return;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101068", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			try
			{
				xmlWriter_0.WriteStartElement("AAR");
				if (Information.IsNothing(Losses))
				{
					Losses = new Dictionary<string, HashSet<string>>();
				}
				xmlWriter_0.WriteStartElement("Losses");
				foreach (KeyValuePair<string, HashSet<string>> loss in Losses)
				{
					xmlWriter_0.WriteStartElement("Unit");
					xmlWriter_0.WriteElementString("ID", loss.Key.ToString());
					xmlWriter_0.WriteElementString("Quantity", loss.Value.ToString());
					xmlWriter_0.WriteElementString("Name", AwakeInterruptibleReg(scenario_0, loss) + "\r\n");
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
				if (Information.IsNothing(Expenditures))
				{
					Expenditures = new Dictionary<int, int>();
				}
				xmlWriter_0.WriteStartElement("Expenditures");
				foreach (KeyValuePair<int, int> expenditure in Expenditures)
				{
					xmlWriter_0.WriteStartElement("Weapon");
					xmlWriter_0.WriteElementString("ID", expenditure.Key.ToString());
					xmlWriter_0.WriteElementString("Quantity", expenditure.Value.ToString());
					xmlWriter_0.WriteElementString("Name", PublishInterruptibleReg(scenario_0, expenditure) + "\r\n");
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
				if (WeaponsLost == null)
				{
					WeaponsLost = new Dictionary<int, int>();
				}
				xmlWriter_0.WriteStartElement("WeaponsLost");
				foreach (KeyValuePair<int, int> item in WeaponsLost)
				{
					xmlWriter_0.WriteStartElement("Weapon");
					xmlWriter_0.WriteElementString("ID", item.Key.ToString());
					xmlWriter_0.WriteElementString("Quantity", item.Value.ToString());
					xmlWriter_0.WriteElementString("Name", PublishInterruptibleReg(scenario_0, item) + "\r\n");
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteEndElement();
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 987651321564", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static _AAR FromXML(ref XmlNode xmlNode_0)
		{
			_AAR aAR = new _AAR();
			try
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					IEnumerator enumerator3 = null;
					IEnumerator enumerator4 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						switch (xmlNode.Name)
						{
						case "WeaponsLost":
							try
							{
								enumerator4 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									XmlNode xmlNode4 = (XmlNode)enumerator4.Current;
									string[] array2 = xmlNode4.Name.Split('_');
									int key2 = Conversions.ToInteger(array2[1]);
									int num5 = Conversions.ToInteger(xmlNode4.InnerText);
									if (aAR.WeaponsLost.ContainsKey(key2))
									{
										aAR.WeaponsLost[key2] += num5;
									}
									else
									{
										aAR.WeaponsLost.Add(Conversions.ToInteger(array2[1]), Conversions.ToInteger(xmlNode4.InnerText));
									}
								}
							}
							finally
							{
								if (enumerator4 is IDisposable)
								{
									(enumerator4 as IDisposable).Dispose();
								}
							}
							break;
						case "Losses":
							try
							{
								enumerator3 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
									if (Operators.CompareString(xmlNode3.Name.ToString().Split('_')[0], "Custom", TextCompare: false) == 0)
									{
										if (xmlNode3.InnerText.Length != 0 && Operators.CompareString(xmlNode3.InnerText, "0", TextCompare: false) != 0)
										{
											HashSet<string> value = new HashSet<string> { xmlNode3.InnerText };
											aAR.Losses.Add(xmlNode3.Name, value);
										}
										continue;
									}
									if (Versioned.IsNumeric(xmlNode3.InnerText))
									{
										int num2 = Conversions.ToInteger(xmlNode3.InnerText);
										HashSet<string> hashSet = new HashSet<string>();
										int num3 = num2;
										for (int i = 1; i <= num3; i++)
										{
											hashSet.Add(Guid.NewGuid().ToString());
										}
										aAR.Losses.Add(xmlNode3.Name, hashSet);
										continue;
									}
									List<string> list = xmlNode3.InnerText.Split('_').ToList();
									int count = list.Count;
									HashSet<string> hashSet2 = new HashSet<string>();
									int num4 = count - 1;
									for (int j = 0; j <= num4; j++)
									{
										hashSet2.Add(list[j]);
									}
									aAR.Losses.Add(xmlNode3.Name, hashSet2);
								}
							}
							finally
							{
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
							break;
						case "Expenditures":
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
									string[] array = xmlNode2.Name.Split('_');
									int key = Conversions.ToInteger(array[1]);
									int num = Conversions.ToInteger(xmlNode2.InnerText);
									if (aAR.Expenditures.ContainsKey(key))
									{
										aAR.Expenditures[key] += num;
									}
									else
									{
										aAR.Expenditures.Add(Conversions.ToInteger(array[1]), Conversions.ToInteger(xmlNode2.InnerText));
									}
								}
							}
							finally
							{
								if (enumerator2 is IDisposable)
								{
									(enumerator2 as IDisposable).Dispose();
								}
							}
							break;
						}
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				return aAR;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101069", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				_AAR result = new _AAR();
				ProjectData.ClearProjectError();
				return result;
			}
		}

		internal string PublishInterruptibleReg(Scenario scenario_0, KeyValuePair<int, int> keyValuePair_0)
		{
			DataRow[] array = scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(keyValuePair_0.Key));
			if (array.Count() <= 0)
			{
				return string.Empty;
			}
			return Misc.ReadRequest(array[0]["Name"].ToString());
		}

		internal string AwakeInterruptibleReg(Scenario scenario_0, KeyValuePair<string, HashSet<string>> keyValuePair_0)
		{
			string[] array = keyValuePair_0.Key.ToString().Split('_');
			string result = "";
			switch (array[0].ToString())
			{
			case "Submarine":
				result = Misc.ReadRequest(scenario_0.Cache_Subs_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Ship":
				result = Misc.ReadRequest(scenario_0.Cache_Ships_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Facility":
				result = Misc.ReadRequest(scenario_0.Cache_Facilities_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Custom":
				result = array[1];
				break;
			case "Weapon":
				result = Misc.ReadRequest(scenario_0.Cache_Weapons_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Aircraft":
				result = Misc.ReadRequest(scenario_0.Cache_Aircraft_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "FacilityAimpoint":
			case "FacilityAimpointCargo":
				result = ((Operators.CompareString(array[1], "0", TextCompare: false) == 0) ? "不可识别的陆地目标点  - 对不起！" : Misc.ReadRequest(DBFunctions.GetMountName(Conversions.ToInteger(array[1]), ref scenario_0)));
				break;
			}
			return result;
		}
	}

	[DoNotObfuscate]
	public enum AwarenessLevel_Enum
	{
		Blind = -1,
		Normal,
		AutoSideID,
		AutoSideAndUnitID,
		Omniscient
	}

	[CompilerGenerated]
	private sealed class RoleItem
	{
		public WeaponSalvo Local_theWS;

		public Func<WeaponRec, bool> _003C_003E9__1;

		internal bool QueryInterruptibleReg(WeaponRec theWRec)
		{
			return theWRec.int_0 == Local_theWS.int_0;
		}
	}

	[CompilerGenerated]
	private sealed class FactoryItem
	{
		public WeaponSalvo.Shooter Local_theS;

		internal bool ResetInterruptibleReg(ActiveUnit AU)
		{
			return Operators.CompareString(AU.ObjectID, Local_theS.ShooterObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class AttributeItem
	{
		public Scenario Local_theScen;

		public Side Me;

		internal void MapInterruptibleReg(Contact theContact)
		{
			theContact.HasBeenCheckedForDestructionThisPulse = false;
			theContact.GetIsDestroyed(Local_theScen);
			Me.Cache_ContactStancesOnThisPulse[theContact.ObjectID] = theContact.GetStance(Me);
		}
	}

	[CompilerGenerated]
	private sealed class EventItem
	{
		public Scenario Local_theScen;

		public Side Me;

		public float Local_elapsedTime;

		internal void SortInterruptibleReg(FiringProposal firingProposal_0)
		{
			WrapperProcessProducer CS_0024_003C_003E8__locals0 = new WrapperProcessProducer
			{
				Local_theFPToREc = firingProposal_0
			};
			Mission mission = ((ActiveUnit)CS_0024_003C_003E8__locals0.Local_theFPToREc.FiringUnit).AssignedMissionOrPackage();
			if (!((mission != null) & !CS_0024_003C_003E8__locals0.Local_theFPToREc.FiringUnit.IsAircraft))
			{
				return;
			}
			if (Needs_To_Recalculate_Weapon_ETA(CS_0024_003C_003E8__locals0.Local_theFPToREc.FiringUnit, CS_0024_003C_003E8__locals0.Local_theFPToREc.Target))
			{
				((ActiveUnit)CS_0024_003C_003E8__locals0.Local_theFPToREc.FiringUnit).Weaponry.ReadConsumer(CS_0024_003C_003E8__locals0.Local_theFPToREc.Target, CS_0024_003C_003E8__locals0.Local_theFPToREc.GetReferenceWeapon(Local_theScen));
			}
			DateTime? timeOnTarget = mission.TimeOnTarget;
			DateTime eTA = CS_0024_003C_003E8__locals0.Local_theFPToREc.ETA;
			if ((timeOnTarget.HasValue ? new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), eTA) > 0) : null).GetValueOrDefault())
			{
				FiringProposal firingProposal = Me.callbackProxy.Values.Where((FiringProposal FP) => (Operators.CompareString(FP.Target.ObjectID, CS_0024_003C_003E8__locals0.Local_theFPToREc.Target.ObjectID, TextCompare: false) == 0) & (Operators.CompareString(FP.FiringUnit.ObjectID, CS_0024_003C_003E8__locals0.Local_theFPToREc.FiringUnit.ObjectID, TextCompare: false) == 0)).FirstOrDefault();
				if (firingProposal != null)
				{
					firingProposal.ETA = firingProposal.ETA.AddSeconds(Local_elapsedTime);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class WrapperProcessProducer
	{
		public FiringProposal Local_theFPToREc;

		internal bool CalcInterruptibleReg(FiringProposal FP)
		{
			return (Operators.CompareString(FP.Target.ObjectID, Local_theFPToREc.Target.ObjectID, TextCompare: false) == 0) & (Operators.CompareString(FP.FiringUnit.ObjectID, Local_theFPToREc.FiringUnit.ObjectID, TextCompare: false) == 0);
		}
	}

	[CompilerGenerated]
	private sealed class RefObjectListener
	{
		public Weapon Local_theW;

		internal bool RateInterruptibleReg(WeaponSalvo.Shooter x)
		{
			return Operators.CompareString(x.ShooterObjectID, Local_theW.FiringParent.ObjectID, TextCompare: false) == 0;
		}

		internal bool FlushInterruptibleReg(WeaponSalvo.Shooter x)
		{
			return Operators.CompareString(x.ShooterObjectID, Local_theW.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class GlobalItem
	{
		public ActiveUnit Local_theUnit;

		internal bool ForgotInterruptibleReg(Contact theC)
		{
			return theC.ActualUnit == Local_theUnit;
		}
	}

	[CompilerGenerated]
	private sealed class MappingThreadBridge
	{
		public ActiveUnit theUnit;

		internal bool CollectInterruptibleReg(Contact theC)
		{
			return theC.ActualUnit == theUnit;
		}
	}

	[CompilerGenerated]
	private sealed class MockThreadBridge
	{
		public string Local_sideHash;

		internal bool OrderInterruptibleReg(Side F)
		{
			return Operators.CompareString(F.ObjectID, Local_sideHash, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ObserverProcessProducer
	{
		public Module_Unit.Unit firingUnit;

		public Contact target;

		internal bool RegisterInterruptibleReg(FiringProposal theFP)
		{
			return (Operators.CompareString(theFP.FiringUnit.ObjectID, firingUnit.ObjectID, TextCompare: false) == 0) & (Operators.CompareString(theFP.Target.ObjectID, target.ObjectID, TextCompare: false) == 0);
		}
	}

	[CompilerGenerated]
	private sealed class WrapperCollectionTask
	{
		public string Local_theWeaponObjectID;

		internal bool ManageInterruptibleReg(UnguidedWeapon theW)
		{
			return Operators.CompareString(theW.ObjectID, Local_theWeaponObjectID, TextCompare: false) == 0;
		}
	}

	private string _ParserFacade;

	private Dictionary<Side, Misc.PostureStance> algoFacade;

	private Dictionary<string, Misc.PostureStance> _DatabaseFacade;

	public Color? AssignedFixedColor;

	public bool IsHumanControlled;

	internal List<ActiveUnit> interceptorFacade;

	internal List<ActiveUnit> m_MessageFacade;

	private string _ProductFacade;

	private string _AnnotationFacade;

	private List<Module_Unit.Unit> iteratorFacade;

	private GeoPoint _InitializerFacade;

	public double CameraAlt;

	private List<Mission> m_RoleFacade;

	private List<ScenarioGoal> factoryFacade;

	private int attributeFacade;

	public int? Scoring_Disaster;

	public int? Scoring_Triumph;

	private AwarenessLevel_Enum _EventFacade;

	private GlobalVariables.ProficiencyLevel? globalFacade;

	public Dictionary<string, SpecialAction> SpecialActions;

	[AccessedThroughProperty("_Contacts")]
	[CompilerGenerated]
	private ObservableDictionary<string, Contact> _WorkerFacade;

	[AccessedThroughProperty("_BaseContacts")]
	[CompilerGenerated]
	private ObservableDictionary<string, Contact> accountFacade;

	public HashSet<string> Contacts_NonAU;

	internal int m_StateFacade;

	internal int authenticationFacade;

	internal TDictionary<string, Contact> _ParamsFacade;

	internal TDictionary<string, Contact> m_InfoFacade;

	internal TDictionary<string, Contact> m_HelperFacade;

	internal TDictionary<string, Contact> m_MapperFacade;

	internal TDictionary<string, Contact> managerFacade;

	private bool getterFacade;

	public List<ActiveUnit> Units;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPoints_Slugtrail")]
	private ObservableList<ReferencePoint> producerFacade;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPoints")]
	private ObservableList<ReferencePoint> _ProcFacade;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPointsTag_raw")]
	private Dictionary<string, ReferencePointFlag> m_StructProxy;

	public Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>> RefPointsTag;

	public int TagsCumulativeCount;

	private List<ActiveUnit> merchantProxy;

	public Doctrine Doctrine;

	public _AAR AAR;

	public List<ExclusionZone> ExclusionZones;

	public List<NoNavZone> NoNavZones;

	public List<CustomEnvironmentZone> CustomEnvironmentZones;

	public List<Zone> StandardZones;

	public bool AssignsCollectiveResponsibility;

	public bool CanAutoTrackCivs;

	public Dictionary<int, QuickJumpSlot> QuickJumpSlots;

	public WeaponSalvo[] WeaponSalvos;

	internal ConcurrentDictionary<string, FiringProposal> callbackProxy;

	public Scenario ParentScen;

	public List<string> ScoringLog;

	private int decoratorProxy;

	public Dictionary<string, Misc.PostureStance> Cache_ContactStancesOnThisPulse;

	internal ConcurrentDictionary<string, int> processProxy;

	private Dictionary<Contact, List<WeaponSalvo>> m_ThreadProxy;

	internal TDictionary<string, bool> ruleProxy;

	private MapProfile m_CollectionProxy;

	private List<ActiveUnit> m_InstanceProxy;

	private List<ActiveUnit> objectProxy;

	private List<Contact> m_ParameterProxy;

	private List<Contact> expressionProxy;

	private List<ActiveUnit> m_DispatcherProxy;

	private ActiveUnit[] m_ListenerProxy;

	private HashSet<string> m_ConfigProxy;

	private HashSet<string> m_RegistryProxy;

	internal Queue<Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>>> definitionProxy;

	[CompilerGenerated]
	private SelectedUnitsChangedEventHandler valProxy;

	private List<Module_Unit.Unit> _WrapperProxy;

	public EmconLevel EmconAlertness;

	public bool Nature;

	public List<Chalk> Chalks;

	private List<Chalk> _ObserverProxy;

	private Operation issuerProxy;

	public List<LandingPlan> LandingPlans;

	public bool DisableMultiDomainTOT;

	public HashSet<string> ContactsJustSharedWithMe;

	[ThreadStatic]
	private static StringBuilder m_ClientProxy;

	private ReadOnlyCollection<Mission> _DicProxy;

	private object consumerProxy;

	[CompilerGenerated]
	private static ScoreChangedEventHandler _FacadeProxy;

	[CompilerGenerated]
	private static MissionsChangedEventHandler proxyProxy;

	[CompilerGenerated]
	private static ContactAddedEventHandler m_ReaderProxy;

	[CompilerGenerated]
	private static ContactRemovedEventHandler propertyProxy;

	[CompilerGenerated]
	private static BaseContactAddedEventHandler m_ImporterProxy;

	[CompilerGenerated]
	private static BaseContactRemovedEventHandler m_RepositoryProxy;

	public ObservableList<ReferencePoint> RefPoints_Slugtrail
	{
		[CompilerGenerated]
		get
		{
			return producerFacade;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			producerFacade = value;
		}
	}

	public ObservableList<ReferencePoint> RefPoints
	{
		[CompilerGenerated]
		get
		{
			return _ProcFacade;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<ReferencePoint>> value2 = SortOrder;
			ObservableList<ReferencePoint> procFacade = _ProcFacade;
			if (procFacade != null)
			{
				procFacade.ItemsRemoved -= value2;
			}
			_ProcFacade = value;
			procFacade = _ProcFacade;
			if (procFacade != null)
			{
				procFacade.ItemsRemoved += value2;
			}
		}
	}

	public Dictionary<string, ReferencePointFlag> RefPointsTag_raw
	{
		[CompilerGenerated]
		get
		{
			return m_StructProxy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StructProxy = value;
		}
	}

	public Operation Operation
	{
		get
		{
			if (Information.IsNothing(issuerProxy))
			{
				issuerProxy = new Operation(this);
			}
			return issuerProxy;
		}
		set
		{
			issuerProxy = value;
		}
	}

	public ReadOnlyCollection<KeyValuePair<Side, Misc.PostureStance>> Postures_ReadOnly
	{
		get
		{
			List<KeyValuePair<Side, Misc.PostureStance>> list = new List<KeyValuePair<Side, Misc.PostureStance>>(algoFacade.Count);
			foreach (KeyValuePair<Side, Misc.PostureStance> item in algoFacade)
			{
				list.Add(item);
			}
			return list.AsReadOnly();
		}
	}

	public ObservableDictionary<string, Contact> Contacts => RateOrder();

	public ObservableDictionary<string, Contact> BaseContacts => CollectOrder();

	public string Briefing
	{
		get
		{
			if (string.IsNullOrEmpty(_AnnotationFacade))
			{
				return _ProductFacade;
			}
			if (string.IsNullOrEmpty(_AnnotationFacade))
			{
				return string.Empty;
			}
			return Crypto.ListImporter(_AnnotationFacade, "DaltonTrumbo");
		}
		set
		{
			_ProductFacade = string.Empty;
			if (string.IsNullOrEmpty(value))
			{
				_AnnotationFacade = value;
			}
			else
			{
				_AnnotationFacade = Crypto.VerifyImporter(value, "DaltonTrumbo");
			}
		}
	}

	public GlobalVariables.ProficiencyLevel Proficiency
	{
		get
		{
			if (!globalFacade.HasValue)
			{
				globalFacade = GlobalVariables.ProficiencyLevel.Regular;
			}
			return globalFacade.Value;
		}
		set
		{
			globalFacade = value;
		}
	}

	public GeoPoint MapCenter
	{
		get
		{
			if (Information.IsNothing(_InitializerFacade))
			{
				if (Units.Count <= 0)
				{
					_InitializerFacade = new GeoPoint(0.0, 0.0);
				}
				else
				{
					_InitializerFacade = new GeoPoint(Units[0].GetLongitude(), Units[0].GetLatitude());
				}
			}
			return _InitializerFacade;
		}
		set
		{
			_InitializerFacade = value;
		}
	}

	public AwarenessLevel_Enum AwarenessLevel
	{
		get
		{
			return _EventFacade;
		}
		set
		{
			_EventFacade = value;
		}
	}

	public int Scoring_MajorDefeat
	{
		get
		{
			if (Scoring_Disaster.HasValue && Scoring_Triumph.HasValue)
			{
				return (int)Math.Round(((double)Scoring_Average - (double?)((Scoring_Triumph - Scoring_Average) * 2) / 3.0).Value);
			}
			return 0;
		}
	}

	public int Scoring_MinorDefeat
	{
		get
		{
			if (Scoring_Disaster.HasValue && Scoring_Triumph.HasValue)
			{
				return (int)Math.Round(((double)Scoring_Average - (double?)(Scoring_Triumph - Scoring_Average) / 3.0).Value);
			}
			return 0;
		}
	}

	public int Scoring_Average
	{
		get
		{
			if (Scoring_Disaster.HasValue && Scoring_Triumph.HasValue)
			{
				return (int)Math.Round(((double?)Scoring_Triumph - (double?)(Scoring_Triumph - Scoring_Disaster) / 2.0).Value);
			}
			return 0;
		}
	}

	public int Scoring_MinorVictory
	{
		get
		{
			if (Scoring_Disaster.HasValue && Scoring_Triumph.HasValue)
			{
				return (int)Math.Round(((double)Scoring_Average + (double?)(Scoring_Triumph - Scoring_Average) / 3.0).Value);
			}
			return 0;
		}
	}

	public int Scoring_MajorVictory
	{
		get
		{
			if (Scoring_Disaster.HasValue && Scoring_Triumph.HasValue)
			{
				return (int)Math.Round(((double)Scoring_Average + (double?)((Scoring_Triumph - Scoring_Average) * 2) / 3.0).Value);
			}
			return 0;
		}
	}

	public ReadOnlyCollection<Mission> Missions => m_RoleFacade.AsReadOnly();

	public MapProfile SideMapProfile
	{
		get
		{
			if (m_CollectionProxy == null)
			{
				m_CollectionProxy = MapProfile.GetDefaultProfile();
			}
			return m_CollectionProxy;
		}
		set
		{
			m_CollectionProxy = value;
		}
	}

	public List<Module_Unit.Unit> KnownActiveNuclearWeapons
	{
		set
		{
			_WrapperProxy = value;
		}
	}

	public List<Contact> Contacts_List
	{
		get
		{
			if (m_ParameterProxy == null)
			{
				object obj = consumerProxy;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					m_ParameterProxy = new List<Contact>(Contacts.Values);
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			return m_ParameterProxy;
		}
		set
		{
			m_ParameterProxy = value;
		}
	}

	public List<Contact> BaseContacts_List
	{
		get
		{
			if (Information.IsNothing(expressionProxy))
			{
				expressionProxy = new List<Contact>();
				expressionProxy.AddRange(BaseContacts.Values);
				return expressionProxy;
			}
			if (expressionProxy.Count != BaseContacts.Count)
			{
				expressionProxy = new List<Contact>();
				expressionProxy.AddRange(BaseContacts.Values);
			}
			return expressionProxy;
		}
		set
		{
			expressionProxy = value;
		}
	}

	public new string Name
	{
		get
		{
			return _ParserFacade;
		}
		set
		{
			_ParserFacade = value;
		}
	}

	public bool IsAIOnly
	{
		get
		{
			return getterFacade;
		}
		set
		{
			getterFacade = value;
		}
	}

	public ReadOnlyCollection<Module_Unit.Unit> SelectedUnits => iteratorFacade.AsReadOnly();

	public int PackageID
	{
		get
		{
			if (decoratorProxy < 1000)
			{
				decoratorProxy = GameGeneral.LockRandom_0.Next(1000, 8000);
			}
			else if (decoratorProxy > 9999)
			{
				decoratorProxy = 1000;
			}
			return decoratorProxy;
		}
		set
		{
			decoratorProxy = value;
		}
	}

	public event SelectedUnitsChangedEventHandler SelectedUnitsChanged
	{
		[CompilerGenerated]
		add
		{
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler = valProxy;
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler2;
			do
			{
				selectedUnitsChangedEventHandler2 = selectedUnitsChangedEventHandler;
				SelectedUnitsChangedEventHandler value2 = (SelectedUnitsChangedEventHandler)Delegate.Combine(selectedUnitsChangedEventHandler2, value);
				selectedUnitsChangedEventHandler = Interlocked.CompareExchange(ref valProxy, value2, selectedUnitsChangedEventHandler2);
			}
			while ((object)selectedUnitsChangedEventHandler != selectedUnitsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler = valProxy;
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler2;
			do
			{
				selectedUnitsChangedEventHandler2 = selectedUnitsChangedEventHandler;
				SelectedUnitsChangedEventHandler value2 = (SelectedUnitsChangedEventHandler)Delegate.Remove(selectedUnitsChangedEventHandler2, value);
				selectedUnitsChangedEventHandler = Interlocked.CompareExchange(ref valProxy, value2, selectedUnitsChangedEventHandler2);
			}
			while ((object)selectedUnitsChangedEventHandler != selectedUnitsChangedEventHandler2);
		}
	}

	public static event ScoreChangedEventHandler ScoreChanged
	{
		[CompilerGenerated]
		add
		{
			ScoreChangedEventHandler scoreChangedEventHandler = _FacadeProxy;
			ScoreChangedEventHandler scoreChangedEventHandler2;
			do
			{
				scoreChangedEventHandler2 = scoreChangedEventHandler;
				ScoreChangedEventHandler value2 = (ScoreChangedEventHandler)Delegate.Combine(scoreChangedEventHandler2, value);
				scoreChangedEventHandler = Interlocked.CompareExchange(ref _FacadeProxy, value2, scoreChangedEventHandler2);
			}
			while ((object)scoreChangedEventHandler != scoreChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScoreChangedEventHandler scoreChangedEventHandler = _FacadeProxy;
			ScoreChangedEventHandler scoreChangedEventHandler2;
			do
			{
				scoreChangedEventHandler2 = scoreChangedEventHandler;
				ScoreChangedEventHandler value2 = (ScoreChangedEventHandler)Delegate.Remove(scoreChangedEventHandler2, value);
				scoreChangedEventHandler = Interlocked.CompareExchange(ref _FacadeProxy, value2, scoreChangedEventHandler2);
			}
			while ((object)scoreChangedEventHandler != scoreChangedEventHandler2);
		}
	}

	public static event MissionsChangedEventHandler MissionsChanged
	{
		[CompilerGenerated]
		add
		{
			MissionsChangedEventHandler missionsChangedEventHandler = proxyProxy;
			MissionsChangedEventHandler missionsChangedEventHandler2;
			do
			{
				missionsChangedEventHandler2 = missionsChangedEventHandler;
				MissionsChangedEventHandler value2 = (MissionsChangedEventHandler)Delegate.Combine(missionsChangedEventHandler2, value);
				missionsChangedEventHandler = Interlocked.CompareExchange(ref proxyProxy, value2, missionsChangedEventHandler2);
			}
			while ((object)missionsChangedEventHandler != missionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MissionsChangedEventHandler missionsChangedEventHandler = proxyProxy;
			MissionsChangedEventHandler missionsChangedEventHandler2;
			do
			{
				missionsChangedEventHandler2 = missionsChangedEventHandler;
				MissionsChangedEventHandler value2 = (MissionsChangedEventHandler)Delegate.Remove(missionsChangedEventHandler2, value);
				missionsChangedEventHandler = Interlocked.CompareExchange(ref proxyProxy, value2, missionsChangedEventHandler2);
			}
			while ((object)missionsChangedEventHandler != missionsChangedEventHandler2);
		}
	}

	public static event ContactAddedEventHandler ContactAdded
	{
		[CompilerGenerated]
		add
		{
			ContactAddedEventHandler contactAddedEventHandler = m_ReaderProxy;
			ContactAddedEventHandler contactAddedEventHandler2;
			do
			{
				contactAddedEventHandler2 = contactAddedEventHandler;
				ContactAddedEventHandler value2 = (ContactAddedEventHandler)Delegate.Combine(contactAddedEventHandler2, value);
				contactAddedEventHandler = Interlocked.CompareExchange(ref m_ReaderProxy, value2, contactAddedEventHandler2);
			}
			while ((object)contactAddedEventHandler != contactAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ContactAddedEventHandler contactAddedEventHandler = m_ReaderProxy;
			ContactAddedEventHandler contactAddedEventHandler2;
			do
			{
				contactAddedEventHandler2 = contactAddedEventHandler;
				ContactAddedEventHandler value2 = (ContactAddedEventHandler)Delegate.Remove(contactAddedEventHandler2, value);
				contactAddedEventHandler = Interlocked.CompareExchange(ref m_ReaderProxy, value2, contactAddedEventHandler2);
			}
			while ((object)contactAddedEventHandler != contactAddedEventHandler2);
		}
	}

	public static event ContactRemovedEventHandler ContactRemoved
	{
		[CompilerGenerated]
		add
		{
			ContactRemovedEventHandler contactRemovedEventHandler = propertyProxy;
			ContactRemovedEventHandler contactRemovedEventHandler2;
			do
			{
				contactRemovedEventHandler2 = contactRemovedEventHandler;
				ContactRemovedEventHandler value2 = (ContactRemovedEventHandler)Delegate.Combine(contactRemovedEventHandler2, value);
				contactRemovedEventHandler = Interlocked.CompareExchange(ref propertyProxy, value2, contactRemovedEventHandler2);
			}
			while ((object)contactRemovedEventHandler != contactRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ContactRemovedEventHandler contactRemovedEventHandler = propertyProxy;
			ContactRemovedEventHandler contactRemovedEventHandler2;
			do
			{
				contactRemovedEventHandler2 = contactRemovedEventHandler;
				ContactRemovedEventHandler value2 = (ContactRemovedEventHandler)Delegate.Remove(contactRemovedEventHandler2, value);
				contactRemovedEventHandler = Interlocked.CompareExchange(ref propertyProxy, value2, contactRemovedEventHandler2);
			}
			while ((object)contactRemovedEventHandler != contactRemovedEventHandler2);
		}
	}

	public static event BaseContactAddedEventHandler BaseContactAdded
	{
		[CompilerGenerated]
		add
		{
			BaseContactAddedEventHandler baseContactAddedEventHandler = m_ImporterProxy;
			BaseContactAddedEventHandler baseContactAddedEventHandler2;
			do
			{
				baseContactAddedEventHandler2 = baseContactAddedEventHandler;
				BaseContactAddedEventHandler value2 = (BaseContactAddedEventHandler)Delegate.Combine(baseContactAddedEventHandler2, value);
				baseContactAddedEventHandler = Interlocked.CompareExchange(ref m_ImporterProxy, value2, baseContactAddedEventHandler2);
			}
			while ((object)baseContactAddedEventHandler != baseContactAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			BaseContactAddedEventHandler baseContactAddedEventHandler = m_ImporterProxy;
			BaseContactAddedEventHandler baseContactAddedEventHandler2;
			do
			{
				baseContactAddedEventHandler2 = baseContactAddedEventHandler;
				BaseContactAddedEventHandler value2 = (BaseContactAddedEventHandler)Delegate.Remove(baseContactAddedEventHandler2, value);
				baseContactAddedEventHandler = Interlocked.CompareExchange(ref m_ImporterProxy, value2, baseContactAddedEventHandler2);
			}
			while ((object)baseContactAddedEventHandler != baseContactAddedEventHandler2);
		}
	}

	public static event BaseContactRemovedEventHandler BaseContactRemoved
	{
		[CompilerGenerated]
		add
		{
			BaseContactRemovedEventHandler baseContactRemovedEventHandler = m_RepositoryProxy;
			BaseContactRemovedEventHandler baseContactRemovedEventHandler2;
			do
			{
				baseContactRemovedEventHandler2 = baseContactRemovedEventHandler;
				BaseContactRemovedEventHandler value2 = (BaseContactRemovedEventHandler)Delegate.Combine(baseContactRemovedEventHandler2, value);
				baseContactRemovedEventHandler = Interlocked.CompareExchange(ref m_RepositoryProxy, value2, baseContactRemovedEventHandler2);
			}
			while ((object)baseContactRemovedEventHandler != baseContactRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			BaseContactRemovedEventHandler baseContactRemovedEventHandler = m_RepositoryProxy;
			BaseContactRemovedEventHandler baseContactRemovedEventHandler2;
			do
			{
				baseContactRemovedEventHandler2 = baseContactRemovedEventHandler;
				BaseContactRemovedEventHandler value2 = (BaseContactRemovedEventHandler)Delegate.Remove(baseContactRemovedEventHandler2, value);
				baseContactRemovedEventHandler = Interlocked.CompareExchange(ref m_RepositoryProxy, value2, baseContactRemovedEventHandler2);
			}
			while ((object)baseContactRemovedEventHandler != baseContactRemovedEventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ObservableDictionary<string, Contact> RateOrder()
	{
		return _WorkerFacade;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void FlushOrder(ObservableDictionary<string, Contact> observableDictionary_0)
	{
		INotifyDictionaryChanged<string, Contact>.DictionaryChangedEventHandler val = QueryOrder;
		ObservableDictionary<string, Contact> workerFacade = _WorkerFacade;
		if (workerFacade != null)
		{
			workerFacade.DictionaryChanged -= val;
		}
		_WorkerFacade = observableDictionary_0;
		workerFacade = _WorkerFacade;
		if (workerFacade != null)
		{
			workerFacade.DictionaryChanged += val;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ObservableDictionary<string, Contact> CollectOrder()
	{
		return accountFacade;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void OrderOrder(ObservableDictionary<string, Contact> observableDictionary_0)
	{
		INotifyDictionaryChanged<string, Contact>.DictionaryChangedEventHandler val = ResetOrder;
		ObservableDictionary<string, Contact> val2 = accountFacade;
		if (val2 != null)
		{
			val2.DictionaryChanged -= val;
		}
		accountFacade = observableDictionary_0;
		val2 = accountFacade;
		if (val2 != null)
		{
			val2.DictionaryChanged += val;
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			QuickJumpSlots.Clear();
			foreach (Contact value in RateOrder().Values)
			{
				value.ActualUnit = null;
				value.LastDetections = null;
			}
			FlushOrder(null);
			foreach (Contact value2 in CollectOrder().Values)
			{
				value2.ActualUnit = null;
				value2.LastDetections = null;
			}
			OrderOrder(null);
			foreach (Mission item in m_RoleFacade)
			{
				item.ReleaseReferences();
			}
			m_RoleFacade.Clear();
			interceptorFacade = null;
			m_MessageFacade = null;
			iteratorFacade.Clear();
			merchantProxy = null;
			ArrayExtensions.Clear(ref WeaponSalvos);
			callbackProxy = null;
			m_InstanceProxy = null;
			objectProxy = null;
			m_ParameterProxy = null;
			expressionProxy = null;
			m_DispatcherProxy = null;
			ArrayExtensions.Clear(ref m_ListenerProxy);
			m_ConfigProxy.Clear();
			m_RegistryProxy.Clear();
			definitionProxy.Clear();
			issuerProxy = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public string ToXML(ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		if (m_ClientProxy == null)
		{
			m_ClientProxy = new StringBuilder();
		}
		else
		{
			m_ClientProxy.Clear();
		}
		m_ClientProxy.Append("<Side>");
		try
		{
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
			m_ClientProxy.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					m_ClientProxy.Append("</Side>");
					return m_ClientProxy.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			m_ClientProxy.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			m_ClientProxy.Append("<Nature>").Append(SecurityElement.Escape(Nature.ToString())).Append("</Nature>");
			if (Chalks.Count > 0)
			{
				m_ClientProxy.Append("<Chalks>");
				foreach (Chalk chalk in Chalks)
				{
					if (chalk != null && chalk.AssociatedMothership != null)
					{
						m_ClientProxy.Append(chalk.ToXML(ref hashSet_0));
					}
				}
				m_ClientProxy.Append("</Chalks>");
			}
			if (Operation != null)
			{
				m_ClientProxy.Append(Operation.ToXML(ref hashSet_0));
			}
			if (LandingPlans.Count > 0)
			{
				m_ClientProxy.Append("<LandingPlan>");
				try
				{
					XmlWriter xmlWriter_ = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
					using (xmlWriter_)
					{
						foreach (LandingPlan landingPlan in LandingPlans)
						{
							landingPlan.ToXML(ref xmlWriter_, ref hashSet_0);
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</LandingPlan>");
			}
			if (AssignedFixedColor.HasValue)
			{
				m_ClientProxy.Append("<Color>").Append(Conversions.ToString(AssignedFixedColor.Value.ToArgb())).Append("</Color>");
			}
			if (algoFacade.Count > 0)
			{
				m_ClientProxy.Append("<Postures>");
				Dictionary<Side, Misc.PostureStance>.Enumerator enumerator3 = algoFacade.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					m_ClientProxy.Append("<Posture_").Append(enumerator3.Current.Key.ObjectID).Append(">")
						.Append(((int)enumerator3.Current.Value).ToString())
						.Append("</Posture_")
						.Append(enumerator3.Current.Key.ObjectID)
						.Append(">");
				}
				m_ClientProxy.Append("</Postures>");
			}
			if (RefPoints.Count > 0)
			{
				m_ClientProxy.Append("<ReferencePoints>");
				foreach (ReferencePoint item in RefPoints.ToList())
				{
					if (item != null)
					{
						m_ClientProxy.Append(item.ToXML(ref hashSet_0));
					}
				}
				m_ClientProxy.Append("</ReferencePoints>");
			}
			if (RefPoints_Slugtrail.Count > 0)
			{
				m_ClientProxy.Append("<RefPoints_Slugtrail>");
				foreach (ReferencePoint item5 in RefPoints_Slugtrail.ToList())
				{
					if (item5 != null)
					{
						m_ClientProxy.Append(item5.ToXML(ref hashSet_0));
					}
				}
				m_ClientProxy.Append("</RefPoints_Slugtrail>");
			}
			if (RefPointsTag.Count > 0)
			{
				m_ClientProxy.Append("<ReferencePointFlag>");
				foreach (ReferencePointFlag item6 in RefPointsTag.Keys.ToList())
				{
					if (item6 != null)
					{
						m_ClientProxy.Append(item6.ToXML(ref hashSet_0));
					}
				}
				m_ClientProxy.Append("</ReferencePointFlag>");
			}
			if (Doctrine != null)
			{
				XmlWriter xmlWriter_4 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
				using (xmlWriter_4)
				{
					Doctrine.ToXML(ref xmlWriter_4, ref scenario_0);
				}
				xmlWriter_4 = null;
			}
			if (StandardZones.Count > 0)
			{
				m_ClientProxy.Append("<StandardZones>");
				List<Zone> list = StandardZones.ToList();
				XmlWriter xmlWriter_5 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
				using (xmlWriter_5)
				{
					foreach (Zone item7 in list)
					{
						item7.ToXML(ref xmlWriter_5, ref hashSet_0, ref scenario_0);
					}
				}
				xmlWriter_5 = null;
				m_ClientProxy.Append("</StandardZones>");
			}
			if (ExclusionZones.Count > 0)
			{
				m_ClientProxy.Append("<ExclusionZones>");
				List<ExclusionZone> list2 = ExclusionZones.ToList();
				XmlWriter xmlWriter_6 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
				using (xmlWriter_6)
				{
					foreach (ExclusionZone item8 in list2)
					{
						item8.ToXML(ref xmlWriter_6, ref hashSet_0, ref scenario_0);
					}
				}
				xmlWriter_6 = null;
				m_ClientProxy.Append("</ExclusionZones>");
			}
			if (NoNavZones.Count > 0)
			{
				m_ClientProxy.Append("<NoNavZones>");
				List<NoNavZone> list3 = NoNavZones.ToList();
				XmlWriter xmlWriter_7 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
				using (xmlWriter_7)
				{
					foreach (NoNavZone item9 in list3)
					{
						item9.ToXML(ref xmlWriter_7, ref hashSet_0, ref scenario_0);
					}
				}
				xmlWriter_7 = null;
				m_ClientProxy.Append("</NoNavZones>");
			}
			if (CustomEnvironmentZones.Count > 0)
			{
				m_ClientProxy.Append("<CustomEnvironmentZones>");
				List<CustomEnvironmentZone> list4 = CustomEnvironmentZones.ToList();
				XmlWriter xmlWriter_8 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
				using (xmlWriter_8)
				{
					foreach (CustomEnvironmentZone item10 in list4)
					{
						item10.ToXML(ref xmlWriter_8, ref hashSet_0, ref scenario_0);
					}
				}
				xmlWriter_8 = null;
				m_ClientProxy.Append("</CustomEnvironmentZones>");
			}
			if (AssignsCollectiveResponsibility)
			{
				m_ClientProxy.Append("<CollectiveResponsibility>True</CollectiveResponsibility>");
			}
			else
			{
				m_ClientProxy.Append("<CollectiveResponsibility>False</CollectiveResponsibility>");
			}
			if (CanAutoTrackCivs)
			{
				m_ClientProxy.Append("<CATC>True</CATC>");
			}
			if (QuickJumpSlots.Count > 0)
			{
				m_ClientProxy.Append("<QuickJumpSlots>");
				XmlWriter xmlWriter_9 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
				using (xmlWriter_9)
				{
					foreach (QuickJumpSlot value in QuickJumpSlots.Values)
					{
						value.ToXML(ref xmlWriter_9);
					}
				}
				xmlWriter_9 = null;
				m_ClientProxy.Append("</QuickJumpSlots>");
			}
			if (!string.IsNullOrEmpty(_ProductFacade))
			{
				m_ClientProxy.Append("<Briefing>").Append(_ProductFacade).Append("</Briefing>");
			}
			m_ClientProxy.Append("<Defcon>").Append((int)EmconAlertness.Level).Append("</Defcon>");
			if (!string.IsNullOrEmpty(_AnnotationFacade))
			{
				m_ClientProxy.Append("<Briefing_Encrypted>").Append(_AnnotationFacade).Append("</Briefing_Encrypted>");
			}
			if (_InitializerFacade != null)
			{
				m_ClientProxy.Append("<MapCenter>");
				m_ClientProxy.Append(_InitializerFacade.ToXML(hashSet_0));
				m_ClientProxy.Append("</MapCenter>");
			}
			m_ClientProxy.Append("<CameraAlt>").Append(XmlConvert.ToString(CameraAlt)).Append("</CameraAlt>");
			m_ClientProxy.Append("<TotalScore>").Append(XmlConvert.ToString(attributeFacade)).Append("</TotalScore>");
			if (ScoringLog.Count > 0)
			{
				m_ClientProxy.Append("<ScoringLog>");
				foreach (string item11 in ScoringLog)
				{
					m_ClientProxy.Append("<msg>").Append(SecurityElement.Escape(item11)).Append("</msg>");
				}
				m_ClientProxy.Append("</ScoringLog>");
			}
			if (Scoring_Disaster.HasValue)
			{
				m_ClientProxy.Append("<Scoring_Disaster>").Append(XmlConvert.ToString(Scoring_Disaster.Value)).Append("</Scoring_Disaster>");
			}
			if (Scoring_Triumph.HasValue)
			{
				m_ClientProxy.Append("<Scoring_Triumph>").Append(XmlConvert.ToString(Scoring_Triumph.Value)).Append("</Scoring_Triumph>");
			}
			m_ClientProxy.Append("<AwarenessLevel>").Append(Conversions.ToString((int)AwarenessLevel)).Append("</AwarenessLevel>");
			if (Contacts.Count > 0)
			{
				m_ClientProxy.Append("<Contacts>");
				try
				{
					foreach (Contact item12 in Contacts_List.ToList())
					{
						if (item12.ActualUnit != null)
						{
							m_ClientProxy.Append(item12.ToXML(hashSet_0, this));
						}
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</Contacts>");
			}
			m_ClientProxy.Append("<ContactAutoIncrement>").Append(m_StateFacade.ToString()).Append("</ContactAutoIncrement>");
			if (BaseContacts.Count > 0)
			{
				m_ClientProxy.Append("<BaseContacts>");
				try
				{
					foreach (Contact item2 in BaseContacts_List.ToList())
					{
						if (item2.ActualUnit != null)
						{
							m_ClientProxy.Append(item2.ToXML(hashSet_0, this));
						}
					}
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</BaseContacts>");
			}
			if (Contacts_NonAU.Count > 0)
			{
				m_ClientProxy.Append("<Contacts_NonAU>");
				try
				{
					foreach (string item3 in Contacts_NonAU.ToList())
					{
						m_ClientProxy.Append("<ID>").Append(item3).Append("</ID>");
					}
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</Contacts_NonAU>");
			}
			if (m_RoleFacade.Count > 0)
			{
				m_ClientProxy.Append("<Missions>");
				try
				{
					XmlWriter xmlWriter_10 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
					using (xmlWriter_10)
					{
						foreach (Mission item13 in m_RoleFacade)
						{
							item13?.ToXML(ref xmlWriter_10, ref hashSet_0, ref scenario_0);
						}
					}
					xmlWriter_10 = null;
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</Missions>");
			}
			if (SpecialActions.Any())
			{
				m_ClientProxy.Append("<SpecialActions>");
				try
				{
					XmlWriter xmlWriter2 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
					using (xmlWriter2)
					{
						foreach (SpecialAction value2 in SpecialActions.Values)
						{
							value2.ToXML(xmlWriter2, hashSet_0, scenario_0);
						}
					}
					xmlWriter2 = null;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</SpecialActions>");
			}
			m_ClientProxy.Append("<Prof>").Append(Conversions.ToString((byte)Proficiency)).Append("</Prof>");
			m_ClientProxy.Append("<PackageID>").Append(Conversions.ToString(decoratorProxy)).Append("</PackageID>");
			m_ClientProxy.Append(SideMapProfile.ToXML());
			if (IsAIOnly)
			{
				m_ClientProxy.Append("<IsAIOnly>True</IsAIOnly>");
			}
			XmlWriter xmlWriter_11 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
			using (xmlWriter_11)
			{
				AAR.ToXML(ref xmlWriter_11);
			}
			xmlWriter_11 = null;
			if (WeaponSalvos.Length != 0)
			{
				m_ClientProxy.Append("<WeaponSalvos>");
				try
				{
					XmlWriter xmlWriter_2 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
					using (xmlWriter_2)
					{
						WeaponSalvo[] weaponSalvos = WeaponSalvos;
						for (int i = 0; i < weaponSalvos.Length; i = checked(i + 1))
						{
							weaponSalvos[i].ToXML(ref xmlWriter_2, ref hashSet_0);
						}
					}
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</WeaponSalvos>");
			}
			if (GameGeneral.helperClient && callbackProxy != null && callbackProxy.Count > 0)
			{
				m_ClientProxy.Append("<FiringProposal>");
				try
				{
					XmlWriter xmlWriter_3 = XmlWriter.Create(m_ClientProxy, xmlWriterSettings);
					using (xmlWriter_3)
					{
						foreach (FiringProposal item4 in new List<FiringProposal>(callbackProxy.Values))
						{
							item4.ToXML(ref xmlWriter_3, ref hashSet_0);
						}
					}
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				m_ClientProxy.Append("</FiringProposal>");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101048", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			m_ClientProxy.Append("</Side>");
		}
		return m_ClientProxy.ToString();
	}

	private Side()
	{
		algoFacade = new Dictionary<Side, Misc.PostureStance>();
		_DatabaseFacade = new Dictionary<string, Misc.PostureStance>();
		iteratorFacade = new List<Module_Unit.Unit>();
		m_RoleFacade = new List<Mission>();
		factoryFacade = new List<ScenarioGoal>();
		SpecialActions = new Dictionary<string, SpecialAction>();
		FlushOrder(new ObservableDictionary<string, Contact>());
		OrderOrder(new ObservableDictionary<string, Contact>());
		Contacts_NonAU = new HashSet<string>();
		_ParamsFacade = new TDictionary<string, Contact>();
		m_InfoFacade = new TDictionary<string, Contact>();
		m_HelperFacade = new TDictionary<string, Contact>();
		m_MapperFacade = new TDictionary<string, Contact>();
		managerFacade = new TDictionary<string, Contact>();
		Units = new List<ActiveUnit>();
		RefPoints_Slugtrail = new ObservableList<ReferencePoint>();
		RefPoints = new ObservableList<ReferencePoint>();
		RefPointsTag_raw = new Dictionary<string, ReferencePointFlag>();
		RefPointsTag = new Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>>();
		List<ActiveUnit> list_ = null;
		Doctrine = new Doctrine(this, ref list_);
		AAR = new _AAR();
		ExclusionZones = new List<ExclusionZone>();
		NoNavZones = new List<NoNavZone>();
		CustomEnvironmentZones = new List<CustomEnvironmentZone>();
		StandardZones = new List<Zone>();
		AssignsCollectiveResponsibility = true;
		CanAutoTrackCivs = false;
		QuickJumpSlots = new Dictionary<int, QuickJumpSlot>();
		WeaponSalvos = new WeaponSalvo[0];
		ScoringLog = new List<string>();
		Cache_ContactStancesOnThisPulse = new Dictionary<string, Misc.PostureStance>();
		processProxy = new ConcurrentDictionary<string, int>();
		m_ThreadProxy = new Dictionary<Contact, List<WeaponSalvo>>();
		ruleProxy = new TDictionary<string, bool>();
		m_ListenerProxy = new ActiveUnit[0];
		m_ConfigProxy = new HashSet<string>();
		m_RegistryProxy = new HashSet<string>();
		definitionProxy = new Queue<Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>>>();
		EmconAlertness = new EmconLevel();
		Nature = false;
		Chalks = new List<Chalk>();
		_ObserverProxy = new List<Chalk>();
		LandingPlans = new List<LandingPlan>();
		DisableMultiDomainTOT = false;
		ContactsJustSharedWithMe = new HashSet<string>();
		consumerProxy = RuntimeHelpers.GetObjectValue(new object());
	}

	public static Side FromXML_ByName(string string_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (Operators.CompareString(side.Name, string_0, TextCompare: false) == 0)
				{
					return side;
				}
			}
			foreach (ScenarioObject item in new List<ScenarioObject>(concurrentDictionary_0.Values))
			{
				if ((object)item.GetType() == typeof(Side) && Operators.CompareString(((Side)item).Name, string_0, TextCompare: false) == 0)
				{
					return (Side)item;
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101049", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static Side FromXML_ByObjectID(string string_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		Side result = null;
		if (concurrentDictionary_0.ContainsKey(string_0))
		{
			result = (Side)concurrentDictionary_0[string_0];
		}
		return result;
	}

	public static Side FromXML(ref XmlNode xmlNode_0, ref Scenario scenario_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			Side side = new Side();
			side.IsAIOnly = false;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator12 = null;
				IEnumerator enumerator15 = null;
				IEnumerator enumerator16 = null;
				IEnumerator enumerator17 = null;
				IEnumerator enumerator18 = null;
				IEnumerator enumerator19 = null;
				IEnumerator enumerator20 = null;
				IEnumerator enumerator21 = null;
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				IEnumerator enumerator6 = null;
				IEnumerator enumerator7 = null;
				IEnumerator enumerator8 = null;
				IEnumerator enumerator9 = null;
				IEnumerator enumerator10 = null;
				IEnumerator enumerator11 = null;
				IEnumerator enumerator13 = null;
				IEnumerator enumerator14 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "Name":
						side.Name = xmlNode_.InnerText;
						break;
					case "Scoring_Triumph":
						side.Scoring_Triumph = XmlConvert.ToInt32(xmlNode_.InnerText);
						break;
					case "ReferencePoints":
						try
						{
							enumerator8 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator8.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator8.Current;
								side.RefPoints.Add(ReferencePoint.FromXML(ref xmlNode_3, ref concurrentDictionary_0));
							}
						}
						finally
						{
							if (enumerator8 is IDisposable)
							{
								(enumerator8 as IDisposable).Dispose();
							}
						}
						break;
					case "Operation":
						side.Operation = Operation.FromXML(ref xmlNode_, ref concurrentDictionary_0, side);
						break;
					case "Nature":
						side.Nature = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Missions":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_10 = (XmlNode)enumerator3.Current;
								side.m_RoleFacade.Add(Mission.FromXML(ref xmlNode_10, ref concurrentDictionary_0, ref scenario_0));
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					case "CameraAlt":
						side.CameraAlt = XmlConvert.ToDouble(xmlNode_.InnerText.Replace(", ", "."));
						break;
					case "Doctrine":
						side.Doctrine = Doctrine.FromXML(ref xmlNode_, side);
						break;
					case "QuickJumpSlots":
						try
						{
							enumerator6 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator6.MoveNext())
							{
								QuickJumpSlot quickJumpSlot = QuickJumpSlot.FromXML((XmlNode)enumerator6.Current);
								side.QuickJumpSlots.Add(quickJumpSlot.Index, quickJumpSlot);
							}
						}
						finally
						{
							if (enumerator6 is IDisposable)
							{
								(enumerator6 as IDisposable).Dispose();
							}
						}
						break;
					case "Scoring_Disaster":
						side.Scoring_Disaster = XmlConvert.ToInt32(xmlNode_.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							side.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(side.ObjectID, side);
							break;
						}
						return (Side)concurrentDictionary_0[xmlNode_.InnerText];
					case "Prof":
						side.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "CollectiveResponsibility":
						side.AssignsCollectiveResponsibility = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "CustomEnvironmentZones":
						try
						{
							enumerator18 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator18.MoveNext())
							{
								XmlNode xmlNode_9 = (XmlNode)enumerator18.Current;
								side.CustomEnvironmentZones.Add(CustomEnvironmentZone.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref scenario_0));
							}
						}
						finally
						{
							if (enumerator18 is IDisposable)
							{
								(enumerator18 as IDisposable).Dispose();
							}
						}
						break;
					case "StandardZones":
						try
						{
							enumerator13 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator13.MoveNext())
							{
								XmlNode xmlNode_8 = (XmlNode)enumerator13.Current;
								side.StandardZones.Add(Zone.FromXML(ref xmlNode_8, ref concurrentDictionary_0, ref scenario_0));
							}
						}
						finally
						{
							if (enumerator13 is IDisposable)
							{
								(enumerator13 as IDisposable).Dispose();
							}
						}
						break;
					case "Briefing":
						side.Briefing = xmlNode_.InnerText;
						side.Briefing = side.Briefing.Replace("<HR>", "");
						break;
					case "BaseContacts":
						try
						{
							enumerator12 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator12.MoveNext())
							{
								XmlNode xmlNode_7 = (XmlNode)enumerator12.Current;
								Contact contact2 = Contact.FromXML(ref xmlNode_7, ref concurrentDictionary_0);
								if (Information.IsNothing(contact2))
								{
									side.m_RegistryProxy.Add(xmlNode_7.ChildNodes[0].InnerText);
									continue;
								}
								try
								{
									side.CollectOrder().Add(contact2._ActualUnitID, contact2);
								}
								catch (Exception projectError2)
								{
									ProjectData.SetProjectError(projectError2);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
						finally
						{
							if (enumerator12 is IDisposable)
							{
								(enumerator12 as IDisposable).Dispose();
							}
						}
						break;
					case "Postures":
						try
						{
							enumerator5 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode_6 = (XmlNode)enumerator5.Current;
								if (Operators.CompareString(xmlNode_6.Name, "Posture", TextCompare: false) == 0)
								{
									Posture.FromXML(ref xmlNode_6, ref concurrentDictionary_0);
									string innerText = Misc.StartRequest(xmlNode_6.ChildNodes, "PostureTarget").InnerText;
									Misc.PostureStance value = (Misc.PostureStance)Conversions.ToByte(Misc.StartRequest(xmlNode_6.ChildNodes, "PostureType").InnerText);
									try
									{
										if (!side._DatabaseFacade.ContainsKey(innerText))
										{
											side._DatabaseFacade.Add(innerText, value);
										}
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception exception_ = ex;
										exception_?.Data.Add("Error at 200058", exception_.Message);
										GameGeneral.WriteExceptionsToLog(ref exception_);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
									continue;
								}
								string key = xmlNode_6.Name.Split('_')[1];
								Misc.PostureStance value2 = (Misc.PostureStance)Conversions.ToByte(xmlNode_6.InnerText);
								try
								{
									if (!side._DatabaseFacade.ContainsKey(key))
									{
										side._DatabaseFacade.Add(key, value2);
									}
								}
								catch (Exception ex2)
								{
									ProjectData.SetProjectError(ex2);
									Exception exception_2 = ex2;
									exception_2?.Data.Add("Error at 200590", exception_2.Message);
									GameGeneral.WriteExceptionsToLog(ref exception_2);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
						finally
						{
							if (enumerator5 is IDisposable)
							{
								(enumerator5 as IDisposable).Dispose();
							}
						}
						break;
					case "Briefing_Encrypted":
						side._AnnotationFacade = xmlNode_.InnerText;
						side._AnnotationFacade = side._AnnotationFacade.Replace("<HR>", "");
						break;
					case "ReferencePointFlag":
						try
						{
							enumerator7 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								XmlNode xmlNode_5 = (XmlNode)enumerator7.Current;
								ReferencePointFlag referencePointFlag = ReferencePointFlag.FromXML(ref xmlNode_5, ref concurrentDictionary_0);
								side.RefPointsTag_raw.Add(referencePointFlag.ObjectID, referencePointFlag);
							}
						}
						finally
						{
							if (enumerator7 is IDisposable)
							{
								(enumerator7 as IDisposable).Dispose();
							}
						}
						break;
					case "IsAIOnly":
						side.IsAIOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Contacts_NonAU":
						try
						{
							enumerator17 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator17.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator17.Current;
								side.Contacts_NonAU.Add(xmlNode2.InnerText);
							}
						}
						finally
						{
							if (enumerator17 is IDisposable)
							{
								(enumerator17 as IDisposable).Dispose();
							}
						}
						break;
					case "LandingPlan":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_4 = (XmlNode)enumerator2.Current;
								LandingPlan item2 = LandingPlan.FromXML(ref xmlNode_4, concurrentDictionary_0, side, ref scenario_0);
								side.LandingPlans.Add(item2);
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "TotalScore":
						side.attributeFacade = XmlConvert.ToInt32(xmlNode_.InnerText);
						break;
					case "SpecialActions":
						try
						{
							enumerator11 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator11.MoveNext())
							{
								SpecialAction specialAction = SpecialAction.FromXML((XmlNode)enumerator11.Current, concurrentDictionary_0, scenario_0);
								side.SpecialActions.Add(specialAction.ObjectID, specialAction);
							}
						}
						finally
						{
							if (enumerator11 is IDisposable)
							{
								(enumerator11 as IDisposable).Dispose();
							}
						}
						break;
					case "FiringProposals":
						if (!GameGeneral.helperClient)
						{
							break;
						}
						try
						{
							enumerator20 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator20.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator20.Current;
								FiringProposal firingProposal = FiringProposal.FromXML(ref xmlNode_2, concurrentDictionary_0, ref scenario_0);
								side.callbackProxy.TryAdd(firingProposal.ObjectID, firingProposal);
							}
						}
						finally
						{
							if (enumerator20 is IDisposable)
							{
								(enumerator20 as IDisposable).Dispose();
							}
						}
						break;
					case "PackageID":
						side.decoratorProxy = Conversions.ToShort(xmlNode_.InnerText);
						break;
					case "ScoringLog":
						try
						{
							enumerator10 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator10.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator10.Current;
								side.ScoringLog.Add(xmlNode.InnerText);
							}
						}
						finally
						{
							if (enumerator10 is IDisposable)
							{
								(enumerator10 as IDisposable).Dispose();
							}
						}
						break;
					case "AAR":
						side.AAR = _AAR.FromXML(ref xmlNode_);
						break;
					case "NoNavZones":
					case "NavZones":
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode_18 = (XmlNode)enumerator4.Current;
								side.NoNavZones.Add(NoNavZone.FromXML(ref xmlNode_18, ref concurrentDictionary_0, ref scenario_0));
							}
						}
						finally
						{
							if (enumerator4 is IDisposable)
							{
								(enumerator4 as IDisposable).Dispose();
							}
						}
						break;
					case "Defcon":
						side.EmconAlertness.Level = (Alertlevels)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ContactAutoIncrement":
						side.m_StateFacade = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MapProfile":
						side.SideMapProfile = MapProfile.FromXML(xmlNode_);
						break;
					case "CATC":
						side.CanAutoTrackCivs = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Contacts":
						try
						{
							enumerator16 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator16.MoveNext())
							{
								XmlNode xmlNode_17 = (XmlNode)enumerator16.Current;
								Contact contact = Contact.FromXML(ref xmlNode_17, ref concurrentDictionary_0);
								if (Information.IsNothing(contact))
								{
									if (!side.m_ConfigProxy.Contains(xmlNode_17.ChildNodes[0].InnerText))
									{
										side.m_ConfigProxy.Add(xmlNode_17.ChildNodes[0].InnerText);
									}
									continue;
								}
								try
								{
									if (!side.RateOrder().ContainsKey(contact._ActualUnitID))
									{
										side.RateOrder().Add(contact._ActualUnitID, contact);
									}
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
						finally
						{
							if (enumerator16 is IDisposable)
							{
								(enumerator16 as IDisposable).Dispose();
							}
						}
						break;
					case "Chalks":
						try
						{
							enumerator15 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator15.MoveNext())
							{
								XmlNode xmlNode_16 = (XmlNode)enumerator15.Current;
								Chalk item = Chalk.FromXML(ref xmlNode_16, ref concurrentDictionary_0);
								side._ObserverProxy.Add(item);
							}
						}
						finally
						{
							if (enumerator15 is IDisposable)
							{
								(enumerator15 as IDisposable).Dispose();
							}
						}
						break;
					case "RefPoints_Slugtrail":
						try
						{
							enumerator9 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator9.MoveNext())
							{
								XmlNode xmlNode_15 = (XmlNode)enumerator9.Current;
								side.RefPoints_Slugtrail.Add(ReferencePoint.FromXML(ref xmlNode_15, ref concurrentDictionary_0));
							}
						}
						finally
						{
							if (enumerator9 is IDisposable)
							{
								(enumerator9 as IDisposable).Dispose();
							}
						}
						break;
					case "MapCenter":
					{
						XmlNode xmlNode_14 = xmlNode_.ChildNodes[0];
						side._InitializerFacade = GeoPoint.FromXML(ref xmlNode_14, ref concurrentDictionary_0);
						break;
					}
					case "Color":
						side.AssignedFixedColor = Color.FromArgb(Conversions.ToInteger(xmlNode_.InnerText));
						break;
					case "WeaponSalvos":
						try
						{
							enumerator14 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator14.MoveNext())
							{
								XmlNode xmlNode_13 = (XmlNode)enumerator14.Current;
								WeaponSalvo weaponSalvo = WeaponSalvo.FromXML(ref xmlNode_13, concurrentDictionary_0, ref scenario_0);
								if (!Information.IsNothing(weaponSalvo.Target))
								{
									ArrayExtensions.Add(ref side.WeaponSalvos, weaponSalvo);
								}
							}
						}
						finally
						{
							if (enumerator14 is IDisposable)
							{
								(enumerator14 as IDisposable).Dispose();
							}
						}
						break;
					case "AwarenessLevel":
						side.AwarenessLevel = (AwarenessLevel_Enum)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ForbiddenZones":
					case "ExclusionZones":
						try
						{
							enumerator19 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator19.MoveNext())
							{
								XmlNode xmlNode_12 = (XmlNode)enumerator19.Current;
								side.ExclusionZones.Add(ExclusionZone.FromXML(ref xmlNode_12, ref concurrentDictionary_0, ref scenario_0));
							}
						}
						finally
						{
							if (enumerator19 is IDisposable)
							{
								(enumerator19 as IDisposable).Dispose();
							}
						}
						break;
					case "Goals":
						try
						{
							enumerator21 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator21.MoveNext())
							{
								XmlNode xmlNode_11 = (XmlNode)enumerator21.Current;
								side.factoryFacade.Add(ScenarioGoal.FromXML(xmlNode_11, concurrentDictionary_0, scenario_0));
							}
						}
						finally
						{
							if (enumerator21 is IDisposable)
							{
								(enumerator21 as IDisposable).Dispose();
							}
						}
						break;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			side.ParentScen = scenario_0;
			return side;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 101050", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Side result = new Side();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void PostDeserializationHousekeeping(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, bool bool_0)
	{
		try
		{
			if (RefPoints.Count > 0)
			{
				for (int i = RefPoints.Count - 1; i >= 0; i += -1)
				{
					RefPoints[i].RenderGroup = ReferencePoint_Group.Generic;
				}
			}
			if (RefPoints_Slugtrail.Count > 0)
			{
				for (int j = RefPoints_Slugtrail.Count - 1; j >= 0; j += -1)
				{
					RefPoints_Slugtrail[j].RenderGroup = ReferencePoint_Group.Slugtrail;
				}
			}
			foreach (Chalk item in _ObserverProxy)
			{
				if (!concurrentDictionary_0.ContainsKey(item._AssociatedMothershipID))
				{
					continue;
				}
				Chalks.Add(item);
				item.AssociatedMothership = (ActiveUnit)concurrentDictionary_0[item._AssociatedMothershipID];
				foreach (string cargoID in item._CargoIDs)
				{
					if (concurrentDictionary_0.ContainsKey(cargoID))
					{
						item.Cargo.Add((Cargo)concurrentDictionary_0[cargoID], 0);
					}
				}
			}
			if (concurrentDictionary_0.ContainsKey(Operation._HHourMissionID))
			{
				Operation.HHourMission = (Mission)concurrentDictionary_0[Operation._HHourMissionID];
			}
			if (concurrentDictionary_0.ContainsKey(Operation._LHourMissionID))
			{
				Operation.LHourMission = (Mission)concurrentDictionary_0[Operation._LHourMissionID];
			}
			foreach (LandingPlan item2 in LandingPlans.ToList())
			{
				foreach (string serializedMissionsGUID in item2._SerializedMissionsGUIDS)
				{
					item2.AddMission((Mission)concurrentDictionary_0[serializedMissionsGUID]);
				}
			}
			foreach (Mission mission2 in Missions)
			{
				foreach (string item3 in mission2._MissionStartTrigger_MissionCompletedID)
				{
					if (concurrentDictionary_0.ContainsKey(item3))
					{
						Mission mission = (Mission)concurrentDictionary_0[item3];
						mission2.MissionStartTrigger_MissionCompleted.Add(mission, mission);
					}
				}
			}
			foreach (KeyValuePair<string, Misc.PostureStance> item4 in _DatabaseFacade)
			{
				Side side = FromXML_ByObjectID(item4.Key, ref concurrentDictionary_0);
				if (!Information.IsNothing(side))
				{
					algoFacade.Add(side, item4.Value);
				}
			}
			foreach (ReferencePointFlag value in RefPointsTag_raw.Values)
			{
				if (!RefPointsTag.ContainsKey(value))
				{
					RefPointsTag.Add(value, new Dictionary<ReferencePoint, ReferencePoint>());
				}
			}
			foreach (ReferencePoint refPoint in RefPoints)
			{
				if (refPoint.TagsByGuid_Raw.Count == 0)
				{
					continue;
				}
				foreach (string key in refPoint.TagsByGuid_Raw.Keys)
				{
					if (RefPointsTag_raw.ContainsKey(key) && !refPoint.Tags.ContainsKey(RefPointsTag_raw[key]))
					{
						refPoint.Tags.Add(RefPointsTag_raw[key], RefPointsTag_raw[key]);
						RefPointsTag[RefPointsTag_raw[key]].Add(refPoint, refPoint);
					}
				}
			}
			foreach (string item5 in m_ConfigProxy)
			{
				try
				{
					Contact contact = (Contact)concurrentDictionary_0[item5];
					Contacts.Add(contact._ActualUnitID, contact);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200059", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			foreach (string item6 in m_RegistryProxy)
			{
				try
				{
					Contact contact2 = (Contact)concurrentDictionary_0[item6];
					BaseContacts.Add(contact2._ActualUnitID, contact2);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 200060", exception_2.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 101051", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddContact(Contact contact_0, bool bool_0 = false)
	{
		try
		{
			_ParamsFacade.AddIfNotExistsElseUpdate(contact_0.ActualUnit.ObjectID, contact_0);
			m_InfoFacade.AddIfNotExistsElseUpdate(contact_0.ActualUnit.ObjectID, contact_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101052", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void AssetOrder()
	{
		try
		{
			WeaponSalvo[] weaponSalvos = WeaponSalvos;
			int num = 0;
			WeaponSalvo[] array = weaponSalvos;
			foreach (WeaponSalvo Local_theWS in array)
			{
				if (Local_theWS != null && ((DateTime.Compare(Local_theWS.ScheduledFireTime, DateTime.MaxValue) == 0) | Local_theWS.ManualFire | (Local_theWS.ShootersList.Count() < 2)))
				{
					continue;
				}
				if (Local_theWS.ShootersList[0].QuantityAssigned != int.MaxValue)
				{
					List<int> list = new List<int>();
					WeaponSalvo.Shooter[] shootersList = Local_theWS.ShootersList;
					WeaponSalvo.Shooter[] array2 = shootersList;
					foreach (WeaponSalvo.Shooter Local_theS in array2)
					{
						ActiveUnit activeUnit = Units.Where((ActiveUnit AU) => Operators.CompareString(AU.ObjectID, Local_theS.ShooterObjectID, TextCompare: false) == 0).FirstOrDefault();
						int num2 = 0;
						if (activeUnit != null)
						{
							if (activeUnit.IsAircraft)
							{
								num2 = activeUnit.Weaponry.HowManyOfThisWeaponOnLoadout(((Aircraft)activeUnit).Loadout, Local_theWS.int_0);
							}
							WeaponRec weaponRec = (from theWRec in activeUnit.Weaponry.AllDistinctWeaponsAboard_Current_WeaponRecs(bool_1: true)
								where theWRec.int_0 == Local_theWS.int_0
								select theWRec).FirstOrDefault();
							if (weaponRec != null)
							{
								num2 += weaponRec.CurrentLoad;
							}
						}
						if (num2 > Local_theS.QuantityAssigned)
						{
							list.Add(num2);
							continue;
						}
						return;
					}
					if (Local_theWS.ShootersList.Count() <= 1)
					{
						continue;
					}
					int num3 = 0;
					if (Math.Abs(Local_theWS.ShootersList[0].QuantityAssigned - Local_theWS.ShootersList[1].QuantityAssigned) < 2)
					{
						break;
					}
					WeaponSalvo.Shooter[] shootersList2 = Local_theWS.ShootersList;
					WeaponSalvo.Shooter[] array3 = shootersList2;
					foreach (WeaponSalvo.Shooter shooter in array3)
					{
						if (shooter.QuantityAssigned > 0)
						{
							num3 += shooter.QuantityAssigned;
						}
					}
					double num4 = Math.Max(Math.Floor((double)num3 / (double)Local_theWS.ShootersList.Count()), 1.0);
					int num5 = (int)Math.Round((double)num3 - num4 * (double)Local_theWS.ShootersList.Count());
					int num6 = 0;
					shootersList2 = Local_theWS.ShootersList;
					WeaponSalvo.Shooter[] array4 = shootersList2;
					foreach (WeaponSalvo.Shooter obj in array4)
					{
						int num7 = Math.Min(list[num6], (int)Math.Round(num4));
						obj.QuantityAssigned = (int)Math.Round(num4);
						num6++;
						if (num7 < (int)Math.Round(num4))
						{
							num5 = num5 + (int)Math.Round(num4) - num7;
						}
					}
					num6 = 0;
					if (num5 > 0)
					{
						shootersList2 = Local_theWS.ShootersList;
						WeaponSalvo.Shooter[] array5 = shootersList2;
						foreach (WeaponSalvo.Shooter shooter2 in array5)
						{
							if (num5 == 0)
							{
								break;
							}
							try
							{
								if (list != null && list.Count > 0)
								{
									num = list[num6];
								}
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								continue;
							}
							int num8 = num - shooter2.QuantityAssigned;
							if (num8 > 0)
							{
								if (num8 < num5)
								{
									shooter2.QuantityAssigned = list[num6];
									num5 -= list[num6];
								}
								else
								{
									shooter2.QuantityAssigned = num5;
									num5 = 0;
								}
							}
						}
					}
					if (num5 > 0 && Debugger.IsAttached)
					{
						Debugger.Break();
					}
					continue;
				}
				WeaponSalvo.Shooter[] shootersList3 = Local_theWS.ShootersList;
				for (int i = 0; i < shootersList3.Length; i = checked(i + 1))
				{
					shootersList3[i].QuantityAssigned = int.MaxValue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1034560437990", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddBaseContact(Contact contact_0)
	{
		try
		{
			m_HelperFacade.Add(contact_0.ActualUnit.ObjectID, contact_0);
			contact_0.ActualUnit.Name.Contains("Wierd");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101053", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DropContact(Contact contact_0, ref Scenario scenario_0, bool bool_0)
	{
		try
		{
			if (!Contacts.ContainsKey(contact_0.ActualUnit.ObjectID))
			{
				return;
			}
			m_MapperFacade.AddIfNotExists(contact_0.ActualUnit.ObjectID, contact_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			string string_ = "";
			foreach (KeyValuePair<string, Contact> item in RateOrder())
			{
				if (item.Value == contact_0)
				{
					string_ = item.Key;
					break;
				}
			}
			RateOrder().Remove(string_);
			foreach (ActiveUnit unit in Units)
			{
				unit.Sensory.RemoveContact_Local(ref string_);
			}
			exception_?.Data.Add("Error at 200061", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		ActiveUnit_AI.ExportTargetingChangeEvent("Dropping contact", contact_0, null, this, scenario_0, "");
		if (bool_0)
		{
			if (scenario_0.GetCurrentSide() == this)
			{
				scenario_0.AddMessage("目标" + contact_0.Name + "已经丢失。", contact_0.Name + " 已消失", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
			}
			else
			{
				scenario_0.AddMessage(Name + " :Contact " + contact_0.Name + "已经丢失。", contact_0.Name + " 已消失", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
			}
		}
		foreach (ActiveUnit unit2 in Units)
		{
			try
			{
				unit2.Sensory.HandleContactLoss(contact_0);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 21513221", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CleanFiringProposals()
	{
		List<FiringProposal> list = new List<FiringProposal>();
		if (callbackProxy != null)
		{
			foreach (FiringProposal item in new List<FiringProposal>(callbackProxy.Values))
			{
				if (item.FiringUnit.IsActiveUnit)
				{
					Mission mission = ((ActiveUnit)item.FiringUnit).AssignedMissionOrPackage();
					if (mission != null && mission.MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike = (Strike)mission;
						if ((strike.SpecificTargets.Contains(item.Target) || strike.SpecificTargets.Contains(item.Target.ActualUnit)) && strike.TimeOnTarget.HasValue)
						{
							DateTime? timeOnTarget = strike.TimeOnTarget;
							DateTime time = item.Target.ActualUnit.ParentScen.Time;
							if ((timeOnTarget.HasValue ? new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), time) > 0) : null).GetValueOrDefault())
							{
								continue;
							}
						}
					}
				}
				list.Add(item);
			}
		}
		foreach (FiringProposal item2 in list)
		{
			FiringProposal value = item2;
			if (value != null)
			{
				callbackProxy.TryRemove(value.ObjectID, out value);
			}
		}
	}

	public void RebuildSalvoCache()
	{
		if (m_ThreadProxy.Count > 0)
		{
			m_ThreadProxy.Clear();
		}
		if (WeaponSalvos.Count() <= 0)
		{
			return;
		}
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		WeaponSalvo[] weaponSalvos = WeaponSalvos;
		WeaponSalvo[] array = weaponSalvos;
		foreach (WeaponSalvo weaponSalvo in array)
		{
			if (weaponSalvo.ShootersList.Count() == 0)
			{
				list.Add(weaponSalvo);
			}
		}
		foreach (WeaponSalvo item in list)
		{
			ArrayExtensions.Remove(ref WeaponSalvos, item);
		}
		weaponSalvos = WeaponSalvos;
		WeaponSalvo[] array2 = weaponSalvos;
		foreach (WeaponSalvo weaponSalvo2 in array2)
		{
			if (m_ThreadProxy.ContainsKey(weaponSalvo2.Target))
			{
				m_ThreadProxy[weaponSalvo2.Target].Add(weaponSalvo2);
				continue;
			}
			m_ThreadProxy.Add(weaponSalvo2.Target, new List<WeaponSalvo>(new WeaponSalvo[1] { weaponSalvo2 }));
		}
	}

	public void PrePulseHousekeeping(Scenario scenario_0)
	{
		try
		{
			Contacts_List = null;
			List<Contact> contacts_List = Contacts_List;
			KnownActiveNuclearWeapons = null;
			CleanFiringProposals();
			RebuildSalvoCache();
			Cache_ContactStancesOnThisPulse.Clear();
			processProxy.Clear();
			ruleProxy.Clear();
			int count = contacts_List.Count;
			int num = count - 1;
			for (int i = 0; i <= num && i < count; i++)
			{
				try
				{
					Contact contact = contacts_List[i];
					Cache_ContactStancesOnThisPulse.Add(contact.ObjectID, Misc.PostureStance.Neutral);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			Parallel.ForEach(contacts_List, delegate(Contact theContact)
			{
				theContact.HasBeenCheckedForDestructionThisPulse = false;
				theContact.GetIsDestroyed(scenario_0);
				Cache_ContactStancesOnThisPulse[theContact.ObjectID] = theContact.GetStance(this);
			});
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			WeaponSalvo[] weaponSalvos = WeaponSalvos;
			ActiveUnit activeUnit = null;
			WeaponSalvo[] array = weaponSalvos;
			WeaponSalvo[] array2 = array;
			foreach (WeaponSalvo weaponSalvo in array2)
			{
				bool flag = false;
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				WeaponSalvo.Shooter[] array3 = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array3)
				{
					if (scenario_0.ActiveUnits.TryGetValue(shooter.ShooterObjectID, ref activeUnit) && activeUnit.Weaponry.TotalAvailableInventoryForThisWeapon(weaponSalvo.int_0, bool_1: false) > 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(weaponSalvo);
				}
			}
			foreach (WeaponSalvo item in list)
			{
				AttemptToRemoveWeaponSalvo(ref scenario_0, item);
			}
			foreach (Mission mission in Missions)
			{
				mission.PrePulseHousekeeping(scenario_0);
			}
			if (scenario_0.AnyActiveWeaponEffectThreats)
			{
				GetKnownActiveNuclearWeapons(scenario_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10104444544", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DropBaseContact(Contact contact_0, ref Scenario scenario_0, bool bool_0 = true)
	{
		try
		{
			if (!BaseContacts.ContainsKey(contact_0.ActualUnit.ObjectID))
			{
				return;
			}
			managerFacade.Add(contact_0.ActualUnit.ObjectID, contact_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			string text = "";
			foreach (KeyValuePair<string, Contact> item in CollectOrder())
			{
				if (item.Value == contact_0)
				{
					text = item.Key;
				}
			}
			CollectOrder().Remove(text);
			exception_?.Data.Add("Error at 200062", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (bool_0)
		{
			if (scenario_0.GetCurrentSide() == this)
			{
				scenario_0.AddMessage("基地目标" + contact_0.Name + "已经丢失。", contact_0.Name + " 已消失", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
			}
			else
			{
				scenario_0.AddMessage(Name + " :Base contact " + contact_0.Name + "已经丢失。", contact_0.Name + " 已消失", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude()));
			}
		}
	}

	public void ProcessAutoDetectableUnits(Scenario scenario_0, float float_0)
	{
		if (!scenario_0.UnitAutodetectionValidation.Contains(this))
		{
			return;
		}
		try
		{
			if (!scenario_0.SecondIsChangingOnThisPulse || GameGeneral.m_ManagerClient == null || !GameGeneral.m_ManagerClient.ContainsKey(ObjectID))
			{
				return;
			}
			HashSet<string> hashSet = GameGeneral.m_ManagerClient[ObjectID];
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (activeUnits_ != null && activeUnits_.GetIsEligibleForAutodetection(this) && activeUnits_.GetUnitSide() != null && activeUnits_.IsOperating() && GameGeneral.m_ManagerClient.TryGetValue(activeUnits_.GetUnitSide().ObjectID, out var value) && activeUnits_.GetUnitSide() != this && (!hashSet.Contains(activeUnits_.GetUnitSide().ObjectID) || !value.Contains(ObjectID)))
				{
					if (RateOrder().ContainsKey(activeUnits_.ObjectID))
					{
						RateOrder()[activeUnits_.ObjectID].IsPreciselyLocatedOnThisPulse = true;
						RateOrder()[activeUnits_.ObjectID].method_0(scenario_0, this, null, null, bool_0: false, bool_1: true, bool_2: false, bool_3: true, Contact_Base.IdentificationStatus.PreciseID);
					}
					else
					{
						Contact contact_ = null;
						ActiveUnit_Sensory.ProcessNewContact(ref contact_, ref activeUnits_.ParentScen, this, activeUnits_, ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection, null, Contact_Base.IdentificationStatus.PreciseID);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101054", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ProcessBaseContacts(ref Scenario scenario_0)
	{
		try
		{
			bool flag = false;
			foreach (ActiveUnit item in m_MessageFacade)
			{
				ActiveUnit activeUnit_ = item;
				Group group = (Group)activeUnit_;
				if (group.Type == Group.GroupType.MobileGroup)
				{
					foreach (ActiveUnit value in group.Units.Values)
					{
						if (Contacts.ContainsKey(value.ObjectID))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						ActiveUnit_Sensory sensory = activeUnit_.Sensory;
						Side side_ = this;
						sensory.PerformBaseDetections(ref activeUnit_, ref side_);
					}
				}
				else
				{
					ActiveUnit_Sensory sensory2 = activeUnit_.Sensory;
					Side side_2 = this;
					sensory2.PerformBaseDetections(ref activeUnit_, ref side_2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101055", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void PrintOrder(Scenario scenario_0, float float_0)
	{
		new List<Contact>();
		List<FiringProposal> source;
		try
		{
			source = new List<FiringProposal>(callbackProxy.Values);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			source = new List<FiringProposal>(callbackProxy.Values);
			ProjectData.ClearProjectError();
		}
		if (!DisableMultiDomainTOT)
		{
			Parallel.ForEach(source, delegate(FiringProposal firingProposal_0)
			{
				Mission mission2 = ((ActiveUnit)firingProposal_0.FiringUnit).AssignedMissionOrPackage();
				if ((mission2 != null) & !firingProposal_0.FiringUnit.IsAircraft)
				{
					if (Needs_To_Recalculate_Weapon_ETA(firingProposal_0.FiringUnit, firingProposal_0.Target))
					{
						((ActiveUnit)firingProposal_0.FiringUnit).Weaponry.ReadConsumer(firingProposal_0.Target, firingProposal_0.GetReferenceWeapon(scenario_0));
					}
					DateTime? timeOnTarget2 = mission2.TimeOnTarget;
					DateTime eTA2 = firingProposal_0.ETA;
					if ((timeOnTarget2.HasValue ? new bool?(DateTime.Compare(timeOnTarget2.GetValueOrDefault(), eTA2) > 0) : null).GetValueOrDefault())
					{
						FiringProposal firingProposal = callbackProxy.Values.Where((FiringProposal FP) => (Operators.CompareString(FP.Target.ObjectID, firingProposal_0.Target.ObjectID, TextCompare: false) == 0) & (Operators.CompareString(FP.FiringUnit.ObjectID, firingProposal_0.FiringUnit.ObjectID, TextCompare: false) == 0)).FirstOrDefault();
						if (firingProposal != null)
						{
							firingProposal.ETA = firingProposal.ETA.AddSeconds(float_0);
						}
					}
				}
			});
		}
		foreach (IGrouping<Contact, FiringProposal> item in (from theTargetGroup in source
			where theTargetGroup != null
			group theTargetGroup by theTargetGroup.Target).ToList())
		{
			foreach (IGrouping<int, FiringProposal> item2 in (from theWeaponGroup in item
				where theWeaponGroup != null
				group theWeaponGroup by theWeaponGroup.int_0).ToList())
			{
				int? shooterQuantity = item2.ElementAtOrDefault(0).ShooterQuantity;
				int? num = item2.ElementAtOrDefault(0).QuantityToFire;
				int? num2 = 0;
				foreach (FiringProposal item3 in item2.OrderBy((FiringProposal theFP3) => theFP3.ETA).ToList())
				{
					bool? nullable_ = null;
					Weapon weapon_ = item3.GetReferenceWeapon(scenario_0);
					ref Contact target = ref item3.Target;
					Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref item3.Target, item3.GetReferenceWeapon(scenario_0), ref nullable_);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref target, ref _WRA_WeaponTargetType_, ObjectID);
					Doctrine doctrine = ((ActiveUnit)item3.FiringUnit).Doctrine;
					Weapon referenceWeapon = item3.GetReferenceWeapon(scenario_0);
					int? nullable_3 = null;
					int? nullable_4 = null;
					int? num3 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, scenario_0, referenceWeapon, wRA_WeaponTargetType_, bool_0: false, ref nullable_3, ref nullable_4);
					nullable_4 = num3;
					if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -99) : null).GetValueOrDefault())
					{
						num3 = int.MaxValue;
					}
					else
					{
						nullable_4 = num3;
						if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() < 0) : null).GetValueOrDefault())
						{
							int? nullable_5 = num3;
							ActiveUnit activeUnit_ = (ActiveUnit)item3.FiringUnit;
							ref Contact target2 = ref item3.Target;
							weapon_ = item3.GetReferenceWeapon(((ActiveUnit)item3.FiringUnit).ParentScen);
							num3 = ConvertSalvoWeaponQty_To_ActualQuantity(nullable_5, ref activeUnit_, ref target2, ref weapon_);
						}
					}
					if (((num3.HasValue & num2.HasValue) ? new bool?(num3.GetValueOrDefault() > num2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						int? nullable_6 = num3;
						ActiveUnit activeUnit_2 = (ActiveUnit)item3.FiringUnit;
						ref Contact target3 = ref item3.Target;
						weapon_ = item3.GetReferenceWeapon(scenario_0);
						num2 = ConvertSalvoWeaponQty_To_ActualQuantity(nullable_6, ref activeUnit_2, ref target3, ref weapon_);
					}
				}
				if (((num2.HasValue & num.HasValue) ? new bool?(num2.GetValueOrDefault() > num.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					num = num2;
				}
				foreach (FiringProposal item4 in item2.OrderBy((FiringProposal theFP3) => theFP3.ETA).ToList())
				{
					try
					{
						if (DisableMultiDomainTOT)
						{
							goto IL_0561;
						}
						Mission mission = ((ActiveUnit)item4.FiringUnit).AssignedMissionOrPackage();
						if (!((mission != null) & !item4.FiringUnit.IsAircraft))
						{
							goto IL_0561;
						}
						if (DateTime.Compare(item4.ETA, DateTime.MinValue) == 0)
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							Exception exception_ = new Exception("ETA for weapon " + item4.GetReferenceWeapon(scenario_0).Name + " " + item4.int_0 + " was miscalculated");
							GameGeneral.WriteExceptionsToLog(ref exception_);
						}
						DateTime? timeOnTarget = mission.TimeOnTarget;
						DateTime eTA = item4.ETA;
						if (!(timeOnTarget.HasValue ? new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), eTA) > 0) : null).GetValueOrDefault())
						{
							goto IL_0561;
						}
						goto end_IL_0438;
						IL_0561:
						bool flag = false;
						List<WeaponSalvo> list = new List<WeaponSalvo>();
						int num4 = 0;
						int num5 = 0;
						WeaponSalvo[] weaponSalvos = WeaponSalvos;
						WeaponSalvo[] array = weaponSalvos;
						foreach (WeaponSalvo weaponSalvo in array)
						{
							if (Operators.CompareString(weaponSalvo.Target.ObjectID, item4.Target.ObjectID, TextCompare: false) != 0 || weaponSalvo.GetReferenceWeapon(scenario_0).DBID != item4.GetReferenceWeapon(scenario_0).DBID)
							{
								continue;
							}
							num5 = ((weaponSalvo.WpnQuantityAssigned != int.MaxValue) ? (num5 + weaponSalvo.WpnQuantityAssigned) : 0);
							num4 += weaponSalvo.ShootersList.Count();
							if (weaponSalvo.WpnQuantityFired == 0)
							{
								list.Add(weaponSalvo);
								continue;
							}
							item4.QuantityToFire -= weaponSalvo.WpnQuantityFired;
							int? quantityToFire = item4.QuantityToFire;
							if ((quantityToFire.HasValue ? new bool?(quantityToFire.GetValueOrDefault() <= 0) : null).GetValueOrDefault())
							{
								RemoveFireProposal(item4);
								((ActiveUnit)item4.FiringUnit).AI.DropTarget(item4.Target);
								flag = true;
							}
						}
						int num6 = 0;
						if (!flag)
						{
							foreach (ActiveUnit item5 in Misc.EnableRequest(Units))
							{
								if (item5 != null && item5.DBID == item4.int_0 && item5.AI.PrimaryTarget != null && Operators.CompareString(item5.AI.PrimaryTarget.ObjectID, item4.ObjectID, TextCompare: false) == 0)
								{
									num6++;
								}
							}
							num6 -= num5;
							if (num6 > 0)
							{
								item4.QuantityToFire -= num6;
								int? quantityToFire2 = item4.QuantityToFire;
								if ((quantityToFire2.HasValue ? new bool?(quantityToFire2.GetValueOrDefault() <= 0) : null).GetValueOrDefault())
								{
									RemoveFireProposal(item4);
									((ActiveUnit)item4.FiringUnit).AI.DropTarget(item4.Target);
									flag = true;
								}
							}
						}
						if (!flag)
						{
							bool? nullable_7 = null;
							Weapon weapon_2 = item4.GetReferenceWeapon(scenario_0);
							ref Contact target4 = ref item4.Target;
							Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_2 = Doctrine.WRA_DetermineTargetType(ref item4.Target, item4.GetReferenceWeapon(scenario_0), ref nullable_7);
							Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_2 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_2, ref target4, ref _WRA_WeaponTargetType_2, ObjectID);
							Doctrine doctrine2 = ((ActiveUnit)item4.FiringUnit).Doctrine;
							Scenario scenario_ = scenario_0;
							Weapon referenceWeapon2 = item4.GetReferenceWeapon(scenario_0);
							int? nullable_8 = null;
							int? nullable_9 = null;
							int? num7 = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine2, scenario_, referenceWeapon2, wRA_WeaponTargetType_2, bool_0: false, ref nullable_8, ref nullable_9);
							nullable_9 = num7;
							if ((nullable_9.HasValue ? new bool?(nullable_9.GetValueOrDefault() == -99) : null).GetValueOrDefault())
							{
								num7 = int.MaxValue;
							}
							Doctrine doctrine3 = ((ActiveUnit)item4.FiringUnit).Doctrine;
							Scenario scenario_2 = scenario_0;
							Weapon referenceWeapon3 = item4.GetReferenceWeapon(scenario_0);
							nullable_9 = null;
							nullable_8 = null;
							int? num8 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine3, scenario_2, referenceWeapon3, wRA_WeaponTargetType_2, bool_0: false, ref nullable_9, ref nullable_8);
							nullable_8 = num8;
							if ((nullable_8.HasValue ? new bool?(nullable_8.GetValueOrDefault() == -99) : null).GetValueOrDefault())
							{
								num8 = int.MaxValue;
								num2 = int.MaxValue;
							}
							else
							{
								nullable_8 = num8;
								if ((nullable_8.HasValue ? new bool?(nullable_8.GetValueOrDefault() < 0) : null).GetValueOrDefault())
								{
									int? nullable_10 = num8;
									ActiveUnit activeUnit_3 = (ActiveUnit)item4.FiringUnit;
									ref Contact target5 = ref item4.Target;
									weapon_2 = item4.GetReferenceWeapon(((ActiveUnit)item4.FiringUnit).ParentScen);
									num8 = ConvertSalvoWeaponQty_To_ActualQuantity(nullable_10, ref activeUnit_3, ref target5, ref weapon_2);
								}
							}
							if (((num8.HasValue & num2.HasValue) ? new bool?(num8.GetValueOrDefault() > num2.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								int? nullable_2 = num8;
								ActiveUnit activeUnit_4 = (ActiveUnit)item4.FiringUnit;
								ref Contact target6 = ref item4.Target;
								weapon_2 = item4.GetReferenceWeapon(scenario_0);
								num2 = ConvertSalvoWeaponQty_To_ActualQuantity(nullable_2, ref activeUnit_4, ref target6, ref weapon_2);
							}
							if (list.Count == 0 && ((num7.HasValue ? new bool?(num4 >= num7.GetValueOrDefault()) : null).GetValueOrDefault() || (num2.HasValue ? new bool?(num5 >= num2.GetValueOrDefault()) : null).GetValueOrDefault()))
							{
								RemoveFireProposal(item4);
								((ActiveUnit)item4.FiringUnit).AI.DropTarget(item4.Target);
								flag = true;
							}
							foreach (WeaponSalvo item6 in list)
							{
								ArrayExtensions.Remove(ref WeaponSalvos, item6);
							}
						}
						if (!flag)
						{
							WeaponSalvo[] weaponSalvos2 = WeaponSalvos;
							for (int i = 0; i < weaponSalvos2.Length; i = checked(i + 1))
							{
								WeaponSalvo weaponSalvo_ = weaponSalvos2[i];
								if (Operators.CompareString(weaponSalvo_.Target.ObjectID, item4.Target.ObjectID, TextCompare: false) != 0 || weaponSalvo_.GetReferenceWeapon(scenario_0).DBID != item4.GetReferenceWeapon(scenario_0).DBID)
								{
									continue;
								}
								int? num9 = shooterQuantity;
								bool? flag2 = (num9.HasValue ? new bool?(num9.GetValueOrDefault() == int.MaxValue) : null);
								bool? flag3 = ((weaponSalvo_.WpnQuantityAssigned == int.MaxValue) ? new bool?(false) : flag2);
								int wpnQuantityAssigned = weaponSalvo_.WpnQuantityAssigned;
								bool? flag4 = (num.HasValue ? new bool?(wpnQuantityAssigned >= num.GetValueOrDefault()) : null);
								if (((!flag3).GetValueOrDefault() ? new bool?(false) : ((!flag4.HasValue) ? null : (flag4.GetValueOrDefault() & flag3))).GetValueOrDefault())
								{
									RemoveFireProposal(item4);
									((ActiveUnit)item4.FiringUnit).AI.DropTarget(item4.Target);
									flag = true;
									break;
								}
								wpnQuantityAssigned = weaponSalvo_.ShootersList.Count();
								if ((shooterQuantity.HasValue ? new bool?(wpnQuantityAssigned >= shooterQuantity.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									RemoveFireProposal(item4);
									((ActiveUnit)item4.FiringUnit).AI.DropTarget(item4.Target);
									flag = true;
								}
								else
								{
									AddShooterToExistingSalvo(ref weaponSalvo_, num - weaponSalvo_.WpnQuantityAssigned, 0, item4.QuantityAvailable.Value, item4.ManualFire, ref item4.FiringUnit.ObjectID, bool_1: true);
									RemoveFireProposal(item4);
									flag = true;
								}
								break;
							}
						}
						if (!flag)
						{
							Scenario scenario_3 = scenario_0;
							Weapon weapon_3 = item4.GetReferenceWeapon(scenario_0);
							AssignSalvoToTarget(scenario_3, ref weapon_3, ref item4.Target, num, 0, item4.QuantityAvailable, item4.ManualFire, ref item4.FiringUnit.ObjectID, ref item4.ShooterQuantity, DateTime.MinValue, item4.ETA);
							RemoveFireProposal(item4);
						}
						end_IL_0438:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_2 = ex;
						exception_2?.Data.Add("Error at 98746524324654", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		AssetOrder();
	}

	public static bool Needs_To_Recalculate_Weapon_ETA(Module_Unit.Unit unit_0, ScenarioObject scenarioObject_0)
	{
		if (unit_0.UpdateWriter() | scenarioObject_0.UpdateWriter())
		{
			ActiveUnit activeUnit = (ActiveUnit)unit_0;
			if (activeUnit.AssignedMissionOrPackage() != null && activeUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)activeUnit.AssignedMissionOrPackage();
				if (strike.TimeOnTarget.HasValue && (strike.TimeOnTarget.Value - activeUnit.ParentScen.Time).TotalSeconds < (double)ActiveUnit.FP_RECALC_THREASHOLD)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void DefineOrder(TDictionary<string, Contact> tdictionary_0)
	{
		if (tdictionary_0.Count <= 0)
		{
			return;
		}
		Contact contact = null;
		foreach (string key in tdictionary_0.Keys)
		{
			if (!m_MapperFacade.ContainsKey_NoLock(key))
			{
				if (!RateOrder().ContainsKey(key))
				{
					RateOrder().Add(key, tdictionary_0[key]);
				}
				if (RateOrder().TryGetValue(key, ref contact) && contact.OriginalDetectorSide != this)
				{
					contact.RetreivedPostureOnThisPulse = false;
				}
			}
		}
		tdictionary_0.Clear();
	}

	public void ProcessContactListChanges(Scenario scenario_0)
	{
		try
		{
			DefineOrder(m_InfoFacade);
			if (m_MapperFacade.Count > 0)
			{
				List<string> list = new List<string>(m_MapperFacade.Keys);
				List<ActiveUnit> list2 = new List<ActiveUnit>(Units);
				foreach (string item in list)
				{
					string string_ = item;
					Contact contact_ = m_MapperFacade[string_];
					RemoveWeaponSalvosForThisTarget(ref scenario_0, contact_);
					foreach (ActiveUnit item2 in list2)
					{
						ActiveUnit_AI aI = item2.AI;
						Side side_ = this;
						aI.HandleContactBeingDropped(ref contact_, ref side_);
						item2.Sensory.RemoveContact_Local(ref string_);
					}
					RateOrder().Remove(string_);
					if (SelectedUnits.Contains(contact_))
					{
						SelectedUnits_Remove(contact_);
					}
				}
				m_MapperFacade.Clear();
			}
			DefineOrder(_ParamsFacade);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101056", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ProcessBaseContactListChanges(Scenario scenario_0)
	{
		try
		{
			if (m_HelperFacade.Count > 0)
			{
				foreach (string key in m_HelperFacade.Keys)
				{
					if (!CollectOrder().ContainsKey(key))
					{
						CollectOrder().Add(key, m_HelperFacade[key]);
					}
				}
				m_HelperFacade.Clear();
			}
			if (managerFacade.Count <= 0)
			{
				return;
			}
			foreach (string key2 in managerFacade.Keys)
			{
				Contact contact = managerFacade[key2];
				CollectOrder().Remove(key2);
				if (SelectedUnits.Contains(contact))
				{
					SelectedUnits_Remove(contact);
				}
			}
			managerFacade.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101057", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public int GetTotalScore(Scenario scenario_0, string string_0 = null)
	{
		return attributeFacade;
	}

	[SpecialName]
	public void SetTotalScore(Scenario scenario_0, string string_0, int int_0)
	{
		try
		{
			bool num = int_0 != attributeFacade;
			int num2 = attributeFacade;
			attributeFacade = int_0;
			if (!num)
			{
				return;
			}
			ScoringLog.Add(scenario_0.Time.ToString("MM/dd/yyyy HH:mm") + "：分数变化从" + Conversions.ToString(num2) + "至" + Conversions.ToString(int_0) + "。原因：" + string_0);
			List<EventTrigger> list = new List<EventTrigger>();
			foreach (EventTrigger value in scenario_0.EventTriggers.Values)
			{
				if (value.Type == EventTrigger.EventTriggerType.Points && ((EventTrigger_Points)value).GetIsFulfilled(this, num2, int_0))
				{
					list.Add(value);
				}
			}
			scenario_0.FireEvents(list);
			_FacadeProxy?.Invoke(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101058", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public ReadOnlyCollection<Mission> GetMissionsTotal(Scenario scenario_0)
	{
		try
		{
			if (Information.IsNothing(_DicProxy))
			{
				List<Mission> list = new List<Mission>();
				list.AddRange(m_RoleFacade);
				try
				{
					foreach (Group group in scenario_0.Groups)
					{
						if (group.GetUnitSide() == this)
						{
							list.AddRange(group.Patrols);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200063", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				_DicProxy = list.AsReadOnly();
			}
			return _DicProxy;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101059", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public void MissionsTotal_Reset()
	{
		_DicProxy = null;
	}

	public void Missions_Add(Mission mission_0)
	{
		if (!m_RoleFacade.Contains(mission_0))
		{
			m_RoleFacade.Add(mission_0);
			MissionsTotal_Reset();
			proxyProxy?.Invoke(this);
		}
	}

	public void Missions_Remove(Mission mission_0)
	{
		switch (mission_0.Category)
		{
		case Mission.MissionCategory.TaskPool:
		{
			TaskPool taskPool2 = (TaskPool)mission_0;
			for (int i = taskPool2.PackageList.Count - 1; i >= 0; i += -1)
			{
				Mission mission_ = taskPool2.PackageList[i];
				Missions_Remove(mission_);
			}
			break;
		}
		case Mission.MissionCategory.Package:
			foreach (Mission item in m_RoleFacade)
			{
				if (item.Category == Mission.MissionCategory.TaskPool)
				{
					TaskPool taskPool = (TaskPool)item;
					if (taskPool.PackageList.Contains(mission_0))
					{
						taskPool.PackageList.Remove(mission_0);
						break;
					}
				}
			}
			break;
		}
		foreach (ActiveUnit unit in Units)
		{
			if (unit != null && unit.AssignedMissionOrPackage() == mission_0)
			{
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				unit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_);
			}
		}
		if (m_RoleFacade.Remove(mission_0))
		{
			MissionsTotal_Reset();
			proxyProxy?.Invoke(this);
		}
	}

	public void ScrubMissions(Scenario scenario_0)
	{
		List<Mission> list = new List<Mission>();
		foreach (Mission mission in Missions)
		{
			if (mission.ScrubIfSideIsHuman)
			{
				list.Add(mission);
			}
		}
		foreach (Mission item in list)
		{
			foreach (ActiveUnit item2 in Module_Mission.AssetTokenizer(item, scenario_0))
			{
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				item2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_);
			}
			Missions_Remove(item);
		}
	}

	[SpecialName]
	public List<ActiveUnit> GetUnitsEngagedInOECM(bool bool_0)
	{
		try
		{
			if (merchantProxy == null || bool_0)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (ActiveUnit item in new List<ActiveUnit>(Units))
				{
					bool? flag = item?.IsGroup;
					if (((!flag) ?? flag).GetValueOrDefault() && item.IsOperating() && ActiveUnit_Sensory.smethod_0(item))
					{
						list.Add(item);
					}
				}
				merchantProxy = list;
			}
			return merchantProxy;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101060", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = merchantProxy;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public List<Module_Unit.Unit> GetKnownActiveNuclearWeapons(Scenario scenario_0)
	{
		if (_WrapperProxy == null)
		{
			_WrapperProxy = new List<Module_Unit.Unit>();
			foreach (ActiveUnit item in scenario_0.ActiveUnits.Values.ToList())
			{
				if (item != null && item.GetUnitSide() == this && item.IsWeapon && ((Weapon)item).IsNuke.Value)
				{
					_WrapperProxy.Add(item);
				}
			}
			foreach (UnguidedWeapon item2 in scenario_0.UnguidedWeapons.Values.ToList())
			{
				if (item2 != null && item2.GetUnitSide() == this && item2.ReferenceWeapon.IsNuke.Value && !item2.IsMine)
				{
					_WrapperProxy.Add(item2);
				}
			}
			foreach (Contact item3 in Contacts.Values.ToList())
			{
				if (item3.IsWeaponContact && item3.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && item3.ActualUnit != null && item3.ActualUnit.IsWeapon && ((Weapon)item3.ActualUnit).IsNuke.Value)
				{
					_WrapperProxy.Add(item3);
				}
			}
			foreach (Explosion item4 in scenario_0.Explosions.ToList())
			{
				if (item4.ExplosiveType == Warhead.WarheadExplosivesType.Nuclear)
				{
					_WrapperProxy.Add(item4);
				}
			}
		}
		return _WrapperProxy;
	}

	[SpecialName]
	public List<ActiveUnit> GetFriendlyUnits_OperativeOnly(Scenario scenario_0)
	{
		List<ActiveUnit> friendlyUnits = GetFriendlyUnits(scenario_0);
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit item in friendlyUnits)
		{
			if (item != null && item.IsOperating())
			{
				list.Add(item);
			}
		}
		return list;
	}

	[SpecialName]
	public List<ActiveUnit> GetFriendlyUnits(Scenario scenario_0)
	{
		try
		{
			if (m_DispatcherProxy == null)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					if (activeUnits_ != null && activeUnits_.GetUnitSide() != null && scenario_0.Sides_ReadOnly.Contains(activeUnits_.GetUnitSide()) && ((!activeUnits_.IsWeapon && activeUnits_.GetUnitSide() == this) || GetConsidersThisSideToBe(activeUnits_.GetUnitSide()) == Misc.PostureStance.Friendly))
					{
						list.Add(activeUnits_);
					}
				}
				m_DispatcherProxy = list;
			}
			return m_DispatcherProxy;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101061", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> dispatcherProxy = m_DispatcherProxy;
			ProjectData.ClearProjectError();
			return dispatcherProxy;
		}
	}

	[SpecialName]
	public void SetFriendlyUnits(Scenario scenario_0, List<ActiveUnit> list_0)
	{
		m_DispatcherProxy = list_0;
	}

	[SpecialName]
	public List<LoggedMessage> GetMessageLog_Hybrid(Scenario scenario_0)
	{
		int count = scenario_0.MessageLog.Count;
		List<LoggedMessage> list = new List<LoggedMessage>(count);
		try
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					LoggedMessage loggedMessage = scenario_0.MessageLog[i];
					if (loggedMessage != null && (loggedMessage.Side == null || loggedMessage.Side == this))
					{
						list.Add(loggedMessage);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200065", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	public Side(string string_0, ref Scenario scenario_0)
	{
		algoFacade = new Dictionary<Side, Misc.PostureStance>();
		_DatabaseFacade = new Dictionary<string, Misc.PostureStance>();
		iteratorFacade = new List<Module_Unit.Unit>();
		m_RoleFacade = new List<Mission>();
		factoryFacade = new List<ScenarioGoal>();
		SpecialActions = new Dictionary<string, SpecialAction>();
		FlushOrder(new ObservableDictionary<string, Contact>());
		OrderOrder(new ObservableDictionary<string, Contact>());
		Contacts_NonAU = new HashSet<string>();
		_ParamsFacade = new TDictionary<string, Contact>();
		m_InfoFacade = new TDictionary<string, Contact>();
		m_HelperFacade = new TDictionary<string, Contact>();
		m_MapperFacade = new TDictionary<string, Contact>();
		managerFacade = new TDictionary<string, Contact>();
		Units = new List<ActiveUnit>();
		RefPoints_Slugtrail = new ObservableList<ReferencePoint>();
		RefPoints = new ObservableList<ReferencePoint>();
		RefPointsTag_raw = new Dictionary<string, ReferencePointFlag>();
		RefPointsTag = new Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>>();
		List<ActiveUnit> list_ = null;
		Doctrine = new Doctrine(this, ref list_);
		AAR = new _AAR();
		ExclusionZones = new List<ExclusionZone>();
		NoNavZones = new List<NoNavZone>();
		CustomEnvironmentZones = new List<CustomEnvironmentZone>();
		StandardZones = new List<Zone>();
		AssignsCollectiveResponsibility = true;
		CanAutoTrackCivs = false;
		QuickJumpSlots = new Dictionary<int, QuickJumpSlot>();
		WeaponSalvos = new WeaponSalvo[0];
		ScoringLog = new List<string>();
		Cache_ContactStancesOnThisPulse = new Dictionary<string, Misc.PostureStance>();
		processProxy = new ConcurrentDictionary<string, int>();
		m_ThreadProxy = new Dictionary<Contact, List<WeaponSalvo>>();
		ruleProxy = new TDictionary<string, bool>();
		m_ListenerProxy = new ActiveUnit[0];
		m_ConfigProxy = new HashSet<string>();
		m_RegistryProxy = new HashSet<string>();
		definitionProxy = new Queue<Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>>>();
		EmconAlertness = new EmconLevel();
		Nature = false;
		Chalks = new List<Chalk>();
		_ObserverProxy = new List<Chalk>();
		LandingPlans = new List<LandingPlan>();
		DisableMultiDomainTOT = false;
		ContactsJustSharedWithMe = new HashSet<string>();
		consumerProxy = RuntimeHelpers.GetObjectValue(new object());
		Name = string_0;
	}

	internal void PublishOrder()
	{
		object takeBackMySalvo_LockObj = GameGeneral._TakeBackMySalvo_LockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(takeBackMySalvo_LockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(takeBackMySalvo_LockObj, ref lockTaken);
			foreach (WeaponSalvo item in GetWeaponSalvos().ToList())
			{
				WeaponSalvo weaponSalvo_ = item;
				if (DateTime.Compare(weaponSalvo_.ScheduledFireTime, DateTime.MaxValue) != 0)
				{
					continue;
				}
				int num = weaponSalvo_.MaxNumberOfWeapons;
				try
				{
					int num2 = 0;
					WeaponSalvo.Shooter[] shootersList3 = weaponSalvo_.ShootersList;
					WeaponSalvo.Shooter[] array = shootersList3;
					foreach (WeaponSalvo.Shooter shooter in array)
					{
						num -= shooter.QuantityFired;
						if (num2 > 0)
						{
							num -= shooter.QuantityAssigned;
						}
						num2++;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 10106244", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				foreach (ActiveUnit item2 in Units.ToList())
				{
					try
					{
						if (item2 == null || !item2.IsWeapon)
						{
							continue;
						}
						Weapon Local_theW = (Weapon)item2;
						if (!Local_theW.IsPalletWeapon || weaponSalvo_.ShootersList.Where((WeaponSalvo.Shooter x) => Operators.CompareString(x.ShooterObjectID, Local_theW.FiringParent.ObjectID, TextCompare: false) == 0).FirstOrDefault() == null || weaponSalvo_.ShootersList.Where((WeaponSalvo.Shooter x) => Operators.CompareString(x.ShooterObjectID, Local_theW.ObjectID, TextCompare: false) == 0).FirstOrDefault() != null)
						{
							continue;
						}
						if (Local_theW.WeaponWeapons == null || Local_theW.WeaponWeapons.Count == 0)
						{
							Local_theW.InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in Local_theW.WeaponWeapons)
						{
							if (weaponWeapon.GetReferenceWeapon(item2.ParentScen).DBID != weaponSalvo_.int_0 || weaponWeapon.CurrentLoad <= 0)
							{
								continue;
							}
							int num3 = weaponWeapon.CurrentLoad;
							foreach (WeaponSalvo weaponSalvo in item2.GetUnitSide().GetWeaponSalvos())
							{
								if (weaponSalvo.int_0 != weaponSalvo_.int_0)
								{
									continue;
								}
								WeaponSalvo.Shooter[] shootersList2 = weaponSalvo.ShootersList;
								WeaponSalvo.Shooter[] array2 = shootersList2;
								foreach (WeaponSalvo.Shooter shooter2 in array2)
								{
									if (Operators.CompareString(shooter2.ShooterObjectID, Local_theW.ObjectID, TextCompare: false) == 0)
									{
										num3 = weaponWeapon.CurrentLoad - (shooter2.QuantityAssigned + shooter2.QuantityFired);
									}
								}
							}
							if (num3 > 0 && num != 0)
							{
								if (num3 < num)
								{
									item2.GetUnitSide().AddShooterToExistingSalvo(ref weaponSalvo_, num3, 0, num3, bool_0: false, ref Local_theW.ObjectID);
									weaponSalvo_.ShootersList.Last().QuantityAssigned = num3;
									weaponSalvo_.ShootersList[0].QuantityAssigned = weaponSalvo_.ShootersList[0].QuantityAssigned - num3;
									weaponSalvo_.MaxNumberOfShooters = weaponSalvo_.ShootersList.Count();
									num -= num3;
								}
								else
								{
									item2.GetUnitSide().AddShooterToExistingSalvo(ref weaponSalvo_, num, 0, num3, bool_0: false, ref Local_theW.ObjectID);
									weaponSalvo_.ShootersList.Last().QuantityAssigned = num;
									weaponSalvo_.ShootersList[0].QuantityAssigned = weaponSalvo_.ShootersList[0].QuantityAssigned - num;
									num = 0;
								}
							}
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 101062444416", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			foreach (WeaponSalvo item3 in GetWeaponSalvos().ToList())
			{
				try
				{
					if (DateTime.Compare(item3.ScheduledFireTime, DateTime.MaxValue) != 0 || item3.ShootersList.Count() == 1)
					{
						continue;
					}
					WeaponSalvo.Shooter shooter3 = item3.ShootersList.ElementAt(0);
					_ = item3.WpnQuantityAssigned;
					List<int> list = new List<int>();
					WeaponSalvo.Shooter[] shootersList = item3.ShootersList;
					WeaponSalvo.Shooter[] array3 = shootersList;
					foreach (WeaponSalvo.Shooter shooter4 in array3)
					{
						if (Operators.CompareString(shooter4.ShooterObjectID, shooter3.ShooterObjectID, TextCompare: false) != 0)
						{
							list.Add(shooter4.QuantityAssigned);
						}
					}
					if (shooter3.QuantityAssigned == 0)
					{
						ArrayExtensions.Remove(ref item3.ShootersList, shooter3);
						int num4 = 0;
						WeaponSalvo.Shooter[] shootersList4 = item3.ShootersList;
						for (int i = 0; i < shootersList4.Length; i = checked(i + 1))
						{
							shootersList4[i].QuantityAssigned = list[num4];
							num4++;
						}
						item3.MaxNumberOfShooters = item3.ShootersList.Count();
						item3.ScheduledFireTime = DateTime.MinValue;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 101062440000", "");
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(takeBackMySalvo_LockObj);
			}
		}
	}

	public void HandleUnitHasFiredWeapon(ActiveUnit activeUnit_0, Contact contact_0, WeaponRec weaponRec_0)
	{
		if (Information.IsNothing(contact_0))
		{
			return;
		}
		try
		{
			if (contact_0.Type == Contact_Base.ContactType.Aimpoint || contact_0.Type == Contact_Base.ContactType.ActivationPoint || weaponRec_0.GetReferenceWeapon(activeUnit_0.ParentScen).IsDecoy || (contact_0.ActualUnit.GetUnitSide() != this && contact_0.ActualUnit.GetUnitSide().GetConsidersThisSideToBe(this) != Misc.PostureStance.Friendly))
			{
				return;
			}
			foreach (Contact value in Contacts.Values)
			{
				if (value.GetIsDestroyed(activeUnit_0.ParentScen) || value.ActualUnit != activeUnit_0)
				{
					continue;
				}
				if (value.GetStance(this) == Misc.PostureStance.Hostile || value.ActualUnit.IsWeapon)
				{
					break;
				}
				bool flag = false;
				string text = "";
				if (!Information.IsNothing(value.m_WorkerObserver))
				{
					float? workerObserver = value.m_WorkerObserver;
					if ((workerObserver.HasValue ? new bool?(workerObserver.GetValueOrDefault() < 30f) : null).GetValueOrDefault())
					{
						flag = true;
						text = "（原因：视线观察到了武器发射）";
					}
				}
				if (!flag && !Information.IsNothing(value.m_AccountObserver))
				{
					float? accountObserver = value.m_AccountObserver;
					if ((accountObserver.HasValue ? new bool?(accountObserver.GetValueOrDefault() < 30f) : null).GetValueOrDefault())
					{
						flag = true;
						text = "（原因：通过红外线发现武器发射）";
					}
				}
				if (!flag && !Information.IsNothing(value.authenticationObserver))
				{
					float? authenticationObserver = value.authenticationObserver;
					if ((authenticationObserver.HasValue ? new bool?(authenticationObserver.GetValueOrDefault() < 30f) : null).GetValueOrDefault())
					{
						flag = true;
						text = "（原因：被动声纳探测到武器发射）";
					}
				}
				if (flag)
				{
					value.SetStance(this, bool_0: false, Misc.PostureStance.Hostile);
					activeUnit_0.ParentScen.AddMessage("目标：" + value.Name + "观察到正在攻击一个友方单元，因此现在被认为是敌对的！" + text, value.Name + " is HOSTILE!", LoggedMessage.MessageType.ContactChange, 0, null, this, new Geopoint_Struct(value.GetLongitude(), value.GetLatitude()));
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101062", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PasteIntermittentConfig(Alertlevels alertlevels_0, ActiveEmissionInterval activeEmissionInterval_0)
	{
		foreach (ActiveUnit unit in Units)
		{
			if (unit.Sensors_ReadOnly().Length != 0)
			{
				unit.Sensory.InterruptConsumer().PasteConfig(alertlevels_0, activeEmissionInterval_0);
			}
		}
	}

	public void HandleUnitGoingInoperative(ActiveUnit activeUnit_0)
	{
		try
		{
			IEnumerable<Contact> enumerable = Contacts.Values.Where((Contact theC) => theC.ActualUnit == activeUnit_0);
			new List<Contact>();
			foreach (Contact item in enumerable)
			{
				DropContact(item, ref activeUnit_0.ParentScen, bool_0: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101063", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SelectedUnits_Add(Module_Unit.Unit unit_0, bool bool_0 = true)
	{
		if (!iteratorFacade.Contains(unit_0))
		{
			iteratorFacade.Add(unit_0);
		}
		if (bool_0)
		{
			valProxy?.Invoke();
		}
	}

	public void SelectedUnits_Remove(Module_Unit.Unit unit_0)
	{
		iteratorFacade.Remove(unit_0);
		valProxy?.Invoke();
	}

	public void SelectedUnits_Clear(bool bool_0 = true)
	{
		iteratorFacade.Clear();
		if (bool_0)
		{
			valProxy?.Invoke();
		}
	}

	public void RaiseSelectedUnitsChanged()
	{
		valProxy?.Invoke();
	}

	public void HandleUnitDestruction(ActiveUnit activeUnit_0, bool bool_0)
	{
		if (activeUnit_0.GetUnitSide() == this)
		{
			return;
		}
		List<Mission.Flight> list = new List<Mission.Flight>();
		if (activeUnit_0.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)activeUnit_0;
			if (aircraft.AssignedMissionOrPackage() != null)
			{
				if (aircraft.Navigator.HasFlight)
				{
					foreach (Mission.Flight flight in aircraft.AssignedMissionOrPackage().FlightList)
					{
						if (flight.GetAUCurrentlyAssigned(aircraft.AssignedMissionOrPackage(), aircraft.ParentScen).Count <= 0)
						{
							list.Add(flight);
						}
					}
				}
				foreach (Mission.Flight item in list)
				{
					Mission.Flight flight_ = item;
					Mission mission = aircraft.AssignedMissionOrPackage();
					ref Scenario parentScen = ref aircraft.ParentScen;
					Side side_ = aircraft.GetUnitSide();
					mission.DeleteFlight(ref parentScen, ref side_, ref flight_, flight_.ObjectID);
					aircraft.SetUnitSide(bool_0: false, side_);
				}
			}
		}
		List<Contact> list2 = new List<Contact>();
		List<Contact> list3 = new List<Contact>();
		try
		{
			foreach (Contact value in Contacts.Values)
			{
				if (value.ActualUnit == activeUnit_0)
				{
					list2.Add(value);
				}
			}
			foreach (Contact item2 in list2)
			{
				DropContact(item2, ref activeUnit_0.ParentScen, !bool_0);
				if (SelectedUnits.Contains(item2))
				{
					SelectedUnits_Remove(item2);
				}
			}
			foreach (Contact value2 in BaseContacts.Values)
			{
				if (value2.ActualUnit == activeUnit_0)
				{
					list3.Add(value2);
				}
			}
			foreach (Contact item3 in list3)
			{
				DropBaseContact(item3, ref activeUnit_0.ParentScen, !bool_0);
				if (SelectedUnits.Contains(item3))
				{
					SelectedUnits_Remove(item3);
				}
			}
			ref Scenario parentScen2 = ref activeUnit_0.ParentScen;
			Side side_2 = this;
			MissionPlanner.UpdateStrikeMissionWaypoints_AirborneAircraft(0f, ref parentScen2, ref side_2, ref activeUnit_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101064", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DiscardExpiredContacts(Scenario scenario_0)
	{
		try
		{
			List<Contact> list = new List<Contact>();
			foreach (Contact value in Contacts.Values)
			{
				if (value.IsDueToExpire)
				{
					list.Add(value);
				}
			}
			foreach (Contact item in list)
			{
				DropContact(item, ref scenario_0, this == scenario_0.GetCurrentSide());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300011", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool AwakeOrder(ActiveUnit activeUnit_0)
	{
		return Contacts.Values.Where((Contact theC) => theC.ActualUnit == activeUnit_0).Count() > 0;
	}

	[SpecialName]
	public Misc.PostureStance GetConsidersThisSideToBe(Side side_0)
	{
		if (side_0 == null)
		{
			return Misc.PostureStance.Unknown;
		}
		if (side_0 == this)
		{
			return Misc.PostureStance.Friendly;
		}
		if (algoFacade.TryGetValue(side_0, out var value))
		{
			return value;
		}
		return Misc.PostureStance.Neutral;
	}

	[SpecialName]
	public void SetConsidersThisSideToBe(Side side_0, Misc.PostureStance postureStance_0)
	{
		try
		{
			if (side_0 == null)
			{
				return;
			}
			bool? flag;
			if (algoFacade.ContainsKey(side_0))
			{
				flag = algoFacade[side_0] != postureStance_0;
				if (flag.GetValueOrDefault())
				{
					algoFacade[side_0] = postureStance_0;
				}
			}
			else
			{
				flag = true;
				algoFacade.Add(side_0, postureStance_0);
			}
			if (flag.GetValueOrDefault())
			{
				foreach (Contact value in Contacts.Values)
				{
					if (value.SideIsKnown && !Information.IsNothing(value.ActualUnit) && !Information.IsNothing(value.ActualUnit.GetUnitSide()) && value.ActualUnit.GetUnitSide() == side_0)
					{
						value.SetStance(this, bool_0: false, postureStance_0);
						value.RetreivedPostureOnThisPulse = false;
					}
				}
				foreach (Contact value2 in BaseContacts.Values)
				{
					if (value2.SideIsKnown && !Information.IsNothing(value2.ActualUnit) && !Information.IsNothing(value2.ActualUnit.GetUnitSide()) && value2.ActualUnit.GetUnitSide() == side_0)
					{
						value2.SetStance(this, bool_0: false, postureStance_0);
						value2.RetreivedPostureOnThisPulse = false;
					}
				}
			}
			if (!flag.GetValueOrDefault())
			{
				return;
			}
			if (Contacts.Count > 0 && !Information.IsNothing(Contacts.Values.ElementAtOrDefault(0).ActualUnit))
			{
				Scenario parentScen = Contacts.Values.ElementAtOrDefault(0).ActualUnit.ParentScen;
				Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
				Side[] sides_ReadOnly = parentScen.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					HashSet<string> hashSet = new HashSet<string>();
					side.GetAllFriendlySides(parentScen, hashSet);
					hashSet.Remove(side.ObjectID);
					dictionary.Add(side.ObjectID, hashSet);
				}
				GameGeneral.DeconflictContactsBetweenAllies(parentScen, dictionary);
			}
			if ((postureStance_0 == Misc.PostureStance.Unfriendly || postureStance_0 == Misc.PostureStance.Hostile) && Units.Count > 0)
			{
				switch (postureStance_0)
				{
				case Misc.PostureStance.Hostile:
					Units[0].ParentScen.AddMessage("分方'" + side_0.Name + "' is now considered HOSTILE to " + Name, side_0.Name + " is now HOSTILE to " + Name, LoggedMessage.MessageType.ContactChange, 0, null);
					break;
				case Misc.PostureStance.Unfriendly:
					Units[0].ParentScen.AddMessage("分方'" + side_0.Name + "' is now considered UNFRIENDLY to " + Name, side_0.Name + " is now UNFRIENDLY to " + Name, LoggedMessage.MessageType.ContactChange, 0, null);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101065", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void GetAllFriendlySides(Scenario scenario_0, HashSet<string> hashSet_0)
	{
		try
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array2 = sides_ReadOnly;
			foreach (Side side in array2)
			{
				if (side != this && GetConsidersThisSideToBe(side) == Misc.PostureStance.Friendly)
				{
					hashSet_0.Add(side.ObjectID);
				}
			}
			string[] array = hashSet_0.ToArray();
			string[] array3 = array;
			foreach (string Local_sideHash in array3)
			{
				Misc.PostureStance value = Misc.PostureStance.Neutral;
				Side side2 = scenario_0.Sides_ReadOnly.First((Side F) => Operators.CompareString(F.ObjectID, Local_sideHash, TextCompare: false) == 0);
				if (algoFacade.TryGetValue(side2, out value) && !Information.IsNothing(value) && value != Misc.PostureStance.Friendly)
				{
					hashSet_0.Remove(side2.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101066", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void QueryOrder(object sender, NotifyDictionaryChangedEventArgs<string, Contact> e)
	{
		Contacts_List = null;
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			m_ReaderProxy?.Invoke(ObjectID, e.NewItem.Value.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Remove:
			propertyProxy?.Invoke(ObjectID, e.OldItem.Value.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Reset:
		{
			foreach (KeyValuePair<string, Contact> oldItem in e.OldItems)
			{
				propertyProxy?.Invoke(ObjectID, oldItem.Value.ActualUnit.ObjectID);
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	private void ResetOrder(object sender, NotifyDictionaryChangedEventArgs<string, Contact> e)
	{
		BaseContacts_List = null;
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			m_ImporterProxy?.Invoke(ObjectID, e.NewItem.Value.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Remove:
			m_RepositoryProxy?.Invoke(ObjectID, e.OldItem.Value.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Reset:
		{
			foreach (KeyValuePair<string, Contact> oldItem in e.OldItems)
			{
				m_RepositoryProxy?.Invoke(ObjectID, oldItem.Value.ActualUnit.ObjectID);
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	public ReadOnlyCollection<WeaponSalvo> GetWeaponSalvos()
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		list.AddRange(WeaponSalvos);
		return list.AsReadOnly();
	}

	public void AddFiringProposal(ActiveUnit activeUnit_0, Weapon weapon_0, int? nullable_0, int? nullable_1, Contact contact_0, DateTime dateTime_0)
	{
		try
		{
			if (callbackProxy == null)
			{
				callbackProxy = new ConcurrentDictionary<string, FiringProposal>();
			}
			if (callbackProxy.Count > 0)
			{
				foreach (FiringProposal item in new List<FiringProposal>(callbackProxy.Values))
				{
					if (Operators.CompareString(item.FiringUnit.ObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0 && Operators.CompareString(item.Target.ObjectID, contact_0.ObjectID, TextCompare: false) == 0)
					{
						return;
					}
				}
			}
			FiringProposal firingProposal = new FiringProposal();
			firingProposal.FiringUnit = activeUnit_0;
			firingProposal.QuantityToFire = nullable_0;
			firingProposal.QuantityAvailable = nullable_1;
			firingProposal.Target = contact_0;
			firingProposal.int_0 = weapon_0.DBID;
			if (dateTime_0.Equals(DateTime.MinValue))
			{
				firingProposal.Distance = Module_Unit.RangeToUnit_Slant(activeUnit_0, contact_0);
			}
			else
			{
				firingProposal.ETA = dateTime_0;
			}
			bool? nullable_2 = null;
			Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_0, ref nullable_2);
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_0, ref contact_0, ref _WRA_WeaponTargetType_, ObjectID);
			Doctrine doctrine = activeUnit_0.Doctrine;
			Scenario parentScen = activeUnit_0.ParentScen;
			Weapon weapon_ = weapon_0;
			int? nullable_3 = null;
			int? nullable_4 = null;
			int? num = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine, parentScen, weapon_, wRA_WeaponTargetType_, bool_0: false, ref nullable_3, ref nullable_4);
			nullable_4 = num;
			if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -99) : null).GetValueOrDefault())
			{
				num = int.MaxValue;
			}
			if (!num.HasValue)
			{
				num = 1;
			}
			firingProposal.ShooterQuantity = num;
			callbackProxy.TryAdd(firingProposal.ObjectID, firingProposal);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 5452154874321324447", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveFireProposal(ActiveUnit activeUnit_0, Contact contact_0)
	{
		if (!((activeUnit_0 != null && contact_0 != null) & (callbackProxy != null)))
		{
			return;
		}
		IEnumerator<KeyValuePair<string, FiringProposal>> enumerator = callbackProxy.GetEnumerator();
		while (enumerator.MoveNext())
		{
			FiringProposal value = enumerator.Current.Value;
			if (Operators.CompareString(value.FiringUnit.ObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0 && Operators.CompareString(value.Target.ObjectID, contact_0.ObjectID, TextCompare: false) == 0)
			{
				callbackProxy.TryRemove(value.ObjectID, out value);
				break;
			}
		}
	}

	public void RemoveFireProposal(FiringProposal firingProposal_0)
	{
		Module_Unit.Unit firingUnit = firingProposal_0.FiringUnit;
		Contact target = firingProposal_0.Target;
		if ((firingUnit != null && target != null) & (callbackProxy != null))
		{
			FiringProposal value = new List<FiringProposal>(callbackProxy.Values).Where((FiringProposal theFP) => (Operators.CompareString(theFP.FiringUnit.ObjectID, firingUnit.ObjectID, TextCompare: false) == 0) & (Operators.CompareString(theFP.Target.ObjectID, target.ObjectID, TextCompare: false) == 0)).FirstOrDefault();
			if (value != null)
			{
				callbackProxy.TryRemove(value.ObjectID, out value);
			}
		}
	}

	public List<WeaponSalvo> WeaponSalvosForThisTarget(Contact contact_0)
	{
		try
		{
			if (contact_0 == null)
			{
				return new List<WeaponSalvo>();
			}
			if (m_ThreadProxy.TryGetValue(contact_0, out var value))
			{
				return value;
			}
			return new List<WeaponSalvo>();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200549", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<WeaponSalvo> result = new List<WeaponSalvo>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public List<Weapon> WeaponsLeftToFireAtThisTarget(ref ActiveUnit activeUnit_0, ref Contact contact_0)
	{
		List<Weapon> list = new List<Weapon>();
		try
		{
			for (int i = activeUnit_0.GetUnitSide().WeaponSalvos.Length - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo = activeUnit_0.GetUnitSide().WeaponSalvos[i];
				if (contact_0 != weaponSalvo.Target)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				for (int j = 0; j < shootersList.Length; j = checked(j + 1))
				{
					if (Operators.CompareString(shootersList[j].ShooterObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0)
					{
						list.Add(weaponSalvo.GetReferenceWeapon(activeUnit_0.ParentScen));
					}
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200550", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Weapon> result = new List<Weapon>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public int NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref ActiveUnit activeUnit_0, ref Contact contact_0, ref ActiveUnit_AI.TargetingEntry._TargetingBehavior _TargetingBehavior_0)
	{
		int num = activeUnit_0.GetUnitSide().WeaponSalvos.Length;
		try
		{
			int num2 = 0;
			for (int i = num - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo;
				try
				{
					if (activeUnit_0.GetUnitSide().WeaponSalvos.Length == 0)
					{
						continue;
					}
					if (activeUnit_0.GetUnitSide().WeaponSalvos.Length - 1 < i)
					{
						i = activeUnit_0.GetUnitSide().WeaponSalvos.Length - 1;
					}
					weaponSalvo = activeUnit_0.GetUnitSide().WeaponSalvos[i];
					goto IL_00c9;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200651", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					_ = Debugger.IsAttached;
					ProjectData.ClearProjectError();
				}
				continue;
				IL_00c9:
				if (weaponSalvo == null || contact_0 != weaponSalvo.Target)
				{
					continue;
				}
				for (int j = weaponSalvo.ShootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter;
					try
					{
						if (weaponSalvo.ShootersList.Length != 0)
						{
							if (weaponSalvo.ShootersList.Length - 1 < j)
							{
								j = weaponSalvo.ShootersList.Length - 1;
							}
							shooter = weaponSalvo.ShootersList[j];
							goto IL_0199;
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200467", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					continue;
					IL_0199:
					if (Information.IsNothing(shooter) || Operators.CompareString(shooter.ShooterObjectID, activeUnit_0.ObjectID, TextCompare: false) != 0)
					{
						continue;
					}
					if (shooter.QuantityAssigned != int.MaxValue)
					{
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							num2 += shooter.QuantityAssigned - shooter.QuantityFired;
							if (weaponSalvo.ManualFire)
							{
								_TargetingBehavior_0 = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
							}
						}
						continue;
					}
					return shooter.QuantityAssigned;
				}
			}
			return num2;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 200551", exception_3.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public int NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref ActiveUnit activeUnit_0, Weapon weapon_0, bool bool_0 = false, bool bool_1 = false)
	{
		try
		{
			WeaponSalvo[] weaponSalvos = activeUnit_0.GetUnitSide().WeaponSalvos;
			int num = 0;
			WeaponSalvo[] array = weaponSalvos;
			WeaponSalvo[] array2 = array;
			foreach (WeaponSalvo weaponSalvo in array2)
			{
				if (weapon_0.DBID == weaponSalvo.int_0)
				{
					WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
					WeaponSalvo.Shooter[] array3 = shootersList;
					foreach (WeaponSalvo.Shooter shooter in array3)
					{
						if (Operators.CompareString(shooter.ShooterObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0)
						{
							if (shooter.QuantityAssigned == int.MaxValue)
							{
								return shooter.QuantityAssigned;
							}
							if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
							{
								num += shooter.QuantityAssigned - shooter.QuantityFired;
							}
						}
					}
					continue;
				}
				if (num == 0 && !bool_1 && weapon_0.Warheads.Count() > 0)
				{
					Warhead[] warheads = weaponSalvo.GetReferenceWeapon(activeUnit_0.ParentScen).Warheads;
					Warhead[] array4 = warheads;
					foreach (Warhead warhead in array4)
					{
						if (warhead.GetCarriedWeapon(activeUnit_0.ParentScen) != null)
						{
							int num2 = NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, warhead.GetCarriedWeapon(activeUnit_0.ParentScen), bool_0: false, bool_1: true);
							if (num2 > 0)
							{
								return num2;
							}
						}
					}
				}
				if (!activeUnit_0.IsPalletWeapon || ((Weapon)activeUnit_0).Warheads.Count() <= 0)
				{
					continue;
				}
				foreach (WeaponRec weaponWeapon in ((Weapon)activeUnit_0).WeaponWeapons)
				{
					if (weaponWeapon.GetReferenceWeapon(activeUnit_0.ParentScen).DBID == weapon_0.DBID)
					{
						_ = weaponWeapon.CurrentLoad;
					}
				}
			}
			if (num == 0 && activeUnit_0.IsPalletWeapon && ((Weapon)activeUnit_0).Warheads.Count() > 0)
			{
				foreach (WeaponRec weaponWeapon2 in ((Weapon)activeUnit_0).WeaponWeapons)
				{
					if (weaponWeapon2.GetReferenceWeapon(activeUnit_0.ParentScen).DBID == weapon_0.DBID)
					{
						num = weaponWeapon2.CurrentLoad;
					}
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200552", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public int NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref ActiveUnit activeUnit_0)
	{
		try
		{
			WeaponSalvo[] weaponSalvos = activeUnit_0.GetUnitSide().WeaponSalvos;
			int num = 0;
			for (int i = 0; i < weaponSalvos.Length; i = checked(i + 1))
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvos[i].ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0)
					{
						if (shooter.QuantityAssigned == int.MaxValue)
						{
							return shooter.QuantityAssigned;
						}
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							num += shooter.QuantityAssigned - shooter.QuantityFired;
						}
					}
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200553", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public List<WeaponSalvo> WeaponSalvosFromThisUnitToThisTarget(ref ActiveUnit activeUnit_0, ref Contact contact_0)
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		try
		{
			WeaponSalvo[] weaponSalvos = activeUnit_0.GetUnitSide().WeaponSalvos;
			WeaponSalvo[] array = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array)
			{
				if (contact_0 != weaponSalvo.Target)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				for (int i = 0; i < shootersList.Length; i = checked(i + 1))
				{
					if (Operators.CompareString(shootersList[i].ShooterObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0)
					{
						list.Add(weaponSalvo);
					}
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200554", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<WeaponSalvo> result = new List<WeaponSalvo>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public List<WeaponSalvo> WeaponSalvosFromThisUnitToAnyTarget(ref ActiveUnit activeUnit_0)
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		try
		{
			WeaponSalvo[] weaponSalvos = activeUnit_0.GetUnitSide().WeaponSalvos;
			WeaponSalvo[] array = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array)
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				for (int i = 0; i < shootersList.Length; i = checked(i + 1))
				{
					if (Operators.CompareString(shootersList[i].ShooterObjectID, activeUnit_0.ObjectID, TextCompare: false) == 0)
					{
						list.Add(weaponSalvo);
					}
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200555", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<WeaponSalvo> result = new List<WeaponSalvo>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public List<WeaponSalvo> WeaponSalvosFromAnyUnitToThisTarget(ref Contact contact_0, ref Side side_0)
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		try
		{
			WeaponSalvo[] weaponSalvos = side_0.WeaponSalvos;
			WeaponSalvo[] array = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array)
			{
				if (contact_0 == weaponSalvo.Target)
				{
					list.Add(weaponSalvo);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200556", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<WeaponSalvo> result = new List<WeaponSalvo>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public int? ConvertSalvoWeaponQty_To_ActualQuantity(int? nullable_0, ref ActiveUnit activeUnit_0, ref Contact contact_0, ref Weapon weapon_0)
	{
		int? num = nullable_0;
		int? num2 = num;
		int? result;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -2) : null).GetValueOrDefault())
		{
			nullable_0 = activeUnit_0.Weaponry.InsertConsumer(ref contact_0);
		}
		else
		{
			num2 = num;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -5) : null).GetValueOrDefault())
			{
				nullable_0 = activeUnit_0.Weaponry.InsertConsumer(ref contact_0);
				num2 = nullable_0;
				if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					num2 = nullable_0;
					if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						num2 = nullable_0;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > 2) : null).GetValueOrDefault())
						{
							nullable_0 = (int)Math.Round(Math.Round((double)nullable_0.Value / 2.0, 0));
						}
						goto IL_0451;
					}
				}
				result = 1;
				goto IL_0457;
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -6) : null).GetValueOrDefault())
			{
				nullable_0 = activeUnit_0.Weaponry.InsertConsumer(ref contact_0);
				num2 = nullable_0;
				bool? flag = (num2.HasValue ? new bool?(num2.GetValueOrDefault() >= 1) : null);
				if (flag.GetValueOrDefault(true))
				{
					num2 = nullable_0;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() <= 4) : null).GetValueOrDefault() && flag.HasValue)
					{
						result = 1;
						goto IL_0457;
					}
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > 4) : null).GetValueOrDefault())
				{
					nullable_0 = (int)Math.Round(Math.Round((double)nullable_0.Value / 4.0, 0));
				}
			}
			else
			{
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -3) : null).GetValueOrDefault())
				{
					nullable_0 = Convert.ToInt32(Math.Round(new decimal(activeUnit_0.Weaponry.InsertConsumer(ref contact_0) * 2), 0));
				}
				else
				{
					num2 = num;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -4) : null).GetValueOrDefault())
					{
						nullable_0 = Convert.ToInt32(Math.Round(new decimal(activeUnit_0.Weaponry.InsertConsumer(ref contact_0) * 4), 0));
					}
					else
					{
						num2 = num;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -1) : null).GetValueOrDefault())
						{
							if (weapon_0.IsPalletWeapon)
							{
								weapon_0.InitializeWeaponWeaponsPallet();
								weapon_0 = weapon_0.WeaponWeapons[0].GetReferenceWeapon(activeUnit_0.ParentScen);
							}
							bool? nullable_ = null;
							Doctrine doctrine = activeUnit_0.Doctrine;
							Scenario parentScen = activeUnit_0.ParentScen;
							Weapon weapon_ = weapon_0;
							Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_0, ref nullable_);
							num2 = null;
							int? nullable_2 = null;
							nullable_0 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, weapon_, wRA_WeaponTargetType_, bool_0: false, ref num2, ref nullable_2);
						}
					}
				}
			}
		}
		goto IL_0451;
		IL_0457:
		return result;
		IL_0451:
		return nullable_0;
	}

	public bool UnassignSalvoFromTarget(WeaponSalvo weaponSalvo_0)
	{
		if (!Information.IsNothing(weaponSalvo_0) && m_ThreadProxy.ContainsKey(weaponSalvo_0.Target))
		{
			m_ThreadProxy[weaponSalvo_0.Target].Remove(weaponSalvo_0);
			return true;
		}
		return false;
	}

	public WeaponSalvo AssignSalvoToTarget(Scenario scenario_0, ref Weapon weapon_0, ref Contact contact_0, int? nullable_0, int int_0, int? nullable_1, bool bool_0, ref string string_0, ref int? nullable_2, [Optional][DateTimeConstant(0L)] DateTime ScheduledTime, [Optional][DateTimeConstant(0L)] DateTime ETA)
	{
		if (Information.IsNothing(nullable_2))
		{
			nullable_2 = 1;
		}
		if (Information.IsNothing(nullable_0))
		{
			nullable_0 = int.MaxValue;
		}
		if (Information.IsNothing(nullable_1))
		{
			nullable_1 = int.MaxValue;
		}
		int? num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == int.MaxValue) : null).GetValueOrDefault())
		{
			nullable_1 = nullable_0;
		}
		bool bool_ = true;
		if (weapon_0.IsGuidedWeapon() || weapon_0.IsTorpedo || weapon_0.IsReEntryVehicle || weapon_0.IsVehicleDecoy)
		{
			bool_ = false;
		}
		WeaponSalvo weaponSalvo = new WeaponSalvo(ref weapon_0.DBID, nullable_0.Value, int_0, nullable_1.Value, ref contact_0, ref bool_0, string_0, nullable_2.Value, bool_, ScheduledTime);
		ArrayExtensions.Add(ref WeaponSalvos, weaponSalvo);
		if (m_ThreadProxy.ContainsKey(weaponSalvo.Target))
		{
			m_ThreadProxy[weaponSalvo.Target].Add(weaponSalvo);
		}
		else
		{
			m_ThreadProxy.Add(weaponSalvo.Target, new List<WeaponSalvo>(new WeaponSalvo[1] { weaponSalvo }));
		}
		weaponSalvo.ETA = ETA;
		return weaponSalvo;
	}

	public void AddShooterToExistingSalvo(ref WeaponSalvo weaponSalvo_0, int? nullable_0, int int_0, int? nullable_1, bool bool_0, ref string string_0, bool bool_1 = false)
	{
		try
		{
			if (!nullable_1.HasValue)
			{
				nullable_1 = int.MaxValue;
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = int.MaxValue;
			}
			int? num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == int.MaxValue) : null).GetValueOrDefault())
			{
				nullable_1 = nullable_0;
			}
			if (bool_0)
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvo_0.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, string_0, TextCompare: false) == 0)
					{
						if (shooter.QuantityAssigned < int.MaxValue)
						{
							shooter.QuantityAssigned += nullable_0.Value;
						}
						break;
					}
				}
				weaponSalvo_0.MaxNumberOfWeapons += nullable_0.Value;
				weaponSalvo_0.ManualFire = bool_0;
				return;
			}
			int wpnQuantityAssigned = weaponSalvo_0.WpnQuantityAssigned;
			int maxNumberOfWeapons = weaponSalvo_0.MaxNumberOfWeapons;
			if (bool_1)
			{
				int num2 = 0;
				WeaponSalvo.Shooter[] shootersList2 = weaponSalvo_0.ShootersList;
				WeaponSalvo.Shooter[] array2 = shootersList2;
				foreach (WeaponSalvo.Shooter shooter2 in array2)
				{
					num2 = ((shooter2.QuantityAssigned == int.MaxValue) ? int.MaxValue : (num2 + shooter2.QuantityAssigned));
					shooter2.QuantityAssigned = 0;
				}
				WeaponSalvo.Shooter theAC = new WeaponSalvo.Shooter(string_0, Math.Min(nullable_0.Value, nullable_1.Value), int_0);
				ArrayExtensions.Add(ref weaponSalvo_0.ShootersList, theAC);
				weaponSalvo_0.ShootersList[0].QuantityAssigned = num2;
				return;
			}
			if (maxNumberOfWeapons != -99)
			{
				num = nullable_1;
				int num3 = maxNumberOfWeapons - wpnQuantityAssigned;
				bool? flag = (num.HasValue ? new bool?(num.GetValueOrDefault() > num3) : null);
				if (flag.GetValueOrDefault(true))
				{
					num = nullable_1;
					bool? flag2 = (num.HasValue ? new bool?(num.GetValueOrDefault() == int.MaxValue) : null);
					if (((!flag2) ?? flag2).GetValueOrDefault() && flag.HasValue)
					{
						nullable_1 = maxNumberOfWeapons - wpnQuantityAssigned;
					}
				}
			}
			WeaponSalvo.Shooter theAC2 = new WeaponSalvo.Shooter(string_0, nullable_1.Value, int_0);
			ArrayExtensions.Add(ref weaponSalvo_0.ShootersList, theAC2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200557", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void StopShootingSalvo(ref Scenario scenario_0, ref ActiveUnit activeUnit_0, ref Contact contact_0, ref WeaponSalvo weaponSalvo_0)
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		try
		{
			if (activeUnit_0.GetUnitSide().WeaponSalvos.Length == 0)
			{
				return;
			}
			WeaponSalvo[] array = Misc.CheckRequest<WeaponSalvo>(activeUnit_0.GetUnitSide().WeaponSalvos);
			for (int i = array.Length - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo_ = array[i];
				if (weaponSalvo_ == null || (contact_0 != null && weaponSalvo_.Target != contact_0) || (weaponSalvo_0 != null && weaponSalvo_ != weaponSalvo_0))
				{
					continue;
				}
				List<WeaponSalvo.Shooter> list2 = new List<WeaponSalvo.Shooter>();
				WeaponSalvo.Shooter[] array2 = Misc.CheckRequest<WeaponSalvo.Shooter>(weaponSalvo_.ShootersList);
				for (int j = array2.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter = array2[j];
					if (activeUnit_0 != null && shooter != null && Operators.CompareString(activeUnit_0.ObjectID, shooter.ShooterObjectID, TextCompare: false) == 0)
					{
						if (shooter.QuantityFired == 0)
						{
							DetonateSalvoWeapons(ref scenario_0, null, shooter.ShooterObjectID, ref weaponSalvo_);
							list2.Add(shooter);
						}
						else
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
						}
						break;
					}
				}
				foreach (WeaponSalvo.Shooter item in list2)
				{
					ArrayExtensions.Remove(ref weaponSalvo_.ShootersList, item);
					list.Add(weaponSalvo_);
				}
			}
			for (int k = list.Count - 1; k >= 0; k += -1)
			{
				WeaponSalvo weaponSalvo_2 = list[k];
				AttemptToRemoveWeaponSalvo(ref scenario_0, weaponSalvo_2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200558", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveWeaponFromSalvos(ref Scenario scenario_0, ref string string_0)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			WeaponSalvo[] weaponSalvos = WeaponSalvos;
			WeaponSalvo[] array = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array)
			{
				List<string> list2 = new List<string>();
				string[] weaponList = weaponSalvo.WeaponList;
				for (int i = 0; i < weaponList.Length; i = checked(i + 1))
				{
					if (Operators.CompareString(weaponList[i], string_0, TextCompare: false) == 0)
					{
						list2.Add(string_0);
						break;
					}
				}
				foreach (string item in list2)
				{
					ArrayExtensions.Remove(ref weaponSalvo.WeaponList, item);
					list.Add(weaponSalvo);
				}
			}
			foreach (WeaponSalvo item2 in list)
			{
				AttemptToRemoveWeaponSalvo(ref scenario_0, item2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200559", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DetonateSalvoWeapons(ref Scenario scenario_0, Contact contact_0, string string_0, ref WeaponSalvo weaponSalvo_0)
	{
		if (contact_0 == null || contact_0.ActualUnit == null)
		{
			return;
		}
		string string_ = null;
		for (int i = weaponSalvo_0.WeaponList.Count() - 1; i >= 0; i += -1)
		{
			string Local_theWeaponObjectID = weaponSalvo_0.WeaponList[i];
			if (scenario_0.UnguidedWeapons.ContainsKey(Local_theWeaponObjectID))
			{
				UnguidedWeapon unguidedWeapon = scenario_0.UnguidedWeapons.Values.Where((UnguidedWeapon theW) => Operators.CompareString(theW.ObjectID, Local_theWeaponObjectID, TextCompare: false) == 0).ElementAtOrDefault(0);
				if (unguidedWeapon != null && (unguidedWeapon.Type == Weapon._WeaponType.IronBomb || unguidedWeapon.Type == Weapon._WeaponType.Rocket || unguidedWeapon.Type == Weapon._WeaponType.DepthCharge))
				{
					ActiveUnit actualUnit = contact_0.ActualUnit;
					LockRandom lockRandom_ = GameGeneral.LockRandom_0;
					unguidedWeapon.VerifyWatcher(actualUnit, contact_0, ref scenario_0, ref lockRandom_, string_);
					unguidedWeapon.DestroyMe(ref scenario_0, string_);
				}
			}
		}
	}

	public void RemoveWeaponSalvosForThisTarget(ref Scenario scenario_0, Contact contact_0)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			for (int i = WeaponSalvos.Length - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo_ = WeaponSalvos[i];
				if (weaponSalvo_.Target == contact_0)
				{
					DetonateSalvoWeapons(ref scenario_0, contact_0, null, ref weaponSalvo_);
					if (WeaponSalvos.Contains(weaponSalvo_))
					{
						list.Add(weaponSalvo_);
					}
				}
			}
			for (int j = list.Count - 1; j >= 0; j += -1)
			{
				WeaponSalvo theAC = list[j];
				ArrayExtensions.Remove(ref WeaponSalvos, theAC);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200564", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveUnitFromSalvos(ref Scenario scenario_0, string string_0)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			for (int i = WeaponSalvos.Length - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo_ = WeaponSalvos[i];
				List<WeaponSalvo.Shooter> list2 = new List<WeaponSalvo.Shooter>();
				for (int j = weaponSalvo_.ShootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter = weaponSalvo_.ShootersList[j];
					if (Operators.CompareString(shooter.ShooterObjectID, string_0, TextCompare: false) == 0)
					{
						DetonateSalvoWeapons(ref scenario_0, null, string_0, ref weaponSalvo_);
						if (weaponSalvo_.ShootersList.Contains(shooter))
						{
							list2.Add(shooter);
						}
						break;
					}
				}
				foreach (WeaponSalvo.Shooter item in list2)
				{
					ArrayExtensions.Remove(ref weaponSalvo_.ShootersList, item);
					list.Add(weaponSalvo_);
				}
			}
			for (int k = list.Count - 1; k >= 0; k += -1)
			{
				WeaponSalvo weaponSalvo_2 = list[k];
				AttemptToRemoveWeaponSalvo(ref scenario_0, weaponSalvo_2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200563", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveThisUnitFromThisSalvos(ref Scenario scenario_0, string string_0, ref WeaponSalvo weaponSalvo_0)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			for (int i = WeaponSalvos.Length - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo_ = WeaponSalvos[i];
				if (weaponSalvo_ != weaponSalvo_0)
				{
					continue;
				}
				List<WeaponSalvo.Shooter> list2 = new List<WeaponSalvo.Shooter>();
				for (int j = weaponSalvo_.ShootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter = weaponSalvo_.ShootersList[j];
					if (Operators.CompareString(shooter.ShooterObjectID, string_0, TextCompare: false) == 0)
					{
						DetonateSalvoWeapons(ref scenario_0, null, string_0, ref weaponSalvo_);
						if (weaponSalvo_.ShootersList.Contains(shooter))
						{
							list2.Add(shooter);
						}
						break;
					}
				}
				foreach (WeaponSalvo.Shooter item in list2)
				{
					ArrayExtensions.Remove(ref weaponSalvo_.ShootersList, item);
					list.Add(weaponSalvo_);
				}
			}
			for (int k = list.Count - 1; k >= 0; k += -1)
			{
				WeaponSalvo weaponSalvo_2 = list[k];
				AttemptToRemoveWeaponSalvo(ref scenario_0, weaponSalvo_2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200562", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AttemptToRemoveWeaponSalvo(ref Scenario scenario_0, WeaponSalvo weaponSalvo_0, bool bool_0 = false)
	{
		if (weaponSalvo_0.WeaponList.Count() > 0)
		{
			return;
		}
		if (weaponSalvo_0.WpnQuantityFired < weaponSalvo_0.WpnQuantityAssigned)
		{
			if (weaponSalvo_0.ShootersList.Length == 0)
			{
				ArrayExtensions.Remove(ref WeaponSalvos, weaponSalvo_0);
			}
			else
			{
				if (weaponSalvo_0.WeaponList.Count() != 0 || weaponSalvo_0.WpnQuantityFired <= 0 || (weaponSalvo_0.ManualFire && (!weaponSalvo_0.ManualFire || !SimConfiguration.DefaultGamePreferences.SalvoTimeout)))
				{
					return;
				}
				if (weaponSalvo_0.FireSimultaneouslyFromMultipleMounts)
				{
					if (!weaponSalvo_0.ManualFire)
					{
						ArrayExtensions.Remove(ref WeaponSalvos, weaponSalvo_0);
					}
					return;
				}
				WeaponSalvo.Shooter[] shootersList = weaponSalvo_0.ShootersList;
				for (int num = 0; num < shootersList.Length; num = checked(num + 1))
				{
					if (shootersList[num].TimeToNextLaunch > 0)
					{
						return;
					}
				}
				if (!weaponSalvo_0.ManualFire || weaponSalvo_0.GetReferenceWeapon(scenario_0).Guidance != Weapon.WeaponGuidanceType.CommandGuided_Datalinked)
				{
					ArrayExtensions.Remove(ref WeaponSalvos, weaponSalvo_0);
				}
			}
		}
		else
		{
			if (bool_0)
			{
				UnassignSalvoFromTarget(weaponSalvo_0);
			}
			ArrayExtensions.Remove(ref WeaponSalvos, weaponSalvo_0);
		}
	}

	public void MissionSalvoWeaponQty()
	{
		try
		{
			foreach (Mission mission in Missions)
			{
				if (mission.MissionClass != Mission._MissionClass.Strike)
				{
					continue;
				}
				Strike strike = (Strike)mission;
				if (strike.Type != Strike.StrikeType.Land_Strike && strike.Type != Strike.StrikeType.Maritime_Strike)
				{
					continue;
				}
				foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
				{
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200561", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal int MapOrder()
	{
		decoratorProxy++;
		return decoratorProxy;
	}

	private void SortOrder(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		try
		{
			foreach (ReferencePoint item in observableListModified_0.Items)
			{
				foreach (Mission item2 in m_RoleFacade)
				{
					if (item2.MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol patrol = (Patrol)item2;
						if (patrol.PatrolArea.Contains(item))
						{
							patrol.PatrolArea.Remove(item);
						}
						if (patrol.ProsecutionArea.Contains(item))
						{
							patrol.ProsecutionArea.Remove(item);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101067", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Side(string string_0, ref Scenario scenario_0, bool bool_0 = true)
	{
		algoFacade = new Dictionary<Side, Misc.PostureStance>();
		_DatabaseFacade = new Dictionary<string, Misc.PostureStance>();
		iteratorFacade = new List<Module_Unit.Unit>();
		m_RoleFacade = new List<Mission>();
		factoryFacade = new List<ScenarioGoal>();
		SpecialActions = new Dictionary<string, SpecialAction>();
		FlushOrder(new ObservableDictionary<string, Contact>());
		OrderOrder(new ObservableDictionary<string, Contact>());
		Contacts_NonAU = new HashSet<string>();
		_ParamsFacade = new TDictionary<string, Contact>();
		m_InfoFacade = new TDictionary<string, Contact>();
		m_HelperFacade = new TDictionary<string, Contact>();
		m_MapperFacade = new TDictionary<string, Contact>();
		managerFacade = new TDictionary<string, Contact>();
		Units = new List<ActiveUnit>();
		RefPoints_Slugtrail = new ObservableList<ReferencePoint>();
		RefPoints = new ObservableList<ReferencePoint>();
		RefPointsTag_raw = new Dictionary<string, ReferencePointFlag>();
		RefPointsTag = new Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>>();
		List<ActiveUnit> list_ = null;
		Doctrine = new Doctrine(this, ref list_);
		AAR = new _AAR();
		ExclusionZones = new List<ExclusionZone>();
		NoNavZones = new List<NoNavZone>();
		CustomEnvironmentZones = new List<CustomEnvironmentZone>();
		StandardZones = new List<Zone>();
		AssignsCollectiveResponsibility = true;
		CanAutoTrackCivs = false;
		QuickJumpSlots = new Dictionary<int, QuickJumpSlot>();
		WeaponSalvos = new WeaponSalvo[0];
		ScoringLog = new List<string>();
		Cache_ContactStancesOnThisPulse = new Dictionary<string, Misc.PostureStance>();
		processProxy = new ConcurrentDictionary<string, int>();
		m_ThreadProxy = new Dictionary<Contact, List<WeaponSalvo>>();
		ruleProxy = new TDictionary<string, bool>();
		m_ListenerProxy = new ActiveUnit[0];
		m_ConfigProxy = new HashSet<string>();
		m_RegistryProxy = new HashSet<string>();
		definitionProxy = new Queue<Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>>>();
		EmconAlertness = new EmconLevel();
		Nature = false;
		Chalks = new List<Chalk>();
		_ObserverProxy = new List<Chalk>();
		LandingPlans = new List<LandingPlan>();
		DisableMultiDomainTOT = false;
		ContactsJustSharedWithMe = new HashSet<string>();
		consumerProxy = RuntimeHelpers.GetObjectValue(new object());
		Name = string_0;
		Nature = bool_0;
	}

	internal bool CalcOrder()
	{
		return Nature;
	}
}
