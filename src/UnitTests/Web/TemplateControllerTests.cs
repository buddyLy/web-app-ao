using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NUnit.Framework;
using Rhino.Mocks;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Web
{
	public abstract class Behaves_like_templatecontroller_spec : Specification
	{
        protected TemplateController controller;
        protected HttpContextBase context;

	    protected override void Arrange()
		{
            context = Mock<HttpContextBase>();
            controller = new TemplateController(context);
		}
	}

	public class When_requesting_a_valid_template : Behaves_like_templatecontroller_spec
	{
		private string _templateName;
		private HttpResponseMessage _result;
		protected override void Arrange()
		{
            base.Arrange();
            context.Stub(x => x.Server.MapPath(Arg<string>.Is.NotNull)).Return(@"Templates");
            _templateName = "ItemListTemplate.csv";
		}

		protected override void Act()
		{
			_result = controller.Get(_templateName);
		}

		[Test]
		public void It_should_return_an_ok_status()
		{
			Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}

		[Test]
		public void It_should_return_the_correct_file()
		{
			Assert.That(_result.Content.Headers.ContentType.MediaType, Is.EqualTo("text/csv"));
			Assert.That(_result.Content.Headers.ContentDisposition.DispositionType, Is.EqualTo("attachment"));
			Assert.That(_result.Content.Headers.ContentDisposition.FileName, Is.EqualTo(_templateName));

		}
	}

	public class When_requesting_an_invalid_template : Behaves_like_templatecontroller_spec
	{
		private string _templateName;

	    protected override void Arrange()
		{
			base.Arrange();
            context.Stub(x => x.Server.MapPath(Arg<string>.Is.NotNull)).Return("foo");
            _templateName = "blah";
		}

		[Test]
        public void It_should_throw_an_exception()
		{
			Assert.Throws<HttpResponseException>(() => controller.Get(_templateName));
		}
	}
}
