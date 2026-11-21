using System;
using System.Collections.Generic;

namespace Command_Core;

[Serializable]
public sealed class ImportExportRecord
{
	[Serializable]
	public sealed class MemberRecord
	{
		public int Member_DBID;

		public string Member_GUID;

		public string MemberType;

		public string MemberName;

		public string ParentGroupName;

		public string ParentGroupGUID;

		public double Longitude;

		public double Latitude;

		public double Altitude;

		public double Speed;

		public int LoadoutID;

		public float Orientation;

		public ActiveUnit_Navigator.FormationStation FormationStationPoint;

		public double FormationLatitude;

		public double FormationLongitude;

		public string LastFormationSet;

		public float LastFormationSpacing;

		public byte LastFormationSpacingUnits;

		public List<HostedAircraftRecord> HostedAircraftRecords;

		public List<EmbarkedBoatRecord> EmbarkedBoatRecords;

		public List<MagazineRecord> MagazineRecords;

		public string Member_SBR;

		public MemberRecord()
		{
			ParentGroupName = null;
			ParentGroupGUID = null;
			FormationStationPoint = null;
			LastFormationSet = null;
			LastFormationSpacing = -1f;
			LastFormationSpacingUnits = 0;
			HostedAircraftRecords = new List<HostedAircraftRecord>();
			EmbarkedBoatRecords = new List<EmbarkedBoatRecord>();
			MagazineRecords = new List<MagazineRecord>();
		}
	}

	[Serializable]
	public sealed class HostedAircraftRecord
	{
		public string Name;

		public int AC_DBID;

		public int Loadout_ID;

		public int ReadyTime_Mins;

		public MemberRecord Member;

		public HostedAircraftRecord(string string_0, int int_0, int int_1, int int_2)
		{
			Member = null;
			Name = string_0;
			AC_DBID = int_0;
			Loadout_ID = int_1;
			ReadyTime_Mins = int_2;
		}

		public HostedAircraftRecord()
		{
			Member = null;
		}
	}

	[Serializable]
	public sealed class EmbarkedBoatRecord
	{
		public string Name;

		public int Boat_DBID;

		public int ReadyTime_Mins;

		public string Type;

		public MemberRecord Member;

		public EmbarkedBoatRecord(string string_0, int int_0, int int_1, string string_1)
		{
			Member = null;
			Name = string_0;
			Boat_DBID = int_0;
			ReadyTime_Mins = int_1;
			Type = string_1;
		}

		public EmbarkedBoatRecord()
		{
			Member = null;
		}
	}

	[Serializable]
	public sealed class WeaponRecord
	{
		public string Name;

		public int Weapon_DBID;

		public int Weapon_MaxLoad;

		public int Weapon_Multiple;

		public int Weapon_CurrentLoad;

		public int Weapon_ROF;

		public string Type;

		public WeaponRecord(string string_0, int int_0, int int_1, int int_2, int int_3, int int_4)
		{
			Name = string_0;
			Weapon_DBID = int_0;
			Weapon_MaxLoad = int_1;
			Weapon_Multiple = int_2;
			Weapon_CurrentLoad = int_3;
			Weapon_ROF = int_4;
		}

		public WeaponRecord()
		{
		}
	}

	[Serializable]
	public sealed class MagazineRecord
	{
		public string Name;

		public int Mag_DBID;

		public int ReadyTime_Mins;

		public string Type;

		public List<WeaponRecord> WeaponRecords;

		public MagazineRecord(string string_0, int int_0)
		{
			WeaponRecords = new List<WeaponRecord>();
			Name = string_0;
			Mag_DBID = int_0;
		}

		public MagazineRecord()
		{
			WeaponRecords = new List<WeaponRecord>();
		}
	}

	public int DB_ID;

	public int FormatVersion;

	public List<MemberRecord> MemberRecords;

	public string ValidFrom;

	public string ValidUntil;

	public string Name;

	public string Comments;

	public bool Template;

	public ImportExportRecord()
	{
		MemberRecords = new List<MemberRecord>();
	}
}
