using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Chalk
{
	private int _BaseObserver;

	public Dictionary<Cargo, int> Cargo;

	public List<string> _CargoIDs;

	public string _AssociatedMothershipID;

	public ActiveUnit AssociatedMothership;

	public int Priority;

	public Transport Preboat;

	public bool SelfTransport;

	public int ID
	{
		get
		{
			return _BaseObserver;
		}
		set
		{
			if (Information.IsNothing(AssociatedMothership))
			{
				_BaseObserver = value;
			}
			else if (ValidateChalkID(value, AssociatedMothership.GetUnitSide()))
			{
				_BaseObserver = value;
			}
		}
	}

	public Chalk()
	{
		Cargo = new Dictionary<Cargo, int>();
		_CargoIDs = new List<string>();
		SelfTransport = false;
	}

	public Chalk(int int_0, ActiveUnit activeUnit_0)
	{
		Cargo = new Dictionary<Cargo, int>();
		_CargoIDs = new List<string>();
		SelfTransport = false;
		ID = int_0;
		AssociatedMothership = activeUnit_0;
	}

	public void AddCargo(Cargo cargo_0)
	{
		if (cargo_0 != null && !Cargo.ContainsKey(cargo_0))
		{
			Cargo.Add(cargo_0, 0);
		}
	}

	public void RemoveCargo(Cargo cargo_0)
	{
	}

	internal string AddImporter(ActiveUnit activeUnit_0, ref float float_0)
	{
		ICargoHost cargoHost = (ICargoHost)activeUnit_0;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			Cargo key = item.Key;
			if (key.RequiredMass <= cargoHost.GetCargo_Mass())
			{
				if (key.RequiredArea <= cargoHost.GetCargo_Area())
				{
					if (key.RequiredCrewSpace <= cargoHost.GetCargo_Crew())
					{
						if (key.RequiredCargoType > cargoHost.GetCargo_Type())
						{
							return "A single cargo exceeds max cargo type size";
						}
						continue;
					}
					return key.Name + " exceeds max PAX";
				}
				return key.Name + " exceeds max area";
			}
			return key.Name + " exceeds max mass";
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float val = ((ComputeImporter() == 0f || cargoHost.GetCargo_Mass() == 0f) ? 0f : (ComputeImporter() / cargoHost.GetCargo_Mass()));
		num2 = ((PatchImporter() == 0f || cargoHost.GetCargo_Area() == 0f) ? 0f : (PatchImporter() / cargoHost.GetCargo_Area()));
		num3 = ((SelectImporter() == 0f || cargoHost.GetCargo_Crew() == 0f) ? 0f : (SelectImporter() / cargoHost.GetCargo_Crew()));
		num = Math.Max(val, num2);
		num = (float_0 = Math.Max(num, num3));
		return "OK";
	}

	internal CargoType DestroyImporter()
	{
		CargoType cargoType = CargoType.NoCargo;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			if (item.Key.RequiredCargoType > cargoType)
			{
				cargoType = item.Key.RequiredCargoType;
			}
		}
		return cargoType;
	}

	internal float ComputeImporter()
	{
		float num = 0f;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			num += item.Key.RequiredMass;
		}
		return num;
	}

	internal float PatchImporter()
	{
		float num = 0f;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			num += item.Key.RequiredArea;
		}
		return num;
	}

	internal float SelectImporter()
	{
		float num = 0f;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			num += item.Key.RequiredCrewSpace;
		}
		return num;
	}

	public static void AddNewChalk(Side side_0, ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 != null)
		{
			side_0.Chalks.Add(new Chalk(FetchHighestChalkSerial(side_0), activeUnit_0));
		}
	}

	public static void RemoveChalk(Side side_0, Chalk chalk_0)
	{
		side_0.Chalks.Contains(chalk_0);
		side_0.Chalks.Remove(chalk_0);
	}

	public static int FetchHighestChalkSerial(Side side_0)
	{
		int num = -5;
		foreach (Chalk chalk in side_0.Chalks)
		{
			if (chalk.ID > num)
			{
				num = chalk.ID;
			}
		}
		return num + 5;
	}

	public static bool ValidateChalkID(int int_0, Side side_0)
	{
		if (int_0 < 0)
		{
			return false;
		}
		foreach (Chalk chalk in side_0.Chalks)
		{
			if (int_0 == chalk.ID)
			{
				return false;
			}
		}
		return true;
	}

	public string ToXML(ref HashSet<string> hashSet_0)
	{
		string result = null;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			stringBuilder.Append("<Chalk>");
			stringBuilder.Append("<ID>").Append(ID).Append("</ID>");
			if (Cargo.Count > 0)
			{
				foreach (KeyValuePair<Cargo, int> item in Cargo)
				{
					stringBuilder.Append("<Cargo>").Append(item.Key.ObjectID).Append("</Cargo>");
				}
			}
			stringBuilder.Append("<AssociatedMothership>").Append(AssociatedMothership.ObjectID).Append("</AssociatedMothership>");
			stringBuilder.Append("</Chalk>");
			result = stringBuilder.ToString();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1005845_b", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static Chalk FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			Chalk chalk = new Chalk();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ID":
						chalk.ID = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Cargo":
						chalk._CargoIDs.Add(xmlNode.InnerText);
						break;
					case "AssociatedMothership":
						chalk._AssociatedMothershipID = xmlNode.InnerText;
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
			return chalk;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1005855_b", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Chalk result = new Chalk();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
