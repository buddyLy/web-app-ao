using System.Web;
using StructureMap.Web.Pipeline;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.DependencyResolution
{
	public class StructureMapScopeModule : IHttpModule
	{
		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += (sender, e) => IocActivator.StructureMapDependencyScope.CreateNestedContainer();
			context.EndRequest += (sender, e) =>
			{
				HttpContextLifecycle.DisposeAndClearAll();
				IocActivator.StructureMapDependencyScope.DisposeNestedContainer();
			};
		}
	}
}