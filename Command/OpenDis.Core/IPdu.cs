using System;
using System.Text;

namespace OpenDis.Core;

public interface IPdu
{
	event EventHandler<PduExceptionEventArgs> ExceptionOccured;

	void Marshal(DataOutputStream dataOutputStream_0);

	void Reflection(StringBuilder stringBuilder_0);

	void Unmarshal(DataInputStream dataInputStream_0);
}
