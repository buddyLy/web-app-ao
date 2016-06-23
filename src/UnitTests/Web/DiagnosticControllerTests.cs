using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NUnit.Framework;
using Rhino.Mocks;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.StaticMocks;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Web
{
    public abstract class Behaves_like_diagnosticcontroller_spec : Specification
    {
        protected IRepository repository;

        protected DiagnosticController controller;

        protected HttpResponseMessage result;
        protected AssortmentAnalysis assortment;

        protected override void Arrange()
        {
            repository = Mock<IRepository>();
            controller = new DiagnosticController(repository)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
    }

    [Ignore]
    public class When_getting_a_diagnostic : Behaves_like_diagnosticcontroller_spec
    {
        protected override void Arrange()
        {
            base.Arrange();

            assortment = AssortmentMocker.GetAssortment();

            var capability = new Diagnostic("tester", CapabilityStatus.Waiting, new byte[33]);
            assortment.AddCapability(capability);

            repository.Stub(x => x.Find(Arg<Expression<Func<Diagnostic, bool>>>.Is.NotNull))
                .Return(Enumerable.Range(0, 1)
                    .Select(x => capability)
                    .AsQueryable());
        }

        protected override void Act()
        {
            result = controller.Get(assortment);
        }

        [Test]
        public void It_should_return_OK()
        {
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }

    public class When_no_diagnostic_exists : Behaves_like_diagnosticcontroller_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            assortment = AssortmentMocker.GetAssortment();
            repository.Stub(x => x.Find(Arg<Expression<Func<Diagnostic, bool>>>.Is.NotNull))
                .Return(Enumerable.Range(0, 0)
                    .Select(x => new Diagnostic())
                    .AsQueryable());
        }

        [Test]
        public void It_should_return_Not_Found()
        {
            Assert.Throws<HttpResponseException>(() => controller.Get(assortment));
        }
    }
}
