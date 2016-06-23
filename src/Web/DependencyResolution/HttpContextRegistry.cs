using System.Web;
using StructureMap.Configuration.DSL;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.DependencyResolution
{
    public class HttpContextRegistry : Registry
    {
        public HttpContextRegistry()
        {
            For<HttpContextBase>().Transient().Use(() => new HttpContextWrapper(HttpContext.Current));
        }
    }
}