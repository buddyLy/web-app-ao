using System.Web.Http.Dependencies;
using StructureMap;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.DependencyResolution
{
	public class StructureMapWebApiDependencyScope : StructureMapDependencyScope, IDependencyScope
	{
		public StructureMapWebApiDependencyScope(IContainer container)
			: base(container)
		{
		}
	}
}
