using System.Web.Http.Dependencies;
using StructureMap;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.DependencyResolution
{
	public class StructureMapWebApiDependencyResolver : StructureMapWebApiDependencyScope, IDependencyResolver
	{
		public StructureMapWebApiDependencyResolver(IContainer container)
			: base(container)
		{
		}

		public IDependencyScope BeginScope()
		{
			var child = Container.GetNestedContainer();
			return new StructureMapWebApiDependencyResolver(child);
		}
	}
}