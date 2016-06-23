using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers
{
    public class TemplateController : ApiController
    {
        private readonly HttpContextBase _context;

        public TemplateController(HttpContextBase context)
        {
            _context = context;
        }

        public HttpResponseMessage Get(string templateName)
        {
            var templatePath = _context.Server.MapPath("~/bin/Templates") + "/" + templateName;
            var response = new HttpResponseMessage();
            try
            {
                var bytes = File.ReadAllBytes(templatePath);
                const string mimeType = "text/csv";
                response.AddFileAttachemntContent(templateName, bytes, mimeType);
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (DirectoryNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}