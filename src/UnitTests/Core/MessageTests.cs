using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.Core
{
    public class When_Creating_a_Diagnostic_Message : Specification
    {
        private AssortmentAnalysis _assortment;
        private Diagnostic _diag;
        private DiagnosticMessage _result;

        protected override void Arrange()
        {
            _assortment = StaticMocks.AssortmentMocker.GetAssortment();
            _diag = new Diagnostic()
            {
                Creator =  "Foo"
            };
            _assortment.AddCapability(_diag);
        }

        protected override void Act()
        {
            _result = new DiagnosticMessage(_diag);
        }

        [Test]
        public void It_Should_Have_the_Correct_Capability_Code()
        {
            Assert.That(_result.CapabilityCode, Is.EqualTo(1));
        }

        [Test]
        public void It_Should_Have_the_Correct_Assortmnet_Information()
        {
            Assert.That(_result.RollUpTypeCode, Is.EqualTo(_assortment.Rollup.Code));
            Assert.That(_result.AssortCapabilityId, Is.EqualTo(0));
            Assert.That(_result.AssortmentId, Is.EqualTo(_assortment.Id));
            Assert.That(_result.AssortmentName, Is.EqualTo(_assortment.Name));
            Assert.That(_result.CreateUserId, Is.EqualTo(_diag.Creator));
            
        }
    }

    public class When_Creating_a_CDT_Message : Specification
    {
        private DecisionTree _cdt;
        private DecisionTreeMessage _result;

        protected override void Arrange()
        {
            _cdt = new DecisionTree()
            {
                AssortmentAnalysis = StaticMocks.AssortmentMocker.GetAssortment(),
            };


        }

        protected override void Act()
        {
            _result = new DecisionTreeMessage(_cdt);
        }

        [Test]
        public void It_Should_Have_the_Correct_Capability_Code()
        {
            Assert.That(_result.CapabilityCode, Is.EqualTo(2));
        }
    }

    public class When_Creating_a_StoreClustering_Message : Specification
    {
        private StoreClustering _storeClustering;
        private StoreClusteringMessage _result;

        protected override void Arrange()
        {
            _storeClustering = new StoreClustering()
            {
                AssortmentAnalysis = StaticMocks.AssortmentMocker.GetAssortment(),
            };


        }

        protected override void Act()
        {
            _result = new StoreClusteringMessage(_storeClustering);
        }

        [Test]
        public void It_Should_Have_the_Correct_Capability_Code()
        {
            Assert.That(_result.CapabilityCode, Is.EqualTo(3));
        }

    }
    public class When_Creating_a_Loyalt_Message : Specification
    {
        private LoyaltyReport _loyaltyReport;
        private LoyaltyMessage _result;

        protected override void Arrange()
        {
            _loyaltyReport = StaticMocks.CapabilityMocker.GetLoyalty();
            _loyaltyReport.AssortmentAnalysis = StaticMocks.AssortmentMocker.GetAssortment();
        }

        protected override void Act()
        {
            _result = new LoyaltyMessage(_loyaltyReport);
        }

        [Test]
        public void It_Should_Have_the_Correct_Capability_Code()
        {
            Assert.That(_result.CapabilityCode, Is.EqualTo(4));
        }

        [Test]
        public void It_Should_Have_the_Correct_Loyalty_Parameters()
        {
            Assert.That(_result.LoyaltyLevel, Is.EqualTo(_loyaltyReport.LoyaltyLevel.Value));
            Assert.That(_result.UseClustering, Is.EqualTo(Convert.ToBoolean(_loyaltyReport.UseClustering.Value)));
        }

    }
    public class When_Creating_a_Substitution_Message : Specification
    {
        private Substitution _substitution;
        private SubstitutionMessage _result;

        protected override void Arrange()
        {
            _substitution = new Substitution()
            {
                AssortmentAnalysis = StaticMocks.AssortmentMocker.GetAssortment()
            };

        }

        protected override void Act()
        {
            _result = new SubstitutionMessage(_substitution);
        }

        [Test]
        public void It_Should_Have_the_Correct_Capability_Code()
        {
            Assert.That(_result.CapabilityCode, Is.EqualTo(5));
        }

    }
}
