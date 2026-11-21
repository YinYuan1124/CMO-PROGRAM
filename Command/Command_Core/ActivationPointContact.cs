using System.Xml;

namespace Command_Core;

public sealed class ActivationPointContact : Contact
{
	public ActivationPointContact(double double_0, double double_1)
		: base(null)
	{
		Type = ContactType.ActivationPoint;
		SetLatitude(null, double_0);
		SetLongitude(null, double_1);
		Name = "方位攻击BOL激活点：" + Misc.CoordsToEnglish(GetLatitude(), GetLongitude());
		ObjectID_Set("ActivationPoint_" + XmlConvert.ToString(GetLatitude()) + "_" + XmlConvert.ToString(GetLongitude()));
	}

	public static ActivationPointContact FromString(string string_0)
	{
		string[] array = string_0.Split('_');
		double double_ = XmlConvert.ToDouble(array[1]);
		double double_2 = XmlConvert.ToDouble(array[2]);
		return new ActivationPointContact(double_, double_2);
	}
}
