using System;
using System.Collections.Generic;
using Command_Core.SmartAssembly.Attributes;

namespace Command_Core;

[DoNotPrune]
[DoNotObfuscateType]
[DoNotPruneType]
public class UnitLineWrapper
{
	public ChalkUnit ChalkUnit;

	private bool _IteratorProxy;

	public int Index;

	public string Priority
	{
		get
		{
			if (_IteratorProxy)
			{
				return "";
			}
			return ChalkUnit.AssociatedChalk.Priority.ToString();
		}
		set
		{
			int.TryParse(value, out ChalkUnit.AssociatedChalk.Priority);
		}
	}

	public string CurrentTransport
	{
		get
		{
			if (ChalkUnit.TransportErrorMessage.Length <= 0)
			{
				if (ChalkUnit.AssociatedChalk.Preboat == null)
				{
					if (ChalkUnit.CurrentTransport == null)
					{
						return "None";
					}
					if (ChalkUnit.CurrentTransport.ActualTransport == null)
					{
						return "None";
					}
					(float, float, float) tuple = ChalkUnit.CurrentTransport.CalculateWatcher(ChalkUnit);
					return ChalkUnit.CurrentTransport.ActualTransport.Name + " (" + (int)Math.Round(tuple.Item1 * 100f) + "%, " + (int)Math.Round(tuple.Item2 * 100f) + " %," + (int)Math.Round(tuple.Item3 * 100f) + " %)";
				}
				return ChalkUnit.AssociatedChalk.Preboat.ActualTransport.Name + " Preboated";
			}
			return ChalkUnit.TransportErrorMessage;
		}
	}

	public string Serial
	{
		get
		{
			if (_IteratorProxy)
			{
				return "";
			}
			string text = "";
			text = ((ChalkUnit.AssociatedChalk.ID == -1) ? "Pre-Boated" : ChalkUnit.AssociatedChalk.ID.ToString());
			return text + "  ( " + Math.Round(ChalkUnit.AssociatedChalk.ComputeImporter(), 1) + " | " + Math.Round(ChalkUnit.AssociatedChalk.PatchImporter(), 1) + " | " + Math.Round(ChalkUnit.AssociatedChalk.SelectImporter(), 1) + " )";
		}
	}

	public string Unit
	{
		get
		{
			return ChalkUnit.Unit.CargoObjectName;
		}
		set
		{
		}
	}

	public int Wave
	{
		get
		{
			if (ChalkUnit.AssociatedChalk.Preboat == null)
			{
				return ChalkUnit.Wave;
			}
			return 1;
		}
		set
		{
			ChalkUnit.Wave = value;
		}
	}

	public UnitLineWrapper(Chalk chalk_0, Cargo cargo_0, int int_0, int int_1, ActiveUnit activeUnit_0, bool bool_0, Dictionary<string, TransportAvailability> dictionary_0, LandingZoneWrapper landingZoneWrapper_0, int int_2)
	{
		Index = int_2;
		_IteratorProxy = bool_0;
		ChalkUnit = new ChalkUnit(chalk_0, cargo_0, int_0, int_1, activeUnit_0, bool_0, landingZoneWrapper_0);
		foreach (KeyValuePair<string, TransportAvailability> item in dictionary_0)
		{
			ChalkUnit.TransportAvailable.Add(item.Key, item.Value);
		}
	}
}
