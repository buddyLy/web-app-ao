using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Models;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers
{
    public class DecisionTreeController : AOSApiController
    {
        public DecisionTreeController(IRepository repository, IMessageService messageService, IUserService userService)
            : base(repository, messageService, userService)
        { }

        public HttpResponseMessage Get(AssortmentAnalysis assortment)
        {
            var cdt = assortment.Capabilities.OfType<DecisionTree>().OrderByDescending(x => x.Created).FirstOrDefault();
            if (cdt == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var cdtVm = new DecisionTreeViewModel(cdt);
            return Request.CreateResponse(HttpStatusCode.OK, cdtVm);
        }

        public HttpResponseMessage Post([FromBody]CreateDecisionTreeRequest req, AssortmentAnalysis assortment)
        {
            var cdt = new DecisionTree(req, userService.UserId, CapabilityStatus.Waiting);
            assortment.AddCapability(cdt);
            repository.Save<DecisionTree>(cdt);
            var decisionMessage = new DecisionTreeMessage(cdt);
            var messageId = messageService.Send(decisionMessage);
            cdt.StatusMessage = string.Format(messageId.ToString());
            repository.Save<DecisionTree>(cdt);
            repository.SubmitChanges();
            var cdtVm = new DecisionTreeViewModel(cdt);
            return Request.CreateResponse(HttpStatusCode.Created, cdtVm);
        }
    }
}