using System;
using System.Runtime.CompilerServices;
using OpenDis.Core;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2006;

public class CetItem : IComparable<ICetItem>, IComparable, ICetItem
{
	[CompilerGenerated]
	private EntityKind m_SingletonCallback;

	[CompilerGenerated]
	private byte? exceptionCallback;

	[CompilerGenerated]
	private byte? m_VisitorCallback;

	public Country Country { get; set; }

	public byte Domain { get; set; }

	public EntityKind Kind
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonCallback;
		}
		[CompilerGenerated]
		set
		{
			m_SingletonCallback = value;
		}
	}

	public byte Category { get; set; }

	public byte? Subcategory
	{
		[CompilerGenerated]
		get
		{
			return exceptionCallback;
		}
		[CompilerGenerated]
		set
		{
			exceptionCallback = value;
		}
	}

	public byte? Specific { get; set; }

	public byte? Extra
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorCallback;
		}
		[CompilerGenerated]
		set
		{
			m_VisitorCallback = value;
		}
	}

	public uint? Maximum { get; set; }

	public string Description { get; set; }

	public int CompareTo(ICetItem other)
	{
		if (other == null)
		{
			return 1;
		}
		int num = Country.ToString().CompareTo(other.Country.ToString());
		if (num == 0)
		{
			int num2 = Domain.CompareTo(other.Domain);
			if (num2 == 0)
			{
				int num3 = Kind.ToString().CompareTo(other.Kind.ToString());
				if (num3 == 0)
				{
					int num4 = Category.CompareTo(other.Category);
					if (num4 == 0)
					{
						if (Subcategory.HasValue)
						{
							int num5 = Subcategory.Value.CompareTo(other.Subcategory);
							if (num5 == 0)
							{
								if (Specific.HasValue)
								{
									int num6 = Specific.Value.CompareTo(other.Specific);
									if (num6 == 0)
									{
										if (Extra.HasValue)
										{
											int num7 = Extra.Value.CompareTo(other.Extra);
											if (num7 == 0)
											{
												if (string.IsNullOrEmpty(Description))
												{
													return 0;
												}
												return Description.CompareTo(other.Description);
											}
											return num7;
										}
										if (other.Extra.HasValue)
										{
											return -1;
										}
										return 0;
									}
									return num6;
								}
								if (other.Specific.HasValue)
								{
									return -1;
								}
								return 0;
							}
							return num5;
						}
						if (other.Subcategory.HasValue)
						{
							return -1;
						}
						return 0;
					}
					return num4;
				}
				return num3;
			}
			return num2;
		}
		return num;
	}

	public int CompareTo(object target)
	{
		if (!(target is CetItem))
		{
			throw new ArgumentException("Object is not of type CetItem.");
		}
		return CompareTo((CetItem)target);
	}
}
