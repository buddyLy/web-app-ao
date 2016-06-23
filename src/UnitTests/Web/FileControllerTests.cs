using System;
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
	public abstract class Behaves_like_filecontroller_spec : Specification
	{
		protected IRepository repository;
		protected FileController controller;
		protected override void Arrange()
		{
			repository = Mock<IRepository>();
			controller = new FileController(repository);
		}
	}

	public class When_downloading_an_existing_file : Behaves_like_filecontroller_spec
	{
		private string _mime;
		private byte[] _bytes;
		private string _name;
		private HttpResponseMessage _result;
		protected override void Arrange()
		{
			base.Arrange();
			_mime = "text/csv";
			_bytes = FileMocker.GetBytes("sample.csv");
			_name = "myfile";
			var fileType = Mock<FileType>();
			fileType.Stub(x => x.Description()).Return(_name);
			fileType.Stub(x => x.MIMEType).Return(_mime);
			repository.Stub(x =>
				x.Get(Arg<Expression<Func<CapabilityFile, bool>>>.Is.NotNull))
				.Return(new DiagnosticItemListFile(_bytes, "blah") { FileType = fileType });
		}

		protected override void Act()
		{
			_result = controller.Get(1, 2);
		}

		[Test]
		public void It_should_return_an_ok_httpstatus() {
			Assert.That(_result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
		[Test]
		public void It_should_return_the_correct_file() {
			Assert.That(_result.Content.Headers.ContentType.MediaType, Is.EqualTo("text/csv"));
			Assert.That(_result.Content.Headers.ContentDisposition.DispositionType, Is.EqualTo("attachment"));
			Assert.That(_result.Content.Headers.ContentDisposition.FileName, Is.EqualTo("myfile"));
		}
	}
	public class When_downloading_an_nonexisting_file : Behaves_like_filecontroller_spec
	{
	    protected override void Arrange()
		{
			base.Arrange();
			repository.Stub(x =>
				x.Get(Arg<Expression<Func<CapabilityFile, bool>>>.Is.NotNull))
				.Return(null);
		}

		[Test]
		public void It_should_throw_an_exception()
		{
			Assert.Throws<HttpResponseException>(()=>controller.Get(1, 2));
		}
	}

}
