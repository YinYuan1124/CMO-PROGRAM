using DXRenderer;

namespace Command.Specifications;

internal interface ValueDefinitionSpec
{
	void Handle(RenderEvent renderEvent_0, object object_0 = null);

	object MoveInterruptibleIdentifier();
}
