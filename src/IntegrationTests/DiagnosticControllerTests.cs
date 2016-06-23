using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
    public class DiagnosticControllerTest : Behaves_like_Persistence_Spec
    {
        private DiagnosticController _controller;
        private HttpRequestMessage _request;
        private HttpResponseMessage _result;
        private AssortmentAnalysis _assortment;
        private int _assortId;

        protected override void Arrange()
        {
            base.Arrange();
            _assortId = 170;
            _request = new HttpRequestMessage();
            _request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }
        protected override void Act()
        {
            _assortment = repository.Get<AssortmentAnalysis>(x => x.Id == _assortId);
            _controller = new DiagnosticController(repository) {Request = _request};
            _result = _controller.Get(_assortment);
        }

        [Test]
        public void It_should_select_a_diagnostic()
        {
            Assert.That(_result, Is.Not.Null);
        }

        [Test]
        public void It_should_be_for_the_correct_assortment()
        {
        }
    }
}
