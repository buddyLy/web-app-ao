using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.StaticMocks;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Core
{
	public class When_creating_an_assortmentanalysis_from_a_request : Specification
	{
		private CreateAssortmentRequest _request;
		private string _user;
		private AssortmentAnalysis _result;
		protected override void Arrange()
		{
			_user = "testing123";
			_request = new CreateAssortmentRequest
			{
				Department = 7,
				Name = "Toys",
				RollUpTypeCode = 1,
                ItemList = FileMocker.GetFileString("sample.csv")
			};
		}
		protected override void Act()
		{
			_result = new AssortmentAnalysis(_request, _user);
		}

		[Test]
		public void It_should_have_the_correct_values()
		{
			Assert.That(_result.Department, Is.EqualTo(_request.Department));
			Assert.That(_result.Name, Is.EqualTo(_request.Name.ToUpper()));
			Assert.That(_result.Rollup.Code, Is.EqualTo(_request.RollUpTypeCode));
		}
		[Test]
		public void It_should_have_null_dates()
		{
			Assert.That(_result.StartDate, Is.EqualTo(null));
			Assert.That(_result.EndDate, Is.EqualTo(null));
		}
		[Test]
		public void It_should_have_the_correct_auditing_values()
		{
			Assert.That(_result.Creator, Is.EqualTo(_user));
			Assert.That(_result.Creator, Is.EqualTo(_result.LastChangedBy));
            Assert.That(_result.Created, Is.LessThanOrEqualTo(_result.LastChanged));
		}
	}

	public class When_creating_an_assortmentanalysis_from_a_request_with_invalid_characters_in_the_name : Specification
	{
		private CreateAssortmentRequest _request;
		private string _user;
		private AssortmentAnalysis _result;
		protected override void Arrange()
		{
			_user = "testing123";
			_request = new CreateAssortmentRequest
			{
				Department = 7,
				Name = @"	T
				oys",
				RollUpTypeCode = 1,
                ItemList = FileMocker.GetFileString("sample.csv")
			};
		}
		protected override void Act()
		{
			_result = new AssortmentAnalysis(_request, _user);
		}

		[Test]
		public void It_should_remove_the_special_characters()
		{
			Assert.That(_result.Name.Contains(@"	"), Is.False);
			Assert.That(_result.Name.Contains(@"
"), Is.False);
		}
	}
}
