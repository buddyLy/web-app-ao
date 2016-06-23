using System.Linq;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
    public class DiagnosticTests : Behaves_like_Persistence_Spec
    {
        private Diagnostic _result;
        private Diagnostic _resultById;

        private int _capabilityId;
        private int _assortmentId;

        protected override void Arrange()
        {
            base.Arrange();
            _capabilityId = 220;
            _assortmentId = 230;
        }

        protected override void Act()
        {
            _result = repository.Get<Diagnostic>(x => x.Id == _capabilityId);
            var assort = repository.Get<AssortmentAnalysis>(x =>  x.Id == _assortmentId);
            _resultById = assort.Capabilities.FirstOrDefault() as Diagnostic;
        }

        [Test]
        public void It_should_not_return_null()
        {
            Assert.That(_result, Is.Not.Null);
        }

        [Test]
        public void It_should_return_an_assortment_with_the_correct_id()
        {
            Assert.That(_result.Id, Is.EqualTo(_capabilityId));
        }

        [Test]
        public void It_is_selectable_by_the_assortment_id()
        {
            Assert.That(_resultById.Id == _capabilityId);
            Assert.That(_resultById.AssortmentAnalysis.Id == _assortmentId);
        }

        [Test]
        public void It_has_an_item_file()
        {
            Assert.That(_result.DiagnosticItemList, Is.Not.Null);
        }

        [Test]
        public void It_has_a_results_file()
        {
            Assert.That(_result.DiagnosticResultsExists, Is.False);
        }
    }
}
