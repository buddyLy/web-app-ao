using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class CapabilityFileMap : TrackedEntityMap<CapabilityFile>
	{
		public CapabilityFileMap()
		{
			Table("assort_capability_file");
			DiscriminateSubClassesOnColumn("file_type_code").Default(0);
			CompositeId()
				.KeyReference(x => x.Capability, "assort_capability_id")
				.KeyReference(x => x.FileType, "file_type_code");
			Map(x => x.Content, "file_img");//.LazyLoad().;
		}
	}
}
