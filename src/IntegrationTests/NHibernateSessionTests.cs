using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
	public class When_creating_a_Repository : Specification
	{
		private IRepository _result;
		protected override void Act()
		{
			_result = container.GetInstance<IRepository>();
		}

		[Test]
		public void It_should_not_be_null() {
			Assert.That(_result, Is.Not.Null);
		}
	}
}
