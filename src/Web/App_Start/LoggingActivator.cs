using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Walmart.Assortment.AssortmentOptimizationSystem.Web.LoggingActivator), "Start", Order = 1)]

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web
{
	public class LoggingActivator
	{
		public static void Start()
		{
			XmlConfigurator.Configure();
		}
	}
}