using System.Xml;

namespace Command_Core;

public sealed class AimpointContact : Contact
{
	public AimpointContact(double double_0, double double_1)
		: base(null)
	{
		Type = ContactType.Aimpoint;
		SetLatitude(null, double_0);
		SetLongitude(null, double_1);
		SetCurrentAltitude(bool_0: false, Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, (ActualUnit == null) ? null : ActualUnit.ParentScen));
		Name = "瞄准点：" + Misc.CoordsToEnglish(GetLatitude(), GetLongitude());
		ObjectID_Set("Aimpoint_" + XmlConvert.ToString(GetLatitude()) + "_" + XmlConvert.ToString(GetLongitude()));
	}

	public static AimpointContact FromString(string string_0)
	{
		string[] array = string_0.Split('_');
		double double_ = XmlConvert.ToDouble(array[1]);
		double double_2 = XmlConvert.ToDouble(array[2]);
		return new AimpointContact(double_, double_2);
	}
}
