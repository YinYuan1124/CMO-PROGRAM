using System;

namespace SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
[DoNotPrune]
[DoNotObfuscate]
public sealed class DoNotCaptureFieldsAttribute : Attribute
{
}
