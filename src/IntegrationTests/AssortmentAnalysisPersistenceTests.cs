using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Extensions;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
	public abstract class Behaves_like_Persistence_Spec : Specification
	{
		protected IRepository repository;
		protected override void Arrange()
		{
			repository = container.GetInstance<IRepository>();
		}
	}

	public class When_saving_an_assortment : Behaves_like_Persistence_Spec
	{
		private AssortmentAnalysis _result;
		private AssortmentAnalysis _analysis;
		private CreateAssortmentRequest _request;
		private AssortmentAnalysis _saved;

		protected override void Arrange()
		{
			base.Arrange();
			_request = new CreateAssortmentRequest
			{
				Department = 5,
				Name = "Awesome Assortment",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddYears(1),
				RollUpTypeCode = 1,
                ItemList = Convert.ToBase64String(File.ReadAllBytes(@"Files\sample.csv"))
			};
			_analysis = new AssortmentAnalysis(_request, "tester");
		}
		protected override void Act()
		{
			_saved = repository.Save<AssortmentAnalysis>(_analysis);
			repository.SubmitChanges();
			_result = repository.Get<AssortmentAnalysis>(x => x.Id == _saved.Id);
		}

		[Test]
		public void It_should_populate_the_id_property()
		{
			Assert.That(_result.Id, Is.GreaterThan(0));
			Assert.That(_result.Id, Is.EqualTo(_saved.Id));
		}
		[Test]
		public void It_should_match_the_request() { 
			Assert.That(_result.Name, Is.EqualTo(_request.Name.RemoveSpecialCharacters().ToUpper()));
			Assert.That(_result.Department, Is.EqualTo(_request.Department));
			Assert.That(_result.Rollup.Code, Is.EqualTo(_request.RollUpTypeCode));
		}
		[Test]
		public void It_should_have_correct_capability_information() {
			Assert.That(_result.Capabilities.Count(), Is.EqualTo(1));
			Assert.That(_result.Capabilities.First(), Is.TypeOf<Diagnostic>());
		}

		[Test]
		public void It_should_have_the_correct_diagnostic_input_file()
		{
			var diag = _result.Capabilities.First() as Diagnostic;
			Assert.That(diag.DiagnosticItemList, Is.Not.Null);
		}

		public override void TearDown()
		{
			repository.Delete<AssortmentAnalysis>(_result);
			repository.SubmitChanges();
			base.TearDown();
		}
	}
}
	
