using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web
{
    public static class WebApiConfig
    {
        private static ILog _log;

        public static void Register(HttpConfiguration config)
        {
            _log = config.DependencyResolver.GetService(typeof(ILog)) as ILog;
            
            // Web API configuration and services
            GlobalConfiguration.Configuration.Filters.Add(new LogExceptionFilterAttribute(_log));
            config.BindParameter(typeof(AssortmentAnalysis), new AssortmentAnalysisModelBinder(config.DependencyResolver));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
