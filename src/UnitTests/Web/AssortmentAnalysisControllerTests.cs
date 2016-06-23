using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NUnit.Framework;
using Rhino.Mocks;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Models;
using System.Web;
using System.IO;
using System.Collections.Specialized;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Web
{
    public abstract class Behaves_like_assortmentanalysiscontroller_spec : Specification
    {
        protected IRepository repository;
        protected AssortmentAnalysisController controller;
        protected IMessageService messageService;
        protected IUserService userService;

        protected override void Arrange()
        {
            repository = Mock<IRepository>();
            messageService = Mock<IMessageService>();
            userService = Mock<IUserService>();
            controller = new AssortmentAnalysisController(repository, messageService, userService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
    }

    public class When_getting_all_assortments : Behaves_like_assortmentanalysiscontroller_spec
    {
        private HttpResponseMessage _result;
        private int _count;

        protected override void Arrange()
        {
            base.Arrange();
            _count = 17;
            repository.Stub(x => x.Find<AssortmentAnalysis>())
                .Return(Enumerable.Range(0, _count)
                    .Select(x => new AssortmentAnalysis { Id = x, LastChanged = DateTime.Now.AddDays(x) })
                    .AsQueryable());
        }
        protected override void Act()
        {
            _result = controller.Get();
        }

        [Test]
        public void It_should_return_an_ok_status()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void It_should_return_the_correct_count()
        {
            Assert.That(_result, Is.Not.Null);
            var list = new List<AssortmentViewModel>();
            _result.TryGetContentValue(out list);
            Assert.That(list.Count, Is.EqualTo(_count));
        }

        [Test]
        public void It_should_be_ordered_by_descending_last_updated_time()
        {
            Assert.That(_result, Is.Not.Null);
            var list = new List<AssortmentViewModel>();
            _result.TryGetContentValue(out list);
            for (var i = 1; i < _count; i++)
            {
                Assert.That(list[i].LastChangedTime, Is.LessThan(list[i - 1].LastChangedTime));
            }
        }
    }

    public class When_getting_a_specific_valid_assortemnt : Behaves_like_assortmentanalysiscontroller_spec
    {
        private int _id;
        private int _count;
        private HttpResponseMessage _result;
        private HttpFileCollectionBase filesMock;
        private HttpPostedFileBase fileMock;
        private HttpRequestBase mockRequest;
        private HttpContextBase mockContext;
        //private CreateAssortmentRequest req;
        protected override void Arrange()
        {
            base.Arrange();
            _id = 3;
            _count = 4;

            repository.Stub(x => x.Find<AssortmentAnalysis>())
                .Return(Enumerable.Range(0, _count)
                    .Select(x => new AssortmentAnalysis { Id = x, LastChanged = DateTime.Now.AddDays(x) })
                    .AsQueryable());

            var @params = new NameValueCollection();
            var responseHeaders = new NameValueCollection();

            fileMock = Mock<HttpPostedFileBase>();
            filesMock = Mock <HttpFileCollectionBase>();
            filesMock.Stub(x => x.Count).Return(1);

            var request = Mock<HttpRequestBase>();
            request.Stub(r => r.Params).Return(@params);
            request.Stub(r => r.Files).Return(filesMock);

            var response = Mock<HttpResponseBase>();
            response.Stub(r => r.Headers).Return(responseHeaders);

            var session = Mock<HttpSessionStateBase>();

            mockContext = Mock<HttpContextBase>();
            mockContext.Stub(x => x.Request).Return(request);
            mockContext.Stub(x => x.Session).Return(session);
            mockContext.Stub(x => x.Response).Return(response);
        }
        protected override void Act()
        {
            _result = controller.Get(_id);
        }

        [Test]
        public void It_should_return_an_ok_status()
        {
            Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void It_should_Contain_A_Valid_File_Collection()
        {
            Assert.That(mockContext, Is.Not.Null);
            Assert.That(mockContext.Request.Files, Is.Not.Null);
            Assert.That(mockContext.Request.Files.Count, Is.GreaterThan(0));
        }

        [Test]
        public void It_should_return_the_correct_one()
        {
            Assert.That(_result, Is.Not.Null);
            AssortmentViewModel content; ;
            _result.TryGetContentValue(out content);
            Assert.That(content.Id, Is.EqualTo(_id));
        }
    }
}