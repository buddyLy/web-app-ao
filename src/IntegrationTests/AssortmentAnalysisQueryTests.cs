using System.Linq;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Extensions;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
    public class When_getting_an_assortment_by_id : Behaves_like_Persistence_Spec
	{
		private AssortmentAnalysis _result;
		private int _id;
		protected override void Arrange()
		{
			base.Arrange();
			_id = 170;
		}

		protected override void Act()
		{
			_result = repository.GetActiveAssortment(_id);
		}

		[Test]
		public void It_should_not_return_null()
		{
			Assert.That(_result, Is.Not.Null);
		}
		[Test]
		public void It_should_return_an_assortment_with_the_correct_id()
		{
			Assert.That(_result.Id, Is.EqualTo(_id));
		}
		[Test]
		public void It_should_return_an_assortment_with_the_correct_rollup()
		{
			Assert.That(_result.Rollup, Is.Not.Null);
			Assert.That(_result.Rollup.Code, Is.EqualTo(1));
			Assert.That(_result.Rollup.Description(), Is.EqualTo("UPC"));
		}
		[Test]
		public void It_should_return_an_assortment_with_the_correct_capabilities()
		{
			Assert.That(_result.Capabilities.Count(), Is.EqualTo(1));
		}
		[Test]
		public void It_should_return_an_assortment_with_the_correct_status()
		{
			Assert.That(_result.Status, Is.EqualTo("Diag-Waiting"));
		}
	}
}
