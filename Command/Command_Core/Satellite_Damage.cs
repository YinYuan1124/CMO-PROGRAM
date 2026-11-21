using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Satellite_Damage : ActiveUnit_Damage
{
	private Satellite m_RegistryFacade;

	[SpecialName]
	private Satellite GetSatellite()
	{
		if (Information.IsNothing(m_RegistryFacade))
		{
			m_RegistryFacade = (Satellite)myUnit;
		}
		return m_RegistryFacade;
	}

	public Satellite_Damage(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	protected override void ResolveDamageFromDirectImpact(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ref ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2)
	{
		if (weapon_0.Type == Weapon._WeaponType.LaserDazzler)
		{
			double num = Module_Unit.RangeToPoint_Slant(myUnit, geoPoint_0) / weapon_0.MaxRange_NoTargetType;
			double num2 = 1.0 - num;
			ResolveDamageFromDazzler((float)num2);
		}
		else
		{
			myUnit.SetDamagePts(bool_0: false, null, -1f);
			myUnit.ParentScen.DestroyThisUnit(myUnit, "Direct impact. Satellite destroyed.", "Weapon Interaction");
		}
	}
}
