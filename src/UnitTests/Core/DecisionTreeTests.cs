using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Core
{
    public class When_creating_a_cdt_from_a_request : Specification
    {
        private CreateDecisionTreeRequest _request;
        private string _user;
        private DecisionTree _result;
        private AssortmentAnalysis _assort;
        protected override void Arrange()
        {
            _user = "tester";
            _request = new CreateDecisionTreeRequest
            {
                AssortmentID = 1001
            };
            _assort = new AssortmentAnalysis()
            {
                Id = 1001,
                Department = 92,
                Name = "JAMS & JELLY",
                Rollup = new RollupLevel { Code = 1 }
            };
        }
        protected override void Act()
        {
            _result = new DecisionTree(_request, _user, CapabilityStatus.Waiting);
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
        public void It_should_not_have_any_files()
        {
            Assert.That(_result.YulesQMatrixExists, Is.False);
            Assert.That(_result.ItemMetricsExists, Is.False);
            Assert.That(_result.AssortmentDescriptionExists, Is.False);
        }
    }
}
