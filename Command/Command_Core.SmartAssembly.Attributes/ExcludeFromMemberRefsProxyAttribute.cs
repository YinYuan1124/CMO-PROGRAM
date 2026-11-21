using System;

namespace Command_Core.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
public sealed class ExcludeFromMemberRefsProxyAttribute : Attribute
{
}
