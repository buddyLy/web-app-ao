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
    public abstract class Behaves_like_StoreClusteringController_spec : Specification
    {
        private IRepository _repository;
        private IMessageService _messageService;
        protected StoreClusteringController controller;

        protected HttpResponseMessage _result;

        protected StoreClustering storeCluster;
        protected AssortmentAnalysis assortment;
        private IUserService _userService;

        protected override void Arrange()
        {
            _repository = Mock<IRepository>();
            _messageService = Mock<IMessageService>();
            _userService = Mock<IUserService>();
            controller = new StoreClusteringController(_repository, _messageService, _userService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
    }

    public class When_creating_a_new_StoreClustering : Behaves_like_StoreClusteringController_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            //storeCluster = StaticMocks.CapabilityMocker.GetStoreClustering();
            //assortment = StaticMocks.AssortmentMocker.GetAssortment();

            //repository.Stub(x =>
            //    x.Save<StoreClustering>(Arg<StoreClustering>.Is.NotNull))
            //    .Return(null)
            //    .WhenCalled(_ =>
            //        {
            //            var sc = (StoreClustering) _.Arguments[0];
            //            sc.Id = 2501;
            //            assortment.AddCapability(sc);
            //            _.ReturnValue = sc;
            //        }
            //    );


            //messageService.Stub(x => x.Send(Arg<StoreClusteringMessage>.Is.NotNull))
            //    .Return(new Guid());

        }

        protected override void Act()
        {
            //_result = controller.Post(new CreateStoreClusteringRequest()
            //{
            //    AssortmentID = 1234,
            //    StoreList = StaticMocks.FileMocker.GetFileString("sample.csv")
            //});
        }

        public void It_should_create_a_new_StoreClustering()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }

    public class When_getting_an_existing_StoreClustering : Behaves_like_StoreClusteringController_spec
    {
        protected override void Arrange()
        {
            base.Arrange();
            storeCluster = CapabilityMocker.GetStoreClustering();
            storeCluster.Id = 2501;
            assortment = AssortmentMocker.GetAssortment();
            assortment.AddCapability(storeCluster);
        }

        protected override void Act()
        {
            _result = controller.Get(assortment);
        }

        public void It_should_retrieve_the_loyalty()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }

    public class When_getting_an_the_latest_StoreClustering : Behaves_like_StoreClusteringController_spec
    {
        private StoreClustering _otherCluster;
        private StoreClustering _anotherCluster;
        protected override void Arrange()
        {
            base.Arrange();
            storeCluster = CapabilityMocker.GetStoreClustering();
            storeCluster.Id = 2501;

            _otherCluster = CapabilityMocker.GetStoreClustering();
            _otherCluster.Id = 1212;
            _otherCluster.Created = storeCluster.Created.AddDays(-3);
            _otherCluster.Created = storeCluster.Created.AddDays(-3);
            _otherCluster.Status = CapabilityStatus.Done;

            _anotherCluster = CapabilityMocker.GetStoreClustering();
            _anotherCluster.Id = 678;
            _anotherCluster.Created = storeCluster.Created.AddDays(-6);
            _anotherCluster.Created = storeCluster.Created.AddDays(-6);
            _anotherCluster.Status = CapabilityStatus.Done;

            assortment = AssortmentMocker.GetAssortment();
            assortment.AddCapability(_anotherCluster);
            assortment.AddCapability(storeCluster);
            assortment.AddCapability(_otherCluster);
        }

        protected override void Act()
        {
            _result = controller.Get(assortment);
        }

        [Test]
        public void It_should_retrieve_the_current_StoreClustering()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
