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
    public class LoyaltyController : AOSApiController
    {
        public LoyaltyController(IRepository repository, IMessageService messageService, IUserService userService)
            : base(repository, messageService, userService)
        { }

        public HttpResponseMessage Get(AssortmentAnalysis assortment)
        {
            var loyalty = assortment.Capabilities.OfType<LoyaltyReport>();
            var loyaltyReports = loyalty as IList<LoyaltyReport> ?? loyalty.ToList();
            if (!loyaltyReports.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var currentLoyalty = loyaltyReports.OrderByDescending(x => x.Created).FirstOrDefault();
            var loyaltyVm = new LoyaltyViewModel(currentLoyalty);
            return Request.CreateResponse(HttpStatusCode.OK, loyaltyVm);
        }

        public HttpResponseMessage Post([FromBody]CreateLoyaltyReportRequest req, AssortmentAnalysis assortment)
        {
            var loyalty = new LoyaltyReport(req, userService.UserId, CapabilityStatus.Waiting);
            assortment.AddCapability(loyalty);
            repository.Save<LoyaltyReport>(loyalty);
            var loyaltyMessage = new LoyaltyMessage(loyalty);
            var messageId = messageService.Send(loyaltyMessage);
            loyalty.StatusMessage = string.Format(messageId.ToString());
            repository.Save<LoyaltyReport>(loyalty);
            repository.SubmitChanges();
            var loyaltyVm = new LoyaltyViewModel(loyalty);
            return Request.CreateResponse(HttpStatusCode.Created, loyaltyVm);
        }
    }
}