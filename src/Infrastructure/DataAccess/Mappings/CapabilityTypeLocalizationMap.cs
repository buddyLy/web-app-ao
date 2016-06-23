//using FluentNHibernate.Mapping;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

//namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
//{
//	public class CapabilityTypeLocalizationMap : ClassMap<CapabilityTypeLocalization>
//	{
//		public CapabilityTypeLocalizationMap()
//		{
//			Table("capability_txt");
//			CompositeId()
//				.KeyProperty(x => x.Id, "capability_code")
//				.KeyProperty(x => x.LanguageCode, "language_code");
//			Map(x => x.Description, "capability_desc");
//		}
//	}
//}
