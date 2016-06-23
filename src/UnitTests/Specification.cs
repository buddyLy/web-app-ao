using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace  Walmart.Assortment.AssortmentOptimizationSystem.UnitTests {
    [TestFixture]
    public abstract class Specification {
        [TestFixtureSetUp]
        public void SetUp() {
            Arrange();
            Act();
        }

        protected virtual void Arrange() { }
        protected virtual void Act() { }

        [TestFixtureTearDown]
        public virtual void TearDown() {
        }

        protected T Mock<T>(params object[] arguementsForCtor) where T : class {
            return MockRepository.GenerateMock<T>(arguementsForCtor);
        }

        protected T Stub<T>(params object[] arguementsForCtor) where T : class {
            return MockRepository.GenerateStub<T>(arguementsForCtor);
        }
    }
}