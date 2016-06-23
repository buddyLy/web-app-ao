using System.Web.Http;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers
{
    public abstract class AOSApiController : ApiController
    {
        protected readonly IRepository repository;
        protected readonly IMessageService messageService;
        protected readonly IUserService userService;

        public AOSApiController(IRepository respository, IMessageService messageService, IUserService userService)
        {
            repository = respository;
            this.messageService = messageService;
            this.userService = userService;
        }
    }
}