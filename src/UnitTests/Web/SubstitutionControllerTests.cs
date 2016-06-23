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
    public abstract class Behaves_like_SubstitutionController_spec : Specification
    {
        protected IRepository repository;
        protected IMessageService messageService;
        protected SubstitutionController controller;
        protected HttpResponseMessage _result;
        protected Substitution sub;
        protected AssortmentAnalysis assortment;
        private IUserService _userService;

        protected override void Arrange()
        {
            repository = Mock<IRepository>();
            messageService = Mock<IMessageService>();
            _userService = Mock<IUserService>();
            controller = new SubstitutionController(repository, messageService, _userService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
    }

    public class When_creating_a_new_Substitution : Behaves_like_SubstitutionController_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            sub = CapabilityMocker.GetSubstitution();
            assortment = AssortmentMocker.GetAssortment();

            repository.Stub(x =>
                x.Save<Substitution>(Arg<Substitution>.Is.NotNull))
                .Return(null)
                .WhenCalled(_ =>
                    {
                        var sc = (Substitution)_.Arguments[0];
                        sc.Id = 2501;
                        _.ReturnValue = sc;
                    }
                );


            messageService.Stub(x => x.Send(Arg<SubstitutionMessage>.Is.NotNull))
                .Return(new Guid());

        }

        protected override void Act()
        {
            _result = controller.Post(new CreateSubstitutionRequest()
            {
                AssortmentID = 1234,
                ItemList = FileMocker.GetFileString("sample.csv")
            },
            assortment
            );
        }

        [Test]
        public void It_should_create_a_new_Substitution()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }

    public class When_getting_an_existing_Substiution : Behaves_like_SubstitutionController_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            sub = CapabilityMocker.GetSubstitution();
            sub.Id = 2501;
            assortment = AssortmentMocker.GetAssortment();
            assortment.AddCapability(sub);
        }

        protected override void Act()
        {
            _result = controller.Get(assortment);
        }

        [Test]
        public void It_should_retrieve_the_Substitution()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }

    public class When_getting_an_the_latest_Substiution : Behaves_like_SubstitutionController_spec
    {
        private Substitution _otherSub;
        private Substitution _anotherSub;
        protected override void Arrange()
        {
            base.Arrange();
            sub = CapabilityMocker.GetSubstitution();
            sub.Id = 2501;

            _otherSub = CapabilityMocker.GetSubstitution();
            _otherSub.Id = 1324;
            _otherSub.Created = sub.Created.AddDays(-4);
            _otherSub.Created = sub.Created.AddDays(-4);
            _otherSub.Status = CapabilityStatus.Done;

            _anotherSub = CapabilityMocker.GetSubstitution();
            _anotherSub.Id = 222;
            _anotherSub.Created = sub.Created.AddDays(-9);
            _anotherSub.Created = sub.Created.AddDays(-9);
            _anotherSub.Status = CapabilityStatus.Done;

            assortment = AssortmentMocker.GetAssortment();
            assortment.AddCapability(_otherSub);
            assortment.AddCapability(sub);
            assortment.AddCapability(_anotherSub);
        }

        protected override void Act()
        {
            _result = controller.Get(assortment);
        }

        [Test]
        public void It_should_retrieve_the_latest_Substitution()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
