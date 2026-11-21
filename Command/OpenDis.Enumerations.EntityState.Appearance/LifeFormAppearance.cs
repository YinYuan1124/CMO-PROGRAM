using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct LifeFormAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes the damaged visual appearance of an entity")]
	public enum HealthValue : uint
	{
		NoInjury,
		SlightInjury,
		ModerateInjury,
		FatalInjury
	}

	[Description("Describes compliance of life form")]
	public enum ComplianceValue : uint
	{
		Unknown,
		Detained,
		Surrender,
		UsingFists,
		VerbalAbuseLevel1,
		VerbalAbuseLevel2,
		VerbalAbuseLevel3,
		PassiveResistanceLevel1,
		PassiveResistanceLevel2,
		PassiveResistanceLevel3,
		UsingNonLethalWeapon1,
		UsingNonLethalWeapon2,
		UsingNonLethalWeapon3,
		UsingNonLethalWeapon4,
		UsingNonLethalWeapon5,
		UsingNonLethalWeapon6
	}

	[Description("Describes whether Flash Lights are on or off.")]
	public enum FlashLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes the state of the life form")]
	public enum LifeFormStateValue : uint
	{
		Unknown,
		UprightStandingStill,
		UprightWalking,
		UprightRunning,
		Kneeling,
		Prone,
		Crawling,
		Swimming,
		Parachuting,
		Jumping,
		Sitting,
		Squatting,
		Crouching,
		Wading,
		Surrender,
		Detained
	}

	[Description("Describes the frozen status of a life form")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the state of a life form")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes the position of the life form's primary weapon")]
	public enum Weapon1Value : uint
	{
		NoPrimaryWeaponPresent,
		PrimaryWeaponIsStowed,
		PrimaryWeaponIsDeployed,
		PrimaryWeaponIsInFiringPosition
	}

	[Description("Describes the position of the life form's secondary weapon")]
	public enum Weapon2Value : uint
	{
		NoSecondaryWeaponPresent,
		SecondaryWeaponIsStowed,
		SecondaryWeaponIsDeployed,
		SecondaryWeaponIsInFiringPosition
	}

	[Description("Describes the type of camouflage")]
	public enum CamouflageTypeValue : uint
	{
		DesertCamouflage,
		WinterCamouflage,
		ForestCamouflage,
		Unknown
	}

	[Description("Describes the type of stationary concealment")]
	public enum ConcealedStationaryValue : uint
	{
		NotConcealed,
		EntityInAPreparedConcealedPosition
	}

	[Description("Describes the type of concealed movement")]
	public enum ConcealedMovementValue : uint
	{
		OpenMovement,
		RushesBetweenCoveredPositions
	}

	private PaintSchemeValue paintSchemeValue_0;

	private HealthValue healthValue_0;

	private ComplianceValue complianceValue_0;

	private FlashLightsValue flashLightsValue_0;

	private LifeFormStateValue lifeFormStateValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private StateValue stateValue_0;

	private Weapon1Value weapon1Value_0;

	private Weapon2Value weapon2Value_0;

	private CamouflageTypeValue camouflageTypeValue_0;

	private ConcealedStationaryValue concealedStationaryValue_0;

	private ConcealedMovementValue concealedMovementValue_0;

	public PaintSchemeValue PaintScheme
	{
		get
		{
			return paintSchemeValue_0;
		}
		set
		{
			paintSchemeValue_0 = value;
		}
	}

	public HealthValue Health
	{
		get
		{
			return healthValue_0;
		}
		set
		{
			healthValue_0 = value;
		}
	}

	public ComplianceValue Compliance
	{
		get
		{
			return complianceValue_0;
		}
		set
		{
			complianceValue_0 = value;
		}
	}

	public FlashLightsValue FlashLights
	{
		get
		{
			return flashLightsValue_0;
		}
		set
		{
			flashLightsValue_0 = value;
		}
	}

	public LifeFormStateValue LifeFormState
	{
		get
		{
			return lifeFormStateValue_0;
		}
		set
		{
			lifeFormStateValue_0 = value;
		}
	}

	public FrozenStatusValue FrozenStatus
	{
		get
		{
			return frozenStatusValue_0;
		}
		set
		{
			frozenStatusValue_0 = value;
		}
	}

	public StateValue State
	{
		get
		{
			return stateValue_0;
		}
		set
		{
			stateValue_0 = value;
		}
	}

	public Weapon1Value Weapon1
	{
		get
		{
			return weapon1Value_0;
		}
		set
		{
			weapon1Value_0 = value;
		}
	}

	public Weapon2Value Weapon2
	{
		get
		{
			return weapon2Value_0;
		}
		set
		{
			weapon2Value_0 = value;
		}
	}

	public CamouflageTypeValue CamouflageType
	{
		get
		{
			return camouflageTypeValue_0;
		}
		set
		{
			camouflageTypeValue_0 = value;
		}
	}

	public ConcealedStationaryValue ConcealedStationary
	{
		get
		{
			return concealedStationaryValue_0;
		}
		set
		{
			concealedStationaryValue_0 = value;
		}
	}

	public ConcealedMovementValue ConcealedMovement
	{
		get
		{
			return concealedMovementValue_0;
		}
		set
		{
			concealedMovementValue_0 = value;
		}
	}

	public static bool operator !=(LifeFormAppearance lifeFormAppearance_0, LifeFormAppearance lifeFormAppearance_1)
	{
		return !(lifeFormAppearance_0 == lifeFormAppearance_1);
	}

	public static bool operator ==(LifeFormAppearance lifeFormAppearance_0, LifeFormAppearance lifeFormAppearance_1)
	{
		if ((object)lifeFormAppearance_0 == (object)lifeFormAppearance_1)
		{
			return true;
		}
		if ((object)lifeFormAppearance_0 != null && (object)lifeFormAppearance_1 != null)
		{
			return lifeFormAppearance_0.Equals(lifeFormAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(LifeFormAppearance lifeFormAppearance_0)
	{
		return lifeFormAppearance_0.ToUInt32();
	}

	public static explicit operator LifeFormAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static LifeFormAppearance FromByteArray(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_0.Length - 1 || int_0 + 4 > byte_0.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(byte_0, int_0));
	}

	public static LifeFormAppearance smethod_0(uint uint_0)
	{
		LifeFormAppearance result = default(LifeFormAppearance);
		result.PaintScheme = (PaintSchemeValue)(uint_0 & 1u);
		result.Health = (HealthValue)((uint_0 & 0x18) >> 3);
		result.Compliance = (ComplianceValue)((uint_0 & 0x1E0) >> 5);
		result.FlashLights = (FlashLightsValue)((uint_0 & 0x1000) >> 12);
		result.LifeFormState = (LifeFormStateValue)((uint_0 & 0xF0000) >> 16);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		result.Weapon1 = (Weapon1Value)((uint_0 & 0x3000000) >> 24);
		result.Weapon2 = (Weapon2Value)((uint_0 & 0xC000000) >> 26);
		result.CamouflageType = (CamouflageTypeValue)((uint_0 & 0x30000000) >> 28);
		result.ConcealedStationary = (ConcealedStationaryValue)((uint_0 & 0x40000000) >> 30);
		result.ConcealedMovement = (ConcealedMovementValue)((uint_0 & 0x80000000u) >> 31);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is LifeFormAppearance)
		{
			return Equals((LifeFormAppearance)obj);
		}
		return false;
	}

	public bool Equals(LifeFormAppearance lifeFormAppearance_0)
	{
		if ((object)lifeFormAppearance_0 == null)
		{
			return false;
		}
		if (PaintScheme == lifeFormAppearance_0.PaintScheme && Health == lifeFormAppearance_0.Health && Compliance == lifeFormAppearance_0.Compliance && FlashLights == lifeFormAppearance_0.FlashLights && LifeFormState == lifeFormAppearance_0.LifeFormState && FrozenStatus == lifeFormAppearance_0.FrozenStatus && State == lifeFormAppearance_0.State && Weapon1 == lifeFormAppearance_0.Weapon1 && Weapon2 == lifeFormAppearance_0.Weapon2 && CamouflageType == lifeFormAppearance_0.CamouflageType && ConcealedStationary == lifeFormAppearance_0.ConcealedStationary)
		{
			return ConcealedMovement == lifeFormAppearance_0.ConcealedMovement;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Health << 3) | ((uint)Compliance << 5) | ((uint)FlashLights << 12) | ((uint)LifeFormState << 16) | ((uint)FrozenStatus << 21) | ((uint)State << 23) | ((uint)Weapon1 << 24) | ((uint)Weapon2 << 26) | ((uint)CamouflageType << 28) | ((uint)ConcealedStationary << 30) | ((uint)ConcealedMovement << 31);
	}

	public override int GetHashCode()
	{
		return (((((((((((493 + PaintScheme.GetHashCode()) * 29 + Health.GetHashCode()) * 29 + Compliance.GetHashCode()) * 29 + FlashLights.GetHashCode()) * 29 + LifeFormState.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Weapon1.GetHashCode()) * 29 + Weapon2.GetHashCode()) * 29 + CamouflageType.GetHashCode()) * 29 + ConcealedStationary.GetHashCode()) * 29 + ConcealedMovement.GetHashCode();
	}
}
