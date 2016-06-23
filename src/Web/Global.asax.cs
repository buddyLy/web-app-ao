using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web
{
	public class Global : HttpApplication
	{
		private readonly ILog _logger = LogManager.GetLogger(typeof(Global));
		
		void Application_Start(object sender, EventArgs e)
		{
			_logger.Info(string.Format(@"App started at {0}", DateTime.Now));
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			var context = HttpContext.Current;
			var ex = context.Server.GetLastError();
			if (ex != null)
			{
				_logger.Error(string.Format("Shields up, Red Alert!:{0}", ex.Message), ex);
			}
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			if (Request.Path.Equals("/AssortmentOptimization", StringComparison.CurrentCultureIgnoreCase))
			{
				var redirectUrl = VirtualPathUtility.AppendTrailingSlash(Request.Path);
				Response.RedirectPermanent(redirectUrl);
			}
		}
	}
}