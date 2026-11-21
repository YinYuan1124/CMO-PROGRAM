namespace Command_Core;

public class Contact_Base : Module_Unit.Unit
{
	public enum ContactType : byte
	{
		Air,
		Missile,
		Surface,
		Submarine,
		UndeterminedNaval,
		Aimpoint,
		Orbital,
		Facility_Fixed,
		Facility_Mobile,
		Torpedo,
		Mine,
		Explosion,
		Undetermined,
		Decoy_Air,
		Decoy_Surface,
		Decoy_Land,
		Decoy_Sub,
		Sonobuoy,
		Installation,
		AirBase,
		NavalBase,
		MobileGroup,
		ActivationPoint
	}

	public enum IdentificationStatus : short
	{
		Unknown,
		KnownDomain,
		KnownType,
		KnownClass,
		PreciseID
	}

	public ContactType Type;

	public bool SideIsKnown;

	protected int _AutoIncrement;

	protected IdentificationStatus _IDStatus;

	public Side OriginalDetectorSide;

	protected string _OriginalDetectorSide_Name;

	public string ContactType_String
	{
		get
		{
			ContactType type = Type;
			if (1 == 0)
			{
			}
			string result = type switch
			{
				ContactType.Air => "Air", 
				ContactType.Missile => "Missile", 
				ContactType.Surface => "Surface", 
				ContactType.Submarine => "Submarine", 
				ContactType.UndeterminedNaval => "未确定的海军", 
				ContactType.Aimpoint => "Aimpoint", 
				ContactType.Orbital => "Orbital", 
				ContactType.Facility_Fixed => "固定设施", 
				ContactType.Facility_Mobile => "移动单元", 
				ContactType.Torpedo => "Torpedo", 
				ContactType.Mine => "Mine", 
				ContactType.Explosion => "Explosion", 
				ContactType.Undetermined => "Undetermined", 
				ContactType.Decoy_Air => "诱饵（空中）", 
				ContactType.Decoy_Surface => "诱饵（水面）", 
				ContactType.Decoy_Land => "诱饵（地面）", 
				ContactType.Decoy_Sub => "诱饵（水下）", 
				ContactType.Sonobuoy => "Sonobuoy", 
				ContactType.Installation => "固定安装", 
				ContactType.AirBase => "AirBase", 
				ContactType.NavalBase => "海军基地", 
				ContactType.MobileGroup => "移动编队", 
				ContactType.ActivationPoint => "激活点", 
				_ => Type.ToString(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}
}
