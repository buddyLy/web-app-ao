using System.Net;
using System.Net.Http;
using System.Web.Http;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers
{
    public class FileController : ApiController
    {
        private readonly IRepository _repository;

        public FileController(IRepository repository)
        {
            _repository = repository;
        }

        public HttpResponseMessage Get([FromUri] int capabilityId, [FromUri] int fileType)
        {
            var response = new HttpResponseMessage();
            var file = _repository.Get<CapabilityFile>(
                x => x.Capability.Id == capabilityId && x.FileType.Code == fileType);
            if (file == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            response.AddFileAttachemntContent(file.FileType.Description(), file.Content, file.FileType.MIMEType);
            return response;
        }
    }
}