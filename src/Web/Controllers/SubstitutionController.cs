using System.Collections.Generic;
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
    public class SubstitutionController : AOSApiController
    {
        public SubstitutionController(IRepository repository, IMessageService messageService, IUserService userService)
            : base(repository, messageService, userService)
        { }

        public HttpResponseMessage Get(AssortmentAnalysis assortment)
        {
            var sub = assortment.Capabilities.OfType<Substitution>();
            var substitutions = sub as IList<Substitution> ?? sub.ToList();
            if (!substitutions.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var currentSub = substitutions.OrderByDescending(x => x.Created).FirstOrDefault();
            var currentSubVm = new SubstitutionViewModel(currentSub);
            return Request.CreateResponse(HttpStatusCode.OK, currentSubVm);
        }

        public HttpResponseMessage Post([FromBody]CreateSubstitutionRequest req, AssortmentAnalysis assortment)
        {
            var sub = new Substitution(req, userService.UserId, CapabilityStatus.Waiting);
            assortment.AddCapability(sub);
            repository.Save<Substitution>(sub);
            var substitutionMessage = new SubstitutionMessage(sub);
            var messageId = messageService.Send(substitutionMessage);
            sub.StatusMessage = string.Format(messageId.ToString());
            repository.Save<Substitution>(sub);
            repository.SubmitChanges();
            var subVm = new SubstitutionViewModel(sub);
            return Request.CreateResponse(HttpStatusCode.Created, subVm);
        }
    }
}