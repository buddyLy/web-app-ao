using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Core
{
    class When_creating_StoreClustering_from_a_request : Specification
    {
        private CreateStoreClusteringRequest _request;
        private AssortmentAnalysis _assort;
        private string _user;
        private StoreClustering _result;
        protected override void Arrange()
        {
            _user = "tester";
            _request = new CreateStoreClusteringRequest()
            {
                AssortmentID = 1001,
                StoreList = @"bG9sLGlkayx3dGYsYmJxLGd0Zw0KMSwyLDMsNCw1"
            };

            _assort = new AssortmentAnalysis()
			{
                Id = 1001,
				Department = 92,
				Name = "JAMS & JELLY",
				Rollup = new RollupLevel { Code = 1 },
			};
        }

        protected override void Act()
        {
            _result = new StoreClustering(_request, _user, CapabilityStatus.Waiting);
            _assort.AddCapability(_result);
        }

        [Test]
        public void It_should_have_the_correct_auditing_values()
        {
            Assert.That(_result.Creator, Is.EqualTo(_user));
            Assert.That(_result.Creator, Is.EqualTo(_result.LastChangedBy));
            Assert.That(_result.Created, Is.LessThanOrEqualTo(_result.LastChanged));
        }

        [Test]
        public void It_should_have_the_correct_status()
        {
            Assert.That(_result.Status.Code, Is.EqualTo(2));
        }

        [Test]
        public void It_is_assigned_to_an_assortment()
        {
            Assert.AreSame(_result.AssortmentAnalysis, _assort);
        }

        [Test]
        public void It_should_not_have_any_result_files()
        {
            Assert.That(_result.ModelSummaryFileExists, Is.False);
            Assert.That(_result.ReclassifedStoresFileExists, Is.False);
        }

        [Test]
        public void It_should_have_an_input_file()
        {
            Assert.That(_result.StoreList, Is.Not.Null);
        }
    }
}
