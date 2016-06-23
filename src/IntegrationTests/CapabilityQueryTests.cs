using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
	public class When_getting_a_capability_by_id : Behaves_like_Persistence_Spec
	{
		private int _id;
		private Capability _result;
		protected override void Arrange()
		{
			base.Arrange();
			_id = 170;
		}
		protected override void Act()
		{
			_result = repository.Get<Diagnostic>(x => x.Id == _id);
			var tt = repository.Get<StatusLocalization>(x => x.Code == 3);
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
		public void It_should_return_an_assortment_with_the_status()
		{
			Assert.That(_result.Status, Is.Not.Null);
			Assert.That(_result.Status.Code, Is.EqualTo(2));
			Assert.That(_result.Status.Description(), Is.EqualTo("Waiting"));
		}

	}
}
