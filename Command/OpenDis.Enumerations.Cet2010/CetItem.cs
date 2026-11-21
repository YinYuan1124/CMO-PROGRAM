using System;
using System.Runtime.CompilerServices;
using OpenDis.Core;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2010;

public class CetItem : IComparable<ICetItem>, IComparable, ICetItem
{
	[CompilerGenerated]
	private byte m_ConfigurationCallback;

	[CompilerGenerated]
	private EntityKind m_TokenCallback;

	[CompilerGenerated]
	private byte m_IndexerCallback;

	[CompilerGenerated]
	private uint? adapterCallback;

	[CompilerGenerated]
	private string m_SchemaCallback;

	public Country Country { get; set; }

	public byte Domain
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationCallback;
		}
		[CompilerGenerated]
		set
		{
			m_ConfigurationCallback = value;
		}
	}

	public EntityKind Kind
	{
		[CompilerGenerated]
		get
		{
			return m_TokenCallback;
		}
		[CompilerGenerated]
		set
		{
			m_TokenCallback = value;
		}
	}

	public byte Category
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerCallback;
		}
		[CompilerGenerated]
		set
		{
			m_IndexerCallback = value;
		}
	}

	public byte? Subcategory { get; set; }

	public byte? Specific { get; set; }

	public byte? Extra { get; set; }

	public uint? Maximum
	{
		[CompilerGenerated]
		get
		{
			return adapterCallback;
		}
		[CompilerGenerated]
		set
		{
			adapterCallback = value;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaCallback;
		}
		[CompilerGenerated]
		set
		{
			m_SchemaCallback = value;
		}
	}

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
