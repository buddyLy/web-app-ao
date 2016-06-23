using System;
using System.IO;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
    public class LoyaltyReportPersistanceTests : Behaves_like_Persistence_Spec
    {
        private LoyaltyReport _result;
        private AssortmentAnalysis _assortment;
        private CreateAssortmentRequest _assortRequest;
        private CreateLoyaltyReportRequest _loyaltyRequest;

        protected override void Arrange()
        {
            base.Arrange();
            _assortRequest = new CreateAssortmentRequest()
            {
                Department = 22,
                Name = "Loyalty Test Assortment",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                RollUpTypeCode = 1,
                ItemList = Convert.ToBase64String(File.ReadAllBytes(@"Files\sample.csv"))
            };
            _assortment = new AssortmentAnalysis(_assortRequest, "tester");

            _loyaltyRequest = new CreateLoyaltyReportRequest()
            {
                AssortmentID = -1,
                ItemList = Convert.ToBase64String(File.ReadAllBytes(@"Files\sample.csv")),
                LoyaltyLevel = "Item",
                StoreClustering = Convert.ToBase64String(File.ReadAllBytes(@"Files\sample.csv")),
                UseClustering = true
            };
        }

        protected override void Act()
        {
            repository.Save<AssortmentAnalysis>(_assortment);
            repository.SubmitChanges();
            if (_assortment.Id <= 0) return;
            _loyaltyRequest.AssortmentID = _assortment.Id;
            var loyalty = new LoyaltyReport(_loyaltyRequest, _assortment.Creator, CapabilityStatus.Waiting);
            _assortment.AddCapability(loyalty);
            repository.Save<LoyaltyReport>(loyalty);
            repository.SubmitChanges();

            _result = repository.Get<LoyaltyReport>(x => x.Id == loyalty.Id);
        }

        [Test]
        public void It_has_the_correct_parameters()
        {
            Assert.That(_result.LoyaltyLevel.Value, Is.EqualTo("Item"));
            Assert.That(_result.UseClustering.Value, Is.EqualTo("TRUE"));
        }

        [Test]
        public void It_has_the_correct_files()
        {
            Assert.That(_result.StoreClustering, Is.Not.Null);
            Assert.That(_result.ItemList, Is.Not.Null);
        }

        [Test]
        public void It_matches_the_assortment()
        {
            Assert.That(_result.AssortmentAnalysis.Id, Is.EqualTo(_assortment.Id));
        }

        public override void TearDown()
        {
            repository.Delete<AssortmentAnalysis>(_assortment);
            repository.SubmitChanges();
            base.TearDown();
        }
    }
}
