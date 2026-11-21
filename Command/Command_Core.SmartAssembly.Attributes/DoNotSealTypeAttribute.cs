using System;

namespace Command_Core.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DoNotSealTypeAttribute : Attribute
{
}
