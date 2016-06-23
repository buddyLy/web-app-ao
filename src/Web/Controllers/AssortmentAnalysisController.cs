using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Extensions;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Models;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers
{

    public class AssortmentAnalysisController : AOSApiController
    {
        public AssortmentAnalysisController(IRepository repository, IMessageService messageService, IUserService userService)
            : base(repository, messageService, userService)
        { }

        public HttpResponseMessage Get()
        {
            var assortments = repository.GetAllActiveAssortments();
            if (assortments == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var vm = assortments.Select(x => new AssortmentViewModel(x)).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, vm);
        }

        public HttpResponseMessage Get(int id)
        {
            var aa = repository.GetActiveAssortment(id);
            if (aa == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, new AssortmentViewModel(aa));
        }

        public HttpResponseMessage Post([FromBody]CreateAssortmentRequest req)
        {
            var assort = new AssortmentAnalysis(req, userService.UserId);
            repository.Save<AssortmentAnalysis>(assort);
            repository.SubmitChanges();
            var diag = assort.Capabilities.OfType<Diagnostic>().FirstOrDefault();
            var msg = new DiagnosticMessage(diag);
            var messageId = messageService.Send(msg);
            diag.StatusMessage = string.Format(messageId.ToString());
            repository.Save<Diagnostic>(diag);
            repository.SubmitChanges();
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}