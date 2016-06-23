using log4net;
using StructureMap.Configuration.DSL;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.DependencyResolution
{
	public class Log4NetRegistry : Registry
	{
		public Log4NetRegistry()
		{
			For<ILog>().Use(() => LogManager.GetLogger("Assortment Optimization Log"));
		}
	}
}