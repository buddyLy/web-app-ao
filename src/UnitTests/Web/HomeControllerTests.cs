using System.Web.Mvc;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Controllers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Web
{
	public class When_calling_HomeController_Index : Specification
	{
		private HomeController _controller;
		private ViewResult _result;
		protected override void Arrange()
		{
			_controller = new HomeController();
		}

		protected override void Act()
		{
			_result = _controller.Index() as ViewResult;
		}

		[Test]
		public void It_should_return_the_correct_model() {
			Assert.That(_result.Model, Is.Null);
		}
	}
}
