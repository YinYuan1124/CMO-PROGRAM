namespace CSMaterial;

public struct BLENDFUNCTION
{
	private byte m_ThreadDispatcher;

	private byte m_RuleDispatcher;

	private byte collectionDispatcher;

	private byte _InstanceDispatcher;

	public BLENDFUNCTION(byte byte_0, byte byte_1, byte byte_2, byte byte_3)
	{
		m_ThreadDispatcher = byte_0;
		m_RuleDispatcher = byte_1;
		collectionDispatcher = byte_2;
		_InstanceDispatcher = byte_3;
	}
}
