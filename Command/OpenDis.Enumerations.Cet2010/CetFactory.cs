using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Command.Managers;
using Command.Specifications;
using OpenDis.Core;
using OpenDis.Resolver;

namespace OpenDis.Enumerations.Cet2010;

public class CetFactory
{
	public static Cet CreateAggregateTypes()
	{
		return ComputeDecorator("OpenDis.Enumerations.Cet2010.AggregateTypes.xml");
	}

	private static Cet ComputeDecorator(string string_0)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cet));
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string_0);
		return (Cet)xmlSerializer.Deserialize(manifestResourceStream);
	}

	public static List<ICetItem> Transform(Cet cet_0)
	{
		List<ICetItem> first = new List<ICetItem>();
		IEnumerable<ICetItem> second = from e in cet_0.Entities
			from j in e.Categories
			select new Struct<Entity, GenericEntryDescription>(e, j) into _003C_003Eh__TransparentIdentifier0
			from k in ((ICategoryOrCategoryRange)_003C_003Eh__TransparentIdentifier0.j).Subcategories
			select new AuthenticationListenerManager<Struct<Entity, GenericEntryDescription>, GenericEntryDescription>(_003C_003Eh__TransparentIdentifier0, k) into _003C_003Eh__TransparentIdentifier1
			from genericEntryDescription_0 in ((ISubcategoryOrSubcategoryRange)_003C_003Eh__TransparentIdentifier1.k).Specifices
			select new ParamsListenerManager<AuthenticationListenerManager<Struct<Entity, GenericEntryDescription>, GenericEntryDescription>, GenericEntryDescription>(_003C_003Eh__TransparentIdentifier1, genericEntryDescription_0) into _003C_003Eh__TransparentIdentifier2
			select new RepositoryDefinitionSpec<ParamsListenerManager<AuthenticationListenerManager<Struct<Entity, GenericEntryDescription>, GenericEntryDescription>, GenericEntryDescription>, GenericEntryDescription>(_003C_003Eh__TransparentIdentifier2, _003C_003Eh__TransparentIdentifier2.genericEntryDescription_0) into _003C_003Eh__TransparentIdentifier3
			from m in ((ISpecificOrSpecificRange)_003C_003Eh__TransparentIdentifier3.Prop_0).Extras
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)_003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.j).Value,
				Country = _003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Country,
				Description = m.Description,
				Domain = _003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Domain,
				Extra = ((!(m is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)m).Value) : ((((GenericEntryRange)m).Min == 0) ? null : new byte?((byte)((GenericEntryRange)m).Min))),
				Maximum = ((!(m is GenericEntryRange)) ? null : ((((GenericEntryRange)m).Max == 0) ? null : new byte?((byte)((GenericEntryRange)m).Max))),
				Kind = _003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Kind,
				Specific = ((!(_003C_003Eh__TransparentIdentifier3.Prop_0 is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)_003C_003Eh__TransparentIdentifier3.Prop_0).Value) : ((((GenericEntryRange)_003C_003Eh__TransparentIdentifier3.Prop_0).Min == 0) ? null : new byte?((byte)((GenericEntryRange)_003C_003Eh__TransparentIdentifier3.Prop_0).Min))),
				Subcategory = ((!(_003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1.k is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)_003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1.k).Value) : ((((GenericEntryRange)_003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1.k).Min == 0) ? null : new byte?((byte)((GenericEntryRange)_003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1.k).Min)))
			};
		IEnumerable<ICetItem> second2 = from e in cet_0.Entities
			from j in e.Categories
			select new Struct<Entity, GenericEntryDescription>(e, j) into _003C_003Eh__TransparentIdentifier0
			from k in ((ICategoryOrCategoryRange)_003C_003Eh__TransparentIdentifier0.j).Subcategories
			select new AuthenticationListenerManager<Struct<Entity, GenericEntryDescription>, GenericEntryDescription>(_003C_003Eh__TransparentIdentifier0, k) into _003C_003Eh__TransparentIdentifier1
			from genericEntryDescription_0 in ((ISubcategoryOrSubcategoryRange)_003C_003Eh__TransparentIdentifier1.k).Specifices
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)_003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.j).Value,
				Country = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Country,
				Description = genericEntryDescription_0.Description,
				Domain = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Domain,
				Kind = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Kind,
				Specific = ((!(genericEntryDescription_0 is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)genericEntryDescription_0).Value) : ((((GenericEntryRange)genericEntryDescription_0).Min == 0) ? null : new byte?((byte)((GenericEntryRange)genericEntryDescription_0).Min))),
				Maximum = ((!(genericEntryDescription_0 is GenericEntryRange)) ? null : ((((GenericEntryRange)genericEntryDescription_0).Max == 0) ? null : new byte?((byte)((GenericEntryRange)genericEntryDescription_0).Max))),
				Subcategory = ((!(_003C_003Eh__TransparentIdentifier1.k is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)_003C_003Eh__TransparentIdentifier1.k).Value) : ((((GenericEntryRange)_003C_003Eh__TransparentIdentifier1.k).Min == 0) ? null : new byte?((byte)((GenericEntryRange)_003C_003Eh__TransparentIdentifier1.k).Min)))
			};
		IEnumerable<ICetItem> second3 = from e in cet_0.Entities
			from j in e.Categories
			select new Struct<Entity, GenericEntryDescription>(e, j) into _003C_003Eh__TransparentIdentifier0
			from k in ((ICategoryOrCategoryRange)_003C_003Eh__TransparentIdentifier0.j).Subcategories
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)_003C_003Eh__TransparentIdentifier0.j).Value,
				Country = _003C_003Eh__TransparentIdentifier0.e.Country,
				Description = k.Description,
				Domain = _003C_003Eh__TransparentIdentifier0.e.Domain,
				Kind = _003C_003Eh__TransparentIdentifier0.e.Kind,
				Subcategory = ((!(k is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)k).Value) : ((((GenericEntryRange)k).Min == 0) ? null : new byte?((byte)((GenericEntryRange)k).Min))),
				Maximum = ((!(k is GenericEntryRange)) ? null : ((((GenericEntryRange)k).Max == 0) ? null : new byte?((byte)((GenericEntryRange)k).Max)))
			};
		IEnumerable<ICetItem> second4 = from e in cet_0.Entities
			from j in e.Categories
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)j).Value,
				Country = e.Country,
				Description = j.Description,
				Domain = e.Domain,
				Kind = e.Kind
			};
		List<ICetItem> list = first.Concat(second).Concat(second2).Concat(second3)
			.Concat(second4)
			.ToList();
		list.Sort();
		return list;
	}

	public static Cet CreateEntityTypes()
	{
		return ComputeDecorator("OpenDis.Enumerations.Cet2010.EntityTypes.xml");
	}
}
