using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public abstract class TrackedEntityMap<T> : ClassMap<T> where T : TrackedEntity
	{
		public TrackedEntityMap()
		{
			Map(x => x.Creator, "create_userid");
			Map(x => x.Created, "create_ts");
			Map(x => x.LastChangedBy, "last_change_userid");
			Map(x => x.LastChanged, "last_change_ts");
		}
	}
}
