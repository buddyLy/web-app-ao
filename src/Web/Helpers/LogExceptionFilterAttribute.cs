using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using log4net;
using System.Web.Http;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILog _log;
        public LogExceptionFilterAttribute(ILog log) { _log = log; }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var ex = actionExecutedContext.Exception;
            if (ex.GetType() != typeof(HttpResponseException))
            {
                var incident = GenerateIncidentNumber();
                _log.Error(string.Format("Shields up, Red Alert!:{0}-{1}", incident, ex.Message), ex);
                var message = string.Format(@"An unknown has error occurred (Ref:{0})", incident);
                using (var response = new HttpResponseMessage(HttpStatusCode.InternalServerError) { ReasonPhrase = message })
                {
                    actionExecutedContext.Response = response;
                }
            }
            else {
                actionExecutedContext.Response = ((HttpResponseException)ex).Response;
            }
        }

        private static string GenerateIncidentNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
            return result;
        }
    }
}