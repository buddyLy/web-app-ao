using System.Web.Http;
using System.Web.Mvc;
using log4net;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using StructureMap.Graph;
using Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DependencyResolution;
using Walmart.Assortment.AssortmentOptimizationSystem.Web;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.DependencyResolution;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(IocActivator), "PreStart", Order=2)]
[assembly: PostApplicationStartMethod(typeof(IocActivator), "PostStart")]
[assembly: ApplicationShutdownMethod(typeof(IocActivator), "End")]

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web
{
	public class IocActivator
	{
		public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

		public static void PreStart()
		{
			var conventions = new IRegistrationConvention[] { new ControllerConvention() };
			var container = IoC.Initialize(conventions);
			var _logger = container.GetInstance<ILog>();
			_logger.Info(container.WhatDoIHave());
			StructureMapDependencyScope = new StructureMapDependencyScope(container);
			DependencyResolver.SetResolver(StructureMapDependencyScope);
			GlobalConfiguration.Configuration.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
			DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
		}

		public static void PostStart()
		{
		}


		public static void End()
		{
			StructureMapDependencyScope.Dispose();
		}

	}
}