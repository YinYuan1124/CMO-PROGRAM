using System.Runtime.CompilerServices;
using DarkUI.Docking;
using OpenDis.Candidates;

namespace Command.Tasks;

internal class InstanceCollectionTask
{
	[CompilerGenerated]
	private TokenCallbackCandidate _SerializerParameter;

	[CompilerGenerated]
	private TokenCallbackCandidate m_RefParameter;

	[CompilerGenerated]
	private TokenCallbackCandidate m_ErrorParameter;

	[SpecialName]
	[CompilerGenerated]
	internal TokenCallbackCandidate ResolveConfig()
	{
		return _SerializerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void PostConfig(TokenCallbackCandidate tokenCallbackCandidate_0)
	{
		_SerializerParameter = tokenCallbackCandidate_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal TokenCallbackCandidate StartConfig()
	{
		return m_RefParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void AssetConfig(TokenCallbackCandidate tokenCallbackCandidate_0)
	{
		m_RefParameter = tokenCallbackCandidate_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal TokenCallbackCandidate DefineConfig()
	{
		return m_ErrorParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void PublishConfig(TokenCallbackCandidate tokenCallbackCandidate_0)
	{
		m_ErrorParameter = tokenCallbackCandidate_0;
	}

	internal InstanceCollectionTask(DarkDockPanel darkDockPanel_0, DarkDockGroup darkDockGroup_0)
	{
		PostConfig(new TokenCallbackCandidate(darkDockPanel_0, darkDockGroup_0, DockInsertType.None));
		AssetConfig(new TokenCallbackCandidate(darkDockPanel_0, darkDockGroup_0, DockInsertType.Before));
		PublishConfig(new TokenCallbackCandidate(darkDockPanel_0, darkDockGroup_0, DockInsertType.After));
	}
}
