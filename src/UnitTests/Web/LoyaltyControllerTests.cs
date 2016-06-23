using System.Net;
using System.Net.Http;
using System.Web.Http;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.StaticMocks;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests
{
    public abstract class Behaves_like_LoyaltyController_spec : Specification
    {
        private IRepository _repository;
        private IMessageService _messageService;
        protected LoyaltyController controller;
        protected HttpResponseMessage _result;

        protected LoyaltyReport loyalty;
        protected AssortmentAnalysis assortment;
        private IUserService _userService;

        protected override void Arrange()
        {
            _repository = Mock<IRepository>();
            _messageService = Mock<IMessageService>();
            _userService = Mock<IUserService>();
            controller = new LoyaltyController(_repository, _messageService, _userService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
    }

    //public class When_creating_a_new_Loyalty : Behaves_like_LoyaltyController_spec
    //{
    //    protected override void Arrange()
    //    {
    //        base.Arrange();
    //        //loyalty = StaticMocks.CapabilityMocker.GetLoyalty();
    //        //assortment = StaticMocks.AssortmentMocker.GetAssortment();

    //        //repository.Stub(x =>
    //        //    x.Save<LoyaltyReport>(Arg<LoyaltyReport>.Is.NotNull))
    //        //    .Return(null)
    //        //    .WhenCalled(_ =>
    //        //        {
    //        //            var x = (LoyaltyReport) _.Arguments[0];
    //        //            x.Id = 2501;
    //        //            assortment.AddCapability(x);
    //        //            _.ReturnValue = x;
    //        //        }
    //        //    );

    //        //messageService.Stub(x => x.Send(Arg<LoyaltyMessage>.Is.NotNull))
    //        //    .Return(new Guid());

    //    }

    //    protected override void Act()
    //    {
    //        //_result = controller.Post(new CreateLoyaltyReportRequest()
    //        //    {
    //        //        AssortmentID = 1234,
    //        //        ItemList = StaticMocks.FileMocker.GetFileString("sample.csv"),
    //        //        LoyaltyLevel = "Item",
    //        //        StoreClustering = StaticMocks.FileMocker.GetFileString("sample.csv"),
    //        //        UseClustering = true
    //        //    });
    //    }

    //    public void It_should_create_a_new_loyalty()
    //    {
    //        Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    //    }
    //}

    public class When_getting_an_existing_Loyalty : Behaves_like_LoyaltyController_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            loyalty = CapabilityMocker.GetLoyalty();
            loyalty.Id = 2501;
            assortment = AssortmentMocker.GetAssortment();
            assortment.AddCapability(loyalty);
        }

        protected override void Act()
        {
            _result = controller.Get(assortment);
        }

        [Test]
        public void It_should_retrieve_the_loyalty()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }


    public class When_getting_the_latest_Loyalty : Behaves_like_LoyaltyController_spec
    {
        private LoyaltyReport _otherLoyalty;
        private LoyaltyReport _anotherLoyalty;

        protected override void Arrange()
        {
            base.Arrange();
            loyalty = CapabilityMocker.GetLoyalty();
            loyalty.Id = 2501;

            _otherLoyalty = CapabilityMocker.GetLoyalty();
            _otherLoyalty.Id = 1100;
            _otherLoyalty.Created = loyalty.Created.AddDays(-3);
            _otherLoyalty.Created = loyalty.Created.AddDays(-3);
            _otherLoyalty.Status = CapabilityStatus.Done;

            _anotherLoyalty = CapabilityMocker.GetLoyalty();
            _anotherLoyalty.Id = 800;
            _anotherLoyalty.Created = loyalty.Created.AddDays(-4);
            _anotherLoyalty.Created = loyalty.Created.AddDays(-4);
            _anotherLoyalty.Status = CapabilityStatus.Done;

            assortment = AssortmentMocker.GetAssortment();
            assortment.AddCapability(_anotherLoyalty);
            assortment.AddCapability(loyalty);
            assortment.AddCapability(_otherLoyalty);
        }

        protected override void Act()
        {
            _result = controller.Get(assortment);
        }

        [Test]
        public void It_should_retrieve_the_latest_loyalty()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
