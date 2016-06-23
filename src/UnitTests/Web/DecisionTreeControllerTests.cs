using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NUnit.Framework;
using Rhino.Mocks;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages;
using Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.StaticMocks;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests
{
    public abstract class Behaves_like_DecisionTreeController_spec : Specification
    {
        protected IRepository repository;
        protected IMessageService messageService;
        protected DecisionTreeController controller;
        protected HttpResponseMessage _result;
        protected DecisionTree cdt;
        protected AssortmentAnalysis assortment;
        private IUserService _userService;


        protected override void Arrange()
        {
            repository = Mock<IRepository>();
            messageService = Mock<IMessageService>();
            _userService = Mock<IUserService>();
            controller = new DecisionTreeController(repository, messageService, _userService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
    }

    public class When_creating_a_new_CDT : Behaves_like_DecisionTreeController_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            cdt = CapabilityMocker.GetDecisionTree();
            assortment = AssortmentMocker.GetAssortment();
            repository.Stub(x =>
                x.Save<DecisionTree>(Arg<DecisionTree>.Is.NotNull))
                .Return(null)
                .WhenCalled(_ =>
                    {
                        var x = (DecisionTree)_.Arguments[0];
                        x.Id = 2501;
                        _.ReturnValue = x;
                    }
                );
            messageService.Stub(x => x.Send(Arg<DecisionTreeMessage>.Is.NotNull))
                .Return(new Guid());
        }

        protected override void Act()
        {
            _result = controller.Post(new CreateDecisionTreeRequest() { AssortmentID = 1234 }, assortment);
        }

        [Test]
        public void It_should_create_a_new_cdt()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }

    public class When_getting_an_existing_CDT : Behaves_like_DecisionTreeController_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            cdt = CapabilityMocker.GetDecisionTree();
            cdt.Id = 2501;
            assortment = AssortmentMocker.GetAssortment();
            assortment.AddCapability(cdt);
        }

        protected override void Act()
        {
            _result = controller.Get(assortment);
        }

        [Test]
        public void It_should_retrieve_the_cdt()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
