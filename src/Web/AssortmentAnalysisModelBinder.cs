using StructureMap;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.ModelBinding;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web
{
    public class AssortmentAnalysisModelBinder : IModelBinder
    {
        private IDependencyResolver _resolver;

        public AssortmentAnalysisModelBinder(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var repository = _resolver.GetService(typeof(IRepository)) as IRepository;
            var assortmentId = 0;
            int.TryParse(actionContext.ControllerContext.RouteData.Values["id"].ToString(), out assortmentId);
            var assortment = repository.Get<AssortmentAnalysis>(x => x.Id == assortmentId);
            if (assortment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            bindingContext.Model = assortment;
            return true;
        }
    }
}