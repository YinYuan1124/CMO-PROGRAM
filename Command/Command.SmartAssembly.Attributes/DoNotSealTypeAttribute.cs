using System;

namespace Command.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DoNotSealTypeAttribute : Attribute
{
}
