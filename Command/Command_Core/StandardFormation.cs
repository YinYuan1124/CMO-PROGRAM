using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class StandardFormation
{
	public enum FormationType : byte
	{
		RelativeToLead,
		RelativeToPrevious,
		MultiSided
	}

	public static List<StandardFormation> StandardFormationList;

	protected string _Name;

	protected FormationType _Type;

	protected List<ActiveUnit_Navigator.FormationStation> _Stations;

	public string Name => _Name;

	public FormationType Type => _Type;

	static StandardFormation()
	{
		StandardFormationList = new List<StandardFormation>();
	}

	public StandardFormation()
	{
		_Stations = new List<ActiveUnit_Navigator.FormationStation>();
	}

	public static void LoadStandardFormations()
	{
		StandardFormationList.Clear();
		string path = Path.Combine(GameGeneral.ResourcesFolderPath, "Formation\\StandardFormations.txt");
		List<string> list = new List<string>();
		if (!File.Exists(path))
		{
			return;
		}
		try
		{
			StreamReader streamReader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
			while (!streamReader.EndOfStream)
			{
				list.Add(streamReader.ReadLine());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error loading group formation data", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
			return;
		}
		if (list.Count <= 1 || !int.TryParse(list[0], out var result))
		{
			return;
		}
		int num = result;
		for (int i = 1; i <= num; i++)
		{
			StandardFormation standardFormation = new StandardFormation();
			if (standardFormation.NewSpecification(list[i]))
			{
				StandardFormationList.Add(standardFormation);
			}
		}
	}

	public static string SetFormation(ActiveUnit activeUnit_0, string string_0, float float_0, float float_1, int int_0, bool bool_0)
	{
		if (activeUnit_0 == null)
		{
			return "Invalid group or unit is not a group";
		}
		if (activeUnit_0.IsGroup)
		{
			Group group = (Group)activeUnit_0;
			int num = 0;
			if (string.IsNullOrEmpty(string_0))
			{
				return "Invalid formation";
			}
			if (StandardFormationList.Count == 0)
			{
				LoadStandardFormations();
			}
			StandardFormation standardFormation2;
			if (string_0.StartsWith("Custom:", ignoreCase: true, null))
			{
				StandardFormation standardFormation = new StandardFormation();
				if (!standardFormation.NewSpecification(string_0))
				{
					return "Invalid custom formation";
				}
				standardFormation2 = standardFormation;
			}
			else
			{
				using (List<StandardFormation>.Enumerator enumerator = StandardFormationList.GetEnumerator())
				{
					while (enumerator.MoveNext() && string.Compare(enumerator.Current.Name, string_0, ignoreCase: true) != 0)
					{
						num++;
					}
				}
				if (num >= StandardFormationList.Count)
				{
					return "Invalid formation";
				}
				standardFormation2 = StandardFormationList[num];
			}
			float float_2 = float_1;
			if (int_0 == 0)
			{
				float_2 = (float)((double)float_1 * 0.000539957);
			}
			if ((object)float_0 != null)
			{
				group.GroupLead.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_0);
			}
			int num2 = 0;
			int num3 = group.Units.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				standardFormation2.SetFormationStation(group.Units.Values.ElementAtOrDefault(i), num2, float_2);
				if (group.Units.Values.ElementAtOrDefault(i) != group.GroupLead)
				{
					num2++;
				}
			}
			if (bool_0)
			{
				group.GroupLead.CurrentHeading = group.GroupLead.DesiredHeading;
				int num4 = group.Units.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					ActiveUnit activeUnit = group.Units.Values.ElementAtOrDefault(j);
					if (activeUnit != group.GroupLead)
					{
						activeUnit.CurrentHeading = activeUnit.DesiredHeading;
						Tuple<double, double> validatedLatitudeAndLongitude = activeUnit.Navigator.UnitFormationStation.GetValidatedLatitudeAndLongitude(activeUnit, group.GroupLead);
						activeUnit.Teleport(ref activeUnit.ParentScen, validatedLatitudeAndLongitude.Item2, validatedLatitudeAndLongitude.Item1);
					}
				}
			}
			group.LastFormationSet = standardFormation2.Name;
			group.LastFormationSpacing = float_1;
			group.LastFormationSpacingUnits = (byte)int_0;
			return "Ok";
		}
		return "Unit is not a group";
	}

	internal ActiveUnit WriteSpecification(ActiveUnit activeUnit_0, int int_0)
	{
		bool flag = false;
		int num = 1;
		int num2 = activeUnit_0.GetParentGroup().Units.Count - 1;
		while (true)
		{
			if (num2 >= 0)
			{
				if (activeUnit_0.GetParentGroup().Units.Values.ElementAtOrDefault(num2) == activeUnit_0)
				{
					flag = true;
				}
				else if (flag && activeUnit_0.GetParentGroup().Units.Values.ElementAtOrDefault(num2) != activeUnit_0.GetParentGroup().GroupLead)
				{
					if (num == int_0)
					{
						break;
					}
					num++;
				}
				num2 += -1;
				continue;
			}
			return null;
		}
		return activeUnit_0.GetParentGroup().Units.Values.ElementAtOrDefault(num2);
	}

	public void SetFormationStation(ActiveUnit activeUnit_0, int int_0, float float_0)
	{
		if (activeUnit_0.GetParentGroup() == null || activeUnit_0.IsGroupLead())
		{
			return;
		}
		ActiveUnit groupLead = activeUnit_0.GetParentGroup().GroupLead;
		ActiveUnit activeUnit = null;
		int count = activeUnit_0.GetParentGroup().Units.Count;
		int index = int_0 % _Stations.Count;
		int num = 1 + int_0 / _Stations.Count;
		ActiveUnit_Navigator.FormationStation formationStation = new ActiveUnit_Navigator.FormationStation();
		if (_Type == FormationType.MultiSided)
		{
			int num2 = count - 1;
			int num3;
			if (num2 < _Stations.Count)
			{
				num3 = 2;
			}
			else
			{
				int num4 = num2 / _Stations.Count;
				num3 = 2 * num4;
				if (num4 * _Stations.Count < num2)
				{
					int num5 = 0;
					if ((count & (count - 1)) == 0)
					{
						num5 = 1;
					}
					num3 += num2 - num5 - num4 * _Stations.Count;
					if (num3 % 2 == 1)
					{
						num3++;
					}
				}
				if (num3 / 2 == num4 && num2 % 2 == 0)
				{
					num3 += 2;
				}
			}
			num = 1;
			if (int_0 < num3)
			{
				index = int_0 % 2;
				activeUnit = ((int_0 < 2) ? groupLead : WriteSpecification(activeUnit_0, 2));
			}
			else
			{
				index = 2 + int_0 % 2;
				activeUnit = WriteSpecification(activeUnit_0, 2);
			}
		}
		else if (_Type == FormationType.RelativeToPrevious && int_0 > 0)
		{
			activeUnit = WriteSpecification(activeUnit_0, 1);
			if (activeUnit == null)
			{
				activeUnit = groupLead;
			}
		}
		formationStation.BearingType = _Stations[index].BearingType;
		if (activeUnit == null)
		{
			formationStation.Bearing = _Stations[index].Bearing;
			formationStation.Distance = float_0 * _Stations[index].Distance * (float)num;
		}
		else
		{
			float num6 = _Stations[index].Bearing;
			if (formationStation.BearingType == ReferencePoint.OrientationType.Rotating)
			{
				num6 = Math2.UpdateClass(num6 + groupLead.CurrentHeading);
			}
			Tuple<double, double> latitudeAndLongitude = activeUnit.Navigator.UnitFormationStation.GetLatitudeAndLongitude(activeUnit, groupLead);
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(latitudeAndLongitude.Item2, latitudeAndLongitude.Item1, ref double_, ref double_2, float_0, num6);
			formationStation.Distance = Module_Unit.RangeToPoint_Horiz(groupLead, double_2, double_);
			num6 = Math2.PublishClass(groupLead.GetLatitude(), groupLead.GetLongitude(), double_2, double_);
			if (formationStation.BearingType == ReferencePoint.OrientationType.Rotating)
			{
				formationStation.Bearing = Math2.UpdateClass(num6 - groupLead.CurrentHeading);
			}
			else
			{
				formationStation.Bearing = num6;
			}
		}
		activeUnit_0.Navigator.UnitFormationStation = formationStation;
	}

	internal bool NewSpecification(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		string[] array = string_0.Split('\t');
		if (array.Count() > 3)
		{
			_Name = array[0];
			_Type = (FormationType)Conversions.ToByte(array[1]);
			int num = Conversions.ToInteger(array[2]) - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit_Navigator.FormationStation formationStation = new ActiveUnit_Navigator.FormationStation();
				formationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(array[3 + i * 3]);
				formationStation.Bearing = Conversions.ToSingle(array[3 + i * 3 + 1]);
				formationStation.Distance = Conversions.ToSingle(array[3 + i * 3 + 2]);
				_Stations.Add(formationStation);
			}
		}
		return _Stations.Count > 0;
	}
}
