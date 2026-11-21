using System;

namespace OpenDis.Core;

[AttributeUsage(AttributeTargets.Field, Inherited = true)]
public sealed class InternetDomainCodeAttribute : Attribute
{
	private string fieldCallback;

	public string InternetDomainCode => fieldCallback;

	public InternetDomainCodeAttribute(string string_0)
	{
		fieldCallback = string_0;
	}
}
