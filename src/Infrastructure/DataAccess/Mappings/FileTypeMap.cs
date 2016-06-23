using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class FileTypeMap : ClassMap<FileType>
	{
		public FileTypeMap()
		{
			Table("file_type");
			Id(x => x.Code, "file_type_code");
			HasMany(x => x.Localizations)
				.KeyColumn("file_type_code")
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Cascade.AllDeleteOrphan();
			Map(x => x.MIMEType, "file_mime_type_name");
		}
	}
}
