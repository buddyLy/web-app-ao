using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class FileTypeLocalizationMap : ClassMap<FileTypeLocalization>
	{
		public FileTypeLocalizationMap()
		{
			Table("file_type_txt");
			CompositeId()
				.KeyProperty(x => x.Code, "file_type_code")
				.KeyProperty(x => x.LanguageCode, "language_code");
			Map(x => x.Description, "file_type_desc");

		}
	}
}
