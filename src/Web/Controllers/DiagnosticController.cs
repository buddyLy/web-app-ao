using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Models;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers
{
    public class DiagnosticController : ApiController
    {
        private IRepository _repository;

        public DiagnosticController(IRepository respository)
        {
            _repository = respository;
        }

        public HttpResponseMessage Get(AssortmentAnalysis assortment)
        {
            var diagnostic = assortment.Capabilities.OfType<Diagnostic>().FirstOrDefault();
            if (diagnostic == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var diagVm = new DiagnosticViewModel(diagnostic);
            return Request.CreateResponse(HttpStatusCode.OK, diagVm);
        }
    }
}