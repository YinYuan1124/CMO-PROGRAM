using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Command.Filter;
using Command.Managers;
using Command.Specifications;
using OpenDis.Core;
using OpenDis.Resolver;

namespace OpenDis.Enumerations.Cet2006;

public class CetFactory
{
	public static Cet CreateAggregateTypes()
	{
		return PatchDecorator("OpenDis.Enumerations.Cet2006.AggregateTypes.xml");
	}

	public static List<ICetItem> Transform(Cet cet_0)
	{
		List<ICetItem> first = new List<ICetItem>();
		IEnumerable<ICetItem> second = from e in cet_0.Entities
			from j in e.Categories
			select new Struct<Entity, Category>(e, j) into _003C_003Eh__TransparentIdentifier0
			from k in _003C_003Eh__TransparentIdentifier0.j.Subcategories
			select new AuthenticationListenerManager<Struct<Entity, Category>, Subcategory>(_003C_003Eh__TransparentIdentifier0, k) into _003C_003Eh__TransparentIdentifier1
			from specific_0 in _003C_003Eh__TransparentIdentifier1.k.Specifices
			select new VisitorInstanceFilter<AuthenticationListenerManager<Struct<Entity, Category>, Subcategory>, Specific>(_003C_003Eh__TransparentIdentifier1, specific_0) into _003C_003Eh__TransparentIdentifier2
			select new RepositoryDefinitionSpec<VisitorInstanceFilter<AuthenticationListenerManager<Struct<Entity, Category>, Subcategory>, Specific>, Specific>(_003C_003Eh__TransparentIdentifier2, _003C_003Eh__TransparentIdentifier2.specific_0) into _003C_003Eh__TransparentIdentifier3
			from m in _003C_003Eh__TransparentIdentifier3.Prop_0.Extras
			select new CetItem
			{
				Category = _003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.j.Id,
				Country = _003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Country,
				Description = m.Description,
				Domain = _003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Domain,
				Extra = ((m.Id == 0) ? null : new byte?(m.Id)),
				Kind = _003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Kind,
				Specific = ((_003C_003Eh__TransparentIdentifier3.Prop_0.Id == 0) ? null : new byte?(_003C_003Eh__TransparentIdentifier3.Prop_0.Id)),
				Subcategory = ((_003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1.k.Id == 0) ? null : new byte?(_003C_003Eh__TransparentIdentifier3._003C_003Eh__TransparentIdentifier2._003C_003Eh__TransparentIdentifier1.k.Id))
			};
		IEnumerable<ICetItem> second2 = from e in cet_0.Entities
			from j in e.Categories
			select new Struct<Entity, Category>(e, j) into _003C_003Eh__TransparentIdentifier0
			from k in _003C_003Eh__TransparentIdentifier0.j.Subcategories
			select new AuthenticationListenerManager<Struct<Entity, Category>, Subcategory>(_003C_003Eh__TransparentIdentifier0, k) into _003C_003Eh__TransparentIdentifier1
			from specific_0 in _003C_003Eh__TransparentIdentifier1.k.Specifices
			select new CetItem
			{
				Category = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.j.Id,
				Country = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Country,
				Description = specific_0.Description,
				Domain = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Domain,
				Kind = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.e.Kind,
				Specific = ((specific_0.Id == 0) ? null : new byte?(specific_0.Id)),
				Maximum = ((specific_0.Id2 == 0) ? null : new byte?(specific_0.Id2)),
				Subcategory = ((_003C_003Eh__TransparentIdentifier1.k.Id == 0) ? null : new byte?(_003C_003Eh__TransparentIdentifier1.k.Id))
			};
		IEnumerable<ICetItem> second3 = from e in cet_0.Entities
			from j in e.Categories
			select new Struct<Entity, Category>(e, j) into _003C_003Eh__TransparentIdentifier0
			from k in _003C_003Eh__TransparentIdentifier0.j.Subcategories
			select new CetItem
			{
				Category = _003C_003Eh__TransparentIdentifier0.j.Id,
				Country = _003C_003Eh__TransparentIdentifier0.e.Country,
				Description = k.Description,
				Domain = _003C_003Eh__TransparentIdentifier0.e.Domain,
				Kind = _003C_003Eh__TransparentIdentifier0.e.Kind,
				Subcategory = ((k.Id == 0) ? null : new byte?(k.Id)),
				Maximum = ((k.Id2 == 0) ? null : new byte?(k.Id2))
			};
		IEnumerable<ICetItem> second4 = from e in cet_0.Entities
			from j in e.Categories
			select new CetItem
			{
				Category = j.Id,
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

	private static Cet PatchDecorator(string string_0)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cet));
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string_0);
		return (Cet)xmlSerializer.Deserialize(manifestResourceStream);
	}

	public static Cet CreateEntityTypes()
	{
		return PatchDecorator("OpenDis.Enumerations.Cet2006.EntityTypes.xml");
	}
}
