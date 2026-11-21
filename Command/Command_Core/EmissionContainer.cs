using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EmissionContainer
{
	public float Age;

	public bool IsIllumination;

	public bool PreciseID;

	private Sensor _ListenerClient;

	[SpecialName]
	public Sensor GetAssociatedSensor(int int_0, Scenario scenario_0)
	{
		if (_ListenerClient == null && !scenario_0.Cache_AssociatedSensors.TryGetValue(int_0, out _ListenerClient))
		{
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			_ListenerClient = DBFunctions.GetSensor(int_0, ref sqliteConnection_);
			scenario_0.Cache_AssociatedSensors.TryAdd(int_0, _ListenerClient);
		}
		return _ListenerClient;
	}

	[SpecialName]
	public string GetID_Description(int int_0, Scenario scenario_0)
	{
		if (_ListenerClient == null)
		{
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			_ListenerClient = DBFunctions.GetSensor(int_0, ref sqliteConnection_);
		}
		if (_ListenerClient.IsOECM)
		{
			return "JAMMER";
		}
		string result = "";
		if (PreciseID)
		{
			result = _ListenerClient.Name;
		}
		else if (_ListenerClient.IsSonar)
		{
			if (_ListenerClient.SearchFreqs.Count() > 0)
			{
				Sensor.FrequencyBand frequencyBand = _ListenerClient.SearchFreqs[0].Band - 4001;
				if ((ulong)frequencyBand <= 3uL && (ulong)frequencyBand <= 3uL)
				{
					Sensor.FrequencyBand frequencyBand2 = frequencyBand;
					Sensor.FrequencyBand frequencyBand3 = frequencyBand2;
					if ((ulong)frequencyBand3 <= 3uL)
					{
						switch (frequencyBand3)
						{
						case (Sensor.FrequencyBand)0L:
							result = "LF声纳";
							break;
						case (Sensor.FrequencyBand)1L:
							result = "MF声纳";
							break;
						case (Sensor.FrequencyBand)2L:
							result = "HF声纳";
							break;
						case (Sensor.FrequencyBand)3L:
							result = "VLF声纳";
							break;
						}
					}
				}
			}
		}
		else
		{
			result = _ListenerClient.RoleDescription;
		}
		return result;
	}

	public EmissionContainer(double double_0, bool bool_0, bool bool_1)
	{
		Age = (float)double_0;
		IsIllumination = bool_0;
		PreciseID = bool_1;
	}

	public override string ToString()
	{
		return XmlConvert.ToString(Age) + "-" + IsIllumination + "-" + PreciseID;
	}

	public static EmissionContainer FromString(ref string string_0)
	{
		string[] array = string_0.Split('-');
		double double_ = XmlConvert.ToSingle(array[0]);
		bool bool_ = Conversions.ToBoolean(array[1]);
		bool bool_2 = Conversions.ToBoolean(array[2]);
		return new EmissionContainer(double_, bool_, bool_2);
	}
}
