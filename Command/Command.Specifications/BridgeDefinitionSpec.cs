using System;
using System.Runtime.CompilerServices;
using System.Threading;
using OpenDis.Resolver;

namespace Command.Specifications;

internal class BridgeDefinitionSpec
{
	[CompilerGenerated]
	private Action productMerchant;

	private IdentifierProcessResolver m_AnnotationMerchant;

	internal event Action SortMerchant
	{
		[CompilerGenerated]
		add
		{
			Action action = productMerchant;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref productMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = productMerchant;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref productMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public BridgeDefinitionSpec()
	{
		m_AnnotationMerchant = new IdentifierProcessResolver(IdentifierProcessResolver.HKeyEnum.LocalMachine, "SYSTEM\\CurrentControlSet\\Control\\Power\\User\\PowerSchemes", bool_0: true);
		m_AnnotationMerchant.ComputeCallback += DefineMerchant;
	}

	private void DefineMerchant()
	{
		PublishMerchant();
	}

	private void PublishMerchant()
	{
		if (productMerchant != null)
		{
			productMerchant();
		}
	}
}
