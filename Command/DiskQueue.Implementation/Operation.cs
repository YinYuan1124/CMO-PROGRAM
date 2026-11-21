using System.Runtime.CompilerServices;

namespace DiskQueue.Implementation;

public sealed class Operation
{
	[CompilerGenerated]
	private int reponseObject;

	[CompilerGenerated]
	private int m_DescriptorObject;

	public OperationType Type { get; set; }

	public int FileNumber
	{
		[CompilerGenerated]
		get
		{
			return reponseObject;
		}
		[CompilerGenerated]
		set
		{
			reponseObject = value;
		}
	}

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorObject;
		}
		[CompilerGenerated]
		set
		{
			m_DescriptorObject = value;
		}
	}

	public int Length { get; set; }

	public Operation(OperationType operationType_0, int int_0, int int_1, int int_2)
	{
		Type = operationType_0;
		FileNumber = int_0;
		Start = int_1;
		Length = int_2;
	}
}
