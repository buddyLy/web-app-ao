//using FluentNHibernate.Mapping;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

//namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
//{
//	public class CapabilityTypeMap : ClassMap<CapabilityType>
//	{
//		public CapabilityTypeMap()
//		{
//			Table("capability");
//			Id(x => x.Code, "capability_code");
//			HasMany(x => x.Localizations)
//				.KeyColumn("capability_code")
//				.Access.ReadOnlyPropertyThroughLowerCaseField(Prefix.Underscore)
//				.Cascade.AllDeleteOrphan();
//		}
//	}
//}
