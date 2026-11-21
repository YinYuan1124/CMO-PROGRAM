using System;

namespace Command.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
public sealed class DoNotObfuscateControlFlowAttribute : Attribute
{
}
