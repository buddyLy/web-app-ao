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
    public class StoreClusteringController : AOSApiController
    {
        public StoreClusteringController(IRepository repository, IMessageService messageService, IUserService userService)
            : base(repository, messageService, userService)
        { }

        public HttpResponseMessage Get(AssortmentAnalysis assortment)
        {
            var storeClustering = assortment.Capabilities.OfType<StoreClustering>();
            var storeClusterings = storeClustering as IList<StoreClustering> ?? storeClustering.ToList();
            if (!storeClusterings.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var currentCluster = storeClusterings.OrderByDescending(x => x.Created).FirstOrDefault();
            var storeClusterVm = new ClusteringViewModel(currentCluster);
            return Request.CreateResponse(HttpStatusCode.OK, storeClusterVm);
        }

        public HttpResponseMessage Post([FromBody]CreateStoreClusteringRequest req, AssortmentAnalysis assortment)
        {
            var cluster = new StoreClustering(req, userService.UserId, CapabilityStatus.Waiting);
            assortment.AddCapability(cluster);
            repository.Save<StoreClustering>(cluster);

            var storeMessage = new StoreClusteringMessage(cluster);
            var messageId = messageService.Send(storeMessage);
            cluster.StatusMessage = string.Format(messageId.ToString());
            repository.Save<StoreClustering>(cluster);
            repository.SubmitChanges();

            var clusterVm = new ClusteringViewModel(cluster);
            return Request.CreateResponse(HttpStatusCode.Created, clusterVm);
        }
    }
}