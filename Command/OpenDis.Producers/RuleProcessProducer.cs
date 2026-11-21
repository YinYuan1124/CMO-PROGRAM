using Microsoft.VisualBasic.CompilerServices;

namespace OpenDis.Producers;

[StandardModule]
internal sealed class RuleProcessProducer
{
	public const string m_IdentifierProxy = "Impact / Detonation";

	public const string printerProxy = "Missed";

	public const string parserProxy = "Weapon Interaction";

	public const string Fuel = "Out of Fuel";

	public const string algoProxy = "Spoofed";

	public const string databaseProxy = "Jammed";

	public const string interceptorProxy = "Malfunction";

	public const string m_MessageProxy = "Sub-munitions Expended";

	public const string Self = "Self-destruct";

	public const string _ProductProxy = "Fire / Flooding";

	public const string _AnnotationProxy = "Host Destruction";
}
